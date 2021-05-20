Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_seleccionar_cuenta_nota_credito

    Private Sub Form_selecionar_cuenta_nota_credito_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_nota_credito.WindowState = FormWindowState.Normal
        Form_nota_credito.Enabled = True
        Form_nota_credito.txt_rut_cliente.Focus()
    End Sub

    Private Sub Form_selecionar_cuenta_nota_credito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        mostrar_malla()
        grilla_clientes.Focus()
    End Sub

    Private Sub Form_seleccionar_cuenta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_seleccionar_cuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        mostrar_malla()
        grilla_clientes.Focus()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub mostrar_malla()
        'conexion.Close()
        Dim RUT As String

        RUT = Form_nota_credito.txt_rut_cliente.Text
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
                Form_nota_credito.txt_codigo.Focus()
                Me.Close()
            Else
                codigo = grilla_clientes.CurrentRow.Cells(0).Value
                rut = grilla_clientes.CurrentRow.Cells(1).Value

                Form_nota_credito.limpiar_datos_clientes_enter()
                Form_nota_credito.txt_rut_cliente.Text = codigo
                '   Form_venta.txt_porcentaje_desc.Text = "0"
                mostrar_datos_clientes()
                ' Form_venta.llenar_combo_retira()
                '   Form_nota_credito.limpiar_datos_clientes_retira()
                ' Form_venta.guardar_descuento()
                'Form_venta.grilla_detalle_venta.Rows.Clear()
                'Form_venta.cargar_descuento()
                Form_nota_credito.calcular_totales()




















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
            Form_nota_credito.lbl_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
            Form_nota_credito.txt_rut_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
            Form_nota_credito.txt_nombre_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
            Form_nota_credito.txt_direccion_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
            Form_nota_credito.txt_cod_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
            Form_nota_credito.txt_descuento_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
            Form_nota_credito.txt_giro_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_cliente")
            Form_nota_credito.txt_comuna_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
            Form_nota_credito.txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
            Form_nota_credito.txt_cuenta_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("estado_cuenta")
            Form_nota_credito.txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")

            Form_nota_credito.txt_correo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
            Form_nota_credito.txt_ciudad_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")



        Else


            Form_nota_credito.txt_codigo.Focus()


        End If
        conexion.Close()
    End Sub


End Class