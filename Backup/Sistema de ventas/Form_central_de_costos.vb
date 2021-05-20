Public Class Form_central_de_costos

    Private Sub Form_central_de_costos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_central_de_costos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_central_de_costos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        'malla_costos()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub

    Private Sub bbtn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
    End Sub

    Sub malla_costos()
        'Dim consulta_busqueda As String
        'consulta_busqueda = "select * from central_de_costos, familia, proveedores where familia.codigo=central_de_costos.familia and central_de_costos.proveedor=proveedores.rut_proveedor "

        ''  consulta_busqueda = "SELECT RUT_CLIENTE,  cod_CLIENTE, NOMBRE_CLIENTE, DIRECCION_CLIENTE, EMAIL_CLIENTE, COMUNA_CLIENTE, TELEFONO_CLIENTE,  GIRO_CLIENTE, CIUDAD_CLIENTE FROM CLIENTES WHERE"

        'Dim cadena As String
        'Dim tabla() As String
        'Dim n As Integer

        'cadena = txt_busqueda.Text
        ''   Dim split As String() = words.Split(New [Char]() {" "c, ","c, "."c, ":"c})
        'tabla = Split(cadena, " ")

        'For n = 0 To UBound(tabla, 1)
        '    Dim fin_consulta As String
        '    fin_consulta = Strings.Right(consulta_busqueda, 5)

        '    consulta_busqueda = consulta_busqueda & " and CONCAT_WS(' ', codigo_interno, codigo_barra, marca, numero_tecnico, aplicacion, nombre_familia, nombre, costo, precio_venta_sugerido, fecha, margen_1, margen_2, margen_3, margen_4, margen_5, rut_proveedor, nombre_proveedor) LIKE '" & ("%" & tabla(n) & "%") & "'"

        'Next


        Dim consulta_busqueda As String
        consulta_busqueda = "select * from central_de_costos, familia, proveedores where familia.codigo=central_de_costos.familia and central_de_costos.proveedor=proveedores.rut_proveedor and proveedores.rut_proveedor='" & (txt_rut_cliente.Text) & "' "



        consulta_busqueda = consulta_busqueda & " group by codigo_barra"

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        'SC.CommandText = "select * from central_de_costos, familia, proveedores where familia.codigo=central_de_costos.familia and central_de_costos.proveedor=proveedores.rut_proveedor group by codigo_barra"
        SC.CommandText = "select * from central_de_costos, familia, proveedores where familia.codigo=central_de_costos.familia and central_de_costos.proveedor=proveedores.rut_proveedor and proveedores.rut_proveedor='" & (txt_rut_cliente.Text) & "' "

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_costos.Rows.Clear()
        grilla_costos.Columns.Clear()
        grilla_costos.Columns.Add("", "RUT PROVEEDOR")
        grilla_costos.Columns.Add("", "NOMBRE PROVEEDOR")
        grilla_costos.Columns.Add("", "FECHA")
        grilla_costos.Columns.Add("", "CODIGO INTERNO")
        grilla_costos.Columns.Add("", "CODIGO BARRA")
        grilla_costos.Columns.Add("", "MARCA")
        grilla_costos.Columns.Add("", "MOMBRE")
        grilla_costos.Columns.Add("", "NRO. TECNICO")
        grilla_costos.Columns.Add("", "APLICACION")
        grilla_costos.Columns.Add("", "FAMILIA")
        grilla_costos.Columns.Add("", "COSTO")
        grilla_costos.Columns.Add("", "PRECIO")
        grilla_costos.Columns.Add("", "PVS")
        grilla_costos.Columns.Add("", "MARGEN 1")
        grilla_costos.Columns.Add("", "MARGEN 2")
        grilla_costos.Columns.Add("", "MARGEN 3")
        grilla_costos.Columns.Add("", "MARGEN 4")
        grilla_costos.Columns.Add("", "MARGEN 5")
        grilla_costos.Columns.Add("", "MAESTRA")

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim MiFechaCentralDeCostos As Date
                Dim MiFechaCentralDeCostos2 As String
                MiFechaCentralDeCostos = DS.Tables(DT.TableName).Rows(i).Item("fecha")
                MiFechaCentralDeCostos2 = MiFechaCentralDeCostos.ToString("dd-MM-yyy")

                grilla_costos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("RUT_proveedor"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("nombre_proveedor"), _
                                                    MiFechaCentralDeCostos2, _
                                                   DS.Tables(DT.TableName).Rows(i).Item("codigo_interno"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("codigo_barra"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("marca"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("nombre"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("aplicacion"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("nombre_familia"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("costo"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("precio"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("precio_venta_sugerido"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("margen_1"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("margen_2"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("margen_3"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("margen_4"), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("margen_5"), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("maestra"))
            Next
        End If

        If grilla_costos.Rows.Count <> 0 Then
            If grilla_costos.Columns(0).Width = 100 Then
                grilla_costos.Columns(0).Width = 99
            Else
                grilla_costos.Columns(0).Width = 100
            End If

            grilla_costos.Columns(1).Width = 200
            grilla_costos.Columns(2).Width = 100
            grilla_costos.Columns(3).Width = 100
            grilla_costos.Columns(4).Width = 100
            grilla_costos.Columns(5).Width = 100
            grilla_costos.Columns(6).Width = 100
            grilla_costos.Columns(7).Width = 100
            grilla_costos.Columns(8).Width = 100
            grilla_costos.Columns(9).Width = 100
            grilla_costos.Columns(10).Width = 100
            grilla_costos.Columns(11).Width = 100
            grilla_costos.Columns(12).Width = 100
            grilla_costos.Columns(13).Width = 100
            grilla_costos.Columns(14).Width = 100
            grilla_costos.Columns(15).Width = 100
            grilla_costos.Columns(16).Width = 100
            grilla_costos.Columns(17).Width = 100
            grilla_costos.Columns(18).Width = 100

            grilla_costos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_costos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_costos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_costos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_costos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_costos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_costos.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_costos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_costos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_costos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_costos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_costos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_costos.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_costos.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_costos.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_costos.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_costos.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_costos.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_costos.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        malla_costos()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub txt_busqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_busqueda.TextChanged
        grilla_costos.Rows.Clear()
        grilla_costos.Columns.Clear()
    End Sub

    Sub mostrar_datos_proveedor()
        If txt_rut_cliente.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from proveedores where rut_proveedor ='" & (txt_rut_cliente.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_proveedor")
                txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_proveedor")
                txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_proveedor")
                'txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_auto")
                txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_proveedor")
                txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_proveedor")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_proveedor")
                txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_proveedor")
                txt_representante.Text = DS.Tables(DT.TableName).Rows(0).Item("representante_proveedor")
                txt_rut_cliente.Focus()
            Else
                '     MsgBox("RUT NO ENCONTRADO", 0 + 16, "ERROR")
                txt_rut_cliente.Focus()
            End If
            conexion.Close()
        End If
    End Sub

    Private Sub txt_rut_cliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut_cliente.KeyPress
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

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
  

            lbl_mensaje.Visible = True
            Me.Enabled = False
            guion_rut()
            mostrar_datos_proveedor()
            malla_costos()
            lbl_mensaje.Visible = False
            Me.Enabled = True
        End If
    End Sub

    Sub guion_rut()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut_cliente.Text
        If rut_cliente.Length > 2 Then

            guion = rut_cliente(rut_cliente.Length - 2).ToString()

            If guion <> "-" Then
                Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                rut_cliente = rut_cliente & "-" & fin_rut
                txt_rut_cliente.Text = rut_cliente
            End If
        End If

    End Sub

    Private Sub txt_rut_cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut_cliente.TextChanged

    End Sub
End Class