Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_respaldo
    Dim ruta_archivo_respaldo As String
    Dim PathArchivo As String
    Dim strStreamW As Stream = Nothing
    'SaveFileDialog (en este proyecto se llama respaldar ), donde puedes dar el nombre y la ruta donde quieres respaldar.
    'FolderBrowserDialog ( que se llama carpeta )con esto te deberia funcionar.
    Private Sub btn_siguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_siguiente.Click


        Dim nombre_servidor As String
        Dim nombre_servidor_remoto As String
        Dim base_de_datos As String
        Dim clave_base_de_datos As String
        Dim usuario As String
        Dim recinto As String
        Dim rut_empresa As String

        base_de_datos = ""

        For i = 0 To Form_menu_principal.grilla_conexiones.Rows.Count - 1

            nombre_servidor = Form_menu_principal.grilla_conexiones.Rows(i).Cells(0).Value.ToString
            nombre_servidor_remoto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(1).Value.ToString
            base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(2).Value.ToString
            clave_base_de_datos = Form_menu_principal.grilla_conexiones.Rows(i).Cells(3).Value.ToString
            usuario = Form_menu_principal.grilla_conexiones.Rows(i).Cells(4).Value.ToString
            recinto = Form_menu_principal.grilla_conexiones.Rows(i).Cells(5).Value.ToString
            rut_empresa = Form_menu_principal.grilla_conexiones.Rows(i).Cells(6).Value.ToString

            recinto = Trim(Replace(recinto, "'", "´"))

            If SucursalSeleccionada = recinto Then

                Exit For

            End If

        Next















        If Form_menu_principal.Enabled = True Then


            respaldar.DefaultExt = "sql"
            Dim pathmysql As String
            Dim comando As String

            pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MYSQL Server 5.8", "Location", 0)

            If pathmysql = Nothing Then
                pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MYSQL Server 5.7", "Location", 0)
            End If

            If pathmysql = Nothing Then
                pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MYSQL Server 5.6", "Location", 0)
            End If

            If pathmysql = Nothing Then
                pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MYSQL Server 5.5", "Location", 0)
            End If

            If pathmysql = Nothing Then
                pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MYSQL Server 5.4", "Location", 0)
            End If

            If pathmysql = Nothing Then
                pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MYSQL Server 5.3", "Location", 0)
            End If

            If pathmysql = Nothing Then
                pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MYSQL Server 5.2", "Location", 0)
            End If

            If pathmysql = Nothing Then
                pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MySQL Server 5.1", "Location", 0)
            End If

            If pathmysql = Nothing Then
                pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MYSQL Server 5.0", "Location", 0)
            End If













            If pathmysql = Nothing Then
                pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\MySQL AB\MySQL Server 5.8", "Location", 0)
            End If


            If pathmysql = Nothing Then
                pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\MySQL AB\MySQL Server 5.7", "Location", 0)
            End If

            If pathmysql = Nothing Then
                pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\MySQL AB\MySQL Server 5.7", "Location", 0)
            End If

            If pathmysql = Nothing Then
                pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\MySQL AB\MySQL Server 5.6", "Location", 0)
            End If

            If pathmysql = Nothing Then
                pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\MySQL AB\MySQL Server 5.5", "Location", 0)
            End If

            If pathmysql = Nothing Then
                pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\MySQL AB\MySQL Server 5.4", "Location", 0)
            End If

            If pathmysql = Nothing Then
                pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\MySQL AB\MySQL Server 5.3", "Location", 0)
            End If

            If pathmysql = Nothing Then
                pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\MySQL AB\MySQL Server 5.2", "Location", 0)
            End If

            If pathmysql = Nothing Then
                pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\MySQL AB\MySQL Server 5.1", "Location", 0)
            End If

            If pathmysql = Nothing Then
                pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\MySQL AB\MySQL Server 5.0", "Location", 0)
            End If






















            If pathmysql = Nothing Then
                MsgBox("NO SE ENCONTRO EN TU EQUIPO MYSQL, ESCOGE LA CARPETA DONDE ESTA UBICADO", MsgBoxStyle.Information, "ATENCION")
                carpeta.ShowDialog()
                pathmysql = carpeta.SelectedPath
                Exit Sub
            End If



            respaldar.Filter = "File MYSQL (*.sql)|*.sql"
            ' If respaldar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            lbl_mensaje.Visible = True
            Me.Enabled = False
            Try

                If Directory.Exists(ruta_archivo_respaldo) = False Then ' si no existe la carpeta se crea
                    Directory.CreateDirectory(ruta_archivo_respaldo)
                End If

                PathArchivo = ruta_archivo_respaldo & "\" & "RESPALDO_" & SucursalSeleccionada & "_" & Form_menu_principal.dtp_fecha.Text & ".sql"
                PathArchivo = Replace(PathArchivo, "-", "")

                If File.Exists(PathArchivo) Then
                    My.Computer.FileSystem.DeleteFile(PathArchivo)
                End If

                comando = pathmysql & "\bin\mysqldump --user=root --password=1234 --databases " & (base_de_datos) & " -r """ & PathArchivo & """"

                Shell(comando, AppWinStyle.MinimizedFocus, True)

                MsgBox("RESPALDO REALIZADO EXITOSAMENTE", MsgBoxStyle.Information, "ATENCION")

                SC.Connection = conexion
                SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PRODUCTOS','RESPALDO DE DATOS','BASE DE DATOS','" & (Form_menu_principal.dtp_fecha.Text) & "','CREACION','" & (miusuario) & "')"
                DA.SelectCommand = SC
                DA.Fill(DT)

                Me.Enabled = True
                lbl_mensaje.Visible = False
                Me.Close()
            Catch EX As Exception
                MsgBox("OCURRIO UN ERROR AL RESPALDAR", MsgBoxStyle.Critical, "ATENCION")
            End Try
        Else
            MsgBox("ERROR DE INGRESO", MsgBoxStyle.Critical)
            Me.Close()
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub Form_respaldo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_respaldo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_respaldo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        cargar_rutas_respaldo()
        'RichTextBox1.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub cargar_rutas_respaldo()

        conexion.Close()
        DS2.Tables.Clear()
        DT2.Rows.Clear()
        DT2.Columns.Clear()
        DS2.Clear()
        conexion.Open()

        SC2.Connection = conexion
        SC2.CommandText = "select * from rutas_archivos"
        DA2.SelectCommand = SC2
        DA2.Fill(DT2)
        DS2.Tables.Add(DT2)

        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
            ruta_archivo_respaldo = DS2.Tables(DT2.TableName).Rows(0).Item("archivo_respaldo")
        End If
        conexion.Close()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub btn_siguiente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.GotFocus
        btn_siguiente.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_siguiente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_siguiente.LostFocus
        btn_siguiente.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub lbl_mensaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_mensaje.Click

    End Sub
End Class