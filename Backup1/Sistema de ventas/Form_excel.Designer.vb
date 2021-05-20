<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_excel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_excel))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.combo_tipo = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.txt_item = New System.Windows.Forms.TextBox
        Me.txtFic = New System.Windows.Forms.TextBox
        Me.txtSelect = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_exportar_excel = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btnAbrir = New System.Windows.Forms.Button
        Me.grilla_excel = New System.Windows.Forms.DataGridView
        Me.lbl_mensaje = New System.Windows.Forms.Label
        Me.grilla_ejemplo = New System.Windows.Forms.DataGridView
        Me.txt_nro_ajuste = New System.Windows.Forms.TextBox
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.txt_codigo_cliente = New System.Windows.Forms.TextBox
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grilla_excel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_ejemplo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.combo_tipo)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.txt_item)
        Me.GroupBox3.Controls.Add(Me.txtFic)
        Me.GroupBox3.Controls.Add(Me.txtSelect)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(754, 142)
        Me.GroupBox3.TabIndex = 297
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "INFORMACION DEL ARCHIVO"
        '
        'combo_tipo
        '
        Me.combo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_tipo.FormattingEnabled = True
        Me.combo_tipo.Items.AddRange(New Object() {"-", "ACTUALIZAR CUPO", "INGRESAR MEDIDAS SUBFAMILIAS 2", "INGRESAR CLIENTES COPEUCH", "AGREGAR TIPO EMISION A COMPRAS", "CAMBIAR ESTADO DE GUIAS", "ACTUALIZAR NOMBRE", "ACTUALIZAR NUMERO TECNICO", "ACTUALIZAR APLICACION", "ACTUALIZAR STOCK", "ACTUALIZAR STOCK MINIMO", "ACTUALIZAR ESTADO DEL PRODUCTO", "ACTUALIZAR DATOS DEL PRODUCTO", "ACTUALIZAR APLICACION", "ACTUALIZAR COSTOS", "ACTUALIZAR ULTIMA COMPRA", "ACTUALIZAR MARCA", "ACTUALIZAR FAMILIA", "ACTUALIZAR SUBFAMILIA", "ACTUALIZAR SUBFAMILIA 2", "INGRESAR CODIGOS DE BARRA", "ANULAR CREDITOS", "PERMISOS DE USUARIOS", "ASOCIAR CLIENTES A EMPRESAS", "ACTUALIZAR ULTIMA COMPRA", "CREAR FAMILIA", "CREAR SUBFAMILIA", "CREAR SUBFAMILIA 2", "ACTUALIZAR SUBFAMILIA M", "ACTUALIZAR SUBFAMILIA O", "ACTUALIZAR CENTRAL DE COSTOS", "INGRESAR PEDIDO", "ACTUALIZAR LETRA"})
        Me.combo_tipo.Location = New System.Drawing.Point(166, 31)
        Me.combo_tipo.Name = "combo_tipo"
        Me.combo_tipo.Size = New System.Drawing.Size(269, 24)
        Me.combo_tipo.TabIndex = 300
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(437, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(184, 16)
        Me.Label2.TabIndex = 299
        Me.Label2.Text = "CANTIDAD DE REGISTROS:"
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
        'txt_item
        '
        Me.txt_item.BackColor = System.Drawing.SystemColors.Control
        Me.txt_item.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_item.ForeColor = System.Drawing.Color.Black
        Me.txt_item.Location = New System.Drawing.Point(623, 31)
        Me.txt_item.Name = "txt_item"
        Me.txt_item.ReadOnly = True
        Me.txt_item.Size = New System.Drawing.Size(100, 24)
        Me.txt_item.TabIndex = 296
        Me.txt_item.TabStop = False
        Me.txt_item.Text = "0"
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
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btn_exportar_excel)
        Me.GroupBox1.Controls.Add(Me.btn_guardar)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.btnAbrir)
        Me.GroupBox1.Location = New System.Drawing.Point(766, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(246, 140)
        Me.GroupBox1.TabIndex = 296
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
        Me.btn_exportar_excel.Text = "EJEMPLO"
        Me.btn_exportar_excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exportar_excel.UseVisualStyleBackColor = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.Transparent
        Me.btn_guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.Location = New System.Drawing.Point(26, 76)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(95, 40)
        Me.btn_guardar.TabIndex = 3
        Me.btn_guardar.Text = "GUARDAR"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
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
        'grilla_excel
        '
        Me.grilla_excel.AllowUserToAddRows = False
        Me.grilla_excel.AllowUserToDeleteRows = False
        Me.grilla_excel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grilla_excel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_excel.Location = New System.Drawing.Point(6, 224)
        Me.grilla_excel.Name = "grilla_excel"
        Me.grilla_excel.ReadOnly = True
        Me.grilla_excel.Size = New System.Drawing.Size(1006, 470)
        Me.grilla_excel.TabIndex = 298
        Me.grilla_excel.TabStop = False
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(307, 0)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(711, 81)
        Me.lbl_mensaje.TabIndex = 299
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_mensaje.Visible = False
        '
        'grilla_ejemplo
        '
        Me.grilla_ejemplo.AllowUserToAddRows = False
        Me.grilla_ejemplo.AllowUserToDeleteRows = False
        Me.grilla_ejemplo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grilla_ejemplo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_ejemplo.Location = New System.Drawing.Point(193, 250)
        Me.grilla_ejemplo.Name = "grilla_ejemplo"
        Me.grilla_ejemplo.ReadOnly = True
        Me.grilla_ejemplo.Size = New System.Drawing.Size(600, 300)
        Me.grilla_ejemplo.TabIndex = 301
        Me.grilla_ejemplo.TabStop = False
        '
        'txt_nro_ajuste
        '
        Me.txt_nro_ajuste.Enabled = False
        Me.txt_nro_ajuste.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_ajuste.Location = New System.Drawing.Point(698, 320)
        Me.txt_nro_ajuste.MaxLength = 6
        Me.txt_nro_ajuste.Name = "txt_nro_ajuste"
        Me.txt_nro_ajuste.Size = New System.Drawing.Size(120, 24)
        Me.txt_nro_ajuste.TabIndex = 16
        Me.txt_nro_ajuste.Visible = False
        '
        'grilla
        '
        Me.grilla.AllowUserToAddRows = False
        Me.grilla.AllowUserToDeleteRows = False
        Me.grilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Location = New System.Drawing.Point(462, 316)
        Me.grilla.Name = "grilla"
        Me.grilla.ReadOnly = True
        Me.grilla.Size = New System.Drawing.Size(95, 68)
        Me.grilla.TabIndex = 302
        Me.grilla.TabStop = False
        '
        'txt_codigo_cliente
        '
        Me.txt_codigo_cliente.Enabled = False
        Me.txt_codigo_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo_cliente.Location = New System.Drawing.Point(449, 338)
        Me.txt_codigo_cliente.MaxLength = 11
        Me.txt_codigo_cliente.Name = "txt_codigo_cliente"
        Me.txt_codigo_cliente.Size = New System.Drawing.Size(120, 24)
        Me.txt_codigo_cliente.TabIndex = 303
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 300
        Me.PictureBox_logo.TabStop = False
        '
        'Form_excel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 700)
        Me.Controls.Add(Me.grilla_excel)
        Me.Controls.Add(Me.txt_nro_ajuste)
        Me.Controls.Add(Me.grilla_ejemplo)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grilla)
        Me.Controls.Add(Me.txt_codigo_cliente)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_excel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CARGAR DATOS DESDE ARCHIVO EXCEL"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grilla_excel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_ejemplo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txt_item As System.Windows.Forms.TextBox
    Friend WithEvents txtFic As System.Windows.Forms.TextBox
    Friend WithEvents txtSelect As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btnAbrir As System.Windows.Forms.Button
    Friend WithEvents grilla_excel As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents combo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grilla_ejemplo As System.Windows.Forms.DataGridView
    Friend WithEvents btn_exportar_excel As System.Windows.Forms.Button
    Friend WithEvents txt_nro_ajuste As System.Windows.Forms.TextBox
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents txt_codigo_cliente As System.Windows.Forms.TextBox
End Class
