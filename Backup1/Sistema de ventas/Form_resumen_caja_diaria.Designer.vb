<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_resumen_caja_diaria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_resumen_caja_diaria))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lbl_mensaje = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btn_mostrar = New System.Windows.Forms.Button
        Me.btn_exportar_excel = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_limpiar = New System.Windows.Forms.Button
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dtp_desde = New System.Windows.Forms.DateTimePicker
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dtp_hasta = New System.Windows.Forms.DateTimePicker
        Me.dtp_ingresar = New System.Windows.Forms.DateTimePicker
        Me.txt_boletas_contado = New System.Windows.Forms.TextBox
        Me.txt_guias_contado = New System.Windows.Forms.TextBox
        Me.txt_abonos_contado = New System.Windows.Forms.TextBox
        Me.txt_facturas_contado = New System.Windows.Forms.TextBox
        Me.grilla_libro_compras = New System.Windows.Forms.DataGridView
        Me.txt_boletas_cantidad = New System.Windows.Forms.TextBox
        Me.txt_facturas_cantidad = New System.Windows.Forms.TextBox
        Me.txt_guias_cantidad = New System.Windows.Forms.TextBox
        Me.combo_sucursal = New System.Windows.Forms.ComboBox
        Me.GroupBox_tipo_venta = New System.Windows.Forms.GroupBox
        Me.txt_facturas_pie = New System.Windows.Forms.TextBox
        Me.txt_egresos = New System.Windows.Forms.TextBox
        Me.txt_guias_pie = New System.Windows.Forms.TextBox
        Me.txt_boletas_pie = New System.Windows.Forms.TextBox
        Me.txt_facturas_credito = New System.Windows.Forms.TextBox
        Me.txt_abonos_credito = New System.Windows.Forms.TextBox
        Me.txt_guias_credito = New System.Windows.Forms.TextBox
        Me.txt_boletas_credito = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_ndc_contado = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txt_ndc_credito = New System.Windows.Forms.TextBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.txt_ndc_cantidad = New System.Windows.Forms.TextBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.txt_total_efectivo = New System.Windows.Forms.TextBox
        Me.txt_total_cheque_al_dia = New System.Windows.Forms.TextBox
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grilla_libro_compras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_tipo_venta.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(307, 1)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(711, 81)
        Me.lbl_mensaje.TabIndex = 306
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btn_mostrar)
        Me.GroupBox4.Controls.Add(Me.btn_exportar_excel)
        Me.GroupBox4.Controls.Add(Me.btn_salir)
        Me.GroupBox4.Controls.Add(Me.btn_limpiar)
        Me.GroupBox4.Location = New System.Drawing.Point(596, 78)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(411, 64)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        '
        'btn_mostrar
        '
        Me.btn_mostrar.BackColor = System.Drawing.Color.Transparent
        Me.btn_mostrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_mostrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_mostrar.Image = CType(resources.GetObject("btn_mostrar.Image"), System.Drawing.Image)
        Me.btn_mostrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_mostrar.Location = New System.Drawing.Point(8, 15)
        Me.btn_mostrar.Name = "btn_mostrar"
        Me.btn_mostrar.Size = New System.Drawing.Size(95, 40)
        Me.btn_mostrar.TabIndex = 1
        Me.btn_mostrar.Text = "MOSTRAR"
        Me.btn_mostrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_mostrar.UseVisualStyleBackColor = False
        '
        'btn_exportar_excel
        '
        Me.btn_exportar_excel.BackColor = System.Drawing.Color.Transparent
        Me.btn_exportar_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_exportar_excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar_excel.Image = CType(resources.GetObject("btn_exportar_excel.Image"), System.Drawing.Image)
        Me.btn_exportar_excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exportar_excel.Location = New System.Drawing.Point(208, 15)
        Me.btn_exportar_excel.Name = "btn_exportar_excel"
        Me.btn_exportar_excel.Size = New System.Drawing.Size(95, 40)
        Me.btn_exportar_excel.TabIndex = 3
        Me.btn_exportar_excel.Text = "EXPORTAR"
        Me.btn_exportar_excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exportar_excel.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(308, 15)
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
        Me.btn_limpiar.Location = New System.Drawing.Point(108, 15)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(95, 40)
        Me.btn_limpiar.TabIndex = 2
        Me.btn_limpiar.Text = "LIMPIAR"
        Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_limpiar.UseVisualStyleBackColor = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 307
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dtp_desde)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(150, 65)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DESDE:"
        '
        'dtp_desde
        '
        Me.dtp_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_desde.Location = New System.Drawing.Point(20, 24)
        Me.dtp_desde.Name = "dtp_desde"
        Me.dtp_desde.Size = New System.Drawing.Size(111, 24)
        Me.dtp_desde.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.dtp_hasta)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(162, 77)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(150, 65)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "HASTA:"
        '
        'dtp_hasta
        '
        Me.dtp_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_hasta.Location = New System.Drawing.Point(20, 24)
        Me.dtp_hasta.Name = "dtp_hasta"
        Me.dtp_hasta.Size = New System.Drawing.Size(111, 24)
        Me.dtp_hasta.TabIndex = 0
        '
        'dtp_ingresar
        '
        Me.dtp_ingresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ingresar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_ingresar.Location = New System.Drawing.Point(157, 251)
        Me.dtp_ingresar.Name = "dtp_ingresar"
        Me.dtp_ingresar.Size = New System.Drawing.Size(111, 24)
        Me.dtp_ingresar.TabIndex = 1
        Me.dtp_ingresar.TabStop = False
        '
        'txt_boletas_contado
        '
        Me.txt_boletas_contado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_boletas_contado.Location = New System.Drawing.Point(20, 27)
        Me.txt_boletas_contado.Name = "txt_boletas_contado"
        Me.txt_boletas_contado.ReadOnly = True
        Me.txt_boletas_contado.Size = New System.Drawing.Size(80, 24)
        Me.txt_boletas_contado.TabIndex = 310
        Me.txt_boletas_contado.TabStop = False
        Me.txt_boletas_contado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_guias_contado
        '
        Me.txt_guias_contado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_guias_contado.Location = New System.Drawing.Point(20, 87)
        Me.txt_guias_contado.Name = "txt_guias_contado"
        Me.txt_guias_contado.ReadOnly = True
        Me.txt_guias_contado.Size = New System.Drawing.Size(80, 24)
        Me.txt_guias_contado.TabIndex = 311
        Me.txt_guias_contado.TabStop = False
        Me.txt_guias_contado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_abonos_contado
        '
        Me.txt_abonos_contado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_abonos_contado.Location = New System.Drawing.Point(20, 117)
        Me.txt_abonos_contado.Name = "txt_abonos_contado"
        Me.txt_abonos_contado.ReadOnly = True
        Me.txt_abonos_contado.Size = New System.Drawing.Size(80, 24)
        Me.txt_abonos_contado.TabIndex = 312
        Me.txt_abonos_contado.TabStop = False
        Me.txt_abonos_contado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_facturas_contado
        '
        Me.txt_facturas_contado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_facturas_contado.Location = New System.Drawing.Point(20, 57)
        Me.txt_facturas_contado.Name = "txt_facturas_contado"
        Me.txt_facturas_contado.ReadOnly = True
        Me.txt_facturas_contado.Size = New System.Drawing.Size(80, 24)
        Me.txt_facturas_contado.TabIndex = 313
        Me.txt_facturas_contado.TabStop = False
        Me.txt_facturas_contado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grilla_libro_compras
        '
        Me.grilla_libro_compras.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_libro_compras.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grilla_libro_compras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla_libro_compras.DefaultCellStyle = DataGridViewCellStyle2
        Me.grilla_libro_compras.Location = New System.Drawing.Point(6, 147)
        Me.grilla_libro_compras.Name = "grilla_libro_compras"
        Me.grilla_libro_compras.ReadOnly = True
        Me.grilla_libro_compras.Size = New System.Drawing.Size(1006, 546)
        Me.grilla_libro_compras.TabIndex = 314
        Me.grilla_libro_compras.TabStop = False
        '
        'txt_boletas_cantidad
        '
        Me.txt_boletas_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_boletas_cantidad.Location = New System.Drawing.Point(20, 57)
        Me.txt_boletas_cantidad.Name = "txt_boletas_cantidad"
        Me.txt_boletas_cantidad.ReadOnly = True
        Me.txt_boletas_cantidad.Size = New System.Drawing.Size(80, 24)
        Me.txt_boletas_cantidad.TabIndex = 316
        Me.txt_boletas_cantidad.TabStop = False
        Me.txt_boletas_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_facturas_cantidad
        '
        Me.txt_facturas_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_facturas_cantidad.Location = New System.Drawing.Point(20, 27)
        Me.txt_facturas_cantidad.Name = "txt_facturas_cantidad"
        Me.txt_facturas_cantidad.ReadOnly = True
        Me.txt_facturas_cantidad.Size = New System.Drawing.Size(80, 24)
        Me.txt_facturas_cantidad.TabIndex = 315
        Me.txt_facturas_cantidad.TabStop = False
        Me.txt_facturas_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_guias_cantidad
        '
        Me.txt_guias_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_guias_cantidad.Location = New System.Drawing.Point(20, 87)
        Me.txt_guias_cantidad.Name = "txt_guias_cantidad"
        Me.txt_guias_cantidad.ReadOnly = True
        Me.txt_guias_cantidad.Size = New System.Drawing.Size(80, 24)
        Me.txt_guias_cantidad.TabIndex = 318
        Me.txt_guias_cantidad.TabStop = False
        Me.txt_guias_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'combo_sucursal
        '
        Me.combo_sucursal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_sucursal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_sucursal.BackColor = System.Drawing.SystemColors.Window
        Me.combo_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_sucursal.ForeColor = System.Drawing.Color.Black
        Me.combo_sucursal.FormattingEnabled = True
        Me.combo_sucursal.Location = New System.Drawing.Point(8, 25)
        Me.combo_sucursal.Name = "combo_sucursal"
        Me.combo_sucursal.Size = New System.Drawing.Size(250, 26)
        Me.combo_sucursal.TabIndex = 8
        '
        'GroupBox_tipo_venta
        '
        Me.GroupBox_tipo_venta.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_tipo_venta.Controls.Add(Me.combo_sucursal)
        Me.GroupBox_tipo_venta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_tipo_venta.Location = New System.Drawing.Point(318, 77)
        Me.GroupBox_tipo_venta.Name = "GroupBox_tipo_venta"
        Me.GroupBox_tipo_venta.Size = New System.Drawing.Size(266, 65)
        Me.GroupBox_tipo_venta.TabIndex = 3
        Me.GroupBox_tipo_venta.TabStop = False
        Me.GroupBox_tipo_venta.Text = "SUCURSAL:"
        '
        'txt_facturas_pie
        '
        Me.txt_facturas_pie.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_facturas_pie.Location = New System.Drawing.Point(20, 57)
        Me.txt_facturas_pie.Name = "txt_facturas_pie"
        Me.txt_facturas_pie.ReadOnly = True
        Me.txt_facturas_pie.Size = New System.Drawing.Size(80, 24)
        Me.txt_facturas_pie.TabIndex = 322
        Me.txt_facturas_pie.TabStop = False
        Me.txt_facturas_pie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_egresos
        '
        Me.txt_egresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_egresos.Location = New System.Drawing.Point(20, 27)
        Me.txt_egresos.Name = "txt_egresos"
        Me.txt_egresos.ReadOnly = True
        Me.txt_egresos.Size = New System.Drawing.Size(80, 24)
        Me.txt_egresos.TabIndex = 321
        Me.txt_egresos.TabStop = False
        Me.txt_egresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_guias_pie
        '
        Me.txt_guias_pie.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_guias_pie.Location = New System.Drawing.Point(20, 87)
        Me.txt_guias_pie.Name = "txt_guias_pie"
        Me.txt_guias_pie.ReadOnly = True
        Me.txt_guias_pie.Size = New System.Drawing.Size(80, 24)
        Me.txt_guias_pie.TabIndex = 320
        Me.txt_guias_pie.TabStop = False
        Me.txt_guias_pie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_boletas_pie
        '
        Me.txt_boletas_pie.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_boletas_pie.Location = New System.Drawing.Point(20, 27)
        Me.txt_boletas_pie.Name = "txt_boletas_pie"
        Me.txt_boletas_pie.ReadOnly = True
        Me.txt_boletas_pie.Size = New System.Drawing.Size(80, 24)
        Me.txt_boletas_pie.TabIndex = 319
        Me.txt_boletas_pie.TabStop = False
        Me.txt_boletas_pie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_facturas_credito
        '
        Me.txt_facturas_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_facturas_credito.Location = New System.Drawing.Point(20, 57)
        Me.txt_facturas_credito.Name = "txt_facturas_credito"
        Me.txt_facturas_credito.ReadOnly = True
        Me.txt_facturas_credito.Size = New System.Drawing.Size(80, 24)
        Me.txt_facturas_credito.TabIndex = 326
        Me.txt_facturas_credito.TabStop = False
        Me.txt_facturas_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_abonos_credito
        '
        Me.txt_abonos_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_abonos_credito.Location = New System.Drawing.Point(20, 117)
        Me.txt_abonos_credito.Name = "txt_abonos_credito"
        Me.txt_abonos_credito.ReadOnly = True
        Me.txt_abonos_credito.Size = New System.Drawing.Size(80, 24)
        Me.txt_abonos_credito.TabIndex = 325
        Me.txt_abonos_credito.TabStop = False
        Me.txt_abonos_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_guias_credito
        '
        Me.txt_guias_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_guias_credito.Location = New System.Drawing.Point(20, 87)
        Me.txt_guias_credito.Name = "txt_guias_credito"
        Me.txt_guias_credito.ReadOnly = True
        Me.txt_guias_credito.Size = New System.Drawing.Size(80, 24)
        Me.txt_guias_credito.TabIndex = 324
        Me.txt_guias_credito.TabStop = False
        Me.txt_guias_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_boletas_credito
        '
        Me.txt_boletas_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_boletas_credito.Location = New System.Drawing.Point(20, 27)
        Me.txt_boletas_credito.Name = "txt_boletas_credito"
        Me.txt_boletas_credito.ReadOnly = True
        Me.txt_boletas_credito.Size = New System.Drawing.Size(80, 24)
        Me.txt_boletas_credito.TabIndex = 323
        Me.txt_boletas_credito.TabStop = False
        Me.txt_boletas_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txt_ndc_contado)
        Me.GroupBox1.Controls.Add(Me.txt_boletas_contado)
        Me.GroupBox1.Controls.Add(Me.txt_guias_contado)
        Me.GroupBox1.Controls.Add(Me.txt_abonos_contado)
        Me.GroupBox1.Controls.Add(Me.txt_facturas_contado)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(281, 224)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(121, 184)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CONTADO:"
        '
        'txt_ndc_contado
        '
        Me.txt_ndc_contado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ndc_contado.Location = New System.Drawing.Point(20, 147)
        Me.txt_ndc_contado.Name = "txt_ndc_contado"
        Me.txt_ndc_contado.ReadOnly = True
        Me.txt_ndc_contado.Size = New System.Drawing.Size(80, 24)
        Me.txt_ndc_contado.TabIndex = 314
        Me.txt_ndc_contado.TabStop = False
        Me.txt_ndc_contado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txt_ndc_credito)
        Me.GroupBox5.Controls.Add(Me.txt_boletas_credito)
        Me.GroupBox5.Controls.Add(Me.txt_guias_credito)
        Me.GroupBox5.Controls.Add(Me.txt_facturas_credito)
        Me.GroupBox5.Controls.Add(Me.txt_abonos_credito)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(535, 224)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(121, 184)
        Me.GroupBox5.TabIndex = 314
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "CREDITO:"
        '
        'txt_ndc_credito
        '
        Me.txt_ndc_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ndc_credito.Location = New System.Drawing.Point(20, 147)
        Me.txt_ndc_credito.Name = "txt_ndc_credito"
        Me.txt_ndc_credito.ReadOnly = True
        Me.txt_ndc_credito.Size = New System.Drawing.Size(80, 24)
        Me.txt_ndc_credito.TabIndex = 327
        Me.txt_ndc_credito.TabStop = False
        Me.txt_ndc_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.txt_facturas_pie)
        Me.GroupBox6.Controls.Add(Me.txt_boletas_pie)
        Me.GroupBox6.Controls.Add(Me.txt_guias_pie)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(662, 224)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(121, 184)
        Me.GroupBox6.TabIndex = 327
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "PIE:"
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.Controls.Add(Me.txt_ndc_cantidad)
        Me.GroupBox7.Controls.Add(Me.txt_boletas_cantidad)
        Me.GroupBox7.Controls.Add(Me.txt_facturas_cantidad)
        Me.GroupBox7.Controls.Add(Me.txt_guias_cantidad)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(408, 224)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(121, 184)
        Me.GroupBox7.TabIndex = 328
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "CANTIDAD:"
        '
        'txt_ndc_cantidad
        '
        Me.txt_ndc_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ndc_cantidad.Location = New System.Drawing.Point(20, 117)
        Me.txt_ndc_cantidad.Name = "txt_ndc_cantidad"
        Me.txt_ndc_cantidad.ReadOnly = True
        Me.txt_ndc_cantidad.Size = New System.Drawing.Size(80, 24)
        Me.txt_ndc_cantidad.TabIndex = 319
        Me.txt_ndc_cantidad.TabStop = False
        Me.txt_ndc_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox8.Controls.Add(Me.txt_egresos)
        Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(789, 224)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(121, 184)
        Me.GroupBox8.TabIndex = 328
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "EGRESOS:"
        '
        'txt_total_efectivo
        '
        Me.txt_total_efectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_efectivo.Location = New System.Drawing.Point(510, 358)
        Me.txt_total_efectivo.Name = "txt_total_efectivo"
        Me.txt_total_efectivo.ReadOnly = True
        Me.txt_total_efectivo.Size = New System.Drawing.Size(30, 24)
        Me.txt_total_efectivo.TabIndex = 329
        Me.txt_total_efectivo.TabStop = False
        Me.txt_total_efectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_cheque_al_dia
        '
        Me.txt_total_cheque_al_dia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_cheque_al_dia.Location = New System.Drawing.Point(510, 388)
        Me.txt_total_cheque_al_dia.Name = "txt_total_cheque_al_dia"
        Me.txt_total_cheque_al_dia.ReadOnly = True
        Me.txt_total_cheque_al_dia.Size = New System.Drawing.Size(52, 24)
        Me.txt_total_cheque_al_dia.TabIndex = 330
        Me.txt_total_cheque_al_dia.TabStop = False
        Me.txt_total_cheque_al_dia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Form_resumen_caja_diaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 699)
        Me.Controls.Add(Me.grilla_libro_compras)
        Me.Controls.Add(Me.txt_total_cheque_al_dia)
        Me.Controls.Add(Me.txt_total_efectivo)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtp_ingresar)
        Me.Controls.Add(Me.GroupBox_tipo_venta)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_resumen_caja_diaria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RESUMEN DE CAJA DIARIA"
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grilla_libro_compras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_tipo_venta.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_mostrar As System.Windows.Forms.Button
    Friend WithEvents btn_exportar_excel As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_ingresar As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_boletas_contado As System.Windows.Forms.TextBox
    Friend WithEvents txt_guias_contado As System.Windows.Forms.TextBox
    Friend WithEvents txt_abonos_contado As System.Windows.Forms.TextBox
    Friend WithEvents txt_facturas_contado As System.Windows.Forms.TextBox
    Friend WithEvents grilla_libro_compras As System.Windows.Forms.DataGridView
    Friend WithEvents txt_boletas_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents txt_facturas_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents txt_guias_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents combo_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox_tipo_venta As System.Windows.Forms.GroupBox
    Friend WithEvents txt_facturas_pie As System.Windows.Forms.TextBox
    Friend WithEvents txt_egresos As System.Windows.Forms.TextBox
    Friend WithEvents txt_guias_pie As System.Windows.Forms.TextBox
    Friend WithEvents txt_boletas_pie As System.Windows.Forms.TextBox
    Friend WithEvents txt_facturas_credito As System.Windows.Forms.TextBox
    Friend WithEvents txt_abonos_credito As System.Windows.Forms.TextBox
    Friend WithEvents txt_guias_credito As System.Windows.Forms.TextBox
    Friend WithEvents txt_boletas_credito As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_ndc_contado As System.Windows.Forms.TextBox
    Friend WithEvents txt_ndc_credito As System.Windows.Forms.TextBox
    Friend WithEvents txt_ndc_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_efectivo As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_cheque_al_dia As System.Windows.Forms.TextBox
End Class
