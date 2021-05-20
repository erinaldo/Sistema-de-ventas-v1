
Public Class Form_numero_de_atencion_cliente

    Private Sub Form_numero_de_atencion_cliente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_numero_de_atencion_cliente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_numero_de_atencion_cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        crear_numero_atencion()

        SC.Connection = conexion
        SC.CommandText = "INSERT INTO `basededatos`.`numero_atencion_meson` (`numero_atencion`, `fecha`, `hora`, `usuario_responsable`) VALUES ('" & (txt_numero.Text) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (Form_menu_principal.lbl_hora.Text) & "', '" & (miusuario) & "');"
        DA.SelectCommand = SC
        DA.Fill(DT)
    End Sub

    Sub crear_numero_atencion()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        Try
            SC.Connection = conexion
            SC.CommandText = "select max(numero_atencion) as numero_atencion from numero_atencion_meson where fecha ='" & (Form_menu_principal.dtp_fecha.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_numero.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_atencion")
                txt_numero.Text = Val(txt_numero.Text) + 1
            End If
        Catch err As InvalidCastException
            txt_numero.Text = 1
            Exit Sub
        End Try
        conexion.Close()
    End Sub

    Private Sub btn_siguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_siguiente.Click




        crear_numero_atencion()

        SC.Connection = conexion
        SC.CommandText = "INSERT INTO `basededatos`.`numero_atencion_meson` (`numero_atencion`, `fecha`, `hora`, `usuario_responsable`) VALUES ('" & (txt_numero.Text) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "', '" & (Form_menu_principal.lbl_hora.Text) & "', '" & (miusuario) & "');"
        DA.SelectCommand = SC
        DA.Fill(DT)
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
End Class