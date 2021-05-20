Imports System.Drawing.Printing
Imports System.Math
Imports System.Drawing.Drawing2D
Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Resources

Public Class Form_facturacion
    Dim total_registros As Integer
    Dim varnumfactura As Integer
    Dim peso As String
    Dim pesos As String
    Dim desc As Integer
    Private WithEvents Pd As New PrintDocument
    'Dim mifecha2 As String
    'Dim mifecha4 As String
    Dim mifecha6 As String
    Dim fecha_impresion As String
    'Dim fecha_ultimo_dia_mes As Date

    Private Sub Form_facturacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_facturacion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_facturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'dtp_desde.Value = dtp_desde.Value.AddMonths(Val(-1))
        llenar_combo_rut()
        crear_numero_factura()
        cargar_logo()
        grilla_facturacion.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)
        If grilla_facturacion.Rows.Count <> 0 Then
            grilla_facturacion.Columns(8).Width = 150
        End If
        fecha_impresion = "NO"
        Dim fecha As New DateTime(Date.Now.Year, Date.Now.Month, 1)
        'dtp_desde.Value = fecha
        'dtp_hasta.Value = dtp_desde.Value.AddMonths(Val(+1))
        'dtp_hasta.Value = dtp_desde.Value.AddDays(Val(-1))
        'dtp_desde.Value = dtp_desde.Value.AddMonths(Val(-1))
        'dtp_fecha.Value = dtp_hasta.Value
        'fecha_ultimo_dia_mes = dtp_hasta.Value

        Combo_año.Text = Year(Now)
        txt_mes.Text = Month(Now)
        seleccionar_mes()

        grilla_facturacion.Columns(0).ReadOnly = True
        grilla_facturacion.Columns(1).ReadOnly = True
        grilla_facturacion.Columns(2).ReadOnly = True
        grilla_facturacion.Columns(3).ReadOnly = True
        grilla_facturacion.Columns(4).ReadOnly = True
        grilla_facturacion.Columns(5).ReadOnly = True
        grilla_facturacion.Columns(6).ReadOnly = True
        grilla_facturacion.Columns(7).ReadOnly = True
        grilla_facturacion.Columns(8).ReadOnly = True
        grilla_facturacion.Columns(9).ReadOnly = False

    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub
    Sub fecha()
        'Dim mifecha As Date
        'mifecha = dtp_desde.Text
        'mifecha2 = mifecha.ToString("yyy-MM-dd")

        'Dim mifecha3 As Date
        'mifecha3 = dtp_hasta.Text
        'mifecha4 = mifecha3.ToString("yyy-MM-dd")

        Dim mifecha5 As Date
        mifecha5 = dtp_fecha.Text
        mifecha6 = mifecha5.ToString("yyy-MM-dd")
    End Sub

    'sub para llenar el combo rut de clientes en BOLETAs facturas y cotizaciones.
    Sub llenar_combo_rut()
        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()

        SC2.Connection = conexion
        SC2.CommandText = "select rut_cliente from  clientes where estado_cuenta <> 'SIN CUENTA' group by rut_cliente ORDER BY rut_cliente"

        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)

        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                combo_rut.Items.Add(DS2.Tables(DT2.TableName).Rows(i).Item("rut_cliente"))
            Next
            conexion.Close()
        End If
    End Sub

    'muestra los datos del cliente seleccionado.
    Sub mostrar_datos_clientes()
        If combo_rut.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from clientes where rut_cliente ='" & (combo_rut.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count = 1 Then
                txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
                txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_descuento_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
                txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
                txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_cliente")
                txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
                txt_telefono_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                txt_folio_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
                txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                conexion.Close()

                mostrar_malla()
                calcular_totales()
                recuperar_conexion_actual()
                Exit Sub

            ElseIf DS.Tables(DT.TableName).Rows.Count > 1 Then
                conexion.Close()
                Form_seleccionar_cuenta_facturacion.Show()
                Me.Enabled = False
                Exit Sub
            ElseIf DS.Tables(DT.TableName).Rows.Count < 1 Then
                MsgBox("CLIENTE NO ENCONTRADO", 0 + 16, "ERROR")
                txt_rut_cliente.Focus()
                conexion.Close()
            End If
        End If
    End Sub

    Sub limpiar_datos_clientes()
        'txt_rut_cliente.Text = ""
        txt_nombre_cliente.Text = ""
        txt_direccion_cliente.Text = ""
        txt_cod_cliente.Text = ""
        txt_descuento_cliente.Text = ""
        txt_porcentaje_desc.Text = ""
        txt_giro_cliente.Text = ""
        txt_comuna_cliente.Text = ""
        txt_telefono_cliente.Text = ""
        txt_folio_cliente.Text = ""
        txt_correo_cliente.Text = ""
        txt_ciudad_cliente.Text = ""
    End Sub

    'va generando el calculo del neto iva total y descuento del documento, es decir de la suma de todos los productos ingresados.
    Sub calcular_totales()
        Dim netogrilla As Integer
        Dim ivagrilla As Integer
        Dim subtotalgrilla As Integer

        '//Calcular el total neto
        txt_neto.Text = 0
        For i = 0 To grilla_facturacion.Rows.Count - 1
            netogrilla = Val(grilla_facturacion.Rows(i).Cells(4).Value.ToString)
            txt_neto.Text = Val(txt_neto.Text) + Val(netogrilla)
        Next

        '//Calcular el total iva
        txt_iva.Text = 0
        For i = 0 To grilla_facturacion.Rows.Count - 1
            ivagrilla = Val(grilla_facturacion.Rows(i).Cells(5).Value.ToString)
            txt_iva.Text = Val(txt_iva.Text) + Val(ivagrilla)
        Next

        '//Calcular el sub-total 
        txt_sub_total.Text = 0
        For i = 0 To grilla_facturacion.Rows.Count - 1
            subtotalgrilla = Val(grilla_facturacion.Rows(i).Cells(7).Value.ToString)
            txt_sub_total.Text = Val(txt_sub_total.Text) + Val(subtotalgrilla)
        Next

        '//Calcular el descuento
        txt_descuento.Text = 0
        txt_descuento_cliente.Text = 0
        txt_descuento.Text = CInt(CInt(txt_descuento_cliente.Text) * CInt(txt_sub_total.Text) / 100)

        '//Calcular el total general
        txt_total.Text = 0

        txt_total.Text = (txt_sub_total.Text) - (txt_descuento.Text)

        Dim descuento_porcentaje As Integer
        Dim porcentaje_desc As Integer

        If txt_porcentaje_desc.Text = "" Then
            porcentaje_desc = 0
        Else
            porcentaje_desc = txt_porcentaje_desc.Text
        End If

        descuento_porcentaje = ((txt_total.Text) * porcentaje_desc) / 100
        txt_descuento.Text = descuento_porcentaje

        txt_total.Text = Int(txt_sub_total.Text) - Int(txt_descuento.Text)

        Dim iva_valor As String

        iva_valor = valor_iva / 100 + 1
        txt_neto.Text = Round(txt_total.Text / iva_valor)
        txt_iva.Text = (((txt_neto.Text) * valor_iva) / 100)
        txt_iva.Text = (txt_total.Text) - (txt_neto.Text)

        peso = " PESOS"
        If CInt(txt_total.Text) < 1000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & peso
        Else
            txt_desglose.Text = Num2Text(txt_total.Text)
        End If

        peso = " PESOS"
        If CInt(txt_total.Text) = 1000000 Then
            desglose_valor = Num2Text(txt_total.Text) & " DE PESOS"
        ElseIf CInt(txt_total.Text) = 2000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 3000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 4000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 5000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 6000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 7000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 8000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 9000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 10000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 11000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 12000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 13000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 14000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 15000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 16000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 17000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 18000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 19000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 20000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 21000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 22000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 23000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 24000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 25000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 26000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 27000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 28000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 29000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 30000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        Else
            desglose_valor = Num2Text(txt_total.Text) & peso
        End If

        If grilla_facturacion.Rows.Count <> 0 Then
            txt_item.Text = grilla_facturacion.Rows.Count
        End If

        If txt_sub_total.Text = "" Or txt_sub_total.Text = "0" Then
            txt_sub_total_millar.Text = "0"
        Else
            txt_sub_total_millar.Text = Format(Int(txt_sub_total.Text), "###,###,###")
        End If
        If txt_descuento.Text = "" Or txt_descuento.Text = "0" Then
            txt_desc_millar.Text = "0"
        Else
            txt_desc_millar.Text = Format(Int(txt_descuento.Text), "###,###,###")
        End If
        If txt_neto.Text = "" Or txt_neto.Text = "0" Then
            txt_neto_millar.Text = "0"
        Else
            txt_neto_millar.Text = Format(Int(txt_neto.Text), "###,###,###")
        End If
        If txt_iva.Text = "" Or txt_iva.Text = "0" Then
            txt_iva_millar.Text = "0"
        Else
            txt_iva_millar.Text = Format(Int(txt_iva.Text), "###,###,###")
        End If
        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total_millar.Text = "0"
        Else
            txt_total_millar.Text = Format(Int(txt_total.Text), "###,###,###")
        End If
    End Sub

    'genera la busqueda directa en el combo del rut que se va digitando.
    Sub mostrar_rut()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from guia where rut like '" & (combo_rut.Text & "%") & "' and estado='" & ("SIN FACTURAR") & "' AND CONDICIONES <> 'TRASLADO' "
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            combo_rut.Items.Clear()
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                combo_rut.Items.Add(DS.Tables(DT.TableName).Rows(i).Item("rut"))
            Next
        End If
        conexion.Close()
    End Sub

    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mostrar_rut()
    End Sub

    'funcion para deglosar en palabras la deuda.
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

    Sub mostrar_malla()
        fecha()
        If mirutempresa = "87686300-6" Then
            Dim nombre_servidor As String
            Dim nombre_servidor_remoto As String
            Dim base_de_datos As String
            Dim clave_base_de_datos As String
            Dim usuario As String
            Dim recinto As String
            Dim rut_empresa As String

            For u = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1
                nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(u).Cells(0).Value.ToString
                nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(u).Cells(1).Value.ToString
                base_de_datos = Form_menu_principal.grilla_conexiones.Rows(u).Cells(2).Value.ToString
                clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(u).Cells(3).Value.ToString
                usuario = Form_menu_principal.grilla_conexiones.Rows(u).Cells(4).Value.ToString
                recinto = Form_menu_principal.grilla_conexiones.Rows(u).Cells(5).Value.ToString
                rut_empresa = Form_menu_principal.grilla_conexiones.Rows(u).Cells(6).Value.ToString
                'recinto = Trim(Replace(recinto, "'", "´"))


                Try
                    conexion.Close()
                    conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                    conexion.Open()
                    conexion.Close()
                Catch
                    conexion.Close()
                    conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                End Try

                'conexion.Close()
                'conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"

                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                SC.Connection = conexion
                'SC.CommandText = "select n_guia , tipo , fecha_venta, descuento , neto , iva, subtotal , total, recinto from guia  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and  CODIGO_cliente = '" & (txt_cod_cliente.Text) & "' and estado = 'SIN FACTURAR' AND CONDICIONES <> 'TRASLADO' "
                SC.CommandText = "select n_guia , tipo , fecha_venta, descuento , neto , iva, subtotal , total, recinto, orden from guia  where year(fecha_venta)='" & (Combo_año.Text) & "' and month(fecha_venta)= '" & (txt_mes.Text) & "' and  codigo_cliente = '" & (txt_cod_cliente.Text) & "' and estado = 'SIN FACTURAR' AND CONDICIONES <> 'TRASLADO' "

                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                ' grilla_facturacion.Rows.Clear()

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                        Dim fecha_guia As String
                        fecha_guia = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                        grilla_facturacion.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_guia"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("tipo"), _
                                                      fecha_guia, _
                                                       DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("subtotal"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("recinto"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("orden"))
                    Next

                    If grilla_facturacion.Rows.Count <> 0 Then
                        If grilla_facturacion.Columns(0).Width = 110 Then
                            grilla_facturacion.Columns(0).Width = 109
                        Else
                            grilla_facturacion.Columns(0).Width = 110
                        End If
                    End If
                End If
                txt_item.Text = grilla_facturacion.Rows.Count

                Try

                Catch mierror As MySqlException
                Catch mierror As MissingManifestResourceException
                End Try
            Next

            recuperar_conexion_actual()


        End If



        If mirutempresa <> "87686300-6" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            'SC.CommandText = "select n_guia , TIPO , fecha_venta, descuento , neto , iva, subtotal , total, recinto from guia  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and  CODIGO_cliente = '" & (txt_cod_cliente.Text) & "' and estado = 'SIN FACTURAR' AND CONDICIONES <> 'TRASLADO' "
            SC.CommandText = "select n_guia , TIPO , fecha_venta, descuento , neto , iva, subtotal , total, recinto, orden from guia  where year(fecha_venta)='" & (Combo_año.Text) & "' and month(fecha_venta)= '" & (txt_mes.Text) & "' and  codigo_cliente = '" & (txt_cod_cliente.Text) & "' and estado = 'SIN FACTURAR' AND CONDICIONES <> 'TRASLADO' "
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            ' grilla_facturacion.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim fecha_guia As String
                    fecha_guia = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    grilla_facturacion.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_guia"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("tipo"), _
                                                  fecha_guia, _
                                                   DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("subtotal"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("recinto"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("orden"))
                Next

                If grilla_facturacion.Rows.Count <> 0 Then
                    If grilla_facturacion.Columns(0).Width = 110 Then
                        grilla_facturacion.Columns(0).Width = 109
                    Else
                        grilla_facturacion.Columns(0).Width = 110
                    End If
                End If
            End If
            txt_item.Text = grilla_facturacion.Rows.Count

        End If

        grilla_facturacion.Columns(0).ReadOnly = True
        grilla_facturacion.Columns(1).ReadOnly = True
        grilla_facturacion.Columns(2).ReadOnly = True
        grilla_facturacion.Columns(3).ReadOnly = True
        grilla_facturacion.Columns(4).ReadOnly = True
        grilla_facturacion.Columns(5).ReadOnly = True
        grilla_facturacion.Columns(6).ReadOnly = True
        grilla_facturacion.Columns(7).ReadOnly = True
        grilla_facturacion.Columns(8).ReadOnly = True
        grilla_facturacion.Columns(9).ReadOnly = False
    End Sub

    'creamos el numero de la factura de credito.
    Sub crear_numero_factura()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(cod_auto) as cod_auto from factura where tipo_impresion <> 'DIGITADA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumfactura = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                'txt_factura.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_factura.Text = 1
            Exit Sub
        End Try

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select n_factura from factura where cod_auto='" & (varnumfactura) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumfactura = DS.Tables(DT.TableName).Rows(0).Item("n_factura")
                txt_factura.Text = varnumfactura + 1
            End If
        Catch err As InvalidCastException
            txt_factura.Text = 1
        End Try
        conexion.Close()
        Exit Sub
    End Sub

    ' graba los datos generales de la factura.
    Sub grabar_factura()
        Dim tipo_impresion As String

        If estado_factura_electronica = "SI" Then
            tipo_impresion = "ELECTRONICA"
        Else
            tipo_impresion = "MANUAL"
        End If

        dtp_vencimiento.CustomFormat = "yyy-MM-dd"
        dtp_vencimiento.Value = dtp_fecha.Value.AddMonths(Val(+1))

        SC.Connection = conexion
        SC.CommandText = "insert into factura (n_factura, tipo, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable, rut_retira, nombre_retira, recinto, orden, hora, porcentaje_desc, tipo_impresion, pie, condicion_de_pago_pie, comision) values (" & (txt_factura.Text) & ",'" & ("FACTURA DE CREDITO") & "', '" & (combo_rut.Text) & "','" & (txt_cod_cliente.Text) & "','" & (mifecha6) & "'," & (txt_descuento.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ",'" & ("CREDITO") & "', '" & ("EMITIDA") & "',  '" & ("SISTEMA") & "','-','-','" & (mirecintoempresa) & "','" & (txt_nro_orden_de_compra.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "','" & (tipo_impresion) & "', '0', '-'," & (txt_total.Text) & ")"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "insert into creditos (n_creditos, tipo, tipo_detalle, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, saldo, desglose, condiciones, estado, usuario_responsable, codigo_afecta, nombre_afecta, recinto, fecha_vencimiento, fecha_pago, numero_cuota, total_cuotas, interes, gastos_de_cobranza, pie, convenio) values (" & (txt_factura.Text) & ",'" & ("FACTURA") & "','" & ("FACTURA") & "','" & (txt_rut_cliente.Text) & "','" & (txt_cod_cliente.Text) & "','" & (mifecha6) & "'," & (txt_descuento.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & "," & (txt_total.Text) & ",'" & (txt_desglose.Text) & "','" & ("CREDITO") & "','" & ("EMITIDA") & "','" & ("SISTEMA") & "','" & (txt_factura.Text) & "','FACTURA', '" & (mirecintoempresa) & "', '" & (dtp_vencimiento.Text) & "', '0000-00-00', '1', '1', '0', '0', '0', '-')"
        DA.SelectCommand = SC
        DA.Fill(DT)
        Exit Sub
    End Sub

    'graba el detalle de la factura mediente un ciclo for.
    Sub grabar_detalle_factura()
        Dim VarNumeroguia As Integer
        Dim varTipo As String
        Dim varfecha As String
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarTotal As Integer
        Dim VarSubotal As Integer
        Dim VarRecinto As String
        Dim Varoc As String

        For i = 0 To grilla_facturacion.Rows.Count - 1
            VarNumeroguia = grilla_facturacion.Rows(i).Cells(0).Value
            varTipo = grilla_facturacion.Rows(i).Cells(1).Value
            varfecha = grilla_facturacion.Rows(i).Cells(2).Value
            VarDescuento = grilla_facturacion.Rows(i).Cells(3).Value
            VarNeto = grilla_facturacion.Rows(i).Cells(4).Value
            VarIva = grilla_facturacion.Rows(i).Cells(5).Value
            VarSubotal = grilla_facturacion.Rows(i).Cells(6).Value
            VarTotal = grilla_facturacion.Rows(i).Cells(7).Value
            VarRecinto = grilla_facturacion.Rows(i).Cells(8).Value
            Varoc = grilla_facturacion.Rows(i).Cells(9).Value

            SC.Connection = conexion
            SC.CommandText = "insert into detalle_factura (n_factura, cod_producto, detalle_nombre, cantidad, numero_tecnico, valor_unitario, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_factura.Text) & "," & (VarNumeroguia) & ",'" & (varTipo) & "','1','" & (varfecha) & "'," & (VarTotal) & ",'0', " & (VarDescuento) & ", " & (VarNeto) & "," & (VarIva) & "," & (VarSubotal) & "," & (VarTotal) & ")"
            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()

            Dim nombre_servidor As String
            Dim nombre_servidor_remoto As String
            Dim base_de_datos As String
            Dim clave_base_de_datos As String
            Dim usuario As String
            Dim recinto As String
            Dim rut_empresa As String

            For u = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1
                nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(u).Cells(0).Value.ToString
                nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(u).Cells(1).Value.ToString
                base_de_datos = Form_menu_principal.grilla_conexiones.Rows(u).Cells(2).Value.ToString
                clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(u).Cells(3).Value.ToString
                usuario = Form_menu_principal.grilla_conexiones.Rows(u).Cells(4).Value.ToString
                recinto = Form_menu_principal.grilla_conexiones.Rows(u).Cells(5).Value.ToString
                rut_empresa = Form_menu_principal.grilla_conexiones.Rows(u).Cells(6).Value.ToString

                recinto = Trim(Replace(recinto, "'", "´"))

                If VarRecinto = recinto Then


                    Try
                        conexion.Close()
                        conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                        conexion.Open()
                        conexion.Close()
                    Catch
                        conexion.Close()
                        conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                    End Try

                    'conexion.Close()
                    'conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"

                    SC.Connection = conexion
                    SC.CommandText = "update guia set estado = '" & ("FACTURADA") & "', orden='" & (Varoc) & "' where n_guia = '" & (VarNumeroguia) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)



                    'SC.Connection = conexion
                    'SC.CommandText = "UPDATE `guia` SET `orden`='789' WHERE `orden`='" & (Varoc) & "' and `n_guia`='" & (VarNumeroguia) & "' and `cod_auto`<>'0';"
                    'DA.SelectCommand = SC
                    'DA.Fill(DT)
                    Try

                    Catch

                    End Try
                End If
            Next
        Next

        recuperar_conexion_actual()

    End Sub

    Sub grabar_detalle_guia_temporal()
        Dim VarNumeroguia As Integer
        Dim varTipo As String
        Dim varfecha As String
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarTotal As Integer
        Dim VarSubotal As Integer
        Dim VarRecinto As Integer

        For i = 0 To grilla_facturacion.Rows.Count - 1
            VarNumeroguia = grilla_facturacion.Rows(i).Cells(0).Value
            varTipo = grilla_facturacion.Rows(i).Cells(1).Value
            varfecha = grilla_facturacion.Rows(i).Cells(2).Value
            VarDescuento = grilla_facturacion.Rows(i).Cells(3).Value
            VarNeto = grilla_facturacion.Rows(i).Cells(4).Value
            VarIva = grilla_facturacion.Rows(i).Cells(5).Value
            VarSubotal = grilla_facturacion.Rows(i).Cells(6).Value
            VarTotal = grilla_facturacion.Rows(i).Cells(7).Value
            VarRecinto = grilla_facturacion.Rows(i).Cells(8).Value

            SC.Connection = conexion
            SC.CommandText = "insert into guia_temporal (nro_guia, TIPO, fecha, descuento, neto, iva, subtotal, total, recinto) values('" & (VarNumeroguia) & "','" & (varTipo) & "','" & (varfecha) & "','" & (VarDescuento) & "','" & (VarNeto) & "','" & (VarIva) & "','" & (VarSubotal) & "','" & (VarTotal) & "', '" & (VarRecinto) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next
    End Sub

    'limpia la pantalla.
    Sub limpiar()
        txt_desglose.Text = ""
        txt_direccion_cliente.Text = ""
        txt_nombre_cliente.Text = ""
        txt_telefono_cliente.Text = ""
        combo_rut.Text = ""
        combo_rut.Text = ""
        txt_giro_cliente.Text = ""
        txt_comuna_cliente.Text = ""
        txt_factura.Text = ""
        txt_item.Text = ""
        txt_correo_cliente.Text = ""
        txt_ciudad_cliente.Text = ""
        txt_cod_cliente.Text = ""
        txt_folio_cliente.Text = ""
        txt_porcentaje_desc.Text = ""
        txt_descuento_cliente.Text = ""
        txt_descuento.Text = ""
        txt_total.Text = ""
        txt_sub_total.Text = ""
        txt_iva.Text = ""
        txt_neto.Text = ""
        txt_sub_total_millar.Text = ""
        txt_neto_millar.Text = ""
        txt_iva_millar.Text = ""
        txt_desc_millar.Text = ""
        txt_total_millar.Text = ""
        txt_nro_orden_de_compra.Text = ""
        txt_nro_orden_de_compra.Text = ""
        grilla_facturacion.Rows.Clear()
        crear_numero_factura()
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Form_menu_principal.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()
        End If
    End Sub

    Private Sub btn_nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nueva.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_listado_de_facturacion.Show()
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        If Int(txt_mes.Text) <> Int(dtp_fecha.Value.Month) Then
            MsgBox("EL MES CARGADO NO ES IGUAL AL DE LA FECHA A FACTURAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            dtp_fecha.Focus()
            Exit Sub
        End If

        If fecha_impresion = "NO" Then
            Dim valormensaje As Integer
            valormensaje = MsgBox("¿ESTAS SEGURO QUE LA FECHA DE EMISION ES: " & dtp_fecha.Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
            If valormensaje = vbYes Then
                fecha_impresion = "SI"
            Else
                Exit Sub
            End If
        End If

        If grilla_facturacion.Rows.Count = 0 Then
            MsgBox("MALLA DE GUIAS VACÍA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_rut.Focus()
            Exit Sub
        End If

        If estado_factura_electronica = "NO" Then
            With Pd.PrinterSettings
                ' Especifico el nombre de la impresora 
                ' por donde deseo imprimir. 
                .PrinterName = impresora_facturas
                ' Establezco el número de copias que se imprimirán 
                .Copies = 1
                ' Rango de páginas que se imprimirán 
                .PrintRange = PrintRange.AllPages
                If .IsValid Then
                    Me.Enabled = False
                    Me.crear_numero_factura()
                    Me.grabar_factura()
                    Me.Pd.PrintController = New StandardPrintController
                    Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 1100)
                    Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                    Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                    Pd.Print()
                    Me.grabar_detalle_factura()
                    Form_impreso_corectamente.Show()
                    Me.crear_archivo_plano()
                    Me.limpiar()
                    txt_condicion.Text = "CREDITO"
                    combo_rut.Focus()
                    Me.Enabled = True
                    Exit Sub
                Else
                    MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                    Me.Enabled = True
                    txt_condicion.Text = "CREDITO"
                    combo_rut.Focus()
                    Exit Sub
                End If
            End With
        Else
            Me.Enabled = False
            facturacion()
            txt_condicion.Text = "CREDITO"
            Me.Enabled = True
            combo_rut.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btn_quitar_lista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_lista.Click
        If grilla_facturacion.Rows.Count > 0 Then
            grilla_facturacion.Rows.Remove(grilla_facturacion.CurrentRow)
            calcular_totales()
            txt_item.Text = grilla_facturacion.Rows.Count
        End If
    End Sub

    Private Sub dtp1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar_datos_clientes()
        grilla_facturacion.Rows.Clear()
    End Sub

    Private Sub dtp2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar_datos_clientes()
        grilla_facturacion.Rows.Clear()
    End Sub

    Private Sub combo_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combo_rut.KeyPress
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
        limpiar_datos_clientes()
        grilla_facturacion.Rows.Clear()
    End Sub

    Private Sub combo_rut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_rut.SelectedIndexChanged
        If combo_rut.Text <> "" Then
            lbl_mensaje.Visible = True
            Me.Enabled = False
            grilla_facturacion.Rows.Clear()
            mostrar_datos_clientes()
            calcular_totales()
            lbl_mensaje.Visible = False
            Me.Enabled = True
        End If
    End Sub

    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
        If mirutempresa = "87686300-6" Then
            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            format1.Alignment = StringAlignment.Far

            Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
            Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
            Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
            Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)

            Dim VarNumeroguia As String
            Dim varTipo As String
            Dim varfecha As String
            Dim VarDescuento As String
            Dim VarNeto As String
            Dim VarIva As String
            Dim VarSubotal As String
            Dim VarTotal As String

            e.Graphics.DrawString(txt_factura.Text, Font10, Brushes.Black, 550, 10, format1)
            e.Graphics.DrawString(dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 85, 10)
            e.Graphics.DrawString(txt_nombre_cliente.Text, Font10, Brushes.Black, 85, 25)
            e.Graphics.DrawString(txt_folio_cliente.Text, Font10, Brushes.Black, 550, 25, format1)
            e.Graphics.DrawString(txt_direccion_cliente.Text, Font10, Brushes.Black, 85, 40)
            e.Graphics.DrawString(txt_giro_cliente.Text, Font10, Brushes.Black, 85, 55)
            e.Graphics.DrawString(txt_rut_cliente.Text, Font10, Brushes.Black, 665, 10)
            e.Graphics.DrawString(txt_comuna_cliente.Text, Font10, Brushes.Black, 665, 25)
            e.Graphics.DrawString(txt_telefono_cliente.Text, Font10, Brushes.Black, 665, 40)
            e.Graphics.DrawString(txt_condicion.Text, Font10, Brushes.Black, 665, 55)

            For i = 0 To grilla_facturacion.Rows.Count - 1
                VarNumeroguia = grilla_facturacion.Rows(i).Cells(0).Value
                varTipo = grilla_facturacion.Rows(i).Cells(1).Value
                varfecha = grilla_facturacion.Rows(i).Cells(2).Value
                VarDescuento = grilla_facturacion.Rows(i).Cells(3).Value
                VarNeto = grilla_facturacion.Rows(i).Cells(4).Value
                VarIva = grilla_facturacion.Rows(i).Cells(5).Value
                VarSubotal = grilla_facturacion.Rows(i).Cells(6).Value
                VarTotal = grilla_facturacion.Rows(i).Cells(7).Value

                e.Graphics.DrawString("TIPO: " & varTipo, Font8, Brushes.Black, 10, 140 + (i * 20))
                e.Graphics.DrawString("NRO. DE GUIA: " & VarNumeroguia, Font8, Brushes.Black, 200, 140 + (i * 20))
                e.Graphics.DrawString("FECHA DE GUIA: " & varfecha, Font8, Brushes.Black, 420, 140 + (i * 20))
                If VarTotal <> "0" Then
                    VarTotal = Format(Int(VarTotal), "###,###,###")
                Else
                    VarTotal = "0"
                End If
                e.Graphics.DrawString("TOTAL DE GUIA: " & VarTotal, Font8, Brushes.Black, 792, 140 + (i * 20), format1)
            Next

            Dim descuento_millar As String
            Dim neto_millar As String
            Dim iva_millar As String
            Dim total_millar As String
            Dim subtotal_millar As String

            descuento_millar = txt_descuento.Text
            neto_millar = txt_neto.Text
            iva_millar = txt_iva.Text
            subtotal_millar = txt_sub_total.Text
            total_millar = txt_total.Text

            descuento_millar = Format(Int(descuento_millar), "###,###,###")
            neto_millar = Format(Int(neto_millar), "###,###,###")
            iva_millar = Format(Int(iva_millar), "###,###,###")
            subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
            total_millar = Format(Int(total_millar), "###,###,###")

            e.Graphics.DrawString(desglose_valor, Font9, Brushes.Black, 35, 670)
            e.Graphics.DrawString(dtp_fecha.Text, Font8, Brushes.Black, 40, 755)
            e.Graphics.DrawString(mirecintoempresa, Font8, Brushes.Black, 180, 755)
            e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 792, 680, format1)
            e.Graphics.DrawString(neto_millar, Font10, Brushes.Black, 792, 725, format1)
            e.Graphics.DrawString(iva_millar, Font10, Brushes.Black, 792, 745, format1)
            e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 792, 765, format1)

            If descuento_millar <> "" Then
                If descuento_millar <> "0" Then
                    e.Graphics.DrawString(subtotal_millar, Font8, Brushes.Black, 800, 580, format1)
                    e.Graphics.DrawString("-  " & descuento_millar, Font8, Brushes.Black, 800, 600, format1)
                    e.Graphics.DrawString("_________", Font8, Brushes.Black, 800, 602, format1)
                    e.Graphics.DrawString(total_millar, Font8, Brushes.Black, 800, 620, format1)
                End If
            End If
        End If




        If mirutempresa = "81921000-4" Then



            Dim VarCodProducto As String
            Dim varnombre As String
            Dim vartecnico As String
            Dim VarValorUnitario As String
            Dim VarCantidad As String
            Dim VarPorcentaje As String
            Dim VarDescuento As String
            Dim VarNeto As String
            Dim VarIva As String
            Dim VarSubtotal As String
            Dim VarTotal As String
            Dim cantidad_detalle As String
            Dim valorUnitario_detalle As String
            Dim subtotal_detalle As String
            Dim total_detalle As String

            Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
            Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
            Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
            Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)

            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            format1.Alignment = StringAlignment.Far

            'e.Graphics.DrawString("NRO. GUIA: " & txt_factura.Text & ", PROVIENE DE: " & mirecintoempresa & " , BULTOS: " & txt_productos.Text, Font10, Brushes.Black, 0, 0)
            e.Graphics.DrawString(txt_factura.Text, Font10, Brushes.Black, 85, 0)
            e.Graphics.DrawString(dtp_fecha.Value.Day & "          " & dtp_fecha.Value.Month & "         " & dtp_fecha.Value.Year, Font10, Brushes.Black, 620, 0)
            e.Graphics.DrawString(txt_nombre_cliente.Text, Font10, Brushes.Black, 80, 40)
            e.Graphics.DrawString(txt_direccion_cliente.Text, Font10, Brushes.Black, 80, 57)
            e.Graphics.DrawString(txt_giro_cliente.Text, Font10, Brushes.Black, 80, 74)
            'e.Graphics.DrawString(txt_telefono.Text, Font10, Brushes.Black, 80, 91)
            'e.Graphics.DrawString(Combo_vehiculo.Text, Font10, Brushes.Black, 80, 108)
            e.Graphics.DrawString(txt_rut_cliente.Text, Font10, Brushes.Black, 550, 40)
            e.Graphics.DrawString(txt_comuna_cliente.Text, Font10, Brushes.Black, 550, 57)
            e.Graphics.DrawString(txt_ciudad_cliente.Text, Font10, Brushes.Black, 550, 74)
            e.Graphics.DrawString(txt_condicion.Text, Font10, Brushes.Black, 550, 91)
            'e.Graphics.DrawString(txt_patente.Text, Font10, Brushes.Black, 550, 108)

            For i = 0 To grilla_facturacion.Rows.Count - 1
                VarCodProducto = grilla_facturacion.Rows(i).Cells(0).Value.ToString
                varnombre = grilla_facturacion.Rows(i).Cells(1).Value.ToString
                vartecnico = grilla_facturacion.Rows(i).Cells(2).Value.ToString
                VarValorUnitario = grilla_facturacion.Rows(i).Cells(3).Value.ToString
                VarCantidad = grilla_facturacion.Rows(i).Cells(4).Value.ToString
                VarNeto = grilla_facturacion.Rows(i).Cells(5).Value.ToString
                VarIva = grilla_facturacion.Rows(i).Cells(6).Value.ToString
                VarSubtotal = grilla_facturacion.Rows(i).Cells(7).Value.ToString
                VarPorcentaje = grilla_facturacion.Rows(i).Cells(8).Value.ToString
                VarDescuento = grilla_facturacion.Rows(i).Cells(9).Value.ToString
                VarTotal = grilla_facturacion.Rows(i).Cells(10).Value.ToString
                cantidad_detalle = grilla_facturacion.Rows(i).Cells(4).Value.ToString
                valorUnitario_detalle = grilla_facturacion.Rows(i).Cells(3).Value.ToString
                subtotal_detalle = grilla_facturacion.Rows(i).Cells(7).Value.ToString
                total_detalle = grilla_facturacion.Rows(i).Cells(10).Value.ToString
                valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
                subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
                total_detalle = Format(Int(total_detalle), "###,###,###")

                If varnombre.Length > 35 Then
                    varnombre = varnombre.Substring(0, 35)
                End If

                If vartecnico.Length > 22 Then
                    vartecnico = vartecnico.Substring(0, 22)
                End If

                e.Graphics.DrawString(VarCodProducto, Font8, Brushes.Black, 10, 190 + (i * 15))
                e.Graphics.DrawString(varnombre & " " & vartecnico, Font8, Brushes.Black, 130, 190 + (i * 15))
                e.Graphics.DrawString(cantidad_detalle, Font8, Brushes.Black, 570, 190 + (i * 15), format1)
                e.Graphics.DrawString(valorUnitario_detalle, Font8, Brushes.Black, 730, 190 + (i * 15), format1)
            Next


            Dim descuento_millar As String
            Dim neto_millar As String
            Dim iva_millar As String
            Dim total_millar As String
            Dim subtotal_millar As String

            descuento_millar = txt_descuento.Text
            neto_millar = txt_neto.Text
            iva_millar = txt_iva.Text
            subtotal_millar = txt_sub_total.Text
            total_millar = txt_total.Text

            descuento_millar = Format(Int(descuento_millar), "###,###,###")
            neto_millar = Format(Int(neto_millar), "###,###,###")
            iva_millar = Format(Int(iva_millar), "###,###,###")
            subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
            total_millar = Format(Int(total_millar), "###,###,###")

            e.Graphics.DrawString(desglose_valor, Font9, Brushes.Black, 35, 670)
            e.Graphics.DrawString(dtp_fecha.Text, Font8, Brushes.Black, 40, 755)
            e.Graphics.DrawString(mirecintoempresa, Font8, Brushes.Black, 180, 755)
            e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 792, 680, format1)
            e.Graphics.DrawString(neto_millar, Font10, Brushes.Black, 792, 725, format1)
            e.Graphics.DrawString(iva_millar, Font10, Brushes.Black, 792, 745, format1)
            e.Graphics.DrawString(total_millar, Font10, Brushes.Black, 792, 765, format1)

            If descuento_millar <> "" Then
                If descuento_millar <> "0" Then
                    e.Graphics.DrawString(subtotal_millar, Font8, Brushes.Black, 800, 580, format1)
                    e.Graphics.DrawString("-  " & descuento_millar, Font8, Brushes.Black, 800, 600, format1)
                    e.Graphics.DrawString("_________", Font8, Brushes.Black, 800, 602, format1)
                    e.Graphics.DrawString(total_millar, Font8, Brushes.Black, 800, 620, format1)
                End If
            End If
            'e.Graphics.DrawString("GUIA DE TRANSPORTE, NO CONSTITUYE VENTA", Font9, Brushes.Black, 35, 650)
            'e.Graphics.DrawString("NOMBRE: " & txt_nombre_retira.Text & " RUT: " & txt_rut_retira.Text, Font9, Brushes.Black, 35, 670)
        End If
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_quitar_lista_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_lista.GotFocus
        btn_quitar_lista.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_lista_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_lista.LostFocus
        btn_quitar_lista.BackColor = Color.Transparent
    End Sub

    Private Sub btn_nueva_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nueva.GotFocus
        btn_nueva.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nueva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nueva.LostFocus
        btn_nueva.BackColor = Color.Transparent
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        btn_imprimir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub

    Private Sub combo_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_rut.GotFocus
        combo_rut.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_rut.LostFocus
        combo_rut.BackColor = Color.WhiteSmoke
    End Sub

    Sub crear_archivo_plano()
        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim ContenidoArchivo As String = Nothing
        Dim PathArchivo As String
        Dim varnombre As String
        Dim VarNroGuia As String
        Dim VarFechaGuia As String
        Dim VarTotalGuia As String
        Dim nro_linea As String
        Dim nombre_cliente As String
        Dim oc_guia As String

        nombre_cliente = txt_nombre_cliente.Text
        If nombre_cliente.Length > 99 Then
            nombre_cliente = nombre_cliente.Substring(0, 99)
        End If

        Dim giro_cliente As String
        giro_cliente = txt_giro_cliente.Text
        If giro_cliente.Length > 39 Then
            giro_cliente = giro_cliente.Substring(0, 39)
        End If

        Dim direccion_cliente As String
        direccion_cliente = txt_direccion_cliente.Text
        If direccion_cliente.Length > 59 Then
            direccion_cliente = direccion_cliente.Substring(0, 59)
        End If

        Dim comuna_cliente As String
        comuna_cliente = txt_comuna_cliente.Text
        If comuna_cliente.Length > 19 Then
            comuna_cliente = comuna_cliente.Substring(0, 19)
        End If

        Dim ciudad_cliente As String
        ciudad_cliente = txt_ciudad_cliente.Text
        If ciudad_cliente.Length > 19 Then
            ciudad_cliente = ciudad_cliente.Substring(0, 19)
        End If

        Dim correo_cliente As String
        correo_cliente = txt_correo_cliente.Text
        If correo_cliente.Length > 199 Then
            correo_cliente = correo_cliente.Substring(0, 199)
        End If

        Dim telefono_cliente As String
        telefono_cliente = txt_telefono_cliente.Text
        If telefono_cliente.Length > 8 Then
            telefono_cliente = telefono_cliente.Substring(0, 8)
        End If

        If correo_cliente = "-" Then
            correo_cliente = ""
        End If

        If txt_folio_cliente.Text = "-" Then
            txt_folio_cliente.Text = ""
        End If

        Dim condicion As String = ""

        If txt_condicion.Text = "CREDITO" Then
            condicion = "CREDITO " & "(" & txt_condicion.Text & ")"
        End If

        Try
            If Directory.Exists(ruta_archivos_facturacion) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(ruta_archivos_facturacion)
            End If

            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            PathArchivo = ruta_archivos_facturacion & "\" & "Factura " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' TIPO de codificacion para escritura

            'escribimos en el archivo
            strStreamWriter.WriteLine("->Encabezado<-" & vbNewLine _
                                       & "33" & ";" & (txt_factura.Text) & ";" & (mifecha6) & ";" & "0" & ";" & "0" & ";" & (txt_rut_cliente.Text) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (ciudad_cliente) & ";" & (comuna_cliente) & ";" & (correo_cliente) & ";" & (condicion) & ";" & "SISTEMA" & ";;;" & (mirecintoempresa) & ";" & (telefono_cliente) & ";" & vbNewLine _
                                       & "->Totales<-" & vbNewLine _
                                        & (0) & ";" & (0) & ";" & "0" & ";" & "0" & ";" & (txt_neto.Text) & ";" & "0" & ";" & (valor_iva) & ";" & (txt_iva.Text) & ";" & (txt_total.Text) & ";1;" & vbNewLine _
                                        & "->Detalle<-")
            nro_linea = 0

            For i = 0 To grilla_facturacion.Rows.Count - 1
                nro_linea = nro_linea + 1
                VarNroGuia = grilla_facturacion.Rows(i).Cells(0).Value.ToString
                VarFechaGuia = grilla_facturacion.Rows(i).Cells(2).Value.ToString
                VarTotalGuia = grilla_facturacion.Rows(i).Cells(7).Value.ToString
                oc_guia = grilla_facturacion.Rows(i).Cells(9).Value.ToString

                varnombre = "GUIA NRO. " & VarNroGuia & " / " & VarFechaGuia & " / OC " & oc_guia

                If varnombre.Length > 52 Then
                    varnombre = varnombre.Substring(0, 52)
                End If

                strStreamWriter.WriteLine(nro_linea & ";-;" & (varnombre) & ";1;" & (VarTotalGuia) & ";0;0;" & (0) & ";" & (0) & ";" & (0) & ";" & (VarTotalGuia) & ";" & "INT11" & ";" & "UN" & ";" & ";")

            Next


            nro_linea = 0
            strStreamWriter.WriteLine("->Referencia<-")

            nro_linea = nro_linea + 1
            strStreamWriter.WriteLine(nro_linea & ";" & ("801") & ";" & (txt_nro_orden_de_compra.Text) & ";" & (mifecha6) & ";" & (0) & ";" & ("ORDEN DE COMPRA") & ";")

            For i = 0 To grilla_facturacion.Rows.Count - 1
                nro_linea = nro_linea + 1
                VarNroGuia = grilla_facturacion.Rows(i).Cells(0).Value.ToString
                VarFechaGuia = grilla_facturacion.Rows(i).Cells(2).Value.ToString
                VarTotalGuia = grilla_facturacion.Rows(i).Cells(7).Value.ToString
                oc_guia = grilla_facturacion.Rows(i).Cells(9).Value.ToString

                varnombre = "GUIA NRO. " & VarNroGuia & " / " & VarFechaGuia & " / OC " & oc_guia

                If varnombre.Length > 52 Then
                    varnombre = varnombre.Substring(0, 52)
                End If


                Dim mifecha As Date
                mifecha = VarFechaGuia
                VarFechaGuia = mifecha.ToString("yyy-MM-dd")

                strStreamWriter.WriteLine(nro_linea & ";52;" & (VarNroGuia) & ";" & (VarFechaGuia) & ";" & "0" & ";" & "-" & ";")
            Next


            'strStreamWriter.WriteLine("->Referencia<-" & vbNewLine _
            '& "1" & ";801;;;" & "0" & ";" & "-" & ";" & vbNewLine _
            '& "->DescRec<-" & vbNewLine _
            Dim obsernaciones_factura As String
            obsernaciones_factura = txt_folio_cliente.Text & ", " & txt_condicion.Text & ", " & "O.C: " & txt_nro_orden_de_compra.Text

            strStreamWriter.WriteLine("->DescRec<-" & vbNewLine _
                                        & "1" & ";" & "D" & ";" & "Descuento" & ";" & "$" & ";" & txt_descuento.Text & ";" & "0" & ";" & vbNewLine _
                                        & "->Observacion<-" & vbNewLine _
                                        & obsernaciones_factura & ";")
            strStreamWriter.Close() ' cerramos

        Catch ex As Exception
            MsgBox("Error al Guardar la informacion en el archivo. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
            strStreamWriter.Close() ' cerramos
        End Try
    End Sub

    Private Sub dtp_fecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha.ValueChanged
        Dim fecha_factura As Date = dtp_fecha.Text
        Dim fecha_actual As Date = Form_menu_principal.dtp_fecha.Text

        If (fecha_factura) > (fecha_actual) Then
            MsgBox("LA FECHA DE FACTURACION NO PUEDE SER MAYOR AL DIA DE HOY", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            dtp_fecha.Text = Form_menu_principal.dtp_fecha.Text
        End If

        'If (fecha_factura) < (fecha_ultimo_dia_mes) Then
        '    MsgBox("LA FECHA DE FACTURACION NO PUEDE SER MENOR AL ULTIMO DIA DEL MES ANTERIOR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    dtp_fecha.Text = Form_menu_principal.dtp_fecha.Text
        'End If

        fecha()
    End Sub

    Sub facturacion()
        Dim VarNumeroguia As Integer
        Dim varTipo As String
        Dim varfecha As String
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarTotal As Integer
        Dim VarSubotal As Integer
        Dim VarRecinto As String
        Dim VarOcGuia As String

        grilla_factura_tope.Rows.Clear()
        For i = 0 To grilla_facturacion.Rows.Count - 1
            VarNumeroguia = grilla_facturacion.Rows(i).Cells(0).Value
            varTipo = grilla_facturacion.Rows(i).Cells(1).Value
            varfecha = grilla_facturacion.Rows(i).Cells(2).Value
            VarDescuento = grilla_facturacion.Rows(i).Cells(3).Value
            VarNeto = grilla_facturacion.Rows(i).Cells(4).Value
            VarIva = grilla_facturacion.Rows(i).Cells(5).Value
            VarSubotal = grilla_facturacion.Rows(i).Cells(6).Value
            VarTotal = grilla_facturacion.Rows(i).Cells(7).Value
            VarRecinto = grilla_facturacion.Rows(i).Cells(8).Value
            VarOcGuia = grilla_facturacion.Rows(i).Cells(9).Value

            grilla_factura_tope.Rows.Add(VarNumeroguia, _
                                          varTipo, _
                                           varfecha, _
                                            VarDescuento, _
                                             VarNeto, _
                                              VarIva, _
                                               VarSubotal, _
                                                VarTotal, _
                                                 VarRecinto, _
                                                  VarOcGuia)

        Next

        Dim nro_linea As Integer
        grilla_facturacion.Rows.Clear()
        nro_linea = 0

        For i = 0 To grilla_factura_tope.Rows.Count - 1

            VarNumeroguia = grilla_factura_tope.Rows(i).Cells(0).Value
            varTipo = grilla_factura_tope.Rows(i).Cells(1).Value
            varfecha = grilla_factura_tope.Rows(i).Cells(2).Value
            VarDescuento = grilla_factura_tope.Rows(i).Cells(3).Value
            VarNeto = grilla_factura_tope.Rows(i).Cells(4).Value
            VarIva = grilla_factura_tope.Rows(i).Cells(5).Value
            VarSubotal = grilla_factura_tope.Rows(i).Cells(6).Value
            VarTotal = grilla_factura_tope.Rows(i).Cells(7).Value
            VarRecinto = grilla_factura_tope.Rows(i).Cells(8).Value
            VarOcGuia = grilla_factura_tope.Rows(i).Cells(9).Value

            grilla_facturacion.Rows.Add(VarNumeroguia, _
                                          varTipo, _
                                           varfecha, _
                                            VarDescuento, _
                                             VarNeto, _
                                              VarIva, _
                                               VarSubotal, _
                                                VarTotal, _
                                                 VarRecinto, _
                                                  VarOcGuia)

            nro_linea = nro_linea + 1

            If grilla_facturacion.Rows.Count = 25 Or grilla_factura_tope.Rows.Count = 0 Then
                nro_linea = 0
                Me.calcular_totales()
                Me.crear_numero_factura()
                Me.grabar_factura()
                Me.grabar_detalle_factura()
                Me.crear_archivo_plano()
                grilla_facturacion.Rows.Clear()
                txt_condicion.Text = "CREDITO"
            End If
        Next

        If grilla_facturacion.Rows.Count <> 0 Then
            nro_linea = 0
            Me.calcular_totales()
            Me.crear_numero_factura()
            Me.grabar_factura()
            Me.grabar_detalle_factura()
            Me.crear_archivo_plano()
            limpiar()
            txt_condicion.Text = "CREDITO"
        End If

        grilla_factura_tope.Rows.Clear()
        grilla_facturacion.Rows.Clear()
        limpiar()
    End Sub

    Sub nombre_mes()

        If Combo_mes.Text = "ENERO" Then
            txt_mes.Text = "01"
        End If

        If Combo_mes.Text = "FEBRERO" Then
            txt_mes.Text = "02"
        End If

        If Combo_mes.Text = "MARZO" Then
            txt_mes.Text = "03"
        End If

        If Combo_mes.Text = "ABRIL" Then
            txt_mes.Text = "04"
        End If

        If Combo_mes.Text = "MAYO" Then
            txt_mes.Text = "05"
        End If

        If Combo_mes.Text = "JUNIO" Then
            txt_mes.Text = "06"
        End If

        If Combo_mes.Text = "JULIO" Then
            txt_mes.Text = "07"
        End If

        If Combo_mes.Text = "AGOSTO" Then
            txt_mes.Text = "08"
        End If

        If Combo_mes.Text = "SEPTIEMBRE" Then
            txt_mes.Text = "09"
        End If

        If Combo_mes.Text = "OCTUBRE" Then
            txt_mes.Text = "10"
        End If

        If Combo_mes.Text = "NOVIEMBRE" Then
            txt_mes.Text = "11"
        End If

        If Combo_mes.Text = "DICIEMBRE" Then
            txt_mes.Text = "12"
        End If

    End Sub

    Private Sub Combo_mes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_mes.SelectedIndexChanged
        grilla_facturacion.Rows.Clear()
        nombre_mes()
    End Sub

    Sub seleccionar_mes()
        If txt_mes.Text = "1" Then
            Combo_mes.Text = "ENERO"
        End If

        If txt_mes.Text = "2" Then
            Combo_mes.Text = "FEBRERO"
        End If

        If txt_mes.Text = "3" Then
            Combo_mes.Text = "MARZO"
        End If

        If txt_mes.Text = "4" Then
            Combo_mes.Text = "ABRIL"
        End If

        If txt_mes.Text = "5" Then
            Combo_mes.Text = "MAYO"
        End If

        If txt_mes.Text = "JUNIO" Then
            Combo_mes.Text = "06"
        End If

        If txt_mes.Text = "7" Then
            Combo_mes.Text = "JULIO"
        End If

        If txt_mes.Text = "8" Then
            Combo_mes.Text = "AGOSTO"
        End If

        If txt_mes.Text = "9" Then
            Combo_mes.Text = "SEPTIEMBRE"
        End If

        If txt_mes.Text = "10" Then
            Combo_mes.Text = "OCTUBRE"
        End If

        If txt_mes.Text = "11" Then
            Combo_mes.Text = "NOVIEMBRE"
        End If

        If txt_mes.Text = "12" Then
            Combo_mes.Text = "DICIEMBRE"
        End If
    End Sub

    Private Sub Combo_año_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_año.SelectedIndexChanged
        grilla_facturacion.Rows.Clear()
    End Sub

    Private Sub grilla_facturacion_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_facturacion.CellContentClick
        If grilla_facturacion.Rows.Count <> 0 Then
            Dim oc_guia As String

            oc_guia = grilla_facturacion.CurrentRow.Cells(9).Value

            oc_guia.Replace("'", "´")
            oc_guia.Replace("&", "")
            oc_guia.Replace(Chr(34), "´´")
            oc_guia.Replace("\", "")
            oc_guia.Replace("|", "")
            oc_guia.Replace("¿", "")
            oc_guia.Replace("?", "")
            oc_guia.Replace("}", "")
            oc_guia.Replace("{", "")
            oc_guia.Replace("<", "")
            oc_guia.Replace(">", "")
            oc_guia.Replace("*", "")
            oc_guia.Replace("+", "")
            oc_guia.Replace("-", "")
            oc_guia.Replace(";", "")

            If oc_guia.Length > 11 Then
                oc_guia = oc_guia.Substring(0, 11)
                grilla_facturacion.CurrentRow.Cells(9).Value = oc_guia
            End If
        End If
    End Sub

    Private Sub grilla_facturacion_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_facturacion.CellValueChanged

        If grilla_facturacion.Rows.Count <> 0 Then
            Dim oc_guia As String

            oc_guia = grilla_facturacion.CurrentRow.Cells(9).Value

            oc_guia.Replace("'", "´")
            oc_guia.Replace("&", "")
            oc_guia.Replace(Chr(34), "´´")
            oc_guia.Replace("\", "")
            oc_guia.Replace("|", "")
            oc_guia.Replace("¿", "")
            oc_guia.Replace("?", "")
            oc_guia.Replace("}", "")
            oc_guia.Replace("{", "")
            oc_guia.Replace("<", "")
            oc_guia.Replace(">", "")
            oc_guia.Replace("*", "")
            oc_guia.Replace("+", "")
            oc_guia.Replace("-", "")
            oc_guia.Replace(";", "")

            If oc_guia.Length > 11 Then
                oc_guia = oc_guia.Substring(0, 11)
                grilla_facturacion.CurrentRow.Cells(9).Value = oc_guia
            End If
        End If

    End Sub

    Private Sub grilla_facturacion_EditModeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_facturacion.EditModeChanged
        If grilla_facturacion.Rows.Count <> 0 Then
            Dim oc_guia As String

            oc_guia = grilla_facturacion.CurrentRow.Cells(9).Value

            oc_guia.Replace("'", "´")
            oc_guia.Replace("&", "")
            oc_guia.Replace(Chr(34), "´´")
            oc_guia.Replace("\", "")
            oc_guia.Replace("|", "")
            oc_guia.Replace("¿", "")
            oc_guia.Replace("?", "")
            oc_guia.Replace("}", "")
            oc_guia.Replace("{", "")
            oc_guia.Replace("<", "")
            oc_guia.Replace(">", "")
            oc_guia.Replace("*", "")
            oc_guia.Replace("+", "")
            oc_guia.Replace("-", "")
            oc_guia.Replace(";", "")

            If oc_guia.Length > 11 Then
                oc_guia = oc_guia.Substring(0, 11)
                grilla_facturacion.CurrentRow.Cells(9).Value = oc_guia
            End If
        End If
    End Sub

    Private Sub grilla_facturacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grilla_facturacion.KeyPress

      


        If grilla_facturacion.Rows.Count <> 0 Then
            Dim oc_guia As String

            oc_guia = grilla_facturacion.CurrentRow.Cells(9).Value


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


            oc_guia.Replace("'", "´")
            oc_guia.Replace("&", "")
            oc_guia.Replace(Chr(34), "´´")
            oc_guia.Replace("\", "")
            oc_guia.Replace("|", "")
            oc_guia.Replace("¿", "")
            oc_guia.Replace("?", "")
            oc_guia.Replace("}", "")
            oc_guia.Replace("{", "")
            oc_guia.Replace("<", "")
            oc_guia.Replace(">", "")
            oc_guia.Replace("*", "")
            oc_guia.Replace("+", "")
            oc_guia.Replace("-", "")
            oc_guia.Replace(";", "")

            If oc_guia.Length > 11 Then
                oc_guia = oc_guia.Substring(0, 11)
                grilla_facturacion.CurrentRow.Cells(9).Value = oc_guia
            End If
        End If
    End Sub
End Class