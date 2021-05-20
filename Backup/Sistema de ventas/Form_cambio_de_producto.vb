Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Math
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D

Public Class Form_cambio_de_producto
    Dim peso As String
    Dim alto_cotizacion As String
    Private WithEvents Pd As New PrintDocument
    Dim mifecha2 As String
    Dim desglose_saldo As String
    Dim documento_tipo As String
    Dim tipo_impresion As String

    Private Sub Form_cambio_de_producto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_cambio_de_producto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

        If e.KeyCode = Keys.F1 Then
            txt_codigo.Focus()
        End If

        If e.KeyCode = Keys.F2 Then
            If grilla_detalle_venta.Rows.Count > 0 Then
                grilla_detalle_venta.Rows.Remove(grilla_detalle_venta.CurrentRow)
                calcular_totales_entra()
                calcular_totales_sale()
                txt_codigo.Focus()
            End If
        End If

        If e.KeyCode = Keys.F12 Then
            If txt_porcentaje_desc.Focused = True Then
                btn_grabar.PerformClick()
                Exit Sub
            Else
                txt_porcentaje_desc.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Form_cambio_de_producto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        Me.Enabled = False
        dtp_fecha.CustomFormat = "yyy-MM-dd"
        controles(False, True)
        grilla_detalle_venta.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)
        grilla_detalle_venta_entra.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)
        Form_cargar_documento_cambio_producto.Show()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub


    Sub calcular_totales_entra()
        Dim netogrilla As Long
        Dim ivagrilla As Long
        Dim totalgrilla As Long
        Dim subtotalgrilla As Long

        '//Calcular el total neto
        txt_neto_entra.Text = 0
        For i = 0 To grilla_detalle_venta_entra.Rows.Count - 1
            netogrilla = Val(grilla_detalle_venta_entra.Rows(i).Cells(5).Value.ToString)
            txt_neto_entra.Text = Val(txt_neto_entra.Text) + Val(netogrilla)
        Next

        '//Calcular el total iva
        txt_iva_entra.Text = 0
        For i = 0 To grilla_detalle_venta_entra.Rows.Count - 1
            ivagrilla = Val(grilla_detalle_venta_entra.Rows(i).Cells(6).Value.ToString)
            txt_iva_entra.Text = Val(txt_iva_entra.Text) + Val(ivagrilla)
        Next

        '//Calcular el sub-total 
        txt_sub_total_entra.Text = 0
        For i = 0 To grilla_detalle_venta_entra.Rows.Count - 1
            subtotalgrilla = Val(grilla_detalle_venta_entra.Rows(i).Cells(10).Value.ToString)
            txt_sub_total_entra.Text = Val(txt_sub_total_entra.Text) + Val(subtotalgrilla)
        Next

        '//Calcular el total general
        txt_total_entra.Text = 0
        For i = 0 To grilla_detalle_venta_entra.Rows.Count - 1
            totalgrilla = Val(grilla_detalle_venta_entra.Rows(i).Cells(10).Value.ToString)
            txt_total_entra.Text = Val(txt_total_entra.Text) + Val(totalgrilla)
        Next

        Dim descuento_porcentaje As Integer
        Dim porcentaje_desc As Integer

        If txt_porcentaje_desc_entra.Text = "" Or txt_porcentaje_desc_entra.Text = "-" Then
            porcentaje_desc = 0
        Else
            porcentaje_desc = txt_porcentaje_desc_entra.Text
        End If

        descuento_porcentaje = ((txt_total_entra.Text) * porcentaje_desc) / 100
        txt_desc_entra.Text = descuento_porcentaje
        txt_total_entra.Text = Int(txt_sub_total_entra.Text) - Int(txt_desc_entra.Text)

        Dim iva As Integer
        Dim neto As Integer
        Dim iva_valor As String

        iva_valor = valor_iva / 100 + 1
        neto = (txt_total_entra.Text / iva_valor)
        Round(neto)
        txt_neto_entra.Text = neto

        iva = ((txt_neto_entra.Text) * valor_iva / 100)
        Round(iva)
        txt_iva_entra.Text = iva

        iva_valor = valor_iva / 100 + 1
        txt_neto_entra.Text = Round(txt_total_entra.Text / iva_valor)
        txt_iva_entra.Text = (((txt_neto_entra.Text) * valor_iva) / 100)
        txt_iva_entra.Text = (txt_total_entra.Text) - (txt_neto_entra.Text)

        If txt_sub_total_entra.Text = "" Or txt_sub_total_entra.Text = "0" Then
            txt_sub_total_entra_millar.Text = "0"
        Else
            txt_sub_total_entra_millar.Text = Format(Int(txt_sub_total_entra.Text), "###,###,###")
        End If
        If txt_desc_entra.Text = "" Or txt_desc_entra.Text = "0" Then
            txt_desc_entra_millar.Text = "0"
        Else
            txt_desc_entra_millar.Text = Format(Int(txt_desc_entra.Text), "###,###,###")
        End If
        If txt_neto_entra.Text = "" Or txt_neto_entra.Text = "0" Then
            txt_neto_entra_millar.Text = "0"
        Else
            txt_neto_entra_millar.Text = Format(Int(txt_neto_entra.Text), "###,###,###")
        End If
        If txt_iva_entra.Text = "" Or txt_iva_entra.Text = "0" Then
            txt_iva_entra_millar.Text = "0"
        Else
            txt_iva_entra_millar.Text = Format(Int(txt_iva_entra.Text), "###,###,###")
        End If
        If txt_total_entra.Text = "" Or txt_total_entra.Text = "0" Then
            txt_total_entra_millar.Text = "0"
        Else
            txt_total_entra_millar.Text = Format(Int(txt_total_entra.Text), "###,###,###")
        End If

        lbl_venta.Text = Int(txt_total_sale.Text) - Int(txt_total_entra.Text)

        If lbl_venta.Text = "" Then
            lbl_venta.Text = "0"
        End If

        If Int(lbl_venta.Text) < 10 Then
            lbl_venta.ForeColor = Color.Red
            lbl_documento.Text = "VALE DE CAMBIO:"
            lbl_mensaje_doc.Text = "SALDO A FAVOR DE CLIENTE $:"
        ElseIf Int(lbl_venta.Text) > 10 And Int(lbl_venta.Text) <> 0 Then
            lbl_venta.ForeColor = Color.Blue
            lbl_documento.Text = "BOLETA:"
            lbl_mensaje_doc.Text = "CANCELAR EN CAJA $:"
        End If

        If lbl_venta.Text = "" Or lbl_venta.Text = "0" Then
            lbl_venta.Text = "0"
        Else
            lbl_venta.Text = Format(Int(lbl_venta.Text), "###,###,###")
        End If

        lbl_venta.Text = Replace(lbl_venta.Text, "-", "")
    End Sub

    Sub calcular_totales_sale()
        Dim netogrilla As Long
        Dim ivagrilla As Long
        Dim totalgrilla As Long
        Dim subtotalgrilla As Long

        '//Calcular el total neto
        txt_neto_sale.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            netogrilla = Val(grilla_detalle_venta.Rows(i).Cells(5).Value.ToString)
            txt_neto_sale.Text = Val(txt_neto_sale.Text) + Val(netogrilla)
        Next

        '//Calcular el total iva
        txt_iva_sale.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            ivagrilla = Val(grilla_detalle_venta.Rows(i).Cells(6).Value.ToString)
            txt_iva_sale.Text = Val(txt_iva_sale.Text) + Val(ivagrilla)
        Next

        '//Calcular el sub-total 
        txt_sub_total.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            subtotalgrilla = Val(grilla_detalle_venta.Rows(i).Cells(10).Value.ToString)
            txt_sub_total.Text = Val(txt_sub_total.Text) + Val(subtotalgrilla)
        Next

        '//Calcular el total general
        txt_total_sale.Text = 0
        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            totalgrilla = Val(grilla_detalle_venta.Rows(i).Cells(10).Value.ToString)
            txt_total_sale.Text = Val(txt_total_sale.Text) + Val(totalgrilla)
        Next

        Dim descuento_porcentaje As Integer
        Dim porcentaje_desc As Integer

        If txt_porcentaje_desc.Text = "" Or txt_porcentaje_desc.Text = "-" Then
            porcentaje_desc = 0
        Else
            porcentaje_desc = txt_porcentaje_desc.Text
        End If

        descuento_porcentaje = ((txt_total_sale.Text) * porcentaje_desc) / 100
        txt_desc.Text = descuento_porcentaje

        txt_total_sale.Text = Int(txt_sub_total.Text) - Int(txt_desc.Text)

        Dim iva As Integer
        Dim neto As Integer
        Dim iva_valor As String

        iva_valor = valor_iva / 100 + 1
        neto = (txt_total_sale.Text / iva_valor)
        Round(neto)
        txt_neto_sale.Text = neto

        iva = ((txt_neto_sale.Text) * valor_iva / 100)
        Round(iva)
        txt_iva_sale.Text = iva

        iva_valor = valor_iva / 100 + 1

        txt_neto_sale.Text = Round(txt_total_sale.Text / iva_valor)

        txt_iva_sale.Text = (((txt_neto_sale.Text) * valor_iva) / 100)

        txt_iva_sale.Text = (txt_total_sale.Text) - (txt_neto_sale.Text)

        lbl_venta.Text = Int(txt_total_sale.Text) - Int(txt_total_entra.Text)

        If lbl_venta.Text = "" Then
            lbl_venta.Text = "0"
        End If

        If Int(lbl_venta.Text) < 10 Then
            lbl_venta.ForeColor = Color.Red
            lbl_documento.Text = "VALE DE CAMBIO:"

            If Int(lbl_venta.Text) > -10 Then
                lbl_venta.ForeColor = SystemColors.Control
                lbl_mensaje_doc.Text = "AJUSTE COMPLETO"
            Else
                lbl_mensaje_doc.Text = "SALDO A FAVOR DE CLIENTE $:"
            End If

        ElseIf Int(lbl_venta.Text) >= 10 And Int(lbl_venta.Text) <> 0 Then
            lbl_venta.ForeColor = Color.Blue
            lbl_documento.Text = "BOLETA:"
            lbl_mensaje_doc.Text = "CANCELAR EN CAJA $:"
        End If

        If lbl_venta.Text = "" Or lbl_venta.Text = "0" Then
            lbl_venta.Text = "0"
        Else
            lbl_venta.Text = Format(Int(lbl_venta.Text), "###,###,###")
        End If

        lbl_venta.Text = Replace(lbl_venta.Text, "-", "")

        If txt_sub_total.Text = "" Or txt_sub_total.Text = "0" Then
            txt_sub_total_millar.Text = "0"
        Else
            txt_sub_total_millar.Text = Format(Int(txt_sub_total.Text), "###,###,###")
        End If
        If txt_desc.Text = "" Or txt_desc.Text = "0" Then
            txt_desc_millar.Text = "0"
        Else
            txt_desc_millar.Text = Format(Int(txt_desc.Text), "###,###,###")
        End If
        If txt_neto_sale.Text = "" Or txt_neto_sale.Text = "0" Then
            txt_neto_millar.Text = "0"
        Else
            txt_neto_millar.Text = Format(Int(txt_neto_sale.Text), "###,###,###")
        End If
        If txt_iva_sale.Text = "" Or txt_iva_sale.Text = "0" Then
            txt_iva_millar.Text = "0"
        Else
            txt_iva_millar.Text = Format(Int(txt_iva_sale.Text), "###,###,###")
        End If
        If txt_total_sale.Text = "" Or txt_total_sale.Text = "0" Then
            txt_total_millar.Text = "0"
        Else
            txt_total_millar.Text = Format(Int(txt_total_sale.Text), "###,###,###")
        End If

        peso = " PESOS"
        If CInt(lbl_venta.Text) = 1000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & " DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 2000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 3000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 4000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 5000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 6000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 7000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 8000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 9000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 10000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 11000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 12000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 13000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 14000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 15000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 16000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 17000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 18000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 19000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 20000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 21000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 22000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 23000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 24000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 25000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 26000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 27000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 28000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 29000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        ElseIf CInt(lbl_venta.Text) = 30000000 Then
            desglose_saldo = Num2Text(lbl_venta.Text) & "DE PESOS"
        Else
            desglose_saldo = Num2Text(lbl_venta.Text) & peso
        End If
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

    Private Sub btn_quitar_entra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_entra.Click
        If grilla_detalle_venta_entra.Rows.Count = 1 Then
            grilla_detalle_venta_entra.Rows.Remove(grilla_detalle_venta_entra.CurrentRow)
            calcular_totales_entra()
            txt_codigo.Focus()
            Form_cargar_documento_cambio_producto.Show()
            Exit Sub
        End If

        If grilla_detalle_venta_entra.Rows.Count > 0 Then
            grilla_detalle_venta_entra.Rows.Remove(grilla_detalle_venta_entra.CurrentRow)
            calcular_totales_entra()
            txt_codigo.Focus()
        Else
            Me.Enabled = False
            Form_cargar_documento_cambio_producto.Show()
        End If
    End Sub

    'a traves de este sub puedo descontar las cantidades que agregue a la grilla cuando el mismo codigo del producto ya fue agregado.
    Sub mostrar_cantidad_real()
        conexion.Close()
        Dim cantidad_caracteres As Integer
        cantidad_caracteres = Len(txt_codigo.Text)
        If cantidad_caracteres <= 6 Then

            If txt_codigo.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto='" & (txt_codigo.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                    txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                    txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                    txt_precio_modificado.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                    txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                    txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                    txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                    txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                    txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                    If grilla_detalle_venta.Rows.Count > 0 Then
                        For i = 0 To grilla_detalle_venta.Rows.Count - 1
                            Dim codigo = grilla_detalle_venta.Rows(i).Cells(0).Value
                            Dim cantidad2 = grilla_detalle_venta.Rows(i).Cells(4).Value
                            If codigo = txt_codigo.Text Then
                                txt_cantidad.Text = Int(txt_cantidad.Text) - Int(cantidad2)
                            End If
                        Next
                        conexion.Close()
                    End If
                End If
            End If
        Else

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from codigos_de_barra where codigo_barra='" & (txt_codigo.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("codigo_interno")
            End If

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto='" & (txt_codigo.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                txt_precio_modificado.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                If grilla_detalle_venta.Rows.Count > 0 Then
                    For i = 0 To grilla_detalle_venta.Rows.Count - 1
                        Dim codigo = grilla_detalle_venta.Rows(i).Cells(0).Value
                        Dim cantidad2 = grilla_detalle_venta.Rows(i).Cells(4).Value
                        If codigo = txt_codigo.Text Then
                            txt_cantidad.Text = Int(txt_cantidad.Text) - Int(cantidad2)
                        End If
                    Next
                End If
            End If
            conexion.Close()
        End If
    End Sub

    Private Sub txt_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo.KeyPress
        limpiar_datos_productos_enter()

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

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            If txt_codigo.Text = "" Then
                Exit Sub
            End If

            If txt_codigo.Text = "*" Then
                limpiar_producto()
                txt_nombre_producto.ReadOnly = False
                txt_nombre_producto.BackColor = Color.White
                txt_nombre_producto.Focus()
                Exit Sub
            Else
                txt_nombre_producto.ReadOnly = True
                txt_nombre_producto.BackColor = SystemColors.Control
            End If

            conexion.Close()
            Dim cantidad_caracteres As Integer
            cantidad_caracteres = Len(txt_codigo.Text)
            If cantidad_caracteres <= 5 Then
                Form_buscador_productos_ventas.Show()
                Form_buscador_productos_ventas.buscar_codigo()
                Exit Sub
            End If

            limpiar_datos_productos_enter()
            mostrar_cantidad_real()
            mostrar_nombre_proveedor()

            If txt_codigo.Text <> "" And txt_nombre_producto.Text = "" Then
                MsgBox("CODIGO NO ENCONTRADO", MsgBoxStyle.Critical, "INFORMACION")
                txt_codigo.Focus()
            Else
                txt_cantidad_agregar.Text = "1"
                txt_precio_modificado.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Sub limpiar_datos_productos_enter()
        lbl_codigo.Text = "nada"
        txt_nombre_producto.Text = ""
        txt_marca.Text = ""
        txt_numero_tecnico.Text = ""
        txt_cantidad.Text = ""
        txt_factor.Text = ""
        txt_precio_modificado.Text = ""
        txt_costo.Text = ""
        txt_proveedor.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_aplicacion.Text = ""
    End Sub

    'limpiar producto se utiliza cuando agregamos el producto a la grilla.
    Sub limpiar_producto()
        lbl_codigo.Text = "nada"
        txt_codigo.Text = ""
        txt_codigo.Text = ""
        txt_cantidad.Text = ""
        txt_nombre_producto.Text = ""
        txt_precio_modificado.Text = ""
        txt_precio.Text = ""
        txt_factor.Text = ""
        txt_codigo.Text = ""
        txt_numero_tecnico.Text = ""
        txt_marca.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_aplicacion.Text = ""
    End Sub

    'sub para mostrar los datos de los clientes.
    Sub mostrar_nombre_proveedor()
        conexion.Close()
        If txt_proveedor.Text <> "" Then
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from proveedores where rut_proveedor ='" & (txt_proveedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            txt_nombre_proveedor.Text = ""
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_proveedor")
            End If
            conexion.Close()
        End If
    End Sub

    Private Sub txt_precio_modificado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_precio_modificado.KeyPress
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
            txt_cantidad_agregar.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_agregar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_agregar.KeyPress
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

        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If

        If e.KeyChar = "-" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btn_agregar.PerformClick()
        End If
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        Dim mensaje As String = ""

        If txt_precio.Text = "NeuN" Then
            txt_precio.Text = "0"
        End If

        If txt_precio_modificado.Text = "NeuN" Then
            txt_precio_modificado.Text = "0"
        End If

        If txt_cantidad_agregar.Text = "NeuN" Then
            txt_cantidad_agregar.Text = "0"
        End If

        If txt_cantidad.Text = "NeuN" Then
            txt_cantidad.Text = "0"
        End If

        If IsNumeric(txt_precio.Text) = False Then
            txt_precio.Text = "0"
        End If

        If IsNumeric(txt_precio_modificado.Text) = False Then
            txt_precio_modificado.Text = "0"
        End If

        If IsNumeric(txt_cantidad_agregar.Text) = False Then
            txt_cantidad_agregar.Text = "0"
        End If

        If IsNumeric(txt_cantidad.Text) = False Then
            txt_cantidad.Text = "0"
        End If

        If txt_precio.Text = "NeuNInfinito Then" Then
            txt_precio.Text = "0"
        End If

        If txt_precio_modificado.Text = "Infinito" Then
            txt_precio_modificado.Text = "0"
        End If

        If txt_cantidad_agregar.Text = "Infinito" Then
            txt_cantidad_agregar.Text = "0"
        End If

        If txt_cantidad.Text = "Infinito" Then
            txt_cantidad.Text = "0"
        End If

        If txt_cantidad_agregar.Text = "" Then
            txt_cantidad_agregar.Focus()
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_codigo.Text = "" Then
            txt_codigo.Focus()
            MsgBox("CAMPO CODIGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_cantidad_agregar.Text = "" Then
            txt_cantidad_agregar.Text = ""
            txt_cantidad_agregar.Focus()
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_nombre_producto.Text = "" Then
            txt_codigo.Focus()
            MsgBox("CAMPO CODIGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        venta()
        mostrar_cantidad_real()
        txt_cantidad_agregar.Text = ""
    End Sub

    Sub venta()
        Dim iva As Long
        Dim neto As Long
        Dim total As Long
        Dim codigo As Long
        Dim cantidad As Integer
        Dim desc As String
        Dim porcentaje_desc As String
        Dim subtotal As Long
        Dim iva_valor As String
        Dim precio_lista As String
        Dim cantidad_agregar As String = Trim(txt_cantidad_agregar.Text)

        If txt_cantidad_agregar.Text = "" Then
            txt_cantidad_agregar.Text = 0
        End If

        If txt_cantidad_agregar.Text = " " Then
            txt_cantidad_agregar.Text = 0
        End If

        If txt_cantidad_agregar.TextLength = 0 Then
            txt_cantidad_agregar.Text = 0
        End If
        If txt_cantidad_agregar.Text = "  " Then
            txt_cantidad_agregar.Text = 0
        End If

        Me.txt_cantidad_agregar.Text = Trim(Replace(Me.txt_cantidad_agregar.Text, " ", ""))

        If txt_precio.Text = "NeuN" Then
            txt_precio.Text = "0"
        End If

        If txt_precio_modificado.Text = "NeuN" Then
            txt_precio_modificado.Text = "0"
        End If

        If txt_cantidad_agregar.Text = "NeuN" Then
            txt_cantidad_agregar.Text = "0"
        End If

        If txt_cantidad.Text = "NeuN" Then
            txt_cantidad.Text = "0"
        End If

        If IsNumeric(txt_precio.Text) = False Then
            txt_precio.Text = "0"
        End If

        If IsNumeric(txt_precio_modificado.Text) = False Then
            txt_precio_modificado.Text = "0"
        End If

        If IsNumeric(txt_cantidad_agregar.Text) = False Then
            txt_cantidad_agregar.Text = "0"
        End If

        If IsNumeric(txt_cantidad.Text) = False Then
            txt_cantidad.Text = "0"
        End If

        If txt_precio.Text = "Infinito" Then
            txt_precio.Text = "0"
        End If

        If txt_precio_modificado.Text = "Infinito" Then
            txt_precio_modificado.Text = "0"
        End If

        If txt_cantidad_agregar.Text = "Infinito" Then
            txt_cantidad_agregar.Text = "0"
        End If

        If txt_cantidad.Text = "Infinito" Then
            txt_cantidad.Text = "0"
        End If

        If txt_codigo.Text = "*" Then
            Try
                If txt_cantidad_agregar.Text <> "" And txt_cantidad_agregar.Text <> " " And txt_cantidad_agregar.Text <> "  " And txt_cantidad_agregar.Text <> 0 Then

                    If txt_cantidad.Text = "" Then
                        txt_cantidad.Text = "0"
                    End If

                    If txt_precio.Text = "" Then
                        txt_precio.Text = "0"
                    End If

                    If txt_precio_modificado.Text = "" Then
                        txt_precio_modificado.Text = "0"
                    End If

                    porcentaje_desc = "0"
                    desc = "0"

                    subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
                    iva_valor = valor_iva / 100 + 1
                    neto = (subtotal / iva_valor)
                    iva = (neto) * valor_iva / 100
                    total = subtotal - desc
                    
                    grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, txt_precio.Text, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)
                    calcular_totales_sale()
                    limpiar_producto()
                    txt_codigo.Focus()
                Else
                    MsgBox("DEBE INGRESAR UNA CANTIDAD", 0 + 16, "ERROR")
                    txt_cantidad_agregar.Focus()
                End If
            Catch err As InvalidCastException
                MsgBox("VERIFIQUE EL CODIGO INGRESADO", 0 + 16, "ERROR")
                txt_cantidad_agregar.Focus()
                Exit Sub
            End Try
            Exit Sub
        End If

        Try
            If txt_cantidad_agregar.Text <> "" And txt_cantidad_agregar.Text <> " " And txt_cantidad_agregar.Text <> "  " And txt_cantidad_agregar.Text <> 0 Then
                ' If Val(txt_cantidad_agregar.Text) <= Val(txt_cantidad.Text) Then

                For i = 0 To grilla_detalle_venta.Rows.Count - 1
                    codigo = Val(grilla_detalle_venta.Rows(i).Cells(0).Value.ToString)

                    cantidad = Val(grilla_detalle_venta.Rows(i).Cells(4).Value.ToString)
                    If codigo = txt_codigo.Text Then
                        grilla_detalle_venta.Rows.Remove(grilla_detalle_venta.Rows(i))
                        Exit For
                    End If
                Next

                If txt_cantidad.Text = "" Then
                    txt_cantidad.Text = "0"
                End If

                If txt_precio.Text = "" Then
                    txt_precio.Text = "0"
                End If

                If txt_precio_modificado.Text = "" Then
                    txt_precio_modificado.Text = "0"
                End If

                porcentaje_desc = "0"
                desc = "0"

                If Int(txt_precio.Text) > Int(txt_precio_modificado.Text) Then

                    porcentaje_desc = (txt_precio.Text - txt_precio_modificado.Text)
                    porcentaje_desc = (porcentaje_desc * 100)
                    porcentaje_desc = (porcentaje_desc / txt_precio.Text)
                    desc = (txt_precio.Text - txt_precio_modificado.Text)
                    desc = (desc * txt_cantidad_agregar.Text)

                    If porcentaje_desc.Length > 4 Then
                        porcentaje_desc = porcentaje_desc.Substring(0, 4)
                    End If

                    Dim porcentaje_desc_2 As Integer
                    Dim porcentaje_desc_3 As String

                    porcentaje_desc_2 = porcentaje_desc
                    porcentaje_desc = porcentaje_desc_2
                    porcentaje_desc_3 = porcentaje_desc_2 / 100
                    porcentaje_desc_3 = 1 - porcentaje_desc_3
                    txt_precio.Text = Int(txt_precio_modificado.Text / porcentaje_desc_3)

                    If txt_precio.Text = "Infinito" Then
                        txt_precio.Text = "1"
                    End If

                    If txt_precio.Text = "NeuN" Then
                        txt_precio.Text = "1"
                    End If

                    desc = (txt_precio.Text - txt_precio_modificado.Text)
                    desc = (desc * txt_cantidad_agregar.Text)

                    If txt_precio.Text = "Infinito" Then
                        txt_precio.Text = "1"
                        desc = 0
                    End If

                    If txt_precio.Text = "NeuN" Then
                        txt_precio.Text = "1"
                        desc = 0
                    End If
                End If

                If Int(txt_precio.Text) < Int(txt_precio_modificado.Text) Then
                    subtotal = (txt_precio_modificado.Text * txt_cantidad_agregar.Text)
                    precio_lista = txt_precio_modificado.Text
                Else
                    subtotal = (txt_precio.Text * txt_cantidad_agregar.Text)
                    precio_lista = txt_precio.Text
                End If

                iva_valor = valor_iva / 100 + 1
                neto = (subtotal / iva_valor)
                iva = (neto) * valor_iva / 100
                total = subtotal - desc

                grilla_detalle_venta.Rows.Add(txt_codigo.Text, txt_nombre_producto.Text, txt_numero_tecnico.Text, precio_lista, txt_cantidad_agregar.Text, neto, iva, txt_precio_modificado.Text, porcentaje_desc, desc, total)
                calcular_totales_sale()
                limpiar_producto()
                txt_codigo.Focus()
            Else
                MsgBox("DEBE INGRESAR UNA CANTIDAD", 0 + 16, "ERROR")
                txt_cantidad_agregar.Focus()
            End If
        Catch err As InvalidCastException
            MsgBox("VERIFIQUE EL CODIGO INGRESADO", 0 + 16, "ERROR")
            txt_cantidad_agregar.Focus()
            Exit Sub
        End Try
    End Sub

    Private Sub btn_quitar_elemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        If grilla_detalle_venta.Rows.Count > 0 Then
            grilla_detalle_venta.Rows.Remove(grilla_detalle_venta.CurrentRow)
            calcular_totales_sale()
            txt_codigo.Focus()
        End If
    End Sub

    Private Sub txt_porcentaje_desc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_porcentaje_desc.KeyPress

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
            calcular_totales_sale()
            btn_grabar.Focus()
        End If
    End Sub

    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
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

        If documento_tipo = "1" Then
            Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
            Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
            Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
            Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)
            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            format1.Alignment = StringAlignment.Far
            Dim Font1 As New Font("arial", 7, FontStyle.Regular)
            Dim Font2 As New Font("arial", 14, FontStyle.Regular)
            Dim Font3 As New Font("arial", 8, FontStyle.Regular)
            Dim Font4 As New Font("arial", 8, FontStyle.Bold)

            Try
                Dim p As New PointF(0, 0)
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

            e.Graphics.DrawString("CAMBIO DE PRODUCTO", Font2, Brushes.Black, rect7, stringFormat)
            e.Graphics.DrawString("NRO. CAMBIO", Font4, Brushes.Black, 0, 220)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 78, 220)
            e.Graphics.DrawString(txt_nro_vale_cambio.Text, Font3, Brushes.Black, 83, 220)
            e.Graphics.DrawString("FECHA", Font4, Brushes.Black, 0, 235)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 78, 235)
            e.Graphics.DrawString(dtp_fecha.Text, Font3, Brushes.Black, 83, 235)
            e.Graphics.DrawString("REFERENCIA", Font4, Brushes.Black, 0, 250)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 78, 250)
            e.Graphics.DrawString(txt_tipo_doc_referencia.Text & " NRO. " & txt_nro_doc_referencia.Text, Font3, Brushes.Black, 83, 250)
            e.Graphics.DrawString("VENDEDOR", Font4, Brushes.Black, 0, 265)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 78, 265)
            e.Graphics.DrawString(minombre, Font3, Brushes.Black, 83, 265)
            Dim rect_ingresa As New Rectangle(15, 293, 270, 22)
            e.Graphics.DrawString("INGRESA", Font2, Brushes.Black, rect_ingresa, stringFormat)
            e.Graphics.DrawString("CODIGO", Font4, Brushes.Black, 0, 325)
            e.Graphics.DrawString("DESCRIPCION", Font4, Brushes.Black, 55, 325)
            e.Graphics.DrawString("CANT.", Font4, Brushes.Black, 200, 325)
            e.Graphics.DrawString("TOTAL", Font4, Brushes.Black, 245, 325)
            e.Graphics.DrawLine(Pens.Black, 1, 340, 295, 340)

            For i = 0 To grilla_detalle_venta_entra.Rows.Count - 1
                VarCodProducto = grilla_detalle_venta_entra.Rows(i).Cells(0).Value.ToString
                varnombre = grilla_detalle_venta_entra.Rows(i).Cells(1).Value.ToString
                vartecnico = grilla_detalle_venta_entra.Rows(i).Cells(2).Value.ToString
                VarValorUnitario = grilla_detalle_venta_entra.Rows(i).Cells(3).Value.ToString
                VarCantidad = grilla_detalle_venta_entra.Rows(i).Cells(4).Value.ToString
                VarNeto = grilla_detalle_venta_entra.Rows(i).Cells(5).Value.ToString
                VarIva = grilla_detalle_venta_entra.Rows(i).Cells(6).Value.ToString
                VarSubtotal = grilla_detalle_venta_entra.Rows(i).Cells(7).Value.ToString
                VarPorcentaje = grilla_detalle_venta_entra.Rows(i).Cells(8).Value.ToString
                VarDescuento = grilla_detalle_venta_entra.Rows(i).Cells(9).Value.ToString
                VarTotal = grilla_detalle_venta_entra.Rows(i).Cells(10).Value.ToString
                cantidad_detalle = grilla_detalle_venta_entra.Rows(i).Cells(4).Value.ToString
                valorUnitario_detalle = grilla_detalle_venta_entra.Rows(i).Cells(3).Value.ToString
                subtotal_detalle = grilla_detalle_venta_entra.Rows(i).Cells(7).Value.ToString
                total_detalle = grilla_detalle_venta_entra.Rows(i).Cells(10).Value.ToString

                Dim cantidad As String
                Dim total As String
                Dim descripcion As String

                cantidad = VarCantidad
                total = total_detalle
                descripcion = varnombre

                If varnombre.Length > 17 Then
                    descripcion = varnombre.Substring(0, 17)
                End If

                total = Format(Int(total), "###,###,###")
                VarSubtotal = Format(Int(VarSubtotal), "###,###,###")

                e.Graphics.DrawString(VarCodProducto, Font3, Brushes.Gray, 0, 343 + (i * 30))
                e.Graphics.DrawString(descripcion, Font3, Brushes.Gray, 55, 343 + (i * 30))
                e.Graphics.DrawString(vartecnico, Font3, Brushes.Gray, 55, 353 + (i * 30))
                e.Graphics.DrawString(VarSubtotal & " X " & cantidad, Font3, Brushes.Gray, 235, 353 + (i * 30), format1)
                e.Graphics.DrawString(total, Font3, Brushes.Gray, 285, 353 + (i * 30), format1)
                e.Graphics.DrawLine(Pens.Black, 1, 368 + (i * 30), 295, 368 + (i * 30))
                '  cuenta_ciclo = cuenta_ciclo + 1
            Next

            Dim subtotal_millar As String
            Dim descuento_millar As String
            Dim total_millar As String

            descuento_millar = txt_desc_entra.Text
            subtotal_millar = txt_sub_total_entra.Text
            total_millar = txt_total_entra.Text

            subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
            descuento_millar = Format(Int(descuento_millar), "###,###,###")
            total_millar = Format(Int(total_millar), "###,###,###")

            Dim var_grilla As Integer
            var_grilla = ((grilla_detalle_venta_entra.Rows.Count) * 30)

            e.Graphics.DrawString("SUBTOTAL", Font4, Brushes.Black, 160, var_grilla + 360)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + 360)
            e.Graphics.DrawString(subtotal_millar, Font3, Brushes.Black, 285, var_grilla + 360, format1)
            e.Graphics.DrawString("DESCUENTO", Font4, Brushes.Black, 160, var_grilla + 375)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + 375)
            e.Graphics.DrawString(descuento_millar, Font3, Brushes.Black, 285, var_grilla + 375, format1)
            e.Graphics.DrawString("TOTAL", Font4, Brushes.Black, 160, var_grilla + 390)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + 390)
            e.Graphics.DrawString(total_millar, Font3, Brushes.Black, 285, var_grilla + 390, format1)
            Dim rect_sale As New Rectangle(10, var_grilla + 420, 270, 17)
            e.Graphics.DrawString("SALE", Font2, Brushes.Black, rect_sale, stringFormat)
            e.Graphics.DrawString("CODIGO", Font4, Brushes.Black, 0, var_grilla + 450)
            e.Graphics.DrawString("DESCRIPCION", Font4, Brushes.Black, 55, var_grilla + 450)
            e.Graphics.DrawString("CANT.", Font4, Brushes.Black, 200, var_grilla + 450)
            e.Graphics.DrawString("TOTAL", Font4, Brushes.Black, 245, var_grilla + 450)
            e.Graphics.DrawLine(Pens.Black, 1, var_grilla + 465, 295, var_grilla + 465)

            For i = 0 To grilla_detalle_venta.Rows.Count - 1
                VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString
                cantidad_detalle = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                valorUnitario_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                subtotal_detalle = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                total_detalle = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                Dim cantidad As String
                Dim total As String
                Dim descripcion As String

                cantidad = VarCantidad
                total = total_detalle

                descripcion = varnombre
                If varnombre.Length > 17 Then
                    descripcion = varnombre.Substring(0, 17)
                End If

                total = Format(Int(total), "###,###,###")
                VarSubtotal = Format(Int(VarSubtotal), "###,###,###")

                e.Graphics.DrawString(VarCodProducto, Font3, Brushes.Gray, 0, var_grilla + 468 + (i * 30))
                e.Graphics.DrawString(descripcion, Font3, Brushes.Gray, 55, var_grilla + 468 + (i * 30))
                e.Graphics.DrawString(vartecnico, Font3, Brushes.Gray, 55, var_grilla + 478 + (i * 30))
                e.Graphics.DrawString(VarSubtotal & " X " & cantidad, Font3, Brushes.Gray, 235, var_grilla + 478 + (i * 30), format1)
                e.Graphics.DrawString(total, Font3, Brushes.Gray, 285, var_grilla + 478 + (i * 30), format1)
                e.Graphics.DrawLine(Pens.Black, 1, var_grilla + 493 + (i * 30), 295, var_grilla + 493 + (i * 30))
            Next

            Dim var_grilla_sale As Integer
            var_grilla_sale = ((grilla_detalle_venta.Rows.Count) * 30)

            If var_grilla_sale < "0" Then
                var_grilla_sale = 5
            End If

            If var_grilla_sale = "0" Then
                var_grilla_sale = 5
            End If

            descuento_millar = txt_desc.Text
            subtotal_millar = txt_sub_total.Text
            total_millar = txt_total_sale.Text

            subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
            descuento_millar = Format(Int(descuento_millar), "###,###,###")
            total_millar = Format(Int(total_millar), "###,###,###")

            e.Graphics.DrawString("SUBTOTAL", Font4, Brushes.Black, 160, var_grilla + var_grilla_sale + 485)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + var_grilla_sale + 485)
            e.Graphics.DrawString(subtotal_millar, Font3, Brushes.Black, 285, var_grilla + var_grilla_sale + 485, format1)
            e.Graphics.DrawString("DESCUENTO", Font4, Brushes.Black, 160, var_grilla + var_grilla_sale + 500)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + var_grilla_sale + 500)
            e.Graphics.DrawString(descuento_millar, Font3, Brushes.Black, 285, var_grilla + var_grilla_sale + 500, format1)
            e.Graphics.DrawString("TOTAL", Font4, Brushes.Black, 160, var_grilla + var_grilla_sale + 515)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + var_grilla_sale + 515)
            e.Graphics.DrawString(total_millar, Font3, Brushes.Black, 285, var_grilla + var_grilla_sale + 515, format1)

            Dim rect_resumen As New Rectangle(10, var_grilla + var_grilla_sale + 545, 270, 17)

            e.Graphics.DrawString("RESUMEN", Font2, Brushes.Black, rect_resumen, stringFormat)

            subtotal_millar = txt_total_entra.Text
            descuento_millar = txt_total_sale.Text
            total_millar = Int(txt_total_entra.Text) - Int(txt_total_sale.Text)

            subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
            descuento_millar = Format(Int(descuento_millar), "###,###,###")
            total_millar = Format(Int(total_millar), "###,###,###")

            e.Graphics.DrawString("INGRESA", Font4, Brushes.Black, 160, var_grilla + var_grilla_sale + 580)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + var_grilla_sale + 580)
            e.Graphics.DrawString(subtotal_millar, Font3, Brushes.Black, 285, var_grilla + var_grilla_sale + 580, format1)
            e.Graphics.DrawString("SALE", Font4, Brushes.Black, 160, var_grilla + var_grilla_sale + 595)
            e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + var_grilla_sale + 595)
            e.Graphics.DrawString(descuento_millar, Font3, Brushes.Black, 285, var_grilla + var_grilla_sale + 595, format1)


            Dim tipo_documento As String
            tipo_documento = lbl_documento.Text
            tipo_documento = Mid(tipo_documento, 1, Len(tipo_documento) - 1)


            If tipo_documento.Contains("BOLETA") Then
                If lbl_venta.Text <> "" Then
                    If lbl_venta.Text <> "0" Then

                        Dim total_venta As String
                        total_venta = lbl_venta.Text
                        If total_venta = "" Or total_venta = "0" Then
                            total_venta = "0"
                        Else
                            total_venta = Format(Int(total_venta), "###,###,###")
                        End If

                        e.Graphics.DrawString("PAGA", Font4, Brushes.Black, 160, var_grilla + var_grilla_sale + 610)
                        e.Graphics.DrawString(":", Font3, Brushes.Black, 231, var_grilla + var_grilla_sale + 610)
                        e.Graphics.DrawString(total_venta, Font3, Brushes.Black, 285, var_grilla + var_grilla_sale + 610, format1)
                        e.Graphics.DrawString("SE GENERA BOLETA " & txt_nro_boleta.Text, Font2, Brushes.Black, 10, var_grilla + var_grilla_sale + 625)
                    End If
                End If
            End If




            Dim rect8 As New Rectangle(10, var_grilla + var_grilla_sale + 730, 270, 15)
            Dim rect9 As New Rectangle(10, var_grilla + var_grilla_sale + 650, 270, 15)

            e.Graphics.DrawString("AUTORIZA :", Font4, Brushes.Black, 0, var_grilla + var_grilla_sale + 730)
            e.Graphics.DrawLine(Pens.Black, 65, var_grilla + var_grilla_sale + 745, 295, var_grilla + var_grilla_sale + 745)

            Dim fecha_mas_tres As String
            fecha_mas_tres = dtp_fecha.Value.AddMonths(Val(+3))

            If fecha_mas_tres.Length > 10 Then
                fecha_mas_tres = fecha_mas_tres.Substring(0, 10)
            End If

            Dim rect10 As New Rectangle(10, var_grilla + var_grilla_sale + 795, 260, 15)
            e.Graphics.DrawString("-", Font3, Brushes.Gray, rect10, stringFormat)

            alto_cotizacion = var_grilla + var_grilla_sale + 680

        End If


        If documento_tipo = "2" Then

            Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
            Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
            Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
            Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)

            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            format1.Alignment = StringAlignment.Far

            If mirutempresa = "87686300-6" Then

                e.Graphics.DrawString(dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 85, 5)
                e.Graphics.DrawString(txt_condiciones.Text, Font10, Brushes.Black, 590, 5)

                e.Graphics.DrawString("999999", Font9, Brushes.Black, 50, 75)
                e.Graphics.DrawString("CAMBIO DE PRODUCTO, VALE NRO. " & txt_nro_vale_cambio.Text, Font9, Brushes.Black, 120, 75)
                e.Graphics.DrawString(txt_sub_total_final.Text, Font9, Brushes.Black, 725, 75, format1)

                Dim descuento_millar_final As String
                Dim neto_millar_final As String
                Dim iva_millar_final As String
                Dim total_millar_final As String
                Dim subtotal_millar_final As String

                descuento_millar_final = txt_desc_final.Text
                neto_millar_final = txt_neto_final.Text
                iva_millar_final = txt_iva_final.Text
                subtotal_millar_final = txt_sub_total_final.Text
                total_millar_final = txt_total_final.Text

                descuento_millar_final = Format(Int(descuento_millar_final), "###,###,###")
                neto_millar_final = Format(Int(neto_millar_final), "###,###,###")
                iva_millar_final = Format(Int(iva_millar_final), "###,###,###")
                subtotal_millar_final = Format(Int(subtotal_millar_final), "###,###,###")
                total_millar_final = Format(Int(total_millar_final), "###,###,###")

                Dim nombre_vendedor As String
                nombre_vendedor = minombre
                If nombre_vendedor.Length > 12 Then
                    nombre_vendedor = nombre_vendedor.Substring(0, 12)
                End If

                e.Graphics.DrawString(txt_nro_boleta.Text, Font10, Brushes.Black, 60, 270)
                e.Graphics.DrawString(nombre_vendedor, Font10, Brushes.Black, 215, 270)
                e.Graphics.DrawString(subtotal_millar_final, Font10, Brushes.Black, 385, 270)
                e.Graphics.DrawString(descuento_millar_final, Font10, Brushes.Black, 515, 270)
                e.Graphics.DrawString(total_millar_final, Font10, Brushes.Black, 630, 270)

            End If


            If mirutempresa <> "87686300-6" Then
                ' '' '' '' '' '' '' '' '' '' '' '' ''    ''\\FORMATO ORIGINAL
                ' '' '' '' '' '' '' '' '' '' '' '' ''    e.Graphics.DrawString(dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 85, 5)
                ' '' '' '' '' '' '' '' '' '' '' '' ''    e.Graphics.DrawString("CAMBIO DE MERCADERIA", Font10, Brushes.Black, 320, 5)
                ' '' '' '' '' '' '' '' '' '' '' '' ''    e.Graphics.DrawString(txt_condiciones.Text, Font10, Brushes.Black, 590, 5)

                ' '' '' '' '' '' '' '' '' '' '' '' ''    e.Graphics.DrawString("///ENTRA///", Font10, Brushes.Black, 35, 60)

                ' '' '' '' '' '' '' '' '' '' '' '' ''    e.Graphics.DrawString("REFERENCIA: " & txt_tipo_doc_referencia.Text & " NRO. " & txt_nro_doc_referencia.Text, Font10, Brushes.Black, 725, 60, format1)

                ' '' '' '' '' '' '' '' '' '' '' '' ''    For i = 0 To grilla_detalle_venta_entra.Rows.Count - 1
                ' '' '' '' '' '' '' '' '' '' '' '' ''        VarCodProducto = grilla_detalle_venta_entra.Rows(i).Cells(0).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        varnombre = grilla_detalle_venta_entra.Rows(i).Cells(1).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        vartecnico = grilla_detalle_venta_entra.Rows(i).Cells(2).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        VarValorUnitario = grilla_detalle_venta_entra.Rows(i).Cells(3).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        VarCantidad = grilla_detalle_venta_entra.Rows(i).Cells(4).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        VarNeto = grilla_detalle_venta_entra.Rows(i).Cells(5).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        VarIva = grilla_detalle_venta_entra.Rows(i).Cells(6).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        VarSubtotal = grilla_detalle_venta_entra.Rows(i).Cells(7).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        VarPorcentaje = grilla_detalle_venta_entra.Rows(i).Cells(8).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        VarDescuento = grilla_detalle_venta_entra.Rows(i).Cells(9).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        VarTotal = grilla_detalle_venta_entra.Rows(i).Cells(10).Value.ToString

                ' '' '' '' '' '' '' '' '' '' '' '' ''        cantidad_detalle = grilla_detalle_venta_entra.Rows(i).Cells(4).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        valorUnitario_detalle = grilla_detalle_venta_entra.Rows(i).Cells(3).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        subtotal_detalle = grilla_detalle_venta_entra.Rows(i).Cells(7).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        total_detalle = grilla_detalle_venta_entra.Rows(i).Cells(10).Value.ToString

                ' '' '' '' '' '' '' '' '' '' '' '' ''        '   cantidad_detalle = Format(Int(cantidad_detalle), "###,###,###")
                ' '' '' '' '' '' '' '' '' '' '' '' ''        valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
                ' '' '' '' '' '' '' '' '' '' '' '' ''        subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
                ' '' '' '' '' '' '' '' '' '' '' '' ''        total_detalle = Format(Int(total_detalle), "###,###,###")

                ' '' '' '' '' '' '' '' '' '' '' '' ''        Dim descripcion_caracteres As String
                ' '' '' '' '' '' '' '' '' '' '' '' ''        descripcion_caracteres = varnombre & ", " & vartecnico
                ' '' '' '' '' '' '' '' '' '' '' '' ''        If descripcion_caracteres.Length > 55 Then
                ' '' '' '' '' '' '' '' '' '' '' '' ''            descripcion_caracteres = descripcion_caracteres.Substring(0, 55)
                ' '' '' '' '' '' '' '' '' '' '' '' ''        End If

                ' '' '' '' '' '' '' '' '' '' '' '' ''        e.Graphics.DrawString(VarCodProducto, Font9, Brushes.Black, 50, 75 + (i * 15))
                ' '' '' '' '' '' '' '' '' '' '' '' ''        e.Graphics.DrawString(descripcion_caracteres, Font9, Brushes.Black, 120, 75 + (i * 15))
                ' '' '' '' '' '' '' '' '' '' '' '' ''        e.Graphics.DrawString(cantidad_detalle, Font9, Brushes.Black, 565, 75 + (i * 15), format1)
                ' '' '' '' '' '' '' '' '' '' '' '' ''        e.Graphics.DrawString(valorUnitario_detalle, Font9, Brushes.Black, 645, 75 + (i * 15), format1)
                ' '' '' '' '' '' '' '' '' '' '' '' ''        e.Graphics.DrawString(total_detalle, Font9, Brushes.Black, 725, 75 + (i * 15), format1)
                ' '' '' '' '' '' '' '' '' '' '' '' ''    Next

                ' '' '' '' '' '' '' '' '' '' '' '' ''    Dim var_grilla_entra As Integer
                ' '' '' '' '' '' '' '' '' '' '' '' ''    var_grilla_entra = ((grilla_detalle_venta_entra.Rows.Count) * 15)

                ' '' '' '' '' '' '' '' '' '' '' '' ''    Dim descuento_millar_entra As String
                ' '' '' '' '' '' '' '' '' '' '' '' ''    Dim neto_millar_entra As String
                ' '' '' '' '' '' '' '' '' '' '' '' ''    Dim iva_millar_entra As String
                ' '' '' '' '' '' '' '' '' '' '' '' ''    Dim total_millar_entra As String
                ' '' '' '' '' '' '' '' '' '' '' '' ''    Dim subtotal_millar_entra As String

                ' '' '' '' '' '' '' '' '' '' '' '' ''    descuento_millar_entra = txt_desc_entra.Text
                ' '' '' '' '' '' '' '' '' '' '' '' ''    neto_millar_entra = txt_neto_entra.Text
                ' '' '' '' '' '' '' '' '' '' '' '' ''    iva_millar_entra = txt_iva_entra.Text
                ' '' '' '' '' '' '' '' '' '' '' '' ''    subtotal_millar_entra = txt_sub_total_entra.Text
                ' '' '' '' '' '' '' '' '' '' '' '' ''    total_millar_entra = txt_total_entra.Text

                ' '' '' '' '' '' '' '' '' '' '' '' ''    descuento_millar_entra = Format(Int(descuento_millar_entra), "###,###,###")
                ' '' '' '' '' '' '' '' '' '' '' '' ''    neto_millar_entra = Format(Int(neto_millar_entra), "###,###,###")
                ' '' '' '' '' '' '' '' '' '' '' '' ''    iva_millar_entra = Format(Int(iva_millar_entra), "###,###,###")
                ' '' '' '' '' '' '' '' '' '' '' '' ''    subtotal_millar_entra = Format(Int(subtotal_millar_entra), "###,###,###")
                ' '' '' '' '' '' '' '' '' '' '' '' ''    total_millar_entra = Format(Int(total_millar_entra), "###,###,###")

                ' '' '' '' '' '' '' '' '' '' '' '' ''    e.Graphics.DrawString("SUBTOTAL: ", Font10, Brushes.Black, 35, 75 + var_grilla_entra)
                ' '' '' '' '' '' '' '' '' '' '' '' ''    e.Graphics.DrawString("DESCUENTO: ", Font10, Brushes.Black, 290, 75 + var_grilla_entra)
                ' '' '' '' '' '' '' '' '' '' '' '' ''    e.Graphics.DrawString("TOTAL ENTRA: ", Font10, Brushes.Black, 645, 75 + var_grilla_entra, format1)

                ' '' '' '' '' '' '' '' '' '' '' '' ''    e.Graphics.DrawString(subtotal_millar_entra, Font10, Brushes.Black, 145, 75 + var_grilla_entra)
                ' '' '' '' '' '' '' '' '' '' '' '' ''    e.Graphics.DrawString(descuento_millar_entra, Font10, Brushes.Black, 440, 75 + var_grilla_entra, format1)
                ' '' '' '' '' '' '' '' '' '' '' '' ''    e.Graphics.DrawString(total_millar_entra, Font10, Brushes.Black, 725, 75 + var_grilla_entra, format1)

                ' '' '' '' '' '' '' '' '' '' '' '' ''    e.Graphics.DrawString("///SALE///", Font10, Brushes.Black, 35, 90 + var_grilla_entra)

                ' '' '' '' '' '' '' '' '' '' '' '' ''    For i = 0 To grilla_detalle_venta.Rows.Count - 1
                ' '' '' '' '' '' '' '' '' '' '' '' ''        VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                ' '' '' '' '' '' '' '' '' '' '' '' ''        cantidad_detalle = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        valorUnitario_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        subtotal_detalle = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                ' '' '' '' '' '' '' '' '' '' '' '' ''        total_detalle = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                ' '' '' '' '' '' '' '' '' '' '' '' ''        '   cantidad_detalle = Format(Int(cantidad_detalle), "###,###,###")
                ' '' '' '' '' '' '' '' '' '' '' '' ''        valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
                ' '' '' '' '' '' '' '' '' '' '' '' ''        subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
                ' '' '' '' '' '' '' '' '' '' '' '' ''        total_detalle = Format(Int(total_detalle), "###,###,###")

                ' '' '' '' '' '' '' '' '' '' '' '' ''        Dim descripcion_caracteres As String
                ' '' '' '' '' '' '' '' '' '' '' '' ''        descripcion_caracteres = varnombre & "        " & vartecnico
                ' '' '' '' '' '' '' '' '' '' '' '' ''        If descripcion_caracteres.Length > 55 Then
                ' '' '' '' '' '' '' '' '' '' '' '' ''            descripcion_caracteres = descripcion_caracteres.Substring(0, 55)
                ' '' '' '' '' '' '' '' '' '' '' '' ''        End If

                ' '' '' '' '' '' '' '' '' '' '' '' ''        e.Graphics.DrawString(VarCodProducto, Font9, Brushes.Black, 50, 120 + (i * 15))
                ' '' '' '' '' '' '' '' '' '' '' '' ''        e.Graphics.DrawString(descripcion_caracteres, Font9, Brushes.Black, 120, 120 + (i * 15))
                ' '' '' '' '' '' '' '' '' '' '' '' ''        e.Graphics.DrawString(cantidad_detalle, Font9, Brushes.Black, 565, 120 + (i * 15), format1)
                ' '' '' '' '' '' '' '' '' '' '' '' ''        e.Graphics.DrawString(valorUnitario_detalle, Font9, Brushes.Black, 645, 120 + (i * 15), format1)
                ' '' '' '' '' '' '' '' '' '' '' '' ''        e.Graphics.DrawString(total_detalle, Font9, Brushes.Black, 725, 120 + (i * 15), format1)
                ' '' '' '' '' '' '' '' '' '' '' '' ''    Next

                ' '' '' '' '' '' '' '' '' '' '' '' ''    Dim descuento_millar_final As String
                ' '' '' '' '' '' '' '' '' '' '' '' ''    Dim neto_millar_final As String
                ' '' '' '' '' '' '' '' '' '' '' '' ''    Dim iva_millar_final As String
                ' '' '' '' '' '' '' '' '' '' '' '' ''    Dim total_millar_final As String
                ' '' '' '' '' '' '' '' '' '' '' '' ''    Dim subtotal_millar_final As String

                ' '' '' '' '' '' '' '' '' '' '' '' ''    descuento_millar_final = txt_desc_final.Text
                ' '' '' '' '' '' '' '' '' '' '' '' ''    neto_millar_final = txt_neto_final.Text
                ' '' '' '' '' '' '' '' '' '' '' '' ''    iva_millar_final = txt_iva_final.Text
                ' '' '' '' '' '' '' '' '' '' '' '' ''    subtotal_millar_final = txt_sub_total_final.Text
                ' '' '' '' '' '' '' '' '' '' '' '' ''    total_millar_final = txt_total_final.Text

                ' '' '' '' '' '' '' '' '' '' '' '' ''    descuento_millar_final = Format(Int(descuento_millar_final), "###,###,###")
                ' '' '' '' '' '' '' '' '' '' '' '' ''    neto_millar_final = Format(Int(neto_millar_final), "###,###,###")
                ' '' '' '' '' '' '' '' '' '' '' '' ''    iva_millar_final = Format(Int(iva_millar_final), "###,###,###")
                ' '' '' '' '' '' '' '' '' '' '' '' ''    subtotal_millar_final = Format(Int(subtotal_millar_final), "###,###,###")
                ' '' '' '' '' '' '' '' '' '' '' '' ''    total_millar_final = Format(Int(total_millar_final), "###,###,###")


                ' '' '' '' '' '' '' '' '' '' '' '' ''    Dim nombre_vendedor As String
                ' '' '' '' '' '' '' '' '' '' '' '' ''    nombre_vendedor = minombre
                ' '' '' '' '' '' '' '' '' '' '' '' ''    If nombre_vendedor.Length > 12 Then
                ' '' '' '' '' '' '' '' '' '' '' '' ''        nombre_vendedor = nombre_vendedor.Substring(0, 12)
                ' '' '' '' '' '' '' '' '' '' '' '' ''    End If

                ' '' '' '' '' '' '' '' '' '' '' '' ''    e.Graphics.DrawString(txt_nro_boleta.Text, Font10, Brushes.Black, 60, 270)
                ' '' '' '' '' '' '' '' '' '' '' '' ''    e.Graphics.DrawString(nombre_vendedor, Font10, Brushes.Black, 215, 270)
                ' '' '' '' '' '' '' '' '' '' '' '' ''    e.Graphics.DrawString(subtotal_millar_final, Font10, Brushes.Black, 385, 270)
                ' '' '' '' '' '' '' '' '' '' '' '' ''    e.Graphics.DrawString(descuento_millar_final, Font10, Brushes.Black, 515, 270)
                ' '' '' '' '' '' '' '' '' '' '' '' ''    e.Graphics.DrawString(total_millar_final, Font10, Brushes.Black, 630, 270)

                ' '' '' '' '' '' '' '' '' '' '' '' ''End If
                ' '' '' '' '' '' '' '' '' '' '' '' '' ''\\FIN FORMATO ORIGINAL




                ''\\FORMATO ORIGINAL

                Dim altura_impresion As Integer
                altura_impresion = 0


                e.Graphics.DrawString(txt_nro_boleta.Text & "                   " & dtp_fecha.Text, Font10, Brushes.Black, 540, altura_impresion + 0)


                ' e.Graphics.DrawString(dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 85, 5)
                e.Graphics.DrawString("CAMBIO DE MERCADERIA", Font10, Brushes.Black, 320, 5)
                'e.Graphics.DrawString(txt_condiciones.Text, Font10, Brushes.Black, 590, 5)

                e.Graphics.DrawString("///ENTRA///", Font10, Brushes.Black, 35, 60)

                e.Graphics.DrawString("REFERENCIA: " & txt_tipo_doc_referencia.Text & " NRO. " & txt_nro_doc_referencia.Text, Font10, Brushes.Black, 725, 60, format1)

                For i = 0 To grilla_detalle_venta_entra.Rows.Count - 1
                    VarCodProducto = grilla_detalle_venta_entra.Rows(i).Cells(0).Value.ToString
                    varnombre = grilla_detalle_venta_entra.Rows(i).Cells(1).Value.ToString
                    vartecnico = grilla_detalle_venta_entra.Rows(i).Cells(2).Value.ToString
                    VarValorUnitario = grilla_detalle_venta_entra.Rows(i).Cells(3).Value.ToString
                    VarCantidad = grilla_detalle_venta_entra.Rows(i).Cells(4).Value.ToString
                    VarNeto = grilla_detalle_venta_entra.Rows(i).Cells(5).Value.ToString
                    VarIva = grilla_detalle_venta_entra.Rows(i).Cells(6).Value.ToString
                    VarSubtotal = grilla_detalle_venta_entra.Rows(i).Cells(7).Value.ToString
                    VarPorcentaje = grilla_detalle_venta_entra.Rows(i).Cells(8).Value.ToString
                    VarDescuento = grilla_detalle_venta_entra.Rows(i).Cells(9).Value.ToString
                    VarTotal = grilla_detalle_venta_entra.Rows(i).Cells(10).Value.ToString

                    cantidad_detalle = grilla_detalle_venta_entra.Rows(i).Cells(4).Value.ToString
                    valorUnitario_detalle = grilla_detalle_venta_entra.Rows(i).Cells(3).Value.ToString
                    subtotal_detalle = grilla_detalle_venta_entra.Rows(i).Cells(7).Value.ToString
                    total_detalle = grilla_detalle_venta_entra.Rows(i).Cells(10).Value.ToString

                    '   cantidad_detalle = Format(Int(cantidad_detalle), "###,###,###")
                    valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
                    subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
                    total_detalle = Format(Int(total_detalle), "###,###,###")

                    Dim descripcion_caracteres As String
                    descripcion_caracteres = varnombre & "        " & vartecnico
                    If descripcion_caracteres.Length > 55 Then
                        descripcion_caracteres = descripcion_caracteres.Substring(0, 55)
                    End If

                    e.Graphics.DrawString(VarCodProducto, Font9, Brushes.Black, 0, altura_impresion + 75 + (i * 15))
                    e.Graphics.DrawString(descripcion_caracteres, Font9, Brushes.Black, 120, altura_impresion + 75 + (i * 15))
                    e.Graphics.DrawString(cantidad_detalle, Font9, Brushes.Black, 605, altura_impresion + 75 + (i * 15), format1)
                    e.Graphics.DrawString(valorUnitario_detalle, Font9, Brushes.Black, 695, altura_impresion + 75 + (i * 15), format1)
                    e.Graphics.DrawString(total_detalle, Font9, Brushes.Black, 770, altura_impresion + 75 + (i * 15), format1)
                Next

                Dim var_grilla_entra As Integer
                var_grilla_entra = ((grilla_detalle_venta_entra.Rows.Count) * 15)

                e.Graphics.DrawString("///SALE///", Font10, Brushes.Black, 35, 90 + var_grilla_entra)

                For i = 0 To grilla_detalle_venta.Rows.Count - 1
                    VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                    varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                    vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                    VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                    VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                    VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                    VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                    VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                    VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                    VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                    VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                    cantidad_detalle = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                    valorUnitario_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
                    subtotal_detalle = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                    total_detalle = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

                    '   cantidad_detalle = Format(Int(cantidad_detalle), "###,###,###")
                    valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
                    subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
                    total_detalle = Format(Int(total_detalle), "###,###,###")

                    Dim descripcion_caracteres As String
                    descripcion_caracteres = varnombre & "        " & vartecnico
                    If descripcion_caracteres.Length > 55 Then
                        descripcion_caracteres = descripcion_caracteres.Substring(0, 55)
                    End If

                    e.Graphics.DrawString(VarCodProducto, Font9, Brushes.Black, 0, altura_impresion + 120 + (i * 15))
                    e.Graphics.DrawString(descripcion_caracteres, Font9, Brushes.Black, 120, altura_impresion + 120 + (i * 15))
                    e.Graphics.DrawString(cantidad_detalle, Font9, Brushes.Black, 605, altura_impresion + 120 + (i * 15), format1)
                    e.Graphics.DrawString(valorUnitario_detalle, Font9, Brushes.Black, 695, altura_impresion + 120 + (i * 15), format1)
                    e.Graphics.DrawString(total_detalle, Font9, Brushes.Black, 770, altura_impresion + 120 + (i * 15), format1)
                Next

                Dim descuento_millar_final As String
                Dim neto_millar_final As String
                Dim iva_millar_final As String
                Dim total_millar_final As String
                Dim subtotal_millar_final As String

                descuento_millar_final = txt_desc_final.Text
                neto_millar_final = txt_neto_final.Text
                iva_millar_final = txt_iva_final.Text
                subtotal_millar_final = txt_sub_total_final.Text
                total_millar_final = txt_total_final.Text

                descuento_millar_final = Format(Int(descuento_millar_final), "###,###,###")
                neto_millar_final = Format(Int(neto_millar_final), "###,###,###")
                iva_millar_final = Format(Int(iva_millar_final), "###,###,###")
                subtotal_millar_final = Format(Int(subtotal_millar_final), "###,###,###")
                total_millar_final = Format(Int(total_millar_final), "###,###,###")


                Dim nombre_vendedor As String
                nombre_vendedor = minombre
                If nombre_vendedor.Length > 12 Then
                    nombre_vendedor = nombre_vendedor.Substring(0, 12)
                End If

                If nombre_vendedor.Length > 12 Then
                    nombre_vendedor = nombre_vendedor.Substring(0, 12)
                End If

                e.Graphics.DrawString("FORMA DE PAGO:", Font10, Brushes.Black, 10, altura_impresion + 400)
                e.Graphics.DrawString(txt_condiciones.Text, Font10, Brushes.Black, 140, altura_impresion + 400)
                e.Graphics.DrawString(total_millar_final, Font10, Brushes.Black, 770, altura_impresion + 360, format1)
            End If
        End If

    End Sub

    Sub redondear_documento()
        Dim iva_valor As String
        Dim valor_total As Integer
        Dim finTotal As Integer
        Dim numerofinal As Integer

        valor_total = Int(txt_total_entra.Text) - Int(txt_total_sale.Text)
        valor_total = Replace(valor_total, "-", "")
        txt_sub_total_final.Text = Int(txt_total_entra.Text) - Int(txt_total_sale.Text)
        txt_sub_total_final.Text = Replace(txt_sub_total_final.Text, "-", "")
        finTotal = Strings.Right(valor_total, 2)
        numerofinal = Strings.Right(valor_total, 1)

        If numerofinal = 0 Then
            '  Exit Sub
        End If

        valor_total = valor_total - numerofinal
        Round(valor_total)
        txt_desc_final.Text = numerofinal
        txt_total_final.Text = valor_total

        '\\prueba de redondear descuento
        Dim valor_descuento_redondeado As String

        valor_descuento_redondeado = txt_desc_final.Text * 100
        valor_descuento_redondeado = valor_descuento_redondeado / txt_sub_total_final.Text

        If valor_descuento_redondeado.Length > 5 Then
            valor_descuento_redondeado = valor_descuento_redondeado.Substring(0, 5)
        End If

        iva_valor = valor_iva / 100 + 1
        txt_neto_final.Text = Round(txt_total_final.Text / iva_valor)
        txt_iva_final.Text = (((txt_neto_final.Text) * valor_iva) / 100)
        txt_iva_final.Text = (txt_total_final.Text) - (txt_neto_final.Text)

        valor_total = lbl_venta.Text
        valor_total = Replace(valor_total, "-", "")
        finTotal = Strings.Right(valor_total, 2)
        numerofinal = Strings.Right(valor_total, 1)

        If numerofinal = 0 Then
            '  Exit Sub
        End If

        valor_total = valor_total - numerofinal
        Round(valor_total)
        lbl_venta.Text = valor_total

    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        If grilla_detalle_venta_entra.Rows.Count = 0 Then
            MsgBox("AUN NO AGREGA UN PRODUCTO A LA LISTA", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_codigo.Focus()
            Exit Sub
        End If

        Dim documento_tipo As String

        documento_tipo = lbl_documento.Text
        documento_tipo = Mid(documento_tipo, 1, Len(documento_tipo) - 1)


        If documento_tipo = "BOLETA" Then
            If grilla_detalle_venta.Rows.Count > limite_boletas Then
                MsgBox("NO PUEDE AGREGAR MAS DE PRODUCTOS, ELIMINE ALGUNOS", 0 + 16, "ERROR")
                txt_codigo.Focus()
                Exit Sub
            End If
        End If

        If documento_tipo = "VALE DE CAMBIO" Then
            Dim valormensaje As Integer
            valormensaje = MsgBox("¿ESTA SEGURO DE IMPRIMIR UN VALE DE CAMBIO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")

            If valormensaje = vbYes Then
                Form_autorizacion_cambio_producto.Show()
                Me.Enabled = False
            End If

        End If

        If documento_tipo = "BOLETA" Then
            Dim valormensaje As Integer
            valormensaje = MsgBox("¿ESTA SEGURO DE IMPRIMIR UNA BOLETA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "INFORMACION")
            If valormensaje = vbYes Then
                Form_cambio_de_producto_condiciones.Show()
                Me.Enabled = False
            End If
        End If
    End Sub

    Sub imprimir()
        Dim tipo_documento As String
        tipo_documento = lbl_documento.Text
        tipo_documento = Mid(tipo_documento, 1, Len(tipo_documento) - 1)

        documento_tipo = "1"

        txt_nro_boleta.Text = ""

        If tipo_documento.Contains("BOLETA") Then
            crear_numero_boleta()
        End If

        With Pd.PrinterSettings
            ' Especifico el nombre de la impresora 
            ' por donde deseo imprimir. 
            .PrinterName = impresora_ticket
            '.PrinterName = "Microsoft Print to PDF"
            ' .PrinterName = "\\SERVER\HP LaserJet Professional P 1102w"
            ' Establezco el número de copias que se imprimirán 
            .Copies = 1

            'If mirutempresa = "81921000-4" Then
            '    .Copies = 2
            'Else
            '    .Copies = 1
            'End If

            .Copies = 1

            ' Rango de páginas que se imprimirán 
            .PrintRange = PrintRange.AllPages

            If .IsValid Then

                Me.Enabled = False

                Me.Enabled = False
                Me.crear_numero_vale()
                redondear_documento()
                Me.grabar_vale()

                '  grabar_boleta()

                Me.Pd.PrintController = New StandardPrintController
                Me.Pd.DefaultPageSettings.Margins.Left = 10
                Me.Pd.DefaultPageSettings.Margins.Right = 10
                Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, alto_cotizacion)
                Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1

                Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                Pd.Print()

                Me.grabar_detalle_vale()

                If tipo_documento = "VALE DE CAMBIO" Then

                    If Int(lbl_venta.Text) <> 0 Then
                        crear_numero_saldo()
                        grabar_saldo()
                        With Pd.PrinterSettings
                            .PrinterName = impresora_ticket
                            .Copies = 2
                            .PrintRange = PrintRange.AllPages
                            If .IsValid Then
                                'Me.Pd.PrintController = New StandardPrintController
                                Dim Custom_Size_cambio As New PaperSize("New Long Roll", 1000, 850)
                                Me.PrintDocument1.DefaultPageSettings.PaperSize = Custom_Size_cambio
                                PrintDocument1.PrintController = New System.Drawing.Printing.StandardPrintController()
                                PrintDocument1.Print()
                            Else
                                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                                lbl_mensaje.Visible = False
                                Me.Enabled = True
                                Exit Sub
                            End If
                        End With
                        'Try
                        '    Dim iReporte As New Form_informe_saldo_a_favor
                        '    Dim rpt As New Crystal_saldo_a_favor
                        '    rpt.Load()
                        '    rpt.SetDataSource(ReturnDataSet)
                        '    rpt.Refresh()
                        '    iReporte.Reporte = rpt
                        '    rpt.PrintOptions.PrinterName = impresora_ticket
                        '    rpt.PrintToPrinter(1, False, 0, 0)
                        'Catch ex As Exception
                        '    MsgBox(ex.Message)
                        'End Try
                    End If
                End If
            End If
        End With

        documento_tipo = "2"
        If estado_boleta_electronica = "NO" Then

            If impresora_boletas = "TICKET INTERNO" Then



                With PrintDocument_ticket_interno.PrinterSettings
                    .PrinterName = impresora_ticket
                    .Copies = 2
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then
                        Me.crear_numero_boleta()
                        ' Me.grabar_factura()
                        Me.PrintDocument_ticket_interno.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                        Me.PrintDocument_ticket_interno.DefaultPageSettings.PaperSize = pkCustomSize1
                        PrintDocument_ticket_interno.PrintController = New System.Drawing.Printing.StandardPrintController()
                        PrintDocument_ticket_interno.Print()




                        redondear_documento()
                        grabar_boleta()

                        grabar_detalle_boleta()
                        Me.crear_archivo_plano()
                        Form_autorizacion.Close()
                        Me.limpiar()
                        Me.controles(False, True)

                        Form_tipo_despacho.Close()

                        lbl_mensaje.Visible = False
                        Me.Enabled = True






                        lbl_mensaje.Visible = False
                        Me.Enabled = True

                        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With



                '    Try
                '        Me.crear_numero_boleta()

                '        Dim iReporte As New Form_informe_cotizacion_ticket_personalizado
                '        Dim rpt As New Crystal_cotizacion_ticket_personalizado
                '        rpt.Load()
                '        rpt.SetDataSource(ReturnDataSetTicketInterno)
                '        rpt.Refresh()
                '        iReporte.Reporte = rpt
                '        '  iReporte.ShowDialog()
                '        rpt.PrintOptions.PrinterName = impresora_ticket
                '        rpt.PrintToPrinter(1, False, 0, 0)

                '        redondear_documento()

                '        ' Me.grabar_vale()
                '        grabar_boleta()

                '        grabar_detalle_boleta()
                '        Me.crear_archivo_plano()
                '        Form_autorizacion.Close()
                '        Me.limpiar()
                '        Me.controles(False, True)

                '        Form_tipo_despacho.Close()

                '        lbl_mensaje.Visible = False
                '        Me.Enabled = True
                '        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                '        Exit Sub

                '    Catch ex As Exception
                '        MsgBox(ex.Message)
                '    End Try
                'Else
                '    MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                '    lbl_mensaje.Visible = False
                '    Me.Enabled = True
                '    Exit Sub
                'End If
            End If






















            If tipo_documento = "BOLETA" Then

                With Pd.PrinterSettings
                    ' Especifico el nombre de la impresora 
                    ' por donde deseo imprimir. 
                    .PrinterName = impresora_boletas
                    ' .PrinterName = "\\SERVER\HP LaserJet Professional P 1102w"
                    ' Establezco el número de copias que se imprimirán 
                    .Copies = 1
                    ' Rango de páginas que se imprimirán 
                    .PrintRange = PrintRange.AllPages

                    If .IsValid Then

                        Me.Enabled = False


                        Me.crear_numero_boleta()

                        redondear_documento()

                        ' Me.grabar_vale()
                        grabar_boleta()

                        Me.Pd.PrintController = New StandardPrintController
                        Me.Pd.DefaultPageSettings.Margins.Left = 10
                        Me.Pd.DefaultPageSettings.Margins.Right = 10
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 547)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1

                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()

                        ' Me.grabar_detalle_vale()
                        grabar_detalle_boleta()
                    End If
                End With
            End If
        End If

        If estado_boleta_electronica = "SI" Then
            If tipo_documento = "BOLETA" Then
                crear_numero_boleta()
                redondear_documento()
                grabar_boleta()
                grabar_detalle_boleta()
                crear_archivo_plano()
            End If
        End If







































        Me.limpiar()
        Me.Enabled = True
        Me.controles(False, True)
        btn_nueva.Focus()
        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
    End Sub


    Private Function ReturnDataSetTicketInterno() As DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ds As New DataSet

        dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
        dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("nro_cotizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha_cotizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre_vendedor", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono_vendedor", GetType(String)))
        dt.Columns.Add(New DataColumn("codigo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(String)))
        dt.Columns.Add(New DataColumn("total", GetType(Integer)))
        dt.Columns.Add(New DataColumn("numero_tecnico", GetType(String)))
        dt.Columns.Add(New DataColumn("subtotal_final", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descuento_final", GetType(Integer)))
        dt.Columns.Add(New DataColumn("total_final", GetType(Integer)))
        dt.Columns.Add(New DataColumn("forma_de_pago", GetType(String)))
        dt.Columns.Add(New DataColumn("precio", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipo_doc", GetType(String)))
        dt.Columns.Add(New DataColumn("valido", GetType(String)))

        Dim tipo_doc As String
        Dim valido As String

  
        tipo_doc = "DETALLE DE BOLETA"
        valido = " "


        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As String
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarPorcentaje As Integer
        Dim VarSubtotal As Integer
        Dim VarTotal As Integer
        Dim condicion_cotizacion As String
        Dim fecha_cotizacion As String
        Dim desc_cotizacion As String
        Dim nro_cotizacion As String
        Dim subtotal_cotizacion As String
        Dim total_cotizacion As String
        Dim vendedor_cotizacion As String

        condicion_cotizacion = txt_condiciones.Text
        fecha_cotizacion = Form_menu_principal.dtp_fecha.Text
        desc_cotizacion = txt_desc.Text
        nro_cotizacion = txt_nro_boleta.Text
        total_cotizacion = Val(txt_total_sale.Text) - Val(txt_total_entra.Text)
        subtotal_cotizacion = Val(txt_total_sale.Text) - Val(txt_total_entra.Text)
        vendedor_cotizacion = minombre

        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
            vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
            VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
            VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
            VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
            VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
            VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
            VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

            dr = dt.NewRow()

            Try
                dr("Imagen") = Imagen_ticket
            Catch
            End Try
            dr("nombre_empresa") = minombreempresa
            dr("giro_empresa") = migiroempresa
            dr("direccion_empresa") = midireccionempresa
            dr("comuna_empresa") = micomunaempresa
            dr("telefono_empresa") = mitelefonoempresa
            dr("correo_empresa") = micorreoempresa
            dr("rut_empresa") = mirutempresa
            dr("nro_cotizacion") = nro_cotizacion
            dr("fecha_cotizacion") = fecha_cotizacion
            dr("nombre_vendedor") = vendedor_cotizacion
            dr("telefono_vendedor") = mitelefono
            dr("codigo") = VarCodProducto
            dr("descripcion") = varnombre
            dr("cantidad") = " X " & VarCantidad & " ="
            dr("total") = VarTotal
            dr("numero_tecnico") = vartecnico
            dr("subtotal_final") = subtotal_cotizacion
            dr("descuento_final") = desc_cotizacion
            dr("total_final") = total_cotizacion
            dr("forma_de_pago") = condicion_cotizacion
            dr("precio") = VarValorUnitario
            dr("tipo_doc") = tipo_doc
            dr("valido") = valido
            dt.Rows.Add(dr)
        Next

        ds.Tables.Add(dt)
        ds.Tables(0).TableName = "CotizacionTicket"
        Dim iDS As New dsCotizacionTicket
        iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
        Return iDS
    End Function


    Sub crear_numero_vale()

        Dim varnumdoc As Integer
        varnumdoc = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(nro_vale) as nro_vale from vale_cambio"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("nro_vale")
                txt_nro_vale_cambio.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_nro_vale_cambio.Text = 1
            Exit Sub
        End Try
        conexion.Close()

    End Sub

    Sub crear_numero_saldo()

        Dim varnumdoc As Integer
        varnumdoc = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(nro_saldo) as nro_saldo from saldo_a_favor"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("nro_saldo")
                txt_nro_vale_saldo.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_nro_vale_saldo.Text = 1
            Exit Sub
        End Try
        conexion.Close()

    End Sub

    Sub crear_numero_boleta()

        Dim varnumdoc As Integer
        varnumdoc = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        Try
            SC.Connection = conexion
            SC.CommandText = "select max(cod_auto) as cod_auto from boleta where tipo_impresion <> 'DIGITADA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                'txt_factura.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_nro_boleta.Text = 1
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
            SC.CommandText = "select n_boleta from boleta where cod_auto='" & (varnumdoc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_boleta")
                txt_nro_boleta.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_nro_boleta.Text = 1
        End Try
        conexion.Close()

    End Sub


    Sub grabar_vale()
        Dim saldo_favor_cliente As Integer
        Dim documento_tipo As String

        fecha()
        saldo_favor_cliente = 0
        documento_tipo = lbl_documento.Text
        documento_tipo = Mid(documento_tipo, 1, Len(documento_tipo) - 1)

        If lbl_referencia.Text.Contains("SALDO A FAVOR") Then
            SC.Connection = conexion
            SC.CommandText = "insert into vale_cambio (nro_vale, fecha, usuario_responsable, total_positivo, total_negativo, saldo_favor_cliente, vendedor_entra, ESTADO, tipo, descuento, porcentaje_desc, neto, iva, hora, documento_referencia, nro_referencia) values ('" & (txt_nro_vale_cambio.Text) & "' , '" & (mifecha2) & "', '" & (miusuario) & "','" & (txt_total_sale.Text) & "','" & (txt_total_entra.Text) & "','" & (saldo_favor_cliente) & "','SISTEMA', 'EMITIDA', 'VALE DE CAMBIO','" & (txt_desc.Text) & "','" & (txt_porcentaje_desc.Text) & "','" & (txt_neto_sale.Text) & "','" & (txt_iva_sale.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_tipo_doc_referencia.Text) & "','" & (txt_nro_doc_referencia.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Else
            SC.Connection = conexion
            SC.CommandText = "insert into vale_cambio (nro_vale, fecha, usuario_responsable, total_positivo, total_negativo, saldo_favor_cliente, vendedor_entra, ESTADO, tipo, descuento, porcentaje_desc, neto, iva, hora, documento_referencia, nro_referencia) values ('" & (txt_nro_vale_cambio.Text) & "' , '" & (mifecha2) & "', '" & (miusuario) & "','" & (txt_total_sale.Text) & "','" & (txt_total_entra.Text) & "','" & (saldo_favor_cliente) & "','" & (txt_rut_vendedor.Text) & "', 'EMITIDA', 'VALE DE CAMBIO','" & (txt_desc.Text) & "','" & (txt_porcentaje_desc.Text) & "','" & (txt_neto_sale.Text) & "','" & (txt_iva_sale.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_tipo_doc_referencia.Text) & "','" & (txt_nro_doc_referencia.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        'SC.Connection = conexion
        'SC.CommandText = "insert into vale_cambio (nro_vale, fecha, usuario_responsable, total_positivo, total_negativo, saldo_favor_cliente, vendedor_entra, ESTADO, tipo, descuento, porcentaje_desc, neto, iva, hora, documento_referencia, nro_referencia) values ('" & (txt_nro_vale_cambio.Text) & "' , '" & (mifecha2) & "', '" & (miusuario) & "','" & (txt_total_sale.Text) & "','" & (txt_total_entra.Text) & "','" & (saldo_favor_cliente) & "','" & (txt_rut_vendedor.Text) & "', 'EMITIDA', 'VALE DE CAMBIO','" & (txt_desc.Text) & "','" & (txt_porcentaje_desc.Text) & "','" & (txt_neto_sale.Text) & "','" & (txt_iva_sale.Text) & "','" & (form_Menu_admin.lbl_hora.Text) & "','" & (txt_tipo_doc_referencia.Text) & "','" & (txt_nro_doc_referencia.Text) & "')"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        If txt_nro_doc_referencia.Text = "" Then
            txt_nro_doc_referencia.Text = "0"
        End If

        SC.Connection = conexion
        SC.CommandText = "insert into boleta_cambio (n_boleta, n_cambio) values (" & (txt_nro_doc_referencia.Text) & " , " & (txt_nro_vale_cambio.Text) & ")"
        DA.SelectCommand = SC
        DA.Fill(DT)
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_fecha.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")
    End Sub

    Sub grabar_detalle_vale()
        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As String
        Dim VarPorcentaje As Integer
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarSubtotal As Integer
        Dim VarTotal As Integer
        'Dim VarProveedor As String
        'Dim VarCosto As Integer
        'Dim VarSaldo As Integer
        fecha()

        Dim documento_tipo As String

        documento_tipo = lbl_documento.Text
        documento_tipo = Mid(documento_tipo, 1, Len(documento_tipo) - 1)


        '  If documento_tipo = "VALE DE CAMBIO" Then


        For i = 0 To grilla_detalle_venta.Rows.Count - 1

            VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
            vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
            VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
            VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
            VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
            VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
            VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
            VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

            SC.Connection = conexion
            SC.CommandText = "insert into detalle_vale_cambio (nro_vale, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total, movimiento) values(" & (txt_nro_vale_cambio.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "update productos set cantidad = cantidad - " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into detalle_total (n_total, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento,  fecha, vendedor, estado) values(" & (txt_nro_vale_cambio.Text) & ",'VALE DE CAMBIO', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE','" & (mifecha2) & "', '" & (miusuario) & "' ,'EMITIDA')"
            DA.SelectCommand = SC
            DA.Fill(DT)



        Next


        '   End If







        For i = 0 To grilla_detalle_venta_entra.Rows.Count - 1

            VarCodProducto = grilla_detalle_venta_entra.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle_venta_entra.Rows(i).Cells(1).Value.ToString
            vartecnico = grilla_detalle_venta_entra.Rows(i).Cells(2).Value.ToString
            VarValorUnitario = grilla_detalle_venta_entra.Rows(i).Cells(3).Value.ToString
            VarCantidad = grilla_detalle_venta_entra.Rows(i).Cells(4).Value.ToString
            VarNeto = grilla_detalle_venta_entra.Rows(i).Cells(5).Value.ToString
            VarIva = grilla_detalle_venta_entra.Rows(i).Cells(6).Value.ToString
            VarSubtotal = grilla_detalle_venta_entra.Rows(i).Cells(7).Value.ToString
            VarPorcentaje = grilla_detalle_venta_entra.Rows(i).Cells(8).Value.ToString
            VarDescuento = grilla_detalle_venta_entra.Rows(i).Cells(9).Value.ToString
            VarTotal = grilla_detalle_venta_entra.Rows(i).Cells(10).Value.ToString

            SC.Connection = conexion
            SC.CommandText = "insert into detalle_vale_cambio (nro_vale, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total, movimiento) values(" & (txt_nro_vale_cambio.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'ENTRA')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "update productos set cantidad = cantidad + " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into detalle_total (n_total, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento,  fecha, vendedor, estado) values(" & (txt_nro_vale_cambio.Text) & ",'VALE DE CAMBIO', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'ENTRA','" & (mifecha2) & "', '" & (miusuario) & "' ,'EMITIDA')"
            DA.SelectCommand = SC
            DA.Fill(DT)





            'If txt_tipo_doc_referencia.Text = "boleta" Then
            '    SC.Connection = conexion
            '    SC.CommandText = "update detalle_boleta set cantidad = '0' where cod_producto = '" & (VarCodProducto) & "' and n_boleta='" & (txt_nro_doc_referencia.Text) & "'"
            '    DA.SelectCommand = SC
            '    DA.Fill(DT)
            'End If

            'If txt_tipo_doc_referencia.Text = "FACTURA" Then
            '    SC.Connection = conexion
            '    SC.CommandText = "update detalle_factura set cantidad = '0' where cod_producto = '" & (VarCodProducto) & "' and n_factura='" & (txt_nro_doc_referencia.Text) & "'"
            '    DA.SelectCommand = SC
            '    DA.Fill(DT)
            'End If

            'If txt_tipo_doc_referencia.Text = "GUIA" Then
            '    SC.Connection = conexion
            '    SC.CommandText = "update detalle_guia set cantidad = '0' where cod_producto = '" & (VarCodProducto) & "' and n_guia='" & (txt_nro_doc_referencia.Text) & "'"
            '    DA.SelectCommand = SC
            '    DA.Fill(DT)
            'End If

        Next
    End Sub


    'sub controles, permite cambiar el estado cuando lo necesitemos.
    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_agregar.Enabled = a
        btn_quitar_elemento.Enabled = a

        txt_codigo.Enabled = a

        btn_grabar.Enabled = a
        btn_limpiar.Enabled = a
        btn_quitar_entra.Enabled = a

        btn_nueva.Enabled = b

        txt_cantidad_agregar.Enabled = a
        txt_porcentaje_desc.Enabled = a
        txt_codigo.Enabled = a
        txt_nombre_producto.Enabled = a

        txt_precio_modificado.Enabled = a

        GroupBox_descuento.Enabled = a
        GroupBox_descuento_entra.Enabled = a
        GroupBox_producto.Enabled = a
        GroupBox_totales.Enabled = a
        GroupBox_total_entra.Enabled = a
        grilla_detalle_venta.Enabled = a
        grilla_detalle_venta_entra.Enabled = a
        lbl_precio.Enabled = a
        lbl_cantidad_agregar.Enabled = a
        txt_codigo.Focus()

    End Sub

    Private Sub btn_nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nueva.Click
        Me.Enabled = False
        Form_cargar_documento_cambio_producto.Show()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_buscar_productos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_productos.GotFocus
        btn_buscar_productos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_productos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_productos.LostFocus
        btn_buscar_productos.BackColor = Color.Transparent
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



    Private Sub btn_grabar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.GotFocus
        btn_grabar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_grabar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.LostFocus
        btn_grabar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub


    Private Sub btn_quitar_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.GotFocus
        btn_quitar_elemento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_elemento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.LostFocus
        btn_quitar_elemento.BackColor = Color.Transparent
    End Sub


    Private Sub btn_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.GotFocus
        btn_agregar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.LostFocus
        btn_agregar.BackColor = Color.Transparent
    End Sub


    Private Sub btn_quitar_entra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_entra.GotFocus
        btn_quitar_entra.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_entra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_entra.LostFocus
        btn_quitar_entra.BackColor = Color.Transparent
    End Sub


    Private Sub txt_precio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_modificado.GotFocus
        txt_precio_modificado.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_precio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_precio_modificado.LostFocus
        txt_precio_modificado.BackColor = Color.White
    End Sub

    Private Sub txt_codigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.GotFocus
        txt_codigo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.LostFocus
        txt_codigo.BackColor = Color.White
    End Sub

    Private Sub txt_cantidad_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.GotFocus
        txt_cantidad_agregar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_cantidad_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_agregar.LostFocus
        txt_cantidad_agregar.BackColor = Color.White
    End Sub

    Private Sub txt_porcentaje_desc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_porcentaje_desc.GotFocus
        txt_porcentaje_desc.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_porcentaje_desc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_porcentaje_desc.LostFocus
        txt_porcentaje_desc.BackColor = Color.White
    End Sub

    'nos permite limpiar los campos de la pantalla cuando lo necesitemos.
    Sub limpiar()


        txt_aplicacion.Text = ""
        txt_cantidad.Text = ""
        txt_cantidad_agregar.Text = ""
        txt_codigo.Text = ""
        txt_costo.Text = ""
        txt_desc.Text = ""
        txt_desc_entra.Text = ""
        txt_desc_millar.Text = ""
        txt_factor.Text = ""
        txt_iva_sale.Text = ""
        txt_iva_entra.Text = ""
        txt_iva_millar.Text = ""
        txt_marca.Text = ""
        txt_neto_sale.Text = ""
        txt_neto_entra.Text = ""
        txt_neto_millar.Text = ""
        txt_nombre_producto.Text = ""
        txt_nombre_proveedor.Text = ""
        txt_nro_doc_referencia.Text = ""
        txt_nro_vale_cambio.Text = ""
        txt_numero_tecnico.Text = ""
        txt_porcentaje_desc.Text = ""
        txt_precio.Text = ""
        txt_proveedor.Text = ""
        txt_rut_vendedor.Text = ""
        txt_sub_total.Text = ""
        txt_sub_total_entra.Text = ""
        txt_sub_total_millar.Text = ""
        txt_total_entra.Text = ""
        txt_total_millar.Text = ""
        txt_precio_modificado.Text = ""
        txt_total_millar.Text = ""
        txt_porcentaje_desc_entra.Text = ""
        lbl_referencia.Text = "DOCUMENTO DE REFERENCIA"




        grilla_detalle_venta.Rows.Clear()
        grilla_detalle_venta_entra.Rows.Clear()

        txt_codigo.Focus()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            limpiar()
            Me.Enabled = False
            Form_cargar_documento_cambio_producto.Show()
        End If
    End Sub

    Private Sub txt_porcentaje_desc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_porcentaje_desc.TextChanged
        calcular_totales_sale()
    End Sub

    Private Sub txt_porcentaje_desc_entra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_porcentaje_desc_entra.TextChanged
        calcular_totales_entra()
    End Sub

    Private Sub btn_buscar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos.Click
        Me.Enabled = False
        conexion.Close()
        Form_buscador_productos_cambio_de_producto.Show()
    End Sub

    Private Sub grilla_detalle_venta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_detalle_venta.CellContentClick

    End Sub

    Private Sub grilla_detalle_venta_entra_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_detalle_venta_entra.DoubleClick
        If grilla_detalle_venta_entra.CurrentRow.Cells(4).Selected Then
            ' Form_descuento.lbl_codigo.Text = codigo_producto_descuento & ", " & nombre_producto_descuento

            Form_cambiar_cantidad_cambio_producto.Show()

            Me.Enabled = False


        End If
    End Sub


    Sub grabar_boleta()

        Dim tipo_impresion As String
        If estado_boleta_electronica = "SI" Then
            tipo_impresion = "ELECTRONICA"
        Else
            tipo_impresion = "MANUAL"
        End If

        'pie_credito = 0

        SC.Connection = conexion
        SC.CommandText = "insert into boleta (caja, n_boleta, tipo, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva,  subtotal, total, condiciones,estado, usuario_responsable, hora, porcentaje_desc, tipo_impresion, pie, condicion_de_pago_pie, comision) values ('" & (nombre_pc) & "', " & (txt_nro_boleta.Text) & " , 'BOLETA DE CAMBIO','-','0','" & (dtp_fecha.Text) & "'," & (txt_desc_final.Text) & "," & (txt_neto_final.Text) & "," & (txt_iva_final.Text) & "," & (txt_sub_total_final.Text) & "," & (txt_total_final.Text) & ",'" & (txt_condiciones.Text) & "','" & ("EMITIDA") & "','" & (miusuario) & "','" & (Form_menu_principal.lbl_hora.Text) & "','0','" & (tipo_impresion) & "', '0', '-','0')"
        DA.SelectCommand = SC
        DA.Fill(DT)


        If txt_nro_vale_cambio.Text = "" Then
            txt_nro_vale_cambio.Text = "0"
        End If

        SC.Connection = conexion
        SC.CommandText = "insert into boleta_cambio (n_boleta, n_cambio) values ('" & (txt_nro_boleta.Text) & "' , '" & (txt_nro_vale_cambio.Text) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "insert into detalle_condicion_de_pago (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha, caja) values(" & (txt_nro_boleta.Text) & ", '" & ("boleta") & "', '" & (txt_total_final.Text) & "', '" & (txt_condiciones.Text) & "', 'EMITIDA', '" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (nombre_pc) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

    End Sub

    Public Function EliminarFormato(ByVal numeroFormateado As String) As String

        Dim pattern As String = "[\.\-]"
        Dim replacement As String = String.Empty
        Dim regex As New System.Text.RegularExpressions.Regex(pattern)

        Return regex.Replace(numeroFormateado, replacement)

    End Function




    Sub grabar_saldo()

        Dim saldo As String
        saldo = Replace(lbl_venta.Text, ".", "")

        saldo = EliminarFormato(lbl_venta.Text)

        SC.Connection = conexion
        SC.CommandText = "insert into saldo_a_favor (nro_saldo, total_saldo, doc_referencia, NRO_referencia, estado, usuario_responsable, fecha_saldo) values ('" & (txt_nro_vale_saldo.Text) & "', '" & (saldo) & "', 'VALE DE CAMBIO', '" & (txt_nro_vale_cambio.Text) & "', 'EMITIDA','" & (miusuario) & "','" & (dtp_fecha.Text) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

    End Sub



    Sub grabar_detalle_boleta()
        'Dim VarCodProducto As String
        'Dim varnombre As String
        'Dim vartecnico As String
        'Dim VarValorUnitario As Integer
        'Dim VarCantidad As String
        'Dim VarPorcentaje As Integer
        'Dim VarDescuento As Integer
        'Dim VarNeto As Integer
        'Dim VarIva As Integer
        'Dim VarSubtotal As Integer
        'Dim VarTotal As Integer
        'Dim VarProveedor As String
        'Dim VarCosto As Integer
        'Dim VarSaldo As Integer



















        'For i = 0 To grilla_detalle_venta_entra.Rows.Count - 1

        '    VarCodProducto = grilla_detalle_venta_entra.Rows(i).Cells(0).Value.ToString
        '    varnombre = grilla_detalle_venta_entra.Rows(i).Cells(1).Value.ToString
        '    vartecnico = grilla_detalle_venta_entra.Rows(i).Cells(2).Value.ToString
        '    VarValorUnitario = grilla_detalle_venta_entra.Rows(i).Cells(3).Value.ToString
        '    VarCantidad = grilla_detalle_venta_entra.Rows(i).Cells(4).Value.ToString
        '    VarNeto = grilla_detalle_venta_entra.Rows(i).Cells(5).Value.ToString
        '    VarIva = grilla_detalle_venta_entra.Rows(i).Cells(6).Value.ToString
        '    VarSubtotal = grilla_detalle_venta_entra.Rows(i).Cells(7).Value.ToString
        '    VarPorcentaje = grilla_detalle_venta_entra.Rows(i).Cells(8).Value.ToString
        '    VarDescuento = grilla_detalle_venta_entra.Rows(i).Cells(9).Value.ToString
        '    VarTotal = grilla_detalle_venta_entra.Rows(i).Cells(10).Value.ToString

        '    SC.Connection = conexion
        '    SC.CommandText = "insert into detalle_boleta (n_boleta, cod_producto, detalle_nombre, numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_nro_boleta.Text) & ",'" & (VarCodProducto) & "','" & (varnombre) & "','" & (vartecnico) & "'," & (VarValorUnitario) & ",'" & "-" & (VarCantidad) & "'," & (VarPorcentaje) & "," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ")"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)

        '    SC.Connection = conexion
        '    SC.CommandText = "update productos set cantidad = cantidad + " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)

        '    SC.Connection = conexion
        '    SC.CommandText = "insert into detalle_total (n_total, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento,  fecha, vendedor, estado) values(" & (txt_nro_vale_cambio.Text) & ",'VALE CAMBIO', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'ENTRA','" & (mifecha2) & "', '" & (miusuario) & "' ,'EMITIDA')"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Next








        'For i = 0 To grilla_detalle_venta.Rows.Count - 1

        '    VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
        '    varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
        '    vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
        '    VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
        '    VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
        '    VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
        '    VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
        '    VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
        '    VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
        '    VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
        '    VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString



        '    SC.Connection = conexion
        '    SC.CommandText = "update productos set cantidad = cantidad - " & (Int(VarCantidad)) & " where cod_producto = '" & (VarCodProducto) & "'"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)

        '    SC.Connection = conexion
        '    SC.CommandText = "insert into detalle_total (n_total, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_nro_boleta.Text) & ",'boleta DE CAMBIO', '" & (VarCodProducto) & "','" & (varnombre) & "'," & (VarValorUnitario) & ",'" & (VarCantidad) & "'," & (VarDescuento) & "," & (VarNeto) & ", " & (VarIva) & "," & (VarSubtotal) & "," & (VarTotal) & ",'SALE','" & (dtp_fecha.Text) & "', '" & (miusuario) & "' ,'EMITIDA')"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)

        'Next




        SC.Connection = conexion
        SC.CommandText = "update productos set cantidad = cantidad - " & (1) & " where cod_producto = '029265'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "insert into detalle_total (n_total, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento, fecha, vendedor, estado) values(" & (txt_nro_boleta.Text) & ",'boleta DE CAMBIO', '999999','" & ("CAMBIO DE PRODUCTO, VALE NRO. " & txt_nro_vale_cambio.Text) & "'," & (txt_sub_total_final.Text) & ",'1','0','0', '0'," & (txt_sub_total_final.Text) & "," & (txt_sub_total_final.Text) & ",'SALE','" & (dtp_fecha.Text) & "', '" & (miusuario) & "' ,'EMITIDA')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "insert into detalle_boleta (n_boleta, cod_producto, detalle_nombre,  numero_tecnico, valor_unitario, cantidad, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_nro_boleta.Text) & ",'999999','" & ("CAMBIO DE PRODUCTO, VALE NRO. " & txt_nro_vale_cambio.Text) & "','-',    " & (txt_sub_total_final.Text) & ",'1','0','0',    '0', " & (0) & "," & (txt_sub_total_final.Text) & "," & (txt_sub_total_final.Text) & ")"
        DA.SelectCommand = SC
        DA.Fill(DT)

    End Sub

    Private Sub grilla_detalle_venta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_detalle_venta.Click
        If grilla_detalle_venta.Rows.Count <= 0 Then
            Exit Sub
        End If
        If grilla_detalle_venta.CurrentRow.Cells(0).Value() = "*" Then
            Exit Sub
        End If
        txt_codigo.Text = grilla_detalle_venta.CurrentRow.Cells(0).Value()

        mostrar_datos_productos()
        txt_precio_modificado.Text = grilla_detalle_venta.CurrentRow.Cells(7).Value()
        mostrar_nombre_proveedor()
        txt_cantidad_agregar.Focus()
    End Sub

    Sub mostrar_datos_productos()
        If txt_codigo.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                txt_precio_modificado.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
            End If
            conexion.Close()
        End If
    End Sub

    Private Sub txt_codigo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            Form_buscador_productos_cambio_de_producto.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Function ReturnDataSet() As DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ds As New DataSet

        'Dim Total_letra As Integer
        'Dim Comprobar_letra As Integer

        'Total_letra = (txt_total.Text) / (txt_cargar.Text)
        'Comprobar_letra = (Total_letra) * (txt_cargar.Text)
        'Comprobar_letra = (txt_total.Text) - (Comprobar_letra)
        'Total_letra = (Total_letra) + (Comprobar_letra)
        'Round(Total_letra)

        Dim fecha_mas_tres As String
        fecha_mas_tres = dtp_fecha.Value.AddMonths(Val(+3))

        If fecha_mas_tres.Length > 10 Then
            fecha_mas_tres = fecha_mas_tres.Substring(0, 10)
        End If



        dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
        dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))

        dt.Columns.Add(New DataColumn("nro_saldo", GetType(String)))
        dt.Columns.Add(New DataColumn("total_saldo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("referencia_saldo", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha_saldo", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre_vendedor", GetType(String)))
        dt.Columns.Add(New DataColumn("desglose", GetType(String)))
        dt.Columns.Add(New DataColumn("validez", GetType(String)))
        dr = dt.NewRow()

        Try
            'dr("Imagen") = ImageToByte(Image.FromFile("C:\Sistema de ventas\Logo de empresa\logo_ticket.jpg"))
            dr("Imagen") = Imagen_ticket

        Catch
        End Try

        dr("nro_saldo") = txt_nro_vale_saldo.Text
        dr("total_saldo") = lbl_venta.Text
        dr("referencia_saldo") = "VALE DE CAMBIO " & txt_nro_vale_cambio.Text
        dr("fecha_saldo") = dtp_fecha.Text
        dr("nombre_vendedor") = minombre
        dr("validez") = "VALIDO HASTA EL " & fecha_mas_tres

        dr("desglose") = desglose_saldo
        dr("nombre_empresa") = minombreempresa
        dr("giro_empresa") = migiroempresa
        dr("direccion_empresa") = midireccionempresa
        dr("comuna_empresa") = micomunaempresa
        dr("telefono_empresa") = mitelefonoempresa
        dr("correo_empresa") = micorreoempresa
        dr("rut_empresa") = mirutempresa
        dt.Rows.Add(dr)

        ds.Tables.Add(dt)
        ds.Tables(0).TableName = "Saldo"

        Dim iDS As New dsSaldoafavor

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

    Private Sub grilla_detalle_venta_entra_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_detalle_venta_entra.CellContentClick

    End Sub








    Sub crear_archivo_plano()
        'Dim sRenglon As String = Nothing
        'Dim strStreamW As Stream = Nothing
        'Dim strStreamWriter As StreamWriter = Nothing
        'Dim ContenidoArchivo As String = Nothing
        '' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
        'Dim PathArchivo As String


        'Dim VarCodProducto As String
        'Dim varnombre As String
        'Dim vartecnico As String
        'Dim VarValorUnitario As Integer
        'Dim VarCantidad As String
        'Dim VarPorcentaje As String
        'Dim VarDescuento As Integer
        'Dim VarNeto As Integer
        'Dim VarIva As Integer
        'Dim VarSubtotal As Integer
        'Dim VarTotal As Integer
        ''Dim VarProveedor As String
        ''Dim VarCosto As Integer
        ''Dim VarSaldo As Integer

        'Dim nro_linea As String

        'Dim nombre_cliente As String
        'nombre_cliente = "SIN NOMBRE"
        'If nombre_cliente.Length > 40 Then
        '    nombre_cliente = nombre_cliente.Substring(0, 40)
        'End If

        'Dim giro_cliente As String
        'giro_cliente = "SIN GIRO"
        'If giro_cliente.Length > 40 Then
        '    giro_cliente = giro_cliente.Substring(0, 40)
        'End If

        'Dim direccion_cliente As String
        'direccion_cliente = "SIN DIRECCION"
        'If direccion_cliente.Length > 59 Then
        '    direccion_cliente = direccion_cliente.Substring(0, 60)
        'End If

        'Dim comuna_cliente As String
        'comuna_cliente = "SIN COMUNA"
        'If comuna_cliente.Length > 19 Then
        '    comuna_cliente = comuna_cliente.Substring(0, 20)
        'End If

        'Dim ciudad_cliente As String
        'ciudad_cliente = "SIN CIUDAD"
        'If ciudad_cliente.Length > 19 Then
        '    ciudad_cliente = ciudad_cliente.Substring(0, 20)
        'End If

        'Dim correo_cliente As String
        'correo_cliente = "SIN CORREO"
        'If correo_cliente.Length > 199 Then
        '    correo_cliente = correo_cliente.Substring(0, 200)
        'End If

        'Dim telefono_cliente As String
        'telefono_cliente = "0"
        'If telefono_cliente.Length > 8 Then
        '    telefono_cliente = telefono_cliente.Substring(0, 8)
        'End If

        'If correo_cliente = "-" Then
        '    correo_cliente = ""
        'End If

        ''If txt_folio.Text = "-" Then
        ''    txt_folio.Text = ""
        ''End If

        'Dim condicion As String

        'condicion = txt_condiciones.Text

        ''If txt_condiciones.Text = "EFECTIVO" Then
        ''    condicion = "CONTADO " & "(" & txt_condiciones.Text & ")"
        ''End If
        ''If txt_condiciones.Text = "ABCDIN" Then
        ''    condicion = "CONTADO " & "(" & txt_condiciones.Text & ")"
        ''End If
        ''If txt_condiciones.Text = "CENCOSUD" Then
        ''    condicion = "CONTADO " & "(" & txt_condiciones.Text & ")"
        ''End If
        ''If txt_condiciones.Text = "C&D" Then
        ''    condicion = "CONTADO " & "(" & txt_condiciones.Text & ")"
        ''End If
        ''If txt_condiciones.Text = "PRESTO" Then
        ''    condicion = "CONTADO " & "(" & txt_condiciones.Text & ")"
        ''End If
        ''If combo_condiciones.Text = "RYPLEY" Then
        ''    condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        ''End If
        ''If combo_condiciones.Text = "VISA" Then
        ''    condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        ''End If
        ''If combo_condiciones.Text = "MASTERCARD" Then
        ''    condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        ''End If
        ''If combo_condiciones.Text = "BANCARIA" Then
        ''    condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        ''End If
        ''If combo_condiciones.Text = "REDCOMPRA" Then
        ''    condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        ''End If
        ''If combo_condiciones.Text = "TRANSFERENCIA" Then
        ''    condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        ''End If
        ''If combo_condiciones.Text = "CHEQUE AL DIA" Then
        ''    condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        ''End If
        ''If combo_condiciones.Text = "CHEQUE 15 DIAS" Then
        ''    condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        ''End If
        ''If combo_condiciones.Text = "CHEQUE 30 DIAS" Then
        ''    condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        ''End If
        ''If combo_condiciones.Text = "CHEQUE 45 DIAS" Then
        ''    condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        ''End If
        ''If combo_condiciones.Text = "CHEQUE 60 DIAS" Then
        ''    condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        ''End If
        ''If combo_condiciones.Text = "CHEQUE 30-60 DIAS" Then
        ''    condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        ''End If
        ''If combo_condiciones.Text = "CHEQUE 30-60-90 DIAS" Then
        ''    condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        ''End If
        ''If combo_condiciones.Text = "PENDIENTE" Then
        ''    condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        ''End If
        ''If combo_condiciones.Text = "TRANSFERENCIA" Then
        ''    condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        ''End If
        ''If combo_condiciones.Text = "CREDITO" Then
        ''    condicion = "CREDITO " & "(" & combo_condiciones.Text & ")"
        ''End If


        ''correcto sin modificaciones






        'Try

        '    If Directory.Exists(ruta_archivos_planos) = False Then ' si no existe la carpeta se crea
        '        Directory.CreateDirectory(ruta_archivos_planos)
        '    End If

        '    'If Directory.Exists("C:\Carpeta Facturacion Electronica") = False Then ' si no existe la carpeta se crea
        '    '    Directory.CreateDirectory("C:\Carpeta Facturacion Electronica")
        '    'End If

        '    Windows.Forms.Cursor.Current = Cursors.WaitCursor
        '    ' PathArchivo = "C:\carpeta\Archivo" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
        '    ' PathArchivo = "\\SERVER\Claudio Calderon R\Capeta\Archivo '" & (combo_venta.Text) & "'" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
        '    ' PathArchivo = "C:\Carpeta Facturacion Electronica\" & (combo_venta.Text) & " " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual
        '    PathArchivo = ruta_archivos_planos & "\" & "boleta " & (txt_nro_boleta.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

        '    'verificamos si existe el archivo

        '    If File.Exists(PathArchivo) Then
        '        strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
        '    Else
        '        strStreamW = File.Create(PathArchivo) ' lo creamos
        '    End If

        '    strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

        '    'escribimos en el archivo
        '    strStreamWriter.WriteLine("->boleta<-" & vbNewLine _
        '                                & ("39") & ";" & (txt_nro_boleta.Text) & ";" & (dtp_fecha.Text) & ";" & ("3") & ";" & ("0") & ";" & ("") & ";" & ("") & ";" & ("") & ";" & ("11111111-1") & ";" & ("0") & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (comuna_cliente) & ";" & (ciudad_cliente) & ";" & (correo_cliente) & ";" & vbNewLine _
        '                                & "->boletaTotales<-" & vbNewLine _
        '                                & (txt_neto_final.Text) & ";" & ("0") & ";" & (txt_iva_final.Text) & ";" & (txt_total_final.Text) & ";" & ("0") & ";" & ("0") & ";" & ("0") & ";" & ("0") & ";" & vbNewLine _
        '                                & "->boletaDetalle<-")

        '    nro_linea = 0
        '    '   For i = 0 To grilla_detalle_venta.Rows.Count - 1
        '    nro_linea = nro_linea + 1





        '    'Dim iva As Integer
        '    'Dim neto As Integer
        '    Dim iva_valor As String






        '    VarValorUnitario = txt_sub_total_final.Text

        '    iva_valor = valor_iva / 100 + 1
        '    VarNeto = Round(VarValorUnitario / iva_valor)
        '    VarIva = (((txt_neto_final.Text) * valor_iva) / 100)
        '    txt_iva_final.Text = (VarValorUnitario) - (VarNeto)







        '    VarCodProducto = "999999"
        '    varnombre = "CAMBIO DE PRODUCTO, VALE NRO. " & txt_nro_vale_cambio.Text
        '    vartecnico = ""

        '    VarCantidad = "1"
        '    'VarNeto = 
        '    'VarIva = 
        '    VarSubtotal = VarValorUnitario
        '    VarPorcentaje = "0"
        '    VarDescuento = "0"

        '    VarTotal = VarValorUnitario

        '    VarPorcentaje = 0
        '    VarDescuento = 0
        '    VarValorUnitario = VarSubtotal

        '    If VarCodProducto.Length > 34 Then
        '        VarCodProducto = VarCodProducto.Substring(0, 35)
        '    End If

        '    varnombre = varnombre & " " & vartecnico

        '    If varnombre.Length > 80 Then
        '        varnombre = varnombre.Substring(0, 80)
        '    End If

        '    varnombre = VarCodProducto & " - " & varnombre & " " & vartecnico

        '    If varnombre.Length > 52 Then
        '        varnombre = varnombre.Substring(0, 51)
        '    End If

        '    VarCantidad = Replace(VarCantidad, ",", ".")
        '    VarPorcentaje = Replace(VarPorcentaje, ",", ".")

        '    strStreamWriter.WriteLine(nro_linea & ";" & (VarCodProducto) & ";" & (varnombre) & ";" & ("0") & ";" & (VarCantidad) & ";" & (VarValorUnitario) & ";" & ("0") & ";" & (VarTotal) & ";" & ("INT11") & ";" & ("UN") & ";" & ("") & ";")
        '    '  Next



        '    strStreamWriter.WriteLine("->boletaDescRec<-" & vbNewLine _
        '                                & ("1") & ";" & ("D") & ";" & ("Descuento") & ";" & ("$") & ";" & (txt_desc_final.Text) & ";" & ("0") & ";" & vbNewLine _
        '                                & "->boletaReferencia<-" & vbNewLine _
        '                                & ("1") & ";" & ("") & ";" & ("") & ";" & vbNewLine _
        '                                & "->Observacion<-" & vbNewLine _
        '                                & (txt_condiciones.Text) & ", " & minombre & ", " & mirecintoempresa & ";")

        '    strStreamWriter.Close() ' cerramos

        'Catch ex As Exception
        '    MsgBox("ERROR AL GUARDAR LA INFORMACION EN EL ARCHIVO. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
        '    strStreamWriter.Close() ' cerramos
        'End Try

        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim ContenidoArchivo As String = Nothing
        ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
        Dim PathArchivo As String


        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As String
        Dim VarPorcentaje As String
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarSubtotal As Integer
        Dim VarTotal As Integer
        'Dim VarProveedor As String
        'Dim VarCosto As Integer
        'Dim VarSaldo As Integer

        Dim nro_linea As String

        Dim nombre_cliente As String
        nombre_cliente = "SIN NOMBRE"
        If nombre_cliente.Length > 40 Then
            nombre_cliente = nombre_cliente.Substring(0, 40)
        End If

        Dim giro_cliente As String
        giro_cliente = "SIN GIRO"
        If giro_cliente.Length > 40 Then
            giro_cliente = giro_cliente.Substring(0, 40)
        End If

        Dim direccion_cliente As String
        direccion_cliente = "SIN DIRECCION"
        If direccion_cliente.Length > 59 Then
            direccion_cliente = direccion_cliente.Substring(0, 60)
        End If

        Dim comuna_cliente As String
        comuna_cliente = "SIN COMUNA"
        If comuna_cliente.Length > 19 Then
            comuna_cliente = comuna_cliente.Substring(0, 20)
        End If

        Dim ciudad_cliente As String
        ciudad_cliente = "SIN CIUDAD"
        If ciudad_cliente.Length > 19 Then
            ciudad_cliente = ciudad_cliente.Substring(0, 20)
        End If

        Dim correo_cliente As String
        correo_cliente = "SIN CORREO"
        If correo_cliente.Length > 199 Then
            correo_cliente = correo_cliente.Substring(0, 200)
        End If

        Dim telefono_cliente As String
        telefono_cliente = "0"
        If telefono_cliente.Length > 8 Then
            telefono_cliente = telefono_cliente.Substring(0, 8)
        End If

        If correo_cliente = "-" Then
            correo_cliente = ""
        End If

        'If txt_folio.Text = "-" Then
        '    txt_folio.Text = ""
        'End If

        Dim condicion As String

        condicion = txt_condiciones.Text

        'If txt_condiciones.Text = "EFECTIVO" Then
        '    condicion = "CONTADO " & "(" & txt_condiciones.Text & ")"
        'End If
        'If txt_condiciones.Text = "ABCDIN" Then
        '    condicion = "CONTADO " & "(" & txt_condiciones.Text & ")"
        'End If
        'If txt_condiciones.Text = "CENCOSUD" Then
        '    condicion = "CONTADO " & "(" & txt_condiciones.Text & ")"
        'End If
        'If txt_condiciones.Text = "C&D" Then
        '    condicion = "CONTADO " & "(" & txt_condiciones.Text & ")"
        'End If
        'If txt_condiciones.Text = "PRESTO" Then
        '    condicion = "CONTADO " & "(" & txt_condiciones.Text & ")"
        'End If
        'If combo_condiciones.Text = "RYPLEY" Then
        '    condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        'End If
        'If combo_condiciones.Text = "VISA" Then
        '    condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        'End If
        'If combo_condiciones.Text = "MASTERCARD" Then
        '    condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        'End If
        'If combo_condiciones.Text = "BANCARIA" Then
        '    condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        'End If
        'If combo_condiciones.Text = "REDCOMPRA" Then
        '    condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        'End If
        'If combo_condiciones.Text = "TRANSFERENCIA" Then
        '    condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        'End If
        'If combo_condiciones.Text = "CHEQUE AL DIA" Then
        '    condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        'End If
        'If combo_condiciones.Text = "CHEQUE 15 DIAS" Then
        '    condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        'End If
        'If combo_condiciones.Text = "CHEQUE 30 DIAS" Then
        '    condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        'End If
        'If combo_condiciones.Text = "CHEQUE 45 DIAS" Then
        '    condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        'End If
        'If combo_condiciones.Text = "CHEQUE 60 DIAS" Then
        '    condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        'End If
        'If combo_condiciones.Text = "CHEQUE 30-60 DIAS" Then
        '    condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        'End If
        'If combo_condiciones.Text = "CHEQUE 30-60-90 DIAS" Then
        '    condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        'End If
        'If combo_condiciones.Text = "PENDIENTE" Then
        '    condicion = "DOCUMENTADA " & "(" & combo_condiciones.Text & ")"
        'End If
        'If combo_condiciones.Text = "TRANSFERENCIA" Then
        '    condicion = "CONTADO " & "(" & combo_condiciones.Text & ")"
        'End If
        'If combo_condiciones.Text = "CREDITO" Then
        '    condicion = "CREDITO " & "(" & combo_condiciones.Text & ")"
        'End If


        'correcto sin modificaciones






        Try

            If Directory.Exists(ruta_archivos_planos) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(ruta_archivos_planos)
            End If

            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            ' PathArchivo = "C:\carpeta\Archivo" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
            ' PathArchivo = "\\SERVER\Claudio Calderon R\Capeta\Archivo '" & (combo_venta.Text) & "'" & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual
            ' PathArchivo = "C:\Carpeta Facturacion Electronica\" & (combo_venta.Text) & " " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual
            PathArchivo = ruta_archivos_planos & "\" & "Boleta " & (txt_nro_boleta.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

            'verificamos si existe el archivo

            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            'escribimos en el archivo
            strStreamWriter.WriteLine("->Boleta<-" & vbNewLine _
                                        & ("39") & ";" & (txt_nro_boleta.Text) & ";" & (dtp_fecha.Text) & ";" & ("3") & ";" & ("0") & ";" & ("") & ";" & ("") & ";" & ("") & ";" & ("11111111-1") & ";" & ("0") & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (comuna_cliente) & ";" & (ciudad_cliente) & ";" & (correo_cliente) & ";" & vbNewLine _
                                        & "->BoletaTotales<-" & vbNewLine _
                                        & (txt_neto_final.Text) & ";" & ("0") & ";" & (txt_iva_final.Text) & ";" & (txt_total_final.Text) & ";" & ("0") & ";" & ("0") & ";" & ("0") & ";" & ("0") & ";" & vbNewLine _
                                        & "->BoletaDetalle<-")

            nro_linea = 0
            '   For i = 0 To grilla_detalle_venta.Rows.Count - 1
            nro_linea = nro_linea + 1

            Dim iva_valor As String
            VarValorUnitario = txt_sub_total_final.Text
            iva_valor = valor_iva / 100 + 1
            VarNeto = Round(VarValorUnitario / iva_valor)
            VarIva = (((txt_neto_final.Text) * valor_iva) / 100)
            txt_iva_final.Text = (VarValorUnitario) - (VarNeto)
            VarCodProducto = "999999"
            varnombre = "CAMBIO DE PRODUCTO, VALE NRO. " & txt_nro_vale_cambio.Text
            vartecnico = ""

            VarCantidad = "1"
            'VarNeto = 
            'VarIva = 
            VarSubtotal = VarValorUnitario
            VarPorcentaje = "0"
            VarDescuento = "0"

            VarTotal = VarValorUnitario

            VarPorcentaje = 0
            VarDescuento = 0
            VarValorUnitario = VarSubtotal

            If VarCodProducto.Length > 34 Then
                VarCodProducto = VarCodProducto.Substring(0, 35)
            End If

            varnombre = varnombre & " " & vartecnico

            If varnombre.Length > 80 Then
                varnombre = varnombre.Substring(0, 80)
            End If

            varnombre = VarCodProducto & " - " & varnombre & " " & vartecnico

            If varnombre.Length > 52 Then
                varnombre = varnombre.Substring(0, 51)
            End If

            VarCantidad = Replace(VarCantidad, ",", ".")
            VarPorcentaje = Replace(VarPorcentaje, ",", ".")

            strStreamWriter.WriteLine(nro_linea & ";" & (VarCodProducto) & ";" & (varnombre) & ";" & ("0") & ";" & (VarCantidad) & ";" & (VarValorUnitario) & ";" & ("0") & ";" & (VarTotal) & ";" & ("INT11") & ";" & ("UN") & ";" & ("") & ";")
            '  Next

            strStreamWriter.WriteLine("->BoletaDescRec<-" & vbNewLine _
                                        & ("1") & ";" & ("D") & ";" & ("Descuento") & ";" & ("$") & ";" & (txt_desc_final.Text) & ";" & ("0") & ";" & vbNewLine _
                                        & "->BoletaReferencia<-" & vbNewLine _
                                        & ("1") & ";" & ("") & ";" & ("") & ";" & vbNewLine _
                                        & "->Observacion<-" & vbNewLine _
                                        & (txt_condiciones.Text) & ", " & minombre & ", " & mirecintoempresa & ";")
            strStreamWriter.Close() ' cerramos

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LA INFORMACION EN EL ARCHIVO. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
            strStreamWriter.Close() ' cerramos
        End Try
    End Sub

    Sub revisar_traspaso()
        Dim VarCodProducto As String
        Dim VarCantidad As String
        Dim VarCodProductoRevisar As String
        Dim VarCantidadRevisar As String
        Dim VarCantidadNueva As Integer
        Dim VarPrecio As Integer

        conexion.Close()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from `vale_cambio`, `detalle_vale_cambio` WHERE documento_referencia='" & (Form_cargar_documento_cambio_producto.combo_documento.Text) & "' and nro_referencia='" & (Form_cargar_documento_cambio_producto.txt_nro_documento.Text) & "' and vale_cambio.nro_vale=detalle_vale_cambio.nro_vale and MOVIMIENTO='ENTRA';"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                VarCodProductoRevisar = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                VarCantidadRevisar = DS.Tables(DT.TableName).Rows(i).Item("cantidad")

                For u = 0 To grilla_detalle_venta_entra.Rows.Count - 1
                    VarCodProducto = grilla_detalle_venta_entra.Rows(u).Cells(0).Value.ToString
                    VarCantidad = grilla_detalle_venta_entra.Rows(u).Cells(4).Value.ToString
                    VarPrecio = grilla_detalle_venta_entra.Rows(u).Cells(3).Value.ToString

                    If VarCodProducto = VarCodProductoRevisar Then
                        VarCantidadNueva = Val(VarCantidad) - Val(VarCantidadRevisar)
                        grilla_detalle_venta_entra.Rows(u).Cells(4).Value = VarCantidadNueva
                        grilla_detalle_venta_entra.Rows(u).Cells(10).Value = VarCantidadNueva * VarPrecio
                    End If
                Next
            Next
        End If

        conexion.Close()
        calcular_totales_entra()
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

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

        Dim stringFormat_left As New StringFormat()
        stringFormat_left.Alignment = StringAlignment.Near
        stringFormat_left.LineAlignment = StringAlignment.Near

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

        e.Graphics.DrawString(minombreempresa, Font_texto_empresa, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(migiroempresa, Font_texto_empresa, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font_texto_empresa, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font_texto_empresa, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font_texto_empresa, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font_texto_empresa, Brushes.Black, rect6, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font_texto_empresa, Brushes.Black, rect7, stringFormat)

        e.Graphics.DrawString("SALDO A FAVOR", Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)


        e.Graphics.DrawString("NRO. SALDO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 245)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 245)
        e.Graphics.DrawString(txt_nro_vale_saldo.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 245)

        e.Graphics.DrawString("VENDEDOR", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 260)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 260)
        e.Graphics.DrawString(minombre, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 260)

        e.Graphics.DrawString("FECHA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 275)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 275)
        e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 275)

        e.Graphics.DrawString("REFERENCIA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 290)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 290)
        e.Graphics.DrawString("VALE DE CAMBIO " & txt_nro_vale_cambio.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 290)

        e.Graphics.DrawString("TOTAL", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 305)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 305)
        e.Graphics.DrawString(lbl_venta.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 305)

        e.Graphics.DrawString("DESGLOSE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 320)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 320)
        'e.Graphics.DrawString(desglose_saldo, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 320)

        Dim rect_desglose_saldo As New Rectangle(margen_izquierdo + 85, margen_superior + 320, margen_izquierdo + 200, margen_superior + 15)
        e.Graphics.DrawString(desglose_saldo, Font_texto_cabecera, Brushes.Black, rect_desglose_saldo, stringFormat_left)
        Dim texto_validez As String

        texto_validez = "PARA COBRAR ESTE ABONO AL MOMENTO DE LA ENTREGA DE LA MERCADERÍA, SOLO SE RECIBE ESTE BOLETO ORIGINAL, NO UNA COPIA NI OTRO MEDIO DONDE SE VEA LA IMAGEN."

        Dim rect_validez As New Rectangle(margen_izquierdo + 0, margen_superior + 365, margen_izquierdo + 300, margen_superior + 60)
        e.Graphics.DrawString(texto_validez, Font_texto_titulo_detalle, Brushes.Black, rect_validez, stringFormat)

  

        Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + 450, margen_izquierdo + 270, margen_superior + 15)
        e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)
    End Sub




    Private Sub PrintDocument_ticket_interno_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument_ticket_interno.PrintPage
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

        e.Graphics.DrawString(minombreempresa, Font_texto_empresa, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(migiroempresa, Font_texto_empresa, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font_texto_empresa, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font_texto_empresa, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font_texto_empresa, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font_texto_empresa, Brushes.Black, rect6, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font_texto_empresa, Brushes.Black, rect7, stringFormat)




        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As String
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarPorcentaje As Integer
        Dim VarSubtotal As Integer
        Dim VarTotal As Integer
        Dim condicion_documento As String
        Dim fecha_cotizacion As String
        Dim desc_cotizacion As String
        Dim nro_documento As String
        Dim subtotal_cotizacion As String
        Dim total_cotizacion As String
        Dim vendedor_cotizacion As String

        condicion_documento = txt_condiciones.Text
        fecha_cotizacion = Form_menu_principal.dtp_fecha.Text
        desc_cotizacion = txt_desc.Text
        nro_documento = txt_nro_boleta.Text
        total_cotizacion = Val(txt_total_sale.Text) - Val(txt_total_entra.Text)
        subtotal_cotizacion = Val(txt_total_sale.Text) - Val(txt_total_entra.Text)
        vendedor_cotizacion = minombre

        e.Graphics.DrawString("DETALLE DE BOLETA", Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)

        e.Graphics.DrawString("NUMERO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 245)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 245)
        e.Graphics.DrawString(nro_documento, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 245)

        e.Graphics.DrawString("FECHA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 260)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 260)
        e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 260)

        e.Graphics.DrawString("VENDEDOR", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 275)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 275)
        e.Graphics.DrawString(minombre, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 275)

        e.Graphics.DrawString("TELEFONO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 290)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 290)
        e.Graphics.DrawString(mitelefono, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 290)

        e.Graphics.DrawString("CONDICION", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 305)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 60, margen_superior + 305)
        e.Graphics.DrawString(condicion_documento, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 70, margen_superior + 305)

        e.Graphics.DrawString("CODIGO", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 335)
        e.Graphics.DrawString("DESCRIPCION", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 50, margen_superior + 335)
        e.Graphics.DrawString("CANT.", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 335)
        e.Graphics.DrawString("TOTAL", Font_texto_titulo_detalle, Brushes.Black, margen_izquierdo + 285, margen_superior + 335, format1)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + 350, margen_izquierdo + 295, margen_superior + 350)

        Dim descuento_detalle As String
        Dim precio_detalle As String
        Dim precio_total As String

        Dim multiplicador_lineas As Integer = 45
        Dim numero_lineas As Integer = 0

        For i = 0 To grilla_detalle_venta.Rows.Count - 1
            VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
            varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
            vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
            VarValorUnitario = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
            VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
            VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
            VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
            VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
            VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
            VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            VarTotal = grilla_detalle_venta.Rows(i).Cells(10).Value.ToString

            precio_detalle = grilla_detalle_venta.Rows(i).Cells(3).Value.ToString
            descuento_detalle = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
            descuento_detalle = Val(descuento_detalle) / VarCantidad

            precio_detalle = Val(precio_detalle - descuento_detalle)
            precio_total = VarTotal
            If descuento_detalle = "" Or descuento_detalle = "0" Then
                descuento_detalle = "0"
            Else
                descuento_detalle = Format(Int(descuento_detalle), "###,###,###")
            End If

            If precio_detalle = "" Or precio_detalle = "0" Then
                precio_detalle = "0"
            Else
                precio_detalle = Format(Int(precio_detalle), "###,###,###")
            End If

            If precio_total = "" Or precio_total = "0" Then
                precio_total = "0"
            Else
                precio_total = Format(Int(precio_total), "###,###,###")
            End If
            'If detalle_referencia.Length > 23 Then
            '    detalle_referencia = detalle_referencia.Substring(0, 23)
            'End If

            e.Graphics.DrawString(VarCodProducto, Font_texto_detalle, Brushes.Black, margen_izquierdo + 0, margen_superior + 355 + (i * multiplicador_lineas))
            e.Graphics.DrawString(varnombre, Font_texto_detalle, Brushes.Black, margen_izquierdo + 50, margen_superior + 355 + (i * multiplicador_lineas))
            e.Graphics.DrawString(vartecnico, Font_texto_detalle, Brushes.Black, margen_izquierdo + 50, margen_superior + 370 + (i * multiplicador_lineas))
            'e.Graphics.DrawString(precio_detalle, Font_texto_detalle, Brushes.Black, margen_izquierdo + 285, margen_superior + 405 + (i * multiplicador_lineas))
            e.Graphics.DrawString(precio_detalle & " X " & VarCantidad, Font_texto_detalle, Brushes.Black, margen_izquierdo + 150, margen_superior + 385 + (i * multiplicador_lineas))
            e.Graphics.DrawString(precio_total, Font_texto_detalle, Brushes.Black, margen_izquierdo + 285, margen_superior + 385 + (i * multiplicador_lineas), format1)
            e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + (i * multiplicador_lineas) + 398, margen_izquierdo + 295, margen_superior + (i * multiplicador_lineas) + 398)
        Next

        numero_lineas = ((grilla_detalle_venta.Rows.Count - 1) * multiplicador_lineas)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + numero_lineas + 398, margen_izquierdo + 295, margen_superior + numero_lineas + 398)

        e.Graphics.DrawString("SUBTOTAL", Font_texto_totales, Brushes.Black, margen_izquierdo + 125, margen_superior + numero_lineas + 420)
        e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 210, margen_superior + numero_lineas + 420)
        e.Graphics.DrawString(txt_sub_total_millar.Text, Font_texto_totales, Brushes.Black, margen_izquierdo + 285, margen_superior + numero_lineas + 420, format1)

        e.Graphics.DrawString("DESCUENTO", Font_texto_totales, Brushes.Black, margen_izquierdo + 125, margen_superior + numero_lineas + 435)
        e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 210, margen_superior + numero_lineas + 435)
        e.Graphics.DrawString(txt_desc_millar.Text, Font_texto_totales, Brushes.Black, margen_izquierdo + 285, margen_superior + numero_lineas + 435, format1)

        e.Graphics.DrawString("TOTAL", Font_texto_totales, Brushes.Black, margen_izquierdo + 125, margen_superior + numero_lineas + 450)
        e.Graphics.DrawString(":", Font_texto_totales, Brushes.Black, margen_izquierdo + 210, margen_superior + numero_lineas + 450)
        e.Graphics.DrawString(txt_total_millar.Text, Font_texto_totales, Brushes.Black, margen_izquierdo + 285, margen_superior + numero_lineas + 450, format1)

        Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + numero_lineas + 490, margen_izquierdo + 270, margen_superior + numero_lineas + 15)
        e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)
    End Sub
End Class