Imports System.Math
Public Class Form_deuda_clientes_segun_fecha
    Dim mifecha2 As String
    Dim mifecha4 As String

    Private Sub Form_deuda_clientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_deuda_clientes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub Form_deuda_clientes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_deuda_clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtp_desde.Text = "1980-01-01"
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub mostrar_totales()
        fecha()
        txt_total_millar.Text = "0"

        Dim total_creditos As Long = 0
        Dim total_historico As Long = 0
        Dim total_abonos As Long = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select sum(TOTAL) AS TOTAL from creditos where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            total_creditos = DS.Tables(DT.TableName).Rows(0).Item("TOTAL")
        End If

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select sum(TOTAL) AS TOTAL from historico_creditos where fecha_venta>='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            total_historico = DS.Tables(DT.TableName).Rows(0).Item("TOTAL")
        End If

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select sum(monto_abono) AS TOTAL from abono where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            total_abonos = DS.Tables(DT.TableName).Rows(0).Item("TOTAL")
        End If


        txt_total_millar.Text = Val(total_creditos) + Val(total_historico) - Val(total_abonos)



        Dim iva As Integer
        Dim neto As Integer
        Dim iva_valor As String

        iva_valor = valor_iva / 100 + 1
        neto = (txt_total_millar.Text / iva_valor)
        Round(neto)
        txt_neto_millar.Text = neto

        iva = ((txt_neto_millar.Text) * valor_iva / 100)
        Round(iva)
        txt_iva_millar.Text = iva

        If txt_neto_millar.Text = "" Or txt_neto_millar.Text = "0" Then
            txt_neto_millar.Text = "0"
        Else
            txt_neto_millar.Text = Format(Int(txt_neto_millar.Text), "###,###,###")
        End If
        If txt_iva_millar.Text = "" Or txt_iva_millar.Text = "0" Then
            txt_iva_millar.Text = "0"
        Else
            txt_iva_millar.Text = Format(Int(txt_iva_millar.Text), "###,###,###")
        End If
        If txt_total_millar.Text = "" Or txt_total_millar.Text = "0" Then
            txt_total_millar.Text = "0"
        Else
            txt_total_millar.Text = Format(Int(txt_total_millar.Text), "###,###,###")
        End If
    End Sub

    Sub mostrar_malla()
        fecha()
        grilla_deuda.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select clientes.rut_cliente AS RUT, nombre_cliente AS NOMBRE, sum(saldo) AS TOTAL from `creditos`,`clientes` where fecha_venta>='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and creditos.rut_cliente=clientes.rut_cliente group by creditos.rut_cliente;"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_deuda.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("RUT"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("TOTAL"))
            Next
        End If




        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select clientes.rut_cliente AS RUT, nombre_cliente AS NOMBRE, sum(saldo) AS TOTAL from historico_creditos,`clientes` where fecha_venta>='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and historico_creditos.rut_cliente=clientes.rut_cliente group by historico_creditos.rut_cliente;"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_deuda.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("RUT"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("TOTAL"))
            Next
        End If




        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select abono.rut_cliente AS RUT, clientes.nombre_cliente AS NOMBRE , sum(monto_abono) AS TOTAL from `abono`,`clientes` where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and abono.rut_cliente=clientes.rut_cliente group by abono.rut_cliente;"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_deuda.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("RUT"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                  "-" & DS.Tables(DT.TableName).Rows(i).Item("TOTAL"))
            Next
        End If
    End Sub

    Sub grabar_deuda()
        SC.Connection = conexion
        SC.CommandText = "DELETE FROM deuda_cliente_temporal WHERE `cod_auto`='1';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "DELETE FROM deuda_cliente_temporal WHERE `cod_auto`<>'1';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        Dim VarRut As String
        Dim varNombre As String
        Dim varTotal As String
        For i = 0 To grilla_deuda.Rows.Count - 1
            VarRut = grilla_deuda.Rows(i).Cells(0).Value.ToString
            varNombre = grilla_deuda.Rows(i).Cells(1).Value.ToString
            varTotal = grilla_deuda.Rows(i).Cells(2).Value.ToString

            SC.Connection = conexion
            SC.CommandText = "INSERT INTO deuda_cliente_temporal (rut, nombre, total) VALUES ('" & (VarRut) & "','" & (varNombre) & "', '" & (varTotal) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next

        grilla_deuda.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select rut, nombre, total from deuda_cliente_temporal order by rut;"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_deuda.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("RUT"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("TOTAL"), _
                                                   mirecintoempresa)
            Next
        End If
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False


        mostrar_totales()

        lbl_mensaje.Visible = False
        Me.Enabled = True

        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA VER EL DETALLE POR RUT DE LA DEUDA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        If valormensaje = vbYes Then
            valormensaje = MsgBox("ESTA OPERACION PUEDE TARDAR VARIOS MINUTOS, ¿DESEA CONTINUAR?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
            If valormensaje = vbYes Then
                grilla_deuda.DataSource = Nothing
                mostrar_malla()
                grabar_deuda()
                calcular_totales()
                lbl_mensaje.Visible = False
                Me.Enabled = True
            End If
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        If grilla_deuda.Rows.Count = 0 Then
            dtp_desde.Focus()
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_deuda, save.FileName)
        End If
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Sub calcular_totales()
        ' Dim descgrilla As Long
        ' Dim netogrilla As Long
        ' Dim ivagrilla As Long
        Dim totalgrilla As Long
        ' Dim subtotalgrilla As Long

        'Calcular el total general
        txt_total_millar.Text = 0
        For i = 0 To grilla_deuda.Rows.Count - 1
            totalgrilla = Val(grilla_deuda.Rows(i).Cells(2).Value.ToString)
            txt_total_millar.Text = Val(txt_total_millar.Text) + Val(totalgrilla)
        Next

        Dim iva As Integer
        Dim neto As Integer
        Dim iva_valor As String

        iva_valor = valor_iva / 100 + 1
        neto = (txt_total_millar.Text / iva_valor)
        Round(neto)
        txt_neto_millar.Text = neto

        iva = ((txt_neto_millar.Text) * valor_iva / 100)
        Round(iva)
        txt_iva_millar.Text = iva

        If txt_neto_millar.Text = "" Or txt_neto_millar.Text = "0" Then
            txt_neto_millar.Text = "0"
        Else
            txt_neto_millar.Text = Format(Int(txt_neto_millar.Text), "###,###,###")
        End If
        If txt_iva_millar.Text = "" Or txt_iva_millar.Text = "0" Then
            txt_iva_millar.Text = "0"
        Else
            txt_iva_millar.Text = Format(Int(txt_iva_millar.Text), "###,###,###")
        End If
        If txt_total_millar.Text = "" Or txt_total_millar.Text = "0" Then
            txt_total_millar.Text = "0"
        Else
            txt_total_millar.Text = Format(Int(txt_total_millar.Text), "###,###,###")
        End If
    End Sub

    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)
        Dim xlApp As Object = CreateObject("Excel.Application")
        'crear una nueva hoja de calculo 
        Dim xlWB As Object = xlApp.WorkBooks.add
        Dim xlWS As Object = xlWB.WorkSheets(1)

        'exportamos los caracteres de las columnas 
        For c As Integer = 0 To grilla_deuda.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_deuda.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_deuda.RowCount - 1
            For c As Integer = 0 To grilla_deuda.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_deuda.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        grilla_deuda.Rows.Clear()
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        grilla_deuda.Rows.Clear()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        grilla_deuda.Rows.Clear()
    End Sub
End Class

