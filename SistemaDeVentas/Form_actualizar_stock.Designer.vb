<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_actualizar_stock
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_actualizar_stock))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lbl_mensaje = New System.Windows.Forms.Label
        Me.lbl_resultado = New System.Windows.Forms.Label
        Me.grilla_buscador_productos = New System.Windows.Forms.DataGridView
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox_tipo_venta = New System.Windows.Forms.GroupBox
        Me.txt_descripcion = New System.Windows.Forms.TextBox
        Me.Combo_descripcion = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_numero_tecnico = New System.Windows.Forms.TextBox
        Me.Combo_numero_tecnico = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_aplicacion = New System.Windows.Forms.TextBox
        Me.Combo_aplicacion = New System.Windows.Forms.ComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txt_proveedor = New System.Windows.Forms.TextBox
        Me.Combo_proveedor = New System.Windows.Forms.ComboBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txt_busqueda = New System.Windows.Forms.TextBox
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.grilla_stock = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TextBoxuno = New System.Windows.Forms.TextBox
        CType(Me.grilla_buscador_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_tipo_venta.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.grilla_stock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(307, 2)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(711, 81)
        Me.lbl_mensaje.TabIndex = 315
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'lbl_resultado
        '
        Me.lbl_resultado.BackColor = System.Drawing.Color.Transparent
        Me.lbl_resultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_resultado.Location = New System.Drawing.Point(307, 15)
        Me.lbl_resultado.Name = "lbl_resultado"
        Me.lbl_resultado.Size = New System.Drawing.Size(709, 30)
        Me.lbl_resultado.TabIndex = 318
        Me.lbl_resultado.Text = "SE ENCONTRARON 0 RESULTADOS"
        Me.lbl_resultado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_resultado.Visible = False
        '
        'grilla_buscador_productos
        '
        Me.grilla_buscador_productos.AllowUserToAddRows = False
        Me.grilla_buscador_productos.AllowUserToDeleteRows = False
        Me.grilla_buscador_productos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_buscador_productos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grilla_buscador_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla_buscador_productos.DefaultCellStyle = DataGridViewCellStyle2
        Me.grilla_buscador_productos.Enabled = False
        Me.grilla_buscador_productos.Location = New System.Drawing.Point(6, 220)
        Me.grilla_buscador_productos.Name = "grilla_buscador_productos"
        Me.grilla_buscador_productos.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_buscador_productos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grilla_buscador_productos.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grilla_buscador_productos.Size = New System.Drawing.Size(1006, 470)
        Me.grilla_buscador_productos.TabIndex = 313
        Me.grilla_buscador_productos.TabStop = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 314
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox_tipo_venta
        '
        Me.GroupBox_tipo_venta.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_tipo_venta.Controls.Add(Me.txt_descripcion)
        Me.GroupBox_tipo_venta.Controls.Add(Me.Combo_descripcion)
        Me.GroupBox_tipo_venta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_tipo_venta.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox_tipo_venta.Name = "GroupBox_tipo_venta"
        Me.GroupBox_tipo_venta.Size = New System.Drawing.Size(246, 82)
        Me.GroupBox_tipo_venta.TabIndex = 1
        Me.GroupBox_tipo_venta.TabStop = False
        Me.GroupBox_tipo_venta.Text = "DESCRIPCION"
        '
        'txt_descripcion
        '
        Me.txt_descripcion.BackColor = System.Drawing.Color.White
        Me.txt_descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descripcion.Location = New System.Drawing.Point(7, 50)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.Size = New System.Drawing.Size(232, 24)
        Me.txt_descripcion.TabIndex = 2
        '
        'Combo_descripcion
        '
        Me.Combo_descripcion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_descripcion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_descripcion.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_descripcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_descripcion.ForeColor = System.Drawing.Color.Black
        Me.Combo_descripcion.FormattingEnabled = True
        Me.Combo_descripcion.Items.AddRange(New Object() {"-", "COMIENZA POR", "NO COMIENZA POR", "TERMINA CON", "NO TERMINA CON", "CONTIENE", "NO CONTIENE"})
        Me.Combo_descripcion.Location = New System.Drawing.Point(7, 19)
        Me.Combo_descripcion.Name = "Combo_descripcion"
        Me.Combo_descripcion.Size = New System.Drawing.Size(147, 24)
        Me.Combo_descripcion.TabIndex = 11
        Me.Combo_descripcion.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txt_numero_tecnico)
        Me.GroupBox1.Controls.Add(Me.Combo_numero_tecnico)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(258, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(246, 82)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "NUMERO TECNICO"
        '
        'txt_numero_tecnico
        '
        Me.txt_numero_tecnico.BackColor = System.Drawing.Color.White
        Me.txt_numero_tecnico.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numero_tecnico.Location = New System.Drawing.Point(7, 50)
        Me.txt_numero_tecnico.Name = "txt_numero_tecnico"
        Me.txt_numero_tecnico.Size = New System.Drawing.Size(232, 24)
        Me.txt_numero_tecnico.TabIndex = 2
        '
        'Combo_numero_tecnico
        '
        Me.Combo_numero_tecnico.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_numero_tecnico.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_numero_tecnico.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_numero_tecnico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_numero_tecnico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_numero_tecnico.ForeColor = System.Drawing.Color.Black
        Me.Combo_numero_tecnico.FormattingEnabled = True
        Me.Combo_numero_tecnico.Items.AddRange(New Object() {"-", "COMIENZA POR", "NO COMIENZA POR", "TERMINA CON", "NO TERMINA CON", "CONTIENE", "NO CONTIENE"})
        Me.Combo_numero_tecnico.Location = New System.Drawing.Point(7, 19)
        Me.Combo_numero_tecnico.Name = "Combo_numero_tecnico"
        Me.Combo_numero_tecnico.Size = New System.Drawing.Size(147, 24)
        Me.Combo_numero_tecnico.TabIndex = 11
        Me.Combo_numero_tecnico.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txt_aplicacion)
        Me.GroupBox2.Controls.Add(Me.Combo_aplicacion)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(510, 77)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(248, 82)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "APLICACION"
        '
        'txt_aplicacion
        '
        Me.txt_aplicacion.BackColor = System.Drawing.Color.White
        Me.txt_aplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_aplicacion.Location = New System.Drawing.Point(7, 50)
        Me.txt_aplicacion.Name = "txt_aplicacion"
        Me.txt_aplicacion.Size = New System.Drawing.Size(234, 24)
        Me.txt_aplicacion.TabIndex = 2
        '
        'Combo_aplicacion
        '
        Me.Combo_aplicacion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_aplicacion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_aplicacion.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_aplicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_aplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_aplicacion.ForeColor = System.Drawing.Color.Black
        Me.Combo_aplicacion.FormattingEnabled = True
        Me.Combo_aplicacion.Items.AddRange(New Object() {"-", "COMIENZA POR", "NO COMIENZA POR", "TERMINA CON", "NO TERMINA CON", "CONTIENE", "NO CONTIENE"})
        Me.Combo_aplicacion.Location = New System.Drawing.Point(7, 19)
        Me.Combo_aplicacion.Name = "Combo_aplicacion"
        Me.Combo_aplicacion.Size = New System.Drawing.Size(147, 24)
        Me.Combo_aplicacion.TabIndex = 11
        Me.Combo_aplicacion.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.txt_proveedor)
        Me.GroupBox3.Controls.Add(Me.Combo_proveedor)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(764, 77)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(248, 82)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "PROVEEDOR"
        '
        'txt_proveedor
        '
        Me.txt_proveedor.BackColor = System.Drawing.Color.White
        Me.txt_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_proveedor.Location = New System.Drawing.Point(7, 50)
        Me.txt_proveedor.Name = "txt_proveedor"
        Me.txt_proveedor.Size = New System.Drawing.Size(234, 24)
        Me.txt_proveedor.TabIndex = 2
        '
        'Combo_proveedor
        '
        Me.Combo_proveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_proveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_proveedor.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_proveedor.ForeColor = System.Drawing.Color.Black
        Me.Combo_proveedor.FormattingEnabled = True
        Me.Combo_proveedor.Items.AddRange(New Object() {"-", "COMIENZA POR", "NO COMIENZA POR", "TERMINA CON", "NO TERMINA CON", "CONTIENE", "NO CONTIENE"})
        Me.Combo_proveedor.Location = New System.Drawing.Point(7, 19)
        Me.Combo_proveedor.Name = "Combo_proveedor"
        Me.Combo_proveedor.Size = New System.Drawing.Size(147, 24)
        Me.Combo_proveedor.TabIndex = 11
        Me.Combo_proveedor.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.txt_busqueda)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(6, 159)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(952, 56)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "BUSQUEDA"
        '
        'txt_busqueda
        '
        Me.txt_busqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_busqueda.Location = New System.Drawing.Point(7, 22)
        Me.txt_busqueda.Name = "txt_busqueda"
        Me.txt_busqueda.Size = New System.Drawing.Size(938, 22)
        Me.txt_busqueda.TabIndex = 1
        '
        'btn_buscar
        '
        Me.btn_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_buscar.Image = CType(resources.GetObject("btn_buscar.Image"), System.Drawing.Image)
        Me.btn_buscar.Location = New System.Drawing.Point(963, 164)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(50, 50)
        Me.btn_buscar.TabIndex = 6
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'grilla_stock
        '
        Me.grilla_stock.AllowUserToAddRows = False
        Me.grilla_stock.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_stock.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grilla_stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_stock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column14, Me.Column15, Me.Column8, Me.Column4, Me.Column13, Me.Column6, Me.Column5, Me.Column7})
        Me.grilla_stock.Location = New System.Drawing.Point(6, 220)
        Me.grilla_stock.Name = "grilla_stock"
        Me.grilla_stock.Size = New System.Drawing.Size(1006, 474)
        Me.grilla_stock.TabIndex = 237
        '
        'Column1
        '
        Me.Column1.HeaderText = "CODIGO"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 74
        '
        'Column2
        '
        Me.Column2.HeaderText = "DESCRIPCION"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 105
        '
        'Column3
        '
        Me.Column3.HeaderText = "NUMERO TECNICO"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 119
        '
        'Column14
        '
        Me.Column14.HeaderText = "APLICACION"
        Me.Column14.Name = "Column14"
        Me.Column14.Width = 95
        '
        'Column15
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Column15.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column15.HeaderText = "STOCK FISICO"
        Me.Column15.Name = "Column15"
        Me.Column15.Width = 97
        '
        'Column8
        '
        Me.Column8.HeaderText = "STOCK FISICO REAL"
        Me.Column8.Name = "Column8"
        '
        'Column4
        '
        Me.Column4.HeaderText = "STOCK PC"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 79
        '
        'Column13
        '
        Me.Column13.HeaderText = "PRECIO"
        Me.Column13.Name = "Column13"
        Me.Column13.Width = 72
        '
        'Column6
        '
        Me.Column6.HeaderText = "PROVEEDOR"
        Me.Column6.Name = "Column6"
        '
        'Column5
        '
        Me.Column5.HeaderText = "ULT. COMP."
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 86
        '
        'Column7
        '
        Me.Column7.HeaderText = "CANT. ULT. COMP."
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 117
        '
        'TextBoxuno
        '
        Me.TextBoxuno.BackColor = System.Drawing.Color.White
        Me.TextBoxuno.Enabled = False
        Me.TextBoxuno.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxuno.Location = New System.Drawing.Point(658, 313)
        Me.TextBoxuno.Name = "TextBoxuno"
        Me.TextBoxuno.Size = New System.Drawing.Size(74, 24)
        Me.TextBoxuno.TabIndex = 12
        '
        'Form_actualizar_stock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 700)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.grilla_stock)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.GroupBox_tipo_venta)
        Me.Controls.Add(Me.lbl_resultado)
        Me.Controls.Add(Me.grilla_buscador_productos)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.TextBoxuno)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_actualizar_stock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ACTUALIZAR STOCK"
        CType(Me.grilla_buscador_productos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_tipo_venta.ResumeLayout(False)
        Me.GroupBox_tipo_venta.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.grilla_stock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents lbl_resultado As System.Windows.Forms.Label
    Friend WithEvents grilla_buscador_productos As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox_tipo_venta As System.Windows.Forms.GroupBox
    Friend WithEvents txt_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Combo_descripcion As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_numero_tecnico As System.Windows.Forms.TextBox
    Friend WithEvents Combo_numero_tecnico As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_aplicacion As System.Windows.Forms.TextBox
    Friend WithEvents Combo_aplicacion As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Combo_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_busqueda As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents grilla_stock As System.Windows.Forms.DataGridView
    Friend WithEvents TextBoxuno As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
