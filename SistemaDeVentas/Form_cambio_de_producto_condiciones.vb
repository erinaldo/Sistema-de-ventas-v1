Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.IO
Public Class Form_cambio_de_producto_condiciones

    Private Sub Form_cambio_de_producto_condiciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Form_autorizacion_cambio_producto.Visible = False Then
            Form_cambio_de_producto.Enabled = True
            Form_cambio_de_producto.WindowState = FormWindowState.Normal
        Else
            Form_cambio_de_producto.Enabled = False
        End If
    End Sub

    Private Sub Form_cambio_de_producto_condiciones_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_cambio_de_producto_condiciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        condiciones()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub condiciones()

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
        combo_condiciones.SelectedItem = "-"

    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
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



        Dim VarPorcentajeDesc As String
        Dim VarCantidadDesc As Integer
        'Dim VarDescuentoCliente As Integer
        Dim porcentaje_desc As Integer
        Dim mensaje As String = ""
        VarCantidadDesc = 0



        'If Form_cambio_de_producto.txt_porcentaje_desc.Text > Int(12) And tipo_usuario = "USUARIO DEL SISTEMA" Then
        '    MsgBox("ESTE DESCUENTO DEBE SER AUTORIZADO POR UN ADMINISTRADOR DE SISTEMA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        Form_autorizacion_cambio_producto.lbl_autorizacion.Text = ""


        VarCantidadDesc = 0


        If Form_cambio_de_producto.txt_porcentaje_desc.Text = "" Then
            porcentaje_desc = 0
        Else
            porcentaje_desc = Form_cambio_de_producto.txt_porcentaje_desc.Text
        End If

        If mirutempresa = "87686300-6" Then
            If Int(porcentaje_desc) >= Int("12") Then
                Form_autorizacion_cambio_producto.Show()
                Form_autorizacion_cambio_producto.lbl_autorizacion.Text = "EL DESCUENTO FINAL EXCEDE EL MAXIMO"


                Form_cambio_de_producto.txt_condiciones.Text = combo_condiciones.Text

                Form_autorizacion_cambio_producto.Show()
                Me.Close()



                Exit Sub
            End If
        End If

        For i = 0 To Form_cambio_de_producto.grilla_detalle_venta.Rows.Count - 1
            VarPorcentajeDesc = Form_cambio_de_producto.grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
            If VarPorcentajeDesc > Int(valor_descuento_maximo_columna) Then
                VarCantidadDesc = VarCantidadDesc + 1
            End If
        Next


        If Int(VarCantidadDesc) <> "0" And Int(porcentaje_desc) > Int(valor_descuento_maximo) Then

            Form_autorizacion_cambio_producto.Show()
            If VarCantidadDesc = 1 Then
                Form_autorizacion_cambio_producto.lbl_autorizacion.Text = "SE HA APLICADO " & VarCantidadDesc & " DCTO. POR PRODUCTO Y EL DESCUENTO FINAL EXCEDE EL MAXIMO"
            Else
                Form_autorizacion_cambio_producto.lbl_autorizacion.Text = "SE HAN APLICADO " & VarCantidadDesc & " DCTOS. POR PRODUCTO Y EL DESCUENTO FINAL EXCEDE EL MAXIMO"
            End If



            Form_cambio_de_producto.txt_condiciones.Text = combo_condiciones.Text

            Form_autorizacion_cambio_producto.Show()
            Me.Close()


            Exit Sub
        End If

        If Int(VarCantidadDesc) <> "0" Then
            Form_autorizacion_cambio_producto.Show()
            If VarCantidadDesc = 1 Then
                Form_autorizacion_cambio_producto.lbl_autorizacion.Text = "SE HA APLICADO " & VarCantidadDesc & " DCTO. POR PRODUCTO"
            Else
                Form_autorizacion_cambio_producto.lbl_autorizacion.Text = "SE HAN APLICADO " & VarCantidadDesc & " DCTOS. POR PRODUCTO"
            End If


            Form_cambio_de_producto.txt_condiciones.Text = combo_condiciones.Text

            Form_autorizacion_cambio_producto.Show()
            Me.Close()



            Exit Sub
        End If

        If Int(porcentaje_desc) > Int(valor_descuento_maximo) Then
            'If txt_descuento_cliente.Text = "" Then
            '    txt_descuento_cliente.Text = 0
            'End If
            'If Int(txt_descuento_cliente.Text) >= Int(txt_porcentaje_desc.Text) Then
            'Else
            Form_autorizacion_cambio_producto.Show()
            Form_autorizacion_cambio_producto.lbl_autorizacion.Text = "EL DESCUENTO FINAL EXCEDE EL MAXIMO"


            Form_cambio_de_producto.txt_condiciones.Text = combo_condiciones.Text

            Form_autorizacion_cambio_producto.Show()
            Me.Close()



            Exit Sub
        End If
        'End If






        Form_autorizacion_cambio_producto.lbl_autorizacion.Text = "AUTORIZAR CAMBIO DE PRODUCTO"

        Form_cambio_de_producto.txt_condiciones.Text = combo_condiciones.Text

        Form_autorizacion_cambio_producto.Show()
        Me.Close()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub


    Private Sub combo_condiciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_condiciones.SelectedIndexChanged
        If combo_condiciones.Text = "OTRO MEDIO DE PAGO" Then
            Form_otro_medio_de_pago_cambio_de_producto.Show()
            Me.Enabled = False
        End If
    End Sub
End Class