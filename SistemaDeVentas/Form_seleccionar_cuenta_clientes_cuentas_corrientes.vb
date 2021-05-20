Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_seleccionar_cuenta_clientes_cuentas_corrientes

    Private Sub Form_seleccionar_cuenta_clientes_cuentas_corrientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Form_registro_cuentas_corrientes.WindowState = FormWindowState.Normal
        Form_registro_cuentas_corrientes.Enabled = True
        Form_registro_cuentas_corrientes.txt_nombres.Focus()
    End Sub

    Private Sub Form_seleccionar_cuenta_clientes_cuentas_corrientes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

    Private Sub Form_seleccionar_cuenta_clientes_cuentas_corrientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        RUT = Form_registro_cuentas_corrientes.txt_rut.Text
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
            Form_registro_cuentas_corrientes.txt_codigo_cliente.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_cliente")
            Form_registro_cuentas_corrientes.txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
            Form_registro_cuentas_corrientes.combo_tipo.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cliente")
            Form_registro_cuentas_corrientes.txt_nombres.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_cliente")
            Form_registro_cuentas_corrientes.txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("direccion_cliente")
            Form_registro_cuentas_corrientes.txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente")
            Form_registro_cuentas_corrientes.txt_telefono_dos.Text = DS.Tables(DT.TableName).Rows(0).Item("telefono_cliente_dos")
            Form_registro_cuentas_corrientes.txt_email.Text = DS.Tables(DT.TableName).Rows(0).Item("email_cliente")
            Form_registro_cuentas_corrientes.txt_comuna.Text = DS.Tables(DT.TableName).Rows(0).Item("comuna_cliente")
            Form_registro_cuentas_corrientes.txt_ciudad.Text = DS.Tables(DT.TableName).Rows(0).Item("ciudad_cliente")
            Form_registro_cuentas_corrientes.txt_giro.Text = DS.Tables(DT.TableName).Rows(0).Item("giro_cliente")
            Form_registro_cuentas_corrientes.txt_dscto1.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_1")
            Form_registro_cuentas_corrientes.txt_dscto2.Text = DS.Tables(DT.TableName).Rows(0).Item("descuento_2")
            Form_registro_cuentas_corrientes.txt_folio.Text = DS.Tables(DT.TableName).Rows(0).Item("folio_cliente")
            Form_registro_cuentas_corrientes.Combo_tipo_cuenta.Items.Clear()
            Form_registro_cuentas_corrientes.Combo_tipo_cuenta.Items.Add("BOLETA")
            Form_registro_cuentas_corrientes.Combo_tipo_cuenta.Items.Add("GUIA")
            Form_registro_cuentas_corrientes.Combo_tipo_cuenta.Items.Add("FACTURA")
            Form_registro_cuentas_corrientes.Combo_tipo_cuenta.Items.Add("MIXTA")
            Form_registro_cuentas_corrientes.Combo_tipo_cuenta.Items.Add("-")
            Form_registro_cuentas_corrientes.Combo_tipo_cuenta.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_cuenta")
            Form_registro_cuentas_corrientes.txt_cupo.Text = DS.Tables(DT.TableName).Rows(0).Item("cupo_cliente")
            Form_registro_cuentas_corrientes.Combo_cuenta.Text = DS.Tables(DT.TableName).Rows(0).Item("estado_cuenta")
            Form_registro_cuentas_corrientes.Combo_activo.Text = DS.Tables(DT.TableName).Rows(0).Item("activo")
            Form_registro_cuentas_corrientes.txt_representante.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_representante")
            Form_registro_cuentas_corrientes.txt_email_representante.Text = DS.Tables(DT.TableName).Rows(0).Item("email_representante")

            For Each cntrl As Control In Form_registro_cuentas_corrientes.Controls
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
            Form_registro_cuentas_corrientes.txt_rut.Enabled = False
            Form_registro_cuentas_corrientes.txt_nombres.Focus()
            Exit Sub
        Else
            Form_registro_cuentas_corrientes.txt_rut.Focus()
        End If
        conexion.Close()
    End Sub
    Private Sub grilla_clientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grilla_clientes.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim codigo As String
            Dim rut As String

            If grilla_clientes.Rows.Count <= 0 Then
                Me.Close()
                Form_registro_cuentas_corrientes.txt_rut.Focus()
                Me.Close()
            Else
                codigo = grilla_clientes.CurrentRow.Cells(1).Value
                rut = grilla_clientes.CurrentRow.Cells(0).Value
                Form_registro_cuentas_corrientes.limpiar()
                ' Form_registro_cuentas_corrientes.txt_rut.Text = rut
                mostrar_datos_clientes()
                Me.Close()
            End If
        End If
    End Sub



    Private Sub grilla_clientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_clientes.CellContentClick

    End Sub
End Class