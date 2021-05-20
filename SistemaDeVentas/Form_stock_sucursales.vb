Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Resources

Public Class Form_stock_sucursales

    Private Sub Form_stock_sucursales_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        LiberarMemoria()
        recuperar_conexion_actual()
        LiberarMemoria()
        Form_buscador_productos_ventas.WindowState = FormWindowState.Normal
        Form_buscador_productos_ventas.lbl_mensaje.Visible = False
        Form_buscador_productos_ventas.Enabled = True
    End Sub

    Private Sub Form_stock_sucursales_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_stock_sucursales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        verificar_stock()
        LiberarMemoria()
        recuperar_conexion_actual()
        grilla_stock.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        LiberarMemoria()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub verificar_stock()
        txt_codigo.Text = Form_buscador_productos_ventas.grilla_buscador_productos_ventas.CurrentRow.Cells(0).Value
        txt_nombre_producto.Text = Form_buscador_productos_ventas.grilla_buscador_productos_ventas.CurrentRow.Cells(1).Value
        txt_numero_tecnico.Text = Form_buscador_productos_ventas.grilla_buscador_productos_ventas.CurrentRow.Cells(2).Value

        Dim nombre_servidor As String
        Dim nombre_servidor_remoto As String
        Dim base_de_datos As String
        Dim clave_base_de_datos As String
        Dim usuario As String
        Dim recinto As String
        Dim rut_empresa As String = Form_menu_principal.grilla_conexiones.Rows.Count

        For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1

            nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
            nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
            base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
            clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
            usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
            recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
            rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString

            'recinto = Trim(Replace(recinto, "'", "´"))
            Try
                conexion.Close()
                conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"

                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                txt_cantidad.Text = "0"
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_cantidad.Text = DS.Tables(DT.TableName).Rows(0).Item("cantidad")
                End If

                conexion.Close()
                grilla_stock.Rows.Add(recinto, txt_cantidad.Text)

            Catch

            End Try

        Next
        LiberarMemoria()
        recuperar_conexion_actual()
        LiberarMemoria()
    End Sub

End Class