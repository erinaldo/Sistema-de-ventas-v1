<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_exportar_detalle_compras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_exportar_detalle_compras))
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox_tipo_precio = New System.Windows.Forms.GroupBox
        Me.Radio_compra = New System.Windows.Forms.RadioButton
        Me.Radio_detalle_compra = New System.Windows.Forms.RadioButton
        Me.btn_exportar_excel = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_tipo_precio.SuspendLayout()
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
        Me.PictureBox_logo.TabIndex = 311
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox_tipo_precio
        '
        Me.GroupBox_tipo_precio.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_tipo_precio.Controls.Add(Me.Radio_compra)
        Me.GroupBox_tipo_precio.Controls.Add(Me.Radio_detalle_compra)
        Me.GroupBox_tipo_precio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_tipo_precio.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox_tipo_precio.Name = "GroupBox_tipo_precio"
        Me.GroupBox_tipo_precio.Size = New System.Drawing.Size(300, 65)
        Me.GroupBox_tipo_precio.TabIndex = 312
        Me.GroupBox_tipo_precio.TabStop = False
        '
        'Radio_compra
        '
        Me.Radio_compra.AutoSize = True
        Me.Radio_compra.Checked = True
        Me.Radio_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_compra.Location = New System.Drawing.Point(32, 25)
        Me.Radio_compra.Name = "Radio_compra"
        Me.Radio_compra.Size = New System.Drawing.Size(84, 20)
        Me.Radio_compra.TabIndex = 0
        Me.Radio_compra.TabStop = True
        Me.Radio_compra.Text = "COMPRA"
        Me.Radio_compra.UseVisualStyleBackColor = True
        '
        'Radio_detalle_compra
        '
        Me.Radio_detalle_compra.AutoSize = True
        Me.Radio_detalle_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_detalle_compra.Location = New System.Drawing.Point(121, 25)
        Me.Radio_detalle_compra.Name = "Radio_detalle_compra"
        Me.Radio_detalle_compra.Size = New System.Drawing.Size(147, 20)
        Me.Radio_detalle_compra.TabIndex = 0
        Me.Radio_detalle_compra.Text = "DETALLE COMPRA"
        Me.Radio_detalle_compra.UseVisualStyleBackColor = True
        '
        'btn_exportar_excel
        '
        Me.btn_exportar_excel.BackColor = System.Drawing.Color.Transparent
        Me.btn_exportar_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_exportar_excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar_excel.Image = CType(resources.GetObject("btn_exportar_excel.Image"), System.Drawing.Image)
        Me.btn_exportar_excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exportar_excel.Location = New System.Drawing.Point(61, 147)
        Me.btn_exportar_excel.Name = "btn_exportar_excel"
        Me.btn_exportar_excel.Size = New System.Drawing.Size(95, 40)
        Me.btn_exportar_excel.TabIndex = 3
        Me.btn_exportar_excel.Text = "EXPORTAR"
        Me.btn_exportar_excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exportar_excel.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(161, 147)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
        Me.btn_salir.TabIndex = 4
        Me.btn_salir.Text = "SALIR"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'Form_exportar_detalle_compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 193)
        Me.Controls.Add(Me.btn_exportar_excel)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.GroupBox_tipo_precio)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_exportar_detalle_compras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EXPORTAR COMPRAS"
        Me.TopMost = True
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_tipo_precio.ResumeLayout(False)
        Me.GroupBox_tipo_precio.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox_tipo_precio As System.Windows.Forms.GroupBox
    Friend WithEvents Radio_compra As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_detalle_compra As System.Windows.Forms.RadioButton
    Friend WithEvents btn_exportar_excel As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
End Class
