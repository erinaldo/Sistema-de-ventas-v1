Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_info_factura_pagada

    Private Sub Form_info_factura_pagada_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_registro_de_facturas.Enabled = True
    End Sub

    Private Sub Form_info_factura_pagada_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_info_factura_pagada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Enabled = False

        Form_registro_de_facturas.grilla_facturas.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Columns.Clear()
        DT.Rows.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select documento, tipo_documento, nro_factura, total, fecha_factura, proveedores.nombre_proveedor as proveedor, libro_de_compras.rut_proveedor, estado, codigo_folio, periodo_tributario from libro_de_compras, proveedores where  forma_de_pago ='" & (txt_forma_de_pago.Text) & "' and detalle_de_pago ='" & (txt_detalle_de_pago.Text) & "' and libro_de_compras.rut_proveedor=proveedores.rut_proveedor group by nro_factura"
        'SC.CommandText = "select documento, tipo_documento, nro_factura, total, fecha_factura, proveedores.nombre_proveedor as proveedor, libro_de_compras.rut_proveedor, estado, codigo_folio, periodo_tributario from libro_de_compras, proveedores where forma_de_pago ='" & (Combo_forma_de_pago.Text) & "' and detalle_de_pago ='" & (txt_detalle_de_pago.Text) & "' and libro_de_compras.rut_proveedor=proveedores.rut_proveedor group by nro_factura"





        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
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

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                documento = DS.Tables(DT.TableName).Rows(i).Item("documento")
                tipo = DS.Tables(DT.TableName).Rows(i).Item("tipo_documento")
                numero = DS.Tables(DT.TableName).Rows(i).Item("nro_factura")
                total = DS.Tables(DT.TableName).Rows(i).Item("total")
                vencimiento = DS.Tables(DT.TableName).Rows(i).Item("fecha_factura")
                proveedor = DS.Tables(DT.TableName).Rows(i).Item("proveedor")
                rut_proveedor = DS.Tables(DT.TableName).Rows(i).Item("rut_proveedor")
                estado = DS.Tables(DT.TableName).Rows(i).Item("estado")
                codigo_folio = DS.Tables(DT.TableName).Rows(i).Item("codigo_folio")
                fecha_factura = DS.Tables(DT.TableName).Rows(i).Item("periodo_tributario")

                Form_registro_de_facturas.grilla_facturas.Rows.Add(documento, tipo, estado, proveedor, total, vencimiento, numero, rut_proveedor, codigo_folio, fecha_factura)
            Next
        End If
        Form_registro_de_facturas.calcular_totales()
        conexion.Close()
        Dim estado_revision As String
        'estado_revision = grilla1.CurrentRow.Cells(9).Value
        For i = 0 To Form_registro_de_facturas.grilla_facturas.Rows.Count - 1
            estado_revision = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(2).Value.ToString
            If estado_revision = "PAGADA" Then
                Form_registro_de_facturas.grilla_facturas.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If
        Next

        Form_registro_de_facturas.txt_forma_de_pago.Text = Me.txt_forma_de_pago.Text
        Form_registro_de_facturas.txt_detalle_de_pago.Text = Me.txt_detalle_de_pago.Text


        If Form_registro_de_facturas.grilla_facturas.Rows.Count <> 0 Then
            If Form_registro_de_facturas.grilla_facturas.Columns(0).Width = 120 Then
                Form_registro_de_facturas.grilla_facturas.Columns(0).Width = 119
            Else
                Form_registro_de_facturas.grilla_facturas.Columns(0).Width = 120
            End If
        End If

        Me.Close()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub


End Class