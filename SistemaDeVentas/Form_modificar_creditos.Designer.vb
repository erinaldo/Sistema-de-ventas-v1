<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_modificar_creditos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_modificar_creditos))
        Me.lbl_mensaje = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txt_vencimiento = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_saldo_millar = New System.Windows.Forms.TextBox
        Me.txt_deuda_actual = New System.Windows.Forms.TextBox
        Me.GroupBox_monto = New System.Windows.Forms.GroupBox
        Me.txt_abono = New System.Windows.Forms.TextBox
        Me.GroupBox_documento = New System.Windows.Forms.GroupBox
        Me.Combo_cuotas = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.GroupBox_nombre = New System.Windows.Forms.GroupBox
        Me.txt_rut = New System.Windows.Forms.ComboBox
        Me.txt_nombre_cliente = New System.Windows.Forms.TextBox
        Me.txt_direccion = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_codigo_cliente = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_invicible = New System.Windows.Forms.TextBox
        Me.txt_fecha = New System.Windows.Forms.TextBox
        Me.dtp_emision = New System.Windows.Forms.DateTimePicker
        Me.txt_n_abono = New System.Windows.Forms.TextBox
        Me.txt_cod_auto = New System.Windows.Forms.TextBox
        Me.combo_factura = New System.Windows.Forms.ComboBox
        Me.Combo_tipo = New System.Windows.Forms.ComboBox
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.btn_cargar = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_modificar_abono = New System.Windows.Forms.Button
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox_monto.SuspendLayout()
        Me.GroupBox_documento.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox_nombre.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(307, 2)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(565, 81)
        Me.lbl_mensaje.TabIndex = 370
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.txt_vencimiento)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(266, 142)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(124, 67)
        Me.GroupBox3.TabIndex = 355
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "VENCIMIENTO:"
        '
        'txt_vencimiento
        '
        Me.txt_vencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vencimiento.Location = New System.Drawing.Point(7, 25)
        Me.txt_vencimiento.Name = "txt_vencimiento"
        Me.txt_vencimiento.ReadOnly = True
        Me.txt_vencimiento.Size = New System.Drawing.Size(110, 24)
        Me.txt_vencimiento.TabIndex = 49
        Me.txt_vencimiento.TabStop = False
        Me.txt_vencimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txt_saldo_millar)
        Me.GroupBox2.Controls.Add(Me.txt_deuda_actual)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(396, 142)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(124, 67)
        Me.GroupBox2.TabIndex = 354
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "SALDO:"
        '
        'txt_saldo_millar
        '
        Me.txt_saldo_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_saldo_millar.Location = New System.Drawing.Point(7, 25)
        Me.txt_saldo_millar.Name = "txt_saldo_millar"
        Me.txt_saldo_millar.ReadOnly = True
        Me.txt_saldo_millar.ShortcutsEnabled = False
        Me.txt_saldo_millar.Size = New System.Drawing.Size(110, 24)
        Me.txt_saldo_millar.TabIndex = 17
        Me.txt_saldo_millar.TabStop = False
        Me.txt_saldo_millar.Text = "0"
        Me.txt_saldo_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_deuda_actual
        '
        Me.txt_deuda_actual.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_deuda_actual.Location = New System.Drawing.Point(7, 25)
        Me.txt_deuda_actual.Name = "txt_deuda_actual"
        Me.txt_deuda_actual.ReadOnly = True
        Me.txt_deuda_actual.Size = New System.Drawing.Size(86, 24)
        Me.txt_deuda_actual.TabIndex = 15
        Me.txt_deuda_actual.TabStop = False
        Me.txt_deuda_actual.Text = "0"
        Me.txt_deuda_actual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox_monto
        '
        Me.GroupBox_monto.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_monto.Controls.Add(Me.txt_abono)
        Me.GroupBox_monto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_monto.Location = New System.Drawing.Point(526, 142)
        Me.GroupBox_monto.Name = "GroupBox_monto"
        Me.GroupBox_monto.Size = New System.Drawing.Size(124, 67)
        Me.GroupBox_monto.TabIndex = 342
        Me.GroupBox_monto.TabStop = False
        Me.GroupBox_monto.Text = "ABONO:"
        '
        'txt_abono
        '
        Me.txt_abono.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_abono.Location = New System.Drawing.Point(7, 26)
        Me.txt_abono.MaxLength = 9
        Me.txt_abono.Name = "txt_abono"
        Me.txt_abono.Size = New System.Drawing.Size(110, 24)
        Me.txt_abono.TabIndex = 15
        Me.txt_abono.Text = "0"
        Me.txt_abono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox_documento
        '
        Me.GroupBox_documento.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_documento.Controls.Add(Me.Combo_cuotas)
        Me.GroupBox_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_documento.Location = New System.Drawing.Point(6, 142)
        Me.GroupBox_documento.Name = "GroupBox_documento"
        Me.GroupBox_documento.Size = New System.Drawing.Size(254, 67)
        Me.GroupBox_documento.TabIndex = 339
        Me.GroupBox_documento.TabStop = False
        Me.GroupBox_documento.Text = "DOCUMENTO:"
        '
        'Combo_cuotas
        '
        Me.Combo_cuotas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_cuotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_cuotas.FormattingEnabled = True
        Me.Combo_cuotas.Location = New System.Drawing.Point(7, 24)
        Me.Combo_cuotas.Name = "Combo_cuotas"
        Me.Combo_cuotas.Size = New System.Drawing.Size(240, 24)
        Me.Combo_cuotas.TabIndex = 310
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btn_guardar)
        Me.GroupBox1.Controls.Add(Me.btn_nuevo)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(656, 142)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(209, 67)
        Me.GroupBox1.TabIndex = 352
        Me.GroupBox1.TabStop = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.Location = New System.Drawing.Point(107, 15)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(95, 40)
        Me.btn_guardar.TabIndex = 13
        Me.btn_guardar.Text = "GUARDAR"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.Image = CType(resources.GetObject("btn_nuevo.Image"), System.Drawing.Image)
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo.Location = New System.Drawing.Point(7, 15)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(95, 40)
        Me.btn_nuevo.TabIndex = 111
        Me.btn_nuevo.Text = "NUEVO"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'GroupBox_nombre
        '
        Me.GroupBox_nombre.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_nombre.Controls.Add(Me.txt_rut)
        Me.GroupBox_nombre.Controls.Add(Me.txt_nombre_cliente)
        Me.GroupBox_nombre.Controls.Add(Me.txt_direccion)
        Me.GroupBox_nombre.Controls.Add(Me.Label7)
        Me.GroupBox_nombre.Controls.Add(Me.Label8)
        Me.GroupBox_nombre.Controls.Add(Me.txt_codigo_cliente)
        Me.GroupBox_nombre.Controls.Add(Me.Label9)
        Me.GroupBox_nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_nombre.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox_nombre.Name = "GroupBox_nombre"
        Me.GroupBox_nombre.Size = New System.Drawing.Size(859, 65)
        Me.GroupBox_nombre.TabIndex = 338
        Me.GroupBox_nombre.TabStop = False
        Me.GroupBox_nombre.Text = "DATOS DEL CLIENTE"
        '
        'txt_rut
        '
        Me.txt_rut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txt_rut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut.FormattingEnabled = True
        Me.txt_rut.Location = New System.Drawing.Point(7, 33)
        Me.txt_rut.Name = "txt_rut"
        Me.txt_rut.Size = New System.Drawing.Size(122, 24)
        Me.txt_rut.TabIndex = 311
        '
        'txt_nombre_cliente
        '
        Me.txt_nombre_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_cliente.Location = New System.Drawing.Point(135, 33)
        Me.txt_nombre_cliente.Name = "txt_nombre_cliente"
        Me.txt_nombre_cliente.ReadOnly = True
        Me.txt_nombre_cliente.Size = New System.Drawing.Size(354, 24)
        Me.txt_nombre_cliente.TabIndex = 2
        Me.txt_nombre_cliente.TabStop = False
        '
        'txt_direccion
        '
        Me.txt_direccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_direccion.Location = New System.Drawing.Point(495, 33)
        Me.txt_direccion.Name = "txt_direccion"
        Me.txt_direccion.ReadOnly = True
        Me.txt_direccion.Size = New System.Drawing.Size(357, 24)
        Me.txt_direccion.TabIndex = 2
        Me.txt_direccion.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(492, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "DIRECCION:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(132, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "NOMBRE:"
        '
        'txt_codigo_cliente
        '
        Me.txt_codigo_cliente.Enabled = False
        Me.txt_codigo_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_cliente.Location = New System.Drawing.Point(135, 33)
        Me.txt_codigo_cliente.Name = "txt_codigo_cliente"
        Me.txt_codigo_cliente.Size = New System.Drawing.Size(70, 24)
        Me.txt_codigo_cliente.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 16)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "RUT:"
        '
        'txt_invicible
        '
        Me.txt_invicible.Enabled = False
        Me.txt_invicible.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_invicible.Location = New System.Drawing.Point(604, 96)
        Me.txt_invicible.Name = "txt_invicible"
        Me.txt_invicible.Size = New System.Drawing.Size(50, 21)
        Me.txt_invicible.TabIndex = 361
        Me.txt_invicible.TabStop = False
        Me.txt_invicible.Visible = False
        '
        'txt_fecha
        '
        Me.txt_fecha.Enabled = False
        Me.txt_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_fecha.Location = New System.Drawing.Point(584, 96)
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.Size = New System.Drawing.Size(50, 21)
        Me.txt_fecha.TabIndex = 363
        Me.txt_fecha.TabStop = False
        Me.txt_fecha.Visible = False
        '
        'dtp_emision
        '
        Me.dtp_emision.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_emision.Enabled = False
        Me.dtp_emision.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_emision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_emision.Location = New System.Drawing.Point(429, 102)
        Me.dtp_emision.Name = "dtp_emision"
        Me.dtp_emision.Size = New System.Drawing.Size(111, 24)
        Me.dtp_emision.TabIndex = 344
        Me.dtp_emision.TabStop = False
        '
        'txt_n_abono
        '
        Me.txt_n_abono.Enabled = False
        Me.txt_n_abono.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_n_abono.Location = New System.Drawing.Point(313, 102)
        Me.txt_n_abono.MaxLength = 11
        Me.txt_n_abono.Name = "txt_n_abono"
        Me.txt_n_abono.Size = New System.Drawing.Size(110, 24)
        Me.txt_n_abono.TabIndex = 353
        Me.txt_n_abono.TabStop = False
        Me.txt_n_abono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_cod_auto
        '
        Me.txt_cod_auto.BackColor = System.Drawing.SystemColors.Control
        Me.txt_cod_auto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_auto.ForeColor = System.Drawing.Color.Black
        Me.txt_cod_auto.Location = New System.Drawing.Point(195, 272)
        Me.txt_cod_auto.Name = "txt_cod_auto"
        Me.txt_cod_auto.ReadOnly = True
        Me.txt_cod_auto.Size = New System.Drawing.Size(153, 24)
        Me.txt_cod_auto.TabIndex = 369
        Me.txt_cod_auto.TabStop = False
        Me.txt_cod_auto.Text = "0"
        Me.txt_cod_auto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'combo_factura
        '
        Me.combo_factura.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_factura.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_factura.FormattingEnabled = True
        Me.combo_factura.Location = New System.Drawing.Point(501, 272)
        Me.combo_factura.Name = "combo_factura"
        Me.combo_factura.Size = New System.Drawing.Size(153, 24)
        Me.combo_factura.TabIndex = 343
        Me.combo_factura.TabStop = False
        '
        'Combo_tipo
        '
        Me.Combo_tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_tipo.FormattingEnabled = True
        Me.Combo_tipo.Location = New System.Drawing.Point(348, 272)
        Me.Combo_tipo.Name = "Combo_tipo"
        Me.Combo_tipo.Size = New System.Drawing.Size(153, 24)
        Me.Combo_tipo.TabIndex = 340
        Me.Combo_tipo.TabStop = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 364
        Me.PictureBox_logo.TabStop = False
        '
        'btn_cargar
        '
        Me.btn_cargar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_cargar.Enabled = False
        Me.btn_cargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cargar.Image = CType(resources.GetObject("btn_cargar.Image"), System.Drawing.Image)
        Me.btn_cargar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cargar.Location = New System.Drawing.Point(451, 88)
        Me.btn_cargar.Name = "btn_cargar"
        Me.btn_cargar.Size = New System.Drawing.Size(95, 40)
        Me.btn_cargar.TabIndex = 341
        Me.btn_cargar.Text = "CARGAR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_cargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cargar.UseVisualStyleBackColor = True
        Me.btn_cargar.Visible = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.Enabled = False
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(551, 88)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
        Me.btn_salir.TabIndex = 348
        Me.btn_salir.Text = "SALIR"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = True
        Me.btn_salir.Visible = False
        '
        'btn_modificar_abono
        '
        Me.btn_modificar_abono.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_modificar_abono.Enabled = False
        Me.btn_modificar_abono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_modificar_abono.Image = CType(resources.GetObject("btn_modificar_abono.Image"), System.Drawing.Image)
        Me.btn_modificar_abono.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_modificar_abono.Location = New System.Drawing.Point(351, 88)
        Me.btn_modificar_abono.Name = "btn_modificar_abono"
        Me.btn_modificar_abono.Size = New System.Drawing.Size(95, 40)
        Me.btn_modificar_abono.TabIndex = 347
        Me.btn_modificar_abono.TabStop = False
        Me.btn_modificar_abono.Text = "MODIFIC."
        Me.btn_modificar_abono.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_modificar_abono.UseVisualStyleBackColor = True
        Me.btn_modificar_abono.Visible = False
        '
        'Form_modificar_creditos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(871, 215)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox_monto)
        Me.Controls.Add(Me.GroupBox_documento)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox_nombre)
        Me.Controls.Add(Me.txt_invicible)
        Me.Controls.Add(Me.txt_fecha)
        Me.Controls.Add(Me.dtp_emision)
        Me.Controls.Add(Me.txt_n_abono)
        Me.Controls.Add(Me.btn_cargar)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.btn_modificar_abono)
        Me.Controls.Add(Me.txt_cod_auto)
        Me.Controls.Add(Me.combo_factura)
        Me.Controls.Add(Me.Combo_tipo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_modificar_creditos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MODIFICAR CREDITOS"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox_monto.ResumeLayout(False)
        Me.GroupBox_monto.PerformLayout()
        Me.GroupBox_documento.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox_nombre.ResumeLayout(False)
        Me.GroupBox_nombre.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_vencimiento As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_saldo_millar As System.Windows.Forms.TextBox
    Friend WithEvents txt_deuda_actual As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox_monto As System.Windows.Forms.GroupBox
    Friend WithEvents txt_abono As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox_documento As System.Windows.Forms.GroupBox
    Friend WithEvents Combo_cuotas As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox_nombre As System.Windows.Forms.GroupBox
    Friend WithEvents txt_nombre_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_direccion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_invicible As System.Windows.Forms.TextBox
    Friend WithEvents txt_fecha As System.Windows.Forms.TextBox
    Friend WithEvents dtp_emision As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_n_abono As System.Windows.Forms.TextBox
    Friend WithEvents btn_cargar As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_modificar_abono As System.Windows.Forms.Button
    Friend WithEvents txt_cod_auto As System.Windows.Forms.TextBox
    Friend WithEvents combo_factura As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents txt_rut As System.Windows.Forms.ComboBox
End Class
