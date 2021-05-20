<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_registro_ruta_imagenes_sistema
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_registro_ruta_imagenes_sistema))
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.btn_ruta_menu = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_ruta_ticket = New System.Windows.Forms.Button
        Me.txt_ruta_imagen_ticket = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btn_ruta_reporte = New System.Windows.Forms.Button
        Me.txt_ruta_imagen_reportes = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btn_ruta_ventana = New System.Windows.Forms.Button
        Me.txt_ruta_imagen_ventana = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_ruta_imagen_menu = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog
        Me.OpenFileDialog3 = New System.Windows.Forms.OpenFileDialog
        Me.OpenFileDialog4 = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btn_ruta_carpeta_fotografias = New System.Windows.Forms.Button
        Me.txt_ruta_carpeta_fotografias = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btn_ruta_carpeta_productos = New System.Windows.Forms.Button
        Me.txt_ruta_carpeta_productos = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.OpenFileDialog5 = New System.Windows.Forms.OpenFileDialog
        Me.OpenFileDialog6 = New System.Windows.Forms.OpenFileDialog
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.PictureBox_logo.TabIndex = 250
        Me.PictureBox_logo.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btn_salir)
        Me.GroupBox2.Controls.Add(Me.btn_nuevo)
        Me.GroupBox2.Controls.Add(Me.btn_cancelar)
        Me.GroupBox2.Controls.Add(Me.btn_guardar)
        Me.GroupBox2.Location = New System.Drawing.Point(501, 58)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(109, 309)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(7, 261)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
        Me.btn_salir.TabIndex = 14
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
        Me.btn_nuevo.TabIndex = 9
        Me.btn_nuevo.Text = "MODIFICAR"
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
        Me.btn_cancelar.Location = New System.Drawing.Point(7, 216)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(95, 40)
        Me.btn_cancelar.TabIndex = 13
        Me.btn_cancelar.Text = "CANCELAR"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.Transparent
        Me.btn_guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.Location = New System.Drawing.Point(7, 58)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(95, 40)
        Me.btn_guardar.TabIndex = 12
        Me.btn_guardar.Text = "GUARDAR"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'btn_ruta_menu
        '
        Me.btn_ruta_menu.BackColor = System.Drawing.Color.Transparent
        Me.btn_ruta_menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_ruta_menu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ruta_menu.Image = CType(resources.GetObject("btn_ruta_menu.Image"), System.Drawing.Image)
        Me.btn_ruta_menu.Location = New System.Drawing.Point(452, 30)
        Me.btn_ruta_menu.Name = "btn_ruta_menu"
        Me.btn_ruta_menu.Size = New System.Drawing.Size(30, 30)
        Me.btn_ruta_menu.TabIndex = 248
        Me.btn_ruta_menu.TabStop = False
        Me.btn_ruta_menu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ruta_menu.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btn_ruta_ticket)
        Me.GroupBox1.Controls.Add(Me.txt_ruta_imagen_ticket)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btn_ruta_reporte)
        Me.GroupBox1.Controls.Add(Me.txt_ruta_imagen_reportes)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btn_ruta_ventana)
        Me.GroupBox1.Controls.Add(Me.txt_ruta_imagen_ventana)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btn_ruta_menu)
        Me.GroupBox1.Controls.Add(Me.txt_ruta_imagen_menu)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(489, 199)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "RUTAS DE IMAGENES"
        '
        'btn_ruta_ticket
        '
        Me.btn_ruta_ticket.BackColor = System.Drawing.Color.Transparent
        Me.btn_ruta_ticket.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_ruta_ticket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ruta_ticket.Image = CType(resources.GetObject("btn_ruta_ticket.Image"), System.Drawing.Image)
        Me.btn_ruta_ticket.Location = New System.Drawing.Point(452, 161)
        Me.btn_ruta_ticket.Name = "btn_ruta_ticket"
        Me.btn_ruta_ticket.Size = New System.Drawing.Size(30, 30)
        Me.btn_ruta_ticket.TabIndex = 257
        Me.btn_ruta_ticket.TabStop = False
        Me.btn_ruta_ticket.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ruta_ticket.UseVisualStyleBackColor = False
        '
        'txt_ruta_imagen_ticket
        '
        Me.txt_ruta_imagen_ticket.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ruta_imagen_ticket.Location = New System.Drawing.Point(7, 167)
        Me.txt_ruta_imagen_ticket.MaxLength = 200
        Me.txt_ruta_imagen_ticket.Name = "txt_ruta_imagen_ticket"
        Me.txt_ruta_imagen_ticket.Size = New System.Drawing.Size(440, 24)
        Me.txt_ruta_imagen_ticket.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(7, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(216, 16)
        Me.Label3.TabIndex = 255
        Me.Label3.Text = "RUTA DE IMAGEN PARA TICKET:"
        '
        'btn_ruta_reporte
        '
        Me.btn_ruta_reporte.BackColor = System.Drawing.Color.Transparent
        Me.btn_ruta_reporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_ruta_reporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ruta_reporte.Image = CType(resources.GetObject("btn_ruta_reporte.Image"), System.Drawing.Image)
        Me.btn_ruta_reporte.Location = New System.Drawing.Point(452, 118)
        Me.btn_ruta_reporte.Name = "btn_ruta_reporte"
        Me.btn_ruta_reporte.Size = New System.Drawing.Size(30, 30)
        Me.btn_ruta_reporte.TabIndex = 254
        Me.btn_ruta_reporte.TabStop = False
        Me.btn_ruta_reporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ruta_reporte.UseVisualStyleBackColor = False
        '
        'txt_ruta_imagen_reportes
        '
        Me.txt_ruta_imagen_reportes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ruta_imagen_reportes.Location = New System.Drawing.Point(7, 123)
        Me.txt_ruta_imagen_reportes.MaxLength = 200
        Me.txt_ruta_imagen_reportes.Name = "txt_ruta_imagen_reportes"
        Me.txt_ruta_imagen_reportes.Size = New System.Drawing.Size(440, 24)
        Me.txt_ruta_imagen_reportes.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(7, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(244, 16)
        Me.Label4.TabIndex = 252
        Me.Label4.Text = "RUTA DE IMAGEN PARA REPORTES:"
        '
        'btn_ruta_ventana
        '
        Me.btn_ruta_ventana.BackColor = System.Drawing.Color.Transparent
        Me.btn_ruta_ventana.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_ruta_ventana.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ruta_ventana.Image = CType(resources.GetObject("btn_ruta_ventana.Image"), System.Drawing.Image)
        Me.btn_ruta_ventana.Location = New System.Drawing.Point(452, 74)
        Me.btn_ruta_ventana.Name = "btn_ruta_ventana"
        Me.btn_ruta_ventana.Size = New System.Drawing.Size(30, 30)
        Me.btn_ruta_ventana.TabIndex = 251
        Me.btn_ruta_ventana.TabStop = False
        Me.btn_ruta_ventana.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ruta_ventana.UseVisualStyleBackColor = False
        '
        'txt_ruta_imagen_ventana
        '
        Me.txt_ruta_imagen_ventana.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ruta_imagen_ventana.Location = New System.Drawing.Point(7, 79)
        Me.txt_ruta_imagen_ventana.MaxLength = 200
        Me.txt_ruta_imagen_ventana.Name = "txt_ruta_imagen_ventana"
        Me.txt_ruta_imagen_ventana.Size = New System.Drawing.Size(440, 24)
        Me.txt_ruta_imagen_ventana.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(7, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(317, 16)
        Me.Label1.TabIndex = 249
        Me.Label1.Text = "RUTA DE IMAGEN FORMULARIOS DEL SISTEMA:"
        '
        'txt_ruta_imagen_menu
        '
        Me.txt_ruta_imagen_menu.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ruta_imagen_menu.Location = New System.Drawing.Point(7, 35)
        Me.txt_ruta_imagen_menu.MaxLength = 200
        Me.txt_ruta_imagen_menu.Name = "txt_ruta_imagen_menu"
        Me.txt_ruta_imagen_menu.Size = New System.Drawing.Size(440, 24)
        Me.txt_ruta_imagen_menu.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(7, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(373, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "RUTA DE IMAGEN DE FONDO PARA MENU DEL SISTEMA:"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "true"
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.DefaultExt = "true"
        Me.OpenFileDialog2.FileName = "OpenFileDialog1"
        '
        'OpenFileDialog3
        '
        Me.OpenFileDialog3.DefaultExt = "true"
        Me.OpenFileDialog3.FileName = "OpenFileDialog1"
        '
        'OpenFileDialog4
        '
        Me.OpenFileDialog4.DefaultExt = "true"
        Me.OpenFileDialog4.FileName = "OpenFileDialog1"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.btn_ruta_carpeta_fotografias)
        Me.GroupBox3.Controls.Add(Me.txt_ruta_carpeta_fotografias)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.btn_ruta_carpeta_productos)
        Me.GroupBox3.Controls.Add(Me.txt_ruta_carpeta_productos)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 256)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(489, 111)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "RUTAS DE CARPETAS PARA IMAGENES"
        '
        'btn_ruta_carpeta_fotografias
        '
        Me.btn_ruta_carpeta_fotografias.BackColor = System.Drawing.Color.Transparent
        Me.btn_ruta_carpeta_fotografias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_ruta_carpeta_fotografias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ruta_carpeta_fotografias.Image = CType(resources.GetObject("btn_ruta_carpeta_fotografias.Image"), System.Drawing.Image)
        Me.btn_ruta_carpeta_fotografias.Location = New System.Drawing.Point(452, 73)
        Me.btn_ruta_carpeta_fotografias.Name = "btn_ruta_carpeta_fotografias"
        Me.btn_ruta_carpeta_fotografias.Size = New System.Drawing.Size(30, 30)
        Me.btn_ruta_carpeta_fotografias.TabIndex = 251
        Me.btn_ruta_carpeta_fotografias.TabStop = False
        Me.btn_ruta_carpeta_fotografias.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ruta_carpeta_fotografias.UseVisualStyleBackColor = False
        '
        'txt_ruta_carpeta_fotografias
        '
        Me.txt_ruta_carpeta_fotografias.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ruta_carpeta_fotografias.Location = New System.Drawing.Point(7, 79)
        Me.txt_ruta_carpeta_fotografias.MaxLength = 200
        Me.txt_ruta_carpeta_fotografias.Name = "txt_ruta_carpeta_fotografias"
        Me.txt_ruta_carpeta_fotografias.Size = New System.Drawing.Size(440, 24)
        Me.txt_ruta_carpeta_fotografias.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(7, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(179, 16)
        Me.Label7.TabIndex = 249
        Me.Label7.Text = "FOTOGRAFIAS USUARIOS:"
        '
        'btn_ruta_carpeta_productos
        '
        Me.btn_ruta_carpeta_productos.BackColor = System.Drawing.Color.Transparent
        Me.btn_ruta_carpeta_productos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_ruta_carpeta_productos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ruta_carpeta_productos.Image = CType(resources.GetObject("btn_ruta_carpeta_productos.Image"), System.Drawing.Image)
        Me.btn_ruta_carpeta_productos.Location = New System.Drawing.Point(452, 30)
        Me.btn_ruta_carpeta_productos.Name = "btn_ruta_carpeta_productos"
        Me.btn_ruta_carpeta_productos.Size = New System.Drawing.Size(30, 30)
        Me.btn_ruta_carpeta_productos.TabIndex = 248
        Me.btn_ruta_carpeta_productos.TabStop = False
        Me.btn_ruta_carpeta_productos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ruta_carpeta_productos.UseVisualStyleBackColor = False
        '
        'txt_ruta_carpeta_productos
        '
        Me.txt_ruta_carpeta_productos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ruta_carpeta_productos.Location = New System.Drawing.Point(7, 35)
        Me.txt_ruta_carpeta_productos.MaxLength = 200
        Me.txt_ruta_carpeta_productos.Name = "txt_ruta_carpeta_productos"
        Me.txt_ruta_carpeta_productos.Size = New System.Drawing.Size(440, 24)
        Me.txt_ruta_carpeta_productos.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(7, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "PRODUCTOS:"
        '
        'OpenFileDialog5
        '
        Me.OpenFileDialog5.DefaultExt = "true"
        Me.OpenFileDialog5.FileName = "OpenFileDialog1"
        '
        'OpenFileDialog6
        '
        Me.OpenFileDialog6.DefaultExt = "true"
        Me.OpenFileDialog6.FileName = "OpenFileDialog1"
        '
        'Form_registro_ruta_imagenes_sistema
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 373)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_registro_ruta_imagenes_sistema"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RUTA DE IMAGENES"
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_ruta_menu As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_ruta_ticket As System.Windows.Forms.Button
    Friend WithEvents txt_ruta_imagen_ticket As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_ruta_reporte As System.Windows.Forms.Button
    Friend WithEvents txt_ruta_imagen_reportes As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_ruta_ventana As System.Windows.Forms.Button
    Friend WithEvents txt_ruta_imagen_ventana As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_ruta_imagen_menu As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OpenFileDialog3 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OpenFileDialog4 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_ruta_carpeta_fotografias As System.Windows.Forms.Button
    Friend WithEvents txt_ruta_carpeta_fotografias As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btn_ruta_carpeta_productos As System.Windows.Forms.Button
    Friend WithEvents txt_ruta_carpeta_productos As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog5 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OpenFileDialog6 As System.Windows.Forms.OpenFileDialog
End Class
