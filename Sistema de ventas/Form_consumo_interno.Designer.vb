<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_consumo_interno
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_consumo_interno))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txt_nro_guia = New System.Windows.Forms.TextBox
        Me.GroupBox_datos_producto = New System.Windows.Forms.GroupBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.txt_tipo_precio = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txt_codigo_subfamilia_2 = New System.Windows.Forms.TextBox
        Me.Combo_tipo_precio = New System.Windows.Forms.ComboBox
        Me.txt_codigo_subfamilia = New System.Windows.Forms.TextBox
        Me.txt_codigo_familia = New System.Windows.Forms.TextBox
        Me.lbl_tipo_cuenta = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_cantidad_minima = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txt_nro_doc = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_tipo_doc = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_cantidad_ultima_compra = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.dtp_ultima_compra = New System.Windows.Forms.DateTimePicker
        Me.txt_codigo_barra = New System.Windows.Forms.TextBox
        Me.txt_costo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lbl_mensaje = New System.Windows.Forms.Label
        Me.GroupBox_totales = New System.Windows.Forms.GroupBox
        Me.txt_iva = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_neto = New System.Windows.Forms.TextBox
        Me.txt_total = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_cantidad = New System.Windows.Forms.TextBox
        Me.GroupBox_producto = New System.Windows.Forms.GroupBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txt_precio = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txt_nombre = New System.Windows.Forms.TextBox
        Me.txt_aplicacion = New System.Windows.Forms.TextBox
        Me.txt_numero_tecnico = New System.Windows.Forms.TextBox
        Me.btn_buscar_productos = New System.Windows.Forms.Button
        Me.txt_stock = New System.Windows.Forms.TextBox
        Me.txt_codigo = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txt_factor = New System.Windows.Forms.TextBox
        Me.txt_marca = New System.Windows.Forms.TextBox
        Me.txt_proveedor = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.txt_rut_proveedor = New System.Windows.Forms.TextBox
        Me.grilla_consumo_interno = New System.Windows.Forms.DataGridView
        Me.cod_auto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COSTO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Timer_cierre = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_item = New System.Windows.Forms.TextBox
        Me.txt_nro_vale = New System.Windows.Forms.TextBox
        Me.Combo_motivo = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Combo_responsable = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_rut_responsable = New System.Windows.Forms.TextBox
        Me.btn_quitar_elemento = New System.Windows.Forms.Button
        Me.btn_imprimir = New System.Windows.Forms.Button
        Me.btn_agregar = New System.Windows.Forms.Button
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox_clientes = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.txt_rut_cliente = New System.Windows.Forms.TextBox
        Me.txt_nombre_cliente = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.txt_comuna_cliente = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.txt_giro_cliente = New System.Windows.Forms.TextBox
        Me.txt_direccion_cliente = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.btn_buscar_clientes = New System.Windows.Forms.Button
        Me.Label34 = New System.Windows.Forms.Label
        Me.txt_telefono = New System.Windows.Forms.TextBox
        Me.txt_cod_cliente = New System.Windows.Forms.TextBox
        Me.txt_correo_cliente = New System.Windows.Forms.TextBox
        Me.GroupBox_datos_producto.SuspendLayout()
        Me.GroupBox_totales.SuspendLayout()
        Me.GroupBox_producto.SuspendLayout()
        CType(Me.grilla_consumo_interno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_clientes.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_nro_guia
        '
        Me.txt_nro_guia.BackColor = System.Drawing.SystemColors.Control
        Me.txt_nro_guia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_guia.ForeColor = System.Drawing.Color.Black
        Me.txt_nro_guia.Location = New System.Drawing.Point(1031, 214)
        Me.txt_nro_guia.Name = "txt_nro_guia"
        Me.txt_nro_guia.ReadOnly = True
        Me.txt_nro_guia.Size = New System.Drawing.Size(63, 24)
        Me.txt_nro_guia.TabIndex = 290
        Me.txt_nro_guia.TabStop = False
        '
        'GroupBox_datos_producto
        '
        Me.GroupBox_datos_producto.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_datos_producto.Controls.Add(Me.Label29)
        Me.GroupBox_datos_producto.Controls.Add(Me.txt_tipo_precio)
        Me.GroupBox_datos_producto.Controls.Add(Me.Label7)
        Me.GroupBox_datos_producto.Controls.Add(Me.Label9)
        Me.GroupBox_datos_producto.Controls.Add(Me.Label15)
        Me.GroupBox_datos_producto.Controls.Add(Me.txt_codigo_subfamilia_2)
        Me.GroupBox_datos_producto.Controls.Add(Me.Combo_tipo_precio)
        Me.GroupBox_datos_producto.Controls.Add(Me.txt_codigo_subfamilia)
        Me.GroupBox_datos_producto.Controls.Add(Me.txt_codigo_familia)
        Me.GroupBox_datos_producto.Controls.Add(Me.lbl_tipo_cuenta)
        Me.GroupBox_datos_producto.Controls.Add(Me.Label4)
        Me.GroupBox_datos_producto.Controls.Add(Me.txt_cantidad_minima)
        Me.GroupBox_datos_producto.Controls.Add(Me.Label18)
        Me.GroupBox_datos_producto.Controls.Add(Me.txt_nro_doc)
        Me.GroupBox_datos_producto.Controls.Add(Me.Label5)
        Me.GroupBox_datos_producto.Controls.Add(Me.txt_tipo_doc)
        Me.GroupBox_datos_producto.Controls.Add(Me.Label12)
        Me.GroupBox_datos_producto.Controls.Add(Me.txt_cantidad_ultima_compra)
        Me.GroupBox_datos_producto.Controls.Add(Me.Label10)
        Me.GroupBox_datos_producto.Controls.Add(Me.dtp_ultima_compra)
        Me.GroupBox_datos_producto.Controls.Add(Me.txt_codigo_barra)
        Me.GroupBox_datos_producto.Controls.Add(Me.txt_costo)
        Me.GroupBox_datos_producto.Controls.Add(Me.Label6)
        Me.GroupBox_datos_producto.Controls.Add(Me.Label8)
        Me.GroupBox_datos_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_datos_producto.Location = New System.Drawing.Point(1039, 122)
        Me.GroupBox_datos_producto.Name = "GroupBox_datos_producto"
        Me.GroupBox_datos_producto.Size = New System.Drawing.Size(266, 393)
        Me.GroupBox_datos_producto.TabIndex = 285
        Me.GroupBox_datos_producto.TabStop = False
        Me.GroupBox_datos_producto.Text = "DATOS DEL PRODUCTO"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Location = New System.Drawing.Point(52, 210)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(95, 16)
        Me.Label29.TabIndex = 57
        Me.Label29.Text = "TIPO PRECIO:"
        '
        'txt_tipo_precio
        '
        Me.txt_tipo_precio.Enabled = False
        Me.txt_tipo_precio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tipo_precio.Location = New System.Drawing.Point(149, 207)
        Me.txt_tipo_precio.MaxLength = 7
        Me.txt_tipo_precio.Name = "txt_tipo_precio"
        Me.txt_tipo_precio.Size = New System.Drawing.Size(111, 24)
        Me.txt_tipo_precio.TabIndex = 56
        Me.txt_tipo_precio.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(58, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 16)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "SUBFAMILIA:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(48, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 16)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "SUBFAMILIA 2:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(86, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 16)
        Me.Label15.TabIndex = 53
        Me.Label15.Text = "FAMILIA:"
        '
        'txt_codigo_subfamilia_2
        '
        Me.txt_codigo_subfamilia_2.Enabled = False
        Me.txt_codigo_subfamilia_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_subfamilia_2.Location = New System.Drawing.Point(149, 83)
        Me.txt_codigo_subfamilia_2.MaxLength = 8
        Me.txt_codigo_subfamilia_2.Name = "txt_codigo_subfamilia_2"
        Me.txt_codigo_subfamilia_2.Size = New System.Drawing.Size(111, 24)
        Me.txt_codigo_subfamilia_2.TabIndex = 52
        Me.txt_codigo_subfamilia_2.TabStop = False
        '
        'Combo_tipo_precio
        '
        Me.Combo_tipo_precio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_tipo_precio.Enabled = False
        Me.Combo_tipo_precio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_tipo_precio.FormattingEnabled = True
        Me.Combo_tipo_precio.Items.AddRange(New Object() {"-", "FACTOR", "DIRECTO"})
        Me.Combo_tipo_precio.Location = New System.Drawing.Point(149, 176)
        Me.Combo_tipo_precio.Name = "Combo_tipo_precio"
        Me.Combo_tipo_precio.Size = New System.Drawing.Size(111, 24)
        Me.Combo_tipo_precio.TabIndex = 10
        Me.Combo_tipo_precio.TabStop = False
        '
        'txt_codigo_subfamilia
        '
        Me.txt_codigo_subfamilia.Enabled = False
        Me.txt_codigo_subfamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_subfamilia.Location = New System.Drawing.Point(149, 52)
        Me.txt_codigo_subfamilia.MaxLength = 8
        Me.txt_codigo_subfamilia.Name = "txt_codigo_subfamilia"
        Me.txt_codigo_subfamilia.Size = New System.Drawing.Size(111, 24)
        Me.txt_codigo_subfamilia.TabIndex = 51
        Me.txt_codigo_subfamilia.TabStop = False
        '
        'txt_codigo_familia
        '
        Me.txt_codigo_familia.Enabled = False
        Me.txt_codigo_familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_familia.Location = New System.Drawing.Point(149, 21)
        Me.txt_codigo_familia.MaxLength = 8
        Me.txt_codigo_familia.Name = "txt_codigo_familia"
        Me.txt_codigo_familia.Size = New System.Drawing.Size(111, 24)
        Me.txt_codigo_familia.TabIndex = 50
        Me.txt_codigo_familia.TabStop = False
        '
        'lbl_tipo_cuenta
        '
        Me.lbl_tipo_cuenta.AutoSize = True
        Me.lbl_tipo_cuenta.BackColor = System.Drawing.Color.Transparent
        Me.lbl_tipo_cuenta.Location = New System.Drawing.Point(52, 179)
        Me.lbl_tipo_cuenta.Name = "lbl_tipo_cuenta"
        Me.lbl_tipo_cuenta.Size = New System.Drawing.Size(95, 16)
        Me.lbl_tipo_cuenta.TabIndex = 29
        Me.lbl_tipo_cuenta.Text = "TIPO PRECIO:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 16)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "CANTIDAD MINIMA:"
        '
        'txt_cantidad_minima
        '
        Me.txt_cantidad_minima.Enabled = False
        Me.txt_cantidad_minima.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad_minima.Location = New System.Drawing.Point(149, 145)
        Me.txt_cantidad_minima.MaxLength = 10
        Me.txt_cantidad_minima.Name = "txt_cantidad_minima"
        Me.txt_cantidad_minima.Size = New System.Drawing.Size(111, 24)
        Me.txt_cantidad_minima.TabIndex = 7
        Me.txt_cantidad_minima.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(3, 303)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(144, 16)
        Me.Label18.TabIndex = 25
        Me.Label18.Text = "CANT. ULT. COMPRA:"
        '
        'txt_nro_doc
        '
        Me.txt_nro_doc.Enabled = False
        Me.txt_nro_doc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_doc.Location = New System.Drawing.Point(149, 361)
        Me.txt_nro_doc.MaxLength = 7
        Me.txt_nro_doc.Name = "txt_nro_doc"
        Me.txt_nro_doc.Size = New System.Drawing.Size(111, 24)
        Me.txt_nro_doc.TabIndex = 18
        Me.txt_nro_doc.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(68, 364)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "NRO. DOC.:"
        '
        'txt_tipo_doc
        '
        Me.txt_tipo_doc.Enabled = False
        Me.txt_tipo_doc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tipo_doc.Location = New System.Drawing.Point(149, 331)
        Me.txt_tipo_doc.MaxLength = 7
        Me.txt_tipo_doc.Name = "txt_tipo_doc"
        Me.txt_tipo_doc.Size = New System.Drawing.Size(111, 24)
        Me.txt_tipo_doc.TabIndex = 17
        Me.txt_tipo_doc.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(70, 334)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 16)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "TIPO DOC.:"
        '
        'txt_cantidad_ultima_compra
        '
        Me.txt_cantidad_ultima_compra.Enabled = False
        Me.txt_cantidad_ultima_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad_ultima_compra.Location = New System.Drawing.Point(149, 300)
        Me.txt_cantidad_ultima_compra.MaxLength = 7
        Me.txt_cantidad_ultima_compra.Name = "txt_cantidad_ultima_compra"
        Me.txt_cantidad_ultima_compra.Size = New System.Drawing.Size(111, 24)
        Me.txt_cantidad_ultima_compra.TabIndex = 16
        Me.txt_cantidad_ultima_compra.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(26, 273)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(121, 16)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "ULTIMA COMPRA:"
        '
        'dtp_ultima_compra
        '
        Me.dtp_ultima_compra.Checked = False
        Me.dtp_ultima_compra.Enabled = False
        Me.dtp_ultima_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ultima_compra.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_ultima_compra.Location = New System.Drawing.Point(149, 269)
        Me.dtp_ultima_compra.Name = "dtp_ultima_compra"
        Me.dtp_ultima_compra.Size = New System.Drawing.Size(111, 24)
        Me.dtp_ultima_compra.TabIndex = 15
        Me.dtp_ultima_compra.TabStop = False
        '
        'txt_codigo_barra
        '
        Me.txt_codigo_barra.Enabled = False
        Me.txt_codigo_barra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_barra.Location = New System.Drawing.Point(149, 114)
        Me.txt_codigo_barra.MaxLength = 30
        Me.txt_codigo_barra.Name = "txt_codigo_barra"
        Me.txt_codigo_barra.Size = New System.Drawing.Size(111, 24)
        Me.txt_codigo_barra.TabIndex = 6
        Me.txt_codigo_barra.TabStop = False
        '
        'txt_costo
        '
        Me.txt_costo.Enabled = False
        Me.txt_costo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_costo.Location = New System.Drawing.Point(149, 238)
        Me.txt_costo.MaxLength = 7
        Me.txt_costo.Name = "txt_costo"
        Me.txt_costo.Size = New System.Drawing.Size(111, 24)
        Me.txt_costo.TabIndex = 12
        Me.txt_costo.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(32, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "COD. DE BARRA:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(89, 241)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "COSTO:"
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(308, 1)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(711, 81)
        Me.lbl_mensaje.TabIndex = 286
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'GroupBox_totales
        '
        Me.GroupBox_totales.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_totales.Controls.Add(Me.txt_iva)
        Me.GroupBox_totales.Controls.Add(Me.Label11)
        Me.GroupBox_totales.Controls.Add(Me.txt_neto)
        Me.GroupBox_totales.Controls.Add(Me.txt_total)
        Me.GroupBox_totales.Controls.Add(Me.Label23)
        Me.GroupBox_totales.Controls.Add(Me.Label13)
        Me.GroupBox_totales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_totales.Location = New System.Drawing.Point(1039, 544)
        Me.GroupBox_totales.Name = "GroupBox_totales"
        Me.GroupBox_totales.Size = New System.Drawing.Size(266, 137)
        Me.GroupBox_totales.TabIndex = 280
        Me.GroupBox_totales.TabStop = False
        Me.GroupBox_totales.Text = "TOTALES:"
        '
        'txt_iva
        '
        Me.txt_iva.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_iva.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_iva.ForeColor = System.Drawing.Color.Black
        Me.txt_iva.Location = New System.Drawing.Point(117, 58)
        Me.txt_iva.Name = "txt_iva"
        Me.txt_iva.ReadOnly = True
        Me.txt_iva.Size = New System.Drawing.Size(90, 24)
        Me.txt_iva.TabIndex = 0
        Me.txt_iva.TabStop = False
        Me.txt_iva.Text = "0"
        Me.txt_iva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(60, 95)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 16)
        Me.Label11.TabIndex = 131
        Me.Label11.Text = "TOTAL:"
        '
        'txt_neto
        '
        Me.txt_neto.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_neto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_neto.ForeColor = System.Drawing.Color.Black
        Me.txt_neto.Location = New System.Drawing.Point(117, 28)
        Me.txt_neto.Name = "txt_neto"
        Me.txt_neto.ReadOnly = True
        Me.txt_neto.Size = New System.Drawing.Size(90, 24)
        Me.txt_neto.TabIndex = 0
        Me.txt_neto.TabStop = False
        Me.txt_neto.Text = "0"
        Me.txt_neto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.Black
        Me.txt_total.Location = New System.Drawing.Point(117, 92)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(90, 24)
        Me.txt_total.TabIndex = 0
        Me.txt_total.TabStop = False
        Me.txt_total.Text = "0"
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(66, 31)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(49, 16)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "NETO:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(83, 63)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 16)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "IVA:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(5, 196)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 275
        Me.Label2.Text = "CANTIDAD:"
        '
        'txt_cantidad
        '
        Me.txt_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad.Location = New System.Drawing.Point(87, 193)
        Me.txt_cantidad.MaxLength = 3
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Size = New System.Drawing.Size(100, 24)
        Me.txt_cantidad.TabIndex = 2
        '
        'GroupBox_producto
        '
        Me.GroupBox_producto.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_producto.Controls.Add(Me.Label26)
        Me.GroupBox_producto.Controls.Add(Me.txt_precio)
        Me.GroupBox_producto.Controls.Add(Me.Label22)
        Me.GroupBox_producto.Controls.Add(Me.txt_nombre)
        Me.GroupBox_producto.Controls.Add(Me.txt_aplicacion)
        Me.GroupBox_producto.Controls.Add(Me.txt_numero_tecnico)
        Me.GroupBox_producto.Controls.Add(Me.btn_buscar_productos)
        Me.GroupBox_producto.Controls.Add(Me.txt_stock)
        Me.GroupBox_producto.Controls.Add(Me.txt_codigo)
        Me.GroupBox_producto.Controls.Add(Me.Label17)
        Me.GroupBox_producto.Controls.Add(Me.txt_factor)
        Me.GroupBox_producto.Controls.Add(Me.txt_marca)
        Me.GroupBox_producto.Controls.Add(Me.txt_proveedor)
        Me.GroupBox_producto.Controls.Add(Me.Label27)
        Me.GroupBox_producto.Controls.Add(Me.Label19)
        Me.GroupBox_producto.Controls.Add(Me.Label20)
        Me.GroupBox_producto.Controls.Add(Me.Label25)
        Me.GroupBox_producto.Controls.Add(Me.Label21)
        Me.GroupBox_producto.Controls.Add(Me.Label24)
        Me.GroupBox_producto.Controls.Add(Me.TextBox8)
        Me.GroupBox_producto.Controls.Add(Me.txt_rut_proveedor)
        Me.GroupBox_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_producto.ForeColor = System.Drawing.Color.Black
        Me.GroupBox_producto.Location = New System.Drawing.Point(7, 77)
        Me.GroupBox_producto.Name = "GroupBox_producto"
        Me.GroupBox_producto.Size = New System.Drawing.Size(1006, 109)
        Me.GroupBox_producto.TabIndex = 1
        Me.GroupBox_producto.TabStop = False
        Me.GroupBox_producto.Text = "DATOS DEL PRODUCTO ( F1 ):"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(413, 59)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(89, 16)
        Me.Label26.TabIndex = 26
        Me.Label26.Text = "APLICACION:"
        '
        'txt_precio
        '
        Me.txt_precio.BackColor = System.Drawing.SystemColors.Control
        Me.txt_precio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_precio.ForeColor = System.Drawing.Color.Black
        Me.txt_precio.Location = New System.Drawing.Point(292, 77)
        Me.txt_precio.Name = "txt_precio"
        Me.txt_precio.ReadOnly = True
        Me.txt_precio.Size = New System.Drawing.Size(113, 24)
        Me.txt_precio.TabIndex = 25
        Me.txt_precio.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(289, 59)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(61, 16)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "PRECIO:"
        '
        'txt_nombre
        '
        Me.txt_nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre.Location = New System.Drawing.Point(113, 33)
        Me.txt_nombre.MaxLength = 45
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.ReadOnly = True
        Me.txt_nombre.Size = New System.Drawing.Size(291, 24)
        Me.txt_nombre.TabIndex = 2
        Me.txt_nombre.TabStop = False
        '
        'txt_aplicacion
        '
        Me.txt_aplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_aplicacion.Location = New System.Drawing.Point(411, 77)
        Me.txt_aplicacion.MaxLength = 45
        Me.txt_aplicacion.Name = "txt_aplicacion"
        Me.txt_aplicacion.ReadOnly = True
        Me.txt_aplicacion.Size = New System.Drawing.Size(290, 24)
        Me.txt_aplicacion.TabIndex = 4
        Me.txt_aplicacion.TabStop = False
        '
        'txt_numero_tecnico
        '
        Me.txt_numero_tecnico.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numero_tecnico.Location = New System.Drawing.Point(707, 33)
        Me.txt_numero_tecnico.MaxLength = 45
        Me.txt_numero_tecnico.Name = "txt_numero_tecnico"
        Me.txt_numero_tecnico.ReadOnly = True
        Me.txt_numero_tecnico.Size = New System.Drawing.Size(292, 24)
        Me.txt_numero_tecnico.TabIndex = 3
        Me.txt_numero_tecnico.TabStop = False
        '
        'btn_buscar_productos
        '
        Me.btn_buscar_productos.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_buscar_productos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar_productos.ForeColor = System.Drawing.Color.Black
        Me.btn_buscar_productos.Image = CType(resources.GetObject("btn_buscar_productos.Image"), System.Drawing.Image)
        Me.btn_buscar_productos.Location = New System.Drawing.Point(7, 62)
        Me.btn_buscar_productos.Name = "btn_buscar_productos"
        Me.btn_buscar_productos.Size = New System.Drawing.Size(40, 40)
        Me.btn_buscar_productos.TabIndex = 14
        Me.btn_buscar_productos.TabStop = False
        Me.btn_buscar_productos.UseVisualStyleBackColor = True
        '
        'txt_stock
        '
        Me.txt_stock.BackColor = System.Drawing.SystemColors.Control
        Me.txt_stock.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_stock.ForeColor = System.Drawing.Color.Black
        Me.txt_stock.Location = New System.Drawing.Point(172, 77)
        Me.txt_stock.Name = "txt_stock"
        Me.txt_stock.ReadOnly = True
        Me.txt_stock.Size = New System.Drawing.Size(114, 24)
        Me.txt_stock.TabIndex = 17
        Me.txt_stock.TabStop = False
        '
        'txt_codigo
        '
        Me.txt_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo.Location = New System.Drawing.Point(7, 33)
        Me.txt_codigo.MaxLength = 6
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(100, 24)
        Me.txt_codigo.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(6, 15)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(63, 16)
        Me.Label17.TabIndex = 19
        Me.Label17.Text = "CODIGO:"
        '
        'txt_factor
        '
        Me.txt_factor.BackColor = System.Drawing.SystemColors.Control
        Me.txt_factor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_factor.ForeColor = System.Drawing.Color.Black
        Me.txt_factor.Location = New System.Drawing.Point(52, 77)
        Me.txt_factor.Name = "txt_factor"
        Me.txt_factor.ReadOnly = True
        Me.txt_factor.Size = New System.Drawing.Size(114, 24)
        Me.txt_factor.TabIndex = 20
        Me.txt_factor.TabStop = False
        '
        'txt_marca
        '
        Me.txt_marca.BackColor = System.Drawing.SystemColors.Control
        Me.txt_marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_marca.ForeColor = System.Drawing.Color.Black
        Me.txt_marca.Location = New System.Drawing.Point(410, 33)
        Me.txt_marca.Name = "txt_marca"
        Me.txt_marca.ReadOnly = True
        Me.txt_marca.Size = New System.Drawing.Size(291, 24)
        Me.txt_marca.TabIndex = 8
        Me.txt_marca.TabStop = False
        '
        'txt_proveedor
        '
        Me.txt_proveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txt_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_proveedor.ForeColor = System.Drawing.Color.Black
        Me.txt_proveedor.Location = New System.Drawing.Point(707, 77)
        Me.txt_proveedor.Name = "txt_proveedor"
        Me.txt_proveedor.ReadOnly = True
        Me.txt_proveedor.Size = New System.Drawing.Size(292, 24)
        Me.txt_proveedor.TabIndex = 5
        Me.txt_proveedor.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(704, 15)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(88, 16)
        Me.Label27.TabIndex = 12
        Me.Label27.Text = "Nº TECNICO:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(112, 15)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 16)
        Me.Label19.TabIndex = 13
        Me.Label19.Text = "NOMBRE:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(169, 59)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 16)
        Me.Label20.TabIndex = 6
        Me.Label20.Text = "STOCK:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(704, 59)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(97, 16)
        Me.Label25.TabIndex = 10
        Me.Label25.Text = "PROVEEDOR:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(408, 15)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 16)
        Me.Label21.TabIndex = 7
        Me.Label21.Text = "MARCA:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(49, 59)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(66, 16)
        Me.Label24.TabIndex = 9
        Me.Label24.Text = "FACTOR:"
        '
        'TextBox8
        '
        Me.TextBox8.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.ForeColor = System.Drawing.Color.Black
        Me.TextBox8.Location = New System.Drawing.Point(555, 36)
        Me.TextBox8.MaxLength = 8
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(21, 20)
        Me.TextBox8.TabIndex = 24
        Me.TextBox8.TabStop = False
        '
        'txt_rut_proveedor
        '
        Me.txt_rut_proveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txt_rut_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut_proveedor.ForeColor = System.Drawing.Color.Black
        Me.txt_rut_proveedor.Location = New System.Drawing.Point(783, 77)
        Me.txt_rut_proveedor.Name = "txt_rut_proveedor"
        Me.txt_rut_proveedor.ReadOnly = True
        Me.txt_rut_proveedor.Size = New System.Drawing.Size(67, 20)
        Me.txt_rut_proveedor.TabIndex = 27
        Me.txt_rut_proveedor.TabStop = False
        '
        'grilla_consumo_interno
        '
        Me.grilla_consumo_interno.AllowUserToAddRows = False
        Me.grilla_consumo_interno.AllowUserToDeleteRows = False
        Me.grilla_consumo_interno.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_consumo_interno.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grilla_consumo_interno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_consumo_interno.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cod_auto, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.Column3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.Column1, Me.Column2, Me.COSTO, Me.Column4})
        Me.grilla_consumo_interno.Location = New System.Drawing.Point(7, 271)
        Me.grilla_consumo_interno.Name = "grilla_consumo_interno"
        Me.grilla_consumo_interno.ReadOnly = True
        Me.grilla_consumo_interno.Size = New System.Drawing.Size(1005, 422)
        Me.grilla_consumo_interno.TabIndex = 281
        Me.grilla_consumo_interno.TabStop = False
        '
        'cod_auto
        '
        Me.cod_auto.HeaderText = "cod_auto"
        Me.cod_auto.Name = "cod_auto"
        Me.cod_auto.ReadOnly = True
        Me.cod_auto.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "NOMBRE"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "NRO. TEC."
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "APLIC."
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "CANT."
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "FECHA"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "HORA"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "RESPONSABLE"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "MOTIVO"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'COSTO
        '
        Me.COSTO.HeaderText = "COSTO"
        Me.COSTO.Name = "COSTO"
        Me.COSTO.ReadOnly = True
        Me.COSTO.Visible = False
        '
        'Column4
        '
        Me.Column4.HeaderText = "TOTAL"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        '
        'Timer_cierre
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(545, 236)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 294
        Me.Label1.Text = "LINEAS:"
        '
        'txt_item
        '
        Me.txt_item.BackColor = System.Drawing.SystemColors.Control
        Me.txt_item.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_item.ForeColor = System.Drawing.Color.Black
        Me.txt_item.Location = New System.Drawing.Point(605, 233)
        Me.txt_item.Name = "txt_item"
        Me.txt_item.ReadOnly = True
        Me.txt_item.Size = New System.Drawing.Size(100, 24)
        Me.txt_item.TabIndex = 293
        Me.txt_item.TabStop = False
        Me.txt_item.Text = "0"
        Me.txt_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_nro_vale
        '
        Me.txt_nro_vale.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_nro_vale.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_vale.ForeColor = System.Drawing.Color.Black
        Me.txt_nro_vale.Location = New System.Drawing.Point(1188, 521)
        Me.txt_nro_vale.Name = "txt_nro_vale"
        Me.txt_nro_vale.ReadOnly = True
        Me.txt_nro_vale.Size = New System.Drawing.Size(111, 24)
        Me.txt_nro_vale.TabIndex = 277
        Me.txt_nro_vale.TabStop = False
        Me.txt_nro_vale.Text = "0"
        Me.txt_nro_vale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Combo_motivo
        '
        Me.Combo_motivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_motivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_motivo.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_motivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_motivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_motivo.ForeColor = System.Drawing.Color.Black
        Me.Combo_motivo.FormattingEnabled = True
        Me.Combo_motivo.Items.AddRange(New Object() {"-", "USO LUBRICENTRO", "USO EXPRESS", "USO HIDRÁULICA", "USO BALATAS", "OTRO MOTIVO"})
        Me.Combo_motivo.Location = New System.Drawing.Point(756, 193)
        Me.Combo_motivo.Name = "Combo_motivo"
        Me.Combo_motivo.Size = New System.Drawing.Size(250, 26)
        Me.Combo_motivo.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(691, 196)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 296
        Me.Label3.Text = "MOTIVO:"
        '
        'Combo_responsable
        '
        Me.Combo_responsable.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_responsable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_responsable.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_responsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_responsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_responsable.ForeColor = System.Drawing.Color.Black
        Me.Combo_responsable.FormattingEnabled = True
        Me.Combo_responsable.Items.AddRange(New Object() {"EFECTIVO", "CREDITO"})
        Me.Combo_responsable.Location = New System.Drawing.Point(438, 193)
        Me.Combo_responsable.Name = "Combo_responsable"
        Me.Combo_responsable.Size = New System.Drawing.Size(250, 26)
        Me.Combo_responsable.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(325, 196)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(111, 16)
        Me.Label14.TabIndex = 299
        Me.Label14.Text = "RESPONSABLE:"
        '
        'txt_rut_responsable
        '
        Me.txt_rut_responsable.BackColor = System.Drawing.SystemColors.Control
        Me.txt_rut_responsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut_responsable.ForeColor = System.Drawing.Color.Black
        Me.txt_rut_responsable.Location = New System.Drawing.Point(513, 198)
        Me.txt_rut_responsable.Name = "txt_rut_responsable"
        Me.txt_rut_responsable.ReadOnly = True
        Me.txt_rut_responsable.Size = New System.Drawing.Size(90, 20)
        Me.txt_rut_responsable.TabIndex = 300
        Me.txt_rut_responsable.TabStop = False
        Me.txt_rut_responsable.Text = "0"
        Me.txt_rut_responsable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_quitar_elemento
        '
        Me.btn_quitar_elemento.BackColor = System.Drawing.Color.Transparent
        Me.btn_quitar_elemento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_quitar_elemento.ForeColor = System.Drawing.Color.Black
        Me.btn_quitar_elemento.Image = CType(resources.GetObject("btn_quitar_elemento.Image"), System.Drawing.Image)
        Me.btn_quitar_elemento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_quitar_elemento.Location = New System.Drawing.Point(911, 225)
        Me.btn_quitar_elemento.Name = "btn_quitar_elemento"
        Me.btn_quitar_elemento.Size = New System.Drawing.Size(95, 40)
        Me.btn_quitar_elemento.TabIndex = 6
        Me.btn_quitar_elemento.Text = "QUITAR F2"
        Me.btn_quitar_elemento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_quitar_elemento.UseVisualStyleBackColor = True
        '
        'btn_imprimir
        '
        Me.btn_imprimir.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.ForeColor = System.Drawing.Color.Black
        Me.btn_imprimir.Image = CType(resources.GetObject("btn_imprimir.Image"), System.Drawing.Image)
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprimir.Location = New System.Drawing.Point(710, 225)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(95, 40)
        Me.btn_imprimir.TabIndex = 270
        Me.btn_imprimir.TabStop = False
        Me.btn_imprimir.Text = "IMPRIMIR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir.UseVisualStyleBackColor = True
        '
        'btn_agregar
        '
        Me.btn_agregar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_agregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar.ForeColor = System.Drawing.Color.Black
        Me.btn_agregar.Image = CType(resources.GetObject("btn_agregar.Image"), System.Drawing.Image)
        Me.btn_agregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_agregar.Location = New System.Drawing.Point(811, 225)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(95, 40)
        Me.btn_agregar.TabIndex = 5
        Me.btn_agregar.Text = "AGREGAR"
        Me.btn_agregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(7, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 279
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox_clientes
        '
        Me.GroupBox_clientes.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_clientes.Controls.Add(Me.Label16)
        Me.GroupBox_clientes.Controls.Add(Me.Label28)
        Me.GroupBox_clientes.Controls.Add(Me.txt_rut_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.txt_nombre_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.Label30)
        Me.GroupBox_clientes.Controls.Add(Me.txt_comuna_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.Label31)
        Me.GroupBox_clientes.Controls.Add(Me.txt_giro_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.txt_direccion_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.Label32)
        Me.GroupBox_clientes.Controls.Add(Me.Label33)
        Me.GroupBox_clientes.Controls.Add(Me.btn_buscar_clientes)
        Me.GroupBox_clientes.Controls.Add(Me.Label34)
        Me.GroupBox_clientes.Controls.Add(Me.txt_telefono)
        Me.GroupBox_clientes.Controls.Add(Me.txt_cod_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.txt_correo_cliente)
        Me.GroupBox_clientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_clientes.Location = New System.Drawing.Point(110, 315)
        Me.GroupBox_clientes.Name = "GroupBox_clientes"
        Me.GroupBox_clientes.Size = New System.Drawing.Size(799, 108)
        Me.GroupBox_clientes.TabIndex = 301
        Me.GroupBox_clientes.TabStop = False
        Me.GroupBox_clientes.Text = "DATOS DEL PROVEEDOR ( F5 ):"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(510, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 16)
        Me.Label16.TabIndex = 363
        Me.Label16.Text = "CORREO:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(341, 15)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(83, 16)
        Me.Label28.TabIndex = 362
        Me.Label28.Text = "TELEFONO:"
        '
        'txt_rut_cliente
        '
        Me.txt_rut_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_rut_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_rut_cliente.Location = New System.Drawing.Point(7, 33)
        Me.txt_rut_cliente.MaxLength = 12
        Me.txt_rut_cliente.Name = "txt_rut_cliente"
        Me.txt_rut_cliente.ReadOnly = True
        Me.txt_rut_cliente.Size = New System.Drawing.Size(100, 24)
        Me.txt_rut_cliente.TabIndex = 2
        Me.txt_rut_cliente.TabStop = False
        '
        'txt_nombre_cliente
        '
        Me.txt_nombre_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_nombre_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_nombre_cliente.Location = New System.Drawing.Point(113, 33)
        Me.txt_nombre_cliente.MaxLength = 50
        Me.txt_nombre_cliente.Name = "txt_nombre_cliente"
        Me.txt_nombre_cliente.ReadOnly = True
        Me.txt_nombre_cliente.Size = New System.Drawing.Size(225, 24)
        Me.txt_nombre_cliente.TabIndex = 0
        Me.txt_nombre_cliente.TabStop = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(5, 58)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(70, 16)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "COMUNA:"
        '
        'txt_comuna_cliente
        '
        Me.txt_comuna_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_comuna_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_comuna_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_comuna_cliente.Location = New System.Drawing.Point(8, 76)
        Me.txt_comuna_cliente.MaxLength = 50
        Me.txt_comuna_cliente.Name = "txt_comuna_cliente"
        Me.txt_comuna_cliente.ReadOnly = True
        Me.txt_comuna_cliente.Size = New System.Drawing.Size(214, 24)
        Me.txt_comuna_cliente.TabIndex = 0
        Me.txt_comuna_cliente.TabStop = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(510, 58)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(44, 16)
        Me.Label31.TabIndex = 0
        Me.Label31.Text = "GIRO:"
        '
        'txt_giro_cliente
        '
        Me.txt_giro_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_giro_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_giro_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_giro_cliente.Location = New System.Drawing.Point(513, 76)
        Me.txt_giro_cliente.MaxLength = 50
        Me.txt_giro_cliente.Name = "txt_giro_cliente"
        Me.txt_giro_cliente.ReadOnly = True
        Me.txt_giro_cliente.Size = New System.Drawing.Size(279, 24)
        Me.txt_giro_cliente.TabIndex = 0
        Me.txt_giro_cliente.TabStop = False
        '
        'txt_direccion_cliente
        '
        Me.txt_direccion_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_direccion_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_direccion_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_direccion_cliente.HideSelection = False
        Me.txt_direccion_cliente.Location = New System.Drawing.Point(228, 76)
        Me.txt_direccion_cliente.MaxLength = 50
        Me.txt_direccion_cliente.Name = "txt_direccion_cliente"
        Me.txt_direccion_cliente.ReadOnly = True
        Me.txt_direccion_cliente.Size = New System.Drawing.Size(279, 24)
        Me.txt_direccion_cliente.TabIndex = 0
        Me.txt_direccion_cliente.TabStop = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(225, 58)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(84, 16)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "DIRECCION:"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(110, 15)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(70, 16)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "NOMBRE:"
        '
        'btn_buscar_clientes
        '
        Me.btn_buscar_clientes.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_buscar_clientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar_clientes.ForeColor = System.Drawing.Color.Black
        Me.btn_buscar_clientes.Image = CType(resources.GetObject("btn_buscar_clientes.Image"), System.Drawing.Image)
        Me.btn_buscar_clientes.Location = New System.Drawing.Point(752, 18)
        Me.btn_buscar_clientes.Name = "btn_buscar_clientes"
        Me.btn_buscar_clientes.Size = New System.Drawing.Size(40, 40)
        Me.btn_buscar_clientes.TabIndex = 0
        Me.btn_buscar_clientes.TabStop = False
        Me.btn_buscar_clientes.UseVisualStyleBackColor = True
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(5, 15)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(40, 16)
        Me.Label34.TabIndex = 0
        Me.Label34.Text = "RUT:"
        '
        'txt_telefono
        '
        Me.txt_telefono.BackColor = System.Drawing.SystemColors.Control
        Me.txt_telefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_telefono.ForeColor = System.Drawing.Color.Black
        Me.txt_telefono.Location = New System.Drawing.Point(344, 33)
        Me.txt_telefono.MaxLength = 50
        Me.txt_telefono.Name = "txt_telefono"
        Me.txt_telefono.ReadOnly = True
        Me.txt_telefono.Size = New System.Drawing.Size(163, 24)
        Me.txt_telefono.TabIndex = 3
        Me.txt_telefono.TabStop = False
        '
        'txt_cod_cliente
        '
        Me.txt_cod_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_cod_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_cod_cliente.Location = New System.Drawing.Point(607, 111)
        Me.txt_cod_cliente.Name = "txt_cod_cliente"
        Me.txt_cod_cliente.ReadOnly = True
        Me.txt_cod_cliente.Size = New System.Drawing.Size(56, 24)
        Me.txt_cod_cliente.TabIndex = 7
        Me.txt_cod_cliente.TabStop = False
        '
        'txt_correo_cliente
        '
        Me.txt_correo_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_correo_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_correo_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_correo_cliente.Location = New System.Drawing.Point(513, 33)
        Me.txt_correo_cliente.MaxLength = 50
        Me.txt_correo_cliente.Name = "txt_correo_cliente"
        Me.txt_correo_cliente.ReadOnly = True
        Me.txt_correo_cliente.Size = New System.Drawing.Size(234, 24)
        Me.txt_correo_cliente.TabIndex = 361
        Me.txt_correo_cliente.TabStop = False
        '
        'Form_consumo_interno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 699)
        Me.Controls.Add(Me.grilla_consumo_interno)
        Me.Controls.Add(Me.GroupBox_clientes)
        Me.Controls.Add(Me.Combo_responsable)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txt_rut_responsable)
        Me.Controls.Add(Me.Combo_motivo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_item)
        Me.Controls.Add(Me.btn_quitar_elemento)
        Me.Controls.Add(Me.txt_nro_guia)
        Me.Controls.Add(Me.btn_imprimir)
        Me.Controls.Add(Me.GroupBox_datos_producto)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.txt_nro_vale)
        Me.Controls.Add(Me.GroupBox_totales)
        Me.Controls.Add(Me.btn_agregar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_cantidad)
        Me.Controls.Add(Me.GroupBox_producto)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_consumo_interno"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONSUMO INTERNO"
        Me.GroupBox_datos_producto.ResumeLayout(False)
        Me.GroupBox_datos_producto.PerformLayout()
        Me.GroupBox_totales.ResumeLayout(False)
        Me.GroupBox_totales.PerformLayout()
        Me.GroupBox_producto.ResumeLayout(False)
        Me.GroupBox_producto.PerformLayout()
        CType(Me.grilla_consumo_interno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_clientes.ResumeLayout(False)
        Me.GroupBox_clientes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_nro_guia As System.Windows.Forms.TextBox
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents GroupBox_datos_producto As System.Windows.Forms.GroupBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txt_tipo_precio As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo_subfamilia_2 As System.Windows.Forms.TextBox
    Friend WithEvents Combo_tipo_precio As System.Windows.Forms.ComboBox
    Friend WithEvents txt_codigo_subfamilia As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_familia As System.Windows.Forms.TextBox
    Friend WithEvents lbl_tipo_cuenta As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad_minima As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txt_nro_doc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_tipo_doc As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad_ultima_compra As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtp_ultima_compra As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_codigo_barra As System.Windows.Forms.TextBox
    Friend WithEvents txt_costo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents GroupBox_totales As System.Windows.Forms.GroupBox
    Friend WithEvents txt_iva As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_neto As System.Windows.Forms.TextBox
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox_producto As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txt_precio As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents txt_aplicacion As System.Windows.Forms.TextBox
    Friend WithEvents txt_numero_tecnico As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar_productos As System.Windows.Forms.Button
    Friend WithEvents txt_stock As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_factor As System.Windows.Forms.TextBox
    Friend WithEvents txt_marca As System.Windows.Forms.TextBox
    Friend WithEvents txt_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents txt_rut_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents grilla_consumo_interno As System.Windows.Forms.DataGridView
    Friend WithEvents Timer_cierre As System.Windows.Forms.Timer
    Friend WithEvents btn_quitar_elemento As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_item As System.Windows.Forms.TextBox
    Friend WithEvents txt_nro_vale As System.Windows.Forms.TextBox
    Friend WithEvents Combo_motivo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Combo_responsable As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_rut_responsable As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox_clientes As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txt_rut_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txt_comuna_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txt_giro_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_direccion_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents btn_buscar_clientes As System.Windows.Forms.Button
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txt_telefono As System.Windows.Forms.TextBox
    Friend WithEvents txt_cod_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_correo_cliente As System.Windows.Forms.TextBox
    Friend WithEvents cod_auto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COSTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
