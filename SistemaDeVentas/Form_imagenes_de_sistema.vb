Imports System.Data
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Form_imagenes_de_sistema

    Private Sub Form_imagenes_de_sistema_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_imagenes_de_sistema_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_imagenes_de_sistema_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        Combo_imagen.Text = "-"
    End Sub

    Private Sub btn_abrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Private Sub btn_guardar_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_1.Click

        If Combo_imagen.Text = "" Then
            MsgBox("CAMPO TIPO DE IMAGEN VACIO, FAVOR LLENAR", MessageBoxIcon.Information, "ATENCION")
            Combo_imagen.Focus()
            Exit Sub
        End If

        If Combo_imagen.Text = "-" Then
            MsgBox("CAMPO TIPO DE IMAGEN VACIO, FAVOR LLENAR", MessageBoxIcon.Information, "ATENCION")
            Combo_imagen.Focus()
            Exit Sub
        End If

        Consultas_SQL("select * from imagenes_de_sistema")
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

        Else
            SC.Connection = conexion
            SC.CommandText = "INSERT INTO imagenes_de_sistema (logo_empresa_menu) VALUES ('1')"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        If Combo_imagen.Text = "LOGO EMPRESA MENU" Then
            Try
                Dim sql As String = "UPDATE imagenes_de_sistema SET logo_empresa_menu=?logo_empresa_menu WHERE cod_auto='1'"
                Dim Comando As New MySqlCommand(sql, conexion)
                Dim Imag As Byte()
                Imag = Imagen_Bytes(Me.PictureBox1.Image)
                Comando.Parameters.AddWithValue("?logo_empresa_menu", Imag)
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Comando.ExecuteNonQuery()
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Exit Sub
            End Try
        End If

        If Combo_imagen.Text = "LOGO EMPRESA TICKET" Then
            Try
                Dim sql As String = "UPDATE imagenes_de_sistema SET logo_empresa_ticket=?logo_empresa_ticket WHERE cod_auto='1'"
                Dim Comando As New MySqlCommand(sql, conexion)
                Dim Imag As Byte()
                Imag = Imagen_Bytes(Me.PictureBox1.Image)
                Comando.Parameters.AddWithValue("?logo_empresa_ticket", Imag)
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Comando.ExecuteNonQuery()
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Exit Sub
            End Try
        End If

        If Combo_imagen.Text = "LOGO EMPRESA REPORTES" Then
            Try
                Dim sql As String = "UPDATE imagenes_de_sistema SET logo_empresa_reportes=?logo_empresa_reportes WHERE cod_auto='1'"
                Dim Comando As New MySqlCommand(sql, conexion)
                Dim Imag As Byte()
                Imag = Imagen_Bytes(Me.PictureBox1.Image)
                Comando.Parameters.AddWithValue("?logo_empresa_reportes", Imag)
                conexion.Close()
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Comando.ExecuteNonQuery()
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Exit Sub
            End Try
        End If

        If Combo_imagen.Text = "LOGO EMPRESA FORMULARIOS" Then
            Try
                Dim sql As String = "UPDATE imagenes_de_sistema SET logo_empresa_formularios=?logo_empresa_formularios WHERE cod_auto='1'"
                Dim Comando As New MySqlCommand(sql, conexion)
                Dim Imag As Byte()
                Imag = Imagen_Bytes(Me.PictureBox1.Image)
                Comando.Parameters.AddWithValue("?logo_empresa_formularios", Imag)
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Comando.ExecuteNonQuery()
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Exit Sub
            End Try
        End If

        If Combo_imagen.Text = "ICONO MENU 1 DE MENU PRINCIPAL" Then
            Try
                Dim sql As String = "UPDATE imagenes_de_sistema SET icono_menu_1_de_menu_principal=?icono_menu_1_de_menu_principal WHERE cod_auto='1'"
                Dim Comando As New MySqlCommand(sql, conexion)
                Dim Imag As Byte()
                Imag = Imagen_Bytes(Me.PictureBox1.Image)
                Comando.Parameters.AddWithValue("?icono_menu_1_de_menu_principal", Imag)
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Comando.ExecuteNonQuery()
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Exit Sub
            End Try
        End If

        If Combo_imagen.Text = "ICONO MENU 2 DE MENU PRINCIPAL" Then
            Try
                Dim sql As String = "UPDATE imagenes_de_sistema SET icono_menu_2_de_menu_principal=?icono_menu_2_de_menu_principal WHERE cod_auto='1'"
                Dim Comando As New MySqlCommand(sql, conexion)
                Dim Imag As Byte()
                Imag = Imagen_Bytes(Me.PictureBox1.Image)
                Comando.Parameters.AddWithValue("?icono_menu_2_de_menu_principal", Imag)
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Comando.ExecuteNonQuery()
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Exit Sub
            End Try
        End If

        If Combo_imagen.Text = "ICONO MENU 3 DE MENU PRINCIPAL" Then
            Try
                Dim sql As String = "UPDATE imagenes_de_sistema SET icono_menu_3_de_menu_principal=?icono_menu_3_de_menu_principal WHERE cod_auto='1'"
                Dim Comando As New MySqlCommand(sql, conexion)
                Dim Imag As Byte()
                Imag = Imagen_Bytes(Me.PictureBox1.Image)
                Comando.Parameters.AddWithValue("?icono_menu_3_de_menu_principal", Imag)
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Comando.ExecuteNonQuery()
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Exit Sub
            End Try
        End If

        If Combo_imagen.Text = "ICONO MENU 4 DE MENU PRINCIPAL" Then
            Try
                Dim sql As String = "UPDATE imagenes_de_sistema SET icono_menu_4_de_menu_principal=?icono_menu_4_de_menu_principal WHERE cod_auto='1'"
                Dim Comando As New MySqlCommand(sql, conexion)
                Dim Imag As Byte()
                Imag = Imagen_Bytes(Me.PictureBox1.Image)
                Comando.Parameters.AddWithValue("?icono_menu_4_de_menu_principal", Imag)
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Comando.ExecuteNonQuery()
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Exit Sub
            End Try
        End If

        If Combo_imagen.Text = "ICONO MENU 5 DE MENU PRINCIPAL" Then
            Try
                Dim sql As String = "UPDATE imagenes_de_sistema SET icono_menu_5_de_menu_principal=?icono_menu_5_de_menu_principal WHERE cod_auto='1'"
                Dim Comando As New MySqlCommand(sql, conexion)
                Dim Imag As Byte()
                Imag = Imagen_Bytes(Me.PictureBox1.Image)
                Comando.Parameters.AddWithValue("?icono_menu_5_de_menu_principal", Imag)
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Comando.ExecuteNonQuery()
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Exit Sub
            End Try
        End If

        If Combo_imagen.Text = "ICONO MENU 6 DE MENU PRINCIPAL" Then
            Try
                Dim sql As String = "UPDATE imagenes_de_sistema SET icono_menu_6_de_menu_principal=?icono_menu_6_de_menu_principal WHERE cod_auto='1'"
                Dim Comando As New MySqlCommand(sql, conexion)
                Dim Imag As Byte()
                Imag = Imagen_Bytes(Me.PictureBox1.Image)
                Comando.Parameters.AddWithValue("?icono_menu_6_de_menu_principal", Imag)
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Comando.ExecuteNonQuery()
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Exit Sub
            End Try
        End If

        Combo_imagen.Text = "-"
        MsgBox("IMAGEN INGRESADA CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
    End Sub

    Private Sub btn_abrir_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_abrir_1.Click
        abrir_imagen()
    End Sub

    Private Sub btn_buscar_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_1.Click
        If Combo_imagen.Text = "" Then
            MsgBox("CAMPO TIPO DE IMAGEN VACIO, FAVOR LLENAR", MessageBoxIcon.Information, "ATENCION")
            Combo_imagen.Focus()
            Exit Sub
        End If

        If Combo_imagen.Text = "-" Then
            MsgBox("CAMPO TIPO DE IMAGEN VACIO, FAVOR LLENAR", MessageBoxIcon.Information, "ATENCION")
            Combo_imagen.Focus()
            Exit Sub
        End If

        If Combo_imagen.Text = "LOGO EMPRESA MENU" Then
            Try
                Dim Sql As String = "select logo_empresa_menu from imagenes_de_sistema where cod_auto=1"
                Dim lector As MySqlDataReader
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Dim Imag As Byte()
                    Dim Comando As New MySqlCommand(Sql, conexion)
                    lector = Comando.ExecuteReader
                    While lector.Read
                        Imag = lector("logo_empresa_menu")
                        Me.PictureBox1.Image = Bytes_Imagen(Imag)
                    End While
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

        If Combo_imagen.Text = "LOGO EMPRESA TICKET" Then
            Try
                Dim Sql As String = "select logo_empresa_ticket from imagenes_de_sistema where cod_auto=1"
                Dim lector As MySqlDataReader
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Dim Imag As Byte()
                    Dim Comando As New MySqlCommand(Sql, conexion)
                    lector = Comando.ExecuteReader
                    While lector.Read
                        Imag = lector("logo_empresa_ticket")
                        Me.PictureBox1.Image = Bytes_Imagen(Imag)
                    End While
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

        If Combo_imagen.Text = "LOGO EMPRESA REPORTES" Then
            Try
                Dim Sql As String = "select logo_empresa_reportes from imagenes_de_sistema where cod_auto=1"
                'Dim Sql As String = "select logo_inmobiliaria from imagenes_de_sistema where cod_auto=1"
                Dim lector As MySqlDataReader
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Dim Imag As Byte()
                    Dim Comando As New MySqlCommand(Sql, conexion)
                    lector = Comando.ExecuteReader
                    While lector.Read
                        Imag = lector("logo_empresa_reportes")
                        'Imag = lector("logo_inmobiliaria")
                        Me.PictureBox1.Image = Bytes_Imagen(Imag)
                    End While
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

        If Combo_imagen.Text = "LOGO EMPRESA FORMULARIOS" Then
            Try
                Dim Sql As String = "select logo_empresa_formularios from imagenes_de_sistema where cod_auto=1"
                Dim lector As MySqlDataReader
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Dim Imag As Byte()
                    Dim Comando As New MySqlCommand(Sql, conexion)
                    lector = Comando.ExecuteReader
                    While lector.Read
                        Imag = lector("logo_empresa_formularios")
                        Me.PictureBox1.Image = Bytes_Imagen(Imag)
                    End While
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

        If Combo_imagen.Text = "ICONO MENU 1 DE MENU PRINCIPAL" Then
            Try
                Dim Sql As String = "select icono_menu_1_de_menu_principal from imagenes_de_sistema where cod_auto=1"
                Dim lector As MySqlDataReader
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Dim Imag As Byte()
                    Dim Comando As New MySqlCommand(Sql, conexion)
                    lector = Comando.ExecuteReader
                    While lector.Read
                        Imag = lector("icono_menu_1_de_menu_principal")
                        Me.PictureBox1.Image = Bytes_Imagen(Imag)
                    End While
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

        If Combo_imagen.Text = "ICONO MENU 2 DE MENU PRINCIPAL" Then
            Try
                Dim Sql As String = "select icono_menu_2_de_menu_principal from imagenes_de_sistema where cod_auto=1"
                Dim lector As MySqlDataReader
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Dim Imag As Byte()
                    Dim Comando As New MySqlCommand(Sql, conexion)
                    lector = Comando.ExecuteReader
                    While lector.Read
                        Imag = lector("icono_menu_2_de_menu_principal")
                        Me.PictureBox1.Image = Bytes_Imagen(Imag)
                    End While
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

        If Combo_imagen.Text = "ICONO MENU 3 DE MENU PRINCIPAL" Then
            Try
                Dim Sql As String = "select icono_menu_3_de_menu_principal from imagenes_de_sistema where cod_auto=1"
                Dim lector As MySqlDataReader
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Dim Imag As Byte()
                    Dim Comando As New MySqlCommand(Sql, conexion)
                    lector = Comando.ExecuteReader
                    While lector.Read
                        Imag = lector("icono_menu_3_de_menu_principal")
                        Me.PictureBox1.Image = Bytes_Imagen(Imag)
                    End While
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

        If Combo_imagen.Text = "ICONO MENU 4 DE MENU PRINCIPAL" Then
            Try
                Dim Sql As String = "select icono_menu_4_de_menu_principal from imagenes_de_sistema where cod_auto=1"
                Dim lector As MySqlDataReader
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Dim Imag As Byte()
                    Dim Comando As New MySqlCommand(Sql, conexion)
                    lector = Comando.ExecuteReader
                    While lector.Read
                        Imag = lector("icono_menu_4_de_menu_principal")
                        Me.PictureBox1.Image = Bytes_Imagen(Imag)
                    End While
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

        If Combo_imagen.Text = "ICONO MENU 5 DE MENU PRINCIPAL" Then
            Try
                Dim Sql As String = "select icono_menu_5_de_menu_principal from imagenes_de_sistema where cod_auto=1"
                Dim lector As MySqlDataReader
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Dim Imag As Byte()
                    Dim Comando As New MySqlCommand(Sql, conexion)
                    lector = Comando.ExecuteReader
                    While lector.Read
                        Imag = lector("icono_menu_5_de_menu_principal")
                        Me.PictureBox1.Image = Bytes_Imagen(Imag)
                    End While
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

        If Combo_imagen.Text = "ICONO MENU 6 DE MENU PRINCIPAL" Then
            Try
                Dim Sql As String = "select icono_menu_6_de_menu_principal from imagenes_de_sistema where cod_auto=1"
                Dim lector As MySqlDataReader
                conexion.Open()
                If conexion.State = ConnectionState.Open Then
                    Dim Imag As Byte()
                    Dim Comando As New MySqlCommand(Sql, conexion)
                    lector = Comando.ExecuteReader
                    While lector.Read
                        Imag = lector("icono_menu_6_de_menu_principal")
                        Me.PictureBox1.Image = Bytes_Imagen(Imag)
                    End While
                End If
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Sub cargar_logo()
        Try
            Dim Sql As String = "select logo_empresa_formularios from imagenes_de_sistema where cod_auto=1"
            Dim lector As MySqlDataReader
            conexion.Open()
            If conexion.State = ConnectionState.Open Then
                Dim Imag As Byte()
                Dim Comando As New MySqlCommand(Sql, conexion)
                lector = Comando.ExecuteReader
                While lector.Read
                    Imag = lector("logo_empresa_formularios")
                    Me.PictureBox_logo.Image = Bytes_Imagen(Imag)
                End While
            End If
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Combo_software_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_imagen.SelectedIndexChanged
        Try
            Me.PictureBox1.Image.Dispose()
        Catch ex As NullReferenceException
        End Try
        Me.PictureBox1.Image = Nothing

        If Combo_imagen.Text = "LOGO EMPRESA REPORTES" Then
            txt_tamaño.Text = "250 X 70 PX"
        Else
            txt_tamaño.Text = ""
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
End Class