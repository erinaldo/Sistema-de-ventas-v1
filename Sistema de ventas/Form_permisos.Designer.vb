<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_permisos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_permisos))
        Me.txt_nombre = New System.Windows.Forms.TextBox
        Me.Check_clientes = New System.Windows.Forms.CheckBox
        Me.Check_usuarios = New System.Windows.Forms.CheckBox
        Me.Check_productos = New System.Windows.Forms.CheckBox
        Me.Check_proveedores = New System.Windows.Forms.CheckBox
        Me.Check_retiradores = New System.Windows.Forms.CheckBox
        Me.Check_ventas = New System.Windows.Forms.CheckBox
        Me.Check_cartola = New System.Windows.Forms.CheckBox
        Me.Check_facturacion = New System.Windows.Forms.CheckBox
        Me.Check_pagos = New System.Windows.Forms.CheckBox
        Me.Check_estados = New System.Windows.Forms.CheckBox
        Me.Check_deudores = New System.Windows.Forms.CheckBox
        Me.Check_nota_de_credito = New System.Windows.Forms.CheckBox
        Me.Check_caja = New System.Windows.Forms.CheckBox
        Me.Check_corregir = New System.Windows.Forms.CheckBox
        Me.Check_comisiones = New System.Windows.Forms.CheckBox
        Me.Check_vencidas = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_ultimo = New System.Windows.Forms.Button
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.btn_siguiente = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_primero = New System.Windows.Forms.Button
        Me.btn_anterior = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_modificar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Panel_1 = New System.Windows.Forms.Panel
        Me.Check_hojas_foleadas = New System.Windows.Forms.CheckBox
        Me.Check_estado_de_deudas = New System.Windows.Forms.CheckBox
        Me.Check_detalle_de_ventas_por_doc = New System.Windows.Forms.CheckBox
        Me.Check_detalle_de_ventas = New System.Windows.Forms.CheckBox
        Me.Check_cuentas_por_cobrar = New System.Windows.Forms.CheckBox
        Me.Check_historial_de_cuenta = New System.Windows.Forms.CheckBox
        Me.Check_nota_de_debito = New System.Windows.Forms.CheckBox
        Me.Check_agregar_abonos = New System.Windows.Forms.CheckBox
        Me.Check_CORREGIR_numeros = New System.Windows.Forms.CheckBox
        Me.Check_buscar_facturas = New System.Windows.Forms.CheckBox
        Me.Check_ingreso_de_creditos = New System.Windows.Forms.CheckBox
        Me.Check_ingreso_manual_de_ventas = New System.Windows.Forms.CheckBox
        Me.Check_menu_administracion = New System.Windows.Forms.CheckBox
        Me.Check_libro_de_compra = New System.Windows.Forms.CheckBox
        Me.Check_estadistica = New System.Windows.Forms.CheckBox
        Me.Check_buscar_totales = New System.Windows.Forms.CheckBox
        Me.Check_libro_de_ventas = New System.Windows.Forms.CheckBox
        Me.Check_reporte_libro_de_compra = New System.Windows.Forms.CheckBox
        Me.Check_resumen_libro_de_compra = New System.Windows.Forms.CheckBox
        Me.Check_traspaso_de_stock = New System.Windows.Forms.CheckBox
        Me.Check_imputar_notas_de_credito = New System.Windows.Forms.CheckBox
        Me.Check_estados_cuenta_rango = New System.Windows.Forms.CheckBox
        Me.Check_imputar_abono = New System.Windows.Forms.CheckBox
        Me.Check_agregar_marcas = New System.Windows.Forms.CheckBox
        Me.Check_stock_y_ubicaciones = New System.Windows.Forms.CheckBox
        Me.Check_enviar_cotizacion = New System.Windows.Forms.CheckBox
        Me.Check_cotizacion_formal = New System.Windows.Forms.CheckBox
        Me.Check_subfamilias = New System.Windows.Forms.CheckBox
        Me.Check_menu_mantenedores = New System.Windows.Forms.CheckBox
        Me.Check_familias = New System.Windows.Forms.CheckBox
        Me.Check_menu_ventas = New System.Windows.Forms.CheckBox
        Me.Check_cuentas_corrientes = New System.Windows.Forms.CheckBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txt_rut = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Panel_3 = New System.Windows.Forms.Panel
        Me.CheckBox_adm_servicios_de_lubricentro = New System.Windows.Forms.CheckBox
        Me.CheckBox_servicios_de_lubricentro = New System.Windows.Forms.CheckBox
        Me.Check_adm_vales_de_cambio = New System.Windows.Forms.CheckBox
        Me.Check_ventas_asistidas = New System.Windows.Forms.CheckBox
        Me.Check_registro_de_autorizaciones = New System.Windows.Forms.CheckBox
        Me.Check_subfamilias2 = New System.Windows.Forms.CheckBox
        Me.Check_tarjetas_de_presentacion = New System.Windows.Forms.CheckBox
        Me.Check_ticket_de_ventas = New System.Windows.Forms.CheckBox
        Me.Check_mis_cotizaciones = New System.Windows.Forms.CheckBox
        Me.Check_cambio_de_productos = New System.Windows.Forms.CheckBox
        Me.Check_comision_servicios = New System.Windows.Forms.CheckBox
        Me.Check_proveedores_mas_pedidos = New System.Windows.Forms.CheckBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Panel_2 = New System.Windows.Forms.Panel
        Me.Check_existencias = New System.Windows.Forms.CheckBox
        Me.check_traspasar_stock_fisico = New System.Windows.Forms.CheckBox
        Me.Check_traspaso_de_creditos_a_historico = New System.Windows.Forms.CheckBox
        Me.Check_actualizar_stock = New System.Windows.Forms.CheckBox
        Me.Check_asignar_familias = New System.Windows.Forms.CheckBox
        Me.Check_guias_de_traslado = New System.Windows.Forms.CheckBox
        Me.Check_detalle_compras_por_doc = New System.Windows.Forms.CheckBox
        Me.Check_detalle_compras = New System.Windows.Forms.CheckBox
        Me.Check_personalizar_sistema = New System.Windows.Forms.CheckBox
        Me.Check_consultas = New System.Windows.Forms.CheckBox
        Me.Check_reservas = New System.Windows.Forms.CheckBox
        Me.Check_bitacora_de_cambios = New System.Windows.Forms.CheckBox
        Me.Check_confirmacion_de_llegada = New System.Windows.Forms.CheckBox
        Me.Check_ruta_para_archivos_planos = New System.Windows.Forms.CheckBox
        Me.Check_compras = New System.Windows.Forms.CheckBox
        Me.Check_ruta_para_imagenes_de_sistema = New System.Windows.Forms.CheckBox
        Me.Check_revision_de_pedidos = New System.Windows.Forms.CheckBox
        Me.Check_inventario = New System.Windows.Forms.CheckBox
        Me.Check_etiquetas = New System.Windows.Forms.CheckBox
        Me.Check_envio_a_sucursal = New System.Windows.Forms.CheckBox
        Me.Check_mis_pedidos = New System.Windows.Forms.CheckBox
        Me.Check_codigos_de_barra = New System.Windows.Forms.CheckBox
        Me.Check_menu_adquisiciones = New System.Windows.Forms.CheckBox
        Me.Check_valores = New System.Windows.Forms.CheckBox
        Me.Check_realizar_pedidos = New System.Windows.Forms.CheckBox
        Me.Check_respaldo = New System.Windows.Forms.CheckBox
        Me.Check_menu_bodega = New System.Windows.Forms.CheckBox
        Me.Check_empresa = New System.Windows.Forms.CheckBox
        Me.Check_stock_minimo = New System.Windows.Forms.CheckBox
        Me.Check_impresoras = New System.Windows.Forms.CheckBox
        Me.Check_numeracion = New System.Windows.Forms.CheckBox
        Me.Check_menu_configuracion = New System.Windows.Forms.CheckBox
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.Check_registro_de_actualizaciones = New System.Windows.Forms.CheckBox
        Me.Check_actualizar_sistema = New System.Windows.Forms.CheckBox
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel_1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel_3.SuspendLayout()
        Me.Panel_2.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_nombre
        '
        Me.txt_nombre.BackColor = System.Drawing.SystemColors.Window
        Me.txt_nombre.Enabled = False
        Me.txt_nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre.Location = New System.Drawing.Point(112, 34)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(192, 24)
        Me.txt_nombre.TabIndex = 28
        '
        'Check_clientes
        '
        Me.Check_clientes.AutoSize = True
        Me.Check_clientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_clientes.Location = New System.Drawing.Point(21, 41)
        Me.Check_clientes.Name = "Check_clientes"
        Me.Check_clientes.Size = New System.Drawing.Size(214, 20)
        Me.Check_clientes.TabIndex = 2
        Me.Check_clientes.TabStop = False
        Me.Check_clientes.Text = "MANTENEDOR DE CLIENTES"
        Me.Check_clientes.UseVisualStyleBackColor = True
        '
        'Check_usuarios
        '
        Me.Check_usuarios.AutoSize = True
        Me.Check_usuarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_usuarios.Location = New System.Drawing.Point(21, 61)
        Me.Check_usuarios.Name = "Check_usuarios"
        Me.Check_usuarios.Size = New System.Drawing.Size(219, 20)
        Me.Check_usuarios.TabIndex = 2
        Me.Check_usuarios.TabStop = False
        Me.Check_usuarios.Text = "MANTENEDOR DE USUARIOS"
        Me.Check_usuarios.UseVisualStyleBackColor = True
        '
        'Check_productos
        '
        Me.Check_productos.AutoSize = True
        Me.Check_productos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_productos.Location = New System.Drawing.Point(21, 81)
        Me.Check_productos.Name = "Check_productos"
        Me.Check_productos.Size = New System.Drawing.Size(235, 20)
        Me.Check_productos.TabIndex = 2
        Me.Check_productos.TabStop = False
        Me.Check_productos.Text = "MANTENEDOR DE PRODUCTOS"
        Me.Check_productos.UseVisualStyleBackColor = True
        '
        'Check_proveedores
        '
        Me.Check_proveedores.AutoSize = True
        Me.Check_proveedores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_proveedores.Location = New System.Drawing.Point(21, 101)
        Me.Check_proveedores.Name = "Check_proveedores"
        Me.Check_proveedores.Size = New System.Drawing.Size(253, 20)
        Me.Check_proveedores.TabIndex = 2
        Me.Check_proveedores.TabStop = False
        Me.Check_proveedores.Text = "MANTENEDOR DE PROVEEDORES"
        Me.Check_proveedores.UseVisualStyleBackColor = True
        '
        'Check_retiradores
        '
        Me.Check_retiradores.AutoSize = True
        Me.Check_retiradores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_retiradores.Location = New System.Drawing.Point(21, 121)
        Me.Check_retiradores.Name = "Check_retiradores"
        Me.Check_retiradores.Size = New System.Drawing.Size(247, 20)
        Me.Check_retiradores.TabIndex = 2
        Me.Check_retiradores.TabStop = False
        Me.Check_retiradores.Text = "MANTENEDOR DE RETIRADORES"
        Me.Check_retiradores.UseVisualStyleBackColor = True
        '
        'Check_ventas
        '
        Me.Check_ventas.AutoSize = True
        Me.Check_ventas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_ventas.Location = New System.Drawing.Point(21, 328)
        Me.Check_ventas.Name = "Check_ventas"
        Me.Check_ventas.Size = New System.Drawing.Size(82, 20)
        Me.Check_ventas.TabIndex = 2
        Me.Check_ventas.TabStop = False
        Me.Check_ventas.Text = "VENTAS"
        Me.Check_ventas.UseVisualStyleBackColor = True
        '
        'Check_cartola
        '
        Me.Check_cartola.AutoSize = True
        Me.Check_cartola.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_cartola.Location = New System.Drawing.Point(21, 428)
        Me.Check_cartola.Name = "Check_cartola"
        Me.Check_cartola.Size = New System.Drawing.Size(147, 20)
        Me.Check_cartola.TabIndex = 2
        Me.Check_cartola.TabStop = False
        Me.Check_cartola.Text = "CARTOLA KARDEX"
        Me.Check_cartola.UseVisualStyleBackColor = True
        '
        'Check_facturacion
        '
        Me.Check_facturacion.AutoSize = True
        Me.Check_facturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_facturacion.Location = New System.Drawing.Point(16, 141)
        Me.Check_facturacion.Name = "Check_facturacion"
        Me.Check_facturacion.Size = New System.Drawing.Size(189, 20)
        Me.Check_facturacion.TabIndex = 2
        Me.Check_facturacion.TabStop = False
        Me.Check_facturacion.Text = "FACTURACION DE GUIAS"
        Me.Check_facturacion.UseVisualStyleBackColor = True
        '
        'Check_pagos
        '
        Me.Check_pagos.AutoSize = True
        Me.Check_pagos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_pagos.Location = New System.Drawing.Point(16, 161)
        Me.Check_pagos.Name = "Check_pagos"
        Me.Check_pagos.Size = New System.Drawing.Size(173, 20)
        Me.Check_pagos.TabIndex = 2
        Me.Check_pagos.TabStop = False
        Me.Check_pagos.Text = "ABONOS SIN IMPUTAR"
        Me.Check_pagos.UseVisualStyleBackColor = True
        '
        'Check_estados
        '
        Me.Check_estados.AutoSize = True
        Me.Check_estados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_estados.Location = New System.Drawing.Point(16, 620)
        Me.Check_estados.Name = "Check_estados"
        Me.Check_estados.Size = New System.Drawing.Size(193, 20)
        Me.Check_estados.TabIndex = 2
        Me.Check_estados.TabStop = False
        Me.Check_estados.Text = "REPORTES DE EMPRESA"
        Me.Check_estados.UseVisualStyleBackColor = True
        '
        'Check_deudores
        '
        Me.Check_deudores.AutoSize = True
        Me.Check_deudores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_deudores.Location = New System.Drawing.Point(16, 181)
        Me.Check_deudores.Name = "Check_deudores"
        Me.Check_deudores.Size = New System.Drawing.Size(104, 20)
        Me.Check_deudores.TabIndex = 2
        Me.Check_deudores.TabStop = False
        Me.Check_deudores.Text = "DEUDORES"
        Me.Check_deudores.UseVisualStyleBackColor = True
        '
        'Check_nota_de_credito
        '
        Me.Check_nota_de_credito.AutoSize = True
        Me.Check_nota_de_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_nota_de_credito.Location = New System.Drawing.Point(16, 359)
        Me.Check_nota_de_credito.Name = "Check_nota_de_credito"
        Me.Check_nota_de_credito.Size = New System.Drawing.Size(159, 20)
        Me.Check_nota_de_credito.TabIndex = 2
        Me.Check_nota_de_credito.TabStop = False
        Me.Check_nota_de_credito.Text = "NOTAS DE CREDITO"
        Me.Check_nota_de_credito.UseVisualStyleBackColor = True
        '
        'Check_caja
        '
        Me.Check_caja.AutoSize = True
        Me.Check_caja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_caja.Location = New System.Drawing.Point(16, 41)
        Me.Check_caja.Name = "Check_caja"
        Me.Check_caja.Size = New System.Drawing.Size(155, 20)
        Me.Check_caja.TabIndex = 2
        Me.Check_caja.TabStop = False
        Me.Check_caja.Text = "OPCIONES DE CAJA"
        Me.Check_caja.UseVisualStyleBackColor = True
        '
        'Check_corregir
        '
        Me.Check_corregir.AutoSize = True
        Me.Check_corregir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_corregir.Location = New System.Drawing.Point(16, 61)
        Me.Check_corregir.Name = "Check_corregir"
        Me.Check_corregir.Size = New System.Drawing.Size(208, 20)
        Me.Check_corregir.TabIndex = 2
        Me.Check_corregir.TabStop = False
        Me.Check_corregir.Text = "CORREGIR DOCUMENTOS"
        Me.Check_corregir.UseVisualStyleBackColor = True
        '
        'Check_comisiones
        '
        Me.Check_comisiones.AutoSize = True
        Me.Check_comisiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_comisiones.Location = New System.Drawing.Point(21, 348)
        Me.Check_comisiones.Name = "Check_comisiones"
        Me.Check_comisiones.Size = New System.Drawing.Size(110, 20)
        Me.Check_comisiones.TabIndex = 2
        Me.Check_comisiones.TabStop = False
        Me.Check_comisiones.Text = "COMISIONES"
        Me.Check_comisiones.UseVisualStyleBackColor = True
        '
        'Check_vencidas
        '
        Me.Check_vencidas.AutoSize = True
        Me.Check_vencidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_vencidas.Location = New System.Drawing.Point(16, 101)
        Me.Check_vencidas.Name = "Check_vencidas"
        Me.Check_vencidas.Size = New System.Drawing.Size(195, 20)
        Me.Check_vencidas.TabIndex = 2
        Me.Check_vencidas.TabStop = False
        Me.Check_vencidas.Text = "REGISTRO DE FACTURAS"
        Me.Check_vencidas.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.GroupBox2.Controls.Add(Me.btn_ultimo)
        Me.GroupBox2.Controls.Add(Me.btn_buscar)
        Me.GroupBox2.Controls.Add(Me.btn_siguiente)
        Me.GroupBox2.Controls.Add(Me.btn_salir)
        Me.GroupBox2.Controls.Add(Me.btn_primero)
        Me.GroupBox2.Controls.Add(Me.btn_anterior)
        Me.GroupBox2.Controls.Add(Me.btn_cancelar)
        Me.GroupBox2.Controls.Add(Me.btn_modificar)
        Me.GroupBox2.Controls.Add(Me.btn_guardar)
        Me.GroupBox2.Location = New System.Drawing.Point(323, 58)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(689, 66)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'btn_ultimo
        '
        Me.btn_ultimo.BackColor = System.Drawing.Color.Transparent
        Me.btn_ultimo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_ultimo.Image = CType(resources.GetObject("btn_ultimo.Image"), System.Drawing.Image)
        Me.btn_ultimo.Location = New System.Drawing.Point(142, 16)
        Me.btn_ultimo.Name = "btn_ultimo"
        Me.btn_ultimo.Size = New System.Drawing.Size(40, 40)
        Me.btn_ultimo.TabIndex = 4
        Me.btn_ultimo.UseVisualStyleBackColor = False
        '
        'btn_buscar
        '
        Me.btn_buscar.BackColor = System.Drawing.Color.Transparent
        Me.btn_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = CType(resources.GetObject("btn_buscar.Image"), System.Drawing.Image)
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_buscar.Location = New System.Drawing.Point(187, 16)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(95, 40)
        Me.btn_buscar.TabIndex = 5
        Me.btn_buscar.Text = "BUSCAR"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_buscar.UseVisualStyleBackColor = False
        '
        'btn_siguiente
        '
        Me.btn_siguiente.BackColor = System.Drawing.Color.Transparent
        Me.btn_siguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_siguiente.Image = CType(resources.GetObject("btn_siguiente.Image"), System.Drawing.Image)
        Me.btn_siguiente.Location = New System.Drawing.Point(97, 16)
        Me.btn_siguiente.Name = "btn_siguiente"
        Me.btn_siguiente.Size = New System.Drawing.Size(40, 40)
        Me.btn_siguiente.TabIndex = 3
        Me.btn_siguiente.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(587, 16)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
        Me.btn_salir.TabIndex = 9
        Me.btn_salir.Text = "SALIR"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_primero
        '
        Me.btn_primero.BackColor = System.Drawing.Color.Transparent
        Me.btn_primero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_primero.Image = CType(resources.GetObject("btn_primero.Image"), System.Drawing.Image)
        Me.btn_primero.Location = New System.Drawing.Point(7, 16)
        Me.btn_primero.Name = "btn_primero"
        Me.btn_primero.Size = New System.Drawing.Size(40, 40)
        Me.btn_primero.TabIndex = 1
        Me.btn_primero.UseVisualStyleBackColor = False
        '
        'btn_anterior
        '
        Me.btn_anterior.BackColor = System.Drawing.Color.Transparent
        Me.btn_anterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_anterior.Image = CType(resources.GetObject("btn_anterior.Image"), System.Drawing.Image)
        Me.btn_anterior.Location = New System.Drawing.Point(52, 16)
        Me.btn_anterior.Name = "btn_anterior"
        Me.btn_anterior.Size = New System.Drawing.Size(40, 40)
        Me.btn_anterior.TabIndex = 2
        Me.btn_anterior.UseVisualStyleBackColor = False
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.Transparent
        Me.btn_cancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(487, 16)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(95, 40)
        Me.btn_cancelar.TabIndex = 8
        Me.btn_cancelar.Text = "CANCELAR"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'btn_modificar
        '
        Me.btn_modificar.BackColor = System.Drawing.Color.Transparent
        Me.btn_modificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_modificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_modificar.Image = CType(resources.GetObject("btn_modificar.Image"), System.Drawing.Image)
        Me.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_modificar.Location = New System.Drawing.Point(287, 16)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(95, 40)
        Me.btn_modificar.TabIndex = 6
        Me.btn_modificar.Text = "MODIFICAR"
        Me.btn_modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_modificar.UseVisualStyleBackColor = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.Transparent
        Me.btn_guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.Location = New System.Drawing.Point(387, 16)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(95, 40)
        Me.btn_guardar.TabIndex = 7
        Me.btn_guardar.Text = "GUARDAR"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.GroupBox1.Controls.Add(Me.Panel_1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 124)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(331, 570)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'Panel_1
        '
        Me.Panel_1.AutoScroll = True
        Me.Panel_1.BackColor = System.Drawing.Color.Transparent
        Me.Panel_1.Controls.Add(Me.Check_hojas_foleadas)
        Me.Panel_1.Controls.Add(Me.Check_estado_de_deudas)
        Me.Panel_1.Controls.Add(Me.Check_detalle_de_ventas_por_doc)
        Me.Panel_1.Controls.Add(Me.Check_detalle_de_ventas)
        Me.Panel_1.Controls.Add(Me.Check_cuentas_por_cobrar)
        Me.Panel_1.Controls.Add(Me.Check_historial_de_cuenta)
        Me.Panel_1.Controls.Add(Me.Check_nota_de_debito)
        Me.Panel_1.Controls.Add(Me.Check_agregar_abonos)
        Me.Panel_1.Controls.Add(Me.Check_CORREGIR_numeros)
        Me.Panel_1.Controls.Add(Me.Check_buscar_facturas)
        Me.Panel_1.Controls.Add(Me.Check_pagos)
        Me.Panel_1.Controls.Add(Me.Check_ingreso_de_creditos)
        Me.Panel_1.Controls.Add(Me.Check_nota_de_credito)
        Me.Panel_1.Controls.Add(Me.Check_vencidas)
        Me.Panel_1.Controls.Add(Me.Check_facturacion)
        Me.Panel_1.Controls.Add(Me.Check_ingreso_manual_de_ventas)
        Me.Panel_1.Controls.Add(Me.Check_menu_administracion)
        Me.Panel_1.Controls.Add(Me.Check_deudores)
        Me.Panel_1.Controls.Add(Me.Check_caja)
        Me.Panel_1.Controls.Add(Me.Check_libro_de_compra)
        Me.Panel_1.Controls.Add(Me.Check_corregir)
        Me.Panel_1.Controls.Add(Me.Check_estadistica)
        Me.Panel_1.Controls.Add(Me.Check_buscar_totales)
        Me.Panel_1.Controls.Add(Me.Check_libro_de_ventas)
        Me.Panel_1.Controls.Add(Me.Check_reporte_libro_de_compra)
        Me.Panel_1.Controls.Add(Me.Check_resumen_libro_de_compra)
        Me.Panel_1.Controls.Add(Me.Check_traspaso_de_stock)
        Me.Panel_1.Controls.Add(Me.Check_imputar_notas_de_credito)
        Me.Panel_1.Controls.Add(Me.Check_estados_cuenta_rango)
        Me.Panel_1.Controls.Add(Me.Check_estados)
        Me.Panel_1.Controls.Add(Me.Check_imputar_abono)
        Me.Panel_1.Location = New System.Drawing.Point(2, 8)
        Me.Panel_1.Name = "Panel_1"
        Me.Panel_1.Size = New System.Drawing.Size(327, 559)
        Me.Panel_1.TabIndex = 47
        '
        'Check_hojas_foleadas
        '
        Me.Check_hojas_foleadas.AutoSize = True
        Me.Check_hojas_foleadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_hojas_foleadas.Location = New System.Drawing.Point(16, 600)
        Me.Check_hojas_foleadas.Name = "Check_hojas_foleadas"
        Me.Check_hojas_foleadas.Size = New System.Drawing.Size(146, 20)
        Me.Check_hojas_foleadas.TabIndex = 53
        Me.Check_hojas_foleadas.TabStop = False
        Me.Check_hojas_foleadas.Text = "HOJAS FOLEADAS"
        Me.Check_hojas_foleadas.UseVisualStyleBackColor = True
        '
        'Check_estado_de_deudas
        '
        Me.Check_estado_de_deudas.AutoSize = True
        Me.Check_estado_de_deudas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_estado_de_deudas.Location = New System.Drawing.Point(16, 580)
        Me.Check_estado_de_deudas.Name = "Check_estado_de_deudas"
        Me.Check_estado_de_deudas.Size = New System.Drawing.Size(165, 20)
        Me.Check_estado_de_deudas.TabIndex = 52
        Me.Check_estado_de_deudas.TabStop = False
        Me.Check_estado_de_deudas.Text = "ESTADO DE DEUDAS"
        Me.Check_estado_de_deudas.UseVisualStyleBackColor = True
        '
        'Check_detalle_de_ventas_por_doc
        '
        Me.Check_detalle_de_ventas_por_doc.AutoSize = True
        Me.Check_detalle_de_ventas_por_doc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_detalle_de_ventas_por_doc.Location = New System.Drawing.Point(16, 500)
        Me.Check_detalle_de_ventas_por_doc.Name = "Check_detalle_de_ventas_por_doc"
        Me.Check_detalle_de_ventas_por_doc.Size = New System.Drawing.Size(234, 20)
        Me.Check_detalle_de_ventas_por_doc.TabIndex = 51
        Me.Check_detalle_de_ventas_por_doc.TabStop = False
        Me.Check_detalle_de_ventas_por_doc.Text = "DETALLE DE VENTAS POR DOC."
        Me.Check_detalle_de_ventas_por_doc.UseVisualStyleBackColor = True
        '
        'Check_detalle_de_ventas
        '
        Me.Check_detalle_de_ventas.AutoSize = True
        Me.Check_detalle_de_ventas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_detalle_de_ventas.Location = New System.Drawing.Point(16, 480)
        Me.Check_detalle_de_ventas.Name = "Check_detalle_de_ventas"
        Me.Check_detalle_de_ventas.Size = New System.Drawing.Size(167, 20)
        Me.Check_detalle_de_ventas.TabIndex = 50
        Me.Check_detalle_de_ventas.TabStop = False
        Me.Check_detalle_de_ventas.Text = "DETALLE DE VENTAS"
        Me.Check_detalle_de_ventas.UseVisualStyleBackColor = True
        '
        'Check_cuentas_por_cobrar
        '
        Me.Check_cuentas_por_cobrar.AutoSize = True
        Me.Check_cuentas_por_cobrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_cuentas_por_cobrar.Location = New System.Drawing.Point(16, 520)
        Me.Check_cuentas_por_cobrar.Name = "Check_cuentas_por_cobrar"
        Me.Check_cuentas_por_cobrar.Size = New System.Drawing.Size(184, 20)
        Me.Check_cuentas_por_cobrar.TabIndex = 49
        Me.Check_cuentas_por_cobrar.TabStop = False
        Me.Check_cuentas_por_cobrar.Text = "CUENTAS POR COBRAR"
        Me.Check_cuentas_por_cobrar.UseVisualStyleBackColor = True
        '
        'Check_historial_de_cuenta
        '
        Me.Check_historial_de_cuenta.AutoSize = True
        Me.Check_historial_de_cuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_historial_de_cuenta.Location = New System.Drawing.Point(16, 540)
        Me.Check_historial_de_cuenta.Name = "Check_historial_de_cuenta"
        Me.Check_historial_de_cuenta.Size = New System.Drawing.Size(178, 20)
        Me.Check_historial_de_cuenta.TabIndex = 47
        Me.Check_historial_de_cuenta.TabStop = False
        Me.Check_historial_de_cuenta.Text = "HISTORIAL DE CUENTA"
        Me.Check_historial_de_cuenta.UseVisualStyleBackColor = True
        '
        'Check_nota_de_debito
        '
        Me.Check_nota_de_debito.AutoSize = True
        Me.Check_nota_de_debito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_nota_de_debito.Location = New System.Drawing.Point(16, 560)
        Me.Check_nota_de_debito.Name = "Check_nota_de_debito"
        Me.Check_nota_de_debito.Size = New System.Drawing.Size(149, 20)
        Me.Check_nota_de_debito.TabIndex = 48
        Me.Check_nota_de_debito.TabStop = False
        Me.Check_nota_de_debito.Text = "NOTAS DE DEBITO"
        Me.Check_nota_de_debito.UseVisualStyleBackColor = True
        '
        'Check_agregar_abonos
        '
        Me.Check_agregar_abonos.AutoSize = True
        Me.Check_agregar_abonos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_agregar_abonos.Location = New System.Drawing.Point(16, 399)
        Me.Check_agregar_abonos.Name = "Check_agregar_abonos"
        Me.Check_agregar_abonos.Size = New System.Drawing.Size(154, 20)
        Me.Check_agregar_abonos.TabIndex = 46
        Me.Check_agregar_abonos.TabStop = False
        Me.Check_agregar_abonos.Text = "AGREGAR ABONOS"
        Me.Check_agregar_abonos.UseVisualStyleBackColor = True
        '
        'Check_CORREGIR_numeros
        '
        Me.Check_CORREGIR_numeros.AutoSize = True
        Me.Check_CORREGIR_numeros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_CORREGIR_numeros.Location = New System.Drawing.Point(16, 319)
        Me.Check_CORREGIR_numeros.Name = "Check_CORREGIR_numeros"
        Me.Check_CORREGIR_numeros.Size = New System.Drawing.Size(279, 20)
        Me.Check_CORREGIR_numeros.TabIndex = 43
        Me.Check_CORREGIR_numeros.TabStop = False
        Me.Check_CORREGIR_numeros.Text = "CORREGIR NUMEROS DE IMPRESION"
        Me.Check_CORREGIR_numeros.UseVisualStyleBackColor = True
        '
        'Check_buscar_facturas
        '
        Me.Check_buscar_facturas.AutoSize = True
        Me.Check_buscar_facturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_buscar_facturas.Location = New System.Drawing.Point(16, 259)
        Me.Check_buscar_facturas.Name = "Check_buscar_facturas"
        Me.Check_buscar_facturas.Size = New System.Drawing.Size(159, 20)
        Me.Check_buscar_facturas.TabIndex = 22
        Me.Check_buscar_facturas.TabStop = False
        Me.Check_buscar_facturas.Text = "BUSCAR FACTURAS"
        Me.Check_buscar_facturas.UseVisualStyleBackColor = True
        '
        'Check_ingreso_de_creditos
        '
        Me.Check_ingreso_de_creditos.AutoSize = True
        Me.Check_ingreso_de_creditos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_ingreso_de_creditos.Location = New System.Drawing.Point(16, 379)
        Me.Check_ingreso_de_creditos.Name = "Check_ingreso_de_creditos"
        Me.Check_ingreso_de_creditos.Size = New System.Drawing.Size(182, 20)
        Me.Check_ingreso_de_creditos.TabIndex = 45
        Me.Check_ingreso_de_creditos.TabStop = False
        Me.Check_ingreso_de_creditos.Text = "INGRESO DE CREDITOS"
        Me.Check_ingreso_de_creditos.UseVisualStyleBackColor = True
        '
        'Check_ingreso_manual_de_ventas
        '
        Me.Check_ingreso_manual_de_ventas.AutoSize = True
        Me.Check_ingreso_manual_de_ventas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_ingreso_manual_de_ventas.Location = New System.Drawing.Point(16, 339)
        Me.Check_ingreso_manual_de_ventas.Name = "Check_ingreso_manual_de_ventas"
        Me.Check_ingreso_manual_de_ventas.Size = New System.Drawing.Size(227, 20)
        Me.Check_ingreso_manual_de_ventas.TabIndex = 44
        Me.Check_ingreso_manual_de_ventas.TabStop = False
        Me.Check_ingreso_manual_de_ventas.Text = "INGRESO MANUAL DE VENTAS"
        Me.Check_ingreso_manual_de_ventas.UseVisualStyleBackColor = True
        '
        'Check_menu_administracion
        '
        Me.Check_menu_administracion.AutoSize = True
        Me.Check_menu_administracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_menu_administracion.Location = New System.Drawing.Point(16, 21)
        Me.Check_menu_administracion.Name = "Check_menu_administracion"
        Me.Check_menu_administracion.Size = New System.Drawing.Size(204, 20)
        Me.Check_menu_administracion.TabIndex = 12
        Me.Check_menu_administracion.TabStop = False
        Me.Check_menu_administracion.Text = "MENU ADMINISTRACION"
        Me.Check_menu_administracion.UseVisualStyleBackColor = True
        '
        'Check_libro_de_compra
        '
        Me.Check_libro_de_compra.AutoSize = True
        Me.Check_libro_de_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_libro_de_compra.Location = New System.Drawing.Point(16, 219)
        Me.Check_libro_de_compra.Name = "Check_libro_de_compra"
        Me.Check_libro_de_compra.Size = New System.Drawing.Size(158, 20)
        Me.Check_libro_de_compra.TabIndex = 11
        Me.Check_libro_de_compra.TabStop = False
        Me.Check_libro_de_compra.Text = "LIBRO DE COMPRAS"
        Me.Check_libro_de_compra.UseVisualStyleBackColor = True
        '
        'Check_estadistica
        '
        Me.Check_estadistica.AutoSize = True
        Me.Check_estadistica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_estadistica.Location = New System.Drawing.Point(16, 81)
        Me.Check_estadistica.Name = "Check_estadistica"
        Me.Check_estadistica.Size = New System.Drawing.Size(124, 20)
        Me.Check_estadistica.TabIndex = 3
        Me.Check_estadistica.TabStop = False
        Me.Check_estadistica.Text = "ESTADISTICAS"
        Me.Check_estadistica.UseVisualStyleBackColor = True
        '
        'Check_buscar_totales
        '
        Me.Check_buscar_totales.AutoSize = True
        Me.Check_buscar_totales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_buscar_totales.Location = New System.Drawing.Point(16, 299)
        Me.Check_buscar_totales.Name = "Check_buscar_totales"
        Me.Check_buscar_totales.Size = New System.Drawing.Size(148, 20)
        Me.Check_buscar_totales.TabIndex = 41
        Me.Check_buscar_totales.TabStop = False
        Me.Check_buscar_totales.Text = "BUSCAR TOTALES"
        Me.Check_buscar_totales.UseVisualStyleBackColor = True
        '
        'Check_libro_de_ventas
        '
        Me.Check_libro_de_ventas.AutoSize = True
        Me.Check_libro_de_ventas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_libro_de_ventas.Location = New System.Drawing.Point(16, 279)
        Me.Check_libro_de_ventas.Name = "Check_libro_de_ventas"
        Me.Check_libro_de_ventas.Size = New System.Drawing.Size(146, 20)
        Me.Check_libro_de_ventas.TabIndex = 28
        Me.Check_libro_de_ventas.TabStop = False
        Me.Check_libro_de_ventas.Text = "LIBRO DE VENTAS"
        Me.Check_libro_de_ventas.UseVisualStyleBackColor = True
        '
        'Check_reporte_libro_de_compra
        '
        Me.Check_reporte_libro_de_compra.AutoSize = True
        Me.Check_reporte_libro_de_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_reporte_libro_de_compra.Location = New System.Drawing.Point(16, 199)
        Me.Check_reporte_libro_de_compra.Name = "Check_reporte_libro_de_compra"
        Me.Check_reporte_libro_de_compra.Size = New System.Drawing.Size(227, 20)
        Me.Check_reporte_libro_de_compra.TabIndex = 21
        Me.Check_reporte_libro_de_compra.TabStop = False
        Me.Check_reporte_libro_de_compra.Text = "REPORTE LIBRO DE COMPRAS"
        Me.Check_reporte_libro_de_compra.UseVisualStyleBackColor = True
        '
        'Check_resumen_libro_de_compra
        '
        Me.Check_resumen_libro_de_compra.AutoSize = True
        Me.Check_resumen_libro_de_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_resumen_libro_de_compra.Location = New System.Drawing.Point(16, 239)
        Me.Check_resumen_libro_de_compra.Name = "Check_resumen_libro_de_compra"
        Me.Check_resumen_libro_de_compra.Size = New System.Drawing.Size(251, 20)
        Me.Check_resumen_libro_de_compra.TabIndex = 9
        Me.Check_resumen_libro_de_compra.TabStop = False
        Me.Check_resumen_libro_de_compra.Text = "RESUMEN DE LIBRO DE COMPRAS"
        Me.Check_resumen_libro_de_compra.UseVisualStyleBackColor = True
        '
        'Check_traspaso_de_stock
        '
        Me.Check_traspaso_de_stock.AutoSize = True
        Me.Check_traspaso_de_stock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_traspaso_de_stock.Location = New System.Drawing.Point(16, 420)
        Me.Check_traspaso_de_stock.Name = "Check_traspaso_de_stock"
        Me.Check_traspaso_de_stock.Size = New System.Drawing.Size(171, 20)
        Me.Check_traspaso_de_stock.TabIndex = 40
        Me.Check_traspaso_de_stock.TabStop = False
        Me.Check_traspaso_de_stock.Text = "TRASPASO DE STOCK"
        Me.Check_traspaso_de_stock.UseVisualStyleBackColor = True
        '
        'Check_imputar_notas_de_credito
        '
        Me.Check_imputar_notas_de_credito.AutoSize = True
        Me.Check_imputar_notas_de_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_imputar_notas_de_credito.Location = New System.Drawing.Point(16, 440)
        Me.Check_imputar_notas_de_credito.Name = "Check_imputar_notas_de_credito"
        Me.Check_imputar_notas_de_credito.Size = New System.Drawing.Size(223, 20)
        Me.Check_imputar_notas_de_credito.TabIndex = 37
        Me.Check_imputar_notas_de_credito.TabStop = False
        Me.Check_imputar_notas_de_credito.Text = "IMPUTAR NOTAS DE CREDITO"
        Me.Check_imputar_notas_de_credito.UseVisualStyleBackColor = True
        '
        'Check_estados_cuenta_rango
        '
        Me.Check_estados_cuenta_rango.AutoSize = True
        Me.Check_estados_cuenta_rango.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_estados_cuenta_rango.Location = New System.Drawing.Point(16, 121)
        Me.Check_estados_cuenta_rango.Name = "Check_estados_cuenta_rango"
        Me.Check_estados_cuenta_rango.Size = New System.Drawing.Size(257, 20)
        Me.Check_estados_cuenta_rango.TabIndex = 27
        Me.Check_estados_cuenta_rango.TabStop = False
        Me.Check_estados_cuenta_rango.Text = "ESTADOS DE CUENTA POR RANGO"
        Me.Check_estados_cuenta_rango.UseVisualStyleBackColor = True
        '
        'Check_imputar_abono
        '
        Me.Check_imputar_abono.AutoSize = True
        Me.Check_imputar_abono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_imputar_abono.Location = New System.Drawing.Point(16, 460)
        Me.Check_imputar_abono.Name = "Check_imputar_abono"
        Me.Check_imputar_abono.Size = New System.Drawing.Size(139, 20)
        Me.Check_imputar_abono.TabIndex = 38
        Me.Check_imputar_abono.TabStop = False
        Me.Check_imputar_abono.Text = "IMPUTAR ABONO"
        Me.Check_imputar_abono.UseVisualStyleBackColor = True
        '
        'Check_agregar_marcas
        '
        Me.Check_agregar_marcas.AutoSize = True
        Me.Check_agregar_marcas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_agregar_marcas.Location = New System.Drawing.Point(21, 201)
        Me.Check_agregar_marcas.Name = "Check_agregar_marcas"
        Me.Check_agregar_marcas.Size = New System.Drawing.Size(206, 20)
        Me.Check_agregar_marcas.TabIndex = 32
        Me.Check_agregar_marcas.TabStop = False
        Me.Check_agregar_marcas.Text = "MANTENEDOR DE MARCAS"
        Me.Check_agregar_marcas.UseVisualStyleBackColor = True
        '
        'Check_stock_y_ubicaciones
        '
        Me.Check_stock_y_ubicaciones.AutoSize = True
        Me.Check_stock_y_ubicaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_stock_y_ubicaciones.Location = New System.Drawing.Point(21, 388)
        Me.Check_stock_y_ubicaciones.Name = "Check_stock_y_ubicaciones"
        Me.Check_stock_y_ubicaciones.Size = New System.Drawing.Size(177, 20)
        Me.Check_stock_y_ubicaciones.TabIndex = 29
        Me.Check_stock_y_ubicaciones.TabStop = False
        Me.Check_stock_y_ubicaciones.Text = "STOCK Y UBICACIONES"
        Me.Check_stock_y_ubicaciones.UseVisualStyleBackColor = True
        '
        'Check_enviar_cotizacion
        '
        Me.Check_enviar_cotizacion.AutoSize = True
        Me.Check_enviar_cotizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_enviar_cotizacion.Location = New System.Drawing.Point(21, 368)
        Me.Check_enviar_cotizacion.Name = "Check_enviar_cotizacion"
        Me.Check_enviar_cotizacion.Size = New System.Drawing.Size(160, 20)
        Me.Check_enviar_cotizacion.TabIndex = 28
        Me.Check_enviar_cotizacion.TabStop = False
        Me.Check_enviar_cotizacion.Text = "ENVIAR COTIZACION"
        Me.Check_enviar_cotizacion.UseVisualStyleBackColor = True
        '
        'Check_cotizacion_formal
        '
        Me.Check_cotizacion_formal.AutoSize = True
        Me.Check_cotizacion_formal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_cotizacion_formal.Location = New System.Drawing.Point(21, 408)
        Me.Check_cotizacion_formal.Name = "Check_cotizacion_formal"
        Me.Check_cotizacion_formal.Size = New System.Drawing.Size(165, 20)
        Me.Check_cotizacion_formal.TabIndex = 26
        Me.Check_cotizacion_formal.TabStop = False
        Me.Check_cotizacion_formal.Text = "COTIZACION FORMAL"
        Me.Check_cotizacion_formal.UseVisualStyleBackColor = True
        '
        'Check_subfamilias
        '
        Me.Check_subfamilias.AutoSize = True
        Me.Check_subfamilias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_subfamilias.Location = New System.Drawing.Point(21, 161)
        Me.Check_subfamilias.Name = "Check_subfamilias"
        Me.Check_subfamilias.Size = New System.Drawing.Size(236, 20)
        Me.Check_subfamilias.TabIndex = 2
        Me.Check_subfamilias.TabStop = False
        Me.Check_subfamilias.Text = "MANTENEDOR DE SUBFAMILIAS"
        Me.Check_subfamilias.UseVisualStyleBackColor = True
        '
        'Check_menu_mantenedores
        '
        Me.Check_menu_mantenedores.AutoSize = True
        Me.Check_menu_mantenedores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_menu_mantenedores.Location = New System.Drawing.Point(21, 21)
        Me.Check_menu_mantenedores.Name = "Check_menu_mantenedores"
        Me.Check_menu_mantenedores.Size = New System.Drawing.Size(202, 20)
        Me.Check_menu_mantenedores.TabIndex = 17
        Me.Check_menu_mantenedores.TabStop = False
        Me.Check_menu_mantenedores.Text = "MENU MANTENEDORES"
        Me.Check_menu_mantenedores.UseVisualStyleBackColor = True
        '
        'Check_familias
        '
        Me.Check_familias.AutoSize = True
        Me.Check_familias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_familias.Location = New System.Drawing.Point(21, 141)
        Me.Check_familias.Name = "Check_familias"
        Me.Check_familias.Size = New System.Drawing.Size(208, 20)
        Me.Check_familias.TabIndex = 2
        Me.Check_familias.TabStop = False
        Me.Check_familias.Text = "MANTENEDOR DE FAMILIAS"
        Me.Check_familias.UseVisualStyleBackColor = True
        '
        'Check_menu_ventas
        '
        Me.Check_menu_ventas.AutoSize = True
        Me.Check_menu_ventas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_menu_ventas.Location = New System.Drawing.Point(21, 308)
        Me.Check_menu_ventas.Name = "Check_menu_ventas"
        Me.Check_menu_ventas.Size = New System.Drawing.Size(136, 20)
        Me.Check_menu_ventas.TabIndex = 18
        Me.Check_menu_ventas.TabStop = False
        Me.Check_menu_ventas.Text = "MENU VENTAS"
        Me.Check_menu_ventas.UseVisualStyleBackColor = True
        '
        'Check_cuentas_corrientes
        '
        Me.Check_cuentas_corrientes.AutoSize = True
        Me.Check_cuentas_corrientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_cuentas_corrientes.Location = New System.Drawing.Point(21, 181)
        Me.Check_cuentas_corrientes.Name = "Check_cuentas_corrientes"
        Me.Check_cuentas_corrientes.Size = New System.Drawing.Size(229, 20)
        Me.Check_cuentas_corrientes.TabIndex = 10
        Me.Check_cuentas_corrientes.TabStop = False
        Me.Check_cuentas_corrientes.Text = "MANTENEDOR DE CUENTAS C."
        Me.Check_cuentas_corrientes.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txt_nombre)
        Me.GroupBox5.Controls.Add(Me.txt_rut)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(6, 57)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(311, 67)
        Me.GroupBox5.TabIndex = 278
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "DATOS DEL USUARIO"
        '
        'txt_rut
        '
        Me.txt_rut.BackColor = System.Drawing.SystemColors.Window
        Me.txt_rut.Enabled = False
        Me.txt_rut.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut.Location = New System.Drawing.Point(7, 34)
        Me.txt_rut.Name = "txt_rut"
        Me.txt_rut.Size = New System.Drawing.Size(99, 24)
        Me.txt_rut.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(111, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "NOMBRE:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "RUT:"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.GroupBox4.Controls.Add(Me.Panel_3)
        Me.GroupBox4.Location = New System.Drawing.Point(681, 124)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(331, 570)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        '
        'Panel_3
        '
        Me.Panel_3.AutoScroll = True
        Me.Panel_3.BackColor = System.Drawing.Color.Transparent
        Me.Panel_3.Controls.Add(Me.CheckBox_adm_servicios_de_lubricentro)
        Me.Panel_3.Controls.Add(Me.CheckBox_servicios_de_lubricentro)
        Me.Panel_3.Controls.Add(Me.Check_adm_vales_de_cambio)
        Me.Panel_3.Controls.Add(Me.Check_ventas_asistidas)
        Me.Panel_3.Controls.Add(Me.Check_registro_de_autorizaciones)
        Me.Panel_3.Controls.Add(Me.Check_subfamilias2)
        Me.Panel_3.Controls.Add(Me.Check_tarjetas_de_presentacion)
        Me.Panel_3.Controls.Add(Me.Check_ticket_de_ventas)
        Me.Panel_3.Controls.Add(Me.Check_mis_cotizaciones)
        Me.Panel_3.Controls.Add(Me.Check_menu_mantenedores)
        Me.Panel_3.Controls.Add(Me.Check_cambio_de_productos)
        Me.Panel_3.Controls.Add(Me.Check_clientes)
        Me.Panel_3.Controls.Add(Me.Check_comision_servicios)
        Me.Panel_3.Controls.Add(Me.Check_retiradores)
        Me.Panel_3.Controls.Add(Me.Check_proveedores_mas_pedidos)
        Me.Panel_3.Controls.Add(Me.Check_productos)
        Me.Panel_3.Controls.Add(Me.Check_cartola)
        Me.Panel_3.Controls.Add(Me.Check_familias)
        Me.Panel_3.Controls.Add(Me.Check_enviar_cotizacion)
        Me.Panel_3.Controls.Add(Me.Check_usuarios)
        Me.Panel_3.Controls.Add(Me.Check_stock_y_ubicaciones)
        Me.Panel_3.Controls.Add(Me.Check_subfamilias)
        Me.Panel_3.Controls.Add(Me.Check_comisiones)
        Me.Panel_3.Controls.Add(Me.Check_cuentas_corrientes)
        Me.Panel_3.Controls.Add(Me.Check_ventas)
        Me.Panel_3.Controls.Add(Me.Check_proveedores)
        Me.Panel_3.Controls.Add(Me.Check_menu_ventas)
        Me.Panel_3.Controls.Add(Me.Check_cotizacion_formal)
        Me.Panel_3.Controls.Add(Me.Check_agregar_marcas)
        Me.Panel_3.Location = New System.Drawing.Point(2, 8)
        Me.Panel_3.Name = "Panel_3"
        Me.Panel_3.Size = New System.Drawing.Size(327, 559)
        Me.Panel_3.TabIndex = 63
        '
        'CheckBox_adm_servicios_de_lubricentro
        '
        Me.CheckBox_adm_servicios_de_lubricentro.AutoSize = True
        Me.CheckBox_adm_servicios_de_lubricentro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_adm_servicios_de_lubricentro.Location = New System.Drawing.Point(21, 608)
        Me.CheckBox_adm_servicios_de_lubricentro.Name = "CheckBox_adm_servicios_de_lubricentro"
        Me.CheckBox_adm_servicios_de_lubricentro.Size = New System.Drawing.Size(255, 20)
        Me.CheckBox_adm_servicios_de_lubricentro.TabIndex = 44
        Me.CheckBox_adm_servicios_de_lubricentro.TabStop = False
        Me.CheckBox_adm_servicios_de_lubricentro.Text = "ADM. SERVICIOS DE LUBRICENTRO"
        Me.CheckBox_adm_servicios_de_lubricentro.UseVisualStyleBackColor = True
        '
        'CheckBox_servicios_de_lubricentro
        '
        Me.CheckBox_servicios_de_lubricentro.AutoSize = True
        Me.CheckBox_servicios_de_lubricentro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_servicios_de_lubricentro.Location = New System.Drawing.Point(21, 588)
        Me.CheckBox_servicios_de_lubricentro.Name = "CheckBox_servicios_de_lubricentro"
        Me.CheckBox_servicios_de_lubricentro.Size = New System.Drawing.Size(219, 20)
        Me.CheckBox_servicios_de_lubricentro.TabIndex = 43
        Me.CheckBox_servicios_de_lubricentro.TabStop = False
        Me.CheckBox_servicios_de_lubricentro.Text = "SERVICIOS DE LUBRICENTRO"
        Me.CheckBox_servicios_de_lubricentro.UseVisualStyleBackColor = True
        '
        'Check_adm_vales_de_cambio
        '
        Me.Check_adm_vales_de_cambio.AutoSize = True
        Me.Check_adm_vales_de_cambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_adm_vales_de_cambio.Location = New System.Drawing.Point(21, 568)
        Me.Check_adm_vales_de_cambio.Name = "Check_adm_vales_de_cambio"
        Me.Check_adm_vales_de_cambio.Size = New System.Drawing.Size(214, 20)
        Me.Check_adm_vales_de_cambio.TabIndex = 42
        Me.Check_adm_vales_de_cambio.TabStop = False
        Me.Check_adm_vales_de_cambio.Text = "BUSCADOR DE PRODUCTOS"
        Me.Check_adm_vales_de_cambio.UseVisualStyleBackColor = True
        '
        'Check_ventas_asistidas
        '
        Me.Check_ventas_asistidas.AutoSize = True
        Me.Check_ventas_asistidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_ventas_asistidas.Location = New System.Drawing.Point(21, 548)
        Me.Check_ventas_asistidas.Name = "Check_ventas_asistidas"
        Me.Check_ventas_asistidas.Size = New System.Drawing.Size(155, 20)
        Me.Check_ventas_asistidas.TabIndex = 41
        Me.Check_ventas_asistidas.TabStop = False
        Me.Check_ventas_asistidas.Text = "VENTAS ASISTIDAS"
        Me.Check_ventas_asistidas.UseVisualStyleBackColor = True
        '
        'Check_registro_de_autorizaciones
        '
        Me.Check_registro_de_autorizaciones.AutoSize = True
        Me.Check_registro_de_autorizaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_registro_de_autorizaciones.Location = New System.Drawing.Point(21, 528)
        Me.Check_registro_de_autorizaciones.Name = "Check_registro_de_autorizaciones"
        Me.Check_registro_de_autorizaciones.Size = New System.Drawing.Size(240, 20)
        Me.Check_registro_de_autorizaciones.TabIndex = 40
        Me.Check_registro_de_autorizaciones.TabStop = False
        Me.Check_registro_de_autorizaciones.Text = "REGISTRO DE AUTORIZACIONES"
        Me.Check_registro_de_autorizaciones.UseVisualStyleBackColor = True
        '
        'Check_subfamilias2
        '
        Me.Check_subfamilias2.AutoSize = True
        Me.Check_subfamilias2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_subfamilias2.Location = New System.Drawing.Point(21, 261)
        Me.Check_subfamilias2.Name = "Check_subfamilias2"
        Me.Check_subfamilias2.Size = New System.Drawing.Size(246, 20)
        Me.Check_subfamilias2.TabIndex = 39
        Me.Check_subfamilias2.TabStop = False
        Me.Check_subfamilias2.Text = "MANTENEDOR DE SUBFAMILIAS 2"
        Me.Check_subfamilias2.UseVisualStyleBackColor = True
        '
        'Check_tarjetas_de_presentacion
        '
        Me.Check_tarjetas_de_presentacion.AutoSize = True
        Me.Check_tarjetas_de_presentacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_tarjetas_de_presentacion.Location = New System.Drawing.Point(21, 241)
        Me.Check_tarjetas_de_presentacion.Name = "Check_tarjetas_de_presentacion"
        Me.Check_tarjetas_de_presentacion.Size = New System.Drawing.Size(220, 20)
        Me.Check_tarjetas_de_presentacion.TabIndex = 38
        Me.Check_tarjetas_de_presentacion.TabStop = False
        Me.Check_tarjetas_de_presentacion.Text = "MANTENEDOR DE TARJETAS"
        Me.Check_tarjetas_de_presentacion.UseVisualStyleBackColor = True
        '
        'Check_ticket_de_ventas
        '
        Me.Check_ticket_de_ventas.AutoSize = True
        Me.Check_ticket_de_ventas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_ticket_de_ventas.Location = New System.Drawing.Point(21, 508)
        Me.Check_ticket_de_ventas.Name = "Check_ticket_de_ventas"
        Me.Check_ticket_de_ventas.Size = New System.Drawing.Size(154, 20)
        Me.Check_ticket_de_ventas.TabIndex = 37
        Me.Check_ticket_de_ventas.TabStop = False
        Me.Check_ticket_de_ventas.Text = "TICKET DE VENTAS"
        Me.Check_ticket_de_ventas.UseVisualStyleBackColor = True
        '
        'Check_mis_cotizaciones
        '
        Me.Check_mis_cotizaciones.AutoSize = True
        Me.Check_mis_cotizaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_mis_cotizaciones.Location = New System.Drawing.Point(21, 488)
        Me.Check_mis_cotizaciones.Name = "Check_mis_cotizaciones"
        Me.Check_mis_cotizaciones.Size = New System.Drawing.Size(217, 20)
        Me.Check_mis_cotizaciones.TabIndex = 36
        Me.Check_mis_cotizaciones.TabStop = False
        Me.Check_mis_cotizaciones.Text = "MIS DOCUMENTOS EMITIDOS"
        Me.Check_mis_cotizaciones.UseVisualStyleBackColor = True
        '
        'Check_cambio_de_productos
        '
        Me.Check_cambio_de_productos.AutoSize = True
        Me.Check_cambio_de_productos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_cambio_de_productos.Location = New System.Drawing.Point(21, 468)
        Me.Check_cambio_de_productos.Name = "Check_cambio_de_productos"
        Me.Check_cambio_de_productos.Size = New System.Drawing.Size(189, 20)
        Me.Check_cambio_de_productos.TabIndex = 35
        Me.Check_cambio_de_productos.TabStop = False
        Me.Check_cambio_de_productos.Text = "CAMBIO DE PRODUCTOS"
        Me.Check_cambio_de_productos.UseVisualStyleBackColor = True
        '
        'Check_comision_servicios
        '
        Me.Check_comision_servicios.AutoSize = True
        Me.Check_comision_servicios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_comision_servicios.Location = New System.Drawing.Point(21, 448)
        Me.Check_comision_servicios.Name = "Check_comision_servicios"
        Me.Check_comision_servicios.Size = New System.Drawing.Size(188, 20)
        Me.Check_comision_servicios.TabIndex = 34
        Me.Check_comision_servicios.TabStop = False
        Me.Check_comision_servicios.Text = "COMISION DE SERVICIOS"
        Me.Check_comision_servicios.UseVisualStyleBackColor = True
        '
        'Check_proveedores_mas_pedidos
        '
        Me.Check_proveedores_mas_pedidos.AutoSize = True
        Me.Check_proveedores_mas_pedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_proveedores_mas_pedidos.Location = New System.Drawing.Point(21, 221)
        Me.Check_proveedores_mas_pedidos.Name = "Check_proveedores_mas_pedidos"
        Me.Check_proveedores_mas_pedidos.Size = New System.Drawing.Size(285, 20)
        Me.Check_proveedores_mas_pedidos.TabIndex = 33
        Me.Check_proveedores_mas_pedidos.TabStop = False
        Me.Check_proveedores_mas_pedidos.Text = "MANTENEDOR DE PROV. MAS PEDIDOS"
        Me.Check_proveedores_mas_pedidos.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.GroupBox6.Location = New System.Drawing.Point(343, 124)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(332, 570)
        Me.GroupBox6.TabIndex = 21
        Me.GroupBox6.TabStop = False
        '
        'Panel_2
        '
        Me.Panel_2.AutoScroll = True
        Me.Panel_2.BackColor = System.Drawing.Color.Transparent
        Me.Panel_2.Controls.Add(Me.Check_registro_de_actualizaciones)
        Me.Panel_2.Controls.Add(Me.Check_actualizar_sistema)
        Me.Panel_2.Controls.Add(Me.Check_existencias)
        Me.Panel_2.Controls.Add(Me.check_traspasar_stock_fisico)
        Me.Panel_2.Controls.Add(Me.Check_traspaso_de_creditos_a_historico)
        Me.Panel_2.Controls.Add(Me.Check_actualizar_stock)
        Me.Panel_2.Controls.Add(Me.Check_asignar_familias)
        Me.Panel_2.Controls.Add(Me.Check_guias_de_traslado)
        Me.Panel_2.Controls.Add(Me.Check_detalle_compras_por_doc)
        Me.Panel_2.Controls.Add(Me.Check_detalle_compras)
        Me.Panel_2.Controls.Add(Me.Check_personalizar_sistema)
        Me.Panel_2.Controls.Add(Me.Check_consultas)
        Me.Panel_2.Controls.Add(Me.Check_reservas)
        Me.Panel_2.Controls.Add(Me.Check_bitacora_de_cambios)
        Me.Panel_2.Controls.Add(Me.Check_confirmacion_de_llegada)
        Me.Panel_2.Controls.Add(Me.Check_ruta_para_archivos_planos)
        Me.Panel_2.Controls.Add(Me.Check_compras)
        Me.Panel_2.Controls.Add(Me.Check_ruta_para_imagenes_de_sistema)
        Me.Panel_2.Controls.Add(Me.Check_revision_de_pedidos)
        Me.Panel_2.Controls.Add(Me.Check_inventario)
        Me.Panel_2.Controls.Add(Me.Check_etiquetas)
        Me.Panel_2.Controls.Add(Me.Check_envio_a_sucursal)
        Me.Panel_2.Controls.Add(Me.Check_mis_pedidos)
        Me.Panel_2.Controls.Add(Me.Check_codigos_de_barra)
        Me.Panel_2.Controls.Add(Me.Check_menu_adquisiciones)
        Me.Panel_2.Controls.Add(Me.Check_valores)
        Me.Panel_2.Controls.Add(Me.Check_realizar_pedidos)
        Me.Panel_2.Controls.Add(Me.Check_respaldo)
        Me.Panel_2.Controls.Add(Me.Check_menu_bodega)
        Me.Panel_2.Controls.Add(Me.Check_empresa)
        Me.Panel_2.Controls.Add(Me.Check_stock_minimo)
        Me.Panel_2.Controls.Add(Me.Check_impresoras)
        Me.Panel_2.Controls.Add(Me.Check_numeracion)
        Me.Panel_2.Controls.Add(Me.Check_menu_configuracion)
        Me.Panel_2.Location = New System.Drawing.Point(345, 132)
        Me.Panel_2.Name = "Panel_2"
        Me.Panel_2.Size = New System.Drawing.Size(328, 559)
        Me.Panel_2.TabIndex = 48
        '
        'Check_existencias
        '
        Me.Check_existencias.AutoSize = True
        Me.Check_existencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_existencias.Location = New System.Drawing.Point(23, 385)
        Me.Check_existencias.Name = "Check_existencias"
        Me.Check_existencias.Size = New System.Drawing.Size(102, 20)
        Me.Check_existencias.TabIndex = 73
        Me.Check_existencias.TabStop = False
        Me.Check_existencias.Text = "REPORTES"
        Me.Check_existencias.UseVisualStyleBackColor = True
        '
        'check_traspasar_stock_fisico
        '
        Me.check_traspasar_stock_fisico.AutoSize = True
        Me.check_traspasar_stock_fisico.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.check_traspasar_stock_fisico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.check_traspasar_stock_fisico.Location = New System.Drawing.Point(23, 689)
        Me.check_traspasar_stock_fisico.Name = "check_traspasar_stock_fisico"
        Me.check_traspasar_stock_fisico.Size = New System.Drawing.Size(203, 20)
        Me.check_traspasar_stock_fisico.TabIndex = 72
        Me.check_traspasar_stock_fisico.TabStop = False
        Me.check_traspasar_stock_fisico.Text = "TRASPASAR STOCK FISICO"
        Me.check_traspasar_stock_fisico.UseVisualStyleBackColor = True
        '
        'Check_traspaso_de_creditos_a_historico
        '
        Me.Check_traspaso_de_creditos_a_historico.AutoSize = True
        Me.Check_traspaso_de_creditos_a_historico.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Check_traspaso_de_creditos_a_historico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_traspaso_de_creditos_a_historico.Location = New System.Drawing.Point(23, 669)
        Me.Check_traspaso_de_creditos_a_historico.Name = "Check_traspaso_de_creditos_a_historico"
        Me.Check_traspaso_de_creditos_a_historico.Size = New System.Drawing.Size(283, 20)
        Me.Check_traspaso_de_creditos_a_historico.TabIndex = 71
        Me.Check_traspaso_de_creditos_a_historico.TabStop = False
        Me.Check_traspaso_de_creditos_a_historico.Text = "TRASPASO DE CREDITOS A HISTORICO"
        Me.Check_traspaso_de_creditos_a_historico.UseVisualStyleBackColor = True
        '
        'Check_actualizar_stock
        '
        Me.Check_actualizar_stock.AutoSize = True
        Me.Check_actualizar_stock.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Check_actualizar_stock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_actualizar_stock.Location = New System.Drawing.Point(23, 629)
        Me.Check_actualizar_stock.Name = "Check_actualizar_stock"
        Me.Check_actualizar_stock.Size = New System.Drawing.Size(158, 20)
        Me.Check_actualizar_stock.TabIndex = 70
        Me.Check_actualizar_stock.TabStop = False
        Me.Check_actualizar_stock.Text = "ACTUALIZAR STOCK"
        Me.Check_actualizar_stock.UseVisualStyleBackColor = True
        '
        'Check_asignar_familias
        '
        Me.Check_asignar_familias.AutoSize = True
        Me.Check_asignar_familias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_asignar_familias.Location = New System.Drawing.Point(23, 365)
        Me.Check_asignar_familias.Name = "Check_asignar_familias"
        Me.Check_asignar_familias.Size = New System.Drawing.Size(149, 20)
        Me.Check_asignar_familias.TabIndex = 69
        Me.Check_asignar_familias.TabStop = False
        Me.Check_asignar_familias.Text = "ASIGNAR FAMILIAS"
        Me.Check_asignar_familias.UseVisualStyleBackColor = True
        '
        'Check_guias_de_traslado
        '
        Me.Check_guias_de_traslado.AutoSize = True
        Me.Check_guias_de_traslado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_guias_de_traslado.Location = New System.Drawing.Point(23, 345)
        Me.Check_guias_de_traslado.Name = "Check_guias_de_traslado"
        Me.Check_guias_de_traslado.Size = New System.Drawing.Size(166, 20)
        Me.Check_guias_de_traslado.TabIndex = 68
        Me.Check_guias_de_traslado.TabStop = False
        Me.Check_guias_de_traslado.Text = "GUIAS DE TRASLADO"
        Me.Check_guias_de_traslado.UseVisualStyleBackColor = True
        '
        'Check_detalle_compras_por_doc
        '
        Me.Check_detalle_compras_por_doc.AutoSize = True
        Me.Check_detalle_compras_por_doc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_detalle_compras_por_doc.Location = New System.Drawing.Point(23, 325)
        Me.Check_detalle_compras_por_doc.Name = "Check_detalle_compras_por_doc"
        Me.Check_detalle_compras_por_doc.Size = New System.Drawing.Size(227, 20)
        Me.Check_detalle_compras_por_doc.TabIndex = 67
        Me.Check_detalle_compras_por_doc.TabStop = False
        Me.Check_detalle_compras_por_doc.Text = "DETALLE COMPRAS  POR DOC."
        Me.Check_detalle_compras_por_doc.UseVisualStyleBackColor = True
        '
        'Check_detalle_compras
        '
        Me.Check_detalle_compras.AutoSize = True
        Me.Check_detalle_compras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_detalle_compras.Location = New System.Drawing.Point(23, 305)
        Me.Check_detalle_compras.Name = "Check_detalle_compras"
        Me.Check_detalle_compras.Size = New System.Drawing.Size(157, 20)
        Me.Check_detalle_compras.TabIndex = 66
        Me.Check_detalle_compras.TabStop = False
        Me.Check_detalle_compras.Text = "DETALLE COMPRAS"
        Me.Check_detalle_compras.UseVisualStyleBackColor = True
        '
        'Check_personalizar_sistema
        '
        Me.Check_personalizar_sistema.AutoSize = True
        Me.Check_personalizar_sistema.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Check_personalizar_sistema.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_personalizar_sistema.Location = New System.Drawing.Point(23, 609)
        Me.Check_personalizar_sistema.Name = "Check_personalizar_sistema"
        Me.Check_personalizar_sistema.Size = New System.Drawing.Size(181, 20)
        Me.Check_personalizar_sistema.TabIndex = 65
        Me.Check_personalizar_sistema.TabStop = False
        Me.Check_personalizar_sistema.Text = "IMAGENES DE SISTEMA"
        Me.Check_personalizar_sistema.UseVisualStyleBackColor = True
        '
        'Check_consultas
        '
        Me.Check_consultas.AutoSize = True
        Me.Check_consultas.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Check_consultas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_consultas.Location = New System.Drawing.Point(23, 569)
        Me.Check_consultas.Name = "Check_consultas"
        Me.Check_consultas.Size = New System.Drawing.Size(138, 20)
        Me.Check_consultas.TabIndex = 64
        Me.Check_consultas.TabStop = False
        Me.Check_consultas.Text = "CONSULTAS SQL"
        Me.Check_consultas.UseVisualStyleBackColor = True
        '
        'Check_reservas
        '
        Me.Check_reservas.AutoSize = True
        Me.Check_reservas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_reservas.Location = New System.Drawing.Point(23, 141)
        Me.Check_reservas.Name = "Check_reservas"
        Me.Check_reservas.Size = New System.Drawing.Size(101, 20)
        Me.Check_reservas.TabIndex = 63
        Me.Check_reservas.TabStop = False
        Me.Check_reservas.Text = "RESERVAS"
        Me.Check_reservas.UseVisualStyleBackColor = True
        '
        'Check_bitacora_de_cambios
        '
        Me.Check_bitacora_de_cambios.AutoSize = True
        Me.Check_bitacora_de_cambios.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Check_bitacora_de_cambios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_bitacora_de_cambios.Location = New System.Drawing.Point(23, 549)
        Me.Check_bitacora_de_cambios.Name = "Check_bitacora_de_cambios"
        Me.Check_bitacora_de_cambios.Size = New System.Drawing.Size(180, 20)
        Me.Check_bitacora_de_cambios.TabIndex = 62
        Me.Check_bitacora_de_cambios.TabStop = False
        Me.Check_bitacora_de_cambios.Text = "BITACORA DE CAMBIOS"
        Me.Check_bitacora_de_cambios.UseVisualStyleBackColor = True
        '
        'Check_confirmacion_de_llegada
        '
        Me.Check_confirmacion_de_llegada.AutoSize = True
        Me.Check_confirmacion_de_llegada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_confirmacion_de_llegada.Location = New System.Drawing.Point(23, 121)
        Me.Check_confirmacion_de_llegada.Name = "Check_confirmacion_de_llegada"
        Me.Check_confirmacion_de_llegada.Size = New System.Drawing.Size(215, 20)
        Me.Check_confirmacion_de_llegada.TabIndex = 55
        Me.Check_confirmacion_de_llegada.TabStop = False
        Me.Check_confirmacion_de_llegada.Text = "CONFIRMACION DE LLEGADA"
        Me.Check_confirmacion_de_llegada.UseVisualStyleBackColor = True
        '
        'Check_ruta_para_archivos_planos
        '
        Me.Check_ruta_para_archivos_planos.AutoSize = True
        Me.Check_ruta_para_archivos_planos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_ruta_para_archivos_planos.Location = New System.Drawing.Point(23, 509)
        Me.Check_ruta_para_archivos_planos.Name = "Check_ruta_para_archivos_planos"
        Me.Check_ruta_para_archivos_planos.Size = New System.Drawing.Size(234, 20)
        Me.Check_ruta_para_archivos_planos.TabIndex = 61
        Me.Check_ruta_para_archivos_planos.TabStop = False
        Me.Check_ruta_para_archivos_planos.Text = "RUTA PARA ARCHIVOS PLANOS"
        Me.Check_ruta_para_archivos_planos.UseVisualStyleBackColor = True
        '
        'Check_compras
        '
        Me.Check_compras.AutoSize = True
        Me.Check_compras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_compras.Location = New System.Drawing.Point(23, 226)
        Me.Check_compras.Name = "Check_compras"
        Me.Check_compras.Size = New System.Drawing.Size(94, 20)
        Me.Check_compras.TabIndex = 44
        Me.Check_compras.TabStop = False
        Me.Check_compras.Text = "COMPRAS"
        Me.Check_compras.UseVisualStyleBackColor = True
        '
        'Check_ruta_para_imagenes_de_sistema
        '
        Me.Check_ruta_para_imagenes_de_sistema.AutoSize = True
        Me.Check_ruta_para_imagenes_de_sistema.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_ruta_para_imagenes_de_sistema.Location = New System.Drawing.Point(23, 529)
        Me.Check_ruta_para_imagenes_de_sistema.Name = "Check_ruta_para_imagenes_de_sistema"
        Me.Check_ruta_para_imagenes_de_sistema.Size = New System.Drawing.Size(262, 20)
        Me.Check_ruta_para_imagenes_de_sistema.TabIndex = 60
        Me.Check_ruta_para_imagenes_de_sistema.TabStop = False
        Me.Check_ruta_para_imagenes_de_sistema.Text = "RUTA PARA IMAGENES DE SISTEMA"
        Me.Check_ruta_para_imagenes_de_sistema.UseVisualStyleBackColor = True
        '
        'Check_revision_de_pedidos
        '
        Me.Check_revision_de_pedidos.AutoSize = True
        Me.Check_revision_de_pedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_revision_de_pedidos.Location = New System.Drawing.Point(23, 101)
        Me.Check_revision_de_pedidos.Name = "Check_revision_de_pedidos"
        Me.Check_revision_de_pedidos.Size = New System.Drawing.Size(175, 20)
        Me.Check_revision_de_pedidos.TabIndex = 54
        Me.Check_revision_de_pedidos.TabStop = False
        Me.Check_revision_de_pedidos.Text = "REVISION DE PEDIDOS"
        Me.Check_revision_de_pedidos.UseVisualStyleBackColor = True
        '
        'Check_inventario
        '
        Me.Check_inventario.AutoSize = True
        Me.Check_inventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_inventario.Location = New System.Drawing.Point(23, 284)
        Me.Check_inventario.Name = "Check_inventario"
        Me.Check_inventario.Size = New System.Drawing.Size(109, 20)
        Me.Check_inventario.TabIndex = 59
        Me.Check_inventario.TabStop = False
        Me.Check_inventario.Text = "INVENTARIO"
        Me.Check_inventario.UseVisualStyleBackColor = True
        '
        'Check_etiquetas
        '
        Me.Check_etiquetas.AutoSize = True
        Me.Check_etiquetas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_etiquetas.Location = New System.Drawing.Point(23, 205)
        Me.Check_etiquetas.Name = "Check_etiquetas"
        Me.Check_etiquetas.Size = New System.Drawing.Size(154, 20)
        Me.Check_etiquetas.TabIndex = 42
        Me.Check_etiquetas.TabStop = False
        Me.Check_etiquetas.Text = "CREAR ETIQUETAS"
        Me.Check_etiquetas.UseVisualStyleBackColor = True
        '
        'Check_envio_a_sucursal
        '
        Me.Check_envio_a_sucursal.AutoSize = True
        Me.Check_envio_a_sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_envio_a_sucursal.Location = New System.Drawing.Point(23, 265)
        Me.Check_envio_a_sucursal.Name = "Check_envio_a_sucursal"
        Me.Check_envio_a_sucursal.Size = New System.Drawing.Size(156, 20)
        Me.Check_envio_a_sucursal.TabIndex = 58
        Me.Check_envio_a_sucursal.TabStop = False
        Me.Check_envio_a_sucursal.Text = "ENVIO A SUCURSAL"
        Me.Check_envio_a_sucursal.UseVisualStyleBackColor = True
        '
        'Check_mis_pedidos
        '
        Me.Check_mis_pedidos.AutoSize = True
        Me.Check_mis_pedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_mis_pedidos.Location = New System.Drawing.Point(23, 81)
        Me.Check_mis_pedidos.Name = "Check_mis_pedidos"
        Me.Check_mis_pedidos.Size = New System.Drawing.Size(113, 20)
        Me.Check_mis_pedidos.TabIndex = 53
        Me.Check_mis_pedidos.TabStop = False
        Me.Check_mis_pedidos.Text = "MIS PEDIDOS"
        Me.Check_mis_pedidos.UseVisualStyleBackColor = True
        '
        'Check_codigos_de_barra
        '
        Me.Check_codigos_de_barra.AutoSize = True
        Me.Check_codigos_de_barra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_codigos_de_barra.Location = New System.Drawing.Point(23, 245)
        Me.Check_codigos_de_barra.Name = "Check_codigos_de_barra"
        Me.Check_codigos_de_barra.Size = New System.Drawing.Size(160, 20)
        Me.Check_codigos_de_barra.TabIndex = 56
        Me.Check_codigos_de_barra.TabStop = False
        Me.Check_codigos_de_barra.Text = "CODIGOS DE BARRA"
        Me.Check_codigos_de_barra.UseVisualStyleBackColor = True
        '
        'Check_menu_adquisiciones
        '
        Me.Check_menu_adquisiciones.AutoSize = True
        Me.Check_menu_adquisiciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_menu_adquisiciones.Location = New System.Drawing.Point(23, 21)
        Me.Check_menu_adquisiciones.Name = "Check_menu_adquisiciones"
        Me.Check_menu_adquisiciones.Size = New System.Drawing.Size(192, 20)
        Me.Check_menu_adquisiciones.TabIndex = 49
        Me.Check_menu_adquisiciones.TabStop = False
        Me.Check_menu_adquisiciones.Text = "MENU ADQUISICIONES"
        Me.Check_menu_adquisiciones.UseVisualStyleBackColor = True
        '
        'Check_valores
        '
        Me.Check_valores.AutoSize = True
        Me.Check_valores.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Check_valores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_valores.Location = New System.Drawing.Point(23, 649)
        Me.Check_valores.Name = "Check_valores"
        Me.Check_valores.Size = New System.Drawing.Size(90, 20)
        Me.Check_valores.TabIndex = 57
        Me.Check_valores.TabStop = False
        Me.Check_valores.Text = "VALORES"
        Me.Check_valores.UseVisualStyleBackColor = True
        '
        'Check_realizar_pedidos
        '
        Me.Check_realizar_pedidos.AutoSize = True
        Me.Check_realizar_pedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_realizar_pedidos.Location = New System.Drawing.Point(23, 61)
        Me.Check_realizar_pedidos.Name = "Check_realizar_pedidos"
        Me.Check_realizar_pedidos.Size = New System.Drawing.Size(155, 20)
        Me.Check_realizar_pedidos.TabIndex = 52
        Me.Check_realizar_pedidos.TabStop = False
        Me.Check_realizar_pedidos.Text = "REALIZAR PEDIDOS"
        Me.Check_realizar_pedidos.UseVisualStyleBackColor = True
        '
        'Check_respaldo
        '
        Me.Check_respaldo.AutoSize = True
        Me.Check_respaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_respaldo.Location = New System.Drawing.Point(23, 589)
        Me.Check_respaldo.Name = "Check_respaldo"
        Me.Check_respaldo.Size = New System.Drawing.Size(109, 20)
        Me.Check_respaldo.TabIndex = 48
        Me.Check_respaldo.TabStop = False
        Me.Check_respaldo.Text = "RESPALDOS"
        Me.Check_respaldo.UseVisualStyleBackColor = True
        '
        'Check_menu_bodega
        '
        Me.Check_menu_bodega.AutoSize = True
        Me.Check_menu_bodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_menu_bodega.Location = New System.Drawing.Point(23, 185)
        Me.Check_menu_bodega.Name = "Check_menu_bodega"
        Me.Check_menu_bodega.Size = New System.Drawing.Size(138, 20)
        Me.Check_menu_bodega.TabIndex = 50
        Me.Check_menu_bodega.TabStop = False
        Me.Check_menu_bodega.Text = "MENU BODEGA"
        Me.Check_menu_bodega.UseVisualStyleBackColor = True
        '
        'Check_empresa
        '
        Me.Check_empresa.AutoSize = True
        Me.Check_empresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_empresa.Location = New System.Drawing.Point(23, 489)
        Me.Check_empresa.Name = "Check_empresa"
        Me.Check_empresa.Size = New System.Drawing.Size(110, 20)
        Me.Check_empresa.TabIndex = 47
        Me.Check_empresa.TabStop = False
        Me.Check_empresa.Text = "MI EMPRESA"
        Me.Check_empresa.UseVisualStyleBackColor = True
        '
        'Check_stock_minimo
        '
        Me.Check_stock_minimo.AutoSize = True
        Me.Check_stock_minimo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_stock_minimo.Location = New System.Drawing.Point(23, 41)
        Me.Check_stock_minimo.Name = "Check_stock_minimo"
        Me.Check_stock_minimo.Size = New System.Drawing.Size(123, 20)
        Me.Check_stock_minimo.TabIndex = 43
        Me.Check_stock_minimo.TabStop = False
        Me.Check_stock_minimo.Text = "STOCK MINIMO"
        Me.Check_stock_minimo.UseVisualStyleBackColor = True
        '
        'Check_impresoras
        '
        Me.Check_impresoras.AutoSize = True
        Me.Check_impresoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_impresoras.Location = New System.Drawing.Point(23, 449)
        Me.Check_impresoras.Name = "Check_impresoras"
        Me.Check_impresoras.Size = New System.Drawing.Size(116, 20)
        Me.Check_impresoras.TabIndex = 46
        Me.Check_impresoras.TabStop = False
        Me.Check_impresoras.Text = "IMPRESORAS"
        Me.Check_impresoras.UseVisualStyleBackColor = True
        '
        'Check_numeracion
        '
        Me.Check_numeracion.AutoSize = True
        Me.Check_numeracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_numeracion.Location = New System.Drawing.Point(23, 469)
        Me.Check_numeracion.Name = "Check_numeracion"
        Me.Check_numeracion.Size = New System.Drawing.Size(118, 20)
        Me.Check_numeracion.TabIndex = 45
        Me.Check_numeracion.TabStop = False
        Me.Check_numeracion.Text = "NUMERACION"
        Me.Check_numeracion.UseVisualStyleBackColor = True
        '
        'Check_menu_configuracion
        '
        Me.Check_menu_configuracion.AutoSize = True
        Me.Check_menu_configuracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_menu_configuracion.Location = New System.Drawing.Point(23, 429)
        Me.Check_menu_configuracion.Name = "Check_menu_configuracion"
        Me.Check_menu_configuracion.Size = New System.Drawing.Size(199, 20)
        Me.Check_menu_configuracion.TabIndex = 51
        Me.Check_menu_configuracion.TabStop = False
        Me.Check_menu_configuracion.Text = "MENU CONFIGURACION"
        Me.Check_menu_configuracion.UseVisualStyleBackColor = True
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(7, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 50)
        Me.PictureBox_logo.TabIndex = 72
        Me.PictureBox_logo.TabStop = False
        '
        'Check_registro_de_actualizaciones
        '
        Me.Check_registro_de_actualizaciones.AutoSize = True
        Me.Check_registro_de_actualizaciones.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Check_registro_de_actualizaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_registro_de_actualizaciones.Location = New System.Drawing.Point(23, 729)
        Me.Check_registro_de_actualizaciones.Name = "Check_registro_de_actualizaciones"
        Me.Check_registro_de_actualizaciones.Size = New System.Drawing.Size(245, 20)
        Me.Check_registro_de_actualizaciones.TabIndex = 75
        Me.Check_registro_de_actualizaciones.TabStop = False
        Me.Check_registro_de_actualizaciones.Text = "REGISTRO DE ACTUALIZACIONES"
        Me.Check_registro_de_actualizaciones.UseVisualStyleBackColor = True
        '
        'Check_actualizar_sistema
        '
        Me.Check_actualizar_sistema.AutoSize = True
        Me.Check_actualizar_sistema.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Check_actualizar_sistema.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_actualizar_sistema.Location = New System.Drawing.Point(23, 709)
        Me.Check_actualizar_sistema.Name = "Check_actualizar_sistema"
        Me.Check_actualizar_sistema.Size = New System.Drawing.Size(172, 20)
        Me.Check_actualizar_sistema.TabIndex = 74
        Me.Check_actualizar_sistema.TabStop = False
        Me.Check_actualizar_sistema.Text = "ACTUALIZAR SISTEMA"
        Me.Check_actualizar_sistema.UseVisualStyleBackColor = True
        '
        'Form_permisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1018, 700)
        Me.Controls.Add(Me.Panel_2)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_permisos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PERMISOS DE USUARIO"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel_1.ResumeLayout(False)
        Me.Panel_1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel_3.ResumeLayout(False)
        Me.Panel_3.PerformLayout()
        Me.Panel_2.ResumeLayout(False)
        Me.Panel_2.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents Check_clientes As System.Windows.Forms.CheckBox
    Friend WithEvents Check_usuarios As System.Windows.Forms.CheckBox
    Friend WithEvents Check_productos As System.Windows.Forms.CheckBox
    Friend WithEvents Check_proveedores As System.Windows.Forms.CheckBox
    Friend WithEvents Check_retiradores As System.Windows.Forms.CheckBox
    Friend WithEvents Check_ventas As System.Windows.Forms.CheckBox
    Friend WithEvents Check_cartola As System.Windows.Forms.CheckBox
    Friend WithEvents Check_facturacion As System.Windows.Forms.CheckBox
    Friend WithEvents Check_pagos As System.Windows.Forms.CheckBox
    Friend WithEvents Check_estados As System.Windows.Forms.CheckBox
    Friend WithEvents Check_deudores As System.Windows.Forms.CheckBox
    Friend WithEvents Check_nota_de_credito As System.Windows.Forms.CheckBox
    Friend WithEvents Check_caja As System.Windows.Forms.CheckBox
    Friend WithEvents Check_corregir As System.Windows.Forms.CheckBox
    Friend WithEvents Check_comisiones As System.Windows.Forms.CheckBox
    Friend WithEvents Check_vencidas As System.Windows.Forms.CheckBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_modificar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Check_estadistica As System.Windows.Forms.CheckBox
    Friend WithEvents Check_subfamilias As System.Windows.Forms.CheckBox
    Friend WithEvents Check_familias As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents Check_cuentas_corrientes As System.Windows.Forms.CheckBox
    Friend WithEvents Check_libro_de_compra As System.Windows.Forms.CheckBox
    Friend WithEvents Check_resumen_libro_de_compra As System.Windows.Forms.CheckBox
    Friend WithEvents Check_menu_mantenedores As System.Windows.Forms.CheckBox
    Friend WithEvents Check_menu_administracion As System.Windows.Forms.CheckBox
    Friend WithEvents Check_menu_ventas As System.Windows.Forms.CheckBox
    Friend WithEvents btn_ultimo As System.Windows.Forms.Button
    Friend WithEvents btn_siguiente As System.Windows.Forms.Button
    Friend WithEvents btn_primero As System.Windows.Forms.Button
    Friend WithEvents btn_anterior As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_rut As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Check_reporte_libro_de_compra As System.Windows.Forms.CheckBox
    Friend WithEvents Check_buscar_facturas As System.Windows.Forms.CheckBox
    Friend WithEvents Check_estados_cuenta_rango As System.Windows.Forms.CheckBox
    Friend WithEvents Check_cotizacion_formal As System.Windows.Forms.CheckBox
    Friend WithEvents Check_stock_y_ubicaciones As System.Windows.Forms.CheckBox
    Friend WithEvents Check_enviar_cotizacion As System.Windows.Forms.CheckBox
    Friend WithEvents Check_agregar_marcas As System.Windows.Forms.CheckBox
    Friend WithEvents Check_proveedores_mas_pedidos As System.Windows.Forms.CheckBox
    Friend WithEvents Check_agregar_abonos As System.Windows.Forms.CheckBox
    Friend WithEvents Check_ingreso_de_creditos As System.Windows.Forms.CheckBox
    Friend WithEvents Check_ingreso_manual_de_ventas As System.Windows.Forms.CheckBox
    Friend WithEvents Check_CORREGIR_numeros As System.Windows.Forms.CheckBox
    Friend WithEvents Check_buscar_totales As System.Windows.Forms.CheckBox
    Friend WithEvents Check_traspaso_de_stock As System.Windows.Forms.CheckBox
    Friend WithEvents Check_imputar_abono As System.Windows.Forms.CheckBox
    Friend WithEvents Check_imputar_notas_de_credito As System.Windows.Forms.CheckBox
    Friend WithEvents Check_libro_de_ventas As System.Windows.Forms.CheckBox
    Friend WithEvents Check_comision_servicios As System.Windows.Forms.CheckBox
    Friend WithEvents Check_cambio_de_productos As System.Windows.Forms.CheckBox
    Friend WithEvents Check_mis_cotizaciones As System.Windows.Forms.CheckBox
    Friend WithEvents Panel_1 As System.Windows.Forms.Panel
    Friend WithEvents Check_detalle_de_ventas_por_doc As System.Windows.Forms.CheckBox
    Friend WithEvents Check_detalle_de_ventas As System.Windows.Forms.CheckBox
    Friend WithEvents Check_cuentas_por_cobrar As System.Windows.Forms.CheckBox
    Friend WithEvents Check_historial_de_cuenta As System.Windows.Forms.CheckBox
    Friend WithEvents Check_nota_de_debito As System.Windows.Forms.CheckBox
    Friend WithEvents Panel_2 As System.Windows.Forms.Panel
    Friend WithEvents Check_bitacora_de_cambios As System.Windows.Forms.CheckBox
    Friend WithEvents Check_confirmacion_de_llegada As System.Windows.Forms.CheckBox
    Friend WithEvents Check_ruta_para_archivos_planos As System.Windows.Forms.CheckBox
    Friend WithEvents Check_compras As System.Windows.Forms.CheckBox
    Friend WithEvents Check_ruta_para_imagenes_de_sistema As System.Windows.Forms.CheckBox
    Friend WithEvents Check_revision_de_pedidos As System.Windows.Forms.CheckBox
    Friend WithEvents Check_inventario As System.Windows.Forms.CheckBox
    Friend WithEvents Check_etiquetas As System.Windows.Forms.CheckBox
    Friend WithEvents Check_envio_a_sucursal As System.Windows.Forms.CheckBox
    Friend WithEvents Check_mis_pedidos As System.Windows.Forms.CheckBox
    Friend WithEvents Check_codigos_de_barra As System.Windows.Forms.CheckBox
    Friend WithEvents Check_menu_adquisiciones As System.Windows.Forms.CheckBox
    Friend WithEvents Check_valores As System.Windows.Forms.CheckBox
    Friend WithEvents Check_realizar_pedidos As System.Windows.Forms.CheckBox
    Friend WithEvents Check_respaldo As System.Windows.Forms.CheckBox
    Friend WithEvents Check_menu_bodega As System.Windows.Forms.CheckBox
    Friend WithEvents Check_empresa As System.Windows.Forms.CheckBox
    Friend WithEvents Check_stock_minimo As System.Windows.Forms.CheckBox
    Friend WithEvents Check_impresoras As System.Windows.Forms.CheckBox
    Friend WithEvents Check_numeracion As System.Windows.Forms.CheckBox
    Friend WithEvents Check_menu_configuracion As System.Windows.Forms.CheckBox
    Friend WithEvents Panel_3 As System.Windows.Forms.Panel
    Friend WithEvents Check_estado_de_deudas As System.Windows.Forms.CheckBox
    Friend WithEvents Check_personalizar_sistema As System.Windows.Forms.CheckBox
    Friend WithEvents Check_consultas As System.Windows.Forms.CheckBox
    Friend WithEvents Check_reservas As System.Windows.Forms.CheckBox
    Friend WithEvents Check_ticket_de_ventas As System.Windows.Forms.CheckBox
    Friend WithEvents Check_tarjetas_de_presentacion As System.Windows.Forms.CheckBox
    Friend WithEvents Check_subfamilias2 As System.Windows.Forms.CheckBox
    Friend WithEvents Check_detalle_compras_por_doc As System.Windows.Forms.CheckBox
    Friend WithEvents Check_detalle_compras As System.Windows.Forms.CheckBox
    Friend WithEvents Check_guias_de_traslado As System.Windows.Forms.CheckBox
    Friend WithEvents Check_registro_de_autorizaciones As System.Windows.Forms.CheckBox
    Friend WithEvents Check_ventas_asistidas As System.Windows.Forms.CheckBox
    Friend WithEvents Check_asignar_familias As System.Windows.Forms.CheckBox
    Friend WithEvents check_traspasar_stock_fisico As System.Windows.Forms.CheckBox
    Friend WithEvents Check_traspaso_de_creditos_a_historico As System.Windows.Forms.CheckBox
    Friend WithEvents Check_actualizar_stock As System.Windows.Forms.CheckBox
    Friend WithEvents Check_adm_vales_de_cambio As System.Windows.Forms.CheckBox
    Friend WithEvents Check_hojas_foleadas As System.Windows.Forms.CheckBox
    Friend WithEvents Check_existencias As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_adm_servicios_de_lubricentro As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_servicios_de_lubricentro As System.Windows.Forms.CheckBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents Check_registro_de_actualizaciones As System.Windows.Forms.CheckBox
    Friend WithEvents Check_actualizar_sistema As System.Windows.Forms.CheckBox
End Class
