<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_detalle_ventas_credito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_detalle_ventas_credito))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txt_descuento_millar = New System.Windows.Forms.TextBox()
        Me.GroupBox_totales = New System.Windows.Forms.GroupBox()
        Me.txt_total_millar = New System.Windows.Forms.TextBox()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.txt_subtotal_millar = New System.Windows.Forms.TextBox()
        Me.txt_descuento = New System.Windows.Forms.TextBox()
        Me.GroupBox_tipo_venta = New System.Windows.Forms.GroupBox()
        Me.combo_venta = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtp_desde = New System.Windows.Forms.DateTimePicker()
        Me.txt_subtotal = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtp_hasta = New System.Windows.Forms.DateTimePicker()
        Me.lbl_mensaje = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn_mostrar = New System.Windows.Forms.Button()
        Me.btn_exportar_excel = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_limpiar = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Barra_titulo1 = New proyecto_sistema_ventas.Barra_titulo()
        Me.Barra_pie1 = New proyecto_sistema_ventas.Barra_pie()
        Me.Barra_lateral_izquierda1 = New proyecto_sistema_ventas.Barra_lateral_izquierda()
        Me.Barra_lateral_derecha1 = New proyecto_sistema_ventas.Barra_lateral_derecha()
        Me.grilla_documento = New System.Windows.Forms.DataGridView()
        Me.GroupBox_totales.SuspendLayout()
        Me.GroupBox_tipo_venta.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_documento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_descuento_millar
        '
        Me.txt_descuento_millar.BackColor = System.Drawing.SystemColors.Control
        Me.txt_descuento_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descuento_millar.ForeColor = System.Drawing.Color.Black
        Me.txt_descuento_millar.Location = New System.Drawing.Point(639, 390)
        Me.txt_descuento_millar.Name = "txt_descuento_millar"
        Me.txt_descuento_millar.ReadOnly = True
        Me.txt_descuento_millar.Size = New System.Drawing.Size(90, 24)
        Me.txt_descuento_millar.TabIndex = 315
        Me.txt_descuento_millar.TabStop = False
        Me.txt_descuento_millar.Text = "0"
        Me.txt_descuento_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox_totales
        '
        Me.GroupBox_totales.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_totales.Controls.Add(Me.txt_total_millar)
        Me.GroupBox_totales.Controls.Add(Me.txt_total)
        Me.GroupBox_totales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_totales.Location = New System.Drawing.Point(843, 360)
        Me.GroupBox_totales.Name = "GroupBox_totales"
        Me.GroupBox_totales.Size = New System.Drawing.Size(174, 83)
        Me.GroupBox_totales.TabIndex = 304
        Me.GroupBox_totales.TabStop = False
        Me.GroupBox_totales.Text = "TOTAL DEUDA:"
        '
        'txt_total_millar
        '
        Me.txt_total_millar.BackColor = System.Drawing.SystemColors.Control
        Me.txt_total_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_millar.ForeColor = System.Drawing.Color.Black
        Me.txt_total_millar.Location = New System.Drawing.Point(32, 33)
        Me.txt_total_millar.Name = "txt_total_millar"
        Me.txt_total_millar.ReadOnly = True
        Me.txt_total_millar.Size = New System.Drawing.Size(111, 24)
        Me.txt_total_millar.TabIndex = 132
        Me.txt_total_millar.TabStop = False
        Me.txt_total_millar.Text = "0"
        Me.txt_total_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.Black
        Me.txt_total.Location = New System.Drawing.Point(80, 34)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(61, 20)
        Me.txt_total.TabIndex = 0
        Me.txt_total.TabStop = False
        Me.txt_total.Text = "0"
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_subtotal_millar
        '
        Me.txt_subtotal_millar.BackColor = System.Drawing.SystemColors.Control
        Me.txt_subtotal_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_subtotal_millar.ForeColor = System.Drawing.Color.Black
        Me.txt_subtotal_millar.Location = New System.Drawing.Point(639, 358)
        Me.txt_subtotal_millar.Name = "txt_subtotal_millar"
        Me.txt_subtotal_millar.ReadOnly = True
        Me.txt_subtotal_millar.Size = New System.Drawing.Size(90, 24)
        Me.txt_subtotal_millar.TabIndex = 314
        Me.txt_subtotal_millar.TabStop = False
        Me.txt_subtotal_millar.Text = "0"
        Me.txt_subtotal_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_descuento
        '
        Me.txt_descuento.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_descuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descuento.ForeColor = System.Drawing.Color.Black
        Me.txt_descuento.Location = New System.Drawing.Point(663, 390)
        Me.txt_descuento.Name = "txt_descuento"
        Me.txt_descuento.ReadOnly = True
        Me.txt_descuento.Size = New System.Drawing.Size(61, 20)
        Me.txt_descuento.TabIndex = 305
        Me.txt_descuento.TabStop = False
        Me.txt_descuento.Text = "0"
        Me.txt_descuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox_tipo_venta
        '
        Me.GroupBox_tipo_venta.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_tipo_venta.Controls.Add(Me.combo_venta)
        Me.GroupBox_tipo_venta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_tipo_venta.Location = New System.Drawing.Point(843, 277)
        Me.GroupBox_tipo_venta.Name = "GroupBox_tipo_venta"
        Me.GroupBox_tipo_venta.Size = New System.Drawing.Size(174, 83)
        Me.GroupBox_tipo_venta.TabIndex = 311
        Me.GroupBox_tipo_venta.TabStop = False
        Me.GroupBox_tipo_venta.Text = "TIPO DE DOCUMENTO:"
        '
        'combo_venta
        '
        Me.combo_venta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_venta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_venta.BackColor = System.Drawing.SystemColors.Window
        Me.combo_venta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_venta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_venta.ForeColor = System.Drawing.Color.Black
        Me.combo_venta.FormattingEnabled = True
        Me.combo_venta.Items.AddRange(New Object() {"-", "BOLETA", "FACTURA", "GUIA", "NOTA DE DEBITO", "NOTA DE CREDITO"})
        Me.combo_venta.Location = New System.Drawing.Point(7, 33)
        Me.combo_venta.Name = "combo_venta"
        Me.combo_venta.Size = New System.Drawing.Size(160, 26)
        Me.combo_venta.TabIndex = 8
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dtp_desde)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(843, 111)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(174, 83)
        Me.GroupBox2.TabIndex = 309
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DESDE:"
        '
        'dtp_desde
        '
        Me.dtp_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_desde.Location = New System.Drawing.Point(32, 33)
        Me.dtp_desde.Name = "dtp_desde"
        Me.dtp_desde.Size = New System.Drawing.Size(111, 24)
        Me.dtp_desde.TabIndex = 0
        '
        'txt_subtotal
        '
        Me.txt_subtotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_subtotal.ForeColor = System.Drawing.Color.Black
        Me.txt_subtotal.Location = New System.Drawing.Point(663, 358)
        Me.txt_subtotal.Name = "txt_subtotal"
        Me.txt_subtotal.ReadOnly = True
        Me.txt_subtotal.Size = New System.Drawing.Size(61, 20)
        Me.txt_subtotal.TabIndex = 306
        Me.txt_subtotal.TabStop = False
        Me.txt_subtotal.Text = "0"
        Me.txt_subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.dtp_hasta)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(843, 194)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(174, 83)
        Me.GroupBox3.TabIndex = 310
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "HASTA:"
        '
        'dtp_hasta
        '
        Me.dtp_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_hasta.Location = New System.Drawing.Point(32, 33)
        Me.dtp_hasta.Name = "dtp_hasta"
        Me.dtp_hasta.Size = New System.Drawing.Size(111, 24)
        Me.dtp_hasta.TabIndex = 0
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(308, 36)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(714, 81)
        Me.lbl_mensaje.TabIndex = 316
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(554, 361)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(83, 16)
        Me.Label23.TabIndex = 307
        Me.Label23.Text = "SUBTOTAL:"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btn_mostrar)
        Me.GroupBox4.Controls.Add(Me.btn_exportar_excel)
        Me.GroupBox4.Controls.Add(Me.btn_salir)
        Me.GroupBox4.Controls.Add(Me.btn_limpiar)
        Me.GroupBox4.Location = New System.Drawing.Point(843, 443)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(174, 274)
        Me.GroupBox4.TabIndex = 313
        Me.GroupBox4.TabStop = False
        '
        'btn_mostrar
        '
        Me.btn_mostrar.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.btn_mostrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_mostrar.FlatAppearance.BorderSize = 0
        Me.btn_mostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_mostrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_mostrar.ForeColor = System.Drawing.Color.White
        Me.btn_mostrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_mostrar.Location = New System.Drawing.Point(7, 13)
        Me.btn_mostrar.Name = "btn_mostrar"
        Me.btn_mostrar.Size = New System.Drawing.Size(160, 59)
        Me.btn_mostrar.TabIndex = 1
        Me.btn_mostrar.Text = "MOSTRAR"
        Me.btn_mostrar.UseVisualStyleBackColor = False
        '
        'btn_exportar_excel
        '
        Me.btn_exportar_excel.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.btn_exportar_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_exportar_excel.FlatAppearance.BorderSize = 0
        Me.btn_exportar_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exportar_excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar_excel.ForeColor = System.Drawing.Color.White
        Me.btn_exportar_excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exportar_excel.Location = New System.Drawing.Point(7, 143)
        Me.btn_exportar_excel.Name = "btn_exportar_excel"
        Me.btn_exportar_excel.Size = New System.Drawing.Size(160, 59)
        Me.btn_exportar_excel.TabIndex = 4
        Me.btn_exportar_excel.Text = "EXPORTAR"
        Me.btn_exportar_excel.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.btn_salir.FlatAppearance.BorderSize = 0
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.ForeColor = System.Drawing.Color.White
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(7, 208)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(160, 58)
        Me.btn_salir.TabIndex = 5
        Me.btn_salir.Text = "SALIR"
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_limpiar
        '
        Me.btn_limpiar.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.btn_limpiar.FlatAppearance.BorderSize = 0
        Me.btn_limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_limpiar.ForeColor = System.Drawing.Color.White
        Me.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_limpiar.Location = New System.Drawing.Point(7, 78)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(160, 59)
        Me.btn_limpiar.TabIndex = 3
        Me.btn_limpiar.Text = "LIMPIAR"
        Me.btn_limpiar.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(585, 393)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 16)
        Me.Label18.TabIndex = 308
        Me.Label18.Text = "DCTO.:"
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(7, 41)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 317
        Me.PictureBox_logo.TabStop = False
        '
        'PrintDocument1
        '
        Me.PrintDocument1.DocumentName = "Reporte"
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Barra_titulo1
        '
        Me.Barra_titulo1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Barra_titulo1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Barra_titulo1.Location = New System.Drawing.Point(1, 0)
        Me.Barra_titulo1.Name = "Barra_titulo1"
        Me.Barra_titulo1.Padding = New System.Windows.Forms.Padding(2)
        Me.Barra_titulo1.Size = New System.Drawing.Size(1022, 35)
        Me.Barra_titulo1.TabIndex = 3
        Me.Barra_titulo1.TabStop = False
        '
        'Barra_pie1
        '
        Me.Barra_pie1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Barra_pie1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Barra_pie1.Location = New System.Drawing.Point(1, 723)
        Me.Barra_pie1.Name = "Barra_pie1"
        Me.Barra_pie1.Size = New System.Drawing.Size(1022, 5)
        Me.Barra_pie1.TabIndex = 2
        '
        'Barra_lateral_izquierda1
        '
        Me.Barra_lateral_izquierda1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Barra_lateral_izquierda1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Barra_lateral_izquierda1.Location = New System.Drawing.Point(0, 0)
        Me.Barra_lateral_izquierda1.Name = "Barra_lateral_izquierda1"
        Me.Barra_lateral_izquierda1.Size = New System.Drawing.Size(1, 728)
        Me.Barra_lateral_izquierda1.TabIndex = 1
        '
        'Barra_lateral_derecha1
        '
        Me.Barra_lateral_derecha1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Barra_lateral_derecha1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Barra_lateral_derecha1.Location = New System.Drawing.Point(1023, 0)
        Me.Barra_lateral_derecha1.Name = "Barra_lateral_derecha1"
        Me.Barra_lateral_derecha1.Size = New System.Drawing.Size(1, 728)
        Me.Barra_lateral_derecha1.TabIndex = 0
        '
        'grilla_documento
        '
        Me.grilla_documento.AllowUserToAddRows = False
        Me.grilla_documento.AllowUserToDeleteRows = False
        Me.grilla_documento.AllowUserToResizeColumns = False
        Me.grilla_documento.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grilla_documento.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grilla_documento.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.grilla_documento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_documento.Location = New System.Drawing.Point(7, 117)
        Me.grilla_documento.Name = "grilla_documento"
        Me.grilla_documento.ReadOnly = True
        Me.grilla_documento.RowHeadersVisible = False
        Me.grilla_documento.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grilla_documento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grilla_documento.Size = New System.Drawing.Size(830, 599)
        Me.grilla_documento.TabIndex = 319
        '
        'Form_detalle_ventas_credito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 728)
        Me.Controls.Add(Me.grilla_documento)
        Me.Controls.Add(Me.txt_descuento_millar)
        Me.Controls.Add(Me.GroupBox_totales)
        Me.Controls.Add(Me.txt_subtotal_millar)
        Me.Controls.Add(Me.txt_descuento)
        Me.Controls.Add(Me.GroupBox_tipo_venta)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txt_subtotal)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.Barra_titulo1)
        Me.Controls.Add(Me.Barra_pie1)
        Me.Controls.Add(Me.Barra_lateral_izquierda1)
        Me.Controls.Add(Me.Barra_lateral_derecha1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form_detalle_ventas_credito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DETALLE VENTAS CREDITO"
        Me.GroupBox_totales.ResumeLayout(False)
        Me.GroupBox_totales.PerformLayout()
        Me.GroupBox_tipo_venta.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_documento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Barra_lateral_derecha1 As Barra_lateral_derecha
    Friend WithEvents Barra_lateral_izquierda1 As Barra_lateral_izquierda
    Friend WithEvents Barra_pie1 As Barra_pie
    Friend WithEvents Barra_titulo1 As Barra_titulo
    Friend WithEvents txt_descuento_millar As TextBox
    Friend WithEvents GroupBox_totales As GroupBox
    Friend WithEvents txt_total_millar As TextBox
    Friend WithEvents txt_total As TextBox
    Friend WithEvents txt_subtotal_millar As TextBox
    Friend WithEvents txt_descuento As TextBox
    Friend WithEvents GroupBox_tipo_venta As GroupBox
    Friend WithEvents combo_venta As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtp_desde As DateTimePicker
    Friend WithEvents txt_subtotal As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dtp_hasta As DateTimePicker
    Friend WithEvents lbl_mensaje As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btn_mostrar As Button
    Friend WithEvents btn_exportar_excel As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents btn_limpiar As Button
    Friend WithEvents Label18 As Label
    Friend WithEvents PictureBox_logo As PictureBox
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents PrintDialog1 As PrintDialog
    Private WithEvents grilla_documento As DataGridView
End Class
