
Public Class Form_listado_de_clientes_con_pagare
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_listado_de_clientes_con_pagare_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_listado_de_clientes_con_pagare_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_listado_de_clientes_con_pagare_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fecha()
        cargar_logo()
        grilla_deudores.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
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

    Sub mostrar_malla()
        grilla_deudores.Columns.Clear()
        grilla_deudores.Rows.Clear()

        grilla_deudores.Columns.Add("", "RUT")
        grilla_deudores.Columns.Add("", "NOMBRE")
        grilla_deudores.Columns.Add("", "FECHA")
        grilla_deudores.Columns.Add("", "PAGARE")
        grilla_deudores.Columns.Add("", "RECINTO")

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from  clientes where fecha_pagare >='" & (mifecha2) & "' and fecha_pagare <= '" & (mifecha4) & "' GROUP by rut_cliente order by nombre_cliente"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Dim MiFechaEmision As Date
                Dim mifecha_emision2 As String
                MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_pagare")
                mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")
                grilla_deudores.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("rut_cliente"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente"), _
                                                     mifecha_emision2, _
                                                      DS.Tables(DT.TableName).Rows(i).Item("pagare"), _
                                                       mirecintoempresa)
            Next
            grilla_deudores.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_deudores.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_deudores.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_deudores.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_deudores.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_deudores.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        If grilla_deudores.Rows.Count <> 0 Then
            If grilla_deudores.Columns(0).Width = 100 Then
                grilla_deudores.Columns(0).Width = 99
            Else
                grilla_deudores.Columns(0).Width = 100
            End If
            grilla_deudores.Columns(1).Width = 200
            grilla_deudores.Columns(2).Width = 100
            grilla_deudores.Columns(3).Width = 100
            grilla_deudores.Columns(4).Width = 200
        End If

    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        If grilla_deudores.Rows.Count = 0 Then
            dtp_desde.Focus()
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_deudores, save.FileName)
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
        For c As Integer = 0 To grilla_deudores.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_deudores.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_deudores.RowCount - 1
            For c As Integer = 0 To grilla_deudores.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_deudores.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            LIMPIAR()
        End If
    End Sub
    Sub LIMPIAR()
        grilla_deudores.Columns.Clear()
        grilla_deudores.Rows.Clear()
        txt_total.Text = 0
        txt_total_millar.Text = 0
        'combo_cuenta.SelectedItem = "TODOS"
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        fecha()
        mostrar_malla()
        calcular_total()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Sub calcular_total()

        '//Calcular el total general
        txt_total.Text = grilla_deudores.Rows.Count

        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total_millar.Text = "0"
        Else
            txt_total_millar.Text = Format(Int(txt_total.Text), "###,###,###")
        End If
    End Sub
End Class