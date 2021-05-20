Imports System.IO
Imports System.Drawing.Drawing2D
Public Class Form_productos_modificados_arana
    Dim mifecha2 As String
    Dim mifecha4 As String

    Private Sub Form_productos_modificados_arana_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 1024
        Me.Height = 728
        Centrar()
        cargar_logo()

        grilla_inventario.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular)
        txt_productos.Text = ""
        'txt_total.Text = ""

        dtp_desde.Value = dtp_desde.Value.AddDays(Val(-7))
    End Sub

    Public Sub Centrar()
        Dim tamaño As Rectangle = My.Computer.Screen.Bounds
        Dim posicionX As Integer = (tamaño.Width - Me.Width) \ 2
        Dim posicionY As Integer = (tamaño.Height - Me.Height) \ 2
        Me.Location = New Point(posicionX, posicionY - 20)
    End Sub

    Sub cargar_logo()
        Try
            'PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub Form_productos_modificados_arana_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_productos_modificados_arana_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub
    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub

    Sub mostrar_malla_inventario()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion

        'SC.CommandText = "select * from productos, familia where productos.familia=familia.codigo and COSTO >= 1 and cantidad >= 1 group by cod_producto"
        SC.CommandText = "select * from productos, familia where productos.familia=familia.codigo and productos.fecha_modificacion >='" & (mifecha2) & "' and productos.fecha_modificacion <= '" & (mifecha4) & "' group by cod_producto"

        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_inventario.Rows.Clear()
        grilla_inventario.Columns.Clear()
        grilla_inventario.Columns.Add("", "CODIGO")
        grilla_inventario.Columns.Add("", "NOMBRE")
        grilla_inventario.Columns.Add("", "NRO. TECNICO")
        grilla_inventario.Columns.Add("", "APLICACION")
        grilla_inventario.Columns.Add("", "FAMILIA")
        grilla_inventario.Columns.Add("", "PRECIO")
        grilla_inventario.Columns.Add("", "MODIFICACION")
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim fecha_modificacion As Date
                Dim fecha_modificacion_text As String

                fecha_modificacion = DS.Tables(DT.TableName).Rows(i).Item("fecha_modificacion")
                fecha_modificacion_text = fecha_modificacion.ToString("dd-MM-yyy")

                grilla_inventario.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"),
                                            DS.Tables(DT.TableName).Rows(i).Item("nombre"),
                                             DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"),
                                              DS.Tables(DT.TableName).Rows(i).Item("aplicacion"),
                                               DS.Tables(DT.TableName).Rows(i).Item("nombre_familia"),
                                                DS.Tables(DT.TableName).Rows(i).Item("precio"),
                                                 fecha_modificacion_text)
            Next
        End If

        If grilla_inventario.Rows.Count <> 0 Then
            If grilla_inventario.Columns(0).Width = 100 Then
                grilla_inventario.Columns(0).Width = 99
            Else
                grilla_inventario.Columns(0).Width = 100
            End If
            grilla_inventario.Columns(1).Width = 150
            grilla_inventario.Columns(2).Width = 136
            grilla_inventario.Columns(3).Width = 100
            grilla_inventario.Columns(4).Width = 100
            grilla_inventario.Columns(5).Width = 100
            grilla_inventario.Columns(6).Width = 100

            grilla_inventario.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_inventario.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_inventario.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_inventario.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_inventario.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_inventario.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_inventario.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End If
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        fecha()
        mostrar_malla_inventario()
        calcular_totales()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""
        If grilla_inventario.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            dtp_desde.Focus()
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
        ruta_archivo = My.Computer.FileSystem.SpecialDirectories.Desktop & "\INVENTARIO " & mirecintoempresa & ".csv"

        'Dim cadenaubicacion As String
        'Dim directorio As New FolderBrowserDialog
        'If directorio.ShowDialog = DialogResult.OK Then
        '    cadenaubicacion = directorio.SelectedPath
        Try
            Dim stream As Stream
            Dim escritor As StreamWriter
            Dim fila = grilla_inventario.Rows.Count
            Dim columnas = grilla_inventario.Columns.Count
            Dim archivo As String = ruta_archivo
            Dim linea As String = ""
            Dim filadata, column As Int32

            File.Delete(archivo)
            stream = File.OpenWrite(archivo)
            escritor = New StreamWriter(stream, System.Text.Encoding.UTF8)

            For column = 0 To columnas - 1
                linea = linea & grilla_inventario.Columns(column).HeaderText & ";"
            Next
            linea = Mid(CStr(linea), 1, linea.ToString.Length - 1)
            escritor.WriteLine(linea)
            linea = Nothing
            For filadata = 0 To fila - 1
                For column = 0 To columnas - 1
                    linea = linea & CStr(grilla_inventario.Item(column, filadata).Value) & ";"
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

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            grilla_inventario.Rows.Clear()
            grilla_inventario.Columns.Clear()
            'txt_total.Text = ""
            txt_productos.Text = ""
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

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        grilla_inventario.Rows.Clear()
        'txt_total.Text = ""
        txt_productos.Text = ""
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Sub calcular_totales()

        'Dim totalgrilla As Long

        txt_productos.Text = grilla_inventario.Rows.Count

        If txt_productos.Text = "" Then
            txt_productos.Text = "0"
        End If
        'Calcular el total general
        'txt_total.Text = 0
        'For i = 0 To grilla_inventario.Rows.Count - 1
        '    totalgrilla = Val(grilla_inventario.Rows(i).Cells(8).Value.ToString)
        '    txt_total.Text = Val(txt_total.Text) + Val(totalgrilla)
        'Next

        'If txt_total.Text = "" Or txt_total.Text = "0" Then
        '    txt_total.Text = "0"
        'Else
        '    txt_total.Text = Format(Int(txt_total.Text), "###,###,###")
        'End If

    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        grilla_inventario.Rows.Clear()
        'txt_total.Text = ""
        txt_productos.Text = ""
    End Sub

    Private Sub PictureBox_logo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox_logo.Click

    End Sub

    Private Sub lbl_mensaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_mensaje.Click

    End Sub
End Class