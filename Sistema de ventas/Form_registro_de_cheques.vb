Imports System.IO
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Public Class Form_registro_de_cheques
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private WithEvents Pd As New PrintDocument

    Private Sub Form_registro_de_cheques_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_registro_de_cheques_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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


    Private Sub Form_registro_de_cheques_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_bancos()


        grilla_estado_de_cuenta.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)

        controles(False, True)

    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_fecha_caja.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_fecha_cheque.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub



    Sub crear_numero_documento()
        Dim varnumdoc As Integer
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(folio_cheque) as folio_cheque from cheques"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("folio_cheque")
                txt_folio_cheque.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_folio_cheque.Text = 1
            Exit Sub
        End Try
        conexion.Close()
    End Sub


    Sub limpiar()
        txt_monto_cheque.Text = ""
        txt_nombre_cliente.Text = ""
        txt_nro_cheque.Text = ""
        Combo_banco.Text = ""
        txt_codigo_banco.Text = ""
        txt_folio_cheque.Text = ""
        Combo_banco.SelectedItem = "-"
        dtp_fecha_caja.Text = FormatDateTime(Now, DateFormat.ShortDate)
        dtp_fecha_cheque.Text = FormatDateTime(Now, DateFormat.ShortDate)
        '  grilla_estado_de_cuenta.Rows.Clear()
    End Sub


    Sub limpiar_cheque()
        txt_monto_cheque.Text = ""
        txt_nombre_cliente.Text = ""
        txt_nro_cheque.Text = ""
        Combo_banco.SelectedItem = "-"
        txt_codigo_banco.Text = ""
        txt_folio_cheque.Text = ""
        '  dtp_fecha_caja.Text = FormatDateTime(Now, DateFormat.ShortDate)
        dtp_fecha_cheque.Text = FormatDateTime(Now, DateFormat.ShortDate)
    End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)

        txt_monto_cheque.Enabled = a
        txt_nombre_cliente.Enabled = a
        txt_nro_cheque.Enabled = a
        txt_codigo_banco.Enabled = a
        Combo_banco.Enabled = a
        dtp_fecha_caja.Enabled = a
        dtp_fecha_cheque.Enabled = a
        grilla_estado_de_cuenta.Enabled = a

        btn_agregar.Enabled = a
        btn_quitar_elemento.Enabled = a

        btn_imprimir.Enabled = a
        btn_exportar_excel.Enabled = a

        btn_limpiar.Enabled = a
        btn_cargar.Enabled = a
        btn_nueva.Enabled = b
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click


        If txt_codigo_banco.Text = "" Then
            MsgBox("CAMPO BANCO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_codigo_banco.Focus()
            Exit Sub
        End If

        If Combo_banco.Text = "" Then
            MsgBox("CAMPO BANCO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_banco.Focus()
            Exit Sub
        End If

        If Combo_banco.Text = "-" Then
            MsgBox("CAMPO BANCO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_banco.Focus()
            Exit Sub
        End If

        If txt_nro_cheque.Text = "" Then
            MsgBox("CAMPO NRO. CHEQUE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nro_cheque.Focus()
            Exit Sub
        End If

        If txt_monto_cheque.Text = "" Then
            MsgBox("CAMPO MONTO CHEQUE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_monto_cheque.Focus()
            Exit Sub
        End If

        If txt_nombre_cliente.Text = "" Then
            MsgBox("CAMPO NOMBRE CLIENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nombre_cliente.Focus()
            Exit Sub
        End If

        fecha()
        crear_numero_documento()

        For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1

            Dim nombre_cliente As String
            Dim nro_cheque As String
            Dim banco As String

            nombre_cliente = grilla_estado_de_cuenta.Rows(i).Cells(3).Value.ToString
            nro_cheque = grilla_estado_de_cuenta.Rows(i).Cells(6).Value.ToString
            banco = grilla_estado_de_cuenta.Rows(i).Cells(4).Value.ToString

            If nombre_cliente = txt_nombre_cliente.Text And nro_cheque = txt_nro_cheque.Text And banco = txt_codigo_banco.Text Then

                Dim folio_cheque As Integer

                folio_cheque = grilla_estado_de_cuenta.CurrentRow.Cells(0).Value

                SC.Connection = conexion
                SC.CommandText = "delete from cheques where folio_cheque =  '" & (folio_cheque) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                ' '' '' ''grilla_estado_de_cuenta.Rows.Remove(grilla_estado_de_cuenta.CurrentRow)
                ' '' '' ''grilla_estado_de_cuenta.Rows.Add(txt_folio_cheque.Text, dtp_fecha_caja.Text, dtp_fecha_cheque.Text, txt_nombre_cliente.Text, txt_codigo_banco.Text, Combo_banco.Text, txt_nro_cheque.Text, txt_monto_cheque.Text)

                SC.Connection = conexion
                SC.CommandText = "insert into cheques (folio_cheque, fecha_caja, fecha_cheque, nombre_cliente, nro_banco, nro_cheque, monto_cheque, usuario_responsable, hora, estado) values( '" & (txt_folio_cheque.Text) & "', '" & (mifecha2) & "', '" & (mifecha4) & "','" & (txt_nombre_cliente.Text) & "','" & (txt_codigo_banco.Text) & "','" & (txt_nro_cheque.Text) & "','" & (txt_monto_cheque.Text) & "','" & (miusuario) & "', '" & (Form_menu_principal.lbl_hora.Text) & "', 'SIN DEPOSITAR')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                calcular_totales()
                limpiar_cheque()
                '   dtp_fecha_cheque.Value.Day.ToString.Select()
                dtp_fecha_cheque.Focus()
                Exit Sub
            End If


        Next

        ' '' '' ''grilla_estado_de_cuenta.Rows.Add(txt_folio_cheque.Text, dtp_fecha_caja.Text, dtp_fecha_cheque.Text, txt_nombre_cliente.Text, txt_codigo_banco.Text, Combo_banco.Text, txt_nro_cheque.Text, txt_monto_cheque.Text)

        SC.Connection = conexion
        SC.CommandText = "insert into cheques (folio_cheque, fecha_caja, fecha_cheque, nombre_cliente, nro_banco, nro_cheque, monto_cheque, usuario_responsable, hora, estado) values( '" & (txt_folio_cheque.Text) & "', '" & (mifecha2) & "', '" & (mifecha4) & "','" & (txt_nombre_cliente.Text) & "','" & (txt_codigo_banco.Text) & "','" & (txt_nro_cheque.Text) & "','" & (txt_monto_cheque.Text) & "','" & (miusuario) & "', '" & (Form_menu_principal.lbl_hora.Text) & "', 'SIN DEPOSITAR')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        mostrar_malla()

        calcular_totales()
        limpiar_cheque()
        dtp_fecha_cheque.Focus()
    End Sub

    Sub calcular_totales()
        '//Calcular el total general

        Dim totalabono As String
        txt_total.Text = 0
        For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1
            totalabono = Val(grilla_estado_de_cuenta.Rows(i).Cells(7).Value.ToString)
            txt_total.Text = Val(txt_total.Text) + Val(totalabono)
        Next
    End Sub

    Private Sub btn_quitar_elemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        Dim folio_cheque As Integer
        If grilla_estado_de_cuenta.Rows.Count = 0 Then
            Exit Sub
        End If

        folio_cheque = grilla_estado_de_cuenta.CurrentRow.Cells(0).Value

        SC.Connection = conexion
        SC.CommandText = "delete from cheques where folio_cheque =  '" & (folio_cheque) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        grilla_estado_de_cuenta.Rows.Remove(grilla_estado_de_cuenta.CurrentRow)
        calcular_totales()
        Combo_banco.Focus()

    End Sub



    Sub llenar_combo_bancos()
        Combo_banco.Items.Clear()
        Combo_banco.Items.Add("-")
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from bancos order by nombre_banco"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_banco.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_banco"))
            Next
        End If
        conexion.Close()
    End Sub

    Sub mostrar_codigo_banco()
        conexion.Close()
        If Combo_banco.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from bancos where nombre_banco ='" & (Combo_banco.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_codigo_banco.Text = DS.Tables(DT.TableName).Rows(0).Item("codigo_banco")
            End If

            conexion.Close()
        End If
    End Sub

    Sub mostrar_nombre_banco()
        conexion.Close()
        If txt_codigo_banco.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from bancos where codigo_banco ='" & (txt_codigo_banco.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Combo_banco.SelectedItem = DS.Tables(DT.TableName).Rows(0).Item("nombre_banco")
                'Else
                '    MsgBox("NRO. DE BANCO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ERROR")
                '    txt_codigo_banco.Focus()
                '    Exit Sub
            End If

            conexion.Close()
        End If
    End Sub

    Private Sub btn_nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar()
        controles(True, False)
        mostrar_malla()
        dtp_fecha_caja.Focus()
    End Sub

    Private Sub Combo_banco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_banco.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            txt_nro_cheque.Focus()
        End If
    End Sub

    Private Sub Combo_banco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_banco.SelectedIndexChanged

        mostrar_codigo_banco()

        If Combo_banco.SelectedItem = "-" Then
            txt_codigo_banco.Text = ""
            Exit Sub
        Else
            txt_nro_cheque.Focus()
        End If


    End Sub





    Private Sub txt_monto_cheque_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_monto_cheque.GotFocus
        txt_monto_cheque.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_monto_cheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_monto_cheque.KeyPress
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
            txt_nombre_cliente.Focus()
        End If

    End Sub

    Private Sub txt_monto_cheque_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_monto_cheque.LostFocus
        txt_monto_cheque.BackColor = Color.White
    End Sub

    Private Sub txt_nombre_cliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_cliente.GotFocus
        txt_nombre_cliente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_banco_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_banco.GotFocus
        txt_codigo_banco.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_banco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_banco.KeyPress
        Combo_banco.SelectedItem = "-"
 

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If


        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_nombre_banco()


            If Combo_banco.Text = "" Then
                MsgBox("NRO. DE BANCO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ERROR")
                txt_codigo_banco.Focus()
                Exit Sub
            End If
            If Combo_banco.Text = "-" Then
                MsgBox("NRO. DE BANCO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ERROR")
                txt_codigo_banco.Focus()
                Exit Sub
            End If
            txt_nro_cheque.Focus()
        End If

    End Sub

    Private Sub txt_codigo_banco_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_banco.LostFocus
        txt_codigo_banco.BackColor = Color.White
    End Sub

    Private Sub txt_nombre_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre_cliente.KeyPress
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
            btn_agregar.Focus()
        End If

    End Sub

    Private Sub txt_nombre_cliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_cliente.LostFocus
        txt_nombre_cliente.BackColor = Color.White
    End Sub

    Private Sub txt_nro_cheque_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_cheque.GotFocus
        txt_nro_cheque.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nro_cheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nro_cheque.KeyPress
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
            txt_monto_cheque.Focus()
        End If
    End Sub

    Private Sub txt_nro_cheque_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_cheque.LostFocus
        txt_nro_cheque.BackColor = Color.White
    End Sub

    Private Sub Combo_banco_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_banco.GotFocus
        Combo_banco.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_banco_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_banco.LostFocus
        Combo_banco.BackColor = Color.White
    End Sub

    Private Sub dtp_fecha_caja_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_fecha_caja.GotFocus
        dtp_fecha_caja.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub dtp_fecha_caja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_fecha_caja.KeyPress
        'Dim salto_enter As Integer
        'salto_enter = 0

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            'SendKeys.Send("{Right}")
            dtp_fecha_cheque.Focus()
          
        End If
    End Sub

    Private Sub dtp_fecha_caja_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_fecha_caja.LostFocus
        dtp_fecha_caja.BackColor = Color.White
    End Sub

    Private Sub dtp_fecha_cheque_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_fecha_cheque.GotFocus
        Me.dtp_fecha_cheque.Select()
        dtp_fecha_cheque.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub dtp_fecha_cheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_fecha_cheque.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            txt_codigo_banco.Focus()
        End If
    End Sub

    Private Sub dtp_fecha_cheque_ingreso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_fecha_cheque.LostFocus
        dtp_fecha_cheque.BackColor = Color.White
    End Sub


    Private Sub btn_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.GotFocus
        btn_agregar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.LostFocus
        btn_agregar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cargar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cargar.GotFocus
        btn_cargar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cargar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cargar.LostFocus
        btn_cargar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

   

    Private Sub btn_quitar_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.GotFocus
        btn_quitar_elemento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_elemento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.LostFocus
        btn_quitar_elemento.BackColor = Color.Transparent
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

    Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        btn_imprimir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_nueva_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nueva.GotFocus
        btn_nueva.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nueva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nueva.LostFocus
        btn_nueva.BackColor = Color.Transparent
    End Sub

    Private Sub txt_nombre_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_cliente.TextChanged

    End Sub

    Private Sub txt_nro_cheque_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_cheque.TextChanged

    End Sub

    Private Sub txt_monto_cheque_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_monto_cheque.TextChanged

    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()
            dtp_fecha_caja.Focus()
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub








    Sub mostrar_malla()

        fecha()

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion

        SC.CommandText = "select * from cheques, bancos  where  fecha_caja = '" & (mifecha2) & "' and bancos.codigo_banco=cheques.nro_banco order by folio_cheque DESC"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_estado_de_cuenta.Rows.Clear()

        '  Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim MiFechaCaja As Date
                Dim MiFechaCaja2 As String
                MiFechaCaja = DS.Tables(DT.TableName).Rows(i).Item("fecha_caja")
                MiFechaCaja2 = MiFechaCaja.ToString("dd-MM-yyy")


                Dim MiFechaCheque As Date
                Dim MiFechaCheque2 As String
                MiFechaCheque = DS.Tables(DT.TableName).Rows(i).Item("fecha_cheque")
                MiFechaCheque2 = MiFechaCheque.ToString("dd-MM-yyy")

                grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_auto"), _
                                                   MiFechaCaja2, _
                                                    MiFechaCheque2, _
                                                     DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("nro_banco"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("nombre_banco"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("nro_cheque"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("monto_cheque"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("estado"))
            Next


            Dim estado_cheque As String

            For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1
                estado_cheque = grilla_estado_de_cuenta.Rows(i).Cells(8).Value.ToString
                If estado_cheque = "DEPOSITADO" Then
                    grilla_estado_de_cuenta.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                End If
            Next
            'grilla_estado_de_cuenta.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'grilla_estado_de_cuenta.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'grilla_estado_de_cuenta.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'grilla_estado_de_cuenta.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'grilla_estado_de_cuenta.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'grilla_estado_de_cuenta.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'grilla_estado_de_cuenta.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End If


    End Sub

    Private Sub dtp_fecha_caja_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha_caja.ValueChanged

        mostrar_malla()
        SendKeys.Send("{Right}")
    End Sub

    Private Sub btn_cargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cargar.Click
        'mostrar_malla()
        Form_cargar_fecha_cheque.Show()
        Me.Enabled = False
    End Sub

    Private Sub txt_codigo_banco_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_banco.TextChanged
        'mostrar_nombre_banco()
    End Sub

    Private Sub dtp_fecha_cheque_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha_cheque.ValueChanged
        SendKeys.Send("{Right}")
    End Sub










    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage

        'crear_numero_factura()
        Dim VarNombreCliente As String
        Dim varTotalCheque As String
       



        Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
        Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
        Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
        Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)
        Dim Font8_negrita As New Font("Lucida Console Normal", 8, FontStyle.Bold)


        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far







        e.Graphics.DrawString("        CHEQUES DEPOSITO " & dtp_fecha_cheque.Text, Font8_negrita, Brushes.Black, 23, 0)

        e.Graphics.DrawLine(Pens.Black, 30, 14, 259, 14)

        e.Graphics.DrawString("CLIENTE", Font8_negrita, Brushes.Black, 30, 15)
        e.Graphics.DrawString("MONTO", Font8_negrita, Brushes.Black, 210, 15)

        For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1
            VarNombreCliente = grilla_estado_de_cuenta.Rows(i).Cells(3).Value.ToString
            varTotalCheque = grilla_estado_de_cuenta.Rows(i).Cells(7).Value.ToString
            varTotalCheque = Format(Int(varTotalCheque), "###,###,###")

            If VarNombreCliente.Length > 18 Then
                VarNombreCliente = VarNombreCliente.Substring(0, 18)
            End If

            e.Graphics.DrawString(VarNombreCliente, Font8, Brushes.Black, 30, 30 + (i * 15))
            e.Graphics.DrawString(varTotalCheque, Font8, Brushes.Black, 260, 30 + (i * 15), format1)
        Next


                Dim total_millar As String
                total_millar = txt_total.Text


                total_millar = Format(Int(total_millar), "###,###,###")

        e.Graphics.DrawLine(Pens.Black, 30, 29 + (grilla_estado_de_cuenta.Rows.Count * 15), 259, 29 + (grilla_estado_de_cuenta.Rows.Count * 15))

        e.Graphics.DrawString("TOTAL", Font8_negrita, Brushes.Black, 30, 30 + (grilla_estado_de_cuenta.Rows.Count * 15))
        e.Graphics.DrawString(total_millar, Font8_negrita, Brushes.Black, 260, 30 + (grilla_estado_de_cuenta.Rows.Count * 15), format1)

        e.Graphics.DrawString("-", Font8, Brushes.Black, 136, 95 + (grilla_estado_de_cuenta.Rows.Count * 15))


    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA IMPRIMIR EL LISTADO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")

        If valormensaje = vbYes Then
            lbl_mensaje.Visible = True
            Me.Enabled = False

            calcular_totales()

            With Pd.PrinterSettings
                'Especifico el nombre de la impresora 
                'por donde deseo imprimir. 
                .PrinterName = impresora_ticket
                'Establezco el número de copias que se imprimirán 
                .Copies = 1
                'Rango de páginas que se imprimirán 
                .PrintRange = PrintRange.AllPages
                If .IsValid Then
                    Me.Pd.PrintController = New StandardPrintController
                    Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                    Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                    Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                    Pd.Print()
                    actualizar_estado()
                    lbl_mensaje.Visible = False
                    Me.Enabled = True
                    MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Else
                    MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                    lbl_mensaje.Visible = False
                    Me.Enabled = True
                    Exit Sub
                End If
            End With
        End If
    End Sub

 
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_nueva_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nueva.Click
        controles(True, False)
        mostrar_malla()
        dtp_fecha_caja.Focus()
    End Sub




    Sub actualizar_estado()
        Dim VarFolio As String

        For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1
            VarFolio = grilla_estado_de_cuenta.Rows(i).Cells(0).Value.ToString

            SC.Connection = conexion
            SC.CommandText = "update CHEQUES set estado = 'DEPOSITADO' where cod_auto = '" & (VarFolio) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

        Next

        mostrar_malla()
    End Sub

End Class