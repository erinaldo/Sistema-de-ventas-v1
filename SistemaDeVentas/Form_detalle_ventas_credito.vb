Imports System.Math
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing

Public Class Form_detalle_ventas_credito
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim numero_lineas_total As Integer = 0
    'Dim impreso As Integer = 0

    Private Sub Form_detalle_ventas_credito_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
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

    Private Sub Form_detalle_ventas_credito_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_detalle_ventas_credito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'dtp_desde.CustomFormat = "yyy-MM-dd"
        ' dtp_hasta.CustomFormat = "yyy-MM-dd"
        fecha()
        combo_venta.SelectedItem = "-"
        'mostrar_malla()
        grilla_documento.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular)
        cargar_logo()

        With grilla_documento.DefaultCellStyle
            .Font = New Font("Calibri", 12)
        End With

        grilla_documento.Font = New Font("Calibri", 12, FontStyle.Regular)
        ' fecha()
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
        Dim consulta As String

        grilla_documento.Rows.Clear()
        grilla_documento.Columns.Clear()
        grilla_documento.Columns.Add("", "TIPO")
        grilla_documento.Columns.Add("", "RUT")
        grilla_documento.Columns.Add("", "CLIENTE")
        grilla_documento.Columns.Add("", "CUPO")
        grilla_documento.Columns.Add("", "DEUDA")
        grilla_documento.Columns.Add("", "DIFERENCIA")


        If combo_venta.Text = "BOLETA" Then

            consulta = "select boleta.tipo as tipo, boleta.rut_cliente AS RUT, NOMBRE_CLIENTE AS 'CLIENTE', cupo_cliente as 'CUPO' from boleta, usuarios, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and tipo LIKE 'boleta%' and usuarios.rut_usuario =boleta.usuario_responsable and boleta.rut_cliente=clientes.rut_cliente "
            consulta = consulta & " and boleta.condiciones = 'CREDITO' "
            consulta = consulta & " GROUP BY boleta.rut_cliente ORDER BY boleta.rut_cliente"

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
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_documento.Rows.Add("BOLETA",
                                               DS.Tables(DT.TableName).Rows(i).Item("folio"),
                                                   DS.Tables(DT.TableName).Rows(i).Item("rut"),
                                                    DS.Tables(DT.TableName).Rows(i).Item("cliente"),
                                                     DS.Tables(DT.TableName).Rows(i).Item("cupo"),
                                                      "0",
                                                       "0")
                Next
            End If
        End If


        If combo_venta.Text = "FACTURA" Then

            consulta = "select factura.tipo as tipo, factura.rut_cliente AS RUT, NOMBRE_CLIENTE AS 'CLIENTE', cupo_cliente as 'CUPO' from factura , usuarios, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and tipo LIKE 'factura%' and usuarios.rut_usuario =factura.usuario_responsable and factura.rut_cliente=clientes.rut_cliente "
            consulta = consulta & " and factura.condiciones = 'CREDITO' "
            consulta = consulta & " GROUP BY factura.rut_cliente ORDER BY factura.rut_cliente"

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
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_documento.Rows.Add("FACTURA",
                                                   DS.Tables(DT.TableName).Rows(i).Item("rut"),
                                                    DS.Tables(DT.TableName).Rows(i).Item("cliente"),
                                                     DS.Tables(DT.TableName).Rows(i).Item("cupo"),
                                                      "0",
                                                       "0")
                Next
            End If
        End If



        If combo_venta.Text = "GUIA" Then

            consulta = "select guia.tipo as tipo, guia.rut_cliente AS RUT, NOMBRE_CLIENTE AS 'CLIENTE', cupo_cliente as 'CUPO' from guia , usuarios, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND tipo LIKE 'guia%' AND usuarios.rut_usuario =guia.usuario_responsable AND guia.rut_cliente=clientes.rut_cliente "
            consulta = consulta & " and guia.condiciones = 'CREDITO' "
            consulta = consulta & " GROUP BY guia.rut_cliente ORDER BY guia.rut_cliente"

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
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_documento.Rows.Add("GUIA",
                                                   DS.Tables(DT.TableName).Rows(i).Item("rut"),
                                                    DS.Tables(DT.TableName).Rows(i).Item("cliente"),
                                                     DS.Tables(DT.TableName).Rows(i).Item("cupo"),
                                                      "0",
                                                       "0")
                Next
            End If
        End If

        If combo_venta.Text = "NOTA DE CREDITO" Then

            consulta = "select nota_credito.tipo as tipo, nota_credito.rut_cliente AS RUT, NOMBRE_CLIENTE AS 'CLIENTE', MOTIVO AS 'MOTIVO', cupo_cliente as 'CUPO' from nota_credito , usuarios, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND tipo LIKE 'NOTA DE CREDITO%' AND usuarios.rut_usuario =nota_credito.usuario_responsable AND nota_credito.rut_cliente=clientes.rut_cliente "
            consulta = consulta & " and nota_credito.condiciones = 'CREDITO' "
            consulta = consulta & " GROUP BY nota_credito.rut_cliente ORDER BY nota_credito.rut_cliente"

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
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_documento.Rows.Add("NC",
                                                   DS.Tables(DT.TableName).Rows(i).Item("rut"),
                                                    DS.Tables(DT.TableName).Rows(i).Item("cliente"),
                                                     DS.Tables(DT.TableName).Rows(i).Item("cupo"),
                                                      "0",
                                                       "0")
                Next
            End If
        End If

        If combo_venta.Text = "NOTA DE DEBITO" Then

            consulta = "select nota_debito.tipo as tipo, nota_debito.rut_cliente AS RUT, NOMBRE_CLIENTE AS 'CLIENTE', cupo_cliente as 'CUPO' from nota_debito , usuarios, clientes where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' AND tipo LIKE 'NOTA DE DEBITO%' AND usuarios.rut_usuario =nota_debito.usuario_responsable AND nota_debito.rut_cliente=clientes.rut_cliente "
            consulta = consulta & " and nota_debito.condiciones = 'CREDITO' "
            consulta = consulta & " GROUP BY nota_debito.rut_cliente ORDER BY nota_debito.rut_cliente"

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
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_documento.Rows.Add("ND",
                                                   DS.Tables(DT.TableName).Rows(i).Item("rut"),
                                                    DS.Tables(DT.TableName).Rows(i).Item("cliente"),
                                                     DS.Tables(DT.TableName).Rows(i).Item("cupo"),
                                                      "0",
                                                       "0")
                Next
            End If
        End If

        If grilla_documento.Rows.Count <> 0 Then

            If grilla_documento.Columns(0).Width = 100 Then
                grilla_documento.Columns(0).Width = 101
            Else
                grilla_documento.Columns(0).Width = 100
            End If

            grilla_documento.Columns(1).Width = 100
            grilla_documento.Columns(2).Width = 188
            grilla_documento.Columns(3).Width = 140
            grilla_documento.Columns(4).Width = 120
            grilla_documento.Columns(5).Width = 120
        End If

        grilla_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub

    Sub Deuda_actual()
        Dim rut As String = ""
        For i = 0 To grilla_documento.Rows.Count - 1
            rut = grilla_documento.Rows(i).Cells(1).Value.ToString

            conexion.Close()
            Consultas_SQL("select sum(saldo) as saldo from creditos where rut_cliente = '" & (rut) & "'")
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                grilla_documento.Rows(i).Cells(4).Value = DS.Tables(DT.TableName).Rows(0).Item("saldo")


                If Val(grilla_documento.Rows(i).Cells(3).Value) < Val(grilla_documento.Rows(i).Cells(4).Value) Then
                    grilla_documento.Rows(i).Cells(5).Value = Val(grilla_documento.Rows(i).Cells(3).Value) - Val(grilla_documento.Rows(i).Cells(4).Value)
                End If
            End If

        Next
    End Sub



    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_venta.SelectedIndexChanged
        'combo_venta.SelectedItem = "-"
        grilla_documento.Columns.Clear()
        calcular_totales()
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click

        lbl_mensaje.Visible = True
        Me.Enabled = False
        grilla_documento.DataSource = Nothing

        fecha()
        mostrar_malla()
        Deuda_actual()
        calcular_totales()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""



        If grilla_documento.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            dtp_desde.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_documento, save.FileName)
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
        For c As Integer = 0 To grilla_documento.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_documento.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_documento.RowCount - 1
            For c As Integer = 0 To grilla_documento.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_documento.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        'combo_venta.SelectedItem = "-"
        grilla_documento.Columns.Clear()
        calcular_totales()
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        'combo_venta.SelectedItem = "-"
        grilla_documento.Columns.Clear()
        calcular_totales()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            grilla_documento.DataSource = Nothing
            combo_venta.SelectedItem = "-"
        End If
    End Sub

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


    Sub calcular_totales()
        Dim totalgrilla As Long

        '//Calcular el total general
        txt_total.Text = 0
        For i = 0 To grilla_documento.Rows.Count - 1
            totalgrilla = Val(grilla_documento.Rows(i).Cells(4).Value.ToString)
            txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        Next

        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total_millar.Text = "0"
        Else
            txt_total_millar.Text = Format(Int(txt_total.Text), "###,###,###")
        End If

    End Sub

    Private Sub Combo_condicion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grilla_documento.DataSource = Nothing
        calcular_totales()
    End Sub

End Class