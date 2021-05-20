Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.IO
Imports System.Math

Public Class Form_ventas_lubricentro
    Private Sub Form_ventas_lubricentro_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Form_venta.Visible = False Then
            Form_menu_principal.WindowState = FormWindowState.Normal
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
            mostrar_cierre_sistema()
            Form_menu_principal.Close()
        End If
    End Sub

    Private Sub ventas_lubricentro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_vendedor()
        mostrar_malla()
        Combo_vendedor.SelectedItem = "-"

        grilla_estado_de_cuenta.Columns(0).Width = 60
        grilla_estado_de_cuenta.Columns(0).Visible = False

        grilla_estado_de_cuenta.Columns(1).Width = 80
        grilla_estado_de_cuenta.Columns(2).Width = 250
        grilla_estado_de_cuenta.Columns(3).Width = 80
        grilla_estado_de_cuenta.Columns(4).Width = 60
        grilla_estado_de_cuenta.Columns(4).Visible = False

        grilla_estado_de_cuenta.Columns(5).Width = 300
        grilla_estado_de_cuenta.Columns(6).Width = 80
        grilla_estado_de_cuenta.Columns(7).Width = 140
        grilla_estado_de_cuenta.Columns(8).Width = 80
        grilla_estado_de_cuenta.Columns(9).Width = 80
        grilla_estado_de_cuenta.Columns(10).Width = 140
        grilla_estado_de_cuenta.Columns(11).Width = 80
        grilla_estado_de_cuenta.Columns(12).Width = 80
        grilla_estado_de_cuenta.Columns(13).Width = 140
        grilla_estado_de_cuenta.Columns(14).Width = 80
        grilla_estado_de_cuenta.Columns(15).Width = 80
        grilla_estado_de_cuenta.Columns(16).Width = 140
        grilla_estado_de_cuenta.Columns(17).Width = 80
        grilla_estado_de_cuenta.Columns(18).Width = 80
        grilla_estado_de_cuenta.Columns(19).Width = 140
        grilla_estado_de_cuenta.Columns(20).Width = 80
        grilla_estado_de_cuenta.Columns(21).Width = 80
        grilla_estado_de_cuenta.Columns(22).Width = 140
        grilla_estado_de_cuenta.Columns(23).Width = 80
        grilla_estado_de_cuenta.Columns(24).Width = 80
        grilla_estado_de_cuenta.Columns(25).Width = 140
        grilla_estado_de_cuenta.Columns(26).Width = 80
        grilla_estado_de_cuenta.Columns(27).Width = 80
        grilla_estado_de_cuenta.Columns(28).Width = 140
        grilla_estado_de_cuenta.Columns(29).Width = 80
        grilla_estado_de_cuenta.Columns(30).Width = 80
        grilla_estado_de_cuenta.Columns(31).Width = 140
        grilla_estado_de_cuenta.Columns(32).Width = 80
        grilla_estado_de_cuenta.Columns(33).Width = 80
        grilla_estado_de_cuenta.Columns(34).Width = 140
        grilla_estado_de_cuenta.Columns(35).Width = 80
        grilla_estado_de_cuenta.Columns(36).Width = 80
        grilla_estado_de_cuenta.Columns(37).Width = 140
        grilla_estado_de_cuenta.Columns(38).Width = 80
        grilla_estado_de_cuenta.Columns(39).Width = 80
        grilla_estado_de_cuenta.Columns(40).Width = 140
        grilla_estado_de_cuenta.Columns(41).Width = 80
        grilla_estado_de_cuenta.Columns(42).Width = 80
        grilla_estado_de_cuenta.Columns(43).Width = 140
        grilla_estado_de_cuenta.Columns(44).Width = 80
        grilla_estado_de_cuenta.Columns(45).Width = 80
        grilla_estado_de_cuenta.Columns(46).Width = 140
        grilla_estado_de_cuenta.Columns(47).Width = 80
        grilla_estado_de_cuenta.Columns(48).Width = 80
        grilla_estado_de_cuenta.Columns(49).Width = 140
        grilla_estado_de_cuenta.Columns(50).Width = 80
        grilla_estado_de_cuenta.ColumnHeadersHeight = 80
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

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
            'SC.CommandText = "UPDATE servicios_lubricentro SET patente='" & (txt_codigo_patente.Text) & "', modelo='" & (txt_nombre.Text) & "', codigo_1='" & (txt_codigo_6.Text) & "', filtro_de_aceite='" & (txt_nombre_6.Text) & "', codigo_2='" & (txt_codigo_1.Text) & "', aceite_de_motor='" & (txt_nombre_1.Text) & "', codigo_3='" & (txt_codigo_7.Text) & "', filtro_de_aire='" & (txt_nombre_7.Text) & "', codigo_4='" & (txt_codigo_8.Text) & "', filtro_de_combustible='" & (txt_nombre_8.Text) & "', codigo_5='" & (txt_codigo_4.Text) & "', aceite_de_caja='" & (txt_nombre_4.Text) & "', codigo_6='" & (txt_codigo_3.Text) & "', aceite_diferencial='" & (txt_nombre_3.Text) & "', codigo_7='" & (txt_codigo_9.Text) & "', otros_1='" & (txt_nombre_9.Text) & "', codigo_8='" & (txt_codigo_2.Text) & "', otros_2='" & (txt_nombre_2.Text) & "', codigo_9='" & (txt_codigo_5.Text) & "', otros_3='" & (txt_nombre_5.Text) & "', codigo_10='" & (txt_codigo_10.Text) & "', otros_4='" & (txt_nombre_10.Text) & "',kilometraje='" & (txt_kilometraje.Text) & "', cantidad_1='" & (txt_cantidad_1.Text) & "', cantidad_2='" & (txt_cantidad_2.Text) & "', cantidad_3='" & (txt_cantidad_3.Text) & "', cantidad_4='" & (txt_cantidad_4.Text) & "', cantidad_5='" & (txt_cantidad_5.Text) & "', cantidad_6='" & (txt_cantidad_6.Text) & "', cantidad_7='" & (txt_cantidad_7.Text) & "',cantidad_8='" & (txt_cantidad_8.Text) & "', cantidad_9='" & (txt_cantidad_8.Text) & "',cantidad_10='" & (txt_cantidad_10.Text) & "', rut_mecanico='" & (txt_rut_vendedor.Text) & "', usuario_responsable='" & (miusuario) & "', fecha='" & (Form_menu_principal.dtp_fecha.Text) & "', estado='PENDIENTE', tipo_documento='', nro_documento='', hora='" & (Form_menu_principal.lbl_hora.Text) & "' WHERE cod_auto='" & (txt_cod_auto_servicio.Text) & "'"
            SC.CommandText = "UPDATE servicios_lubricentro SET patente='" & (txt_codigo_patente.Text) & "', kilometraje='" & (txt_kilometraje.Text) & "', modelo='" & (txt_nombre.Text) & "', codigo_1='" & (txt_codigo_1.Text) & "', codigo_2='" & (txt_codigo_2.Text) & "', codigo_3='" & (txt_codigo_3.Text) & "', codigo_4='" & (txt_codigo_4.Text) & "', codigo_5='" & (txt_codigo_5.Text) & "', codigo_6='" & (txt_codigo_6.Text) & "', codigo_7='" & (txt_codigo_7.Text) & "', codigo_8='" & (txt_codigo_8.Text) & "', codigo_9='" & (txt_codigo_9.Text) & "', codigo_10='" & (txt_codigo_10.Text) & "', codigo_11='" & (txt_codigo_11.Text) & "', codigo_12='" & (txt_codigo_12.Text) & "', codigo_13='" & (txt_codigo_13.Text) & "', codigo_14='" & (txt_codigo_14.Text) & "', codigo_15='" & (txt_codigo_15.Text) & "', nombre_1='" & (txt_nombre_1.Text) & "', nombre_2='" & (txt_nombre_2.Text) & "', nombre_3='" & (txt_nombre_3.Text) & "', nombre_4='" & (txt_nombre_4.Text) & "', nombre_4='" & (txt_nombre_4.Text) & "', nombre_5='" & (txt_nombre_5.Text) & "', nombre_6='" & (txt_nombre_6.Text) & "', nombre_7='" & (txt_nombre_7.Text) & "', nombre_8='" & (txt_nombre_8.Text) & "', nombre_9='" & (txt_nombre_9.Text) & "', nombre_10='" & (txt_nombre_10.Text) & "', nombre_11='" & (txt_nombre_11.Text) & "', nombre_12='" & (txt_nombre_12.Text) & "', nombre_13='" & (txt_nombre_13.Text) & "', nombre_14='" & (txt_nombre_14.Text) & "', nombre_15='" & (txt_nombre_15.Text) & "', cantidad_1='" & (txt_cantidad_1.Text) & "', cantidad_2='" & (txt_cantidad_2.Text) & "', cantidad_3='" & (txt_cantidad_3.Text) & "', cantidad_4='" & (txt_cantidad_4.Text) & "', cantidad_5='" & (txt_cantidad_5.Text) & "', cantidad_6='" & (txt_cantidad_6.Text) & "', cantidad_7='" & (txt_cantidad_7.Text) & "',cantidad_8='" & (txt_cantidad_8.Text) & "', cantidad_9='" & (txt_cantidad_8.Text) & "',cantidad_9='" & (txt_cantidad_9.Text) & "', cantidad_10='" & (txt_cantidad_10.Text) & "', cantidad_11='" & (txt_cantidad_11.Text) & "', cantidad_12='" & (txt_cantidad_12.Text) & "', cantidad_13='" & (txt_cantidad_13.Text) & "', cantidad_14='" & (txt_cantidad_14.Text) & "', cantidad_15='" & (txt_cantidad_15.Text) & "', rut_mecanico='" & (txt_rut_vendedor.Text) & "', usuario_responsable='" & (miusuario) & "', fecha='" & (Form_menu_principal.dtp_fecha.Text) & "', estado='PENDIENTE', tipo_documento='', nro_documento='', hora='" & (Form_menu_principal.lbl_hora.Text) & "' WHERE cod_auto='" & (txt_cod_auto_servicio.Text) & "'"


            DA.SelectCommand = SC
            DA.Fill(DT)

        Else

            SC.Connection = conexion
            SC.CommandText = "insert into servicios_lubricentro (patente, modelo, kilometraje, codigo_1, codigo_2, codigo_3, codigo_4, codigo_5, codigo_6, codigo_7, codigo_8, codigo_9, codigo_10, codigo_11, codigo_12, codigo_13, codigo_14, codigo_15, nombre_1, nombre_2, nombre_3,  nombre_4, nombre_5, nombre_6, nombre_7, nombre_8, nombre_9, nombre_10, nombre_11, nombre_12, nombre_13, nombre_14, nombre_15, cantidad_1, cantidad_2, cantidad_3, cantidad_4, cantidad_5, cantidad_6, cantidad_7,cantidad_8, cantidad_9, cantidad_10, cantidad_11, cantidad_12, cantidad_13, cantidad_14, cantidad_15, rut_mecanico, usuario_responsable, fecha, estado, tipo_documento, nro_documento, hora) values('" & (txt_codigo_patente.Text) & "', '" & (txt_nombre.Text) & "', '" & (txt_kilometraje.Text) & "', '" & (txt_codigo_1.Text) & "', '" & (txt_codigo_2.Text) & "', '" & (txt_codigo_3.Text) & "', '" & (txt_codigo_4.Text) & "', '" & (txt_codigo_5.Text) & "', '" & (txt_codigo_6.Text) & "', '" & (txt_codigo_7.Text) & "', '" & (txt_codigo_8.Text) & "', '" & (txt_codigo_9.Text) & "', '" & (txt_codigo_10.Text) & "', '" & (txt_codigo_11.Text) & "', '" & (txt_codigo_12.Text) & "', '" & (txt_codigo_13.Text) & "', '" & (txt_codigo_14.Text) & "', '" & (txt_codigo_15.Text) & "', '" & (txt_nombre_1.Text) & "', '" & (txt_nombre_2.Text) & "', '" & (txt_nombre_3.Text) & "', '" & (txt_nombre_4.Text) & "', '" & (txt_nombre_5.Text) & "', '" & (txt_nombre_6.Text) & "', '" & (txt_nombre_7.Text) & "', '" & (txt_nombre_8.Text) & "', '" & (txt_nombre_9.Text) & "', '" & (txt_nombre_10.Text) & "', '" & (txt_nombre_11.Text) & "', '" & (txt_nombre_12.Text) & "', '" & (txt_nombre_13.Text) & "', '" & (txt_nombre_14.Text) & "', '" & (txt_nombre_15.Text) & "', '" & (txt_cantidad_1.Text) & "', '" & (txt_cantidad_2.Text) & "', '" & (txt_cantidad_3.Text) & "', '" & (txt_cantidad_4.Text) & "', '" & (txt_cantidad_5.Text) & "', '" & (txt_cantidad_6.Text) & "', '" & (txt_cantidad_7.Text) & "', '" & (txt_cantidad_8.Text) & "', '" & (txt_cantidad_9.Text) & "','" & (txt_cantidad_10.Text) & "', '" & (txt_cantidad_11.Text) & "', '" & (txt_cantidad_12.Text) & "', '" & (txt_cantidad_13.Text) & "', '" & (txt_cantidad_14.Text) & "', '" & (txt_cantidad_15.Text) & "', '" & (txt_rut_vendedor.Text) & "', '" & (miusuario) & "', '" & (Form_menu_principal.dtp_fecha.Text) & "', 'PENDIENTE', '', '', '" & (Form_menu_principal.lbl_hora.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

        End If

        mostrar_malla()

        limpiar()
        txt_codigo_6.Focus()

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
                grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_auto"),
                                                  DS.Tables(DT.TableName).Rows(i).Item("patente"),
                                                   DS.Tables(DT.TableName).Rows(i).Item("modelo"),
                                                    DS.Tables(DT.TableName).Rows(i).Item("kilometraje"),
                                                     DS.Tables(DT.TableName).Rows(i).Item("rut_mecanico"),
                                                      DS.Tables(DT.TableName).Rows(i).Item("comentario"),
                                                       DS.Tables(DT.TableName).Rows(i).Item("codigo_1"),
                                                        DS.Tables(DT.TableName).Rows(i).Item("nombre_1"),
                                                         DS.Tables(DT.TableName).Rows(i).Item("cantidad_1"),
                                                          DS.Tables(DT.TableName).Rows(i).Item("codigo_2"),
                                                           DS.Tables(DT.TableName).Rows(i).Item("nombre_2"),
                                                            DS.Tables(DT.TableName).Rows(i).Item("cantidad_2"),
                                                             DS.Tables(DT.TableName).Rows(i).Item("codigo_3"),
                                                              DS.Tables(DT.TableName).Rows(i).Item("nombre_3"),
                                                               DS.Tables(DT.TableName).Rows(i).Item("cantidad_3"),
                                                                DS.Tables(DT.TableName).Rows(i).Item("codigo_4"),
                                                                 DS.Tables(DT.TableName).Rows(i).Item("nombre_4"),
                                                                  DS.Tables(DT.TableName).Rows(i).Item("cantidad_4"),
                                                                   DS.Tables(DT.TableName).Rows(i).Item("codigo_5"),
                                                                    DS.Tables(DT.TableName).Rows(i).Item("nombre_5"),
                                                                     DS.Tables(DT.TableName).Rows(i).Item("cantidad_5"),
                                                                      DS.Tables(DT.TableName).Rows(i).Item("codigo_6"),
                                                                       DS.Tables(DT.TableName).Rows(i).Item("nombre_6"),
                                                                        DS.Tables(DT.TableName).Rows(i).Item("cantidad_6"),
                                                                         DS.Tables(DT.TableName).Rows(i).Item("codigo_7"),
                                                                          DS.Tables(DT.TableName).Rows(i).Item("nombre_7"),
                                                                           DS.Tables(DT.TableName).Rows(i).Item("cantidad_7"),
                                                                            DS.Tables(DT.TableName).Rows(i).Item("codigo_8"),
                                                                             DS.Tables(DT.TableName).Rows(i).Item("nombre_8"),
                                                                              DS.Tables(DT.TableName).Rows(i).Item("cantidad_8"),
                                                                               DS.Tables(DT.TableName).Rows(i).Item("codigo_9"),
                                                                                DS.Tables(DT.TableName).Rows(i).Item("nombre_9"),
                                                                                 DS.Tables(DT.TableName).Rows(i).Item("cantidad_9"),
                                                                                  DS.Tables(DT.TableName).Rows(i).Item("codigo_10"),
                                                                                   DS.Tables(DT.TableName).Rows(i).Item("nombre_10"),
                                                                                    DS.Tables(DT.TableName).Rows(i).Item("cantidad_10"),
                                                                                     DS.Tables(DT.TableName).Rows(i).Item("codigo_11"),
                                                                                      DS.Tables(DT.TableName).Rows(i).Item("nombre_11"),
                                                                                       DS.Tables(DT.TableName).Rows(i).Item("cantidad_11"),
                                                                                        DS.Tables(DT.TableName).Rows(i).Item("codigo_12"),
                                                                                         DS.Tables(DT.TableName).Rows(i).Item("nombre_12"),
                                                                                          DS.Tables(DT.TableName).Rows(i).Item("cantidad_12"),
                                                                                           DS.Tables(DT.TableName).Rows(i).Item("codigo_13"),
                                                                                            DS.Tables(DT.TableName).Rows(i).Item("nombre_13"),
                                                                                             DS.Tables(DT.TableName).Rows(i).Item("cantidad_13"),
                                                                                              DS.Tables(DT.TableName).Rows(i).Item("codigo_14"),
                                                                                               DS.Tables(DT.TableName).Rows(i).Item("nombre_14"),
                                                                                                DS.Tables(DT.TableName).Rows(i).Item("cantidad_14"),
                                                                                                 DS.Tables(DT.TableName).Rows(i).Item("codigo_15"),
                                                                                                  DS.Tables(DT.TableName).Rows(i).Item("nombre_15"),
                                                                                                   DS.Tables(DT.TableName).Rows(i).Item("cantidad_15"),
                                                                                                    DS.Tables(DT.TableName).Rows(i).Item("fecha"),
                                                                                                     DS.Tables(DT.TableName).Rows(i).Item("hora"))

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

    Private Sub txt_codigo_filtro_aceite_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_6.GotFocus
        buscar_ventas_lubricentro = "6"
    End Sub

    Private Sub txt_codigo_filtro_aceite_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_6.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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

        limpiar_producto()

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_productos()
        End If
    End Sub

    Private Sub txt_codigo_filtro_aceite_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_6.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_6.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_filtro_aceite_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_6.TextChanged
        buscar_ventas_lubricentro = "6"
    End Sub

    Private Sub txt_codigo_aceite_motor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_1.GotFocus
        buscar_ventas_lubricentro = "1"
    End Sub

    Private Sub txt_codigo_aceite_motor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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

        limpiar_producto()

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_productos()
        End If
    End Sub

    Private Sub txt_codigo_aceite_motor_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_1.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_1.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_aceite_motor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_1.TextChanged
        buscar_ventas_lubricentro = "1"
    End Sub

    Private Sub txt_codigo_filtro_aire_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_7.GotFocus
        buscar_ventas_lubricentro = "7"
    End Sub

    Private Sub txt_codigo_filtro_aire_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_7.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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

        limpiar_producto()

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_productos()
        End If
    End Sub

    Private Sub txt_codigo_filtro_aire_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_7.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_7.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_filtro_aire_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_7.TextChanged
        buscar_ventas_lubricentro = "7"
    End Sub

    Private Sub txt_codigo_aceite_combustible_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_8.GotFocus
        buscar_ventas_lubricentro = "8"
    End Sub

    Private Sub txt_codigo_aceite_combustible_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_8.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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

        limpiar_producto()

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_productos()
        End If
    End Sub

    Private Sub txt_codigo_aceite_combustible_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_8.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_8.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_aceite_combustible_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_8.TextChanged
        buscar_ventas_lubricentro = "8"
    End Sub

    Private Sub txt_codigo_aceite_caja_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_4.GotFocus
        buscar_ventas_lubricentro = "4"
    End Sub

    Private Sub txt_codigo_aceite_caja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_4.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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

        limpiar_producto()

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_productos()
        End If
    End Sub

    Private Sub txt_codigo_aceite_caja_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_4.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_3.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_aceite_caja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_4.TextChanged
        buscar_ventas_lubricentro = "4"
    End Sub

    Private Sub txt_codigo_aceite_diferencial_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_3.GotFocus
        buscar_ventas_lubricentro = "3"
    End Sub

    Private Sub txt_codigo_aceite_diferencial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_3.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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

        limpiar_producto()

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_productos()
        End If
    End Sub

    Private Sub txt_codigo_aceite_diferencial_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_3.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_3.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_aceite_diferencial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_3.TextChanged
        buscar_ventas_lubricentro = "3"
    End Sub

    Private Sub grilla_estado_de_cuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_estado_de_cuenta.Click
        If grilla_estado_de_cuenta.Rows.Count = 0 Then
            Exit Sub
        End If

        limpiar()


        txt_cod_auto_servicio.Text = grilla_estado_de_cuenta.CurrentRow.Cells(0).Value()
        txt_codigo_patente.Text = grilla_estado_de_cuenta.CurrentRow.Cells(1).Value()
        txt_nombre.Text = grilla_estado_de_cuenta.CurrentRow.Cells(2).Value()
        txt_kilometraje.Text = grilla_estado_de_cuenta.CurrentRow.Cells(3).Value()
        txt_rut_vendedor.Text = grilla_estado_de_cuenta.CurrentRow.Cells(4).Value()
        mostrar_datos_vendedor_por_rut()

        txt_codigo_1.Text = grilla_estado_de_cuenta.CurrentRow.Cells(6).Value.ToString
        txt_nombre_1.Text = grilla_estado_de_cuenta.CurrentRow.Cells(7).Value.ToString
        txt_cantidad_1.Text = grilla_estado_de_cuenta.CurrentRow.Cells(8).Value.ToString

        txt_codigo_2.Text = grilla_estado_de_cuenta.CurrentRow.Cells(9).Value.ToString
        txt_nombre_2.Text = grilla_estado_de_cuenta.CurrentRow.Cells(10).Value.ToString
        txt_cantidad_2.Text = grilla_estado_de_cuenta.CurrentRow.Cells(11).Value.ToString

        txt_codigo_3.Text = grilla_estado_de_cuenta.CurrentRow.Cells(12).Value.ToString
        txt_nombre_3.Text = grilla_estado_de_cuenta.CurrentRow.Cells(13).Value.ToString
        txt_cantidad_3.Text = grilla_estado_de_cuenta.CurrentRow.Cells(14).Value.ToString

        txt_codigo_4.Text = grilla_estado_de_cuenta.CurrentRow.Cells(15).Value.ToString
        txt_nombre_4.Text = grilla_estado_de_cuenta.CurrentRow.Cells(16).Value.ToString
        txt_cantidad_4.Text = grilla_estado_de_cuenta.CurrentRow.Cells(17).Value.ToString

        txt_codigo_5.Text = grilla_estado_de_cuenta.CurrentRow.Cells(18).Value.ToString
        txt_nombre_5.Text = grilla_estado_de_cuenta.CurrentRow.Cells(19).Value.ToString
        txt_cantidad_5.Text = grilla_estado_de_cuenta.CurrentRow.Cells(20).Value.ToString

        txt_codigo_6.Text = grilla_estado_de_cuenta.CurrentRow.Cells(21).Value.ToString
        txt_nombre_6.Text = grilla_estado_de_cuenta.CurrentRow.Cells(22).Value.ToString
        txt_cantidad_6.Text = grilla_estado_de_cuenta.CurrentRow.Cells(23).Value.ToString

        txt_codigo_7.Text = grilla_estado_de_cuenta.CurrentRow.Cells(24).Value.ToString
        txt_nombre_7.Text = grilla_estado_de_cuenta.CurrentRow.Cells(25).Value.ToString
        txt_cantidad_7.Text = grilla_estado_de_cuenta.CurrentRow.Cells(26).Value.ToString

        txt_codigo_8.Text = grilla_estado_de_cuenta.CurrentRow.Cells(27).Value.ToString
        txt_nombre_8.Text = grilla_estado_de_cuenta.CurrentRow.Cells(28).Value.ToString
        txt_cantidad_8.Text = grilla_estado_de_cuenta.CurrentRow.Cells(29).Value.ToString

        txt_codigo_9.Text = grilla_estado_de_cuenta.CurrentRow.Cells(30).Value.ToString
        txt_nombre_9.Text = grilla_estado_de_cuenta.CurrentRow.Cells(31).Value.ToString
        txt_cantidad_9.Text = grilla_estado_de_cuenta.CurrentRow.Cells(32).Value.ToString

        txt_codigo_10.Text = grilla_estado_de_cuenta.CurrentRow.Cells(33).Value.ToString
        txt_nombre_10.Text = grilla_estado_de_cuenta.CurrentRow.Cells(34).Value.ToString
        txt_cantidad_10.Text = grilla_estado_de_cuenta.CurrentRow.Cells(35).Value.ToString

        txt_codigo_11.Text = grilla_estado_de_cuenta.CurrentRow.Cells(36).Value.ToString
        txt_nombre_11.Text = grilla_estado_de_cuenta.CurrentRow.Cells(37).Value.ToString
        txt_cantidad_11.Text = grilla_estado_de_cuenta.CurrentRow.Cells(38).Value.ToString

        txt_codigo_12.Text = grilla_estado_de_cuenta.CurrentRow.Cells(39).Value.ToString
        txt_nombre_12.Text = grilla_estado_de_cuenta.CurrentRow.Cells(40).Value.ToString
        txt_cantidad_12.Text = grilla_estado_de_cuenta.CurrentRow.Cells(41).Value.ToString

        txt_codigo_13.Text = grilla_estado_de_cuenta.CurrentRow.Cells(42).Value.ToString
        txt_nombre_13.Text = grilla_estado_de_cuenta.CurrentRow.Cells(43).Value.ToString
        txt_cantidad_13.Text = grilla_estado_de_cuenta.CurrentRow.Cells(44).Value.ToString

        txt_codigo_14.Text = grilla_estado_de_cuenta.CurrentRow.Cells(45).Value.ToString
        txt_nombre_14.Text = grilla_estado_de_cuenta.CurrentRow.Cells(46).Value.ToString
        txt_cantidad_14.Text = grilla_estado_de_cuenta.CurrentRow.Cells(47).Value.ToString

        txt_codigo_15.Text = grilla_estado_de_cuenta.CurrentRow.Cells(48).Value.ToString
        txt_nombre_15.Text = grilla_estado_de_cuenta.CurrentRow.Cells(49).Value.ToString
        txt_cantidad_15.Text = grilla_estado_de_cuenta.CurrentRow.Cells(50).Value.ToString

        TextBox4.Text = grilla_estado_de_cuenta.CurrentRow.Cells(51).Value.ToString
        TextBox1.Text = grilla_estado_de_cuenta.CurrentRow.Cells(52).Value.ToString

        If txt_codigo_1.Text <> "" Then
            buscar_ventas_lubricentro = "1"
            mostrar_datos_productos()
        End If

        If txt_codigo_2.Text <> "" Then
            buscar_ventas_lubricentro = "2"
            mostrar_datos_productos()
        End If

        If txt_codigo_3.Text <> "" Then
            buscar_ventas_lubricentro = "3"
            mostrar_datos_productos()
        End If

        If txt_codigo_4.Text <> "" Then
            buscar_ventas_lubricentro = "4"
            mostrar_datos_productos()
        End If

        If txt_codigo_5.Text <> "" Then
            buscar_ventas_lubricentro = "5"
            mostrar_datos_productos()
        End If

        If txt_codigo_6.Text <> "" Then
            buscar_ventas_lubricentro = "6"
            mostrar_datos_productos()
        End If

        If txt_codigo_7.Text <> "" Then
            buscar_ventas_lubricentro = "7"
            mostrar_datos_productos()
        End If

        If txt_codigo_8.Text <> "" Then
            buscar_ventas_lubricentro = "8"
            mostrar_datos_productos()
        End If

        If txt_codigo_9.Text <> "" Then
            buscar_ventas_lubricentro = "9"
            mostrar_datos_productos()
        End If

        If txt_codigo_10.Text <> "" Then
            buscar_ventas_lubricentro = "10"
            mostrar_datos_productos()
        End If

        If txt_codigo_11.Text <> "" Then
            buscar_ventas_lubricentro = "11"
            mostrar_datos_productos()
        End If

        If txt_codigo_12.Text <> "" Then
            buscar_ventas_lubricentro = "12"
            mostrar_datos_productos()
        End If

        If txt_codigo_13.Text <> "" Then
            buscar_ventas_lubricentro = "13"
            mostrar_datos_productos()
        End If

        If txt_codigo_14.Text <> "" Then
            buscar_ventas_lubricentro = "14"
            mostrar_datos_productos()
        End If

        If txt_codigo_15.Text <> "" Then
            buscar_ventas_lubricentro = "15"
            mostrar_datos_productos()
        End If

        mostrar_datos_vendedor_por_rut()

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

            If txt_nombre_1.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_1.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_1.Text
                Form_venta.venta()
            End If

            If txt_nombre_2.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_2.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_2.Text
                Form_venta.venta()
            End If

            If txt_nombre_3.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_3.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_3.Text
                Form_venta.venta()
            End If

            If txt_nombre_4.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_4.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_4.Text
                Form_venta.venta()
            End If

            If txt_nombre_5.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_5.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_5.Text
                Form_venta.venta()
            End If

            If txt_nombre_6.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_6.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_6.Text
                Form_venta.venta()
            End If

            If txt_nombre_7.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_7.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_7.Text
                Form_venta.venta()
            End If

            If txt_nombre_8.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_8.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_8.Text
                Form_venta.venta()
            End If

            If txt_nombre_9.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_9.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_9.Text
                Form_venta.venta()
            End If

            If txt_nombre_10.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_10.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_10.Text
                Form_venta.venta()
            End If

            If txt_nombre_11.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_11.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_11.Text
                Form_venta.venta()
            End If

            If txt_nombre_12.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_12.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_12.Text
                Form_venta.venta()
            End If

            If txt_nombre_13.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_13.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_13.Text
                Form_venta.venta()
            End If

            If txt_nombre_14.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_14.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_14.Text
                Form_venta.venta()
            End If

            If txt_nombre_15.Text <> "" Then
                Form_venta.txt_codigo.Text = txt_codigo_15.Text
                Form_venta.mostrar_datos_productos()
                Form_venta.txt_cantidad_agregar.Text = txt_cantidad_15.Text
                Form_venta.venta()
            End If

        End If





    End Sub

    Sub limpiar()

        txt_codigo_patente.Text = ""
        txt_nombre.Text = ""
        txt_cod_auto_servicio.Text = ""
        txt_kilometraje.Text = ""

        txt_codigo_1.Text = ""
        txt_codigo_2.Text = ""
        txt_codigo_3.Text = ""
        txt_codigo_4.Text = ""
        txt_codigo_5.Text = ""
        txt_codigo_6.Text = ""
        txt_codigo_7.Text = ""
        txt_codigo_8.Text = ""
        txt_codigo_9.Text = ""
        txt_codigo_10.Text = ""
        txt_codigo_11.Text = ""
        txt_codigo_12.Text = ""
        txt_codigo_13.Text = ""
        txt_codigo_14.Text = ""
        txt_codigo_15.Text = ""

        txt_nombre_1.Text = ""
        txt_nombre_2.Text = ""
        txt_nombre_3.Text = ""
        txt_nombre_4.Text = ""
        txt_nombre_5.Text = ""
        txt_nombre_6.Text = ""
        txt_nombre_7.Text = ""
        txt_nombre_8.Text = ""
        txt_nombre_9.Text = ""
        txt_nombre_10.Text = ""
        txt_nombre_11.Text = ""
        txt_nombre_12.Text = ""
        txt_nombre_13.Text = ""
        txt_nombre_14.Text = ""
        txt_nombre_15.Text = ""

        txt_cantidad_6.Text = ""
        txt_cantidad_1.Text = ""
        txt_cantidad_7.Text = ""
        txt_cantidad_8.Text = ""
        txt_cantidad_4.Text = ""
        txt_cantidad_3.Text = ""
        txt_cantidad_9.Text = ""
        txt_cantidad_2.Text = ""
        txt_cantidad_5.Text = ""
        txt_cantidad_10.Text = ""
        txt_cantidad_11.Text = ""
        txt_cantidad_12.Text = ""
        txt_cantidad_13.Text = ""
        txt_cantidad_14.Text = ""
        txt_cantidad_15.Text = ""

        txt_nro_tecnico_6.Text = ""
        txt_nro_tecnico_1.Text = ""
        txt_nro_tecnico_7.Text = ""
        txt_nro_tecnico_8.Text = ""
        txt_nro_tecnico_4.Text = ""
        txt_nro_tecnico_3.Text = ""
        txt_nro_tecnico_9.Text = ""
        txt_nro_tecnico_2.Text = ""
        txt_nro_tecnico_5.Text = ""
        txt_nro_tecnico_10.Text = ""
        txt_nro_tecnico_11.Text = ""
        txt_nro_tecnico_12.Text = ""
        txt_nro_tecnico_13.Text = ""
        txt_nro_tecnico_14.Text = ""
        txt_nro_tecnico_15.Text = ""

        Combo_vendedor.SelectedItem = "-"
        txt_rut_vendedor.Text = ""
    End Sub



    'Sub color_foco()


    '    Dim controlcito As Control
    '    Dim controlChild As Control


    '    For Each controlcito In Me.Controls
    '        If TypeOf controlcito Is TextBox Then
    '            If CType(controlcito, TextBox).ReadOnly = False Then
    '                CType(controlcito, TextBox).BackColor = Color.White
    '            End If
    '        End If

    '        If TypeOf controlcito Is ComboBox Then
    '            CType(controlcito, ComboBox).BackColor = Color.White
    '        End If

    '        If TypeOf controlcito Is Button Then
    '            CType(controlcito, Button).BackColor = Color.Transparent
    '        End If

    '        If TypeOf controlcito Is GroupBox Then
    '            For Each controlChild In controlcito.Controls
    '                If TypeOf controlChild Is TextBox Then
    '                    If CType(controlChild, TextBox).ReadOnly = False Then
    '                        CType(controlChild, TextBox).BackColor = Color.White
    '                    End If
    '                End If

    '                If TypeOf controlChild Is ComboBox Then
    '                    CType(controlChild, ComboBox).BackColor = Color.White
    '                End If

    '                If TypeOf controlChild Is Button Then
    '                    CType(controlChild, Button).BackColor = Color.Transparent
    '                End If
    '            Next
    '        End If

    '        If TypeOf controlcito Is Panel Then
    '            For Each controlChild In controlcito.Controls
    '                If TypeOf controlChild Is TextBox Then
    '                    If CType(controlChild, TextBox).ReadOnly = False Then
    '                        CType(controlChild, TextBox).BackColor = Color.White
    '                    End If
    '                End If

    '                If TypeOf controlChild Is ComboBox Then
    '                    CType(controlChild, ComboBox).BackColor = Color.White
    '                End If

    '                If TypeOf controlChild Is Button Then
    '                    CType(controlChild, Button).BackColor = Color.Transparent
    '                End If
    '            Next
    '        End If

    '    Next











    '    For Each controlcito In Me.Controls
    '        If TypeOf controlcito Is TextBox Then
    '            If CType(controlcito, TextBox).Focused Then
    '                If CType(controlcito, TextBox).ReadOnly = False Then
    '                    CType(controlcito, TextBox).BackColor = Color.LightSkyBlue
    '                    Exit Sub
    '                End If
    '            End If
    '        End If

    '        If TypeOf controlcito Is ComboBox Then
    '            If CType(controlcito, ComboBox).Focused Then
    '                CType(controlcito, ComboBox).BackColor = Color.LightSkyBlue
    '                Exit Sub
    '            End If
    '        End If

    '        If TypeOf controlcito Is Button Then
    '            If CType(controlcito, Button).Focused Then
    '                CType(controlcito, Button).BackColor = Color.LightSkyBlue
    '                Exit Sub
    '            End If
    '        End If

    '        If TypeOf controlcito Is GroupBox Then
    '            For Each controlChild In controlcito.Controls
    '                If TypeOf controlChild Is TextBox Then
    '                    If CType(controlChild, TextBox).Focused Then
    '                        If CType(controlChild, TextBox).ReadOnly = False Then
    '                            CType(controlChild, TextBox).BackColor = Color.LightSkyBlue
    '                            Exit Sub
    '                        End If
    '                    End If
    '                End If

    '                If TypeOf controlChild Is ComboBox Then
    '                    If CType(controlChild, ComboBox).Focused Then
    '                        CType(controlChild, ComboBox).BackColor = Color.LightSkyBlue
    '                        Exit Sub
    '                    End If
    '                End If

    '                If TypeOf controlChild Is Button Then
    '                    If CType(controlChild, Button).Focused Then
    '                        CType(controlChild, Button).BackColor = Color.LightSkyBlue
    '                        Exit Sub
    '                    End If
    '                End If
    '            Next
    '        End If


    '        If TypeOf controlcito Is Panel Then
    '            For Each controlChild In controlcito.Controls
    '                If TypeOf controlChild Is TextBox Then
    '                    If CType(controlChild, TextBox).Focused Then
    '                        If CType(controlChild, TextBox).ReadOnly = False Then
    '                            CType(controlChild, TextBox).BackColor = Color.LightSkyBlue
    '                            Exit Sub
    '                        End If
    '                    End If
    '                End If

    '                If TypeOf controlChild Is ComboBox Then
    '                    If CType(controlChild, ComboBox).Focused Then
    '                        CType(controlChild, ComboBox).BackColor = Color.LightSkyBlue
    '                        Exit Sub
    '                    End If
    '                End If

    '                If TypeOf controlChild Is Button Then
    '                    If CType(controlChild, Button).Focused Then
    '                        CType(controlChild, Button).BackColor = Color.LightSkyBlue
    '                        Exit Sub
    '                    End If
    '                End If
    '            Next
    '        End If

    '    Next
    'End Sub

    Private Sub btn_buscar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_6.Click
        buscar_ventas_lubricentro = "6"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_1.Click
        buscar_ventas_lubricentro = "1"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_8.Click
        buscar_ventas_lubricentro = "8"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_7.Click
        buscar_ventas_lubricentro = "7"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_4.Click
        buscar_ventas_lubricentro = "4"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
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

    Sub mostrar_datos_productos()

        If buscar_ventas_lubricentro = "1" Then
            If txt_codigo_1.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_1.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_nombre_1.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_nro_tecnico_1.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                End If
                conexion.Close()

                If txt_nombre_1.Text = "" Then
                    MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_codigo_1.Focus()
                    Exit Sub
                End If

                txt_cantidad_1.Focus()

            End If
        End If
        If buscar_ventas_lubricentro = "2" Then
            If txt_codigo_2.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_2.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_nombre_2.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_nro_tecnico_2.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                End If
                conexion.Close()

                If txt_nombre_2.Text = "" Then
                    MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_codigo_2.Focus()
                    Exit Sub
                End If

                txt_cantidad_2.Focus()

            End If
        End If
        If buscar_ventas_lubricentro = "3" Then
            If txt_codigo_3.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_3.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_nombre_3.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_nro_tecnico_3.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                End If
                conexion.Close()

                If txt_nombre_3.Text = "" Then
                    MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_codigo_3.Focus()
                    Exit Sub
                End If

                txt_cantidad_3.Focus()

            End If
        End If
        If buscar_ventas_lubricentro = "4" Then
            If txt_codigo_4.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_4.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_nombre_4.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_nro_tecnico_4.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                End If
                conexion.Close()

                If txt_nombre_4.Text = "" Then
                    MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_codigo_4.Focus()
                    Exit Sub
                End If

                txt_cantidad_4.Focus()

            End If
        End If
        If buscar_ventas_lubricentro = "5" Then
            If txt_codigo_5.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_5.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_nombre_5.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_nro_tecnico_5.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                End If
                conexion.Close()

                If txt_nombre_5.Text = "" Then
                    MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_codigo_5.Focus()
                    Exit Sub
                End If

                txt_cantidad_5.Focus()

            End If
        End If
        If buscar_ventas_lubricentro = "6" Then
            If txt_codigo_6.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_6.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_nombre_6.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_nro_tecnico_6.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                End If
                conexion.Close()

                If txt_nombre_6.Text = "" Then
                    MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_codigo_6.Focus()
                    Exit Sub
                End If

                txt_cantidad_6.Focus()

            End If
        End If
        If buscar_ventas_lubricentro = "7" Then
            If txt_codigo_7.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_7.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_nombre_7.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_nro_tecnico_7.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                End If
                conexion.Close()

                If txt_nombre_7.Text = "" Then
                    MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_codigo_7.Focus()
                    Exit Sub
                End If

                txt_cantidad_7.Focus()

            End If
        End If
        If buscar_ventas_lubricentro = "8" Then
            If txt_codigo_8.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_8.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_nombre_8.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_nro_tecnico_8.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                End If
                conexion.Close()

                If txt_nombre_8.Text = "" Then
                    MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_codigo_8.Focus()
                    Exit Sub
                End If

                txt_cantidad_8.Focus()

            End If
        End If
        If buscar_ventas_lubricentro = "9" Then
            If txt_codigo_9.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_9.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_nombre_9.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_nro_tecnico_9.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                End If
                conexion.Close()

                If txt_nombre_9.Text = "" Then
                    MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_codigo_9.Focus()
                    Exit Sub
                End If

                txt_cantidad_9.Focus()

            End If
        End If
        If buscar_ventas_lubricentro = "10" Then
            If txt_codigo_10.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_10.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_nombre_10.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_nro_tecnico_10.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                End If
                conexion.Close()

                If txt_nombre_10.Text = "" Then
                    MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_codigo_10.Focus()
                    Exit Sub
                End If

                txt_cantidad_10.Focus()

            End If
        End If
        If buscar_ventas_lubricentro = "11" Then
            If txt_codigo_11.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_11.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_nombre_11.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_nro_tecnico_11.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                End If
                conexion.Close()

                If txt_nombre_11.Text = "" Then
                    MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_codigo_11.Focus()
                    Exit Sub
                End If

                txt_cantidad_11.Focus()

            End If
        End If
        If buscar_ventas_lubricentro = "12" Then
            If txt_codigo_12.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_12.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_nombre_12.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_nro_tecnico_12.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                End If
                conexion.Close()

                If txt_nombre_12.Text = "" Then
                    MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_codigo_12.Focus()
                    Exit Sub
                End If

                txt_cantidad_12.Focus()

            End If
        End If
        If buscar_ventas_lubricentro = "13" Then
            If txt_codigo_13.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_13.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_nombre_13.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_nro_tecnico_13.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                End If
                conexion.Close()

                If txt_nombre_13.Text = "" Then
                    MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_codigo_13.Focus()
                    Exit Sub
                End If

                txt_cantidad_13.Focus()

            End If
        End If
        If buscar_ventas_lubricentro = "14" Then
            If txt_codigo_14.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_14.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_nombre_14.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_nro_tecnico_14.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                End If
                conexion.Close()

                If txt_nombre_14.Text = "" Then
                    MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_codigo_14.Focus()
                    Exit Sub
                End If

                txt_cantidad_14.Focus()

            End If
        End If
        If buscar_ventas_lubricentro = "15" Then
            If txt_codigo_15.Text <> "" Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_15.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)

                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    txt_nombre_15.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_nro_tecnico_15.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                End If
                conexion.Close()

                If txt_nombre_15.Text = "" Then
                    MsgBox("CODIGO NO ENCONTRADO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    txt_codigo_15.Focus()
                    Exit Sub
                End If

                txt_cantidad_15.Focus()

            End If
        End If
    End Sub

    Private Sub btn_buscar_productos_6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_3.Click
        buscar_ventas_lubricentro = "3"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub txt_codigo_otros_1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_9.GotFocus
        buscar_ventas_lubricentro = "9"
    End Sub

    Private Sub txt_codigo_otros_1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_9.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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

        limpiar_producto()

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_productos()
        End If
    End Sub

    Private Sub txt_codigo_otros_1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_9.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_9.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_otros_1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_9.TextChanged
        buscar_ventas_lubricentro = "9"
    End Sub

    Private Sub txt_codigo_otros_2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_2.GotFocus
        buscar_ventas_lubricentro = "2"
    End Sub

    Private Sub txt_codigo_otros_2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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

        limpiar_producto()

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_productos()
        End If
    End Sub

    Private Sub txt_codigo_otros_2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_2.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_2.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_otros_2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_2.TextChanged
        buscar_ventas_lubricentro = "2"
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
                txt_codigo_2.Focus()
                Exit Sub
            End If

            txt_nombre.Focus()
        End If
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

    Private Sub btn_buscar_productos_7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_9.Click
        buscar_ventas_lubricentro = "9"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_buscar_productos_8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_2.Click
        buscar_ventas_lubricentro = "2"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
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

    Private Sub txt_cantidad_1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_6.KeyPress
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

            If txt_cantidad_6.Text = "" Then
                txt_cantidad_6.Text = "1"
            End If

            txt_codigo_1.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_1.KeyPress
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

            If txt_cantidad_1.Text = "" Then
                txt_cantidad_1.Text = "1"
            End If

            txt_codigo_7.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_7.KeyPress
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

            If txt_cantidad_7.Text = "" Then
                txt_cantidad_7.Text = "1"
            End If

            txt_codigo_8.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_8.KeyPress
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

            If txt_cantidad_8.Text = "" Then
                txt_cantidad_8.Text = "1"
            End If

            txt_codigo_4.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_4.KeyPress
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

            txt_codigo_3.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_3.KeyPress
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

            If txt_cantidad_3.Text = "" Then
                txt_cantidad_3.Text = "1"
            End If

            txt_codigo_9.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_9.KeyPress
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

            txt_codigo_2.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_2.KeyPress
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

            txt_codigo_5.Focus()
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

    Private Sub Combo_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_vendedor.SelectedIndexChanged
        mostrar_datos_vendedor()
    End Sub

    Private Sub GroupBox8_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox16.Enter

    End Sub

    Private Sub txt_codigo_otros_3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_5.GotFocus
        buscar_ventas_lubricentro = "5"
    End Sub

    Private Sub txt_codigo_otros_3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_5.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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

        limpiar_producto()

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_productos()
        End If
    End Sub

    Private Sub txt_codigo_otros_3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_5.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_5.PerformClick()
        End If
    End Sub



    Private Sub txt_codigo_otros_3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_5.TextChanged
        buscar_ventas_lubricentro = "5"
    End Sub

    Private Sub txt_codigo_otros_4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_10.GotFocus
        buscar_ventas_lubricentro = "10"
    End Sub

    Private Sub txt_codigo_otros_4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_10.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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

        limpiar_producto()

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_productos()
        End If
    End Sub

    Private Sub txt_codigo_otros_4_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codigo_10.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_10.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_otros_4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_10.TextChanged
        buscar_ventas_lubricentro = "10"
    End Sub

    Private Sub txt_cantidad_9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad_5.KeyPress
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

            If txt_cantidad_5.Text = "" Then
                txt_cantidad_5.Text = "1"
            End If

            txt_codigo_10.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_9_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cantidad_5.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_10.PerformClick()
        End If
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

    Private Sub btn_buscar_productos_9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_5.Click
        buscar_ventas_lubricentro = "5"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_buscar_productos_10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_productos_10.Click
        buscar_ventas_lubricentro = "10"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nueva.Click

        limpiar()

        Form_nuevo_servicio_lubricentro.Show()

        Me.Enabled = False

    End Sub

    Private Sub btn_comentario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_comentario.Click

        If txt_cod_auto_servicio.Text = "" Then
            Exit Sub
        End If

        Form_comentario_ventas_lubricentro.Show()
        Me.Enabled = False
    End Sub

    Private Sub txt_nro_tecnico_1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_nro_tecnico_6.KeyUp

    End Sub

    Private Sub txt_nro_tecnico_1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_tecnico_6.TextChanged

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub btn_mostrar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        Me.Enabled = False
        mostrar_malla()
        Me.Enabled = True
    End Sub

    Private Sub btn_buscar_productos_11_Click(sender As Object, e As EventArgs) Handles btn_buscar_productos_11.Click
        buscar_ventas_lubricentro = "11"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_buscar_productos_12_Click(sender As Object, e As EventArgs) Handles btn_buscar_productos_12.Click
        buscar_ventas_lubricentro = "12"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_buscar_productos_13_Click(sender As Object, e As EventArgs) Handles btn_buscar_productos_13.Click
        buscar_ventas_lubricentro = "13"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_buscar_productos_14_Click(sender As Object, e As EventArgs) Handles btn_buscar_productos_14.Click
        buscar_ventas_lubricentro = "14"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_buscar_productos_15_Click(sender As Object, e As EventArgs) Handles btn_buscar_productos_15.Click
        buscar_ventas_lubricentro = "15"
        Form_buscador_inteligente.Show()
        Me.Enabled = False
    End Sub

    Private Sub txt_codigo_11_TextChanged(sender As Object, e As EventArgs) Handles txt_codigo_11.TextChanged
        buscar_ventas_lubricentro = "11"
    End Sub

    Private Sub txt_codigo_12_TextChanged(sender As Object, e As EventArgs) Handles txt_codigo_12.TextChanged
        buscar_ventas_lubricentro = "12"
    End Sub

    Private Sub txt_codigo_13_TextChanged(sender As Object, e As EventArgs) Handles txt_codigo_13.TextChanged
        buscar_ventas_lubricentro = "13"
    End Sub

    Private Sub txt_codigo_14_TextChanged(sender As Object, e As EventArgs) Handles txt_codigo_14.TextChanged
        buscar_ventas_lubricentro = "14"
    End Sub

    Private Sub txt_codigo_15_TextChanged(sender As Object, e As EventArgs) Handles txt_codigo_15.TextChanged
        buscar_ventas_lubricentro = "15"
    End Sub

    Sub limpiar_producto()

        If buscar_ventas_lubricentro = "1" Then
            txt_nombre_1.Text = ""
            txt_nro_tecnico_1.Text = ""
            txt_cantidad_1.Text = ""
        End If

        If buscar_ventas_lubricentro = "2" Then
            txt_nombre_2.Text = ""
            txt_nro_tecnico_2.Text = ""
            txt_cantidad_2.Text = ""
        End If

        If buscar_ventas_lubricentro = "3" Then
            txt_nombre_3.Text = ""
            txt_nro_tecnico_3.Text = ""
            txt_cantidad_3.Text = ""
        End If

        If buscar_ventas_lubricentro = "4" Then
            txt_nombre_4.Text = ""
            txt_nro_tecnico_4.Text = ""
            txt_cantidad_4.Text = ""
        End If

        If buscar_ventas_lubricentro = "5" Then
            txt_nombre_5.Text = ""
            txt_nro_tecnico_5.Text = ""
            txt_cantidad_5.Text = ""
        End If

        If buscar_ventas_lubricentro = "6" Then
            txt_nombre_6.Text = ""
            txt_nro_tecnico_6.Text = ""
            txt_cantidad_6.Text = ""
        End If

        If buscar_ventas_lubricentro = "7" Then
            txt_nombre_7.Text = ""
            txt_nro_tecnico_7.Text = ""
            txt_cantidad_7.Text = ""
        End If

        If buscar_ventas_lubricentro = "8" Then
            txt_nombre_8.Text = ""
            txt_nro_tecnico_8.Text = ""
            txt_cantidad_8.Text = ""
        End If

        If buscar_ventas_lubricentro = "9" Then
            txt_nombre_9.Text = ""
            txt_nro_tecnico_9.Text = ""
            txt_cantidad_9.Text = ""
        End If

        If buscar_ventas_lubricentro = "10" Then
            txt_nombre_10.Text = ""
            txt_nro_tecnico_10.Text = ""
            txt_cantidad_10.Text = ""
        End If

        If buscar_ventas_lubricentro = "11" Then
            txt_nombre_11.Text = ""
            txt_nro_tecnico_11.Text = ""
            txt_cantidad_11.Text = ""
        End If

        If buscar_ventas_lubricentro = "12" Then
            txt_nombre_12.Text = ""
            txt_nro_tecnico_12.Text = ""
            txt_cantidad_12.Text = ""
        End If

        If buscar_ventas_lubricentro = "13" Then
            txt_nombre_13.Text = ""
            txt_nro_tecnico_13.Text = ""
            txt_cantidad_13.Text = ""
        End If

        If buscar_ventas_lubricentro = "14" Then
            txt_nombre_14.Text = ""
            txt_nro_tecnico_14.Text = ""
            txt_cantidad_14.Text = ""
        End If

        If buscar_ventas_lubricentro = "15" Then
            txt_nombre_15.Text = ""
            txt_nro_tecnico_15.Text = ""
            txt_cantidad_15.Text = ""
        End If

    End Sub

    Private Sub txt_codigo_11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_codigo_11.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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

        limpiar_producto()

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_productos()
        End If
    End Sub

    Private Sub txt_codigo_12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_codigo_12.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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

        limpiar_producto()

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_productos()
        End If
    End Sub

    Private Sub txt_codigo_13_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_codigo_13.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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

        limpiar_producto()

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_productos()
        End If
    End Sub

    Private Sub txt_codigo_14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_codigo_14.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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

        limpiar_producto()

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_productos()
        End If
    End Sub

    Private Sub txt_codigo_15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_codigo_15.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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

        limpiar_producto()

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            mostrar_datos_productos()
        End If
    End Sub

    Private Sub txt_cantidad_11_TextChanged(sender As Object, e As EventArgs) Handles txt_cantidad_11.TextChanged

    End Sub

    Private Sub txt_cantidad_11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad_11.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cantidad_12_TextChanged(sender As Object, e As EventArgs) Handles txt_cantidad_12.TextChanged

    End Sub

    Private Sub txt_cantidad_12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad_12.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cantidad_13_TextChanged(sender As Object, e As EventArgs) Handles txt_cantidad_13.TextChanged

    End Sub

    Private Sub txt_cantidad_13_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad_13.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cantidad_14_TextChanged(sender As Object, e As EventArgs) Handles txt_cantidad_14.TextChanged

    End Sub

    Private Sub txt_cantidad_14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad_14.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cantidad_15_TextChanged(sender As Object, e As EventArgs) Handles txt_cantidad_15.TextChanged

    End Sub

    Private Sub txt_cantidad_15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cantidad_15.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_codigo_11_GotFocus(sender As Object, e As EventArgs) Handles txt_codigo_11.GotFocus
        buscar_ventas_lubricentro = "11"
    End Sub

    Private Sub txt_codigo_12_GotFocus(sender As Object, e As EventArgs) Handles txt_codigo_12.GotFocus
        buscar_ventas_lubricentro = "12"
    End Sub

    Private Sub txt_codigo_13_GotFocus(sender As Object, e As EventArgs) Handles txt_codigo_13.GotFocus
        buscar_ventas_lubricentro = "13"
    End Sub

    Private Sub txt_codigo_14_GotFocus(sender As Object, e As EventArgs) Handles txt_codigo_14.GotFocus
        buscar_ventas_lubricentro = "14"
    End Sub

    Private Sub txt_codigo_15_GotFocus(sender As Object, e As EventArgs) Handles txt_codigo_15.GotFocus
        buscar_ventas_lubricentro = "15"
    End Sub

    Private Sub grilla_estado_de_cuenta_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla_estado_de_cuenta.CellContentClick

    End Sub

    Private Sub txt_codigo_15_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_codigo_15.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_15.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_14_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_codigo_14.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_14.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_13_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_codigo_13.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_13.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_12_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_codigo_12.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_12.PerformClick()
        End If
    End Sub

    Private Sub txt_codigo_11_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_codigo_11.KeyUp
        If e.KeyCode = Keys.F4 Then
            conexion.Close()
            btn_buscar_productos_11.PerformClick()
        End If
    End Sub
End Class