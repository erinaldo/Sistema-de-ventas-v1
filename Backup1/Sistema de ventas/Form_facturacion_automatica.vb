Imports System.IO
Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient
Imports System.Math
Imports System.Resources

Public Class Form_facturacion_automatica
    Dim cod_cliente As String
    Dim rut_cliente As String
    Dim nombre_cliente As String
    Dim telefono_cliente As String
    Dim direccion_cliente As String
    Dim comuna_cliente As String
    Dim descuento_1 As String
    Dim descuento_2 As String
    Dim giro_cliente As String
    Dim folio_cliente As String
    Dim email_cliente As String
    Dim varnumfactura As Integer
    Dim mitexto As String
    Dim hasta As String
    Dim peso As String
    Dim mifecha_emision2 As String
    Dim mifecha_vencimiento2 As String
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim mifecha6 As String
    Dim fecha_impresion As String

    Private Sub Form_facturacion_automatica_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_facturacion_automatica_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_facturacion_automatica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        grilla_clientes.Columns(0).Visible = False
        grilla_clientes.Columns(3).Visible = False
        grilla_clientes.Columns(9).Visible = False
        grilla_clientes.Columns(10).Visible = False
        grilla_facturacion.Columns(1).Visible = False
        grilla_clientes.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)
        grilla_facturacion.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)
        fecha_impresion = "NO"
        Dim fecha As New DateTime(Date.Now.Year, Date.Now.Month, 1)
        dtp_desde.Value = fecha
        dtp_hasta.Value = dtp_desde.Value.AddMonths(Val(+1))
        dtp_hasta.Value = dtp_desde.Value.AddDays(Val(-1))
        dtp_desde.Value = dtp_desde.Value.AddMonths(Val(-1))
        dtp_fecha.Value = dtp_hasta.Value
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
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

        Dim mifecha5 As Date
        mifecha5 = dtp_fecha.Text
        mifecha6 = mifecha5.ToString("yyy-MM-dd")
    End Sub

    Sub limpiar()
        txt_hasta.Text = ""
        txt_desde.Text = ""
        txt_descuento.Text = ""
        txt_total.Text = ""
        txt_sub_total.Text = ""
        txt_iva.Text = ""
        txt_neto.Text = ""
        txt_sub_total_millar.Text = ""
        txt_neto_millar.Text = ""
        txt_iva_millar.Text = ""
        txt_desc_millar.Text = ""
        txt_total_millar.Text = ""
        txt_total_saldo.Text = ""
        grilla_clientes.Rows.Clear()
        grilla_facturacion.Rows.Clear()
    End Sub

    Sub limpiar_facturacion()
        txt_hasta.Text = ""
        txt_desde.Text = ""
        txt_descuento.Text = ""
        txt_total.Text = ""
        txt_sub_total.Text = ""
        txt_iva.Text = ""
        txt_neto.Text = ""
        txt_sub_total_millar.Text = ""
        txt_neto_millar.Text = ""
        txt_iva_millar.Text = ""
        txt_desc_millar.Text = ""
        txt_total_millar.Text = ""
        txt_total_saldo.Text = ""
        grilla_facturacion.Rows.Clear()
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

        recuperar_conexion()

        SC.Connection = conexion
        SC.CommandText = "delete from clientes_temporal"
        DA.SelectCommand = SC
        DA.Fill(DT)

        Dim nombre_servidor As String
        Dim nombre_servidor_remoto As String
        Dim base_de_datos As String
        Dim clave_base_de_datos As String
        Dim usuario As String
        Dim recinto As String
        Dim rut_empresa As String

        For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1

            nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
            nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
            base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
            clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
            usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
            recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
            rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString
            'recinto = Trim(Replace(recinto, "'", "´"))

            conexion.Close()
            conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"

            malla_clientes_remoto()
            recuperar_conexion()
            grabar_clientes()

            Try

            Catch mierror As MySqlException

            Catch mierror As MissingManifestResourceException

            End Try
        Next

        recuperar_conexion()
    End Sub

    Sub malla_clientes_remoto()
        If txt_desde.Text = txt_hasta.Text Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select clientes.cod_cliente, clientes.rut_cliente, clientes.nombre_cliente, clientes.telefono_cliente, clientes.direccion_cliente, clientes.comuna_cliente, clientes.descuento_1, clientes.descuento_2, clientes.giro_cliente, clientes.folio_cliente, clientes.email_cliente from clientes, guia where clientes.rut_cliente = guia.rut_cliente and estado = 'SIN FACTURAR' AND CONDICIONES <> 'TRASLADO' AND  nombre_cliente like '" & (mitexto) & "' and  fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' GROUP BY clientes.rut_CLIENTE order by nombre_cliente"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_clientes.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    cod_cliente = DS.Tables(DT.TableName).Rows(i).Item("cod_cliente")
                    rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
                    nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente")
                    telefono_cliente = DS.Tables(DT.TableName).Rows(i).Item("telefono_cliente")
                    direccion_cliente = DS.Tables(DT.TableName).Rows(i).Item("direccion_cliente")
                    comuna_cliente = DS.Tables(DT.TableName).Rows(i).Item("comuna_cliente")
                    descuento_1 = DS.Tables(DT.TableName).Rows(i).Item("descuento_1")
                    descuento_2 = DS.Tables(DT.TableName).Rows(i).Item("descuento_2")
                    giro_cliente = DS.Tables(DT.TableName).Rows(i).Item("giro_cliente")
                    folio_cliente = DS.Tables(DT.TableName).Rows(i).Item("folio_cliente")
                    email_cliente = DS.Tables(DT.TableName).Rows(i).Item("email_cliente")
                    grilla_clientes.Rows.Add(cod_cliente, rut_cliente, nombre_cliente, telefono_cliente, direccion_cliente, comuna_cliente, descuento_1, descuento_2, giro_cliente, folio_cliente, email_cliente)
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

            SC.CommandText = "select clientes.cod_cliente, clientes.rut_cliente, clientes.nombre_cliente, clientes.telefono_cliente, clientes.direccion_cliente, clientes.comuna_cliente, clientes.descuento_1, clientes.descuento_2, clientes.giro_cliente, clientes.folio_cliente, clientes.email_cliente from clientes, guia  where clientes.rut_cliente = guia.rut_cliente and estado = 'SIN FACTURAR' AND CONDICIONES <> 'TRASLADO' AND  nombre_cliente BETWEEN  '" & (txt_desde.Text) & "' and '" & (hasta) & "' and  fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' GROUP BY CODIGO_CLIENTE order by nombre_cliente"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_clientes.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    cod_cliente = DS.Tables(DT.TableName).Rows(i).Item("cod_cliente")
                    rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
                    nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente")
                    telefono_cliente = DS.Tables(DT.TableName).Rows(i).Item("telefono_cliente")
                    direccion_cliente = DS.Tables(DT.TableName).Rows(i).Item("direccion_cliente")
                    comuna_cliente = DS.Tables(DT.TableName).Rows(i).Item("comuna_cliente")
                    descuento_1 = DS.Tables(DT.TableName).Rows(i).Item("descuento_1")
                    descuento_2 = DS.Tables(DT.TableName).Rows(i).Item("descuento_2")
                    giro_cliente = DS.Tables(DT.TableName).Rows(i).Item("giro_cliente")
                    folio_cliente = DS.Tables(DT.TableName).Rows(i).Item("folio_cliente")
                    email_cliente = DS.Tables(DT.TableName).Rows(i).Item("email_cliente")

                    grilla_clientes.Rows.Add(cod_cliente, rut_cliente, nombre_cliente, telefono_cliente, direccion_cliente, comuna_cliente, descuento_1, descuento_2, giro_cliente, folio_cliente, email_cliente)
                Next
            End If
        End If

        If grilla_clientes.Rows.Count <> 0 Then
            If grilla_clientes.Columns(1).Width = 100 Then
                grilla_clientes.Columns(1).Width = 99
            Else
                grilla_clientes.Columns(1).Width = 100
            End If
        End If
    End Sub

    Sub grabar_clientes()
        For i = 0 To grilla_clientes.Rows.Count - 1
            cod_cliente = grilla_clientes.Rows(i).Cells(0).Value
            rut_cliente = grilla_clientes.Rows(i).Cells(1).Value
            nombre_cliente = grilla_clientes.Rows(i).Cells(2).Value
            telefono_cliente = grilla_clientes.Rows(i).Cells(3).Value
            direccion_cliente = grilla_clientes.Rows(i).Cells(4).Value
            comuna_cliente = grilla_clientes.Rows(i).Cells(5).Value
            descuento_1 = grilla_clientes.Rows(i).Cells(6).Value
            descuento_2 = grilla_clientes.Rows(i).Cells(7).Value
            giro_cliente = grilla_clientes.Rows(i).Cells(8).Value
            folio_cliente = grilla_clientes.Rows(i).Cells(9).Value
            email_cliente = grilla_clientes.Rows(i).Cells(10).Value

            SC.Connection = conexion
            SC.CommandText = "INSERT INTO clientes_temporal(codigo_cliente, rut_cliente, nombre_cliente, telefono_cliente, direccion_cliente, comuna_cliente, descuento_1, descuento_2, giro_cliente, folio_cliente, email_cliente) values('" & (cod_cliente) & "','" & (rut_cliente) & "','" & (nombre_cliente) & "','" & (telefono_cliente) & "','" & (direccion_cliente) & "','" & (comuna_cliente) & "','" & (descuento_1) & "','" & (descuento_2) & "','" & (giro_cliente) & "','" & (folio_cliente) & "','" & (email_cliente) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Next



        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
       
        SC.CommandText = "select codigo_cliente, rut_cliente, nombre_cliente, telefono_cliente, direccion_cliente, comuna_cliente, descuento_1, descuento_2, giro_cliente, folio_cliente, email_cliente from clientes_temporal GROUP BY codigo_cliente order by nombre_cliente"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_clientes.Rows.Clear()

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                cod_cliente = DS.Tables(DT.TableName).Rows(i).Item("codigo_cliente")
                rut_cliente = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
                nombre_cliente = DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente")
                telefono_cliente = DS.Tables(DT.TableName).Rows(i).Item("telefono_cliente")
                direccion_cliente = DS.Tables(DT.TableName).Rows(i).Item("direccion_cliente")
                comuna_cliente = DS.Tables(DT.TableName).Rows(i).Item("comuna_cliente")
                descuento_1 = DS.Tables(DT.TableName).Rows(i).Item("descuento_1")
                descuento_2 = DS.Tables(DT.TableName).Rows(i).Item("descuento_2")
                giro_cliente = DS.Tables(DT.TableName).Rows(i).Item("giro_cliente")
                folio_cliente = DS.Tables(DT.TableName).Rows(i).Item("folio_cliente")
                email_cliente = DS.Tables(DT.TableName).Rows(i).Item("email_cliente")
                grilla_clientes.Rows.Add(cod_cliente, rut_cliente, nombre_cliente, telefono_cliente, direccion_cliente, comuna_cliente, descuento_1, descuento_2, giro_cliente, folio_cliente, email_cliente)
            Next
        End If

        If grilla_clientes.Rows.Count <> 0 Then
            If grilla_clientes.Columns(1).Width = 100 Then
                grilla_clientes.Columns(1).Width = 99
            Else
                grilla_clientes.Columns(1).Width = 100
            End If
        End If
    End Sub

    Sub mostrar_malla()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select n_guia , TIPO , fecha_venta, descuento , neto , iva, subtotal , total, recinto from guia  where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and  CODIGO_cliente = '" & (cod_cliente) & "' and estado = 'SIN FACTURAR' AND CONDICIONES <> 'TRASLADO' "

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Dim fecha_guia As String
                fecha_guia = DS.Tables(DT.TableName).Rows(i).Item("FECHA_VENTA")
                grilla_facturacion.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("N_GUIA"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                                fecha_guia, _
                                                 DS.Tables(DT.TableName).Rows(i).Item("descuento"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("neto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("iva"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("subtotal"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("total"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("recinto"))
            Next
        End If

        conexion.Close()
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
        End If
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        Dim nombre_servidor As String
        Dim nombre_servidor_remoto As String
        Dim base_de_datos As String
        Dim clave_base_de_datos As String
        Dim usuario As String
        Dim recinto As String
        Dim rut_empresa As String

        If fecha_impresion = "NO" Then
            Dim valormensaje As Integer
            valormensaje = MsgBox("¿ESTAS SEGURO QUE LA FECHA DE EMISION ES: " & dtp_fecha.Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
            If valormensaje = vbYes Then
                fecha_impresion = "SI"
            End If
        Else
            Exit Sub
        End If


        Dim valorfac As Integer
        valorfac = MsgBox("¿ESTAS SEGURO DE INICIAR LA FACTURACION?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        If valorfac = vbYes Then



            For i = 0 To grilla_clientes.Rows.Count - 1
                grilla_facturacion.Rows.Clear()
                txt_sub_total.Text = 0
                txt_neto.Text = 0
                txt_iva.Text = 0
                txt_descuento.Text = 0
                txt_porcentaje_desc.Text = 0
                txt_total.Text = 0
                txt_sub_total_millar.Text = 0
                txt_neto_millar.Text = 0
                txt_iva_millar.Text = 0
                txt_desc_millar.Text = 0
                txt_porcentaje_desc.Text = 0
                txt_total_millar.Text = 0

                cod_cliente = grilla_clientes.Rows(i).Cells(0).Value
                rut_cliente = grilla_clientes.Rows(i).Cells(1).Value
                nombre_cliente = grilla_clientes.Rows(i).Cells(2).Value
                telefono_cliente = grilla_clientes.Rows(i).Cells(3).Value
                direccion_cliente = grilla_clientes.Rows(i).Cells(4).Value
                comuna_cliente = grilla_clientes.Rows(i).Cells(5).Value
                descuento_1 = grilla_clientes.Rows(i).Cells(6).Value
                descuento_2 = grilla_clientes.Rows(i).Cells(7).Value
                giro_cliente = grilla_clientes.Rows(i).Cells(8).Value
                folio_cliente = grilla_clientes.Rows(i).Cells(9).Value
                email_cliente = grilla_clientes.Rows(i).Cells(10).Value
                txt_porcentaje_desc.Text = descuento_2

                For u = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1
                    nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(u).Cells(0).Value.ToString
                    nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(u).Cells(1).Value.ToString
                    base_de_datos = Form_menu_principal.grilla_conexiones.Rows(u).Cells(2).Value.ToString
                    clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(u).Cells(3).Value.ToString
                    usuario = Form_menu_principal.grilla_conexiones.Rows(u).Cells(4).Value.ToString
                    recinto = Form_menu_principal.grilla_conexiones.Rows(u).Cells(5).Value.ToString
                    rut_empresa = Form_menu_principal.grilla_conexiones.Rows(u).Cells(6).Value.ToString
                    recinto = Trim(Replace(recinto, "'", "´"))

                    'conexion.Close()
                    'conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"

                    conexion.Close()
                    conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor_remoto) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                    mostrar_malla()

                    'Try
                    '    mostrar_malla()
                    'Catch mierror As MySqlException
                    '    conexion.Close()
                    '    conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor_remoto) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                    '    mostrar_malla()
                    'Catch mierror As MissingManifestResourceException
                    '    conexion.Close()
                    '    conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor_remoto) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                    '    mostrar_malla()
                    'End Try
                Next

                calcular_totales()
                recuperar_conexion()
                facturacion()
                grilla_facturacion.Rows.Clear()
            Next

            lbl_mensaje.Visible = False
            Me.Enabled = True

            limpiar()
            txt_desde.Focus()

            MsgBox("SE HA IMPRESO CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCION")

        End If
        lbl_mensaje.Visible = False
        Me.Enabled = True
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
        Dim netogrilla As Integer
        Dim ivagrilla As Integer
        Dim subtotalgrilla As Integer

        '//Calcular el total neto
        txt_neto.Text = 0
        For i = 0 To grilla_facturacion.Rows.Count - 1
            netogrilla = Val(grilla_facturacion.Rows(i).Cells(4).Value.ToString)
            txt_neto.Text = Val(txt_neto.Text) + Val(netogrilla)
        Next

        '//Calcular el total iva
        txt_iva.Text = 0
        For i = 0 To grilla_facturacion.Rows.Count - 1
            ivagrilla = Val(grilla_facturacion.Rows(i).Cells(5).Value.ToString)
            txt_iva.Text = Val(txt_iva.Text) + Val(ivagrilla)
        Next

        '//Calcular el sub-total 
        txt_sub_total.Text = 0
        For i = 0 To grilla_facturacion.Rows.Count - 1
            subtotalgrilla = Val(grilla_facturacion.Rows(i).Cells(7).Value.ToString)
            txt_sub_total.Text = Val(txt_sub_total.Text) + Val(subtotalgrilla)
        Next

        '//Calcular el descuento
        txt_descuento.Text = 0

        txt_descuento.Text = CInt(CInt(descuento_2) * CInt(txt_sub_total.Text) / 100)

        '//Calcular el total general
        txt_total.Text = 0

        txt_total.Text = (txt_sub_total.Text) - (txt_descuento.Text)

        'Dim descuento_porcentaje As Integer
        'Dim porcentaje_desc As Integer
        'Dim iva As Integer
        'Dim neto As Integer
        Dim iva_valor As String

        iva_valor = valor_iva / 100 + 1
        txt_neto.Text = Round(txt_total.Text / iva_valor)
        txt_iva.Text = (((txt_neto.Text) * valor_iva) / 100)
        txt_iva.Text = (txt_total.Text) - (txt_neto.Text)

        peso = " PESOS"
        If CInt(txt_total.Text) < 1000000 Then
            txt_desglose.Text = Num2Text(txt_total.Text) & peso
        Else
            txt_desglose.Text = Num2Text(txt_total.Text)
        End If

        peso = " PESOS"
        If CInt(txt_total.Text) = 1000000 Then
            desglose_valor = Num2Text(txt_total.Text) & " DE PESOS"
        ElseIf CInt(txt_total.Text) = 2000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 3000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 4000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 5000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 6000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 7000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 8000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 9000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 10000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 11000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 12000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 13000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 14000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 15000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 16000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 17000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 18000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 19000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 20000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 21000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 22000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 23000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 24000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 25000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 26000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 27000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 28000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 29000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        ElseIf CInt(txt_total.Text) = 30000000 Then
            desglose_valor = Num2Text(txt_total.Text) & "DE PESOS"
        Else
            desglose_valor = Num2Text(txt_total.Text) & peso
        End If

        If txt_sub_total.Text = "" Or txt_sub_total.Text = "0" Then
            txt_sub_total_millar.Text = "0"
        Else
            txt_sub_total_millar.Text = Format(Int(txt_sub_total.Text), "###,###,###")
        End If
        If txt_descuento.Text = "" Or txt_descuento.Text = "0" Then
            txt_desc_millar.Text = "0"
        Else
            txt_desc_millar.Text = Format(Int(txt_descuento.Text), "###,###,###")
        End If
        If txt_neto.Text = "" Or txt_neto.Text = "0" Then
            txt_neto_millar.Text = "0"
        Else
            txt_neto_millar.Text = Format(Int(txt_neto.Text), "###,###,###")
        End If
        If txt_iva.Text = "" Or txt_iva.Text = "0" Then
            txt_iva_millar.Text = "0"
        Else
            txt_iva_millar.Text = Format(Int(txt_iva.Text), "###,###,###")
        End If
        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total_millar.Text = "0"
        Else
            txt_total_millar.Text = Format(Int(txt_total.Text), "###,###,###")
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

    Private Sub btn_quitar_elemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        If grilla_facturacion.Rows.Count <> 0 Then
            grilla_facturacion.Rows.Remove(grilla_facturacion.CurrentRow)
            txt_desde.Focus()
        End If
    End Sub

    Private Sub btn_quitar_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.GotFocus
        btn_quitar_elemento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_elemento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.LostFocus
        btn_quitar_elemento.BackColor = Color.Transparent
    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
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
        grilla_clientes.Rows.Clear()
        fecha()
        mostrar_malla_clientes()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub grilla_clientes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_clientes.DoubleClick
        lbl_mensaje.Visible = True
        Me.Enabled = False
        grilla_facturacion.Rows.Clear()
        txt_sub_total.Text = 0
        txt_neto.Text = 0
        txt_iva.Text = 0
        txt_descuento.Text = 0
        txt_porcentaje_desc.Text = 0
        txt_total.Text = 0
        txt_sub_total_millar.Text = 0
        txt_neto_millar.Text = 0
        txt_iva_millar.Text = 0
        txt_desc_millar.Text = 0
        txt_porcentaje_desc.Text = 0
        txt_total_millar.Text = 0
        cod_cliente = grilla_clientes.CurrentRow.Cells(0).Value
        rut_cliente = grilla_clientes.CurrentRow.Cells(1).Value
        nombre_cliente = grilla_clientes.CurrentRow.Cells(2).Value
        telefono_cliente = grilla_clientes.CurrentRow.Cells(3).Value
        direccion_cliente = grilla_clientes.CurrentRow.Cells(4).Value
        comuna_cliente = grilla_clientes.CurrentRow.Cells(5).Value
        descuento_1 = grilla_clientes.CurrentRow.Cells(6).Value
        descuento_2 = grilla_clientes.CurrentRow.Cells(7).Value
        giro_cliente = grilla_clientes.CurrentRow.Cells(8).Value
        folio_cliente = grilla_clientes.CurrentRow.Cells(9).Value
        email_cliente = grilla_clientes.CurrentRow.Cells(10).Value
        txt_porcentaje_desc.Text = descuento_2

        Dim nombre_servidor As String
        Dim nombre_servidor_remoto As String
        Dim base_de_datos As String
        Dim clave_base_de_datos As String
        Dim usuario As String
        Dim recinto As String
        Dim rut_empresa As String

        For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1
            nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
            nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
            base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
            clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
            usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
            recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
            rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString
            'recinto = Trim(Replace(recinto, "'", "´"))

            conexion.Close()
            conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"

            Try

                mostrar_malla()
                calcular_totales()

            Catch mierror As MySqlException

            Catch mierror As MissingManifestResourceException

            End Try
        Next

        recuperar_conexion()
        lbl_mensaje.Visible = False
        Me.Enabled = True




    End Sub

    'creamos el numero de la factura de credito.
    Sub crear_numero_factura()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(cod_auto) as cod_auto from factura where tipo_impresion <> 'DIGITADA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumfactura = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                'txt_factura.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_factura.Text = 1
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
            SC.CommandText = "select n_factura from factura where cod_auto='" & (varnumfactura) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumfactura = DS.Tables(DT.TableName).Rows(0).Item("n_factura")
                txt_factura.Text = varnumfactura + 1
            End If
        Catch err As InvalidCastException
            txt_factura.Text = 1
        End Try
        conexion.Close()
        Exit Sub
    End Sub

    Sub grabar_factura()
        Dim tipo_impresion As String
        If estado_factura_electronica = "SI" Then
            tipo_impresion = "ELECTRONICA"
        Else
            tipo_impresion = "MANUAL"
        End If

        dtp_vencimiento.CustomFormat = "yyy-MM-dd"
        dtp_vencimiento.Value = dtp_fecha.Value.AddMonths(Val(+1))

        SC.Connection = conexion
        SC.CommandText = "insert into factura (n_factura, TIPO, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable, rut_retira, nombre_retira, recinto, orden, hora, porcentaje_desc, tipo_impresion, pie, condicion_de_pago_pie, comision) values (" & (txt_factura.Text) & ",'" & ("FACTURA DE CREDITO") & "', '" & (rut_cliente) & "','" & (cod_cliente) & "','" & (mifecha6) & "'," & (txt_descuento.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & ",'" & ("CREDITO") & "', '" & ("EMITIDA") & "',  '" & ("SISTEMA") & "','-','-','" & (mirecintoempresa) & "','-','" & (Form_menu_principal.lbl_hora.Text) & "','" & (txt_porcentaje_desc.Text) & "','" & (tipo_impresion) & "', '0', '-'," & (txt_total.Text) & ")"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "insert into creditos (n_creditos, TIPO, tipo_detalle, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, saldo, desglose, condiciones, estado, usuario_responsable, codigo_afecta, nombre_afecta, recinto, fecha_vencimiento, fecha_pago, numero_cuota, total_cuotas, interes, gastos_de_cobranza, pie, convenio) values (" & (txt_factura.Text) & ",'" & ("FACTURA") & "','" & ("FACTURA") & "','" & (rut_cliente) & "','" & (cod_cliente) & "','" & (mifecha6) & "'," & (txt_descuento.Text) & "," & (txt_neto.Text) & "," & (txt_iva.Text) & "," & (txt_sub_total.Text) & "," & (txt_total.Text) & "," & (txt_total.Text) & ",'" & (txt_desglose.Text) & "','" & ("CREDITO") & "','" & ("EMITIDA") & "','" & ("SISTEMA") & "','" & (txt_factura.Text) & "','FACTURA', '" & (mirecintoempresa) & "', '" & (dtp_vencimiento.Text) & "', '0000-00-00', '1', '1', '0', '0', '0', '-')"
        DA.SelectCommand = SC
        DA.Fill(DT)
        Exit Sub
    End Sub

    Sub grabar_detalle_factura()
        Dim VarNumeroguia As Integer
        Dim varTipo As String
        Dim varfecha As String
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarTotal As Integer
        Dim VarSubotal As Integer
        Dim VarRecinto As String

        For i = 0 To grilla_facturacion.Rows.Count - 1
            VarNumeroguia = grilla_facturacion.Rows(i).Cells(0).Value
            varTipo = grilla_facturacion.Rows(i).Cells(1).Value
            varfecha = grilla_facturacion.Rows(i).Cells(2).Value
            VarDescuento = grilla_facturacion.Rows(i).Cells(3).Value
            VarNeto = grilla_facturacion.Rows(i).Cells(4).Value
            VarIva = grilla_facturacion.Rows(i).Cells(5).Value
            VarSubotal = grilla_facturacion.Rows(i).Cells(6).Value
            VarTotal = grilla_facturacion.Rows(i).Cells(7).Value
            VarRecinto = grilla_facturacion.Rows(i).Cells(8).Value

            SC.Connection = conexion
            SC.CommandText = "insert into detalle_factura (n_factura, cod_producto, detalle_nombre, cantidad, numero_tecnico, valor_unitario, porcentaje_desc, detalle_descuento, detalle_neto, detalle_iva, detalle_subtotal, detalle_total) values(" & (txt_factura.Text) & "," & (VarNumeroguia) & ",'" & (varTipo) & "','1','" & (varfecha) & "'," & (VarTotal) & ",'0', " & (VarDescuento) & ", " & (VarNeto) & "," & (VarIva) & "," & (VarSubotal) & "," & (VarTotal) & ")"
            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()

            Dim nombre_servidor As String
            Dim nombre_servidor_remoto As String
            Dim base_de_datos As String
            Dim clave_base_de_datos As String
            Dim usuario As String
            Dim recinto As String
            Dim rut_empresa As String

            For u = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1
                nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(u).Cells(0).Value.ToString
                nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(u).Cells(1).Value.ToString
                base_de_datos = Form_menu_principal.grilla_conexiones.Rows(u).Cells(2).Value.ToString
                clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(u).Cells(3).Value.ToString
                usuario = Form_menu_principal.grilla_conexiones.Rows(u).Cells(4).Value.ToString
                recinto = Form_menu_principal.grilla_conexiones.Rows(u).Cells(5).Value.ToString
                rut_empresa = Form_menu_principal.grilla_conexiones.Rows(u).Cells(6).Value.ToString
                recinto = Trim(Replace(recinto, "'", "´"))

                If VarRecinto = recinto Then
                    conexion.Close()
                    conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"

                    Try
                        conexion.Open()
                        conexion.Close()

                    Catch mierror As MySqlException
                        conexion.Close()
                        conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"

                    Catch mierror As MissingManifestResourceException
                        conexion.Close()
                        conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                    End Try

                    SC.Connection = conexion
                    SC.CommandText = "update guia set estado = 'FACTURADA' where n_guia = '" & (VarNumeroguia) & "'"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                End If
            Next
        Next

        recuperar_conexion()
    End Sub

    Sub recuperar_conexion()
        Dim nombre_servidor As String
        Dim nombre_servidor_remoto As String
        Dim base_de_datos As String
        Dim clave_base_de_datos As String
        Dim usuario As String
        Dim recinto As String
        Dim rut_empresa As String
        Try
            For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1
                nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
                nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
                base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
                clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
                usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
                recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
                rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString

                If SucursalSeleccionada = recinto Then
                    Try
                        conexion.Close()
                        conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                        conexion.Open()
                        conexion.Close()
                    Catch
                        conexion.Close()
                        conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"
                        conexion.Open()
                        conexion.Close()
                    End Try
                End If
            Next
        Catch
            Me.Close()
            Form_menu_principal.Close()
        End Try
    End Sub

    Sub crear_archivo_plano()
        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim ContenidoArchivo As String = Nothing
        ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
        Dim PathArchivo As String
        'Dim VarCodProducto As String
        Dim varnombre As String
        'Dim vartecnico As String
        'Dim VarValorUnitario As Integer
        'Dim VarCantidad As String
        'Dim VarPorcentaje As String
        'Dim VarDescuento As Integer
        'Dim VarNeto As Integer
        'Dim VarIva As Integer
        'Dim VarSubtotal As Integer
        'Dim VarTotal As Integer
        'Dim VarProveedor As String
        'Dim VarCosto As Integer
        'Dim VarSaldo As Integer
        Dim VarNroGuia As String
        Dim VarFechaGuia As String
        Dim VarTotalGuia As String
        Dim nro_linea As String

        If nombre_cliente.Length > 99 Then
            nombre_cliente = nombre_cliente.Substring(0, 100)
        End If

        If giro_cliente.Length > 39 Then
            giro_cliente = giro_cliente.Substring(0, 40)
        End If

        If direccion_cliente.Length > 59 Then
            direccion_cliente = direccion_cliente.Substring(0, 60)
        End If

        If comuna_cliente.Length > 19 Then
            comuna_cliente = comuna_cliente.Substring(0, 20)
        End If

        Dim ciudad_cliente As String
        ciudad_cliente = comuna_cliente
        If ciudad_cliente.Length > 19 Then
            ciudad_cliente = ciudad_cliente.Substring(0, 20)
        End If

        If email_cliente.Length > 199 Then
            email_cliente = email_cliente.Substring(0, 200)
        End If

        If telefono_cliente.Length > 8 Then
            telefono_cliente = telefono_cliente.Substring(0, 8)
        End If

        If email_cliente = "-" Then
            email_cliente = ""
        End If

        If folio_cliente = "-" Then
            folio_cliente = ""
        End If

        Dim condicion As String
        condicion = "CREDITO"

        If condicion = "CREDITO" Then
            condicion = "CREDITO "
        End If

        Try

            If Directory.Exists(ruta_archivos_facturacion) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(ruta_archivos_facturacion)
            End If

            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            PathArchivo = ruta_archivos_facturacion & "\" & "Factura " & (txt_factura.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' TIPO de codificacion para escritura

            'escribimos en el archivo
            strStreamWriter.WriteLine("->Encabezado<-" & vbNewLine _
                                       & "33" & ";" & (txt_factura.Text) & ";" & (mifecha6) & ";" & "0" & ";" & "0" & ";" & (rut_cliente) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (ciudad_cliente) & ";" & (comuna_cliente) & ";" & (email_cliente) & ";" & ("CREDITO") & ";" & "SISTEMA" & ";;;" & (mirecintoempresa) & ";" & (telefono_cliente) & ";" & vbNewLine _
                                       & "->Totales<-" & vbNewLine _
                                        & (0) & ";" & (0) & ";" & "0" & ";" & "0" & ";" & (txt_neto.Text) & ";" & "0" & ";" & (valor_iva) & ";" & (txt_iva.Text) & ";" & (txt_total.Text) & ";1;" & vbNewLine _
                                        & "->Detalle<-")

            nro_linea = 0

            For i = 0 To grilla_facturacion.Rows.Count - 1
                nro_linea = nro_linea + 1
                VarNroGuia = grilla_facturacion.Rows(i).Cells(0).Value.ToString
                VarFechaGuia = grilla_facturacion.Rows(i).Cells(2).Value.ToString
                VarTotalGuia = grilla_facturacion.Rows(i).Cells(7).Value.ToString
                varnombre = "GUIA NRO. " & VarNroGuia & " / " & VarFechaGuia

                If varnombre.Length > 52 Then
                    varnombre = varnombre.Substring(0, 52)
                End If
                strStreamWriter.WriteLine(nro_linea & ";-;" & (varnombre) & ";1;" & (VarTotalGuia) & ";0;0;" & (0) & ";" & (0) & ";" & (0) & ";" & (VarTotalGuia) & ";" & "INT11" & ";" & "UN" & ";" & ";")
            Next



            nro_linea = 0
            strStreamWriter.WriteLine("->Referencia<-")

            For i = 0 To grilla_facturacion.Rows.Count - 1
                nro_linea = nro_linea + 1
                VarNroGuia = grilla_facturacion.Rows(i).Cells(0).Value.ToString
                VarFechaGuia = grilla_facturacion.Rows(i).Cells(2).Value.ToString
                VarTotalGuia = grilla_facturacion.Rows(i).Cells(7).Value.ToString
                varnombre = "GUIA NRO. " & VarNroGuia & " / " & VarFechaGuia

                If varnombre.Length > 52 Then
                    varnombre = varnombre.Substring(0, 52)
                End If


                Dim mifecha As Date
                mifecha = VarFechaGuia
                VarFechaGuia = mifecha.ToString("yyy-MM-dd")

                strStreamWriter.WriteLine(nro_linea & ";52;" & (VarNroGuia) & ";" & (VarFechaGuia) & ";" & "0" & ";" & "-" & ";")
            Next


            'strStreamWriter.WriteLine("->Referencia<-" & vbNewLine _
            '& "1" & ";801;;;" & "0" & ";" & "-" & ";" & vbNewLine _
            '& "->DescRec<-" & vbNewLine _

            'strStreamWriter.WriteLine("->Referencia<-" & vbNewLine _
            '                            & "1" & ";801;;;" & "0" & ";" & "-" & ";" & vbNewLine _
            strStreamWriter.WriteLine("->DescRec<-" & vbNewLine _
                                        & "1" & ";" & "D" & ";" & "Descuento" & ";" & "$" & ";" & txt_descuento.Text & ";" & "0" & ";" & vbNewLine _
                                        & "->Observacion<-" & vbNewLine _
                                        & folio_cliente & ";" & "CREDITO" & ";")
            strStreamWriter.Close() ' cerramos

        Catch ex As Exception
            MsgBox("Error al Guardar la informacion en el archivo. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
            strStreamWriter.Close() ' cerramos
        End Try
    End Sub

    Sub facturacion()
        Dim VarNumeroguia As Integer
        Dim varTipo As String
        Dim varfecha As String
        Dim VarDescuento As Integer
        Dim VarNeto As Integer
        Dim VarIva As Integer
        Dim VarTotal As Integer
        Dim VarSubotal As Integer
        Dim VarRecinto As String
        grilla_factura_tope.Rows.Clear()

        For i = 0 To grilla_facturacion.Rows.Count - 1
            VarNumeroguia = grilla_facturacion.Rows(i).Cells(0).Value
            varTipo = grilla_facturacion.Rows(i).Cells(1).Value
            varfecha = grilla_facturacion.Rows(i).Cells(2).Value
            VarDescuento = grilla_facturacion.Rows(i).Cells(3).Value
            VarNeto = grilla_facturacion.Rows(i).Cells(4).Value
            VarIva = grilla_facturacion.Rows(i).Cells(5).Value
            VarSubotal = grilla_facturacion.Rows(i).Cells(6).Value
            VarTotal = grilla_facturacion.Rows(i).Cells(7).Value
            VarRecinto = grilla_facturacion.Rows(i).Cells(8).Value

            grilla_factura_tope.Rows.Add(VarNumeroguia, _
                                          varTipo, _
                                           varfecha, _
                                            VarDescuento, _
                                             VarNeto, _
                                              VarIva, _
                                               VarSubotal, _
                                                VarTotal, _
                                                 VarRecinto)
        Next

        Dim nro_linea As Integer
        grilla_facturacion.Rows.Clear()
        nro_linea = 0

        For i = 0 To grilla_factura_tope.Rows.Count - 1
            VarNumeroguia = grilla_factura_tope.Rows(i).Cells(0).Value
            varTipo = grilla_factura_tope.Rows(i).Cells(1).Value
            varfecha = grilla_factura_tope.Rows(i).Cells(2).Value
            VarDescuento = grilla_factura_tope.Rows(i).Cells(3).Value
            VarNeto = grilla_factura_tope.Rows(i).Cells(4).Value
            VarIva = grilla_factura_tope.Rows(i).Cells(5).Value
            VarSubotal = grilla_factura_tope.Rows(i).Cells(6).Value
            VarTotal = grilla_factura_tope.Rows(i).Cells(7).Value
            VarRecinto = grilla_factura_tope.Rows(i).Cells(8).Value

            grilla_facturacion.Rows.Add(VarNumeroguia, _
                                          varTipo, _
                                           varfecha, _
                                            VarDescuento, _
                                             VarNeto, _
                                              VarIva, _
                                               VarSubotal, _
                                                VarTotal, _
                                                 VarRecinto)

            nro_linea = nro_linea + 1

            If grilla_facturacion.Rows.Count = 25 Or grilla_factura_tope.Rows.Count = 0 Then
                nro_linea = 0
                Me.calcular_totales()
                Me.crear_numero_factura()
                Me.grabar_factura()
                Me.grabar_detalle_factura()
                Me.crear_archivo_plano()
                grilla_facturacion.Rows.Clear()
            End If
        Next

        If grilla_facturacion.Rows.Count <> 0 Then
            nro_linea = 0
            Me.calcular_totales()
            Me.crear_numero_factura()
            Me.grabar_factura()
            Me.grabar_detalle_factura()
            Me.crear_archivo_plano()
        End If

        grilla_factura_tope.Rows.Clear()
        grilla_facturacion.Rows.Clear()
        limpiar_facturacion()
    End Sub

    Private Sub grilla_clientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_clientes.CellContentClick

    End Sub
End Class