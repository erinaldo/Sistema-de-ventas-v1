<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_enviar_documento
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
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_enviar_documento))
        Me.grilla_detalle = New System.Windows.Forms.DataGridView
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Preciocosto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Desc2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Desc3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Neto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Factor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Precioventa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.margen = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Radio_impresora_1 = New System.Windows.Forms.RadioButton
        Me.Radio_impresora_2 = New System.Windows.Forms.RadioButton
        Me.GroupBox_electronicas = New System.Windows.Forms.GroupBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.radio_codigo_de_barra = New System.Windows.Forms.RadioButton
        Me.radio_solo_numeros = New System.Windows.Forms.RadioButton
        Me.GroupBox_tipo = New System.Windows.Forms.GroupBox
        Me.Radio_iva = New System.Windows.Forms.RadioButton
        Me.Radio_neto = New System.Windows.Forms.RadioButton
        Me.GroupBox_valores = New System.Windows.Forms.GroupBox
        Me.txt_factor = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txt_total_producto = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txt_costo_actual = New System.Windows.Forms.TextBox
        Me.lbl_venta = New System.Windows.Forms.Label
        Me.txt_precio_venta_producto = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox_tipo_precio = New System.Windows.Forms.GroupBox
        Me.Radio_margen = New System.Windows.Forms.RadioButton
        Me.Radio_precio_venta = New System.Windows.Forms.RadioButton
        Me.txt_nro_doc = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btn_cargar = New System.Windows.Forms.Button
        Me.btn_grabar = New System.Windows.Forms.Button
        Me.GroupBox_proveedor = New System.Windows.Forms.GroupBox
        Me.txt_nombre_proveedor = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_rut_proveedor = New System.Windows.Forms.TextBox
        Me.Combo_sucursal = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Combo_vendedor = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_rut_vendedor = New System.Windows.Forms.TextBox
        Me.lbl_mensaje = New System.Windows.Forms.Label
        Me.Check_todos = New System.Windows.Forms.CheckBox
        Me.txt_total = New System.Windows.Forms.TextBox
        Me.txt_iva = New System.Windows.Forms.TextBox
        Me.txt_neto = New System.Windows.Forms.TextBox
        CType(Me.grilla_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox_electronicas.SuspendLayout()
        Me.GroupBox_tipo.SuspendLayout()
        Me.GroupBox_valores.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_tipo_precio.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox_proveedor.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grilla_detalle
        '
        Me.grilla_detalle.AllowUserToAddRows = False
        Me.grilla_detalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_detalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grilla_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_detalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Nombre, Me.Cantidad, Me.Column8, Me.Column2, Me.Preciocosto, Me.Column1, Me.Desc2, Me.Desc3, Me.Neto, Me.IVA, Me.total, Me.Factor, Me.Precioventa, Me.margen, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        Me.grilla_detalle.Location = New System.Drawing.Point(6, 166)
        Me.grilla_detalle.Name = "grilla_detalle"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_detalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grilla_detalle.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.grilla_detalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grilla_detalle.Size = New System.Drawing.Size(1006, 528)
        Me.grilla_detalle.TabIndex = 261
        Me.grilla_detalle.TabStop = False
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "CODIGO"
        Me.Codigo.Name = "Codigo"
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "NOMBRE"
        Me.Nombre.Name = "Nombre"
        '
        'Cantidad
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cantidad.HeaderText = "CANT. DOC."
        Me.Cantidad.Name = "Cantidad"
        '
        'Column8
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column8.HeaderText = "CANT. ENVIO"
        Me.Column8.Name = "Column8"
        '
        'Column2
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column2.HeaderText = "P. UNIT."
        Me.Column2.Name = "Column2"
        '
        'Preciocosto
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Preciocosto.DefaultCellStyle = DataGridViewCellStyle5
        Me.Preciocosto.HeaderText = "COSTO"
        Me.Preciocosto.Name = "Preciocosto"
        '
        'Column1
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column1.HeaderText = "DESC. 1"
        Me.Column1.Name = "Column1"
        '
        'Desc2
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Desc2.DefaultCellStyle = DataGridViewCellStyle7
        Me.Desc2.HeaderText = "DESC. 2"
        Me.Desc2.Name = "Desc2"
        '
        'Desc3
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Desc3.DefaultCellStyle = DataGridViewCellStyle8
        Me.Desc3.HeaderText = "DESC. 3"
        Me.Desc3.Name = "Desc3"
        '
        'Neto
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Neto.DefaultCellStyle = DataGridViewCellStyle9
        Me.Neto.HeaderText = "NETO"
        Me.Neto.Name = "Neto"
        Me.Neto.Visible = False
        '
        'IVA
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.IVA.DefaultCellStyle = DataGridViewCellStyle10
        Me.IVA.HeaderText = "IVA"
        Me.IVA.Name = "IVA"
        Me.IVA.Visible = False
        '
        'total
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.total.DefaultCellStyle = DataGridViewCellStyle11
        Me.total.HeaderText = "TOTAL"
        Me.total.Name = "total"
        '
        'Factor
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Factor.DefaultCellStyle = DataGridViewCellStyle12
        Me.Factor.HeaderText = "FACTOR"
        Me.Factor.Name = "Factor"
        '
        'Precioventa
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Precioventa.DefaultCellStyle = DataGridViewCellStyle13
        Me.Precioventa.HeaderText = "P. VENTA"
        Me.Precioventa.Name = "Precioventa"
        '
        'margen
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.margen.DefaultCellStyle = DataGridViewCellStyle14
        Me.margen.HeaderText = "MARGEN"
        Me.margen.Name = "margen"
        '
        'Column3
        '
        Me.Column3.HeaderText = "ESTADO"
        Me.Column3.Name = "Column3"
        Me.Column3.Visible = False
        '
        'Column4
        '
        Me.Column4.HeaderText = "P. ANT."
        Me.Column4.Name = "Column4"
        Me.Column4.Visible = False
        '
        'Column5
        '
        Me.Column5.HeaderText = "M. ANT."
        Me.Column5.Name = "Column5"
        Me.Column5.Visible = False
        '
        'Column6
        '
        Me.Column6.HeaderText = "COD. AUTO"
        Me.Column6.Name = "Column6"
        Me.Column6.Visible = False
        '
        'Column7
        '
        Me.Column7.HeaderText = "SELEC."
        Me.Column7.Name = "Column7"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Radio_impresora_1)
        Me.GroupBox2.Controls.Add(Me.Radio_impresora_2)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(475, 505)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 50)
        Me.GroupBox2.TabIndex = 280
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "IMPRESORA:"
        '
        'Radio_impresora_1
        '
        Me.Radio_impresora_1.AutoSize = True
        Me.Radio_impresora_1.BackColor = System.Drawing.Color.Transparent
        Me.Radio_impresora_1.Checked = True
        Me.Radio_impresora_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_impresora_1.Location = New System.Drawing.Point(6, 20)
        Me.Radio_impresora_1.Name = "Radio_impresora_1"
        Me.Radio_impresora_1.Size = New System.Drawing.Size(116, 20)
        Me.Radio_impresora_1.TabIndex = 1
        Me.Radio_impresora_1.TabStop = True
        Me.Radio_impresora_1.Text = "IMPRESORA 1"
        Me.Radio_impresora_1.UseVisualStyleBackColor = False
        '
        'Radio_impresora_2
        '
        Me.Radio_impresora_2.AutoSize = True
        Me.Radio_impresora_2.BackColor = System.Drawing.Color.Transparent
        Me.Radio_impresora_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_impresora_2.Location = New System.Drawing.Point(165, 20)
        Me.Radio_impresora_2.Name = "Radio_impresora_2"
        Me.Radio_impresora_2.Size = New System.Drawing.Size(116, 20)
        Me.Radio_impresora_2.TabIndex = 2
        Me.Radio_impresora_2.Text = "IMPRESORA 2"
        Me.Radio_impresora_2.UseVisualStyleBackColor = False
        '
        'GroupBox_electronicas
        '
        Me.GroupBox_electronicas.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_electronicas.Controls.Add(Me.Label29)
        Me.GroupBox_electronicas.Controls.Add(Me.radio_codigo_de_barra)
        Me.GroupBox_electronicas.Controls.Add(Me.radio_solo_numeros)
        Me.GroupBox_electronicas.Enabled = False
        Me.GroupBox_electronicas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_electronicas.Location = New System.Drawing.Point(475, 455)
        Me.GroupBox_electronicas.Name = "GroupBox_electronicas"
        Me.GroupBox_electronicas.Size = New System.Drawing.Size(300, 50)
        Me.GroupBox_electronicas.TabIndex = 279
        Me.GroupBox_electronicas.TabStop = False
        Me.GroupBox_electronicas.Text = "TIPO IMPRESION:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(-128, 18)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(84, 16)
        Me.Label29.TabIndex = 284
        Me.Label29.Text = "SUCURSAL:"
        '
        'radio_codigo_de_barra
        '
        Me.radio_codigo_de_barra.AutoSize = True
        Me.radio_codigo_de_barra.BackColor = System.Drawing.Color.Transparent
        Me.radio_codigo_de_barra.Checked = True
        Me.radio_codigo_de_barra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radio_codigo_de_barra.Location = New System.Drawing.Point(6, 20)
        Me.radio_codigo_de_barra.Name = "radio_codigo_de_barra"
        Me.radio_codigo_de_barra.Size = New System.Drawing.Size(159, 20)
        Me.radio_codigo_de_barra.TabIndex = 1
        Me.radio_codigo_de_barra.TabStop = True
        Me.radio_codigo_de_barra.Text = "CODIGOS DE BARRA"
        Me.radio_codigo_de_barra.UseVisualStyleBackColor = False
        '
        'radio_solo_numeros
        '
        Me.radio_solo_numeros.AutoSize = True
        Me.radio_solo_numeros.BackColor = System.Drawing.Color.Transparent
        Me.radio_solo_numeros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radio_solo_numeros.Location = New System.Drawing.Point(165, 20)
        Me.radio_solo_numeros.Name = "radio_solo_numeros"
        Me.radio_solo_numeros.Size = New System.Drawing.Size(134, 20)
        Me.radio_solo_numeros.TabIndex = 2
        Me.radio_solo_numeros.Text = "SOLO NUMEROS"
        Me.radio_solo_numeros.UseVisualStyleBackColor = False
        '
        'GroupBox_tipo
        '
        Me.GroupBox_tipo.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_tipo.Controls.Add(Me.Radio_iva)
        Me.GroupBox_tipo.Controls.Add(Me.Radio_neto)
        Me.GroupBox_tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_tipo.Location = New System.Drawing.Point(1154, 177)
        Me.GroupBox_tipo.Name = "GroupBox_tipo"
        Me.GroupBox_tipo.Size = New System.Drawing.Size(75, 65)
        Me.GroupBox_tipo.TabIndex = 278
        Me.GroupBox_tipo.TabStop = False
        '
        'Radio_iva
        '
        Me.Radio_iva.AutoSize = True
        Me.Radio_iva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_iva.Location = New System.Drawing.Point(8, 39)
        Me.Radio_iva.Name = "Radio_iva"
        Me.Radio_iva.Size = New System.Drawing.Size(47, 20)
        Me.Radio_iva.TabIndex = 2
        Me.Radio_iva.Text = "IVA"
        Me.Radio_iva.UseVisualStyleBackColor = True
        '
        'Radio_neto
        '
        Me.Radio_neto.AutoSize = True
        Me.Radio_neto.Checked = True
        Me.Radio_neto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_neto.Location = New System.Drawing.Point(8, 14)
        Me.Radio_neto.Name = "Radio_neto"
        Me.Radio_neto.Size = New System.Drawing.Size(64, 20)
        Me.Radio_neto.TabIndex = 1
        Me.Radio_neto.TabStop = True
        Me.Radio_neto.Text = "NETO"
        Me.Radio_neto.UseVisualStyleBackColor = True
        '
        'GroupBox_valores
        '
        Me.GroupBox_valores.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_valores.Controls.Add(Me.txt_factor)
        Me.GroupBox_valores.Controls.Add(Me.Label24)
        Me.GroupBox_valores.Controls.Add(Me.txt_total_producto)
        Me.GroupBox_valores.Controls.Add(Me.Label21)
        Me.GroupBox_valores.Controls.Add(Me.txt_costo_actual)
        Me.GroupBox_valores.Controls.Add(Me.lbl_venta)
        Me.GroupBox_valores.Controls.Add(Me.txt_precio_venta_producto)
        Me.GroupBox_valores.Controls.Add(Me.Label8)
        Me.GroupBox_valores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_valores.Location = New System.Drawing.Point(342, 406)
        Me.GroupBox_valores.Name = "GroupBox_valores"
        Me.GroupBox_valores.Size = New System.Drawing.Size(336, 65)
        Me.GroupBox_valores.TabIndex = 270
        Me.GroupBox_valores.TabStop = False
        '
        'txt_factor
        '
        Me.txt_factor.BackColor = System.Drawing.SystemColors.Control
        Me.txt_factor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_factor.Location = New System.Drawing.Point(171, 33)
        Me.txt_factor.MaxLength = 11
        Me.txt_factor.Name = "txt_factor"
        Me.txt_factor.ReadOnly = True
        Me.txt_factor.Size = New System.Drawing.Size(76, 24)
        Me.txt_factor.TabIndex = 257
        Me.txt_factor.TabStop = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(86, 15)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(55, 16)
        Me.Label24.TabIndex = 255
        Me.Label24.Text = "TOTAL:"
        '
        'txt_total_producto
        '
        Me.txt_total_producto.BackColor = System.Drawing.SystemColors.Control
        Me.txt_total_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_producto.Location = New System.Drawing.Point(89, 33)
        Me.txt_total_producto.MaxLength = 11
        Me.txt_total_producto.Name = "txt_total_producto"
        Me.txt_total_producto.ReadOnly = True
        Me.txt_total_producto.Size = New System.Drawing.Size(76, 24)
        Me.txt_total_producto.TabIndex = 2
        Me.txt_total_producto.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(4, 15)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(58, 16)
        Me.Label21.TabIndex = 253
        Me.Label21.Text = "COSTO:"
        '
        'txt_costo_actual
        '
        Me.txt_costo_actual.BackColor = System.Drawing.SystemColors.Control
        Me.txt_costo_actual.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_costo_actual.Location = New System.Drawing.Point(7, 33)
        Me.txt_costo_actual.MaxLength = 11
        Me.txt_costo_actual.Name = "txt_costo_actual"
        Me.txt_costo_actual.ReadOnly = True
        Me.txt_costo_actual.Size = New System.Drawing.Size(76, 24)
        Me.txt_costo_actual.TabIndex = 1
        Me.txt_costo_actual.TabStop = False
        '
        'lbl_venta
        '
        Me.lbl_venta.AutoSize = True
        Me.lbl_venta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_venta.Location = New System.Drawing.Point(250, 15)
        Me.lbl_venta.Name = "lbl_venta"
        Me.lbl_venta.Size = New System.Drawing.Size(57, 16)
        Me.lbl_venta.TabIndex = 0
        Me.lbl_venta.Text = "VENTA:"
        '
        'txt_precio_venta_producto
        '
        Me.txt_precio_venta_producto.BackColor = System.Drawing.SystemColors.Control
        Me.txt_precio_venta_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_precio_venta_producto.Location = New System.Drawing.Point(253, 33)
        Me.txt_precio_venta_producto.MaxLength = 11
        Me.txt_precio_venta_producto.Name = "txt_precio_venta_producto"
        Me.txt_precio_venta_producto.ReadOnly = True
        Me.txt_precio_venta_producto.Size = New System.Drawing.Size(76, 24)
        Me.txt_precio_venta_producto.TabIndex = 3
        Me.txt_precio_venta_producto.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(306, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 16)
        Me.Label8.TabIndex = 252
        Me.Label8.Text = "%"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(225, 14)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(84, 16)
        Me.Label25.TabIndex = 256
        Me.Label25.Text = "SUCURSAL:"
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 275
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox_tipo_precio
        '
        Me.GroupBox_tipo_precio.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_tipo_precio.Controls.Add(Me.Radio_margen)
        Me.GroupBox_tipo_precio.Controls.Add(Me.Radio_precio_venta)
        Me.GroupBox_tipo_precio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_tipo_precio.Location = New System.Drawing.Point(1026, 177)
        Me.GroupBox_tipo_precio.Name = "GroupBox_tipo_precio"
        Me.GroupBox_tipo_precio.Size = New System.Drawing.Size(122, 65)
        Me.GroupBox_tipo_precio.TabIndex = 260
        Me.GroupBox_tipo_precio.TabStop = False
        '
        'Radio_margen
        '
        Me.Radio_margen.AutoSize = True
        Me.Radio_margen.Checked = True
        Me.Radio_margen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_margen.Location = New System.Drawing.Point(8, 14)
        Me.Radio_margen.Name = "Radio_margen"
        Me.Radio_margen.Size = New System.Drawing.Size(85, 20)
        Me.Radio_margen.TabIndex = 0
        Me.Radio_margen.TabStop = True
        Me.Radio_margen.Text = "MARGEN"
        Me.Radio_margen.UseVisualStyleBackColor = True
        '
        'Radio_precio_venta
        '
        Me.Radio_precio_venta.AutoSize = True
        Me.Radio_precio_venta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_precio_venta.Location = New System.Drawing.Point(8, 39)
        Me.Radio_precio_venta.Name = "Radio_precio_venta"
        Me.Radio_precio_venta.Size = New System.Drawing.Size(112, 20)
        Me.Radio_precio_venta.TabIndex = 0
        Me.Radio_precio_venta.Text = "PRECIO  VTA."
        Me.Radio_precio_venta.UseVisualStyleBackColor = True
        '
        'txt_nro_doc
        '
        Me.txt_nro_doc.BackColor = System.Drawing.SystemColors.Control
        Me.txt_nro_doc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_doc.Location = New System.Drawing.Point(229, 33)
        Me.txt_nro_doc.MaxLength = 10
        Me.txt_nro_doc.Name = "txt_nro_doc"
        Me.txt_nro_doc.ReadOnly = True
        Me.txt_nro_doc.Size = New System.Drawing.Size(100, 24)
        Me.txt_nro_doc.TabIndex = 2
        Me.txt_nro_doc.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(226, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 16)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "N° DOC.:"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btn_cargar)
        Me.GroupBox4.Controls.Add(Me.btn_grabar)
        Me.GroupBox4.Location = New System.Drawing.Point(803, 78)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(209, 65)
        Me.GroupBox4.TabIndex = 276
        Me.GroupBox4.TabStop = False
        '
        'btn_cargar
        '
        Me.btn_cargar.BackColor = System.Drawing.Color.Transparent
        Me.btn_cargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cargar.Image = CType(resources.GetObject("btn_cargar.Image"), System.Drawing.Image)
        Me.btn_cargar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cargar.Location = New System.Drawing.Point(7, 15)
        Me.btn_cargar.Name = "btn_cargar"
        Me.btn_cargar.Size = New System.Drawing.Size(95, 40)
        Me.btn_cargar.TabIndex = 2
        Me.btn_cargar.TabStop = False
        Me.btn_cargar.Text = "CARGAR F9"
        Me.btn_cargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cargar.UseVisualStyleBackColor = False
        '
        'btn_grabar
        '
        Me.btn_grabar.BackColor = System.Drawing.Color.Transparent
        Me.btn_grabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_grabar.Image = CType(resources.GetObject("btn_grabar.Image"), System.Drawing.Image)
        Me.btn_grabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_grabar.Location = New System.Drawing.Point(107, 15)
        Me.btn_grabar.Name = "btn_grabar"
        Me.btn_grabar.Size = New System.Drawing.Size(95, 40)
        Me.btn_grabar.TabIndex = 3
        Me.btn_grabar.TabStop = False
        Me.btn_grabar.Text = "ENVIAR"
        Me.btn_grabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_grabar.UseVisualStyleBackColor = False
        '
        'GroupBox_proveedor
        '
        Me.GroupBox_proveedor.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_proveedor.Controls.Add(Me.txt_nro_doc)
        Me.GroupBox_proveedor.Controls.Add(Me.Label13)
        Me.GroupBox_proveedor.Controls.Add(Me.txt_nombre_proveedor)
        Me.GroupBox_proveedor.Controls.Add(Me.Label2)
        Me.GroupBox_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_proveedor.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox_proveedor.Name = "GroupBox_proveedor"
        Me.GroupBox_proveedor.Size = New System.Drawing.Size(336, 65)
        Me.GroupBox_proveedor.TabIndex = 265
        Me.GroupBox_proveedor.TabStop = False
        Me.GroupBox_proveedor.Text = "DATOS DEL DOCUMENTO:"
        '
        'txt_nombre_proveedor
        '
        Me.txt_nombre_proveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txt_nombre_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_proveedor.Location = New System.Drawing.Point(7, 33)
        Me.txt_nombre_proveedor.Name = "txt_nombre_proveedor"
        Me.txt_nombre_proveedor.ReadOnly = True
        Me.txt_nombre_proveedor.Size = New System.Drawing.Size(216, 24)
        Me.txt_nombre_proveedor.TabIndex = 0
        Me.txt_nombre_proveedor.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "PROVEEDOR:"
        '
        'txt_rut_proveedor
        '
        Me.txt_rut_proveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txt_rut_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut_proveedor.Location = New System.Drawing.Point(23, 90)
        Me.txt_rut_proveedor.Name = "txt_rut_proveedor"
        Me.txt_rut_proveedor.ReadOnly = True
        Me.txt_rut_proveedor.Size = New System.Drawing.Size(100, 24)
        Me.txt_rut_proveedor.TabIndex = 115
        Me.txt_rut_proveedor.TabStop = False
        '
        'Combo_sucursal
        '
        Me.Combo_sucursal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_sucursal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_sucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_sucursal.ForeColor = System.Drawing.Color.Black
        Me.Combo_sucursal.FormattingEnabled = True
        Me.Combo_sucursal.Location = New System.Drawing.Point(228, 32)
        Me.Combo_sucursal.Name = "Combo_sucursal"
        Me.Combo_sucursal.Size = New System.Drawing.Size(215, 26)
        Me.Combo_sucursal.TabIndex = 283
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Combo_vendedor)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_rut_vendedor)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.Combo_sucursal)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(348, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(449, 65)
        Me.GroupBox1.TabIndex = 271
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DATOS DEL ENVIO:"
        '
        'Combo_vendedor
        '
        Me.Combo_vendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_vendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_vendedor.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_vendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_vendedor.ForeColor = System.Drawing.Color.Black
        Me.Combo_vendedor.FormattingEnabled = True
        Me.Combo_vendedor.Items.AddRange(New Object() {"EFECTIVO", "CREDITO"})
        Me.Combo_vendedor.Location = New System.Drawing.Point(7, 32)
        Me.Combo_vendedor.Name = "Combo_vendedor"
        Me.Combo_vendedor.Size = New System.Drawing.Size(215, 26)
        Me.Combo_vendedor.TabIndex = 284
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(4, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 16)
        Me.Label3.TabIndex = 285
        Me.Label3.Text = "DESPACHADOR:"
        '
        'txt_rut_vendedor
        '
        Me.txt_rut_vendedor.BackColor = System.Drawing.SystemColors.Control
        Me.txt_rut_vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut_vendedor.ForeColor = System.Drawing.Color.Black
        Me.txt_rut_vendedor.Location = New System.Drawing.Point(115, 34)
        Me.txt_rut_vendedor.Name = "txt_rut_vendedor"
        Me.txt_rut_vendedor.ReadOnly = True
        Me.txt_rut_vendedor.Size = New System.Drawing.Size(95, 20)
        Me.txt_rut_vendedor.TabIndex = 286
        Me.txt_rut_vendedor.TabStop = False
        Me.txt_rut_vendedor.Text = "0"
        Me.txt_rut_vendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(307, 2)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(711, 81)
        Me.lbl_mensaje.TabIndex = 283
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'Check_todos
        '
        Me.Check_todos.AutoSize = True
        Me.Check_todos.BackColor = System.Drawing.Color.Transparent
        Me.Check_todos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_todos.Location = New System.Drawing.Point(834, 144)
        Me.Check_todos.Name = "Check_todos"
        Me.Check_todos.Size = New System.Drawing.Size(172, 20)
        Me.Check_todos.TabIndex = 284
        Me.Check_todos.TabStop = False
        Me.Check_todos.Text = "SELECCIONAR TODOS"
        Me.Check_todos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Check_todos.UseVisualStyleBackColor = False
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.SystemColors.Control
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.Location = New System.Drawing.Point(459, 232)
        Me.txt_total.MaxLength = 10
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(100, 24)
        Me.txt_total.TabIndex = 3
        Me.txt_total.TabStop = False
        '
        'txt_iva
        '
        Me.txt_iva.BackColor = System.Drawing.SystemColors.Control
        Me.txt_iva.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_iva.Location = New System.Drawing.Point(459, 293)
        Me.txt_iva.MaxLength = 10
        Me.txt_iva.Name = "txt_iva"
        Me.txt_iva.ReadOnly = True
        Me.txt_iva.Size = New System.Drawing.Size(100, 24)
        Me.txt_iva.TabIndex = 285
        Me.txt_iva.TabStop = False
        '
        'txt_neto
        '
        Me.txt_neto.BackColor = System.Drawing.SystemColors.Control
        Me.txt_neto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_neto.Location = New System.Drawing.Point(459, 269)
        Me.txt_neto.MaxLength = 10
        Me.txt_neto.Name = "txt_neto"
        Me.txt_neto.ReadOnly = True
        Me.txt_neto.Size = New System.Drawing.Size(100, 24)
        Me.txt_neto.TabIndex = 286
        Me.txt_neto.TabStop = False
        '
        'Form_enviar_documento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 700)
        Me.Controls.Add(Me.grilla_detalle)
        Me.Controls.Add(Me.txt_neto)
        Me.Controls.Add(Me.txt_iva)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.Check_todos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.GroupBox_tipo)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox_tipo_precio)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox_proveedor)
        Me.Controls.Add(Me.GroupBox_electronicas)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox_valores)
        Me.Controls.Add(Me.txt_rut_proveedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_enviar_documento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ENVIAR DOCUMENTO"
        CType(Me.grilla_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox_electronicas.ResumeLayout(False)
        Me.GroupBox_electronicas.PerformLayout()
        Me.GroupBox_tipo.ResumeLayout(False)
        Me.GroupBox_tipo.PerformLayout()
        Me.GroupBox_valores.ResumeLayout(False)
        Me.GroupBox_valores.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_tipo_precio.ResumeLayout(False)
        Me.GroupBox_tipo_precio.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox_proveedor.ResumeLayout(False)
        Me.GroupBox_proveedor.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grilla_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Radio_impresora_1 As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_impresora_2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox_electronicas As System.Windows.Forms.GroupBox
    Friend WithEvents radio_codigo_de_barra As System.Windows.Forms.RadioButton
    Friend WithEvents radio_solo_numeros As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox_tipo As System.Windows.Forms.GroupBox
    Friend WithEvents Radio_iva As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_neto As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox_valores As System.Windows.Forms.GroupBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txt_factor As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txt_total_producto As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txt_costo_actual As System.Windows.Forms.TextBox
    Friend WithEvents lbl_venta As System.Windows.Forms.Label
    Friend WithEvents txt_precio_venta_producto As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox_tipo_precio As System.Windows.Forms.GroupBox
    Friend WithEvents Radio_margen As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_precio_venta As System.Windows.Forms.RadioButton
    Friend WithEvents txt_nro_doc As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cargar As System.Windows.Forms.Button
    Friend WithEvents btn_grabar As System.Windows.Forms.Button
    Friend WithEvents GroupBox_proveedor As System.Windows.Forms.GroupBox
    Friend WithEvents txt_rut_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Combo_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents Combo_vendedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_rut_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents Check_todos As System.Windows.Forms.CheckBox
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Preciocosto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Desc2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Desc3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Neto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Factor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precioventa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents margen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents txt_iva As System.Windows.Forms.TextBox
    Friend WithEvents txt_neto As System.Windows.Forms.TextBox
End Class
