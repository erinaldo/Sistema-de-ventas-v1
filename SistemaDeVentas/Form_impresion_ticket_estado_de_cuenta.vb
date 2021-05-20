Imports System.Runtime.InteropServices
Imports System.Net.Mail
'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared
Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.Resources


Public Class Form_impresion_ticket_estado_de_cuenta

    Dim numero_lineas_total As Integer = 0
    Dim impresora_ticket_estado_de_cuenta As String

    Private Sub Form_impresion_ticket_estado_de_cuenta_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_impresion_ticket_estado_de_cuenta_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form_estado_de_cuenta.lbl_mensaje.Visible = False
        Form_estado_de_cuenta.Enabled = True
        Form_estado_de_cuenta.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_impresion_ticket_estado_de_cuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mostrar_impresora()


        '  Threading.Thread.Sleep(5000)


        With Print_ticket.PrinterSettings
            .PrinterName = impresora_ticket_estado_de_cuenta
            .Copies = 1
            .PrintRange = PrintRange.AllPages
            If .IsValid Then
                Me.Print_ticket.PrintController = New StandardPrintController

                Try
                    Print_ticket.DefaultPageSettings.Landscape = False
                    Print_ticket.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                    Print_ticket.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
                Catch
                End Try

                Print_ticket.PrintController = New System.Drawing.Printing.StandardPrintController()
                Print_ticket.Print()
                'Me.Close()
            Else
                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                Me.Close()
            End If
        End With
    End Sub

    Sub mostrar_impresora()
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
            impresora_ticket_estado_de_cuenta = DS.Tables(DT.TableName).Rows(0).Item("ticket_estado_de_cuenta")
        End If
        conexion.Close()
    End Sub

    Private Sub Print_ticket_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles Print_ticket.PrintPage
        If Form_estado_de_cuenta.txt_direccion_cliente.Text.Length > 23 Then
            Form_estado_de_cuenta.txt_direccion_cliente.Text = Form_estado_de_cuenta.txt_direccion_cliente.Text.Substring(0, 23)
        End If

        Dim Font_texto_titulo As New Font("arial", 9, FontStyle.Bold)
        Dim Font_texto_empresa As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_cabecera As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_titulo_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_detalle As New Font("arial", 7, FontStyle.Bold)
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
        Dim rect_titulo As New Rectangle(margen_izquierdo + 10, margen_superior + 215, margen_izquierdo + 250, margen_superior + 15)
        Dim rect_fecha As New Rectangle(margen_izquierdo + 10, margen_superior + 235, margen_izquierdo + 250, margen_superior + 15)

        e.Graphics.DrawString(minombreempresa, Font_texto_empresa, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(migiroempresa, Font_texto_empresa, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font_texto_empresa, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font_texto_empresa, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font_texto_empresa, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font_texto_empresa, Brushes.Black, rect6, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font_texto_empresa, Brushes.Black, rect7, stringFormat)

        e.Graphics.DrawString("ESTADO DE CUENTA", Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + 230, margen_izquierdo + 270, margen_superior + 230)
        e.Graphics.DrawString(Form_menu_principal.lbl_fecha.Text, Font_texto_titulo, Brushes.Gray, rect_fecha, stringFormat)

        e.Graphics.DrawString("NOMBRE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 275)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 275)
        e.Graphics.DrawString(Form_estado_de_cuenta.txt_nombre_cliente.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 275)

        e.Graphics.DrawString("RUT", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 290)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 290)
        e.Graphics.DrawString(Form_estado_de_cuenta.txt_rut_cliente.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 290)

        e.Graphics.DrawString("DEUDA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 305)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 305)
        e.Graphics.DrawString("$" & Form_estado_de_cuenta.txt_total_deuda.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 305)

        e.Graphics.DrawString("TIPO DOC.", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 335)
        e.Graphics.DrawString("FECHA", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 90, margen_superior + 335)
        e.Graphics.DrawString("TOTAL", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 200, margen_superior + 335, format1)
        e.Graphics.DrawString("SALDO", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 265, margen_superior + 335, format1)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + 350, margen_izquierdo + 270, margen_superior + 350)

        Dim Varcoddocumento As String
        Dim VarTipo As String
        Dim Varfecha As String
        Dim VarRecinto As String
        Dim VarVencimiento As String
        Dim vartotal As String
        Dim varsaldo As String
        Dim varsaldoTotal As String
        Dim multiplicador_lineas As Integer = 15
        Dim numero_lineas As Integer = 0



        For i = numero_lineas_total To Form_estado_de_cuenta.grilla_estado_de_cuenta.Rows.Count - 1
            Varcoddocumento = Form_estado_de_cuenta.grilla_estado_de_cuenta.Rows(i).Cells(0).Value.ToString
            VarTipo = Form_estado_de_cuenta.grilla_estado_de_cuenta.Rows(i).Cells(1).Value.ToString
            Varfecha = Form_estado_de_cuenta.grilla_estado_de_cuenta.Rows(i).Cells(2).Value
            VarRecinto = Form_estado_de_cuenta.grilla_estado_de_cuenta.Rows(i).Cells(3).Value
            VarVencimiento = Form_estado_de_cuenta.grilla_estado_de_cuenta.Rows(i).Cells(4).Value
            vartotal = Form_estado_de_cuenta.grilla_estado_de_cuenta.Rows(i).Cells(5).Value.ToString
            varsaldo = Form_estado_de_cuenta.grilla_estado_de_cuenta.Rows(i).Cells(6).Value.ToString
            varsaldoTotal = Form_estado_de_cuenta.grilla_estado_de_cuenta.Rows(i).Cells(7).Value.ToString

            If varsaldo = "" Or varsaldo = "0" Then
                varsaldo = "0"
            Else
                varsaldo = Format(Int(varsaldo), "###,###,###")
            End If

            If varsaldoTotal = "" Or varsaldoTotal = "0" Then
                varsaldoTotal = "0"
            Else
                varsaldoTotal = Format(Int(varsaldoTotal), "###,###,###")
            End If

            If Varfecha.Length > 10 Then
                Varfecha = Varfecha.Substring(0, 10)
            End If

            If VarTipo = "BOLETA" Then
                VarTipo = "BOL"
            End If

            If VarTipo = "FACTURA" Then
                VarTipo = "FAC"
            End If

            If VarTipo = "NOTA DE CREDITO" Then
                VarTipo = "NDC"
            End If

            If VarTipo = "NOTA DE DEBITO" Then
                VarTipo = "NDB"
            End If

            If VarTipo = "NOTA DE CREDITO SIN IMPUTAR" Then
                VarTipo = "NDC"
            End If

            If VarTipo = "NOTA DE DEBITO SIN IMPUTAR" Then
                VarTipo = "NDB"
            End If

            If VarTipo = "ABONO SIN IMPUTAR" Then
                VarTipo = "ABONO"
            End If

            e.Graphics.DrawString(VarTipo & " " & Varcoddocumento, Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 355 + (numero_lineas * multiplicador_lineas))
            e.Graphics.DrawString(Varfecha, Font_texto_detalle, Brushes.Black, margen_izquierdo + 90, margen_superior + 355 + (numero_lineas * multiplicador_lineas))
            e.Graphics.DrawString(varsaldo, Font_texto_detalle, Brushes.Black, margen_izquierdo + 200, margen_superior + 355 + (numero_lineas * multiplicador_lineas), format1)
            e.Graphics.DrawString(varsaldoTotal, Font_texto_detalle, Brushes.Black, margen_izquierdo + 265, margen_superior + 355 + (numero_lineas * multiplicador_lineas), format1)

            numero_lineas = numero_lineas + 1
            numero_lineas_total = numero_lineas_total + 1


            If numero_lineas > 45 Then
                'Linea horizontal
                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + 355 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 270, margen_superior + 355 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************
                e.HasMorePages = True ' Todavia faltan mas paginas
                Exit Sub
            Else
                e.HasMorePages = False
            End If

        Next

        numero_lineas_total = 0

        numero_lineas = ((numero_lineas) * multiplicador_lineas)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 0, margen_superior + numero_lineas + 355, margen_izquierdo + 270, margen_superior + numero_lineas + 355)

        e.Graphics.DrawString("DATOS INFORMADOS ESTAN SUJETOS", Font_texto_detalle, Brushes.Black, margen_izquierdo + 40, margen_superior + 370 + numero_lineas)
        e.Graphics.DrawString("A CONFIRMACION.", Font_texto_detalle, Brushes.Black, margen_izquierdo + 90, margen_superior + 385 + numero_lineas)
        e.Graphics.DrawString("-", Font_texto_detalle, Brushes.Black, margen_izquierdo + 130, margen_superior + 440 + numero_lineas)

        Me.Close()

    End Sub
End Class