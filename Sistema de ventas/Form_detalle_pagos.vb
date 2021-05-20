Imports System.IO
Public Class Form_detalle_pagos
    Dim mifecha2 As String

    Private Sub Form_detalle_pagos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_detalle_pagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fecha()
        cargar_detalle()
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub
    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click

        If Combo_documento.Text = "" Then
            MsgBox("CAMPO TIPO DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_documento.Focus()
            Exit Sub
        End If

        If combo_condiciones.Text = "" Then
            MsgBox("CAMPO CONDICION VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_condiciones.Focus()
            Exit Sub
        End If

        If txt_nro_doc.Text = "" Then
            MsgBox("CAMPO NRO. DOC. VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nro_doc.Focus()
            Exit Sub
        End If

        If txt_nro_doc.Text = "0" Then
            MsgBox("CAMPO NRO. DOC. VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nro_doc.Focus()
            Exit Sub
        End If

        If txt_valor_doc.Text = "0" Then
            MsgBox("CAMPO VALOR DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_valor_doc.Focus()
            Exit Sub
        End If

        If txt_valor_doc.Text = "" Then
            MsgBox("CAMPO VALOR DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_valor_doc.Focus()
            Exit Sub
        End If


        SC.Connection = conexion
        SC.CommandText = "insert into detalle_condicion_de_pago (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha, caja) values ('" & (txt_nro_doc.Text) & "' , '" & (Combo_documento.Text) & "', '" & (txt_valor_doc.Text) & "','" & (combo_condiciones.Text) & "', 'EMITIDA', '" & (mifecha2) & "', '" & (nombre_pc) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)



        For i = 0 To grilla_detalle.Rows.Count - 1
            Dim tipo_documento As String
            Dim numero_documento As String
            Dim condicion_documento As String

            tipo_documento = grilla_detalle.Rows(i).Cells(1).Value.ToString
            numero_documento = grilla_detalle.Rows(i).Cells(0).Value.ToString
            condicion_documento = grilla_detalle.Rows(i).Cells(3).Value.ToString

            If tipo_documento = Combo_documento.Text And numero_documento = txt_nro_doc.Text And condicion_documento = combo_condiciones.Text Then

                SC.Connection = conexion
                SC.CommandText = "delete from detalle_condicion_de_pago where nro_doc = '" & (numero_documento) & "' and tipo_doc= '" & (tipo_documento) & "' and condicion_de_pago= '" & (condicion_documento) & "' and fecha= '" & (mifecha2) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                grilla_detalle.Rows.Remove(grilla_detalle.CurrentRow)
                grilla_detalle.Rows.Add(txt_nro_doc.Text, Combo_documento.Text, txt_valor_doc.Text, combo_condiciones.Text, "EMITIDA", mifecha2)

                SC.Connection = conexion
                SC.CommandText = "insert into detalle_condicion_de_pago (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha, caja) values ('" & (txt_nro_doc.Text) & "' , '" & (Combo_documento.Text) & "', '" & (txt_valor_doc.Text) & "','" & (combo_condiciones.Text) & "', 'EMITIDA', '" & (mifecha2) & "', '" & (nombre_pc) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                calcular_totales()

                txt_nro_doc.Text = ""
                txt_valor_doc.Text = ""
                combo_condiciones.SelectedItem = "-"

                dtp_emision.Focus()
                Exit Sub
            End If
        Next

        grilla_detalle.Rows.Add(txt_nro_doc.Text, Combo_documento.Text, txt_valor_doc.Text, combo_condiciones.Text, "EMITIDA", mifecha2)

        SC.Connection = conexion
        SC.CommandText = "insert into detalle_condicion_de_pago (nro_doc, tipo_doc, valor, condicion_de_pago, estado, fecha, caja) values ('" & (txt_nro_doc.Text) & "' , '" & (Combo_documento.Text) & "', '" & (txt_valor_doc.Text) & "','" & (combo_condiciones.Text) & "', 'EMITIDA', '" & (mifecha2) & "', '" & (nombre_pc) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        calcular_totales()

        txt_nro_doc.Text = ""
        txt_valor_doc.Text = ""
        combo_condiciones.SelectedItem = "-"

        dtp_emision.Focus()
    End Sub





    Sub calcular_totales()
        '//Calcular el total general

        Dim total As String

        txt_total_final.Text = 0

        For i = 0 To grilla_detalle.Rows.Count - 1

            total = Val(grilla_detalle.Rows(i).Cells(3).Value.ToString)
            txt_total_final.Text = Val(txt_total_final.Text) + Val(total)
        Next



        If txt_total_final.Text = "" Or txt_total_final.Text = "0" Then
            txt_total_millar.Text = "0"
        Else
            txt_total_millar.Text = Format(Int(txt_total_final.Text), "###,###,###")
        End If


    End Sub

    Private Sub txt_nro_doc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nro_doc.KeyPress
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
    End Sub

    Private Sub txt_nro_doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_doc.TextChanged

    End Sub

    Private Sub txt_valor_doc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_valor_doc.KeyPress
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
    End Sub

    Private Sub txt_valor_doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_valor_doc.TextChanged

    End Sub

    Private Sub Combo_documento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_documento.GotFocus
        Combo_documento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_documento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_documento.LostFocus
        Combo_documento.BackColor = Color.White
    End Sub


    Private Sub combo_condiciones_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_condiciones.GotFocus
        combo_condiciones.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_condiciones_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_condiciones.LostFocus
        combo_condiciones.BackColor = Color.White
    End Sub


    Private Sub txt_nro_doc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc.GotFocus
        txt_nro_doc.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nro_doc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc.LostFocus
        txt_nro_doc.BackColor = Color.White
    End Sub


    Private Sub txt_valor_doc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_valor_doc.GotFocus
        txt_valor_doc.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_valor_doc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_valor_doc.LostFocus
        txt_valor_doc.BackColor = Color.White
    End Sub

    Private Sub btn_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.GotFocus
        btn_agregar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.LostFocus
        btn_agregar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_quitar_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.GotFocus
        btn_quitar_elemento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_elemento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.LostFocus
        btn_quitar_elemento.BackColor = Color.Transparent
    End Sub


    Sub cargar_detalle()

        grilla_detalle.Rows.Clear()

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from detalle_condicion_de_pago where fecha='" & (mifecha2) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1


                Dim fecha_doc As String


                Dim mifecha As Date
                mifecha = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                fecha_doc = mifecha.ToString("yyy-MM-dd")









                grilla_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("nro_doc"), _
                                         DS.Tables(DT.TableName).Rows(i).Item("tipo_doc"), _
                                          DS.Tables(DT.TableName).Rows(i).Item("valor"), _
                                           DS.Tables(DT.TableName).Rows(i).Item("condicion_de_pago"), _
                                            DS.Tables(DT.TableName).Rows(i).Item("estado"), _
                                             fecha_doc)
            Next
        End If
    End Sub

    Private Sub dtp_vencimiento_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_emision.ValueChanged
        fecha()
        cargar_detalle()
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_emision.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")
    End Sub

    Private Sub btn_quitar_elemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        Dim tipo_documento As String
        Dim numero_documento As String
        Dim condicion_documento As String

        tipo_documento = grilla_detalle.CurrentRow.Cells(1).Value
        numero_documento = grilla_detalle.CurrentRow.Cells(0).Value
        condicion_documento = grilla_detalle.CurrentRow.Cells(3).Value

        SC.Connection = conexion
        SC.CommandText = "delete from detalle_condicion_de_pago where nro_doc = '" & (numero_documento) & "' and tipo_doc= '" & (tipo_documento) & "' and condicion_de_pago= '" & (condicion_documento) & "' and fecha= '" & (mifecha2) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        cargar_detalle()
    End Sub
End Class