Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Resources
Imports MySql.Data.MySqlClient
Imports System.Math

Public Class Form_resumen_caja_diaria
    Dim mifecha2 As String
    Dim mifecha4 As String

    Dim nombre_sucursal As String

    Private Sub Form_resumen_caja_diaria_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_resumen_caja_diaria_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_resumen_caja_diaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_condiciones()
        llenar_combo_cajas()
        combo_venta.Text = "-"
        Me.Width = 1024
        Me.Height = 728
        Centrar()
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

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub

    Sub malla_caja()
        'dtp_ingresar.Text = dtp_desde.Text

        'While (dtp_ingresar.Value < dtp_hasta.Value)

        'End While
        Dim consulta As String = ""

        consulta = "select * from detalle_condicion_de_pago where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'"

        If Combo_caja.Text <> "-" Then
            consulta = consulta & " and caja='" & (Combo_caja.Text) & "'"
        End If

        If combo_venta.Text <> "-" Then
            consulta = consulta & " and tipo_doc='" & (combo_venta.Text) & "'"
        End If

        If combo_condiciones.Text <> "-" Then
            consulta = consulta & " and condicion_de_pago='" & (combo_condiciones.Text) & "'"
        End If

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
        grilla_inventario.Rows.Clear()
        grilla_inventario.Columns.Clear()
        grilla_inventario.Columns.Add("", "DOCUMENTO")
        grilla_inventario.Columns.Add("", "NUMERO")
        grilla_inventario.Columns.Add("", "TOTAL")
        grilla_inventario.Columns.Add("", "CONDICION DE PAGO")
        grilla_inventario.Columns.Add("", "ESTADO")
        grilla_inventario.Columns.Add("", "FECHA")
        grilla_inventario.Columns.Add("", "CAJA")

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim MiFechaPago As Date
                Dim MiFechaPago2 As String
                MiFechaPago = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                MiFechaPago2 = MiFechaPago.ToString("dd-MM-yyy")

                grilla_inventario.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("tipo_doc"),
                                               DS.Tables(DT.TableName).Rows(i).Item("nro_doc"),
                                                DS.Tables(DT.TableName).Rows(i).Item("valor"),
                                                  DS.Tables(DT.TableName).Rows(i).Item("condicion_de_pago"),
                                                   DS.Tables(DT.TableName).Rows(i).Item("estado"),
                                                    MiFechaPago2,
                                                     DS.Tables(DT.TableName).Rows(i).Item("caja"))
            Next
        End If

        If grilla_inventario.Rows.Count <> 0 Then
            If grilla_inventario.Columns(0).Width = 150 Then
                grilla_inventario.Columns(0).Width = 149
            Else
                grilla_inventario.Columns(0).Width = 150
            End If
            grilla_inventario.Columns(1).Width = 100
            grilla_inventario.Columns(2).Width = 100
            grilla_inventario.Columns(3).Width = 200
            grilla_inventario.Columns(4).Width = 100
            grilla_inventario.Columns(5).Width = 100
            grilla_inventario.Columns(6).Width = 150

            grilla_inventario.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_inventario.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_inventario.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_inventario.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_inventario.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_inventario.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_inventario.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If
    End Sub

    Sub llenar_combo_condiciones()
        combo_condiciones.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion
        SC3.CommandText = "select * from formas_de_pago group by forma_de_pago order by forma_de_pago"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                combo_condiciones.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("forma_de_pago"))
            Next
            combo_condiciones.Items.Add("OTRO MEDIO DE PAGO")
        End If
        conexion.Close()

        combo_condiciones.Items.Add("-")
        combo_condiciones.SelectedItem = "-"
    End Sub

    Sub llenar_combo_cajas()
        Combo_caja.Items.Clear()
        Combo_caja.Items.Add("TODAS")
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion
        SC3.CommandText = "select * from equipos_de_cajas where nombre_caja <> 'TODAS' order by nombre_caja"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_caja.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_caja"))
            Next
        End If
        conexion.Close()
        Combo_caja.Items.Add("-")
        Combo_caja.SelectedItem = "-"
    End Sub

    Sub ingresar_fechas()

        grilla_inventario.Rows.Clear()

        Dim contador As Integer
        contador = "1"

        dtp_ingresar.Text = dtp_desde.Text

        '   grilla_documento.Rows.Add(dtp_desde.Text)

        ' dtp_ingresar.Value = dtp_ingresar.Value.AddDays(Val(+1))

        While (dtp_ingresar.Value < dtp_hasta.Value)

            grilla_inventario.Rows.Add(dtp_ingresar.Text)
            dtp_ingresar.Value = dtp_ingresar.Value.AddDays(Val(+1))

        End While

    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        fecha()
        malla_caja()
        calcular_totales()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub


    Sub calcular_totales()
        Dim totalgrilla As Long

        '//Calcular el total 
        txt_total.Text = 0
        For i = 0 To grilla_inventario.Rows.Count - 1
            totalgrilla = Val(grilla_inventario.Rows(i).Cells(2).Value.ToString)
            txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        Next

        Dim iva_valor As String

        iva_valor = valor_iva / 100 + 1
        txt_neto.Text = Round(txt_total.Text / iva_valor)
        txt_iva.Text = (((txt_neto.Text) * valor_iva) / 100)
        txt_iva.Text = (txt_total.Text) - (txt_neto.Text)

        If txt_neto.Text = "" Or txt_neto.Text = "0" Then
            txt_neto.Text = "0"
        Else
            txt_neto.Text = Format(Int(txt_neto.Text), "###,###,###")
        End If

        If txt_iva.Text = "" Or txt_iva.Text = "0" Then
            txt_iva.Text = "0"
        Else
            txt_iva.Text = Format(Int(txt_iva.Text), "###,###,###")
        End If

        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total.Text = "0"
        Else
            txt_total.Text = Format(Int(txt_total.Text), "###,###,###")
        End If
    End Sub


    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click

        If grilla_inventario.Rows.Count = 0 Then
            btn_mostrar.Focus()
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        exportar_excel()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub




    Private Function exportar_excel() As Boolean
        Dim ruta_archivo As String
        Dim hora_sistema As String
        Dim fecha_sistema As String
        Dim fecha_desde As String
        Dim fecha_hasta As String

        hora_sistema = Form_menu_principal.lbl_hora.Text
        hora_sistema = hora_sistema.Replace(":", " ")

        fecha_sistema = Format(Today.Date, "Long Date")

        fecha_desde = Format(Today.Date, "Short Date")
        fecha_hasta = Format(Today.Date, "Short Date")
        'fecha_desde = fecha_sistema.Replace("-", " ")
        'fecha_hasta = fecha_sistema.Replace("-", " ")

        fecha_sistema = fecha_sistema.Replace(",", " ")

        ruta_archivo = My.Computer.FileSystem.SpecialDirectories.Desktop & "\RESUMEN CAJA DIARIA DESD E" & fecha_desde & " HASTA " & fecha_hasta & " " & hora_sistema & ".csv"





        'Dim cadenaubicacion As String
        'Dim directorio As New FolderBrowserDialog
        'If directorio.ShowDialog = DialogResult.OK Then
        '    cadenaubicacion = directorio.SelectedPath
        Try
            Dim stream As Stream
            Dim escritor As StreamWriter
            Dim fila = grilla_inventario.Rows.Count
            Dim columnas = grilla_inventario.Columns.Count
            Dim archivo As String = ruta_archivo
            Dim linea As String = ""
            Dim filadata, column As Int32

            File.Delete(archivo)
            stream = File.OpenWrite(archivo)
            escritor = New StreamWriter(stream, System.Text.Encoding.UTF8)

            For column = 0 To columnas - 1
                linea = linea & grilla_inventario.Columns(column).HeaderText & ";"
            Next
            linea = Mid(CStr(linea), 1, linea.ToString.Length - 1)
            escritor.WriteLine(linea)
            linea = Nothing
            For filadata = 0 To fila - 1
                For column = 0 To columnas - 1
                    linea = linea & CStr(grilla_inventario.Item(column, filadata).Value) & ";"
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

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        grilla_inventario.Columns.Clear()
        calcular_totales()
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        grilla_inventario.Columns.Clear()
        calcular_totales()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        grilla_inventario.Columns.Clear()
        calcular_totales()
        dtp_desde.Text = Date.Now
        dtp_hasta.Text = Date.Now
        combo_venta.Text = "-"
        Combo_caja.Text = "-"
        combo_condiciones.Text = "-"
    End Sub

    Private Sub combo_sucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grilla_inventario.Columns.Clear()
    End Sub

    Private Sub combo_venta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_venta.SelectedIndexChanged
        grilla_inventario.Columns.Clear()
        calcular_totales()
    End Sub

    Private Sub combo_condiciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_condiciones.SelectedIndexChanged
        grilla_inventario.Columns.Clear()
        calcular_totales()
    End Sub

    Private Sub Combo_caja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_caja.SelectedIndexChanged
        grilla_inventario.Columns.Clear()
        calcular_totales()
    End Sub
End Class