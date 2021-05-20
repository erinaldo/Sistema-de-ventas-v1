Imports System.IO
Imports System.Math
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class Form_comisiones
    Dim mifecha2 As String
    Dim mifecha4 As String

    Private Sub Form_comisiones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_comisiones_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    'se llama al sub fecha, fecha2, mostrar malla.
    Private Sub Form_comisiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fecha()
        mostrar_malla_boletas()
        mostrar_malla_facturas()
        mostrar_malla_guias()
        mostrar_malla_notas_de_credito()
        mostrar_malla_vale_entra()
        mostrar_malla_vale_sale()
        malla_vendedores()
        grabar_comision_detalle()
        mostrar_malla()
        calcular_totales()
        grilla_comisiones_indicador.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        grilla_comisiones_sin_indicador.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        cargar_logo()
        Timer_tiempo_espera.Start()
        Me.Width = 1024
        Me.Height = 728
        Centrar()
    End Sub

    Public Sub Centrar()
        ' Dim tamaño As Rectangle = My.Computer.Screen.Bounds
        Dim posicionX As Integer = (My.Computer.Screen.Bounds.Width - Me.Width) \ 2
        Dim posicionY As Integer = (My.Computer.Screen.Bounds.Height - Me.Height) \ 2
        Me.Location = New Point(posicionX, posicionY - 20)
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub

    Sub calcular_totales()
        Dim vartotal As String

        If tipo_usuario = "ADMINISTRADOR DEL SISTEMA" And mirutempresa = "87686300-6" Then
            '//Calcular el total de las facturas
            txt_total.Text = 0
            For i = 0 To grilla_comisiones_indicador.Rows.Count - 1
                vartotal = (grilla_comisiones_indicador.Rows(i).Cells(4).Value.ToString)
                vartotal = Trim(Replace(vartotal, ".", ""))
                txt_total.Text = Val(txt_total.Text) + Val(vartotal)
            Next
        End If

        If tipo_usuario <> "ADMINISTRADOR DEL SISTEMA" Then
            '//Calcular el total de las facturas
            txt_total.Text = 0
            For i = 0 To grilla_comisiones_sin_indicador.Rows.Count - 1
                vartotal = (grilla_comisiones_sin_indicador.Rows(i).Cells(4).Value.ToString)
                vartotal = Trim(Replace(vartotal, ".", ""))
                txt_total.Text = Val(txt_total.Text) + Val(vartotal)
            Next
        End If

        If mirutempresa <> "87686300-6" Then
            '//Calcular el total de las facturas
            txt_total.Text = 0
            For i = 0 To grilla_comisiones_sin_indicador.Rows.Count - 1
                vartotal = (grilla_comisiones_sin_indicador.Rows(i).Cells(4).Value.ToString)
                vartotal = Trim(Replace(vartotal, ".", ""))
                txt_total.Text = Val(txt_total.Text) + Val(vartotal)
            Next
        End If

        Dim iva_valor As String

        iva_valor = valor_iva / 100 + 1
        txt_neto.Text = Round(txt_total.Text / iva_valor)
        txt_iva.Text = Round((txt_neto.Text) * valor_iva / 100)

        If txt_neto.Text = "" Or txt_neto.Text = "0" Then
            txt_neto.Text = "0"
        Else
            txt_neto.Text = Format(Int(txt_neto.Text), "###,###,###")
        End If
        If txt_iva.Text = "" Or txt_iva.Text = "0" Then
            txt_iva.Text = "0"
        Else
            txt_iva.Text = Format(Int(txt_iva.Text), "###,###,###")
        End If
        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total.Text = "0"
        Else
            txt_total.Text = Format(Int(txt_total.Text), "###,###,###")
        End If
    End Sub

    Sub mostrar_malla()
        If tipo_usuario = "ADMINISTRADOR DEL SISTEMA" And mirutempresa = "87686300-6" Then
            grilla_comisiones_indicador.Visible = True
            grilla_comisiones_sin_indicador.Visible = False
            grilla_comisiones_indicador.Rows.Clear()

            conexion.Close()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select rut_usuario as RUT, nombre_usuario NOMBRE, SUM(total_comision) AS TOTAL, SUM(cantidad_doc) AS 'CANT. DOC.'  from comision where rut_usuario <> 'SISTEMA' and usuario_responsable='" & (miusuario) & "' GROUP BY rut_usuario ORDER BY nombre_usuario asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim iva As String
                    Dim neto As String
                    Dim iva_valor As String
                    Dim total As String
                    Dim total_millar As String
                    Dim total_doc As String

                    total = DS.Tables(DT.TableName).Rows(i).Item("TOTAL")
                    total_millar = DS.Tables(DT.TableName).Rows(i).Item("TOTAL")
                    iva_valor = valor_iva / 100 + 1
                    neto = Round((DS.Tables(DT.TableName).Rows(i).Item("TOTAL") / iva_valor))
                    iva = Round(((neto) * valor_iva / 100))
                    total_doc = DS.Tables(DT.TableName).Rows(i).Item("CANT. DOC.")

                    Dim indicador As Double

                    indicador = total * total_doc
                    indicador = indicador / 10400000
                    Round(indicador, 2)

                    If neto = "" Or neto = "0" Then
                        neto = "0"
                    Else
                        neto = Format(Int(neto), "###,###,###")
                    End If

                    If iva = "" Or iva = "0" Then
                        iva = "0"
                    Else
                        iva = Format(Int(iva), "###,###,###")
                    End If

                    If total_millar = "" Or total_millar = "0" Then
                        total_millar = "0"
                    Else
                        total_millar = Format(Int(total_millar), "###,###,###")
                    End If

                    grilla_comisiones_indicador.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("RUT"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), (neto), (iva), total_millar, total_doc, Round(indicador, 2), total)
                Next
                conexion.Close()
            End If

            grilla_comisiones_indicador.Columns(0).Visible = False
            grilla_comisiones_indicador.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_comisiones_indicador.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_comisiones_indicador.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_comisiones_indicador.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_comisiones_indicador.Columns(5).SortMode = True
            grilla_comisiones_indicador.Sort(grilla_comisiones_indicador.Columns(6), System.ComponentModel.ListSortDirection.Descending)

            For i = 0 To grilla_comisiones_indicador.Rows.Count - 1
                If miusuario = grilla_comisiones_indicador.Rows(i).Cells(0).Value.ToString Then
                    grilla_comisiones_indicador.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
                End If
            Next

            If dtp_desde.Text = dtp_hasta.Text Then
                Dim indicador_color As Double
                For i = 0 To grilla_comisiones_indicador.Rows.Count - 1
                    indicador_color = grilla_comisiones_indicador.Rows(i).Cells(6).Value.ToString

                    If indicador_color < 1 Then
                        grilla_comisiones_indicador.Rows(i).DefaultCellStyle.BackColor = Color.White
                    End If

                    If indicador_color < (2) And indicador_color >= (1.0) Then
                        grilla_comisiones_indicador.Rows(i).DefaultCellStyle.BackColor = Color.Orange
                    End If

                    If indicador_color < 3 And indicador_color >= 2 Then
                        grilla_comisiones_indicador.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                    End If

                    If indicador_color >= 3 Then
                        grilla_comisiones_indicador.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                    End If

                    If indicador_color < 1 Then
                        grilla_comisiones_indicador.Rows(i).DefaultCellStyle.BackColor = Color.White
                    End If

                    If indicador_color < (2) And indicador_color >= (1) Then
                        grilla_comisiones_indicador.Rows(i).DefaultCellStyle.BackColor = Color.Orange
                    End If

                    If indicador_color < 3 And indicador_color >= 2 Then
                        grilla_comisiones_indicador.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                    End If

                    If indicador_color >= 3 Then
                        grilla_comisiones_indicador.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                    End If
                Next
                Exit Sub
            End If
        End If

        If tipo_usuario <> "ADMINISTRADOR DEL SISTEMA" Then
            grilla_comisiones_indicador.Visible = False
            grilla_comisiones_sin_indicador.Visible = True
            grilla_comisiones_sin_indicador.Rows.Clear()
            conexion.Close()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select rut_usuario as RUT, nombre_usuario NOMBRE, SUM(total_comision) AS TOTAL from comision where rut_usuario <> 'SISTEMA' and usuario_responsable='" & (miusuario) & "' GROUP BY rut_usuario ORDER BY nombre_usuario asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim iva As String
                    Dim neto As String
                    Dim iva_valor As String
                    Dim total As String
                    Dim total_millar As String
                    total = DS.Tables(DT.TableName).Rows(i).Item("TOTAL")
                    total_millar = DS.Tables(DT.TableName).Rows(i).Item("TOTAL")
                    iva_valor = valor_iva / 100 + 1
                    neto = Round((DS.Tables(DT.TableName).Rows(i).Item("TOTAL") / iva_valor))
                    iva = Round(((neto) * valor_iva / 100))
                    If neto = "" Or neto = "0" Then
                        neto = "0"
                    Else
                        neto = Format(Int(neto), "###,###,###")
                    End If
                    If iva = "" Or iva = "0" Then
                        iva = "0"
                    Else
                        iva = Format(Int(iva), "###,###,###")
                    End If
                    If total_millar = "" Or total_millar = "0" Then
                        total_millar = "0"
                    Else
                        total_millar = Format(Int(total_millar), "###,###,###")
                    End If
                    grilla_comisiones_sin_indicador.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("RUT"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), (neto), (iva), total_millar)
                Next
                conexion.Close()
            End If

            grilla_comisiones_sin_indicador.Columns(0).Visible = False
            grilla_comisiones_sin_indicador.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_comisiones_sin_indicador.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_comisiones_sin_indicador.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

        If mirutempresa <> "87686300-6" Then
            grilla_comisiones_indicador.Visible = False
            grilla_comisiones_sin_indicador.Visible = True
            grilla_comisiones_sin_indicador.Rows.Clear()
            conexion.Close()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select rut_usuario as RUT, nombre_usuario NOMBRE, SUM(total_comision) AS TOTAL from comision where rut_usuario <> 'SISTEMA' and usuario_responsable='" & (miusuario) & "' GROUP BY rut_usuario ORDER BY nombre_usuario asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim iva As String
                    Dim neto As String
                    Dim iva_valor As String
                    Dim total As String
                    Dim total_millar As String
                    total = DS.Tables(DT.TableName).Rows(i).Item("TOTAL")
                    total_millar = DS.Tables(DT.TableName).Rows(i).Item("TOTAL")
                    iva_valor = valor_iva / 100 + 1
                    neto = Round((DS.Tables(DT.TableName).Rows(i).Item("TOTAL") / iva_valor))
                    iva = Round(((neto) * valor_iva / 100))

                    If neto = "" Or neto = "0" Then
                        neto = "0"
                    Else
                        neto = Format(Int(neto), "###,###,###")
                    End If

                    If iva = "" Or iva = "0" Then
                        iva = "0"
                    Else
                        iva = Format(Int(iva), "###,###,###")
                    End If

                    If total_millar = "" Or total_millar = "0" Then
                        total_millar = "0"
                    Else
                        total_millar = Format(Int(total_millar), "###,###,###")
                    End If

                    grilla_comisiones_sin_indicador.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("RUT"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), (neto), (iva), total_millar)
                Next
                conexion.Close()
            End If
            grilla_comisiones_sin_indicador.Columns(0).Visible = False
            grilla_comisiones_sin_indicador.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_comisiones_sin_indicador.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_comisiones_sin_indicador.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
    End Sub

    Sub mostrar_malla_boletas()
        grilla_comisiones_boletas.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select boleta.usuario_responsable as RUT, usuarios.nombre_usuario NOMBRE, SUM(comision) AS TOTAL, count(n_boleta) AS 'CANT. DOC.' from boleta , USUARIOS where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and boleta.estado <> 'ANULADA' AND usuarios.rut_usuario =boleta.usuario_responsable GROUP BY boleta.usuario_responsable ORDER BY NOMBRE_USUARIO"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_comisiones_boletas.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("RUT"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("TOTAL"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("CANT. DOC."))
            Next
            conexion.Close()
        End If
    End Sub

    Sub mostrar_malla_guias()
        grilla_comisiones_guias.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select guia.usuario_responsable as RUT, usuarios.nombre_usuario NOMBRE, SUM(total) AS TOTAL, count(n_GUIA) AS 'CANT. DOC.'  from guia , USUARIOS where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and guia.estado <> 'ANULADA' AND CONDICIONES <> 'TRASLADO' AND usuarios.rut_usuario =guia.usuario_responsable GROUP BY guia.usuario_responsable ORDER BY NOMBRE_USUARIO"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_comisiones_guias.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("RUT"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("TOTAL"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("CANT. DOC."))
            Next
            conexion.Close()
        End If
    End Sub

    Sub mostrar_malla_notas_de_credito()
        grilla_comisiones_nota_de_credito.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select nota_credito.vendedor as RUT, usuarios.nombre_usuario NOMBRE, SUM(total) AS TOTAL from nota_credito , USUARIOS where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and nota_credito.estado <> 'ANULADA' AND usuarios.rut_usuario =nota_credito.vendedor GROUP BY nota_credito.vendedor ORDER BY NOMBRE_USUARIO"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_comisiones_nota_de_credito.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("RUT"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("TOTAL"), 0)
            Next
            conexion.Close()
        End If
    End Sub

    Sub malla_vendedores()
        conexion.Close()
        Dim DT3 As New DataTable
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion
        SC3.CommandText = "select rut_usuario, nombre_usuario from usuarios where area_usuario LIKE '%VENTAS%'"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        grilla_vendedores.DataSource = DS3.Tables(DT3.TableName)
        conexion.Close()
    End Sub

    Sub mostrar_malla_facturas()
        grilla_comisiones_facturas.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select factura.usuario_responsable as RUT, usuarios.nombre_usuario NOMBRE, SUM(comision) AS TOTAL, count(n_FACTURA) AS 'CANT. DOC.'  from factura , USUARIOS where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and factura.estado <> 'ANULADA' AND usuarios.rut_usuario =factura.usuario_responsable GROUP BY factura.usuario_responsable ORDER BY (0 + cod_auto)"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_comisiones_facturas.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("RUT"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("TOTAL"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("CANT. DOC."))
            Next
            conexion.Close()
        End If
    End Sub

    Sub mostrar_malla_vale_entra()
        grilla_comisiones_vale_entra.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select vale_cambio.vendedor_entra as RUT, usuarios.nombre_usuario NOMBRE, SUM(total_negativo) AS TOTAL, count(nro_vale) AS 'CANT. DOC.'  from vale_cambio , USUARIOS where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and vale_cambio.estado <> 'ANULADA' AND usuarios.rut_usuario =vale_cambio.vendedor_entra GROUP BY vale_cambio.vendedor_entra"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_comisiones_vale_entra.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("RUT"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("TOTAL"), _
                                                         0)
            Next
            conexion.Close()
        End If
    End Sub

    Sub mostrar_malla_vale_sale()
        grilla_comisiones_vale_sale.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select vale_cambio.usuario_responsable as RUT, usuarios.nombre_usuario NOMBRE, SUM(total_positivo) AS TOTAL, count(nro_vale) AS 'CANT. DOC.'  from vale_cambio , USUARIOS where fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' and vale_cambio.estado <> 'ANULADA' AND usuarios.rut_usuario =vale_cambio.usuario_responsable GROUP BY vale_cambio.usuario_responsable"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_comisiones_vale_sale.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("RUT"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("NOMBRE"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("TOTAL"), _
                                                        0)
            Next
            conexion.Close()
        End If
    End Sub

    'se llama al sub fecha, fecha2, mostrar malla.
    Private Sub dtp2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        grilla_comisiones_indicador.Rows.Clear()
        grilla_comisiones_boletas.Rows.Clear()
        grilla_comisiones_facturas.Rows.Clear()
        grilla_comisiones_guias.Rows.Clear()
        grilla_comisiones_nota_de_credito.Rows.Clear()
        txt_iva.Text = "0"
        txt_neto.Text = "0"
        txt_total.Text = "0"
    End Sub

    'se llama al sub fecha, fecha2, mostrar malla.
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mostrar_malla()
    End Sub

    'se llama al sub fecha, fecha2, mostrar malla.
    Private Sub dtp1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        grilla_comisiones_indicador.Rows.Clear()
        grilla_comisiones_boletas.Rows.Clear()
        grilla_comisiones_facturas.Rows.Clear()
        grilla_comisiones_guias.Rows.Clear()
        grilla_comisiones_nota_de_credito.Rows.Clear()
        txt_iva.Text = "0"
        txt_neto.Text = "0"
        txt_total.Text = "0"
    End Sub

    'salir de la pantalla.
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Form_menu_principal.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub

    Sub grabar_comision_detalle()
        Dim Varvendedor As String
        Dim Vartotal As Integer
        Dim Varnombre As String
        Dim cantidad_doc As String

        SC.Connection = conexion
        SC.CommandText = "delete from comision WHERE usuario_responsable='" & (miusuario) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        For i = 0 To grilla_vendedores.Rows.Count - 1
            Varvendedor = grilla_vendedores.Rows(i).Cells(0).Value.ToString
            Varnombre = grilla_vendedores.Rows(i).Cells(1).Value.ToString
            Vartotal = "0"
            cantidad_doc = "0"
            SC.Connection = conexion
            SC.CommandText = "insert into comision (rut_usuario ,nombre_usuario, total_comision, cantidad_doc, usuario_responsable) values('" & (Varvendedor) & "','" & (Varnombre) & "'," & (Vartotal) & ",'" & (cantidad_doc) & "','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next

        For i = 0 To grilla_comisiones_boletas.Rows.Count - 1
            Varvendedor = grilla_comisiones_boletas.Rows(i).Cells(0).Value.ToString
            Varnombre = grilla_comisiones_boletas.Rows(i).Cells(1).Value.ToString
            Vartotal = grilla_comisiones_boletas.Rows(i).Cells(2).Value.ToString
            cantidad_doc = grilla_comisiones_boletas.Rows(i).Cells(3).Value.ToString
            SC.Connection = conexion
            SC.CommandText = "insert into comision (rut_usuario ,nombre_usuario, total_comision, cantidad_doc, usuario_responsable) values('" & (Varvendedor) & "','" & (Varnombre) & "'," & (Vartotal) & ",'" & (cantidad_doc) & "','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next

        For i = 0 To grilla_comisiones_facturas.Rows.Count - 1
            Varvendedor = grilla_comisiones_facturas.Rows(i).Cells(0).Value.ToString
            Varnombre = grilla_comisiones_facturas.Rows(i).Cells(1).Value.ToString
            Vartotal = grilla_comisiones_facturas.Rows(i).Cells(2).Value.ToString
            cantidad_doc = grilla_comisiones_facturas.Rows(i).Cells(3).Value.ToString
            SC.Connection = conexion
            SC.CommandText = "insert into comision (rut_usuario ,nombre_usuario, total_comision, cantidad_doc, usuario_responsable) values('" & (Varvendedor) & "','" & (Varnombre) & "'," & (Vartotal) & ",'" & (cantidad_doc) & "','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next

        For i = 0 To grilla_comisiones_guias.Rows.Count - 1
            Varvendedor = grilla_comisiones_guias.Rows(i).Cells(0).Value.ToString
            Varnombre = grilla_comisiones_guias.Rows(i).Cells(1).Value.ToString
            Vartotal = grilla_comisiones_guias.Rows(i).Cells(2).Value.ToString
            cantidad_doc = grilla_comisiones_guias.Rows(i).Cells(3).Value.ToString
            SC.Connection = conexion
            SC.CommandText = "insert into comision (rut_usuario ,nombre_usuario, total_comision, cantidad_doc, usuario_responsable) values('" & (Varvendedor) & "','" & (Varnombre) & "'," & (Vartotal) & ",'" & (cantidad_doc) & "','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next

        For i = 0 To grilla_comisiones_nota_de_credito.Rows.Count - 1
            Varvendedor = grilla_comisiones_nota_de_credito.Rows(i).Cells(0).Value.ToString
            Varnombre = grilla_comisiones_nota_de_credito.Rows(i).Cells(1).Value.ToString
            Vartotal = grilla_comisiones_nota_de_credito.Rows(i).Cells(2).Value.ToString
            cantidad_doc = grilla_comisiones_nota_de_credito.Rows(i).Cells(3).Value.ToString
            SC.Connection = conexion
            SC.CommandText = "insert into comision (rut_usuario ,nombre_usuario, total_comision, cantidad_doc, usuario_responsable) values('" & (Varvendedor) & "','" & (Varnombre) & "'," & ("-" & Vartotal) & ",'" & (cantidad_doc) & "','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next

        For i = 0 To grilla_comisiones_vale_entra.Rows.Count - 1
            Varvendedor = grilla_comisiones_vale_entra.Rows(i).Cells(0).Value.ToString
            Varnombre = grilla_comisiones_vale_entra.Rows(i).Cells(1).Value.ToString
            Vartotal = grilla_comisiones_vale_entra.Rows(i).Cells(2).Value.ToString
            cantidad_doc = grilla_comisiones_vale_entra.Rows(i).Cells(3).Value.ToString
            SC.Connection = conexion
            SC.CommandText = "insert into comision (rut_usuario ,nombre_usuario, total_comision, cantidad_doc, usuario_responsable) values('" & (Varvendedor) & "','" & (Varnombre) & "'," & ("-" & Vartotal) & ",'" & (cantidad_doc) & "','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next

        For i = 0 To grilla_comisiones_vale_sale.Rows.Count - 1
            Varvendedor = grilla_comisiones_vale_sale.Rows(i).Cells(0).Value.ToString
            Varnombre = grilla_comisiones_vale_sale.Rows(i).Cells(1).Value.ToString
            Vartotal = grilla_comisiones_vale_sale.Rows(i).Cells(2).Value.ToString
            cantidad_doc = grilla_comisiones_vale_sale.Rows(i).Cells(3).Value.ToString
            SC.Connection = conexion
            SC.CommandText = "insert into comision (rut_usuario ,nombre_usuario, total_comision, cantidad_doc, usuario_responsable) values('" & (Varvendedor) & "','" & (Varnombre) & "'," & (Vartotal) & ",'" & (cantidad_doc) & "','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next
    End Sub

    'limpia la pantalla.
    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        If grilla_comisiones_indicador.Rows.Count = 0 Then
            ' MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            dtp_desde.Focus()
            Exit Sub
        End If
        grilla_comisiones_sin_indicador.Rows.Clear()
        grilla_comisiones_indicador.Rows.Clear()
        grilla_comisiones_indicador.Rows.Clear()
        grilla_comisiones_boletas.Rows.Clear()
        grilla_comisiones_facturas.Rows.Clear()
        grilla_comisiones_guias.Rows.Clear()
        grilla_comisiones_nota_de_credito.Rows.Clear()
        txt_iva.Text = "0"
        txt_neto.Text = "0"
        txt_total.Text = "0"
        dtp_desde.Text = Form_menu_principal.dtp_fecha.Text
        dtp_hasta.Text = Form_menu_principal.dtp_fecha.Text
    End Sub

    Private Sub btn_grabar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.GotFocus
        btn_grabar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_grabar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_grabar.LostFocus
        btn_grabar.BackColor = Color.WhiteSmoke
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

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        If tipo_usuario = "ADMINISTRADOR DEL SISTEMA" And mirutempresa = "87686300-6" Then
            If grilla_comisiones_indicador.Rows.Count = 0 Then
                MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                dtp_desde.Focus()
                Exit Sub
            End If

            lbl_mensaje.Visible = True
            Me.Enabled = False
            Dim save As New SaveFileDialog
            save.Filter = "Archivo Excel | *.xlsx"
            If save.ShowDialog = Windows.Forms.DialogResult.OK Then
                Exportar_Excel(Me.grilla_comisiones_indicador, save.FileName)
            End If
            lbl_mensaje.Visible = False
            Me.Enabled = True
            Exit Sub
        End If

        If tipo_usuario <> "ADMINISTRADOR DEL SISTEMA" Then
            If grilla_comisiones_sin_indicador.Rows.Count = 0 Then
                MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                dtp_desde.Focus()
                Exit Sub
            End If

            lbl_mensaje.Visible = True
            Me.Enabled = False
            Dim save As New SaveFileDialog
            save.Filter = "Archivo Excel | *.xlsx"
            If save.ShowDialog = Windows.Forms.DialogResult.OK Then
                Exportar_Excel(Me.grilla_comisiones_sin_indicador, save.FileName)
            End If
            lbl_mensaje.Visible = False
            Me.Enabled = True
            Exit Sub
        End If

        If mirutempresa <> "87686300-6" Then
            If grilla_comisiones_sin_indicador.Rows.Count = 0 Then
                MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                dtp_desde.Focus()
                Exit Sub
            End If

            lbl_mensaje.Visible = True
            Me.Enabled = False
            Dim save As New SaveFileDialog
            save.Filter = "Archivo Excel | *.xlsx"
            If save.ShowDialog = Windows.Forms.DialogResult.OK Then
                Exportar_Excel(Me.grilla_comisiones_sin_indicador, save.FileName)
            End If
            lbl_mensaje.Visible = False
            Me.Enabled = True
            Exit Sub
        End If
    End Sub

    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)
        If tipo_usuario = "ADMINISTRADOR DEL SISTEMA" And mirutempresa = "87686300-6" Then
            Dim xlApp As Object = CreateObject("Excel.Application")
            'crear una nueva hoja de calculo 
            Dim xlWB As Object = xlApp.WorkBooks.add
            Dim xlWS As Object = xlWB.WorkSheets(1)

            'exportamos los caracteres de las columnas 
            For c As Integer = 0 To grilla_comisiones_indicador.Columns.Count - 1
                xlWS.cells(1, c + 1).value = grilla_comisiones_indicador.Columns(c).HeaderText
            Next
            'exportamos las cabeceras de columnas 
            For r As Integer = 0 To grilla_comisiones_indicador.RowCount - 1
                For c As Integer = 0 To grilla_comisiones_indicador.Columns.Count - 1
                    xlWS.cells(r + 2, c + 1).value = grilla_comisiones_indicador.Item(c, r).Value
                Next
            Next
            'guardamos la hoja de calculo en la ruta especificada 
            xlWB.saveas(pth)
            xlWS = Nothing
            xlWB = Nothing
            xlApp.quit()
            xlApp = Nothing
            Exit Sub
        End If

        If tipo_usuario <> "ADMINISTRADOR DEL SISTEMA" Then
            Dim xlApp As Object = CreateObject("Excel.Application")
            'crear una nueva hoja de calculo 
            Dim xlWB As Object = xlApp.WorkBooks.add
            Dim xlWS As Object = xlWB.WorkSheets(1)

            'exportamos los caracteres de las columnas 
            For c As Integer = 0 To grilla_comisiones_sin_indicador.Columns.Count - 1
                xlWS.cells(1, c + 1).value = grilla_comisiones_sin_indicador.Columns(c).HeaderText
            Next
            'exportamos las cabeceras de columnas 
            For r As Integer = 0 To grilla_comisiones_sin_indicador.RowCount - 1
                For c As Integer = 0 To grilla_comisiones_sin_indicador.Columns.Count - 1
                    xlWS.cells(r + 2, c + 1).value = grilla_comisiones_sin_indicador.Item(c, r).Value
                Next
            Next
            'guardamos la hoja de calculo en la ruta especificada 
            xlWB.saveas(pth)
            xlWS = Nothing
            xlWB = Nothing
            xlApp.quit()
            xlApp = Nothing
            Exit Sub
        End If

        If mirutempresa <> "87686300-6" Then
            Dim xlApp As Object = CreateObject("Excel.Application")
            'crear una nueva hoja de calculo 
            Dim xlWB As Object = xlApp.WorkBooks.add
            Dim xlWS As Object = xlWB.WorkSheets(1)

            'exportamos los caracteres de las columnas 
            For c As Integer = 0 To grilla_comisiones_sin_indicador.Columns.Count - 1
                xlWS.cells(1, c + 1).value = grilla_comisiones_sin_indicador.Columns(c).HeaderText
            Next
            'exportamos las cabeceras de columnas 
            For r As Integer = 0 To grilla_comisiones_sin_indicador.RowCount - 1
                For c As Integer = 0 To grilla_comisiones_sin_indicador.Columns.Count - 1
                    xlWS.cells(r + 2, c + 1).value = grilla_comisiones_sin_indicador.Item(c, r).Value
                Next
            Next
            'guardamos la hoja de calculo en la ruta especificada 
            xlWB.saveas(pth)
            xlWS = Nothing
            xlWB = Nothing
            xlApp.quit()
            xlApp = Nothing
            Exit Sub
        End If
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        fecha()
        mostrar_malla_boletas()
        mostrar_malla_facturas()
        mostrar_malla_guias()
        mostrar_malla_notas_de_credito()
        mostrar_malla_vale_entra()
        mostrar_malla_vale_sale()
        malla_vendedores()
        grabar_comision_detalle()
        mostrar_malla()
        calcular_totales()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Structure LASTINPUTINFO
        Public cbSize As UInteger
        Public dwTime As UInteger
    End Structure

    <DllImport("User32.dll")> _
    Private Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    End Function

    Public Function GetInactiveTime() As Nullable(Of TimeSpan)
        Dim info As LASTINPUTINFO = New LASTINPUTINFO
        info.cbSize = CUInt(Marshal.SizeOf(info))
        If (GetLastInputInfo(info)) Then
            Return TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime)
        Else
            Return Nothing
        End If
    End Function

    Private Sub Timer_comisiones_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_tiempo_espera.Tick
        Dim inactiveTime = GetInactiveTime()
        If (inactiveTime.Value.TotalSeconds > tiempo_espera) Then
            Me.Close()
        End If
    End Sub

    Private Sub PictureBox_logo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox_logo.Click

    End Sub
End Class