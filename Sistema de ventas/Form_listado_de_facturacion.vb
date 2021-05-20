Imports System.IO
Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient
Imports System.Resources
Imports System.Drawing.Printing

Public Class Form_listado_de_facturacion
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim numero_lineas_total As Integer = 0
    Dim tipo_impresion As Integer = 0
    Private Sub Form_lista_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_facturacion.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_lista_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    'cargamos el sub fecha y sub fecha 2 y mostrar lista.
    Private Sub Form_lista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        grilla_lista.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        Combo_año.Text = Year(Now)
        txt_mes.Text = Month(Now)
        seleccionar_mes()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")
    End Sub

    'selecciona todos los clientes que tengan guias sin facturar
    Sub mostrar_lista()
        Dim consulta As String

        consulta = "select factura.n_factura as 'NRO.', factura.rut_cliente AS RUT, nombre_cliente AS 'NOMBRE', COUNT(detalle_factura.cod_auto) AS 'GUIAS', factura.descuento AS 'DESCUENTO' , factura.total AS TOTAL, clientes.folio_cliente as FOLIO from factura , detalle_factura, clientes where fecha_venta= '" & (mifecha2) & "' and factura.n_factura = detalle_factura.n_factura and factura.rut_cliente=clientes.rut_cliente and factura.condiciones ='CREDITO'  and factura.usuario_responsable ='SISTEMA' group by cod_cliente order by nombre_cliente"

        grilla_lista.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = consulta
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        grilla_lista.Rows.Clear()
        grilla_lista.Columns.Clear()
        grilla_lista.Columns.Add("", "FACTURA")
        grilla_lista.Columns.Add("", "RUT")
        grilla_lista.Columns.Add("", "NOMBRE")
        grilla_lista.Columns.Add("", "GUIAS")
        grilla_lista.Columns.Add("", "DESCUENTO")
        grilla_lista.Columns.Add("", "TOTAL")
        grilla_lista.Columns.Add("", "FOLIO")

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For e = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_lista.Rows.Add(DS.Tables(DT.TableName).Rows(e).Item("NRO."), _
                                       DS.Tables(DT.TableName).Rows(e).Item("RUT"), _
                                        DS.Tables(DT.TableName).Rows(e).Item("NOMBRE"), _
                                         DS.Tables(DT.TableName).Rows(e).Item("GUIAS"), _
                                          DS.Tables(DT.TableName).Rows(e).Item("DESCUENTO"), _
                                           DS.Tables(DT.TableName).Rows(e).Item("TOTAL"), _
                                            DS.Tables(DT.TableName).Rows(e).Item("FOLIO"))
            Next
        End If

        If grilla_lista.Rows.Count <> 0 Then

            If grilla_lista.Columns(0).Width = 100 Then
                grilla_lista.Columns(0).Width = 99
            Else
                grilla_lista.Columns(0).Width = 100
                grilla_lista.Columns(1).Width = 100
                grilla_lista.Columns(2).Width = 200
                grilla_lista.Columns(3).Width = 100
                grilla_lista.Columns(4).Width = 100
                grilla_lista.Columns(5).Width = 100
                grilla_lista.Columns(6).Width = 100
            End If

        End If

        grilla_lista.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_lista.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_lista.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_lista.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_lista.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_lista.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_lista.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    'grabamos los datos de la lsita mediante una tabla temporal.
    Sub grabar_lista()
        Dim Varrut As String
        Dim Varnombre As String
        Dim Vartotal_guia As String
        Dim Vardescuento As String
        Dim Vartotal_factura As String
        Dim Varfolio As String

        SC.Connection = conexion
        SC.CommandText = " DELETE FROM lista_temporal WHERE id_lista <> '68H9'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        For i = 0 To grilla_lista.Rows.Count - 1
            Varrut = grilla_lista.Rows(i).Cells(0).Value.ToString
            Varnombre = grilla_lista.Rows(i).Cells(1).Value.ToString
            Vartotal_guia = grilla_lista.Rows(i).Cells(2).Value.ToString
            Vardescuento = grilla_lista.Rows(i).Cells(3).Value.ToString
            Vartotal_factura = grilla_lista.Rows(i).Cells(4).Value.ToString
            Varfolio = grilla_lista.Rows(i).Cells(5).Value.ToString

            SC.Connection = conexion
            SC.CommandText = "insert into lista_temporal (rut, nombre, total_guia, descuento, total_factura, folio) values('" & (Varrut) & "','" & (Varnombre) & "','" & (Vartotal_guia) & "'," & (Vardescuento) & "," & (Vartotal_factura) & ",'" & (Varfolio) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next
    End Sub

    'grabamos los datos de la lsita mediante una tabla temporal.
    Sub grabar_lista2()
        Dim Varrut As String
        Dim Varnombre As String
        Dim Vartotal_guia As String
        Dim Vardescuento As String
        Dim Vartotal_factura As String
        Dim Varfolio As String

        SC.Connection = conexion
        SC.CommandText = " DELETE FROM lista_temporal WHERE id_lista <>'68H9'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        For i = 0 To grilla_lista.Rows.Count - 1

            Varrut = grilla_lista.Rows(i).Cells(0).Value.ToString
            Varnombre = grilla_lista.Rows(i).Cells(1).Value.ToString
            Vartotal_guia = grilla_lista.Rows(i).Cells(2).Value.ToString
            Vardescuento = grilla_lista.Rows(i).Cells(3).Value.ToString
            Vartotal_factura = grilla_lista.Rows(i).Cells(4).Value.ToString
            Varfolio = grilla_lista.Rows(i).Cells(5).Value.ToString

            SC.Connection = conexion
            SC.CommandText = "insert into lista_temporal (rut, nombre, total_guia, descuento, total_factura, folio) values('" & (Varrut) & "','" & (Varnombre) & "','" & (Vartotal_guia) & "'," & (Vardescuento) & "," & (Vartotal_factura) & ",'" & (Varfolio) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

        Next
    End Sub

    'verificamos que la grilla no este vacia, grabamos los datos y pósteriormente los imprimimos.
    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        If grilla_lista.Rows.Count = 0 Then
            Combo_mes.Focus()
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            lbl_mensaje.Visible = False
            Me.Enabled = True
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        tipo_impresion = 1
        PrintDialog1.Document = PrintDocument1

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument1.DefaultPageSettings.Landscape = False
            PrintDocument1.Print()

            Try
                PrintDocument1.DefaultPageSettings.Landscape = False
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
            Catch
            End Try
        End If

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_listado2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_listado2.Click
        If grilla_lista.Rows.Count = 0 Then
            Combo_mes.Focus()
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            lbl_mensaje.Visible = False
            Me.Enabled = True
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        tipo_impresion = 2
        PrintDialog1.Document = PrintDocument1

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument1.DefaultPageSettings.Landscape = False
            PrintDocument1.Print()

            Try
                PrintDocument1.DefaultPageSettings.Landscape = False
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
            Catch
            End Try
        End If

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
    End Sub

    Private Sub Combo_año_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_año.GotFocus
        Combo_año.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_año_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_año.LostFocus
        Combo_año.BackColor = Color.White
    End Sub

    Private Sub Combo_mes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_mes.GotFocus
        Combo_mes.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_mes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_mes.LostFocus
        Combo_mes.BackColor = Color.White
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

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_listado2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_listado2.GotFocus
        btn_listado2.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_listado2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_listado2.LostFocus
        btn_listado2.BackColor = Color.Transparent
    End Sub








    Sub recuperar_conexion()
        Dim nombre_servidor As String
        Dim nombre_servidor_remoto As String
        Dim base_de_datos As String
        Dim clave_base_de_datos As String
        Dim usuario As String
        Dim recinto As String
        Dim rut_empresa As String
        Try
            For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1
                nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
                nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
                base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
                clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
                usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
                recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
                rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString

                If SucursalSeleccionada = recinto Then
                    Try
                        conexion.Close()
                        conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                        conexion.Open()
                        conexion.Close()
                    Catch
                        conexion.Close()
                        conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                        conexion.Open()
                        conexion.Close()
                    End Try
                End If
            Next
        Catch
            Me.Close()
            Form_menu_principal.Close()
        End Try
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim ruta_archivo As String
        Dim hora_sistema As String
        Dim fecha_sistema As String

        If grilla_lista.Rows.Count = 0 Then
            Combo_mes.Focus()
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        hora_sistema = Form_menu_principal.lbl_hora.Text
        hora_sistema = hora_sistema.Replace(":", " ")
        fecha_sistema = Format(Today.Date, "Long Date")
        fecha_sistema = fecha_sistema.Replace(",", " ")
        ruta_archivo = My.Computer.FileSystem.SpecialDirectories.Desktop & "\LISTADO FACTURACION " & fecha_sistema & " " & hora_sistema & ".csv"

        exportar_excel()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Function exportar_excel() As Boolean


        Dim ruta_archivo As String
        Dim hora_sistema As String
        Dim fecha_sistema As String

        hora_sistema = Form_menu_principal.lbl_hora.Text
        hora_sistema = hora_sistema.Replace(":", " ")



        fecha_sistema = Format(Today.Date, "Long Date")

        fecha_sistema = fecha_sistema.Replace(",", " ")

        ruta_archivo = My.Computer.FileSystem.SpecialDirectories.Desktop & "\LISTADO FACTURACION " & fecha_sistema & " " & hora_sistema & ".csv"





        'Dim cadenaubicacion As String
        'Dim directorio As New FolderBrowserDialog
        'If directorio.ShowDialog = DialogResult.OK Then
        '    cadenaubicacion = directorio.SelectedPath
        Try
            Dim stream As Stream
            Dim escritor As StreamWriter
            Dim fila = grilla_lista.Rows.Count
            Dim columnas = grilla_lista.Columns.Count
            Dim archivo As String = ruta_archivo
            Dim linea As String = ""
            Dim filadata, column As Int32

            File.Delete(archivo)
            stream = File.OpenWrite(archivo)
            escritor = New StreamWriter(stream, System.Text.Encoding.UTF8)

            For column = 0 To columnas - 1
                linea = linea & grilla_lista.Columns(column).HeaderText & ";"
            Next
            linea = Mid(CStr(linea), 1, linea.ToString.Length - 1)
            escritor.WriteLine(linea)
            linea = Nothing
            For filadata = 0 To fila - 1
                For column = 0 To columnas - 1
                    linea = linea & CStr(grilla_lista.Item(column, filadata).Value) & ";"
                Next
                linea = Mid(CStr(linea), 1, linea.ToString.Length - 1)
                escritor.WriteLine(linea)
                linea = Nothing
            Next
            escritor.Close()
            Try
                ''Process.Start(archivo)
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        'End If
        'Return False
    End Function

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        fecha()
        mostrar_lista()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub Combo_mes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_mes.SelectedIndexChanged
        grilla_lista.Rows.Clear()
        nombre_mes()
        dtp_desde.Text = "01" & "-" & (Val(txt_mes.Text) + Val(1)) & "-" & Combo_año.Text
        dtp_desde.Value = dtp_desde.Value.AddDays(Val(-1))
    End Sub

    Sub nombre_mes()

        If Combo_mes.Text = "ENERO" Then
            txt_mes.Text = "01"
        End If

        If Combo_mes.Text = "FEBRERO" Then
            txt_mes.Text = "02"
        End If

        If Combo_mes.Text = "MARZO" Then
            txt_mes.Text = "03"
        End If

        If Combo_mes.Text = "ABRIL" Then
            txt_mes.Text = "04"
        End If

        If Combo_mes.Text = "MAYO" Then
            txt_mes.Text = "05"
        End If

        If Combo_mes.Text = "JUNIO" Then
            txt_mes.Text = "06"
        End If

        If Combo_mes.Text = "JULIO" Then
            txt_mes.Text = "07"
        End If

        If Combo_mes.Text = "AGOSTO" Then
            txt_mes.Text = "08"
        End If

        If Combo_mes.Text = "SEPTIEMBRE" Then
            txt_mes.Text = "09"
        End If

        If Combo_mes.Text = "OCTUBRE" Then
            txt_mes.Text = "10"
        End If

        If Combo_mes.Text = "NOVIEMBRE" Then
            txt_mes.Text = "11"
        End If

        If Combo_mes.Text = "DICIEMBRE" Then
            txt_mes.Text = "12"
        End If

    End Sub

    Sub seleccionar_mes()
        If txt_mes.Text = "1" Then
            Combo_mes.Text = "ENERO"
        End If

        If txt_mes.Text = "2" Then
            Combo_mes.Text = "FEBRERO"
        End If

        If txt_mes.Text = "3" Then
            Combo_mes.Text = "MARZO"
        End If

        If txt_mes.Text = "4" Then
            Combo_mes.Text = "ABRIL"
        End If

        If txt_mes.Text = "5" Then
            Combo_mes.Text = "MAYO"
        End If

        If txt_mes.Text = "JUNIO" Then
            Combo_mes.Text = "06"
        End If

        If txt_mes.Text = "7" Then
            Combo_mes.Text = "JULIO"
        End If

        If txt_mes.Text = "8" Then
            Combo_mes.Text = "AGOSTO"
        End If

        If txt_mes.Text = "9" Then
            Combo_mes.Text = "SEPTIEMBRE"
        End If

        If txt_mes.Text = "10" Then
            Combo_mes.Text = "OCTUBRE"
        End If

        If txt_mes.Text = "11" Then
            Combo_mes.Text = "NOVIEMBRE"
        End If

        If txt_mes.Text = "12" Then
            Combo_mes.Text = "DICIEMBRE"
        End If
    End Sub

    Private Sub Combo_año_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_año.SelectedIndexChanged
        grilla_lista.Rows.Clear()
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font_titulo As New Font("arial", 12, FontStyle.Regular)
        Dim Font_subtitulo As New Font("arial", 9, FontStyle.Regular)
        Dim Font_titulo_columna As New Font("verdana", 7, FontStyle.Bold)
        Dim Font_texto_impresion As New Font("verdana", 7, FontStyle.Regular)
        Dim Font_campos_superiores As New Font("verdana", 8, FontStyle.Regular)
        Dim Font_datos_empresa As New Font("verdana", 7, FontStyle.Regular)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = -30
        margen_superior = 0

        Try
            e.Graphics.DrawImage(Bytes_Imagen(Imagen_reporte), 560, 10, 260, 70)
        Catch
        End Try

        e.Graphics.DrawString(minombreempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 10)
        e.Graphics.DrawString(migiroempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 20)
        e.Graphics.DrawString(midireccionempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 30)
        e.Graphics.DrawString(micomunaempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 40)
        e.Graphics.DrawString(mitelefonoempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 50)
        e.Graphics.DrawString(mirutempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 60)

        Dim rect1 As New Rectangle(margen_izquierdo + 50, margen_superior + 55, margen_izquierdo + 810, margen_superior + 45)
        Dim rect2 As New Rectangle(margen_izquierdo + 50, margen_superior + 70, margen_izquierdo + 810, margen_superior + 60)

        e.Graphics.DrawString("LISTADO DE FACTURACION", Font_titulo, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 88, margen_izquierdo + 865, margen_superior + 88)
        e.Graphics.DrawString(Combo_mes.Text & " DEL " & Combo_año.Text, Font_subtitulo, Brushes.Gray, rect2, stringFormat)

        If tipo_impresion = 1 Then
            e.Graphics.DrawString("FACTURA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 50, margen_superior + 120)
            e.Graphics.DrawString("RUT", Font_titulo_columna, Brushes.Black, margen_izquierdo + 150, margen_superior + 120)
            e.Graphics.DrawString("NOMBRE", Font_titulo_columna, Brushes.Black, margen_izquierdo + 250, margen_superior + 120)
            e.Graphics.DrawString("TOTAL GUIAS", Font_titulo_columna, Brushes.Black, margen_izquierdo + 550, margen_superior + 120, format1)
            e.Graphics.DrawString("DESCUENTO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 650, margen_superior + 120, format1)
            e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 750, margen_superior + 120, format1)
            e.Graphics.DrawString("FOLIO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 850, margen_superior + 120, format1)

            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 135, margen_izquierdo + 865, margen_superior + 135)

            Dim VarFactura As String
            Dim VarRut As String
            Dim VarNombre As String
            Dim VarGuias As String
            Dim VarDescuento As String
            Dim VarTotal As String
            Dim VarFolio As String

            Dim numero_lineas As Integer = 0
            Dim multiplicador_lineas As Integer = 10

            For i = numero_lineas_total To grilla_lista.Rows.Count - 1

                VarFactura = grilla_lista.Rows(i).Cells(0).Value.ToString
                VarRut = grilla_lista.Rows(i).Cells(1).Value.ToString
                VarNombre = grilla_lista.Rows(i).Cells(2).Value.ToString
                VarGuias = grilla_lista.Rows(i).Cells(3).Value.ToString
                VarDescuento = grilla_lista.Rows(i).Cells(4).Value.ToString
                VarTotal = grilla_lista.Rows(i).Cells(5).Value.ToString
                VarFolio = grilla_lista.Rows(i).Cells(6).Value.ToString

                If VarDescuento = "" Or VarDescuento = "0" Then
                    VarDescuento = "0"
                Else
                    VarDescuento = Format(Int(VarDescuento), "###,###,###")
                End If

                If VarTotal = "" Or VarTotal = "0" Then
                    VarTotal = "0"
                Else
                    VarTotal = Format(Int(VarTotal), "###,###,###")
                End If

                If VarNombre.Length > 35 Then
                    VarNombre = VarNombre.Substring(0, 35)
                End If

                e.Graphics.DrawString(VarFactura, Font_texto_impresion, Brushes.Black, margen_izquierdo + 50, margen_superior + 140 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(VarRut, Font_texto_impresion, Brushes.Black, margen_izquierdo + 150, margen_superior + 140 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(VarNombre, Font_texto_impresion, Brushes.Black, margen_izquierdo + 250, margen_superior + 140 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(VarGuias, Font_texto_impresion, Brushes.Black, margen_izquierdo + 550, margen_superior + 140 + (numero_lineas * multiplicador_lineas), format1)
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(VarDescuento, Font_texto_impresion, Brushes.Black, margen_izquierdo + 650, margen_superior + 140 + (numero_lineas * multiplicador_lineas), format1)
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(VarTotal, Font_texto_impresion, Brushes.Black, margen_izquierdo + 750, margen_superior + 140 + (numero_lineas * multiplicador_lineas), format1)
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(VarFolio, Font_texto_impresion, Brushes.Black, margen_izquierdo + 850, margen_superior + 140 + (numero_lineas * multiplicador_lineas), format1)
                '***************************************************************************************************************************************************

                numero_lineas = numero_lineas + 1
                numero_lineas_total = numero_lineas_total + 1

                If numero_lineas > 85 Then
                    'Linea horizontal
                    e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 145 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 145 + (numero_lineas * multiplicador_lineas))
                    '***************************************************************************************************************************************************
                    e.HasMorePages = True ' Todavia faltan mas paginas
                    Exit Sub
                Else
                    e.HasMorePages = False
                End If
            Next

            'Linea horizontal
            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 145 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 145 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            numero_lineas_total = 0
        End If


        If tipo_impresion = 2 Then
            e.Graphics.DrawString("FACTURA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 50, margen_superior + 120)
            e.Graphics.DrawString("RUT", Font_titulo_columna, Brushes.Black, margen_izquierdo + 110, margen_superior + 120)
            e.Graphics.DrawString("NOMBRE", Font_titulo_columna, Brushes.Black, margen_izquierdo + 190, margen_superior + 120)
            e.Graphics.DrawString("TOTAL GUIAS", Font_titulo_columna, Brushes.Black, margen_izquierdo + 470, margen_superior + 120, format1)
            e.Graphics.DrawString("DESCUENTO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 550, margen_superior + 120, format1)
            e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 620, margen_superior + 120, format1)
            e.Graphics.DrawString("FOLIO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 690, margen_superior + 120, format1)
            e.Graphics.DrawString("ENTREGADO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 720, margen_superior + 120)

            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 135, margen_izquierdo + 865, margen_superior + 135)

            Dim VarFactura As String
            Dim VarRut As String
            Dim VarNombre As String
            Dim VarGuias As String
            Dim VarDescuento As String
            Dim VarTotal As String
            Dim VarFolio As String

            Dim numero_lineas As Integer = 0
            Dim multiplicador_lineas As Integer = 10

            For i = numero_lineas_total To grilla_lista.Rows.Count - 1

                VarFactura = grilla_lista.Rows(i).Cells(0).Value.ToString
                VarRut = grilla_lista.Rows(i).Cells(1).Value.ToString
                VarNombre = grilla_lista.Rows(i).Cells(2).Value.ToString
                VarGuias = grilla_lista.Rows(i).Cells(3).Value.ToString
                VarDescuento = grilla_lista.Rows(i).Cells(4).Value.ToString
                VarTotal = grilla_lista.Rows(i).Cells(5).Value.ToString
                VarFolio = grilla_lista.Rows(i).Cells(6).Value.ToString

                If VarDescuento = "" Or VarDescuento = "0" Then
                    VarDescuento = "0"
                Else
                    VarDescuento = Format(Int(VarDescuento), "###,###,###")
                End If

                If VarTotal = "" Or VarTotal = "0" Then
                    VarTotal = "0"
                Else
                    VarTotal = Format(Int(VarTotal), "###,###,###")
                End If

                If VarNombre.Length > 35 Then
                    VarNombre = VarNombre.Substring(0, 35)
                End If

                e.Graphics.DrawString(VarFactura, Font_texto_impresion, Brushes.Black, margen_izquierdo + 50, margen_superior + 140 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(VarRut, Font_texto_impresion, Brushes.Black, margen_izquierdo + 110, margen_superior + 140 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(VarNombre, Font_texto_impresion, Brushes.Black, margen_izquierdo + 190, margen_superior + 140 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(VarGuias, Font_texto_impresion, Brushes.Black, margen_izquierdo + 470, margen_superior + 140 + (numero_lineas * multiplicador_lineas), format1)
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(VarDescuento, Font_texto_impresion, Brushes.Black, margen_izquierdo + 540, margen_superior + 140 + (numero_lineas * multiplicador_lineas), format1)
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(VarTotal, Font_texto_impresion, Brushes.Black, margen_izquierdo + 620, margen_superior + 140 + (numero_lineas * multiplicador_lineas), format1)
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(VarFolio, Font_texto_impresion, Brushes.Black, margen_izquierdo + 690, margen_superior + 140 + (numero_lineas * multiplicador_lineas), format1)
                '***************************************************************************************************************************************************

                e.Graphics.DrawString(".........................................", Font_texto_impresion, Brushes.Black, margen_izquierdo + 720, margen_superior + 140 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************

                numero_lineas = numero_lineas + 1
                numero_lineas_total = numero_lineas_total + 1

                If numero_lineas > 85 Then
                    'Linea horizontal
                    e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 145 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 145 + (numero_lineas * multiplicador_lineas))
                    '***************************************************************************************************************************************************
                    e.HasMorePages = True ' Todavia faltan mas paginas
                    Exit Sub
                Else
                    e.HasMorePages = False
                End If
            Next

            'Linea horizontal
            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 145 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 145 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            numero_lineas_total = 0
        End If
    End Sub
End Class