<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_solicitar_cotizacion
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_solicitar_cotizacion))
        Me.txt_observacion = New System.Windows.Forms.TextBox()
        Me.lbl_mensaje = New System.Windows.Forms.Label()
        Me.lbl_codigo = New System.Windows.Forms.Label()
        Me.txt_cantidad_producto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_codigo_producto = New System.Windows.Forms.TextBox()
        Me.grilla_pedidos = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_codigo_pedido = New System.Windows.Forms.TextBox()
        Me.txt_llegada_producto = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_año = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_cilindrada = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Combo_tipo_motor = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_nro_motor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_marca_vehiculo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_telefono_cliente = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_nombre_cliente = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_nro_chasis = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_modelo_vehiculo = New System.Windows.Forms.TextBox()
        Me.dtp_fecha_llegada = New System.Windows.Forms.DateTimePicker()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.btn_agregar = New System.Windows.Forms.Button()
        Me.btn_quitar_elemento = New System.Windows.Forms.Button()
        Me.btn_modificar = New System.Windows.Forms.Button()
        CType(Me.grilla_pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_observacion
        '
        Me.txt_observacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_observacion.Location = New System.Drawing.Point(6, 171)
        Me.txt_observacion.MaxLength = 50
        Me.txt_observacion.Multiline = True
        Me.txt_observacion.Name = "txt_observacion"
        Me.txt_observacion.ReadOnly = True
        Me.txt_observacion.Size = New System.Drawing.Size(872, 44)
        Me.txt_observacion.TabIndex = 5
        Me.txt_observacion.TabStop = False
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(307, 1)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(711, 82)
        Me.lbl_mensaje.TabIndex = 247
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'lbl_codigo
        '
        Me.lbl_codigo.AutoSize = True
        Me.lbl_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_codigo.Location = New System.Drawing.Point(64, 301)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(102, 16)
        Me.lbl_codigo.TabIndex = 2
        Me.lbl_codigo.Text = "DESCRIPCION:"
        '
        'txt_cantidad_producto
        '
        Me.txt_cantidad_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad_producto.Location = New System.Drawing.Point(12, 319)
        Me.txt_cantidad_producto.MaxLength = 4
        Me.txt_cantidad_producto.Name = "txt_cantidad_producto"
        Me.txt_cantidad_producto.Size = New System.Drawing.Size(48, 24)
        Me.txt_cantidad_producto.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 301)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "CANT.:"
        '
        'txt_codigo_producto
        '
        Me.txt_codigo_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_producto.Location = New System.Drawing.Point(66, 319)
        Me.txt_codigo_producto.MaxLength = 45
        Me.txt_codigo_producto.Name = "txt_codigo_producto"
        Me.txt_codigo_producto.Size = New System.Drawing.Size(526, 24)
        Me.txt_codigo_producto.TabIndex = 2
        '
        'grilla_pedidos
        '
        Me.grilla_pedidos.AllowUserToAddRows = False
        Me.grilla_pedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grilla_pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_pedidos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column4, Me.Column2, Me.Column3, Me.Column6, Me.Column7, Me.Column5, Me.Column9})
        Me.grilla_pedidos.Location = New System.Drawing.Point(6, 351)
        Me.grilla_pedidos.Name = "grilla_pedidos"
        Me.grilla_pedidos.ReadOnly = True
        Me.grilla_pedidos.Size = New System.Drawing.Size(1006, 342)
        Me.grilla_pedidos.TabIndex = 234
        Me.grilla_pedidos.TabStop = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "COD. ITEM"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "PROVEEDOR"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column2
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column2.HeaderText = "CANTIDAD"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "DESCRIPCION"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "COMENTARIO"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "ESTADO"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column5
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column5.HeaderText = "LLEGADA"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "rut_proveedor"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Visible = False
        '
        'txt_codigo_pedido
        '
        Me.txt_codigo_pedido.Enabled = False
        Me.txt_codigo_pedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_pedido.Location = New System.Drawing.Point(1032, 112)
        Me.txt_codigo_pedido.MaxLength = 11
        Me.txt_codigo_pedido.Name = "txt_codigo_pedido"
        Me.txt_codigo_pedido.Size = New System.Drawing.Size(111, 24)
        Me.txt_codigo_pedido.TabIndex = 239
        Me.txt_codigo_pedido.TabStop = False
        '
        'txt_llegada_producto
        '
        Me.txt_llegada_producto.Enabled = False
        Me.txt_llegada_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_llegada_producto.Location = New System.Drawing.Point(1032, 143)
        Me.txt_llegada_producto.MaxLength = 11
        Me.txt_llegada_producto.Name = "txt_llegada_producto"
        Me.txt_llegada_producto.Size = New System.Drawing.Size(111, 24)
        Me.txt_llegada_producto.TabIndex = 242
        Me.txt_llegada_producto.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.txt_año)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.txt_cilindrada)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Combo_tipo_motor)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txt_nro_motor)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.txt_marca_vehiculo)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.txt_observacion)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.txt_telefono_cliente)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.txt_nombre_cliente)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.txt_nro_chasis)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.txt_modelo_vehiculo)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(885, 223)
        Me.GroupBox4.TabIndex = 237
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "DATOS DEL PRODUCTO"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(301, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "AÑO:"
        '
        'txt_año
        '
        Me.txt_año.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_año.Location = New System.Drawing.Point(298, 83)
        Me.txt_año.MaxLength = 22
        Me.txt_año.Name = "txt_año"
        Me.txt_año.ReadOnly = True
        Me.txt_año.Size = New System.Drawing.Size(288, 24)
        Me.txt_año.TabIndex = 19
        Me.txt_año.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 16)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "CILINDRADA:"
        '
        'txt_cilindrada
        '
        Me.txt_cilindrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cilindrada.Location = New System.Drawing.Point(7, 83)
        Me.txt_cilindrada.MaxLength = 22
        Me.txt_cilindrada.Name = "txt_cilindrada"
        Me.txt_cilindrada.ReadOnly = True
        Me.txt_cilindrada.Size = New System.Drawing.Size(285, 24)
        Me.txt_cilindrada.TabIndex = 17
        Me.txt_cilindrada.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(592, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 16)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "TIPO MOTOR:"
        '
        'Combo_tipo_motor
        '
        Me.Combo_tipo_motor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_tipo_motor.Location = New System.Drawing.Point(592, 39)
        Me.Combo_tipo_motor.MaxLength = 22
        Me.Combo_tipo_motor.Name = "Combo_tipo_motor"
        Me.Combo_tipo_motor.ReadOnly = True
        Me.Combo_tipo_motor.Size = New System.Drawing.Size(286, 24)
        Me.Combo_tipo_motor.TabIndex = 15
        Me.Combo_tipo_motor.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 109)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 16)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "NRO. MOTOR:"
        '
        'txt_nro_motor
        '
        Me.txt_nro_motor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_motor.Location = New System.Drawing.Point(7, 127)
        Me.txt_nro_motor.MaxLength = 22
        Me.txt_nro_motor.Name = "txt_nro_motor"
        Me.txt_nro_motor.ReadOnly = True
        Me.txt_nro_motor.Size = New System.Drawing.Size(285, 24)
        Me.txt_nro_motor.TabIndex = 13
        Me.txt_nro_motor.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "MARCA VEHICULO:"
        '
        'txt_marca_vehiculo
        '
        Me.txt_marca_vehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_marca_vehiculo.Location = New System.Drawing.Point(6, 39)
        Me.txt_marca_vehiculo.MaxLength = 22
        Me.txt_marca_vehiculo.Name = "txt_marca_vehiculo"
        Me.txt_marca_vehiculo.ReadOnly = True
        Me.txt_marca_vehiculo.Size = New System.Drawing.Size(286, 24)
        Me.txt_marca_vehiculo.TabIndex = 11
        Me.txt_marca_vehiculo.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 153)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "OBSERVACION:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(591, 109)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(142, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "TELEFONO CLIENTE:"
        '
        'txt_telefono_cliente
        '
        Me.txt_telefono_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_telefono_cliente.Location = New System.Drawing.Point(592, 127)
        Me.txt_telefono_cliente.MaxLength = 22
        Me.txt_telefono_cliente.Name = "txt_telefono_cliente"
        Me.txt_telefono_cliente.ReadOnly = True
        Me.txt_telefono_cliente.Size = New System.Drawing.Size(286, 24)
        Me.txt_telefono_cliente.TabIndex = 8
        Me.txt_telefono_cliente.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(298, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "NOMBRE CLIENTE:"
        '
        'txt_nombre_cliente
        '
        Me.txt_nombre_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_cliente.Location = New System.Drawing.Point(298, 127)
        Me.txt_nombre_cliente.MaxLength = 22
        Me.txt_nombre_cliente.Name = "txt_nombre_cliente"
        Me.txt_nombre_cliente.ReadOnly = True
        Me.txt_nombre_cliente.Size = New System.Drawing.Size(288, 24)
        Me.txt_nombre_cliente.TabIndex = 6
        Me.txt_nombre_cliente.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(591, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "NRO. CHASIS:"
        '
        'txt_nro_chasis
        '
        Me.txt_nro_chasis.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_chasis.Location = New System.Drawing.Point(592, 83)
        Me.txt_nro_chasis.MaxLength = 22
        Me.txt_nro_chasis.Name = "txt_nro_chasis"
        Me.txt_nro_chasis.ReadOnly = True
        Me.txt_nro_chasis.Size = New System.Drawing.Size(286, 24)
        Me.txt_nro_chasis.TabIndex = 4
        Me.txt_nro_chasis.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(298, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "MODELO VEHICULO:"
        '
        'txt_modelo_vehiculo
        '
        Me.txt_modelo_vehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_modelo_vehiculo.Location = New System.Drawing.Point(298, 39)
        Me.txt_modelo_vehiculo.MaxLength = 22
        Me.txt_modelo_vehiculo.Name = "txt_modelo_vehiculo"
        Me.txt_modelo_vehiculo.ReadOnly = True
        Me.txt_modelo_vehiculo.Size = New System.Drawing.Size(288, 24)
        Me.txt_modelo_vehiculo.TabIndex = 2
        Me.txt_modelo_vehiculo.TabStop = False
        '
        'dtp_fecha_llegada
        '
        Me.dtp_fecha_llegada.Enabled = False
        Me.dtp_fecha_llegada.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_llegada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha_llegada.Location = New System.Drawing.Point(1032, 81)
        Me.dtp_fecha_llegada.Name = "dtp_fecha_llegada"
        Me.dtp_fecha_llegada.Size = New System.Drawing.Size(111, 24)
        Me.dtp_fecha_llegada.TabIndex = 246
        Me.dtp_fecha_llegada.TabStop = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.Transparent
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.Location = New System.Drawing.Point(907, 132)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(95, 40)
        Me.btn_guardar.TabIndex = 2
        Me.btn_guardar.Text = "GUARDAR"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
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
        'btn_agregar
        '
        Me.btn_agregar.BackColor = System.Drawing.Color.Transparent
        Me.btn_agregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar.Image = CType(resources.GetObject("btn_agregar.Image"), System.Drawing.Image)
        Me.btn_agregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_agregar.Location = New System.Drawing.Point(807, 305)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(95, 40)
        Me.btn_agregar.TabIndex = 4
        Me.btn_agregar.Text = "AGREGAR"
        Me.btn_agregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_agregar.UseVisualStyleBackColor = False
        '
        'btn_quitar_elemento
        '
        Me.btn_quitar_elemento.BackColor = System.Drawing.Color.Transparent
        Me.btn_quitar_elemento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_quitar_elemento.Image = CType(resources.GetObject("btn_quitar_elemento.Image"), System.Drawing.Image)
        Me.btn_quitar_elemento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_quitar_elemento.Location = New System.Drawing.Point(907, 305)
        Me.btn_quitar_elemento.Name = "btn_quitar_elemento"
        Me.btn_quitar_elemento.Size = New System.Drawing.Size(95, 40)
        Me.btn_quitar_elemento.TabIndex = 5
        Me.btn_quitar_elemento.Text = "QUITAR"
        Me.btn_quitar_elemento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_quitar_elemento.UseVisualStyleBackColor = False
        '
        'btn_modificar
        '
        Me.btn_modificar.BackColor = System.Drawing.Color.Transparent
        Me.btn_modificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_modificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_modificar.Image = CType(resources.GetObject("btn_modificar.Image"), System.Drawing.Image)
        Me.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_modificar.Location = New System.Drawing.Point(907, 86)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(95, 40)
        Me.btn_modificar.TabIndex = 1
        Me.btn_modificar.Text = "MODIFICAR"
        Me.btn_modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_modificar.UseVisualStyleBackColor = False
        '
        'Form_solicitar_cotizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 699)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.btn_modificar)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.lbl_codigo)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.txt_cantidad_producto)
        Me.Controls.Add(Me.btn_agregar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_quitar_elemento)
        Me.Controls.Add(Me.txt_codigo_producto)
        Me.Controls.Add(Me.grilla_pedidos)
        Me.Controls.Add(Me.txt_codigo_pedido)
        Me.Controls.Add(Me.txt_llegada_producto)
        Me.Controls.Add(Me.dtp_fecha_llegada)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_solicitar_cotizacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SOLICITAR COTIZACION"
        CType(Me.grilla_pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_observacion As TextBox
    Friend WithEvents lbl_mensaje As Label
    Friend WithEvents btn_guardar As Button
    Friend WithEvents PictureBox_logo As PictureBox
    Friend WithEvents lbl_codigo As Label
    Friend WithEvents txt_cantidad_producto As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_codigo_producto As TextBox
    Friend WithEvents btn_agregar As Button
    Friend WithEvents btn_quitar_elemento As Button
    Friend WithEvents grilla_pedidos As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents txt_codigo_pedido As TextBox
    Friend WithEvents txt_llegada_producto As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_telefono_cliente As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_nombre_cliente As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_nro_chasis As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_modelo_vehiculo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dtp_fecha_llegada As DateTimePicker
    Friend WithEvents btn_modificar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_marca_vehiculo As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txt_nro_motor As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Combo_tipo_motor As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txt_cilindrada As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_año As TextBox
End Class
