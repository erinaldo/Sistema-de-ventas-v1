<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_registro_cuentas_corrientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_registro_cuentas_corrientes))
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox_posicion = New System.Windows.Forms.GroupBox
        Me.btn_ultimo = New System.Windows.Forms.Button
        Me.btn_siguiente = New System.Windows.Forms.Button
        Me.btn_primero = New System.Windows.Forms.Button
        Me.btn_anterior = New System.Windows.Forms.Button
        Me.GroupBox_botones = New System.Windows.Forms.GroupBox
        Me.btn_empresas = New System.Windows.Forms.Button
        Me.btn_aviso = New System.Windows.Forms.Button
        Me.btn_mensaje_cliente = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_modificar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.GroupBox_clientes = New System.Windows.Forms.GroupBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txt_representante = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_email_representante = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_email_dos = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_telefono_dos = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_giro = New System.Windows.Forms.TextBox
        Me.lbl_giro = New System.Windows.Forms.Label
        Me.Combo_activo = New System.Windows.Forms.ComboBox
        Me.lbl_activo = New System.Windows.Forms.Label
        Me.Combo_cuenta = New System.Windows.Forms.ComboBox
        Me.txt_cupo = New System.Windows.Forms.TextBox
        Me.lbl_cupo = New System.Windows.Forms.Label
        Me.lbl_directo = New System.Windows.Forms.Label
        Me.lbl_fin_de_mes = New System.Windows.Forms.Label
        Me.Combo_orden = New System.Windows.Forms.ComboBox
        Me.lbl_orden = New System.Windows.Forms.Label
        Me.Combo_tipo_cuenta = New System.Windows.Forms.ComboBox
        Me.lbl_tipo_cuenta = New System.Windows.Forms.Label
        Me.txt_ciudad = New System.Windows.Forms.TextBox
        Me.lbl_ciudad = New System.Windows.Forms.Label
        Me.txt_comuna = New System.Windows.Forms.TextBox
        Me.txt_email = New System.Windows.Forms.TextBox
        Me.txt_telefono = New System.Windows.Forms.TextBox
        Me.txt_dscto2 = New System.Windows.Forms.TextBox
        Me.lbl_descto1 = New System.Windows.Forms.Label
        Me.txt_direccion = New System.Windows.Forms.TextBox
        Me.txt_folio = New System.Windows.Forms.TextBox
        Me.lbl_descto2 = New System.Windows.Forms.Label
        Me.lbl_cuenta = New System.Windows.Forms.Label
        Me.lbl_comuna = New System.Windows.Forms.Label
        Me.txt_dscto1 = New System.Windows.Forms.TextBox
        Me.lbl_email = New System.Windows.Forms.Label
        Me.lbl_folio = New System.Windows.Forms.Label
        Me.lbl_telefono = New System.Windows.Forms.Label
        Me.lbl_direccion = New System.Windows.Forms.Label
        Me.txt_apellidos = New System.Windows.Forms.TextBox
        Me.lbl_apellidos = New System.Windows.Forms.Label
        Me.txt_rut = New System.Windows.Forms.TextBox
        Me.txt_pagare = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_pagare = New System.Windows.Forms.Label
        Me.lbl_nombre = New System.Windows.Forms.Label
        Me.txt_nombres = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.combo_tipo = New System.Windows.Forms.ComboBox
        Me.txt_codigo_cliente = New System.Windows.Forms.TextBox
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.txt_cuenta = New System.Windows.Forms.TextBox
        Me.grilla = New System.Windows.Forms.DataGridView
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_posicion.SuspendLayout()
        Me.GroupBox_botones.SuspendLayout()
        Me.GroupBox_clientes.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PictureBox_logo.TabIndex = 240
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox_posicion
        '
        Me.GroupBox_posicion.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_posicion.Controls.Add(Me.btn_ultimo)
        Me.GroupBox_posicion.Controls.Add(Me.btn_siguiente)
        Me.GroupBox_posicion.Controls.Add(Me.btn_primero)
        Me.GroupBox_posicion.Controls.Add(Me.btn_anterior)
        Me.GroupBox_posicion.Location = New System.Drawing.Point(6, 632)
        Me.GroupBox_posicion.Name = "GroupBox_posicion"
        Me.GroupBox_posicion.Size = New System.Drawing.Size(563, 61)
        Me.GroupBox_posicion.TabIndex = 239
        Me.GroupBox_posicion.TabStop = False
        '
        'btn_ultimo
        '
        Me.btn_ultimo.BackColor = System.Drawing.Color.Transparent
        Me.btn_ultimo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_ultimo.Image = CType(resources.GetObject("btn_ultimo.Image"), System.Drawing.Image)
        Me.btn_ultimo.Location = New System.Drawing.Point(516, 13)
        Me.btn_ultimo.Name = "btn_ultimo"
        Me.btn_ultimo.Size = New System.Drawing.Size(40, 40)
        Me.btn_ultimo.TabIndex = 8
        Me.btn_ultimo.UseVisualStyleBackColor = False
        '
        'btn_siguiente
        '
        Me.btn_siguiente.BackColor = System.Drawing.Color.Transparent
        Me.btn_siguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_siguiente.Image = CType(resources.GetObject("btn_siguiente.Image"), System.Drawing.Image)
        Me.btn_siguiente.Location = New System.Drawing.Point(471, 13)
        Me.btn_siguiente.Name = "btn_siguiente"
        Me.btn_siguiente.Size = New System.Drawing.Size(40, 40)
        Me.btn_siguiente.TabIndex = 7
        Me.btn_siguiente.UseVisualStyleBackColor = False
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
        'btn_anterior
        '
        Me.btn_anterior.BackColor = System.Drawing.Color.Transparent
        Me.btn_anterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_anterior.Image = CType(resources.GetObject("btn_anterior.Image"), System.Drawing.Image)
        Me.btn_anterior.Location = New System.Drawing.Point(57, 13)
        Me.btn_anterior.Name = "btn_anterior"
        Me.btn_anterior.Size = New System.Drawing.Size(40, 40)
        Me.btn_anterior.TabIndex = 6
        Me.btn_anterior.UseVisualStyleBackColor = False
        '
        'GroupBox_botones
        '
        Me.GroupBox_botones.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_botones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.GroupBox_botones.Controls.Add(Me.btn_empresas)
        Me.GroupBox_botones.Controls.Add(Me.btn_aviso)
        Me.GroupBox_botones.Controls.Add(Me.btn_mensaje_cliente)
        Me.GroupBox_botones.Controls.Add(Me.btn_salir)
        Me.GroupBox_botones.Controls.Add(Me.btn_nuevo)
        Me.GroupBox_botones.Controls.Add(Me.btn_cancelar)
        Me.GroupBox_botones.Controls.Add(Me.btn_modificar)
        Me.GroupBox_botones.Controls.Add(Me.btn_guardar)
        Me.GroupBox_botones.Controls.Add(Me.btn_buscar)
        Me.GroupBox_botones.Location = New System.Drawing.Point(575, 78)
        Me.GroupBox_botones.Name = "GroupBox_botones"
        Me.GroupBox_botones.Size = New System.Drawing.Size(109, 615)
        Me.GroupBox_botones.TabIndex = 238
        Me.GroupBox_botones.TabStop = False
        '
        'btn_empresas
        '
        Me.btn_empresas.BackColor = System.Drawing.Color.Transparent
        Me.btn_empresas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_empresas.Image = CType(resources.GetObject("btn_empresas.Image"), System.Drawing.Image)
        Me.btn_empresas.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_empresas.Location = New System.Drawing.Point(7, 238)
        Me.btn_empresas.Name = "btn_empresas"
        Me.btn_empresas.Size = New System.Drawing.Size(95, 40)
        Me.btn_empresas.TabIndex = 6
        Me.btn_empresas.Text = "EMPRESAS"
        Me.btn_empresas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_empresas.UseVisualStyleBackColor = False
        '
        'btn_aviso
        '
        Me.btn_aviso.BackColor = System.Drawing.Color.Transparent
        Me.btn_aviso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aviso.Image = CType(resources.GetObject("btn_aviso.Image"), System.Drawing.Image)
        Me.btn_aviso.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_aviso.Location = New System.Drawing.Point(7, 193)
        Me.btn_aviso.Name = "btn_aviso"
        Me.btn_aviso.Size = New System.Drawing.Size(95, 40)
        Me.btn_aviso.TabIndex = 5
        Me.btn_aviso.Text = "AVISO"
        Me.btn_aviso.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_aviso.UseVisualStyleBackColor = False
        '
        'btn_mensaje_cliente
        '
        Me.btn_mensaje_cliente.BackColor = System.Drawing.Color.Transparent
        Me.btn_mensaje_cliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_mensaje_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_mensaje_cliente.Image = CType(resources.GetObject("btn_mensaje_cliente.Image"), System.Drawing.Image)
        Me.btn_mensaje_cliente.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_mensaje_cliente.Location = New System.Drawing.Point(7, 148)
        Me.btn_mensaje_cliente.Name = "btn_mensaje_cliente"
        Me.btn_mensaje_cliente.Size = New System.Drawing.Size(95, 40)
        Me.btn_mensaje_cliente.TabIndex = 4
        Me.btn_mensaje_cliente.Text = "MENSAJE"
        Me.btn_mensaje_cliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_mensaje_cliente.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(7, 567)
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
        Me.btn_cancelar.Location = New System.Drawing.Point(7, 522)
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
        Me.btn_guardar.Location = New System.Drawing.Point(7, 477)
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
        Me.btn_buscar.Location = New System.Drawing.Point(7, 103)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(95, 40)
        Me.btn_buscar.TabIndex = 3
        Me.btn_buscar.Text = "BUSCAR"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_buscar.UseVisualStyleBackColor = False
        '
        'GroupBox_clientes
        '
        Me.GroupBox_clientes.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_clientes.Controls.Add(Me.Panel2)
        Me.GroupBox_clientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_clientes.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox_clientes.Name = "GroupBox_clientes"
        Me.GroupBox_clientes.Size = New System.Drawing.Size(563, 555)
        Me.GroupBox_clientes.TabIndex = 237
        Me.GroupBox_clientes.TabStop = False
        Me.GroupBox_clientes.Text = "DATOS DEL CLIENTE"
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.txt_apellidos)
        Me.Panel2.Controls.Add(Me.lbl_apellidos)
        Me.Panel2.Controls.Add(Me.txt_rut)
        Me.Panel2.Controls.Add(Me.txt_pagare)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lbl_pagare)
        Me.Panel2.Controls.Add(Me.lbl_nombre)
        Me.Panel2.Controls.Add(Me.txt_nombres)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.combo_tipo)
        Me.Panel2.Location = New System.Drawing.Point(-1, 14)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(557, 539)
        Me.Panel2.TabIndex = 243
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txt_representante)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txt_email_representante)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txt_email_dos)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txt_telefono_dos)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_giro)
        Me.Panel1.Controls.Add(Me.lbl_giro)
        Me.Panel1.Controls.Add(Me.Combo_activo)
        Me.Panel1.Controls.Add(Me.lbl_activo)
        Me.Panel1.Controls.Add(Me.Combo_cuenta)
        Me.Panel1.Controls.Add(Me.txt_cupo)
        Me.Panel1.Controls.Add(Me.lbl_cupo)
        Me.Panel1.Controls.Add(Me.lbl_directo)
        Me.Panel1.Controls.Add(Me.lbl_fin_de_mes)
        Me.Panel1.Controls.Add(Me.Combo_orden)
        Me.Panel1.Controls.Add(Me.lbl_orden)
        Me.Panel1.Controls.Add(Me.Combo_tipo_cuenta)
        Me.Panel1.Controls.Add(Me.lbl_tipo_cuenta)
        Me.Panel1.Controls.Add(Me.txt_ciudad)
        Me.Panel1.Controls.Add(Me.lbl_ciudad)
        Me.Panel1.Controls.Add(Me.txt_comuna)
        Me.Panel1.Controls.Add(Me.txt_email)
        Me.Panel1.Controls.Add(Me.txt_telefono)
        Me.Panel1.Controls.Add(Me.txt_dscto2)
        Me.Panel1.Controls.Add(Me.lbl_descto1)
        Me.Panel1.Controls.Add(Me.txt_direccion)
        Me.Panel1.Controls.Add(Me.txt_folio)
        Me.Panel1.Controls.Add(Me.lbl_descto2)
        Me.Panel1.Controls.Add(Me.lbl_cuenta)
        Me.Panel1.Controls.Add(Me.lbl_comuna)
        Me.Panel1.Controls.Add(Me.txt_dscto1)
        Me.Panel1.Controls.Add(Me.lbl_email)
        Me.Panel1.Controls.Add(Me.lbl_folio)
        Me.Panel1.Controls.Add(Me.lbl_telefono)
        Me.Panel1.Controls.Add(Me.lbl_direccion)
        Me.Panel1.Location = New System.Drawing.Point(5, 131)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(530, 561)
        Me.Panel1.TabIndex = 242
        '
        'txt_representante
        '
        Me.txt_representante.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_representante.Location = New System.Drawing.Point(136, 251)
        Me.txt_representante.MaxLength = 45
        Me.txt_representante.Name = "txt_representante"
        Me.txt_representante.Size = New System.Drawing.Size(392, 24)
        Me.txt_representante.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(2, 285)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 16)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "EMAIL REP.:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txt_email_representante
        '
        Me.txt_email_representante.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_email_representante.Location = New System.Drawing.Point(136, 282)
        Me.txt_email_representante.MaxLength = 45
        Me.txt_email_representante.Name = "txt_email_representante"
        Me.txt_email_representante.Size = New System.Drawing.Size(392, 24)
        Me.txt_email_representante.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(2, 223)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(133, 16)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = "DIRECCION:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txt_email_dos
        '
        Me.txt_email_dos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_email_dos.Location = New System.Drawing.Point(136, 124)
        Me.txt_email_dos.MaxLength = 45
        Me.txt_email_dos.Name = "txt_email_dos"
        Me.txt_email_dos.Size = New System.Drawing.Size(392, 24)
        Me.txt_email_dos.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 16)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "E-MAIL 2:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txt_telefono_dos
        '
        Me.txt_telefono_dos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_telefono_dos.Location = New System.Drawing.Point(136, 62)
        Me.txt_telefono_dos.MaxLength = 10
        Me.txt_telefono_dos.Name = "txt_telefono_dos"
        Me.txt_telefono_dos.Size = New System.Drawing.Size(150, 24)
        Me.txt_telefono_dos.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 16)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "TELEFONO 2:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txt_giro
        '
        Me.txt_giro.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_giro.Location = New System.Drawing.Point(136, 0)
        Me.txt_giro.MaxLength = 45
        Me.txt_giro.Name = "txt_giro"
        Me.txt_giro.Size = New System.Drawing.Size(392, 24)
        Me.txt_giro.TabIndex = 5
        '
        'lbl_giro
        '
        Me.lbl_giro.BackColor = System.Drawing.Color.Transparent
        Me.lbl_giro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_giro.Location = New System.Drawing.Point(2, 3)
        Me.lbl_giro.Name = "lbl_giro"
        Me.lbl_giro.Size = New System.Drawing.Size(133, 16)
        Me.lbl_giro.TabIndex = 37
        Me.lbl_giro.Text = "GIRO:"
        Me.lbl_giro.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Combo_activo
        '
        Me.Combo_activo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_activo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_activo.FormattingEnabled = True
        Me.Combo_activo.Items.AddRange(New Object() {"-", "SI", "NO"})
        Me.Combo_activo.Location = New System.Drawing.Point(136, 530)
        Me.Combo_activo.Name = "Combo_activo"
        Me.Combo_activo.Size = New System.Drawing.Size(150, 24)
        Me.Combo_activo.TabIndex = 22
        '
        'lbl_activo
        '
        Me.lbl_activo.BackColor = System.Drawing.Color.Transparent
        Me.lbl_activo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_activo.Location = New System.Drawing.Point(2, 533)
        Me.lbl_activo.Name = "lbl_activo"
        Me.lbl_activo.Size = New System.Drawing.Size(133, 16)
        Me.lbl_activo.TabIndex = 62
        Me.lbl_activo.Text = "ACTIVO:"
        Me.lbl_activo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Combo_cuenta
        '
        Me.Combo_cuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_cuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_cuenta.FormattingEnabled = True
        Me.Combo_cuenta.Items.AddRange(New Object() {"-", "CERRADA", "ABIERTA", "BLOQUEADA", "SIN CUENTA"})
        Me.Combo_cuenta.Location = New System.Drawing.Point(136, 499)
        Me.Combo_cuenta.Name = "Combo_cuenta"
        Me.Combo_cuenta.Size = New System.Drawing.Size(150, 24)
        Me.Combo_cuenta.TabIndex = 21
        '
        'txt_cupo
        '
        Me.txt_cupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cupo.Location = New System.Drawing.Point(136, 468)
        Me.txt_cupo.MaxLength = 8
        Me.txt_cupo.Name = "txt_cupo"
        Me.txt_cupo.Size = New System.Drawing.Size(150, 24)
        Me.txt_cupo.TabIndex = 20
        '
        'lbl_cupo
        '
        Me.lbl_cupo.BackColor = System.Drawing.Color.Transparent
        Me.lbl_cupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cupo.Location = New System.Drawing.Point(2, 471)
        Me.lbl_cupo.Name = "lbl_cupo"
        Me.lbl_cupo.Size = New System.Drawing.Size(133, 16)
        Me.lbl_cupo.TabIndex = 61
        Me.lbl_cupo.Text = "CUPO:"
        Me.lbl_cupo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_directo
        '
        Me.lbl_directo.AutoSize = True
        Me.lbl_directo.BackColor = System.Drawing.Color.Transparent
        Me.lbl_directo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_directo.Location = New System.Drawing.Point(288, 316)
        Me.lbl_directo.Name = "lbl_directo"
        Me.lbl_directo.Size = New System.Drawing.Size(76, 16)
        Me.lbl_directo.TabIndex = 60
        Me.lbl_directo.Text = "(DIRECTO)"
        '
        'lbl_fin_de_mes
        '
        Me.lbl_fin_de_mes.AutoSize = True
        Me.lbl_fin_de_mes.BackColor = System.Drawing.Color.Transparent
        Me.lbl_fin_de_mes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fin_de_mes.Location = New System.Drawing.Point(288, 347)
        Me.lbl_fin_de_mes.Name = "lbl_fin_de_mes"
        Me.lbl_fin_de_mes.Size = New System.Drawing.Size(91, 16)
        Me.lbl_fin_de_mes.TabIndex = 59
        Me.lbl_fin_de_mes.Text = "(FIN DE MES)"
        '
        'Combo_orden
        '
        Me.Combo_orden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_orden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_orden.FormattingEnabled = True
        Me.Combo_orden.Items.AddRange(New Object() {"SI", "NO"})
        Me.Combo_orden.Location = New System.Drawing.Point(136, 437)
        Me.Combo_orden.Name = "Combo_orden"
        Me.Combo_orden.Size = New System.Drawing.Size(150, 24)
        Me.Combo_orden.TabIndex = 19
        '
        'lbl_orden
        '
        Me.lbl_orden.BackColor = System.Drawing.Color.Transparent
        Me.lbl_orden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_orden.Location = New System.Drawing.Point(2, 440)
        Me.lbl_orden.Name = "lbl_orden"
        Me.lbl_orden.Size = New System.Drawing.Size(133, 16)
        Me.lbl_orden.TabIndex = 58
        Me.lbl_orden.Text = "O.C.:"
        Me.lbl_orden.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Combo_tipo_cuenta
        '
        Me.Combo_tipo_cuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_tipo_cuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_tipo_cuenta.FormattingEnabled = True
        Me.Combo_tipo_cuenta.Items.AddRange(New Object() {"-", "BOLETA", "FACTURA", "GUIA", "MIXTA"})
        Me.Combo_tipo_cuenta.Location = New System.Drawing.Point(136, 406)
        Me.Combo_tipo_cuenta.Name = "Combo_tipo_cuenta"
        Me.Combo_tipo_cuenta.Size = New System.Drawing.Size(150, 24)
        Me.Combo_tipo_cuenta.TabIndex = 18
        '
        'lbl_tipo_cuenta
        '
        Me.lbl_tipo_cuenta.BackColor = System.Drawing.Color.Transparent
        Me.lbl_tipo_cuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tipo_cuenta.Location = New System.Drawing.Point(2, 409)
        Me.lbl_tipo_cuenta.Name = "lbl_tipo_cuenta"
        Me.lbl_tipo_cuenta.Size = New System.Drawing.Size(133, 16)
        Me.lbl_tipo_cuenta.TabIndex = 57
        Me.lbl_tipo_cuenta.Text = "TIPO DOC.:"
        Me.lbl_tipo_cuenta.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txt_ciudad
        '
        Me.txt_ciudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ciudad.Location = New System.Drawing.Point(136, 189)
        Me.txt_ciudad.MaxLength = 45
        Me.txt_ciudad.Name = "txt_ciudad"
        Me.txt_ciudad.Size = New System.Drawing.Size(392, 24)
        Me.txt_ciudad.TabIndex = 11
        '
        'lbl_ciudad
        '
        Me.lbl_ciudad.BackColor = System.Drawing.Color.Transparent
        Me.lbl_ciudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ciudad.Location = New System.Drawing.Point(2, 192)
        Me.lbl_ciudad.Name = "lbl_ciudad"
        Me.lbl_ciudad.Size = New System.Drawing.Size(133, 16)
        Me.lbl_ciudad.TabIndex = 56
        Me.lbl_ciudad.Text = "CIUDAD:"
        Me.lbl_ciudad.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txt_comuna
        '
        Me.txt_comuna.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_comuna.Location = New System.Drawing.Point(136, 158)
        Me.txt_comuna.MaxLength = 45
        Me.txt_comuna.Name = "txt_comuna"
        Me.txt_comuna.Size = New System.Drawing.Size(392, 24)
        Me.txt_comuna.TabIndex = 10
        '
        'txt_email
        '
        Me.txt_email.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_email.Location = New System.Drawing.Point(136, 93)
        Me.txt_email.MaxLength = 45
        Me.txt_email.Name = "txt_email"
        Me.txt_email.Size = New System.Drawing.Size(392, 24)
        Me.txt_email.TabIndex = 8
        '
        'txt_telefono
        '
        Me.txt_telefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_telefono.Location = New System.Drawing.Point(136, 31)
        Me.txt_telefono.MaxLength = 10
        Me.txt_telefono.Name = "txt_telefono"
        Me.txt_telefono.Size = New System.Drawing.Size(150, 24)
        Me.txt_telefono.TabIndex = 6
        '
        'txt_dscto2
        '
        Me.txt_dscto2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dscto2.Location = New System.Drawing.Point(136, 344)
        Me.txt_dscto2.MaxLength = 2
        Me.txt_dscto2.Name = "txt_dscto2"
        Me.txt_dscto2.Size = New System.Drawing.Size(150, 24)
        Me.txt_dscto2.TabIndex = 16
        '
        'lbl_descto1
        '
        Me.lbl_descto1.BackColor = System.Drawing.Color.Transparent
        Me.lbl_descto1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_descto1.Location = New System.Drawing.Point(2, 316)
        Me.lbl_descto1.Name = "lbl_descto1"
        Me.lbl_descto1.Size = New System.Drawing.Size(133, 16)
        Me.lbl_descto1.TabIndex = 31
        Me.lbl_descto1.Text = "DTO.  1:"
        Me.lbl_descto1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txt_direccion
        '
        Me.txt_direccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_direccion.Location = New System.Drawing.Point(136, 220)
        Me.txt_direccion.MaxLength = 45
        Me.txt_direccion.Name = "txt_direccion"
        Me.txt_direccion.Size = New System.Drawing.Size(392, 24)
        Me.txt_direccion.TabIndex = 12
        '
        'txt_folio
        '
        Me.txt_folio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_folio.Location = New System.Drawing.Point(136, 375)
        Me.txt_folio.MaxLength = 6
        Me.txt_folio.Name = "txt_folio"
        Me.txt_folio.Size = New System.Drawing.Size(150, 24)
        Me.txt_folio.TabIndex = 17
        '
        'lbl_descto2
        '
        Me.lbl_descto2.BackColor = System.Drawing.Color.Transparent
        Me.lbl_descto2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_descto2.Location = New System.Drawing.Point(2, 347)
        Me.lbl_descto2.Name = "lbl_descto2"
        Me.lbl_descto2.Size = New System.Drawing.Size(133, 16)
        Me.lbl_descto2.TabIndex = 34
        Me.lbl_descto2.Text = "DTO.  2:"
        Me.lbl_descto2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_cuenta
        '
        Me.lbl_cuenta.BackColor = System.Drawing.Color.Transparent
        Me.lbl_cuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cuenta.Location = New System.Drawing.Point(2, 502)
        Me.lbl_cuenta.Name = "lbl_cuenta"
        Me.lbl_cuenta.Size = New System.Drawing.Size(133, 16)
        Me.lbl_cuenta.TabIndex = 35
        Me.lbl_cuenta.Text = "ESTADO CUENTA:"
        Me.lbl_cuenta.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_comuna
        '
        Me.lbl_comuna.BackColor = System.Drawing.Color.Transparent
        Me.lbl_comuna.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_comuna.Location = New System.Drawing.Point(2, 161)
        Me.lbl_comuna.Name = "lbl_comuna"
        Me.lbl_comuna.Size = New System.Drawing.Size(133, 16)
        Me.lbl_comuna.TabIndex = 33
        Me.lbl_comuna.Text = "COMUNA:"
        Me.lbl_comuna.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txt_dscto1
        '
        Me.txt_dscto1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dscto1.Location = New System.Drawing.Point(136, 313)
        Me.txt_dscto1.MaxLength = 2
        Me.txt_dscto1.Name = "txt_dscto1"
        Me.txt_dscto1.Size = New System.Drawing.Size(150, 24)
        Me.txt_dscto1.TabIndex = 15
        '
        'lbl_email
        '
        Me.lbl_email.BackColor = System.Drawing.Color.Transparent
        Me.lbl_email.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_email.Location = New System.Drawing.Point(2, 96)
        Me.lbl_email.Name = "lbl_email"
        Me.lbl_email.Size = New System.Drawing.Size(133, 16)
        Me.lbl_email.TabIndex = 36
        Me.lbl_email.Text = "E-MAIL:"
        Me.lbl_email.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_folio
        '
        Me.lbl_folio.BackColor = System.Drawing.Color.Transparent
        Me.lbl_folio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_folio.Location = New System.Drawing.Point(2, 378)
        Me.lbl_folio.Name = "lbl_folio"
        Me.lbl_folio.Size = New System.Drawing.Size(133, 16)
        Me.lbl_folio.TabIndex = 32
        Me.lbl_folio.Text = "FOLIO:"
        Me.lbl_folio.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_telefono
        '
        Me.lbl_telefono.BackColor = System.Drawing.Color.Transparent
        Me.lbl_telefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_telefono.Location = New System.Drawing.Point(2, 34)
        Me.lbl_telefono.Name = "lbl_telefono"
        Me.lbl_telefono.Size = New System.Drawing.Size(133, 16)
        Me.lbl_telefono.TabIndex = 38
        Me.lbl_telefono.Text = "TELEFONO:"
        Me.lbl_telefono.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_direccion
        '
        Me.lbl_direccion.BackColor = System.Drawing.Color.Transparent
        Me.lbl_direccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_direccion.Location = New System.Drawing.Point(2, 254)
        Me.lbl_direccion.Name = "lbl_direccion"
        Me.lbl_direccion.Size = New System.Drawing.Size(133, 16)
        Me.lbl_direccion.TabIndex = 39
        Me.lbl_direccion.Text = "REPRESENTANTE:"
        Me.lbl_direccion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txt_apellidos
        '
        Me.txt_apellidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_apellidos.Location = New System.Drawing.Point(141, 101)
        Me.txt_apellidos.MaxLength = 45
        Me.txt_apellidos.Name = "txt_apellidos"
        Me.txt_apellidos.Size = New System.Drawing.Size(392, 24)
        Me.txt_apellidos.TabIndex = 4
        Me.txt_apellidos.Visible = False
        '
        'lbl_apellidos
        '
        Me.lbl_apellidos.BackColor = System.Drawing.Color.Transparent
        Me.lbl_apellidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_apellidos.Location = New System.Drawing.Point(7, 104)
        Me.lbl_apellidos.Name = "lbl_apellidos"
        Me.lbl_apellidos.Size = New System.Drawing.Size(133, 16)
        Me.lbl_apellidos.TabIndex = 55
        Me.lbl_apellidos.Text = "APELLIDOS:"
        Me.lbl_apellidos.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lbl_apellidos.Visible = False
        '
        'txt_rut
        '
        Me.txt_rut.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rut.Location = New System.Drawing.Point(141, 39)
        Me.txt_rut.MaxLength = 11
        Me.txt_rut.Name = "txt_rut"
        Me.txt_rut.Size = New System.Drawing.Size(150, 24)
        Me.txt_rut.TabIndex = 2
        '
        'txt_pagare
        '
        Me.txt_pagare.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pagare.Location = New System.Drawing.Point(383, 8)
        Me.txt_pagare.MaxLength = 11
        Me.txt_pagare.Name = "txt_pagare"
        Me.txt_pagare.Size = New System.Drawing.Size(150, 24)
        Me.txt_pagare.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "RUT:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_pagare
        '
        Me.lbl_pagare.BackColor = System.Drawing.Color.Transparent
        Me.lbl_pagare.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pagare.Location = New System.Drawing.Point(298, 11)
        Me.lbl_pagare.Name = "lbl_pagare"
        Me.lbl_pagare.Size = New System.Drawing.Size(84, 16)
        Me.lbl_pagare.TabIndex = 31
        Me.lbl_pagare.Text = "PAGARE:"
        Me.lbl_pagare.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_nombre
        '
        Me.lbl_nombre.BackColor = System.Drawing.Color.Transparent
        Me.lbl_nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nombre.Location = New System.Drawing.Point(7, 73)
        Me.lbl_nombre.Name = "lbl_nombre"
        Me.lbl_nombre.Size = New System.Drawing.Size(133, 16)
        Me.lbl_nombre.TabIndex = 0
        Me.lbl_nombre.Text = "NOMBRES:"
        Me.lbl_nombre.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txt_nombres
        '
        Me.txt_nombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombres.Location = New System.Drawing.Point(141, 70)
        Me.txt_nombres.MaxLength = 45
        Me.txt_nombres.Name = "txt_nombres"
        Me.txt_nombres.Size = New System.Drawing.Size(392, 24)
        Me.txt_nombres.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(133, 16)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "TIPO CUENTA:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'combo_tipo
        '
        Me.combo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_tipo.FormattingEnabled = True
        Me.combo_tipo.Items.AddRange(New Object() {"TIPO CUENTA", "EMPRESA", "PERSONA", "-"})
        Me.combo_tipo.Location = New System.Drawing.Point(141, 8)
        Me.combo_tipo.Name = "combo_tipo"
        Me.combo_tipo.Size = New System.Drawing.Size(150, 24)
        Me.combo_tipo.TabIndex = 1
        '
        'txt_codigo_cliente
        '
        Me.txt_codigo_cliente.Enabled = False
        Me.txt_codigo_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_cliente.Location = New System.Drawing.Point(364, 122)
        Me.txt_codigo_cliente.MaxLength = 11
        Me.txt_codigo_cliente.Name = "txt_codigo_cliente"
        Me.txt_codigo_cliente.Size = New System.Drawing.Size(120, 24)
        Me.txt_codigo_cliente.TabIndex = 21
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
        'txt_cuenta
        '
        Me.txt_cuenta.Enabled = False
        Me.txt_cuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cuenta.Location = New System.Drawing.Point(393, 109)
        Me.txt_cuenta.MaxLength = 6
        Me.txt_cuenta.Name = "txt_cuenta"
        Me.txt_cuenta.Size = New System.Drawing.Size(83, 24)
        Me.txt_cuenta.TabIndex = 28
        Me.txt_cuenta.TabStop = False
        '
        'grilla
        '
        Me.grilla.AllowUserToAddRows = False
        Me.grilla.AllowUserToDeleteRows = False
        Me.grilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Location = New System.Drawing.Point(697, 6)
        Me.grilla.Name = "grilla"
        Me.grilla.ReadOnly = True
        Me.grilla.Size = New System.Drawing.Size(45, 33)
        Me.grilla.TabIndex = 241
        Me.grilla.TabStop = False
        '
        'Form_registro_cuentas_corrientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 699)
        Me.Controls.Add(Me.grilla)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox_posicion)
        Me.Controls.Add(Me.GroupBox_botones)
        Me.Controls.Add(Me.GroupBox_clientes)
        Me.Controls.Add(Me.txt_codigo_cliente)
        Me.Controls.Add(Me.txt_cuenta)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_registro_cuentas_corrientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REGISTRO DE CUENTAS CORRIENTES"
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_posicion.ResumeLayout(False)
        Me.GroupBox_botones.ResumeLayout(False)
        Me.GroupBox_clientes.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox_posicion As System.Windows.Forms.GroupBox
    Friend WithEvents btn_ultimo As System.Windows.Forms.Button
    Friend WithEvents btn_siguiente As System.Windows.Forms.Button
    Friend WithEvents btn_primero As System.Windows.Forms.Button
    Friend WithEvents btn_anterior As System.Windows.Forms.Button
    Friend WithEvents GroupBox_botones As System.Windows.Forms.GroupBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_modificar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents GroupBox_clientes As System.Windows.Forms.GroupBox
    Friend WithEvents txt_nombres As System.Windows.Forms.TextBox
    Friend WithEvents combo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_rut As System.Windows.Forms.TextBox
    Friend WithEvents lbl_nombre As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents txt_codigo_cliente As System.Windows.Forms.TextBox
    Friend WithEvents btn_mensaje_cliente As System.Windows.Forms.Button
    Friend WithEvents txt_cuenta As System.Windows.Forms.TextBox
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents txt_pagare As System.Windows.Forms.TextBox
    Friend WithEvents lbl_pagare As System.Windows.Forms.Label
    Friend WithEvents btn_aviso As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_giro As System.Windows.Forms.TextBox
    Friend WithEvents lbl_giro As System.Windows.Forms.Label
    Friend WithEvents Combo_activo As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_activo As System.Windows.Forms.Label
    Friend WithEvents Combo_cuenta As System.Windows.Forms.ComboBox
    Friend WithEvents txt_cupo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_cupo As System.Windows.Forms.Label
    Friend WithEvents lbl_directo As System.Windows.Forms.Label
    Friend WithEvents lbl_fin_de_mes As System.Windows.Forms.Label
    Friend WithEvents Combo_orden As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_orden As System.Windows.Forms.Label
    Friend WithEvents Combo_tipo_cuenta As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_tipo_cuenta As System.Windows.Forms.Label
    Friend WithEvents txt_ciudad As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ciudad As System.Windows.Forms.Label
    Friend WithEvents txt_comuna As System.Windows.Forms.TextBox
    Friend WithEvents txt_email As System.Windows.Forms.TextBox
    Friend WithEvents txt_telefono As System.Windows.Forms.TextBox
    Friend WithEvents txt_dscto2 As System.Windows.Forms.TextBox
    Friend WithEvents lbl_descto1 As System.Windows.Forms.Label
    Friend WithEvents txt_direccion As System.Windows.Forms.TextBox
    Friend WithEvents txt_folio As System.Windows.Forms.TextBox
    Friend WithEvents lbl_descto2 As System.Windows.Forms.Label
    Friend WithEvents lbl_cuenta As System.Windows.Forms.Label
    Friend WithEvents lbl_comuna As System.Windows.Forms.Label
    Friend WithEvents txt_dscto1 As System.Windows.Forms.TextBox
    Friend WithEvents lbl_email As System.Windows.Forms.Label
    Friend WithEvents lbl_folio As System.Windows.Forms.Label
    Friend WithEvents lbl_telefono As System.Windows.Forms.Label
    Friend WithEvents lbl_direccion As System.Windows.Forms.Label
    Friend WithEvents txt_apellidos As System.Windows.Forms.TextBox
    Friend WithEvents lbl_apellidos As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txt_representante As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_email_representante As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_email_dos As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_telefono_dos As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_empresas As System.Windows.Forms.Button
End Class
