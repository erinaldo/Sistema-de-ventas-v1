<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_reposicion_arana
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_reposicion_arana))
        Me.lbl_mensaje = New System.Windows.Forms.Label()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.grilla_documento = New System.Windows.Forms.DataGridView()
        Me.Combo_subfamilia = New System.Windows.Forms.ComboBox()
        Me.Combo_subfamilia_2 = New System.Windows.Forms.ComboBox()
        Me.Combo_familia = New System.Windows.Forms.ComboBox()
        Me.txt_codigo_subfamilia_2 = New System.Windows.Forms.TextBox()
        Me.txt_codigo_subfamilia = New System.Windows.Forms.TextBox()
        Me.txt_codigo_familia = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn_mostrar = New System.Windows.Forms.Button()
        Me.btn_exportar_excel = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.Check_expandir_todo = New System.Windows.Forms.CheckBox()
        Me.Check_codigo_subfamilia2 = New System.Windows.Forms.CheckBox()
        Me.Check_mostrar_solo_por_pedir = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_documento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(409, 2)
        Me.lbl_mensaje.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(945, 100)
        Me.lbl_mensaje.TabIndex = 234
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(8, 7)
        Me.PictureBox_logo.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(400, 86)
        Me.PictureBox_logo.TabIndex = 233
        Me.PictureBox_logo.TabStop = False
        '
        'grilla_documento
        '
        Me.grilla_documento.AllowUserToAddRows = False
        Me.grilla_documento.AllowUserToDeleteRows = False
        Me.grilla_documento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_documento.Location = New System.Drawing.Point(8, 181)
        Me.grilla_documento.Margin = New System.Windows.Forms.Padding(4)
        Me.grilla_documento.Name = "grilla_documento"
        Me.grilla_documento.ReadOnly = True
        Me.grilla_documento.Size = New System.Drawing.Size(1341, 672)
        Me.grilla_documento.TabIndex = 298
        Me.grilla_documento.TabStop = False
        '
        'Combo_subfamilia
        '
        Me.Combo_subfamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_subfamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_subfamilia.FormattingEnabled = True
        Me.Combo_subfamilia.Items.AddRange(New Object() {"-"})
        Me.Combo_subfamilia.Location = New System.Drawing.Point(9, 28)
        Me.Combo_subfamilia.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_subfamilia.Name = "Combo_subfamilia"
        Me.Combo_subfamilia.Size = New System.Drawing.Size(281, 28)
        Me.Combo_subfamilia.TabIndex = 300
        '
        'Combo_subfamilia_2
        '
        Me.Combo_subfamilia_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_subfamilia_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_subfamilia_2.FormattingEnabled = True
        Me.Combo_subfamilia_2.Items.AddRange(New Object() {"-"})
        Me.Combo_subfamilia_2.Location = New System.Drawing.Point(9, 28)
        Me.Combo_subfamilia_2.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_subfamilia_2.Name = "Combo_subfamilia_2"
        Me.Combo_subfamilia_2.Size = New System.Drawing.Size(281, 28)
        Me.Combo_subfamilia_2.TabIndex = 301
        '
        'Combo_familia
        '
        Me.Combo_familia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_familia.FormattingEnabled = True
        Me.Combo_familia.Items.AddRange(New Object() {"-"})
        Me.Combo_familia.Location = New System.Drawing.Point(9, 28)
        Me.Combo_familia.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_familia.Name = "Combo_familia"
        Me.Combo_familia.Size = New System.Drawing.Size(281, 28)
        Me.Combo_familia.TabIndex = 299
        '
        'txt_codigo_subfamilia_2
        '
        Me.txt_codigo_subfamilia_2.Enabled = False
        Me.txt_codigo_subfamilia_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_subfamilia_2.Location = New System.Drawing.Point(397, 309)
        Me.txt_codigo_subfamilia_2.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_codigo_subfamilia_2.MaxLength = 8
        Me.txt_codigo_subfamilia_2.Name = "txt_codigo_subfamilia_2"
        Me.txt_codigo_subfamilia_2.Size = New System.Drawing.Size(147, 29)
        Me.txt_codigo_subfamilia_2.TabIndex = 307
        Me.txt_codigo_subfamilia_2.TabStop = False
        '
        'txt_codigo_subfamilia
        '
        Me.txt_codigo_subfamilia.Enabled = False
        Me.txt_codigo_subfamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_subfamilia.Location = New System.Drawing.Point(249, 309)
        Me.txt_codigo_subfamilia.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_codigo_subfamilia.MaxLength = 8
        Me.txt_codigo_subfamilia.Name = "txt_codigo_subfamilia"
        Me.txt_codigo_subfamilia.Size = New System.Drawing.Size(147, 29)
        Me.txt_codigo_subfamilia.TabIndex = 306
        Me.txt_codigo_subfamilia.TabStop = False
        '
        'txt_codigo_familia
        '
        Me.txt_codigo_familia.Enabled = False
        Me.txt_codigo_familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_familia.Location = New System.Drawing.Point(101, 309)
        Me.txt_codigo_familia.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_codigo_familia.MaxLength = 8
        Me.txt_codigo_familia.Name = "txt_codigo_familia"
        Me.txt_codigo_familia.Size = New System.Drawing.Size(147, 29)
        Me.txt_codigo_familia.TabIndex = 305
        Me.txt_codigo_familia.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Combo_familia)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 95)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(301, 80)
        Me.GroupBox1.TabIndex = 308
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FAMILIA:"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Combo_subfamilia)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(317, 95)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(301, 80)
        Me.GroupBox2.TabIndex = 309
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "SUBFAMILIA:"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Combo_subfamilia_2)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(627, 95)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(303, 80)
        Me.GroupBox3.TabIndex = 310
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "SUBAMILIA 2:"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btn_mostrar)
        Me.GroupBox4.Controls.Add(Me.btn_exportar_excel)
        Me.GroupBox4.Controls.Add(Me.btn_salir)
        Me.GroupBox4.Location = New System.Drawing.Point(937, 96)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(412, 79)
        Me.GroupBox4.TabIndex = 311
        Me.GroupBox4.TabStop = False
        '
        'btn_mostrar
        '
        Me.btn_mostrar.BackColor = System.Drawing.Color.Transparent
        Me.btn_mostrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_mostrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_mostrar.Image = CType(resources.GetObject("btn_mostrar.Image"), System.Drawing.Image)
        Me.btn_mostrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_mostrar.Location = New System.Drawing.Point(9, 18)
        Me.btn_mostrar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_mostrar.Name = "btn_mostrar"
        Me.btn_mostrar.Size = New System.Drawing.Size(127, 49)
        Me.btn_mostrar.TabIndex = 1
        Me.btn_mostrar.Text = "MOSTRAR"
        Me.btn_mostrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_mostrar.UseVisualStyleBackColor = False
        '
        'btn_exportar_excel
        '
        Me.btn_exportar_excel.BackColor = System.Drawing.Color.Transparent
        Me.btn_exportar_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_exportar_excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar_excel.Image = CType(resources.GetObject("btn_exportar_excel.Image"), System.Drawing.Image)
        Me.btn_exportar_excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exportar_excel.Location = New System.Drawing.Point(143, 18)
        Me.btn_exportar_excel.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_exportar_excel.Name = "btn_exportar_excel"
        Me.btn_exportar_excel.Size = New System.Drawing.Size(127, 49)
        Me.btn_exportar_excel.TabIndex = 4
        Me.btn_exportar_excel.Text = "EXPORTAR"
        Me.btn_exportar_excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exportar_excel.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(276, 18)
        Me.btn_salir.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(127, 49)
        Me.btn_salir.TabIndex = 5
        Me.btn_salir.Text = "SALIR"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'Check_expandir_todo
        '
        Me.Check_expandir_todo.AutoSize = True
        Me.Check_expandir_todo.BackColor = System.Drawing.Color.Transparent
        Me.Check_expandir_todo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Check_expandir_todo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_expandir_todo.Location = New System.Drawing.Point(1157, 28)
        Me.Check_expandir_todo.Margin = New System.Windows.Forms.Padding(4)
        Me.Check_expandir_todo.Name = "Check_expandir_todo"
        Me.Check_expandir_todo.Size = New System.Drawing.Size(170, 24)
        Me.Check_expandir_todo.TabIndex = 312
        Me.Check_expandir_todo.TabStop = False
        Me.Check_expandir_todo.Text = "EXPANDIR TODO"
        Me.Check_expandir_todo.UseVisualStyleBackColor = False
        '
        'Check_codigo_subfamilia2
        '
        Me.Check_codigo_subfamilia2.AutoSize = True
        Me.Check_codigo_subfamilia2.BackColor = System.Drawing.Color.Transparent
        Me.Check_codigo_subfamilia2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Check_codigo_subfamilia2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_codigo_subfamilia2.Location = New System.Drawing.Point(893, 28)
        Me.Check_codigo_subfamilia2.Margin = New System.Windows.Forms.Padding(4)
        Me.Check_codigo_subfamilia2.Name = "Check_codigo_subfamilia2"
        Me.Check_codigo_subfamilia2.Size = New System.Drawing.Size(243, 24)
        Me.Check_codigo_subfamilia2.TabIndex = 313
        Me.Check_codigo_subfamilia2.TabStop = False
        Me.Check_codigo_subfamilia2.Text = "OCULTAR CODIGO SUBF2"
        Me.Check_codigo_subfamilia2.UseVisualStyleBackColor = False
        '
        'Check_mostrar_solo_por_pedir
        '
        Me.Check_mostrar_solo_por_pedir.AutoSize = True
        Me.Check_mostrar_solo_por_pedir.BackColor = System.Drawing.Color.Transparent
        Me.Check_mostrar_solo_por_pedir.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Check_mostrar_solo_por_pedir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_mostrar_solo_por_pedir.Location = New System.Drawing.Point(1060, 59)
        Me.Check_mostrar_solo_por_pedir.Margin = New System.Windows.Forms.Padding(4)
        Me.Check_mostrar_solo_por_pedir.Name = "Check_mostrar_solo_por_pedir"
        Me.Check_mostrar_solo_por_pedir.Size = New System.Drawing.Size(263, 24)
        Me.Check_mostrar_solo_por_pedir.TabIndex = 314
        Me.Check_mostrar_solo_por_pedir.TabStop = False
        Me.Check_mostrar_solo_por_pedir.Text = "MOSTRAR SOLO POR PEDIR"
        Me.Check_mostrar_solo_por_pedir.UseVisualStyleBackColor = False
        '
        'Form_reposicion_arana
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1357, 860)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.Check_mostrar_solo_por_pedir)
        Me.Controls.Add(Me.Check_codigo_subfamilia2)
        Me.Controls.Add(Me.Check_expandir_todo)
        Me.Controls.Add(Me.grilla_documento)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txt_codigo_subfamilia_2)
        Me.Controls.Add(Me.txt_codigo_subfamilia)
        Me.Controls.Add(Me.txt_codigo_familia)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Form_reposicion_arana"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPOSICION"
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_documento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents grilla_documento As System.Windows.Forms.DataGridView
    Friend WithEvents Combo_subfamilia As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_subfamilia_2 As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_familia As System.Windows.Forms.ComboBox
    Friend WithEvents txt_codigo_subfamilia_2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_subfamilia As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_familia As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_mostrar As System.Windows.Forms.Button
    Friend WithEvents btn_exportar_excel As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents Check_expandir_todo As System.Windows.Forms.CheckBox
    Friend WithEvents Check_codigo_subfamilia2 As System.Windows.Forms.CheckBox
    Friend WithEvents Check_mostrar_solo_por_pedir As System.Windows.Forms.CheckBox
End Class
