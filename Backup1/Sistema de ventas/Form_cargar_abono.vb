Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Public Class Form_cargar_abono

    Private Sub Form_cargar_abono_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_agregar_abonos.Enabled = True
        Form_agregar_abonos.txt_n_abono.Focus()
        Form_agregar_abonos.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_cargar_abono_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_cargar_abono_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub cargar_datos_abono()

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from abono where n_abono ='" & (txt_nro_doc.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        Try
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Form_agregar_abonos.txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
                Form_agregar_abonos.txt_n_abono.Text = DS.Tables(DT.TableName).Rows(0).Item("n_abono")
                Form_agregar_abonos.dtp_emision.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha")
                Form_agregar_abonos.txt_total_abono.Text = DS.Tables(DT.TableName).Rows(0).Item("monto_abono")

                Form_agregar_abonos.mostrar_datos_clientes()
                Form_agregar_abonos.combo_factura.Items.Clear()
                Form_agregar_abonos.llenar_combo_doc()
                Form_agregar_abonos.guion_rut_cliente()
                Form_agregar_abonos.mostrar_datos_clientes()
                '  Form_agregar_abonos.mostrar_deuda()
            End If
        Catch
        End Try
        conexion.Close()

        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()

        'SC.Connection = conexion
        'SC.CommandText = "select * from creditos where n_creditos ='" & (txt_nro_doc.Text) & "' and TIPO='ABONO'"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)

        'Try
        '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '        Form_agregar_abonos.txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_cliente")
        '        Form_agregar_abonos.txt_n_abono.Text = DS.Tables(DT.TableName).Rows(0).Item("n_abono")
        '        Form_agregar_abonos.dtp_emision.Text = DS.Tables(DT.TableName).Rows(0).Item("fecha")
        '        Form_agregar_abonos.txt_total_abono.Text = DS.Tables(DT.TableName).Rows(0).Item("monto_abono")

        '        Form_agregar_abonos.mostrar_datos_clientes()
        '        Form_agregar_abonos.combo_factura.Items.Clear()
        '        Form_agregar_abonos.llenar_combo_doc()
        '        Form_agregar_abonos.guion_rut_cliente()
        '        Form_agregar_abonos.mostrar_datos_clientes()
        '        Form_agregar_abonos.mostrar_deuda()
        '    End If
        'Catch
        'End Try
        'conexion.Close()

    End Sub

    Sub cargar_abono()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select tipo_documento, nro_documento, monto_abono, saldo_documento from detalle_abono where nro_abono='" & (txt_nro_doc.Text) & "' "
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        Form_agregar_abonos.grilla_abono.Rows.Clear()

        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Form_agregar_abonos.grilla_abono.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("tipo_documento"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("nro_documento"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("monto_abono"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("saldo_documento"), _
                                                    "INGRESADO")
            Next

        End If
    End Sub

    Private Sub txt_nro_doc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nro_doc.KeyPress

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



        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btn_aceptar.PerformClick()
        End If
    End Sub

    Private Sub txt_nro_doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_doc.TextChanged

    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Dim mensaje As String = ""
        If txt_nro_doc.Text = "" Then
            mensaje = "CAMPO NRO. DOC. VACIO, FAVOR LLENAR" + Chr(13) & mensaje
            txt_nro_doc.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        cargar_abono()
        cargar_datos_abono()
        Form_agregar_abonos.mostrar_datos_clientes()
        Form_agregar_abonos.calcular_totales()





        Form_agregar_abonos.combo_factura.Items.Clear()
        Form_agregar_abonos.llenar_combo_doc()
        Form_agregar_abonos.guion_rut_cliente()
        Form_agregar_abonos.mostrar_datos_clientes()
        '  Form_agregar_abonos.mostrar_deuda()








        Form_agregar_abonos.btn_modificar_abono.Enabled = True
        '  Form_agregar_abonos.txt_n_abono.Enabled = False
        Form_agregar_abonos.txt_rut.Enabled = False
        Form_agregar_abonos.dtp_emision.Enabled = False
        Form_agregar_abonos.txt_total_abono.Enabled = False
        Form_agregar_abonos.txt_nombre_cliente.Enabled = False
        Form_agregar_abonos.txt_direccion.Enabled = False
        Me.Close()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub


End Class