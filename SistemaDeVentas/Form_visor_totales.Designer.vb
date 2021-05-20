<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_visor_totales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_visor_totales))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox_tipo_venta = New System.Windows.Forms.GroupBox
        Me.combo_venta = New System.Windows.Forms.ComboBox
        Me.btn_buscar_productos = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_limpiar = New System.Windows.Forms.Button
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.grilla_estado_de_cuenta_final = New System.Windows.Forms.DataGridView
        Me.GroupBox_descuento = New System.Windows.Forms.GroupBox
        Me.txt_total = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dtp_desde = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtp_hasta = New System.Windows.Forms.DateTimePicker
        Me.GroupBox_tipo_venta.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_estado_de_cuenta_final, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_descuento.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox_tipo_venta
        '
        Me.GroupBox_tipo_venta.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_tipo_venta.Controls.Add(Me.combo_venta)
        Me.GroupBox_tipo_venta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_tipo_venta.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox_tipo_venta.Name = "GroupBox_tipo_venta"
        Me.GroupBox_tipo_venta.Size = New System.Drawing.Size(239, 49)
        Me.GroupBox_tipo_venta.TabIndex = 1
        Me.GroupBox_tipo_venta.TabStop = False
        Me.GroupBox_tipo_venta.Text = "TIPO DOCUMENTO"
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
        Me.combo_venta.Items.AddRange(New Object() {"BOLETA", "FACTURA", "GUIA"})
        Me.combo_venta.Location = New System.Drawing.Point(14, 27)
        Me.combo_venta.Name = "combo_venta"
        Me.combo_venta.Size = New System.Drawing.Size(210, 26)
        Me.combo_venta.TabIndex = 8
        '
        'btn_buscar_productos
        '
        Me.btn_buscar_productos.BackColor = System.Drawing.Color.Transparent
        Me.btn_buscar_productos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_buscar_productos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar_productos.ForeColor = System.Drawing.Color.Black
        Me.btn_buscar_productos.Image = CType(resources.GetObject("btn_buscar_productos.Image"), System.Drawing.Image)
        Me.btn_buscar_productos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_buscar_productos.Location = New System.Drawing.Point(14, 18)
        Me.btn_buscar_productos.Name = "btn_buscar_productos"
        Me.btn_buscar_productos.Size = New System.Drawing.Size(95, 40)
        Me.btn_buscar_productos.TabIndex = 1
        Me.btn_buscar_productos.Text = "BUSCAR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_buscar_productos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_buscar_productos.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btn_salir)
        Me.GroupBox4.Controls.Add(Me.btn_buscar_productos)
        Me.GroupBox4.Controls.Add(Me.btn_limpiar)
        Me.GroupBox4.Location = New System.Drawing.Point(689, 77)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(323, 49)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.ForeColor = System.Drawing.Color.Black
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(214, 18)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
        Me.btn_salir.TabIndex = 3
        Me.btn_salir.Text = "SALIR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_limpiar
        '
        Me.btn_limpiar.BackColor = System.Drawing.Color.Transparent
        Me.btn_limpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_limpiar.ForeColor = System.Drawing.Color.Black
        Me.btn_limpiar.Image = CType(resources.GetObject("btn_limpiar.Image"), System.Drawing.Image)
        Me.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_limpiar.Location = New System.Drawing.Point(114, 18)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(95, 40)
        Me.btn_limpiar.TabIndex = 2
        Me.btn_limpiar.Text = "LIMPIAR"
        Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_limpiar.UseVisualStyleBackColor = True
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 142
        Me.PictureBox_logo.TabStop = False
        '
        'grilla_estado_de_cuenta_final
        '
        Me.grilla_estado_de_cuenta_final.AllowUserToAddRows = False
        Me.grilla_estado_de_cuenta_final.AllowUserToDeleteRows = False
        Me.grilla_estado_de_cuenta_final.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_estado_de_cuenta_final.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grilla_estado_de_cuenta_final.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla_estado_de_cuenta_final.DefaultCellStyle = DataGridViewCellStyle2
        Me.grilla_estado_de_cuenta_final.Location = New System.Drawing.Point(7, 150)
        Me.grilla_estado_de_cuenta_final.Name = "grilla_estado_de_cuenta_final"
        Me.grilla_estado_de_cuenta_final.ReadOnly = True
        Me.grilla_estado_de_cuenta_final.Size = New System.Drawing.Size(1005, 544)
        Me.grilla_estado_de_cuenta_final.TabIndex = 237
        Me.grilla_estado_de_cuenta_final.TabStop = False
        '
        'GroupBox_descuento
        '
        Me.GroupBox_descuento.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_descuento.Controls.Add(Me.txt_total)
        Me.GroupBox_descuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_descuento.Location = New System.Drawing.Point(251, 77)
        Me.GroupBox_descuento.Name = "GroupBox_descuento"
        Me.GroupBox_descuento.Size = New System.Drawing.Size(140, 48)
        Me.GroupBox_descuento.TabIndex = 2
        Me.GroupBox_descuento.TabStop = False
        Me.GroupBox_descuento.Text = "TOTAL:"
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.SystemColors.Window
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.Black
        Me.txt_total.Location = New System.Drawing.Point(15, 27)
        Me.txt_total.MaxLength = 11
        Me.txt_total.Name = "txt_total"
        Me.txt_total.Size = New System.Drawing.Size(111, 24)
        Me.txt_total.TabIndex = 130
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dtp_desde)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(397, 77)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(140, 48)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DESDE:"
        '
        'dtp_desde
        '
        Me.dtp_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_desde.Location = New System.Drawing.Point(15, 27)
        Me.dtp_desde.Name = "dtp_desde"
        Me.dtp_desde.Size = New System.Drawing.Size(111, 24)
        Me.dtp_desde.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtp_hasta)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(543, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(140, 48)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "HASTA:"
        '
        'dtp_hasta
        '
        Me.dtp_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_hasta.Location = New System.Drawing.Point(15, 27)
        Me.dtp_hasta.Name = "dtp_hasta"
        Me.dtp_hasta.Size = New System.Drawing.Size(111, 24)
        Me.dtp_hasta.TabIndex = 2
        '
        'Form_visor_totales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 700)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox_descuento)
        Me.Controls.Add(Me.grilla_estado_de_cuenta_final)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox_tipo_venta)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_visor_totales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BUSCADOR DE TOTALES"
        Me.GroupBox_tipo_venta.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_estado_de_cuenta_final, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_descuento.ResumeLayout(False)
        Me.GroupBox_descuento.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox_tipo_venta As System.Windows.Forms.GroupBox
    Friend WithEvents combo_venta As System.Windows.Forms.ComboBox
    Friend WithEvents btn_buscar_productos As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents grilla_estado_de_cuenta_final As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox_descuento As System.Windows.Forms.GroupBox
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_hasta As System.Windows.Forms.DateTimePicker
End Class
