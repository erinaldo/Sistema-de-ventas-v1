<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_registro_subfamilia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_registro_subfamilia))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btn_ultimo = New System.Windows.Forms.Button
        Me.btn_primero = New System.Windows.Forms.Button
        Me.btn_siguiente = New System.Windows.Forms.Button
        Me.btn_anterior = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_modificar = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.btn_eliminar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_codigo_subfamilia_2 = New System.Windows.Forms.TextBox
        Me.txt_codigo_subfamilia = New System.Windows.Forms.TextBox
        Me.txt_codigo_familia = New System.Windows.Forms.TextBox
        Me.combo_familia = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_nombre_subfamilia = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.btn_ultimo)
        Me.GroupBox3.Controls.Add(Me.btn_primero)
        Me.GroupBox3.Controls.Add(Me.btn_siguiente)
        Me.GroupBox3.Controls.Add(Me.btn_anterior)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 303)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(417, 61)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'btn_ultimo
        '
        Me.btn_ultimo.BackColor = System.Drawing.Color.Transparent
        Me.btn_ultimo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_ultimo.Image = CType(resources.GetObject("btn_ultimo.Image"), System.Drawing.Image)
        Me.btn_ultimo.Location = New System.Drawing.Point(370, 13)
        Me.btn_ultimo.Name = "btn_ultimo"
        Me.btn_ultimo.Size = New System.Drawing.Size(40, 40)
        Me.btn_ultimo.TabIndex = 8
        Me.btn_ultimo.UseVisualStyleBackColor = False
        '
        'btn_primero
        '
        Me.btn_primero.BackColor = System.Drawing.Color.Transparent
        Me.btn_primero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_primero.Image = CType(resources.GetObject("btn_primero.Image"), System.Drawing.Image)
        Me.btn_primero.Location = New System.Drawing.Point(7, 13)
        Me.btn_primero.Name = "btn_primero"
        Me.btn_primero.Size = New System.Drawing.Size(40, 40)
        Me.btn_primero.TabIndex = 5
        Me.btn_primero.UseVisualStyleBackColor = False
        '
        'btn_siguiente
        '
        Me.btn_siguiente.BackColor = System.Drawing.Color.Transparent
        Me.btn_siguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_siguiente.Image = CType(resources.GetObject("btn_siguiente.Image"), System.Drawing.Image)
        Me.btn_siguiente.Location = New System.Drawing.Point(325, 13)
        Me.btn_siguiente.Name = "btn_siguiente"
        Me.btn_siguiente.Size = New System.Drawing.Size(40, 40)
        Me.btn_siguiente.TabIndex = 7
        Me.btn_siguiente.UseVisualStyleBackColor = False
        '
        'btn_anterior
        '
        Me.btn_anterior.BackColor = System.Drawing.Color.Transparent
        Me.btn_anterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_anterior.Image = CType(resources.GetObject("btn_anterior.Image"), System.Drawing.Image)
        Me.btn_anterior.Location = New System.Drawing.Point(52, 13)
        Me.btn_anterior.Name = "btn_anterior"
        Me.btn_anterior.Size = New System.Drawing.Size(40, 40)
        Me.btn_anterior.TabIndex = 6
        Me.btn_anterior.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btn_modificar)
        Me.GroupBox2.Controls.Add(Me.btn_salir)
        Me.GroupBox2.Controls.Add(Me.btn_nuevo)
        Me.GroupBox2.Controls.Add(Me.btn_cancelar)
        Me.GroupBox2.Controls.Add(Me.btn_guardar)
        Me.GroupBox2.Controls.Add(Me.btn_eliminar)
        Me.GroupBox2.Location = New System.Drawing.Point(429, 78)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(109, 286)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'btn_modificar
        '
        Me.btn_modificar.BackColor = System.Drawing.Color.Transparent
        Me.btn_modificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_modificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_modificar.Image = CType(resources.GetObject("btn_modificar.Image"), System.Drawing.Image)
        Me.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_modificar.Location = New System.Drawing.Point(7, 58)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(95, 40)
        Me.btn_modificar.TabIndex = 2
        Me.btn_modificar.Text = "MODIFICAR"
        Me.btn_modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_modificar.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(7, 238)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
        Me.btn_salir.TabIndex = 6
        Me.btn_salir.Text = "SALIR"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_nuevo
        '
        Me.btn_nuevo.BackColor = System.Drawing.Color.Transparent
        Me.btn_nuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_nuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btn_nuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btn_nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.Image = CType(resources.GetObject("btn_nuevo.Image"), System.Drawing.Image)
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo.Location = New System.Drawing.Point(7, 13)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(95, 40)
        Me.btn_nuevo.TabIndex = 1
        Me.btn_nuevo.Text = "NUEVO"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.Transparent
        Me.btn_cancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(7, 193)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(95, 40)
        Me.btn_cancelar.TabIndex = 5
        Me.btn_cancelar.Text = "CANCELAR"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.Transparent
        Me.btn_guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.Location = New System.Drawing.Point(7, 148)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(95, 40)
        Me.btn_guardar.TabIndex = 4
        Me.btn_guardar.Text = "GUARDAR"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'btn_eliminar
        '
        Me.btn_eliminar.BackColor = System.Drawing.Color.Transparent
        Me.btn_eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_eliminar.Image = CType(resources.GetObject("btn_eliminar.Image"), System.Drawing.Image)
        Me.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_eliminar.Location = New System.Drawing.Point(7, 103)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(95, 40)
        Me.btn_eliminar.TabIndex = 3
        Me.btn_eliminar.Text = "ELIMINAR"
        Me.btn_eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_eliminar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txt_codigo_subfamilia_2)
        Me.GroupBox1.Controls.Add(Me.txt_codigo_subfamilia)
        Me.GroupBox1.Controls.Add(Me.txt_codigo_familia)
        Me.GroupBox1.Controls.Add(Me.combo_familia)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_nombre_subfamilia)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(417, 226)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DATOS DE LA FAMILIA"
        '
        'txt_codigo_subfamilia_2
        '
        Me.txt_codigo_subfamilia_2.Enabled = False
        Me.txt_codigo_subfamilia_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_subfamilia_2.Location = New System.Drawing.Point(426, 142)
        Me.txt_codigo_subfamilia_2.MaxLength = 8
        Me.txt_codigo_subfamilia_2.Name = "txt_codigo_subfamilia_2"
        Me.txt_codigo_subfamilia_2.Size = New System.Drawing.Size(111, 24)
        Me.txt_codigo_subfamilia_2.TabIndex = 55
        Me.txt_codigo_subfamilia_2.TabStop = False
        '
        'txt_codigo_subfamilia
        '
        Me.txt_codigo_subfamilia.Enabled = False
        Me.txt_codigo_subfamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_subfamilia.Location = New System.Drawing.Point(426, 118)
        Me.txt_codigo_subfamilia.MaxLength = 8
        Me.txt_codigo_subfamilia.Name = "txt_codigo_subfamilia"
        Me.txt_codigo_subfamilia.Size = New System.Drawing.Size(111, 24)
        Me.txt_codigo_subfamilia.TabIndex = 54
        Me.txt_codigo_subfamilia.TabStop = False
        '
        'txt_codigo_familia
        '
        Me.txt_codigo_familia.Enabled = False
        Me.txt_codigo_familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_familia.Location = New System.Drawing.Point(426, 94)
        Me.txt_codigo_familia.MaxLength = 8
        Me.txt_codigo_familia.Name = "txt_codigo_familia"
        Me.txt_codigo_familia.Size = New System.Drawing.Size(111, 24)
        Me.txt_codigo_familia.TabIndex = 53
        Me.txt_codigo_familia.TabStop = False
        '
        'combo_familia
        '
        Me.combo_familia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_familia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_familia.BackColor = System.Drawing.SystemColors.Window
        Me.combo_familia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_familia.FormattingEnabled = True
        Me.combo_familia.Location = New System.Drawing.Point(7, 57)
        Me.combo_familia.MaxLength = 12
        Me.combo_familia.Name = "combo_familia"
        Me.combo_familia.Size = New System.Drawing.Size(403, 26)
        Me.combo_familia.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(7, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "FAMILIA:"
        '
        'txt_nombre_subfamilia
        '
        Me.txt_nombre_subfamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_subfamilia.Location = New System.Drawing.Point(7, 174)
        Me.txt_nombre_subfamilia.MaxLength = 45
        Me.txt_nombre_subfamilia.Name = "txt_nombre_subfamilia"
        Me.txt_nombre_subfamilia.Size = New System.Drawing.Size(403, 24)
        Me.txt_nombre_subfamilia.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(7, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "NOMBRE SUB-FAMILIA:"
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 216
        Me.PictureBox_logo.TabStop = False
        '
        'Form_registro_subfamilia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 370)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_registro_subfamilia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REGISTRO DE SUB-FAMILIAS"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_ultimo As System.Windows.Forms.Button
    Friend WithEvents btn_primero As System.Windows.Forms.Button
    Friend WithEvents btn_siguiente As System.Windows.Forms.Button
    Friend WithEvents btn_anterior As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_nombre_subfamilia As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents combo_familia As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents btn_modificar As System.Windows.Forms.Button
    Friend WithEvents txt_codigo_subfamilia_2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_subfamilia As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_familia As System.Windows.Forms.TextBox
End Class
