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
            form_Ingreso.Show()
            Form_menu_principal.Close()
        End If
    End Sub

    Private Sub Form_info_factura_pagada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
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
        SC.CommandText = "select documento, nro_factura, total, fecha_vencimiento, proveedores.nombre_proveedor as proveedor, LIBRO_DE_COMPRAS.RUT_PROVEEDOR,estado ,codigo_folio, PERIODO_TRIBUTARIO from LIBRO_DE_compraS, proveedores where  forma_de_pago ='" & (txt_forma_de_pago.Text) & "' and detalle_de_pago ='" & (txt_detalle_de_pago.Text) & "' and LIBRO_DE_compraS.rut_PROVEEDOR=proveedores.rut_PROVEEDOR group by NRO_FACTURA"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            Dim TIPO As String
            Dim numero As String
            Dim total As String
            Dim vencimiento As String
            Dim proveedor As String
            Dim estado As String
            Dim rut_proveedor As String
            Dim codigo_folio As String
            Dim fecha_factura As String

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                TIPO = DS.Tables(DT.TableName).Rows(i).Item("DOCUMENTO")
                numero = DS.Tables(DT.TableName).Rows(i).Item("nRO_FACTURA")
                total = DS.Tables(DT.TableName).Rows(i).Item("total")
                vencimiento = DS.Tables(DT.TableName).Rows(i).Item("fecha_vencimiento")
                proveedor = DS.Tables(DT.TableName).Rows(i).Item("proveedor")
                rut_proveedor = DS.Tables(DT.TableName).Rows(i).Item("RUT_PROVEEDOR")
                estado = DS.Tables(DT.TableName).Rows(i).Item("ESTADO")
                codigo_folio = DS.Tables(DT.TableName).Rows(i).Item("codigo_folio")
                fecha_factura = DS.Tables(DT.TableName).Rows(i).Item("PERIODO_TRIBUTARIO")
                Form_registro_de_facturas.grilla_facturas.Rows.Add(TIPO, estado, proveedor, total, vencimiento, numero, rut_proveedor, codigo_folio, fecha_factura)
            Next
        End If
        Form_registro_de_facturas.calcular_totales()
        conexion.Close()
        Dim estado_revision As String
        'estado_revision = grilla1.CurrentRow.Cells(9).Value
        For i = 0 To Form_registro_de_facturas.grilla_facturas.Rows.Count - 1
            estado_revision = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(1).Value.ToString
            If estado_revision = "PAGADA" Then
                Form_registro_de_facturas.grilla_facturas.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If
        Next

        Form_registro_de_facturas.txt_forma_de_pago.Text = Me.txt_forma_de_pago.Text
        Form_registro_de_facturas.txt_detalle_de_pago.Text = Me.txt_detalle_de_pago.Text


        Me.Close()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub


End Class