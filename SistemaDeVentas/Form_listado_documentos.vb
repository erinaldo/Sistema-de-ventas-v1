Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_listado_documentos

    Private Sub Form_listado_documentos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_anular_documentos.Enabled = True
        Form_anular_documentos.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_listado_documentos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_listado_documentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        combo_documentos.Text = "BOLETA"
        txt_numero_inicio.Focus()
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub mostrar_malla()
        If combo_documentos.Text = "FACTURA" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from factura, usuarios  where  n_factura BETWEEN  '" & Int(txt_numero_inicio.Text) & " ' and  '" & Int(txt_numero_termino.Text) & "' and usuarios.rut_usuario= factura.usuario_responsable and TIPO <> 'AJUSTE'  order by (n_factura)"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_listado.Rows.Clear()
            grilla_listado.Columns.Clear()
            grilla_listado.Columns.Add("TIPO", "TIPO")
            grilla_listado.Columns.Add("n_factura", "NRO.")
            grilla_listado.Columns.Add("fecha_venta", "FECHA")
            grilla_listado.Columns.Add("descuento", "DESCTO.")
            grilla_listado.Columns.Add("neto", "NETO")
            grilla_listado.Columns.Add("iva", "IVA")
            grilla_listado.Columns.Add("total", "TOTAL")
            grilla_listado.Columns.Add("condiciones", "CONDIC.")
            grilla_listado.Columns.Add("estado", "ESTADO")
            grilla_listado.Columns.Add("nombre_usuario", "USUARIO")

            '  Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim fecha_venta As String
                    fecha_venta = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    'If descripcion_caracteres.Length > 55 Then
                    '    descripcion_caracteres = descripcion_caracteres.Substring(0, 55)
                    'End If


                    grilla_listado.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("n_factura"), _
                                             fecha_venta, _
                                                   DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("condiciones"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("estado"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"))

                Next

                grilla_listado.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                grilla_listado.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If





            Exit Sub
        End If








        If combo_documentos.Text = "BOLETA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from boleta, usuarios  where  n_boleta BETWEEN  '" & (txt_numero_inicio.Text) & " ' and  '" & (txt_numero_termino.Text) & "' and usuarios.rut_usuario= BOLETA.usuario_responsable and TIPO <> 'AJUSTE'  order by n_boleta asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_listado.Rows.Clear()
            grilla_listado.Columns.Clear()
            grilla_listado.Columns.Add("TIPO", "TIPO")
            grilla_listado.Columns.Add("n_boleta", "NRO.")
            grilla_listado.Columns.Add("fecha_venta", "FECHA")
            grilla_listado.Columns.Add("descuento", "DESCTO.")
            grilla_listado.Columns.Add("neto", "NETO")
            grilla_listado.Columns.Add("iva", "IVA")
            grilla_listado.Columns.Add("total", "TOTAL")
            grilla_listado.Columns.Add("condiciones", "CONDIC.")
            grilla_listado.Columns.Add("estado", "ESTADO")
            grilla_listado.Columns.Add("nombre_usuario", "USUARIO")
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim fecha_venta As String
                    fecha_venta = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")

                    grilla_listado.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("tipo"), _
                                             DS.Tables(DT.TableName).Rows(i).Item("n_boleta"), _
                                              fecha_venta, _
                                               DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("condiciones"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("estado"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"))

                Next
                grilla_listado.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                grilla_listado.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            Exit Sub
        End If

        If combo_documentos.Text = "GUIA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from guia, usuarios  where  n_guia BETWEEN  '" & (txt_numero_inicio.Text) & " ' and  '" & (txt_numero_termino.Text) & "'  and usuarios.rut_usuario= guia.usuario_responsable  and TIPO <> 'AJUSTE'  order by n_guia asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_listado.Rows.Clear()
            grilla_listado.Columns.Clear()
            grilla_listado.Columns.Add("TIPO", "TIPO")
            grilla_listado.Columns.Add("n_guia", "NRO.")
            grilla_listado.Columns.Add("fecha_venta", "FECHA")
            grilla_listado.Columns.Add("descuento", "DESCTO.")
            grilla_listado.Columns.Add("neto", "NETO")
            grilla_listado.Columns.Add("iva", "IVA")
            grilla_listado.Columns.Add("total", "TOTAL")
            grilla_listado.Columns.Add("condiciones", "CONDIC.")
            grilla_listado.Columns.Add("estado", "ESTADO")
            grilla_listado.Columns.Add("nombre_usuario", "USUARIO")
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim fecha_venta As String
                    fecha_venta = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")

                    grilla_listado.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("tipo"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("n_guia"), _
                                                fecha_venta, _
                                                   DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("condiciones"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("estado"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"))

                Next

                grilla_listado.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                grilla_listado.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If


            Exit Sub
        End If
        If combo_documentos.Text = "NOTA DE CREDITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from nota_credito, usuarios   where n_nota_credito BETWEEN  '" & (txt_numero_inicio.Text) & " ' and  '" & (txt_numero_termino.Text) & "'  and usuarios.rut_usuario= nota_credito.usuario_responsable  and TIPO <> 'AJUSTE'   order by N_NOTA_CREDITO asc"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_listado.Rows.Clear()
            grilla_listado.Columns.Clear()
            grilla_listado.Columns.Add("TIPO", "TIPO")
            grilla_listado.Columns.Add("n_nota_credito", "NRO.")
            grilla_listado.Columns.Add("fecha_venta", "FECHA")
            grilla_listado.Columns.Add("descuento", "DESCTO.")
            grilla_listado.Columns.Add("neto", "NETO")
            grilla_listado.Columns.Add("iva", "IVA")
            grilla_listado.Columns.Add("total", "TOTAL")
            grilla_listado.Columns.Add("condiciones", "CONDIC.")
            grilla_listado.Columns.Add("estado", "ESTADO")
            grilla_listado.Columns.Add("nombre_usuario", "USUARIO")

            '   Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim fecha_venta As String
                    fecha_venta = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    'If descripcion_caracteres.Length > 55 Then
                    '    descripcion_caracteres = descripcion_caracteres.Substring(0, 55)
                    'End If


                    grilla_listado.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("n_nota_credito"), _
                                              fecha_venta, _
                                                   DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("condiciones"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("estado"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"))

                Next

                grilla_listado.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                grilla_listado.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If


            Exit Sub
        End If


        If combo_documentos.Text = "COTIZACION" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from cotizacion, usuarios   where  n_cotizacion BETWEEN  '" & (txt_numero_inicio.Text) & " ' and  '" & (txt_numero_termino.Text) & "'  and usuarios.rut_usuario= cotizacion.usuario_responsable   and TIPO <> 'AJUSTE'  order by N_COTIZACION asc"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_listado.Rows.Clear()
            grilla_listado.Columns.Clear()
            grilla_listado.Columns.Add("TIPO", "TIPO")
            grilla_listado.Columns.Add("n_cotizacion", "NRO.")
            grilla_listado.Columns.Add("fecha_venta", "FECHA")
            grilla_listado.Columns.Add("descuento", "DESCTO.")
            grilla_listado.Columns.Add("neto", "NETO")
            grilla_listado.Columns.Add("iva", "IVA")
            grilla_listado.Columns.Add("total", "TOTAL")
            grilla_listado.Columns.Add("condiciones", "CONDIC.")
            grilla_listado.Columns.Add("estado", "ESTADO")
            grilla_listado.Columns.Add("nombre_usuario", "USUARIO")

            '   Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim fecha_venta As String
                    fecha_venta = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                    'If descripcion_caracteres.Length > 55 Then
                    '    descripcion_caracteres = descripcion_caracteres.Substring(0, 55)
                    'End If


                    grilla_listado.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("n_cotizacion"), _
                                                 fecha_venta, _
                                                   DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("condiciones"), _
                                                        "-", _
                                                         DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"))

                Next

                grilla_listado.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                grilla_listado.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If


            '  Exit Sub
        End If











        If combo_documentos.Text = "ABONO" Then

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from abono, usuarios  where  n_abono BETWEEN  '" & Int(txt_numero_inicio.Text) & " ' and  '" & Int(txt_numero_termino.Text) & "' and usuarios.rut_usuario= ABONO.usuario_responsable and TIPO <> 'AJUSTE'  order by (n_abono)"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_listado.Rows.Clear()
            grilla_listado.Columns.Clear()
            grilla_listado.Columns.Add("TIPO", "TIPO")
            grilla_listado.Columns.Add("n_abono", "NRO. ABONO")
            grilla_listado.Columns.Add("fecha", "FECHA")
            grilla_listado.Columns.Add("rut_cliente", "RUT CLIENTE")
            grilla_listado.Columns.Add("nombre", "NOMBRE")
            grilla_listado.Columns.Add("monto_abono", "MONTO ABONO")
            grilla_listado.Columns.Add("nombre_usuario", "USUARIO")

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim fecha_venta As String
                    fecha_venta = DS.Tables(DT.TableName).Rows(i).Item("FECHA")
                    'If descripcion_caracteres.Length > 55 Then
                    '    descripcion_caracteres = descripcion_caracteres.Substring(0, 55)
                    'End If


                    grilla_listado.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("n_abono"), _
                                             fecha_venta, _
                                                   DS.Tables(DT.TableName).Rows(i).Item("rut_cliente"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("nombre"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("monto_abono"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"))

                Next

                grilla_listado.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                grilla_listado.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grilla_listado.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If





            Exit Sub
        End If
    End Sub

    Private Sub Combo_numero_termino_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Convert.ToChar(Keys.Escape)) Then
            ' txt_codigo.Focus()

        ElseIf (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_malla()
        End If
    End Sub

    Private Sub Combo_numero_termino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_numero_termino_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero_termino.GotFocus
        txt_numero_termino.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_numero_termino_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero_termino.KeyPress

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
            Dim MENSAJE As String = ""
            If combo_documentos.Text = "" Then
                ' MENSAJE = "SELECCIONE EL TIPO DE DOCUMENTO" + Chr(13) & MENSAJE
                MsgBox("SELECCIONE EL TIPO DE DOCUMENTO", 0 + 16, "ERROR")
                combo_documentos.Focus()
                ' MsgBox(MENSAJE, MsgBoxStyle.OkOnly)

            ElseIf txt_numero_inicio.Text = "" Then
                ' MENSAJE = "INGRESE EL N° DE INICIO PARA EL LISTADO" + Chr(13) & MENSAJE
                MsgBox("INGRESE EL N° DE INICIO PARA EL LISTADO", 0 + 16, "ERROR")
                txt_numero_inicio.Focus()
                '  MsgBox(MENSAJE, MsgBoxStyle.OkOnly)
            ElseIf txt_numero_termino.Text = "" Then
                ' MENSAJE = "INGRESE EL N° DE TERMINO PARA EL LISTADO" + Chr(13) & MENSAJE
                MsgBox("INGRESE EL N° DE TERMINO PARA EL LISTADO", 0 + 16, "ERROR")
                txt_numero_termino.Focus()

                ' 'MsgBox(MENSAJE, MsgBoxStyle.OkOnly)
            Else

                mostrar_malla()
                calcular_total()
            End If
        End If
    End Sub


    'va generando el calculo del neto iva total y descuento del documento, es decir de la suma de todos los productos ingresados.
    Sub calcular_total()

        Dim totalgrilla As Integer






        '//Calcular el total general

        If combo_documentos.Text <> "ABONO" Then

            txt_total_contado.Text = 0
            txt_total_credito.Text = 0
            For i = 0 To grilla_listado.Rows.Count - 1

                If grilla_listado.Rows(i).Cells(7).Value.ToString = "CREDITO" Then
                    totalgrilla = Val(grilla_listado.Rows(i).Cells(6).Value.ToString)
                    txt_total_credito.Text = Val(txt_total_credito.Text) + Val(totalgrilla)
                Else
                    totalgrilla = Val(grilla_listado.Rows(i).Cells(6).Value.ToString)
                    txt_total_contado.Text = Val(txt_total_contado.Text) + Val(totalgrilla)
                End If
            Next

        End If


        If txt_total_contado.Text = "" Or txt_total_contado.Text = "0" Then
            txt_total_contado_millar.Text = "0"
        Else
            txt_total_contado_millar.Text = Format(Int(txt_total_contado.Text), "###,###,###")
        End If


        If txt_total_credito.Text = "" Or txt_total_credito.Text = "0" Then
            txt_total_credito_millar.Text = "0"
        Else
            txt_total_credito_millar.Text = Format(Int(txt_total_credito.Text), "###,###,###")
        End If
    End Sub

    Private Sub txt_numero_termino_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero_termino.LostFocus
        txt_numero_termino.BackColor = Color.White
    End Sub



    Private Sub txt_numero_termino_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero_termino.TextChanged

    End Sub

    Private Sub combo_documentos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_documentos.GotFocus
        combo_documentos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_documentos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_documentos.LostFocus
        combo_documentos.BackColor = Color.White
    End Sub

    Private Sub combo_documentos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_documentos.SelectedIndexChanged
        txt_numero_inicio.Focus()
    End Sub

    Private Sub txt_numero_inicio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero_inicio.GotFocus
        txt_numero_inicio.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_numero_inicio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero_inicio.KeyPress

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
            Dim mensaje As String = ""
            If combo_documentos.Text = "" Then
                ' mensaje = "SELECCIONE EL TIPO DE DOCUMENTO" + Chr(13) & mensaje
                MsgBox("SELECCIONE EL TIPO DE DOCUMENTO", 0 + 16, "ERROR")
                combo_documentos.Focus()
                ' MsgBox(mensaje, MsgBoxStyle.OkOnly)

            ElseIf txt_numero_inicio.Text = "" Then
                ' mensaje = "INGRESE EL N° DE INICIO PARA EL LISTADO" + Chr(13) & mensaje
                MsgBox("INGRESE EL N° DE INICIO PARA EL LISTADO", 0 + 16, "ERROR")
                txt_numero_inicio.Focus()
                '  MsgBox(mensaje, MsgBoxStyle.OkOnly)
            ElseIf txt_numero_termino.Text = "" Then
                '  mensaje = "INGRESE EL N° DE TERMINO PARA EL LISTADO" + Chr(13) & mensaje
                MsgBox("INGRESE EL N° DE TERMINO PARA EL LISTADO", 0 + 16, "ERROR")
                txt_numero_termino.Focus()
                '  MsgBox(mensaje, MsgBoxStyle.OkOnly)

            Else
                mostrar_malla()
                calcular_total()
            End If
        End If
    End Sub

    Private Sub txt_numero_inicio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero_inicio.LostFocus
        txt_numero_inicio.BackColor = Color.White
    End Sub

    Private Sub txt_numero_inicio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero_inicio.TextChanged

    End Sub

    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Salir.Click
        Me.Close()
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub

    Private Sub Salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Salir.GotFocus
        Salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Salir.LostFocus
        Salir.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub txt_total_contado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total_contado.TextChanged

    End Sub

    Private Sub grilla_listado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_listado.CellContentClick

    End Sub

    Private Sub grilla_listado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_listado.DoubleClick
        If grilla_listado.Rows.Count <> 0 Then

            Dim estado As String
            Dim nro_guia As String
            Dim nro_factura As String
            'Dim fecha_factura As String
            'Dim tipo_doc As String

            nro_guia = grilla_listado.CurrentRow.Cells(1).Value
            estado = grilla_listado.CurrentRow.Cells(8).Value

            If combo_documentos.Text = "GUIA" And estado = "FACTURADA" Then

                conexion.Close()
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from detalle_factura where cod_producto ='" & (nro_guia) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    nro_factura = DS.Tables(DT.TableName).Rows(0).Item("n_factura")
                    '    fecha_factura = DS.Tables(DT.TableName).Rows(0).Item("fecha_venta")


                    MsgBox("GUIA FACTURADA CON DOCUMENTO NUMERO: " & nro_factura, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                End If
                conexion.Close()
                'End If
            End If
        End If
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""



        If grilla_listado.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            txt_numero_inicio.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_listado, save.FileName)
        End If
    End Sub

    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)

        Dim xlApp As Object = CreateObject("Excel.Application")
        'crear una nueva hoja de calculo 
        Dim xlWB As Object = xlApp.WorkBooks.add
        Dim xlWS As Object = xlWB.WorkSheets(1)

        'exportamos los caracteres de las columnas 
        For c As Integer = 0 To grilla_listado.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_listado.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_listado.RowCount - 1
            For c As Integer = 0 To grilla_listado.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_listado.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especific
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub


End Class