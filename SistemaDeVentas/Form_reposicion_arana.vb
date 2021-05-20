Public Class Form_reposicion_arana
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_reposicion_arana_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_reposicion_arana_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_reposicion_arana_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        grilla_documento.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)
        llenar_combo_familia()
        Me.Width = 1024
        Me.Height = 728
        Centrar()
    End Sub

    Public Sub Centrar()
        Dim tamaño As Rectangle = My.Computer.Screen.Bounds
        Dim posicionX As Integer = (tamaño.Width - Me.Width) \ 2
        Dim posicionY As Integer = (tamaño.Height - Me.Height) \ 2
        Me.Location = New Point(posicionX, posicionY - 20)
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub fecha()
        'Dim mifecha As Date
        'mifecha = dtp_desde.Text
        'mifecha2 = mifecha.ToString("yyy-MM-dd")

        'Dim mifecha3 As Date
        'mifecha3 = dtp_hasta.Text
        'mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub

    Sub mostrar_malla()
        Dim sub_familia_2 As String
        Dim sub_familia_2_anterior As String = ""
        Dim stock_familia_2 As String = ""
        Dim consulta As String

        consulta = "SELECT subfamilia_dos.cod_auto as 'COD. SB2', subfamilia_dos.nombre_subfamilia as 'SUB FAMILIA 2', m as M, o as O, SUM(cantidad) as 'STOCK', cod_producto as 'PRODUCTO', nombre as 'DESCRIPCION', numero_tecnico  as 'NUMERO TECNICO', aplicacion as 'APLICACION', cantidad as 'CANTIDAD', precio as 'PRECIO', nombre_proveedor as 'NOMBRE PROVEEDOR', cantidad_ultima_compra as 'CANT. ULT. COMP.', ultima_compra as 'ULT. COMPRA', costo as 'COSTO' FROM productos, subfamilia_dos, proveedores where productos.subfamilia_dos=subfamilia_dos.cod_auto and productos.proveedor=proveedores.rut_proveedor and productos.subfamilia_dos<>'0' and subfamilia_dos.m <> '-99999'"

        If Combo_familia.Text <> "-" Then
            consulta = consulta & "  and productos.familia='" & (txt_codigo_familia.Text) & "'"
        End If

        If Combo_subfamilia.Text <> "-" Then
            consulta = consulta & " and productos.subfamilia='" & (txt_codigo_subfamilia.Text) & "'"
        End If

        If Combo_subfamilia_2.Text <> "-" Then
            consulta = consulta & " and productos.subfamilia_dos='" & (txt_codigo_subfamilia_2.Text) & "'"
        End If

        consulta = consulta & " group by cod_producto order by nombre_subfamilia"


        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = consulta
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_documento.Rows.Clear()
        grilla_documento.Columns.Clear()
        grilla_documento.Columns.Add("", "COD. SB2")
        grilla_documento.Columns.Add("", "SUB FAMILIA 2")
        grilla_documento.Columns.Add("", "STOCK")
        grilla_documento.Columns.Add("", "M")
        grilla_documento.Columns.Add("", "O")
        grilla_documento.Columns.Add("", "P")
        grilla_documento.Columns.Add("", "PRODUCTO")
        grilla_documento.Columns.Add("", "DESCRIPCION")
        grilla_documento.Columns.Add("", "NUMERO TECNICO")
        grilla_documento.Columns.Add("", "APLICACION")
        grilla_documento.Columns.Add("", "CANTIDAD")
        grilla_documento.Columns.Add("", "PRECIO")
        grilla_documento.Columns.Add("", "NOMBRE PROVEEDOR")
        grilla_documento.Columns.Add("", "CANT. ULT. COMP.")
        grilla_documento.Columns.Add("", "ULT. COMPRA")
        grilla_documento.Columns.Add("", "COSTO")
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                sub_familia_2 = DS.Tables(DT.TableName).Rows(i).Item("SUB FAMILIA 2")

                If sub_familia_2 = sub_familia_2_anterior Then
                    grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("COD. SB2"), _
                                              "", _
                                               "", _
                                                "", _
                                                 "", _
                                                  "", _
                                                   DS.Tables(DT.TableName).Rows(i).Item("PRODUCTO"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("DESCRIPCION"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("NUMERO TECNICO"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("NOMBRE PROVEEDOR"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("CANT. ULT. COMP."), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("COSTO"))
                Else
                    'grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("COD. SB2"), _
                    '                           DS.Tables(DT.TableName).Rows(i).Item("SUB FAMILIA 2"), _
                    '                                     DS.Tables(DT.TableName).Rows(i).Item("STOCK"), _
                    '                                      DS.Tables(DT.TableName).Rows(i).Item("M"), _
                    '                                       DS.Tables(DT.TableName).Rows(i).Item("O"), _
                    '                                        "", _
                    '                                         DS.Tables(DT.TableName).Rows(i).Item("PRODUCTO"), _
                    '                                          DS.Tables(DT.TableName).Rows(i).Item("DESCRIPCION"), _
                    '                                           DS.Tables(DT.TableName).Rows(i).Item("NUMERO TECNICO"), _
                    '                                            DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                    '                                             DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                    '                                              DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                    '                                               DS.Tables(DT.TableName).Rows(i).Item("NOMBRE PROVEEDOR"), _
                    '                                                DS.Tables(DT.TableName).Rows(i).Item("CANT. ULT. COMP."), _
                    '                                                 DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                    '                                                  DS.Tables(DT.TableName).Rows(i).Item("COSTO"))


                    grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("COD. SB2"), _
                               DS.Tables(DT.TableName).Rows(i).Item("SUB FAMILIA 2"), _
                                         DS.Tables(DT.TableName).Rows(i).Item("STOCK"), _
                                          DS.Tables(DT.TableName).Rows(i).Item("M"), _
                                           DS.Tables(DT.TableName).Rows(i).Item("O"), _
                                            "", _
                                             "", _
                                              "", _
                                               "", _
                                                "", _
                                                 "", _
                                                  "", _
                                                   "", _
                                                    "", _
                                                     "", _
                                                      "")
                    grilla_documento.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("COD. SB2"), _
                                              "", _
                                               "", _
                                                "", _
                                                 "", _
                                                  "", _
                                                   DS.Tables(DT.TableName).Rows(i).Item("PRODUCTO"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("DESCRIPCION"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("NUMERO TECNICO"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("PRECIO"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("NOMBRE PROVEEDOR"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("CANT. ULT. COMP."), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("ULT. COMPRA"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("COSTO"))

                End If

                sub_familia_2_anterior = DS.Tables(DT.TableName).Rows(i).Item("SUB FAMILIA 2")

            Next
        End If

        If grilla_documento.Rows.Count <> 0 Then
            If grilla_documento.Columns(0).Width = 150 Then
                grilla_documento.Columns(0).Width = 149
            Else
                grilla_documento.Columns(0).Width = 150
            End If
            grilla_documento.Columns(1).Width = 150
            grilla_documento.Columns(2).Width = 150
            grilla_documento.Columns(3).Width = 150
            grilla_documento.Columns(4).Width = 150
            grilla_documento.Columns(5).Width = 150
            grilla_documento.Columns(6).Width = 150
            grilla_documento.Columns(7).Width = 250
            grilla_documento.Columns(8).Width = 250
            grilla_documento.Columns(9).Width = 250
            grilla_documento.Columns(10).Width = 150
            grilla_documento.Columns(11).Width = 150
            grilla_documento.Columns(12).Width = 250
            grilla_documento.Columns(13).Width = 150
            grilla_documento.Columns(14).Width = 150
            grilla_documento.Columns(15).Width = 150

            grilla_documento.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_documento.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_documento.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_documento.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_documento.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_documento.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_documento.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_documento.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_documento.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
    End Sub

    Sub llenar_combo_familia()
        combo_familia.Items.Clear()
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion
        SC3.CommandText = "select * from familia order by nombre_familia"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        Combo_familia.Items.Add("-")
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                combo_familia.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_familia"))
            Next
        End If
        'Combo_familia.SelectedItem = "SIN FAMILIA"
        Combo_familia.SelectedItem = "-"
        conexion.Close()
    End Sub

    Sub mostrar_codigo_familia()
        If Combo_familia.Text <> "-" Then
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            SC2.CommandText = "select * from familia where nombre_familia ='" & (Combo_familia.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                txt_codigo_familia.Text = DS2.Tables(DT2.TableName).Rows(0).Item("codigo")
            End If
            conexion.Close()
        Else
            txt_codigo_familia.Text = ""
        End If
    End Sub

    Sub llenar_combo_subfamilia()
        If Combo_familia.Text <> "-" Then
            conexion.Close()
            Combo_subfamilia.Items.Clear()
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion
            SC3.CommandText = "select * from subfamilia where codigo_familia='" & (txt_codigo_familia.Text) & "' order by nombre_subfamilia"
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            Combo_subfamilia.Items.Add("SIN SUB FAMILIA")
            If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                    Combo_subfamilia.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_subfamilia"))
                Next
            End If
            conexion.Close()
            Combo_subfamilia.Items.Add("-")
            Combo_subfamilia.SelectedItem = "-"
        Else
            Combo_subfamilia.Items.Clear()
            Combo_subfamilia.Items.Add("-")
            Combo_subfamilia.SelectedItem = "-"
        End If
    End Sub

    Sub mostrar_codigo_subfamilia()
        If Combo_subfamilia.Text <> "-" Then
            conexion.Close()
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion
            SC3.CommandText = "select * from subfamilia where nombre_subfamilia ='" & (Combo_subfamilia.Text) & "'"
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                txt_codigo_subfamilia.Text = DS3.Tables(DT3.TableName).Rows(0).Item("cod_auto")
            End If
            conexion.Close()
        Else
            txt_codigo_subfamilia.Text = ""
        End If
    End Sub

    Sub mostrar_codigo_subfamilia2()
        If Combo_subfamilia_2.Text <> "-" Then
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            SC2.CommandText = "select * from subfamilia_dos where nombre_subfamilia ='" & (Combo_subfamilia_2.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                txt_codigo_subfamilia_2.Text = DS2.Tables(DT2.TableName).Rows(0).Item("cod_auto")
            End If
            conexion.Close()
        Else
            txt_codigo_subfamilia_2.Text = ""
        End If
    End Sub

    Sub llenar_combo_subfamilia2()
        If Combo_subfamilia.Text <> "-" Then
            conexion.Close()
            Combo_subfamilia_2.Items.Clear()
            DS3.Tables.Clear()
            DT3.Rows.Clear()
            DT3.Columns.Clear()
            DS3.Clear()
            conexion.Open()
            SC3.Connection = conexion
            SC3.CommandText = "select * from subfamilia_dos where codigo_subfamilia='" & (txt_codigo_subfamilia.Text) & "' order by nombre_subfamilia"
            DA3.SelectCommand = SC3
            DA3.Fill(DT3)
            DS3.Tables.Add(DT3)
            Combo_subfamilia_2.Items.Add("SIN SUB FAMILIA DOS")
            If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
                For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                    Combo_subfamilia_2.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_subfamilia"))
                Next
            End If
            conexion.Close()
            Combo_subfamilia_2.Items.Add("-")
            Combo_subfamilia_2.SelectedItem = "-"
        Else
            Combo_subfamilia_2.Items.Clear()
            Combo_subfamilia_2.Items.Add("-")
            Combo_subfamilia_2.SelectedItem = "-"
        End If
    End Sub

    Sub mostrar_subfamilia_dos()
        If txt_codigo_subfamilia_2.Text <> "" And txt_codigo_subfamilia_2.Text <> "-" Then
            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()

            SC2.Connection = conexion
            SC2.CommandText = "select * from subfamilia_dos where cod_auto ='" & (txt_codigo_subfamilia_2.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)

            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                Combo_subfamilia_2.SelectedItem = DS2.Tables(DT2.TableName).Rows(0).Item("nombre_subfamilia")
            End If

            conexion.Close()
        End If
    End Sub


    Private Sub Combo_familia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_familia.SelectedIndexChanged
        mostrar_codigo_familia()
        llenar_combo_subfamilia()
    End Sub

    Private Sub Combo_subfamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_subfamilia.SelectedIndexChanged
        mostrar_codigo_subfamilia()
        llenar_combo_subfamilia2()
    End Sub

    Private Sub Combo_subfamilia_2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_subfamilia_2.SelectedIndexChanged
        mostrar_codigo_subfamilia2()
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        grilla_documento.DataSource = Nothing

        mostrar_malla()
        stock_familia()
        pintar_y_esconder()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""

        If grilla_documento.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            Combo_familia.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_documento, save.FileName)
        End If
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)

        Dim xlApp As Object = CreateObject("Excel.Application")
        'crear una nueva hoja de calculo 
        Dim xlWB As Object = xlApp.WorkBooks.add
        Dim xlWS As Object = xlWB.WorkSheets(1)

        'exportamos los caracteres de las columnas 
        For c As Integer = 0 To grilla_documento.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_documento.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_documento.RowCount - 1
            For c As Integer = 0 To grilla_documento.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_documento.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub


    Sub stock_familia()
        Dim Subfamilia As String = ""
        Dim Subfamilia_anterior As String = ""
        Dim stock_subfamilia As Integer
        Dim nueva_posicion As Integer = 0
        Dim stock_total As Integer


        For i = 0 To grilla_documento.Rows.Count - 1
            Subfamilia = grilla_documento.Rows(i).Cells(0).Value.ToString

            'If Subfamilia = "1594" Then
            '    MsgBox("ffff")
            'End If
            Try
                stock_subfamilia = grilla_documento.Rows(i).Cells(10).Value.ToString
            Catch e As InvalidCastException
                stock_subfamilia = "0"
            End Try

            If Subfamilia = "593" Then
                Subfamilia = grilla_documento.Rows(i).Cells(0).Value.ToString
            End If

            If i = 0 Then
                Subfamilia_anterior = grilla_documento.Rows(i).Cells(0).Value.ToString
            End If

            If Subfamilia = Subfamilia_anterior Then
                stock_total = stock_total + stock_subfamilia
            Else
                grilla_documento.Rows(nueva_posicion).Cells(2).Value = stock_total
                stock_total = stock_subfamilia
                nueva_posicion = i
            End If

            Subfamilia_anterior = grilla_documento.Rows(i).Cells(0).Value.ToString

        Next

        Try
            grilla_documento.Rows(nueva_posicion).Cells(2).Value = stock_total
        Catch
        End Try

    End Sub

    Sub familia_visible()
        Dim Subfamilia As String = ""
        Dim Subfamilia_anterior As String = ""
        Dim nueva_posicion As Integer = 0
        Dim posicion_actual As Integer = 0

        posicion_actual = grilla_documento.CurrentCell.RowIndex

        Subfamilia = grilla_documento.Rows(posicion_actual).Cells(0).Value.ToString

        nueva_posicion = grilla_documento.CurrentCell.RowIndex + 1


        Subfamilia_anterior = grilla_documento.Rows(nueva_posicion).Cells(0).Value.ToString
        'If posicion_actual = grilla_documento.CurrentCell.RowIndex Then
        '    Subfamilia_anterior = grilla_documento.Rows(nueva_posicion).Cells(0).Value.ToString
        'End If

        While Subfamilia = Subfamilia_anterior



            If grilla_documento.Rows(nueva_posicion).Visible = False Then
                grilla_documento.Rows(nueva_posicion).Visible = True
            Else
                grilla_documento.Rows(nueva_posicion).Visible = False
            End If

            nueva_posicion = nueva_posicion + 1


            Try
                Subfamilia_anterior = grilla_documento.Rows(nueva_posicion).Cells(0).Value.ToString
            Catch e As ArgumentOutOfRangeException
                Exit Sub
            End Try


        End While




    End Sub

    Sub pintar_y_esconder()
        'Dim Subfamilia As String = ""

        'For i = 0 To grilla_documento.Rows.Count - 1
        '    Subfamilia = grilla_documento.Rows(i).Cells(1).Value.ToString

        '    If Subfamilia = "" Then
        '        grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
        '        grilla_documento.Rows(i).Visible = False
        '    End If
        'Next



        Dim subfamilia As String = ""
        Dim stock_subfamilia As Integer
        Dim subfamilia_m As Integer
        Dim subfamilia_o As Integer
        Dim cantidad_por_pedir As String = ""

        For i = 0 To grilla_documento.Rows.Count - 1
            subfamilia = grilla_documento.Rows(i).Cells(1).Value.ToString

            Try
                stock_subfamilia = grilla_documento.Rows(i).Cells(2).Value.ToString
            Catch
                stock_subfamilia = 0
            End Try

            Try
                subfamilia_m = grilla_documento.Rows(i).Cells(3).Value.ToString
            Catch
                subfamilia_m = 0
            End Try

            Try
                subfamilia_o = grilla_documento.Rows(i).Cells(4).Value.ToString
            Catch
                subfamilia_o = 0
            End Try

            'If subfamilia <> "" Then
            If stock_subfamilia <= subfamilia_m Then
                grilla_documento.Rows(i).Cells(5).Value = subfamilia_o - stock_subfamilia
            Else
                grilla_documento.Rows(i).Cells(5).Value = "0"
            End If
            'End If

            If subfamilia <> "" Then
                cantidad_por_pedir = grilla_documento.Rows(i).Cells(5).Value
            End If

            If subfamilia = "" Then
                grilla_documento.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
                If Check_expandir_todo.Checked = True Then
                    grilla_documento.Rows(i).Visible = True
                Else
                    grilla_documento.Rows(i).Visible = False
                End If
            End If

            If Check_mostrar_solo_por_pedir.Checked = True Then
                If cantidad_por_pedir = "0" Then
                    grilla_documento.Rows(i).Visible = False
                End If
            End If
        Next
    End Sub

    Private Sub grilla_documento_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_documento.DoubleClick
        familia_visible()
    End Sub

    Private Sub grilla_documento_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_documento.CellContentClick

    End Sub














    Sub expandir_todo()
        Dim Subfamilia As String = ""
        Dim Subfamilia_anterior As String = ""
        Dim nueva_posicion As Integer = 0

        For i = 0 To grilla_documento.Rows.Count - 1
            Subfamilia = grilla_documento.Rows(i).Cells(1).Value.ToString
            Subfamilia = grilla_documento.Rows(i).Cells(0).Value.ToString
            nueva_posicion = i + 1

            Try
                Subfamilia_anterior = grilla_documento.Rows(nueva_posicion).Cells(0).Value.ToString
            Catch e As ArgumentOutOfRangeException
                Exit Sub
            End Try

            If Subfamilia = Subfamilia_anterior Then
                If grilla_documento.Rows(nueva_posicion).Visible = False Then
                    grilla_documento.Rows(nueva_posicion).Visible = True
                Else
                    grilla_documento.Rows(nueva_posicion).Visible = False
                End If
            End If

            Try
                Subfamilia_anterior = grilla_documento.Rows(nueva_posicion).Cells(0).Value.ToString
            Catch e As ArgumentOutOfRangeException
                Exit Sub
            End Try
        Next
    End Sub

  

    Private Sub Check_codigo_subfamilia2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_codigo_subfamilia2.CheckedChanged
        lbl_mensaje.Visible = True
        Me.Enabled = False
        If grilla_documento.Rows.Count <> 0 Then
            If grilla_documento.Columns(0).Visible = True Then
                grilla_documento.Columns(0).Visible = False
            Else
                grilla_documento.Columns(0).Visible = True
            End If
        End If
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Sub mostrar_solo_por_pedir()
        Dim valor_p As String = ""
        Dim subfamilia As String = ""
        For i = 0 To grilla_documento.Rows.Count - 1
            valor_p = grilla_documento.Rows(i).Cells(5).Value.ToString
            subfamilia = grilla_documento.Rows(i).Cells(1).Value.ToString

            If subfamilia <> "" Then
                If valor_p = "0" Then
                    If grilla_documento.Rows(i).Visible = False Then
                        grilla_documento.Rows(i).Visible = True
                    Else
                        grilla_documento.Rows(i).Visible = False
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub Check_expandir_todo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_expandir_todo.CheckedChanged
        'lbl_mensaje.Visible = True
        'Me.Enabled = False
        'expandir_todo()
        'lbl_mensaje.Visible = False
        'Me.Enabled = True
        grilla_documento.Columns.Clear()
    End Sub

    Private Sub Check_mostrar_solo_por_pedir_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_mostrar_solo_por_pedir.CheckedChanged
        'lbl_mensaje.Visible = True
        'Me.Enabled = False
        'mostrar_solo_por_pedir()
        'lbl_mensaje.Visible = False
        'Me.Enabled = True
        grilla_documento.Columns.Clear()
    End Sub

    Private Sub lbl_mensaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_mensaje.Click

    End Sub
End Class