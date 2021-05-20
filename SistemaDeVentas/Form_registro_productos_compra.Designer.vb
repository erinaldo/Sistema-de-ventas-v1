<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_registro_productos_compra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_registro_productos_compra))
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_nombre_proveedor = New System.Windows.Forms.TextBox()
        Me.Combo_tipo_medida = New System.Windows.Forms.ComboBox()
        Me.Combo_subfamilia = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_rut_proveedor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Combo_activo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_activo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Combo_subfamilia_2 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Combo_familia = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Combo_tipo_precio = New System.Windows.Forms.ComboBox()
        Me.txt_codigo = New System.Windows.Forms.TextBox()
        Me.lbl_tipo_cuenta = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txt_marca = New System.Windows.Forms.TextBox()
        Me.txt_cantidad_minima = New System.Windows.Forms.TextBox()
        Me.txt_aplicacion = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txt_precio = New System.Windows.Forms.TextBox()
        Me.txt_nro_doc = New System.Windows.Forms.TextBox()
        Me.txt_numero_tecnico = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txt_tipo_doc = New System.Windows.Forms.TextBox()
        Me.txt_cantidad = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_costo = New System.Windows.Forms.TextBox()
        Me.txt_cantidad_ultima_compra = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_codigo_barra = New System.Windows.Forms.TextBox()
        Me.dtp_ultima_compra = New System.Windows.Forms.DateTimePicker()
        Me.txt_nombre = New System.Windows.Forms.TextBox()
        Me.txt_codigo_subfamilia_2 = New System.Windows.Forms.TextBox()
        Me.txt_codigo_subfamilia = New System.Windows.Forms.TextBox()
        Me.txt_codigo_familia = New System.Windows.Forms.TextBox()
        Me.lbl_mensaje = New System.Windows.Forms.Label()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_especifico = New System.Windows.Forms.Button()
        Me.btn_sugerir = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_modificar = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.grilla = New System.Windows.Forms.DataGridView()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.txt_nro_ajuste = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(506, 555)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DATOS DEL PRODUCTO"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.txt_nombre_proveedor)
        Me.Panel1.Controls.Add(Me.Combo_tipo_medida)
        Me.Panel1.Controls.Add(Me.Combo_subfamilia)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.txt_rut_proveedor)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Combo_activo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lbl_activo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Combo_subfamilia_2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Combo_familia)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Combo_tipo_precio)
        Me.Panel1.Controls.Add(Me.txt_codigo)
        Me.Panel1.Controls.Add(Me.lbl_tipo_cuenta)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.txt_marca)
        Me.Panel1.Controls.Add(Me.txt_cantidad_minima)
        Me.Panel1.Controls.Add(Me.txt_aplicacion)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.txt_precio)
        Me.Panel1.Controls.Add(Me.txt_nro_doc)
        Me.Panel1.Controls.Add(Me.txt_numero_tecnico)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.txt_tipo_doc)
        Me.Panel1.Controls.Add(Me.txt_cantidad)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txt_costo)
        Me.Panel1.Controls.Add(Me.txt_cantidad_ultima_compra)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txt_codigo_barra)
        Me.Panel1.Controls.Add(Me.dtp_ultima_compra)
        Me.Panel1.Controls.Add(Me.txt_nombre)
        Me.Panel1.Location = New System.Drawing.Point(0, 14)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(501, 536)
        Me.Panel1.TabIndex = 254
        '
        'txt_nombre_proveedor
        '
        Me.txt_nombre_proveedor.Enabled = False
        Me.txt_nombre_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_proveedor.Location = New System.Drawing.Point(134, 473)
        Me.txt_nombre_proveedor.MaxLength = 12
        Me.txt_nombre_proveedor.Name = "txt_nombre_proveedor"
        Me.txt_nombre_proveedor.Size = New System.Drawing.Size(347, 24)
        Me.txt_nombre_proveedor.TabIndex = 17
        Me.txt_nombre_proveedor.TabStop = False
        '
        'Combo_tipo_medida
        '
        Me.Combo_tipo_medida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_tipo_medida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_tipo_medida.FormattingEnabled = True
        Me.Combo_tipo_medida.Items.AddRange(New Object() {"-", "UNIDAD", "DECIMAL"})
        Me.Combo_tipo_medida.Location = New System.Drawing.Point(134, 318)
        Me.Combo_tipo_medida.Name = "Combo_tipo_medida"
        Me.Combo_tipo_medida.Size = New System.Drawing.Size(111, 24)
        Me.Combo_tipo_medida.TabIndex = 11
        '
        'Combo_subfamilia
        '
        Me.Combo_subfamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_subfamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_subfamilia.FormattingEnabled = True
        Me.Combo_subfamilia.Items.AddRange(New Object() {"-"})
        Me.Combo_subfamilia.Location = New System.Drawing.Point(134, 225)
        Me.Combo_subfamilia.Name = "Combo_subfamilia"
        Me.Combo_subfamilia.Size = New System.Drawing.Size(347, 24)
        Me.Combo_subfamilia.TabIndex = 8
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(35, 321)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(97, 16)
        Me.Label16.TabIndex = 58
        Me.Label16.Text = "TIPO MEDIDA:"
        '
        'txt_rut_proveedor
        '
        Me.txt_rut_proveedor.Enabled = False
        Me.txt_rut_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut_proveedor.Location = New System.Drawing.Point(134, 473)
        Me.txt_rut_proveedor.MaxLength = 12
        Me.txt_rut_proveedor.Name = "txt_rut_proveedor"
        Me.txt_rut_proveedor.Size = New System.Drawing.Size(111, 20)
        Me.txt_rut_proveedor.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(69, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CODIGO:"
        '
        'Combo_activo
        '
        Me.Combo_activo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_activo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_activo.FormattingEnabled = True
        Me.Combo_activo.Items.AddRange(New Object() {"-", "SI", "NO"})
        Me.Combo_activo.Location = New System.Drawing.Point(370, 8)
        Me.Combo_activo.Name = "Combo_activo"
        Me.Combo_activo.Size = New System.Drawing.Size(111, 24)
        Me.Combo_activo.TabIndex = 55
        Me.Combo_activo.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(62, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "NOMBRE:"
        '
        'lbl_activo
        '
        Me.lbl_activo.BackColor = System.Drawing.Color.Transparent
        Me.lbl_activo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_activo.Location = New System.Drawing.Point(285, 11)
        Me.lbl_activo.Name = "lbl_activo"
        Me.lbl_activo.Size = New System.Drawing.Size(84, 16)
        Me.lbl_activo.TabIndex = 56
        Me.lbl_activo.Text = "ACTIVO:"
        Me.lbl_activo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(74, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "MARCA:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(71, 383)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "PRECIO:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(44, 228)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(89, 16)
        Me.Label20.TabIndex = 49
        Me.Label20.Text = "SUBFAMILIA:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(44, 73)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 16)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "APLICACION:"
        '
        'Combo_subfamilia_2
        '
        Me.Combo_subfamilia_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_subfamilia_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_subfamilia_2.FormattingEnabled = True
        Me.Combo_subfamilia_2.Items.AddRange(New Object() {"-"})
        Me.Combo_subfamilia_2.Location = New System.Drawing.Point(134, 256)
        Me.Combo_subfamilia_2.Name = "Combo_subfamilia_2"
        Me.Combo_subfamilia_2.Size = New System.Drawing.Size(347, 24)
        Me.Combo_subfamilia_2.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(44, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Nº TECNICO:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(33, 259)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 16)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "SUBFAMILIA 2:"
        '
        'Combo_familia
        '
        Me.Combo_familia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_familia.FormattingEnabled = True
        Me.Combo_familia.Items.AddRange(New Object() {"-"})
        Me.Combo_familia.Location = New System.Drawing.Point(134, 194)
        Me.Combo_familia.Name = "Combo_familia"
        Me.Combo_familia.Size = New System.Drawing.Size(347, 24)
        Me.Combo_familia.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(74, 445)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "COSTO:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(71, 197)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(61, 16)
        Me.Label21.TabIndex = 45
        Me.Label21.Text = "FAMILIA:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(52, 353)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "CANTIDAD:"
        '
        'Combo_tipo_precio
        '
        Me.Combo_tipo_precio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_tipo_precio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_tipo_precio.FormattingEnabled = True
        Me.Combo_tipo_precio.Items.AddRange(New Object() {"-", "FACTOR", "DIRECTO"})
        Me.Combo_tipo_precio.Location = New System.Drawing.Point(134, 411)
        Me.Combo_tipo_precio.Name = "Combo_tipo_precio"
        Me.Combo_tipo_precio.Size = New System.Drawing.Size(111, 24)
        Me.Combo_tipo_precio.TabIndex = 14
        '
        'txt_codigo
        '
        Me.txt_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo.Location = New System.Drawing.Point(134, 8)
        Me.txt_codigo.MaxLength = 6
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(111, 24)
        Me.txt_codigo.TabIndex = 1
        '
        'lbl_tipo_cuenta
        '
        Me.lbl_tipo_cuenta.AutoSize = True
        Me.lbl_tipo_cuenta.BackColor = System.Drawing.Color.Transparent
        Me.lbl_tipo_cuenta.Location = New System.Drawing.Point(38, 414)
        Me.lbl_tipo_cuenta.Name = "lbl_tipo_cuenta"
        Me.lbl_tipo_cuenta.Size = New System.Drawing.Size(95, 16)
        Me.lbl_tipo_cuenta.TabIndex = 29
        Me.lbl_tipo_cuenta.Text = "TIPO PRECIO:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(17, 166)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(115, 16)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "COD. DE BARRA:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(2, 290)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(130, 16)
        Me.Label19.TabIndex = 27
        Me.Label19.Text = "CANTIDAD MINIMA:"
        '
        'txt_marca
        '
        Me.txt_marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_marca.Location = New System.Drawing.Point(134, 132)
        Me.txt_marca.MaxLength = 45
        Me.txt_marca.Name = "txt_marca"
        Me.txt_marca.Size = New System.Drawing.Size(347, 24)
        Me.txt_marca.TabIndex = 5
        '
        'txt_cantidad_minima
        '
        Me.txt_cantidad_minima.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad_minima.Location = New System.Drawing.Point(134, 287)
        Me.txt_cantidad_minima.MaxLength = 10
        Me.txt_cantidad_minima.Name = "txt_cantidad_minima"
        Me.txt_cantidad_minima.Size = New System.Drawing.Size(111, 24)
        Me.txt_cantidad_minima.TabIndex = 10
        '
        'txt_aplicacion
        '
        Me.txt_aplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_aplicacion.Location = New System.Drawing.Point(134, 70)
        Me.txt_aplicacion.MaxLength = 45
        Me.txt_aplicacion.Name = "txt_aplicacion"
        Me.txt_aplicacion.Size = New System.Drawing.Size(347, 24)
        Me.txt_aplicacion.TabIndex = 3
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(249, 507)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(119, 16)
        Me.Label18.TabIndex = 25
        Me.Label18.Text = "CANT. ULT. COM.:"
        '
        'txt_precio
        '
        Me.txt_precio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_precio.Location = New System.Drawing.Point(134, 380)
        Me.txt_precio.MaxLength = 8
        Me.txt_precio.Name = "txt_precio"
        Me.txt_precio.Size = New System.Drawing.Size(111, 24)
        Me.txt_precio.TabIndex = 13
        '
        'txt_nro_doc
        '
        Me.txt_nro_doc.Enabled = False
        Me.txt_nro_doc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_doc.Location = New System.Drawing.Point(370, 535)
        Me.txt_nro_doc.MaxLength = 7
        Me.txt_nro_doc.Name = "txt_nro_doc"
        Me.txt_nro_doc.Size = New System.Drawing.Size(111, 24)
        Me.txt_nro_doc.TabIndex = 21
        '
        'txt_numero_tecnico
        '
        Me.txt_numero_tecnico.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numero_tecnico.Location = New System.Drawing.Point(134, 101)
        Me.txt_numero_tecnico.MaxLength = 45
        Me.txt_numero_tecnico.Name = "txt_numero_tecnico"
        Me.txt_numero_tecnico.Size = New System.Drawing.Size(347, 24)
        Me.txt_numero_tecnico.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(290, 538)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 16)
        Me.Label17.TabIndex = 24
        Me.Label17.Text = "NRO. DOC.:"
        '
        'txt_tipo_doc
        '
        Me.txt_tipo_doc.Enabled = False
        Me.txt_tipo_doc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tipo_doc.Location = New System.Drawing.Point(134, 535)
        Me.txt_tipo_doc.MaxLength = 7
        Me.txt_tipo_doc.Name = "txt_tipo_doc"
        Me.txt_tipo_doc.Size = New System.Drawing.Size(111, 24)
        Me.txt_tipo_doc.TabIndex = 20
        '
        'txt_cantidad
        '
        Me.txt_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad.Location = New System.Drawing.Point(134, 349)
        Me.txt_cantidad.MaxLength = 10
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Size = New System.Drawing.Size(111, 24)
        Me.txt_cantidad.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(56, 538)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 16)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "TIPO DOC.:"
        '
        'txt_costo
        '
        Me.txt_costo.Enabled = False
        Me.txt_costo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_costo.Location = New System.Drawing.Point(134, 442)
        Me.txt_costo.MaxLength = 7
        Me.txt_costo.Name = "txt_costo"
        Me.txt_costo.Size = New System.Drawing.Size(111, 24)
        Me.txt_costo.TabIndex = 16
        '
        'txt_cantidad_ultima_compra
        '
        Me.txt_cantidad_ultima_compra.Enabled = False
        Me.txt_cantidad_ultima_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad_ultima_compra.Location = New System.Drawing.Point(370, 504)
        Me.txt_cantidad_ultima_compra.MaxLength = 7
        Me.txt_cantidad_ultima_compra.Name = "txt_cantidad_ultima_compra"
        Me.txt_cantidad_ultima_compra.Size = New System.Drawing.Size(111, 24)
        Me.txt_cantidad_ultima_compra.TabIndex = 19
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(35, 476)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(97, 16)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "PROVEEDOR:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 507)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(124, 16)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "FECHA ULT. COM.:"
        '
        'txt_codigo_barra
        '
        Me.txt_codigo_barra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_barra.Location = New System.Drawing.Point(134, 163)
        Me.txt_codigo_barra.MaxLength = 30
        Me.txt_codigo_barra.Name = "txt_codigo_barra"
        Me.txt_codigo_barra.Size = New System.Drawing.Size(347, 24)
        Me.txt_codigo_barra.TabIndex = 6
        '
        'dtp_ultima_compra
        '
        Me.dtp_ultima_compra.Checked = False
        Me.dtp_ultima_compra.Enabled = False
        Me.dtp_ultima_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ultima_compra.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_ultima_compra.Location = New System.Drawing.Point(134, 504)
        Me.dtp_ultima_compra.Name = "dtp_ultima_compra"
        Me.dtp_ultima_compra.Size = New System.Drawing.Size(111, 24)
        Me.dtp_ultima_compra.TabIndex = 18
        '
        'txt_nombre
        '
        Me.txt_nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre.Location = New System.Drawing.Point(134, 39)
        Me.txt_nombre.MaxLength = 45
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(347, 24)
        Me.txt_nombre.TabIndex = 2
        '
        'txt_codigo_subfamilia_2
        '
        Me.txt_codigo_subfamilia_2.Enabled = False
        Me.txt_codigo_subfamilia_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_subfamilia_2.Location = New System.Drawing.Point(650, 392)
        Me.txt_codigo_subfamilia_2.MaxLength = 8
        Me.txt_codigo_subfamilia_2.Name = "txt_codigo_subfamilia_2"
        Me.txt_codigo_subfamilia_2.Size = New System.Drawing.Size(111, 24)
        Me.txt_codigo_subfamilia_2.TabIndex = 52
        Me.txt_codigo_subfamilia_2.TabStop = False
        '
        'txt_codigo_subfamilia
        '
        Me.txt_codigo_subfamilia.Enabled = False
        Me.txt_codigo_subfamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_subfamilia.Location = New System.Drawing.Point(650, 368)
        Me.txt_codigo_subfamilia.MaxLength = 8
        Me.txt_codigo_subfamilia.Name = "txt_codigo_subfamilia"
        Me.txt_codigo_subfamilia.Size = New System.Drawing.Size(111, 24)
        Me.txt_codigo_subfamilia.TabIndex = 51
        Me.txt_codigo_subfamilia.TabStop = False
        '
        'txt_codigo_familia
        '
        Me.txt_codigo_familia.Enabled = False
        Me.txt_codigo_familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_familia.Location = New System.Drawing.Point(650, 344)
        Me.txt_codigo_familia.MaxLength = 8
        Me.txt_codigo_familia.Name = "txt_codigo_familia"
        Me.txt_codigo_familia.Size = New System.Drawing.Size(111, 24)
        Me.txt_codigo_familia.TabIndex = 50
        Me.txt_codigo_familia.TabStop = False
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(-1, 2)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(618, 81)
        Me.lbl_mensaje.TabIndex = 253
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.PictureBox_logo.TabIndex = 252
        Me.PictureBox_logo.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(9, 504)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(144, 16)
        Me.Label11.TabIndex = 250
        Me.Label11.Text = "CANT. ULT. COMPRA:"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btn_especifico)
        Me.GroupBox2.Controls.Add(Me.btn_sugerir)
        Me.GroupBox2.Controls.Add(Me.btn_salir)
        Me.GroupBox2.Controls.Add(Me.btn_nuevo)
        Me.GroupBox2.Controls.Add(Me.btn_cancelar)
        Me.GroupBox2.Controls.Add(Me.btn_modificar)
        Me.GroupBox2.Controls.Add(Me.btn_guardar)
        Me.GroupBox2.Controls.Add(Me.btn_buscar)
        Me.GroupBox2.Controls.Add(Me.grilla)
        Me.GroupBox2.Location = New System.Drawing.Point(518, 78)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(109, 554)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'btn_especifico
        '
        Me.btn_especifico.BackColor = System.Drawing.Color.Transparent
        Me.btn_especifico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_especifico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_especifico.Image = CType(resources.GetObject("btn_especifico.Image"), System.Drawing.Image)
        Me.btn_especifico.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_especifico.Location = New System.Drawing.Point(7, 103)
        Me.btn_especifico.Name = "btn_especifico"
        Me.btn_especifico.Size = New System.Drawing.Size(95, 40)
        Me.btn_especifico.TabIndex = 5
        Me.btn_especifico.Text = "ESPECIFIC."
        Me.btn_especifico.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_especifico.UseVisualStyleBackColor = False
        '
        'btn_sugerir
        '
        Me.btn_sugerir.BackColor = System.Drawing.Color.Transparent
        Me.btn_sugerir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_sugerir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sugerir.Image = CType(resources.GetObject("btn_sugerir.Image"), System.Drawing.Image)
        Me.btn_sugerir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_sugerir.Location = New System.Drawing.Point(7, 148)
        Me.btn_sugerir.Name = "btn_sugerir"
        Me.btn_sugerir.Size = New System.Drawing.Size(95, 40)
        Me.btn_sugerir.TabIndex = 6
        Me.btn_sugerir.Text = "SUG. COD."
        Me.btn_sugerir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_sugerir.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(7, 506)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
        Me.btn_salir.TabIndex = 9
        Me.btn_salir.Text = "SALIR"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_nuevo
        '
        Me.btn_nuevo.BackColor = System.Drawing.Color.Transparent
        Me.btn_nuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_nuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btn_nuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btn_nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.Image = CType(resources.GetObject("btn_nuevo.Image"), System.Drawing.Image)
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nuevo.Location = New System.Drawing.Point(7, 13)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(95, 40)
        Me.btn_nuevo.TabIndex = 1
        Me.btn_nuevo.Text = "NUEVO"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nuevo.UseVisualStyleBackColor = False
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.Transparent
        Me.btn_cancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(7, 462)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(95, 40)
        Me.btn_cancelar.TabIndex = 8
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
        Me.btn_modificar.Location = New System.Drawing.Point(7, 58)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(95, 40)
        Me.btn_modificar.TabIndex = 2
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
        Me.btn_guardar.Location = New System.Drawing.Point(7, 416)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(95, 40)
        Me.btn_guardar.TabIndex = 7
        Me.btn_guardar.Text = "GUARDAR"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'btn_buscar
        '
        Me.btn_buscar.BackColor = System.Drawing.Color.Transparent
        Me.btn_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = CType(resources.GetObject("btn_buscar.Image"), System.Drawing.Image)
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_buscar.Location = New System.Drawing.Point(112, 306)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(95, 40)
        Me.btn_buscar.TabIndex = 4
        Me.btn_buscar.TabStop = False
        Me.btn_buscar.Text = "BUSCAR"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_buscar.UseVisualStyleBackColor = False
        '
        'grilla
        '
        Me.grilla.AllowUserToAddRows = False
        Me.grilla.AllowUserToDeleteRows = False
        Me.grilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Location = New System.Drawing.Point(112, 310)
        Me.grilla.Name = "grilla"
        Me.grilla.ReadOnly = True
        Me.grilla.Size = New System.Drawing.Size(95, 68)
        Me.grilla.TabIndex = 40
        Me.grilla.TabStop = False
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Enabled = False
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha.Location = New System.Drawing.Point(355, 82)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(116, 20)
        Me.dtp_fecha.TabIndex = 251
        '
        'txt_nro_ajuste
        '
        Me.txt_nro_ajuste.Enabled = False
        Me.txt_nro_ajuste.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_ajuste.Location = New System.Drawing.Point(351, 64)
        Me.txt_nro_ajuste.MaxLength = 6
        Me.txt_nro_ajuste.Name = "txt_nro_ajuste"
        Me.txt_nro_ajuste.Size = New System.Drawing.Size(120, 24)
        Me.txt_nro_ajuste.TabIndex = 249
        Me.txt_nro_ajuste.Visible = False
        '
        'Form_registro_productos_compra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 639)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.txt_codigo_subfamilia_2)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.txt_codigo_subfamilia)
        Me.Controls.Add(Me.txt_codigo_familia)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dtp_fecha)
        Me.Controls.Add(Me.txt_nro_ajuste)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_registro_productos_compra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REGISTRO PRODUCTOS"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_codigo_subfamilia_2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_subfamilia As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_familia As System.Windows.Forms.TextBox
    Friend WithEvents Combo_subfamilia As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Combo_subfamilia_2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Combo_familia As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Combo_tipo_precio As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_tipo_cuenta As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad_minima As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txt_nro_doc As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_tipo_doc As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad_ultima_compra As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtp_ultima_compra As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_rut_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents txt_codigo_barra As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_costo As System.Windows.Forms.TextBox
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents txt_numero_tecnico As System.Windows.Forms.TextBox
    Friend WithEvents txt_precio As System.Windows.Forms.TextBox
    Friend WithEvents txt_aplicacion As System.Windows.Forms.TextBox
    Friend WithEvents txt_marca As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_especifico As System.Windows.Forms.Button
    Friend WithEvents btn_sugerir As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_modificar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents dtp_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_nro_ajuste As System.Windows.Forms.TextBox
    Friend WithEvents Combo_activo As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_activo As System.Windows.Forms.Label
    Friend WithEvents Combo_tipo_medida As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As Panel
End Class
