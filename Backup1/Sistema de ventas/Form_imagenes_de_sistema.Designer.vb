<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_imagenes_de_sistema
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_imagenes_de_sistema))
        Me.Combo_imagen = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_guardar_1 = New System.Windows.Forms.Button
        Me.btn_abrir_1 = New System.Windows.Forms.Button
        Me.btn_buscar_1 = New System.Windows.Forms.Button
        Me.txt_extencion_1 = New System.Windows.Forms.TextBox
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_tamaño = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Combo_imagen
        '
        Me.Combo_imagen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_imagen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_imagen.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_imagen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_imagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_imagen.ForeColor = System.Drawing.Color.Black
        Me.Combo_imagen.FormattingEnabled = True
        Me.Combo_imagen.Items.AddRange(New Object() {"LOGO EMPRESA MENU", "LOGO EMPRESA TICKET", "LOGO EMPRESA REPORTES", "LOGO EMPRESA FORMULARIOS", "ICONO MENU 1 DE MENU PRINCIPAL", "ICONO MENU 2 DE MENU PRINCIPAL", "ICONO MENU 3 DE MENU PRINCIPAL", "ICONO MENU 4 DE MENU PRINCIPAL", "ICONO MENU 5 DE MENU PRINCIPAL", "ICONO MENU 6 DE MENU PRINCIPAL", "-"})
        Me.Combo_imagen.Location = New System.Drawing.Point(7, 21)
        Me.Combo_imagen.Name = "Combo_imagen"
        Me.Combo_imagen.Size = New System.Drawing.Size(453, 26)
        Me.Combo_imagen.TabIndex = 285
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btn_salir)
        Me.GroupBox2.Controls.Add(Me.btn_guardar_1)
        Me.GroupBox2.Controls.Add(Me.btn_abrir_1)
        Me.GroupBox2.Controls.Add(Me.btn_buscar_1)
        Me.GroupBox2.Location = New System.Drawing.Point(479, 136)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(109, 196)
        Me.GroupBox2.TabIndex = 284
        Me.GroupBox2.TabStop = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(7, 148)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
        Me.btn_salir.TabIndex = 4
        Me.btn_salir.Text = "SALIR"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_guardar_1
        '
        Me.btn_guardar_1.BackColor = System.Drawing.Color.Transparent
        Me.btn_guardar_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_guardar_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar_1.Image = CType(resources.GetObject("btn_guardar_1.Image"), System.Drawing.Image)
        Me.btn_guardar_1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar_1.Location = New System.Drawing.Point(7, 58)
        Me.btn_guardar_1.Name = "btn_guardar_1"
        Me.btn_guardar_1.Size = New System.Drawing.Size(95, 40)
        Me.btn_guardar_1.TabIndex = 2
        Me.btn_guardar_1.Text = "GUARDAR"
        Me.btn_guardar_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar_1.UseVisualStyleBackColor = False
        '
        'btn_abrir_1
        '
        Me.btn_abrir_1.BackColor = System.Drawing.Color.Transparent
        Me.btn_abrir_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_abrir_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_abrir_1.Image = CType(resources.GetObject("btn_abrir_1.Image"), System.Drawing.Image)
        Me.btn_abrir_1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_abrir_1.Location = New System.Drawing.Point(7, 13)
        Me.btn_abrir_1.Name = "btn_abrir_1"
        Me.btn_abrir_1.Size = New System.Drawing.Size(95, 40)
        Me.btn_abrir_1.TabIndex = 1
        Me.btn_abrir_1.Text = "ABRIR"
        Me.btn_abrir_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_abrir_1.UseVisualStyleBackColor = False
        '
        'btn_buscar_1
        '
        Me.btn_buscar_1.BackColor = System.Drawing.Color.Transparent
        Me.btn_buscar_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_buscar_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar_1.Image = CType(resources.GetObject("btn_buscar_1.Image"), System.Drawing.Image)
        Me.btn_buscar_1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_buscar_1.Location = New System.Drawing.Point(7, 103)
        Me.btn_buscar_1.Name = "btn_buscar_1"
        Me.btn_buscar_1.Size = New System.Drawing.Size(95, 40)
        Me.btn_buscar_1.TabIndex = 3
        Me.btn_buscar_1.Text = "BUSCAR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_buscar_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_buscar_1.UseVisualStyleBackColor = False
        '
        'txt_extencion_1
        '
        Me.txt_extencion_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_extencion_1.Location = New System.Drawing.Point(269, 363)
        Me.txt_extencion_1.MaxLength = 45
        Me.txt_extencion_1.Name = "txt_extencion_1"
        Me.txt_extencion_1.ReadOnly = True
        Me.txt_extencion_1.Size = New System.Drawing.Size(95, 24)
        Me.txt_extencion_1.TabIndex = 283
        Me.txt_extencion_1.TabStop = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 287
        Me.PictureBox_logo.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(7, 141)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(466, 191)
        Me.PictureBox1.TabIndex = 282
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Combo_imagen)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(467, 59)
        Me.GroupBox1.TabIndex = 285
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SELECCIONE DONDE IRA LA IMAGEN A GUARDAR"
        '
        'txt_tamaño
        '
        Me.txt_tamaño.BackColor = System.Drawing.SystemColors.Control
        Me.txt_tamaño.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tamaño.ForeColor = System.Drawing.Color.Black
        Me.txt_tamaño.Location = New System.Drawing.Point(7, 21)
        Me.txt_tamaño.Name = "txt_tamaño"
        Me.txt_tamaño.ReadOnly = True
        Me.txt_tamaño.Size = New System.Drawing.Size(95, 24)
        Me.txt_tamaño.TabIndex = 297
        Me.txt_tamaño.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.txt_tamaño)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(479, 77)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(109, 59)
        Me.GroupBox3.TabIndex = 286
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "TAMAÑO:"
        '
        'Form_imagenes_de_sistema
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 338)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txt_extencion_1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_imagenes_de_sistema"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IMAGENES DE SISTEMA"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents Combo_imagen As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_guardar_1 As System.Windows.Forms.Button
    Friend WithEvents btn_abrir_1 As System.Windows.Forms.Button
    Friend WithEvents btn_buscar_1 As System.Windows.Forms.Button
    Friend WithEvents txt_extencion_1 As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents txt_tamaño As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
End Class
