Public Class Form_control_caf
    Dim cod_doc As Integer

    Private Sub Form_control_caf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_documentos()
    End Sub


    Sub Carga_documentos()

        cmb_Documento_caf.Items.Clear()
        cmb_Documento_caf.Items.Add("33-FACTURA ELECTRONICA")
        cmb_Documento_caf.Items.Add("34-FACTURA EXENTA ELECTRONICA")
        cmb_Documento_caf.Items.Add("39-BOLETA ELECTRONICA")
        cmb_Documento_caf.Items.Add("41-BOLETA EXENTA ELECTRONICA")
        cmb_Documento_caf.Items.Add("52-GUIA DE DESPACHO ELECTRONICA")
        cmb_Documento_caf.Items.Add("56-NOTA DE DEBITO ELECTRONICA")
        cmb_Documento_caf.Items.Add("61-NOTA DE CREDITO ELECTRONICA")
        cmb_Documento_caf.Text = "33-FACTURA ELECTRONICA"

    End Sub

    Sub Inicia_caf()

        cmb_Documento_caf.Enabled = False
        txt_Caf.Clear()
        txt_Desde_caf.Clear()
        txt_Hasta_caf.Clear()
        txt_Fecha_caf.Clear()
        txt_Rut_caf.Clear()
        txt_Razon_social_caf.Clear()
        txt_Fecha_vencimiento_caf.Clear()
        Carga_lista_caf_por_documento()

    End Sub


    Sub Carga_lista_caf_por_documento()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from caf where codigo_documento='" & (cod_doc) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        dgv_Documentos_caf.Rows.Clear()
        dgv_Documentos_caf.Columns.Clear()
        dgv_Documentos_caf.Columns.Add("", "DOCUMENTO")
        dgv_Documentos_caf.Columns.Add("", "DESDE")
        dgv_Documentos_caf.Columns.Add("", "HASTA")
        dgv_Documentos_caf.Columns.Add("", "VENCIMIENTO")

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                dgv_Documentos_caf.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("codigo_documento"),
                                             DS.Tables(DT.TableName).Rows(i).Item("desde"),
                                              DS.Tables(DT.TableName).Rows(i).Item("hasta"),
                                               DS.Tables(DT.TableName).Rows(i).Item("fecha_vencimiento"))
            Next
        End If

        If dgv_Documentos_caf.Rows.Count <> 0 Then
            If dgv_Documentos_caf.Columns(0).Width = 150 Then
                dgv_Documentos_caf.Columns(0).Width = 149
            Else
                dgv_Documentos_caf.Columns(0).Width = 150
            End If
            dgv_Documentos_caf.Columns(1).Width = 100
            dgv_Documentos_caf.Columns(2).Width = 100
            dgv_Documentos_caf.Columns(3).Width = 100

            dgv_Documentos_caf.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgv_Documentos_caf.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgv_Documentos_caf.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgv_Documentos_caf.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        End If
    End Sub


    Sub Carga_XML(ByVal ruta As String)




        Try

            Dim DS As New DataSet()

            DS.ReadXml(ruta)
            ' Dim td As String = DS.Tables["DA"].Rows[0]["TD"].ToString()
            Dim td As String = DS.Tables("DA").Rows(0).Item("TD").ToString()

            If (td = cod_doc) Then

                txt_Rut_caf.Text = DS.Tables("DA").Rows(0).Item("RE").ToString()
                txt_Razon_social_caf.Text = DS.Tables("DA").Rows(0).Item("RS").ToString()
                txt_Desde_caf.Text = DS.Tables("RNG").Rows(0).Item("D").ToString()
                txt_Hasta_caf.Text = DS.Tables("RNG").Rows(0).Item("H").ToString()
                txt_Fecha_caf.Text = DS.Tables("DA").Rows(0).Item("FA").ToString()

                Dim FechaEmisionDate As Date
                Dim FechaEmisionText As Date
                FechaEmisionDate = txt_Fecha_caf.Text
                FechaEmisionText = FechaEmisionDate.ToString("yyy-MM-dd")
                txt_Fecha_caf.Text = FechaEmisionText

                Dim FechaVencimientoDate As Date
                Dim FechaVencimientoText As Date
                FechaVencimientoDate = FechaEmisionDate.AddMonths(6)
                FechaVencimientoText = FechaVencimientoDate.ToString("yyy-MM-dd")

                txt_Fecha_vencimiento_caf.Text = FechaVencimientoText

                '_caf = New Caf_objeto()
                '_caf.Desde = Convert.ToInt32(DS.Tables["RNG"].Rows[0]["D"].ToString())
                '    _caf.Hasta = Convert.ToInt32(DS.Tables["RNG"].Rows[0]["H"].ToString())
                '    _caf.Archivo = txt_Caf.Text
                '_caf.Codigo_documento = Convert.ToInt32(DS.Tables["DA"].Rows[0]["TD"].ToString())

            Else

                MessageBox.Show("El Archivo, no corresponde al Documento Seleccionado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            cmb_Documento_caf.Enabled = False




        Catch ex As Exception
            MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmb_Documento_caf.Enabled = True
        End Try

    End Sub

    Private Sub btn_Cargar_caf_Click(sender As Object, e As EventArgs) Handles btn_Cargar_caf.Click
        Inicia_caf()



        Dim stRuta As String = ""
        Dim Dir As String
        Dim archivo As New OpenFileDialog()
        With archivo
            .Title = "Seleccionar archivos"
            .Filter = "Archivos XML(*.xml)| *.xml"
            .InitialDirectory = "C:\SistemaVenta\Electronica\CAF"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dir = .FileName
                txt_Caf.Text = archivo.SafeFileName
                Carga_XML(Dir)


                conexion.Close()
                Consultas_SQL("select * from caf where codigo_documento='" & (cod_doc) & "' and desde= '" & (txt_Desde_caf.Text) & "' and hasta= '" & (txt_Hasta_caf.Text) & "'")
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    MsgBox("El Archivo Caf ya fue cargado Anteriormente", 0 + 16, "ERROR")
                    Inicia_caf()
                    Exit Sub
                End If


            End If
        End With

    End Sub

    Private Sub btn_inicia_caf_Click(sender As Object, e As EventArgs) Handles btn_inicia_caf.Click
        Inicia_caf()
    End Sub

    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click

        If cmb_Documento_caf.Text = "" Then
            MsgBox("CAMPO DOCUMENTO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            cmb_Documento_caf.Focus()
            Exit Sub
        End If

        If txt_Caf.Text = "-" Then
            MsgBox("CAMPO CAF VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_Caf.Focus()
            Exit Sub
        End If

        If txt_Rut_caf.Text = "" Then
            MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_Caf.Focus()
            Exit Sub
        End If

        If txt_Razon_social_caf.Text = "" Then
            MsgBox("CAMPO RAZON SOCIAL VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_Caf.Focus()
            Exit Sub
        End If

        If txt_Desde_caf.Text = "" Then
            MsgBox("CAMPO DESDE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_Desde_caf.Focus()
            Exit Sub
        End If

        If txt_Hasta_caf.Text = "" Then
            MsgBox("CAMPO HASTA VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_Hasta_caf.Focus()
            Exit Sub
        End If

        Dim mifecha_desde As Date
        Dim fecha_desde As String
        mifecha_desde = txt_Fecha_caf.Text
        fecha_desde = mifecha_desde.ToString("yyy-MM-dd")

        Dim mifecha_hasta As Date
        Dim fecha_hasta As String
        mifecha_hasta = txt_Fecha_vencimiento_caf.Text
        fecha_hasta = mifecha_hasta.ToString("yyy-MM-dd")

        SC.Connection = conexion
        SC.CommandText = "INSERT INTO caf (codigo_documento, archivo, desde, hasta, fecha, fecha_vencimiento) VALUES  ('" & (cod_doc) & "','" & (txt_Caf.Text) & "','" & (txt_Desde_caf.Text) & "','" & (txt_Hasta_caf.Text) & "','" & (fecha_desde) & "','" & (fecha_hasta) & "')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        MsgBox("CAF INGRESADO CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

    End Sub

    Sub Guardar_caf()

    End Sub

    Private Sub cmb_Documento_caf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Documento_caf.SelectedIndexChanged

        If cmb_Documento_caf.Text = "33-FACTURA ELECTRONICA" Then
            cod_doc = 33
        End If
        If cmb_Documento_caf.Text = "34-FACTURA EXENTA ELECTRONICA" Then
            cod_doc = 34
        End If
        If cmb_Documento_caf.Text = "39-BOLETA ELECTRONICA" Then
            cod_doc = 39
        End If
        If cmb_Documento_caf.Text = "41-BOLETA EXENTA ELECTRONICA" Then
            cod_doc = 41
        End If
        If cmb_Documento_caf.Text = "52-GUIA DE DESPACHO ELECTRONICA" Then
            cod_doc = 52
        End If
        If cmb_Documento_caf.Text = "56-NOTA DE DEBITO ELECTRONICA" Then
            cod_doc = 56
        End If
        If cmb_Documento_caf.Text = "61-NOTA DE CREDITO ELECTRONICA" Then
            cod_doc = 61
        End If

        Carga_lista_caf_por_documento()
    End Sub
End Class