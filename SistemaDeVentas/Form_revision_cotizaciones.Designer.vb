<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_revision_cotizaciones
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_revision_cotizaciones))
        Me.dtp_desde = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_hasta = New System.Windows.Forms.DateTimePicker()
        Me.lbl_mensaje = New System.Windows.Forms.Label()
        Me.grilla_revision_pedidos = New System.Windows.Forms.DataGridView()
        Me.txt_codigo_pedido = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox_1 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Combo_prioridad = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Combo_marca = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Combo_vendedor = New System.Windows.Forms.ComboBox()
        Me.Combo_proveedor = New System.Windows.Forms.ComboBox()
        Me.dtp3 = New System.Windows.Forms.DateTimePicker()
        Me.grilla_ofertas = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btn_editar_oferta = New System.Windows.Forms.Button()
        Me.btn_encargar_pedido = New System.Windows.Forms.Button()
        Me.btn_aceptar_oferta = New System.Windows.Forms.Button()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.txt_copiar_y_pegar = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbl_telefono_cliente = New System.Windows.Forms.Label()
        Me.lbl_nombre_cliente = New System.Windows.Forms.Label()
        Me.btn_eliminar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grilla_revision_pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_1.SuspendLayout()
        CType(Me.grilla_ofertas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtp_desde
        '
        Me.dtp_desde.Checked = False
        Me.dtp_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_desde.Location = New System.Drawing.Point(7, 33)
        Me.dtp_desde.Name = "dtp_desde"
        Me.dtp_desde.Size = New System.Drawing.Size(111, 24)
        Me.dtp_desde.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtp_desde)
        Me.GroupBox1.Controls.Add(Me.dtp_hasta)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(770, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(242, 66)
        Me.GroupBox1.TabIndex = 259
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "RANGO FECHAS:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(121, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "HASTA:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "DESDE:"
        '
        'dtp_hasta
        '
        Me.dtp_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_hasta.Location = New System.Drawing.Point(124, 33)
        Me.dtp_hasta.Name = "dtp_hasta"
        Me.dtp_hasta.Size = New System.Drawing.Size(111, 24)
        Me.dtp_hasta.TabIndex = 6
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(307, 1)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(711, 81)
        Me.lbl_mensaje.TabIndex = 270
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'grilla_revision_pedidos
        '
        Me.grilla_revision_pedidos.AllowUserToAddRows = False
        Me.grilla_revision_pedidos.AllowUserToDeleteRows = False
        Me.grilla_revision_pedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_revision_pedidos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grilla_revision_pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla_revision_pedidos.DefaultCellStyle = DataGridViewCellStyle2
        Me.grilla_revision_pedidos.Location = New System.Drawing.Point(6, 148)
        Me.grilla_revision_pedidos.Name = "grilla_revision_pedidos"
        Me.grilla_revision_pedidos.Size = New System.Drawing.Size(1006, 259)
        Me.grilla_revision_pedidos.TabIndex = 271
        Me.grilla_revision_pedidos.TabStop = False
        '
        'txt_codigo_pedido
        '
        Me.txt_codigo_pedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_pedido.Location = New System.Drawing.Point(7, 34)
        Me.txt_codigo_pedido.MaxLength = 11
        Me.txt_codigo_pedido.Name = "txt_codigo_pedido"
        Me.txt_codigo_pedido.Size = New System.Drawing.Size(114, 24)
        Me.txt_codigo_pedido.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(4, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 16)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "COD. PEDIDO:"
        '
        'GroupBox_1
        '
        Me.GroupBox_1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_1.Controls.Add(Me.Label9)
        Me.GroupBox_1.Controls.Add(Me.Combo_prioridad)
        Me.GroupBox_1.Controls.Add(Me.Label10)
        Me.GroupBox_1.Controls.Add(Me.Combo_marca)
        Me.GroupBox_1.Controls.Add(Me.txt_codigo_pedido)
        Me.GroupBox_1.Controls.Add(Me.Label11)
        Me.GroupBox_1.Controls.Add(Me.Label2)
        Me.GroupBox_1.Controls.Add(Me.Label3)
        Me.GroupBox_1.Controls.Add(Me.Combo_vendedor)
        Me.GroupBox_1.Controls.Add(Me.Combo_proveedor)
        Me.GroupBox_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_1.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox_1.Name = "GroupBox_1"
        Me.GroupBox_1.Size = New System.Drawing.Size(758, 66)
        Me.GroupBox_1.TabIndex = 257
        Me.GroupBox_1.TabStop = False
        Me.GroupBox_1.Text = "FILTROS:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(464, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "MARCA:"
        '
        'Combo_prioridad
        '
        Me.Combo_prioridad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_prioridad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_prioridad.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_prioridad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_prioridad.FormattingEnabled = True
        Me.Combo_prioridad.Items.AddRange(New Object() {"TODOS", "ENCARGADO", "ACEPTADO", "EN ESPERA"})
        Me.Combo_prioridad.Location = New System.Drawing.Point(636, 34)
        Me.Combo_prioridad.MaxLength = 12
        Me.Combo_prioridad.Name = "Combo_prioridad"
        Me.Combo_prioridad.Size = New System.Drawing.Size(115, 24)
        Me.Combo_prioridad.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(633, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 16)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "PRIORIDAD:"
        '
        'Combo_marca
        '
        Me.Combo_marca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_marca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_marca.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_marca.FormattingEnabled = True
        Me.Combo_marca.Location = New System.Drawing.Point(467, 34)
        Me.Combo_marca.MaxLength = 12
        Me.Combo_marca.Name = "Combo_marca"
        Me.Combo_marca.Size = New System.Drawing.Size(163, 24)
        Me.Combo_marca.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(124, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "VENDEDOR:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(294, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "PROVEEDOR:"
        '
        'Combo_vendedor
        '
        Me.Combo_vendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_vendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_vendedor.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_vendedor.FormattingEnabled = True
        Me.Combo_vendedor.Location = New System.Drawing.Point(127, 34)
        Me.Combo_vendedor.MaxLength = 12
        Me.Combo_vendedor.Name = "Combo_vendedor"
        Me.Combo_vendedor.Size = New System.Drawing.Size(164, 24)
        Me.Combo_vendedor.TabIndex = 2
        '
        'Combo_proveedor
        '
        Me.Combo_proveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_proveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_proveedor.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_proveedor.FormattingEnabled = True
        Me.Combo_proveedor.Location = New System.Drawing.Point(297, 34)
        Me.Combo_proveedor.MaxLength = 12
        Me.Combo_proveedor.Name = "Combo_proveedor"
        Me.Combo_proveedor.Size = New System.Drawing.Size(164, 24)
        Me.Combo_proveedor.TabIndex = 3
        '
        'dtp3
        '
        Me.dtp3.Checked = False
        Me.dtp3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp3.Location = New System.Drawing.Point(363, 87)
        Me.dtp3.Name = "dtp3"
        Me.dtp3.Size = New System.Drawing.Size(111, 24)
        Me.dtp3.TabIndex = 262
        Me.dtp3.TabStop = False
        '
        'grilla_ofertas
        '
        Me.grilla_ofertas.AllowUserToAddRows = False
        Me.grilla_ofertas.AllowUserToDeleteRows = False
        Me.grilla_ofertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_ofertas.Location = New System.Drawing.Point(412, 469)
        Me.grilla_ofertas.Name = "grilla_ofertas"
        Me.grilla_ofertas.ReadOnly = True
        Me.grilla_ofertas.Size = New System.Drawing.Size(600, 225)
        Me.grilla_ofertas.TabIndex = 299
        Me.grilla_ofertas.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(409, 451)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(196, 16)
        Me.Label6.TabIndex = 300
        Me.Label6.Text = "OFERTAS POR PRODUCTOS:"
        '
        'btn_editar_oferta
        '
        Me.btn_editar_oferta.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btn_editar_oferta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_editar_oferta.FlatAppearance.BorderSize = 0
        Me.btn_editar_oferta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_editar_oferta.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_editar_oferta.ForeColor = System.Drawing.Color.White
        Me.btn_editar_oferta.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_editar_oferta.Location = New System.Drawing.Point(786, 413)
        Me.btn_editar_oferta.Name = "btn_editar_oferta"
        Me.btn_editar_oferta.Size = New System.Drawing.Size(110, 50)
        Me.btn_editar_oferta.TabIndex = 301
        Me.btn_editar_oferta.TabStop = False
        Me.btn_editar_oferta.Text = "EDITAR OFERTA"
        Me.btn_editar_oferta.UseVisualStyleBackColor = False
        '
        'btn_encargar_pedido
        '
        Me.btn_encargar_pedido.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btn_encargar_pedido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_encargar_pedido.FlatAppearance.BorderSize = 0
        Me.btn_encargar_pedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_encargar_pedido.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_encargar_pedido.ForeColor = System.Drawing.Color.White
        Me.btn_encargar_pedido.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_encargar_pedido.Location = New System.Drawing.Point(902, 413)
        Me.btn_encargar_pedido.Name = "btn_encargar_pedido"
        Me.btn_encargar_pedido.Size = New System.Drawing.Size(110, 50)
        Me.btn_encargar_pedido.TabIndex = 303
        Me.btn_encargar_pedido.TabStop = False
        Me.btn_encargar_pedido.Text = "ENCARGAR PEDIDO"
        Me.btn_encargar_pedido.UseVisualStyleBackColor = False
        '
        'btn_aceptar_oferta
        '
        Me.btn_aceptar_oferta.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btn_aceptar_oferta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_aceptar_oferta.FlatAppearance.BorderSize = 0
        Me.btn_aceptar_oferta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_aceptar_oferta.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar_oferta.ForeColor = System.Drawing.Color.White
        Me.btn_aceptar_oferta.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_aceptar_oferta.Location = New System.Drawing.Point(670, 413)
        Me.btn_aceptar_oferta.Name = "btn_aceptar_oferta"
        Me.btn_aceptar_oferta.Size = New System.Drawing.Size(110, 50)
        Me.btn_aceptar_oferta.TabIndex = 304
        Me.btn_aceptar_oferta.TabStop = False
        Me.btn_aceptar_oferta.Text = "ACEPTAR OFERTA"
        Me.btn_aceptar_oferta.UseVisualStyleBackColor = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 269
        Me.PictureBox_logo.TabStop = False
        '
        'txt_copiar_y_pegar
        '
        Me.txt_copiar_y_pegar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_copiar_y_pegar.Location = New System.Drawing.Point(6, 469)
        Me.txt_copiar_y_pegar.MaxLength = 45
        Me.txt_copiar_y_pegar.Multiline = True
        Me.txt_copiar_y_pegar.Name = "txt_copiar_y_pegar"
        Me.txt_copiar_y_pegar.ReadOnly = True
        Me.txt_copiar_y_pegar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_copiar_y_pegar.Size = New System.Drawing.Size(400, 225)
        Me.txt_copiar_y_pegar.TabIndex = 306
        Me.txt_copiar_y_pegar.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(580, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 16)
        Me.Label8.TabIndex = 310
        Me.Label8.Text = "COTIZADO"
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.Color.BurlyWood
        Me.TextBox5.Enabled = False
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(563, 24)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(15, 15)
        Me.TextBox5.TabIndex = 309
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(827, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 16)
        Me.Label7.TabIndex = 312
        Me.Label7.Text = "EN ESPERA"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.Enabled = False
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(810, 24)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(15, 15)
        Me.TextBox2.TabIndex = 311
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(704, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 16)
        Me.Label13.TabIndex = 314
        Me.Label13.Text = "ACEPTADO"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.PaleGreen
        Me.TextBox3.Enabled = False
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(687, 24)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(15, 15)
        Me.TextBox3.TabIndex = 313
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(435, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 16)
        Me.Label12.TabIndex = 316
        Me.Label12.Text = "ENCARGADO"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(418, 24)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(15, 15)
        Me.TextBox1.TabIndex = 315
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(6, 413)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 50)
        Me.Button1.TabIndex = 317
        Me.Button1.TabStop = False
        Me.Button1.Text = "COPIAR Y PEGAR"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(131, 418)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 16)
        Me.Label4.TabIndex = 318
        Me.Label4.Text = "NOMBRE CLIENTE:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(118, 440)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(142, 16)
        Me.Label14.TabIndex = 319
        Me.Label14.Text = "TELEFONO CLIENTE:"
        '
        'lbl_telefono_cliente
        '
        Me.lbl_telefono_cliente.AutoSize = True
        Me.lbl_telefono_cliente.BackColor = System.Drawing.Color.Transparent
        Me.lbl_telefono_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_telefono_cliente.Location = New System.Drawing.Point(260, 440)
        Me.lbl_telefono_cliente.Name = "lbl_telefono_cliente"
        Me.lbl_telefono_cliente.Size = New System.Drawing.Size(142, 16)
        Me.lbl_telefono_cliente.TabIndex = 321
        Me.lbl_telefono_cliente.Text = "TELEFONO CLIENTE:"
        '
        'lbl_nombre_cliente
        '
        Me.lbl_nombre_cliente.AutoSize = True
        Me.lbl_nombre_cliente.BackColor = System.Drawing.Color.Transparent
        Me.lbl_nombre_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nombre_cliente.Location = New System.Drawing.Point(260, 418)
        Me.lbl_nombre_cliente.Name = "lbl_nombre_cliente"
        Me.lbl_nombre_cliente.Size = New System.Drawing.Size(129, 16)
        Me.lbl_nombre_cliente.TabIndex = 320
        Me.lbl_nombre_cliente.Text = "NOMBRE CLIENTE:"
        '
        'btn_eliminar
        '
        Me.btn_eliminar.BackColor = System.Drawing.Color.Transparent
        Me.btn_eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_eliminar.Image = CType(resources.GetObject("btn_eliminar.Image"), System.Drawing.Image)
        Me.btn_eliminar.Location = New System.Drawing.Point(977, 6)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(35, 35)
        Me.btn_eliminar.TabIndex = 322
        Me.btn_eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eliminar.UseVisualStyleBackColor = False
        '
        'Form_revision_cotizaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 700)
        Me.Controls.Add(Me.btn_eliminar)
        Me.Controls.Add(Me.lbl_telefono_cliente)
        Me.Controls.Add(Me.lbl_nombre_cliente)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.txt_copiar_y_pegar)
        Me.Controls.Add(Me.btn_aceptar_oferta)
        Me.Controls.Add(Me.btn_encargar_pedido)
        Me.Controls.Add(Me.btn_editar_oferta)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.grilla_ofertas)
        Me.Controls.Add(Me.grilla_revision_pedidos)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox_1)
        Me.Controls.Add(Me.dtp3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_revision_cotizaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REVISION DE COTIZACIONES"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grilla_revision_pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_1.ResumeLayout(False)
        Me.GroupBox_1.PerformLayout()
        CType(Me.grilla_ofertas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtp_desde As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtp_hasta As DateTimePicker
    Friend WithEvents lbl_mensaje As Label
    Friend WithEvents grilla_revision_pedidos As DataGridView
    Friend WithEvents PictureBox_logo As PictureBox
    Friend WithEvents txt_codigo_pedido As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents GroupBox_1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Combo_vendedor As ComboBox
    Friend WithEvents Combo_proveedor As ComboBox
    Friend WithEvents dtp3 As DateTimePicker
    Friend WithEvents grilla_ofertas As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents btn_editar_oferta As Button
    Friend WithEvents btn_encargar_pedido As Button
    Friend WithEvents btn_aceptar_oferta As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_copiar_y_pegar As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Combo_prioridad As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Combo_marca As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lbl_telefono_cliente As Label
    Friend WithEvents lbl_nombre_cliente As Label
    Friend WithEvents btn_eliminar As Button
End Class
