<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_buscador_usuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_buscador_usuarios))
        Me.btn_volver = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.radio_todos = New System.Windows.Forms.RadioButton
        Me.radio_clave = New System.Windows.Forms.RadioButton
        Me.radio_usuario = New System.Windows.Forms.RadioButton
        Me.radio_nombre = New System.Windows.Forms.RadioButton
        Me.radio_rut = New System.Windows.Forms.RadioButton
        Me.migrilla = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txt_buscar = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Combocriterio = New System.Windows.Forms.ComboBox
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.migrilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_volver
        '
        Me.btn_volver.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_volver.Image = CType(resources.GetObject("btn_volver.Image"), System.Drawing.Image)
        Me.btn_volver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_volver.Location = New System.Drawing.Point(783, 422)
        Me.btn_volver.Name = "btn_volver"
        Me.btn_volver.Size = New System.Drawing.Size(105, 40)
        Me.btn_volver.TabIndex = 6
        Me.btn_volver.Text = "VOLVER"
        Me.btn_volver.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_volver.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radio_todos)
        Me.GroupBox1.Controls.Add(Me.radio_clave)
        Me.GroupBox1.Controls.Add(Me.radio_usuario)
        Me.GroupBox1.Controls.Add(Me.radio_nombre)
        Me.GroupBox1.Controls.Add(Me.radio_rut)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(882, 56)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CAMPO DE BUSQUEDA"
        '
        'radio_todos
        '
        Me.radio_todos.AutoSize = True
        Me.radio_todos.Location = New System.Drawing.Point(714, 23)
        Me.radio_todos.Name = "radio_todos"
        Me.radio_todos.Size = New System.Drawing.Size(74, 20)
        Me.radio_todos.TabIndex = 0
        Me.radio_todos.TabStop = True
        Me.radio_todos.Text = "TODOS"
        Me.radio_todos.UseVisualStyleBackColor = True
        '
        'radio_clave
        '
        Me.radio_clave.AutoSize = True
        Me.radio_clave.Location = New System.Drawing.Point(564, 23)
        Me.radio_clave.Name = "radio_clave"
        Me.radio_clave.Size = New System.Drawing.Size(69, 20)
        Me.radio_clave.TabIndex = 0
        Me.radio_clave.TabStop = True
        Me.radio_clave.Text = "CLAVE"
        Me.radio_clave.UseVisualStyleBackColor = True
        '
        'radio_usuario
        '
        Me.radio_usuario.AutoSize = True
        Me.radio_usuario.Location = New System.Drawing.Point(396, 23)
        Me.radio_usuario.Name = "radio_usuario"
        Me.radio_usuario.Size = New System.Drawing.Size(87, 20)
        Me.radio_usuario.TabIndex = 0
        Me.radio_usuario.TabStop = True
        Me.radio_usuario.Text = "USUARIO"
        Me.radio_usuario.UseVisualStyleBackColor = True
        '
        'radio_nombre
        '
        Me.radio_nombre.AutoSize = True
        Me.radio_nombre.Location = New System.Drawing.Point(230, 23)
        Me.radio_nombre.Name = "radio_nombre"
        Me.radio_nombre.Size = New System.Drawing.Size(85, 20)
        Me.radio_nombre.TabIndex = 0
        Me.radio_nombre.TabStop = True
        Me.radio_nombre.Text = "NOMBRE"
        Me.radio_nombre.UseVisualStyleBackColor = True
        '
        'radio_rut
        '
        Me.radio_rut.AutoSize = True
        Me.radio_rut.Location = New System.Drawing.Point(94, 23)
        Me.radio_rut.Name = "radio_rut"
        Me.radio_rut.Size = New System.Drawing.Size(55, 20)
        Me.radio_rut.TabIndex = 0
        Me.radio_rut.TabStop = True
        Me.radio_rut.Text = "RUT"
        Me.radio_rut.UseVisualStyleBackColor = True
        '
        'migrilla
        '
        Me.migrilla.AllowUserToAddRows = False
        Me.migrilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.migrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.migrilla.Location = New System.Drawing.Point(6, 175)
        Me.migrilla.Name = "migrilla"
        Me.migrilla.ReadOnly = True
        Me.migrilla.Size = New System.Drawing.Size(882, 241)
        Me.migrilla.TabIndex = 44
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txt_buscar)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(615, 113)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(273, 56)
        Me.GroupBox3.TabIndex = 62
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "TEXTO A BUSCAR"
        '
        'txt_buscar
        '
        Me.txt_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_buscar.Location = New System.Drawing.Point(21, 22)
        Me.txt_buscar.Name = "txt_buscar"
        Me.txt_buscar.Size = New System.Drawing.Size(230, 24)
        Me.txt_buscar.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Combocriterio)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 113)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(273, 56)
        Me.GroupBox2.TabIndex = 61
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CRITERIO DE BUSQUEDA"
        '
        'Combocriterio
        '
        Me.Combocriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combocriterio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combocriterio.FormattingEnabled = True
        Me.Combocriterio.Items.AddRange(New Object() {"CUALQUIER PARTE DEL CAMPO", "AL COMIENZO DEL CAMPO"})
        Me.Combocriterio.Location = New System.Drawing.Point(21, 21)
        Me.Combocriterio.Name = "Combocriterio"
        Me.Combocriterio.Size = New System.Drawing.Size(230, 24)
        Me.Combocriterio.TabIndex = 0
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 50)
        Me.PictureBox_logo.TabIndex = 65
        Me.PictureBox_logo.TabStop = False
        '
        'form_buscar_usuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(894, 468)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.migrilla)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_volver)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "form_buscar_usuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BUSCADOR DE USUARIOS"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.migrilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_volver As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radio_todos As System.Windows.Forms.RadioButton
    Friend WithEvents radio_clave As System.Windows.Forms.RadioButton
    Friend WithEvents radio_usuario As System.Windows.Forms.RadioButton
    Friend WithEvents radio_nombre As System.Windows.Forms.RadioButton
    Friend WithEvents radio_rut As System.Windows.Forms.RadioButton
    Friend WithEvents migrilla As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_buscar As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Combocriterio As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
End Class
