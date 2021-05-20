<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_call_center
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_call_center))
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.Combo_asistente = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.lbl_nivel_asistencia = New System.Windows.Forms.Label
        Me.Combo_nivel_asistencia = New System.Windows.Forms.ComboBox
        Me.GroupBox_clientes = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_grabar = New System.Windows.Forms.Button
        Me.txt_rut_asistente = New System.Windows.Forms.TextBox
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_clientes.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 142
        Me.PictureBox_logo.TabStop = False
        '
        'Combo_asistente
        '
        Me.Combo_asistente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_asistente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_asistente.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_asistente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_asistente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_asistente.ForeColor = System.Drawing.Color.Black
        Me.Combo_asistente.FormattingEnabled = True
        Me.Combo_asistente.Items.AddRange(New Object() {"EFECTIVO", "CREDITO"})
        Me.Combo_asistente.Location = New System.Drawing.Point(172, 55)
        Me.Combo_asistente.Name = "Combo_asistente"
        Me.Combo_asistente.Size = New System.Drawing.Size(200, 26)
        Me.Combo_asistente.TabIndex = 328
        Me.Combo_asistente.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(77, 58)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(93, 18)
        Me.Label17.TabIndex = 329
        Me.Label17.Text = "ASISTENTE:"
        '
        'lbl_nivel_asistencia
        '
        Me.lbl_nivel_asistencia.AutoSize = True
        Me.lbl_nivel_asistencia.BackColor = System.Drawing.Color.Transparent
        Me.lbl_nivel_asistencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nivel_asistencia.ForeColor = System.Drawing.Color.Black
        Me.lbl_nivel_asistencia.Location = New System.Drawing.Point(3, 23)
        Me.lbl_nivel_asistencia.Name = "lbl_nivel_asistencia"
        Me.lbl_nivel_asistencia.Size = New System.Drawing.Size(167, 18)
        Me.lbl_nivel_asistencia.TabIndex = 327
        Me.lbl_nivel_asistencia.Text = "NIVEL DE ASISTENCIA:"
        '
        'Combo_nivel_asistencia
        '
        Me.Combo_nivel_asistencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_nivel_asistencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_nivel_asistencia.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_nivel_asistencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_nivel_asistencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_nivel_asistencia.ForeColor = System.Drawing.Color.Black
        Me.Combo_nivel_asistencia.FormattingEnabled = True
        Me.Combo_nivel_asistencia.Items.AddRange(New Object() {"BASICA", "MEDIA", "COMPLETA", "-"})
        Me.Combo_nivel_asistencia.Location = New System.Drawing.Point(172, 20)
        Me.Combo_nivel_asistencia.Name = "Combo_nivel_asistencia"
        Me.Combo_nivel_asistencia.Size = New System.Drawing.Size(200, 26)
        Me.Combo_nivel_asistencia.TabIndex = 326
        '
        'GroupBox_clientes
        '
        Me.GroupBox_clientes.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_clientes.Controls.Add(Me.Combo_asistente)
        Me.GroupBox_clientes.Controls.Add(Me.Combo_nivel_asistencia)
        Me.GroupBox_clientes.Controls.Add(Me.Label17)
        Me.GroupBox_clientes.Controls.Add(Me.lbl_nivel_asistencia)
        Me.GroupBox_clientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_clientes.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox_clientes.Name = "GroupBox_clientes"
        Me.GroupBox_clientes.Size = New System.Drawing.Size(379, 89)
        Me.GroupBox_clientes.TabIndex = 330
        Me.GroupBox_clientes.TabStop = False
        Me.GroupBox_clientes.Text = "DATOS DE LA ASISTENCIA:"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btn_salir)
        Me.GroupBox4.Controls.Add(Me.btn_grabar)
        Me.GroupBox4.Location = New System.Drawing.Point(391, 78)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(210, 88)
        Me.GroupBox4.TabIndex = 331
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
        'txt_rut_asistente
        '
        Me.txt_rut_asistente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_rut_asistente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut_asistente.ForeColor = System.Drawing.Color.Black
        Me.txt_rut_asistente.Location = New System.Drawing.Point(619, 32)
        Me.txt_rut_asistente.Name = "txt_rut_asistente"
        Me.txt_rut_asistente.ReadOnly = True
        Me.txt_rut_asistente.Size = New System.Drawing.Size(84, 24)
        Me.txt_rut_asistente.TabIndex = 332
        Me.txt_rut_asistente.TabStop = False
        '
        'Form_call_center
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 172)
        Me.Controls.Add(Me.txt_rut_asistente)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox_clientes)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_call_center"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ASISTENCIA TELEFONICA"
        Me.TopMost = True
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_clientes.ResumeLayout(False)
        Me.GroupBox_clientes.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents Combo_asistente As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lbl_nivel_asistencia As System.Windows.Forms.Label
    Friend WithEvents Combo_nivel_asistencia As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox_clientes As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_grabar As System.Windows.Forms.Button
    Friend WithEvents txt_rut_asistente As System.Windows.Forms.TextBox
End Class
