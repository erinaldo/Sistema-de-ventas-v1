<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_agregar_propiedades
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_agregar_propiedades))
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_monto = New System.Windows.Forms.TextBox
        Me.grilla_propiedades = New System.Windows.Forms.DataGridView
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.btn_quitar_entrada_remuneracion = New System.Windows.Forms.Button
        Me.btn_agregar_entrada_remuneracion = New System.Windows.Forms.Button
        Me.GroupBox_nombre = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_rut = New System.Windows.Forms.ComboBox
        Me.txt_nombre_cliente = New System.Windows.Forms.TextBox
        Me.txt_direccion = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_codigo_cliente = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        CType(Me.grilla_propiedades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_nombre.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 16)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "REBAJAR:"
        '
        'txt_monto
        '
        Me.txt_monto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_monto.Location = New System.Drawing.Point(88, 155)
        Me.txt_monto.MaxLength = 11
        Me.txt_monto.Name = "txt_monto"
        Me.txt_monto.Size = New System.Drawing.Size(100, 24)
        Me.txt_monto.TabIndex = 2
        '
        'grilla_propiedades
        '
        Me.grilla_propiedades.AllowUserToAddRows = False
        Me.grilla_propiedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_propiedades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column6, Me.Column1, Me.Column4, Me.Column2})
        Me.grilla_propiedades.Location = New System.Drawing.Point(6, 193)
        Me.grilla_propiedades.Name = "grilla_propiedades"
        Me.grilla_propiedades.ReadOnly = True
        Me.grilla_propiedades.Size = New System.Drawing.Size(1006, 500)
        Me.grilla_propiedades.TabIndex = 150
        Me.grilla_propiedades.TabStop = False
        '
        'Column5
        '
        Me.Column5.HeaderText = "CODIGO"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 193
        '
        'Column6
        '
        Me.Column6.HeaderText = "RUT"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 192
        '
        'Column1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column1.HeaderText = "NOMBRE"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 193
        '
        'Column4
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column4.HeaderText = "DIRECCION"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 192
        '
        'Column2
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column2.HeaderText = "MONTO"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 193
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 151
        Me.PictureBox_logo.TabStop = False
        '
        'btn_quitar_entrada_remuneracion
        '
        Me.btn_quitar_entrada_remuneracion.BackColor = System.Drawing.Color.Transparent
        Me.btn_quitar_entrada_remuneracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_quitar_entrada_remuneracion.Image = CType(resources.GetObject("btn_quitar_entrada_remuneracion.Image"), System.Drawing.Image)
        Me.btn_quitar_entrada_remuneracion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_quitar_entrada_remuneracion.Location = New System.Drawing.Point(910, 147)
        Me.btn_quitar_entrada_remuneracion.Name = "btn_quitar_entrada_remuneracion"
        Me.btn_quitar_entrada_remuneracion.Size = New System.Drawing.Size(95, 40)
        Me.btn_quitar_entrada_remuneracion.TabIndex = 4
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
        Me.btn_agregar_entrada_remuneracion.Location = New System.Drawing.Point(810, 147)
        Me.btn_agregar_entrada_remuneracion.Name = "btn_agregar_entrada_remuneracion"
        Me.btn_agregar_entrada_remuneracion.Size = New System.Drawing.Size(95, 40)
        Me.btn_agregar_entrada_remuneracion.TabIndex = 3
        Me.btn_agregar_entrada_remuneracion.Text = "AGREGAR"
        Me.btn_agregar_entrada_remuneracion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_agregar_entrada_remuneracion.UseVisualStyleBackColor = False
        '
        'GroupBox_nombre
        '
        Me.GroupBox_nombre.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_nombre.Controls.Add(Me.Label1)
        Me.GroupBox_nombre.Controls.Add(Me.txt_rut)
        Me.GroupBox_nombre.Controls.Add(Me.txt_nombre_cliente)
        Me.GroupBox_nombre.Controls.Add(Me.txt_direccion)
        Me.GroupBox_nombre.Controls.Add(Me.Label7)
        Me.GroupBox_nombre.Controls.Add(Me.Label8)
        Me.GroupBox_nombre.Controls.Add(Me.txt_codigo_cliente)
        Me.GroupBox_nombre.Controls.Add(Me.Label9)
        Me.GroupBox_nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_nombre.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox_nombre.Name = "GroupBox_nombre"
        Me.GroupBox_nombre.Size = New System.Drawing.Size(1006, 65)
        Me.GroupBox_nombre.TabIndex = 1
        Me.GroupBox_nombre.TabStop = False
        Me.GroupBox_nombre.Text = "DATOS DEL CLIENTE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(132, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "CODIGO:"
        '
        'txt_rut
        '
        Me.txt_rut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txt_rut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut.FormattingEnabled = True
        Me.txt_rut.Location = New System.Drawing.Point(7, 33)
        Me.txt_rut.Name = "txt_rut"
        Me.txt_rut.Size = New System.Drawing.Size(122, 24)
        Me.txt_rut.TabIndex = 1
        '
        'txt_nombre_cliente
        '
        Me.txt_nombre_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_cliente.Location = New System.Drawing.Point(241, 33)
        Me.txt_nombre_cliente.Name = "txt_nombre_cliente"
        Me.txt_nombre_cliente.ReadOnly = True
        Me.txt_nombre_cliente.Size = New System.Drawing.Size(354, 24)
        Me.txt_nombre_cliente.TabIndex = 2
        Me.txt_nombre_cliente.TabStop = False
        '
        'txt_direccion
        '
        Me.txt_direccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_direccion.Location = New System.Drawing.Point(601, 33)
        Me.txt_direccion.Name = "txt_direccion"
        Me.txt_direccion.ReadOnly = True
        Me.txt_direccion.Size = New System.Drawing.Size(398, 24)
        Me.txt_direccion.TabIndex = 2
        Me.txt_direccion.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(598, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "DIRECCION:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(238, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "NOMBRE:"
        '
        'txt_codigo_cliente
        '
        Me.txt_codigo_cliente.Enabled = False
        Me.txt_codigo_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_cliente.Location = New System.Drawing.Point(135, 33)
        Me.txt_codigo_cliente.Name = "txt_codigo_cliente"
        Me.txt_codigo_cliente.ReadOnly = True
        Me.txt_codigo_cliente.Size = New System.Drawing.Size(100, 24)
        Me.txt_codigo_cliente.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 16)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "RUT:"
        '
        'Form_agregar_propiedades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 699)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox_nombre)
        Me.Controls.Add(Me.txt_monto)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.grilla_propiedades)
        Me.Controls.Add(Me.btn_quitar_entrada_remuneracion)
        Me.Controls.Add(Me.btn_agregar_entrada_remuneracion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_agregar_propiedades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENCION DE PROPIEDADES"
        CType(Me.grilla_propiedades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_nombre.ResumeLayout(False)
        Me.GroupBox_nombre.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_monto As System.Windows.Forms.TextBox
    Friend WithEvents grilla_propiedades As System.Windows.Forms.DataGridView
    Friend WithEvents btn_quitar_entrada_remuneracion As System.Windows.Forms.Button
    Friend WithEvents btn_agregar_entrada_remuneracion As System.Windows.Forms.Button
    Friend WithEvents GroupBox_nombre As System.Windows.Forms.GroupBox
    Friend WithEvents txt_rut As System.Windows.Forms.ComboBox
    Friend WithEvents txt_nombre_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_direccion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
