Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_visor_totales



    Private Sub txt_porcentaje_desc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_total.KeyPress

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

        If txt_total.Text <> "" Then
            If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
                mostrar_malla()
            End If
        End If
    End Sub

    Sub mostrar_malla()
        If combo_venta.Text = "BOLETA" Then
            Dim DT As New DataTable
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select n_boleta as NUMERO, fecha_venta AS FECHA, BOLETA.rut_cliente AS RUT, nombre_cliente as NOMBRE,  total AS TOTAL from BOLETA, clientes where total = '" & (txt_total.Text) & "' and fecha_venta >='" & (dtp_desde.Text) & "' and fecha_venta <='" & (dtp_hasta.Text) & "' AND BOLETA.rut_cliente=clientes.rut_cliente group by BOLETA.n_boleta"
            DA.SelectCommand = SC

            DA.Fill(DT)
            DS.Tables.Add(DT)

            grilla_estado_de_cuenta_final.DataSource = DS.Tables(DT.TableName)
            conexion.Close()
        End If

        If combo_venta.Text = "FACTURA" Then
            Dim DT As New DataTable
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select n_factura as NUMERO, fecha_venta AS FECHA, factura.rut_cliente AS RUT, nombre_cliente as NOMBRE,  total AS TOTAL from factura, clientes where total = '" & (txt_total.Text) & "' and fecha_venta >='" & (dtp_desde.Text) & "' and fecha_venta <='" & (dtp_hasta.Text) & "' AND factura.rut_cliente=clientes.rut_cliente group by factura.n_factura"
            DA.SelectCommand = SC

            DA.Fill(DT)
            DS.Tables.Add(DT)

            grilla_estado_de_cuenta_final.DataSource = DS.Tables(DT.TableName)
            conexion.Close()
        End If

        If combo_venta.Text = "GUIA" Then
            Dim DT As New DataTable
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select n_guia as NUMERO, fecha_venta AS FECHA, guia.rut_cliente AS RUT, nombre_cliente as NOMBRE,  total AS TOTAL from guia, clientes where total = '" & (txt_total.Text) & "' and fecha_venta >='" & (dtp_desde.Text) & "' and fecha_venta <='" & (dtp_hasta.Text) & "' AND guia.rut_cliente=clientes.rut_cliente  group by guia.n_guia"
            DA.SelectCommand = SC

            DA.Fill(DT)
            DS.Tables.Add(DT)

            grilla_estado_de_cuenta_final.DataSource = DS.Tables(DT.TableName)
            conexion.Close()
        End If
    End Sub

    Private Sub btn_buscar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos.Click
        mostrar_malla()
    End Sub

    Private Sub Form_visor_totales_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_visor_totales_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_visor_totales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtp_desde.CustomFormat = "yyy-MM-dd"
        dtp_hasta.CustomFormat = "yyy-MM-dd"
        grilla_estado_de_cuenta_final.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_buscar_productos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_productos.GotFocus
        btn_buscar_productos.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_productos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_productos.LostFocus
        btn_buscar_productos.BackColor = Color.Transparent
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub txt_total_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_total.GotFocus
        txt_total.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_total_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_total.LostFocus
        txt_total.BackColor = Color.White
    End Sub

    Private Sub combo_venta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_venta.GotFocus
        combo_venta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_venta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_venta.LostFocus
        combo_venta.BackColor = Color.White
    End Sub

    Private Sub txt_total_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total.TextChanged

    End Sub

End Class