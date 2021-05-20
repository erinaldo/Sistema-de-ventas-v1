<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_numeros_impresion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_numeros_impresion))
        Me.txt_boleta = New System.Windows.Forms.TextBox
        Me.txt_factura = New System.Windows.Forms.TextBox
        Me.txt_guia = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_modificar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Radio_abono = New System.Windows.Forms.RadioButton
        Me.Radio_nota_credito = New System.Windows.Forms.RadioButton
        Me.Radio_nota_debito = New System.Windows.Forms.RadioButton
        Me.txt_nota_credito = New System.Windows.Forms.TextBox
        Me.txt_abono = New System.Windows.Forms.TextBox
        Me.Radio_guia = New System.Windows.Forms.RadioButton
        Me.txt_cotizacion = New System.Windows.Forms.TextBox
        Me.Radio_factura = New System.Windows.Forms.RadioButton
        Me.Radio_letra = New System.Windows.Forms.RadioButton
        Me.Radio_boleta = New System.Windows.Forms.RadioButton
        Me.Radio_cotizacion = New System.Windows.Forms.RadioButton
        Me.txt_letra = New System.Windows.Forms.TextBox
        Me.txt_nota_debito = New System.Windows.Forms.TextBox
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_boleta
        '
        Me.txt_boleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_boleta.Location = New System.Drawing.Point(171, 26)
        Me.txt_boleta.MaxLength = 11
        Me.txt_boleta.Name = "txt_boleta"
        Me.txt_boleta.Size = New System.Drawing.Size(118, 24)
        Me.txt_boleta.TabIndex = 1
        Me.txt_boleta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_factura
        '
        Me.txt_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_factura.Location = New System.Drawing.Point(171, 69)
        Me.txt_factura.MaxLength = 11
        Me.txt_factura.Name = "txt_factura"
        Me.txt_factura.Size = New System.Drawing.Size(118, 24)
        Me.txt_factura.TabIndex = 2
        Me.txt_factura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_guia
        '
        Me.txt_guia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_guia.Location = New System.Drawing.Point(171, 112)
        Me.txt_guia.MaxLength = 11
        Me.txt_guia.Name = "txt_guia"
        Me.txt_guia.Size = New System.Drawing.Size(118, 24)
        Me.txt_guia.TabIndex = 3
        Me.txt_guia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btn_salir)
        Me.GroupBox2.Controls.Add(Me.btn_cancelar)
        Me.GroupBox2.Controls.Add(Me.btn_modificar)
        Me.GroupBox2.Controls.Add(Me.btn_guardar)
        Me.GroupBox2.Location = New System.Drawing.Point(594, 77)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(107, 196)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(5, 148)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
        Me.btn_salir.TabIndex = 11
        Me.btn_salir.Text = "SALIR"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.Transparent
        Me.btn_cancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(6, 103)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(95, 40)
        Me.btn_cancelar.TabIndex = 10
        Me.btn_cancelar.Text = "CANCELAR"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'btn_modificar
        '
        Me.btn_modificar.BackColor = System.Drawing.Color.Transparent
        Me.btn_modificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_modificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_modificar.Image = CType(resources.GetObject("btn_modificar.Image"), System.Drawing.Image)
        Me.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_modificar.Location = New System.Drawing.Point(6, 13)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(95, 40)
        Me.btn_modificar.TabIndex = 0
        Me.btn_modificar.Text = "MODIFICAR"
        Me.btn_modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_modificar.UseVisualStyleBackColor = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.Transparent
        Me.btn_guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.Location = New System.Drawing.Point(6, 58)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(95, 40)
        Me.btn_guardar.TabIndex = 9
        Me.btn_guardar.Text = "GUARDAR"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Radio_abono)
        Me.GroupBox1.Controls.Add(Me.Radio_nota_credito)
        Me.GroupBox1.Controls.Add(Me.Radio_nota_debito)
        Me.GroupBox1.Controls.Add(Me.txt_nota_credito)
        Me.GroupBox1.Controls.Add(Me.txt_abono)
        Me.GroupBox1.Controls.Add(Me.Radio_guia)
        Me.GroupBox1.Controls.Add(Me.txt_cotizacion)
        Me.GroupBox1.Controls.Add(Me.Radio_factura)
        Me.GroupBox1.Controls.Add(Me.Radio_letra)
        Me.GroupBox1.Controls.Add(Me.Radio_boleta)
        Me.GroupBox1.Controls.Add(Me.Radio_cotizacion)
        Me.GroupBox1.Controls.Add(Me.txt_boleta)
        Me.GroupBox1.Controls.Add(Me.txt_letra)
        Me.GroupBox1.Controls.Add(Me.txt_factura)
        Me.GroupBox1.Controls.Add(Me.txt_nota_debito)
        Me.GroupBox1.Controls.Add(Me.txt_guia)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(7, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(581, 196)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Radio_abono
        '
        Me.Radio_abono.AutoSize = True
        Me.Radio_abono.BackColor = System.Drawing.Color.Transparent
        Me.Radio_abono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_abono.Location = New System.Drawing.Point(364, 158)
        Me.Radio_abono.Name = "Radio_abono"
        Me.Radio_abono.Size = New System.Drawing.Size(86, 20)
        Me.Radio_abono.TabIndex = 10
        Me.Radio_abono.Text = "ABONOS:"
        Me.Radio_abono.UseVisualStyleBackColor = False
        '
        'Radio_nota_credito
        '
        Me.Radio_nota_credito.AutoSize = True
        Me.Radio_nota_credito.BackColor = System.Drawing.Color.Transparent
        Me.Radio_nota_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_nota_credito.Location = New System.Drawing.Point(8, 158)
        Me.Radio_nota_credito.Name = "Radio_nota_credito"
        Me.Radio_nota_credito.Size = New System.Drawing.Size(161, 20)
        Me.Radio_nota_credito.TabIndex = 4
        Me.Radio_nota_credito.Text = "NOTAS DE CREDITO:"
        Me.Radio_nota_credito.UseVisualStyleBackColor = False
        '
        'Radio_nota_debito
        '
        Me.Radio_nota_debito.AutoSize = True
        Me.Radio_nota_debito.BackColor = System.Drawing.Color.Transparent
        Me.Radio_nota_debito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_nota_debito.Location = New System.Drawing.Point(299, 29)
        Me.Radio_nota_debito.Name = "Radio_nota_debito"
        Me.Radio_nota_debito.Size = New System.Drawing.Size(151, 20)
        Me.Radio_nota_debito.TabIndex = 7
        Me.Radio_nota_debito.Text = "NOTAS DE DEBITO:"
        Me.Radio_nota_debito.UseVisualStyleBackColor = False
        '
        'txt_nota_credito
        '
        Me.txt_nota_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nota_credito.Location = New System.Drawing.Point(171, 155)
        Me.txt_nota_credito.MaxLength = 11
        Me.txt_nota_credito.Name = "txt_nota_credito"
        Me.txt_nota_credito.Size = New System.Drawing.Size(118, 24)
        Me.txt_nota_credito.TabIndex = 4
        Me.txt_nota_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_abono
        '
        Me.txt_abono.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_abono.Location = New System.Drawing.Point(452, 155)
        Me.txt_abono.MaxLength = 11
        Me.txt_abono.Name = "txt_abono"
        Me.txt_abono.Size = New System.Drawing.Size(118, 24)
        Me.txt_abono.TabIndex = 4
        Me.txt_abono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Radio_guia
        '
        Me.Radio_guia.AutoSize = True
        Me.Radio_guia.BackColor = System.Drawing.Color.Transparent
        Me.Radio_guia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_guia.Location = New System.Drawing.Point(99, 115)
        Me.Radio_guia.Name = "Radio_guia"
        Me.Radio_guia.Size = New System.Drawing.Size(70, 20)
        Me.Radio_guia.TabIndex = 2
        Me.Radio_guia.Text = "GUIAS:"
        Me.Radio_guia.UseVisualStyleBackColor = False
        '
        'txt_cotizacion
        '
        Me.txt_cotizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cotizacion.Location = New System.Drawing.Point(452, 69)
        Me.txt_cotizacion.MaxLength = 11
        Me.txt_cotizacion.Name = "txt_cotizacion"
        Me.txt_cotizacion.Size = New System.Drawing.Size(118, 24)
        Me.txt_cotizacion.TabIndex = 2
        Me.txt_cotizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Radio_factura
        '
        Me.Radio_factura.AutoSize = True
        Me.Radio_factura.BackColor = System.Drawing.Color.Transparent
        Me.Radio_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_factura.Location = New System.Drawing.Point(67, 72)
        Me.Radio_factura.Name = "Radio_factura"
        Me.Radio_factura.Size = New System.Drawing.Size(102, 20)
        Me.Radio_factura.TabIndex = 2
        Me.Radio_factura.Text = "FACTURAS:"
        Me.Radio_factura.UseVisualStyleBackColor = False
        '
        'Radio_letra
        '
        Me.Radio_letra.AutoSize = True
        Me.Radio_letra.BackColor = System.Drawing.Color.Transparent
        Me.Radio_letra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_letra.Location = New System.Drawing.Point(368, 115)
        Me.Radio_letra.Name = "Radio_letra"
        Me.Radio_letra.Size = New System.Drawing.Size(82, 20)
        Me.Radio_letra.TabIndex = 8
        Me.Radio_letra.Text = "LETRAS:"
        Me.Radio_letra.UseVisualStyleBackColor = False
        '
        'Radio_boleta
        '
        Me.Radio_boleta.AutoSize = True
        Me.Radio_boleta.BackColor = System.Drawing.Color.Transparent
        Me.Radio_boleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_boleta.Location = New System.Drawing.Point(78, 29)
        Me.Radio_boleta.Name = "Radio_boleta"
        Me.Radio_boleta.Size = New System.Drawing.Size(91, 20)
        Me.Radio_boleta.TabIndex = 2
        Me.Radio_boleta.Text = "BOLETAS:"
        Me.Radio_boleta.UseVisualStyleBackColor = False
        '
        'Radio_cotizacion
        '
        Me.Radio_cotizacion.AutoSize = True
        Me.Radio_cotizacion.BackColor = System.Drawing.Color.Transparent
        Me.Radio_cotizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_cotizacion.Location = New System.Drawing.Point(323, 72)
        Me.Radio_cotizacion.Name = "Radio_cotizacion"
        Me.Radio_cotizacion.Size = New System.Drawing.Size(127, 20)
        Me.Radio_cotizacion.TabIndex = 2
        Me.Radio_cotizacion.Text = "COTIZACIONES:"
        Me.Radio_cotizacion.UseVisualStyleBackColor = False
        '
        'txt_letra
        '
        Me.txt_letra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_letra.Location = New System.Drawing.Point(452, 112)
        Me.txt_letra.MaxLength = 11
        Me.txt_letra.Name = "txt_letra"
        Me.txt_letra.Size = New System.Drawing.Size(118, 24)
        Me.txt_letra.TabIndex = 3
        Me.txt_letra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_nota_debito
        '
        Me.txt_nota_debito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nota_debito.Location = New System.Drawing.Point(452, 26)
        Me.txt_nota_debito.MaxLength = 11
        Me.txt_nota_debito.Name = "txt_nota_debito"
        Me.txt_nota_debito.Size = New System.Drawing.Size(118, 24)
        Me.txt_nota_debito.TabIndex = 1
        Me.txt_nota_debito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 69
        Me.PictureBox_logo.TabStop = False
        '
        'Form_numeros_impresion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 279)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_numeros_impresion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NUMEROS DE IMPRESION"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_boleta As System.Windows.Forms.TextBox
    Friend WithEvents txt_factura As System.Windows.Forms.TextBox
    Friend WithEvents txt_guia As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_modificar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Radio_cotizacion As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_guia As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_factura As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_boleta As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents Radio_nota_credito As System.Windows.Forms.RadioButton
    Friend WithEvents txt_nota_credito As System.Windows.Forms.TextBox
    Friend WithEvents Radio_nota_debito As System.Windows.Forms.RadioButton
    Friend WithEvents txt_nota_debito As System.Windows.Forms.TextBox
    Friend WithEvents Radio_letra As System.Windows.Forms.RadioButton
    Friend WithEvents txt_letra As System.Windows.Forms.TextBox
    Friend WithEvents Radio_abono As System.Windows.Forms.RadioButton
    Friend WithEvents txt_abono As System.Windows.Forms.TextBox
    Friend WithEvents txt_cotizacion As System.Windows.Forms.TextBox
End Class
