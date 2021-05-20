<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_estado_de_cuenta_por_letras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_estado_de_cuenta_por_letras))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lbl_mensaje = New System.Windows.Forms.Label()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txt_total_deuda = New System.Windows.Forms.TextBox()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn_mostrar = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_limpiar = New System.Windows.Forms.Button()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.txt_desglose = New System.Windows.Forms.TextBox()
        Me.grilla_clientes = New System.Windows.Forms.DataGridView()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_desde = New System.Windows.Forms.TextBox()
        Me.txt_hasta = New System.Windows.Forms.TextBox()
        Me.txt_total_saldo = New System.Windows.Forms.TextBox()
        Me.combo_tipo_impresion = New System.Windows.Forms.ComboBox()
        Me.dtp_fecha_faturacion = New System.Windows.Forms.DateTimePicker()
        Me.btn_quitar_elemento = New System.Windows.Forms.Button()
        Me.grilla_estado_de_cuenta = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Print_carta = New System.Drawing.Printing.PrintDocument()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Combo_impresora = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.grilla_clientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_estado_de_cuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(409, 1)
        Me.lbl_mensaje.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(945, 100)
        Me.lbl_mensaje.TabIndex = 244
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(8, 7)
        Me.PictureBox_logo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(400, 86)
        Me.PictureBox_logo.TabIndex = 243
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txt_total_deuda)
        Me.GroupBox5.Controls.Add(Me.txt_total)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(1081, 467)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox5.Size = New System.Drawing.Size(268, 87)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "DEUDA:"
        '
        'txt_total_deuda
        '
        Me.txt_total_deuda.BackColor = System.Drawing.SystemColors.Control
        Me.txt_total_deuda.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_deuda.Location = New System.Drawing.Point(61, 33)
        Me.txt_total_deuda.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_total_deuda.Name = "txt_total_deuda"
        Me.txt_total_deuda.ReadOnly = True
        Me.txt_total_deuda.Size = New System.Drawing.Size(147, 29)
        Me.txt_total_deuda.TabIndex = 3
        Me.txt_total_deuda.TabStop = False
        Me.txt_total_deuda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_total
        '
        Me.txt_total.Enabled = False
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.Location = New System.Drawing.Point(76, 33)
        Me.txt_total.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.Size = New System.Drawing.Size(65, 29)
        Me.txt_total.TabIndex = 2
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btn_quitar_elemento)
        Me.GroupBox4.Controls.Add(Me.btn_mostrar)
        Me.GroupBox4.Controls.Add(Me.btn_salir)
        Me.GroupBox4.Controls.Add(Me.btn_limpiar)
        Me.GroupBox4.Controls.Add(Me.btn_imprimir)
        Me.GroupBox4.Location = New System.Drawing.Point(1081, 555)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(268, 299)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        '
        'btn_mostrar
        '
        Me.btn_mostrar.BackColor = System.Drawing.Color.Transparent
        Me.btn_mostrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_mostrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_mostrar.Image = CType(resources.GetObject("btn_mostrar.Image"), System.Drawing.Image)
        Me.btn_mostrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_mostrar.Location = New System.Drawing.Point(71, 16)
        Me.btn_mostrar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_mostrar.Name = "btn_mostrar"
        Me.btn_mostrar.Size = New System.Drawing.Size(127, 49)
        Me.btn_mostrar.TabIndex = 1
        Me.btn_mostrar.Text = "MOSTRAR"
        Me.btn_mostrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_mostrar.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(71, 240)
        Me.btn_salir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(127, 49)
        Me.btn_salir.TabIndex = 5
        Me.btn_salir.Text = "SALIR"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_limpiar
        '
        Me.btn_limpiar.BackColor = System.Drawing.Color.Transparent
        Me.btn_limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_limpiar.Image = CType(resources.GetObject("btn_limpiar.Image"), System.Drawing.Image)
        Me.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_limpiar.Location = New System.Drawing.Point(71, 128)
        Me.btn_limpiar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(127, 49)
        Me.btn_limpiar.TabIndex = 3
        Me.btn_limpiar.Text = "LIMPIAR"
        Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_limpiar.UseVisualStyleBackColor = False
        '
        'btn_imprimir
        '
        Me.btn_imprimir.BackColor = System.Drawing.Color.Transparent
        Me.btn_imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.Image = CType(resources.GetObject("btn_imprimir.Image"), System.Drawing.Image)
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprimir.Location = New System.Drawing.Point(71, 72)
        Me.btn_imprimir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(127, 49)
        Me.btn_imprimir.TabIndex = 2
        Me.btn_imprimir.Text = "IMPRIMIR"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir.UseVisualStyleBackColor = False
        '
        'txt_desglose
        '
        Me.txt_desglose.Enabled = False
        Me.txt_desglose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desglose.Location = New System.Drawing.Point(253, 699)
        Me.txt_desglose.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_desglose.Multiline = True
        Me.txt_desglose.Name = "txt_desglose"
        Me.txt_desglose.Size = New System.Drawing.Size(624, 59)
        Me.txt_desglose.TabIndex = 240
        '
        'grilla_clientes
        '
        Me.grilla_clientes.AllowUserToAddRows = False
        Me.grilla_clientes.AllowUserToDeleteRows = False
        Me.grilla_clientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_clientes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grilla_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_clientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column12})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla_clientes.DefaultCellStyle = DataGridViewCellStyle2
        Me.grilla_clientes.Location = New System.Drawing.Point(9, 102)
        Me.grilla_clientes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grilla_clientes.Name = "grilla_clientes"
        Me.grilla_clientes.ReadOnly = True
        Me.grilla_clientes.Size = New System.Drawing.Size(1064, 388)
        Me.grilla_clientes.TabIndex = 249
        Me.grilla_clientes.TabStop = False
        '
        'Column5
        '
        Me.Column5.HeaderText = "RUT"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "CODIGO"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "NOMBRE"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "TELEFONO"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "COMUNA"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.HeaderText = "DIRECCION"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'txt_desde
        '
        Me.txt_desde.BackColor = System.Drawing.SystemColors.Window
        Me.txt_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desde.Location = New System.Drawing.Point(107, 25)
        Me.txt_desde.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_desde.MaxLength = 1
        Me.txt_desde.Name = "txt_desde"
        Me.txt_desde.Size = New System.Drawing.Size(132, 29)
        Me.txt_desde.TabIndex = 1
        '
        'txt_hasta
        '
        Me.txt_hasta.BackColor = System.Drawing.SystemColors.Window
        Me.txt_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_hasta.Location = New System.Drawing.Point(107, 63)
        Me.txt_hasta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_hasta.MaxLength = 1
        Me.txt_hasta.Name = "txt_hasta"
        Me.txt_hasta.Size = New System.Drawing.Size(132, 29)
        Me.txt_hasta.TabIndex = 2
        '
        'txt_total_saldo
        '
        Me.txt_total_saldo.Enabled = False
        Me.txt_total_saldo.Location = New System.Drawing.Point(939, 186)
        Me.txt_total_saldo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txt_total_saldo.Name = "txt_total_saldo"
        Me.txt_total_saldo.Size = New System.Drawing.Size(132, 22)
        Me.txt_total_saldo.TabIndex = 254
        Me.txt_total_saldo.Visible = False
        '
        'combo_tipo_impresion
        '
        Me.combo_tipo_impresion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_tipo_impresion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_tipo_impresion.FormattingEnabled = True
        Me.combo_tipo_impresion.Items.AddRange(New Object() {"TODOS", "FACTURACION"})
        Me.combo_tipo_impresion.Location = New System.Drawing.Point(20, 32)
        Me.combo_tipo_impresion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.combo_tipo_impresion.Name = "combo_tipo_impresion"
        Me.combo_tipo_impresion.Size = New System.Drawing.Size(229, 32)
        Me.combo_tipo_impresion.TabIndex = 1
        '
        'dtp_fecha_faturacion
        '
        Me.dtp_fecha_faturacion.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_faturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_faturacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha_faturacion.Location = New System.Drawing.Point(61, 33)
        Me.dtp_fecha_faturacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtp_fecha_faturacion.Name = "dtp_fecha_faturacion"
        Me.dtp_fecha_faturacion.Size = New System.Drawing.Size(147, 29)
        Me.dtp_fecha_faturacion.TabIndex = 257
        '
        'btn_quitar_elemento
        '
        Me.btn_quitar_elemento.BackColor = System.Drawing.Color.Transparent
        Me.btn_quitar_elemento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_quitar_elemento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_quitar_elemento.ForeColor = System.Drawing.Color.Black
        Me.btn_quitar_elemento.Image = CType(resources.GetObject("btn_quitar_elemento.Image"), System.Drawing.Image)
        Me.btn_quitar_elemento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_quitar_elemento.Location = New System.Drawing.Point(71, 184)
        Me.btn_quitar_elemento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_quitar_elemento.Name = "btn_quitar_elemento"
        Me.btn_quitar_elemento.Size = New System.Drawing.Size(127, 49)
        Me.btn_quitar_elemento.TabIndex = 4
        Me.btn_quitar_elemento.Text = "QUITAR"
        Me.btn_quitar_elemento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_quitar_elemento.UseVisualStyleBackColor = False
        '
        'grilla_estado_de_cuenta
        '
        Me.grilla_estado_de_cuenta.AllowUserToAddRows = False
        Me.grilla_estado_de_cuenta.AllowUserToDeleteRows = False
        Me.grilla_estado_de_cuenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_estado_de_cuenta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grilla_estado_de_cuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_estado_de_cuenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column14, Me.Column15, Me.Column4, Me.Column13, Me.Column6})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla_estado_de_cuenta.DefaultCellStyle = DataGridViewCellStyle4
        Me.grilla_estado_de_cuenta.Location = New System.Drawing.Point(8, 497)
        Me.grilla_estado_de_cuenta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grilla_estado_de_cuenta.Name = "grilla_estado_de_cuenta"
        Me.grilla_estado_de_cuenta.ReadOnly = True
        Me.grilla_estado_de_cuenta.Size = New System.Drawing.Size(1065, 357)
        Me.grilla_estado_de_cuenta.TabIndex = 263
        Me.grilla_estado_de_cuenta.TabStop = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "NRO."
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "TIPO"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "EMISION"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.HeaderText = "SUCURSAL"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column15
        '
        Me.Column15.HeaderText = "VENC."
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "TOTAL"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.HeaderText = "SALDO"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "S. FINAL"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.txt_hasta)
        Me.GroupBox6.Controls.Add(Me.txt_desde)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(1081, 94)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox6.Size = New System.Drawing.Size(268, 108)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "RANGO:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 67)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 20)
        Me.Label2.TabIndex = 273
        Me.Label2.Text = "HASTA:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 29)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 20)
        Me.Label3.TabIndex = 274
        Me.Label3.Text = "DESDE:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtp_fecha_faturacion)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(1081, 379)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(268, 87)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "EMISION:"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Combo_impresora)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(1081, 203)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(268, 87)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "IMPRESORA:"
        '
        'Print_carta
        '
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.combo_tipo_impresion)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(1081, 291)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(268, 87)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "EMISION:"
        '
        'Combo_impresora
        '
        Me.Combo_impresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_impresora.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_impresora.FormattingEnabled = True
        Me.Combo_impresora.Items.AddRange(New Object() {"TODOS", "FACTURACION"})
        Me.Combo_impresora.Location = New System.Drawing.Point(20, 32)
        Me.Combo_impresora.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_impresora.Name = "Combo_impresora"
        Me.Combo_impresora.Size = New System.Drawing.Size(229, 32)
        Me.Combo_impresora.TabIndex = 1
        '
        'Form_estado_de_cuenta_por_letras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1357, 862)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grilla_estado_de_cuenta)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.txt_desglose)
        Me.Controls.Add(Me.grilla_clientes)
        Me.Controls.Add(Me.txt_total_saldo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Form_estado_de_cuenta_por_letras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ESTADOS DE CUENTA POR RANGO"
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.grilla_clientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_estado_de_cuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents txt_desglose As System.Windows.Forms.TextBox
    Friend WithEvents grilla_clientes As System.Windows.Forms.DataGridView
    Friend WithEvents txt_desde As System.Windows.Forms.TextBox
    Friend WithEvents txt_hasta As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_saldo As System.Windows.Forms.TextBox
    Friend WithEvents combo_tipo_impresion As System.Windows.Forms.ComboBox
    Friend WithEvents dtp_fecha_faturacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_quitar_elemento As System.Windows.Forms.Button
    Friend WithEvents grilla_estado_de_cuenta As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_total_deuda As System.Windows.Forms.TextBox
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_mostrar As System.Windows.Forms.Button
    Friend WithEvents Print_carta As Printing.PrintDocument
    Friend WithEvents Combo_impresora As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
End Class
