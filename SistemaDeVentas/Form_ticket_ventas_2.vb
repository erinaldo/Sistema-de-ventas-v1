'Imports System.IO
'Imports System.Drawing.Drawing2D
'Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.IO
Imports System.Math
Public Class Form_ticket_ventas_2
    Dim mifecha2 As String
    Dim desglose_palabras As String
    Dim peso As String
    Private WithEvents Pd As New PrintDocument
    Dim varnumdoc As Integer

    Dim contador As Integer

    Dim desglose_letra As String
    Dim cantidad_letras As Integer


    Dim impresion_de_documento As String
    Private Sub Form_tikcet_ventas_2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_tikcet_ventas_2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_tikcet_ventas_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_vendedor()
        mostrar_datos_vendedor()
        mostrar_malla()
        'dtp_hasta.CustomFormat = "yyy-MM-dd"
        dtp_vencimiento.CustomFormat = "yyy-MM-dd"
        dtp_vencimiento.Value = dtp_vencimiento.Value.AddMonths(Val(+1))

        condiciones()
        btn_play_vendedor.Visible = False
        btn_pause_vendedor.Visible = True

        'Dim nro_vale As String
        'Dim tipo_doc As String
        'Dim condicion_doc As String   
        'Dim nombre_vendedor As String

        'nro_vale = grilla_documento.CurrentRow.Cells(0).Value
        'tipo_doc = grilla_documento.CurrentRow.Cells(1).Value
        'condicion_doc = grilla_documento.CurrentRow.Cells(2).Value
        'nombre_vendedor = grilla_documento.CurrentRow.Cells(21).Value

        'combo_venta.Text = tipo_doc
        'combo_condiciones.SelectedItem = condicion_doc
        'Combo_vendedor.Text = nombre_vendedor
        'txt_nro_vale.Text = nro_vale
        grilla_documento.Font = New System.Drawing.Font("Arial", 9.7!, System.Drawing.FontStyle.Regular)
        'grilla_cuotas.Font = New System.Drawing.Font("Arial", 9.7!, System.Drawing.FontStyle.Regular)
        grilla_detalle_documento.Font = New System.Drawing.Font("Arial", 9.7!, System.Drawing.FontStyle.Regular)
        Timer_actualizar.Start()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
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
                txt_rut_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
            End If

            conexion.Close()
        End If
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = Form_menu_principal.dtp_fecha.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")
    End Sub






    Sub condiciones()

        combo_condiciones.Items.Clear()
        combo_condiciones.Items.Add("-")
        combo_condiciones.Items.Add("EFECTIVO")
        combo_condiciones.Items.Add("TARJETA DEBITO")
        combo_condiciones.Items.Add("TARJETA CREDITO")
        combo_condiciones.Items.Add("CHEQUE AL DIA")
        combo_condiciones.Items.Add("CHEQUE 30 DIAS")
        combo_condiciones.Items.Add("CHEQUE 30-60 DIAS")
        combo_condiciones.Items.Add("CHEQUE 30-60-90 DIAS")
        combo_condiciones.Items.Add("TRANSFERENCIA")
        combo_condiciones.Items.Add("PENDIENTE")
        combo_condiciones.Items.Add("LETRA")
        combo_condiciones.Items.Add("OTRO MEDIO DE PAGO")
        combo_condiciones.Items.Add("CREDITO")
        combo_condiciones.SelectedItem = "-"

    End Sub

    Sub mostrar_malla()
        fecha()
        conexion.Close()
        Dim DT3 As New DataTable
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion
        SC3.CommandText = "select  n_ticket as 'NRO.',  TIPO as 'TIPO', condiciones as 'CONDIC.', fecha_venta as 'FECHA',  cod_cliente as 'CODIGO', ticket_venta.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', direccion_cliente as 'DIRECCION', comuna_cliente as 'COMUNA', ciudad_cliente as 'CIUDAD', telefono_cliente as 'TELEFONO', folio_cliente as 'FOLIO', giro_cliente as 'GIRO', email_cliente as 'CORREO', subtotal as 'SUBTOTAL', porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', rut_usuario as 'RUT VENDEDOR', nombre_usuario as 'VENDEDOR', rut_retira as 'RUT RETIRA', nombre_cliente_retira as 'RETIRA', ticket_venta.ESTADO as 'ESTADO', ticket_venta.orden_de_compra as 'OC' , ticket_venta.PIE as 'PIE', ticket_venta.CONVENIO as CONVENIO , ticket_venta.condicion_de_pago_pie as 'PAGO PIE', ticket_venta.hora as 'HORA' from ticket_venta, usuarios, clientes, clientes_retira  where fecha_venta ='" & (mifecha2) & "' and ticket_venta.usuario_responsable=usuarios.rut_usuario and ticket_venta.codigo_cliente=clientes.cod_cliente and ticket_venta.rut_retira=clientes_retira.rut_cliente_retira group by n_ticket order by n_ticket desc"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        grilla_documento.DataSource = DS3.Tables(DT3.TableName)
        conexion.Close()
        For i = 0 To grilla_documento.Rows.Count - 1
            Dim estado_doc As String
            estado_doc = grilla_documento.Rows(i).Cells(24).Value.ToString
            If estado_doc = "EMITIDO" Then
                grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If
        Next

        grilla_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_documento.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(26).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(27).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(29).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grilla_documento.Columns(2).Visible = True
        grilla_documento.Columns(3).Visible = False
        grilla_documento.Columns(4).Visible = False
        grilla_documento.Columns(5).Visible = False
        grilla_documento.Columns(7).Visible = False
        grilla_documento.Columns(8).Visible = False
        grilla_documento.Columns(9).Visible = False
        grilla_documento.Columns(10).Visible = False
        grilla_documento.Columns(11).Visible = False
        grilla_documento.Columns(12).Visible = False
        grilla_documento.Columns(13).Visible = False
        grilla_documento.Columns(15).Visible = False
        grilla_documento.Columns(17).Visible = False
        grilla_documento.Columns(18).Visible = False
        grilla_documento.Columns(20).Visible = False
        grilla_documento.Columns(22).Visible = False
        grilla_documento.Columns(23).Visible = False
        grilla_documento.Columns(24).Visible = False
        grilla_documento.Columns(25).Visible = False
        grilla_documento.Columns(26).Visible = False
        grilla_documento.Columns(27).Visible = False
        grilla_documento.Columns(28).Visible = False
        grilla_detalle_documento.Rows.Clear()

        'grilla_letra.Rows.Clear()
        'grilla_cuotas.Rows.Clear()
        'grilla_pago_combinado.Rows.Clear()

        combo_condiciones.SelectedItem = "-"
        txt_nro_vale.Text = "0"

        txt_efectivo.Text = ""
        txt_vuelto.Text = ""
    End Sub





    Sub mostrar_malla_doc()
        fecha()


        conexion.Close()
        Dim DT3 As New DataTable

        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion

        SC3.CommandText = "select  n_ticket as 'NRO.',  TIPO as 'TIPO', condiciones as 'CONDIC.', fecha_venta as 'FECHA',  cod_cliente as 'CODIGO', ticket_venta.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', direccion_cliente as 'DIRECCION', comuna_cliente as 'COMUNA', ciudad_cliente as 'CIUDAD', telefono_cliente as 'TELEFONO', folio_cliente as 'FOLIO', giro_cliente as 'GIRO', email_cliente as 'CORREO', subtotal as 'SUBTOTAL', porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', rut_usuario as 'RUT VENDEDOR', nombre_usuario as 'VENDEDOR', rut_retira as 'RUT RETIRA', nombre_cliente_retira as 'RETIRA', ticket_venta.ESTADO as 'ESTADO' from ticket_venta, usuarios, clientes, clientes_retira  where fecha_venta ='" & (mifecha2) & "' and  ticket_venta.TIPO ='" & (combo_venta.Text) & "' and ticket_venta.usuario_responsable=usuarios.rut_usuario and ticket_venta.rut_cliente=clientes.rut_cliente and ticket_venta.rut_retira=clientes_retira.rut_cliente_retira group by n_ticket order by n_ticket desc"

        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        grilla_documento.DataSource = DS3.Tables(DT3.TableName)
        conexion.Close()

        grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(26).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(4).Visible = False
        grilla_documento.Columns(5).Visible = False
        grilla_documento.Columns(7).Visible = False
        grilla_documento.Columns(8).Visible = False
        grilla_documento.Columns(9).Visible = False
        grilla_documento.Columns(10).Visible = False
        grilla_documento.Columns(11).Visible = False
        grilla_documento.Columns(12).Visible = False
        grilla_documento.Columns(13).Visible = False
        grilla_documento.Columns(17).Visible = False
        grilla_documento.Columns(18).Visible = False
        grilla_documento.Columns(20).Visible = False
        grilla_documento.Columns(22).Visible = False
        grilla_documento.Columns(23).Visible = False
        grilla_documento.Columns(24).Visible = False
        For i = 0 To grilla_documento.Rows.Count - 1

            Dim estado_doc As String
            estado_doc = grilla_documento.Rows(i).Cells(24).Value.ToString
            If estado_doc = "EMITIDO" Then
                grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
            End If
        Next

        grilla_detalle_documento.Rows.Clear()





    End Sub






    Sub mostrar_malla_vendedor()
        fecha()


        conexion.Close()
        Dim DT3 As New DataTable

        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion

        SC3.CommandText = "select  n_ticket as 'NRO.',  TIPO as 'TIPO', condiciones as 'CONDIC.', fecha_venta as 'FECHA',  cod_cliente as 'CODIGO', ticket_venta.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', direccion_cliente as 'DIRECCION', comuna_cliente as 'COMUNA', ciudad_cliente as 'CIUDAD', telefono_cliente as 'TELEFONO', folio_cliente as 'FOLIO', giro_cliente as 'GIRO', email_cliente as 'CORREO', subtotal as 'SUBTOTAL', porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', rut_usuario as 'RUT VENDEDOR', nombre_usuario as 'VENDEDOR', rut_retira as 'RUT RETIRA', nombre_cliente_retira as 'RETIRA', ticket_venta.ESTADO as 'ESTADO' from ticket_venta, usuarios, clientes, clientes_retira  where fecha_venta ='" & (mifecha2) & "' and  ticket_venta.usuario_responsable ='" & (txt_rut_vendedor.Text) & "' and ticket_venta.usuario_responsable=usuarios.rut_usuario and ticket_venta.rut_cliente=clientes.rut_cliente and ticket_venta.rut_retira=clientes_retira.rut_cliente_retira group by n_ticket order by n_ticket desc"

        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        grilla_documento.DataSource = DS3.Tables(DT3.TableName)
        conexion.Close()

        grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grilla_documento.Columns(4).Visible = False
        grilla_documento.Columns(5).Visible = False
        grilla_documento.Columns(7).Visible = False
        grilla_documento.Columns(8).Visible = False
        grilla_documento.Columns(9).Visible = False
        grilla_documento.Columns(10).Visible = False
        grilla_documento.Columns(11).Visible = False
        grilla_documento.Columns(12).Visible = False
        grilla_documento.Columns(13).Visible = False
        grilla_documento.Columns(17).Visible = False
        grilla_documento.Columns(18).Visible = False
        grilla_documento.Columns(20).Visible = False
        grilla_documento.Columns(22).Visible = False
        grilla_documento.Columns(23).Visible = False
        grilla_documento.Columns(24).Visible = False
        For i = 0 To grilla_documento.Rows.Count - 1

            Dim estado_doc As String
            estado_doc = grilla_documento.Rows(i).Cells(24).Value.ToString
            If estado_doc = "EMITIDO" Then
                grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
            End If
        Next

        grilla_detalle_documento.Rows.Clear()





    End Sub







    Sub mostrar_malla_detalle()

        Dim nro_doc As String
        Dim hora_doc As String
        Dim rut_vendedor As String

        nro_doc = grilla_documento.CurrentRow.Cells(0).Value
        hora_doc = grilla_documento.CurrentRow.Cells(29).Value
        rut_vendedor = grilla_documento.CurrentRow.Cells(20).Value

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from detalle_ticket_venta where hora= '" & (hora_doc) & "' and usuario_responsable= '" & (rut_vendedor) & "' and fecha_venta= '" & (Form_menu_principal.dtp_fecha.Text) & "'"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_detalle_documento.Rows.Clear()

        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_detalle_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("precio_lista"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("precio_venta"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
            Next
        End If



        If grilla_detalle_documento.Rows.Count <> 0 Then
            grilla_detalle_documento.Columns(1).Width = 50
            If grilla_detalle_documento.Columns(1).Width = 260 Then
                grilla_detalle_documento.Columns(1).Width = 259
            Else
                grilla_detalle_documento.Columns(1).Width = 260
            End If
        End If

        'grilla_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_documento.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grilla_detalle_documento.Columns(8).Visible = False
        grilla_detalle_documento.Columns(9).Visible = False
    End Sub



    Private Sub grilla_documento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.Click
        'Dim condicion As String


        If grilla_documento.Rows.Count = 0 Then
            Exit Sub
        End If





        Dim nro_vale As String
        Dim tipo_doc As String
        Dim condicion_doc As String
        Dim fecha_doc As String
        Dim cod_cliente As String
        Dim rut_cliente As String
        Dim nombre_cliente As String
        Dim direccion_cliente As String
        Dim comuna_cliente As String
        Dim ciudad_cliente As String
        Dim telefono_cliente As String
        Dim folio_cliente As String
        Dim giro_cliente As String
        Dim correo_cliente As String
        Dim subtotal_doc As String
        Dim porcentaje_desc_doc As String
        Dim descuento_doc As String
        Dim neto_doc As String
        Dim iva_doc As String
        Dim total_doc As String
        Dim rut_vendedor As String
        Dim nombre_vendedor As String
        Dim rut_retira As String
        Dim nombre_retira As String


        nro_vale = grilla_documento.CurrentRow.Cells(0).Value
        tipo_doc = grilla_documento.CurrentRow.Cells(1).Value
        condicion_doc = grilla_documento.CurrentRow.Cells(2).Value
        fecha_doc = grilla_documento.CurrentRow.Cells(3).Value
        cod_cliente = grilla_documento.CurrentRow.Cells(4).Value
        rut_cliente = grilla_documento.CurrentRow.Cells(5).Value
        nombre_cliente = grilla_documento.CurrentRow.Cells(6).Value
        direccion_cliente = grilla_documento.CurrentRow.Cells(7).Value
        comuna_cliente = grilla_documento.CurrentRow.Cells(8).Value
        ciudad_cliente = grilla_documento.CurrentRow.Cells(9).Value
        telefono_cliente = grilla_documento.CurrentRow.Cells(10).Value
        folio_cliente = grilla_documento.CurrentRow.Cells(11).Value
        giro_cliente = grilla_documento.CurrentRow.Cells(12).Value
        correo_cliente = grilla_documento.CurrentRow.Cells(13).Value
        subtotal_doc = grilla_documento.CurrentRow.Cells(14).Value
        porcentaje_desc_doc = grilla_documento.CurrentRow.Cells(15).Value
        descuento_doc = grilla_documento.CurrentRow.Cells(16).Value
        neto_doc = grilla_documento.CurrentRow.Cells(17).Value
        iva_doc = grilla_documento.CurrentRow.Cells(18).Value
        total_doc = grilla_documento.CurrentRow.Cells(19).Value
        rut_vendedor = grilla_documento.CurrentRow.Cells(20).Value
        nombre_vendedor = grilla_documento.CurrentRow.Cells(21).Value
        rut_retira = grilla_documento.CurrentRow.Cells(22).Value
        nombre_retira = grilla_documento.CurrentRow.Cells(23).Value


        If txt_nro_vale.Text = nro_vale Then
        Else
            combo_venta.Text = tipo_doc
            combo_condiciones.SelectedItem = condicion_doc
            Combo_vendedor.Text = nombre_vendedor
            txt_nro_vale.Text = nro_vale
        End If


        txt_efectivo.Focus()

        grilla_detalle_documento.Rows.Clear()

        mostrar_malla_detalle()


        peso = " PESOS"
        If CInt(total_doc) = 1000000 Then
            desglose_palabras = Num2Text(total_doc) & " DE PESOS"
        ElseIf CInt(total_doc) = 2000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 3000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 4000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 5000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 6000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 7000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 8000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 9000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 10000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 11000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 12000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 13000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 14000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 15000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 16000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 17000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 18000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 19000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 20000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 21000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 22000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 23000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 24000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 25000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 26000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 27000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 28000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 29000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        ElseIf CInt(total_doc) = 30000000 Then
            desglose_palabras = Num2Text(total_doc) & "DE PESOS"
        Else
            desglose_palabras = Num2Text(total_doc) & peso
        End If



        txt_efectivo.Text = ""
        txt_vuelto.Text = ""

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

    Private Sub grilla_documento_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.DoubleClick

        If grilla_documento.Rows.Count = 0 Then
            Exit Sub
        End If




        If combo_condiciones.Text = "" Then
            Exit Sub
        End If

        If combo_condiciones.Text = "-" Then
            Exit Sub
        End If


        btn_imprimir.PerformClick()
        'Dim nro_vale As String
        'Dim tipo_doc As String
        'Dim condicion_doc As String
        'Dim fecha_doc As String
        'Dim cod_cliente As String
        'Dim rut_cliente As String
        'Dim nombre_cliente As String
        'Dim direccion_cliente As String
        'Dim comuna_cliente As String
        'Dim ciudad_cliente As String
        'Dim telefono_cliente As String
        'Dim folio_cliente As String
        'Dim giro_cliente As String
        'Dim correo_cliente As String
        'Dim subtotal_doc As String
        'Dim porcentaje_desc_doc As String
        'Dim descuento_doc As String
        'Dim neto_doc As String
        'Dim iva_doc As String
        'Dim total_doc As String
        'Dim rut_vendedor As String
        'Dim nombre_vendedor As String
        'Dim rut_retira As String
        'Dim nombre_retira As String


        'nro_vale = grilla_documento.CurrentRow.Cells(0).Value
        'tipo_doc = grilla_documento.CurrentRow.Cells(1).Value
        'condicion_doc = grilla_documento.CurrentRow.Cells(2).Value
        'fecha_doc = grilla_documento.CurrentRow.Cells(3).Value
        'cod_cliente = grilla_documento.CurrentRow.Cells(4).Value
        'rut_cliente = grilla_documento.CurrentRow.Cells(5).Value
        'nombre_cliente = grilla_documento.CurrentRow.Cells(6).Value
        'direccion_cliente = grilla_documento.CurrentRow.Cells(7).Value
        'comuna_cliente = grilla_documento.CurrentRow.Cells(8).Value
        'ciudad_cliente = grilla_documento.CurrentRow.Cells(9).Value
        'telefono_cliente = grilla_documento.CurrentRow.Cells(10).Value
        'folio_cliente = grilla_documento.CurrentRow.Cells(11).Value
        'giro_cliente = grilla_documento.CurrentRow.Cells(12).Value
        'correo_cliente = grilla_documento.CurrentRow.Cells(13).Value
        'subtotal_doc = grilla_documento.CurrentRow.Cells(14).Value
        'porcentaje_desc_doc = grilla_documento.CurrentRow.Cells(15).Value
        'descuento_doc = grilla_documento.CurrentRow.Cells(16).Value
        'neto_doc = grilla_documento.CurrentRow.Cells(17).Value
        'iva_doc = grilla_documento.CurrentRow.Cells(18).Value
        'total_doc = grilla_documento.CurrentRow.Cells(19).Value
        'rut_vendedor = grilla_documento.CurrentRow.Cells(20).Value
        'nombre_vendedor = grilla_documento.CurrentRow.Cells(21).Value
        'rut_retira = grilla_documento.CurrentRow.Cells(22).Value
        'nombre_retira = grilla_documento.CurrentRow.Cells(23).Value




        'If combo_condiciones.Text = "LETRA" Then
        '    Me.Enabled = False
        '    Form_calcular_cuotas.txt_doc_referencia.Text = tipo_doc
        '    Form_calcular_cuotas.txt_monto.Text = total_doc
        '    Form_calcular_cuotas.txt_cod_cliente.Text = cod_cliente
        '    Form_calcular_cuotas.mostrar_datos_clientes()


        '    If Form_calcular_cuotas.txt_monto.Text = "" Or Form_calcular_cuotas.txt_monto.Text = "0" Then
        '        Form_calcular_cuotas.txt_monto_millar.Text = "0"
        '    Else
        '        Form_calcular_cuotas.txt_monto_millar.Text = Format(Int(Form_calcular_cuotas.txt_monto.Text), "###,###,###")
        '    End If


        '    Form_calcular_cuotas.Show()
        '    Form_calcular_cuotas.txt_pie.Focus()
        '    Exit Sub
        'End If





        'If tipo_doc = "BOLETA" Then
        '    valormensaje = MsgBox("¿DESEA IMPRIMIR ESTE DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        '    If valormensaje = vbYes Then

        '        If estado_boleta_electronica = "NO" Then
        '            With Pd.PrinterSettings
        '                ' Especifico el nombre de la impresora 
        '                ' por donde deseo imprimir. 
        '                .PrinterName = impresora_boletas
        '                ' Establezco el número de copias que se imprimirán 
        '                .Copies = 1
        '                ' Rango de páginas que se imprimirán 
        '                .PrintRange = PrintRange.AllPages
        '                If .IsValid Then

        '                    Me.Enabled = False
        '                    Me.crear_numero_documento()
        '                    Me.grabar_factura()


        '                    Me.Pd.PrintController = New StandardPrintController
        '                    Me.Pd.DefaultPageSettings.Margins.Left = 10
        '                    Me.Pd.DefaultPageSettings.Margins.Right = 10
        '                    Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 547)
        '                    Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1

        '                    Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
        '                    Pd.Print()

        '                    Me.grabar_detalle_factura()
        '                    Me.crear_archivo_plano()
        '                    MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '                    Me.Enabled = True

        '                    Exit Sub
        '                Else
        '                    MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
        '                    Me.Enabled = True
        '                    Exit Sub
        '                End If
        '            End With
        '        Else

        '            Me.Enabled = False
        '            Me.crear_numero_documento()
        '            Me.grabar_factura()
        '            Me.grabar_detalle_factura()
        '            Me.crear_archivo_plano()
        '            MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '            Me.Enabled = True
        '            Exit Sub

        '        End If
        '    End If
        '    Exit Sub
        'End If




        'If tipo_doc = "BOLETA DE CREDITO" Then
        '    valormensaje = MsgBox("¿DESEA IMPRIMIR ESTE DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        '    If valormensaje = vbYes Then

        '        If estado_boleta_electronica = "NO" Then
        '            With Pd.PrinterSettings
        '                ' Especifico el nombre de la impresora 
        '                ' por donde deseo imprimir. 
        '                .PrinterName = impresora_boletas
        '                ' Establezco el número de copias que se imprimirán 
        '                .Copies = 1
        '                ' Rango de páginas que se imprimirán 
        '                .PrintRange = PrintRange.AllPages
        '                If .IsValid Then

        '                    Me.Enabled = False
        '                    Me.crear_numero_documento()
        '                    Me.grabar_factura()


        '                    Me.Pd.PrintController = New StandardPrintController
        '                    Me.Pd.DefaultPageSettings.Margins.Left = 10
        '                    Me.Pd.DefaultPageSettings.Margins.Right = 10
        '                    Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 547)
        '                    Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1

        '                    Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
        '                    Pd.Print()

        '                    Me.grabar_detalle_factura()
        '                    Me.crear_archivo_plano()
        '                    MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '                    Me.Enabled = True
        '                    Exit Sub
        '                Else
        '                    MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
        '                    Me.Enabled = True
        '                    Exit Sub
        '                End If
        '            End With
        '        Else

        '            Me.Enabled = False
        '            Me.crear_numero_documento()
        '            Me.grabar_factura()
        '            Me.grabar_detalle_factura()
        '            Me.crear_archivo_plano()
        '            MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '            Me.Enabled = True
        '            Exit Sub

        '        End If
        '    End If
        'End If





        'If tipo_doc = "FACTURA" Then
        '    valormensaje = MsgBox("¿DESEA IMPRIMIR ESTE DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        '    If valormensaje = vbYes Then

        '        If estado_factura_electronica = "NO" Then
        '            With Pd.PrinterSettings
        '                ' Especifico el nombre de la impresora 
        '                ' por donde deseo imprimir. 
        '                .PrinterName = impresora_facturas
        '                ' Establezco el número de copias que se imprimirán 
        '                .Copies = 1
        '                ' Rango de páginas que se imprimirán 
        '                .PrintRange = PrintRange.AllPages
        '                If .IsValid Then

        '                    Me.Enabled = False
        '                    Me.crear_numero_documento()
        '                    Me.grabar_factura()

        '                    '   .PrinterName = impresora_facturas

        '                    Me.Pd.PrintController = New StandardPrintController
        '                    Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 1100)
        '                    Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
        '                    Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
        '                    Pd.Print()

        '                    Me.grabar_detalle_factura()
        '                    Me.crear_archivo_plano()
        '                    MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '                    Me.Enabled = True
        '                    Exit Sub
        '                Else
        '                    MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
        '                    Me.Enabled = True
        '                    Exit Sub
        '                End If
        '            End With
        '        Else
        '            Me.Enabled = False
        '            Me.crear_numero_documento()
        '            Me.grabar_factura()
        '            Me.grabar_detalle_factura()
        '            Me.crear_archivo_plano()
        '            MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '            Me.Enabled = True
        '            Exit Sub
        '        End If
        '    End If
        'End If






        'If tipo_doc = "FACTURA DE CREDITO" Then
        '    valormensaje = MsgBox("¿DESEA IMPRIMIR ESTE DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        '    If valormensaje = vbYes Then

        '        If estado_factura_electronica = "NO" Then
        '            With Pd.PrinterSettings
        '                ' Especifico el nombre de la impresora 
        '                ' por donde deseo imprimir. 
        '                .PrinterName = impresora_facturas
        '                ' Establezco el número de copias que se imprimirán 
        '                .Copies = 1
        '                ' Rango de páginas que se imprimirán 
        '                .PrintRange = PrintRange.AllPages
        '                If .IsValid Then

        '                    Me.Enabled = False
        '                    Me.crear_numero_documento()
        '                    Me.grabar_factura()


        '                    Me.Pd.PrintController = New StandardPrintController
        '                    Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 1100)
        '                    Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
        '                    Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
        '                    Pd.Print()

        '                    Me.grabar_detalle_factura()
        '                    Me.crear_archivo_plano()
        '                    MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '                    Me.Enabled = True
        '                    Exit Sub
        '                Else
        '                    MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
        '                    Me.Enabled = True
        '                    Exit Sub
        '                End If
        '            End With
        '        Else

        '            Me.Enabled = False
        '            Me.crear_numero_documento()
        '            Me.grabar_factura()
        '            Me.grabar_detalle_factura()
        '            Me.crear_archivo_plano()
        '            MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '            Me.Enabled = True
        '            Exit Sub
        '        End If
        '    End If
        'End If





        'If tipo_doc = "GUIA" Then
        '    valormensaje = MsgBox("¿DESEA IMPRIMIR ESTE DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        '    If valormensaje = vbYes Then


        '        If estado_guia_electronica = "NO" Then
        '            With Pd.PrinterSettings
        '                ' Especifico el nombre de la impresora 
        '                ' por donde deseo imprimir. 
        '                .PrinterName = impresora_guias
        '                ' Establezco el número de copias que se imprimirán 
        '                .Copies = 1
        '                ' Rango de páginas que se imprimirán 
        '                .PrintRange = PrintRange.AllPages
        '                If .IsValid Then

        '                    Me.Enabled = False
        '                    Me.crear_numero_documento()
        '                    Me.grabar_factura()


        '                    Me.Pd.PrintController = New StandardPrintController
        '                    Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
        '                    Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
        '                    Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
        '                    Pd.Print()


        '                    Me.grabar_detalle_factura()
        '                    Me.crear_archivo_plano()
        '                    MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '                    Me.Enabled = True
        '                    Exit Sub
        '                Else
        '                    MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
        '                    Me.Enabled = True
        '                    Exit Sub
        '                End If
        '            End With
        '        Else

        '            Me.Enabled = False
        '            Me.crear_numero_documento()
        '            Me.grabar_factura()
        '            Me.grabar_detalle_factura()
        '            Me.crear_archivo_plano()
        '            MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '            Me.Enabled = True
        '            Exit Sub

        '        End If
        '    End If
        'End If



    End Sub


    Sub crear_numero_documento()
        Dim tipo_doc As String

        tipo_doc = grilla_documento.CurrentRow.Cells(1).Value

        If tipo_doc = "FACTURA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select max(cod_auto) as cod_auto from factura where tipo_impresion <> 'DIGITADA'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                    'txt_factura.Text = varnumdoc + 1
                End If
            Catch err As InvalidCastException
                txt_factura.Text = 1
                Exit Sub
            End Try
            conexion.Close()

            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select n_factura from factura where cod_auto='" & (varnumdoc) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_factura")
                    txt_factura.Text = varnumdoc + 1
                End If
            Catch err As InvalidCastException
                txt_factura.Text = 1
            End Try
            conexion.Close()
            Exit Sub
        End If

        If tipo_doc = "FACTURA DE CREDITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select max(cod_auto) as cod_auto from factura where tipo_impresion <> 'DIGITADA'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                    'txt_factura.Text = varnumdoc + 1
                End If
            Catch err As InvalidCastException
                txt_factura.Text = 1
                Exit Sub
            End Try
            conexion.Close()

            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select n_factura from factura where cod_auto='" & (varnumdoc) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_factura")
                    txt_factura.Text = varnumdoc + 1
                End If
            Catch err As InvalidCastException
                txt_factura.Text = 1
            End Try
            conexion.Close()
            Exit Sub
        End If

        If tipo_doc = "GUIA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select max(cod_auto) as cod_auto from guia where tipo_impresion <> 'DIGITADA'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                    'txt_factura.Text = varnumdoc + 1
                End If
            Catch err As InvalidCastException
                txt_factura.Text = 1
                Exit Sub
            End Try
            conexion.Close()

            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select n_guia from guia where cod_auto='" & (varnumdoc) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_guia")
                    txt_factura.Text = varnumdoc + 1
                End If
            Catch err As InvalidCastException
                txt_factura.Text = 1
            End Try
            conexion.Close()
            Exit Sub
        End If

        If tipo_doc = "BOLETA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select max(cod_auto) as cod_auto from BOLETA where tipo_impresion <> 'DIGITADA'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                    'txt_factura.Text = varnumdoc + 1
                End If
            Catch err As InvalidCastException
                txt_factura.Text = 1
                Exit Sub
            End Try
            conexion.Close()

            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select n_boleta from BOLETA where cod_auto='" & (varnumdoc) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_boleta")
                    txt_factura.Text = varnumdoc + 1
                End If
            Catch err As InvalidCastException
                txt_factura.Text = 1
            End Try
            conexion.Close()
            Exit Sub
        End If

        If tipo_doc = "BOLETA DE CREDITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select max(cod_auto) as cod_auto from BOLETA where tipo_impresion <> 'DIGITADA'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                    'txt_factura.Text = varnumdoc + 1
                End If
            Catch err As InvalidCastException
                txt_factura.Text = 1
                Exit Sub
            End Try
            conexion.Close()

            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select n_boleta from BOLETA where cod_auto='" & (varnumdoc) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_boleta")
                    txt_factura.Text = varnumdoc + 1
                End If
            Catch err As InvalidCastException
                txt_factura.Text = 1
            End Try
            conexion.Close()
            Exit Sub
        End If
    End Sub

    Sub grabar_factura()
        Dim nro_vale As String
        Dim tipo_doc As String
        Dim condicion_doc As String
        Dim fecha_doc As String
        Dim cod_cliente As String
        Dim rut_cliente As String
        Dim nombre_cliente As String
        Dim direccion_cliente As String
        Dim comuna_cliente As String
        Dim ciudad_cliente As String
        Dim telefono_cliente As String
        Dim folio_cliente As String
        Dim giro_cliente As String
        Dim correo_cliente As String
        Dim subtotal_doc As String
        Dim porcentaje_desc_doc As String
        Dim descuento_doc As String
        Dim neto_doc As String
        Dim iva_doc As String
        Dim total_doc As String
        Dim rut_vendedor As String
        Dim nombre_vendedor As String
        Dim rut_retira As String
        Dim nombre_retira As String
        Dim orden_de_compra As String
        Dim convenio As String
        Dim pie As String
        Dim forma_de_pago_pie As String

        nro_vale = grilla_documento.CurrentRow.Cells(0).Value
        tipo_doc = grilla_documento.CurrentRow.Cells(1).Value
        condicion_doc = grilla_documento.CurrentRow.Cells(2).Value
        fecha_doc = grilla_documento.CurrentRow.Cells(3).Value
        cod_cliente = grilla_documento.CurrentRow.Cells(4).Value
        rut_cliente = grilla_documento.CurrentRow.Cells(5).Value
        nombre_cliente = grilla_documento.CurrentRow.Cells(6).Value
        direccion_cliente = grilla_documento.CurrentRow.Cells(7).Value
        comuna_cliente = grilla_documento.CurrentRow.Cells(8).Value
        ciudad_cliente = grilla_documento.CurrentRow.Cells(9).Value
        telefono_cliente = grilla_documento.CurrentRow.Cells(10).Value
        folio_cliente = grilla_documento.CurrentRow.Cells(11).Value
        giro_cliente = grilla_documento.CurrentRow.Cells(12).Value
        correo_cliente = grilla_documento.CurrentRow.Cells(13).Value
        subtotal_doc = grilla_documento.CurrentRow.Cells(14).Value
        porcentaje_desc_doc = grilla_documento.CurrentRow.Cells(15).Value
        descuento_doc = grilla_documento.CurrentRow.Cells(16).Value
        neto_doc = grilla_documento.CurrentRow.Cells(17).Value
        iva_doc = grilla_documento.CurrentRow.Cells(18).Value
        total_doc = grilla_documento.CurrentRow.Cells(19).Value
        rut_vendedor = grilla_documento.CurrentRow.Cells(20).Value
        nombre_vendedor = grilla_documento.CurrentRow.Cells(21).Value
        rut_retira = grilla_documento.CurrentRow.Cells(22).Value
        nombre_retira = grilla_documento.CurrentRow.Cells(23).Value
        convenio = grilla_documento.CurrentRow.Cells(27).Value
        pie = Me.grilla_documento.CurrentRow.Cells(26).Value
        forma_de_pago_pie = grilla_documento.CurrentRow.Cells(28).Value

        Try
            orden_de_compra = grilla_documento.CurrentRow.Cells(25).Value
        Catch err As InvalidCastException
            orden_de_compra = 0
        End Try

        Dim mifecha As Date
        mifecha = fecha_doc
        fecha_doc = mifecha.ToString("yyy-MM-dd")

        Dim tipo_impresion As String
        tipo_impresion = ""

        condicion_doc = combo_condiciones.Text

        If condicion_doc = "LETRA" Then
            condicion_doc = "CREDITO"
        End If

        If condicion_doc = "CONVENIO" Then
            condicion_doc = "CREDITO"
        End If

        If tipo_doc = "GUIA" Then
            If estado_guia_electronica = "SI" Then
                tipo_impresion = "ELECTRONICA"
            Else
                tipo_impresion = "MANUAL"
            End If

            SC.Connection = conexion
            SC.CommandText = "insert into guia (caja, n_guia, TIPO, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable,rut_retira, nombre_retira, recinto, orden, hora, porcentaje_desc, tipo_impresion, pie, condicion_de_pago_pie, comision) values ('" & (nombre_pc) & "', " & (txt_factura.Text) & " , '" & ("GUIA") & "', '" & (rut_cliente) & "','" & (cod_cliente) & "','" & (fecha_doc) & "'," & (descuento_doc) & "," & (neto_doc) & "," & (iva_doc) & "," & (subtotal_doc) & "," & (total_doc) & ",'" & (condicion_doc) & "','" & ("SIN FACTURAR") & "','" & (rut_vendedor) & "','" & (rut_retira) & "','" & (nombre_retira) & "','" & (mirecintoempresa) & "','" & ("0") & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (porcentaje_desc_doc) & "', '" & (tipo_impresion) & "', '" & (pie) & "', '" & (forma_de_pago_pie) & "'," & (total_doc) & ")"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If


        If tipo_doc = "FACTURA DE CREDITO" Then

            If estado_factura_electronica = "SI" Then
                tipo_impresion = "ELECTRONICA"
            Else
                tipo_impresion = "MANUAL"
            End If

            SC.Connection = conexion
            SC.CommandText = "insert into factura (caja, n_factura, tipo, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable, rut_retira, nombre_retira, recinto, orden, hora, porcentaje_desc, tipo_impresion, pie, condicion_de_pago_pie, comision) values ('" & (nombre_pc) & "', " & (txt_factura.Text) & ",'" & ("FACTURA") & "','" & (rut_cliente) & "','" & (cod_cliente) & "', '" & (fecha_doc) & "'," & (descuento_doc) & "," & (neto_doc) & "," & (iva_doc) & "," & (subtotal_doc) & "," & (total_doc) & ",'" & (condicion_doc) & "','" & ("EMITIDA") & "','" & (miusuario) & "','" & (rut_retira) & "','" & (nombre_retira) & "','" & (mirecintoempresa) & "','" & (orden_de_compra) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (porcentaje_desc_doc) & "', '" & (tipo_impresion) & "', '" & (pie) & "', '" & (forma_de_pago_pie) & "'," & (total_doc) & ")"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into  creditos (n_creditos, TIPO, tipo_detalle, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, saldo, condiciones, estado, usuario_responsable, codigo_afecta, nombre_afecta, recinto, fecha_vencimiento, fecha_pago, numero_cuota, total_cuotas, pie, convenio) values (" & (txt_factura.Text) & ",'" & ("FACTURA") & "','" & ("FACTURA") & "','" & (rut_cliente) & "','" & (cod_cliente) & "','" & (fecha_doc) & "'," & (descuento_doc) & "," & (neto_doc) & "," & (iva_doc) & "," & (subtotal_doc) & "," & (total_doc) & "," & (total_doc) & ",'" & (condicion_doc) & "','" & ("EMITIDA") & "','" & (miusuario) & "','" & (txt_factura.Text) & "','FACTURA','" & (mirecintoempresa) & "', '" & (mirecintoempresa) & "', '" & (dtp_vencimiento.Text) & "', '0000-00-00', '1', '1','" & (pie) & "','" & (convenio) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "update clientes set saldo_cliente = saldo_cliente - " & (Int(total_doc)) & " where rut_cliente = '" & (rut_cliente) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        If tipo_doc = "BOLETA" Then
            If estado_boleta_electronica = "SI" Then
                tipo_impresion = "ELECTRONICA"
            Else
                tipo_impresion = "MANUAL"
            End If
            SC.Connection = conexion
            SC.CommandText = "insert into BOLETA (caja, n_boleta, tipo, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva,  subtotal, total, condiciones,estado, usuario_responsable, hora, porcentaje_desc, tipo_impresion, pie, condicion_de_pago_pie, comision) values ('" & (nombre_pc) & "', " & (txt_factura.Text) & " , 'BOLETA','" & (rut_cliente) & "','" & (cod_cliente) & "','" & (fecha_doc) & "'," & (descuento_doc) & "," & (neto_doc) & "," & (iva_doc) & "," & (subtotal_doc) & "," & (total_doc) & ",'" & (condicion_doc) & "','" & ("EMITIDA") & "','" & (miusuario) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (porcentaje_desc_doc) & "', '" & (tipo_impresion) & "', '" & (pie) & "', '" & (forma_de_pago_pie) & "'," & (total_doc) & ")"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If


        If tipo_doc = "BOLETA DE CREDITO" Then
            If estado_boleta_electronica = "SI" Then
                tipo_impresion = "ELECTRONICA"
            Else
                tipo_impresion = "MANUAL"
            End If

            SC.Connection = conexion
            SC.CommandText = "insert into BOLETA (caja, n_boleta, tipo, rut_cliente,  codigo_cliente,  fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable, hora, porcentaje_desc, tipo_impresion, pie, condicion_de_pago_pie, comision) values ('" & (nombre_pc) & "', " & (txt_factura.Text) & " , '" & ("BOLETA DE CREDITO") & "', '" & (rut_cliente) & "','" & (cod_cliente) & "','" & (fecha_doc) & "'," & (descuento_doc) & "," & (neto_doc) & "," & (iva_doc) & "," & (subtotal_doc) & "," & (total_doc) & ",'" & (condicion_doc) & "','" & ("EMITIDA") & "','" & (rut_vendedor) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (porcentaje_desc_doc) & "', '" & (tipo_impresion) & "', '" & (pie) & "', '" & (forma_de_pago_pie) & "'," & (total_doc) & ")"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into creditos (n_creditos, TIPO, tipo_detalle, rut_cliente,  codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, saldo, condiciones, estado, usuario_responsable, codigo_afecta, nombre_afecta, recinto, fecha_vencimiento, fecha_pago, numero_cuota, total_cuotas, pie, convenio) values (" & (txt_factura.Text) & " , '" & ("BOLETA") & "','" & ("BOLETA") & "', '" & (rut_cliente) & "', '" & (cod_cliente) & "','" & (fecha_doc) & "'," & (descuento_doc) & "," & (neto_doc) & "," & (iva_doc) & "," & (subtotal_doc) & "," & (total_doc) & ", " & (total_doc) & ",'" & (condicion_doc) & "','" & ("EMITIDA") & "','" & (miusuario) & "'," & (txt_factura.Text) & " ,'BOLETA','" & (mirecintoempresa) & "', '" & (dtp_vencimiento.Text) & "', '0000-00-00', '1', '1','" & (pie) & "','" & (convenio) & "')"

            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "update clientes set saldo_cliente = saldo_cliente - " & (Int(total_doc)) & " where rut_cliente = '" & (rut_cliente) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        If tipo_doc = "FACTURA" Then
            If estado_factura_electronica = "SI" Then
                tipo_impresion = "ELECTRONICA"
            Else
                tipo_impresion = "MANUAL"
            End If

            SC.Connection = conexion
            SC.CommandText = "insert into factura(caja, n_factura, tipo, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable, rut_retira, nombre_retira, recinto, hora, porcentaje_desc, orden, tipo_impresion, pie, condicion_de_pago_pie, comision)values('" & (nombre_pc) & "', " & (txt_factura.Text) & ",'" & ("FACTURA") & "','" & (rut_cliente) & "','" & (cod_cliente) & "','" & (fecha_doc) & "'," & (descuento_doc) & "," & (neto_doc) & "," & (iva_doc) & "," & (subtotal_doc) & "," & (total_doc) & ",'" & (condicion_doc) & "','" & ("EMITIDA") & "','" & (miusuario) & "','" & (rut_retira) & "','" & (nombre_retira) & "','" & (mirecintoempresa) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (porcentaje_desc_doc) & "', '0', '" & (tipo_impresion) & "', '" & (pie) & "', '" & (forma_de_pago_pie) & "'," & (total_doc) & ")"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If
    End Sub




    Sub grabar_detalle_factura()


        Dim nro_vale As String
        Dim tipo_doc As String
        Dim condicion_doc As String
        Dim fecha_doc As String
        Dim cod_cliente As String
        Dim rut_cliente As String
        Dim nombre_cliente As String
        Dim direccion_cliente As String
        Dim comuna_cliente As String
        Dim ciudad_cliente As String
        Dim telefono_cliente As String
        Dim folio_cliente As String
        Dim giro_cliente As String
        Dim correo_cliente As String
        Dim subtotal_doc As String
        Dim porcentaje_desc_doc As String
        Dim descuento_doc As String
        Dim neto_doc As String
        Dim iva_doc As String
        Dim total_doc As String
        Dim rut_vendedor As String
        Dim nombre_vendedor As String
        Dim rut_retira As String
        Dim nombre_retira As String
        ' Dim orden_de_compra As String
        Dim convenio As String
        Dim pie As String
        Dim forma_de_pago_pie As String



        nro_vale = grilla_documento.CurrentRow.Cells(0).Value
        tipo_doc = grilla_documento.CurrentRow.Cells(1).Value
        condicion_doc = grilla_documento.CurrentRow.Cells(2).Value
        fecha_doc = grilla_documento.CurrentRow.Cells(3).Value
        cod_cliente = grilla_documento.CurrentRow.Cells(4).Value
        rut_cliente = grilla_documento.CurrentRow.Cells(5).Value
        nombre_cliente = grilla_documento.CurrentRow.Cells(6).Value
        direccion_cliente = grilla_documento.CurrentRow.Cells(7).Value
        comuna_cliente = grilla_documento.CurrentRow.Cells(8).Value
        ciudad_cliente = grilla_documento.CurrentRow.Cells(9).Value
        telefono_cliente = grilla_documento.CurrentRow.Cells(10).Value
        folio_cliente = grilla_documento.CurrentRow.Cells(11).Value
        giro_cliente = grilla_documento.CurrentRow.Cells(12).Value
        correo_cliente = grilla_documento.CurrentRow.Cells(13).Value
        subtotal_doc = grilla_documento.CurrentRow.Cells(14).Value
        porcentaje_desc_doc = grilla_documento.CurrentRow.Cells(15).Value
        descuento_doc = grilla_documento.CurrentRow.Cells(16).Value
        neto_doc = grilla_documento.CurrentRow.Cells(17).Value
        iva_doc = grilla_documento.CurrentRow.Cells(18).Value
        total_doc = grilla_documento.CurrentRow.Cells(19).Value
        rut_vendedor = grilla_documento.CurrentRow.Cells(20).Value
        nombre_vendedor = grilla_documento.CurrentRow.Cells(21).Value
        rut_retira = grilla_documento.CurrentRow.Cells(22).Value
        nombre_retira = grilla_documento.CurrentRow.Cells(23).Value
        convenio = grilla_documento.CurrentRow.Cells(27).Value
        pie = Me.grilla_documento.CurrentRow.Cells(26).Value
        forma_de_pago_pie = grilla_documento.CurrentRow.Cells(28).Value

        Dim VarTipoDoc As String = ""


        If tipo_doc = "BOLETA" Then
            VarTipoDoc = "BOLETA"
        End If

        If tipo_doc = "BOLETA DE CREDITO" Then
            VarTipoDoc = "BOLETA"
        End If

        If tipo_doc = "FACTURA" Then
            VarTipoDoc = "FACTURA"
        End If

        If tipo_doc = "FACTURA DE CREDITO" Then
            VarTipoDoc = "FACTURA"
        End If

        If tipo_doc = "GUIA" Then
            VarTipoDoc = "GUIA"
        End If




        If combo_condiciones.Text <> "PAGO COMBINADO" And combo_condiciones.Text <> "LETRA" And combo_condiciones.Text <> "CONVENIO" Then
            SC.Connection = conexion
            SC.CommandText = "insert into detalle_condicion_de_pago (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha, caja) values(" & (txt_factura.Text) & ", '" & (VarTipoDoc) & "', '" & (total_doc) & "', '" & (condicion_doc) & "', 'EMITIDA', '" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (nombre_pc) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If


























        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarPrecioLista As Integer
        Dim VarCantidad As String
        Dim VarPorcentaje As Integer
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarPrecioVenta As Integer
        Dim VarTotal As Integer












        'Dim nro_vale As String
        'Dim tipo_doc As String
        'Dim fecha_doc As String
        'Dim rut_vendedor As String

        'nro_vale = grilla_documento.CurrentRow.Cells(0).Value
        'tipo_doc = grilla_documento.CurrentRow.Cells(1).Value
        'fecha_doc = grilla_documento.CurrentRow.Cells(3).Value     
        'rut_vendedor = grilla_documento.CurrentRow.Cells(20).Value











        Dim mifecha As Date
        mifecha = fecha_doc
        fecha_doc = mifecha.ToString("yyy-MM-dd")


        For i = 0 To grilla_detalle_documento.Rows.Count - 1

            VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
            vartecnico = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
            VarPrecioLista = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
            VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
            VarPrecioVenta = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
            VarPorcentaje = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
            VarDescuento = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
            VarNeto = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString
            VarIva = grilla_detalle_documento.Rows(i).Cells(9).Value.ToString
            VarTotal = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString


            If tipo_doc = "FACTURA" Then
                SC.Connection = conexion
                SC.CommandText = "insert into detalle_factura (n_factura, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarPrecioLista) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarPrecioVenta) & "," & (VarTotal) & ")"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If


            If tipo_doc = "BOLETA DE CREDITO" Then
                SC.Connection = conexion
                SC.CommandText = "insert into detalle_boleta (n_boleta, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarPrecioLista) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarPrecioVenta) & "," & (VarTotal) & ")"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If tipo_doc = "FACTURA DE CREDITO" Then
                SC.Connection = conexion
                SC.CommandText = "insert into detalle_factura (n_factura, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarPrecioLista) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarPrecioVenta) & "," & (VarTotal) & ")"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If


            If tipo_doc = "BOLETA" Then
                SC.Connection = conexion
                SC.CommandText = "insert into detalle_boleta (n_boleta, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarPrecioLista) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarPrecioVenta) & "," & (VarTotal) & ")"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If tipo_doc = "GUIA" Then
                SC.Connection = conexion
                SC.CommandText = "insert into detalle_guia (n_guia, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_factura.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarPrecioLista) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarPrecioVenta) & "," & (VarTotal) & ")"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If


            SC.Connection = conexion
            SC.CommandText = "update productos set cantidad = cantidad - " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into detalle_total (n_total, TIPO, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento,  fecha, vendedor, estado) values(" & (txt_factura.Text) & ",'" & (tipo_doc) & "', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarPrecioLista) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarPrecioVenta) & "," & (VarTotal) & ",'SALE','" & (fecha_doc) & "', '" & (rut_vendedor) & "' ,'EMITIDA')"
            DA.SelectCommand = SC
            DA.Fill(DT)

        Next

        SC.Connection = conexion
        SC.CommandText = "update ticket_venta set estado = 'EMITIDO' where N_TICKET = '" & (nro_vale) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)

    End Sub






















    Sub crear_archivo_plano()
        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim ContenidoArchivo As String = Nothing
        ' Donde guardamos los paths de los archivos que vamos a estar utilizando...
        Dim PathArchivo As String
        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarPrecioLista As Integer
        Dim VarCantidad As String
        Dim VarPorcentaje As Integer
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarPrecioVenta As Integer
        Dim VarTotal As Integer
        Dim nro_vale As String
        Dim tipo_doc As String
        Dim condicion_doc As String
        Dim fecha_doc As String
        Dim cod_cliente As String
        Dim rut_cliente As String
        Dim nombre_cliente As String
        Dim direccion_cliente As String
        Dim comuna_cliente As String
        Dim ciudad_cliente As String
        Dim telefono_cliente As String
        Dim folio_cliente As String
        Dim giro_cliente As String
        Dim correo_cliente As String
        Dim subtotal_doc As String
        Dim porcentaje_desc_doc As String
        Dim descuento_doc As String
        Dim neto_doc As String
        Dim iva_doc As String
        Dim total_doc As String
        Dim rut_vendedor As String
        Dim nombre_vendedor As String
        Dim rut_retira As String
        Dim nombre_retira As String
        'Dim orden_de_compra As String
        Dim nro_linea As String
        Dim orden_de_compra_doc As String
        Dim VarValorUnitario As String

        nro_vale = grilla_documento.CurrentRow.Cells(0).Value
        tipo_doc = grilla_documento.CurrentRow.Cells(1).Value
        condicion_doc = grilla_documento.CurrentRow.Cells(2).Value
        fecha_doc = grilla_documento.CurrentRow.Cells(3).Value
        cod_cliente = grilla_documento.CurrentRow.Cells(4).Value
        rut_cliente = grilla_documento.CurrentRow.Cells(5).Value
        nombre_cliente = grilla_documento.CurrentRow.Cells(6).Value
        direccion_cliente = grilla_documento.CurrentRow.Cells(7).Value
        comuna_cliente = grilla_documento.CurrentRow.Cells(8).Value
        ciudad_cliente = grilla_documento.CurrentRow.Cells(9).Value
        telefono_cliente = grilla_documento.CurrentRow.Cells(10).Value
        folio_cliente = grilla_documento.CurrentRow.Cells(11).Value
        giro_cliente = grilla_documento.CurrentRow.Cells(12).Value
        correo_cliente = grilla_documento.CurrentRow.Cells(13).Value
        subtotal_doc = grilla_documento.CurrentRow.Cells(14).Value
        porcentaje_desc_doc = grilla_documento.CurrentRow.Cells(15).Value
        descuento_doc = grilla_documento.CurrentRow.Cells(16).Value
        neto_doc = grilla_documento.CurrentRow.Cells(17).Value
        iva_doc = grilla_documento.CurrentRow.Cells(18).Value
        total_doc = grilla_documento.CurrentRow.Cells(19).Value
        rut_vendedor = grilla_documento.CurrentRow.Cells(20).Value
        nombre_vendedor = grilla_documento.CurrentRow.Cells(21).Value
        rut_retira = grilla_documento.CurrentRow.Cells(22).Value
        nombre_retira = grilla_documento.CurrentRow.Cells(23).Value
        orden_de_compra_doc = grilla_documento.CurrentRow.Cells(24).Value

        If nombre_cliente.Length > 40 Then
            nombre_cliente = nombre_cliente.Substring(0, 40)
        End If

        If giro_cliente.Length > 40 Then
            giro_cliente = giro_cliente.Substring(0, 40)
        End If

        If direccion_cliente.Length > 59 Then
            direccion_cliente = direccion_cliente.Substring(0, 60)
        End If

        If comuna_cliente.Length > 19 Then
            comuna_cliente = comuna_cliente.Substring(0, 20)
        End If

        If ciudad_cliente.Length > 19 Then
            ciudad_cliente = ciudad_cliente.Substring(0, 20)
        End If

        If correo_cliente.Length > 199 Then
            correo_cliente = correo_cliente.Substring(0, 200)
        End If

        telefono_cliente = Trim(dejarNumerosPuntos(telefono_cliente))

        If telefono_cliente.Length > 8 Then
            telefono_cliente = telefono_cliente.Substring(0, 8)
        End If

        If correo_cliente = "-" Then
            correo_cliente = ""
        End If

        If folio_cliente = "-" Then
            folio_cliente = ""
        End If

        Dim condicion As String

        condicion = combo_condiciones.Text

        If combo_condiciones.Text = "EFECTIVO" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "ABCDIN" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "CENCOSUD" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "C&D" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "PRESTO" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "RYPLEY" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "VISA" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "MASTERCARD" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "BANCARIA" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "REDCOMPRA" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "TRANSFERENCIA" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "CHEQUE AL DIA" Then
            condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "CHEQUE 15 DIAS" Then
            condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "CHEQUE 30 DIAS" Then
            condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "CHEQUE 45 DIAS" Then
            condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "CHEQUE 60 DIAS" Then
            condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "CHEQUE 30-60 DIAS" Then
            condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "CHEQUE 30-60-90 DIAS" Then
            condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "PENDIENTE" Then
            condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "TRANSFERENCIA" Then
            condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        End If
        If combo_condiciones.Text = "CREDITO" Then
            condicion = "CREDITO " & "(" & combo_condiciones.Text & ")"
        End If


        If combo_venta.Text = "BOLETA" Then
            Try

                If Directory.Exists(ruta_archivos_planos) = False Then ' si no existe la carpeta se crea
                    Directory.CreateDirectory(ruta_archivos_planos)
                End If

                'If Directory.Exists("C:\Carpeta Facturacion Electronica") = False Then ' si no existe la carpeta se crea
                ' Directory.CreateDirectory("C:\Carpeta Facturacion Electronica")
                'End If

                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                ' PathArchivo = "C:\carpeta\Archivo" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
                ' PathArchivo = "\\SERVER\Claudio Calderon R\Capeta\Archivo '" & (combo_venta.Text) & "'" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
                ' PathArchivo = "C:\Carpeta Facturacion Electronica\" & (combo_venta.Text) & " " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual
                PathArchivo = ruta_archivos_planos & "\" & "Boleta " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

                'verificamos si existe el archivo

                If File.Exists(PathArchivo) Then
                    strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
                Else
                    strStreamW = File.Create(PathArchivo) ' lo creamos
                End If

                strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

                'escribimos en el archivo
                strStreamWriter.WriteLine("->Boleta<-" & vbNewLine _
                & ("39") & ";" & (txt_factura.Text) & ";" & (Form_menu_principal.dtp_fecha.Text) & ";" & ("3") & ";" & ("0") & ";" & ("") & ";" & ("") & ";" & ("") & ";" & (rut_cliente) & ";" & (cod_cliente) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (comuna_cliente) & ";" & (ciudad_cliente) & ";" & (correo_cliente) & ";" & vbNewLine _
                & "->BoletaTotales<-" & vbNewLine _
                & (neto_doc) & ";" & ("0") & ";" & (iva_doc) & ";" & (total_doc) & ";" & ("0") & ";" & ("0") & ";" & ("0") & ";" & ("0") & ";" & vbNewLine _
                & "->BoletaDetalle<-")

                nro_linea = 0

                For i = 0 To grilla_detalle_documento.Rows.Count - 1
                    nro_linea = nro_linea + 1
                    VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
                    varnombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
                    vartecnico = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
                    VarPrecioLista = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
                    VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
                    VarPrecioVenta = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
                    VarPorcentaje = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
                    VarDescuento = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
                    VarNeto = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString
                    VarIva = grilla_detalle_documento.Rows(i).Cells(9).Value.ToString
                    VarTotal = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString

                    'VarPorcentaje = 0
                    'VarDescuento = 0
                    VarValorUnitario = VarPrecioVenta

                    If VarCodProducto.Length > 34 Then
                        VarCodProducto = VarCodProducto.Substring(0, 35)
                    End If

                    varnombre = varnombre & " " & vartecnico

                    If varnombre.Length > 80 Then
                        varnombre = varnombre.Substring(0, 80)
                    End If

                    varnombre = VarCodProducto & " - " & varnombre & " " & vartecnico

                    If varnombre.Length > 52 Then
                        varnombre = varnombre.Substring(0, 51)
                    End If

                    VarCantidad = Replace(VarCantidad, ",", ".")
                    VarPorcentaje = Replace(VarPorcentaje, ",", ".")

                    strStreamWriter.WriteLine(nro_linea & ";" & (VarCodProducto) & ";" & (varnombre) & ";" & ("0") & ";" & (VarCantidad) & ";" & (VarValorUnitario) & ";" & ("0") & ";" & (VarTotal) & ";" & ("INT11") & ";" & ("UN") & ";" & ("") & ";")
                Next

                If orden_de_compra_doc = "0" Then
                    orden_de_compra_doc = ""
                End If

                strStreamWriter.WriteLine("->BoletaDescRec<-" & vbNewLine _
                & ("1") & ";" & ("D") & ";" & ("Descuento") & ";" & ("$") & ";" & (descuento_doc) & ";" & ("0") & ";" & vbNewLine _
                & "->BoletaReferencia<-" & vbNewLine _
                & ("1") & ";" & ("") & ";" & ("") & ";" & vbNewLine _
                & "->Observacion<-" & vbNewLine _
                & (combo_condiciones.Text) & ", " & nombre_vendedor & ", " & mirecintoempresa & ";")

                strStreamWriter.Close() ' cerramos

            Catch ex As Exception
                MsgBox("ERROR AL GUARDAR LA INFORMACION EN EL ARCHIVO. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
                strStreamWriter.Close() ' cerramos
            End Try
        End If





        If combo_venta.Text = "BOLETA DE CREDITO" Then
            Try
                If Directory.Exists(ruta_archivos_planos) = False Then ' si no existe la carpeta se crea
                    Directory.CreateDirectory(ruta_archivos_planos)
                End If

                'If Directory.Exists("C:\Carpeta Facturacion Electronica") = False Then ' si no existe la carpeta se crea
                ' Directory.CreateDirectory("C:\Carpeta Facturacion Electronica")
                'End If

                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                ' PathArchivo = "C:\carpeta\Archivo" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
                ' PathArchivo = "\\SERVER\Claudio Calderon R\Capeta\Archivo '" & (combo_venta.Text) & "'" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
                ' PathArchivo = "C:\Carpeta Facturacion Electronica\" & (combo_venta.Text) & " " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual
                PathArchivo = ruta_archivos_planos & "\" & "Boleta " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

                'verificamos si existe el archivo

                If File.Exists(PathArchivo) Then
                    strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
                Else
                    strStreamW = File.Create(PathArchivo) ' lo creamos
                End If

                strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

                'escribimos en el archivo
                strStreamWriter.WriteLine("->Boleta<-" & vbNewLine _
                & ("39") & ";" & (txt_factura.Text) & ";" & (Form_menu_principal.dtp_fecha.Text) & ";" & ("3") & ";" & ("0") & ";" & ("") & ";" & ("") & ";" & ("") & ";" & (rut_cliente) & ";" & (cod_cliente) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (comuna_cliente) & ";" & (ciudad_cliente) & ";" & (correo_cliente) & ";" & vbNewLine _
                & "->BoletaTotales<-" & vbNewLine _
                & (neto_doc) & ";" & ("0") & ";" & (iva_doc) & ";" & (total_doc) & ";" & ("0") & ";" & ("0") & ";" & ("0") & ";" & ("0") & ";" & vbNewLine _
                & "->BoletaDetalle<-")

                nro_linea = 0
                For i = 0 To grilla_detalle_documento.Rows.Count - 1
                    nro_linea = nro_linea + 1
                    VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
                    varnombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
                    vartecnico = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
                    VarPrecioLista = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
                    VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
                    VarPrecioVenta = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
                    VarPorcentaje = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
                    VarDescuento = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
                    VarNeto = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString
                    VarIva = grilla_detalle_documento.Rows(i).Cells(9).Value.ToString
                    VarTotal = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString

                    'VarPorcentaje = 0
                    'VarDescuento = 0
                    VarValorUnitario = VarPrecioVenta

                    If VarCodProducto.Length > 34 Then
                        VarCodProducto = VarCodProducto.Substring(0, 35)
                    End If

                    varnombre = varnombre & " " & vartecnico

                    If varnombre.Length > 80 Then
                        varnombre = varnombre.Substring(0, 80)
                    End If

                    varnombre = VarCodProducto & " - " & varnombre & " " & vartecnico

                    If varnombre.Length > 52 Then
                        varnombre = varnombre.Substring(0, 51)
                    End If

                    VarCantidad = Replace(VarCantidad, ",", ".")
                    VarPorcentaje = Replace(VarPorcentaje, ",", ".")

                    strStreamWriter.WriteLine(nro_linea & ";" & (VarCodProducto) & ";" & (varnombre) & ";" & ("0") & ";" & (VarCantidad) & ";" & (VarValorUnitario) & ";" & ("0") & ";" & (VarTotal) & ";" & ("INT11") & ";" & ("UN") & ";" & ("") & ";")
                Next

                If orden_de_compra_doc = "0" Then
                    orden_de_compra_doc = ""
                End If

                strStreamWriter.WriteLine("->BoletaDescRec<-" & vbNewLine _
                & ("1") & ";" & ("D") & ";" & ("Descuento") & ";" & ("$") & ";" & (descuento_doc) & ";" & ("0") & ";" & vbNewLine _
                & "->BoletaReferencia<-" & vbNewLine _
                & ("1") & ";" & ("") & ";" & ("") & ";" & vbNewLine _
                & "->Observacion<-" & vbNewLine _
                & (combo_condiciones.Text) & ", " & nombre_vendedor & ", " & mirecintoempresa & ";")

                strStreamWriter.Close() ' cerramos

            Catch ex As Exception
                MsgBox("ERROR AL GUARDAR LA INFORMACION EN EL ARCHIVO. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
                strStreamWriter.Close() ' cerramos
            End Try
        End If

        If combo_venta.Text = "FACTURA" Then
            Try
                If Directory.Exists(ruta_archivos_planos) = False Then ' si no existe la carpeta se crea
                    Directory.CreateDirectory(ruta_archivos_planos)
                End If

                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                PathArchivo = ruta_archivos_planos & "\" & "Factura " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

                'verificamos si existe el archivo

                If File.Exists(PathArchivo) Then
                    strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
                Else
                    strStreamW = File.Create(PathArchivo) ' lo creamos
                End If

                strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' TIPO de codificacion para escritura

                'escribimos en el archivo
                strStreamWriter.WriteLine("->Encabezado<-" & vbNewLine _
                & "33" & ";" & (txt_factura.Text) & ";" & (Form_menu_principal.dtp_fecha.Text) & ";" & "0" & ";" & "0" & ";" & (rut_cliente) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (ciudad_cliente) & ";" & (comuna_cliente) & ";" & (correo_cliente) & ";" & (condicion) & ";" & (nombre_vendedor) & ";" & (rut_retira) & ";" & (nombre_retira) & ";" & (mirecintoempresa) & ";" & (telefono_cliente) & ";" & vbNewLine _
                & "->Totales<-" & vbNewLine _
                & (0) & ";" & (descuento_doc) & ";" & "0" & ";" & "0" & ";" & (neto_doc) & ";" & "0" & ";" & (valor_iva) & ";" & (iva_doc) & ";" & (total_doc) & ";1;" & vbNewLine _
                & "->Detalle<-")

                nro_linea = 0

                For i = 0 To grilla_detalle_documento.Rows.Count - 1
                    nro_linea = nro_linea + 1
                    VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
                    varnombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
                    vartecnico = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
                    VarPrecioLista = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
                    VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
                    VarPrecioVenta = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
                    VarPorcentaje = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
                    VarDescuento = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
                    VarNeto = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString
                    VarIva = grilla_detalle_documento.Rows(i).Cells(9).Value.ToString
                    VarTotal = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString

                    'VarPorcentaje = 0
                    'VarDescuento = 0
                    VarValorUnitario = VarPrecioVenta

                    If VarCodProducto.Length > 34 Then
                        VarCodProducto = VarCodProducto.Substring(0, 35)
                    End If

                    If varnombre.Length > 79 Then
                        varnombre = varnombre.Substring(0, 80)
                    End If

                    varnombre = varnombre & " " & vartecnico

                    If varnombre.Length > 52 Then
                        varnombre = varnombre.Substring(0, 52)
                    End If

                    VarCantidad = Replace(VarCantidad, ",", ".")
                    VarPorcentaje = Replace(VarPorcentaje, ",", ".")

                    strStreamWriter.WriteLine(nro_linea & ";" & (VarCodProducto) & ";" & (varnombre) & ";" & (VarCantidad) & ";" & (VarValorUnitario) & ";" & (VarPorcentaje) & ";" & (VarDescuento) & ";" & (0) & ";" & (0) & ";" & (0) & ";" & (VarTotal) & ";" & "INT11" & ";" & "UN" & ";" & ";")
                Next

                If orden_de_compra_doc = "0" Then
                    orden_de_compra_doc = ""
                End If

                Dim orden_de_compra_referencia As String = ""

                'If txt_nro_orden_de_compra.Text <> "" Then
                orden_de_compra_referencia = "OC " & orden_de_compra_doc & ", FOLIO :" & folio_cliente & ", " & combo_condiciones.Text & ", " & mirecintoempresa
                ' End If

                strStreamWriter.WriteLine("->Referencia<-" & vbNewLine _
                & "1" & ";" & "801" & ";" & orden_de_compra_doc & ";;" & "0" & ";" & "-" & ";" & vbNewLine _
                & "->DescRec<-" & vbNewLine _
                & "1" & ";" & "D" & ";" & "Descuento" & ";" & "$" & ";" & descuento_doc & ";" & "0" & ";" & vbNewLine _
                & "->Observacion<-" & vbNewLine _
                & folio_cliente & ";" & combo_condiciones.Text & ", " & mirecintoempresa & ";" & orden_de_compra_referencia & ";")
                strStreamWriter.Close() ' cerramos

            Catch ex As Exception
                MsgBox("ERROR AL GUARDAR LA INFORMACION EN EL ARCHIVO. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
                strStreamWriter.Close() ' cerramos
            End Try
        End If

        If combo_venta.Text = "FACTURA DE CREDITO" Then
            Try

                If Directory.Exists(ruta_archivos_planos) = False Then ' si no existe la carpeta se crea
                    Directory.CreateDirectory(ruta_archivos_planos)
                End If

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                PathArchivo = ruta_archivos_planos & "\" & "Factura " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

                If File.Exists(PathArchivo) Then
                    strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
                Else
                    strStreamW = File.Create(PathArchivo) ' lo creamos
                End If

                strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' TIPO de codificacion para escritura

                strStreamWriter.WriteLine("->Encabezado<-" & vbNewLine _
                & "33" & ";" & (txt_factura.Text) & ";" & (Form_menu_principal.dtp_fecha.Text) & ";" & "0" & ";" & "0" & ";" & (rut_cliente) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (ciudad_cliente) & ";" & (comuna_cliente) & ";" & (correo_cliente) & ";" & (condicion) & ";" & (nombre_vendedor) & ";" & (rut_retira) & ";" & (nombre_retira) & ";" & (mirecintoempresa) & ";" & (telefono_cliente) & ";" & vbNewLine _
                & "->Totales<-" & vbNewLine _
                & (0) & ";" & (descuento_doc) & ";" & "0" & ";" & "0" & ";" & (neto_doc) & ";" & "0" & ";" & (valor_iva) & ";" & (iva_doc) & ";" & (total_doc) & ";1;" & vbNewLine _
                & "->Detalle<-")

                nro_linea = 0

                For i = 0 To grilla_detalle_documento.Rows.Count - 1
                    nro_linea = nro_linea + 1
                    VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
                    varnombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
                    vartecnico = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
                    VarPrecioLista = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
                    VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
                    VarPrecioVenta = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
                    VarPorcentaje = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
                    VarDescuento = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
                    VarNeto = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString
                    VarIva = grilla_detalle_documento.Rows(i).Cells(9).Value.ToString
                    VarTotal = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString

                    'VarPorcentaje = 0
                    'VarDescuento = 0
                    VarValorUnitario = VarPrecioVenta

                    If VarCodProducto.Length > 34 Then
                        VarCodProducto = VarCodProducto.Substring(0, 35)
                    End If

                    If varnombre.Length > 79 Then
                        varnombre = varnombre.Substring(0, 80)
                    End If

                    varnombre = varnombre & " " & vartecnico

                    If varnombre.Length > 52 Then
                        varnombre = varnombre.Substring(0, 52)
                    End If

                    VarCantidad = Replace(VarCantidad, ",", ".")
                    VarPorcentaje = Replace(VarPorcentaje, ",", ".")

                    strStreamWriter.WriteLine(nro_linea & ";" & (VarCodProducto) & ";" & (varnombre) & ";" & (VarCantidad) & ";" & (VarValorUnitario) & ";" & (VarPorcentaje) & ";" & (VarDescuento) & ";" & (0) & ";" & (0) & ";" & (0) & ";" & (VarTotal) & ";" & "INT11" & ";" & "UN" & ";" & ";")
                Next

                If orden_de_compra_doc = "0" Then
                    orden_de_compra_doc = ""
                End If

                Dim orden_de_compra_referencia As String = ""

                'If txt_nro_orden_de_compra.Text <> "" Then
                ' orden_de_compra_referencia = "OC " & txt_nro_orden_de_compra.Text
                orden_de_compra_referencia = "OC " & orden_de_compra_doc & ", FOLIO :" & folio_cliente & ", " & combo_condiciones.Text & ", " & mirecintoempresa

                'End If

                strStreamWriter.WriteLine("->Referencia<-" & vbNewLine _
                & "1" & ";" & "801" & ";" & orden_de_compra_doc & ";;" & "0" & ";" & "-" & ";" & vbNewLine _
                & "->DescRec<-" & vbNewLine _
                & "1" & ";" & "D" & ";" & "Descuento" & ";" & "$" & ";" & descuento_doc & ";" & "0" & ";" & vbNewLine _
                & "->Observacion<-" & vbNewLine _
                & orden_de_compra_referencia & ";" & combo_condiciones.Text & ", " & mirecintoempresa & ";" & folio_cliente & ";")
                strStreamWriter.Close() ' cerramos

            Catch ex As Exception
                MsgBox("ERROR AL GUARDAR LA INFORMACION EN EL ARCHIVO. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
                strStreamWriter.Close() ' cerramos
            End Try
        End If


        If combo_venta.Text = "GUIA" Then
            Dim IndTraslado As Integer
            If combo_condiciones.Text = "TRASLADO" Then
                IndTraslado = 0
            Else
                IndTraslado = 1
            End If

            Try
                If Directory.Exists(ruta_archivos_planos) = False Then ' si no existe la carpeta se crea
                    Directory.CreateDirectory(ruta_archivos_planos)
                End If

                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                PathArchivo = ruta_archivos_planos & "\" & "Guia " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

                'verificamos si existe el archivo

                If File.Exists(PathArchivo) Then
                    strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
                Else
                    strStreamW = File.Create(PathArchivo) ' lo creamos
                End If

                strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' TIPO de codificacion para escritura

                'escribimos en el archivo
                strStreamWriter.WriteLine("->Encabezado<-" & vbNewLine _
                & "52" & ";" & (txt_factura.Text) & ";" & (Form_menu_principal.dtp_fecha.Text) & ";" & (tipo_despacho) & ";" & (IndTraslado) & ";" & (rut_cliente) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (ciudad_cliente) & ";" & (comuna_cliente) & ";" & (correo_cliente) & ";" & (condicion) & ";" & (nombre_vendedor) & ";" & (rut_retira) & ";" & (nombre_retira) & ";" & (mirecintoempresa) & ";" & (telefono_cliente) & ";" & vbNewLine _
                & "->Totales<-" & vbNewLine _
                & (0) & ";" & (descuento_doc) & ";" & "0" & ";" & "0" & ";" & (neto_doc) & ";" & "0" & ";" & (valor_iva) & ";" & (iva_doc) & ";" & (total_doc) & ";1;" & vbNewLine _
                & "->Detalle<-")

                nro_linea = 0

                For i = 0 To grilla_detalle_documento.Rows.Count - 1
                    nro_linea = nro_linea + 1
                    VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
                    varnombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
                    vartecnico = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
                    VarPrecioLista = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
                    VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
                    VarPrecioVenta = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
                    VarPorcentaje = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
                    VarDescuento = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
                    VarNeto = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString
                    VarIva = grilla_detalle_documento.Rows(i).Cells(9).Value.ToString
                    VarTotal = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString

                    'VarPorcentaje = 0
                    'VarDescuento = 0
                    VarValorUnitario = VarPrecioVenta

                    If VarCodProducto.Length > 34 Then
                        VarCodProducto = VarCodProducto.Substring(0, 35)
                    End If

                    If varnombre.Length > 79 Then
                        varnombre = varnombre.Substring(0, 80)
                    End If

                    varnombre = varnombre & " " & vartecnico

                    If varnombre.Length > 52 Then
                        varnombre = varnombre.Substring(0, 52)
                    End If

                    VarCantidad = Replace(VarCantidad, ",", ".")
                    VarPorcentaje = Replace(VarPorcentaje, ",", ".")

                    strStreamWriter.WriteLine(nro_linea & ";" & (VarCodProducto) & ";" & (varnombre) & ";" & (VarCantidad) & ";" & (VarValorUnitario) & ";" & (VarPorcentaje) & ";" & (VarDescuento) & ";" & (0) & ";" & (0) & ";" & (0) & ";" & (VarTotal) & ";" & "INT11" & ";" & "UN" & ";" & ";")
                Next

                If orden_de_compra_doc = "0" Then
                    orden_de_compra_doc = ""
                End If

                Dim orden_de_compra_referencia As String = ""

                'If txt_nro_orden_de_compra.Text <> "" Then
                'orden_de_compra_referencia = "OC " & txt_nro_orden_de_compra.Text
                orden_de_compra_referencia = "OC " & orden_de_compra_doc & ", FOLIO :" & folio_cliente & ", " & combo_condiciones.Text & ", " & mirecintoempresa

                ' End If

                strStreamWriter.WriteLine("->Referencia<-" & vbNewLine _
                & "1" & ";" & "801" & ";" & orden_de_compra_doc & ";;" & "0" & ";" & "-" & ";" & vbNewLine _
                & "->DescRec<-" & vbNewLine _
                & "1" & ";" & "D" & ";" & "Descuento" & ";" & "$" & ";" & descuento_doc & ";" & "0" & ";" & vbNewLine _
                & "->Observacion<-" & vbNewLine _
                & orden_de_compra_referencia & ";" & combo_condiciones.Text & ", " & mirecintoempresa & ";" & folio_cliente & ";")
                strStreamWriter.Close() ' cerramos

            Catch ex As Exception
                MsgBox("ERROR AL GUARDAR LA INFORMACION EN EL ARCHIVO. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
                strStreamWriter.Close() ' cerramos
            End Try
        End If
    End Sub




    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage

        'Dim nro_vale As String
        'Dim tipo_doc As String
        'Dim condicion_doc As String
        'Dim fecha_doc As String
        'Dim cod_cliente As String
        'Dim rut_cliente As String
        'Dim nombre_cliente As String
        'Dim direccion_cliente As String
        'Dim comuna_cliente As String
        'Dim ciudad_cliente As String
        'Dim telefono_cliente As String
        'Dim folio_cliente As String
        'Dim giro_cliente As String
        'Dim correo_cliente As String
        'Dim subtotal_doc As String
        'Dim porcentaje_desc_doc As String
        'Dim descuento_doc As String
        'Dim neto_doc As String
        'Dim iva_doc As String
        'Dim total_doc As String
        'Dim rut_vendedor As String
        'Dim nombre_vendedor As String
        'Dim rut_retira As String
        'Dim nombre_retira As String
        'Dim orden_de_compra As String

        'Dim VarCodProducto As String
        'Dim varnombre As String
        'Dim vartecnico As String
        'Dim VarPrecioLista As Integer
        'Dim VarCantidad As String
        'Dim VarPorcentaje As Integer
        'Dim VarDescuento As Integer
        'Dim VarNeto As Integer
        'Dim VarIva As Integer
        'Dim VarPrecioVenta As Integer
        'Dim VarTotal As Integer
        'Dim pie As String

        'nro_vale = grilla_documento.CurrentRow.Cells(0).Value
        'tipo_doc = grilla_documento.CurrentRow.Cells(1).Value
        'condicion_doc = grilla_documento.CurrentRow.Cells(2).Value
        'fecha_doc = grilla_documento.CurrentRow.Cells(3).Value
        'cod_cliente = grilla_documento.CurrentRow.Cells(4).Value
        'rut_cliente = grilla_documento.CurrentRow.Cells(5).Value
        'nombre_cliente = grilla_documento.CurrentRow.Cells(6).Value
        'direccion_cliente = grilla_documento.CurrentRow.Cells(7).Value
        'comuna_cliente = grilla_documento.CurrentRow.Cells(8).Value
        'ciudad_cliente = grilla_documento.CurrentRow.Cells(9).Value
        'telefono_cliente = grilla_documento.CurrentRow.Cells(10).Value
        'folio_cliente = grilla_documento.CurrentRow.Cells(11).Value
        'giro_cliente = grilla_documento.CurrentRow.Cells(12).Value
        'correo_cliente = grilla_documento.CurrentRow.Cells(13).Value
        'subtotal_doc = grilla_documento.CurrentRow.Cells(14).Value
        'porcentaje_desc_doc = grilla_documento.CurrentRow.Cells(15).Value
        'descuento_doc = grilla_documento.CurrentRow.Cells(16).Value
        'neto_doc = grilla_documento.CurrentRow.Cells(17).Value
        'iva_doc = grilla_documento.CurrentRow.Cells(18).Value
        'total_doc = grilla_documento.CurrentRow.Cells(19).Value
        'rut_vendedor = grilla_documento.CurrentRow.Cells(20).Value
        'nombre_vendedor = grilla_documento.CurrentRow.Cells(21).Value
        'rut_retira = grilla_documento.CurrentRow.Cells(22).Value
        'nombre_retira = grilla_documento.CurrentRow.Cells(23).Value


        'pie = grilla_documento.CurrentRow.Cells(26).Value






        'If grilla_documento.CurrentRow.Cells(25).Value.ToString = "" Then
        '    orden_de_compra = 0
        'Else
        '    orden_de_compra = grilla_documento.CurrentRow.Cells(25).Value
        'End If


















        ''crear_numero_factura()



        'Dim cantidad_detalle As String
        'Dim valorUnitario_detalle As String
        'Dim subtotal_detalle As String
        'Dim total_detalle As String

        ''Dim Font11 As New Font("Lucida Console", 11, FontStyle.Regular)
        ''Dim Font10 As New Font("Lucida Console", 10, FontStyle.Regular)
        ''Dim Font9 As New Font("Lucida Console", 9, FontStyle.Regular)
        ''Dim Font8 As New Font("Lucida Console", 8, FontStyle.Regular)

        'Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
        'Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
        'Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
        'Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)



        'Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        'format1.Alignment = StringAlignment.Far

        '' sdfgv()
        'If impresion_de_documento = "LETRA" Then





        '    Dim mifecha As Date
        '    mifecha = fecha_doc
        '    fecha_doc = mifecha.ToString("yyy-MM-dd")

        '    peso = " PESOS"
        '    If CInt(varTotalCuota) = 1000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & " DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 2000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 3000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 4000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 5000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 6000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 7000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 8000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 9000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 10000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 11000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 12000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 13000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 14000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 15000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 16000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 17000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 18000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 19000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 20000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 21000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 22000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 23000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 24000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 25000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 26000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 27000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 28000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 29000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    ElseIf CInt(varTotalCuota) = 30000000 Then
        '        desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        '    Else
        '        desglose_letra = Num2Text(varTotalCuota) & peso
        '    End If

        '    Dim mifecha_letra As Date
        '    mifecha_letra = varFechaCuota
        '    varFechaCuota = mifecha_letra.ToString("yyy-MM-dd")
        '    'FGH()
        '    e.Graphics.DrawString(txt_nro_letra.Text, Font10, Brushes.Black, 400, 0)
        '    e.Graphics.DrawString(cantidad_letras & " DE " & grilla_cuotas.Rows.Count, Font10, Brushes.Black, 590, 0)
        '    e.Graphics.DrawString(varFechaCuota, Font10, Brushes.Black, 700, 10)


        '    e.Graphics.DrawString(varTotalCuota, Font10, Brushes.Black, 700, 45)
        '    e.Graphics.DrawString(Format(form_Menu_admin.dtp_fecha.Text, "Long Date"), Font10, Brushes.Black, 310, 30)


        '    e.Graphics.DrawString(Format(varFechaCuota, "Long Date"), Font10, Brushes.Black, 255, 60)


        '    e.Graphics.DrawString(desglose_letra, Font10, Brushes.Black, 343, 160)


        '    e.Graphics.DrawString(txt_factura.Text, Font10, Brushes.Black, 130, 260)

        '    e.Graphics.DrawString(rut_cliente, Font10, Brushes.Black, 50, 288)
        '    e.Graphics.DrawString(nombre_cliente, Font10, Brushes.Black, 250, 288)

        '    e.Graphics.DrawString(direccion_cliente, Font10, Brushes.Black, 80, 317)
        '    e.Graphics.DrawString(ciudad_cliente, Font10, Brushes.Black, 480, 317)

        'End If


        'If impresion_de_documento = "DOCUMENTO" Then


        '    If tipo_doc = "BOLETA" Then

        '        If mirutempresa <> "81921000-4" Then

        '            e.Graphics.DrawString(fecha_doc & " " & mirecintoempresa, Font10, Brushes.Black, 85, 5)
        '            e.Graphics.DrawString(condicion_doc, Font10, Brushes.Black, 590, 5)

        '            For i = 0 To grilla_detalle_documento.Rows.Count - 1
        '                VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
        '                varnombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
        '                vartecnico = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
        '                VarPrecioLista = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
        '                VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
        '                VarPrecioVenta = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
        '                VarPorcentaje = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
        '                VarDescuento = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
        '                VarNeto = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString
        '                VarIva = grilla_detalle_documento.Rows(i).Cells(9).Value.ToString
        '                VarTotal = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString

        '                cantidad_detalle = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
        '                valorUnitario_detalle = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
        '                subtotal_detalle = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
        '                total_detalle = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString

        '                '   cantidad_detalle = Format(Int(cantidad_detalle), "###,###,###")
        '                valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
        '                subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
        '                total_detalle = Format(Int(total_detalle), "###,###,###")

        '                Dim descripcion_caracteres As String
        '                descripcion_caracteres = varnombre & "        " & vartecnico
        '                If descripcion_caracteres.Length > 55 Then
        '                    descripcion_caracteres = descripcion_caracteres.Substring(0, 55)
        '                End If




        '                e.Graphics.DrawString(VarCodProducto, Font9, Brushes.Black, 50, 60 + (i * 15))
        '                e.Graphics.DrawString(descripcion_caracteres, Font9, Brushes.Black, 120, 60 + (i * 15))
        '                e.Graphics.DrawString(cantidad_detalle, Font9, Brushes.Black, 565, 60 + (i * 15), format1)
        '                e.Graphics.DrawString(valorUnitario_detalle, Font9, Brushes.Black, 645, 60 + (i * 15), format1)
        '                e.Graphics.DrawString(total_detalle, Font9, Brushes.Black, 725, 60 + (i * 15), format1)
        '            Next

        '            Dim descuento_millar As String
        '            Dim neto_millar As String
        '            Dim iva_millar As String
        '            Dim total_millar As String
        '            Dim subtotal_millar As String

        '            descuento_millar = descuento_doc
        '            neto_millar = neto_doc
        '            iva_millar = iva_doc
        '            subtotal_millar = subtotal_doc
        '            total_millar = total_doc

        '            descuento_millar = Format(Int(descuento_millar), "###,###,###")
        '            neto_millar = Format(Int(neto_millar), "###,###,###")
        '            iva_millar = Format(Int(iva_millar), "###,###,###")
        '            subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
        '            total_millar = Format(Int(total_millar), "###,###,###")

        '            If nombre_vendedor.Length > 12 Then
        '                nombre_vendedor = nombre_vendedor.Substring(0, 12)
        '            End If


        '            e.Graphics.DrawString(txt_factura.Text, Font10, Brushes.Black, 60, 270)
        '            e.Graphics.DrawString(nombre_vendedor, Font10, Brushes.Black, 215, 270)
        '            e.Graphics.DrawString(subtotal_millar, Font10, Brushes.Black, 385, 270)
        '            e.Graphics.DrawString(descuento_millar, Font10, Brushes.Black, 515, 270)
        '            e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 630, 270)

        '            'Pd = New Printing.PrintDocument
        '            'Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 100, 200)
        '            'Pd.PrinterSettings.DefaultPageSettings.PaperSize = pkCustomSize1



        '        End If




        '        If mirutempresa = "81921000-4" Then

        '            Dim altura_impresion As Integer
        '            altura_impresion = 0

        '            e.Graphics.DrawString(txt_factura.Text & "                   " & fecha_doc, Font10, Brushes.Black, 540, altura_impresion + 0)



        '            'If condicion_doc = "LETRA" Then
        '            If nombre_cliente <> "SIN NOMBRE" And nombre_cliente <> "" Then
        '                e.Graphics.DrawString(nombre_cliente, Font10, Brushes.Black, 70, altura_impresion + 40)
        '                e.Graphics.DrawString(direccion_cliente, Font10, Brushes.Black, 70, altura_impresion + 60)


        '                e.Graphics.DrawString(rut_cliente, Font10, Brushes.Black, 590, altura_impresion + 40)
        '                e.Graphics.DrawString(comuna_cliente, Font10, Brushes.Black, 590, altura_impresion + 60)
        '                e.Graphics.DrawString(telefono_cliente, Font10, Brushes.Black, 590, altura_impresion + 80)
        '            End If
        '            'ElseIf condicion_doc = "CONVENIO" Then

        '            '    e.Graphics.DrawString(nombre_cliente, Font10, Brushes.Black, 70, altura_impresion + 40)
        '            '    e.Graphics.DrawString(direccion_cliente, Font10, Brushes.Black, 70, altura_impresion + 60)


        '            '    e.Graphics.DrawString(rut_cliente, Font10, Brushes.Black, 590, altura_impresion + 40)
        '            '    e.Graphics.DrawString(comuna_cliente, Font10, Brushes.Black, 590, altura_impresion + 60)
        '            '    e.Graphics.DrawString(telefono_cliente, Font10, Brushes.Black, 590, altura_impresion + 80)
        '            'Else

        '            '    e.Graphics.DrawString("VENTA SIN RUT", Font10, Brushes.Black, 70, altura_impresion + 40)
        '            'End If
        '            ' e.Graphics.DrawString(giro_cliente, Font10, Brushes.Black, 85, 55)



        '            ' e.Graphics.DrawString(condicion_doc, Font10, Brushes.Black, 665, 55)



        '            'e.Graphics.DrawString(fecha_doc & " " & mirecintoempresa, Font10, Brushes.Black, 85, 5)
        '            '  e.Graphics.DrawString(condicion_doc, Font10, Brushes.Black, 590, 5)

        '            For i = 0 To grilla_detalle_documento.Rows.Count - 1
        '                VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
        '                varnombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
        '                vartecnico = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
        '                VarPrecioLista = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
        '                VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
        '                VarPrecioVenta = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
        '                VarPorcentaje = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
        '                VarDescuento = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
        '                VarNeto = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString
        '                VarIva = grilla_detalle_documento.Rows(i).Cells(9).Value.ToString
        '                VarTotal = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString

        '                cantidad_detalle = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
        '                valorUnitario_detalle = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
        '                subtotal_detalle = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
        '                total_detalle = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString

        '                '   cantidad_detalle = Format(Int(cantidad_detalle), "###,###,###")
        '                valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
        '                subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
        '                total_detalle = Format(Int(total_detalle), "###,###,###")

        '                Dim descripcion_caracteres As String
        '                descripcion_caracteres = varnombre & "        " & vartecnico
        '                If descripcion_caracteres.Length > 55 Then
        '                    descripcion_caracteres = descripcion_caracteres.Substring(0, 55)
        '                End If




        '                e.Graphics.DrawString(VarCodProducto, Font9, Brushes.Black, 0, altura_impresion + 130 + (i * 15))
        '                e.Graphics.DrawString(descripcion_caracteres, Font9, Brushes.Black, 120, altura_impresion + 130 + (i * 15))
        '                e.Graphics.DrawString(cantidad_detalle, Font9, Brushes.Black, 605, altura_impresion + 130 + (i * 15), format1)
        '                e.Graphics.DrawString(valorUnitario_detalle, Font9, Brushes.Black, 695, altura_impresion + 130 + (i * 15), format1)
        '                e.Graphics.DrawString(total_detalle, Font9, Brushes.Black, 770, altura_impresion + 130 + (i * 15), format1)
        '            Next

        '            Dim descuento_millar As String
        '            Dim neto_millar As String
        '            Dim iva_millar As String
        '            Dim total_millar As String
        '            Dim subtotal_millar As String

        '            descuento_millar = descuento_doc
        '            neto_millar = neto_doc
        '            iva_millar = iva_doc
        '            subtotal_millar = subtotal_doc
        '            total_millar = total_doc

        '            descuento_millar = Format(Int(descuento_millar), "###,###,###")
        '            neto_millar = Format(Int(neto_millar), "###,###,###")
        '            iva_millar = Format(Int(iva_millar), "###,###,###")
        '            subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
        '            total_millar = Format(Int(total_millar), "###,###,###")

        '            If nombre_vendedor.Length > 12 Then
        '                nombre_vendedor = nombre_vendedor.Substring(0, 12)
        '            End If


        '            e.Graphics.DrawString("FORMA DE PAGO:", Font10, Brushes.Black, 10, altura_impresion + 400)

        '            If condicion_doc = "LETRA" Then
        '                Dim dia_de_pago As String
        '                Dim dia_de_pago2 As String
        '                Dim dia_de_pago3 As String
        '                dia_de_pago = grilla_cuotas.CurrentRow.Cells(1).Value
        '                dia_de_pago3 = dia_de_pago(dia_de_pago.Length - 1).ToString()
        '                dia_de_pago2 = dia_de_pago(dia_de_pago.Length - 2).ToString()

        '                dia_de_pago = dia_de_pago2 & dia_de_pago3

        '                e.Graphics.DrawString(Val(grilla_cuotas.Rows.Count) & " LETRAS ACEPTADAS", Font10, Brushes.Black, 140, altura_impresion + 400)
        '                e.Graphics.DrawString("CON FECHAS DE PAGO PARA", Font10, Brushes.Black, 140, altura_impresion + 415)
        '                e.Graphics.DrawString("LOS DIAS " & (dia_de_pago) & " DE CADA MES", Font10, Brushes.Black, 140, altura_impresion + 430)
        '            ElseIf condicion_doc = "LETRA" Then
        '                Dim dia_de_pago As String
        '                Dim dia_de_pago2 As String
        '                Dim dia_de_pago3 As String
        '                dia_de_pago = grilla_cuotas.CurrentRow.Cells(1).Value
        '                dia_de_pago3 = dia_de_pago(dia_de_pago.Length - 1).ToString()
        '                dia_de_pago2 = dia_de_pago(dia_de_pago.Length - 2).ToString()

        '                dia_de_pago = dia_de_pago2 & dia_de_pago3

        '                e.Graphics.DrawString(Val(grilla_cuotas.Rows.Count) & " LETRAS ACEPTADAS", Font10, Brushes.Black, 140, altura_impresion + 400)
        '                e.Graphics.DrawString("CON FECHAS DE PAGO PARA", Font10, Brushes.Black, 140, altura_impresion + 415)
        '                e.Graphics.DrawString("LOS DIAS " & (dia_de_pago) & " DE CADA MES", Font10, Brushes.Black, 140, altura_impresion + 430)
        '            Else
        '                e.Graphics.DrawString(condicion_doc, Font10, Brushes.Black, 140, altura_impresion + 400)
        '            End If

        '            e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 770, altura_impresion + 360, format1)

        '            If condicion_doc = "LETRA" Then
        '                Dim pie_millar As String
        '                Dim saldo_millar As String
        '                ' Dim pie As String

        '                ' pie = Me.grilla_cuotas.CurrentRow.Cells(6).Value

        '                pie_millar = Format(Int(pie), "###,###,###")
        '                saldo_millar = Format(Int(total_doc - pie), "###,###,###")

        '                e.Graphics.DrawString(pie_millar, Font10, Brushes.Black, 770, altura_impresion + 375, format1)
        '                e.Graphics.DrawString(saldo_millar, Font10, Brushes.Black, 770, altura_impresion + 390, format1)

        '                e.Graphics.DrawString("PIE", Font10, Brushes.Black, 650, altura_impresion + 375)
        '                e.Graphics.DrawString("SALDO", Font10, Brushes.Black, 650, altura_impresion + 390)
        '            End If


        '            If condicion_doc = "CONVENIO" Then
        '                Dim pie_millar As String
        '                Dim saldo_millar As String
        '                ' Dim pie As String

        '                ' pie = Me.grilla_cuotas.CurrentRow.Cells(6).Value

        '                pie_millar = Format(Int(pie), "###,###,###")
        '                saldo_millar = Format(Int(total_doc - pie), "###,###,###")

        '                e.Graphics.DrawString(pie_millar, Font10, Brushes.Black, 770, altura_impresion + 375, format1)
        '                e.Graphics.DrawString(saldo_millar, Font10, Brushes.Black, 770, altura_impresion + 390, format1)

        '                e.Graphics.DrawString("PIE", Font10, Brushes.Black, 650, altura_impresion + 375)
        '                e.Graphics.DrawString("SALDO", Font10, Brushes.Black, 650, altura_impresion + 390)
        '            End If
        '            'e.Graphics.DrawString(nombre_vendedor, Font10, Brushes.Black, 215, 400)
        '            'e.Graphics.DrawString(subtotal_millar, Font10, Brushes.Black, 385, 400)
        '            ' e.Graphics.DrawString(descuento_millar, Font10, Brushes.Black, 515, 400)
        '            '  e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 760, 380, format1)

        '            'Pd = New Printing.PrintDocument
        '            'Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 100, 200)
        '            'Pd.PrinterSettings.DefaultPageSettings.PaperSize = pkCustomSize1



        '        End If


        '    End If





        '    If tipo_doc = "BOLETA DE CREDITO" Then
        '        e.Graphics.DrawString(fecha_doc & " " & mirecintoempresa, Font10, Brushes.Black, 85, 5)
        '        e.Graphics.DrawString(condicion_doc, Font10, Brushes.Black, 590, 5)

        '        For i = 0 To grilla_detalle_documento.Rows.Count - 1
        '            VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
        '            varnombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
        '            vartecnico = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
        '            VarPrecioLista = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
        '            VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
        '            VarPrecioVenta = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
        '            VarPorcentaje = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
        '            VarDescuento = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
        '            VarNeto = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString
        '            VarIva = grilla_detalle_documento.Rows(i).Cells(9).Value.ToString
        '            VarTotal = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString

        '            cantidad_detalle = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
        '            valorUnitario_detalle = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
        '            subtotal_detalle = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
        '            total_detalle = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString

        '            '   cantidad_detalle = Format(Int(cantidad_detalle), "###,###,###")
        '            valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
        '            subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
        '            total_detalle = Format(Int(total_detalle), "###,###,###")

        '            Dim descripcion_caracteres As String
        '            descripcion_caracteres = varnombre & "        " & vartecnico
        '            If descripcion_caracteres.Length > 55 Then
        '                descripcion_caracteres = descripcion_caracteres.Substring(0, 55)
        '            End If




        '            e.Graphics.DrawString(VarCodProducto, Font9, Brushes.Black, 50, 60 + (i * 15))
        '            e.Graphics.DrawString(descripcion_caracteres, Font9, Brushes.Black, 120, 60 + (i * 15))
        '            e.Graphics.DrawString(cantidad_detalle, Font9, Brushes.Black, 565, 60 + (i * 15), format1)
        '            e.Graphics.DrawString(valorUnitario_detalle, Font9, Brushes.Black, 645, 60 + (i * 15), format1)
        '            e.Graphics.DrawString(total_detalle, Font9, Brushes.Black, 725, 60 + (i * 15), format1)
        '        Next

        '        Dim descuento_millar As String
        '        Dim neto_millar As String
        '        Dim iva_millar As String
        '        Dim total_millar As String
        '        Dim subtotal_millar As String

        '        descuento_millar = descuento_doc
        '        neto_millar = neto_doc
        '        iva_millar = iva_doc
        '        subtotal_millar = subtotal_doc
        '        total_millar = total_doc

        '        descuento_millar = Format(Int(descuento_millar), "###,###,###")
        '        neto_millar = Format(Int(neto_millar), "###,###,###")
        '        iva_millar = Format(Int(iva_millar), "###,###,###")
        '        subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
        '        total_millar = Format(Int(total_millar), "###,###,###")


        '        If nombre_vendedor.Length > 12 Then
        '            nombre_vendedor = nombre_vendedor.Substring(0, 12)
        '        End If



        '        e.Graphics.DrawString(nombre_cliente, Font10, Brushes.Black, 60, 190)
        '        e.Graphics.DrawString(rut_cliente, Font10, Brushes.Black, 60, 205)
        '        e.Graphics.DrawString(direccion_cliente, Font10, Brushes.Black, 60, 220)
        '        e.Graphics.DrawString(comuna_cliente, Font10, Brushes.Black, 60, 235)




        '        e.Graphics.DrawString(txt_factura.Text, Font10, Brushes.Black, 60, 270)
        '        e.Graphics.DrawString(nombre_vendedor, Font10, Brushes.Black, 215, 270)
        '        e.Graphics.DrawString(subtotal_millar, Font10, Brushes.Black, 385, 270)
        '        e.Graphics.DrawString(descuento_millar, Font10, Brushes.Black, 515, 270)
        '        e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 630, 270)




        '        'Pd = New Printing.PrintDocument
        '        'Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 100, 200)
        '        'Pd.PrinterSettings.DefaultPageSettings.PaperSize = pkCustomSize1
        '    End If




        '    If tipo_doc = "FACTURA" Then
        '        e.Graphics.DrawString(txt_factura.Text, Font10, Brushes.Black, 550, 10, format1)
        '        e.Graphics.DrawString(fecha_doc & " " & mirecintoempresa, Font10, Brushes.Black, 85, 10)
        '        e.Graphics.DrawString(nombre_cliente, Font10, Brushes.Black, 85, 25)
        '        e.Graphics.DrawString(direccion_cliente, Font10, Brushes.Black, 85, 40)
        '        e.Graphics.DrawString(giro_cliente, Font10, Brushes.Black, 85, 55)

        '        e.Graphics.DrawString(rut_cliente, Font10, Brushes.Black, 665, 10)
        '        e.Graphics.DrawString(comuna_cliente, Font10, Brushes.Black, 665, 25)
        '        e.Graphics.DrawString(telefono_cliente, Font10, Brushes.Black, 665, 40)
        '        e.Graphics.DrawString(condicion_doc, Font10, Brushes.Black, 665, 55)

        '        For i = 0 To grilla_detalle_documento.Rows.Count - 1
        '            VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
        '            varnombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
        '            vartecnico = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
        '            VarPrecioLista = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
        '            VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
        '            VarPrecioVenta = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
        '            VarPorcentaje = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
        '            VarDescuento = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
        '            VarNeto = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString
        '            VarIva = grilla_detalle_documento.Rows(i).Cells(9).Value.ToString
        '            VarTotal = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString

        '            cantidad_detalle = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
        '            valorUnitario_detalle = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
        '            subtotal_detalle = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
        '            total_detalle = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString


        '            '      cantidad_detalle = Format(Int(cantidad_detalle), "###,###,###")
        '            valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
        '            subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
        '            total_detalle = Format(Int(total_detalle), "###,###,###")



        '            If varnombre.Length > 35 Then
        '                varnombre = varnombre.Substring(0, 35)
        '            End If

        '            If vartecnico.Length > 22 Then
        '                vartecnico = vartecnico.Substring(0, 22)
        '            End If

        '            e.Graphics.DrawString(VarCodProducto, Font8, Brushes.Black, 10, 130 + (i * 15))
        '            e.Graphics.DrawString(varnombre, Font8, Brushes.Black, 85, 130 + (i * 15))
        '            e.Graphics.DrawString(vartecnico, Font8, Brushes.Black, 340, 130 + (i * 15))
        '            e.Graphics.DrawString(cantidad_detalle, Font8, Brushes.Black, 540, 130 + (i * 15), format1)
        '            e.Graphics.DrawString(valorUnitario_detalle, Font8, Brushes.Black, 600, 130 + (i * 15), format1)
        '            e.Graphics.DrawString(VarPorcentaje, Font8, Brushes.Black, 650, 130 + (i * 15), format1)
        '            e.Graphics.DrawString(subtotal_detalle, Font8, Brushes.Black, 730, 130 + (i * 15), format1)
        '            e.Graphics.DrawString(total_detalle, Font8, Brushes.Black, 800, 130 + (i * 15), format1)

        '            'e.Graphics.DrawString(VarCodProducto, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 0, 140 + (i * 20))
        '            'e.Graphics.DrawString(varnombre, New Font("Calibri (Cuerpo)", 8), Brushes.Black, 75, 140 + (i * 20))
        '            'e.Graphics.DrawString(vartecnico, New Font("Calibri (Cuerpo)", 8), Brushes.Black, 335, 140 + (i * 20))
        '            'e.Graphics.DrawString(cantidad_detalle, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 510, 140 + (i * 20), format1)
        '            'e.Graphics.DrawString(valorUnitario_detalle, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 590, 140 + (i * 20), format1)
        '            'e.Graphics.DrawString(VarPorcentaje, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 640, 140 + (i * 20), format1)
        '            'e.Graphics.DrawString(VarSubtotal, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 710, 140 + (i * 20), format1)
        '            'e.Graphics.DrawString(VarTotal, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 780, 140 + (i * 20), format1)
        '        Next

        '        Dim descuento_millar As String
        '        Dim neto_millar As String
        '        Dim iva_millar As String
        '        Dim total_millar As String
        '        Dim subtotal_millar As String

        '        descuento_millar = descuento_doc
        '        neto_millar = neto_doc
        '        iva_millar = iva_doc
        '        subtotal_millar = subtotal_doc
        '        total_millar = total_doc

        '        descuento_millar = Format(Int(descuento_millar), "###,###,###")
        '        neto_millar = Format(Int(neto_millar), "###,###,###")
        '        iva_millar = Format(Int(iva_millar), "###,###,###")
        '        subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
        '        total_millar = Format(Int(total_millar), "###,###,###")

        '        e.Graphics.DrawString(desglose_valor, Font9, Brushes.Black, 35, 670)
        '        e.Graphics.DrawString(minombre, Font9, Brushes.Black, 35, 690)

        '        e.Graphics.DrawString(nombre_retira, Font8, Brushes.Black, 50, 735)
        '        e.Graphics.DrawString(fecha_doc, Font8, Brushes.Black, 40, 755)
        '        e.Graphics.DrawString(rut_retira, Font8, Brushes.Black, 470, 735)
        '        e.Graphics.DrawString(mirecintoempresa, Font8, Brushes.Black, 180, 755)

        '        e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 792, 680, format1)
        '        '  e.Graphics.DrawString(descuento_millar, Font10, Brushes.Black, 792, 700, format1)
        '        e.Graphics.DrawString(neto_millar, Font10, Brushes.Black, 792, 725, format1)
        '        e.Graphics.DrawString(iva_millar, Font10, Brushes.Black, 792, 745, format1)
        '        e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 792, 765, format1)

        '        If descuento_millar <> "" Then
        '            If descuento_millar <> "0" Then
        '                e.Graphics.DrawString(subtotal_millar, Font8, Brushes.Black, 800, 580, format1)
        '                e.Graphics.DrawString("-  " & descuento_millar, Font8, Brushes.Black, 800, 600, format1)
        '                e.Graphics.DrawString("_________", Font8, Brushes.Black, 800, 602, format1)
        '                e.Graphics.DrawString(total_millar, Font8, Brushes.Black, 800, 620, format1)
        '            End If
        '        End If
        '        'e.Graphics.DrawString(neto_millar, Font10, Brushes.Black, 792, 745, format1)
        '        'e.Graphics.DrawString(iva_millar, Font10, Brushes.Black, 792, 745, format1)











        '        'Pd = New Printing.PrintDocument
        '        'Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 100, 200)
        '        'Pd.PrinterSettings.DefaultPageSettings.PaperSize = pkCustomSize1
        '    End If



        '    If tipo_doc = "FACTURA DE CREDITO" Then
        '        e.Graphics.DrawString(txt_factura.Text, Font10, Brushes.Black, 550, 10, format1)
        '        e.Graphics.DrawString(fecha_doc & " " & mirecintoempresa, Font10, Brushes.Black, 85, 10)
        '        e.Graphics.DrawString(nombre_cliente, Font10, Brushes.Black, 85, 25)
        '        e.Graphics.DrawString(folio_cliente, Font10, Brushes.Black, 550, 25, format1)
        '        e.Graphics.DrawString(direccion_cliente, Font10, Brushes.Black, 85, 40)
        '        e.Graphics.DrawString(giro_cliente, Font10, Brushes.Black, 85, 55)

        '        If orden_de_compra <> "" Then
        '            If orden_de_compra <> "0" Then
        '                e.Graphics.DrawString("ORDEN DE COMPRA: " & orden_de_compra, Font10, Brushes.Black, 50, 70)
        '            End If
        '        End If

        '        e.Graphics.DrawString(rut_cliente, Font10, Brushes.Black, 665, 10)
        '        e.Graphics.DrawString(comuna_cliente, Font10, Brushes.Black, 665, 25)
        '        e.Graphics.DrawString(telefono_cliente, Font10, Brushes.Black, 665, 40)
        '        e.Graphics.DrawString(condicion_doc, Font10, Brushes.Black, 665, 55)

        '        For i = 0 To grilla_detalle_documento.Rows.Count - 1
        '            VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
        '            varnombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
        '            vartecnico = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
        '            VarPrecioLista = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
        '            VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
        '            VarPrecioVenta = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
        '            VarPorcentaje = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
        '            VarDescuento = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
        '            VarNeto = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString
        '            VarIva = grilla_detalle_documento.Rows(i).Cells(9).Value.ToString
        '            VarTotal = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString

        '            cantidad_detalle = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
        '            valorUnitario_detalle = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
        '            subtotal_detalle = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
        '            total_detalle = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString


        '            'cantidad_detalle = Format(Int(cantidad_detalle), "###,###,###")
        '            valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
        '            subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
        '            total_detalle = Format(Int(total_detalle), "###,###,###")



        '            If varnombre.Length > 35 Then
        '                varnombre = varnombre.Substring(0, 35)
        '            End If

        '            If vartecnico.Length > 22 Then
        '                vartecnico = vartecnico.Substring(0, 22)
        '            End If

        '            e.Graphics.DrawString(VarCodProducto, Font8, Brushes.Black, 10, 130 + (i * 15))
        '            e.Graphics.DrawString(varnombre, Font8, Brushes.Black, 85, 130 + (i * 15))
        '            e.Graphics.DrawString(vartecnico, Font8, Brushes.Black, 340, 130 + (i * 15))
        '            e.Graphics.DrawString(cantidad_detalle, Font8, Brushes.Black, 540, 130 + (i * 15), format1)
        '            e.Graphics.DrawString(valorUnitario_detalle, Font8, Brushes.Black, 600, 130 + (i * 15), format1)
        '            e.Graphics.DrawString(VarPorcentaje, Font8, Brushes.Black, 650, 130 + (i * 15), format1)
        '            e.Graphics.DrawString(subtotal_detalle, Font8, Brushes.Black, 730, 130 + (i * 15), format1)
        '            e.Graphics.DrawString(total_detalle, Font8, Brushes.Black, 800, 130 + (i * 15), format1)

        '            'e.Graphics.DrawString(VarCodProducto, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 0, 140 + (i * 20))
        '            'e.Graphics.DrawString(varnombre, New Font("Calibri (Cuerpo)", 8), Brushes.Black, 75, 140 + (i * 20))
        '            'e.Graphics.DrawString(vartecnico, New Font("Calibri (Cuerpo)", 8), Brushes.Black, 335, 140 + (i * 20))
        '            'e.Graphics.DrawString(cantidad_detalle, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 510, 140 + (i * 20), format1)
        '            'e.Graphics.DrawString(valorUnitario_detalle, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 590, 140 + (i * 20), format1)
        '            'e.Graphics.DrawString(VarPorcentaje, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 640, 140 + (i * 20), format1)
        '            'e.Graphics.DrawString(VarSubtotal, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 710, 140 + (i * 20), format1)
        '            'e.Graphics.DrawString(VarTotal, New Font("Calibri (Cuerpo)", 9), Brushes.Black, 780, 140 + (i * 20), format1)
        '        Next

        '        Dim descuento_millar As String
        '        Dim neto_millar As String
        '        Dim iva_millar As String
        '        Dim total_millar As String
        '        Dim subtotal_millar As String

        '        descuento_millar = descuento_doc
        '        neto_millar = neto_doc
        '        iva_millar = iva_doc
        '        subtotal_millar = subtotal_doc
        '        total_millar = total_doc

        '        descuento_millar = Format(Int(descuento_millar), "###,###,###")
        '        neto_millar = Format(Int(neto_millar), "###,###,###")
        '        iva_millar = Format(Int(iva_millar), "###,###,###")
        '        subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
        '        total_millar = Format(Int(total_millar), "###,###,###")

        '        e.Graphics.DrawString(desglose_valor, Font9, Brushes.Black, 35, 670)
        '        e.Graphics.DrawString(minombre, Font9, Brushes.Black, 35, 690)

        '        e.Graphics.DrawString(nombre_cliente, Font8, Brushes.Black, 50, 735)
        '        e.Graphics.DrawString(fecha_doc, Font8, Brushes.Black, 40, 755)
        '        e.Graphics.DrawString(rut_retira, Font8, Brushes.Black, 470, 735)
        '        e.Graphics.DrawString(mirecintoempresa, Font8, Brushes.Black, 180, 755)

        '        e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 792, 680, format1)
        '        ' e.Graphics.DrawString(descuento_millar, Font10, Brushes.Black, 792, 700, format1)
        '        e.Graphics.DrawString(neto_millar, Font10, Brushes.Black, 792, 725, format1)
        '        e.Graphics.DrawString(iva_millar, Font10, Brushes.Black, 792, 745, format1)
        '        e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 792, 765, format1)

        '        If descuento_millar <> "" Then
        '            If descuento_millar <> "0" Then
        '                e.Graphics.DrawString(subtotal_millar, Font8, Brushes.Black, 800, 580, format1)
        '                e.Graphics.DrawString("-  " & descuento_millar, Font8, Brushes.Black, 800, 600, format1)
        '                e.Graphics.DrawString("_________", Font8, Brushes.Black, 800, 602, format1)
        '                e.Graphics.DrawString(total_millar, Font8, Brushes.Black, 800, 620, format1)
        '            End If
        '        End If
        '        'e.Graphics.DrawString(neto_millar, Font10, Brushes.Black, 792, 745, format1)
        '        'e.Graphics.DrawString(iva_millar, Font10, Brushes.Black, 792, 745, format1)











        '        'Pd = New Printing.PrintDocument
        '        'Dim pkCustomSize1 As New Printing.PaperSize("Custom Paper Size", 100, 200)
        '        'Pd.PrinterSettings.DefaultPageSettings.PaperSize = pkCustomSize1
        '    End If

        '    If tipo_doc = "GUIA" Then
        '        If mirutempresa <> "81921000-4" Then
        '            e.Graphics.DrawString(fecha_doc & " " & mirecintoempresa, Font10, Brushes.Black, 100, 20)
        '            e.Graphics.DrawString(Me.txt_factura.Text, Font10, Brushes.Black, 550, 20, format1)
        '            e.Graphics.DrawString(nombre_cliente, Font10, Brushes.Black, 100, 36)
        '            e.Graphics.DrawString(folio_cliente, Font10, Brushes.Black, 550, 36, format1)
        '            e.Graphics.DrawString(direccion_cliente, Font10, Brushes.Black, 100, 52)
        '            e.Graphics.DrawString(giro_cliente, Font10, Brushes.Black, 100, 68)
        '            e.Graphics.DrawString(orden_de_compra, Font10, Brushes.Black, 100, 84)
        '            e.Graphics.DrawString(rut_cliente, Font10, Brushes.Black, 655, 20)
        '            e.Graphics.DrawString(comuna_cliente, Font10, Brushes.Black, 655, 36)
        '            e.Graphics.DrawString(telefono_cliente, Font10, Brushes.Black, 655, 52)
        '            e.Graphics.DrawString(condicion_doc, Font10, Brushes.Black, 655, 68)
        '            e.Graphics.DrawString(minombre, Font10, Brushes.Black, 655, 84)

        '            For i = 0 To Me.grilla_detalle_documento.Rows.Count - 1
        '                VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
        '                varnombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
        '                vartecnico = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
        '                VarPrecioLista = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
        '                VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
        '                VarPrecioVenta = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
        '                VarPorcentaje = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
        '                VarDescuento = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
        '                VarNeto = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString
        '                VarIva = grilla_detalle_documento.Rows(i).Cells(9).Value.ToString
        '                VarTotal = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString
        '                cantidad_detalle = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
        '                valorUnitario_detalle = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
        '                subtotal_detalle = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
        '                total_detalle = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString

        '                valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
        '                subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
        '                total_detalle = Format(Int(total_detalle), "###,###,###")

        '                If varnombre.Length > 35 Then
        '                    varnombre = varnombre.Substring(0, 35)
        '                End If

        '                If vartecnico.Length > 22 Then
        '                    vartecnico = vartecnico.Substring(0, 22)
        '                End If

        '                e.Graphics.DrawString(VarCodProducto, Font8, Brushes.Black, 0, 145 + (i * 15))
        '                e.Graphics.DrawString(varnombre, Font8, Brushes.Black, 75, 145 + (i * 15))
        '                e.Graphics.DrawString(vartecnico, Font8, Brushes.Black, 335, 145 + (i * 15))
        '                e.Graphics.DrawString(cantidad_detalle, Font8, Brushes.Black, 520, 145 + (i * 15), format1)
        '                e.Graphics.DrawString(valorUnitario_detalle, Font8, Brushes.Black, 600, 145 + (i * 15), format1)
        '                e.Graphics.DrawString(VarPorcentaje, Font8, Brushes.Black, 640, 145 + (i * 15), format1)
        '                e.Graphics.DrawString(subtotal_detalle, Font8, Brushes.Black, 725, 145 + (i * 15), format1)
        '                e.Graphics.DrawString(total_detalle, Font8, Brushes.Black, 792, 145 + (i * 15), format1)
        '            Next

        '            Dim descuento_millar As String
        '            Dim neto_millar As String
        '            Dim iva_millar As String
        '            Dim total_millar As String
        '            Dim subtotal_millar As String

        '            descuento_millar = descuento_doc
        '            neto_millar = neto_doc
        '            iva_millar = iva_doc
        '            subtotal_millar = subtotal_doc
        '            total_millar = total_doc

        '            descuento_millar = Format(Int(descuento_millar), "###,###,###")
        '            neto_millar = Format(Int(neto_millar), "###,###,###")
        '            iva_millar = Format(Int(iva_millar), "###,###,###")
        '            subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
        '            total_millar = Format(Int(total_millar), "###,###,###")

        '            e.Graphics.DrawString(nombre_retira, Font8, Brushes.Black, 55, 540)
        '            e.Graphics.DrawString(rut_retira, Font8, Brushes.Black, 265, 540)
        '            e.Graphics.DrawString(mirecintoempresa, Font8, Brushes.Black, 510, 540)
        '            e.Graphics.DrawString(fecha_doc, Font8, Brushes.Black, 797, 540, format1)

        '            If condicion_doc <> "TRASLADO" Then
        '                If porcentaje_desc_doc = "0" Or porcentaje_desc_doc = "" Then
        '                    e.Graphics.DrawString("TOTAL $", Font8, Brushes.Black, 725, 400, format1)
        '                    e.Graphics.DrawString(total_millar, Font8, Brushes.Black, 792, 400, format1)
        '                Else
        '                    e.Graphics.DrawString(subtotal_millar, Font8, Brushes.Black, 792, 400, format1)
        '                    e.Graphics.DrawString("-" & porcentaje_desc_doc & "%", Font8, Brushes.Black, 725, 415, format1)
        '                    e.Graphics.DrawString(descuento_millar, Font8, Brushes.Black, 792, 415, format1)
        '                    e.Graphics.DrawString("_________", Font8, Brushes.Black, 792, 417, format1)
        '                    e.Graphics.DrawString(total_millar, Font8, Brushes.Black, 792, 432, format1)
        '                End If
        '            End If
        '        End If

        '        If mirutempresa = "81921000-4" Then

        '            'e.Graphics.DrawString("NRO. GUIA: " & txt_factura.Text & ", PROVIENE DE: " & mirecintoempresa & " , BULTOS: " & txt_productos.Text, Font10, Brushes.Black, 0, 0)
        '            e.Graphics.DrawString(txt_factura.Text, Font10, Brushes.Black, 85, 0)
        '            e.Graphics.DrawString(fecha_doc, Font10, Brushes.Black, 620, 0)
        '            e.Graphics.DrawString(nombre_cliente, Font10, Brushes.Black, 80, 40)
        '            e.Graphics.DrawString(direccion_cliente, Font10, Brushes.Black, 80, 57)
        '            e.Graphics.DrawString(giro_cliente, Font10, Brushes.Black, 80, 74)
        '            e.Graphics.DrawString(telefono_cliente, Font10, Brushes.Black, 80, 91)
        '            'e.Graphics.DrawString(Combo_vehiculo.Text, Font10, Brushes.Black, 80, 108)
        '            e.Graphics.DrawString(rut_cliente, Font10, Brushes.Black, 550, 40)
        '            e.Graphics.DrawString(comuna_cliente, Font10, Brushes.Black, 550, 57)
        '            'e.Graphics.DrawString(txt_ciudad_cliente.Text, Font10, Brushes.Black, 550, 74)
        '            e.Graphics.DrawString(combo_condiciones.Text, Font10, Brushes.Black, 550, 91)
        '            'e.Graphics.DrawString(txt_patente.Text, Font10, Brushes.Black, 550, 108)

        '            For i = 0 To Me.grilla_detalle_documento.Rows.Count - 1
        '                VarCodProducto = grilla_detalle_documento.Rows(i).Cells(0).Value.ToString
        '                varnombre = grilla_detalle_documento.Rows(i).Cells(1).Value.ToString
        '                vartecnico = grilla_detalle_documento.Rows(i).Cells(2).Value.ToString
        '                VarPrecioLista = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
        '                VarCantidad = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
        '                VarPrecioVenta = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
        '                VarPorcentaje = grilla_detalle_documento.Rows(i).Cells(6).Value.ToString
        '                VarDescuento = grilla_detalle_documento.Rows(i).Cells(7).Value.ToString
        '                VarNeto = grilla_detalle_documento.Rows(i).Cells(8).Value.ToString
        '                VarIva = grilla_detalle_documento.Rows(i).Cells(9).Value.ToString
        '                VarTotal = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString
        '                cantidad_detalle = grilla_detalle_documento.Rows(i).Cells(4).Value.ToString
        '                valorUnitario_detalle = grilla_detalle_documento.Rows(i).Cells(3).Value.ToString
        '                subtotal_detalle = grilla_detalle_documento.Rows(i).Cells(5).Value.ToString
        '                total_detalle = grilla_detalle_documento.Rows(i).Cells(10).Value.ToString
        '                valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
        '                subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
        '                total_detalle = Format(Int(total_detalle), "###,###,###")

        '                If varnombre.Length > 35 Then
        '                    varnombre = varnombre.Substring(0, 35)
        '                End If

        '                If vartecnico.Length > 22 Then
        '                    vartecnico = vartecnico.Substring(0, 22)
        '                End If

        '                e.Graphics.DrawString(VarCodProducto, Font8, Brushes.Black, 10, 190 + (i * 15))
        '                e.Graphics.DrawString(varnombre & " " & vartecnico, Font8, Brushes.Black, 130, 190 + (i * 15))
        '                e.Graphics.DrawString(cantidad_detalle, Font8, Brushes.Black, 570, 190 + (i * 15), format1)
        '                e.Graphics.DrawString(valorUnitario_detalle, Font8, Brushes.Black, 730, 190 + (i * 15), format1)
        '            Next

        '            Dim descuento_millar As String
        '            Dim neto_millar As String
        '            Dim iva_millar As String
        '            Dim total_millar As String
        '            Dim subtotal_millar As String

        '            descuento_millar = descuento_doc
        '            neto_millar = neto_doc
        '            iva_millar = iva_doc
        '            subtotal_millar = subtotal_doc
        '            total_millar = total_doc

        '            descuento_millar = Format(Int(descuento_millar), "###,###,###")
        '            neto_millar = Format(Int(neto_millar), "###,###,###")
        '            iva_millar = Format(Int(iva_millar), "###,###,###")
        '            subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
        '            total_millar = Format(Int(total_millar), "###,###,###")

        '            e.Graphics.DrawString(nombre_retira, Font8, Brushes.Black, 55, 540)
        '            e.Graphics.DrawString(rut_retira, Font8, Brushes.Black, 265, 540)
        '            e.Graphics.DrawString(mirecintoempresa, Font8, Brushes.Black, 510, 540)
        '            e.Graphics.DrawString(fecha_doc, Font8, Brushes.Black, 797, 540, format1)

        '            If condicion_doc <> "TRASLADO" Then
        '                If porcentaje_desc_doc = "0" Or porcentaje_desc_doc = "" Then
        '                    e.Graphics.DrawString("TOTAL $", Font8, Brushes.Black, 725, 400, format1)
        '                    e.Graphics.DrawString(total_millar, Font8, Brushes.Black, 792, 400, format1)
        '                Else
        '                    e.Graphics.DrawString(subtotal_millar, Font8, Brushes.Black, 792, 400, format1)
        '                    e.Graphics.DrawString("-" & porcentaje_desc_doc & "%", Font8, Brushes.Black, 725, 415, format1)
        '                    e.Graphics.DrawString(descuento_millar, Font8, Brushes.Black, 792, 415, format1)
        '                    e.Graphics.DrawString("_________", Font8, Brushes.Black, 792, 417, format1)
        '                    e.Graphics.DrawString(total_millar, Font8, Brushes.Black, 792, 432, format1)
        '                End If
        '            End If
        '        End If

        '    End If
        'End If


    End Sub
















    Sub imprimir()
        '  Dim VarPorcentajeDesc As String
        '  Dim VarCantidadDesc As Integer
        ' Dim VarDescuentoCliente As Integer
        ' Dim porcentaje_desc As Integer
        '  Dim mensaje As String = ""
        '  VarCantidadDesc = 0



        If combo_venta.Text = "GUIA" Then




            If estado_guia_electronica = "NO" Then
                With Pd.PrinterSettings
                    ' Especifico el nombre de la impresora 
                    ' por donde deseo imprimir. 
                    .PrinterName = impresora_guias
                    ' Establezco el número de copias que se imprimirán 
                    .Copies = 1
                    ' Rango de páginas que se imprimirán 
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then

                        Me.Enabled = False
                        Me.crear_numero_documento()
                        Me.grabar_factura()


                        Me.Pd.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()


                        Me.grabar_detalle_factura()
                        'Form_autorizacion_pie.Close()
                        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        ' Form_impreso_corectamente.Show()
                        Me.crear_archivo_plano()
                        ' Me.limpiar()
                        Me.Enabled = True
                        ' Me.controles(False, True)
                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
            Else

                Me.Enabled = False
                Me.crear_numero_documento()
                Me.grabar_factura()
                Me.grabar_detalle_factura()
                'Form_autorizacion_pie.Close()
                MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                ' Form_impreso_corectamente.Show()
                Me.crear_archivo_plano()
                ' Me.limpiar()
                Me.Enabled = True
                'Me.controles(False, True)
                Exit Sub

            End If
        End If









        If combo_venta.Text = "FACTURA DE CREDITO" Then












            If estado_factura_electronica = "NO" Then
                With Pd.PrinterSettings
                    ' Especifico el nombre de la impresora 
                    ' por donde deseo imprimir. 
                    .PrinterName = impresora_facturas
                    ' Establezco el número de copias que se imprimirán 
                    .Copies = 1
                    ' Rango de páginas que se imprimirán 
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then

                        Me.Enabled = False
                        Me.crear_numero_documento()
                        Me.grabar_factura()


                        Me.Pd.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 1100)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()

                        Me.grabar_detalle_factura()
                        'Form_autorizacion_pie.Close()
                        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        ' Form_impreso_corectamente.Show()
                        Me.crear_archivo_plano()
                        ' Me.limpiar()
                        Me.Enabled = True
                        'Me.controles(False, True)
                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
            Else

                Me.Enabled = False
                Me.crear_numero_documento()
                Me.grabar_factura()
                Me.grabar_detalle_factura()
                'Form_autorizacion_pie.Close()
                MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                ' Form_impreso_corectamente.Show()
                Me.crear_archivo_plano()
                ' Me.limpiar()
                Me.Enabled = True
                ' Me.controles(False, True)
                Exit Sub
            End If
        End If




        If combo_venta.Text = "BOLETA" Then







            If estado_boleta_electronica = "NO" Then
                With Pd.PrinterSettings
                    ' Especifico el nombre de la impresora 
                    ' por donde deseo imprimir. 
                    .PrinterName = impresora_boletas
                    ' Establezco el número de copias que se imprimirán 
                    .Copies = 1
                    ' Rango de páginas que se imprimirán 
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then

                        Me.Enabled = False
                        ' Me.redondear_documento()
                        Me.crear_numero_documento()
                        Me.grabar_factura()


                        Me.Pd.PrintController = New StandardPrintController
                        Me.Pd.DefaultPageSettings.Margins.Left = 10
                        Me.Pd.DefaultPageSettings.Margins.Right = 10
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 547)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1

                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()






                        Me.grabar_detalle_factura()
                        'Form_autorizacion_pie.Close()
                        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        ' Form_impreso_corectamente.Show()
                        Me.crear_archivo_plano()
                        ' Me.limpiar()
                        Me.Enabled = True
                        '  Me.controles(False, True)

                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
            Else

                Me.Enabled = False
                ' Me.redondear_documento()
                Me.crear_numero_documento()
                Me.grabar_factura()
                Me.grabar_detalle_factura()
                'Form_autorizacion_pie.Close()
                MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                ' Form_impreso_corectamente.Show()
                Me.crear_archivo_plano()
                '  Me.limpiar()
                Me.Enabled = True
                ' Me.controles(False, True)
                Exit Sub

            End If
        End If



        If combo_venta.Text = "BOLETA DE CREDITO" Then






            If estado_boleta_electronica = "NO" Then
                With Pd.PrinterSettings
                    ' Especifico el nombre de la impresora 
                    ' por donde deseo imprimir. 
                    .PrinterName = impresora_boletas
                    ' Establezco el número de copias que se imprimirán 
                    .Copies = 1
                    ' Rango de páginas que se imprimirán 
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then

                        Me.Enabled = False
                        Me.crear_numero_documento()
                        Me.grabar_factura()


                        Me.Pd.PrintController = New StandardPrintController
                        Me.Pd.DefaultPageSettings.Margins.Left = 10
                        Me.Pd.DefaultPageSettings.Margins.Right = 10
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 547)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1

                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()

                        Me.grabar_detalle_factura()
                        'Form_autorizacion_pie.Close()
                        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        ' Form_impreso_corectamente.Show()
                        Me.crear_archivo_plano()
                        ' Me.limpiar()
                        Me.Enabled = True
                        '  Me.controles(False, True)

                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
            Else

                Me.Enabled = False
                Me.crear_numero_documento()
                Me.grabar_factura()
                Me.grabar_detalle_factura()
                'Form_autorizacion_pie.Close()
                MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                ' Form_impreso_corectamente.Show()
                Me.crear_archivo_plano()
                '  Me.limpiar()
                Me.Enabled = True
                ' Me.controles(False, True)
                Exit Sub

            End If
        End If









        If combo_venta.Text = "FACTURA" Then







            If estado_factura_electronica = "NO" Then
                With Pd.PrinterSettings
                    ' Especifico el nombre de la impresora 
                    ' por donde deseo imprimir. 
                    .PrinterName = impresora_facturas
                    ' Establezco el número de copias que se imprimirán 
                    .Copies = 1
                    ' Rango de páginas que se imprimirán 
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then

                        Me.Enabled = False
                        ' Me.redondear_documento()
                        Me.crear_numero_documento()
                        Me.grabar_factura()


                        '   .PrinterName = impresora_facturas

                        Me.Pd.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 1100)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()




                        Me.grabar_detalle_factura()
                        'Form_autorizacion_pie.Close()
                        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        ' Form_impreso_corectamente.Show()
                        Me.crear_archivo_plano()
                        ' Me.limpiar()
                        Me.Enabled = True
                        ' Me.controles(False, True)
                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
            Else
                Me.Enabled = False
                '   Me.redondear_documento()
                Me.crear_numero_documento()
                Me.grabar_factura()
                Me.grabar_detalle_factura()
                'Form_autorizacion_pie.Close()
                MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                ' Form_impreso_corectamente.Show()
                Me.crear_archivo_plano()
                ' Me.limpiar()
                Me.Enabled = True
                ' Me.controles(False, True)
                Exit Sub
            End If
        End If



    End Sub

    Private Sub combo_condiciones_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_condiciones.LostFocus
        'TextBox1.Text = ActiveControl.Name
    End Sub

    Private Sub combo_condiciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_condiciones.SelectedIndexChanged
        If combo_condiciones.Text = "OTRO MEDIO DE PAGO" Then
            Form_otro_medio_de_pago_ticket.Show()
            Me.Enabled = False
        End If

        If combo_condiciones.Text = "EFECTIVO" Then
            txt_efectivo.BackColor = Color.White
            txt_efectivo.Text = ""
            txt_vuelto.Text = ""
            txt_efectivo.Enabled = True
            txt_vuelto.Enabled = True
            txt_efectivo.Focus()
        Else
            txt_efectivo.BackColor = SystemColors.Control
            txt_efectivo.Text = ""
            txt_vuelto.Text = ""
            txt_efectivo.Enabled = False
            txt_vuelto.Enabled = False
        End If



        If grilla_detalle_documento.Rows.Count <> 0 Then
            Dim condicion_doc As String

            condicion_doc = grilla_documento.CurrentRow.Cells(2).Value
            If condicion_doc <> "LETRA" And combo_condiciones.SelectedItem = "LETRA" Then
                combo_condiciones.SelectedItem = "-"
            End If
        End If


    End Sub

    Private Sub btn_play_vendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_play_vendedor.Click
        btn_play_vendedor.Visible = False
        btn_pause_vendedor.Visible = True
        btn_pause_vendedor.Focus()
        Timer_actualizar.Start()
    End Sub

    Private Sub btn_pause_vendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pause_vendedor.Click
        btn_play_vendedor.Visible = True
        btn_play_vendedor.Focus()
        btn_pause_vendedor.Visible = False
        Timer_actualizar.Stop()
        contador = 0
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    'Private Structure LASTINPUTINFO
    '    Public cbSize As UInteger
    '    Public dwTime As UInteger
    'End Structure

    '<DllImport("User32.dll")> _
    'Private Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    'End Function

    'Public Function GetInactiveTime() As Nullable(Of TimeSpan)
    '    Dim info As LASTINPUTINFO = New LASTINPUTINFO
    '    info.cbSize = CUInt(Marshal.SizeOf(info))
    '    If (GetLastInputInfo(info)) Then
    '        Return TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime)
    '    Else
    '        Return Nothing
    '    End If
    'End Function

    Private Sub Timer_actualizar_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_actualizar.Tick
        'Dim inactiveTime = GetInactiveTime()
        'If (inactiveTime.Value.TotalSeconds > 15) And Me.Enabled = True Then
        '    btn_mostrar.PerformClick()
        '    inactiveTime.
        'End If



    End Sub


    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        mostrar_malla()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub


    Private Function ReturnDataSet() As DataSet
        'Dim dt As New DataTable
        'Dim dr As DataRow
        'Dim ds As New DataSet

        ''Dim Total_letra As Integer
        ''Dim Comprobar_letra As Integer

        ''Total_letra = (txt_total.Text) / (txt_cargar.Text)
        ''Comprobar_letra = (Total_letra) * (txt_cargar.Text)
        ''Comprobar_letra = (txt_total.Text) - (Comprobar_letra)
        ''Total_letra = (Total_letra) + (Comprobar_letra)
        ''Round(Total_letra)

        'dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
        'dt.Columns.Add(New DataColumn("nro_doc", GetType(String)))
        'dt.Columns.Add(New DataColumn("documento_referencia", GetType(String)))
        'dt.Columns.Add(New DataColumn("monto_total", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("nro_letra", GetType(String)))
        'dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))
        'dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
        'dt.Columns.Add(New DataColumn("telefono_cliente", GetType(String)))
        'dt.Columns.Add(New DataColumn("ciudad_cliente", GetType(String)))
        'dt.Columns.Add(New DataColumn("direccion_cliente", GetType(String)))
        'dt.Columns.Add(New DataColumn("monto_letra", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("desglose", GetType(String)))
        'dt.Columns.Add(New DataColumn("girador", GetType(String)))
        'dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        'dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("fecha_palabras", GetType(String)))
        'dt.Columns.Add(New DataColumn("fecha_letra_palabras", GetType(String)))
        'dt.Columns.Add(New DataColumn("nombre_firma", GetType(String)))
        'dt.Columns.Add(New DataColumn("comuna_cliente", GetType(String)))

        'Dim nro_vale As String
        'Dim tipo_doc As String
        'Dim condicion_doc As String
        'Dim fecha_doc As String
        'Dim cod_cliente As String
        'Dim rut_cliente As String
        'Dim nombre_cliente As String
        'Dim direccion_cliente As String
        'Dim comuna_cliente As String
        'Dim ciudad_cliente As String
        'Dim telefono_cliente As String
        'Dim folio_cliente As String
        'Dim giro_cliente As String
        'Dim correo_cliente As String
        'Dim subtotal_doc As String
        'Dim porcentaje_desc_doc As String
        'Dim descuento_doc As String
        'Dim neto_doc As String
        'Dim iva_doc As String
        'Dim total_doc As String
        'Dim rut_vendedor As String
        'Dim nombre_vendedor As String
        'Dim rut_retira As String
        'Dim nombre_retira As String

        'nro_vale = Me.grilla_documento.CurrentRow.Cells(0).Value
        'tipo_doc = Me.grilla_documento.CurrentRow.Cells(1).Value
        'condicion_doc = Me.grilla_documento.CurrentRow.Cells(2).Value
        'fecha_doc = Me.grilla_documento.CurrentRow.Cells(3).Value
        'cod_cliente = Me.grilla_documento.CurrentRow.Cells(4).Value
        'rut_cliente = Me.grilla_documento.CurrentRow.Cells(5).Value
        'nombre_cliente = Me.grilla_documento.CurrentRow.Cells(6).Value
        'direccion_cliente = Me.grilla_documento.CurrentRow.Cells(7).Value
        'comuna_cliente = Me.grilla_documento.CurrentRow.Cells(8).Value
        'ciudad_cliente = Me.grilla_documento.CurrentRow.Cells(9).Value
        'telefono_cliente = Me.grilla_documento.CurrentRow.Cells(10).Value
        'folio_cliente = Me.grilla_documento.CurrentRow.Cells(11).Value
        'giro_cliente = Me.grilla_documento.CurrentRow.Cells(12).Value
        'correo_cliente = Me.grilla_documento.CurrentRow.Cells(13).Value
        'subtotal_doc = Me.grilla_documento.CurrentRow.Cells(14).Value
        'porcentaje_desc_doc = Me.grilla_documento.CurrentRow.Cells(15).Value
        'descuento_doc = Me.grilla_documento.CurrentRow.Cells(16).Value
        'neto_doc = Me.grilla_documento.CurrentRow.Cells(17).Value
        'iva_doc = Me.grilla_documento.CurrentRow.Cells(18).Value
        'total_doc = Me.grilla_documento.CurrentRow.Cells(19).Value
        'rut_vendedor = Me.grilla_documento.CurrentRow.Cells(20).Value
        'nombre_vendedor = Me.grilla_documento.CurrentRow.Cells(21).Value
        'rut_retira = Me.grilla_documento.CurrentRow.Cells(22).Value
        'nombre_retira = Me.grilla_documento.CurrentRow.Cells(23).Value

        'Dim mifecha As Date
        'mifecha = fecha_doc
        'fecha_doc = mifecha.ToString("yyy-MM-dd")

        'peso = " PESOS"
        'If CInt(varTotalCuota) = 1000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & " DE PESOS"
        'ElseIf CInt(varTotalCuota) = 2000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 3000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 4000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 5000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 6000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 7000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 8000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 9000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 10000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 11000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 12000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 13000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 14000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 15000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 16000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 17000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 18000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 19000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 20000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 21000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 22000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 23000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 24000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 25000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 26000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 27000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 28000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 29000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'ElseIf CInt(varTotalCuota) = 30000000 Then
        '    desglose_letra = Num2Text(varTotalCuota) & "DE PESOS"
        'Else
        '    desglose_letra = Num2Text(varTotalCuota) & peso
        'End If

        'Dim mifecha_letra As Date
        'mifecha_letra = varFechaCuota
        'varFechaCuota = mifecha_letra.ToString("yyy-MM-dd")

        'dr = dt.NewRow()

        'Try
        '    dr("Imagen") = ImageToByte(Image.FromFile("C:\Sistema de ventas\Logo de empresa\logo_crystal.jpg"))
        'Catch
        'End Try

        'dr("nro_doc") = txt_nro_letra.Text
        'dr("nro_letra") = cantidad_letras & " DE " & grilla_cuotas.Rows.Count
        'dr("documento_referencia") = combo_venta.Text & " NRO. " & txt_factura.Text
        'dr("fecha") = varFechaCuota
        'dr("rut_cliente") = rut_cliente
        'dr("nombre_cliente") = nombre_cliente
        'dr("telefono_cliente") = telefono_cliente
        'dr("ciudad_cliente") = ciudad_cliente
        'dr("direccion_cliente") = direccion_cliente
        'dr("monto_letra") = varTotalCuota
        'dr("monto_total") = varTotalCuota
        'dr("desglose") = desglose_letra
        'dr("girador") = minombreempresa
        'dr("nombre_empresa") = minombreempresa
        'dr("giro_empresa") = migiroempresa
        'dr("direccion_empresa") = midireccionempresa
        'dr("comuna_empresa") = micomunaempresa
        'dr("telefono_empresa") = mitelefonoempresa
        'dr("correo_empresa") = micorreoempresa
        'dr("rut_empresa") = mirutempresa
        'dr("fecha_palabras") = Format(form_Menu_admin.dtp_fecha.Text, "Long Date")
        'dr("fecha_letra_palabras") = Format(varFechaCuota, "Long Date")
        'dr("comuna_cliente") = comuna_cliente
        'dr("nombre_firma") = "P.P " & minombreempresa
        'dt.Rows.Add(dr)

        'ds.Tables.Add(dt)
        'ds.Tables(0).TableName = "Letra"

        'Dim iDS As New dsletra

        'iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
        'Return iDS
        Return Nothing
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


    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        Dim valormensaje As Integer
        If grilla_documento.Rows.Count = 0 Then
            MsgBox("DEBE SELECCIONAR UN DOCUMENTO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If


        If grilla_detalle_documento.Rows.Count = 0 Then
            MsgBox("DEBE SELECCIONAR UN DOCUMENTO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        Dim estado_doc As String
        estado_doc = grilla_documento.CurrentRow.Cells(24).Value
        If estado_doc = "EMITIDO" Then
            MsgBox("EL TICKET YA FUE IMPRESO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_condiciones.Text = "" Then
            Exit Sub
        End If

        If combo_condiciones.Text = "-" Then
            Exit Sub
        End If

        Dim nro_vale As String
        Dim tipo_doc As String
        Dim condicion_doc As String
        Dim fecha_doc As String
        Dim cod_cliente As String
        Dim rut_cliente As String
        Dim nombre_cliente As String
        Dim direccion_cliente As String
        Dim comuna_cliente As String
        Dim ciudad_cliente As String
        Dim telefono_cliente As String
        Dim folio_cliente As String
        Dim giro_cliente As String
        Dim correo_cliente As String
        Dim subtotal_doc As String
        Dim porcentaje_desc_doc As String
        Dim descuento_doc As String
        Dim neto_doc As String
        Dim iva_doc As String
        Dim total_doc As String
        Dim rut_vendedor As String
        Dim nombre_vendedor As String
        Dim rut_retira As String
        Dim nombre_retira As String


        nro_vale = grilla_documento.CurrentRow.Cells(0).Value
        tipo_doc = grilla_documento.CurrentRow.Cells(1).Value
        condicion_doc = grilla_documento.CurrentRow.Cells(2).Value
        fecha_doc = grilla_documento.CurrentRow.Cells(3).Value
        cod_cliente = grilla_documento.CurrentRow.Cells(4).Value
        rut_cliente = grilla_documento.CurrentRow.Cells(5).Value
        nombre_cliente = grilla_documento.CurrentRow.Cells(6).Value
        direccion_cliente = grilla_documento.CurrentRow.Cells(7).Value
        comuna_cliente = grilla_documento.CurrentRow.Cells(8).Value
        ciudad_cliente = grilla_documento.CurrentRow.Cells(9).Value
        telefono_cliente = grilla_documento.CurrentRow.Cells(10).Value
        folio_cliente = grilla_documento.CurrentRow.Cells(11).Value
        giro_cliente = grilla_documento.CurrentRow.Cells(12).Value
        correo_cliente = grilla_documento.CurrentRow.Cells(13).Value
        subtotal_doc = grilla_documento.CurrentRow.Cells(14).Value
        porcentaje_desc_doc = grilla_documento.CurrentRow.Cells(15).Value
        descuento_doc = grilla_documento.CurrentRow.Cells(16).Value
        neto_doc = grilla_documento.CurrentRow.Cells(17).Value
        iva_doc = grilla_documento.CurrentRow.Cells(18).Value
        total_doc = grilla_documento.CurrentRow.Cells(19).Value
        rut_vendedor = grilla_documento.CurrentRow.Cells(20).Value
        nombre_vendedor = grilla_documento.CurrentRow.Cells(21).Value
        rut_retira = grilla_documento.CurrentRow.Cells(22).Value
        nombre_retira = grilla_documento.CurrentRow.Cells(23).Value

        impresion_de_documento = "DOCUMENTO"

        If tipo_doc = "BOLETA" Then
            valormensaje = MsgBox("¿DESEA IMPRIMIR ESTE DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
            If valormensaje = vbYes Then

                If estado_boleta_electronica = "NO" Then
                    With Pd.PrinterSettings
                        .PrinterName = impresora_boletas

                        .Copies = 1

                        .PrintRange = PrintRange.AllPages
                        If .IsValid Then
                            lbl_mensaje.Visible = True
                            Me.Enabled = False
                            Me.crear_numero_documento()
                            Me.grabar_factura()


                            Me.Pd.PrintController = New StandardPrintController
                            Me.Pd.DefaultPageSettings.Margins.Left = 10
                            Me.Pd.DefaultPageSettings.Margins.Right = 10

                            If mirutempresa = "81921000-4" Then
                                Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 670)
                                Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                            End If

                            If mirutempresa <> "81921000-4" Then
                                Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 547)
                                Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                            End If

                            Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                            Pd.Print()

                            Me.grabar_detalle_factura()
                            Me.crear_archivo_plano()


                            mostrar_malla()
                            MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                            lbl_mensaje.Visible = False
                            Me.Enabled = True

                            Exit Sub
                        Else
                            MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                            lbl_mensaje.Visible = False
                            Me.Enabled = True
                            Exit Sub
                        End If
                    End With
                Else
                    lbl_mensaje.Visible = True
                    Me.Enabled = False
                    Me.crear_numero_documento()
                    Me.grabar_factura()
                    Me.grabar_detalle_factura()
                    Me.crear_archivo_plano()

                    mostrar_malla()
                    MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    lbl_mensaje.Visible = False
                    Me.Enabled = True
                    Exit Sub
                End If
            End If
            Exit Sub
        End If




        If tipo_doc = "BOLETA DE CREDITO" Then
            valormensaje = MsgBox("¿DESEA IMPRIMIR ESTE DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
            If valormensaje = vbYes Then

                If estado_boleta_electronica = "NO" Then
                    With Pd.PrinterSettings
                        ' Especifico el nombre de la impresora 
                        ' por donde deseo imprimir. 
                        .PrinterName = impresora_boletas
                        ' Establezco el número de copias que se imprimirán 
                        .Copies = 1
                        ' Rango de páginas que se imprimirán 
                        .PrintRange = PrintRange.AllPages
                        If .IsValid Then
                            lbl_mensaje.Visible = True
                            Me.Enabled = False
                            Me.crear_numero_documento()
                            Me.grabar_factura()


                            Me.Pd.PrintController = New StandardPrintController
                            Me.Pd.DefaultPageSettings.Margins.Left = 10
                            Me.Pd.DefaultPageSettings.Margins.Right = 10
                            Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 547)
                            Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1

                            Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                            Pd.Print()

                            Me.grabar_detalle_factura()
                            Me.crear_archivo_plano()

                            mostrar_malla()
                            MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                            lbl_mensaje.Visible = False
                            Me.Enabled = True
                            Exit Sub
                        Else
                            MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                            lbl_mensaje.Visible = False
                            Me.Enabled = True
                            Exit Sub
                        End If
                    End With
                Else
                    lbl_mensaje.Visible = True
                    Me.Enabled = False
                    Me.crear_numero_documento()
                    Me.grabar_factura()
                    Me.grabar_detalle_factura()
                    Me.crear_archivo_plano()

                    If combo_condiciones.Text = "LETRA" Then

                        mostrar_malla()
                        MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        Exit Sub
                    End If
                End If
            End If
        End If





        If tipo_doc = "FACTURA" Then
            valormensaje = MsgBox("¿DESEA IMPRIMIR ESTE DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
            If valormensaje = vbYes Then

                If estado_factura_electronica = "NO" Then
                    With Pd.PrinterSettings
                        ' Especifico el nombre de la impresora 
                        ' por donde deseo imprimir. 
                        .PrinterName = impresora_facturas
                        ' Establezco el número de copias que se imprimirán 
                        .Copies = 1
                        ' Rango de páginas que se imprimirán 
                        .PrintRange = PrintRange.AllPages
                        If .IsValid Then
                            lbl_mensaje.Visible = True
                            Me.Enabled = False
                            Me.crear_numero_documento()
                            Me.grabar_factura()

                            '   .PrinterName = impresora_facturas

                            Me.Pd.PrintController = New StandardPrintController
                            Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 1100)
                            Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                            Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                            Pd.Print()

                            Me.grabar_detalle_factura()
                            Me.crear_archivo_plano()

                            mostrar_malla()
                            MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                            lbl_mensaje.Visible = False
                            Me.Enabled = True
                            Exit Sub
                        Else
                            MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                            lbl_mensaje.Visible = False
                            Me.Enabled = True
                            Exit Sub
                        End If
                    End With
                Else
                    lbl_mensaje.Visible = True
                    Me.Enabled = False
                    Me.crear_numero_documento()
                    Me.grabar_factura()
                    Me.grabar_detalle_factura()
                    Me.crear_archivo_plano()

                    mostrar_malla()
                    MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    lbl_mensaje.Visible = False
                    Me.Enabled = True
                    Exit Sub
                End If
            End If
        End If






        If tipo_doc = "FACTURA DE CREDITO" Then
            valormensaje = MsgBox("¿DESEA IMPRIMIR ESTE DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
            If valormensaje = vbYes Then

                If estado_factura_electronica = "NO" Then
                    With Pd.PrinterSettings
                        ' Especifico el nombre de la impresora 
                        ' por donde deseo imprimir. 
                        .PrinterName = impresora_facturas
                        ' Establezco el número de copias que se imprimirán 
                        .Copies = 1
                        ' Rango de páginas que se imprimirán 
                        .PrintRange = PrintRange.AllPages
                        If .IsValid Then

                            Me.Enabled = False
                            Me.crear_numero_documento()
                            Me.grabar_factura()


                            Me.Pd.PrintController = New StandardPrintController
                            Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 1100)
                            Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                            Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                            Pd.Print()

                            Me.grabar_detalle_factura()
                            Me.crear_archivo_plano()

                            mostrar_malla()
                            MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                            lbl_mensaje.Visible = False
                            Me.Enabled = True
                            Exit Sub
                        Else
                            MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                            lbl_mensaje.Visible = False
                            Me.Enabled = True
                            Exit Sub
                        End If
                    End With
                Else

                    Me.Enabled = False
                    Me.crear_numero_documento()
                    Me.grabar_factura()
                    Me.grabar_detalle_factura()
                    Me.crear_archivo_plano()

                    mostrar_malla()
                    MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    lbl_mensaje.Visible = False
                    Me.Enabled = True
                    Exit Sub
                End If
            End If
        End If





        If tipo_doc = "GUIA" Then
            valormensaje = MsgBox("¿DESEA IMPRIMIR ESTE DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
            If valormensaje = vbYes Then


                If estado_guia_electronica = "NO" Then
                    With Pd.PrinterSettings
                        ' Especifico el nombre de la impresora 
                        ' por donde deseo imprimir. 
                        .PrinterName = impresora_guias
                        ' Establezco el número de copias que se imprimirán 
                        .Copies = 1
                        ' Rango de páginas que se imprimirán 
                        .PrintRange = PrintRange.AllPages
                        If .IsValid Then

                            Me.Enabled = False
                            Me.crear_numero_documento()
                            Me.grabar_factura()


                            Me.Pd.PrintController = New StandardPrintController
                            Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                            Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                            Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                            Pd.Print()


                            Me.grabar_detalle_factura()
                            Me.crear_archivo_plano()

                            mostrar_malla()
                            MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                            lbl_mensaje.Visible = False
                            Me.Enabled = True
                            Exit Sub
                        Else
                            MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                            lbl_mensaje.Visible = False
                            Me.Enabled = True
                            Exit Sub
                        End If
                    End With
                Else

                    Me.Enabled = False
                    Me.crear_numero_documento()
                    Me.grabar_factura()
                    Me.grabar_detalle_factura()
                    Me.crear_archivo_plano()

                    mostrar_malla()
                    MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    lbl_mensaje.Visible = False
                    Me.Enabled = True
                    Exit Sub
                End If
            End If
        End If

    End Sub



    Private Sub btn_grabar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.GotFocus
        btn_grabar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_grabar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.LostFocus
        btn_grabar.BackColor = Color.Transparent
    End Sub


    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_pause_vendedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_pause_vendedor.GotFocus
        btn_pause_vendedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_pause_vendedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_pause_vendedor.LostFocus
        btn_pause_vendedor.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent

    End Sub

    Private Sub btn_play_vendedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_play_vendedor.GotFocus
        btn_play_vendedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_play_vendedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_play_vendedor.LostFocus
        btn_play_vendedor.BackColor = Color.Transparent
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_efectivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_efectivo.KeyPress
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



        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btn_grabar.Focus()
        End If
    End Sub

    Private Sub txt_efectivo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_efectivo.GotFocus
        txt_efectivo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_efectivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_efectivo.LostFocus
        txt_efectivo.BackColor = Color.White
    End Sub

    Private Sub txt_efectivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_efectivo.TextChanged
        calcular_vuelto()
    End Sub

    Sub calcular_vuelto()
        'Dim bono1 As Integer
        'Dim deuda1 As Integer

        'If txt_deuda_actual.Text = "" Then
        '    deuda1 = 0
        'Else
        '    deuda1 = txt_deuda_actual.Text
        'End If



        'If txt_abono.Text = "" Then
        '    bono1 = 0
        'Else
        '    bono1 = txt_abono.Text
        'End If
        'txt_despues.Text = (deuda1) - (bono1)


        If txt_nro_vale.Text = "0" Then
            Exit Sub
        End If

        If txt_nro_vale.Text = "" Then
            Exit Sub
        End If


        If grilla_documento.Rows.Count = 0 Then
            txt_vuelto.Text = "0"
            Exit Sub
        End If

        Dim total As Integer
        Dim vuelto As Long

        total = grilla_documento.CurrentRow.Cells(19).Value

        vuelto = Val(txt_efectivo.Text) - Val(total)


        If vuelto < 0 Then
            txt_vuelto.Text = "0"
        Else
            txt_vuelto.Text = vuelto
        End If




        If txt_vuelto.Text = "" Or txt_vuelto.Text = "0" Then
            txt_vuelto.Text = "0"
        Else
            txt_vuelto.Text = Format(Int(txt_vuelto.Text), "###,###,###")
        End If



    End Sub


    Private Sub grilla_documento_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_documento.CellContentClick

    End Sub
End Class