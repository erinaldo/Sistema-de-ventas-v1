<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_datos_solicitud_cotizacion
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
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txt_marca_automovil = New System.Windows.Forms.TextBox()
        Me.txt_año = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_nro_motor = New System.Windows.Forms.TextBox()
        Me.txt_cilindrada = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Combo_tipo_motor = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_observacion = New System.Windows.Forms.Label()
        Me.txt_observacion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_telefono_cliente = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_nombre_cliente = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_nro_chasis = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_modelo_vehiculo = New System.Windows.Forms.TextBox()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.txt_marca_automovil)
        Me.GroupBox4.Controls.Add(Me.txt_año)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.txt_nro_motor)
        Me.GroupBox4.Controls.Add(Me.txt_cilindrada)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Combo_tipo_motor)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.lbl_observacion)
        Me.GroupBox4.Controls.Add(Me.txt_observacion)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.txt_telefono_cliente)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.txt_nombre_cliente)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.txt_nro_chasis)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.txt_modelo_vehiculo)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(300, 580)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "DATOS DEL PRODUCTO"
        '
        'txt_marca_automovil
        '
        Me.txt_marca_automovil.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_marca_automovil.Location = New System.Drawing.Point(7, 34)
        Me.txt_marca_automovil.MaxLength = 45
        Me.txt_marca_automovil.Name = "txt_marca_automovil"
        Me.txt_marca_automovil.Size = New System.Drawing.Size(286, 24)
        Me.txt_marca_automovil.TabIndex = 1
        '
        'txt_año
        '
        Me.txt_año.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_año.Location = New System.Drawing.Point(7, 164)
        Me.txt_año.MaxLength = 4
        Me.txt_año.Name = "txt_año"
        Me.txt_año.Size = New System.Drawing.Size(286, 24)
        Me.txt_año.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 146)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 16)
        Me.Label9.TabIndex = 252
        Me.Label9.Text = "AÑO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 279)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 16)
        Me.Label2.TabIndex = 249
        Me.Label2.Text = "NRO. MOTOR"
        '
        'txt_nro_motor
        '
        Me.txt_nro_motor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_motor.Location = New System.Drawing.Point(7, 297)
        Me.txt_nro_motor.MaxLength = 20
        Me.txt_nro_motor.Name = "txt_nro_motor"
        Me.txt_nro_motor.Size = New System.Drawing.Size(286, 24)
        Me.txt_nro_motor.TabIndex = 7
        '
        'txt_cilindrada
        '
        Me.txt_cilindrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cilindrada.Location = New System.Drawing.Point(7, 209)
        Me.txt_cilindrada.MaxLength = 4
        Me.txt_cilindrada.Name = "txt_cilindrada"
        Me.txt_cilindrada.Size = New System.Drawing.Size(286, 24)
        Me.txt_cilindrada.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 191)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(195, 16)
        Me.Label8.TabIndex = 248
        Me.Label8.Text = "CILINDRADA (EJEMPLO: 1400)"
        '
        'Combo_tipo_motor
        '
        Me.Combo_tipo_motor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_tipo_motor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_tipo_motor.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_tipo_motor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_tipo_motor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_tipo_motor.FormattingEnabled = True
        Me.Combo_tipo_motor.Items.AddRange(New Object() {"BENCINERO", "PETROLERO", "-"})
        Me.Combo_tipo_motor.Location = New System.Drawing.Point(7, 120)
        Me.Combo_tipo_motor.MaxLength = 12
        Me.Combo_tipo_motor.Name = "Combo_tipo_motor"
        Me.Combo_tipo_motor.Size = New System.Drawing.Size(286, 24)
        Me.Combo_tipo_motor.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 16)
        Me.Label3.TabIndex = 246
        Me.Label3.Text = "TIPO MOTOR:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(217, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "MARCA (EJEMPLO: CHEVROLET)"
        '
        'lbl_observacion
        '
        Me.lbl_observacion.Location = New System.Drawing.Point(7, 322)
        Me.lbl_observacion.Name = "lbl_observacion"
        Me.lbl_observacion.Size = New System.Drawing.Size(290, 51)
        Me.lbl_observacion.TabIndex = 9
        Me.lbl_observacion.Text = "OBSERVACION ( EJEMPLO: HATCHBACK, 5 PUERTAS, STATION WAGON, RETORNADO, ETC.)"
        '
        'txt_observacion
        '
        Me.txt_observacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_observacion.Location = New System.Drawing.Point(7, 373)
        Me.txt_observacion.MaxLength = 50
        Me.txt_observacion.Multiline = True
        Me.txt_observacion.Name = "txt_observacion"
        Me.txt_observacion.Size = New System.Drawing.Size(286, 110)
        Me.txt_observacion.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 529)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(142, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "TELEFONO CLIENTE:"
        '
        'txt_telefono_cliente
        '
        Me.txt_telefono_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_telefono_cliente.Location = New System.Drawing.Point(7, 547)
        Me.txt_telefono_cliente.MaxLength = 11
        Me.txt_telefono_cliente.Name = "txt_telefono_cliente"
        Me.txt_telefono_cliente.Size = New System.Drawing.Size(286, 24)
        Me.txt_telefono_cliente.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 485)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "NOMBRE CLIENTE:"
        '
        'txt_nombre_cliente
        '
        Me.txt_nombre_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_cliente.Location = New System.Drawing.Point(7, 503)
        Me.txt_nombre_cliente.MaxLength = 45
        Me.txt_nombre_cliente.Name = "txt_nombre_cliente"
        Me.txt_nombre_cliente.Size = New System.Drawing.Size(286, 24)
        Me.txt_nombre_cliente.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 235)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(175, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "NRO. CHASIS (17 DIGITOS)"
        '
        'txt_nro_chasis
        '
        Me.txt_nro_chasis.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_chasis.Location = New System.Drawing.Point(7, 253)
        Me.txt_nro_chasis.MaxLength = 17
        Me.txt_nro_chasis.Name = "txt_nro_chasis"
        Me.txt_nro_chasis.Size = New System.Drawing.Size(286, 24)
        Me.txt_nro_chasis.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(184, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "MODELO ( EJEMPLO: AVEO)"
        '
        'txt_modelo_vehiculo
        '
        Me.txt_modelo_vehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_modelo_vehiculo.Location = New System.Drawing.Point(7, 76)
        Me.txt_modelo_vehiculo.MaxLength = 45
        Me.txt_modelo_vehiculo.Name = "txt_modelo_vehiculo"
        Me.txt_modelo_vehiculo.Size = New System.Drawing.Size(286, 24)
        Me.txt_modelo_vehiculo.TabIndex = 2
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
        Me.btn_aceptar.Location = New System.Drawing.Point(6, 662)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(300, 40)
        Me.btn_aceptar.TabIndex = 2
        Me.btn_aceptar.Text = "ACEPTAR"
        Me.btn_aceptar.UseVisualStyleBackColor = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 244
        Me.PictureBox_logo.TabStop = False
        '
        'Form_datos_solicitud_cotizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 709)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.GroupBox4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_datos_solicitud_cotizacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DATOS SOLICITUD COTIZACION"
        Me.TopMost = True
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lbl_observacion As Label
    Friend WithEvents txt_observacion As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_telefono_cliente As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_nombre_cliente As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_nro_chasis As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_modelo_vehiculo As TextBox
    Friend WithEvents btn_aceptar As Button
    Friend WithEvents PictureBox_logo As PictureBox
    Friend WithEvents txt_cilindrada As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Combo_tipo_motor As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_nro_motor As TextBox
    Friend WithEvents txt_año As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txt_marca_automovil As TextBox
End Class
