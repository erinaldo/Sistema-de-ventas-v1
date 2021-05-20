Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Resources
Imports System.IO

Public Class Form_contar_dinero

    Dim ex, ey As Integer

    Dim Arrastre As Boolean

    'Estas tres subrutinas permiten desplazar el formulario. 

    Private Sub Form_contar_dinero_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown

        ex = e.X

        ey = e.Y

        Arrastre = True

    End Sub

    Private Sub Form_contar_dinero_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp

        Arrastre = False

    End Sub

    Private Sub Form_contar_dinero_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove

        'Si el formulario no tiene borde (FormBorderStyle = none) la siguiente linea funciona bien

        If Arrastre Then Me.Location = Me.PointToScreen(New Point(Me.MousePosition.X - Me.Location.X - ex, Me.MousePosition.Y - Me.Location.Y - ey))

        'pero si quieres dejar los bordes y la barra de titulo entonces es necesario descomentar la siguiente linea y comentar la anterior, osea ponerle el apostrofe

        'If Arrastre Then Me.Location = Me.PointToScreen(New Point(Me.MousePosition.X - Me.Location.X - ex - 8, Me.MousePosition.Y - Me.Location.Y - ey - 60))

    End Sub

    Private Sub Form_contar_dinero_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_contar_dinero_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_contar_dinero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_cajeros()

        CambiaColorFondo(btn_imprimir, mirutempresa)
        CambiaColorFondo(btn_limpiar, mirutempresa)
        CambiaColorFondo(btn_salir, mirutempresa)
        CambiaColorFondo(Footer_bar, mirutempresa)
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

    Private Sub txt_cantidad_20000_TextChanged(sender As Object, e As EventArgs) Handles txt_cantidad_20000.TextChanged

        Dim valor As Integer = 20000
        Dim subtotal As Integer = Val(txt_cantidad_20000.Text) * valor
        txt_subtotal_20000.Text = subtotal
        sumar_total()

    End Sub

    Private Sub txt_cantidad_10000_TextChanged(sender As Object, e As EventArgs) Handles txt_cantidad_10000.TextChanged

        Dim valor As Integer = 10000
        Dim subtotal As Integer = Val(txt_cantidad_10000.Text) * valor
        txt_subtotal_10000.Text = subtotal
        sumar_total()

    End Sub

    Private Sub txt_cantidad_5000_TextChanged(sender As Object, e As EventArgs) Handles txt_cantidad_5000.TextChanged

        Dim valor As Integer = 5000
        Dim subtotal As Integer = Val(txt_cantidad_5000.Text) * valor
        txt_subtotal_5000.Text = subtotal
        sumar_total()

    End Sub

    Private Sub txt_cantidad_1000_TextChanged(sender As Object, e As EventArgs) Handles txt_cantidad_1000.TextChanged

        Dim valor As Integer = 1000
        Dim subtotal As Integer = Val(txt_cantidad_1000.Text) * valor
        txt_subtotal_1000.Text = subtotal
        sumar_total()

    End Sub

    Private Sub txt_cantidad_500_TextChanged(sender As Object, e As EventArgs) Handles txt_cantidad_500.TextChanged

        Dim valor As Integer = 500
        Dim subtotal As Integer = Val(txt_cantidad_500.Text) * valor
        txt_subtotal_500.Text = subtotal
        sumar_total()

    End Sub

    Private Sub txt_cantidad_100_TextChanged(sender As Object, e As EventArgs) Handles txt_cantidad_100.TextChanged

        Dim valor As Integer = 100
        Dim subtotal As Integer = Val(txt_cantidad_100.Text) * valor
        txt_subtotal_100.Text = subtotal
        sumar_total()

    End Sub

    Private Sub txt_cantidad_50_TextChanged(sender As Object, e As EventArgs) Handles txt_cantidad_50.TextChanged

        Dim valor As Integer = 50
        Dim subtotal As Integer = Val(txt_cantidad_50.Text) * valor
        txt_subtotal_50.Text = subtotal
        sumar_total()

    End Sub
    Private Sub txt_cantidad_10_TextChanged(sender As Object, e As EventArgs) Handles txt_cantidad_10.TextChanged

        Dim valor As Integer = 10
        Dim subtotal As Integer = Val(txt_cantidad_10.Text) * valor
        txt_subtotal_10.Text = subtotal
        sumar_total()

    End Sub





    Sub llenar_combo_cajeros()
        Combo_caja.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from usuarios WHERE ACTIVO='SI' order by nombre_usuario"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        Combo_caja.Items.Add("-")
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_caja.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_usuario"))
            Next
        End If
        Combo_caja.SelectedItem = ("-")

        conexion.Close()
    End Sub


    Public Function Formato_millar(Total_pesos As String) As String

        If Total_pesos = "" Or Total_pesos = "0" Then
            Total_pesos = "0"
        Else
            Total_pesos = "$" & Format(Int(Total_pesos), "###,###,###")
        End If

        Return Total_pesos

    End Function

    Sub sumar_total()
        Dim subtotal_20000 As String = txt_subtotal_20000.Text
        Dim subtotal_10000 As String = txt_subtotal_10000.Text
        Dim subtotal_5000 As String = txt_subtotal_5000.Text
        Dim subtotal_2000 As String = txt_subtotal_2000.Text
        Dim subtotal_1000 As String = txt_subtotal_1000.Text
        Dim subtotal_500 As String = txt_subtotal_500.Text
        Dim subtotal_100 As String = txt_subtotal_100.Text
        Dim subtotal_50 As String = txt_subtotal_50.Text
        Dim subtotal_10 As String = txt_subtotal_10.Text
        Dim subtotal_5 As String = txt_subtotal_5.Text

        subtotal_20000 = subtotal_20000.Replace(".", "")
        subtotal_10000 = subtotal_10000.Replace(".", "")
        subtotal_5000 = subtotal_5000.Replace(".", "")
        subtotal_2000 = subtotal_2000.Replace(".", "")
        subtotal_1000 = subtotal_1000.Replace(".", "")
        subtotal_500 = subtotal_500.Replace(".", "")
        subtotal_100 = subtotal_100.Replace(".", "")
        subtotal_50 = subtotal_50.Replace(".", "")
        subtotal_10 = subtotal_10.Replace(".", "")
        subtotal_5 = subtotal_5.Replace(".", "")

        subtotal_20000 = subtotal_20000.Replace("$", "")
        subtotal_10000 = subtotal_10000.Replace("$", "")
        subtotal_5000 = subtotal_5000.Replace("$", "")
        subtotal_2000 = subtotal_2000.Replace("$", "")
        subtotal_1000 = subtotal_1000.Replace("$", "")
        subtotal_500 = subtotal_500.Replace("$", "")
        subtotal_100 = subtotal_100.Replace("$", "")
        subtotal_50 = subtotal_50.Replace("$", "")
        subtotal_10 = subtotal_10.Replace("$", "")
        subtotal_5 = subtotal_5.Replace("$", "")

        txt_total.Text = Val(subtotal_20000) + Val(subtotal_10000) + Val(subtotal_5000) + Val(subtotal_2000) + Val(subtotal_1000) + Val(subtotal_500) + Val(subtotal_100) + Val(subtotal_50) + Val(subtotal_10) + Val(subtotal_5)

        subtotal_20000 = Formato_millar(subtotal_20000)
        subtotal_10000 = Formato_millar(subtotal_10000)
        subtotal_5000 = Formato_millar(subtotal_5000)
        subtotal_2000 = Formato_millar(subtotal_2000)
        subtotal_1000 = Formato_millar(subtotal_1000)
        subtotal_500 = Formato_millar(subtotal_500)
        subtotal_100 = Formato_millar(subtotal_100)
        subtotal_50 = Formato_millar(subtotal_50)
        subtotal_10 = Formato_millar(subtotal_10)
        subtotal_5 = Formato_millar(subtotal_5)

        txt_subtotal_20000.Text = subtotal_20000
        txt_subtotal_10000.Text = subtotal_10000
        txt_subtotal_5000.Text = subtotal_5000
        txt_subtotal_2000.Text = subtotal_2000
        txt_subtotal_1000.Text = subtotal_1000
        txt_subtotal_500.Text = subtotal_500
        txt_subtotal_100.Text = subtotal_100
        txt_subtotal_50.Text = subtotal_50
        txt_subtotal_10.Text = subtotal_10
        txt_subtotal_5.Text = subtotal_5

        txt_total.Text = Formato_millar(txt_total.Text)

    End Sub




    Private Sub txt_cantidad_20000_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad_20000.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cantidad_10000_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad_10000.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cantidad_5000_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad_5000.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cantidad_1000_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad_1000.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cantidad_500_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad_500.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cantidad_100_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad_100.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cantidad_50_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad_50.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cantidad_10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad_10.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btn_limpiar_Click(sender As Object, e As EventArgs) Handles btn_limpiar.Click

        txt_cantidad_20000.Text = ""
        txt_cantidad_10000.Text = ""
        txt_cantidad_5000.Text = ""
        txt_cantidad_2000.Text = ""
        txt_cantidad_1000.Text = ""
        txt_cantidad_500.Text = ""
        txt_cantidad_100.Text = ""
        txt_cantidad_50.Text = ""
        txt_cantidad_10.Text = ""
        txt_cantidad_5.Text = ""

        txt_subtotal_20000.Text = ""
        txt_subtotal_10000.Text = ""
        txt_subtotal_5000.Text = ""
        txt_subtotal_2000.Text = ""
        txt_subtotal_1000.Text = ""
        txt_subtotal_500.Text = ""
        txt_subtotal_100.Text = ""
        txt_subtotal_50.Text = ""
        txt_subtotal_10.Text = ""
        txt_subtotal_5.Text = ""

        txt_total.Text = ""

    End Sub

    Private Sub txt_cantidad_2000_TextChanged(sender As Object, e As EventArgs) Handles txt_cantidad_2000.TextChanged

        Dim valor As Integer = 2000
        Dim subtotal As Integer = Val(txt_cantidad_2000.Text) * valor
        txt_subtotal_2000.Text = subtotal
        sumar_total()

    End Sub

    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub txt_cantidad_5_TextChanged(sender As Object, e As EventArgs) Handles txt_cantidad_5.TextChanged

        Dim valor As Integer = 5
        Dim subtotal As Integer = Val(txt_cantidad_5.Text) * valor
        txt_subtotal_5.Text = subtotal
        sumar_total()

    End Sub

    Private Sub txt_cantidad_2000_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad_2000.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cantidad_5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad_5.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btn_imprimir_Click(sender As Object, e As EventArgs) Handles btn_imprimir.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False


        With PrintDocument_ticket.PrinterSettings
            .PrinterName = "Star TSP100 Cutter (TSP143)"
            .Copies = 1
            .PrintRange = PrintRange.AllPages
            If .IsValid Then
                Me.PrintDocument_ticket.PrintController = New StandardPrintController
                'Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                'Me.PrintDocument_ticket.DefaultPageSettings.PaperSize = pkCustomSize1
                PrintDocument_ticket.PrintController = New System.Drawing.Printing.StandardPrintController()
                PrintDocument_ticket.Print()
            Else
                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                lbl_mensaje.Visible = False
                Me.Enabled = True
                Exit Sub
            End If
        End With

        'Try
        '    Dim iReporte As New VisorReporte

        '    Dim rpt As New Crystal_caja_ticket

        '    rpt.Load()
        '    rpt.SetDataSource(ReturnDataSet)
        '    rpt.Refresh()

        '    iReporte.Reporte = rpt
        '    '  iReporte.ShowDialog()
        '    'rpt.PrintOptions.PrinterName = "\\Microsoft XPS Document Writer"
        '    rpt.PrintOptions.PrinterName = impresora_ticket
        '    rpt.PrintToPrinter(1, False, 0, 0)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PrintDocument_ticket_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument_ticket.PrintPage
        Dim Font_texto_titulo As New Font("arial", 9, FontStyle.Bold)
        Dim Font_texto_empresa As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_cabecera As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_titulo_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_detalle As New Font("arial", 9, FontStyle.Bold)
        Dim Font_texto_totales As New Font("arial", 9, FontStyle.Bold)

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = 0
        margen_superior = 0

        Try
            Dim imagen_reporte As Image
            imagen_reporte = Image.FromFile("C:\Temp\" & mirutempresa & "\Logo-impresion.jpg")
            Dim posicion_imagen As New PointF(margen_izquierdo + 0, margen_superior + 0)
            e.Graphics.DrawImage(imagen_reporte, posicion_imagen)
        Catch
        End Try

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center


        Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 90, margen_izquierdo + 250, margen_superior + 15)
        Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 105, margen_izquierdo + 250, margen_superior + 15)
        Dim rect3 As New Rectangle(margen_izquierdo + 10, margen_superior + 120, margen_izquierdo + 250, margen_superior + 15)
        Dim rect4 As New Rectangle(margen_izquierdo + 10, margen_superior + 135, margen_izquierdo + 250, margen_superior + 15)
        Dim rect5 As New Rectangle(margen_izquierdo + 10, margen_superior + 150, margen_izquierdo + 250, margen_superior + 15)
        Dim rect6 As New Rectangle(margen_izquierdo + 10, margen_superior + 165, margen_izquierdo + 250, margen_superior + 15)
        Dim rect7 As New Rectangle(margen_izquierdo + 10, margen_superior + 180, margen_izquierdo + 250, margen_superior + 15)

        e.Graphics.DrawString(minombreempresa, Font_texto_empresa, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(migiroempresa, Font_texto_empresa, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font_texto_empresa, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font_texto_empresa, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font_texto_empresa, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font_texto_empresa, Brushes.Black, rect6, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font_texto_empresa, Brushes.Black, rect7, stringFormat)

        Dim rect_titulo As New Rectangle(margen_izquierdo + 10, margen_superior + 215, margen_izquierdo + 250, margen_superior + 15)
        e.Graphics.DrawString("DETALLE EFECTIVO", Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + 230, margen_izquierdo + 270, margen_superior + 230)

        Dim rect_fecha As New Rectangle(margen_izquierdo + 10, margen_superior + 230, margen_izquierdo + 250, margen_superior + 15)
        e.Graphics.DrawString(Form_menu_principal.lbl_fecha.Text, Font_texto_cabecera, Brushes.Black, rect_fecha, stringFormat)

        Dim rect_recinto As New Rectangle(margen_izquierdo + 10, margen_superior + 245, margen_izquierdo + 250, margen_superior + 15)
        e.Graphics.DrawString(nombre_pc, Font_texto_cabecera, Brushes.Black, rect_recinto, stringFormat)

        'Dim rect_boletas As New Rectangle(margen_izquierdo + 10, margen_superior + 280, margen_izquierdo + 250, margen_superior + 15)
        'e.Graphics.DrawString("BILLETES DE $ 20.000", Font_texto_titulo, Brushes.Black, rect_boletas, stringFormat)

        e.Graphics.DrawString(Val(txt_cantidad_20000.Text) & " BILLETES DE $20.000", Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 300)
        e.Graphics.DrawString(":", Font_texto_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 300)
        e.Graphics.DrawString(txt_subtotal_20000.Text, Font_texto_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 300, format1)

        e.Graphics.DrawString(Val(txt_cantidad_10000.Text) & " BILLETES DE $10.000", Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 330)
        e.Graphics.DrawString(":", Font_texto_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 330)
        e.Graphics.DrawString(txt_subtotal_10000.Text, Font_texto_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 330, format1)

        e.Graphics.DrawString(Val(txt_cantidad_5000.Text) & " BILLETES DE $5.000", Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 360)
        e.Graphics.DrawString(":", Font_texto_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 360)
        e.Graphics.DrawString(txt_subtotal_5000.Text, Font_texto_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 360, format1)

        e.Graphics.DrawString(Val(txt_cantidad_2000.Text) & " BILLETES DE $2.000", Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 390)
        e.Graphics.DrawString(":", Font_texto_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 390)
        e.Graphics.DrawString(txt_subtotal_2000.Text, Font_texto_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 390, format1)

        e.Graphics.DrawString(Val(txt_cantidad_1000.Text) & " BILLETES DE $1.000", Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 420)
        e.Graphics.DrawString(":", Font_texto_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 420)
        e.Graphics.DrawString(txt_subtotal_1000.Text, Font_texto_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 420, format1)

        e.Graphics.DrawString(Val(txt_cantidad_500.Text) & " MONEDAS DE $500", Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 450)
        e.Graphics.DrawString(":", Font_texto_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 450)
        e.Graphics.DrawString(txt_subtotal_500.Text, Font_texto_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 450, format1)

        e.Graphics.DrawString(Val(txt_cantidad_100.Text) & " MONEDAS DE $100", Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 480)
        e.Graphics.DrawString(":", Font_texto_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 480)
        e.Graphics.DrawString(txt_subtotal_100.Text, Font_texto_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 480, format1)

        e.Graphics.DrawString(Val(txt_cantidad_50.Text) & " MONEDAS DE $50", Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 510)
        e.Graphics.DrawString(":", Font_texto_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 510)
        e.Graphics.DrawString(txt_subtotal_50.Text, Font_texto_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 510, format1)

        e.Graphics.DrawString(Val(txt_cantidad_10.Text) & " MONEDAS DE $10", Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 540)
        e.Graphics.DrawString(":", Font_texto_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 540)
        e.Graphics.DrawString(txt_subtotal_10.Text, Font_texto_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 540, format1)

        e.Graphics.DrawString(Val(txt_cantidad_5.Text) & " MONEDAS DE $5", Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 570)
        e.Graphics.DrawString(":", Font_texto_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 570)
        e.Graphics.DrawString(txt_subtotal_5.Text, Font_texto_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 570, format1)

        ''Linea horizontal
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + 600, margen_izquierdo + 810, margen_superior + 600)

        e.Graphics.DrawString("TOTAL EFECTIVO", Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 610)
        e.Graphics.DrawString(":", Font_texto_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 610)
        e.Graphics.DrawString(txt_total.Text, Font_texto_detalle, Brushes.Black, margen_izquierdo + 270, margen_superior + 610, format1)
        ''Linea horizontal
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + 635, margen_izquierdo + 810, margen_superior + 635)





        ''Linea horizontal
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + 750, margen_izquierdo + 810, margen_superior + 750)




        Dim rect_detalle As New Rectangle(margen_izquierdo + 10, margen_superior + 760, margen_izquierdo + 250, margen_superior + 15)
        e.Graphics.DrawString("FIRMA RESPONSABLE", Font_texto_titulo, Brushes.Black, rect_detalle, stringFormat)






        Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + 800, margen_izquierdo + 270, margen_superior + 15)
        e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)
    End Sub


End Class