Imports System.Runtime.InteropServices
Imports System.Net.Mail
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.Resources

Public Class Form_estado_de_cuenta
    Declare Function SetDefaultPrinter Lib "winspool.drv" Alias "SetDefaultPrinterA" (ByVal pszPrinter As String) As Boolean
    Dim total_registros As Integer
    Dim peso As String
    Dim pesos As String
    Dim mifecha_emision2 As String
    Dim mifecha_vencimiento2 As String
    Dim message As New MailMessage
    Dim smtp As New SmtpClient
    Private WithEvents Pd As New PrintDocument
    Dim tipo_impresion As String

    Dim email As String
    Dim clave_email As String
    Dim seguridad_ssl As String
    Dim puerto_smtp As String
    Dim servidor_smtp As String
    Dim numero_lineas_total As Integer = 0

    Private Sub Form_estado_de_cuenta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_estado_de_cuenta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    'se llena el combo rut.
    Private Sub Form_estado_de_cuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '  llenar_combo_rut()
        cargar_logo()
        SetDefaultPrinter(impresora_guias)
        mostrar_datos_correo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub mostrar_datos_correo()
        'Dim email As String
        'Dim clave_email As String
        'Dim seguridad_ssl As String
        'Dim puerto_smtp As String
        'Dim servidor_smtp As String

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from correo_de_administracion"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            email = DS.Tables(DT.TableName).Rows(0).Item("correo")
            clave_email = DS.Tables(DT.TableName).Rows(0).Item("clave_correo")
            seguridad_ssl = DS.Tables(DT.TableName).Rows(0).Item("seguridad_ssl")
            puerto_smtp = DS.Tables(DT.TableName).Rows(0).Item("puerto_smtp")
            servidor_smtp = DS.Tables(DT.TableName).Rows(0).Item("servidor_smtp")
        End If
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
            totalgrilla = Val(grilla_estado_de_cuenta.Rows(i).Cells(6).Value.ToString)
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
            grilla_estado_de_cuenta.Rows.Clear()
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
            If DS.Tables(DT.TableName).Rows.Count = 1 Then
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_codigo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
                txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                conexion.Close()
                Exit Sub
            ElseIf DS.Tables(DT.TableName).Rows.Count > 1 Then
                conexion.Close()
                Form_seleccionar_cuenta_estado_de_cuenta.Show()
                Me.Enabled = False
                Exit Sub
            ElseIf DS.Tables(DT.TableName).Rows.Count < 1 Then
                MsgBox("CLIENTE NO ENCONTRADO", 0 + 16, "ERROR")
                txt_rut_cliente.Focus()
                conexion.Close()
            End If
            conexion.Close()
        End If
    End Sub

    Sub mostrar_datos_clientes_rut()
        If txt_rut_cliente.Text <> "" Then
            grilla_estado_de_cuenta.Rows.Clear()
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
            If DS.Tables(DT.TableName).Rows.Count > 1 Then
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_codigo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
                txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                conexion.Close()
                Exit Sub
            ElseIf DS.Tables(DT.TableName).Rows.Count < 1 Then
                MsgBox("CLIENTE NO ENCONTRADO", 0 + 16, "ERROR")
                txt_rut_cliente.Focus()
                conexion.Close()
            End If
            conexion.Close()
        End If
    End Sub

    Sub mostrar_datos_clientes_codigo()
        If txt_codigo_cliente.Text <> "" Then
            grilla_estado_de_cuenta.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from clientes where cod_cliente ='" & (txt_codigo_cliente.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count = 1 Then
                txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_codigo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
                txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                conexion.Close()
                Exit Sub
            ElseIf DS.Tables(DT.TableName).Rows.Count > 1 Then
                conexion.Close()
                Form_seleccionar_cuenta_estado_de_cuenta.Show()
                Me.Enabled = False
                Exit Sub
            ElseIf DS.Tables(DT.TableName).Rows.Count < 1 Then
                MsgBox("CLIENTE NO ENCONTRADO", 0 + 16, "ERROR")
                txt_rut_cliente.Focus()
                conexion.Close()
            End If
            conexion.Close()
        End If
    End Sub


    Sub cargar_documento()

        Dim tipo_doc As String
        Dim numero_doc As String

        tipo_doc = grilla_estado_de_cuenta.CurrentRow.Cells(1).Value
        numero_doc = grilla_estado_de_cuenta.CurrentRow.Cells(0).Value

        grilla_detalle_venta.Rows.Clear()

        If tipo_doc = "LETRA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from letras where n_letra='" & (numero_doc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)


            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                tipo_doc = DS.Tables(DT.TableName).Rows(0).Item("doc_referencia")
                numero_doc = DS.Tables(DT.TableName).Rows(0).Item("nro_referencia")

            End If
        End If




        If tipo_doc = "BOLETA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from detalle_boleta where detalle_boleta.n_boleta='" & (numero_doc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)


            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                                    DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                                     DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                                      DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                                       DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                                        DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                                                                         DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                                          DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
                                                                           DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
                                                                            DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                                                                             DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If
        End If

        If tipo_doc = "FACTURA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from detalle_factura where detalle_factura.n_factura='" & (numero_doc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)


            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_venta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                                    DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                                     DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                                      DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"), _
                                                                       DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                                        DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"), _
                                                                         DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"), _
                                                                          DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"), _
                                                                           DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc"), _
                                                                            DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"), _
                                                                             DS.Tables(DT.TableName).Rows(i).Item("detalle_total"))
                Next
            End If
        End If
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
    Sub mostrar_malla_rut()
        Dim saldo As Integer
        txt_total_deuda.Text = "0"
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from creditos where rut_cliente = '" & (txt_rut_cliente.Text) & "' and saldo <> '0' order by fecha_venta asc"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Dim MiFechaEmision As Date
                MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")

                Dim MiFechaVencimiento As Date
                MiFechaVencimiento = DS.Tables(DT.TableName).Rows(i).Item("fecha_vencimiento")
                mifecha_vencimiento2 = MiFechaVencimiento.ToString("dd-MM-yyy")

                Dim tipo_detalle As String
                tipo_detalle = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")

                If tipo_detalle = "ABONO SIN IMPUTAR" Then
                    mifecha_vencimiento2 = "-"
                End If

                If tipo_detalle = "NOTA DE CREDITO SIN IMPUTAR" Then
                    mifecha_vencimiento2 = "-"
                End If

                If tipo_detalle = "NOTA DE DEBITO SIN IMPUTAR" Then
                    mifecha_vencimiento2 = "-"
                End If

                saldo = DS.Tables(DT.TableName).Rows(i).Item("saldo")

                txt_total_deuda.Text = Val(txt_total_deuda.Text) + Val(saldo)

                grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_creditos"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle"), _
                                                   mifecha_emision2, _
                                                    DS.Tables(DT.TableName).Rows(i).Item("recinto"), _
                                                     mifecha_vencimiento2, _
                                                      DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                       saldo, _
                                                        txt_total_deuda.Text)
                'txt_total_deuda.Text = Val(txt_total_deuda.Text) + Val(saldo)
            Next
            grilla_estado_de_cuenta.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_estado_de_cuenta.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_estado_de_cuenta.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_estado_de_cuenta.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        If grilla_estado_de_cuenta.Rows.Count <> 0 Then
            If grilla_estado_de_cuenta.Columns(0).Width = 80 Then
                grilla_estado_de_cuenta.Columns(0).Width = 79
            Else
                grilla_estado_de_cuenta.Columns(0).Width = 80
            End If
            grilla_estado_de_cuenta.Columns(2).Width = 80
            grilla_estado_de_cuenta.Columns(3).Width = 150
            grilla_estado_de_cuenta.Columns(4).Width = 80
            grilla_estado_de_cuenta.Columns(5).Width = 80
            grilla_estado_de_cuenta.Columns(6).Width = 80
            grilla_estado_de_cuenta.Columns(7).Width = 85
        End If
    End Sub

    Sub mostrar_malla_codigo()
        Dim saldo As Integer
        txt_total_deuda.Text = "0"
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from creditos where codigo_cliente = '" & (txt_codigo_cliente.Text) & "' and saldo <> '0' order by fecha_venta asc"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Dim MiFechaEmision As Date
                MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")

                Dim MiFechaVencimiento As Date
                MiFechaVencimiento = DS.Tables(DT.TableName).Rows(i).Item("fecha_vencimiento")
                mifecha_vencimiento2 = MiFechaVencimiento.ToString("dd-MM-yyy")

                Dim tipo_detalle As String
                tipo_detalle = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")

                If tipo_detalle = "ABONO SIN IMPUTAR" Then
                    mifecha_vencimiento2 = "-"
                End If

                If tipo_detalle = "NOTA DE CREDITO SIN IMPUTAR" Then
                    mifecha_vencimiento2 = "-"
                End If

                If tipo_detalle = "NOTA DE DEBITO SIN IMPUTAR" Then
                    mifecha_vencimiento2 = "-"
                End If

                saldo = DS.Tables(DT.TableName).Rows(i).Item("saldo")

                txt_total_deuda.Text = Val(txt_total_deuda.Text) + Val(saldo)

                grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_creditos"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle"), _
                                                   mifecha_emision2, _
                                                    DS.Tables(DT.TableName).Rows(i).Item("recinto"), _
                                                     mifecha_vencimiento2, _
                                                      DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                       saldo, _
                                                        txt_total_deuda.Text)
                'txt_total_deuda.Text = Val(txt_total_deuda.Text) + Val(saldo)
            Next
            grilla_estado_de_cuenta.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_estado_de_cuenta.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_estado_de_cuenta.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_estado_de_cuenta.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        If grilla_estado_de_cuenta.Rows.Count <> 0 Then
            If grilla_estado_de_cuenta.Columns(0).Width = 80 Then
                grilla_estado_de_cuenta.Columns(0).Width = 79
            Else
                grilla_estado_de_cuenta.Columns(0).Width = 80
            End If
            grilla_estado_de_cuenta.Columns(2).Width = 80
            grilla_estado_de_cuenta.Columns(3).Width = 150
            grilla_estado_de_cuenta.Columns(4).Width = 80
            grilla_estado_de_cuenta.Columns(5).Width = 80
            grilla_estado_de_cuenta.Columns(6).Width = 80
            grilla_estado_de_cuenta.Columns(7).Width = 85
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


        grilla_estado_de_cuenta.DataSource = Nothing
        grilla_estado_de_cuenta.Rows.Clear()

        txt_total_deuda.Text = ""
    End Sub

    Sub guion_rut_cliente()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut_cliente.Text
        If txt_rut_cliente.Text.Contains("PROPIEDAD") Then
        Else
            If rut_cliente.Length > 2 Then
                guion = rut_cliente(rut_cliente.Length - 2).ToString()
                If guion <> "-" Then
                    Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                    rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                    rut_cliente = rut_cliente & "-" & fin_rut
                    txt_rut_cliente.Text = rut_cliente
                End If
            End If
        End If
    End Sub




    '' se graba el estado de cuenta mediante un ciclo for en una tabla temporal.
    'Sub grabar_estado_cuenta()
    '    Dim Varcoddocumento As Integer
    '    Dim VarTipo As String
    '    Dim Varfecha As String
    '    Dim vartotal As Integer
    '    Dim varsaldo As Integer
    '    Dim totalsaldo As Integer
    '    Dim vartotalsaldo As Integer
    '    txt_total_saldo.Text = "0"


    '    'DS.Tables.Clear()
    '    'DT.Rows.Clear()
    '    'DT.Columns.Clear()
    '    'DS.Clear()
    '    'conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "delete from estado_de_cuenta_temporal"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    'conexion.Close()



    '    'SC.Connection = conexion
    '    'SC.CommandText = "delete from estado_de_cuenta_temporal"
    '    'DA.SelectCommand = SC
    '    'DA.Fill(DT)







    '    For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1




    '        Varcoddocumento = grilla_estado_de_cuenta.Rows(i).Cells(0).Value.ToString
    '        VarTipo = grilla_estado_de_cuenta.Rows(i).Cells(1).Value.ToString
    '        Varfecha = grilla_estado_de_cuenta.Rows(i).Cells(2).Value
    '        vartotal = grilla_estado_de_cuenta.Rows(i).Cells(3).Value.ToString
    '        varsaldo = grilla_estado_de_cuenta.Rows(i).Cells(4).Value.ToString


    '        ' For e = 0 To migrilla.Rows.Count - 1

    '        totalsaldo = grilla_estado_de_cuenta.Rows(i).Cells(4).Value.ToString
    '        '   txt_total_saldo.Text = Val(txt_total_saldo.Text) + Val(totalsaldo)

    '        'Next
    '        conexion.Close()
    '        DS.Tables.Clear()
    '        DT.Rows.Clear()
    '        DT.Columns.Clear()
    '        DS.Clear()
    '        conexion.Open()
    '        vartotalsaldo = grilla_estado_de_cuenta.Rows(i).Cells(4).Value.ToString
    '        SC.Connection = conexion
    '        SC.CommandText = "insert into estado_de_cuenta_temporal (rut, nombre, direccion, telefono,TIPO, deuda_total, n_doc, fecha_venta, total, deuda_saldo, desglose, total_saldo, ciudad) values('" & (txt_rut_cliente.Text) & "','" & (txt_nombre_cliente.Text) & "','" & (txt_direccion_cliente.Text) & "','" & (txt_telefono.Text) & "','" & (VarTipo) & "','" & (txt_total_deuda.Text) & "','" & (Varcoddocumento) & "','" & (Varfecha) & "','" & (vartotal) & "','" & (varsaldo) & "','" & (txt_desglose.Text) & "','" & (totalsaldo) & "','" & (txt_ciudad_cliente.Text) & "')"
    '        '  SC.CommandText = "insert into estado_de_cuenta_temporal (                                                                                                                                          rut,                nombre,                                  direccion,                  telefono,              TIPO,                   deuda_total,                    n_doc,              fecha_venta,            total,      deuda_saldo,        desglose,                   total_saldo,                        ciudad) values('" & (txt_rut.Text) & "','" & (txt_nombre_cliente.Text) & "','" & (txt_direccion.Text) & "'," & (txt_telefono.Text) & ",'" & (VarTipo) & "'," & (txt_total.Text) & "," & (Varcoddocumento) & ",'" & (Varfecha) & "'," & (vartotal) & ",'" & (0) & "','" & (txt_desglose.Text) & "'," & (txt_total_saldo.Text) & ",'" & (txt_ciudad.Text) & "')"

    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        conexion.Close()

    '        'DS.Tables.Clear()
    '        'DT.Rows.Clear()
    '        'DT.Columns.Clear()
    '        'DS.Clear()
    '        'conexion.Close()
    '    Next
    '    ' Next






    '    'Dim sql As String = "insert into tbl_imagenes(imagen)values(?imagen)"
    '    'cnn = New MySqlConnection(StrConexion)
    '    'Dim Comando As New MySqlCommand(sql, cnn)
    '    'Dim Imag As Byte()
    '    'Imag = Imagen_Bytes(Me.PictureBox1.Image)

    '    'Comando.Parameters.AddWithValue("?imagen", Imag)








    'End Sub









    Private Sub combo_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If Char.IsControl(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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
        dt.Columns.Add(New DataColumn("recinto", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha_vencimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("total_doc", GetType(Integer)))
        dt.Columns.Add(New DataColumn("saldo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("saldo_final", GetType(Integer)))
        dt.Columns.Add(New DataColumn("desglose_palabras", GetType(String)))
        dt.Columns.Add(New DataColumn("deuda", GetType(String)))
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
        Dim VarRecinto As String
        Dim VarVencimiento As String
        Dim vartotal As Integer
        Dim varsaldo As Integer
        Dim varsaldoTotal As Integer

        For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1
            Varcoddocumento = grilla_estado_de_cuenta.Rows(i).Cells(0).Value.ToString
            VarTipo = grilla_estado_de_cuenta.Rows(i).Cells(1).Value.ToString
            Varfecha = grilla_estado_de_cuenta.Rows(i).Cells(2).Value
            VarRecinto = grilla_estado_de_cuenta.Rows(i).Cells(3).Value
            VarVencimiento = grilla_estado_de_cuenta.Rows(i).Cells(4).Value
            vartotal = grilla_estado_de_cuenta.Rows(i).Cells(5).Value.ToString
            varsaldo = grilla_estado_de_cuenta.Rows(i).Cells(6).Value.ToString
            varsaldoTotal = grilla_estado_de_cuenta.Rows(i).Cells(7).Value.ToString
            dr = dt.NewRow()

            Try
                dr("Imagen") = Imagen_formulario
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
            If tipo_impresion = "FORMAL" Then
                dr("tipo_documento") = VarTipo
            Else
                dr("tipo_documento") = VarTipo & Varcoddocumento
            End If
            dr("nro_doc") = Varcoddocumento
            dr("fecha_doc") = Varfecha
            dr("recinto") = VarRecinto
            dr("fecha_vencimiento") = VarVencimiento
            dr("total_doc") = vartotal
            dr("saldo") = varsaldo
            dr("saldo_final") = varsaldoTotal
            dr("deuda") = txt_total_deuda.Text
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



        'tipo_impresion = "FORMAL"


        lbl_mensaje.Visible = True
        Me.Enabled = False

        PrintDialog1.Document = Print_carta

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Print_carta.DefaultPageSettings.Landscape = False
            Print_carta.Print()

            Try
                Print_carta.DefaultPageSettings.Landscape = False
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
            Catch
            End Try
        End If




        lbl_mensaje.Visible = False
        Me.Enabled = True



    End Sub



    'se llama al sub limpiar la pantalla.
    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_historico.Click
        Form_historico_cuentas_corrientes.Show()
        Form_historico_cuentas_corrientes.txt_rut_cliente.Text = txt_rut_cliente.Text

        If Form_historico_cuentas_corrientes.txt_rut_cliente.Text <> "" Then
            Form_historico_cuentas_corrientes.fecha()
            '  mostrar_datos_clientes()
            Form_historico_cuentas_corrientes.mostrar_malla_abonos()
            Form_historico_cuentas_corrientes.mostrar_malla_estado_de_cuenta()
            Form_historico_cuentas_corrientes.mostrar_malla_avisos_de_cobranza()

            calcular_totales()
        End If

        Form_cobranzas.WindowState = FormWindowState.Normal
        'Me.WindowState = FormWindowState.Minimized
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
        txt_correo_cliente.Text = ""
        'grilla_estado_de_cuenta.DataSource = Nothing
        grilla_estado_de_cuenta.Rows.Clear()
    End Sub

    'salir de la pantalla.
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'form_Menu_admin.WindowState = FormWindowState.Normal
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

        seleccion_estado_de_cuenta = ""

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


        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            lbl_mensaje.Visible = True
            Me.Enabled = False

            If mirutempresa = "87686300-6" Then
                limpiar_datos_clientes()
                grilla_estado_de_cuenta.Rows.Clear()
                grilla_detalle_venta.Rows.Clear()
                txt_total_deuda.Text = 0
                guion_rut_cliente()
                mostrar_datos_clientes()
                'mostrar_malla()
                'calcular_totales()
                mostrar_malla_rut()
                'mostrar_malla()
                calcular_totales()
                'recuperar_conexion()
                If txt_total_deuda.Text = "" Or txt_total_deuda.Text = "0" Then
                    txt_total_deuda.Text = "0"
                Else
                    txt_total_deuda.Text = Format(Int(txt_total_deuda.Text), "###,###,###")
                End If
                lbl_mensaje.Visible = False
                Me.Enabled = True
                Exit Sub
            End If

            limpiar_datos_clientes()
            grilla_estado_de_cuenta.Rows.Clear()
            grilla_detalle_venta.Rows.Clear()
            txt_total_deuda.Text = 0
            guion_rut_cliente()
            mostrar_datos_clientes()
            mostrar_malla_rut()
            calcular_totales()

            If txt_total_deuda.Text = "" Or txt_total_deuda.Text = "0" Then
                txt_total_deuda.Text = "0"
            Else
                txt_total_deuda.Text = Format(Int(txt_total_deuda.Text), "###,###,###")
            End If

            lbl_mensaje.Visible = False
            Me.Enabled = True
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
        btn_enviar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_enviar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_enviar.GotFocus
        btn_enviar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_historico.GotFocus
        btn_historico.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_historico.LostFocus
        btn_historico.BackColor = Color.Transparent
    End Sub

    Private Sub btn_aviso_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aviso.GotFocus
        btn_aviso.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_aviso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aviso.LostFocus
        btn_aviso.BackColor = Color.Transparent
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

        If ValidEmail(txt_correo_cliente.Text) = False Then
            txt_correo_cliente.Focus()
            txt_correo_cliente.SelectAll()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        mostrar_datos_correo()

        Dim nro_copia As Integer
        nro_copia = 1

        Dim nombre_archivo As String
        nombre_archivo = "ESTADO DE CUENTA AL DIA " & txt_rut_cliente.Text & " " & dtp_fecha.Text & ".pdf"

        Dim exists As Boolean
        exists = System.IO.File.Exists("C:\Estados de cuenta\" & nombre_archivo)

        If exists = True Then
            nro_copia = nro_copia + 1

            '  nombre_archivo = nombre_archivo & "_" & nro_copia

            nombre_archivo = "ESTADO DE CUENTA AL DIA " & txt_rut_cliente.Text & " " & dtp_fecha.Text & "_" & nro_copia & ".pdf"

            exists = System.IO.File.Exists("C:\Estados de cuenta\" & nombre_archivo)

            Dim index As Integer = 0
            Do While exists = True
                nombre_archivo = "ESTADO DE CUENTA AL DIA " & txt_rut_cliente.Text & " " & dtp_fecha.Text & "_" & nro_copia & ".pdf"

                exists = System.IO.File.Exists("C:\Estados de cuenta\" & nombre_archivo)

                If exists = False Then
                    Exit Do
                End If

                nro_copia = nro_copia + 1
            Loop
        End If

        Try
            Dim iReporte As New form_informe_estado_de_cuenta_personalizado
            Dim rpt As New Crystal_estado_de_cuenta_personalizado

            rpt.Load()
            rpt.SetDataSource(ReturnDataSet)
            rpt.Refresh()

            iReporte.Reporte = rpt
            '  iReporte.ShowDialog()

            If Directory.Exists("C:\Estados de cuenta") = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory("C:\Estados de cuenta")
            End If

            Try
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
                Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

                CrDiskFileDestinationOptions.DiskFileName = "C:\Estados de cuenta\" & nombre_archivo
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
            adjunto = New System.Net.Mail.Attachment("C:\Estados de cuenta\" & nombre_archivo)
            message.From = New MailAddress(email)

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
            "Le saluda atentamente" & vbNewLine & vbNewLine & minombre & vbNewLine & mitelefonoempresa & vbNewLine & miarea & vbNewLine & minombreempresa
            message.Subject = "ESTADO DE CUENTA ACTUALIZADO AL DIA " & dtp_fecha.Text
            message.Priority = MailPriority.Normal
            message.Attachments.Add(adjunto)




            If seguridad_ssl = "SI" Then
                smtp.EnableSsl = True
            Else
                smtp.EnableSsl = False
            End If

            smtp.Port = puerto_smtp
            smtp.Host = servidor_smtp
            smtp.Credentials = New Net.NetworkCredential(email, clave_email)
            smtp.Send(message)


            SC.Connection = conexion
            SC.CommandText = "insert into registro_de_cobranzas (rut_cliente, detalle, TIPO, fecha, usuario_responsable) values ('" & (txt_rut_cliente.Text) & "' , 'ENVIADO DESDE ESTADOS DE CUENTA','CORREO ELECTRONICO','" & (Form_menu_principal.dtp_fecha.Text) & "','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

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
        btn_buscar_clientes.BackColor = Color.Transparent
    End Sub

    Private Sub btn_buscar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_clientes.Click

        Form_buscador_clientes_estado_de_cuenta.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nro_doc As String

        nro_doc = grilla_estado_de_cuenta.CurrentRow.Cells(0).Value

        SC.Connection = conexion
        SC.CommandText = "DELETE FROM creditos WHERE `n_creditos`='" & (nro_doc) & "' "
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "DELETE FROM nota_credito WHERE `n_nota_credito`='" & (nro_doc) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "DELETE FROM detalle_nota_credito WHERE `n_nota_credito`='" & (nro_doc) & "'"
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

    Private Sub grilla_estado_de_cuenta_final_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_estado_de_cuenta.CellContentClick

    End Sub

    Private Sub grilla_estado_de_cuenta_final_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_estado_de_cuenta.Click
        If grilla_estado_de_cuenta.Rows.Count <> 0 Then
            cargar_documento()
        End If
    End Sub

    Private Sub btn_ticket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ticket.Click
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

        lbl_mensaje.Visible = True
        Me.Enabled = False



        With Print_ticket.PrinterSettings
            .PrinterName = impresora_ticket
            .Copies = 2
            .PrintRange = PrintRange.AllPages
            If .IsValid Then
                Me.Print_ticket.PrintController = New StandardPrintController
 
                Try
                    Print_ticket.DefaultPageSettings.Landscape = False
                    Print_ticket.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                    Print_ticket.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
                Catch
                End Try

                Print_ticket.PrintController = New System.Drawing.Printing.StandardPrintController()
                Print_ticket.Print()
            Else
                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                lbl_mensaje.Visible = False
                Me.Enabled = True
                Exit Sub
            End If
        End With

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
        Dim Varcoddocumento As String
        Dim VarTipo As String
        Dim Varfecha As String
        Dim VarRecinto As String
        Dim VarVencimiento As String
        Dim vartotal As String
        Dim varsaldo As String
        Dim varsaldoTotal As String

        Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
        Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
        Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
        Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font1 As New Font("arial", 7, FontStyle.Bold)
        Dim Font2 As New Font("arial", 14, FontStyle.Regular)
        Dim Font3 As New Font("arial", 8, FontStyle.Regular)
        Dim Font4 As New Font("arial", 8, FontStyle.Bold)

        ' Dim im As Image

        Try
            ' ruta_logo_empresa_ticket = "C:\Sistema de ventas\Sucursales\" & SucursalSeleccionada & "\Logo de empresa\logo_ticket.jpg"

            'im = Image.FromFile(ruta_logo_empresa_ticket)
            Dim p As New PointF(0, 0)
            'e.Graphics.DrawImage(im, p)
            e.Graphics.DrawImage(Bytes_Imagen(Imagen_ticket), p)
        Catch
        End Try

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim rect1 As New Rectangle(10, 60, 270, 15)
        Dim rect2 As New Rectangle(10, 75, 270, 15)
        Dim rect3 As New Rectangle(10, 90, 270, 15)
        Dim rect4 As New Rectangle(10, 105, 270, 15)
        Dim rect5 As New Rectangle(10, 120, 270, 15)
        Dim rect6 As New Rectangle(10, 135, 270, 15)
        Dim rect7 As New Rectangle(10, 185, 270, 17)
        Dim rect15 As New Rectangle(10, 150, 270, 15)

        e.Graphics.DrawString(minombreempresa, Font3, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(migiroempresa, Font3, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font3, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font3, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font3, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font3, Brushes.Black, rect6, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font3, Brushes.Black, rect15, stringFormat)

        e.Graphics.DrawString("ESTADO DE CUENTA", Font2, Brushes.Black, rect7, stringFormat)

        e.Graphics.DrawString("NOMBRE", Font4, Brushes.Black, 0, 220)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 54, 220)
        e.Graphics.DrawString(txt_nombre_cliente.Text, Font3, Brushes.Black, 60, 220)
        e.Graphics.DrawString("RUT", Font4, Brushes.Black, 0, 235)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 54, 235)
        e.Graphics.DrawString(txt_rut_cliente.Text, Font3, Brushes.Black, 60, 235)

        Dim total_millar As String

        total_millar = txt_total_deuda.Text

        total_millar = Format(Int(total_millar), "###,###,###")

        e.Graphics.DrawString("DEUDA", Font4, Brushes.Black, 0, 250)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 54, 250)
        e.Graphics.DrawString(total_millar, Font3, Brushes.Black, 60, 250)

        e.Graphics.DrawString("EMISION", Font4, Brushes.Black, 0, 265)
        e.Graphics.DrawString(":", Font3, Brushes.Black, 54, 265)
        e.Graphics.DrawString(dtp_fecha.Text, Font3, Brushes.Black, 60, 265)

        'Dim rect_ingresa As New Rectangle(15, 293, 270, 22)

        ' e.Graphics.DrawString("INGRESA", Font2, Brushes.Black, rect_ingresa, stringFormat)

        e.Graphics.DrawString("DOCUMENTO", Font4, Brushes.Black, 0, 295)
        ' e.Graphics.DrawString("DESCRIPCION", Font4, Brushes.Black, 55, 308)
        e.Graphics.DrawString("FECHA", Font4, Brushes.Black, 109, 295)
        e.Graphics.DrawString("TOTAL", Font4, Brushes.Black, 180, 295)
        e.Graphics.DrawString("SALDO", Font4, Brushes.Black, 245, 295)
        e.Graphics.DrawLine(Pens.Black, 1, 310, 310, 310)

        Dim cuenta_ciclo As Integer

        cuenta_ciclo = 0

        For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1

            Varcoddocumento = grilla_estado_de_cuenta.Rows(i).Cells(0).Value.ToString
            VarTipo = grilla_estado_de_cuenta.Rows(i).Cells(1).Value.ToString
            Varfecha = grilla_estado_de_cuenta.Rows(i).Cells(2).Value
            VarRecinto = grilla_estado_de_cuenta.Rows(i).Cells(3).Value
            VarVencimiento = grilla_estado_de_cuenta.Rows(i).Cells(4).Value
            vartotal = grilla_estado_de_cuenta.Rows(i).Cells(5).Value.ToString
            varsaldo = grilla_estado_de_cuenta.Rows(i).Cells(6).Value.ToString
            varsaldoTotal = grilla_estado_de_cuenta.Rows(i).Cells(7).Value.ToString

            VarTipo = VarTipo & " " & Varcoddocumento

            If VarTipo.Length > 16 Then
                VarTipo = VarTipo.Substring(0, 16)
            End If

            varsaldo = Format(Int(varsaldo), "###,###,###")
            vartotal = Format(Int(vartotal), "###,###,###")
            varsaldoTotal = Format(Int(varsaldoTotal), "###,###,###")

            e.Graphics.DrawString(VarTipo, Font1, Brushes.Gray, 0, 311 + (i * 15))
            e.Graphics.DrawString(Varfecha, Font1, Brushes.Gray, 103, 311 + (i * 15))
            e.Graphics.DrawString(varsaldo, Font1, Brushes.Gray, 220, 311 + (i * 15), format1)
            e.Graphics.DrawString(varsaldoTotal, Font1, Brushes.Gray, 285, 311 + (i * 15), format1)

        Next

        Dim rect16 As New Rectangle(0, 505, 505 + (15 * grilla_estado_de_cuenta.Rows.Count + 30), 15)
        Dim rect17 As New Rectangle(0, 520, 520 + (15 * grilla_estado_de_cuenta.Rows.Count + 30), 15)

        e.Graphics.DrawString("           DATOS INFORMADOS ESTAN SUJETOS", Font3, Brushes.Black, 0, 265 + (15 * grilla_estado_de_cuenta.Rows.Count + 60))
        e.Graphics.DrawString("                             A CONFIRMACION.", Font3, Brushes.Black, 0, 280 + (15 * grilla_estado_de_cuenta.Rows.Count + 60))

        e.Graphics.DrawString("-", Font3, Brushes.Black, 139, 325 + (15 * grilla_estado_de_cuenta.Rows.Count + 60))

    End Sub








    Private Sub btn_aviso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aviso.Click
        Form_cobranzas.Show()
        Form_cobranzas.txt_rut_cliente.Text = txt_rut_cliente.Text

        If Form_cobranzas.txt_rut_cliente.Text <> "" Then
            Form_cobranzas.cargar_detalle()
            Form_cobranzas.mostrar_datos_clientes()
            Form_cobranzas.combo_tipo.SelectedItem = "-"
            Form_cobranzas.grilla_cobranzas.Columns(0).Width = 300
            Form_cobranzas.grilla_cobranzas.Columns(1).Width = 450
            Form_cobranzas.grilla_cobranzas.Columns(2).Width = 110
            Form_cobranzas.grilla_cobranzas.Columns(3).Width = 108
            Form_cobranzas.grilla_cobranzas.Columns(4).Width = 110
            Form_cobranzas.txt_detalle.Focus()
        End If

        Form_cobranzas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
    End Sub




    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

    End Sub

    Private Sub Print_ticket_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Print_ticket.PrintPage
        If txt_direccion_cliente.Text.Length > 23 Then
            txt_direccion_cliente.Text = txt_direccion_cliente.Text.Substring(0, 30)
        End If

        Dim Font_texto_titulo As New Font("arial", 9, FontStyle.Bold)
        Dim Font_texto_empresa As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_cabecera As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_titulo_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_totales As New Font("arial", 9, FontStyle.Bold)

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Try
            e.Graphics.DrawImage(Bytes_Imagen(Imagen_reporte), -74, 0, 440, 70)
        Catch
        End Try

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = 0
        margen_superior = 0

        Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 90, margen_izquierdo + 270, margen_superior + 15)
        Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 105, margen_izquierdo + 270, margen_superior + 15)
        Dim rect3 As New Rectangle(margen_izquierdo + 10, margen_superior + 120, margen_izquierdo + 270, margen_superior + 15)
        Dim rect4 As New Rectangle(margen_izquierdo + 10, margen_superior + 135, margen_izquierdo + 270, margen_superior + 15)
        Dim rect5 As New Rectangle(margen_izquierdo + 10, margen_superior + 150, margen_izquierdo + 270, margen_superior + 15)
        Dim rect6 As New Rectangle(margen_izquierdo + 10, margen_superior + 165, margen_izquierdo + 270, margen_superior + 15)
        Dim rect7 As New Rectangle(margen_izquierdo + 10, margen_superior + 180, margen_izquierdo + 270, margen_superior + 15)
        Dim rect_titulo As New Rectangle(margen_izquierdo + 10, margen_superior + 215, margen_izquierdo + 270, margen_superior + 15)
        Dim rect_fecha As New Rectangle(margen_izquierdo + 10, margen_superior + 235, margen_izquierdo + 270, margen_superior + 15)

        e.Graphics.DrawString(minombreempresa, Font_texto_empresa, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(migiroempresa, Font_texto_empresa, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font_texto_empresa, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font_texto_empresa, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font_texto_empresa, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font_texto_empresa, Brushes.Black, rect6, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font_texto_empresa, Brushes.Black, rect7, stringFormat)

        e.Graphics.DrawString("COMPROBANTE DE INGRESO", Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + 230, margen_izquierdo + 295, margen_superior + 230)
        e.Graphics.DrawString(Form_menu_principal.lbl_fecha.Text, Font_texto_titulo, Brushes.Gray, rect_fecha, stringFormat)

        e.Graphics.DrawString("NOMBRE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 275)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 275)
        e.Graphics.DrawString(txt_nombre_cliente.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 275)

        e.Graphics.DrawString("RUT", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 290)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 290)
        e.Graphics.DrawString(txt_rut_cliente.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 290)

        e.Graphics.DrawString("DEUDA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 305)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 90, margen_superior + 305)
        e.Graphics.DrawString("$" & txt_total_deuda.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 100, margen_superior + 305)

        e.Graphics.DrawString("TIPO DOC.", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 335)
        e.Graphics.DrawString("FECHA", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 90, margen_superior + 335)
        e.Graphics.DrawString("TOTAL", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 210, margen_superior + 335, format1)
        e.Graphics.DrawString("SALDO", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 285, margen_superior + 335, format1)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + 350, margen_izquierdo + 295, margen_superior + 350)

        Dim Varcoddocumento As String
        Dim VarTipo As String
        Dim Varfecha As String
        Dim VarRecinto As String
        Dim VarVencimiento As String
        Dim vartotal As String
        Dim varsaldo As String
        Dim varsaldoTotal As String
        Dim multiplicador_lineas As Integer = 15
        Dim numero_lineas As Integer = 0



        For i = numero_lineas_total To grilla_estado_de_cuenta.Rows.Count - 1
            Varcoddocumento = grilla_estado_de_cuenta.Rows(i).Cells(0).Value.ToString
            VarTipo = grilla_estado_de_cuenta.Rows(i).Cells(1).Value.ToString
            Varfecha = grilla_estado_de_cuenta.Rows(i).Cells(2).Value
            VarRecinto = grilla_estado_de_cuenta.Rows(i).Cells(3).Value
            VarVencimiento = grilla_estado_de_cuenta.Rows(i).Cells(4).Value
            vartotal = grilla_estado_de_cuenta.Rows(i).Cells(5).Value.ToString
            varsaldo = grilla_estado_de_cuenta.Rows(i).Cells(6).Value.ToString
            varsaldoTotal = grilla_estado_de_cuenta.Rows(i).Cells(7).Value.ToString

            If varsaldo = "" Or varsaldo = "0" Then
                varsaldo = "0"
            Else
                varsaldo = Format(Int(varsaldo), "###,###,###")
            End If

            If varsaldoTotal = "" Or varsaldoTotal = "0" Then
                varsaldoTotal = "0"
            Else
                varsaldoTotal = Format(Int(varsaldoTotal), "###,###,###")
            End If

            If Varfecha.Length > 10 Then
                Varfecha = Varfecha.Substring(0, 10)
            End If

            If VarTipo = "BOLETA" Then
                VarTipo = "BOL"
            End If

            If VarTipo = "FACTURA" Then
                VarTipo = "FAC"
            End If

            If VarTipo = "NOTA DE CREDITO" Then
                VarTipo = "NDC"
            End If

            If VarTipo = "NOTA DE DEBITO" Then
                VarTipo = "NDB"
            End If

            e.Graphics.DrawString(VarTipo & " " & Varcoddocumento, Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 355 + (numero_lineas * multiplicador_lineas))
            e.Graphics.DrawString(Varfecha, Font_texto_detalle, Brushes.Black, margen_izquierdo + 90, margen_superior + 355 + (numero_lineas * multiplicador_lineas))
            e.Graphics.DrawString(varsaldo, Font_texto_detalle, Brushes.Black, margen_izquierdo + 210, margen_superior + 355 + (numero_lineas * multiplicador_lineas), format1)
            e.Graphics.DrawString(varsaldoTotal, Font_texto_detalle, Brushes.Black, margen_izquierdo + 285, margen_superior + 355 + (numero_lineas * multiplicador_lineas), format1)

            numero_lineas = numero_lineas + 1
            numero_lineas_total = numero_lineas_total + 1


            If numero_lineas > 45 Then
                'Linea horizontal
                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + 355 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 295, margen_superior + 355 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************
                e.HasMorePages = True ' Todavia faltan mas paginas
                Exit Sub
            Else
                e.HasMorePages = False
            End If

        Next

        numero_lineas_total = 0

        numero_lineas = ((numero_lineas) * multiplicador_lineas)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + numero_lineas + 355, margen_izquierdo + 295, margen_superior + numero_lineas + 355)

        Dim rect_guion_mensaje_final As New Rectangle(margen_izquierdo + 10, margen_superior + numero_lineas + 240, margen_izquierdo + 270, margen_superior + numero_lineas + 15)
        e.Graphics.DrawString("DATOS INFORMADOS ESTAN SUJETOS A CONFIRMACION.", Font_texto_totales, Brushes.Gray, rect_guion_mensaje_final, stringFormat)

        Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + numero_lineas + 300, margen_izquierdo + 270, margen_superior + numero_lineas + 15)
        e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)
    End Sub

    Private Sub Print_carta_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Print_carta.PrintPage
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font_titulo As New Font("arial", 12, FontStyle.Regular)
        Dim Font_subtitulo As New Font("arial", 9, FontStyle.Regular)
        Dim Font_titulo_columna As New Font("verdana", 6.5, FontStyle.Bold)
        Dim Font_texto_impresion As New Font("verdana", 6.5, FontStyle.Regular)
        Dim Font_campos_superiores As New Font("verdana", 8, FontStyle.Regular)
        Dim Font_datos_empresa As New Font("verdana", 7, FontStyle.Regular)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = -30
        margen_superior = 0

        Try
            e.Graphics.DrawImage(Bytes_Imagen(Imagen_reporte), 560, 10, 260, 70)
        Catch
        End Try

        e.Graphics.DrawString(minombreempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 10)
        e.Graphics.DrawString(migiroempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 20)
        e.Graphics.DrawString(midireccionempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 30)
        e.Graphics.DrawString(micomunaempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 40)
        e.Graphics.DrawString(mitelefonoempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 50)
        e.Graphics.DrawString(mirutempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 60)

        Dim rect1 As New Rectangle(margen_izquierdo + 50, margen_superior + 85, margen_izquierdo + 810, margen_superior + 45)
        Dim rect2 As New Rectangle(margen_izquierdo + 50, margen_superior + 100, margen_izquierdo + 810, margen_superior + 60)

        e.Graphics.DrawString("ESTADO DE CUENTA", Font_titulo, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 118, margen_izquierdo + 865, margen_superior + 118)
        e.Graphics.DrawString(Form_menu_principal.lbl_fecha.Text, Font_subtitulo, Brushes.Gray, rect2, stringFormat)

        'If txt_nombre_cliente.Text.Length > 23 Then
        '    txt_nombre_cliente.Text = txt_nombre_cliente.Text.Substring(0, 23)
        'End If

        e.Graphics.DrawString("NOMBRE", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 150)
        e.Graphics.DrawString("RUT", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 165)
        e.Graphics.DrawString("DEUDA", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 180)

        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 100, margen_superior + 150)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 100, margen_superior + 165)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 100, margen_superior + 180)

        e.Graphics.DrawString(txt_nombre_cliente.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 110, margen_superior + 150)
        e.Graphics.DrawString(txt_rut_cliente.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 110, margen_superior + 165)
        e.Graphics.DrawString("$" & txt_total_deuda.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 110, margen_superior + 180)


        e.Graphics.DrawString("DIRECCION", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 150)
        e.Graphics.DrawString("TELEFONO", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 165)
        e.Graphics.DrawString("CIUDAD", Font_campos_superiores, Brushes.Black, margen_izquierdo + 500, margen_superior + 180)

        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 570, margen_superior + 150)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 570, margen_superior + 165)
        e.Graphics.DrawString(":", Font_campos_superiores, Brushes.Black, margen_izquierdo + 570, margen_superior + 180)

        e.Graphics.DrawString(txt_direccion_cliente.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 580, margen_superior + 150)
        e.Graphics.DrawString(txt_telefono.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 580, margen_superior + 165)
        e.Graphics.DrawString(txt_ciudad_cliente.Text, Font_campos_superiores, Brushes.Black, margen_izquierdo + 580, margen_superior + 180)

        e.Graphics.DrawString("DOCUMENTO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 50, margen_superior + 210)
        e.Graphics.DrawString("NUMERO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 150, margen_superior + 210)
        e.Graphics.DrawString("FECHA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 230, margen_superior + 210)
        e.Graphics.DrawString("SUCURSAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 320, margen_superior + 210)
        e.Graphics.DrawString("VENC.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 470, margen_superior + 210)
        e.Graphics.DrawString("TOTAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 600, margen_superior + 210, format1)
        e.Graphics.DrawString("SALDO DOC.", Font_titulo_columna, Brushes.Black, margen_izquierdo + 700, margen_superior + 210, format1)
        e.Graphics.DrawString("SALDO FINAL", Font_titulo_columna, Brushes.Black, margen_izquierdo + 800, margen_superior + 210, format1)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 225, margen_izquierdo + 865, margen_superior + 225)


        Dim Varcoddocumento As String
        Dim VarTipo As String
        Dim Varfecha As String
        Dim VarRecinto As String
        Dim VarVencimiento As String
        Dim vartotal As String
        Dim varsaldo As String
        Dim varsaldoTotal As String
        Dim multiplicador_lineas As Integer = 15
        Dim numero_lineas As Integer = 0

        For i = numero_lineas_total To grilla_estado_de_cuenta.Rows.Count - 1
            Varcoddocumento = grilla_estado_de_cuenta.Rows(i).Cells(0).Value.ToString
            VarTipo = grilla_estado_de_cuenta.Rows(i).Cells(1).Value.ToString
            Varfecha = grilla_estado_de_cuenta.Rows(i).Cells(2).Value
            VarRecinto = grilla_estado_de_cuenta.Rows(i).Cells(3).Value
            VarVencimiento = grilla_estado_de_cuenta.Rows(i).Cells(4).Value
            vartotal = grilla_estado_de_cuenta.Rows(i).Cells(5).Value.ToString
            varsaldo = grilla_estado_de_cuenta.Rows(i).Cells(6).Value.ToString
            varsaldoTotal = grilla_estado_de_cuenta.Rows(i).Cells(7).Value.ToString

            If vartotal = "" Or vartotal = "0" Then
                vartotal = "0"
            Else
                vartotal = Format(Int(vartotal), "###,###,###")
            End If

            If varsaldo = "" Or varsaldo = "0" Then
                varsaldo = "0"
            Else
                varsaldo = Format(Int(varsaldo), "###,###,###")
            End If

            If varsaldoTotal = "" Or varsaldoTotal = "0" Then
                varsaldoTotal = "0"
            Else
                varsaldoTotal = Format(Int(varsaldoTotal), "###,###,###")
            End If

            If Varfecha.Length > 10 Then
                Varfecha = Varfecha.Substring(0, 10)
            End If

            If VarVencimiento.Length > 10 Then
                VarVencimiento = VarVencimiento.Substring(0, 10)
            End If

            e.Graphics.DrawString(VarTipo, Font_texto_impresion, Brushes.Black, margen_izquierdo + 50, margen_superior + 230 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(Varcoddocumento, Font_texto_impresion, Brushes.Black, margen_izquierdo + 150, margen_superior + 230 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(Varfecha, Font_texto_impresion, Brushes.Black, margen_izquierdo + 230, margen_superior + 230 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarRecinto, Font_texto_impresion, Brushes.Black, margen_izquierdo + 320, margen_superior + 230 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarVencimiento, Font_texto_impresion, Brushes.Black, margen_izquierdo + 470, margen_superior + 230 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(vartotal, Font_texto_impresion, Brushes.Black, margen_izquierdo + 600, margen_superior + 230 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(varsaldo, Font_texto_impresion, Brushes.Black, margen_izquierdo + 700, margen_superior + 230 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(varsaldoTotal, Font_texto_impresion, Brushes.Black, margen_izquierdo + 800, margen_superior + 230 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************


            numero_lineas = numero_lineas + 1
            numero_lineas_total = numero_lineas_total + 1

            If numero_lineas > 50 Then
                'Linea horizontal
                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 230 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 230 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************
                e.HasMorePages = True ' Todavia faltan mas paginas
                Exit Sub
            Else
                e.HasMorePages = False
            End If
        Next

        'Linea horizontal
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 230 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 230 + (numero_lineas * multiplicador_lineas))
        '***************************************************************************************************************************************************

        e.Graphics.DrawString("DESGLOSE:", Font_titulo_columna, Brushes.Black, margen_izquierdo + 50, margen_superior + 250 + (numero_lineas * multiplicador_lineas))
        e.Graphics.DrawString(txt_desglose.Text & ".", Font_titulo_columna, Brushes.Gray, margen_izquierdo + 50, margen_superior + 265 + (numero_lineas * multiplicador_lineas))

        numero_lineas_total = 0
    End Sub
End Class