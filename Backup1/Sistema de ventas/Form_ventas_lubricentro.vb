Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.IO
Imports System.Math
Public Class Form_ventas_lubricentro

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If txt_codigo_patente.Text = "" Or txt_nombre.Text = "" Or Combo_vendedor.Text = "" Or Combo_vendedor.Text = "-" Then


            Dim valormensaje As Integer
            valormensaje = MsgBox("¿LA INFORMACION DEL VEHICULO ESTA INCOMPLETA, DESEA CONTINUAR?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
            If valormensaje <> vbYes Then

                If txt_codigo_patente.Text = "" Then
                    txt_codigo_patente.Focus()
                    Exit Sub
                End If

                If txt_nombre.Text = "" Then
                    txt_nombre.Focus()
                    Exit Sub
                End If

                If txt_kilometraje.Text = "" Then
                    txt_kilometraje.Focus()
                    Exit Sub
                End If


            End If


        End If

        If txt_nombre.Text = "" Then
            MsgBox("CAMPO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nombre.Focus()
            Exit Sub
        End If

     


        'Dim cod_auto_servicio As String
        'For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1
        '    cod_auto_servicio = grilla_estado_de_cuenta.Rows(i).Cells(34).Value.ToString

        '    If cod_auto_servicio = txt_cod_auto_servicio.Text Then

        '        SC.Connection = conexion
        '        SC.CommandText = "DELETE FROM servicios_lubricentro WHERE cod_auto='" & (txt_cod_auto_servicio.Text) & "'"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)


        '        Exit For
        '    End If
        'Next
     



        If txt_cod_auto_servicio.Text <> "" Then

            SC.Connection = conexion
            SC.CommandText = "UPDATE servicios_lubricentro SET patente='" & (txt_codigo_patente.Text) & "', modelo='" & (txt_nombre.Text) & "', codigo_1='" & (txt_codigo_filtro_aceite.Text) & "', filtro_de_aceite='" & (txt_nombre_filtro_aceite.Text) & "', codigo_2='" & (txt_codigo_aceite_motor.Text) & "', aceite_de_motor='" & (txt_nombre_aceite_motor.Text) & "', codigo_3='" & (txt_codigo_filtro_aire.Text) & "', filtro_de_aire='" & (txt_nombre_filtro_aire.Text) & "', codigo_4='" & (txt_codigo_aceite_combustible.Text) & "', filtro_de_combustible='" & (txt_nombre_aceite_combustible.Text) & "', codigo_5='" & (txt_codigo_aceite_caja.Text) & "', aceite_de_caja='" & (txt_nombre_aceite_caja.Text) & "', codigo_6='" & (txt_codigo_aceite_diferencial.Text) & "', aceite_diferencial='" & (txt_nombre_aceite_diferencial.Text) & "', codigo_7='" & (txt_codigo_otros_1.Text) & "', otros_1='" & (txt_nombre_otros_1.Text) & "', codigo_8='" & (txt_codigo_otros_2.Text) & "', otros_2='" & (txt_nombre_otros_2.Text) & "', codigo_9='" & (txt_codigo_otros_3.Text) & "', otros_3='" & (txt_nombre_otros_3.Text) & "',  codigo_10='" & (txt_codigo_otros_4.Text) & "', otros_4='" & (txt_nombre_otros_4.Text) & "',kilometraje='" & (txt_kilometraje.Text) & "', cantidad_1='" & (txt_cantidad_1.Text) & "', cantidad_2='" & (txt_cantidad_2.Text) & "', cantidad_3='" & (txt_cantidad_3.Text) & "', cantidad_4='" & (txt_cantidad_4.Text) & "', cantidad_5='" & (txt_cantidad_5.Text) & "', cantidad_6='" & (txt_cantidad_6.Text) & "', cantidad_7='" & (txt_cantidad_7.Text) & "',cantidad_8='" & (txt_cantidad_8.Text) & "', cantidad_9='" & (txt_cantidad_9.Text) & "',cantidad_10='" & (txt_cantidad_10.Text) & "', rut_mecanico='" & (txt_rut_vendedor.Text) & "', usuario_responsable='" & (miusuario) & "', fecha='" & (Form_menu_principal.dtp_fecha.Text) & "', estado='PENDIENTE', tipo_documento='', nro_documento='', hora='" & (Form_menu_principal.lbl_hora.Text) & "' WHERE cod_auto='" & (txt_cod_auto_servicio.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

        Else

            SC.Connection = conexion
            SC.CommandText = "insert into servicios_lubricentro (patente, modelo, codigo_1, filtro_de_aceite, codigo_2, aceite_de_motor, codigo_3, filtro_de_aire, codigo_4, filtro_de_combustible, codigo_5, aceite_de_caja, codigo_6, aceite_diferencial, codigo_7, otros_1, codigo_8, otros_2, codigo_9, otros_3,  codigo_10, otros_4,kilometraje, cantidad_1, cantidad_2, cantidad_3, cantidad_4, cantidad_5, cantidad_6, cantidad_7,cantidad_8, cantidad_9,cantidad_10, rut_mecanico, usuario_responsable, fecha, estado, tipo_documento, nro_documento, hora) values('" & (txt_codigo_patente.Text) & "', '" & (txt_nombre.Text) & "', '" & (txt_codigo_filtro_aceite.Text) & "', '" & (txt_nombre_filtro_aceite.Text) & "', '" & (txt_codigo_aceite_motor.Text) & "', '" & (txt_nombre_aceite_motor.Text) & "', '" & (txt_codigo_filtro_aire.Text) & "', '" & (txt_nombre_filtro_aire.Text) & "', '" & (txt_codigo_aceite_combustible.Text) & "', '" & (txt_nombre_aceite_combustible.Text) & "', '" & (txt_codigo_aceite_caja.Text) & "', '" & (txt_nombre_aceite_caja.Text) & "', '" & (txt_codigo_aceite_diferencial.Text) & "', '" & (txt_nombre_aceite_diferencial.Text) & "', '" & (txt_codigo_otros_1.Text) & "', '" & (txt_nombre_otros_1.Text) & "', '" & (txt_codigo_otros_2.Text) & "', '" & (txt_nombre_otros_2.Text) & "', '" & (txt_codigo_otros_3.Text) & "', '" & (txt_nombre_otros_3.Text) & "', '" & (txt_codigo_otros_4.Text) & "', '" & (txt_nombre_otros_4.Text) & "','" & (txt_kilometraje.Text) & "', '" & (txt_cantidad_1.Text) & "', '" & (txt_cantidad_2.Text) & "', '" & (txt_cantidad_3.Text) & "', '" & (txt_cantidad_4.Text) & "', '" & (txt_cantidad_5.Text) & "', '" & (txt_cantidad_6.Text) & "', '" & (txt_cantidad_7.Text) & "', '" & (txt_cantidad_8.Text) & "', '" & (txt_cantidad_9.Text) & "','" & (txt_cantidad_10.Text) & "', '" & (txt_rut_vendedor.Text) & "', '" & (miusuario) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "', 'PENDIENTE', '', '', '" & (Form_menu_principal.lbl_hora.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

        End If

        mostrar_malla()

        limpiar()
        txt_codigo_filtro_aceite.Focus()

    End Sub

    Private Sub txt_codigo_patente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        color_foco()
    End Sub

    Sub mostrar_malla()
        grilla_estado_de_cuenta.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from servicios_lubricentro where estado='pendiente' ORDER BY cod_auto"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)


        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_auto"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("patente"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("modelo"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("codigo_1"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("filtro_de_aceite"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("codigo_2"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("aceite_de_motor"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("codigo_3"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("filtro_de_aire"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("codigo_4"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("filtro_de_combustible"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("codigo_5"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("aceite_de_caja"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("codigo_6"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("aceite_diferencial"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("codigo_7"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("otros_1"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("codigo_8"), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("otros_2"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("codigo_9"), _
                                                                    DS.Tables(DT.TableName).Rows(i).Item("otros_3"), _
                                                                     DS.Tables(DT.TableName).Rows(i).Item("codigo_10"), _
                                                                      DS.Tables(DT.TableName).Rows(i).Item("otros_4"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("kilometraje"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("cantidad_1"), _
                                                                    DS.Tables(DT.TableName).Rows(i).Item("cantidad_2"), _
                                                                     DS.Tables(DT.TableName).Rows(i).Item("cantidad_3"), _
                                                                      DS.Tables(DT.TableName).Rows(i).Item("cantidad_4"), _
                                                                       DS.Tables(DT.TableName).Rows(i).Item("cantidad_5"), _
                                                                        DS.Tables(DT.TableName).Rows(i).Item("cantidad_6"), _
                                                                         DS.Tables(DT.TableName).Rows(i).Item("cantidad_7"), _
                                                                          DS.Tables(DT.TableName).Rows(i).Item("cantidad_8"), _
                                                                          DS.Tables(DT.TableName).Rows(i).Item("cantidad_9"), _
                                                                          DS.Tables(DT.TableName).Rows(i).Item("cantidad_10"), _
                                                                           DS.Tables(DT.TableName).Rows(i).Item("rut_mecanico"), _
                                                                              DS.Tables(DT.TableName).Rows(i).Item("comentario"))

            Next
        End If

        If grilla_estado_de_cuenta.Rows.Count <> 0 Then

            If grilla_estado_de_cuenta.Columns(0).Width = 200 Then
                grilla_estado_de_cuenta.Columns(0).Width = 150
            Else
                grilla_estado_de_cuenta.Columns(0).Width = 200
            End If

            'grilla_stock_final.Columns(0).Width = 150
            'grilla_stock_final.Columns(1).Width = 300
            'grilla_stock_final.Columns(2).Width = 300
            'grilla_stock_final.Columns(3).Width = 200
            'grilla_stock_final.Columns(4).Width = 150
            'grilla_stock_final.Columns(5).Width = 150
            'grilla_stock_final.Columns(6).Width = 150
            'grilla_stock_final.Columns(7).Width = 300
            'grilla_stock_final.Columns(8).Width = 150
        End If
    End Sub

    Private Sub txt_codigo_patente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

        End If
    End Sub

    Private Sub txt_codigo_patente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_nombre_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        color_foco()
    End Sub

    Private Sub txt_nombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

        End If
    End Sub

    Private Sub txt_nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_telefono_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        color_foco()
    End Sub

    Private Sub txt_telefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

        End If
    End Sub

    Private Sub txt_telefono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_otros_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        color_foco()
    End Sub

    Private Sub txt_otros_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

        End If
    End Sub

    Private Sub txt_otros_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_codigo_filtro_aceite_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_filtro_aceite.GotFocus
        color_foco()
    End Sub

    Private Sub txt_codigo_filtro_aceite_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_filtro_aceite.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        txt_nombre_filtro_aceite.Text = ""
        txt_nro_tecnico_1.Text = ""

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_filtro_de_aceite()

            If txt_nombre_filtro_aceite.Text = "" Then
                MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo_filtro_aceite.Focus()
                Exit Sub
            End If

            txt_cantidad_1.Focus()
        End If
    End Sub

    Private Sub txt_codigo_filtro_aceite_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_filtro_aceite.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_1.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_filtro_aceite_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_filtro_aceite.TextChanged

    End Sub

    Private Sub txt_codigo_aceite_motor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_aceite_motor.GotFocus
        color_foco()
    End Sub

    Private Sub txt_codigo_aceite_motor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_aceite_motor.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        txt_nombre_aceite_motor.Text = ""
        txt_nro_tecnico_2.Text = ""

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_aceite_de_motor()

            If txt_nombre_aceite_motor.Text = "" Then
                MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo_aceite_motor.Focus()
                Exit Sub
            End If

            txt_cantidad_2.Focus()
        End If
    End Sub

    Private Sub txt_codigo_aceite_motor_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_aceite_motor.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_2.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_aceite_motor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_aceite_motor.TextChanged

    End Sub

    Private Sub txt_codigo_filtro_aire_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_filtro_aire.GotFocus
        color_foco()
    End Sub

    Private Sub txt_codigo_filtro_aire_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_filtro_aire.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        txt_nombre_filtro_aire.Text = ""
        txt_nro_tecnico_3.Text = ""

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_filtro_de_aire()

            If txt_nombre_filtro_aire.Text = "" Then
                MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo_filtro_aire.Focus()
                Exit Sub
            End If

            txt_cantidad_3.Focus()
        End If
    End Sub

    Private Sub txt_codigo_filtro_aire_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_filtro_aire.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_3.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_filtro_aire_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_filtro_aire.TextChanged

    End Sub

    Private Sub txt_codigo_aceite_combustible_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_aceite_combustible.GotFocus
        color_foco()
    End Sub

    Private Sub txt_codigo_aceite_combustible_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_aceite_combustible.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        txt_nombre_aceite_combustible.Text = ""
        txt_nro_tecnico_4.Text = ""

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_aceite_de_combustible()


            If txt_nombre_aceite_combustible.Text = "" Then
                MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo_aceite_combustible.Focus()
                Exit Sub
            End If


            txt_cantidad_4.Focus()
        End If
    End Sub

    Private Sub txt_codigo_aceite_combustible_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_aceite_combustible.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_4.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_aceite_combustible_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_aceite_combustible.TextChanged

    End Sub

    Private Sub txt_codigo_aceite_caja_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_aceite_caja.GotFocus
        color_foco()
    End Sub

    Private Sub txt_codigo_aceite_caja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_aceite_caja.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        txt_nombre_aceite_caja.Text = ""
        txt_nro_tecnico_5.Text = ""

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_aceite_de_caja()

            If txt_nombre_aceite_caja.Text = "" Then
                MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo_aceite_caja.Focus()
                Exit Sub
            End If

            txt_cantidad_5.Focus()
        End If
    End Sub

    Private Sub txt_codigo_aceite_caja_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_aceite_caja.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_6.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_aceite_caja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_aceite_caja.TextChanged

    End Sub

    Private Sub txt_codigo_aceite_diferencial_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_aceite_diferencial.GotFocus
        color_foco()
    End Sub

    Private Sub txt_codigo_aceite_diferencial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_aceite_diferencial.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        txt_nombre_aceite_diferencial.Text = ""
        txt_nro_tecnico_6.Text = ""
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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_aceite_diferencial()

            If txt_nombre_aceite_diferencial.Text = "" Then
                MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo_aceite_diferencial.Focus()
                Exit Sub
            End If

            txt_cantidad_6.Focus()
        End If
    End Sub

    Private Sub txt_codigo_aceite_diferencial_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_aceite_diferencial.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_6.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_aceite_diferencial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_aceite_diferencial.TextChanged

    End Sub

    Private Sub Form_ventas_lubricentro_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Form_venta.Visible = False Then
            Form_menu_principal.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub Form_ventas_lubricentro_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub ventas_lubricentro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_vendedor()
        mostrar_malla()
        Combo_vendedor.SelectedItem = "-"


        'grilla_estado_de_cuenta.Columns(0).Width = 200
        'grilla_estado_de_cuenta.Columns(1).Width = 200
        'grilla_estado_de_cuenta.Columns(3).Width = 200
        'grilla_estado_de_cuenta.Columns(5).Width = 200
        'grilla_estado_de_cuenta.Columns(7).Width = 200
        'grilla_estado_de_cuenta.Columns(9).Width = 200
        'grilla_estado_de_cuenta.Columns(11).Width = 200
        'grilla_estado_de_cuenta.Columns(13).Width = 200
        'grilla_estado_de_cuenta.Columns(15).Width = 200
        'grilla_estado_de_cuenta.Columns(17).Width = 200
        'grilla_estado_de_cuenta.Columns(27).Width = 200



        grilla_estado_de_cuenta.Columns(0).Width = 120
        grilla_estado_de_cuenta.Columns(1).Width = 120
        grilla_estado_de_cuenta.Columns(2).Width = 250
        grilla_estado_de_cuenta.Columns(35).Width = 473



        grilla_estado_de_cuenta.Columns(0).Visible = True
        grilla_estado_de_cuenta.Columns(1).Visible = True
        grilla_estado_de_cuenta.Columns(2).Visible = True
        grilla_estado_de_cuenta.Columns(3).Visible = False

        grilla_estado_de_cuenta.Columns(4).Visible = False
        grilla_estado_de_cuenta.Columns(5).Visible = False
        grilla_estado_de_cuenta.Columns(6).Visible = False
        grilla_estado_de_cuenta.Columns(7).Visible = False
        grilla_estado_de_cuenta.Columns(8).Visible = False
        grilla_estado_de_cuenta.Columns(9).Visible = False
        grilla_estado_de_cuenta.Columns(10).Visible = False
        grilla_estado_de_cuenta.Columns(11).Visible = False
        grilla_estado_de_cuenta.Columns(12).Visible = False
        grilla_estado_de_cuenta.Columns(13).Visible = False
        grilla_estado_de_cuenta.Columns(14).Visible = False
        grilla_estado_de_cuenta.Columns(15).Visible = False
        grilla_estado_de_cuenta.Columns(16).Visible = False
        grilla_estado_de_cuenta.Columns(17).Visible = False
        grilla_estado_de_cuenta.Columns(18).Visible = False
        grilla_estado_de_cuenta.Columns(19).Visible = False
        grilla_estado_de_cuenta.Columns(20).Visible = False
        grilla_estado_de_cuenta.Columns(21).Visible = False
        grilla_estado_de_cuenta.Columns(22).Visible = False
        grilla_estado_de_cuenta.Columns(23).Visible = False
        grilla_estado_de_cuenta.Columns(24).Visible = False
        grilla_estado_de_cuenta.Columns(25).Visible = False
        grilla_estado_de_cuenta.Columns(26).Visible = False
        grilla_estado_de_cuenta.Columns(27).Visible = False
        grilla_estado_de_cuenta.Columns(28).Visible = False
        grilla_estado_de_cuenta.Columns(29).Visible = False
        grilla_estado_de_cuenta.Columns(30).Visible = False
        grilla_estado_de_cuenta.Columns(30).Visible = False
        grilla_estado_de_cuenta.Columns(31).Visible = False
        grilla_estado_de_cuenta.Columns(32).Visible = False
        grilla_estado_de_cuenta.Columns(33).Visible = False
        grilla_estado_de_cuenta.Columns(34).Visible = False
        ' grilla_estado_de_cuenta.Columns(35).Visible = False
        'grilla_estado_de_cuenta.Columns(28).Width = 200

    End Sub

    Private Sub grilla_estado_de_cuenta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_estado_de_cuenta.CellContentClick



    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Private Sub grilla_estado_de_cuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_estado_de_cuenta.Click
        If grilla_estado_de_cuenta.Rows.Count = 0 Then
            Exit Sub
        End If

        limpiar()


        txt_cod_auto_servicio.Text = grilla_estado_de_cuenta.CurrentRow.Cells(0).Value()
        txt_codigo_patente.Text = grilla_estado_de_cuenta.CurrentRow.Cells(1).Value()
        txt_nombre.Text = grilla_estado_de_cuenta.CurrentRow.Cells(2).Value()
        txt_codigo_filtro_aceite.Text = grilla_estado_de_cuenta.CurrentRow.Cells(3).Value()
        txt_nombre_filtro_aceite.Text = grilla_estado_de_cuenta.CurrentRow.Cells(4).Value()
        txt_codigo_aceite_motor.Text = grilla_estado_de_cuenta.CurrentRow.Cells(5).Value()
        txt_nombre_aceite_motor.Text = grilla_estado_de_cuenta.CurrentRow.Cells(6).Value()
        txt_codigo_filtro_aire.Text = grilla_estado_de_cuenta.CurrentRow.Cells(7).Value()
        txt_nombre_filtro_aire.Text = grilla_estado_de_cuenta.CurrentRow.Cells(8).Value()
        txt_codigo_aceite_combustible.Text = grilla_estado_de_cuenta.CurrentRow.Cells(9).Value()
        txt_nombre_aceite_combustible.Text = grilla_estado_de_cuenta.CurrentRow.Cells(10).Value()
        txt_codigo_aceite_caja.Text = grilla_estado_de_cuenta.CurrentRow.Cells(11).Value()
        txt_nombre_aceite_caja.Text = grilla_estado_de_cuenta.CurrentRow.Cells(12).Value()
        txt_codigo_aceite_diferencial.Text = grilla_estado_de_cuenta.CurrentRow.Cells(13).Value()
        txt_nombre_aceite_diferencial.Text = grilla_estado_de_cuenta.CurrentRow.Cells(14).Value()
        txt_codigo_otros_1.Text = grilla_estado_de_cuenta.CurrentRow.Cells(15).Value()
        txt_nombre_otros_1.Text = grilla_estado_de_cuenta.CurrentRow.Cells(16).Value()
        txt_codigo_otros_2.Text = grilla_estado_de_cuenta.CurrentRow.Cells(17).Value()
        txt_nombre_otros_2.Text = grilla_estado_de_cuenta.CurrentRow.Cells(18).Value()

        txt_codigo_otros_3.Text = grilla_estado_de_cuenta.CurrentRow.Cells(19).Value()
        txt_nombre_otros_3.Text = grilla_estado_de_cuenta.CurrentRow.Cells(20).Value()
        txt_codigo_otros_4.Text = grilla_estado_de_cuenta.CurrentRow.Cells(21).Value()
        txt_nombre_otros_4.Text = grilla_estado_de_cuenta.CurrentRow.Cells(22).Value()

        txt_kilometraje.Text = grilla_estado_de_cuenta.CurrentRow.Cells(23).Value()
        txt_cantidad_1.Text = grilla_estado_de_cuenta.CurrentRow.Cells(24).Value()
        txt_cantidad_2.Text = grilla_estado_de_cuenta.CurrentRow.Cells(25).Value()
        txt_cantidad_3.Text = grilla_estado_de_cuenta.CurrentRow.Cells(26).Value()
        txt_cantidad_4.Text = grilla_estado_de_cuenta.CurrentRow.Cells(27).Value()
        txt_cantidad_5.Text = grilla_estado_de_cuenta.CurrentRow.Cells(28).Value()
        txt_cantidad_6.Text = grilla_estado_de_cuenta.CurrentRow.Cells(29).Value()
        txt_cantidad_7.Text = grilla_estado_de_cuenta.CurrentRow.Cells(30).Value()
        txt_cantidad_8.Text = grilla_estado_de_cuenta.CurrentRow.Cells(31).Value()
        txt_cantidad_9.Text = grilla_estado_de_cuenta.CurrentRow.Cells(32).Value()
        txt_cantidad_10.Text = grilla_estado_de_cuenta.CurrentRow.Cells(33).Value()
        txt_rut_vendedor.Text = grilla_estado_de_cuenta.CurrentRow.Cells(34).Value()




        If txt_codigo_filtro_aceite.Text <> "" Then
            mostrar_datos_filtro_de_aceite()
        End If

        If txt_codigo_aceite_motor.Text <> "" Then
            mostrar_datos_aceite_de_motor()
        End If

        If txt_codigo_filtro_aire.Text <> "" Then
            mostrar_datos_filtro_de_aire()
        End If

        If txt_codigo_aceite_combustible.Text <> "" Then
            mostrar_datos_aceite_de_combustible()
        End If

        If txt_codigo_aceite_caja.Text <> "" Then
            mostrar_datos_aceite_de_caja()
        End If

        If txt_codigo_aceite_diferencial.Text <> "" Then
            mostrar_datos_aceite_diferencial()
        End If

        If txt_codigo_otros_1.Text <> "" Then
            mostrar_datos_otros_1()
        End If

        If txt_codigo_otros_2.Text <> "" Then
            mostrar_datos_otros_2()
        End If

        If txt_codigo_otros_3.Text <> "" Then
            mostrar_datos_otros_3()
        End If

        If txt_codigo_otros_4.Text <> "" Then
            mostrar_datos_otros_4()
        End If















        mostrar_datos_vendedor_por_rut()

        txt_codigo_filtro_aceite.Focus()
    End Sub

    Private Sub grilla_estado_de_cuenta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_estado_de_cuenta.DoubleClick






        If grilla_estado_de_cuenta.Rows.Count = 0 Then
            Exit Sub
        End If


 









        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA ENVIAR ESTE SERVICIO A LA PANTALLA DE VENTAS?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        If valormensaje = vbYes Then

            If Form_venta.Visible = False Then
                ' MsgBox("ABRA LA PANTALLA DE VENTAS Y VUELVA A INTENTARLO", MessageBoxIcon.Error + MsgBoxStyle.OkOnly, "ATENCION")
                ' Exit Sub
                Form_venta.Show()
            End If

            Form_venta.grilla_detalle_venta.Rows.Clear()


            Form_venta.txt_cod_auto_servicio.Text = txt_cod_auto_servicio.Text


            If txt_nombre_filtro_aceite.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_filtro_aceite.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_1.Text
                Form_venta.venta()
            End If

            If txt_nombre_aceite_motor.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_aceite_motor.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_2.Text
                Form_venta.venta()
            End If

            If txt_nombre_filtro_aire.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_filtro_aire.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_3.Text
                Form_venta.venta()
            End If

            If txt_nombre_aceite_combustible.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_aceite_combustible.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_4.Text
                Form_venta.venta()
            End If

            If txt_nombre_aceite_caja.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_aceite_caja.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_5.Text
                Form_venta.venta()
            End If

            If txt_nombre_aceite_diferencial.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_aceite_diferencial.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_6.Text
                Form_venta.venta()
            End If

            If txt_nombre_otros_1.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_otros_1.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_7.Text
                Form_venta.venta()
            End If

            If txt_nombre_otros_2.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_otros_2.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_8.Text
                Form_venta.venta()
            End If


            If txt_nombre_otros_3.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_otros_3.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_9.Text
                Form_venta.venta()
            End If


            If txt_nombre_otros_4.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_otros_4.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_10.Text
                Form_venta.venta()
            End If



        End If





    End Sub

    Sub limpiar()

        txt_codigo_patente.Text = ""

        txt_nombre.Text = ""

        txt_cod_auto_servicio.Text = ""

        txt_codigo_filtro_aceite.Text = ""

        txt_nombre_filtro_aceite.Text = ""

        txt_codigo_aceite_motor.Text = ""
        txt_nombre_aceite_motor.Text = ""
        txt_codigo_filtro_aire.Text = ""
        txt_nombre_filtro_aire.Text = ""
        txt_codigo_aceite_combustible.Text = ""
        txt_nombre_aceite_combustible.Text = ""
        txt_codigo_aceite_caja.Text = ""
        txt_nombre_aceite_caja.Text = ""
        txt_codigo_aceite_diferencial.Text = ""
        txt_nombre_aceite_diferencial.Text = ""

        txt_codigo_otros_1.Text = ""
        txt_nombre_otros_1.Text = ""
        txt_codigo_otros_2.Text = ""
        txt_nombre_otros_2.Text = ""
        txt_codigo_otros_3.Text = ""
        txt_nombre_otros_3.Text = ""
        txt_codigo_otros_4.Text = ""
        txt_nombre_otros_4.Text = ""

        txt_kilometraje.Text = ""

        txt_cantidad_1.Text = ""
        txt_cantidad_2.Text = ""
        txt_cantidad_3.Text = ""
        txt_cantidad_4.Text = ""
        txt_cantidad_5.Text = ""
        txt_cantidad_6.Text = ""
        txt_cantidad_7.Text = ""
        txt_cantidad_8.Text = ""
        txt_cantidad_9.Text = ""
        txt_cantidad_10.Text = ""

        txt_nro_tecnico_1.Text = ""
        txt_nro_tecnico_2.Text = ""
        txt_nro_tecnico_3.Text = ""
        txt_nro_tecnico_4.Text = ""
        txt_nro_tecnico_5.Text = ""
        txt_nro_tecnico_6.Text = ""
        txt_nro_tecnico_7.Text = ""
        txt_nro_tecnico_8.Text = ""
        txt_nro_tecnico_9.Text = ""
        txt_nro_tecnico_10.Text = ""
 

        Combo_vendedor.SelectedItem = "-"
        txt_rut_vendedor.Text = ""
    End Sub



    Sub color_foco()


        Dim controlcito As Control
        Dim controlChild As Control


        For Each controlcito In Me.Controls
            If TypeOf controlcito Is TextBox Then
                If CType(controlcito, TextBox).ReadOnly = False Then
                    CType(controlcito, TextBox).BackColor = Color.White
                End If
            End If

            If TypeOf controlcito Is ComboBox Then
                CType(controlcito, ComboBox).BackColor = Color.White
            End If

            If TypeOf controlcito Is Button Then
                CType(controlcito, Button).BackColor = Color.Transparent
            End If

            If TypeOf controlcito Is GroupBox Then
                For Each controlChild In controlcito.Controls
                    If TypeOf controlChild Is TextBox Then
                        If CType(controlChild, TextBox).ReadOnly = False Then
                            CType(controlChild, TextBox).BackColor = Color.White
                        End If
                    End If

                    If TypeOf controlChild Is ComboBox Then
                        CType(controlChild, ComboBox).BackColor = Color.White
                    End If

                    If TypeOf controlChild Is Button Then
                        CType(controlChild, Button).BackColor = Color.Transparent
                    End If
                Next
            End If

            If TypeOf controlcito Is Panel Then
                For Each controlChild In controlcito.Controls
                    If TypeOf controlChild Is TextBox Then
                        If CType(controlChild, TextBox).ReadOnly = False Then
                            CType(controlChild, TextBox).BackColor = Color.White
                        End If
                    End If

                    If TypeOf controlChild Is ComboBox Then
                        CType(controlChild, ComboBox).BackColor = Color.White
                    End If

                    If TypeOf controlChild Is Button Then
                        CType(controlChild, Button).BackColor = Color.Transparent
                    End If
                Next
            End If

        Next











        For Each controlcito In Me.Controls
            If TypeOf controlcito Is TextBox Then
                If CType(controlcito, TextBox).Focused Then
                    If CType(controlcito, TextBox).ReadOnly = False Then
                        CType(controlcito, TextBox).BackColor = Color.LightSkyBlue
                        Exit Sub
                    End If
                End If
            End If

            If TypeOf controlcito Is ComboBox Then
                If CType(controlcito, ComboBox).Focused Then
                    CType(controlcito, ComboBox).BackColor = Color.LightSkyBlue
                    Exit Sub
                End If
            End If

            If TypeOf controlcito Is Button Then
                If CType(controlcito, Button).Focused Then
                    CType(controlcito, Button).BackColor = Color.LightSkyBlue
                    Exit Sub
                End If
            End If

            If TypeOf controlcito Is GroupBox Then
                For Each controlChild In controlcito.Controls
                    If TypeOf controlChild Is TextBox Then
                        If CType(controlChild, TextBox).Focused Then
                            If CType(controlChild, TextBox).ReadOnly = False Then
                                CType(controlChild, TextBox).BackColor = Color.LightSkyBlue
                                Exit Sub
                            End If
                        End If
                    End If

                    If TypeOf controlChild Is ComboBox Then
                        If CType(controlChild, ComboBox).Focused Then
                            CType(controlChild, ComboBox).BackColor = Color.LightSkyBlue
                            Exit Sub
                        End If
                    End If

                    If TypeOf controlChild Is Button Then
                        If CType(controlChild, Button).Focused Then
                            CType(controlChild, Button).BackColor = Color.LightSkyBlue
                            Exit Sub
                        End If
                    End If
                Next
            End If


            If TypeOf controlcito Is Panel Then
                For Each controlChild In controlcito.Controls
                    If TypeOf controlChild Is TextBox Then
                        If CType(controlChild, TextBox).Focused Then
                            If CType(controlChild, TextBox).ReadOnly = False Then
                                CType(controlChild, TextBox).BackColor = Color.LightSkyBlue
                                Exit Sub
                            End If
                        End If
                    End If

                    If TypeOf controlChild Is ComboBox Then
                        If CType(controlChild, ComboBox).Focused Then
                            CType(controlChild, ComboBox).BackColor = Color.LightSkyBlue
                            Exit Sub
                        End If
                    End If

                    If TypeOf controlChild Is Button Then
                        If CType(controlChild, Button).Focused Then
                            CType(controlChild, Button).BackColor = Color.LightSkyBlue
                            Exit Sub
                        End If
                    End If
                Next
            End If

        Next
    End Sub

    Private Sub txt_nombre_aceite_motor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_aceite_motor.GotFocus

    End Sub

    Private Sub txt_nombre_aceite_motor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_aceite_motor.TextChanged

    End Sub

    Private Sub txt_nombre_filtro_aceite_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_filtro_aceite.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_filtro_aceite_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_filtro_aceite.TextChanged

    End Sub

    Private Sub btn_buscar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_1.Click
        buscar_ventas_lubricentro = "FILTRO DE ACEITE"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_buscar_productos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_1.GotFocus
        color_foco()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_2.Click
        buscar_ventas_lubricentro = "ACEITE DE MOTOR"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_2.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_aceite_combustible_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_aceite_combustible.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_aceite_combustible_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_aceite_combustible.TextChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_4.Click
        buscar_ventas_lubricentro = "ACEITE DE COMBUSTIBLE"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_4.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_filtro_aire_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_filtro_aire.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_filtro_aire_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_filtro_aire.TextChanged

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_3.Click
        buscar_ventas_lubricentro = "FILTRO DE AIRE"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_3.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_aceite_caja_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_aceite_caja.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_aceite_caja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_aceite_caja.TextChanged

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_5.Click
        buscar_ventas_lubricentro = "ACEITE DE CAJA"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button7_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_5.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_aceite_diferencial_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_aceite_diferencial.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_aceite_diferencial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_aceite_diferencial.TextChanged

    End Sub

    Private Sub btn_agregar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_agregar.GotFocus
        color_foco()
    End Sub

    Private Sub btn_quitar_elemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.Click
        If grilla_estado_de_cuenta.Rows.Count <> 0 Then
            Dim valormensaje As Integer
            valormensaje = MsgBox("¿DESEA QUTAR EL SERVICIO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
            If valormensaje = vbYes Then
           
                SC.Connection = conexion
                SC.CommandText = "DELETE FROM servicios_lubricentro WHERE cod_auto='" & (txt_cod_auto_servicio.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)

                mostrar_malla()

                txt_codigo_patente.Focus()

            End If
        End If
    End Sub

    Private Sub btn_quitar_elemento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_elemento.GotFocus
        color_foco()
    End Sub





    Sub mostrar_datos_filtro_de_aceite()
        If txt_codigo_filtro_aceite.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_filtro_aceite.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_filtro_aceite.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_nro_tecnico_1.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
            End If
            conexion.Close()
        End If
    End Sub

    Sub mostrar_datos_aceite_de_motor()
        If txt_codigo_aceite_motor.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_aceite_motor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_aceite_motor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_nro_tecnico_2.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
            End If
            conexion.Close()
        End If
    End Sub

    Sub mostrar_datos_filtro_de_aire()
        If txt_codigo_filtro_aire.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_filtro_aire.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_filtro_aire.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_nro_tecnico_3.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
            End If
            conexion.Close()
        End If
    End Sub



    Sub mostrar_datos_aceite_de_combustible()
        If txt_codigo_aceite_combustible.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_aceite_combustible.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_aceite_combustible.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_nro_tecnico_4.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
            End If
            conexion.Close()
        End If
    End Sub

    Sub mostrar_datos_aceite_de_caja()
        If txt_codigo_aceite_caja.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_aceite_caja.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_aceite_caja.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_nro_tecnico_5.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
            End If
            conexion.Close()
        End If
    End Sub


    Sub mostrar_datos_aceite_diferencial()
        If txt_codigo_aceite_diferencial.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_aceite_diferencial.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_aceite_diferencial.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_nro_tecnico_6.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
            End If
            conexion.Close()
        End If
    End Sub

    Sub mostrar_datos_otros_1()
        If txt_codigo_otros_1.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_otros_1.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_otros_1.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_nro_tecnico_7.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
            End If
            conexion.Close()
        End If
    End Sub

    Sub mostrar_datos_otros_2()
        If txt_codigo_otros_2.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_otros_2.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_otros_2.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_nro_tecnico_8.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
            End If
            conexion.Close()
        End If
    End Sub






    Sub mostrar_datos_otros_3()
        If txt_codigo_otros_3.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_otros_3.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_otros_3.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_nro_tecnico_9.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
            End If
            conexion.Close()
        End If
    End Sub


    Sub mostrar_datos_otros_4()
        If txt_codigo_otros_4.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_otros_4.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_nombre_otros_4.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                txt_nro_tecnico_10.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
            End If
            conexion.Close()
        End If
    End Sub

    Private Sub btn_buscar_productos_6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_6.Click
        buscar_ventas_lubricentro = "ACEITE DIFERENCIAL"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub txt_codigo_otros_1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_otros_1.GotFocus
        color_foco()
    End Sub

    Private Sub txt_codigo_otros_1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_otros_1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        txt_nombre_otros_1.Text = ""
        txt_nro_tecnico_7.Text = ""

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_otros_1()

            If txt_nombre_otros_1.Text = "" Then
                MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo_otros_1.Focus()
                Exit Sub
            End If

            txt_cantidad_7.Focus()
        End If
    End Sub

    Private Sub txt_codigo_otros_1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_otros_1.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_7.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_otros_1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_otros_1.TextChanged

    End Sub

    Private Sub txt_codigo_otros_2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_otros_2.GotFocus
        color_foco()
    End Sub

    Private Sub txt_codigo_otros_2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_otros_2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        txt_nombre_otros_2.Text = ""
        txt_nro_tecnico_8.Text = ""

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_otros_2()

            If txt_nombre_otros_2.Text = "" Then
                MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo_otros_2.Focus()
                Exit Sub
            End If

            txt_cantidad_8.Focus()
        End If
    End Sub

    Private Sub txt_codigo_otros_2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_otros_2.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_8.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_otros_2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_otros_2.TextChanged

    End Sub

    Private Sub txt_codigo_patente_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_patente.GotFocus
        color_foco()
    End Sub

    Private Sub txt_codigo_patente_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_patente.KeyPress

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            If txt_codigo_patente.Text = "" Then
                MsgBox("CAMPO PATENTE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo_otros_2.Focus()
                Exit Sub
            End If

            txt_nombre.Focus()
        End If
    End Sub

    Private Sub txt_codigo_patente_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_patente.TextChanged

    End Sub

    Private Sub txt_nombre_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre.KeyPress
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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            If txt_nombre.Text = "" Then
                MsgBox("CAMPO MODELO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_nombre.Focus()
                Exit Sub
            End If

            txt_kilometraje.Focus()
        End If
    End Sub

    Private Sub txt_nombre_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre.TextChanged

    End Sub

    Private Sub btn_buscar_productos_7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_7.Click
        buscar_ventas_lubricentro = "OTROS 1"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_buscar_productos_8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_8.Click
        buscar_ventas_lubricentro = "OTROS 2"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub txt_nombre_otros_1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_otros_1.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_otros_1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_otros_1.TextChanged

    End Sub

    Private Sub btn_buscar_productos_7_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_7.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_otros_2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_otros_2.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_otros_2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_otros_2.TextChanged

    End Sub

    Private Sub btn_buscar_productos_8_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_8.GotFocus
        color_foco()
    End Sub

    Private Sub txt_kilometraje_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_kilometraje.GotFocus
        color_foco()
    End Sub

    Private Sub txt_kilometraje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_kilometraje.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        e.KeyChar = e.KeyChar.ToString.ToUpper
        '  txt_nombre_aceite_diferencial.Text = ""
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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            If txt_nombre.Text = "" Then
                MsgBox("CAMPO MODELO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_nombre.Focus()
                Exit Sub
            End If

            btn_agregar.Focus()
        End If
    End Sub

    Private Sub txt_kilometraje_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_kilometraje.TextChanged

    End Sub

    Private Sub txt_cantidad_1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_1.GotFocus
        color_foco()
    End Sub

    Private Sub txt_cantidad_1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        ' txt_nombre_filtro_aceite.Text = ""

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            If txt_cantidad_1.Text = "" Then
                txt_cantidad_1.Text = "1"
            End If

            txt_codigo_aceite_motor.Focus()
        End If
    End Sub


    Private Sub txt_cantidad_1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_1.TextChanged

    End Sub

    Private Sub txt_cantidad_2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_2.GotFocus
        color_foco()
    End Sub

    Private Sub txt_cantidad_2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        '  txt_nombre_filtro_aceite.Text = ""

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            If txt_cantidad_2.Text = "" Then
                txt_cantidad_2.Text = "1"
            End If

            txt_codigo_filtro_aire.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_2.TextChanged

    End Sub

    Private Sub txt_cantidad_3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_3.GotFocus
        color_foco()
    End Sub

    Private Sub txt_cantidad_3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_3.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        '  txt_nombre_filtro_aceite.Text = ""

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            If txt_cantidad_3.Text = "" Then
                txt_cantidad_3.Text = "1"
            End If

            txt_codigo_aceite_combustible.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_3.TextChanged

    End Sub

    Private Sub txt_cantidad_4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_4.GotFocus
        color_foco()
    End Sub

    Private Sub txt_cantidad_4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_4.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        'txt_nombre_filtro_aceite.Text = ""

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            If txt_cantidad_4.Text = "" Then
                txt_cantidad_4.Text = "1"
            End If

            txt_codigo_aceite_caja.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_4.TextChanged

    End Sub

    Private Sub txt_cantidad_5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_5.GotFocus
        color_foco()
    End Sub

    Private Sub txt_cantidad_5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_5.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        'txt_nombre_filtro_aceite.Text = ""

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            If txt_cantidad_5.Text = "" Then
                txt_cantidad_5.Text = "1"
            End If

            txt_codigo_aceite_diferencial.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_5.TextChanged

    End Sub

    Private Sub txt_cantidad_6_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_6.GotFocus
        color_foco()
    End Sub

    Private Sub txt_cantidad_6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_6.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        'txt_nombre_filtro_aceite.Text = ""

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            If txt_cantidad_6.Text = "" Then
                txt_cantidad_6.Text = "1"
            End If

            txt_codigo_otros_1.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_6.TextChanged

    End Sub

    Private Sub txt_cantidad_7_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_7.GotFocus
        color_foco()
    End Sub

    Private Sub txt_cantidad_7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_7.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        ' txt_nombre_filtro_aceite.Text = ""

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            If txt_cantidad_7.Text = "" Then
                txt_cantidad_7.Text = "1"
            End If

            txt_codigo_otros_2.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_7.TextChanged

    End Sub

    Private Sub txt_cantidad_8_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_8.GotFocus
        color_foco()
    End Sub

    Private Sub txt_cantidad_8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_8.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        '  txt_nombre_filtro_aceite.Text = ""

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            If txt_cantidad_8.Text = "" Then
                txt_cantidad_8.Text = "1"
            End If

            txt_codigo_otros_3.Focus()
        End If
    End Sub
    Sub llenar_combo_vendedor()
        Combo_vendedor.Items.Clear()
        Combo_vendedor.Items.Add("-")
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from usuarios WHERE AREA_USUARIO='MECANICO' order by nombre_usuario"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                Combo_vendedor.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_usuario"))
            Next
        End If
        conexion.Close()
    End Sub

    Sub mostrar_datos_vendedor()
        conexion.Close()
        If Combo_vendedor.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from usuarios where nombre_usuario ='" & (Combo_vendedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
            End If

            conexion.Close()
        End If
    End Sub

    Sub mostrar_datos_vendedor_por_rut()
        conexion.Close()
        If txt_rut_vendedor.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from usuarios where rut_usuario ='" & (txt_rut_vendedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Combo_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")
            End If

            conexion.Close()
        End If
    End Sub

    Private Sub txt_cantidad_8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_8.TextChanged

    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        color_foco()
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        color_foco()
    End Sub

    Private Sub Combo_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_vendedor.SelectedIndexChanged
        mostrar_datos_vendedor()
    End Sub

    Private Sub GroupBox8_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox8.Enter

    End Sub

    Private Sub txt_codigo_otros_3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_otros_3.GotFocus
        color_foco()
    End Sub

    Private Sub txt_codigo_otros_3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_otros_3.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        txt_nombre_otros_3.Text = ""
        txt_nro_tecnico_9.Text = ""

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_otros_3()

            If txt_nombre_otros_3.Text = "" Then
                MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo_otros_3.Focus()
                Exit Sub
            End If

            txt_cantidad_9.Focus()
        End If
    End Sub

    Private Sub txt_codigo_otros_3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_otros_3.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_9.PerformClick()
        End If
    End Sub

 

    Private Sub txt_codigo_otros_3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_otros_3.TextChanged

    End Sub

    Private Sub txt_codigo_otros_4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_otros_4.GotFocus
        color_foco()
    End Sub

    Private Sub txt_codigo_otros_4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_otros_4.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        txt_nombre_otros_4.Text = ""
        txt_nro_tecnico_10.Text = ""

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_otros_4()

            If txt_nombre_otros_4.Text = "" Then
                MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                txt_codigo_otros_4.Focus()
                Exit Sub
            End If

            txt_cantidad_10.Focus()
        End If
    End Sub

    Private Sub txt_codigo_otros_4_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_otros_4.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_10.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_otros_4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_otros_4.TextChanged

    End Sub

    Private Sub txt_cantidad_9_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_9.GotFocus
        color_foco()
    End Sub

    Private Sub txt_cantidad_9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_9.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        ' txt_nombre_filtro_aceite.Text = ""

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            If txt_cantidad_9.Text = "" Then
                txt_cantidad_9.Text = "1"
            End If

            txt_codigo_otros_4.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_9_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cantidad_9.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_10.PerformClick()
        End If
    End Sub

    Private Sub txt_cantidad_9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_9.TextChanged

    End Sub

    Private Sub txt_cantidad_10_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cantidad_10.GotFocus
        color_foco()
    End Sub

    Private Sub txt_cantidad_10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_10.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        e.KeyChar = e.KeyChar.ToString.ToUpper
        ' txt_nombre_filtro_aceite.Text = ""

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

        If e.KeyChar = ";" Then
            e.KeyChar = ""
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then

            If txt_cantidad_10.Text = "" Then
                txt_cantidad_10.Text = "1"
            End If

            txt_codigo_patente.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad_10.TextChanged

    End Sub

    Private Sub btn_buscar_productos_9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_9.Click
        buscar_ventas_lubricentro = "OTROS 3"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_buscar_productos_10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_10.Click
        buscar_ventas_lubricentro = "OTROS 4"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub txt_nombre_otros_3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_otros_3.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_otros_3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_otros_3.TextChanged

    End Sub

    Private Sub btn_buscar_productos_9_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_9.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_otros_4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_otros_4.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_otros_4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_otros_4.TextChanged

    End Sub

    Private Sub btn_buscar_productos_10_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_10.GotFocus
        color_foco()
    End Sub

    Private Sub btn_nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nueva.Click
     
        limpiar()

        Form_nuevo_servicio_lubricentro.Show()

        Me.Enabled = False
      
    End Sub

    Private Sub btn_nueva_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nueva.GotFocus
        color_foco()
    End Sub

    Private Sub btn_comentario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_comentario.Click

        If txt_cod_auto_servicio.Text = "" Then
            Exit Sub
        End If

        Form_comentario_ventas_lubricentro.Show()
        Me.Enabled = False


    End Sub

    Private Sub btn_comentario_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_comentario.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nro_tecnico_1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_nro_tecnico_1.KeyUp

    End Sub

    Private Sub txt_nro_tecnico_1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_tecnico_1.TextChanged

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub btn_mostrar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        Me.Enabled = False

        mostrar_malla()

        Me.Enabled = True

    End Sub

    Private Sub btn_mostrar_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        color_foco()
    End Sub
End Class