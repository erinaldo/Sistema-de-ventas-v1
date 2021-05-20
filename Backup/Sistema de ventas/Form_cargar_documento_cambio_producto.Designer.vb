<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_cargar_documento_cambio_producto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_cargar_documento_cambio_producto))
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbl_mensaje = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Combo_sucursal = New System.Windows.Forms.ComboBox
        Me.txt_nro_documento = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.combo_documento = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_tipo_dte = New System.Windows.Forms.TextBox
        Me.txt_estado_doc = New System.Windows.Forms.TextBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.dtp_fecha_documento = New System.Windows.Forms.DateTimePicker
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker
        Me.dtp_fecha_doc_referencia = New System.Windows.Forms.DateTimePicker
        Me.txt_referencia_saldo = New System.Windows.Forms.TextBox
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
        Me.PictureBox_logo.TabIndex = 136
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lbl_mensaje)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Combo_sucursal)
        Me.GroupBox1.Controls.Add(Me.txt_nro_documento)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.combo_documento)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(7, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(299, 116)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(2, 9)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(295, 104)
        Me.lbl_mensaje.TabIndex = 322
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_mensaje.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 16)
        Me.Label3.TabIndex = 133
        Me.Label3.Text = "SUCURSAL:"
        '
        'Combo_sucursal
        '
        Me.Combo_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_sucursal.FormattingEnabled = True
        Me.Combo_sucursal.Location = New System.Drawing.Point(111, 17)
        Me.Combo_sucursal.Name = "Combo_sucursal"
        Me.Combo_sucursal.Size = New System.Drawing.Size(180, 24)
        Me.Combo_sucursal.TabIndex = 3
        '
        'txt_nro_documento
        '
        Me.txt_nro_documento.BackColor = System.Drawing.Color.White
        Me.txt_nro_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_documento.ForeColor = System.Drawing.Color.Black
        Me.txt_nro_documento.Location = New System.Drawing.Point(111, 83)
        Me.txt_nro_documento.Name = "txt_nro_documento"
        Me.txt_nro_documento.Size = New System.Drawing.Size(180, 24)
        Me.txt_nro_documento.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 16)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "DOCUMENTO:"
        '
        'combo_documento
        '
        Me.combo_documento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_documento.FormattingEnabled = True
        Me.combo_documento.Items.AddRange(New Object() {"BOLETA", "FACTURA", "GUIA", "SALDO A FAVOR", "VALE DE CAMBIO"})
        Me.combo_documento.Location = New System.Drawing.Point(111, 50)
        Me.combo_documento.Name = "combo_documento"
        Me.combo_documento.Size = New System.Drawing.Size(180, 24)
        Me.combo_documento.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 16)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "NUMERO DOC.:"
        '
        'txt_tipo_dte
        '
        Me.txt_tipo_dte.BackColor = System.Drawing.SystemColors.Control
        Me.txt_tipo_dte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tipo_dte.ForeColor = System.Drawing.Color.Black
        Me.txt_tipo_dte.Location = New System.Drawing.Point(323, 83)
        Me.txt_tipo_dte.Name = "txt_tipo_dte"
        Me.txt_tipo_dte.ReadOnly = True
        Me.txt_tipo_dte.Size = New System.Drawing.Size(100, 24)
        Me.txt_tipo_dte.TabIndex = 240
        Me.txt_tipo_dte.TabStop = False
        '
        'txt_estado_doc
        '
        Me.txt_estado_doc.BackColor = System.Drawing.Color.White
        Me.txt_estado_doc.Enabled = False
        Me.txt_estado_doc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_estado_doc.ForeColor = System.Drawing.Color.Black
        Me.txt_estado_doc.Location = New System.Drawing.Point(323, 119)
        Me.txt_estado_doc.Name = "txt_estado_doc"
        Me.txt_estado_doc.Size = New System.Drawing.Size(97, 24)
        Me.txt_estado_doc.TabIndex = 241
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.Transparent
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(176, 198)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(95, 40)
        Me.btn_cancelar.TabIndex = 5
        Me.btn_cancelar.Text = "    SALIR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'btn_aceptar
        '
        Me.btn_aceptar.BackColor = System.Drawing.Color.Transparent
        Me.btn_aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.Image = CType(resources.GetObject("btn_aceptar.Image"), System.Drawing.Image)
        Me.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_aceptar.Location = New System.Drawing.Point(42, 198)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(95, 40)
        Me.btn_aceptar.TabIndex = 4
        Me.btn_aceptar.Text = "CARGAR"
        Me.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_aceptar.UseVisualStyleBackColor = False
        '
        'dtp_fecha_documento
        '
        Me.dtp_fecha_documento.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_documento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha_documento.Location = New System.Drawing.Point(79, 97)
        Me.dtp_fecha_documento.Name = "dtp_fecha_documento"
        Me.dtp_fecha_documento.Size = New System.Drawing.Size(111, 24)
        Me.dtp_fecha_documento.TabIndex = 137
        Me.dtp_fecha_documento.TabStop = False
        '
        'dtp_fecha
        '
        Me.dtp_fecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha.Location = New System.Drawing.Point(131, 100)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(53, 24)
        Me.dtp_fecha.TabIndex = 272
        Me.dtp_fecha.TabStop = False
        '
        'dtp_fecha_doc_referencia
        '
        Me.dtp_fecha_doc_referencia.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_doc_referencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_doc_referencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha_doc_referencia.Location = New System.Drawing.Point(25, 100)
        Me.dtp_fecha_doc_referencia.Name = "dtp_fecha_doc_referencia"
        Me.dtp_fecha_doc_referencia.Size = New System.Drawing.Size(53, 24)
        Me.dtp_fecha_doc_referencia.TabIndex = 271
        Me.dtp_fecha_doc_referencia.TabStop = False
        '
        'txt_referencia_saldo
        '
        Me.txt_referencia_saldo.BackColor = System.Drawing.Color.White
        Me.txt_referencia_saldo.Enabled = False
        Me.txt_referencia_saldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_referencia_saldo.ForeColor = System.Drawing.Color.Black
        Me.txt_referencia_saldo.Location = New System.Drawing.Point(78, 107)
        Me.txt_referencia_saldo.Name = "txt_referencia_saldo"
        Me.txt_referencia_saldo.Size = New System.Drawing.Size(83, 24)
        Me.txt_referencia_saldo.TabIndex = 242
        '
        'Form_cargar_documento_cambio_producto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 244)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.txt_tipo_dte)
        Me.Controls.Add(Me.dtp_fecha_documento)
        Me.Controls.Add(Me.txt_estado_doc)
        Me.Controls.Add(Me.dtp_fecha)
        Me.Controls.Add(Me.txt_referencia_saldo)
        Me.Controls.Add(Me.dtp_fecha_doc_referencia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_cargar_documento_cambio_producto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CARGAR DOCUMENTO CAMBIO PRODUCTO"
        Me.TopMost = True
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_nro_documento As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents combo_documento As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_tipo_dte As System.Windows.Forms.TextBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents dtp_fecha_documento As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_doc_referencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_estado_doc As System.Windows.Forms.TextBox
    Friend WithEvents txt_referencia_saldo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Combo_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
End Class
