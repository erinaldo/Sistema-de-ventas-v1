<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_cargar_libro_de_compra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_cargar_libro_de_compra))
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Radio_periodo_tributario = New System.Windows.Forms.RadioButton
        Me.Radio_fecha_de_ingreso = New System.Windows.Forms.RadioButton
        Me.dtp_fecha_de_ingreso = New System.Windows.Forms.DateTimePicker
        Me.dtp_periodo_tributario = New System.Windows.Forms.DateTimePicker
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_aceptar = New System.Windows.Forms.Button
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.PictureBox_logo.TabIndex = 129
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Radio_periodo_tributario)
        Me.GroupBox1.Controls.Add(Me.Radio_fecha_de_ingreso)
        Me.GroupBox1.Controls.Add(Me.dtp_fecha_de_ingreso)
        Me.GroupBox1.Controls.Add(Me.dtp_periodo_tributario)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 127)
        Me.GroupBox1.TabIndex = 120
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PERIODO TRIBUTARO:"
        '
        'Radio_periodo_tributario
        '
        Me.Radio_periodo_tributario.AutoSize = True
        Me.Radio_periodo_tributario.BackColor = System.Drawing.Color.Transparent
        Me.Radio_periodo_tributario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_periodo_tributario.Location = New System.Drawing.Point(27, 80)
        Me.Radio_periodo_tributario.Name = "Radio_periodo_tributario"
        Me.Radio_periodo_tributario.Size = New System.Drawing.Size(126, 20)
        Me.Radio_periodo_tributario.TabIndex = 119
        Me.Radio_periodo_tributario.Text = "P. TRIBUTARIO:"
        Me.Radio_periodo_tributario.UseVisualStyleBackColor = False
        '
        'Radio_fecha_de_ingreso
        '
        Me.Radio_fecha_de_ingreso.AutoSize = True
        Me.Radio_fecha_de_ingreso.BackColor = System.Drawing.Color.Transparent
        Me.Radio_fecha_de_ingreso.Checked = True
        Me.Radio_fecha_de_ingreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_fecha_de_ingreso.Location = New System.Drawing.Point(27, 34)
        Me.Radio_fecha_de_ingreso.Name = "Radio_fecha_de_ingreso"
        Me.Radio_fecha_de_ingreso.Size = New System.Drawing.Size(126, 20)
        Me.Radio_fecha_de_ingreso.TabIndex = 120
        Me.Radio_fecha_de_ingreso.TabStop = True
        Me.Radio_fecha_de_ingreso.Text = "F. DE INGRESO:"
        Me.Radio_fecha_de_ingreso.UseVisualStyleBackColor = False
        '
        'dtp_fecha_de_ingreso
        '
        Me.dtp_fecha_de_ingreso.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_de_ingreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_de_ingreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha_de_ingreso.Location = New System.Drawing.Point(155, 31)
        Me.dtp_fecha_de_ingreso.Name = "dtp_fecha_de_ingreso"
        Me.dtp_fecha_de_ingreso.Size = New System.Drawing.Size(119, 26)
        Me.dtp_fecha_de_ingreso.TabIndex = 8
        '
        'dtp_periodo_tributario
        '
        Me.dtp_periodo_tributario.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_periodo_tributario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_periodo_tributario.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_periodo_tributario.Location = New System.Drawing.Point(155, 77)
        Me.dtp_periodo_tributario.Name = "dtp_periodo_tributario"
        Me.dtp_periodo_tributario.Size = New System.Drawing.Size(119, 26)
        Me.dtp_periodo_tributario.TabIndex = 7
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.Transparent
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(177, 220)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(95, 40)
        Me.btn_cancelar.TabIndex = 122
        Me.btn_cancelar.Text = "SALIR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'btn_aceptar
        '
        Me.btn_aceptar.BackColor = System.Drawing.Color.Transparent
        Me.btn_aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.Image = CType(resources.GetObject("btn_aceptar.Image"), System.Drawing.Image)
        Me.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_aceptar.Location = New System.Drawing.Point(41, 220)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(95, 40)
        Me.btn_aceptar.TabIndex = 121
        Me.btn_aceptar.Text = "CARGAR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_aceptar.UseVisualStyleBackColor = False
        '
        'Form_cargar_libro_de_compra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 275)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_aceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_cargar_libro_de_compra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CARGAR LIBRO DE COMPRA"
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents dtp_periodo_tributario As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_de_ingreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Radio_periodo_tributario As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_fecha_de_ingreso As System.Windows.Forms.RadioButton
End Class
