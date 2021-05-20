Imports System.IO

Public Class Form_exportar_productos_pagina
    Dim consulta_busqueda As String

    Private Sub Form_exportar_productos_pagina_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_exportar_productos_pagina_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F1 Then
            txt_busqueda.Focus()
        End If

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

    Private Sub Form_exportar_productos_pagina_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        txt_busqueda.Focus()
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        buscar()
        'lbl_resultado.Location = New Point(1024 - lbl_resultado.Width - 7, 30)
    End Sub

    Private Sub txt_busqueda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_busqueda.KeyPress
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
            buscar()
        End If
    End Sub

    Sub buscar()
        lbl_mensaje.Visible = True
        Me.Enabled = False

        Dim precio As String
        Dim descuento As String
        'Dim medida_1 As String
        'Dim medida_2 As String
        'Dim medida_3 As String
        'Dim volumen As String





        consulta_busqueda = "select cod_producto as SKU, nombre as Nombre, numero_tecnico as 'NUMERO TECNICO', aplicacion as 'APLICACION', cantidad as CANTIDAD, precio as PRECIO, familia.nombre_familia as 'FAMILIA', subfamilia.nombre_subfamilia as 'SUBFAMILIA', subfamilia_dos.nombre_subfamilia as 'SUBFAMILIA DOS' , subfamilia_dos.medida_1 as 'MEDIDA UNO' , subfamilia_dos.medida_2 as 'MEDIDA DOS' , subfamilia_dos.medida_1 as 'MEDIDA TRES'  , subfamilia_dos.m as 'M'  , subfamilia_dos.o as 'O' ,  subfamilia_dos.volumen as 'VOLUMEN' , subfamilia_dos.cod_auto as 'COD. SF2' from productos, familia, subfamilia, subfamilia_dos where productos.familia=familia.codigo and productos.subfamilia=subfamilia.cod_auto and productos.subfamilia_dos=subfamilia_dos.cod_auto and productos.familia <> '0' and productos.subfamilia_dos <> '0' and activo='SI' group by productos.cod_producto order by productos.fecha_modificacion desc "



        Dim cadena As String
            Dim tabla() As String
            Dim n As Integer

            cadena = txt_busqueda.Text
            '   Dim split As String() = words.Split(New [Char]() {" "c, ","c, "."c, ":"c})
            tabla = Split(cadena, " ")

        If txt_busqueda.Text <> "" Then
            For n = 0 To UBound(tabla, 1)
                'consulta_busqueda = consulta_busqueda & "AND CONCAT_WS(' ',COD_PRODUCTO, NOMBRE, APLICACION, NUMERO_TECNICO, nombre_proveedor) LIKE '" & ("%" & tabla(n) & "%") & "'"
                consulta_busqueda = consulta_busqueda & "AND CONCAT_WS(' ',cod_producto, nombre, numero_tecnico, aplicacion, cantidad, precio, proveedores.nombre_proveedor, productos.ultima_compra, productos.cantidad_ULTIMA_COMPRA, costo, cantidad_minima, familia.nombre_familia, subfamilia.nombre_subfamilia, subfamilia_dos.nombre_subfamilia) LIKE '" & ("%" & tabla(n) & "%") & "'"
            Next
        End If

        grilla_estado_de_cuenta.Rows.Clear()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = consulta_busqueda
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                precio = Val(DS.Tables(DT.TableName).Rows(i).Item("precio"))

                descuento = Int(((precio) * "5") / 100)
                precio = Int(precio) - Int(descuento)

                Dim Tabla_detalle As String = ""
                Dim Nombre_detalle As String = DS.Tables(DT.TableName).Rows(i).Item("NOMBRE")
                Dim Aplicacion_detalle As String = DS.Tables(DT.TableName).Rows(i).Item("APLICACION")
                Dim Numero_tecnico_detalle As String = DS.Tables(DT.TableName).Rows(i).Item("NUMERO TECNICO")

                Tabla_detalle = "<table><tbody><tr><td><strong>Descripción</strong></td><td>" & Nombre_detalle & " " & Numero_tecnico_detalle & "</td></tr>
 <tr><td><strong>Aplicacion</strong></td><td>" & Aplicacion_detalle & "</td></tr></tbody></table>"

                grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("SKU"),
                                                     DS.Tables(DT.TableName).Rows(i).Item("NOMBRE") & " " & DS.Tables(DT.TableName).Rows(i).Item("NUMERO TECNICO") & " (" & DS.Tables(DT.TableName).Rows(i).Item("SKU") & ")",
                                                      Tabla_detalle,
                                                         DS.Tables(DT.TableName).Rows(i).Item("CANTIDAD"),
                                                          precio,
                                                           DS.Tables(DT.TableName).Rows(i).Item("FAMILIA"),
                                                            DS.Tables(DT.TableName).Rows(i).Item("SUBFAMILIA DOS"),
                                                                 DS.Tables(DT.TableName).Rows(i).Item("VOLUMEN"),
                                                                  "https://www.arana.cl/imagenes%20de%20productos/" & DS.Tables(DT.TableName).Rows(i).Item("COD. SF2") & ".jpeg")
            Next

            grilla_estado_de_cuenta.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_estado_de_cuenta.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_estado_de_cuenta.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_estado_de_cuenta.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_estado_de_cuenta.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_estado_de_cuenta.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'grilla_estado_de_cuenta.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'grilla_estado_de_cuenta.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'grilla_estado_de_cuenta.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'grilla_estado_de_cuenta.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        If grilla_estado_de_cuenta.Rows.Count <> 0 Then
            If grilla_estado_de_cuenta.Columns(0).Width = 100 Then
                grilla_estado_de_cuenta.Columns(0).Width = 99
            Else
                grilla_estado_de_cuenta.Columns(0).Width = 100
            End If
            grilla_estado_de_cuenta.Columns(1).Width = 350
            grilla_estado_de_cuenta.Columns(2).Width = 350
            grilla_estado_de_cuenta.Columns(3).Width = 120
            grilla_estado_de_cuenta.Columns(4).Width = 120
            grilla_estado_de_cuenta.Columns(5).Width = 350
            grilla_estado_de_cuenta.Columns(6).Width = 350
            grilla_estado_de_cuenta.Columns(7).Width = 120
            grilla_estado_de_cuenta.Columns(8).Width = 350


        End If

        lbl_mensaje.Visible = False
        Me.Enabled = True

    End Sub

    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_csv.Click
        Dim mensaje As String = ""

        Dim ruta_archivo As String
        Dim hora_sistema As String
        Dim fecha_sistema As String

        hora_sistema = Form_menu_principal.lbl_hora.Text
        hora_sistema = hora_sistema.Replace(":", " ")

        fecha_sistema = Format(Today.Date, "Long Date")

        fecha_sistema = fecha_sistema.Replace(",", " ")

        ruta_archivo = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & txt_busqueda.Text & " " & fecha_sistema & " " & hora_sistema & ".csv"

        If grilla_estado_de_cuenta.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            txt_busqueda.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        lbl_mensaje.Visible = True
        Me.Enabled = False

        exportar_excel()

        lbl_mensaje.Visible = False
        Me.Enabled = True

    End Sub

    Private Function exportar_excel() As Boolean
        Dim ruta_archivo As String
        Dim hora_sistema As String
        Dim fecha_sistema As String

        hora_sistema = Form_menu_principal.lbl_hora.Text
        hora_sistema = hora_sistema.Replace(":", " ")

        fecha_sistema = Format(Today.Date, "Long Date")

        fecha_sistema = fecha_sistema.Replace(",", " ")

        ruta_archivo = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & txt_busqueda.Text & " " & fecha_sistema & " " & hora_sistema & ".csv"





        'Dim cadenaubicacion As String
        'Dim directorio As New FolderBrowserDialog
        'If directorio.ShowDialog = DialogResult.OK Then
        '    cadenaubicacion = directorio.SelectedPath
        Try
            Dim stream As Stream
            Dim escritor As StreamWriter
            Dim fila = grilla_estado_de_cuenta.Rows.Count
            Dim columnas = grilla_estado_de_cuenta.Columns.Count
            Dim archivo As String = ruta_archivo
            Dim linea As String = ""
            Dim filadata, column As Int32

            File.Delete(archivo)
            stream = File.OpenWrite(archivo)
            escritor = New StreamWriter(stream, System.Text.Encoding.UTF8)

            For column = 0 To columnas - 1
                linea = linea & grilla_estado_de_cuenta.Columns(column).HeaderText & ";"
            Next
            linea = Mid(CStr(linea), 1, linea.ToString.Length - 1)
            escritor.WriteLine(linea)
            linea = Nothing
            For filadata = 0 To fila - 1
                For column = 0 To columnas - 1
                    linea = linea & CStr(grilla_estado_de_cuenta.Item(column, filadata).Value) & ";"
                Next
                linea = Mid(CStr(linea), 1, linea.ToString.Length - 1)
                escritor.WriteLine(linea)
                linea = Nothing
            Next
            escritor.Close()
            Try
                ''Process.Start(archivo)
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        'End If
        'Return False
    End Function

    Private Sub btn_exportar_excel_Click_1(sender As Object, e As EventArgs) Handles btn_exportar_excel.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_estado_de_cuenta, save.FileName)
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
        For c As Integer = 0 To grilla_estado_de_cuenta.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_estado_de_cuenta.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_estado_de_cuenta.RowCount - 1
            For c As Integer = 0 To grilla_estado_de_cuenta.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_estado_de_cuenta.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub
End Class