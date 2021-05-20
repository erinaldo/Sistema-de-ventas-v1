Imports System.IO
Imports System.Math
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

Public Class Form_CORREGIR

    Private Sub Form_CORREGIR_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_CORREGIR_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp

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

    Private Sub Form_CORREGIR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()

        txt_recinto.Text = mirecintoempresa
        combo_doc_referencia.SelectedItem = "BOLETA"

        dtp_emision.CustomFormat = "yyy-MM-dd"
        dtp_vencimiento.CustomFormat = "yyy-MM-dd"
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click

        If txt_rut_cliente.Text = "" Then
            MsgBox("CAMPO CLIENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut_cliente.Focus()
            Exit Sub
        End If

        If txt_nombre_cliente.Text = "" Then
            MsgBox("CAMPO CLIENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut_cliente.Focus()
            Exit Sub
        End If


        If txt_nro_doc_referencia.Text = "" Then
            MsgBox("CAMPO NRO. DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nro_doc_referencia.Focus()
            Exit Sub
        End If

        If txt_total_doc_referencia.Text = "" Then
            MsgBox("CAMPO TOTAL DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_total_doc_referencia.Focus()
            Exit Sub
        End If

        If txt_cantidad_cuotas.Text = "" Then
            MsgBox("CAMPO CANT. CUOTAS VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_cantidad_cuotas.Focus()
            Exit Sub
        End If

        If txt_nro_letra.Text = "" Then
            MsgBox("CAMPO LETRA INICIAL VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nro_letra.Focus()
            Exit Sub
        End If


        If txt_pie.Text = "" Then
            MsgBox("CAMPO PIE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_pie.Focus()
            Exit Sub
        End If


        If txt_total_letra.Text = "" Then
            MsgBox("CAMPO TOTAL LETRA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_total_letra.Focus()
            Exit Sub
        End If

        conexion.Close()
        Consultas_SQL("select * from letras where n_letra = '" & (txt_nro_letra.Text) & "'")
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            MsgBox("LA LETRA YA FUE INGRESADA", 0 + 16, "ERROR")
            Exit Sub
        End If



        grabar_letras()

    End Sub

    Sub grabar_letras()

        Me.Enabled = False


        Dim Nro_Cuota As Integer
        Nro_Cuota = 1
        dtp_vencimiento.Value = dtp_emision.Value.AddMonths(Val(+1))

        For i = 0 To (txt_cantidad_cuotas.Text - 1)

            Dim Neto_letra As Integer
            Dim Iva_letra As Integer
            Dim iva_valor As String

            iva_valor = valor_iva / 100 + 1
            Neto_letra = Round(txt_total_letra.Text / iva_valor)
            Iva_letra = (((Neto_letra) * valor_iva) / 100)
            Iva_letra = (txt_total_letra.Text) - (Neto_letra)

            SC.Connection = conexion
            SC.CommandText = "insert into  creditos (n_creditos, TIPO, tipo_detalle, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, saldo, condiciones, estado, usuario_responsable, codigo_afecta, nombre_afecta, recinto, fecha_vencimiento, fecha_pago, numero_cuota, total_cuotas, interes, gastos_de_cobranza, pie, convenio, condicion_de_pago_pie, doc_referencia, nro_referencia, total_referencia) values (" & (txt_nro_letra.Text) & ",'" & ("LETRA") & "','" & (combo_doc_referencia.Text & " " & txt_nro_doc_referencia.Text & " " & Nro_Cuota & " DE " & txt_cantidad_cuotas.Text) & "','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (dtp_emision.Text) & "','0'," & (Neto_letra) & "," & (Iva_letra) & "," & (txt_total_letra.Text) & "," & (txt_total_letra.Text) & "," & (txt_total_letra.Text) & ",'CREDITO','" & ("EMITIDA") & "','" & (miusuario) & "','" & (txt_nro_letra.Text) & "','LETRA', '" & (mirecintoempresa) & "', '" & (dtp_vencimiento.Text) & "', '0000-00-00', '" & (Nro_Cuota) & "', '" & (txt_cantidad_cuotas.Text) & "', '0', '0', '" & (txt_pie.Text) & "', '-', 'EFECTIVO', '" & (combo_doc_referencia.Text) & "', '" & (txt_nro_doc_referencia.Text) & "', '" & (txt_total_doc_referencia.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into letras (n_letra, cant_letras, doc_referencia, nro_referencia, fecha, rut_cliente, monto_letra, total_letra, estado, usuario_responsable, fecha_vencimiento, orden_letras, total_doc_referencia) values (" & (txt_nro_letra.Text) & " , '" & (txt_cantidad_cuotas.Text) & "', '" & (combo_doc_referencia.Text) & "','" & (txt_nro_doc_referencia.Text) & "','" & (dtp_emision.Text) & "','" & (txt_rut_cliente.Text) & "'," & (txt_total_letra.Text) & "," & (txt_total_letra.Text) & ", 'EMITIDA', '" & (miusuario) & "','" & (dtp_vencimiento.Text) & "','" & (Nro_Cuota) & "','" & (txt_total_doc_referencia.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            Nro_Cuota = Nro_Cuota + 1
            dtp_vencimiento.Value = dtp_vencimiento.Value.AddMonths(Val(+1))
            txt_nro_letra.Text = Val(txt_nro_letra.Text) + 1

        Next

        Me.Enabled = True

        MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        limpiar()
    End Sub




    Sub limpiar()

        txt_cantidad_cuotas.Text = ""
        txt_ciudad_cliente.Text = ""
        txt_cod_cliente.Text = ""
        txt_comuna_cliente.Text = ""
        txt_correo_cliente.Text = ""
        txt_direccion_cliente.Text = ""
        txt_giro_cliente.Text = ""
        txt_nombre_cliente.Text = ""
        txt_nro_doc_referencia.Text = ""
        txt_total_doc_referencia.Text = ""
        txt_pie.Text = ""
        txt_cantidad_cuotas.Text = ""
        txt_nro_letra.Text = ""
        txt_total_letra.Text = ""
        txt_rut_cliente.Text = ""
        txt_rut_cliente.Focus()

    End Sub


    Private Sub txt_total_letra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_total_letra.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_total_letra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total_letra.TextChanged

    End Sub

    Private Sub txt_pie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pie.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_pie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pie.TextChanged

    End Sub

    Private Sub txt_nro_letra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nro_letra.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_nro_letra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_letra.TextChanged

    End Sub

    Private Sub txt_cantidad_cuotas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_cuotas.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cantidad_cuotas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_cuotas.TextChanged

    End Sub

    Private Sub txt_total_doc_referencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_total_doc_referencia.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_total_doc_referencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total_doc_referencia.TextChanged

    End Sub

    Private Sub txt_nro_doc_referencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nro_doc_referencia.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_nro_doc_referencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_doc_referencia.TextChanged

    End Sub

    Private Sub txt_rut_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_cliente.KeyPress
        limpiar_datos_clientes_enter()


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



        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            limpiar_datos_clientes_enter()
            guion_rut_cliente()
            mostrar_datos_clientes()
        End If
    End Sub

    Sub guion_rut_cliente()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut_cliente.Text
        If rut_cliente.Length > 2 Then

            guion = rut_cliente(rut_cliente.Length - 2).ToString()

            If guion <> "-" Then
                Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                rut_cliente = rut_cliente & "-" & fin_rut
                txt_rut_cliente.Text = rut_cliente
            End If
        End If
    End Sub

    Sub limpiar_datos_clientes_enter()
        lbl_rut.Text = "nada"
        txt_nombre_cliente.Text = ""
        txt_direccion_cliente.Text = ""
        txt_cod_cliente.Text = ""
        'txt_descuento_cliente.Text = ""
        txt_giro_cliente.Text = ""
        txt_comuna_cliente.Text = ""
        '  txt_cuenta_cliente.Text = ""
        txt_telefono.Text = ""
        '  txt_folio.Text = ""
        '  txt_descuento_cliente_2.Text = ""
        '  txt_orden_de_compra.Text = ""
    End Sub

    'sub para mostrar los datos de los clientes.
    Sub mostrar_datos_clientes()
        conexion.Close()
        If txt_rut_cliente.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from clientes where rut_cliente ='" & (txt_rut_cliente.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            ' If DS.Tables(DT.TableName).Rows.Count > 0 Then
            If DS.Tables(DT.TableName).Rows.Count = 1 Then
                lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
                txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                'txt_descuento_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
                ' txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
                txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_cliente")
                txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                '   txt_cuenta_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("estado_cuenta")
                '  txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
                txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                '  txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
                ' txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                ' txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")
                'End If
                conexion.Close()

            Else
                MsgBox("CLIENTE NO ENCONTRADO", 0 + 16, "ERROR")
                txt_rut_cliente.Focus()
                conexion.Close()
            End If
        End If
    End Sub












    Private Sub txt_rut_cliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.LostFocus
        txt_rut_cliente.BackColor = Color.White
    End Sub

    Private Sub txt_rut_cliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.GotFocus
        txt_rut_cliente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_doc_referencia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_doc_referencia.LostFocus
        combo_doc_referencia.BackColor = Color.White
    End Sub

    Private Sub combo_doc_referencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_doc_referencia.GotFocus
        combo_doc_referencia.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_total_doc_referencia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_total_doc_referencia.LostFocus
        txt_total_doc_referencia.BackColor = Color.White
    End Sub

    Private Sub txt_total_doc_referencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_total_doc_referencia.GotFocus
        txt_total_doc_referencia.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nro_doc_referencia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc_referencia.LostFocus
        txt_nro_doc_referencia.BackColor = Color.White
    End Sub

    Private Sub txt_nro_doc_referencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc_referencia.GotFocus
        txt_nro_doc_referencia.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_cantidad_cuotas_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_cuotas.LostFocus
        txt_cantidad_cuotas.BackColor = Color.White
    End Sub

    Private Sub txt_cantidad_cuotas_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_cuotas.GotFocus
        txt_cantidad_cuotas.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nro_letra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_letra.LostFocus
        txt_nro_letra.BackColor = Color.White
    End Sub

    Private Sub txt_nro_letra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_letra.GotFocus
        txt_nro_letra.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_pie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_pie.LostFocus
        txt_pie.BackColor = Color.White
    End Sub

    Private Sub txt_pie_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_pie.GotFocus
        txt_pie.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_total_letra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_total_letra.LostFocus
        txt_total_letra.BackColor = Color.White
    End Sub

    Private Sub txt_total_letra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_total_letra.GotFocus
        txt_total_letra.BackColor = Color.LightSkyBlue
    End Sub



    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_grabar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.LostFocus
        btn_grabar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_grabar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.GotFocus
        btn_grabar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()
        End If
    End Sub

    Private Sub txt_rut_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.TextChanged

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
End Class