Public Class Form_cobranzas
    Dim mifecha2 As String
    Private Sub btn_agregar_entrada_remuneracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_entrada_remuneracion.Click
        If txt_detalle.Text = "" Then
            MsgBox("CAMPO DETALLE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_detalle.Focus()
            Exit Sub
        End If

        If combo_tipo.Text = "-" Then
            MsgBox("CAMPO MOVIMIENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_tipo.Focus()
            Exit Sub
        End If

        fecha()

        SC.Connection = conexion
        SC.CommandText = "insert into registro_de_cobranzas (rut_cliente, detalle, TIPO, fecha, usuario_responsable) values ('" & (txt_rut_cliente.Text) & "' , '" & (txt_detalle.Text) & "','" & (combo_tipo.Text) & "','" & (mifecha2) & "','" & (miusuario) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        cargar_detalle()

        txt_detalle.Text = ""
        dtp_desde.Text = FormatDateTime(Now, DateFormat.ShortDate)
        combo_tipo.SelectedItem = "-"

        txt_detalle.Focus()




    End Sub

    Sub cargar_detalle()
        Try
            grilla_cobranzas.Rows.Clear()
            'fecha()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select * from registro_de_cobranzas, clientes where registro_de_cobranzas.rut_cliente=clientes.rut_cliente and registro_de_cobranzas.rut_cliente='" & (txt_rut_cliente.Text) & "' order by fecha asc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            Dim fecha_cobranza As String


            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                    fecha_cobranza = DS.Tables(DT.TableName).Rows(i).Item("fecha")

                    If fecha_cobranza.Length > 10 Then
                        fecha_cobranza = fecha_cobranza.Substring(0, 10)
                    End If

                    grilla_cobranzas.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("detalle"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("TIPO"), _
                                                           fecha_cobranza, _
                                                            DS.Tables(DT.TableName).Rows(i).Item("COD_AUTO"))
                Next
            End If
        Catch
            crear_tabla()
        End Try
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")
    End Sub

    Sub crear_tabla()
        Try
            SC.Connection = conexion
            SC.CommandText = "CREATE  TABLE `basededatos`.`registro_de_cobranzas` (`cod_auto` INT NOT NULL AUTO_INCREMENT ,`rut_cliente` VARCHAR(45) NULL ,`detalle` VARCHAR(150) NULL ,`TIPO` VARCHAR(45) NULL ,`fecha` DATE NULL ,`usuario_responsable` VARCHAR(45) NULL ,PRIMARY KEY (`cod_auto`));"
            DA.SelectCommand = SC
            DA.Fill(DT)
        Catch

        End Try
    End Sub

    Private Sub Form_cobranzas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_calcular_deuda_cliente.Enabled = True
        Form_calcular_deuda_cliente.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_cobranzas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_cobranzas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            txt_rut_cliente.Text = Form_calcular_deuda_cliente.grilla_deuda_clientes.CurrentRow.Cells(0).Value
            cargar_detalle()
            mostrar_datos_clientes()
        Catch
        End Try

        combo_tipo.SelectedItem = "-"
        grilla_cobranzas.Columns(0).Width = 300
        grilla_cobranzas.Columns(1).Width = 450
        grilla_cobranzas.Columns(2).Width = 110
        grilla_cobranzas.Columns(3).Width = 108
        grilla_cobranzas.Columns(4).Width = 110
        txt_detalle.Focus()

    End Sub


    Sub mostrar_datos_clientes()
        If txt_rut_cliente.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from clientes where rut_cliente ='" & (txt_rut_cliente.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
                txt_codigo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
                txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
                txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
                txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
                conexion.Close()
                'ElseIf DS.Tables(DT.TableName).Rows.Count < 1 Then
                '    MsgBox("CLIENTE NO ENCONTRADO", 0 + 16, "ERROR")
                '    txt_rut_cliente.Focus()
                '    conexion.Close()
            End If
            conexion.Close()
        End If
    End Sub

    Sub color_foco()
        Dim controlcito As Control
        Dim controlChild As Control

        For Each controlcito In Me.Controls
            If TypeOf controlcito Is TextBox Then
                If CType(controlcito, TextBox).ReadOnly = False Then
                    CType(controlcito, TextBox).BackColor = Color.White
                End If
            End If

            If TypeOf controlcito Is ComboBox Then
                CType(controlcito, ComboBox).BackColor = Color.White
            End If

            If TypeOf controlcito Is Button Then
                CType(controlcito, Button).BackColor = Color.Transparent
            End If

            If TypeOf controlcito Is GroupBox Then
                For Each controlChild In controlcito.Controls
                    If TypeOf controlChild Is TextBox Then
                        If CType(controlChild, TextBox).ReadOnly = False Then
                            CType(controlChild, TextBox).BackColor = Color.White
                        End If
                    End If

                    If TypeOf controlChild Is ComboBox Then
                        CType(controlChild, ComboBox).BackColor = Color.White
                    End If

                    If TypeOf controlChild Is Button Then
                        CType(controlChild, Button).BackColor = Color.Transparent
                    End If
                Next
            End If
        Next

        For Each controlcito In Me.Controls
            If TypeOf controlcito Is TextBox Then
                If CType(controlcito, TextBox).Focused Then
                    If CType(controlcito, TextBox).ReadOnly = False Then
                        CType(controlcito, TextBox).BackColor = Color.LightSkyBlue
                        Exit Sub
                    End If
                End If
            End If

            If TypeOf controlcito Is ComboBox Then
                If CType(controlcito, ComboBox).Focused Then
                    CType(controlcito, ComboBox).BackColor = Color.LightSkyBlue
                    Exit Sub
                End If
            End If

            If TypeOf controlcito Is Button Then
                If CType(controlcito, Button).Focused Then
                    CType(controlcito, Button).BackColor = Color.LightSkyBlue
                    Exit Sub
                End If
            End If

            If TypeOf controlcito Is GroupBox Then
                For Each controlChild In controlcito.Controls
                    If TypeOf controlChild Is TextBox Then
                        If CType(controlChild, TextBox).Focused Then
                            If CType(controlChild, TextBox).ReadOnly = False Then
                                CType(controlChild, TextBox).BackColor = Color.LightSkyBlue
                                Exit Sub
                            End If
                        End If
                    End If

                    If TypeOf controlChild Is ComboBox Then
                        If CType(controlChild, ComboBox).Focused Then
                            CType(controlChild, ComboBox).BackColor = Color.LightSkyBlue
                            Exit Sub
                        End If
                    End If

                    If TypeOf controlChild Is Button Then
                        If CType(controlChild, Button).Focused Then
                            CType(controlChild, Button).BackColor = Color.LightSkyBlue
                            Exit Sub
                        End If
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub txt_rut_cliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.GotFocus
        color_foco()
    End Sub

    Private Sub txt_rut_cliente_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.HandleCreated

    End Sub

    Private Sub txt_rut_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.TextChanged

    End Sub

    Private Sub txt_detalle_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_detalle.GotFocus
        color_foco()
    End Sub

    Private Sub txt_detalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_detalle.KeyPress
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

    Private Sub txt_detalle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_detalle.TextChanged

    End Sub

    Private Sub combo_tipo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_tipo.GotFocus
        color_foco()
    End Sub

    Private Sub combo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_tipo.SelectedIndexChanged

    End Sub

    Private Sub dtp_desde_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_desde.GotFocus
        color_foco()
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged

    End Sub

    Private Sub btn_agregar_entrada_remuneracion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar_entrada_remuneracion.GotFocus
        color_foco()
    End Sub

    Private Sub btn_quitar_entrada_remuneracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_entrada_remuneracion.Click
        If txt_cod_auto.Text = "" Then
            txt_detalle.Focus()
            MsgBox("DEBE SELECCIONAR UN DOCUMENTO ANTES DE QUITARLO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If grilla_cobranzas.Rows.Count = 0 Then
            txt_detalle.Focus()
            MsgBox("DEBE SELECCIONAR UN DOCUMENTO ANTES DE QUITARLO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        Dim valormensaje As Integer
        valormensaje = MsgBox("¿ESTA SEGURO DE ELIMINAR EL MOVIMIENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")

        If valormensaje = vbYes Then

            SC.Connection = conexion
            SC.CommandText = "delete from registro_de_cobranzas where cod_auto = '" & (txt_cod_auto.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            'Dim valormensaje As Integer
            'valormensaje = MsgBox("¿ESTA SEGURO DE ELIMINAR EL MOVIMIENTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")

            'If valormensaje = vbYes Then
            '    Form_autorizacion_caja.Show()
            '    Form_autorizacion_caja.lbl_autorizacion.Text = "PARA ELIMINAR UN MOVIMIENTO SOLICITE AUTORIZACION"
            '    Me.Enabled = False
        End If

    End Sub

    Private Sub btn_quitar_entrada_remuneracion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_entrada_remuneracion.GotFocus
        color_foco()
    End Sub

    Private Sub txt_correo_cliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_correo_cliente.GotFocus
        color_foco()
    End Sub

    Private Sub txt_correo_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_correo_cliente.TextChanged

    End Sub

    Private Sub txt_ciudad_cliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ciudad_cliente.GotFocus
        color_foco()
    End Sub

    Private Sub txt_ciudad_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ciudad_cliente.TextChanged

    End Sub

    Private Sub txt_direccion_cliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_direccion_cliente.GotFocus
        color_foco()
    End Sub

    Private Sub txt_direccion_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_direccion_cliente.TextChanged

    End Sub

    Private Sub txt_nombre_cliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_cliente.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_cliente.TextChanged

    End Sub

    Private Sub txt_codigo_cliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_cliente.GotFocus
        color_foco()
    End Sub

    Private Sub txt_codigo_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_cliente.TextChanged

    End Sub

    Private Sub grilla_cobranzas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_cobranzas.CellContentClick

    End Sub

    Private Sub grilla_cobranzas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_cobranzas.Click
        If grilla_cobranzas.Rows.Count = 0 Then
            Exit Sub
        End If

        txt_cod_auto.Text = grilla_cobranzas.CurrentRow.Cells(4).Value.ToString
    End Sub

    Private Sub grilla_cobranzas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_cobranzas.DoubleClick
    

    End Sub
End Class