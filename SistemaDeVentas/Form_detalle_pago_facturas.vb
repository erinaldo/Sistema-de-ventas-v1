Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_detalle_pago_facturas
    Dim mifecha6 As String
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub Form_detalle_pago_facturas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_registro_de_facturas.Enabled = True
    End Sub

    Private Sub Form_detalle_pago_facturas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_detalle_pago_facturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        Combo_forma_de_pago.SelectedItem = "CHEQUE"
        txt_detalle_de_pago.Focus()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        'Dim estado1 As String
        Dim valormensaje As Integer
        'Dim Varnumero As Integer
        'Dim rut_proveedor1 As String

        Dim documento As String
        Dim tipo As String
        Dim numero As String
        Dim total As String
        Dim vencimiento As String
        Dim proveedor As String
        Dim estado As String
        Dim rut_proveedor As String
        Dim codigo_folio As String
        Dim fecha_factura As String



        If Radio_pagada.Checked = True Then
            If Combo_forma_de_pago.Text = "" Then
                Combo_forma_de_pago.Focus()
                MsgBox("CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR" + Chr(13), MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            If txt_detalle_de_pago.Text = "" Then
                txt_detalle_de_pago.Focus()
                MsgBox("CAMPO DETALLE PAGO VACIO VACIO, FAVOR LLENAR" + Chr(13), MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If

            valormensaje = MsgBox("¿ESTA SEGURO DE CAMBIAR A PAGADA EL ESTADO DE LAS FACTURAS?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "MODIFICAR")
            fecha3()
            If valormensaje = vbYes Then

                Me.Enabled = False

                For i = 0 To Form_registro_de_facturas.grilla_facturas.Rows.Count - 1


                    documento = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(0).Value.ToString
                    tipo = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(1).Value.ToString
                    estado = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(2).Value.ToString
                    proveedor = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(3).Value.ToString
                    total = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(4).Value.ToString
                    vencimiento = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(5).Value.ToString
                    numero = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(6).Value.ToString
                    rut_proveedor = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(7).Value.ToString
                    codigo_folio = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(8).Value.ToString
                    fecha_factura = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(9).Value.ToString











                    If Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(10).Value = True Then

                        SC.Connection = conexion
                        SC.CommandText = "update libro_de_compras set estado= 'PAGADA', fecha_de_pago= '" & (mifecha6) & "', forma_de_pago= '" & (Combo_forma_de_pago.Text) & "' , detalle_de_pago= '" & (txt_detalle_de_pago.Text) & "' where documento='" & (documento) & "' and  tipo_documento='" & (tipo) & "' and nro_factura='" & (numero) & "' and rut_proveedor= '" & (rut_proveedor) & "' "
                        DA.SelectCommand = SC
                        DA.Fill(DT)

                    End If
                Next

                'If Form_registro_de_facturas.txt_nro_factura.Text <> "" And Form_registro_de_facturas.txt_rut_proveedor.Text <> "" Then
                '    Form_registro_de_facturas.mostrar()
                '    Form_registro_de_facturas.calcular_totales()
                '    Me.Close()
                'End If

                'If Form_registro_de_facturas.txt_rut_proveedor.Text <> "" Then
                '    Form_registro_de_facturas.mostrar()
                '    Form_registro_de_facturas.calcular_totales()
                '    Me.Close()
                'End If

                'If Form_registro_de_facturas.txt_nro_factura.Text <> "" Then
                '    Form_registro_de_facturas.mostrar_factura()
                '    Form_registro_de_facturas.calcular_totales()
                '    Me.Close()
                ' End If
                'End If






                Form_registro_de_facturas.grilla_facturas.Rows.Clear()
                conexion.Close()
                DS.Tables.Clear()
                DT.Columns.Clear()
                DT.Rows.Clear()
                DS.Clear()
                conexion.Open()
                SC.Connection = conexion
                SC.CommandText = "select documento, tipo_documento,  nro_factura, total, fecha_vencimiento, proveedores.nombre_proveedor as proveedor, LIBRO_DE_COMPRAS.RUT_PROVEEDOR,estado, codigo_folio, PERIODO_TRIBUTARIO from LIBRO_DE_compraS, proveedores where forma_de_pago ='" & (Combo_forma_de_pago.Text) & "' and detalle_de_pago ='" & (txt_detalle_de_pago.Text) & "' and LIBRO_DE_compraS.rut_PROVEEDOR=proveedores.rut_PROVEEDOR group by NRO_FACTURA"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)


                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    documento = DS.Tables(DT.TableName).Rows(i).Item("documento")
                    tipo = DS.Tables(DT.TableName).Rows(i).Item("tipo_documento")
                    numero = DS.Tables(DT.TableName).Rows(i).Item("nro_factura")
                    total = DS.Tables(DT.TableName).Rows(i).Item("total")
                    vencimiento = DS.Tables(DT.TableName).Rows(i).Item("fecha_vencimiento")
                    proveedor = DS.Tables(DT.TableName).Rows(i).Item("proveedor")
                    rut_proveedor = DS.Tables(DT.TableName).Rows(i).Item("rut_proveedor")
                    estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
                    codigo_folio = DS.Tables(DT.TableName).Rows(i).Item("codigo_folio")
                    fecha_factura = DS.Tables(DT.TableName).Rows(i).Item("periodo_tributario")

                    Form_registro_de_facturas.grilla_facturas.Rows.Add(documento, tipo, estado, proveedor, total, vencimiento, numero, rut_proveedor, codigo_folio, fecha_factura)

                Next
                conexion.Close()

                Dim estado_revision As String
                'estado_revision = grilla1.CurrentRow.Cells(9).Value
                For i = 0 To Form_registro_de_facturas.grilla_facturas.Rows.Count - 1
                    estado_revision = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(2).Value.ToString
                    If estado_revision = "PAGADA" Then
                        Form_registro_de_facturas.grilla_facturas.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                    End If
                Next
                Form_registro_de_facturas.calcular_totales()

                Form_registro_de_facturas.txt_forma_de_pago.Text = Combo_forma_de_pago.Text
                Form_registro_de_facturas.txt_detalle_de_pago.Text = txt_detalle_de_pago.Text

                Me.Close()

            End If
        End If










        If Radio_impaga.Checked = True Then
            valormensaje = MsgBox("¿ESTA SEGURO DE CAMBIAR A  IMPAGA EL ESTADO DE LAS FACTURAS?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "MODIFICAR")
            fecha3()
            If valormensaje = vbYes Then

                Me.Enabled = False

                For i = 0 To Form_registro_de_facturas.grilla_facturas.Rows.Count - 1

                    documento = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(0).Value.ToString
                    tipo = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(1).Value.ToString
                    estado = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(2).Value.ToString
                    proveedor = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(3).Value.ToString
                    total = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(4).Value.ToString
                    vencimiento = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(5).Value.ToString
                    numero = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(6).Value.ToString
                    rut_proveedor = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(7).Value.ToString
                    codigo_folio = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(8).Value.ToString
                    fecha_factura = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(9).Value.ToString

                    If Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(10).Value = True Then

                        documento = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(0).Value.ToString
                        tipo = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(1).Value.ToString
                        estado = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(2).Value.ToString
                        proveedor = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(3).Value.ToString
                        total = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(4).Value.ToString
                        vencimiento = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(5).Value.ToString
                        numero = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(6).Value.ToString
                        rut_proveedor = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(7).Value.ToString
                        codigo_folio = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(8).Value.ToString
                        fecha_factura = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(9).Value.ToString

                        SC.Connection = conexion
                        SC.CommandText = "update libro_de_compras set estado= 'IMPAGA', fecha_de_pago= '0000-00-000', forma_de_pago= '-' , detalle_de_pago= '-' where  documento='" & (documento) & "' and  tipo_documento='" & (tipo) & "' and nro_factura='" & (numero) & "' and  rut_proveedor= '" & (rut_proveedor) & "' "
                        DA.SelectCommand = SC
                        DA.Fill(DT)

                    End If
                Next

                If Form_registro_de_facturas.txt_nro_factura.Text <> "" And Form_registro_de_facturas.txt_rut_proveedor.Text <> "" Then

                    Form_registro_de_facturas.mostrar_malla()
                    Form_registro_de_facturas.calcular_totales()

                    Form_registro_de_facturas.txt_forma_de_pago.Text = Combo_forma_de_pago.Text
                    Form_registro_de_facturas.txt_detalle_de_pago.Text = txt_detalle_de_pago.Text

                    Me.Close()

                End If

                If Form_registro_de_facturas.txt_rut_proveedor.Text <> "" Then

                    Form_registro_de_facturas.mostrar_malla()
                    Form_registro_de_facturas.calcular_totales()

                    Form_registro_de_facturas.txt_forma_de_pago.Text = Combo_forma_de_pago.Text
                    Form_registro_de_facturas.txt_detalle_de_pago.Text = txt_detalle_de_pago.Text

                    Me.Close()

                End If

                If Form_registro_de_facturas.txt_nro_factura.Text <> "" Then

                    Form_registro_de_facturas.mostrar_malla()
                    Form_registro_de_facturas.calcular_totales()

                    Form_registro_de_facturas.txt_forma_de_pago.Text = Combo_forma_de_pago.Text
                    Form_registro_de_facturas.txt_detalle_de_pago.Text = txt_detalle_de_pago.Text

                    Me.Close()

                End If
            End If
        End If
    End Sub

    'se declara la variable mifecha.
    'se le entrega el valor de la variable al label.
    'a la variable mi fecha2 se le entrega el formato de fecha indicado.

    Sub fecha3()
        Dim mifecha2 As Date
        mifecha2 = dtp_fecha.Text
        mifecha6 = mifecha2.ToString("yyy-MM-dd")
    End Sub

    Private Sub Radio_impaga_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_impaga.CheckedChanged
        If Radio_impaga.Checked = True Then
            dtp_fecha.Enabled = False
            txt_detalle_de_pago.Enabled = False
            Combo_forma_de_pago.Enabled = False
        End If
    End Sub

    Private Sub Radio_pagada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_pagada.CheckedChanged
        If Radio_pagada.Checked = True Then
            dtp_fecha.Enabled = True
            txt_detalle_de_pago.Enabled = True
            Combo_forma_de_pago.Enabled = True
        End If
    End Sub

    Private Sub Radio_pago_parcial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Radio_pago_parcial.Checked = True Then
        '    dtp_fecha.Enabled = True
        '    txt_detalle_de_pago.Enabled = True
        '    Combo_forma_de_pago.Enabled = True
        'End If
    End Sub

    Private Sub txt_detalle_de_pago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_detalle_de_pago.KeyPress
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

    Private Sub txt_detalle_de_pago_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_detalle_de_pago.TextChanged

    End Sub

    Private Sub Combo_forma_de_pago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_forma_de_pago.KeyPress
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

End Class