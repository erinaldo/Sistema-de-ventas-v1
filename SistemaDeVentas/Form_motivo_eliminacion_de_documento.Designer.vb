<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_motivo_eliminacion_de_documento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_motivo_eliminacion_de_documento))
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox_referencia = New System.Windows.Forms.GroupBox
        Me.Combo_codigo_referencia = New System.Windows.Forms.ComboBox
        Me.txt_codigo_referencia = New System.Windows.Forms.TextBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_eliminar = New System.Windows.Forms.Button
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_referencia.SuspendLayout()
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
        Me.PictureBox_logo.TabIndex = 143
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox_referencia
        '
        Me.GroupBox_referencia.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_referencia.Controls.Add(Me.Combo_codigo_referencia)
        Me.GroupBox_referencia.Controls.Add(Me.txt_codigo_referencia)
        Me.GroupBox_referencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_referencia.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox_referencia.Name = "GroupBox_referencia"
        Me.GroupBox_referencia.Size = New System.Drawing.Size(301, 69)
        Me.GroupBox_referencia.TabIndex = 144
        Me.GroupBox_referencia.TabStop = False
        Me.GroupBox_referencia.Text = "OPCIONES:"
        '
        'Combo_codigo_referencia
        '
        Me.Combo_codigo_referencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_codigo_referencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_codigo_referencia.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_codigo_referencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_codigo_referencia.ForeColor = System.Drawing.Color.Black
        Me.Combo_codigo_referencia.FormattingEnabled = True
        Me.Combo_codigo_referencia.Items.AddRange(New Object() {"DOCUMENTO DUPLICADO", "-"})
        Me.Combo_codigo_referencia.Location = New System.Drawing.Point(7, 25)
        Me.Combo_codigo_referencia.Name = "Combo_codigo_referencia"
        Me.Combo_codigo_referencia.Size = New System.Drawing.Size(287, 26)
        Me.Combo_codigo_referencia.TabIndex = 9
        '
        'txt_codigo_referencia
        '
        Me.txt_codigo_referencia.BackColor = System.Drawing.SystemColors.Control
        Me.txt_codigo_referencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_referencia.ForeColor = System.Drawing.Color.Black
        Me.txt_codigo_referencia.Location = New System.Drawing.Point(188, 25)
        Me.txt_codigo_referencia.Name = "txt_codigo_referencia"
        Me.txt_codigo_referencia.ReadOnly = True
        Me.txt_codigo_referencia.Size = New System.Drawing.Size(100, 24)
        Me.txt_codigo_referencia.TabIndex = 239
        Me.txt_codigo_referencia.TabStop = False
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.Transparent
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(177, 151)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(95, 40)
        Me.btn_cancelar.TabIndex = 145
        Me.btn_cancelar.Text = "SALIR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'btn_eliminar
        '
        Me.btn_eliminar.BackColor = System.Drawing.Color.Transparent
        Me.btn_eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_eliminar.Image = CType(resources.GetObject("btn_eliminar.Image"), System.Drawing.Image)
        Me.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_eliminar.Location = New System.Drawing.Point(40, 151)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(95, 40)
        Me.btn_eliminar.TabIndex = 146
        Me.btn_eliminar.Text = "ELIMINAR"
        Me.btn_eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_eliminar.UseVisualStyleBackColor = False
        '
        'Form_motivo_eliminacion_de_documento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 197)
        Me.Controls.Add(Me.btn_eliminar)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.GroupBox_referencia)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_motivo_eliminacion_de_documento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MOTIVO"
        Me.TopMost = True
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_referencia.ResumeLayout(False)
        Me.GroupBox_referencia.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox_referencia As System.Windows.Forms.GroupBox
    Friend WithEvents Combo_codigo_referencia As System.Windows.Forms.ComboBox
    Friend WithEvents txt_codigo_referencia As System.Windows.Forms.TextBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
End Class
