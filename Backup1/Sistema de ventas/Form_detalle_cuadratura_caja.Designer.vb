<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_detalle_cuadratura_caja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_detalle_cuadratura_caja))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox_detalle_remuneracion = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtp_fecha_caja_desde = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.combo_tipo = New System.Windows.Forms.ComboBox
        Me.txt_monto = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.btn_agregar_entrada_remuneracion = New System.Windows.Forms.Button
        Me.btn_quitar_entrada_remuneracion = New System.Windows.Forms.Button
        Me.grilla_detalle_cuadratura = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_cod_auto = New System.Windows.Forms.TextBox
        Me.btn_mostrar = New System.Windows.Forms.Button
        Me.grilla_revision = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dtp_desde = New System.Windows.Forms.DateTimePicker
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dtp_hasta = New System.Windows.Forms.DateTimePicker
        Me.Combo_detalle = New System.Windows.Forms.ComboBox
        Me.txt_rut_usuario = New System.Windows.Forms.TextBox
        Me.txt_nro_anticipo = New System.Windows.Forms.TextBox
        Me.lbl_mensaje = New System.Windows.Forms.Label
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_detalle_remuneracion.SuspendLayout()
        CType(Me.grilla_detalle_cuadratura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_revision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.PictureBox_logo.TabIndex = 150
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox_detalle_remuneracion
        '
        Me.GroupBox_detalle_remuneracion.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_detalle_remuneracion.Controls.Add(Me.Label2)
        Me.GroupBox_detalle_remuneracion.Controls.Add(Me.dtp_fecha_caja_desde)
        Me.GroupBox_detalle_remuneracion.Controls.Add(Me.Label1)
        Me.GroupBox_detalle_remuneracion.Controls.Add(Me.combo_tipo)
        Me.GroupBox_detalle_remuneracion.Controls.Add(Me.txt_monto)
        Me.GroupBox_detalle_remuneracion.Controls.Add(Me.Label19)
        Me.GroupBox_detalle_remuneracion.Controls.Add(Me.Label26)
        Me.GroupBox_detalle_remuneracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_detalle_remuneracion.Location = New System.Drawing.Point(7, 77)
        Me.GroupBox_detalle_remuneracion.Name = "GroupBox_detalle_remuneracion"
        Me.GroupBox_detalle_remuneracion.Size = New System.Drawing.Size(1005, 65)
        Me.GroupBox_detalle_remuneracion.TabIndex = 1
        Me.GroupBox_detalle_remuneracion.TabStop = False
        Me.GroupBox_detalle_remuneracion.Text = "INGRESO:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(884, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 154
        Me.Label2.Text = "FECHA:"
        '
        'dtp_fecha_caja_desde
        '
        Me.dtp_fecha_caja_desde.Checked = False
        Me.dtp_fecha_caja_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_caja_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_caja_desde.Location = New System.Drawing.Point(887, 33)
        Me.dtp_fecha_caja_desde.Name = "dtp_fecha_caja_desde"
        Me.dtp_fecha_caja_desde.Size = New System.Drawing.Size(111, 24)
        Me.dtp_fecha_caja_desde.TabIndex = 151
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 16)
        Me.Label1.TabIndex = 153
        Me.Label1.Text = "TIPO:"
        '
        'combo_tipo
        '
        Me.combo_tipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_tipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_tipo.BackColor = System.Drawing.SystemColors.Window
        Me.combo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_tipo.ForeColor = System.Drawing.Color.Black
        Me.combo_tipo.FormattingEnabled = True
        Me.combo_tipo.Items.AddRange(New Object() {"-", "OTROS INGRESOS", "ANTICIPOS", "EGRESOS CON BOLETA Y OTROS", "EGRESOS CON FACTURA", "OTROS EGRESOS CON FACTURA", "VENTAS PENDIENTES", "RETIRO"})
        Me.combo_tipo.Location = New System.Drawing.Point(7, 33)
        Me.combo_tipo.Name = "combo_tipo"
        Me.combo_tipo.Size = New System.Drawing.Size(275, 24)
        Me.combo_tipo.TabIndex = 1
        '
        'txt_monto
        '
        Me.txt_monto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_monto.Location = New System.Drawing.Point(771, 33)
        Me.txt_monto.MaxLength = 11
        Me.txt_monto.Name = "txt_monto"
        Me.txt_monto.Size = New System.Drawing.Size(110, 24)
        Me.txt_monto.TabIndex = 3
        Me.txt_monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(768, 15)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(61, 16)
        Me.Label19.TabIndex = 33
        Me.Label19.Text = "MONTO:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(285, 15)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(71, 16)
        Me.Label26.TabIndex = 31
        Me.Label26.Text = "DETALLE:"
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_guardar.Location = New System.Drawing.Point(343, 98)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(100, 25)
        Me.btn_guardar.TabIndex = 147
        Me.btn_guardar.TabStop = False
        Me.btn_guardar.Text = "GRABAR"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'btn_agregar_entrada_remuneracion
        '
        Me.btn_agregar_entrada_remuneracion.BackColor = System.Drawing.Color.Transparent
        Me.btn_agregar_entrada_remuneracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar_entrada_remuneracion.Image = CType(resources.GetObject("btn_agregar_entrada_remuneracion.Image"), System.Drawing.Image)
        Me.btn_agregar_entrada_remuneracion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_agregar_entrada_remuneracion.Location = New System.Drawing.Point(802, 147)
        Me.btn_agregar_entrada_remuneracion.Name = "btn_agregar_entrada_remuneracion"
        Me.btn_agregar_entrada_remuneracion.Size = New System.Drawing.Size(95, 40)
        Me.btn_agregar_entrada_remuneracion.TabIndex = 5
        Me.btn_agregar_entrada_remuneracion.Text = "AGREGAR"
        Me.btn_agregar_entrada_remuneracion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_agregar_entrada_remuneracion.UseVisualStyleBackColor = False
        '
        'btn_quitar_entrada_remuneracion
        '
        Me.btn_quitar_entrada_remuneracion.BackColor = System.Drawing.Color.Transparent
        Me.btn_quitar_entrada_remuneracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_quitar_entrada_remuneracion.Image = CType(resources.GetObject("btn_quitar_entrada_remuneracion.Image"), System.Drawing.Image)
        Me.btn_quitar_entrada_remuneracion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_quitar_entrada_remuneracion.Location = New System.Drawing.Point(902, 147)
        Me.btn_quitar_entrada_remuneracion.Name = "btn_quitar_entrada_remuneracion"
        Me.btn_quitar_entrada_remuneracion.Size = New System.Drawing.Size(95, 40)
        Me.btn_quitar_entrada_remuneracion.TabIndex = 6
        Me.btn_quitar_entrada_remuneracion.Text = "QUITAR"
        Me.btn_quitar_entrada_remuneracion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_quitar_entrada_remuneracion.UseVisualStyleBackColor = False
        '
        'grilla_detalle_cuadratura
        '
        Me.grilla_detalle_cuadratura.AllowUserToAddRows = False
        Me.grilla_detalle_cuadratura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_detalle_cuadratura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column4, Me.Column3, Me.Column2, Me.Column5, Me.Column6})
        Me.grilla_detalle_cuadratura.Location = New System.Drawing.Point(6, 193)
        Me.grilla_detalle_cuadratura.Name = "grilla_detalle_cuadratura"
        Me.grilla_detalle_cuadratura.ReadOnly = True
        Me.grilla_detalle_cuadratura.Size = New System.Drawing.Size(1006, 274)
        Me.grilla_detalle_cuadratura.TabIndex = 16
        Me.grilla_detalle_cuadratura.TabStop = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "DETALLE"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 241
        '
        'Column4
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column4.HeaderText = "MONTO"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 241
        '
        'Column3
        '
        Me.Column3.HeaderText = "TIPO"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 240
        '
        'Column2
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column2.HeaderText = "FECHA"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 241
        '
        'Column5
        '
        Me.Column5.HeaderText = "REVISION"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'Column6
        '
        Me.Column6.HeaderText = "COD AUTO"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'txt_cod_auto
        '
        Me.txt_cod_auto.Enabled = False
        Me.txt_cod_auto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_auto.Location = New System.Drawing.Point(622, 202)
        Me.txt_cod_auto.MaxLength = 11
        Me.txt_cod_auto.Name = "txt_cod_auto"
        Me.txt_cod_auto.Size = New System.Drawing.Size(110, 24)
        Me.txt_cod_auto.TabIndex = 154
        Me.txt_cod_auto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_mostrar
        '
        Me.btn_mostrar.BackColor = System.Drawing.Color.Transparent
        Me.btn_mostrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_mostrar.Image = CType(resources.GetObject("btn_mostrar.Image"), System.Drawing.Image)
        Me.btn_mostrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_mostrar.Location = New System.Drawing.Point(701, 147)
        Me.btn_mostrar.Name = "btn_mostrar"
        Me.btn_mostrar.Size = New System.Drawing.Size(95, 40)
        Me.btn_mostrar.TabIndex = 4
        Me.btn_mostrar.Text = "MOSTRAR"
        Me.btn_mostrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_mostrar.UseVisualStyleBackColor = False
        '
        'grilla_revision
        '
        Me.grilla_revision.AllowUserToAddRows = False
        Me.grilla_revision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_revision.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn6})
        Me.grilla_revision.Location = New System.Drawing.Point(29, 482)
        Me.grilla_revision.Name = "grilla_revision"
        Me.grilla_revision.ReadOnly = True
        Me.grilla_revision.Size = New System.Drawing.Size(807, 228)
        Me.grilla_revision.TabIndex = 155
        Me.grilla_revision.TabStop = False
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn2.HeaderText = "MONTO"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 241
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "TIPO"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 240
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "COD AUTO"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dtp_desde)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(412, 241)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(195, 65)
        Me.GroupBox2.TabIndex = 156
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DESDE:"
        '
        'dtp_desde
        '
        Me.dtp_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_desde.Location = New System.Drawing.Point(42, 24)
        Me.dtp_desde.Name = "dtp_desde"
        Me.dtp_desde.Size = New System.Drawing.Size(111, 24)
        Me.dtp_desde.TabIndex = 0
        Me.dtp_desde.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.dtp_hasta)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(412, 305)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(195, 65)
        Me.GroupBox3.TabIndex = 157
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "HASTA:"
        '
        'dtp_hasta
        '
        Me.dtp_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_hasta.Location = New System.Drawing.Point(42, 24)
        Me.dtp_hasta.Name = "dtp_hasta"
        Me.dtp_hasta.Size = New System.Drawing.Size(111, 24)
        Me.dtp_hasta.TabIndex = 0
        Me.dtp_hasta.TabStop = False
        '
        'Combo_detalle
        '
        Me.Combo_detalle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_detalle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_detalle.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_detalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.Combo_detalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_detalle.ForeColor = System.Drawing.Color.Black
        Me.Combo_detalle.FormattingEnabled = True
        Me.Combo_detalle.Items.AddRange(New Object() {"-", "OTROS INGRESOS", "ANTICIPOS", "EGRESOS CON BOLETA Y OTROS", "EGRESOS CON FACTURA", "OTROS EGRESOS CON FACTURA", "VENTAS PENDIENTES", "RETIRO"})
        Me.Combo_detalle.Location = New System.Drawing.Point(295, 110)
        Me.Combo_detalle.Name = "Combo_detalle"
        Me.Combo_detalle.Size = New System.Drawing.Size(477, 24)
        Me.Combo_detalle.TabIndex = 2
        '
        'txt_rut_usuario
        '
        Me.txt_rut_usuario.BackColor = System.Drawing.SystemColors.Control
        Me.txt_rut_usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut_usuario.ForeColor = System.Drawing.Color.Black
        Me.txt_rut_usuario.HideSelection = False
        Me.txt_rut_usuario.Location = New System.Drawing.Point(459, 234)
        Me.txt_rut_usuario.Name = "txt_rut_usuario"
        Me.txt_rut_usuario.ReadOnly = True
        Me.txt_rut_usuario.Size = New System.Drawing.Size(101, 24)
        Me.txt_rut_usuario.TabIndex = 243
        Me.txt_rut_usuario.TabStop = False
        '
        'txt_nro_anticipo
        '
        Me.txt_nro_anticipo.Enabled = False
        Me.txt_nro_anticipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_anticipo.Location = New System.Drawing.Point(382, 198)
        Me.txt_nro_anticipo.MaxLength = 11
        Me.txt_nro_anticipo.Name = "txt_nro_anticipo"
        Me.txt_nro_anticipo.ReadOnly = True
        Me.txt_nro_anticipo.Size = New System.Drawing.Size(110, 24)
        Me.txt_nro_anticipo.TabIndex = 155
        Me.txt_nro_anticipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(307, 2)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(712, 81)
        Me.lbl_mensaje.TabIndex = 338
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'Form_detalle_cuadratura_caja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 473)
        Me.Controls.Add(Me.grilla_detalle_cuadratura)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.txt_nro_anticipo)
        Me.Controls.Add(Me.Combo_detalle)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.grilla_revision)
        Me.Controls.Add(Me.btn_mostrar)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox_detalle_remuneracion)
        Me.Controls.Add(Me.btn_quitar_entrada_remuneracion)
        Me.Controls.Add(Me.btn_agregar_entrada_remuneracion)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.txt_cod_auto)
        Me.Controls.Add(Me.txt_rut_usuario)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_detalle_cuadratura_caja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DETALLE CUADRATURA CAJA"
        Me.TopMost = True
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_detalle_remuneracion.ResumeLayout(False)
        Me.GroupBox_detalle_remuneracion.PerformLayout()
        CType(Me.grilla_detalle_cuadratura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_revision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox_detalle_remuneracion As System.Windows.Forms.GroupBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents txt_monto As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents btn_agregar_entrada_remuneracion As System.Windows.Forms.Button
    Friend WithEvents btn_quitar_entrada_remuneracion As System.Windows.Forms.Button
    Friend WithEvents grilla_detalle_cuadratura As System.Windows.Forms.DataGridView
    Friend WithEvents combo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_caja_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_cod_auto As System.Windows.Forms.TextBox
    Friend WithEvents btn_mostrar As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grilla_revision As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Combo_detalle As System.Windows.Forms.ComboBox
    Friend WithEvents txt_rut_usuario As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_nro_anticipo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
End Class
