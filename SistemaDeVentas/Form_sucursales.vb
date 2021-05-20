Public Class Form_sucursales


    Private Sub Form_sucursales_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_sucursales_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_sucursales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_logo()

        Try
            SC4.Connection = conexion
            SC4.CommandText = "ALTER TABLE `sucursales` ADD COLUMN `ciudad` VARCHAR(45) NULL AFTER `tipo`;"
            DA4.SelectCommand = SC4
            DA4.Fill(DT4)
        Catch
        End Try




        mostrar_malla_forma_de_pago()
        comunas()
        grilla_forma_de_pago.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)
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
            txt_ciudad.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt_ciudad.AutoCompleteCustomSource = col
            txt_ciudad.AutoCompleteMode = AutoCompleteMode.Suggest

            txt_ciudad.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt_ciudad.AutoCompleteCustomSource = col
            txt_ciudad.AutoCompleteMode = AutoCompleteMode.Suggest
        End If
        txt_ciudad.AutoCompleteSource = AutoCompleteSource.CustomSource
        txt_ciudad.AutoCompleteCustomSource = col
        txt_ciudad.AutoCompleteMode = AutoCompleteMode.Suggest
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub mostrar_malla_forma_de_pago()

        grilla_forma_de_pago.Rows.Clear()
        grilla_forma_de_pago.Columns.Clear()
        grilla_forma_de_pago.Columns.Add("", "SUCURSAL")
        grilla_forma_de_pago.Columns.Add("", "CIUDAD")
        grilla_forma_de_pago.Columns.Add("", "TIPO")

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from sucursales"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_forma_de_pago.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("nombre_sucursal"),
                                                  DS.Tables(DT.TableName).Rows(i).Item("ciudad"),
                                                    DS.Tables(DT.TableName).Rows(i).Item("tipo"))
                'txt_total_deuda.Text = Val(txt_total_deuda.Text) + Val(saldo)
            Next
            grilla_forma_de_pago.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_forma_de_pago.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_forma_de_pago.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
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

    Private Sub Combo_venta_SelectedIndexChanged(sender As Object, e As EventArgs)
        mostrar_malla_forma_de_pago()
    End Sub

    Private Sub btn_agregar_entrada_remuneracion_Click(sender As Object, e As EventArgs) Handles btn_agregar_entrada_remuneracion.Click
        If txt_sucursal.Text = "" Then
            MsgBox("CAMPO SUCURSAL VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_sucursal.Focus()
            Exit Sub
        End If

        If txt_ciudad.Text = "" Then
            MsgBox("CAMPO CIUDAD VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_ciudad.Focus()
            Exit Sub
        End If

        Dim tipo_sucursal As String = "SUCURSAL"

        If CheckBox1.Checked = True Then
            tipo_sucursal = "CASA MATRIZ"
        Else
            tipo_sucursal = "SUCURSAL"
        End If

        conexion.Close()
        Consultas_SQL("select * from sucursales where nombre_sucursal= '" & (txt_sucursal.Text) & "' and ciudad= '" & (txt_ciudad.Text) & "'")
        If DS.Tables(DT.TableName).Rows.Count = 0 Then

            If tipo_sucursal = "CASA MATRIZ" Then
                SC.Connection = conexion
                SC.CommandText = "Update sucursales Set tipo='SUCURSAL' WHERE cod_auto <> '0';"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "INSERT INTO `sucursales` (`nombre_sucursal`, `ciudad`, `tipo`) VALUES ('" & (txt_sucursal.Text) & "', '" & (txt_ciudad.Text) & "', '" & (tipo_sucursal) & "');"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Else
                SC.Connection = conexion
                SC.CommandText = "INSERT INTO `sucursales` (`nombre_sucursal`, `ciudad`, `tipo`) VALUES ('" & (txt_sucursal.Text) & "', '" & (txt_ciudad.Text) & "', '" & (tipo_sucursal) & "');"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If

        Else

            If tipo_sucursal = "CASA MATRIZ" Then
                SC.Connection = conexion
                SC.CommandText = "Update sucursales Set tipo='SUCURSAL' WHERE cod_auto <> '0';"
                DA.SelectCommand = SC
                DA.Fill(DT)

                SC.Connection = conexion
                SC.CommandText = "Update sucursales Set tipo='" & (tipo_sucursal) & "' WHERE nombre_sucursal= '" & (txt_sucursal.Text) & "' and ciudad='" & (txt_ciudad.Text) & "' and cod_auto <> '0';"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Else
                SC.Connection = conexion
                SC.CommandText = "Update sucursales Set tipo='" & (tipo_sucursal) & "' WHERE nombre_sucursal= '" & (txt_sucursal.Text) & "' and ciudad='" & (txt_ciudad.Text) & "' and cod_auto <> '0';"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
        End If

        mostrar_malla_forma_de_pago()
        txt_sucursal.Text = ""
        txt_ciudad.Text = ""
    End Sub

    Private Sub txt_nombre_TextChanged(sender As Object, e As EventArgs) Handles txt_ciudad.TextChanged

    End Sub

    Private Sub txt_nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_ciudad.KeyPress
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

    Private Sub btn_quitar_entrada_remuneracion_Click(sender As Object, e As EventArgs) Handles btn_quitar_entrada_remuneracion.Click
        'Dim VarEstado As String
        If grilla_forma_de_pago.Rows.Count > 0 Then

            Dim valormensaje As Integer
            valormensaje = MsgBox("¿ESTA SEGURO DE ELIMINAR LA SUCURSAL?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")


            If valormensaje = vbYes Then
                Dim nombre_sucursal As String
                Dim ciudad As String

                nombre_sucursal = grilla_forma_de_pago.CurrentRow.Cells(0).Value
                ciudad = grilla_forma_de_pago.CurrentRow.Cells(1).Value

                SC.Connection = conexion
                SC.CommandText = "DELETE FROM sucursales WHERE nombre_sucursal='" & (nombre_sucursal) & "' and ciudad='" & (ciudad) & "' and cod_auto <> '0'"
                DA.SelectCommand = SC
                DA.Fill(DT)

            End If
            mostrar_malla_forma_de_pago()
        End If

    End Sub

    Private Sub grilla_detalle_cuadratura_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla_forma_de_pago.CellContentClick

    End Sub

    Private Sub grilla_detalle_cuadratura_Click(sender As Object, e As EventArgs) Handles grilla_forma_de_pago.Click
        txt_sucursal.Text = grilla_forma_de_pago.CurrentRow.Cells(0).Value()
        txt_ciudad.Text = grilla_forma_de_pago.CurrentRow.Cells(1).Value()
    End Sub

    Private Sub txt_sucursal_TextChanged(sender As Object, e As EventArgs) Handles txt_sucursal.TextChanged

    End Sub

    Private Sub txt_sucursal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_sucursal.KeyPress
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
End Class