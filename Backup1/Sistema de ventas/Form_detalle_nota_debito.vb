Imports System.IO

Imports System.Runtime.InteropServices
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D

Public Class Form_detalle_nota_debito
    Dim mifecha2 As String
    Private WithEvents Pd As New PrintDocument

    Private Sub Form_detalle_nota_debito_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Form_impreso_corectamente.Visible = True Or Form_autorizacion.Visible = True Then
            Form_nota_de_debito.Enabled = False
        Else
            Form_nota_de_debito.Enabled = True
            Form_nota_de_debito.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Form_detalle_nota_debito_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_detalle_nota_debito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lblfecha.Text = FormatDateTime(Now, DateFormat.ShortDate)
        dtp_fecha_documento.CustomFormat = "yyy-MM-dd"
        cargar_logo()
        combo_documento.SelectedItem = "NOTA DE CREDITO"
        combo_documento.Focus()
    End Sub







    Sub mostrar_datos_documento()

        If combo_documento.Text = "BOLETA" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from BOLETA, usuarios where n_boleta='" & (txt_nro_documento.Text) & "' and BOLETA.usuario_responsable=usuarios.rut_usuario"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Dim condicion As String
                condicion = DS.Tables(DT.TableName).Rows(0).Item("CONDICIONES")
                Form_nota_de_debito.txt_tipo_impresion.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_impresion")
                Form_nota_de_debito.dtp_fecha_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
                Form_nota_de_debito.txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_nota_de_debito.txt_rut_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_nota_de_debito.txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
                Form_nota_de_debito.txt_total_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
                Form_nota_de_debito.Combo_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")


                If (condicion) <> "CREDITO" Then
                    Form_nota_de_debito.combo_condiciones.Text = "CONTADO"
                Else
                    Form_nota_de_debito.combo_condiciones.Text = "CREDITO"
                End If


                Form_nota_de_debito.txt_tipo_doc_referencia.Text = combo_documento.Text
                Form_nota_de_debito.txt_nro_doc_referencia.Text = txt_nro_documento.Text
                'Form_nota_credito.txt_codigo_doc_referencia.Text = txt_tipo_dte.Text

                If Form_nota_de_debito.txt_tipo_impresion.Text = "MANUAL" Then
                    Form_nota_de_debito.txt_codigo_doc_referencia.Text = "35"
                ElseIf Form_nota_de_debito.txt_tipo_impresion.Text = "ELECTRONICA" Then
                    Form_nota_de_debito.txt_codigo_doc_referencia.Text = "39"
                End If

                Form_nota_de_debito.lbl_venta.Text = "DOC. DE REFERENCIA: " & combo_documento.Text & " NRO. " & txt_nro_documento.Text
            Else
                MsgBox("EL DOCUMENTO NO SE ENCUENTRA", 0 + 16, "ERROR")
                txt_nro_documento.Focus()
                conexion.Close()
                Exit Sub
            End If
            conexion.Close()
        End If

        If combo_documento.Text = "FACTURA" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from  factura,  usuarios where n_factura='" & (txt_nro_documento.Text) & "' and factura.usuario_responsable=usuarios.rut_usuario"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Dim condicion As String
                condicion = DS.Tables(DT.TableName).Rows(0).Item("CONDICIONES")
                Form_nota_de_debito.txt_tipo_impresion.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_impresion")
                Form_nota_de_debito.dtp_fecha_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
                Form_nota_de_debito.txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_nota_de_debito.txt_rut_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_nota_de_debito.txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
                Form_nota_de_debito.txt_total_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
                Form_nota_de_debito.Combo_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")


                If (condicion) <> "CREDITO" Then
                    Form_nota_de_debito.combo_condiciones.Text = "CONTADO"
                Else
                    Form_nota_de_debito.combo_condiciones.Text = "CREDITO"
                End If

                Form_nota_de_debito.txt_tipo_doc_referencia.Text = combo_documento.Text
                Form_nota_de_debito.txt_nro_doc_referencia.Text = txt_nro_documento.Text
                'Form_nota_credito.txt_codigo_doc_referencia.Text = txt_tipo_dte.Text

                If Form_nota_de_debito.txt_tipo_impresion.Text = "MANUAL" Then
                    Form_nota_de_debito.txt_codigo_doc_referencia.Text = "30"
                ElseIf Form_nota_de_debito.txt_tipo_impresion.Text = "ELECTRONICA" Then
                    Form_nota_de_debito.txt_codigo_doc_referencia.Text = "33"
                End If

                Form_nota_de_debito.lbl_venta.Text = "DOC. DE REFERENCIA: " & combo_documento.Text & " NRO. " & txt_nro_documento.Text
            Else
                MsgBox("EL DOCUMENTO NO SE ENCUENTRA", 0 + 16, "ERROR")
                txt_nro_documento.Focus()
                conexion.Close()
                Exit Sub
            End If
            conexion.Close()
        End If



        If combo_documento.Text = "NOTA DE CREDITO" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from nota_credito, usuarios where n_nota_credito='" & (txt_nro_documento.Text) & "' and nota_credito.usuario_responsable=usuarios.rut_usuario"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Dim condicion As String
                condicion = DS.Tables(DT.TableName).Rows(0).Item("CONDICIONES")
                Form_nota_de_debito.txt_tipo_impresion.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_impresion")
                Form_nota_de_debito.dtp_fecha_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
                Form_nota_de_debito.txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_nota_de_debito.txt_rut_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_nota_de_debito.txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
                Form_nota_de_debito.txt_total_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
                Form_nota_de_debito.Combo_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")


                If (condicion) <> "CREDITO" Then
                    Form_nota_de_debito.combo_condiciones.Text = "CONTADO"
                Else
                    Form_nota_de_debito.combo_condiciones.Text = "CREDITO"
                End If

                Form_nota_de_debito.txt_tipo_doc_referencia.Text = combo_documento.Text
                Form_nota_de_debito.txt_nro_doc_referencia.Text = txt_nro_documento.Text

                If Form_nota_de_debito.txt_tipo_impresion.Text = "MANUAL" Then
                    Form_nota_de_debito.txt_codigo_doc_referencia.Text = "60"
                ElseIf Form_nota_de_debito.txt_tipo_impresion.Text = "ELECTRONICA" Then
                    Form_nota_de_debito.txt_codigo_doc_referencia.Text = "61"
                End If

                ' Form_nota_de_debito.txt_codigo_doc_referencia.Text = txt_tipo_dte.Text
                Form_nota_de_debito.lbl_venta.Text = "DOC. DE REFERENCIA: " & combo_documento.Text & " NRO. " & txt_nro_documento.Text
            Else
                MsgBox("EL DOCUMENTO NO SE ENCUENTRA", 0 + 16, "ERROR")
                txt_nro_documento.Focus()
                conexion.Close()
                Exit Sub
            End If
            conexion.Close()
        End If


    End Sub





    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click


        '  fecha()


        If combo_documento.Text = "" Then
            MsgBox("DEBE INGRESAR EL TIPO DE DOCUMENTO QUE AFECTA LA NOTA DE DEBITO", 0 + 16, "ERROR")
            combo_documento.Focus()
            Exit Sub
        End If

        If combo_documento.Text <> "SIN IMPUTAR" Then
            If txt_nro_documento.Text = "" Then
                MsgBox("DEBE INGRESAR EL NRO. DE DOCUMENTO QUE AFECTA LA NOTA DE DEBITO", 0 + 16, "ERROR")
                txt_nro_documento.Focus()
                Exit Sub
            End If
        End If





        Me.Enabled = False

        mostrar_datos_documento()
        Form_nota_de_debito.mostrar_datos_clientes()
        cargar_documento()
        Form_nota_de_debito.calcular_totales()
        Form_nota_de_debito.controles(True, False)

        Form_nota_de_debito.txt_factura.Enabled = False
        Form_nota_de_debito.dtp_ingreso.Enabled = False
        Form_nota_de_debito.dtp_ingreso.Text = FormatDateTime(Now, DateFormat.ShortDate)
        Form_nota_de_debito.crear_numero_documento()

        Me.Close()
        Exit Sub

        If Form_nota_de_debito.combo_condiciones.Text <> "CREDITO" Then
            Form_nota_de_debito.redondear_documento()
        End If

        '    If Form_nota_credito.Radio_electronica.Checked = True Then
        Form_nota_de_debito.crear_numero_documento()
        '  End If



        Form_nota_de_debito.dtp_fecha_doc_referencia.Text = ""
        Form_nota_de_debito.txt_rut_cliente.Text = ""
        Form_nota_de_debito.txt_rut_doc_referencia.Text = ""
        Form_nota_de_debito.txt_porcentaje_desc.Text = ""
        Form_nota_de_debito.txt_total_doc_referencia.Text = ""
        Form_nota_de_debito.txt_tipo_doc_referencia.Text = ""
        Form_nota_de_debito.txt_nro_doc_referencia.Text = ""
        Form_nota_de_debito.txt_codigo_doc_referencia.Text = ""















        Form_nota_de_debito.grabar_factura()
        Form_nota_de_debito.grabar_detalle_factura()
        Form_nota_de_debito.crear_archivo_plano()

        If Form_nota_credito.combo_condiciones.Text = "CREDITO" Then

            SC.Connection = conexion
            SC.CommandText = "insert into creditos (n_creditos, TIPO, tipo_detalle, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, saldo, desglose, condiciones, estado, usuario_responsable, codigo_afecta, nombre_afecta, RECINTO) values (" & (Form_nota_credito.txt_factura.Text) & ",'" & ("NOTA DE CREDITO") & "','" & ("NOTA DE CREDITO SIN IMPUTAR") & "','" & (Form_nota_credito.txt_rut_cliente.Text) & "','" & (Form_nota_credito.txt_cod_cliente.Text) & "','" & (Form_nota_credito.dtp_ingreso.Text) & "'," & (Form_nota_credito.txt_desc.Text) & "," & (Form_nota_credito.txt_neto.Text) & "," & (Form_nota_credito.txt_iva.Text) & "," & (Form_nota_credito.txt_sub_total.Text) & "," & ("-" & Form_nota_credito.txt_total.Text) & "," & ("-" & Form_nota_credito.txt_total.Text) & ",'" & (desglose_valor) & "','" & (Form_nota_credito.combo_condiciones.Text) & "','" & ("EMITIDA") & "','" & (miusuario) & "','0','SIN IMPUTAR','" & (mirecintoempresa) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

        End If

        Form_nota_de_debito.limpiar()
        Form_nota_de_debito.controles(False, True)
        Form_impreso_corectamente.Show()
        Me.Close()

    End Sub





    Private Sub txt_orden_de_compra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_nro_documento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_orden_de_compra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

        If e.KeyChar = "\" Then
            e.KeyChar = " "
        End If

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If


        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btn_aceptar.Focus()
        End If
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
        '   Form_nota_credito.Close()
    End Sub

    Private Sub txt_orden_de_compra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_nro_documento.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub btn_aceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.GotFocus
        btn_aceptar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_aceptar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.LostFocus
        btn_aceptar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Private Sub combo_documento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles combo_documento.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_nro_documento.Focus()
        End If
    End Sub

    Private Sub combo_documento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combo_documento.KeyPress
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

        If e.KeyChar = "\" Then
            e.KeyChar = " "
        End If
    End Sub

    Private Sub txt_nro_documento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub combo_documento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_documento.SelectedIndexChanged




        txt_nro_documento.Focus()
    End Sub

    Private Sub combo_documento_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_documento.TextChanged
        If combo_documento.Text = "SIN IMPUTAR" Then
            txt_nro_documento.Enabled = False
        Else
            txt_nro_documento.Enabled = True
        End If
    End Sub

    Private Sub txt_nro_documento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nro_documento.KeyPress
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
            btn_aceptar.Focus()
        End If

    End Sub

    Private Sub txt_nro_documento_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_documento.TextChanged

    End Sub

    Private Sub txt_nro_documento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_documento.GotFocus
        txt_nro_documento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nro_documento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_documento.LostFocus
        txt_nro_documento.BackColor = Color.White
    End Sub




    Sub cargar_documento()

        Form_nota_credito.grilla_detalle_venta.Rows.Clear()


        If combo_documento.Text = "BOLETA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_boleta where detalle_boleta.n_boleta='" & (txt_nro_documento.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    '   grilla_detalle_venta.Rows.Clear()

                    Form_nota_de_debito.grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
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
        End If




        If combo_documento.Text = "FACTURA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_factura where detalle_factura.n_factura='" & (txt_nro_documento.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            'Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then


                Dim nombre As String
                Dim valor As String
                Dim descuento As String
                Dim total As String
                Dim subtotal As String




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


                    '  grilla_detalle_venta.Rows.Clear()
                    Form_nota_de_debito.grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                    valor, _
                                                      DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                         subtotal, _
                                                          DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
                                                           descuento, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If
        End If



        If combo_documento.Text = "NOTA DE CREDITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_nota_credito where detalle_nota_credito.n_nota_credito='" & (txt_nro_documento.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then


                Dim nombre As String
                Dim valor As String
                Dim descuento As String
                Dim total As String
                Dim subtotal As String




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


                    '  grilla_detalle_venta.Rows.Clear()
                    Form_nota_de_debito.grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                     valor, _
                                                      DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                         subtotal, _
                                                          DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
                                                           descuento, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If
        End If

    End Sub

End Class