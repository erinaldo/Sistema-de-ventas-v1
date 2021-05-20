<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_clientes
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UC_clientes))
        Me.GroupBox_producto = New System.Windows.Forms.GroupBox()
        Me.txt_medida = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_aplicacion = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txt_numero_tecnico = New System.Windows.Forms.TextBox()
        Me.txt_codigo = New System.Windows.Forms.TextBox()
        Me.btn_imagen = New System.Windows.Forms.Button()
        Me.btn_buscar_productos = New System.Windows.Forms.Button()
        Me.txt_cantidad = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_nombre_producto = New System.Windows.Forms.TextBox()
        Me.txt_factor = New System.Windows.Forms.TextBox()
        Me.txt_marca = New System.Windows.Forms.TextBox()
        Me.txt_nombre_proveedor = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbl_codigo = New System.Windows.Forms.Label()
        Me.txt_precio = New System.Windows.Forms.TextBox()
        Me.txt_costo = New System.Windows.Forms.TextBox()
        Me.txt_proveedor = New System.Windows.Forms.TextBox()
        Me.GroupBox_producto.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox_producto
        '
        Me.GroupBox_producto.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_producto.Controls.Add(Me.txt_medida)
        Me.GroupBox_producto.Controls.Add(Me.Label12)
        Me.GroupBox_producto.Controls.Add(Me.txt_aplicacion)
        Me.GroupBox_producto.Controls.Add(Me.Label22)
        Me.GroupBox_producto.Controls.Add(Me.txt_numero_tecnico)
        Me.GroupBox_producto.Controls.Add(Me.txt_codigo)
        Me.GroupBox_producto.Controls.Add(Me.btn_imagen)
        Me.GroupBox_producto.Controls.Add(Me.btn_buscar_productos)
        Me.GroupBox_producto.Controls.Add(Me.txt_cantidad)
        Me.GroupBox_producto.Controls.Add(Me.Label5)
        Me.GroupBox_producto.Controls.Add(Me.txt_nombre_producto)
        Me.GroupBox_producto.Controls.Add(Me.txt_factor)
        Me.GroupBox_producto.Controls.Add(Me.txt_marca)
        Me.GroupBox_producto.Controls.Add(Me.txt_nombre_proveedor)
        Me.GroupBox_producto.Controls.Add(Me.Label27)
        Me.GroupBox_producto.Controls.Add(Me.Label6)
        Me.GroupBox_producto.Controls.Add(Me.Label11)
        Me.GroupBox_producto.Controls.Add(Me.Label25)
        Me.GroupBox_producto.Controls.Add(Me.Label7)
        Me.GroupBox_producto.Controls.Add(Me.Label9)
        Me.GroupBox_producto.Controls.Add(Me.lbl_codigo)
        Me.GroupBox_producto.Controls.Add(Me.txt_precio)
        Me.GroupBox_producto.Controls.Add(Me.txt_costo)
        Me.GroupBox_producto.Controls.Add(Me.txt_proveedor)
        Me.GroupBox_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_producto.ForeColor = System.Drawing.Color.Black
        Me.GroupBox_producto.Location = New System.Drawing.Point(8, 73)
        Me.GroupBox_producto.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_producto.Name = "GroupBox_producto"
        Me.GroupBox_producto.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_producto.Size = New System.Drawing.Size(1341, 134)
        Me.GroupBox_producto.TabIndex = 2
        Me.GroupBox_producto.TabStop = False
        Me.GroupBox_producto.Text = "DATOS DEL PRODUCTO ( F1 ):"
        '
        'txt_medida
        '
        Me.txt_medida.BackColor = System.Drawing.SystemColors.Control
        Me.txt_medida.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_medida.ForeColor = System.Drawing.Color.Black
        Me.txt_medida.Location = New System.Drawing.Point(412, 95)
        Me.txt_medida.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_medida.Name = "txt_medida"
        Me.txt_medida.ReadOnly = True
        Me.txt_medida.Size = New System.Drawing.Size(131, 29)
        Me.txt_medida.TabIndex = 26
        Me.txt_medida.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(408, 73)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 20)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "MEDIDA:"
        '
        'txt_aplicacion
        '
        Me.txt_aplicacion.BackColor = System.Drawing.SystemColors.Control
        Me.txt_aplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_aplicacion.ForeColor = System.Drawing.Color.Black
        Me.txt_aplicacion.Location = New System.Drawing.Point(552, 95)
        Me.txt_aplicacion.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_aplicacion.Name = "txt_aplicacion"
        Me.txt_aplicacion.ReadOnly = True
        Me.txt_aplicacion.Size = New System.Drawing.Size(392, 29)
        Me.txt_aplicacion.TabIndex = 23
        Me.txt_aplicacion.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(549, 73)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(114, 20)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "APLICACION:"
        '
        'txt_numero_tecnico
        '
        Me.txt_numero_tecnico.BackColor = System.Drawing.SystemColors.Control
        Me.txt_numero_tecnico.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numero_tecnico.ForeColor = System.Drawing.Color.Black
        Me.txt_numero_tecnico.Location = New System.Drawing.Point(953, 41)
        Me.txt_numero_tecnico.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_numero_tecnico.Name = "txt_numero_tecnico"
        Me.txt_numero_tecnico.ReadOnly = True
        Me.txt_numero_tecnico.Size = New System.Drawing.Size(377, 29)
        Me.txt_numero_tecnico.TabIndex = 0
        Me.txt_numero_tecnico.TabStop = False
        '
        'txt_codigo
        '
        Me.txt_codigo.BackColor = System.Drawing.SystemColors.Window
        Me.txt_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo.ForeColor = System.Drawing.Color.Black
        Me.txt_codigo.Location = New System.Drawing.Point(9, 41)
        Me.txt_codigo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_codigo.MaxLength = 25
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(132, 29)
        Me.txt_codigo.TabIndex = 1
        '
        'btn_imagen
        '
        Me.btn_imagen.BackColor = System.Drawing.Color.Transparent
        Me.btn_imagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imagen.ForeColor = System.Drawing.Color.Black
        Me.btn_imagen.Image = CType(resources.GetObject("btn_imagen.Image"), System.Drawing.Image)
        Me.btn_imagen.Location = New System.Drawing.Point(69, 76)
        Me.btn_imagen.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_imagen.Name = "btn_imagen"
        Me.btn_imagen.Size = New System.Drawing.Size(53, 49)
        Me.btn_imagen.TabIndex = 15
        Me.btn_imagen.TabStop = False
        Me.btn_imagen.UseVisualStyleBackColor = False
        '
        'btn_buscar_productos
        '
        Me.btn_buscar_productos.BackColor = System.Drawing.Color.Transparent
        Me.btn_buscar_productos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar_productos.ForeColor = System.Drawing.Color.Black
        Me.btn_buscar_productos.Image = CType(resources.GetObject("btn_buscar_productos.Image"), System.Drawing.Image)
        Me.btn_buscar_productos.Location = New System.Drawing.Point(9, 76)
        Me.btn_buscar_productos.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_buscar_productos.Name = "btn_buscar_productos"
        Me.btn_buscar_productos.Size = New System.Drawing.Size(53, 49)
        Me.btn_buscar_productos.TabIndex = 14
        Me.btn_buscar_productos.TabStop = False
        Me.btn_buscar_productos.UseVisualStyleBackColor = False
        '
        'txt_cantidad
        '
        Me.txt_cantidad.BackColor = System.Drawing.SystemColors.Control
        Me.txt_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad.ForeColor = System.Drawing.Color.Black
        Me.txt_cantidad.Location = New System.Drawing.Point(271, 95)
        Me.txt_cantidad.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.ReadOnly = True
        Me.txt_cantidad.Size = New System.Drawing.Size(132, 29)
        Me.txt_cantidad.TabIndex = 17
        Me.txt_cantidad.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(8, 18)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 20)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "CODIGO:"
        '
        'txt_nombre_producto
        '
        Me.txt_nombre_producto.BackColor = System.Drawing.SystemColors.Control
        Me.txt_nombre_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_producto.ForeColor = System.Drawing.Color.Black
        Me.txt_nombre_producto.Location = New System.Drawing.Point(151, 41)
        Me.txt_nombre_producto.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_nombre_producto.MaxLength = 45
        Me.txt_nombre_producto.Name = "txt_nombre_producto"
        Me.txt_nombre_producto.ReadOnly = True
        Me.txt_nombre_producto.Size = New System.Drawing.Size(392, 29)
        Me.txt_nombre_producto.TabIndex = 2
        Me.txt_nombre_producto.TabStop = False
        '
        'txt_factor
        '
        Me.txt_factor.BackColor = System.Drawing.SystemColors.Control
        Me.txt_factor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_factor.ForeColor = System.Drawing.Color.Black
        Me.txt_factor.Location = New System.Drawing.Point(129, 95)
        Me.txt_factor.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_factor.Name = "txt_factor"
        Me.txt_factor.ReadOnly = True
        Me.txt_factor.Size = New System.Drawing.Size(132, 29)
        Me.txt_factor.TabIndex = 20
        Me.txt_factor.TabStop = False
        '
        'txt_marca
        '
        Me.txt_marca.BackColor = System.Drawing.SystemColors.Control
        Me.txt_marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_marca.ForeColor = System.Drawing.Color.Black
        Me.txt_marca.Location = New System.Drawing.Point(552, 41)
        Me.txt_marca.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_marca.Name = "txt_marca"
        Me.txt_marca.ReadOnly = True
        Me.txt_marca.Size = New System.Drawing.Size(392, 29)
        Me.txt_marca.TabIndex = 8
        Me.txt_marca.TabStop = False
        '
        'txt_nombre_proveedor
        '
        Me.txt_nombre_proveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txt_nombre_proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_proveedor.ForeColor = System.Drawing.Color.Black
        Me.txt_nombre_proveedor.Location = New System.Drawing.Point(953, 95)
        Me.txt_nombre_proveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_nombre_proveedor.Name = "txt_nombre_proveedor"
        Me.txt_nombre_proveedor.ReadOnly = True
        Me.txt_nombre_proveedor.Size = New System.Drawing.Size(377, 29)
        Me.txt_nombre_proveedor.TabIndex = 5
        Me.txt_nombre_proveedor.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(952, 18)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(111, 20)
        Me.Label27.TabIndex = 12
        Me.Label27.Text = "Nº TECNICO:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(149, 18)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 20)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "NOMBRE:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(267, 73)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 20)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "STOCK:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(952, 73)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(121, 20)
        Me.Label25.TabIndex = 10
        Me.Label25.Text = "PROVEEDOR:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(551, 18)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 20)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "MARCA:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(125, 73)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 20)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "FACTOR:"
        '
        'lbl_codigo
        '
        Me.lbl_codigo.AutoSize = True
        Me.lbl_codigo.ForeColor = System.Drawing.Color.Black
        Me.lbl_codigo.Location = New System.Drawing.Point(40, 48)
        Me.lbl_codigo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(45, 20)
        Me.lbl_codigo.TabIndex = 0
        Me.lbl_codigo.Text = "nada"
        '
        'txt_precio
        '
        Me.txt_precio.BackColor = System.Drawing.SystemColors.Control
        Me.txt_precio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_precio.ForeColor = System.Drawing.Color.Black
        Me.txt_precio.Location = New System.Drawing.Point(740, 44)
        Me.txt_precio.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_precio.MaxLength = 8
        Me.txt_precio.Name = "txt_precio"
        Me.txt_precio.Size = New System.Drawing.Size(27, 23)
        Me.txt_precio.TabIndex = 24
        Me.txt_precio.TabStop = False
        '
        'txt_costo
        '
        Me.txt_costo.ForeColor = System.Drawing.Color.Black
        Me.txt_costo.Location = New System.Drawing.Point(352, 41)
        Me.txt_costo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_costo.Name = "txt_costo"
        Me.txt_costo.ReadOnly = True
        Me.txt_costo.Size = New System.Drawing.Size(31, 26)
        Me.txt_costo.TabIndex = 0
        Me.txt_costo.TabStop = False
        Me.txt_costo.Visible = False
        '
        'txt_proveedor
        '
        Me.txt_proveedor.ForeColor = System.Drawing.Color.Black
        Me.txt_proveedor.Location = New System.Drawing.Point(316, 41)
        Me.txt_proveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_proveedor.Name = "txt_proveedor"
        Me.txt_proveedor.ReadOnly = True
        Me.txt_proveedor.Size = New System.Drawing.Size(31, 26)
        Me.txt_proveedor.TabIndex = 0
        Me.txt_proveedor.TabStop = False
        Me.txt_proveedor.Visible = False
        '
        'UC_clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox_producto)
        Me.Name = "UC_clientes"
        Me.Size = New System.Drawing.Size(1024, 280)
        Me.GroupBox_producto.ResumeLayout(False)
        Me.GroupBox_producto.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox_producto As GroupBox
    Friend WithEvents txt_medida As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txt_aplicacion As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txt_numero_tecnico As TextBox
    Friend WithEvents txt_codigo As TextBox
    Friend WithEvents btn_imagen As Button
    Friend WithEvents btn_buscar_productos As Button
    Friend WithEvents txt_cantidad As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_nombre_producto As TextBox
    Friend WithEvents txt_factor As TextBox
    Friend WithEvents txt_marca As TextBox
    Friend WithEvents txt_nombre_proveedor As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lbl_codigo As Label
    Friend WithEvents txt_precio As TextBox
    Friend WithEvents txt_costo As TextBox
    Friend WithEvents txt_proveedor As TextBox
End Class
