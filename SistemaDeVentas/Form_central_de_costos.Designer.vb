<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_central_de_costos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_central_de_costos))
        Me.lbl_mensaje = New System.Windows.Forms.Label
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.grilla_costos = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_busqueda = New System.Windows.Forms.TextBox
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.btn_exportar_excel = New System.Windows.Forms.Button
        Me.GroupBox_clientes = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_representante = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_correo_cliente = New System.Windows.Forms.TextBox
        Me.txt_rut_cliente = New System.Windows.Forms.TextBox
        Me.txt_nombre_cliente = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_comuna_cliente = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txt_giro_cliente = New System.Windows.Forms.TextBox
        Me.txt_direccion_cliente = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_telefono = New System.Windows.Forms.TextBox
        Me.txt_cod_cliente = New System.Windows.Forms.TextBox
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_costos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox_clientes.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(307, 2)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(712, 81)
        Me.lbl_mensaje.TabIndex = 302
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
        Me.PictureBox_logo.TabIndex = 301
        Me.PictureBox_logo.TabStop = False
        '
        'grilla_costos
        '
        Me.grilla_costos.AllowUserToAddRows = False
        Me.grilla_costos.AllowUserToDeleteRows = False
        Me.grilla_costos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_costos.Location = New System.Drawing.Point(6, 193)
        Me.grilla_costos.Name = "grilla_costos"
        Me.grilla_costos.ReadOnly = True
        Me.grilla_costos.Size = New System.Drawing.Size(1006, 500)
        Me.grilla_costos.TabIndex = 300
        Me.grilla_costos.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txt_busqueda)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(20, 237)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(896, 56)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txt_busqueda
        '
        Me.txt_busqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_busqueda.Location = New System.Drawing.Point(7, 22)
        Me.txt_busqueda.Name = "txt_busqueda"
        Me.txt_busqueda.Size = New System.Drawing.Size(882, 22)
        Me.txt_busqueda.TabIndex = 1
        '
        'btn_buscar
        '
        Me.btn_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_buscar.Image = CType(resources.GetObject("btn_buscar.Image"), System.Drawing.Image)
        Me.btn_buscar.Location = New System.Drawing.Point(962, 83)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(50, 50)
        Me.btn_buscar.TabIndex = 2
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'btn_exportar_excel
        '
        Me.btn_exportar_excel.BackColor = System.Drawing.Color.Transparent
        Me.btn_exportar_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_exportar_excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar_excel.Image = CType(resources.GetObject("btn_exportar_excel.Image"), System.Drawing.Image)
        Me.btn_exportar_excel.Location = New System.Drawing.Point(962, 138)
        Me.btn_exportar_excel.Name = "btn_exportar_excel"
        Me.btn_exportar_excel.Size = New System.Drawing.Size(50, 50)
        Me.btn_exportar_excel.TabIndex = 3
        Me.btn_exportar_excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exportar_excel.UseVisualStyleBackColor = False
        '
        'GroupBox_clientes
        '
        Me.GroupBox_clientes.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_clientes.Controls.Add(Me.Label5)
        Me.GroupBox_clientes.Controls.Add(Me.txt_representante)
        Me.GroupBox_clientes.Controls.Add(Me.Label10)
        Me.GroupBox_clientes.Controls.Add(Me.Label4)
        Me.GroupBox_clientes.Controls.Add(Me.txt_correo_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.txt_rut_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.txt_nombre_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.Label8)
        Me.GroupBox_clientes.Controls.Add(Me.txt_comuna_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.Label13)
        Me.GroupBox_clientes.Controls.Add(Me.txt_giro_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.txt_direccion_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.Label3)
        Me.GroupBox_clientes.Controls.Add(Me.Label2)
        Me.GroupBox_clientes.Controls.Add(Me.Label1)
        Me.GroupBox_clientes.Controls.Add(Me.txt_telefono)
        Me.GroupBox_clientes.Controls.Add(Me.txt_cod_cliente)
        Me.GroupBox_clientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_clientes.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox_clientes.Name = "GroupBox_clientes"
        Me.GroupBox_clientes.Size = New System.Drawing.Size(950, 111)
        Me.GroupBox_clientes.TabIndex = 1
        Me.GroupBox_clientes.TabStop = False
        Me.GroupBox_clientes.Text = "DATOS DEL PROVEEDOR ( F5 ):"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(690, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 16)
        Me.Label5.TabIndex = 365
        Me.Label5.Text = "REPRESENTANTE:"
        '
        'txt_representante
        '
        Me.txt_representante.BackColor = System.Drawing.SystemColors.Control
        Me.txt_representante.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_representante.ForeColor = System.Drawing.Color.Black
        Me.txt_representante.Location = New System.Drawing.Point(693, 78)
        Me.txt_representante.MaxLength = 50
        Me.txt_representante.Name = "txt_representante"
        Me.txt_representante.ReadOnly = True
        Me.txt_representante.Size = New System.Drawing.Size(250, 24)
        Me.txt_representante.TabIndex = 364
        Me.txt_representante.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(110, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 16)
        Me.Label10.TabIndex = 363
        Me.Label10.Text = "CORREO:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(4, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 16)
        Me.Label4.TabIndex = 362
        Me.Label4.Text = "TELEFONO:"
        '
        'txt_correo_cliente
        '
        Me.txt_correo_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_correo_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_correo_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_correo_cliente.Location = New System.Drawing.Point(113, 78)
        Me.txt_correo_cliente.MaxLength = 50
        Me.txt_correo_cliente.Name = "txt_correo_cliente"
        Me.txt_correo_cliente.ReadOnly = True
        Me.txt_correo_cliente.Size = New System.Drawing.Size(284, 24)
        Me.txt_correo_cliente.TabIndex = 361
        Me.txt_correo_cliente.TabStop = False
        '
        'txt_rut_cliente
        '
        Me.txt_rut_cliente.BackColor = System.Drawing.SystemColors.Window
        Me.txt_rut_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_rut_cliente.Location = New System.Drawing.Point(7, 34)
        Me.txt_rut_cliente.MaxLength = 12
        Me.txt_rut_cliente.Name = "txt_rut_cliente"
        Me.txt_rut_cliente.Size = New System.Drawing.Size(100, 24)
        Me.txt_rut_cliente.TabIndex = 2
        Me.txt_rut_cliente.TabStop = False
        '
        'txt_nombre_cliente
        '
        Me.txt_nombre_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_nombre_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_nombre_cliente.Location = New System.Drawing.Point(113, 34)
        Me.txt_nombre_cliente.MaxLength = 50
        Me.txt_nombre_cliente.Name = "txt_nombre_cliente"
        Me.txt_nombre_cliente.ReadOnly = True
        Me.txt_nombre_cliente.Size = New System.Drawing.Size(284, 24)
        Me.txt_nombre_cliente.TabIndex = 0
        Me.txt_nombre_cliente.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(690, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "COMUNA:"
        '
        'txt_comuna_cliente
        '
        Me.txt_comuna_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_comuna_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_comuna_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_comuna_cliente.Location = New System.Drawing.Point(693, 34)
        Me.txt_comuna_cliente.MaxLength = 50
        Me.txt_comuna_cliente.Name = "txt_comuna_cliente"
        Me.txt_comuna_cliente.ReadOnly = True
        Me.txt_comuna_cliente.Size = New System.Drawing.Size(250, 24)
        Me.txt_comuna_cliente.TabIndex = 0
        Me.txt_comuna_cliente.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(400, 60)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 16)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "GIRO:"
        '
        'txt_giro_cliente
        '
        Me.txt_giro_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_giro_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_giro_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_giro_cliente.Location = New System.Drawing.Point(403, 78)
        Me.txt_giro_cliente.MaxLength = 50
        Me.txt_giro_cliente.Name = "txt_giro_cliente"
        Me.txt_giro_cliente.ReadOnly = True
        Me.txt_giro_cliente.Size = New System.Drawing.Size(284, 24)
        Me.txt_giro_cliente.TabIndex = 0
        Me.txt_giro_cliente.TabStop = False
        '
        'txt_direccion_cliente
        '
        Me.txt_direccion_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_direccion_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_direccion_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_direccion_cliente.HideSelection = False
        Me.txt_direccion_cliente.Location = New System.Drawing.Point(403, 34)
        Me.txt_direccion_cliente.MaxLength = 50
        Me.txt_direccion_cliente.Name = "txt_direccion_cliente"
        Me.txt_direccion_cliente.ReadOnly = True
        Me.txt_direccion_cliente.Size = New System.Drawing.Size(284, 24)
        Me.txt_direccion_cliente.TabIndex = 0
        Me.txt_direccion_cliente.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(400, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "DIRECCION:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(110, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "NOMBRE:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "RUT:"
        '
        'txt_telefono
        '
        Me.txt_telefono.BackColor = System.Drawing.SystemColors.Control
        Me.txt_telefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_telefono.ForeColor = System.Drawing.Color.Black
        Me.txt_telefono.Location = New System.Drawing.Point(7, 78)
        Me.txt_telefono.MaxLength = 50
        Me.txt_telefono.Name = "txt_telefono"
        Me.txt_telefono.ReadOnly = True
        Me.txt_telefono.Size = New System.Drawing.Size(100, 24)
        Me.txt_telefono.TabIndex = 3
        Me.txt_telefono.TabStop = False
        '
        'txt_cod_cliente
        '
        Me.txt_cod_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_cod_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_cod_cliente.Location = New System.Drawing.Point(607, 111)
        Me.txt_cod_cliente.Name = "txt_cod_cliente"
        Me.txt_cod_cliente.ReadOnly = True
        Me.txt_cod_cliente.Size = New System.Drawing.Size(56, 24)
        Me.txt_cod_cliente.TabIndex = 7
        Me.txt_cod_cliente.TabStop = False
        '
        'Form_central_de_costos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 699)
        Me.Controls.Add(Me.GroupBox_clientes)
        Me.Controls.Add(Me.btn_exportar_excel)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.grilla_costos)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_central_de_costos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CENTRAL DE COSTOS"
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_costos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox_clientes.ResumeLayout(False)
        Me.GroupBox_clientes.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents grilla_costos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_busqueda As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents btn_exportar_excel As System.Windows.Forms.Button
    Friend WithEvents GroupBox_clientes As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_rut_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_comuna_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_giro_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_direccion_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_telefono As System.Windows.Forms.TextBox
    Friend WithEvents txt_cod_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_correo_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_representante As System.Windows.Forms.TextBox
End Class
