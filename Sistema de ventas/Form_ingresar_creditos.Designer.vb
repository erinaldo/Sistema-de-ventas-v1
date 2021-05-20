<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_ingresar_creditos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_ingresar_creditos))
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox_documento = New System.Windows.Forms.GroupBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.dtp_emision = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.combo_documento = New System.Windows.Forms.ComboBox
        Me.txt_nro_doc = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox_totales = New System.Windows.Forms.GroupBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_iva = New System.Windows.Forms.TextBox
        Me.txt_total = New System.Windows.Forms.TextBox
        Me.txt_neto = New System.Windows.Forms.TextBox
        Me.GroupBox_clientes = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Combo_recinto = New System.Windows.Forms.ComboBox
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
        Me.GroupBox_ = New System.Windows.Forms.GroupBox
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_limpiar = New System.Windows.Forms.Button
        Me.btn_nueva = New System.Windows.Forms.Button
        Me.btn_grabar = New System.Windows.Forms.Button
        Me.dtp_vencimiento = New System.Windows.Forms.DateTimePicker
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_documento.SuspendLayout()
        Me.GroupBox_totales.SuspendLayout()
        Me.GroupBox_clientes.SuspendLayout()
        Me.GroupBox_.SuspendLayout()
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
        Me.PictureBox_logo.TabIndex = 142
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox_documento
        '
        Me.GroupBox_documento.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_documento.Controls.Add(Me.Label20)
        Me.GroupBox_documento.Controls.Add(Me.dtp_emision)
        Me.GroupBox_documento.Controls.Add(Me.Label9)
        Me.GroupBox_documento.Controls.Add(Me.combo_documento)
        Me.GroupBox_documento.Controls.Add(Me.txt_nro_doc)
        Me.GroupBox_documento.Controls.Add(Me.Label13)
        Me.GroupBox_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_documento.Location = New System.Drawing.Point(7, 185)
        Me.GroupBox_documento.Name = "GroupBox_documento"
        Me.GroupBox_documento.Size = New System.Drawing.Size(278, 137)
        Me.GroupBox_documento.TabIndex = 2
        Me.GroupBox_documento.TabStop = False
        Me.GroupBox_documento.Text = "DOCUMENTO:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(32, 93)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(66, 16)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "EMISION:"
        '
        'dtp_emision
        '
        Me.dtp_emision.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_emision.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_emision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_emision.Location = New System.Drawing.Point(100, 90)
        Me.dtp_emision.Name = "dtp_emision"
        Me.dtp_emision.Size = New System.Drawing.Size(111, 24)
        Me.dtp_emision.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(21, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 16)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "TIPO DOC.:"
        '
        'combo_documento
        '
        Me.combo_documento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_documento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_documento.BackColor = System.Drawing.Color.White
        Me.combo_documento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_documento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_documento.FormattingEnabled = True
        Me.combo_documento.Items.AddRange(New Object() {"ABONO", "BOLETA", "FACTURA", "NOTA DE CREDITO", "NOTA DE DEBITO", "-"})
        Me.combo_documento.Location = New System.Drawing.Point(100, 29)
        Me.combo_documento.Name = "combo_documento"
        Me.combo_documento.Size = New System.Drawing.Size(146, 24)
        Me.combo_documento.TabIndex = 1
        '
        'txt_nro_doc
        '
        Me.txt_nro_doc.BackColor = System.Drawing.Color.White
        Me.txt_nro_doc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_doc.Location = New System.Drawing.Point(100, 60)
        Me.txt_nro_doc.MaxLength = 10
        Me.txt_nro_doc.Name = "txt_nro_doc"
        Me.txt_nro_doc.Size = New System.Drawing.Size(146, 24)
        Me.txt_nro_doc.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(38, 63)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 16)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "N° DOC.:"
        '
        'GroupBox_totales
        '
        Me.GroupBox_totales.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_totales.Controls.Add(Me.Label18)
        Me.GroupBox_totales.Controls.Add(Me.Label23)
        Me.GroupBox_totales.Controls.Add(Me.Label1)
        Me.GroupBox_totales.Controls.Add(Me.txt_iva)
        Me.GroupBox_totales.Controls.Add(Me.txt_total)
        Me.GroupBox_totales.Controls.Add(Me.txt_neto)
        Me.GroupBox_totales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_totales.Location = New System.Drawing.Point(291, 185)
        Me.GroupBox_totales.Name = "GroupBox_totales"
        Me.GroupBox_totales.Size = New System.Drawing.Size(235, 137)
        Me.GroupBox_totales.TabIndex = 3
        Me.GroupBox_totales.TabStop = False
        Me.GroupBox_totales.Text = "TOTALES:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(60, 64)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(32, 16)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "IVA:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(37, 96)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(55, 16)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "TOTAL:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NETO:"
        '
        'txt_iva
        '
        Me.txt_iva.BackColor = System.Drawing.SystemColors.Control
        Me.txt_iva.Enabled = False
        Me.txt_iva.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_iva.Location = New System.Drawing.Point(94, 60)
        Me.txt_iva.MaxLength = 11
        Me.txt_iva.Name = "txt_iva"
        Me.txt_iva.ReadOnly = True
        Me.txt_iva.Size = New System.Drawing.Size(100, 24)
        Me.txt_iva.TabIndex = 7
        Me.txt_iva.TabStop = False
        Me.txt_iva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.Color.White
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.Location = New System.Drawing.Point(94, 91)
        Me.txt_total.MaxLength = 11
        Me.txt_total.Name = "txt_total"
        Me.txt_total.Size = New System.Drawing.Size(100, 24)
        Me.txt_total.TabIndex = 8
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_neto
        '
        Me.txt_neto.BackColor = System.Drawing.SystemColors.Control
        Me.txt_neto.Enabled = False
        Me.txt_neto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_neto.Location = New System.Drawing.Point(94, 29)
        Me.txt_neto.MaxLength = 11
        Me.txt_neto.Name = "txt_neto"
        Me.txt_neto.ReadOnly = True
        Me.txt_neto.Size = New System.Drawing.Size(100, 24)
        Me.txt_neto.TabIndex = 6
        Me.txt_neto.TabStop = False
        Me.txt_neto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox_clientes
        '
        Me.GroupBox_clientes.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_clientes.Controls.Add(Me.Label4)
        Me.GroupBox_clientes.Controls.Add(Me.Combo_recinto)
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
        Me.GroupBox_clientes.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox_clientes.Name = "GroupBox_clientes"
        Me.GroupBox_clientes.Size = New System.Drawing.Size(777, 108)
        Me.GroupBox_clientes.TabIndex = 1
        Me.GroupBox_clientes.TabStop = False
        Me.GroupBox_clientes.Text = "DATOS DEL CLIENTE:"
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
        'Combo_recinto
        '
        Me.Combo_recinto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_recinto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_recinto.BackColor = System.Drawing.Color.White
        Me.Combo_recinto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_recinto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_recinto.FormattingEnabled = True
        Me.Combo_recinto.Items.AddRange(New Object() {"QUECHEREGUAS 856", "BDO. O´HIGGINS 441", "BDO. O´HIGGINS 452", "-"})
        Me.Combo_recinto.Location = New System.Drawing.Point(7, 77)
        Me.Combo_recinto.Name = "Combo_recinto"
        Me.Combo_recinto.Size = New System.Drawing.Size(213, 24)
        Me.Combo_recinto.TabIndex = 5
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
        'GroupBox_
        '
        Me.GroupBox_.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_.Controls.Add(Me.btn_salir)
        Me.GroupBox_.Controls.Add(Me.btn_limpiar)
        Me.GroupBox_.Controls.Add(Me.btn_nueva)
        Me.GroupBox_.Controls.Add(Me.btn_grabar)
        Me.GroupBox_.Location = New System.Drawing.Point(532, 185)
        Me.GroupBox_.Name = "GroupBox_"
        Me.GroupBox_.Size = New System.Drawing.Size(251, 137)
        Me.GroupBox_.TabIndex = 4
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
        Me.btn_salir.Location = New System.Drawing.Point(128, 74)
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
        Me.btn_limpiar.Location = New System.Drawing.Point(28, 74)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(95, 40)
        Me.btn_limpiar.TabIndex = 14
        Me.btn_limpiar.Text = "LIMPIAR"
        Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_limpiar.UseVisualStyleBackColor = False
        '
        'btn_nueva
        '
        Me.btn_nueva.BackColor = System.Drawing.Color.Transparent
        Me.btn_nueva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_nueva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nueva.ForeColor = System.Drawing.Color.Black
        Me.btn_nueva.Image = CType(resources.GetObject("btn_nueva.Image"), System.Drawing.Image)
        Me.btn_nueva.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nueva.Location = New System.Drawing.Point(28, 29)
        Me.btn_nueva.Name = "btn_nueva"
        Me.btn_nueva.Size = New System.Drawing.Size(95, 40)
        Me.btn_nueva.TabIndex = 12
        Me.btn_nueva.Text = "NUEVO"
        Me.btn_nueva.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nueva.UseVisualStyleBackColor = False
        '
        'btn_grabar
        '
        Me.btn_grabar.BackColor = System.Drawing.Color.Transparent
        Me.btn_grabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_grabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_grabar.ForeColor = System.Drawing.Color.Black
        Me.btn_grabar.Image = CType(resources.GetObject("btn_grabar.Image"), System.Drawing.Image)
        Me.btn_grabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_grabar.Location = New System.Drawing.Point(128, 29)
        Me.btn_grabar.Name = "btn_grabar"
        Me.btn_grabar.Size = New System.Drawing.Size(95, 40)
        Me.btn_grabar.TabIndex = 13
        Me.btn_grabar.Text = "GUARDAR"
        Me.btn_grabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_grabar.UseVisualStyleBackColor = False
        '
        'dtp_vencimiento
        '
        Me.dtp_vencimiento.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_vencimiento.Enabled = False
        Me.dtp_vencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_vencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_vencimiento.Location = New System.Drawing.Point(371, 101)
        Me.dtp_vencimiento.Name = "dtp_vencimiento"
        Me.dtp_vencimiento.Size = New System.Drawing.Size(111, 24)
        Me.dtp_vencimiento.TabIndex = 257
        '
        'Form_ingresar_creditos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 328)
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
        Me.Name = "Form_ingresar_creditos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INGRESAR CREDITOS"
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_documento.ResumeLayout(False)
        Me.GroupBox_documento.PerformLayout()
        Me.GroupBox_totales.ResumeLayout(False)
        Me.GroupBox_totales.PerformLayout()
        Me.GroupBox_clientes.ResumeLayout(False)
        Me.GroupBox_clientes.PerformLayout()
        Me.GroupBox_.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox_documento As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents dtp_emision As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents combo_documento As System.Windows.Forms.ComboBox
    Friend WithEvents txt_nro_doc As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox_totales As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox_clientes As System.Windows.Forms.GroupBox
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
    Friend WithEvents GroupBox_ As System.Windows.Forms.GroupBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_nueva As System.Windows.Forms.Button
    Friend WithEvents btn_grabar As System.Windows.Forms.Button
    Friend WithEvents Combo_recinto As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtp_vencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_iva As System.Windows.Forms.TextBox
    Friend WithEvents txt_neto As System.Windows.Forms.TextBox
End Class
