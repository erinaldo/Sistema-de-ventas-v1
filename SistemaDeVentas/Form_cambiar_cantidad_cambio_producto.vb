Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Public Class Form_cambiar_cantidad_cambio_producto

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Dim iva As Long
        Dim neto As Long
        Dim total As Long
        Dim codigo As String
        Dim cantidad As Integer
        Dim desc As Long
        'Dim subtotal As Long
        'Dim saldo As Integer
        Dim iva_valor As String

        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As Integer
        Dim VarPorcentaje As Integer
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarSubtotal As Integer
        Dim VarTotal As Integer



        Dim VarPrecioLista As Integer
        'Dim VarProveedor As String
        'Dim VarCosto As Integer
        'Dim VarSaldo As Integer
        Dim VarConDescuento As Integer
        If txt_cantidad.Text = "" Then
            txt_cantidad.Text = "0"
        End If

        If txt_cantidad.Text = "" Then
            Exit Sub
        End If

        For i = 0 To Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Count - 1

            VarCodProducto = Form_cambio_de_producto.grilla_detalle_venta_entra.Rows(i).Cells(0).Value.ToString
            varnombre = Form_cambio_de_producto.grilla_detalle_venta_entra.Rows(i).Cells(1).Value.ToString
            vartecnico = Form_cambio_de_producto.grilla_detalle_venta_entra.Rows(i).Cells(2).Value.ToString
            'VarValorUnitario = Form_cambio_de_producto.grilla_detalle_venta_entra.Rows(i).Cells(3).Value.ToString
            VarPrecioLista = Form_cambio_de_producto.grilla_detalle_venta_entra.Rows(i).Cells(3).Value.ToString
            VarValorUnitario = Form_cambio_de_producto.grilla_detalle_venta_entra.Rows(i).Cells(7).Value.ToString

            VarCantidad = Form_cambio_de_producto.grilla_detalle_venta_entra.Rows(i).Cells(4).Value.ToString


            If VarCantidad < Int(txt_cantidad.Text) Then
                MsgBox("LA CANTIDAD INGRESADA NO PUEDE SER MAYOR A LA CANTIDAD DE REFERENCIA", 0 + 16, "ERROR")
                txt_cantidad.Focus()
                Exit Sub
            End If







            VarCantidad = txt_cantidad.Text


            VarNeto = Form_cambio_de_producto.grilla_detalle_venta_entra.Rows(i).Cells(5).Value.ToString
            VarIva = Form_cambio_de_producto.grilla_detalle_venta_entra.Rows(i).Cells(6).Value.ToString
            VarSubtotal = Form_cambio_de_producto.grilla_detalle_venta_entra.Rows(i).Cells(7).Value.ToString
            VarPorcentaje = Form_cambio_de_producto.grilla_detalle_venta_entra.Rows(i).Cells(8).Value.ToString
            VarDescuento = Form_cambio_de_producto.grilla_detalle_venta_entra.Rows(i).Cells(9).Value.ToString
            VarTotal = Form_cambio_de_producto.grilla_detalle_venta_entra.Rows(i).Cells(10).Value.ToString
            codigo = Form_cambio_de_producto.grilla_detalle_venta_entra.CurrentRow.Cells(0).Value.ToString

            cantidad = Val(txt_cantidad.Text)

            If codigo = VarCodProducto Then
                Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Remove(Form_cambio_de_producto.grilla_detalle_venta_entra.Rows(i))

                'desc = ((VarValorUnitario * VarCantidad) * txt_descto.Text) / 100
                'subtotal = (VarCantidad * VarValorUnitario)

                'iva_valor = valor_iva / 100 + 1

                'neto = (subtotal / iva_valor)
                'iva = (neto) * valor_iva / 100
                'total = subtotal - desc





                desc = (VarPrecioLista * VarPorcentaje) / 100
                VarConDescuento = (VarPrecioLista - desc)

                iva_valor = valor_iva / 100 + 1

                total = VarConDescuento * VarCantidad

                neto = (total / iva_valor)
                iva = (neto) * valor_iva / 100


                desc = desc * VarCantidad


                Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Add(VarCodProducto, varnombre, vartecnico, VarPrecioLista, VarCantidad, neto, iva, VarConDescuento, VarPorcentaje, desc, total)

                'Form_cambio_de_producto.grilla_detalle_venta_entra.Rows.Add(VarCodProducto, varnombre, vartecnico, VarValorUnitario, VarCantidad, neto, iva, VarConDescuento, VarPorcentaje, desc, total)
                Form_cambio_de_producto.txt_cantidad_agregar.Text = 0
                Form_cambio_de_producto.calcular_totales_entra()
                '   Form_venta.detalle_label()
                Form_cambio_de_producto.limpiar_producto()
                Form_cambio_de_producto.txt_codigo.Focus()
                Me.Close()
                Exit Sub
            End If
        Next
    End Sub

    Private Sub Form_cambiar_cantidad_cambio_producto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_cambio_de_producto.Enabled = True
        Form_cambio_de_producto.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_cambiar_cantidad_cambio_producto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_cambiar_cantidad_cambio_producto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub txt_cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad.KeyPress
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

    Private Sub txt_cantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad.TextChanged

    End Sub


End Class