Imports System.Net.Mail
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class Form_historial_de_cuenta
    Dim total_registros As Integer
    Dim peso As String
    Dim pesos As String
    Dim mifecha2 As String

    Dim message As New MailMessage

    Dim smtp As New SmtpClient
    Private Sub Form_historial_de_cuenta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_historial_de_cuenta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_historial_de_cuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    'actualiza la tabla de clientes.
    'Sub actualizar_tabla_clientes()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from clientes"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    conexion.Close()
    'End Sub

    'funcion para realizar el desglose en palabras de la cifra que se indica en el txt_total.
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

    'va generando el calculo del neto iva total y descuento del documento, es decir de la suma de todos los productos ingresados.
    Sub calcular_totales()
        Dim totalgrilla As Integer


        '//Calcular el total 
        txt_total.Text = 0
        For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1
            totalgrilla = Val(grilla_estado_de_cuenta.Rows(i).Cells(3).Value.ToString)
            txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        Next

        '//Calcular el saldo

        peso = " PESOS"
        If CInt(txt_total.Text) = 1000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & " DE PESOS"
        ElseIf CInt(txt_total.Text) = 2000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 3000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 4000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 5000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 6000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 7000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 8000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 9000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 10000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 11000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 12000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 13000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 14000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 15000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 16000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 17000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 18000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 19000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 20000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 21000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 22000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 23000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 24000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 25000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 26000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 27000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 28000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 29000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 30000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 33000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 34000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 35000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 36000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 37000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 38000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 39000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 40000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 41000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) < 0 Then
            txt_desglose.Text = "SALDO A FAVOR"
        Else
            txt_desglose.Text = Num2Text(txt_total.Text) & peso
        End If







    End Sub

    'sub para llenar el combo rut.
    'Sub llenar_combo_rut()
    '    combo_rut.Items.Clear()
    '    actualizar_tabla_clientes()

    '    total_registros = DS.Tables(DT.TableName).Rows.Count()
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        For i = 0 To total_registros - 1
    '            combo_rut.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("rut"))
    '        Next
    '    End If
    '    conexion.Close()
    'End Sub

    'sub para mostrar los datos de los clientes.
    Sub mostrar_datos_clientes()
        If txt_rut_cliente.Text <> "" Then
            grilla_estado_de_cuenta_final.Rows.Clear()

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from clientes where rut_cliente ='" & (txt_rut_cliente.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_codigo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
                txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")

                grilla_estado_de_cuenta.DataSource = Nothing
                grilla_estado_de_cuenta_final.Rows.Clear()

                conexion.Close()

            ElseIf DS.Tables(DT.TableName).Rows.Count < 1 Then
                MsgBox("CLIENTE NO ENCONTRADO", 0 + 16, "ERROR")
                txt_rut_cliente.Focus()
                conexion.Close()
            End If
            conexion.Close()
        End If










        'If DS.Tables(DT.TableName).Rows.Count = 1 Then
        '    txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
        '    txt_codigo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
        '    txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
        '    txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
        '    txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
        '    txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")

        '    conexion.Close()
        '    Exit Sub
        'ElseIf DS.Tables(DT.TableName).Rows.Count > 1 Then
        '    conexion.Close()
        '    Form_seleccionar_cuenta_estado_de_cuenta.Show()
        '    Me.Enabled = False
        '    Exit Sub
        'ElseIf DS.Tables(DT.TableName).Rows.Count < 1 Then
        '    MsgBox("CLIENTE NO ENCONTRADO", 0 + 16, "ERROR")
        '    txt_rut_cliente.Focus()
        '    conexion.Close()














    End Sub

    'sub para generar el filtrado que se produce en el combo rut. 
    'Sub mostrar_rut()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from clientes where rut like '" & (txt_rut.Text & "%") & "'"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        combo_rut.Items.Clear()
    '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
    '            combo_rut.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("rut"))
    '        Next
    '    End If
    '    conexion.Close()
    'End Sub

    'carga todas las facturas y notas de credito que tnga a su favor,
    Sub mostrar_malla()



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion

        SC.CommandText = "select * from creditos  where  rut_cliente = '" & (txt_rut_cliente.Text) & "' and ESTADO<> 'ANULADA' order by fecha_venta asc,  codigo_afecta asc"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_estado_de_cuenta.Rows.Clear()
        grilla_estado_de_cuenta.Columns.Clear()
        grilla_estado_de_cuenta.Columns.Add("n_creditos", "NRO.")
        grilla_estado_de_cuenta.Columns.Add("tipo_detalle", "TIPO")
        grilla_estado_de_cuenta.Columns.Add("fecha_venta", "FECHA")
        grilla_estado_de_cuenta.Columns.Add("total", "TOTAL")
        ' grilla_estado_de_cuenta.Columns.Add("saldo", "SALDO")
        grilla_estado_de_cuenta.Columns.Add("saldo", "SALDO FINAL")

        Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            txt_total_deuda.Text = 0
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_creditos"), _
                                              DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("fecha_venta"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("saldo"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("saldo") + Val(txt_total_deuda.Text))

                txt_total_deuda.Text = DS.Tables(DT.TableName).Rows(i).Item("saldo")

            Next


            Dim Varcoddocumento As Integer
            Dim VarTipo As String
            Dim Varfecha As String
            Dim vartotal As Integer
            Dim varsaldo As Integer
            'Dim totalsaldo As Integer
            'Dim vartotalsaldo As Integer
            txt_total_deuda.Text = "0"

            For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1

                Varcoddocumento = grilla_estado_de_cuenta.Rows(i).Cells(0).Value.ToString
                VarTipo = grilla_estado_de_cuenta.Rows(i).Cells(1).Value.ToString
                Varfecha = grilla_estado_de_cuenta.Rows(i).Cells(2).Value
                vartotal = grilla_estado_de_cuenta.Rows(i).Cells(3).Value.ToString
                varsaldo = grilla_estado_de_cuenta.Rows(i).Cells(4).Value.ToString


                ' For e = 0 To migrilla.Rows.Count - 1

                Dim descripcion_tipo As String
                descripcion_tipo = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")

                If descripcion_tipo.Length > 15 Then
                    descripcion_tipo = descripcion_tipo.Substring(0, 15)
                End If

                If descripcion_tipo = "NOTA DE CREDITO" Then

                    If VarTipo <> "NOTA DE CREDITO SIN IMPUTAR" Then


                        VarTipo = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")


                        varsaldo = 0
                    Else
                        varsaldo = DS.Tables(DT.TableName).Rows(i).Item("saldo")
                    End If
                End If






                descripcion_tipo = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")
                If descripcion_tipo.Length > 5 Then
                    descripcion_tipo = descripcion_tipo.Substring(0, 5)
                End If

                If descripcion_tipo = "ABONO" Then

                    If VarTipo <> "ABONO SIN IMPUTAR" Then

                        VarTipo = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")





                        If descripcion_tipo = "ABONO" Then
                            varsaldo = 0
                        Else
                            varsaldo = DS.Tables(DT.TableName).Rows(i).Item("saldo")
                        End If
                    End If
                End If


                txt_total_deuda.Text = Val(txt_total_deuda.Text) + Val(DS.Tables(DT.TableName).Rows(i).Item("total"))

                grilla_estado_de_cuenta_final.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_creditos"), _
                                          DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle"), _
                                           DS.Tables(DT.TableName).Rows(i).Item("fecha_venta"), _
                                            DS.Tables(DT.TableName).Rows(i).Item("saldo"), _
                                                txt_total_deuda.Text, _
            txt_total_deuda.Text)

            Next



            grilla_estado_de_cuenta_final.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta_final.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_estado_de_cuenta_final.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta_final.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            grilla_estado_de_cuenta.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            grilla_estado_de_cuenta.Columns(0).Width = 100
            grilla_estado_de_cuenta.Columns(1).Width = 200
            grilla_estado_de_cuenta.Columns(2).Width = 100
            grilla_estado_de_cuenta.Columns(3).Width = 100
            grilla_estado_de_cuenta.Columns(4).Width = 100

            txt_total_deuda.Text = Format(Int(txt_total_deuda.Text), "###,###,###")

        End If


    End Sub

    Sub limpiar_datos_clientes()
        ' lbl_rut.Text = "nada"
        'txt_rut_cliente.Text = ""
        'txt_rut_cliente.Text = ""
        txt_nombre_cliente.Text = ""
        txt_direccion_cliente.Text = ""
        txt_codigo_cliente.Text = ""
        txt_ciudad_cliente.Text = ""
        ' ¿ txt_giro_cliente.Text = ""
        '  txt_comun_cliente.Text = ""
        txt_correo_cliente.Text = ""
        txt_telefono.Text = ""
        'txt_folio.Text = ""


        grilla_estado_de_cuenta_final.DataSource = Nothing
        grilla_estado_de_cuenta_final.Rows.Clear()

        txt_total_deuda.Text = ""
    End Sub

    Sub guion_rut_cliente()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut_cliente.Text
        If rut_cliente.Length > 2 Then

            guion = rut_cliente(rut_cliente.Length - 2).ToString()

            If guion <> "-" Then
                Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                rut_cliente = rut_cliente & "-" & fin_rut
                txt_rut_cliente.Text = rut_cliente
            End If
        End If
    End Sub

    'carga todas las facturas y notas de credito que tnga a su favor,
    Sub mostrar_malla_saldo()
        conexion.Close()
        DS1.Tables.Clear()
        DT1.Rows.Clear()
        DT1.Columns.Clear()
        DS1.Clear()
        conexion.Open()

        SC1.Connection = conexion
        SC1.CommandText = "select n_doc AS NUMERO, TIPO AS TIPO, fecha_venta AS FECHA, total AS TOTAL, total_saldo AS SALDO from estado_de_cuenta_temporal  where  rut = '" & (txt_rut_cliente.Text) & "' "
        DA1.SelectCommand = SC1
        DA1.Fill(DT1)
        DS1.Tables.Add(DT1)

        grilla_estado_de_cuenta.DataSource = DS1.Tables(DT1.TableName)
        conexion.Close()
    End Sub


    ' se graba el estado de cuenta mediante un ciclo for en una tabla temporal.
    Sub grabar_estado_cuenta()
        Dim Varcoddocumento As Integer
        Dim VarTipo As String
        Dim Varfecha As String
        Dim vartotal As Integer
        Dim varsaldo As Integer
        Dim totalsaldo As Integer
        Dim vartotalsaldo As Integer
        txt_total_saldo.Text = "0"


        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "delete from estado_de_cuenta_temporal"
        DA.SelectCommand = SC
        DA.Fill(DT)
        'conexion.Close()



        'SC.Connection = conexion
        'SC.CommandText = "delete from estado_de_cuenta_temporal"
        'DA.SelectCommand = SC
        'DA.Fill(DT)







        For i = 0 To grilla_estado_de_cuenta_final.Rows.Count - 1




            Varcoddocumento = grilla_estado_de_cuenta_final.Rows(i).Cells(0).Value.ToString
            VarTipo = grilla_estado_de_cuenta_final.Rows(i).Cells(1).Value.ToString
            Varfecha = grilla_estado_de_cuenta_final.Rows(i).Cells(2).Value
            vartotal = grilla_estado_de_cuenta_final.Rows(i).Cells(3).Value.ToString
            varsaldo = grilla_estado_de_cuenta_final.Rows(i).Cells(4).Value.ToString


            ' For e = 0 To migrilla.Rows.Count - 1

            totalsaldo = grilla_estado_de_cuenta_final.Rows(i).Cells(4).Value.ToString
            '   txt_total_saldo.Text = Val(txt_total_saldo.Text) + Val(totalsaldo)

            'Next
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            vartotalsaldo = grilla_estado_de_cuenta_final.Rows(i).Cells(4).Value.ToString
            SC.Connection = conexion
            SC.CommandText = "insert into estado_de_cuenta_temporal (rut, nombre, direccion, telefono,TIPO, deuda_total, n_doc, fecha_venta, total, deuda_saldo, desglose, total_saldo, ciudad) values('" & (txt_rut_cliente.Text) & "','" & (txt_nombre_cliente.Text) & "','" & (txt_direccion_cliente.Text) & "','" & (txt_telefono.Text) & "','" & (VarTipo) & "','" & (txt_total_deuda.Text) & "','" & (Varcoddocumento) & "','" & (Varfecha) & "','" & (vartotal) & "','" & (varsaldo) & "','" & (txt_desglose.Text) & "','" & (totalsaldo) & "','" & (txt_ciudad_cliente.Text) & "')"
            '  SC.CommandText = "insert into estado_de_cuenta_temporal (                                                                                                                                          rut,                nombre,                                  direccion,                  telefono,              TIPO,                   deuda_total,                    n_doc,              fecha_venta,            total,      deuda_saldo,        desglose,                   total_saldo,                        ciudad) values('" & (txt_rut.Text) & "','" & (txt_nombre_cliente.Text) & "','" & (txt_direccion.Text) & "'," & (txt_telefono.Text) & ",'" & (VarTipo) & "'," & (txt_total.Text) & "," & (Varcoddocumento) & ",'" & (Varfecha) & "'," & (vartotal) & ",'" & (0) & "','" & (txt_desglose.Text) & "'," & (txt_total_saldo.Text) & ",'" & (txt_ciudad.Text) & "')"

            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()

            'DS.Tables.Clear()
            'DT.Rows.Clear()
            'DT.Columns.Clear()
            'DS.Clear()
            'conexion.Close()
        Next
        ' Next






        'Dim sql As String = "insert into tbl_imagenes(imagen)values(?imagen)"
        'cnn = New MySqlConnection(StrConexion)
        'Dim Comando As New MySqlCommand(sql, cnn)
        'Dim Imag As Byte()
        'Imag = Imagen_Bytes(Me.PictureBox1.Image)

        'Comando.Parameters.AddWithValue("?imagen", Imag)








    End Sub









    Private Sub combo_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If Char.IsControl(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub





    'se le otorga el valor del combo al texbox.
    'muetra los datos de los clientes.
    'muestra los documentos del cliente.
    'calcula el total.
    Private Sub combo_rut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        mostrar_datos_clientes()
        mostrar_malla()
        calcular_totales()
        grabar_estado_cuenta()
        mostrar_malla_saldo()

    End Sub

    'se llama al sub mostrar rut.
    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'mostrar_rut()
    End Sub

    Private Function ReturnDataSet() As DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ds As New DataSet


        dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
        dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("deuda_total", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("ciudad_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo_documento", GetType(String)))
        dt.Columns.Add(New DataColumn("nro_doc", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fecha_doc", GetType(String)))
        dt.Columns.Add(New DataColumn("total_doc", GetType(Integer)))
        dt.Columns.Add(New DataColumn("saldo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("desglose_palabras", GetType(String)))

        dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))




        Dim Varcoddocumento As String
        Dim VarTipo As String
        Dim Varfecha As String
        Dim vartotal As Integer
        Dim varsaldo As Integer

        For i = 0 To grilla_estado_de_cuenta_final.Rows.Count - 1


            Varcoddocumento = grilla_estado_de_cuenta_final.Rows(i).Cells(0).Value.ToString
            VarTipo = grilla_estado_de_cuenta_final.Rows(i).Cells(1).Value.ToString
            Varfecha = grilla_estado_de_cuenta_final.Rows(i).Cells(2).Value
            vartotal = grilla_estado_de_cuenta_final.Rows(i).Cells(3).Value.ToString
            varsaldo = grilla_estado_de_cuenta_final.Rows(i).Cells(4).Value.ToString

            dr = dt.NewRow()



            Try
                dr("Imagen") = Imagen_reporte
            Catch
            End Try

            dr("nombre_empresa") = minombreempresa
            dr("giro_empresa") = migiroempresa
            dr("direccion_empresa") = midireccionempresa
            dr("comuna_empresa") = micomunaempresa
            dr("telefono_empresa") = mitelefonoempresa
            dr("correo_empresa") = micorreoempresa
            dr("rut_empresa") = mirutempresa
            dr("nombre_cliente") = txt_nombre_cliente.Text
            dr("rut_cliente") = txt_rut_cliente.Text
            dr("deuda_total") = txt_total_deuda.Text
            dr("direccion_cliente") = txt_direccion_cliente.Text
            dr("telefono_cliente") = txt_telefono.Text
            dr("ciudad_cliente") = txt_ciudad_cliente.Text
            dr("desglose_palabras") = txt_desglose.Text
            dr("tipo_documento") = VarTipo
            dr("nro_doc") = Varcoddocumento
            dr("fecha_doc") = Varfecha
            dr("total_doc") = vartotal
            dr("saldo") = varsaldo
            dt.Rows.Add(dr)




        Next





        ds.Tables.Add(dt)
        ds.Tables(0).TableName = "Imagenes"

        Dim iDS As New dsImagenes
        iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
        Return iDS
    End Function

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

    'veridica que la grilla no este vacia, si esta llena llama al sub grabar estado de cuenta, e imprime el documento.
    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click






        Dim mensaje As String = ""
        If grilla_estado_de_cuenta.Rows.Count = 0 Then mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
        If txt_rut_cliente.Text = "" Then mensaje = "CAMPO RUT VACIO, FAVOR LLENAR" + Chr(13) & mensaje

        If mensaje <> "" Then
            MsgBox(mensaje, MsgBoxStyle.OkOnly)
        Else
            lbl_mensaje.Visible = True
            Me.Enabled = False






            Try


                Dim iReporte As New form_informe_estado_de_cuenta_personalizado

                Dim rpt As New Crystal_estado_de_cuenta_personalizado

                rpt.Load()
                rpt.SetDataSource(ReturnDataSet)
                rpt.Refresh()

                iReporte.Reporte = rpt
                iReporte.ShowDialog()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try







            lbl_mensaje.Visible = False
            Me.Enabled = True

        End If

    End Sub



    'se llama al sub limpiar la pantalla.
    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()
        End If
    End Sub

    'limpia la pantalla.
    Sub limpiar()
        txt_rut_cliente.Text = ""
        txt_nombre_cliente.Text = ""
        txt_direccion_cliente.Text = ""
        txt_telefono.Text = ""
        txt_total.Text = ""
        txt_codigo_cliente.Text = ""
        txt_total_deuda.Text = ""
        txt_ciudad_cliente.Text = ""
        txt_desglose.Text = ""
        'grilla_estado_de_cuenta.DataSource = Nothing
        grilla_estado_de_cuenta_final.Rows.Clear()
    End Sub

    'salir de la pantalla.
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Form_menu_principal.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub



    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_cliente.KeyPress

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



        limpiar_datos_clientes()


        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            limpiar_datos_clientes()
            grilla_estado_de_cuenta_final.Rows.Clear()
            guion_rut_cliente()
            mostrar_datos_clientes()
            mostrar_malla()
            calcular_totales()
            'grabar_estado_cuenta()
            'mostrar_malla_saldo()
        End If
    End Sub

    Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.GotFocus
        txt_rut_cliente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.LostFocus
        txt_rut_cliente.BackColor = Color.White
    End Sub

    Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        btn_imprimir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_enviar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_enviar.LostFocus
        btn_enviar.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub btn_enviar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_enviar.GotFocus
        btn_enviar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub txt_rut_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.TextChanged

    End Sub

    Private Sub btn_enviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enviar.Click




        If grilla_estado_de_cuenta.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut_cliente.Focus()
            Exit Sub
        End If


        If txt_rut_cliente.Text = "" Then
            MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut_cliente.Focus()
            Exit Sub
        End If

        If txt_nombre_cliente.Text = "" Then
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nombre_cliente.Focus()
            Exit Sub
        End If





        lbl_mensaje.Visible = True
        Me.Enabled = False









        Try


            Dim iReporte As New form_informe_estado_de_cuenta_personalizado

            Dim rpt As New Crystal_estado_de_cuenta_personalizado

            rpt.Load()
            rpt.SetDataSource(ReturnDataSet)
            rpt.Refresh()

            iReporte.Reporte = rpt
            iReporte.ShowDialog()
       









            If Directory.Exists("C:\Estados de cuenta") = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory("C:\Estados de cuenta")
            End If



            Try
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
                Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

                CrDiskFileDestinationOptions.DiskFileName = "C:\Estados de cuenta\" & "ESTADO DE CUENTA AL DIA " & txt_rut_cliente.Text & " " & dtp_fecha.Text & ".pdf"
                CrExportOptions = rpt.ExportOptions

                With CrExportOptions
                    .ExportDestinationType = ExportDestinationType.DiskFile
                    .ExportFormatType = ExportFormatType.PortableDocFormat
                    .DestinationOptions = CrDiskFileDestinationOptions
                    .FormatOptions = CrFormatTypeOptions
                End With

                rpt.Export()

            Catch ex As Exception
                MsgBox("EL ESTADO DE CUENTA AL DIA " & dtp_fecha.Text & " AUN ESTA SIENDO ENVIADO", MsgBoxStyle.Critical, "INFORMACION")
                Me.Enabled = True
                lbl_mensaje.Visible = False
                Exit Sub
            End Try

            '  mostrar_datos_cotizacion()






            Dim adjunto As System.Net.Mail.Attachment
            adjunto = Nothing
            adjunto = New System.Net.Mail.Attachment("C:\Estados de cuenta\" & "ESTADO DE CUENTA AL DIA " & txt_rut_cliente.Text & " " & dtp_fecha.Text & ".pdf")
            message.From = New MailAddress(micorreoempresa)

            '  message.IsBodyHtml = True

            Try
                message.To.Add(txt_correo_cliente.Text)
            Catch ex As Exception
                MsgBox("EL CORREO ELECTRONICO ESPECIFICADO NO TIENE LA FORMA OBLIGATORIA PARA UNA DIRECCION DE MAIL", MsgBoxStyle.Critical, "INFORMACION")
                Me.Enabled = True
                lbl_mensaje.Visible = False
                Exit Sub
            End Try

            '  message.IsBodyHtml = <HTML><BODY>Dear John:....</BODY></HTML>





            message.Body = "Señor(es): " & txt_nombre_cliente.Text & vbNewLine & _
            vbNewLine & _
            "Adjunto le enviamos el estado de cuenta actualizado a la fecha " & dtp_fecha.Text & ", por un monto de $" & txt_total_deuda.Text & ". " & vbNewLine & _
            vbNewLine & _
            "Recordamos a usted que el crédito otorgado es de 30 días a contar de la fecha de facturación, por lo tanto, el no pago de su facturas en la fecha indicada, dará origen al bloqueo de la cuenta, por lo que el sistema no dejara generar una nueva venta bajo condición de crédito y solo podrán efectuarse ventas con efectivo cheques contra-entrega." & vbNewLine & _
            vbNewLine & _
            "Le saluda atentamente" & vbNewLine & vbNewLine & minombre & vbNewLine & mitelefono & vbNewLine & miarea & vbNewLine & minombreempresa
            message.Subject = "ESTADO DE CUENTA ACTUALIZADO AL DIA " & dtp_fecha.Text
            message.Priority = MailPriority.Normal
            message.Attachments.Add(adjunto)




            smtp.EnableSsl = True
            smtp.Port = "587"
            smtp.Host = "smtp.gmail.com"
            smtp.Credentials = New Net.NetworkCredential(micorreoempresa, miclavecorreoempresa)
            smtp.Send(message)
            Me.Enabled = True
            lbl_mensaje.Visible = False
            limpiar()
            MsgBox("EL CORREO FUE ENVIADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        lbl_mensaje.Visible = False
        Me.Enabled = True

    End Sub

    Private Sub btn_buscar_clientes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.GotFocus
        btn_buscar_clientes.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_clientes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.LostFocus
        btn_buscar_clientes.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub btn_buscar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.Click

        Form_buscador_clientes_estado_de_cuenta.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nro_doc As String

        nro_doc = grilla_estado_de_cuenta_final.CurrentRow.Cells(0).Value

        SC.Connection = conexion
        SC.CommandText = "DELETE FROM creditos WHERE `n_creditos`='" & (nro_doc) & "' "
        DA.SelectCommand = SC
        DA.Fill(DT)


    End Sub

    Private Sub txt_rut_cliente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rut_cliente.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            Form_buscador_clientes_estado_de_cuenta.Show()
            Me.Enabled = False
        End If
    End Sub
End Class