﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_administrar_vale_cambio
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_administrar_vale_cambio))
        Me.grilla_documento = New System.Windows.Forms.DataGridView
        Me.grilla_detalle_documento = New System.Windows.Forms.DataGridView
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtp_hasta = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dtp_desde = New System.Windows.Forms.DateTimePicker
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Combo_vendedor = New System.Windows.Forms.ComboBox
        Me.txt_rut_vendedor = New System.Windows.Forms.TextBox
        Me.lbl_mensaje = New System.Windows.Forms.Label
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btn_grabar = New System.Windows.Forms.Button
        Me.btn_exportar_excel = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_limpiar = New System.Windows.Forms.Button
        CType(Me.grilla_documento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_detalle_documento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'grilla_documento
        '
        Me.grilla_documento.AllowUserToAddRows = False
        Me.grilla_documento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_documento.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grilla_documento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla_documento.DefaultCellStyle = DataGridViewCellStyle2
        Me.grilla_documento.Location = New System.Drawing.Point(6, 148)
        Me.grilla_documento.Name = "grilla_documento"
        Me.grilla_documento.ReadOnly = True
        Me.grilla_documento.Size = New System.Drawing.Size(1006, 280)
        Me.grilla_documento.TabIndex = 302
        Me.grilla_documento.TabStop = False
        '
        'grilla_detalle_documento
        '
        Me.grilla_detalle_documento.AllowUserToAddRows = False
        Me.grilla_detalle_documento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_detalle_documento.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grilla_detalle_documento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_detalle_documento.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column10, Me.Column11, Me.Column4, Me.Column12, Me.Column13, Me.Column19, Me.Column9, Me.Column14, Me.Column15, Me.Column16, Me.Column1})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla_detalle_documento.DefaultCellStyle = DataGridViewCellStyle11
        Me.grilla_detalle_documento.Location = New System.Drawing.Point(6, 434)
        Me.grilla_detalle_documento.Name = "grilla_detalle_documento"
        Me.grilla_detalle_documento.ReadOnly = True
        Me.grilla_detalle_documento.Size = New System.Drawing.Size(1006, 260)
        Me.grilla_detalle_documento.TabIndex = 301
        Me.grilla_detalle_documento.TabStop = False
        '
        'Column10
        '
        Me.Column10.HeaderText = "CODIGO"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.HeaderText = "NOMBRE"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "TECNICO"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        '
        'Column12
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column12.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column12.HeaderText = "VALOR"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column13
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column13.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column13.HeaderText = "CANT."
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column19
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column19.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column19.HeaderText = "SUBTOTAL"
        Me.Column19.Name = "Column19"
        Me.Column19.ReadOnly = True
        '
        'Column9
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column9.HeaderText = "DESCUENTO"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column14
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column14.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column14.HeaderText = "NETO"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column15
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column15.DefaultCellStyle = DataGridViewCellStyle9
        Me.Column15.HeaderText = "IVA"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'Column16
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column16.DefaultCellStyle = DataGridViewCellStyle10
        Me.Column16.HeaderText = "TOTAL"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "MOV."
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtp_hasta)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(137, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(125, 66)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "HASTA:"
        '
        'dtp_hasta
        '
        Me.dtp_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_hasta.Location = New System.Drawing.Point(7, 27)
        Me.dtp_hasta.Name = "dtp_hasta"
        Me.dtp_hasta.Size = New System.Drawing.Size(111, 24)
        Me.dtp_hasta.TabIndex = 7
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dtp_desde)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(125, 66)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DESDE:"
        '
        'dtp_desde
        '
        Me.dtp_desde.Checked = False
        Me.dtp_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_desde.Location = New System.Drawing.Point(7, 27)
        Me.dtp_desde.Name = "dtp_desde"
        Me.dtp_desde.Size = New System.Drawing.Size(111, 24)
        Me.dtp_desde.TabIndex = 6
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Combo_vendedor)
        Me.GroupBox3.Controls.Add(Me.txt_rut_vendedor)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(268, 77)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(329, 66)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "VENDEDOR:"
        '
        'Combo_vendedor
        '
        Me.Combo_vendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_vendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_vendedor.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_vendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_vendedor.FormattingEnabled = True
        Me.Combo_vendedor.Location = New System.Drawing.Point(7, 27)
        Me.Combo_vendedor.MaxLength = 12
        Me.Combo_vendedor.Name = "Combo_vendedor"
        Me.Combo_vendedor.Size = New System.Drawing.Size(315, 24)
        Me.Combo_vendedor.TabIndex = 2
        '
        'txt_rut_vendedor
        '
        Me.txt_rut_vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut_vendedor.Location = New System.Drawing.Point(57, 27)
        Me.txt_rut_vendedor.MaxLength = 11
        Me.txt_rut_vendedor.Name = "txt_rut_vendedor"
        Me.txt_rut_vendedor.ReadOnly = True
        Me.txt_rut_vendedor.Size = New System.Drawing.Size(100, 24)
        Me.txt_rut_vendedor.TabIndex = 308
        Me.txt_rut_vendedor.TabStop = False
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(307, 2)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(711, 81)
        Me.lbl_mensaje.TabIndex = 310
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 309
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btn_grabar)
        Me.GroupBox4.Controls.Add(Me.btn_exportar_excel)
        Me.GroupBox4.Controls.Add(Me.btn_salir)
        Me.GroupBox4.Controls.Add(Me.btn_limpiar)
        Me.GroupBox4.Location = New System.Drawing.Point(603, 78)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(409, 65)
        Me.GroupBox4.TabIndex = 311
        Me.GroupBox4.TabStop = False
        '
        'btn_grabar
        '
        Me.btn_grabar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_grabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_grabar.ForeColor = System.Drawing.Color.Black
        Me.btn_grabar.Image = CType(resources.GetObject("btn_grabar.Image"), System.Drawing.Image)
        Me.btn_grabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_grabar.Location = New System.Drawing.Point(7, 15)
        Me.btn_grabar.Name = "btn_grabar"
        Me.btn_grabar.Size = New System.Drawing.Size(95, 40)
        Me.btn_grabar.TabIndex = 1
        Me.btn_grabar.Text = "IMPRIMIR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_grabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_grabar.UseVisualStyleBackColor = True
        '
        'btn_exportar_excel
        '
        Me.btn_exportar_excel.BackColor = System.Drawing.Color.Transparent
        Me.btn_exportar_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_exportar_excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar_excel.Image = CType(resources.GetObject("btn_exportar_excel.Image"), System.Drawing.Image)
        Me.btn_exportar_excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exportar_excel.Location = New System.Drawing.Point(207, 15)
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
        Me.btn_salir.Location = New System.Drawing.Point(307, 15)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
        Me.btn_salir.TabIndex = 4
        Me.btn_salir.Text = "SALIR"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_limpiar
        '
        Me.btn_limpiar.BackColor = System.Drawing.Color.Transparent
        Me.btn_limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_limpiar.Image = CType(resources.GetObject("btn_limpiar.Image"), System.Drawing.Image)
        Me.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_limpiar.Location = New System.Drawing.Point(107, 15)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(95, 40)
        Me.btn_limpiar.TabIndex = 2
        Me.btn_limpiar.Text = "LIMPIAR"
        Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_limpiar.UseVisualStyleBackColor = False
        '
        'Form_administrar_vale_cambio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 700)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.grilla_documento)
        Me.Controls.Add(Me.grilla_detalle_documento)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_administrar_vale_cambio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADMINISTRAR VALES DE CAMBIO"
        Me.TopMost = True
        CType(Me.grilla_documento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_detalle_documento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grilla_documento As System.Windows.Forms.DataGridView
    Friend WithEvents grilla_detalle_documento As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Combo_vendedor As System.Windows.Forms.ComboBox
    Friend WithEvents txt_rut_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_exportar_excel As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_grabar As System.Windows.Forms.Button
End Class
