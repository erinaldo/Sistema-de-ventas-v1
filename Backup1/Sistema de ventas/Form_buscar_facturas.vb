Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Public Class Form_buscar_facturas

    Private Sub Form_buscar_facturas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_buscar_facturas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_buscar_facturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    'Private Sub txt_rut_proveedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_rut_proveedor.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub txt_rut_proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
    '        mostrar_datos_proveedores()
    '        txt_nro_doc.Focus()
    '    End If
    'End Sub
    'Sub mostrar_datos_proveedores()
    '    If txt_rut_proveedor.Text <> "" Then
    '        DS.Tables.Clear()
    '        DT.Rows.Clear()
    '        DT.Columns.Clear()
    '        DS.Clear()
    '        conexion.Open()

    '        SC.Connection = conexion
    '        SC.CommandText = "select * from proveedores where rut_proveedor ='" & (txt_rut_proveedor.Text) & "'"
    '        DA.SelectCommand = SC
    '        DA.Fill(DT)
    '        DS.Tables.Add(DT)

    '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '            lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_proveedor")
    '            txt_nombre_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_proveedor")
    '        End If
    '        conexion.Close()
    '    End If
    'End Sub

    'Private Sub txt_rut_proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_rut_proveedor.BackColor = Color.White
    'End Sub

    Private Sub txt_rut_proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Sub mostrar_datos_factura()
    '    Dim folio As String
    '    Dim fecha As String
    '    Dim mifecha As Date
    '    Dim mifecha2 As String

    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select codigo_folio,PERIODO_TRIBUTARIO  from libro_de_compras where rut_proveedor= '" & (txt_rut_proveedor.Text) & "' and nro_factura= '" & (txt_nro_doc.Text) & "'"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        folio = DS.Tables(DT.TableName).Rows(0).Item("codigo_folio")
    '        fecha = DS.Tables(DT.TableName).Rows(0).Item("PERIODO_TRIBUTARIO")
    '        mifecha = fecha
    '        mifecha2 = mifecha.ToString("dd-MM-yyy")

    '        MsgBox("FOLIO:     " & (folio) & "-" & (mifecha2) & "", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
    '    Else
    '        MsgBox("LOS DATOS DE LA FACTURA NO SE ENCUENTRAN EN LA BASE DE DATOS", 0 + 16, "ERROR")
    '    End If
    '    conexion.Close()
    'End Sub

    Sub mostrar_malla_facturas()
        conexion.Close()
        DS1.Tables.Clear()
        DT1.Rows.Clear()
        DT1.Columns.Clear()
        DS1.Clear()
        conexion.Open()

        SC1.Connection = conexion
        SC1.CommandText = "select codigo_folio as 'FOLIO',PERIODO_TRIBUTARIO  as 'FECHA',total  as 'TOTAL',libro_de_compras.rut_proveedor as 'RUT PROV.', nombre_proveedor  as 'PROVEEDOR'  from libro_de_compras, proveedores where libro_de_compras.rut_proveedor=proveedores.rut_proveedor and nro_factura= '" & (txt_nro_doc.Text) & "'"
        DA1.SelectCommand = SC1
        DA1.Fill(DT1)
        DS1.Tables.Add(DT1)

        grilla_facturas.DataSource = DS1.Tables(DT1.TableName)
        conexion.Close()

    End Sub




    Private Sub btn_buscar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Dim mensaje As String = ""
        'If txt_nombre_proveedor.Text = "" Then
        '    mensaje = "CAMPO RUT PROVEEDOR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
        '    txt_rut_proveedor.Focus()
        '    MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
        '    Exit Sub
        'End If

        If txt_nro_doc.Text = "" Then
            mensaje = "CAMPO NRO. DOC. VACIO, FAVOR LLENAR" + Chr(13) & mensaje
            txt_nro_doc.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        mostrar_malla_facturas()
        '   End If
    End Sub

    Private Sub txt_nro_doc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc.GotFocus
        txt_nro_doc.BackColor = Color.LightSkyBlue
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



        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            btn_buscar.Focus()
        End If
    End Sub

    Private Sub txt_nro_doc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc.LostFocus
        txt_nro_doc.BackColor = Color.White
    End Sub

    Private Sub txt_nro_doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_doc.TextChanged

    End Sub

    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub



    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        txt_nro_doc.Text = ""
        grilla_facturas.DataSource = Nothing
    End Sub

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

End Class