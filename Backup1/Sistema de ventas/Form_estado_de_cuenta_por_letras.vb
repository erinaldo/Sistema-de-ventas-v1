Imports System.IO
Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient
Imports System.Resources

Public Class Form_estado_de_cuenta_por_letras

    Dim rut_cliente As String
    Dim codigo_cliente As String
    Dim nombre_cliente As String
    Dim telefono_cliente As String
    Dim comuna_cliente As String
    Dim direccion_cliente As String
    Dim ciudad_cliente As String


    Dim mitexto As String
    Dim hasta As String


    Dim peso As String
    Dim mifecha_emision2 As String
    Dim mifecha_vencimiento2 As String
    Private Sub Form_estado_de_cuenta_por_letras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_estado_de_cuenta_por_letras_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_estado_de_cuenta_por_letras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        dtp_fecha_faturacion.CustomFormat = "yyy-MM-dd"
        combo_impresion.Text = "TODOS"
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub limpiar()
        txt_hasta.Text = ""
        txt_desde.Text = ""
        txt_total.Text = ""
        txt_total_deuda.Text = ""
        txt_total_saldo.Text = ""
        grilla_clientes.Rows.Clear()
        grilla_estado_de_cuenta.Rows.Clear()
        'grilla_estado_de_cuenta_final.Rows.Clear()
    End Sub

    Sub mostrar_malla_clientes()
        mitexto = txt_desde.Text & "%"

        If txt_hasta.Text = "A" Then
            hasta = "B"
        End If

        If txt_hasta.Text = "B" Then
            hasta = "C"
        End If

        If txt_hasta.Text = "C" Then
            hasta = "D"
        End If

        If txt_hasta.Text = "D" Then
            hasta = "E"
        End If

        If txt_hasta.Text = "E" Then
            hasta = "F"
        End If

        If txt_hasta.Text = "F" Then
            hasta = "G"
        End If

        If txt_hasta.Text = "G" Then
            hasta = "H"
        End If

        If txt_hasta.Text = "H" Then
            hasta = "I"
        End If

        If txt_hasta.Text = "I" Then
            hasta = "J"
        End If

        If txt_hasta.Text = "J" Then
            hasta = "K"
        End If

        If txt_hasta.Text = "K" Then
            hasta = "L"
        End If

        If txt_hasta.Text = "L" Then
            hasta = "M"
        End If

        If txt_hasta.Text = "M" Then
            hasta = "M"
        End If

        If txt_hasta.Text = "N" Then
            hasta = "Ñ"
        End If

        If txt_hasta.Text = "Ñ" Then
            hasta = "O"
        End If

        If txt_hasta.Text = "O" Then
            hasta = "P"
        End If

        If txt_hasta.Text = "P" Then
            hasta = "Q"
        End If

        If txt_hasta.Text = "Q" Then
            hasta = "R"
        End If

        If txt_hasta.Text = "R" Then
            hasta = "S"
        End If

        If txt_hasta.Text = "S" Then
            hasta = "T"
        End If

        If txt_hasta.Text = "T" Then
            hasta = "U"
        End If

        If txt_hasta.Text = "U" Then
            hasta = "V"
        End If

        If txt_hasta.Text = "V" Then
            hasta = "W"
        End If

        If txt_hasta.Text = "W" Then
            hasta = "X"
        End If

        If txt_hasta.Text = "X" Then
            hasta = "Y"
        End If

        If txt_hasta.Text = "Y" Then
            hasta = "Z"
        End If

        If txt_hasta.Text = "Z" Then
            hasta = "Z"
        End If

        If combo_impresion.Text = "TODOS" Then
            If txt_desde.Text = txt_hasta.Text Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                SC.Connection = conexion
                SC.CommandText = "select * from clientes, CREDITOS  where  clientes.rut_cliente = creditos.rut_cliente and saldo > '0' AND TIPO <> 'NOTA DE CREDITO' AND  nombre_cliente like '" & (mitexto) & "' GROUP BY clientes.rut_CLIENTE order by nombre_cliente"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                grilla_clientes.Rows.Clear()

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                        grilla_clientes.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("rut_cliente"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("codigo_cliente"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("telefono_cliente"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("comuna_cliente"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("direccion_cliente"))
                    Next
                End If
            End If

            If txt_desde.Text <> txt_hasta.Text Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                SC.Connection = conexion
                SC.CommandText = "select * from clientes, CREDITOS  where  clientes.rut_cliente = creditos.rut_cliente and saldo > '0' AND TIPO <> 'NOTA DE CREDITO' AND  nombre_cliente BETWEEN  '" & (txt_desde.Text) & "' and '" & (hasta) & "' and creditos.TIPO='FACTURA' GROUP BY CODIGO_CLIENTE order by nombre_cliente"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                grilla_clientes.Rows.Clear()

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                        grilla_clientes.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("rut_cliente"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("codigo_cliente"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("telefono_cliente"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("comuna_cliente"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("direccion_cliente"))
                    Next
                End If
            End If
        End If

        If combo_impresion.Text = "FACTURACION" Then
            If txt_desde.Text = txt_hasta.Text Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                SC.Connection = conexion
                SC.CommandText = "select * from clientes, CREDITOS  where  clientes.rut_cliente = creditos.rut_cliente and saldo > '0' AND TIPO <> 'NOTA DE CREDITO' AND  nombre_cliente like '" & (mitexto) & "' and creditos.TIPO='FACTURA' and creditos.fecha_venta='" & (dtp_fecha_faturacion.Text) & "'  AND CREDITOS.USUARIO_RESPONSABLE='SISTEMA' GROUP BY clientes.rut_CLIENTE order by nombre_cliente"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                grilla_clientes.Rows.Clear()

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                        grilla_clientes.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("rut_cliente"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("codigo_cliente"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("telefono_cliente"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("comuna_cliente"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("direccion_cliente"))
                    Next
                End If
            End If

            If txt_desde.Text <> txt_hasta.Text Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                SC.Connection = conexion

                SC.CommandText = "select * from clientes, CREDITOS  where  clientes.rut_cliente = creditos.rut_cliente and saldo > '0' AND TIPO <> 'NOTA DE CREDITO' AND  nombre_cliente BETWEEN  '" & (txt_desde.Text) & "' and '" & (hasta) & "' and creditos.TIPO='FACTURA' and creditos.fecha_venta='" & (dtp_fecha_faturacion.Text) & "' AND CREDITOS.USUARIO_RESPONSABLE='SISTEMA' GROUP BY CODIGO_CLIENTE order by nombre_cliente"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                grilla_clientes.Rows.Clear()

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                        grilla_clientes.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("rut_cliente"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("codigo_cliente"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("telefono_cliente"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("comuna_cliente"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("direccion_cliente"))
                    Next
                End If
            End If
        End If

        If grilla_clientes.Rows.Count <> 0 Then
            If grilla_clientes.Columns(0).Width = 1500 Then
                grilla_clientes.Columns(0).Width = 149
            Else
                grilla_clientes.Columns(0).Width = 150
            End If
        End If
    End Sub
















    Sub malla_clientes_remoto()
        If combo_impresion.Text = "TODOS" Then

            If txt_desde.Text = txt_hasta.Text Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                SC.Connection = conexion
                SC.CommandText = "select * from clientes, CREDITOS  where  clientes.rut_cliente = creditos.rut_cliente and saldo > '0' AND TIPO <> 'NOTA DE CREDITO' AND  nombre_cliente like '" & (mitexto) & "' GROUP BY clientes.rut_CLIENTE order by nombre_cliente"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                grilla_clientes.Rows.Clear()

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
                        codigo_cliente = DS.Tables(DT.TableName).Rows(i).Item("codigo_cliente")
                        nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente")
                        telefono_cliente = DS.Tables(DT.TableName).Rows(i).Item("telefono_cliente")
                        comuna_cliente = DS.Tables(DT.TableName).Rows(i).Item("comuna_cliente")
                        direccion_cliente = DS.Tables(DT.TableName).Rows(i).Item("direccion_cliente")

                        SC.Connection = conexion
                        SC.CommandText = "INSERT INTO clientes_temporal(rut_cliente, codigo_cliente, nombre_cliente, telefono_cliente, comuna_cliente, direccion_cliente) VALUES ('" & (rut_cliente) & "','" & (codigo_cliente) & "','" & (nombre_cliente) & "','" & (telefono_cliente) & "','" & (comuna_cliente) & "','" & (direccion_cliente) & "')"
                        DA.SelectCommand = SC
                        DA.Fill(DT)

                    Next
                End If
            End If

            If txt_desde.Text <> txt_hasta.Text Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                SC.Connection = conexion

                SC.CommandText = "select * from clientes, CREDITOS  where  clientes.rut_cliente = creditos.rut_cliente and saldo > '0' AND TIPO <> 'NOTA DE CREDITO' AND  nombre_cliente BETWEEN  '" & (txt_desde.Text) & "' and '" & (hasta) & "' and creditos.TIPO='FACTURA' GROUP BY CODIGO_CLIENTE order by nombre_cliente"

                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                grilla_clientes.Rows.Clear()

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
                        codigo_cliente = DS.Tables(DT.TableName).Rows(i).Item("codigo_cliente")
                        nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente")
                        telefono_cliente = DS.Tables(DT.TableName).Rows(i).Item("telefono_cliente")
                        comuna_cliente = DS.Tables(DT.TableName).Rows(i).Item("comuna_cliente")
                        direccion_cliente = DS.Tables(DT.TableName).Rows(i).Item("direccion_cliente")

                        SC.Connection = conexion
                        SC.CommandText = "INSERT INTO clientes_temporal(rut_cliente, codigo_cliente, nombre_cliente, telefono_cliente, comuna_cliente, direccion_cliente) VALUES ('" & (rut_cliente) & "','" & (codigo_cliente) & "','" & (nombre_cliente) & "','" & (telefono_cliente) & "','" & (comuna_cliente) & "','" & (direccion_cliente) & "')"
                        DA.SelectCommand = SC
                        DA.Fill(DT)

                    Next
                End If
            End If

        End If















        If combo_impresion.Text = "FACTURACION" Then

            If txt_desde.Text = txt_hasta.Text Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                SC.Connection = conexion
                SC.CommandText = "select * from clientes, CREDITOS  where  clientes.rut_cliente = creditos.rut_cliente and saldo > '0' AND TIPO <> 'NOTA DE CREDITO' AND  nombre_cliente like '" & (mitexto) & "' and creditos.TIPO='FACTURA' and creditos.fecha_venta='" & (dtp_fecha_faturacion.Text) & "'  AND CREDITOS.USUARIO_RESPONSABLE='SISTEMA' GROUP BY clientes.rut_CLIENTE order by nombre_cliente"

                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                grilla_clientes.Rows.Clear()

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
                        codigo_cliente = DS.Tables(DT.TableName).Rows(i).Item("codigo_cliente")
                        nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente")
                        telefono_cliente = DS.Tables(DT.TableName).Rows(i).Item("telefono_cliente")
                        comuna_cliente = DS.Tables(DT.TableName).Rows(i).Item("comuna_cliente")
                        direccion_cliente = DS.Tables(DT.TableName).Rows(i).Item("direccion_cliente")

                        SC.Connection = conexion
                        SC.CommandText = "INSERT INTO clientes_temporal(rut_cliente, codigo_cliente, nombre_cliente, telefono_cliente, comuna_cliente, direccion_cliente) VALUES ('" & (rut_cliente) & "','" & (codigo_cliente) & "','" & (nombre_cliente) & "','" & (telefono_cliente) & "','" & (comuna_cliente) & "','" & (direccion_cliente) & "')"
                        DA.SelectCommand = SC
                        DA.Fill(DT)

                    Next
                End If
            End If


            If txt_desde.Text <> txt_hasta.Text Then

                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                SC.Connection = conexion

                SC.CommandText = "select * from clientes, CREDITOS  where  clientes.rut_cliente = creditos.rut_cliente and saldo > '0' AND TIPO <> 'NOTA DE CREDITO' AND  nombre_cliente BETWEEN  '" & (txt_desde.Text) & "' and '" & (hasta) & "' and creditos.TIPO='FACTURA' and creditos.fecha_venta='" & (dtp_fecha_faturacion.Text) & "' AND CREDITOS.USUARIO_RESPONSABLE='SISTEMA' GROUP BY CODIGO_CLIENTE order by nombre_cliente"

                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                grilla_clientes.Rows.Clear()

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                        rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
                        codigo_cliente = DS.Tables(DT.TableName).Rows(i).Item("codigo_cliente")
                        nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente")
                        telefono_cliente = DS.Tables(DT.TableName).Rows(i).Item("telefono_cliente")
                        comuna_cliente = DS.Tables(DT.TableName).Rows(i).Item("comuna_cliente")
                        direccion_cliente = DS.Tables(DT.TableName).Rows(i).Item("direccion_cliente")

                        SC.Connection = conexion
                        SC.CommandText = "INSERT INTO clientes_temporal(rut_cliente, codigo_cliente, nombre_cliente, telefono_cliente, comuna_cliente, direccion_cliente) VALUES ('" & (rut_cliente) & "','" & (codigo_cliente) & "','" & (nombre_cliente) & "','" & (telefono_cliente) & "','" & (comuna_cliente) & "','" & (direccion_cliente) & "')"
                        DA.SelectCommand = SC
                        DA.Fill(DT)

                    Next
                End If
            End If

        End If


    End Sub












    Sub mostrar_malla()

        ' grilla_estado_de_cuenta.Rows.Clear()

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion

        SC.CommandText = "select * from creditos  where  rut_cliente = '" & (rut_cliente) & "'  and saldo <> '0' order by fecha_venta asc"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        '  grilla_estado_de_cuenta.Rows.Clear()
        'grilla_estado_de_cuenta.Columns.Clear()
        'grilla_estado_de_cuenta.Columns.Add("n_creditos", "NRO.")
        'grilla_estado_de_cuenta.Columns.Add("tipo_detalle", "TIPO")
        'grilla_estado_de_cuenta.Columns.Add("fecha_venta", "FECHA")
        'grilla_estado_de_cuenta.Columns.Add("fecha_vncimiento", "VENCIMIENTO")
        'grilla_estado_de_cuenta.Columns.Add("RECINTO", "RECINTO")
        'grilla_estado_de_cuenta.Columns.Add("total", "TOTAL")
        'grilla_estado_de_cuenta.Columns.Add("saldo", "SALDO")
        'grilla_estado_de_cuenta.Columns.Add("saldo", "SALDO FINAL")

        '  Dim consulta As String = DS.Tables(DT.TableName).Rows.Count
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1


                Dim MiFechaEmision As Date
                MiFechaEmision = DS.Tables(DT.TableName).Rows(i).Item("fecha_venta")
                mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")


                Dim MiFechaVencimiento As Date
                MiFechaVencimiento = DS.Tables(DT.TableName).Rows(i).Item("fecha_vencimiento")
                mifecha_vencimiento2 = MiFechaVencimiento.ToString("dd-MM-yyy")

                Dim tipo_detalle As String
                tipo_detalle = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")

                If tipo_detalle = "ABONO SIN IMPUTAR" Then
                    mifecha_vencimiento2 = "-"
                End If

                If tipo_detalle = "NOTA DE CREDITO SIN IMPUTAR" Then
                    mifecha_vencimiento2 = "-"
                End If

                If tipo_detalle = "NOTA DE DEBITO SIN IMPUTAR" Then
                    mifecha_vencimiento2 = "-"
                End If



                'If rut_cliente = "2721489-4" Then
                '    MsgBox("")
                'End If

                grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_creditos"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle"), _
                                                   mifecha_emision2, _
                                                    DS.Tables(DT.TableName).Rows(i).Item("recinto"), _
                                                     mifecha_vencimiento2, _
                                                      DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("saldo"), _
                                                       Val(DS.Tables(DT.TableName).Rows(i).Item("saldo")) + Val(txt_total_deuda.Text))

                txt_total_deuda.Text = txt_total_deuda.Text + DS.Tables(DT.TableName).Rows(i).Item("saldo")
            Next


            'Dim Varcoddocumento As Integer
            'Dim VarTipo As String
            'Dim Varfecha As String
            'Dim VarRecinto As String
            'Dim VarVencimiento As String
            'Dim vartotal As Integer
            'Dim varsaldo As Integer
            ''Dim totalsaldo As Integer
            ''Dim vartotalsaldo As Integer
            'txt_total_deuda.Text = "0"

            'For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1

            '    Varcoddocumento = grilla_estado_de_cuenta.Rows(i).Cells(0).Value.ToString
            '    VarTipo = grilla_estado_de_cuenta.Rows(i).Cells(1).Value.ToString
            '    Varfecha = grilla_estado_de_cuenta.Rows(i).Cells(2).Value
            '    VarRecinto = grilla_estado_de_cuenta.Rows(i).Cells(3).Value
            '    VarVencimiento = grilla_estado_de_cuenta.Rows(i).Cells(4).Value
            '    vartotal = grilla_estado_de_cuenta.Rows(i).Cells(5).Value.ToString
            '    varsaldo = grilla_estado_de_cuenta.Rows(i).Cells(6).Value.ToString


            '    ' For e = 0 To migrilla.Rows.Count - 1

            '    Dim descripcion_tipo As String
            '    descripcion_tipo = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")

            '    If descripcion_tipo.Length > 15 Then
            '        descripcion_tipo = descripcion_tipo.Substring(0, 15)
            '    End If

            '    If descripcion_tipo = "NOTA DE CREDITO" Then

            '        If VarTipo <> "NOTA DE CREDITO SIN IMPUTAR" Then


            '            VarTipo = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")


            '            varsaldo = 0
            '        Else
            '            varsaldo = DS.Tables(DT.TableName).Rows(i).Item("saldo")
            '        End If
            '    End If






            '    descripcion_tipo = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")
            '    If descripcion_tipo.Length > 5 Then
            '        descripcion_tipo = descripcion_tipo.Substring(0, 5)
            '    End If

            '    If descripcion_tipo = "ABONO" Then

            '        If VarTipo <> "ABONO SIN IMPUTAR" Then

            '            VarTipo = DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle")





            '            If descripcion_tipo = "ABONO" Then
            '                varsaldo = 0
            '            Else
            '                varsaldo = DS.Tables(DT.TableName).Rows(i).Item("saldo")
            '            End If
            '        End If
            '    End If


            '    txt_total_deuda.Text = Val(txt_total_deuda.Text) + Val(DS.Tables(DT.TableName).Rows(i).Item("saldo"))

            '    grilla_estado_de_cuenta_final.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("n_creditos"), _
            '                              DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle"), _
            '                               DS.Tables(DT.TableName).Rows(i).Item("fecha_venta"), _
            '                                DS.Tables(DT.TableName).Rows(i).Item("total"), _
            '                                    DS.Tables(DT.TableName).Rows(i).Item("saldo"), _
            'txt_total_deuda.Text)

            'Next



            grilla_estado_de_cuenta.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_estado_de_cuenta.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_estado_de_cuenta.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            grilla_estado_de_cuenta.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            'grilla_estado_de_cuenta.Columns(0).Width = 10
            'grilla_estado_de_cuenta.Columns(1).Width = 20
            'grilla_estado_de_cuenta.Columns(2).Width = 10
            'grilla_estado_de_cuenta.Columns(3).Width = 10
            'grilla_estado_de_cuenta.Columns(4).Width = 10
            'grilla_estado_de_cuenta.Columns(5).Width = 10
            'grilla_estado_de_cuenta.Columns(6).Width = 10
            'grilla_estado_de_cuenta.Columns(7).Width = 10

            '' '' ''txt_total_deuda.Text = Format(Int(txt_total_deuda.Text), "###,###,###")

        End If


    End Sub

    Private Sub txt_desde_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_desde.KeyPress
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
            Dim mensaje As String = ""

            If txt_desde.Text = "" Then
                MsgBox("SELECCIONE LA LETRA INICIAL", 0 + 16, "ERROR")
                txt_desde.Focus()
                Exit Sub
            End If

            If txt_hasta.Text = "" Then
                MsgBox("SELECCIONE LA LETRA FINAL", 0 + 16, "ERROR")
                txt_hasta.Focus()
                Exit Sub
            End If

            mostrar_malla_clientes()

        End If
    End Sub

    Private Sub txt_desde_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_desde.TextChanged

    End Sub

    Private Sub txt_hasta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_hasta.KeyPress
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
            Dim mensaje As String = ""

            If txt_desde.Text = "" Then
                MsgBox("SELECCIONE LA LETRA INICIAL", 0 + 16, "ERROR")
                txt_desde.Focus()
                Exit Sub
            End If

            If txt_hasta.Text = "" Then
                MsgBox("SELECCIONE LA LETRA FINAL", 0 + 16, "ERROR")
                txt_hasta.Focus()
                Exit Sub
            End If


            lbl_mensaje.Visible = True
            Me.Enabled = False

            mostrar_malla_clientes()

            lbl_mensaje.Visible = False
            Me.Enabled = True

        End If
    End Sub

    Private Sub txt_hasta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_hasta.TextChanged

    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        Dim mensaje As String = ""
        If grilla_clientes.Rows.Count = 0 Then mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje

        If mensaje <> "" Then
            MsgBox(mensaje, MsgBoxStyle.OkOnly)
        Else
            lbl_mensaje.Visible = True
            Me.Enabled = False
        End If

        For i = 0 To grilla_clientes.Rows.Count - 1
            nombre_cliente = grilla_clientes.Rows(i).Cells(2).Value.ToString
            rut_cliente = grilla_clientes.Rows(i).Cells(0).Value.ToString
            direccion_cliente = grilla_clientes.Rows(i).Cells(5).Value
            telefono_cliente = grilla_clientes.Rows(i).Cells(3).Value.ToString
            ciudad_cliente = grilla_clientes.Rows(i).Cells(4).Value.ToString
            codigo_cliente = grilla_clientes.Rows(i).Cells(1).Value.ToString
            grilla_estado_de_cuenta.Rows.Clear()
            txt_total_deuda.Text = 0

            mostrar_malla()
            calcular_totales()

            If txt_total_deuda.Text = "" Or txt_total_deuda.Text = "0" Then
                txt_total_deuda.Text = "0"
            Else
                txt_total_deuda.Text = Format(Int(txt_total_deuda.Text), "###,###,###")
            End If

            If combo_impresion.Text = "TODOS" Then

                Try
                    Dim iReporte As New form_informe_estado_de_cuenta_personalizado
                    Dim rpt As New Crystal_estado_de_cuenta_personalizado

                    rpt.Load()
                    rpt.SetDataSource(ReturnDataSet)
                    rpt.Refresh()

                    iReporte.Reporte = rpt

                    rpt.PrintOptions.PrinterName = impresora_reportes

                    rpt.PrintToPrinter(1, False, 0, 0)
                    ' iReporte.ShowDialog()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If

            If combo_impresion.Text = "FACTURACION" Then
                If grilla_estado_de_cuenta.Rows.Count > 1 Then
                    Try

                        Dim iReporte As New form_informe_estado_de_cuenta_personalizado
                        Dim rpt As New Crystal_estado_de_cuenta_personalizado

                        rpt.Load()
                        rpt.SetDataSource(ReturnDataSet)
                        rpt.Refresh()
                        iReporte.Reporte = rpt
                        rpt.PrintOptions.PrinterName = impresora_reportes
                        rpt.PrintToPrinter(1, False, 0, 0)
                        ' iReporte.ShowDialog()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            End If

            lbl_mensaje.Visible = False
            Me.Enabled = True
        Next
        limpiar()
        MsgBox("SE HA IMPRESO CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCION")
    End Sub







    ' se graba el estado de cuenta mediante un ciclo for en una tabla temporal.
    Sub grabar_estado_cuenta()
        'Dim Varcoddocumento As Integer
        'Dim VarTipo As String
        'Dim Varfecha As String
        'Dim vartotal As Integer
        'Dim varsaldo As Integer
        'Dim totalsaldo As Integer
        'Dim vartotalsaldo As Integer
        'txt_total_saldo.Text = "0"


        ''DS.Tables.Clear()
        ''DT.Rows.Clear()
        ''DT.Columns.Clear()
        ''DS.Clear()
        ''conexion.Open()

        'SC.Connection = conexion
        'SC.CommandText = "delete from estado_de_cuenta_temporal"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        ''conexion.Close()


        'For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1

        '    Varcoddocumento = grilla_estado_de_cuenta_final.Rows(i).Cells(0).Value.ToString
        '    VarTipo = grilla_estado_de_cuenta_final.Rows(i).Cells(1).Value.ToString
        '    Varfecha = grilla_estado_de_cuenta_final.Rows(i).Cells(2).Value
        '    vartotal = grilla_estado_de_cuenta_final.Rows(i).Cells(3).Value.ToString
        '    varsaldo = grilla_estado_de_cuenta_final.Rows(i).Cells(4).Value.ToString

        '    ' For e = 0 To migrilla.Rows.Count - 1

        '    totalsaldo = grilla_estado_de_cuenta_final.Rows(i).Cells(4).Value.ToString
        '    '   txt_total_saldo.Text = Val(txt_total_saldo.Text) + Val(totalsaldo)
        '    'Next
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()
        '    vartotalsaldo = grilla_estado_de_cuenta_final.Rows(i).Cells(4).Value.ToString
        '    SC.Connection = conexion
        '    SC.CommandText = "insert into estado_de_cuenta_temporal (rut, nombre, direccion, telefono,TIPO, deuda_total, n_doc, fecha_venta, total, deuda_saldo, desglose, total_saldo, ciudad) values('" & (rut_cliente) & "','" & (nombre_cliente) & "','" & (direccion_cliente) & "','" & (telefono_cliente) & "','" & (VarTipo) & "','" & (txt_total.Text) & "','" & (Varcoddocumento) & "','" & (Varfecha) & "','" & (vartotal) & "','" & (varsaldo) & "','" & (txt_desglose.Text) & "','" & (totalsaldo) & "','" & (ciudad_cliente) & "')"
        '    '  SC.CommandText = "insert into estado_de_cuenta_temporal (                                                                                                                                          rut,                nombre,                                  direccion,                  telefono,              TIPO,                   deuda_total,                    n_doc,              fecha_venta,            total,      deuda_saldo,        desglose,                   total_saldo,                        ciudad) values('" & (txt_rut.Text) & "','" & (txt_nombre_cliente.Text) & "','" & (txt_direccion.Text) & "'," & (txt_telefono.Text) & ",'" & (VarTipo) & "'," & (txt_total.Text) & "," & (Varcoddocumento) & ",'" & (Varfecha) & "'," & (vartotal) & ",'" & (0) & "','" & (txt_desglose.Text) & "'," & (txt_total_saldo.Text) & ",'" & (txt_ciudad.Text) & "')"

        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    conexion.Close()

        '    'DS.Tables.Clear()
        '    'DT.Rows.Clear()
        '    'DT.Columns.Clear()
        '    'DS.Clear()
        '    'conexion.Close()
        'Next
        '' Next
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

    'va generando el calculo del neto iva total y descuento del documento, es decir de la suma de todos los productos ingresados.
    Sub calcular_totales()
        Dim totalgrilla As Integer


        '//Calcular el total 
        txt_total.Text = 0
        For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1
            totalgrilla = Val(grilla_estado_de_cuenta.Rows(i).Cells(6).Value.ToString)
            txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        Next

        '//Calcular el saldo

        peso = " PESOS"
        If CInt(txt_total.Text) = 1000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & " DE PESOS"
        ElseIf CInt(txt_total.Text) = 2000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 3000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 4000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 5000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 6000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 7000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 8000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 9000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 10000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 11000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 12000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 13000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 14000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 15000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 16000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 17000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 18000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 19000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 20000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 21000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 22000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 23000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 24000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 25000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 26000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 27000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 28000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 29000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 30000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 33000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 34000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 35000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 36000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 37000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 38000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 39000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 40000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 41000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) < 0 Then
            txt_desglose.Text = "SALDO A FAVOR"
        Else
            txt_desglose.Text = Num2Text(txt_total.Text) & peso
        End If







    End Sub

    Private Sub txt_desde_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_desde.GotFocus
        txt_desde.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_desde_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_desde.LostFocus
        txt_desde.BackColor = Color.White
    End Sub

    Private Sub txt_hasta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_hasta.GotFocus
        txt_hasta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_hasta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_hasta.LostFocus
        txt_hasta.BackColor = Color.White
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        btn_imprimir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub
    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        limpiar()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub




    Private Function ReturnDataSet() As DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ds As New DataSet


        dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
        dt.Columns.Add(New DataColumn("nombre_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("deuda_total", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("ciudad_cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo_documento", GetType(String)))
        dt.Columns.Add(New DataColumn("nro_doc", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fecha_doc", GetType(String)))
        dt.Columns.Add(New DataColumn("recinto", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha_vencimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("total_doc", GetType(Integer)))
        dt.Columns.Add(New DataColumn("saldo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("saldo_final", GetType(Integer)))
        dt.Columns.Add(New DataColumn("desglose_palabras", GetType(String)))

        dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))




        Dim Varcoddocumento As String
        Dim VarTipo As String
        Dim Varfecha As String
        Dim VarRecinto As String
        Dim VarVencimiento As String
        Dim vartotal As Integer
        Dim varsaldo As Integer
        Dim varsaldoTotal As Integer
        For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1


            Varcoddocumento = grilla_estado_de_cuenta.Rows(i).Cells(0).Value.ToString
            VarTipo = grilla_estado_de_cuenta.Rows(i).Cells(1).Value.ToString
            Varfecha = grilla_estado_de_cuenta.Rows(i).Cells(2).Value
            VarRecinto = grilla_estado_de_cuenta.Rows(i).Cells(3).Value
            VarVencimiento = grilla_estado_de_cuenta.Rows(i).Cells(4).Value
            vartotal = grilla_estado_de_cuenta.Rows(i).Cells(5).Value.ToString
            varsaldo = grilla_estado_de_cuenta.Rows(i).Cells(6).Value.ToString
            varsaldoTotal = grilla_estado_de_cuenta.Rows(i).Cells(7).Value.ToString
            dr = dt.NewRow()

            Try
                dr("Imagen") = Imagen_reporte
            Catch
            End Try

            dr("nombre_empresa") = minombreempresa
            dr("giro_empresa") = migiroempresa
            dr("direccion_empresa") = midireccionempresa
            dr("comuna_empresa") = micomunaempresa
            dr("telefono_empresa") = mitelefonoempresa
            dr("correo_empresa") = micorreoempresa
            dr("rut_empresa") = mirutempresa
            dr("nombre_cliente") = nombre_cliente
            dr("rut_cliente") = rut_cliente
            dr("deuda_total") = txt_total_deuda.Text
            dr("direccion_cliente") = direccion_cliente
            dr("telefono_cliente") = telefono_cliente
            dr("ciudad_cliente") = ciudad_cliente
            dr("desglose_palabras") = txt_desglose.Text
            dr("tipo_documento") = VarTipo
            dr("nro_doc") = Varcoddocumento
            dr("fecha_doc") = Varfecha
            dr("recinto") = VarRecinto
            dr("fecha_vencimiento") = VarVencimiento
            dr("total_doc") = vartotal
            dr("saldo") = varsaldo
            dr("saldo_final") = varsaldoTotal
            dt.Rows.Add(dr)




        Next





        ds.Tables.Add(dt)
        ds.Tables(0).TableName = "Imagenes"

        Dim iDS As New dsImagenes
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

    Private Sub combo_conexion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_impresion.SelectedIndexChanged
        If combo_impresion.Text = "FACTURACION" Then
            dtp_fecha_faturacion.Enabled = True
        Else
            dtp_fecha_faturacion.Enabled = False
        End If
    End Sub

    Private Sub btn_quitar_elemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        If grilla_clientes.Rows.Count <> 0 Then
            grilla_clientes.Rows.Remove(grilla_clientes.CurrentRow)
            txt_desde.Focus()
        End If
    End Sub

    Private Sub btn_quitar_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.GotFocus
        btn_quitar_elemento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_elemento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.LostFocus
        btn_quitar_elemento.BackColor = Color.Transparent
    End Sub



    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        If txt_desde.Text = "" Then
            MsgBox("SELECCIONE LA LETRA INICIAL", 0 + 16, "ERROR")
            txt_desde.Focus()
            Exit Sub
        End If

        If txt_hasta.Text = "" Then
            MsgBox("SELECCIONE LA LETRA FINAL", 0 + 16, "ERROR")
            txt_hasta.Focus()
            Exit Sub
        End If


        lbl_mensaje.Visible = True
        Me.Enabled = False

        mostrar_malla_clientes()

        lbl_mensaje.Visible = False
        Me.Enabled = True

    End Sub
End Class