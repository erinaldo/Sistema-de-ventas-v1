Public Class Form_venta_esperada_por_familia
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_venta_esperada_por_familia_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_venta_esperada_por_familia_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_venta_esperada_por_familia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        grilla_libro_compras.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)
        'txt_precio.Text = ""
        'txt_costo.Text = ""
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

    Sub mostrar_malla_familia()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "SELECT familia.nombre_familia AS FAMILIA, sum(cantidad) AS CANTIDAD,sum(costo) AS COSTO,sum(precio) AS PRECIO FROM productos, familia where productos.activo='SI' and productos.cantidad > '0' and productos.familia=familia.codigo group by productos.familia;"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_libro_compras.Rows.Clear()
        grilla_libro_compras.Columns.Clear()
        grilla_libro_compras.Columns.Add("", "FAMILIA")
        grilla_libro_compras.Columns.Add("", "CANTIDAD")
        grilla_libro_compras.Columns.Add("", "COSTO")
        grilla_libro_compras.Columns.Add("", "PRECIO")
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_libro_compras.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"), _
                                                "", _
                                                 "")
            Next
        End If




        Dim nombre_familia As String
        Dim codigo_familia As String = ""
        Dim cantidad As String
        Dim costo As String = ""
        Dim precio As String = ""

        For i = 0 To grilla_libro_compras.Rows.Count - 1
            nombre_familia = grilla_libro_compras.Rows(i).Cells(0).Value.ToString
            cantidad = grilla_libro_compras.Rows(i).Cells(1).Value.ToString

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select codigo as codigo from familia where nombre_familia='" & (nombre_familia) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                codigo_familia = DS.Tables(DT.TableName).Rows(0).Item("codigo")
            End If
            conexion.Close()


            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select sum(costo * cantidad) AS COSTO FROM productos where productos.activo='SI' and productos.cantidad > '0' and familia='" & (codigo_familia) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    costo = DS.Tables(DT.TableName).Rows(0).Item("COSTO")
                End If
            Catch err As InvalidCastException
                costo = "0"
                Exit Sub
            End Try
            conexion.Close()

            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            Try
                SC.Connection = conexion
                SC.CommandText = "select sum(precio * cantidad) AS PRECIO FROM productos where productos.activo='SI' and productos.cantidad > '0' and familia='" & (codigo_familia) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    precio = DS.Tables(DT.TableName).Rows(0).Item("PRECIO")
                End If
            Catch err As InvalidCastException
                precio = "0"
                Exit Sub
            End Try
            conexion.Close()

            grilla_libro_compras.Rows(i).Cells(2).Value = costo
            grilla_libro_compras.Rows(i).Cells(3).Value = precio
        Next

        If grilla_libro_compras.Rows.Count <> 0 Then
            If grilla_libro_compras.Columns(0).Width = 336 Then
                grilla_libro_compras.Columns(0).Width = 335
            Else
                grilla_libro_compras.Columns(0).Width = 336
            End If
            grilla_libro_compras.Columns(1).Width = 150
            grilla_libro_compras.Columns(2).Width = 150
            grilla_libro_compras.Columns(3).Width = 150
            grilla_libro_compras.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        fecha()
        mostrar_malla_familia()
        calcular_totales()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        If grilla_libro_compras.Rows.Count = 0 Then
            btn_mostrar.Focus()
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_libro_compras, save.FileName)
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
        For c As Integer = 0 To grilla_libro_compras.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_libro_compras.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_libro_compras.RowCount - 1
            For c As Integer = 0 To grilla_libro_compras.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_libro_compras.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            grilla_libro_compras.Rows.Clear()
            grilla_libro_compras.Columns.Clear()
            txt_costo.Text = ""
            txt_precio.Text = ""
        End If

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
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

    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grilla_libro_compras.Rows.Clear()
        txt_costo.Text = ""
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Sub calcular_totales()

        Dim totalcantidad As Long
        Dim totalcosto As Long
        Dim totalprecio As Long
        Dim costo As String
        Dim precio As String

        txt_cantidad.Text = 0
        For i = 0 To grilla_libro_compras.Rows.Count - 1
            totalcantidad = Val(grilla_libro_compras.Rows(i).Cells(1).Value.ToString)
            txt_cantidad.Text = Val(txt_cantidad.Text) + Val(totalcantidad)
        Next

        txt_costo.Text = 0
        For i = 0 To grilla_libro_compras.Rows.Count - 1
            totalcosto = Val(grilla_libro_compras.Rows(i).Cells(2).Value.ToString)
            txt_costo.Text = Val(txt_costo.Text) + Val(totalcosto)
        Next

        txt_precio.Text = 0
        For i = 0 To grilla_libro_compras.Rows.Count - 1
            totalprecio = Val(grilla_libro_compras.Rows(i).Cells(3).Value.ToString)
            txt_precio.Text = Val(txt_precio.Text) + Val(totalprecio)
        Next

        txt_familia.Text = grilla_libro_compras.Rows.Count


        If txt_costo.Text = "" Or txt_costo.Text = "0" Then
            txt_costo.Text = "0"
        Else
            txt_costo.Text = Format(Int(txt_costo.Text), "###,###,###")
        End If

        If txt_precio.Text = "" Or txt_precio.Text = "0" Then
            txt_precio.Text = "0"
        Else
            txt_precio.Text = Format(Int(txt_precio.Text), "###,###,###")
        End If

        If txt_cantidad.Text = "" Or txt_cantidad.Text = "0" Then
            txt_cantidad.Text = "0"
        Else
            txt_cantidad.Text = Format(Int(txt_cantidad.Text), "###,###,###")
        End If





        For i = 0 To grilla_libro_compras.Rows.Count - 1
            costo = grilla_libro_compras.Rows(i).Cells(2).Value
            precio = grilla_libro_compras.Rows(i).Cells(3).Value

            If costo = "" Or costo = "0" Then
                costo = "0"
            Else
                costo = Format(Int(costo), "###,###,###")
            End If

            If precio = "" Or precio = "0" Then
                precio = "0"
            Else
                precio = Format(Int(precio), "###,###,###")
            End If

            grilla_libro_compras.Rows(i).Cells(2).Value = costo
            grilla_libro_compras.Rows(i).Cells(3).Value = precio
        Next


    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grilla_libro_compras.Rows.Clear()
        txt_costo.Text = ""
    End Sub

End Class