<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_menu_principal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_menu_principal))
        Me.Timer_hora = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_inactividad_menu = New System.Windows.Forms.Timer(Me.components)
        Me.lbl_uc = New System.Windows.Forms.Label
        Me.lbl_pie = New System.Windows.Forms.Label
        Me.lbl_mensaje = New System.Windows.Forms.Label
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker
        Me.lbl_hora = New System.Windows.Forms.Label
        Me.lbl_fecha = New System.Windows.Forms.Label
        Me.lbl_usuario_conectado = New System.Windows.Forms.Label
        Me.lbl_soporte_remoto = New System.Windows.Forms.Label
        Me.Panel_pie = New System.Windows.Forms.Panel
        Me.lbl_contacto = New System.Windows.Forms.Label
        Me.grilla_conexiones = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbl_version = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.MENU_ADQUISICIONES_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.STOCK_MINIMO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.REALIZAR_PEDIDOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MIS_PEDIDOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CONFIRMACION_DE_LLEGADA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.REVISION_DE_PEDIDOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RESERVAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.REALIZAR_RESERVA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MIS_RESERVAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ORDENES_DE_COMPRA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CENTRAL_DE_COSTOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PEDIDOS_OR_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MENU_ADMINISTRACION_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FACTURACION_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FACTURACION_POR_RANGOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FACTURACION_MANUAL_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CORREGIR_DOCUMENTOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OPCIONES_DE_CAJA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CUADRATURA_DE_CAJA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DETALLE_DE_ABONOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LISTADO_DE_DOCUMENTOS_NULOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LISTADO_DE_ABONOS_PARA_CAJA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.REGISTRO_DE_CHEQUES_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CAJA_REGISTRADORA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RESUMEN_DE_CUADRATURA_CAJA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LISTADO_DE_EGRESOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CUADRATURA_FIN_DE_MES_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SUELDOS_POR_CAJA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ANTICIPOS_Y_SUELDOS_JEFE_LOCAL_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FONDO_DE_SUELDOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DOCUMENTOS_CON_PAGOS_COMBINADOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.REGISTRO_DE_FACTURAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ESTADISTICAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VENTAS_DEL_DIA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VENTAS_DE_LA_SEMANA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VENTAS_SEGUN_VENDEDOR_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BUSCAR_FACTURAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.REPORTE_LIBRO_DE_COMPRAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LIBRO_DE_COMPRAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.REVISAR_ARCHIVO_SII_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LIBRO_DE_VENTAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BUSCAR_TOTALES_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CORREGIR_NUMEROS_DE_IMPRESION_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.INGRESO_MANUAL_DE_VENTAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NOTAS_DE_CREDITO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TRASPASO_DE_STOCK_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DETALLE_DE_VENTAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DETALLE_DE_VENTAS_POR_DOCUMENTO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CUENTAS_POR_COBRAR_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ESTADO_DE_CUENTA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ESTADO_DE_CUENTA_POR_RANGO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AGREGAR_ABONOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AGREGAR_ABONOS_SIN_IMPUTAR_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IMPUTAR_ABONOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IMPUTAR_NOTAS_DE_CREDITO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DEUDORES_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LISTADO_DE_ABONOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LISTADO_DE_LETRAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DETALLE_DE_CREDITOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DETALLE_DE_VENTAS_CON_PIE_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DETALLE_DE_VENTAS_PAGO_COMBINADO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ARCHIVO_DICOM_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DEUDA_DE_CLIENTE_SEGUN_FECHA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HISTORICO_DE_CUENTASCORRIENTES_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.INGRESAR_CREDITOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LISTADO_DE_INTERESES_Y_GASTOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NOTAS_DE_DEBITO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ESTADO_DE_DEUDAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DEUDA_CLIENTES_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DEUDA_PROVEEDORES_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CALCULAR_DEUDAS_DE_CLIENTES_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HOJAS_FOLIADAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LISTADO_DE_CLIENTES_CON_PAGARE_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SALIDA_DE_TRABAJADORES_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.REGISTRODEFACTURASDEUDAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LIBRO_DE_COMPRAS_IMPRESION_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MENU_BODEGA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.COMPRAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ETIQUETAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CODIGOS_DE_BARRA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TRASPASO_A_SUCURSAL_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.INVENTARIO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DETALLE_DE_COMPRAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GUIAS_DE_TRASLADO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ASIGNAR_FAMILIAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GUIAS_ACEPTADAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EXISTENCIAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.REPOSICION_DE_VENTAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.STOCK_ACUMULADO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DETALLE_DE_ENVIOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RESUMEN_DE_COMPRAS_Y_GUIAS_DE_TRASLADO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GUIAS_DE_TRASLADO_A_PROVEEDORES_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CONSUMO_INTERNO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ENVIO_A_GARANTIA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RESUMEN_DE_COMPRAS_POR_PROVEEDOR_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RESUMEN_DE_COMPRAS_POR_ITEM_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RESUMEN_DE_ITEM_POR_GUIAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CONTROL_DE_DESPACHOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RESUMEN_DE_COMPRAS_POR_GUIAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RESUMEN_DE_VENTAS_POR_ITEM_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.REPOSICION_ARANA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.REVISION_DE_DESPACHOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CONTEOS_ARANA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LISTADO_GUIAS_DE_GARANTIA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LISTADO_DE_PEDIDOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VENTA_ESPERADA_POR_FAMILIA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.INVENTARIO_DIARIO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.REVISION_DE_STOCK_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MENU_CONFIGURACION_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PERMISOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EMPRESA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NUMERACION_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IMPRESORAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RESPALDO_BD_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VALORES_DE_SISTEMA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RUTA_PARA_ARCHIVOS_PLANOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RUTA_PARA_RESPALDOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BITACORA_DE_CAMBIOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CONSULTAS_SQL_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IMAGENES_DE_SISTEMA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CARGAR_ARCHIVO_EXCEL_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ACTUALIZAR_STOCK_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.INGRESO_DE_CREDITOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TRASPASO_DE_CREDITOS_A_HISTORICO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TRASPASAR_STOCK_FISICO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.REVISAR_CAJAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CONFIGURACION_CORREO_DE_VENTAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CONFIGURACION_CORREO_DE_ADMINISTRACION_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CAMBIO_DE_CONTRASEÑA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MODIFICAR_CREDITOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MANTENCION_DE_PROPIEDADES_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FffffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MENU_MANTENEDORES_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CLIENTES_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.USUARIOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PROVEEDORES_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PRODUCTOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RETIRADORES_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FAMILIAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SUBFAMILIAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SUBFAMILIAS_2_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CUENTAS_CORRIENTES_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MARCAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PROVEEDORES_MAS_PEDIDOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TARJETAS_DE_PRESENTACION_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CONDICION_DE_VENTA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IMAGENES_DE_PRODUCTOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.REGISTRO_DE_HARDWARE_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LISTADOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ASOCIAR_CLIENTES_A_EMPRESAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IMAGENES_DE_PRODUCTOS_PARA_PUBLICIDAD_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MENU_VENTAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VENTAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ENVIAR_COTIZACION_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CARTOLA_KARDEX_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.COMISION_VENDEDORES_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.COMISION_POR_SERVICIOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.COTIZACION_FORMAL_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CAMBIO_DE_PRODUCTOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MIS_DOCUMENTOS_EMITIDOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TICKET_DE_VENTAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AUTORIZACIONES_DE_VENTAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VENTAS_ASISTIDAS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BUSCADOR_DE_PRODUCTOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ADMINISTRAR_SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CALCULADORA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RECEPCION_DE_TRABAJO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LISTADO_DE_VALES_DE_CAMBIO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ESTADISTICAS_DE_VENTA_POR_PRODUCTOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.COMISIONES_POR_VENDEDOR_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BUSCAR_DOCUMENTO_DE_CAMBIO_DE_PRODUCTO_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TARJETA_DE_PRESENTACION_RAPIDA_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PRODUCTOSPAGINAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PRODUCTOS_CON_MAS_MOVIMIENTOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.Panel_pie.SuspendLayout()
        CType(Me.grilla_conexiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer_hora
        '
        Me.Timer_hora.Interval = 1000
        '
        'Timer_inactividad_menu
        '
        '
        'lbl_uc
        '
        Me.lbl_uc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_uc.AutoSize = True
        Me.lbl_uc.BackColor = System.Drawing.Color.Transparent
        Me.lbl_uc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_uc.Location = New System.Drawing.Point(830, 106)
        Me.lbl_uc.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_uc.Name = "lbl_uc"
        Me.lbl_uc.Size = New System.Drawing.Size(160, 16)
        Me.lbl_uc.TabIndex = 244
        Me.lbl_uc.Text = "USUARIO CONECTADO:"
        Me.lbl_uc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_pie
        '
        Me.lbl_pie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_pie.BackColor = System.Drawing.Color.Transparent
        Me.lbl_pie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pie.Location = New System.Drawing.Point(20, 27)
        Me.lbl_pie.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_pie.Name = "lbl_pie"
        Me.lbl_pie.Size = New System.Drawing.Size(976, 19)
        Me.lbl_pie.TabIndex = 249
        Me.lbl_pie.Text = "."
        Me.lbl_pie.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.AutoSize = True
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_mensaje.Location = New System.Drawing.Point(1, 91)
        Me.lbl_mensaje.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(464, 37)
        Me.lbl_mensaje.TabIndex = 233
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.Visible = False
        '
        'dtp_fecha
        '
        Me.dtp_fecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha.Enabled = False
        Me.dtp_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha.Location = New System.Drawing.Point(460, 38)
        Me.dtp_fecha.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(111, 24)
        Me.dtp_fecha.TabIndex = 250
        '
        'lbl_hora
        '
        Me.lbl_hora.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_hora.BackColor = System.Drawing.Color.Transparent
        Me.lbl_hora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_hora.Location = New System.Drawing.Point(930, 173)
        Me.lbl_hora.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_hora.Name = "lbl_hora"
        Me.lbl_hora.Size = New System.Drawing.Size(60, 16)
        Me.lbl_hora.TabIndex = 247
        Me.lbl_hora.Text = "00:00:00"
        Me.lbl_hora.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_fecha
        '
        Me.lbl_fecha.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.BackColor = System.Drawing.Color.Transparent
        Me.lbl_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fecha.Location = New System.Drawing.Point(788, 150)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(202, 16)
        Me.lbl_fecha.TabIndex = 246
        Me.lbl_fecha.Text = "Miercoles 06 de Agosto del 2014"
        Me.lbl_fecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_usuario_conectado
        '
        Me.lbl_usuario_conectado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_usuario_conectado.AutoSize = True
        Me.lbl_usuario_conectado.BackColor = System.Drawing.Color.Transparent
        Me.lbl_usuario_conectado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_usuario_conectado.Location = New System.Drawing.Point(978, 128)
        Me.lbl_usuario_conectado.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_usuario_conectado.Name = "lbl_usuario_conectado"
        Me.lbl_usuario_conectado.Size = New System.Drawing.Size(12, 16)
        Me.lbl_usuario_conectado.TabIndex = 245
        Me.lbl_usuario_conectado.Text = "-"
        Me.lbl_usuario_conectado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_soporte_remoto
        '
        Me.lbl_soporte_remoto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_soporte_remoto.AutoSize = True
        Me.lbl_soporte_remoto.BackColor = System.Drawing.Color.Transparent
        Me.lbl_soporte_remoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_soporte_remoto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbl_soporte_remoto.Location = New System.Drawing.Point(777, 84)
        Me.lbl_soporte_remoto.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_soporte_remoto.Name = "lbl_soporte_remoto"
        Me.lbl_soporte_remoto.Size = New System.Drawing.Size(213, 16)
        Me.lbl_soporte_remoto.TabIndex = 103
        Me.lbl_soporte_remoto.Text = "SOPORTE REMOTO, CLICK AQUI"
        Me.lbl_soporte_remoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel_pie
        '
        Me.Panel_pie.Controls.Add(Me.lbl_contacto)
        Me.Panel_pie.Controls.Add(Me.lbl_pie)
        Me.Panel_pie.Location = New System.Drawing.Point(0, 600)
        Me.Panel_pie.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel_pie.Name = "Panel_pie"
        Me.Panel_pie.Size = New System.Drawing.Size(1018, 100)
        Me.Panel_pie.TabIndex = 252
        '
        'lbl_contacto
        '
        Me.lbl_contacto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_contacto.BackColor = System.Drawing.Color.Transparent
        Me.lbl_contacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_contacto.Location = New System.Drawing.Point(19, 56)
        Me.lbl_contacto.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_contacto.Name = "lbl_contacto"
        Me.lbl_contacto.Size = New System.Drawing.Size(976, 19)
        Me.lbl_contacto.TabIndex = 253
        Me.lbl_contacto.Text = "DESARROLLADO POR CLICK OFFICE • CONTACTO@CLICKOFFICE.CL"
        Me.lbl_contacto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grilla_conexiones
        '
        Me.grilla_conexiones.AllowUserToAddRows = False
        Me.grilla_conexiones.AllowUserToDeleteRows = False
        Me.grilla_conexiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_conexiones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grilla_conexiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_conexiones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.Column2, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.Column1})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla_conexiones.DefaultCellStyle = DataGridViewCellStyle2
        Me.grilla_conexiones.Location = New System.Drawing.Point(400, 3400)
        Me.grilla_conexiones.Name = "grilla_conexiones"
        Me.grilla_conexiones.ReadOnly = True
        Me.grilla_conexiones.Size = New System.Drawing.Size(964, 200)
        Me.grilla_conexiones.TabIndex = 264
        Me.grilla_conexiones.TabStop = False
        Me.grilla_conexiones.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "SERVIDOR"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "REMOTO"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "BD"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "CLAVE"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "USUARIO"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "RECINTO"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "EMPRESA"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "TIPO"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'lbl_version
        '
        Me.lbl_version.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_version.BackColor = System.Drawing.Color.Transparent
        Me.lbl_version.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_version.Location = New System.Drawing.Point(1500, 1500)
        Me.lbl_version.Name = "lbl_version"
        Me.lbl_version.Size = New System.Drawing.Size(99, 12)
        Me.lbl_version.TabIndex = 283
        Me.lbl_version.Text = "VERSION 1.0.0.0"
        Me.lbl_version.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MENU_ADQUISICIONES_ToolStripMenuItem, Me.MENU_ADMINISTRACION_ToolStripMenuItem, Me.MENU_BODEGA_ToolStripMenuItem, Me.MENU_CONFIGURACION_ToolStripMenuItem, Me.MENU_MANTENEDORES_ToolStripMenuItem, Me.MENU_VENTAS_ToolStripMenuItem})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1018, 65)
        Me.MenuStrip1.Stretch = False
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MENU_ADQUISICIONES_ToolStripMenuItem
        '
        Me.MENU_ADQUISICIONES_ToolStripMenuItem.AutoSize = False
        Me.MENU_ADQUISICIONES_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.STOCK_MINIMO_ToolStripMenuItem, Me.REALIZAR_PEDIDOS_ToolStripMenuItem, Me.MIS_PEDIDOS_ToolStripMenuItem, Me.CONFIRMACION_DE_LLEGADA_ToolStripMenuItem, Me.REVISION_DE_PEDIDOS_ToolStripMenuItem, Me.RESERVAS_ToolStripMenuItem, Me.ORDENES_DE_COMPRA_ToolStripMenuItem, Me.CENTRAL_DE_COSTOS_ToolStripMenuItem, Me.PEDIDOS_OR_ToolStripMenuItem})
        Me.MENU_ADQUISICIONES_ToolStripMenuItem.Image = CType(resources.GetObject("MENU_ADQUISICIONES_ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MENU_ADQUISICIONES_ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MENU_ADQUISICIONES_ToolStripMenuItem.Name = "MENU_ADQUISICIONES_ToolStripMenuItem"
        Me.MENU_ADQUISICIONES_ToolStripMenuItem.Size = New System.Drawing.Size(168, 70)
        Me.MENU_ADQUISICIONES_ToolStripMenuItem.Text = "ADQUISICIONES"
        Me.MENU_ADQUISICIONES_ToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'STOCK_MINIMO_ToolStripMenuItem
        '
        Me.STOCK_MINIMO_ToolStripMenuItem.Name = "STOCK_MINIMO_ToolStripMenuItem"
        Me.STOCK_MINIMO_ToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.STOCK_MINIMO_ToolStripMenuItem.Text = "STOCK MINIMO"
        '
        'REALIZAR_PEDIDOS_ToolStripMenuItem
        '
        Me.REALIZAR_PEDIDOS_ToolStripMenuItem.Name = "REALIZAR_PEDIDOS_ToolStripMenuItem"
        Me.REALIZAR_PEDIDOS_ToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.REALIZAR_PEDIDOS_ToolStripMenuItem.Text = "REALIZAR PEDIDOS"
        '
        'MIS_PEDIDOS_ToolStripMenuItem
        '
        Me.MIS_PEDIDOS_ToolStripMenuItem.Name = "MIS_PEDIDOS_ToolStripMenuItem"
        Me.MIS_PEDIDOS_ToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.MIS_PEDIDOS_ToolStripMenuItem.Text = "MIS PEDIDOS"
        '
        'CONFIRMACION_DE_LLEGADA_ToolStripMenuItem
        '
        Me.CONFIRMACION_DE_LLEGADA_ToolStripMenuItem.Name = "CONFIRMACION_DE_LLEGADA_ToolStripMenuItem"
        Me.CONFIRMACION_DE_LLEGADA_ToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.CONFIRMACION_DE_LLEGADA_ToolStripMenuItem.Text = "CONFIRMACION DE LLEGADA"
        '
        'REVISION_DE_PEDIDOS_ToolStripMenuItem
        '
        Me.REVISION_DE_PEDIDOS_ToolStripMenuItem.Name = "REVISION_DE_PEDIDOS_ToolStripMenuItem"
        Me.REVISION_DE_PEDIDOS_ToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.REVISION_DE_PEDIDOS_ToolStripMenuItem.Text = "REVISION DE PEDIDOS"
        '
        'RESERVAS_ToolStripMenuItem
        '
        Me.RESERVAS_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.REALIZAR_RESERVA_ToolStripMenuItem, Me.MIS_RESERVAS_ToolStripMenuItem})
        Me.RESERVAS_ToolStripMenuItem.Name = "RESERVAS_ToolStripMenuItem"
        Me.RESERVAS_ToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.RESERVAS_ToolStripMenuItem.Text = "RESERVAS"
        '
        'REALIZAR_RESERVA_ToolStripMenuItem
        '
        Me.REALIZAR_RESERVA_ToolStripMenuItem.Name = "REALIZAR_RESERVA_ToolStripMenuItem"
        Me.REALIZAR_RESERVA_ToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.REALIZAR_RESERVA_ToolStripMenuItem.Text = "REALIZAR RESERVA"
        '
        'MIS_RESERVAS_ToolStripMenuItem
        '
        Me.MIS_RESERVAS_ToolStripMenuItem.Name = "MIS_RESERVAS_ToolStripMenuItem"
        Me.MIS_RESERVAS_ToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.MIS_RESERVAS_ToolStripMenuItem.Text = "MIS RESERVAS"
        '
        'ORDENES_DE_COMPRA_ToolStripMenuItem
        '
        Me.ORDENES_DE_COMPRA_ToolStripMenuItem.Name = "ORDENES_DE_COMPRA_ToolStripMenuItem"
        Me.ORDENES_DE_COMPRA_ToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.ORDENES_DE_COMPRA_ToolStripMenuItem.Text = "ORDENES DE COMPRA"
        '
        'CENTRAL_DE_COSTOS_ToolStripMenuItem
        '
        Me.CENTRAL_DE_COSTOS_ToolStripMenuItem.Name = "CENTRAL_DE_COSTOS_ToolStripMenuItem"
        Me.CENTRAL_DE_COSTOS_ToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.CENTRAL_DE_COSTOS_ToolStripMenuItem.Text = "CENTRAL DE COSTOS"
        '
        'PEDIDOS_OR_ToolStripMenuItem
        '
        Me.PEDIDOS_OR_ToolStripMenuItem.Name = "PEDIDOS_OR_ToolStripMenuItem"
        Me.PEDIDOS_OR_ToolStripMenuItem.Size = New System.Drawing.Size(264, 22)
        Me.PEDIDOS_OR_ToolStripMenuItem.Text = "PEDIDOS OR"
        '
        'MENU_ADMINISTRACION_ToolStripMenuItem
        '
        Me.MENU_ADMINISTRACION_ToolStripMenuItem.AutoSize = False
        Me.MENU_ADMINISTRACION_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FACTURACION_ToolStripMenuItem, Me.CORREGIR_DOCUMENTOS_ToolStripMenuItem, Me.OPCIONES_DE_CAJA_ToolStripMenuItem, Me.REGISTRO_DE_FACTURAS_ToolStripMenuItem, Me.ESTADISTICAS_ToolStripMenuItem, Me.BUSCAR_FACTURAS_ToolStripMenuItem, Me.REPORTE_LIBRO_DE_COMPRAS_ToolStripMenuItem, Me.LIBRO_DE_COMPRAS_ToolStripMenuItem, Me.LIBRO_DE_VENTAS_ToolStripMenuItem, Me.BUSCAR_TOTALES_ToolStripMenuItem, Me.CORREGIR_NUMEROS_DE_IMPRESION_ToolStripMenuItem, Me.INGRESO_MANUAL_DE_VENTAS_ToolStripMenuItem, Me.NOTAS_DE_CREDITO_ToolStripMenuItem, Me.TRASPASO_DE_STOCK_ToolStripMenuItem, Me.DETALLE_DE_VENTAS_ToolStripMenuItem, Me.DETALLE_DE_VENTAS_POR_DOCUMENTO_ToolStripMenuItem, Me.CUENTAS_POR_COBRAR_ToolStripMenuItem, Me.NOTAS_DE_DEBITO_ToolStripMenuItem, Me.ESTADO_DE_DEUDAS_ToolStripMenuItem, Me.HOJAS_FOLIADAS_ToolStripMenuItem, Me.LISTADO_DE_CLIENTES_CON_PAGARE_ToolStripMenuItem, Me.SALIDA_DE_TRABAJADORES_ToolStripMenuItem, Me.REGISTRODEFACTURASDEUDAToolStripMenuItem, Me.LIBRO_DE_COMPRAS_IMPRESION_ToolStripMenuItem})
        Me.MENU_ADMINISTRACION_ToolStripMenuItem.Image = CType(resources.GetObject("MENU_ADMINISTRACION_ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MENU_ADMINISTRACION_ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MENU_ADMINISTRACION_ToolStripMenuItem.Name = "MENU_ADMINISTRACION_ToolStripMenuItem"
        Me.MENU_ADMINISTRACION_ToolStripMenuItem.Size = New System.Drawing.Size(94, 70)
        Me.MENU_ADMINISTRACION_ToolStripMenuItem.Text = "ADMINISTRACION"
        Me.MENU_ADMINISTRACION_ToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'FACTURACION_ToolStripMenuItem
        '
        Me.FACTURACION_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FACTURACION_POR_RANGOS_ToolStripMenuItem, Me.FACTURACION_MANUAL_ToolStripMenuItem})
        Me.FACTURACION_ToolStripMenuItem.Name = "FACTURACION_ToolStripMenuItem"
        Me.FACTURACION_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.FACTURACION_ToolStripMenuItem.Text = "FACTURACION"
        '
        'FACTURACION_POR_RANGOS_ToolStripMenuItem
        '
        Me.FACTURACION_POR_RANGOS_ToolStripMenuItem.Name = "FACTURACION_POR_RANGOS_ToolStripMenuItem"
        Me.FACTURACION_POR_RANGOS_ToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.FACTURACION_POR_RANGOS_ToolStripMenuItem.Text = "FACTURACION POR RANGOS"
        '
        'FACTURACION_MANUAL_ToolStripMenuItem
        '
        Me.FACTURACION_MANUAL_ToolStripMenuItem.Name = "FACTURACION_MANUAL_ToolStripMenuItem"
        Me.FACTURACION_MANUAL_ToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.FACTURACION_MANUAL_ToolStripMenuItem.Text = "FACTURACION MANUAL"
        '
        'CORREGIR_DOCUMENTOS_ToolStripMenuItem
        '
        Me.CORREGIR_DOCUMENTOS_ToolStripMenuItem.Name = "CORREGIR_DOCUMENTOS_ToolStripMenuItem"
        Me.CORREGIR_DOCUMENTOS_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.CORREGIR_DOCUMENTOS_ToolStripMenuItem.Text = "CORREGIR DOCUMENTOS"
        '
        'OPCIONES_DE_CAJA_ToolStripMenuItem
        '
        Me.OPCIONES_DE_CAJA_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CUADRATURA_DE_CAJA_ToolStripMenuItem, Me.DETALLE_DE_ABONOS_ToolStripMenuItem, Me.LISTADO_DE_DOCUMENTOS_NULOS_ToolStripMenuItem, Me.LISTADO_DE_ABONOS_PARA_CAJA_ToolStripMenuItem, Me.REGISTRO_DE_CHEQUES_ToolStripMenuItem, Me.CAJA_REGISTRADORA_ToolStripMenuItem, Me.RESUMEN_DE_CUADRATURA_CAJA_ToolStripMenuItem, Me.LISTADO_DE_EGRESOS_ToolStripMenuItem, Me.CUADRATURA_FIN_DE_MES_ToolStripMenuItem, Me.SUELDOS_POR_CAJA_ToolStripMenuItem, Me.ANTICIPOS_Y_SUELDOS_JEFE_LOCAL_ToolStripMenuItem, Me.FONDO_DE_SUELDOS_ToolStripMenuItem, Me.DOCUMENTOS_CON_PAGOS_COMBINADOS_ToolStripMenuItem})
        Me.OPCIONES_DE_CAJA_ToolStripMenuItem.Name = "OPCIONES_DE_CAJA_ToolStripMenuItem"
        Me.OPCIONES_DE_CAJA_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.OPCIONES_DE_CAJA_ToolStripMenuItem.Text = "OPCIONES DE CAJA"
        '
        'CUADRATURA_DE_CAJA_ToolStripMenuItem
        '
        Me.CUADRATURA_DE_CAJA_ToolStripMenuItem.Name = "CUADRATURA_DE_CAJA_ToolStripMenuItem"
        Me.CUADRATURA_DE_CAJA_ToolStripMenuItem.Size = New System.Drawing.Size(348, 22)
        Me.CUADRATURA_DE_CAJA_ToolStripMenuItem.Text = "CUADRATURA DE CAJA"
        '
        'DETALLE_DE_ABONOS_ToolStripMenuItem
        '
        Me.DETALLE_DE_ABONOS_ToolStripMenuItem.Name = "DETALLE_DE_ABONOS_ToolStripMenuItem"
        Me.DETALLE_DE_ABONOS_ToolStripMenuItem.Size = New System.Drawing.Size(348, 22)
        Me.DETALLE_DE_ABONOS_ToolStripMenuItem.Text = "DETALLE DE ABONOS"
        '
        'LISTADO_DE_DOCUMENTOS_NULOS_ToolStripMenuItem
        '
        Me.LISTADO_DE_DOCUMENTOS_NULOS_ToolStripMenuItem.Name = "LISTADO_DE_DOCUMENTOS_NULOS_ToolStripMenuItem"
        Me.LISTADO_DE_DOCUMENTOS_NULOS_ToolStripMenuItem.Size = New System.Drawing.Size(348, 22)
        Me.LISTADO_DE_DOCUMENTOS_NULOS_ToolStripMenuItem.Text = "LISTADO DE DOCUMENTOS NULOS"
        '
        'LISTADO_DE_ABONOS_PARA_CAJA_ToolStripMenuItem
        '
        Me.LISTADO_DE_ABONOS_PARA_CAJA_ToolStripMenuItem.Name = "LISTADO_DE_ABONOS_PARA_CAJA_ToolStripMenuItem"
        Me.LISTADO_DE_ABONOS_PARA_CAJA_ToolStripMenuItem.Size = New System.Drawing.Size(348, 22)
        Me.LISTADO_DE_ABONOS_PARA_CAJA_ToolStripMenuItem.Text = "LISTADO DE ABONOS PARA CAJA"
        '
        'REGISTRO_DE_CHEQUES_ToolStripMenuItem
        '
        Me.REGISTRO_DE_CHEQUES_ToolStripMenuItem.Name = "REGISTRO_DE_CHEQUES_ToolStripMenuItem"
        Me.REGISTRO_DE_CHEQUES_ToolStripMenuItem.Size = New System.Drawing.Size(348, 22)
        Me.REGISTRO_DE_CHEQUES_ToolStripMenuItem.Text = "REGISTRO DE CHEQUES"
        '
        'CAJA_REGISTRADORA_ToolStripMenuItem
        '
        Me.CAJA_REGISTRADORA_ToolStripMenuItem.Name = "CAJA_REGISTRADORA_ToolStripMenuItem"
        Me.CAJA_REGISTRADORA_ToolStripMenuItem.Size = New System.Drawing.Size(348, 22)
        Me.CAJA_REGISTRADORA_ToolStripMenuItem.Text = "CAJA REGISTRADORA"
        '
        'RESUMEN_DE_CUADRATURA_CAJA_ToolStripMenuItem
        '
        Me.RESUMEN_DE_CUADRATURA_CAJA_ToolStripMenuItem.Name = "RESUMEN_DE_CUADRATURA_CAJA_ToolStripMenuItem"
        Me.RESUMEN_DE_CUADRATURA_CAJA_ToolStripMenuItem.Size = New System.Drawing.Size(348, 22)
        Me.RESUMEN_DE_CUADRATURA_CAJA_ToolStripMenuItem.Text = "RESUMEN  DE CUADRATURA CAJA"
        '
        'LISTADO_DE_EGRESOS_ToolStripMenuItem
        '
        Me.LISTADO_DE_EGRESOS_ToolStripMenuItem.Name = "LISTADO_DE_EGRESOS_ToolStripMenuItem"
        Me.LISTADO_DE_EGRESOS_ToolStripMenuItem.Size = New System.Drawing.Size(348, 22)
        Me.LISTADO_DE_EGRESOS_ToolStripMenuItem.Text = "LISTADO DE EGRESOS"
        '
        'CUADRATURA_FIN_DE_MES_ToolStripMenuItem
        '
        Me.CUADRATURA_FIN_DE_MES_ToolStripMenuItem.Name = "CUADRATURA_FIN_DE_MES_ToolStripMenuItem"
        Me.CUADRATURA_FIN_DE_MES_ToolStripMenuItem.Size = New System.Drawing.Size(348, 22)
        Me.CUADRATURA_FIN_DE_MES_ToolStripMenuItem.Text = "CUADRATURA FIN DE MES"
        '
        'SUELDOS_POR_CAJA_ToolStripMenuItem
        '
        Me.SUELDOS_POR_CAJA_ToolStripMenuItem.Name = "SUELDOS_POR_CAJA_ToolStripMenuItem"
        Me.SUELDOS_POR_CAJA_ToolStripMenuItem.Size = New System.Drawing.Size(348, 22)
        Me.SUELDOS_POR_CAJA_ToolStripMenuItem.Text = "SUELDOS POR CAJA"
        '
        'ANTICIPOS_Y_SUELDOS_JEFE_LOCAL_ToolStripMenuItem
        '
        Me.ANTICIPOS_Y_SUELDOS_JEFE_LOCAL_ToolStripMenuItem.Name = "ANTICIPOS_Y_SUELDOS_JEFE_LOCAL_ToolStripMenuItem"
        Me.ANTICIPOS_Y_SUELDOS_JEFE_LOCAL_ToolStripMenuItem.Size = New System.Drawing.Size(348, 22)
        Me.ANTICIPOS_Y_SUELDOS_JEFE_LOCAL_ToolStripMenuItem.Text = "ANTICIPOS Y SUELDOS JEFE DE LOCAL"
        '
        'FONDO_DE_SUELDOS_ToolStripMenuItem
        '
        Me.FONDO_DE_SUELDOS_ToolStripMenuItem.Name = "FONDO_DE_SUELDOS_ToolStripMenuItem"
        Me.FONDO_DE_SUELDOS_ToolStripMenuItem.Size = New System.Drawing.Size(348, 22)
        Me.FONDO_DE_SUELDOS_ToolStripMenuItem.Text = "FONDO DE SUELDOS"
        '
        'DOCUMENTOS_CON_PAGOS_COMBINADOS_ToolStripMenuItem
        '
        Me.DOCUMENTOS_CON_PAGOS_COMBINADOS_ToolStripMenuItem.Name = "DOCUMENTOS_CON_PAGOS_COMBINADOS_ToolStripMenuItem"
        Me.DOCUMENTOS_CON_PAGOS_COMBINADOS_ToolStripMenuItem.Size = New System.Drawing.Size(348, 22)
        Me.DOCUMENTOS_CON_PAGOS_COMBINADOS_ToolStripMenuItem.Text = "DOCUMENTOS CON PAGOS COMBINADOS"
        '
        'REGISTRO_DE_FACTURAS_ToolStripMenuItem
        '
        Me.REGISTRO_DE_FACTURAS_ToolStripMenuItem.Name = "REGISTRO_DE_FACTURAS_ToolStripMenuItem"
        Me.REGISTRO_DE_FACTURAS_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.REGISTRO_DE_FACTURAS_ToolStripMenuItem.Text = "REGISTRO DE FACTURAS"
        '
        'ESTADISTICAS_ToolStripMenuItem
        '
        Me.ESTADISTICAS_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VENTAS_DEL_DIA_ToolStripMenuItem, Me.VENTAS_DE_LA_SEMANA_ToolStripMenuItem, Me.VENTAS_SEGUN_VENDEDOR_ToolStripMenuItem})
        Me.ESTADISTICAS_ToolStripMenuItem.Name = "ESTADISTICAS_ToolStripMenuItem"
        Me.ESTADISTICAS_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.ESTADISTICAS_ToolStripMenuItem.Text = "ESTADISTICAS"
        Me.ESTADISTICAS_ToolStripMenuItem.Visible = False
        '
        'VENTAS_DEL_DIA_ToolStripMenuItem
        '
        Me.VENTAS_DEL_DIA_ToolStripMenuItem.Name = "VENTAS_DEL_DIA_ToolStripMenuItem"
        Me.VENTAS_DEL_DIA_ToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.VENTAS_DEL_DIA_ToolStripMenuItem.Text = "VENTAS DEL DIA"
        '
        'VENTAS_DE_LA_SEMANA_ToolStripMenuItem
        '
        Me.VENTAS_DE_LA_SEMANA_ToolStripMenuItem.Name = "VENTAS_DE_LA_SEMANA_ToolStripMenuItem"
        Me.VENTAS_DE_LA_SEMANA_ToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.VENTAS_DE_LA_SEMANA_ToolStripMenuItem.Text = "VENTAS DE LA SEMANA"
        '
        'VENTAS_SEGUN_VENDEDOR_ToolStripMenuItem
        '
        Me.VENTAS_SEGUN_VENDEDOR_ToolStripMenuItem.Name = "VENTAS_SEGUN_VENDEDOR_ToolStripMenuItem"
        Me.VENTAS_SEGUN_VENDEDOR_ToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.VENTAS_SEGUN_VENDEDOR_ToolStripMenuItem.Text = "VENTAS SEGUN VENDEDOR"
        '
        'BUSCAR_FACTURAS_ToolStripMenuItem
        '
        Me.BUSCAR_FACTURAS_ToolStripMenuItem.Name = "BUSCAR_FACTURAS_ToolStripMenuItem"
        Me.BUSCAR_FACTURAS_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.BUSCAR_FACTURAS_ToolStripMenuItem.Text = "BUSCAR FACTURAS"
        '
        'REPORTE_LIBRO_DE_COMPRAS_ToolStripMenuItem
        '
        Me.REPORTE_LIBRO_DE_COMPRAS_ToolStripMenuItem.Name = "REPORTE_LIBRO_DE_COMPRAS_ToolStripMenuItem"
        Me.REPORTE_LIBRO_DE_COMPRAS_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.REPORTE_LIBRO_DE_COMPRAS_ToolStripMenuItem.Text = "REPORTE LIBRO DE COMPRAS"
        '
        'LIBRO_DE_COMPRAS_ToolStripMenuItem
        '
        Me.LIBRO_DE_COMPRAS_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.REVISAR_ARCHIVO_SII_ToolStripMenuItem})
        Me.LIBRO_DE_COMPRAS_ToolStripMenuItem.Name = "LIBRO_DE_COMPRAS_ToolStripMenuItem"
        Me.LIBRO_DE_COMPRAS_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.LIBRO_DE_COMPRAS_ToolStripMenuItem.Text = "LIBRO DE COMPRAS"
        '
        'REVISAR_ARCHIVO_SII_ToolStripMenuItem
        '
        Me.REVISAR_ARCHIVO_SII_ToolStripMenuItem.Name = "REVISAR_ARCHIVO_SII_ToolStripMenuItem"
        Me.REVISAR_ARCHIVO_SII_ToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.REVISAR_ARCHIVO_SII_ToolStripMenuItem.Text = "REVISAR ARCHIVO SII"
        '
        'LIBRO_DE_VENTAS_ToolStripMenuItem
        '
        Me.LIBRO_DE_VENTAS_ToolStripMenuItem.Name = "LIBRO_DE_VENTAS_ToolStripMenuItem"
        Me.LIBRO_DE_VENTAS_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.LIBRO_DE_VENTAS_ToolStripMenuItem.Text = "LIBRO DE VENTAS"
        '
        'BUSCAR_TOTALES_ToolStripMenuItem
        '
        Me.BUSCAR_TOTALES_ToolStripMenuItem.Name = "BUSCAR_TOTALES_ToolStripMenuItem"
        Me.BUSCAR_TOTALES_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.BUSCAR_TOTALES_ToolStripMenuItem.Text = "BUSCAR TOTALES"
        '
        'CORREGIR_NUMEROS_DE_IMPRESION_ToolStripMenuItem
        '
        Me.CORREGIR_NUMEROS_DE_IMPRESION_ToolStripMenuItem.Name = "CORREGIR_NUMEROS_DE_IMPRESION_ToolStripMenuItem"
        Me.CORREGIR_NUMEROS_DE_IMPRESION_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.CORREGIR_NUMEROS_DE_IMPRESION_ToolStripMenuItem.Text = "CORREGIR NUMEROS DE IMPRESION"
        '
        'INGRESO_MANUAL_DE_VENTAS_ToolStripMenuItem
        '
        Me.INGRESO_MANUAL_DE_VENTAS_ToolStripMenuItem.Name = "INGRESO_MANUAL_DE_VENTAS_ToolStripMenuItem"
        Me.INGRESO_MANUAL_DE_VENTAS_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.INGRESO_MANUAL_DE_VENTAS_ToolStripMenuItem.Text = "INGRESO MANUAL DE VENTAS"
        '
        'NOTAS_DE_CREDITO_ToolStripMenuItem
        '
        Me.NOTAS_DE_CREDITO_ToolStripMenuItem.Name = "NOTAS_DE_CREDITO_ToolStripMenuItem"
        Me.NOTAS_DE_CREDITO_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.NOTAS_DE_CREDITO_ToolStripMenuItem.Text = "NOTAS DE CREDITO"
        '
        'TRASPASO_DE_STOCK_ToolStripMenuItem
        '
        Me.TRASPASO_DE_STOCK_ToolStripMenuItem.Name = "TRASPASO_DE_STOCK_ToolStripMenuItem"
        Me.TRASPASO_DE_STOCK_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.TRASPASO_DE_STOCK_ToolStripMenuItem.Text = "TRASPASO DE STOCK"
        '
        'DETALLE_DE_VENTAS_ToolStripMenuItem
        '
        Me.DETALLE_DE_VENTAS_ToolStripMenuItem.Name = "DETALLE_DE_VENTAS_ToolStripMenuItem"
        Me.DETALLE_DE_VENTAS_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.DETALLE_DE_VENTAS_ToolStripMenuItem.Text = "DETALLE VENTAS"
        '
        'DETALLE_DE_VENTAS_POR_DOCUMENTO_ToolStripMenuItem
        '
        Me.DETALLE_DE_VENTAS_POR_DOCUMENTO_ToolStripMenuItem.Name = "DETALLE_DE_VENTAS_POR_DOCUMENTO_ToolStripMenuItem"
        Me.DETALLE_DE_VENTAS_POR_DOCUMENTO_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.DETALLE_DE_VENTAS_POR_DOCUMENTO_ToolStripMenuItem.Text = "DETALLE VENTAS POR DOCUMENTO"
        '
        'CUENTAS_POR_COBRAR_ToolStripMenuItem
        '
        Me.CUENTAS_POR_COBRAR_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ESTADO_DE_CUENTA_ToolStripMenuItem, Me.ESTADO_DE_CUENTA_POR_RANGO_ToolStripMenuItem, Me.AGREGAR_ABONOS_ToolStripMenuItem, Me.AGREGAR_ABONOS_SIN_IMPUTAR_ToolStripMenuItem, Me.IMPUTAR_ABONOS_ToolStripMenuItem, Me.IMPUTAR_NOTAS_DE_CREDITO_ToolStripMenuItem, Me.DEUDORES_ToolStripMenuItem, Me.LISTADO_DE_ABONOS_ToolStripMenuItem, Me.LISTADO_DE_LETRAS_ToolStripMenuItem, Me.DETALLE_DE_CREDITOS_ToolStripMenuItem, Me.DETALLE_DE_VENTAS_CON_PIE_ToolStripMenuItem, Me.DETALLE_DE_VENTAS_PAGO_COMBINADO_ToolStripMenuItem, Me.ARCHIVO_DICOM_ToolStripMenuItem, Me.DEUDA_DE_CLIENTE_SEGUN_FECHA_ToolStripMenuItem, Me.HISTORICO_DE_CUENTASCORRIENTES_ToolStripMenuItem, Me.INGRESAR_CREDITOS_ToolStripMenuItem, Me.LISTADO_DE_INTERESES_Y_GASTOS_ToolStripMenuItem})
        Me.CUENTAS_POR_COBRAR_ToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.CUENTAS_POR_COBRAR_ToolStripMenuItem.Name = "CUENTAS_POR_COBRAR_ToolStripMenuItem"
        Me.CUENTAS_POR_COBRAR_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.CUENTAS_POR_COBRAR_ToolStripMenuItem.Text = "CUENTAS POR COBRAR"
        '
        'ESTADO_DE_CUENTA_ToolStripMenuItem
        '
        Me.ESTADO_DE_CUENTA_ToolStripMenuItem.Name = "ESTADO_DE_CUENTA_ToolStripMenuItem"
        Me.ESTADO_DE_CUENTA_ToolStripMenuItem.Size = New System.Drawing.Size(341, 22)
        Me.ESTADO_DE_CUENTA_ToolStripMenuItem.Text = "ESTADO DE CUENTA"
        '
        'ESTADO_DE_CUENTA_POR_RANGO_ToolStripMenuItem
        '
        Me.ESTADO_DE_CUENTA_POR_RANGO_ToolStripMenuItem.Name = "ESTADO_DE_CUENTA_POR_RANGO_ToolStripMenuItem"
        Me.ESTADO_DE_CUENTA_POR_RANGO_ToolStripMenuItem.Size = New System.Drawing.Size(341, 22)
        Me.ESTADO_DE_CUENTA_POR_RANGO_ToolStripMenuItem.Text = "ESTADO DE CUENTA POR RANGO"
        '
        'AGREGAR_ABONOS_ToolStripMenuItem
        '
        Me.AGREGAR_ABONOS_ToolStripMenuItem.Name = "AGREGAR_ABONOS_ToolStripMenuItem"
        Me.AGREGAR_ABONOS_ToolStripMenuItem.Size = New System.Drawing.Size(341, 22)
        Me.AGREGAR_ABONOS_ToolStripMenuItem.Text = "AGREGAR ABONOS"
        '
        'AGREGAR_ABONOS_SIN_IMPUTAR_ToolStripMenuItem
        '
        Me.AGREGAR_ABONOS_SIN_IMPUTAR_ToolStripMenuItem.Name = "AGREGAR_ABONOS_SIN_IMPUTAR_ToolStripMenuItem"
        Me.AGREGAR_ABONOS_SIN_IMPUTAR_ToolStripMenuItem.Size = New System.Drawing.Size(341, 22)
        Me.AGREGAR_ABONOS_SIN_IMPUTAR_ToolStripMenuItem.Text = "AGREGAR ABONOS SIN IMPUTAR"
        '
        'IMPUTAR_ABONOS_ToolStripMenuItem
        '
        Me.IMPUTAR_ABONOS_ToolStripMenuItem.Name = "IMPUTAR_ABONOS_ToolStripMenuItem"
        Me.IMPUTAR_ABONOS_ToolStripMenuItem.Size = New System.Drawing.Size(341, 22)
        Me.IMPUTAR_ABONOS_ToolStripMenuItem.Text = "IMPUTAR ABONOS"
        '
        'IMPUTAR_NOTAS_DE_CREDITO_ToolStripMenuItem
        '
        Me.IMPUTAR_NOTAS_DE_CREDITO_ToolStripMenuItem.Name = "IMPUTAR_NOTAS_DE_CREDITO_ToolStripMenuItem"
        Me.IMPUTAR_NOTAS_DE_CREDITO_ToolStripMenuItem.Size = New System.Drawing.Size(341, 22)
        Me.IMPUTAR_NOTAS_DE_CREDITO_ToolStripMenuItem.Text = "IMPUTAR NOTAS DE CREDITO"
        '
        'DEUDORES_ToolStripMenuItem
        '
        Me.DEUDORES_ToolStripMenuItem.Name = "DEUDORES_ToolStripMenuItem"
        Me.DEUDORES_ToolStripMenuItem.Size = New System.Drawing.Size(341, 22)
        Me.DEUDORES_ToolStripMenuItem.Text = "DEUDORES"
        '
        'LISTADO_DE_ABONOS_ToolStripMenuItem
        '
        Me.LISTADO_DE_ABONOS_ToolStripMenuItem.Name = "LISTADO_DE_ABONOS_ToolStripMenuItem"
        Me.LISTADO_DE_ABONOS_ToolStripMenuItem.Size = New System.Drawing.Size(341, 22)
        Me.LISTADO_DE_ABONOS_ToolStripMenuItem.Text = "LISTADO DE ABONOS"
        '
        'LISTADO_DE_LETRAS_ToolStripMenuItem
        '
        Me.LISTADO_DE_LETRAS_ToolStripMenuItem.Name = "LISTADO_DE_LETRAS_ToolStripMenuItem"
        Me.LISTADO_DE_LETRAS_ToolStripMenuItem.Size = New System.Drawing.Size(341, 22)
        Me.LISTADO_DE_LETRAS_ToolStripMenuItem.Text = "LISTADO DE LETRAS"
        '
        'DETALLE_DE_CREDITOS_ToolStripMenuItem
        '
        Me.DETALLE_DE_CREDITOS_ToolStripMenuItem.Name = "DETALLE_DE_CREDITOS_ToolStripMenuItem"
        Me.DETALLE_DE_CREDITOS_ToolStripMenuItem.Size = New System.Drawing.Size(341, 22)
        Me.DETALLE_DE_CREDITOS_ToolStripMenuItem.Text = "DETALLE DE CREDITOS"
        '
        'DETALLE_DE_VENTAS_CON_PIE_ToolStripMenuItem
        '
        Me.DETALLE_DE_VENTAS_CON_PIE_ToolStripMenuItem.Name = "DETALLE_DE_VENTAS_CON_PIE_ToolStripMenuItem"
        Me.DETALLE_DE_VENTAS_CON_PIE_ToolStripMenuItem.Size = New System.Drawing.Size(341, 22)
        Me.DETALLE_DE_VENTAS_CON_PIE_ToolStripMenuItem.Text = "DETALLE DE VENTAS CON PIE"
        '
        'DETALLE_DE_VENTAS_PAGO_COMBINADO_ToolStripMenuItem
        '
        Me.DETALLE_DE_VENTAS_PAGO_COMBINADO_ToolStripMenuItem.Name = "DETALLE_DE_VENTAS_PAGO_COMBINADO_ToolStripMenuItem"
        Me.DETALLE_DE_VENTAS_PAGO_COMBINADO_ToolStripMenuItem.Size = New System.Drawing.Size(341, 22)
        Me.DETALLE_DE_VENTAS_PAGO_COMBINADO_ToolStripMenuItem.Text = "DETALLE DE VENTAS PAGO COMBINADO"
        '
        'ARCHIVO_DICOM_ToolStripMenuItem
        '
        Me.ARCHIVO_DICOM_ToolStripMenuItem.Name = "ARCHIVO_DICOM_ToolStripMenuItem"
        Me.ARCHIVO_DICOM_ToolStripMenuItem.Size = New System.Drawing.Size(341, 22)
        Me.ARCHIVO_DICOM_ToolStripMenuItem.Text = "ARCHIVO DICOM"
        '
        'DEUDA_DE_CLIENTE_SEGUN_FECHA_ToolStripMenuItem
        '
        Me.DEUDA_DE_CLIENTE_SEGUN_FECHA_ToolStripMenuItem.Name = "DEUDA_DE_CLIENTE_SEGUN_FECHA_ToolStripMenuItem"
        Me.DEUDA_DE_CLIENTE_SEGUN_FECHA_ToolStripMenuItem.Size = New System.Drawing.Size(341, 22)
        Me.DEUDA_DE_CLIENTE_SEGUN_FECHA_ToolStripMenuItem.Text = "DEUDA DE CLIENTES SEGUN FECHA"
        '
        'HISTORICO_DE_CUENTASCORRIENTES_ToolStripMenuItem
        '
        Me.HISTORICO_DE_CUENTASCORRIENTES_ToolStripMenuItem.Name = "HISTORICO_DE_CUENTASCORRIENTES_ToolStripMenuItem"
        Me.HISTORICO_DE_CUENTASCORRIENTES_ToolStripMenuItem.Size = New System.Drawing.Size(341, 22)
        Me.HISTORICO_DE_CUENTASCORRIENTES_ToolStripMenuItem.Text = "HISTORICO DE CUENTAS CORRIENTES"
        '
        'INGRESAR_CREDITOS_ToolStripMenuItem
        '
        Me.INGRESAR_CREDITOS_ToolStripMenuItem.Name = "INGRESAR_CREDITOS_ToolStripMenuItem"
        Me.INGRESAR_CREDITOS_ToolStripMenuItem.Size = New System.Drawing.Size(341, 22)
        Me.INGRESAR_CREDITOS_ToolStripMenuItem.Text = "INGRESAR CREDITOS"
        '
        'LISTADO_DE_INTERESES_Y_GASTOS_ToolStripMenuItem
        '
        Me.LISTADO_DE_INTERESES_Y_GASTOS_ToolStripMenuItem.Name = "LISTADO_DE_INTERESES_Y_GASTOS_ToolStripMenuItem"
        Me.LISTADO_DE_INTERESES_Y_GASTOS_ToolStripMenuItem.Size = New System.Drawing.Size(341, 22)
        Me.LISTADO_DE_INTERESES_Y_GASTOS_ToolStripMenuItem.Text = "LISTADO DE INTERESES Y GASTOS"
        '
        'NOTAS_DE_DEBITO_ToolStripMenuItem
        '
        Me.NOTAS_DE_DEBITO_ToolStripMenuItem.Name = "NOTAS_DE_DEBITO_ToolStripMenuItem"
        Me.NOTAS_DE_DEBITO_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.NOTAS_DE_DEBITO_ToolStripMenuItem.Text = "NOTAS DE DEBITO"
        '
        'ESTADO_DE_DEUDAS_ToolStripMenuItem
        '
        Me.ESTADO_DE_DEUDAS_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DEUDA_CLIENTES_ToolStripMenuItem, Me.DEUDA_PROVEEDORES_ToolStripMenuItem, Me.CALCULAR_DEUDAS_DE_CLIENTES_ToolStripMenuItem})
        Me.ESTADO_DE_DEUDAS_ToolStripMenuItem.Name = "ESTADO_DE_DEUDAS_ToolStripMenuItem"
        Me.ESTADO_DE_DEUDAS_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.ESTADO_DE_DEUDAS_ToolStripMenuItem.Text = "ESTADO DE DEUDAS"
        '
        'DEUDA_CLIENTES_ToolStripMenuItem
        '
        Me.DEUDA_CLIENTES_ToolStripMenuItem.Name = "DEUDA_CLIENTES_ToolStripMenuItem"
        Me.DEUDA_CLIENTES_ToolStripMenuItem.Size = New System.Drawing.Size(296, 22)
        Me.DEUDA_CLIENTES_ToolStripMenuItem.Text = "DEUDA CLIENTES"
        '
        'DEUDA_PROVEEDORES_ToolStripMenuItem
        '
        Me.DEUDA_PROVEEDORES_ToolStripMenuItem.Name = "DEUDA_PROVEEDORES_ToolStripMenuItem"
        Me.DEUDA_PROVEEDORES_ToolStripMenuItem.Size = New System.Drawing.Size(296, 22)
        Me.DEUDA_PROVEEDORES_ToolStripMenuItem.Text = "DEUDA PROVEEDORES"
        '
        'CALCULAR_DEUDAS_DE_CLIENTES_ToolStripMenuItem
        '
        Me.CALCULAR_DEUDAS_DE_CLIENTES_ToolStripMenuItem.Name = "CALCULAR_DEUDAS_DE_CLIENTES_ToolStripMenuItem"
        Me.CALCULAR_DEUDAS_DE_CLIENTES_ToolStripMenuItem.Size = New System.Drawing.Size(296, 22)
        Me.CALCULAR_DEUDAS_DE_CLIENTES_ToolStripMenuItem.Text = "CALCULAR DEUDAS DE CLIENTES"
        '
        'HOJAS_FOLIADAS_ToolStripMenuItem
        '
        Me.HOJAS_FOLIADAS_ToolStripMenuItem.Name = "HOJAS_FOLIADAS_ToolStripMenuItem"
        Me.HOJAS_FOLIADAS_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.HOJAS_FOLIADAS_ToolStripMenuItem.Text = "HOJAS FOLIADAS"
        '
        'LISTADO_DE_CLIENTES_CON_PAGARE_ToolStripMenuItem
        '
        Me.LISTADO_DE_CLIENTES_CON_PAGARE_ToolStripMenuItem.Name = "LISTADO_DE_CLIENTES_CON_PAGARE_ToolStripMenuItem"
        Me.LISTADO_DE_CLIENTES_CON_PAGARE_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.LISTADO_DE_CLIENTES_CON_PAGARE_ToolStripMenuItem.Text = "LISTADO DE CLIENTES CON PAGARE"
        '
        'SALIDA_DE_TRABAJADORES_ToolStripMenuItem
        '
        Me.SALIDA_DE_TRABAJADORES_ToolStripMenuItem.Name = "SALIDA_DE_TRABAJADORES_ToolStripMenuItem"
        Me.SALIDA_DE_TRABAJADORES_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.SALIDA_DE_TRABAJADORES_ToolStripMenuItem.Text = "SALIDA DE TRABAJADORES"
        '
        'REGISTRODEFACTURASDEUDAToolStripMenuItem
        '
        Me.REGISTRODEFACTURASDEUDAToolStripMenuItem.Name = "REGISTRODEFACTURASDEUDAToolStripMenuItem"
        Me.REGISTRODEFACTURASDEUDAToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.REGISTRODEFACTURASDEUDAToolStripMenuItem.Text = "REGISTRO DE FACTURAS (DEUDA)"
        '
        'LIBRO_DE_COMPRAS_IMPRESION_ToolStripMenuItem
        '
        Me.LIBRO_DE_COMPRAS_IMPRESION_ToolStripMenuItem.Name = "LIBRO_DE_COMPRAS_IMPRESION_ToolStripMenuItem"
        Me.LIBRO_DE_COMPRAS_IMPRESION_ToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.LIBRO_DE_COMPRAS_IMPRESION_ToolStripMenuItem.Text = "LIBRO DE COMPRAS IMPRESION"
        '
        'MENU_BODEGA_ToolStripMenuItem
        '
        Me.MENU_BODEGA_ToolStripMenuItem.AutoSize = False
        Me.MENU_BODEGA_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.COMPRAS_ToolStripMenuItem, Me.ETIQUETAS_ToolStripMenuItem, Me.CODIGOS_DE_BARRA_ToolStripMenuItem, Me.TRASPASO_A_SUCURSAL_ToolStripMenuItem, Me.INVENTARIO_ToolStripMenuItem, Me.DETALLE_DE_COMPRAS_ToolStripMenuItem, Me.GUIAS_DE_TRASLADO_ToolStripMenuItem, Me.ASIGNAR_FAMILIAS_ToolStripMenuItem, Me.GUIAS_ACEPTADAS_ToolStripMenuItem, Me.EXISTENCIAS_ToolStripMenuItem, Me.REPOSICION_DE_VENTAS_ToolStripMenuItem, Me.STOCK_ACUMULADO_ToolStripMenuItem, Me.DETALLE_DE_ENVIOS_ToolStripMenuItem, Me.RESUMEN_DE_COMPRAS_Y_GUIAS_DE_TRASLADO_ToolStripMenuItem, Me.GUIAS_DE_TRASLADO_A_PROVEEDORES_ToolStripMenuItem, Me.CONSUMO_INTERNO_ToolStripMenuItem, Me.ENVIO_A_GARANTIA_ToolStripMenuItem, Me.RESUMEN_DE_COMPRAS_POR_PROVEEDOR_ToolStripMenuItem, Me.RESUMEN_DE_COMPRAS_POR_ITEM_ToolStripMenuItem, Me.RESUMEN_DE_ITEM_POR_GUIAS_ToolStripMenuItem, Me.CONTROL_DE_DESPACHOS_ToolStripMenuItem, Me.RESUMEN_DE_COMPRAS_POR_GUIAS_ToolStripMenuItem, Me.RESUMEN_DE_VENTAS_POR_ITEM_ToolStripMenuItem, Me.REPOSICION_ARANA_ToolStripMenuItem, Me.REVISION_DE_DESPACHOS_ToolStripMenuItem, Me.CONTEOS_ARANA_ToolStripMenuItem, Me.LISTADO_GUIAS_DE_GARANTIA_ToolStripMenuItem, Me.LISTADO_DE_PEDIDOS_ToolStripMenuItem, Me.VENTA_ESPERADA_POR_FAMILIA_ToolStripMenuItem, Me.INVENTARIO_DIARIO_ToolStripMenuItem, Me.REVISION_DE_STOCK_ToolStripMenuItem})
        Me.MENU_BODEGA_ToolStripMenuItem.Image = CType(resources.GetObject("MENU_BODEGA_ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MENU_BODEGA_ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MENU_BODEGA_ToolStripMenuItem.Name = "MENU_BODEGA_ToolStripMenuItem"
        Me.MENU_BODEGA_ToolStripMenuItem.Size = New System.Drawing.Size(94, 70)
        Me.MENU_BODEGA_ToolStripMenuItem.Text = "BODEGA F6"
        Me.MENU_BODEGA_ToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.MENU_BODEGA_ToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'COMPRAS_ToolStripMenuItem
        '
        Me.COMPRAS_ToolStripMenuItem.Name = "COMPRAS_ToolStripMenuItem"
        Me.COMPRAS_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.COMPRAS_ToolStripMenuItem.Text = "COMPRAS"
        '
        'ETIQUETAS_ToolStripMenuItem
        '
        Me.ETIQUETAS_ToolStripMenuItem.Name = "ETIQUETAS_ToolStripMenuItem"
        Me.ETIQUETAS_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.ETIQUETAS_ToolStripMenuItem.Text = "ETIQUETAS"
        '
        'CODIGOS_DE_BARRA_ToolStripMenuItem
        '
        Me.CODIGOS_DE_BARRA_ToolStripMenuItem.Name = "CODIGOS_DE_BARRA_ToolStripMenuItem"
        Me.CODIGOS_DE_BARRA_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.CODIGOS_DE_BARRA_ToolStripMenuItem.Text = "CODIGOS DE BARRA"
        '
        'TRASPASO_A_SUCURSAL_ToolStripMenuItem
        '
        Me.TRASPASO_A_SUCURSAL_ToolStripMenuItem.Name = "TRASPASO_A_SUCURSAL_ToolStripMenuItem"
        Me.TRASPASO_A_SUCURSAL_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.TRASPASO_A_SUCURSAL_ToolStripMenuItem.Text = "TRASPASO A SUCURSAL"
        '
        'INVENTARIO_ToolStripMenuItem
        '
        Me.INVENTARIO_ToolStripMenuItem.Name = "INVENTARIO_ToolStripMenuItem"
        Me.INVENTARIO_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.INVENTARIO_ToolStripMenuItem.Text = "INVENTARIO"
        '
        'DETALLE_DE_COMPRAS_ToolStripMenuItem
        '
        Me.DETALLE_DE_COMPRAS_ToolStripMenuItem.Name = "DETALLE_DE_COMPRAS_ToolStripMenuItem"
        Me.DETALLE_DE_COMPRAS_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.DETALLE_DE_COMPRAS_ToolStripMenuItem.Text = "DETALLE DE COMPRAS"
        '
        'GUIAS_DE_TRASLADO_ToolStripMenuItem
        '
        Me.GUIAS_DE_TRASLADO_ToolStripMenuItem.Name = "GUIAS_DE_TRASLADO_ToolStripMenuItem"
        Me.GUIAS_DE_TRASLADO_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.GUIAS_DE_TRASLADO_ToolStripMenuItem.Text = "GUIAS DE TRASLADO"
        '
        'ASIGNAR_FAMILIAS_ToolStripMenuItem
        '
        Me.ASIGNAR_FAMILIAS_ToolStripMenuItem.Name = "ASIGNAR_FAMILIAS_ToolStripMenuItem"
        Me.ASIGNAR_FAMILIAS_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.ASIGNAR_FAMILIAS_ToolStripMenuItem.Text = "ASIGNAR FAMILIAS"
        '
        'GUIAS_ACEPTADAS_ToolStripMenuItem
        '
        Me.GUIAS_ACEPTADAS_ToolStripMenuItem.Name = "GUIAS_ACEPTADAS_ToolStripMenuItem"
        Me.GUIAS_ACEPTADAS_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.GUIAS_ACEPTADAS_ToolStripMenuItem.Text = "GUIAS ACEPTADAS"
        '
        'EXISTENCIAS_ToolStripMenuItem
        '
        Me.EXISTENCIAS_ToolStripMenuItem.Name = "EXISTENCIAS_ToolStripMenuItem"
        Me.EXISTENCIAS_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.EXISTENCIAS_ToolStripMenuItem.Text = "EXISTENCIAS"
        '
        'REPOSICION_DE_VENTAS_ToolStripMenuItem
        '
        Me.REPOSICION_DE_VENTAS_ToolStripMenuItem.Name = "REPOSICION_DE_VENTAS_ToolStripMenuItem"
        Me.REPOSICION_DE_VENTAS_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.REPOSICION_DE_VENTAS_ToolStripMenuItem.Text = "REPOSICION DE VENTAS"
        '
        'STOCK_ACUMULADO_ToolStripMenuItem
        '
        Me.STOCK_ACUMULADO_ToolStripMenuItem.Name = "STOCK_ACUMULADO_ToolStripMenuItem"
        Me.STOCK_ACUMULADO_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.STOCK_ACUMULADO_ToolStripMenuItem.Text = "STOCK ACUMULADO"
        '
        'DETALLE_DE_ENVIOS_ToolStripMenuItem
        '
        Me.DETALLE_DE_ENVIOS_ToolStripMenuItem.Name = "DETALLE_DE_ENVIOS_ToolStripMenuItem"
        Me.DETALLE_DE_ENVIOS_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.DETALLE_DE_ENVIOS_ToolStripMenuItem.Text = "DETALLE DE ENVIOS"
        '
        'RESUMEN_DE_COMPRAS_Y_GUIAS_DE_TRASLADO_ToolStripMenuItem
        '
        Me.RESUMEN_DE_COMPRAS_Y_GUIAS_DE_TRASLADO_ToolStripMenuItem.Name = "RESUMEN_DE_COMPRAS_Y_GUIAS_DE_TRASLADO_ToolStripMenuItem"
        Me.RESUMEN_DE_COMPRAS_Y_GUIAS_DE_TRASLADO_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.RESUMEN_DE_COMPRAS_Y_GUIAS_DE_TRASLADO_ToolStripMenuItem.Text = "RESUMEN DE COMPRAS Y GUIAS DE TRASLADO"
        '
        'GUIAS_DE_TRASLADO_A_PROVEEDORES_ToolStripMenuItem
        '
        Me.GUIAS_DE_TRASLADO_A_PROVEEDORES_ToolStripMenuItem.Name = "GUIAS_DE_TRASLADO_A_PROVEEDORES_ToolStripMenuItem"
        Me.GUIAS_DE_TRASLADO_A_PROVEEDORES_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.GUIAS_DE_TRASLADO_A_PROVEEDORES_ToolStripMenuItem.Text = "GUIAS DE TRASLADO A PROVEEDORES"
        '
        'CONSUMO_INTERNO_ToolStripMenuItem
        '
        Me.CONSUMO_INTERNO_ToolStripMenuItem.Name = "CONSUMO_INTERNO_ToolStripMenuItem"
        Me.CONSUMO_INTERNO_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.CONSUMO_INTERNO_ToolStripMenuItem.Text = "CONSUMO INTERNO"
        '
        'ENVIO_A_GARANTIA_ToolStripMenuItem
        '
        Me.ENVIO_A_GARANTIA_ToolStripMenuItem.Name = "ENVIO_A_GARANTIA_ToolStripMenuItem"
        Me.ENVIO_A_GARANTIA_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.ENVIO_A_GARANTIA_ToolStripMenuItem.Text = "ENVIO A GARANTIA"
        '
        'RESUMEN_DE_COMPRAS_POR_PROVEEDOR_ToolStripMenuItem
        '
        Me.RESUMEN_DE_COMPRAS_POR_PROVEEDOR_ToolStripMenuItem.Name = "RESUMEN_DE_COMPRAS_POR_PROVEEDOR_ToolStripMenuItem"
        Me.RESUMEN_DE_COMPRAS_POR_PROVEEDOR_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.RESUMEN_DE_COMPRAS_POR_PROVEEDOR_ToolStripMenuItem.Text = "RESUMEN DE COMPRAS POR PROVEEDOR"
        '
        'RESUMEN_DE_COMPRAS_POR_ITEM_ToolStripMenuItem
        '
        Me.RESUMEN_DE_COMPRAS_POR_ITEM_ToolStripMenuItem.Name = "RESUMEN_DE_COMPRAS_POR_ITEM_ToolStripMenuItem"
        Me.RESUMEN_DE_COMPRAS_POR_ITEM_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.RESUMEN_DE_COMPRAS_POR_ITEM_ToolStripMenuItem.Text = "RESUMEN DE COMPRAS POR ITEM"
        '
        'RESUMEN_DE_ITEM_POR_GUIAS_ToolStripMenuItem
        '
        Me.RESUMEN_DE_ITEM_POR_GUIAS_ToolStripMenuItem.Name = "RESUMEN_DE_ITEM_POR_GUIAS_ToolStripMenuItem"
        Me.RESUMEN_DE_ITEM_POR_GUIAS_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.RESUMEN_DE_ITEM_POR_GUIAS_ToolStripMenuItem.Text = "RESUMEN DE ITEM POR GUIAS"
        '
        'CONTROL_DE_DESPACHOS_ToolStripMenuItem
        '
        Me.CONTROL_DE_DESPACHOS_ToolStripMenuItem.Name = "CONTROL_DE_DESPACHOS_ToolStripMenuItem"
        Me.CONTROL_DE_DESPACHOS_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.CONTROL_DE_DESPACHOS_ToolStripMenuItem.Text = "CONTROL DE DESPACHOS"
        '
        'RESUMEN_DE_COMPRAS_POR_GUIAS_ToolStripMenuItem
        '
        Me.RESUMEN_DE_COMPRAS_POR_GUIAS_ToolStripMenuItem.Name = "RESUMEN_DE_COMPRAS_POR_GUIAS_ToolStripMenuItem"
        Me.RESUMEN_DE_COMPRAS_POR_GUIAS_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.RESUMEN_DE_COMPRAS_POR_GUIAS_ToolStripMenuItem.Text = "RESUMEN DE COMPRAS POR GUIAS"
        '
        'RESUMEN_DE_VENTAS_POR_ITEM_ToolStripMenuItem
        '
        Me.RESUMEN_DE_VENTAS_POR_ITEM_ToolStripMenuItem.Name = "RESUMEN_DE_VENTAS_POR_ITEM_ToolStripMenuItem"
        Me.RESUMEN_DE_VENTAS_POR_ITEM_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.RESUMEN_DE_VENTAS_POR_ITEM_ToolStripMenuItem.Text = "RESUMEN DE VENTAS POR ITEM"
        '
        'REPOSICION_ARANA_ToolStripMenuItem
        '
        Me.REPOSICION_ARANA_ToolStripMenuItem.Name = "REPOSICION_ARANA_ToolStripMenuItem"
        Me.REPOSICION_ARANA_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.REPOSICION_ARANA_ToolStripMenuItem.Text = "REPOSICION ARANA"
        '
        'REVISION_DE_DESPACHOS_ToolStripMenuItem
        '
        Me.REVISION_DE_DESPACHOS_ToolStripMenuItem.Name = "REVISION_DE_DESPACHOS_ToolStripMenuItem"
        Me.REVISION_DE_DESPACHOS_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.REVISION_DE_DESPACHOS_ToolStripMenuItem.Text = "REVISION DE DESPACHOS"
        '
        'CONTEOS_ARANA_ToolStripMenuItem
        '
        Me.CONTEOS_ARANA_ToolStripMenuItem.Name = "CONTEOS_ARANA_ToolStripMenuItem"
        Me.CONTEOS_ARANA_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.CONTEOS_ARANA_ToolStripMenuItem.Text = "CONTEOS ARANA"
        '
        'LISTADO_GUIAS_DE_GARANTIA_ToolStripMenuItem
        '
        Me.LISTADO_GUIAS_DE_GARANTIA_ToolStripMenuItem.Name = "LISTADO_GUIAS_DE_GARANTIA_ToolStripMenuItem"
        Me.LISTADO_GUIAS_DE_GARANTIA_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.LISTADO_GUIAS_DE_GARANTIA_ToolStripMenuItem.Text = "LISTADO DE GUIAS DE GARANTIA"
        '
        'LISTADO_DE_PEDIDOS_ToolStripMenuItem
        '
        Me.LISTADO_DE_PEDIDOS_ToolStripMenuItem.Name = "LISTADO_DE_PEDIDOS_ToolStripMenuItem"
        Me.LISTADO_DE_PEDIDOS_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.LISTADO_DE_PEDIDOS_ToolStripMenuItem.Text = "LISTADO DE PEDIDOS"
        '
        'VENTA_ESPERADA_POR_FAMILIA_ToolStripMenuItem
        '
        Me.VENTA_ESPERADA_POR_FAMILIA_ToolStripMenuItem.Name = "VENTA_ESPERADA_POR_FAMILIA_ToolStripMenuItem"
        Me.VENTA_ESPERADA_POR_FAMILIA_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.VENTA_ESPERADA_POR_FAMILIA_ToolStripMenuItem.Text = "VENTA ESPERADA POR FAMILIA"
        '
        'INVENTARIO_DIARIO_ToolStripMenuItem
        '
        Me.INVENTARIO_DIARIO_ToolStripMenuItem.Name = "INVENTARIO_DIARIO_ToolStripMenuItem"
        Me.INVENTARIO_DIARIO_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.INVENTARIO_DIARIO_ToolStripMenuItem.Text = "INVENTARIO DIARIO"
        '
        'REVISION_DE_STOCK_ToolStripMenuItem
        '
        Me.REVISION_DE_STOCK_ToolStripMenuItem.Name = "REVISION_DE_STOCK_ToolStripMenuItem"
        Me.REVISION_DE_STOCK_ToolStripMenuItem.Size = New System.Drawing.Size(390, 22)
        Me.REVISION_DE_STOCK_ToolStripMenuItem.Text = "REVISION DE STOCK"
        '
        'MENU_CONFIGURACION_ToolStripMenuItem
        '
        Me.MENU_CONFIGURACION_ToolStripMenuItem.AutoSize = False
        Me.MENU_CONFIGURACION_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PERMISOS_ToolStripMenuItem, Me.EMPRESA_ToolStripMenuItem, Me.NUMERACION_ToolStripMenuItem, Me.IMPRESORAS_ToolStripMenuItem, Me.RESPALDO_BD_ToolStripMenuItem, Me.VALORES_DE_SISTEMA_ToolStripMenuItem, Me.RUTA_PARA_ARCHIVOS_PLANOS_ToolStripMenuItem, Me.RUTA_PARA_RESPALDOS_ToolStripMenuItem, Me.BITACORA_DE_CAMBIOS_ToolStripMenuItem, Me.CONSULTAS_SQL_ToolStripMenuItem, Me.IMAGENES_DE_SISTEMA_ToolStripMenuItem, Me.CARGAR_ARCHIVO_EXCEL_ToolStripMenuItem, Me.ACTUALIZAR_STOCK_ToolStripMenuItem, Me.INGRESO_DE_CREDITOS_ToolStripMenuItem, Me.TRASPASO_DE_CREDITOS_A_HISTORICO_ToolStripMenuItem, Me.TRASPASAR_STOCK_FISICO_ToolStripMenuItem, Me.REVISAR_CAJAS_ToolStripMenuItem, Me.CONFIGURACION_CORREO_DE_VENTAS_ToolStripMenuItem, Me.CONFIGURACION_CORREO_DE_ADMINISTRACION_ToolStripMenuItem, Me.CAMBIO_DE_CONTRASEÑA_ToolStripMenuItem, Me.MODIFICAR_CREDITOS_ToolStripMenuItem, Me.MANTENCION_DE_PROPIEDADES_ToolStripMenuItem, Me.FffffToolStripMenuItem})
        Me.MENU_CONFIGURACION_ToolStripMenuItem.Image = CType(resources.GetObject("MENU_CONFIGURACION_ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MENU_CONFIGURACION_ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MENU_CONFIGURACION_ToolStripMenuItem.Name = "MENU_CONFIGURACION_ToolStripMenuItem"
        Me.MENU_CONFIGURACION_ToolStripMenuItem.Size = New System.Drawing.Size(94, 70)
        Me.MENU_CONFIGURACION_ToolStripMenuItem.Text = "CONFIGURACION"
        Me.MENU_CONFIGURACION_ToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PERMISOS_ToolStripMenuItem
        '
        Me.PERMISOS_ToolStripMenuItem.Name = "PERMISOS_ToolStripMenuItem"
        Me.PERMISOS_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.PERMISOS_ToolStripMenuItem.Text = "PERMISOS"
        '
        'EMPRESA_ToolStripMenuItem
        '
        Me.EMPRESA_ToolStripMenuItem.Name = "EMPRESA_ToolStripMenuItem"
        Me.EMPRESA_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.EMPRESA_ToolStripMenuItem.Text = "EMPRESA"
        '
        'NUMERACION_ToolStripMenuItem
        '
        Me.NUMERACION_ToolStripMenuItem.Name = "NUMERACION_ToolStripMenuItem"
        Me.NUMERACION_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.NUMERACION_ToolStripMenuItem.Text = "NUMERACION"
        '
        'IMPRESORAS_ToolStripMenuItem
        '
        Me.IMPRESORAS_ToolStripMenuItem.Name = "IMPRESORAS_ToolStripMenuItem"
        Me.IMPRESORAS_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.IMPRESORAS_ToolStripMenuItem.Text = "IMPRESORAS"
        '
        'RESPALDO_BD_ToolStripMenuItem
        '
        Me.RESPALDO_BD_ToolStripMenuItem.Name = "RESPALDO_BD_ToolStripMenuItem"
        Me.RESPALDO_BD_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.RESPALDO_BD_ToolStripMenuItem.Text = "RESPALDO BD"
        '
        'VALORES_DE_SISTEMA_ToolStripMenuItem
        '
        Me.VALORES_DE_SISTEMA_ToolStripMenuItem.Name = "VALORES_DE_SISTEMA_ToolStripMenuItem"
        Me.VALORES_DE_SISTEMA_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.VALORES_DE_SISTEMA_ToolStripMenuItem.Text = "VALORES DE SISTEMA"
        '
        'RUTA_PARA_ARCHIVOS_PLANOS_ToolStripMenuItem
        '
        Me.RUTA_PARA_ARCHIVOS_PLANOS_ToolStripMenuItem.Name = "RUTA_PARA_ARCHIVOS_PLANOS_ToolStripMenuItem"
        Me.RUTA_PARA_ARCHIVOS_PLANOS_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.RUTA_PARA_ARCHIVOS_PLANOS_ToolStripMenuItem.Text = "RUTA PARA ARCHIVOS PLANOS"
        '
        'RUTA_PARA_RESPALDOS_ToolStripMenuItem
        '
        Me.RUTA_PARA_RESPALDOS_ToolStripMenuItem.Name = "RUTA_PARA_RESPALDOS_ToolStripMenuItem"
        Me.RUTA_PARA_RESPALDOS_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.RUTA_PARA_RESPALDOS_ToolStripMenuItem.Text = "RUTA PARA RESPALDOS"
        '
        'BITACORA_DE_CAMBIOS_ToolStripMenuItem
        '
        Me.BITACORA_DE_CAMBIOS_ToolStripMenuItem.Name = "BITACORA_DE_CAMBIOS_ToolStripMenuItem"
        Me.BITACORA_DE_CAMBIOS_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.BITACORA_DE_CAMBIOS_ToolStripMenuItem.Text = "BITACORA DE CAMBIOS"
        '
        'CONSULTAS_SQL_ToolStripMenuItem
        '
        Me.CONSULTAS_SQL_ToolStripMenuItem.Name = "CONSULTAS_SQL_ToolStripMenuItem"
        Me.CONSULTAS_SQL_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.CONSULTAS_SQL_ToolStripMenuItem.Text = "CONSULTAS SQL"
        '
        'IMAGENES_DE_SISTEMA_ToolStripMenuItem
        '
        Me.IMAGENES_DE_SISTEMA_ToolStripMenuItem.Name = "IMAGENES_DE_SISTEMA_ToolStripMenuItem"
        Me.IMAGENES_DE_SISTEMA_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.IMAGENES_DE_SISTEMA_ToolStripMenuItem.Text = "IMAGENES DE SISTEMA"
        '
        'CARGAR_ARCHIVO_EXCEL_ToolStripMenuItem
        '
        Me.CARGAR_ARCHIVO_EXCEL_ToolStripMenuItem.Name = "CARGAR_ARCHIVO_EXCEL_ToolStripMenuItem"
        Me.CARGAR_ARCHIVO_EXCEL_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.CARGAR_ARCHIVO_EXCEL_ToolStripMenuItem.Text = "CARGAR ARCHIVO EXCEL"
        '
        'ACTUALIZAR_STOCK_ToolStripMenuItem
        '
        Me.ACTUALIZAR_STOCK_ToolStripMenuItem.Name = "ACTUALIZAR_STOCK_ToolStripMenuItem"
        Me.ACTUALIZAR_STOCK_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.ACTUALIZAR_STOCK_ToolStripMenuItem.Text = "ACTUALIZAR STOCK"
        '
        'INGRESO_DE_CREDITOS_ToolStripMenuItem
        '
        Me.INGRESO_DE_CREDITOS_ToolStripMenuItem.Name = "INGRESO_DE_CREDITOS_ToolStripMenuItem"
        Me.INGRESO_DE_CREDITOS_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.INGRESO_DE_CREDITOS_ToolStripMenuItem.Text = "INGRESO DE CREDITOS"
        '
        'TRASPASO_DE_CREDITOS_A_HISTORICO_ToolStripMenuItem
        '
        Me.TRASPASO_DE_CREDITOS_A_HISTORICO_ToolStripMenuItem.Name = "TRASPASO_DE_CREDITOS_A_HISTORICO_ToolStripMenuItem"
        Me.TRASPASO_DE_CREDITOS_A_HISTORICO_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.TRASPASO_DE_CREDITOS_A_HISTORICO_ToolStripMenuItem.Text = "TRASPASO DE CREDITOS A HISTORICO"
        '
        'TRASPASAR_STOCK_FISICO_ToolStripMenuItem
        '
        Me.TRASPASAR_STOCK_FISICO_ToolStripMenuItem.Name = "TRASPASAR_STOCK_FISICO_ToolStripMenuItem"
        Me.TRASPASAR_STOCK_FISICO_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.TRASPASAR_STOCK_FISICO_ToolStripMenuItem.Text = "TRASPASAR STOCK FISICO"
        '
        'REVISAR_CAJAS_ToolStripMenuItem
        '
        Me.REVISAR_CAJAS_ToolStripMenuItem.Name = "REVISAR_CAJAS_ToolStripMenuItem"
        Me.REVISAR_CAJAS_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.REVISAR_CAJAS_ToolStripMenuItem.Text = "REVISAR CAJAS"
        '
        'CONFIGURACION_CORREO_DE_VENTAS_ToolStripMenuItem
        '
        Me.CONFIGURACION_CORREO_DE_VENTAS_ToolStripMenuItem.Name = "CONFIGURACION_CORREO_DE_VENTAS_ToolStripMenuItem"
        Me.CONFIGURACION_CORREO_DE_VENTAS_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.CONFIGURACION_CORREO_DE_VENTAS_ToolStripMenuItem.Text = "CONFIGURACION CORREO DE VENTAS"
        '
        'CONFIGURACION_CORREO_DE_ADMINISTRACION_ToolStripMenuItem
        '
        Me.CONFIGURACION_CORREO_DE_ADMINISTRACION_ToolStripMenuItem.Name = "CONFIGURACION_CORREO_DE_ADMINISTRACION_ToolStripMenuItem"
        Me.CONFIGURACION_CORREO_DE_ADMINISTRACION_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.CONFIGURACION_CORREO_DE_ADMINISTRACION_ToolStripMenuItem.Text = "CONFIGURACION CORREO DE ADMINISTRACION"
        '
        'CAMBIO_DE_CONTRASEÑA_ToolStripMenuItem
        '
        Me.CAMBIO_DE_CONTRASEÑA_ToolStripMenuItem.Name = "CAMBIO_DE_CONTRASEÑA_ToolStripMenuItem"
        Me.CAMBIO_DE_CONTRASEÑA_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.CAMBIO_DE_CONTRASEÑA_ToolStripMenuItem.Text = "CAMBIO DE CONTRASEÑA"
        '
        'MODIFICAR_CREDITOS_ToolStripMenuItem
        '
        Me.MODIFICAR_CREDITOS_ToolStripMenuItem.Name = "MODIFICAR_CREDITOS_ToolStripMenuItem"
        Me.MODIFICAR_CREDITOS_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.MODIFICAR_CREDITOS_ToolStripMenuItem.Text = "MODIFICAR CREDITOS"
        '
        'MANTENCION_DE_PROPIEDADES_ToolStripMenuItem
        '
        Me.MANTENCION_DE_PROPIEDADES_ToolStripMenuItem.Name = "MANTENCION_DE_PROPIEDADES_ToolStripMenuItem"
        Me.MANTENCION_DE_PROPIEDADES_ToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.MANTENCION_DE_PROPIEDADES_ToolStripMenuItem.Text = "MANTENCION DE PROPIEDADES"
        '
        'FffffToolStripMenuItem
        '
        Me.FffffToolStripMenuItem.Name = "FffffToolStripMenuItem"
        Me.FffffToolStripMenuItem.Size = New System.Drawing.Size(388, 22)
        Me.FffffToolStripMenuItem.Text = "fffff"
        '
        'MENU_MANTENEDORES_ToolStripMenuItem
        '
        Me.MENU_MANTENEDORES_ToolStripMenuItem.AutoSize = False
        Me.MENU_MANTENEDORES_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CLIENTES_ToolStripMenuItem, Me.USUARIOS_ToolStripMenuItem, Me.PROVEEDORES_ToolStripMenuItem, Me.PRODUCTOS_ToolStripMenuItem, Me.RETIRADORES_ToolStripMenuItem, Me.FAMILIAS_ToolStripMenuItem, Me.SUBFAMILIAS_ToolStripMenuItem, Me.SUBFAMILIAS_2_ToolStripMenuItem, Me.CUENTAS_CORRIENTES_ToolStripMenuItem, Me.MARCAS_ToolStripMenuItem, Me.PROVEEDORES_MAS_PEDIDOS_ToolStripMenuItem, Me.TARJETAS_DE_PRESENTACION_ToolStripMenuItem, Me.CONDICION_DE_VENTA_ToolStripMenuItem, Me.IMAGENES_DE_PRODUCTOS_ToolStripMenuItem, Me.REGISTRO_DE_HARDWARE_ToolStripMenuItem, Me.LISTADOS_ToolStripMenuItem, Me.ASOCIAR_CLIENTES_A_EMPRESAS_ToolStripMenuItem, Me.IMAGENES_DE_PRODUCTOS_PARA_PUBLICIDAD_ToolStripMenuItem})
        Me.MENU_MANTENEDORES_ToolStripMenuItem.Image = CType(resources.GetObject("MENU_MANTENEDORES_ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MENU_MANTENEDORES_ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MENU_MANTENEDORES_ToolStripMenuItem.Name = "MENU_MANTENEDORES_ToolStripMenuItem"
        Me.MENU_MANTENEDORES_ToolStripMenuItem.Size = New System.Drawing.Size(168, 70)
        Me.MENU_MANTENEDORES_ToolStripMenuItem.Text = "MANTENEDORES"
        Me.MENU_MANTENEDORES_ToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'CLIENTES_ToolStripMenuItem
        '
        Me.CLIENTES_ToolStripMenuItem.Name = "CLIENTES_ToolStripMenuItem"
        Me.CLIENTES_ToolStripMenuItem.Size = New System.Drawing.Size(379, 22)
        Me.CLIENTES_ToolStripMenuItem.Text = "CLIENTES"
        '
        'USUARIOS_ToolStripMenuItem
        '
        Me.USUARIOS_ToolStripMenuItem.Name = "USUARIOS_ToolStripMenuItem"
        Me.USUARIOS_ToolStripMenuItem.Size = New System.Drawing.Size(379, 22)
        Me.USUARIOS_ToolStripMenuItem.Text = "USUARIOS"
        '
        'PROVEEDORES_ToolStripMenuItem
        '
        Me.PROVEEDORES_ToolStripMenuItem.Name = "PROVEEDORES_ToolStripMenuItem"
        Me.PROVEEDORES_ToolStripMenuItem.Size = New System.Drawing.Size(379, 22)
        Me.PROVEEDORES_ToolStripMenuItem.Text = "PROVEEDORES"
        '
        'PRODUCTOS_ToolStripMenuItem
        '
        Me.PRODUCTOS_ToolStripMenuItem.Name = "PRODUCTOS_ToolStripMenuItem"
        Me.PRODUCTOS_ToolStripMenuItem.Size = New System.Drawing.Size(379, 22)
        Me.PRODUCTOS_ToolStripMenuItem.Text = "PRODUCTOS"
        '
        'RETIRADORES_ToolStripMenuItem
        '
        Me.RETIRADORES_ToolStripMenuItem.Name = "RETIRADORES_ToolStripMenuItem"
        Me.RETIRADORES_ToolStripMenuItem.Size = New System.Drawing.Size(379, 22)
        Me.RETIRADORES_ToolStripMenuItem.Text = "RETIRADORES"
        Me.RETIRADORES_ToolStripMenuItem.Visible = False
        '
        'FAMILIAS_ToolStripMenuItem
        '
        Me.FAMILIAS_ToolStripMenuItem.Name = "FAMILIAS_ToolStripMenuItem"
        Me.FAMILIAS_ToolStripMenuItem.Size = New System.Drawing.Size(379, 22)
        Me.FAMILIAS_ToolStripMenuItem.Text = "FAMILIAS"
        '
        'SUBFAMILIAS_ToolStripMenuItem
        '
        Me.SUBFAMILIAS_ToolStripMenuItem.Name = "SUBFAMILIAS_ToolStripMenuItem"
        Me.SUBFAMILIAS_ToolStripMenuItem.Size = New System.Drawing.Size(379, 22)
        Me.SUBFAMILIAS_ToolStripMenuItem.Text = "SUBFAMILIAS"
        '
        'SUBFAMILIAS_2_ToolStripMenuItem
        '
        Me.SUBFAMILIAS_2_ToolStripMenuItem.Name = "SUBFAMILIAS_2_ToolStripMenuItem"
        Me.SUBFAMILIAS_2_ToolStripMenuItem.Size = New System.Drawing.Size(379, 22)
        Me.SUBFAMILIAS_2_ToolStripMenuItem.Text = "SUBFAMILIAS 2"
        '
        'CUENTAS_CORRIENTES_ToolStripMenuItem
        '
        Me.CUENTAS_CORRIENTES_ToolStripMenuItem.Name = "CUENTAS_CORRIENTES_ToolStripMenuItem"
        Me.CUENTAS_CORRIENTES_ToolStripMenuItem.Size = New System.Drawing.Size(379, 22)
        Me.CUENTAS_CORRIENTES_ToolStripMenuItem.Text = "CUENTAS CORRIENTES"
        '
        'MARCAS_ToolStripMenuItem
        '
        Me.MARCAS_ToolStripMenuItem.Name = "MARCAS_ToolStripMenuItem"
        Me.MARCAS_ToolStripMenuItem.Size = New System.Drawing.Size(379, 22)
        Me.MARCAS_ToolStripMenuItem.Text = "MARCAS"
        '
        'PROVEEDORES_MAS_PEDIDOS_ToolStripMenuItem
        '
        Me.PROVEEDORES_MAS_PEDIDOS_ToolStripMenuItem.Name = "PROVEEDORES_MAS_PEDIDOS_ToolStripMenuItem"
        Me.PROVEEDORES_MAS_PEDIDOS_ToolStripMenuItem.Size = New System.Drawing.Size(379, 22)
        Me.PROVEEDORES_MAS_PEDIDOS_ToolStripMenuItem.Text = "PROVEEDORES MAS PEDIDOS"
        '
        'TARJETAS_DE_PRESENTACION_ToolStripMenuItem
        '
        Me.TARJETAS_DE_PRESENTACION_ToolStripMenuItem.Name = "TARJETAS_DE_PRESENTACION_ToolStripMenuItem"
        Me.TARJETAS_DE_PRESENTACION_ToolStripMenuItem.Size = New System.Drawing.Size(379, 22)
        Me.TARJETAS_DE_PRESENTACION_ToolStripMenuItem.Text = "TARJETAS DE PRESENTACION"
        '
        'CONDICION_DE_VENTA_ToolStripMenuItem
        '
        Me.CONDICION_DE_VENTA_ToolStripMenuItem.Name = "CONDICION_DE_VENTA_ToolStripMenuItem"
        Me.CONDICION_DE_VENTA_ToolStripMenuItem.Size = New System.Drawing.Size(379, 22)
        Me.CONDICION_DE_VENTA_ToolStripMenuItem.Text = "CONDICION DE VENTA"
        Me.CONDICION_DE_VENTA_ToolStripMenuItem.Visible = False
        '
        'IMAGENES_DE_PRODUCTOS_ToolStripMenuItem
        '
        Me.IMAGENES_DE_PRODUCTOS_ToolStripMenuItem.Name = "IMAGENES_DE_PRODUCTOS_ToolStripMenuItem"
        Me.IMAGENES_DE_PRODUCTOS_ToolStripMenuItem.Size = New System.Drawing.Size(379, 22)
        Me.IMAGENES_DE_PRODUCTOS_ToolStripMenuItem.Text = "IMAGENES DE PRODUCTOS"
        '
        'REGISTRO_DE_HARDWARE_ToolStripMenuItem
        '
        Me.REGISTRO_DE_HARDWARE_ToolStripMenuItem.Name = "REGISTRO_DE_HARDWARE_ToolStripMenuItem"
        Me.REGISTRO_DE_HARDWARE_ToolStripMenuItem.Size = New System.Drawing.Size(379, 22)
        Me.REGISTRO_DE_HARDWARE_ToolStripMenuItem.Text = "REGISTRO DE HARDWARE"
        '
        'LISTADOS_ToolStripMenuItem
        '
        Me.LISTADOS_ToolStripMenuItem.Name = "LISTADOS_ToolStripMenuItem"
        Me.LISTADOS_ToolStripMenuItem.Size = New System.Drawing.Size(379, 22)
        Me.LISTADOS_ToolStripMenuItem.Text = "LISTADOS"
        '
        'ASOCIAR_CLIENTES_A_EMPRESAS_ToolStripMenuItem
        '
        Me.ASOCIAR_CLIENTES_A_EMPRESAS_ToolStripMenuItem.Name = "ASOCIAR_CLIENTES_A_EMPRESAS_ToolStripMenuItem"
        Me.ASOCIAR_CLIENTES_A_EMPRESAS_ToolStripMenuItem.Size = New System.Drawing.Size(379, 22)
        Me.ASOCIAR_CLIENTES_A_EMPRESAS_ToolStripMenuItem.Text = "ASOCIAR CLIENTES A EMPRESAS"
        '
        'IMAGENES_DE_PRODUCTOS_PARA_PUBLICIDAD_ToolStripMenuItem
        '
        Me.IMAGENES_DE_PRODUCTOS_PARA_PUBLICIDAD_ToolStripMenuItem.Name = "IMAGENES_DE_PRODUCTOS_PARA_PUBLICIDAD_ToolStripMenuItem"
        Me.IMAGENES_DE_PRODUCTOS_PARA_PUBLICIDAD_ToolStripMenuItem.Size = New System.Drawing.Size(379, 22)
        Me.IMAGENES_DE_PRODUCTOS_PARA_PUBLICIDAD_ToolStripMenuItem.Text = "IMAGENES DE PRODUCTOS PARA PUBLICIDAD"
        '
        'MENU_VENTAS_ToolStripMenuItem
        '
        Me.MENU_VENTAS_ToolStripMenuItem.AutoSize = False
        Me.MENU_VENTAS_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VENTAS_ToolStripMenuItem, Me.ENVIAR_COTIZACION_ToolStripMenuItem, Me.CARTOLA_KARDEX_ToolStripMenuItem, Me.COMISION_VENDEDORES_ToolStripMenuItem, Me.COMISION_POR_SERVICIOS_ToolStripMenuItem, Me.COTIZACION_FORMAL_ToolStripMenuItem, Me.CAMBIO_DE_PRODUCTOS_ToolStripMenuItem, Me.MIS_DOCUMENTOS_EMITIDOS_ToolStripMenuItem, Me.TICKET_DE_VENTAS_ToolStripMenuItem, Me.AUTORIZACIONES_DE_VENTAS_ToolStripMenuItem, Me.VENTAS_ASISTIDAS_ToolStripMenuItem, Me.BUSCADOR_DE_PRODUCTOS_ToolStripMenuItem, Me.SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem, Me.ADMINISTRAR_SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem, Me.CALCULADORA_ToolStripMenuItem, Me.RECEPCION_DE_TRABAJO_ToolStripMenuItem, Me.LISTADO_DE_VALES_DE_CAMBIO_ToolStripMenuItem, Me.ESTADISTICAS_DE_VENTA_POR_PRODUCTOS_ToolStripMenuItem, Me.COMISIONES_POR_VENDEDOR_ToolStripMenuItem, Me.BUSCAR_DOCUMENTO_DE_CAMBIO_DE_PRODUCTO_ToolStripMenuItem, Me.TARJETA_DE_PRESENTACION_RAPIDA_ToolStripMenuItem, Me.PRODUCTOSPAGINAToolStripMenuItem, Me.PRODUCTOS_CON_MAS_MOVIMIENTOS_ToolStripMenuItem})
        Me.MENU_VENTAS_ToolStripMenuItem.Image = CType(resources.GetObject("MENU_VENTAS_ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MENU_VENTAS_ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MENU_VENTAS_ToolStripMenuItem.Name = "MENU_VENTAS_ToolStripMenuItem"
        Me.MENU_VENTAS_ToolStripMenuItem.Size = New System.Drawing.Size(94, 70)
        Me.MENU_VENTAS_ToolStripMenuItem.Text = "VENTAS F12"
        Me.MENU_VENTAS_ToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'VENTAS_ToolStripMenuItem
        '
        Me.VENTAS_ToolStripMenuItem.Name = "VENTAS_ToolStripMenuItem"
        Me.VENTAS_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.VENTAS_ToolStripMenuItem.Text = "VENTAS"
        '
        'ENVIAR_COTIZACION_ToolStripMenuItem
        '
        Me.ENVIAR_COTIZACION_ToolStripMenuItem.Name = "ENVIAR_COTIZACION_ToolStripMenuItem"
        Me.ENVIAR_COTIZACION_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.ENVIAR_COTIZACION_ToolStripMenuItem.Text = "ENVIAR COTIZACION"
        '
        'CARTOLA_KARDEX_ToolStripMenuItem
        '
        Me.CARTOLA_KARDEX_ToolStripMenuItem.Name = "CARTOLA_KARDEX_ToolStripMenuItem"
        Me.CARTOLA_KARDEX_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.CARTOLA_KARDEX_ToolStripMenuItem.Text = "CARTOLA KARDEX"
        '
        'COMISION_VENDEDORES_ToolStripMenuItem
        '
        Me.COMISION_VENDEDORES_ToolStripMenuItem.Name = "COMISION_VENDEDORES_ToolStripMenuItem"
        Me.COMISION_VENDEDORES_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.COMISION_VENDEDORES_ToolStripMenuItem.Text = "COMISION VENDEDORES"
        '
        'COMISION_POR_SERVICIOS_ToolStripMenuItem
        '
        Me.COMISION_POR_SERVICIOS_ToolStripMenuItem.Name = "COMISION_POR_SERVICIOS_ToolStripMenuItem"
        Me.COMISION_POR_SERVICIOS_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.COMISION_POR_SERVICIOS_ToolStripMenuItem.Text = "COMISION POR SERVICIOS"
        '
        'COTIZACION_FORMAL_ToolStripMenuItem
        '
        Me.COTIZACION_FORMAL_ToolStripMenuItem.Name = "COTIZACION_FORMAL_ToolStripMenuItem"
        Me.COTIZACION_FORMAL_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.COTIZACION_FORMAL_ToolStripMenuItem.Text = "COTIZACION FORMAL"
        '
        'CAMBIO_DE_PRODUCTOS_ToolStripMenuItem
        '
        Me.CAMBIO_DE_PRODUCTOS_ToolStripMenuItem.Name = "CAMBIO_DE_PRODUCTOS_ToolStripMenuItem"
        Me.CAMBIO_DE_PRODUCTOS_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.CAMBIO_DE_PRODUCTOS_ToolStripMenuItem.Text = "CAMBIO DE PRODUCTOS"
        '
        'MIS_DOCUMENTOS_EMITIDOS_ToolStripMenuItem
        '
        Me.MIS_DOCUMENTOS_EMITIDOS_ToolStripMenuItem.Name = "MIS_DOCUMENTOS_EMITIDOS_ToolStripMenuItem"
        Me.MIS_DOCUMENTOS_EMITIDOS_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.MIS_DOCUMENTOS_EMITIDOS_ToolStripMenuItem.Text = "MIS DOCUMENTOS EMITIDOS"
        '
        'TICKET_DE_VENTAS_ToolStripMenuItem
        '
        Me.TICKET_DE_VENTAS_ToolStripMenuItem.Name = "TICKET_DE_VENTAS_ToolStripMenuItem"
        Me.TICKET_DE_VENTAS_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.TICKET_DE_VENTAS_ToolStripMenuItem.Text = "TICKET DE VENTAS"
        '
        'AUTORIZACIONES_DE_VENTAS_ToolStripMenuItem
        '
        Me.AUTORIZACIONES_DE_VENTAS_ToolStripMenuItem.Name = "AUTORIZACIONES_DE_VENTAS_ToolStripMenuItem"
        Me.AUTORIZACIONES_DE_VENTAS_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.AUTORIZACIONES_DE_VENTAS_ToolStripMenuItem.Text = "AUTORIZACIONES DE VENTAS"
        '
        'VENTAS_ASISTIDAS_ToolStripMenuItem
        '
        Me.VENTAS_ASISTIDAS_ToolStripMenuItem.Name = "VENTAS_ASISTIDAS_ToolStripMenuItem"
        Me.VENTAS_ASISTIDAS_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.VENTAS_ASISTIDAS_ToolStripMenuItem.Text = "VENTAS ASISTIDAS"
        '
        'BUSCADOR_DE_PRODUCTOS_ToolStripMenuItem
        '
        Me.BUSCADOR_DE_PRODUCTOS_ToolStripMenuItem.Name = "BUSCADOR_DE_PRODUCTOS_ToolStripMenuItem"
        Me.BUSCADOR_DE_PRODUCTOS_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.BUSCADOR_DE_PRODUCTOS_ToolStripMenuItem.Text = "BUSCADOR DE PRODUCTOS"
        '
        'SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem
        '
        Me.SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem.Name = "SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem"
        Me.SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem.Text = "SERVICIOS DE LUBRICENTRO"
        '
        'ADMINISTRAR_SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem
        '
        Me.ADMINISTRAR_SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem.Name = "ADMINISTRAR_SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem"
        Me.ADMINISTRAR_SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.ADMINISTRAR_SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem.Text = "ADMINISTRAR SERVICIOS DE LUBRICENTRO"
        '
        'CALCULADORA_ToolStripMenuItem
        '
        Me.CALCULADORA_ToolStripMenuItem.Name = "CALCULADORA_ToolStripMenuItem"
        Me.CALCULADORA_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.CALCULADORA_ToolStripMenuItem.Text = "CALCULADORA"
        '
        'RECEPCION_DE_TRABAJO_ToolStripMenuItem
        '
        Me.RECEPCION_DE_TRABAJO_ToolStripMenuItem.Name = "RECEPCION_DE_TRABAJO_ToolStripMenuItem"
        Me.RECEPCION_DE_TRABAJO_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.RECEPCION_DE_TRABAJO_ToolStripMenuItem.Text = "RECEPCION DE TRABAJO"
        '
        'LISTADO_DE_VALES_DE_CAMBIO_ToolStripMenuItem
        '
        Me.LISTADO_DE_VALES_DE_CAMBIO_ToolStripMenuItem.Name = "LISTADO_DE_VALES_DE_CAMBIO_ToolStripMenuItem"
        Me.LISTADO_DE_VALES_DE_CAMBIO_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.LISTADO_DE_VALES_DE_CAMBIO_ToolStripMenuItem.Text = "LISTADO DE VALES DE CAMBIO"
        '
        'ESTADISTICAS_DE_VENTA_POR_PRODUCTOS_ToolStripMenuItem
        '
        Me.ESTADISTICAS_DE_VENTA_POR_PRODUCTOS_ToolStripMenuItem.Name = "ESTADISTICAS_DE_VENTA_POR_PRODUCTOS_ToolStripMenuItem"
        Me.ESTADISTICAS_DE_VENTA_POR_PRODUCTOS_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.ESTADISTICAS_DE_VENTA_POR_PRODUCTOS_ToolStripMenuItem.Text = "ESTADISTICAS DE VENTA POR PRODUCTOS"
        '
        'COMISIONES_POR_VENDEDOR_ToolStripMenuItem
        '
        Me.COMISIONES_POR_VENDEDOR_ToolStripMenuItem.Name = "COMISIONES_POR_VENDEDOR_ToolStripMenuItem"
        Me.COMISIONES_POR_VENDEDOR_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.COMISIONES_POR_VENDEDOR_ToolStripMenuItem.Text = "COMISIONES POR VENDEDOR"
        '
        'BUSCAR_DOCUMENTO_DE_CAMBIO_DE_PRODUCTO_ToolStripMenuItem
        '
        Me.BUSCAR_DOCUMENTO_DE_CAMBIO_DE_PRODUCTO_ToolStripMenuItem.Name = "BUSCAR_DOCUMENTO_DE_CAMBIO_DE_PRODUCTO_ToolStripMenuItem"
        Me.BUSCAR_DOCUMENTO_DE_CAMBIO_DE_PRODUCTO_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.BUSCAR_DOCUMENTO_DE_CAMBIO_DE_PRODUCTO_ToolStripMenuItem.Text = "BUSCAR DOCUMENTO DE CAMBIO DE PRODUCTO"
        '
        'TARJETA_DE_PRESENTACION_RAPIDA_ToolStripMenuItem
        '
        Me.TARJETA_DE_PRESENTACION_RAPIDA_ToolStripMenuItem.Name = "TARJETA_DE_PRESENTACION_RAPIDA_ToolStripMenuItem"
        Me.TARJETA_DE_PRESENTACION_RAPIDA_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.TARJETA_DE_PRESENTACION_RAPIDA_ToolStripMenuItem.Text = "TARJETA DE PRESENTACION RAPIDA"
        '
        'PRODUCTOSPAGINAToolStripMenuItem
        '
        Me.PRODUCTOSPAGINAToolStripMenuItem.Name = "PRODUCTOSPAGINAToolStripMenuItem"
        Me.PRODUCTOSPAGINAToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.PRODUCTOSPAGINAToolStripMenuItem.Text = "PRODUCTOS PAGINA"
        '
        'PRODUCTOS_CON_MAS_MOVIMIENTOS_ToolStripMenuItem
        '
        Me.PRODUCTOS_CON_MAS_MOVIMIENTOS_ToolStripMenuItem.Name = "PRODUCTOS_CON_MAS_MOVIMIENTOS_ToolStripMenuItem"
        Me.PRODUCTOS_CON_MAS_MOVIMIENTOS_ToolStripMenuItem.Size = New System.Drawing.Size(401, 22)
        Me.PRODUCTOS_CON_MAS_MOVIMIENTOS_ToolStripMenuItem.Text = "PRODUCTOS CON MAS MOVIMIENTOS"
        '
        'BackgroundWorker1
        '
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(0, 201)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(1018, 400)
        Me.PictureBox_logo.TabIndex = 282
        Me.PictureBox_logo.TabStop = False
        '
        'Form_menu_principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1018, 771)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.lbl_version)
        Me.Controls.Add(Me.grilla_conexiones)
        Me.Controls.Add(Me.Panel_pie)
        Me.Controls.Add(Me.lbl_soporte_remoto)
        Me.Controls.Add(Me.lbl_hora)
        Me.Controls.Add(Me.lbl_fecha)
        Me.Controls.Add(Me.lbl_usuario_conectado)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.lbl_uc)
        Me.Controls.Add(Me.dtp_fecha)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "Form_menu_principal"
        Me.Opacity = 0
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MENU PRINCIPAL"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel_pie.ResumeLayout(False)
        CType(Me.grilla_conexiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer_hora As System.Windows.Forms.Timer
    Friend WithEvents Timer_inactividad_menu As System.Windows.Forms.Timer
    Friend WithEvents lbl_uc As System.Windows.Forms.Label
    Friend WithEvents lbl_pie As System.Windows.Forms.Label
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_hora As System.Windows.Forms.Label
    Friend WithEvents lbl_fecha As System.Windows.Forms.Label
    Friend WithEvents lbl_usuario_conectado As System.Windows.Forms.Label
    Friend WithEvents lbl_soporte_remoto As System.Windows.Forms.Label
    Friend WithEvents Panel_pie As System.Windows.Forms.Panel
    Friend WithEvents lbl_contacto As System.Windows.Forms.Label
    Friend WithEvents grilla_conexiones As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbl_version As System.Windows.Forms.Label
    Friend WithEvents MENU_ADQUISICIONES_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents STOCK_MINIMO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents REALIZAR_PEDIDOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MIS_PEDIDOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CONFIRMACION_DE_LLEGADA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents REVISION_DE_PEDIDOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RESERVAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents REALIZAR_RESERVA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MIS_RESERVAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ORDENES_DE_COMPRA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CENTRAL_DE_COSTOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PEDIDOS_OR_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MENU_ADMINISTRACION_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FACTURACION_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FACTURACION_POR_RANGOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FACTURACION_MANUAL_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CORREGIR_DOCUMENTOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OPCIONES_DE_CAJA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CUADRATURA_DE_CAJA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DETALLE_DE_ABONOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LISTADO_DE_DOCUMENTOS_NULOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LISTADO_DE_ABONOS_PARA_CAJA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents REGISTRO_DE_CHEQUES_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CAJA_REGISTRADORA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RESUMEN_DE_CUADRATURA_CAJA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LISTADO_DE_EGRESOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CUADRATURA_FIN_DE_MES_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SUELDOS_POR_CAJA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ANTICIPOS_Y_SUELDOS_JEFE_LOCAL_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FONDO_DE_SUELDOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents REGISTRO_DE_FACTURAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ESTADISTICAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VENTAS_DEL_DIA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VENTAS_DE_LA_SEMANA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VENTAS_SEGUN_VENDEDOR_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BUSCAR_FACTURAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents REPORTE_LIBRO_DE_COMPRAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LIBRO_DE_COMPRAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents REVISAR_ARCHIVO_SII_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LIBRO_DE_VENTAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BUSCAR_TOTALES_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CORREGIR_NUMEROS_DE_IMPRESION_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents INGRESO_MANUAL_DE_VENTAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NOTAS_DE_CREDITO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TRASPASO_DE_STOCK_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DETALLE_DE_VENTAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DETALLE_DE_VENTAS_POR_DOCUMENTO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CUENTAS_POR_COBRAR_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ESTADO_DE_CUENTA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ESTADO_DE_CUENTA_POR_RANGO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AGREGAR_ABONOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AGREGAR_ABONOS_SIN_IMPUTAR_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IMPUTAR_ABONOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IMPUTAR_NOTAS_DE_CREDITO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DEUDORES_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LISTADO_DE_ABONOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LISTADO_DE_LETRAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DETALLE_DE_CREDITOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DETALLE_DE_VENTAS_CON_PIE_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DETALLE_DE_VENTAS_PAGO_COMBINADO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ARCHIVO_DICOM_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DEUDA_DE_CLIENTE_SEGUN_FECHA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HISTORICO_DE_CUENTASCORRIENTES_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents INGRESAR_CREDITOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LISTADO_DE_INTERESES_Y_GASTOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NOTAS_DE_DEBITO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ESTADO_DE_DEUDAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DEUDA_CLIENTES_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DEUDA_PROVEEDORES_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CALCULAR_DEUDAS_DE_CLIENTES_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HOJAS_FOLIADAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LISTADO_DE_CLIENTES_CON_PAGARE_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SALIDA_DE_TRABAJADORES_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MENU_BODEGA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents COMPRAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ETIQUETAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CODIGOS_DE_BARRA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TRASPASO_A_SUCURSAL_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents INVENTARIO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DETALLE_DE_COMPRAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GUIAS_DE_TRASLADO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ASIGNAR_FAMILIAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GUIAS_ACEPTADAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EXISTENCIAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents REPOSICION_DE_VENTAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents STOCK_ACUMULADO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DETALLE_DE_ENVIOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RESUMEN_DE_COMPRAS_Y_GUIAS_DE_TRASLADO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GUIAS_DE_TRASLADO_A_PROVEEDORES_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CONSUMO_INTERNO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ENVIO_A_GARANTIA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RESUMEN_DE_COMPRAS_POR_PROVEEDOR_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RESUMEN_DE_COMPRAS_POR_ITEM_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RESUMEN_DE_ITEM_POR_GUIAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CONTROL_DE_DESPACHOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RESUMEN_DE_COMPRAS_POR_GUIAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RESUMEN_DE_VENTAS_POR_ITEM_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents REPOSICION_ARANA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents REVISION_DE_DESPACHOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CONTEOS_ARANA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LISTADO_GUIAS_DE_GARANTIA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LISTADO_DE_PEDIDOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VENTA_ESPERADA_POR_FAMILIA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents INVENTARIO_DIARIO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MENU_CONFIGURACION_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PERMISOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EMPRESA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NUMERACION_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IMPRESORAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RESPALDO_BD_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VALORES_DE_SISTEMA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RUTA_PARA_ARCHIVOS_PLANOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BITACORA_DE_CAMBIOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CONSULTAS_SQL_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IMAGENES_DE_SISTEMA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CARGAR_ARCHIVO_EXCEL_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ACTUALIZAR_STOCK_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents INGRESO_DE_CREDITOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TRASPASO_DE_CREDITOS_A_HISTORICO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TRASPASAR_STOCK_FISICO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents REVISAR_CAJAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MENU_MANTENEDORES_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CLIENTES_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents USUARIOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PROVEEDORES_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PRODUCTOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RETIRADORES_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FAMILIAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SUBFAMILIAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SUBFAMILIAS_2_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CUENTAS_CORRIENTES_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MARCAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PROVEEDORES_MAS_PEDIDOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TARJETAS_DE_PRESENTACION_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CONDICION_DE_VENTA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IMAGENES_DE_PRODUCTOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents REGISTRO_DE_HARDWARE_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LISTADOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MENU_VENTAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VENTAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ENVIAR_COTIZACION_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CARTOLA_KARDEX_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents COMISION_VENDEDORES_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents COMISION_POR_SERVICIOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents COTIZACION_FORMAL_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CAMBIO_DE_PRODUCTOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MIS_DOCUMENTOS_EMITIDOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TICKET_DE_VENTAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AUTORIZACIONES_DE_VENTAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VENTAS_ASISTIDAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BUSCADOR_DE_PRODUCTOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ADMINISTRAR_SERVICIOS_DE_LUBRICENTRO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CALCULADORA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RECEPCION_DE_TRABAJO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LISTADO_DE_VALES_DE_CAMBIO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ESTADISTICAS_DE_VENTA_POR_PRODUCTOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents COMISIONES_POR_VENDEDOR_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DOCUMENTOS_CON_PAGOS_COMBINADOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BUSCAR_DOCUMENTO_DE_CAMBIO_DE_PRODUCTO_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CONFIGURACION_CORREO_DE_VENTAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CONFIGURACION_CORREO_DE_ADMINISTRACION_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ASOCIAR_CLIENTES_A_EMPRESAS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CAMBIO_DE_CONTRASEÑA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RUTA_PARA_RESPALDOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MODIFICAR_CREDITOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents REVISION_DE_STOCK_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MANTENCION_DE_PROPIEDADES_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IMAGENES_DE_PRODUCTOS_PARA_PUBLICIDAD_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents REGISTRODEFACTURASDEUDAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TARJETA_DE_PRESENTACION_RAPIDA_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PRODUCTOSPAGINAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PRODUCTOS_CON_MAS_MOVIMIENTOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LIBRO_DE_COMPRAS_IMPRESION_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FffffToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
