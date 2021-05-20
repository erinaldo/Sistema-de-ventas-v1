'Imports System
'Imports System.IO
'Imports System.Drawing
'Imports System.Drawing.Font
'Imports System.Collections
'Imports System.ComponentModel
'Imports System.Windows.Forms
'Imports System.Data
'Imports System.Drawing.Text
Imports System.IO
Imports System.Math

Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D

Public Class Form_crear_etiquetas
    Dim total_registros As Integer
    Private fuente As Font
    Private directorioFuentes As String
    Private WithEvents Pd As New PrintDocument
    Dim impresora_etiquetas_1 As String
    Dim impresora_etiquetas_2 As String
    Dim margen_etiquetas_1 As String
    Dim margen_etiquetas_2 As String

    Private Sub Form_crear_etiquetas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_crear_etiquetas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F4 Then
            btn_buscar.PerformClick()
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

    'se llama al llenar codigo.
    'se actualiza la tabla clientes.
    Private Sub Form_crear_etiquetas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llenar_combo_codigo()
        ' actualizar_tabla_productos()
        '  impresoras()
        mostrar_datos_empresa()
        cargar_logo()

        Panel_etiqueta_1.Location = New Point(307, 84)

        Radio_impresora_1.Checked = True

        'Panel_etiqueta_1.Visible = True
        'Panel_etiqueta_2.Visible = False
        'Panel_etiqueta_3.Visible = False
        'Panel_etiqueta_4.Visible = False
        'Panel_etiqueta_5.Visible = False
        'Panel_etiqueta_6.Visible = False

        RadioButton1.Checked = True


        lbl_nombre_empresa_1.Text = txt_empresa.Text
        lbl_nombre_empresa_2.Text = txt_empresa.Text

        lbl_nombre_empresa_4.Text = txt_empresa.Text

        mostrar_impresora()
    End Sub

    Sub mostrar_impresora()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from impresoras"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            impresora_etiquetas_1 = DS.Tables(DT.TableName).Rows(0).Item("etiqueta")
            impresora_etiquetas_2 = DS.Tables(DT.TableName).Rows(0).Item("etiqueta_2")
            margen_etiquetas_1 = DS.Tables(DT.TableName).Rows(0).Item("margen_etiqueta_1")
            margen_etiquetas_2 = DS.Tables(DT.TableName).Rows(0).Item("margen_etiqueta_2")
        End If
        conexion.Close()
    End Sub

    Sub mostrar_datos_empresa()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from empresa"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            txt_empresa.Text = DS.Tables(DT.TableName).Rows(0).Item("titular_etiqueta")
        End If
        conexion.Close()

    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    'se muestra los datos de los productos.
    Sub mostrar_datos_productos()
        Dim cantidad_caracteres As Integer

        If txt_codigo.Text <> "" Then
            cantidad_caracteres = Len(txt_codigo.Text)
            If cantidad_caracteres <= 6 Then
                conexion.Close()
                DS.Tables.Clear()
                DT.Rows.Clear()
                DT.Columns.Clear()
                DS.Clear()
                conexion.Open()

                SC.Connection = conexion
                SC.CommandText = "select * from productos where cod_producto ='" & (txt_codigo.Text) & "'"
                DA.SelectCommand = SC
                DA.Fill(DT)
                DS.Tables.Add(DT)
                If DS.Tables(DT.TableName).Rows.Count > 0 Then
                    Try

                        txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                        lbl_nombre_producto_1.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                        lbl_nombre_producto_2.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                        lbl_nombre_producto_3.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                        lbl_nombre_producto_4.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                        lbl_codigo_4.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                        lbl_codigo_1.Text = "*" & DS.Tables(DT.TableName).Rows(0).Item("cod_producto") & "*"
                        lbl_codigo_2.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                        lbl_codigo_3.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                        txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                        txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                        lbl_nro_tecnico_1.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                        lbl_nro_tecnico_2.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                        lbl_nro_tecnico_3.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                        'lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                        'txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                        'lbl_factor_1.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                        'lbl_factor_2.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                        txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                        lbl_aplicacion_1.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                        lbl_aplicacion_2.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                        'lbl_nombre_producto_3.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                        txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                        lbl_precio_3.Text = DS.Tables(DT.TableName).Rows(0).Item("precio")
                        txt_tipo_medida.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_medida")

                        If mirutempresa = "87686300-6" Then
                            If Val(txt_precio.Text) <> 0 Then
                                Dim precio As Integer

                                precio = Val(txt_precio.Text)
                                precio = precio * valor_descuento_maximo / 100

                                lbl_precio_3.Text = txt_precio.Text - precio

                                redondear_documento()
                                lbl_precio_3.Text = "$" & Format(Int(lbl_precio_3.Text), "###,###,###")
                            End If
                        End If

                        If lbl_precio_3.Text = "" Or lbl_precio_3.Text = "0" Then
                            lbl_precio_3.Text = "$0"
                        Else
                            lbl_precio_3.Text = "$" & Format(Int(lbl_precio_3.Text), "###,###,###")
                        End If
                    Catch
                    End Try
                End If
                conexion.Close()
            End If

        Else
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from productos where codigo_barra ='" & (txt_codigo.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                Try
                    txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    lbl_nombre_producto_1.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    lbl_nombre_producto_2.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    lbl_nombre_producto_3.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    lbl_nombre_producto_4.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    lbl_codigo_4.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    lbl_codigo_1.Text = "*" & DS.Tables(DT.TableName).Rows(0).Item("cod_producto") & "*"
                    lbl_codigo_2.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    lbl_codigo_3.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
                    txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                    lbl_nro_tecnico_1.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                    lbl_nro_tecnico_2.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                    lbl_nro_tecnico_3.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
                    'lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
                    'txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                    'lbl_factor_1.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                    'lbl_factor_2.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
                    txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                    lbl_aplicacion_1.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                    lbl_aplicacion_2.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")
                    'lbl_nombre_producto_3.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
                    txt_precio.Text = DS.Tables(DT.TableName).Rows(0).Item("PRECIO")
                    lbl_precio_3.Text = DS.Tables(DT.TableName).Rows(0).Item("PRECIO")
                    txt_tipo_medida.Text = DS.Tables(DT.TableName).Rows(0).Item("tipo_medida")

                    If mirutempresa = "87686300-6" Then
                        If Val(txt_precio.Text) <> 0 Then
                            Dim precio As Integer

                            precio = Val(txt_precio.Text)
                            precio = precio * valor_descuento_maximo / 100

                            lbl_precio_3.Text = txt_precio.Text - precio
                            redondear_documento()
                            lbl_precio_3.Text = "$" & Format(Int(lbl_precio_3.Text), "###,###,###")
                        End If
                    End If

                    If lbl_precio_3.Text = "" Or lbl_precio_3.Text = "0" Then
                        lbl_precio_3.Text = "$0"
                    Else
                        lbl_precio_3.Text = "$" & Format(Int(lbl_precio_3.Text), "###,###,###")
                    End If
                Catch
                End Try
            End If
            conexion.Close()
        End If

    End Sub

    'Sub mostrar_datos_productos2()
    '    '    If combo_cod.Text <> "" Then
    '    conexion.Close()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from productos where codigo_barra ='" & (txt_codigo.Text) & "'"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        Try
    '            txt_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
    '            txt_nombre_producto.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
    '            txt_marca.Text = DS.Tables(DT.TableName).Rows(0).Item("marca")
    '            txt_numero_tecnico.Text = DS.Tables(DT.TableName).Rows(0).Item("numero_tecnico")
    '            lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
    '            txt_factor.Text = DS.Tables(DT.TableName).Rows(0).Item("factor")
    '            txt_aplicacion.Text = DS.Tables(DT.TableName).Rows(0).Item("aplicacion")

    '        Catch
    '        End Try
    '    End If
    '    conexion.Close()
    '    '  End If

    '    If RadioButton2.Checked = True Then

    '        If txt_precio.Text <> "" And txt_precio.Text <> 0 Then
    '            Dim precio As Integer

    '            precio = Val(txt_precio.Text)
    '            precio = precio * valor_descuento_maximo / 100

    '            txt_precio.Text = txt_precio.Text - precio
    '        End If

    '    End If
    'End Sub

    Sub limpiar()
        txt_nombre_producto.Text = ""
        txt_marca.Text = ""
        txt_numero_tecnico.Text = ""
        'lbl_codigo.Text = "CODIGO"
        'txt_factor.Text = ""
        txt_numero.Text = ""
        txt_codigo.Text = ""
        txt_precio.Text = ""
        txt_aplicacion.Text = ""
        txt_tipo_medida.Text = ""
        'combo_cantidad.Items.Clear()
        'combo_cantidad.Items.Add("3")
        'combo_cantidad.Items.Add("6")
        'combo_cantidad.Items.Add("3")
        'combo_cantidad.Items.Add("4")











        lbl_nombre_producto_1.Text = "NOMBRE PRODUCTO"
        lbl_nombre_producto_2.Text = "NOMBRE PRODUCTO"
        lbl_nombre_producto_3.Text = "NOMBRE PRODUCTO"
        lbl_codigo_1.Text = "*CODIGO*"
        lbl_codigo_2.Text = "CODIGO"
        lbl_codigo_3.Text = "CODIGO"

        lbl_nro_tecnico_1.Text = "NUMERO TECNICO"
        lbl_nro_tecnico_2.Text = "NUMERO TECNICO"
        lbl_nro_tecnico_3.Text = "NUMERO TECNICO"

        'lbl_factor_1.Text = "FACTOR"
        'lbl_factor_2.Text = "FACTOR"

        lbl_aplicacion_1.Text = "APLICACION"
        lbl_aplicacion_2.Text = "APLICACION"

        lbl_precio_3.Text = "$0"


    End Sub

    Sub limpiar_producto()
        txt_nombre_producto.Text = ""
        txt_marca.Text = ""
        txt_numero_tecnico.Text = ""
        'lbl_codigo.Text = "CODIGO"
        'txt_factor.Text = ""
        '   txt_numero.Text = ""
        '  txt_codigo.Text = ""
        txt_precio.Text = ""
        txt_aplicacion.Text = ""
        txt_tipo_medida.Text = ""
        'combo_cantidad.Items.Clear()
        'combo_cantidad.Items.Add("3")
        'combo_cantidad.Items.Add("6")
        'combo_cantidad.Items.Add("3")
        'combo_cantidad.Items.Add("4")
    End Sub


    ''se graba los datos deltickets en una tabla temporal.
    'Sub grabar_ticket()
    '    Dim cod As String
    '    Dim num As String
    '    cod = "*" & (lbl_codigo.Text) & "*"
    '    num = "(" & (txt_numero_tecnico.Text) & ")"
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "insert into ticket_temporal (codigo, marca, nombre, factor, cbarra, numero_tecnico, aplicacion) values('" & (lbl_codigo.Text) & "','" & (txt_marca.Text) & "','" & (txt_nombre_producto.Text) & "','" & (txt_factor.Text) & "','" & (cod) & "','" & (num) & "','" & (txt_aplicacion.Text) & "')"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    conexion.Close()

    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Close()

    'End Sub

    ''se actualiza la tabla productos.
    'Sub actualizar_tabla_productos()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from productos"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    conexion.Close()
    'End Sub





    'se muestran lso datos del producto.
    'se asigna el calor del ocmbo al texbox.
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mostrar_datos_productos()

    End Sub


    'salir de la pantalla
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        'form_Menu_admin.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub

    'Sub impresoras()

    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()

    '    SC.Connection = conexion
    '    SC.CommandText = "select * from impresoras"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)

    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        txt_impresora_etiquetas.Text = DS.Tables(DT.TableName).Rows(0).Item("etiqueta")
    '    End If
    '    conexion.Close()
    'End Sub


    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("C:\Ayuda Market Digital\Ayuda market digital.chm")
        Catch
        End Try
    End Sub

    'se graba la impresion del ticket, se imprime y posteriormente se elimina.
    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        
        Dim mensaje As String = ""

        If txt_nombre_producto.Text = "" Then
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_nombre_producto.Focus()
            Exit Sub
        End If

        If txt_numero.Text = "" Then
            MsgBox("CAMPO NUMERO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_numero.Focus()
            Exit Sub
        End If

        If txt_codigo.Text = "" Then
            MsgBox("CAMPO CODIGO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            txt_codigo.Focus()
            Exit Sub
        End If





        lbl_mensaje.Visible = True
        Me.Enabled = False

        'If RadioButton5.Checked = True Then

        '    lbl_mensaje.Visible = True
        '    Me.Enabled = False



        '    Try
        '        Dim iReporte As New form_informe_estado_de_cuenta_personalizado
        '        Dim rpt As New Crystal_etiqueta_5

        '        rpt.Load()
        '        rpt.SetDataSource(ReturnDataSet)
        '        rpt.Refresh()

        '        iReporte.Reporte = rpt
        '        '  iReporte.ShowDialog()
        '        rpt.PrintOptions.PrinterName = impresora_etiquetas
        '        rpt.PrintToPrinter(txt_numero.Text, False, 0, 0)
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try


        '    lbl_mensaje.Visible = False
        '    Me.Enabled = True

        'Else
        With Pd.PrinterSettings

            ' Especifico el nombre de la impresora 
            ' por donde deseo imprimir. 
            If Radio_impresora_1.Checked = True Then
                '.PrinterName = impresora_etiquetas
                .PrinterName = impresora_etiquetas_1
            Else
                .PrinterName = impresora_etiquetas_2
            End If
            '.PrinterName = "\\INFORMATICA-PC\ZDesigner TLP 2844"

            ' Establezco el número de copias que se imprimirán 
            .Copies = txt_numero.Text

            ' Rango de páginas que se imprimirán 
            .PrintRange = PrintRange.AllPages
            If .IsValid Then
                Me.Pd.PrintController = New StandardPrintController
                'Me.Pd.DefaultPageSettings.Margins.Left = 10
                'Me.Pd.DefaultPageSettings.Margins.Right = 10

                If RadioButton5.Checked = True Then
                    Dim pkCustomSize1 As New PaperSize("New Long Roll", 300, 70)
                    Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                ElseIf RadioButton6.Checked = True Then
                    Dim pkCustomSize1 As New PaperSize("New Long Roll", 200, 44)
                    Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                Else
                    Dim pkCustomSize1 As New PaperSize("New Long Roll", 300, 99)
                    Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                End If



                Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                Pd.Print()
                'limpiar()
                'MsgBox("SE HA IMPRESO CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                txt_numero.Focus()
            Else
                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                lbl_mensaje.Visible = False
                Me.Enabled = True
                Exit Sub
            End If
        End With
        ' End If

        lbl_mensaje.Visible = False
        Me.Enabled = True
        txt_numero.Focus()






    End Sub

    'Private Function ReturnDataSet() As DataSet

    '    Dim dt As New DataTable
    '    Dim dr As DataRow
    '    Dim ds As New DataSet

    '    dt.Columns.Add(New DataColumn("logo_empresa", GetType(Byte())))
    '    dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))
    '    dt.Columns.Add(New DataColumn("fechas", GetType(String)))
    '    dt.Columns.Add(New DataColumn("titulo", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn1", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn2", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn3", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn4", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn5", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn6", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn7", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn8", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn9", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn10", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn11", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn12", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn13", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn14", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn15", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn16", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn17", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn18", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn19", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn20", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn21", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn22", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn23", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn24", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn25", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn26", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn27", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn28", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn29", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn30", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn31", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn32", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn33", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn34", GetType(Integer)))
    '    dt.Columns.Add(New DataColumn("DataColumn35", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn36", GetType(String)))
    '    dt.Columns.Add(New DataColumn("DataColumn37", GetType(String)))


    '    Dim VarFecha As String
    '    Dim VarVehiculo As String
    '    Dim VarPatente As String
    '    Dim VarKilometros As String
    '    Dim VarCantidad As String
    '    Dim VarCodigo As String
    '    Dim VarNombre As String
    '    Dim VarNumeroTecnico As String


    '    dr = dt.NewRow()

    '    Try
    '        dr("DataColumn1") = mititularetiquetaempresa
    '    Catch
    '    End Try

    '    Try
    '        dr("DataColumn2") = txt_nombre_producto.Text
    '    Catch
    '    End Try

    '    Try
    '        dr("DataColumn3") = "*" & txt_codigo.Text & "*"
    '    Catch
    '    End Try

    '    dt.Rows.Add(dr)

    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "DS_reporte"

    '    Dim iDS As New DS_reporte
    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS





    'End Function

    Private Sub txt_numero_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero.GotFocus
        txt_numero.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_numero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numero.KeyPress
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


        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If


        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            txt_codigo.Focus()
        End If

    End Sub


    Private Sub combo_cantidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_codigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.GotFocus
        txt_codigo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo.KeyPress

        e.KeyChar = e.KeyChar.ToString.ToUpper

        limpiar_datos_productos()


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

            ' If Radio_codigo_interno.Checked = True Then
            mostrar_datos_productos()
            btn_imprimir.Focus()
            'Else
            '  If Radio_codigo_barra.Checked = True Then
            'mostrar_datos_productos2()
            '    btn_imprimir.Focus()
            '  End If
        End If

        '    End If
    End Sub

    Private Sub txt_codigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo.LostFocus
        txt_codigo.BackColor = Color.White
    End Sub

    Private Sub txt_codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo.TextChanged

    End Sub

    Private Sub Radio_codigo_barra_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_codigo.Focus()
    End Sub

    Private Sub Radio_codigo_interno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_codigo.Focus()
    End Sub



    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
        If RadioButton6.Checked = True Then


            Dim Fuente As Font
            Fuente = New Font("GothicE", 50, FontStyle.Bold)
            Dim Fuente1 As Font
            Fuente1 = New Font("Arial", 12, FontStyle.Bold)

            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center

            'Dim rect1 As New Rectangle(5, 1, 294, 10)
            ''(left,top,whidth,height )
            'Dim rect2 As New Rectangle(5, 54, 294, 40)

            'rect1.Height = 50
            'rect1.Width = 250

            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            format1.Alignment = StringAlignment.Far

            Dim margen As String

            If Radio_impresora_1.Checked = True Then
                margen = margen_etiquetas_1
            Else
                margen = margen_etiquetas_2
            End If



            Dim rect1 As New Rectangle(margen + 5, 1, 200, 10)
            '(left,top,whidth,height )
            Dim rect2 As New Rectangle(margen + 5, 54, 294, 40)

            'e.Graphics.DrawString(mititularetiquetaempresa, New Font("ARIAL", 3, FontStyle.Bold), Brushes.Black, -1, 1)

            Dim descripcion_caracteres As String
            descripcion_caracteres = txt_nombre_producto.Text
            If descripcion_caracteres.Length > 34 Then
                descripcion_caracteres = descripcion_caracteres.Substring(0, 34)
            End If

            Dim descripcion_aplicacion As String
            descripcion_aplicacion = txt_aplicacion.Text
            If descripcion_aplicacion.Length > 34 Then
                descripcion_aplicacion = descripcion_aplicacion.Substring(0, 34)
            End If

            Dim descripcion_tecnico As String
            descripcion_tecnico = txt_numero_tecnico.Text
            If descripcion_tecnico.Length > 27 Then
                descripcion_tecnico = descripcion_tecnico.Substring(0, 27)
            End If

            e.Graphics.DrawString(descripcion_caracteres, New Font("ARIAL", 4, FontStyle.Regular), Brushes.Black, -1, 0)


            'e.Graphics.DrawString(descripcion_caracteres, New Font("ARIAL", 5, FontStyle.Bold), Brushes.Black, 0, 19)
            'e.Graphics.DrawString(descripcion_aplicacion, New Font("ARIAL", 5, FontStyle.Bold), Brushes.Black, margen + 40, 27)
            'e.Graphics.DrawString(descripcion_tecnico, New Font("ARIAL", 5, FontStyle.Bold), Brushes.Black, margen + 40, 39)

            'If txt_factor.Text <> "0" And txt_factor.Text <> "" Then
            '    e.Graphics.DrawString(txt_factor.Text, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 242, 39, format1)
            'End If

            e.Graphics.DrawString("*" & (txt_codigo.Text) & "*", New Font("C39HrP36DlTt", 12), Brushes.Black, -2, 8)
            'e.Graphics.DrawString("*" & (txt_codigo.Text) & "*", New Font("C39HrP36DlTt", 20), Brushes.Black, rect2, stringFormat)



            'Indica que no hay más hojas para imprimir, por lo que no se ejecutará nuevamente este procedimiento
            e.HasMorePages = False
            'Fuerza a que se liberen los recursos.
            Fuente.Dispose()

        End If



        If RadioButton5.Checked = True Then


            Dim Fuente As Font
            Fuente = New Font("GothicE", 50, FontStyle.Bold)
            Dim Fuente1 As Font
            Fuente1 = New Font("Arial", 12, FontStyle.Bold)

            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center

            'Dim rect1 As New Rectangle(5, 1, 294, 10)
            ''(left,top,whidth,height )
            'Dim rect2 As New Rectangle(5, 54, 294, 40)

            'rect1.Height = 50
            'rect1.Width = 250

            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            format1.Alignment = StringAlignment.Far

            Dim margen As String

            If Radio_impresora_1.Checked = True Then
                margen = margen_etiquetas_1
            Else
                margen = margen_etiquetas_2
            End If



            Dim rect1 As New Rectangle(margen + 5, 1, 200, 10)
            '(left,top,whidth,height )
            Dim rect2 As New Rectangle(margen + 5, 54, 294, 40)

            e.Graphics.DrawString(mititularetiquetaempresa, New Font("ARIAL", 4.5, FontStyle.Bold), Brushes.Black, margen + 40, 5)

            Dim descripcion_caracteres As String
            descripcion_caracteres = txt_nombre_producto.Text
            If descripcion_caracteres.Length > 34 Then
                descripcion_caracteres = descripcion_caracteres.Substring(0, 34)
            End If

            Dim descripcion_aplicacion As String
            descripcion_aplicacion = txt_aplicacion.Text
            If descripcion_aplicacion.Length > 34 Then
                descripcion_aplicacion = descripcion_aplicacion.Substring(0, 34)
            End If

            Dim descripcion_tecnico As String
            descripcion_tecnico = txt_numero_tecnico.Text
            If descripcion_tecnico.Length > 27 Then
                descripcion_tecnico = descripcion_tecnico.Substring(0, 27)
            End If

            e.Graphics.DrawString(descripcion_caracteres, New Font("ARIAL", 5, FontStyle.Bold), Brushes.Black, margen + 40, 19)
            'e.Graphics.DrawString(descripcion_aplicacion, New Font("ARIAL", 5, FontStyle.Bold), Brushes.Black, margen + 40, 27)
            'e.Graphics.DrawString(descripcion_tecnico, New Font("ARIAL", 5, FontStyle.Bold), Brushes.Black, margen + 40, 39)

            'If txt_factor.Text <> "0" And txt_factor.Text <> "" Then
            '    e.Graphics.DrawString(txt_factor.Text, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 242, 39, format1)
            'End If

            e.Graphics.DrawString("*" & (txt_codigo.Text) & "*", New Font("C39HrP36DlTt", 20), Brushes.Black, margen + 40, 35)
            'e.Graphics.DrawString("*" & (txt_codigo.Text) & "*", New Font("C39HrP36DlTt", 20), Brushes.Black, rect2, stringFormat)



            'Indica que no hay más hojas para imprimir, por lo que no se ejecutará nuevamente este procedimiento
            e.HasMorePages = False
            'Fuerza a que se liberen los recursos.
            Fuente.Dispose()

        End If







        If RadioButton1.Checked = True Then


            Dim Fuente As Font
            Fuente = New Font("GothicE", 50, FontStyle.Bold)
            Dim Fuente1 As Font
            Fuente1 = New Font("Arial", 12, FontStyle.Bold)

            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center

            'Dim rect1 As New Rectangle(5, 1, 294, 10)
            ''(left,top,whidth,height )
            'Dim rect2 As New Rectangle(5, 54, 294, 40)

            'rect1.Height = 50
            'rect1.Width = 250

            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            format1.Alignment = StringAlignment.Far

            Dim margen As String

            If Radio_impresora_1.Checked = True Then
                margen = margen_etiquetas_1
            Else
                margen = margen_etiquetas_2
            End If



            Dim rect1 As New Rectangle(margen + 5, 1, 294, 10)
            '(left,top,whidth,height )
            Dim rect2 As New Rectangle(margen + 5, 54, 294, 40)

            e.Graphics.DrawString(mititularetiquetaempresa, New Font("ARIAL", 5, FontStyle.Bold), Brushes.Black, rect1, stringFormat)

            Dim descripcion_caracteres As String
            descripcion_caracteres = txt_nombre_producto.Text
            If descripcion_caracteres.Length > 34 Then
                descripcion_caracteres = descripcion_caracteres.Substring(0, 34)
            End If

            Dim descripcion_aplicacion As String
            descripcion_aplicacion = txt_aplicacion.Text
            If descripcion_aplicacion.Length > 34 Then
                descripcion_aplicacion = descripcion_aplicacion.Substring(0, 34)
            End If

            Dim descripcion_tecnico As String
            descripcion_tecnico = txt_numero_tecnico.Text
            If descripcion_tecnico.Length > 34 Then
                descripcion_tecnico = descripcion_tecnico.Substring(0, 34)
            End If

            e.Graphics.DrawString(descripcion_caracteres, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 59, 15)
            e.Graphics.DrawString(descripcion_aplicacion, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 59, 27)
            e.Graphics.DrawString(descripcion_tecnico, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 59, 39)

            'If txt_factor.Text <> "0" And txt_factor.Text <> "" Then
            '    e.Graphics.DrawString(txt_factor.Text, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 242, 39, format1)
            'End If


            e.Graphics.DrawString("*" & (txt_codigo.Text) & "*", New Font("C39HrP36DlTt", 30), Brushes.Black, rect2, stringFormat)



            'Indica que no hay más hojas para imprimir, por lo que no se ejecutará nuevamente este procedimiento
            e.HasMorePages = False
            'Fuerza a que se liberen los recursos.
            Fuente.Dispose()

        End If









        If RadioButton2.Checked = True Then


            Dim Fuente As Font
            Fuente = New Font("GothicE", 50, FontStyle.Bold)
            Dim Fuente1 As Font
            Fuente1 = New Font("Arial", 12, FontStyle.Bold)

            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center

            'Dim rect1 As New Rectangle(5, 1, 294, 10)
            ''(left,top,whidth,height )
            'Dim rect2 As New Rectangle(5, 54, 294, 40)

            'rect1.Height = 50
            'rect1.Width = 250

            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            format1.Alignment = StringAlignment.Far

            Dim margen As String

            If Radio_impresora_1.Checked = True Then
                margen = margen_etiquetas_1
            Else
                margen = margen_etiquetas_2
            End If



            Dim rect1 As New Rectangle(margen + 5, 1, 294, 10)
            '(left,top,whidth,height )
            Dim rect2 As New Rectangle(margen + 5, 54, 294, 40)

            e.Graphics.DrawString(mititularetiquetaempresa, New Font("ARIAL", 5, FontStyle.Bold), Brushes.Black, rect1, stringFormat)

            Dim descripcion_caracteres As String
            descripcion_caracteres = txt_nombre_producto.Text
            If descripcion_caracteres.Length > 34 Then
                descripcion_caracteres = descripcion_caracteres.Substring(0, 34)
            End If

            Dim descripcion_aplicacion As String
            descripcion_aplicacion = txt_aplicacion.Text
            If descripcion_aplicacion.Length > 34 Then
                descripcion_aplicacion = descripcion_aplicacion.Substring(0, 34)
            End If

            Dim descripcion_tecnico As String
            descripcion_tecnico = txt_numero_tecnico.Text
            If descripcion_tecnico.Length > 27 Then
                descripcion_tecnico = descripcion_tecnico.Substring(0, 27)
            End If

            e.Graphics.DrawString(descripcion_caracteres, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 59, 15)
            e.Graphics.DrawString(descripcion_aplicacion, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 59, 27)
            e.Graphics.DrawString(descripcion_tecnico, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 59, 39)

            'If txt_factor.Text <> "0" And txt_factor.Text <> "" Then
            '    e.Graphics.DrawString(txt_factor.Text, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 242, 39, format1)
            'End If

            e.Graphics.DrawString((txt_codigo.Text), New Font("ARIAL", 30), Brushes.Black, rect2, stringFormat)


            'Indica que no hay más hojas para imprimir, por lo que no se ejecutará nuevamente este procedimiento
            e.HasMorePages = False
            'Fuerza a que se liberen los recursos.
            Fuente.Dispose()

        End If





























        If RadioButton3.Checked = True Then

            If txt_precio.Text = "" Or txt_precio.Text = "0" Then
                txt_precio.Text = "0"
            Else
                txt_precio.Text = Format(Int(txt_precio.Text), "###,###,###")
            End If

            Dim Fuente As Font
            Fuente = New Font("GothicE", 50, FontStyle.Bold)
            Dim Fuente1 As Font
            Fuente1 = New Font("Arial", 12, FontStyle.Bold)

            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center

            'Dim rect1 As New Rectangle(5, 1, 294, 10)
            ''(left,top,whidth,height )
            'Dim rect2 As New Rectangle(5, 54, 294, 40)

            'rect1.Height = 50
            'rect1.Width = 250

            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            format1.Alignment = StringAlignment.Far

            Dim margen As String

            If Radio_impresora_1.Checked = True Then
                margen = margen_etiquetas_1
            Else
                margen = margen_etiquetas_2
            End If



            Dim rect1 As New Rectangle(margen + 5, 1, 294, 10)
            '(left,top,whidth,height )
            Dim rect2 As New Rectangle(margen + 5, 33, 294, 40)

            ' e.Graphics.DrawString(txt_nombre_producto.Text, New Font("ARIAL", 5, FontStyle.Bold), Brushes.Black, rect1, stringFormat)

            Dim descripcion_caracteres As String
            descripcion_caracteres = txt_nombre_producto.Text
            If descripcion_caracteres.Length > 34 Then
                descripcion_caracteres = descripcion_caracteres.Substring(0, 34)
            End If

            Dim descripcion_aplicacion As String
            descripcion_aplicacion = txt_aplicacion.Text
            If descripcion_aplicacion.Length > 34 Then
                descripcion_aplicacion = descripcion_aplicacion.Substring(0, 34)
            End If

            Dim descripcion_tecnico As String
            descripcion_tecnico = txt_numero_tecnico.Text
            If descripcion_tecnico.Length > 27 Then
                descripcion_tecnico = descripcion_tecnico.Substring(0, 27)
            End If


            Dim rect5 As New Rectangle(margen + 5, 1, 294, 10)
            Dim rect6 As New Rectangle(margen + 5, 1, 294, 30)
            e.Graphics.DrawString(txt_codigo.Text & " " & descripcion_caracteres, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, rect5, stringFormat)
            e.Graphics.DrawString(descripcion_tecnico, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, rect6, stringFormat)

            'If mirutempresa = "87686300-6" Then
            '    e.Graphics.DrawString(("$" & lbl_precio_3.Text), New Font("ARIAL", 34), Brushes.Black, rect2, stringFormat)
            'Else
            '    e.Graphics.DrawString(("$" & txt_precio.Text), New Font("ARIAL", 34), Brushes.Black, rect2, stringFormat)
            'End If

            If mirutempresa = "87686300-6" Then


                Dim label_precio As String
                label_precio = lbl_precio_3.Text
 
                If label_precio.Length = 6 Then
                    e.Graphics.DrawString((lbl_precio_3.Text), New Font("Arial Black", 34), Brushes.Black, rect2, stringFormat)
                ElseIf label_precio.Length = 7 Then
                    e.Graphics.DrawString((lbl_precio_3.Text), New Font("Arial Black", 31), Brushes.Black, rect2, stringFormat)
                Else
                    e.Graphics.DrawString((lbl_precio_3.Text), New Font("Arial Black", 27), Brushes.Black, rect2, stringFormat)
                End If



                'e.Graphics.DrawString((lbl_precio_3.Text), New Font("ARIAL", 34), Brushes.Black, rect2, stringFormat)
            Else
                e.Graphics.DrawString(("$" & txt_precio.Text), New Font("ARIAL", 34), Brushes.Black, rect2, stringFormat)
            End If

            If mirutempresa = "87686300-6" Then
                e.Graphics.DrawString("$" & txt_precio.Text & " - " & "10% DCTO.", New Font("ARIAL", 11, FontStyle.Bold), Brushes.Black, margen + 70, 77)
            Else
                e.Graphics.DrawString(txt_codigo.Text, New Font("ARIAL", 11, FontStyle.Bold), Brushes.Black, margen + 134, 77)
            End If
            'Indica que no hay más hojas para imprimir, por lo que no se ejecutará nuevamente este procedimiento
            e.HasMorePages = False
                'Fuerza a que se liberen los recursos.
                Fuente.Dispose()

            End If






















            If RadioButton4.Checked = True Then


            Dim Fuente As Font
            Fuente = New Font("GothicE", 50, FontStyle.Bold)
            Dim Fuente1 As Font
            Fuente1 = New Font("Arial", 12, FontStyle.Bold)

            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center

            'Dim rect1 As New Rectangle(5, 1, 294, 10)
            ''(left,top,whidth,height )
            'Dim rect2 As New Rectangle(5, 54, 294, 40)

            'rect1.Height = 50
            'rect1.Width = 250

            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            format1.Alignment = StringAlignment.Far

            Dim margen As String

            If Radio_impresora_1.Checked = True Then
                margen = margen_etiquetas_1
            Else
                margen = margen_etiquetas_2
            End If



            Dim rect1 As New Rectangle(margen + 5, 1, 294, 10)
            '(left,top,whidth,height )
            Dim rect2 As New Rectangle(margen + 5, 54, 294, 40)

            e.Graphics.DrawString(mititularetiquetaempresa, New Font("ARIAL", 5, FontStyle.Bold), Brushes.Black, rect1, stringFormat)

            Dim descripcion_caracteres As String
            descripcion_caracteres = txt_nombre_producto.Text
            If descripcion_caracteres.Length > 31 Then
                descripcion_caracteres = descripcion_caracteres.Substring(0, 31)
            End If

            Dim descripcion_aplicacion As String
            descripcion_aplicacion = txt_aplicacion.Text
            If descripcion_aplicacion.Length > 34 Then
                descripcion_aplicacion = descripcion_aplicacion.Substring(0, 34)
            End If

            Dim descripcion_tecnico As String
            descripcion_tecnico = txt_numero_tecnico.Text
            If descripcion_tecnico.Length > 27 Then
                descripcion_tecnico = descripcion_tecnico.Substring(0, 27)
            End If

            e.Graphics.DrawString(descripcion_caracteres, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 59, 28)
            'e.Graphics.DrawString(descripcion_aplicacion, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 59, 27)
            ' e.Graphics.DrawString(descripcion_tecnico, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 59, 39)

            'If txt_factor.Text <> "0" And txt_factor.Text <> "" Then
            '    e.Graphics.DrawString(txt_factor.Text, New Font("ARIAL", 7, FontStyle.Bold), Brushes.Black, margen + 242, 39, format1)
            'End If

            e.Graphics.DrawString((txt_codigo.Text), New Font("ARIAL", 30), Brushes.Black, rect2, stringFormat)


            'Indica que no hay más hojas para imprimir, por lo que no se ejecutará nuevamente este procedimiento
            e.HasMorePages = False
            'Fuerza a que se liberen los recursos.
            Fuente.Dispose()

        End If



        If RadioButton7.Checked = True Then
            Dim Fuente As Font
            Fuente = New Font("GothicE", 50, FontStyle.Bold)
            Dim Fuente1 As Font
            Fuente1 = New Font("Arial", 12, FontStyle.Bold)

            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center

            'Dim rect1 As New Rectangle(5, 1, 294, 10)
            ''(left,top,whidth,height )
            'Dim rect2 As New Rectangle(5, 54, 294, 40)

            'rect1.Height = 50
            'rect1.Width = 250

            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            format1.Alignment = StringAlignment.Far

            Dim margen As String

            If Radio_impresora_1.Checked = True Then
                margen = margen_etiquetas_1
            Else
                margen = margen_etiquetas_2
            End If

            Dim rect1 As New Rectangle(margen + 1, 30, 294, 40)
            '(left,top,whidth,height )
            Dim rect2 As New Rectangle(margen + 5, 60, 294, 40)

            Dim descripcion_caracteres As String
            descripcion_caracteres = txt_nombre_producto.Text
            If descripcion_caracteres.Length > 34 Then
                descripcion_caracteres = descripcion_caracteres.Substring(0, 34)
            End If

            Dim descripcion_aplicacion As String
            descripcion_aplicacion = txt_aplicacion.Text
            If descripcion_aplicacion.Length > 34 Then
                descripcion_aplicacion = descripcion_aplicacion.Substring(0, 34)
            End If

            Dim descripcion_tecnico As String
            descripcion_tecnico = txt_numero_tecnico.Text
            If descripcion_tecnico.Length > 27 Then
                descripcion_tecnico = descripcion_tecnico.Substring(0, 27)
            End If

            e.Graphics.DrawString(descripcion_caracteres, New Font("ARIAL", 7, FontStyle.Regular), Brushes.Black, margen + 59, 5)
            e.Graphics.DrawString(descripcion_aplicacion, New Font("ARIAL", 7, FontStyle.Regular), Brushes.Black, margen + 59, 15)
            e.Graphics.DrawString(descripcion_tecnico, New Font("ARIAL", 7, FontStyle.Regular), Brushes.Black, margen + 59, 25)

            e.Graphics.DrawString(Form_menu_principal.dtp_fecha.Text, New Font("ARIAL", 7, FontStyle.Regular), Brushes.Black, margen + 245, 40, format1)
            e.Graphics.DrawString(txt_tipo_medida.Text, New Font("ARIAL", 7, FontStyle.Regular), Brushes.Black, margen + 245, 50, format1)
            e.Graphics.DrawString((lbl_precio_3.Text), New Font("ARIAL", 20), Brushes.Black, rect2, stringFormat)
            e.Graphics.DrawString("*" & (txt_codigo.Text) & "*", New Font("C39HrP36DlTt", 20), Brushes.Black, margen + 59, 37)

            'Indica que no hay más hojas para imprimir, por lo que no se ejecutará nuevamente este procedimiento
            e.HasMorePages = False
            'Fuerza a que se liberen los recursos.
            Fuente.Dispose()

        End If
    End Sub

    Private Sub txt_numero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numero.LostFocus
        txt_numero.BackColor = Color.White
    End Sub

    Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
        btn_imprimir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
        btn_imprimir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Form_buscador_productos_etiquetas.Show()
        Me.Enabled = False
    End Sub

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Panel_etiqueta_1.Location = New Point(1000, 1000)
        Panel_etiqueta_2.Location = New Point(307, 84)
        Panel_etiqueta_3.Location = New Point(1000, 1000)
        Panel_etiqueta_4.Location = New Point(1000, 1000)
        Panel_etiqueta_5.Location = New Point(1000, 1000)
        Panel_etiqueta_6.Location = New Point(1000, 1000)
        Panel_etiqueta_7.Location = New Point(1000, 1000)
        lbl_tamaño.Text = "TAMAÑO: ALTO 25 MM X  ANCHO 50 MM"
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        Panel_etiqueta_1.Location = New Point(1000, 1000)
        Panel_etiqueta_2.Location = New Point(1000, 1000)
        Panel_etiqueta_3.Location = New Point(307, 84)
        Panel_etiqueta_4.Location = New Point(1000, 1000)
        Panel_etiqueta_5.Location = New Point(1000, 1000)
        Panel_etiqueta_6.Location = New Point(1000, 1000)
        Panel_etiqueta_7.Location = New Point(1000, 1000)
        Panel_etiqueta_7.Location = New Point(1000, 1000)
        lbl_tamaño.Text = "TAMAÑO: ALTO 25 MM X  ANCHO 50 MM"
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Panel_etiqueta_1.Location = New Point(307, 84)
        Panel_etiqueta_2.Location = New Point(1000, 1000)
        Panel_etiqueta_3.Location = New Point(1000, 1000)
        Panel_etiqueta_4.Location = New Point(1000, 1000)
        Panel_etiqueta_5.Location = New Point(1000, 1000)
        Panel_etiqueta_6.Location = New Point(1000, 1000)
        lbl_tamaño.Text = "TAMAÑO: ALTO 50 MM X  ANCHO 30 MM"
    End Sub



    Sub limpiar_datos_productos()
        txt_nombre_producto.Text = ""
        lbl_nombre_producto_1.Text = "NOMBRE PRODUCTO"
        lbl_nombre_producto_2.Text = "NOMBRE PRODUCTO"
        lbl_nombre_producto_3.Text = "NOMBRE PRODUCTO"
        lbl_codigo_1.Text = "*CODIGO*"
        lbl_codigo_2.Text = "CODIGO"
        lbl_codigo_3.Text = "CODIGO"
        txt_marca.Text = ""
        txt_numero_tecnico.Text = ""
        lbl_nro_tecnico_1.Text = "NUMERO TECNICO"
        lbl_nro_tecnico_2.Text = "NUMERO TECNICO"
        lbl_nro_tecnico_3.Text = "NUMERO TECNICO"
        'lbl_codigo.Text = DS.Tables(DT.TableName).Rows(0).Item("cod_producto")
        'txt_factor.Text = ""
        'lbl_factor_1.Text = "FACTOR"
        'lbl_factor_2.Text = "FACTOR"
        txt_aplicacion.Text = ""
        lbl_aplicacion_1.Text = "APLICACION"
        lbl_aplicacion_2.Text = "APLICACION"
        'lbl_nombre_producto_3.Text = DS.Tables(DT.TableName).Rows(0).Item("nombre")
        txt_precio.Text = ""
        lbl_precio_3.Text = "$0"
        txt_tipo_medida.Text = ""
        'If lbl_precio_3.Text = "" Or lbl_precio_3.Text = "0" Then
        '    lbl_precio_3.Text = "$0"
        'Else
        '    lbl_precio_3.Text = "$" & Format(Int(lbl_precio_3.Text), "###,###,###")
        'End If
    End Sub


    Sub redondear_documento()


        Dim valor_total As Integer
        valor_total = lbl_precio_3.Text
        Dim finTotal As Integer
        Dim numerofinal As Integer

        finTotal = Strings.Right(valor_total, 2)
        numerofinal = Strings.Right(valor_total, 1)

        If numerofinal = 0 Then
            '  Exit Sub
        End If


        valor_total = valor_total - numerofinal

        Round(valor_total)

        lbl_precio_3.Text = valor_total




    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        Panel_etiqueta_1.Location = New Point(1000, 1000)
        Panel_etiqueta_2.Location = New Point(1000, 1000)
        Panel_etiqueta_3.Location = New Point(1000, 1000)
        Panel_etiqueta_4.Location = New Point(307, 84)
        Panel_etiqueta_5.Location = New Point(1000, 1000)
        Panel_etiqueta_6.Location = New Point(1000, 1000)
        Panel_etiqueta_7.Location = New Point(1000, 1000)
        lbl_tamaño.Text = "TAMAÑO: ALTO 25 MM X  ANCHO 50 MM"
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        Panel_etiqueta_1.Location = New Point(1000, 1000)
        Panel_etiqueta_2.Location = New Point(1000, 1000)
        Panel_etiqueta_3.Location = New Point(1000, 1000)
        Panel_etiqueta_4.Location = New Point(1000, 1000)
        Panel_etiqueta_5.Location = New Point(307, 84)
        Panel_etiqueta_6.Location = New Point(1000, 1000)
        Panel_etiqueta_7.Location = New Point(1000, 1000)
        lbl_tamaño.Text = "TAMAÑO: ALTO 20 MM X  ANCHO 30 MM"
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        Panel_etiqueta_1.Location = New Point(1000, 1000)
        Panel_etiqueta_2.Location = New Point(1000, 1000)
        Panel_etiqueta_3.Location = New Point(1000, 1000)
        Panel_etiqueta_4.Location = New Point(1000, 1000)
        Panel_etiqueta_5.Location = New Point(1000, 1000)
        Panel_etiqueta_6.Location = New Point(307, 84)
        Panel_etiqueta_7.Location = New Point(1000, 1000)
        lbl_tamaño.Text = "TAMAÑO: ALTO 10 MM X  ANCHO 20 MM"
    End Sub

    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton7.CheckedChanged
        Panel_etiqueta_1.Location = New Point(1000, 1000)
        Panel_etiqueta_2.Location = New Point(1000, 1000)
        Panel_etiqueta_3.Location = New Point(1000, 1000)
        Panel_etiqueta_4.Location = New Point(1000, 1000)
        Panel_etiqueta_5.Location = New Point(1000, 1000)
        Panel_etiqueta_6.Location = New Point(1000, 1000)
        Panel_etiqueta_7.Location = New Point(307, 84)
        lbl_tamaño.Text = "TAMAÑO: ALTO 50 MM X  ANCHO 30 MM"
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage

    End Sub
End Class