Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Deployment.Application
Imports Microsoft.Win32
Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.Text

Public Class Form_menu_principal
    Private ejecutar As Boolean
    Dim inactiveTime = GetInactiveTime()
    Dim icono_1 As Byte()
    Dim icono_2 As Byte()
    Dim icono_3 As Byte()
    Dim icono_4 As Byte()
    Dim icono_5 As Byte()
    Dim icono_6 As Byte()
    Dim link_red_social As String
    Dim habilitar_permiso As String
    Dim permiso_compras As String = "NO"
    Dim permiso_ventas As String = "NO"
    Private WithEvents Pd As New PrintDocument
    Dim actualizar_reloj As Integer = 52
    'Dim contador As Integer = 50
    Dim segundo As String = 52
    Dim nro_venta As Integer = 0

    Sub mostrar_datos_login()
        Me.Text = "MENU GENERAL  -  USUARIO CONECTADO: " & minombre & "  (" & miarea & ")"
        lbl_usuario_conectado.Text = minombre & "  (" & miarea & ")"
    End Sub

    Private Sub form_Menu_admin_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim forms As FormCollection = Application.OpenForms
        Dim i As Integer
        For i = 0 To forms.Count - 1
            Try
                For Each form As Form In forms
                    If TypeOf form Is form_Ingreso Then

                    Else
                        form.Close()
                    End If
                Next
            Catch err As InvalidOperationException
            End Try
        Next i

        mostrar_cierre_sistema()
    End Sub

    Private Sub form_Menu_admin_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            'mostrar_cierre_sistema()
            Me.Close()
        End If

        If e.KeyCode = 18 Then
            If Me.WindowState = FormWindowState.Maximized Then
                Me.WindowState = FormWindowState.Normal
                Exit Sub
            End If
            If Me.WindowState = FormWindowState.Normal Then
                Me.WindowState = FormWindowState.Maximized
                Exit Sub
            End If
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
            'mostrar_cierre_sistema()
            Me.Close()
        End If

        If e.KeyCode = Keys.F12 Then
            If permiso_ventas = "SI" Then
                Form_venta.Show()
                Form_venta.WindowState = FormWindowState.Normal
                Me.WindowState = FormWindowState.Minimized
            End If
        End If

        If e.KeyCode = Keys.F6 Then
            If permiso_compras = "SI" Then
                Form_Compra.Show()
                Form_Compra.WindowState = FormWindowState.Normal
                Me.WindowState = FormWindowState.Minimized
            End If
        End If
    End Sub
    Private Sub form_Menu_admin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        form_Ingreso.traspasar_malla_conexiones()

        'lbl_mensaje.Height = 64
        'lbl_mensaje.Width = 470
        'PictureBox_reloj.Height = 64
        'PictureBox_reloj.Width = 64
        'Panel_espere.Width = lbl_mensaje.Width + PictureBox_reloj.Width
        'Panel_espere.Height = 65
        'PictureBox_reloj.Location = New Point(lbl_mensaje.Width, 0)
        'Panel_espere.Location = New Point(30, 100)


        Me.Text = Me.Text & " - " & form_Ingreso.lbl_version.Text
        cerrar_login = "NO"
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True
        CheckForIllegalCrossThreadCalls = False

        If (BackgroundWorker1.IsBusy <> True) Then
            ' Iniciamos la operación asíncrona.
            BackgroundWorker1.RunWorkerAsync()

        End If
        'cargar_logo()
        'agregar_tareas()
        'empresa()
        'mostrar_datos_login()

        'If tipo_usuario = "USUARIO DEL SISTEMA" Then
        '    ConsultaBloqueaMenus()
        '    ConsultaMenus()
        'End If

        'revisar_permisos()
        'cargar_iconos_menu()
        'personalizar_empresa()
        'valores()

        'Try
        '    lbl_version.Text = "VERSION " & ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
        'Catch err As InvalidDeploymentException
        'End Try

        lbl_uc.Text = "CONEXION " & tipo_conexion & " - " & SucursalSeleccionada

        ''''Dim fecha As Date = Today.Date
        ''''lbl_fecha.Text = Format(fecha, "Long Date")
        ''''lbl_fecha.Text = UCase(lbl_fecha.Text)
        ''''dtp_fecha.CustomFormat = "yyy-MM-dd"
        '''''dtp_fecha.CustomFormat = "yyy-MM-dd HH:mm"
        ''''lbl_hora.Text = TimeString
        'fecha_hora_servidor()

        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        'El formulario se ubique en toda la pantalla
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location


        Timer_hora.Start()



        ajustar()

        'If mirutempresa = "87686300-6" Then
        '    If mirecintoempresa = "BDO. O´HIGGINS 441" Then
        '        Registry.CurrentUser.CreateSubKey("Software\\ClickOffice\\SistemaDeVentas\\ArchivoConexion")
        '        Registry.CurrentUser.CreateSubKey("Software\\ClickOffice\\SistemaDeVentas\\ArchivoOpcionesConexion")
        '        Registry.CurrentUser.CreateSubKey("Software\\ClickOffice\\SistemaDeVentas\\RutEmpresa")
        '        Dim Regkey1 As RegistryKey
        '        Dim Regkey2 As RegistryKey
        '        Dim Regkey3 As RegistryKey
        '        'Dim Regkey4 As RegistryKey
        '        Dim Regkey5 As RegistryKey
        '        Regkey1 = Registry.CurrentUser.OpenSubKey("Software\\ClickOffice\\SistemaDeVentas\\ArchivoConexion", True)
        '        Regkey1.SetValue("ArchivoConexion", "BDO. O'HIGGINS 441")
        '        Regkey2 = Registry.CurrentUser.OpenSubKey("Software\\ClickOffice\\SistemaDeVentas\\ArchivoOpcionesConexion", True)
        '        'Regkey2.SetValue("ArchivoOpcionesConexion", "BDO. O'HIGGINS 441,BDO. O'HIGGINS 452,QUECHEREGUAS 856")
        '        Regkey2.SetValue("ArchivoOpcionesConexion", "BDO. O'HIGGINS 441")
        '        Regkey3 = Registry.CurrentUser.OpenSubKey("Software\\ClickOffice\\SistemaDeVentas\\MultiSucursal", True)
        '        Regkey5 = Registry.CurrentUser.OpenSubKey("Software\\ClickOffice\\SistemaDeVentas\\RutEmpresa", True)
        '        Regkey5.SetValue("RutEmpresa", "87686300-6")
        '    End If
        'End If

        Timer_inactividad_menu.Start()
        'Timer_memoria.Start()
    End Sub

    Sub revisar_permisos()
        If calculo_interes = "NO" Then
            If miusuario <> "16972940-9" Then
                DETALLE_DE_ABONOS_ToolStripMenuItem.Visible = False
                LISTADO_DE_LETRAS_ToolStripMenuItem.Visible = False
                'REVISARKARDEXToolStripMenuItem.Visible = False
                REVISAR_CAJAS_ToolStripMenuItem.Visible = False
                'CARTOLAKARDEX2ToolStripMenuItem.Visible = False
            End If
        End If

        If mirutempresa <> "18229026-2" Then
            CARGAR_NEUMATICOS_ToolStripMenuItem.Visible = False
            PRODUCTOS_PAGINA_NEUMAPRO_ToolStripMenuItem.Visible = False
        End If
        If mirutempresa = "76820004-1" Then
            CARGAR_ARCHIVO_EXCEL_ToolStripMenuItem.Visible = False
        End If
        If mirutempresa <> "81921000-4" Then
            ENVIO_A_GARANTIA_ToolStripMenuItem.Visible = False
            ESTADO_DE_DEUDAS_ToolStripMenuItem.Visible = False
            RESUMEN_DE_COMPRAS_Y_GUIAS_DE_TRASLADO_ToolStripMenuItem.Visible = False
            RESUMEN_DE_ITEM_POR_GUIAS_ToolStripMenuItem.Visible = False
            RESUMEN_DE_COMPRAS_POR_PROVEEDOR_ToolStripMenuItem.Visible = False
            RESUMEN_DE_COMPRAS_POR_GUIAS_ToolStripMenuItem.Visible = False
            RESUMEN_DE_VENTAS_POR_ITEM_ToolStripMenuItem.Visible = False
            RESUMEN_DE_COMPRAS_POR_GUIAS_ToolStripMenuItem.Visible = False
            RESUMEN_DE_COMPRAS_POR_ITEM_ToolStripMenuItem.Visible = False
            REVISION_DE_DESPACHOS_ToolStripMenuItem.Visible = False
            RESUMEN_DE_VENTAS_POR_ITEM_ToolStripMenuItem.Visible = False
            LISTADO_DE_PEDIDOS_ToolStripMenuItem.Visible = False
            VENTA_ESPERADA_POR_FAMILIA_ToolStripMenuItem.Visible = False
            'INVENTARIO_DIARIO_ToolStripMenuItem.Visible = False
            SALIDA_DE_TRABAJADORES_ToolStripMenuItem.Visible = False
            CENTRAL_DE_COSTOS_ToolStripMenuItem.Visible = False
            PEDIDOS_OR_ToolStripMenuItem.Visible = False
            GUIAS_ACEPTADAS_ToolStripMenuItem.Visible = False
            GUIAS_DE_TRASLADO_ToolStripMenuItem.Visible = False
            DEUDA_DE_CLIENTE_SEGUN_FECHA_ToolStripMenuItem.Visible = False
            EXISTENCIAS_ToolStripMenuItem.Visible = False
            REPOSICION_DE_VENTAS_ToolStripMenuItem.Visible = False
            STOCK_ACUMULADO_ToolStripMenuItem.Visible = False
            ARCHIVO_DICOM_ToolStripMenuItem.Visible = False
            CUADRATURA_FIN_DE_MES_ToolStripMenuItem.Visible = False
            DETALLE_DE_ENVIOS_ToolStripMenuItem.Visible = False
            LISTADO_DE_CLIENTES_CON_PAGARE_ToolStripMenuItem.Visible = False
            SUELDOS_POR_CAJA_ToolStripMenuItem.Visible = False
            ANTICIPOS_Y_SUELDOS_JEFE_LOCAL_ToolStripMenuItem.Visible = False
            FONDO_DE_SUELDOS_ToolStripMenuItem.Visible = False
            CONTROL_DE_DESPACHOS_ToolStripMenuItem.Visible = False
            LISTADO_GUIAS_DE_GARANTIA_ToolStripMenuItem.Visible = False
            CARGAR_ARCHIVO_EXCEL_ToolStripMenuItem.Visible = False
            LISTADO_DE_INTERESES_Y_GASTOS_ToolStripMenuItem.Visible = False
        End If

        If mirutempresa <> "87686300-6" Then
            IMAGENES_DE_PRODUCTOS_PARA_PUBLICIDAD_ToolStripMenuItem.Visible = False
            ESTADO_DE_DEUDAS_ToolStripMenuItem.Visible = False
            VENTAS_ASISTIDAS_ToolStripMenuItem.Visible = False
            TARJETAS_DE_PRESENTACION_ToolStripMenuItem.Visible = False
            TRASPASAR_STOCK_FISICO_ToolStripMenuItem.Visible = False
            SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem.Visible = False
            ADMINISTRAR_SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem.Visible = False
            CARGAR_ARCHIVO_EXCEL_ToolStripMenuItem.Visible = False
            IMPUTAR_ABONOS_ToolStripMenuItem.Visible = False
            AGREGAR_ABONOS_SIN_IMPUTAR_ToolStripMenuItem.Visible = False
            REPOSICION_ARANA_ToolStripMenuItem.Visible = False
            CONTEOS_ARANA_ToolStripMenuItem.Visible = False
        End If

        If mirutempresa <> "12413179-0" Then
            RECEPCION_DE_TRABAJO_ToolStripMenuItem.Visible = False
            REGISTRO_DE_HARDWARE_ToolStripMenuItem.Visible = False
        End If

        If miusuario <> "16972940-9" Then
            'VACIAR_ToolStripMenuItem.Visible = False
            'PRUEBAS_ToolStripMenuItem.Visible = False
            CARGAR_ARCHIVO_EXCEL_ToolStripMenuItem.Visible = False
            INGRESO_DE_CREDITOS_ToolStripMenuItem.Visible = False
            CONDICION_DE_VENTA_ToolStripMenuItem.Visible = False
            'EDICION_DE_IMPRESION_ToolStripMenuItem.Visible = False
            'REVISARKARDEXToolStripMenuItem.Visible = False
            'PRODUCTOSREPETIDOSKARDEXToolStripMenuItem.Visible = False
            'DOCUMENTOSDUPLICADOSToolStripMenuItem.Visible = False
        End If

        If mirutempresa = "87686300-6" Then
            CARGAR_ARCHIVO_EXCEL_ToolStripMenuItem.Visible = True
            ESTADO_DE_DEUDAS_ToolStripMenuItem.Visible = True
        End If
        If mirutempresa = "81921000-4" Then
            ESTADO_DE_DEUDAS_ToolStripMenuItem.Visible = True
            If miusuario <> "16972940-9" Then
                CARGAR_ARCHIVO_EXCEL_ToolStripMenuItem.Visible = False
            Else
                CARGAR_ARCHIVO_EXCEL_ToolStripMenuItem.Visible = True
            End If
        End If


        If mirutempresa = "76820004-1" Then
            CARGAR_ARCHIVO_EXCEL_ToolStripMenuItem.Visible = True
        End If
    End Sub

    Sub cargar_imagenes()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-menu.png"
        Catch
        End Try

        Try
            MENU_ADQUISICIONES_ToolStripMenuItem.Image = Image.FromFile("C:\Temp\" & mirutempresa & "\Icono-adquisiciones.png")
            'MENU_ADQUISICIONES_ToolStripMenuItem.Image = PictureBox_icono_1.Image
            'MENU_ADQUISICIONES_ToolStripMenuItem.Image = Bytes_Imagen(icono_1)
            MENU_ADQUISICIONES_ToolStripMenuItem.ImageAlign = ContentAlignment.TopCenter
            MENU_ADQUISICIONES_ToolStripMenuItem.TextAlign = ContentAlignment.BottomCenter
        Catch
        End Try

        Try
            MENU_ADMINISTRACION_ToolStripMenuItem.Image = Image.FromFile("C:\Temp\" & mirutempresa & "\Icono-administracion.png")
            'MENU_ADMINISTRACION_ToolStripMenuItem.Image = PictureBox_icono_2.Image
            'MENU_ADMINISTRACION_ToolStripMenuItem.Image = Bytes_Imagen(icono_2)
            MENU_ADMINISTRACION_ToolStripMenuItem.ImageAlign = ContentAlignment.TopCenter
            MENU_ADMINISTRACION_ToolStripMenuItem.TextAlign = ContentAlignment.BottomCenter
        Catch
        End Try

        Try
            MENU_BODEGA_ToolStripMenuItem.Image = Image.FromFile("C:\Temp\" & mirutempresa & "\Icono-bodega.png")
            'MENU_BODEGA_ToolStripMenuItem.Image = PictureBox_icono_3.Image
            'MENU_BODEGA_ToolStripMenuItem.Image = Bytes_Imagen(icono_3)
            MENU_BODEGA_ToolStripMenuItem.ImageAlign = ContentAlignment.TopCenter
            MENU_BODEGA_ToolStripMenuItem.TextAlign = ContentAlignment.BottomCenter
        Catch
        End Try

        Try
            MENU_CONFIGURACION_ToolStripMenuItem.Image = Image.FromFile("C:\Temp\" & mirutempresa & "\Icono-configuracion.png")
            'MENU_CONFIGURACION_ToolStripMenuItem.Image = PictureBox_icono_4.Image
            'MENU_CONFIGURACION_ToolStripMenuItem.Image = Bytes_Imagen(icono_4)
            MENU_CONFIGURACION_ToolStripMenuItem.ImageAlign = ContentAlignment.TopCenter
            MENU_CONFIGURACION_ToolStripMenuItem.TextAlign = ContentAlignment.BottomCenter
        Catch
        End Try

        Try
            MENU_MANTENEDORES_ToolStripMenuItem.Image = Image.FromFile("C:\Temp\" & mirutempresa & "\Icono-mantenedores.png")
            'MENU_MANTENEDORES_ToolStripMenuItem.Image = PictureBox_icono_5.Image
            'MENU_MANTENEDORES_ToolStripMenuItem.Image = Bytes_Imagen(icono_5)
            MENU_MANTENEDORES_ToolStripMenuItem.ImageAlign = ContentAlignment.TopCenter
            MENU_MANTENEDORES_ToolStripMenuItem.TextAlign = ContentAlignment.BottomCenter
        Catch
        End Try

        Try
            MENU_VENTAS_ToolStripMenuItem.Image = Image.FromFile("C:\Temp\" & mirutempresa & "\Icono-ventas.png")
            'MENU_VENTAS_ToolStripMenuItem.Image = PictureBox_icono_6.Image
            'MENU_VENTAS_ToolStripMenuItem.Image = Bytes_Imagen(icono_6)
            MENU_VENTAS_ToolStripMenuItem.ImageAlign = ContentAlignment.TopCenter
            MENU_VENTAS_ToolStripMenuItem.TextAlign = ContentAlignment.BottomCenter
        Catch
        End Try
    End Sub

    Sub personalizar_empresa()



        CambiaColorFondo(MenuStrip1, mirutempresa)
        CambiaColorFondo(lbl_fecha, mirutempresa)
        CambiaColorFondo(lbl_hora, mirutempresa)
        CambiaColorFondo(lbl_version, mirutempresa)
        CambiaColorFondo(lbl_mensaje, mirutempresa)
        CambiaColorFondo(lbl_soporte_remoto, mirutempresa)
        CambiaColorFondo(lbl_uc, mirutempresa)
        CambiaColorFondo(lbl_usuario_conectado, mirutempresa)
        CambiaColorFondo(Panel_pie, mirutempresa)
        ' CambiaColorFondo(lbl_pie, mirutempresa)
        'CambiaColorFondo(lbl_contacto, mirutempresa)
        'CambiaColorFondo(Me.BackColor, mirutempresa)


        ''NEUMAPRO
        'If mirutempresa = "18229026-2" Then
        '    MenuStrip1.ForeColor = Color.FromArgb(255, 255, 255)
        '    MenuStrip1.BackColor = Color.FromArgb(0, 112, 130)
        '    lbl_fecha.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_hora.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_version.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_mensaje.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_soporte_remoto.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_uc.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_usuario_conectado.ForeColor = Color.FromArgb(0, 0, 0)
        '    Panel_pie.BackColor = Color.FromArgb(0, 112, 130)
        '    lbl_pie.ForeColor = Color.FromArgb(255, 255, 255)
        '    lbl_contacto.ForeColor = Color.FromArgb(255, 255, 255)
        '    Me.BackColor = Color.FromArgb(255, 255, 255)
        'End If

        ''CARNES DIAZ
        'If mirutempresa = "76474168-4" Then
        '    MenuStrip1.ForeColor = Color.FromArgb(255, 246, 199)
        '    MenuStrip1.BackColor = Color.FromArgb(91, 5, 14)
        '    lbl_fecha.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_hora.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_version.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_mensaje.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_soporte_remoto.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_uc.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_usuario_conectado.ForeColor = Color.FromArgb(0, 0, 0)
        '    Panel_pie.BackColor = Color.FromArgb(91, 5, 14)
        '    lbl_pie.ForeColor = Color.FromArgb(255, 246, 199)
        '    lbl_contacto.ForeColor = Color.FromArgb(255, 246, 199)
        '    Me.BackColor = Color.FromArgb(255, 255, 255)
        'End If

        'If mirutempresa = "14048487-3" Then
        '    MenuStrip1.ForeColor = Color.FromArgb(172, 201, 1)
        '    MenuStrip1.BackColor = Color.FromArgb(8, 96, 0)
        '    lbl_fecha.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_hora.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_version.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_mensaje.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_soporte_remoto.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_uc.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_usuario_conectado.ForeColor = Color.FromArgb(0, 0, 0)
        '    Panel_pie.BackColor = Color.FromArgb(8, 96, 0)
        '    lbl_pie.ForeColor = Color.White
        '    lbl_contacto.ForeColor = Color.White
        '    Me.BackColor = Color.FromArgb(141, 193, 222)
        'End If


        'If mirutempresa = "76312567-K" Then
        '    MenuStrip1.ForeColor = Color.FromArgb(149, 43, 118)
        '    MenuStrip1.BackColor = Color.FromArgb(130, 196, 210)
        '    lbl_fecha.ForeColor = Color.FromArgb(25, 102, 110)
        '    lbl_hora.ForeColor = Color.FromArgb(25, 102, 110)
        '    lbl_version.ForeColor = Color.FromArgb(25, 102, 110)
        '    lbl_mensaje.ForeColor = Color.FromArgb(25, 102, 110)
        '    lbl_soporte_remoto.ForeColor = Color.FromArgb(25, 102, 110)
        '    lbl_uc.ForeColor = Color.FromArgb(25, 102, 110)
        '    lbl_usuario_conectado.ForeColor = Color.FromArgb(25, 102, 110)
        '    Panel_pie.BackColor = Color.FromArgb(130, 196, 210)
        '    lbl_pie.ForeColor = Color.FromArgb(149, 43, 118)
        '    lbl_contacto.ForeColor = Color.White
        '    Me.BackColor = Color.FromArgb(141, 193, 222)
        'End If

        'If mirutempresa = "76366176-8" Then
        '    MenuStrip1.ForeColor = Color.White
        '    MenuStrip1.BackColor = Color.FromArgb(192, 0, 0)
        '    lbl_fecha.ForeColor = Color.FromArgb(192, 0, 0)
        '    lbl_hora.ForeColor = Color.FromArgb(192, 0, 0)
        '    lbl_version.ForeColor = Color.FromArgb(192, 0, 0)
        '    lbl_mensaje.ForeColor = Color.FromArgb(192, 0, 0)
        '    lbl_soporte_remoto.ForeColor = Color.FromArgb(192, 0, 0)
        '    lbl_uc.ForeColor = Color.FromArgb(192, 0, 0)
        '    lbl_usuario_conectado.ForeColor = Color.FromArgb(192, 0, 0)
        '    Panel_pie.BackColor = Color.FromArgb(192, 0, 0)
        '    lbl_pie.ForeColor = Color.FromArgb(250, 250, 250)
        '    lbl_contacto.ForeColor = Color.White
        '    Me.BackColor = Color.FromArgb(141, 193, 222)
        'End If

        'If mirutempresa = "76820004-1" Then
        '    MenuStrip1.ForeColor = Color.White
        '    MenuStrip1.BackColor = Color.FromArgb(10, 33, 61)
        '    lbl_fecha.ForeColor = Color.FromArgb(10, 33, 61)
        '    lbl_hora.ForeColor = Color.FromArgb(10, 33, 61)
        '    lbl_version.ForeColor = Color.FromArgb(10, 33, 61)
        '    lbl_mensaje.ForeColor = Color.FromArgb(10, 33, 61)
        '    lbl_soporte_remoto.ForeColor = Color.FromArgb(10, 33, 61)
        '    lbl_uc.ForeColor = Color.FromArgb(10, 33, 61)
        '    lbl_usuario_conectado.ForeColor = Color.FromArgb(10, 33, 61)
        '    Panel_pie.BackColor = Color.FromArgb(10, 33, 61)
        '    lbl_pie.ForeColor = Color.FromArgb(250, 250, 250)
        '    lbl_contacto.ForeColor = Color.White
        '    Me.BackColor = Color.FromArgb(141, 193, 222)
        'End If

        'If mirutempresa = "16621207-3" Then
        '    MenuStrip1.ForeColor = Color.White
        '    MenuStrip1.BackColor = Color.FromArgb(80, 76, 172)
        '    lbl_fecha.ForeColor = Color.FromArgb(80, 76, 172)
        '    lbl_hora.ForeColor = Color.FromArgb(80, 76, 172)
        '    lbl_version.ForeColor = Color.FromArgb(80, 76, 172)
        '    lbl_mensaje.ForeColor = Color.FromArgb(80, 76, 172)
        '    lbl_soporte_remoto.ForeColor = Color.FromArgb(80, 76, 172)
        '    lbl_uc.ForeColor = Color.FromArgb(80, 76, 172)
        '    lbl_usuario_conectado.ForeColor = Color.FromArgb(80, 76, 172)
        '    Panel_pie.BackColor = Color.FromArgb(80, 76, 172)
        '    lbl_pie.ForeColor = Color.FromArgb(250, 250, 250)
        '    lbl_contacto.ForeColor = Color.White
        '    Me.BackColor = Color.FromArgb(141, 193, 222)
        'End If

        'If mirutempresa = "16972940-9" Then
        '    MenuStrip1.ForeColor = Color.White
        '    MenuStrip1.BackColor = Color.FromArgb(48, 100, 137)
        '    lbl_fecha.ForeColor = Color.FromArgb(48, 100, 137)
        '    lbl_hora.ForeColor = Color.FromArgb(48, 100, 137)
        '    lbl_version.ForeColor = Color.FromArgb(48, 100, 137)
        '    lbl_mensaje.ForeColor = Color.FromArgb(48, 100, 137)
        '    lbl_soporte_remoto.ForeColor = Color.FromArgb(48, 100, 137)
        '    lbl_uc.ForeColor = Color.FromArgb(48, 100, 137)
        '    lbl_usuario_conectado.ForeColor = Color.FromArgb(48, 100, 137)
        '    Panel_pie.BackColor = Color.FromArgb(48, 100, 137)
        '    lbl_pie.ForeColor = Color.FromArgb(0, 165, 233)
        '    lbl_contacto.ForeColor = Color.White
        '    Me.BackColor = Color.FromArgb(141, 193, 222)
        'End If


        'If mirutempresa = "12413179-0" Then
        '    MenuStrip1.ForeColor = Color.White
        '    MenuStrip1.BackColor = Color.FromArgb(0, 0, 0)
        '    lbl_fecha.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_hora.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_version.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_mensaje.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_soporte_remoto.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_uc.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_usuario_conectado.ForeColor = Color.FromArgb(0, 0, 0)
        '    Panel_pie.BackColor = Color.FromArgb(0, 0, 0)
        '    lbl_pie.ForeColor = Color.FromArgb(211, 33, 33)
        '    lbl_contacto.ForeColor = Color.White
        '    Me.BackColor = Color.FromArgb(141, 193, 222)
        'End If


        'If mirutempresa = "87686300-6" Then
        '    MenuStrip1.ForeColor = Color.White
        '    MenuStrip1.BackColor = Color.FromArgb(24, 49, 106)
        '    lbl_fecha.ForeColor = Color.FromArgb(24, 49, 106)
        '    lbl_hora.ForeColor = Color.FromArgb(24, 49, 106)
        '    lbl_version.ForeColor = Color.FromArgb(24, 49, 106)
        '    lbl_mensaje.ForeColor = Color.FromArgb(24, 49, 106)
        '    lbl_soporte_remoto.ForeColor = Color.FromArgb(24, 49, 106)
        '    lbl_uc.ForeColor = Color.FromArgb(24, 49, 106)
        '    lbl_usuario_conectado.ForeColor = Color.FromArgb(24, 49, 106)
        '    Panel_pie.BackColor = Color.FromArgb(24, 49, 106)
        '    lbl_pie.ForeColor = Color.FromArgb(242, 182, 49)
        '    lbl_contacto.ForeColor = Color.White
        'End If

        'If mirutempresa = "76536823-5" Then
        '    MenuStrip1.ForeColor = Color.White
        '    MenuStrip1.BackColor = Color.FromArgb(108, 193, 39)
        '    lbl_fecha.ForeColor = Color.FromArgb(108, 193, 39)
        '    lbl_hora.ForeColor = Color.FromArgb(108, 193, 39)
        '    lbl_version.ForeColor = Color.FromArgb(108, 193, 39)
        '    lbl_mensaje.ForeColor = Color.FromArgb(149, 149, 149)
        '    lbl_soporte_remoto.ForeColor = Color.FromArgb(108, 193, 39)
        '    lbl_uc.ForeColor = Color.FromArgb(108, 193, 39)
        '    lbl_usuario_conectado.ForeColor = Color.FromArgb(108, 193, 39)
        '    Panel_pie.BackColor = Color.FromArgb(108, 193, 39)
        '    lbl_pie.ForeColor = Color.FromArgb(255, 255, 255)
        '    lbl_contacto.ForeColor = Color.White
        'End If

        'If mirutempresa = "81921000-4" Then
        '    MenuStrip1.ForeColor = Color.White
        '    MenuStrip1.BackColor = Color.FromArgb(217, 0, 0)
        '    lbl_fecha.ForeColor = Color.FromArgb(217, 0, 0)
        '    lbl_hora.ForeColor = Color.FromArgb(217, 0, 0)
        '    lbl_version.ForeColor = Color.FromArgb(217, 0, 0)
        '    lbl_mensaje.ForeColor = Color.FromArgb(217, 0, 0)
        '    lbl_soporte_remoto.ForeColor = Color.FromArgb(217, 0, 0)
        '    lbl_uc.ForeColor = Color.FromArgb(217, 0, 0)
        '    lbl_usuario_conectado.ForeColor = Color.FromArgb(217, 0, 0)
        '    Panel_pie.BackColor = Color.FromArgb(217, 0, 0)
        '    lbl_pie.ForeColor = Color.FromArgb(242, 182, 49)
        '    lbl_contacto.ForeColor = Color.White
        'End If

        'If mirutempresa = "13501829-5" Then
        '    MenuStrip1.ForeColor = Color.White
        '    MenuStrip1.BackColor = Color.FromArgb(217, 0, 0)
        '    lbl_fecha.ForeColor = Color.FromArgb(217, 0, 0)
        '    lbl_hora.ForeColor = Color.FromArgb(217, 0, 0)
        '    lbl_version.ForeColor = Color.FromArgb(217, 0, 0)
        '    lbl_mensaje.ForeColor = Color.FromArgb(217, 0, 0)
        '    lbl_soporte_remoto.ForeColor = Color.FromArgb(217, 0, 0)
        '    lbl_uc.ForeColor = Color.FromArgb(217, 0, 0)
        '    lbl_usuario_conectado.ForeColor = Color.FromArgb(217, 0, 0)
        '    Panel_pie.BackColor = Color.FromArgb(217, 0, 0)
        '    lbl_pie.ForeColor = Color.FromArgb(242, 182, 49)
        '    lbl_contacto.ForeColor = Color.White
        'End If


        'If mirutempresa = "76313245-5" Then
        '    MenuStrip1.ForeColor = Color.White
        '    MenuStrip1.BackColor = Color.FromArgb(0, 0, 0)
        '    lbl_fecha.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_hora.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_version.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_mensaje.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_soporte_remoto.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_uc.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_usuario_conectado.ForeColor = Color.FromArgb(0, 0, 0)
        '    Panel_pie.BackColor = Color.FromArgb(0, 0, 0)
        '    lbl_pie.ForeColor = Color.FromArgb(255, 255, 255)
        '    lbl_contacto.ForeColor = Color.White
        'End If

        'If mirutempresa = "8445963-1" Then
        '    MenuStrip1.ForeColor = Color.White
        '    MenuStrip1.BackColor = Color.FromArgb(0, 0, 0)
        '    lbl_fecha.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_hora.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_version.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_mensaje.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_soporte_remoto.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_uc.ForeColor = Color.FromArgb(0, 0, 0)
        '    lbl_usuario_conectado.ForeColor = Color.FromArgb(0, 0, 0)
        '    Panel_pie.BackColor = Color.FromArgb(0, 0, 0)
        '    lbl_pie.ForeColor = Color.FromArgb(246, 180, 18)
        '    lbl_contacto.ForeColor = Color.White
        'End If
    End Sub

    Sub empresa()
        Me.lbl_pie.Text = mipiemenuempresa
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
        '    micorreoempresa = DS.Tables(DT.TableName).Rows(0).Item("correo_empresa")
        '    miclavecorreoempresa = DS.Tables(DT.TableName).Rows(0).Item("clave_correo_empresa")
        '    miciudadempresa = DS.Tables(DT.TableName).Rows(0).Item("ciudad_empresa")
        '    mititularetiquetaempresa = DS.Tables(DT.TableName).Rows(0).Item("titular_etiqueta")
        '    mipiemenuempresa = DS.Tables(DT.TableName).Rows(0).Item("pie_menu")
        '    mi_tipo_sucursal_empresa = DS.Tables(DT.TableName).Rows(0).Item("tipo_sucursal")
        '    MiCorreoEmpresaAdministracion = DS.Tables(DT.TableName).Rows(0).Item("correo_empresa_administracion")
        '    MiClaveCorreoEmpresaAdministracion = DS.Tables(DT.TableName).Rows(0).Item("clave_correo_empresa_administracion")
        '    MiWebEmpresa = DS.Tables(DT.TableName).Rows(0).Item("web_empresa")
        '    Me.lbl_pie.Text = DS.Tables(DT.TableName).Rows(0).Item("pie_menu")
        'End If
        'conexion.Close()
    End Sub

    Sub agregar_tareas()

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `proveedores` ADD COLUMN `nombre_fantasia_proveedor` VARCHAR(75) NULL DEFAULT '-' AFTER `nombre_proveedor`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch ex As Exception
        '    'MsgBox(ex)
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `empresa` ADD COLUMN `fecha_resolucion` DATE NULL DEFAULT '2020-01-01' AFTER `rut_representante`, ADD COLUMN `nro_resolucion` VARCHAR(45) NULL DEFAULT 0 AFTER `fecha_resolucion`,ADD COLUMN `rut_certificado_digital` VARCHAR(45) NULL DEFAULT '-' AFTER `nro_resolucion`,ADD COLUMN `nombre_certificado_digital` VARCHAR(45) NULL DEFAULT '-' AFTER `rut_certificado_digital`,ADD COLUMN `cod_actividad_economica` VARCHAR(45) NULL DEFAULT 0 AFTER `nombre_certificado_digital`,ADD COLUMN `clave_conector` VARCHAR(45) NULL DEFAULT '0',ADD COLUMN `produccion_sii` VARCHAR(45) NULL DEFAULT '0';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch ex As Exception
        '    'MsgBox(ex)
        'End Try

        'Try
        '        SC.Connection = conexion
        '        SC.CommandText = "CREATE TABLE listado_documentos Like factura"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch ex As Exception
        '        'MsgBox(ex)
        '    End Try

        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "ALTER TABLE listado_documentos CHANGE COLUMN `n_factura` `nro_documento` INT(11) NULL DEFAULT NULL AFTER `documento`, CHANGE COLUMN `tipo` `documento` VARCHAR(18) NULL DEFAULT NULL, ADD COLUMN `codigo_documento` VARCHAR(45) NULL AFTER `cod_auto`;"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch ex As Exception
        '        'MsgBox(ex)
        '    End Try

        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "ALTER TABLE `listado_documentos` ADD COLUMN `exento` INT(11) NULL DEFAULT '0' AFTER `subtotal`, ADD COLUMN `folio_sii` INT(11) NULL DEFAULT '0' AFTER `estado_vuelto`;"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch ex As Exception
        '        'MsgBox(ex)
        '    End Try

        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "ALTER TABLE `listado_documentos` ADD COLUMN `doc_referencia` VARCHAR(45) NULL DEFAULT '-' AFTER `folio_sii`, ADD COLUMN `nro_referencia` INT(11) NULL DEFAULT 0 AFTER `doc_referencia`, ADD COLUMN `fecha_doc_referencia` DATE NULL DEFAULT '0000-00-00' AFTER `nro_referencia`, ADD COLUMN `accion_referencia` VARCHAR(45) NULL DEFAULT '-' AFTER `fecha_doc_referencia`;"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch ex As Exception
        '        'MsgBox(ex)
        '    End Try




        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "ALTER TABLE `listado_documentos`  ADD COLUMN `tipo_de_traslado` VARCHAR(45) NULL DEFAULT '-' AFTER `accion_referencia`, ADD COLUMN `trasladado_por` VARCHAR(45) NULL DEFAULT '-' AFTER `tipo_de_traslado`;"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch ex As Exception
        '        'MsgBox(ex)
        '    End Try

        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "ALTER TABLE `productos` ADD COLUMN `exento` TINYINT(1) NULL DEFAULT 0 AFTER `tipo_medida`;"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch ex As Exception
        '        'MsgBox(ex)
        '    End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `guia` ADD COLUMN `orden_de_compra` INT(11) NULL DEFAULT 0 AFTER `comision`, ADD COLUMN `fecha_orden_de_compra` DATE NULL DEFAULT '0000-00-00' AFTER `orden_de_compra`, ADD COLUMN `nro_atencion` INT(11) NULL DEFAULT 0 AFTER `fecha_orden_de_compra`, ADD COLUMN `fecha_nro_atencion` DATE NULL DEFAULT '0000-00-00' AFTER `nro_atencion`, ADD COLUMN `hoja_entrada` INT(11) NULL DEFAULT 0 AFTER `fecha_nro_atencion`, ADD COLUMN `fecha_hoja_entrada` DATE NULL DEFAULT '0000-00-00' AFTER `hoja_entrada`, ADD COLUMN `otra_referencia` VARCHAR(45) NULL DEFAULT '-' AFTER `fecha_hoja_entrada`, ADD COLUMN `nro_otra_referencia` INT(11) NULL DEFAULT 0 AFTER `otra_referencia`, ADD COLUMN `fecha_otra_referencia` DATE NULL DEFAULT '0000-00-00' AFTER `nro_otra_referencia`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch ex As Exception
        '    'MsgBox(ex)
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `factura` ADD COLUMN `orden_de_compra` INT(11) NULL DEFAULT 0 AFTER `comision`, ADD COLUMN `fecha_orden_de_compra` DATE NULL DEFAULT '0000-00-00' AFTER `orden_de_compra`, ADD COLUMN `nro_atencion` INT(11) NULL DEFAULT 0 AFTER `fecha_orden_de_compra`, ADD COLUMN `fecha_nro_atencion` DATE NULL DEFAULT '0000-00-00' AFTER `nro_atencion`, ADD COLUMN `hoja_entrada` INT(11) NULL DEFAULT 0 AFTER `fecha_nro_atencion`, ADD COLUMN `fecha_hoja_entrada` DATE NULL DEFAULT '0000-00-00' AFTER `hoja_entrada`, ADD COLUMN `otra_referencia` VARCHAR(45) NULL DEFAULT '-' AFTER `fecha_hoja_entrada`, ADD COLUMN `nro_otra_referencia` INT(11) NULL DEFAULT 0 AFTER `otra_referencia`, ADD COLUMN `fecha_otra_referencia` DATE NULL DEFAULT '0000-00-00' AFTER `nro_otra_referencia`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch ex As Exception
        '    'MsgBox(ex)
        'End Try





        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `guia` CHANGE COLUMN `orden_de_compra` `orden_de_compra` VARCHAR(11) NULL DEFAULT '0' ,CHANGE COLUMN `nro_atencion` `nro_atencion` VARCHAR(11) NULL DEFAULT '0' ,CHANGE COLUMN `hoja_entrada` `hoja_entrada` VARCHAR(11) NULL DEFAULT '0' ,CHANGE COLUMN `nro_otra_referencia` `nro_otra_referencia` VARCHAR(11) NULL DEFAULT '0' ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch ex As Exception
        '    'MsgBox(ex)
        'End Try


        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `factura` CHANGE COLUMN `orden_de_compra` `orden_de_compra` VARCHAR(11) NULL DEFAULT '0' ,CHANGE COLUMN `nro_atencion` `nro_atencion` VARCHAR(11) NULL DEFAULT '0' ,CHANGE COLUMN `hoja_entrada` `hoja_entrada` VARCHAR(11) NULL DEFAULT '0' ,CHANGE COLUMN `nro_otra_referencia` `nro_otra_referencia` VARCHAR(11) NULL DEFAULT '0' ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch ex As Exception
        '    'MsgBox(ex)
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `compra` CHANGE COLUMN `usuario_responsable` `usuario_responsable` VARCHAR(45) NULL DEFAULT NULL AFTER `tipo_emision`,ADD COLUMN `total_automatico` INT(11) NULL AFTER `usuario_responsable`,ADD COLUMN `diferencia` INT(11) NULL AFTER `total_automatico`,ADD COLUMN `porcentaje_diferencia` VARCHAR(11) NULL AFTER `diferencia`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch ex As Exception
        '    'MsgBox(ex)
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `compra` CHANGE COLUMN `total_automatico` `total_automatico` INT(11) NULL DEFAULT 0 ,CHANGE COLUMN `diferencia` `diferencia` INT(11) NULL DEFAULT 0 ,CHANGE COLUMN `porcentaje_diferencia` `porcentaje_diferencia` VARCHAR(11) NULL DEFAULT 0 ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch ex As Exception
        '    'MsgBox(ex)
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `comision` ADD COLUMN `cantidad_sku` VARCHAR(45) NULL AFTER `comision`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch ex As Exception
        '    'MsgBox(ex)
        'End Try

        'If mirutempresa = "76820004-1" Then
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE `formas_de_pago` (`cod_auto` INT Not NULL AUTO_INCREMENT, `tipo_documento` VARCHAR(45) NULL, `forma_de_pago` VARCHAR(45) NULL, `por_defecto` VARCHAR(45) NULL, PRIMARY KEY (`cod_auto`));"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch ex As Exception
        '    'MsgBox(ex)
        'End Try


        'conexion.Close()
        'Consultas_SQL("select * from formas_de_pago")
        'If DS.Tables(DT.TableName).Rows.Count = 0 Then

        '    Try
        '        'BOLETAS
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('BOLETA', 'EFECTIVO', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('BOLETA', 'TARJETA DEBITO', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('BOLETA', 'TARJETA CREDITO', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('BOLETA', 'CHEQUE AL DIA', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('BOLETA', 'CHEQUE 30 DIAS', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('BOLETA', 'CHEQUE 30-60 DIAS', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('BOLETA', 'CHEQUE 30-60-90 DIAS', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('BOLETA', 'TRANSFERENCIA', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('BOLETA', 'PENDIENTE', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('BOLETA', 'LETRAS', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)

        '        'FACTURAS
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('FACTURA', 'EFECTIVO', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('FACTURA', 'TARJETA DEBITO', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('FACTURA', 'TARJETA CREDITO', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('FACTURA', 'CHEQUE AL DIA', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('FACTURA', 'CHEQUE 30 DIAS', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('FACTURA', 'CHEQUE 30-60 DIAS', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('FACTURA', 'CHEQUE 30-60-90 DIAS', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('FACTURA', 'TRANSFERENCIA', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('FACTURA', 'PENDIENTE', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('FACTURA', 'LETRAS', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)

        '        'FACTURAS
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('COTIZACION', 'EFECTIVO', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `formas_de_pago` (`tipo_documento`, `forma_de_pago`, `por_defecto`) VALUES ('COTIZACION', 'CREDITO', 'NO');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)

        '    Catch ex As Exception
        '        'MsgBox(ex)
        '    End Try

        'End If
        'End If

        'Try
        '        SC.Connection = conexion
        '        SC.CommandText = "ALTER TABLE `valores` ADD COLUMN `validez_cotizacion` INT(11) NULL DEFAULT 3 AFTER `restriccion_ingreso_clientes`;"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch
        '    End Try


        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "ALTER TABLE `valores` ADD COLUMN `cierre_sistema` VARCHAR(2) NULL DEFAULT 'SI' AFTER `validez_cotizacion`;"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch ex As Exception
        '        ' MsgBox(ex)
        '    End Try



        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "ALTER TABLE `basededatos`.`documento_temporal` ADD COLUMN `nro_venta` INT(11) NULL AFTER `unidad_medida`;"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch ex As Exception
        '        ' MsgBox(ex)
        '    End Try




        '    If mirutempresa = "13501829-5" Then

        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "ALTER TABLE `impresoras`  ADD COLUMN `ticket_abonos` VARCHAR(75) NULL AFTER `traspaso_sucursal`, ADD COLUMN `ticket_anticipos` VARCHAR(75) NULL AFTER `ticket_abonos`, ADD COLUMN `ticket_caja` VARCHAR(75) NULL AFTER `ticket_anticipos`, ADD COLUMN `ticket_tarjeta_presentacion` VARCHAR(75) NULL AFTER `ticket_caja`, ADD COLUMN `ticket_cotizaciones` VARCHAR(75) NULL AFTER `ticket_tarjeta_presentacion`, ADD COLUMN `ticket_estado_de_cuenta` VARCHAR(75) NULL AFTER `ticket_cotizaciones`, ADD COLUMN `ticket_pedidos` VARCHAR(75) NULL AFTER `ticket_estado_de_cuenta`, ADD COLUMN `ticket_ventas` VARCHAR(75) NULL AFTER `ticket_pedidos`, ADD COLUMN `ticket_vales_de_cambio` VARCHAR(75) NULL AFTER `ticket_ventas`, ADD COLUMN `ticket_envios_sucursal` VARCHAR(75) NULL AFTER `ticket_vales_de_cambio`;"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch ex As Exception
        '            ' MsgBox(ex)
        '        End Try

        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "ALTER TABLE `impresoras` CHANGE COLUMN `nota_de_debito` `nota_de_debito` VARCHAR(75) NULL DEFAULT NULL AFTER `tipo_impresion`, ADD COLUMN `tipo_impresion_boleta` VARCHAR(45) NULL DEFAULT 'INTERNA' AFTER `ticket_consumo_interno`, ADD COLUMN `tipo_impresion_factura` VARCHAR(45) NULL DEFAULT 'INTERNA' AFTER `tipo_impresion_boleta`, ADD COLUMN `tipo_impresion_guia` VARCHAR(45) NULL DEFAULT 'INTERNA' AFTER `tipo_impresion_factura`, ADD COLUMN `tipo_impresion_nota_de_credito` VARCHAR(45) NULL DEFAULT 'INTERNA' AFTER `tipo_impresion_guia`, ADD COLUMN `tipo_impresion_nota_de_debito` VARCHAR(45) NULL DEFAULT 'INTERNA' AFTER `tipo_impresion_nota_de_credito`;"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch ex As Exception
        '            ' MsgBox(ex)
        '        End Try



        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "ALTER TABLE `impresoras` ADD COLUMN `ticket_registro_de_cheques` VARCHAR(75) NULL AFTER `ticket_envios_sucursal`;"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch
        '        End Try

        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "ALTER TABLE `impresoras` ADD COLUMN `ticket_consumo_interno` VARCHAR(75) NULL AFTER `ticket_registro_de_cheques`;"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch
        '        End Try



        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "Update `impresoras` Set ticket_abonos=ticket WHERE `codigo`<>'0';"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch
        '        End Try

        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "Update `impresoras` Set ticket_anticipos=ticket WHERE `codigo`<>'0';"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch
        '        End Try

        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "Update `impresoras` Set ticket_caja=ticket WHERE `codigo`<>'0';"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch
        '        End Try

        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "Update `impresoras` Set ticket_anticipos=ticket WHERE `codigo`<>'0';"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch
        '        End Try

        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "Update `impresoras` Set ticket_tarjeta_presentacion=ticket WHERE `codigo`<>'0';"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch
        '        End Try

        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "Update `impresoras` Set ticket_cotizaciones=ticket WHERE `codigo`<>'0';"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch
        '        End Try

        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "Update `impresoras` Set ticket_tarjeta_presentacion=ticket WHERE `codigo`<>'0';"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch
        '        End Try

        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "Update `impresoras` Set ticket_estado_de_cuenta=ticket WHERE `codigo`<>'0';"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch
        '        End Try

        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "Update `impresoras` Set ticket_pedidos=ticket WHERE `codigo`<>'0';"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch
        '        End Try

        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "Update `impresoras` Set ticket_ventas=ticket WHERE `codigo`<>'0';"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch
        '        End Try

        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "Update `impresoras` Set ticket_vales_de_cambio=ticket WHERE `codigo`<>'0';"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch
        '        End Try


        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "Update `impresoras` Set ticket_envios_sucursal=ticket WHERE `codigo`<>'0';"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch
        '        End Try

        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "Update `impresoras` Set ticket_consumo_interno=ticket WHERE `codigo`<>'0';"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch
        '        End Try



        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "Update `impresoras` Set ticket_registro_de_cheques=ticket WHERE `codigo`<>'0';"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch
        '        End Try

        '    End If


        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `valores` ADD COLUMN `validez_cotizacion` INT(11) NULL DEFAULT 3 AFTER `restriccion_ingreso_clientes`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try



        'Try
        '        SC.Connection = conexion
        '        SC.CommandText = "ALTER TABLE `envios_recibidos` ADD COLUMN `hora` VARCHAR(8) NULL DEFAULT '00:00:00' AFTER `rut_proveedor`;"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch
        '    End Try



        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "ALTER TABLE `detalle_consumo_interno` ADD COLUMN `hora` VARCHAR(8) NULL DEFAULT '00:00:00' AFTER `rut_proveedor`;"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch
        '    End Try



        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "ALTER TABLE `ajustes_de_stock` ADD COLUMN `hora` VARCHAR(8) NULL DEFAULT '00:00:00' AFTER `rut_proveedor`;"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch
        '    End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = " ALTER TABLE `subfamilia_dos` ADD COLUMN `volumen` INT(11) NULL DEFAULT 0 AFTER `medida_3`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `valores` CHANGE COLUMN `restrinccion_ingreso_clientes` `restriccion_ingreso_clientes` VARCHAR(2) NULL DEFAULT 'SI' ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `valores` ADD COLUMN `restrinccion_ingreso_clientes` VARCHAR(2) NULL DEFAULT 'SI' AFTER `redondear_venta`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `documento_temporal` ADD COLUMN `unidad_medida` VARCHAR(45) NULL AFTER `descuento_2`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `productos` ADD COLUMN `tipo_medida` VARCHAR(45) NULL DEFAULT 'UNIDAD' AFTER `fecha_conteo`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'If mirutempresa = "76366176-8" Then
        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `productos` SET `tipo_medida`='DECIMAL' WHERE `cod_producto`='000162';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)

        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `productos` SET `tipo_medida`='DECIMAL' WHERE `cod_producto`<>'000162';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'End If

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `empresa` ADD COLUMN `link_red_social` VARCHAR(75) NULL AFTER `web_empresa`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try



        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `empresa` SET `link_red_social`='-' WHERE `cod_empresa`<>'0';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `valores` ADD COLUMN `redondear_venta` VARCHAR(2) NULL DEFAULT 'SI' AFTER `valor_descuento_ventas`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'If mirutempresa = "76366176-8" Then
        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `valores` SET `redondear_venta`='NO' WHERE `cod_auto`<>'0';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'End If
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "INSERT INTO `clientes` (`cod_cliente`, `rut_cliente`, `nombre_cliente`, `direccion_cliente`, `telefono_cliente`, `ciudad_cliente`, `comuna_cliente`, `giro_cliente`, `email_cliente`, `tipo_cliente`, `descuento_1`, `descuento_2`, `cuenta_cliente`) VALUES ('0', '-', '-', '-', '0', '-', '-', '-', '-', '-', '0', '0', '-');"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `subfamilia_dos` ADD COLUMN `medida_1` VARCHAR(11) NULL DEFAULT 0 AFTER `fecha_conteo`, ADD COLUMN `medida_2` VARCHAR(11) NULL DEFAULT 0 AFTER `medida_1`, ADD COLUMN `medida_3` VARCHAR(11) NULL DEFAULT 0 AFTER `medida_2`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'If mirutempresa = "16621207-3" Then
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "UPDATE `productos` SET `proveedor`='11111111-1' WHERE `cod_producto`='000000';"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch
        '    End Try

        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "UPDATE `productos` SET `proveedor`='11111111-1' WHERE `cod_producto`<>'000000';"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch
        '    End Try
        'End If

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `familia` DROP FOREIGN KEY `subfamilia`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE `revision_stock` (`cod_auto` INT NOT NULL,`cod_producto` VARCHAR(45) NULL,`fecha_revision` DATE NULL, `estado` VARCHAR(45) NULL DEFAULT 'EN ESPERA',`usuario_responsable` VARCHAR(45) NULL, PRIMARY KEY (`cod_auto`));"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `revision_stock` CHANGE COLUMN `cod_auto` `cod_auto` INT(11) NOT NULL AUTO_INCREMENT ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `revision_stock` ADD COLUMN `stock_sugerido` VARCHAR(45) NULL AFTER `estado`,ADD COLUMN `comentarios` VARCHAR(200) NULL AFTER `stock_sugerido`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE `equipos_de_cajas` (`cod_auto` INT NOT NULL AUTO_INCREMENT,`nombre_caja` VARCHAR(45) NULL,`fecha_modificacion` DATE NULL,`usuario_responsable` VARCHAR(45) NULL,  PRIMARY KEY(`cod_auto`));"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE `cajas` (`cod_auto` INT NOT NULL AUTO_INCREMENT,`nombre_caja` VARCHAR(45) NULL,`fecha_modificacion` DATE NULL,`usuario_responsable` VARCHAR(45) NULL,  PRIMARY KEY(`cod_auto`));"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `detalle_condicion_de_pago` ADD COLUMN `caja` VARCHAR(45) NULL DEFAULT '-' AFTER `fecha`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '        SC.Connection = conexion
        '        SC.CommandText = "ALTER TABLE `detalle_cuadratura_caja` ADD COLUMN `caja` VARCHAR(45) NULL AFTER `hora`;"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch
        '    End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `detalle_condiciones` ADD COLUMN `usuario_responsable` VARCHAR(45) NULL AFTER `monto`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `boleta` ADD COLUMN `caja` VARCHAR(45) NULL DEFAULT '-' AFTER `n_boleta`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `guia` ADD COLUMN `caja` VARCHAR(45) NULL DEFAULT '-' AFTER `n_guia`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `factura` ADD COLUMN `caja` VARCHAR(45) NULL DEFAULT '-' AFTER `n_factura`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `nota_credito` ADD COLUMN `caja` VARCHAR(45) NULL DEFAULT '-' AFTER `n_nota_credito`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `nota_debito` ADD COLUMN `caja` VARCHAR(45) NULL DEFAULT '-' AFTER `n_nota_debito`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `abono` ADD COLUMN `caja` VARCHAR(45) NULL DEFAULT '-' AFTER `n_abono`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `clientes` ADD COLUMN `telefono_cliente_dos` VARCHAR(45) NULL DEFAULT 0 AFTER `fecha_pagare`,ADD COLUMN `email_cliente_dos` VARCHAR(45) NULL DEFAULT '-' AFTER `telefono_cliente_dos`,ADD COLUMN `nombre_representante` VARCHAR(75) NULL DEFAULT '-' AFTER `email_cliente_dos`,ADD COLUMN `email_representante` VARCHAR(45) NULL DEFAULT '-' AFTER `nombre_representante`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE `empresas_relacionadas` (  `cod_auto` INT NOT NULL AUTO_INCREMENT,  `rut_empresa` VARCHAR(45) NULL,  `rut_empresa_relacionada` VARCHAR(45) NULL,  `nombre_empresa_relacionada` VARCHAR(75) NULL,  `usuario_responable` VARCHAR(45) NULL,  PRIMARY KEY (`cod_auto`));"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '        SC.Connection = conexion
        '        SC.CommandText = "ALTER TABLE `detalle_ticket_venta` ADD COLUMN `hora` VARCHAR(45) NULL AFTER `cod_auto`;"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch
        '    End Try

        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "  ALTER TABLE `detalle_ticket_venta` ADD COLUMN `usuario_responsable` VARCHAR(45) NULL AFTER `hora`;"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch
        '    End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `detalle_ticket_venta` ADD COLUMN `fecha_venta` DATE NULL AFTER `cod_auto`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE `correo_de_ventas` (`cod_auto` INT NOT NULL AUTO_INCREMENT, `correo` VARCHAR(45) NULL, `clave_correo` VARCHAR(45) NULL, `seguridad_ssl` VARCHAR(45) NULL, `puerto_smtp` VARCHAR(45) NULL, PRIMARY KEY (`cod_auto`));"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE `correo_de_administracion` (`cod_auto` INT NOT NULL AUTO_INCREMENT, `correo` VARCHAR(45) NULL, `clave_correo` VARCHAR(45) NULL, `seguridad_ssl` VARCHAR(45) NULL, `puerto_smtp` VARCHAR(45) NULL, PRIMARY KEY (`cod_auto`));"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `correo_de_ventas` ADD COLUMN `servidor_smtp` VARCHAR(45) NULL AFTER `puerto_smtp`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `correo_de_administracion` ADD COLUMN `servidor_smtp` VARCHAR(45) NULL AFTER `puerto_smtp`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `detalle_compra` ADD COLUMN `tipo` VARCHAR(45) NULL AFTER `precio_anterior`, ADD COLUMN `tipo_emision` VARCHAR(45) NULL AFTER `tipo`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = " ALTER TABLE `compra` ADD COLUMN `tipo_emision` VARCHAR(45) NULL AFTER `precio_anterior`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `cheques` ADD COLUMN `estado` VARCHAR(45) NULL AFTER `hora`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `guia` CHANGE COLUMN `n_guia` `n_guia` INT(11) NULL DEFAULT NULL ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = " ALTER TABLE `control_de_despachos` CHANGE COLUMN `direccion_cliente` `direccion_cliente` VARCHAR(75) NULL DEFAULT NULL ,ADD COLUMN `referencia` VARCHAR(75) NULL AFTER `retiro`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `boleta` ADD COLUMN `ingreso` VARCHAR(45) NULL DEFAULT 'SISTEMA' AFTER `estado_vuelto`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE `inventario_diario` (  `cod_auto` INT NOT NULL AUTO_INCREMENT,  `cod_producto` VARCHAR(45) NULL,  `nombre` VARCHAR(45) NULL,  `numero_tecnico` VARCHAR(45) NULL,  `aplicacion` VARCHAR(45) NULL,  `familia` VARCHAR(45) NULL,  `proveedor` VARCHAR(45) NULL,  `cantidad` VARCHAR(45) NULL,  `fecha` DATE NULL,  PRIMARY KEY (`cod_auto`));"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = " ALTER TABLE `control_despachos` CHANGE COLUMN `direccion_cliente` `direccion_cliente` VARCHAR(75) NULL DEFAULT NULL ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `familia` ADD CONSTRAINT `subfamilia` FOREIGN KEY (`codigo`) REFERENCES `basededatos`.`subfamilia` (`cod_auto`) ON DELETE CASCADE ON UPDATE CASCADE;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `subfamilia` ADD CONSTRAINT `subfamilia_dos` FOREIGN KEY (`cod_auto`) REFERENCES `basededatos`.`subfamilia_dos` (`cod_auto`) ON DELETE CASCADE ON UPDATE CASCADE;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE `registros_eliminados` ( `cod_auto` INT NOT NULL AUTO_INCREMENT, `registro` VARCHAR(45) NULL, `codigo` VARCHAR(45) NULL, `fecha` DATE NULL, `usuario_responsable` VARCHAR(45) NULL, PRIMARY KEY (`cod_auto`));"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `usuarios` SET `clave`='55588825' WHERE `rut_usuario`='8803052-4';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE `consultas_sql` ( `cod_auto` INT NOT NULL AUTO_INCREMENT, `nombre` VARCHAR(45) NULL, `consulta` VARCHAR(750) NULL,  PRIMARY KEY (`cod_auto`));"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE `salida_de_trabajadores` ( `cod_auto` INT NOT NULL AUTO_INCREMENT,`tipo` VARCHAR(45) NULL, `rut_trabajador` VARCHAR(45) NULL, `desde` VARCHAR(45) NULL, `hasta` VARCHAR(45) NULL, `fecha` DATE NULL, `usuario_responsable` VARCHAR(45) NULL, PRIMARY KEY (`cod_auto`));"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `subfamilia_dos` ADD COLUMN `fecha_conteo` DATE NULL AFTER `o`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE `resumen_de_ventas_por_item_temporal` ( `cod_auto` INT NOT NULL AUTO_INCREMENT, `cod_producto` VARCHAR(45) NULL,`nombre_proveedor` VARCHAR(45) NULL, `nombre_producto` VARCHAR(45) NULL, `aplicacion` VARCHAR(45) NULL, `familia` VARCHAR(45) NULL, `precio` VARCHAR(45) NULL,  `costo` VARCHAR(45) NULL, `neto` VARCHAR(45) NULL,  `nombre_mes` VARCHAR(45) NULL, `total` VARCHAR(45) NULL, PRIMARY KEY (`cod_auto`));"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE `conteos` ( `cod_auto` INT NOT NULL AUTO_INCREMENT, `fecha` DATE NULL, `familia` VARCHAR(45) NULL, `subfamilia` VARCHAR(45) NULL, `subfamilia_dos` VARCHAR(45) NULL, `cod_producto` VARCHAR(45) NULL, `nombre_producto` VARCHAR(45) NULL, `numero_tecnico` VARCHAR(45) NULL, `cantidad` INT(11) NULL, PRIMARY KEY (`cod_auto`));"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `conteos` ADD COLUMN `n_conteo` INT(11) NULL AFTER `cantidad`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `conteos` CHANGE COLUMN `cantidad` `cantidad` VARCHAR(11) NULL DEFAULT NULL ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try


        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE `conteos_temporal` (`cod_auto` INT NOT NULL AUTO_INCREMENT, `subfamilia_dos` VARCHAR(45) NULL, `cantidad` INT(11) NULL, PRIMARY KEY (`cod_auto`));"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `productos` ADD COLUMN `fecha_conteo` DATE NULL AFTER `activo`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `productos` SET `fecha_conteo`='2014-01-01' WHERE `cod_producto`='000000';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `productos` SET `fecha_conteo`='2014-01-01' WHERE `cod_producto`<>'000000';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = " ALTER TABLE `vale` CHANGE COLUMN `cod_auto` `cod_auto` INT(11) NOT NULL , ADD COLUMN `valor_unitario` INT(11) NULL AFTER `cod_auto`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `vale` ADD COLUMN `nombre_producto` VARCHAR(75) NULL AFTER `valor_unitario`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `control_despachos` ADD COLUMN `fecha` DATE NULL  AFTER `recinto` ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `control_despachos` CHANGE COLUMN `cod_auto` `cod_auto` INT(11) NOT NULL ,ADD COLUMN `km_inicial` INT(11) NULL AFTER `fecha`,ADD COLUMN `km_final` INT(11) NULL AFTER `km_inicial`,ADD COLUMN `chofer` VARCHAR(45) NULL AFTER `km_final`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try



        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = " ALTER TABLE `control_despachos` CHANGE COLUMN `cod_auto` `cod_auto` INT(11) NOT NULL AUTO_INCREMENT ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE envios_recibidos LIKE detalle_total;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `envios_recibidos` CHANGE COLUMN `n_total` `n_documento` INT(11) NOT NULL ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE detalle_consumo_interno LIKE detalle_total;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `detalle_consumo_interno` CHANGE COLUMN `n_total` `n_documento` INT(11) NOT NULL ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try


        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE ajustes_de_stock LIKE detalle_total;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `ajustes_de_stock` CHANGE COLUMN `n_total` `n_ajuste` INT(11) NOT NULL ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "INSERT INTO envios_recibidos SELECT * FROM detalle_total;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "DELETE FROM `envios_recibidos` WHERE  tipo <> 'VALE DE CAMBIO' AND `cod_detalle`= '35856';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "DELETE FROM `envios_recibidos` WHERE  tipo <> 'VALE DE CAMBIO' AND `cod_detalle`<> '35856';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `documentos_faltantes` ADD COLUMN `estado` VARCHAR(45) NULL AFTER `usuario_responsable`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `subfamilia` CHANGE COLUMN `cod_auto` `cod_auto` INT(11) NOT NULL;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `subfamilia_dos` CHANGE COLUMN `cod_auto` `cod_auto` INT(11) NOT NULL;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `familia` CHANGE COLUMN `codigo` `codigo` INT(11) NOT NULL;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `subfamilia_dos` ADD COLUMN `fecha_modificacion` DATE AFTER `nombre_subfamilia`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `subfamilia` ADD COLUMN `fecha_modificacion` DATE AFTER `nombre_subfamilia`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `familia` ADD COLUMN `fecha_modificacion` DATE AFTER `nombre_familia`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `control_despachos` ADD COLUMN `recinto` VARCHAR(45) AFTER `cod_auto`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE `despachos_clientes` (`cod_auto` INT NOT NULL AUTO_INCREMENT,`nro_despacho` VARCHAR(45),`rut_cliente` VARCHAR(45),`nombre_cliente` VARCHAR(45),`comuna_cliente` VARCHAR(45),`direccion_cliente` VARCHAR(45),`telefono_cliente` VARCHAR(45),`tipo_doc` VARCHAR(45),`nro_doc` VARCHAR(45), PRIMARY KEY (`cod_auto`));"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE detalle_control_despachos LIKE detalle_boleta;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE `control_de_despachos` ( `n_despacho` VARCHAR(45),  `rut_cliente` VARCHAR(45), `nombre_cliente` VARCHAR(45), `comuna_cliente` VARCHAR(45), `direccion_cliente` VARCHAR(45), `telefono_cliente` VARCHAR(45), `tipo_doc` VARCHAR(45), `nro_doc` VARCHAR(45),  `retiro` VARCHAR(45),  PRIMARY KEY (`n_despacho`));"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE detalle_fondo_sueldos LIKE detalle_cuadratura_caja;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = " ALTER TABLE `detalle_control_despachos` CHANGE COLUMN `n_boleta` `n_despacho` INT(11) ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try



        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `control_de_despachos` RENAME TO  `control_despachos` ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `control_despachos` CHANGE COLUMN `n_despacho` `n_despacho` INT ,ADD COLUMN `cod_auto` INT(11) NOT NULL AUTO_INCREMENT AFTER `retiro`,DROP PRIMARY KEY,ADD PRIMARY KEY (`cod_auto`);"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try



        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `usuarios` SET `clave`='555876' WHERE `rut_usuario`='08803052-4';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `usuarios` SET `clave`='555876' WHERE `rut_usuario`='8803052-4';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `usuarios` ADD COLUMN `tope_anticipos` INT(11) NULL COMMENT '' AFTER `clave_autoriza`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `usuarios` SET `tope_anticipos`='150000' WHERE `rut_usuario`='';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `usuarios` SET `tope_anticipos`='150000' WHERE `rut_usuario`<>'';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `usuarios` ADD COLUMN `sueldo` INT(11) AFTER `tope_anticipos`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `usuarios` SET `sueldo`='275000' WHERE `rut_usuario`='';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `usuarios` SET `sueldo`='275000' WHERE `rut_usuario`<>'';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE `documentos_faltantes` ( `cod_auto` INT NOT NULL AUTO_INCREMENT, `TIPO` VARCHAR(45) NULL, `numero` VARCHAR(45) NULL, `fecha` DATE NULL, `usuario_responsable` VARCHAR(45) NULL,PRIMARY KEY (`cod_auto`));"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `familia` CHANGE COLUMN `codigo` `codigo` INT(11) NOT NULL DEFAULT NULL AUTO_INCREMENT  , CHANGE COLUMN `cod_auto` `cod_auto` INT(11) NOT NULL  , DROP PRIMARY KEY , ADD PRIMARY KEY (`codigo`, `cod_auto`) ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try



        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `familia` DROP COLUMN `cod_auto` , DROP PRIMARY KEY , ADD PRIMARY KEY (`codigo`) ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `nota_credito` ADD COLUMN `motivo` VARCHAR(75) NULL  AFTER `cod_auto` ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try


        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE orden_de_compra LIKE factura;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE detalle_orden_de_compra LIKE detalle_factura;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `orden_de_compra` CHANGE COLUMN `n_factura` `n_orden_de_compra` INT(11) NULL DEFAULT NULL  ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `detalle_orden_de_compra` CHANGE COLUMN `n_factura` `n_orden_de_compra` INT(11) NULL DEFAULT NULL  ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `BOLETA` CHANGE COLUMN `estado_vuelto` `estado_vuelto` VARCHAR(45) NULL DEFAULT 'NO'  ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `factura` CHANGE COLUMN `estado_vuelto` `estado_vuelto` VARCHAR(45) NULL DEFAULT 'NO'  ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "  CREATE TABLE clientes_que_retiran_por_empresas_eliminados LIKE clientes_que_retiran_por_empresas;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `clientes_que_retiran_por_empresas` ADD COLUMN `fecha_modificacion` DATE NULL  AFTER `usuario_responsable` ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try


        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `familia` ADD COLUMN `cod_auto` INT(11) NOT NULL AUTO_INCREMENT  AFTER `nombre_familia` , CHANGE COLUMN `codigo` `codigo` INT(11) NULL  , DROP PRIMARY KEY , ADD PRIMARY KEY (`cod_auto`) ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "INSERT INTO `familia` (`codigo`, `nombre_familia`) VALUES ('0', 'SIN FAMILIA');"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `familia` SET `codigo`='0' WHERE `cod_auto`<>'99999' and nombre_familia='SIN FAMILIA';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "INSERT INTO `subfamilia` (`codigo_familia`, `nombre_subfamilia`) VALUES ('0', 'SIN SUB FAMILIA');"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "INSERT INTO `subfamilia_dos` (`codigo_subfamilia`, `nombre_subfamilia`) VALUES ('0', 'SIN SUB FAMILIA DOS');"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `usuarios` SET `clave`='1988' WHERE `rut_usuario`='16972940-9';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE  TABLE `clientes_que_retiran_por_empresas` (`cod_auto` INT NOT NULL AUTO_INCREMENT ,`codigo_empresa` VARCHAR(45) NULL ,`rut_empresa` VARCHAR(45) NULL ,`rut_cliente` VARCHAR(45) NULL ,`nombre_cliente` VARCHAR(45) NULL ,`usuario_responsable` VARCHAR(45) NULL ,PRIMARY KEY (`cod_auto`) );"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try


        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE  TABLE `folio_cambio` ( `cod_auto` INT NOT NULL AUTO_INCREMENT , `nro_cambio` INT(11) NULL , `nro_guia` INT(11) NULL , PRIMARY KEY (`cod_auto`) );"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `valores` ADD COLUMN `valor_descuento_ventas` INT(11) NULL  AFTER `inventario_inicial`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `valores` SET `valor_descuento_ventas`='10' WHERE `cod_auto`='1';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "drop table `recepcion_de_trabajos`"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE `recepcion_de_trabajos` (  `cod_auto` int(11) NOT NULL AUTO_INCREMENT,`n_recepcion` int(11) DEFAULT NULL,  `rut_cliente` varchar(45) DEFAULT NULL,`diagnostico_tecnico` varchar(350) DEFAULT NULL,  `diagnostico_cliente` varchar(350) DEFAULT NULL,  `detalle_pago` varchar(45) DEFAULT NULL,  `cancelado` varchar(2) DEFAULT NULL,  `retirado` varchar(2) DEFAULT NULL,  `total_presupuesto` int(11) DEFAULT NULL,  `pago_parcial` int(11) DEFAULT NULL,  `estado` varchar(45) DEFAULT NULL,  `usuario_responsable` varchar(45) DEFAULT NULL,  `fecha` date DEFAULT NULL,  `hora` varchar(45) DEFAULT NULL,  PRIMARY KEY (`cod_auto`)) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "drop table `productos_imagenes`"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE `productos_imagenes` (  `cod_auto` int(11) NOT NULL AUTO_INCREMENT,  `cod_producto` varchar(45) DEFAULT NULL,  `imagen_producto` longblob,  PRIMARY KEY (`cod_auto`)) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try







        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `detalle_imputar_nota_credito` ADD COLUMN `sucursal` VARCHAR(45) NULL  AFTER `estado` ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '        SC.Connection = conexion
        '        SC.CommandText = "CREATE TABLE `detalle_cuadratura_caja` (  `cod_auto` int(11) NOT NULL AUTO_INCREMENT,`detalle` varchar(65) DEFAULT NULL,  `monto` int(11) DEFAULT NULL,`fecha` date DEFAULT NULL,  `TIPO` varchar(45) DEFAULT NULL,`usuario_responsable` varchar(45) DEFAULT NULL,`hora` varchar(45) DEFAULT NULL,  PRIMARY KEY (`cod_auto`)) ENGINE=InnoDB AUTO_INCREMENT=1137 DEFAULT CHARSET=latin1;"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch
        '    End Try


        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE  TABLE `recepcion_de_trabajos` (`cod_auto` INT NOT NULL AUTO_INCREMENT ,`n_recepcion` INT(11) NULL ,PRIMARY KEY (`cod_auto`) );"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try



        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `recepcion_de_trabajos` ADD COLUMN `cancelado` VARCHAR(2) NULL  AFTER `n_recepcion` , ADD COLUMN `detalle_pago` VARCHAR(45) NULL  AFTER `n_recepcion` , ADD COLUMN `diagnostico_cliente` VARCHAR(350) NULL  AFTER `n_recepcion` , ADD COLUMN `diagnostico_tecnico` VARCHAR(350) NULL  AFTER `n_recepcion` , ADD COLUMN `pago_parcial` INT(11) NULL  AFTER `cancelado` , ADD COLUMN `retirado` VARCHAR(2) NULL  AFTER `cancelado` , ADD COLUMN `rut_cliente` VARCHAR(45) NULL  AFTER `n_recepcion` , ADD COLUMN `total_presupuesto` INT(11) NULL  AFTER `retirado` ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE envio_garantias LIKE nota_credito;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE detalle_envio_garantias LIKE detalle_nota_credito;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try


        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `envio_garantias` CHANGE COLUMN `n_nota_credito` `n_envio_garantia` INT(11) NULL DEFAULT NULL  ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `detalle_envio_garantias` CHANGE COLUMN `n_nota_credito` `n_envio_garantia` INT(11) NOT NULL  , DROP INDEX `fcreditos` , ADD INDEX `fcreditos` (`n_envio_garantia` ASC) , DROP INDEX `r1` , ADD INDEX `r1` (`n_envio_garantia` ASC) ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE consumo_interno_temporal LIKE consumo_interno"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = " ALTER TABLE `consumo_interno` ADD COLUMN `motivo` VARCHAR(45) NULL  AFTER `cod_auto` ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE TABLE consumo_interno LIKE vale;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `consumo_interno` CHANGE COLUMN `n_vale` `n_consumo_interno` INT(11) NULL DEFAULT NULL  ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `consumo_interno` DROP COLUMN `despachador` , DROP COLUMN `sucursal` ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try



        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE  TABLE `control_meses_libro_de_compras` (`cod_auto` INT NOT NULL AUTO_INCREMENT ,`anual` VARCHAR(45) NULL ,`mensual` VARCHAR(45) NULL ,`estado` VARCHAR(45) NULL ,PRIMARY KEY (`cod_auto`) );"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `clientes` ADD COLUMN `fecha_pagare` DATE NULL  AFTER `pagare`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `valores` ADD COLUMN `inventario_inicial` DATE NULL  AFTER `uf` ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `valores` SET `inventario_inicial`='2017-04-23' WHERE `cod_auto`='1';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "CREATE  TABLE `guias_de_traslado_a_proveedores` (  `cod_auto` INT NOT NULL AUTO_INCREMENT ,`n_guia` INT(11) NULL ,`motivo` VARCHAR(60) NULL ,`solicitud` VARCHAR(60) NULL ,PRIMARY KEY (`cod_auto`) );"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'If mirutempresa = "81921000-4" Then
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "UPDATE `empresa` SET `correo_empresa`='WWW.OR.CL', `web_empresa`='WWW.OR.CL' WHERE `cod_empresa`='1';"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch
        '    End Try
        'End If

        'If mirutempresa = "81921000-4" Then
        '    If mirecintoempresa <> "VALDIVIA 060" Then
        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "DELETE FROM `registro_de_permisos` WHERE permiso='PRODUCTOS_ToolStripMenuItem' and `cod_auto`<>'0';"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch
        '        End Try
        '        Try
        '            SC.Connection = conexion
        '            SC.CommandText = "DELETE FROM `registro_de_permisos` WHERE permiso='PROVEEDORES_ToolStripMenuItem' and `cod_auto`<>'0';"
        '            DA.SelectCommand = SC
        '            DA.Fill(DT)
        '        Catch
        '        End Try
        '    End If
        'End If

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `impresoras` ADD COLUMN `traspaso_sucursal` VARCHAR(45) NULL  AFTER `ticket_2`;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "update impresoras set traspaso_sucursal = ticket;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'If mirutempresa = "81921000-4" Then

        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "DELETE FROM `usuarios` WHERE `rut_usuario`='17523196-K';"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch
        '    End Try
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "INSERT INTO `usuarios` (`rut_usuario`, `nombre_usuario`, `usuario`, `clave`, `tipo_usuario`, `pregunta_usuario`, `respuesta_usuario`, `area_usuario`, `telefono_usuario`, `autoriza_venta`,`tiempo_espera`, `fecha_modificacion`, ACTIVO) VALUES ('17523196-K', 'ANA MOYA T.', 'AMT', 'AMT', 'ADMINISTRADOR DEL SISTEMA', '-', '-', 'ADMINISTRACION', '942815789', 'NO','9999', '2017-03-06', 'SI');"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch
        '    End Try

        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "UPDATE `usuarios` SET `clave`='555876' WHERE `rut_usuario`='08803052-4';"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch
        '    End Try
        '    Try
        '        SC.Connection = conexion
        '        SC.CommandText = "UPDATE `usuarios` SET `clave`='555876' WHERE `rut_usuario`='8803052-4';"
        '        DA.SelectCommand = SC
        '        DA.Fill(DT)
        '    Catch
        '    End Try
        'End If

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `usuarios` SET `clave`='0428' WHERE `rut_usuario`='16972940-9';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `clientes` ADD COLUMN `cod_auto` INT(11) NOT NULL AUTO_INCREMENT  AFTER `activo` , CHANGE COLUMN `cod_cliente` `cod_cliente` INT(11) NULL  , DROP PRIMARY KEY , ADD PRIMARY KEY (`cod_auto`) ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `clientes` ADD COLUMN `pagare` INT(11) NULL  AFTER `activo` ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `clientes` SET `pagare`='0' WHERE `cod_auto` = '1';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "UPDATE `clientes` SET `pagare`='0' WHERE `cod_auto` <> '1';"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try

        'Try
        '    SC.Connection = conexion
        '    SC.CommandText = "ALTER TABLE `clientes` CHANGE COLUMN `pagare` `pagare` INT(11) NULL DEFAULT 0  ;"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        'Catch
        'End Try
    End Sub

    Sub valores()

        Using cn As New MySqlConnection(conexion_actual)
            cn.Open()

            Dim query As String = "select * from valores"
            Dim cmd As New MySqlCommand(query, cn)

            'cmd.Parameters.AddWithValue("@codigo", CInt(txtId.Text))

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                ingreso_rapido = CStr(reader("ingreso_rapido"))
                valor_iva = CStr(reader("iva"))
                valor_factor = CStr(reader("factor"))
                inicio_sugerir_codigo = CStr(reader("inicio_sugerir_codigo"))
                valor_descuento_maximo = CStr(reader("valor_descuento_maximo"))
                valor_descuento_ventas = CStr(reader("valor_descuento_ventas"))
                valor_descuento_maximo_columna = CStr(reader("valor_descuento_maximo_columna"))
                calculo_interes = CStr(reader("calculo_de_interes"))
                vuelto = CStr(reader("vuelto"))
                inicio_codigo_cliente = CStr(reader("inicio_codigo_cliente"))
                venta_sin_stock = CStr(reader("venta_sin_stock"))
                validez_cotizacion = CStr(reader("validez_cotizacion"))
            End If

        End Using


        'conexion.Close()
        'DS2.Tables.Clear()
        'DT2.Rows.Clear()
        'DT2.Columns.Clear()
        'DS2.Clear()
        'conexion.Open()

        'SC2.Connection = conexion
        'SC2.CommandText = "select * from valores"
        'DA2.SelectCommand = SC2
        'DA2.Fill(DT2)
        'DS2.Tables.Add(DT2)

        'If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
        '    ingreso_rapido = DS2.Tables(DT2.TableName).Rows(0).Item("ingreso_rapido")
        '    valor_iva = DS2.Tables(DT2.TableName).Rows(0).Item("iva")
        '    valor_factor = DS2.Tables(DT2.TableName).Rows(0).Item("factor")
        '    inicio_sugerir_codigo = DS2.Tables(DT2.TableName).Rows(0).Item("inicio_sugerir_codigo")
        '    valor_descuento_maximo = DS2.Tables(DT2.TableName).Rows(0).Item("valor_descuento_maximo")

        '    valor_descuento_ventas = DS2.Tables(DT2.TableName).Rows(0).Item("valor_descuento_ventas")

        '    valor_descuento_maximo_columna = DS2.Tables(DT2.TableName).Rows(0).Item("valor_descuento_maximo_columna")
        '    calculo_interes = DS2.Tables(DT2.TableName).Rows(0).Item("calculo_de_interes")
        '    vuelto = DS2.Tables(DT2.TableName).Rows(0).Item("vuelto")
        '    inicio_codigo_cliente = DS2.Tables(DT2.TableName).Rows(0).Item("inicio_codigo_cliente")
        '    venta_sin_stock = DS2.Tables(DT2.TableName).Rows(0).Item("venta_sin_stock")
        '    validez_cotizacion = DS2.Tables(DT2.TableName).Rows(0).Item("validez_cotizacion")
        'End If

        'If vuelto = "SI" Then
        '    Form_venta.txt_efectivo.Visible = True
        '    Form_venta.txt_vuelto.Visible = True
        '    Form_venta.lbl_1.Text = "EFECTIVO:"
        '    Form_venta.lbl_2.Text = "VUELTO:"
        '    'Form_venta.lbl_1.Location = New Point(8, 30)
        '    'Form_venta.lbl_2.Location = New Point(8, 61)
        '    'Form_venta.lbl_3.Location = New Point(8, 93)
        '    Form_venta.txt_efectivo.Location = New Point(86, 28)
        '    Form_venta.txt_vuelto.Location = New Point(86, 59)
        '    Form_venta.txt_neto_millar.Location = New Point(86, 28)
        '    Form_venta.txt_iva_millar.Location = New Point(86, 59)
        '    Form_venta.txt_total_millar.Location = New Point(86, 90)
        'End If

        'If vuelto = "NO" Then
        '    Form_venta.txt_efectivo.Visible = False
        '    Form_venta.txt_vuelto.Visible = False
        '    Form_venta.lbl_1.Text = "NETO:"
        '    Form_venta.lbl_2.Text = "IVA:"
        '    'Form_venta.lbl_1.Location = New Point(0, 30)
        '    'Form_venta.lbl_2.Location = New Point(0, 61)
        '    'Form_venta.lbl_3.Location = New Point(0, 93)
        '    Form_venta.txt_neto_millar.Location = New Point(77, 28)
        '    Form_venta.txt_iva_millar.Location = New Point(77, 59)
        '    Form_venta.txt_total_millar.Location = New Point(77, 90)
        'End If
        conexion.Close()
    End Sub

    Sub ajustar()
        Me.Enabled = False
        Dim margen_lateral_logo As String
        Dim margen_superior_logo As String
        Dim tamaño_menu As String

        margen_lateral_logo = (Me.Width - PictureBox_logo.Width) / 2
        margen_superior_logo = (Me.Height - PictureBox_logo.Height) / 2
        PictureBox_logo.Location = New Point(margen_lateral_logo - 3, margen_superior_logo)

        lbl_soporte_remoto.Location = New Point(Me.Width - lbl_soporte_remoto.Width - 20, 130)
        lbl_uc.Location = New Point(Me.Width - lbl_uc.Width - 20, 150)
        lbl_usuario_conectado.Location = New Point(Me.Width - lbl_usuario_conectado.Width - 20, 170)


        lbl_hora.Width = lbl_fecha.Width
        'lbl_fecha.Location = New Point(30, 140)

        lbl_hora.Location = New Point(20, 120)
        lbl_fecha.Location = New Point(20, 170)

        Dim tamaño As Rectangle = My.Computer.Screen.Bounds

        MenuStrip1.Width = tamaño.Width

        tamaño_menu = tamaño.Width
        tamaño_menu = Me.Width / 6
        tamaño_menu = tamaño_menu - 1

        MenuStrip1.Location = New Point(0, 35)

        MENU_ADQUISICIONES_ToolStripMenuItem.Width = Int(tamaño_menu)
        MENU_ADMINISTRACION_ToolStripMenuItem.Width = Int(tamaño_menu)
        MENU_BODEGA_ToolStripMenuItem.Width = Int(tamaño_menu)
        MENU_CONFIGURACION_ToolStripMenuItem.Width = Int(tamaño_menu)
        MENU_MANTENEDORES_ToolStripMenuItem.Width = Int(tamaño_menu)
        MENU_VENTAS_ToolStripMenuItem.Width = Int(tamaño_menu) - 2

        MenuStrip1.Height = 76


        'Panel_pie.Width = Me.Width
        Panel_pie.Height = 75

        'Panel_pie.Location = New Point((Me.Width - Panel_pie.Width) / 2, Me.Height - Panel_pie.Height)
        'lbl_contacto.Location = New Point((Panel_pie.Width - lbl_contacto.Width) / 2, Panel_pie.Height / 2 - 10)
        'lbl_pie.Location = New Point((Panel_pie.Width - lbl_pie.Width) / 2, Panel_pie.Height / 2 - 30)
        Me.Enabled = True
    End Sub

    Sub descargar_imagenes()
        'Try
        '    Dim Imagen_menu As Byte()
        '    conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    conexion.Open()

        '    SC.Connection = conexion
        '    SC.CommandText = "select * from imagenes_de_sistema where cod_auto=1"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    DS.Tables.Add(DT)

        '    If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '        lector = SC.ExecuteReader
        '        While lector.Read
        '            'Imagen_menu = lector("logo_empresa_menu")
        '            Imagen_formulario = lector("logo_empresa_formularios")
        '            icono_1 = lector("icono_menu_1_de_menu_principal")
        '            icono_2 = lector("icono_menu_2_de_menu_principal")
        '            icono_3 = lector("icono_menu_3_de_menu_principal")
        '            icono_4 = lector("icono_menu_4_de_menu_principal")
        '            icono_5 = lector("icono_menu_5_de_menu_principal")
        '            icono_6 = lector("icono_menu_6_de_menu_principal")
        '            Imagen_ticket = lector("logo_empresa_reportes")
        '            Imagen_ticket = lector("logo_empresa_ticket")
        '            Me.PictureBox_logo.Image = Bytes_Imagen(Imagen_menu)

        '        End While
        '    End If
        '    conexion.Close()


        'Catch ex As Exception
        '    'MessageBox.Show(ex.Message)
        'End Try






        'Try
        '    If Directory.Exists("C:\Temp\" & mirutempresa) = False Then ' si no existe la carpeta se crea
        '        Directory.CreateDirectory("C:\Temp\" & mirutempresa)
        '    End If
        'Catch
        'End Try

        'Try
        '    Dim fileCreatedDate As DateTime = File.GetCreationTime("C:\Temp\" & mirutempresa & "\Logo-menu.png")
        '    Dim mifechacreacion As String
        '    Dim mifechahoy As String

        '    Dim mifecha As Date
        '    mifecha = fileCreatedDate
        '    mifechacreacion = mifecha.ToString("yyy-MM-dd")

        '    Dim mifecha3 As Date
        '    mifecha3 = dtp_fecha.Text
        '    mifechahoy = mifecha3.ToString("yyy-MM-dd")

        '    If mifechacreacion = mifechahoy Then
        '        Exit Sub
        '    End If
        'Catch
        'End Try

        'Dim XDia As String
        'XDia = Format(Now, "dddd")
        'If XDia = "lunes" Then
        '    Try
        '        Dim Client As New WebClient
        '        Client.DownloadFile("https://www.clickoffice.cl/imagenes-clientes/" & mirutempresa & "/Logo-menu.png", "C:\Temp\" & mirutempresa & "\Logo-menu.png")
        '        Client.DownloadFile("https://www.clickoffice.cl/imagenes-clientes/" & mirutempresa & "/Logo-impresion.jpg", "C:\Temp\" & mirutempresa & "\Logo-impresion.jpg")
        '        Client.DownloadFile("https://www.clickoffice.cl/imagenes-clientes/" & mirutempresa & "/Logo-formulario.png", "C:\Temp\" & mirutempresa & "\Logo-formulario.png")
        '        Client.DownloadFile("https://www.clickoffice.cl/imagenes-clientes/" & mirutempresa & "/Icono-adquisiciones.png", "C:\Temp\" & mirutempresa & "\Icono-adquisiciones.png")
        '        Client.DownloadFile("https://www.clickoffice.cl/imagenes-clientes/" & mirutempresa & "/Icono-administracion.png", "C:\Temp\" & mirutempresa & "\Icono-administracion.png")
        '        Client.DownloadFile("https://www.clickoffice.cl/imagenes-clientes/" & mirutempresa & "/Icono-bodega.png", "C:\Temp\" & mirutempresa & "\Icono-bodega.png")
        '        Client.DownloadFile("https://www.clickoffice.cl/imagenes-clientes/" & mirutempresa & "/Icono-configuracion.png", "C:\Temp\" & mirutempresa & "\Icono-configuracion.png")
        '        Client.DownloadFile("https://www.clickoffice.cl/imagenes-clientes/" & mirutempresa & "/Icono-mantenedores.png", "C:\Temp\" & mirutempresa & "\Icono-mantenedores.png")
        '        Client.DownloadFile("https://www.clickoffice.cl/imagenes-clientes/" & mirutempresa & "/Icono-ventas.png", "C:\Temp\" & mirutempresa & "\Icono-ventas.png")
        '        Client.Dispose()
        '    Catch
        '        ' MsgBox("el error es" & ex.Message)
        '    End Try
        'End If
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

    Private Sub ConsultaBloqueaMenus()

        Try
            For Each vLocMnuOpciones In Me.MenuStrip1.Items
                If vLocMnuOpciones.DropDownItems.Count > 0 Then
                    ' vLocMnuOpciones.Enabled = False
                    vLocMnuOpciones.Enabled = False
                    BloquearMenus(vLocMnuOpciones.DropDownItems)
                End If
            Next
            'vGlovalor = vGlovalor.TrimEnd(";")
            'MsgBox(vGlovalor)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub


    Private Sub ConsultaMenus()

        'If tipo_usuario = "USUARIO DEL SISTEMA" Then
        '    Dim vLocMnuOpciones As ToolStripMenuItem
        '    Try
        '        For Each vLocMnuOpciones In Me.MenuStrip1.Items
        '            If vLocMnuOpciones.DropDownItems.Count > 0 Then
        '                vLocMnuOpciones.Enabled = False
        '            End If
        '        Next
        '        'vGlovalor = vGlovalor.TrimEnd(";")
        '        'MsgBox(vGlovalor)
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
        'End If

        'If tipo_usuario = "USUARIO DEL SISTEMA" Then
        '    Dim vLocMnuOpciones As ToolStripMenuItem
        '    Try
        '        For Each vLocMnuOpciones In Me.MenuStrip1.Items
        '            If vLocMnuOpciones.DropDownItems.Count > 0 Then

        '                conexion.Close()
        '                DS.Tables.Clear()
        '                DT.Rows.Clear()
        '                DT.Columns.Clear()
        '                DS.Clear()
        '                SC.Connection = conexion
        '                SC.CommandText = "select * from registro_de_permisos where rut_usuario ='" & (miusuario) & "'"
        '                DA.SelectCommand = SC
        '                DA.Fill(DT)
        '                DS.Tables.Add(DT)
        '                If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '                    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
        '                        habilitar_permiso = DS.Tables(DT.TableName).Rows(i).Item("permiso")

        '                        If habilitar_permiso = vLocMnuOpciones.Name Then
        '                            vLocMnuOpciones.Enabled = True
        '                        End If

        '                    Next
        '                End If
        '            End If
        '        Next
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
        'End If

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from registro_de_permisos where rut_usuario ='" & (miusuario) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                habilitar_permiso = DS.Tables(DT.TableName).Rows(i).Item("permiso")

                'If habilitar_permiso = "FACTURACION_MANUAL_ToolStripMenuItem" Then
                '    MsgBox("")
                'End If

                Dim vLocMnuOpciones As ToolStripMenuItem
                Try
                    For Each vLocMnuOpciones In Me.MenuStrip1.Items
                        If vLocMnuOpciones.DropDownItems.Count > 0 Then
                            ' vLocMnuOpciones.Enabled = False

                            If habilitar_permiso = "COMPRAS_ToolStripMenuItem" Then
                                permiso_compras = "SI"
                            End If

                            If habilitar_permiso = "VENTAS_ToolStripMenuItem" Then
                                permiso_ventas = "SI"
                            End If

                            If habilitar_permiso = vLocMnuOpciones.Name Then
                                vLocMnuOpciones.Enabled = True
                                Exit For
                            End If

                            RecorrerMenus(vLocMnuOpciones.DropDownItems)
                        End If
                    Next
                    'vGlovalor = vGlovalor.TrimEnd(";")
                    'MsgBox(vGlovalor)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try


            Next
        End If






    End Sub

    Private Sub BloquearMenus(ByVal vLocOneItem As ToolStripItemCollection)

        Dim vLocElItem As ToolStripMenuItem

        Try
            For Each vLocOtroItem As ToolStripItem In vLocOneItem
                If TypeOf vLocOtroItem Is ToolStripMenuItem Then
                    'vGlovalor &= vLocOtroItem.Text & ";"

                    If vLocOtroItem.IsOnDropDown Then
                        vLocElItem = vLocOtroItem

                        vLocElItem.Visible = False

                        If vLocElItem.DropDownItems.Count > 0 Then
                            BloquearMenus(vLocElItem.DropDownItems)
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub RecorrerMenus(ByVal vLocOneItem As ToolStripItemCollection)

        Dim vLocElItem As ToolStripMenuItem

        Try
            For Each vLocOtroItem As ToolStripItem In vLocOneItem
                If TypeOf vLocOtroItem Is ToolStripMenuItem Then

                    If vLocOtroItem.IsOnDropDown Then
                        vLocElItem = vLocOtroItem

                        If habilitar_permiso = vLocElItem.Name Then
                            vLocElItem.Visible = True
                            Exit For
                        End If

                        If vLocElItem.DropDownItems.Count > 0 Then
                            RecorrerMenus(vLocElItem.DropDownItems)
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CORREGIRDOCUMENTOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CORREGIR_DOCUMENTOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_anular_documentos.Show()
        Form_anular_documentos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub STOCKMINIMOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCK_MINIMO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_stock.Show()
        Form_stock.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub COMPRASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMPRAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_Compra.Show()
        Form_Compra.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub ETIQUETASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ETIQUETAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_crear_etiquetas.Show()
        Form_crear_etiquetas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PERMISOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PERMISOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_permisos_2.Show()
        Form_permisos_2.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub MIEMPRESAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EMPRESA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_empresa.Show()
        Form_registro_empresa.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub NUMERACIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUMERACION_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_numeros_impresion.Show()
        Form_numeros_impresion.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub IMPRESORASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMPRESORAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_impresoras.Show()
        Form_impresoras.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub RESPALDOBDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RESPALDO_BD_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_respaldo.Show()
        Form_respaldo.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub AGREGARCLIENTESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLIENTES_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        form_registro_clientes.Show()
        form_registro_clientes.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub AGREGARUSUARIOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USUARIOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        form_registro_usuarios.Show()
        form_registro_usuarios.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub AGREGARPROVEEDORESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROVEEDORES_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        form_registro_proveedores.Show()
        form_registro_proveedores.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub AGREGARPRODUCTOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCTOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        form_registro_productos.Show()
        form_registro_productos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub


    Private Sub AGREGARFAMILIAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FAMILIAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_familia.Show()
        Form_registro_familia.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub AGREGARSUBFAMILIAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUBFAMILIAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_subfamilia.Show()
        Form_registro_subfamilia.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VENTASToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Form_venta.WindowState = FormWindowState.Minimized Then
            Form_venta.WindowState = FormWindowState.Normal
            Me.WindowState = FormWindowState.Minimized
        Else
            Form_venta.Show()
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub COMISIONESToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form_comisiones.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub AGREGARCUENTACORRIENTEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CUENTAS_CORRIENTES_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_cuentas_corrientes.Show()
        Form_registro_cuentas_corrientes.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub REALIZARPEDIDOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REALIZAR_PEDIDOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_pedidos.Show()
        Form_pedidos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub REVISIONDEPEDIDOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REVISION_DE_PEDIDOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_pedidos_revision.Show()
        Form_pedidos_revision.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub MISPEDIDOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MIS_PEDIDOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_mis_pedidos.Show()
        Form_mis_pedidos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CONFIRMACIONDELLEGADAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONFIRMACION_DE_LLEGADA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_pedido_confirmacion_de_llegada.Show()
        Form_pedido_confirmacion_de_llegada.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub form_Menu_admin_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        'If mirutempresa = "76820004-1" Then
        '    Me.BackColor = SystemColors.Control
        '    Exit Sub
        'End If

        'If mirutempresa = "16621207-3" Then
        '    Me.BackColor = Color.FromArgb(255, 255, 255)
        '    Exit Sub
        'End If

        'If mirutempresa = "87686300-6" Then
        '    Me.BackColor = SystemColors.Control
        '    Exit Sub
        'End If

        'If mirutempresa = "76313245-5" Then
        '    Me.BackColor = Color.FromArgb(214, 214, 214)
        '    Exit Sub
        'End If

        'If mirutempresa = "16972940-9" Then
        '    Me.BackColor = Color.FromArgb(141, 193, 222)
        '    Exit Sub
        'End If
        ''If mirutempresa = "16972940-9" Then
        ''    Me.BackColor = Color.White
        ''    Exit Sub
        ''End If
        'If mirutempresa = "81921000-4" Then
        '    Me.BackColor = Color.White
        '    Exit Sub
        'End If
        'If mirutempresa = "76536823-5" Then
        '    Me.BackColor = Color.White
        '    Exit Sub
        'End If
        'Me.BackColor = SystemColors.Control
    End Sub

    Private Sub form_Menu_admin_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        ajustar()
        If Me.WindowState = FormWindowState.Minimized Then
            inactiveTime = True
        End If
        If Me.WindowState <> FormWindowState.Minimized Then
            inactiveTime = False
        End If
    End Sub

    Private Sub FACTURASVENCIDASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REGISTRO_DE_FACTURAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_de_facturas.Show()
        Form_registro_de_facturas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VALORESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPCIONES_GENERALES_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_valores.Show()
        Form_registro_valores.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VENTASToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VENTAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_venta.Show()
        Form_venta.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub ENVIARCOTIZACIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENVIAR_COTIZACION_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_enviar_correo_cotizacion.Show()
        Form_enviar_correo_cotizacion.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub AGREGARMARCASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MARCAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_marcas.Show()
        Form_registro_marcas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub Timer_hora_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_hora.Tick

        If segundo < actualizar_reloj Then

            Dim valor As Integer
            valor = segundo
            segundo = String.Format("{0:00}", valor)

            If lbl_hora.Text.Length > 6 Then
                lbl_hora.Text = lbl_hora.Text.Substring(0, 6)
            End If
            lbl_hora.Text = lbl_hora.Text & segundo

            segundo = segundo + 1
        Else
            fecha_hora_servidor()
        End If
    End Sub

    Private Structure LASTINPUTINFO
        Public cbSize As UInteger
        Public dwTime As UInteger
    End Structure

    <DllImport("User32.dll")>
    Private Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    End Function

    Public Function GetInactiveTime() As Nullable(Of TimeSpan)
        Dim info As LASTINPUTINFO = New LASTINPUTINFO
        info.cbSize = CUInt(Marshal.SizeOf(info))
        If (GetLastInputInfo(info)) Then
            Return TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime)
        Else
            Return Nothing
        End If
    End Function

    Private Sub BUSCARFACTURASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUSCAR_FACTURAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_buscar_facturas.Show()
        Form_buscar_facturas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub REPORTELIBRODECOMPRASToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REPORTE_LIBRO_DE_COMPRAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_libro_de_compras_impresion.Show()
        Form_libro_de_compras_impresion.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub LIBRODECOMPRASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LIBRO_DE_COMPRAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_libro_de_compras.Show()
        Form_libro_de_compras.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PROVEEDORESMASPEDIDOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROVEEDORES_MAS_PEDIDOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_proveedores_mas_pedidos.Show()
        Form_registro_proveedores_mas_pedidos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub LIBRODEVENTASToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LIBRO_DE_VENTAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_libro_de_ventas.Show()
        Form_libro_de_ventas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CARTOLAKARDEXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CARTOLA_KARDEX_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        'Form_cartola_kardex.Show()
        'Form_cartola_kardex.WindowState = FormWindowState.Normal
        Form_cartola_kardex_2.Show()
        Form_cartola_kardex_2.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub COMISIONVENDEDORESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMISION_VENDEDORES_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_comisiones.Show()
        Form_comisiones.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub BUSCARTOTALESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUSCAR_TOTALES_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_visor_totales.Show()
        Form_visor_totales.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CORREGIRNUMEROSDEIMPRESIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CORREGIR_NUMEROS_DE_IMPRESION_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_CORREGIR_numero_impresion.Show()
        Form_CORREGIR_numero_impresion.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub INGRESOMANUALDEVENTASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INGRESO_MANUAL_DE_VENTAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_venta_manual.Show()
        Form_venta_manual.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub NOTASDECREDITOToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NOTAS_DE_CREDITO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_nota_credito.Show()
        Form_nota_credito.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CODIGODEBARRAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CODIGOS_DE_BARRA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_codigos_de_barra.Show()
        Form_registro_codigos_de_barra.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub INGRESODECREDITOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_ingresar_creditos.Show()
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub AGREGARABONOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_agregar_abonos.Show()
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub Timer_inactividad_menu_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_inactividad_menu.Tick
        Dim forms As FormCollection = Application.OpenForms
        Dim inactiveTime = GetInactiveTime()
        If (inactiveTime.Value.TotalSeconds > tiempo_espera) Then
            If forms.Count = 1 Then
                mostrar_cierre_sistema()
                Me.Close()
            End If
        End If
        LiberarMemoria()
    End Sub

    Private Sub TRASPASODESTOCKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TRASPASO_DE_STOCK_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_traspaso_stock.Show()
        Form_traspaso_stock.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub IMPUTARNOTASDECREDITOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_imputar_nota_de_credito.Show()
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub IMPUTARABONOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_imputar_abonos.Show()
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub RUTAPARAARCHIVOSPLANOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RUTA_PARA_ARCHIVOS_PLANOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_ruta_documentos_electronicos.Show()
        Form_registro_ruta_documentos_electronicos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PRUEBASToolStripMenuItem_Click_4(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_pruebas.Show()
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub COMISIONPORSERVICIOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMISION_POR_SERVICIOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_comision_servicios.Show()
        Form_comision_servicios.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CALCULADORAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CALCULADORA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim Proceso As New Process()
        Proceso.StartInfo.FileName = "calc.exe"
        Proceso.StartInfo.Arguments = ""
        Proceso.Start()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub TRASPASOASUCURSALToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TRASPASO_A_SUCURSAL_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_envio_productos_sucursal.Show()
        Form_envio_productos_sucursal.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub COLORDESISTEMAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_color_sistema.Show()
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DETALLEVENTASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DETALLE_DE_VENTAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_detalle_ventas.Show()
        Form_detalle_ventas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub INVENTARIOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INVENTARIO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_inventario.Show()
        Form_inventario.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub ESTADODECUENTAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ESTADO_DE_CUENTA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_estado_de_cuenta.Show()
        Form_estado_de_cuenta.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub ESTADODECUENTAPORToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ESTADO_DE_CUENTA_POR_RANGO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_estado_de_cuenta_por_letras.Show()
        Form_estado_de_cuenta_por_letras.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub AGREGARABONOSToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AGREGAR_ABONOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_agregar_abonos.Show()
        Form_agregar_abonos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub ABONOSSINIMPUTARToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AGREGAR_ABONOS_SIN_IMPUTAR_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_agregar_abonos_sin_imputar.Show()
        Form_agregar_abonos_sin_imputar.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub IMPUTARABONOSToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMPUTAR_ABONOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_imputar_abonos.Show()
        Form_imputar_abonos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub IMPUTARNOTASDECREDITOToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMPUTAR_NOTAS_DE_CREDITO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_imputar_nota_de_credito.Show()
        Form_imputar_nota_de_credito.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub COTIZACIONFORMALToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COTIZACION_FORMAL_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_cotizacion_formal.Show()
        Form_cotizacion_formal.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CAMBIODEPRODUCTOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CAMBIO_DE_PRODUCTOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_cambio_de_producto.Show()
        Form_cambio_de_producto.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub MISCOTIZACIONESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MIS_DOCUMENTOS_EMITIDOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_mis_documentos.Show()
        Form_mis_documentos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub RUTAPARAIMAGENESDESISTEMAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_ruta_imagenes_sistema.Show()
        Form_registro_ruta_imagenes_sistema.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub BITACORADECAMBIOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BITACORA_DE_CAMBIOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_bitacora_de_cambios.Show()
        Form_bitacora_de_cambios.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DETALLEVENTASPORDOCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DETALLE_DE_VENTAS_POR_DOCUMENTO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_detalle_ventas_documentos.Show()
        Form_detalle_ventas_documentos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DEUDORESToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEUDORES_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_deudores.Show()
        Form_deudores.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub NOTASDEDEBITOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NOTAS_DE_DEBITO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_nota_de_debito.Show()
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PruebasToolStripMenuItem_Click_5(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_pruebas.Show()
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PruebasToolStripMenuItem_Click_6(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_pruebas.Show()
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PruebaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_pruebas.Show()
        Form_pruebas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub lbl_soporte_remoto_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        lbl_soporte_remoto.ForeColor = Color.Black
    End Sub

    Private Sub lbl_soporte_remoto_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        lbl_soporte_remoto.ForeColor = Color.Yellow
    End Sub

    Private Sub REALIZARRESERVAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REALIZAR_RESERVA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_reservas.Show()
        Form_reservas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub MISRESERVASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MIS_RESERVAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_mis_reservas.Show()
        Form_mis_reservas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub lbl_soporte_remoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_soporte_remoto.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Try
            Try
                My.Computer.Network.DownloadFile("https://www.clickoffice.cl/AnyDesk.exe", "My.Computer.FileSystem.SpecialDirectories.Desktop\AnyDesk.exe")
                Process.Start("My.Computer.FileSystem.SpecialDirectories.Desktop\AnyDesk.exe")
            Catch
                Process.Start("My.Computer.FileSystem.SpecialDirectories.Desktop\AnyDesk.exe")
            End Try

        Catch
            Process.Start("https://anydesk.es/download?os=win")
        End Try

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub LISTADODEABONOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LISTADO_DE_ABONOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_abonos_listado.Show()
        Form_abonos_listado.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CONDICIONEVENTAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONDICION_DE_VENTA_ToolStripMenuItem.Click
        'lbl_mensaje.Visible = True
        'Me.Enabled = False
        'Form_registro_condicion_de_venta.Show()
        'Form_registro_condicion_de_venta.WindowState = FormWindowState.Normal
        'Me.WindowState = FormWindowState.Minimized
        'lbl_mensaje.Visible = False
        'Me.Enabled = True
    End Sub

    Private Sub PRUEBASToolStripMenuItem_Click_7(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_pruebas.Show()
        Form_pruebas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CONSULTASSQLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONSULTAS_SQL_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_consultas.Show()
        Form_consultas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VENTASDELDIAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VENTAS_DEL_DIA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_estadisticas_ventas_del_dia.Show()
        Form_estadisticas_ventas_del_dia.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VENTASDELASEMANAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VENTAS_DE_LA_SEMANA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_estadisticas_ventas_de_la_semana.Show()
        Form_estadisticas_ventas_de_la_semana.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VENTASSEGUNVENDEDORToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VENTAS_SEGUN_VENDEDOR_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_estadisticas_ventas_segun_vendedor.Show()
        Form_estadisticas_ventas_segun_vendedor.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CLIENTESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEUDA_CLIENTES_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_deudores.Show()
        Form_deudores.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PROVEEDORESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEUDA_PROVEEDORES_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_deuda_proveedor.Show()
        Form_deuda_proveedor.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub TICKETDEVENTASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TICKET_DE_VENTAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        If mirutempresa = "87686300-6" Then
            Form_ticket_ventas_2.Show()
            Form_ticket_ventas_2.WindowState = FormWindowState.Normal
        Else
            Form_ticket_ventas.Show()
            Form_ticket_ventas.WindowState = FormWindowState.Normal
        End If
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VACIARToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_vaciar.Show()
        Form_vaciar.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DBFToolStripMenuItem_Click_4(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_archivo_dbf.Show()
        Form_archivo_dbf.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PRUEBASToolStripMenuItem_Click_9(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_pruebas.Show()
        Form_pruebas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CARGARARCHIVOEXCELToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CARGAR_ARCHIVO_EXCEL_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_excel.Show()
        Form_excel.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DETALLEDECOMPRASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DETALLE_DE_COMPRAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_detalle_compras.Show()
        Form_detalle_compras.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub SUBFAMILIA2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUBFAMILIAS_2_ToolStripMenuItem.Click

        If mirutempresa = "87686300-6" Then
            lbl_mensaje.Visible = True
            Me.Enabled = False
            Form_registro_subfamilia_2_arana.Show()
            Form_registro_subfamilia_2_arana.WindowState = FormWindowState.Normal
            Me.WindowState = FormWindowState.Minimized
            lbl_mensaje.Visible = False
            Me.Enabled = True
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_subfamilia_2.Show()
        Form_registro_subfamilia_2.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub GUIASDETRASLADOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GUIAS_DE_TRASLADO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_guias_traslado.Show()
        Form_guias_traslado.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DETALLEDEABONOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DETALLE_DE_ABONOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_abonos_detalle.Show()
        Form_abonos_detalle.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub REGISTRODEAUTORIZACIONESDEVENTASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AUTORIZACIONES_DE_VENTAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_de_autorizaciones.Show()
        Form_registro_de_autorizaciones.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub LISTADODEDOCUMENTOSNULOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LISTADO_DE_DOCUMENTOS_NULOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_listado_documentos_nulos.Show()
        Form_listado_documentos_nulos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CUADRATURADECAJAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CUADRATURA_DE_CAJA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_caja_diaria.Show()
        Form_caja_diaria.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub LISTADODEABONOSToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LISTADO_DE_ABONOS_PARA_CAJA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_abonos_listado.Show()
        Form_abonos_listado.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DETALLEDEVENTASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_detalle_ventas.Show()
        Form_detalle_ventas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub REGISTRODECHEQUESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REGISTRO_DE_CHEQUES_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_de_cheques.Show()
        Form_registro_de_cheques.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PAGOCOMBINADOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_pago_combinado.Show()
        Form_pago_combinado.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub ACTUALIZARToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_actualizar_stock.Show()
        Form_actualizar_stock.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub LISTADODELETRASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LISTADO_DE_LETRAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_listado_letras.Show()
        Form_listado_letras.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub INGRESARLETRASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_ingresar_creditos.Show()
        Form_ingresar_creditos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        If calculo_interes = "NO" Then
            Form_ingresar_creditos.Show()
            Form_ingresar_creditos.WindowState = FormWindowState.Normal
            Me.WindowState = FormWindowState.Minimized
        End If
        If calculo_interes = "SI" Then
            Form_CORREGIR.Show()
            Form_CORREGIR.WindowState = FormWindowState.Normal
            Me.WindowState = FormWindowState.Minimized
        End If
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DETALLEVENTACONTADOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_detalle_pagos.Show()
        Form_detalle_pagos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CORREGIRCODIGOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_CORREGIR_codigo.Show()
        Form_CORREGIR_codigo.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VENTASASISTIDASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VENTAS_ASISTIDAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_ventas_asistidas.Show()
        Form_ventas_asistidas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DETALLEDECREDITOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DETALLE_DE_CREDITOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_detalle_creditos.Show()
        Form_detalle_creditos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub ASIGNARFAMILIASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ASIGNAR_FAMILIAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_asignar_familias.Show()
        Form_asignar_familias.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DETALLEDECOMBINADOYPIEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_detalle_ventas_pie.Show()
        Form_detalle_ventas_pie.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DETALLEDEVENTASCONPIEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DETALLE_DE_VENTAS_CON_PIE_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_detalle_ventas_pie.Show()
        Form_detalle_ventas_pie.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DETALLEDEVENTASPAGOCOMBINADOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DETALLE_DE_VENTAS_PAGO_COMBINADO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_detalle_ventas_pago_combinado.Show()
        Form_detalle_ventas_pago_combinado.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub lbl_soporte_remoto_MouseLeave1(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_soporte_remoto.MouseLeave
        'DESPUES DEL FOCO

        'CARNES DIAZ
        If mirutempresa = "76474168-4" Then
            lbl_soporte_remoto.ForeColor = Color.FromArgb(0, 0, 0)
            Exit Sub
        End If

        If mirutempresa = "76312567-K" Then
            lbl_soporte_remoto.ForeColor = Color.FromArgb(25, 102, 110)
            Exit Sub
        End If

        If mirutempresa = "76366176-8" Then
            lbl_soporte_remoto.ForeColor = Color.FromArgb(192, 0, 0)
            Exit Sub
        End If

        If mirutempresa = "76820004-1" Then
            lbl_soporte_remoto.ForeColor = Color.FromArgb(10, 33, 61)
            Exit Sub
        End If

        If mirutempresa = "16621207-3" Then
            lbl_soporte_remoto.ForeColor = Color.FromArgb(80, 76, 172)
            Exit Sub
        End If
        If mirutempresa = "87686300-6" Then
            lbl_soporte_remoto.ForeColor = Color.FromArgb(24, 49, 106)
            Exit Sub
        End If
        If mirutempresa = "16972940-9" Then
            lbl_soporte_remoto.ForeColor = Color.FromArgb(48, 100, 137)
            Exit Sub
        End If

        If mirutempresa = "12413179-0" Then
            lbl_soporte_remoto.ForeColor = Color.Black
        End If

        If mirutempresa = "81921000-4" Then
            lbl_soporte_remoto.ForeColor = Color.FromArgb(217, 0, 0)
            Exit Sub
        End If

        If mirutempresa = "76536823-5" Then
            lbl_soporte_remoto.ForeColor = Color.FromArgb(108, 193, 39)
            Exit Sub
        End If

        If mirutempresa = "13501829-5" Then
            lbl_soporte_remoto.ForeColor = Color.FromArgb(217, 0, 0)
            Exit Sub
        End If
        If mirutempresa = "76313245-5" Then
            lbl_soporte_remoto.ForeColor = Color.FromArgb(0, 0, 0)
            Exit Sub
        End If
        lbl_soporte_remoto.ForeColor = Color.Black
    End Sub

    Private Sub lbl_soporte_remoto_MouseMove1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbl_soporte_remoto.MouseMove
        'EN EL FOCO

        'CARNES DIAZ
        If mirutempresa = "76474168-4" Then
            lbl_soporte_remoto.ForeColor = Color.Red
            Exit Sub
        End If

        If mirutempresa = "76312567-K" Then
            lbl_soporte_remoto.ForeColor = Color.FromArgb(221, 174, 206)
            Exit Sub
        End If

        If mirutempresa = "16621207-3" Then
            lbl_soporte_remoto.ForeColor = Color.FromArgb(190, 64, 166)
            Exit Sub
        End If

        If mirutempresa = "87686300-6" Then
            lbl_soporte_remoto.ForeColor = Color.FromArgb(242, 182, 49)
            Exit Sub
        End If

        If mirutempresa = "12413179-0" Then
            lbl_soporte_remoto.ForeColor = Color.FromArgb(211, 33, 33)
            Exit Sub
        End If


        If mirutempresa = "16972940-9" Then
            lbl_soporte_remoto.ForeColor = Color.FromArgb(0, 165, 233)
            Exit Sub
        End If

        If mirutempresa = "76313245-5" Then
            lbl_soporte_remoto.ForeColor = Color.FromArgb(255, 255, 255)
            Exit Sub
        End If


        lbl_soporte_remoto.ForeColor = Color.Yellow
    End Sub

    Private Sub ACTUALIZARSTOCKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACTUALIZAR_STOCK_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_actualizar_stock.Show()
        Form_actualizar_stock.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub ADMVALESDECAMBIOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUSCADOR_DE_PRODUCTOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_buscador_productos.Show()
        Form_buscador_productos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub INGRESODECREDITOSToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INGRESO_DE_CREDITOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        If calculo_interes = "NO" Then
            Form_ingresar_creditos.Show()
            Form_ingresar_creditos.WindowState = FormWindowState.Normal
            Me.WindowState = FormWindowState.Minimized
        End If
        If calculo_interes = "SI" Then
            Form_CORREGIR.Show()
            Form_CORREGIR.WindowState = FormWindowState.Normal
            Me.WindowState = FormWindowState.Minimized
        End If
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub TRASPASODECREDITOSAHISTORICOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TRASPASO_DE_CREDITOS_A_HISTORICO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_traspaso_historico_credito.Show()
        Form_traspaso_historico_credito.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub TRASPASARSTOCKFISICOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TRASPASAR_STOCK_FISICO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_stock_fisico.Show()
        Form_stock_fisico.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub FACTURACIONAUTOMATICAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FACTURACION_POR_RANGOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_facturacion_automatica.Show()
        Form_facturacion_automatica.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub FACTURACIONMANUALToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FACTURACION_MANUAL_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_facturacion.Show()
        Form_facturacion.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub ARCHIVODICOMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ARCHIVO_DICOM_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_archivo_dicom.Show()
        Form_archivo_dicom.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub SERVICIOSLUBRICENTROToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_ventas_lubricentro.Show()
        Form_ventas_lubricentro.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub ADMINISTRARSERVICIOSDELUBRICENTROToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADMINISTRAR_SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_administrar_servicios_lubricentro.Show()
        Form_administrar_servicios_lubricentro.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub HOJASFOLEADASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HOJAS_FOLIADAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_hojas_foleadas.Show()
        Form_hojas_foleadas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub ACTUALIZARToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        actualizar_sistema = "SI"
        System.Diagnostics.Process.Start("http://www.clickoffice.cl/clickoffice.cl/sistema%20de%20ventas/index.htm")
        Me.Close()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub EXISTENCIASToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_existencias.Show()
        Form_existencias.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub REPOSICIONDEVENTASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_reposicion_ventas.Show()
        Form_reposicion_ventas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub STOCKACUMULADOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_stock_acumulado.Show()
        Form_stock_acumulado.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VueltoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CAJA_REGISTRADORA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_caja_registradora.Show()
        Form_caja_registradora.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CALCULARDEUDASDECLIENTESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CALCULAR_DEUDAS_DE_CLIENTES_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_calcular_deuda_cliente.Show()
        Form_calcular_deuda_cliente.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub RESUMENDECUADRATURACAJAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RESUMEN_DE_CUADRATURA_CAJA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_resumen_caja_diaria.Show()
        Form_resumen_caja_diaria.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CAJA2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_caja_dos.Show()
        Form_caja_dos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub


    Private Sub PERSONALIZARSISTEMAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMAGENES_DE_SISTEMA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_imagenes_de_sistema.Show()
        Form_imagenes_de_sistema.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub REPORTESORToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DEUDADECLIENTESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_deuda_clientes_segun_fecha.Show()
        Form_deuda_clientes_segun_fecha.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CONFIGURACIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MENU_CONFIGURACION_ToolStripMenuItem.Click

    End Sub

    Private Sub PictureBox_logo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox_logo.Click

    End Sub


    Sub mostrar_detalle_actualizacion()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "select * from detalle_de_actualizaciones where version='" & (lbl_version.Text) & "'"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
        Else


            If mirutempresa = "87686300-6" Then
                Try
                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO detalle_de_actualizaciones (`version`, `mensaje`, `fecha`) VALUES ('" & (lbl_version.Text) & "', 'SE QUITO EL BOTON PARA MODIFICAR CLIENTES EN VENTAS', '" & (Me.dtp_fecha.Text) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                Catch
                End Try

                Try
                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO detalle_de_actualizaciones (`version`, `mensaje`, `fecha`) VALUES ('" & (lbl_version.Text) & "', 'SE AGREGARON LOS LOGOS QUE FALTABAN EN LOS REPORTES', '" & (Me.dtp_fecha.Text) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                Catch
                End Try

                Try
                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO detalle_de_actualizaciones (`version`, `mensaje`, `fecha`) VALUES ('" & (lbl_version.Text) & "', 'SEGUNDA REVISION A LA PANTALLA DE NOTAS DE CREDITO', '" & (Me.dtp_fecha.Text) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                Catch
                End Try

                'Try
                '    SC.Connection = conexion
                '    SC.CommandText = "INSERT INTO detalle_de_actualizaciones (`version`, `mensaje`, `fecha`) VALUES ('" & (lbl_version.Text) & "', 'SE AGREGO UNA NUEVA FUNCIÓN PARA ACTIVAR O DESACTIVAR CLIENTES.', '" & (Me.dtp_fecha.Text) & "');"
                '    DA.SelectCommand = SC
                '    DA.Fill(DT)
                'Catch
                'End Try

                'Try
                '    SC.Connection = conexion
                '    SC.CommandText = "INSERT INTO detalle_de_actualizaciones (`version`, `mensaje`, `fecha`) VALUES ('" & (lbl_version.Text) & "', 'SE AGREGO UNA NUEVA FUNCIÓN PARA PODER VENDER PRODUCTOS CON O SIN STOCK.', '" & (Me.dtp_fecha.Text) & "');"
                '    DA.SelectCommand = SC
                '    DA.Fill(DT)
                'Catch
                'End Try

                Exit Sub
            End If

            If mirutempresa = "81921000-4" Then
                Try
                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO detalle_de_actualizaciones (`version`, `mensaje`, `fecha`) VALUES ('" & (lbl_version.Text) & "', 'SE AGREGO UNA PANTALLA PARA VER LAS GUIAS RECIBIDAS DESDE EL MENU DE BODEGA, '" & (Me.dtp_fecha.Text) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                Catch
                End Try

                Try
                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO detalle_de_actualizaciones (`version`, `mensaje`, `fecha`) VALUES ('" & (lbl_version.Text) & "', 'SE AGREGO UNA PANTALLA PARA VER EL LISTADO DE EGRESOS POR SUCURSAL EN EL MENU DE ADMINISTRACION-OPCIONES DE CAJA', '" & (Me.dtp_fecha.Text) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                Catch
                End Try

                Try
                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO detalle_de_actualizaciones (`version`, `mensaje`, `fecha`) VALUES ('" & (lbl_version.Text) & "', 'SE AGREGO UN NUEVO CAMPO PARA PAGARES EN EL MANTENEDOR DE CUENTAS CORRIENTES Y SU VALIDACION EN LAS VENTAS', '" & (Me.dtp_fecha.Text) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                Catch
                End Try

                Try
                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO detalle_de_actualizaciones (`version`, `mensaje`, `fecha`) VALUES ('" & (lbl_version.Text) & "', 'SE AGREGO UNA VALIDACION PARA NO ANULAR DOCUMENTOS CON ANTIGUEDAD MAYOR A 30 DIAS', '" & (Me.dtp_fecha.Text) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                Catch
                End Try

                Try
                    SC.Connection = conexion
                    SC.CommandText = "INSERT INTO detalle_de_actualizaciones (`version`, `mensaje`, `fecha`) VALUES ('" & (lbl_version.Text) & "', 'SE AGREGARON MAS FECHAS PARA LA SELECCION DE LA PRIMERA CUOTA DE VENTAS, LLEGANDO A 45 DIAS.', '" & (Me.dtp_fecha.Text) & "');"
                    DA.SelectCommand = SC
                    DA.Fill(DT)
                Catch
                End Try

                'Try
                '    SC.Connection = conexion
                '    SC.CommandText = "INSERT INTO detalle_de_actualizaciones (`version`, `mensaje`, `fecha`) VALUES ('" & (lbl_version.Text) & "', 'SE AGREGO UNA NUEVA FUNCIÓN PARA PODER VENDER PRODUCTOS CON O SIN STOCK.', '" & (Me.dtp_fecha.Text) & "');"
                '    DA.SelectCommand = SC
                '    DA.Fill(DT)
                'Catch
                'End Try


                Exit Sub
            End If

            'Try
            '    SC.Connection = conexion
            '    SC.CommandText = "INSERT INTO detalle_de_actualizaciones (`version`, `mensaje`, `fecha`) VALUES ('" & (lbl_version.Text) & "', 'QUEDA ACTIVA LA NUEVA VENTANA DE PERMISOS.', '" & (Me.dtp_fecha.Text) & "');"
            '    DA.SelectCommand = SC
            '    DA.Fill(DT)
            'Catch
            'End Try

            'Try
            '    SC.Connection = conexion
            '    SC.CommandText = "INSERT INTO detalle_de_actualizaciones (`version`, `mensaje`, `fecha`) VALUES ('" & (lbl_version.Text) & "', 'SE AGREGO UNA NUEVA FUNCIÓN PARA ACTIVAR O DESACTIVAR PRODUCTOS.', '" & (Me.dtp_fecha.Text) & "');"
            '    DA.SelectCommand = SC
            '    DA.Fill(DT)
            'Catch
            'End Try

            'Try
            '    SC.Connection = conexion
            '    SC.CommandText = "INSERT INTO detalle_de_actualizaciones (`version`, `mensaje`, `fecha`) VALUES ('" & (lbl_version.Text) & "', 'SE AGREGO UNA NUEVA FUNCIÓN PARA ACTIVAR O DESACTIVAR USUARIOS.', '" & (Me.dtp_fecha.Text) & "');"
            '    DA.SelectCommand = SC
            '    DA.Fill(DT)
            'Catch
            'End Try

            'Try
            '    SC.Connection = conexion
            '    SC.CommandText = "INSERT INTO detalle_de_actualizaciones (`version`, `mensaje`, `fecha`) VALUES ('" & (lbl_version.Text) & "', 'SE AGREGO UNA NUEVA FUNCIÓN PARA ACTIVAR O DESACTIVAR CLIENTES.', '" & (Me.dtp_fecha.Text) & "');"
            '    DA.SelectCommand = SC
            '    DA.Fill(DT)
            'Catch
            'End Try

            'Try
            '    SC.Connection = conexion
            '    SC.CommandText = "INSERT INTO detalle_de_actualizaciones (`version`, `mensaje`, `fecha`) VALUES ('" & (lbl_version.Text) & "', 'SE AGREGO UNA NUEVA FUNCIÓN PARA PODER VENDER PRODUCTOS CON O SIN STOCK.', '" & (Me.dtp_fecha.Text) & "');"
            '    DA.SelectCommand = SC
            '    DA.Fill(DT)
            'Catch
            'End Try

        End If
        conexion.Close()
    End Sub

    Private Sub REGISTRODEACTUALIZACIONESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_de_actualizaciones.Show()
        Form_registro_de_actualizaciones.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PERMISOSToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_permisos_2.Show()
        Form_permisos_2.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub AGREGARPERMISOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_agregar_permisos.Show()
        Form_agregar_permisos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PANTALLADEPERMISOSTRADICIONALToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_permisos.Show()
        Form_permisos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub NUEVAVENTANADEPERMISOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_permisos_2.Show()
        Form_permisos_2.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DEUDACLIENTESToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_deuda_clientes_segun_fecha.Show()
        Form_deuda_clientes_segun_fecha.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PERMISOSAGREGARToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_agregar_permisos.Show()
        Form_agregar_permisos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub EXISTENCIASToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_existencias.Show()
        Form_existencias.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub REPOSICIONDEVENTASToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_reposicion_ventas.Show()
        Form_reposicion_ventas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub STOCKACUMULADOToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_stock_acumulado.Show()
        Form_stock_acumulado.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub LISTADODEEGRESOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LISTADO_DE_EGRESOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_reporte_de_egresos.Show()
        Form_reporte_de_egresos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub GUIASACEPTADASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GUIAS_ACEPTADAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_detalle_guias_aceptadas.Show()
        Form_detalle_guias_aceptadas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub EXISTENCIAS_ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXISTENCIAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_existencias.Show()
        Form_existencias.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub REPORTEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REPOSICION_DE_VENTAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_reposicion_ventas.Show()
        Form_reposicion_ventas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub STOCKACUMULADOToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCK_ACUMULADO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_stock_acumulado.Show()
        Form_stock_acumulado.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DEUDADECLIENTESToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEUDA_DE_CLIENTE_SEGUN_FECHA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_deuda_clientes_segun_fecha.Show()
        Form_deuda_clientes_segun_fecha.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub REPORTES_ARANA_ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DETALLEDEENVIOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DETALLE_DE_ENVIOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_detalle_envios.Show()
        Form_detalle_envios.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub EDICIONDEIMPRESIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_edicion_de_impresion.Show()
        Form_edicion_de_impresion.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub GUIAS_DE_TRASLADO_A_PROVEEDORES_ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GUIAS_DE_TRASLADO_A_PROVEEDORES_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_guias_traslado_a_proveedores.Show()
        Form_guias_traslado_a_proveedores.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub


    Private Sub HISTORICODECUENTASCORRIENTESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HISTORICO_DE_CUENTASCORRIENTES_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_historico_cuentas_corrientes.Show()
        Form_historico_cuentas_corrientes.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub LISTADODECLIENTESCONPAGAREToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LISTADO_DE_CLIENTES_CON_PAGARE_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_listado_de_clientes_con_pagare.Show()
        Form_listado_de_clientes_con_pagare.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CONSUMO_INTERNO_ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONSUMO_INTERNO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_consumo_interno.Show()
        Form_consumo_interno.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub RECEPCIONDETRABAJOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECEPCION_DE_TRABAJO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_recepcion_de_trabajo.Show()
        Form_recepcion_de_trabajo.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub IMAGENESDEPRODUCTOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMAGENES_DE_PRODUCTOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_de_imagenes_de_productos.Show()
        Form_registro_de_imagenes_de_productos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub REGISTRODEHARDWAREToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REGISTRO_DE_HARDWARE_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_hardware.Show()
        Form_registro_hardware.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub ENVIODEGARANTIASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENVIO_A_GARANTIA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_envio_a_garantias.Show()
        Form_envio_a_garantias.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DETALLEDEENVIOSAGARANTIAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_detalle_envios_a_garantias.Show()
        Form_detalle_envios_a_garantias.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub ASOCIARCLIENTESAEMPRESASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_asociar_clientes_a_empresas.Show()
        Form_asociar_clientes_a_empresas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub LISTADODEVALESDECAMBIOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LISTADO_DE_VALES_DE_CAMBIO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_listado_vales_de_cambio.Show()
        Form_listado_vales_de_cambio.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub MENU_VENTAS_ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MENU_VENTAS_ToolStripMenuItem.Click

    End Sub

    Private Sub ORDENESDECOMPRAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ORDENES_DE_COMPRA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_orden_de_compra.Show()
        Form_orden_de_compra.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CENTRALDECOSTOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CENTRAL_DE_COSTOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_central_de_costos.Show()
        Form_central_de_costos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub INGRESARCREDITOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INGRESAR_CREDITOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_ingresar_creditos.Show()
        Form_ingresar_creditos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub RESUMENDECOMPRASPORPROVEEDORToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RESUMEN_DE_COMPRAS_POR_PROVEEDOR_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_resumen_de_compras_por_proveedor.Show()
        Form_resumen_de_compras_por_proveedor.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub LISTADOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LISTADOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_listados.Show()
        Form_listados.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub RESUMEN_DE_COMPRAS_POR_ITEM_ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RESUMEN_DE_COMPRAS_POR_ITEM_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_resumen_por_item.Show()
        Form_resumen_por_item.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub RESUMENDEITEMPORGUIASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RESUMEN_DE_ITEM_POR_GUIAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_resumen_de_item_por_guia.Show()
        Form_resumen_de_item_por_guia.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CARTOLAKARDEX2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_cartola_kardex_2.Show()
        Form_cartola_kardex_2.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub REVISARKARDEXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_revisar_documentos_a_kardex.Show()
        Form_revisar_documentos_a_kardex.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub SUELDOSPORCAJAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUELDOS_POR_CAJA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_sueldos_por_caja.Show()
        Form_sueldos_por_caja.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub REVISARCAJASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REVISAR_CAJAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_revisar_cajas.Show()
        Form_revisar_cajas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub RESUMENDEVENASPORITEMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RESUMEN_DE_VENTAS_POR_ITEM_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_resumen_de_ventas_por_item.Show()
        Form_resumen_de_ventas_por_item.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub REPOSICION_ARANA_ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REPOSICION_ARANA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_reposicion_arana.Show()
        Form_reposicion_arana.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub ESTADISTICASDEVENTAPORPORDUCTOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ESTADISTICAS_DE_VENTA_POR_PRODUCTOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_estadistica_ventas_por_producto.Show()
        Form_estadistica_ventas_por_producto.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PRODUCTOSREPETIDOSKARDEXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_productos_repetidos_kardex.Show()
        Form_productos_repetidos_kardex.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DOCUMENTOSDUPLICADOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_documentos_duplicados.Show()
        Form_documentos_duplicados.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub REVISIONDEDOCUMENTOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub lbl_pie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_pie.Click

    End Sub

    Private Sub DOCUMENTOSSINDETALLEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_documentos_sin_detalle.Show()
        Form_documentos_sin_detalle.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DETALLESINDOCUMENTOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_detalle_sin_documentos.Show()
        Form_detalle_sin_documentos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CARTOLAKARDEX2ToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_cartola_kardex_2.Show()
        Form_cartola_kardex_2.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CONTEOS_ARANA_ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONTEOS_ARANA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_conteos_arana.Show()
        Form_conteos_arana.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub GUIAS_DE_GARANTIA_ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LISTADO_GUIAS_DE_GARANTIA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_detalle_guias_de_garantia.Show()
        Form_detalle_guias_de_garantia.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub LISTADODEPEDIDOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LISTADO_DE_PEDIDOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_pedidos_aceptados.Show()
        Form_pedidos_aceptados.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub LISTADO_DE_INTERESES_Y_GASTOS_oolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LISTADO_DE_INTERESES_Y_GASTOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_listado_intereses_y_gastos.Show()
        Form_listado_intereses_y_gastos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VENTAESPERADAPORFAMILIAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VENTA_ESPERADA_POR_FAMILIA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_venta_esperada_por_familia.Show()
        Form_venta_esperada_por_familia.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub INVENTARIODIARIOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_inventario_diario.Show()
        Form_inventario_diario.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub REVISARARCHIVOSIIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REVISAR_ARCHIVO_SII_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_revisar_archivo_sii.Show()
        Form_revisar_archivo_sii.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub COMISIONES2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COMISIONES_POR_VENDEDOR_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_comisiones_por_vendedor.Show()
        Form_comisiones_por_vendedor.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DOCUMENTOS_CON_PAGOS_COMBINADOS_ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOCUMENTOS_CON_PAGOS_COMBINADOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_documentos_con_pagos_combinados.Show()
        Form_documentos_con_pagos_combinados.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If (BackgroundWorker1.CancellationPending) Then
            e.Cancel = True
            Exit Sub
        Else
            Me.descargar_imagenes()
            Me.agregar_tareas()
            Me.empresa()
            Me.mostrar_datos_login()
            Me.revisar_permisos()
            Me.cargar_imagenes()
            Me.personalizar_empresa()
            Me.valores()
            Me.ajustar()
            Me.fecha_hora_servidor()
            ' cerrar_login = "SI"
            Me.Opacity = 100


        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'form_Ingreso.Visible = False

        If tipo_usuario = "USUARIO DEL SISTEMA" Then
            ConsultaBloqueaMenus()
            ConsultaMenus()
        End If

        form_Ingreso.Close()
    End Sub

    Private Sub NUMERODEATENCIONCLIENTEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_numero_de_atencion_cliente.Show()
        Form_numero_de_atencion_cliente.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub BUSCARDOCUMENTODECAMBIODEPRODUCTOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUSCAR_DOCUMENTO_DE_CAMBIO_DE_PRODUCTO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_buscar_documento_de_cambio_de_producto.Show()
        Form_buscar_documento_de_cambio_de_producto.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CONFIGURACIONCORREODEVENTASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONFIGURACION_CORREO_DE_VENTAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_configuracion_correo_ventas.Show()
        Form_configuracion_correo_ventas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CONFIGURACIONCORREODEADMINISTRACIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONFIGURACION_CORREO_DE_ADMINISTRACION_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_configuracion_correo_administracion.Show()
        Form_configuracion_correo_administracion.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub EMPRESASRELACIONADASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_empresas_relacionadas.Show()
        Form_empresas_relacionadas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub ASOCIARCLIENTESAEMPRESASToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ASOCIAR_CLIENTES_A_EMPRESAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_asociar_clientes_a_empresas.Show()
        Form_asociar_clientes_a_empresas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VaciarToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_vaciar.Show()
        Form_vaciar.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CAMBIO_DE_CONTRASEÑA_ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CAMBIO_DE_CONTRASEÑA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_cambio_de_contraseña_asistente.Show()
        Form_cambio_de_contraseña_asistente.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VaciarToolStripMenuItem_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_vaciar.Show()
        Form_vaciar.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub RUTAPARARESPALDOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RUTA_PARA_RESPALDOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_ruta_respaldos.Show()
        Form_registro_ruta_respaldos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub MODIFICAR_CREDITOS_ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MODIFICAR_CREDITOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_modificar_creditos.Show()
        Form_modificar_creditos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub REVISION_DE_STOCK_ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REVISION_DE_STOCK_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_revision_de_stock.Show()
        Form_revision_de_stock.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub AGREGARPROPIEDADESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MANTENCION_DE_PROPIEDADES_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_agregar_propiedades.Show()
        Form_agregar_propiedades.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub IMAGENESDEPRODUCTOSPARAPUBLICIDADToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMAGENES_DE_PRODUCTOS_PARA_PUBLICIDAD_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_de_imagenes_de_productos_publicidad.Show()
        Form_registro_de_imagenes_de_productos_publicidad.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub REGISTRODEFACTURASDEUDAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REGISTRODEFACTURASDEUDAToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_de_facturas_deuda.Show()
        Form_registro_de_facturas_deuda.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub LIMPIARToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_vaciar.Show()
        Form_vaciar.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VaciarToolStripMenuItem_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_vaciar.Show()
        Form_vaciar.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_vaciar.Show()
        Form_vaciar.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub TARJETADEPRESENTACIONRAPIDAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TARJETA_DE_PRESENTACION_RAPIDA_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False

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
            link_red_social = DS.Tables(DT.TableName).Rows(0).Item("link_red_social")
        End If
        conexion.Close()

        Dim ticket_tarjeta_presentacion As String = ""
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
            ticket_tarjeta_presentacion = DS.Tables(DT.TableName).Rows(0).Item("ticket_tarjeta_presentacion")
        End If
        conexion.Close()



        With Pd.PrinterSettings
            .PrinterName = ticket_tarjeta_presentacion
            .Copies = 1
            .PrintRange = PrintRange.AllPages
            If .IsValid Then
                Me.Pd.PrintController = New StandardPrintController
                Dim pkCustomSize1 As New PaperSize("New Long Roll", 1000, 850)
                Me.Pd.DefaultPageSettings.PaperSize = pkCustomSize1
                Pd.PrintController = New System.Drawing.Printing.StandardPrintController()
                Pd.Print()
            Else
                MsgBox("LA IMPRESORA NO ES VALIDA", 0 + 16, "ERROR")
                lbl_mensaje.Visible = False
                Me.Enabled = True
                Exit Sub
            End If
        End With


        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
        Dim Font_texto_titulo As New Font("arial", 9, FontStyle.Bold)
        Dim Font_texto_empresa As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_cabecera As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_titulo_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_detalle As New Font("arial", 7, FontStyle.Bold)
        Dim Font_texto_totales As New Font("arial", 9, FontStyle.Bold)
        Dim Font_texto_subtitulo As New Font("arial", 9, FontStyle.Regular)

        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = 5
        margen_superior = 0

        Try
            Dim imagen_reporte As Image
            imagen_reporte = Image.FromFile("C:\Temp\" & mirutempresa & "\Logo-impresion.jpg")
            Dim posicion_imagen As New PointF(margen_izquierdo + 0, margen_superior + 0)
            e.Graphics.DrawImage(imagen_reporte, posicion_imagen)
        Catch
        End Try

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim stringFormat_left As New StringFormat()
        stringFormat_left.Alignment = StringAlignment.Near
        stringFormat_left.LineAlignment = StringAlignment.Near


        Dim rect1 As New Rectangle(margen_izquierdo + 10, margen_superior + 90, margen_izquierdo + 250, margen_superior + 15)
        Dim rect2 As New Rectangle(margen_izquierdo + 10, margen_superior + 105, margen_izquierdo + 250, margen_superior + 15)
        Dim rect3 As New Rectangle(margen_izquierdo + 10, margen_superior + 120, margen_izquierdo + 250, margen_superior + 15)
        Dim rect4 As New Rectangle(margen_izquierdo + 10, margen_superior + 135, margen_izquierdo + 250, margen_superior + 15)
        Dim rect5 As New Rectangle(margen_izquierdo + 10, margen_superior + 150, margen_izquierdo + 250, margen_superior + 15)
        Dim rect6 As New Rectangle(margen_izquierdo + 10, margen_superior + 165, margen_izquierdo + 250, margen_superior + 15)
        Dim rect7 As New Rectangle(margen_izquierdo + 10, margen_superior + 180, margen_izquierdo + 250, margen_superior + 15)
        Dim rect_titulo As New Rectangle(margen_izquierdo + 10, margen_superior + 215, margen_izquierdo + 250, margen_superior + 15)

        e.Graphics.DrawString(minombreempresa, Font_texto_empresa, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(migiroempresa, Font_texto_empresa, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font_texto_empresa, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font_texto_empresa, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font_texto_empresa, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font_texto_empresa, Brushes.Black, rect6, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font_texto_empresa, Brushes.Black, rect7, stringFormat)

        e.Graphics.DrawString("DATOS DE CONTACTO", Font_texto_titulo, Brushes.Black, rect_titulo, stringFormat)

        e.Graphics.DrawString("NOMBRE", Font_texto_titulo, Brushes.Black, margen_izquierdo + 0, margen_superior + 245)
        e.Graphics.DrawString(":", Font_texto_titulo, Brushes.Black, margen_izquierdo + 70, margen_superior + 245)
        e.Graphics.DrawString(minombre, Font_texto_subtitulo, Brushes.Black, margen_izquierdo + 80, margen_superior + 245)

        e.Graphics.DrawString("TELEFONO", Font_texto_titulo, Brushes.Black, margen_izquierdo + 0, margen_superior + 290)
        e.Graphics.DrawString(":", Font_texto_titulo, Brushes.Black, margen_izquierdo + 70, margen_superior + 290)
        e.Graphics.DrawString(mitelefono, Font_texto_subtitulo, Brushes.Black, margen_izquierdo + 80, margen_superior + 290)

        e.Graphics.DrawString("AREA", Font_texto_titulo, Brushes.Black, margen_izquierdo + 0, margen_superior + 335)
        e.Graphics.DrawString(":", Font_texto_titulo, Brushes.Black, margen_izquierdo + 70, margen_superior + 335)
        e.Graphics.DrawString(miarea, Font_texto_subtitulo, Brushes.Black, margen_izquierdo + 80, margen_superior + 335)


        'e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 1, margen_superior + 500, margen_izquierdo + 295, margen_superior + 305)
        Dim rect_siguenos As New Rectangle(margen_izquierdo + 10, margen_superior + 380, margen_izquierdo + 270, margen_superior + 15)
        e.Graphics.DrawString("SÍGUENOS EN:", Font_texto_titulo, Brushes.Black, rect_siguenos, stringFormat)

        Dim rect_link_red As New Rectangle(margen_izquierdo + 10, margen_superior + 395, margen_izquierdo + 250, margen_superior + 15)
        e.Graphics.DrawString(link_red_social, Font_texto_subtitulo, Brushes.Black, rect_link_red, stringFormat)

        Dim rect_guion_final As New Rectangle(margen_izquierdo + 10, margen_superior + 450, margen_izquierdo + 250, margen_superior + 15)
        e.Graphics.DrawString("-", Font_texto_totales, Brushes.Gray, rect_guion_final, stringFormat)
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


    '    dr = dt.NewRow()

    '    'Try
    '    '    dr("logo_empresa") = Imagen_reporte
    '    'Catch
    '    'End Try

    '    dr("nombre_empresa") = minombreempresa
    '    dr("giro_empresa") = migiroempresa
    '    dr("direccion_empresa") = midireccionempresa
    '    dr("comuna_empresa") = micomunaempresa
    '    dr("telefono_empresa") = mitelefonoempresa
    '    dr("correo_empresa") = micorreoempresa
    '    dr("rut_empresa") = mirutempresa

    '    Try
    '        dr("DataColumn1") = minombre
    '    Catch
    '    End Try
    '    Try
    '        dr("DataColumn2") = mitelefono
    '    Catch
    '    End Try
    '    Try
    '        dr("DataColumn3") = miarea
    '    Catch
    '    End Try

    '    Try
    '        dr("DataColumn4") = link_red_social
    '    Catch
    '    End Try

    '    dt.Rows.Add(dr)

    '    ds.Tables.Add(dt)
    '    ds.Tables(0).TableName = "DS_reporte"

    '    Dim iDS As New DS_reporte
    '    iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
    '    Return iDS

    'End Function

    Private Sub PRODUCTOSPAGINAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCTOSPAGINAToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_exportar_productos_pagina.Show()
        Form_exportar_productos_pagina.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VACIARToolStripMenuItem_Click_4(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_vaciar.Show()
        Form_vaciar.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PRODUCTOS_CON_MAS_MOVIMIENTOS_ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCTOS_CON_MAS_MOVIMIENTOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_productos_con_mas_movimientos.Show()
        Form_productos_con_mas_movimientos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub LIBRO_DE_COMPRAS_IMPRESION_ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LIBRO_DE_COMPRAS_IMPRESION_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_libro_de_compras_impresion.Show()
        Form_libro_de_compras_impresion.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub FffffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_recepcion_de_trabajo.Show()
        Form_recepcion_de_trabajo.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Sub fecha_hora_servidor()
        Try
            conexion.Close()
            LimpiarDS2()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            SC2.CommandText = "select current_time as hora_servidor, current_date as fecha_servidor"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
                dtp_fecha.Text = DS2.Tables(DT2.TableName).Rows(0).Item("fecha_servidor")

                lbl_hora.Text = Convert.ToString(DS2.Tables(DT2.TableName).Rows(0).Item("hora_servidor"))
            End If

            lbl_fecha.Text = Format(dtp_fecha.Text, "Long Date")
            lbl_fecha.Text = UCase(lbl_fecha.Text)
            dtp_fecha.CustomFormat = "yyy-MM-dd"
            segundo = Strings.Right(lbl_hora.Text, 2)
        Catch
            '    conexion.Close()
            'Catch err As NullReferenceException
            '    Me.Close()
        End Try
    End Sub

    Private Sub VACIARToolStripMenuItem_Click_5(sender As Object, e As EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_vaciar.Show()
        Form_vaciar.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub XMLToolStripMenuItem_Click(sender As Object, e As EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_xml.Show()
        Form_xml.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub Timer_memoria_Tick(sender As Object, e As EventArgs)
        LiberarMemoria()
    End Sub

    Private Sub VENTAS_MULTIPLES_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VENTAS_MULTIPLES_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_venta_multiple.Show()
        Form_venta_multiple.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PRODUCTOSMODIFICADOSARANAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRODUCTOSMODIFICADOSARANAToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_productos_modificados_arana.Show()
        Form_productos_modificados_arana.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub FOMAS_DE_PAGO_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FOMAS_DE_PAGO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_forma_de_pago_por_defecto.Show()
        Form_forma_de_pago_por_defecto.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub AGREGAR_ABONOS_MANUALES_ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_agregar_abonos_manuales.Show()
        Form_agregar_abonos_manuales.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PRUEBASToolStripMenuItem_Click(sender As Object, e As EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_pruebas.Show()
        Form_pruebas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VACIARToolStripMenuItem_Click_6(sender As Object, e As EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_vaciar.Show()
        Form_vaciar.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DIFERENCIAS_COMPRAS_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DIFERENCIAS_COMPRAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_diferencia_compras.Show()
        Form_diferencia_compras.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VACIARToolStripMenuItem_Click_7(sender As Object, e As EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_vaciar.Show()
        Form_vaciar.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DESPACHOS_WEB_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DESPACHOS_WEB_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_despacho_web.Show()
        Form_despacho_web.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub LISTADO_DE_ABONOS_PROPIEDADES_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LISTADO_DE_ABONOS_PROPIEDADES_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_abonos_listado_propiedades.Show()
        Form_abonos_listado_propiedades.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub SOLICITAR_COTIZACION_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SOLICITAR_COTIZACION_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_solicitar_cotizacion.Show()
        Form_solicitar_cotizacion.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub REVISION_DE_COTIZACIONESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REVISION_DE_COTIZACIONES_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_revision_cotizaciones.Show()
        Form_revision_cotizaciones.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CARGAR_NEUMATICOS_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CARGAR_NEUMATICOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_cargar_neumaticos.Show()
        Form_cargar_neumaticos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CONTAR_EFECTIVO_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONTAR_EFECTIVO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_contar_dinero.Show()
        Form_contar_dinero.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub




    'Private Sub MENU_VENTAS_ToolStripMenuItem_MouseMove(sender As Object, e As MouseEventArgs) Handles MENU_VENTAS_ToolStripMenuItem.MouseMove
    '    'EN EL FOCO
    '    MENU_VENTAS_ToolStripMenuItem.ForeColor = Color.Black
    'End Sub

    'Private Sub MENU_VENTAS_ToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles MENU_VENTAS_ToolStripMenuItem.MouseLeave
    '    'DESPUES DEL FOCO
    '    MENU_VENTAS_ToolStripMenuItem.ForeColor = Color.White
    'End Sub

    'Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    'End Sub

    'Private Sub MenuStrip1_MouseMove(sender As Object, e As MouseEventArgs) Handles MenuStrip1.MouseMove
    '    'EN EL FOCO
    '    If MENU_VENTAS_ToolStripMenuItem.Selected = True Then
    '        MENU_VENTAS_ToolStripMenuItem.ForeColor = SystemColors.WindowFrame
    '    End If
    'End Sub

    'Private Sub MenuStrip1_MouseLeave(sender As Object, e As EventArgs) Handles MenuStrip1.MouseLeave
    '    'DESPUES DEL FOCO
    '    If MENU_VENTAS_ToolStripMenuItem.Selected = True Then
    '        MENU_VENTAS_ToolStripMenuItem.ForeColor = Color.White
    '    End If
    'End Sub

    'Private Sub MenuStrip1_GotFocus(sender As Object, e As EventArgs) Handles MenuStrip1.GotFocus
    '    'EN EL FOCO
    '    If MENU_VENTAS_ToolStripMenuItem.Selected = True Then
    '        MENU_VENTAS_ToolStripMenuItem.ForeColor = SystemColors.WindowFrame
    '    End If
    'End Sub

    'Private Sub MenuStrip1_LostFocus(sender As Object, e As EventArgs) Handles MenuStrip1.LostFocus
    '    'DESPUES DEL FOCO
    '    MENU_ADQUISICIONES_ToolStripMenuItem.ForeColor = Color.White
    '    MENU_ADMINISTRACION_ToolStripMenuItem.ForeColor = Color.White
    '    MENU_BODEGA_ToolStripMenuItem.ForeColor = Color.White
    '    MENU_CONFIGURACION_ToolStripMenuItem.ForeColor = Color.White
    '    MENU_MANTENEDORES_ToolStripMenuItem.ForeColor = Color.White
    '    MENU_VENTAS_ToolStripMenuItem.ForeColor = Color.White
    'End Sub


    Private Sub MENU_ADQUISICIONES_ToolStripMenuItem_DropDownOpened(sender As Object, e As EventArgs) Handles MENU_ADQUISICIONES_ToolStripMenuItem.DropDownOpened
        MENU_ADQUISICIONES_ToolStripMenuItem.ForeColor = Color.Black
    End Sub

    Private Sub MENU_ADQUISICIONES_ToolStripMenuItem_DropDownClosed(sender As Object, e As EventArgs) Handles MENU_ADQUISICIONES_ToolStripMenuItem.DropDownClosed
        MENU_ADQUISICIONES_ToolStripMenuItem.ForeColor = Color.White
    End Sub



    Private Sub MENU_ADMINISTRACION_ToolStripMenuItem_DropDownOpened(sender As Object, e As EventArgs) Handles MENU_ADMINISTRACION_ToolStripMenuItem.DropDownOpened
        MENU_ADMINISTRACION_ToolStripMenuItem.ForeColor = Color.Black
    End Sub

    Private Sub MENU_ADMINISTRACION_ToolStripMenuItem_DropDownClosed(sender As Object, e As EventArgs) Handles MENU_ADMINISTRACION_ToolStripMenuItem.DropDownClosed
        MENU_ADMINISTRACION_ToolStripMenuItem.ForeColor = Color.White
    End Sub



    Private Sub MENU_BODEGA_ToolStripMenuItem_DropDownOpened(sender As Object, e As EventArgs) Handles MENU_BODEGA_ToolStripMenuItem.DropDownOpened
        MENU_BODEGA_ToolStripMenuItem.ForeColor = Color.Black
    End Sub

    Private Sub MENU_BODEGA_ToolStripMenuItem_DropDownClosed(sender As Object, e As EventArgs) Handles MENU_BODEGA_ToolStripMenuItem.DropDownClosed
        MENU_BODEGA_ToolStripMenuItem.ForeColor = Color.White
    End Sub


    Private Sub MENU_CONFIGURACION_ToolStripMenuItem_DropDownOpened(sender As Object, e As EventArgs) Handles MENU_CONFIGURACION_ToolStripMenuItem.DropDownOpened
        MENU_CONFIGURACION_ToolStripMenuItem.ForeColor = Color.Black
    End Sub

    Private Sub MENU_CONFIGURACION_ToolStripMenuItem_DropDownClosed(sender As Object, e As EventArgs) Handles MENU_CONFIGURACION_ToolStripMenuItem.DropDownClosed
        MENU_CONFIGURACION_ToolStripMenuItem.ForeColor = Color.White
    End Sub


    Private Sub MENU_MANTENEDORES_ToolStripMenuItem_DropDownOpened(sender As Object, e As EventArgs) Handles MENU_MANTENEDORES_ToolStripMenuItem.DropDownOpened
        MENU_MANTENEDORES_ToolStripMenuItem.ForeColor = Color.Black
    End Sub

    Private Sub MENU_MANTENEDORES_ToolStripMenuItem_DropDownClosed(sender As Object, e As EventArgs) Handles MENU_MANTENEDORES_ToolStripMenuItem.DropDownClosed
        MENU_MANTENEDORES_ToolStripMenuItem.ForeColor = Color.White
    End Sub

    Private Sub MENU_VENTAS_ToolStripMenuItem_DropDownOpened(sender As Object, e As EventArgs) Handles MENU_VENTAS_ToolStripMenuItem.DropDownOpened
        MENU_VENTAS_ToolStripMenuItem.ForeColor = Color.Black
    End Sub

    Private Sub MENU_VENTAS_ToolStripMenuItem_DropDownClosed(sender As Object, e As EventArgs) Handles MENU_VENTAS_ToolStripMenuItem.DropDownClosed
        MENU_VENTAS_ToolStripMenuItem.ForeColor = Color.White
    End Sub

    Private Sub PRODUCTOS_CON_FAMILIAS_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRODUCTOS_CON_FAMILIAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_registro_productos_con_familia.Show()
        Form_registro_productos_con_familia.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub SUCURSALES_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SUCURSALES_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_sucursales.Show()
        Form_sucursales.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PRODUCTOS_PAGINA_NEUMAPRO_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRODUCTOS_PAGINA_NEUMAPRO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_productos_pagina_neumapro.Show()
        Form_productos_pagina_neumapro.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PROVEEDORES_CONTACTO_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PROVEEDORES_CONTACTO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_proveedores_contactos.Show()
        Form_proveedores_contactos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub CONTROL_CAF_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONTROL_CAF_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_control_caf.Show()
        Form_control_caf.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PROVEEDORES_MARCAS_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PROVEEDORES_MARCAS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_proveedores_marcas.Show()
        Form_proveedores_marcas.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub MARCASVEHICULOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MARCASVEHICULOSToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_marcas_vehiculos.Show()
        Form_marcas_vehiculos.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub ORDEN_DE_TRABAJO_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ORDEN_DE_TRABAJO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_orden_de_trabajo.Show()
        Form_orden_de_trabajo.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VACIARToolStripMenuItem_Click_8(sender As Object, e As EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_vaciar.Show()
        Form_vaciar.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VACIARToolStripMenuItem_Click_9(sender As Object, e As EventArgs) 
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_vaciar.Show()
        Form_vaciar.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VACAIRToolStripMenuItem_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub ANTICIPOS_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ANTICIPOS_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_detalle_cuadratura_caja.Show()
        Form_detalle_cuadratura_caja.WindowState = FormWindowState.Normal

        Form_detalle_cuadratura_caja.Combo_movimiento.Enabled = False
        Form_detalle_cuadratura_caja.combo_tipo.Enabled = False

        Form_detalle_cuadratura_caja.Combo_movimiento.Text = "EGRESO"
        Form_detalle_cuadratura_caja.combo_tipo.Text = "ANTICIPOS"

        ' Form_detalle_cuadratura_caja.Combo_detalle.Enabled = False

        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub VACIARToolStripMenuItem_Click_10(sender As Object, e As EventArgs)
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_vaciar.Show()
        Form_vaciar.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub DETALLE_VENTAS_CREDITO_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DETALLE_VENTAS_CREDITO_ToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_detalle_ventas_credito.Show()
        Form_detalle_ventas_credito.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub PRUEBASToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles PRUEBASToolStripMenuItem.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Form_vaciar.Show()
        Form_vaciar.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Minimized
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub
End Class
