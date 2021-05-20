Public Class Form_revision_de_stock
    Dim mifecha2 As String
    Dim mifecha4 As String
    Private Sub Form_revision_de_stock_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_revision_de_stock_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_revision_de_stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        combo_estado.Text = "TODOS"
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub

    Sub mostrar_malla_revision_de_stock()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        'SC.CommandText = "select * from productos, familia where productos.familia=familia.codigo and COSTO >= 1 and cantidad >= 1 group by cod_producto"
        If combo_estado.Text = "TODOS" Then
            SC.CommandText = "SELECT revision_stock.cod_auto as 'COD AUTO', productos.cod_producto as 'PRODUCTO', nombre as 'DESCRIPCION', numero_tecnico as 'NRO. TECNICO', aplicacion as APLICACION, cantidad as 'STOCK', nombre_proveedor as 'PROVEEDOR', ultima_compra as 'FECHA ULT. COMPRA',cantidad_ultima_compra as 'CANT. ULT. COMPRA', revision_stock.estado as ESTADO, revision_stock.fecha_revision as 'FECHA REVISION', usuarios.nombre_usuario as 'USUARIO', revision_stock.stock_sugerido as 'STOCK SUGUERIDO' FROM productos, proveedores, revision_stock, usuarios where revision_stock.usuario_responsable = usuarios.rut_usuario and productos.cod_producto = revision_stock.cod_producto and productos.proveedor = proveedores.rut_proveedor  and fecha_revision >='" & (mifecha2) & "' and fecha_revision <= '" & (mifecha4) & "' ;"
        Else
            SC.CommandText = "SELECT revision_stock.cod_auto as 'COD AUTO', productos.cod_producto as 'PRODUCTO', nombre as 'DESCRIPCION', numero_tecnico as 'NRO. TECNICO', aplicacion as APLICACION, cantidad as 'STOCK', nombre_proveedor as 'PROVEEDOR', ultima_compra as 'FECHA ULT. COMPRA',cantidad_ultima_compra as 'CANT. ULT. COMPRA', revision_stock.estado as ESTADO, revision_stock.fecha_revision as 'FECHA REVISION', usuarios.nombre_usuario as 'USUARIO', revision_stock.stock_sugerido as 'STOCK SUGUERIDO' FROM productos, proveedores, revision_stock, usuarios where revision_stock.estado='" & (combo_estado.Text) & "' and revision_stock.usuario_responsable = usuarios.rut_usuario and productos.cod_producto = revision_stock.cod_producto and productos.proveedor = proveedores.rut_proveedor  and fecha_revision >='" & (mifecha2) & "' and fecha_revision <= '" & (mifecha4) & "' ;"
        End If
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_revision_de_stock.Rows.Clear()
        grilla_revision_de_stock.Columns.Clear()
        grilla_revision_de_stock.Columns.Add("", "COD AUTO")
        grilla_revision_de_stock.Columns.Add("", "PRODUCTO")
        grilla_revision_de_stock.Columns.Add("", "DESCRIPCION")
        grilla_revision_de_stock.Columns.Add("", "NRO. TECNICO")
        grilla_revision_de_stock.Columns.Add("", "APLICACION")
        grilla_revision_de_stock.Columns.Add("", "STOCK")
        grilla_revision_de_stock.Columns.Add("", "PROVEEDOR")
        grilla_revision_de_stock.Columns.Add("", "FECHA ULT. COMPRA")
        grilla_revision_de_stock.Columns.Add("", "CANT. ULT. COMPRA")
        grilla_revision_de_stock.Columns.Add("", "ESTADO")
        grilla_revision_de_stock.Columns.Add("", "FECHA REVISION")
        grilla_revision_de_stock.Columns.Add("", "USUARIO")
        grilla_revision_de_stock.Columns.Add("", "SOCK SUG.")
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                Dim MiFechaUltimaCompra As Date
                Dim Mi_Fecha_Ultima_Compra As String
                MiFechaUltimaCompra = DS.Tables(DT.TableName).Rows(i).Item("FECHA ULT. COMPRA")
                Mi_Fecha_Ultima_Compra = MiFechaUltimaCompra.ToString("dd-MM-yyy")

                Dim MiFechaRevision As Date
                Dim Mi_Fecha_Revision As String
                MiFechaRevision = DS.Tables(DT.TableName).Rows(i).Item("FECHA ULT. COMPRA")
                Mi_Fecha_Revision = MiFechaRevision.ToString("dd-MM-yyy")

                grilla_revision_de_stock.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("COD AUTO"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("PRODUCTO"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("DESCRIPCION"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("NRO. TECNICO"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("APLICACION"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("STOCK"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("PROVEEDOR"), _
                                                         Mi_Fecha_Ultima_Compra, _
                                                          DS.Tables(DT.TableName).Rows(i).Item("CANT. ULT. COMPRA"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("ESTADO"), _
                                                            Mi_Fecha_Revision, _
                                                             DS.Tables(DT.TableName).Rows(i).Item("USUARIO"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("STOCK SUGUERIDO"))
            Next
        End If

        If grilla_revision_de_stock.Rows.Count <> 0 Then
            If grilla_revision_de_stock.Columns(0).Width = 150 Then
                grilla_revision_de_stock.Columns(0).Width = 149
            Else
                grilla_revision_de_stock.Columns(0).Width = 150
            End If
            grilla_revision_de_stock.Columns(1).Width = 150
            grilla_revision_de_stock.Columns(2).Width = 250
            grilla_revision_de_stock.Columns(3).Width = 250
            grilla_revision_de_stock.Columns(4).Width = 150
            grilla_revision_de_stock.Columns(5).Width = 150
            grilla_revision_de_stock.Columns(6).Width = 150
            grilla_revision_de_stock.Columns(7).Width = 150
            grilla_revision_de_stock.Columns(8).Width = 150
            grilla_revision_de_stock.Columns(9).Width = 150
            grilla_revision_de_stock.Columns(10).Width = 150
            grilla_revision_de_stock.Columns(11).Width = 250
            grilla_revision_de_stock.Columns(12).Width = 150
            grilla_revision_de_stock.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_revision_de_stock.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_revision_de_stock.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_revision_de_stock.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_revision_de_stock.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_revision_de_stock.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_revision_de_stock.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_revision_de_stock.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_revision_de_stock.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_revision_de_stock.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_revision_de_stock.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_revision_de_stock.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_revision_de_stock.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        fecha()
        mostrar_malla_revision_de_stock()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        If grilla_revision_de_stock.Rows.Count = 0 Then
            dtp_desde.Focus()
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_revision_de_stock, save.FileName)
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
        For c As Integer = 0 To grilla_revision_de_stock.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_revision_de_stock.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_revision_de_stock.RowCount - 1
            For c As Integer = 0 To grilla_revision_de_stock.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_revision_de_stock.Item(c, r).Value
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
            grilla_revision_de_stock.Rows.Clear()
            grilla_revision_de_stock.Columns.Clear()
            combo_estado.Text = "TODOS"
        End If
    End Sub

    Private Sub btn_estado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub grilla_revision_de_stock_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_revision_de_stock.CellContentClick

    End Sub

    Private Sub grilla_revision_de_stock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_revision_de_stock.Click

    End Sub

    Private Sub grilla_revision_de_stock_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_revision_de_stock.DoubleClick
        If grilla_revision_de_stock.Rows.Count = 0 Then
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        Dim cod_auto As String
        Dim estado_de_revision As String

        cod_auto = grilla_revision_de_stock.CurrentRow.Cells(0).Value
        estado_de_revision = grilla_revision_de_stock.CurrentRow.Cells(9).Value

        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA CAMBIAR EL  ESTADO DE ESTE PRODUCTO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        If valormensaje = vbYes Then
            If estado_de_revision = "EN ESPERA" Then
                SC.Connection = conexion
                SC.CommandText = "UPDATE `revision_stock` SET `estado`='REVISADO' WHERE `cod_auto`='" & (cod_auto) & "';"
                DA.SelectCommand = SC
                DA.Fill(DT)
            Else
                SC.Connection = conexion
                SC.CommandText = "UPDATE `revision_stock` SET `estado`='EN ESPERA' WHERE `cod_auto`='" & (cod_auto) & "';"
                DA.SelectCommand = SC
                DA.Fill(DT)
            End If
            mostrar_malla_revision_de_stock()
        End If

            lbl_mensaje.Visible = False
            Me.Enabled = True
    End Sub
End Class