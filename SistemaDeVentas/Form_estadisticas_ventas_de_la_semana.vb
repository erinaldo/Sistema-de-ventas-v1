Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_estadisticas_ventas_de_la_semana
    Dim mifecha2 As String
    Dim contador As Integer

    Dim VarDia1 As String
    Dim VarDia2 As String
    Dim VarDia3 As String
    Dim VarDia4 As String
    Dim VarDia5 As String
    Dim VarDia6 As String
    Dim VarDia7 As String

    Private Sub Form_estadisticas_ventas_de_la_semana_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_estadisticas_ventas_de_la_semana_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_estadisticas_ventas_de_la_semana_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        dtp1.CustomFormat = "yyy-MM-dd"

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

        Dim VarDiamifecha1 As Date
        Dim VarDiamifecha2 As Date
        Dim VarDiamifecha3 As Date
        Dim VarDiamifecha4 As Date
        Dim VarDiamifecha5 As Date
        Dim VarDiamifecha6 As Date
        Dim VarDiamifecha7 As Date





        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim VarDiaSemana As String
        'Dim VarNombreDia As String
        VarDiaSemana = Weekday(mifecha2, vbMonday)
        'he puesto vbmonday para que el primer dia de la semana lo coja el lunes 'y devuelva un 1 cuando sea lunes.

        'If VarDiaSemana = 1 Then
        '    VarNombreDia = "LUNES"
        'ElseIf VarDiaSemana = 2 Then
        '    VarNombreDia = "MARTES"
        'ElseIf VarDiaSemana = 3 Then
        '    VarNombreDia = "MIERCOLES"
        'ElseIf VarDiaSemana = 4 Then
        '    VarNombreDia = "JUEVES"
        'ElseIf VarDiaSemana = 5 Then
        '    VarNombreDia = "VIERNES"
        'ElseIf VarDiaSemana = 6 Then
        '    VarNombreDia = "SABADO"
        'ElseIf VarDiaSemana = 7 Then
        '    VarNombreDia = "DOMINGO"
        'End If

        dtp1.Text = mifecha2

        If VarDiaSemana = 1 Then
            VarDia1 = mifecha2
            VarDia2 = dtp1.Value.AddDays(Val(+1))
            VarDia3 = dtp1.Value.AddDays(Val(+2))
            VarDia4 = dtp1.Value.AddDays(Val(+3))
            VarDia5 = dtp1.Value.AddDays(Val(+4))
            VarDia6 = dtp1.Value.AddDays(Val(+5))
            VarDia7 = dtp1.Value.AddDays(Val(+6))
        End If

        If VarDiaSemana = 2 Then
            VarDia1 = dtp1.Value.AddDays(Val(-1))
            VarDia2 = mifecha2
            VarDia3 = dtp1.Value.AddDays(Val(+1))
            VarDia4 = dtp1.Value.AddDays(Val(+2))
            VarDia5 = dtp1.Value.AddDays(Val(+3))
            VarDia6 = dtp1.Value.AddDays(Val(+4))
            VarDia7 = dtp1.Value.AddDays(Val(+5))
        End If

        If VarDiaSemana = 3 Then
            VarDia1 = dtp1.Value.AddDays(Val(-2))
            VarDia2 = dtp1.Value.AddDays(Val(-1))
            VarDia3 = mifecha2
            VarDia4 = dtp1.Value.AddDays(Val(+1))
            VarDia5 = dtp1.Value.AddDays(Val(+2))
            VarDia6 = dtp1.Value.AddDays(Val(+3))
            VarDia7 = dtp1.Value.AddDays(Val(+4))
        End If

        If VarDiaSemana = 4 Then
            VarDia1 = dtp1.Value.AddDays(Val(-3))
            VarDia2 = dtp1.Value.AddDays(Val(-2))
            VarDia3 = dtp1.Value.AddDays(Val(-1))
            VarDia4 = mifecha2
            VarDia5 = dtp1.Value.AddDays(Val(+1))
            VarDia6 = dtp1.Value.AddDays(Val(+2))
            VarDia7 = dtp1.Value.AddDays(Val(+3))
        End If

        If VarDiaSemana = 5 Then
            VarDia1 = dtp1.Value.AddDays(Val(-4))
            VarDia2 = dtp1.Value.AddDays(Val(-3))
            VarDia3 = dtp1.Value.AddDays(Val(-2))
            VarDia4 = dtp1.Value.AddDays(Val(-1))
            VarDia5 = mifecha2
            VarDia6 = dtp1.Value.AddDays(Val(+1))
            VarDia7 = dtp1.Value.AddDays(Val(+2))
        End If

        If VarDiaSemana = 6 Then
            VarDia1 = dtp1.Value.AddDays(Val(-5))
            VarDia2 = dtp1.Value.AddDays(Val(-4))
            VarDia3 = dtp1.Value.AddDays(Val(-3))
            VarDia4 = dtp1.Value.AddDays(Val(-2))
            VarDia5 = dtp1.Value.AddDays(Val(-1))
            VarDia6 = mifecha2
            VarDia7 = dtp1.Value.AddDays(Val(+1))
        End If

        If VarDiaSemana = 6 Then
            VarDia1 = dtp1.Value.AddDays(Val(-6))
            VarDia2 = dtp1.Value.AddDays(Val(-5))
            VarDia3 = dtp1.Value.AddDays(Val(-4))
            VarDia4 = dtp1.Value.AddDays(Val(-3))
            VarDia5 = dtp1.Value.AddDays(Val(-2))
            VarDia6 = dtp1.Value.AddDays(Val(-1))
            VarDia7 = mifecha2
        End If







        VarDiamifecha1 = VarDia1
        VarDia1 = VarDiamifecha1.ToString("yyy-MM-dd")

        VarDiamifecha2 = VarDia2
        VarDia2 = VarDiamifecha2.ToString("yyy-MM-dd")


        VarDiamifecha3 = VarDia3
        VarDia3 = VarDiamifecha3.ToString("yyy-MM-dd")


        VarDiamifecha4 = VarDia4
        VarDia4 = VarDiamifecha4.ToString("yyy-MM-dd")


        VarDiamifecha5 = VarDia5
        VarDia5 = VarDiamifecha5.ToString("yyy-MM-dd")


        VarDiamifecha6 = VarDia6
        VarDia6 = VarDiamifecha6.ToString("yyy-MM-dd")


        VarDiamifecha7 = VarDia7
        VarDia7 = VarDiamifecha7.ToString("yyy-MM-dd")

    End Sub

    Sub total_por_hora()

        'Me.Chart1.Series("Series1").Points.Clear()
        'Dim total_millar As String
        Dim hora_alta As String

        txt_total_ventas.Text = 0




        'DIA 1



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
            SC.CommandText = "select sum(total) as total from BOLETA where fecha_venta ='" & (VarDia1) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from factura where fecha_venta ='" & (VarDia1) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from guia where fecha_venta ='" & (VarDia1) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta ='" & (VarDia1) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta ='" & (VarDia1) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total_negativo) as total from vale_cambio where fecha ='" & (VarDia1) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total_positivo) as total from vale_cambio where fecha ='" & (VarDia1) & "' and usuario_responsable <> 'SISTEMA'"
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



        'Me.Chart1.Series("Series1").Points.AddY(Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text))
        'Me.Chart1.Series("Series1").Points(0).AxisLabel = "LUNES"

        txt_total_ventas.Text = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        txt_hora_alta.Text = txt_total_ventas.Text
        GroupBox_hora.Text = "DIA MAS ALTO (LUN):"



        'DIA 2



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
            SC.CommandText = "select sum(total) as total from BOLETA where fecha_venta ='" & (VarDia2) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from factura where fecha_venta ='" & (VarDia2) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from guia where fecha_venta ='" & (VarDia2) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta ='" & (VarDia2) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta ='" & (VarDia2) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total_negativo) as total from vale_cambio where fecha ='" & (VarDia2) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total_positivo) as total from vale_cambio where fecha ='" & (VarDia2) & "' and usuario_responsable <> 'SISTEMA'"
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



        'Me.Chart1.Series("Series1").Points.AddY(Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text))
        'Me.Chart1.Series("Series1").Points(1).AxisLabel = "MARTES"

        txt_total_ventas.Text = txt_total_ventas.Text + Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)


        hora_alta = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        If Val(txt_hora_alta.Text) < Val(hora_alta) Then
            GroupBox_hora.Text = "DIA MAS ALTO (MAR):"
            txt_hora_alta.Text = hora_alta
        End If



        ' DIA 3



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
            SC.CommandText = "select sum(total) as total from BOLETA where fecha_venta ='" & (VarDia3) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from factura where fecha_venta ='" & (VarDia3) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from guia where fecha_venta ='" & (VarDia3) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta ='" & (VarDia3) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta ='" & (VarDia3) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total_negativo) as total from vale_cambio where fecha ='" & (VarDia3) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total_positivo) as total from vale_cambio where fecha ='" & (VarDia3) & "' and usuario_responsable <> 'SISTEMA'"
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



        'Me.Chart1.Series("Series1").Points.AddY(Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text))
        'Me.Chart1.Series("Series1").Points(2).AxisLabel = "MIERCOLES"

        txt_total_ventas.Text = txt_total_ventas.Text + Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        hora_alta = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        If Val(txt_hora_alta.Text) < Val(hora_alta) Then
            GroupBox_hora.Text = "DIA MAS ALTO (MIE):"
            txt_hora_alta.Text = hora_alta
        End If



        ' DIA 4



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
            SC.CommandText = "select sum(total) as total from BOLETA where fecha_venta ='" & (VarDia4) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from factura where fecha_venta ='" & (VarDia4) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from guia where fecha_venta ='" & (VarDia4) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta ='" & (VarDia4) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta ='" & (VarDia4) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total_negativo) as total from vale_cambio where fecha ='" & (VarDia4) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total_positivo) as total from vale_cambio where fecha ='" & (VarDia4) & "' and usuario_responsable <> 'SISTEMA'"
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



        'Me.Chart1.Series("Series1").Points.AddY(Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text))
        'Me.Chart1.Series("Series1").Points(3).AxisLabel = "JUEVES"

        txt_total_ventas.Text = txt_total_ventas.Text + Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        hora_alta = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        If Val(txt_hora_alta.Text) < Val(hora_alta) Then
            GroupBox_hora.Text = "DIA MAS ALTO (JUE):"
            txt_hora_alta.Text = hora_alta
        End If



        ' DIA 5



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
            SC.CommandText = "select sum(total) as total from BOLETA where fecha_venta ='" & (VarDia5) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from factura where fecha_venta ='" & (VarDia5) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from guia where fecha_venta ='" & (VarDia5) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta ='" & (VarDia5) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta ='" & (VarDia5) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total_negativo) as total from vale_cambio where fecha ='" & (VarDia5) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total_positivo) as total from vale_cambio where fecha ='" & (VarDia5) & "' and usuario_responsable <> 'SISTEMA'"
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



        'Me.Chart1.Series("Series1").Points.AddY(Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text))
        'Me.Chart1.Series("Series1").Points(4).AxisLabel = "VIERNES"

        txt_total_ventas.Text = txt_total_ventas.Text + Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        hora_alta = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        If Val(txt_hora_alta.Text) < Val(hora_alta) Then
            GroupBox_hora.Text = "DIA MAS ALTO (VIE):"
            txt_hora_alta.Text = hora_alta
        End If



        'DIA 6



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
            SC.CommandText = "select sum(total) as total from BOLETA where fecha_venta ='" & (VarDia6) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from factura where fecha_venta ='" & (VarDia6) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from guia where fecha_venta ='" & (VarDia6) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta ='" & (VarDia6) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta ='" & (VarDia6) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total_negativo) as total from vale_cambio where fecha ='" & (VarDia6) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total_positivo) as total from vale_cambio where fecha ='" & (VarDia6) & "' and usuario_responsable <> 'SISTEMA'"
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



        'Me.Chart1.Series("Series1").Points.AddY(Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text))
        'Me.Chart1.Series("Series1").Points(5).AxisLabel = "SABADO"

        txt_total_ventas.Text = txt_total_ventas.Text + Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)


        hora_alta = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        If Val(txt_hora_alta.Text) < Val(hora_alta) Then
            GroupBox_hora.Text = "DIA MAS ALTO (SAB):"
            txt_hora_alta.Text = hora_alta
        End If



        ' DIA 7



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
            SC.CommandText = "select sum(total) as total from BOLETA where fecha_venta ='" & (VarDia7) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from factura where fecha_venta ='" & (VarDia7) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from guia where fecha_venta ='" & (VarDia7) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from nota_credito where fecha_venta ='" & (VarDia7) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total) as total from nota_debito where fecha_venta ='" & (VarDia7) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total_negativo) as total from vale_cambio where fecha ='" & (VarDia7) & "' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select sum(total_positivo) as total from vale_cambio where fecha ='" & (VarDia7) & "' and usuario_responsable <> 'SISTEMA'"
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



        'Me.Chart1.Series("Series1").Points.AddY(Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text))
        'Me.Chart1.Series("Series1").Points(6).AxisLabel = "DOMINGO"

        txt_total_ventas.Text = txt_total_ventas.Text + Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        hora_alta = Val(txt_total_boleta.Text) + Val(txt_total_factura.Text) + Val(txt_total_guia.Text) + Val(txt_total_nota_debito.Text) - Val(txt_nota_de_credito.Text) - Val(txt_total_vale_entra.Text) + Val(txt_total_vale_sale.Text)

        If Val(txt_hora_alta.Text) < Val(hora_alta) Then
            GroupBox_hora.Text = "DIA MAS ALTO(DOM):"
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


        'DIA 1

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
            SC.CommandText = "select count(n_boleta) as total from BOLETA where fecha_venta ='" & (VarDia1) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select  count(n_factura) as total from factura where fecha_venta ='" & (VarDia1) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select  count(n_guia) as total from guia where fecha_venta ='" & (VarDia1) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(n_nota_credito) as total from nota_credito where fecha_venta ='" & (VarDia1) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(n_nota_debito) as total from nota_debito where fecha_venta ='" & (VarDia1) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(nro_vale) as total from vale_cambio where fecha ='" & (VarDia1) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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




        'DIA 2



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
            SC.CommandText = "select count(n_boleta) as total from BOLETA where fecha_venta ='" & (VarDia2) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select  count(n_factura) as total from factura where fecha_venta ='" & (VarDia2) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select  count(n_guia) as total from guia where fecha_venta ='" & (VarDia2) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(n_nota_credito) as total from nota_credito where fecha_venta ='" & (VarDia2) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(n_nota_debito) as total from nota_debito where fecha_venta ='" & (VarDia2) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(nro_vale) as total from vale_cambio where fecha ='" & (VarDia2) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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



        'DIA 3



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
            SC.CommandText = "select count(n_boleta) as total from BOLETA where fecha_venta ='" & (VarDia3) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select  count(n_factura) as total from factura where fecha_venta ='" & (VarDia3) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select  count(n_guia) as total from guia where fecha_venta ='" & (VarDia3) & "' AND estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(n_nota_credito) as total from nota_credito where fecha_venta ='" & (VarDia3) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(n_nota_debito) as total from nota_debito where fecha_venta ='" & (VarDia3) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(nro_vale) as total from vale_cambio where fecha ='" & (VarDia3) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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




        'DIA 4



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
            SC.CommandText = "select count(n_boleta) as total from BOLETA where fecha_venta ='" & (VarDia4) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select  count(n_factura) as total from factura where fecha_venta ='" & (VarDia4) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select  count(n_guia) as total from guia where fecha_venta ='" & (VarDia4) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(n_nota_credito) as total from nota_credito where fecha_venta ='" & (VarDia4) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(n_nota_debito) as total from nota_debito where fecha_venta ='" & (VarDia4) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(nro_vale) as total from vale_cambio where fecha ='" & (VarDia4) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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




        'DIA 5



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
            SC.CommandText = "select count(n_boleta) as total from BOLETA where fecha_venta ='" & (VarDia5) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select  count(n_factura) as total from factura where fecha_venta ='" & (VarDia5) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select  count(n_guia) as total from guia where fecha_venta ='" & (VarDia5) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(n_nota_credito) as total from nota_credito where fecha_venta ='" & (VarDia5) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(n_nota_debito) as total from nota_debito where fecha_venta ='" & (VarDia5) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(nro_vale) as total from vale_cambio where fecha ='" & (VarDia5) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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




        'DIA 6



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
            SC.CommandText = "select count(n_boleta) as total from BOLETA where fecha_venta ='" & (VarDia6) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select  count(n_factura) as total from factura where fecha_venta ='" & (VarDia6) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select  count(n_guia) as total from guia where fecha_venta ='" & (VarDia6) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(n_nota_credito) as total from nota_credito where fecha_venta ='" & (VarDia6) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(n_nota_debito) as total from nota_debito where fecha_venta ='" & (VarDia6) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(nro_vale) as total from vale_cambio where fecha ='" & (VarDia6) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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




        'DIA 7



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
            SC.CommandText = "select count(n_boleta) as total from BOLETA where fecha_venta ='" & (VarDia7) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select  count(n_factura) as total from factura where fecha_venta ='" & (VarDia7) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select  count(n_guia) as total from guia where fecha_venta ='" & (VarDia7) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(n_nota_credito) as total from nota_credito where fecha_venta ='" & (VarDia7) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(n_nota_debito) as total from nota_debito where fecha_venta ='" & (VarDia7) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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
            SC.CommandText = "select count(nro_vale) as total from vale_cambio where fecha ='" & (VarDia7) & "' and estado <> 'ANULADA' and usuario_responsable <> 'SISTEMA'"
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





    End Sub

    Sub calcular_totales()
        'Dim total_millar As Integer
        'total_millar = txt_total_ventas.Text

        txt_total_ventas.Text = Format(Int(txt_total_ventas.Text), "###,###,###")




        txt_total_doc.Text = Val(lbl_total_doc_8.Text) + Val(lbl_total_doc_9.Text) + Val(lbl_total_doc_10.Text) + Val(lbl_total_doc_11.Text) + Val(lbl_total_doc_12.Text) + Val(lbl_total_doc_13.Text) + Val(lbl_total_doc_14.Text)




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
        If (contador > 30) Then
            contador = 0
            btn_mostrar.PerformClick()
        End If
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus

    End Sub

    Private Sub lbl_mensaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_mensaje.Click

    End Sub


End Class