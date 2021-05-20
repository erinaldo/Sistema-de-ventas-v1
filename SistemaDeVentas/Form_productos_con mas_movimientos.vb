Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_productos_con_mas_movimientos
    Dim mifecha2 As String
    Dim mifecha4 As String

    Private Sub Form_productos_con_mas_movimientos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_productos_con_mas_movimientos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_productos_con_mas_movimientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grilla_facturas.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        cargar_logo()
        combo_venta.Text = "BOLETA"
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

    Sub mostrar_malla()
        Dim tipo As String
        Dim item As String
        Dim nombre As String
        Dim numero_tecnico As String
        Dim cantidad As String

        If combo_venta.Text = "BOLETA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Columns.Clear()
            DT.Rows.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select boleta.tipo as tipo, detalle_boleta.cod_producto as item , detalle_boleta.detalle_nombre as nombre, detalle_boleta.numero_tecnico as tecnico, sum(detalle_boleta.cantidad) as cantidad from boleta , detalle_boleta where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and tipo like 'boleta%' and boleta.n_boleta=detalle_boleta.n_boleta group by item order by cantidad desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    tipo = DS.Tables(DT.TableName).Rows(i).Item("TIPO")
                    item = DS.Tables(DT.TableName).Rows(i).Item("ITEM")
                    nombre = DS.Tables(DT.TableName).Rows(i).Item("NOMBRE")
                    numero_tecnico = DS.Tables(DT.TableName).Rows(i).Item("TECNICO")
                    cantidad = DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD")

                    grilla_facturas.Rows.Add(tipo, item, nombre, numero_tecnico, cantidad)
                Next
            End If
            conexion.Close()
        End If

        If combo_venta.Text = "FACTURA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Columns.Clear()
            DT.Rows.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select factura.tipo as tipo, detalle_factura.cod_producto as item, detalle_factura.detalle_nombre as nombre, detalle_factura.numero_tecnico as tecnico, sum(detalle_factura.cantidad) as cantidad from factura , detalle_factura where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and tipo like 'factura%' and factura.n_factura=detalle_factura.n_factura group by item order by cantidad desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    tipo = DS.Tables(DT.TableName).Rows(i).Item("TIPO")
                    item = DS.Tables(DT.TableName).Rows(i).Item("ITEM")
                    nombre = DS.Tables(DT.TableName).Rows(i).Item("NOMBRE")
                    numero_tecnico = DS.Tables(DT.TableName).Rows(i).Item("TECNICO")
                    cantidad = DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD")

                    grilla_facturas.Rows.Add(tipo, item, nombre, numero_tecnico, cantidad)
                Next
            End If
            conexion.Close()
        End If

        If combo_venta.Text = "GUIA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Columns.Clear()
            DT.Rows.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select guia.tipo as tipo, detalle_guia.cod_producto as item, detalle_guia.detalle_nombre as nombre, detalle_guia.numero_tecnico as tecnico, sum(detalle_guia.cantidad) as cantidad from guia, detalle_guia where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and tipo like 'guia%' and guia.n_guia=detalle_guia.n_guia group by item order by cantidad desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    tipo = DS.Tables(DT.TableName).Rows(i).Item("TIPO")
                    item = DS.Tables(DT.TableName).Rows(i).Item("ITEM")
                    nombre = DS.Tables(DT.TableName).Rows(i).Item("NOMBRE")
                    numero_tecnico = DS.Tables(DT.TableName).Rows(i).Item("TECNICO")
                    cantidad = DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD")

                    grilla_facturas.Rows.Add(tipo, item, nombre, numero_tecnico, cantidad)
                Next
            End If
            conexion.Close()
        End If

        If combo_venta.Text = "COTIZACION" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Columns.Clear()
            DT.Rows.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select cotizacion.tipo as tipo, detalle_cotizacion.cod_producto as item, detalle_cotizacion.detalle_nombre as nombre, detalle_cotizacion.numero_tecnico as tecnico, sum(detalle_cotizacion.cantidad) as cantidad from cotizacion, detalle_cotizacion where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and tipo like 'cotizacion%' and cotizacion.n_cotizacion=detalle_cotizacion.n_cotizacion group by item order by cantidad desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    tipo = DS.Tables(DT.TableName).Rows(i).Item("TIPO")
                    item = DS.Tables(DT.TableName).Rows(i).Item("ITEM")
                    nombre = DS.Tables(DT.TableName).Rows(i).Item("NOMBRE")
                    numero_tecnico = DS.Tables(DT.TableName).Rows(i).Item("TECNICO")
                    cantidad = DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD")

                    grilla_facturas.Rows.Add(tipo, item, nombre, numero_tecnico, cantidad)
                Next
            End If
            conexion.Close()
        End If

        If combo_venta.Text = "NOTA DE CREDITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Columns.Clear()
            DT.Rows.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select nota_credito.tipo as tipo, detalle_nota_credito.cod_producto as item, detalle_nota_credito.detalle_nombre as nombre, detalle_nota_credito.numero_tecnico as tecnico, sum(detalle_nota_credito.cantidad) as cantidad from nota_credito, detalle_nota_credito where fecha_venta >='" & (mifecha2) & "' and fecha_venta <= '" & (mifecha4) & "' and tipo like 'nota de credito%' and nota_credito.n_nota_credito=detalle_nota_credito.n_nota_credito group by item order by cantidad desc"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    tipo = DS.Tables(DT.TableName).Rows(i).Item("TIPO")
                    item = DS.Tables(DT.TableName).Rows(i).Item("ITEM")
                    nombre = DS.Tables(DT.TableName).Rows(i).Item("NOMBRE")
                    numero_tecnico = DS.Tables(DT.TableName).Rows(i).Item("TECNICO")
                    cantidad = DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD")

                    grilla_facturas.Rows.Add(tipo, item, nombre, numero_tecnico, cantidad)
                Next
            End If
            conexion.Close()
        End If

        If grilla_facturas.Rows.Count <> 0 Then
            If grilla_facturas.Columns(0).Width = 200 Then
                grilla_facturas.Columns(0).Width = 199
            Else
                grilla_facturas.Columns(0).Width = 200
            End If
        End If
    End Sub

    Private Sub combo_venta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_venta.GotFocus
        color_foco()
    End Sub

    Private Sub combo_venta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_venta.SelectedIndexChanged
        grilla_facturas.Rows.Clear()
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grilla_facturas.Rows.Clear()
        mostrar_malla()
    End Sub

    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)

        Dim xlApp As Object = CreateObject("Excel.Application")
        'crear una nueva hoja de calculo 
        Dim xlWB As Object = xlApp.WorkBooks.add
        Dim xlWS As Object = xlWB.WorkSheets(1)

        'exportamos los caracteres de las columnas 
        For c As Integer = 0 To grilla_facturas.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_facturas.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_facturas.RowCount - 1
            For c As Integer = 0 To grilla_facturas.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_facturas.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub dtp_hasta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_hasta.GotFocus
        color_foco()
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        combo_venta.Text = ""
        grilla_facturas.Rows.Clear()
    End Sub

    Private Sub dtp_desde_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_desde.GotFocus
        color_foco()
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        combo_venta.Text = ""
        grilla_facturas.Rows.Clear()
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
        Next
    End Sub

    Private Sub Button2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        color_foco()
    End Sub

    Private Sub Button1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        color_foco()
    End Sub

    Private Sub Button3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar.GotFocus
        color_foco()
    End Sub

    Private Sub Button4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        color_foco()
    End Sub

    Private Sub btn_mostrar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        grilla_facturas.Rows.Clear()
        lbl_mensaje.Visible = True
        Me.Enabled = False
        fecha()
        mostrar_malla()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
        If valormensaje = vbYes Then
            grilla_facturas.Rows.Clear()
        End If
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click

        If grilla_facturas.Rows.Count = 0 Then
            dtp_desde.Focus()
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_facturas, save.FileName)
        End If
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_salir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
End Class