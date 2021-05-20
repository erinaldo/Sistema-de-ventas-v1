Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_registro_valores

    Private Sub Form_registro_valores_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        limpiar()
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_registro_valores_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        limpiar()
    End Sub

    Private Sub Form_registro_valores_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_registro_valores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        controles(False, True)
        cargar_logo()
        mostrar_valores()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)
        btn_modificar.Enabled = b
        btn_guardar.Enabled = a
        btn_cancelar.Enabled = a
        '   txt_factor_hora_extra.Enabled = a
        txt_factor_venta.Enabled = a
        txt_iva.Enabled = a
        Combo_stock.Enabled = a
        ' txt_salud_fonasa.Enabled = a
        ' txt_seguro_cesantia.Enabled = a
        txt_descuento_ventas.Enabled = a
        txt_sugerir_codigo.Enabled = a
        txt_descuento_maximo.Enabled = a
        txt_descuento_maximo_columna.Enabled = a
        Combo_ingreso.Enabled = a
        Combo_vuelto.Enabled = a
        Combo_redondear_venta.Enabled = a
        Combo_restrinccion_clientes.Enabled = a
    End Sub

    Sub limpiar()
        ' txt_factor_hora_extra.Text = ""
        txt_factor_venta.Text = ""
        txt_iva.Text = ""
        txt_sugerir_codigo.Text = ""
        '  txt_seguro_cesantia.Text = ""
        '  txt_sueldo_minimo.Text = ""
        txt_descuento_ventas.Text = ""
        txt_descuento_maximo.Text = ""
        txt_descuento_maximo_columna.Text = ""
        Combo_stock.Text = "-"

        Combo_ingreso.Text = "-"
        Combo_vuelto.Text = "-"
        Combo_redondear_venta.Text = "-"
        Combo_restrinccion_clientes.Text = "-"
    End Sub

    Sub mostrar_valores()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from VALORES"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            '  txt_factor_hora_extra.Text = DS.Tables(DT.TableName).Rows(0).Item("valor_hora_extra")
            txt_factor_venta.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
            txt_iva.Text = DS.Tables(DT.TableName).Rows(0).Item("iva")
            '   txt_salud_fonasa.Text = DS.Tables(DT.TableName).Rows(0).Item("salud_fonasa")
            '   txt_seguro_cesantia.Text = DS.Tables(DT.TableName).Rows(0).Item("seguro_cesantia")
            txt_descuento_ventas.Text = DS.Tables(DT.TableName).Rows(0).Item("valor_descuento_ventas")
            txt_sugerir_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("inicio_sugerir_codigo")
            txt_descuento_maximo.Text = DS.Tables(DT.TableName).Rows(0).Item("valor_descuento_maximo")
            txt_descuento_maximo_columna.Text = DS.Tables(DT.TableName).Rows(0).Item("valor_descuento_maximo_columna")
            Combo_stock.Text = DS.Tables(DT.TableName).Rows(0).Item("venta_sin_stock")
            Combo_ingreso.Text = DS.Tables(DT.TableName).Rows(0).Item("ingreso_rapido")
            Combo_vuelto.Text = DS.Tables(DT.TableName).Rows(0).Item("vuelto")
            Combo_redondear_venta.Text = DS.Tables(DT.TableName).Rows(0).Item("redondear_venta")
            Combo_restrinccion_clientes.Text = DS.Tables(DT.TableName).Rows(0).Item("restriccion_ingreso_clientes")
        End If
        conexion.Close()
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        controles(True, False)
        txt_factor_venta.Focus()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        controles(False, True)
    End Sub

    Private Sub txt_factor_venta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_factor_venta.GotFocus
        txt_factor_venta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_factor_venta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_factor_venta.KeyPress
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

    Private Sub txt_factor_venta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_factor_venta.LostFocus
        txt_factor_venta.BackColor = Color.White

        Dim primer_caracter As String
        Dim ultimo_caracter As String
        Dim total_caracter As String
        total_caracter = ""

        If txt_factor_venta.Text = "" Then
            primer_caracter = 0
            ultimo_caracter = 0
        Else
            primer_caracter = txt_factor_venta.Text.Length - txt_factor_venta.Text.Length + 1
            ultimo_caracter = txt_factor_venta.Text.Length
            total_caracter = txt_factor_venta.Text
        End If

        Dim n1 As Byte, lMal As Boolean

        If txt_factor_venta.Text <> "" Then

            For n1 = ultimo_caracter To ultimo_caracter
                If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
                    MsgBox("LA COMA NO PUEDE IR AL FINAL", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                    txt_factor_venta.Focus()
                    lMal = True
                    Exit Sub
                End If
            Next

            For n1 = 1 To 1
                If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
                    MsgBox("LA COMA NO PUEDE IR AL COMIENZO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                    txt_factor_venta.Focus()
                    lMal = True
                    Exit Sub
                End If
            Next
        End If

        Dim var_suma As String
        var_suma = txt_factor_venta.Text

        Try
            var_suma = var_suma + 1
        Catch err As InvalidCastException
            MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
            txt_factor_venta.Focus()
            Exit Sub
        End Try
    End Sub

    Private Sub txt_iva_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_iva.GotFocus
        txt_iva.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_iva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_iva.KeyPress
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

    Private Sub txt_iva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_iva.LostFocus
        txt_iva.BackColor = Color.White

        Dim primer_caracter As String
        Dim ultimo_caracter As String
        Dim total_caracter As String
        total_caracter = ""
        If txt_iva.Text = "" Then
            primer_caracter = 0
            ultimo_caracter = 0
        Else
            primer_caracter = txt_iva.Text.Length - txt_iva.Text.Length + 1
            ultimo_caracter = txt_iva.Text.Length
            total_caracter = txt_iva.Text
        End If

        Dim n1 As Byte, lMal As Boolean

        If txt_iva.Text <> "" Then
            For n1 = ultimo_caracter To ultimo_caracter
                If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
                    MsgBox("LA COMA NO PUEDE IR AL FINAL", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                    txt_iva.Focus()
                    lMal = True
                    Exit Sub
                End If
            Next

            For n1 = 1 To 1
                If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
                    MsgBox("LA COMA NO PUEDE IR AL COMIENZO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                    txt_iva.Focus()
                    lMal = True
                    Exit Sub
                End If
            Next
        End If

        Dim var_suma As String
        var_suma = txt_iva.Text

        Try
            var_suma = var_suma + 1
        Catch err As InvalidCastException
            MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
            txt_iva.Focus()
            Exit Sub
        End Try
    End Sub

    'Private Sub txt_sueldo_minimo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_sueldo_minimo.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub txt_sueldo_minimo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_sueldo_minimo.BackColor = Color.White

    '    Dim primer_caracter As String
    '    Dim ultimo_caracter As String
    '    Dim total_caracter As String

    '    If txt_sueldo_minimo.Text = "" Then
    '        primer_caracter = 0
    '        ultimo_caracter = 0
    '    Else
    '        primer_caracter = txt_sueldo_minimo.Text.Length - txt_sueldo_minimo.Text.Length + 1
    '        ultimo_caracter = txt_sueldo_minimo.Text.Length
    '        total_caracter = txt_sueldo_minimo.Text
    '    End If

    '    Dim n1 As Byte, lMal As Boolean

    '    If txt_sueldo_minimo.Text <> "" Then

    '        For n1 = ultimo_caracter To ultimo_caracter
    '            If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
    '                MsgBox("LA COMA NO PUEDE IR AL FINAL", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
    '                txt_sueldo_minimo.Focus()
    '                lMal = True
    '                Exit Sub
    '            End If
    '        Next

    '        For n1 = 1 To 1
    '            If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
    '                MsgBox("LA COMA NO PUEDE IR AL COMIENZO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
    '                txt_sueldo_minimo.Focus()
    '                lMal = True
    '                Exit Sub
    '            End If
    '        Next
    '    End If

    '    Dim var_suma As String
    '    var_suma = txt_sueldo_minimo.Text

    '    Try
    '        var_suma = var_suma + 1
    '    Catch err As InvalidCastException
    '        MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
    '        txt_sueldo_minimo.Focus()
    '        Exit Sub
    '    End Try
    'End Sub

    'Private Sub txt_valor_uf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_valor_uf.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub txt_valor_uf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_valor_uf.BackColor = Color.White

    '    Dim primer_caracter As String
    '    Dim ultimo_caracter As String
    '    Dim total_caracter As String

    '    If txt_valor_uf.Text = "" Then
    '        primer_caracter = 0
    '        ultimo_caracter = 0
    '    Else
    '        primer_caracter = txt_valor_uf.Text.Length - txt_valor_uf.Text.Length + 1
    '        ultimo_caracter = txt_valor_uf.Text.Length
    '        total_caracter = txt_valor_uf.Text
    '    End If

    '    Dim n1 As Byte, lMal As Boolean

    '    If txt_valor_uf.Text <> "" Then

    '        For n1 = ultimo_caracter To ultimo_caracter
    '            If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
    '                MsgBox("LA COMA NO PUEDE IR AL FINAL", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
    '                txt_valor_uf.Focus()
    '                lMal = True
    '                Exit Sub
    '            End If
    '        Next

    '        For n1 = 1 To 1
    '            If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
    '                MsgBox("LA COMA NO PUEDE IR AL COMIENZO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
    '                txt_valor_uf.Focus()
    '                lMal = True
    '                Exit Sub
    '            End If
    '        Next
    '    End If

    '    Dim var_suma As String
    '    var_suma = txt_valor_uf.Text

    '    Try
    '        var_suma = var_suma + 1
    '    Catch err As InvalidCastException
    '        MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
    '        txt_valor_uf.Focus()
    '        Exit Sub
    '    End Try
    'End Sub

    'Private Sub txt_seguro_cesantia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_seguro_cesantia.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub txt_seguro_cesantia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_seguro_cesantia.BackColor = Color.White

    '    Dim primer_caracter As String
    '    Dim ultimo_caracter As String
    '    Dim total_caracter As String

    '    If txt_seguro_cesantia.Text = "" Then
    '        primer_caracter = 0
    '        ultimo_caracter = 0
    '    Else
    '        primer_caracter = txt_seguro_cesantia.Text.Length - txt_seguro_cesantia.Text.Length + 1
    '        ultimo_caracter = txt_seguro_cesantia.Text.Length
    '        total_caracter = txt_seguro_cesantia.Text
    '    End If

    '    Dim n1 As Byte, lMal As Boolean

    '    If txt_seguro_cesantia.Text <> "" Then

    '        For n1 = ultimo_caracter To ultimo_caracter
    '            If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
    '                MsgBox("LA COMA NO PUEDE IR AL FINAL", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
    '                txt_seguro_cesantia.Focus()
    '                lMal = True
    '                Exit Sub
    '            End If
    '        Next

    '        For n1 = 1 To 1
    '            If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
    '                MsgBox("LA COMA NO PUEDE IR AL COMIENZO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
    '                txt_seguro_cesantia.Focus()
    '                lMal = True
    '                Exit Sub
    '            End If
    '        Next
    '    End If

    '    Dim var_suma As String
    '    var_suma = txt_seguro_cesantia.Text

    '    Try
    '        var_suma = var_suma + 1
    '    Catch err As InvalidCastException
    '        MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
    '        txt_seguro_cesantia.Focus()
    '        Exit Sub
    '    End Try
    'End Sub

    'Private Sub txt_factor_hora_extra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_factor_hora_extra.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub txt_factor_hora_extra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_factor_hora_extra.BackColor = Color.White

    '    Dim primer_caracter As String
    '    Dim ultimo_caracter As String
    '    Dim total_caracter As String

    '    If txt_factor_hora_extra.Text = "" Then
    '        primer_caracter = 0
    '        ultimo_caracter = 0
    '    Else
    '        primer_caracter = txt_factor_hora_extra.Text.Length - txt_factor_hora_extra.Text.Length + 1
    '        ultimo_caracter = txt_factor_hora_extra.Text.Length
    '        total_caracter = txt_factor_hora_extra.Text
    '    End If

    '    Dim n1 As Byte, lMal As Boolean

    '    If txt_factor_hora_extra.Text <> "" Then

    '        For n1 = ultimo_caracter To ultimo_caracter
    '            If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
    '                MsgBox("LA COMA NO PUEDE IR AL FINAL", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
    '                txt_factor_hora_extra.Focus()
    '                lMal = True
    '                Exit Sub
    '            End If
    '        Next

    '        For n1 = 1 To 1
    '            If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
    '                MsgBox("LA COMA NO PUEDE IR AL COMIENZO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
    '                txt_factor_hora_extra.Focus()
    '                lMal = True
    '                Exit Sub
    '            End If
    '        Next
    '    End If

    '    Dim var_suma As String
    '    var_suma = txt_factor_hora_extra.Text

    '    Try
    '        var_suma = var_suma + 1
    '    Catch err As InvalidCastException
    '        MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
    '        txt_factor_hora_extra.Focus()
    '        Exit Sub
    '    End Try
    'End Sub

    'Private Sub txt_salud_fonasa_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_salud_fonasa.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub txt_salud_fonasa_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txt_salud_fonasa.BackColor = Color.White

    '    Dim primer_caracter As String
    '    Dim ultimo_caracter As String
    '    Dim total_caracter As String

    '    If txt_salud_fonasa.Text = "" Then
    '        primer_caracter = 0
    '        ultimo_caracter = 0
    '    Else
    '        primer_caracter = txt_salud_fonasa.Text.Length - txt_salud_fonasa.Text.Length + 1
    '        ultimo_caracter = txt_salud_fonasa.Text.Length
    '        total_caracter = txt_salud_fonasa.Text
    '    End If

    '    Dim n1 As Byte, lMal As Boolean

    '    If txt_salud_fonasa.Text <> "" Then

    '        For n1 = ultimo_caracter To ultimo_caracter
    '            If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
    '                MsgBox("LA COMA NO PUEDE IR AL FINAL", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
    '                txt_salud_fonasa.Focus()
    '                lMal = True
    '                Exit Sub
    '            End If
    '        Next

    '        For n1 = 1 To 1
    '            If Not IsNumeric(Mid(total_caracter, n1, 1)) Then
    '                MsgBox("LA COMA NO PUEDE IR AL COMIENZO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
    '                txt_salud_fonasa.Focus()
    '                lMal = True
    '                Exit Sub
    '            End If
    '        Next
    '    End If

    '    Dim var_suma As String
    '    var_suma = txt_salud_fonasa.Text

    '    Try
    '        var_suma = var_suma + 1
    '    Catch err As InvalidCastException
    '        MsgBox("EL VALOR INGRESADO NO ES VALIDO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
    '        txt_salud_fonasa.Focus()
    '        Exit Sub
    '    End Try
    'End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click


        If txt_factor_venta.Text = "" Then
            MsgBox("CAMPO FACTOR VENTA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_factor_venta.Focus()
            Exit Sub
        End If

        If txt_descuento_maximo.Text = "" Then
            MsgBox("CAMPO DESCUENTO MAXIMO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_descuento_maximo.Focus()
            Exit Sub
        End If

        If txt_descuento_maximo_columna.Text = "" Then
            MsgBox("CAMPO DESCUENTO MAXIMO POR COLUMNA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_descuento_maximo_columna.Focus()
            Exit Sub
        End If

        If txt_iva.Text = "" Then
            MsgBox("CAMPO IVA MAXIMO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_iva.Focus()
            Exit Sub
        End If

        If txt_sugerir_codigo.Text = "" Then
            MsgBox("CAMPO SUGERIR CODIGO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_sugerir_codigo.Focus()
            Exit Sub
        End If

        If Combo_stock.Text = "-" Then
            MsgBox("CAMPO VENTA SIN STOCK VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_stock.Focus()
            Exit Sub
        End If

        If Combo_ingreso.Text = "-" Then
            MsgBox("CAMPO INGRESO RAPIDO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_ingreso.Focus()
            Exit Sub
        End If

        If Combo_vuelto.Text = "-" Then
            MsgBox("CAMPO VUELTO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_vuelto.Focus()
            Exit Sub
        End If

        If Combo_redondear_venta.Text = "-" Then
            MsgBox("CAMPO REDONDEAR VENTA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_redondear_venta.Focus()
            Exit Sub
        End If

        If Combo_restrinccion_clientes.Text = "-" Then
            MsgBox("CAMPO RESTRICCION CLIENTES VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_restrinccion_clientes.Focus()
            Exit Sub
        End If

        SC.Connection = conexion
        SC.CommandText = "UPDATE VALORES SET restriccion_ingreso_clientes='" & (Combo_restrinccion_clientes.Text) & "', redondear_venta='" & (Combo_redondear_venta.Text) & "',  ingreso_rapido='" & (Combo_ingreso.Text) & "', vuelto='" & (Combo_vuelto.Text) & "', valor_descuento_maximo='" & (txt_descuento_maximo.Text) & "', factor='" & (txt_factor_venta.Text) & "', iva='" & (txt_iva.Text) & "' , valor_descuento_maximo_columna='" & (txt_descuento_maximo_columna.Text) & "' , inicio_sugerir_codigo='" & (txt_sugerir_codigo.Text) & "' , venta_sin_stock='" & (Combo_stock.Text) & "', valor_descuento_ventas='" & (txt_descuento_ventas.Text) & "'  where cod_auto <> '0'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, tipo, usuario_responsable) values('VALORES','MODIFICACION DE VALORES','VALORES','" & (Form_menu_principal.dtp_fecha.Text) & "',',MODIFICACION','" & (miusuario) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        controles(False, True)

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
            valor_iva = DS2.Tables(DT2.TableName).Rows(0).Item("iva")
            valor_descuento_maximo = DS2.Tables(DT2.TableName).Rows(0).Item("valor_descuento_maximo")
            valor_descuento_ventas = DS2.Tables(DT2.TableName).Rows(0).Item("valor_descuento_ventas")
            valor_descuento_maximo_columna = DS2.Tables(DT2.TableName).Rows(0).Item("valor_descuento_maximo_columna")
            valor_factor = DS2.Tables(DT2.TableName).Rows(0).Item("factor")
            tiempo_espera = DS2.Tables(DT2.TableName).Rows(0).Item("tiempo_espera")
            inicio_sugerir_codigo = DS2.Tables(DT2.TableName).Rows(0).Item("inicio_sugerir_codigo")
            venta_sin_stock = DS2.Tables(DT2.TableName).Rows(0).Item("venta_sin_stock")
        End If
        conexion.Close()

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
        btn_modificar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
        btn_modificar.BackColor = Color.Transparent
    End Sub

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

    Private Sub txt_factor_venta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_factor_venta.TextChanged

    End Sub

    Private Sub txt_iva_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_iva.TextChanged

    End Sub

    Private Sub txt_sueldo_minimo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_valor_uf_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_seguro_cesantia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_factor_hora_extra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_salud_fonasa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub txt_descuento_maximo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descuento_maximo.KeyPress
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
    End Sub

    Private Sub txt_descuento_maximo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descuento_maximo.GotFocus
        txt_descuento_maximo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_descuento_maximo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descuento_maximo.LostFocus
        txt_descuento_maximo.BackColor = Color.White
    End Sub

    Private Sub txt_descuento_maximo_columna_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descuento_maximo_columna.GotFocus
        txt_descuento_maximo_columna.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_descuento_maximo_columna_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descuento_maximo_columna.LostFocus
        txt_descuento_maximo_columna.BackColor = Color.White
    End Sub

    Private Sub txt_descuento_maximo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descuento_maximo.TextChanged

    End Sub

    Private Sub txt_descuento_maximo_columna_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descuento_maximo_columna.KeyPress
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
    End Sub

    Private Sub txt_descuento_maximo_columna_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descuento_maximo_columna.TextChanged

    End Sub




    Private Sub txt_sugerir_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_sugerir_codigo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_sugerir_codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_sugerir_codigo.TextChanged

    End Sub


    Private Sub txt_sugerir_codigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_sugerir_codigo.GotFocus
        txt_sugerir_codigo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_sugerir_codigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_sugerir_codigo.LostFocus
        txt_sugerir_codigo.BackColor = Color.White
    End Sub

    Private Sub txt_descuento_ventas_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descuento_ventas.GotFocus
        txt_descuento_ventas.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub ttxt_descuento_ventas_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_descuento_ventas.LostFocus
        txt_descuento_ventas.BackColor = Color.White
    End Sub

    Private Sub txt_descuento_ventas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descuento_ventas.KeyPress
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
    End Sub

    Private Sub txt_descuento_ventas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descuento_ventas.TextChanged

    End Sub
End Class