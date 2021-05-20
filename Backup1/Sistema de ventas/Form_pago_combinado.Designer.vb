<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_pago_combinado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_pago_combinado))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.combo_condiciones = New System.Windows.Forms.ComboBox
        Me.GroupBox_orden = New System.Windows.Forms.GroupBox
        Me.txt_monto = New System.Windows.Forms.TextBox
        Me.btn_agregar = New System.Windows.Forms.Button
        Me.btn_quitar_elemento = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_total = New System.Windows.Forms.TextBox
        Me.grilla_pago_combinado = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_total_pago = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_grabar = New System.Windows.Forms.Button
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox_orden.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grilla_pago_combinado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
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
        Me.PictureBox_logo.TabIndex = 317
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.combo_condiciones)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(226, 77)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(206, 68)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "CONDICION DE VENTA:"
        '
        'combo_condiciones
        '
        Me.combo_condiciones.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_condiciones.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_condiciones.BackColor = System.Drawing.SystemColors.Window
        Me.combo_condiciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_condiciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_condiciones.ForeColor = System.Drawing.Color.Black
        Me.combo_condiciones.FormattingEnabled = True
        Me.combo_condiciones.Items.AddRange(New Object() {"-", "EFECTIVO", "TARJETA ABCDIN", "TARJETA CENCOSUD", "TARJETA C&D", "TARJETA PRESTO", "TARJETA RYPLEY", "TARJETA CREDITO", "TARJETA VISA", "TARJETA MASTERCARD", "TARJETA BANCARIA", "TRANSFERENCIA", "CHEQUE AL DIA", "CHEQUE 15 DIAS", "CHEQUE 30 DIAS", "CHEQUE 45 DIAS", "CHEQUE 30-60 DIAS", "CHEQUE 30-60-90 DIAS"})
        Me.combo_condiciones.Location = New System.Drawing.Point(7, 24)
        Me.combo_condiciones.Name = "combo_condiciones"
        Me.combo_condiciones.Size = New System.Drawing.Size(192, 26)
        Me.combo_condiciones.TabIndex = 10
        '
        'GroupBox_orden
        '
        Me.GroupBox_orden.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_orden.Controls.Add(Me.txt_monto)
        Me.GroupBox_orden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_orden.Location = New System.Drawing.Point(116, 77)
        Me.GroupBox_orden.Name = "GroupBox_orden"
        Me.GroupBox_orden.Size = New System.Drawing.Size(104, 68)
        Me.GroupBox_orden.TabIndex = 2
        Me.GroupBox_orden.TabStop = False
        Me.GroupBox_orden.Text = "MONTO:"
        '
        'txt_monto
        '
        Me.txt_monto.BackColor = System.Drawing.Color.White
        Me.txt_monto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_monto.ForeColor = System.Drawing.Color.Black
        Me.txt_monto.Location = New System.Drawing.Point(7, 26)
        Me.txt_monto.MaxLength = 20
        Me.txt_monto.Name = "txt_monto"
        Me.txt_monto.Size = New System.Drawing.Size(90, 24)
        Me.txt_monto.TabIndex = 0
        Me.txt_monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_agregar
        '
        Me.btn_agregar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_agregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar.ForeColor = System.Drawing.Color.Black
        Me.btn_agregar.Image = CType(resources.GetObject("btn_agregar.Image"), System.Drawing.Image)
        Me.btn_agregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_agregar.Location = New System.Drawing.Point(444, 150)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(95, 40)
        Me.btn_agregar.TabIndex = 5
        Me.btn_agregar.Text = "AGREGAR"
        Me.btn_agregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'btn_quitar_elemento
        '
        Me.btn_quitar_elemento.BackColor = System.Drawing.Color.Transparent
        Me.btn_quitar_elemento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_quitar_elemento.ForeColor = System.Drawing.Color.Black
        Me.btn_quitar_elemento.Image = CType(resources.GetObject("btn_quitar_elemento.Image"), System.Drawing.Image)
        Me.btn_quitar_elemento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_quitar_elemento.Location = New System.Drawing.Point(544, 150)
        Me.btn_quitar_elemento.Name = "btn_quitar_elemento"
        Me.btn_quitar_elemento.Size = New System.Drawing.Size(95, 40)
        Me.btn_quitar_elemento.TabIndex = 6
        Me.btn_quitar_elemento.Text = "QUITAR"
        Me.btn_quitar_elemento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_quitar_elemento.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txt_total)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(104, 68)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "TOTAL:"
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.SystemColors.Control
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.Black
        Me.txt_total.Location = New System.Drawing.Point(7, 26)
        Me.txt_total.MaxLength = 20
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(90, 24)
        Me.txt_total.TabIndex = 0
        Me.txt_total.TabStop = False
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grilla_pago_combinado
        '
        Me.grilla_pago_combinado.AllowUserToAddRows = False
        Me.grilla_pago_combinado.AllowUserToDeleteRows = False
        Me.grilla_pago_combinado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_pago_combinado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grilla_pago_combinado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_pago_combinado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla_pago_combinado.DefaultCellStyle = DataGridViewCellStyle3
        Me.grilla_pago_combinado.Location = New System.Drawing.Point(6, 196)
        Me.grilla_pago_combinado.Name = "grilla_pago_combinado"
        Me.grilla_pago_combinado.ReadOnly = True
        Me.grilla_pago_combinado.Size = New System.Drawing.Size(639, 190)
        Me.grilla_pago_combinado.TabIndex = 325
        Me.grilla_pago_combinado.TabStop = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "FORMA DE PAGO"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column2.HeaderText = "MONTO"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'txt_total_pago
        '
        Me.txt_total_pago.BackColor = System.Drawing.SystemColors.Control
        Me.txt_total_pago.Enabled = False
        Me.txt_total_pago.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_pago.ForeColor = System.Drawing.Color.Black
        Me.txt_total_pago.Location = New System.Drawing.Point(335, 92)
        Me.txt_total_pago.MaxLength = 20
        Me.txt_total_pago.Name = "txt_total_pago"
        Me.txt_total_pago.ReadOnly = True
        Me.txt_total_pago.Size = New System.Drawing.Size(90, 24)
        Me.txt_total_pago.TabIndex = 1
        Me.txt_total_pago.TabStop = False
        Me.txt_total_pago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btn_salir)
        Me.GroupBox4.Controls.Add(Me.btn_grabar)
        Me.GroupBox4.Location = New System.Drawing.Point(438, 77)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(209, 68)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.ForeColor = System.Drawing.Color.Black
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(107, 16)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
        Me.btn_salir.TabIndex = 15
        Me.btn_salir.Text = "SALIR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_grabar
        '
        Me.btn_grabar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_grabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_grabar.ForeColor = System.Drawing.Color.Black
        Me.btn_grabar.Image = CType(resources.GetObject("btn_grabar.Image"), System.Drawing.Image)
        Me.btn_grabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_grabar.Location = New System.Drawing.Point(7, 16)
        Me.btn_grabar.Name = "btn_grabar"
        Me.btn_grabar.Size = New System.Drawing.Size(95, 40)
        Me.btn_grabar.TabIndex = 13
        Me.btn_grabar.Text = "IMPRIMIR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_grabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_grabar.UseVisualStyleBackColor = True
        '
        'Form_pago_combinado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 392)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox_orden)
        Me.Controls.Add(Me.grilla_pago_combinado)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_agregar)
        Me.Controls.Add(Me.btn_quitar_elemento)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.txt_total_pago)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_pago_combinado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PAGO COMBINADO"
        Me.TopMost = True
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox_orden.ResumeLayout(False)
        Me.GroupBox_orden.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grilla_pago_combinado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents combo_condiciones As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox_orden As System.Windows.Forms.GroupBox
    Friend WithEvents txt_monto As System.Windows.Forms.TextBox
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents btn_quitar_elemento As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents grilla_pago_combinado As System.Windows.Forms.DataGridView
    Friend WithEvents txt_total_pago As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_grabar As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
