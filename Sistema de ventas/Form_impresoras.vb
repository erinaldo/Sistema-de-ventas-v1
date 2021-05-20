Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_impresoras
    Private Sub Form_impresoras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
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
            form_Ingreso.Show()
            Form_menu_principal.Close()
        End If
    End Sub

    Private Sub Form_impresoras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        controles(False, True)
        cargar_impresoras()
        mostrar_impresoras()
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
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
        Combo_impresora_ticket_1.Enabled = a
        Combo_impresora_ticket_2.Enabled = a
        txt_impresora_etiquetas_1.Enabled = a
        txt_impresora_etiquetas_2.Enabled = a
        combo_impresora_nota_de_credito.Enabled = a
        combo_impresora_nota_de_debito.Enabled = a
        combo_impresora_reportes.Enabled = a
        combo_impresora_traspaso_sucursal.Enabled = a

        radio_directa.Enabled = a
        radio_ticket.Enabled = a

        GroupBox_datos.Enabled = a
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

        If Combo_impresora_ticket_1.Text = "" Then
            Combo_impresora_ticket_1.Focus()
            MsgBox("CAMPO IMPRESORA DE TICKET 1 VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If Combo_impresora_ticket_2.Text = "" Then
            Combo_impresora_ticket_2.Focus()
            MsgBox("CAMPO IMPRESORA DE TICKET 2 VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
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


        If combo_impresora_reportes.Text = "" Then
            combo_impresora_reportes.Focus()
            MsgBox("CAMPO IMPRESORA DE REPORTES VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If combo_impresora_traspaso_sucursal.Text = "" Then
            combo_impresora_traspaso_sucursal.Focus()
            MsgBox("CAMPO IMPRESORA DE DESPACHO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_impresora_etiquetas_1.Text = "" Then
            txt_impresora_etiquetas_1.Focus()
            MsgBox("CAMPO MARGEN IMPRESORA DE ETIQUETAS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_impresora_etiquetas_2.Text = "" Then
            txt_impresora_etiquetas_2.Focus()
            MsgBox("CAMPO MARGEN IMPRESORA DE ETIQUETAS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        Combo_impresora_boletas.Text = Trim(Replace(Combo_impresora_boletas.Text, "\", "\\"))
        Combo_impresora_guias.Text = Trim(Replace(Combo_impresora_guias.Text, "\", "\\"))
        Combo_impresora_facturas.Text = Trim(Replace(Combo_impresora_facturas.Text, "\", "\\"))
        combo_impresora_nota_de_credito.Text = Trim(Replace(combo_impresora_nota_de_credito.Text, "\", "\\"))
        combo_impresora_nota_de_debito.Text = Trim(Replace(combo_impresora_nota_de_debito.Text, "\", "\\"))
        combo_impresora_reportes.Text = Trim(Replace(combo_impresora_reportes.Text, "\", "\\"))
        Combo_impresora_ticket_1.Text = Trim(Replace(Combo_impresora_ticket_1.Text, "\", "\\"))
        Combo_impresora_ticket_2.Text = Trim(Replace(Combo_impresora_ticket_2.Text, "\", "\\"))
        Combo_impresora_etiquetas_1.Text = Trim(Replace(Combo_impresora_etiquetas_1.Text, "\", "\\"))
        Combo_impresora_etiquetas_2.Text = Trim(Replace(Combo_impresora_etiquetas_2.Text, "\", "\\"))
        combo_impresora_traspaso_sucursal.Text = Trim(Replace(combo_impresora_traspaso_sucursal.Text, "\", "\\"))


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
        SC.CommandText = "UPDATE impresoras SET BOLETA='" & (Combo_impresora_boletas.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE impresoras SET factura='" & (Combo_impresora_facturas.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.CommandText = "UPDATE impresoras SET guia='" & (Combo_impresora_guias.Text) & "' where codigo <> '0'"
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
        SC.CommandText = "UPDATE impresoras SET ticket='" & (Combo_impresora_ticket_1.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE impresoras SET ticket_2='" & (Combo_impresora_ticket_2.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE impresoras SET nota_de_credito='" & (combo_impresora_nota_de_credito.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE impresoras SET nota_de_debito='" & (combo_impresora_nota_de_debito.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE impresoras SET reporte='" & (combo_impresora_reportes.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE impresoras SET traspaso_sucursal='" & (combo_impresora_traspaso_sucursal.Text) & "' where codigo <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE `impresoras` SET `margen_etiqueta_1`='" & (txt_impresora_etiquetas_1.Text) & "' WHERE `codigo` <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "UPDATE `impresoras` SET `margen_etiqueta_2`='" & (txt_impresora_etiquetas_2.Text) & "' WHERE `codigo` <> '0'"
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
        impresora_etiquetas = Combo_impresora_etiquetas_1.Text
        impresora_etiquetas_2 = Combo_impresora_etiquetas_2.Text
        impresora_ticket = Combo_impresora_ticket_1.Text
        impresora_ticket_2 = Combo_impresora_ticket_2.Text
        impresora_nota_de_credito = combo_impresora_nota_de_credito.Text
        impresora_nota_de_debito = combo_impresora_nota_de_debito.Text
        impresora_reportes = combo_impresora_reportes.Text
        impresora_despacho = combo_impresora_traspaso_sucursal.Text
        tipo_impresion_sistema = tipo_impresion
        margen_etiqueta_1 = txt_impresora_etiquetas_1.Text
        margen_etiqueta_2 = txt_impresora_etiquetas_2.Text

        MsgBox("MODIFICADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly)
    End Sub


    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
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
            Combo_impresora_boletas.Text = DS.Tables(DT.TableName).Rows(0).Item("BOLETA")
            Combo_impresora_etiquetas_1.Text = DS.Tables(DT.TableName).Rows(0).Item("etiqueta")
            Combo_impresora_etiquetas_2.Text = DS.Tables(DT.TableName).Rows(0).Item("etiqueta_2")
            Combo_impresora_ticket_1.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket")
            Combo_impresora_ticket_2.Text = DS.Tables(DT.TableName).Rows(0).Item("ticket_2")
            combo_impresora_nota_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("nota_de_credito")
            combo_impresora_nota_de_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("nota_de_debito")
            combo_impresora_reportes.Text = DS.Tables(DT.TableName).Rows(0).Item("reporte")
            combo_impresora_traspaso_sucursal.Text = DS.Tables(DT.TableName).Rows(0).Item("traspaso_sucursal")

            txt_impresora_etiquetas_1.Text = DS.Tables(DT.TableName).Rows(0).Item("margen_etiqueta_1")
            txt_impresora_etiquetas_2.Text = DS.Tables(DT.TableName).Rows(0).Item("margen_etiqueta_2")

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

    Private Sub combo_impresora_reportes_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_reportes.GotFocus
        combo_impresora_reportes.BackColor = Color.LightSkyBlue
    End Sub



    Private Sub txt_reporte_impresora_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    End Sub

    Private Sub txt_reporte_impresora_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

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

    Private Sub txt_ticket_impresora_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_impresora_ticket_1.GotFocus
        Combo_impresora_ticket_1.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_ticket_impresora_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_impresora_ticket_1.LostFocus
        Combo_impresora_ticket_1.BackColor = Color.White
    End Sub

    Private Sub Combo_impresora_ticket_2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_impresora_ticket_2.GotFocus
        Combo_impresora_ticket_2.BackColor = Color.LightSkyBlue
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

    Private Sub Combo_impresora_ticket_2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_impresora_ticket_2.LostFocus
        Combo_impresora_ticket_2.BackColor = Color.White
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
            Combo_impresora_ticket_1.Items.Add(tImpresora)
            Combo_impresora_ticket_2.Items.Add(tImpresora)
            combo_impresora_nota_de_debito.Items.Add(tImpresora)
            combo_impresora_nota_de_credito.Items.Add(tImpresora)
            combo_impresora_reportes.Items.Add(tImpresora)
            combo_impresora_traspaso_sucursal.Items.Add(tImpresora)
        Next

        combo_impresora_reportes.Items.Add("SIN IMPRESION")
        combo_impresora_nota_de_credito.Items.Add("SIN IMPRESION")

        Combo_impresora_boletas.Items.Add("TICKET INTERNO")

    End Sub

    Private Sub combo_impresora_reportes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_impresora_reportes.LostFocus
        combo_impresora_reportes.BackColor = Color.White
    End Sub






    Private Sub combo_impresora_reportes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_impresora_reportes.SelectedIndexChanged

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
End Class