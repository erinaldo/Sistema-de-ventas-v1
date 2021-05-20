<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_forma_de_pago_por_defecto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_forma_de_pago_por_defecto))
        Me.lbl_mensaje = New System.Windows.Forms.Label()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.grilla_forma_de_pago = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_quitar_entrada_remuneracion = New System.Windows.Forms.Button()
        Me.btn_agregar_entrada_remuneracion = New System.Windows.Forms.Button()
        Me.GroupBox_detalle_remuneracion = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Combo_venta = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_nombre = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_forma_de_pago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_detalle_remuneracion.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(410, 2)
        Me.lbl_mensaje.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(577, 101)
        Me.lbl_mensaje.TabIndex = 339
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(8, 8)
        Me.PictureBox_logo.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(400, 86)
        Me.PictureBox_logo.TabIndex = 142
        Me.PictureBox_logo.TabStop = False
        '
        'grilla_forma_de_pago
        '
        Me.grilla_forma_de_pago.AllowUserToAddRows = False
        Me.grilla_forma_de_pago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grilla_forma_de_pago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_forma_de_pago.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column1, Me.Column3})
        Me.grilla_forma_de_pago.Location = New System.Drawing.Point(8, 240)
        Me.grilla_forma_de_pago.Margin = New System.Windows.Forms.Padding(4)
        Me.grilla_forma_de_pago.Name = "grilla_forma_de_pago"
        Me.grilla_forma_de_pago.ReadOnly = True
        Me.grilla_forma_de_pago.Size = New System.Drawing.Size(973, 500)
        Me.grilla_forma_de_pago.TabIndex = 342
        Me.grilla_forma_de_pago.TabStop = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "DOCUMENTO"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "FORMA DE PAGO"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "POR DEFECTO"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'btn_quitar_entrada_remuneracion
        '
        Me.btn_quitar_entrada_remuneracion.BackColor = System.Drawing.Color.Transparent
        Me.btn_quitar_entrada_remuneracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_quitar_entrada_remuneracion.Image = CType(resources.GetObject("btn_quitar_entrada_remuneracion.Image"), System.Drawing.Image)
        Me.btn_quitar_entrada_remuneracion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_quitar_entrada_remuneracion.Location = New System.Drawing.Point(846, 183)
        Me.btn_quitar_entrada_remuneracion.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_quitar_entrada_remuneracion.Name = "btn_quitar_entrada_remuneracion"
        Me.btn_quitar_entrada_remuneracion.Size = New System.Drawing.Size(127, 49)
        Me.btn_quitar_entrada_remuneracion.TabIndex = 2
        Me.btn_quitar_entrada_remuneracion.Text = "QUITAR"
        Me.btn_quitar_entrada_remuneracion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_quitar_entrada_remuneracion.UseVisualStyleBackColor = False
        '
        'btn_agregar_entrada_remuneracion
        '
        Me.btn_agregar_entrada_remuneracion.BackColor = System.Drawing.Color.Transparent
        Me.btn_agregar_entrada_remuneracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar_entrada_remuneracion.Image = CType(resources.GetObject("btn_agregar_entrada_remuneracion.Image"), System.Drawing.Image)
        Me.btn_agregar_entrada_remuneracion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_agregar_entrada_remuneracion.Location = New System.Drawing.Point(712, 183)
        Me.btn_agregar_entrada_remuneracion.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_agregar_entrada_remuneracion.Name = "btn_agregar_entrada_remuneracion"
        Me.btn_agregar_entrada_remuneracion.Size = New System.Drawing.Size(127, 49)
        Me.btn_agregar_entrada_remuneracion.TabIndex = 1
        Me.btn_agregar_entrada_remuneracion.Text = "AGREGAR"
        Me.btn_agregar_entrada_remuneracion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_agregar_entrada_remuneracion.UseVisualStyleBackColor = False
        '
        'GroupBox_detalle_remuneracion
        '
        Me.GroupBox_detalle_remuneracion.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_detalle_remuneracion.Controls.Add(Me.txt_nombre)
        Me.GroupBox_detalle_remuneracion.Controls.Add(Me.CheckBox1)
        Me.GroupBox_detalle_remuneracion.Controls.Add(Me.Label2)
        Me.GroupBox_detalle_remuneracion.Controls.Add(Me.Combo_venta)
        Me.GroupBox_detalle_remuneracion.Controls.Add(Me.Label1)
        Me.GroupBox_detalle_remuneracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_detalle_remuneracion.Location = New System.Drawing.Point(8, 96)
        Me.GroupBox_detalle_remuneracion.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_detalle_remuneracion.Name = "GroupBox_detalle_remuneracion"
        Me.GroupBox_detalle_remuneracion.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_detalle_remuneracion.Size = New System.Drawing.Size(973, 80)
        Me.GroupBox_detalle_remuneracion.TabIndex = 343
        Me.GroupBox_detalle_remuneracion.TabStop = False
        Me.GroupBox_detalle_remuneracion.Text = "DATOS:"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(809, 42)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(152, 24)
        Me.CheckBox1.TabIndex = 346
        Me.CheckBox1.Text = "POR DEFECTO"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(302, 18)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 20)
        Me.Label2.TabIndex = 345
        Me.Label2.Text = "FORMA DE PAGO:"
        '
        'Combo_venta
        '
        Me.Combo_venta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_venta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_venta.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_venta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_venta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_venta.ForeColor = System.Drawing.Color.Black
        Me.Combo_venta.FormattingEnabled = True
        Me.Combo_venta.Items.AddRange(New Object() {"BOLETA", "FACTURA", "GUIA", "COTIZACION"})
        Me.Combo_venta.Location = New System.Drawing.Point(9, 40)
        Me.Combo_venta.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_venta.Name = "Combo_venta"
        Me.Combo_venta.Size = New System.Drawing.Size(289, 28)
        Me.Combo_venta.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 20)
        Me.Label1.TabIndex = 153
        Me.Label1.Text = "DOCUMENTO:"
        '
        'txt_nombre
        '
        Me.txt_nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre.Location = New System.Drawing.Point(306, 40)
        Me.txt_nombre.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_nombre.MaxLength = 45
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(495, 29)
        Me.txt_nombre.TabIndex = 2
        '
        'Form_forma_de_pago_por_defecto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 748)
        Me.Controls.Add(Me.GroupBox_detalle_remuneracion)
        Me.Controls.Add(Me.grilla_forma_de_pago)
        Me.Controls.Add(Me.btn_quitar_entrada_remuneracion)
        Me.Controls.Add(Me.btn_agregar_entrada_remuneracion)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_forma_de_pago_por_defecto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FORMA DE PAGO POR DEFECTO"
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_forma_de_pago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_detalle_remuneracion.ResumeLayout(False)
        Me.GroupBox_detalle_remuneracion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox_logo As PictureBox
    Friend WithEvents lbl_mensaje As Label
    Friend WithEvents grilla_forma_de_pago As DataGridView
    Friend WithEvents btn_quitar_entrada_remuneracion As Button
    Friend WithEvents btn_agregar_entrada_remuneracion As Button
    Friend WithEvents GroupBox_detalle_remuneracion As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Combo_venta As ComboBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents txt_nombre As TextBox
End Class
