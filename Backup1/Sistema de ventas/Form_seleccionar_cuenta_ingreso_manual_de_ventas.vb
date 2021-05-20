Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_seleccionar_cuenta_ingreso_manual_de_ventas

    Private Sub Form_seleccionar_cuenta_ingreso_manual_de_ventas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_venta_manual.WindowState = FormWindowState.Normal

        Form_venta_manual.Enabled = True

        If Form_venta_manual.txt_nombre_cliente.Text = "" And Form_venta_manual.txt_direccion_cliente.Text = "" And Form_venta_manual.txt_cod_cliente.Text = "" And Form_venta_manual.txt_comuna_cliente.Text = "" Then
            Form_venta_manual.txt_rut_cliente.Focus()
        Else
            Form_venta_manual.txt_codigo.Focus()
        End If
    End Sub


    Private Sub Form_seleccionar_cuenta_ingreso_manual_de_ventas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_seleccionar_cuenta_ingreso_manual_de_ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        mostrar_malla()
        grilla_clientes.Focus()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub mostrar_malla()
        'conexion.Close()
        Dim RUT As String

        RUT = Form_venta_manual.txt_rut_cliente.Text
        conexion.Close()
        DS4.Tables.Clear()
        DT4.Rows.Clear()
        DT4.Columns.Clear()
        DS4.Clear()
        conexion.Open()

        SC4.Connection = conexion
        SC4.CommandText = "SELECT RUT_CLIENTE AS RUT, cod_CLIENTE AS COD, NOMBRE_CLIENTE AS NOMBRE, DIRECCION_CLIENTE AS DIRECCION, COMUNA_CLIENTE AS COMUNA, CIUDAD_CLIENTE AS CIUDAD, GIRO_CLIENTE AS GIRO FROM CLIENTES where rut_cliente = '" & (RUT) & "'"

        DA4.SelectCommand = SC4
        DA4.Fill(DT4)
        DS4.Tables.Add(DT4)

        grilla_clientes.DataSource = DS4.Tables(DT4.TableName)
        conexion.Close()
        grilla_clientes.Columns(0).Visible = False
        grilla_clientes.Columns(1).Visible = False
        grilla_clientes.Columns(3).Visible = False
        lbl_nombre.Text = "NOMBRE CLIENTE: " & grilla_clientes.Rows(0).Cells(2).Value.ToString
    End Sub

    Private Sub grilla_clientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_clientes.CellContentClick

    End Sub

    Private Sub grilla_clientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grilla_clientes.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim codigo As String
            Dim rut As String

            If grilla_clientes.Rows.Count <= 0 Then
                Me.Close()
                Form_venta.txt_codigo.Focus()
                Me.Close()
            Else
                codigo = grilla_clientes.CurrentRow.Cells(0).Value
                rut = grilla_clientes.CurrentRow.Cells(1).Value

                Form_venta_manual.limpiar_datos_clientes_enter()
                Form_venta_manual.txt_rut_cliente.Text = codigo
                '   Form_venta.txt_porcentaje_desc.Text = "0"
                mostrar_datos_clientes()
                ' Form_venta.llenar_combo_retira()
                '  Form_venta_manual.limpiar_datos_clientes_retira()
                ' Form_venta.guardar_descuento()
                'Form_venta.grilla_detalle_venta.Rows.Clear()
                'Form_venta.cargar_descuento()
                Form_venta_manual.calcular_totales()


                Me.Close()
            End If
        End If
    End Sub

    Private Sub grilla_clientes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grilla_clientes.KeyPress
        'If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
        '    Dim codigo As String
        '    Dim rut As String

        '    If grilla_clientes.Rows.Count <= 0 Then
        '        Me.Close()
        '        Form_venta.txt_codigo.Focus()
        '        Me.Close()
        '    Else
        '        codigo = grilla_clientes.CurrentRow.Cells(0).Value
        '        rut = grilla_clientes.CurrentRow.Cells(1).Value

        '        Form_venta.limpiar_datos_clientes_enter()
        '        Form_venta.txt_rut.Text = codigo
        '        Form_venta.txt_descto.Text = "0"
        '        mostrar_datos_clientes()
        '        ' Form_venta.llenar_combo_retira()
        '        Form_venta.limpiar_datos_clientes_retira()
        '        Form_venta.guardar_descuento()
        '        Form_venta.grilla_detalle.Rows.Clear()
        '        Form_venta.cargar_descuento()
        '        Form_venta.calcular_totales()
        '        Me.Close()
        '    End If
        'End If


    End Sub


    Sub mostrar_datos_clientes()
        conexion.Close()


        Dim codigo As String
        Dim rut As String

        codigo = grilla_clientes.CurrentRow.Cells(1).Value
        rut = grilla_clientes.CurrentRow.Cells(0).Value
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from clientes where rut_cliente ='" & (rut) & "' and cod_cliente ='" & (codigo) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count = 1 Then

            Form_venta_manual.lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
            Form_venta_manual.txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
            Form_venta_manual.txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
            Form_venta_manual.txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
            Form_venta_manual.txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
            '    Form_venta_manual.txt_descuento_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
            '   Form_venta_manual.txt_descuento_cliente_2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
            Form_venta_manual.txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_cliente")
            Form_venta_manual.txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
            Form_venta_manual.txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
            Form_venta_manual.txt_cuenta_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("estado_cuenta")
            Form_venta_manual.txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
            '  Form_venta_manual.txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
            '  Form_venta_manual.txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
            Form_venta_manual.txt_porcentaje_desc.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
            '    Form_venta_manual.txt_orden_de_compra.Text = DS.Tables(DT.TableName).Rows(0).Item("orden_de_compra")
            '   Form_venta_manual.txt_tipo_documento.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")





            If Form_venta_manual.combo_venta.Text = "BOLETA" Then
                Form_venta_manual.txt_codigo.Focus()
            End If

            If Form_venta_manual.combo_venta.Text = "BOLETA DE CREDITO" Then
                Form_venta_manual.txt_codigo.Focus()
            End If

            If Form_venta_manual.combo_venta.Text = "COTIZACION" Then
                Form_venta_manual.txt_codigo.Focus()
            End If


        Else


            Form_venta_manual.txt_codigo.Focus()


        End If
        conexion.Close()
    End Sub


End Class