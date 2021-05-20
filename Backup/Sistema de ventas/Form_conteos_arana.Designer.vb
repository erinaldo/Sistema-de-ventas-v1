<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_conteos_arana
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_conteos_arana))
        Me.GroupBox_contar = New System.Windows.Forms.GroupBox
        Me.txt_contar = New System.Windows.Forms.TextBox
        Me.GroupBox_fecha_historico = New System.Windows.Forms.GroupBox
        Me.dtp_fecha_conteo = New System.Windows.Forms.DateTimePicker
        Me.lbl_mensaje = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btn_filtros = New System.Windows.Forms.Button
        Me.btn_quitar_elemento = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_imprimir = New System.Windows.Forms.Button
        Me.btn_nueva = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_mostrar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.btn_exportar_excel = New System.Windows.Forms.Button
        Me.grilla_conteos = New System.Windows.Forms.DataGridView
        Me.Combo_subfamilia = New System.Windows.Forms.ComboBox
        Me.Combo_subfamilia_2 = New System.Windows.Forms.ComboBox
        Me.GroupBox_familia = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Combo_familia = New System.Windows.Forms.ComboBox
        Me.txt_codigo_subfamilia_2 = New System.Windows.Forms.TextBox
        Me.txt_codigo_subfamilia = New System.Windows.Forms.TextBox
        Me.txt_codigo_familia = New System.Windows.Forms.TextBox
        Me.Check_familias = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Check_subfamilias = New System.Windows.Forms.CheckBox
        Me.grilla_sub_familias_dos = New System.Windows.Forms.DataGridView
        Me.txt_nro_conteo = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_ultimo = New System.Windows.Forms.Button
        Me.btn_primero = New System.Windows.Forms.Button
        Me.btn_siguiente = New System.Windows.Forms.Button
        Me.btn_anterior = New System.Windows.Forms.Button
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox_desde = New System.Windows.Forms.GroupBox
        Me.dtp_desde = New System.Windows.Forms.DateTimePicker
        Me.GroupBox_hasta = New System.Windows.Forms.GroupBox
        Me.dtp_hasta = New System.Windows.Forms.DateTimePicker
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog
        Me.GroupBox_contar.SuspendLayout()
        Me.GroupBox_fecha_historico.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.grilla_conteos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_familia.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grilla_sub_familias_dos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_desde.SuspendLayout()
        Me.GroupBox_hasta.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox_contar
        '
        Me.GroupBox_contar.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_contar.Controls.Add(Me.txt_contar)
        Me.GroupBox_contar.Enabled = False
        Me.GroupBox_contar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_contar.Location = New System.Drawing.Point(16, 500)
        Me.GroupBox_contar.Name = "GroupBox_contar"
        Me.GroupBox_contar.Size = New System.Drawing.Size(188, 60)
        Me.GroupBox_contar.TabIndex = 5
        Me.GroupBox_contar.TabStop = False
        Me.GroupBox_contar.Text = "CONTAR:"
        '
        'txt_contar
        '
        Me.txt_contar.BackColor = System.Drawing.Color.White
        Me.txt_contar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_contar.ForeColor = System.Drawing.Color.Black
        Me.txt_contar.Location = New System.Drawing.Point(39, 21)
        Me.txt_contar.MaxLength = 11
        Me.txt_contar.Name = "txt_contar"
        Me.txt_contar.Size = New System.Drawing.Size(111, 24)
        Me.txt_contar.TabIndex = 133
        Me.txt_contar.TabStop = False
        Me.txt_contar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox_fecha_historico
        '
        Me.GroupBox_fecha_historico.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_fecha_historico.Controls.Add(Me.dtp_fecha_conteo)
        Me.GroupBox_fecha_historico.Enabled = False
        Me.GroupBox_fecha_historico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_fecha_historico.Location = New System.Drawing.Point(16, 440)
        Me.GroupBox_fecha_historico.Name = "GroupBox_fecha_historico"
        Me.GroupBox_fecha_historico.Size = New System.Drawing.Size(188, 60)
        Me.GroupBox_fecha_historico.TabIndex = 4
        Me.GroupBox_fecha_historico.TabStop = False
        Me.GroupBox_fecha_historico.Text = "FECHA HISTORICO:"
        '
        'dtp_fecha_conteo
        '
        Me.dtp_fecha_conteo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_conteo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_conteo.Location = New System.Drawing.Point(39, 22)
        Me.dtp_fecha_conteo.Name = "dtp_fecha_conteo"
        Me.dtp_fecha_conteo.Size = New System.Drawing.Size(111, 24)
        Me.dtp_fecha_conteo.TabIndex = 317
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(307, 1)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(712, 81)
        Me.lbl_mensaje.TabIndex = 307
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btn_filtros)
        Me.GroupBox4.Controls.Add(Me.btn_quitar_elemento)
        Me.GroupBox4.Controls.Add(Me.btn_salir)
        Me.GroupBox4.Controls.Add(Me.btn_imprimir)
        Me.GroupBox4.Controls.Add(Me.btn_nueva)
        Me.GroupBox4.Controls.Add(Me.btn_cancelar)
        Me.GroupBox4.Controls.Add(Me.btn_mostrar)
        Me.GroupBox4.Controls.Add(Me.btn_guardar)
        Me.GroupBox4.Controls.Add(Me.btn_exportar_excel)
        Me.GroupBox4.Location = New System.Drawing.Point(824, 257)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(188, 436)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        '
        'btn_filtros
        '
        Me.btn_filtros.BackColor = System.Drawing.Color.Transparent
        Me.btn_filtros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_filtros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_filtros.Image = CType(resources.GetObject("btn_filtros.Image"), System.Drawing.Image)
        Me.btn_filtros.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_filtros.Location = New System.Drawing.Point(47, 108)
        Me.btn_filtros.Name = "btn_filtros"
        Me.btn_filtros.Size = New System.Drawing.Size(95, 40)
        Me.btn_filtros.TabIndex = 3
        Me.btn_filtros.Text = "FILTROS"
        Me.btn_filtros.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_filtros.UseVisualStyleBackColor = False
        '
        'btn_quitar_elemento
        '
        Me.btn_quitar_elemento.BackColor = System.Drawing.Color.Transparent
        Me.btn_quitar_elemento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_quitar_elemento.ForeColor = System.Drawing.Color.Black
        Me.btn_quitar_elemento.Image = CType(resources.GetObject("btn_quitar_elemento.Image"), System.Drawing.Image)
        Me.btn_quitar_elemento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_quitar_elemento.Location = New System.Drawing.Point(47, 154)
        Me.btn_quitar_elemento.Name = "btn_quitar_elemento"
        Me.btn_quitar_elemento.Size = New System.Drawing.Size(95, 40)
        Me.btn_quitar_elemento.TabIndex = 4
        Me.btn_quitar_elemento.Text = "QUITAR"
        Me.btn_quitar_elemento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_quitar_elemento.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(47, 384)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
        Me.btn_salir.TabIndex = 9
        Me.btn_salir.Text = "SALIR"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_imprimir
        '
        Me.btn_imprimir.BackColor = System.Drawing.Color.Transparent
        Me.btn_imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.Image = CType(resources.GetObject("btn_imprimir.Image"), System.Drawing.Image)
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprimir.Location = New System.Drawing.Point(47, 292)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(95, 40)
        Me.btn_imprimir.TabIndex = 7
        Me.btn_imprimir.Text = "IMPRIMIR"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir.UseVisualStyleBackColor = False
        '
        'btn_nueva
        '
        Me.btn_nueva.BackColor = System.Drawing.Color.Transparent
        Me.btn_nueva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nueva.Image = CType(resources.GetObject("btn_nueva.Image"), System.Drawing.Image)
        Me.btn_nueva.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nueva.Location = New System.Drawing.Point(47, 16)
        Me.btn_nueva.Name = "btn_nueva"
        Me.btn_nueva.Size = New System.Drawing.Size(95, 40)
        Me.btn_nueva.TabIndex = 1
        Me.btn_nueva.Text = "NUEVO"
        Me.btn_nueva.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nueva.UseVisualStyleBackColor = False
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.Transparent
        Me.btn_cancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(47, 338)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(95, 40)
        Me.btn_cancelar.TabIndex = 8
        Me.btn_cancelar.Text = "CANCELAR"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'btn_mostrar
        '
        Me.btn_mostrar.BackColor = System.Drawing.Color.Transparent
        Me.btn_mostrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_mostrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_mostrar.Image = CType(resources.GetObject("btn_mostrar.Image"), System.Drawing.Image)
        Me.btn_mostrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_mostrar.Location = New System.Drawing.Point(47, 62)
        Me.btn_mostrar.Name = "btn_mostrar"
        Me.btn_mostrar.Size = New System.Drawing.Size(95, 40)
        Me.btn_mostrar.TabIndex = 2
        Me.btn_mostrar.Text = "MOSTRAR"
        Me.btn_mostrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_mostrar.UseVisualStyleBackColor = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.Transparent
        Me.btn_guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.Location = New System.Drawing.Point(47, 200)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(95, 40)
        Me.btn_guardar.TabIndex = 5
        Me.btn_guardar.Text = "GENERAR"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'btn_exportar_excel
        '
        Me.btn_exportar_excel.BackColor = System.Drawing.Color.Transparent
        Me.btn_exportar_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_exportar_excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar_excel.Image = CType(resources.GetObject("btn_exportar_excel.Image"), System.Drawing.Image)
        Me.btn_exportar_excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exportar_excel.Location = New System.Drawing.Point(47, 246)
        Me.btn_exportar_excel.Name = "btn_exportar_excel"
        Me.btn_exportar_excel.Size = New System.Drawing.Size(95, 40)
        Me.btn_exportar_excel.TabIndex = 6
        Me.btn_exportar_excel.Text = "EXPORTAR"
        Me.btn_exportar_excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exportar_excel.UseVisualStyleBackColor = False
        '
        'grilla_conteos
        '
        Me.grilla_conteos.AllowUserToAddRows = False
        Me.grilla_conteos.AllowUserToDeleteRows = False
        Me.grilla_conteos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_conteos.Location = New System.Drawing.Point(6, 83)
        Me.grilla_conteos.Name = "grilla_conteos"
        Me.grilla_conteos.ReadOnly = True
        Me.grilla_conteos.Size = New System.Drawing.Size(812, 632)
        Me.grilla_conteos.TabIndex = 305
        Me.grilla_conteos.TabStop = False
        '
        'Combo_subfamilia
        '
        Me.Combo_subfamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_subfamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_subfamilia.FormattingEnabled = True
        Me.Combo_subfamilia.Items.AddRange(New Object() {"-"})
        Me.Combo_subfamilia.Location = New System.Drawing.Point(16, 77)
        Me.Combo_subfamilia.Name = "Combo_subfamilia"
        Me.Combo_subfamilia.Size = New System.Drawing.Size(157, 24)
        Me.Combo_subfamilia.TabIndex = 300
        '
        'Combo_subfamilia_2
        '
        Me.Combo_subfamilia_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_subfamilia_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_subfamilia_2.FormattingEnabled = True
        Me.Combo_subfamilia_2.Items.AddRange(New Object() {"-"})
        Me.Combo_subfamilia_2.Location = New System.Drawing.Point(16, 121)
        Me.Combo_subfamilia_2.Name = "Combo_subfamilia_2"
        Me.Combo_subfamilia_2.Size = New System.Drawing.Size(157, 24)
        Me.Combo_subfamilia_2.TabIndex = 301
        '
        'GroupBox_familia
        '
        Me.GroupBox_familia.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_familia.Controls.Add(Me.Label2)
        Me.GroupBox_familia.Controls.Add(Me.Label1)
        Me.GroupBox_familia.Controls.Add(Me.Label7)
        Me.GroupBox_familia.Controls.Add(Me.Combo_subfamilia_2)
        Me.GroupBox_familia.Controls.Add(Me.Combo_subfamilia)
        Me.GroupBox_familia.Controls.Add(Me.Combo_familia)
        Me.GroupBox_familia.Enabled = False
        Me.GroupBox_familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_familia.Location = New System.Drawing.Point(16, 271)
        Me.GroupBox_familia.Name = "GroupBox_familia"
        Me.GroupBox_familia.Size = New System.Drawing.Size(188, 156)
        Me.GroupBox_familia.TabIndex = 1
        Me.GroupBox_familia.TabStop = False
        Me.GroupBox_familia.Text = "FLTROS:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 16)
        Me.Label2.TabIndex = 304
        Me.Label2.Text = "FAMILIA DOS:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 16)
        Me.Label1.TabIndex = 303
        Me.Label1.Text = "SUBFAMILIA:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 16)
        Me.Label7.TabIndex = 302
        Me.Label7.Text = "FAMILIA:"
        '
        'Combo_familia
        '
        Me.Combo_familia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_familia.FormattingEnabled = True
        Me.Combo_familia.Items.AddRange(New Object() {"-"})
        Me.Combo_familia.Location = New System.Drawing.Point(16, 33)
        Me.Combo_familia.Name = "Combo_familia"
        Me.Combo_familia.Size = New System.Drawing.Size(157, 24)
        Me.Combo_familia.TabIndex = 299
        '
        'txt_codigo_subfamilia_2
        '
        Me.txt_codigo_subfamilia_2.Enabled = False
        Me.txt_codigo_subfamilia_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_subfamilia_2.Location = New System.Drawing.Point(39, 21)
        Me.txt_codigo_subfamilia_2.MaxLength = 8
        Me.txt_codigo_subfamilia_2.Name = "txt_codigo_subfamilia_2"
        Me.txt_codigo_subfamilia_2.Size = New System.Drawing.Size(111, 24)
        Me.txt_codigo_subfamilia_2.TabIndex = 316
        Me.txt_codigo_subfamilia_2.TabStop = False
        '
        'txt_codigo_subfamilia
        '
        Me.txt_codigo_subfamilia.Enabled = False
        Me.txt_codigo_subfamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_subfamilia.Location = New System.Drawing.Point(39, 21)
        Me.txt_codigo_subfamilia.MaxLength = 8
        Me.txt_codigo_subfamilia.Name = "txt_codigo_subfamilia"
        Me.txt_codigo_subfamilia.Size = New System.Drawing.Size(111, 24)
        Me.txt_codigo_subfamilia.TabIndex = 315
        Me.txt_codigo_subfamilia.TabStop = False
        '
        'txt_codigo_familia
        '
        Me.txt_codigo_familia.Enabled = False
        Me.txt_codigo_familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_familia.Location = New System.Drawing.Point(39, 21)
        Me.txt_codigo_familia.MaxLength = 8
        Me.txt_codigo_familia.Name = "txt_codigo_familia"
        Me.txt_codigo_familia.Size = New System.Drawing.Size(111, 24)
        Me.txt_codigo_familia.TabIndex = 314
        Me.txt_codigo_familia.TabStop = False
        '
        'Check_familias
        '
        Me.Check_familias.AutoSize = True
        Me.Check_familias.BackColor = System.Drawing.Color.Transparent
        Me.Check_familias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_familias.Location = New System.Drawing.Point(37, 17)
        Me.Check_familias.Name = "Check_familias"
        Me.Check_familias.Size = New System.Drawing.Size(86, 20)
        Me.Check_familias.TabIndex = 317
        Me.Check_familias.TabStop = False
        Me.Check_familias.Text = "FAMILIAS"
        Me.Check_familias.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Check_subfamilias)
        Me.GroupBox1.Controls.Add(Me.Check_familias)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(824, 136)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(188, 60)
        Me.GroupBox1.TabIndex = 134
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "COLUMNAS:"
        '
        'Check_subfamilias
        '
        Me.Check_subfamilias.AutoSize = True
        Me.Check_subfamilias.BackColor = System.Drawing.Color.Transparent
        Me.Check_subfamilias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_subfamilias.Location = New System.Drawing.Point(37, 36)
        Me.Check_subfamilias.Name = "Check_subfamilias"
        Me.Check_subfamilias.Size = New System.Drawing.Size(114, 20)
        Me.Check_subfamilias.TabIndex = 318
        Me.Check_subfamilias.TabStop = False
        Me.Check_subfamilias.Text = "SUBFAMILIAS"
        Me.Check_subfamilias.UseVisualStyleBackColor = False
        '
        'grilla_sub_familias_dos
        '
        Me.grilla_sub_familias_dos.AllowUserToAddRows = False
        Me.grilla_sub_familias_dos.AllowUserToDeleteRows = False
        Me.grilla_sub_familias_dos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_sub_familias_dos.Location = New System.Drawing.Point(376, 403)
        Me.grilla_sub_familias_dos.Name = "grilla_sub_familias_dos"
        Me.grilla_sub_familias_dos.ReadOnly = True
        Me.grilla_sub_familias_dos.Size = New System.Drawing.Size(166, 290)
        Me.grilla_sub_familias_dos.TabIndex = 317
        Me.grilla_sub_familias_dos.TabStop = False
        '
        'txt_nro_conteo
        '
        Me.txt_nro_conteo.BackColor = System.Drawing.SystemColors.Control
        Me.txt_nro_conteo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_conteo.ForeColor = System.Drawing.Color.Black
        Me.txt_nro_conteo.Location = New System.Drawing.Point(44, 22)
        Me.txt_nro_conteo.Name = "txt_nro_conteo"
        Me.txt_nro_conteo.ReadOnly = True
        Me.txt_nro_conteo.Size = New System.Drawing.Size(100, 24)
        Me.txt_nro_conteo.TabIndex = 318
        Me.txt_nro_conteo.TabStop = False
        Me.txt_nro_conteo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btn_ultimo)
        Me.GroupBox2.Controls.Add(Me.btn_primero)
        Me.GroupBox2.Controls.Add(Me.btn_siguiente)
        Me.GroupBox2.Controls.Add(Me.btn_anterior)
        Me.GroupBox2.Location = New System.Drawing.Point(824, 196)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(188, 61)
        Me.GroupBox2.TabIndex = 319
        Me.GroupBox2.TabStop = False
        '
        'btn_ultimo
        '
        Me.btn_ultimo.BackColor = System.Drawing.Color.Transparent
        Me.btn_ultimo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_ultimo.Image = CType(resources.GetObject("btn_ultimo.Image"), System.Drawing.Image)
        Me.btn_ultimo.Location = New System.Drawing.Point(142, 13)
        Me.btn_ultimo.Name = "btn_ultimo"
        Me.btn_ultimo.Size = New System.Drawing.Size(40, 40)
        Me.btn_ultimo.TabIndex = 8
        Me.btn_ultimo.UseVisualStyleBackColor = False
        '
        'btn_primero
        '
        Me.btn_primero.BackColor = System.Drawing.Color.Transparent
        Me.btn_primero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_primero.Image = CType(resources.GetObject("btn_primero.Image"), System.Drawing.Image)
        Me.btn_primero.Location = New System.Drawing.Point(7, 13)
        Me.btn_primero.Name = "btn_primero"
        Me.btn_primero.Size = New System.Drawing.Size(40, 40)
        Me.btn_primero.TabIndex = 5
        Me.btn_primero.UseVisualStyleBackColor = False
        '
        'btn_siguiente
        '
        Me.btn_siguiente.BackColor = System.Drawing.Color.Transparent
        Me.btn_siguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_siguiente.Image = CType(resources.GetObject("btn_siguiente.Image"), System.Drawing.Image)
        Me.btn_siguiente.Location = New System.Drawing.Point(97, 13)
        Me.btn_siguiente.Name = "btn_siguiente"
        Me.btn_siguiente.Size = New System.Drawing.Size(40, 40)
        Me.btn_siguiente.TabIndex = 7
        Me.btn_siguiente.UseVisualStyleBackColor = False
        '
        'btn_anterior
        '
        Me.btn_anterior.BackColor = System.Drawing.Color.Transparent
        Me.btn_anterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_anterior.Image = CType(resources.GetObject("btn_anterior.Image"), System.Drawing.Image)
        Me.btn_anterior.Location = New System.Drawing.Point(52, 13)
        Me.btn_anterior.Name = "btn_anterior"
        Me.btn_anterior.Size = New System.Drawing.Size(40, 40)
        Me.btn_anterior.TabIndex = 6
        Me.btn_anterior.UseVisualStyleBackColor = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 306
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox_desde
        '
        Me.GroupBox_desde.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_desde.Controls.Add(Me.dtp_desde)
        Me.GroupBox_desde.Enabled = False
        Me.GroupBox_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_desde.Location = New System.Drawing.Point(16, 560)
        Me.GroupBox_desde.Name = "GroupBox_desde"
        Me.GroupBox_desde.Size = New System.Drawing.Size(188, 60)
        Me.GroupBox_desde.TabIndex = 320
        Me.GroupBox_desde.TabStop = False
        Me.GroupBox_desde.Text = "ROTADOS DESDE:"
        '
        'dtp_desde
        '
        Me.dtp_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_desde.Location = New System.Drawing.Point(39, 22)
        Me.dtp_desde.Name = "dtp_desde"
        Me.dtp_desde.Size = New System.Drawing.Size(111, 24)
        Me.dtp_desde.TabIndex = 0
        '
        'GroupBox_hasta
        '
        Me.GroupBox_hasta.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_hasta.Controls.Add(Me.dtp_hasta)
        Me.GroupBox_hasta.Enabled = False
        Me.GroupBox_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_hasta.Location = New System.Drawing.Point(16, 620)
        Me.GroupBox_hasta.Name = "GroupBox_hasta"
        Me.GroupBox_hasta.Size = New System.Drawing.Size(188, 60)
        Me.GroupBox_hasta.TabIndex = 321
        Me.GroupBox_hasta.TabStop = False
        Me.GroupBox_hasta.Text = "ROTADOS HASTA:"
        '
        'dtp_hasta
        '
        Me.dtp_hasta.Enabled = False
        Me.dtp_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_hasta.Location = New System.Drawing.Point(39, 22)
        Me.dtp_hasta.Name = "dtp_hasta"
        Me.dtp_hasta.Size = New System.Drawing.Size(111, 24)
        Me.dtp_hasta.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.txt_nro_conteo)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(824, 76)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(188, 60)
        Me.GroupBox3.TabIndex = 319
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "NRO. CONTEO:"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txt_codigo_familia)
        Me.GroupBox5.Enabled = False
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(16, 94)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(188, 60)
        Me.GroupBox5.TabIndex = 305
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "FAMILIA:"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.txt_codigo_subfamilia)
        Me.GroupBox6.Enabled = False
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(16, 137)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(188, 60)
        Me.GroupBox6.TabIndex = 315
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "SUBFAMILIA:"
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.Controls.Add(Me.txt_codigo_subfamilia_2)
        Me.GroupBox7.Enabled = False
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(16, 197)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(188, 60)
        Me.GroupBox7.TabIndex = 316
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "SUBFAMILIA DOS:"
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
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Form_conteos_arana
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 699)
        Me.Controls.Add(Me.grilla_conteos)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox_contar)
        Me.Controls.Add(Me.GroupBox_fecha_historico)
        Me.Controls.Add(Me.GroupBox_desde)
        Me.Controls.Add(Me.GroupBox_hasta)
        Me.Controls.Add(Me.GroupBox_familia)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.grilla_sub_familias_dos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_conteos_arana"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONTEOS ARANA"
        Me.GroupBox_contar.ResumeLayout(False)
        Me.GroupBox_contar.PerformLayout()
        Me.GroupBox_fecha_historico.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.grilla_conteos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_familia.ResumeLayout(False)
        Me.GroupBox_familia.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grilla_sub_familias_dos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_desde.ResumeLayout(False)
        Me.GroupBox_hasta.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox_contar As System.Windows.Forms.GroupBox
    Friend WithEvents txt_contar As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox_fecha_historico As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_mostrar As System.Windows.Forms.Button
    Friend WithEvents btn_exportar_excel As System.Windows.Forms.Button
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents grilla_conteos As System.Windows.Forms.DataGridView
    Friend WithEvents Combo_subfamilia As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_subfamilia_2 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox_familia As System.Windows.Forms.GroupBox
    Friend WithEvents Combo_familia As System.Windows.Forms.ComboBox
    Friend WithEvents txt_codigo_subfamilia_2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_subfamilia As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_familia As System.Windows.Forms.TextBox
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents Check_familias As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Check_subfamilias As System.Windows.Forms.CheckBox
    Friend WithEvents grilla_sub_familias_dos As System.Windows.Forms.DataGridView
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents txt_nro_conteo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_ultimo As System.Windows.Forms.Button
    Friend WithEvents btn_primero As System.Windows.Forms.Button
    Friend WithEvents btn_siguiente As System.Windows.Forms.Button
    Friend WithEvents btn_anterior As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btn_nueva As System.Windows.Forms.Button
    Friend WithEvents GroupBox_desde As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox_hasta As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_quitar_elemento As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_filtros As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_fecha_conteo As System.Windows.Forms.DateTimePicker
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
End Class
