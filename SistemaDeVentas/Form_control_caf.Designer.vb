<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_control_caf
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_control_caf))
        Me.label23 = New System.Windows.Forms.Label()
        Me.txt_Fecha_vencimiento_caf = New System.Windows.Forms.TextBox()
        Me.btn_inicia_caf = New System.Windows.Forms.Button()
        Me.cmb_Documento_caf = New System.Windows.Forms.ComboBox()
        Me.btn_Cargar_caf = New System.Windows.Forms.Button()
        Me.txt_Fecha_caf = New System.Windows.Forms.TextBox()
        Me.label25 = New System.Windows.Forms.Label()
        Me.txt_Hasta_caf = New System.Windows.Forms.TextBox()
        Me.txt_Desde_caf = New System.Windows.Forms.TextBox()
        Me.txt_Razon_social_caf = New System.Windows.Forms.TextBox()
        Me.label26 = New System.Windows.Forms.Label()
        Me.txt_Caf = New System.Windows.Forms.TextBox()
        Me.label27 = New System.Windows.Forms.Label()
        Me.label22 = New System.Windows.Forms.Label()
        Me.label28 = New System.Windows.Forms.Label()
        Me.txt_Rut_caf = New System.Windows.Forms.TextBox()
        Me.label24 = New System.Windows.Forms.Label()
        Me.dgv_Documentos_caf = New System.Windows.Forms.DataGridView()
        Me.Linea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCaf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Documento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Desde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hasta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Eliminar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.GroupBox_botones = New System.Windows.Forms.GroupBox()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        CType(Me.dgv_Documentos_caf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_botones.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label23
        '
        Me.label23.AutoSize = True
        Me.label23.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.label23.ForeColor = System.Drawing.Color.Black
        Me.label23.Location = New System.Drawing.Point(346, 185)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(110, 15)
        Me.label23.TabIndex = 34
        Me.label23.Text = "Fecha Vencimiento"
        '
        'txt_Fecha_vencimiento_caf
        '
        Me.txt_Fecha_vencimiento_caf.BackColor = System.Drawing.Color.Snow
        Me.txt_Fecha_vencimiento_caf.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.txt_Fecha_vencimiento_caf.Location = New System.Drawing.Point(459, 181)
        Me.txt_Fecha_vencimiento_caf.Name = "txt_Fecha_vencimiento_caf"
        Me.txt_Fecha_vencimiento_caf.ReadOnly = True
        Me.txt_Fecha_vencimiento_caf.Size = New System.Drawing.Size(74, 22)
        Me.txt_Fecha_vencimiento_caf.TabIndex = 33
        '
        'btn_inicia_caf
        '
        Me.btn_inicia_caf.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.btn_inicia_caf.Location = New System.Drawing.Point(396, 223)
        Me.btn_inicia_caf.Name = "btn_inicia_caf"
        Me.btn_inicia_caf.Size = New System.Drawing.Size(136, 27)
        Me.btn_inicia_caf.TabIndex = 32
        Me.btn_inicia_caf.Text = "Limpiar CAF"
        Me.btn_inicia_caf.UseVisualStyleBackColor = True
        '
        'cmb_Documento_caf
        '
        Me.cmb_Documento_caf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Documento_caf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_Documento_caf.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.cmb_Documento_caf.FormattingEnabled = True
        Me.cmb_Documento_caf.Location = New System.Drawing.Point(112, 99)
        Me.cmb_Documento_caf.Name = "cmb_Documento_caf"
        Me.cmb_Documento_caf.Size = New System.Drawing.Size(261, 22)
        Me.cmb_Documento_caf.TabIndex = 18
        '
        'btn_Cargar_caf
        '
        Me.btn_Cargar_caf.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.btn_Cargar_caf.Location = New System.Drawing.Point(396, 96)
        Me.btn_Cargar_caf.Name = "btn_Cargar_caf"
        Me.btn_Cargar_caf.Size = New System.Drawing.Size(136, 27)
        Me.btn_Cargar_caf.TabIndex = 26
        Me.btn_Cargar_caf.Text = "Cargar CAF"
        Me.btn_Cargar_caf.UseVisualStyleBackColor = True
        '
        'txt_Fecha_caf
        '
        Me.txt_Fecha_caf.BackColor = System.Drawing.Color.Snow
        Me.txt_Fecha_caf.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.txt_Fecha_caf.Location = New System.Drawing.Point(112, 181)
        Me.txt_Fecha_caf.Name = "txt_Fecha_caf"
        Me.txt_Fecha_caf.ReadOnly = True
        Me.txt_Fecha_caf.Size = New System.Drawing.Size(74, 22)
        Me.txt_Fecha_caf.TabIndex = 25
        '
        'label25
        '
        Me.label25.AutoSize = True
        Me.label25.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.label25.ForeColor = System.Drawing.Color.Black
        Me.label25.Location = New System.Drawing.Point(26, 103)
        Me.label25.Name = "label25"
        Me.label25.Size = New System.Drawing.Size(71, 15)
        Me.label25.TabIndex = 19
        Me.label25.Text = "Documento"
        '
        'txt_Hasta_caf
        '
        Me.txt_Hasta_caf.BackColor = System.Drawing.Color.Snow
        Me.txt_Hasta_caf.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.txt_Hasta_caf.Location = New System.Drawing.Point(112, 231)
        Me.txt_Hasta_caf.Name = "txt_Hasta_caf"
        Me.txt_Hasta_caf.ReadOnly = True
        Me.txt_Hasta_caf.Size = New System.Drawing.Size(73, 22)
        Me.txt_Hasta_caf.TabIndex = 24
        '
        'txt_Desde_caf
        '
        Me.txt_Desde_caf.BackColor = System.Drawing.Color.Snow
        Me.txt_Desde_caf.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.txt_Desde_caf.Location = New System.Drawing.Point(112, 206)
        Me.txt_Desde_caf.Name = "txt_Desde_caf"
        Me.txt_Desde_caf.ReadOnly = True
        Me.txt_Desde_caf.Size = New System.Drawing.Size(73, 22)
        Me.txt_Desde_caf.TabIndex = 23
        '
        'txt_Razon_social_caf
        '
        Me.txt_Razon_social_caf.BackColor = System.Drawing.Color.Snow
        Me.txt_Razon_social_caf.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.txt_Razon_social_caf.Location = New System.Drawing.Point(192, 156)
        Me.txt_Razon_social_caf.Name = "txt_Razon_social_caf"
        Me.txt_Razon_social_caf.ReadOnly = True
        Me.txt_Razon_social_caf.Size = New System.Drawing.Size(341, 22)
        Me.txt_Razon_social_caf.TabIndex = 29
        '
        'label26
        '
        Me.label26.AutoSize = True
        Me.label26.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.label26.ForeColor = System.Drawing.Color.Black
        Me.label26.Location = New System.Drawing.Point(26, 210)
        Me.label26.Name = "label26"
        Me.label26.Size = New System.Drawing.Size(41, 15)
        Me.label26.TabIndex = 20
        Me.label26.Text = "Desde"
        '
        'txt_Caf
        '
        Me.txt_Caf.BackColor = System.Drawing.Color.Snow
        Me.txt_Caf.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.txt_Caf.Location = New System.Drawing.Point(112, 131)
        Me.txt_Caf.Name = "txt_Caf"
        Me.txt_Caf.ReadOnly = True
        Me.txt_Caf.Size = New System.Drawing.Size(421, 22)
        Me.txt_Caf.TabIndex = 31
        '
        'label27
        '
        Me.label27.AutoSize = True
        Me.label27.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.label27.ForeColor = System.Drawing.Color.Black
        Me.label27.Location = New System.Drawing.Point(27, 235)
        Me.label27.Name = "label27"
        Me.label27.Size = New System.Drawing.Size(37, 15)
        Me.label27.TabIndex = 21
        Me.label27.Text = "Hasta"
        '
        'label22
        '
        Me.label22.AutoSize = True
        Me.label22.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.label22.ForeColor = System.Drawing.Color.Black
        Me.label22.Location = New System.Drawing.Point(26, 135)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(72, 15)
        Me.label22.TabIndex = 30
        Me.label22.Text = "Archivo CAF"
        '
        'label28
        '
        Me.label28.AutoSize = True
        Me.label28.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.label28.ForeColor = System.Drawing.Color.Black
        Me.label28.Location = New System.Drawing.Point(26, 185)
        Me.label28.Name = "label28"
        Me.label28.Size = New System.Drawing.Size(38, 15)
        Me.label28.TabIndex = 22
        Me.label28.Text = "Fecha"
        '
        'txt_Rut_caf
        '
        Me.txt_Rut_caf.BackColor = System.Drawing.Color.Snow
        Me.txt_Rut_caf.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.txt_Rut_caf.Location = New System.Drawing.Point(112, 156)
        Me.txt_Rut_caf.Name = "txt_Rut_caf"
        Me.txt_Rut_caf.ReadOnly = True
        Me.txt_Rut_caf.Size = New System.Drawing.Size(74, 22)
        Me.txt_Rut_caf.TabIndex = 28
        '
        'label24
        '
        Me.label24.AutoSize = True
        Me.label24.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.label24.ForeColor = System.Drawing.Color.Black
        Me.label24.Location = New System.Drawing.Point(26, 160)
        Me.label24.Name = "label24"
        Me.label24.Size = New System.Drawing.Size(54, 15)
        Me.label24.TabIndex = 27
        Me.label24.Text = "Empresa"
        '
        'dgv_Documentos_caf
        '
        Me.dgv_Documentos_caf.AllowUserToAddRows = False
        Me.dgv_Documentos_caf.AllowUserToDeleteRows = False
        Me.dgv_Documentos_caf.AllowUserToResizeColumns = False
        Me.dgv_Documentos_caf.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite
        Me.dgv_Documentos_caf.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_Documentos_caf.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.dgv_Documentos_caf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Documentos_caf.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Linea, Me.IdCaf, Me.Documento, Me.Desde, Me.Hasta, Me.Vencimiento, Me.Eliminar})
        Me.dgv_Documentos_caf.Location = New System.Drawing.Point(6, 277)
        Me.dgv_Documentos_caf.Name = "dgv_Documentos_caf"
        Me.dgv_Documentos_caf.ReadOnly = True
        Me.dgv_Documentos_caf.RowHeadersVisible = False
        Me.dgv_Documentos_caf.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_Documentos_caf.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Documentos_caf.Size = New System.Drawing.Size(527, 185)
        Me.dgv_Documentos_caf.TabIndex = 35
        '
        'Linea
        '
        Me.Linea.DataPropertyName = "Linea"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        Me.Linea.DefaultCellStyle = DataGridViewCellStyle2
        Me.Linea.HeaderText = ""
        Me.Linea.Name = "Linea"
        Me.Linea.ReadOnly = True
        Me.Linea.Width = 30
        '
        'IdCaf
        '
        Me.IdCaf.DataPropertyName = "Id"
        Me.IdCaf.HeaderText = "ID"
        Me.IdCaf.Name = "IdCaf"
        Me.IdCaf.ReadOnly = True
        Me.IdCaf.Visible = False
        Me.IdCaf.Width = 50
        '
        'Documento
        '
        Me.Documento.DataPropertyName = "Documento_nombre"
        Me.Documento.HeaderText = "Documento"
        Me.Documento.Name = "Documento"
        Me.Documento.ReadOnly = True
        Me.Documento.Width = 200
        '
        'Desde
        '
        Me.Desde.DataPropertyName = "Desde"
        Me.Desde.HeaderText = "Desde"
        Me.Desde.Name = "Desde"
        Me.Desde.ReadOnly = True
        Me.Desde.Width = 80
        '
        'Hasta
        '
        Me.Hasta.DataPropertyName = "Hasta"
        Me.Hasta.HeaderText = "Hasta"
        Me.Hasta.Name = "Hasta"
        Me.Hasta.ReadOnly = True
        Me.Hasta.Width = 80
        '
        'Vencimiento
        '
        Me.Vencimiento.DataPropertyName = "FechaVencimiento"
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Vencimiento.DefaultCellStyle = DataGridViewCellStyle3
        Me.Vencimiento.HeaderText = "Vencimiento"
        Me.Vencimiento.Name = "Vencimiento"
        Me.Vencimiento.ReadOnly = True
        Me.Vencimiento.Width = 80
        '
        'Eliminar
        '
        Me.Eliminar.HeaderText = ""
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.ReadOnly = True
        Me.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Eliminar.Text = "x"
        Me.Eliminar.UseColumnTextForButtonValue = True
        Me.Eliminar.Width = 30
        '
        'GroupBox_botones
        '
        Me.GroupBox_botones.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_botones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.GroupBox_botones.Controls.Add(Me.btn_salir)
        Me.GroupBox_botones.Controls.Add(Me.btn_guardar)
        Me.GroupBox_botones.Location = New System.Drawing.Point(559, 114)
        Me.GroupBox_botones.Name = "GroupBox_botones"
        Me.GroupBox_botones.Size = New System.Drawing.Size(109, 348)
        Me.GroupBox_botones.TabIndex = 36
        Me.GroupBox_botones.TabStop = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(7, 299)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
        Me.btn_salir.TabIndex = 7
        Me.btn_salir.Text = "SALIR"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.Transparent
        Me.btn_guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.Location = New System.Drawing.Point(6, 17)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(95, 40)
        Me.btn_guardar.TabIndex = 5
        Me.btn_guardar.Text = "GUARDAR"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 73
        Me.PictureBox_logo.TabStop = False
        '
        'Form_control_caf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 469)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox_botones)
        Me.Controls.Add(Me.dgv_Documentos_caf)
        Me.Controls.Add(Me.label23)
        Me.Controls.Add(Me.txt_Fecha_vencimiento_caf)
        Me.Controls.Add(Me.btn_inicia_caf)
        Me.Controls.Add(Me.cmb_Documento_caf)
        Me.Controls.Add(Me.btn_Cargar_caf)
        Me.Controls.Add(Me.txt_Fecha_caf)
        Me.Controls.Add(Me.label25)
        Me.Controls.Add(Me.txt_Hasta_caf)
        Me.Controls.Add(Me.txt_Desde_caf)
        Me.Controls.Add(Me.txt_Razon_social_caf)
        Me.Controls.Add(Me.label26)
        Me.Controls.Add(Me.txt_Caf)
        Me.Controls.Add(Me.label27)
        Me.Controls.Add(Me.label22)
        Me.Controls.Add(Me.label28)
        Me.Controls.Add(Me.txt_Rut_caf)
        Me.Controls.Add(Me.label24)
        Me.Name = "Form_control_caf"
        Me.Text = "Form_control_caf"
        CType(Me.dgv_Documentos_caf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_botones.ResumeLayout(False)
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents label23 As Label
    Private WithEvents txt_Fecha_vencimiento_caf As TextBox
    Private WithEvents btn_inicia_caf As Button
    Private WithEvents cmb_Documento_caf As ComboBox
    Private WithEvents btn_Cargar_caf As Button
    Private WithEvents txt_Fecha_caf As TextBox
    Private WithEvents label25 As Label
    Private WithEvents txt_Hasta_caf As TextBox
    Private WithEvents txt_Desde_caf As TextBox
    Private WithEvents txt_Razon_social_caf As TextBox
    Private WithEvents label26 As Label
    Private WithEvents txt_Caf As TextBox
    Private WithEvents label27 As Label
    Private WithEvents label22 As Label
    Private WithEvents label28 As Label
    Private WithEvents txt_Rut_caf As TextBox
    Private WithEvents label24 As Label
    Private WithEvents dgv_Documentos_caf As DataGridView
    Private WithEvents Linea As DataGridViewTextBoxColumn
    Private WithEvents IdCaf As DataGridViewTextBoxColumn
    Private WithEvents Documento As DataGridViewTextBoxColumn
    Private WithEvents Desde As DataGridViewTextBoxColumn
    Private WithEvents Hasta As DataGridViewTextBoxColumn
    Private WithEvents Vencimiento As DataGridViewTextBoxColumn
    Private WithEvents Eliminar As DataGridViewButtonColumn
    Friend WithEvents GroupBox_botones As GroupBox
    Friend WithEvents btn_salir As Button
    Friend WithEvents btn_guardar As Button
    Friend WithEvents PictureBox_logo As PictureBox
End Class
