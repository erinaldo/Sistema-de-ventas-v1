Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_registro_cuentas_corrientes
    Dim VarSeleccion As Integer
    Dim MiPos As Integer
    Dim restriccion_ingreso_clientes As String
    'Dim label_apellidos As Integer
    'Dim text_apellidos As Integer
    'Dim label_giro As Integer
    'Dim text_giro As Integer
    'Dim label_telefono As Integer
    'Dim text_telefono As Integer
    'Dim label_email As Integer
    'Dim text_email As Integer
    'Dim label_comuna As Integer
    'Dim text_comuna As Integer
    'Dim label_ciudad As Integer
    'Dim text_ciudad As Integer
    'Dim label_direccion As Integer
    'Dim text_direccion As Integer
    'Dim label_descto1 As Integer
    'Dim text_dscto1 As Integer
    'Dim label_descto2 As Integer
    'Dim text_dscto2 As Integer
    'Dim label_folio As Integer
    'Dim text_folio As Integer
    'Dim label_tipo_cuenta As Integer
    'Dim Combobox_tipo_cuenta As Integer
    'Dim label_orden As Integer
    'Dim Combobox_orden As Integer
    'Dim label_cupo As Integer
    'Dim text_cupo As Integer
    'Dim label_cuenta As Integer
    'Dim Combobox_cuenta As Integer
    'Dim label_activo As Integer
    'Dim Combobox_activo As Integer
    'Dim label_directo As Integer
    'Dim label_fin_de_mes As Integer


    'Dim label_apellidos_menos As Integer
    'Dim text_apellidos_menos As Integer
    'Dim label_giro_menos As Integer
    'Dim text_giro_menos As Integer
    'Dim label_telefono_menos As Integer
    'Dim text_telefono_menos As Integer
    'Dim label_email_menos As Integer
    'Dim text_email_menos As Integer
    'Dim label_comuna_menos As Integer
    'Dim text_comuna_menos As Integer
    'Dim label_ciudad_menos As Integer
    'Dim text_ciudad_menos As Integer
    'Dim label_direccion_menos As Integer
    'Dim text_direccion_menos As Integer
    'Dim label_descto1_menos As Integer
    'Dim text_dscto1_menos As Integer
    'Dim label_descto2_menos As Integer
    'Dim text_dscto2_menos As Integer
    'Dim label_folio_menos As Integer
    'Dim text_folio_menos As Integer
    'Dim label_tipo_cuenta_menos As Integer
    'Dim Combobox_tipo_cuenta_menos As Integer
    'Dim label_orden_menos As Integer
    'Dim Combobox_orden_menos As Integer
    'Dim label_cupo_menos As Integer
    'Dim text_cupo_menos As Integer
    'Dim label_cuenta_menos As Integer
    'Dim Combobox_cuenta_menos As Integer
    'Dim label_activo_menos As Integer
    'Dim Combobox_activo_menos As Integer
    'Dim label_directo_menos As Integer
    'Dim label_fin_de_mes_menos As Integer

    Dim Nombre As String
    Dim Comuna As String
    Dim Direccion As String
    Dim email As String
    Dim email_dos As String
    Dim telefono As String
    Dim telefono_dos As String
    Dim Giro As String
    Dim descuento As String
    Dim descuento2 As String
    Dim pagare As String
    Dim estado_cuenta_corriente As String
    Dim nombre_representante As String
    Dim email_representante As String
    Dim cupo_cliente As String
    Dim saldo_cliente As String

    Private Sub form_registro_clientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub


    Private Sub form_clientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If mirutempresa = "81921000-4" Then
            txt_pagare.Visible = True
            lbl_pagare.Visible = True
        Else
            txt_pagare.Visible = False
            lbl_pagare.Visible = False
        End If

        'capturar_location()

        controles(False, True)
        'actualizar_tabla()
        'mostrar(0)



        comunas()
        ' combo_tipo.Text = "TIPO CUENTA"
        cargar_logo()


        restriccion_clientes()

        lbl_apellidos.Visible = False
        txt_apellidos.Visible = False


        ' TIPO()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub



    Sub comunas()

        conexion.Close()
        DS4.Tables.Clear()
        DT4.Rows.Clear()
        DT4.Columns.Clear()
        DS4.Clear()
        SC4.Connection = conexion
        SC4.CommandText = "select * from comuna order by comuna_nombre asc"
        DA4.SelectCommand = SC4
        DA4.Fill(DT4)
        DS4.Tables.Add(DT4)

        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        If DS4.Tables(DT4.TableName).Rows.Count > 0 Then


            For i = 0 To DS4.Tables(0).Rows.Count - 1

                ' Combo_comuna.Items.Add(UCase(DS3.Tables(DT3.TableName).Rows(i).Item("comuna_nombre")))
                col.Add(UCase(DS4.Tables(0).Rows(i)("comuna_nombre").ToString()))
            Next
            txt_comuna.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt_comuna.AutoCompleteCustomSource = col
            txt_comuna.AutoCompleteMode = AutoCompleteMode.Suggest

            txt_comuna.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt_comuna.AutoCompleteCustomSource = col
            txt_comuna.AutoCompleteMode = AutoCompleteMode.Suggest
        End If

        txt_comuna.AutoCompleteSource = AutoCompleteSource.CustomSource
        txt_comuna.AutoCompleteCustomSource = col
        txt_comuna.AutoCompleteMode = AutoCompleteMode.Suggest







    End Sub


    Sub guion_rut_cliente()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut.Text
        If txt_rut.Text.Contains("PROPIEDAD") Then
        Else
            If rut_cliente.Length > 2 Then

                guion = rut_cliente(rut_cliente.Length - 2).ToString()

                If guion <> "-" Then
                    Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                    rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                    rut_cliente = rut_cliente & "-" & fin_rut
                    txt_rut.Text = rut_cliente
                End If
            End If
        End If
    End Sub


    Private Sub txt_telefono_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_telefono.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_telefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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
    End Sub

    Private Sub txt_rut_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.GotFocus
        txt_rut.BackColor = Color.LightSkyBlue
    End Sub


    Private Sub txt_rut_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.Validated
        'If valida_rut(txt_rut.Text) = False Then
        '    txt_rut.Focus()
        '    txt_rut.SelectAll()
        'End If
    End Sub

    Sub mostrar(ByVal i As Integer)
        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            txt_codigo_cliente.Text = DS2.Tables(DT2.TableName).Rows(i).Item("cod_cliente")
            txt_rut.Text = DS2.Tables(DT2.TableName).Rows(i).Item("rut_cliente")
            combo_tipo.Text = DS2.Tables(DT2.TableName).Rows(i).Item("tipo_cliente")
            txt_nombres.Text = DS2.Tables(DT2.TableName).Rows(i).Item("nombre_cliente")
            txt_direccion.Text = DS2.Tables(DT2.TableName).Rows(i).Item("direccion_cliente")
            txt_telefono.Text = DS2.Tables(DT2.TableName).Rows(i).Item("telefono_cliente")
            txt_telefono_dos.Text = DS2.Tables(DT2.TableName).Rows(i).Item("telefono_cliente_dos")
            txt_email.Text = DS2.Tables(DT2.TableName).Rows(i).Item("email_cliente_dos")
            txt_email_dos.Text = DS2.Tables(DT2.TableName).Rows(i).Item("email_cliente")
            txt_comuna.Text = DS2.Tables(DT2.TableName).Rows(i).Item("comuna_cliente")
            txt_ciudad.Text = DS2.Tables(DT2.TableName).Rows(i).Item("ciudad_cliente")
            txt_giro.Text = DS2.Tables(DT2.TableName).Rows(i).Item("giro_cliente")
            txt_dscto1.Text = DS2.Tables(DT2.TableName).Rows(i).Item("descuento_1")
            txt_dscto2.Text = DS2.Tables(DT2.TableName).Rows(i).Item("descuento_2")
            txt_folio.Text = DS2.Tables(DT2.TableName).Rows(i).Item("folio_cliente")
            txt_pagare.Text = DS2.Tables(DT2.TableName).Rows(i).Item("pagare")
            txt_representante.Text = DS2.Tables(DT2.TableName).Rows(i).Item("nombre_representante")
            txt_email_representante.Text = DS2.Tables(DT2.TableName).Rows(i).Item("email_representante")
            Combo_tipo_cuenta.Items.Clear()
            Combo_tipo_cuenta.Items.Add("BOLETA")
            Combo_tipo_cuenta.Items.Add("GUIA")
            Combo_tipo_cuenta.Items.Add("FACTURA")
            Combo_tipo_cuenta.Items.Add("MIXTA")
            Combo_tipo_cuenta.Items.Add("-")
            Combo_tipo_cuenta.Text = DS2.Tables(DT2.TableName).Rows(i).Item("tipo_cuenta")
            Combo_orden.Text = DS2.Tables(DT2.TableName).Rows(i).Item("orden_de_compra")
            txt_cupo.Text = DS2.Tables(DT2.TableName).Rows(i).Item("cupo_cliente")
            txt_cuenta.Text = DS2.Tables(DT2.TableName).Rows(i).Item("estado_cuenta")
            Combo_cuenta.Text = DS2.Tables(DT2.TableName).Rows(i).Item("estado_cuenta")

            Try
                Combo_activo.Text = DS2.Tables(DT2.TableName).Rows(i).Item("activo")
            Catch
            End Try
        End If
    End Sub

    Sub mostrar_datos_clientes()
        If txt_rut.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from clientes where rut_cliente ='" & (txt_rut.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count = 1 Then
                txt_codigo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                combo_tipo.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cliente")
                txt_nombres.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                txt_telefono_dos.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente_dos")
                txt_email.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                txt_email_dos.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente_dos")
                txt_comuna.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
                txt_ciudad.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                txt_giro.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_cliente")
                txt_dscto1.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
                txt_dscto2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
                txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
                txt_pagare.Text = DS.Tables(DT.TableName).Rows(0).Item("pagare")
                Combo_tipo_cuenta.Items.Clear()
                Combo_tipo_cuenta.Items.Add("BOLETA")
                Combo_tipo_cuenta.Items.Add("GUIA")
                Combo_tipo_cuenta.Items.Add("FACTURA")
                Combo_tipo_cuenta.Items.Add("MIXTA")
                Combo_tipo_cuenta.Items.Add("-")
                Combo_tipo_cuenta.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")
                Combo_orden.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
                txt_cupo.Text = DS.Tables(DT.TableName).Rows(0).Item("cupo_cliente")
                txt_cuenta.Text = DS.Tables(DT.TableName).Rows(0).Item("estado_cuenta")
                Combo_cuenta.Text = DS.Tables(DT.TableName).Rows(0).Item("estado_cuenta")
                txt_representante.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_representante")
                txt_email_representante.Text = DS.Tables(DT.TableName).Rows(0).Item("email_representante")

                Try
                    Combo_activo.Text = DS.Tables(DT.TableName).Rows(0).Item("activo")
                    txt_pagare.Text = DS.Tables(DT.TableName).Rows(0).Item("pagare")
                Catch
                End Try





                Nombre = txt_nombres.Text
                Comuna = txt_comuna.Text
                Direccion = txt_direccion.Text
                email = txt_email.Text
                telefono = txt_telefono.Text
                Giro = txt_giro.Text
                descuento = txt_dscto1.Text
                descuento2 = txt_dscto2.Text
                pagare = txt_pagare.Text
                estado_cuenta_corriente = Combo_cuenta.Text
                cupo_cliente = txt_cupo.Text




                For Each cntrl As Control In Me.Controls
                    If (TypeOf (cntrl) Is GroupBox) Then ' Verifico que el control sea un textbox
                        For Each myControl In cntrl.Controls
                            If (TypeOf (myControl) Is TextBox) Then ' Verifico que el control sea un textbox
                                CType(myControl, TextBox).Enabled = True ' Le cambio el valor a la propiedad
                                CType(myControl, TextBox).BackColor = Color.White ' Le cambio el valor a la propiedad
                                'CType(myControl, TextBox).Focus() ' Le cambio el valor a la propiedad
                            End If
                            If (TypeOf (myControl) Is ComboBox) Then ' Verifico que el control sea un textbox
                                CType(myControl, ComboBox).Enabled = True ' Le cambio el valor a la propiedad
                            End If
                        Next
                    End If
                Next
                txt_rut.Enabled = False
                txt_nombres.Focus()
                Exit Sub

            ElseIf DS.Tables(DT.TableName).Rows.Count > 1 Then
                conexion.Close()
                Form_seleccionar_cuenta_clientes_cuentas_corrientes.Show()
                Me.Enabled = False
                Exit Sub
            ElseIf DS.Tables(DT.TableName).Rows.Count < 1 Then
                MsgBox("RUT NO EXISTENTE", 0 + 16, "ERROR")
                txt_rut.Focus()
                conexion.Close()
            End If
            conexion.Close()
        End If
    End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_nuevo.Enabled = b
        'btn_eliminar.Enabled = b
        btn_modificar.Enabled = b
        btn_buscar.Enabled = b
        btn_guardar.Enabled = a
        btn_cancelar.Enabled = a

        '   btn_mensaje_cliente.Enabled = a

        'btn_imprimir.Enabled = b
        combo_tipo.Enabled = a
        txt_rut.Enabled = a
        txt_direccion.Enabled = a
        txt_nombres.Enabled = a
        txt_pagare.Enabled = a
        txt_telefono.Enabled = a
        txt_telefono_dos.Enabled = a
        txt_email.Enabled = a
        txt_email_dos.Enabled = a
        txt_ciudad.Enabled = a
        txt_comuna.Enabled = a
        txt_giro.Enabled = a
        txt_dscto1.Enabled = a
        txt_dscto2.Enabled = a
        txt_folio.Enabled = a
        Combo_cuenta.Enabled = a
        Combo_activo.Enabled = a
        txt_cupo.Enabled = a
        Combo_tipo_cuenta.Enabled = a
        Combo_orden.Enabled = a
        txt_representante.Enabled = a
        txt_email_representante.Enabled = a

        btn_primero.Enabled = b
        btn_ultimo.Enabled = b
        btn_siguiente.Enabled = b
        btn_anterior.Enabled = b
        'txt_dscto1.Enabled = a

        For Each cntrl As Control In Me.Controls
            If (TypeOf (cntrl) Is GroupBox) Then ' Verifico que el control sea un textbox
                For Each myControl In cntrl.Controls
                    If (TypeOf (myControl) Is TextBox) Then ' Verifico que el control sea un textbox
                        If CType(myControl, TextBox).Enabled = True Then ' Le cambio el valor a la propiedad
                            CType(myControl, TextBox).BackColor = Color.White ' Le cambio el valor a la propiedad
                        Else
                            CType(myControl, TextBox).Enabled = True
                            CType(myControl, TextBox).BackColor = SystemColors.Control ' Le cambio el valor a la propiedad
                            CType(myControl, TextBox).Enabled = False ' Le cambio el valor a la propiedad
                        End If
                        If (TypeOf (myControl) Is ComboBox) Then ' Verifico que el control sea un textbox
                            CType(myControl, ComboBox).Enabled = False ' Le cambio el valor a la propiedad
                        End If
                    End If
                Next
            End If
        Next
    End Sub

    Sub limpiar()
        combo_tipo.Text = "-"
        txt_rut.Text = ""
        txt_direccion.Text = ""
        txt_nombres.Text = ""
        txt_pagare.Text = ""
        txt_telefono.Text = ""
        txt_telefono_dos.Text = ""
        txt_email.Text = ""
        txt_email_dos.Text = ""
        txt_ciudad.Text = ""
        txt_comuna.Text = ""
        txt_giro.Text = ""
        txt_dscto1.Text = ""
        txt_dscto2.Text = ""
        txt_folio.Text = ""
        Combo_cuenta.Text = ""
        Combo_activo.Text = ""
        txt_cupo.Text = ""
        Combo_tipo_cuenta.Text = "-"
        Combo_orden.Text = ""
        txt_representante.Text = ""
        txt_email_representante.Text = ""




    End Sub


    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        limpiar()
        controles(True, False)
        VarSeleccion = 1
        estado_cuenta_corriente = ""
        'txt_dscto1.Text = "0"
        btn_mensaje_cliente.Enabled = False
        combo_tipo.DroppedDown = True
        combo_tipo.Focus()
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        controles(True, False)
        VarSeleccion = 2

        For Each cntrl As Control In Me.Controls
            If (TypeOf (cntrl) Is GroupBox) Then ' Verifico que el control sea un textbox
                For Each myControl In cntrl.Controls
                    If (TypeOf (myControl) Is TextBox) Then ' Verifico que el control sea un textbox
                        CType(myControl, TextBox).BackColor = SystemColors.Control ' Le cambio el valor a la propiedad
                        CType(myControl, TextBox).Enabled = False ' Le cambio el valor a la propiedad
                    End If
                    If (TypeOf (myControl) Is ComboBox) Then ' Verifico que el control sea un textbox
                        CType(myControl, ComboBox).Enabled = False ' Le cambio el valor a la propiedad
                    End If
                Next
            End If
        Next
        txt_rut.Enabled = True
        txt_rut.Focus()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Dim mensaje As String = ""
        Dim estado_cuenta As String
        Dim cuenta_cliente As String

        cuenta_cliente = ""
        estado_cuenta = ""

        If combo_tipo.Text = "" Then
            MsgBox("CAMPO TIPO CUENTA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            combo_tipo.Focus()
            Exit Sub
        End If

        If combo_tipo.Text = "-" Then
            MsgBox("CAMPO TIPO CUENTA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            combo_tipo.Focus()
            Exit Sub
        End If

        If txt_rut.Text = "" Then
            MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_rut.Focus()
            Exit Sub
        End If

        If txt_nombres.Text = "" Then
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_nombres.Focus()
            Exit Sub
        End If

        If txt_giro.Text = "" Then
            MsgBox("CAMPO GIRO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_giro.Focus()
            Exit Sub
        End If

        If txt_telefono.Text = "" Then
            MsgBox("CAMPO TELEFONO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_telefono.Focus()
            Exit Sub
        End If

        If txt_telefono_dos.Text = "" Then
            MsgBox("CAMPO TELEFONO DOS VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_telefono_dos.Focus()
            Exit Sub
        End If

        If txt_email.Text = "" Then
            MsgBox("CAMPO CORREO ELECTRONICO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_email.Focus()
            Exit Sub
        End If

        If txt_email_dos.Text = "" Then
            MsgBox("CAMPO CORREO ELECTRONICO DOS VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_email_dos.Focus()
            Exit Sub
        End If

        If txt_comuna.Text = "" Then
            MsgBox("CAMPO COMUNA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_comuna.Focus()
            Exit Sub
        End If

        If txt_ciudad.Text = "" Then
            MsgBox("CAMPO CIUDAD VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_ciudad.Focus()
            Exit Sub
        End If

        If txt_direccion.Text = "" Then
            MsgBox("CAMPO DIRECCION VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_direccion.Focus()
            Exit Sub
        End If

        If txt_dscto1.Text = "" Then
            MsgBox("CAMPO DESCUENTO 1 VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_dscto1.Focus()
            Exit Sub
        End If

        If txt_dscto2.Text = "" Then
            MsgBox("CAMPO DESCUENTO 2 VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_dscto2.Focus()
            Exit Sub
        End If

        If txt_folio.Text = "" Then
            MsgBox("CAMPO FOLIO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_folio.Focus()
            Exit Sub
        End If

        If txt_representante.Text = "" Then
            MsgBox("CAMPO REPRESENTANTE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_representante.Focus()
            Exit Sub
        End If

        If txt_email_representante.Text = "" Then
            MsgBox("CAMPO CORREO ELECTRONICO REPRESENTANTE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_email_representante.Focus()
            Exit Sub
        End If

        If Combo_cuenta.Text <> "SIN CUENTA" Then
            If Combo_tipo_cuenta.Text = "" Then
                MsgBox("CAMPO TIPO DOCUMENTO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
                combo_tipo.Focus()
                Exit Sub
            End If

            If Combo_tipo_cuenta.Text = "-" Then
                MsgBox("CAMPO TIPO DOCUMENTO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
                combo_tipo.Focus()
                Exit Sub
            End If
        End If

        If Combo_orden.Text = "" Then
            MsgBox("CAMPO ORDEN DE COMPRA CUENTA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_orden.Focus()
            Exit Sub
        End If

        If Combo_orden.Text = "-" Then
            MsgBox("CAMPO ORDEN DE COMPRA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_orden.Focus()
            Exit Sub
        End If

        If txt_cupo.Text = "" Then
            MsgBox("CAMPO CUPO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_cupo.Focus()
            Exit Sub
        End If

        If estado_cuenta_corriente <> "SIN CUENTA" Then
            If Combo_cuenta.Text = "SIN CUENTA" Then
                MsgBox("NO PUEDE SELECCIONAR LA OPCION SIN CUENTA", 0 + 16, "ERROR")
                Exit Sub
            End If
        End If

        If Combo_cuenta.Text = "-" Then
            MsgBox("CAMPO CUENTA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_cuenta.Focus()
            Exit Sub
        End If

        If Combo_activo.Text = "-" Then
            MsgBox("CAMPO ACTIVO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_activo.Focus()
            Exit Sub
        End If






        If combo_tipo.Text = "PERSONA" Then
            txt_nombres.Text = txt_apellidos.Text & " " & txt_nombres.Text
        ElseIf combo_tipo.Text = "EMPRESA" Then
            txt_nombres.Text = txt_nombres.Text
        End If


        If Combo_cuenta.Text = "ABIERTA" Then
            estado_cuenta = "ABIERTA"
            cuenta_cliente = "SI"
        End If
        If Combo_cuenta.Text = "CERRADA" Then
            estado_cuenta = "CERRADA"
            cuenta_cliente = "SI"
        End If
        If Combo_cuenta.Text = "SIN CUENTA" Then
            estado_cuenta = "SIN CUENTA"
            cuenta_cliente = "NO"
        End If
        If Combo_cuenta.Text = "BLOQUEADA" Then
            estado_cuenta = "BLOQUEADA"
            cuenta_cliente = "SI"
        End If

        If mirutempresa = "81921000-4" Then
            If txt_pagare.Text = "" Then
                MsgBox("CAMPO PAGARE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
                txt_pagare.Focus()
                Exit Sub
            End If
            If txt_pagare.Text = "0" Then
                MsgBox("CAMPO PAGARE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
                txt_pagare.Focus()
                Exit Sub
            End If
        Else
            txt_pagare.Text = "0"
        End If

        If VarSeleccion = 1 Then
            If valida_rut(txt_rut.Text) = False Then
                txt_rut.Focus()
                txt_rut.SelectAll()
                Exit Sub
            End If



            txt_nombres.Text = LTrim(Replace(txt_nombres.Text, " ", " "))

            conexion.Close()
            Consultas_SQL("select * from comuna where comuna_nombre = '" & (txt_comuna.Text) & "'")
            If DS.Tables(DT.TableName).Rows.Count = 0 Then
                MsgBox("DEBE SELECCIONAR UNA COMUNA DEL SISTEMA", 0 + 16, "ERROR")
                txt_comuna.Focus()
                Exit Sub
            End If

            'If restriccion_ingreso_clientes = "SI" Then
            '    If tipo_usuario <> "ADMINISTRADOR DEL SISTEMA" Then
            '        Consultas_SQL("select * from clientes where rut_CLIENTE = '" & (txt_rut.Text) & "'")
            '        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            '            MsgBox("REGISTRO YA EXISTENTE", 0 + 16, "ERROR")
            '            Exit Sub
            '        End If
            '    End If
            'End If

            Me.Enabled = False

            crear_codigo_cliente()

            SC.Connection = conexion
            SC.CommandText = "INSERT INTO clientes (cod_cliente, tipo_cliente, rut_cliente, nombre_cliente, direccion_cliente, telefono_cliente, telefono_cliente_dos, email_cliente, email_cliente_dos, comuna_cliente, giro_cliente, descuento_1, ciudad_cliente, descuento_2, folio_cliente, estado_cuenta, cuenta_cliente, tipo_cuenta, orden_de_compra, mensaje, cupo_cliente, saldo_cliente, fecha_modificacion, activo, pagare, nombre_representante, email_representante) VALUES  ('" & (txt_codigo_cliente.Text) & "','" & (combo_tipo.Text) & "','" & (txt_rut.Text) & "','" & (txt_nombres.Text) & "','" & (txt_direccion.Text) & "','" & (txt_telefono.Text) & "','" & (txt_telefono_dos.Text) & "','" & (txt_email.Text) & "','" & (txt_email_dos.Text) & "','" & (txt_comuna.Text) & "','" & (txt_giro.Text) & "','" & (txt_dscto1.Text) & "','" & (txt_comuna.Text) & "','" & (txt_dscto2.Text) & "','" & (txt_folio.Text) & "','" & (estado_cuenta) & "', '" & (cuenta_cliente) & "', '" & (Combo_tipo_cuenta.Text) & "', '" & (Combo_orden.Text) & "', 'SIN MENSAJE', '" & (txt_cupo.Text) & "', '" & (txt_cupo.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (Combo_activo.Text) & "', '" & (txt_pagare.Text) & "', '" & (txt_representante.Text) & "', '" & (txt_email_representante.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','CREACION DE CLIENTES CREDITO','" & (txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','CREACION','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            actualizar_tabla()
            controles(False, True)
            MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            btn_mensaje_cliente.Enabled = False
            txt_apellidos.Enabled = False

        ElseIf VarSeleccion = 2 Then

            If estado_cuenta_corriente <> "SIN CUENTA" Then
                If Combo_cuenta.Text = "SIN CUENTA" Then
                    MsgBox("NO PUEDE SELECCIONAR LA OPCION SIN CUENTA", 0 + 16, "ERROR")
                    Exit Sub
                End If
            End If


            txt_nombres.Text = LTrim(Replace(txt_nombres.Text, " ", " "))


            conexion.Close()
            Consultas_SQL("select * from comuna where comuna_nombre = '" & (txt_comuna.Text) & "'")
            If DS.Tables(DT.TableName).Rows.Count = 0 Then
                MsgBox("DEBE SELECCIONAR UNA COMUNA DEL SISTEMA", 0 + 16, "ERROR")
                txt_comuna.Focus()
                Exit Sub
            End If


            If Nombre <> txt_nombres.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTES','" & ("SE MODIFICO EL NOMBRE AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If Comuna <> txt_comuna.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTES','" & ("SE MODIFICO LA COMUNA AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If Direccion <> txt_direccion.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTES','" & ("SE MODIFICO LA DIRECCION AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If email <> txt_email.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTES','" & ("SE MODIFICO EL EMAIL AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If email_dos <> txt_email_dos.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTES','" & ("SE MODIFICO EL SEGUNDO EMAIL AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If telefono <> txt_telefono.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTES','" & ("SE MODIFICO EL TELEFONO AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If telefono_dos <> txt_telefono_dos.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTES','" & ("SE MODIFICO EL SEGUNDO TELEFONO AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If Giro <> txt_giro.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTES','" & ("SE MODIFICO EL GIRO AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If descuento <> txt_dscto1.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTES','" & ("SE MODIFICO EL DESCUENTO AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If


            If descuento2 <> txt_dscto2.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTES','" & ("SE MODIFICO EL DESCUENTO 2 AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If nombre_representante <> txt_representante.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE REPRESENTANTE','" & ("SE MODIFICO EL REPRESENTANTE AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If email_representante <> txt_email_representante.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE REPRESENTANTE','" & ("SE MODIFICO EL EMAIL DE REPRESENTANTE AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If pagare <> txt_pagare.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTES','" & ("SE MODIFICO EL PAGARE AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "UPDATE `clientes` SET `fecha_pagare`='" & (Form_menu_principal.dtp_fecha.Text) & "'  WHERE cod_cliente = '" & (txt_codigo_cliente.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

            If cupo_cliente <> txt_cupo.Text Then
                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, tipo, usuario_responsable) values('CLIENTES','MODIFICACION DE CUPO','" & ("SE MODIFICO EL CUPO AL CLIENTE " & txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)


                DS3.Tables.Clear()
                DT3.Rows.Clear()
                DT3.Columns.Clear()
                DS3.Clear()
                conexion.Open()
                Try
                    SC3.Connection = conexion
                    SC3.CommandText = "select sum(saldo) as saldo from creditos  where saldo <> '0' and rut_cliente='" & (txt_rut.Text) & "'"
                    DA3.SelectCommand = SC3
                    DA3.Fill(DT3)
                    DS3.Tables.Add(DT3)

                    If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                        saldo_cliente = DS3.Tables(DT3.TableName).Rows(0).Item("saldo")
                    End If
                Catch err As InvalidCastException
                    saldo_cliente = 0
                End Try
                'saldo_cliente = Val(txt_cupo.Text) - Val(saldo_cliente)

                SC.Connection = conexion
                SC.CommandText = "UPDATE clientes SET saldo_cliente = '" & (saldo_cliente) & "', fecha_modificacion='" & (Form_menu_principal.dtp_fecha.Text) & "' WHERE rut_cliente = '" & (txt_rut.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If








            Try
                SC.Connection = conexion
                SC.CommandText = "UPDATE clientes SET tipo_cliente='" & (combo_tipo.Text) & "', nombre_cliente='" & (txt_nombres.Text) & "', direccion_cliente='" & (txt_direccion.Text) & "', telefono_cliente='" & (txt_telefono.Text) & "', telefono_cliente_dos='" & (txt_telefono_dos.Text) & "', email_cliente='" & (txt_email.Text) & "', email_cliente_dos='" & (txt_email_dos.Text) & "', comuna_cliente='" & (txt_comuna.Text) & "', giro_cliente='" & (txt_giro.Text) & "', descuento_1='" & (txt_dscto1.Text) & "', ciudad_cliente='" & (txt_comuna.Text) & "', descuento_2='" & (txt_dscto2.Text) & "', folio_cliente='" & (txt_folio.Text) & "', estado_cuenta='" & (estado_cuenta) & "', cuenta_cliente='" & (cuenta_cliente) & "', tipo_cuenta='" & (Combo_tipo_cuenta.Text) & "' ,orden_de_compra= '" & (Combo_orden.Text) & "', email_cliente = '" & (txt_email.Text) & "', cupo_cliente = '" & (txt_cupo.Text) & "', fecha_modificacion='" & (Form_menu_principal.dtp_fecha.Text) & "', activo='" & (Combo_activo.Text) & "', pagare='" & (txt_pagare.Text) & "' , nombre_representante='" & (txt_representante.Text) & "' , email_representante='" & (txt_email_representante.Text) & "' WHERE cod_cliente = '" & (txt_codigo_cliente.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('CLIENTES','MODIFICACION DE CLIENTES CREDITO','" & (txt_rut.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','MODIFICACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

            Catch err As InvalidCastException

            End Try


            actualizar_tabla()
            controles(False, True)
            Me.Enabled = True
            MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            btn_mensaje_cliente.Enabled = False
            txt_apellidos.Enabled = False
        End If

    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA ELIMINAR ESTE REGISTRO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")

        If valormensaje = vbYes Then
            SC.Connection = conexion
            SC.CommandText = "delete from clientes where rut_cliente = '" & (txt_rut.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        actualizar_tabla()
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            mostrar(0)
        Else
            limpiar()
        End If


    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        controles(False, True)
        MiPos = 0
        mostrar(MiPos)
        tipo_seleccion()

        For Each cntrl As Control In Me.Controls
            If (TypeOf (cntrl) Is GroupBox) Then ' Verifico que el control sea un textbox
                For Each myControl In cntrl.Controls
                    If (TypeOf (myControl) Is TextBox) Then ' Verifico que el control sea un textbox
                        CType(myControl, TextBox).BackColor = SystemColors.Control ' Le cambio el valor a la propiedad
                        CType(myControl, TextBox).Enabled = False ' Le cambio el valor a la propiedad
                    End If
                    If (TypeOf (myControl) Is ComboBox) Then ' Verifico que el control sea un textbox
                        CType(myControl, ComboBox).Enabled = False ' Le cambio el valor a la propiedad
                    End If
                Next
            End If
        Next
        btn_mensaje_cliente.Enabled = True
        btn_cancelar.Enabled = True
    End Sub



    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        'form_Menu_admin.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub



    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Enabled = False
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()

        'conexion.Open()

        'SC.Connection = conexion
        'SC.CommandText = "select * from clientes, EMPRESA where rut = '" & (txt_rut.Text) & "'"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)

        'Dim rpt As New Crystal_clientes_sistema

        'rpt.SetDataSource(DS.Tables(DT.TableName))
        'form_informe_clientes.rpt_clientes.ReportSource = rpt
        'form_informe_clientes.Show()
        'conexion.Close()
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.ShowDialog()

        Me.Enabled = True
    End Sub

    Sub actualizar_tabla()
        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()

        SC2.Connection = conexion
        SC2.CommandText = "select * from clientes order by nombre_cliente asc"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)

        conexion.Close()
    End Sub

    Private Sub txt_dscto2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If Char.IsControl(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub

    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut.TextChanged

    End Sub

    Private Sub txt_nombre_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombres.GotFocus
        txt_nombres.BackColor = Color.LightSkyBlue

    End Sub

    Private Sub txt_nombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombres.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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

    Private Sub txt_nombre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombres.LostFocus
        txt_nombres.BackColor = Color.White
    End Sub



    Private Sub txt_direccion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_direccion.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_cupo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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
    End Sub




    Private Sub txt_cupo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_cupo.BackColor = Color.White
    End Sub

    Private Sub txt_cupo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_cupo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_pagare_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_pagare.LostFocus
        txt_pagare.BackColor = Color.White
    End Sub

    Private Sub txt_pagare_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_pagare.GotFocus
        txt_pagare.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_direccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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

    Private Sub txt_direccion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_direccion.BackColor = Color.White
    End Sub

    Private Sub txt_direccion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub txt_ciudad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_ciudad.BackColor = Color.LightBlue
    'End Sub

    Private Sub txt_ciudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    'Private Sub txt_ciudad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_ciudad.BackColor = Color.White
    'End Sub

    Private Sub txt_ciudad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_comuna_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_comuna.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_comuna_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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

    Private Sub txt_comuna_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_comuna.BackColor = Color.White
    End Sub

    Private Sub txt_comuna_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_giro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_giro.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_giro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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

    Private Sub txt_giro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_giro.BackColor = Color.White
    End Sub

    Private Sub txt_giro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_razon_social_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper

    End Sub


    Private Sub combo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_tipo.GotFocus
        combo_tipo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_tipo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_tipo.LostFocus
        combo_tipo.BackColor = Color.White
    End Sub

    Private Sub combo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_tipo.SelectedIndexChanged
        tipo_seleccion()
        txt_rut.Focus()
        'If combo_tipo.Enabled = True Then
        '    If combo_tipo.Text = "PERSONA" Then

        '        lbl_apellidos.Visible = True
        '        txt_apellidos.Visible = True

        '        lbl_apellidos.Location = New Point(9, 120)
        '        lbl_direccion.Location = New Point(2, 153)
        '        lbl_telefono.Location = New Point(3, 186)
        '        lbl_email.Location = New Point(32, 219)
        '        lbl_comuna.Location = New Point(16, 252)
        '        lbl_giro.Location = New Point(42, 285)

        '        txt_apellidos.Location = New Point(88, 117)
        '        txt_direccion.Location = New Point(88, 150)
        '        txt_telefono.Location = New Point(88, 183)
        '        txt_email.Location = New Point(88, 216)
        '        txt_comuna.Location = New Point(88, 249)
        '        txt_giro.Location = New Point(88, 282)

        '        btn_guardar.Location = New Point(7, 247)
        '        btn_cancelar.Location = New Point(7, 287)
        '        btn_salir.Location = New Point(7, 327)

        '        GroupBox_clientes.Width = (473)
        '        GroupBox_clientes.Height = (316)

        '        GroupBox_posicion.Location = New Point(7, 372)

        '        GroupBox_botones.Width = (119)
        '        GroupBox_botones.Height = (371)


        '        Me.Width = (617)
        '        Me.Height = (462)

        '    End If
        '    If combo_tipo.Text = "EMPRESA" Then

        '        lbl_apellidos.Visible = False
        '        txt_apellidos.Visible = False

        '        lbl_apellidos.Location = New Point(2, 120)
        '        lbl_direccion.Location = New Point(2, 120)
        '        lbl_telefono.Location = New Point(3, 153)
        '        lbl_email.Location = New Point(32, 186)
        '        lbl_comuna.Location = New Point(16, 219)
        '        lbl_giro.Location = New Point(42, 252)

        '        btn_guardar.Location = New Point(7, 214)
        '        btn_cancelar.Location = New Point(7, 254)
        '        btn_salir.Location = New Point(7, 294)

        '        txt_apellidos.Location = New Point(88, 117)
        '        txt_direccion.Location = New Point(88, 117)
        '        txt_telefono.Location = New Point(88, 150)
        '        txt_email.Location = New Point(88, 183)
        '        txt_comuna.Location = New Point(88, 216)
        '        txt_giro.Location = New Point(88, 249)

        '        GroupBox_clientes.Width = (473)
        '        GroupBox_clientes.Height = (283)

        '        GroupBox_posicion.Location = New Point(7, 339)

        '        GroupBox_botones.Width = (119)
        '        GroupBox_botones.Height = (337)

        '        Me.Width = (617)
        '        Me.Height = (429)

        '    End If
        '    If combo_tipo.Text = "TIPO CUENTA" Then
        '        lbl_apellidos.Visible = False
        '        txt_apellidos.Visible = False

        '        lbl_apellidos.Location = New Point(2, 120)
        '        lbl_direccion.Location = New Point(2, 120)
        '        lbl_telefono.Location = New Point(3, 153)
        '        lbl_email.Location = New Point(32, 186)
        '        lbl_comuna.Location = New Point(16, 219)
        '        lbl_giro.Location = New Point(42, 252)

        '        btn_guardar.Location = New Point(7, 214)
        '        btn_cancelar.Location = New Point(7, 254)
        '        btn_salir.Location = New Point(7, 294)

        '        txt_apellidos.Location = New Point(88, 117)
        '        txt_direccion.Location = New Point(88, 117)
        '        txt_telefono.Location = New Point(88, 150)
        '        txt_email.Location = New Point(88, 183)
        '        txt_comuna.Location = New Point(88, 216)
        '        txt_giro.Location = New Point(88, 249)

        '        GroupBox_clientes.Width = (473)
        '        GroupBox_clientes.Height = (283)

        '        GroupBox_posicion.Location = New Point(7, 339)

        '        GroupBox_botones.Width = (119)
        '        GroupBox_botones.Height = (337)

        '        Me.Width = (617)
        '        Me.Height = (429)
        '    End If
        'End If
    End Sub



    Private Sub txt_telefono_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_telefono.BackColor = Color.White
    End Sub

    Private Sub txt_telefono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_email_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_email.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_email_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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

    Private Sub txt_email_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_email.BackColor = Color.White
    End Sub

    Private Sub txt_email_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox_clientes.Enter

    End Sub

    'Private Sub txt_dscto1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_dscto1.BackColor = Color.LightBlue
    'End Sub

    'Private Sub txt_dscto1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_dscto1.BackColor = Color.White
    'End Sub

    Private Sub txt_rut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut.LostFocus
        txt_rut.BackColor = Color.White
    End Sub




    Private Sub btn_primero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_primero.Click
        MiPos = 0
        mostrar(MiPos)
    End Sub

    Private Sub btn_anterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_anterior.Click
        If MiPos >= 1 Then
            MiPos -= 1
            mostrar(MiPos)
        End If
    End Sub

    Private Sub btn_siguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_siguiente.Click
        If MiPos < DT2.Rows.Count - 1 Then
            MiPos += 1
            mostrar(MiPos)
        End If
    End Sub

    Private Sub btn_ultimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ultimo.Click
        MiPos = DT2.Rows.Count - 1
        mostrar(MiPos)
    End Sub

    Private Sub form_clientes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    End Sub



    Private Sub txt_rut_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rut.KeyUp

    End Sub

    Private Sub combo_tipo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_tipo.TextChanged

    End Sub

    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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
            If VarSeleccion = 1 Then
                guion_rut_cliente()
                txt_nombres.Focus()
            End If
            If VarSeleccion = 2 Then
                guion_rut_cliente()
                mostrar_datos_clientes()
            End If
        End If

    End Sub

    'Sub capturar_location()
    '    label_apellidos = lbl_apellidos.Top + 31
    '    text_apellidos = txt_apellidos.Top + 31
    '    label_giro = lbl_giro.Top + 31
    '    text_giro = txt_giro.Top + 31
    '    label_telefono = lbl_telefono.Top + 31
    '    text_telefono = txt_telefono.Top + 31
    '    label_email = lbl_email.Top + 31
    '    text_email = txt_email.Top + 31
    '    label_comuna = lbl_comuna.Top + 31
    '    text_comuna = txt_comuna.Top + 31
    '    label_ciudad = lbl_ciudad.Top + 31
    '    text_ciudad = txt_ciudad.Top + 31
    '    label_direccion = lbl_direccion.Top + 31
    '    text_direccion = txt_direccion.Top + 31
    '    label_descto1 = lbl_descto1.Top + 31
    '    text_dscto1 = txt_dscto1.Top + 31
    '    label_descto2 = lbl_descto2.Top + 31
    '    text_dscto2 = txt_dscto2.Top + 31
    '    label_folio = lbl_folio.Top + 31
    '    text_folio = txt_folio.Top + 31
    '    label_tipo_cuenta = lbl_tipo_cuenta.Top + 31
    '    Combobox_tipo_cuenta = Combo_tipo_cuenta.Top + 31
    '    label_orden = lbl_orden.Top + 31
    '    Combobox_orden = Combo_orden.Top + 31
    '    label_cupo = lbl_cupo.Top + 31
    '    text_cupo = txt_cupo.Top + 31
    '    label_cuenta = lbl_cuenta.Top + 31
    '    Combobox_cuenta = Combo_cuenta.Top + 31
    '    label_activo = lbl_activo.Top + 31
    '    Combobox_activo = Combo_activo.Top + 31
    '    label_directo = lbl_directo.Top + 31
    '    label_fin_de_mes = lbl_fin_de_mes.Top + 31

    '    label_apellidos_menos = lbl_apellidos.Top
    '    text_apellidos_menos = txt_apellidos.Top
    '    label_giro_menos = lbl_giro.Top
    '    text_giro_menos = txt_giro.Top
    '    label_telefono_menos = lbl_telefono.Top
    '    text_telefono_menos = txt_telefono.Top
    '    label_email_menos = lbl_email.Top
    '    text_email_menos = txt_email.Top
    '    label_comuna_menos = lbl_comuna.Top
    '    text_comuna_menos = txt_comuna.Top
    '    label_ciudad_menos = lbl_ciudad.Top
    '    text_ciudad_menos = txt_ciudad.Top
    '    label_direccion_menos = lbl_direccion.Top
    '    text_direccion_menos = txt_direccion.Top
    '    label_descto1_menos = lbl_descto1.Top
    '    text_dscto1_menos = txt_dscto1.Top
    '    label_descto2_menos = lbl_descto2.Top
    '    text_dscto2_menos = txt_dscto2.Top
    '    label_folio_menos = lbl_folio.Top
    '    text_folio_menos = txt_folio.Top
    '    label_tipo_cuenta_menos = lbl_tipo_cuenta.Top
    '    Combobox_tipo_cuenta_menos = Combo_tipo_cuenta.Top
    '    label_orden_menos = lbl_orden.Top
    '    Combobox_orden_menos = Combo_orden.Top
    '    label_cupo_menos = lbl_cupo.Top
    '    text_cupo_menos = txt_cupo.Top
    '    label_cuenta_menos = lbl_cuenta.Top
    '    Combobox_cuenta_menos = Combo_cuenta.Top
    '    label_activo_menos = lbl_activo.Top
    '    Combobox_activo_menos = Combo_activo.Top
    '    label_directo_menos = lbl_directo.Top
    '    label_fin_de_mes_menos = lbl_fin_de_mes.Top
    'End Sub

    Sub tipo_seleccion()

        If combo_tipo.Enabled = False Then
            lbl_apellidos.Visible = False
            txt_apellidos.Visible = False
            Panel1.Location = New Point(5, 101)

            'lbl_giro.Location = New Point(4, label_giro_menos)
            'txt_giro.Location = New Point(89, text_giro_menos)
            'lbl_telefono.Location = New Point(4, label_telefono_menos)
            'txt_telefono.Location = New Point(89, text_telefono_menos)
            'lbl_email.Location = New Point(4, label_email_menos)
            'txt_email.Location = New Point(89, text_email_menos)
            'lbl_comuna.Location = New Point(4, label_comuna_menos)
            'txt_comuna.Location = New Point(89, text_comuna_menos)
            'lbl_ciudad.Location = New Point(4, label_ciudad_menos)
            'txt_ciudad.Location = New Point(89, text_ciudad_menos)
            'lbl_direccion.Location = New Point(4, label_direccion_menos)
            'txt_direccion.Location = New Point(89, text_direccion_menos)
            'lbl_descto1.Location = New Point(4, label_descto1_menos)
            'txt_dscto1.Location = New Point(89, text_dscto1_menos)
            'lbl_descto2.Location = New Point(4, label_descto2_menos)
            'txt_dscto2.Location = New Point(89, text_dscto2_menos)
            'lbl_folio.Location = New Point(4, label_folio_menos)
            'txt_folio.Location = New Point(89, text_folio_menos)
            'lbl_tipo_cuenta.Location = New Point(4, label_tipo_cuenta_menos)
            'Combo_tipo_cuenta.Location = New Point(89, Combobox_tipo_cuenta_menos)
            'lbl_orden.Location = New Point(4, label_orden_menos)
            'Combo_orden.Location = New Point(89, Combobox_orden_menos)
            'lbl_cupo.Location = New Point(4, label_cupo_menos)
            'txt_cupo.Location = New Point(89, text_cupo_menos)
            'lbl_cuenta.Location = New Point(4, label_cuenta_menos)
            'Combo_cuenta.Location = New Point(89, Combobox_cuenta_menos)
            'lbl_activo.Location = New Point(4, label_activo_menos)
            'Combo_activo.Location = New Point(89, Combobox_activo_menos)
            'lbl_directo.Location = New Point(241, label_directo_menos)
            'lbl_fin_de_mes.Location = New Point(241, label_fin_de_mes_menos)

            'btn_guardar.Location = New Point(7, 470)
            'btn_cancelar.Location = New Point(7, 518)
            'btn_salir.Location = New Point(7, 560)

            'GroupBox_clientes.Width = (488)
            'GroupBox_clientes.Height = (548)
            'GroupBox_posicion.Location = New Point(7, 605)
            'GroupBox_botones.Width = (109)
            'GroupBox_botones.Height = (608)
            'Me.Width = (621)
            'Me.Height = (700)


            Exit Sub
        End If








        If combo_tipo.Enabled = True Then

            If combo_tipo.Text = "PERSONA" Then
                lbl_apellidos.Visible = True
                txt_apellidos.Visible = True

                Panel1.Location = New Point(5, 131)

                'lbl_giro.Location = New Point(4, label_giro)
                'txt_giro.Location = New Point(89, text_giro)
                'lbl_telefono.Location = New Point(4, label_telefono)
                'txt_telefono.Location = New Point(89, text_telefono)
                'lbl_email.Location = New Point(4, label_email)
                'txt_email.Location = New Point(89, text_email)
                'lbl_comuna.Location = New Point(4, label_comuna)
                'txt_comuna.Location = New Point(89, text_comuna)
                'lbl_ciudad.Location = New Point(4, label_ciudad)
                'txt_ciudad.Location = New Point(89, text_ciudad)
                'lbl_direccion.Location = New Point(4, label_direccion)
                'txt_direccion.Location = New Point(89, text_direccion)
                'lbl_descto1.Location = New Point(4, label_descto1)
                'txt_dscto1.Location = New Point(89, text_dscto1)
                'lbl_descto2.Location = New Point(4, label_descto2)
                'txt_dscto2.Location = New Point(89, text_dscto2)
                'lbl_folio.Location = New Point(4, label_folio)
                'txt_folio.Location = New Point(89, text_folio)
                'lbl_tipo_cuenta.Location = New Point(4, label_tipo_cuenta)
                'Combo_tipo_cuenta.Location = New Point(89, Combobox_tipo_cuenta)
                'lbl_orden.Location = New Point(4, label_orden)
                'Combo_orden.Location = New Point(89, Combobox_orden)
                'lbl_cupo.Location = New Point(4, label_cupo)
                'txt_cupo.Location = New Point(89, text_cupo)
                'lbl_cuenta.Location = New Point(4, label_cuenta)
                'Combo_cuenta.Location = New Point(89, Combobox_cuenta)
                'lbl_activo.Location = New Point(4, label_activo)
                'Combo_activo.Location = New Point(89, Combobox_activo)
                'lbl_directo.Location = New Point(241, label_directo)
                'lbl_fin_de_mes.Location = New Point(241, label_fin_de_mes)







                'btn_guardar.Location = New Point(7, 498)
                'btn_cancelar.Location = New Point(7, 543)
                'btn_salir.Location = New Point(7, 588)


                'GroupBox_clientes.Width = (490)
                'GroupBox_clientes.Height = (577)
                'GroupBox_posicion.Location = New Point(7, 633)
                'GroupBox_botones.Width = (109)
                'GroupBox_botones.Height = (636)
                'Me.Width = (621)
                'Me.Height = (728)


                Exit Sub
            End If



            If combo_tipo.Text = "EMPRESA" Then

                lbl_apellidos.Visible = False
                txt_apellidos.Visible = False

                Panel1.Location = New Point(5, 101)
                'lbl_apellidos.Location = New Point(label_apellidos_menos)
                'txt_apellidos.Location = New Point(text_apellidos_menos)
                'lbl_giro.Location = New Point(4, label_giro_menos)
                'txt_giro.Location = New Point(89, text_giro_menos)
                'lbl_telefono.Location = New Point(4, label_telefono_menos)
                'txt_telefono.Location = New Point(89, text_telefono_menos)
                'lbl_email.Location = New Point(4, label_email_menos)
                'txt_email.Location = New Point(89, text_email_menos)
                'lbl_comuna.Location = New Point(4, label_comuna_menos)
                'txt_comuna.Location = New Point(89, text_comuna_menos)
                'lbl_ciudad.Location = New Point(4, label_ciudad_menos)
                'txt_ciudad.Location = New Point(89, text_ciudad_menos)
                'lbl_direccion.Location = New Point(4, label_direccion_menos)
                'txt_direccion.Location = New Point(89, text_direccion_menos)
                'lbl_descto1.Location = New Point(4, label_descto1_menos)
                'txt_dscto1.Location = New Point(89, text_dscto1_menos)
                'lbl_descto2.Location = New Point(4, label_descto2_menos)
                'txt_dscto2.Location = New Point(89, text_dscto2_menos)
                'lbl_folio.Location = New Point(4, label_folio_menos)
                'txt_folio.Location = New Point(89, text_folio_menos)
                'lbl_tipo_cuenta.Location = New Point(4, label_tipo_cuenta_menos)
                'Combo_tipo_cuenta.Location = New Point(89, Combobox_tipo_cuenta_menos)
                'lbl_orden.Location = New Point(4, label_orden_menos)
                'Combo_orden.Location = New Point(89, Combobox_orden_menos)
                'lbl_cupo.Location = New Point(4, label_cupo_menos)
                'txt_cupo.Location = New Point(89, text_cupo_menos)
                'lbl_cuenta.Location = New Point(4, label_cuenta_menos)
                'Combo_cuenta.Location = New Point(89, Combobox_cuenta_menos)
                'lbl_activo.Location = New Point(4, label_activo_menos)
                'Combo_activo.Location = New Point(89, Combobox_activo_menos)
                'lbl_directo.Location = New Point(241, label_directo_menos)
                'lbl_fin_de_mes.Location = New Point(241, label_fin_de_mes_menos)










                'btn_guardar.Location = New Point(7, 470)
                'btn_cancelar.Location = New Point(7, 518)
                'btn_salir.Location = New Point(7, 560)

                'GroupBox_clientes.Width = (488)
                'GroupBox_clientes.Height = (548)
                'GroupBox_posicion.Location = New Point(7, 605)
                'GroupBox_botones.Width = (109)
                'GroupBox_botones.Height = (608)
                'Me.Width = (621)
                'Me.Height = (700)
                Exit Sub
            End If





            If combo_tipo.Text = "TIPO CUENTA" Then
                lbl_apellidos.Visible = False
                txt_apellidos.Visible = False

                Panel1.Location = New Point(5, 101)

                ''lbl_apellidos.Location = New Point(label_apellidos_menos)
                ''txt_apellidos.Location = New Point(text_apellidos_menos)
                'lbl_giro.Location = New Point(4, label_giro_menos)
                'txt_giro.Location = New Point(89, text_giro_menos)
                'lbl_telefono.Location = New Point(4, label_telefono_menos)
                'txt_telefono.Location = New Point(89, text_telefono_menos)
                'lbl_email.Location = New Point(4, label_email_menos)
                'txt_email.Location = New Point(89, text_email_menos)
                'lbl_comuna.Location = New Point(4, label_comuna_menos)
                'txt_comuna.Location = New Point(89, text_comuna_menos)
                'lbl_ciudad.Location = New Point(4, label_ciudad_menos)
                'txt_ciudad.Location = New Point(89, text_ciudad_menos)
                'lbl_direccion.Location = New Point(4, label_direccion_menos)
                'txt_direccion.Location = New Point(89, text_direccion_menos)
                'lbl_descto1.Location = New Point(4, label_descto1_menos)
                'txt_dscto1.Location = New Point(89, text_dscto1_menos)
                'lbl_descto2.Location = New Point(4, label_descto2_menos)
                'txt_dscto2.Location = New Point(89, text_dscto2_menos)
                'lbl_folio.Location = New Point(4, label_folio_menos)
                'txt_folio.Location = New Point(89, text_folio_menos)
                'lbl_tipo_cuenta.Location = New Point(4, label_tipo_cuenta_menos)
                'Combo_tipo_cuenta.Location = New Point(89, Combobox_tipo_cuenta_menos)
                'lbl_orden.Location = New Point(4, label_orden_menos)
                'Combo_orden.Location = New Point(89, Combobox_orden_menos)
                'lbl_cupo.Location = New Point(4, label_cupo_menos)
                'txt_cupo.Location = New Point(89, text_cupo_menos)
                'lbl_cuenta.Location = New Point(4, label_cuenta_menos)
                'Combo_cuenta.Location = New Point(89, Combobox_cuenta_menos)
                'lbl_activo.Location = New Point(4, label_activo_menos)
                'Combo_activo.Location = New Point(89, Combobox_activo_menos)
                'lbl_directo.Location = New Point(241, label_directo_menos)
                'lbl_fin_de_mes.Location = New Point(241, label_fin_de_mes_menos)




                'btn_guardar.Location = New Point(7, 470)
                'btn_cancelar.Location = New Point(7, 518)
                'btn_salir.Location = New Point(7, 560)

                'GroupBox_clientes.Width = (488)
                'GroupBox_clientes.Height = (548)
                'GroupBox_posicion.Location = New Point(7, 605)
                'GroupBox_botones.Width = (109)
                'GroupBox_botones.Height = (608)
                'Me.Width = (621)
                'Me.Height = (700)
                Exit Sub
            End If

        End If

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font1 As New Font("arial", 11, FontStyle.Regular)
        Dim Font2 As New Font("arial", 12, FontStyle.Bold)
        Dim Font3 As New Font("arial", 7, FontStyle.Bold)
        Dim Font4 As New Font("arial", 8, FontStyle.Bold)



        Dim im As Image
        Try
            im = Image.FromFile("C:\Sistema de ventas\Logo de empresa\logo_ticket.jpg")
            Dim p As New PointF(535, 10)
            e.Graphics.DrawImage(im, p)
        Catch
        End Try



        Dim rect1 As New Rectangle(10, 15, 250, 15)
        Dim rect2 As New Rectangle(10, 30, 250, 15)
        Dim rect3 As New Rectangle(10, 45, 250, 15)
        Dim rect4 As New Rectangle(10, 60, 250, 15)
        Dim rect5 As New Rectangle(10, 75, 250, 15)
        Dim rect6 As New Rectangle(10, 90, 250, 15)
        Dim rect_titulo As New Rectangle(10, 130, 830, 30)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim stringFormat_logo As New StringFormat()
        stringFormat_logo.Alignment = StringAlignment.Center
        stringFormat_logo.LineAlignment = StringAlignment.Far

        e.Graphics.DrawString(migiroempresa, Font3, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font3, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font3, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font3, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font3, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font3, Brushes.Black, rect6, stringFormat)

        e.Graphics.DrawString("DATOS CLIENTE", Font2, Brushes.Black, rect_titulo, stringFormat)

        e.Graphics.DrawLine(Pens.Black, 10, 160, 820, 160)

        e.Graphics.DrawString("TIPO", Font1, Brushes.Black, 30, 200)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 200)
        e.Graphics.DrawString(combo_tipo.Text, Font1, Brushes.Gray, 200, 200)
        e.Graphics.DrawString("RUT", Font1, Brushes.Black, 30, 220)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 220)
        e.Graphics.DrawString(txt_rut.Text, Font1, Brushes.Gray, 200, 220)
        e.Graphics.DrawString("NOMBRE", Font1, Brushes.Black, 30, 240)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 240)
        e.Graphics.DrawString(txt_nombres.Text, Font1, Brushes.Gray, 200, 240)
        e.Graphics.DrawString("DIRECCION", Font1, Brushes.Black, 30, 260)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 260)
        e.Graphics.DrawString(txt_direccion.Text, Font1, Brushes.Gray, 200, 260)
        e.Graphics.DrawString("TELEFONO", Font1, Brushes.Black, 30, 280)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 280)
        e.Graphics.DrawString(txt_telefono.Text, Font1, Brushes.Gray, 200, 280)
        e.Graphics.DrawString("EMAIL", Font1, Brushes.Black, 30, 300)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 300)
        e.Graphics.DrawString(txt_email.Text, Font1, Brushes.Gray, 200, 300)
        e.Graphics.DrawString("COMUNA", Font1, Brushes.Black, 30, 320)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 320)
        e.Graphics.DrawString(txt_comuna.Text, Font1, Brushes.Gray, 200, 320)
        e.Graphics.DrawString("GIRO", Font1, Brushes.Black, 30, 340)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 340)
        e.Graphics.DrawString(txt_giro.Text, Font1, Brushes.Gray, 200, 340)
    End Sub

    Private Sub btn_nuevo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.GotFocus
        btn_nuevo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nuevo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.LostFocus
        btn_nuevo.BackColor = Color.Transparent
    End Sub

    Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
        btn_modificar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
        btn_modificar.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_eliminar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_eliminar.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_eliminar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_eliminar.BackColor = Color.WhiteSmoke
    'End Sub

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_mensaje_cliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mensaje_cliente.GotFocus
        btn_mensaje_cliente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mensaje_cliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mensaje_cliente.LostFocus
        btn_mensaje_cliente.BackColor = Color.Transparent
    End Sub

    Private Sub btn_aviso_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aviso.GotFocus
        btn_aviso.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_aviso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aviso.LostFocus
        btn_aviso.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_imprimir.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_imprimir.BackColor = Color.WhiteSmoke
    'End Sub

    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        btn_guardar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.LostFocus
        btn_guardar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_primero_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_primero.GotFocus
        btn_primero.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_primero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_primero.LostFocus
        btn_primero.BackColor = Color.Transparent
    End Sub

    Private Sub btn_anterior_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anterior.GotFocus
        btn_anterior.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_anterior_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anterior.LostFocus
        btn_anterior.BackColor = Color.Transparent
    End Sub

    Private Sub btn_siguiente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.GotFocus
        btn_siguiente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_siguiente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.LostFocus
        btn_siguiente.BackColor = Color.Transparent
    End Sub

    Private Sub btn_ultimo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ultimo.GotFocus
        btn_ultimo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_ultimo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ultimo.LostFocus
        btn_ultimo.BackColor = Color.Transparent
    End Sub

    Private Sub txt_ciudad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_ciudad.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_ciudad_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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

    Private Sub txt_ciudad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_ciudad.BackColor = Color.White
    End Sub

    Private Sub txt_ciudad_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_dscto1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_dscto1.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_dscto1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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




    End Sub

    Private Sub txt_dscto1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_dscto1.BackColor = Color.White
    End Sub

    Private Sub txt_dscto1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_dscto2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_dscto2.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_dscto2_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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




    End Sub

    Private Sub txt_dscto2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_dscto2.BackColor = Color.White
    End Sub

    Private Sub txt_dscto2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_folio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_folio.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_folio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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

    Private Sub txt_folio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_folio.BackColor = Color.White
    End Sub

    Private Sub txt_folio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_apellidos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_apellidos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_apellidos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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

    Private Sub txt_apellidos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_apellidos.BackColor = Color.White
    End Sub

    Private Sub txt_apellidos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Form_registro_cuentas_corrientes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub txt_rut_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rut.KeyDown

    End Sub

    Private Sub txt_nombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombres.TextChanged

    End Sub

    Private Sub radio_sin_cuenta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub btn_mensaje_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mensaje_cliente.Click
        If txt_codigo_cliente.Text <> "" Then
            Me.Enabled = False
            Form_editar_mensaje_clientes.Show()
        End If
    End Sub


    Private Sub txt_cupo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Form_buscador_clientes_registro_cuentas_corrientes.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Sub crear_codigo_cliente()




        Dim VarCodProducto As String

        Dim VarCodBuscar As String


        conexion.Close()
        DS1.Tables.Clear()
        DT1.Rows.Clear()
        DT1.Columns.Clear()
        DS1.Clear()
        conexion.Open()
        SC1.Connection = conexion

        SC1.CommandText = "select cod_cliente from clientes where cod_cliente >= '" & (inicio_codigo_cliente) & "' order by cod_cliente asc"

        DA1.SelectCommand = SC1
        DA1.Fill(DT1)
        DS1.Tables.Add(DT1)
        grilla.DataSource = DS1.Tables(DT1.TableName)
        conexion.Close()


        VarCodBuscar = inicio_codigo_cliente

        For i = 0 To grilla.Rows.Count - 1

            VarCodProducto = grilla.Rows(i).Cells(0).Value.ToString

            If VarCodBuscar <> VarCodProducto Then
                txt_codigo_cliente.Text = VarCodBuscar
                Exit Sub
            End If

            VarCodBuscar = VarCodBuscar + 1

        Next

        'VarCodBuscar = VarCodBuscar + 1

        txt_codigo_cliente.Text = VarCodBuscar

        Exit Sub



    End Sub




    Private Sub Combo_cuenta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Combo_cuenta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_cuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Combo_cuenta.BackColor = Color.White
    End Sub


    Private Sub Combo_activo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Combo_activo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_activo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Combo_activo.BackColor = Color.White
    End Sub




    Private Sub Combo_cuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_pagare_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pagare.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

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
    End Sub

    Private Sub txt_pagare_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pagare.TextChanged

    End Sub

    Private Sub btn_aviso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aviso.Click
        Form_cobranzas.Show()
        Form_cobranzas.txt_rut_cliente.Text = txt_rut.Text

        If Form_cobranzas.txt_rut_cliente.Text <> "" Then
            Form_cobranzas.cargar_detalle()
            Form_cobranzas.mostrar_datos_clientes()
            Form_cobranzas.combo_tipo.SelectedItem = "-"
            Form_cobranzas.grilla_cobranzas.Columns(0).Width = 300
            Form_cobranzas.grilla_cobranzas.Columns(1).Width = 450
            Form_cobranzas.grilla_cobranzas.Columns(2).Width = 110
            Form_cobranzas.grilla_cobranzas.Columns(3).Width = 108
            Form_cobranzas.grilla_cobranzas.Columns(4).Width = 110
            Form_cobranzas.txt_detalle.Focus()
        End If

        Form_cobranzas.WindowState = FormWindowState.Normal
    End Sub

    Private Sub txt_telefono_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_telefono.KeyPress

    End Sub

    Private Sub txt_telefono_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_telefono.TextChanged

    End Sub

    Private Sub btn_empresas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_empresas.Click
        Form_empresas_relacionadas.Show()
        Me.Enabled = False
    End Sub


    Sub restriccion_clientes()
        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()

        SC2.Connection = conexion
        SC2.CommandText = "select * from valores"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)

        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            restriccion_ingreso_clientes = DS2.Tables(DT2.TableName).Rows(0).Item("restriccion_ingreso_clientes")
        End If
        conexion.Close()
    End Sub
End Class