<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_editar_ofertas_productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_editar_ofertas_productos))
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.grilla_ofertas = New System.Windows.Forms.DataGridView()
        Me.btn_agregar = New System.Windows.Forms.Button()
        Me.btn_quitar = New System.Windows.Forms.Button()
        Me.lbl_codigo = New System.Windows.Forms.Label()
        Me.txt_costo = New System.Windows.Forms.TextBox()
        Me.Combo_proveedor = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_comentario = New System.Windows.Forms.TextBox()
        Me.Combo_tipo_precio = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_porcentaje_desc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_precio = New System.Windows.Forms.TextBox()
        Me.lbl_marca = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_ofertas, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PictureBox_logo.TabIndex = 270
        Me.PictureBox_logo.TabStop = False
        '
        'grilla_ofertas
        '
        Me.grilla_ofertas.AllowUserToAddRows = False
        Me.grilla_ofertas.AllowUserToDeleteRows = False
        Me.grilla_ofertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_ofertas.Location = New System.Drawing.Point(6, 172)
        Me.grilla_ofertas.Name = "grilla_ofertas"
        Me.grilla_ofertas.ReadOnly = True
        Me.grilla_ofertas.Size = New System.Drawing.Size(1006, 226)
        Me.grilla_ofertas.TabIndex = 300
        Me.grilla_ofertas.TabStop = False
        '
        'btn_agregar
        '
        Me.btn_agregar.BackColor = System.Drawing.Color.Transparent
        Me.btn_agregar.Font = New System.Drawing.Font("Century Gothic", 10.5!)
        Me.btn_agregar.ForeColor = System.Drawing.Color.Black
        Me.btn_agregar.Image = CType(resources.GetObject("btn_agregar.Image"), System.Drawing.Image)
        Me.btn_agregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_agregar.Location = New System.Drawing.Point(807, 126)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(100, 40)
        Me.btn_agregar.TabIndex = 6
        Me.btn_agregar.Text = "AGREGAR"
        Me.btn_agregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_agregar.UseVisualStyleBackColor = False
        '
        'btn_quitar
        '
        Me.btn_quitar.BackColor = System.Drawing.Color.Transparent
        Me.btn_quitar.Font = New System.Drawing.Font("Century Gothic", 10.5!)
        Me.btn_quitar.ForeColor = System.Drawing.Color.Black
        Me.btn_quitar.Image = CType(resources.GetObject("btn_quitar.Image"), System.Drawing.Image)
        Me.btn_quitar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_quitar.Location = New System.Drawing.Point(912, 126)
        Me.btn_quitar.Name = "btn_quitar"
        Me.btn_quitar.Size = New System.Drawing.Size(100, 40)
        Me.btn_quitar.TabIndex = 7
        Me.btn_quitar.Text = "QUITAR"
        Me.btn_quitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_quitar.UseVisualStyleBackColor = False
        '
        'lbl_codigo
        '
        Me.lbl_codigo.AutoSize = True
        Me.lbl_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_codigo.Location = New System.Drawing.Point(638, 78)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(58, 16)
        Me.lbl_codigo.TabIndex = 2
        Me.lbl_codigo.Text = "COSTO:"
        '
        'txt_costo
        '
        Me.txt_costo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_costo.Location = New System.Drawing.Point(640, 96)
        Me.txt_costo.MaxLength = 11
        Me.txt_costo.Name = "txt_costo"
        Me.txt_costo.Size = New System.Drawing.Size(120, 24)
        Me.txt_costo.TabIndex = 3
        '
        'Combo_proveedor
        '
        Me.Combo_proveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_proveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_proveedor.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_proveedor.FormattingEnabled = True
        Me.Combo_proveedor.Location = New System.Drawing.Point(6, 96)
        Me.Combo_proveedor.MaxLength = 12
        Me.Combo_proveedor.Name = "Combo_proveedor"
        Me.Combo_proveedor.Size = New System.Drawing.Size(502, 24)
        Me.Combo_proveedor.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "PROVEEDOR:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "COMENTARIO:"
        '
        'txt_comentario
        '
        Me.txt_comentario.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_comentario.Location = New System.Drawing.Point(5, 140)
        Me.txt_comentario.MaxLength = 45
        Me.txt_comentario.Name = "txt_comentario"
        Me.txt_comentario.Size = New System.Drawing.Size(503, 24)
        Me.txt_comentario.TabIndex = 5
        '
        'Combo_tipo_precio
        '
        Me.Combo_tipo_precio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_tipo_precio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_tipo_precio.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_tipo_precio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_tipo_precio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_tipo_precio.FormattingEnabled = True
        Me.Combo_tipo_precio.Items.AddRange(New Object() {"CON IVA", "MAS IVA", "-"})
        Me.Combo_tipo_precio.Location = New System.Drawing.Point(514, 96)
        Me.Combo_tipo_precio.MaxLength = 12
        Me.Combo_tipo_precio.Name = "Combo_tipo_precio"
        Me.Combo_tipo_precio.Size = New System.Drawing.Size(120, 24)
        Me.Combo_tipo_precio.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(511, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 16)
        Me.Label1.TabIndex = 302
        Me.Label1.Text = "TIPO PRECIO:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(764, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 16)
        Me.Label3.TabIndex = 303
        Me.Label3.Text = "% DESC.:"
        '
        'txt_porcentaje_desc
        '
        Me.txt_porcentaje_desc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_porcentaje_desc.Location = New System.Drawing.Point(766, 96)
        Me.txt_porcentaje_desc.MaxLength = 2
        Me.txt_porcentaje_desc.Name = "txt_porcentaje_desc"
        Me.txt_porcentaje_desc.Size = New System.Drawing.Size(120, 24)
        Me.txt_porcentaje_desc.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(890, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 16)
        Me.Label5.TabIndex = 305
        Me.Label5.Text = "PRECIO:"
        '
        'txt_precio
        '
        Me.txt_precio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_precio.Location = New System.Drawing.Point(892, 96)
        Me.txt_precio.MaxLength = 11
        Me.txt_precio.Name = "txt_precio"
        Me.txt_precio.ReadOnly = True
        Me.txt_precio.Size = New System.Drawing.Size(120, 24)
        Me.txt_precio.TabIndex = 306
        Me.txt_precio.TabStop = False
        '
        'lbl_marca
        '
        Me.lbl_marca.AutoSize = True
        Me.lbl_marca.BackColor = System.Drawing.Color.Transparent
        Me.lbl_marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_marca.Location = New System.Drawing.Point(374, 6)
        Me.lbl_marca.Name = "lbl_marca"
        Me.lbl_marca.Size = New System.Drawing.Size(137, 16)
        Me.lbl_marca.TabIndex = 324
        Me.lbl_marca.Text = "MARCA AUTOMOVIL"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(312, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 16)
        Me.Label6.TabIndex = 322
        Me.Label6.Text = "MARCA:"
        '
        'Form_editar_ofertas_productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 404)
        Me.Controls.Add(Me.lbl_marca)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_precio)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_porcentaje_desc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Combo_tipo_precio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_comentario)
        Me.Controls.Add(Me.btn_agregar)
        Me.Controls.Add(Me.lbl_codigo)
        Me.Controls.Add(Me.btn_quitar)
        Me.Controls.Add(Me.Combo_proveedor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_costo)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.grilla_ofertas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_editar_ofertas_productos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OFERTAS DE PRODUCTOS"
        Me.TopMost = True
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_ofertas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox_logo As PictureBox
    Friend WithEvents grilla_ofertas As DataGridView
    Friend WithEvents btn_agregar As Button
    Friend WithEvents btn_quitar As Button
    Friend WithEvents lbl_codigo As Label
    Friend WithEvents txt_costo As TextBox
    Friend WithEvents Combo_proveedor As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_comentario As TextBox
    Friend WithEvents Combo_tipo_precio As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_porcentaje_desc As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_precio As TextBox
    Friend WithEvents lbl_marca As Label
    Friend WithEvents Label6 As Label
End Class
