<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_reservas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_reservas))
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.lbl_mensaje = New System.Windows.Forms.Label
        Me.grilla_detalle_venta = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btn_quitar_elemento = New System.Windows.Forms.Button
        Me.btn_agregar = New System.Windows.Forms.Button
        Me.txt_proveedor = New System.Windows.Forms.TextBox
        Me.txt_costo = New System.Windows.Forms.TextBox
        Me.txt_precio = New System.Windows.Forms.TextBox
        Me.lbl_codigo = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.txt_nombre_proveedor = New System.Windows.Forms.TextBox
        Me.txt_marca = New System.Windows.Forms.TextBox
        Me.txt_factor = New System.Windows.Forms.TextBox
        Me.txt_nombre_producto = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_cantidad = New System.Windows.Forms.TextBox
        Me.btn_buscar_productos = New System.Windows.Forms.Button
        Me.txt_codigo = New System.Windows.Forms.TextBox
        Me.txt_numero_tecnico = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txt_aplicacion = New System.Windows.Forms.TextBox
        Me.GroupBox_producto = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_cantidad_agregar = New System.Windows.Forms.TextBox
        Me.lbl_cantidad_agregar = New System.Windows.Forms.Label
        Me.PictureBox_imagen = New System.Windows.Forms.PictureBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dtp_hasta = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtp_desde = New System.Windows.Forms.DateTimePicker
        Me.lbl_venta = New System.Windows.Forms.Label
        Me.lbl_usuario_conectado = New System.Windows.Forms.Label
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_detalle_venta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_producto.SuspendLayout()
        CType(Me.PictureBox_imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 243
        Me.PictureBox_logo.TabStop = False
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(307, 1)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(711, 81)
        Me.lbl_mensaje.TabIndex = 248
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'grilla_detalle_venta
        '
        Me.grilla_detalle_venta.AllowUserToAddRows = False
        Me.grilla_detalle_venta.AllowUserToDeleteRows = False
        Me.grilla_detalle_venta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_detalle_venta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grilla_detalle_venta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_detalle_venta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla_detalle_venta.DefaultCellStyle = DataGridViewCellStyle6
        Me.grilla_detalle_venta.Location = New System.Drawing.Point(6, 237)
        Me.grilla_detalle_venta.Name = "grilla_detalle_venta"
        Me.grilla_detalle_venta.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_detalle_venta.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        Me.grilla_detalle_venta.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.grilla_detalle_venta.Size = New System.Drawing.Size(1006, 457)
        Me.grilla_detalle_venta.TabIndex = 250
        Me.grilla_detalle_venta.TabStop = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "CODIGO"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "NOMBRE"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "N° TECNICO"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column4.HeaderText = "CANTIDAD"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column5.HeaderText = "PRECIO"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column6.HeaderText = "TOTAL"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column7.HeaderText = "FECHA"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'btn_quitar_elemento
        '
        Me.btn_quitar_elemento.BackColor = System.Drawing.Color.Transparent
        Me.btn_quitar_elemento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_quitar_elemento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_quitar_elemento.ForeColor = System.Drawing.Color.Black
        Me.btn_quitar_elemento.Image = CType(resources.GetObject("btn_quitar_elemento.Image"), System.Drawing.Image)
        Me.btn_quitar_elemento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_quitar_elemento.Location = New System.Drawing.Point(907, 191)
        Me.btn_quitar_elemento.Name = "btn_quitar_elemento"
        Me.btn_quitar_elemento.Size = New System.Drawing.Size(95, 40)
        Me.btn_quitar_elemento.TabIndex = 4
        Me.btn_quitar_elemento.Text = "QUITAR"
        Me.btn_quitar_elemento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_quitar_elemento.UseVisualStyleBackColor = False
        '
        'btn_agregar
        '
        Me.btn_agregar.BackColor = System.Drawing.Color.Transparent
        Me.btn_agregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_agregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar.ForeColor = System.Drawing.Color.Black
        Me.btn_agregar.Image = CType(resources.GetObject("btn_agregar.Image"), System.Drawing.Image)
        Me.btn_agregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_agregar.Location = New System.Drawing.Point(807, 191)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(95, 40)
        Me.btn_agregar.TabIndex = 3
        Me.btn_agregar.Text = "AGREGAR"
        Me.btn_agregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_agregar.UseVisualStyleBackColor = False
        '
        'txt_proveedor
        '
        Me.txt_proveedor.ForeColor = System.Drawing.Color.Black
        Me.txt_proveedor.Location = New System.Drawing.Point(237, 33)
        Me.txt_proveedor.Name = "txt_proveedor"
        Me.txt_proveedor.ReadOnly = True
        Me.txt_proveedor.Size = New System.Drawing.Size(24, 22)
        Me.txt_proveedor.TabIndex = 0
        Me.txt_proveedor.TabStop = False
        Me.txt_proveedor.Visible = False
        '
        'txt_costo
        '
        Me.txt_costo.ForeColor = System.Drawing.Color.Black
        Me.txt_costo.Location = New System.Drawing.Point(264, 33)
        Me.txt_costo.Name = "txt_costo"
        Me.txt_costo.ReadOnly = True
        Me.txt_costo.Size = New System.Drawing.Size(24, 22)
        Me.txt_costo.TabIndex = 0
        Me.txt_costo.TabStop = False
        Me.txt_costo.Visible = False
        '
        'txt_precio
        '
        Me.txt_precio.BackColor = System.Drawing.SystemColors.Control
        Me.txt_precio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_precio.ForeColor = System.Drawing.Color.Black
        Me.txt_precio.Location = New System.Drawing.Point(294, 77)
        Me.txt_precio.MaxLength = 8
        Me.txt_precio.Name = "txt_precio"
        Me.txt_precio.Size = New System.Drawing.Size(114, 24)
        Me.txt_precio.TabIndex = 24
        Me.txt_precio.TabStop = False
        '
        'lbl_codigo
        '
        Me.lbl_codigo.AutoSize = True
        Me.lbl_codigo.ForeColor = System.Drawing.Color.Black
        Me.lbl_codigo.Location = New System.Drawing.Point(30, 39)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(39, 16)
        Me.lbl_codigo.TabIndex = 0
        Me.lbl_codigo.Text = "nada"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(49, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 16)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "FACTOR:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(413, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "MARCA:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(714, 59)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(97, 16)
        Me.Label25.TabIndex = 10
        Me.Label25.Text = "PROVEEDOR:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(170, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "STOCK:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(112, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "NOMBRE:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(714, 15)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(88, 16)
        Me.Label27.TabIndex = 12
        Me.Label27.Text = "Nº TECNICO:"
        '
        'txt_nombre_proveedor
        '
        Me.txt_nombre_proveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txt_nombre_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_proveedor.ForeColor = System.Drawing.Color.Black
        Me.txt_nombre_proveedor.Location = New System.Drawing.Point(717, 77)
        Me.txt_nombre_proveedor.Name = "txt_nombre_proveedor"
        Me.txt_nombre_proveedor.ReadOnly = True
        Me.txt_nombre_proveedor.Size = New System.Drawing.Size(282, 24)
        Me.txt_nombre_proveedor.TabIndex = 5
        Me.txt_nombre_proveedor.TabStop = False
        '
        'txt_marca
        '
        Me.txt_marca.BackColor = System.Drawing.SystemColors.Control
        Me.txt_marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_marca.ForeColor = System.Drawing.Color.Black
        Me.txt_marca.Location = New System.Drawing.Point(414, 33)
        Me.txt_marca.Name = "txt_marca"
        Me.txt_marca.ReadOnly = True
        Me.txt_marca.Size = New System.Drawing.Size(295, 24)
        Me.txt_marca.TabIndex = 8
        Me.txt_marca.TabStop = False
        '
        'txt_factor
        '
        Me.txt_factor.BackColor = System.Drawing.SystemColors.Control
        Me.txt_factor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_factor.ForeColor = System.Drawing.Color.Black
        Me.txt_factor.Location = New System.Drawing.Point(52, 77)
        Me.txt_factor.Name = "txt_factor"
        Me.txt_factor.ReadOnly = True
        Me.txt_factor.Size = New System.Drawing.Size(115, 24)
        Me.txt_factor.TabIndex = 20
        Me.txt_factor.TabStop = False
        '
        'txt_nombre_producto
        '
        Me.txt_nombre_producto.BackColor = System.Drawing.SystemColors.Control
        Me.txt_nombre_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_producto.ForeColor = System.Drawing.Color.Black
        Me.txt_nombre_producto.Location = New System.Drawing.Point(113, 33)
        Me.txt_nombre_producto.Name = "txt_nombre_producto"
        Me.txt_nombre_producto.ReadOnly = True
        Me.txt_nombre_producto.Size = New System.Drawing.Size(295, 24)
        Me.txt_nombre_producto.TabIndex = 2
        Me.txt_nombre_producto.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 16)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "CODIGO:"
        '
        'txt_cantidad
        '
        Me.txt_cantidad.BackColor = System.Drawing.SystemColors.Control
        Me.txt_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad.ForeColor = System.Drawing.Color.Black
        Me.txt_cantidad.Location = New System.Drawing.Point(173, 77)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.ReadOnly = True
        Me.txt_cantidad.Size = New System.Drawing.Size(115, 24)
        Me.txt_cantidad.TabIndex = 17
        Me.txt_cantidad.TabStop = False
        '
        'btn_buscar_productos
        '
        Me.btn_buscar_productos.BackColor = System.Drawing.Color.Transparent
        Me.btn_buscar_productos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_buscar_productos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar_productos.ForeColor = System.Drawing.Color.Black
        Me.btn_buscar_productos.Image = CType(resources.GetObject("btn_buscar_productos.Image"), System.Drawing.Image)
        Me.btn_buscar_productos.Location = New System.Drawing.Point(7, 62)
        Me.btn_buscar_productos.Name = "btn_buscar_productos"
        Me.btn_buscar_productos.Size = New System.Drawing.Size(40, 40)
        Me.btn_buscar_productos.TabIndex = 14
        Me.btn_buscar_productos.TabStop = False
        Me.btn_buscar_productos.UseVisualStyleBackColor = False
        '
        'txt_codigo
        '
        Me.txt_codigo.BackColor = System.Drawing.SystemColors.Window
        Me.txt_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo.ForeColor = System.Drawing.Color.Black
        Me.txt_codigo.Location = New System.Drawing.Point(7, 33)
        Me.txt_codigo.MaxLength = 25
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(100, 24)
        Me.txt_codigo.TabIndex = 1
        '
        'txt_numero_tecnico
        '
        Me.txt_numero_tecnico.BackColor = System.Drawing.SystemColors.Control
        Me.txt_numero_tecnico.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numero_tecnico.ForeColor = System.Drawing.Color.Black
        Me.txt_numero_tecnico.Location = New System.Drawing.Point(715, 33)
        Me.txt_numero_tecnico.Name = "txt_numero_tecnico"
        Me.txt_numero_tecnico.ReadOnly = True
        Me.txt_numero_tecnico.Size = New System.Drawing.Size(284, 24)
        Me.txt_numero_tecnico.TabIndex = 0
        Me.txt_numero_tecnico.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(413, 59)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(89, 16)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "APLICACION:"
        '
        'txt_aplicacion
        '
        Me.txt_aplicacion.BackColor = System.Drawing.SystemColors.Control
        Me.txt_aplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_aplicacion.ForeColor = System.Drawing.Color.Black
        Me.txt_aplicacion.Location = New System.Drawing.Point(414, 77)
        Me.txt_aplicacion.Name = "txt_aplicacion"
        Me.txt_aplicacion.ReadOnly = True
        Me.txt_aplicacion.Size = New System.Drawing.Size(297, 24)
        Me.txt_aplicacion.TabIndex = 23
        Me.txt_aplicacion.TabStop = False
        '
        'GroupBox_producto
        '
        Me.GroupBox_producto.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_producto.Controls.Add(Me.Label1)
        Me.GroupBox_producto.Controls.Add(Me.txt_aplicacion)
        Me.GroupBox_producto.Controls.Add(Me.Label22)
        Me.GroupBox_producto.Controls.Add(Me.txt_numero_tecnico)
        Me.GroupBox_producto.Controls.Add(Me.txt_codigo)
        Me.GroupBox_producto.Controls.Add(Me.btn_buscar_productos)
        Me.GroupBox_producto.Controls.Add(Me.txt_cantidad)
        Me.GroupBox_producto.Controls.Add(Me.Label5)
        Me.GroupBox_producto.Controls.Add(Me.txt_precio)
        Me.GroupBox_producto.Controls.Add(Me.txt_nombre_producto)
        Me.GroupBox_producto.Controls.Add(Me.txt_factor)
        Me.GroupBox_producto.Controls.Add(Me.txt_marca)
        Me.GroupBox_producto.Controls.Add(Me.txt_nombre_proveedor)
        Me.GroupBox_producto.Controls.Add(Me.Label27)
        Me.GroupBox_producto.Controls.Add(Me.Label6)
        Me.GroupBox_producto.Controls.Add(Me.Label11)
        Me.GroupBox_producto.Controls.Add(Me.Label25)
        Me.GroupBox_producto.Controls.Add(Me.Label7)
        Me.GroupBox_producto.Controls.Add(Me.Label9)
        Me.GroupBox_producto.Controls.Add(Me.lbl_codigo)
        Me.GroupBox_producto.Controls.Add(Me.txt_costo)
        Me.GroupBox_producto.Controls.Add(Me.txt_proveedor)
        Me.GroupBox_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_producto.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox_producto.Name = "GroupBox_producto"
        Me.GroupBox_producto.Size = New System.Drawing.Size(1006, 109)
        Me.GroupBox_producto.TabIndex = 1
        Me.GroupBox_producto.TabStop = False
        Me.GroupBox_producto.Text = "DATOS DEL PRODUCTO ( F1 ):"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(291, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 16)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "PRECIO:"
        '
        'txt_cantidad_agregar
        '
        Me.txt_cantidad_agregar.BackColor = System.Drawing.Color.White
        Me.txt_cantidad_agregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad_agregar.ForeColor = System.Drawing.Color.Black
        Me.txt_cantidad_agregar.Location = New System.Drawing.Point(157, 198)
        Me.txt_cantidad_agregar.MaxLength = 5
        Me.txt_cantidad_agregar.Name = "txt_cantidad_agregar"
        Me.txt_cantidad_agregar.Size = New System.Drawing.Size(100, 24)
        Me.txt_cantidad_agregar.TabIndex = 2
        '
        'lbl_cantidad_agregar
        '
        Me.lbl_cantidad_agregar.AutoSize = True
        Me.lbl_cantidad_agregar.BackColor = System.Drawing.Color.Transparent
        Me.lbl_cantidad_agregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cantidad_agregar.ForeColor = System.Drawing.Color.Black
        Me.lbl_cantidad_agregar.Location = New System.Drawing.Point(5, 201)
        Me.lbl_cantidad_agregar.Name = "lbl_cantidad_agregar"
        Me.lbl_cantidad_agregar.Size = New System.Drawing.Size(150, 16)
        Me.lbl_cantidad_agregar.TabIndex = 251
        Me.lbl_cantidad_agregar.Text = "AGREGAR CANTIDAD:"
        '
        'PictureBox_imagen
        '
        Me.PictureBox_imagen.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_imagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_imagen.ErrorImage = Nothing
        Me.PictureBox_imagen.Location = New System.Drawing.Point(312, 1)
        Me.PictureBox_imagen.Name = "PictureBox_imagen"
        Me.PictureBox_imagen.Size = New System.Drawing.Size(51, 61)
        Me.PictureBox_imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox_imagen.TabIndex = 253
        Me.PictureBox_imagen.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dtp_hasta)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(447, 370)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(125, 54)
        Me.GroupBox3.TabIndex = 257
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "HASTA:"
        '
        'dtp_hasta
        '
        Me.dtp_hasta.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_hasta.Location = New System.Drawing.Point(7, 20)
        Me.dtp_hasta.Name = "dtp_hasta"
        Me.dtp_hasta.Size = New System.Drawing.Size(111, 24)
        Me.dtp_hasta.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtp_desde)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(447, 316)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(125, 54)
        Me.GroupBox1.TabIndex = 256
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DESDE:"
        '
        'dtp_desde
        '
        Me.dtp_desde.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_desde.Location = New System.Drawing.Point(7, 20)
        Me.dtp_desde.Name = "dtp_desde"
        Me.dtp_desde.Size = New System.Drawing.Size(111, 24)
        Me.dtp_desde.TabIndex = 2
        '
        'lbl_venta
        '
        Me.lbl_venta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_venta.AutoSize = True
        Me.lbl_venta.BackColor = System.Drawing.Color.Transparent
        Me.lbl_venta.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_venta.ForeColor = System.Drawing.Color.Black
        Me.lbl_venta.Location = New System.Drawing.Point(971, 30)
        Me.lbl_venta.Name = "lbl_venta"
        Me.lbl_venta.Size = New System.Drawing.Size(39, 23)
        Me.lbl_venta.TabIndex = 259
        Me.lbl_venta.Text = "$: 0"
        Me.lbl_venta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_usuario_conectado
        '
        Me.lbl_usuario_conectado.BackColor = System.Drawing.Color.Transparent
        Me.lbl_usuario_conectado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_usuario_conectado.ForeColor = System.Drawing.Color.Black
        Me.lbl_usuario_conectado.Location = New System.Drawing.Point(364, 2)
        Me.lbl_usuario_conectado.Name = "lbl_usuario_conectado"
        Me.lbl_usuario_conectado.Size = New System.Drawing.Size(253, 19)
        Me.lbl_usuario_conectado.TabIndex = 260
        Me.lbl_usuario_conectado.Text = "NOMBRE DE USUARIO"
        Me.lbl_usuario_conectado.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Form_reservas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 700)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.lbl_venta)
        Me.Controls.Add(Me.lbl_usuario_conectado)
        Me.Controls.Add(Me.txt_cantidad_agregar)
        Me.Controls.Add(Me.lbl_cantidad_agregar)
        Me.Controls.Add(Me.btn_agregar)
        Me.Controls.Add(Me.btn_quitar_elemento)
        Me.Controls.Add(Me.grilla_detalle_venta)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.PictureBox_imagen)
        Me.Controls.Add(Me.GroupBox_producto)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_reservas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RESERVAS"
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_detalle_venta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_producto.ResumeLayout(False)
        Me.GroupBox_producto.PerformLayout()
        CType(Me.PictureBox_imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents grilla_detalle_venta As System.Windows.Forms.DataGridView
    Friend WithEvents btn_quitar_elemento As System.Windows.Forms.Button
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents txt_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_costo As System.Windows.Forms.TextBox
    Friend WithEvents txt_precio As System.Windows.Forms.TextBox
    Friend WithEvents lbl_codigo As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txt_nombre_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_marca As System.Windows.Forms.TextBox
    Friend WithEvents txt_factor As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_producto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar_productos As System.Windows.Forms.Button
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents txt_numero_tecnico As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txt_aplicacion As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox_producto As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad_agregar As System.Windows.Forms.TextBox
    Friend WithEvents lbl_cantidad_agregar As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox_imagen As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_venta As System.Windows.Forms.Label
    Friend WithEvents lbl_usuario_conectado As System.Windows.Forms.Label
End Class
