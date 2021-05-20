Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class Form_desea_enviar_cotizacion

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Form_enviar_correo_cotizacion_ventas.txt_nro_cotizacion.Text = Form_venta.txt_factura.Text
        Form_enviar_correo_cotizacion_ventas.Show()

        Me.Close()
    End Sub

    Private Sub Form_desea_enviar_cotizacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Form_enviar_correo_cotizacion_ventas.Visible = False Then
            Form_venta.Enabled = True
            Form_venta.limpiar()
            Form_venta.controles(False, True)
            Form_venta.btn_nueva.Focus()
        End If
    End Sub

    Private Sub Form_desea_enviar_cotizacion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_desea_enviar_cotizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Form_impreso_corectamente.Show()
        '   Me.Close()
        Timer_enviar_cotizacion.Start()
    End Sub

    Private Structure LASTINPUTINFO
        Public cbSize As UInteger
        Public dwTime As UInteger
    End Structure

    <DllImport("User32.dll")> _
    Private Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    End Function

    Public Function GetInactiveTime() As Nullable(Of TimeSpan)
        Dim info As LASTINPUTINFO = New LASTINPUTINFO
        info.cbSize = CUInt(Marshal.SizeOf(info))
        If (GetLastInputInfo(info)) Then
            Return TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime)
        Else
            Return Nothing
        End If
    End Function

    Private Sub Timer_enviar_cotizacion_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_enviar_cotizacion.Tick
        Dim inactiveTime = GetInactiveTime()
        If (inactiveTime.Value.TotalSeconds > 6) Then
            Me.Close()
        End If
    End Sub

End Class