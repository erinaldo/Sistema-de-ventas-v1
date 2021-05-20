<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Barra_titulo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Barra_titulo))
        Me.lbl_titulo = New System.Windows.Forms.Label()
        Me.btn_minimize = New System.Windows.Forms.Button()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbl_titulo
        '
        Me.lbl_titulo.AutoSize = True
        Me.lbl_titulo.BackColor = System.Drawing.Color.Transparent
        Me.lbl_titulo.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbl_titulo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_titulo.ForeColor = System.Drawing.Color.White
        Me.lbl_titulo.Location = New System.Drawing.Point(2, 2)
        Me.lbl_titulo.Name = "lbl_titulo"
        Me.lbl_titulo.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.lbl_titulo.Size = New System.Drawing.Size(51, 26)
        Me.lbl_titulo.TabIndex = 335
        Me.lbl_titulo.Text = "Titulo"
        Me.lbl_titulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_minimize
        '
        Me.btn_minimize.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.btn_minimize.BackgroundImage = CType(resources.GetObject("btn_minimize.BackgroundImage"), System.Drawing.Image)
        Me.btn_minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_minimize.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_minimize.FlatAppearance.BorderSize = 0
        Me.btn_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_minimize.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_minimize.ForeColor = System.Drawing.Color.White
        Me.btn_minimize.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_minimize.Location = New System.Drawing.Point(636, 2)
        Me.btn_minimize.Margin = New System.Windows.Forms.Padding(4, 4, 4, 0)
        Me.btn_minimize.Name = "btn_minimize"
        Me.btn_minimize.Padding = New System.Windows.Forms.Padding(8)
        Me.btn_minimize.Size = New System.Drawing.Size(31, 31)
        Me.btn_minimize.TabIndex = 334
        Me.btn_minimize.TabStop = False
        Me.btn_minimize.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_minimize.UseVisualStyleBackColor = False
        '
        'btn_close
        '
        Me.btn_close.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.btn_close.BackgroundImage = CType(resources.GetObject("btn_close.BackgroundImage"), System.Drawing.Image)
        Me.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_close.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_close.FlatAppearance.BorderSize = 0
        Me.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_close.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_close.ForeColor = System.Drawing.Color.White
        Me.btn_close.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_close.Location = New System.Drawing.Point(667, 2)
        Me.btn_close.Margin = New System.Windows.Forms.Padding(4, 4, 4, 0)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Padding = New System.Windows.Forms.Padding(4)
        Me.btn_close.Size = New System.Drawing.Size(31, 31)
        Me.btn_close.TabIndex = 333
        Me.btn_close.TabStop = False
        Me.btn_close.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_close.UseVisualStyleBackColor = False
        '
        'Barra_titulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Controls.Add(Me.lbl_titulo)
        Me.Controls.Add(Me.btn_minimize)
        Me.Controls.Add(Me.btn_close)
        Me.Name = "Barra_titulo"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.Size = New System.Drawing.Size(700, 35)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_titulo As Label
    Friend WithEvents btn_minimize As Button
    Friend WithEvents btn_close As Button
End Class
