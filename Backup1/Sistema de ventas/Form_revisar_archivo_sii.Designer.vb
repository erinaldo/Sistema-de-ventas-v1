<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_revisar_archivo_sii
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_revisar_archivo_sii))
        Me.grilla_excel = New System.Windows.Forms.DataGridView
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.lbl_mensaje = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.combo_tipo = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Combo_mes = New System.Windows.Forms.ComboBox
        Me.Combo_año = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtFic = New System.Windows.Forms.TextBox
        Me.txtSelect = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_cantidad_excel = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_exportar_excel = New System.Windows.Forms.Button
        Me.btn_revisar = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btnAbrir = New System.Windows.Forms.Button
        Me.grilla_base_de_datos = New System.Windows.Forms.DataGridView
        Me.grilla_faltantes = New System.Windows.Forms.DataGridView
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_cantidad_bd = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_cantidad_faltantes = New System.Windows.Forms.TextBox
        CType(Me.grilla_excel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grilla_base_de_datos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_faltantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grilla_excel
        '
        Me.grilla_excel.AllowUserToAddRows = False
        Me.grilla_excel.AllowUserToDeleteRows = False
        Me.grilla_excel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grilla_excel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_excel.Location = New System.Drawing.Point(6, 255)
        Me.grilla_excel.Name = "grilla_excel"
        Me.grilla_excel.ReadOnly = True
        Me.grilla_excel.Size = New System.Drawing.Size(331, 438)
        Me.grilla_excel.TabIndex = 303
        Me.grilla_excel.TabStop = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 305
        Me.PictureBox_logo.TabStop = False
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(307, 2)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(711, 81)
        Me.lbl_mensaje.TabIndex = 304
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.combo_tipo)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Combo_mes)
        Me.GroupBox3.Controls.Add(Me.Combo_año)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.txtFic)
        Me.GroupBox3.Controls.Add(Me.txtSelect)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(754, 142)
        Me.GroupBox3.TabIndex = 302
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "INFORMACION DEL ARCHIVO"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(407, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 317
        Me.Label8.Text = "MES:"
        '
        'combo_tipo
        '
        Me.combo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_tipo.FormattingEnabled = True
        Me.combo_tipo.Items.AddRange(New Object() {"BUSCAR EN BASE DE DATOS", "BUSCAR EN ARCHIVO SII"})
        Me.combo_tipo.Location = New System.Drawing.Point(166, 31)
        Me.combo_tipo.Name = "combo_tipo"
        Me.combo_tipo.Size = New System.Drawing.Size(239, 24)
        Me.combo_tipo.TabIndex = 300
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(566, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 16)
        Me.Label9.TabIndex = 316
        Me.Label9.Text = "AÑO:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(122, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 16)
        Me.Label10.TabIndex = 301
        Me.Label10.Text = "TIPO:"
        '
        'Combo_mes
        '
        Me.Combo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_mes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_mes.FormattingEnabled = True
        Me.Combo_mes.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.Combo_mes.Location = New System.Drawing.Point(449, 31)
        Me.Combo_mes.Name = "Combo_mes"
        Me.Combo_mes.Size = New System.Drawing.Size(115, 24)
        Me.Combo_mes.TabIndex = 315
        '
        'Combo_año
        '
        Me.Combo_año.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_año.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_año.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_año.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_año.FormattingEnabled = True
        Me.Combo_año.Items.AddRange(New Object() {"2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031", "2032", "2033", "2034", "2035", "2036", "2037", "2038", "2039", "2040", "2041", "2042", "2043", "2044", "2045", "2046", "2047", "2048", "2049", "2050"})
        Me.Combo_año.Location = New System.Drawing.Point(608, 31)
        Me.Combo_año.MaxLength = 12
        Me.Combo_año.Name = "Combo_año"
        Me.Combo_año.Size = New System.Drawing.Size(115, 24)
        Me.Combo_año.TabIndex = 315
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(52, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 298
        Me.Label1.Text = "RUTA ARCHIVO:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(31, 65)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(133, 16)
        Me.Label22.TabIndex = 297
        Me.Label22.Text = "NOMBRE ARCHIVO:"
        '
        'txtFic
        '
        Me.txtFic.BackColor = System.Drawing.SystemColors.Control
        Me.txtFic.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFic.ForeColor = System.Drawing.Color.Black
        Me.txtFic.Location = New System.Drawing.Point(166, 93)
        Me.txtFic.Name = "txtFic"
        Me.txtFic.ReadOnly = True
        Me.txtFic.Size = New System.Drawing.Size(557, 24)
        Me.txtFic.TabIndex = 292
        Me.txtFic.TabStop = False
        '
        'txtSelect
        '
        Me.txtSelect.BackColor = System.Drawing.SystemColors.Control
        Me.txtSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelect.ForeColor = System.Drawing.Color.Black
        Me.txtSelect.Location = New System.Drawing.Point(166, 62)
        Me.txtSelect.Name = "txtSelect"
        Me.txtSelect.ReadOnly = True
        Me.txtSelect.Size = New System.Drawing.Size(557, 24)
        Me.txtSelect.TabIndex = 293
        Me.txtSelect.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(82, 228)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 16)
        Me.Label2.TabIndex = 299
        Me.Label2.Text = "REGISTROS EXCEL SII:"
        '
        'txt_cantidad_excel
        '
        Me.txt_cantidad_excel.BackColor = System.Drawing.SystemColors.Control
        Me.txt_cantidad_excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad_excel.ForeColor = System.Drawing.Color.Black
        Me.txt_cantidad_excel.Location = New System.Drawing.Point(237, 225)
        Me.txt_cantidad_excel.Name = "txt_cantidad_excel"
        Me.txt_cantidad_excel.ReadOnly = True
        Me.txt_cantidad_excel.Size = New System.Drawing.Size(100, 24)
        Me.txt_cantidad_excel.TabIndex = 296
        Me.txt_cantidad_excel.TabStop = False
        Me.txt_cantidad_excel.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btn_exportar_excel)
        Me.GroupBox1.Controls.Add(Me.btn_revisar)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.btnAbrir)
        Me.GroupBox1.Location = New System.Drawing.Point(766, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(246, 140)
        Me.GroupBox1.TabIndex = 301
        Me.GroupBox1.TabStop = False
        '
        'btn_exportar_excel
        '
        Me.btn_exportar_excel.BackColor = System.Drawing.Color.Transparent
        Me.btn_exportar_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_exportar_excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar_excel.Image = CType(resources.GetObject("btn_exportar_excel.Image"), System.Drawing.Image)
        Me.btn_exportar_excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exportar_excel.Location = New System.Drawing.Point(126, 31)
        Me.btn_exportar_excel.Name = "btn_exportar_excel"
        Me.btn_exportar_excel.Size = New System.Drawing.Size(95, 40)
        Me.btn_exportar_excel.TabIndex = 2
        Me.btn_exportar_excel.Text = "EXPORTAR"
        Me.btn_exportar_excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exportar_excel.UseVisualStyleBackColor = False
        '
        'btn_revisar
        '
        Me.btn_revisar.BackColor = System.Drawing.Color.Transparent
        Me.btn_revisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_revisar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_revisar.Image = CType(resources.GetObject("btn_revisar.Image"), System.Drawing.Image)
        Me.btn_revisar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_revisar.Location = New System.Drawing.Point(26, 76)
        Me.btn_revisar.Name = "btn_revisar"
        Me.btn_revisar.Size = New System.Drawing.Size(95, 40)
        Me.btn_revisar.TabIndex = 3
        Me.btn_revisar.Text = "REVISAR"
        Me.btn_revisar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_revisar.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(126, 76)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
        Me.btn_salir.TabIndex = 4
        Me.btn_salir.Text = "SALIR"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btnAbrir
        '
        Me.btnAbrir.BackColor = System.Drawing.Color.Transparent
        Me.btnAbrir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAbrir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbrir.Image = CType(resources.GetObject("btnAbrir.Image"), System.Drawing.Image)
        Me.btnAbrir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAbrir.Location = New System.Drawing.Point(26, 31)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(95, 40)
        Me.btnAbrir.TabIndex = 1
        Me.btnAbrir.Text = "ABRIR"
        Me.btnAbrir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAbrir.UseVisualStyleBackColor = False
        '
        'grilla_base_de_datos
        '
        Me.grilla_base_de_datos.AllowUserToAddRows = False
        Me.grilla_base_de_datos.AllowUserToDeleteRows = False
        Me.grilla_base_de_datos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grilla_base_de_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_base_de_datos.Location = New System.Drawing.Point(343, 255)
        Me.grilla_base_de_datos.Name = "grilla_base_de_datos"
        Me.grilla_base_de_datos.ReadOnly = True
        Me.grilla_base_de_datos.Size = New System.Drawing.Size(331, 438)
        Me.grilla_base_de_datos.TabIndex = 306
        Me.grilla_base_de_datos.TabStop = False
        '
        'grilla_faltantes
        '
        Me.grilla_faltantes.AllowUserToAddRows = False
        Me.grilla_faltantes.AllowUserToDeleteRows = False
        Me.grilla_faltantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grilla_faltantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_faltantes.Location = New System.Drawing.Point(680, 255)
        Me.grilla_faltantes.Name = "grilla_faltantes"
        Me.grilla_faltantes.ReadOnly = True
        Me.grilla_faltantes.Size = New System.Drawing.Size(332, 438)
        Me.grilla_faltantes.TabIndex = 307
        Me.grilla_faltantes.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(371, 228)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(201, 16)
        Me.Label6.TabIndex = 311
        Me.Label6.Text = "REGISTROS BASE DE DATOS:"
        '
        'txt_cantidad_bd
        '
        Me.txt_cantidad_bd.BackColor = System.Drawing.SystemColors.Control
        Me.txt_cantidad_bd.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad_bd.ForeColor = System.Drawing.Color.Black
        Me.txt_cantidad_bd.Location = New System.Drawing.Point(574, 225)
        Me.txt_cantidad_bd.Name = "txt_cantidad_bd"
        Me.txt_cantidad_bd.ReadOnly = True
        Me.txt_cantidad_bd.Size = New System.Drawing.Size(100, 24)
        Me.txt_cantidad_bd.TabIndex = 310
        Me.txt_cantidad_bd.TabStop = False
        Me.txt_cantidad_bd.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(738, 228)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(172, 16)
        Me.Label7.TabIndex = 313
        Me.Label7.Text = "REGISTROS FALTANTES:"
        '
        'txt_cantidad_faltantes
        '
        Me.txt_cantidad_faltantes.BackColor = System.Drawing.SystemColors.Control
        Me.txt_cantidad_faltantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad_faltantes.ForeColor = System.Drawing.Color.Black
        Me.txt_cantidad_faltantes.Location = New System.Drawing.Point(912, 225)
        Me.txt_cantidad_faltantes.Name = "txt_cantidad_faltantes"
        Me.txt_cantidad_faltantes.ReadOnly = True
        Me.txt_cantidad_faltantes.Size = New System.Drawing.Size(100, 24)
        Me.txt_cantidad_faltantes.TabIndex = 312
        Me.txt_cantidad_faltantes.TabStop = False
        Me.txt_cantidad_faltantes.Text = "0"
        '
        'Form_revisar_archivo_sii
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 699)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_cantidad_faltantes)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_cantidad_bd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.grilla_faltantes)
        Me.Controls.Add(Me.grilla_base_de_datos)
        Me.Controls.Add(Me.txt_cantidad_excel)
        Me.Controls.Add(Me.grilla_excel)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_revisar_archivo_sii"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REVISAR ARCHIVO SII"
        CType(Me.grilla_excel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grilla_base_de_datos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_faltantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grilla_excel As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents combo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad_excel As System.Windows.Forms.TextBox
    Friend WithEvents txtFic As System.Windows.Forms.TextBox
    Friend WithEvents txtSelect As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_exportar_excel As System.Windows.Forms.Button
    Friend WithEvents btn_revisar As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btnAbrir As System.Windows.Forms.Button
    Friend WithEvents grilla_base_de_datos As System.Windows.Forms.DataGridView
    Friend WithEvents grilla_faltantes As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad_bd As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad_faltantes As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Combo_mes As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_año As System.Windows.Forms.ComboBox
End Class
