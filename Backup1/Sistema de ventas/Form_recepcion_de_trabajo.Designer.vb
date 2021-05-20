<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_recepcion_de_trabajo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_recepcion_de_trabajo))
        Me.GroupBox_clientes = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_correo_cliente = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_comuna_cliente = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_rut_cliente = New System.Windows.Forms.TextBox
        Me.txt_direccion_cliente = New System.Windows.Forms.TextBox
        Me.txt_nombre_cliente = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.btn_agregar_clientes = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.txt_giro_cliente = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_buscar_clientes = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_ciudad_cliente = New System.Windows.Forms.TextBox
        Me.txt_telefono = New System.Windows.Forms.TextBox
        Me.txt_cod_cliente = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_nueva = New System.Windows.Forms.Button
        Me.btn_modificar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.btn_limpiar = New System.Windows.Forms.Button
        Me.btn_imprimir = New System.Windows.Forms.Button
        Me.GroupBox_cargar = New System.Windows.Forms.GroupBox
        Me.txt_cargar = New System.Windows.Forms.TextBox
        Me.txt_diagnostico_cliente = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox_tecnico = New System.Windows.Forms.GroupBox
        Me.txt_diagnostico_tecnico = New System.Windows.Forms.TextBox
        Me.GroupBox_posicion = New System.Windows.Forms.GroupBox
        Me.btn_ultimo = New System.Windows.Forms.Button
        Me.btn_siguiente = New System.Windows.Forms.Button
        Me.btn_primero = New System.Windows.Forms.Button
        Me.btn_anterior = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txt_nro_doc = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txt_pago_parcial = New System.Windows.Forms.TextBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.txt_total = New System.Windows.Forms.TextBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.txt_detalle_de_pago = New System.Windows.Forms.TextBox
        Me.Check_retirado = New System.Windows.Forms.CheckBox
        Me.Check_cancelado = New System.Windows.Forms.CheckBox
        Me.lbl_mensaje = New System.Windows.Forms.Label
        Me.CheckedListBox_hardware = New System.Windows.Forms.CheckedListBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.Combo_estado = New System.Windows.Forms.ComboBox
        Me.txt_fecha = New System.Windows.Forms.TextBox
        Me.txt_hora = New System.Windows.Forms.TextBox
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.GroupBox11 = New System.Windows.Forms.GroupBox
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.btn_busqueda_recepcion = New System.Windows.Forms.Button
        Me.GroupBox12 = New System.Windows.Forms.GroupBox
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.GroupBox_clientes.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox_cargar.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox_tecnico.SuspendLayout()
        Me.GroupBox_posicion.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox12.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox_clientes
        '
        Me.GroupBox_clientes.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_clientes.Controls.Add(Me.Label6)
        Me.GroupBox_clientes.Controls.Add(Me.txt_correo_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.Label5)
        Me.GroupBox_clientes.Controls.Add(Me.Label4)
        Me.GroupBox_clientes.Controls.Add(Me.txt_comuna_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.Label3)
        Me.GroupBox_clientes.Controls.Add(Me.txt_rut_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.txt_direccion_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.txt_nombre_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.Label8)
        Me.GroupBox_clientes.Controls.Add(Me.btn_agregar_clientes)
        Me.GroupBox_clientes.Controls.Add(Me.Label13)
        Me.GroupBox_clientes.Controls.Add(Me.txt_giro_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.Label2)
        Me.GroupBox_clientes.Controls.Add(Me.btn_buscar_clientes)
        Me.GroupBox_clientes.Controls.Add(Me.Label1)
        Me.GroupBox_clientes.Controls.Add(Me.txt_ciudad_cliente)
        Me.GroupBox_clientes.Controls.Add(Me.txt_telefono)
        Me.GroupBox_clientes.Controls.Add(Me.txt_cod_cliente)
        Me.GroupBox_clientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_clientes.Location = New System.Drawing.Point(7, 77)
        Me.GroupBox_clientes.Name = "GroupBox_clientes"
        Me.GroupBox_clientes.Size = New System.Drawing.Size(1005, 108)
        Me.GroupBox_clientes.TabIndex = 1
        Me.GroupBox_clientes.TabStop = False
        Me.GroupBox_clientes.Text = "DATOS DEL CLIENTE:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(400, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(167, 16)
        Me.Label6.TabIndex = 249
        Me.Label6.Text = "CORREO ELECTRONICO:"
        '
        'txt_correo_cliente
        '
        Me.txt_correo_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_correo_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_correo_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_correo_cliente.Location = New System.Drawing.Point(403, 33)
        Me.txt_correo_cliente.Name = "txt_correo_cliente"
        Me.txt_correo_cliente.Size = New System.Drawing.Size(274, 24)
        Me.txt_correo_cliente.TabIndex = 248
        Me.txt_correo_cliente.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(4, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "CIUDAD:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(680, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "TELEFONO:"
        '
        'txt_comuna_cliente
        '
        Me.txt_comuna_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_comuna_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_comuna_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_comuna_cliente.Location = New System.Drawing.Point(238, 77)
        Me.txt_comuna_cliente.Name = "txt_comuna_cliente"
        Me.txt_comuna_cliente.ReadOnly = True
        Me.txt_comuna_cliente.Size = New System.Drawing.Size(225, 24)
        Me.txt_comuna_cliente.TabIndex = 0
        Me.txt_comuna_cliente.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(466, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "DIRECCION:"
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
        'txt_direccion_cliente
        '
        Me.txt_direccion_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_direccion_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_direccion_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_direccion_cliente.HideSelection = False
        Me.txt_direccion_cliente.Location = New System.Drawing.Point(469, 77)
        Me.txt_direccion_cliente.Name = "txt_direccion_cliente"
        Me.txt_direccion_cliente.ReadOnly = True
        Me.txt_direccion_cliente.Size = New System.Drawing.Size(266, 24)
        Me.txt_direccion_cliente.TabIndex = 0
        Me.txt_direccion_cliente.TabStop = False
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
        Me.txt_nombre_cliente.Size = New System.Drawing.Size(284, 24)
        Me.txt_nombre_cliente.TabIndex = 0
        Me.txt_nombre_cliente.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(235, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "COMUNA:"
        '
        'btn_agregar_clientes
        '
        Me.btn_agregar_clientes.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_agregar_clientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar_clientes.ForeColor = System.Drawing.Color.Black
        Me.btn_agregar_clientes.Image = CType(resources.GetObject("btn_agregar_clientes.Image"), System.Drawing.Image)
        Me.btn_agregar_clientes.Location = New System.Drawing.Point(958, 18)
        Me.btn_agregar_clientes.Name = "btn_agregar_clientes"
        Me.btn_agregar_clientes.Size = New System.Drawing.Size(40, 40)
        Me.btn_agregar_clientes.TabIndex = 0
        Me.btn_agregar_clientes.TabStop = False
        Me.btn_agregar_clientes.Text = "     "
        Me.btn_agregar_clientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_agregar_clientes.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(738, 59)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 16)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "GIRO:"
        '
        'txt_giro_cliente
        '
        Me.txt_giro_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_giro_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_giro_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_giro_cliente.Location = New System.Drawing.Point(741, 77)
        Me.txt_giro_cliente.Name = "txt_giro_cliente"
        Me.txt_giro_cliente.ReadOnly = True
        Me.txt_giro_cliente.Size = New System.Drawing.Size(257, 24)
        Me.txt_giro_cliente.TabIndex = 0
        Me.txt_giro_cliente.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(110, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "NOMBRE:"
        '
        'btn_buscar_clientes
        '
        Me.btn_buscar_clientes.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_buscar_clientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar_clientes.ForeColor = System.Drawing.Color.Black
        Me.btn_buscar_clientes.Image = CType(resources.GetObject("btn_buscar_clientes.Image"), System.Drawing.Image)
        Me.btn_buscar_clientes.Location = New System.Drawing.Point(913, 18)
        Me.btn_buscar_clientes.Name = "btn_buscar_clientes"
        Me.btn_buscar_clientes.Size = New System.Drawing.Size(40, 40)
        Me.btn_buscar_clientes.TabIndex = 0
        Me.btn_buscar_clientes.TabStop = False
        Me.btn_buscar_clientes.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "RUT:"
        '
        'txt_ciudad_cliente
        '
        Me.txt_ciudad_cliente.BackColor = System.Drawing.SystemColors.Control
        Me.txt_ciudad_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ciudad_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_ciudad_cliente.Location = New System.Drawing.Point(7, 77)
        Me.txt_ciudad_cliente.Name = "txt_ciudad_cliente"
        Me.txt_ciudad_cliente.ReadOnly = True
        Me.txt_ciudad_cliente.Size = New System.Drawing.Size(225, 24)
        Me.txt_ciudad_cliente.TabIndex = 9
        Me.txt_ciudad_cliente.TabStop = False
        '
        'txt_telefono
        '
        Me.txt_telefono.BackColor = System.Drawing.SystemColors.Control
        Me.txt_telefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_telefono.ForeColor = System.Drawing.Color.Black
        Me.txt_telefono.Location = New System.Drawing.Point(683, 33)
        Me.txt_telefono.Name = "txt_telefono"
        Me.txt_telefono.ReadOnly = True
        Me.txt_telefono.Size = New System.Drawing.Size(225, 24)
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
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btn_cancelar)
        Me.GroupBox4.Controls.Add(Me.btn_nueva)
        Me.GroupBox4.Controls.Add(Me.btn_modificar)
        Me.GroupBox4.Controls.Add(Me.btn_guardar)
        Me.GroupBox4.Controls.Add(Me.btn_limpiar)
        Me.GroupBox4.Controls.Add(Me.btn_imprimir)
        Me.GroupBox4.Location = New System.Drawing.Point(684, 554)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(328, 139)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.Transparent
        Me.btn_cancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(217, 73)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(95, 40)
        Me.btn_cancelar.TabIndex = 6
        Me.btn_cancelar.Text = "CANCELAR"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'btn_nueva
        '
        Me.btn_nueva.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_nueva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nueva.Image = CType(resources.GetObject("btn_nueva.Image"), System.Drawing.Image)
        Me.btn_nueva.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_nueva.Location = New System.Drawing.Point(17, 28)
        Me.btn_nueva.Name = "btn_nueva"
        Me.btn_nueva.Size = New System.Drawing.Size(95, 40)
        Me.btn_nueva.TabIndex = 1
        Me.btn_nueva.Text = "NUEVO"
        Me.btn_nueva.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_nueva.UseVisualStyleBackColor = True
        '
        'btn_modificar
        '
        Me.btn_modificar.BackColor = System.Drawing.Color.Transparent
        Me.btn_modificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_modificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_modificar.Image = CType(resources.GetObject("btn_modificar.Image"), System.Drawing.Image)
        Me.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_modificar.Location = New System.Drawing.Point(117, 73)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(95, 40)
        Me.btn_modificar.TabIndex = 5
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
        Me.btn_guardar.Location = New System.Drawing.Point(117, 28)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(95, 40)
        Me.btn_guardar.TabIndex = 2
        Me.btn_guardar.Text = "GUARDAR"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'btn_limpiar
        '
        Me.btn_limpiar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_limpiar.ForeColor = System.Drawing.Color.Black
        Me.btn_limpiar.Image = CType(resources.GetObject("btn_limpiar.Image"), System.Drawing.Image)
        Me.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_limpiar.Location = New System.Drawing.Point(17, 73)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(95, 40)
        Me.btn_limpiar.TabIndex = 4
        Me.btn_limpiar.Text = "LIMPIAR"
        Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_limpiar.UseVisualStyleBackColor = True
        '
        'btn_imprimir
        '
        Me.btn_imprimir.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.ForeColor = System.Drawing.Color.Black
        Me.btn_imprimir.Image = CType(resources.GetObject("btn_imprimir.Image"), System.Drawing.Image)
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprimir.Location = New System.Drawing.Point(217, 28)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(95, 40)
        Me.btn_imprimir.TabIndex = 3
        Me.btn_imprimir.Text = "IMPRIMIR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir.UseVisualStyleBackColor = True
        '
        'GroupBox_cargar
        '
        Me.GroupBox_cargar.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_cargar.Controls.Add(Me.txt_cargar)
        Me.GroupBox_cargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_cargar.Location = New System.Drawing.Point(555, 553)
        Me.GroupBox_cargar.Name = "GroupBox_cargar"
        Me.GroupBox_cargar.Size = New System.Drawing.Size(123, 69)
        Me.GroupBox_cargar.TabIndex = 8
        Me.GroupBox_cargar.TabStop = False
        Me.GroupBox_cargar.Text = "CARGAR:"
        '
        'txt_cargar
        '
        Me.txt_cargar.BackColor = System.Drawing.SystemColors.Window
        Me.txt_cargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cargar.ForeColor = System.Drawing.Color.Black
        Me.txt_cargar.Location = New System.Drawing.Point(11, 27)
        Me.txt_cargar.MaxLength = 11
        Me.txt_cargar.Name = "txt_cargar"
        Me.txt_cargar.Size = New System.Drawing.Size(100, 24)
        Me.txt_cargar.TabIndex = 0
        Me.txt_cargar.TabStop = False
        Me.txt_cargar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_diagnostico_cliente
        '
        Me.txt_diagnostico_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_diagnostico_cliente.Location = New System.Drawing.Point(7, 17)
        Me.txt_diagnostico_cliente.MaxLength = 350
        Me.txt_diagnostico_cliente.Multiline = True
        Me.txt_diagnostico_cliente.Name = "txt_diagnostico_cliente"
        Me.txt_diagnostico_cliente.Size = New System.Drawing.Size(739, 123)
        Me.txt_diagnostico_cliente.TabIndex = 246
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txt_diagnostico_cliente)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 185)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(753, 148)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DIAGNOSTICO DEL CLIENTE:"
        '
        'GroupBox_tecnico
        '
        Me.GroupBox_tecnico.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_tecnico.Controls.Add(Me.txt_diagnostico_tecnico)
        Me.GroupBox_tecnico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_tecnico.Location = New System.Drawing.Point(6, 333)
        Me.GroupBox_tecnico.Name = "GroupBox_tecnico"
        Me.GroupBox_tecnico.Size = New System.Drawing.Size(753, 150)
        Me.GroupBox_tecnico.TabIndex = 3
        Me.GroupBox_tecnico.TabStop = False
        Me.GroupBox_tecnico.Text = "DIAGNOSTICO DEL TECNICO:"
        '
        'txt_diagnostico_tecnico
        '
        Me.txt_diagnostico_tecnico.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_diagnostico_tecnico.Location = New System.Drawing.Point(7, 17)
        Me.txt_diagnostico_tecnico.MaxLength = 350
        Me.txt_diagnostico_tecnico.Multiline = True
        Me.txt_diagnostico_tecnico.Name = "txt_diagnostico_tecnico"
        Me.txt_diagnostico_tecnico.Size = New System.Drawing.Size(739, 122)
        Me.txt_diagnostico_tecnico.TabIndex = 246
        '
        'GroupBox_posicion
        '
        Me.GroupBox_posicion.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_posicion.Controls.Add(Me.btn_ultimo)
        Me.GroupBox_posicion.Controls.Add(Me.btn_siguiente)
        Me.GroupBox_posicion.Controls.Add(Me.btn_primero)
        Me.GroupBox_posicion.Controls.Add(Me.btn_anterior)
        Me.GroupBox_posicion.Location = New System.Drawing.Point(6, 554)
        Me.GroupBox_posicion.Name = "GroupBox_posicion"
        Me.GroupBox_posicion.Size = New System.Drawing.Size(414, 68)
        Me.GroupBox_posicion.TabIndex = 4
        Me.GroupBox_posicion.TabStop = False
        '
        'btn_ultimo
        '
        Me.btn_ultimo.BackColor = System.Drawing.Color.Transparent
        Me.btn_ultimo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_ultimo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ultimo.Image = CType(resources.GetObject("btn_ultimo.Image"), System.Drawing.Image)
        Me.btn_ultimo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ultimo.Location = New System.Drawing.Point(309, 17)
        Me.btn_ultimo.Name = "btn_ultimo"
        Me.btn_ultimo.Size = New System.Drawing.Size(95, 40)
        Me.btn_ultimo.TabIndex = 8
        Me.btn_ultimo.Text = "ULTIMO"
        Me.btn_ultimo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_ultimo.UseVisualStyleBackColor = True
        '
        'btn_siguiente
        '
        Me.btn_siguiente.BackColor = System.Drawing.Color.Transparent
        Me.btn_siguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_siguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_siguiente.Image = CType(resources.GetObject("btn_siguiente.Image"), System.Drawing.Image)
        Me.btn_siguiente.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_siguiente.Location = New System.Drawing.Point(209, 17)
        Me.btn_siguiente.Name = "btn_siguiente"
        Me.btn_siguiente.Size = New System.Drawing.Size(95, 40)
        Me.btn_siguiente.TabIndex = 7
        Me.btn_siguiente.Text = "SIGUIENTE"
        Me.btn_siguiente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_siguiente.UseVisualStyleBackColor = True
        '
        'btn_primero
        '
        Me.btn_primero.BackColor = System.Drawing.Color.Transparent
        Me.btn_primero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_primero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_primero.Image = CType(resources.GetObject("btn_primero.Image"), System.Drawing.Image)
        Me.btn_primero.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_primero.Location = New System.Drawing.Point(9, 17)
        Me.btn_primero.Name = "btn_primero"
        Me.btn_primero.Size = New System.Drawing.Size(95, 40)
        Me.btn_primero.TabIndex = 5
        Me.btn_primero.Text = "PRIMERO"
        Me.btn_primero.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_primero.UseVisualStyleBackColor = True
        '
        'btn_anterior
        '
        Me.btn_anterior.BackColor = System.Drawing.Color.Transparent
        Me.btn_anterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_anterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_anterior.Image = CType(resources.GetObject("btn_anterior.Image"), System.Drawing.Image)
        Me.btn_anterior.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_anterior.Location = New System.Drawing.Point(109, 17)
        Me.btn_anterior.Name = "btn_anterior"
        Me.btn_anterior.Size = New System.Drawing.Size(95, 40)
        Me.btn_anterior.TabIndex = 6
        Me.btn_anterior.Text = "ANTERIOR"
        Me.btn_anterior.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_anterior.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.txt_nro_doc)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(555, 622)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(123, 71)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "RECEPCION:"
        '
        'txt_nro_doc
        '
        Me.txt_nro_doc.BackColor = System.Drawing.SystemColors.Control
        Me.txt_nro_doc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_doc.ForeColor = System.Drawing.Color.Black
        Me.txt_nro_doc.Location = New System.Drawing.Point(11, 27)
        Me.txt_nro_doc.MaxLength = 11
        Me.txt_nro_doc.Name = "txt_nro_doc"
        Me.txt_nro_doc.ReadOnly = True
        Me.txt_nro_doc.Size = New System.Drawing.Size(100, 24)
        Me.txt_nro_doc.TabIndex = 0
        Me.txt_nro_doc.TabStop = False
        Me.txt_nro_doc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txt_pago_parcial)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(426, 622)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(123, 71)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "PAGO PARCIAL:"
        '
        'txt_pago_parcial
        '
        Me.txt_pago_parcial.BackColor = System.Drawing.SystemColors.Window
        Me.txt_pago_parcial.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pago_parcial.ForeColor = System.Drawing.Color.Black
        Me.txt_pago_parcial.Location = New System.Drawing.Point(11, 27)
        Me.txt_pago_parcial.MaxLength = 11
        Me.txt_pago_parcial.Name = "txt_pago_parcial"
        Me.txt_pago_parcial.Size = New System.Drawing.Size(100, 24)
        Me.txt_pago_parcial.TabIndex = 0
        Me.txt_pago_parcial.TabStop = False
        Me.txt_pago_parcial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.txt_total)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(426, 553)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(123, 69)
        Me.GroupBox6.TabIndex = 6
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "TOTAL:"
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.SystemColors.Window
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.Black
        Me.txt_total.Location = New System.Drawing.Point(11, 27)
        Me.txt_total.MaxLength = 11
        Me.txt_total.Name = "txt_total"
        Me.txt_total.Size = New System.Drawing.Size(100, 24)
        Me.txt_total.TabIndex = 0
        Me.txt_total.TabStop = False
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.Controls.Add(Me.txt_detalle_de_pago)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(6, 622)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(414, 71)
        Me.GroupBox7.TabIndex = 5
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "DETALLE DE PAGO:"
        '
        'txt_detalle_de_pago
        '
        Me.txt_detalle_de_pago.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_detalle_de_pago.Location = New System.Drawing.Point(7, 17)
        Me.txt_detalle_de_pago.MaxLength = 300
        Me.txt_detalle_de_pago.Multiline = True
        Me.txt_detalle_de_pago.Name = "txt_detalle_de_pago"
        Me.txt_detalle_de_pago.Size = New System.Drawing.Size(399, 46)
        Me.txt_detalle_de_pago.TabIndex = 247
        '
        'Check_retirado
        '
        Me.Check_retirado.AutoSize = True
        Me.Check_retirado.Location = New System.Drawing.Point(8, 38)
        Me.Check_retirado.Name = "Check_retirado"
        Me.Check_retirado.Size = New System.Drawing.Size(97, 20)
        Me.Check_retirado.TabIndex = 1
        Me.Check_retirado.TabStop = False
        Me.Check_retirado.Text = "RETIRADO"
        Me.Check_retirado.UseVisualStyleBackColor = True
        '
        'Check_cancelado
        '
        Me.Check_cancelado.AutoSize = True
        Me.Check_cancelado.Location = New System.Drawing.Point(8, 20)
        Me.Check_cancelado.Name = "Check_cancelado"
        Me.Check_cancelado.Size = New System.Drawing.Size(109, 20)
        Me.Check_cancelado.TabIndex = 0
        Me.Check_cancelado.TabStop = False
        Me.Check_cancelado.Text = "CANCELADO"
        Me.Check_cancelado.UseVisualStyleBackColor = True
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(307, 2)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(700, 81)
        Me.lbl_mensaje.TabIndex = 233
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'CheckedListBox_hardware
        '
        Me.CheckedListBox_hardware.CheckOnClick = True
        Me.CheckedListBox_hardware.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckedListBox_hardware.FormattingEnabled = True
        Me.CheckedListBox_hardware.Location = New System.Drawing.Point(7, 17)
        Me.CheckedListBox_hardware.Name = "CheckedListBox_hardware"
        Me.CheckedListBox_hardware.Size = New System.Drawing.Size(233, 344)
        Me.CheckedListBox_hardware.TabIndex = 234
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.CheckedListBox_hardware)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(765, 185)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(247, 369)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "HARDWARE A REVISAR:"
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox8.Controls.Add(Me.Combo_estado)
        Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(6, 483)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(244, 71)
        Me.GroupBox8.TabIndex = 10
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "ESTADO:"
        '
        'Combo_estado
        '
        Me.Combo_estado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_estado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_estado.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_estado.ForeColor = System.Drawing.Color.Black
        Me.Combo_estado.FormattingEnabled = True
        Me.Combo_estado.Items.AddRange(New Object() {"EN PROCESO", "CANCELADO", "RETIRADO", "CANCELADO / RETIRADO"})
        Me.Combo_estado.Location = New System.Drawing.Point(7, 27)
        Me.Combo_estado.Name = "Combo_estado"
        Me.Combo_estado.Size = New System.Drawing.Size(230, 26)
        Me.Combo_estado.TabIndex = 234
        '
        'txt_fecha
        '
        Me.txt_fecha.BackColor = System.Drawing.SystemColors.Control
        Me.txt_fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_fecha.ForeColor = System.Drawing.Color.Black
        Me.txt_fecha.Location = New System.Drawing.Point(11, 27)
        Me.txt_fecha.MaxLength = 11
        Me.txt_fecha.Name = "txt_fecha"
        Me.txt_fecha.ReadOnly = True
        Me.txt_fecha.Size = New System.Drawing.Size(100, 24)
        Me.txt_fecha.TabIndex = 1
        Me.txt_fecha.TabStop = False
        Me.txt_fecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_hora
        '
        Me.txt_hora.BackColor = System.Drawing.SystemColors.Control
        Me.txt_hora.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_hora.ForeColor = System.Drawing.Color.Black
        Me.txt_hora.Location = New System.Drawing.Point(11, 27)
        Me.txt_hora.MaxLength = 11
        Me.txt_hora.Name = "txt_hora"
        Me.txt_hora.ReadOnly = True
        Me.txt_hora.Size = New System.Drawing.Size(100, 24)
        Me.txt_hora.TabIndex = 247
        Me.txt_hora.TabStop = False
        Me.txt_hora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox9.Controls.Add(Me.txt_fecha)
        Me.GroupBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(507, 483)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(123, 71)
        Me.GroupBox9.TabIndex = 9
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "FECHA:"
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox10.Controls.Add(Me.txt_hora)
        Me.GroupBox10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox10.Location = New System.Drawing.Point(636, 483)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(123, 71)
        Me.GroupBox10.TabIndex = 10
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "HORA:"
        '
        'GroupBox11
        '
        Me.GroupBox11.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox11.Controls.Add(Me.Check_cancelado)
        Me.GroupBox11.Controls.Add(Me.Check_retirado)
        Me.GroupBox11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox11.Location = New System.Drawing.Point(378, 483)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(123, 71)
        Me.GroupBox11.TabIndex = 10
        Me.GroupBox11.TabStop = False
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
        'btn_busqueda_recepcion
        '
        Me.btn_busqueda_recepcion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_busqueda_recepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_busqueda_recepcion.ForeColor = System.Drawing.Color.Black
        Me.btn_busqueda_recepcion.Image = CType(resources.GetObject("btn_busqueda_recepcion.Image"), System.Drawing.Image)
        Me.btn_busqueda_recepcion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_busqueda_recepcion.Location = New System.Drawing.Point(10, 19)
        Me.btn_busqueda_recepcion.Name = "btn_busqueda_recepcion"
        Me.btn_busqueda_recepcion.Size = New System.Drawing.Size(95, 40)
        Me.btn_busqueda_recepcion.TabIndex = 250
        Me.btn_busqueda_recepcion.TabStop = False
        Me.btn_busqueda_recepcion.Text = "RECEPCION"
        Me.btn_busqueda_recepcion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_busqueda_recepcion.UseVisualStyleBackColor = True
        '
        'GroupBox12
        '
        Me.GroupBox12.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox12.Controls.Add(Me.btn_busqueda_recepcion)
        Me.GroupBox12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox12.Location = New System.Drawing.Point(256, 483)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(116, 71)
        Me.GroupBox12.TabIndex = 10
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "BUSQUEDA:"
        '
        'PrintDocument1
        '
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
        'Form_recepcion_de_trabajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 699)
        Me.Controls.Add(Me.GroupBox12)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox_posicion)
        Me.Controls.Add(Me.GroupBox_tecnico)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox_cargar)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox_clientes)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_recepcion_de_trabajo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RECEPCION DE TRABAJO"
        Me.GroupBox_clientes.ResumeLayout(False)
        Me.GroupBox_clientes.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox_cargar.ResumeLayout(False)
        Me.GroupBox_cargar.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox_tecnico.ResumeLayout(False)
        Me.GroupBox_tecnico.PerformLayout()
        Me.GroupBox_posicion.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox12.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox_clientes As System.Windows.Forms.GroupBox
    Friend WithEvents txt_rut_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre_cliente As System.Windows.Forms.TextBox
    Friend WithEvents btn_agregar_clientes As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_comuna_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_giro_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_direccion_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_buscar_clientes As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_ciudad_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_telefono As System.Windows.Forms.TextBox
    Friend WithEvents txt_cod_cliente As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_nueva As System.Windows.Forms.Button
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents GroupBox_cargar As System.Windows.Forms.GroupBox
    Friend WithEvents txt_cargar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_correo_cliente As System.Windows.Forms.TextBox
    Friend WithEvents txt_diagnostico_cliente As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox_tecnico As System.Windows.Forms.GroupBox
    Friend WithEvents txt_diagnostico_tecnico As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox_posicion As System.Windows.Forms.GroupBox
    Friend WithEvents btn_ultimo As System.Windows.Forms.Button
    Friend WithEvents btn_siguiente As System.Windows.Forms.Button
    Friend WithEvents btn_primero As System.Windows.Forms.Button
    Friend WithEvents btn_anterior As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_modificar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_nro_doc As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_pago_parcial As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Check_retirado As System.Windows.Forms.CheckBox
    Friend WithEvents Check_cancelado As System.Windows.Forms.CheckBox
    Friend WithEvents txt_detalle_de_pago As System.Windows.Forms.TextBox
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckedListBox_hardware As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Combo_estado As System.Windows.Forms.ComboBox
    Friend WithEvents txt_hora As System.Windows.Forms.TextBox
    Friend WithEvents txt_fecha As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_busqueda_recepcion As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
End Class
