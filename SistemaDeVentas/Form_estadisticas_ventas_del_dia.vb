Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_estadisticas_ventas_del_dia
    Dim mifecha2 As String
    Dim contador As Integer
    Private Sub Form_estadisticas_ventas_del_dia_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_estadisticas_ventas_del_dia_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_estadisticas_ventas_del_dia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        fecha()
        total_por_hora()
        documentos_por_hora()
        calcular_totales()
        Timer_actualizar.Start()
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
        total_por_hora()
        documentos_por_hora()
        calcular_totales()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")
    End Sub

    Sub total_por_hora()

        Me.Chart1.Series("Series1").Points.Clear()
        Dim total_millar As String
        Dim hora_alta As String

        txt_total_ventas.Text = 0

        'DESDE 8 A 9



        txt_nota_de_credito.Text = 0
        txt_total_boleta.Text = 0
        txt_total_factura.Text = 0
        txt_total_guia.Text = 0
        txt_total_nota_debito.Text = 0
        txt_total_vale_entra.Text = 0
        txt_total_vale_sale.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 8 and 8 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_boleta.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_boleta.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 8 and 8 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_factura.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_factura.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 8 and 8 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_guia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_guia.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 8 and 8 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nota_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_nota_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 8 and 8 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_nota_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_nota_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_negativo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 8 and 8 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_entra.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_entra.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_positivo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 8 and 8 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_sale.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_sale.Text = 0
        End Try
        conexion.Close()



        Me.Chart1.Series("Series1").Points.AddY(Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text))
        Me.Chart1.Series("Series1").Points(0).AxisLabel = "08"

        txt_total_ventas.Text = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        txt_hora_alta.Text = txt_total_ventas.Text
        GroupBox_hora.Text = "HORA MAS ALTA (08):"



        'DESDE 9 A 10



        txt_nota_de_credito.Text = 0
        txt_total_boleta.Text = 0
        txt_total_factura.Text = 0
        txt_total_guia.Text = 0
        txt_total_nota_debito.Text = 0
        txt_total_vale_entra.Text = 0
        txt_total_vale_sale.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 9 and 9 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_boleta.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_boleta.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 9 and 9 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_factura.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Else
                txt_total_factura.Text = 0
            End If
        Catch err As InvalidCastException
            txt_total_factura.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 9 and 9 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_guia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_guia.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 9 and 9 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nota_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_nota_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 9 and 9 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_nota_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_nota_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_negativo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 9 and 9 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_entra.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_entra.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_positivo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 9 and 9 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_sale.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_sale.Text = 0
        End Try
        conexion.Close()



        Me.Chart1.Series("Series1").Points.AddY(Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text))
        Me.Chart1.Series("Series1").Points(1).AxisLabel = "09"

        txt_total_ventas.Text = txt_total_ventas.Text + Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)


        hora_alta = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        If Val(txt_hora_alta.Text) < Val(hora_alta) Then
            GroupBox_hora.Text = "HORA MAS ALTA (09):"
            txt_hora_alta.Text = hora_alta
        End If



        ' DESDE 10 A 11



        txt_nota_de_credito.Text = 0
        txt_total_boleta.Text = 0
        txt_total_factura.Text = 0
        txt_total_guia.Text = 0
        txt_total_nota_debito.Text = 0
        txt_total_vale_entra.Text = 0
        txt_total_vale_sale.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 10 and 10 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_boleta.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_boleta.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 10 and 10 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_factura.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Else
                txt_total_factura.Text = 0
            End If
        Catch err As InvalidCastException
            txt_total_factura.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 10 and 10 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_guia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_guia.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 10 and 10 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nota_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_nota_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 10 and 10 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_nota_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_nota_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_negativo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 10 and 10 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_entra.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_entra.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_positivo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 10 and 10 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_sale.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_sale.Text = 0
        End Try
        conexion.Close()



        Me.Chart1.Series("Series1").Points.AddY(Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text))
        Me.Chart1.Series("Series1").Points(2).AxisLabel = "10"

        txt_total_ventas.Text = txt_total_ventas.Text + Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        hora_alta = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        If Val(txt_hora_alta.Text) < Val(hora_alta) Then
            GroupBox_hora.Text = "HORA MAS ALTA (10):"
            txt_hora_alta.Text = hora_alta
        End If



        ' DESDE 11 A 12



        txt_nota_de_credito.Text = 0
        txt_total_boleta.Text = 0
        txt_total_factura.Text = 0
        txt_total_guia.Text = 0
        txt_total_nota_debito.Text = 0
        txt_total_vale_entra.Text = 0
        txt_total_vale_sale.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 11 and 11 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_boleta.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_boleta.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 11 and 11 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_factura.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Else
                txt_total_factura.Text = 0
            End If
        Catch err As InvalidCastException
            txt_total_factura.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 11 and 11 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_guia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_guia.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 11 and 11 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nota_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_nota_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 11 and 11 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_nota_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_nota_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_negativo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 11 and 11 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_entra.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_entra.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_positivo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 11 and 11 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_sale.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_sale.Text = 0
        End Try
        conexion.Close()



        Me.Chart1.Series("Series1").Points.AddY(Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text))
        Me.Chart1.Series("Series1").Points(3).AxisLabel = "11"

        txt_total_ventas.Text = txt_total_ventas.Text + Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        hora_alta = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        If Val(txt_hora_alta.Text) < Val(hora_alta) Then
            GroupBox_hora.Text = "HORA MAS ALTA (11):"
            txt_hora_alta.Text = hora_alta
        End If



        ' DESDE 12 A 13



        txt_nota_de_credito.Text = 0
        txt_total_boleta.Text = 0
        txt_total_factura.Text = 0
        txt_total_guia.Text = 0
        txt_total_nota_debito.Text = 0
        txt_total_vale_entra.Text = 0
        txt_total_vale_sale.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 12 and 12 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_boleta.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_boleta.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 12 and 12 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_factura.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Else
                txt_total_factura.Text = 0
            End If
        Catch err As InvalidCastException
            txt_total_factura.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 12 and 12 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_guia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_guia.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 12 and 12 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nota_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_nota_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 12 and 12 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_nota_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_nota_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_negativo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 12 and 12 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_entra.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_entra.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_positivo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 12 and 12 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_sale.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_sale.Text = 0
        End Try
        conexion.Close()



        Me.Chart1.Series("Series1").Points.AddY(Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text))
        Me.Chart1.Series("Series1").Points(4).AxisLabel = "12"

        txt_total_ventas.Text = txt_total_ventas.Text + Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        hora_alta = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        If Val(txt_hora_alta.Text) < Val(hora_alta) Then
            GroupBox_hora.Text = "HORA MAS ALTA (12):"
            txt_hora_alta.Text = hora_alta
        End If



        ' DESDE 13 A 14



        txt_nota_de_credito.Text = 0
        txt_total_boleta.Text = 0
        txt_total_factura.Text = 0
        txt_total_guia.Text = 0
        txt_total_nota_debito.Text = 0
        txt_total_vale_entra.Text = 0
        txt_total_vale_sale.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 13 and 13 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_boleta.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_boleta.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 13 and 13 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_factura.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Else
                txt_total_factura.Text = 0
            End If
        Catch err As InvalidCastException
            txt_total_factura.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 13 and 13 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_guia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_guia.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 13 and 13 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nota_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_nota_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 13 and 13 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_nota_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_nota_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_negativo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 13 and 13 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_entra.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_entra.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_positivo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 13 and 13 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_sale.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_sale.Text = 0
        End Try
        conexion.Close()



        Me.Chart1.Series("Series1").Points.AddY(Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text))
        Me.Chart1.Series("Series1").Points(5).AxisLabel = "13"

        txt_total_ventas.Text = txt_total_ventas.Text + Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)


        hora_alta = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        If Val(txt_hora_alta.Text) < Val(hora_alta) Then
            GroupBox_hora.Text = "HORA MAS ALTA (13):"
            txt_hora_alta.Text = hora_alta
        End If



        ' DESDE 14 A 15



        txt_nota_de_credito.Text = 0
        txt_total_boleta.Text = 0
        txt_total_factura.Text = 0
        txt_total_guia.Text = 0
        txt_total_nota_debito.Text = 0
        txt_total_vale_entra.Text = 0
        txt_total_vale_sale.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 14 and 14 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_boleta.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_boleta.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 14 and 14 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_factura.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Else
                txt_total_factura.Text = 0
            End If
        Catch err As InvalidCastException
            txt_total_factura.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 14 and 14 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_guia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_guia.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 14 and 14 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nota_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_nota_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 14 and 14 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_nota_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_nota_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_negativo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 14 and 14 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_entra.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_entra.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_positivo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 14 and 14 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_sale.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_sale.Text = 0
        End Try
        conexion.Close()



        Me.Chart1.Series("Series1").Points.AddY(Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text))
        Me.Chart1.Series("Series1").Points(6).AxisLabel = "14"

        txt_total_ventas.Text = txt_total_ventas.Text + Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        hora_alta = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        If Val(txt_hora_alta.Text) < Val(hora_alta) Then
            GroupBox_hora.Text = "HORA MAS ALTA (14):"
            txt_hora_alta.Text = hora_alta
        End If



        ' DESDE 15 A 16



        txt_nota_de_credito.Text = 0
        txt_total_boleta.Text = 0
        txt_total_factura.Text = 0
        txt_total_guia.Text = 0
        txt_total_nota_debito.Text = 0
        txt_total_vale_entra.Text = 0
        txt_total_vale_sale.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 15 and 15 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_boleta.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_boleta.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 15 and 15 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_factura.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Else
                txt_total_factura.Text = 0
            End If
        Catch err As InvalidCastException
            txt_total_factura.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 15 and 15 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_guia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_guia.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 15 and 15 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nota_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_nota_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 15 and 15 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_nota_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_nota_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_negativo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 15 and 15 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_entra.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_entra.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_positivo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 15 and 15 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_sale.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_sale.Text = 0
        End Try
        conexion.Close()



        total_millar = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text)
        total_millar = Format(Int(total_millar), "###.###.###")
        Me.Chart1.Series("Series1").Points.AddY(Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text))
        Me.Chart1.Series("Series1").Points(7).AxisLabel = "15"

        txt_total_ventas.Text = txt_total_ventas.Text + Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)


        hora_alta = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        If Val(txt_hora_alta.Text) < Val(hora_alta) Then
            GroupBox_hora.Text = "HORA MAS ALTA (15):"
            txt_hora_alta.Text = hora_alta
        End If



        ' DESDE 16 A 17



        txt_nota_de_credito.Text = 0
        txt_total_boleta.Text = 0
        txt_total_factura.Text = 0
        txt_total_guia.Text = 0
        txt_total_nota_debito.Text = 0
        txt_total_vale_entra.Text = 0
        txt_total_vale_sale.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 16 and 16 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_boleta.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_boleta.Text = 0
        End Try
        conexion.Close()




        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 16 and 16 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_factura.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Else
                txt_total_factura.Text = 0
            End If
        Catch err As InvalidCastException
            txt_total_factura.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 16 and 16 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_guia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_guia.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 16 and 16 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nota_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_nota_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 16 and 16 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_nota_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_nota_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_negativo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 16 and 16 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_entra.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_entra.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_positivo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 16 and 16 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_sale.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_sale.Text = 0
        End Try
        conexion.Close()



        Me.Chart1.Series("Series1").Points.AddY(Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text))
        Me.Chart1.Series("Series1").Points(8).AxisLabel = "16"

        txt_total_ventas.Text = txt_total_ventas.Text + Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)


        hora_alta = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        If Val(txt_hora_alta.Text) < Val(hora_alta) Then
            GroupBox_hora.Text = "HORA MAS ALTA (16):"
            txt_hora_alta.Text = hora_alta
        End If



        ' DESDE 17 A 18



        txt_nota_de_credito.Text = 0
        txt_total_boleta.Text = 0
        txt_total_factura.Text = 0
        txt_total_guia.Text = 0
        txt_total_nota_debito.Text = 0
        txt_total_vale_entra.Text = 0
        txt_total_vale_sale.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 17 and 17 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_boleta.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_boleta.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 17 and 17 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_factura.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Else
                txt_total_factura.Text = 0
            End If
        Catch err As InvalidCastException
            txt_total_factura.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 17 and 17 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_guia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_guia.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 17 and 17 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nota_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_nota_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 17 and 17 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_nota_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_nota_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_negativo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 17 and 17 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_entra.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_entra.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_positivo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 17 and 17 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_sale.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_sale.Text = 0
        End Try
        conexion.Close()



        total_millar = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text)
        total_millar = Format(Int(total_millar), "###.###.###")
        Me.Chart1.Series("Series1").Points.AddY(Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text))
        Me.Chart1.Series("Series1").Points(9).AxisLabel = "17"

        txt_total_ventas.Text = txt_total_ventas.Text + Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)


        hora_alta = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        If Val(txt_hora_alta.Text) < Val(hora_alta) Then
            GroupBox_hora.Text = "HORA MAS ALTA (17):"
            txt_hora_alta.Text = hora_alta
        End If



        ' DESDE 18 A 19



        txt_nota_de_credito.Text = 0
        txt_total_boleta.Text = 0
        txt_total_factura.Text = 0
        txt_total_guia.Text = 0
        txt_total_nota_debito.Text = 0
        txt_total_vale_entra.Text = 0
        txt_total_vale_sale.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 18 and 18 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_boleta.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_boleta.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 18 and 18 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_factura.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Else
                txt_total_factura.Text = 0
            End If
        Catch err As InvalidCastException
            txt_total_factura.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 18 and 18 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_guia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_guia.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN  18 and 18 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nota_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_nota_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 18 and 18 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_nota_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_nota_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_negativo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 18 and 18 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_entra.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_entra.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_positivo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 18 and 18 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_sale.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_sale.Text = 0
        End Try
        conexion.Close()



        Me.Chart1.Series("Series1").Points.AddY(Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text))
        Me.Chart1.Series("Series1").Points(10).AxisLabel = "18"

        txt_total_ventas.Text = txt_total_ventas.Text + Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)


        hora_alta = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        If Val(txt_hora_alta.Text) < Val(hora_alta) Then
            GroupBox_hora.Text = "HORA MAS ALTA (18):"
            txt_hora_alta.Text = hora_alta
        End If



        ' DESDE 19 A 20



        txt_nota_de_credito.Text = 0
        txt_total_boleta.Text = 0
        txt_total_factura.Text = 0
        txt_total_guia.Text = 0
        txt_total_nota_debito.Text = 0
        txt_total_vale_entra.Text = 0
        txt_total_vale_sale.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 19 and 21 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_boleta.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_boleta.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 19 and 21 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_factura.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            Else
                txt_total_factura.Text = 0
            End If
        Catch err As InvalidCastException
            txt_total_factura.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 19 and 21 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_guia.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_guia.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 19 and 21 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nota_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_nota_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 19 and 21 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_nota_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_nota_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_negativo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 19 and 21 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_entra.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_entra.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select sum(total_positivo) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 19 and 21 and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_vale_sale.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_vale_sale.Text = 0
        End Try
        conexion.Close()



        Me.Chart1.Series("Series1").Points.AddY(Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text))
        Me.Chart1.Series("Series1").Points(11).AxisLabel = "19"
        txt_total_ventas.Text = txt_total_ventas.Text + Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)


        hora_alta = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        If Val(txt_hora_alta.Text) < Val(hora_alta) Then
            GroupBox_hora.Text = "HORA MAS ALTA (19):"
            txt_hora_alta.Text = hora_alta
        End If
        txt_hora_alta.Text = Format(Int(txt_hora_alta.Text), "###,###,###")

    End Sub















    Sub documentos_por_hora()


        lbl_total_doc_8.Text = 0
        lbl_total_doc_9.Text = 0
        lbl_total_doc_10.Text = 0
        lbl_total_doc_11.Text = 0
        lbl_total_doc_12.Text = 0
        lbl_total_doc_13.Text = 0
        lbl_total_doc_14.Text = 0
        lbl_total_doc_15.Text = 0
        lbl_total_doc_16.Text = 0
        lbl_total_doc_17.Text = 0
        lbl_total_doc_18.Text = 0
        lbl_total_doc_19.Text = 0

        'DESDE LAS 8

        txt_total_doc_boletas.Text = 0
        txt_total_doc_facturas.Text = 0
        txt_total_doc_guias.Text = 0
        txt_total_doc_noas_de_credito.Text = 0
        txt_total_doc_notas_de_debito.Text = 0
        txt_total_doc_vales.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_boleta) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 8 and 8 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_boletas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_boletas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_factura) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 8 and 8 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_facturas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_facturas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_guia) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 8 and 8 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_guias.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_guias.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_credito) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 8 and 8 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_noas_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_noas_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_debito) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 8 and 8 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_notas_de_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_notas_de_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(nro_vale) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 8 and 8 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_vales.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_vales.Text = 0
        End Try
        conexion.Close()




        lbl_total_doc_8.Text = Val(txt_total_doc_boletas.Text) + Val(txt_total_doc_facturas.Text) + Val(txt_total_doc_guias.Text) + Val(txt_total_doc_notas_de_debito.Text) + Val(txt_total_doc_vales.Text) - Val(txt_total_doc_noas_de_credito.Text)




        'DESDE LAS 9



        txt_total_doc_boletas.Text = 0
        txt_total_doc_facturas.Text = 0
        txt_total_doc_guias.Text = 0
        txt_total_doc_noas_de_credito.Text = 0
        txt_total_doc_notas_de_debito.Text = 0
        txt_total_doc_vales.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_boleta) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 9 and 9 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_boletas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_boletas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_factura) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 9 AND 9 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_facturas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_facturas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_guia) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 9 AND 9 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_guias.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_guias.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_credito) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 9 AND 9 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_noas_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_noas_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_debito) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 9 AND 9 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_notas_de_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_notas_de_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(nro_vale) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 9 AND 9 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_vales.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_vales.Text = 0
        End Try
        conexion.Close()




        lbl_total_doc_9.Text = Val(txt_total_doc_boletas.Text) + Val(txt_total_doc_facturas.Text) + Val(txt_total_doc_guias.Text) + Val(txt_total_doc_notas_de_debito.Text) + Val(txt_total_doc_vales.Text) - Val(txt_total_doc_noas_de_credito.Text)



        'DESDE LAS 10



        txt_total_doc_boletas.Text = 0
        txt_total_doc_facturas.Text = 0
        txt_total_doc_guias.Text = 0
        txt_total_doc_noas_de_credito.Text = 0
        txt_total_doc_notas_de_debito.Text = 0
        txt_total_doc_vales.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_boleta) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 10 and 10 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_boletas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_boletas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_factura) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 10 and 10 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_facturas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_facturas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_guia) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 10 and 10 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_guias.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_guias.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_credito) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 10 and 10 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_noas_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_noas_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_debito) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 10 and 10 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_notas_de_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_notas_de_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(nro_vale) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 10 and 10 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_vales.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_vales.Text = 0
        End Try
        conexion.Close()




        lbl_total_doc_10.Text = Val(txt_total_doc_boletas.Text) + Val(txt_total_doc_facturas.Text) + Val(txt_total_doc_guias.Text) + Val(txt_total_doc_notas_de_debito.Text) + Val(txt_total_doc_vales.Text) - Val(txt_total_doc_noas_de_credito.Text)




        'DESDE LAS 11



        txt_total_doc_boletas.Text = 0
        txt_total_doc_facturas.Text = 0
        txt_total_doc_guias.Text = 0
        txt_total_doc_noas_de_credito.Text = 0
        txt_total_doc_notas_de_debito.Text = 0
        txt_total_doc_vales.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_boleta) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 11 and 11 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_boletas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_boletas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_factura) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 11 and 11 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_facturas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_facturas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_guia) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 11 and 11 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_guias.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_guias.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_credito) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 11 and 11 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_noas_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_noas_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_debito) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 11 and 11 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_notas_de_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_notas_de_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(nro_vale) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 11 and 11 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_vales.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_vales.Text = 0
        End Try
        conexion.Close()




        lbl_total_doc_11.Text = Val(txt_total_doc_boletas.Text) + Val(txt_total_doc_facturas.Text) + Val(txt_total_doc_guias.Text) + Val(txt_total_doc_notas_de_debito.Text) + Val(txt_total_doc_vales.Text) - Val(txt_total_doc_noas_de_credito.Text)




        'DESDE LAS 12



        txt_total_doc_boletas.Text = 0
        txt_total_doc_facturas.Text = 0
        txt_total_doc_guias.Text = 0
        txt_total_doc_noas_de_credito.Text = 0
        txt_total_doc_notas_de_debito.Text = 0
        txt_total_doc_vales.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_boleta) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 12 and 12 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_boletas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_boletas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_factura) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 12 and 12 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_facturas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_facturas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_guia) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 12 and 12 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_guias.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_guias.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_credito) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 12 and 12 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_noas_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_noas_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_debito) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 12 and 12 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_notas_de_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_notas_de_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(nro_vale) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 12 and 12 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_vales.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_vales.Text = 0
        End Try
        conexion.Close()




        lbl_total_doc_12.Text = Val(txt_total_doc_boletas.Text) + Val(txt_total_doc_facturas.Text) + Val(txt_total_doc_guias.Text) + Val(txt_total_doc_notas_de_debito.Text) + Val(txt_total_doc_vales.Text) - Val(txt_total_doc_noas_de_credito.Text)




        'DESDE LAS 13



        txt_total_doc_boletas.Text = 0
        txt_total_doc_facturas.Text = 0
        txt_total_doc_guias.Text = 0
        txt_total_doc_noas_de_credito.Text = 0
        txt_total_doc_notas_de_debito.Text = 0
        txt_total_doc_vales.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_boleta) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 13 and 13 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_boletas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_boletas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_factura) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 13 and 13 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_facturas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_facturas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_guia) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 13 and 13 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_guias.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_guias.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_credito) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 13 and 13 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_noas_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_noas_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_debito) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 13 and 13 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_notas_de_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_notas_de_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(nro_vale) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 13 and 13 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_vales.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_vales.Text = 0
        End Try
        conexion.Close()




        lbl_total_doc_13.Text = Val(txt_total_doc_boletas.Text) + Val(txt_total_doc_facturas.Text) + Val(txt_total_doc_guias.Text) + Val(txt_total_doc_notas_de_debito.Text) + Val(txt_total_doc_vales.Text) - Val(txt_total_doc_noas_de_credito.Text)




        'DESDE LAS 14



        txt_total_doc_boletas.Text = 0
        txt_total_doc_facturas.Text = 0
        txt_total_doc_guias.Text = 0
        txt_total_doc_noas_de_credito.Text = 0
        txt_total_doc_notas_de_debito.Text = 0
        txt_total_doc_vales.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_boleta) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 14 and 14 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_boletas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_boletas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_factura) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 14 and 14 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_facturas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_facturas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_guia) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 14 and 14 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_guias.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_guias.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_credito) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 14 and 14 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_noas_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_noas_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_debito) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 14 and 14 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_notas_de_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_notas_de_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(nro_vale) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 14 and 14 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_vales.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_vales.Text = 0
        End Try
        conexion.Close()




        lbl_total_doc_14.Text = Val(txt_total_doc_boletas.Text) + Val(txt_total_doc_facturas.Text) + Val(txt_total_doc_guias.Text) + Val(txt_total_doc_notas_de_debito.Text) + Val(txt_total_doc_vales.Text) - Val(txt_total_doc_noas_de_credito.Text)




        'DESDE LAS 15



        txt_total_doc_boletas.Text = 0
        txt_total_doc_facturas.Text = 0
        txt_total_doc_guias.Text = 0
        txt_total_doc_noas_de_credito.Text = 0
        txt_total_doc_notas_de_debito.Text = 0
        txt_total_doc_vales.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_boleta) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 15 and 15 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_boletas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_boletas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_factura) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 15 and 15 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_facturas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_facturas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_guia) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 15 and 15 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_guias.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_guias.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_credito) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 15 and 15 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_noas_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_noas_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_debito) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 15 and 15 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_notas_de_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_notas_de_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(nro_vale) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 15 and 15 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_vales.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_vales.Text = 0
        End Try
        conexion.Close()




        lbl_total_doc_15.Text = Val(txt_total_doc_boletas.Text) + Val(txt_total_doc_facturas.Text) + Val(txt_total_doc_guias.Text) + Val(txt_total_doc_notas_de_debito.Text) + Val(txt_total_doc_vales.Text) - Val(txt_total_doc_noas_de_credito.Text)



        'DESDE LAS 16



        txt_total_doc_boletas.Text = 0
        txt_total_doc_facturas.Text = 0
        txt_total_doc_guias.Text = 0
        txt_total_doc_noas_de_credito.Text = 0
        txt_total_doc_notas_de_debito.Text = 0
        txt_total_doc_vales.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_boleta) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 16 and 16 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_boletas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_boletas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_factura) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 16 and 16 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_facturas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_facturas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_guia) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 16 and 16 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_guias.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_guias.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_credito) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 16 and 16 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_noas_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_noas_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_debito) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 16 and 16 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_notas_de_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_notas_de_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(nro_vale) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 16 and 16 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_vales.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_vales.Text = 0
        End Try
        conexion.Close()




        lbl_total_doc_17.Text = Val(txt_total_doc_boletas.Text) + Val(txt_total_doc_facturas.Text) + Val(txt_total_doc_guias.Text) + Val(txt_total_doc_notas_de_debito.Text) + Val(txt_total_doc_vales.Text) - Val(txt_total_doc_noas_de_credito.Text)




        'DESDE LAS 17



        txt_total_doc_boletas.Text = 0
        txt_total_doc_facturas.Text = 0
        txt_total_doc_guias.Text = 0
        txt_total_doc_noas_de_credito.Text = 0
        txt_total_doc_notas_de_debito.Text = 0
        txt_total_doc_vales.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_boleta) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 17 and 17 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_boletas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_boletas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_factura) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 17 and 17 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_facturas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_facturas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_guia) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 17 and 17 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_guias.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_guias.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_credito) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 17 and 17 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_noas_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_noas_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_debito) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 17 and 17 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_notas_de_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_notas_de_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(nro_vale) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 17 and 17 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_vales.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_vales.Text = 0
        End Try
        conexion.Close()




        lbl_total_doc_17.Text = Val(txt_total_doc_boletas.Text) + Val(txt_total_doc_facturas.Text) + Val(txt_total_doc_guias.Text) + Val(txt_total_doc_notas_de_debito.Text) + Val(txt_total_doc_vales.Text) - Val(txt_total_doc_noas_de_credito.Text)




        'DESDE LAS 18



        txt_total_doc_boletas.Text = 0
        txt_total_doc_facturas.Text = 0
        txt_total_doc_guias.Text = 0
        txt_total_doc_noas_de_credito.Text = 0
        txt_total_doc_notas_de_debito.Text = 0
        txt_total_doc_vales.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_boleta) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 18 and 18 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_boletas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_boletas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_factura) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 18 and 18 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_facturas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_facturas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_guia) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 18 and 18 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_guias.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_guias.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_credito) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 18 and 18 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_noas_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_noas_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_debito) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 18 and 18 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_notas_de_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_notas_de_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(nro_vale) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 18 and 18 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_vales.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_vales.Text = 0
        End Try
        conexion.Close()




        lbl_total_doc_18.Text = Val(txt_total_doc_boletas.Text) + Val(txt_total_doc_facturas.Text) + Val(txt_total_doc_guias.Text) + Val(txt_total_doc_notas_de_debito.Text) + Val(txt_total_doc_vales.Text) - Val(txt_total_doc_noas_de_credito.Text)




        'DESDE LAS 19



        txt_total_doc_boletas.Text = 0
        txt_total_doc_facturas.Text = 0
        txt_total_doc_guias.Text = 0
        txt_total_doc_noas_de_credito.Text = 0
        txt_total_doc_notas_de_debito.Text = 0
        txt_total_doc_vales.Text = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_boleta) as total from BOLETA where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 19 and 21 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_boletas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_boletas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_factura) as total from factura where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 19 and 21 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_facturas.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_facturas.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select  count(n_guia) as total from guia where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 19 and 21 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_guias.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_guias.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_credito) as total from nota_credito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 19 and 21 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_noas_de_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_noas_de_credito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(n_nota_debito) as total from nota_debito where fecha_venta ='" & (mifecha2) & "' and hora BETWEEN 19 and 21 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_notas_de_debito.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_notas_de_debito.Text = 0
        End Try
        conexion.Close()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select count(nro_vale) as total from vale_cambio where fecha ='" & (mifecha2) & "' and hora BETWEEN 19 and 21 and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_total_doc_vales.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
            End If
        Catch err As InvalidCastException
            txt_total_doc_vales.Text = 0
        End Try
        conexion.Close()




        lbl_total_doc_19.Text = Val(txt_total_doc_boletas.Text) + Val(txt_total_doc_facturas.Text) + Val(txt_total_doc_guias.Text) + Val(txt_total_doc_notas_de_debito.Text) + Val(txt_total_doc_vales.Text) - Val(txt_total_doc_noas_de_credito.Text)




    End Sub

    Sub calcular_totales()
        'Dim total_millar As Integer
        'total_millar = txt_total_ventas.Text

        txt_total_ventas.Text = Format(Int(txt_total_ventas.Text), "###,###,###")




        txt_total_doc.Text = Val(lbl_total_doc_8.Text) + Val(lbl_total_doc_9.Text) + Val(lbl_total_doc_10.Text) + Val(lbl_total_doc_11.Text) + Val(lbl_total_doc_12.Text) + Val(lbl_total_doc_13.Text) + Val(lbl_total_doc_14.Text) + Val(lbl_total_doc_15.Text) + Val(lbl_total_doc_16.Text) + Val(lbl_total_doc_17.Text) + Val(lbl_total_doc_18.Text) + Val(lbl_total_doc_19.Text)




        txt_total_doc.Text = Format(Int(txt_total_doc.Text), "###,###,###")
    End Sub

    Private Sub btn_play_vendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_play_vendedor.Click
        btn_play_vendedor.Visible = False
        btn_pause_vendedor.Visible = True
        btn_pause_vendedor.Focus()
        Timer_actualizar.Start()
    End Sub

    Private Sub btn_pause_vendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pause_vendedor.Click
        btn_play_vendedor.Visible = True
        btn_play_vendedor.Focus()
        btn_pause_vendedor.Visible = False
        Timer_actualizar.Stop()
        contador = 0
    End Sub

    Private Sub Timer_actualizar_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_actualizar.Tick
        contador = contador + 1
        If (contador > 100) Then
            contador = 0
            btn_mostrar.PerformClick()
        End If
    End Sub


   

End Class