Imports System.IO
Imports System.Drawing.Drawing2D
Public Class Form_traspaso_historico_credito
    Dim mifecha2 As String
    Dim mifecha4 As String

    Private Sub Form_traspaso_historico_credito_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_traspaso_historico_credito_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
    Private Sub Form_traspaso_historico_credito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      


        lbl_mensaje.Visible = True
        Me.Enabled = False

        cargar_logo()
        dtp_desde.Value = dtp_desde.Value.AddYears(Val(-2))
        fecha()
        mostrar_malla()



        lbl_mensaje.Visible = False
        Me.Enabled = True



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
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub mostrar_malla()

        conexion.Close()
        Dim DT3 As New DataTable
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion


        SC3.CommandText = "select * from creditos where saldo='0' and fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' ORDER BY cod_auto"


        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        grilla_documento.DataSource = DS3.Tables(DT3.TableName)
        conexion.Close()

        grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grilla_documento.Columns(9).Visible = False


        txt_total.Text = grilla_documento.Rows.Count



        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total_millar.Text = "0"
        Else
            txt_total_millar.Text = Format(Int(txt_total.Text), "###,###,###")
        End If




    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        fecha()
        mostrar_malla()

        lbl_mensaje.Visible = False
        Me.Enabled = True

    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click

        lbl_mensaje.Visible = True
        Me.Enabled = False




        Dim n_creditos As String
        Dim tipo As String
        Dim tipo_detalle As String
        Dim codigo_cliente As String
        Dim rut_cliente As String
        Dim fecha_venta As String
        Dim descuento As String
        Dim neto As String
        Dim iva As String
        Dim subtotal As String
        Dim total As String
        Dim saldo As String
        Dim desglose As String
        Dim condiciones As String
        Dim estado As String
        Dim usuario_responsable As String
        Dim codigo_afecta As String
        Dim nombre_afecta As String
        Dim recinto As String
        Dim fecha_vencimiento As String
        Dim fecha_pago As String
        Dim numero_cuota As String
        Dim total_cuotas As String
        Dim interes As String
        Dim gastos_de_cobranza As String
        Dim pie As String
        Dim convenio As String



        Dim cod_auto_creditos As String




        For i = 0 To grilla_documento.Rows.Count - 1
            cod_auto_creditos = grilla_documento.Rows(i).Cells(0).Value.ToString
            n_creditos = grilla_documento.Rows(i).Cells(1).Value.ToString
            tipo = grilla_documento.Rows(i).Cells(2).Value.ToString
            tipo_detalle = grilla_documento.Rows(i).Cells(3).Value.ToString
            codigo_cliente = grilla_documento.Rows(i).Cells(4).Value.ToString
            rut_cliente = grilla_documento.Rows(i).Cells(5).Value.ToString
            fecha_venta = grilla_documento.Rows(i).Cells(6).Value.ToString

            Dim mifecha_venta As Date
            mifecha_venta = fecha_venta
            fecha_venta = mifecha_venta.ToString("yyy-MM-dd")






            descuento = grilla_documento.Rows(i).Cells(7).Value.ToString
            neto = grilla_documento.Rows(i).Cells(8).Value.ToString
            iva = grilla_documento.Rows(i).Cells(9).Value.ToString
            subtotal = grilla_documento.Rows(i).Cells(10).Value.ToString
            total = grilla_documento.Rows(i).Cells(11).Value.ToString
            saldo = grilla_documento.Rows(i).Cells(12).Value.ToString
            desglose = grilla_documento.Rows(i).Cells(13).Value.ToString
            condiciones = grilla_documento.Rows(i).Cells(14).Value.ToString
            estado = grilla_documento.Rows(i).Cells(15).Value.ToString
            usuario_responsable = grilla_documento.Rows(i).Cells(16).Value.ToString
            codigo_afecta = grilla_documento.Rows(i).Cells(17).Value.ToString
            nombre_afecta = grilla_documento.Rows(i).Cells(18).Value.ToString
            recinto = grilla_documento.Rows(i).Cells(19).Value.ToString
            fecha_vencimiento = grilla_documento.Rows(i).Cells(20).Value.ToString

            Dim mifecha_vencimiento As Date
            mifecha_vencimiento = fecha_vencimiento
            fecha_vencimiento = mifecha_vencimiento.ToString("yyy-MM-dd")







            fecha_pago = grilla_documento.Rows(i).Cells(21).Value.ToString

            If fecha_pago <> "0000-00-00" Then
                Dim mifecha_pago As Date
                mifecha_pago = fecha_pago
                fecha_pago = mifecha_pago.ToString("yyy-MM-dd")
            End If








            numero_cuota = grilla_documento.Rows(i).Cells(22).Value.ToString
            total_cuotas = grilla_documento.Rows(i).Cells(23).Value.ToString
            interes = grilla_documento.Rows(i).Cells(24).Value.ToString
            gastos_de_cobranza = grilla_documento.Rows(i).Cells(25).Value.ToString
            pie = grilla_documento.Rows(i).Cells(26).Value.ToString
            convenio = grilla_documento.Rows(i).Cells(27).Value.ToString

            pie = 0
            convenio = grilla_documento.Rows(i).Cells(27).Value.ToString

            SC.Connection = conexion
            SC.CommandText = "insert into historico_creditos (n_creditos, tipo, tipo_detalle, codigo_cliente, rut_cliente, fecha_venta, descuento, neto, iva, subtotal, total, saldo, desglose, condiciones, estado, usuario_responsable, codigo_afecta, nombre_afecta, recinto, fecha_vencimiento, fecha_pago, numero_cuota, total_cuotas, interes, gastos_de_cobranza, pie, convenio) values ('" & (n_creditos) & "', '" & (tipo) & "', '" & (tipo_detalle) & "', '" & (codigo_cliente) & "', '" & (rut_cliente) & "', '" & (fecha_venta) & "', '" & (descuento) & "', '" & (neto) & "', '" & (iva) & "', '" & (subtotal) & "', '" & (total) & "', '" & (saldo) & "', '" & (desglose) & "', '" & (condiciones) & "', '" & (estado) & "', '" & (usuario_responsable) & "', '" & (codigo_afecta) & "', '" & (nombre_afecta) & "', '" & (recinto) & "', '" & (fecha_vencimiento) & "', '" & (fecha_pago) & "', '" & (numero_cuota) & "', '" & (total_cuotas) & "', '" & (interes) & "', '" & (gastos_de_cobranza) & "', '" & (pie) & "', '" & (convenio) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)


            SC.Connection = conexion
            SC.CommandText = "DELETE FROM creditos WHERE cod_auto='" & (cod_auto_creditos) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

        Next

        lbl_mensaje.Visible = False
        Me.Enabled = True

        grilla_documento.DataSource = Nothing
        txt_total_millar.Text = "0"

        MsgBox("ARCHIVO ACTUALIZADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly)



    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
End Class