Imports System.Data
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Form_registro_de_imagenes_de_productos
    Dim MiPos As Integer
    Dim VarSeleccion As Integer
    Private Sub Form_registro_de_imagenes_de_productos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_registro_de_imagenes_de_productos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_registro_de_imagenes_de_productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        controles(False, True)
        actualizar_tabla()
        mostrar(0)
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub actualizar_tabla()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = "select * from productos_imagenes order by cod_auto asc"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        conexion.Close()
    End Sub

    'Sub mostrar_datos_clientes()
    '    conexion.Close()
    '    If txt_codigo_producto.Text <> "" Then
    '        DS2.Tables.Clear()
    '        DT2.Rows.Clear()
    '        DT2.Columns.Clear()
    '        DS2.Clear()
    '        conexion.Open()
    '        SC2.Connection = conexion
    '        SC2.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_producto.Text) & "'"
    '        DA2.SelectCommand = SC2
    '        DA2.Fill(DT2)
    '        DS2.Tables.Add(DT2)
    '        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
    '            txt_nombre_producto.Text = DS2.Tables(DT2.TableName).Rows(0).Item("nombre_producto")
    '        End If
    '    End If
    '    conexion.Close()
    'End Sub

    Sub mostrar(ByVal i As Integer)
        'Dim cancelado As String = ""
        'Dim retirado As String = ""
        Try
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_cod_auto.Text = DS.Tables(DT.TableName).Rows(i).Item("cod_auto")
                txt_codigo_producto.Text = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
                mostrar_datos_productos()
            End If
        Catch
        End Try

        Me.PictureBox1.Image = Nothing

        Try
            Dim Sql As String = "select imagen_producto from productos_imagenes where cod_auto='" & (txt_cod_auto.Text) & "'"
            Dim lector As MySqlDataReader
            conexion.Close()
            conexion.Open()
            If conexion.State = ConnectionState.Open Then
                Dim Imag As Byte()
                Dim Comando As New MySqlCommand(Sql, conexion)
                lector = Comando.ExecuteReader
                While lector.Read
                    Imag = lector("imagen_producto")
                    Me.PictureBox1.Image = Bytes_Imagen(Imag)
                End While
            End If
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub mostrar_datos_productos()
        conexion.Close()
        If txt_codigo_producto.Text <> "" Then
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            SC2.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_producto.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                txt_nombre_producto.Text = DS2.Tables(DT2.TableName).Rows(0).Item("nombre")
            End If
        End If


        'conexion.Close()
        'If txt_codigo_producto.Text <> "" Then
        '    DS2.Tables.Clear()
        '    DT2.Rows.Clear()
        '    DT2.Columns.Clear()
        '    DS2.Clear()
        '    conexion.Open()
        '    SC2.Connection = conexion
        '    SC2.CommandText = "select * from productos_imagenes where cod_producto ='" & (txt_codigo_producto.Text) & "' order by cod_auto desc"
        '    DA2.SelectCommand = SC2
        '    DA2.Fill(DT2)
        '    DS2.Tables.Add(DT2)
        '    If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
        '        txt_cod_auto.Text = DS2.Tables(DT2.TableName).Rows(0).Item("cod_auto")
        '    End If
        'End If

        Me.PictureBox1.Image = Nothing

        Try
            Dim Sql As String = "select * from productos_imagenes where cod_auto='" & (txt_cod_auto.Text) & "'"
            Dim lector As MySqlDataReader
            conexion.Close()
            conexion.Open()
            If conexion.State = ConnectionState.Open Then
                Dim Imag As Byte()
                Dim Comando As New MySqlCommand(Sql, conexion)
                lector = Comando.ExecuteReader
                While lector.Read
                    'txt_cod_auto.Text = lector("cod_auto")
                    Imag = lector("imagen_producto")
                    Me.PictureBox1.Image = Bytes_Imagen(Imag)
                End While
            End If
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub




    Sub mostrar_datos_productos_para_modificar()
        conexion.Close()
        If txt_codigo_producto.Text <> "" Then
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            SC2.CommandText = "select * from productos_imagenes where cod_producto ='" & (txt_codigo_producto.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)

            If DS2.Tables(DT2.TableName).Rows.Count = 1 Then
                txt_nombre_producto.Text = DS2.Tables(DT2.TableName).Rows(0).Item("nombre")
                conexion.Close()
                Exit Sub
            ElseIf DS2.Tables(DT2.TableName).Rows.Count > 1 Then
                conexion.Close()
                Form_seleccion_imagen_por_codigo.Show()
                Me.Enabled = False
                Exit Sub
            ElseIf DS2.Tables(DT2.TableName).Rows.Count < 1 Then
                txt_codigo_producto.Focus()
                conexion.Close()
                Exit Sub
            End If
        End If

        Me.PictureBox1.Image = Nothing

        Try
            Dim Sql As String = "select * from productos_imagenes where cod_producto='" & (txt_codigo_producto.Text) & "'"
            Dim lector As MySqlDataReader
            conexion.Close()
            conexion.Open()
            If conexion.State = ConnectionState.Open Then
                Dim Imag As Byte()
                Dim Comando As New MySqlCommand(Sql, conexion)
                lector = Comando.ExecuteReader
                While lector.Read
                    txt_cod_auto.Text = lector("cod_auto")
                    Imag = lector("imagen_producto")
                    Me.PictureBox1.Image = Bytes_Imagen(Imag)
                End While
            End If
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Sub mostrar_datos_productos_ingreso()
        conexion.Close()
        If txt_codigo_producto.Text <> "" Then
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            SC2.CommandText = "select * from productos where cod_producto ='" & (txt_codigo_producto.Text) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                txt_nombre_producto.Text = DS2.Tables(DT2.TableName).Rows(0).Item("nombre")
                conexion.Close()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txt_codigo_producto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_codigo_producto.GotFocus
        color_foco()
    End Sub

    Private Sub txt_codigo_producto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_codigo_producto.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If txt_codigo_producto.ReadOnly = False Then
            txt_cod_auto.Text = ""
            txt_nombre_producto.Text = ""
            Me.PictureBox1.Image = Nothing

            If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
                If VarSeleccion = 1 Then
                    mostrar_datos_productos_ingreso()
                End If
                If VarSeleccion = 2 Then
                    mostrar_datos_productos_para_modificar()
                End If
            End If
        End If
    End Sub

    Private Sub txt_codigo_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_codigo_producto.TextChanged

    End Sub

    Private Sub btn_abrir_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_abrir_1.Click
        abrir_imagen()
    End Sub

    Private Sub abrir_imagen()
        Dim filename As String
        Dim openfiler As New OpenFileDialog
        'Definiendo propiedades al openfiledialog
        With openfiler
            'directorio inicial
            .InitialDirectory = "C:\"
            'archivos que se pueden abrir
            '.Filter = "Archivos de imágen(*.jpg)|*.jpg|All Files (*.*)|*.*"
            .Filter = "All Files (*.*)|*.*|Ficheros PNG|*.png|Ficheros JPG o JPEG|*.jpg;*.jpeg|Ficheros BMP|*.bmp|Ficheros GIF|*.gif|Ficheros TIFF|*.tif"
            'indice del archivo de lectura por defecto
            .FilterIndex = 1
            'restaurar el directorio al cerrar el dialogo
            .RestoreDirectory = True
        End With
        'Evalua si el usuario hace click en el boton abrir
        If openfiler.ShowDialog = Windows.Forms.DialogResult.OK Then
            'Obteniendo la ruta completa del archivo xml
            filename = openfiler.FileName
            Me.PictureBox1.Image = Image.FromFile(filename)
            txt_extencion_1.Text = System.IO.Path.GetExtension(filename)
        End If
    End Sub

    Private Sub btn_guardar_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

        'SC2.Connection = conexion
        'SC2.CommandText = "INSERT INTO `productos_imagenes` (`cod_producto`) VALUES ('" & (txt_codigo_producto.Text) & "');"
        'DA2.SelectCommand = SC2
        'DA2.Fill(DT2)

        'mostrar_datos_productos_desc()

        If VarSeleccion = 1 Then
            Try
                Dim sql As String = "INSERT INTO productos_imagenes (cod_producto,imagen_producto) VALUES ('" & (txt_codigo_producto.Text) & "',?imagen_producto);"
                'Dim sql As String = "insert into tbl_imagenes(imagen)values(?imagen)"

                'Dim sql As String = "UPDATE productos_imagenes SET imagen_producto=?imagen_producto WHERE cod_auto='" & (txt_cod_auto.Text) & "'"
                Dim Comando As New MySqlCommand(sql, conexion)
                Dim Imag As Byte()
                Imag = Imagen_Bytes(Me.PictureBox1.Image)
                Comando.Parameters.AddWithValue("?imagen_producto", Imag)
                conexion.Close()
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Comando.ExecuteNonQuery()
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                lbl_mensaje.Visible = False
                Me.Enabled = True
                Exit Sub
            End Try
        End If

        If VarSeleccion = 2 Then
            Try
                Dim sql As String = "UPDATE productos_imagenes SET imagen_producto=?imagen_producto WHERE cod_auto='" & (txt_cod_auto.Text) & "'"
                Dim Comando As New MySqlCommand(sql, conexion)
                Dim Imag As Byte()
                Imag = Imagen_Bytes(Me.PictureBox1.Image)
                Comando.Parameters.AddWithValue("?imagen_producto", Imag)
                conexion.Close()
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Comando.ExecuteNonQuery()
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                lbl_mensaje.Visible = False
                Me.Enabled = True
                Exit Sub
            End Try
        End If




        actualizar_tabla()
        controles(False, True)
        lbl_mensaje.Visible = False
        Me.Enabled = True

        MsgBox("IMAGEN INGRESADA CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

    End Sub

    'convertir imagen a binario
    Private Function Imagen_Bytes(ByVal Imagen As Image) As Byte()
        'si hay imagen
        If Not Imagen Is Nothing Then
            'variable de datos binarios en stream(flujo)
            Dim Bin As New MemoryStream
            'convertir a bytes
            If txt_extencion_1.Text = ".png" Then
                Imagen.Save(Bin, Imaging.ImageFormat.Png)
            End If
            If txt_extencion_1.Text = ".jpeg" Then
                Imagen.Save(Bin, Imaging.ImageFormat.Jpeg)
            End If

            If txt_extencion_1.Text = ".jpg" Then
                Imagen.Save(Bin, Imaging.ImageFormat.Jpeg)
            End If
            'retorna binario
            Return Bin.GetBuffer
        Else
            Return Nothing
        End If
    End Function

    'convertir binario a imágen
    Private Function Bytes_Imagen(ByVal Imagen As Byte()) As Image
        Try
            'si hay imagen
            If Not Imagen Is Nothing Then
                'caturar array con memorystream hacia Bin
                Dim Bin As New MemoryStream(Imagen)
                'con el método FroStream de Image obtenemos imagen
                Dim Resultado As Image = Image.FromStream(Bin)
                'y la retornamos
                Return Resultado
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_primero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_primero.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        MiPos = 0
        mostrar(0)
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_anterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_anterior.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        If MiPos >= 1 Then
            MiPos -= 1
            mostrar(MiPos)
        End If
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_siguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_siguiente.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        If MiPos < DT.Rows.Count - 1 Then
            MiPos += 1
            mostrar(MiPos)
        End If
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_ultimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ultimo.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        MiPos = DT.Rows.Count - 1
        mostrar(MiPos)
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        VarSeleccion = 2
        controles(True, False)
        txt_codigo_producto.Focus()
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        VarSeleccion = 1
        controles(True, False)

        txt_codigo_producto.Text = ""
        txt_cod_auto.Text = ""
        txt_nombre_producto.Text = ""
        Me.PictureBox1.Image = Nothing

        txt_codigo_producto.Focus()
    End Sub

    Sub controles(ByVal a As Boolean, ByVal b As Boolean)

        btn_guardar.Enabled = a
        btn_abrir_1.Enabled = a
        btn_cancelar.Enabled = a
        'btn_limpiar.Enabled = a
        btn_nuevo.Enabled = b
        btn_modificar.Enabled = b
        btn_eliminar.Enabled = b

        txt_codigo_producto.ReadOnly = b

        btn_primero.Enabled = b
        btn_siguiente.Enabled = b
        btn_anterior.Enabled = b
        btn_ultimo.Enabled = b
        'GroupBox_cargar.Enabled = b
        'GroupBox_clientes.Enabled = a
        'GroupBox_posicion.Enabled = b
        'GroupBox_tecnico.Enabled = a
        'GroupBox1.Enabled = a
        ' GroupBox3.Enabled = a
        'GroupBox4.Enabled = a
        'GroupBox5.Enabled = a
        'GroupBox6.Enabled = a
        'GroupBox7.Enabled = a

        'If txt_rut_cliente.Enabled = True Then
        '    txt_rut_cliente.BackColor = Color.White
        'Else
        '    txt_rut_cliente.BackColor = SystemColors.Control
        'End If

        'If txt_cargar.Enabled = True Then
        '    txt_cargar.BackColor = Color.White
        'Else
        '    txt_cargar.BackColor = SystemColors.Control
        'End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        controles(False, True)
    End Sub

    Sub mostrar_imagen()
        conexion.Close()
        Me.PictureBox1.Image = Nothing
        Try
            Dim Sql As String = "select * from productos_imagenes where cod_auto='" & (txt_cod_auto.Text) & "'"
            Dim lector As MySqlDataReader
            conexion.Close()
            conexion.Open()
            If conexion.State = ConnectionState.Open Then
                Dim Imag As Byte()
                Dim Comando As New MySqlCommand(Sql, conexion)
                lector = Comando.ExecuteReader
                While lector.Read
                    'txt_cod_auto.Text = lector("cod_auto")
                    Imag = lector("imagen_producto")
                    Me.PictureBox1.Image = Bytes_Imagen(Imag)
                End While
            End If
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        If txt_cod_auto.Text <> "" Then
            Dim valormensaje As Integer
            valormensaje = MsgBox("¿DESEA ELIMINAR LA IMAGEN?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")
            If valormensaje = vbYes Then
                SC2.Connection = conexion
                SC2.CommandText = "DELETE FROM `productos_imagenes` WHERE `cod_auto`=''" & (txt_cod_auto.Text) & "';"
                DA2.SelectCommand = SC2
                DA2.Fill(DT2)
                actualizar_tabla()
            End If
        End If
    
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

    Private Sub btn_nuevo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.GotFocus
        color_foco()
    End Sub

    Private Sub btn_eliminar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.GotFocus
        color_foco()
    End Sub

    Private Sub btn_abrir_1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_abrir_1.GotFocus
        color_foco()
    End Sub

    Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
        color_foco()
    End Sub

    Private Sub btn_buscar_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_buscar_1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        color_foco()
    End Sub

    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        color_foco()
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        color_foco()
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        color_foco()
    End Sub

    Private Sub btn_primero_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_primero.GotFocus
        color_foco()
    End Sub

    Private Sub btn_anterior_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anterior.GotFocus
        color_foco()
    End Sub

    Private Sub btn_siguiente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.GotFocus
        color_foco()
    End Sub

    Private Sub btn_ultimo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ultimo.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_producto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre_producto.GotFocus
        color_foco()
    End Sub

    Private Sub txt_nombre_producto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre_producto.TextChanged

    End Sub
End Class