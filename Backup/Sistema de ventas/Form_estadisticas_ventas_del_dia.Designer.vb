<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_estadisticas_ventas_del_dia
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_estadisticas_ventas_del_dia))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dtp_desde = New System.Windows.Forms.DateTimePicker
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txt_total_doc = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btn_pause_vendedor = New System.Windows.Forms.Button
        Me.btn_play_vendedor = New System.Windows.Forms.Button
        Me.btn_mostrar = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_total_ventas = New System.Windows.Forms.TextBox
        Me.lbl_total_doc_9 = New System.Windows.Forms.Label
        Me.lbl_total_doc_19 = New System.Windows.Forms.Label
        Me.lbl_total_doc_17 = New System.Windows.Forms.Label
        Me.lbl_total_doc_15 = New System.Windows.Forms.Label
        Me.lbl_total_doc_13 = New System.Windows.Forms.Label
        Me.lbl_total_doc_11 = New System.Windows.Forms.Label
        Me.lbl_total_doc_18 = New System.Windows.Forms.Label
        Me.lbl_total_doc_16 = New System.Windows.Forms.Label
        Me.lbl_total_doc_14 = New System.Windows.Forms.Label
        Me.lbl_total_doc_12 = New System.Windows.Forms.Label
        Me.lbl_total_doc_10 = New System.Windows.Forms.Label
        Me.lbl_total_doc_8 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_mensaje = New System.Windows.Forms.Label
        Me.txt_total_doc_boletas = New System.Windows.Forms.TextBox
        Me.txt_total_doc_facturas = New System.Windows.Forms.TextBox
        Me.txt_total_doc_guias = New System.Windows.Forms.TextBox
        Me.txt_total_doc_notas_de_debito = New System.Windows.Forms.TextBox
        Me.txt_total_doc_noas_de_credito = New System.Windows.Forms.TextBox
        Me.txt_total_doc_vales = New System.Windows.Forms.TextBox
        Me.txt_total_vale_sale = New System.Windows.Forms.TextBox
        Me.txt_total_vale_entra = New System.Windows.Forms.TextBox
        Me.txt_nota_de_credito = New System.Windows.Forms.TextBox
        Me.txt_total_nota_debito = New System.Windows.Forms.TextBox
        Me.txt_total_boleta = New System.Windows.Forms.TextBox
        Me.txt_total_guia = New System.Windows.Forms.TextBox
        Me.txt_total_factura = New System.Windows.Forms.TextBox
        Me.GroupBox_hora = New System.Windows.Forms.GroupBox
        Me.txt_hora_alta = New System.Windows.Forms.TextBox
        Me.Timer_actualizar = New System.Windows.Forms.Timer(Me.components)
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox_hora.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 50)
        Me.PictureBox_logo.TabIndex = 300
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dtp_desde)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(163, 65)
        Me.GroupBox2.TabIndex = 327
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "FECHA:"
        '
        'dtp_desde
        '
        Me.dtp_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_desde.Location = New System.Drawing.Point(26, 25)
        Me.dtp_desde.Name = "dtp_desde"
        Me.dtp_desde.Size = New System.Drawing.Size(111, 24)
        Me.dtp_desde.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.txt_total_doc)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(344, 57)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(163, 65)
        Me.GroupBox3.TabIndex = 329
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "TOTAL DE DOC.:"
        '
        'txt_total_doc
        '
        Me.txt_total_doc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_doc.Location = New System.Drawing.Point(26, 25)
        Me.txt_total_doc.Name = "txt_total_doc"
        Me.txt_total_doc.ReadOnly = True
        Me.txt_total_doc.Size = New System.Drawing.Size(111, 24)
        Me.txt_total_doc.TabIndex = 356
        Me.txt_total_doc.TabStop = False
        Me.txt_total_doc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btn_pause_vendedor)
        Me.GroupBox4.Controls.Add(Me.btn_play_vendedor)
        Me.GroupBox4.Controls.Add(Me.btn_mostrar)
        Me.GroupBox4.Controls.Add(Me.btn_salir)
        Me.GroupBox4.Location = New System.Drawing.Point(682, 58)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(330, 64)
        Me.GroupBox4.TabIndex = 330
        Me.GroupBox4.TabStop = False
        '
        'btn_pause_vendedor
        '
        Me.btn_pause_vendedor.BackColor = System.Drawing.Color.Transparent
        Me.btn_pause_vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pause_vendedor.Image = CType(resources.GetObject("btn_pause_vendedor.Image"), System.Drawing.Image)
        Me.btn_pause_vendedor.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_pause_vendedor.Location = New System.Drawing.Point(118, 15)
        Me.btn_pause_vendedor.Name = "btn_pause_vendedor"
        Me.btn_pause_vendedor.Size = New System.Drawing.Size(95, 40)
        Me.btn_pause_vendedor.TabIndex = 5
        Me.btn_pause_vendedor.Text = "PAUSE"
        Me.btn_pause_vendedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_pause_vendedor.UseVisualStyleBackColor = False
        '
        'btn_play_vendedor
        '
        Me.btn_play_vendedor.BackColor = System.Drawing.Color.Transparent
        Me.btn_play_vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_play_vendedor.Image = CType(resources.GetObject("btn_play_vendedor.Image"), System.Drawing.Image)
        Me.btn_play_vendedor.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_play_vendedor.Location = New System.Drawing.Point(118, 15)
        Me.btn_play_vendedor.Name = "btn_play_vendedor"
        Me.btn_play_vendedor.Size = New System.Drawing.Size(95, 40)
        Me.btn_play_vendedor.TabIndex = 6
        Me.btn_play_vendedor.Text = "PLAY"
        Me.btn_play_vendedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_play_vendedor.UseVisualStyleBackColor = False
        '
        'btn_mostrar
        '
        Me.btn_mostrar.BackColor = System.Drawing.Color.Transparent
        Me.btn_mostrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_mostrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_mostrar.Image = CType(resources.GetObject("btn_mostrar.Image"), System.Drawing.Image)
        Me.btn_mostrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_mostrar.Location = New System.Drawing.Point(18, 15)
        Me.btn_mostrar.Name = "btn_mostrar"
        Me.btn_mostrar.Size = New System.Drawing.Size(95, 40)
        Me.btn_mostrar.TabIndex = 1
        Me.btn_mostrar.Text = "MOSTRAR"
        Me.btn_mostrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_mostrar.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(218, 15)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
        Me.btn_salir.TabIndex = 4
        Me.btn_salir.Text = "SALIR"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txt_total_ventas)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(175, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(163, 65)
        Me.GroupBox1.TabIndex = 328
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "TOTAL VENTAS:"
        '
        'txt_total_ventas
        '
        Me.txt_total_ventas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_ventas.Location = New System.Drawing.Point(26, 25)
        Me.txt_total_ventas.Name = "txt_total_ventas"
        Me.txt_total_ventas.ReadOnly = True
        Me.txt_total_ventas.Size = New System.Drawing.Size(111, 24)
        Me.txt_total_ventas.TabIndex = 357
        Me.txt_total_ventas.TabStop = False
        Me.txt_total_ventas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_total_doc_9
        '
        Me.lbl_total_doc_9.BackColor = System.Drawing.Color.Transparent
        Me.lbl_total_doc_9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total_doc_9.Location = New System.Drawing.Point(199, 678)
        Me.lbl_total_doc_9.Name = "lbl_total_doc_9"
        Me.lbl_total_doc_9.Size = New System.Drawing.Size(51, 16)
        Me.lbl_total_doc_9.TabIndex = 367
        Me.lbl_total_doc_9.Text = "0"
        Me.lbl_total_doc_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_total_doc_19
        '
        Me.lbl_total_doc_19.BackColor = System.Drawing.Color.Transparent
        Me.lbl_total_doc_19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total_doc_19.Location = New System.Drawing.Point(915, 678)
        Me.lbl_total_doc_19.Name = "lbl_total_doc_19"
        Me.lbl_total_doc_19.Size = New System.Drawing.Size(51, 16)
        Me.lbl_total_doc_19.TabIndex = 366
        Me.lbl_total_doc_19.Text = "0"
        Me.lbl_total_doc_19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_total_doc_17
        '
        Me.lbl_total_doc_17.BackColor = System.Drawing.Color.Transparent
        Me.lbl_total_doc_17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total_doc_17.Location = New System.Drawing.Point(772, 678)
        Me.lbl_total_doc_17.Name = "lbl_total_doc_17"
        Me.lbl_total_doc_17.Size = New System.Drawing.Size(51, 16)
        Me.lbl_total_doc_17.TabIndex = 365
        Me.lbl_total_doc_17.Text = "0"
        Me.lbl_total_doc_17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_total_doc_15
        '
        Me.lbl_total_doc_15.BackColor = System.Drawing.Color.Transparent
        Me.lbl_total_doc_15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total_doc_15.Location = New System.Drawing.Point(629, 678)
        Me.lbl_total_doc_15.Name = "lbl_total_doc_15"
        Me.lbl_total_doc_15.Size = New System.Drawing.Size(51, 16)
        Me.lbl_total_doc_15.TabIndex = 364
        Me.lbl_total_doc_15.Text = "0"
        Me.lbl_total_doc_15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_total_doc_13
        '
        Me.lbl_total_doc_13.BackColor = System.Drawing.Color.Transparent
        Me.lbl_total_doc_13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total_doc_13.Location = New System.Drawing.Point(486, 678)
        Me.lbl_total_doc_13.Name = "lbl_total_doc_13"
        Me.lbl_total_doc_13.Size = New System.Drawing.Size(51, 16)
        Me.lbl_total_doc_13.TabIndex = 363
        Me.lbl_total_doc_13.Text = "0"
        Me.lbl_total_doc_13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_total_doc_11
        '
        Me.lbl_total_doc_11.BackColor = System.Drawing.Color.Transparent
        Me.lbl_total_doc_11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total_doc_11.Location = New System.Drawing.Point(342, 678)
        Me.lbl_total_doc_11.Name = "lbl_total_doc_11"
        Me.lbl_total_doc_11.Size = New System.Drawing.Size(51, 16)
        Me.lbl_total_doc_11.TabIndex = 362
        Me.lbl_total_doc_11.Text = "0"
        Me.lbl_total_doc_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_total_doc_18
        '
        Me.lbl_total_doc_18.BackColor = System.Drawing.Color.Transparent
        Me.lbl_total_doc_18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total_doc_18.Location = New System.Drawing.Point(845, 678)
        Me.lbl_total_doc_18.Name = "lbl_total_doc_18"
        Me.lbl_total_doc_18.Size = New System.Drawing.Size(51, 16)
        Me.lbl_total_doc_18.TabIndex = 361
        Me.lbl_total_doc_18.Text = "0"
        Me.lbl_total_doc_18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_total_doc_16
        '
        Me.lbl_total_doc_16.BackColor = System.Drawing.Color.Transparent
        Me.lbl_total_doc_16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total_doc_16.Location = New System.Drawing.Point(702, 678)
        Me.lbl_total_doc_16.Name = "lbl_total_doc_16"
        Me.lbl_total_doc_16.Size = New System.Drawing.Size(51, 16)
        Me.lbl_total_doc_16.TabIndex = 360
        Me.lbl_total_doc_16.Text = "0"
        Me.lbl_total_doc_16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_total_doc_14
        '
        Me.lbl_total_doc_14.BackColor = System.Drawing.Color.Transparent
        Me.lbl_total_doc_14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total_doc_14.Location = New System.Drawing.Point(557, 678)
        Me.lbl_total_doc_14.Name = "lbl_total_doc_14"
        Me.lbl_total_doc_14.Size = New System.Drawing.Size(51, 16)
        Me.lbl_total_doc_14.TabIndex = 359
        Me.lbl_total_doc_14.Text = "0"
        Me.lbl_total_doc_14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_total_doc_12
        '
        Me.lbl_total_doc_12.BackColor = System.Drawing.Color.Transparent
        Me.lbl_total_doc_12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total_doc_12.Location = New System.Drawing.Point(414, 678)
        Me.lbl_total_doc_12.Name = "lbl_total_doc_12"
        Me.lbl_total_doc_12.Size = New System.Drawing.Size(51, 16)
        Me.lbl_total_doc_12.TabIndex = 358
        Me.lbl_total_doc_12.Text = "0"
        Me.lbl_total_doc_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_total_doc_10
        '
        Me.lbl_total_doc_10.BackColor = System.Drawing.Color.Transparent
        Me.lbl_total_doc_10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total_doc_10.Location = New System.Drawing.Point(271, 678)
        Me.lbl_total_doc_10.Name = "lbl_total_doc_10"
        Me.lbl_total_doc_10.Size = New System.Drawing.Size(51, 16)
        Me.lbl_total_doc_10.TabIndex = 357
        Me.lbl_total_doc_10.Text = "0"
        Me.lbl_total_doc_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_total_doc_8
        '
        Me.lbl_total_doc_8.BackColor = System.Drawing.Color.Transparent
        Me.lbl_total_doc_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total_doc_8.Location = New System.Drawing.Point(127, 678)
        Me.lbl_total_doc_8.Name = "lbl_total_doc_8"
        Me.lbl_total_doc_8.Size = New System.Drawing.Size(51, 16)
        Me.lbl_total_doc_8.TabIndex = 356
        Me.lbl_total_doc_8.Text = "0"
        Me.lbl_total_doc_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(5, 678)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(108, 16)
        Me.Label14.TabIndex = 355
        Me.Label14.Text = "DOCUMENTOS:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(844, 662)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 16)
        Me.Label7.TabIndex = 354
        Me.Label7.Text = "18"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(701, 662)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 16)
        Me.Label6.TabIndex = 353
        Me.Label6.Text = "16"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(557, 662)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 16)
        Me.Label5.TabIndex = 352
        Me.Label5.Text = "14"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(414, 662)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 16)
        Me.Label4.TabIndex = 351
        Me.Label4.Text = "12"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(271, 662)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 16)
        Me.Label3.TabIndex = 350
        Me.Label3.Text = "10"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(54, 662)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 348
        Me.Label2.Text = "HORAS:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(127, 662)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 16)
        Me.Label1.TabIndex = 349
        Me.Label1.Text = "08"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(307, 0)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(711, 63)
        Me.lbl_mensaje.TabIndex = 368
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'txt_total_doc_boletas
        '
        Me.txt_total_doc_boletas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_doc_boletas.Location = New System.Drawing.Point(321, 277)
        Me.txt_total_doc_boletas.Name = "txt_total_doc_boletas"
        Me.txt_total_doc_boletas.ReadOnly = True
        Me.txt_total_doc_boletas.Size = New System.Drawing.Size(106, 24)
        Me.txt_total_doc_boletas.TabIndex = 377
        Me.txt_total_doc_boletas.TabStop = False
        Me.txt_total_doc_boletas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_doc_facturas
        '
        Me.txt_total_doc_facturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_doc_facturas.Location = New System.Drawing.Point(321, 301)
        Me.txt_total_doc_facturas.Name = "txt_total_doc_facturas"
        Me.txt_total_doc_facturas.ReadOnly = True
        Me.txt_total_doc_facturas.Size = New System.Drawing.Size(106, 24)
        Me.txt_total_doc_facturas.TabIndex = 378
        Me.txt_total_doc_facturas.TabStop = False
        Me.txt_total_doc_facturas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_doc_guias
        '
        Me.txt_total_doc_guias.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_doc_guias.Location = New System.Drawing.Point(321, 325)
        Me.txt_total_doc_guias.Name = "txt_total_doc_guias"
        Me.txt_total_doc_guias.ReadOnly = True
        Me.txt_total_doc_guias.Size = New System.Drawing.Size(106, 24)
        Me.txt_total_doc_guias.TabIndex = 379
        Me.txt_total_doc_guias.TabStop = False
        Me.txt_total_doc_guias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_doc_notas_de_debito
        '
        Me.txt_total_doc_notas_de_debito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_doc_notas_de_debito.Location = New System.Drawing.Point(321, 349)
        Me.txt_total_doc_notas_de_debito.Name = "txt_total_doc_notas_de_debito"
        Me.txt_total_doc_notas_de_debito.ReadOnly = True
        Me.txt_total_doc_notas_de_debito.Size = New System.Drawing.Size(106, 24)
        Me.txt_total_doc_notas_de_debito.TabIndex = 380
        Me.txt_total_doc_notas_de_debito.TabStop = False
        Me.txt_total_doc_notas_de_debito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_doc_noas_de_credito
        '
        Me.txt_total_doc_noas_de_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_doc_noas_de_credito.Location = New System.Drawing.Point(321, 373)
        Me.txt_total_doc_noas_de_credito.Name = "txt_total_doc_noas_de_credito"
        Me.txt_total_doc_noas_de_credito.ReadOnly = True
        Me.txt_total_doc_noas_de_credito.Size = New System.Drawing.Size(106, 24)
        Me.txt_total_doc_noas_de_credito.TabIndex = 381
        Me.txt_total_doc_noas_de_credito.TabStop = False
        Me.txt_total_doc_noas_de_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_doc_vales
        '
        Me.txt_total_doc_vales.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_doc_vales.Location = New System.Drawing.Point(591, 370)
        Me.txt_total_doc_vales.Name = "txt_total_doc_vales"
        Me.txt_total_doc_vales.ReadOnly = True
        Me.txt_total_doc_vales.Size = New System.Drawing.Size(106, 24)
        Me.txt_total_doc_vales.TabIndex = 382
        Me.txt_total_doc_vales.TabStop = False
        Me.txt_total_doc_vales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_vale_sale
        '
        Me.txt_total_vale_sale.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_vale_sale.Location = New System.Drawing.Point(469, 312)
        Me.txt_total_vale_sale.Name = "txt_total_vale_sale"
        Me.txt_total_vale_sale.ReadOnly = True
        Me.txt_total_vale_sale.Size = New System.Drawing.Size(106, 24)
        Me.txt_total_vale_sale.TabIndex = 375
        Me.txt_total_vale_sale.TabStop = False
        Me.txt_total_vale_sale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_vale_entra
        '
        Me.txt_total_vale_entra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_vale_entra.Location = New System.Drawing.Point(469, 342)
        Me.txt_total_vale_entra.Name = "txt_total_vale_entra"
        Me.txt_total_vale_entra.ReadOnly = True
        Me.txt_total_vale_entra.Size = New System.Drawing.Size(106, 24)
        Me.txt_total_vale_entra.TabIndex = 376
        Me.txt_total_vale_entra.TabStop = False
        Me.txt_total_vale_entra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_nota_de_credito
        '
        Me.txt_nota_de_credito.Enabled = False
        Me.txt_nota_de_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nota_de_credito.Location = New System.Drawing.Point(470, 373)
        Me.txt_nota_de_credito.Name = "txt_nota_de_credito"
        Me.txt_nota_de_credito.Size = New System.Drawing.Size(105, 24)
        Me.txt_nota_de_credito.TabIndex = 373
        Me.txt_nota_de_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_total_nota_debito
        '
        Me.txt_total_nota_debito.Enabled = False
        Me.txt_total_nota_debito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_nota_debito.Location = New System.Drawing.Point(470, 277)
        Me.txt_total_nota_debito.Name = "txt_total_nota_debito"
        Me.txt_total_nota_debito.Size = New System.Drawing.Size(105, 24)
        Me.txt_total_nota_debito.TabIndex = 374
        Me.txt_total_nota_debito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_total_boleta
        '
        Me.txt_total_boleta.Enabled = False
        Me.txt_total_boleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_boleta.Location = New System.Drawing.Point(470, 301)
        Me.txt_total_boleta.Name = "txt_total_boleta"
        Me.txt_total_boleta.Size = New System.Drawing.Size(105, 24)
        Me.txt_total_boleta.TabIndex = 370
        Me.txt_total_boleta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_total_guia
        '
        Me.txt_total_guia.Enabled = False
        Me.txt_total_guia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_guia.Location = New System.Drawing.Point(470, 349)
        Me.txt_total_guia.Name = "txt_total_guia"
        Me.txt_total_guia.Size = New System.Drawing.Size(105, 24)
        Me.txt_total_guia.TabIndex = 371
        Me.txt_total_guia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_total_factura
        '
        Me.txt_total_factura.Enabled = False
        Me.txt_total_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_factura.Location = New System.Drawing.Point(470, 325)
        Me.txt_total_factura.Name = "txt_total_factura"
        Me.txt_total_factura.Size = New System.Drawing.Size(105, 24)
        Me.txt_total_factura.TabIndex = 372
        Me.txt_total_factura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox_hora
        '
        Me.GroupBox_hora.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_hora.Controls.Add(Me.txt_hora_alta)
        Me.GroupBox_hora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_hora.Location = New System.Drawing.Point(513, 57)
        Me.GroupBox_hora.Name = "GroupBox_hora"
        Me.GroupBox_hora.Size = New System.Drawing.Size(163, 65)
        Me.GroupBox_hora.TabIndex = 357
        Me.GroupBox_hora.TabStop = False
        Me.GroupBox_hora.Text = "HORA MAS ALTA:"
        '
        'txt_hora_alta
        '
        Me.txt_hora_alta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_hora_alta.Location = New System.Drawing.Point(26, 25)
        Me.txt_hora_alta.Name = "txt_hora_alta"
        Me.txt_hora_alta.ReadOnly = True
        Me.txt_hora_alta.Size = New System.Drawing.Size(111, 24)
        Me.txt_hora_alta.TabIndex = 356
        Me.txt_hora_alta.TabStop = False
        Me.txt_hora_alta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Timer_actualizar
        '
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.Transparent
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(-43, 102)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.IsValueShownAsLabel = True
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(1215, 604)
        Me.Chart1.TabIndex = 331
        Me.Chart1.Text = "Chart2"
        '
        'Form_estadisticas_ventas_del_dia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 700)
        Me.Controls.Add(Me.GroupBox_hora)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.lbl_total_doc_9)
        Me.Controls.Add(Me.lbl_total_doc_19)
        Me.Controls.Add(Me.lbl_total_doc_17)
        Me.Controls.Add(Me.lbl_total_doc_15)
        Me.Controls.Add(Me.lbl_total_doc_13)
        Me.Controls.Add(Me.lbl_total_doc_11)
        Me.Controls.Add(Me.lbl_total_doc_18)
        Me.Controls.Add(Me.lbl_total_doc_16)
        Me.Controls.Add(Me.lbl_total_doc_14)
        Me.Controls.Add(Me.lbl_total_doc_12)
        Me.Controls.Add(Me.lbl_total_doc_10)
        Me.Controls.Add(Me.lbl_total_doc_8)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.txt_total_doc_boletas)
        Me.Controls.Add(Me.txt_total_doc_facturas)
        Me.Controls.Add(Me.txt_total_doc_guias)
        Me.Controls.Add(Me.txt_total_doc_notas_de_debito)
        Me.Controls.Add(Me.txt_total_doc_noas_de_credito)
        Me.Controls.Add(Me.txt_total_doc_vales)
        Me.Controls.Add(Me.txt_total_vale_sale)
        Me.Controls.Add(Me.txt_total_vale_entra)
        Me.Controls.Add(Me.txt_nota_de_credito)
        Me.Controls.Add(Me.txt_total_nota_debito)
        Me.Controls.Add(Me.txt_total_boleta)
        Me.Controls.Add(Me.txt_total_guia)
        Me.Controls.Add(Me.txt_total_factura)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_estadisticas_ventas_del_dia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VENTAS DEL DIA"
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox_hora.ResumeLayout(False)
        Me.GroupBox_hora.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_total_doc As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_mostrar As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_total_ventas As System.Windows.Forms.TextBox
    Friend WithEvents lbl_total_doc_9 As System.Windows.Forms.Label
    Friend WithEvents lbl_total_doc_19 As System.Windows.Forms.Label
    Friend WithEvents lbl_total_doc_17 As System.Windows.Forms.Label
    Friend WithEvents lbl_total_doc_15 As System.Windows.Forms.Label
    Friend WithEvents lbl_total_doc_13 As System.Windows.Forms.Label
    Friend WithEvents lbl_total_doc_11 As System.Windows.Forms.Label
    Friend WithEvents lbl_total_doc_18 As System.Windows.Forms.Label
    Friend WithEvents lbl_total_doc_16 As System.Windows.Forms.Label
    Friend WithEvents lbl_total_doc_14 As System.Windows.Forms.Label
    Friend WithEvents lbl_total_doc_12 As System.Windows.Forms.Label
    Friend WithEvents lbl_total_doc_10 As System.Windows.Forms.Label
    Friend WithEvents lbl_total_doc_8 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents txt_total_doc_boletas As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_doc_facturas As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_doc_guias As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_doc_notas_de_debito As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_doc_noas_de_credito As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_doc_vales As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_vale_sale As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_vale_entra As System.Windows.Forms.TextBox
    Friend WithEvents txt_nota_de_credito As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_nota_debito As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_boleta As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_guia As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_factura As System.Windows.Forms.TextBox
    Friend WithEvents btn_pause_vendedor As System.Windows.Forms.Button
    Friend WithEvents btn_play_vendedor As System.Windows.Forms.Button
    Friend WithEvents GroupBox_hora As System.Windows.Forms.GroupBox
    Friend WithEvents txt_hora_alta As System.Windows.Forms.TextBox
    Friend WithEvents Timer_actualizar As System.Windows.Forms.Timer
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
End Class
