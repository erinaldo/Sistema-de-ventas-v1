<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_cargar_fecha_cheque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_cargar_fecha_cheque))
        Me.GroupBox_electronicas = New System.Windows.Forms.GroupBox
        Me.dtp_hasta_cheque = New System.Windows.Forms.DateTimePicker
        Me.Radio_rango_cheques = New System.Windows.Forms.RadioButton
        Me.dtp_desde_cheque = New System.Windows.Forms.DateTimePicker
        Me.dtp_hasta_caja = New System.Windows.Forms.DateTimePicker
        Me.radio_rango_fechas = New System.Windows.Forms.RadioButton
        Me.dtp_desde_caja = New System.Windows.Forms.DateTimePicker
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.GroupBox_electronicas.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox_electronicas
        '
        Me.GroupBox_electronicas.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_electronicas.Controls.Add(Me.dtp_hasta_cheque)
        Me.GroupBox_electronicas.Controls.Add(Me.Radio_rango_cheques)
        Me.GroupBox_electronicas.Controls.Add(Me.dtp_desde_cheque)
        Me.GroupBox_electronicas.Controls.Add(Me.dtp_hasta_caja)
        Me.GroupBox_electronicas.Controls.Add(Me.radio_rango_fechas)
        Me.GroupBox_electronicas.Controls.Add(Me.dtp_desde_caja)
        Me.GroupBox_electronicas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_electronicas.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox_electronicas.Name = "GroupBox_electronicas"
        Me.GroupBox_electronicas.Size = New System.Drawing.Size(300, 147)
        Me.GroupBox_electronicas.TabIndex = 1
        Me.GroupBox_electronicas.TabStop = False
        Me.GroupBox_electronicas.Text = "OPCIONES DE FECHAS:"
        '
        'dtp_hasta_cheque
        '
        Me.dtp_hasta_cheque.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hasta_cheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hasta_cheque.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_hasta_cheque.Location = New System.Drawing.Point(157, 43)
        Me.dtp_hasta_cheque.Name = "dtp_hasta_cheque"
        Me.dtp_hasta_cheque.Size = New System.Drawing.Size(111, 24)
        Me.dtp_hasta_cheque.TabIndex = 3
        '
        'Radio_rango_cheques
        '
        Me.Radio_rango_cheques.AutoSize = True
        Me.Radio_rango_cheques.BackColor = System.Drawing.Color.Transparent
        Me.Radio_rango_cheques.Checked = True
        Me.Radio_rango_cheques.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_rango_cheques.Location = New System.Drawing.Point(23, 21)
        Me.Radio_rango_cheques.Name = "Radio_rango_cheques"
        Me.Radio_rango_cheques.Size = New System.Drawing.Size(257, 20)
        Me.Radio_rango_cheques.TabIndex = 1
        Me.Radio_rango_cheques.TabStop = True
        Me.Radio_rango_cheques.Text = "RANGO DE FECHAS PARA CHEQUE:"
        Me.Radio_rango_cheques.UseVisualStyleBackColor = False
        '
        'dtp_desde_cheque
        '
        Me.dtp_desde_cheque.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_desde_cheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_desde_cheque.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_desde_cheque.Location = New System.Drawing.Point(40, 43)
        Me.dtp_desde_cheque.Name = "dtp_desde_cheque"
        Me.dtp_desde_cheque.Size = New System.Drawing.Size(111, 24)
        Me.dtp_desde_cheque.TabIndex = 2
        '
        'dtp_hasta_caja
        '
        Me.dtp_hasta_caja.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hasta_caja.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hasta_caja.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_hasta_caja.Location = New System.Drawing.Point(157, 107)
        Me.dtp_hasta_caja.Name = "dtp_hasta_caja"
        Me.dtp_hasta_caja.Size = New System.Drawing.Size(111, 24)
        Me.dtp_hasta_caja.TabIndex = 8
        '
        'radio_rango_fechas
        '
        Me.radio_rango_fechas.AutoSize = True
        Me.radio_rango_fechas.BackColor = System.Drawing.Color.Transparent
        Me.radio_rango_fechas.Checked = True
        Me.radio_rango_fechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radio_rango_fechas.Location = New System.Drawing.Point(23, 85)
        Me.radio_rango_fechas.Name = "radio_rango_fechas"
        Me.radio_rango_fechas.Size = New System.Drawing.Size(234, 20)
        Me.radio_rango_fechas.TabIndex = 6
        Me.radio_rango_fechas.TabStop = True
        Me.radio_rango_fechas.Text = "RANGO DE FECHAS PARA CAJA:"
        Me.radio_rango_fechas.UseVisualStyleBackColor = False
        '
        'dtp_desde_caja
        '
        Me.dtp_desde_caja.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_desde_caja.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_desde_caja.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_desde_caja.Location = New System.Drawing.Point(40, 107)
        Me.dtp_desde_caja.Name = "dtp_desde_caja"
        Me.dtp_desde_caja.Size = New System.Drawing.Size(111, 24)
        Me.dtp_desde_caja.TabIndex = 7
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 137
        Me.PictureBox_logo.TabStop = False
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.Transparent
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(176, 229)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(95, 40)
        Me.btn_cancelar.TabIndex = 3
        Me.btn_cancelar.Text = "SALIR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_aceptar
        '
        Me.btn_aceptar.BackColor = System.Drawing.Color.Transparent
        Me.btn_aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.Image = CType(resources.GetObject("btn_aceptar.Image"), System.Drawing.Image)
        Me.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_aceptar.Location = New System.Drawing.Point(41, 229)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(95, 40)
        Me.btn_aceptar.TabIndex = 2
        Me.btn_aceptar.Text = "CARGAR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'Form_cargar_fecha_cheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 275)
        Me.Controls.Add(Me.GroupBox_electronicas)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_aceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_cargar_fecha_cheque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FECHA CHEQUE"
        Me.TopMost = True
        Me.GroupBox_electronicas.ResumeLayout(False)
        Me.GroupBox_electronicas.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox_electronicas As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents dtp_hasta_caja As System.Windows.Forms.DateTimePicker
    Friend WithEvents radio_rango_fechas As System.Windows.Forms.RadioButton
    Friend WithEvents dtp_desde_caja As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_hasta_cheque As System.Windows.Forms.DateTimePicker
    Friend WithEvents Radio_rango_cheques As System.Windows.Forms.RadioButton
    Friend WithEvents dtp_desde_cheque As System.Windows.Forms.DateTimePicker
End Class
