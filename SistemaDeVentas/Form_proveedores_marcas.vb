Public Class Form_proveedores_marcas
    Private Sub Form_proveedores_marcas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo__marca_vehiculo()
        llenar_combo_proveedores()
        txt_rut.Focus()
        mostrar_malla_forma_de_pago()
        grilla_contactos.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)
    End Sub

    Private Sub Form_proveedores_marcas_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_proveedores_marcas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub mostrar_datos_proveedor()
        If Combo_proveedor.Text <> "-" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from proveedores where nombre_fantasia_proveedor ='" & (Combo_proveedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_proveedor")
            End If
        End If
    End Sub

    Sub llenar_combo_proveedores()
        Combo_proveedor.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from proveedores WHERE nombre_fantasia_proveedor <> '-' order by nombre_proveedor"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_proveedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_fantasia_proveedor"))
            Next
            Combo_proveedor.Items.Add("-")
            Combo_proveedor.Text = "-"
        End If
        conexion.Close()
    End Sub

    Sub llenar_combo__marca_vehiculo()

        conexion.Close()
        DS4.Tables.Clear()
        DT4.Rows.Clear()
        DT4.Columns.Clear()
        DS4.Clear()
        SC4.Connection = conexion
        SC4.CommandText = "select * from marcas_vehiculos order by nombre_marca"
        DA4.SelectCommand = SC4
        DA4.Fill(DT4)
        DS4.Tables.Add(DT4)
        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        If DS4.Tables(DT4.TableName).Rows.Count > 0 Then
            For i = 0 To DS4.Tables(0).Rows.Count - 1
                ' Combo_comuna.Items.Add(UCase(DS3.Tables(DT3.TableName).Rows(i).Item("comuna_nombre")))
                col.Add(UCase(DS4.Tables(0).Rows(i)("nombre_marca").ToString()))
            Next
            txt_marca_automovil.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt_marca_automovil.AutoCompleteCustomSource = col
            txt_marca_automovil.AutoCompleteMode = AutoCompleteMode.Suggest

            txt_marca_automovil.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt_marca_automovil.AutoCompleteCustomSource = col
            txt_marca_automovil.AutoCompleteMode = AutoCompleteMode.Suggest
        End If
        txt_marca_automovil.AutoCompleteSource = AutoCompleteSource.CustomSource
        txt_marca_automovil.AutoCompleteCustomSource = col
        txt_marca_automovil.AutoCompleteMode = AutoCompleteMode.Suggest

    End Sub

    Sub mostrar_malla_forma_de_pago()

        grilla_contactos.Rows.Clear()
        grilla_contactos.Columns.Clear()
        grilla_contactos.Columns.Add("", "CODIGO")
        grilla_contactos.Columns.Add("", "MARCA")

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from proveedores_marcas where rut_proveedor= '" & (txt_rut.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_contactos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_auto"),
                                           DS.Tables(DT.TableName).Rows(i).Item("marca"))
            Next
            grilla_contactos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_contactos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        'If grilla_detalle_cuadratura.Rows.Count <> 0 Then
        '    If grilla_detalle_cuadratura.Columns(0).Width = 80 Then
        '        grilla_detalle_cuadratura.Columns(0).Width = 79
        '    Else
        '        grilla_detalle_cuadratura.Columns(0).Width = 80
        '    End If
        '    grilla_detalle_cuadratura.Columns(2).Width = 80
        '    grilla_detalle_cuadratura.Columns(3).Width = 150
        'End If
    End Sub

    Sub guion_rut()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut.Text
        If rut_cliente.Length > 2 Then
            guion = rut_cliente(rut_cliente.Length - 2).ToString()
            If guion <> "-" Then
                Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                rut_cliente = rut_cliente & "-" & fin_rut
                txt_rut.Text = rut_cliente
            End If
        End If
    End Sub


    Private Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        If txt_rut.Text = "" Then
            MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_rut.Focus()
            Exit Sub
        End If

        If Combo_proveedor.Text = "-" Then
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            Combo_proveedor.Focus()
            Exit Sub
        End If

        If txt_marca_automovil.Text = "" Then
            MsgBox("CAMPO MARCA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_marca_automovil.Focus()
            Exit Sub
        End If


        SC.Connection = conexion
        SC.CommandText = "INSERT INTO `proveedores_marcas` (`rut_proveedor`, `marca`) VALUES ('" & (txt_rut.Text) & "', '" & (txt_marca_automovil.Text) & "');"
        DA.SelectCommand = SC
        DA.Fill(DT)


        mostrar_malla_forma_de_pago()

        txt_rut.Text = ""
        Combo_proveedor.Text = "-"
        txt_marca_automovil.Text = ""

    End Sub

    Private Sub btn_quitar_Click(sender As Object, e As EventArgs) Handles btn_quitar.Click
        'Dim VarEstado As String
        If grilla_contactos.Rows.Count > 0 Then

            Dim valormensaje As Integer
            valormensaje = MsgBox("¿ESTA SEGURO DE ELIMINAR EL REGISTRO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")


            If valormensaje = vbYes Then
                Dim Var_codigo As String

                Var_codigo = grilla_contactos.CurrentRow.Cells(0).Value

                SC.Connection = conexion
                SC.CommandText = "DELETE FROM proveedores_marcas WHERE cod_auto = '" & (Var_codigo) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

            End If
            mostrar_malla_forma_de_pago()
        End If

    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs)
        Form_buscar_proveedores_marcas.Show()
        Me.Enabled = False
    End Sub

    Private Sub txt_rut_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_marca_automovil_TextChanged(sender As Object, e As EventArgs) Handles txt_marca_automovil.TextChanged

    End Sub

    Private Sub txt_marca_automovil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_marca_automovil.KeyPress
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

    Private Sub Combo_proveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo_proveedor.SelectedIndexChanged
        mostrar_datos_proveedor()
    End Sub
End Class