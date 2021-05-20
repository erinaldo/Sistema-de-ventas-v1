Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Math
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient
Imports System.Resources
Public Class Form_consumo_interno
    Private WithEvents Pd As New PrintDocument
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim mifecha6 As String

    Private Sub Form_consumo_interno_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_consumo_interno_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

        If e.KeyCode = Keys.F1 Then
            txt_codigo.Focus()
        End If
    End Sub

    Private Sub Form_consumo_interno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_responsable()
        'dtp_fecha.CustomFormat = "yyy-MM-dd"
        grilla_consumo_interno.Font = New System.Drawing.Font("Arial", 10.25!, System.Drawing.FontStyle.Regular)
        dtp_ultima_compra.CustomFormat = "yyy-MM-dd"

        mostrar_malla()

        Timer_cierre.Start()

        If mirutempresa = "87686300-6" Then
            btn_imprimir.Visible = True
        Else
            btn_imprimir.Visible = False
        End If
        Combo_motivo.SelectedItem = "-"


        If tipo_usuario = "ADMINISTRADOR DEL SISTEMA" Then
            btn_quitar_elemento.Enabled = True
        Else
            btn_quitar_elemento.Enabled = False
        End If
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub



    Sub mostrar_malla()

        Dim costo As Integer = 0
        Dim cantidad As Integer = 0
        Dim total As Integer = 0

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from consumo_interno_temporal, productos, USUARIOS  WHERE ESTADO = 'EMITIDA' and consumo_interno_temporal.codigo_producto=productos.cod_producto AND consumo_interno_temporal.usuario_responsable=usuarios.rut_usuario ORDER by n_consumo_interno"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_consumo_interno.Rows.Clear()

        Dim fecha_envio As String

        If DS.Tables(DT.TableName).Rows.Count > 0 Then


            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                fecha_envio = DS.Tables(DT.TableName).Rows(i).Item("fecha")

                If fecha_envio.Length > 10 Then
                    fecha_envio = fecha_envio.Substring(0, 10)
                End If

                costo = DS.Tables(DT.TableName).Rows(i).Item("costo")
                cantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
                total = Val(costo) * Val(cantidad)

                grilla_consumo_interno.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_auto"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("codigo_producto"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("nombre"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("aplicacion"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                      fecha_envio, _
                                                       DS.Tables(DT.TableName).Rows(i).Item("hora"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("motivo"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("costo"), _
                                                           total)
            Next
        End If


        txt_item.Text = grilla_consumo_interno.Rows.Count



        Me.grilla_consumo_interno.Columns(0).Width = grilla_consumo_interno.Columns(0).Width
        Me.grilla_consumo_interno.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Me.grilla_consumo_interno.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.grilla_consumo_interno.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' Me.grilla_consumo_interno.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight



    End Sub


    Sub mostrar_datos_productos()

        If txt_codigo.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_nombre.Text = ""
                    txt_marca.Text = ""
                    txt_aplicacion.Text = ""
                    txt_numero_tecnico.Text = ""
                    'combo_familia.Text = ""
                    'combo_subfamilia.Text = ""
                    txt_cantidad.Text = ""
                    txt_factor.Text = ""
                    txt_costo.Text = ""
                    txt_rut_proveedor.Text = ""
                    txt_precio.Text = ""
                    txt_codigo_barra.Text = ""
                    dtp_ultima_compra.Text = ""
                    txt_cantidad_ultima_compra.Text = ""
                    txt_nro_doc.Text = ""
                    txt_tipo_doc.Text = ""
                    txt_cantidad_minima.Text = ""


                    'combo_familia.Text = "-"
                    'combo_subfamilia.Text = "-"
                    'Combo_subfamilia_2.Text = "-"

                    txt_codigo_familia.Text = "-"
                    txt_codigo_subfamilia.Text = "-"
                    txt_codigo_subfamilia_2.Text = "-"

                    txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    txt_nombre.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                    txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                    txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                    'combo_familia.Text = DS.Tables(DT.TableName).Rows(0).Item("familia")
                    'combo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
                    txt_stock.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                    txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                    txt_costo.Text = DS.Tables(DT.TableName).Rows(0).Item("costo")
                    txt_rut_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("proveedor")
                    txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                    txt_codigo_barra.Text = DS.Tables(DT.TableName).Rows(0).Item("codigo_barra")
                    dtp_ultima_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("ultima_compra")
                    txt_cantidad_ultima_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_ultima_compra")
                    txt_nro_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("nro_doc")
                    txt_tipo_doc.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_doc")
                    txt_cantidad_minima.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad_minima")
                    txt_codigo_familia.Text = DS.Tables(DT.TableName).Rows(0).Item("familia")
                    txt_codigo_subfamilia.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia")
                    txt_codigo_subfamilia_2.Text = DS.Tables(DT.TableName).Rows(0).Item("subfamilia_dos")
                    txt_tipo_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_precio")

                    If DS.Tables(DT.TableName).Rows(0).Item("tipo_precio") = "1" Then
                        Combo_tipo_precio.Text = "FACTOR"
                    End If

                    If DS.Tables(DT.TableName).Rows(0).Item("tipo_precio") = "2" Then
                        Combo_tipo_precio.Text = "DIRECTO"
                    End If

                Else
                    MsgBox("CODIGO NO EXISTENTE", 0 + 16, "ERROR")
                    conexion.Close()
                End If

            Catch err As InvalidCastException
                '    txt_factura.Text = 1
                conexion.Close()
                Exit Sub
            End Try
            conexion.Close()
        End If

    End Sub

    Sub limpiar_producto()

        txt_stock.Text = ""
        txt_nombre.Text = ""
        txt_marca.Text = ""
        txt_aplicacion.Text = ""
        txt_precio.Text = ""
        txt_numero_tecnico.Text = ""
        txt_factor.Text = ""
        txt_cantidad.Text = ""
        txt_costo.Text = ""
        txt_rut_proveedor.Text = ""
        txt_nombre.Text = ""
        txt_codigo_barra.Text = ""
        dtp_ultima_compra.Text = ""
        txt_cantidad_ultima_compra.Text = ""
        txt_nro_doc.Text = ""
        txt_tipo_doc.Text = ""
        dtp_ultima_compra.Text = ""
        txt_cantidad_ultima_compra.Text = ""
        txt_nro_doc.Text = ""
        txt_tipo_doc.Text = ""
    End Sub

    Sub limpiar()

        Combo_motivo.Text = "-"
        Combo_responsable.Text = "-"

        txt_nombre.Text = ""
        txt_marca.Text = ""
        txt_aplicacion.Text = ""
        txt_precio.Text = ""
        txt_numero_tecnico.Text = ""
        txt_factor.Text = ""
        txt_cantidad.Text = ""
        txt_costo.Text = ""
        txt_rut_proveedor.Text = ""
        txt_proveedor.Text = ""
        txt_codigo_barra.Text = ""
        txt_codigo.Text = ""
        dtp_ultima_compra.Text = ""
        txt_cantidad_ultima_compra.Text = ""
        txt_nro_doc.Text = ""
        txt_tipo_doc.Text = ""
        dtp_ultima_compra.Text = ""
        txt_cantidad_ultima_compra.Text = ""
        txt_nro_doc.Text = ""
        txt_tipo_doc.Text = ""
        txt_stock.Text = ""

    End Sub


    Private Sub txt_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo.KeyPress

        limpiar_producto()

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

            mostrar_datos_productos()
            mostrar_nombre_proveedor()
            '  txt_codigo.Enabled = False
            '    txt_nombre.Enabled = True
            ' txt_codigo_barra.Enabled = True
            '  COMBO.Focus()
            txt_cantidad.Focus()
        End If

    End Sub

    Private Sub txt_codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo.TextChanged

    End Sub

    Private Sub txt_cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad.KeyPress

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

        e.KeyChar = e.KeyChar.ToString.ToUpper

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Combo_responsable.Focus()
            Combo_responsable.DroppedDown = True
        End If
    End Sub


    Private Sub txt_cantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad.TextChanged

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub






    Sub totales()
        txt_total.Text = Int(txt_cantidad.Text) - Int(txt_precio.Text)

        Dim iva As Integer
        Dim neto As Integer
        Dim iva_valor As String

        iva_valor = valor_iva / 100 + 1
        neto = (txt_total.Text / iva_valor)
        Round(neto)
        txt_neto.Text = neto

        iva = ((txt_neto.Text) * valor_iva / 100)
        Round(iva)
        txt_iva.Text = iva
    End Sub


    Sub crear_nro_vale()
        Dim VarNumVale As String

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        Try
            SC.Connection = conexion
            SC.CommandText = "select max(n_consumo_interno) as n_consumo_interno from consumo_interno"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                VarNumVale = DS.Tables(DT.TableName).Rows(0).Item("n_consumo_interno")
                txt_nro_vale.Text = VarNumVale + 1
            End If
        Catch err As InvalidCastException
            txt_nro_vale.Text = 1
        End Try
        conexion.Close()
    End Sub

    Private Sub txt_codigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.GotFocus
        txt_codigo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.LostFocus
        txt_codigo.BackColor = Color.White
    End Sub

    Private Sub txt_cantidad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad.GotFocus
        txt_cantidad.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_cantidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad.LostFocus
        txt_cantidad.BackColor = Color.White
        'Combo_vendedor.DroppedDown = True
    End Sub

    Private Sub Combo_vendedor_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' If Not Combo_vendedor.DroppedDown Then



    End Sub



    Private Sub Combo_vendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then

            btn_agregar.Focus()

        End If
    End Sub


    'Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_guardarR.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_guardarR.BackColor = Color.Transparent
    'End Sub

    'Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_salir.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_salir.BackColor = Color.Transparent
    'End Sub

    Private Sub btn_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.GotFocus
        btn_agregar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_agregar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.LostFocus
        btn_agregar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_quitar_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.GotFocus
        btn_quitar_elemento.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_responsable_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_responsable.KeyPress
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
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Combo_motivo.Focus()
            Combo_motivo.DroppedDown = True
        End If
    End Sub

    Private Sub Combo_responsable_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_responsable.LostFocus
        Combo_responsable.BackColor = Color.White
    End Sub

    Private Sub Combo_responsable_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_responsable.GotFocus
        Combo_responsable.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_motivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Combo_motivo.KeyPress
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
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btn_agregar.Focus()
        End If
    End Sub

    Private Sub Combo_motivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_motivo.LostFocus
        Combo_motivo.BackColor = Color.White
    End Sub

    Private Sub Combo_motivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_motivo.GotFocus
        Combo_motivo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_quitar_elemento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.LostFocus
        btn_quitar_elemento.BackColor = Color.Transparent
    End Sub

    Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        btn_imprimir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_sucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btn_agregar.Focus()
        End If
    End Sub

    Private Sub btn_quitar_elemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If grilla_consumo_interno.Rows.Count > 0 Then
            Form_autorizacion_traspaso.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub txt_codigo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            Form_buscador_productos_consumo_interno.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub btn_buscar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        conexion.Close()
        Me.Enabled = False
        txt_codigo.Focus()
        Form_buscador_productos_traspaso_sucursal.Show()
        Form_buscador_productos_traspaso_sucursal.txt_busqueda.Focus()
    End Sub

    Private Sub grilla_estado_de_cuenta_final_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub grilla_estado_de_cuenta_final_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim valormensaje As Integer

        'If grilla_estado_de_cuenta_final.Rows.Count <> 0 Then
        '    valormensaje = MsgBox("¿DESEA REIMPRIMIR EL ENVIO A SUCURSAL?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        '    If valormensaje = vbYes Then
        '        Me.Enabled = False
        '        With Pd.PrinterSettings
        '            ' Especifico el nombre de la impresora 
        '            ' por donde deseo imprimir. 
        '            .PrinterName = impresora_ticket
        '            ' .PrinterName = "\\SERVER\HP LaserJet Professional P 1102w"
        '            ' Establezco el número de copias que se imprimirán 
        '            .Copies = 1
        '            ' Rango de páginas que se imprimirán 
        '            .PrintRange = PrintRange.AllPages
        '            If .IsValid Then


        '                Me.Pd.PrintController = New StandardPrintController
        '                Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
        '                Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
        '                Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
        '                Pd.Print()
        '            Else
        '                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
        '                Me.Enabled = True
        '                Exit Sub
        '            End If
        '        End With
        '        Me.Enabled = True
        '    End If
        'End If
    End Sub

    ' '' '' '' '' '' '' ''Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage

    ' '' '' '' '' '' '' ''    Dim VarNroVale As String
    ' '' '' '' '' '' '' ''    Dim VarDespachadoPor As String
    ' '' '' '' '' '' '' ''    Dim VarCodProducto As String
    ' '' '' '' '' '' '' ''    Dim VarCantidad As String
    ' '' '' '' '' '' '' ''    Dim VarFecha As String
    ' '' '' '' '' '' '' ''    Dim VarHora As String
    ' '' '' '' '' '' '' ''    Dim varnombre As String
    ' '' '' '' '' '' '' ''    Dim vartecnico As String
    ' '' '' '' '' '' '' ''    Dim VarAplicacion As String
    ' '' '' '' '' '' '' ''    Dim VarGeneradoPor As String

    ' '' '' '' '' '' '' ''    Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
    ' '' '' '' '' '' '' ''    Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
    ' '' '' '' '' '' '' ''    Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
    ' '' '' '' '' '' '' ''    Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)



    ' '' '' '' '' '' '' ''    Dim format1 As New StringFormat(StringFormatFlags.NoClip)
    ' '' '' '' '' '' '' ''    format1.Alignment = StringAlignment.Far


    ' '' '' '' '' '' '' ''    Dim Font1 As New Font("arial", 7, FontStyle.Regular)
    ' '' '' '' '' '' '' ''    Dim Font2 As New Font("arial", 9, FontStyle.Bold)
    ' '' '' '' '' '' '' ''    Dim Font3 As New Font("arial", 7, FontStyle.Bold)
    ' '' '' '' '' '' '' ''    Dim Font4 As New Font("arial", 8, FontStyle.Bold)

    ' '' '' '' '' '' '' ''    Dim im As Image

    ' '' '' '' '' '' '' ''    Try
    ' '' '' '' '' '' '' ''        im = Image.FromFile("C:\Sistema de ventas\Logo de empresa\logo_ticket.jpg")
    ' '' '' '' '' '' '' ''        Dim p As New PointF(0, 0)
    ' '' '' '' '' '' '' ''        e.Graphics.DrawImage(im, p)
    ' '' '' '' '' '' '' ''    Catch
    ' '' '' '' '' '' '' ''    End Try

    ' '' '' '' '' '' '' ''    Dim stringFormat As New StringFormat()
    ' '' '' '' '' '' '' ''    stringFormat.Alignment = StringAlignment.Center
    ' '' '' '' '' '' '' ''    stringFormat.LineAlignment = StringAlignment.Center

    ' '' '' '' '' '' '' ''    Dim rect1 As New Rectangle(10, 60, 270, 15)
    ' '' '' '' '' '' '' ''    Dim rect2 As New Rectangle(10, 75, 270, 15)
    ' '' '' '' '' '' '' ''    Dim rect3 As New Rectangle(10, 90, 270, 15)
    ' '' '' '' '' '' '' ''    Dim rect4 As New Rectangle(10, 105, 270, 15)
    ' '' '' '' '' '' '' ''    Dim rect5 As New Rectangle(10, 120, 270, 15)
    ' '' '' '' '' '' '' ''    Dim rect6 As New Rectangle(10, 135, 270, 15)
    ' '' '' '' '' '' '' ''    Dim rect7 As New Rectangle(10, 165, 270, 15)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(migiroempresa, Font3, Brushes.Black, rect1, stringFormat)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(midireccionempresa, Font3, Brushes.Black, rect2, stringFormat)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(miciudadempresa, Font3, Brushes.Black, rect3, stringFormat)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(mitelefonoempresa, Font3, Brushes.Black, rect4, stringFormat)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(micorreoempresa, Font3, Brushes.Black, rect5, stringFormat)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(mirutempresa, Font3, Brushes.Black, rect6, stringFormat)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("ENVIO A SUCURSAL", Font2, Brushes.Black, rect7, stringFormat)





    ' '' '' '' '' '' '' ''    VarCodProducto = Me.grilla_sale.CurrentRow.Cells(0).Value
    ' '' '' '' '' '' '' ''    varnombre = Me.grilla_sale.CurrentRow.Cells(1).Value
    ' '' '' '' '' '' '' ''    vartecnico = Me.grilla_sale.CurrentRow.Cells(2).Value
    ' '' '' '' '' '' '' ''    VarAplicacion = Me.grilla_sale.CurrentRow.Cells(3).Value
    ' '' '' '' '' '' '' ''    VarCantidad = Me.grilla_sale.CurrentRow.Cells(4).Value
    ' '' '' '' '' '' '' ''    VarFecha = Me.grilla_sale.CurrentRow.Cells(5).Value
    ' '' '' '' '' '' '' ''    VarHora = Me.grilla_sale.CurrentRow.Cells(6).Value
    ' '' '' '' '' '' '' ''    VarDespachadoPor = Me.grilla_sale.CurrentRow.Cells(7).Value
    ' '' '' '' '' '' '' ''    VarGeneradoPor = Me.grilla_sale.CurrentRow.Cells(8).Value
    ' '' '' '' '' '' '' ''    VarNroVale = Me.grilla_sale.CurrentRow.Cells(9).Value






    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("NRO. VALE", Font3, Brushes.Black, 0, 195)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 195)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(VarNroVale, Font4, Brushes.Black, 95, 195)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("FECHA", Font3, Brushes.Black, 0, 210)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 210)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(VarFecha & " " & VarHora, Font3, Brushes.Black, 95, 210)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("RETIRADO POR", Font3, Brushes.Black, 0, 225)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 225)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(VarDespachadoPor, Font3, Brushes.Black, 95, 225)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("GENERADO POR", Font3, Brushes.Black, 0, 240)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 240)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(VarGeneradoPor, Font3, Brushes.Black, 95, 240)


    ' '' '' '' '' '' '' ''    e.Graphics.DrawLine(Pens.Black, 1, 260, 295, 260)


    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("CODIGO", Font3, Brushes.Black, 0, 270)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 270)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(VarCodProducto, Font3, Brushes.Black, 95, 270)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("NOMBRE", Font3, Brushes.Black, 0, 285)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 285)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(varnombre, Font3, Brushes.Black, 95, 285)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("NRO. TECNICO", Font3, Brushes.Black, 0, 300)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 300)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(vartecnico, Font3, Brushes.Black, 95, 300)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("APLICACION", Font3, Brushes.Black, 0, 315)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 315)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(VarAplicacion, Font3, Brushes.Black, 95, 315)

    ' '' '' '' '' '' '' ''    Dim cantidad As String
    ' '' '' '' '' '' '' ''    cantidad = VarCantidad
    ' '' '' '' '' '' '' ''    cantidad = Format(Int(cantidad), "###,###,###")

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("CANT.", Font3, Brushes.Black, 0, 330)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(":", Font3, Brushes.Black, 90, 330)
    ' '' '' '' '' '' '' ''    e.Graphics.DrawString(cantidad, Font3, Brushes.Black, 95, 330)


    ' '' '' '' '' '' '' ''    e.Graphics.DrawLine(Pens.Black, 1, 350, 295, 350)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawLine(Pens.Black, 1, 450, 295, 450)

    ' '' '' '' '' '' '' ''    e.Graphics.DrawString("-", Font3, Brushes.Gray, 135, 508)

    ' '' '' '' '' '' '' ''End Sub

    Private Sub Combo_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_nombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre.KeyPress
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

    Private Sub txt_nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre.TextChanged

    End Sub

    Private Sub txt_numero_tecnico_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero_tecnico.KeyPress
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

    Private Sub txt_numero_tecnico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numero_tecnico.TextChanged

    End Sub

    Private Sub txt_aplicacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_aplicacion.KeyPress
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

    Private Sub txt_aplicacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_aplicacion.TextChanged

    End Sub

    Private Sub GroupBox_vendedor_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Sub mostrar_nombre_proveedor()
        conexion.Close()
        If txt_rut_proveedor.Text <> "" Then
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from proveedores where rut_proveedor ='" & (txt_rut_proveedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            txt_proveedor.Text = ""
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_proveedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_proveedor")
            End If
            conexion.Close()
        End If
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If txt_codigo.Text = "" Then
            MsgBox("CAMPO CODIGO PRODUCTO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_codigo.Focus()
            Exit Sub
        End If

        If txt_nombre.Text = "" Then
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_nombre.Focus()
            Exit Sub
        End If

        If txt_cantidad.Text = "" Then
            MsgBox("CAMPO CANTIDAD VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_cantidad.Focus()
            Exit Sub
        End If

        If Combo_responsable.Text = "" Then
            MsgBox("CAMPO RESPONSABLE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_responsable.Focus()
            Exit Sub
        End If

        If Combo_responsable.Text = "-" Then
            MsgBox("CAMPO RESPONSABLE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_responsable.Focus()
            Exit Sub
        End If

        If Combo_motivo.Text = "" Then
            MsgBox("CAMPO MOTIVO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_motivo.Focus()
            Exit Sub
        End If

        If Combo_motivo.Text = "-" Then
            MsgBox("CAMPO MOTIVO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_motivo.Focus()
            Exit Sub
        End If

        If grilla_consumo_interno.Rows.Count >= limite_guias Then
            MsgBox("DEBE IMPRIMIR LA GUIA PARA SEGUIR INGRESNDO PRODUCTOS", 0 + 16, "ERROR")
            Combo_motivo.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        totales()
        crear_nro_vale()





        With Pd.PrinterSettings
            .PrinterName = impresora_despacho
            .Copies = 2
            .PrintRange = PrintRange.AllPages
            If .IsValid Then
                Me.Pd.PrintController = New StandardPrintController
                Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                Pd.Print()
            Else
                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                lbl_mensaje.Visible = False
                Me.Enabled = True
                Exit Sub
            End If
        End With








        'Try
        '    Dim iReporte As New form_informe_estado_de_cuenta_personalizado
        '    Dim rpt As New Crystal_ticket_consumo_interno

        '    rpt.Load()
        '    rpt.SetDataSource(ReturnDataSet)
        '    rpt.Refresh()

        '    iReporte.Reporte = rpt
        '    'iReporte.ShowDialog()
        '    rpt.PrintOptions.PrinterName = impresora_despacho
        '    'rpt.PrintOptions.PrinterName = "Microsoft Print to PDF"
        '    rpt.PrintToPrinter(1, False, 0, 0)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


        SC.Connection = conexion
        SC.CommandText = "insert into consumo_interno (n_consumo_interno, codigo_producto, cantidad, fecha, hora, estado, usuario_responsable, motivo) values('" & (txt_nro_vale.Text) & "','" & (txt_codigo.Text) & "','" & (txt_cantidad.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','EMITIDA','" & (txt_rut_responsable.Text) & "','" & (Combo_motivo.Text) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "insert into consumo_interno_temporal (n_consumo_interno, codigo_producto, cantidad, fecha, hora, estado, usuario_responsable, motivo) values('" & (txt_nro_vale.Text) & "','" & (txt_codigo.Text) & "','" & (txt_cantidad.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','" & (Form_menu_principal.lbl_hora.Text) & "','EMITIDA','" & (txt_rut_responsable.Text) & "','" & (Combo_motivo.Text) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "update productos set cantidad = cantidad - " & (Int(txt_cantidad.Text)) & " where cod_producto = '" & (txt_codigo.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "insert into detalle_total (n_total, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento,  fecha, vendedor, estado) values(" & (txt_nro_vale.Text) & ",'CONSUMO INTERNO', '" & (txt_codigo.Text) & "','" & (txt_nombre.Text) & "'," & (txt_precio.Text) & ",'" & (txt_cantidad.Text) & "'," & (0) & "," & (txt_neto.Text) & ", " & (txt_iva.Text) & "," & (txt_total.Text) & "," & (txt_total.Text) & ",'SALE','" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (miusuario) & "' ,'EMITIDA')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        Try
            SC.Connection = conexion
            SC.CommandText = "insert into detalle_consumo_interno (n_documento, tipo, cod_producto, nombre, valor_unitario, cantidad, descuento, neto, iva, subtotal, total, movimiento,  fecha, vendedor, estado) values(" & (txt_nro_vale.Text) & ",'CONSUMO INTERNO', '" & (txt_codigo.Text) & "','" & (txt_nombre.Text) & "'," & (txt_precio.Text) & ",'" & (txt_cantidad.Text) & "'," & (0) & "," & (txt_neto.Text) & ", " & (txt_iva.Text) & "," & (txt_total.Text) & "," & (txt_total.Text) & ",'SALE','" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (miusuario) & "' ,'EMITIDA')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Catch
        End Try

        limpiar()
        mostrar_malla()

        If grilla_consumo_interno.Rows.Count <> 0 Then
            txt_item.Text = grilla_consumo_interno.Rows.Count
        End If

        lbl_mensaje.Visible = False
        Me.Enabled = True

        MsgBox("CONSUMO GUARDADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        txt_codigo.Focus()
    End Sub

    Private Sub btn_buscar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos.Click
        conexion.Close()
        Me.Enabled = False
        txt_codigo.Focus()
        Form_buscador_productos_consumo_interno.Show()
        Form_buscador_productos_consumo_interno.txt_busqueda.Focus()
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        mostrar_malla()
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

    Private Sub Timer_cierre_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_cierre.Tick

    End Sub

    Private Sub btn_grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click

        If grilla_consumo_interno.Rows.Count = 0 Then
            MsgBox("MALLA DE PRODUCTOS VACÍA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA IMPRIMIR LA GUIA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        If valormensaje = vbYes Then

            lbl_mensaje.Visible = True
            Me.Enabled = False

            llenar_para_imprimir()

            If estado_guia_electronica = "NO" Then
                With Pd.PrinterSettings
                    .PrinterName = impresora_guias
                    .Copies = 1
                    .PrintRange = PrintRange.AllPages
                    If .IsValid Then
                        Me.crear_numero_guia()
                        Me.grabar_guia()
                        Me.Pd.PrintController = New StandardPrintController
                        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                        Pd.Print()
                        Me.crear_archivo_plano()

                        SC.Connection = conexion
                        SC.CommandText = "DELETE FROM `consumo_interno_temporal` WHERE `cod_auto`='1';"
                        DA.SelectCommand = SC
                        DA.Fill(DT)

                        SC.Connection = conexion
                        SC.CommandText = "DELETE FROM `consumo_interno_temporal` WHERE `cod_auto`<>'1';"
                        DA.SelectCommand = SC
                        DA.Fill(DT)

                        grilla_consumo_interno.Rows.Clear()
                        txt_item.Text = "0"
                        Exit Sub

                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                        Exit Sub
                    Else
                        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                        lbl_mensaje.Visible = False
                        Me.Enabled = True
                        Exit Sub
                    End If
                End With
            Else
                calcular_totales()
                Me.crear_numero_guia()
                Me.grabar_guia()
                Me.crear_archivo_plano()

                SC.Connection = conexion
                SC.CommandText = "DELETE FROM `consumo_interno_temporal` WHERE `cod_auto`='1';"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "DELETE FROM `consumo_interno_temporal` WHERE `cod_auto`<>'1';"
                DA.SelectCommand = SC
                DA.Fill(DT)

                grilla_consumo_interno.Rows.Clear()
                txt_item.Text = "0"
                'Exit Sub

                lbl_mensaje.Visible = False
                Me.Enabled = True
                MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                Exit Sub
            End If




            'With Pd.PrinterSettings
            '    ' Especifico el nombre de la impresora 
            '    ' por donde deseo imprimir. 
            '    .PrinterName = impresora_guias
            '    '.PrinterName = "\\caja-pc\HP LaserJet Professional P 1102w"
            '    ' Establezco el número de copias que se imprimirán 
            '    .Copies = 1
            '    ' Rango de páginas que se imprimirán 
            '    .PrintRange = PrintRange.AllPages
            '    If .IsValid Then
            '        crear_numero_guia()
            '        grabar_guia()
            '        Me.Pd.PrintController = New StandardPrintController
            '        Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
            '        Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
            '        Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
            '        Pd.Print()
            '        Me.Enabled = True
            '        MsgBox("SE HA IMPRESO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")

            '        SC.Connection = conexion
            '        SC.CommandText = "DELETE FROM `consumo_interno_temporal` WHERE `cod_auto`='1';"
            '        DA.SelectCommand = SC
            '        DA.Fill(DT)

            '        SC.Connection = conexion
            '        SC.CommandText = "DELETE FROM `consumo_interno_temporal` WHERE `cod_auto`<>'1';"
            '        DA.SelectCommand = SC
            '        DA.Fill(DT)

            '        grilla_consumo_interno.Rows.Clear()
            '        txt_item.Text = "0"
            '        Exit Sub
            '    Else
            '        MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
            '        lbl_mensaje.Visible = False
            '        Me.Enabled = True
            '        Exit Sub
            '    End If
            'End With
        End If
    End Sub

    Sub grabar_guia()
        Dim neto As Integer
        Dim iva As Integer
        Dim subtotal As Integer
        Dim total As Integer

        neto = "1696050"
        iva = "322250"
        subtotal = "2018300"
        total = "2018300"

        SC.Connection = conexion
        SC.CommandText = "insert into guia (n_guia, TIPO, rut_cliente, codigo_cliente, fecha_venta, descuento, neto, iva, subtotal, total, condiciones, estado, usuario_responsable,rut_retira, nombre_retira, recinto, orden, hora, porcentaje_desc, tipo_impresion, vehiculo, patente, pie, condicion_de_pago_pie, comision) values (" & (txt_nro_guia.Text) & " , '" & ("GUIA") & "', '87686300-6','530','" & (Form_menu_principal.dtp_fecha.Text) & "','0'," & (neto) & "," & (iva) & "," & (subtotal) & "," & (total) & ",'TRASLADO','" & ("SIN FACTURAR") & "','SISTEMA','-','-','" & (mirecintoempresa) & "','" & ("0") & "','" & (Form_menu_principal.lbl_hora.Text) & "','0','MANUAL', '-', '-', '0', '0', '0')"
        DA.SelectCommand = SC
        DA.Fill(DT)
    End Sub



    Sub crear_numero_guia()
        Dim varnumdoc As Integer

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(cod_auto) as cod_auto from guia where tipo_impresion <> 'DIGITADA'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                'txt_factura.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_nro_guia.Text = 1
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
            SC.CommandText = "select n_guia from guia where cod_auto='" & (varnumdoc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                varnumdoc = DS.Tables(DT.TableName).Rows(0).Item("n_guia")
                txt_nro_guia.Text = varnumdoc + 1
            End If
        Catch err As InvalidCastException
            txt_nro_guia.Text = 1
        End Try
        conexion.Close()
    End Sub

    Sub imprimir()
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        conexion.Close()
        Form_enviar_documento.Show()
        Form_cargar_compra_documento.txt_rut_proveedor.Focus()
        Me.Enabled = False
    End Sub



    Private Sub btn_estado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        mostrar_malla()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_quitar_elemento_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        If grilla_consumo_interno.Rows.Count > 0 Then
            Dim n_consumo_interno As String
            Dim cantidad_consumo As String
            Dim codigo_consumo As String

            n_consumo_interno = grilla_consumo_interno.CurrentRow.Cells(0).Value
            cantidad_consumo = grilla_consumo_interno.CurrentRow.Cells(5).Value
            codigo_consumo = grilla_consumo_interno.CurrentRow.Cells(1).Value

            Try
                SC.Connection = conexion
                SC.CommandText = "DELETE FROM consumo_interno_temporal WHERE cod_auto = '" & (n_consumo_interno) & "';"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Catch
            End Try

            'Try
            '    SC.Connection = conexion
            '    SC.CommandText = "DELETE FROM consumo_interno WHERE n_consumo_interno = '" & (n_consumo_interno) & "';"
            '    DA.SelectCommand = SC
            '    DA.Fill(DT)
            'Catch
            'End Try

            'Try
            '    SC.Connection = conexion
            '    SC.CommandText = "DELETE FROM `detalle_total` WHERE TIPO ='CONSUMO INTERNO' and cod_producto = '" & (codigo_consumo) & "' and n_total = '" & (n_consumo_interno) & "' and `cod_auto`<>'1';"
            '    DA.SelectCommand = SC
            '    DA.Fill(DT)
            'Catch
            'End Try

            Try
                SC.Connection = conexion
                SC.CommandText = "DELETE FROM `detalle_consumo_interno` WHERE TIPO ='CONSUMO INTERNO' and cod_producto = '" & (codigo_consumo) & "' and n_documento = '" & (n_consumo_interno) & "' and `cod_detalle`<>'1';"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Catch
            End Try

            SC.Connection = conexion
            SC.CommandText = "update productos set cantidad = cantidad + " & (Int(cantidad_consumo)) & " where cod_producto = '" & (codigo_consumo) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            mostrar_malla()

            txt_codigo.Focus()
        End If
    End Sub

    Sub llenar_combo_responsable()
        Combo_responsable.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from usuarios WHERE ACTIVO='SI' order by nombre_usuario"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        Combo_responsable.Items.Add("-")
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_responsable.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_usuario"))
            Next
        End If
        Combo_responsable.SelectedItem = ("-")

        conexion.Close()
    End Sub

    Sub mostrar_datos_vendedor()
        conexion.Close()
        If Combo_responsable.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from usuarios where nombre_usuario ='" & (Combo_responsable.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut_responsable.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
            End If

            conexion.Close()
        End If
    End Sub

    Private Sub Combo_responsable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_responsable.SelectedIndexChanged
        mostrar_datos_vendedor()
    End Sub

    Private Sub Combo_motivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_motivo.SelectedIndexChanged
        If Combo_motivo.Text = "OTRO MOTIVO" Then
            Form_otro_motivo_consumo_interno.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Function ReturnDataSet() As DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ds As New DataSet

        'dt.Columns.Add(New DataColumn("Imagen", GetType(Byte())))
        dt.Columns.Add(New DataColumn("DataColumn1", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn2", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn3", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn4", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn5", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn6", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn7", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn8", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn9", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn10", GetType(String)))


        'Dim Varcodigo As String
        'Dim Vardescripcion As String
        'Dim Varcantidad As String

        'For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1
        '    Varcodigo = grilla_estado_de_cuenta.Rows(i).Cells(0).Value.ToString
        '    Vardescripcion = grilla_estado_de_cuenta.Rows(i).Cells(1).Value.ToString
        '    Varcantidad = grilla_estado_de_cuenta.Rows(i).Cells(2).Value

        dr = dt.NewRow()

        'Try
        '    dr("Imagen") = Imagen_reporte
        'Catch
        'End Try

        dr("DataColumn1") = txt_nro_vale.Text
        dr("DataColumn2") = Form_menu_principal.dtp_fecha.Text
        dr("DataColumn3") = Form_menu_principal.lbl_hora.Text
        dr("DataColumn4") = Combo_responsable.Text
        dr("DataColumn5") = Combo_motivo.Text
        dr("DataColumn6") = txt_codigo.Text
        dr("DataColumn7") = txt_nombre.Text
        dr("DataColumn8") = txt_cantidad.Text
        dt.Rows.Add(dr)
        ' Next

        ds.Tables.Add(dt)
        ds.Tables(0).TableName = "DS_reporte"
        Dim iDS As New DS_reporte
        iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
        Return iDS
    End Function


    Sub crear_archivo_plano()

        Dim condicion As String

        condicion = "TRASLADO"

        'correcto sin modificaciones

        Dim IndTraslado As Integer
        If condicion = "TRASLADO" Then
            IndTraslado = 0
        Else
            IndTraslado = 1
        End If




















        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim ContenidoArchivo As String = Nothing
        ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
        Dim PathArchivo As String


        Dim VarCodProducto As String
        Dim varnombre As String
        Dim vartecnico As String
        Dim VarValorUnitario As Integer
        Dim VarCantidad As String
        Dim VarPorcentaje As String
        Dim VarDescuento As Integer
        ' Dim VarNeto As Integer
        'Dim VarIva As Integer
        'Dim VarSubtotal As Integer
        Dim VarTotal As Integer
        'Dim VarProveedor As String
        'Dim VarCosto As Integer
        'Dim VarSaldo As Integer

        Dim nro_linea As String

        txt_nombre_cliente.Text = txt_nombre_cliente.Text & " - " & "CONSUMO INTERNO"

        Dim nombre_cliente As String
        nombre_cliente = txt_nombre_cliente.Text
        If nombre_cliente.Length > 40 Then
            nombre_cliente = nombre_cliente.Substring(0, 40)
        End If

        Dim giro_cliente As String
        giro_cliente = txt_giro_cliente.Text
        If giro_cliente.Length > 40 Then
            giro_cliente = giro_cliente.Substring(0, 40)
        End If

        Dim direccion_cliente As String
        direccion_cliente = txt_direccion_cliente.Text
        If direccion_cliente.Length > 59 Then
            direccion_cliente = direccion_cliente.Substring(0, 60)
        End If

        Dim comuna_cliente As String
        comuna_cliente = txt_comuna_cliente.Text
        If comuna_cliente.Length > 19 Then
            comuna_cliente = comuna_cliente.Substring(0, 20)
        End If

        Dim ciudad_cliente As String
        ciudad_cliente = txt_comuna_cliente.Text
        If ciudad_cliente.Length > 19 Then
            ciudad_cliente = ciudad_cliente.Substring(0, 20)
        End If

        Dim correo_cliente As String
        correo_cliente = txt_correo_cliente.Text
        If correo_cliente.Length > 199 Then
            correo_cliente = correo_cliente.Substring(0, 200)
        End If


        txt_telefono.Text = Trim(dejarNumerosPuntos(txt_telefono.Text))


        Dim telefono_cliente As String
        telefono_cliente = txt_telefono.Text
        If telefono_cliente.Length > 8 Then
            telefono_cliente = telefono_cliente.Substring(0, 8)
        End If

        If correo_cliente = "-" Then
            correo_cliente = ""
        End If








        Try
            If Directory.Exists(ruta_archivos_planos) = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory(ruta_archivos_planos)
            End If

            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            PathArchivo = ruta_archivos_planos & "\" & "Guia " & (txt_nro_guia.Text) & ".txt" ' Se determina el nombre del archivo con la fecha actual

            'verificamos si existe el archivo

            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' TIPO de codificacion para escritura

            'escribimos en el archivo
            strStreamWriter.WriteLine("->Encabezado<-" & vbNewLine _
            & "52" & ";" & (txt_nro_guia.Text) & ";" & (Form_menu_principal.dtp_fecha.Text) & ";" & (tipo_despacho) & ";" & (IndTraslado) & ";" & (txt_rut_cliente.Text) & ";" & (nombre_cliente) & ";" & (giro_cliente) & ";" & (direccion_cliente) & ";" & (ciudad_cliente) & ";" & (comuna_cliente) & ";" & (correo_cliente) & ";" & (condicion) & ";" & (minombre) & ";" & (miusuario) & ";" & (minombre) & ";" & (mirecintoempresa) & ";" & (telefono_cliente) & ";" & vbNewLine _
            & "->Totales<-" & vbNewLine _
            & (0) & ";" & ("0") & ";" & "0" & ";" & "0" & ";" & (txt_neto.Text) & ";" & "0" & ";" & (valor_iva) & ";" & (txt_iva.Text) & ";" & (txt_total.Text) & ";1;" & vbNewLine _
            & "->Detalle<-")

            nro_linea = 0

            For i = 0 To grilla_consumo_interno.Rows.Count - 1
                nro_linea = nro_linea + 1
                VarCodProducto = Me.grilla_consumo_interno.Rows(i).Cells(1).Value.ToString
                varnombre = Me.grilla_consumo_interno.Rows(i).Cells(2).Value.ToString
                vartecnico = Me.grilla_consumo_interno.Rows(i).Cells(3).Value.ToString
                VarValorUnitario = Me.grilla_consumo_interno.Rows(i).Cells(10).Value.ToString
                VarCantidad = Me.grilla_consumo_interno.Rows(i).Cells(5).Value.ToString

                'VarCodProducto = grilla_detalle_venta.Rows(i).Cells(0).Value.ToString
                'varnombre = grilla_detalle_venta.Rows(i).Cells(1).Value.ToString
                'vartecnico = grilla_detalle_venta.Rows(i).Cells(2).Value.ToString
                'VarValorUnitario = grilla_consumo_interno.Rows(i).Cells(3).Value.ToString
                'VarCantidad = grilla_detalle_venta.Rows(i).Cells(4).Value.ToString
                'VarNeto = grilla_detalle_venta.Rows(i).Cells(5).Value.ToString
                'VarIva = grilla_detalle_venta.Rows(i).Cells(6).Value.ToString
                'VarSubtotal = grilla_detalle_venta.Rows(i).Cells(7).Value.ToString
                'VarPorcentaje = grilla_detalle_venta.Rows(i).Cells(8).Value.ToString
                'VarDescuento = grilla_detalle_venta.Rows(i).Cells(9).Value.ToString
                VarTotal = Val(VarCantidad) * Val(VarValorUnitario)


                If VarCodProducto.Length > 34 Then
                    VarCodProducto = VarCodProducto.Substring(0, 35)
                End If

                If varnombre.Length > 79 Then
                    varnombre = varnombre.Substring(0, 80)
                End If

                varnombre = varnombre & " " & vartecnico

                If varnombre.Length > 52 Then
                    varnombre = varnombre.Substring(0, 52)
                End If

                VarCantidad = Replace(VarCantidad, ",", ".")
                VarPorcentaje = Replace(VarPorcentaje, ",", ".")

                strStreamWriter.WriteLine(nro_linea & ";" & (VarCodProducto) & ";" & (varnombre) & ";" & (VarCantidad) & ";" & (VarValorUnitario) & ";" & (VarPorcentaje) & ";" & (VarDescuento) & ";" & (0) & ";" & (0) & ";" & (0) & ";" & (VarTotal) & ";" & "INT11" & ";" & "UN" & ";" & ";")
            Next



            strStreamWriter.WriteLine("->Referencia<-" & vbNewLine _
            & "1" & ";" & "801" & ";0;;" & "0" & ";" & "-" & ";" & vbNewLine _
            & "->DescRec<-" & vbNewLine _
            & "1" & ";" & "D" & ";" & "Descuento" & ";" & "$" & ";0;" & "0" & ";" & vbNewLine _
            & "->Observacion<-" & vbNewLine _
            & "" & ";" & "TRASLADO" & ", " & mirecintoempresa & ";")
            strStreamWriter.Close() ' cerramos

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LA INFORMACION EN EL ARCHIVO. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
            strStreamWriter.Close() ' cerramos
        End Try

    End Sub


    Sub llenar_para_imprimir()

        txt_nombre_cliente.Text = "RAFAEL ARANA Y CIA."
        txt_direccion_cliente.Text = "O'HIGGINS 452"
        txt_giro_cliente.Text = "REPUESTOS AUTOMOTRICES"
        txt_correo_cliente.Text = "CONTACTO@REPUESTOSARANA.CL"
        txt_rut_cliente.Text = "87686300-6"
        txt_comuna_cliente.Text = "SAN FERNANDO"
        txt_telefono.Text = "714173"
    End Sub

    Sub calcular_totales()
        Dim totalgrilla As Long

        'Calcular el total
        txt_total.Text = 0
        For i = 0 To grilla_consumo_interno.Rows.Count - 1
            totalgrilla = Val(grilla_consumo_interno.Rows(i).Cells(11).Value.ToString)
            txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        Next

        Dim iva As Integer = 0
        Dim neto As Integer = 0
        Dim iva_valor As String

        iva_valor = valor_iva / 100 + 1
        txt_neto.Text = Round(txt_total.Text / iva_valor)
        txt_iva.Text = (((txt_neto.Text) * valor_iva) / 100)
        txt_iva.Text = (txt_total.Text) - (txt_neto.Text)
    End Sub

    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
        'If txt_direccion.Text.Length > 23 Then
        '    txt_direccion.Text = txt_direccion.Text.Substring(0, 30)
        'End If

        Dim Font_texto_titulo As New Font("arial", 9, FontStyle.Bold)
        Dim Font_texto_empresa As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_cabecera As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_titulo_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_totales As New Font("arial", 9, FontStyle.Bold)

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Try
            e.Graphics.DrawImage(Bytes_Imagen(Imagen_reporte), -74, 0, 440, 70)
        Catch
        End Try

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim stringFormat_left As New StringFormat()
        stringFormat_left.Alignment = StringAlignment.Near
        stringFormat_left.LineAlignment = StringAlignment.Near

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = 0
        margen_superior = 0

        Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 90, margen_izquierdo + 270, margen_superior + 15)
        Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 105, margen_izquierdo + 270, margen_superior + 15)
        Dim rect3 As New Rectangle(margen_izquierdo + 10, margen_superior + 120, margen_izquierdo + 270, margen_superior + 15)
        Dim rect4 As New Rectangle(margen_izquierdo + 10, margen_superior + 135, margen_izquierdo + 270, margen_superior + 15)
        Dim rect5 As New Rectangle(margen_izquierdo + 10, margen_superior + 150, margen_izquierdo + 270, margen_superior + 15)
        Dim rect6 As New Rectangle(margen_izquierdo + 10, margen_superior + 165, margen_izquierdo + 270, margen_superior + 15)
        Dim rect7 As New Rectangle(margen_izquierdo + 10, margen_superior + 180, margen_izquierdo + 270, margen_superior + 15)
        Dim rect_titulo As New Rectangle(margen_izquierdo + 10, margen_superior + 215, margen_izquierdo + 270, margen_superior + 15)

        e.Graphics.DrawString(minombreempresa, Font_texto_empresa, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(migiroempresa, Font_texto_empresa, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font_texto_empresa, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font_texto_empresa, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font_texto_empresa, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font_texto_empresa, Brushes.Black, rect6, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font_texto_empresa, Brushes.Black, rect7, stringFormat)

        e.Graphics.DrawString("CONSUMO INTERNO", Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)

        e.Graphics.DrawString("NUMERO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 245)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 245)
        e.Graphics.DrawString(txt_nro_vale.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 245)

        e.Graphics.DrawString("FECHA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 260)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 260)
        e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 260)

        e.Graphics.DrawString("HORA", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 275)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 275)
        e.Graphics.DrawString(Form_menu_principal.lbl_hora.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 275)


        e.Graphics.DrawString("RESPONSABLE", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 290)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 290)
        e.Graphics.DrawString(Combo_responsable.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 290)

        e.Graphics.DrawString("MOTIVO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 305)
        e.Graphics.DrawString(":", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 305)
        e.Graphics.DrawString(Combo_motivo.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 85, margen_superior + 305)

        'Dim monto As Integer = txt_monto.Text
        'monto = Math.Abs(monto)
        'Dim monto_final As String = monto

        'If monto_final = "" Or monto_final = "0" Then
        '    monto_final = "0"
        'Else
        '    monto_final = Format(Int(monto_final), "###,###,###")
        'End If

        e.Graphics.DrawString("CODIGO", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 335)
        e.Graphics.DrawString("DESCRIPCION", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 335)
        e.Graphics.DrawString("CANTIDAD", Font_texto_cabecera, Brushes.Black, margen_izquierdo + 280, margen_superior + 335, format1)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + 350, margen_izquierdo + 295, margen_superior + 350)

        e.Graphics.DrawString(txt_codigo.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 0, margen_superior + 355)
        'e.Graphics.DrawString(txt_nombre.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 75, margen_superior + 320)


        Dim rect_descripcion_producto As New Rectangle(margen_izquierdo + 75, margen_superior + 355, margen_izquierdo + 200, margen_superior + 60)
        'e.Graphics.DrawString("FIRMA TRABAJADOR", Font_texto_titulo_detalle, Brushes.Black, rect_firma, stringFormat)
        e.Graphics.DrawString(txt_nombre.Text, Font_texto_titulo_detalle, Brushes.Black, rect_descripcion_producto, stringFormat_left)

        e.Graphics.DrawString(txt_cantidad.Text, Font_texto_cabecera, Brushes.Black, margen_izquierdo + 280, margen_superior + 385, format1)

        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + 470, margen_izquierdo + 295, margen_superior + 470)
        Dim rect_firma As New Rectangle(margen_izquierdo + 10, margen_superior + 480, margen_izquierdo + 270, margen_superior + 15)
        e.Graphics.DrawString("FIRMA RESPONSABLE", Font_texto_titulo_detalle, Brushes.Black, rect_firma, stringFormat)


        Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + 540, margen_izquierdo + 270, margen_superior + 15)
        e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)


















        'Dim VarCodProducto As String
        'Dim varnombre As String
        'Dim vartecnico As String
        'Dim VarValorUnitario As String
        'Dim VarCantidad As String
        'Dim VarPorcentaje As String
        'Dim VarDescuento As String
        'Dim VarNeto As String
        'Dim VarIva As String
        'Dim VarSubtotal As String
        'Dim VarTotal As String
        'Dim cantidad_detalle As String
        'Dim valorUnitario_detalle As String
        'Dim subtotal_detalle As String
        'Dim total_detalle As String

        'Dim Font11 As New Font("Lucida Console Normal", 11, FontStyle.Regular)
        'Dim Font10 As New Font("Lucida Console Normal", 10, FontStyle.Regular)
        'Dim Font9 As New Font("Lucida Console Normal", 9, FontStyle.Regular)
        'Dim Font8 As New Font("Lucida Console Normal", 8, FontStyle.Regular)

        'Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        'format1.Alignment = StringAlignment.Far

        'Dim Font1 As New Font("arial", 7, FontStyle.Regular)
        'Dim Font2 As New Font("arial", 10, FontStyle.Bold)
        'Dim Font3 As New Font("arial", 7, FontStyle.Bold)
        'Dim Font4 As New Font("arial", 8, FontStyle.Regular)

        'Dim stringFormat As New StringFormat()
        'stringFormat.Alignment = StringAlignment.Center
        'stringFormat.LineAlignment = StringAlignment.Center

        'Dim rect7 As New Rectangle(10, 0, 270, 15)
        'Dim rect8 As New Rectangle(10, 90, 270, 50)

        'e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text & " " & mirecintoempresa, Font10, Brushes.Black, 100, 20)
        'e.Graphics.DrawString(txt_nro_guia.Text, Font10, Brushes.Black, 550, 20, format1)
        'e.Graphics.DrawString("RAFAEL ARANA Y CIA.", Font10, Brushes.Black, 100, 36)
        'e.Graphics.DrawString("O'HIGGINS 452", Font10, Brushes.Black, 100, 52)
        'e.Graphics.DrawString("REPUESTOS AUTOMOTRICES", Font10, Brushes.Black, 100, 68)
        'e.Graphics.DrawString("", Font10, Brushes.Black, 100, 84)
        'e.Graphics.DrawString("87686300-6", Font10, Brushes.Black, 655, 20)
        'e.Graphics.DrawString("SAN FERNANDO", Font10, Brushes.Black, 655, 36)
        'e.Graphics.DrawString("714173", Font10, Brushes.Black, 655, 52)
        'e.Graphics.DrawString("TRASLADO", Font10, Brushes.Black, 655, 68)
        'e.Graphics.DrawString(miusuario, Font10, Brushes.Black, 655, 84)





        'For i = 0 To Me.grilla_consumo_interno.Rows.Count - 1
        '    VarCodProducto = Me.grilla_consumo_interno.Rows(i).Cells(1).Value.ToString
        '    varnombre = Me.grilla_consumo_interno.Rows(i).Cells(2).Value.ToString
        '    vartecnico = Me.grilla_consumo_interno.Rows(i).Cells(3).Value.ToString
        '    VarValorUnitario = "0"
        '    VarCantidad = Me.grilla_consumo_interno.Rows(i).Cells(5).Value.ToString

        '    VarNeto = "0"
        '    VarIva = "0"
        '    VarSubtotal = "0"
        '    VarPorcentaje = "0"
        '    VarDescuento = "0"
        '    VarTotal = "0"
        '    cantidad_detalle = "0"
        '    valorUnitario_detalle = "0"
        '    subtotal_detalle = "0"
        '    total_detalle = "0"

        '    'valorUnitario_detalle = Format(Int(valorUnitario_detalle), "###,###,###")
        '    'subtotal_detalle = Format(Int(subtotal_detalle), "###,###,###")
        '    'total_detalle = Format(Int(total_detalle), "###,###,###")

        '    If varnombre.Length > 35 Then
        '        varnombre = varnombre.Substring(0, 35)
        '    End If

        '    If vartecnico.Length > 22 Then
        '        vartecnico = vartecnico.Substring(0, 22)
        '    End If

        '    e.Graphics.DrawString(VarCodProducto, Font8, Brushes.Black, 0, 145 + (i * 15))
        '    e.Graphics.DrawString(varnombre, Font8, Brushes.Black, 75, 145 + (i * 15))
        '    e.Graphics.DrawString(vartecnico, Font8, Brushes.Black, 335, 145 + (i * 15))
        '    e.Graphics.DrawString(VarCantidad, Font8, Brushes.Black, 520, 145 + (i * 15), format1)


        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()

        '    SC.Connection = conexion
        '    SC.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    DS.Tables.Add(DT)
        '    txt_proveedor.Text = ""
        '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '        valorUnitario_detalle = DS.Tables(DT.TableName).Rows(0).Item("costo")
        '    End If
        '    conexion.Close()

        '    subtotal_detalle = Int(valorUnitario_detalle) * Int(VarCantidad)
        '    total_detalle = subtotal_detalle

        '    e.Graphics.DrawString(valorUnitario_detalle, Font8, Brushes.Black, 600, 145 + (i * 15), format1)
        '    e.Graphics.DrawString(VarPorcentaje, Font8, Brushes.Black, 640, 145 + (i * 15), format1)
        '    e.Graphics.DrawString(subtotal_detalle, Font8, Brushes.Black, 725, 145 + (i * 15), format1)
        '    e.Graphics.DrawString(total_detalle, Font8, Brushes.Black, 792, 145 + (i * 15), format1)
        'Next


        'Dim neto_millar As String
        'Dim iva_millar As String
        'Dim total_millar As String

        'neto_millar = Me.txt_neto.Text
        'iva_millar = Me.txt_iva.Text

        'total_millar = Me.txt_total.Text

        ''descuento_millar = Format(Int(descuento_millar), "###,###,###")
        'neto_millar = Format(Int(neto_millar), "###,###,###")
        'iva_millar = Format(Int(iva_millar), "###,###,###")
        ''subtotal_millar = Format(Int(subtotal_millar), "###,###,###")
        'total_millar = Format(Int(total_millar), "###,###,###")

        'e.Graphics.DrawString(minombre, Font8, Brushes.Black, 55, 540)
        'e.Graphics.DrawString(miusuario, Font8, Brushes.Black, 265, 540)
        'e.Graphics.DrawString(mirecintoempresa, Font8, Brushes.Black, 510, 540)
        'e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, Font8, Brushes.Black, 797, 540, format1)
    End Sub
End Class