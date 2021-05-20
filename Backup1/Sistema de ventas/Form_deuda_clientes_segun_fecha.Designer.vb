<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_deuda_clientes_segun_fecha
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_deuda_clientes_segun_fecha))
        Me.grilla_deuda = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbl_mensaje = New System.Windows.Forms.Label
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtp_desde = New System.Windows.Forms.DateTimePicker
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dtp_hasta = New System.Windows.Forms.DateTimePicker
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btn_mostrar = New System.Windows.Forms.Button
        Me.btn_exportar_excel = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_limpiar = New System.Windows.Forms.Button
        Me.GroupBox_totales = New System.Windows.Forms.GroupBox
        Me.lbl_3 = New System.Windows.Forms.Label
        Me.txt_total_millar = New System.Windows.Forms.TextBox
        Me.lbl_1 = New System.Windows.Forms.Label
        Me.lbl_2 = New System.Windows.Forms.Label
        Me.txt_iva_millar = New System.Windows.Forms.TextBox
        Me.txt_neto_millar = New System.Windows.Forms.TextBox
        CType(Me.grilla_deuda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox_totales.SuspendLayout()
        Me.SuspendLayout()
        '
        'grilla_deuda
        '
        Me.grilla_deuda.AllowUserToAddRows = False
        Me.grilla_deuda.AllowUserToDeleteRows = False
        Me.grilla_deuda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_deuda.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grilla_deuda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_deuda.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column3, Me.Column14, Me.Column2})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla_deuda.DefaultCellStyle = DataGridViewCellStyle3
        Me.grilla_deuda.Location = New System.Drawing.Point(6, 83)
        Me.grilla_deuda.Name = "grilla_deuda"
        Me.grilla_deuda.ReadOnly = True
        Me.grilla_deuda.Size = New System.Drawing.Size(811, 611)
        Me.grilla_deuda.TabIndex = 237
        Me.grilla_deuda.TabStop = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "RUT"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "NOMBRE"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column14
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column14.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column14.HeaderText = "DEUDA"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "SUCURSAL"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(307, 1)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(710, 81)
        Me.lbl_mensaje.TabIndex = 242
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 237
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtp_desde)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(823, 76)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(189, 65)
        Me.GroupBox1.TabIndex = 243
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DESDE:"
        '
        'dtp_desde
        '
        Me.dtp_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_desde.Location = New System.Drawing.Point(42, 24)
        Me.dtp_desde.Name = "dtp_desde"
        Me.dtp_desde.Size = New System.Drawing.Size(111, 24)
        Me.dtp_desde.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.dtp_hasta)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(823, 141)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(189, 65)
        Me.GroupBox3.TabIndex = 244
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "HASTA:"
        '
        'dtp_hasta
        '
        Me.dtp_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_hasta.Location = New System.Drawing.Point(42, 24)
        Me.dtp_hasta.Name = "dtp_hasta"
        Me.dtp_hasta.Size = New System.Drawing.Size(111, 24)
        Me.dtp_hasta.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btn_mostrar)
        Me.GroupBox4.Controls.Add(Me.btn_exportar_excel)
        Me.GroupBox4.Controls.Add(Me.btn_salir)
        Me.GroupBox4.Controls.Add(Me.btn_limpiar)
        Me.GroupBox4.Location = New System.Drawing.Point(823, 344)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(189, 350)
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
        Me.btn_mostrar.Location = New System.Drawing.Point(47, 31)
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
        Me.btn_exportar_excel.Location = New System.Drawing.Point(47, 199)
        Me.btn_exportar_excel.Name = "btn_exportar_excel"
        Me.btn_exportar_excel.Size = New System.Drawing.Size(95, 40)
        Me.btn_exportar_excel.TabIndex = 4
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
        Me.btn_salir.Location = New System.Drawing.Point(47, 283)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
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
        Me.btn_limpiar.Location = New System.Drawing.Point(47, 115)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(95, 40)
        Me.btn_limpiar.TabIndex = 3
        Me.btn_limpiar.Text = "LIMPIAR"
        Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_limpiar.UseVisualStyleBackColor = False
        '
        'GroupBox_totales
        '
        Me.GroupBox_totales.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_totales.Controls.Add(Me.lbl_3)
        Me.GroupBox_totales.Controls.Add(Me.txt_total_millar)
        Me.GroupBox_totales.Controls.Add(Me.lbl_1)
        Me.GroupBox_totales.Controls.Add(Me.lbl_2)
        Me.GroupBox_totales.Controls.Add(Me.txt_iva_millar)
        Me.GroupBox_totales.Controls.Add(Me.txt_neto_millar)
        Me.GroupBox_totales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_totales.Location = New System.Drawing.Point(823, 207)
        Me.GroupBox_totales.Name = "GroupBox_totales"
        Me.GroupBox_totales.Size = New System.Drawing.Size(189, 137)
        Me.GroupBox_totales.TabIndex = 245
        Me.GroupBox_totales.TabStop = False
        Me.GroupBox_totales.Text = "TOTALES:"
        '
        'lbl_3
        '
        Me.lbl_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_3.ForeColor = System.Drawing.Color.Black
        Me.lbl_3.Location = New System.Drawing.Point(0, 93)
        Me.lbl_3.Name = "lbl_3"
        Me.lbl_3.Size = New System.Drawing.Size(77, 20)
        Me.lbl_3.TabIndex = 131
        Me.lbl_3.Text = "TOTAL:"
        Me.lbl_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_total_millar
        '
        Me.txt_total_millar.BackColor = System.Drawing.SystemColors.Control
        Me.txt_total_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_millar.ForeColor = System.Drawing.Color.Black
        Me.txt_total_millar.Location = New System.Drawing.Point(78, 90)
        Me.txt_total_millar.Name = "txt_total_millar"
        Me.txt_total_millar.ReadOnly = True
        Me.txt_total_millar.Size = New System.Drawing.Size(90, 26)
        Me.txt_total_millar.TabIndex = 132
        Me.txt_total_millar.TabStop = False
        Me.txt_total_millar.Text = "0"
        Me.txt_total_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_1
        '
        Me.lbl_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_1.ForeColor = System.Drawing.Color.Black
        Me.lbl_1.Location = New System.Drawing.Point(0, 30)
        Me.lbl_1.Name = "lbl_1"
        Me.lbl_1.Size = New System.Drawing.Size(77, 20)
        Me.lbl_1.TabIndex = 0
        Me.lbl_1.Text = "NETO:"
        Me.lbl_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_2
        '
        Me.lbl_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_2.ForeColor = System.Drawing.Color.Black
        Me.lbl_2.Location = New System.Drawing.Point(0, 61)
        Me.lbl_2.Name = "lbl_2"
        Me.lbl_2.Size = New System.Drawing.Size(77, 20)
        Me.lbl_2.TabIndex = 0
        Me.lbl_2.Text = "IVA:"
        Me.lbl_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_iva_millar
        '
        Me.txt_iva_millar.BackColor = System.Drawing.SystemColors.Control
        Me.txt_iva_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_iva_millar.ForeColor = System.Drawing.Color.Black
        Me.txt_iva_millar.Location = New System.Drawing.Point(78, 59)
        Me.txt_iva_millar.Name = "txt_iva_millar"
        Me.txt_iva_millar.ReadOnly = True
        Me.txt_iva_millar.Size = New System.Drawing.Size(90, 24)
        Me.txt_iva_millar.TabIndex = 134
        Me.txt_iva_millar.TabStop = False
        Me.txt_iva_millar.Text = "0"
        Me.txt_iva_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_neto_millar
        '
        Me.txt_neto_millar.BackColor = System.Drawing.SystemColors.Control
        Me.txt_neto_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_neto_millar.ForeColor = System.Drawing.Color.Black
        Me.txt_neto_millar.Location = New System.Drawing.Point(78, 28)
        Me.txt_neto_millar.Name = "txt_neto_millar"
        Me.txt_neto_millar.ReadOnly = True
        Me.txt_neto_millar.Size = New System.Drawing.Size(90, 24)
        Me.txt_neto_millar.TabIndex = 133
        Me.txt_neto_millar.TabStop = False
        Me.txt_neto_millar.Text = "0"
        Me.txt_neto_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Form_deuda_clientes_segun_fecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 700)
        Me.Controls.Add(Me.GroupBox_totales)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.grilla_deuda)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_deuda_clientes_segun_fecha"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DEUDA CLIENTES"
        CType(Me.grilla_deuda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox_totales.ResumeLayout(False)
        Me.GroupBox_totales.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grilla_deuda As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_mostrar As System.Windows.Forms.Button
    Friend WithEvents btn_exportar_excel As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents GroupBox_totales As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_3 As System.Windows.Forms.Label
    Friend WithEvents txt_total_millar As System.Windows.Forms.TextBox
    Friend WithEvents lbl_1 As System.Windows.Forms.Label
    Friend WithEvents lbl_2 As System.Windows.Forms.Label
    Friend WithEvents txt_iva_millar As System.Windows.Forms.TextBox
    Friend WithEvents txt_neto_millar As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
