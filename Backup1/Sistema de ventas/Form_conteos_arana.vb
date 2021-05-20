Imports System.Drawing.Printing
Public Class Form_conteos_arana
    Dim mifechaconteo As String
    Dim mifechadesde As String
    Dim mifechahasta As String
    Dim MiPos As Integer
    Dim numero_lineas_total As Integer = 0

    Private Sub Form_conteos_arana_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_conteos_arana_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_conteos_arana_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        grilla_conteos.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)
        llenar_combo_familia()
        dtp_fecha_conteo.Value = dtp_fecha_conteo.Value.AddMonths(Val(-2))
        controles(True, False)
        actualizar_tabla()
        mostrar(0)
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub fecha()
        Dim mifecha1conteo As Date
        mifecha1conteo = dtp_fecha_conteo.Text
        mifechaconteo = mifecha1conteo.ToString("yyy-MM-dd")

        Dim mifecha1desde As Date
        mifecha1desde = dtp_desde.Text
        mifechadesde = mifecha1desde.ToString("yyy-MM-dd")

        Dim mifecha1hasta As Date
        mifecha1hasta = dtp_hasta.Text
        mifechahasta = mifecha1hasta.ToString("yyy-MM-dd")
    End Sub

    Sub mostrar_malla_conteos()
        Dim sub_familia_2 As String
        Dim sub_familia_2_anterior As String = ""
        Dim consulta As String
        grilla_conteos.Rows.Clear()
        grilla_conteos.Columns.Clear()
        grilla_conteos.Columns.Add("", "FECHA")
        grilla_conteos.Columns.Add("", "FAMILIA")
        grilla_conteos.Columns.Add("", "SUBFAMILIA")
        grilla_conteos.Columns.Add("", "SUBFAMILIA 2")
        grilla_conteos.Columns.Add("", "PRODUCTO")
        grilla_conteos.Columns.Add("", "DESCRIPCION")
        grilla_conteos.Columns.Add("", "NRO. TECNICO")
        grilla_conteos.Columns.Add("", "CANTIDAD")
        Dim VarSubFamiliaDos As String

        For u = 0 To grilla_sub_familias_dos.Rows.Count - 1
            VarSubFamiliaDos = grilla_sub_familias_dos.Rows(u).Cells(0).Value.ToString
            consulta = "select productos.fecha_conteo as 'FECHA', familia.nombre_familia as 'FAMILIA', subfamilia.nombre_subfamilia as 'SUBFAMILIA', subfamilia_dos.nombre_subfamilia as 'SUBFAMILIA 2', productos.cod_producto as 'PRODUCTO', productos.nombre as 'DESCRIPCION', productos.numero_tecnico as 'NRO. TECNICO', productos.cantidad as 'CANTIDAD' from productos, familia, subfamilia, subfamilia_dos where productos.familia=familia.codigo and productos.subfamilia=subfamilia.cod_auto and productos.subfamilia_dos=subfamilia_dos.cod_auto "
            consulta = consulta & " and productos.subfamilia_dos='" & (VarSubFamiliaDos) & "'"
            'consulta = consulta & " group by cod_producto LIMIT " & (txt_contar.Text) & ""
            'consulta = consulta & " LIMIT " & (txt_contar.Text) & ""

            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            SC2.Connection = conexion
            SC2.CommandText = consulta
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)


            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1

                    Dim MiFechaEmision As Date
                    Dim mifecha_emision2 As String
                    MiFechaEmision = DS2.Tables(DT2.TableName).Rows(i).Item("FECHA")
                    mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")

                    sub_familia_2 = DS2.Tables(DT2.TableName).Rows(i).Item("SUBFAMILIA 2")
                    If sub_familia_2 = sub_familia_2_anterior Then
                        'grilla_conteos.Rows.Add(mifecha_emision2, _
                        '                         DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                        '                          DS.Tables(DT.TableName).Rows(i).Item("SUBFAMILIA"), _
                        '                           DS.Tables(DT.TableName).Rows(i).Item("SUBFAMILIA 2"), _
                        '                            DS.Tables(DT.TableName).Rows(i).Item("PRODUCTO"), _
                        '                             DS.Tables(DT.TableName).Rows(i).Item("DESCRIPCION"), _
                        '                              DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                        '                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"))
                        grilla_conteos.Rows.Add(mifecha_emision2, _
                                                 "", _
                                                  "", _
                                                   "", _
                                                    DS2.Tables(DT2.TableName).Rows(i).Item("PRODUCTO"), _
                                                     DS2.Tables(DT2.TableName).Rows(i).Item("DESCRIPCION"), _
                                                      DS2.Tables(DT2.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                       DS2.Tables(DT2.TableName).Rows(i).Item("CANTIDAD"))
                    Else
                        grilla_conteos.Rows.Add(mifecha_emision2, _
                                                                   DS2.Tables(DT2.TableName).Rows(i).Item("FAMILIA"), _
                                                                    DS2.Tables(DT2.TableName).Rows(i).Item("SUBFAMILIA"), _
                                                                     DS2.Tables(DT2.TableName).Rows(i).Item("SUBFAMILIA 2"), _
                                                                      "", _
                                                                       "", _
                                                                        "", _
                                                                         "")
                        grilla_conteos.Rows.Add(mifecha_emision2, _
                                                 "", _
                                                  "", _
                                                   "", _
                                                    DS2.Tables(DT2.TableName).Rows(i).Item("PRODUCTO"), _
                                                     DS2.Tables(DT2.TableName).Rows(i).Item("DESCRIPCION"), _
                                                      DS2.Tables(DT2.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                       DS2.Tables(DT2.TableName).Rows(i).Item("CANTIDAD"))
                    End If
                    sub_familia_2_anterior = DS2.Tables(DT2.TableName).Rows(i).Item("SUBFAMILIA 2")
                Next
            End If
        Next

        If grilla_conteos.Rows.Count <> 0 Then
            If grilla_conteos.Columns(0).Width = 100 Then
                grilla_conteos.Columns(0).Width = 99
            Else
                grilla_conteos.Columns(0).Width = 100
            End If
            grilla_conteos.Columns(1).Width = 100
            grilla_conteos.Columns(2).Width = 100
            grilla_conteos.Columns(3).Width = 100
            grilla_conteos.Columns(4).Width = 100
            grilla_conteos.Columns(5).Width = 100
            grilla_conteos.Columns(6).Width = 100
            grilla_conteos.Columns(7).Width = 100
            grilla_conteos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_conteos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_conteos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_conteos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_conteos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_conteos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_conteos.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_conteos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
    End Sub


    Sub mostrar_malla_mas_rotados()

        Dim consulta As String
        Dim nombre_sf2 As String
        Dim cantidad_sf2 As String

        consulta = "SELECT count(detalle_boleta.cod_producto) as cantidad_total, subfamilia_dos.cod_auto as nsb2 FROM boleta, detalle_boleta, subfamilia_dos, productos where detalle_boleta.n_boleta=boleta.n_boleta and detalle_boleta.cod_producto=productos.cod_producto and productos.subfamilia_dos=subfamilia_dos.cod_auto and subfamilia_dos.fecha_conteo <= '" & (mifechaconteo) & "' and  fecha_venta >='" & (mifechadesde) & "' and fecha_venta <= '" & (mifechahasta) & "'"

        If Combo_familia.Text <> "-" Then
            consulta = consulta & "  and productos.familia='" & (txt_codigo_familia.Text) & "'"
        End If

        If Combo_subfamilia.Text <> "-" Then
            consulta = consulta & " and productos.subfamilia='" & (txt_codigo_subfamilia.Text) & "'"
        End If

        If Combo_subfamilia_2.Text <> "-" Then
            consulta = consulta & " and productos.subfamilia_dos='" & (txt_codigo_subfamilia_2.Text) & "'"
        End If

        consulta = consulta & "group by subfamilia_dos.nombre_subfamilia order by cantidad_total desc LIMIT " & (txt_contar.Text) & ""

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = consulta
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                nombre_sf2 = DS.Tables(DT.TableName).Rows(i).Item("nsb2")
                cantidad_sf2 = DS.Tables(DT.TableName).Rows(i).Item("cantidad_total")

                SC2.Connection = conexion
                SC2.CommandText = "INSERT INTO `conteos_temporal` (`subfamilia_dos`, cantidad) VALUES ('" & (nombre_sf2) & "','" & (cantidad_sf2) & "');"
                DA2.SelectCommand = SC2
                DA2.Fill(DT2)

                ' grilla_sub_familias_dos.Rows.Add(nombre_sf2)

            Next
        End If

        'FACTURAS
        consulta = "SELECT count(detalle_factura.cod_producto) as cantidad_total, subfamilia_dos.cod_auto as nsb2 FROM factura, detalle_factura, subfamilia_dos, productos where detalle_factura.n_factura=factura.n_factura and detalle_factura.cod_producto=productos.cod_producto and productos.subfamilia_dos=subfamilia_dos.cod_auto and subfamilia_dos.fecha_conteo <= '" & (mifechaconteo) & "'  and  fecha_venta >='" & (mifechadesde) & "' and fecha_venta <= '" & (mifechahasta) & "'"

        If Combo_familia.Text <> "-" Then
            consulta = consulta & "  and productos.familia='" & (txt_codigo_familia.Text) & "'"
        End If

        If Combo_subfamilia.Text <> "-" Then
            consulta = consulta & " and productos.subfamilia='" & (txt_codigo_subfamilia.Text) & "'"
        End If

        If Combo_subfamilia_2.Text <> "-" Then
            consulta = consulta & " and productos.subfamilia_dos='" & (txt_codigo_subfamilia_2.Text) & "'"
        End If

        consulta = consulta & "group by subfamilia_dos.nombre_subfamilia order by cantidad_total desc LIMIT " & (txt_contar.Text) & ""

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = consulta
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                nombre_sf2 = DS.Tables(DT.TableName).Rows(i).Item("nsb2")
                cantidad_sf2 = DS.Tables(DT.TableName).Rows(i).Item("cantidad_total")

                SC2.Connection = conexion
                SC2.CommandText = "INSERT INTO `conteos_temporal` (`subfamilia_dos`, cantidad) VALUES ('" & (nombre_sf2) & "','" & (cantidad_sf2) & "');"
                DA2.SelectCommand = SC2
                DA2.Fill(DT2)

                'grilla_sub_familias_dos.Rows.Add(nombre_sf2)

            Next
        End If

        'GUIAS
        consulta = "SELECT count(detalle_guia.cod_producto) as cantidad_total, subfamilia_dos.cod_auto as nsb2 FROM guia, detalle_guia, subfamilia_dos, productos where detalle_guia.n_guia=guia.n_guia and detalle_guia.cod_producto=productos.cod_producto and productos.subfamilia_dos=subfamilia_dos.cod_auto and subfamilia_dos.fecha_conteo <= '" & (mifechaconteo) & "'  and  fecha_venta >='" & (mifechadesde) & "' and fecha_venta <= '" & (mifechahasta) & "'"

        If Combo_familia.Text <> "-" Then
            consulta = consulta & "  and productos.familia='" & (txt_codigo_familia.Text) & "'"
        End If

        If Combo_subfamilia.Text <> "-" Then
            consulta = consulta & " and productos.subfamilia='" & (txt_codigo_subfamilia.Text) & "'"
        End If

        If Combo_subfamilia_2.Text <> "-" Then
            consulta = consulta & " and productos.subfamilia_dos='" & (txt_codigo_subfamilia_2.Text) & "'"
        End If

        consulta = consulta & "group by subfamilia_dos.nombre_subfamilia order by cantidad_total desc LIMIT " & (txt_contar.Text) & ""

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = consulta
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                nombre_sf2 = DS.Tables(DT.TableName).Rows(i).Item("nsb2")
                cantidad_sf2 = DS.Tables(DT.TableName).Rows(i).Item("cantidad_total")

                SC2.Connection = conexion
                SC2.CommandText = "INSERT INTO `conteos_temporal` (`subfamilia_dos`, cantidad) VALUES ('" & (nombre_sf2) & "','" & (cantidad_sf2) & "');"
                DA2.SelectCommand = SC2
                DA2.Fill(DT2)

                ' grilla_sub_familias_dos.Rows.Add(nombre_sf2)

            Next
        End If

        'NOTAS DE DEBITO
        consulta = "SELECT count(detalle_nota_debito.cod_producto) as cantidad_total, subfamilia_dos.cod_auto as nsb2 FROM nota_debito, detalle_nota_debito, subfamilia_dos, productos where detalle_nota_debito.n_nota_debito=nota_debito.n_nota_debito and detalle_nota_debito.cod_producto=productos.cod_producto and productos.subfamilia_dos=subfamilia_dos.cod_auto and subfamilia_dos.fecha_conteo <= '" & (mifechaconteo) & "'  and  fecha_venta >='" & (mifechadesde) & "' and fecha_venta <= '" & (mifechahasta) & "'"

        If Combo_familia.Text <> "-" Then
            consulta = consulta & "  and productos.familia='" & (txt_codigo_familia.Text) & "'"
        End If

        If Combo_subfamilia.Text <> "-" Then
            consulta = consulta & " and productos.subfamilia='" & (txt_codigo_subfamilia.Text) & "'"
        End If

        If Combo_subfamilia_2.Text <> "-" Then
            consulta = consulta & " and productos.subfamilia_dos='" & (txt_codigo_subfamilia_2.Text) & "'"
        End If

        consulta = consulta & "group by subfamilia_dos.nombre_subfamilia order by cantidad_total desc LIMIT " & (txt_contar.Text) & ""

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = consulta
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                nombre_sf2 = DS.Tables(DT.TableName).Rows(i).Item("nsb2")
                cantidad_sf2 = DS.Tables(DT.TableName).Rows(i).Item("cantidad_total")

                SC2.Connection = conexion
                SC2.CommandText = "INSERT INTO `conteos_temporal` (`subfamilia_dos`, cantidad) VALUES ('" & (nombre_sf2) & "','" & (cantidad_sf2) & "');"
                DA2.SelectCommand = SC2
                DA2.Fill(DT2)

                ' grilla_sub_familias_dos.Rows.Add(nombre_sf2)

            Next
        End If

        'NOTAS DE CREDITO
        consulta = "SELECT count(detalle_nota_credito.cod_producto) as cantidad_total, subfamilia_dos.cod_auto as nsb2 FROM nota_credito, detalle_nota_credito, subfamilia_dos, productos where detalle_nota_credito.n_nota_credito=nota_credito.n_nota_credito and detalle_nota_credito.cod_producto=productos.cod_producto and productos.subfamilia_dos=subfamilia_dos.cod_auto and subfamilia_dos.fecha_conteo <= '" & (mifechaconteo) & "'  and  fecha_venta >='" & (mifechadesde) & "' and fecha_venta <= '" & (mifechahasta) & "'"

        If Combo_familia.Text <> "-" Then
            consulta = consulta & "  and productos.familia='" & (txt_codigo_familia.Text) & "'"
        End If

        If Combo_subfamilia.Text <> "-" Then
            consulta = consulta & " and productos.subfamilia='" & (txt_codigo_subfamilia.Text) & "'"
        End If

        If Combo_subfamilia_2.Text <> "-" Then
            consulta = consulta & " and productos.subfamilia_dos='" & (txt_codigo_subfamilia_2.Text) & "'"
        End If

        consulta = consulta & "group by subfamilia_dos.nombre_subfamilia order by cantidad_total desc LIMIT " & (txt_contar.Text) & ""

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = consulta
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                nombre_sf2 = DS.Tables(DT.TableName).Rows(i).Item("nsb2")
                cantidad_sf2 = DS.Tables(DT.TableName).Rows(i).Item("cantidad_total")

                SC2.Connection = conexion
                SC2.CommandText = "INSERT INTO `conteos_temporal` (`subfamilia_dos`, cantidad) VALUES ('" & (nombre_sf2) & "','" & ("-" & cantidad_sf2) & "');"
                DA2.SelectCommand = SC2
                DA2.Fill(DT2)

                ' grilla_sub_familias_dos.Rows.Add(nombre_sf2)

            Next
        End If


        'VALE DE CAMBIO SALE
        consulta = "SELECT count(detalle_vale_cambio.cod_producto) as cantidad_total, subfamilia_dos.cod_auto as nsb2 FROM vale_cambio, detalle_vale_cambio, subfamilia_dos, productos where vale_cambio.nro_vale=detalle_vale_cambio.nro_vale and detalle_vale_cambio.movimiento='SALE' and detalle_vale_cambio.cod_producto=productos.cod_producto and productos.subfamilia_dos=subfamilia_dos.cod_auto and subfamilia_dos.fecha_conteo <= '" & (mifechaconteo) & "'  and  fecha >='" & (mifechadesde) & "' and fecha <= '" & (mifechahasta) & "'"

        If Combo_familia.Text <> "-" Then
            consulta = consulta & "  and productos.familia='" & (txt_codigo_familia.Text) & "'"
        End If

        If Combo_subfamilia.Text <> "-" Then
            consulta = consulta & " and productos.subfamilia='" & (txt_codigo_subfamilia.Text) & "'"
        End If

        If Combo_subfamilia_2.Text <> "-" Then
            consulta = consulta & " and productos.subfamilia_dos='" & (txt_codigo_subfamilia_2.Text) & "'"
        End If

        consulta = consulta & "group by subfamilia_dos.nombre_subfamilia order by cantidad_total desc LIMIT " & (txt_contar.Text) & ""

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = consulta
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                nombre_sf2 = DS.Tables(DT.TableName).Rows(i).Item("nsb2")
                cantidad_sf2 = DS.Tables(DT.TableName).Rows(i).Item("cantidad_total")

                SC2.Connection = conexion
                SC2.CommandText = "INSERT INTO `conteos_temporal` (`subfamilia_dos`, cantidad) VALUES ('" & (nombre_sf2) & "','" & (cantidad_sf2) & "');"
                DA2.SelectCommand = SC2
                DA2.Fill(DT2)

                ' grilla_sub_familias_dos.Rows.Add(nombre_sf2)

            Next
        End If


        'VALE DE CAMBIO ENTRA
        consulta = "SELECT count(detalle_vale_cambio.cod_producto) as cantidad_total, subfamilia_dos.cod_auto as nsb2 FROM vale_cambio, detalle_vale_cambio, subfamilia_dos, productos where vale_cambio.nro_vale=detalle_vale_cambio.nro_vale and detalle_vale_cambio.movimiento='ENTRA' and detalle_vale_cambio.cod_producto=productos.cod_producto and productos.subfamilia_dos=subfamilia_dos.cod_auto and subfamilia_dos.fecha_conteo <= '" & (mifechaconteo) & "'  and  fecha >='" & (mifechadesde) & "' and fecha <= '" & (mifechahasta) & "'"

        If Combo_familia.Text <> "-" Then
            consulta = consulta & "  and productos.familia='" & (txt_codigo_familia.Text) & "'"
        End If

        If Combo_subfamilia.Text <> "-" Then
            consulta = consulta & " and productos.subfamilia='" & (txt_codigo_subfamilia.Text) & "'"
        End If

        If Combo_subfamilia_2.Text <> "-" Then
            consulta = consulta & " and productos.subfamilia_dos='" & (txt_codigo_subfamilia_2.Text) & "'"
        End If

        consulta = consulta & "group by subfamilia_dos.nombre_subfamilia order by cantidad_total desc LIMIT " & (txt_contar.Text) & ""

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = consulta
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                nombre_sf2 = DS.Tables(DT.TableName).Rows(i).Item("nsb2")
                cantidad_sf2 = DS.Tables(DT.TableName).Rows(i).Item("cantidad_total")

                SC2.Connection = conexion
                SC2.CommandText = "INSERT INTO `conteos_temporal` (`subfamilia_dos`, cantidad) VALUES ('" & (nombre_sf2) & "','" & ("-" & cantidad_sf2) & "');"
                DA2.SelectCommand = SC2
                DA2.Fill(DT2)

                ' grilla_sub_familias_dos.Rows.Add(nombre_sf2)

            Next
        End If
    End Sub

    Sub mostrar_malla_negativos()

        Dim consulta As String

        SC.Connection = conexion
        SC.CommandText = "DELETE FROM `conteos_temporal` WHERE `cod_auto`<>'0';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        consulta = "SELECT subfamilia_dos FROM productos where productos.cantidad < '0' "

        If Combo_familia.Text <> "-" Then
            consulta = consulta & "  and productos.familia='" & (txt_codigo_familia.Text) & "'"
        End If

        If Combo_subfamilia.Text <> "-" Then
            consulta = consulta & " and productos.subfamilia='" & (txt_codigo_subfamilia.Text) & "'"
        End If

        If Combo_subfamilia_2.Text <> "-" Then
            consulta = consulta & " and productos.subfamilia_dos='" & (txt_codigo_subfamilia_2.Text) & "'"
        End If

        consulta = consulta & " group by productos.subfamilia_dos order by productos.subfamilia_dos desc LIMIT " & (txt_contar.Text) & ""

        grilla_sub_familias_dos.Rows.Clear()
        grilla_sub_familias_dos.Columns.Clear()
        grilla_sub_familias_dos.Columns.Add("", "SUBFAMILIA 2")

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = consulta
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                SC.Connection = conexion
                SC.CommandText = "INSERT INTO `conteos_temporal` (`subfamilia_dos`, cantidad) VALUES ('" & (DS.Tables(DT.TableName).Rows(i).Item("subfamilia_dos")) & "', '500000');"
                DA.SelectCommand = SC
                DA.Fill(DT)

                grilla_sub_familias_dos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("subfamilia_dos"))
            Next
        End If



    End Sub

    Sub malla_subfamilias_dos_rotadas()


        Dim consulta As String

        'SC.Connection = conexion
        'SC.CommandText = "DELETE FROM `conteos_temporal` WHERE `cod_auto`<>'0';"
        'DA.SelectCommand = SC
        'DA.Fill(DT)

        consulta = "SELECT subfamilia_dos, sum(cantidad) as cant FROM conteos_temporal group by subfamilia_dos order by cant desc LIMIT " & (txt_contar.Text) & " "

        grilla_sub_familias_dos.Rows.Clear()
        grilla_sub_familias_dos.Columns.Clear()
        grilla_sub_familias_dos.Columns.Add("", "SUBFAMILIA 2")

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = consulta
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                grilla_sub_familias_dos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("subfamilia_dos"))
            Next
        End If
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        If txt_contar.Text = "" Then
            txt_contar.Focus()
            MsgBox("CAMPO CONTAR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        fecha()
        mostrar_malla_negativos()
        mostrar_malla_mas_rotados()
        malla_subfamilias_dos_rotadas()
        mostrar_malla_conteos()
        calcular_totales()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        If grilla_conteos.Rows.Count = 0 Then
            Combo_familia.Focus()
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_conteos, save.FileName)
        End If

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub



    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)

        Dim xlApp As Object = CreateObject("Excel.Application")
        'crear una nueva hoja de calculo 
        Dim xlWB As Object = xlApp.WorkBooks.add
        Dim xlWS As Object = xlWB.WorkSheets(1)

        'exportamos los caracteres de las columnas 
        For c As Integer = 0 To grilla_conteos.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_conteos.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_conteos.RowCount - 1
            For c As Integer = 0 To grilla_conteos.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_conteos.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            grilla_conteos.Rows.Clear()
            grilla_conteos.Columns.Clear()
            txt_contar.Text = ""
        End If

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    'Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_limpiar.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_limpiar.BackColor = Color.Transparent
    'End Sub

    'Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_salir.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_salir.BackColor = Color.Transparent
    'End Sub

    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Sub calcular_totales()

        'Dim totalgrilla As Long

        'txt_contar.Text = grilla_conteos.Rows.Count

        'If txt_productos.Text = "" Then
        '    txt_productos.Text = "0"
        'End If
        ''Calcular el total general
        'txt_total.Text = 0
        'For i = 0 To grilla_libro_compras.Rows.Count - 1
        '    totalgrilla = Val(grilla_libro_compras.Rows(i).Cells(8).Value.ToString)
        '    txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        'Next

        'If txt_total.Text = "" Or txt_total.Text = "0" Then
        '    txt_total.Text = "0"
        'Else
        '    txt_total.Text = Format(Int(txt_total.Text), "###,###,###")
        'End If

    End Sub

    Sub llenar_combo_familia()
        Combo_familia.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion
        SC3.CommandText = "select * from familia order by nombre_familia"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        Combo_familia.Items.Add("-")
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_familia.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_familia"))
            Next
        End If
        'Combo_familia.SelectedItem = "SIN FAMILIA"
        Combo_familia.SelectedItem = "-"
        conexion.Close()
    End Sub

    Sub mostrar_codigo_familia()
        If Combo_familia.Text <> "-" Then
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            SC2.CommandText = "select * from familia where nombre_familia ='" & (Combo_familia.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                txt_codigo_familia.Text = DS2.Tables(DT2.TableName).Rows(0).Item("codigo")
            End If
            conexion.Close()
        Else
            txt_codigo_familia.Text = ""
        End If
    End Sub

    Sub llenar_combo_subfamilia()
        If Combo_familia.Text <> "-" Then
            conexion.Close()
            Combo_subfamilia.Items.Clear()
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion
            SC3.CommandText = "select * from subfamilia where codigo_familia='" & (txt_codigo_familia.Text) & "' order by nombre_subfamilia"
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            Combo_subfamilia.Items.Add("SIN SUB FAMILIA")
            If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                    Combo_subfamilia.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_subfamilia"))
                Next
            End If
            conexion.Close()
            Combo_subfamilia.Items.Add("-")
            Combo_subfamilia.SelectedItem = "-"
        Else
            Combo_subfamilia.Items.Clear()
            Combo_subfamilia.Items.Add("-")
            Combo_subfamilia.SelectedItem = "-"
        End If
    End Sub

    Sub mostrar_codigo_subfamilia()
        If Combo_subfamilia.Text <> "-" Then
            conexion.Close()
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion
            SC3.CommandText = "select * from subfamilia where nombre_subfamilia ='" & (Combo_subfamilia.Text) & "'"
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                txt_codigo_subfamilia.Text = DS3.Tables(DT3.TableName).Rows(0).Item("cod_auto")
            End If
            conexion.Close()
        Else
            txt_codigo_subfamilia.Text = ""
        End If
    End Sub

    Sub mostrar_codigo_subfamilia2()
        If Combo_subfamilia_2.Text <> "-" Then
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            SC2.CommandText = "select * from subfamilia_dos where nombre_subfamilia ='" & (Combo_subfamilia_2.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                txt_codigo_subfamilia_2.Text = DS2.Tables(DT2.TableName).Rows(0).Item("cod_auto")
            End If
            conexion.Close()
        Else
            txt_codigo_subfamilia_2.Text = ""
        End If
    End Sub

    Sub llenar_combo_subfamilia2()
        If Combo_subfamilia.Text <> "-" Then
            conexion.Close()
            Combo_subfamilia_2.Items.Clear()
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion
            SC3.CommandText = "select * from subfamilia_dos where codigo_subfamilia='" & (txt_codigo_subfamilia.Text) & "' order by nombre_subfamilia"
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            Combo_subfamilia_2.Items.Add("SIN SUB FAMILIA DOS")
            If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                    Combo_subfamilia_2.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_subfamilia"))
                Next
            End If
            conexion.Close()
            Combo_subfamilia_2.Items.Add("-")
            Combo_subfamilia_2.SelectedItem = "-"
        Else
            Combo_subfamilia_2.Items.Clear()
            Combo_subfamilia_2.Items.Add("-")
            Combo_subfamilia_2.SelectedItem = "-"
        End If
    End Sub

    Sub mostrar_subfamilia_dos()
        If txt_codigo_subfamilia_2.Text <> "" And txt_codigo_subfamilia_2.Text <> "-" Then
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()

            SC2.Connection = conexion
            SC2.CommandText = "select * from subfamilia_dos where cod_auto ='" & (txt_codigo_subfamilia_2.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)

            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                Combo_subfamilia_2.SelectedItem = DS2.Tables(DT2.TableName).Rows(0).Item("nombre_subfamilia")
            End If

            conexion.Close()
        End If
    End Sub

    Private Sub Combo_familia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_familia.SelectedIndexChanged
        mostrar_codigo_familia()
        llenar_combo_subfamilia()
        grilla_conteos.Rows.Clear()
        grilla_conteos.Columns.Clear()

        grilla_sub_familias_dos.Rows.Clear()
        grilla_sub_familias_dos.Columns.Clear()

        txt_contar.Text = ""
    End Sub

    Private Sub Combo_subfamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_subfamilia.SelectedIndexChanged
        mostrar_codigo_subfamilia()
        llenar_combo_subfamilia2()
        grilla_conteos.Rows.Clear()
        grilla_conteos.Columns.Clear()
        txt_contar.Text = ""
    End Sub

    Private Sub Combo_subfamilia_2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_subfamilia_2.SelectedIndexChanged
        mostrar_codigo_subfamilia2()
        grilla_conteos.Rows.Clear()
        grilla_conteos.Columns.Clear()
        grilla_sub_familias_dos.Rows.Clear()
        grilla_sub_familias_dos.Columns.Clear()
        grilla_sub_familias_dos.Rows.Clear()
        grilla_sub_familias_dos.Columns.Clear()
        txt_contar.Text = ""
    End Sub
    Private Function ReturnDataSet() As DataSet

        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ds As New DataSet

        dt.Columns.Add(New DataColumn("logo_empresa", GetType(Byte())))
        dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("fechas", GetType(String)))
        dt.Columns.Add(New DataColumn("titulo", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn1", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn2", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn3", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn4", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn5", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn6", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn7", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn8", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn9", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn10", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn11", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn12", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn13", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn14", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn15", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn16", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn17", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn18", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn19", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn20", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn21", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn22", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn23", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn24", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn25", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn26", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn27", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn28", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn29", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn30", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn31", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn32", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn33", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn34", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn35", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn36", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn37", GetType(String)))


        Dim VarFamilia As String
        Dim VarProducto As String
        Dim VarDescripcion As String
        Dim VarNumeroTecnico As String
        Dim VarCantidad As String

        For i = 0 To grilla_conteos.Rows.Count - 1
            'VarFecha = grilla_conteos.Rows(i).Cells(1).Value.ToString
            VarFamilia = grilla_conteos.Rows(i).Cells(2).Value.ToString
            'VarSubFamilia = grilla_conteos.Rows(i).Cells(3).Value.ToString
            'VarSubFamiliaDos = grilla_conteos.Rows(i).Cells(4).Value.ToString
            VarProducto = grilla_conteos.Rows(i).Cells(4).Value.ToString
            VarDescripcion = grilla_conteos.Rows(i).Cells(5).Value.ToString
            VarNumeroTecnico = grilla_conteos.Rows(i).Cells(6).Value.ToString
            VarCantidad = grilla_conteos.Rows(i).Cells(7).Value.ToString

            dr = dt.NewRow()

            Try
                dr("logo_empresa") = Imagen_reporte
            Catch
            End Try

            dr("nombre_empresa") = minombreempresa
            dr("giro_empresa") = migiroempresa
            dr("direccion_empresa") = midireccionempresa
            dr("comuna_empresa") = micomunaempresa
            dr("telefono_empresa") = mitelefonoempresa
            dr("correo_empresa") = micorreoempresa
            dr("rut_empresa") = mirutempresa

            Try
                dr("DataColumn1") = VarFamilia
            Catch
            End Try
            Try
                dr("DataColumn2") = VarProducto
            Catch
            End Try
            Try
                dr("DataColumn3") = VarDescripcion
            Catch
            End Try
            Try
                dr("DataColumn4") = VarNumeroTecnico
            Catch
            End Try
            Try
                dr("DataColumn5") = VarCantidad
            Catch
            End Try
            'Try
            '    dr("DataColumn6") = VarDescripcion
            'Catch
            'End Try
            'Try
            '    dr("DataColumn7") = VarCantidad
            'Catch
            'End Try

            dt.Rows.Add(dr)
        Next

        ds.Tables.Add(dt)
        ds.Tables(0).TableName = "DS_reporte"

        Dim iDS As New DS_reporte
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

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        If grilla_conteos.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_familia.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        PrintDialog1.Document = PrintDocument1

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument1.DefaultPageSettings.Landscape = False
            PrintDocument1.Print()

            Try
                PrintDocument1.DefaultPageSettings.Landscape = False
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
            Catch
            End Try
        End If



        lbl_mensaje.Visible = False
        Me.Enabled = True

    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha_conteo.ValueChanged
        grilla_conteos.Rows.Clear()
        grilla_conteos.Columns.Clear()
        grilla_sub_familias_dos.Rows.Clear()
        grilla_sub_familias_dos.Columns.Clear()
        txt_contar.Text = ""
    End Sub

    Private Sub Check_familias_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_familias.CheckedChanged
        If Check_familias.Checked = True Then
            grilla_conteos.Columns(1).Visible = True
        Else
            grilla_conteos.Columns(1).Visible = False
        End If
    End Sub

    Private Sub Check_subfamilias_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_subfamilias.CheckedChanged
        If Check_subfamilias.Checked = True Then
            grilla_conteos.Columns(2).Visible = True
        Else
            grilla_conteos.Columns(2).Visible = False
        End If
    End Sub

    Private Sub txt_contar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_contar.KeyPress
        grilla_conteos.Rows.Clear()
        grilla_conteos.Columns.Clear()
        grilla_sub_familias_dos.Rows.Clear()
        grilla_sub_familias_dos.Columns.Clear()
    End Sub

    Private Sub txt_contar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_contar.TextChanged

    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If grilla_conteos.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_familia.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        crear_numero_conteo()
        grabar_conteo()
        actualizar_tabla()
        mostrar(0)
        controles(True, False)

        PrintDialog1.Document = PrintDocument1

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument1.DefaultPageSettings.Landscape = False
            PrintDocument1.Print()

            Try
                PrintDocument1.DefaultPageSettings.Landscape = False
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
            Catch
            End Try
        End If

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub


    Sub grabar_conteo()

        Dim fecha_conteo As String
        Dim familia As String
        Dim subfamilia As String
        Dim subfamilia_dos As String
        Dim cod_producto As String
        Dim nombre_producto As String
        Dim numero_tecnico As String
        Dim cantidad As String

        For i = 0 To grilla_conteos.Rows.Count - 1
            fecha_conteo = grilla_conteos.Rows(i).Cells(0).Value.ToString
            familia = grilla_conteos.Rows(i).Cells(1).Value.ToString
            subfamilia = grilla_conteos.Rows(i).Cells(2).Value.ToString
            subfamilia_dos = grilla_conteos.Rows(i).Cells(3).Value.ToString
            cod_producto = grilla_conteos.Rows(i).Cells(4).Value.ToString
            nombre_producto = grilla_conteos.Rows(i).Cells(5).Value.ToString
            numero_tecnico = grilla_conteos.Rows(i).Cells(6).Value.ToString
            cantidad = grilla_conteos.Rows(i).Cells(7).Value.ToString

            Dim mifecha3 As Date
            mifecha3 = fecha_conteo
            fecha_conteo = mifecha3.ToString("yyy-MM-dd")

            Dim cod_auto_familia As Integer
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            SC2.CommandText = "select * from familia where nombre_familia ='" & (familia) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                cod_auto_familia = DS2.Tables(DT2.TableName).Rows(0).Item("codigo")
            End If

            Dim cod_auto_subfamilia As Integer
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            SC2.CommandText = "select * from subfamilia where nombre_subfamilia='" & (subfamilia) & "' and codigo_familia='" & (cod_auto_familia) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                cod_auto_subfamilia = DS2.Tables(DT2.TableName).Rows(0).Item("cod_auto")
            End If

            Dim cod_auto_subfamilia_dos As Integer
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            SC2.CommandText = "select * from subfamilia_dos where nombre_subfamilia='" & (subfamilia_dos) & "' and codigo_subfamilia='" & (cod_auto_subfamilia) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                cod_auto_subfamilia_dos = DS2.Tables(DT2.TableName).Rows(0).Item("cod_auto")
            End If


            SC.Connection = conexion
            SC.CommandText = "INSERT INTO `conteos` (`n_conteo`, `fecha`, `familia`, `subfamilia`, `subfamilia_dos`, `cod_producto`, `nombre_producto`, `numero_tecnico`, `cantidad`) VALUES ('" & (txt_nro_conteo.Text) & "', '" & (fecha_conteo) & "', '" & (familia) & "', '" & (subfamilia) & "', '" & (subfamilia_dos) & "', '" & (cod_producto) & "', '" & (nombre_producto) & "', '" & (numero_tecnico) & "', '" & (cantidad) & "');"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "UPDATE `subfamilia_dos` SET `fecha_conteo`='" & (Form_menu_principal.dtp_fecha.Text) & "' WHERE `nombre_subfamilia`='" & (subfamilia_dos) & "' and `cod_auto`='" & (cod_auto_subfamilia_dos) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next

    End Sub

    Sub crear_numero_conteo()
        Dim varnumdoc As Integer

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(cod_auto) as cod_auto from conteos"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
            End If
        Catch err As InvalidCastException
            txt_nro_conteo.Text = 1
            Exit Sub
        End Try
        conexion.Close()

        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select n_conteo from conteos where cod_auto='" & (varnumdoc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_conteo")
                txt_nro_conteo.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_nro_conteo.Text = 1
        End Try
        conexion.Close()
    End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        'GroupBox_familia.Enabled = b
        'GroupBox_fecha_historico.Enabled = b
        'GroupBox_contar.Enabled = b
        GroupBox1.Enabled = b
        GroupBox2.Enabled = a
        btn_nueva.Enabled = a
        btn_imprimir.Enabled = a
        btn_filtros.Enabled = b
        btn_mostrar.Enabled = b
        btn_exportar_excel.Enabled = a
        btn_guardar.Enabled = b
        btn_cancelar.Enabled = b
        btn_quitar_elemento.Enabled = b
    End Sub

    Private Sub btn_nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nueva.Click
        'controles(False, True)
        Form_nuevo_conteo.Show()
        Me.Enabled = False
        crear_numero_conteo()
        grilla_conteos.Rows.Clear()
        grilla_conteos.Columns.Clear()
        grilla_sub_familias_dos.Rows.Clear()
        grilla_sub_familias_dos.Columns.Clear()
        txt_contar.Text = ""
        txt_codigo_familia.Text = ""
        txt_codigo_subfamilia.Text = ""
        txt_codigo_subfamilia_2.Text = ""
    End Sub

    Private Sub btn_salir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        controles(True, False)
        grilla_conteos.Rows.Clear()
        grilla_conteos.Columns.Clear()
        grilla_sub_familias_dos.Rows.Clear()
        grilla_sub_familias_dos.Columns.Clear()
        controles(True, False)
        mostrar(MiPos)
    End Sub

    Private Sub btn_filtros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_filtros.Click
        Form_nuevo_conteo.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_quitar_elemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        Dim posicion_original As Integer
        Dim posicion As Integer
        Dim familia As String

        If grilla_conteos.Rows.Count <> 0 Then
            posicion_original = Me.grilla_conteos.CurrentCell.RowIndex
            posicion = Me.grilla_conteos.CurrentCell.RowIndex
        End If

        posicion = posicion + 1

        familia = grilla_conteos.Rows(posicion_original).Cells(1).Value.ToString

        If familia = "" Then
            Exit Sub
        End If

        familia = grilla_conteos.Rows(posicion).Cells(1).Value.ToString


        Do While familia = ""

            If grilla_conteos.Rows.Count > 0 Then
                grilla_conteos.Rows.Remove(grilla_conteos.Rows(posicion))
            End If

            ' posicion = posicion + 1

            familia = grilla_conteos.Rows(posicion).Cells(1).Value.ToString

        Loop

        If grilla_conteos.Rows.Count > 0 Then
            grilla_conteos.Rows.Remove(grilla_conteos.Rows(posicion_original))
        End If
        'End If
    End Sub

    Private Sub btn_primero_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_primero.Click
        MiPos = 0
        mostrar(0)
    End Sub

    Private Sub btn_anterior_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anterior.Click
        If MiPos >= 1 Then
            MiPos -= 1
            mostrar(MiPos)
        End If
    End Sub

    Private Sub btn_siguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.Click
        If MiPos < DT.Rows.Count - 1 Then
            MiPos += 1
            mostrar(MiPos)
        End If
    End Sub

    Private Sub btn_ultimo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ultimo.Click
        MiPos = DT.Rows.Count - 1
        mostrar(MiPos)
    End Sub

    Sub mostrar(ByVal i As Integer)
        Try
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nro_conteo.Text = DS.Tables(DT.TableName).Rows(i).Item("n_conteo")
                mostrar_malla_conteos_guardados()
            End If
        Catch
        End Try
    End Sub

    Sub actualizar_tabla()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from conteos order by cod_auto desc"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        conexion.Close()
    End Sub


    Sub mostrar_malla_conteos_guardados()
        Dim sub_familia_2 As String
        Dim sub_familia_2_anterior As String = ""

        grilla_conteos.Rows.Clear()
        grilla_conteos.Columns.Clear()
        grilla_conteos.Columns.Add("", "FECHA")
        grilla_conteos.Columns.Add("", "FAMILIA")
        grilla_conteos.Columns.Add("", "SUBFAMILIA")
        grilla_conteos.Columns.Add("", "SUBFAMILIA 2")
        grilla_conteos.Columns.Add("", "PRODUCTO")
        grilla_conteos.Columns.Add("", "DESCRIPCION")
        grilla_conteos.Columns.Add("", "NRO. TECNICO")
        grilla_conteos.Columns.Add("", "CANTIDAD")

        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        SC2.Connection = conexion
        SC2.CommandText = "select * from conteos where n_conteo ='" & (txt_nro_conteo.Text) & "'"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)
        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            For i = 0 To DS2.Tables(DT2.TableName).Rows.Count - 1
                Dim MiFechaEmision As Date
                Dim mifecha_emision2 As String
                MiFechaEmision = DS2.Tables(DT2.TableName).Rows(i).Item("fecha")
                mifecha_emision2 = MiFechaEmision.ToString("dd-MM-yyy")

                sub_familia_2 = DS2.Tables(DT2.TableName).Rows(i).Item("subfamilia_dos")
                If sub_familia_2 = sub_familia_2_anterior Then
                    'grilla_conteos.Rows.Add(mifecha_emision2, _
                    '                         DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                    '                          DS.Tables(DT.TableName).Rows(i).Item("SUBFAMILIA"), _
                    '                           DS.Tables(DT.TableName).Rows(i).Item("SUBFAMILIA 2"), _
                    '                            DS.Tables(DT.TableName).Rows(i).Item("PRODUCTO"), _
                    '                             DS.Tables(DT.TableName).Rows(i).Item("DESCRIPCION"), _
                    '                              DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                    '                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"))
                    grilla_conteos.Rows.Add(mifecha_emision2, _
                                             "", _
                                              "", _
                                               "", _
                                                DS2.Tables(DT2.TableName).Rows(i).Item("cod_producto"), _
                                                 DS2.Tables(DT2.TableName).Rows(i).Item("nombre_producto"), _
                                                  DS2.Tables(DT2.TableName).Rows(i).Item("numero_tecnico"), _
                                                   DS2.Tables(DT2.TableName).Rows(i).Item("cantidad"))
                Else
                    grilla_conteos.Rows.Add(mifecha_emision2, _
                                                               DS2.Tables(DT2.TableName).Rows(i).Item("familia"), _
                                                                DS2.Tables(DT2.TableName).Rows(i).Item("subfamilia"), _
                                                                 DS2.Tables(DT2.TableName).Rows(i).Item("subfamilia_dos"), _
                                                                  "", _
                                                                   "", _
                                                                    "", _
                                                                     "")
                    grilla_conteos.Rows.Add(mifecha_emision2, _
                                             "", _
                                              "", _
                                               "", _
                                                DS2.Tables(DT2.TableName).Rows(i).Item("cod_producto"), _
                                                 DS2.Tables(DT2.TableName).Rows(i).Item("nombre_producto"), _
                                                  DS2.Tables(DT2.TableName).Rows(i).Item("numero_tecnico"), _
                                                   DS2.Tables(DT2.TableName).Rows(i).Item("cantidad"))
                End If
                sub_familia_2_anterior = DS2.Tables(DT2.TableName).Rows(i).Item("subfamilia_dos")
            Next
        End If

        If grilla_conteos.Rows.Count <> 0 Then
            If grilla_conteos.Columns(0).Width = 100 Then
                grilla_conteos.Columns(0).Width = 99
            Else
                grilla_conteos.Columns(0).Width = 100
            End If
            grilla_conteos.Columns(1).Width = 100
            grilla_conteos.Columns(2).Width = 100
            grilla_conteos.Columns(3).Width = 100
            grilla_conteos.Columns(4).Width = 100
            grilla_conteos.Columns(5).Width = 100
            grilla_conteos.Columns(6).Width = 100
            grilla_conteos.Columns(7).Width = 100
            grilla_conteos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_conteos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_conteos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_conteos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_conteos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_conteos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_conteos.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_conteos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font_titulo As New Font("arial", 12, FontStyle.Regular)
        Dim Font_subtitulo As New Font("arial", 9, FontStyle.Regular)
        Dim Font_titulo_columna As New Font("verdana", 6.5, FontStyle.Bold)
        Dim Font_texto_impresion As New Font("verdana", 6.5, FontStyle.Regular)
        Dim Font_campos_superiores As New Font("verdana", 8, FontStyle.Regular)
        Dim Font_datos_empresa As New Font("verdana", 7, FontStyle.Regular)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = -30
        margen_superior = 0

        Try
            e.Graphics.DrawImage(Bytes_Imagen(Imagen_reporte), 560, 10, 260, 70)
        Catch
        End Try

        e.Graphics.DrawString(minombreempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 10)
        e.Graphics.DrawString(migiroempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 20)
        e.Graphics.DrawString(midireccionempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 30)
        e.Graphics.DrawString(micomunaempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 40)
        e.Graphics.DrawString(mitelefonoempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 50)
        e.Graphics.DrawString(mirutempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 60)

        Dim rect_titulo As New Rectangle(margen_izquierdo + 50, margen_superior + 85, margen_izquierdo + 810, margen_superior + 45)
        Dim rect_fecha As New Rectangle(margen_izquierdo + 50, margen_superior + 100, margen_izquierdo + 810, margen_superior + 60)

        e.Graphics.DrawString("CONTEO DE PRODUCTOS", Font_titulo, Brushes.Black, rect_titulo, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 118, margen_izquierdo + 865, margen_superior + 118)
        e.Graphics.DrawString(Form_menu_principal.lbl_fecha.Text, Font_subtitulo, Brushes.Gray, rect_fecha, stringFormat)

        'If txt_nombre_cliente.Text.Length > 23 Then
        '    txt_nombre_cliente.Text = txt_nombre_cliente.Text.Substring(0, 23)
        'End If

        e.Graphics.DrawString("FAMILIA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 50, margen_superior + 150)
        e.Graphics.DrawString("PRODUCTO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 140, margen_superior + 150)
        e.Graphics.DrawString("DESCRIPCION", Font_titulo_columna, Brushes.Black, margen_izquierdo + 220, margen_superior + 150)
        e.Graphics.DrawString("NRO. TECNICO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 380, margen_superior + 150)
        e.Graphics.DrawString("CANTIDAD", Font_titulo_columna, Brushes.Black, margen_izquierdo + 580, margen_superior + 150, format1)
        e.Graphics.DrawString("FISICO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 600, margen_superior + 150)
        e.Graphics.DrawString("OBSERVACIONES", Font_titulo_columna, Brushes.Black, margen_izquierdo + 690, margen_superior + 150)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 165, margen_izquierdo + 865, margen_superior + 165)

        Dim VarFamilia As String
        Dim VarProducto As String
        Dim VarDescripcion As String
        Dim VarNumeroTecnico As String
        Dim VarCantidad As String

        Dim numero_lineas As Integer = 0
        Dim multiplicador_lineas As Integer = 10

        For i = numero_lineas_total To grilla_conteos.Rows.Count - 1
            VarFamilia = grilla_conteos.Rows(i).Cells(2).Value.ToString
            VarProducto = grilla_conteos.Rows(i).Cells(4).Value.ToString
            VarDescripcion = grilla_conteos.Rows(i).Cells(5).Value.ToString
            VarNumeroTecnico = grilla_conteos.Rows(i).Cells(6).Value.ToString
            VarCantidad = grilla_conteos.Rows(i).Cells(7).Value.ToString

            If VarFamilia.Length > 10 Then
                VarFamilia = VarFamilia.Substring(0, 10)
            End If

            If VarDescripcion.Length > 20 Then
                VarDescripcion = VarDescripcion.Substring(0, 20)
            End If

            If VarNumeroTecnico.Length > 20 Then
                VarNumeroTecnico = VarNumeroTecnico.Substring(0, 20)
            End If

            e.Graphics.DrawString(VarFamilia, Font_texto_impresion, Brushes.Black, margen_izquierdo + 50, margen_superior + 170 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarProducto, Font_texto_impresion, Brushes.Black, margen_izquierdo + 140, margen_superior + 170 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarDescripcion, Font_texto_impresion, Brushes.Black, margen_izquierdo + 220, margen_superior + 170 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarNumeroTecnico, Font_texto_impresion, Brushes.Black, margen_izquierdo + 380, margen_superior + 170 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarCantidad, Font_texto_impresion, Brushes.Black, margen_izquierdo + 580, margen_superior + 170 + (numero_lineas * multiplicador_lineas), format1)
            '***************************************************************************************************************************************************

            numero_lineas = numero_lineas + 1
            numero_lineas_total = numero_lineas_total + 1

            If numero_lineas > 85 Then
                'Linea horizontal
                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 175 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 175 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************
                e.HasMorePages = True ' Todavia faltan mas paginas
                Exit Sub
            Else
                e.HasMorePages = False
            End If
        Next

        'Linea horizontal
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 175 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 175 + (numero_lineas * multiplicador_lineas))
        '***************************************************************************************************************************************************

        numero_lineas_total = 0
    End Sub
End Class