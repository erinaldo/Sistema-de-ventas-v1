Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Public Class Form_cargar_fecha_cheque
    Dim mifecha2 As String
    Dim mifecha4 As String

    Private Sub Form_cargar_fecha_cheque_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_registro_de_cheques.Enabled = True
        Form_registro_de_cheques.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_cargar_fecha_cheque_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_cargar_fecha_cheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()

        'If radio_fecha_caja.Checked = True Then
        '    dtp_fecha_caja.Enabled = True
        '    dtp_fecha_cheque.Enabled = False
        '    dtp_desde_caja.Enabled = False
        '    dtp_hasta_caja.Enabled = False
        '    dtp_desde_cheque.Enabled = False
        '    dtp_hasta_cheque.Enabled = False
        'End If

        'If radio_fecha_cheque.Checked = True Then
        '    dtp_fecha_caja.Enabled = False
        '    dtp_fecha_cheque.Enabled = True
        '    dtp_desde_caja.Enabled = False
        '    dtp_hasta_caja.Enabled = False
        '    dtp_desde_cheque.Enabled = False
        '    dtp_hasta_cheque.Enabled = False
        'End If


        If radio_rango_fechas.Checked = True Then
            'dtp_fecha_caja.Enabled = False
            'dtp_fecha_cheque.Enabled = False
            dtp_desde_caja.Enabled = True
            dtp_hasta_caja.Enabled = True
            dtp_desde_cheque.Enabled = False
            dtp_hasta_cheque.Enabled = False
        End If

        If Radio_rango_cheques.Checked = True Then
            'dtp_fecha_caja.Enabled = False
            'dtp_fecha_cheque.Enabled = False
            dtp_desde_caja.Enabled = False
            dtp_hasta_caja.Enabled = False
            dtp_desde_cheque.Enabled = True
            dtp_hasta_cheque.Enabled = True
        End If

    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub



    Private Sub radio_fecha_caja_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If radio_fecha_caja.Checked = True Then
        '    dtp_fecha_caja.Enabled = True
        '    dtp_fecha_cheque.Enabled = False
        '    dtp_desde_caja.Enabled = False
        '    dtp_hasta_caja.Enabled = False
        '    dtp_desde_cheque.Enabled = False
        '    dtp_hasta_cheque.Enabled = False
        'End If

        'If radio_fecha_cheque.Checked = True Then
        '    'dtp_fecha_caja.Enabled = False
        '    'dtp_fecha_cheque.Enabled = True
        '    dtp_desde_caja.Enabled = False
        '    dtp_hasta_caja.Enabled = False
        '    dtp_desde_cheque.Enabled = False
        '    dtp_hasta_cheque.Enabled = False
        'End If


        If radio_rango_fechas.Checked = True Then
            'dtp_fecha_caja.Enabled = False
            'dtp_fecha_cheque.Enabled = False
            dtp_desde_caja.Enabled = True
            dtp_hasta_caja.Enabled = True
            dtp_desde_cheque.Enabled = False
            dtp_hasta_cheque.Enabled = False
        End If

        If Radio_rango_cheques.Checked = True Then
            'dtp_fecha_caja.Enabled = False
            'dtp_fecha_cheque.Enabled = False
            dtp_desde_caja.Enabled = False
            dtp_hasta_caja.Enabled = False
            dtp_desde_cheque.Enabled = True
            dtp_hasta_cheque.Enabled = True
        End If
    End Sub

    Private Sub radio_fecha_cheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If radio_fecha_caja.Checked = True Then
        '    dtp_fecha_caja.Enabled = True
        '    dtp_fecha_cheque.Enabled = False
        '    dtp_desde_caja.Enabled = False
        '    dtp_hasta_caja.Enabled = False
        '    dtp_desde_cheque.Enabled = False
        '    dtp_hasta_cheque.Enabled = False
        'End If

        'If radio_fecha_cheque.Checked = True Then
        '    dtp_fecha_caja.Enabled = False
        '    dtp_fecha_cheque.Enabled = True
        '    dtp_desde_caja.Enabled = False
        '    dtp_hasta_caja.Enabled = False
        '    dtp_desde_cheque.Enabled = False
        '    dtp_hasta_cheque.Enabled = False
        'End If


        If radio_rango_fechas.Checked = True Then
            'dtp_fecha_caja.Enabled = False
            'dtp_fecha_cheque.Enabled = False
            dtp_desde_caja.Enabled = True
            dtp_hasta_caja.Enabled = True
            dtp_desde_cheque.Enabled = False
            dtp_hasta_cheque.Enabled = False
        End If

        If Radio_rango_cheques.Checked = True Then
            'dtp_fecha_caja.Enabled = False
            'dtp_fecha_cheque.Enabled = False
            dtp_desde_caja.Enabled = False
            dtp_hasta_caja.Enabled = False
            dtp_desde_cheque.Enabled = True
            dtp_hasta_cheque.Enabled = True
        End If
    End Sub

    Private Sub radio_rango_fechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radio_rango_fechas.CheckedChanged
        'If radio_fecha_caja.Checked = True Then
        '    dtp_fecha_caja.Enabled = True
        '    dtp_fecha_cheque.Enabled = False
        '    dtp_desde_caja.Enabled = False
        '    dtp_hasta_caja.Enabled = False
        '    dtp_desde_cheque.Enabled = False
        '    dtp_hasta_cheque.Enabled = False
        'End If

        'If radio_fecha_cheque.Checked = True Then
        '    dtp_fecha_caja.Enabled = False
        '    dtp_fecha_cheque.Enabled = True
        '    dtp_desde_caja.Enabled = False
        '    dtp_hasta_caja.Enabled = False
        '    dtp_desde_cheque.Enabled = False
        '    dtp_hasta_cheque.Enabled = False
        'End If


        If radio_rango_fechas.Checked = True Then
            'dtp_fecha_caja.Enabled = False
            'dtp_fecha_cheque.Enabled = False
            dtp_desde_caja.Enabled = True
            dtp_hasta_caja.Enabled = True
            dtp_desde_cheque.Enabled = False
            dtp_hasta_cheque.Enabled = False
        End If

        If Radio_rango_cheques.Checked = True Then
            'dtp_fecha_caja.Enabled = False
            'dtp_fecha_cheque.Enabled = False
            dtp_desde_caja.Enabled = False
            dtp_hasta_caja.Enabled = False
            dtp_desde_cheque.Enabled = True
            dtp_hasta_cheque.Enabled = True
        End If
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        mostrar_malla()
        Me.Close()
    End Sub

    Sub fecha()

        'If radio_fecha_caja.Checked = True Then
        '    Dim mifecha As Date
        '    mifecha = dtp_fecha_caja.Text
        '    mifecha2 = mifecha.ToString("yyy-MM-dd")
        'End If

        'If radio_fecha_cheque.Checked = True Then
        '    Dim mifecha3 As Date
        '    mifecha3 = dtp_fecha_cheque.Text
        '    mifecha4 = mifecha3.ToString("yyy-MM-dd")
        'End If

        If radio_rango_fechas.Checked = True Then

            Dim mifecha As Date
            mifecha = dtp_desde_caja.Text
            mifecha2 = mifecha.ToString("yyy-MM-dd")

            Dim mifecha3 As Date
            mifecha3 = dtp_hasta_caja.Text
            mifecha4 = mifecha3.ToString("yyy-MM-dd")
        End If

        If Radio_rango_cheques.Checked = True Then

            Dim mifecha As Date
            mifecha = dtp_desde_caja.Text
            mifecha2 = mifecha.ToString("yyy-MM-dd")

            Dim mifecha3 As Date
            mifecha3 = dtp_hasta_caja.Text
            mifecha4 = mifecha3.ToString("yyy-MM-dd")
        End If

    End Sub

    Sub mostrar_malla()

        fecha()


        'If radio_fecha_caja.Checked = True Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    SC.Connection = conexion

        '    SC.CommandText = "select * from cheques, bancos  where  fecha_caja = '" & (mifecha2) & "' and bancos.codigo_banco=cheques.nro_banco order by folio_cheque asc"

        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    DS.Tables.Add(DT)
        '    Form_registro_de_cheques.grilla_estado_de_cuenta.Rows.Clear()

        '    If DS.Tables(DT.TableName).Rows.Count > 0 Then

        '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
        '            Dim MiFechaCaja As Date
        '            Dim MiFechaCaja2 As String
        '            MiFechaCaja = DS.Tables(DT.TableName).Rows(i).Item("fecha_caja")
        '            MiFechaCaja2 = MiFechaCaja.ToString("dd-MM-yyy")

        '            Dim MiFechaCheque As Date
        '            Dim MiFechaCheque2 As String
        '            MiFechaCheque = DS.Tables(DT.TableName).Rows(i).Item("fecha_cheque")
        '            MiFechaCheque2 = MiFechaCheque.ToString("dd-MM-yyy")

        '            Form_registro_de_cheques.grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("folio_cheque"), _
        '                                               MiFechaCaja2, _
        '                                                MiFechaCheque2, _
        '                                                 DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente"), _
        '                                                  DS.Tables(DT.TableName).Rows(i).Item("nro_banco"), _
        '                                                   DS.Tables(DT.TableName).Rows(i).Item("nombre_banco"), _
        '                                                    DS.Tables(DT.TableName).Rows(i).Item("nro_cheque"), _
        '                                                     DS.Tables(DT.TableName).Rows(i).Item("monto_cheque"))
        '        Next
        '    End If
        'End If



        'If radio_fecha_cheque.Checked = True Then
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    SC.Connection = conexion

        '    SC.CommandText = "select * from cheques, bancos  where  fecha_cheque = '" & (mifecha4) & "' and bancos.codigo_banco=cheques.nro_banco order by folio_cheque asc"

        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    DS.Tables.Add(DT)
        '    Form_registro_de_cheques.grilla_estado_de_cuenta.Rows.Clear()

        '    If DS.Tables(DT.TableName).Rows.Count > 0 Then

        '        For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
        '            Dim MiFechaCaja As Date
        '            Dim MiFechaCaja2 As String
        '            MiFechaCaja = DS.Tables(DT.TableName).Rows(i).Item("fecha_caja")
        '            MiFechaCaja2 = MiFechaCaja.ToString("dd-MM-yyy")

        '            Dim MiFechaCheque As Date
        '            Dim MiFechaCheque2 As String
        '            MiFechaCheque = DS.Tables(DT.TableName).Rows(i).Item("fecha_cheque")
        '            MiFechaCheque2 = MiFechaCheque.ToString("dd-MM-yyy")

        '            Form_registro_de_cheques.grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("folio_cheque"), _
        '                                               MiFechaCaja2, _
        '                                                MiFechaCheque2, _
        '                                                 DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente"), _
        '                                                  DS.Tables(DT.TableName).Rows(i).Item("nro_banco"), _
        '                                                   DS.Tables(DT.TableName).Rows(i).Item("nombre_banco"), _
        '                                                    DS.Tables(DT.TableName).Rows(i).Item("nro_cheque"), _
        '                                                     DS.Tables(DT.TableName).Rows(i).Item("monto_cheque"))
        '        Next
        '    End If
        'End If







        If radio_rango_fechas.Checked = True Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion

            SC.CommandText = "select * from cheques, bancos  where  fecha_caja >='" & (mifecha2) & "' and fecha_caja <= '" & (mifecha4) & "' and bancos.codigo_banco=cheques.nro_banco order by folio_cheque asc"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            Form_registro_de_cheques.grilla_estado_de_cuenta.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim MiFechaCaja As Date
                    Dim MiFechaCaja2 As String
                    MiFechaCaja = DS.Tables(DT.TableName).Rows(i).Item("fecha_caja")
                    MiFechaCaja2 = MiFechaCaja.ToString("dd-MM-yyy")

                    Dim MiFechaCheque As Date
                    Dim MiFechaCheque2 As String
                    MiFechaCheque = DS.Tables(DT.TableName).Rows(i).Item("fecha_cheque")
                    MiFechaCheque2 = MiFechaCheque.ToString("dd-MM-yyy")

                    Form_registro_de_cheques.grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("folio_cheque"), _
                                                       MiFechaCaja2, _
                                                        MiFechaCheque2, _
                                                         DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("nro_banco"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("nombre_banco"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("nro_cheque"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("monto_cheque"))
                Next
            End If
        End If




        If Radio_rango_cheques.Checked = True Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion

            SC.CommandText = "select * from cheques, bancos  where  fecha_cheque >='" & (mifecha2) & "' and fecha_cheque <= '" & (mifecha4) & "' and bancos.codigo_banco=cheques.nro_banco order by folio_cheque asc"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            Form_registro_de_cheques.grilla_estado_de_cuenta.Rows.Clear()

            If DS.Tables(DT.TableName).Rows.Count > 0 Then

                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    Dim MiFechaCaja As Date
                    Dim MiFechaCaja2 As String
                    MiFechaCaja = DS.Tables(DT.TableName).Rows(i).Item("fecha_caja")
                    MiFechaCaja2 = MiFechaCaja.ToString("dd-MM-yyy")

                    Dim MiFechaCheque As Date
                    Dim MiFechaCheque2 As String
                    MiFechaCheque = DS.Tables(DT.TableName).Rows(i).Item("fecha_cheque")
                    MiFechaCheque2 = MiFechaCheque.ToString("dd-MM-yyy")

                    Form_registro_de_cheques.grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("folio_cheque"), _
                                                       MiFechaCaja2, _
                                                        MiFechaCheque2, _
                                                         DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("nro_banco"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("nombre_banco"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("nro_cheque"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("monto_cheque"))
                Next
            End If
        End If



    End Sub

    Private Sub Radio_fecha_cheques_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_rango_cheques.CheckedChanged
        'If radio_fecha_caja.Checked = True Then
        '    dtp_fecha_caja.Enabled = True
        '    dtp_fecha_cheque.Enabled = False
        '    dtp_desde_caja.Enabled = False
        '    dtp_hasta_caja.Enabled = False
        '    dtp_desde_cheque.Enabled = False
        '    dtp_hasta_cheque.Enabled = False
        'End If

        'If radio_fecha_cheque.Checked = True Then
        '    dtp_fecha_caja.Enabled = False
        '    dtp_fecha_cheque.Enabled = True
        '    dtp_desde_caja.Enabled = False
        '    dtp_hasta_caja.Enabled = False
        '    dtp_desde_cheque.Enabled = False
        '    dtp_hasta_cheque.Enabled = False
        'End If


        If radio_rango_fechas.Checked = True Then
            'dtp_fecha_caja.Enabled = False
            'dtp_fecha_cheque.Enabled = False
            dtp_desde_caja.Enabled = True
            dtp_hasta_caja.Enabled = True
            dtp_desde_cheque.Enabled = False
            dtp_hasta_cheque.Enabled = False
        End If

        If Radio_rango_cheques.Checked = True Then
            'dtp_fecha_caja.Enabled = False
            'dtp_fecha_cheque.Enabled = False
            dtp_desde_caja.Enabled = False
            dtp_hasta_caja.Enabled = False
            dtp_desde_cheque.Enabled = True
            dtp_hasta_cheque.Enabled = True
        End If
    End Sub




    Private Sub btn_aceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.GotFocus
        btn_aceptar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_aceptar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.LostFocus
        btn_aceptar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub
End Class