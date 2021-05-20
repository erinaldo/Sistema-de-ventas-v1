<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_despacho_web
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_despacho_web))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_nro_pedido = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Combo_transporte = New System.Windows.Forms.ComboBox()
        Me.txt_nro_ot = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.combo_tipo = New System.Windows.Forms.ComboBox()
        Me.txt_nota = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_correo_copia = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_nro_doc = New System.Windows.Forms.TextBox()
        Me.txt_nombre_cliente = New System.Windows.Forms.TextBox()
        Me.txt_correo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn_arroba = New System.Windows.Forms.Button()
        Me.btn_limpiar = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_enviar = New System.Windows.Forms.Button()
        Me.lbl_correo = New System.Windows.Forms.Label()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txt_nro_pedido)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Combo_transporte)
        Me.GroupBox1.Controls.Add(Me.txt_nro_ot)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.combo_tipo)
        Me.GroupBox1.Controls.Add(Me.txt_nota)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_correo_copia)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_nro_doc)
        Me.GroupBox1.Controls.Add(Me.txt_nombre_cliente)
        Me.GroupBox1.Controls.Add(Me.txt_correo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 76)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(541, 342)
        Me.GroupBox1.TabIndex = 294
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DATOS DEL CLIENTE"
        '
        'txt_nro_pedido
        '
        Me.txt_nro_pedido.BackColor = System.Drawing.SystemColors.Window
        Me.txt_nro_pedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_pedido.ForeColor = System.Drawing.Color.Black
        Me.txt_nro_pedido.Location = New System.Drawing.Point(135, 80)
        Me.txt_nro_pedido.MaxLength = 11
        Me.txt_nro_pedido.Name = "txt_nro_pedido"
        Me.txt_nro_pedido.Size = New System.Drawing.Size(400, 24)
        Me.txt_nro_pedido.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(35, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 16)
        Me.Label9.TabIndex = 302
        Me.Label9.Text = "NRO. PEDIDO:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(27, 207)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 16)
        Me.Label7.TabIndex = 300
        Me.Label7.Text = "TRANSPORTE:"
        '
        'Combo_transporte
        '
        Me.Combo_transporte.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_transporte.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_transporte.BackColor = System.Drawing.SystemColors.Window
        Me.Combo_transporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_transporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_transporte.ForeColor = System.Drawing.Color.Black
        Me.Combo_transporte.FormattingEnabled = True
        Me.Combo_transporte.Items.AddRange(New Object() {"CHILEXPRESS", "CORREOS", "STARKEN", "FEDEX/TNT", "RETIRO EN TIENDA", "TRANSPORTE PROPIO", "PULLMAN"})
        Me.Combo_transporte.Location = New System.Drawing.Point(134, 204)
        Me.Combo_transporte.Name = "Combo_transporte"
        Me.Combo_transporte.Size = New System.Drawing.Size(400, 24)
        Me.Combo_transporte.TabIndex = 7
        '
        'txt_nro_ot
        '
        Me.txt_nro_ot.BackColor = System.Drawing.SystemColors.Window
        Me.txt_nro_ot.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_ot.ForeColor = System.Drawing.Color.Black
        Me.txt_nro_ot.Location = New System.Drawing.Point(134, 235)
        Me.txt_nro_ot.MaxLength = 11
        Me.txt_nro_ot.Name = "txt_nro_ot"
        Me.txt_nro_ot.Size = New System.Drawing.Size(400, 24)
        Me.txt_nro_ot.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(53, 238)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 16)
        Me.Label8.TabIndex = 298
        Me.Label8.Text = "NRO. OT:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(55, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 296
        Me.Label3.Text = "TIPO DOC.:"
        '
        'combo_tipo
        '
        Me.combo_tipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_tipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_tipo.BackColor = System.Drawing.SystemColors.Window
        Me.combo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_tipo.ForeColor = System.Drawing.Color.Black
        Me.combo_tipo.FormattingEnabled = True
        Me.combo_tipo.Items.AddRange(New Object() {"BOLETA", "FACTURA"})
        Me.combo_tipo.Location = New System.Drawing.Point(134, 18)
        Me.combo_tipo.Name = "combo_tipo"
        Me.combo_tipo.Size = New System.Drawing.Size(400, 24)
        Me.combo_tipo.TabIndex = 1
        '
        'txt_nota
        '
        Me.txt_nota.BackColor = System.Drawing.SystemColors.Window
        Me.txt_nota.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nota.ForeColor = System.Drawing.Color.Black
        Me.txt_nota.Location = New System.Drawing.Point(134, 266)
        Me.txt_nota.MaxLength = 45
        Me.txt_nota.Multiline = True
        Me.txt_nota.Name = "txt_nota"
        Me.txt_nota.Size = New System.Drawing.Size(400, 68)
        Me.txt_nota.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(83, 269)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 16)
        Me.Label6.TabIndex = 294
        Me.Label6.Text = "NOTA:"
        '
        'txt_correo_copia
        '
        Me.txt_correo_copia.BackColor = System.Drawing.SystemColors.Window
        Me.txt_correo_copia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_correo_copia.ForeColor = System.Drawing.Color.Black
        Me.txt_correo_copia.Location = New System.Drawing.Point(134, 173)
        Me.txt_correo_copia.MaxLength = 45
        Me.txt_correo_copia.Name = "txt_correo_copia"
        Me.txt_correo_copia.Size = New System.Drawing.Size(400, 24)
        Me.txt_correo_copia.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(37, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 16)
        Me.Label4.TabIndex = 293
        Me.Label4.Text = "CON COPIA A:"
        '
        'txt_nro_doc
        '
        Me.txt_nro_doc.BackColor = System.Drawing.SystemColors.Window
        Me.txt_nro_doc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_doc.ForeColor = System.Drawing.Color.Black
        Me.txt_nro_doc.Location = New System.Drawing.Point(134, 49)
        Me.txt_nro_doc.MaxLength = 11
        Me.txt_nro_doc.Name = "txt_nro_doc"
        Me.txt_nro_doc.Size = New System.Drawing.Size(400, 24)
        Me.txt_nro_doc.TabIndex = 2
        '
        'txt_nombre_cliente
        '
        Me.txt_nombre_cliente.BackColor = System.Drawing.SystemColors.Window
        Me.txt_nombre_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_cliente.ForeColor = System.Drawing.Color.Black
        Me.txt_nombre_cliente.Location = New System.Drawing.Point(134, 111)
        Me.txt_nombre_cliente.MaxLength = 45
        Me.txt_nombre_cliente.Name = "txt_nombre_cliente"
        Me.txt_nombre_cliente.Size = New System.Drawing.Size(400, 24)
        Me.txt_nombre_cliente.TabIndex = 4
        '
        'txt_correo
        '
        Me.txt_correo.BackColor = System.Drawing.SystemColors.Window
        Me.txt_correo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_correo.ForeColor = System.Drawing.Color.Black
        Me.txt_correo.Location = New System.Drawing.Point(134, 142)
        Me.txt_correo.MaxLength = 45
        Me.txt_correo.Name = "txt_correo"
        Me.txt_correo.Size = New System.Drawing.Size(400, 24)
        Me.txt_correo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(63, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 290
        Me.Label2.Text = "CORREO:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(53, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "NRO. DOC.:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 16)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "NOMBRE CLIENTE:"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btn_arroba)
        Me.GroupBox4.Controls.Add(Me.btn_limpiar)
        Me.GroupBox4.Controls.Add(Me.btn_salir)
        Me.GroupBox4.Controls.Add(Me.btn_enviar)
        Me.GroupBox4.Location = New System.Drawing.Point(552, 77)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(109, 341)
        Me.GroupBox4.TabIndex = 295
        Me.GroupBox4.TabStop = False
        '
        'btn_arroba
        '
        Me.btn_arroba.BackColor = System.Drawing.Color.Transparent
        Me.btn_arroba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_arroba.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_arroba.Image = CType(resources.GetObject("btn_arroba.Image"), System.Drawing.Image)
        Me.btn_arroba.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_arroba.Location = New System.Drawing.Point(7, 106)
        Me.btn_arroba.Name = "btn_arroba"
        Me.btn_arroba.Size = New System.Drawing.Size(95, 40)
        Me.btn_arroba.TabIndex = 2
        Me.btn_arroba.Text = "ARROBA"
        Me.btn_arroba.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_arroba.UseVisualStyleBackColor = False
        '
        'btn_limpiar
        '
        Me.btn_limpiar.BackColor = System.Drawing.Color.Transparent
        Me.btn_limpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_limpiar.ForeColor = System.Drawing.Color.Black
        Me.btn_limpiar.Image = CType(resources.GetObject("btn_limpiar.Image"), System.Drawing.Image)
        Me.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_limpiar.Location = New System.Drawing.Point(7, 199)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(95, 40)
        Me.btn_limpiar.TabIndex = 3
        Me.btn_limpiar.Text = "LIMPIAR"
        Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_limpiar.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(7, 293)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
        Me.btn_salir.TabIndex = 4
        Me.btn_salir.Text = "SALIR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_enviar
        '
        Me.btn_enviar.BackColor = System.Drawing.Color.Transparent
        Me.btn_enviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_enviar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_enviar.Image = CType(resources.GetObject("btn_enviar.Image"), System.Drawing.Image)
        Me.btn_enviar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_enviar.Location = New System.Drawing.Point(7, 13)
        Me.btn_enviar.Name = "btn_enviar"
        Me.btn_enviar.Size = New System.Drawing.Size(95, 40)
        Me.btn_enviar.TabIndex = 1
        Me.btn_enviar.Text = "ENVIAR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_enviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_enviar.UseVisualStyleBackColor = False
        '
        'lbl_correo
        '
        Me.lbl_correo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_correo.BackColor = System.Drawing.Color.Transparent
        Me.lbl_correo.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_correo.Location = New System.Drawing.Point(1, 1)
        Me.lbl_correo.Name = "lbl_correo"
        Me.lbl_correo.Size = New System.Drawing.Size(665, 81)
        Me.lbl_correo.TabIndex = 297
        Me.lbl_correo.Text = "ENVIANDO CORREO..."
        Me.lbl_correo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_correo.Visible = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(5, 5)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 296
        Me.PictureBox_logo.TabStop = False
        '
        'Form_despacho_web
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 424)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.lbl_correo)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_despacho_web"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DESPACHO WEB"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txt_nota As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_nro_doc As TextBox
    Friend WithEvents txt_nombre_cliente As TextBox
    Friend WithEvents txt_correo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btn_arroba As Button
    Friend WithEvents btn_limpiar As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents btn_enviar As Button
    Friend WithEvents lbl_correo As Label
    Friend WithEvents PictureBox_logo As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents combo_tipo As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Combo_transporte As ComboBox
    Friend WithEvents txt_nro_ot As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_nro_pedido As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txt_correo_copia As TextBox
    Friend WithEvents Label4 As Label
End Class
