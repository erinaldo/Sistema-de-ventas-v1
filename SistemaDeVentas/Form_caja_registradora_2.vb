Imports System.Drawing.Drawing2D
Imports System
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.IO


Public Class Form_caja_registradora_2
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim consulta_busqueda As String
    Private WithEvents Pd As New PrintDocument
    Dim alto_cotizacion As String
    Dim peso As String
    Dim cantidad_letras As Integer
    Dim desglose_palabras As String

    Private Sub Form_caja_registradora_2_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F12 Then
            btn_abrir.PerformClick()
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

    Private Sub Form_caja_registradora_2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_caja_registradora_2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_logo()
        Check_estado.Checked = True

        mostrar_malla()

        grilla_estado_de_cuenta.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        grilla_detalle_documento.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        txt_efectivo.Focus()

        grilla_detalle_documento.Columns(0).Width = 50
        ' grilla_detalle_documento.Columns(1).Width = 250
        grilla_detalle_documento.Columns(2).Width = 50
        grilla_detalle_documento.Columns(3).Width = 50
        grilla_detalle_documento.Columns(4).Width = 50
        grilla_detalle_documento.Columns(5).Width = 50
        grilla_detalle_documento.Columns(6).Width = 50
        grilla_detalle_documento.Columns(7).Width = 50
        grilla_detalle_documento.Columns(8).Width = 100

    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub mostrar_malla()

        If Check_estado.Checked = True Then
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            SC2.Connection = conexion
            SC2.CommandText = "select  n_boleta as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', BOLETA.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL', porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR',  vuelto as 'VUELTO', estado_vuelto as 'ESTADO' from BOLETA, usuarios, clientes  where estado_vuelto = 'NO'  and fecha_venta ='" & (mifecha2) & "' and BOLETA.usuario_responsable=usuarios.rut_usuario and BOLETA.rut_cliente=clientes.rut_cliente and condiciones <> 'CREDITO' group by n_boleta order by n_boleta desc"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            grilla_estado_de_cuenta.Rows.Clear()
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1

                    'Try
                    '    estado_boleta = DS2.Tables(DT2.TableName).Rows(i).Item("ESTADO")
                    'Catch mierror As InvalidCastException
                    '    estado_boleta = "NO"
                    'Catch mierror As ArgumentException
                    '    estado_boleta = "NO"
                    'End Try
                    'Try
                    '    vuelto_boleta = DS2.Tables(DT2.TableName).Rows(i).Item("vuelto")
                    'Catch mierror As InvalidCastException
                    '    vuelto_boleta = "0"
                    'Catch mierror As ArgumentException
                    '    vuelto_boleta = "0"
                    'End Try

                    grilla_estado_de_cuenta.Rows.Add("BOLETA",
                                                      DS2.Tables(DT2.TableName).Rows(i).Item("NRO."),
                                                       DS2.Tables(DT2.TableName).Rows(i).Item("CONDIC."),
                                                        DS2.Tables(DT2.TableName).Rows(i).Item("FECHA"),
                                                         DS2.Tables(DT2.TableName).Rows(i).Item("RUT CLIENTE"),
                                                          DS2.Tables(DT2.TableName).Rows(i).Item("CLIENTE"),
                                                           DS2.Tables(DT2.TableName).Rows(i).Item("SUBTOTAL"),
                                                            DS2.Tables(DT2.TableName).Rows(i).Item("%"),
                                                             DS2.Tables(DT2.TableName).Rows(i).Item("DESC."),
                                                              DS2.Tables(DT2.TableName).Rows(i).Item("NETO"),
                                                               DS2.Tables(DT2.TableName).Rows(i).Item("IVA"),
                                                                DS2.Tables(DT2.TableName).Rows(i).Item("TOTAL"),
                                                                 DS2.Tables(DT2.TableName).Rows(i).Item("VENDEDOR"),
                                                                  DS2.Tables(DT2.TableName).Rows(i).Item("VUELTO"),
                                                                   DS2.Tables(DT2.TableName).Rows(i).Item("ESTADO"))
                Next
            End If

            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            SC2.Connection = conexion
            SC2.CommandText = "select  n_factura as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', FACTURA.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL', porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR', vuelto as 'VUELTO', estado_vuelto as 'ESTADO'  from factura, usuarios, clientes  where estado_vuelto = 'NO' and fecha_venta ='" & (mifecha2) & "' and factura.usuario_responsable=usuarios.rut_usuario and factura.rut_cliente=clientes.rut_cliente  and condiciones <> 'CREDITO' group by n_factura order by n_factura desc"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            'grilla_detalle_documento.Rows.Clear()
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                    'Try
                    '    estado_factura = DS2.Tables(DT2.TableName).Rows(i).Item("ESTADO")
                    'Catch mierror As InvalidCastException
                    '    estado_factura = "NO"
                    'Catch mierror As ArgumentException
                    '    estado_factura = "NO"
                    'End Try
                    'Try
                    '    vuelto_factura = DS2.Tables(DT2.TableName).Rows(i).Item("VUELTO")
                    'Catch mierror As InvalidCastException
                    '    vuelto_factura = "0"
                    'Catch mierror As ArgumentException
                    '    vuelto_factura = "0"
                    'End Try
                    grilla_estado_de_cuenta.Rows.Add("FACTURA",
                                                         DS2.Tables(DT2.TableName).Rows(i).Item("NRO."),
                                                        DS2.Tables(DT2.TableName).Rows(i).Item("CONDIC."),
                                                         DS2.Tables(DT2.TableName).Rows(i).Item("FECHA"),
                                                          DS2.Tables(DT2.TableName).Rows(i).Item("RUT CLIENTE"),
                                                           DS2.Tables(DT2.TableName).Rows(i).Item("CLIENTE"),
                                                            DS2.Tables(DT2.TableName).Rows(i).Item("SUBTOTAL"),
                                                             DS2.Tables(DT2.TableName).Rows(i).Item("%"),
                                                              DS2.Tables(DT2.TableName).Rows(i).Item("DESC."),
                                                               DS2.Tables(DT2.TableName).Rows(i).Item("NETO"),
                                                                DS2.Tables(DT2.TableName).Rows(i).Item("IVA"),
                                                                 DS2.Tables(DT2.TableName).Rows(i).Item("TOTAL"),
                                                                  DS2.Tables(DT2.TableName).Rows(i).Item("VENDEDOR"),
                                                                  DS2.Tables(DT2.TableName).Rows(i).Item("VUELTO"),
                                                                   DS2.Tables(DT2.TableName).Rows(i).Item("ESTADO"))
                Next
            End If
        End If

        If Check_estado.Checked = False Then
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            SC2.Connection = conexion
            SC2.CommandText = "select  n_boleta as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', BOLETA.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL', porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR',  vuelto as 'VUELTO', estado_vuelto as 'ESTADO' from BOLETA, usuarios, clientes  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and BOLETA.usuario_responsable=usuarios.rut_usuario and BOLETA.rut_cliente=clientes.rut_cliente and condiciones <> 'CREDITO' group by n_boleta order by n_boleta desc"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            grilla_estado_de_cuenta.Rows.Clear()
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                    'Try
                    '    estado_boleta = DS2.Tables(DT2.TableName).Rows(i).Item("ESTADO")
                    'Catch mierror As InvalidCastException
                    '    estado_boleta = "NO"
                    'Catch mierror As ArgumentException
                    '    estado_boleta = "NO"
                    'End Try
                    'Try
                    '    vuelto_boleta = DS2.Tables(DT2.TableName).Rows(i).Item("vuelto")
                    'Catch mierror As InvalidCastException
                    '    vuelto_boleta = "0"
                    'Catch mierror As ArgumentException
                    '    vuelto_boleta = "0"
                    'End Try
                    grilla_estado_de_cuenta.Rows.Add("BOLETA",
                                                      DS2.Tables(DT2.TableName).Rows(i).Item("NRO."),
                                                       DS2.Tables(DT2.TableName).Rows(i).Item("CONDIC."),
                                                        DS2.Tables(DT2.TableName).Rows(i).Item("FECHA"),
                                                         DS2.Tables(DT2.TableName).Rows(i).Item("RUT CLIENTE"),
                                                          DS2.Tables(DT2.TableName).Rows(i).Item("CLIENTE"),
                                                           DS2.Tables(DT2.TableName).Rows(i).Item("SUBTOTAL"),
                                                            DS2.Tables(DT2.TableName).Rows(i).Item("%"),
                                                             DS2.Tables(DT2.TableName).Rows(i).Item("DESC."),
                                                              DS2.Tables(DT2.TableName).Rows(i).Item("NETO"),
                                                               DS2.Tables(DT2.TableName).Rows(i).Item("IVA"),
                                                                DS2.Tables(DT2.TableName).Rows(i).Item("TOTAL"),
                                                                 DS2.Tables(DT2.TableName).Rows(i).Item("VENDEDOR"),
                                                                  DS2.Tables(DT2.TableName).Rows(i).Item("VUELTO"),
                                                                   DS2.Tables(DT2.TableName).Rows(i).Item("ESTADO"))
                Next
            End If

            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            SC2.Connection = conexion
            SC2.CommandText = "select  n_factura as 'NRO.', condiciones as 'CONDIC.', fecha_venta as 'FECHA', FACTURA.rut_cliente as 'RUT CLIENTE', nombre_cliente as 'CLIENTE', subtotal as 'SUBTOTAL', porcentaje_desc '%', descuento as 'DESC.', neto as 'NETO', iva as 'IVA', total as 'TOTAL', nombre_usuario as 'VENDEDOR', vuelto as 'VUELTO', estado_vuelto as 'ESTADO'  from factura, usuarios, clientes  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and factura.usuario_responsable=usuarios.rut_usuario and factura.rut_cliente=clientes.rut_cliente  and condiciones <> 'CREDITO' group by n_factura order by n_factura desc"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            'grilla_detalle_documento.Rows.Clear()
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                    'Try
                    '    estado_factura = DS2.Tables(DT2.TableName).Rows(i).Item("ESTADO")
                    'Catch mierror As InvalidCastException
                    '    estado_factura = "NO"
                    'Catch mierror As ArgumentException
                    '    estado_factura = "NO"
                    'End Try
                    'Try
                    '    vuelto_factura = DS2.Tables(DT2.TableName).Rows(i).Item("VUELTO")
                    'Catch mierror As InvalidCastException
                    '    vuelto_factura = "0"
                    'Catch mierror As ArgumentException
                    '    vuelto_factura = "0"
                    'End Try
                    grilla_estado_de_cuenta.Rows.Add("FACTURA",
                                                         DS2.Tables(DT2.TableName).Rows(i).Item("NRO."),
                                                        DS2.Tables(DT2.TableName).Rows(i).Item("CONDIC."),
                                                         DS2.Tables(DT2.TableName).Rows(i).Item("FECHA"),
                                                          DS2.Tables(DT2.TableName).Rows(i).Item("RUT CLIENTE"),
                                                           DS2.Tables(DT2.TableName).Rows(i).Item("CLIENTE"),
                                                            DS2.Tables(DT2.TableName).Rows(i).Item("SUBTOTAL"),
                                                             DS2.Tables(DT2.TableName).Rows(i).Item("%"),
                                                              DS2.Tables(DT2.TableName).Rows(i).Item("DESC."),
                                                               DS2.Tables(DT2.TableName).Rows(i).Item("NETO"),
                                                                DS2.Tables(DT2.TableName).Rows(i).Item("IVA"),
                                                                 DS2.Tables(DT2.TableName).Rows(i).Item("TOTAL"),
                                                                  DS2.Tables(DT2.TableName).Rows(i).Item("VENDEDOR"),
                                                                   DS2.Tables(DT2.TableName).Rows(i).Item("VUELTO"),
                                                                   DS2.Tables(DT2.TableName).Rows(i).Item("ESTADO"))
                Next
            End If
        End If

        grilla_detalle_documento.Rows.Clear()

        Dim estado_vuelto As String
        For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1
            estado_vuelto = grilla_estado_de_cuenta.Rows(i).Cells(14).Value.ToString
            If estado_vuelto = "SI" Then
                grilla_estado_de_cuenta.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If
        Next

        If grilla_estado_de_cuenta.Rows.Count <> 0 Then

            If grilla_estado_de_cuenta.Columns(0).Width = 100 Then
                grilla_estado_de_cuenta.Columns(0).Width = 99
            Else
                grilla_estado_de_cuenta.Columns(0).Width = 100
            End If
        End If
        grilla_estado_de_cuenta.Columns(14).SortMode = True
        grilla_estado_de_cuenta.Sort(grilla_estado_de_cuenta.Columns(14), System.ComponentModel.ListSortDirection.Ascending)
    End Sub












    Sub mostrar_malla_detalle()

        If combo_venta.Text = "BOLETA" Then
            Dim nro_doc As String
            nro_doc = grilla_estado_de_cuenta.CurrentRow.Cells(1).Value

            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            SC2.Connection = conexion
            SC2.CommandText = "select * from detalle_boleta  where n_boleta= '" & (nro_doc) & "'"

            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            grilla_detalle_documento.Rows.Clear()

            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then

                For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                    grilla_detalle_documento.Rows.Add(DS2.Tables(DT2.TableName).Rows(i).Item("cod_producto"),
                                                       DS2.Tables(DT2.TableName).Rows(i).Item("detalle_nombre"),
                                                        DS2.Tables(DT2.TableName).Rows(i).Item("valor_unitario"),
                                                         DS2.Tables(DT2.TableName).Rows(i).Item("cantidad"),
                                                          DS2.Tables(DT2.TableName).Rows(i).Item("detalle_subtotal"),
                                                           DS2.Tables(DT2.TableName).Rows(i).Item("detalle_descuento"),
                                                            DS2.Tables(DT2.TableName).Rows(i).Item("detalle_neto"),
                                                             DS2.Tables(DT2.TableName).Rows(i).Item("detalle_iva"),
                                                              DS2.Tables(DT2.TableName).Rows(i).Item("detalle_total"),
                                                               DS2.Tables(DT2.TableName).Rows(i).Item("numero_tecnico"))
                Next
            End If
        End If

        If combo_venta.Text = "FACTURA" Then
            Dim nro_doc As String
            nro_doc = grilla_estado_de_cuenta.CurrentRow.Cells(1).Value

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_factura  where n_factura= '" & (nro_doc) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_detalle_documento.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"),
                                                       DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"),
                                                        DS.Tables(DT.TableName).Rows(i).Item("valor_unitario"),
                                                         DS.Tables(DT.TableName).Rows(i).Item("cantidad"),
                                                          DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal"),
                                                           DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento"),
                                                            DS.Tables(DT.TableName).Rows(i).Item("detalle_neto"),
                                                             DS.Tables(DT.TableName).Rows(i).Item("detalle_iva"),
                                                              DS.Tables(DT.TableName).Rows(i).Item("detalle_total"),
                                                               DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"))
                Next
            End If
        End If



    End Sub










    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub




    Private Sub Combo_vendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    End Sub

    Private Sub Combo_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False



        lbl_mensaje.Visible = False
        Me.Enabled = True


    End Sub




    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage




    End Sub



    Private Sub combo_venta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_venta.GotFocus
        combo_venta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_venta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_venta.LostFocus
        combo_venta.BackColor = Color.White
    End Sub

    Private Sub txt_buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = " "
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = " "
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            lbl_mensaje.Visible = True
            Me.Enabled = False


            lbl_mensaje.Visible = False
            Me.Enabled = True
        End If
    End Sub

    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_venta.SelectedIndexChanged


    End Sub

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






    Private Sub txt_efectivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_efectivo.KeyPress
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



        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            If txt_vuelto.Text <> "" Then
                btn_abrir.PerformClick()
            End If




        End If
    End Sub



    Sub calcular_vuelto()




        If grilla_estado_de_cuenta.Rows.Count = 0 Then
            txt_vuelto.Text = "0"
            Exit Sub
        End If

        Dim total As Integer
        Dim vuelto As Long

        total = grilla_estado_de_cuenta.CurrentRow.Cells(11).Value

        vuelto = Val(txt_efectivo.Text) - Val(total)


        If vuelto < 0 Then
            txt_vuelto.Text = "0"
        Else
            txt_vuelto.Text = vuelto
        End If


        If txt_vuelto.Text = "" Or txt_vuelto.Text = "0" Then
            txt_vuelto.Text = "0"
        Else
            txt_vuelto.Text = Format(Int(txt_vuelto.Text), "###,###,###")
        End If

    End Sub
    Private Sub txt_efectivo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_efectivo.GotFocus
        txt_efectivo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_efectivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_efectivo.LostFocus
        txt_efectivo.BackColor = Color.White
    End Sub

    Private Sub txt_efectivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_efectivo.TextChanged
        calcular_vuelto()
    End Sub

    Private Sub grilla_documento_Click1(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub btn_abrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_abrir.Click







        lbl_mensaje.Visible = True
        Me.Enabled = False


        'If combo_condiciones.Text <> grilla_estado_de_cuenta.CurrentRow.Cells(1).Value Then
        '    Dim valormensaje As Integer
        '    valormensaje = MsgBox("LA CONDICION DE PAGO ES DISTINTA A LA DEL DOCUMENTO, ¿DESEA CONTINUAR?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        '    If valormensaje = vbYes Then

        '        If combo_venta.Text = "FACTURA" Then
        '            SC.Connection = conexion
        '            SC.CommandText = "UPDATE factura SET condiciones='" & (combo_condiciones.Text) & "' WHERE n_factura='" & (grilla_estado_de_cuenta.CurrentRow.Cells(0).Value) & "'"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        End If

        '        If combo_venta.Text = "BOLETA" Then
        '            SC.Connection = conexion
        '            SC.CommandText = "UPDATE BOLETA SET condiciones='" & (combo_condiciones.Text) & "' WHERE n_boleta='" & (grilla_estado_de_cuenta.CurrentRow.Cells(0).Value) & "'"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        End If

        '    End If
        '    If valormensaje = vbNo Then
        '        lbl_mensaje.Visible = False
        '        Me.Enabled = True
        '        Exit Sub
        '    End If
        'End If

        With Pd.PrinterSettings
            'Especifico el nombre de la impresora 
            'por donde deseo imprimir. 

            '.PrinterName = "Microsoft Print to PDF"
            .PrinterName = "\\CAJA-PC\Generic / Text Only"
            '.PrinterName = "\\CAJA-PC\BIXOLON SRP-350plus"

            'Establezco el número de copias que se imprimirán 
            .Copies = 1
            'Rango de páginas que se imprimirán 
            .PrintRange = PrintRange.AllPages

            If .IsValid Then

                Me.Pd.PrintController = New StandardPrintController
                Dim pkCustomSize1 As New PaperSize("New Long Roll", 0, 0)
                Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                'Exit Sub

                Pd.Print()

                'MsgBox("EL NRO. DE TICKET ES: " & txt_factura.Text, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")


                ' Form_impreso_corectamente.Show()
                '  Exit Sub
            Else
                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                '  Me.Enabled = True
                lbl_mensaje.Visible = False
                Me.Enabled = True
                Exit Sub
            End If
        End With


































        Dim vuelto As String

        vuelto = txt_vuelto.Text
        vuelto = Trim(Replace(vuelto, ".", ""))



        'If IsNumeric(vuelto) = False Then
        '    lbl_mensaje.Visible = False
        '    Me.Enabled = True
        '    Exit Sub
        'End If

        'If combo_venta.Text <> "EFECTIVO" Then
        '    If vuelto = "" Or vuelto = "0" Then
        '        vuelto = "1"
        '    End If
        'End If
        Try
            If combo_venta.Text = "FACTURA" Then
                SC.Connection = conexion
                SC.CommandText = "UPDATE factura SET vuelto='" & (vuelto) & "', estado_vuelto='SI' WHERE n_factura='" & (grilla_estado_de_cuenta.CurrentRow.Cells(1).Value) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If


            If combo_venta.Text = "BOLETA" Then
                SC.Connection = conexion
                SC.CommandText = "UPDATE BOLETA SET vuelto='" & (vuelto) & "', estado_vuelto='SI'  WHERE n_boleta='" & (grilla_estado_de_cuenta.CurrentRow.Cells(1).Value) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
        Catch
        End Try

        mostrar_malla()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub




    Private Sub btn_abrir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_abrir.GotFocus
        btn_abrir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_abrir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_abrir.LostFocus
        btn_abrir.BackColor = Color.Transparent
    End Sub



    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub



    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub


    Private Sub btn_detalle_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_detalle.GotFocus
        btn_detalle.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_detalle_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_detalle.LostFocus
        btn_detalle.BackColor = Color.Transparent
    End Sub

    Private Sub btn_calcular_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_calcular.GotFocus
        btn_calcular.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_calcular_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_calcular.LostFocus
        btn_calcular.BackColor = Color.Transparent
    End Sub






    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        mostrar_malla()

        lbl_mensaje.Visible = False
        Me.Enabled = True


    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub grilla_estado_de_cuenta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_estado_de_cuenta.CellContentClick

    End Sub

    Private Sub grilla_estado_de_cuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_estado_de_cuenta.Click


        txt_efectivo.Text = ""
        txt_vuelto.Text = ""

        If grilla_estado_de_cuenta.Rows.Count = 0 Then
            Exit Sub
        End If

        mostrar_malla_detalle()
        txt_efectivo.Focus()

    End Sub

    Private Sub btn_calcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_calcular.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        Form_caja_diaria.Show()

        lbl_mensaje.Visible = False
        Me.Enabled = True

    End Sub

    Private Sub btn_detalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_detalle.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        Form_detalle_cuadratura_caja.Show()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub










































































    ' Structure and API declarations:
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
    Public Class DOCINFOA
        <MarshalAs(UnmanagedType.LPStr)>
        Public pDocName As String
        <MarshalAs(UnmanagedType.LPStr)>
        Public pOutputFile As String
        <MarshalAs(UnmanagedType.LPStr)>
        Public pDataType As String
    End Class
    <DllImport("winspool.Drv", EntryPoint:="OpenPrinterA",
    SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True,
    CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function OpenPrinter(<MarshalAs(UnmanagedType.LPStr)> ByVal _
    szPrinter As String, ByRef hPrinter As IntPtr, ByVal pd As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="ClosePrinter",
    SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="StartDocPrinterA",
    SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True,
    CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Int32,
    <[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal di As DOCINFOA) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="EndDocPrinter",
    SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="StartPagePrinter",
    SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="EndPagePrinter",
    SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="WritePrinter",
    SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr,
    ByVal dwCount As Int32, ByRef dwWritten As Int32) As Boolean
    End Function

    Private hPrinter As New IntPtr(0)
    Private di As New DOCINFOA()
    Private PrinterOpen As Boolean = False

    Public ReadOnly Property PrinterIsOpen() As Boolean
        Get
            PrinterIsOpen = PrinterOpen
        End Get
    End Property

    Public Function OpenPrint(ByVal szPrinterName As String) As Boolean
        If PrinterOpen = False Then
            di.pDocName = ".NET RAW Document"
            di.pDataType = "RAW"

            If OpenPrinter(szPrinterName.Normalize(), hPrinter, IntPtr.Zero) Then
                ' Start a document.
                If StartDocPrinter(hPrinter, 1, di) Then
                    If StartPagePrinter(hPrinter) Then
                        PrinterOpen = True
                    End If
                End If
            End If
        End If

        OpenPrint = PrinterOpen
    End Function

    Public Sub ClosePrint()
        If PrinterOpen Then
            EndPagePrinter(hPrinter)
            EndDocPrinter(hPrinter)
            ClosePrinter(hPrinter)
            PrinterOpen = False
        End If
    End Sub

    Public Function SendStringToPrinter(ByVal szPrinterName As String, ByVal szString As String) As Boolean
        'If PrinterOpen Then
        '    Dim pBytes As IntPtr
        '    Dim dwCount As Int32
        '    Dim dwWritten As Int32 = 0

        '    dwCount = szString.Length

        '    pBytes = Marshal.StringToCoTaskMemAnsi(szString)

        '    SendStringToPrinter = WritePrinter(hPrinter, pBytes, dwCount, dwWritten)

        '    Marshal.FreeCoTaskMem(pBytes)
        'Else
        '    SendStringToPrinter = False
        'End If

        Dim pBytes As IntPtr
        Dim dwCount As Int32
        Dim dwWritten As Int32 = 0

        dwCount = szString.Length

        pBytes = Marshal.StringToCoTaskMemAnsi(szString)

        SendStringToPrinter = WritePrinter(hPrinter, pBytes, dwCount, dwWritten)

        Marshal.FreeCoTaskMem(pBytes)

    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim s As String
        Dim pd As New PrintDialog()

        ' You need a string to send.
        s = "27,110,0,25,250"
        ' Open the printer dialog box, and then allow the user to select a printer.
        pd.PrinterSettings = New PrinterSettings()
        If (pd.ShowDialog() = DialogResult.OK) Then
            SendStringToPrinter(pd.PrinterSettings.PrinterName, s)
            'SendStringToPrinter(pd.PrinterSettings.PrinterName, Chr(27) & Chr(110) & Chr(0) & Chr(25) & Chr(250))
        End If

        ' SendStringToPrinter(Pd.PrinterSettings.PrinterName = "\\CAJA-PC\BIXOLON SRP-350plus (Copiar 1)", Chr(27) & Chr(110) & Chr(0) & Chr(25) & Chr(250))


        'SendStringToPrinter(Pd.PrinterSettings.PrinterName = "\\CAJA-PC\BIXOLON SRP-350plus (Copiar 1)", "27,110,0,25,250")




        'With pd.PrinterSettings
        '    'Especifico el nombre de la impresora 
        '    'por donde deseo imprimir. 
        '    '.PrinterName = "Microsoft Print to PDF"
        '    '.PrinterName = "\\CAJA-PC\Generic / Text Only"
        '    .PrinterName = "\\CAJA-PC\BIXOLON SRP-350plus (Copiar 1)"
        '    'Establezco el número de copias que se imprimirán 
        '    .Copies = 1
        '    'Rango de páginas que se imprimirán 
        '    .PrintRange = PrintRange.AllPages
        '    If .IsValid Then

        '        SendStringToPrinter(pd.PrinterSettings.PrinterName, Chr(27) & Chr(110) & Chr(0) & Chr(25) & Chr(250))
        '    Else
        '        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
        '        '  Me.Enabled = True
        '        lbl_mensaje.Visible = False
        '        Me.Enabled = True
        '        Exit Sub
        '    End If
        'End With

    End Sub

End Class