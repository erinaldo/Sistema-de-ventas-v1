Imports System.Deployment.Application

Public Class Form_detalle_actualizaciones

    Private Sub Form_detalle_actualizaciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        grabar_actualizacion()
        Form_menu_principal.Enabled = True
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_detalle_actualizaciones_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_detalle_actualizaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            lbl_version.Text = "VERSION " & ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
        Catch err As InvalidDeploymentException
        End Try

        cargar_logo()
        mensaje()
        btn_aceptar.Focus()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Me.Close()
    End Sub

    Sub mensaje()



        If mirutempresa = "87686300-6" Then
            TextBoxDescription.Text = vbCrLf & "SE AGREGO UN REGISTRO AUTOMATICO PARA COBRANZAS AL ENVIAR UN CORREO ELECTRICO DESDE ESTADOS DE CUENTA."
            TextBoxDescription.Text = TextBoxDescription.Text & vbCrLf & vbCrLf & "SE MODIFICO EL OBJETO PARA ESTABLECER EL ESTADO DE LAS CUENTAS CORRIENTES A UN COMBOBOX."
            Exit Sub
        End If
        If mirutempresa = "81921000-4" Then
            TextBoxDescription.Text = vbCrLf & "ESTA ACTUALIZACION ES PARA CORREGIR LA CARTOLA CARDEX A PEDIDO DE ALVARO CHACON."
            TextBoxDescription.Text = TextBoxDescription.Text & vbCrLf & vbCrLf & "SE MODIFICO EL OBJETO PARA ESTABLECER EL ESTADO DE LAS CUENTAS CORRIENTES A UN COMBOBOX."
            Exit Sub
        End If

        TextBoxDescription.Text = vbCrLf & "CORRECCION DE ERRORES VARIOS."
        TextBoxDescription.Text = TextBoxDescription.Text & vbCrLf & vbCrLf & "SE MODIFICO EL OBJETO PARA ESTABLECER EL ESTADO DE LAS CUENTAS CORRIENTES A UN COMBOBOX."

    End Sub

    Sub grabar_actualizacion()

        Dim detalle_actualizacion As String
        detalle_actualizacion = TextBoxDescription.Text
        If detalle_actualizacion.Length > 20 Then
            detalle_actualizacion = detalle_actualizacion.Substring(0, 20)
        End If

        Try
            If CheckBox_mostrar_mensaje.Checked = True Then
                SC.Connection = conexion
                SC.CommandText = "INSERT INTO detalle_de_actualizaciones (`mostrar_mensaje`, `version`, `mensaje`, `usuario_responsable`) VALUES ('NO', '" & (lbl_version.Text) & "', '" & (detalle_actualizacion) & "', '" & (miusuario) & "')" '"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
        Catch
        End Try
    End Sub

End Class