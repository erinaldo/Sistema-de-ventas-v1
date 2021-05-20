Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_impresoras
    Private Sub Form_impresoras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_impresoras_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
            'mostrar_cierre_sistema()
            Form_menu_principal.Close()
        End If
    End Sub

    Private Sub Form_impresoras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        controles(False, True)
        cargar_impresoras()
        mostrar_impresoras()
        cargar_logo()

        Me.Width = 677
        Me.Height = 728
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

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_modificar.Enabled = b
        btn_guardar.Enabled = a
        btn_cancelar.Enabled = a

        Combo_impresora_boletas.Enabled = a
        Combo_impresora_facturas.Enabled = a
        Combo_impresora_guias.Enabled = a
        Combo_impresora_etiquetas_1.Enabled = a
        Combo_impresora_etiquetas_2.Enabled = a

        combo_impresora_abonos.Enabled = a
        combo_impresora_anticipos.Enabled = a
        combo_impresora_caja.Enabled = a
        combo_impresora_tarjeta_rapida.Enabled = a
        combo_impresora_cotizaciones.Enabled = a
        combo_impresora_estados_de_cuenta.Enabled = a
        Combo_impresora_pedidos.Enabled = a
        combo_impresora_ticket_de_ventas.Enabled = a
        combo_impresora_registro_cheques.Enabled = a
        combo_impresora_vales_de_cambio.Enabled = a
        combo_impresora_envio_sucursal.Enabled = a
        combo_impresora_consumo_interno.Enabled = a
        combo_impresora_nota_de_credito.Enabled = a
        combo_impresora_nota_de_debito.Enabled = a


        Combo_tipo_impresion_boletas.Enabled = a
        Combo_tipo_impresion_facturas.Enabled = a
        Combo_tipo_impresion_guias.Enabled = a
        Combo_tipo_impresion_notas_de_credito.Enabled = a
        Combo_tipo_impresion_notas_de_debito.Enabled = a



        txt_margen_abonos.Enabled = a
        txt_margen_anticipos.Enabled = a
        txt_margen_boletas.Enabled = a
        txt_margen_caja.Enabled = a
        txt_margen_consumo_interno.Enabled = a
        txt_margen_cotizaciones.Enabled = a
        txt_margen_envios_a_sucursal.Enabled = a
        txt_margen_estado_de_cuenta.Enabled = a
        txt_margen_etiquetas_1.Enabled = a
        txt_margen_etiquetas_2.Enabled = a
        txt_margen_facturas.Enabled = a
        txt_margen_guias.Enabled = a
        txt_margen_nb.Enabled = a

        txt_margen_nc.Enabled = a
        txt_margen_pedidos.Enabled = a

        txt_margen_tarjeta_rapida.Enabled = a
        txt_margen_ticket_de_cheques.Enabled = a
        txt_margen_ticket_de_ventas.Enabled = a
        txt_margen_vales_de_cambio.Enabled = a





        'combo_impresora_reportes.Enabled = a

        radio_directa.Enabled = a
        radio_ticket.Enabled = a

        'GroupBox_datos.Enabled = a
        GroupBox_electronicas.Enabled = a

        Check_boletas_electronicas.Enabled = a
        Check_facturas_electronica.Enabled = a
        Check_guia_electronica.Enabled = a
        Check_nota_credito_electronica.Enabled = a
        Check_nota_debito_electronica.Enabled = a
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click

        mostrar_impresoras()
        controles(True, False)
        Combo_impresora_boletas.Focus()

    End Sub


    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        controles(False, True)
        'Radio_boleta_manual.Enabled = True
        'Radio_factura_manual.Enabled = True
        'Radio_factura_credito.Enabled = True
        'Radio_cotizacion.Enabled = True
        'Radio_guia_manual.Enabled = True
        'Radio_etiquetas.Enabled = True
        'Radio_ticket.Enabled = True
        mostrar_impresoras()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        Dim tipo_impresion As String = ""

        If Combo_impresora_boletas.Text = "" Then
            Combo_impresora_boletas.Focus()
            MsgBox("CAMPO IMPRESORA DE BOLETAS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If Combo_impresora_facturas.Text = "" Then
            Combo_impresora_facturas.Focus()
            MsgBox("CAMPO IMPRESORA DE FACTURAS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If Combo_impresora_guias.Text = "" Then
            Combo_impresora_guias.Focus()
            MsgBox("CAMPO IMPRESORA DE GUIAS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_impresora_nota_de_credito.Text = "" Then
            combo_impresora_nota_de_credito.Focus()
            MsgBox("CAMPO IMPRESORA DE NOTAS DE CREDITO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If


        If combo_impresora_nota_de_debito.Text = "" Then
            combo_impresora_nota_de_debito.Focus()
            MsgBox("CAMPO IMPRESORA DE NOTAS DE DEBITO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If Combo_impresora_etiquetas_1.Text = "" Then
            Combo_impresora_etiquetas_1.Focus()
            MsgBox("CAMPO IMPRESORA DE ETIQUETAS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If Combo_impresora_etiquetas_2.Text = "" Then
            Combo_impresora_etiquetas_2.Focus()
            MsgBox("CAMPO IMPRESORA DE ETIQUETAS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_impresora_cotizaciones.Text = "" Then
            combo_impresora_cotizaciones.Focus()
            MsgBox("CAMPO IMPRESORA DE COTIZACIONES VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_impresora_abonos.Text = "" Then
            combo_impresora_abonos.Focus()
            MsgBox("CAMPO IMPRESORA DE ABONOS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_impresora_anticipos.Text = "" Then
            combo_impresora_anticipos.Focus()
            MsgBox("CAMPO IMPRESORA DE ANTICIPOS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_impresora_caja.Text = "" Then
            combo_impresora_caja.Focus()
            MsgBox("CAMPO IMPRESORA DE CAJA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_impresora_estados_de_cuenta.Text = "" Then
            combo_impresora_estados_de_cuenta.Focus()
            MsgBox("CAMPO IMPRESORA DE CAJA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_impresora_ticket_de_ventas.Text = "" Then
            combo_impresora_estados_de_cuenta.Focus()
            MsgBox("CAMPO IMPRESORA DE CAJA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_impresora_envio_sucursal.Text = "" Then
            combo_impresora_envio_sucursal.Focus()
            MsgBox("CAMPO IMPRESORA DE ENVIOS A SUCURSAL VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_impresora_vales_de_cambio.Text = "" Then
            combo_impresora_vales_de_cambio.Focus()
            MsgBox("CAMPO IMPRESORA DE VALES DE CAMBIO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_impresora_tarjeta_rapida.Text = "" Then
            combo_impresora_tarjeta_rapida.Focus()
            MsgBox("CAMPO IMPRESORA DE ANTICIPOS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If Combo_impresora_pedidos.Text = "" Then
            Combo_impresora_pedidos.Focus()
            MsgBox("CAMPO IMPRESORA DE PEDIDOS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_impresora_registro_cheques.Text = "" Then
            combo_impresora_registro_cheques.Focus()
            MsgBox("CAMPO IMPRESORA DE CAJA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_impresora_consumo_interno.Text = "" Then
            combo_impresora_consumo_interno.Focus()
            MsgBox("CAMPO IMPRESORA DE CONSUMO INTERNO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_margen_etiquetas_1.Text = "" Then
            txt_margen_etiquetas_1.Focus()
            MsgBox("CAMPO MARGEN IMPRESORA DE ETIQUETAS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_margen_etiquetas_2.Text = "" Then
            txt_margen_etiquetas_2.Focus()
            MsgBox("CAMPO MARGEN IMPRESORA DE ETIQUETAS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        Combo_impresora_boletas.Text = Trim(Replace(Combo_impresora_boletas.Text, "\", "\\"))
        Combo_impresora_guias.Text = Trim(Replace(Combo_impresora_guias.Text, "\", "\\"))
        Combo_impresora_facturas.Text = Trim(Replace(Combo_impresora_facturas.Text, "\", "\\"))
        combo_impresora_nota_de_credito.Text = Trim(Replace(combo_impresora_nota_de_credito.Text, "\", "\\"))
        combo_impresora_nota_de_debito.Text = Trim(Replace(combo_impresora_nota_de_debito.Text, "\", "\\"))

        Combo_impresora_etiquetas_1.Text = Trim(Replace(Combo_impresora_etiquetas_1.Text, "\", "\\"))
        Combo_impresora_etiquetas_2.Text = Trim(Replace(Combo_impresora_etiquetas_2.Text, "\", "\\"))

        combo_impresora_cotizaciones.Text = Trim(Replace(combo_impresora_cotizaciones.Text, "\", "\\"))
        combo_impresora_abonos.Text = Trim(Replace(combo_impresora_abonos.Text, "\", "\\"))
        combo_impresora_anticipos.Text = Trim(Replace(combo_impresora_anticipos.Text, "\", "\\"))
        combo_impresora_caja.Text = Trim(Replace(combo_impresora_caja.Text, "\", "\\"))
        combo_impresora_estados_de_cuenta.Text = Trim(Replace(combo_impresora_estados_de_cuenta.Text, "\", "\\"))
        combo_impresora_ticket_de_ventas.Text = Trim(Replace(combo_impresora_ticket_de_ventas.Text, "\", "\\"))
        combo_impresora_envio_sucursal.Text = Trim(Replace(combo_impresora_envio_sucursal.Text, "\", "\\"))
        combo_impresora_vales_de_cambio.Text = Trim(Replace(combo_impresora_vales_de_cambio.Text, "\", "\\"))
        combo_impresora_tarjeta_rapida.Text = Trim(Replace(combo_impresora_tarjeta_rapida.Text, "\", "\\"))
        Combo_impresora_pedidos.Text = Trim(Replace(Combo_impresora_pedidos.Text, "\", "\\"))
        combo_impresora_registro_cheques.Text = Trim(Replace(combo_impresora_registro_cheques.Text, "\", "\\"))
        combo_impresora_consumo_interno.Text = Trim(Replace(combo_impresora_consumo_interno.Text, "\", "\\"))




        If radio_directa.Checked = True Then
            tipo_impresion = "DIRECTA"
        ElseIf radio_ticket.Checked = True Then
            tipo_impresion = "TICKET"
        End If

        Consultas_SQL("select * from impresoras")
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

        Else
            SC.Connection = conexion
            SC.CommandText = "INSERT INTO impresoras (codigo) VALUES ('1')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        SC.Connection = conexion
        SC.CommandText = "UPDATE impresoras SET tipo_impresion='" & (tipo_impresion) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE impresoras SET boleta='" & (Combo_impresora_boletas.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        SC.Connection = conexion
        SC.CommandText = "UPDATE impresoras SET tipo_impresion_boleta='" & (Combo_tipo_impresion_boletas.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE impresoras SET factura='" & (Combo_impresora_facturas.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        SC.Connection = conexion
        SC.CommandText = "UPDATE impresoras SET tipo_impresion_factura='" & (Combo_tipo_impresion_facturas.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE impresoras SET guia='" & (Combo_impresora_guias.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        SC.Connection = conexion
        SC.CommandText = "UPDATE impresoras SET tipo_impresion_guia='" & (Combo_tipo_impresion_guias.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE impresoras SET nota_de_credito='" & (combo_impresora_nota_de_credito.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        SC.Connection = conexion
        SC.CommandText = "UPDATE impresoras SET tipo_impresion_nota_de_credito='" & (Combo_tipo_impresion_notas_de_credito.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE impresoras SET nota_de_debito='" & (combo_impresora_nota_de_debito.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        SC.Connection = conexion
        SC.CommandText = "UPDATE impresoras SET tipo_impresion_nota_de_debito='" & (Combo_tipo_impresion_notas_de_debito.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE impresoras SET etiqueta='" & (Combo_impresora_etiquetas_1.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE impresoras SET etiqueta_2='" & (Combo_impresora_etiquetas_2.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE `impresoras` SET `margen_etiqueta_1`='" & (txt_margen_etiquetas_1.Text) & "' WHERE `codigo` <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE `impresoras` SET `margen_etiqueta_2`='" & (txt_margen_etiquetas_2.Text) & "' WHERE `codigo` <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "Update `impresoras` Set ticket_abonos='" & (combo_impresora_abonos.Text) & "' WHERE `codigo`<>'0';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "Update `impresoras` Set ticket_anticipos='" & (combo_impresora_anticipos.Text) & "' WHERE `codigo`<>'0';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "Update `impresoras` Set ticket_caja='" & (combo_impresora_caja.Text) & "' WHERE `codigo`<>'0';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "Update `impresoras` Set ticket_anticipos='" & (combo_impresora_anticipos.Text) & "' WHERE `codigo`<>'0';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "Update `impresoras` Set ticket_tarjeta_presentacion='" & (combo_impresora_tarjeta_rapida.Text) & "' WHERE `codigo`<>'0';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "Update `impresoras` Set ticket_cotizaciones='" & (combo_impresora_cotizaciones.Text) & "' WHERE `codigo`<>'0';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "Update `impresoras` Set ticket_estado_de_cuenta='" & (combo_impresora_estados_de_cuenta.Text) & "' WHERE `codigo`<>'0';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "Update `impresoras` Set ticket_pedidos='" & (Combo_impresora_pedidos.Text) & "' WHERE `codigo`<>'0';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "Update `impresoras` Set ticket_ventas='" & (combo_impresora_ticket_de_ventas.Text) & "' WHERE `codigo`<>'0';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "Update `impresoras` Set ticket_vales_de_cambio='" & (combo_impresora_vales_de_cambio.Text) & "' WHERE `codigo`<>'0';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "Update `impresoras` Set ticket_envios_sucursal='" & (combo_impresora_envio_sucursal.Text) & "' WHERE `codigo`<>'0';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "Update `impresoras` Set ticket_registro_de_cheques='" & (combo_impresora_registro_cheques.Text) & "' WHERE `codigo`<>'0';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "Update `impresoras` Set ticket_consumo_interno='" & (combo_impresora_consumo_interno.Text) & "' WHERE `codigo`<>'0';"
        DA.SelectCommand = SC
        DA.Fill(DT)







        If Check_boletas_electronicas.Checked = True Then
            SC.Connection = conexion
            SC.CommandText = "UPDATE impresoras SET estado_boleta_electronica='NO' where codigo <> '0'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Else
            SC.Connection = conexion
            SC.CommandText = "UPDATE impresoras SET estado_boleta_electronica='SI' where codigo <> '0'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        If Check_facturas_electronica.Checked = True Then
            SC.Connection = conexion
            SC.CommandText = "UPDATE impresoras SET estado_factura_electronica='NO' where codigo <> '0'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Else
            SC.Connection = conexion
            SC.CommandText = "UPDATE impresoras SET estado_factura_electronica='SI' where codigo <> '0'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        If Check_guia_electronica.Checked = True Then
            SC.Connection = conexion
            SC.CommandText = "UPDATE impresoras SET estado_guia_electronica='NO' where codigo <> '0'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Else
            SC.Connection = conexion
            SC.CommandText = "UPDATE impresoras SET estado_guia_electronica='SI' where codigo <> '0'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        If Check_nota_credito_electronica.Checked = True Then
            SC.Connection = conexion
            SC.CommandText = "UPDATE impresoras SET estado_nota_credito_electronica='NO' where codigo <> '0'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Else
            SC.Connection = conexion
            SC.CommandText = "UPDATE impresoras SET estado_nota_credito_electronica='SI' where codigo <> '0'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        If Check_nota_debito_electronica.Checked = True Then
            SC.Connection = conexion
            SC.CommandText = "UPDATE impresoras SET estado_nota_debito_electronica='NO' where codigo <> '0'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Else
            SC.Connection = conexion
            SC.CommandText = "UPDATE impresoras SET estado_nota_debito_electronica='SI' where codigo <> '0'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        If Check_boletas_electronicas.Checked = True Then
            estado_boleta_electronica = "SI"
        Else
            estado_boleta_electronica = "NO"
        End If

        If Check_facturas_electronica.Checked = True Then
            estado_factura_electronica = "SI"
        Else
            estado_factura_electronica = "NO"
        End If

        If Check_guia_electronica.Checked = True Then
            estado_guia_electronica = "NO"
        Else
            estado_guia_electronica = "SI"
        End If

        If Check_nota_credito_electronica.Checked = True Then
            estado_nota_de_credito_electronica = "NO"
        Else
            estado_nota_de_credito_electronica = "SI"
        End If

        If Check_nota_debito_electronica.Checked = True Then
            estado_nota_de_debito_electronica = "NO"
        Else
            estado_nota_de_debito_electronica = "SI"
        End If

        SC.Connection = conexion
        SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, tipo, usuario_responsable) values('SISTEMA','MODIFICACION DE IMPRESORAS','IMPRESORAS','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        controles(False, True)
        mostrar_impresoras()

        impresora_boletas = Combo_impresora_boletas.Text
        impresora_guias = Combo_impresora_guias.Text
        impresora_facturas = Combo_impresora_facturas.Text
        impresora_nota_de_credito = combo_impresora_nota_de_credito.Text
        impresora_nota_de_debito = combo_impresora_nota_de_debito.Text
        tipo_impresion_sistema = tipo_impresion

        MsgBox("MODIFICADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly)
    End Sub

    Sub mostrar_impresoras()
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
            Combo_impresora_guias.Text = DS.Tables(DT.TableName).Rows(0).Item("guia")
            Combo_impresora_facturas.Text = DS.Tables(DT.TableName).Rows(0).Item("factura")
            Combo_impresora_boletas.Text = DS.Tables(DT.TableName).Rows(0).Item("boleta")
            Combo_impresora_etiquetas_1.Text = DS.Tables(DT.TableName).Rows(0).Item("etiqueta")
            Combo_impresora_etiquetas_2.Text = DS.Tables(DT.TableName).Rows(0).Item("etiqueta_2")
            combo_impresora_nota_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("nota_de_credito")
            combo_impresora_nota_de_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("nota_de_debito")

            combo_impresora_cotizaciones.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_cotizaciones")
            combo_impresora_abonos.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_abonos")
            combo_impresora_anticipos.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_anticipos")
            combo_impresora_caja.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_caja")
            combo_impresora_estados_de_cuenta.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_estado_de_cuenta")
            combo_impresora_ticket_de_ventas.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_ventas")
            combo_impresora_envio_sucursal.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_envios_sucursal")
            combo_impresora_vales_de_cambio.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_vales_de_cambio")
            combo_impresora_tarjeta_rapida.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_tarjeta_presentacion")
            Combo_impresora_pedidos.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_pedidos")
            combo_impresora_registro_cheques.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_registro_de_cheques")
            combo_impresora_consumo_interno.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_consumo_interno")

            Combo_tipo_impresion_boletas.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_impresion_boleta")
            Combo_tipo_impresion_facturas.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_impresion_factura")
            Combo_tipo_impresion_guias.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_impresion_guia")
            Combo_tipo_impresion_notas_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_impresion_nota_de_credito")
            Combo_tipo_impresion_notas_de_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_impresion_nota_de_debito")

            txt_margen_etiquetas_1.Text = DS.Tables(DT.TableName).Rows(0).Item("margen_etiqueta_1")
            txt_margen_etiquetas_2.Text = DS.Tables(DT.TableName).Rows(0).Item("margen_etiqueta_2")

            If DS.Tables(DT.TableName).Rows(0).Item("estado_boleta_electronica") = "SI" Then
                Check_boletas_electronicas.Checked = False
            Else
                Check_boletas_electronicas.Checked = True
            End If

            If DS.Tables(DT.TableName).Rows(0).Item("estado_factura_electronica") = "SI" Then
                Check_facturas_electronica.Checked = False
            Else
                Check_facturas_electronica.Checked = True
            End If

            If DS.Tables(DT.TableName).Rows(0).Item("estado_guia_electronica") = "SI" Then
                Check_guia_electronica.Checked = False
            Else
                Check_guia_electronica.Checked = True
            End If

            If DS.Tables(DT.TableName).Rows(0).Item("estado_nota_credito_electronica") = "SI" Then
                Check_nota_credito_electronica.Checked = False
            Else
                Check_nota_credito_electronica.Checked = True
            End If

            If DS.Tables(DT.TableName).Rows(0).Item("estado_nota_debito_electronica") = "SI" Then
                Check_nota_debito_electronica.Checked = False
            Else
                Check_nota_debito_electronica.Checked = True
            End If

            If DS.Tables(DT.TableName).Rows(0).Item("tipo_impresion") = "DIRECTA" Then
                radio_directa.Checked = True
            Else
                radio_ticket.Checked = True
            End If

        End If
        conexion.Close()
    End Sub

    Private Sub txt_boleta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If
    End Sub

    Private Sub txt_boleta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)


        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If



    End Sub

    Private Sub txt_factura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_factura_credito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

        'If e.KeyChar = "\" Then
        '    e.KeyChar = " "
        'End If
    End Sub

    Private Sub txt_factura_credito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_guia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)


        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If



    End Sub

    Private Sub txt_guia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_cotizacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

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

        'If e.KeyChar = "\" Then
        '    e.KeyChar = " "
        'End If
    End Sub

    Private Sub txt_cotizacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
        btn_modificar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
        btn_modificar.BackColor = Color.Transparent
    End Sub


    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        btn_guardar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.LostFocus
        btn_guardar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub Combo_impresora_boletas_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_impresora_boletas.GotFocus
        Combo_impresora_boletas.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_impresora_boletas_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_impresora_boletas.LostFocus
        Combo_impresora_boletas.BackColor = Color.White
    End Sub

    Private Sub txt_etiquetas_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_impresora_etiquetas_1.GotFocus
        Combo_impresora_etiquetas_1.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_etiquetas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If


    End Sub

    Private Sub txt_etiquetas_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_impresora_etiquetas_1.LostFocus
        Combo_impresora_etiquetas_1.BackColor = Color.White
    End Sub

    Private Sub Combo_impresora_facturas_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_impresora_facturas.GotFocus
        Combo_impresora_facturas.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_impresora_facturas_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_impresora_facturas.LostFocus
        Combo_impresora_facturas.BackColor = Color.White
    End Sub

    Private Sub txt_etiquetas_2_impresora_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_impresora_etiquetas_2.GotFocus
        Combo_impresora_etiquetas_2.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_etiquetas_2_impresora_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_impresora_etiquetas_2.LostFocus
        Combo_impresora_etiquetas_2.BackColor = Color.White
    End Sub

    Private Sub Combo_impresora_guias_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_impresora_guias.GotFocus
        Combo_impresora_guias.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_impresora_guias_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_impresora_guias.LostFocus
        Combo_impresora_guias.BackColor = Color.White
    End Sub

    Private Sub txt_etiquetas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_ticket_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'e.KeyChar = e.KeyChar.ToString.ToUpper


        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If



    End Sub

    Private Sub txt_boleta_servidor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

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

    End Sub

    Private Sub txt_factura_servidor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

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

    End Sub

    Private Sub txt_guia_servidor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

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

    End Sub

    Private Sub txt_ticket_servidor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

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

    End Sub

    Private Sub txt_etiqueta_servidor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

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

    End Sub

    Private Sub txt_ticket_impresora_2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If
    End Sub

    Private Sub combo_impresora_nota_de_credito_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_nota_de_credito.GotFocus
        combo_impresora_nota_de_credito.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nota_credito_impresora_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    End Sub

    Private Sub combo_impresora_nota_de_credito_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_nota_de_credito.LostFocus
        combo_impresora_nota_de_credito.BackColor = Color.White
    End Sub

    Private Sub combo_impresora_nota_de_debito_impresora_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_nota_de_debito.GotFocus
        combo_impresora_nota_de_debito.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nota_debito_impresora_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    End Sub

    Private Sub combo_impresora_nota_de_debito_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_nota_de_debito.LostFocus
        combo_impresora_nota_de_debito.BackColor = Color.White
    End Sub

    Private Sub txt_ticket_impresora_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_nota_credito_impresora_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_nota_debito_impresora_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_reporte_impresora_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub GroupBox_electronicas_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox_electronicas.Enter

    End Sub

    Private Sub txt_ticket_impresora_2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Sub cargar_impresoras()

        For Each tImpresora As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters()
            Combo_impresora_boletas.Items.Add(tImpresora)
            Combo_impresora_facturas.Items.Add(tImpresora)
            Combo_impresora_guias.Items.Add(tImpresora)
            Combo_impresora_etiquetas_1.Items.Add(tImpresora)
            Combo_impresora_etiquetas_2.Items.Add(tImpresora)
            combo_impresora_nota_de_debito.Items.Add(tImpresora)
            combo_impresora_nota_de_credito.Items.Add(tImpresora)

            combo_impresora_cotizaciones.Items.Add(tImpresora)
            combo_impresora_abonos.Items.Add(tImpresora)
            combo_impresora_anticipos.Items.Add(tImpresora)
            combo_impresora_caja.Items.Add(tImpresora)
            combo_impresora_estados_de_cuenta.Items.Add(tImpresora)
            combo_impresora_ticket_de_ventas.Items.Add(tImpresora)
            combo_impresora_envio_sucursal.Items.Add(tImpresora)
            combo_impresora_vales_de_cambio.Items.Add(tImpresora)
            combo_impresora_tarjeta_rapida.Items.Add(tImpresora)
            Combo_impresora_pedidos.Items.Add(tImpresora)
            combo_impresora_registro_cheques.Items.Add(tImpresora)
            combo_impresora_consumo_interno.Items.Add(tImpresora)



            'combo_impresora_cotizaciones.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_cotizaciones")
            'combo_impresora_abonos.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_abono")
            'combo_impresora_anticipos.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_anticipos")
            'combo_impresora_caja.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_caja")
            'combo_impresora_estados_de_cuenta.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_estados_de_cuenta")
            'combo_impresora_ticket_de_ventas.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_de_ventas")
            'combo_impresora_envio_sucursal.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_envio_a_sucursal")
            'combo_impresora_vales_de_cambio.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_vales_de_cambio")
            'combo_impresora_tarjeta_rapida.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_tarjeta_rapida")
            'Combo_impresora_pedidos.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_pedidos")
            'combo_impresora_registro_cheques.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_registro_de_cheques")




        Next

        'combo_impresora_reportes.Items.Add("SIN IMPRESION")
        'combo_impresora_nota_de_credito.Items.Add("SIN IMPRESION")

        'Combo_impresora_boletas.Items.Add("TICKET INTERNO")

    End Sub



    Private Sub combo_impresora_reportes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox_datos_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox_datos.Enter

    End Sub

    Private Sub Combo_impresora_etiquetas_2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_impresora_etiquetas_2.SelectedIndexChanged

    End Sub

    Private Sub Combo_impresora_guias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_impresora_guias.SelectedIndexChanged

    End Sub

    Private Sub radio_directa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radio_directa.CheckedChanged

    End Sub

    Private Sub radio_directa_TabStopChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radio_directa.TabStopChanged
        radio_directa.TabStop = False
    End Sub

    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub combo_impresora_cotizaciones_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_cotizaciones.GotFocus
        combo_impresora_cotizaciones.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_impresora_cotizaciones_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_cotizaciones.LostFocus
        combo_impresora_cotizaciones.BackColor = Color.White
    End Sub

    Private Sub combo_impresora_abonos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_abonos.GotFocus
        combo_impresora_abonos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_impresora_abonos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_abonos.LostFocus
        combo_impresora_abonos.BackColor = Color.White
    End Sub

    Private Sub combo_impresora_anticipos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_anticipos.GotFocus
        combo_impresora_anticipos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_impresora_anticipos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_anticipos.LostFocus
        combo_impresora_anticipos.BackColor = Color.White
    End Sub

    Private Sub combo_impresora_caja_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_caja.GotFocus
        combo_impresora_caja.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_impresora_caja_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_caja.LostFocus
        combo_impresora_caja.BackColor = Color.White
    End Sub

    Private Sub combo_impresora_estados_de_cuenta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_estados_de_cuenta.GotFocus
        combo_impresora_estados_de_cuenta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_impresora_estados_de_cuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_estados_de_cuenta.LostFocus
        combo_impresora_estados_de_cuenta.BackColor = Color.White
    End Sub

    Private Sub combo_impresora_ticket_de_ventas_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_ticket_de_ventas.GotFocus
        combo_impresora_ticket_de_ventas.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_impresora_ticket_de_ventas_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_ticket_de_ventas.LostFocus
        combo_impresora_ticket_de_ventas.BackColor = Color.White
    End Sub

    Private Sub combo_impresora_envio_sucursal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_envio_sucursal.GotFocus
        combo_impresora_envio_sucursal.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_impresora_envio_sucursal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_envio_sucursal.LostFocus
        combo_impresora_envio_sucursal.BackColor = Color.White
    End Sub

    Private Sub combo_impresora_vales_de_cambio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_vales_de_cambio.GotFocus
        combo_impresora_vales_de_cambio.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_impresora_vales_de_cambio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_vales_de_cambio.LostFocus
        combo_impresora_vales_de_cambio.BackColor = Color.White
    End Sub

    Private Sub combo_impresora_tarjeta_rapida_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_tarjeta_rapida.GotFocus
        combo_impresora_tarjeta_rapida.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_impresora_tarjeta_rapida_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_tarjeta_rapida.LostFocus
        combo_impresora_tarjeta_rapida.BackColor = Color.White
    End Sub

    Private Sub Combo_impresora_pedidos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_impresora_pedidos.GotFocus
        Combo_impresora_pedidos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_impresora_pedidos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_impresora_pedidos.LostFocus
        Combo_impresora_pedidos.BackColor = Color.White
    End Sub

    Private Sub combo_impresora_registro_cheques_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_registro_cheques.GotFocus
        combo_impresora_registro_cheques.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_impresora_registro_cheques_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_registro_cheques.LostFocus
        combo_impresora_registro_cheques.BackColor = Color.White
    End Sub

    Private Sub combo_impresora_consumo_interno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_consumo_interno.GotFocus
        combo_impresora_consumo_interno.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_impresora_consumo_interno_cheques_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_consumo_interno.LostFocus
        combo_impresora_consumo_interno.BackColor = Color.White
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_tipo_impresion_guias.SelectedIndexChanged

    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_tipo_impresion_notas_de_debito.SelectedIndexChanged

    End Sub

    Private Sub txt_margen_boletas_ValueChanged(sender As Object, e As EventArgs) Handles txt_margen_boletas.ValueChanged

    End Sub

    Private Sub NumericUpDown15_ValueChanged(sender As Object, e As EventArgs) Handles txt_margen_estado_de_cuenta.ValueChanged

    End Sub
End Class