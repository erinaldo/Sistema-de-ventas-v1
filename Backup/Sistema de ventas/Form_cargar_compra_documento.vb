Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Public Class Form_cargar_compra_documento
    Dim dias As Integer
    Private Sub Form_cargar_compra_documento_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        Form_enviar_documento.Enabled = True
        Form_enviar_documento.WindowState = FormWindowState.Normal

    End Sub

    Private Sub Form_cargar_compra_documento_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_cargar_compra_documento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()


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



        Radio_impresora_1.Checked = True
        radio_codigo_de_barra.Checked = True


        txt_nro_doc.Focus()
        ' TextBox1.Text = ActiveControl.Name
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub cargar_datos_compra()

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from compra where n_compra ='" & (txt_nro_doc.Text) & "' and rut_proveedor ='" & (txt_rut_proveedor.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        Try
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                'Form_enviar_documento.txt_tipo_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("TIPO")
                Form_enviar_documento.txt_nro_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("n_compra")
                ' Form_enviar_documento.txt_neto.Text = DS.Tables(DT.TableName).Rows(0).Item("neto")
                'Form_enviar_documento.txt_iva.Text = DS.Tables(DT.TableName).Rows(0).Item("iva")
                ' Form_enviar_documento.txt_total.Text = DS.Tables(DT.TableName).Rows(0).Item("total")
                'Form_enviar_documento.txt_codigo_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("codigo_compra")
                'Form_enviar_documento.txt_emision.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha_emision")
                Form_enviar_documento.txt_rut_proveedor.Text = txt_rut_proveedor.Text
                Form_enviar_documento.mostrar_datos_proveedores_combo()
                '   Form_enviar_documento.txt_tipo_doc.Enabled = False
                '  Form_enviar_documento.txt_emision.Enabled = False
                ' Form_enviar_documento.txt_rut_proveedor.Enabled = False
                ' Form_enviar_documento.txt_nro_doc.Enabled = False
                ' Form_enviar_documento.txt_total.Enabled = False
                ' Form_enviar_documento.btn_modificar_doc.Enabled = True
                Form_enviar_documento.txt_nro_doc.Focus()
            Else

                Form_enviar_documento.txt_rut_proveedor.Text = txt_rut_proveedor.Text
                Form_enviar_documento.txt_nro_doc.Text = txt_nro_doc.Text
                'Form_enviar_documento.txt_tipo_doc.Focus()
            End If
        Catch
        End Try
        conexion.Close()


    End Sub

    Sub guion_rut()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut_proveedor.Text
        If rut_cliente.Length > 2 Then
            guion = rut_cliente(rut_cliente.Length - 2).ToString()
            If guion <> "-" Then
                Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                rut_cliente = rut_cliente & "-" & fin_rut
                txt_rut_proveedor.Text = rut_cliente
            End If
        End If
    End Sub

    Sub cargar_compra()
        Form_enviar_documento.grilla_detalle.Rows.Clear()
        Form_enviar_documento.Enabled = True
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select cod_producto, nombre, cantidad,precio_unitario,  valor_unitario, detalle_compra.descuento, detalle_compra.descuento2, detalle_compra.descuento3, detalle_compra.descuento4, detalle_compra.neto, detalle_compra.iva, detalle_compra.total, factor, precio_venta, margen from detalle_compra,COMPRA where compra.n_compra=detalle_compra.n_compra and compra.n_compra='" & (txt_nro_doc.Text) & "' and compra.rut_proveedor='" & (txt_rut_proveedor.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        Form_enviar_documento.grilla_detalle.Columns.Clear()
        Form_enviar_documento.grilla_detalle.Columns.Add("cod_producto", "COD.")
        Form_enviar_documento.grilla_detalle.Columns.Add("nombre", "NOMBRE")
        Form_enviar_documento.grilla_detalle.Columns.Add("detalle_compras.cantidad", "CANT.")
        Form_enviar_documento.grilla_detalle.Columns.Add("valor_unitario", "DESC. 1")
        Form_enviar_documento.grilla_detalle.Columns.Add("descuento", "DESC. 2")
        Form_enviar_documento.grilla_detalle.Columns.Add("descuento2", "DESC. 3")
        Form_enviar_documento.grilla_detalle.Columns.Add("descuento3", "DESC. 4")
        Form_enviar_documento.grilla_detalle.Columns.Add("neto", "NETO")

        Form_enviar_documento.grilla_detalle.Columns(6).Visible = True
        Form_enviar_documento.grilla_detalle.Columns(7).Visible = True
        Form_enviar_documento.grilla_detalle.Columns(8).Visible = True
        Form_enviar_documento.grilla_detalle.Columns(9).Visible = True
        Form_enviar_documento.grilla_detalle.Columns(10).Visible = True
        Form_enviar_documento.grilla_detalle.Columns(11).Visible = True
        Form_enviar_documento.grilla_detalle.Columns(12).Visible = True

        'Form_libro_de_compras.grilla_libro_compras.Columns(0).Width = 85

        Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        If DS.Tables(DT.TableName).Rows.Count > 0 Then



            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1


                Form_enviar_documento.grilla_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("COD_PRODUCTO"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("PRECIO_UNITARIO"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("VALOR_UNITARIO"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO2"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO3"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO4"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("NETO"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("IVA"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("TOTAL"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("FACTOR"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("PRECIO_venta"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("MARGEN"), _
                                                                  "INGRESADO")






                'DS.Tables(DT.TableName).Rows(i).Item("costo"))
            Next









            'conexion.Close()
            'DS.Tables.Clear()
            'DT.Rows.Clear()
            'DT.Columns.Clear()
            'DS.Clear()
            'SC.Connection = conexion
            '' SC.CommandText = "select * from detalle_boleta where detalle_boleta.n_boleta='" & (txt_cargar.Text) & "'"
            'SC.CommandText = "select cod_producto, nombre, cantidad,precio_unitario,  valor_unitario, detalle_compra.descuento, detalle_compra.descuento2, detalle_compra.descuento3, detalle_compra.descuento4, detalle_compra.neto, detalle_compra.iva, detalle_compra.total, factor, precio_venta, margen from detalle_compra,COMPRA where compra.n_compra=detalle_compra.n_compra and compra.n_compra='" & (txt_nro_doc.Text) & "' and compra.rut_proveedor='" & (txt_rut_proveedor.Text) & "'"

            'DA.SelectCommand = SC
            'DA.Fill(DT)
            'DS.Tables.Add(DT)


            'If DS.Tables(DT.TableName).Rows.Count > 0 Then

            '    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
            '        Form_Compra.grilla_detalle.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("COD_PRODUCTO"), _
            '                             DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
            '                              DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
            '                               DS.Tables(DT.TableName).Rows(i).Item("PRECIO_UNITARIO"), _
            '                                DS.Tables(DT.TableName).Rows(i).Item("VALOR_UNITARIO"), _
            '                                 DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO"), _
            '                                  DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO2"), _
            '                                   DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO3"), _
            '                                    DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO4"), _
            '                                     DS.Tables(DT.TableName).Rows(i).Item("NETO"), _
            '                                      DS.Tables(DT.TableName).Rows(i).Item("IVA"), _
            '                                       DS.Tables(DT.TableName).Rows(i).Item("TOTAL"), _
            '                                        DS.Tables(DT.TableName).Rows(i).Item("FACTOR"), _
            '                                         DS.Tables(DT.TableName).Rows(i).Item("PRECIO_venta"), _
            '                                          DS.Tables(DT.TableName).Rows(i).Item("MARGEN"), _
            '                                              "INGRESADO")
            '    Next


        End If
        '   End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
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





        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If






        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btn_aceptar.Focus()
        End If
    End Sub

    Private Sub txt_nro_doc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_doc.LostFocus
        txt_nro_doc.BackColor = Color.White
    End Sub

    Private Sub txt_rut_proveedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_proveedor.GotFocus
        txt_rut_proveedor.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_rut_proveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rut_proveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_nro_doc.Focus()
        End If
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









        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            ' guion_rut()
            txt_nro_doc.Focus()
        End If
    End Sub

    Private Sub txt_rut_proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_proveedor.LostFocus
        txt_rut_proveedor.BackColor = Color.White
    End Sub

    Private Sub btn_aceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.GotFocus
        btn_aceptar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_aceptar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.LostFocus
        btn_aceptar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click


        Dim mensaje As String = ""
        If txt_nro_doc.Text = "" Then
            mensaje = "CAMPO NRO. DOC. VACIO, FAVOR LLENAR" + Chr(13) & mensaje
            txt_nro_doc.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_rut_proveedor.Text = "" Then
            mensaje = "CAMPO RUT PROVEEDOR VACIO, FAVOR LLENAR" + Chr(13) & mensaje
            txt_rut_proveedor.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If



        If mirutempresa <> "87686300-6" Then
            If tipo_usuario <> "ADMINISTRADOR DEL SISTEMA" Then

                verificar_fecha()
                If dias > 3 Then
                    MsgBox("NO PUEDE EDITAR UN DOCUMENTO LUEGO DE TRES DIAS", MessageBoxIcon.Error + MsgBoxStyle.OkOnly, "ATENCION")
                    Exit Sub
                End If

            End If
        End If
        Form_enviar_documento.Show()
        Form_enviar_documento.controles(True, False)

        Form_enviar_documento.cargar_compra()
        cargar_datos_compra()
        Form_enviar_documento.mostrar_datos_proveedores()



        If Radio_impresora_1.Checked = True Then
            Form_enviar_documento.Radio_impresora_1.Checked = True
        Else
            Form_enviar_documento.Radio_impresora_2.Checked = True
        End If
        If radio_codigo_de_barra.Checked = True Then
            Form_enviar_documento.radio_codigo_de_barra.Checked = True
        Else
            Form_enviar_documento.radio_solo_numeros.Checked = True
        End If
        Form_enviar_documento.WindowState = FormWindowState.Normal





        If Form_enviar_documento.grilla_detalle.Rows.Count <> 0 Then
            For i = 0 To Form_enviar_documento.grilla_detalle.Rows.Count - 1
                Form_enviar_documento.grilla_detalle.Rows(i).Cells(19).Value = True
            Next
        End If

        Me.Close()
    End Sub


    Sub verificar_fecha()

        dias = "0"

        Dim fecha_emision As String

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select fecha_emision from COMPRA where compra.n_compra='" & (Me.txt_nro_doc.Text) & "' and compra.rut_proveedor='" & (Me.txt_rut_proveedor.Text) & "'"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)


        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            fecha_emision = DS.Tables(DT.TableName).Rows(0).Item("fecha_emision")

            Dim mifecha As Date
            mifecha = fecha_emision
            fecha_emision = mifecha.ToString("dd-MM-yyy")


            Dim fecha_1 As Date
            Dim fecha_2 As Date

            fecha_1 = Now.Date
            fecha_2 = fecha_emision


            dias = (fecha_1 - fecha_2).TotalDays
        End If




    End Sub

    Private Sub txt_nro_doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_doc.TextChanged

    End Sub

    Private Sub txt_rut_proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_proveedor.TextChanged

    End Sub

    Private Sub btn_aceptar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btn_aceptar.KeyPress

    End Sub

End Class