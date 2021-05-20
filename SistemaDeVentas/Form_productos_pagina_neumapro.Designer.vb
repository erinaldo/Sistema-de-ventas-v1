<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_productos_pagina_neumapro
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btn_exportar_excel = New System.Windows.Forms.Button()
        Me.grilla_estado_de_cuenta = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_exportar_csv = New System.Windows.Forms.Button()
        Me.lbl_mensaje = New System.Windows.Forms.Label()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txt_busqueda = New System.Windows.Forms.TextBox()
        Me.lbl_resultado = New System.Windows.Forms.Label()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.grilla_carga = New System.Windows.Forms.DataGridView()
        Me.grilla_velocidad = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Barra_titulo1 = New proyecto_sistema_ventas.Barra_titulo()
        Me.btn_validar = New System.Windows.Forms.Button()
        CType(Me.grilla_estado_de_cuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_carga, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_velocidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_exportar_excel
        '
        Me.btn_exportar_excel.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.btn_exportar_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_exportar_excel.FlatAppearance.BorderSize = 0
        Me.btn_exportar_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exportar_excel.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar_excel.ForeColor = System.Drawing.Color.White
        Me.btn_exportar_excel.Location = New System.Drawing.Point(806, 118)
        Me.btn_exportar_excel.Name = "btn_exportar_excel"
        Me.btn_exportar_excel.Size = New System.Drawing.Size(100, 50)
        Me.btn_exportar_excel.TabIndex = 321
        Me.btn_exportar_excel.Text = "EXCEL"
        Me.btn_exportar_excel.UseVisualStyleBackColor = False
        '
        'grilla_estado_de_cuenta
        '
        Me.grilla_estado_de_cuenta.AllowUserToAddRows = False
        Me.grilla_estado_de_cuenta.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_estado_de_cuenta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grilla_estado_de_cuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_estado_de_cuenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column15, Me.Column4, Me.Column13, Me.Column6, Me.Column10, Me.Column9})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla_estado_de_cuenta.DefaultCellStyle = DataGridViewCellStyle8
        Me.grilla_estado_de_cuenta.Location = New System.Drawing.Point(6, 173)
        Me.grilla_estado_de_cuenta.Name = "grilla_estado_de_cuenta"
        Me.grilla_estado_de_cuenta.ReadOnly = True
        Me.grilla_estado_de_cuenta.Size = New System.Drawing.Size(1006, 512)
        Me.grilla_estado_de_cuenta.TabIndex = 325
        Me.grilla_estado_de_cuenta.TabStop = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "SKU"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 80
        '
        'Column2
        '
        Me.Column2.HeaderText = "Nombre"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 81
        '
        'Column3
        '
        Me.Column3.HeaderText = "Descripción"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 80
        '
        'Column15
        '
        Me.Column15.HeaderText = "Inventario"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        Me.Column15.Width = 80
        '
        'Column4
        '
        Me.Column4.HeaderText = "Precio normal"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 81
        '
        'Column13
        '
        Me.Column13.HeaderText = "Categorías"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Width = 80
        '
        'Column6
        '
        Me.Column6.HeaderText = "Etiquetas"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 80
        '
        'Column10
        '
        Me.Column10.HeaderText = "Peso (kg)"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Imágenes"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 80
        '
        'btn_exportar_csv
        '
        Me.btn_exportar_csv.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.btn_exportar_csv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_exportar_csv.FlatAppearance.BorderSize = 0
        Me.btn_exportar_csv.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exportar_csv.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar_csv.ForeColor = System.Drawing.Color.White
        Me.btn_exportar_csv.Location = New System.Drawing.Point(700, 118)
        Me.btn_exportar_csv.Name = "btn_exportar_csv"
        Me.btn_exportar_csv.Size = New System.Drawing.Size(100, 50)
        Me.btn_exportar_csv.TabIndex = 320
        Me.btn_exportar_csv.Text = "CSV"
        Me.btn_exportar_csv.UseVisualStyleBackColor = False
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Century Gothic", 24.0!)
        Me.lbl_mensaje.Location = New System.Drawing.Point(307, 37)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(711, 81)
        Me.lbl_mensaje.TabIndex = 323
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'btn_buscar
        '
        Me.btn_buscar.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.btn_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_buscar.FlatAppearance.BorderSize = 0
        Me.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_buscar.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.ForeColor = System.Drawing.Color.White
        Me.btn_buscar.Location = New System.Drawing.Point(594, 118)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(100, 50)
        Me.btn_buscar.TabIndex = 319
        Me.btn_buscar.Text = "BUSCAR"
        Me.btn_buscar.UseVisualStyleBackColor = False
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.txt_busqueda)
        Me.GroupBox6.Font = New System.Drawing.Font("Century Gothic", 11.25!)
        Me.GroupBox6.Location = New System.Drawing.Point(6, 112)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(582, 56)
        Me.GroupBox6.TabIndex = 318
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "BUSQUEDA INTELIGENTE  ( F1 )"
        '
        'txt_busqueda
        '
        Me.txt_busqueda.BackColor = System.Drawing.Color.White
        Me.txt_busqueda.Font = New System.Drawing.Font("Century Gothic", 11.25!)
        Me.txt_busqueda.Location = New System.Drawing.Point(7, 21)
        Me.txt_busqueda.Name = "txt_busqueda"
        Me.txt_busqueda.Size = New System.Drawing.Size(568, 26)
        Me.txt_busqueda.TabIndex = 1
        '
        'lbl_resultado
        '
        Me.lbl_resultado.BackColor = System.Drawing.Color.Transparent
        Me.lbl_resultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_resultado.Location = New System.Drawing.Point(307, 37)
        Me.lbl_resultado.Name = "lbl_resultado"
        Me.lbl_resultado.Size = New System.Drawing.Size(711, 81)
        Me.lbl_resultado.TabIndex = 324
        Me.lbl_resultado.Text = "SE ENCONTRARON 0 RESULTADOS"
        Me.lbl_resultado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_resultado.Visible = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 41)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 322
        Me.PictureBox_logo.TabStop = False
        '
        'grilla_carga
        '
        Me.grilla_carga.AllowUserToAddRows = False
        Me.grilla_carga.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_carga.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.grilla_carga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla_carga.DefaultCellStyle = DataGridViewCellStyle10
        Me.grilla_carga.Location = New System.Drawing.Point(70, 323)
        Me.grilla_carga.Name = "grilla_carga"
        Me.grilla_carga.ReadOnly = True
        Me.grilla_carga.Size = New System.Drawing.Size(265, 252)
        Me.grilla_carga.TabIndex = 325
        Me.grilla_carga.TabStop = False
        '
        'grilla_velocidad
        '
        Me.grilla_velocidad.AllowUserToAddRows = False
        Me.grilla_velocidad.AllowUserToDeleteRows = False
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_velocidad.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.grilla_velocidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla_velocidad.DefaultCellStyle = DataGridViewCellStyle12
        Me.grilla_velocidad.Location = New System.Drawing.Point(461, 323)
        Me.grilla_velocidad.Name = "grilla_velocidad"
        Me.grilla_velocidad.ReadOnly = True
        Me.grilla_velocidad.Size = New System.Drawing.Size(265, 252)
        Me.grilla_velocidad.TabIndex = 326
        Me.grilla_velocidad.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 691)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1018, 8)
        Me.Panel3.TabIndex = 328
        '
        'Barra_titulo1
        '
        Me.Barra_titulo1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Barra_titulo1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Barra_titulo1.Location = New System.Drawing.Point(0, 0)
        Me.Barra_titulo1.Name = "Barra_titulo1"
        Me.Barra_titulo1.Padding = New System.Windows.Forms.Padding(2)
        Me.Barra_titulo1.Size = New System.Drawing.Size(1018, 35)
        Me.Barra_titulo1.TabIndex = 327
        '
        'btn_validar
        '
        Me.btn_validar.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.btn_validar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_validar.FlatAppearance.BorderSize = 0
        Me.btn_validar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_validar.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_validar.ForeColor = System.Drawing.Color.White
        Me.btn_validar.Location = New System.Drawing.Point(912, 118)
        Me.btn_validar.Name = "btn_validar"
        Me.btn_validar.Size = New System.Drawing.Size(100, 50)
        Me.btn_validar.TabIndex = 329
        Me.btn_validar.Text = "VALIDAR"
        Me.btn_validar.UseVisualStyleBackColor = False
        '
        'Form_productos_pagina_neumapro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1018, 699)
        Me.Controls.Add(Me.btn_validar)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Barra_titulo1)
        Me.Controls.Add(Me.grilla_estado_de_cuenta)
        Me.Controls.Add(Me.grilla_velocidad)
        Me.Controls.Add(Me.btn_exportar_excel)
        Me.Controls.Add(Me.grilla_carga)
        Me.Controls.Add(Me.btn_exportar_csv)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.lbl_resultado)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_productos_pagina_neumapro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PRODUCTOS PAGINA NEUMAPRO"
        CType(Me.grilla_estado_de_cuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_carga, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_velocidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_exportar_excel As Button
    Friend WithEvents grilla_estado_de_cuenta As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents btn_exportar_csv As Button
    Friend WithEvents lbl_mensaje As Label
    Friend WithEvents btn_buscar As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents txt_busqueda As TextBox
    Friend WithEvents lbl_resultado As Label
    Friend WithEvents PictureBox_logo As PictureBox
    Friend WithEvents grilla_carga As DataGridView
    Friend WithEvents grilla_velocidad As DataGridView
    Friend WithEvents Barra_titulo1 As Barra_titulo
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btn_validar As Button
End Class
