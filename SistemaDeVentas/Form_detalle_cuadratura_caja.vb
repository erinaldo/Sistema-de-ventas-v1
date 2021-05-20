Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Resources
Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.Math

Public Class Form_detalle_cuadratura_caja
    Dim mifecha2 As String
    Dim peso As String
    Dim monto_palabras As String
    Private WithEvents Pd As New PrintDocument
    Dim tipo_anticipo As String
    Dim impresora_anticipos As String
    'Dim impreso As Integer = 0

    Private Sub Form_ingresos_cuadratura_caja_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        If Form_caja_diaria.Visible = True Then
            Form_caja_diaria.WindowState = FormWindowState.Normal
            Form_caja_diaria.Enabled = True
        Else
            Form_menu_principal.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Form_ingresos_cuadratura_caja_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_ingresos_cuadratura_caja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtp_desde.CustomFormat = "yyy-MM-dd"
        dtp_hasta.CustomFormat = "yyy-MM-dd"
        dtp_desde.Text = FormatDateTime(Now, DateFormat.ShortDate)
        dtp_hasta.Text = FormatDateTime(Now, DateFormat.ShortDate)
        dtp_desde.Value = dtp_hasta.Value.AddDays(Val(-2))


        'revisar_egresos()
        cargar_detalle()
        Combo_movimiento.SelectedItem = "-"
        combo_tipo.SelectedItem = "-"
        grilla_detalle_cuadratura.Font = New System.Drawing.Font("Arial", 10.25!, System.Drawing.FontStyle.Regular)

        cargar_logo()
        'llenar_combo_listado()
        Dim column As DataGridViewColumn = grilla_detalle_cuadratura.Columns(0)
        column.Width = 350

        grilla_detalle_cuadratura.Columns(0).Width = 460
        grilla_detalle_cuadratura.Columns(1).Width = 101
        grilla_detalle_cuadratura.Columns(2).Width = 300
        grilla_detalle_cuadratura.Columns(3).Width = 102
        'grilla_detalle_cuadratura.Columns(4).Width = 250

        revisar_egresos()
        mostrar_impresora()
        'Combo_movimiento.DroppedDown = True

        Me.Width = 1024
        Me.Height = 503
        Centrar()
    End Sub

    Public Sub Centrar()
        Dim tamaño As Rectangle = My.Computer.Screen.Bounds
        Dim posicionX As Integer = (tamaño.Width - Me.Width) \ 2
        Dim posicionY As Integer = (tamaño.Height - Me.Height) \ 2
        Me.Location = New Point(posicionX, posicionY - 20)
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
            impresora_anticipos = DS.Tables(DT.TableName).Rows(0).Item("ticket_anticipos")
        End If
        conexion.Close()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub btn_agregar_entrada_remuneracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_entrada_remuneracion.Click
        If Combo_detalle.Text = "" Then
            MsgBox("CAMPO DETALLE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_detalle.Focus()
            Exit Sub
        End If

        If txt_monto.Text = "" Then
            MsgBox("CAMPO MONTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_monto.Focus()
            Exit Sub
        End If

        If combo_tipo.Text = "-" Then
            MsgBox("CAMPO MOVIMIENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_tipo.Focus()
            Exit Sub
        End If

        fecha()

        If mifecha2 <> Form_menu_principal.dtp_fecha.Text Then
            Form_autorizacion_caja.Show()
            Form_autorizacion_caja.lbl_autorizacion.Text = "PARA AGREGAR UN MOVIMIENTO CON OTRA FECHA, SOLICITE AUTORIZACION"
            Form_autorizacion_caja.dtp_fecha_caja_desde.Text = dtp_fecha_caja_desde.Text
            Me.Enabled = False
            Exit Sub
        End If

        txt_monto.Text = Trim(Replace(txt_monto.Text, "-", ""))
        txt_monto.Text = Trim(Replace(txt_monto.Text, "-", ""))
        txt_monto.Text = Trim(Replace(txt_monto.Text, "-", ""))
        txt_monto.Text = Trim(Replace(txt_monto.Text, "-", ""))


        monto_en_palabras()


        If Combo_movimiento.Text = "EGRESO" Then
            txt_monto.Text = "-" & txt_monto.Text
        End If

        If Combo_movimiento.Text = "EGRESO" Then
            If txt_monto.Text.Contains("-") Then
            Else
                txt_monto.Text = "-" & txt_monto.Text
            End If
        End If

        SC.Connection = conexion
        SC.CommandText = "insert into detalle_cuadratura_caja (detalle, monto, fecha, tipo, usuario_responsable, hora) values ('" & (Combo_detalle.Text) & "' , '" & (txt_monto.Text) & "', '" & (mifecha2) & "','" & (combo_tipo.Text) & "','" & (miusuario) & "','" & (Form_menu_principal.lbl_hora.Text) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)


        If combo_tipo.Text = "ANTICIPOS" Then

            crear_numero_anticipo()
            lbl_mensaje.Visible = True
            Me.Enabled = False
            With Pd.PrinterSettings
                tipo_anticipo = "ORIGINAL"
                .PrinterName = impresora_anticipos
                .Copies = 1
                .PrintRange = PrintRange.AllPages
                If .IsValid Then
                    Me.Pd.PrintController = New StandardPrintController
                    Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                    Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                    Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                    Pd.Print()
                Else
                    MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                    lbl_mensaje.Visible = False
                    Me.Enabled = True
                    Exit Sub
                End If
            End With
            With Pd.PrinterSettings
                tipo_anticipo = "COPIA"
                .PrinterName = impresora_anticipos
                .Copies = 1
                .PrintRange = PrintRange.AllPages
                If .IsValid Then
                    Me.Pd.PrintController = New StandardPrintController
                    Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                    Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                    Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                    Pd.Print()
                Else
                    MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                    lbl_mensaje.Visible = False
                    Me.Enabled = True
                    Exit Sub
                End If
            End With
            lbl_mensaje.Visible = False
            Me.Enabled = True
        End If

        revisar_egresos()
        cargar_detalle()
        If combo_tipo.Text = "ANTICIPOS" Then
            Combo_detalle.Text = "-"
        Else
            Combo_detalle.Text = ""
        End If
        txt_monto.Text = ""
        'combo_tipo.SelectedItem = "-"
        Combo_detalle.Focus()
    End Sub

    Sub crear_numero_anticipo()
        Dim varnumdoc As Integer
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(cod_auto) as cod_auto from detalle_cuadratura_caja"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                txt_nro_anticipo.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_nro_anticipo.Text = 1
            Exit Sub
        End Try
        conexion.Close()
    End Sub

    'Private Function ReturnDataSet() As DataSet
    '    Dim dt As New DataTable
    '    Dim dr As DataRow
    '    Dim ds As New DataSet

    '    dt.Columns.Add(New DataColumn("logo_empresa", GetType(Byte())))
    '    dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("fechas", GetType(String)))
    '    dt.Columns.Add(New DataColumn("titulo", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn0", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn1", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn2", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn3", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn4", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn5", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn6", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn7", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn8", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn9", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn10", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn11", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn12", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn13", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn14", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn15", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn16", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn17", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn18", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn19", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn20", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn21", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn22", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn23", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn24", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn25", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn26", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn27", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn28", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn29", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn30", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn31", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn32", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn33", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn34", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn35", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn36", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn37", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn38", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn39", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn40", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn41", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn42", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn43", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn44", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn45", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn46", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn47", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn48", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn49", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn50", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn51", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("DataColumn52", GetType(String)))


    '    Dim DataColumn1 As String = "0"
    '    Dim DataColumn2 As String = "0"
    '    Dim DataColumn3 As String = "0"
    '    Dim DataColumn4 As String = "0"
    '    Dim DataColumn5 As String = "0"
    '    'Dim DataColumn6 As String
    '    'Dim DataColumn7 As String
    '    'Dim DataColumn8 As String
    '    'Dim DataColumn9 As String
    '    'Dim DataColumn10 As String
    '    'Dim DataColumn11 As String
    '    'Dim DataColumn12 As String
    '    'Dim DataColumn13 As String
    '    'Dim DataColumn14 As String
    '    'Dim DataColumn15 As String
    '    'Dim DataColumn16 As String
    '    'Dim DataColumn17 As String
    '    'Dim DataColumn18 As String
    '    'Dim DataColumn19 As String
    '    'Dim DataColumn20 As String
    '    'Dim DataColumn21 As String
    '    'Dim DataColumn22 As String
    '    'Dim DataColumn23 As String
    '    'Dim DataColumn24 As String
    '    'Dim DataColumn25 As String
    '    'Dim DataColumn26 As String
    '    'Dim DataColumn27 As String
    '    'Dim DataColumn28 As String
    '    'Dim DataColumn29 As String
    '    'Dim DataColumn30 As String

    '    'For i = 0 To grilla_libro_compras.Rows.Count - 1
    '    '    DataColumn0 = grilla_libro_compras.Rows(i).Cells(0).Value.ToString
    '    '    DataColumn1 = grilla_libro_compras.Rows(i).Cells(1).Value.ToString
    '    '    DataColumn2 = grilla_libro_compras.Rows(i).Cells(2).Value.ToString
    '    '    DataColumn3 = grilla_libro_compras.Rows(i).Cells(3).Value.ToString
    '    '    DataColumn4 = grilla_libro_compras.Rows(i).Cells(4).Value.ToString
    '    '    DataColumn5 = grilla_libro_compras.Rows(i).Cells(5).Value.ToString
    '    '    DataColumn6 = grilla_libro_compras.Rows(i).Cells(6).Value.ToString
    '    '    DataColumn7 = grilla_libro_compras.Rows(i).Cells(7).Value.ToString
    '    '    DataColumn8 = grilla_libro_compras.Rows(i).Cells(8).Value.ToString
    '    '    DataColumn9 = grilla_libro_compras.Rows(i).Cells(9).Value.ToString
    '    '    DataColumn10 = grilla_libro_compras.Rows(i).Cells(10).Value.ToString
    '    '    DataColumn11 = grilla_libro_compras.Rows(i).Cells(11).Value.ToString
    '    '    DataColumn12 = grilla_libro_compras.Rows(i).Cells(12).Value.ToString
    '    '    DataColumn13 = grilla_libro_compras.Rows(i).Cells(13).Value.ToString

    '    dr = dt.NewRow()

    '    'Try
    '    '    dr("logo_empresa") = Imagen_reporte
    '    'Catch
    '    'End Try

    '    dr("nombre_empresa") = minombreempresa
    '    dr("giro_empresa") = migiroempresa
    '    dr("direccion_empresa") = midireccionempresa
    '    dr("comuna_empresa") = micomunaempresa
    '    dr("telefono_empresa") = mitelefonoempresa
    '    dr("correo_empresa") = micorreoempresa
    '    dr("rut_empresa") = mirutempresa

    '    Try
    '        dr("DataColumn1") = dtp_fecha_caja_desde.Text
    '    Catch
    '    End Try
    '    Try
    '        dr("DataColumn2") = Form_menu_principal.lbl_hora.Text
    '    Catch
    '    End Try
    '    Try
    '        dr("DataColumn3") = Combo_detalle.Text
    '    Catch
    '    End Try

    '    txt_monto.Text = Trim(Replace(txt_monto.Text, "-", ""))

    '    If txt_monto.Text = "" Or txt_monto.Text = "0" Then
    '        txt_monto.Text = "0"
    '    Else
    '        txt_monto.Text = Format(Int(txt_monto.Text), "###,###,###")
    '    End If

    '    Try
    '        dr("DataColumn4") = "$" & txt_monto.Text
    '    Catch
    '    End Try
    '    Try
    '        dr("DataColumn5") = monto_palabras
    '    Catch
    '    End Try
    '    Try
    '        dr("DataColumn6") = txt_nro_anticipo.Text
    '    Catch
    '    End Try
    '    'Try
    '    '    dr("DataColumn7") = DataColumn7
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn8") = DataColumn8
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn9") = DataColumn9
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn10") = DataColumn10
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn11") = DataColumn11
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn12") = DataColumn12
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn13") = DataColumn13
    '    'Catch
    '    'End Try





    '    'Try
    '    '    dr("DataColumn13") = grilla_estado_de_cuenta.Rows(0).Cells(1).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn14") = grilla_estado_de_cuenta.Rows(0).Cells(2).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn15") = grilla_estado_de_cuenta.Rows(0).Cells(3).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn16") = grilla_estado_de_cuenta.Rows(0).Cells(4).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn17") = grilla_estado_de_cuenta.Rows(1).Cells(1).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn18") = grilla_estado_de_cuenta.Rows(1).Cells(2).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn19") = grilla_estado_de_cuenta.Rows(1).Cells(3).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn20") = grilla_estado_de_cuenta.Rows(1).Cells(4).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn21") = grilla_estado_de_cuenta.Rows(2).Cells(1).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn22") = grilla_estado_de_cuenta.Rows(2).Cells(2).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn23") = grilla_estado_de_cuenta.Rows(2).Cells(3).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn24") = grilla_estado_de_cuenta.Rows(2).Cells(4).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn25") = grilla_estado_de_cuenta.Rows(3).Cells(1).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn26") = grilla_estado_de_cuenta.Rows(3).Cells(2).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn27") = grilla_estado_de_cuenta.Rows(3).Cells(3).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn28") = grilla_estado_de_cuenta.Rows(3).Cells(4).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn29") = grilla_estado_de_cuenta.Rows(4).Cells(1).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn30") = grilla_estado_de_cuenta.Rows(4).Cells(2).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn31") = grilla_estado_de_cuenta.Rows(4).Cells(3).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn32") = grilla_estado_de_cuenta.Rows(4).Cells(4).Value
    '    'Catch
    '    'End Try







    '    'Try
    '    '    dr("DataColumn33") = malla_clasificacion.Rows(0).Cells(1).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn34") = malla_clasificacion.Rows(0).Cells(2).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn35") = malla_clasificacion.Rows(0).Cells(3).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn36") = malla_clasificacion.Rows(0).Cells(4).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn37") = malla_clasificacion.Rows(1).Cells(1).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn38") = malla_clasificacion.Rows(1).Cells(2).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn39") = malla_clasificacion.Rows(1).Cells(3).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn40") = malla_clasificacion.Rows(1).Cells(4).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn41") = malla_clasificacion.Rows(2).Cells(1).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn42") = malla_clasificacion.Rows(2).Cells(2).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn43") = malla_clasificacion.Rows(2).Cells(3).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn44") = malla_clasificacion.Rows(2).Cells(4).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn45") = malla_clasificacion.Rows(3).Cells(1).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn46") = malla_clasificacion.Rows(3).Cells(2).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn47") = malla_clasificacion.Rows(3).Cells(3).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn48") = malla_clasificacion.Rows(3).Cells(4).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn49") = malla_clasificacion.Rows(4).Cells(1).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn50") = malla_clasificacion.Rows(4).Cells(2).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn51") = malla_clasificacion.Rows(4).Cells(3).Value
    '    'Catch
    '    'End Try
    '    'Try
    '    '    dr("DataColumn52") = malla_clasificacion.Rows(4).Cells(4).Value
    '    'Catch
    '    'End Try

    '    'dr("fechas") = "PERIODO TRIBUTARIO " & dtp1.Text
    '    'dr("titulo") = "LIBRO DE COMPRAS (" & mirecintoempresa & ")"

    '    dt.Rows.Add(dr)
    '    ' Next

    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "DS_reporte"

    '    Dim iDS As New DS_reporte
    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS
    'End Function

    Private Sub btn_quitar_entrada_remuneracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_entrada_remuneracion.Click

        If txt_cod_auto.Text = "" Then
            Combo_detalle.Focus()
            MsgBox("DEBE SELECCIONAR UN DOCUMENTO ANTES DE QUITARLO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If grilla_detalle_cuadratura.Rows.Count > 0 Then
            Dim valormensaje As Integer
            valormensaje = MsgBox("¿ESTA SEGURO DE ELIMINAR EL MOVIMIENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")

            If valormensaje = vbYes Then



                Form_autorizacion_caja.Show()
                Form_autorizacion_caja.lbl_autorizacion.Text = "PARA ELIMINAR UN MOVIMIENTO SOLICITE AUTORIZACION"
                Me.Enabled = False





                'Dim VarDetalle As String
                'Dim VarMonto As Integer
                'Dim VarTipo As String

                'VarDetalle = grilla_detalle_cuadratura.CurrentRow.Cells(0).Value
                'VarMonto = grilla_detalle_cuadratura.CurrentRow.Cells(1).Value
                'VarTipo = grilla_detalle_cuadratura.CurrentRow.Cells(3).Value

                'fecha()

                'SC.Connection = conexion
                'SC.CommandText = "delete from detalle_cuadratura_caja where cod_auto = '" & (txt_cod_auto.Text) & "'"
                'DA.SelectCommand = SC
                'DA.Fill(DT)

                'txt_cod_auto.Text = ""
                'txt_monto.Text = ""
                'txt_detalle.Text = ""
                'combo_tipo.Text = "-"

                'grilla_detalle_cuadratura.Rows.Remove(grilla_detalle_cuadratura.CurrentRow)
                'txt_detalle.Focus()











            End If
        End If
    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click

    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        If grilla_detalle_cuadratura.Rows.Count = 0 Then
            MsgBox("MALLA DE PRODUCTOS VACÍA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_detalle.Focus()
            Exit Sub
        End If

        fecha()
        grabar_detalle()

    End Sub


    Sub grabar_detalle()

        Dim VarDetalle As String
        Dim VarMonto As String
        Dim VarFecha As String
        Dim VarTipo As String
        Dim VarRevision As String

        For i = 0 To grilla_detalle_cuadratura.Rows.Count - 1

            VarDetalle = grilla_detalle_cuadratura.Rows(i).Cells(0).Value.ToString
            VarMonto = grilla_detalle_cuadratura.Rows(i).Cells(1).Value.ToString
            VarFecha = grilla_detalle_cuadratura.Rows(i).Cells(2).Value.ToString
            VarTipo = grilla_detalle_cuadratura.Rows(i).Cells(3).Value.ToString
            VarRevision = grilla_detalle_cuadratura.Rows(i).Cells(4).Value.ToString

            If VarRevision = "INGRESAR" Then
                SC.Connection = conexion
                SC.CommandText = "insert into detalle_cuadratura_caja (detalle, monto, fecha, TIPO, usuario_responsable, hora) values ('" & (VarDetalle) & "' , '" & (VarMonto) & "', '" & (mifecha2) & "','" & (VarTipo) & "','" & (miusuario) & "','" & (Form_menu_principal.lbl_hora.Text) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
        Next

        MsgBox("MOVIMIENTO GRABADO CON EXITO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        cargar_detalle()
        combo_tipo.SelectedItem = "-"
        Combo_detalle.Focus()

    End Sub


    Sub cargar_detalle()

        grilla_detalle_cuadratura.Rows.Clear()
        fecha()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion

        SC.CommandText = "select * from detalle_cuadratura_caja where fecha='" & (mifecha2) & "' order by TIPO asc"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        Dim fecha_cuadratura As String


        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                fecha_cuadratura = DS.Tables(DT.TableName).Rows(i).Item("fecha")

                If fecha_cuadratura.Length > 10 Then
                    fecha_cuadratura = fecha_cuadratura.Substring(0, 10)
                End If

                grilla_detalle_cuadratura.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("detalle"),
                                                     DS.Tables(DT.TableName).Rows(i).Item("monto"),
                                                      DS.Tables(DT.TableName).Rows(i).Item("tipo"),
                                                       fecha_cuadratura,
                                                        "INGRESADO",
                                                         DS.Tables(DT.TableName).Rows(i).Item("cod_auto"))
            Next
        End If

        If grilla_detalle_cuadratura.Rows.Count <> 0 Then

            If grilla_detalle_cuadratura.Columns(0).Width = 460 Then
                grilla_detalle_cuadratura.Columns(0).Width = 459
            Else
                grilla_detalle_cuadratura.Columns(0).Width = 460
            End If
        End If
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_fecha_caja_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")
    End Sub



    Private Sub combo_listado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If
    End Sub



    Private Sub txt_detalle_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub Combo_detalle_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_detalle.GotFocus
        Combo_detalle.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_detalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_detalle.KeyPress
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
            txt_monto.Focus()
        End If
    End Sub

    Private Sub Combo_detalle_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_detalle.LostFocus
        'If Combo_detalle.DropDownStyle = ComboBoxStyle.Simple Then
        Combo_detalle.BackColor = Color.White
        ' End If
    End Sub

    Private Sub txt_monto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_monto.GotFocus
        txt_monto.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_monto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_monto.LostFocus
        txt_monto.BackColor = Color.White
    End Sub

    Private Sub combo_venta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_tipo.GotFocus
        combo_tipo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_venta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_tipo.LostFocus
        combo_tipo.BackColor = Color.White
    End Sub


    Private Sub btn_agregar_entrada_remuneracion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar_entrada_remuneracion.GotFocus
        btn_agregar_entrada_remuneracion.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_agregar_entrada_remuneracion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar_entrada_remuneracion.LostFocus
        btn_agregar_entrada_remuneracion.BackColor = Color.Transparent
    End Sub


    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_quitar_entrada_remuneracion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_entrada_remuneracion.GotFocus
        btn_quitar_entrada_remuneracion.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_entrada_remuneracion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_entrada_remuneracion.LostFocus
        btn_quitar_entrada_remuneracion.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_guardar.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_guardar.BackColor = Color.WhiteSmoke
    'End Sub

    Private Sub txt_detalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub txt_detalle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_monto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_monto.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btn_agregar_entrada_remuneracion.Focus()
        End If
    End Sub

    Private Sub txt_monto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_monto.TextChanged

    End Sub


    Private Sub combo_listado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub grilla_asignacion_familiar_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_detalle_cuadratura.CellContentClick

    End Sub

    Private Sub grilla_asignacion_familiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_detalle_cuadratura.Click
        If grilla_detalle_cuadratura.Rows.Count = 0 Then
            Exit Sub
        End If
        If grilla_detalle_cuadratura.CurrentRow.Cells(0).Value() = "*" Then
            Exit Sub
        End If
        Combo_detalle.Text = grilla_detalle_cuadratura.CurrentRow.Cells(0).Value()
        txt_monto.Text = grilla_detalle_cuadratura.CurrentRow.Cells(1).Value()
        combo_tipo.Text = grilla_detalle_cuadratura.CurrentRow.Cells(2).Value.ToString
        txt_cod_auto.Text = grilla_detalle_cuadratura.CurrentRow.Cells(5).Value.ToString
        txt_monto.Text = Trim(Replace(txt_monto.Text, "-", ""))
        ' txt_codigo.Text = grilla_detalle_cuadratura.CurrentRow.Cells(0).Value()
    End Sub

    Private Sub dtp_fecha_caja_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha_caja_desde.ValueChanged
        grilla_detalle_cuadratura.Rows.Clear()
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click

        Form_autorizacion_caja.Show()
        Form_autorizacion_caja.lbl_autorizacion.Text = "PARA CAMBIAR LA FECHA SOLICITE AUTORIZACION"
        Me.Enabled = False
    End Sub

    Private Sub txt_detalle_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Sub revisar_egresos()
        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'SC.Connection = conexion
        'SC.CommandText = "SELECT * FROM detalle_cuadratura_caja where TIPO like '%ANTICIPO%' OR TIPO like '%EGRESO%' OR TIPO like '%SUELDO%' and fecha ='" & (form_Menu_admin.dtp_fecha.Text) & "';"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)
        'If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
        '        grilla_revision.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
        '                                            DS.Tables(DT.TableName).Rows(i).Item("monto"), _
        '                                             DS.Tables(DT.TableName).Rows(i).Item("cod_auto"))
        '    Next
        'End If

        'Dim VarTipo As String
        'Dim VarMonto As String
        'Dim VarCodAuto As String

        'For i = 0 To grilla_revision.Rows.Count - 1
        '    VarTipo = grilla_revision.Rows(i).Cells(0).Value.ToString
        '    VarMonto = grilla_revision.Rows(i).Cells(1).Value.ToString
        '    VarCodAuto = grilla_revision.Rows(i).Cells(2).Value.ToString

        '    If VarTipo.Contains("ANTICIPO") Then
        '        If VarMonto.Contains("-") Then
        '        Else
        '            VarMonto = "-" & VarMonto
        '        End If
        '    End If
        '    If VarTipo.Contains("EGRESO") Then
        '        If VarMonto.Contains("-") Then
        '        Else
        '            VarMonto = "-" & VarMonto
        '        End If
        '    End If

        '    If VarTipo.Contains("SUELDO") Then
        '        If VarMonto.Contains("-") Then
        '        Else
        '            VarMonto = "-" & VarMonto
        '        End If
        '    End If

        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE detalle_cuadratura_caja SET monto='" & (VarMonto) & "' WHERE cod_auto='" & (VarCodAuto) & "';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Next
    End Sub

    Sub llenar_combo_trabajador()
        Combo_detalle.Items.Clear()
        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()

        SC2.Connection = conexion
        SC2.CommandText = "select nombre_usuario from  usuarios where activo <> 'NO' and rut_usuario <> '" & (mirutempresa) & "' and rut_usuario <> 'SISTEMA' ORDER BY nombre_usuario"

        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)

        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                Combo_detalle.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("nombre_usuario"))
            Next
            conexion.Close()
        End If

        'If mirutempresa = "81921000-4" Then
        '    Combo_detalle.Items.Add("SUELDO SIN IMPUTAR")
        'End If
    End Sub

    Private Sub Combo_detalle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_detalle.SelectedIndexChanged

    End Sub

    Private Sub combo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_tipo.SelectedIndexChanged
        'If mirutempresa = "87686300-6" Then
        '    If combo_tipo.Text = "ANTICIPOS" Then
        '        llenar_combo_trabajador()
        '        Combo_detalle.DropDownStyle = ComboBoxStyle.DropDownList
        '        Combo_detalle.DroppedDown = True
        '    Else
        '        Combo_detalle.Items.Clear()
        '        Combo_detalle.DropDownStyle = ComboBoxStyle.Simple
        '        Combo_detalle.MaxLength = 65
        '    End If
        'End If
        Combo_detalle.Enabled = True
        'If mirutempresa = "87686300-6" Then
        If combo_tipo.Text = "ANTICIPOS" Then
            llenar_combo_trabajador()
            Combo_detalle.DropDownStyle = ComboBoxStyle.DropDownList
            Combo_detalle.DroppedDown = True
            Exit Sub
        End If

        If combo_tipo.Text = "ANTICIPO" Then
            llenar_combo_trabajador()
            Combo_detalle.DropDownStyle = ComboBoxStyle.DropDownList
            Combo_detalle.DroppedDown = True
            Exit Sub
        End If


        If combo_tipo.Text = "SUELDOS" Then
            llenar_combo_trabajador()
            Combo_detalle.DropDownStyle = ComboBoxStyle.DropDownList
            Combo_detalle.DroppedDown = True
            Exit Sub
        End If

        If combo_tipo.Text = "SUELDO" Then
            llenar_combo_trabajador()
            Combo_detalle.DropDownStyle = ComboBoxStyle.DropDownList
            Combo_detalle.DroppedDown = True
            Exit Sub
        End If

        If combo_tipo.Text = "AGUINALDO" Then
            llenar_combo_trabajador()
            Combo_detalle.DropDownStyle = ComboBoxStyle.DropDownList
            Combo_detalle.DroppedDown = True
            Exit Sub
        End If

        If combo_tipo.Text = "SUELDO SIN IMPUTAR" Then
            Combo_detalle.DropDownStyle = ComboBoxStyle.Simple
            Combo_detalle.Text = " "
            Combo_detalle.Enabled = False
            txt_monto.Focus()
            Exit Sub
        End If

        Combo_detalle.Enabled = True
        Combo_detalle.Items.Clear()
        Combo_detalle.DropDownStyle = ComboBoxStyle.Simple
        Combo_detalle.MaxLength = 65

        Combo_detalle.Focus()
    End Sub

    Sub mostrar_tope_usuario()
        ' '' '' '' ''txt_tope_anticipo.Text = "0"
        ' '' '' '' ''If Combo_detalle.Text <> "" Then
        ' '' '' '' ''    conexion.Close()
        ' '' '' '' ''    DS.Tables.Clear()
        ' '' '' '' ''    DT.Rows.Clear()
        ' '' '' '' ''    DT.Columns.Clear()
        ' '' '' '' ''    DS.Clear()
        ' '' '' '' ''    conexion.Open()
        ' '' '' '' ''    SC.Connection = conexion
        ' '' '' '' ''    SC.CommandText = "select * from usuarios where nombre_usuario ='" & (Combo_detalle.Text) & "'"
        ' '' '' '' ''    DA.SelectCommand = SC
        ' '' '' '' ''    DA.Fill(DT)
        ' '' '' '' ''    DS.Tables.Add(DT)
        ' '' '' '' ''    If DS.Tables(DT.TableName).Rows.Count > 0 Then
        ' '' '' '' ''        txt_tope_anticipo.Text = DS.Tables(DT.TableName).Rows(0).Item("tope_anticipos")
        ' '' '' '' ''    End If
        ' '' '' '' ''    conexion.Close()
        ' '' '' '' ''End If



        'conexion.Close()
        'conexion.ConnectionString = "server=orchacabuco.dyndns.org; Database=remuneraciones; User Id=sistema_general;Password=1234; Convert Zero Datetime=True; default command timeout=3600"

        'txt_tope_anticipo.Text = ""

        'Dim numero_mes As Integer
        'Dim numero_mes_final As String
        'numero_mes = form_Menu_admin.dtp_fecha.Value.Month
        'numero_mes_final = String.Format("{0:00}", numero_mes)

        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "SELECT * FROM remuneraciones.liquidaciones_de_sueldo where rut_trabajador='" & (txt_rut_usuario.Text) & "' and fecha_liquidacion='" & (numero_mes_final & "-" & form_Menu_admin.dtp_fecha.Value.Year) & "';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    DS.Tables.Add(DT)
        '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '        txt_tope_anticipo.Text = DS.Tables(DT.TableName).Rows(0).Item("totales_saldo_liquido")
        '        txt_tope_anticipo.Text = Int(Val(txt_tope_anticipo.Text) / 2)
        '    End If
        'Catch err As InvalidCastException
        '    txt_tope_anticipo.Text = ""
        '    'Exit Sub
        'End Try
        'conexion.Close()

        'If txt_tope_anticipo.Text = "" Then

        '    numero_mes = form_Menu_admin.dtp_fecha.Value.Month - 1
        '    numero_mes_final = String.Format("{0:00}", numero_mes)

        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "SELECT * FROM remuneraciones.liquidaciones_de_sueldo where rut_trabajador='" & (txt_rut_usuario.Text) & "' and fecha_liquidacion='" & ((numero_mes_final) & "-" & form_Menu_admin.dtp_fecha.Value.Year) & "';"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_tope_anticipo.Text = DS.Tables(DT.TableName).Rows(0).Item("totales_saldo_liquido")
        '            txt_tope_anticipo.Text = Int(Val(txt_tope_anticipo.Text) / 2)
        '        End If
        '    Catch err As InvalidCastException
        '        txt_tope_anticipo.Text = ""
        '        'Exit Sub
        '    End Try
        '    conexion.Close()
        'End If

        'recuperar_conexion()

    End Sub

    Sub mostrar_rut_usuario()
        txt_rut_usuario.Text = ""
        If Combo_detalle.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from usuarios where nombre_usuario ='" & (Combo_detalle.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut_usuario.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
            End If
            conexion.Close()
        End If
    End Sub

    Sub mostrar_suma_anticipos()
        'txt_suma_anticipos.Text = "0"
        'If Combo_detalle.Text <> "" Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "SELECT sum(monto) as total FROM detalle_cuadratura_caja where TIPO like '%ANTICIPO%' AND MONTH(FECHA)='" & (dtp_fecha_caja_desde.Value.Month) & "'AND detalle='" & (Combo_detalle.Text) & "';"
        '        'SC.CommandText = "select * from usuarios where nombre_usuario ='" & (Combo_detalle.Text) & "'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_suma_anticipos.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_suma_anticipos.Text = "0"
        '    End Try
        '    conexion.Close()

        '    txt_suma_anticipos.Text = Trim(Replace(txt_suma_anticipos.Text, "-", ""))

        'End If
    End Sub

    Public Function Num2Text(ByVal value As Double) As String
        Select Case value
            Case 0 : Num2Text = "CERO"
            Case 1 : Num2Text = "UN"
            Case 2 : Num2Text = "DOS"
            Case 3 : Num2Text = "TRES"
            Case 4 : Num2Text = "CUATRO"
            Case 5 : Num2Text = "CINCO"
            Case 6 : Num2Text = "SEIS"
            Case 7 : Num2Text = "SIETE"
            Case 8 : Num2Text = "OCHO"
            Case 9 : Num2Text = "NUEVE"
            Case 10 : Num2Text = "DIEZ"
            Case 11 : Num2Text = "ONCE"
            Case 12 : Num2Text = "DOCE"
            Case 13 : Num2Text = "TRECE"
            Case 14 : Num2Text = "CATORCE"
            Case 15 : Num2Text = "QUINCE"
            Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20 : Num2Text = "VEINTE"
            Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30 : Num2Text = "TREINTA"
            Case 40 : Num2Text = "CUARENTA"
            Case 50 : Num2Text = "CINCUENTA"
            Case 60 : Num2Text = "SESENTA"
            Case 70 : Num2Text = "SETENTA"
            Case 80 : Num2Text = "OCHENTA"
            Case 90 : Num2Text = "NOVENTA"
            Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100 : Num2Text = "CIEN"
            Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select
    End Function



    Sub monto_en_palabras()
        peso = " PESOS"
        If CInt(txt_monto.Text) = 1000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & " DE PESOS"
        ElseIf CInt(txt_monto.Text) = 2000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 3000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 4000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 5000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 6000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 7000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 8000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 9000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 10000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 11000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 12000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 13000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 14000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 15000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 16000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 17000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 18000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 19000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 20000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 21000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 22000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 23000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 24000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 25000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 26000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 27000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 28000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 29000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        ElseIf CInt(txt_monto.Text) = 30000000 Then
            monto_palabras = Num2Text(txt_monto.Text) & "DE PESOS"
        Else
            monto_palabras = Num2Text(txt_monto.Text) & peso
        End If
    End Sub

    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
        'If txt_direccion.Text.Length > 23 Then
        '    txt_direccion.Text = txt_direccion.Text.Substring(0, 30)
        'End If

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

        Dim stringFormat_left As New StringFormat()
        stringFormat_left.Alignment = StringAlignment.Near
        stringFormat_left.LineAlignment = StringAlignment.Near

        Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 90, margen_izquierdo + 250, margen_superior + 15)
        Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 105, margen_izquierdo + 250, margen_superior + 15)
        Dim rect3 As New Rectangle(margen_izquierdo + 10, margen_superior + 120, margen_izquierdo + 250, margen_superior + 15)
        Dim rect4 As New Rectangle(margen_izquierdo + 10, margen_superior + 135, margen_izquierdo + 250, margen_superior + 15)
        Dim rect5 As New Rectangle(margen_izquierdo + 10, margen_superior + 150, margen_izquierdo + 250, margen_superior + 15)
        Dim rect6 As New Rectangle(margen_izquierdo + 10, margen_superior + 165, margen_izquierdo + 250, margen_superior + 15)
        Dim rect7 As New Rectangle(margen_izquierdo + 10, margen_superior + 180, margen_izquierdo + 250, margen_superior + 15)
        Dim rect_titulo As New Rectangle(margen_izquierdo + 10, margen_superior + 215, margen_izquierdo + 270, margen_superior + 15)

        e.Graphics.DrawString(minombreempresa, Font_texto_empresa, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(migiroempresa, Font_texto_empresa, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font_texto_empresa, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font_texto_empresa, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font_texto_empresa, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font_texto_empresa, Brushes.Black, rect6, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font_texto_empresa, Brushes.Black, rect7, stringFormat)

        e.Graphics.DrawString("ANTICIPO DE SUELDO", Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)

        e.Graphics.DrawString("NUMERO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 245)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 245)
        e.Graphics.DrawString(txt_nro_anticipo.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 245)

        e.Graphics.DrawString("FECHA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 260)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 260)
        e.Graphics.DrawString(dtp_fecha_caja_desde.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 260)

        e.Graphics.DrawString("HORA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 275)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 275)
        e.Graphics.DrawString(Form_menu_principal.lbl_hora.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 275)

        e.Graphics.DrawString("TRABAJADOR", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 290)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 290)
        e.Graphics.DrawString(Combo_detalle.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 290)

        Dim monto As Integer = txt_monto.Text
        monto = Math.Abs(monto)
        Dim monto_final As String = monto

        If monto_final = "" Or monto_final = "0" Then
            monto_final = "0"
        Else
            monto_final = Format(Int(monto_final), "###,###,###")
        End If

        e.Graphics.DrawString("MONTO", Font_texto_titulo, Brushes.Black, margen_izquierdo + 0, margen_superior + 305)
        e.Graphics.DrawString(":", Font_texto_titulo, Brushes.Black, margen_izquierdo + 75, margen_superior + 305)
        e.Graphics.DrawString("$" & monto_final, Font_texto_titulo, Brushes.Black, margen_izquierdo + 85, margen_superior + 305)

        e.Graphics.DrawString("GLOSA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 320)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 320)
        'e.Graphics.DrawString(monto_palabras, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 320)

        Dim rect_monto_palabras As New Rectangle(margen_izquierdo + 85, margen_superior + 320, margen_izquierdo + 200, margen_superior + 60)
        'e.Graphics.DrawString("FIRMA TRABAJADOR", Font_texto_titulo_detalle, Brushes.Black, rect_firma, stringFormat)
        e.Graphics.DrawString(monto_palabras, Font_texto_titulo_detalle, Brushes.Black, rect_monto_palabras, stringFormat_left)

        If tipo_anticipo = "ORIGINAL" Then
            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + 450, margen_izquierdo + 270, margen_superior + 450)
            Dim rect_firma As New Rectangle(margen_izquierdo + 10, margen_superior + 460, margen_izquierdo + 270, margen_superior + 15)
            e.Graphics.DrawString("FIRMA TRABAJADOR", Font_texto_titulo_detalle, Brushes.Black, rect_firma, stringFormat)
        End If
        If tipo_anticipo = "COPIA" Then
            Dim rect_firma As New Rectangle(margen_izquierdo + 10, margen_superior + 350, margen_izquierdo + 270, margen_superior + 15)
            e.Graphics.DrawString("COPIA TRABAJADOR", Font_texto_titulo_detalle, Brushes.Black, rect_firma, stringFormat)
        End If
        Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + 400, margen_izquierdo + 270, margen_superior + 15)
        e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)
    End Sub

    Private Sub Combo_movimiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_movimiento.SelectedIndexChanged
        If Combo_movimiento.Text = "INGRESO" Then
            combo_tipo.Items.Clear()
            combo_tipo.Items.Add("CHEQUE PAGADO POR CAJA")
            combo_tipo.Items.Add("ANULACIÓN TARJETA CRÉDITO")
            combo_tipo.Items.Add("OTROS INGRESOS")
            combo_tipo.Items.Add("-")
            combo_tipo.Text = "-"
        End If
        If Combo_movimiento.Text = "EGRESO" Then
            combo_tipo.Items.Clear()
            combo_tipo.Items.Add("FACTURA")
            combo_tipo.Items.Add("BOLETA")
            combo_tipo.Items.Add("RETIRO")
            combo_tipo.Items.Add("BOLETA HONORARIOS")
            combo_tipo.Items.Add("OTROS EGRESOS")
            combo_tipo.Items.Add("ANTICIPOS")
            combo_tipo.Items.Add("-")
            combo_tipo.Text = "-"
        End If
        If Combo_movimiento.Text = "-" Then
            combo_tipo.Items.Clear()
            combo_tipo.Items.Add("-")
            combo_tipo.Text = "-"
        End If
        combo_tipo.Focus()

    End Sub

    Private Sub combo_tipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles combo_tipo.KeyPress

    End Sub

    Private Sub grilla_detalle_cuadratura_DoubleClick(sender As Object, e As EventArgs) Handles grilla_detalle_cuadratura.DoubleClick
        If grilla_detalle_cuadratura.Rows.Count = 0 Then
            Exit Sub
        End If



        Dim VarDetalle As String
        Dim VarMonto As Integer
        Dim VarTipo As String
        Dim Varfecha As String
        Dim VarCodigo As String

        VarDetalle = grilla_detalle_cuadratura.CurrentRow.Cells(0).Value
        VarMonto = grilla_detalle_cuadratura.CurrentRow.Cells(1).Value
        VarMonto = VarMonto * -1
        VarTipo = grilla_detalle_cuadratura.CurrentRow.Cells(2).Value
        Varfecha = grilla_detalle_cuadratura.CurrentRow.Cells(3).Value
        VarCodigo = grilla_detalle_cuadratura.CurrentRow.Cells(5).Value

        If VarTipo = "ANTICIPOS" Then

            Dim valormensaje As Integer
            valormensaje = MsgBox("¿ESTA SEGURO DE IMPRIMIR EL ANTICIPO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")

            If valormensaje = vbYes Then






                If Varfecha.Length > 10 Then
                    Varfecha = Varfecha.Substring(0, 10)
                End If





                crear_numero_anticipo()
                lbl_mensaje.Visible = True
                Me.Enabled = False
                With Pd.PrinterSettings
                    tipo_anticipo = "ORIGINAL"
                    .PrinterName = impresora_anticipos
                    .Copies = 1
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then
                        Me.Pd.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
                With Pd.PrinterSettings
                    tipo_anticipo = "COPIA"
                    .PrinterName = impresora_anticipos
                    .Copies = 1
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then
                        Me.Pd.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
                lbl_mensaje.Visible = False
                Me.Enabled = True
            End If


        End If
    End Sub
End Class