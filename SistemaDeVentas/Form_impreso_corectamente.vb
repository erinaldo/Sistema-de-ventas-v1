Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class Form_impreso_corectamente

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Me.Close()
    End Sub

    Private Sub Form_impreso_corectamente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Form_orden_de_compra.Close()
        Form_venta.limpiar()
        ' Form_venta.controles(True, False)
        Form_venta.Enabled = True
        Form_nota_credito.Enabled = True
        Form_venta.btn_nueva.Focus()
    End Sub

    Private Sub Form_impreso_corectamente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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


    Private Sub Timer_impreso_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_impreso.Tick
        Dim inactiveTime = GetInactiveTime()
        If (inactiveTime.Value.TotalSeconds > 2) Then
            Me.Close()
        End If
    End Sub

    Private Sub Form_impreso_corectamente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer_impreso.Start()
    End Sub



    Private Sub btn_aceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.GotFocus
        btn_aceptar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_aceptar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.LostFocus
        btn_aceptar.BackColor = Color.Transparent
    End Sub
End Class