<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_buscador_productos_ventas
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_buscador_productos_ventas))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grilla_buscador_productos_ventas = New System.Windows.Forms.DataGridView()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txt_busqueda = New System.Windows.Forms.TextBox()
        Me.Timer_inactividad_buscar_productos_ventas = New System.Windows.Forms.Timer(Me.components)
        Me.lbl_mensaje = New System.Windows.Forms.Label()
        Me.lbl_resultado = New System.Windows.Forms.Label()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.grilla_kardex = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtp_hasta = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtp_desde = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.grilla_buscador_productos_ventas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_kardex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grilla_buscador_productos_ventas
        '
        Me.grilla_buscador_productos_ventas.AllowUserToAddRows = False
        Me.grilla_buscador_productos_ventas.AllowUserToDeleteRows = False
        Me.grilla_buscador_productos_ventas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_buscador_productos_ventas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grilla_buscador_productos_ventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla_buscador_productos_ventas.DefaultCellStyle = DataGridViewCellStyle2
        Me.grilla_buscador_productos_ventas.Location = New System.Drawing.Point(6, 138)
        Me.grilla_buscador_productos_ventas.Name = "grilla_buscador_productos_ventas"
        Me.grilla_buscador_productos_ventas.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_buscador_productos_ventas.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grilla_buscador_productos_ventas.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grilla_buscador_productos_ventas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grilla_buscador_productos_ventas.Size = New System.Drawing.Size(500, 556)
        Me.grilla_buscador_productos_ventas.TabIndex = 45
        Me.grilla_buscador_productos_ventas.TabStop = False
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.txt_busqueda)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(806, 56)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "BUSQUEDA INTELIGENTE  ( F1 )"
        '
        'txt_busqueda
        '
        Me.txt_busqueda.BackColor = System.Drawing.Color.White
        Me.txt_busqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_busqueda.Location = New System.Drawing.Point(7, 21)
        Me.txt_busqueda.Name = "txt_busqueda"
        Me.txt_busqueda.Size = New System.Drawing.Size(792, 24)
        Me.txt_busqueda.TabIndex = 1
        '
        'Timer_inactividad_buscar_productos_ventas
        '
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(307, 2)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(712, 81)
        Me.lbl_mensaje.TabIndex = 233
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'lbl_resultado
        '
        Me.lbl_resultado.BackColor = System.Drawing.Color.Transparent
        Me.lbl_resultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_resultado.Location = New System.Drawing.Point(307, 2)
        Me.lbl_resultado.Name = "lbl_resultado"
        Me.lbl_resultado.Size = New System.Drawing.Size(712, 81)
        Me.lbl_resultado.TabIndex = 302
        Me.lbl_resultado.Text = "SE ENCONTRARON 0 RESULTADOS"
        Me.lbl_resultado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_resultado.Visible = False
        '
        'btn_buscar
        '
        Me.btn_buscar.BackColor = System.Drawing.Color.Transparent
        Me.btn_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = CType(resources.GetObject("btn_buscar.Image"), System.Drawing.Image)
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_buscar.Location = New System.Drawing.Point(817, 83)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(95, 40)
        Me.btn_buscar.TabIndex = 3
        Me.btn_buscar.Text = "BUSCAR"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_buscar.UseVisualStyleBackColor = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 64
        Me.PictureBox_logo.TabStop = False
        '
        'grilla_kardex
        '
        Me.grilla_kardex.AllowUserToAddRows = False
        Me.grilla_kardex.AllowUserToDeleteRows = False
        Me.grilla_kardex.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_kardex.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grilla_kardex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla_kardex.DefaultCellStyle = DataGridViewCellStyle6
        Me.grilla_kardex.Location = New System.Drawing.Point(0, 63)
        Me.grilla_kardex.Name = "grilla_kardex"
        Me.grilla_kardex.ReadOnly = True
        Me.grilla_kardex.Size = New System.Drawing.Size(500, 500)
        Me.grilla_kardex.TabIndex = 303
        Me.grilla_kardex.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.dtp_hasta)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(131, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(125, 55)
        Me.GroupBox3.TabIndex = 305
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "HASTA:"
        '
        'dtp_hasta
        '
        Me.dtp_hasta.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_hasta.Location = New System.Drawing.Point(7, 20)
        Me.dtp_hasta.Name = "dtp_hasta"
        Me.dtp_hasta.Size = New System.Drawing.Size(111, 24)
        Me.dtp_hasta.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtp_desde)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(125, 55)
        Me.GroupBox1.TabIndex = 304
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DESDE:"
        '
        'dtp_desde
        '
        Me.dtp_desde.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_desde.Location = New System.Drawing.Point(7, 20)
        Me.dtp_desde.Name = "dtp_desde"
        Me.dtp_desde.Size = New System.Drawing.Size(111, 24)
        Me.dtp_desde.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(917, 83)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 40)
        Me.Button1.TabIndex = 306
        Me.Button1.Text = "KARDEX"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.grilla_kardex)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Location = New System.Drawing.Point(512, 131)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(503, 568)
        Me.Panel1.TabIndex = 307
        '
        'Form_buscador_productos_ventas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1018, 700)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.lbl_resultado)
        Me.Controls.Add(Me.grilla_buscador_productos_ventas)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_buscador_productos_ventas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BUSCADOR DE PRODUCTOS"
        CType(Me.grilla_buscador_productos_ventas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_kardex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grilla_buscador_productos_ventas As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_busqueda As System.Windows.Forms.TextBox
    Friend WithEvents Timer_inactividad_buscar_productos_ventas As System.Windows.Forms.Timer
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents lbl_resultado As System.Windows.Forms.Label
    Friend WithEvents grilla_kardex As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dtp_hasta As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtp_desde As DateTimePicker
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
End Class
