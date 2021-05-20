<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_libro_de_compras
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_libro_de_compras))
        Me.grilla_libro_compras = New System.Windows.Forms.DataGridView
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_rut_proveedor = New System.Windows.Forms.TextBox
        Me.txt_nombre_proveedor = New System.Windows.Forms.TextBox
        Me.lbl_ingreso = New System.Windows.Forms.Label
        Me.lbl_rut = New System.Windows.Forms.Label
        Me.txt_credito_proveedor = New System.Windows.Forms.TextBox
        Me.btn_agregar = New System.Windows.Forms.Button
        Me.btn_quitar_elemento = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Combo_clasificacion_cuenta = New System.Windows.Forms.ComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dtp_emision = New System.Windows.Forms.DateTimePicker
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txt_total = New System.Windows.Forms.TextBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.txt_neto = New System.Windows.Forms.TextBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.txt_iva = New System.Windows.Forms.TextBox
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.txt_numero_factura = New System.Windows.Forms.TextBox
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.Combo_tipo_factura = New System.Windows.Forms.ComboBox
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.txt_exentas_total_millar = New System.Windows.Forms.TextBox
        Me.txt_total_general_millar = New System.Windows.Forms.TextBox
        Me.txt_iva_total_millar = New System.Windows.Forms.TextBox
        Me.txt_neto_total_millar = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txt_exentas_total = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txt_total_general = New System.Windows.Forms.TextBox
        Me.txt_iva_total = New System.Windows.Forms.TextBox
        Me.txt_neto_total = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txt_impuesto_especifico = New System.Windows.Forms.TextBox
        Me.GroupBox11 = New System.Windows.Forms.GroupBox
        Me.Combo_tipo_documento = New System.Windows.Forms.ComboBox
        Me.btn_cargar = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_limpiar = New System.Windows.Forms.Button
        Me.GroupBox13 = New System.Windows.Forms.GroupBox
        Me.dtp_tributario = New System.Windows.Forms.DateTimePicker
        Me.GroupBox14 = New System.Windows.Forms.GroupBox
        Me.btn_nueva = New System.Windows.Forms.Button
        Me.txt_tipo_documento = New System.Windows.Forms.TextBox
        Me.txt_documento = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.txt_folio = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtp3 = New System.Windows.Forms.DateTimePicker
        Me.dtp_vencimiento = New System.Windows.Forms.DateTimePicker
        Me.dtp_fecha_de_ingreso = New System.Windows.Forms.DateTimePicker
        Me.Timer_inactividad_libro_compra = New System.Windows.Forms.Timer(Me.components)
        Me.Check_limpiar = New System.Windows.Forms.CheckBox
        CType(Me.grilla_libro_compras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.SuspendLayout()
        '
        'grilla_libro_compras
        '
        Me.grilla_libro_compras.AllowUserToAddRows = False
        Me.grilla_libro_compras.AllowUserToDeleteRows = False
        Me.grilla_libro_compras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.grilla_libro_compras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_libro_compras.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column10, Me.Column13, Me.Column11, Me.Column12, Me.Column1, Me.Column2, Me.Column9, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column14})
        Me.grilla_libro_compras.Location = New System.Drawing.Point(6, 278)
        Me.grilla_libro_compras.Name = "grilla_libro_compras"
        Me.grilla_libro_compras.ReadOnly = True
        Me.grilla_libro_compras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grilla_libro_compras.Size = New System.Drawing.Size(1006, 416)
        Me.grilla_libro_compras.TabIndex = 0
        Me.grilla_libro_compras.TabStop = False
        '
        'Column10
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column10.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column10.HeaderText = "FOLIO"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 63
        '
        'Column13
        '
        Me.Column13.HeaderText = "PERIODO"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Width = 81
        '
        'Column11
        '
        Me.Column11.HeaderText = "DOCUMENTO"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 102
        '
        'Column12
        '
        Me.Column12.HeaderText = "TIPO"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 57
        '
        'Column1
        '
        Me.Column1.HeaderText = "EMISION"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 77
        '
        'Column2
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column2.HeaderText = "NRO."
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 59
        '
        'Column9
        '
        Me.Column9.HeaderText = "CUENTA"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 76
        '
        'Column3
        '
        Me.Column3.HeaderText = "PROVEEDOR"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "RUT"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 55
        '
        'Column5
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column5.HeaderText = "EXENTAS"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 82
        '
        'Column6
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column6.HeaderText = "NETO"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 62
        '
        'Column7
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column7.HeaderText = "IVA"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 49
        '
        'Column8
        '
        Me.Column8.HeaderText = "TOTAL"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 67
        '
        'Column14
        '
        Me.Column14.HeaderText = "VENCIMIENTO"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        Me.Column14.Visible = False
        Me.Column14.Width = 106
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txt_rut_proveedor)
        Me.GroupBox1.Controls.Add(Me.txt_nombre_proveedor)
        Me.GroupBox1.Controls.Add(Me.lbl_ingreso)
        Me.GroupBox1.Controls.Add(Me.lbl_rut)
        Me.GroupBox1.Controls.Add(Me.txt_credito_proveedor)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(207, 142)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(360, 65)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DATOS DEL PROVEEDOR"
        '
        'txt_rut_proveedor
        '
        Me.txt_rut_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut_proveedor.Location = New System.Drawing.Point(7, 25)
        Me.txt_rut_proveedor.MaxLength = 11
        Me.txt_rut_proveedor.Name = "txt_rut_proveedor"
        Me.txt_rut_proveedor.Size = New System.Drawing.Size(100, 24)
        Me.txt_rut_proveedor.TabIndex = 9
        '
        'txt_nombre_proveedor
        '
        Me.txt_nombre_proveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txt_nombre_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_proveedor.Location = New System.Drawing.Point(113, 25)
        Me.txt_nombre_proveedor.Name = "txt_nombre_proveedor"
        Me.txt_nombre_proveedor.ReadOnly = True
        Me.txt_nombre_proveedor.Size = New System.Drawing.Size(240, 24)
        Me.txt_nombre_proveedor.TabIndex = 0
        Me.txt_nombre_proveedor.TabStop = False
        '
        'lbl_ingreso
        '
        Me.lbl_ingreso.AutoSize = True
        Me.lbl_ingreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ingreso.Location = New System.Drawing.Point(253, 33)
        Me.lbl_ingreso.Name = "lbl_ingreso"
        Me.lbl_ingreso.Size = New System.Drawing.Size(56, 16)
        Me.lbl_ingreso.TabIndex = 0
        Me.lbl_ingreso.Text = "Label25"
        '
        'lbl_rut
        '
        Me.lbl_rut.AutoSize = True
        Me.lbl_rut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rut.Location = New System.Drawing.Point(14, 33)
        Me.lbl_rut.Name = "lbl_rut"
        Me.lbl_rut.Size = New System.Drawing.Size(43, 16)
        Me.lbl_rut.TabIndex = 0
        Me.lbl_rut.Text = "lbl_rut"
        '
        'txt_credito_proveedor
        '
        Me.txt_credito_proveedor.Enabled = False
        Me.txt_credito_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_credito_proveedor.Location = New System.Drawing.Point(181, 25)
        Me.txt_credito_proveedor.Multiline = True
        Me.txt_credito_proveedor.Name = "txt_credito_proveedor"
        Me.txt_credito_proveedor.Size = New System.Drawing.Size(107, 24)
        Me.txt_credito_proveedor.TabIndex = 6
        Me.txt_credito_proveedor.TabStop = False
        '
        'btn_agregar
        '
        Me.btn_agregar.BackColor = System.Drawing.Color.Transparent
        Me.btn_agregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar.Image = CType(resources.GetObject("btn_agregar.Image"), System.Drawing.Image)
        Me.btn_agregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_agregar.Location = New System.Drawing.Point(791, 223)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(95, 40)
        Me.btn_agregar.TabIndex = 12
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
        Me.btn_quitar_elemento.Location = New System.Drawing.Point(891, 223)
        Me.btn_quitar_elemento.Name = "btn_quitar_elemento"
        Me.btn_quitar_elemento.Size = New System.Drawing.Size(95, 40)
        Me.btn_quitar_elemento.TabIndex = 13
        Me.btn_quitar_elemento.Text = "QUITAR"
        Me.btn_quitar_elemento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_quitar_elemento.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Combo_clasificacion_cuenta)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 142)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(195, 65)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "TIPO DE CUENTA:"
        '
        'Combo_clasificacion_cuenta
        '
        Me.Combo_clasificacion_cuenta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_clasificacion_cuenta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_clasificacion_cuenta.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_clasificacion_cuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_clasificacion_cuenta.FormattingEnabled = True
        Me.Combo_clasificacion_cuenta.Items.AddRange(New Object() {"EXISTENCIAS", "ACTIVO FIJO", "GASTOS GENERALES"})
        Me.Combo_clasificacion_cuenta.Location = New System.Drawing.Point(7, 25)
        Me.Combo_clasificacion_cuenta.MaxLength = 25
        Me.Combo_clasificacion_cuenta.Name = "Combo_clasificacion_cuenta"
        Me.Combo_clasificacion_cuenta.Size = New System.Drawing.Size(181, 24)
        Me.Combo_clasificacion_cuenta.TabIndex = 4
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.dtp_emision)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(131, 207)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(125, 65)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "FECHA  DOC.:"
        '
        'dtp_emision
        '
        Me.dtp_emision.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_emision.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_emision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_emision.Location = New System.Drawing.Point(7, 28)
        Me.dtp_emision.Name = "dtp_emision"
        Me.dtp_emision.Size = New System.Drawing.Size(111, 24)
        Me.dtp_emision.TabIndex = 7
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txt_total)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(262, 207)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(119, 65)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "TOTAL DOC.:"
        '
        'txt_total
        '
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.Location = New System.Drawing.Point(7, 28)
        Me.txt_total.MaxLength = 11
        Me.txt_total.Name = "txt_total"
        Me.txt_total.Size = New System.Drawing.Size(105, 24)
        Me.txt_total.TabIndex = 8
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.txt_neto)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(387, 207)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(119, 65)
        Me.GroupBox6.TabIndex = 9
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "NETO DOC.:"
        '
        'txt_neto
        '
        Me.txt_neto.Enabled = False
        Me.txt_neto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_neto.Location = New System.Drawing.Point(7, 28)
        Me.txt_neto.MaxLength = 11
        Me.txt_neto.Name = "txt_neto"
        Me.txt_neto.Size = New System.Drawing.Size(105, 24)
        Me.txt_neto.TabIndex = 9
        Me.txt_neto.TabStop = False
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.Controls.Add(Me.txt_iva)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(512, 208)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(119, 65)
        Me.GroupBox7.TabIndex = 10
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "IVA DOC.:"
        '
        'txt_iva
        '
        Me.txt_iva.Enabled = False
        Me.txt_iva.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_iva.Location = New System.Drawing.Point(7, 28)
        Me.txt_iva.MaxLength = 11
        Me.txt_iva.Name = "txt_iva"
        Me.txt_iva.Size = New System.Drawing.Size(105, 24)
        Me.txt_iva.TabIndex = 10
        Me.txt_iva.TabStop = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 217
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox8.Controls.Add(Me.txt_numero_factura)
        Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(6, 207)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(119, 65)
        Me.GroupBox8.TabIndex = 6
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "NRO. DOC.:"
        '
        'txt_numero_factura
        '
        Me.txt_numero_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numero_factura.Location = New System.Drawing.Point(7, 28)
        Me.txt_numero_factura.MaxLength = 11
        Me.txt_numero_factura.Name = "txt_numero_factura"
        Me.txt_numero_factura.Size = New System.Drawing.Size(105, 24)
        Me.txt_numero_factura.TabIndex = 6
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox9.Controls.Add(Me.Combo_tipo_factura)
        Me.GroupBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(137, 77)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(194, 65)
        Me.GroupBox9.TabIndex = 2
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "TIPO DE INGRESO:"
        '
        'Combo_tipo_factura
        '
        Me.Combo_tipo_factura.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_tipo_factura.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_tipo_factura.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_tipo_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_tipo_factura.FormattingEnabled = True
        Me.Combo_tipo_factura.Items.AddRange(New Object() {"CON IMP. CORRIENTE", "SIN DESGLOSAR", "CON IMP. ESPECIFICO"})
        Me.Combo_tipo_factura.Location = New System.Drawing.Point(7, 25)
        Me.Combo_tipo_factura.MaxLength = 25
        Me.Combo_tipo_factura.Name = "Combo_tipo_factura"
        Me.Combo_tipo_factura.Size = New System.Drawing.Size(180, 24)
        Me.Combo_tipo_factura.TabIndex = 2
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox10.Controls.Add(Me.txt_exentas_total_millar)
        Me.GroupBox10.Controls.Add(Me.txt_total_general_millar)
        Me.GroupBox10.Controls.Add(Me.txt_iva_total_millar)
        Me.GroupBox10.Controls.Add(Me.txt_neto_total_millar)
        Me.GroupBox10.Controls.Add(Me.Label20)
        Me.GroupBox10.Controls.Add(Me.txt_exentas_total)
        Me.GroupBox10.Controls.Add(Me.Label19)
        Me.GroupBox10.Controls.Add(Me.Label18)
        Me.GroupBox10.Controls.Add(Me.Label23)
        Me.GroupBox10.Controls.Add(Me.txt_total_general)
        Me.GroupBox10.Controls.Add(Me.txt_iva_total)
        Me.GroupBox10.Controls.Add(Me.txt_neto_total)
        Me.GroupBox10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox10.Location = New System.Drawing.Point(573, 77)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(186, 131)
        Me.GroupBox10.TabIndex = 219
        Me.GroupBox10.TabStop = False
        '
        'txt_exentas_total_millar
        '
        Me.txt_exentas_total_millar.BackColor = System.Drawing.SystemColors.Control
        Me.txt_exentas_total_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_exentas_total_millar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_exentas_total_millar.Location = New System.Drawing.Point(79, 14)
        Me.txt_exentas_total_millar.Name = "txt_exentas_total_millar"
        Me.txt_exentas_total_millar.ReadOnly = True
        Me.txt_exentas_total_millar.Size = New System.Drawing.Size(100, 24)
        Me.txt_exentas_total_millar.TabIndex = 3
        Me.txt_exentas_total_millar.TabStop = False
        Me.txt_exentas_total_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_general_millar
        '
        Me.txt_total_general_millar.BackColor = System.Drawing.SystemColors.Control
        Me.txt_total_general_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_general_millar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_total_general_millar.Location = New System.Drawing.Point(79, 101)
        Me.txt_total_general_millar.Name = "txt_total_general_millar"
        Me.txt_total_general_millar.ReadOnly = True
        Me.txt_total_general_millar.Size = New System.Drawing.Size(100, 24)
        Me.txt_total_general_millar.TabIndex = 4
        Me.txt_total_general_millar.TabStop = False
        Me.txt_total_general_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_iva_total_millar
        '
        Me.txt_iva_total_millar.BackColor = System.Drawing.SystemColors.Control
        Me.txt_iva_total_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_iva_total_millar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_iva_total_millar.Location = New System.Drawing.Point(79, 72)
        Me.txt_iva_total_millar.Name = "txt_iva_total_millar"
        Me.txt_iva_total_millar.ReadOnly = True
        Me.txt_iva_total_millar.Size = New System.Drawing.Size(100, 24)
        Me.txt_iva_total_millar.TabIndex = 1
        Me.txt_iva_total_millar.TabStop = False
        Me.txt_iva_total_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_neto_total_millar
        '
        Me.txt_neto_total_millar.BackColor = System.Drawing.SystemColors.Control
        Me.txt_neto_total_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_neto_total_millar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_neto_total_millar.Location = New System.Drawing.Point(79, 43)
        Me.txt_neto_total_millar.Name = "txt_neto_total_millar"
        Me.txt_neto_total_millar.ReadOnly = True
        Me.txt_neto_total_millar.Size = New System.Drawing.Size(100, 24)
        Me.txt_neto_total_millar.TabIndex = 2
        Me.txt_neto_total_millar.TabStop = False
        Me.txt_neto_total_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(3, 17)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(74, 16)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "EXENTAS:"
        '
        'txt_exentas_total
        '
        Me.txt_exentas_total.BackColor = System.Drawing.SystemColors.Control
        Me.txt_exentas_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_exentas_total.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_exentas_total.Location = New System.Drawing.Point(79, 15)
        Me.txt_exentas_total.Name = "txt_exentas_total"
        Me.txt_exentas_total.ReadOnly = True
        Me.txt_exentas_total.Size = New System.Drawing.Size(78, 20)
        Me.txt_exentas_total.TabIndex = 0
        Me.txt_exentas_total.TabStop = False
        Me.txt_exentas_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(22, 104)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 16)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "TOTAL:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(45, 75)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(32, 16)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "IVA:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(28, 46)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(49, 16)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "NETO:"
        '
        'txt_total_general
        '
        Me.txt_total_general.BackColor = System.Drawing.SystemColors.Control
        Me.txt_total_general.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_general.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_total_general.Location = New System.Drawing.Point(79, 102)
        Me.txt_total_general.Name = "txt_total_general"
        Me.txt_total_general.ReadOnly = True
        Me.txt_total_general.Size = New System.Drawing.Size(78, 20)
        Me.txt_total_general.TabIndex = 0
        Me.txt_total_general.TabStop = False
        Me.txt_total_general.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_iva_total
        '
        Me.txt_iva_total.BackColor = System.Drawing.SystemColors.Control
        Me.txt_iva_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_iva_total.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_iva_total.Location = New System.Drawing.Point(79, 73)
        Me.txt_iva_total.Name = "txt_iva_total"
        Me.txt_iva_total.ReadOnly = True
        Me.txt_iva_total.Size = New System.Drawing.Size(78, 20)
        Me.txt_iva_total.TabIndex = 0
        Me.txt_iva_total.TabStop = False
        Me.txt_iva_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_neto_total
        '
        Me.txt_neto_total.BackColor = System.Drawing.SystemColors.Control
        Me.txt_neto_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_neto_total.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_neto_total.Location = New System.Drawing.Point(79, 44)
        Me.txt_neto_total.Name = "txt_neto_total"
        Me.txt_neto_total.ReadOnly = True
        Me.txt_neto_total.Size = New System.Drawing.Size(78, 20)
        Me.txt_neto_total.TabIndex = 0
        Me.txt_neto_total.TabStop = False
        Me.txt_neto_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.txt_impuesto_especifico)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(637, 208)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(120, 65)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "I. ESPECIFICO"
        '
        'txt_impuesto_especifico
        '
        Me.txt_impuesto_especifico.Enabled = False
        Me.txt_impuesto_especifico.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_impuesto_especifico.Location = New System.Drawing.Point(7, 28)
        Me.txt_impuesto_especifico.MaxLength = 11
        Me.txt_impuesto_especifico.Name = "txt_impuesto_especifico"
        Me.txt_impuesto_especifico.Size = New System.Drawing.Size(105, 24)
        Me.txt_impuesto_especifico.TabIndex = 11
        '
        'GroupBox11
        '
        Me.GroupBox11.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox11.Controls.Add(Me.Combo_tipo_documento)
        Me.GroupBox11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox11.Location = New System.Drawing.Point(337, 77)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(230, 65)
        Me.GroupBox11.TabIndex = 3
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "TIPO DOCUMENTO:"
        '
        'Combo_tipo_documento
        '
        Me.Combo_tipo_documento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_tipo_documento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_tipo_documento.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_tipo_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_tipo_documento.FormattingEnabled = True
        Me.Combo_tipo_documento.Items.AddRange(New Object() {"FACTURA MANUAL", "FACTURA ELECTRONICA", "NOTA DE CREDITO MANUAL", "NOTA DE CREDITO ELECTRONICA", "NOTA DE DEBITO MANUAL", "NOTA DE DEBITO ELECTRONICA"})
        Me.Combo_tipo_documento.Location = New System.Drawing.Point(7, 25)
        Me.Combo_tipo_documento.MaxLength = 25
        Me.Combo_tipo_documento.Name = "Combo_tipo_documento"
        Me.Combo_tipo_documento.Size = New System.Drawing.Size(216, 24)
        Me.Combo_tipo_documento.TabIndex = 3
        '
        'btn_cargar
        '
        Me.btn_cargar.BackColor = System.Drawing.Color.Transparent
        Me.btn_cargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cargar.Image = CType(resources.GetObject("btn_cargar.Image"), System.Drawing.Image)
        Me.btn_cargar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cargar.Location = New System.Drawing.Point(126, 25)
        Me.btn_cargar.Name = "btn_cargar"
        Me.btn_cargar.Size = New System.Drawing.Size(95, 40)
        Me.btn_cargar.TabIndex = 2
        Me.btn_cargar.Text = "CARGAR"
        Me.btn_cargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cargar.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(126, 70)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
        Me.btn_salir.TabIndex = 4
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
        Me.btn_limpiar.Location = New System.Drawing.Point(26, 70)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(95, 40)
        Me.btn_limpiar.TabIndex = 3
        Me.btn_limpiar.Text = "LIMPIAR"
        Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_limpiar.UseVisualStyleBackColor = False
        '
        'GroupBox13
        '
        Me.GroupBox13.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox13.Controls.Add(Me.dtp_tributario)
        Me.GroupBox13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox13.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(125, 65)
        Me.GroupBox13.TabIndex = 1
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "P. TRIBUTARIO:"
        '
        'dtp_tributario
        '
        Me.dtp_tributario.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tributario.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_tributario.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_tributario.Location = New System.Drawing.Point(7, 25)
        Me.dtp_tributario.Name = "dtp_tributario"
        Me.dtp_tributario.Size = New System.Drawing.Size(111, 24)
        Me.dtp_tributario.TabIndex = 1
        '
        'GroupBox14
        '
        Me.GroupBox14.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox14.Controls.Add(Me.btn_salir)
        Me.GroupBox14.Controls.Add(Me.btn_cargar)
        Me.GroupBox14.Controls.Add(Me.btn_limpiar)
        Me.GroupBox14.Controls.Add(Me.btn_nueva)
        Me.GroupBox14.Location = New System.Drawing.Point(765, 77)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(246, 131)
        Me.GroupBox14.TabIndex = 221
        Me.GroupBox14.TabStop = False
        '
        'btn_nueva
        '
        Me.btn_nueva.BackColor = System.Drawing.Color.Transparent
        Me.btn_nueva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_nueva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nueva.Image = CType(resources.GetObject("btn_nueva.Image"), System.Drawing.Image)
        Me.btn_nueva.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nueva.Location = New System.Drawing.Point(26, 25)
        Me.btn_nueva.Name = "btn_nueva"
        Me.btn_nueva.Size = New System.Drawing.Size(95, 40)
        Me.btn_nueva.TabIndex = 1
        Me.btn_nueva.Text = "NUEVO"
        Me.btn_nueva.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nueva.UseVisualStyleBackColor = False
        '
        'txt_tipo_documento
        '
        Me.txt_tipo_documento.Enabled = False
        Me.txt_tipo_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tipo_documento.Location = New System.Drawing.Point(891, 91)
        Me.txt_tipo_documento.MaxLength = 11
        Me.txt_tipo_documento.Name = "txt_tipo_documento"
        Me.txt_tipo_documento.Size = New System.Drawing.Size(111, 24)
        Me.txt_tipo_documento.TabIndex = 11
        Me.txt_tipo_documento.TabStop = False
        '
        'txt_documento
        '
        Me.txt_documento.Enabled = False
        Me.txt_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_documento.Location = New System.Drawing.Point(807, 91)
        Me.txt_documento.MaxLength = 11
        Me.txt_documento.Name = "txt_documento"
        Me.txt_documento.Size = New System.Drawing.Size(111, 24)
        Me.txt_documento.TabIndex = 222
        Me.txt_documento.TabStop = False
        '
        'TextBox4
        '
        Me.TextBox4.Enabled = False
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(807, 91)
        Me.TextBox4.MaxLength = 11
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(111, 24)
        Me.TextBox4.TabIndex = 223
        '
        'txt_folio
        '
        Me.txt_folio.BackColor = System.Drawing.SystemColors.Window
        Me.txt_folio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_folio.ForeColor = System.Drawing.Color.Black
        Me.txt_folio.Location = New System.Drawing.Point(912, 14)
        Me.txt_folio.Name = "txt_folio"
        Me.txt_folio.Size = New System.Drawing.Size(100, 24)
        Me.txt_folio.TabIndex = 224
        Me.txt_folio.TabStop = False
        Me.txt_folio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(803, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "NRO. DE FOLIO:"
        '
        'dtp3
        '
        Me.dtp3.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp3.Enabled = False
        Me.dtp3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp3.Location = New System.Drawing.Point(638, 92)
        Me.dtp3.Name = "dtp3"
        Me.dtp3.Size = New System.Drawing.Size(111, 24)
        Me.dtp3.TabIndex = 2
        '
        'dtp_vencimiento
        '
        Me.dtp_vencimiento.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_vencimiento.Enabled = False
        Me.dtp_vencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_vencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_vencimiento.Location = New System.Drawing.Point(639, 111)
        Me.dtp_vencimiento.Name = "dtp_vencimiento"
        Me.dtp_vencimiento.Size = New System.Drawing.Size(111, 24)
        Me.dtp_vencimiento.TabIndex = 226
        '
        'dtp_fecha_de_ingreso
        '
        Me.dtp_fecha_de_ingreso.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_de_ingreso.Enabled = False
        Me.dtp_fecha_de_ingreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_de_ingreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha_de_ingreso.Location = New System.Drawing.Point(628, 93)
        Me.dtp_fecha_de_ingreso.Name = "dtp_fecha_de_ingreso"
        Me.dtp_fecha_de_ingreso.Size = New System.Drawing.Size(111, 24)
        Me.dtp_fecha_de_ingreso.TabIndex = 2
        '
        'Timer_inactividad_libro_compra
        '
        '
        'Check_limpiar
        '
        Me.Check_limpiar.AutoSize = True
        Me.Check_limpiar.BackColor = System.Drawing.Color.Transparent
        Me.Check_limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_limpiar.Location = New System.Drawing.Point(607, 50)
        Me.Check_limpiar.Name = "Check_limpiar"
        Me.Check_limpiar.Size = New System.Drawing.Size(412, 20)
        Me.Check_limpiar.TabIndex = 225
        Me.Check_limpiar.TabStop = False
        Me.Check_limpiar.Text = "INGRESO MULTIPLE DE DOCUMENTOS DE UN PROVEEDOR"
        Me.Check_limpiar.UseVisualStyleBackColor = False
        '
        'Form_libro_de_compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 700)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Check_limpiar)
        Me.Controls.Add(Me.GroupBox13)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btn_agregar)
        Me.Controls.Add(Me.btn_quitar_elemento)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grilla_libro_compras)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.txt_folio)
        Me.Controls.Add(Me.dtp3)
        Me.Controls.Add(Me.dtp_vencimiento)
        Me.Controls.Add(Me.dtp_fecha_de_ingreso)
        Me.Controls.Add(Me.GroupBox14)
        Me.Controls.Add(Me.txt_documento)
        Me.Controls.Add(Me.txt_tipo_documento)
        Me.Controls.Add(Me.TextBox4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_libro_de_compras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LIBRO DE COMPRAS"
        CType(Me.grilla_libro_compras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox14.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grilla_libro_compras As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_nombre_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ingreso As System.Windows.Forms.Label
    Friend WithEvents lbl_rut As System.Windows.Forms.Label
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents btn_quitar_elemento As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Combo_clasificacion_cuenta As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_emision As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_numero_factura As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt_exentas_total As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txt_total_general As System.Windows.Forms.TextBox
    Friend WithEvents txt_iva_total As System.Windows.Forms.TextBox
    Friend WithEvents txt_neto_total As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_impuesto_especifico As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Combo_tipo_documento As System.Windows.Forms.ComboBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_cargar As System.Windows.Forms.Button
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_nueva As System.Windows.Forms.Button
    Friend WithEvents dtp_tributario As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_tipo_documento As System.Windows.Forms.TextBox
    Friend WithEvents txt_documento As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_folio As System.Windows.Forms.TextBox
    Friend WithEvents txt_neto As System.Windows.Forms.TextBox
    Friend WithEvents txt_iva As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_vencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_credito_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Combo_tipo_factura As System.Windows.Forms.ComboBox
    Friend WithEvents txt_rut_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents dtp_fecha_de_ingreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Timer_inactividad_libro_compra As System.Windows.Forms.Timer
    Friend WithEvents txt_exentas_total_millar As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_general_millar As System.Windows.Forms.TextBox
    Friend WithEvents txt_iva_total_millar As System.Windows.Forms.TextBox
    Friend WithEvents txt_neto_total_millar As System.Windows.Forms.TextBox
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Check_limpiar As System.Windows.Forms.CheckBox
End Class
