Imports Microsoft.Win32
Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D
Imports System.Resources
Imports System.Deployment.Application
Imports System.Runtime.InteropServices
Imports System.Net.NetworkInformation
Imports System.Net

Public Class form_Ingreso
    Dim ip_conexion As String
    Dim usuario_conexion As String
    Dim bd_conexion As String
    Dim Rut_Empresa_Seleccionada As String
    Dim ingresar As String


    Private Sub form_Ingreso_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Form_menu_principal.Enabled = False Then
            End
        End If
    End Sub

    Private Sub form_Ingreso_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub form_Ingreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls


        Try
            lbl_version.Text = "VERSION " & ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
        Catch
        End Try

        Try
            Me.lbl_equipo.Text = System.Windows.Forms.SystemInformation.ComputerName
            nombre_pc = lbl_equipo.Text
        Catch
        End Try

        Try
            Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
            lbl_mac.Text = nics(1).GetPhysicalAddress.ToString
        Catch
        End Try

        'Registry.CurrentUser.CreateSubKey("Software\\ClickOffice\\SistemaDeVentas\\TipoImpresion")
        'Dim Regkey1 As RegistryKey
        'Regkey1 = Registry.CurrentUser.OpenSubKey("Software\\ClickOffice\\SistemaDeVentas\\TipoImpresion", True)
        'Regkey1.SetValue("TipoImpresion", "DIRECTA")

        'Dim Regkey3 As RegistryKey
        'Dim Regkey4 As RegistryKey
        'Dim Regkey5 As RegistryKey

        ''SERVER CASA BRAVO
        If lbl_mac.Text = "B4B676F39DA0" Then
            Registry.CurrentUser.CreateSubKey("Software\\ClickOffice\\SistemaDeVentas\\ArchivoConexion")
            Registry.CurrentUser.CreateSubKey("Software\\ClickOffice\\SistemaDeVentas\\ArchivoOpcionesConexion")
            Registry.CurrentUser.CreateSubKey("Software\\ClickOffice\\SistemaDeVentas\\MultiSucursal")
            Registry.CurrentUser.CreateSubKey("Software\\ClickOffice\\SistemaDeVentas\\ArchivoConexionMultiSucursal")
            Dim Regkey1 As RegistryKey
            Dim Regkey2 As RegistryKey
            Dim Regkey3 As RegistryKey
            Dim Regkey4 As RegistryKey
            Dim Regkey5 As RegistryKey
            Regkey1 = Registry.CurrentUser.OpenSubKey("Software\\ClickOffice\\SistemaDeVentas\\ArchivoConexion", True)
            Regkey1.SetValue("ArchivoConexion", "CLICKOFFICE")
            Regkey2 = Registry.CurrentUser.OpenSubKey("Software\\ClickOffice\\SistemaDeVentas\\ArchivoOpcionesConexion", True)
            Regkey2.SetValue("ArchivoOpcionesConexion", "CLICKOFFICE")
            Regkey3 = Registry.CurrentUser.OpenSubKey("Software\\ClickOffice\\SistemaDeVentas\\MultiSucursal", True)
            Regkey3.SetValue("MultiSucursal", "NO")
            Regkey4 = Registry.CurrentUser.OpenSubKey("Software\\ClickOffice\\SistemaDeVentas\\ArchivoConexionMultiSucursal", True)
            Regkey5 = Registry.CurrentUser.OpenSubKey("Software\\ClickOffice\\SistemaDeVentas\\RutEmpresa", True)
            Regkey5.SetValue("RutEmpresa", "1697294-9")
        End If



        Try
            Dim Opciones_De_Sucursal = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\ClickOffice\SistemaDeVentas\ArchivoOpcionesConexion", "ArchivoOpcionesConexion", Nothing)

            If Opciones_De_Sucursal = "" Then
                Registry.CurrentUser.CreateSubKey("Software\\ClickOffice\\SistemaDeVentas\\ArchivoConexion")
                Registry.CurrentUser.CreateSubKey("Software\\ClickOffice\\SistemaDeVentas\\ArchivoOpcionesConexion")
                Registry.CurrentUser.CreateSubKey("Software\\ClickOffice\\SistemaDeVentas\\MultiSucursal")
                Registry.CurrentUser.CreateSubKey("Software\\ClickOffice\\SistemaDeVentas\\ArchivoConexionMultiSucursal")
                Dim Regkey1 As RegistryKey
                Dim Regkey2 As RegistryKey
                Dim Regkey3 As RegistryKey
                Dim Regkey4 As RegistryKey
                Dim Regkey5 As RegistryKey
                Regkey1 = Registry.CurrentUser.OpenSubKey("Software\\ClickOffice\\SistemaDeVentas\\ArchivoConexion", True)
                Regkey1.SetValue("ArchivoConexion", "CLICKOFFICE")
                Regkey2 = Registry.CurrentUser.OpenSubKey("Software\\ClickOffice\\SistemaDeVentas\\ArchivoOpcionesConexion", True)
                Regkey2.SetValue("ArchivoOpcionesConexion", "CLICKOFFICE")
                Regkey3 = Registry.CurrentUser.OpenSubKey("Software\\ClickOffice\\SistemaDeVentas\\MultiSucursal", True)
                Regkey3.SetValue("MultiSucursal", "NO")
                Regkey4 = Registry.CurrentUser.OpenSubKey("Software\\ClickOffice\\SistemaDeVentas\\ArchivoConexionMultiSucursal", True)
                Regkey5 = Registry.CurrentUser.OpenSubKey("Software\\ClickOffice\\SistemaDeVentas\\RutEmpresa", True)
                Regkey5.SetValue("RutEmpresa", "16972940-9")
            End If



            Dim tabla() As String
            Dim n As Integer
            Opciones_De_Sucursal = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\ClickOffice\SistemaDeVentas\ArchivoOpcionesConexion", "ArchivoOpcionesConexion", Nothing)
            Dim Sucursal_seleccionada = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\ClickOffice\SistemaDeVentas\ArchivoConexion", "ArchivoConexion", Nothing)
            Rut_Empresa_Seleccionada = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\ClickOffice\SistemaDeVentas\RutEmpresa", "RutEmpresa", Nothing)










            tabla = Split(Opciones_De_Sucursal, ",")
            For n = 0 To UBound(tabla, 1)
                combo_conexion.Items.Add(tabla(n))
            Next
            combo_conexion.Text = Sucursal_seleccionada
        Catch
        End Try

        Try
            cargar_malla_conexiones()
        Catch
        End Try

        actualizar_sistema = "NO"

        cargar_logo()

        If Rut_Empresa_Seleccionada <> "76820004-1" Then
            PrevInstance()
        End If

        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True
        CheckForIllegalCrossThreadCalls = False



        LiberarMemoria()
        Timer_memoria.Start()
    End Sub

    'Sub empresa()
    '    DS.Tables.Clear()
    '    DT.Rows.Clear()
    '    DT.Columns.Clear()
    '    DS.Clear()
    '    conexion.Open()
    '    SC.Connection = conexion
    '    SC.CommandText = "select * from empresa"
    '    DA.SelectCommand = SC
    '    DA.Fill(DT)
    '    DS.Tables.Add(DT)
    '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
    '        mirutempresa = DS.Tables(DT.TableName).Rows(0).Item("rut_empresa")
    '        minombreempresa = DS.Tables(DT.TableName).Rows(0).Item("nombre_empresa")
    '        midireccionempresa = DS.Tables(DT.TableName).Rows(0).Item("direccion_empresa")
    '        mitelefonoempresa = DS.Tables(DT.TableName).Rows(0).Item("telefono_empresa")
    '        migiroempresa = DS.Tables(DT.TableName).Rows(0).Item("giro_empresa")
    '        micomunaempresa = DS.Tables(DT.TableName).Rows(0).Item("comuna_empresa")
    '        mirecintoempresa = DS.Tables(DT.TableName).Rows(0).Item("recinto_empresa")
    '        micorreoempresa = DS.Tables(DT.TableName).Rows(0).Item("correo_empresa")
    '        miclavecorreoempresa = DS.Tables(DT.TableName).Rows(0).Item("clave_correo_empresa")
    '        miciudadempresa = DS.Tables(DT.TableName).Rows(0).Item("ciudad_empresa")
    '        mititularetiquetaempresa = DS.Tables(DT.TableName).Rows(0).Item("titular_etiqueta")
    '        mipiemenuempresa = DS.Tables(DT.TableName).Rows(0).Item("pie_menu")
    '        mi_tipo_sucursal_empresa = DS.Tables(DT.TableName).Rows(0).Item("tipo_sucursal")
    '        MiCorreoEmpresaAdministracion = DS.Tables(DT.TableName).Rows(0).Item("correo_empresa_administracion")
    '        MiClaveCorreoEmpresaAdministracion = DS.Tables(DT.TableName).Rows(0).Item("clave_correo_empresa_administracion")
    '        MiWebEmpresa = DS.Tables(DT.TableName).Rows(0).Item("web_empresa")
    '        form_Menu_admin.lbl_pie.Text = DS.Tables(DT.TableName).Rows(0).Item("pie_menu")
    '    End If
    '    conexion.Close()
    'End Sub

    Sub cargar_logo()
        Dim recinto As String = ""
        Dim rut_empresa As String = ""
        Dim ruta_logo As String = ""
        Dim rut_empresa_color As String = ""
        For i = 0 To grilla_conexiones.Rows.Count - 1
            recinto = grilla_conexiones.Rows(i).Cells(5).Value.ToString
            rut_empresa = grilla_conexiones.Rows(i).Cells(6).Value.ToString
            rut_empresa_color = grilla_conexiones.Rows(i).Cells(6).Value.ToString
            If combo_conexion.Text = recinto Then
                Try
                    rut_empresa = Trim(Replace(rut_empresa, "-", "_"))
                    rut_empresa = "_" & rut_empresa
                    ruta_logo = "Global.proyecto_sistema_ventas.My.Resources.Resources." & rut_empresa
                    PictureBox_logo.Image = My.Resources.ResourceManager.GetObject(rut_empresa)
                Catch
                End Try
                Exit For
            End If
        Next

        CambiaColorFondo(btn_aceptar, rut_empresa_color)
        CambiaColorFondo(titleBar, rut_empresa_color)
        CambiaColorFondo(Panel3, rut_empresa_color)

        'CambiaColorFondo(Label2, rut_empresa_color)
        CambiaColorFondo(btn_minimize, rut_empresa_color)
        CambiaColorFondo(btn_close, rut_empresa_color)
    End Sub

    Friend Function PrevInstance() As Boolean
        If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0 Then
            MsgBox("EL SISTEMA YA SE ESTA EJECUTANDO", MsgBoxStyle.DefaultButton3 + MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "YA ESTA EN EJECUCION")
            Application.Exit()
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btn_aceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If txt_usuario.Text = "" Then
            txt_usuario.Focus()
            MsgBox("CAMPO USUARIO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        If txt_clave.Text = "" Then
            txt_clave.Focus()
            MsgBox("CAMPO CLAVE VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        txt_usuario.Focus()
        If (BackgroundWorker1.IsBusy <> True) Then
            'PictureBox1.Visible = True

            'Panel1.Location = New Point(750, 145)

            ' Iniciamos la operación asíncrona.
            BackgroundWorker1.RunWorkerAsync()
        End If
        'crear_conexion()
    End Sub

    'Sub cargar_rutas_imagenes()
    '    Try
    '        conexion.Close()
    '        DS2.Tables.Clear()
    '        DT2.Rows.Clear()
    '        DT2.Columns.Clear()
    '        DS2.Clear()
    '        conexion.Open()
    '        SC2.Connection = conexion
    '        SC2.CommandText = "select * from rutas_imagenes"
    '        DA2.SelectCommand = SC2
    '        DA2.Fill(DT2)
    '        DS2.Tables.Add(DT2)
    '        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
    '            ruta_logo_empresa_menu = DS2.Tables(DT2.TableName).Rows(0).Item("ruta_logo_empresa_menu")
    '            ruta_logo_empresa = DS2.Tables(DT2.TableName).Rows(0).Item("ruta_logo_empresa_formulario")
    '            ruta_logo_empresa_reportes = DS2.Tables(DT2.TableName).Rows(0).Item("ruta_logo_empresa_reportes")
    '            ruta_logo_empresa_ticket = DS2.Tables(DT2.TableName).Rows(0).Item("ruta_logo_empresa_ticket")
    '        End If
    '        conexion.Close()
    '    Catch ex As MySqlException
    '        conexion.Close()
    '    End Try
    'End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        SucursalSeleccionada = combo_conexion.Text
        Form_cambio_de_contraseña_asistente.Show()
        Me.Close()
    End Sub

    Private Sub Label3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.MouseLeave
        Label3.ForeColor = Color.Black
    End Sub

    Private Sub Label3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseMove
        Label3.ForeColor = Color.Yellow
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub txt_usuario_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_usuario.GotFocus
        'foco()
    End Sub

    Private Sub txt_usuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_usuario.KeyPress

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

        If e.KeyChar = "-" Then
            txt_clave.Focus()
            Exit Sub
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If txt_clave.Enabled = True Then
                txt_clave.Focus()
            Else
                btn_aceptar.PerformClick()
            End If
        End If
    End Sub

    Private Sub txt_usuario_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_usuario.LostFocus
        'foco()
    End Sub

    Private Sub txt_clave_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_clave.GotFocus
        'foco()
    End Sub

    Private Sub txt_clave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_clave.KeyPress
        Dim caracter As String
        Dim caracter_espacio As String
        caracter_espacio = txt_usuario.Text

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

        If txt_usuario.Text <> "" Then
            caracter = caracter_espacio(caracter_espacio.Length - 1).ToString()
            If caracter = "-" Then
                txt_usuario.Text = caracter_espacio.Length - 1
                txt_usuario.Text = Mid(caracter_espacio, 1, Len(caracter_espacio) - 1)
            End If
        End If

        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            btn_aceptar.PerformClick()
        End If
    End Sub

    Sub validar_usuario()
        Using cn As New MySqlConnection(conexion_actual)
            cn.Open()

            Dim query As String = "Select * from usuarios where usuario = '" & (txt_usuario.Text) & "' and Clave ='" & (txt_clave.Text) & "'"
            Dim cmd As New MySqlCommand(query, cn)

            'cmd.Parameters.AddWithValue("@codigo", CInt(txtId.Text))

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                ingresar = "SI"
                miusuario = CStr(reader("rut_usuario"))
                minombre = CStr(reader("nombre_usuario"))
                miarea = CStr(reader("area_usuario"))
                mitelefono = CStr(reader("telefono_usuario"))
                tiempo_espera = CStr(reader("tiempo_espera"))
                tipo_usuario = CStr(reader("tipo_usuario"))
                traspasar_malla_conexiones()
            Else
                Panel1.Location = New Point(5000, 5000)
                txt_usuario.Enabled = True
                txt_clave.Enabled = True
                btn_aceptar.Enabled = True
                ingresar = "NO"
                BackgroundWorker1.CancelAsync()
                MsgBox("USUARIO NO ENCONTRADO", 0 + 16, "INFORMACION")
                txt_usuario.Text = ""
                txt_clave.Text = ""
                conexion.Close()
                txt_usuario.Focus()
            End If

        End Using
        'conexion.Close()
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()
        'SC.Connection = conexion
        'SC.CommandText = "Select * from usuarios where usuario = '" & (txt_usuario.Text) & "' and Clave ='" & (txt_clave.Text) & "' "
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)
        'If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '    ingresar = "SI"
        '    miusuario = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
        '    minombre = DS.Tables(DT.TableName).Rows(0).Item("nombre_usuario")
        '    miarea = DS.Tables(DT.TableName).Rows(0).Item("area_usuario")
        '    mitelefono = DS.Tables(DT.TableName).Rows(0).Item("telefono_usuario")
        '    tiempo_espera = DS.Tables(DT.TableName).Rows(0).Item("tiempo_espera")
        '    tipo_usuario = DS.Tables(DT.TableName).Rows(0).Item("tipo_usuario")
        '    'form_Menu_admin.mostrar_datos_login()
        '    conexion.Close()
        '    'empresa()
        '    traspasar_malla_conexiones()
        '    conexion.Close()
        '    'form_Menu_admin.Show()
        '    'Me.Close()
        'Else
        '    'PictureBox1.Visible = False
        '    Panel1.Location = New Point(5000, 5000)

        '    txt_usuario.Enabled = True
        '    txt_clave.Enabled = True
        '    btn_aceptar.Enabled = True
        '    'btn_cancelar.Enabled = True
        '    ingresar = "NO"
        '    BackgroundWorker1.CancelAsync()
        '    MsgBox("USUARIO NO ENCONTRADO", 0 + 16, "INFORMACION")
        '    txt_usuario.Text = ""
        '    txt_clave.Text = ""

        '    conexion.Close()

        '    txt_usuario.Focus()

        '    'DS.Tables.Clear()
        'End If
    End Sub

    Sub impresoras()


        Using cn As New MySqlConnection(conexion_actual)
            cn.Open()

            Dim query As String = "select * from impresoras"
            Dim cmd As New MySqlCommand(query, cn)

            'cmd.Parameters.AddWithValue("@codigo", CInt(txtId.Text))

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                impresora_boletas = CStr(reader("boleta"))
                impresora_guias = CStr(reader("guia"))
                impresora_facturas = CStr(reader("factura"))
                impresora_nota_de_credito = CStr(reader("nota_de_credito"))

                tipo_impresion_boleta = CStr(reader("tipo_impresion_boleta"))
                tipo_impresion_factura = CStr(reader("tipo_impresion_factura"))
                tipo_impresion_guia = CStr(reader("tipo_impresion_guia"))
                tipo_impresion_nota_de_credito = CStr(reader("tipo_impresion_nota_de_credito"))
                tipo_impresion_nota_de_debito = CStr(reader("tipo_impresion_nota_de_debito"))

                'tipo_papel_boleta = CStr(reader("tipo_papel_boleta"))
                'tipo_papel_factura = CStr(reader("tipo_papel_factura"))
                'tipo_papel_guia = CStr(reader("tipo_papel_guia"))
                'tipo_papel_nota_de_credito = CStr(reader("tipo_papel_nota_de_credito"))
                'tipo_papel_nota_de_debito = CStr(reader("tipo_papel_nota_de_debito"))

                tipo_impresion_sistema = CStr(reader("tipo_impresion"))


                ' tipo_impresion_sistema = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_impresion")

                If CStr(reader("estado_boleta_electronica")) = "SI" Then
                    estado_boleta_electronica = "SI"
                Else
                    estado_boleta_electronica = "NO"
                End If

                If CStr(reader("estado_factura_electronica")) = "SI" Then
                    estado_factura_electronica = "SI"
                Else
                    estado_factura_electronica = "NO"
                End If

                If CStr(reader("estado_guia_electronica")) = "SI" Then
                    estado_guia_electronica = "SI"
                Else
                    estado_guia_electronica = "NO"
                End If

                If CStr(reader("estado_nota_credito_electronica")) = "SI" Then
                    estado_nota_de_credito_electronica = "SI"
                Else
                    estado_nota_de_credito_electronica = "NO"
                End If

                If CStr(reader("estado_nota_debito_electronica")) = "SI" Then
                    estado_nota_de_debito_electronica = "SI"
                Else
                    estado_nota_de_debito_electronica = "NO"
                End If



            End If

        End Using


        'conexion.Close()
        'DS2.Tables.Clear()
        'DT2.Rows.Clear()
        'DT2.Columns.Clear()
        'DS2.Clear()
        'conexion.Open()
        'SC2.Connection = conexion
        'SC2.CommandText = "select * from impresoras"
        'DA2.SelectCommand = SC2
        'DA2.Fill(DT2)
        'DS2.Tables.Add(DT2)
        'If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
        '    impresora_boletas = DS2.Tables(DT2.TableName).Rows(0).Item("boleta")
        '    impresora_guias = DS2.Tables(DT2.TableName).Rows(0).Item("guia")
        '    impresora_facturas = DS2.Tables(DT2.TableName).Rows(0).Item("factura")
        '    impresora_nota_de_credito = DS2.Tables(DT2.TableName).Rows(0).Item("nota_de_credito")
        '    impresora_nota_de_debito = DS2.Tables(DT2.TableName).Rows(0).Item("nota_de_debito")
        '    Try
        '        tipo_impresion_boleta = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_impresion_boleta")
        '        tipo_impresion_factura = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_impresion_factura")
        '        tipo_impresion_guia = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_impresion_guia")
        '        tipo_impresion_nota_de_credito = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_impresion_nota_de_credito")
        '        tipo_impresion_nota_de_debito = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_impresion_nota_de_debito")
        '    Catch
        '    End Try

        '    tipo_impresion_sistema = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_impresion")

        '    If DS2.Tables(DT2.TableName).Rows(0).Item("estado_boleta_electronica") = "SI" Then
        '        estado_boleta_electronica = "SI"
        '    Else
        '        estado_boleta_electronica = "NO"
        '    End If

        '    If DS2.Tables(DT2.TableName).Rows(0).Item("estado_factura_electronica") = "SI" Then
        '        estado_factura_electronica = "SI"
        '    Else
        '        estado_factura_electronica = "NO"
        '    End If

        '    If DS2.Tables(DT2.TableName).Rows(0).Item("estado_guia_electronica") = "SI" Then
        '        estado_guia_electronica = "SI"
        '    Else
        '        estado_guia_electronica = "NO"
        '    End If

        '    If DS2.Tables(DT2.TableName).Rows(0).Item("estado_nota_credito_electronica") = "SI" Then
        '        estado_nota_de_credito_electronica = "SI"
        '    Else
        '        estado_nota_de_credito_electronica = "NO"
        '    End If

        '    If DS2.Tables(DT2.TableName).Rows(0).Item("estado_nota_debito_electronica") = "SI" Then
        '        estado_nota_de_debito_electronica = "SI"
        '    Else
        '        estado_nota_de_debito_electronica = "NO"
        '    End If
        'End If
        'conexion.Close()
    End Sub

    Sub rutas()

        Using cn As New MySqlConnection(conexion_actual)
            cn.Open()

            Dim query As String = "select * from rutas_archivos"
            Dim cmd As New MySqlCommand(query, cn)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then

                ruta_archivos_planos = CStr(reader("archivo_plano_documentos_electronicos"))
                ruta_archivos_facturacion = CStr(reader("archivo_plano_facturacion"))
                ' ruta_archivos_electronicos = CStr(reader("archivos_electronicos"))

            End If

        End Using


        'conexion.Close()
        'DS2.Tables.Clear()
        'DT2.Rows.Clear()
        'DT2.Columns.Clear()
        'DS2.Clear()
        'conexion.Open()
        'SC2.Connection = conexion
        'SC2.CommandText = "select * from rutas_archivos"
        'DA2.SelectCommand = SC2
        'DA2.Fill(DT2)
        'DS2.Tables.Add(DT2)
        'If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
        '    ruta_archivos_planos = DS2.Tables(DT2.TableName).Rows(0).Item("archivo_plano_documentos_electronicos")
        '    ruta_archivos_facturacion = DS2.Tables(DT2.TableName).Rows(0).Item("archivo_plano_facturacion")
        'End If
        'conexion.Close()
    End Sub

    Private Sub txt_clave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_clave.LostFocus
        'foco()
    End Sub

    Private Sub btn_aceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.GotFocus
        'btn_aceptar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_aceptar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aceptar.LostFocus
        'btn_aceptar.BackColor = Color.FromArgb(122, 122, 122)
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'btn_cancelar.BackColor = Color.FromArgb(122, 122, 122)
    End Sub

    Private Sub combo_conexion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim recinto As String
        Dim rut_empresa As String
        Dim ruta_logo As String
        For i = 0 To grilla_conexiones.Rows.Count - 1
            recinto = grilla_conexiones.Rows(i).Cells(5).Value.ToString
            rut_empresa = grilla_conexiones.Rows(i).Cells(6).Value.ToString
            If combo_conexion.Text = recinto Then
                Try
                    rut_empresa = Trim(Replace(rut_empresa, "-", "_"))
                    rut_empresa = "_" & rut_empresa
                    ruta_logo = "Global.proyecto_sistema_ventas.My.Resources.Resources." & rut_empresa
                    PictureBox_logo.Image = My.Resources.ResourceManager.GetObject(rut_empresa)
                Catch
                End Try
            End If
        Next
        txt_usuario.Focus()
    End Sub

    Sub cargar_malla_conexiones()
        grilla_conexiones.Rows.Add("ARANAEXPRESS", "servidorarana452.dyndns.org", "basededatos", "1234", "sistema_general", "BDO. O'HIGGINS 452", "87686300-6", "-")
        grilla_conexiones.Rows.Add("ARANAMATRIZ", "servidorarana441.dyndns.org", "basededatos", "1234", "sistema_general", "BDO. O'HIGGINS 441", "87686300-6", "-")
        grilla_conexiones.Rows.Add("ARANAMATRIZ", "servidorarana441.dyndns.org", "sucursal", "1234", "sistema_general", "QUECHEREGUAS 856", "87686300-6", "-")

        grilla_conexiones.Rows.Add("lubrioil1893", "lubrioil1893.dyndns.org", "basededatos", "1234", "sistema_general", "ARGOMEDO 1893", "13501829-5", "-")
        grilla_conexiones.Rows.Add("lubrioil-pc", "lubrioil-pc", "bd_lubrioil", "1234", "sistema_general", "ARGOMEDO 2153", "13501829-5", "-")

        grilla_conexiones.Rows.Add("VENTAS3-PC", "rectificadorasantacruz.dyndns.org", "basededatos", "1234", "sistema_general", "DIEGO PORTALES 1463", "8445963-1", "-")

        grilla_conexiones.Rows.Add("SERVERHUSKLY", "SDFSDF.dyndns.org", "bd_huskly", "1234", "sistema_general", "MANUEL RODRIGUEZ 760", "76313245-5", "-")
        grilla_conexiones.Rows.Add("SERVERALOHAHUSKLY", "SDFSDF.dyndns.org", "basededatos", "1234", "sistema_general", "RANCAGUA 725-A", "76313245-5", "-")

        grilla_conexiones.Rows.Add("SERVERCASABRAVO", "localhost", "casa_bravo_520", "1234", "sistema_general", "RANCAGUA 520", "12413179-0", "-")

        grilla_conexiones.Rows.Add("localhost", "localhost", "bd_cd_santacruz", "1234", "root", "LOCALHOST", "16972940-9", "-")

        grilla_conexiones.Rows.Add("localhost", "localhost", "bd_cd_santacruz", "1234", "root", "CHORRILLOS N° 66", "14048487-3", "-")

        grilla_conexiones.Rows.Add("CLICK OFFICE", "clickoffice.cl", "ccl27955_basededatos", "clickoffice", "ccl27955_sistema", "CLICK OFFICE", "16972940-9", "-")

        grilla_conexiones.Rows.Add("MILITARYSTORE", "localhost", "bd_military_store", "1234", "sistema_general", "RANCAGUA 592-A", "76820004-1", "-")
        grilla_conexiones.Rows.Add("MILITARY635", "localhost", "bd_military_store", "1234", "sistema_general", "RANCAGUA 627", "76820004-1", "-")


        grilla_conexiones.Rows.Add("IMARS", "SDFSDF.dyndns.org", "bd_imars", "1234", "sistema_general", "CHACABUCO 412", "76366176-8", "-")

        grilla_conexiones.Rows.Add("IMARSRENGO", "SDFSDF.dyndns.org", "bd_imars", "1234", "sistema_general", "RIQUELME 1180", "76366176-8", "-")

        grilla_conexiones.Rows.Add("MIBEBE", "SDFSDF.dyndns.org", "basededatos", "1234", "sistema_general", "CHILLAN 502 L-7", "76312567-K", "-")
        grilla_conexiones.Rows.Add("localhost", "localhost", "bd_cd_santacruz", "1234", "sistema_general", "LOCALHOST", "16972940-9", "-")
        grilla_conexiones.Rows.Add("190.107.177.116", "190.107.177.116", "basededatos", "Mysql2019", "sistema", "PROCMAN", "76881284-5", "-")

        grilla_conexiones.Rows.Add("190.107.177.116", "190.107.177.116", "basededatos", "Mysql2019", "ventas", "SOC. DIAZ OJEDA", "76474168-4", "-")
        grilla_conexiones.Rows.Add("190.107.177.116", "190.107.177.116", "bd_neumapro", "clickoffice2020", "ventas", "NEUMAPRO", "18229026-2", "-")
        grilla_conexiones.Rows.Add("190.107.177.116", "190.107.177.116", "bd_clickoffice", "clickoffice2020", "ventas", "CLICKOFFICE", "16972940-9", "-")





    End Sub

    Sub empresa()

        Using cn As New MySqlConnection(conexion_actual)
            cn.Open()

            Dim query As String = "select * from empresa"
            Dim cmd As New MySqlCommand(query, cn)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then

                mirutempresa = CStr(reader("rut_empresa"))
                minombreempresa = CStr(reader("nombre_empresa"))
                midireccionempresa = CStr(reader("direccion_empresa"))
                mitelefonoempresa = CStr(reader("telefono_empresa"))
                migiroempresa = CStr(reader("giro_empresa"))
                micomunaempresa = CStr(reader("comuna_empresa"))
                mirecintoempresa = CStr(reader("recinto_empresa"))
                miciudadempresa = CStr(reader("comuna_empresa"))
                mititularetiquetaempresa = CStr(reader("titular_etiqueta"))
                mipiemenuempresa = CStr(reader("pie_menu"))
                mi_tipo_sucursal_empresa = CStr(reader("tipo_sucursal"))
                MiWebEmpresa = CStr(reader("web_empresa"))
                mipiemenuempresa = CStr(reader("pie_menu"))
                'produccion_sii = CStr(reader("produccion_sii"))
                ' nro_resolucion = CStr(reader("nro_resolucion"))
                'ActividadEconomica = CStr(reader("cod_actividad_economica"))
                'sucursaL_sii = CStr(reader("sucursaL_sii"))
                'fecha_resolucion = CStr(reader("fecha_resolucion"))
                Dim Rut_a_separar As String = mirutempresa
                Dim Rut_a_separar_2 As String() = Rut_a_separar.Split("-")
                Dim Rut_f_1 As String = Rut_a_separar_2(0)
                Dim Rut_f_2 As String = Rut_a_separar_2(1)

                If Rut_f_1 = "" Or Rut_f_1 = "0" Then
                    Rut_f_1 = "0"
                Else
                    Rut_f_1 = Format(Int(Rut_f_1), "###,###,###")
                End If

                ' mirutempresaFormateado = Rut_f_1 & "-" & Rut_f_2

            End If

        End Using




        Using cn As New MySqlConnection(conexion_actual)
            cn.Open()

            Dim query As String = "select * from correo_de_ventas"
            Dim cmd As New MySqlCommand(query, cn)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then

                micorreoempresa = CStr(reader("correo"))

            End If

        End Using







        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()
        'SC.Connection = conexion
        'SC.CommandText = "select * from empresa"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)
        'If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '    mirutempresa = DS.Tables(DT.TableName).Rows(0).Item("rut_empresa")
        '    minombreempresa = DS.Tables(DT.TableName).Rows(0).Item("nombre_empresa")
        '    midireccionempresa = DS.Tables(DT.TableName).Rows(0).Item("direccion_empresa")
        '    mitelefonoempresa = DS.Tables(DT.TableName).Rows(0).Item("telefono_empresa")
        '    migiroempresa = DS.Tables(DT.TableName).Rows(0).Item("giro_empresa")
        '    micomunaempresa = DS.Tables(DT.TableName).Rows(0).Item("comuna_empresa")
        '    mirecintoempresa = DS.Tables(DT.TableName).Rows(0).Item("recinto_empresa")
        '    miciudadempresa = DS.Tables(DT.TableName).Rows(0).Item("comuna_empresa")
        '    mititularetiquetaempresa = DS.Tables(DT.TableName).Rows(0).Item("titular_etiqueta")
        '    mipiemenuempresa = DS.Tables(DT.TableName).Rows(0).Item("pie_menu")
        '    mi_tipo_sucursal_empresa = DS.Tables(DT.TableName).Rows(0).Item("tipo_sucursal")
        '    MiWebEmpresa = DS.Tables(DT.TableName).Rows(0).Item("web_empresa")
        '    mipiemenuempresa = DS.Tables(DT.TableName).Rows(0).Item("pie_menu")

        '    'produccion_sii = DS.Tables(DT.TableName).Rows(0).Item("produccion_sii")
        '    'nro_resolucion = DS.Tables(DT.TableName).Rows(0).Item("nro_resolucion")
        '    'fecha_resolucion = DS.Tables(DT.TableName).Rows(0).Item("fecha_resolucion")

        'End If
        'conexion.Close()

        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()
        'SC.Connection = conexion
        'SC.CommandText = "select * from correo_de_ventas"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)
        'If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '    micorreoempresa = DS.Tables(DT.TableName).Rows(0).Item("correo")
        'End If
        'conexion.Close()
    End Sub

    Sub traspasar_malla_conexiones()
        Dim nombre_servidor As String
        Dim nombre_servidor_remoto As String
        Dim base_de_datos As String
        Dim clave_base_de_datos As String
        Dim usuario As String
        Dim recinto As String
        Dim rut_empresa As String
        Dim tipo As String

        For i = 0 To grilla_conexiones.Rows.Count - 1
            nombre_servidor = grilla_conexiones.Rows(i).Cells(0).Value.ToString
            nombre_servidor_remoto = grilla_conexiones.Rows(i).Cells(1).Value.ToString
            base_de_datos = grilla_conexiones.Rows(i).Cells(2).Value.ToString
            clave_base_de_datos = grilla_conexiones.Rows(i).Cells(3).Value.ToString
            usuario = grilla_conexiones.Rows(i).Cells(4).Value.ToString
            recinto = grilla_conexiones.Rows(i).Cells(5).Value.ToString
            rut_empresa = grilla_conexiones.Rows(i).Cells(6).Value.ToString
            tipo = grilla_conexiones.Rows(i).Cells(7).Value.ToString
            If mirutempresa = rut_empresa Then
                Form_menu_principal.grilla_conexiones.Rows.Add(nombre_servidor, nombre_servidor_remoto, base_de_datos, clave_base_de_datos, usuario, recinto, rut_empresa, tipo)
            End If
        Next
    End Sub

    Sub crear_conexion()
        Dim nombre_servidor As String
        Dim nombre_servidor_remoto As String
        Dim base_de_datos As String
        Dim clave_base_de_datos As String
        Dim usuario As String
        Dim recinto As String
        Dim rut_empresa As String
        Dim RutEmpresa = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\ClickOffice\SistemaDeVentas\RutEmpresa", "RutEmpresa", Nothing)
        Dim Sucursal_seleccionada = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\ClickOffice\SistemaDeVentas\ArchivoConexion", "ArchivoConexion", Nothing)

        For i = 0 To grilla_conexiones.Rows.Count - 1
            nombre_servidor = grilla_conexiones.Rows(i).Cells(0).Value.ToString
            nombre_servidor_remoto = grilla_conexiones.Rows(i).Cells(1).Value.ToString
            base_de_datos = grilla_conexiones.Rows(i).Cells(2).Value.ToString
            clave_base_de_datos = grilla_conexiones.Rows(i).Cells(3).Value.ToString
            usuario = grilla_conexiones.Rows(i).Cells(4).Value.ToString
            recinto = grilla_conexiones.Rows(i).Cells(5).Value.ToString
            rut_empresa = grilla_conexiones.Rows(i).Cells(6).Value.ToString
            rut_empresa = grilla_conexiones.Rows(i).Cells(6).Value.ToString
            If combo_conexion.Text = recinto Then
                SucursalSeleccionada = combo_conexion.Text
                Try
                    conexion.Close()
                    conexion.ConnectionString = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"

                    tipo_conexion = "LOCAL"

                    conexion_actual = "Database=" & (base_de_datos) & "; Data Source= " & (nombre_servidor) & "; User Id=" & (usuario) & "; Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"


                    conexion.Open()
                    conexion.Close()
                Catch
                    conexion.Close()
                    conexion.ConnectionString = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"

                    tipo_conexion = "REMOTA"

                    conexion_actual = "server=" & (nombre_servidor_remoto) & "; Database=" & (base_de_datos) & "; User Id=" & (usuario) & ";Password=" & (clave_base_de_datos) & "; Convert Zero Datetime=True; default command timeout=3600"

                End Try

                Try
                Catch
                    MsgBox("NO HAY CONEXION CON EL SERVIDOR", 0 + 16, "ERROR")

                    Me.Close()
                    Exit Sub
                End Try
                'cargar_rutas_imagenes()
                impresoras()
                rutas()
                validar_usuario()
                Exit Sub
            End If
        Next
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If (BackgroundWorker1.CancellationPending) Then
            'txt_usuario.Focus()
            e.Cancel = True


            txt_usuario.Focus()
            Exit Sub
        Else
            'PictureBox1.Visible = True
            Panel1.Location = New Point(0, 140)
            txt_usuario.Enabled = False
            txt_clave.Enabled = False
            btn_aceptar.Enabled = False
            'btn_cancelar.Enabled = False
            crear_conexion()

            empresa()
            txt_usuario.Focus()
            'traspasar_malla_conexiones()
            'form_Menu_admin.Show()
            'While cerrar_login <> "SI"
            'Me.Close()
            'End While
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If ingresar = "SI" Then
            Form_menu_principal.Show()
            'traspasar_malla_conexiones()
            'form_Menu_admin.cargar_logo()
            'form_Menu_admin.agregar_tareas()
            'form_Menu_admin.empresa()
            'form_Menu_admin.mostrar_datos_login()
            'form_Menu_admin.revisar_permisos()
            'form_Menu_admin.cargar_iconos_menu()
            'form_Menu_admin.personalizar_empresa()
            'form_Menu_admin.valores()
            'form_Menu_admin.ajustar()
            ' Me.Close()
        End If
    End Sub

    Private Sub Timer_memoria_Tick(sender As Object, e As EventArgs) Handles Timer_memoria.Tick
        LiberarMemoria()
    End Sub

#Region "Drag Form - Arrastrar/ mover Formulario"
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub

    Private Sub titleBar_MouseDown(sender As Object, e As MouseEventArgs) Handles titleBar.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub form_Ingreso_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub PictureBox_logo_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox_logo.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
#End Region

    Private Sub titleBar_Paint(sender As Object, e As PaintEventArgs) Handles titleBar.Paint

    End Sub

    Private Sub txt_usuario_TextChanged(sender As Object, e As EventArgs) Handles txt_usuario.TextChanged
        If txt_usuario.Text = "" Then
            lbl_ingrese_usuario.Visible = True
        Else
            lbl_ingrese_usuario.Visible = False
        End If
    End Sub


    Private Sub txt_clave_TextChanged(sender As Object, e As EventArgs) Handles txt_clave.TextChanged
        If txt_clave.Text = "" Then
            lbl_ingrese_clave.Visible = True
        Else
            lbl_ingrese_clave.Visible = False
        End If
    End Sub


    'Sub foco()
    'If txt_usuario.Focused = False And txt_usuario.Text = "" Then
    '    txt_usuario.Text = "Ingrese un usuario"
    '    txt_usuario.ForeColor = Color.Gray
    '    txt_usuario.Font = New Font("Tahoma", 12, FontStyle.Italic)
    'Else
    '    txt_usuario.ForeColor = Color.Black
    '    txt_usuario.Font = New Font("Tahoma", 12, FontStyle.Regular)
    'End If

    'If txt_usuario.Focused = True And txt_usuario.Text = "Ingrese un usuario" Then
    '    txt_usuario.Text = ""
    'End If

    'If txt_clave.Focused = False And txt_clave.Text = "" Then
    '    txt_clave.Text = "Ingrese una clave"
    '    txt_clave.ForeColor = Color.Gray
    '    txt_clave.Font = New Font("Tahoma", 12, FontStyle.Italic)
    '    txt_clave.PasswordChar = ""
    'Else
    '    txt_clave.ForeColor = Color.Black
    '    txt_clave.Font = New Font("Tahoma", 12, FontStyle.Regular)
    '    txt_clave.PasswordChar = "●"
    '    If txt_clave.Text = "Ingrese una clave" Then
    '        txt_clave.Text = ""
    '    End If
    'End If

    'If txt_clave.Focused = True And txt_clave.Text = "Ingrese una clave" Then
    '    txt_clave.Text = ""
    '    txt_clave.PasswordChar = "●"
    'End If
    'End Sub

    'Private Sub btn_minimize_Click(sender As Object, e As EventArgs)
    '    Me.WindowState = FormWindowState.Minimized
    'End Sub

    'Private Sub btn_close_Click_1(sender As Object, e As EventArgs)
    '    Me.Close()
    'End Sub

    Private Sub txt_clave_DragOver(sender As Object, e As DragEventArgs) Handles txt_clave.DragOver

    End Sub

    Private Sub lbl_ingrese_clave_Click(sender As Object, e As EventArgs) Handles lbl_ingrese_clave.Click
        txt_clave.Focus()
    End Sub

    Private Sub lbl_ingrese_usuario_Click(sender As Object, e As EventArgs) Handles lbl_ingrese_usuario.Click
        txt_usuario.Focus()
    End Sub

    Private Sub btn_minimize_Click(sender As Object, e As EventArgs) Handles btn_minimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub combo_conexion_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles combo_conexion.SelectedIndexChanged
        cargar_logo()
        txt_usuario.Focus()
    End Sub
End Class