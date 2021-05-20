Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing

Public Class Form_hojas_foleadas
    Dim representante As String
    Dim rut_representante As String
    Dim folio_unico As Integer
    Dim nro_sucursal As Integer
    Dim numero_lineas_total As Integer = 0

    Private Sub Form_hojas_foleadas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_hojas_foleadas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_hojas_foleadas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        cargar_impresoras()
        empresa()
        sucursales()

        Combo_orientacion.Text = "VERTICAL"
        Combo_tamaño.Text = "CARTA"

        Combo_impresora.Text = impresora_reportes
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub
    Sub cargar_impresoras()

        For Each tImpresora As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters()
            Combo_impresora.Items.Add(tImpresora)
        Next

    End Sub

    Sub empresa()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from empresa"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            representante = DS.Tables(DT.TableName).Rows(0).Item("representante")
            rut_representante = DS.Tables(DT.TableName).Rows(0).Item("rut_representante")

        End If
        conexion.Close()
    End Sub

    Sub sucursales()
        grilla_sucursales.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from sucursales order by nombre_sucursal asc"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_sucursales.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("nombre_sucursal"), _
                                            DS.Tables(DT.TableName).Rows(i).Item("ciudad"), _
                                             DS.Tables(DT.TableName).Rows(i).Item("tipo"))
            Next
        End If
    End Sub
    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        If txt_numero_inicio.Text = "" Then
            txt_numero_inicio.Focus()
            MsgBox("CAMPO DESDE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_numero_termino.Text = "" Then
            txt_numero_termino.Focus()
            MsgBox("CAMPO HASTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If Val(txt_numero_inicio.Text) > Val(txt_numero_termino.Text) Then
            txt_numero_inicio.Focus()
            MsgBox("LA NUMERACION NO C ORRESPONDE, FAVOR REVISAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        nro_sucursal = 0

        Dim i As Integer
        Dim desde As Integer
        Dim hojas As Integer

        hojas = Val(txt_numero_termino.Text) - Val(txt_numero_inicio.Text)
        desde = txt_numero_inicio.Text
        grilla_estado_de_cuenta.Rows.Clear()

        For i = 0 To hojas
            grilla_estado_de_cuenta.Rows.Add(desde, mirutempresa, minombreempresa, migiroempresa, representante, rut_representante)
            desde = desde + 1
            If desde > txt_numero_termino.Text Then
                If grilla_estado_de_cuenta.Rows.Count <> 0 Then
                    If grilla_estado_de_cuenta.Columns(0).Width = 150 Then
                        grilla_estado_de_cuenta.Columns(0).Width = 149
                    Else
                        grilla_estado_de_cuenta.Columns(0).Width = 150
                    End If
                End If
                lbl_mensaje.Visible = False
                Me.Enabled = True
                Exit Sub
            End If
        Next
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub txt_numero_inicio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero_inicio.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        grilla_estado_de_cuenta.Rows.Clear()
    End Sub

    Private Sub txt_numero_inicio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero_inicio.TextChanged

    End Sub

    Private Sub txt_numero_termino_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero_termino.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        grilla_estado_de_cuenta.Rows.Clear()
    End Sub

    Private Sub txt_numero_termino_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero_termino.TextChanged

    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        If grilla_estado_de_cuenta.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_numero_inicio.Focus()
            Exit Sub
        End If

        If Combo_impresora.Text = "" Then
            MsgBox("SELECCIONE UNA IMPRESORA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_impresora.Focus()
            Exit Sub
        End If

        If Combo_impresora.Text = "-" Then
            MsgBox("SELECCIONE UNA IMPRESORA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_impresora.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        nro_sucursal = 0


        Dim hojas As Integer

        hojas = Val(txt_numero_termino.Text) - Val(txt_numero_inicio.Text)

        folio_unico = txt_numero_inicio.Text



        For i = 0 To hojas



            lbl_mensaje.Visible = True
            Me.Enabled = False

            If Combo_orientacion.Text = "VERTICAL" And Combo_tamaño.Text = "CARTA" Then
                PrintDialog1.Document = PrintDocument1

                ' If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Try
                    PrintDocument1.DefaultPageSettings.Landscape = False
                    PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                    PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
                Catch
                End Try

                PrintDocument1.PrinterSettings.PrinterName = Combo_impresora.Text
                PrintDocument1.Print()
                'If
            End If

            If Combo_orientacion.Text = "VERTICAL" And Combo_tamaño.Text = "OFICIO" Then
                PrintDialog1.Document = PrintDocument1

                ' If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Try
                    PrintDocument1.DefaultPageSettings.Landscape = False
                    PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                    PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Folio
                Catch
                End Try

                PrintDocument1.PrinterSettings.PrinterName = Combo_impresora.Text
                PrintDocument1.Print()
                'If
            End If

            If Combo_orientacion.Text = "HORIZONTAL" And Combo_tamaño.Text = "CARTA" Then
                PrintDialog1.Document = PrintDocument1

                ' If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Try
                    PrintDocument1.DefaultPageSettings.Landscape = True
                    PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                    PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
                Catch
                End Try

                PrintDocument1.PrinterSettings.PrinterName = Combo_impresora.Text
                PrintDocument1.Print()
                'If
            End If

            If Combo_orientacion.Text = "HORIZONTAL" And Combo_tamaño.Text = "OFICIO" Then
                PrintDialog1.Document = PrintDocument1

                ' If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Try
                    PrintDocument1.DefaultPageSettings.Landscape = True
                    PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                    PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Folio
                Catch
                End Try

                PrintDocument1.PrinterSettings.PrinterName = Combo_impresora.Text
                PrintDocument1.Print()
                'If
            End If

            lbl_mensaje.Visible = False
            Me.Enabled = True

            'Exit Sub
            'If Combo_orientacion.Text = "VERTICAL" And Combo_tamaño.Text = "CARTA" Then
            '    Try
            '        Dim iReporte As New Form_informe_hojas_Foliadas
            '        Dim rpt As New Crystal_hojas_Foliadas

            '        rpt.Load()
            '        rpt.SetDataSource(ReturnDataSet)
            '        rpt.Refresh()

            '        iReporte.Reporte = rpt
            '        '  iReporte.ShowDialog()
            '        rpt.PrintOptions.PrinterName = Combo_impresora_boletas.Text
            '        rpt.PrintToPrinter(1, False, 0, 0)
            '    Catch ex As Exception
            '        MsgBox(ex.Message)
            '    End Try
            'End If


            'If Combo_orientacion.Text = "HORIZONTAL" And Combo_tamaño.Text = "CARTA" Then
            '    Try
            '        Dim iReporte As New Form_informe_hojas_Foliadas
            '        Dim rpt As New Crystal_hojas_foleadas_carta_horizontal

            '        rpt.Load()
            '        rpt.SetDataSource(ReturnDataSet)
            '        rpt.Refresh()

            '        iReporte.Reporte = rpt
            '        '  iReporte.ShowDialog()
            '        rpt.PrintOptions.PrinterName = Combo_impresora_boletas.Text
            '        rpt.PrintToPrinter(1, False, 0, 0)
            '    Catch ex As Exception
            '        MsgBox(ex.Message)
            '    End Try
            'End If

            'If Combo_orientacion.Text = "HORIZONTAL" And Combo_tamaño.Text = "OFICIO" Then
            '    Try
            '        Dim iReporte As New Form_informe_hojas_Foliadas
            '        Dim rpt As New Crystal_hojas_foleadas_oficio_horizontal

            '        rpt.Load()
            '        rpt.SetDataSource(ReturnDataSet)
            '        rpt.Refresh()

            '        iReporte.Reporte = rpt
            '        '  iReporte.ShowDialog()
            '        rpt.PrintOptions.PrinterName = Combo_impresora_boletas.Text
            '        rpt.PrintToPrinter(1, False, 0, 0)
            '    Catch ex As Exception
            '        MsgBox(ex.Message)
            '    End Try
            'End If

            'If Combo_orientacion.Text = "VERTICAL" And Combo_tamaño.Text = "OFICIO" Then
            '    Try
            '        Dim iReporte As New Form_informe_hojas_Foliadas
            '        Dim rpt As New Crystal_hojas_foliadas_oficio_vertical

            '        rpt.Load()
            '        rpt.SetDataSource(ReturnDataSet)
            '        rpt.Refresh()

            '        iReporte.Reporte = rpt
            '        rpt.PrintOptions.PrinterName = Combo_impresora_boletas.Text
            '        rpt.PrintToPrinter(1, False, 0, 0)
            '    Catch ex As Exception
            '        MsgBox(ex.Message)
            '    End Try
            'End If


            folio_unico = folio_unico + 1

            If folio_unico > txt_numero_termino.Text Then


                lbl_mensaje.Visible = False
                Me.Enabled = True

                Exit Sub

            End If


        Next















        lbl_mensaje.Visible = False
        Me.Enabled = True

    End Sub








    'Private Function ReturnDataSet() As DataSet
    '    Dim dt As New DataTable
    '    Dim dr As DataRow
    '    Dim ds As New DataSet


    '    dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
    '    dt.Columns.Add(New DataColumn("razon_social", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut", GetType(String)))
    '    dt.Columns.Add(New DataColumn("sucursal", GetType(String)))
    '    dt.Columns.Add(New DataColumn("TIPO", GetType(String)))
    '    dt.Columns.Add(New DataColumn("ciudad", GetType(String)))
    '    dt.Columns.Add(New DataColumn("giro", GetType(String)))
    '    dt.Columns.Add(New DataColumn("representante_legal", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_representante_legal", GetType(String)))
    '    dt.Columns.Add(New DataColumn("folio_unico", GetType(String)))



    '    nro_sucursal = 0

    '    Dim sucursal As String
    '    Dim tipo_suc As String
    '    Dim ciudad As String

    '    For i = 0 To grilla_sucursales.Rows.Count - 1

    '        sucursal = grilla_sucursales.Rows(i).Cells(0).Value.ToString
    '        ciudad = grilla_sucursales.Rows(i).Cells(1).Value
    '        tipo_suc = grilla_sucursales.Rows(i).Cells(2).Value.ToString

    '        dr = dt.NewRow()

    '        dr("razon_social") = minombreempresa
    '        dr("rut") = mirutempresa
    '        dr("sucursal") = sucursal & "-" & ciudad

    '        If tipo_suc = "SUCURSAL" Then
    '            nro_sucursal = Val(nro_sucursal) + 1
    '            dr("tipo") = tipo_suc & " " & nro_sucursal
    '        Else
    '            dr("tipo") = tipo_suc
    '        End If

    '        dr("ciudad") = ciudad
    '        dr("giro") = migiroempresa
    '        dr("representante_legal") = representante
    '        dr("rut_representante_legal") = rut_representante
    '        dr("folio_unico") = folio_unico
    '        dt.Rows.Add(dr)
    '    Next

    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "hojas_Foliadas"

    '    Dim iDS As New DS_hojas_Foliadas
    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS
    'End Function

    Public Function ImageToByte(ByVal pImagen As Image) As Byte()
        Dim mImage() As Byte
        Try
            If Not IsNothing(pImagen) Then
                Dim ms As New System.IO.MemoryStream
                pImagen.Save(ms, pImagen.RawFormat)
                mImage = ms.GetBuffer
                ms.Close()
                Return mImage
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub













    Private Sub btn_generar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_generar.GotFocus
        btn_generar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_generar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_generar.LostFocus
        btn_generar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        btn_imprimir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub txt_numero_inicio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero_inicio.GotFocus
        txt_numero_inicio.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_numero_inicio_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero_inicio.LostFocus
        txt_numero_inicio.BackColor = Color.White
    End Sub

    Private Sub txt_numero_termino_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero_termino.GotFocus
        txt_numero_termino.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_numero_termino_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero_termino.LostFocus
        txt_numero_termino.BackColor = Color.White
    End Sub

    Private Sub Combo_impresora_boletas_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_impresora.GotFocus
        Combo_impresora.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_impresora_boletas_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_impresora.LostFocus
        Combo_impresora.BackColor = Color.White
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font_titulo As New Font("arial", 12, FontStyle.Regular)
        Dim Font_subtitulo As New Font("arial", 9, FontStyle.Regular)
        Dim Font_titulo_columna As New Font("verdana", 6.5, FontStyle.Bold)
        Dim Font_texto_impresion As New Font("verdana", 6.5, FontStyle.Regular)
        Dim Font_campos_superiores As New Font("verdana", 7.5, FontStyle.Regular)
        Dim Font_datos_empresa As New Font("verdana", 7, FontStyle.Regular)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = -30
        margen_superior = 0

        nro_sucursal = 0

        Dim sucursal As String
        Dim tipo_suc As String
        Dim ciudad As String
        If Combo_orientacion.Text = "VERTICAL" And Combo_tamaño.Text = "CARTA" Then
            e.Graphics.DrawString("RAZON SOCIAL", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 10)
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, margen_superior + 10)
            e.Graphics.DrawString(minombreempresa, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, margen_superior + 10)

            e.Graphics.DrawString("RUT", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 20)
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, margen_superior + 20)
            e.Graphics.DrawString(mirutempresa, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, margen_superior + 20)

            For i = 0 To grilla_sucursales.Rows.Count - 1
                sucursal = grilla_sucursales.Rows(i).Cells(0).Value.ToString
                ciudad = grilla_sucursales.Rows(i).Cells(1).Value
                tipo_suc = grilla_sucursales.Rows(i).Cells(2).Value.ToString

                If tipo_suc = "SUCURSAL" Then
                    nro_sucursal = Val(nro_sucursal) + 1
                    e.Graphics.DrawString(tipo_suc & " " & nro_sucursal, Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (i * 10) + (margen_superior + 30))
                    e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (i * 10) + (margen_superior + 30))
                    e.Graphics.DrawString(sucursal & "-" & ciudad, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (i * 10) + (margen_superior + 30))
                Else
                    e.Graphics.DrawString(tipo_suc, Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (i * 10) + (margen_superior + 30))
                    e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (i * 10) + (margen_superior + 30))
                    e.Graphics.DrawString(sucursal & "-" & ciudad, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (i * 10) + (margen_superior + 30))
                End If
            Next

            e.Graphics.DrawString("GIRO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 30))
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 30))
            e.Graphics.DrawString(migiroempresa, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 30))

            e.Graphics.DrawString("REPRESENTANTE LEGAL", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 40))
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 40))
            e.Graphics.DrawString(representante, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 40))

            e.Graphics.DrawString("RUT", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 50))
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 50))
            e.Graphics.DrawString(rut_representante, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 50))

            e.Graphics.DrawString("FOLIO UNICO NACIONAL: " & folio_unico, Font_campos_superiores, Brushes.Black, margen_izquierdo + 850, margen_superior + 10, format1)
        End If

        If Combo_orientacion.Text = "HORIZONTAL" And Combo_tamaño.Text = "CARTA" Then
            e.Graphics.DrawString("RAZON SOCIAL", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 10)
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, margen_superior + 10)
            e.Graphics.DrawString(minombreempresa, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, margen_superior + 10)

            e.Graphics.DrawString("RUT", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 20)
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, margen_superior + 20)
            e.Graphics.DrawString(mirutempresa, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, margen_superior + 20)

            For i = 0 To grilla_sucursales.Rows.Count - 1
                sucursal = grilla_sucursales.Rows(i).Cells(0).Value.ToString
                ciudad = grilla_sucursales.Rows(i).Cells(1).Value
                tipo_suc = grilla_sucursales.Rows(i).Cells(2).Value.ToString

                If tipo_suc = "SUCURSAL" Then
                    nro_sucursal = Val(nro_sucursal) + 1
                    e.Graphics.DrawString(tipo_suc & " " & nro_sucursal, Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (i * 10) + (margen_superior + 30))
                    e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (i * 10) + (margen_superior + 30))
                    e.Graphics.DrawString(sucursal & "-" & ciudad, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (i * 10) + (margen_superior + 30))
                Else
                    e.Graphics.DrawString(tipo_suc, Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (i * 10) + (margen_superior + 30))
                    e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (i * 10) + (margen_superior + 30))
                    e.Graphics.DrawString(sucursal & "-" & ciudad, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (i * 10) + (margen_superior + 30))
                End If
            Next

            e.Graphics.DrawString("GIRO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 30))
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 30))
            e.Graphics.DrawString(migiroempresa, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 30))

            e.Graphics.DrawString("REPRESENTANTE LEGAL", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 40))
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 40))
            e.Graphics.DrawString(representante, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 40))

            e.Graphics.DrawString("RUT", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 50))
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 50))
            e.Graphics.DrawString(rut_representante, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 50))

            e.Graphics.DrawString("FOLIO UNICO NACIONAL: " & folio_unico, Font_campos_superiores, Brushes.Black, margen_izquierdo + 1100, margen_superior + 10, format1)
        End If

        If Combo_orientacion.Text = "VERTICAL" And Combo_tamaño.Text = "OFICIO" Then
            e.Graphics.DrawString("RAZON SOCIAL", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 10)
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, margen_superior + 10)
            e.Graphics.DrawString(minombreempresa, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, margen_superior + 10)

            e.Graphics.DrawString("RUT", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 20)
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, margen_superior + 20)
            e.Graphics.DrawString(mirutempresa, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, margen_superior + 20)

            For i = 0 To grilla_sucursales.Rows.Count - 1
                sucursal = grilla_sucursales.Rows(i).Cells(0).Value.ToString
                ciudad = grilla_sucursales.Rows(i).Cells(1).Value
                tipo_suc = grilla_sucursales.Rows(i).Cells(2).Value.ToString

                If tipo_suc = "SUCURSAL" Then
                    nro_sucursal = Val(nro_sucursal) + 1
                    e.Graphics.DrawString(tipo_suc & " " & nro_sucursal, Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (i * 10) + (margen_superior + 30))
                    e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (i * 10) + (margen_superior + 30))
                    e.Graphics.DrawString(sucursal & "-" & ciudad, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (i * 10) + (margen_superior + 30))
                Else
                    e.Graphics.DrawString(tipo_suc, Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (i * 10) + (margen_superior + 30))
                    e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (i * 10) + (margen_superior + 30))
                    e.Graphics.DrawString(sucursal & "-" & ciudad, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (i * 10) + (margen_superior + 30))
                End If
            Next

            e.Graphics.DrawString("GIRO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 30))
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 30))
            e.Graphics.DrawString(migiroempresa, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 30))

            e.Graphics.DrawString("REPRESENTANTE LEGAL", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 40))
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 40))
            e.Graphics.DrawString(representante, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 40))

            e.Graphics.DrawString("RUT", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 50))
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 50))
            e.Graphics.DrawString(rut_representante, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 50))

            e.Graphics.DrawString("FOLIO UNICO NACIONAL: " & folio_unico, Font_campos_superiores, Brushes.Black, margen_izquierdo + 850, margen_superior + 10, format1)
        End If

        If Combo_orientacion.Text = "HORIZONTAL" And Combo_tamaño.Text = "OFICIO" Then
            e.Graphics.DrawString("RAZON SOCIAL", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 10)
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, margen_superior + 10)
            e.Graphics.DrawString(minombreempresa, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, margen_superior + 10)

            e.Graphics.DrawString("RUT", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 20)
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, margen_superior + 20)
            e.Graphics.DrawString(mirutempresa, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, margen_superior + 20)

            For i = 0 To grilla_sucursales.Rows.Count - 1
                sucursal = grilla_sucursales.Rows(i).Cells(0).Value.ToString
                ciudad = grilla_sucursales.Rows(i).Cells(1).Value
                tipo_suc = grilla_sucursales.Rows(i).Cells(2).Value.ToString

                If tipo_suc = "SUCURSAL" Then
                    nro_sucursal = Val(nro_sucursal) + 1
                    e.Graphics.DrawString(tipo_suc & " " & nro_sucursal, Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (i * 10) + (margen_superior + 30))
                    e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (i * 10) + (margen_superior + 30))
                    e.Graphics.DrawString(sucursal & "-" & ciudad, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (i * 10) + (margen_superior + 30))
                Else
                    e.Graphics.DrawString(tipo_suc, Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (i * 10) + (margen_superior + 30))
                    e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (i * 10) + (margen_superior + 30))
                    e.Graphics.DrawString(sucursal & "-" & ciudad, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (i * 10) + (margen_superior + 30))
                End If
            Next

            e.Graphics.DrawString("GIRO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 30))
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 30))
            e.Graphics.DrawString(migiroempresa, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 30))

            e.Graphics.DrawString("REPRESENTANTE LEGAL", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 40))
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 40))
            e.Graphics.DrawString(representante, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 40))

            e.Graphics.DrawString("RUT", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 50))
            e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 190, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 50))
            e.Graphics.DrawString(rut_representante, Font_campos_superiores, Brushes.Black, margen_izquierdo + 200, (grilla_sucursales.Rows.Count * 10) + (margen_superior + 50))

            e.Graphics.DrawString("FOLIO UNICO NACIONAL: " & folio_unico, Font_campos_superiores, Brushes.Black, margen_izquierdo + 1100, margen_superior + 10, format1)
        End If
    End Sub
End Class