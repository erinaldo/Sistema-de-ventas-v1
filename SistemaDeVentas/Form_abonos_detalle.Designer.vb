﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_abonos_detalle
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_abonos_detalle))
        Me.grilla_documento = New System.Windows.Forms.DataGridView()
        Me.lbl_mensaje = New System.Windows.Forms.Label()
        Me.GroupBox_1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_nombre_cliente = New System.Windows.Forms.TextBox()
        Me.txt_rut_cliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn_mostrar = New System.Windows.Forms.Button()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.btn_exportar_excel = New System.Windows.Forms.Button()
        Me.btn_limpiar = New System.Windows.Forms.Button()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtp_desde = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_hasta = New System.Windows.Forms.DateTimePicker()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        CType(Me.grilla_documento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'grilla_documento
        '
        Me.grilla_documento.AllowUserToAddRows = False
        Me.grilla_documento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
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
        Me.grilla_documento.Location = New System.Drawing.Point(9, 181)
        Me.grilla_documento.Margin = New System.Windows.Forms.Padding(4)
        Me.grilla_documento.Name = "grilla_documento"
        Me.grilla_documento.ReadOnly = True
        Me.grilla_documento.Size = New System.Drawing.Size(1341, 673)
        Me.grilla_documento.TabIndex = 321
        Me.grilla_documento.TabStop = False
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(409, 1)
        Me.lbl_mensaje.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(949, 100)
        Me.lbl_mensaje.TabIndex = 319
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'GroupBox_1
        '
        Me.GroupBox_1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_1.Controls.Add(Me.Label1)
        Me.GroupBox_1.Controls.Add(Me.txt_nombre_cliente)
        Me.GroupBox_1.Controls.Add(Me.txt_rut_cliente)
        Me.GroupBox_1.Controls.Add(Me.Label2)
        Me.GroupBox_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_1.Location = New System.Drawing.Point(359, 94)
        Me.GroupBox_1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_1.Name = "GroupBox_1"
        Me.GroupBox_1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_1.Size = New System.Drawing.Size(437, 81)
        Me.GroupBox_1.TabIndex = 317
        Me.GroupBox_1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 20)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "RUT CLIENTE:"
        '
        'txt_nombre_cliente
        '
        Me.txt_nombre_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_cliente.Location = New System.Drawing.Point(144, 42)
        Me.txt_nombre_cliente.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_nombre_cliente.MaxLength = 11
        Me.txt_nombre_cliente.Name = "txt_nombre_cliente"
        Me.txt_nombre_cliente.ReadOnly = True
        Me.txt_nombre_cliente.Size = New System.Drawing.Size(283, 29)
        Me.txt_nombre_cliente.TabIndex = 7
        Me.txt_nombre_cliente.TabStop = False
        '
        'txt_rut_cliente
        '
        Me.txt_rut_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut_cliente.Location = New System.Drawing.Point(8, 42)
        Me.txt_rut_cliente.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_rut_cliente.MaxLength = 11
        Me.txt_rut_cliente.Name = "txt_rut_cliente"
        Me.txt_rut_cliente.Size = New System.Drawing.Size(127, 29)
        Me.txt_rut_cliente.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(140, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "NOMBRE CLIENTE:"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btn_mostrar)
        Me.GroupBox4.Controls.Add(Me.btn_imprimir)
        Me.GroupBox4.Controls.Add(Me.btn_exportar_excel)
        Me.GroupBox4.Controls.Add(Me.btn_limpiar)
        Me.GroupBox4.Location = New System.Drawing.Point(804, 95)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(545, 80)
        Me.GroupBox4.TabIndex = 318
        Me.GroupBox4.TabStop = False
        '
        'btn_mostrar
        '
        Me.btn_mostrar.BackColor = System.Drawing.Color.Transparent
        Me.btn_mostrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_mostrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_mostrar.Image = CType(resources.GetObject("btn_mostrar.Image"), System.Drawing.Image)
        Me.btn_mostrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_mostrar.Location = New System.Drawing.Point(9, 18)
        Me.btn_mostrar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_mostrar.Name = "btn_mostrar"
        Me.btn_mostrar.Size = New System.Drawing.Size(127, 49)
        Me.btn_mostrar.TabIndex = 7
        Me.btn_mostrar.Text = "MOSTRAR"
        Me.btn_mostrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_mostrar.UseVisualStyleBackColor = False
        '
        'btn_imprimir
        '
        Me.btn_imprimir.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.Image = CType(resources.GetObject("btn_imprimir.Image"), System.Drawing.Image)
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprimir.Location = New System.Drawing.Point(143, 18)
        Me.btn_imprimir.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(127, 49)
        Me.btn_imprimir.TabIndex = 4
        Me.btn_imprimir.Text = "IMPRIMIR"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir.UseVisualStyleBackColor = True
        '
        'btn_exportar_excel
        '
        Me.btn_exportar_excel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_exportar_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_exportar_excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar_excel.Image = CType(resources.GetObject("btn_exportar_excel.Image"), System.Drawing.Image)
        Me.btn_exportar_excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exportar_excel.Location = New System.Drawing.Point(409, 18)
        Me.btn_exportar_excel.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_exportar_excel.Name = "btn_exportar_excel"
        Me.btn_exportar_excel.Size = New System.Drawing.Size(127, 49)
        Me.btn_exportar_excel.TabIndex = 6
        Me.btn_exportar_excel.Text = "EXPORTAR"
        Me.btn_exportar_excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exportar_excel.UseVisualStyleBackColor = True
        '
        'btn_limpiar
        '
        Me.btn_limpiar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_limpiar.Image = CType(resources.GetObject("btn_limpiar.Image"), System.Drawing.Image)
        Me.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_limpiar.Location = New System.Drawing.Point(276, 18)
        Me.btn_limpiar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(127, 49)
        Me.btn_limpiar.TabIndex = 5
        Me.btn_limpiar.Text = "LIMPIAR"
        Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_limpiar.UseVisualStyleBackColor = True
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(8, 7)
        Me.PictureBox_logo.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(400, 86)
        Me.PictureBox_logo.TabIndex = 320
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.dtp_desde)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(9, 95)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(167, 80)
        Me.GroupBox2.TabIndex = 315
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "RANGO:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 20)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "DESDE:"
        '
        'dtp_desde
        '
        Me.dtp_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_desde.Location = New System.Drawing.Point(9, 42)
        Me.dtp_desde.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_desde.Name = "dtp_desde"
        Me.dtp_desde.Size = New System.Drawing.Size(147, 29)
        Me.dtp_desde.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.dtp_hasta)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(184, 95)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(167, 80)
        Me.GroupBox3.TabIndex = 316
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "RANGO:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 20)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "HASTA:"
        '
        'dtp_hasta
        '
        Me.dtp_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_hasta.Location = New System.Drawing.Point(9, 42)
        Me.dtp_hasta.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_hasta.Name = "dtp_hasta"
        Me.dtp_hasta.Size = New System.Drawing.Size(147, 29)
        Me.dtp_hasta.TabIndex = 2
        '
        'txt_total
        '
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.Location = New System.Drawing.Point(613, 441)
        Me.txt_total.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(132, 29)
        Me.txt_total.TabIndex = 325
        Me.txt_total.TabStop = False
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDocument1
        '
        '
        'Form_abonos_detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1357, 862)
        Me.Controls.Add(Me.grilla_documento)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.GroupBox_1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.txt_total)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Form_abonos_detalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DETALLE DE ABONOS"
        CType(Me.grilla_documento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_1.ResumeLayout(False)
        Me.GroupBox_1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grilla_documento As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents GroupBox_1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_nombre_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_rut_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents btn_exportar_excel As System.Windows.Forms.Button
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtp_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtp_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents btn_mostrar As System.Windows.Forms.Button
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
End Class
