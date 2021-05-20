<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_cargar_compra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_cargar_compra))
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.combo_documento = New System.Windows.Forms.ComboBox
        Me.txt_nro_doc = New System.Windows.Forms.TextBox
        Me.txt_rut_proveedor = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Radio_impresora_1 = New System.Windows.Forms.RadioButton
        Me.Radio_impresora_2 = New System.Windows.Forms.RadioButton
        Me.GroupBox_electronicas = New System.Windows.Forms.GroupBox
        Me.radio_codigo_de_barra = New System.Windows.Forms.RadioButton
        Me.radio_solo_numeros = New System.Windows.Forms.RadioButton
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox_electronicas.SuspendLayout()
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
        Me.PictureBox_logo.TabIndex = 133
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.combo_documento)
        Me.GroupBox1.Controls.Add(Me.txt_nro_doc)
        Me.GroupBox1.Controls.Add(Me.txt_rut_proveedor)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 177)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 166)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DATOS DEL DOCUMENTO:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(56, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 16)
        Me.Label2.TabIndex = 135
        Me.Label2.Text = "DOCUMENTO:"
        '
        'combo_documento
        '
        Me.combo_documento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_documento.FormattingEnabled = True
        Me.combo_documento.Items.AddRange(New Object() {"FACTURA MANUAL", "GUIA MANUAL", "FACTURA ELECTRONICA", "GUIA ELECTRONICA", "-"})
        Me.combo_documento.Location = New System.Drawing.Point(54, 37)
        Me.combo_documento.Name = "combo_documento"
        Me.combo_documento.Size = New System.Drawing.Size(195, 26)
        Me.combo_documento.TabIndex = 134
        '
        'txt_nro_doc
        '
        Me.txt_nro_doc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_doc.Location = New System.Drawing.Point(54, 128)
        Me.txt_nro_doc.MaxLength = 11
        Me.txt_nro_doc.Name = "txt_nro_doc"
        Me.txt_nro_doc.Size = New System.Drawing.Size(195, 24)
        Me.txt_nro_doc.TabIndex = 2
        '
        'txt_rut_proveedor
        '
        Me.txt_rut_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut_proveedor.Location = New System.Drawing.Point(54, 84)
        Me.txt_rut_proveedor.MaxLength = 10
        Me.txt_rut_proveedor.Name = "txt_rut_proveedor"
        Me.txt_rut_proveedor.Size = New System.Drawing.Size(195, 24)
        Me.txt_rut_proveedor.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(55, 110)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(116, 16)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "N° DOCUMENTO:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(51, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "RUT PROVEEDOR:"
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.Transparent
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(180, 351)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(95, 40)
        Me.btn_cancelar.TabIndex = 4
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
        Me.btn_aceptar.Location = New System.Drawing.Point(37, 351)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(95, 40)
        Me.btn_aceptar.TabIndex = 3
        Me.btn_aceptar.Text = "CARGAR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Radio_impresora_1)
        Me.GroupBox2.Controls.Add(Me.Radio_impresora_2)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 127)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 50)
        Me.GroupBox2.TabIndex = 135
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "IMPRESORA:"
        '
        'Radio_impresora_1
        '
        Me.Radio_impresora_1.AutoSize = True
        Me.Radio_impresora_1.BackColor = System.Drawing.Color.Transparent
        Me.Radio_impresora_1.Checked = True
        Me.Radio_impresora_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_impresora_1.Location = New System.Drawing.Point(6, 20)
        Me.Radio_impresora_1.Name = "Radio_impresora_1"
        Me.Radio_impresora_1.Size = New System.Drawing.Size(116, 20)
        Me.Radio_impresora_1.TabIndex = 1
        Me.Radio_impresora_1.TabStop = True
        Me.Radio_impresora_1.Text = "IMPRESORA 1"
        Me.Radio_impresora_1.UseVisualStyleBackColor = False
        '
        'Radio_impresora_2
        '
        Me.Radio_impresora_2.AutoSize = True
        Me.Radio_impresora_2.BackColor = System.Drawing.Color.Transparent
        Me.Radio_impresora_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_impresora_2.Location = New System.Drawing.Point(165, 20)
        Me.Radio_impresora_2.Name = "Radio_impresora_2"
        Me.Radio_impresora_2.Size = New System.Drawing.Size(116, 20)
        Me.Radio_impresora_2.TabIndex = 2
        Me.Radio_impresora_2.Text = "IMPRESORA 2"
        Me.Radio_impresora_2.UseVisualStyleBackColor = False
        '
        'GroupBox_electronicas
        '
        Me.GroupBox_electronicas.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_electronicas.Controls.Add(Me.radio_codigo_de_barra)
        Me.GroupBox_electronicas.Controls.Add(Me.radio_solo_numeros)
        Me.GroupBox_electronicas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_electronicas.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox_electronicas.Name = "GroupBox_electronicas"
        Me.GroupBox_electronicas.Size = New System.Drawing.Size(300, 50)
        Me.GroupBox_electronicas.TabIndex = 134
        Me.GroupBox_electronicas.TabStop = False
        Me.GroupBox_electronicas.Text = "TIPO IMPRESION:"
        '
        'radio_codigo_de_barra
        '
        Me.radio_codigo_de_barra.AutoSize = True
        Me.radio_codigo_de_barra.BackColor = System.Drawing.Color.Transparent
        Me.radio_codigo_de_barra.Checked = True
        Me.radio_codigo_de_barra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radio_codigo_de_barra.Location = New System.Drawing.Point(6, 20)
        Me.radio_codigo_de_barra.Name = "radio_codigo_de_barra"
        Me.radio_codigo_de_barra.Size = New System.Drawing.Size(159, 20)
        Me.radio_codigo_de_barra.TabIndex = 1
        Me.radio_codigo_de_barra.TabStop = True
        Me.radio_codigo_de_barra.Text = "CODIGOS DE BARRA"
        Me.radio_codigo_de_barra.UseVisualStyleBackColor = False
        '
        'radio_solo_numeros
        '
        Me.radio_solo_numeros.AutoSize = True
        Me.radio_solo_numeros.BackColor = System.Drawing.Color.Transparent
        Me.radio_solo_numeros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radio_solo_numeros.Location = New System.Drawing.Point(165, 20)
        Me.radio_solo_numeros.Name = "radio_solo_numeros"
        Me.radio_solo_numeros.Size = New System.Drawing.Size(134, 20)
        Me.radio_solo_numeros.TabIndex = 2
        Me.radio_solo_numeros.Text = "SOLO NUMEROS"
        Me.radio_solo_numeros.UseVisualStyleBackColor = False
        '
        'Form_cargar_compra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 401)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox_electronicas)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_aceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_cargar_compra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CARGAR COMPRA"
        Me.TopMost = True
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox_electronicas.ResumeLayout(False)
        Me.GroupBox_electronicas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents txt_nro_doc As System.Windows.Forms.TextBox
    Friend WithEvents txt_rut_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Radio_impresora_1 As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_impresora_2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox_electronicas As System.Windows.Forms.GroupBox
    Friend WithEvents radio_codigo_de_barra As System.Windows.Forms.RadioButton
    Friend WithEvents radio_solo_numeros As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents combo_documento As System.Windows.Forms.ComboBox
End Class
