Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D

Public Class Form_seleccionar_documento_para_nota_credito
    Dim mifecha2 As String
    Dim VarCodProducto As String

    Private WithEvents Pd As New PrintDocument

    Private Sub Form_orden_de_compra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Form_impreso_corectamente.Visible = True Or Form_autorizacion.Visible = True Then
            Form_nota_credito.Enabled = False
        Else
            Form_nota_credito.Enabled = True
            Form_nota_credito.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Form_orden_de_compra_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_seleccionar_documento_para_nota_credito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblfecha.Text = FormatDateTime(Now, DateFormat.ShortDate)
        dtp_fecha_documento.CustomFormat = "yyy-MM-dd"
        cargar_logo()
        combo_documento.SelectedItem = "FACTURA"

        If mirutempresa = "81921000-4" Then
            combo_documento.Items.Clear()
            combo_documento.Items.Add("BOLETA")
            combo_documento.Items.Add("FACTURA")
            combo_documento.Items.Add("GUIA")
            combo_documento.SelectedItem = "FACTURA"
        End If

        combo_documento.Focus()
    End Sub


    Sub mostrar_datos_documento()

        'Dim nombre_usaurio_doc As String

        If combo_documento.Text = "GUIA" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from guia, usuarios where n_guia='" & (txt_nro_documento.Text) & "' and guia.usuario_responsable=usuarios.rut_usuario"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Dim condicion As String
                condicion = DS.Tables(DT.TableName).Rows(0).Item("condiciones")
                Form_nota_credito.txt_tipo_impresion.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_impresion")
                Form_nota_credito.dtp_fecha_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
                Form_nota_credito.txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_nota_credito.txt_rut_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_nota_credito.txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
                Form_nota_credito.txt_total_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")

                If Form_nota_credito.txt_rut_cliente.Text = "-" Then
                    Form_nota_credito.txt_rut_cliente.Text = "11111111-1"
                End If

                Try
                    Form_nota_credito.txt_pie.Text = DS.Tables(DT.TableName).Rows(0).Item("pie")
                Catch
                End Try

                Form_nota_credito.Combo_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")

                If (condicion) <> "CREDITO" Then
                    Form_nota_credito.combo_condiciones.Text = "EFECTIVO"
                Else
                    Form_nota_credito.combo_condiciones.Text = "CREDITO"
                End If

                Form_nota_credito.txt_tipo_doc_referencia.Text = combo_documento.Text
                Form_nota_credito.txt_nro_doc_referencia.Text = txt_nro_documento.Text
                'Form_nota_credito.txt_codigo_doc_referencia.Text = txt_tipo_dte.Text

                If Form_nota_credito.txt_tipo_impresion.Text = "MANUAL" Then
                    Form_nota_credito.txt_codigo_doc_referencia.Text = "35"
                ElseIf Form_nota_credito.txt_tipo_impresion.Text = "DIGITADA" Then
                    Form_nota_credito.txt_codigo_doc_referencia.Text = "35"
                ElseIf Form_nota_credito.txt_tipo_impresion.Text = "ELECTRONICA" Then
                    Form_nota_credito.txt_codigo_doc_referencia.Text = "39"
                End If

                Form_nota_credito.lbl_venta.Text = "DOC. DE REFERENCIA: " & combo_documento.Text & " NRO. " & txt_nro_documento.Text
            Else
                MsgBox("EL DOCUMENTO NO SE ENCUENTRA", 0 + 16, "ERROR")
                txt_nro_documento.Focus()
                conexion.Close()
                Exit Sub
            End If
            conexion.Close()
        End If

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
                Form_nota_credito.txt_tipo_impresion.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_impresion")
                Form_nota_credito.dtp_fecha_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
                Form_nota_credito.txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_nota_credito.txt_rut_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_nota_credito.txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
                Form_nota_credito.txt_total_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")

                If Form_nota_credito.txt_rut_cliente.Text = "-" Then
                    Form_nota_credito.txt_rut_cliente.Text = "11111111-1"
                End If

                Try
                    Form_nota_credito.txt_pie.Text = DS.Tables(DT.TableName).Rows(0).Item("pie")
                Catch
                End Try

                Form_nota_credito.Combo_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")

                If (condicion) <> "CREDITO" Then
                    Form_nota_credito.combo_condiciones.Text = "EFECTIVO"
                Else
                    Form_nota_credito.combo_condiciones.Text = "CREDITO"
                End If

                Form_nota_credito.txt_tipo_doc_referencia.Text = combo_documento.Text
                Form_nota_credito.txt_nro_doc_referencia.Text = txt_nro_documento.Text
                'Form_nota_credito.txt_codigo_doc_referencia.Text = txt_tipo_dte.Text

                If Form_nota_credito.txt_tipo_impresion.Text = "MANUAL" Then
                    Form_nota_credito.txt_codigo_doc_referencia.Text = "35"
                ElseIf Form_nota_credito.txt_tipo_impresion.Text = "DIGITADA" Then
                    Form_nota_credito.txt_codigo_doc_referencia.Text = "35"
                ElseIf Form_nota_credito.txt_tipo_impresion.Text = "ELECTRONICA" Then
                    Form_nota_credito.txt_codigo_doc_referencia.Text = "39"
                End If

                Form_nota_credito.lbl_venta.Text = "DOC. DE REFERENCIA: " & combo_documento.Text & " NRO. " & txt_nro_documento.Text
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
                Form_nota_credito.txt_tipo_impresion.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_impresion")
                Form_nota_credito.dtp_fecha_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
                Form_nota_credito.txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_nota_credito.txt_rut_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_nota_credito.txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
                Form_nota_credito.txt_total_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")

                If Form_nota_credito.txt_rut_cliente.Text = "-" Then
                    Form_nota_credito.txt_rut_cliente.Text = "11111111-1"
                End If

                Try
                    Form_nota_credito.txt_pie.Text = DS.Tables(DT.TableName).Rows(0).Item("pie")
                Catch
                End Try

                Form_nota_credito.Combo_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")


                If (condicion) <> "CREDITO" Then
                    Form_nota_credito.combo_condiciones.Text = "EFECTIVO"
                Else
                    Form_nota_credito.combo_condiciones.Text = "CREDITO"
                End If

                Form_nota_credito.txt_tipo_doc_referencia.Text = combo_documento.Text
                Form_nota_credito.txt_nro_doc_referencia.Text = txt_nro_documento.Text
                'Form_nota_credito.txt_codigo_doc_referencia.Text = txt_tipo_dte.Text

                If Form_nota_credito.txt_tipo_impresion.Text = "MANUAL" Then
                    Form_nota_credito.txt_codigo_doc_referencia.Text = "30"
                ElseIf Form_nota_credito.txt_tipo_impresion.Text = "DIGITADA" Then
                    Form_nota_credito.txt_codigo_doc_referencia.Text = "30"
                ElseIf Form_nota_credito.txt_tipo_impresion.Text = "ELECTRONICA" Then
                    Form_nota_credito.txt_codigo_doc_referencia.Text = "33"
                End If

                Form_nota_credito.lbl_venta.Text = "DOC. DE REFERENCIA: " & combo_documento.Text & " NRO. " & txt_nro_documento.Text
            Else
                MsgBox("EL DOCUMENTO NO SE ENCUENTRA", 0 + 16, "ERROR")
                txt_nro_documento.Focus()
                conexion.Close()
                Exit Sub
            End If
            conexion.Close()
        End If


        If combo_documento.Text = "NOTA DE DEBITO" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from nota_debito, usuarios where n_nota_debito='" & (txt_nro_documento.Text) & "' and nota_debito.usuario_responsable=usuarios.rut_usuario"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Dim condicion As String
                condicion = DS.Tables(DT.TableName).Rows(0).Item("CONDICIONES")
                Form_nota_credito.txt_tipo_impresion.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_impresion")
                Form_nota_credito.dtp_fecha_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")
                Form_nota_credito.txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_nota_credito.txt_rut_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_nota_credito.txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("porcentaje_desc")
                Form_nota_credito.txt_total_doc_referencia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
                Form_nota_credito.Combo_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")

                If Form_nota_credito.txt_rut_cliente.Text = "-" Then
                    Form_nota_credito.txt_rut_cliente.Text = "11111111-1"
                End If

                If (condicion) <> "CREDITO" Then
                    Form_nota_credito.combo_condiciones.Text = "EFECTIVO"
                Else
                    Form_nota_credito.combo_condiciones.Text = "CREDITO"
                End If

                Form_nota_credito.txt_tipo_doc_referencia.Text = combo_documento.Text
                Form_nota_credito.txt_nro_doc_referencia.Text = txt_nro_documento.Text

                If Form_nota_credito.txt_tipo_impresion.Text = "MANUAL" Then
                    Form_nota_credito.txt_codigo_doc_referencia.Text = "55"
                ElseIf Form_nota_credito.txt_tipo_impresion.Text = "DIGITADA" Then
                    Form_nota_credito.txt_codigo_doc_referencia.Text = "55"
                ElseIf Form_nota_credito.txt_tipo_impresion.Text = "ELECTRONICA" Then
                    Form_nota_credito.txt_codigo_doc_referencia.Text = "56"
                End If


                Form_nota_credito.lbl_venta.Text = "DOC. DE REFERENCIA: " & combo_documento.Text & " NRO. " & txt_nro_documento.Text
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

        If combo_documento.Text = "" Then
            MsgBox("DEBE INGRESAR EL TIPO DE DOCUMENTO QUE AFECTA LA NOTA DE CREDITO", 0 + 16, "ERROR")
            combo_documento.Focus()
            Exit Sub
        End If

        If combo_documento.Text <> "SIN IMPUTAR" Then
            If txt_nro_documento.Text = "" Then
                MsgBox("DEBE INGRESAR EL NRO. DE DOCUMENTO QUE AFECTA LA NOTA DE CREDITO", 0 + 16, "ERROR")
                txt_nro_documento.Focus()
                Exit Sub
            End If
        End If

        Me.Enabled = False

        Form_nota_credito.combo_documento.Text = combo_documento.Text
        Form_nota_credito.txt_nro_documento.Text = txt_nro_documento.Text
        Form_nota_credito.mostrar_fecha_doc()

        mostrar_datos_documento()
        Form_nota_credito.mostrar_datos_clientes()
        cargar_documento()
        Form_nota_credito.calcular_totales()

        Form_nota_credito.controles(True, False)

        If VarCodProducto = "999999" Then
            Form_nota_credito.Combo_vendedor.Items.Add("SISTEMA")
            Form_nota_credito.Combo_vendedor.SelectedItem = "SISTEMA"
            Form_nota_credito.Combo_vendedor.Enabled = False
        End If

        Form_nota_credito.txt_factura.Enabled = False
        Form_nota_credito.dtp_ingreso.Enabled = False
        Form_nota_credito.dtp_ingreso.Text = FormatDateTime(Now, DateFormat.ShortDate)
        Form_nota_credito.crear_numero_documento()

        Dim dias As Integer

        dias = DateDiff(DateInterval.Day, Form_nota_credito.dtp_fecha_doc_referencia.Value, Form_menu_principal.dtp_fecha.Value)

        If dias > "90" Then
            'Form_nota_credito.limpiar()
            Form_autorizacion_nc_90_dias.Show()
        End If

        Me.Close()

        If Form_nota_credito.txt_tipo_impresion.Text = "MANUAL" Then
            'Form_nota_credito.txt_rut_cliente.Text = mirutempresa
            'Form_nota_credito.mostrar_datos_clientes()
            Form_nota_credito.Combo_codigo_referencia.Text = "ANULA DOCUMENTO DE REFERENCIA"
        End If



        Descontar_documento()


        Exit Sub




        '   If Form_nota_credito.Radio_electronica.Checked = True Then
        Form_nota_credito.crear_numero_documento()
        '  End If

        Form_nota_credito.dtp_fecha_doc_referencia.Text = ""
        Form_nota_credito.txt_rut_cliente.Text = ""
        Form_nota_credito.txt_rut_doc_referencia.Text = ""
        Form_nota_credito.txt_porcentaje_desc.Text = ""
        Form_nota_credito.txt_total_doc_referencia.Text = ""
        Form_nota_credito.txt_tipo_doc_referencia.Text = ""
        Form_nota_credito.txt_nro_doc_referencia.Text = ""
        Form_nota_credito.txt_codigo_doc_referencia.Text = ""














        Form_nota_credito.grabar_factura()
        Form_nota_credito.grabar_detalle_factura()
        Form_nota_credito.crear_archivo_plano()

        If Form_nota_credito.combo_condiciones.Text = "CREDITO" Then

            SC.Connection = conexion
            SC.CommandText = "insert into creditos (n_creditos, TIPO, tipo_detalle, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, saldo, desglose, condiciones, estado, usuario_responsable, codigo_afecta, nombre_afecta, RECINTO) values (" & (Form_nota_credito.txt_factura.Text) & ",'" & ("NOTA DE CREDITO") & "','" & ("NOTA DE CREDITO SIN IMPUTAR") & "','" & (Form_nota_credito.txt_rut_cliente.Text) & "','" & (Form_nota_credito.txt_cod_cliente.Text) & "','" & (Form_nota_credito.dtp_ingreso.Text) & "'," & (Form_nota_credito.txt_desc.Text) & "," & (Form_nota_credito.txt_neto.Text) & "," & (Form_nota_credito.txt_iva.Text) & "," & (Form_nota_credito.txt_sub_total.Text) & "," & ("-" & Form_nota_credito.txt_total.Text) & "," & ("-" & Form_nota_credito.txt_total.Text) & ",'" & (desglose_valor) & "','" & (Form_nota_credito.combo_condiciones.Text) & "','" & ("EMITIDA") & "','" & (miusuario) & "','0','SIN IMPUTAR','" & (mirecintoempresa) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

        End If

        Form_nota_credito.limpiar()
        Form_nota_credito.controles(False, True)
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
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
        Form_nota_credito.Close()
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


        'If combo_documento.Text = "FACTURA ELECTRONICA" Then
        '    txt_tipo_dte.Text = "33"
        'End If



        'If combo_documento.Text = "BOLETA ELECTRONICA" Then
        '    txt_tipo_dte.Text = "39"
        'End If

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

        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As String
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarSubtotal As Integer
        Dim VarPorcentaje As Integer
        Dim VarDescuento As Integer
        Dim VarTotal As Integer
        Dim VarPrecioReal As Integer
        Dim iva_valor As String
        Dim VarUnidadMedida As String = ""

        Form_nota_credito.grilla_detalle_venta.Rows.Clear()
        Form_nota_credito.grilla_respaldo.Rows.Clear()

        If combo_documento.Text = "GUIA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_guia where detalle_guia.n_guia='" & (txt_nro_documento.Text) & "'"
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
                    VarSubtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal")
                    VarPorcentaje = DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc")
                    VarDescuento = DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento")
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

                    If VarValorUnitario > VarPrecioReal Then
                        VarPrecioReal = VarValorUnitario
                    End If

                    If Form_nota_credito.txt_tipo_impresion.Text = "ELECTRONICA" Then
                        VarPrecioReal = VarValorUnitario
                        'VarSubtotal = VarPrecioReal * VarCantidad
                        VarSubtotal = VarPrecioReal

                        conexion.Close()
                        VarPorcentaje = Val(VarValorUnitario) * 100 / Val(VarPrecioReal)
                        VarPorcentaje = 100 - VarPorcentaje

                        VarDescuento = VarPrecioReal - VarValorUnitario

                        VarSubtotal = VarSubtotal - VarDescuento

                        VarDescuento = VarDescuento * VarCantidad

                        VarValorUnitario = VarPrecioReal
                        iva_valor = valor_iva / 100 + 1
                        VarNeto = (VarTotal / iva_valor)
                        VarIva = (VarNeto) * valor_iva / 100
                    End If

                    If Form_nota_credito.txt_tipo_impresion.Text = "DIGITADA" Then
                        VarPrecioReal = VarValorUnitario
                        'VarSubtotal = VarPrecioReal * VarCantidad
                        VarSubtotal = VarPrecioReal

                        conexion.Close()
                        VarPorcentaje = Val(VarValorUnitario) * 100 / Val(VarPrecioReal)
                        VarPorcentaje = 100 - VarPorcentaje

                        VarDescuento = VarPrecioReal - VarValorUnitario

                        VarSubtotal = VarSubtotal - VarDescuento

                        VarDescuento = VarDescuento * VarCantidad

                        VarValorUnitario = VarPrecioReal
                        iva_valor = valor_iva / 100 + 1
                        VarNeto = (VarTotal / iva_valor)
                        VarIva = (VarNeto) * valor_iva / 100
                    End If


                    Form_nota_credito.grilla_detalle_venta.Rows.Add(VarCodProducto,
                    varnombre,
                    vartecnico,
                    VarValorUnitario,
                    VarCantidad,
                    VarNeto,
                    VarIva,
                    VarSubtotal,
                    VarPorcentaje,
                    VarDescuento,
                    VarTotal)

                    Form_nota_credito.grilla_respaldo.Rows.Add(VarCodProducto,
varnombre,
vartecnico,
VarValorUnitario,
VarCantidad,
VarNeto,
VarIva,
VarSubtotal,
VarPorcentaje,
VarDescuento,
VarTotal)
                Next
            End If
        End If

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

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                    VarCodProducto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")

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
                        VarUnidadMedida = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_medida")
                    End If
                    conexion.Close()

                    VarCodProducto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                    varnombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
                    vartecnico = DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico")
                    VarValorUnitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                    VarCantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
                    VarNeto = DS.Tables(DT.TableName).Rows(i).Item("detalle_neto")
                    VarIva = DS.Tables(DT.TableName).Rows(i).Item("detalle_iva")
                    VarSubtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal")
                    VarPorcentaje = DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc")
                    VarDescuento = DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento")
                    VarTotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")

                    VarValorUnitario = Val(VarTotal / VarCantidad)

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
                        VarUnidadMedida = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_medida")
                    End If
                    conexion.Close()

                    If VarPrecioReal = "0" Then
                        VarPrecioReal = VarValorUnitario
                    End If

                    VarPorcentaje = Val(VarValorUnitario) * 100 / Val(VarPrecioReal)
                    VarPorcentaje = 100 - VarPorcentaje
                    VarDescuento = VarPrecioReal - VarValorUnitario

                    VarDescuento = VarDescuento * VarCantidad

                    VarValorUnitario = VarPrecioReal
                    iva_valor = valor_iva / 100 + 1
                    VarNeto = (VarTotal / iva_valor)
                    VarIva = (VarNeto) * valor_iva / 100



                    If VarDescuento < 0 Then
                        VarDescuento = 0
                        VarPorcentaje = 0
                        VarValorUnitario = VarTotal / VarCantidad
                    End If

                    If VarCodProducto = "999999" Then
                        Form_nota_credito.Combo_vendedor.Text = "SISTEMA"
                        Form_nota_credito.Combo_vendedor.Enabled = False
                    End If

                    Form_nota_credito.grilla_detalle_venta.Rows.Add(VarCodProducto,
                    varnombre,
                    vartecnico,
                    VarValorUnitario,
                    VarCantidad,
                    VarNeto,
                    VarIva,
                    VarSubtotal,
                    VarPorcentaje,
                    VarDescuento,
                    VarTotal,
                    VarUnidadMedida)

                    Form_nota_credito.grilla_respaldo.Rows.Add(VarCodProducto,
varnombre,
vartecnico,
VarValorUnitario,
VarCantidad,
VarNeto,
VarIva,
VarSubtotal,
VarPorcentaje,
VarDescuento,
VarTotal,
VarUnidadMedida)
                Next

                If Form_nota_credito.grilla_detalle_venta.Rows.Count <> 0 Then
                    If Form_nota_credito.grilla_detalle_venta.Columns(0).Width = 85 Then
                        Form_nota_credito.grilla_detalle_venta.Columns(0).Width = 86
                    Else
                        Form_nota_credito.grilla_detalle_venta.Columns(0).Width = 85
                    End If
                    Form_nota_credito.grilla_detalle_venta.Columns(1).Width = 220
                    Form_nota_credito.grilla_detalle_venta.Columns(2).Width = 195
                    Form_nota_credito.grilla_detalle_venta.Columns(3).Width = 85
                    Form_nota_credito.grilla_detalle_venta.Columns(4).Width = 85
                    Form_nota_credito.grilla_detalle_venta.Columns(5).Width = 85
                    Form_nota_credito.grilla_detalle_venta.Columns(6).Width = 85
                    Form_nota_credito.grilla_detalle_venta.Columns(7).Width = 85
                    Form_nota_credito.grilla_detalle_venta.Columns(8).Width = 36
                    Form_nota_credito.grilla_detalle_venta.Columns(9).Width = 85
                    Form_nota_credito.grilla_detalle_venta.Columns(10).Width = 85
                End If

            End If

            Form_nota_credito.txt_porcentaje_desc.Text = "0"

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

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1


                    VarCodProducto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")

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
                        VarUnidadMedida = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_medida")
                    End If
                    conexion.Close()


                    If VarPrecioReal = "0" Then
                        VarPrecioReal = VarValorUnitario
                    End If


                    VarCodProducto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                    varnombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
                    vartecnico = DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico")
                    VarValorUnitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
                    VarCantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
                    VarNeto = DS.Tables(DT.TableName).Rows(i).Item("detalle_neto")
                    VarIva = DS.Tables(DT.TableName).Rows(i).Item("detalle_iva")
                    VarSubtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal")
                    VarPorcentaje = DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc")
                    VarDescuento = DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento")
                    VarTotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")

                    VarValorUnitario = Val(VarTotal / VarCantidad)

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
                        VarUnidadMedida = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_medida")
                    End If
                    conexion.Close()

                    If varnombre <> "GUIA" Then
                        If VarPrecioReal = "0" Then
                            VarPrecioReal = VarValorUnitario
                        End If

                        VarPorcentaje = Val(VarValorUnitario) * 100 / Val(VarPrecioReal)
                        VarPorcentaje = 100 - VarPorcentaje
                        VarDescuento = VarPrecioReal - VarValorUnitario

                        VarDescuento = VarDescuento * VarCantidad

                        VarValorUnitario = VarPrecioReal
                        iva_valor = valor_iva / 100 + 1
                        VarNeto = (VarTotal / iva_valor)
                        VarIva = (VarNeto) * valor_iva / 100
                    Else
                        'VarPrecioReal = VarValorUnitario
                        'VarPorcentaje = Val(VarValorUnitario) * 100 / Val(VarPrecioReal)
                        'VarPorcentaje = 100 - VarPorcentaje
                        'VarDescuento = VarPrecioReal - VarValorUnitario

                        'VarDescuento = VarDescuento * VarCantidad


                        VarPorcentaje = "0"
                        VarDescuento = "0"
                        iva_valor = valor_iva / 100 + 1
                        VarNeto = (VarTotal / iva_valor)
                        VarIva = (VarNeto) * valor_iva / 100
                    End If


                    If VarDescuento < 0 Then
                        VarDescuento = 0
                        VarPorcentaje = 0
                        VarValorUnitario = VarTotal / VarCantidad
                    End If

                    If VarUnidadMedida = "" Then
                        VarUnidadMedida = "UNIDAD"
                    End If

                    Form_nota_credito.grilla_detalle_venta.Rows.Add(VarCodProducto,
                    varnombre,
                    vartecnico,
                    VarValorUnitario,
                    VarCantidad,
                    VarNeto,
                    VarIva,
                    VarSubtotal,
                    VarPorcentaje,
                    VarDescuento,
                    VarTotal,
                    VarUnidadMedida)

                    Form_nota_credito.grilla_respaldo.Rows.Add(VarCodProducto,
varnombre,
vartecnico,
VarValorUnitario,
VarCantidad,
VarNeto,
VarIva,
VarSubtotal,
VarPorcentaje,
VarDescuento,
VarTotal,
VarUnidadMedida)
                Next

                If Form_nota_credito.grilla_detalle_venta.Rows.Count <> 0 Then
                    If Form_nota_credito.grilla_detalle_venta.Columns(0).Width = 85 Then
                        Form_nota_credito.grilla_detalle_venta.Columns(0).Width = 86
                    Else
                        Form_nota_credito.grilla_detalle_venta.Columns(0).Width = 85
                    End If
                    Form_nota_credito.grilla_detalle_venta.Columns(1).Width = 220
                    Form_nota_credito.grilla_detalle_venta.Columns(2).Width = 195
                    Form_nota_credito.grilla_detalle_venta.Columns(3).Width = 85
                    Form_nota_credito.grilla_detalle_venta.Columns(4).Width = 85
                    Form_nota_credito.grilla_detalle_venta.Columns(5).Width = 85
                    Form_nota_credito.grilla_detalle_venta.Columns(6).Width = 85
                    Form_nota_credito.grilla_detalle_venta.Columns(7).Width = 85
                    Form_nota_credito.grilla_detalle_venta.Columns(8).Width = 36
                    Form_nota_credito.grilla_detalle_venta.Columns(9).Width = 85
                    Form_nota_credito.grilla_detalle_venta.Columns(10).Width = 85
                End If

            End If

            'Form_nota_credito.txt_porcentaje_desc.Text = "0"
        End If


    End Sub






    Sub Descontar_documento()

        Dim nro_nc_descontar As String = ""

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from nota_credito where tipo_documento='" & (Form_nota_credito.combo_documento.Text) & "' and nro_documento='" & (Form_nota_credito.txt_nro_documento.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                nro_nc_descontar = DS.Tables(DT.TableName).Rows(i).Item("n_nota_credito")
                Descontar_documento_detalle(nro_nc_descontar)

            Next
        End If

    End Sub






    Sub Descontar_documento_detalle(ByVal nro_nc_descontar As String)

        Dim Cantidad_cargada As String
        Dim Codigo_cargada As Integer

        Dim Cantidad_descontar As String
        Dim Codigo_descontar As Integer


        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        SC.Connection = conexion
        SC2.CommandText = "select * from detalle_nota_credito where n_nota_credito='" & (nro_nc_descontar) & "'"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)

        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then

            For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1

                Codigo_descontar = DS2.Tables(DT2.TableName).Rows(i).Item("cod_producto")
                Cantidad_descontar = DS2.Tables(DT2.TableName).Rows(i).Item("cantidad")

                For fila = 0 To Form_nota_credito.grilla_detalle_venta.Rows.Count - 1

                    Codigo_cargada = Form_nota_credito.grilla_detalle_venta.Rows(fila).Cells(0).Value.ToString
                    Cantidad_cargada = Form_nota_credito.grilla_detalle_venta.Rows(fila).Cells(4).Value.ToString

                    If Codigo_cargada = Codigo_descontar Then

                        Form_nota_credito.grilla_detalle_venta.Rows(fila).Cells(4).Value = Cantidad_cargada - Cantidad_descontar

                    End If

                Next

            Next

        End If


    End Sub

End Class