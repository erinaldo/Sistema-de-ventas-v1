<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_empresas_relacionadas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_empresas_relacionadas))
        Me.GroupBox_fecha = New System.Windows.Forms.GroupBox
        Me.txt_nombre_relacionado = New System.Windows.Forms.TextBox
        Me.txt_rut_relacionado = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.grilla_impuesto_unico = New System.Windows.Forms.DataGridView
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btn_quitar_entrada_remuneracion = New System.Windows.Forms.Button
        Me.btn_agregar_entrada_remuneracion = New System.Windows.Forms.Button
        Me.GroupBox_fecha.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_impuesto_unico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox_fecha
        '
        Me.GroupBox_fecha.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_fecha.Controls.Add(Me.txt_nombre_relacionado)
        Me.GroupBox_fecha.Controls.Add(Me.txt_rut_relacionado)
        Me.GroupBox_fecha.Controls.Add(Me.Label3)
        Me.GroupBox_fecha.Controls.Add(Me.Label1)
        Me.GroupBox_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_fecha.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox_fecha.Name = "GroupBox_fecha"
        Me.GroupBox_fecha.Size = New System.Drawing.Size(532, 66)
        Me.GroupBox_fecha.TabIndex = 1
        Me.GroupBox_fecha.TabStop = False
        Me.GroupBox_fecha.Text = "DATOS DE LA EMPRESA RELACIONADA:"
        '
        'txt_nombre_relacionado
        '
        Me.txt_nombre_relacionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_relacionado.Location = New System.Drawing.Point(124, 33)
        Me.txt_nombre_relacionado.MaxLength = 45
        Me.txt_nombre_relacionado.Name = "txt_nombre_relacionado"
        Me.txt_nombre_relacionado.ReadOnly = True
        Me.txt_nombre_relacionado.Size = New System.Drawing.Size(400, 24)
        Me.txt_nombre_relacionado.TabIndex = 1
        Me.txt_nombre_relacionado.TabStop = False
        '
        'txt_rut_relacionado
        '
        Me.txt_rut_relacionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut_relacionado.Location = New System.Drawing.Point(7, 33)
        Me.txt_rut_relacionado.MaxLength = 13
        Me.txt_rut_relacionado.Name = "txt_rut_relacionado"
        Me.txt_rut_relacionado.Size = New System.Drawing.Size(111, 24)
        Me.txt_rut_relacionado.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(121, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 145
        Me.Label3.Text = "NOMBRE:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 151
        Me.Label1.Text = "RUT:"
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 154
        Me.PictureBox_logo.TabStop = False
        '
        'grilla_impuesto_unico
        '
        Me.grilla_impuesto_unico.AllowUserToAddRows = False
        Me.grilla_impuesto_unico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grilla_impuesto_unico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_impuesto_unico.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column6})
        Me.grilla_impuesto_unico.Location = New System.Drawing.Point(6, 195)
        Me.grilla_impuesto_unico.Name = "grilla_impuesto_unico"
        Me.grilla_impuesto_unico.ReadOnly = True
        Me.grilla_impuesto_unico.Size = New System.Drawing.Size(532, 217)
        Me.grilla_impuesto_unico.TabIndex = 153
        Me.grilla_impuesto_unico.TabStop = False
        '
        'Column5
        '
        Me.Column5.HeaderText = "CODIGO"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "POSICION"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'btn_quitar_entrada_remuneracion
        '
        Me.btn_quitar_entrada_remuneracion.BackColor = System.Drawing.Color.Transparent
        Me.btn_quitar_entrada_remuneracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_quitar_entrada_remuneracion.Image = CType(resources.GetObject("btn_quitar_entrada_remuneracion.Image"), System.Drawing.Image)
        Me.btn_quitar_entrada_remuneracion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_quitar_entrada_remuneracion.Location = New System.Drawing.Point(435, 149)
        Me.btn_quitar_entrada_remuneracion.Name = "btn_quitar_entrada_remuneracion"
        Me.btn_quitar_entrada_remuneracion.Size = New System.Drawing.Size(95, 40)
        Me.btn_quitar_entrada_remuneracion.TabIndex = 3
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
        Me.btn_agregar_entrada_remuneracion.Location = New System.Drawing.Point(335, 149)
        Me.btn_agregar_entrada_remuneracion.Name = "btn_agregar_entrada_remuneracion"
        Me.btn_agregar_entrada_remuneracion.Size = New System.Drawing.Size(95, 40)
        Me.btn_agregar_entrada_remuneracion.TabIndex = 2
        Me.btn_agregar_entrada_remuneracion.Text = "AGREGAR"
        Me.btn_agregar_entrada_remuneracion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_agregar_entrada_remuneracion.UseVisualStyleBackColor = False
        '
        'Form_empresas_relacionadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 418)
        Me.Controls.Add(Me.GroupBox_fecha)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.grilla_impuesto_unico)
        Me.Controls.Add(Me.btn_quitar_entrada_remuneracion)
        Me.Controls.Add(Me.btn_agregar_entrada_remuneracion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_empresas_relacionadas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EMPRESAS RELACIONADAS"
        Me.TopMost = True
        Me.GroupBox_fecha.ResumeLayout(False)
        Me.GroupBox_fecha.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_impuesto_unico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox_fecha As System.Windows.Forms.GroupBox
    Friend WithEvents txt_nombre_relacionado As System.Windows.Forms.TextBox
    Friend WithEvents txt_rut_relacionado As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents grilla_impuesto_unico As System.Windows.Forms.DataGridView
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_quitar_entrada_remuneracion As System.Windows.Forms.Button
    Friend WithEvents btn_agregar_entrada_remuneracion As System.Windows.Forms.Button
End Class
