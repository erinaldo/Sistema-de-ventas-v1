<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_cambiar_de_usuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_cambiar_de_usuario))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_grabar = New System.Windows.Forms.Button
        Me.GroupBox_clientes = New System.Windows.Forms.GroupBox
        Me.txt_area = New System.Windows.Forms.TextBox
        Me.Combo_vendedor = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.lbl_nivel_asistencia = New System.Windows.Forms.Label
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.txt_rut_vendedor = New System.Windows.Forms.TextBox
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox_clientes.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btn_salir)
        Me.GroupBox4.Controls.Add(Me.btn_grabar)
        Me.GroupBox4.Location = New System.Drawing.Point(391, 78)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(210, 88)
        Me.GroupBox4.TabIndex = 334
        Me.GroupBox4.TabStop = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.ForeColor = System.Drawing.Color.Black
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(108, 27)
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
        Me.btn_grabar.Location = New System.Drawing.Point(7, 27)
        Me.btn_grabar.Name = "btn_grabar"
        Me.btn_grabar.Size = New System.Drawing.Size(95, 40)
        Me.btn_grabar.TabIndex = 13
        Me.btn_grabar.Text = "OK"
        Me.btn_grabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_grabar.UseVisualStyleBackColor = True
        '
        'GroupBox_clientes
        '
        Me.GroupBox_clientes.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_clientes.Controls.Add(Me.txt_area)
        Me.GroupBox_clientes.Controls.Add(Me.Combo_vendedor)
        Me.GroupBox_clientes.Controls.Add(Me.Label17)
        Me.GroupBox_clientes.Controls.Add(Me.lbl_nivel_asistencia)
        Me.GroupBox_clientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_clientes.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox_clientes.Name = "GroupBox_clientes"
        Me.GroupBox_clientes.Size = New System.Drawing.Size(379, 89)
        Me.GroupBox_clientes.TabIndex = 333
        Me.GroupBox_clientes.TabStop = False
        Me.GroupBox_clientes.Text = "DATOS DEL VENDEDOR:"
        '
        'txt_area
        '
        Me.txt_area.BackColor = System.Drawing.SystemColors.Control
        Me.txt_area.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_area.Location = New System.Drawing.Point(102, 53)
        Me.txt_area.MaxLength = 11
        Me.txt_area.Name = "txt_area"
        Me.txt_area.ReadOnly = True
        Me.txt_area.Size = New System.Drawing.Size(270, 24)
        Me.txt_area.TabIndex = 330
        Me.txt_area.TabStop = False
        '
        'Combo_vendedor
        '
        Me.Combo_vendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_vendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_vendedor.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_vendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_vendedor.ForeColor = System.Drawing.Color.Black
        Me.Combo_vendedor.FormattingEnabled = True
        Me.Combo_vendedor.Location = New System.Drawing.Point(102, 20)
        Me.Combo_vendedor.Name = "Combo_vendedor"
        Me.Combo_vendedor.Size = New System.Drawing.Size(270, 26)
        Me.Combo_vendedor.TabIndex = 326
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(49, 56)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(51, 18)
        Me.Label17.TabIndex = 329
        Me.Label17.Text = "AREA:"
        '
        'lbl_nivel_asistencia
        '
        Me.lbl_nivel_asistencia.AutoSize = True
        Me.lbl_nivel_asistencia.BackColor = System.Drawing.Color.Transparent
        Me.lbl_nivel_asistencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nivel_asistencia.ForeColor = System.Drawing.Color.Black
        Me.lbl_nivel_asistencia.Location = New System.Drawing.Point(3, 23)
        Me.lbl_nivel_asistencia.Name = "lbl_nivel_asistencia"
        Me.lbl_nivel_asistencia.Size = New System.Drawing.Size(97, 18)
        Me.lbl_nivel_asistencia.TabIndex = 327
        Me.lbl_nivel_asistencia.Text = "VENDEDOR:"
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 332
        Me.PictureBox_logo.TabStop = False
        '
        'txt_rut_vendedor
        '
        Me.txt_rut_vendedor.BackColor = System.Drawing.SystemColors.Control
        Me.txt_rut_vendedor.Enabled = False
        Me.txt_rut_vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut_vendedor.Location = New System.Drawing.Point(469, 90)
        Me.txt_rut_vendedor.MaxLength = 11
        Me.txt_rut_vendedor.Name = "txt_rut_vendedor"
        Me.txt_rut_vendedor.ReadOnly = True
        Me.txt_rut_vendedor.Size = New System.Drawing.Size(81, 24)
        Me.txt_rut_vendedor.TabIndex = 331
        Me.txt_rut_vendedor.TabStop = False
        Me.txt_rut_vendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Form_cambiar_de_usuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 172)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox_clientes)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.txt_rut_vendedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_cambiar_de_usuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CAMBIO DE USUARIO"
        Me.TopMost = True
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox_clientes.ResumeLayout(False)
        Me.GroupBox_clientes.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_grabar As System.Windows.Forms.Button
    Friend WithEvents GroupBox_clientes As System.Windows.Forms.GroupBox
    Friend WithEvents Combo_vendedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lbl_nivel_asistencia As System.Windows.Forms.Label
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents txt_area As System.Windows.Forms.TextBox
    Friend WithEvents txt_rut_vendedor As System.Windows.Forms.TextBox
End Class
