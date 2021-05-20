Imports System.IO
Public Class Form_pago_combinado

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If combo_condiciones.Text = "" Then
            MsgBox("CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_condiciones.Focus()
            Exit Sub
        End If

        If combo_condiciones.Text = "-" Then
            MsgBox("CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_condiciones.Focus()
            Exit Sub
        End If


        If txt_monto.Text = "" Then
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_monto.Focus()
            Exit Sub
        End If

        If Val(txt_monto.Text) > Val(txt_total.Text) Then
            MsgBox("MONTO DE PAGO NO PUEDE SER MAYOR AL TOTAL", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_monto.Focus()
            Exit Sub
        End If



        If Val(txt_monto.Text) > Val(Val(txt_total.Text) - Val(txt_total_pago.Text)) Then
            MsgBox("MONTO DE PAGO NO PUEDE SER MAYOR A LA DIFERENCIA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_monto.Focus()
            Exit Sub
        End If


        'grilla_pago_combinado.Rows.Add(combo_condiciones.Text, txt_monto.Text)
        'calcular_total()







        For i = 0 To grilla_pago_combinado.Rows.Count - 1
            Dim condicion As String
            Dim valor_condicion As Integer

            condicion = grilla_pago_combinado.Rows(i).Cells(0).Value.ToString
            valor_condicion = grilla_pago_combinado.Rows(i).Cells(1).Value.ToString

            If condicion = combo_condiciones.Text Then
                txt_monto.Text = Val(txt_monto.Text) + valor_condicion
                grilla_pago_combinado.Rows.Remove(grilla_pago_combinado.CurrentRow)
                grilla_pago_combinado.Rows.Add(combo_condiciones.Text, txt_monto.Text)
                calcular_total()
                combo_condiciones.SelectedItem = "-"
                Exit Sub
            End If
        Next

        grilla_pago_combinado.Rows.Add(combo_condiciones.Text, txt_monto.Text)
        calcular_total()
        combo_condiciones.SelectedItem = "-"






    End Sub

    Sub calcular_total()
        Dim totalgrilla As Integer

        '//Calcular el total general
        txt_total_pago.Text = 0
        For i = 0 To grilla_pago_combinado.Rows.Count - 1
            totalgrilla = Val(grilla_pago_combinado.Rows(i).Cells(1).Value.ToString)
            txt_total_pago.Text = Val(txt_total_pago.Text) + Val(totalgrilla)
        Next


        'If txt_total.Text = "" Or txt_total.Text = "0" Then
        '    txt_total_millar.Text = "0"
        'Else
        '    txt_total_millar.Text = Format(Int(txt_total.Text), "###,###,###")
        'End If
        txt_monto.Text = Val(txt_total.Text) - Val(txt_total_pago.Text)

        txt_monto.Focus()

        txt_monto.SelectionStart = 0
        txt_monto.SelectionLength = Len(txt_monto.Text)
    End Sub

    Private Sub Form_pago_combinado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_venta.WindowState = FormWindowState.Normal
        Form_venta.Enabled = True
    End Sub

    Private Sub Form_pago_combinado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()

        combo_condiciones.Items.Clear()
        combo_condiciones.Items.Add("-")
        combo_condiciones.Items.Add("EFECTIVO")
        combo_condiciones.Items.Add("TARJETA DEBITO")
        combo_condiciones.Items.Add("TARJETA CREDITO")
        combo_condiciones.Items.Add("CHEQUE AL DIA")
        combo_condiciones.Items.Add("CHEQUE 30-60 DIAS")
        combo_condiciones.SelectedItem = "-"

        txt_total.Text = Form_venta.txt_total.Text

        txt_monto.Text = Val(txt_total.Text) - Val(txt_total_pago.Text)

        grilla_pago_combinado.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)

        combo_condiciones.SelectedItem = "-"

        txt_monto.Focus()

        txt_monto.SelectionStart = 0
        txt_monto.SelectionLength = Len(txt_monto.Text)
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub


    Private Sub combo_condiciones_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_condiciones.GotFocus
        combo_condiciones.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_condiciones_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_condiciones.LostFocus
        combo_condiciones.BackColor = Color.White
    End Sub

    Private Sub txt_monto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_monto.Click
        txt_monto.SelectionStart = 0
        txt_monto.SelectionLength = Len(txt_monto.Text)
    End Sub

    Private Sub txt_monto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_monto.GotFocus
        txt_monto.BackColor = Color.LightSkyBlue
        txt_monto.SelectionStart = 0
        txt_monto.SelectionLength = Len(txt_monto.Text)
    End Sub

    Private Sub txt_monto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_monto.LostFocus
        txt_monto.BackColor = Color.White
    End Sub

    Private Sub btn_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.GotFocus
        btn_agregar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.LostFocus
        btn_agregar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_quitar_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.GotFocus
        btn_quitar_elemento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_elemento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.LostFocus
        btn_quitar_elemento.BackColor = Color.Transparent
    End Sub


    Private Sub btn_grabar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.GotFocus
        btn_grabar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_grabar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.LostFocus
        btn_grabar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub txt_monto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_monto.TextChanged

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_quitar_elemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        If grilla_pago_combinado.Rows.Count > 0 Then
            grilla_pago_combinado.Rows.Remove(grilla_pago_combinado.CurrentRow)
            calcular_total()
            txt_monto.Focus()
        End If
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        If grilla_pago_combinado.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_monto.Focus()
            Exit Sub
        End If

        If Val(txt_total_pago.Text) <> Val(Form_venta.txt_total.Text) Then
            MsgBox("MONTO DE PAGO DEBE SER IGUAL AL TOTAL", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_monto.Focus()
            Exit Sub
        End If

        Form_venta.descuento()
        Form_venta.imprimir()
    End Sub
End Class