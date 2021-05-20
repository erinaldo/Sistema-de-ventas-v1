<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_stock_sucursales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_stock_sucursales))
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.grilla_stock = New System.Windows.Forms.DataGridView
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox_producto = New System.Windows.Forms.GroupBox
        Me.txt_numero_tecnico = New System.Windows.Forms.TextBox
        Me.txt_codigo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_nombre_producto = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lbl_codigo = New System.Windows.Forms.Label
        Me.txt_costo = New System.Windows.Forms.TextBox
        Me.txt_proveedor = New System.Windows.Forms.TextBox
        Me.txt_cantidad = New System.Windows.Forms.TextBox
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_stock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_producto.SuspendLayout()
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
        Me.PictureBox_logo.TabIndex = 244
        Me.PictureBox_logo.TabStop = False
        '
        'grilla_stock
        '
        Me.grilla_stock.AllowUserToAddRows = False
        Me.grilla_stock.AllowUserToDeleteRows = False
        Me.grilla_stock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_stock.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grilla_stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_stock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column8, Me.Column5})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla_stock.DefaultCellStyle = DataGridViewCellStyle2
        Me.grilla_stock.Location = New System.Drawing.Point(6, 147)
        Me.grilla_stock.Name = "grilla_stock"
        Me.grilla_stock.ReadOnly = True
        Me.grilla_stock.Size = New System.Drawing.Size(646, 174)
        Me.grilla_stock.TabIndex = 250
        Me.grilla_stock.TabStop = False
        '
        'Column8
        '
        Me.Column8.HeaderText = "SUCURSAL"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "CANTIDAD"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'GroupBox_producto
        '
        Me.GroupBox_producto.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_producto.Controls.Add(Me.txt_numero_tecnico)
        Me.GroupBox_producto.Controls.Add(Me.txt_codigo)
        Me.GroupBox_producto.Controls.Add(Me.Label5)
        Me.GroupBox_producto.Controls.Add(Me.txt_nombre_producto)
        Me.GroupBox_producto.Controls.Add(Me.Label27)
        Me.GroupBox_producto.Controls.Add(Me.Label6)
        Me.GroupBox_producto.Controls.Add(Me.lbl_codigo)
        Me.GroupBox_producto.Controls.Add(Me.txt_costo)
        Me.GroupBox_producto.Controls.Add(Me.txt_proveedor)
        Me.GroupBox_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_producto.ForeColor = System.Drawing.Color.Black
        Me.GroupBox_producto.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox_producto.Name = "GroupBox_producto"
        Me.GroupBox_producto.Size = New System.Drawing.Size(646, 65)
        Me.GroupBox_producto.TabIndex = 251
        Me.GroupBox_producto.TabStop = False
        Me.GroupBox_producto.Text = "DATOS DEL PRODUCTO:"
        '
        'txt_numero_tecnico
        '
        Me.txt_numero_tecnico.BackColor = System.Drawing.SystemColors.Control
        Me.txt_numero_tecnico.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numero_tecnico.ForeColor = System.Drawing.Color.Black
        Me.txt_numero_tecnico.Location = New System.Drawing.Point(379, 33)
        Me.txt_numero_tecnico.Name = "txt_numero_tecnico"
        Me.txt_numero_tecnico.ReadOnly = True
        Me.txt_numero_tecnico.Size = New System.Drawing.Size(260, 24)
        Me.txt_numero_tecnico.TabIndex = 0
        Me.txt_numero_tecnico.TabStop = False
        '
        'txt_codigo
        '
        Me.txt_codigo.BackColor = System.Drawing.SystemColors.Control
        Me.txt_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo.ForeColor = System.Drawing.Color.Black
        Me.txt_codigo.Location = New System.Drawing.Point(7, 33)
        Me.txt_codigo.MaxLength = 25
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.ReadOnly = True
        Me.txt_codigo.Size = New System.Drawing.Size(100, 24)
        Me.txt_codigo.TabIndex = 1
        Me.txt_codigo.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 16)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "CODIGO:"
        '
        'txt_nombre_producto
        '
        Me.txt_nombre_producto.BackColor = System.Drawing.SystemColors.Control
        Me.txt_nombre_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_producto.ForeColor = System.Drawing.Color.Black
        Me.txt_nombre_producto.Location = New System.Drawing.Point(113, 33)
        Me.txt_nombre_producto.Name = "txt_nombre_producto"
        Me.txt_nombre_producto.ReadOnly = True
        Me.txt_nombre_producto.Size = New System.Drawing.Size(260, 24)
        Me.txt_nombre_producto.TabIndex = 2
        Me.txt_nombre_producto.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(378, 15)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(88, 16)
        Me.Label27.TabIndex = 12
        Me.Label27.Text = "Nº TECNICO:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(112, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "NOMBRE:"
        '
        'lbl_codigo
        '
        Me.lbl_codigo.AutoSize = True
        Me.lbl_codigo.ForeColor = System.Drawing.Color.Black
        Me.lbl_codigo.Location = New System.Drawing.Point(30, 39)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(39, 16)
        Me.lbl_codigo.TabIndex = 0
        Me.lbl_codigo.Text = "nada"
        '
        'txt_costo
        '
        Me.txt_costo.ForeColor = System.Drawing.Color.Black
        Me.txt_costo.Location = New System.Drawing.Point(264, 33)
        Me.txt_costo.Name = "txt_costo"
        Me.txt_costo.ReadOnly = True
        Me.txt_costo.Size = New System.Drawing.Size(24, 22)
        Me.txt_costo.TabIndex = 0
        Me.txt_costo.TabStop = False
        Me.txt_costo.Visible = False
        '
        'txt_proveedor
        '
        Me.txt_proveedor.ForeColor = System.Drawing.Color.Black
        Me.txt_proveedor.Location = New System.Drawing.Point(237, 33)
        Me.txt_proveedor.Name = "txt_proveedor"
        Me.txt_proveedor.ReadOnly = True
        Me.txt_proveedor.Size = New System.Drawing.Size(24, 22)
        Me.txt_proveedor.TabIndex = 0
        Me.txt_proveedor.TabStop = False
        Me.txt_proveedor.Visible = False
        '
        'txt_cantidad
        '
        Me.txt_cantidad.BackColor = System.Drawing.SystemColors.Control
        Me.txt_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad.ForeColor = System.Drawing.Color.Black
        Me.txt_cantidad.Location = New System.Drawing.Point(387, 205)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.ReadOnly = True
        Me.txt_cantidad.Size = New System.Drawing.Size(122, 24)
        Me.txt_cantidad.TabIndex = 20
        Me.txt_cantidad.TabStop = False
        '
        'Form_stock_sucursales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 327)
        Me.Controls.Add(Me.GroupBox_producto)
        Me.Controls.Add(Me.grilla_stock)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.txt_cantidad)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_stock_sucursales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "STOCK SUCURSALES"
        Me.TopMost = True
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_stock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_producto.ResumeLayout(False)
        Me.GroupBox_producto.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents grilla_stock As System.Windows.Forms.DataGridView
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox_producto As System.Windows.Forms.GroupBox
    Friend WithEvents txt_numero_tecnico As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_nombre_producto As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl_codigo As System.Windows.Forms.Label
    Friend WithEvents txt_costo As System.Windows.Forms.TextBox
    Friend WithEvents txt_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
End Class
