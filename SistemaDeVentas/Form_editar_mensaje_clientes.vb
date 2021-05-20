Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_editar_mensaje_clientes

    Private Sub Form_editar_mensaje_clientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_registro_cuentas_corrientes.Enabled = True
        Form_registro_cuentas_corrientes.txt_nombres.Focus()
    End Sub

    Private Sub Form_editar_mensaje_clientes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_editar_mensaje_clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        mostrar_datos_clientes()
        txt_caracteres.Text = 300 - Len(txt_mensaje.Text)
        controles(False, True)
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub mostrar_datos_clientes()
        conexion.Close()
        'If Form_venta.txt_cod_cliente.Text <> "" Then
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select mensaje from clientes where cod_cliente ='" & (Form_registro_cuentas_corrientes.txt_codigo_cliente.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        ' If DS.Tables(DT.TableName).Rows.Count > 0 Then
        If DS.Tables(DT.TableName).Rows.Count = 1 Then
            txt_mensaje.Text = DS.Tables(DT.TableName).Rows(0).Item("mensaje")
        End If
        'End If
    End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)

        btn_modificar.Enabled = b

        btn_guardar.Enabled = a
        btn_cancelar.Enabled = a



        txt_mensaje.Enabled = a



    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click

        controles(True, False)
        txt_mensaje.Focus()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        mostrar_datos_clientes()
        controles(False, True)
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        'Dim mensaje As String = ""

        'If txt_mensaje.Text = "" Then mensaje = "CAMPO MENSAJE VACIO" + Chr(13) & mensaje
        'If mensaje <> "" Then
        '    MsgBox(mensaje, MessageBoxIcon.Information, "ATENCION")
        'Else
        'SC.Connection = conexion
        'SC.CommandText = "UPDATE clientes SET MENSAJE='" & (txt_mensaje.Text) & "'  WHERE cod_cliente = '" & (Form_registro_cuentas_corrientes.txt_codigo_cliente.Text) & "'"
        'DA.SelectCommand = SC
        'DA.Fill(DT)

        'conexion.Close()
        'DS2.Tables.Clear()
        'DT2.Rows.Clear()
        'DT2.Columns.Clear()
        'DS2.Clear()
        'conexion.Open()

        SC2.Connection = conexion
            '   SC2.CommandText = "UPDATE clientes SET MENSAJE='" & (txt_mensaje.Text) & "'  WHERE cod_cliente = '" & (Form_registro_cuentas_corrientes.txt_codigo_cliente.Text) & "'"
            SC2.CommandText = "UPDATE `clientes` SET `mensaje`='" & (txt_mensaje.Text) & "', `fecha_modificacion`='" & (Form_menu_principal.dtp_fecha.Text) & "' WHERE `cod_cliente` = '" & (Form_registro_cuentas_corrientes.txt_codigo_cliente.Text) & "';"

            DA2.SelectCommand = SC2
            DA2.Fill(DT2)




            '   conexion.Close()

            MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
            controles(False, True)
        'End If
    End Sub

    Private Sub txt_mensaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub txt_mensaje_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub txt_mensaje_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_mensaje.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        txt_caracteres.Text = 300 - Len(txt_mensaje.Text)
    End Sub

    Private Sub txt_mensaje_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_mensaje.TextChanged

    End Sub
End Class