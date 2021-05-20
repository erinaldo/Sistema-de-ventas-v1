Imports CrystalDecisions.CrystalReports.Engine
Imports System.Math
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Public Class Form_archivo_dicom
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_archivo_dicom_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_archivo_dicom_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_archivo_dicom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grilla_dicom.Columns(0).Width = 250
        grilla_dicom.Columns(1).Width = 250
        grilla_dicom.Columns(2).Width = 250
        grilla_dicom.Columns(3).Width = 250
        grilla_dicom.Columns(4).Width = 250
        grilla_dicom.Columns(5).Width = 250
        grilla_dicom.Columns(6).Width = 250
        grilla_dicom.Columns(7).Width = 250
        grilla_dicom.Columns(8).Width = 250
        grilla_dicom.Columns(9).Width = 250
        grilla_dicom.Columns(10).Width = 250
        grilla_dicom.Columns(11).Width = 250
        grilla_dicom.Columns(12).Width = 250
        grilla_dicom.Columns(13).Width = 250
        grilla_dicom.Columns(14).Width = 250
        grilla_dicom.Columns(15).Width = 250
        grilla_dicom.Columns(16).Width = 250
        grilla_dicom.Columns(17).Width = 250
        grilla_dicom.Columns(18).Width = 250
        grilla_dicom.Columns(19).Width = 250
        grilla_dicom.Columns(20).Width = 250
        grilla_dicom.Columns(21).Width = 250
        grilla_dicom.Columns(22).Width = 250
        grilla_dicom.Columns(23).Width = 250
        grilla_dicom.Columns(24).Width = 250
        grilla_dicom.Columns(25).Width = 250
        grilla_dicom.Columns(26).Width = 250
        grilla_dicom.Columns(27).Width = 250
        grilla_dicom.Columns(28).Width = 250
        grilla_dicom.Columns(29).Width = 250
        grilla_dicom.Columns(30).Width = 250
        grilla_dicom.Columns(31).Width = 250

        cargar_logo()
        dtp_desde.Value = dtp_desde.Value.AddMonths(Val(-1))
        mostrar_malla()
        calcular_totales()

        btn_mostrar.Focus()
    End Sub




    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub mostrar_malla()

        fecha()

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion

        SC.CommandText = "select * from CREDITOS, CLIENTES where fecha_vencimiento >='" & (mifecha2) & "' and fecha_vencimiento <= '" & (mifecha4) & "' and creditos.saldo > '0' AND clientes.rut_cliente =creditos.rut_cliente  and creditos.convenio = '0' ORDER BY creditos.rut_cliente"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        grilla_dicom.Rows.Clear()

        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1


                'Dim MiFechaVencimiento As Date
                'MiFechaVencimiento = DS.Tables(DT.TableName).Rows(i).Item("fecha_vencimiento")
                'mifecha_vencimiento2 = MiFechaVencimiento.ToString("dd-MM-yyy")

                Dim codigo_aportante As String
                Dim rut_del_deudor As String
                Dim fecha_de_vencimiento As String
                Dim numero_del_documento As String
                Dim tipo_transaccion As String
                Dim nombre_razon_social As String
                Dim tipo_de_calle As String
                Dim nombre_de_la_calle As String
                Dim numero_de_la_calle As String
                Dim numero_del_depto_u_oficina As String
                Dim indicador_del_depto_u_oficina As String
                Dim tipo_domicilio As String
                Dim comuna As String
                Dim ciudad As String
                Dim codigo_postal As String
                Dim telefono As String
                Dim tipo_documento As String
                Dim tipo_moneda As String
                Dim monto_de_la_deuda_morosa As String
                Dim monto_de_la_acaracion_parcial As String
                Dim tipo_de_deudor As String
                Dim rut_deudor_directo As String
                Dim direccion_email_del_deudor As String
                Dim codigo_area As String
                Dim banco As String
                Dim cuenta_corriente As String
                Dim numero_del_documento_a_rectificar As String
                Dim tipo_de_documento_a_rectificar As String
                Dim tipo_de_moneda_a_rectificar As String
                Dim rut_del_deudor_a_rectificar As String
                Dim monto_de_deuda_a_rectificar As String
                Dim campo_de_relleno As String

                codigo_aportante = "218909"
                rut_del_deudor = DS.Tables(DT.TableName).Rows(i).Item("rut_cliente")
                fecha_de_vencimiento = DS.Tables(DT.TableName).Rows(i).Item("fecha_vencimiento")

                Dim MiFechaVencimiento As Date
                MiFechaVencimiento = DS.Tables(DT.TableName).Rows(i).Item("fecha_vencimiento")
                fecha_de_vencimiento = MiFechaVencimiento.ToString("yyy-MM-dd")

                fecha_de_vencimiento = Replace(fecha_de_vencimiento, "-", "")

                numero_del_documento = DS.Tables(DT.TableName).Rows(i).Item("n_creditos")
                tipo_transaccion = "1"
                nombre_razon_social = DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente")
                tipo_de_calle = ""
                nombre_de_la_calle = DS.Tables(DT.TableName).Rows(i).Item("direccion_cliente")
                numero_de_la_calle = ""
                numero_del_depto_u_oficina = ""
                indicador_del_depto_u_oficina = "10"
                tipo_domicilio = "01"
                comuna = DS.Tables(DT.TableName).Rows(i).Item("comuna_cliente")
                ciudad = DS.Tables(DT.TableName).Rows(i).Item("ciudad_cliente")
                codigo_postal = ""
                telefono = DS.Tables(DT.TableName).Rows(i).Item("telefono_cliente")
                tipo_documento = "PG"
                tipo_moneda = "$"
                monto_de_la_deuda_morosa = DS.Tables(DT.TableName).Rows(i).Item("saldo")
                monto_de_la_acaracion_parcial = ""
                tipo_de_deudor = ""
                rut_deudor_directo = ""
                direccion_email_del_deudor = ""
                codigo_area = ""
                banco = ""
                cuenta_corriente = ""
                numero_del_documento_a_rectificar = ""
                tipo_de_documento_a_rectificar = ""
                tipo_de_moneda_a_rectificar = ""
                rut_del_deudor_a_rectificar = ""
                monto_de_deuda_a_rectificar = ""
                campo_de_relleno = ""


                grilla_dicom.Rows.Add(codigo_aportante, _
                                                  rut_del_deudor, _
                                                   fecha_de_vencimiento, _
                                                    numero_del_documento, _
                                                     tipo_transaccion, _
                                                      nombre_razon_social, _
                                                       tipo_de_calle, _
                                                        nombre_de_la_calle, _
                                                         numero_de_la_calle, _
                                                          numero_del_depto_u_oficina, _
                                                           indicador_del_depto_u_oficina, _
                                                            tipo_domicilio, _
                                                             comuna, _
                                                              ciudad, _
                                                               codigo_postal, _
                                                                telefono, _
                                                                 tipo_documento, _
                                                                  tipo_moneda, _
                                                                   monto_de_la_deuda_morosa, _
                                                                    monto_de_la_acaracion_parcial, _
                                                                     tipo_de_deudor, _
                                                                      rut_deudor_directo, _
                                                                       direccion_email_del_deudor, _
                                                                        codigo_area, _
                                                                         banco, _
                                                                          cuenta_corriente, _
                                                                           numero_del_documento_a_rectificar, _
                                                                            tipo_de_documento_a_rectificar, _
                                                                             tipo_de_moneda_a_rectificar, _
                                                                              rut_del_deudor_a_rectificar, _
                                                                               monto_de_deuda_a_rectificar, _
                                                                                campo_de_relleno)
            Next

        End If

        If grilla_dicom.Rows.Count <> 0 Then
            If grilla_dicom.Columns(0).Width = 250 Then
                grilla_dicom.Columns(0).Width = 249
            Else
                grilla_dicom.Columns(0).Width = 250
            End If
        End If

    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        mostrar_malla()
        calcular_totales()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        grilla_dicom.Rows.Clear()
        txt_total_millar.Text = ""
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""



        If grilla_dicom.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            dtp_desde.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_dicom, save.FileName)
        End If


    End Sub


    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)

        Dim xlApp As Object = CreateObject("Excel.Application")
        'crear una nueva hoja de calculo 
        Dim xlWB As Object = xlApp.WorkBooks.add
        Dim xlWS As Object = xlWB.WorkSheets(1)

        'exportamos los caracteres de las columnas 
        For c As Integer = 0 To grilla_dicom.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_dicom.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_dicom.RowCount - 1
            For c As Integer = 0 To grilla_dicom.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_dicom.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub











    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            grilla_dicom.Rows.Clear()
            txt_total_millar.Text = ""
        End If
    End Sub


    Sub calcular_totales()

        Dim totalgrilla As Long

        '//Calcular el descuento
        txt_total.Text = 0
        For i = 0 To grilla_dicom.Rows.Count - 1
            totalgrilla = Val(grilla_dicom.Rows(i).Cells(18).Value.ToString)
            txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        Next

        If txt_total.Text = "" Or txt_total.Text = "0" Then
            txt_total_millar.Text = "0"
        Else
            txt_total_millar.Text = Format(Int(txt_total.Text), "###,###,###")
        End If

    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        grilla_dicom.Rows.Clear()
        txt_total_millar.Text = ""
    End Sub
End Class