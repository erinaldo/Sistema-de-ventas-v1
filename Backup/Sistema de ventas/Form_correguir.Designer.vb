<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_CORREGIR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_CORREGIR))
        Me.GroupBox_ = New System.Windows.Forms.GroupBox
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_limpiar = New System.Windows.Forms.Button
        Me.btn_grabar = New System.Windows.Forms.Button
        Me.GroupBox_clientes = New System.Windows.Forms.GroupBox
        Me.txt_recinto = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_rut_cliente = New System.Windows.Forms.TextBox
        Me.txt_nombre_cliente = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_comuna_cliente = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_giro_cliente = New System.Windows.Forms.TextBox
        Me.txt_direccion_cliente = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbl_rut = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_correo_cliente = New System.Windows.Forms.TextBox
        Me.txt_ciudad_cliente = New System.Windows.Forms.TextBox
        Me.txt_telefono = New System.Windows.Forms.TextBox
        Me.txt_cod_cliente = New System.Windows.Forms.TextBox
        Me.GroupBox_documento = New System.Windows.Forms.GroupBox
        Me.txt_total_doc_referencia = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.dtp_emision = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.combo_doc_referencia = New System.Windows.Forms.ComboBox
        Me.txt_nro_doc_referencia = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox_totales = New System.Windows.Forms.GroupBox
        Me.txt_cantidad_cuotas = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_nro_letra = New System.Windows.Forms.TextBox
        Me.txt_pie = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_total_letra = New System.Windows.Forms.TextBox
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.dtp_vencimiento = New System.Windows.Forms.DateTimePicker
        Me.GroupBox_.SuspendLayout()
        Me.GroupBox_clientes.SuspendLayout()
        Me.GroupBox_documento.SuspendLayout()
        Me.GroupBox_totales.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox_
        '
        Me.GroupBox_.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_.Controls.Add(Me.btn_salir)
        Me.GroupBox_.Controls.Add(Me.btn_limpiar)
        Me.GroupBox_.Controls.Add(Me.btn_grabar)
        Me.GroupBox_.Location = New System.Drawing.Point(474, 165)
        Me.GroupBox_.Name = "GroupBox_"
        Me.GroupBox_.Size = New System.Drawing.Size(309, 144)
        Me.GroupBox_.TabIndex = 261
        Me.GroupBox_.TabStop = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.ForeColor = System.Drawing.Color.Black
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(207, 57)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
        Me.btn_salir.TabIndex = 15
        Me.btn_salir.Text = "SALIR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_limpiar
        '
        Me.btn_limpiar.BackColor = System.Drawing.Color.Transparent
        Me.btn_limpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_limpiar.ForeColor = System.Drawing.Color.Black
        Me.btn_limpiar.Image = CType(resources.GetObject("btn_limpiar.Image"), System.Drawing.Image)
        Me.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_limpiar.Location = New System.Drawing.Point(107, 57)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(95, 40)
        Me.btn_limpiar.TabIndex = 14
        Me.btn_limpiar.Text = "LIMPIAR"
        Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_limpiar.UseVisualStyleBackColor = False
        '
        'btn_grabar
        '
        Me.btn_grabar.BackColor = System.Drawing.Color.Transparent
        Me.btn_grabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_grabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_grabar.ForeColor = System.Drawing.Color.Black
        Me.btn_grabar.Image = CType(resources.GetObject("btn_grabar.Image"), System.Drawing.Image)
        Me.btn_grabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_grabar.Location = New System.Drawing.Point(7, 57)
        Me.btn_grabar.Name = "btn_grabar"
        Me.btn_grabar.Size = New System.Drawing.Size(95, 40)
        Me.btn_grabar.TabIndex = 13
        Me.btn_grabar.Text = "GUARDAR"
        Me.btn_grabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_grabar.UseVisualStyleBackColor = False
        '
        'GroupBox_clientes
        '
        Me.GroupBox_clientes.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_clientes.Controls.Add(Me.txt_recinto)
        Me.GroupBox_clientes.Controls.Add(Me.Label4)
        Me.GroupBox_clientes.Controls.Add(Me.txt_rut_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.txt_nombre_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.Label8)
        Me.GroupBox_clientes.Controls.Add(Me.txt_comuna_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.Label2)
        Me.GroupBox_clientes.Controls.Add(Me.txt_giro_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.txt_direccion_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.Label3)
        Me.GroupBox_clientes.Controls.Add(Me.Label5)
        Me.GroupBox_clientes.Controls.Add(Me.lbl_rut)
        Me.GroupBox_clientes.Controls.Add(Me.Label6)
        Me.GroupBox_clientes.Controls.Add(Me.txt_correo_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.txt_ciudad_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.txt_telefono)
        Me.GroupBox_clientes.Controls.Add(Me.txt_cod_cliente)
        Me.GroupBox_clientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_clientes.Location = New System.Drawing.Point(6, 57)
        Me.GroupBox_clientes.Name = "GroupBox_clientes"
        Me.GroupBox_clientes.Size = New System.Drawing.Size(777, 108)
        Me.GroupBox_clientes.TabIndex = 258
        Me.GroupBox_clientes.TabStop = False
        Me.GroupBox_clientes.Text = "DATOS DEL CLIENTE:"
        '
        'txt_recinto
        '
        Me.txt_recinto.BackColor = System.Drawing.SystemColors.Control
        Me.txt_recinto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_recinto.ForeColor = System.Drawing.Color.Black
        Me.txt_recinto.Location = New System.Drawing.Point(7, 77)
        Me.txt_recinto.Name = "txt_recinto"
        Me.txt_recinto.ReadOnly = True
        Me.txt_recinto.Size = New System.Drawing.Size(213, 24)
        Me.txt_recinto.TabIndex = 240
        Me.txt_recinto.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(4, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 16)
        Me.Label4.TabIndex = 239
        Me.Label4.Text = "RECINTO:"
        '
        'txt_rut_cliente
        '
        Me.txt_rut_cliente.BackColor = System.Drawing.SystemColors.Window
        Me.txt_rut_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_rut_cliente.Location = New System.Drawing.Point(7, 33)
        Me.txt_rut_cliente.MaxLength = 12
        Me.txt_rut_cliente.Name = "txt_rut_cliente"
        Me.txt_rut_cliente.Size = New System.Drawing.Size(100, 24)
        Me.txt_rut_cliente.TabIndex = 2
        '
        'txt_nombre_cliente
        '
        Me.txt_nombre_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_nombre_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_nombre_cliente.Location = New System.Drawing.Point(113, 33)
        Me.txt_nombre_cliente.MaxLength = 0
        Me.txt_nombre_cliente.Name = "txt_nombre_cliente"
        Me.txt_nombre_cliente.ReadOnly = True
        Me.txt_nombre_cliente.Size = New System.Drawing.Size(363, 24)
        Me.txt_nombre_cliente.TabIndex = 0
        Me.txt_nombre_cliente.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(479, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "COMUNA:"
        '
        'txt_comuna_cliente
        '
        Me.txt_comuna_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_comuna_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_comuna_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_comuna_cliente.Location = New System.Drawing.Point(482, 33)
        Me.txt_comuna_cliente.Name = "txt_comuna_cliente"
        Me.txt_comuna_cliente.ReadOnly = True
        Me.txt_comuna_cliente.Size = New System.Drawing.Size(288, 24)
        Me.txt_comuna_cliente.TabIndex = 0
        Me.txt_comuna_cliente.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(223, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "GIRO:"
        '
        'txt_giro_cliente
        '
        Me.txt_giro_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_giro_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_giro_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_giro_cliente.Location = New System.Drawing.Point(226, 77)
        Me.txt_giro_cliente.Name = "txt_giro_cliente"
        Me.txt_giro_cliente.ReadOnly = True
        Me.txt_giro_cliente.Size = New System.Drawing.Size(250, 24)
        Me.txt_giro_cliente.TabIndex = 0
        Me.txt_giro_cliente.TabStop = False
        '
        'txt_direccion_cliente
        '
        Me.txt_direccion_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_direccion_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_direccion_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_direccion_cliente.HideSelection = False
        Me.txt_direccion_cliente.Location = New System.Drawing.Point(482, 77)
        Me.txt_direccion_cliente.Name = "txt_direccion_cliente"
        Me.txt_direccion_cliente.ReadOnly = True
        Me.txt_direccion_cliente.Size = New System.Drawing.Size(288, 24)
        Me.txt_direccion_cliente.TabIndex = 0
        Me.txt_direccion_cliente.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(479, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "DIRECCION:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(110, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "NOMBRE:"
        '
        'lbl_rut
        '
        Me.lbl_rut.AutoSize = True
        Me.lbl_rut.ForeColor = System.Drawing.Color.Black
        Me.lbl_rut.Location = New System.Drawing.Point(16, 35)
        Me.lbl_rut.Name = "lbl_rut"
        Me.lbl_rut.Size = New System.Drawing.Size(39, 16)
        Me.lbl_rut.TabIndex = 0
        Me.lbl_rut.Text = "nada"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(5, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "RUT:"
        '
        'txt_correo_cliente
        '
        Me.txt_correo_cliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_correo_cliente.Enabled = False
        Me.txt_correo_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_correo_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_correo_cliente.Location = New System.Drawing.Point(568, 33)
        Me.txt_correo_cliente.Name = "txt_correo_cliente"
        Me.txt_correo_cliente.Size = New System.Drawing.Size(35, 21)
        Me.txt_correo_cliente.TabIndex = 238
        Me.txt_correo_cliente.TabStop = False
        '
        'txt_ciudad_cliente
        '
        Me.txt_ciudad_cliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_ciudad_cliente.Enabled = False
        Me.txt_ciudad_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ciudad_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_ciudad_cliente.Location = New System.Drawing.Point(515, 33)
        Me.txt_ciudad_cliente.Name = "txt_ciudad_cliente"
        Me.txt_ciudad_cliente.Size = New System.Drawing.Size(35, 21)
        Me.txt_ciudad_cliente.TabIndex = 9
        Me.txt_ciudad_cliente.TabStop = False
        '
        'txt_telefono
        '
        Me.txt_telefono.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_telefono.Enabled = False
        Me.txt_telefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_telefono.ForeColor = System.Drawing.Color.Black
        Me.txt_telefono.Location = New System.Drawing.Point(575, 36)
        Me.txt_telefono.Multiline = True
        Me.txt_telefono.Name = "txt_telefono"
        Me.txt_telefono.Size = New System.Drawing.Size(42, 18)
        Me.txt_telefono.TabIndex = 3
        Me.txt_telefono.TabStop = False
        '
        'txt_cod_cliente
        '
        Me.txt_cod_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_cod_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_cod_cliente.Location = New System.Drawing.Point(607, 111)
        Me.txt_cod_cliente.Name = "txt_cod_cliente"
        Me.txt_cod_cliente.ReadOnly = True
        Me.txt_cod_cliente.Size = New System.Drawing.Size(56, 24)
        Me.txt_cod_cliente.TabIndex = 7
        Me.txt_cod_cliente.TabStop = False
        '
        'GroupBox_documento
        '
        Me.GroupBox_documento.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_documento.Controls.Add(Me.txt_total_doc_referencia)
        Me.GroupBox_documento.Controls.Add(Me.Label10)
        Me.GroupBox_documento.Controls.Add(Me.Label20)
        Me.GroupBox_documento.Controls.Add(Me.dtp_emision)
        Me.GroupBox_documento.Controls.Add(Me.Label9)
        Me.GroupBox_documento.Controls.Add(Me.combo_doc_referencia)
        Me.GroupBox_documento.Controls.Add(Me.txt_nro_doc_referencia)
        Me.GroupBox_documento.Controls.Add(Me.Label13)
        Me.GroupBox_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_documento.Location = New System.Drawing.Point(7, 165)
        Me.GroupBox_documento.Name = "GroupBox_documento"
        Me.GroupBox_documento.Size = New System.Drawing.Size(227, 144)
        Me.GroupBox_documento.TabIndex = 259
        Me.GroupBox_documento.TabStop = False
        Me.GroupBox_documento.Text = "DOCUMENTO:"
        '
        'txt_total_doc_referencia
        '
        Me.txt_total_doc_referencia.BackColor = System.Drawing.Color.White
        Me.txt_total_doc_referencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_doc_referencia.Location = New System.Drawing.Point(104, 111)
        Me.txt_total_doc_referencia.MaxLength = 10
        Me.txt_total_doc_referencia.Name = "txt_total_doc_referencia"
        Me.txt_total_doc_referencia.Size = New System.Drawing.Size(111, 24)
        Me.txt_total_doc_referencia.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 114)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 16)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "TOTAL DOC.:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(11, 52)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(91, 16)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "FECHA DOC.:"
        '
        'dtp_emision
        '
        Me.dtp_emision.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_emision.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_emision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_emision.Location = New System.Drawing.Point(104, 49)
        Me.dtp_emision.Name = "dtp_emision"
        Me.dtp_emision.Size = New System.Drawing.Size(111, 24)
        Me.dtp_emision.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(25, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 16)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "TIPO DOC.:"
        '
        'combo_doc_referencia
        '
        Me.combo_doc_referencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_doc_referencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_doc_referencia.BackColor = System.Drawing.Color.White
        Me.combo_doc_referencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_doc_referencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_doc_referencia.FormattingEnabled = True
        Me.combo_doc_referencia.Items.AddRange(New Object() {"ABONO", "BOLETA", "FACTURA", "NOTA DE CREDITO", "NOTA DE DEBITO", "-"})
        Me.combo_doc_referencia.Location = New System.Drawing.Point(104, 19)
        Me.combo_doc_referencia.Name = "combo_doc_referencia"
        Me.combo_doc_referencia.Size = New System.Drawing.Size(111, 24)
        Me.combo_doc_referencia.TabIndex = 1
        Me.combo_doc_referencia.TabStop = False
        '
        'txt_nro_doc_referencia
        '
        Me.txt_nro_doc_referencia.BackColor = System.Drawing.Color.White
        Me.txt_nro_doc_referencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_doc_referencia.Location = New System.Drawing.Point(104, 80)
        Me.txt_nro_doc_referencia.MaxLength = 10
        Me.txt_nro_doc_referencia.Name = "txt_nro_doc_referencia"
        Me.txt_nro_doc_referencia.Size = New System.Drawing.Size(111, 24)
        Me.txt_nro_doc_referencia.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(23, 83)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 16)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "NRO. DOC.:"
        '
        'GroupBox_totales
        '
        Me.GroupBox_totales.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_totales.Controls.Add(Me.txt_cantidad_cuotas)
        Me.GroupBox_totales.Controls.Add(Me.Label7)
        Me.GroupBox_totales.Controls.Add(Me.txt_nro_letra)
        Me.GroupBox_totales.Controls.Add(Me.txt_pie)
        Me.GroupBox_totales.Controls.Add(Me.Label18)
        Me.GroupBox_totales.Controls.Add(Me.Label23)
        Me.GroupBox_totales.Controls.Add(Me.Label1)
        Me.GroupBox_totales.Controls.Add(Me.txt_total_letra)
        Me.GroupBox_totales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_totales.Location = New System.Drawing.Point(240, 165)
        Me.GroupBox_totales.Name = "GroupBox_totales"
        Me.GroupBox_totales.Size = New System.Drawing.Size(227, 144)
        Me.GroupBox_totales.TabIndex = 260
        Me.GroupBox_totales.TabStop = False
        Me.GroupBox_totales.Text = "TOTALES:"
        '
        'txt_cantidad_cuotas
        '
        Me.txt_cantidad_cuotas.BackColor = System.Drawing.Color.White
        Me.txt_cantidad_cuotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad_cuotas.Location = New System.Drawing.Point(118, 50)
        Me.txt_cantidad_cuotas.MaxLength = 11
        Me.txt_cantidad_cuotas.Name = "txt_cantidad_cuotas"
        Me.txt_cantidad_cuotas.Size = New System.Drawing.Size(100, 24)
        Me.txt_cantidad_cuotas.TabIndex = 2
        Me.txt_cantidad_cuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "CANT. LETRAS:"
        '
        'txt_nro_letra
        '
        Me.txt_nro_letra.BackColor = System.Drawing.Color.White
        Me.txt_nro_letra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_letra.Location = New System.Drawing.Point(118, 81)
        Me.txt_nro_letra.MaxLength = 11
        Me.txt_nro_letra.Name = "txt_nro_letra"
        Me.txt_nro_letra.Size = New System.Drawing.Size(100, 24)
        Me.txt_nro_letra.TabIndex = 3
        Me.txt_nro_letra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_pie
        '
        Me.txt_pie.BackColor = System.Drawing.Color.White
        Me.txt_pie.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pie.Location = New System.Drawing.Point(118, 19)
        Me.txt_pie.MaxLength = 11
        Me.txt_pie.Name = "txt_pie"
        Me.txt_pie.Size = New System.Drawing.Size(100, 24)
        Me.txt_pie.TabIndex = 1
        Me.txt_pie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(84, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(32, 16)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "PIE:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(14, 115)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(102, 16)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "TOTAL LETRA:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NRO. LETRA:"
        '
        'txt_total_letra
        '
        Me.txt_total_letra.BackColor = System.Drawing.Color.White
        Me.txt_total_letra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_letra.Location = New System.Drawing.Point(118, 112)
        Me.txt_total_letra.MaxLength = 11
        Me.txt_total_letra.Name = "txt_total_letra"
        Me.txt_total_letra.Size = New System.Drawing.Size(100, 24)
        Me.txt_total_letra.TabIndex = 4
        Me.txt_total_letra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 50)
        Me.PictureBox_logo.TabIndex = 262
        Me.PictureBox_logo.TabStop = False
        '
        'dtp_vencimiento
        '
        Me.dtp_vencimiento.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_vencimiento.Enabled = False
        Me.dtp_vencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_vencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_vencimiento.Location = New System.Drawing.Point(371, 65)
        Me.dtp_vencimiento.Name = "dtp_vencimiento"
        Me.dtp_vencimiento.Size = New System.Drawing.Size(111, 24)
        Me.dtp_vencimiento.TabIndex = 265
        '
        'Form_CORREGIR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 315)
        Me.Controls.Add(Me.GroupBox_)
        Me.Controls.Add(Me.GroupBox_clientes)
        Me.Controls.Add(Me.GroupBox_documento)
        Me.Controls.Add(Me.GroupBox_totales)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.dtp_vencimiento)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_CORREGIR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox_.ResumeLayout(False)
        Me.GroupBox_clientes.ResumeLayout(False)
        Me.GroupBox_clientes.PerformLayout()
        Me.GroupBox_documento.ResumeLayout(False)
        Me.GroupBox_documento.PerformLayout()
        Me.GroupBox_totales.ResumeLayout(False)
        Me.GroupBox_totales.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox_ As System.Windows.Forms.GroupBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_grabar As System.Windows.Forms.Button
    Friend WithEvents GroupBox_clientes As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_rut_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_comuna_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_giro_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_direccion_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_rut As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_correo_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_ciudad_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_telefono As System.Windows.Forms.TextBox
    Friend WithEvents txt_cod_cliente As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox_documento As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents dtp_emision As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents combo_doc_referencia As System.Windows.Forms.ComboBox
    Friend WithEvents txt_nro_doc_referencia As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox_totales As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_total_letra As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents dtp_vencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_nro_letra As System.Windows.Forms.TextBox
    Friend WithEvents txt_pie As System.Windows.Forms.TextBox
    Friend WithEvents txt_cantidad_cuotas As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_total_doc_referencia As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_recinto As System.Windows.Forms.TextBox
End Class
