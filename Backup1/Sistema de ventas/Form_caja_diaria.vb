Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Net.Mail
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports MySql.Data.MySqlClient
Imports System.Resources
Imports System.Deployment.Application

Public Class Form_caja_diaria
    Declare Function SetDefaultPrinter Lib "winspool.drv" Alias "SetDefaultPrinterA" (ByVal pszPrinter As String) As Boolean
    Dim mes_liquidacion As String
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim tipo_impresion As String
    Dim boletas_nulas As String
    Dim guias_nulas As String
    Dim facturas_nulas As String
    Dim nota_credito_nulas As String
    Dim nota_debito_nulas As String
    Dim abono_nulos As String
    Dim message As New MailMessage
    Dim smtp As New SmtpClient
    Dim nombre_archivo As String
    Dim numero_lineas_total As Integer = 0

    Private Sub Form_caja_diaria_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Form_caja_registradora.Visible = False Then
            Form_menu_principal.WindowState = FormWindowState.Maximized
        Else
            Form_caja_registradora.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Form_caja_diaria_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_caja_diaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        'If mirutempresa = "81921000-4" Then
        '    btn_enviar.Enabled = True
        'Else
        '    btn_enviar.Enabled = False
        'End If
        llenar_combo_sucursales()
        llenar_combo_cajas()
        grilla_detalle_caja.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_fecha_caja_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_fecha_caja_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub

    'seleccionamos el valor minimo del documento registrado en la tabla especifica mediante una consulta sql, en donde la fecha sea iguala la de hoy, y lo mostramos en el textbox correspondiente.
    Sub mostrar_minimo_boleta()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        'SC.CommandText = "select min(n_boleta) as n_boleta from boleta where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE' and TIPO <> 'AJUSTE'"
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select min(n_boleta) as n_boleta from boleta where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE' and TIPO <> 'AJUSTE'"
        Else
            SC.CommandText = "select min(n_boleta) as n_boleta from boleta where caja ='" & (Combo_caja.Text) & "' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE' and TIPO <> 'AJUSTE'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_boleta_minimo.Text = DS.Tables(DT.TableName).Rows(0).Item("n_boleta")
            Catch
            End Try
        End If
        conexion.Close()
    End Sub

    'seleccionamos el valor maximo del documento registrado en la tabla especifica mediante una consulta sql, en donde la fecha sea iguala la de hoy, y lo mostramos en el textbox correspondiente.
    Sub mostrar_maximo_boleta()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select max(n_boleta) as n_boleta from boleta where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        Else
            SC.CommandText = "select max(n_boleta) as n_boleta from boleta where caja ='" & (Combo_caja.Text) & "' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_boleta_maximo.Text = DS.Tables(DT.TableName).Rows(0).Item("n_boleta")
            Catch
            End Try
        End If
        conexion.Close()
    End Sub

    'seleccionamos el valor total de los documentos registrados en la tabla especifica mediante una consulta sql sum, en donde la fecha sea igual a la de hoy, y lo mostramos en el textbox correspondiente.
    Sub mostrar_total_boleta()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select sum(total) as total from boleta where estado='EMITIDA' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and condiciones <> 'CREDITO' and (n_boleta) between '" & (txt_boleta_minimo.Text) & "' and '" & (txt_boleta_maximo.Text) & "'"
        Else
            SC.CommandText = "select sum(total) as total from boleta where caja ='" & (Combo_caja.Text) & "' and estado='EMITIDA' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and condiciones <> 'CREDITO' and (n_boleta) between '" & (txt_boleta_minimo.Text) & "' and '" & (txt_boleta_maximo.Text) & "'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_total_boleta_contado.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Catch
            End Try
        End If
        conexion.Close()

        If txt_total_boleta_contado.Text = "" Or txt_total_boleta_contado.Text = "0" Then
            txt_total_boleta_contado_millar.Text = "0"
        Else
            txt_total_boleta_contado_millar.Text = Format(Int(txt_total_boleta_contado.Text), "###,###,###")
        End If
    End Sub

    Sub mostrar_cantidad_nulas()
        '\\\BOLETAS
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select count(n_boleta) as n_boleta from boleta where estado='ANULADA' and estado <> 'AJUSTE' and CONDICIONES <> 'AJUSTE' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_boleta) between '" & (txt_boleta_minimo.Text) & "' and '" & (txt_boleta_maximo.Text) & "'"
        Else
            SC.CommandText = "select count(n_boleta) as n_boleta from boleta where caja ='" & (Combo_caja.Text) & "' and estado='ANULADA' and estado <> 'AJUSTE' and CONDICIONES <> 'AJUSTE' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_boleta) between '" & (txt_boleta_minimo.Text) & "' and '" & (txt_boleta_maximo.Text) & "'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        boletas_nulas = 0
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                boletas_nulas = DS.Tables(DT.TableName).Rows(0).Item("n_boleta")
            Catch
            End Try
        End If
        conexion.Close()

        '\\\factura
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select count(n_factura) as n_factura from factura where estado='ANULADA' and estado <> 'AJUSTE'  and CONDICIONES <> 'AJUSTE' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_factura) between '" & (txt_factura_minimo.Text) & "' and '" & (txt_factura_maximo.Text) & "'"
        Else
            SC.CommandText = "select count(n_factura) as n_factura from factura where caja ='" & (Combo_caja.Text) & "' and estado='ANULADA' and estado <> 'AJUSTE'  and CONDICIONES <> 'AJUSTE' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_factura) between '" & (txt_factura_minimo.Text) & "' and '" & (txt_factura_maximo.Text) & "'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        facturas_nulas = 0
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                facturas_nulas = DS.Tables(DT.TableName).Rows(0).Item("n_factura")
            Catch
            End Try
        End If
        conexion.Close()

        '\\\guias
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select count(n_guia) as n_guia from guia where estado='ANULADA' and estado <> 'AJUSTE'  and CONDICIONES <> 'AJUSTE' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_guia) between '" & (txt_guia_minimo.Text) & "' and '" & (txt_guia_maximo.Text) & "'"
        Else
            SC.CommandText = "select count(n_guia) as n_guia from guia where caja ='" & (Combo_caja.Text) & "' and estado='ANULADA' and estado <> 'AJUSTE'  and CONDICIONES <> 'AJUSTE' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_guia) between '" & (txt_guia_minimo.Text) & "' and '" & (txt_guia_maximo.Text) & "'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        guias_nulas = 0
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                guias_nulas = DS.Tables(DT.TableName).Rows(0).Item("n_guia")
            Catch
            End Try
        End If
        conexion.Close()

        '\\\abono
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select count(n_abono) as n_abono from abono where estado='ANULADA' and estado <> 'AJUSTE'  and CONDICION_ABONO <> 'AJUSTE' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and (n_abono) between '" & (txt_abono_minimo.Text) & "' and '" & (txt_abono_maximo.Text) & "'"
        Else
            SC.CommandText = "select count(n_abono) as n_abono from abono where caja ='" & (Combo_caja.Text) & "' and estado='ANULADA' and estado <> 'AJUSTE'  and CONDICION_ABONO <> 'AJUSTE' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and (n_abono) between '" & (txt_abono_minimo.Text) & "' and '" & (txt_abono_maximo.Text) & "'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        abono_nulos = 0
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                abono_nulos = DS.Tables(DT.TableName).Rows(0).Item("n_abono")
            Catch
            End Try
        End If
        conexion.Close()

        '\\\nota_credito
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select count(n_nota_credito) as n_nota_credito from nota_credito where estado='ANULADA' and estado <> 'AJUSTE'  and CONDICIONES <> 'AJUSTE' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_nota_credito) between '" & (txt_nota_credito_minimo.Text) & "' and '" & (txt_nota_credito_maximo.Text) & "'"
        Else
            SC.CommandText = "select count(n_nota_credito) as n_nota_credito from nota_credito where caja ='" & (Combo_caja.Text) & "' and estado='ANULADA' and estado <> 'AJUSTE'  and CONDICIONES <> 'AJUSTE' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_nota_credito) between '" & (txt_nota_credito_minimo.Text) & "' and '" & (txt_nota_credito_maximo.Text) & "'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        nota_credito_nulas = 0
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                nota_credito_nulas = DS.Tables(DT.TableName).Rows(0).Item("n_nota_credito")
            Catch
            End Try
        End If
        conexion.Close()

        '\\\nota_debito
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select count(n_nota_debito) as n_nota_debito from nota_debito where estado='ANULADA' and estado <> 'AJUSTE'  and CONDICIONES <> 'AJUSTE' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_nota_debito) between '" & (txt_nota_debito_minimo.Text) & "' and '" & (txt_nota_debito_maximo.Text) & "'"
        Else
            SC.CommandText = "select count(n_nota_debito) as n_nota_debito from nota_debito where caja ='" & (Combo_caja.Text) & "' and estado='ANULADA' and estado <> 'AJUSTE'  and CONDICIONES <> 'AJUSTE' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_nota_debito) between '" & (txt_nota_debito_minimo.Text) & "' and '" & (txt_nota_debito_maximo.Text) & "'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        nota_debito_nulas = 0
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                nota_debito_nulas = DS.Tables(DT.TableName).Rows(0).Item("n_nota_debito")
            Catch
            End Try
        End If
        conexion.Close()
    End Sub

    'Sub mostrar_cantidad_emitidas()
    '    ''\\\BOLETAS
    '    'conexion.Close()
    '    'DS.Tables.Clear()
    '    'DT.Rows.Clear()
    '    'DT.Columns.Clear()
    '    'DS.Clear()
    '    'conexion.Open()
    '    'SC.Connection = conexion
    '    'If Combo_caja.Text = "TODAS" Then
    '    '    SC.CommandText = "select count(n_boleta) as n_boleta from boleta where estado <>'ANULADA' and estado <> 'AJUSTE' and CONDICIONES <> 'AJUSTE' and TIPO <> 'AJUSTE' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_boleta) between '" & (txt_boleta_minimo.Text) & "' and '" & (txt_boleta_maximo.Text) & "'"
    '    'Else
    '    '    SC.CommandText = "select count(n_boleta) as n_boleta from boleta where caja ='" & (Combo_caja.Text) & "' and estado <>'ANULADA' and estado <> 'AJUSTE' and CONDICIONES <> 'AJUSTE' and TIPO <> 'AJUSTE' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_boleta) between '" & (txt_boleta_minimo.Text) & "' and '" & (txt_boleta_maximo.Text) & "'"
    '    'End If
    '    'DA.SelectCommand = SC
    '    'DA.Fill(DT)
    '    'DS.Tables.Add(DT)
    '    'txt_cantidad_boletas_anuladas.Text = 0
    '    'If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '    '    Try
    '    '        txt_cantidad_boletas_emitidas.Text = DS.Tables(DT.TableName).Rows(0).Item("n_boleta") + 1
    '    '    Catch
    '    '    End Try
    '    'End If
    '    'conexion.Close()
    'End Sub

    Sub mostrar_total_boleta_credito()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select sum(total) as total from boleta where estado='EMITIDA' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND CONDICIONES ='CREDITO'  and (n_boleta) between '" & (txt_boleta_minimo.Text) & "' and '" & (txt_boleta_maximo.Text) & "'"
        Else
            SC.CommandText = "select sum(total) as total from boleta where caja ='" & (Combo_caja.Text) & "' and estado='EMITIDA' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND CONDICIONES ='CREDITO'  and (n_boleta) between '" & (txt_boleta_minimo.Text) & "' and '" & (txt_boleta_maximo.Text) & "'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_total_boleta_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Catch
            End Try
        End If
        conexion.Close()
        If txt_total_boleta_credito.Text = "" Or txt_total_boleta_credito.Text = "0" Then
            txt_total_boleta_credito_millar.Text = "0"
        Else
            txt_total_boleta_credito_millar.Text = Format(Int(txt_total_boleta_credito.Text), "###,###,###")
        End If
    End Sub

    'seleccionamos el valor total de los documentos registrados en la tabla especifica mediante una consulta sql sum, en donde la fecha sea igual a la de hoy, y lo mostramos en el textbox correspondiente.
    Sub mostrar_total_factura_credito()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select sum(total) as total from factura where estado='EMITIDA' and condiciones='CREDITO' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "'  and (n_factura) between '" & (txt_factura_minimo.Text) & "' and '" & (txt_factura_maximo.Text) & "'"
        Else
            SC.CommandText = "select sum(total) as total from factura where caja ='" & (Combo_caja.Text) & "' and estado='EMITIDA' and condiciones='CREDITO' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "'  and (n_factura) between '" & (txt_factura_minimo.Text) & "' and '" & (txt_factura_maximo.Text) & "'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_total_factura_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Catch
            End Try
        End If
        conexion.Close()
        If txt_total_factura_credito.Text = "" Or txt_total_factura_credito.Text = "0" Then
            txt_total_factura_credito_millar.Text = "0"
        Else
            txt_total_factura_credito_millar.Text = Format(Int(txt_total_factura_credito.Text), "###,###,###")
        End If
    End Sub

    'seleccionamos el valor minimo del documento registrado en la tabla especifica mediante una consulta sql, en donde la fecha sea iguala la de hoy, y lo mostramos en el textbox correspondiente.
    Sub mostrar_minimo_factura_contado()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select min(n_factura) as n_factura from factura where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        Else
            SC.CommandText = "select min(n_factura) as n_factura from factura where caja ='" & (Combo_caja.Text) & "' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_factura_minimo.Text = DS.Tables(DT.TableName).Rows(0).Item("n_factura")
            Catch
            End Try
        End If
        conexion.Close()
    End Sub

    'seleccionamos el valor maximo del documento registrado en la tabla especifica mediante una consulta sql, en donde la fecha sea iguala la de hoy, y lo mostramos en el textbox correspondiente.
    Sub mostrar_maximo_factura_contado()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select max(n_factura) as n_factura from factura where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        Else
            SC.CommandText = "select max(n_factura) as n_factura from factura where caja ='" & (Combo_caja.Text) & "' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_factura_maximo.Text = DS.Tables(DT.TableName).Rows(0).Item("n_factura")
            Catch
            End Try
        End If
        conexion.Close()
    End Sub

    'seleccionamos el valor total de los documentos registrados en la tabla especifica mediante una consulta sql sum, en donde la fecha sea igual a la de hoy, y lo mostramos en el textbox correspondiente.
    Sub mostrar_total_factura_contado()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select sum(total) as total from factura where estado='EMITIDA'  and condiciones <> 'CREDITO'  and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "'  and (n_factura) between '" & (txt_factura_minimo.Text) & "' and '" & (txt_factura_maximo.Text) & "'"
        Else
            SC.CommandText = "select sum(total) as total from factura where caja ='" & (Combo_caja.Text) & "' and estado='EMITIDA'  and condiciones <> 'CREDITO'  and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "'  and (n_factura) between '" & (txt_factura_minimo.Text) & "' and '" & (txt_factura_maximo.Text) & "'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_total_factura_contado.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Catch
            End Try
        End If
        conexion.Close()
        If txt_total_factura_contado.Text = "" Or txt_total_factura_contado.Text = "0" Then
            txt_total_factura_contado_millar.Text = "0"
        Else
            txt_total_factura_contado_millar.Text = Format(Int(txt_total_factura_contado.Text), "###,###,###")
        End If
    End Sub

    'seleccionamos el valor minimo del documento registrado en la tabla especifica mediante una consulta sql, en donde la fecha sea iguala la de hoy, y lo mostramos en el textbox correspondiente.
    Sub mostrar_minimo_guia()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select min(n_guia) as n_guia from guia where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        Else
            SC.CommandText = "select min(n_guia) as n_guia from guia where caja ='" & (Combo_caja.Text) & "' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_guia_minimo.Text = DS.Tables(DT.TableName).Rows(0).Item("n_guia")
            Catch
            End Try
        Else
            txt_guia_minimo.Text = "0"
        End If
        conexion.Close()
    End Sub

    'seleccionamos el valor maximo del documento registrado en la tabla especifica mediante una consulta sql, en donde la fecha sea iguala la de hoy, y lo mostramos en el textbox correspondiente.
    Sub mostrar_maximo_guia()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select max(n_guia) as n_guia from guia where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        Else
            SC.CommandText = "select max(n_guia) as n_guia from guia where caja ='" & (Combo_caja.Text) & "' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_guia_maximo.Text = DS.Tables(DT.TableName).Rows(0).Item("n_guia")
            Catch
            End Try
        Else
            txt_guia_maximo.Text = "0"
        End If
        conexion.Close()
    End Sub

    'seleccionamos el valor total de los documentos registrados en la tabla especifica mediante una consulta sql sum, en donde la fecha sea igual a la de hoy, y lo mostramos en el textbox correspondiente.
    Sub mostrar_total_guia_credito()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select sum(total) as total from guia where estado='SIN FACTURAR' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_guia) between '" & (txt_guia_minimo.Text) & "' and '" & (txt_guia_maximo.Text) & "' AND CONDICIONES <> 'TRASLADO' AND CONDICIONES = 'CREDITO'"
        Else
            SC.CommandText = "select sum(total) as total from guia where caja ='" & (Combo_caja.Text) & "' and estado='SIN FACTURAR' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_guia) between '" & (txt_guia_minimo.Text) & "' and '" & (txt_guia_maximo.Text) & "' AND CONDICIONES <> 'TRASLADO' AND CONDICIONES = 'CREDITO'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_total_guia_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Catch
            End Try
        End If
        conexion.Close()

        If txt_total_guia_credito.Text = "" Or txt_total_guia_credito.Text = "0" Then
            txt_total_guia_credito_millar.Text = "0"
        Else
            txt_total_guia_credito_millar.Text = Format(Int(txt_total_guia_credito.Text), "###,###,###")
        End If
    End Sub

    Sub mostrar_total_guia_contado()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select sum(total) as total from guia where estado='SIN FACTURAR' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_guia) between '" & (txt_guia_minimo.Text) & "' and '" & (txt_guia_maximo.Text) & "' AND CONDICIONES <> 'TRASLADO' AND CONDICIONES <> 'CREDITO'"
        Else
            SC.CommandText = "select sum(total) as total from guia where caja ='" & (Combo_caja.Text) & "' and estado='SIN FACTURAR' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_guia) between '" & (txt_guia_minimo.Text) & "' and '" & (txt_guia_maximo.Text) & "' AND CONDICIONES <> 'TRASLADO' AND CONDICIONES <> 'CREDITO'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_total_guia_contado.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Catch
            End Try
        End If
        conexion.Close()
        If txt_total_guia_contado.Text = "" Or txt_total_guia_contado.Text = "0" Then
            txt_total_guia_contado_millar.Text = "0"
        Else
            txt_total_guia_contado_millar.Text = Format(Int(txt_total_guia_contado.Text), "###,###,###")
        End If
    End Sub

    'seleccionamos el valor minimo del documento registrado en la tabla especifica mediante una consulta sql, en donde la fecha sea iguala la de hoy, y lo mostramos en el textbox correspondiente.
    Sub mostrar_minimo_nota_credito()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select min(n_nota_credito) as n_nota_credito from nota_credito where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        Else
            SC.CommandText = "select min(n_nota_credito) as n_nota_credito from nota_credito where caja ='" & (Combo_caja.Text) & "' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_nota_credito_minimo.Text = DS.Tables(DT.TableName).Rows(0).Item("n_nota_credito")
            Catch
            End Try
        Else
            txt_nota_credito_minimo.Text = "0"
        End If
        conexion.Close()
    End Sub

    Sub mostrar_minimo_nota_debito()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select min(n_nota_debito) as n_nota_debito from nota_debito where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        Else
            SC.CommandText = "select min(n_nota_debito) as n_nota_debito from nota_debito where caja ='" & (Combo_caja.Text) & "' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_nota_debito_minimo.Text = DS.Tables(DT.TableName).Rows(0).Item("n_nota_debito")
            Catch
            End Try
        Else
            txt_nota_debito_minimo.Text = "0"
        End If
        conexion.Close()
    End Sub

    'seleccionamos el valor maximo del documento registrado en la tabla especifica mediante una consulta sql, en donde la fecha sea iguala la de hoy, y lo mostramos en el textbox correspondiente.
    Sub mostrar_maximo_nota_credito()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select max(n_nota_credito) as n_nota_credito from nota_credito where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        Else
            SC.CommandText = "select max(n_nota_credito) as n_nota_credito from nota_credito where caja ='" & (Combo_caja.Text) & "' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_nota_credito_maximo.Text = DS.Tables(DT.TableName).Rows(0).Item("n_nota_credito")
            Catch
            End Try
        Else
            txt_nota_credito_maximo.Text = "0"
        End If
        conexion.Close()
    End Sub

    'seleccionamos el valor total de los documentos registrados en la tabla especifica mediante una consulta sql sum, en donde la fecha sea igual a la de hoy, y lo mostramos en el textbox correspondiente.
    Sub mostrar_total_nota_credito()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select sum(total) as total from nota_credito where estado='EMITIDA' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and condiciones <> 'CREDITO' and  (n_nota_credito) between '" & (txt_nota_credito_minimo.Text) & "' and '" & (txt_nota_credito_maximo.Text) & "' "
        Else
            SC.CommandText = "select sum(total) as total from nota_credito where caja ='" & (Combo_caja.Text) & "' and estado='EMITIDA' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and condiciones <> 'CREDITO' and  (n_nota_credito) between '" & (txt_nota_credito_minimo.Text) & "' and '" & (txt_nota_credito_maximo.Text) & "' "
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_total_nota_credito_contado.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Catch
            End Try
        End If
        conexion.Close()
        If txt_total_nota_credito_contado.Text = "" Or txt_total_nota_credito_contado.Text = "0" Then
            txt_total_nota_credito_millar.Text = "0"
        Else
            txt_total_nota_credito_millar.Text = Format(Int(txt_total_nota_credito_contado.Text), "###,###,###")
        End If
    End Sub

    Sub mostrar_total_nota_credito_credito()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select sum(total) as total from nota_credito where estado='EMITIDA' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and condiciones = 'CREDITO' and  (n_nota_credito) between '" & (txt_nota_credito_minimo.Text) & "' and '" & (txt_nota_credito_maximo.Text) & "' "
        Else
            SC.CommandText = "select sum(total) as total from nota_credito where caja ='" & (Combo_caja.Text) & "' and estado='EMITIDA' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and condiciones = 'CREDITO' and  (n_nota_credito) between '" & (txt_nota_credito_minimo.Text) & "' and '" & (txt_nota_credito_maximo.Text) & "' "
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_total_nota_credito_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Catch
            End Try
        End If
        conexion.Close()
        If txt_total_nota_credito_credito.Text = "" Or txt_total_nota_credito_credito.Text = "0" Then
            txt_total_nota_credito_credito_millar.Text = "0"
        Else
            txt_total_nota_credito_credito_millar.Text = Format(Int(txt_total_nota_credito_credito.Text), "###,###,###")
        End If
    End Sub

    Sub mostrar_total_nota_debito()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select sum(total) as total from nota_debito where estado='EMITIDA'  and condiciones <> 'CREDITO' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_nota_debito) between '" & (txt_nota_debito_minimo.Text) & "' and '" & (txt_nota_debito_maximo.Text) & "' "
        Else
            SC.CommandText = "select sum(total) as total from nota_debito where caja ='" & (Combo_caja.Text) & "' and estado='EMITIDA'  and condiciones <> 'CREDITO' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_nota_debito) between '" & (txt_nota_debito_minimo.Text) & "' and '" & (txt_nota_debito_maximo.Text) & "' "
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_total_nota_debito_contado.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Catch
            End Try
        End If
        conexion.Close()

        If txt_total_nota_debito_contado.Text = "" Or txt_total_nota_debito_contado.Text = "0" Then
            txt_total_nota_debito_millar.Text = "0"
        Else
            txt_total_nota_debito_millar.Text = Format(Int(txt_total_nota_debito_contado.Text), "###,###,###")
        End If
    End Sub

    Sub mostrar_total_nota_debito_credito()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select sum(total) as total from nota_debito where estado='EMITIDA'  and condiciones = 'CREDITO' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_nota_debito) between '" & (txt_nota_debito_minimo.Text) & "' and '" & (txt_nota_debito_maximo.Text) & "' "
        Else
            SC.CommandText = "select sum(total) as total from nota_debito where caja ='" & (Combo_caja.Text) & "' and estado='EMITIDA'  and condiciones = 'CREDITO' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and (n_nota_debito) between '" & (txt_nota_debito_minimo.Text) & "' and '" & (txt_nota_debito_maximo.Text) & "' "
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_total_nota_debito_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Catch
            End Try
        End If
        conexion.Close()
        If txt_total_nota_debito_credito.Text = "" Or txt_total_nota_debito_credito.Text = "0" Then
            txt_total_nota_debito_credito_millar.Text = "0"
        Else
            txt_total_nota_debito_credito_millar.Text = Format(Int(txt_total_nota_debito_credito.Text), "###,###,###")
        End If
    End Sub

    Sub mostrar_maximo_nota_debito()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select max(n_nota_debito) as n_nota_debito from nota_debito where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        Else
            SC.CommandText = "select max(n_nota_debito) as n_nota_debito from nota_debito where caja ='" & (Combo_caja.Text) & "' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_nota_debito_maximo.Text = DS.Tables(DT.TableName).Rows(0).Item("n_nota_debito")
            Catch
            End Try
        Else
            txt_nota_debito_maximo.Text = "0"
        End If
        conexion.Close()
    End Sub

    'seleccionamos el valor minimo del documento registrado en la tabla especifica mediante una consulta sql, en donde la fecha sea iguala la de hoy, y lo mostramos en el textbox correspondiente.
    Sub mostrar_minimo_abono()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select min(n_abono) as n_abono from abono where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        Else
            SC.CommandText = "select min(n_abono) as n_abono from abono where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_abono_minimo.Text = DS.Tables(DT.TableName).Rows(0).Item("n_abono")
            Catch
            End Try
        Else
            txt_abono_minimo.Text = "0"
        End If
        conexion.Close()
    End Sub

    'seleccionamos el valor maximo del documento registrado en la tabla especifica mediante una consulta sql, en donde la fecha sea iguala la de hoy, y lo mostramos en el textbox correspondiente.
    Sub mostrar_maximo_abono()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select max(n_abono) as n_abono from abono where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        Else
            SC.CommandText = "select max(n_abono) as n_abono from abono where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and TIPO <> 'AJUSTE'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_abono_maximo.Text = DS.Tables(DT.TableName).Rows(0).Item("n_abono")
            Catch
            End Try
        Else
            txt_abono_maximo.Text = "0"
        End If
        conexion.Close()
    End Sub

    'seleccionamos el valor total de los documentos registrados en la tabla especifica mediante una consulta sql sum, en donde la fecha sea igual a la de hoy, y lo mostramos en el textbox correspondiente.
    Sub mostrar_total_abono_contado()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select sum(monto_abono) as monto_abono from abono where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and (n_abono) between '" & (txt_abono_minimo.Text) & "' and '" & (txt_abono_maximo.Text) & "' and condicion_abono <> 'CREDITO'"
        Else
            SC.CommandText = "select sum(monto_abono) as monto_abono from abono where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and (n_abono) between '" & (txt_abono_minimo.Text) & "' and '" & (txt_abono_maximo.Text) & "' and condicion_abono <> 'CREDITO'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_total_abono_contado.Text = DS.Tables(DT.TableName).Rows(0).Item("monto_abono")
            Catch
            End Try
        End If
        conexion.Close()
        If txt_total_abono_contado.Text = "" Or txt_total_abono_contado.Text = "0" Then
            txt_total_abono_contado_millar.Text = "0"
        Else
            txt_total_abono_contado_millar.Text = Format(Int(txt_total_abono_contado.Text), "###,###,###")
        End If
    End Sub

    Sub mostrar_total_abono_credito()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select sum(monto_abono) as monto_abono from abono where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and (n_abono) between '" & (txt_abono_minimo.Text) & "' and '" & (txt_abono_maximo.Text) & "' and condicion_abono = 'CREDITO'"
        Else
            SC.CommandText = "select sum(monto_abono) as monto_abono from abono where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and (n_abono) between '" & (txt_abono_minimo.Text) & "' and '" & (txt_abono_maximo.Text) & "' and condicion_abono = 'CREDITO'"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Try
                txt_total_abono_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("monto_abono")
            Catch
            End Try
        End If
        conexion.Close()
        If txt_total_abono_credito.Text = "" Or txt_total_abono_credito.Text = "0" Then
            txt_total_abono_credito_millar.Text = "0"
        Else
            txt_total_abono_credito_millar.Text = Format(Int(txt_total_abono_credito.Text), "###,###,###")
        End If
    End Sub

    'seleccionamomos los totales de los documentos y los sumamos dependiendo si son de contado o credito para mostrarlos mediante textbox.
    Sub calcular_totales_credito_contado()
        '//Calcular el total contado
        txt_total_contado.Text = 0
        txt_total_contado.Text = Val(txt_total_boleta_contado.Text) + Val(txt_total_factura_contado.Text) + Val(txt_total_abono_contado.Text) - Val(txt_total_nota_credito_contado.Text) + Val(txt_total_nota_debito_contado.Text) + Val(txt_total_guia_contado.Text)

        If txt_total_contado.Text = "" Or txt_total_contado.Text = "0" Then
            txt_total_contado_millar.Text = "0"
        Else
            txt_total_contado_millar.Text = Format(Int(txt_total_contado.Text), "###,###,###")
        End If

        '//Calcular el total credito
        txt_total_credito.Text = 0
        txt_total_credito.Text = Val(txt_total_guia_credito.Text) + Val(txt_total_factura_credito.Text) + Val(txt_total_boleta_credito.Text) - Val(txt_total_nota_credito_credito.Text) + Val(txt_total_nota_debito_credito.Text) + Val(txt_total_abono_credito.Text)

        If txt_total_credito.Text = "" Or txt_total_credito.Text = "0" Then
            txt_total_credito_millar.Text = "0"
        Else
            txt_total_credito_millar.Text = Format(Int(txt_total_credito.Text), "###,###,###")
        End If
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    'limpiamos los texbox.
    Sub limpiar()
        For Each cntrl As Control In Me.Controls
            If (TypeOf (cntrl) Is GroupBox) Then ' Verifico que el control sea un textbox
                For Each myControl In cntrl.Controls

                    If (TypeOf (myControl) Is TextBox) Then ' Verifico que el control sea un textbox
                        CType(myControl, TextBox).Text = "" ' Le cambio el valor a la propiedad
                    End If

                    If (TypeOf (myControl) Is DataGridView) Then ' Verifico que el control sea un textbox
                        CType(myControl, DataGridView).Rows.Clear() ' Le cambio el valor a la propiedad
                    End If

                Next
            End If
        Next

        For Each myControl As Control In Me.Controls
            If (TypeOf (myControl) Is TextBox) Then ' Verifico que el control sea un textbox
                CType(myControl, TextBox).Text = "" ' Le cambio el valor a la propiedad
            End If

            If (TypeOf (myControl) Is DataGridView) Then ' Verifico que el control sea un textbox
                CType(myControl, DataGridView).Rows.Clear() ' Le cambio el valor a la propiedad
            End If
        Next
    End Sub

    Sub limpiar_fuera()
        'For Each myControl As Control In Me.Controls
        '    If (TypeOf (myControl) Is TextBox) Then ' Verifico que el control sea un textbox
        '        CType(myControl, TextBox).Text = "" ' Le cambio el valor a la propiedad
        '    End If

        '    If (TypeOf (myControl) Is DataGridView) Then ' Verifico que el control sea un textbox
        '        CType(myControl, DataGridView).Rows.Clear() ' Le cambio el valor a la propiedad
        '    End If
        'Next
    End Sub

    'llamamos los sub para sacar los valores mnimos, maximos y totales.
    Private Sub dtp1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha_caja_desde.ValueChanged
        limpiar()
    End Sub

    'guardamos la informacion en la tabla de caja diaria y mandamos a imprimir el documento.
    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        tipo_impresion = "FORMAL"

        For Each cntrl As Control In Me.Controls
            If (TypeOf (cntrl) Is GroupBox) Then ' Verifico que el control sea un textbox
                For Each myControl In cntrl.Controls
                    If (TypeOf (myControl) Is TextBox) Then ' Verifico que el control sea un textbox
                        If CType(myControl, TextBox).Text = "" Then
                            CType(myControl, TextBox).Text = "0"
                        End If
                        ' Le cambio el valor a la propiedad
                    End If
                Next
            End If
        Next

        For Each myControl As Control In Me.Controls
            If (TypeOf (myControl) Is TextBox) Then ' Verifico que el control sea un textbox
                If CType(myControl, TextBox).Text = "" Then
                    CType(myControl, TextBox).Text = "0"
                End If
                ' Le cambio el valor a la propiedad
            End If
        Next

        lbl_mensaje.Visible = True
        Me.Enabled = False

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

        'Try
        '    Dim iReporte As New VisorReporte

        '    Dim rpt As New Crystal_caja_uno

        '    rpt.Load()
        '    rpt.SetDataSource(ReturnDataSet)
        '    rpt.Refresh()

        '    iReporte.Reporte = rpt
        '    iReporte.ShowDialog()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        limpiar()
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        btn_imprimir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_ticket_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ticket.GotFocus
        btn_ticket.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_ticket_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ticket.LostFocus
        btn_ticket.BackColor = Color.Transparent
    End Sub

    Private Sub btn_mostrar_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_calcular_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_calcular.GotFocus
        btn_calcular.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_calcular_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_calcular.LostFocus
        btn_calcular.BackColor = Color.Transparent
    End Sub

    Private Sub btn_detalle_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_detalle.GotFocus
        btn_detalle.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_detalle_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_detalle.LostFocus
        btn_detalle.BackColor = Color.Transparent
    End Sub

    Sub fecha_caja()
        If dtp_fecha_caja_desde.Value.Month() = "01" Then
            mes_liquidacion = "ENERO"
        End If

        If dtp_fecha_caja_desde.Value.Month() = "02" Then
            mes_liquidacion = "FEBRERO"
        End If

        If dtp_fecha_caja_desde.Value.Month() = "03" Then
            mes_liquidacion = "MARZO"
        End If

        If dtp_fecha_caja_desde.Value.Month() = "04" Then
            mes_liquidacion = "ABRIL"
        End If

        If dtp_fecha_caja_desde.Value.Month() = "05" Then
            mes_liquidacion = "MAYO"
        End If

        If dtp_fecha_caja_desde.Value.Month() = "06" Then
            mes_liquidacion = "JUNIO"
        End If

        If dtp_fecha_caja_desde.Value.Month() = "07" Then
            mes_liquidacion = "JULIO"
        End If

        If dtp_fecha_caja_desde.Value.Month() = "08" Then
            mes_liquidacion = "AGOSTO"
        End If

        If dtp_fecha_caja_desde.Value.Month() = "09" Then
            mes_liquidacion = "SEPTIEMBRE"
        End If

        If dtp_fecha_caja_desde.Value.Month() = "10" Then
            mes_liquidacion = "OCTUBRE"
        End If

        If dtp_fecha_caja_desde.Value.Month() = "11" Then
            mes_liquidacion = "NOVIEMBRE"
        End If

        If dtp_fecha_caja_desde.Value.Month() = "12" Then
            mes_liquidacion = "DICIEMBRE"
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        fecha_caja()

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font0 As New Font("verdana", 8, FontStyle.Regular)
        Dim Font1 As New Font("arial", 9, FontStyle.Regular)
        Dim Font2 As New Font("arial", 10, FontStyle.Regular)
        Dim Font3 As New Font("arial", 12, FontStyle.Regular)
        Dim Font4 As New Font("arial", 14, FontStyle.Bold)
        Dim Font6 As New Font("arial", 9, FontStyle.Bold)
        Dim rect1 As New Rectangle(50, 30, 800, 50)
        Dim rect2 As New Rectangle(50, 60, 800, 50)
        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        e.Graphics.DrawString("CUADRATURA DE CAJA " & "(" & mirecintoempresa & ")", Font3, Brushes.Black, rect1, stringFormat)
        ' e.Graphics.DrawString(dtp_fecha_caja_desde.Value.Day & " DE " & mes_liquidacion & " DE " & dtp_fecha_caja_desde.Value.Year, Font1, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString("DESDE " & dtp_fecha_caja_desde.Text & " HASTA " & dtp_fecha_caja_hasta.Text, Font1, Brushes.Black, rect2, stringFormat)
        Dim logo_empresa As String
        Dim im As Image
        Try
            logo_empresa = "C:\Sistema de ventas\Logo de empresa\" & minombreempresa & ".png"
            im = Image.FromFile(logo_empresa)
            Dim p As New PointF(460, 42)
            e.Graphics.DrawImage(im, p)
        Catch
        End Try

        'linea
        e.Graphics.DrawLine(Pens.Black, 50, 115, 800, 115)
        e.Graphics.DrawString("DOCUMENTO", Font6, Brushes.Black, 83, 127)
        e.Graphics.DrawString("DESDE", Font6, Brushes.Black, 235, 127)
        e.Graphics.DrawString("HASTA", Font6, Brushes.Black, 355, 127)
        e.Graphics.DrawString("CONTADO", Font6, Brushes.Black, 465, 127)
        e.Graphics.DrawString("CREDITO", Font6, Brushes.Black, 590, 127)
        e.Graphics.DrawString("DOC. NULOS", Font6, Brushes.Black, 697, 127)
        'linea
        e.Graphics.DrawLine(Pens.Black, 50, 150, 800, 150)
        e.Graphics.DrawString("BOLETAS", Font1, Brushes.Black, 60, 160)
        e.Graphics.DrawString(txt_boleta_minimo.Text, Font1, Brushes.Black, 310, 160, format1)
        e.Graphics.DrawString(txt_boleta_maximo.Text, Font1, Brushes.Black, 430, 160, format1)
        e.Graphics.DrawString(txt_total_boleta_contado_millar.Text, Font1, Brushes.Black, 550, 160, format1)
        e.Graphics.DrawString(txt_total_boleta_credito_millar.Text, Font1, Brushes.Black, 670, 160, format1)
        e.Graphics.DrawString(boletas_nulas, Font1, Brushes.Black, 790, 160, format1)
        e.Graphics.DrawString("FACTURAS", Font1, Brushes.Black, 60, 180)
        e.Graphics.DrawString(txt_factura_minimo.Text, Font1, Brushes.Black, 310, 180, format1)
        e.Graphics.DrawString(txt_factura_maximo.Text, Font1, Brushes.Black, 430, 180, format1)
        e.Graphics.DrawString(txt_total_factura_contado_millar.Text, Font1, Brushes.Black, 550, 180, format1)
        e.Graphics.DrawString(txt_total_factura_credito_millar.Text, Font1, Brushes.Black, 670, 180, format1)
        e.Graphics.DrawString(facturas_nulas, Font1, Brushes.Black, 790, 180, format1)
        e.Graphics.DrawString("GUIAS", Font1, Brushes.Black, 60, 200)
        e.Graphics.DrawString(txt_guia_minimo.Text, Font1, Brushes.Black, 310, 200, format1)
        e.Graphics.DrawString(txt_guia_maximo.Text, Font1, Brushes.Black, 430, 200, format1)
        e.Graphics.DrawString("0", Font1, Brushes.Black, 550, 200, format1)
        e.Graphics.DrawString(txt_total_guia_credito_millar.Text, Font1, Brushes.Black, 670, 200, format1)
        e.Graphics.DrawString(guias_nulas, Font1, Brushes.Black, 790, 200, format1)
        e.Graphics.DrawString("ABONOS", Font1, Brushes.Black, 60, 220)
        e.Graphics.DrawString(txt_abono_minimo.Text, Font1, Brushes.Black, 310, 220, format1)
        e.Graphics.DrawString(txt_abono_maximo.Text, Font1, Brushes.Black, 430, 220, format1)
        e.Graphics.DrawString(txt_total_abono_contado_millar.Text, Font1, Brushes.Black, 550, 220, format1)
        e.Graphics.DrawString("0", Font1, Brushes.Black, 670, 220, format1)
        e.Graphics.DrawString(abono_nulos, Font1, Brushes.Black, 790, 220, format1)
        e.Graphics.DrawString("NOTAS DE CREDITO", Font1, Brushes.Black, 60, 240)
        e.Graphics.DrawString(txt_nota_credito_minimo.Text, Font1, Brushes.Black, 310, 240, format1)
        e.Graphics.DrawString(txt_nota_credito_maximo.Text, Font1, Brushes.Black, 430, 240, format1)
        e.Graphics.DrawString(txt_total_nota_credito_millar.Text, Font1, Brushes.Black, 550, 240, format1)
        e.Graphics.DrawString(txt_total_nota_credito_credito_millar.Text, Font1, Brushes.Black, 670, 240, format1)
        e.Graphics.DrawString(nota_credito_nulas, Font1, Brushes.Black, 790, 240, format1)
        e.Graphics.DrawString("NOTAS DE DEBITO", Font1, Brushes.Black, 60, 260)
        e.Graphics.DrawString(txt_nota_debito_minimo.Text, Font1, Brushes.Black, 310, 260, format1)
        e.Graphics.DrawString(txt_nota_debito_maximo.Text, Font1, Brushes.Black, 430, 260, format1)
        e.Graphics.DrawString(txt_total_nota_debito_millar.Text, Font1, Brushes.Black, 550, 260, format1)
        e.Graphics.DrawString(txt_total_nota_debito_credito_millar.Text, Font1, Brushes.Black, 670, 260, format1)
        e.Graphics.DrawString(nota_debito_nulas, Font1, Brushes.Black, 790, 260, format1)
        e.Graphics.DrawLine(Pens.Black, 50, 285, 800, 285)
        e.Graphics.DrawLine(Pens.Black, 50, 320, 800, 320)
        e.Graphics.DrawLine(Pens.Black, 50, 115, 50, 320)
        e.Graphics.DrawString("TOTAL", Font6, Brushes.Black, 380, 295)
        e.Graphics.DrawString(txt_total_contado.Text, Font6, Brushes.Black, 550, 295, format1)
        e.Graphics.DrawString(txt_total_credito.Text, Font6, Brushes.Black, 670, 295, format1)

        Dim total_nulos As String
        total_nulos = Val(txt_cantidad_boletas_anuladas.Text) + Val(txt_cantidad_facturas_anuladas.Text) + Val(txt_cantidad_guias_anuladas.Text) + Val(txt_cantidad_abonos_anuladas.Text) + Val(txt_cantidad_notas_credito_anuladas.Text) + Val(txt_cantidad_notas_debito_anuladas.Text)

        e.Graphics.DrawString(total_nulos, Font6, Brushes.Black, 790, 295, format1)
        e.Graphics.DrawLine(Pens.Black, 200, 115, 200, 285)
        e.Graphics.DrawLine(Pens.Black, 320, 115, 320, 285)
        e.Graphics.DrawLine(Pens.Black, 440, 115, 440, 320)
        e.Graphics.DrawLine(Pens.Black, 560, 115, 560, 320)
        e.Graphics.DrawLine(Pens.Black, 680, 115, 680, 320)
        e.Graphics.DrawLine(Pens.Black, 800, 115, 800, 320)
    End Sub

    Private Sub btn_calcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_calcular.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        If txt_abono_minimo.Text = "" Then
            txt_abono_minimo.Text = "0"
            txt_abono_maximo.Text = "0"
        End If
        If txt_boleta_minimo.Text = "" Then
            txt_boleta_minimo.Text = "0"
            txt_boleta_maximo.Text = "0"
        End If

        If txt_factura_minimo.Text = "" Then
            txt_factura_minimo.Text = "0"
            txt_factura_maximo.Text = "0"
        End If

        If txt_guia_minimo.Text = "" Then
            txt_guia_minimo.Text = "0"
            txt_guia_maximo.Text = "0"
        End If

        If txt_nota_credito_minimo.Text = "" Then
            txt_nota_credito_minimo.Text = "0"
            txt_nota_credito_maximo.Text = "0"
        End If

        If txt_nota_debito_minimo.Text = "" Then
            txt_nota_debito_minimo.Text = "0"
            txt_nota_debito_maximo.Text = "0"
        End If

        If txt_abono_maximo.Text = "" Then
            txt_abono_minimo.Text = "0"
            txt_abono_maximo.Text = "0"
        End If
        If txt_boleta_maximo.Text = "" Then
            txt_boleta_minimo.Text = "0"
            txt_boleta_maximo.Text = "0"
        End If

        If txt_factura_maximo.Text = "" Then
            txt_factura_minimo.Text = "0"
            txt_factura_maximo.Text = "0"
        End If

        If txt_guia_maximo.Text = "" Then
            txt_guia_minimo.Text = "0"
            txt_guia_maximo.Text = "0"
        End If

        If txt_nota_credito_maximo.Text = "" Then
            txt_nota_credito_minimo.Text = "0"
            txt_nota_credito_maximo.Text = "0"
        End If

        If txt_nota_debito_maximo.Text = "" Then
            txt_nota_debito_minimo.Text = "0"
            txt_nota_debito_maximo.Text = "0"
        End If

        txt_total_abono_contado_millar.Text = "0"
        txt_total_boleta_contado_millar.Text = "0"
        txt_total_boleta_credito_millar.Text = "0"
        txt_total_factura_contado_millar.Text = "0"
        txt_total_factura_credito_millar.Text = "0"
        txt_total_guia_credito_millar.Text = "0"
        txt_total_nota_credito_millar.Text = "0"
        fecha()

        crear_conexion()
        funciones_de_caja_calcular()
        recuperar_conexion()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub txt_boleta_minimo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_boleta_minimo.KeyPress
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

        txt_total_boleta_contado.Text = "0"
        txt_total_boleta_credito.Text = "0"
        txt_total_boleta_contado_millar.Text = "0"
        txt_total_boleta_credito_millar.Text = "0"
        txt_total_contado.Text = "0"
        txt_total_credito.Text = "0"
    End Sub

    Private Sub txt_boleta_minimo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_boleta_minimo.TextChanged
        limpiar_fuera()
    End Sub

    Private Sub txt_boleta_maximo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_boleta_maximo.KeyPress

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

        txt_total_boleta_contado.Text = "0"
        txt_total_boleta_credito.Text = "0"
        txt_total_boleta_contado_millar.Text = "0"
        txt_total_boleta_credito_millar.Text = "0"
    End Sub

    Private Sub txt_boleta_maximo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_boleta_maximo.TextChanged
        limpiar_fuera()
    End Sub

    Private Sub txt_factura_contado_minimo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_factura_minimo.KeyPress
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

        txt_total_factura_contado.Text = "0"
        txt_total_factura_credito.Text = "0"
        txt_total_factura_contado_millar.Text = "0"
        txt_total_factura_credito_millar.Text = "0"
        txt_total_contado.Text = "0"
        txt_total_credito.Text = "0"
    End Sub

    Private Sub txt_factura_contado_minimo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_factura_minimo.TextChanged
        limpiar_fuera()
    End Sub

    Private Sub txt_factura_contado_maximo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_factura_maximo.KeyPress

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

        txt_total_factura_contado.Text = "0"
        txt_total_factura_credito.Text = "0"
        txt_total_factura_contado_millar.Text = "0"
        txt_total_factura_credito_millar.Text = "0"
        txt_total_contado.Text = "0"
        txt_total_credito.Text = "0"
    End Sub

    Private Sub txt_factura_contado_maximo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_factura_maximo.TextChanged
        limpiar_fuera()
    End Sub

    Private Sub txt_guia_minimo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_guia_minimo.KeyPress

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

        txt_total_guia_credito.Text = "0"
        txt_total_guia_credito_millar.Text = "0"
    End Sub

    Private Sub txt_guia_minimo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_guia_minimo.TextChanged
        limpiar_fuera()
    End Sub

    Private Sub txt_guia_maximo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_guia_maximo.KeyPress

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

        txt_total_guia_credito.Text = "0"
        txt_total_guia_credito_millar.Text = "0"
        txt_total_contado.Text = "0"
        txt_total_credito.Text = "0"
    End Sub

    Private Sub txt_guia_maximo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_guia_maximo.TextChanged
        limpiar_fuera()
    End Sub

    'Sub cargar_notas_de_credito()
    '    SC.Connection = conexion
    '    SC.CommandText = "DELETE FROM detalle_condiciones where usuario_responsable='" & (miusuario) & "'"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)

    '    grilla_notas_de_credito.Rows.Clear()

    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select sum(total) as total, condiciones from nota_credito where  fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and condiciones <> 'CREDITO' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condiciones ORDER BY CONDICIONES"
    '    Else
    '        SC.CommandText = "select sum(total) as total, condiciones from nota_credito where caja ='" & (Combo_caja.Text) & "' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and condiciones <> 'CREDITO' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condiciones ORDER BY CONDICIONES"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_notas_de_credito.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("total"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("condiciones"))
    '        Next
    '    End If

    '    Dim VarDetalle As String
    '    Dim VarMonto As String

    '    For i = 0 To grilla_notas_de_credito.Rows.Count - 1
    '        VarDetalle = grilla_notas_de_credito.Rows(i).Cells(1).Value.ToString
    '        VarMonto = grilla_notas_de_credito.Rows(i).Cells(0).Value.ToString

    '        SC.Connection = conexion
    '        SC.CommandText = "insert into detalle_condiciones (detalle, monto, usuario_responsable) values('" & (VarDetalle) & "','" & (VarMonto) & "','" & (miusuario) & "')"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '    Next
    'End Sub

    'Sub cargar_notas_de_debito()
    '    SC.Connection = conexion
    '    SC.CommandText = "DELETE FROM detalle_condiciones where usuario_responsable='" & (miusuario) & "'"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)

    '    grilla_notas_de_debito.Rows.Clear()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select sum(total) as total, condiciones from NOTA_DEBITO where  fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and condiciones <> 'CREDITO' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condiciones ORDER BY CONDICIONES"
    '    Else
    '        SC.CommandText = "select sum(total) as total, condiciones from NOTA_DEBITO where caja ='" & (Combo_caja.Text) & "' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and condiciones <> 'CREDITO' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condiciones ORDER BY CONDICIONES"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_notas_de_debito.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("total"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("condiciones"))
    '        Next
    '    End If

    '    Dim VarDetalle As String
    '    Dim VarMonto As String

    '    For i = 0 To grilla_notas_de_debito.Rows.Count - 1
    '        VarDetalle = grilla_notas_de_debito.Rows(i).Cells(1).Value.ToString
    '        VarMonto = grilla_notas_de_debito.Rows(i).Cells(0).Value.ToString

    '        SC.Connection = conexion
    '        SC.CommandText = "insert into detalle_condiciones (detalle, monto, usuario_responsable) values('" & (VarDetalle) & "','" & (VarMonto) & "','" & (miusuario) & "')"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '    Next
    'End Sub

    Private Sub txt_abono_minimo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_abono_minimo.KeyPress
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

        txt_total_abono_contado.Text = "0"
        txt_total_abono_contado_millar.Text = "0"

        txt_total_contado.Text = "0"
        txt_total_credito.Text = "0"
        txt_total_contado.Text = "0"
        txt_total_credito.Text = "0"
    End Sub

    Private Sub txt_abono_minimo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_abono_minimo.TextChanged
        limpiar_fuera()
    End Sub

    Private Sub txt_abono_maximo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_abono_maximo.KeyPress
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

        txt_total_abono_contado.Text = "0"
        txt_total_abono_contado_millar.Text = "0"
        txt_total_contado.Text = "0"
        txt_total_credito.Text = "0"
    End Sub

    Private Sub txt_abono_maximo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_abono_maximo.TextChanged
        limpiar_fuera()
    End Sub

    Private Sub txt_nota_credito_minimo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nota_credito_minimo.KeyPress
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

        txt_total_nota_credito_contado.Text = "0"
        txt_total_nota_credito_millar.Text = "0"
        txt_total_contado.Text = "0"
        txt_total_credito.Text = "0"
    End Sub

    Private Sub txt_nota_credito_minimo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nota_credito_minimo.TextChanged
        limpiar_fuera()
    End Sub

    Private Sub txt_nota_credito_maximo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nota_credito_maximo.KeyPress
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

        txt_total_nota_credito_contado.Text = "0"
        txt_total_nota_credito_millar.Text = "0"

        txt_total_contado.Text = "0"
        txt_total_credito.Text = "0"
    End Sub

    Private Sub txt_nota_credito_maximo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nota_credito_maximo.TextChanged
        limpiar_fuera()
    End Sub

    Private Sub btn_detalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_detalle.Click
        If dtp_fecha_caja_desde.Text <> dtp_fecha_caja_hasta.Text Then
            MsgBox("LAS FECHAS NO COINCIDEN, FAVOR REVISAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            dtp_fecha_caja_desde.Focus()
            Exit Sub
        End If

        Form_detalle_cuadratura_caja.Show()
        Me.Enabled = False
    End Sub

    Private Function ReturnDataSet() As DataSet
        'Dim dt As New DataTable
        'Dim dr As DataRow
        'Dim ds As New DataSet

        'dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
        'dt.Columns.Add(New DataColumn("boleta_desde", GetType(String)))
        'dt.Columns.Add(New DataColumn("boleta_hasta", GetType(String)))
        'dt.Columns.Add(New DataColumn("boleta_total", GetType(String)))
        'dt.Columns.Add(New DataColumn("boleta_credito", GetType(String)))
        'dt.Columns.Add(New DataColumn("factura_desde", GetType(String)))
        'dt.Columns.Add(New DataColumn("factura_hasta", GetType(String)))
        'dt.Columns.Add(New DataColumn("factura_total", GetType(String)))
        'dt.Columns.Add(New DataColumn("factura_credito", GetType(String)))
        'dt.Columns.Add(New DataColumn("guia_desde", GetType(String)))
        'dt.Columns.Add(New DataColumn("guia_hasta", GetType(String)))
        'dt.Columns.Add(New DataColumn("guia_total", GetType(String)))
        'dt.Columns.Add(New DataColumn("abono_desde", GetType(String)))
        'dt.Columns.Add(New DataColumn("abono_hasta", GetType(String)))
        'dt.Columns.Add(New DataColumn("abono_total", GetType(String)))
        'dt.Columns.Add(New DataColumn("nota_de_credito_desde", GetType(String)))
        'dt.Columns.Add(New DataColumn("nota_de_credito_hasta", GetType(String)))
        'dt.Columns.Add(New DataColumn("nota_de_credito_total", GetType(String)))
        'dt.Columns.Add(New DataColumn("nota_de_credito_credito", GetType(String)))
        'dt.Columns.Add(New DataColumn("nota_de_debito_desde", GetType(String)))
        'dt.Columns.Add(New DataColumn("nota_de_debito_hasta", GetType(String)))
        'dt.Columns.Add(New DataColumn("nota_de_debito_total", GetType(String)))
        'dt.Columns.Add(New DataColumn("nota_de_debito_credito", GetType(String)))
        'dt.Columns.Add(New DataColumn("detalle_caja", GetType(String)))
        'dt.Columns.Add(New DataColumn("monto_caja", GetType(String)))
        'dt.Columns.Add(New DataColumn("total_ingresos", GetType(String)))
        'dt.Columns.Add(New DataColumn("total_egresos", GetType(String)))
        'dt.Columns.Add(New DataColumn("total_tarjetas", GetType(String)))
        'dt.Columns.Add(New DataColumn("total_cheques", GetType(String)))
        'dt.Columns.Add(New DataColumn("fecha_caja", GetType(String)))
        'dt.Columns.Add(New DataColumn("recinto", GetType(String)))
        'dt.Columns.Add(New DataColumn("TOTAL_CONTADO", GetType(String)))
        'dt.Columns.Add(New DataColumn("total_credito", GetType(String)))
        'dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("ciudad_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))
        'dt.Columns.Add(New DataColumn("boletas_nulas", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("facturas_nulas", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("guias_nulas", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("abonos_nulos", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("notas_credito_nulas", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("notas_debito_nulas", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("total_doc_nulos", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("guias_total_contado", GetType(String)))
        'dt.Columns.Add(New DataColumn("abono_total_credito", GetType(String)))
        'dt.Columns.Add(New DataColumn("pie_boleta", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("saldo_boleta", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("pie_factura", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("saldo_factura", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("pie_guia", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("saldo_guia", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("pie_abono", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("saldo_abono", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("pie_nota_credito", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("saldo_nota_credito", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("pie_nota_debito", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("saldo_nota_debito", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("total_pie", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("total_saldo", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("total_venta", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("cantidad_de_boletas", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("venta_efectivo", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("porcentaje_efectivo", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("ingresos", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("gastos", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("pendientes", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("total", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("separador", GetType(String)))
        'dt.Columns.Add(New DataColumn("fecha_y_caja", GetType(String)))
        'dt.Columns.Add(New DataColumn("usuario", GetType(String)))

        'Dim VarDetalleIngreso As String
        'Dim VarMontoIngreso As String
        'Dim VarSeparador As String
        'VarSeparador = ""
        'For i = 0 To grilla_resumen.Rows.Count - 1
        '    VarDetalleIngreso = grilla_resumen.Rows(i).Cells(0).Value.ToString
        '    VarMontoIngreso = grilla_resumen.Rows(i).Cells(1).Value.ToString
        '    dr = dt.NewRow()

        '    Try
        '        dr("Imagen") = Imagen_reporte
        '    Catch
        '    End Try


        '    dr("fecha_y_caja") = "FECHA_EMISION: " & Form_menu_principal.dtp_fecha.Text & " A LAS:" & Form_menu_principal.lbl_hora.Text
        '    dr("usuario") = "USUARIO: " & minombre

        '    dr("boleta_desde") = txt_boleta_minimo.Text
        '    dr("boleta_hasta") = txt_boleta_maximo.Text
        '    dr("boleta_total") = txt_total_boleta_contado_millar.Text
        '    dr("boleta_credito") = txt_total_boleta_credito_millar.Text
        '    dr("factura_desde") = txt_factura_minimo.Text
        '    dr("factura_hasta") = txt_factura_maximo.Text
        '    dr("factura_total") = txt_total_factura_contado_millar.Text
        '    dr("factura_credito") = txt_total_factura_credito_millar.Text
        '    dr("guia_desde") = txt_guia_minimo.Text
        '    dr("guia_hasta") = txt_guia_maximo.Text
        '    dr("guia_total") = txt_total_guia_credito_millar.Text
        '    dr("abono_desde") = txt_abono_minimo.Text
        '    dr("abono_hasta") = txt_abono_maximo.Text
        '    dr("abono_total") = txt_total_abono_contado_millar.Text
        '    dr("nota_de_credito_desde") = txt_nota_credito_minimo.Text
        '    dr("nota_de_credito_hasta") = txt_nota_credito_maximo.Text
        '    dr("nota_de_credito_total") = txt_total_nota_credito_millar.Text
        '    dr("nota_de_credito_credito") = txt_total_nota_credito_credito_millar.Text
        '    dr("nota_de_debito_desde") = txt_nota_debito_minimo.Text
        '    dr("nota_de_debito_hasta") = txt_nota_debito_maximo.Text
        '    dr("nota_de_debito_total") = txt_total_nota_debito_millar.Text
        '    dr("nota_de_debito_credito") = txt_total_nota_debito_credito_millar.Text
        '    dr("total_contado") = txt_total_contado_millar.Text
        '    dr("total_credito") = txt_total_credito_millar.Text
        '    dr("guias_total_contado") = txt_total_guia_contado_millar.Text
        '    dr("abono_total_credito") = txt_total_abono_credito_millar.Text
        '    dr("boletas_nulas") = boletas_nulas
        '    dr("facturas_nulas") = facturas_nulas
        '    dr("guias_nulas") = guias_nulas
        '    dr("abonos_nulos") = abono_nulos
        '    dr("notas_credito_nulas") = nota_credito_nulas
        '    dr("notas_debito_nulas") = nota_debito_nulas
        '    dr("total_doc_nulos") = Val(txt_cantidad_boletas_anuladas.Text) + Val(txt_cantidad_facturas_anuladas.Text) + Val(txt_cantidad_guias_anuladas.Text) + Val(txt_cantidad_abonos_anuladas.Text) + Val(txt_cantidad_notas_credito_anuladas.Text) + Val(txt_cantidad_notas_debito_anuladas.Text)

        '    txt_total_resumen.Text = Format(Val(txt_total_resumen.Text), "###,###,###")

        '    dr("total_cheques") = txt_total_resumen.Text

        '    If tipo_impresion = "FORMAL" Then
        '        dr("fecha_caja") = "<font color='#08088A'><P ALIGN=center>CUADRATURA DE CAJA (" & Combo_sucursal.Text & ") </P></font>"
        '    End If

        '    If tipo_impresion = "TICKET" Then
        '        dr("fecha_caja") = "<font color='#08088A'><P ALIGN=center>(" & Combo_sucursal.Text & ") </P></font>"
        '    End If

        '    dr("recinto") = "DESDE " & dtp_fecha_caja_desde.Text & " HASTA " & dtp_fecha_caja_hasta.Text
        '    dr("total_venta") = Val(txt_total_contado.Text) + Val(txt_total_credito.Text) - Val(txt_total_abono_contado.Text)
        '    dr("cantidad_de_boletas") = txt_cantidad_boletas_emitidas.Text
        '    dr("venta_efectivo") = Val(txt_total_contado.Text) + Val(txt_total_pie.Text) - Val(txt_total_abono_contado.Text)

        '    Dim porcentaje_efectivo As Long
        '    Dim total_venta As String = "0"
        '    Dim venta_efectivo As String = "0"

        '    total_venta = Val(txt_total_contado.Text) + Val(txt_total_credito.Text) - Val(txt_total_abono_contado.Text)

        '    venta_efectivo = Val(txt_total_contado.Text) + Val(txt_total_pie.Text) - Val(txt_total_abono_contado.Text)

        '    If venta_efectivo <> "0" Then
        '        porcentaje_efectivo = venta_efectivo * 100 / total_venta
        '    End If

        '    dr("porcentaje_efectivo") = porcentaje_efectivo

        '    If VarMontoIngreso = " " Then
        '        VarMontoIngreso = 0
        '    End If

        '    VarMontoIngreso = Format(Int(VarMontoIngreso), "###,###,###")
        '    If VarDetalleIngreso <> " " And VarDetalleIngreso <> "DETALLE DE CAJA" And VarDetalleIngreso <> "EGRESOS" And VarDetalleIngreso <> "INGRESOS" Then
        '        VarSeparador = VarSeparador & "....................................................................................................................................................................................................................."
        '    Else
        '        VarSeparador = ""
        '    End If

        '    dr("detalle_caja") = VarDetalleIngreso
        '    dr("pie_boleta") = Val(txt_boletas_pie.Text)
        '    dr("saldo_boleta") = Val(txt_total_boleta_credito.Text) - Val(txt_boletas_pie.Text)
        '    dr("pie_factura") = Val(txt_factura_pie.Text)
        '    dr("saldo_factura") = Val(txt_total_factura_credito.Text) - Val(txt_factura_pie.Text)
        '    dr("pie_guia") = Val(txt_guia_pie.Text)
        '    dr("saldo_guia") = Val(txt_total_guia_credito.Text) - Val(txt_guia_pie.Text)
        '    dr("pie_abono") = "0"
        '    dr("saldo_abono") = Val(txt_total_abono_credito.Text)
        '    dr("pie_nota_credito") = "0"
        '    dr("saldo_nota_credito") = Val(txt_total_nota_credito_contado.Text) + Val(txt_total_nota_credito_credito.Text)
        '    dr("pie_nota_debito") = "0"
        '    dr("saldo_nota_debito") = Val(txt_total_nota_debito_credito.Text)
        '    dr("total_pie") = Val(txt_boletas_pie.Text) + Val(txt_factura_pie.Text) + Val(txt_guia_pie.Text)
        '    dr("total_saldo") = Val(txt_total_credito.Text) - Val(Val(txt_boletas_pie.Text) + Val(txt_factura_pie.Text) + Val(txt_guia_pie.Text))

        '    If mirutempresa = "81921000-4" Then
        '        If VarDetalleIngreso = "CHEQUES AL DIA " Then
        '            dr("monto_caja") = "<p align='right'> <b>" & VarMontoIngreso & "</p> </b>"
        '        Else
        '            dr("monto_caja") = "<p align='right'> " & VarMontoIngreso & "</p>"
        '        End If
        '    End If

        '    If VarDetalleIngreso = "TOTAL" Or VarDetalleIngreso = "INGRESOS MENOS EGRESOS" Or VarDetalleIngreso = "TOTAL EFECTIVO" Or VarDetalleIngreso = "A DEPOSITAR " Then
        '        dr("monto_caja") = "<p align='right'> <b>" & VarMontoIngreso & "</p> </b>"
        '    Else
        '        dr("monto_caja") = "<p align='right'> " & VarMontoIngreso & "</p>"
        '    End If

        '    dr("separador") = VarSeparador
        '    dr("total_egresos") = txt_total_egresos.Text
        '    dr("total_ingresos") = txt_total_ingresos.Text
        '    dr("total_tarjetas") = txt_total_tarjetas.Text
        '    dr("nombre_empresa") = minombreempresa
        '    dr("giro_empresa") = migiroempresa
        '    dr("direccion_empresa") = midireccionempresa
        '    dr("ciudad_empresa") = micomunaempresa
        '    dr("telefono_empresa") = mitelefonoempresa
        '    dr("correo_empresa") = micorreoempresa
        '    dr("rut_empresa") = mirutempresa
        '    dr("ingresos") = Val(txt_total_contado.Text) + Val(txt_total_ingresos.Text)
        '    dr("gastos") = Val(txt_total_anticipos.Text) + Val(txt_total_egresos_con_boleta.Text) + Val(txt_total_egresos_con_factura.Text) + Val(txt_total_otros_egresos_con_factura.Text) + Val(txt_total_retiro.Text)
        '    dr("pendientes") = Val(txt_total_pendientes.Text)
        '    'dr("total") = Val(txt_total_contado.Text) + Val(txt_total_ingresos.Text) + Val(txt_total_anticipos.Text) + Val(txt_total_egresos_con_boleta.Text) + Val(txt_total_egresos_con_factura.Text) + Val(txt_total_otros_egresos_con_factura.Text) + Val(txt_total_pendientes.Text) + Val(txt_total_retiro.Text)
        '    dr("total") = Val(txt_total_contado.Text) + Val(txt_total_ingresos.Text) + Val(txt_total_anticipos.Text) + Val(txt_total_egresos_con_boleta.Text) + Val(txt_total_egresos_con_factura.Text) + Val(txt_total_otros_egresos_con_factura.Text) + Val(txt_total_pendientes.Text) + Val(txt_total_retiro.Text)

        '    dt.Rows.Add(dr)
        'Next

        'If grilla_resumen.Rows.Count = 0 Then
        '    VarDetalleIngreso = ""
        '    VarMontoIngreso = "0"
        '    dr = dt.NewRow()
        '    Try
        '        dr("Imagen") = Imagen_reporte
        '    Catch
        '    End Try
        '    dr("boleta_desde") = txt_boleta_minimo.Text
        '    dr("boleta_hasta") = txt_boleta_maximo.Text
        '    dr("boleta_total") = txt_total_boleta_contado_millar.Text
        '    dr("boleta_credito") = txt_total_boleta_credito_millar.Text
        '    dr("factura_desde") = txt_factura_minimo.Text
        '    dr("factura_hasta") = txt_factura_maximo.Text
        '    dr("factura_total") = txt_total_factura_contado_millar.Text
        '    dr("factura_credito") = txt_total_factura_credito_millar.Text
        '    dr("guia_desde") = txt_guia_minimo.Text
        '    dr("guia_hasta") = txt_guia_maximo.Text
        '    dr("guia_total") = txt_total_guia_credito_millar.Text
        '    dr("abono_desde") = txt_abono_minimo.Text
        '    dr("abono_hasta") = txt_abono_maximo.Text
        '    dr("abono_total") = txt_total_abono_contado_millar.Text
        '    dr("nota_de_credito_desde") = txt_nota_credito_minimo.Text
        '    dr("nota_de_credito_hasta") = txt_nota_credito_maximo.Text
        '    dr("nota_de_credito_total") = txt_total_nota_credito_millar.Text
        '    dr("nota_de_credito_credito") = txt_total_nota_credito_credito_millar.Text
        '    dr("nota_de_debito_desde") = txt_nota_debito_minimo.Text
        '    dr("nota_de_debito_hasta") = txt_nota_debito_maximo.Text
        '    dr("nota_de_debito_total") = txt_total_nota_debito_millar.Text
        '    dr("nota_de_debito_credito") = txt_total_nota_debito_credito_millar.Text
        '    dr("total_contado") = txt_total_contado.Text
        '    dr("total_credito") = txt_total_credito.Text
        '    dr("guias_total_contado") = txt_total_guia_contado_millar.Text
        '    dr("abono_total_credito") = txt_total_abono_credito_millar.Text
        '    dr("BOLETAs_nulas") = Val(txt_cantidad_boletas_anuladas.Text)
        '    dr("facturas_nulas") = Val(txt_cantidad_facturas_anuladas.Text)
        '    dr("guias_nulas") = Val(txt_cantidad_guias_anuladas.Text)
        '    dr("abonos_nulos") = Val(txt_cantidad_abonos_anuladas.Text)
        '    dr("notas_credito_nulas") = Val(txt_cantidad_notas_credito_anuladas.Text)
        '    dr("notas_debito_nulas") = Val(txt_cantidad_notas_debito_anuladas.Text)
        '    dr("total_doc_nulos") = Val(txt_cantidad_boletas_anuladas.Text) + Val(txt_cantidad_facturas_anuladas.Text) + Val(txt_cantidad_guias_anuladas.Text) + Val(txt_cantidad_abonos_anuladas.Text) + Val(txt_cantidad_notas_credito_anuladas.Text) + Val(txt_cantidad_notas_debito_anuladas.Text)
        '    If txt_total_resumen.Text = "" Or txt_total_resumen.Text = "0" Then
        '        txt_total_resumen.Text = "0"
        '    Else
        '        txt_total_resumen.Text = Format(Int(txt_total_resumen.Text), "###,###,###")
        '    End If
        '    dr("total_cheques") = txt_total_resumen.Text
        '    dr("fecha_caja") = "<font color='#08088A'><P ALIGN=center>CUADRATURA DE CAJA (" & Combo_sucursal.Text & ") </P></font>"
        '    dr("recinto") = "DESDE " & dtp_fecha_caja_desde.Text & " HASTA " & dtp_fecha_caja_hasta.Text
        '    If VarMontoIngreso = " " Then
        '        VarMontoIngreso = 0
        '    End If
        '    VarMontoIngreso = Format(Int(VarMontoIngreso), "###,###,###")
        '    dr("detalle_caja") = VarDetalleIngreso
        '    If VarDetalleIngreso = "            TOTAL" Then
        '        dr("monto_caja") = "<p align='right'> <b>" & VarMontoIngreso & "</p> </b>"
        '    Else
        '        dr("monto_caja") = "<p align='right'> " & VarMontoIngreso & "</p>"
        '    End If
        '    dr("total_egresos") = txt_total_egresos.Text
        '    dr("total_ingresos") = txt_total_ingresos.Text
        '    dr("total_tarjetas") = txt_total_tarjetas.Text
        '    dr("nombre_empresa") = minombreempresa
        '    dr("giro_empresa") = migiroempresa
        '    dr("direccion_empresa") = midireccionempresa
        '    dr("ciudad_empresa") = micomunaempresa
        '    dr("telefono_empresa") = mitelefonoempresa
        '    dr("correo_empresa") = micorreoempresa
        '    dr("rut_empresa") = mirutempresa
        '    'dr("ingresos") = Val(txt_total_detalle_caja.Text) + Val(txt_total_ingresos.Text)
        '    dr("ingresos") = Val(txt_total_contado.Text) + Val(txt_total_ingresos.Text)

        '    dr("gastos") = Val(txt_total_anticipos.Text) + Val(txt_total_egresos_con_boleta.Text) + Val(txt_total_egresos_con_factura.Text) + Val(txt_total_otros_egresos_con_factura.Text) + Val(txt_total_retiro.Text)
        '    dr("pendientes") = Val(txt_total_pendientes.Text)
        '    'dr("total") = Val(txt_total_detalle_caja.Text) + Val(txt_total_ingresos.Text) + Val(txt_total_anticipos.Text) + Val(txt_total_egresos_con_boleta.Text) + Val(txt_total_egresos_con_factura.Text) + Val(txt_total_otros_egresos_con_factura.Text) + Val(txt_total_retiro.Text)
        '    dr("total") = Val(txt_total_contado.Text) + Val(txt_total_ingresos.Text) + Val(txt_total_anticipos.Text) + Val(txt_total_egresos_con_boleta.Text) + Val(txt_total_egresos_con_factura.Text) + Val(txt_total_otros_egresos_con_factura.Text) + Val(txt_total_retiro.Text)


        '    dt.Rows.Add(dr)
        'End If
        'ds.Tables.Add(dt)
        'ds.Tables(0).TableName = "Caja"
        'Dim iDS As New dscaja
        'iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
        'Return iDS
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

    'Sub cargar_ingresos()
    '    grilla_ingresos.Rows.Clear()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='INGRESO'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='INGRESO'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then

    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_ingresos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If

    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='INGRESOS'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='INGRESOS'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_ingresos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If

    '    'fecha()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='OTROS INGRESOS'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='OTROS INGRESOS'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_ingresos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If
    'End Sub

    'Sub cargar_pendientes()
    '    'grilla_pendientes.Rows.Clear()
    '    ''fecha()
    '    'conexion.Close()
    '    'DS.Tables.Clear()
    '    'DT.Rows.Clear()
    '    'DT.Columns.Clear()
    '    'DS.Clear()
    '    'SC.Connection = conexion
    '    'If Combo_caja.Text = "TODAS" Then
    '    '    SC.CommandText = "select * from detalle_cuadratura_caja where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='VENTAS PENDIENTES'"
    '    'Else
    '    '    SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='VENTAS PENDIENTES'"
    '    'End If
    '    'DA.SelectCommand = SC
    '    'DA.Fill(DT)
    '    'DS.Tables.Add(DT)
    '    'If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '    '    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '    '        grilla_pendientes.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '    '                                             DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '    '    Next
    '    'End If

    '    'conexion.Close()
    '    'DS.Tables.Clear()
    '    'DT.Rows.Clear()
    '    'DT.Columns.Clear()
    '    'DS.Clear()
    '    'SC.Connection = conexion
    '    'If Combo_caja.Text = "TODAS" Then
    '    '    SC.CommandText = "select * from detalle_cuadratura_caja where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='PENDIENTES'"
    '    'Else
    '    '    SC.CommandText = "select * from detalle_cuadratura_caja where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='PENDIENTES'"
    '    'End If
    '    'DA.SelectCommand = SC
    '    'DA.Fill(DT)
    '    'DS.Tables.Add(DT)
    '    'If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '    '    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '    '        grilla_pendientes.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '    '                                             DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '    '    Next
    '    'End If

    '    'conexion.Close()
    '    'DS.Tables.Clear()
    '    'DT.Rows.Clear()
    '    'DT.Columns.Clear()
    '    'DS.Clear()
    '    'SC.Connection = conexion
    '    'If Combo_caja.Text = "TODAS" Then
    '    '    SC.CommandText = "select * from detalle_cuadratura_caja where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='PENDIENTE'"
    '    'Else
    '    '    SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='PENDIENTE'"
    '    'End If
    '    'DA.SelectCommand = SC
    '    'DA.Fill(DT)
    '    'DS.Tables.Add(DT)
    '    'If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '    '    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '    '        grilla_pendientes.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '    '                                             DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '    '    Next
    '    'End If
    'End Sub

    'Sub cargar_egresos()
    '    grilla_egresos.Rows.Clear()
    '    'fecha()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESO'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESO'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_egresos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If

    '    'fecha()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='OTRO EGRESO'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='OTRO EGRESO'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_egresos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If

    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='OTROS EGRESOS'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='OTROS EGRESOS'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_egresos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If
    'End Sub


    'Sub cargar_retiros()
    '    grilla_retiros.Rows.Clear()
    '    'fecha()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='RETIRO'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='RETIRO'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_retiros.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If
    'End Sub

    'Sub cargar_anticipos()
    '    grilla_anticipos.Rows.Clear()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO like '%ANTICIPO%'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO like '%ANTICIPO%'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_anticipos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                       DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If
    'End Sub

    'Sub cargar_sueldos()
    '    grilla_sueldos.Rows.Clear()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO = 'SUELDO' OR TIPO = 'SUELDOS'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO = 'SUELDO' OR TIPO = 'SUELDOS'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_sueldos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                     DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If
    'End Sub

    'Sub cargar_fondo_de_sueldos()
    '    grilla_fondo_de_sueldos.Rows.Clear()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO like '%SUELDO SIN IMPUTAR%'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO like '%SUELDO SIN IMPUTAR%'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_fondo_de_sueldos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                              DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If
    'End Sub

    'Sub cargar_egresos_con_factura()
    '    grilla_egresos_con_factura.Rows.Clear()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESOS CON FACTURA'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESOS CON FACTURA'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_egresos_con_factura.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If

    '    'fecha()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESO CON FACTURA'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESO CON FACTURA'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_egresos_con_factura.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If

    '    'fecha()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESOS CON FACTURA (EXISTENCIAS)'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESOS CON FACTURA (EXISTENCIAS)'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then

    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_egresos_con_factura.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If

    '    'fecha()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESO CON FACTURA (EXISTENCIAS)'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESO CON FACTURA (EXISTENCIAS)'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_egresos_con_factura.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If
    'End Sub

    'Sub cargar_egresos_con_boleta()
    '    grilla_egresos_con_boleta.Rows.Clear()
    '    'fecha()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESO CON BOLETA'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESO CON BOLETA'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_egresos_con_boleta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If

    '    'fecha()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESOS CON BOLETA'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESOS CON BOLETA'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_egresos_con_boleta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If

    '    'fecha()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESOS CON BOLETA Y OTROS'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESOS CON BOLETA Y OTROS'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_egresos_con_boleta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If

    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESO CON BOLETA Y OTROS'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESO CON BOLETA Y OTROS'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_egresos_con_boleta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If
    'End Sub

    'Sub cargar_otros_egresos_con_factura()
    '    grilla_otros_egresos_con_factura.Rows.Clear()
    '    'fecha()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='OTROS EGRESOS CON FACTURA'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='OTROS EGRESOS CON FACTURA'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_otros_egresos_con_factura.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If

    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='OTRO EGRESO CON FACTURA'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='OTRO EGRESO CON FACTURA'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_otros_egresos_con_factura.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If

    '    'fecha()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESOS CON FACTURA (OTROS)'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESOS CON FACTURA (OTROS)'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_otros_egresos_con_factura.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If

    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select * from detalle_cuadratura_caja where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESO CON FACTURA (OTROS)'"
    '    Else
    '        SC.CommandText = "select * from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND TIPO='EGRESO CON FACTURA (OTROS)'"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_otros_egresos_con_factura.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                 DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If
    'End Sub

    'Sub cargar_tarjetas()
    '    SC.Connection = conexion
    '    SC.CommandText = "DELETE FROM detalle_condiciones where usuario_responsable='" & (miusuario) & "'"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)

    '    grilla_tarjetas.Rows.Clear()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select sum(total) as total, condiciones from factura where  fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and condiciones NOT like 'CHEQUE%'  and condiciones <> 'EFECTIVO' and condiciones <> 'CREDITO' and condiciones <> 'AJUSTE' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condiciones ORDER BY CONDICIONES"
    '    Else
    '        SC.CommandText = "select sum(total) as total, condiciones from factura where caja ='" & (Combo_caja.Text) & "' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and condiciones NOT like 'CHEQUE%'  and condiciones <> 'EFECTIVO' and condiciones <> 'CREDITO' and condiciones <> 'AJUSTE' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condiciones ORDER BY CONDICIONES"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_tarjetas.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("total"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("condiciones"))
    '        Next
    '    End If

    '    Dim VarDetalle As String
    '    Dim VarMonto As String

    '    For i = 0 To grilla_tarjetas.Rows.Count - 1
    '        VarDetalle = grilla_tarjetas.Rows(i).Cells(1).Value.ToString
    '        VarMonto = grilla_tarjetas.Rows(i).Cells(0).Value.ToString

    '        SC.Connection = conexion
    '        SC.CommandText = "insert into detalle_condiciones (detalle, monto, usuario_responsable) values('" & (VarDetalle) & "','" & (VarMonto) & "','" & (miusuario) & "')"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '    Next

    '    grilla_tarjetas.Rows.Clear()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select sum(total) as total, condiciones from guia where  fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and condiciones NOT like 'CHEQUE%'  and condiciones <> 'EFECTIVO' and condiciones <> 'CREDITO' and condiciones <> 'AJUSTE' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condiciones ORDER BY CONDICIONES"
    '    Else
    '        SC.CommandText = "select sum(total) as total, condiciones from guia where caja ='" & (Combo_caja.Text) & "' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and condiciones NOT like 'CHEQUE%'  and condiciones <> 'EFECTIVO' and condiciones <> 'CREDITO' and condiciones <> 'AJUSTE' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condiciones ORDER BY CONDICIONES"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_tarjetas.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("total"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("condiciones"))
    '        Next
    '    End If

    '    For i = 0 To grilla_tarjetas.Rows.Count - 1
    '        VarDetalle = grilla_tarjetas.Rows(i).Cells(1).Value.ToString
    '        VarMonto = grilla_tarjetas.Rows(i).Cells(0).Value.ToString

    '        SC.Connection = conexion
    '        SC.CommandText = "insert into detalle_condiciones (detalle, monto, usuario_responsable) values('" & (VarDetalle) & "','" & (VarMonto) & "','" & (miusuario) & "')"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '    Next

    '    grilla_tarjetas.Rows.Clear()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select sum(total) as total, condiciones from BOLETA where  fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and condiciones NOT like 'CHEQUE%' and condiciones <> 'EFECTIVO'  and condiciones <> 'CREDITO' and condiciones <> 'AJUSTE' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condiciones ORDER BY CONDICIONES"
    '    Else
    '        SC.CommandText = "select sum(total) as total, condiciones from BOLETA where caja ='" & (Combo_caja.Text) & "' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and condiciones NOT like 'CHEQUE%' and condiciones <> 'EFECTIVO'  and condiciones <> 'CREDITO' and condiciones <> 'AJUSTE' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condiciones ORDER BY CONDICIONES"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_tarjetas.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("total"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("condiciones"))
    '        Next
    '    End If

    '    For i = 0 To grilla_tarjetas.Rows.Count - 1
    '        VarDetalle = grilla_tarjetas.Rows(i).Cells(1).Value.ToString
    '        VarMonto = grilla_tarjetas.Rows(i).Cells(0).Value.ToString

    '        SC.Connection = conexion
    '        SC.CommandText = "insert into detalle_condiciones (detalle, monto, usuario_responsable) values('" & (VarDetalle) & "','" & (VarMonto) & "','" & (miusuario) & "')"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '    Next

    '    grilla_tarjetas.Rows.Clear()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select sum(monto_abono) as monto_abono, condicion_abono from abono where  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and condicion_abono NOT like 'CHEQUE%' and condicion_abono <> 'EFECTIVO' and condicion_abono <> 'CREDITO' and condicion_abono <> 'AJUSTE' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condicion_abono ORDER BY condicion_abono"
    '    Else
    '        SC.CommandText = "select sum(monto_abono) as monto_abono, condicion_abono from abono where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and condicion_abono NOT like 'CHEQUE%' and condicion_abono <> 'EFECTIVO' and condicion_abono <> 'CREDITO' and condicion_abono <> 'AJUSTE' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condicion_abono ORDER BY condicion_abono"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_tarjetas.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("monto_abono"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("condicion_abono"))
    '        Next
    '    End If

    '    For i = 0 To grilla_tarjetas.Rows.Count - 1
    '        VarDetalle = grilla_tarjetas.Rows(i).Cells(1).Value.ToString
    '        VarMonto = grilla_tarjetas.Rows(i).Cells(0).Value.ToString

    '        SC.Connection = conexion
    '        SC.CommandText = "insert into detalle_condiciones (detalle, monto, usuario_responsable) values('" & (VarDetalle) & "','" & (VarMonto) & "','" & (miusuario) & "')"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '    Next

    '    grilla_tarjetas.Rows.Clear()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select sum(monto) as monto, detalle  from detalle_condiciones where usuario_responsable='" & (miusuario) & "' group by detalle  ORDER BY detalle"
    '    Else
    '        SC.CommandText = "select sum(monto) as monto, detalle  from detalle_condiciones where usuario_responsable='" & (miusuario) & "' group by detalle  ORDER BY detalle"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_tarjetas.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If
    'End Sub

    'Sub cargar_cheques_al_dia()
    '    txt_total_cheque_al_dia.Text = ""
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select sum(valor) as valor, condicion_de_pago from detalle_condicion_de_pago where tipo_doc ='FACTURA' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and (nro_doc) between '" & (txt_factura_minimo.Text) & "' and '" & (txt_factura_maximo.Text) & "' and condicion_de_pago ='CHEQUE AL DIA' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    Else
    '        SC.CommandText = "select sum(valor) as valor, condicion_de_pago from detalle_condicion_de_pago where caja ='" & (Combo_caja.Text) & "' and tipo_doc ='FACTURA' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and (nro_doc) between '" & (txt_factura_minimo.Text) & "' and '" & (txt_factura_maximo.Text) & "' and condicion_de_pago ='CHEQUE AL DIA' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        txt_total_cheque_al_dia.Text = Val(txt_total_cheque_al_dia.Text) + Val(DS.Tables(DT.TableName).Rows(0).Item("valor"))
    '    End If

    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select sum(valor) as valor, condicion_de_pago from detalle_condicion_de_pago where  tipo_doc ='BOLETA' and  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and (nro_doc) between '" & (txt_boleta_minimo.Text) & "' and '" & (txt_boleta_maximo.Text) & "' and condicion_de_pago ='CHEQUE AL DIA' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    Else
    '        SC.CommandText = "select sum(valor) as valor, condicion_de_pago from detalle_condicion_de_pago where caja ='" & (Combo_caja.Text) & "' and tipo_doc ='BOLETA' and  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and (nro_doc) between '" & (txt_boleta_minimo.Text) & "' and '" & (txt_boleta_maximo.Text) & "' and condicion_de_pago ='CHEQUE AL DIA' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        txt_total_cheque_al_dia.Text = Val(txt_total_cheque_al_dia.Text) + Val(DS.Tables(DT.TableName).Rows(0).Item("valor"))
    '    End If

    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select sum(valor) as valor, condicion_de_pago from detalle_condicion_de_pago where  tipo_doc ='GUIA' and  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and (nro_doc) between '" & (txt_guia_minimo.Text) & "' and '" & (txt_guia_maximo.Text) & "' and condicion_de_pago ='CHEQUE AL DIA' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    Else
    '        SC.CommandText = "select sum(valor) as valor, condicion_de_pago from detalle_condicion_de_pago where caja ='" & (Combo_caja.Text) & "' and tipo_doc ='GUIA' and  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and (nro_doc) between '" & (txt_guia_minimo.Text) & "' and '" & (txt_guia_maximo.Text) & "' and condicion_de_pago ='CHEQUE AL DIA' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        txt_total_cheque_al_dia.Text = Val(txt_total_cheque_al_dia.Text) + Val(DS.Tables(DT.TableName).Rows(0).Item("valor"))
    '    End If

    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select sum(valor) as valor, condicion_de_pago from detalle_condicion_de_pago where  tipo_doc ='ABONO' and  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and (nro_doc) between '" & (txt_abono_minimo.Text) & "' and '" & (txt_abono_maximo.Text) & "' and condicion_de_pago ='CHEQUE AL DIA' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    Else
    '        SC.CommandText = "select sum(valor) as valor, condicion_de_pago from detalle_condicion_de_pago where caja ='" & (Combo_caja.Text) & "' and tipo_doc ='ABONO' and  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and (nro_doc) between '" & (txt_abono_minimo.Text) & "' and '" & (txt_abono_maximo.Text) & "' and condicion_de_pago ='CHEQUE AL DIA' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        txt_total_cheque_al_dia.Text = Val(txt_total_cheque_al_dia.Text) + Val(DS.Tables(DT.TableName).Rows(0).Item("valor"))
    '    End If
    'End Sub

    'Sub cargar_efectivo()
    '    SC.Connection = conexion
    '    SC.CommandText = "DELETE FROM detalle_condiciones where usuario_responsable='" & (miusuario) & "'"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    'fecha()

    '    grilla_efectivo.Rows.Clear()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select sum(valor) as total, condicion_de_pago from detalle_condicion_de_pago where tipo_doc ='FACTURA' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and (nro_doc) between '" & (txt_factura_minimo.Text) & "' and '" & (txt_factura_maximo.Text) & "' and condicion_de_pago ='EFECTIVO' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    Else
    '        SC.CommandText = "select sum(valor) as total, condicion_de_pago from detalle_condicion_de_pago where caja ='" & (Combo_caja.Text) & "' and tipo_doc ='FACTURA' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and (nro_doc) between '" & (txt_factura_minimo.Text) & "' and '" & (txt_factura_maximo.Text) & "' and condicion_de_pago ='EFECTIVO' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_efectivo.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("total"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("condicion_de_pago"))
    '        Next
    '    End If

    '    Dim VarDetalle As String
    '    Dim VarMonto As String

    '    For i = 0 To grilla_efectivo.Rows.Count - 1
    '        VarDetalle = grilla_efectivo.Rows(i).Cells(1).Value.ToString
    '        VarMonto = grilla_efectivo.Rows(i).Cells(0).Value.ToString

    '        SC.Connection = conexion
    '        SC.CommandText = "insert into detalle_condiciones (detalle, monto, usuario_responsable) values('" & (VarDetalle) & "','" & (VarMonto) & "','" & (miusuario) & "')"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '    Next

    '    grilla_efectivo.Rows.Clear()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select sum(valor) as total, condicion_de_pago from detalle_condicion_de_pago where  tipo_doc ='BOLETA' and  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and (nro_doc) between '" & (txt_boleta_minimo.Text) & "' and '" & (txt_boleta_maximo.Text) & "' and condicion_de_pago ='EFECTIVO' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    Else
    '        SC.CommandText = "select sum(valor) as total, condicion_de_pago from detalle_condicion_de_pago where caja ='" & (Combo_caja.Text) & "' and tipo_doc ='BOLETA' and  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and (nro_doc) between '" & (txt_boleta_minimo.Text) & "' and '" & (txt_boleta_maximo.Text) & "' and condicion_de_pago ='EFECTIVO' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_efectivo.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("total"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("condicion_de_pago"))
    '        Next
    '    End If

    '    For i = 0 To grilla_efectivo.Rows.Count - 1
    '        VarDetalle = grilla_efectivo.Rows(i).Cells(1).Value.ToString
    '        VarMonto = grilla_efectivo.Rows(i).Cells(0).Value.ToString

    '        SC.Connection = conexion
    '        SC.CommandText = "insert into detalle_condiciones (detalle, monto, usuario_responsable) values('" & (VarDetalle) & "','" & (VarMonto) & "','" & (miusuario) & "')"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '    Next

    '    grilla_efectivo.Rows.Clear()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select sum(valor) as total, condicion_de_pago from detalle_condicion_de_pago where  tipo_doc ='GUIA' and  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and (nro_doc) between '" & (txt_guia_minimo.Text) & "' and '" & (txt_guia_maximo.Text) & "' and condicion_de_pago ='EFECTIVO' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    Else
    '        SC.CommandText = "select sum(valor) as total, condicion_de_pago from detalle_condicion_de_pago where caja ='" & (Combo_caja.Text) & "' and tipo_doc ='GUIA' and  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and (nro_doc) between '" & (txt_guia_minimo.Text) & "' and '" & (txt_guia_maximo.Text) & "' and condicion_de_pago ='EFECTIVO' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_efectivo.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("total"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("condicion_de_pago"))
    '        Next
    '    End If

    '    For i = 0 To grilla_efectivo.Rows.Count - 1
    '        VarDetalle = grilla_efectivo.Rows(i).Cells(1).Value.ToString
    '        VarMonto = grilla_efectivo.Rows(i).Cells(0).Value.ToString

    '        SC.Connection = conexion
    '        SC.CommandText = "insert into detalle_condiciones (detalle, monto, usuario_responsable) values('" & (VarDetalle) & "','" & (VarMonto) & "','" & (miusuario) & "')"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '    Next

    '    grilla_efectivo.Rows.Clear()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select sum(valor) as monto_abono, condicion_de_pago from detalle_condicion_de_pago where  tipo_doc ='ABONO' and  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and (nro_doc) between '" & (txt_abono_minimo.Text) & "' and '" & (txt_abono_maximo.Text) & "' and condicion_de_pago ='EFECTIVO' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    Else
    '        SC.CommandText = "select sum(valor) as monto_abono, condicion_de_pago from detalle_condicion_de_pago where caja ='" & (Combo_caja.Text) & "' and tipo_doc ='ABONO' and  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and (nro_doc) between '" & (txt_abono_minimo.Text) & "' and '" & (txt_abono_maximo.Text) & "' and condicion_de_pago ='EFECTIVO' and estado <> 'ANULADA' and estado <> 'ANULADO' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_efectivo.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("monto_abono"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("condicion_de_pago"))
    '        Next
    '    End If

    '    For i = 0 To grilla_efectivo.Rows.Count - 1
    '        VarDetalle = grilla_efectivo.Rows(i).Cells(1).Value.ToString
    '        VarMonto = grilla_efectivo.Rows(i).Cells(0).Value.ToString

    '        SC.Connection = conexion
    '        SC.CommandText = "insert into detalle_condiciones (detalle, monto, usuario_responsable) values('" & (VarDetalle) & "','" & (VarMonto) & "','" & (miusuario) & "')"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '    Next

    '    grilla_efectivo.Rows.Clear()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select  sum(monto) as monto, detalle from detalle_condiciones where usuario_responsable='" & (miusuario) & "' group by detalle  ORDER BY detalle DESC"
    '    Else
    '        SC.CommandText = "select  sum(monto) as monto, detalle from detalle_condiciones where usuario_responsable='" & (miusuario) & "' group by detalle  ORDER BY detalle DESC"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_efectivo.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If
    'End Sub

    'Sub resumen_grillas()
    '    grilla_resumen.Rows.Clear()

    '    Dim VarDetalle As String
    '    Dim VarMonto As String

    '    If mirutempresa = "81921000-4" Then
    '        If Val(txt_total_fondo.Text) <> 0 Then
    '            grilla_resumen.Rows.Add("FONDO DE SUELDOS ACUMULADO AL DIA " & dtp_fecha_caja_hasta.Text, txt_total_fondo.Text)
    '            grilla_resumen.Rows.Add(" ", " ")
    '        End If
    '    End If

    '    If mirutempresa <> "87686300-6" Then
    '        If grilla_pago_combinado.Rows.Count <> 0 Then
    '            For i = 0 To grilla_pago_combinado.Rows.Count - 1
    '                VarDetalle = grilla_pago_combinado.Rows(i).Cells(0).Value.ToString
    '                VarMonto = grilla_pago_combinado.Rows(i).Cells(1).Value.ToString
    '                grilla_resumen.Rows.Add(VarDetalle, VarMonto)
    '            Next

    '            If mirutempresa <> "81921000-4" Then
    '                If Val(txt_total_cheque_al_dia.Text) <> 0 Then
    '                    grilla_resumen.Rows.Add("CHEQUES AL DIA ", txt_total_cheque_al_dia.Text)
    '                End If
    '            End If

    '            If mirutempresa = "81921000-4" Then
    '                grilla_resumen.Rows.Add("TOTAL", Val(txt_total_detalle_caja.Text))
    '            End If

    '            If mirutempresa <> "81921000-4" Then
    '                grilla_resumen.Rows.Add("TOTAL", Val(txt_total_detalle_caja.Text) + Val(txt_total_cheque_al_dia.Text))
    '            End If
    '            grilla_resumen.Rows.Add(" ", " ")
    '        End If
    '    End If


    '    If grilla_ingresos.Rows.Count <> 0 Then
    '        grilla_resumen.Rows.Add("INGRESOS DE CAJA", " ")

    '        For i = 0 To grilla_ingresos.Rows.Count - 1
    '            VarDetalle = grilla_ingresos.Rows(i).Cells(0).Value.ToString
    '            VarMonto = grilla_ingresos.Rows(i).Cells(1).Value.ToString
    '            grilla_resumen.Rows.Add(VarDetalle, VarMonto)

    '        Next
    '        grilla_resumen.Rows.Add("TOTAL", txt_total_ingresos.Text)
    '        grilla_resumen.Rows.Add(" ", " ")
    '    End If

    '    If grilla_egresos.Rows.Count <> 0 Then
    '        grilla_resumen.Rows.Add("EGRESOS", " ")

    '        For i = 0 To grilla_egresos.Rows.Count - 1
    '            VarDetalle = grilla_egresos.Rows(i).Cells(0).Value.ToString
    '            VarMonto = grilla_egresos.Rows(i).Cells(1).Value.ToString
    '            grilla_resumen.Rows.Add(VarDetalle, VarMonto)
    '        Next
    '        grilla_resumen.Rows.Add("TOTAL", txt_total_egresos.Text)
    '        grilla_resumen.Rows.Add(" ", " ")
    '    End If

    '    If grilla_pendientes.Rows.Count <> 0 Then
    '        grilla_resumen.Rows.Add("DOCUMENTOS PENDIENTES", " ")

    '        For i = 0 To grilla_pendientes.Rows.Count - 1
    '            VarDetalle = grilla_pendientes.Rows(i).Cells(0).Value.ToString
    '            VarMonto = grilla_pendientes.Rows(i).Cells(1).Value.ToString
    '            grilla_resumen.Rows.Add(VarDetalle, VarMonto)
    '        Next
    '        grilla_resumen.Rows.Add("TOTAL", txt_total_pendientes.Text)
    '        grilla_resumen.Rows.Add(" ", " ")
    '    End If

    '    If grilla_egresos_con_boleta.Rows.Count <> 0 Then
    '        grilla_resumen.Rows.Add("EGRESOS CON BOLETA", " ")

    '        For i = 0 To grilla_egresos_con_boleta.Rows.Count - 1
    '            VarDetalle = grilla_egresos_con_boleta.Rows(i).Cells(0).Value.ToString
    '            VarMonto = grilla_egresos_con_boleta.Rows(i).Cells(1).Value.ToString
    '            grilla_resumen.Rows.Add(VarDetalle, VarMonto)
    '        Next
    '        grilla_resumen.Rows.Add("TOTAL", txt_total_egresos_con_boleta.Text)
    '        grilla_resumen.Rows.Add(" ", " ")
    '    End If

    '    If grilla_fondo_de_sueldos.Rows.Count <> 0 Then
    '        grilla_resumen.Rows.Add("SUELDOS SIN IMPUTAR", " ")
    '        For i = 0 To grilla_fondo_de_sueldos.Rows.Count - 1
    '            VarDetalle = grilla_fondo_de_sueldos.Rows(i).Cells(0).Value.ToString
    '            VarMonto = grilla_fondo_de_sueldos.Rows(i).Cells(1).Value.ToString
    '            grilla_resumen.Rows.Add(VarDetalle, VarMonto)
    '        Next
    '        grilla_resumen.Rows.Add("TOTAL", txt_total_fondo_de_sueldos.Text)
    '        grilla_resumen.Rows.Add(" ", " ")
    '    End If

    '    If grilla_anticipos.Rows.Count <> 0 Then
    '        grilla_resumen.Rows.Add("ANTICIPOS", " ")
    '        For i = 0 To grilla_anticipos.Rows.Count - 1
    '            VarDetalle = grilla_anticipos.Rows(i).Cells(0).Value.ToString
    '            VarMonto = grilla_anticipos.Rows(i).Cells(1).Value.ToString
    '            grilla_resumen.Rows.Add(VarDetalle, VarMonto)
    '        Next
    '        grilla_resumen.Rows.Add("TOTAL", txt_total_anticipos.Text)
    '        grilla_resumen.Rows.Add(" ", " ")
    '    End If

    '    If grilla_retiros.Rows.Count <> 0 Then
    '        grilla_resumen.Rows.Add("RETIROS", " ")
    '        For i = 0 To grilla_retiros.Rows.Count - 1
    '            VarDetalle = grilla_retiros.Rows(i).Cells(0).Value.ToString
    '            VarMonto = grilla_retiros.Rows(i).Cells(1).Value.ToString
    '            grilla_resumen.Rows.Add(VarDetalle, VarMonto)
    '        Next
    '        grilla_resumen.Rows.Add("TOTAL", txt_total_retiro.Text)
    '        grilla_resumen.Rows.Add(" ", " ")
    '    End If

    '    If grilla_sueldos.Rows.Count <> 0 Then
    '        grilla_resumen.Rows.Add("SUELDOS", " ")
    '        For i = 0 To grilla_sueldos.Rows.Count - 1
    '            VarDetalle = grilla_sueldos.Rows(i).Cells(0).Value.ToString
    '            VarMonto = grilla_sueldos.Rows(i).Cells(1).Value.ToString
    '            grilla_resumen.Rows.Add(VarDetalle, VarMonto)
    '        Next
    '        grilla_resumen.Rows.Add("TOTAL", txt_total_sueldo.Text)
    '        grilla_resumen.Rows.Add(" ", " ")
    '    End If

    '    If grilla_egresos_con_factura.Rows.Count <> 0 Then
    '        grilla_resumen.Rows.Add("EGRESOS CON FACTURA", " ")
    '        For i = 0 To grilla_egresos_con_factura.Rows.Count - 1
    '            VarDetalle = grilla_egresos_con_factura.Rows(i).Cells(0).Value.ToString
    '            VarMonto = grilla_egresos_con_factura.Rows(i).Cells(1).Value.ToString
    '            grilla_resumen.Rows.Add(VarDetalle, VarMonto)
    '        Next
    '        grilla_resumen.Rows.Add("TOTAL", txt_total_egresos_con_factura.Text)
    '        grilla_resumen.Rows.Add(" ", " ")
    '    End If

    '    If grilla_otros_egresos_con_factura.Rows.Count <> 0 Then
    '        grilla_resumen.Rows.Add("OTROS EGRESOS CON FACTURA", " ")
    '        For i = 0 To grilla_otros_egresos_con_factura.Rows.Count - 1
    '            VarDetalle = grilla_otros_egresos_con_factura.Rows(i).Cells(0).Value.ToString
    '            VarMonto = grilla_otros_egresos_con_factura.Rows(i).Cells(1).Value.ToString
    '            grilla_resumen.Rows.Add(VarDetalle, VarMonto)
    '        Next
    '        grilla_resumen.Rows.Add("TOTAL", txt_total_otros_egresos_con_factura.Text)
    '        grilla_resumen.Rows.Add(" ", " ")
    '    End If

    '    If mirutempresa = "81921000-4" Then
    '        If Val(txt_total_egresos.Text) <> 0 Or Val(txt_total_egresos_con_boleta.Text) <> 0 Or Val(txt_total_anticipos.Text) <> 0 Or Val(txt_total_sueldo.Text) <> 0 Or Val(txt_total_egresos_con_factura.Text) <> 0 Or Val(txt_total_otros_egresos_con_factura.Text) <> 0 Then
    '            grilla_resumen.Rows.Add("INGRESOS MENOS EGRESOS", Val(txt_total_detalle_caja.Text) + Val(txt_total_ingresos.Text) + +Val(txt_total_pendientes.Text) + Val(txt_total_cheque_al_dia.Text) + Val(txt_total_egresos.Text) + Val(txt_total_anticipos.Text) + Val(txt_total_sueldo.Text) + Val(txt_total_egresos_con_boleta.Text) + Val(txt_total_egresos_con_factura.Text) + Val(txt_total_otros_egresos_con_factura.Text) + Val(txt_total_fondo_de_sueldos.Text))
    '            grilla_resumen.Rows.Add(" ", " ")
    '        End If
    '    End If

    '    If grilla_pago_combinado.Rows.Count <> 0 Then
    '        For i = 0 To grilla_pago_combinado.Rows.Count - 1
    '            VarDetalle = grilla_pago_combinado.Rows(i).Cells(0).Value.ToString
    '            VarMonto = grilla_pago_combinado.Rows(i).Cells(1).Value.ToString

    '            If VarDetalle = "EFECTIVO" Then
    '                Dim efectivo As Integer
    '                Dim depositar As Integer

    '                If mirutempresa = "81921000-4" Then
    '                    efectivo = Val(txt_total_efectivo.Text) + Val(txt_total_egresos.Text) + Val(txt_total_anticipos.Text) + Val(txt_total_sueldo.Text) + Val(txt_total_egresos_con_boleta.Text) + Val(txt_total_egresos_con_factura.Text) + Val(txt_total_otros_egresos_con_factura.Text) + Val(txt_total_pendientes.Text) + Val(txt_total_fondo_de_sueldos.Text)
    '                    grilla_resumen.Rows.Add("TOTAL EFECTIVO", efectivo)
    '                    grilla_resumen.Rows.Add(" ", " ")
    '                End If

    '                If mirutempresa = "81921000-4" Then
    '                    If Val(txt_total_cheque_al_dia.Text) <> 0 Then
    '                        grilla_resumen.Rows.Add("CHEQUES AL DIA ", txt_total_cheque_al_dia.Text)
    '                        grilla_resumen.Rows.Add(" ", " ")
    '                    End If
    '                End If

    '                If mirutempresa = "81921000-4" Then
    '                    depositar = Val(txt_total_efectivo.Text) + Val(txt_total_cheque_al_dia.Text) + Val(txt_total_egresos.Text) + Val(txt_total_anticipos.Text) + Val(txt_total_sueldo.Text) + Val(txt_total_egresos_con_boleta.Text) + Val(txt_total_egresos_con_factura.Text) + Val(txt_total_otros_egresos_con_factura.Text) + Val(txt_total_pendientes.Text) + Val(txt_total_fondo_de_sueldos.Text)
    '                    grilla_resumen.Rows.Add("A DEPOSITAR ", depositar)
    '                    grilla_resumen.Rows.Add(" ", " ")
    '                End If
    '            End If
    '        Next
    '    End If
    'End Sub

    Sub calcular_totales_grilla()
        Dim total_ingresos As Integer
        Dim total_egresos As Integer
        'Dim total_anticipos As Integer
        'Dim total_egresos_con_factura As Integer
        'Dim total_egresos_con_boleta As Integer
        'Dim total_otros_egresos_con_factura As Integer
        'Dim total_tarjetas As Integer
        'Dim total_cheques As Integer
        'Dim total_efectivo As Integer
        'Dim total_detalle_caja As Integer
        'Dim total_pendiente As Integer
        'Dim total_sueldos As Integer
        'Dim total_fondo_de_sueldos As Integer
        'Dim total_retiro As Integer


        'txt_total_efectivo.Text = 0
        'For i = 0 To grilla_efectivo.Rows.Count - 1
        '    total_efectivo = Val(grilla_efectivo.Rows(i).Cells(1).Value.ToString)
        '    txt_total_efectivo.Text = Val(txt_total_efectivo.Text) + Val(total_efectivo)
        'Next

        txt_total_ingresos.Text = 0
        txt_total_egresos.Text = 0
        For i = 0 To grilla_detalle_caja.Rows.Count - 1
            total_ingresos = Val(grilla_detalle_caja.Rows(i).Cells(2).Value.ToString)

            If total_ingresos.ToString.Contains("-") Then
                txt_total_egresos.Text = Val(txt_total_egresos.Text) + Val(total_ingresos)
            Else
                txt_total_ingresos.Text = Val(txt_total_ingresos.Text) + Val(total_ingresos)
            End If
        Next

        'txt_total_anticipos.Text = 0
        'For i = 0 To grilla_anticipos.Rows.Count - 1
        '    total_anticipos = Val(grilla_anticipos.Rows(i).Cells(1).Value.ToString)
        '    txt_total_anticipos.Text = Val(txt_total_anticipos.Text) + Val(total_anticipos)
        'Next

        'txt_total_retiro.Text = 0
        'For i = 0 To grilla_retiros.Rows.Count - 1
        '    total_retiro = Val(grilla_retiros.Rows(i).Cells(1).Value.ToString)
        '    txt_total_retiro.Text = Val(txt_total_retiro.Text) + Val(total_retiro)
        'Next

        'txt_total_fondo_de_sueldos.Text = 0
        'For i = 0 To grilla_fondo_de_sueldos.Rows.Count - 1
        '    total_fondo_de_sueldos = Val(grilla_fondo_de_sueldos.Rows(i).Cells(1).Value.ToString)
        '    txt_total_fondo_de_sueldos.Text = Val(txt_total_fondo_de_sueldos.Text) + Val(total_fondo_de_sueldos)
        'Next

        'txt_total_sueldo.Text = 0
        'For i = 0 To grilla_sueldos.Rows.Count - 1
        '    total_sueldos = Val(grilla_sueldos.Rows(i).Cells(1).Value.ToString)
        '    txt_total_sueldo.Text = Val(txt_total_sueldo.Text) + Val(total_sueldos)
        'Next

        'txt_total_egresos_con_factura.Text = 0
        'For i = 0 To grilla_egresos_con_factura.Rows.Count - 1
        '    total_egresos_con_factura = Val(grilla_egresos_con_factura.Rows(i).Cells(1).Value.ToString)
        '    txt_total_egresos_con_factura.Text = Val(txt_total_egresos_con_factura.Text) + Val(total_egresos_con_factura)
        'Next

        'txt_total_pendientes.Text = 0
        'For i = 0 To grilla_pendientes.Rows.Count - 1
        '    total_pendiente = Val(grilla_pendientes.Rows(i).Cells(1).Value.ToString)
        '    txt_total_pendientes.Text = Val(txt_total_pendientes.Text) + Val(total_pendiente)
        'Next

        'txt_total_egresos_con_boleta.Text = 0
        'For i = 0 To grilla_egresos_con_boleta.Rows.Count - 1
        '    total_egresos_con_boleta = Val(grilla_egresos_con_boleta.Rows(i).Cells(1).Value.ToString)
        '    txt_total_egresos_con_boleta.Text = Val(txt_total_egresos_con_boleta.Text) + Val(total_egresos_con_boleta)
        'Next

        'txt_total_otros_egresos_con_factura.Text = 0
        'For i = 0 To grilla_otros_egresos_con_factura.Rows.Count - 1
        '    total_otros_egresos_con_factura = Val(grilla_otros_egresos_con_factura.Rows(i).Cells(1).Value.ToString)
        '    txt_total_otros_egresos_con_factura.Text = Val(txt_total_otros_egresos_con_factura.Text) + Val(total_otros_egresos_con_factura)
        'Next


        'txt_total_tarjetas.Text = 0
        'For i = 0 To grilla_tarjetas.Rows.Count - 1
        '    total_tarjetas = Val(grilla_tarjetas.Rows(i).Cells(1).Value.ToString)
        '    txt_total_tarjetas.Text = Val(txt_total_tarjetas.Text) + Val(total_tarjetas)
        'Next


        'txt_total_cheques.Text = 0
        'For i = 0 To grilla_cheques.Rows.Count - 1
        '    total_cheques = Val(grilla_cheques.Rows(i).Cells(1).Value.ToString)
        '    txt_total_cheques.Text = Val(txt_total_cheques.Text) + Val(total_cheques)
        'Next

        'txt_total_detalle_caja.Text = 0
        'For i = 0 To grilla_pago_combinado.Rows.Count - 1
        '    total_detalle_caja = Val(grilla_pago_combinado.Rows(i).Cells(1).Value.ToString)
        '    txt_total_detalle_caja.Text = Val(txt_total_detalle_caja.Text) + Val(total_detalle_caja)
        'Next

        'txt_total_resumen.Text = 0

        'Dim total_credito As String
        'total_credito = txt_total_credito.Text

        'total_credito = Trim(Replace(total_credito, ".", ""))

        'txt_total_resumen.Text = Val(txt_total_ingresos.Text) + Val(txt_total_egresos.Text) + Val(txt_total_detalle_caja.Text)
    End Sub

    Private Sub dtp_fecha_caja_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha_caja_hasta.ValueChanged
        limpiar()
    End Sub

    'Sub cargar_detalle_caja()
    '    grilla_pago_combinado.Rows.Clear()
    '    '\\BOLETA
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select condicion_de_pago, sum(valor) as total from detalle_condicion_de_pago where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and estado <> 'ANULADA' AND condicion_de_pago <> 'CHEQUE AL DIA' AND condicion_de_pago <> 'CREDITO' AND condicion_de_pago <> 'TRASLADO' AND tipo_doc='BOLETA'  and (nro_doc) between '" & (txt_boleta_minimo.Text) & "' and '" & (txt_boleta_maximo.Text) & "' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    Else
    '        SC.CommandText = "select condicion_de_pago, sum(valor) as total from detalle_condicion_de_pago where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and estado <> 'ANULADA' AND condicion_de_pago <> 'CHEQUE AL DIA' AND condicion_de_pago <> 'CREDITO' AND condicion_de_pago <> 'TRASLADO' AND tipo_doc='BOLETA'  and (nro_doc) between '" & (txt_boleta_minimo.Text) & "' and '" & (txt_boleta_maximo.Text) & "' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_pago_combinado.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("condicion_de_pago"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("total"))
    '        Next
    '    End If

    '    '\\FACTURA
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select condicion_de_pago, sum(valor) as total from detalle_condicion_de_pago where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and estado <> 'ANULADA'  AND condicion_de_pago <> 'CHEQUE AL DIA' AND condicion_de_pago <> 'CREDITO'  AND condicion_de_pago<>'TRASLADO' AND tipo_doc='FACTURA'  and (nro_doc) between '" & (txt_factura_minimo.Text) & "' and '" & (txt_factura_maximo.Text) & "' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    Else
    '        SC.CommandText = "select condicion_de_pago, sum(valor) as total from detalle_condicion_de_pago where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and estado <> 'ANULADA'  AND condicion_de_pago <> 'CHEQUE AL DIA' AND condicion_de_pago <> 'CREDITO'  AND condicion_de_pago<>'TRASLADO' AND tipo_doc='FACTURA'  and (nro_doc) between '" & (txt_factura_minimo.Text) & "' and '" & (txt_factura_maximo.Text) & "' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_pago_combinado.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("condicion_de_pago"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("total"))
    '        Next
    '    End If

    '    '\\ABONO
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select condicion_de_pago, sum(valor) as total from detalle_condicion_de_pago where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and estado <> 'ANULADA'  AND condicion_de_pago <> 'CHEQUE AL DIA' AND condicion_de_pago <> 'CREDITO' AND  condicion_de_pago<>'TRASLADO' AND tipo_doc='ABONO'  and (nro_doc) between '" & (txt_abono_minimo.Text) & "' and '" & (txt_abono_maximo.Text) & "' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    Else
    '        SC.CommandText = "select condicion_de_pago, sum(valor) as total from detalle_condicion_de_pago where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and estado <> 'ANULADA'  AND condicion_de_pago <> 'CHEQUE AL DIA' AND condicion_de_pago <> 'CREDITO' AND  condicion_de_pago<>'TRASLADO' AND tipo_doc='ABONO'  and (nro_doc) between '" & (txt_abono_minimo.Text) & "' and '" & (txt_abono_maximo.Text) & "' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_pago_combinado.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("condicion_de_pago"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("total"))
    '        Next
    '    End If

    '    '\\GUIA
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select condicion_de_pago, sum(valor) as total from detalle_condicion_de_pago where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and estado <> 'ANULADA'  AND condicion_de_pago <> 'CHEQUE AL DIA' AND condicion_de_pago <> 'CREDITO' AND  condicion_de_pago<>'TRASLADO' AND tipo_doc='GUIA'  and (nro_doc) between '" & (txt_guia_minimo.Text) & "' and '" & (txt_guia_maximo.Text) & "' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    Else
    '        SC.CommandText = "select condicion_de_pago, sum(valor) as total from detalle_condicion_de_pago where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and estado <> 'ANULADA'  AND condicion_de_pago <> 'CHEQUE AL DIA' AND condicion_de_pago <> 'CREDITO' AND  condicion_de_pago<>'TRASLADO' AND tipo_doc='GUIA'  and (nro_doc) between '" & (txt_guia_minimo.Text) & "' and '" & (txt_guia_maximo.Text) & "' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_pago_combinado.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("condicion_de_pago"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("total"))
    '        Next
    '    End If

    '    '\\NOTA DE CREDITO
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select condicion_de_pago, sum(valor) as total from detalle_condicion_de_pago where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and estado <> 'ANULADA'  AND condicion_de_pago <> 'CHEQUE AL DIA' AND condicion_de_pago <> 'CREDITO' AND  condicion_de_pago<>'TRASLADO' AND tipo_doc='NOTA DE CREDITO'  and (nro_doc) between '" & (txt_nota_credito_minimo.Text) & "' and '" & (txt_nota_credito_maximo.Text) & "' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    Else
    '        SC.CommandText = "select condicion_de_pago, sum(valor) as total from detalle_condicion_de_pago where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and estado <> 'ANULADA'  AND condicion_de_pago <> 'CHEQUE AL DIA' AND condicion_de_pago <> 'CREDITO' AND  condicion_de_pago<>'TRASLADO' AND tipo_doc='NOTA DE CREDITO'  and (nro_doc) between '" & (txt_nota_credito_minimo.Text) & "' and '" & (txt_nota_credito_maximo.Text) & "' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_pago_combinado.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("condicion_de_pago"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("total"))
    '        Next
    '    End If

    '    '\\NOTA DE DEBITO
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select condicion_de_pago, sum(valor) as total from detalle_condicion_de_pago where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and estado <> 'ANULADA'  AND condicion_de_pago <> 'CHEQUE AL DIA' AND condicion_de_pago <> 'CREDITO' AND  condicion_de_pago<>'TRASLADO' AND tipo_doc='NOTA DE DEBITO'  and (nro_doc) between '" & (txt_nota_debito_minimo.Text) & "' and '" & (txt_nota_debito_maximo.Text) & "' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    Else
    '        SC.CommandText = "select condicion_de_pago, sum(valor) as total from detalle_condicion_de_pago where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'  and estado <> 'ANULADA'  AND condicion_de_pago <> 'CHEQUE AL DIA' AND condicion_de_pago <> 'CREDITO' AND  condicion_de_pago<>'TRASLADO' AND tipo_doc='NOTA DE DEBITO'  and (nro_doc) between '" & (txt_nota_debito_minimo.Text) & "' and '" & (txt_nota_debito_maximo.Text) & "' group by condicion_de_pago ORDER BY condicion_de_pago"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_pago_combinado.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("condicion_de_pago"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("total"))
    '        Next
    '    End If

    '    Dim VarFormaDePago As String
    '    Dim VarMonto As String

    '    SC.Connection = conexion
    '    SC.CommandText = "delete from detalle_condiciones where usuario_responsable='" & (miusuario) & "'"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)

    '    For i = 0 To grilla_pago_combinado.Rows.Count - 1
    '        VarFormaDePago = grilla_pago_combinado.Rows(i).Cells(0).Value.ToString
    '        VarMonto = grilla_pago_combinado.Rows(i).Cells(1).Value.ToString

    '        SC.Connection = conexion
    '        SC.CommandText = "insert into detalle_condiciones (detalle, monto, usuario_responsable) values('" & (VarFormaDePago) & "', '" & (VarMonto) & "', '" & (miusuario) & "')"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '    Next

    '    grilla_pago_combinado.Rows.Clear()
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    SC.Connection = conexion
    '    If Combo_caja.Text = "TODAS" Then
    '        SC.CommandText = "select detalle, sum(monto) as monto from detalle_condiciones where usuario_responsable='" & (miusuario) & "' group by detalle ORDER BY detalle"
    '    Else
    '        SC.CommandText = "select detalle, sum(monto) as monto from detalle_condiciones where usuario_responsable='" & (miusuario) & "' group by detalle ORDER BY detalle"
    '    End If
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            grilla_pago_combinado.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
    '                                                DS.Tables(DT.TableName).Rows(i).Item("monto"))
    '        Next
    '    End If
    'End Sub

    Private Sub btn_ticket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ticket.Click

        lbl_mensaje.Visible = True
        Me.Enabled = False

        tipo_impresion = "TICKET"

        cargar_detalle_caja()
        calcular_totales_grilla()

        With PrintDocument_ticket.PrinterSettings
            .PrinterName = impresora_ticket
            .Copies = 2
            .PrintRange = PrintRange.AllPages
            If .IsValid Then
                Me.PrintDocument_ticket.PrintController = New StandardPrintController
                'Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                'Me.PrintDocument_ticket.DefaultPageSettings.PaperSize = pkCustomSize1
                PrintDocument_ticket.PrintController = New System.Drawing.Printing.StandardPrintController()
                PrintDocument_ticket.Print()
            Else
                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                lbl_mensaje.Visible = False
                Me.Enabled = True
                Exit Sub
            End If
        End With

        'Try
        '    Dim iReporte As New VisorReporte

        '    Dim rpt As New Crystal_caja_ticket

        '    rpt.Load()
        '    rpt.SetDataSource(ReturnDataSet)
        '    rpt.Refresh()

        '    iReporte.Reporte = rpt
        '    '  iReporte.ShowDialog()
        '    'rpt.PrintOptions.PrinterName = "\\Microsoft XPS Document Writer"
        '    rpt.PrintOptions.PrinterName = impresora_ticket
        '    rpt.PrintToPrinter(1, False, 0, 0)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        crear_conexion()
        funciones_de_caja()
        recuperar_conexion()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_salir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Sub funciones_de_caja()
        limpiar()
        fecha()
        mostrar_minimo_boleta()
        mostrar_maximo_boleta()
        mostrar_minimo_factura_contado()
        mostrar_maximo_factura_contado()
        mostrar_maximo_guia()
        mostrar_minimo_guia()
        mostrar_minimo_nota_credito()
        mostrar_maximo_nota_credito()
        mostrar_maximo_abono()
        mostrar_minimo_abono()
        mostrar_total_boleta()
        mostrar_total_boleta_credito()
        mostrar_total_factura_contado()
        mostrar_total_factura_credito()
        mostrar_total_guia_contado()
        mostrar_total_guia_credito()
        mostrar_maximo_nota_credito()
        mostrar_minimo_nota_credito()
        mostrar_maximo_nota_debito()
        mostrar_minimo_nota_debito()
        mostrar_total_nota_credito()
        mostrar_total_nota_credito_credito()
        mostrar_total_nota_debito()
        mostrar_total_nota_debito_credito()
        mostrar_total_abono_contado()
        mostrar_total_abono_credito()
        mostrar_cantidad_nulas()
        'mostrar_cantidad_emitidas()
        calcular_totales_credito_contado()
        cargar_detalle_caja()

        calcular_totales_grilla()
    End Sub

    Sub funciones_de_caja_calcular()
        fecha()
        mostrar_total_boleta()
        mostrar_total_boleta_credito()
        mostrar_total_factura_contado()
        mostrar_total_factura_credito()
        mostrar_total_guia_contado()
        mostrar_total_guia_credito()
        mostrar_total_nota_credito()
        mostrar_total_nota_credito_credito()
        mostrar_total_nota_debito()
        mostrar_total_nota_debito_credito()
        mostrar_total_abono_contado()
        mostrar_total_abono_credito()
        mostrar_cantidad_nulas()
        'mostrar_cantidad_emitidas()
        calcular_totales_credito_contado()
        cargar_detalle_caja()
        calcular_totales_grilla()
    End Sub

    Sub crear_conexion()
        Dim nombre_servidor As String
        Dim nombre_servidor_remoto As String
        Dim base_de_datos As String
        Dim clave_base_de_datos As String
        Dim usuario As String
        Dim recinto As String
        Dim rut_empresa As String
        Dim TIPO As String

        For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1
            nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
            nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
            base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
            clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
            usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
            recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
            rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString
            TIPO = Form_menu_principal.grilla_conexiones.Rows(i).Cells(7).Value.ToString

            recinto = Trim(Replace(recinto, "'", "´"))

            If Combo_sucursal.Text = recinto Then
                SucursalSeleccionada = Combo_sucursal.Text
                Try
                    conexion.Close()
                    conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                    tipo_conexion = "LOCAL"
                    conexion.Open()
                    conexion.Close()

                Catch
                    conexion.Close()
                    conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                    tipo_conexion = "REMOTA"
                End Try

                Try
                Catch
                    MsgBox("NO HAY CONEXION CON EL SERVIDOR", 0 + 16, "ERROR")
                    Me.Close()
                    Exit Sub
                End Try
                Exit Sub
            End If
        Next
    End Sub

    Sub recuperar_conexion()
        Dim nombre_servidor As String
        Dim nombre_servidor_remoto As String
        Dim base_de_datos As String
        Dim clave_base_de_datos As String
        Dim usuario As String
        Dim recinto As String
        Dim rut_empresa As String

        Try
            For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1
                nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
                nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
                base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
                clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
                usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
                recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
                rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString
                recinto = Trim(Replace(recinto, "'", "´"))

                If mirecintoempresa = recinto Then
                    Try
                        conexion.Close()
                        conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                        conexion.Open()
                        conexion.Close()
                    Catch
                        conexion.Close()
                        conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                        conexion.Open()
                        conexion.Close()
                    End Try
                End If
            Next
        Catch
            Me.Close()
            Form_menu_principal.Close()
        End Try
    End Sub

    Private Sub combo_conexion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_sucursal.SelectedIndexChanged
        limpiar()
    End Sub

    Sub llenar_combo_sucursales()
        Combo_sucursal.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion
        SC3.CommandText = "select * from sucursales order by nombre_sucursal"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_sucursal.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_sucursal"))
            Next
        End If
        Combo_sucursal.SelectedItem = mirecintoempresa
        conexion.Close()

        If mirutempresa = "81921000-4" Then
            If tipo_usuario = "ADMINISTRADOR DEL SISTEMA" Then
                Combo_sucursal.Items.Clear()
                conexion.Close()
                DS3.Tables.Clear()
                DT3.Rows.Clear()
                DT3.Columns.Clear()
                DS3.Clear()
                conexion.Open()
                SC3.Connection = conexion
                SC3.CommandText = "select * from sucursales order by nombre_sucursal"
                DA3.SelectCommand = SC3
                DA3.Fill(DT3)
                DS3.Tables.Add(DT3)
                If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                    For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                        Combo_sucursal.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_sucursal"))
                    Next
                End If
                Combo_sucursal.SelectedItem = mirecintoempresa
            Else
                Combo_sucursal.Items.Clear()
                Combo_sucursal.Items.Add(mirecintoempresa)
                Combo_sucursal.SelectedItem = mirecintoempresa
            End If
        End If
    End Sub

    Sub llenar_combo_cajas()
        Combo_caja.Items.Clear()
        Combo_caja.Items.Add("TODAS")
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion
        SC3.CommandText = "select * from equipos_de_cajas order by nombre_caja"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_caja.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_caja"))
            Next
        End If
        Combo_caja.SelectedItem = "TODAS"
        conexion.Close()
    End Sub

    Private Sub txt_nota_debito_minimo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nota_debito_minimo.TextChanged
        limpiar_fuera()
    End Sub

    Private Sub txt_nota_debito_maximo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nota_debito_maximo.TextChanged
        limpiar_fuera()
    End Sub

    Private Sub Combo_caja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_caja.SelectedIndexChanged
        limpiar()
    End Sub

    Private Sub PrintDocument_ticket_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument_ticket.PrintPage
        Dim Font_texto_titulo As New Font("arial", 9, FontStyle.Bold)
        Dim Font_texto_empresa As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_cabecera As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_titulo_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_totales As New Font("arial", 9, FontStyle.Bold)

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Try
            e.Graphics.DrawImage(Bytes_Imagen(Imagen_reporte), -74, 0, 440, 70)
        Catch
        End Try

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = 0
        margen_superior = 0

        Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 90, margen_izquierdo + 270, margen_superior + 15)
        Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 105, margen_izquierdo + 270, margen_superior + 15)
        Dim rect3 As New Rectangle(margen_izquierdo + 10, margen_superior + 120, margen_izquierdo + 270, margen_superior + 15)
        Dim rect4 As New Rectangle(margen_izquierdo + 10, margen_superior + 135, margen_izquierdo + 270, margen_superior + 15)
        Dim rect5 As New Rectangle(margen_izquierdo + 10, margen_superior + 150, margen_izquierdo + 270, margen_superior + 15)
        Dim rect6 As New Rectangle(margen_izquierdo + 10, margen_superior + 165, margen_izquierdo + 270, margen_superior + 15)
        Dim rect7 As New Rectangle(margen_izquierdo + 10, margen_superior + 180, margen_izquierdo + 270, margen_superior + 15)
        
        e.Graphics.DrawString(minombreempresa, Font_texto_empresa, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(migiroempresa, Font_texto_empresa, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font_texto_empresa, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font_texto_empresa, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font_texto_empresa, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font_texto_empresa, Brushes.Black, rect6, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font_texto_empresa, Brushes.Black, rect7, stringFormat)

        Dim rect_titulo As New Rectangle(margen_izquierdo + 10, margen_superior + 215, margen_izquierdo + 270, margen_superior + 15)
        e.Graphics.DrawString("CUADRATURA DE CAJA", Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + 230, margen_izquierdo + 295, margen_superior + 230)

        Dim rect_fecha As New Rectangle(margen_izquierdo + 10, margen_superior + 230, margen_izquierdo + 270, margen_superior + 15)
        e.Graphics.DrawString(Form_menu_principal.lbl_fecha.Text, Font_texto_cabecera, Brushes.Black, rect_fecha, stringFormat)

        Dim rect_recinto As New Rectangle(margen_izquierdo + 10, margen_superior + 245, margen_izquierdo + 270, margen_superior + 15)
        e.Graphics.DrawString(Combo_sucursal.Text, Font_texto_cabecera, Brushes.Black, rect_recinto, stringFormat)

        Dim rect_boletas As New Rectangle(margen_izquierdo + 10, margen_superior + 280, margen_izquierdo + 270, margen_superior + 15)
        e.Graphics.DrawString("BOLETAS", Font_texto_titulo, Brushes.Black, rect_boletas, stringFormat)

        e.Graphics.DrawString("DESDE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 295)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 65, margen_superior + 295)
        e.Graphics.DrawString(Val(txt_boleta_minimo.Text), Font_texto_cabecera, Brushes.Black, margen_izquierdo + 130, margen_superior + 295, format1)

        e.Graphics.DrawString("CONTADO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 310)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 65, margen_superior + 310)
        e.Graphics.DrawString(txt_total_boleta_contado_millar.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 130, margen_superior + 310, format1)

        e.Graphics.DrawString("DOC. NULOS", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 325)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 65, margen_superior + 325)
        e.Graphics.DrawString(Val(txt_cantidad_boletas_anuladas.Text), Font_texto_cabecera, Brushes.Black, margen_izquierdo + 130, margen_superior + 325, format1)
        '*******************************************************************************************************************************************************************
        e.Graphics.DrawString("HASTA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 170, margen_superior + 295)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 220, margen_superior + 295)
        e.Graphics.DrawString(Val(txt_boleta_maximo.Text), Font_texto_cabecera, Brushes.Black, margen_izquierdo + 285, margen_superior + 295, format1)

        e.Graphics.DrawString("CREDITO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 170, margen_superior + 310)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 220, margen_superior + 310)
        e.Graphics.DrawString(txt_total_boleta_credito_millar.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 285, margen_superior + 310, format1)
        '*******************************************************************************************************************************************************************
        Dim aumento As Integer = 80
        Dim rect_facturas As New Rectangle(margen_izquierdo + 10, margen_superior + aumento + 280, margen_izquierdo + 270, margen_superior + 15)
        e.Graphics.DrawString("FACTURAS", Font_texto_titulo, Brushes.Black, rect_facturas, stringFormat)

        e.Graphics.DrawString("DESDE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + aumento + 295)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 65, margen_superior + aumento + 295)
        e.Graphics.DrawString(Val(txt_factura_minimo.Text), Font_texto_cabecera, Brushes.Black, margen_izquierdo + 130, margen_superior + aumento + 295, format1)

        e.Graphics.DrawString("CONTADO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + aumento + 310)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 65, margen_superior + aumento + 310)
        e.Graphics.DrawString(txt_total_factura_contado_millar.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 130, margen_superior + aumento + 310, format1)

        e.Graphics.DrawString("DOC. NULOS", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + aumento + 325)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 65, margen_superior + aumento + 325)
        e.Graphics.DrawString(Val(txt_cantidad_facturas_anuladas.Text), Font_texto_cabecera, Brushes.Black, margen_izquierdo + 130, margen_superior + aumento + 325, format1)
        '*******************************************************************************************************************************************************************
        e.Graphics.DrawString("HASTA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 170, margen_superior + aumento + 295)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 220, margen_superior + aumento + 295)
        e.Graphics.DrawString(Val(txt_factura_maximo.Text), Font_texto_cabecera, Brushes.Black, margen_izquierdo + 285, margen_superior + aumento + 295, format1)

        e.Graphics.DrawString("CREDITO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 170, margen_superior + aumento + 310)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 220, margen_superior + aumento + 310)
        e.Graphics.DrawString(txt_total_factura_credito_millar.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 285, margen_superior + aumento + 310, format1)
        '*******************************************************************************************************************************************************************
        aumento = 160
        Dim rect_guias As New Rectangle(margen_izquierdo + 10, margen_superior + aumento + 280, margen_izquierdo + 270, margen_superior + 15)
        e.Graphics.DrawString("GUIAS", Font_texto_titulo, Brushes.Black, rect_guias, stringFormat)

        e.Graphics.DrawString("DESDE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + aumento + 295)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 65, margen_superior + aumento + 295)
        e.Graphics.DrawString(Val(txt_guia_minimo.Text), Font_texto_cabecera, Brushes.Black, margen_izquierdo + 130, margen_superior + aumento + 295, format1)

        e.Graphics.DrawString("CONTADO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + aumento + 310)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 65, margen_superior + aumento + 310)
        e.Graphics.DrawString(txt_total_guia_contado_millar.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 130, margen_superior + aumento + 310, format1)

        e.Graphics.DrawString("DOC. NULOS", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + aumento + 325)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 65, margen_superior + aumento + 325)
        e.Graphics.DrawString(Val(txt_cantidad_guias_anuladas.Text), Font_texto_cabecera, Brushes.Black, margen_izquierdo + 130, margen_superior + aumento + 325, format1)
        '*******************************************************************************************************************************************************************
        e.Graphics.DrawString("HASTA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 170, margen_superior + aumento + 295)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 220, margen_superior + aumento + 295)
        e.Graphics.DrawString(Val(txt_guia_maximo.Text), Font_texto_cabecera, Brushes.Black, margen_izquierdo + 285, margen_superior + aumento + 295, format1)

        e.Graphics.DrawString("CREDITO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 170, margen_superior + aumento + 310)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 220, margen_superior + aumento + 310)
        e.Graphics.DrawString(txt_total_guia_credito_millar.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 285, margen_superior + aumento + 310, format1)
        '*******************************************************************************************************************************************************************
        aumento = 240
        Dim rect_nc As New Rectangle(margen_izquierdo + 10, margen_superior + aumento + 280, margen_izquierdo + 270, margen_superior + 15)
        e.Graphics.DrawString("NOTAS DE CREDITO", Font_texto_titulo, Brushes.Black, rect_nc, stringFormat)

        e.Graphics.DrawString("DESDE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + aumento + 295)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 65, margen_superior + aumento + 295)
        e.Graphics.DrawString(Val(txt_nota_credito_minimo.Text), Font_texto_cabecera, Brushes.Black, margen_izquierdo + 130, margen_superior + aumento + 295, format1)

        e.Graphics.DrawString("CONTADO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + aumento + 310)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 65, margen_superior + aumento + 310)
        e.Graphics.DrawString(txt_total_nota_credito_millar.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 130, margen_superior + aumento + 310, format1)

        e.Graphics.DrawString("DOC. NULOS", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + aumento + 325)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 65, margen_superior + aumento + 325)
        e.Graphics.DrawString(Val(txt_cantidad_notas_credito_anuladas.Text), Font_texto_cabecera, Brushes.Black, margen_izquierdo + 130, margen_superior + aumento + 325, format1)
        '*******************************************************************************************************************************************************************
        e.Graphics.DrawString("HASTA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 170, margen_superior + aumento + 295)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 220, margen_superior + aumento + 295)
        e.Graphics.DrawString(Val(txt_nota_credito_maximo.Text), Font_texto_cabecera, Brushes.Black, margen_izquierdo + 285, margen_superior + aumento + 295, format1)

        e.Graphics.DrawString("CREDITO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 170, margen_superior + aumento + 310)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 220, margen_superior + aumento + 310)
        e.Graphics.DrawString(txt_total_nota_credito_credito_millar.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 285, margen_superior + aumento + 310, format1)
        '*******************************************************************************************************************************************************************
        aumento = 320
        Dim rect_nd As New Rectangle(margen_izquierdo + 10, margen_superior + aumento + 280, margen_izquierdo + 270, margen_superior + 15)
        e.Graphics.DrawString("NOTAS DE DEBITO", Font_texto_titulo, Brushes.Black, rect_nd, stringFormat)

        e.Graphics.DrawString("DESDE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + aumento + 295)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 65, margen_superior + aumento + 295)
        e.Graphics.DrawString(Val(txt_nota_debito_minimo.Text), Font_texto_cabecera, Brushes.Black, margen_izquierdo + 130, margen_superior + aumento + 295, format1)

        e.Graphics.DrawString("CONTADO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + aumento + 310)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 65, margen_superior + aumento + 310)
        e.Graphics.DrawString(txt_total_nota_debito_millar.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 130, margen_superior + aumento + 310, format1)

        e.Graphics.DrawString("DOC. NULOS", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + aumento + 325)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 65, margen_superior + aumento + 325)
        e.Graphics.DrawString(Val(txt_cantidad_notas_debito_anuladas.Text), Font_texto_cabecera, Brushes.Black, margen_izquierdo + 130, margen_superior + aumento + 325, format1)
        '*******************************************************************************************************************************************************************
        e.Graphics.DrawString("HASTA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 170, margen_superior + aumento + 295)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 220, margen_superior + aumento + 295)
        e.Graphics.DrawString(Val(txt_nota_debito_maximo.Text), Font_texto_cabecera, Brushes.Black, margen_izquierdo + 285, margen_superior + aumento + 295, format1)

        e.Graphics.DrawString("CREDITO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 170, margen_superior + aumento + 310)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 220, margen_superior + aumento + 310)
        e.Graphics.DrawString(txt_total_nota_debito_credito_millar.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 285, margen_superior + aumento + 310, format1)
        '*******************************************************************************************************************************************************************
        aumento = 400
        Dim rect_abonos As New Rectangle(margen_izquierdo + 10, margen_superior + aumento + 280, margen_izquierdo + 270, margen_superior + 15)
        e.Graphics.DrawString("ABONOS", Font_texto_titulo, Brushes.Black, rect_abonos, stringFormat)

        e.Graphics.DrawString("DESDE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + aumento + 295)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 65, margen_superior + aumento + 295)
        e.Graphics.DrawString(Val(txt_abono_minimo.Text), Font_texto_cabecera, Brushes.Black, margen_izquierdo + 130, margen_superior + aumento + 295, format1)

        e.Graphics.DrawString("CONTADO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + aumento + 310)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 65, margen_superior + aumento + 310)
        e.Graphics.DrawString(txt_total_abono_contado_millar.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 130, margen_superior + aumento + 310, format1)

        e.Graphics.DrawString("DOC. NULOS", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + aumento + 325)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 65, margen_superior + aumento + 325)
        e.Graphics.DrawString(Val(txt_cantidad_abonos_anuladas.Text), Font_texto_cabecera, Brushes.Black, margen_izquierdo + 130, margen_superior + aumento + 325, format1)
        '*******************************************************************************************************************************************************************
        e.Graphics.DrawString("HASTA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 170, margen_superior + aumento + 295)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 220, margen_superior + aumento + 295)
        e.Graphics.DrawString(Val(txt_abono_maximo.Text), Font_texto_cabecera, Brushes.Black, margen_izquierdo + 285, margen_superior + aumento + 295, format1)

        e.Graphics.DrawString("CREDITO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 170, margen_superior + aumento + 310)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 220, margen_superior + aumento + 310)
        e.Graphics.DrawString(txt_total_abono_credito_millar.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 285, margen_superior + aumento + 310, format1)
        '*******************************************************************************************************************************************************************




        'e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + 405, margen_izquierdo + 295, margen_superior + 405)

        aumento = 0
        Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + aumento + 800, margen_izquierdo + 270, margen_superior + aumento + 15)
        e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)
    End Sub

    Private Sub PrintDocument_carta_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument_carta.PrintPage
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font_titulo As New Font("arial", 12, FontStyle.Regular)
        Dim Font_subtitulo As New Font("arial", 9, FontStyle.Regular)
        Dim Font_subtitulo_negrita As New Font("arial", 9, FontStyle.Bold)
        Dim Font_titulo_columna As New Font("verdana", 6.5, FontStyle.Bold)
        Dim Font_texto_impresion As New Font("verdana", 6.5, FontStyle.Regular)
        Dim Font_campos_superiores As New Font("verdana", 8, FontStyle.Regular)
        Dim Font_datos_empresa As New Font("verdana", 7, FontStyle.Regular)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = -30
        margen_superior = 0

        Try
            e.Graphics.DrawImage(Bytes_Imagen(Imagen_reporte), 560, 10, 260, 70)
        Catch
        End Try

        e.Graphics.DrawString(minombreempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 10)
        e.Graphics.DrawString(migiroempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 20)
        e.Graphics.DrawString(midireccionempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 30)
        e.Graphics.DrawString(micomunaempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 40)
        e.Graphics.DrawString(mitelefonoempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 50)
        e.Graphics.DrawString(mirutempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 60)

        Dim rect1 As New Rectangle(margen_izquierdo + 50, margen_superior + 75, margen_izquierdo + 810, margen_superior + 60)
        Dim rect2 As New Rectangle(margen_izquierdo + 50, margen_superior + 95, margen_izquierdo + 810, margen_superior + 60)
        Dim rect3 As New Rectangle(margen_izquierdo + 50, margen_superior + 110, margen_izquierdo + 810, margen_superior + 60)
        Dim rect4 As New Rectangle(margen_izquierdo + 50, margen_superior + 125, margen_izquierdo + 810, margen_superior + 60)
        Dim rect5 As New Rectangle(margen_izquierdo + 50, margen_superior + 140, margen_izquierdo + 810, margen_superior + 60)

        e.Graphics.DrawString("CUADRATURA DE CAJA (" & Combo_sucursal.Text & ")", Font_titulo, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 115, margen_izquierdo + 865, margen_superior + 115)
        e.Graphics.DrawString("DESDE " & dtp_fecha_caja_desde.Text & " HASTA " & dtp_fecha_caja_hasta.Text, Font_subtitulo, Brushes.Gray, rect2, stringFormat)
        e.Graphics.DrawString("FECHA_EMISION " & Form_menu_principal.dtp_fecha.Text & " A LAS " & Form_menu_principal.lbl_hora.Text, Font_subtitulo, Brushes.Gray, rect3, stringFormat)
        e.Graphics.DrawString("USUARIO " & minombre, Font_subtitulo, Brushes.Gray, rect4, stringFormat)

        e.Graphics.DrawString("DOCUMENTO", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 50, margen_superior + 175)
        e.Graphics.DrawString("DESDE", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 290, margen_superior + 175, format1)
        e.Graphics.DrawString("HASTA", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 420, margen_superior + 175, format1)
        e.Graphics.DrawString("CONTADO", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 550, margen_superior + 175, format1)
        e.Graphics.DrawString("CREDITO", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 680, margen_superior + 175, format1)
        e.Graphics.DrawString("DOC. NULOS", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 810, margen_superior + 175, format1)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 192, margen_izquierdo + 865, margen_superior + 192)

        e.Graphics.DrawString("BOLETAS", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 50, margen_superior + 195)
        e.Graphics.DrawString("FACTURAS", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 50, margen_superior + 215)
        e.Graphics.DrawString("GUIAS", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 50, margen_superior + 235)
        e.Graphics.DrawString("ABONOS", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 50, margen_superior + 255)
        e.Graphics.DrawString("NOTAS DE CREDITO", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 50, margen_superior + 275)
        e.Graphics.DrawString("NOTAS DE DEBITO", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 50, margen_superior + 295)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 312, margen_izquierdo + 865, margen_superior + 312)

        e.Graphics.DrawString(txt_boleta_minimo.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 290, margen_superior + 195, format1)
        e.Graphics.DrawString(txt_factura_minimo.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 290, margen_superior + 215, format1)
        e.Graphics.DrawString(txt_guia_minimo.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 290, margen_superior + 235, format1)
        e.Graphics.DrawString(txt_abono_minimo.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 290, margen_superior + 255, format1)
        e.Graphics.DrawString(txt_nota_credito_minimo.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 290, margen_superior + 275, format1)
        e.Graphics.DrawString(txt_nota_debito_minimo.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 290, margen_superior + 295, format1)

        e.Graphics.DrawString(txt_boleta_maximo.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 420, margen_superior + 195, format1)
        e.Graphics.DrawString(txt_factura_maximo.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 420, margen_superior + 215, format1)
        e.Graphics.DrawString(txt_guia_maximo.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 420, margen_superior + 235, format1)
        e.Graphics.DrawString(txt_abono_maximo.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 420, margen_superior + 255, format1)
        e.Graphics.DrawString(txt_nota_credito_maximo.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 420, margen_superior + 275, format1)
        e.Graphics.DrawString(txt_nota_debito_maximo.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 420, margen_superior + 295, format1)

        e.Graphics.DrawString(txt_total_boleta_contado_millar.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 550, margen_superior + 195, format1)
        e.Graphics.DrawString(txt_total_factura_contado_millar.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 550, margen_superior + 215, format1)
        e.Graphics.DrawString(txt_total_guia_contado_millar.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 550, margen_superior + 235, format1)
        e.Graphics.DrawString(txt_total_abono_contado_millar.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 550, margen_superior + 255, format1)
        e.Graphics.DrawString(txt_total_nota_credito_millar.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 550, margen_superior + 275, format1)
        e.Graphics.DrawString(txt_total_nota_debito_millar.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 550, margen_superior + 295, format1)

        e.Graphics.DrawString(txt_total_boleta_credito_millar.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 680, margen_superior + 195, format1)
        e.Graphics.DrawString(txt_total_factura_credito_millar.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 680, margen_superior + 215, format1)
        e.Graphics.DrawString(txt_total_guia_credito_millar.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 680, margen_superior + 235, format1)
        e.Graphics.DrawString(txt_total_abono_credito_millar.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 680, margen_superior + 255, format1)
        e.Graphics.DrawString(txt_total_nota_credito_credito_millar.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 680, margen_superior + 275, format1)
        e.Graphics.DrawString(txt_total_nota_debito_credito_millar.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 680, margen_superior + 295, format1)

        e.Graphics.DrawString(txt_cantidad_boletas_anuladas.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 810, margen_superior + 195, format1)
        e.Graphics.DrawString(txt_cantidad_facturas_anuladas.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 810, margen_superior + 215, format1)
        e.Graphics.DrawString(txt_cantidad_guias_anuladas.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 810, margen_superior + 235, format1)
        e.Graphics.DrawString(txt_cantidad_abonos_anuladas.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 810, margen_superior + 255, format1)
        e.Graphics.DrawString(txt_cantidad_notas_credito_anuladas.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 810, margen_superior + 275, format1)
        e.Graphics.DrawString(txt_cantidad_notas_debito_anuladas.Text, Font_subtitulo, Brushes.Black, margen_izquierdo + 810, margen_superior + 295, format1)

        Dim total_nulos As String = Val(txt_cantidad_boletas_anuladas.Text) + Val(txt_cantidad_facturas_anuladas.Text) + Val(txt_cantidad_guias_anuladas.Text) + Val(txt_cantidad_abonos_anuladas.Text) + Val(txt_cantidad_notas_credito_anuladas.Text) + Val(txt_cantidad_notas_debito_anuladas.Text)
        e.Graphics.DrawString("TOTALES:", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 420, margen_superior + 315, format1)
        e.Graphics.DrawString(txt_total_contado_millar.Text, Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 550, margen_superior + 315, format1)
        e.Graphics.DrawString(txt_total_credito_millar.Text, Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 680, margen_superior + 315, format1)
        e.Graphics.DrawString(total_nulos, Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 810, margen_superior + 315, format1)

        Dim rect_detalle_caja As New Rectangle(margen_izquierdo + 50, margen_superior + 335, margen_izquierdo + 810, margen_superior + 60)

        e.Graphics.DrawString("DETALLE CAJA", Font_titulo, Brushes.Black, rect_detalle_caja, stringFormat)

        e.Graphics.DrawString("FECHA", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 50, margen_superior + 395)
        e.Graphics.DrawString("TIPO", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 140, margen_superior + 395)
        e.Graphics.DrawString("DETALLE", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 380, margen_superior + 395)
        e.Graphics.DrawString("MONTO", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 810, margen_superior + 395, format1)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 410, margen_izquierdo + 865, margen_superior + 410)

        Dim numero_lineas As Integer = 0
        Dim multiplicador_lineas As Integer = 15
        Dim VarTipoIngreso As String
        Dim VarDetalleIngreso As String
        Dim VarMontoIngreso As String
        Dim VarFechaIngreso As String

        For i = numero_lineas_total To grilla_detalle_caja.Rows.Count - 1
            VarTipoIngreso = grilla_detalle_caja.Rows(i).Cells(0).Value.ToString
            VarDetalleIngreso = grilla_detalle_caja.Rows(i).Cells(1).Value.ToString
            VarMontoIngreso = grilla_detalle_caja.Rows(i).Cells(2).Value.ToString
            VarFechaIngreso = grilla_detalle_caja.Rows(i).Cells(3).Value.ToString

            If VarMontoIngreso = "" Or VarMontoIngreso = "0" Then
                VarMontoIngreso = "0"
            Else
                Try
                    VarMontoIngreso = Format(Int(VarMontoIngreso), "###,###,###")
                Catch
                End Try
            End If

            If VarDetalleIngreso.Length > 30 Then
                VarDetalleIngreso = VarDetalleIngreso.Substring(0, 30)
            End If

            e.Graphics.DrawString(VarFechaIngreso, Font_subtitulo, Brushes.Black, margen_izquierdo + 50, margen_superior + 415 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarTipoIngreso, Font_subtitulo, Brushes.Black, margen_izquierdo + 140, margen_superior + 415 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarDetalleIngreso, Font_subtitulo, Brushes.Black, margen_izquierdo + 380, margen_superior + 415 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarMontoIngreso, Font_subtitulo, Brushes.Black, margen_izquierdo + 810, margen_superior + 415 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************
            'e.Graphics.DrawString(".........................................................................................................................................................................................................................................", Font_texto_impresion, Brushes.Black, margen_izquierdo + 40, margen_superior + 400 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            numero_lineas = numero_lineas + 1
            numero_lineas_total = numero_lineas_total + 1

            If numero_lineas > 85 Then
                'Linea horizontal
                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 420 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 420 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************
                e.HasMorePages = True ' Todavia faltan mas paginas
                Exit Sub
            Else
                e.HasMorePages = False
            End If
        Next

        'Linea horizontal
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 420 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 420 + (numero_lineas * multiplicador_lineas))
        '***************************************************************************************************************************************************

        Dim ingresos As String = Val(txt_total_contado.Text) + Val(txt_total_ingresos.Text)
        Dim gastos As String = Val(txt_total_egresos.Text)
        Dim total As String = Val(txt_total_contado.Text) + Val(txt_total_ingresos.Text) + Val(txt_total_egresos.Text)

        If ingresos = "" Or ingresos = "0" Then
            ingresos = "0"
        Else

            ingresos = Format(Int(ingresos), "###,###,###")
        End If

        If gastos = "" Or gastos = "0" Then
            gastos = "0"
        Else

            gastos = Format(Int(gastos), "###,###,###")
        End If

        If total = "" Or total = "0" Then
            total = "0"
        Else

            total = Format(Int(total), "###,###,###")
        End If

        e.Graphics.DrawString("INGRESOS", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 650, margen_superior + 450 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(":", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 725, margen_superior + 450 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(ingresos, Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 810, margen_superior + 450 + (numero_lineas * multiplicador_lineas), format1)

        e.Graphics.DrawString("EGRESOS", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 650, margen_superior + 465 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(":", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 725, margen_superior + 465 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(gastos, Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 810, margen_superior + 465 + (numero_lineas * multiplicador_lineas), format1)


        e.Graphics.DrawString("TOTAL", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 650, margen_superior + 480 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(":", Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 725, margen_superior + 480 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(total, Font_subtitulo_negrita, Brushes.Black, margen_izquierdo + 810, margen_superior + 480 + (numero_lineas * multiplicador_lineas), format1)

        numero_lineas_total = 0
    End Sub

    Sub cargar_detalle_caja()
        grilla_detalle_caja.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        If Combo_caja.Text = "TODAS" Then
            SC.CommandText = "select tipo, detalle, monto, fecha from detalle_cuadratura_caja where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' order by tipo"
        Else
            SC.CommandText = "select tipo, detalle, monto, fecha from detalle_cuadratura_caja where caja ='" & (Combo_caja.Text) & "' and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' order by tipo"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim MiFechaIngreso As Date
                Dim MiFechaIngreso2 As String
                MiFechaIngreso = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                MiFechaIngreso2 = MiFechaIngreso.ToString("dd-MM-yyy")


                grilla_detalle_caja.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("tipo"), _
                                              DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("monto"), _
                                                MiFechaIngreso2)
            Next
        End If

        If grilla_detalle_caja.Rows.Count <> 0 Then

            If grilla_detalle_caja.Columns(0).Width = 200 Then
                grilla_detalle_caja.Columns(0).Width = 199
            Else
                grilla_detalle_caja.Columns(0).Width = 200
            End If

            grilla_detalle_caja.Columns(1).Width = 250
            grilla_detalle_caja.Columns(2).Width = 70
            grilla_detalle_caja.Columns(3).Width = 100

            grilla_detalle_caja.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_detalle_caja.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_detalle_caja.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_detalle_caja.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
    End Sub
End Class