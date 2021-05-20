Imports MySql.Data.MySqlClient
Imports System.Resources

Public Class Form_sueldos_por_caja
    Dim nombre_mes As String
    Dim nro_mes As String
    Dim nro_año As String
    Dim mifecha2 As String
    Dim mifecha4 As String

    Private Sub Form_sueldos_por_caja_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_sueldos_por_caja_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_sueldos_por_caja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim d As DateTime = Now()
        'nombre_mes = d.ToString("MMMM") ' Te trae el nombre del mes que tenga d 
        'nro_mes = d.ToString("MM") ' Te trae el numero del mes con doble 0
        'Combo_año.Text = form_Menu_admin.dtp_fecha.Value.Year()
        'Combo_mes.Text = nombre_mes
        cargar_logo()
        grilla_libro_compras.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)
        txt_sueldos.Text = ""
        txt_anticipos.Text = ""
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub



    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        fecha()
        mostrar_malla()
        'mostrar_sueldos()

        'calcular_totales()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        If grilla_libro_compras.Rows.Count = 0 Then
            dtp_desde.Focus()
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_libro_compras, save.FileName)
        End If

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub



    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)

        Dim xlApp As Object = CreateObject("Excel.Application")
        'crear una nueva hoja de calculo 
        Dim xlWB As Object = xlApp.WorkBooks.add
        Dim xlWS As Object = xlWB.WorkSheets(1)

        'exportamos los caracteres de las columnas 
        For c As Integer = 0 To grilla_libro_compras.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_libro_compras.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_libro_compras.RowCount - 1
            For c As Integer = 0 To grilla_libro_compras.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_libro_compras.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            grilla_libro_compras.Rows.Clear()
            grilla_libro_compras.Columns.Clear()
            txt_anticipos.Text = ""
            txt_sueldos.Text = ""
        End If

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub


    Sub calcular_totales()

        Dim totalanticipos As Long
        Dim totalsueldos As Long

        txt_anticipos.Text = 0
        For i = 0 To grilla_libro_compras.Rows.Count - 1
            totalanticipos = Val(grilla_libro_compras.Rows(i).Cells(1).Value.ToString)
            txt_anticipos.Text = Val(txt_anticipos.Text) + Val(totalanticipos)
        Next

        txt_sueldos.Text = 0
        For i = 0 To grilla_libro_compras.Rows.Count - 1
            totalsueldos = Val(grilla_libro_compras.Rows(i).Cells(2).Value.ToString)
            txt_sueldos.Text = Val(txt_sueldos.Text) + Val(totalsueldos)
        Next

        If txt_anticipos.Text = "" Or txt_anticipos.Text = "0" Then
            txt_anticipos.Text = "0"
        Else
            txt_anticipos.Text = Format(Int(txt_anticipos.Text), "###,###,###")
        End If

        If txt_sueldos.Text = "" Or txt_sueldos.Text = "0" Then
            txt_sueldos.Text = "0"
        Else
            txt_sueldos.Text = Format(Int(txt_sueldos.Text), "###,###,###")
        End If

    End Sub

    Private Sub Combo_año_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grilla_libro_compras.Rows.Clear()
        txt_anticipos.Text = ""
        txt_sueldos.Text = ""
    End Sub

    Private Sub Combo_mes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grilla_libro_compras.Rows.Clear()
        txt_anticipos.Text = ""
        txt_sueldos.Text = ""
    End Sub

    Sub mostrar_malla()
        'Dim nro_mes As Integer
        'If Combo_mes.Text = "ENERO" Then
        '    nro_mes = 1
        'End If
        'If Combo_mes.Text = "FEBRERO" Then
        '    nro_mes = 2
        'End If
        'If Combo_mes.Text = "MARZO" Then
        '    nro_mes = 3
        'End If
        'If Combo_mes.Text = "ABRIL" Then
        '    nro_mes = 4
        'End If
        'If Combo_mes.Text = "MAYO" Then
        '    nro_mes = 5
        'End If
        'If Combo_mes.Text = "JUNIO" Then
        '    nro_mes = 6
        'End If
        'If Combo_mes.Text = "JULIO" Then
        '    nro_mes = 7
        'End If
        'If Combo_mes.Text = "AGOSTO" Then
        '    nro_mes = 8
        'End If
        'If Combo_mes.Text = "SEPTIEMBRE" Then
        '    nro_mes = 9
        'End If
        'If Combo_mes.Text = "OCTUBRE" Then
        '    nro_mes = 10
        'End If
        'If Combo_mes.Text = "NOVIEMBRE" Then
        '    nro_mes = 11
        'End If
        'If Combo_mes.Text = "DICIEMBRE" Then
        '    nro_mes = 12
        'End If

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT rut_usuario, detalle_fondo_sueldos.detalle as det, tipo, fecha, monto as monto FROM detalle_fondo_sueldos, usuarios where detalle_fondo_sueldos.detalle=usuarios.nombre_usuario and fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and tipo <> 'SUELDO SIN IMPUTAR' order by detalle;"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_libro_compras.Rows.Clear()
        grilla_libro_compras.Columns.Clear()
        grilla_libro_compras.Columns.Add("", "RUT")
        grilla_libro_compras.Columns.Add("", "DETALLE")
        grilla_libro_compras.Columns.Add("", "TIPO")
        grilla_libro_compras.Columns.Add("", "MONTO")
        grilla_libro_compras.Columns.Add("", "FECHA")

        Dim monto As String

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                monto = DS.Tables(DT.TableName).Rows(i).Item("monto")
                monto = Trim(Replace(monto, "-", ""))

                Dim MiFechaEmision As Date
                Dim mifecha_emision2 As String
                MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")

                grilla_libro_compras.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("rut_usuario"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("det"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("tipo"), _
                                                 monto, _
                                                   mifecha_emision2)
            Next
        End If

        If grilla_libro_compras.Rows.Count <> 0 Then
            If grilla_libro_compras.Columns(0).Width = 140 Then
                grilla_libro_compras.Columns(0).Width = 139
            Else
                grilla_libro_compras.Columns(0).Width = 140
            End If

            grilla_libro_compras.Columns(1).Width = 220
            grilla_libro_compras.Columns(2).Width = 140
            grilla_libro_compras.Columns(3).Width = 140
            grilla_libro_compras.Columns(4).Width = 140
            grilla_libro_compras.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        'grilla_libro_compras.Columns(0).Visible = True
        'grilla_libro_compras.Columns(1).Visible = True
        'grilla_libro_compras.Columns(2).Visible = True
        'grilla_libro_compras.Columns(3).Visible = True
    End Sub

    Sub mostrar_sueldos()
        'Dim RutTrabajador As String
        'Dim TotalAnticipos As Integer

        'conexion.Close()
        'conexion.ConnectionString = "server=orchacabuco.dyndns.org; Database=remuneraciones; User Id=sistema_general;Password=1234; Convert Zero Datetime=True; default command timeout=3600"

        'Dim numero_mes As Integer
        'Dim numero_mes_final As String
        'numero_mes = nro_mes
        'numero_mes_final = String.Format("{0:00}", numero_mes)

        'For i = 0 To grilla_libro_compras.Rows.Count - 1
        '    RutTrabajador = grilla_libro_compras.Rows(i).Cells(0).Value.ToString
        '    TotalAnticipos = grilla_libro_compras.Rows(i).Cells(2).Value.ToString

        '    txt_tope_anticipo.Text = ""
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "SELECT * FROM remuneraciones.liquidaciones_de_sueldo where rut_trabajador='" & (RutTrabajador) & "' and fecha_liquidacion='" & (numero_mes_final & "-" & Combo_año.Text) & "';"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        DS.Tables.Add(DT)
        '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '            txt_tope_anticipo.Text = DS.Tables(DT.TableName).Rows(0).Item("totales_saldo_liquido")
        '        End If
        '    Catch err As InvalidCastException
        '        txt_tope_anticipo.Text = ""
        '    End Try
        '    conexion.Close()

        '    If txt_tope_anticipo.Text = "" Then
        '        numero_mes = nro_mes - 1
        '        numero_mes_final = String.Format("{0:00}", numero_mes)
        '        conexion.Close()
        '        DS.Tables.Clear()
        '        DT.Rows.Clear()
        '        DT.Columns.Clear()
        '        DS.Clear()
        '        conexion.Open()
        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "SELECT * FROM remuneraciones.liquidaciones_de_sueldo where rut_trabajador='" & (RutTrabajador) & "' and fecha_liquidacion='" & ((numero_mes_final) & "-" & Combo_año.Text) & "';"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '            DS.Tables.Add(DT)
        '            If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '                txt_tope_anticipo.Text = DS.Tables(DT.TableName).Rows(0).Item("totales_saldo_liquido")
        '            End If
        '        Catch err As InvalidCastException
        '            txt_tope_anticipo.Text = ""
        '        End Try
        '        conexion.Close()
        '    End If



        '    grilla_libro_compras.Rows(i).Cells(3).Value = txt_tope_anticipo.Text
        '    grilla_libro_compras.Rows(i).Cells(2).Value = Trim(Replace(grilla_libro_compras.Rows(i).Cells(2).Value, "-", ""))
        '    grilla_libro_compras.Rows(i).Cells(4).Value = Val(grilla_libro_compras.Rows(i).Cells(3).Value) - Val(grilla_libro_compras.Rows(i).Cells(2).Value)
        'Next




        'recuperar_conexion()

    End Sub
End Class