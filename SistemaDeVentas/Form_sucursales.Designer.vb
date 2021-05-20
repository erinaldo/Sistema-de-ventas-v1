<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_sucursales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_sucursales))
        Me.GroupBox_detalle_remuneracion = New System.Windows.Forms.GroupBox()
        Me.txt_sucursal = New System.Windows.Forms.TextBox()
        Me.txt_ciudad = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grilla_forma_de_pago = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_quitar_entrada_remuneracion = New System.Windows.Forms.Button()
        Me.btn_agregar_entrada_remuneracion = New System.Windows.Forms.Button()
        Me.lbl_mensaje = New System.Windows.Forms.Label()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.GroupBox_detalle_remuneracion.SuspendLayout()
        CType(Me.grilla_forma_de_pago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox_detalle_remuneracion
        '
        Me.GroupBox_detalle_remuneracion.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_detalle_remuneracion.Controls.Add(Me.txt_sucursal)
        Me.GroupBox_detalle_remuneracion.Controls.Add(Me.txt_ciudad)
        Me.GroupBox_detalle_remuneracion.Controls.Add(Me.CheckBox1)
        Me.GroupBox_detalle_remuneracion.Controls.Add(Me.Label2)
        Me.GroupBox_detalle_remuneracion.Controls.Add(Me.Label1)
        Me.GroupBox_detalle_remuneracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_detalle_remuneracion.Location = New System.Drawing.Point(6, 78)
        Me.GroupBox_detalle_remuneracion.Name = "GroupBox_detalle_remuneracion"
        Me.GroupBox_detalle_remuneracion.Size = New System.Drawing.Size(730, 65)
        Me.GroupBox_detalle_remuneracion.TabIndex = 349
        Me.GroupBox_detalle_remuneracion.TabStop = False
        Me.GroupBox_detalle_remuneracion.Text = "DATOS:"
        '
        'txt_sucursal
        '
        Me.txt_sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_sucursal.Location = New System.Drawing.Point(7, 32)
        Me.txt_sucursal.MaxLength = 45
        Me.txt_sucursal.Name = "txt_sucursal"
        Me.txt_sucursal.Size = New System.Drawing.Size(294, 24)
        Me.txt_sucursal.TabIndex = 347
        '
        'txt_ciudad
        '
        Me.txt_ciudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ciudad.Location = New System.Drawing.Point(307, 32)
        Me.txt_ciudad.MaxLength = 45
        Me.txt_ciudad.Name = "txt_ciudad"
        Me.txt_ciudad.Size = New System.Drawing.Size(294, 24)
        Me.txt_ciudad.TabIndex = 2
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(607, 34)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(118, 21)
        Me.CheckBox1.TabIndex = 346
        Me.CheckBox1.Text = "CASA MATRIZ"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(303, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 17)
        Me.Label2.TabIndex = 345
        Me.Label2.Text = "CIUDAD:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 17)
        Me.Label1.TabIndex = 153
        Me.Label1.Text = "SUCURSAL:"
        '
        'grilla_forma_de_pago
        '
        Me.grilla_forma_de_pago.AllowUserToAddRows = False
        Me.grilla_forma_de_pago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grilla_forma_de_pago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_forma_de_pago.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column3, Me.Column1})
        Me.grilla_forma_de_pago.Location = New System.Drawing.Point(6, 195)
        Me.grilla_forma_de_pago.Name = "grilla_forma_de_pago"
        Me.grilla_forma_de_pago.ReadOnly = True
        Me.grilla_forma_de_pago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grilla_forma_de_pago.Size = New System.Drawing.Size(730, 249)
        Me.grilla_forma_de_pago.TabIndex = 348
        Me.grilla_forma_de_pago.TabStop = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "SUCURSAL"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "CIUDAD"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "TIPO"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'btn_quitar_entrada_remuneracion
        '
        Me.btn_quitar_entrada_remuneracion.BackColor = System.Drawing.Color.Transparent
        Me.btn_quitar_entrada_remuneracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_quitar_entrada_remuneracion.Image = CType(resources.GetObject("btn_quitar_entrada_remuneracion.Image"), System.Drawing.Image)
        Me.btn_quitar_entrada_remuneracion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_quitar_entrada_remuneracion.Location = New System.Drawing.Point(634, 149)
        Me.btn_quitar_entrada_remuneracion.Name = "btn_quitar_entrada_remuneracion"
        Me.btn_quitar_entrada_remuneracion.Size = New System.Drawing.Size(95, 40)
        Me.btn_quitar_entrada_remuneracion.TabIndex = 345
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
        Me.btn_agregar_entrada_remuneracion.Location = New System.Drawing.Point(534, 149)
        Me.btn_agregar_entrada_remuneracion.Name = "btn_agregar_entrada_remuneracion"
        Me.btn_agregar_entrada_remuneracion.Size = New System.Drawing.Size(95, 40)
        Me.btn_agregar_entrada_remuneracion.TabIndex = 344
        Me.btn_agregar_entrada_remuneracion.Text = "AGREGAR"
        Me.btn_agregar_entrada_remuneracion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_agregar_entrada_remuneracion.UseVisualStyleBackColor = False
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(308, 2)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(433, 82)
        Me.lbl_mensaje.TabIndex = 347
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
        Me.PictureBox_logo.TabIndex = 346
        Me.PictureBox_logo.TabStop = False
        '
        'Form_sucursales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 450)
        Me.Controls.Add(Me.GroupBox_detalle_remuneracion)
        Me.Controls.Add(Me.grilla_forma_de_pago)
        Me.Controls.Add(Me.btn_quitar_entrada_remuneracion)
        Me.Controls.Add(Me.btn_agregar_entrada_remuneracion)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form_sucursales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SUCURSALES"
        Me.GroupBox_detalle_remuneracion.ResumeLayout(False)
        Me.GroupBox_detalle_remuneracion.PerformLayout()
        CType(Me.grilla_forma_de_pago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox_detalle_remuneracion As GroupBox
    Friend WithEvents txt_ciudad As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents grilla_forma_de_pago As DataGridView
    Friend WithEvents btn_quitar_entrada_remuneracion As Button
    Friend WithEvents btn_agregar_entrada_remuneracion As Button
    Friend WithEvents lbl_mensaje As Label
    Friend WithEvents PictureBox_logo As PictureBox
    Friend WithEvents txt_sucursal As TextBox
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
End Class
