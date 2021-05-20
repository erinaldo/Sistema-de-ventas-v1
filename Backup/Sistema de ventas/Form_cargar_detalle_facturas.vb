Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_cargar_detalle_facturas

    Private Sub Form_cargar_detalle_facturas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_registro_de_facturas.Enabled = True
    End Sub

    Private Sub Form_cargar_detalle_facturas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_cargar_detalle_facturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        Dim mensaje As String = ""



        If Combo_forma_de_pago.Text = "" Then
            mensaje = "CAMPO FORMA DE PAGO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
            Combo_forma_de_pago.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_detalle_de_pago.Text = "" Then
            mensaje = "CAMPO DETALLE PAGO VACIO VACIO, FAVOR LLENAR" + Chr(13) & mensaje
            txt_detalle_de_pago.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        Me.Enabled = False

        Form_registro_de_facturas.grilla_facturas.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Columns.Clear()
        DT.Rows.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion

        SC.CommandText = "select documento, nro_factura, total, fecha_vencimiento, proveedores.nombre_proveedor as proveedor, LIBRO_DE_COMPRAS.RUT_PROVEEDOR,estado, codigo_folio, PERIODO_TRIBUTARIO from LIBRO_DE_compraS, proveedores where forma_de_pago ='" & (Combo_forma_de_pago.Text) & "' and detalle_de_pago ='" & (txt_detalle_de_pago.Text) & "' and LIBRO_DE_compraS.rut_PROVEEDOR=proveedores.rut_PROVEEDOR group by NRO_FACTURA"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

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
            fecha_factura = DS.Tables(DT.TableName).Rows(i).Item("periodo_tributario")
            Form_registro_de_facturas.grilla_facturas.Rows.Add(TIPO, estado, proveedor, total, vencimiento, numero, rut_proveedor, codigo_folio, fecha_factura)
        Next
        conexion.Close()

        Dim estado_revision As String
        'estado_revision = grilla1.CurrentRow.Cells(9).Value
        For i = 0 To Form_registro_de_facturas.grilla_facturas.Rows.Count - 1
            estado_revision = Form_registro_de_facturas.grilla_facturas.Rows(i).Cells(1).Value.ToString
            If estado_revision = "PAGADA" Then
                Form_registro_de_facturas.grilla_facturas.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If
        Next
        Form_registro_de_facturas.calcular_totales()

        Form_registro_de_facturas.txt_forma_de_pago.Text = Combo_forma_de_pago.Text
        Form_registro_de_facturas.txt_detalle_de_pago.Text = txt_detalle_de_pago.Text

        Me.Close()


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

    Private Sub Combo_forma_de_pago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_forma_de_pago.GotFocus
        Combo_forma_de_pago.BackColor = Color.LightSkyBlue
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

    Private Sub Combo_forma_de_pago_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_forma_de_pago.LostFocus
        Combo_forma_de_pago.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub Combo_forma_de_pago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_forma_de_pago.SelectedIndexChanged

    End Sub

    Private Sub txt_detalle_de_pago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_detalle_de_pago.GotFocus
        txt_detalle_de_pago.BackColor = Color.LightSkyBlue
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

    Private Sub txt_detalle_de_pago_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_detalle_de_pago.LostFocus
        txt_detalle_de_pago.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub txt_detalle_de_pago_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_detalle_de_pago.TextChanged

    End Sub


End Class