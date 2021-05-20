<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_venta_orden_de_compra
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.combo_documento = New System.Windows.Forms.ComboBox()
        Me.dtp_otro = New System.Windows.Forms.DateTimePicker()
        Me.dtp_hes = New System.Windows.Forms.DateTimePicker()
        Me.dtp_802 = New System.Windows.Forms.DateTimePicker()
        Me.dtp_801 = New System.Windows.Forms.DateTimePicker()
        Me.txt_801 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_otro = New System.Windows.Forms.TextBox()
        Me.txt_hes = New System.Windows.Forms.TextBox()
        Me.txt_802 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.combo_documento)
        Me.GroupBox1.Controls.Add(Me.dtp_otro)
        Me.GroupBox1.Controls.Add(Me.dtp_hes)
        Me.GroupBox1.Controls.Add(Me.dtp_802)
        Me.GroupBox1.Controls.Add(Me.dtp_801)
        Me.GroupBox1.Controls.Add(Me.txt_801)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_otro)
        Me.GroupBox1.Controls.Add(Me.txt_hes)
        Me.GroupBox1.Controls.Add(Me.txt_802)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(433, 156)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DATOS DEL DOCUMENTO:"
        '
        'combo_documento
        '
        Me.combo_documento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_documento.FormattingEnabled = True
        Me.combo_documento.Items.AddRange(New Object() {"801", "802", "HES"})
        Me.combo_documento.Location = New System.Drawing.Point(12, 118)
        Me.combo_documento.Name = "combo_documento"
        Me.combo_documento.Size = New System.Drawing.Size(189, 26)
        Me.combo_documento.TabIndex = 7
        '
        'dtp_otro
        '
        Me.dtp_otro.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_otro.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_otro.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_otro.Location = New System.Drawing.Point(313, 118)
        Me.dtp_otro.Name = "dtp_otro"
        Me.dtp_otro.Size = New System.Drawing.Size(111, 24)
        Me.dtp_otro.TabIndex = 9
        '
        'dtp_hes
        '
        Me.dtp_hes.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hes.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_hes.Location = New System.Drawing.Point(313, 85)
        Me.dtp_hes.Name = "dtp_hes"
        Me.dtp_hes.Size = New System.Drawing.Size(111, 24)
        Me.dtp_hes.TabIndex = 6
        '
        'dtp_802
        '
        Me.dtp_802.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_802.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_802.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_802.Location = New System.Drawing.Point(313, 52)
        Me.dtp_802.Name = "dtp_802"
        Me.dtp_802.Size = New System.Drawing.Size(111, 24)
        Me.dtp_802.TabIndex = 4
        '
        'dtp_801
        '
        Me.dtp_801.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_801.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_801.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_801.Location = New System.Drawing.Point(313, 19)
        Me.dtp_801.Name = "dtp_801"
        Me.dtp_801.Size = New System.Drawing.Size(111, 24)
        Me.dtp_801.TabIndex = 2
        '
        'txt_801
        '
        Me.txt_801.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_801.Location = New System.Drawing.Point(207, 19)
        Me.txt_801.MaxLength = 11
        Me.txt_801.Name = "txt_801"
        Me.txt_801.Size = New System.Drawing.Size(100, 24)
        Me.txt_801.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(175, 16)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "(801) ORDEN DE COMPRA:"
        '
        'txt_otro
        '
        Me.txt_otro.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_otro.Location = New System.Drawing.Point(207, 118)
        Me.txt_otro.MaxLength = 11
        Me.txt_otro.Name = "txt_otro"
        Me.txt_otro.Size = New System.Drawing.Size(100, 24)
        Me.txt_otro.TabIndex = 8
        '
        'txt_hes
        '
        Me.txt_hes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_hes.Location = New System.Drawing.Point(207, 85)
        Me.txt_hes.MaxLength = 11
        Me.txt_hes.Name = "txt_hes"
        Me.txt_hes.Size = New System.Drawing.Size(100, 24)
        Me.txt_hes.TabIndex = 5
        '
        'txt_802
        '
        Me.txt_802.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_802.Location = New System.Drawing.Point(207, 52)
        Me.txt_802.MaxLength = 11
        Me.txt_802.Name = "txt_802"
        Me.txt_802.Size = New System.Drawing.Size(100, 24)
        Me.txt_802.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(28, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(177, 16)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "(HES) HOJA DE ENTRADA:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(197, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "(802) NUMERO DE ATENCION:"
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(7, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 139
        Me.PictureBox_logo.TabStop = False
        '
        'btn_aceptar
        '
        Me.btn_aceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btn_aceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_aceptar.FlatAppearance.BorderSize = 0
        Me.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_aceptar.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.ForeColor = System.Drawing.Color.White
        Me.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_aceptar.Location = New System.Drawing.Point(7, 238)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(432, 40)
        Me.btn_aceptar.TabIndex = 140
        Me.btn_aceptar.Text = "ACEPTAR"
        Me.btn_aceptar.UseVisualStyleBackColor = False
        '
        'Form_venta_orden_de_compra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 284)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_venta_orden_de_compra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ORDEN DE COMPRA"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox_logo As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txt_hes As TextBox
    Friend WithEvents txt_802 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_801 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_otro As TextBox
    Friend WithEvents dtp_otro As DateTimePicker
    Friend WithEvents dtp_hes As DateTimePicker
    Friend WithEvents dtp_802 As DateTimePicker
    Friend WithEvents dtp_801 As DateTimePicker
    Friend WithEvents combo_documento As ComboBox
    Friend WithEvents btn_aceptar As Button
End Class
