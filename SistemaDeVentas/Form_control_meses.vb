Public Class Form_control_meses

    Dim MiPos As Integer
    Private Sub Form_control_meses_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_libro_de_compras_impresion.WindowState = FormWindowState.Normal
        Form_libro_de_compras_impresion.Enabled = True
    End Sub

    Private Sub Form_control_meses_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_control_meses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        'txt_mes.Text = Month(Now)
        'seleccionar_mes()
        'Combo_año.Text = Year(Now)

        actualizar_control_meses()
        mostrar(0)



    
        dtp_desde.Text = Form_menu_principal.dtp_fecha.Value.AddMonths(Val(-1))

        txt_mes.Text = dtp_desde.Value.Month

        Combo_año.Text = Form_menu_principal.dtp_fecha.Value.Year

        seleccionar_mes()

        mostrar_datos_mes()

        controles(False, True)
        'txt_mes.Text = dtp_desde.Value.Month
        'dtp_fecha_liquidacion.CustomFormat = "MM-yyy"
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)

        btn_primero.Enabled = b
        btn_siguiente.Enabled = b
        btn_anterior.Enabled = b
        btn_ultimo.Enabled = b
        Combo_año.Enabled = a

        Combo_mes.Enabled = a
        Combo_estado_mes.Enabled = a

        btn_guardar.Enabled = a
        btn_cancelar.Enabled = a
        btn_modificar.Enabled = b
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
  
        controles(True, False)

    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        controles(False, True)
    End Sub


    Private Sub Combo_rut_empresa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If
    End Sub



    Private Sub Combo_rut_empresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        actualizar_control_meses()
        mostrar(0)
    End Sub

    Private Sub btn_primero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_primero.Click
        MiPos = 0
        mostrar(0)
        '  mostrar_datos_usuarios()
    End Sub

    Private Sub btn_anterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_anterior.Click
        If MiPos >= 1 Then
            MiPos -= 1
            mostrar(MiPos)
            ' mostrar_datos_usuarios()
        End If
    End Sub

    Private Sub btn_siguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_siguiente.Click
        If MiPos < DT.Rows.Count - 1 Then
            MiPos += 1
            mostrar(MiPos)
            ' mostrar_datos_usuarios()
        End If
    End Sub

    Private Sub btn_ultimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ultimo.Click
        MiPos = DT.Rows.Count - 1
        mostrar(MiPos)
        '  mostrar_datos_usuarios()
    End Sub

    Sub mostrar(ByVal i As Integer)
        Try
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Combo_año.Text = DS.Tables(DT.TableName).Rows(i).Item("anual")
                txt_mes.Text = DS.Tables(DT.TableName).Rows(i).Item("mensual")
                Combo_estado_mes.Text = DS.Tables(DT.TableName).Rows(i).Item("estado")
                seleccionar_mes()
            End If
        Catch
        End Try
    End Sub

    Sub mostrar_datos_mes()
        Dim mes As String = ""

        If Combo_mes.Text = "ENERO" Then
            mes = "01"
        End If
        If Combo_mes.Text = "FEBRERO" Then
            mes = "02"
        End If
        If Combo_mes.Text = "MARZO" Then
            mes = "03"
        End If
        If Combo_mes.Text = "ABRIL" Then
            mes = "04"
        End If
        If Combo_mes.Text = "MAYO" Then
            mes = "05"
        End If
        If Combo_mes.Text = "JUNIO" Then
            mes = "06"
        End If
        If Combo_mes.Text = "JULIO" Then
            mes = "07"
        End If
        If Combo_mes.Text = "AGOSTO" Then
            mes = "08"
        End If
        If Combo_mes.Text = "SEPTIEMBRE" Then
            mes = "09"
        End If
        If Combo_mes.Text = "OCTUBRE" Then
            mes = "10"
        End If
        If Combo_mes.Text = "NOVIEMBRE" Then
            mes = "11"
        End If
        If Combo_mes.Text = "DICIEMBRE" Then
            mes = "12"
        End If


        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()
        SC2.Connection = conexion
        SC2.CommandText = "select * from control_meses_libro_de_compras where mensual ='" & (mes) & "' and  anual ='" & (Combo_año.Text) & "'"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)
        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            Combo_año.Text = DS2.Tables(DT2.TableName).Rows(0).Item("anual")
            txt_mes.Text = DS2.Tables(DT2.TableName).Rows(0).Item("mensual")
            Combo_estado_mes.Text = DS2.Tables(DT2.TableName).Rows(0).Item("estado")
            seleccionar_mes()
        Else
            Combo_estado_mes.Text = "ABIERTO"
        End If
    End Sub

    Sub actualizar_control_meses()
        conexion.Close()

        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from control_meses_libro_de_compras order by mensual, anual"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        conexion.Close()
    End Sub


    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If Combo_año.Text = "-" Then
            Combo_año.Focus()
            MsgBox("CAMPO AÑO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If Combo_año.Text = "-" Then
            Combo_año.Focus()
            MsgBox("CAMPO MES VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If Combo_estado_mes.Text = "-" Then
            Combo_estado_mes.Focus()
            MsgBox("CAMPO ESTADO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If Combo_año.Text = "" Then
            Combo_año.Focus()
            MsgBox("CAMPO AÑO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If Combo_año.Text = "" Then
            Combo_año.Focus()
            MsgBox("CAMPO MES VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If Combo_estado_mes.Text = "" Then
            Combo_estado_mes.Focus()
            MsgBox("CAMPO ESTADO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()
        SC2.Connection = conexion
        SC2.CommandText = "select * from control_meses_libro_de_compras where mensual ='" & (txt_mes.Text) & "' and  anual ='" & (Combo_año.Text) & "'"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)
        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then

            SC2.Connection = conexion
            SC2.CommandText = "UPDATE `control_meses_libro_de_compras` SET `estado`='" & (Combo_estado_mes.Text) & "' WHERE `anual`='" & (Combo_año.Text) & "' and `mensual`='" & (txt_mes.Text) & "' and `cod_auto`<>'99999999';"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)

        Else
            SC2.Connection = conexion
            SC2.CommandText = "INSERT INTO `control_meses_libro_de_compras` (`anual`, `mensual`, `estado`) VALUES ('" & (Combo_año.Text) & "', '" & (txt_mes.Text) & "', '" & (Combo_estado_mes.Text) & "');"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)

        End If


        MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        actualizar_control_meses()
        controles(False, True)
    End Sub
















    Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
        btn_modificar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
        btn_modificar.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
    '    btn_buscar.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
    '    btn_buscar.BackColor = Color.WhiteSmoke
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


    Private Sub dtp_fecha_liquidacion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Combo_estado_mes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_estado_mes.GotFocus
        Combo_estado_mes.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_estado_mes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_estado_mes.LostFocus
        Combo_estado_mes.BackColor = Color.White
    End Sub

    Private Sub Combo_mes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_mes.GotFocus
        Combo_mes.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_mes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_mes.LostFocus
        Combo_mes.BackColor = Color.White
    End Sub

    Private Sub Combo_año_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_año.GotFocus
        Combo_año.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Combo_año_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_año.LostFocus
        Combo_año.BackColor = Color.White
    End Sub

    Private Sub Combo_estado_mes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_estado_mes.SelectedIndexChanged

    End Sub

    Private Sub txt_nombre_empresa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txt_nombre_empresa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Sub nombre_mes()

        If Combo_mes.Text = "ENERO" Then
            txt_mes.Text = "01"
        End If

        If Combo_mes.Text = "FEBRERO" Then
            txt_mes.Text = "02"
        End If

        If Combo_mes.Text = "MARZO" Then
            txt_mes.Text = "03"
        End If

        If Combo_mes.Text = "ABRIL" Then
            txt_mes.Text = "04"
        End If

        If Combo_mes.Text = "MAYO" Then
            txt_mes.Text = "05"
        End If

        If Combo_mes.Text = "JUNIO" Then
            txt_mes.Text = "06"
        End If

        If Combo_mes.Text = "JULIO" Then
            txt_mes.Text = "07"
        End If

        If Combo_mes.Text = "AGOSTO" Then
            txt_mes.Text = "08"
        End If

        If Combo_mes.Text = "SEPTIEMBRE" Then
            txt_mes.Text = "09"
        End If

        If Combo_mes.Text = "OCTUBRE" Then
            txt_mes.Text = "10"
        End If

        If Combo_mes.Text = "NOVIEMBRE" Then
            txt_mes.Text = "11"
        End If

        If Combo_mes.Text = "DICIEMBRE" Then
            txt_mes.Text = "12"
        End If

    End Sub

    Sub seleccionar_mes()

        Dim valor As Integer
        valor = txt_mes.Text
        txt_mes.Text = String.Format("{0:00}", valor)


        If txt_mes.Text = "01" Then
            Combo_mes.Text = "ENERO"
        End If

        If txt_mes.Text = "02" Then
            Combo_mes.Text = "FEBRERO"
        End If

        If txt_mes.Text = "03" Then
            Combo_mes.Text = "MARZO"
        End If

        If txt_mes.Text = "04" Then
            Combo_mes.Text = "ABRIL"
        End If

        If txt_mes.Text = "05" Then
            Combo_mes.Text = "MAYO"
        End If

        If txt_mes.Text = "06" Then
            Combo_mes.Text = "JUNIO"
        End If

        If txt_mes.Text = "07" Then
            Combo_mes.Text = "JULIO"
        End If

        If txt_mes.Text = "08" Then
            Combo_mes.Text = "AGOSTO"
        End If

        If txt_mes.Text = "09" Then
            Combo_mes.Text = "SEPTIEMBRE"
        End If

        If txt_mes.Text = "10" Then
            Combo_mes.Text = "OCTUBRE"
        End If

        If txt_mes.Text = "11" Then
            Combo_mes.Text = "NOVIEMBRE"
        End If

        If txt_mes.Text = "12" Then
            Combo_mes.Text = "DICIEMBRE"
        End If

    End Sub

    Private Sub Combo_mes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_mes.SelectedIndexChanged
        nombre_mes()
    End Sub
End Class