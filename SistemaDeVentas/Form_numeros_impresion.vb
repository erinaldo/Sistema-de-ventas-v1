Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_numeros_impresion
    ' Dim mifecha2 As String

    Private Sub Form_numeros_impresion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_numeros_impresion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
    Private Sub Form_numeros_impresion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        controles(False, True)
        cargar_logo()
        crear_numero_boleta()
        crear_numero_cotizacion()
        crear_numero_factura()
        crear_numero_guia()
        crear_numero_nota_credito()
        crear_numero_nota_debito()
        crear_numero_letra()
        crear_numero_abono()
        Me.Width = 905
        Me.Height = 308
        Centrar()
    End Sub

    Public Sub Centrar()
        Dim tamaño As Rectangle = My.Computer.Screen.Bounds
        Dim posicionX As Integer = (tamaño.Width - Me.Width) \ 2
        Dim posicionY As Integer = (tamaño.Height - Me.Height) \ 2
        Me.Location = New Point(posicionX, posicionY - 20)
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    'Sub fecha()
    '    Dim mifecha As Date
    '    mifecha = lblfecha.Text
    '    mifecha2 = mifecha.ToString("yyy-MM-dd")
    'End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_modificar.Enabled = b
        btn_guardar.Enabled = a
        btn_cancelar.Enabled = a

        txt_boleta_desde.Enabled = a
        txt_boleta_hasta.Enabled = a
        txt_factura_desde.Enabled = a
        txt_factura_hasta.Enabled = a
        txt_nota_credito_desde.Enabled = a
        txt_nota_credito_hasta.Enabled = a
        txt_guia_desde.Enabled = a
        txt_guia_hasta.Enabled = a
        txt_nota_debito_desde.Enabled = a
        txt_nota_debito_hasta.Enabled = a
        txt_cotizacion_desde.Enabled = a
        txt_cotizacion_hasta.Enabled = a
        txt_abono_desde.Enabled = a
        txt_abono_hasta.Enabled = a
        txt_orden_de_compra_desde.Enabled = a
        txt_orden_de_compra_hasta.Enabled = a
    End Sub


    'permite crear el numero correlativo segun el documento que seleccionemos.
    Sub crear_numero_factura()
        Dim varnumfactura As Integer
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
                varnumfactura = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                'txt_factura.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_factura_desde.Text = 1
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
            SC.CommandText = "select n_factura from factura where cod_auto='" & (varnumfactura) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumfactura = DS.Tables(DT.TableName).Rows(0).Item("n_factura")
                txt_factura_desde.Text = varnumfactura + 1
            End If
        Catch err As InvalidCastException
            txt_factura_desde.Text = 1
        End Try
        conexion.Close()

    End Sub


    'Sub crear_numero_factura_credito()
    '    Dim varnumfacturacredito As Integer
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()
    '    Try
    '        SC.Connection = conexion
    '        SC.CommandText = "select max(n_factura_credito) as n_factura_credito from factura_credito"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)

    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            varnumfacturacredito = DS.Tables(DT.TableName).Rows(0).Item("n_factura_credito")
    '            txt_factura_credito.Text = varnumfacturacredito + 1
    '        End If
    '    Catch err As InvalidCastException
    '        txt_factura_credito.Text = 1
    '    End Try
    '    conexion.Close()
    'End Sub

    Sub crear_numero_guia()
        Dim varnumguia As Integer
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
                varnumguia = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                'txt_factura.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_guia_desde.Text = 1
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
            SC.CommandText = "select n_guia from guia where cod_auto='" & (varnumguia) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumguia = DS.Tables(DT.TableName).Rows(0).Item("n_guia")
                txt_guia_desde.Text = varnumguia + 1
            End If
            Exit Sub
        Catch err As InvalidCastException
            txt_guia_desde.Text = 1
        End Try
        conexion.Close()
    End Sub

    Sub crear_numero_boleta()
        Dim varnumBOLETA As Integer
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
                varnumBOLETA = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                'txt_factura.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_boleta_desde.Text = 1
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
            SC.CommandText = "select n_boleta from BOLETA where cod_auto='" & (varnumBOLETA) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumBOLETA = DS.Tables(DT.TableName).Rows(0).Item("n_boleta")
                txt_boleta_desde.Text = varnumBOLETA + 1
            End If
        Catch err As InvalidCastException
            txt_boleta_desde.Text = 1
        End Try
        conexion.Close()
    End Sub

    Sub crear_numero_nota_credito()
        Dim VarNumNotaCredito As Integer

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(cod_auto) as cod_auto from nota_credito where tipo_impresion <> 'DIGITADA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                VarNumNotaCredito = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
            End If
        Catch err As InvalidCastException
            txt_nota_credito_desde.Text = 1
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
            SC.CommandText = "select n_nota_credito from nota_credito where cod_auto='" & (VarNumNotaCredito) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                VarNumNotaCredito = DS.Tables(DT.TableName).Rows(0).Item("n_nota_credito")
                txt_nota_credito_desde.Text = VarNumNotaCredito + 1
            End If
        Catch err As InvalidCastException
            txt_nota_credito_desde.Text = 1
        End Try
        conexion.Close()
    End Sub

    Sub crear_numero_nota_debito()
        Dim VarNumNotaDebito As Integer

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(cod_auto) as cod_auto from nota_debito where tipo_impresion <> 'DIGITADA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                VarNumNotaDebito = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
            End If
        Catch err As InvalidCastException
            txt_nota_debito_desde.Text = 1
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
            SC.CommandText = "select n_nota_debito from nota_debito where cod_auto='" & (VarNumNotaDebito) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                VarNumNotaDebito = DS.Tables(DT.TableName).Rows(0).Item("n_nota_debito")
                txt_nota_debito_desde.Text = VarNumNotaDebito + 1
            End If
        Catch err As InvalidCastException
            txt_nota_debito_desde.Text = 1
        End Try
        conexion.Close()
    End Sub

    Sub crear_numero_cotizacion()
        Dim varnumcotizacion As Integer
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(cod_auto) as cod_auto from cotizacion"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumcotizacion = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                'txt_factura.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_cotizacion_desde.Text = 1
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
            SC.CommandText = "select n_cotizacion from cotizacion where cod_auto='" & (varnumcotizacion) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumcotizacion = DS.Tables(DT.TableName).Rows(0).Item("n_cotizacion")
                txt_cotizacion_desde.Text = varnumcotizacion + 1
            End If
        Catch err As InvalidCastException
            txt_cotizacion_desde.Text = 1
        End Try
        conexion.Close()
    End Sub


    Sub crear_numero_letra()
        Dim VarNumLetra As Integer
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(cod_auto) as cod_auto from letras"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                VarNumLetra = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                'txt_factura.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_orden_de_compra_desde.Text = 1
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
            SC.CommandText = "select n_letra from letras where cod_auto='" & (VarNumLetra) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                VarNumLetra = DS.Tables(DT.TableName).Rows(0).Item("n_letra")
                txt_orden_de_compra_desde.Text = VarNumLetra + 1
            End If
        Catch err As InvalidCastException
            txt_orden_de_compra_desde.Text = 1
        End Try
        conexion.Close()
    End Sub


    Sub crear_numero_abono()

        Dim varnumdoc As Integer
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(cod_auto) as cod_auto from abono"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                'txt_factura.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_abono_desde.Text = 1
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
            SC.CommandText = "select n_abono from abono where cod_auto='" & (varnumdoc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_abono")
                txt_abono_desde.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_abono_desde.Text = 1
        End Try
        conexion.Close()

    End Sub




    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        If Radio_boleta.Checked = False And Radio_factura.Checked = False And Radio_guia.Checked = False And Radio_cotizacion.Checked = False And Radio_nota_credito.Checked = False And Radio_nota_debito.Checked = False And Radio_abono.Checked = False And Radio_orden_de_compra.Checked = False Then

            MsgBox("DEBE SELECCIONAR UN DOCUMENTO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            crear_numero_boleta()
            crear_numero_cotizacion()
            crear_numero_factura()
            crear_numero_guia()
            crear_numero_nota_credito()
            crear_numero_nota_debito()
            crear_numero_abono()
            crear_numero_letra()

        ElseIf Radio_boleta.Checked = True Then
            txt_boleta_desde.Enabled = True
            txt_boleta_hasta.Enabled = True

            btn_guardar.Enabled = True
            btn_cancelar.Enabled = True
            btn_modificar.Enabled = False

            Radio_factura.Enabled = False
            Radio_nota_credito.Enabled = False
            Radio_guia.Enabled = False
            Radio_cotizacion.Enabled = False
            Radio_nota_credito.Enabled = False
            Radio_nota_debito.Enabled = False
            Radio_abono.Enabled = False
            Radio_orden_de_compra.Enabled = False

            crear_numero_boleta()
            crear_numero_cotizacion()
            crear_numero_factura()
            crear_numero_guia()
            crear_numero_nota_credito()
            crear_numero_nota_debito()
            crear_numero_abono()
            crear_numero_letra()

            txt_boleta_desde.Focus()

        ElseIf Radio_factura.Checked = True Then
            txt_factura_desde.Enabled = True
            txt_factura_hasta.Enabled = True

            btn_guardar.Enabled = True
            btn_cancelar.Enabled = True
            btn_modificar.Enabled = False

            Radio_boleta.Enabled = False
            Radio_nota_credito.Enabled = False
            Radio_guia.Enabled = False
            Radio_cotizacion.Enabled = False
            Radio_nota_credito.Enabled = False
            Radio_nota_debito.Enabled = False
            Radio_abono.Enabled = False
            Radio_orden_de_compra.Enabled = False

            crear_numero_boleta()
            crear_numero_cotizacion()
            crear_numero_factura()
            crear_numero_guia()
            crear_numero_nota_credito()
            crear_numero_nota_debito()
            crear_numero_abono()
            crear_numero_letra()

            txt_factura_desde.Focus()






        ElseIf Radio_guia.Checked = True Then
            txt_guia_desde.Enabled = True
            txt_guia_hasta.Enabled = True

            btn_guardar.Enabled = True
            btn_cancelar.Enabled = True
            btn_modificar.Enabled = False

            Radio_boleta.Enabled = False
            Radio_factura.Enabled = False
            Radio_nota_credito.Enabled = False
            Radio_cotizacion.Enabled = False
            Radio_nota_credito.Enabled = False
            Radio_nota_debito.Enabled = False
            Radio_abono.Enabled = False
            Radio_orden_de_compra.Enabled = False

            crear_numero_boleta()
            crear_numero_cotizacion()
            crear_numero_factura()
            crear_numero_guia()
            crear_numero_nota_credito()
            crear_numero_nota_debito()
            crear_numero_abono()
            crear_numero_letra()

            txt_guia_desde.Focus()


        ElseIf Radio_cotizacion.Checked = True Then
            txt_cotizacion_desde.Enabled = True
            txt_cotizacion_hasta.Enabled = True

            btn_guardar.Enabled = True
            btn_cancelar.Enabled = True
            btn_modificar.Enabled = False

            Radio_boleta.Enabled = False
            Radio_factura.Enabled = False
            Radio_nota_credito.Enabled = False
            Radio_guia.Enabled = False
            Radio_nota_credito.Enabled = False
            Radio_nota_debito.Enabled = False
            Radio_abono.Enabled = False
            Radio_orden_de_compra.Enabled = False

            crear_numero_boleta()
            crear_numero_cotizacion()
            crear_numero_factura()
            crear_numero_guia()
            crear_numero_nota_credito()
            crear_numero_nota_debito()
            crear_numero_abono()
            crear_numero_letra()

            txt_cotizacion_desde.Focus()


        ElseIf Radio_nota_credito.Checked = True Then
            txt_nota_credito_desde.Enabled = True
            txt_nota_credito_hasta.Enabled = True

            btn_guardar.Enabled = True
            btn_cancelar.Enabled = True
            btn_modificar.Enabled = False

            Radio_factura.Enabled = False
            Radio_boleta.Enabled = False
            Radio_cotizacion.Enabled = False
            Radio_guia.Enabled = False
            Radio_nota_debito.Enabled = False
            Radio_abono.Enabled = False
            Radio_orden_de_compra.Enabled = False

            crear_numero_boleta()
            crear_numero_cotizacion()
            crear_numero_factura()
            crear_numero_guia()
            crear_numero_nota_credito()
            crear_numero_nota_debito()
            crear_numero_abono()
            crear_numero_letra()

            txt_nota_credito_desde.Focus()

        ElseIf Radio_nota_debito.Checked = True Then
            txt_nota_debito_desde.Enabled = True
            txt_nota_debito_hasta.Enabled = True

            btn_guardar.Enabled = True
            btn_cancelar.Enabled = True
            btn_modificar.Enabled = False

            Radio_nota_credito.Enabled = False
            Radio_factura.Enabled = False
            Radio_boleta.Enabled = False
            Radio_cotizacion.Enabled = False
            Radio_guia.Enabled = False
            Radio_nota_credito.Enabled = False
            Radio_abono.Enabled = False
            Radio_orden_de_compra.Enabled = False

            crear_numero_boleta()
            crear_numero_cotizacion()
            crear_numero_factura()
            crear_numero_guia()
            crear_numero_nota_credito()
            crear_numero_nota_debito()
            crear_numero_abono()
            crear_numero_letra()

            txt_nota_debito_desde.Focus()




        ElseIf Radio_abono.Checked = True Then
            txt_abono_desde.Enabled = True
            txt_abono_hasta.Enabled = True

            btn_guardar.Enabled = True
            btn_cancelar.Enabled = True
            btn_modificar.Enabled = False

            Radio_nota_credito.Enabled = False
            Radio_factura.Enabled = False
            Radio_boleta.Enabled = False
            Radio_cotizacion.Enabled = False
            Radio_guia.Enabled = False
            Radio_nota_credito.Enabled = False
            Radio_nota_debito.Enabled = False
            Radio_orden_de_compra.Enabled = False

            crear_numero_boleta()
            crear_numero_cotizacion()
            crear_numero_factura()
            crear_numero_guia()
            crear_numero_nota_credito()
            crear_numero_nota_debito()
            crear_numero_abono()
            crear_numero_letra()

            txt_abono_desde.Focus()



        ElseIf Radio_orden_de_compra.Checked = True Then
            txt_orden_de_compra_desde.Enabled = True
            txt_orden_de_compra_hasta.Enabled = True

            btn_guardar.Enabled = True
            btn_cancelar.Enabled = True
            btn_modificar.Enabled = False

            Radio_nota_credito.Enabled = False
            Radio_factura.Enabled = False
            Radio_boleta.Enabled = False
            Radio_cotizacion.Enabled = False
            Radio_guia.Enabled = False
            Radio_nota_credito.Enabled = False
            Radio_nota_debito.Enabled = False
            Radio_abono.Enabled = False

            crear_numero_boleta()
            crear_numero_cotizacion()
            crear_numero_factura()
            crear_numero_guia()
            crear_numero_nota_credito()
            crear_numero_nota_debito()
            crear_numero_abono()
            crear_numero_letra()

            txt_orden_de_compra_desde.Focus()
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        controles(False, True)

        Radio_boleta.Enabled = True
        Radio_factura.Enabled = True
        Radio_nota_credito.Enabled = True
        Radio_cotizacion.Enabled = True
        Radio_guia.Enabled = True
        Radio_nota_credito.Enabled = True
        Radio_nota_debito.Enabled = True
        Radio_orden_de_compra.Enabled = True
        Radio_abono.Enabled = True

        crear_numero_boleta()
        crear_numero_cotizacion()
        crear_numero_factura()
        crear_numero_guia()
        crear_numero_nota_credito()
        crear_numero_guia()
        crear_numero_nota_debito()
        crear_numero_abono()
        crear_numero_letra()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        'If txt_boleta_desde.Text = "" Then
        '    txt_boleta_desde.Focus()
        '    MsgBox("CAMPO BOLETA DESDE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_boleta_hasta.Text = "" Then
        '    txt_boleta_hasta.Focus()
        '    MsgBox("CAMPO BOLETA HASTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_factura_desde.Text = "" Then
        '    txt_factura_desde.Focus()
        '    MsgBox("CAMPO FACTURA DESDE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_factura_hasta.Text = "" Then
        '    txt_factura_hasta.Focus()
        '    MsgBox("CAMPO FACTURA HASTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_guia_desde.Text = "" Then
        '    txt_guia_desde.Focus()
        '    MsgBox("CAMPO GUIA DESDE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_guia_hasta.Text = "" Then
        '    txt_guia_hasta.Focus()
        '    MsgBox("CAMPO GUIA HASTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_nota_credito_desde.Text = "" Then
        '    txt_nota_credito_desde.Focus()
        '    MsgBox("CAMPO NOTA DE CREDITO DESDE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_nota_credito_hasta.Text = "" Then
        '    txt_nota_credito_hasta.Focus()
        '    MsgBox("CAMPO NOTA DE CREDITO HASTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_nota_debito_desde.Text = "" Then
        '    txt_nota_debito_desde.Focus()
        '    MsgBox("CAMPO NOTA DE DEBITO DESDE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_nota_debito_hasta.Text = "" Then
        '    txt_nota_debito_hasta.Focus()
        '    MsgBox("CAMPO NOTA DE DEBITO HASTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_cotizacion_desde.Text = "" Then
        '    txt_cotizacion_desde.Focus()
        '    MsgBox("CAMPO COTIZACION DESDE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_cotizacion_hasta.Text = "" Then
        '    txt_cotizacion_hasta.Focus()
        '    MsgBox("CAMPO COTIZACION HASTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_orden_de_compra_desde.Text = "" Then
        '    txt_orden_de_compra_desde.Focus()
        '    MsgBox("CAMPO ORDEN DE COMPRA DESDE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_orden_de_compra_hasta.Text = "" Then
        '    txt_orden_de_compra_hasta.Focus()
        '    MsgBox("CAMPO ORDEN DE COMPRA HASTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_abono_desde.Text = "" Then
        '    txt_abono_desde.Focus()
        '    MsgBox("CAMPO ABONO DESDE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        'If txt_abono_hasta.Text = "" Then
        '    txt_abono_hasta.Focus()
        '    MsgBox("CAMPO ABONO HASTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If


        'Dim mensaje As String = ""
        'fecha()

        If Radio_boleta.Checked = True Then

            If txt_boleta_desde.Text = "" Then
                txt_boleta_desde.Focus()
                MsgBox("CAMPO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            SC.Connection = conexion
            SC.CommandText = "insert into BOLETA (n_boleta, tipo, rut_cliente, fecha_venta, descuento, neto, iva,  subtotal, total, condiciones,estado, usuario_responsable, codigo_cliente, hora, porcentaje_desc, tipo_impresion, pie, condicion_de_pago_pie, comision) values (" & (txt_boleta_desde.Text - 1) & " , 'AJUSTE','" & (miusuario) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','0','0','0','0','0','AJUSTE','AJUSTE','" & (miusuario) & "','0','" & (Form_menu_principal.lbl_hora.Text) & "','0','-','0','-','0')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            controles(False, True)

            MsgBox("NUMERO MODIFICADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

            crear_numero_boleta()
            crear_numero_cotizacion()
            crear_numero_factura()
            crear_numero_guia()
            crear_numero_nota_credito()
            crear_numero_guia()
            crear_numero_nota_debito()
            crear_numero_abono()
            crear_numero_letra()

            Radio_factura.Enabled = True
            Radio_nota_credito.Enabled = True
            Radio_guia.Enabled = True
            Radio_cotizacion.Enabled = True
            Radio_boleta.Enabled = True
            Radio_nota_credito.Enabled = True
            Radio_nota_debito.Enabled = True
            Radio_abono.Enabled = True
            Radio_orden_de_compra.Enabled = True
        End If



        If Radio_factura.Checked = True Then

            If txt_factura_desde.Text = "" Then
                txt_factura_desde.Focus()
                MsgBox("CAMPO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            SC.Connection = conexion
            SC.CommandText = "insert into factura (n_factura, TIPO, rut_cliente, fecha_venta, descuento, neto, iva,  subtotal, total, condiciones,estado, usuario_responsable, codigo_cliente, hora, porcentaje_desc, rut_retira, nombre_retira, recinto, orden, tipo_impresion, pie, condicion_de_pago_pie, comision) values (" & (txt_factura_desde.Text - 1) & " , 'AJUSTE','" & (miusuario) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','0','0','0','0','0','AJUSTE','AJUSTE','" & (miusuario) & "','0','" & (Form_menu_principal.lbl_hora.Text) & "','0','-','-','" & (mirecintoempresa) & "','0','-','0','-','0')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            controles(False, True)

            MsgBox("NUMERO MODIFICADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

            crear_numero_boleta()
            crear_numero_cotizacion()
            crear_numero_factura()
            crear_numero_guia()
            crear_numero_nota_credito()
            crear_numero_guia()
            crear_numero_nota_debito()
            crear_numero_abono()
            crear_numero_letra()

            Radio_factura.Enabled = True
            Radio_nota_credito.Enabled = True
            Radio_guia.Enabled = True
            Radio_cotizacion.Enabled = True
            Radio_boleta.Enabled = True
            Radio_nota_credito.Enabled = True
            Radio_nota_debito.Enabled = True
            Radio_abono.Enabled = True
            Radio_orden_de_compra.Enabled = True
        End If



        If Radio_guia.Checked = True Then

            If txt_guia_desde.Text = "" Then
                txt_guia_desde.Focus()
                MsgBox("CAMPO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            SC.Connection = conexion
            SC.CommandText = "insert into guia (n_guia, TIPO, rut_cliente, fecha_venta, descuento, neto, iva,  subtotal, total, condiciones,estado, usuario_responsable, codigo_cliente, hora, porcentaje_desc, rut_retira, nombre_retira, recinto, orden, tipo_impresion, pie, condicion_de_pago_pie, comision, vehiculo, patente) values (" & (txt_guia_desde.Text - 1) & " , 'AJUSTE','" & (miusuario) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','0','0','0','0','0','AJUSTE','AJUSTE','" & (miusuario) & "','0','" & (Form_menu_principal.lbl_hora.Text) & "','0','-','-','" & (mirecintoempresa) & "','0','-','0','-','0','-','-')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            controles(False, True)

            MsgBox("NUMERO MODIFICADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

            crear_numero_boleta()
            crear_numero_cotizacion()
            crear_numero_factura()
            crear_numero_guia()
            crear_numero_nota_credito()
            crear_numero_guia()
            crear_numero_nota_debito()
            crear_numero_abono()
            crear_numero_letra()

            Radio_factura.Enabled = True
            Radio_nota_credito.Enabled = True
            Radio_guia.Enabled = True
            Radio_cotizacion.Enabled = True
            Radio_boleta.Enabled = True
            Radio_nota_credito.Enabled = True
            Radio_nota_debito.Enabled = True
            Radio_abono.Enabled = True
            Radio_orden_de_compra.Enabled = True
        End If




        If Radio_cotizacion.Checked = True Then

            If txt_cotizacion_desde.Text = "" Then
                txt_cotizacion_desde.Focus()
                MsgBox("CAMPO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            SC.Connection = conexion
            SC.CommandText = "insert into cotizacion (n_cotizacion, TIPO, rut_cliente, fecha_venta, descuento, neto, iva,  subtotal, total, condiciones, usuario_responsable, codigo_cliente, hora, porcentaje_desc) values (" & (txt_cotizacion_desde.Text - 1) & " , 'AJUSTE','" & (miusuario) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','0',  '0',  '0',   '0',    '0', 'AJUSTE','" & (miusuario) & "','0','" & (Form_menu_principal.lbl_hora.Text) & "','0')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            controles(False, True)

            MsgBox("NUMERO MODIFICADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            crear_numero_boleta()
            crear_numero_cotizacion()
            crear_numero_factura()
            crear_numero_guia()
            crear_numero_nota_credito()
            crear_numero_guia()
            crear_numero_nota_debito()
            crear_numero_abono()
            crear_numero_letra()

            Radio_factura.Enabled = True
            Radio_nota_credito.Enabled = True
            Radio_guia.Enabled = True
            Radio_cotizacion.Enabled = True
            Radio_boleta.Enabled = True
            Radio_nota_credito.Enabled = True
            Radio_nota_debito.Enabled = True
            Radio_abono.Enabled = True
            Radio_orden_de_compra.Enabled = True
        End If





        If Radio_nota_credito.Checked = True Then

            If txt_nota_credito_desde.Text = "" Then
                txt_nota_credito_desde.Focus()
                MsgBox("CAMPO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            SC.Connection = conexion
            SC.CommandText = "insert into nota_credito (n_nota_credito, TIPO, rut_cliente, fecha_venta, descuento, neto, iva,  subtotal, total, condiciones,estado, usuario_responsable, codigo_cliente, hora, porcentaje_desc, rut_retira, nombre_retira, recinto, tipo_documento, nro_documento, vendedor, fecha_ingreso, tipo_impresion) values (" & (txt_nota_credito_desde.Text - 1) & " , 'AJUSTE','" & (miusuario) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','0','0','0','0','0','AJUSTE','AJUSTE','" & (miusuario) & "','0','" & (Form_menu_principal.lbl_hora.Text) & "','0','-','-','" & (mirecintoempresa) & "','-','0','-','" & (Form_menu_principal.dtp_fecha.Text) & "','-')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            controles(False, True)

            MsgBox("NUMERO MODIFICADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

            crear_numero_boleta()
            crear_numero_cotizacion()
            crear_numero_factura()
            crear_numero_guia()
            crear_numero_nota_credito()
            crear_numero_guia()
            crear_numero_nota_debito()
            crear_numero_abono()
            crear_numero_letra()

            Radio_factura.Enabled = True
            Radio_nota_credito.Enabled = True
            Radio_guia.Enabled = True
            Radio_cotizacion.Enabled = True
            Radio_boleta.Enabled = True
            Radio_nota_credito.Enabled = True
            Radio_nota_debito.Enabled = True
            Radio_abono.Enabled = True
            Radio_orden_de_compra.Enabled = True
        End If






        If Radio_nota_debito.Checked = True Then

            If txt_nota_debito_desde.Text = "" Then
                txt_nota_debito_desde.Focus()
                MsgBox("CAMPO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            SC.Connection = conexion
            SC.CommandText = "insert into nota_debito (n_nota_debito, TIPO, rut_cliente, fecha_venta, descuento, neto, iva,  subtotal, total, condiciones,estado, usuario_responsable, codigo_cliente, hora, porcentaje_desc, rut_retira, nombre_retira, recinto, tipo_documento, nro_documento, vendedor, fecha_ingreso, tipo_impresion) values (" & (txt_nota_debito_desde.Text - 1) & " , 'AJUSTE','" & (miusuario) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','0','0','0','0','0','AJUSTE','AJUSTE','" & (miusuario) & "','0','" & (Form_menu_principal.lbl_hora.Text) & "','0','-','-','" & (mirecintoempresa) & "','-','0','-','" & (Form_menu_principal.dtp_fecha.Text) & "','-')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            controles(False, True)

            MsgBox("NUMERO MODIFICADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

            crear_numero_boleta()
            crear_numero_cotizacion()
            crear_numero_factura()
            crear_numero_guia()
            crear_numero_nota_credito()
            crear_numero_guia()
            crear_numero_nota_debito()
            crear_numero_abono()
            crear_numero_letra()

            Radio_factura.Enabled = True
            Radio_nota_credito.Enabled = True
            Radio_guia.Enabled = True
            Radio_cotizacion.Enabled = True
            Radio_boleta.Enabled = True
            Radio_nota_credito.Enabled = True
            Radio_nota_debito.Enabled = True
            Radio_abono.Enabled = True
            Radio_orden_de_compra.Enabled = True
        End If


        If Radio_abono.Checked = True Then

            If txt_abono_desde.Text = "" Then
                txt_abono_desde.Focus()
                MsgBox("CAMPO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            SC.Connection = conexion
            SC.CommandText = "insert into abono (n_abono, TIPO, rut_cliente, fecha, monto_abono, condicion_abono,estado, usuario_responsable, codigo_cliente, nombre, detalle_abono, hora) values (" & (txt_abono_desde.Text - 1) & " , 'AJUSTE','" & (miusuario) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','0','AJUSTE','AJUSTE','" & (miusuario) & "','0','AJUSTE','AJUSTE','" & (Form_menu_principal.lbl_hora.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            controles(False, True)

            MsgBox("NUMERO MODIFICADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

            crear_numero_boleta()
            crear_numero_cotizacion()
            crear_numero_factura()
            crear_numero_guia()
            crear_numero_nota_credito()
            crear_numero_guia()
            crear_numero_nota_debito()
            crear_numero_abono()
            crear_numero_letra()

            Radio_factura.Enabled = True
            Radio_nota_credito.Enabled = True
            Radio_guia.Enabled = True
            Radio_cotizacion.Enabled = True
            Radio_boleta.Enabled = True
            Radio_nota_credito.Enabled = True
            Radio_nota_debito.Enabled = True
            Radio_abono.Enabled = True
            Radio_orden_de_compra.Enabled = True
        End If







        If Radio_orden_de_compra.Checked = True Then

            If txt_orden_de_compra_desde.Text = "" Then
                txt_orden_de_compra_desde.Focus()
                MsgBox("CAMPO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If



            SC.Connection = conexion
            SC.CommandText = "insert into letras (n_letra, cant_letras, doc_referencia, nro_referencia, fecha, rut_cliente, monto_letra, total_letra, estado, usuario_responsable, fecha_vencimiento, orden_letras, total_doc_referencia) values (" & (txt_orden_de_compra_desde.Text - 1) & " , '0', 'AJUSTE','0','" & (Form_menu_principal.dtp_fecha.Text) & "','" & (miusuario) & "','0', '0', 'AJUSTE', '" & (miusuario) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','0', '0')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            controles(False, True)

            MsgBox("NUMERO MODIFICADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

            crear_numero_boleta()
            crear_numero_cotizacion()
            crear_numero_factura()
            crear_numero_guia()
            crear_numero_nota_credito()
            crear_numero_guia()
            crear_numero_nota_debito()
            crear_numero_abono()
            crear_numero_letra()

            Radio_factura.Enabled = True
            Radio_nota_credito.Enabled = True
            Radio_guia.Enabled = True
            Radio_cotizacion.Enabled = True
            Radio_boleta.Enabled = True
            Radio_nota_credito.Enabled = True
            Radio_nota_debito.Enabled = True
            Radio_abono.Enabled = True
            Radio_orden_de_compra.Enabled = True
        End If
    End Sub

    Private Sub txt_boleta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_boleta_desde.KeyPress


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

    End Sub

    Private Sub txt_boleta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_boleta_desde.TextChanged

    End Sub

    Private Sub txt_factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_factura_desde.KeyPress

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

    End Sub

    Private Sub txt_factura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_factura_desde.TextChanged

    End Sub

    Private Sub txt_factura_credito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub txt_factura_credito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_guia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_guia_desde.KeyPress

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

    End Sub

    Private Sub txt_guia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_guia_desde.TextChanged

    End Sub

    Private Sub txt_cotizacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cotizacion_desde.KeyPress

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

    End Sub


    Private Sub ACercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub


    Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
        color_foco()
    End Sub

    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        color_foco()
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        color_foco()
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        color_foco()
    End Sub

    Private Sub txt_boleta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_boleta_desde.GotFocus
        color_foco()
    End Sub

    Private Sub txt_boleta_hasta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_boleta_hasta.GotFocus
        color_foco()
    End Sub

    Private Sub txt_letra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_orden_de_compra_desde.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_letra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_orden_de_compra_desde.LostFocus
        txt_orden_de_compra_desde.BackColor = Color.White
    End Sub

    Private Sub txt_letra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_orden_de_compra_desde.GotFocus
        color_foco()
    End Sub


    Private Sub txt_abono_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_abono_desde.GotFocus
        color_foco()
    End Sub

    Private Sub txt_abono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_abono_desde.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cotizacion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cotizacion_desde.GotFocus
        color_foco()
    End Sub

    Private Sub txt_factura_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_factura_desde.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nota_credito_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nota_credito_desde.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nota_credito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nota_credito_desde.KeyPress
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

    Private Sub txt_nota_credito_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nota_credito_desde.LostFocus
        txt_nota_credito_desde.BackColor = Color.WhiteSmoke
    End Sub

    'Private Sub txt_factura_credito_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_factura_credito.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub txt_factura_credito_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_factura_credito.BackColor = Color.WhiteSmoke
    'End Sub

    Private Sub txt_guia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_guia_desde.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nota_debito_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nota_debito_desde.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nota_credito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nota_credito_desde.TextChanged

    End Sub

    Private Sub txt_letra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_orden_de_compra_desde.TextChanged

    End Sub

    Private Sub txt_abono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_abono_desde.TextChanged

    End Sub

    Private Sub txt_cotizacion_TextChanged(sender As Object, e As EventArgs) Handles txt_cotizacion_desde.TextChanged

    End Sub

    Private Sub Radio_boleta_CheckedChanged(sender As Object, e As EventArgs) Handles Radio_boleta.CheckedChanged

    End Sub

    Private Sub txt_nota_debito_desde_TextChanged(sender As Object, e As EventArgs) Handles txt_nota_debito_desde.TextChanged

    End Sub

    Private Sub txt_nota_debito_desde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nota_debito_desde.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_abono_hasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_abono_hasta.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_orden_de_compra_hasta_TextChanged(sender As Object, e As EventArgs) Handles txt_orden_de_compra_hasta.TextChanged

    End Sub

    Private Sub txt_orden_de_compra_hasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_orden_de_compra_hasta.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cotizacion_hasta_TextChanged(sender As Object, e As EventArgs) Handles txt_cotizacion_hasta.TextChanged

    End Sub

    Private Sub txt_cotizacion_hasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cotizacion_hasta.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_nota_debito_hasta_TextChanged(sender As Object, e As EventArgs) Handles txt_nota_debito_hasta.TextChanged

    End Sub

    Private Sub txt_nota_debito_hasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nota_debito_hasta.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_nota_debito_hasta_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_nota_debito_hasta.KeyUp

    End Sub

    Private Sub txt_nota_credito_hasta_TextChanged(sender As Object, e As EventArgs) Handles txt_nota_credito_hasta.TextChanged

    End Sub

    Private Sub txt_nota_credito_hasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nota_credito_hasta.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_guia_hasta_TextChanged(sender As Object, e As EventArgs) Handles txt_guia_hasta.TextChanged

    End Sub

    Private Sub txt_guia_hasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_guia_hasta.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_factura_hasta_TextChanged(sender As Object, e As EventArgs) Handles txt_factura_hasta.TextChanged

    End Sub

    Private Sub txt_factura_hasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_factura_hasta.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_boleta_hasta_TextChanged(sender As Object, e As EventArgs) Handles txt_boleta_hasta.TextChanged

    End Sub

    Private Sub txt_boleta_hasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_boleta_hasta.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Sub color_foco()
        Dim controlcito As Control
        Dim controlChild As Control

        For Each controlcito In Me.Controls
            If TypeOf controlcito Is TextBox Then
                If CType(controlcito, TextBox).ReadOnly = False Then
                    CType(controlcito, TextBox).BackColor = Color.White
                End If
            End If

            If TypeOf controlcito Is ComboBox Then
                CType(controlcito, ComboBox).BackColor = Color.White
            End If

            If TypeOf controlcito Is Button Then
                CType(controlcito, Button).BackColor = Color.Transparent
            End If

            If TypeOf controlcito Is GroupBox Then
                For Each controlChild In controlcito.Controls
                    If TypeOf controlChild Is TextBox Then
                        If CType(controlChild, TextBox).ReadOnly = False Then
                            CType(controlChild, TextBox).BackColor = Color.White
                        End If
                    End If

                    If TypeOf controlChild Is ComboBox Then
                        CType(controlChild, ComboBox).BackColor = Color.White
                    End If

                    If TypeOf controlChild Is Button Then
                        CType(controlChild, Button).BackColor = Color.Transparent
                    End If
                Next
            End If
        Next

        For Each controlcito In Me.Controls
            If TypeOf controlcito Is TextBox Then
                If CType(controlcito, TextBox).Focused Then
                    If CType(controlcito, TextBox).ReadOnly = False Then
                        CType(controlcito, TextBox).BackColor = Color.LightSkyBlue
                        Exit Sub
                    End If
                End If
            End If

            If TypeOf controlcito Is ComboBox Then
                If CType(controlcito, ComboBox).Focused Then
                    CType(controlcito, ComboBox).BackColor = Color.LightSkyBlue
                    Exit Sub
                End If
            End If

            If TypeOf controlcito Is Button Then
                If CType(controlcito, Button).Focused Then
                    CType(controlcito, Button).BackColor = Color.LightSkyBlue
                    Exit Sub
                End If
            End If

            If TypeOf controlcito Is GroupBox Then
                For Each controlChild In controlcito.Controls
                    If TypeOf controlChild Is TextBox Then
                        If CType(controlChild, TextBox).Focused Then
                            If CType(controlChild, TextBox).ReadOnly = False Then
                                CType(controlChild, TextBox).BackColor = Color.LightSkyBlue
                                Exit Sub
                            End If
                        End If
                    End If

                    If TypeOf controlChild Is ComboBox Then
                        If CType(controlChild, ComboBox).Focused Then
                            CType(controlChild, ComboBox).BackColor = Color.LightSkyBlue
                            Exit Sub
                        End If
                    End If

                    If TypeOf controlChild Is Button Then
                        If CType(controlChild, Button).Focused Then
                            CType(controlChild, Button).BackColor = Color.LightSkyBlue
                            Exit Sub
                        End If
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub txt_factura_hasta_GotFocus(sender As Object, e As EventArgs) Handles txt_factura_hasta.GotFocus
        color_foco()
    End Sub

    Private Sub txt_guia_hasta_GotFocus(sender As Object, e As EventArgs) Handles txt_guia_hasta.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nota_credito_hasta_GotFocus(sender As Object, e As EventArgs) Handles txt_nota_credito_hasta.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nota_debito_hasta_GotFocus(sender As Object, e As EventArgs) Handles txt_nota_debito_hasta.GotFocus
        color_foco()
    End Sub

    Private Sub txt_cotizacion_hasta_GotFocus(sender As Object, e As EventArgs) Handles txt_cotizacion_hasta.GotFocus
        color_foco()
    End Sub

    Private Sub txt_orden_de_compra_hasta_GotFocus(sender As Object, e As EventArgs) Handles txt_orden_de_compra_hasta.GotFocus
        color_foco()
    End Sub

    Private Sub txt_abono_hasta_TextChanged(sender As Object, e As EventArgs) Handles txt_abono_hasta.TextChanged

    End Sub

    Private Sub txt_abono_hasta_GotFocus(sender As Object, e As EventArgs) Handles txt_abono_hasta.GotFocus
        color_foco()
    End Sub
End Class