Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_descuento

    Private Sub Form_descuento_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_venta.Enabled = True
        Form_venta.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_descuento_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_descuento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Dim iva As Long
        Dim neto As Long
        Dim total As Long
        Dim codigo As String
        Dim cantidad As String
        Dim desc As Long
        'Dim subtotal As Long
        'Dim saldo As Integer
        Dim iva_valor As String

        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As String
        Dim VarPorcentaje As Integer
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarSubtotal As Integer
        Dim VarTotal As Integer
        Dim VarTipoMedida As String

        'Dim VarProveedor As String
        'Dim VarCosto As Integer
        'Dim VarSaldo As Integer
        Dim VarConDescuento As Integer
        If txt_descto.Text = "" Then
            txt_descto.Text = "0"
        End If

        If txt_descto.Text = "" Then
            Exit Sub
        End If

        For i = 0 To Form_venta.grilla_detalle_venta.Rows.Count - 1

            VarCodProducto = Form_venta.grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            varnombre = Form_venta.grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
            vartecnico = Form_venta.grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
            VarValorUnitario = Form_venta.grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
            VarCantidad = Form_venta.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
            VarNeto = Form_venta.grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
            VarIva = Form_venta.grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
            VarSubtotal = Form_venta.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            VarPorcentaje = Form_venta.grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
            VarDescuento = Form_venta.grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            VarTotal = Form_venta.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString
            codigo = Form_venta.grilla_detalle_venta.CurrentRow.Cells(0).Value.ToString
            VarTipoMedida = Form_venta.grilla_detalle_venta.Rows(i).Cells(11).Value.ToString

            cantidad = Val(Form_venta.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString)
            If codigo = VarCodProducto Then
                Form_venta.grilla_detalle_venta.Rows.Remove(Form_venta.grilla_detalle_venta.Rows(i))

                'desc = ((VarValorUnitario * VarCantidad) * txt_descto.Text) / 100
                'subtotal = (VarCantidad * VarValorUnitario)

                'iva_valor = valor_iva / 100 + 1

                'neto = (subtotal / iva_valor)
                'iva = (neto) * valor_iva / 100
                'total = subtotal - desc





                desc = (VarValorUnitario * txt_descto.Text) / 100
                VarConDescuento = (VarValorUnitario - desc)

                iva_valor = valor_iva / 100 + 1

                total = VarConDescuento * VarCantidad

                neto = (total / iva_valor)
                iva = (neto) * valor_iva / 100


                desc = desc * VarCantidad


                Form_venta.grilla_detalle_venta.Rows.Add(VarCodProducto, varnombre, vartecnico, VarValorUnitario, VarCantidad, neto, iva, VarConDescuento, txt_descto.Text, desc, total, VarTipoMedida)
                Form_venta.txt_cantidad_agregar.Text = 0
                Form_venta.calcular_totales()
                '   Form_venta.detalle_label()
                Form_venta.limpiar_datos_productos()
                Form_venta.txt_codigo.Focus()
                Me.Close()
                Exit Sub
            End If
        Next
    End Sub

    Private Sub txt_descto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descto.KeyPress

        'e.KeyChar = e.KeyChar.ToString.ToUpper

        'If e.KeyChar = "'" Then
        '    e.KeyChar = "´"
        'End If

        'If e.KeyChar = "&" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = Chr(34) Then
        '    e.KeyChar = "´´"
        'End If

        'If e.KeyChar = "\" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "|" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "¿" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "?" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "}" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "{" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "<" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = ">" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "*" Then
        '    e.KeyChar = ""
        'End If

        'If e.KeyChar = "+" Then
        '    e.KeyChar = ""
        'End If



        'If txt_descto.Text = "" Then
        '    Exit Sub
        'End If


        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Dim iva As Long
            Dim neto As Long
            Dim total As Long
            Dim codigo As String
            Dim cantidad As String
            Dim desc As Long
            'Dim subtotal As Long
            'Dim saldo As Integer
            Dim iva_valor As String

            Dim VarCodProducto As String
            Dim varnombre As String
            Dim vartecnico As String
            Dim VarValorUnitario As Integer
            Dim VarCantidad As String
            Dim VarPorcentaje As Integer
            Dim VarDescuento As Integer
            Dim VarNeto As Integer
            Dim VarIva As Integer
            Dim VarSubtotal As Integer
            Dim VarTotal As Integer
            Dim VarTipoMedida As String

            'Dim VarProveedor As String
            'Dim VarCosto As Integer
            'Dim VarSaldo As Integer
            Dim VarConDescuento As Integer
            If txt_descto.Text = "" Then
                txt_descto.Text = "0"
            End If

            If txt_descto.Text = "" Then
                Exit Sub
            End If

            For i = 0 To Form_venta.grilla_detalle_venta.Rows.Count - 1

                VarCodProducto = Form_venta.grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                varnombre = Form_venta.grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                vartecnico = Form_venta.grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                VarValorUnitario = Form_venta.grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                VarCantidad = Form_venta.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                VarNeto = Form_venta.grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                VarIva = Form_venta.grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                VarSubtotal = Form_venta.grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                VarPorcentaje = Form_venta.grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                VarDescuento = Form_venta.grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                VarTotal = Form_venta.grilla_detalle_venta.Rows(i).Cells(10).Value.ToString


                If Form_venta.grilla_detalle_venta.CurrentRow.Cells(0).Value = "*" Then
                    codigo = "*"
                Else
                    codigo = Val(Form_venta.grilla_detalle_venta.CurrentRow.Cells(0).Value)
                End If



                VarTipoMedida = Form_venta.grilla_detalle_venta.Rows(i).Cells(11).Value.ToString


                cantidad = Val(Form_venta.grilla_detalle_venta.Rows(i).Cells(4).Value.ToString)
                If codigo = VarCodProducto Then
                    Form_venta.grilla_detalle_venta.Rows.Remove(Form_venta.grilla_detalle_venta.Rows(i))

                    'desc = ((VarValorUnitario * VarCantidad) * txt_descto.Text) / 100
                    'subtotal = (VarCantidad * VarValorUnitario)

                    'iva_valor = valor_iva / 100 + 1

                    'neto = (subtotal / iva_valor)
                    'iva = (neto) * valor_iva / 100
                    'total = subtotal - desc





                    desc = (VarValorUnitario * txt_descto.Text) / 100
                    VarConDescuento = (VarValorUnitario - desc)

                    iva_valor = valor_iva / 100 + 1

                    total = VarConDescuento * VarCantidad

                    neto = (total / iva_valor)
                    iva = (neto) * valor_iva / 100



                    desc = desc * VarCantidad

                    Form_venta.grilla_detalle_venta.Rows.Add(VarCodProducto, varnombre, vartecnico, VarValorUnitario, VarCantidad, neto, iva, VarConDescuento, txt_descto.Text, desc, total, VarTipoMedida)
                    Form_venta.txt_cantidad_agregar.Text = 0
                    Form_venta.calcular_totales()
                    '    Form_venta.detalle_label()
                    Form_venta.limpiar_datos_productos()
                    Form_venta.txt_codigo.Focus()
                    Me.Close()
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub txt_descto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descto.TextChanged

    End Sub
    Private Structure LASTINPUTINFO
        Public cbSize As UInteger
        Public dwTime As UInteger
    End Structure

    <DllImport("User32.dll")> _
    Private Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    End Function

    Public Function GetInactiveTime() As Nullable(Of TimeSpan)
        Dim info As LASTINPUTINFO = New LASTINPUTINFO
        info.cbSize = CUInt(Marshal.SizeOf(info))
        If (GetLastInputInfo(info)) Then
            Return TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime)
        Else
            Return Nothing
        End If
    End Function


    Private Sub Timer_descuento_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_descuento.Tick
        Dim inactiveTime = GetInactiveTime()
        If (inactiveTime.Value.TotalSeconds > tiempo_espera) Then
            Me.Close()
        End If
    End Sub


End Class