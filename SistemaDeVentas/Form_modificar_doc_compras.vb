Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_modificar_doc_compras
    Dim mifecha2 As String
    Private Sub Form_modificar_doc_compras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_Compra.Enabled = True
        Form_Compra.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_modificar_doc_compras_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_modificar_doc_compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()

        '   dtp_emision.CustomFormat = "yyy-MM-dd"
        fecha()

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from proveedores"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        If DS.Tables(DT.TableName).Rows.Count > 0 Then


            For i = 0 To DS.Tables(0).Rows.Count - 1
                col.Add(DS.Tables(0).Rows(i)("rut_proveedor").ToString())
            Next
            txt_rut_proveedor.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt_rut_proveedor.AutoCompleteCustomSource = col
            txt_rut_proveedor.AutoCompleteMode = AutoCompleteMode.Suggest
        End If




        txt_rut_proveedor.AutoCompleteSource = AutoCompleteSource.CustomSource
        txt_rut_proveedor.AutoCompleteCustomSource = col
        txt_rut_proveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        dtp_emision.CustomFormat = "yyy-MM-dd"
        dtp_emision_real.CustomFormat = "yyy-MM-dd"
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_emision.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")
    End Sub

    Sub desglose_factura()
        Dim iva As Long
        Dim neto As Long
        Dim total As Long
        total = 0
        If txt_total.Text = "" Then
            total = 0
        End If

        Try

            If txt_total.Text = "" Then
                total = 0
                neto = 0
                iva = 0
                txt_iva.Text = ""
                txt_neto.Text = ""

            End If

            total = txt_total.Text

            neto = (total / 1.19)
            iva = (neto) * 19 / 100

            txt_neto.Text = neto
            txt_iva.Text = iva

            If total = 0 Then
                txt_total.Text = ""
            End If


        Catch err As InvalidCastException

        End Try
    End Sub

    Private Sub txt_total_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_total.KeyPress
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

    Private Sub txt_total_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total.TextChanged
        Me.txt_total.Text = Trim(Replace(Me.txt_total.Text, " ", ""))
        desglose_factura()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar.Click
        If combo_documento.Text = "" Then
            MsgBox("CAMPO DOCUMENTO VACIO, FAVOR LLENAR" + Chr(13), MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_documento.Focus()
            Exit Sub
        End If

        If txt_nro_doc.Text = "" Then
            MsgBox("CAMPO NRO. DOCUMENTO VACIO, FAVOR LLENAR" + Chr(13), MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nro_doc.Focus()
            Exit Sub
        End If

        If txt_total.Text = "" Then
            MsgBox("CAMPO TOTAL VACIO, FAVOR LLENAR" + Chr(13), MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_total.Focus()
            Exit Sub
        End If

        If dtp_emision.Text = "" Then
            MsgBox("CAMPO FECHA VACIO, FAVOR LLENAR" + Chr(13), MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_total.Focus()
            Exit Sub
        End If

        If txt_rut_proveedor.Text = "" Then
            MsgBox("CAMPO RUT PROVEEDOR VACIO, FAVOR LLENAR" + Chr(13), MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_rut_proveedor.Focus()
            Exit Sub
        End If



        Dim cadena As String
        Dim tabla() As String
        Dim n As Integer
        Dim tipo_doc As String
        Dim tipo_emision As String

        tipo_doc = ""
        tipo_emision = ""

        cadena = combo_documento_real.Text

        If cadena = "" Then
            Exit Sub
        End If

        tabla = Split(cadena, " ")
        For n = 0 To UBound(tabla, 1)
            tipo_doc = tabla(0)
            tipo_emision = tabla(1)
        Next

        Dim valormensaje As Integer
        valormensaje = MsgBox("ESTA SEGURO DE MODIFICAR LA INFORMACION DEL DOCUMENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "MODIFICAR")

        If valormensaje = vbNo Then
            Exit Sub
        End If

        If valormensaje = vbYes Then
            fecha()

            If combo_documento.Text = "FACTURA ELECTRONICA" Then
                SC.Connection = conexion
                SC.CommandText = "UPDATE compra SET tipo='FACTURA', tipo_emision='ELECTRONICA', n_compra='" & (txt_nro_doc.Text) & "', total='" & (txt_total.Text) & "',neto = '" & (txt_neto.Text) & "',iva = '" & (txt_iva.Text) & "',fecha_emision = '" & (dtp_emision.Text) & "', rut_proveedor='" & (txt_rut_proveedor.Text) & "', usuario_responsable = '" & (miusuario) & "'  WHERE rut_proveedor= '" & (txt_rut_proveedor_real.Text) & "' and n_compra= '" & (txt_nro_doc_real.Text) & "' and tipo= '" & (tipo_doc) & "' and tipo_emision= '" & (tipo_emision) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If combo_documento.Text = "FACTURA MANUAL" Then
                SC.Connection = conexion
                SC.CommandText = "UPDATE compra SET tipo='FACTURA', tipo_emision='MANUAL', n_compra='" & (txt_nro_doc.Text) & "', total='" & (txt_total.Text) & "',neto = '" & (txt_neto.Text) & "',iva = '" & (txt_iva.Text) & "',fecha_emision = '" & (dtp_emision.Text) & "', rut_proveedor='" & (txt_rut_proveedor.Text) & "', usuario_responsable = '" & (miusuario) & "'  WHERE rut_proveedor= '" & (txt_rut_proveedor_real.Text) & "' and n_compra= '" & (txt_nro_doc_real.Text) & "' and tipo= '" & (tipo_doc) & "' and tipo_emision= '" & (tipo_emision) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If combo_documento.Text = "GUIA ELECTRONICA" Then
                SC.Connection = conexion
                SC.CommandText = "UPDATE compra SET tipo='GUIA', tipo_emision='ELECTRONICA', n_compra='" & (txt_nro_doc.Text) & "', total='" & (txt_total.Text) & "',neto = '" & (txt_neto.Text) & "',iva = '" & (txt_iva.Text) & "',fecha_emision = '" & (dtp_emision.Text) & "', rut_proveedor='" & (txt_rut_proveedor.Text) & "', usuario_responsable = '" & (miusuario) & "'  WHERE rut_proveedor= '" & (txt_rut_proveedor_real.Text) & "' and n_compra= '" & (txt_nro_doc_real.Text) & "' and tipo= '" & (tipo_doc) & "' and tipo_emision= '" & (tipo_emision) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If combo_documento.Text = "GUIA MANUAL" Then
                SC.Connection = conexion
                SC.CommandText = "UPDATE compra SET tipo='GUIA', tipo_emision='MANUAL', n_compra='" & (txt_nro_doc.Text) & "', total='" & (txt_total.Text) & "',neto = '" & (txt_neto.Text) & "',iva = '" & (txt_iva.Text) & "',fecha_emision = '" & (dtp_emision.Text) & "', rut_proveedor='" & (txt_rut_proveedor.Text) & "', usuario_responsable = '" & (miusuario) & "'  WHERE rut_proveedor= '" & (txt_rut_proveedor_real.Text) & "' and n_compra= '" & (txt_nro_doc_real.Text) & "' and tipo= '" & (tipo_doc) & "' and tipo_emision= '" & (tipo_emision) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
            'SC.Connection = conexion
            'SC.CommandText = "UPDATE compra SET tipo='FACTURA', tipo_emision='ELECTRONICA', n_compra='" & (txt_nro_doc.Text) & "', total='" & (txt_total.Text) & "',neto = '" & (txt_neto.Text) & "',iva = '" & (txt_iva.Text) & "',fecha_emision = '" & (dtp_emision.Text) & "', rut_proveedor='" & (txt_rut_proveedor.Text) & "', usuario_responsable = '" & (miusuario) & "'  WHERE codigo_compra = '" & (Form_Compra.txt_codigo_compra.Text) & "'"
            'DA.SelectCommand = SC
            'DA.Fill(DT)

            If combo_documento.Text = "FACTURA ELECTRONICA" Then
                SC.Connection = conexion
                SC.CommandText = "UPDATE detalle_compra SET  tipo='FACTURA', tipo_emision='ELECTRONICA', n_compra='" & (txt_nro_doc.Text) & "', rut_proveedor='" & (txt_rut_proveedor.Text) & "' WHERE n_compra = '" & (txt_nro_doc_real.Text) & "' and rut_proveedor='" & (txt_rut_proveedor_real.Text) & "' and tipo= '" & (tipo_doc) & "' and tipo_emision= '" & (tipo_emision) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If combo_documento.Text = "FACTURA MANUAL" Then
                SC.Connection = conexion
                SC.CommandText = "UPDATE detalle_compra SET  tipo='FACTURA', tipo_emision='MANUAL', n_compra='" & (txt_nro_doc.Text) & "', rut_proveedor='" & (txt_rut_proveedor.Text) & "' WHERE n_compra = '" & (txt_nro_doc_real.Text) & "' and rut_proveedor='" & (txt_rut_proveedor_real.Text) & "' and tipo= '" & (tipo_doc) & "' and tipo_emision= '" & (tipo_emision) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If combo_documento.Text = "GUIA ELECTRONICA" Then
                SC.Connection = conexion
                SC.CommandText = "UPDATE detalle_compra SET  tipo='GUIA', tipo_emision='ELECTRONICA', n_compra='" & (txt_nro_doc.Text) & "', rut_proveedor='" & (txt_rut_proveedor.Text) & "' WHERE n_compra = '" & (txt_nro_doc_real.Text) & "' and rut_proveedor='" & (txt_rut_proveedor_real.Text) & "' and tipo= '" & (tipo_doc) & "' and tipo_emision= '" & (tipo_emision) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If combo_documento.Text = "GUIA MANUAL" Then
                SC.Connection = conexion
                SC.CommandText = "UPDATE detalle_compra SET  tipo='GUIA', tipo_emision='MANUAL', n_compra='" & (txt_nro_doc.Text) & "', rut_proveedor='" & (txt_rut_proveedor.Text) & "' WHERE n_compra = '" & (txt_nro_doc_real.Text) & "' and rut_proveedor='" & (txt_rut_proveedor_real.Text) & "' and tipo= '" & (tipo_doc) & "' and tipo_emision= '" & (tipo_emision) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            'SC.Connection = conexion
            'SC.CommandText = "UPDATE detalle_compra SET n_compra='" & (txt_nro_doc.Text) & "', rut_proveedor='" & (txt_rut_proveedor.Text) & "' WHERE n_compra = '" & (Form_Compra.txt_nro_doc.Text) & "' and rut_proveedor='" & (Form_Compra.txt_rut_proveedor.Text) & "'"
            'DA.SelectCommand = SC
            'DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "UPDATE detalle_total SET n_total='" & (txt_nro_doc.Text) & "', rut_proveedor='" & (txt_rut_proveedor.Text) & "' WHERE n_total = '" & (Form_Compra.txt_nro_doc.Text) & "' and rut_proveedor='" & (Form_Compra.txt_rut_proveedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)



            Dim valormensaje2 As Integer
            valormensaje2 = MsgBox("DESEA MODIFICAR LA ULTIMA COMPRA DE LOS PRODUCTOS?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "MODIFICAR")

            'If valormensaje2 = vbNo Then
            '    Exit Sub
            'End If

            If valormensaje2 = vbYes Then


                Dim VarCodProducto As String
                Dim varnombre As String
                Dim VarCantidad As Integer
                Dim VarPrecioUnitario As String
                Dim VarCosto As String
                Dim VarDescuento As String
                Dim VarDescuento2 As String
                Dim VarDescuento3 As String
                ' Dim VarDescuento4 As String
                Dim VarNeto As String
                Dim VarIva As String
                Dim VarTotal As String
                Dim varFactor As String
                Dim VarPrecioVenta As String


                For i = 0 To Form_Compra.grilla_detalle.Rows.Count - 1

                    VarCodProducto = Form_Compra.grilla_detalle.Rows(i).Cells(0).Value.ToString
                    varnombre = Form_Compra.grilla_detalle.Rows(i).Cells(1).Value.ToString
                    VarCantidad = Form_Compra.grilla_detalle.Rows(i).Cells(2).Value.ToString
                    VarPrecioUnitario = Form_Compra.grilla_detalle.Rows(i).Cells(3).Value.ToString
                    VarCosto = Form_Compra.grilla_detalle.Rows(i).Cells(4).Value.ToString
                    VarDescuento = Form_Compra.grilla_detalle.Rows(i).Cells(5).Value.ToString
                    VarDescuento2 = Form_Compra.grilla_detalle.Rows(i).Cells(6).Value.ToString
                    VarDescuento3 = Form_Compra.grilla_detalle.Rows(i).Cells(7).Value.ToString
                    ' VarDescuento4 = grilla_detalle.Rows(i).Cells(8).Value.ToString
                    VarNeto = Form_Compra.grilla_detalle.Rows(i).Cells(8).Value.ToString
                    VarIva = Form_Compra.grilla_detalle.Rows(i).Cells(9).Value.ToString
                    VarTotal = Form_Compra.grilla_detalle.Rows(i).Cells(10).Value.ToString
                    varFactor = Form_Compra.grilla_detalle.Rows(i).Cells(11).Value.ToString
                    VarPrecioVenta = Form_Compra.grilla_detalle.Rows(i).Cells(12).Value.ToString

                    SC.Connection = conexion
                    SC.CommandText = "UPDATE productos SET cantidad_ultima_compra='" & (VarCantidad) & "', proveedor = '" & (txt_rut_proveedor.Text) & "', ultima_compra = '" & (mifecha2) & "', tipo_doc = '" & (combo_documento.Text) & "', nro_doc = '" & (txt_nro_doc.Text) & "', fecha_modificacion = '" & (Form_menu_principal.dtp_fecha.Text) & "' WHERE cod_producto = " & (VarCodProducto) & ""
                    DA.SelectCommand = SC
                    DA.Fill(DT)

                Next
            End If
























            MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

            Form_Compra.combo_documento.Text = combo_documento.Text
            Form_Compra.dtp_emision.Text = dtp_emision.Text
            Form_Compra.txt_rut_proveedor.Text = txt_rut_proveedor.Text
            Form_Compra.txt_nro_doc.Text = txt_nro_doc.Text
            Form_Compra.txt_total.Text = Form_Compra.txt_total.Text

            Me.Close()

        End If
    End Sub

    Private Sub combo_documento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combo_documento.KeyPress
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

    Private Sub combo_documento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_documento.SelectedIndexChanged

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


    End Sub

    Private Sub txt_nro_doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_doc.TextChanged

    End Sub

    Private Sub txt_rut_proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_proveedor.KeyPress
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

    Private Sub txt_rut_proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_proveedor.TextChanged

    End Sub

    Private Sub btn_grabar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.LostFocus

    End Sub

End Class