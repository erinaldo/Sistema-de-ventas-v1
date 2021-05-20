<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class form_Ingreso
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_Ingreso))
        Me.lbl_ingrese_clave = New System.Windows.Forms.Label()
        Me.txt_usuario = New System.Windows.Forms.TextBox()
        Me.txt_clave = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_version = New System.Windows.Forms.Label()
        Me.lbl_equipo = New System.Windows.Forms.Label()
        Me.grilla_conexiones = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Timer_memoria = New System.Windows.Forms.Timer(Me.components)
        Me.titleBar = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_minimize = New System.Windows.Forms.Button()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lbl_ingrese_usuario = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lbl_mac = New System.Windows.Forms.Label()
        Me.combo_conexion = New System.Windows.Forms.ComboBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Barra_lateral_izquierda1 = New proyecto_sistema_ventas.Barra_lateral_izquierda()
        Me.Barra_lateral_derecha1 = New proyecto_sistema_ventas.Barra_lateral_derecha()
        CType(Me.grilla_conexiones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.titleBar.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_ingrese_clave
        '
        Me.lbl_ingrese_clave.AutoSize = True
        Me.lbl_ingrese_clave.BackColor = System.Drawing.Color.White
        Me.lbl_ingrese_clave.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ingrese_clave.ForeColor = System.Drawing.Color.Gray
        Me.lbl_ingrese_clave.Location = New System.Drawing.Point(76, 272)
        Me.lbl_ingrese_clave.Name = "lbl_ingrese_clave"
        Me.lbl_ingrese_clave.Size = New System.Drawing.Size(147, 19)
        Me.lbl_ingrese_clave.TabIndex = 1
        Me.lbl_ingrese_clave.Text = "Ingrese una clave"
        '
        'txt_usuario
        '
        Me.txt_usuario.BackColor = System.Drawing.Color.White
        Me.txt_usuario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_usuario.Font = New System.Drawing.Font("Century Gothic", 11.25!)
        Me.txt_usuario.Location = New System.Drawing.Point(71, 227)
        Me.txt_usuario.Margin = New System.Windows.Forms.Padding(3, 8, 3, 3)
        Me.txt_usuario.Name = "txt_usuario"
        Me.txt_usuario.Size = New System.Drawing.Size(217, 19)
        Me.txt_usuario.TabIndex = 1
        '
        'txt_clave
        '
        Me.txt_clave.BackColor = System.Drawing.Color.White
        Me.txt_clave.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_clave.Font = New System.Drawing.Font("Century Gothic", 11.25!)
        Me.txt_clave.Location = New System.Drawing.Point(71, 274)
        Me.txt_clave.Margin = New System.Windows.Forms.Padding(3, 8, 3, 3)
        Me.txt_clave.Name = "txt_clave"
        Me.txt_clave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txt_clave.Size = New System.Drawing.Size(217, 19)
        Me.txt_clave.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(344, 189)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(142, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "RECUPERAR CLAVE."
        '
        'lbl_version
        '
        Me.lbl_version.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_version.AutoSize = True
        Me.lbl_version.BackColor = System.Drawing.Color.Transparent
        Me.lbl_version.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_version.Location = New System.Drawing.Point(4, 410)
        Me.lbl_version.Name = "lbl_version"
        Me.lbl_version.Size = New System.Drawing.Size(115, 19)
        Me.lbl_version.TabIndex = 255
        Me.lbl_version.Text = "VERSION 1.0.0.0"
        Me.lbl_version.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_equipo
        '
        Me.lbl_equipo.BackColor = System.Drawing.Color.Transparent
        Me.lbl_equipo.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_equipo.Location = New System.Drawing.Point(158, 410)
        Me.lbl_equipo.Name = "lbl_equipo"
        Me.lbl_equipo.Size = New System.Drawing.Size(162, 16)
        Me.lbl_equipo.TabIndex = 256
        Me.lbl_equipo.Text = "NOMBRE EQUIPO"
        Me.lbl_equipo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'grilla_conexiones
        '
        Me.grilla_conexiones.AllowUserToAddRows = False
        Me.grilla_conexiones.AllowUserToDeleteRows = False
        Me.grilla_conexiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_conexiones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grilla_conexiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_conexiones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.Column2, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.Column1})
        Me.grilla_conexiones.Location = New System.Drawing.Point(380, 232)
        Me.grilla_conexiones.Name = "grilla_conexiones"
        Me.grilla_conexiones.ReadOnly = True
        Me.grilla_conexiones.Size = New System.Drawing.Size(38, 41)
        Me.grilla_conexiones.TabIndex = 263
        Me.grilla_conexiones.TabStop = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "SERVIDOR"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "REMOTO"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "BD"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "CLAVE"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "USUARIO"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "RECINTO"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "EMPRESA"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "TIPO"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'BackgroundWorker1
        '
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(10, 44)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 120)
        Me.PictureBox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox_logo.TabIndex = 110
        Me.PictureBox_logo.TabStop = False
        '
        'btn_aceptar
        '
        Me.btn_aceptar.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.btn_aceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_aceptar.FlatAppearance.BorderSize = 0
        Me.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_aceptar.Font = New System.Drawing.Font("Century Gothic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.ForeColor = System.Drawing.Color.White
        Me.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_aceptar.Location = New System.Drawing.Point(34, 329)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(254, 40)
        Me.btn_aceptar.TabIndex = 3
        Me.btn_aceptar.Text = "INGRESAR"
        Me.btn_aceptar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Location = New System.Drawing.Point(353, 119)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(322, 266)
        Me.Panel1.TabIndex = 299
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(-1, 205)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(322, 18)
        Me.Label5.TabIndex = 300
        Me.Label5.Text = "ESPERE UN MOMENTO..."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.ErrorImage = Nothing
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(-56, -42)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(388, 229)
        Me.PictureBox2.TabIndex = 300
        Me.PictureBox2.TabStop = False
        '
        'Timer_memoria
        '
        '
        'titleBar
        '
        Me.titleBar.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.titleBar.Controls.Add(Me.Label2)
        Me.titleBar.Controls.Add(Me.btn_minimize)
        Me.titleBar.Controls.Add(Me.btn_close)
        Me.titleBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.titleBar.Location = New System.Drawing.Point(0, 0)
        Me.titleBar.Margin = New System.Windows.Forms.Padding(2)
        Me.titleBar.Name = "titleBar"
        Me.titleBar.Size = New System.Drawing.Size(322, 37)
        Me.titleBar.TabIndex = 302
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(5, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 27)
        Me.Label2.TabIndex = 332
        Me.Label2.Text = "Ingreso"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_minimize
        '
        Me.btn_minimize.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.btn_minimize.BackgroundImage = CType(resources.GetObject("btn_minimize.BackgroundImage"), System.Drawing.Image)
        Me.btn_minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_minimize.FlatAppearance.BorderSize = 0
        Me.btn_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_minimize.Font = New System.Drawing.Font("Arial Unicode MS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_minimize.ForeColor = System.Drawing.Color.White
        Me.btn_minimize.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_minimize.Location = New System.Drawing.Point(259, 5)
        Me.btn_minimize.Margin = New System.Windows.Forms.Padding(4, 4, 4, 0)
        Me.btn_minimize.Name = "btn_minimize"
        Me.btn_minimize.Padding = New System.Windows.Forms.Padding(8)
        Me.btn_minimize.Size = New System.Drawing.Size(27, 27)
        Me.btn_minimize.TabIndex = 322
        Me.btn_minimize.TabStop = False
        Me.btn_minimize.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_minimize.UseVisualStyleBackColor = False
        '
        'btn_close
        '
        Me.btn_close.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.btn_close.BackgroundImage = CType(resources.GetObject("btn_close.BackgroundImage"), System.Drawing.Image)
        Me.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_close.FlatAppearance.BorderSize = 0
        Me.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_close.Font = New System.Drawing.Font("Arial Unicode MS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_close.ForeColor = System.Drawing.Color.White
        Me.btn_close.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_close.Location = New System.Drawing.Point(290, 5)
        Me.btn_close.Margin = New System.Windows.Forms.Padding(4, 4, 4, 0)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Padding = New System.Windows.Forms.Padding(4)
        Me.btn_close.Size = New System.Drawing.Size(27, 27)
        Me.btn_close.TabIndex = 321
        Me.btn_close.TabStop = False
        Me.btn_close.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_close.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(6, 403)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(310, 1)
        Me.Panel2.TabIndex = 303
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 459)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(322, 8)
        Me.Panel3.TabIndex = 304
        '
        'lbl_ingrese_usuario
        '
        Me.lbl_ingrese_usuario.AutoSize = True
        Me.lbl_ingrese_usuario.BackColor = System.Drawing.Color.White
        Me.lbl_ingrese_usuario.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ingrese_usuario.ForeColor = System.Drawing.Color.Gray
        Me.lbl_ingrese_usuario.Location = New System.Drawing.Point(76, 224)
        Me.lbl_ingrese_usuario.Name = "lbl_ingrese_usuario"
        Me.lbl_ingrese_usuario.Size = New System.Drawing.Size(146, 19)
        Me.lbl_ingrese_usuario.TabIndex = 312
        Me.lbl_ingrese_usuario.Text = "Ingrese un usuario"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel4.Location = New System.Drawing.Point(71, 248)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(217, 1)
        Me.Panel4.TabIndex = 304
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel5.Location = New System.Drawing.Point(71, 295)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(217, 1)
        Me.Panel5.TabIndex = 305
        '
        'lbl_mac
        '
        Me.lbl_mac.AutoSize = True
        Me.lbl_mac.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_mac.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mac.ForeColor = System.Drawing.Color.Gray
        Me.lbl_mac.Location = New System.Drawing.Point(378, 275)
        Me.lbl_mac.Name = "lbl_mac"
        Me.lbl_mac.Size = New System.Drawing.Size(147, 19)
        Me.lbl_mac.TabIndex = 313
        Me.lbl_mac.Text = "Ingrese una clave"
        '
        'combo_conexion
        '
        Me.combo_conexion.BackColor = System.Drawing.Color.White
        Me.combo_conexion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_conexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.combo_conexion.Font = New System.Drawing.Font("Century Gothic", 11.25!)
        Me.combo_conexion.FormattingEnabled = True
        Me.combo_conexion.Location = New System.Drawing.Point(71, 172)
        Me.combo_conexion.Name = "combo_conexion"
        Me.combo_conexion.Size = New System.Drawing.Size(218, 28)
        Me.combo_conexion.TabIndex = 314
        Me.combo_conexion.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel6.Location = New System.Drawing.Point(71, 199)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(217, 1)
        Me.Panel6.TabIndex = 315
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox5.ErrorImage = Nothing
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(34, 268)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 325
        Me.PictureBox5.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox6.ErrorImage = Nothing
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(34, 220)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 324
        Me.PictureBox6.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox7.ErrorImage = Nothing
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(34, 171)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 323
        Me.PictureBox7.TabStop = False
        '
        'Barra_lateral_izquierda1
        '
        Me.Barra_lateral_izquierda1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Barra_lateral_izquierda1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Barra_lateral_izquierda1.Location = New System.Drawing.Point(0, 37)
        Me.Barra_lateral_izquierda1.Name = "Barra_lateral_izquierda1"
        Me.Barra_lateral_izquierda1.Size = New System.Drawing.Size(1, 422)
        Me.Barra_lateral_izquierda1.TabIndex = 327
        '
        'Barra_lateral_derecha1
        '
        Me.Barra_lateral_derecha1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Barra_lateral_derecha1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Barra_lateral_derecha1.Location = New System.Drawing.Point(321, 37)
        Me.Barra_lateral_derecha1.Name = "Barra_lateral_derecha1"
        Me.Barra_lateral_derecha1.Size = New System.Drawing.Size(1, 422)
        Me.Barra_lateral_derecha1.TabIndex = 328
        '
        'form_Ingreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(322, 467)
        Me.Controls.Add(Me.Barra_lateral_derecha1)
        Me.Controls.Add(Me.Barra_lateral_izquierda1)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.lbl_mac)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.grilla_conexiones)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.titleBar)
        Me.Controls.Add(Me.lbl_equipo)
        Me.Controls.Add(Me.lbl_version)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.lbl_ingrese_usuario)
        Me.Controls.Add(Me.lbl_ingrese_clave)
        Me.Controls.Add(Me.txt_clave)
        Me.Controls.Add(Me.txt_usuario)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.combo_conexion)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox7)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "form_Ingreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INGRESO"
        CType(Me.grilla_conexiones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.titleBar.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents lbl_ingrese_clave As System.Windows.Forms.Label
    Friend WithEvents txt_usuario As System.Windows.Forms.TextBox
    Friend WithEvents txt_clave As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_version As System.Windows.Forms.Label
    Friend WithEvents lbl_equipo As System.Windows.Forms.Label
    Friend WithEvents grilla_conexiones As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Timer_memoria As Timer
    Friend WithEvents titleBar As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lbl_ingrese_usuario As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lbl_mac As Label
    Friend WithEvents combo_conexion As ComboBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents btn_minimize As Button
    Friend WithEvents btn_close As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Barra_lateral_izquierda1 As Barra_lateral_izquierda
    Friend WithEvents Barra_lateral_derecha1 As Barra_lateral_derecha
End Class
