<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_impresion_ticket_estado_de_cuenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_impresion_ticket_estado_de_cuenta))
        Me.lbl_ingrese_clave = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Print_ticket = New System.Drawing.Printing.PrintDocument()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_ingrese_clave
        '
        Me.lbl_ingrese_clave.AutoSize = True
        Me.lbl_ingrese_clave.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_ingrese_clave.Font = New System.Drawing.Font("Century Gothic", 30.0!)
        Me.lbl_ingrese_clave.ForeColor = System.Drawing.Color.Black
        Me.lbl_ingrese_clave.Location = New System.Drawing.Point(67, 36)
        Me.lbl_ingrese_clave.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_ingrese_clave.Name = "lbl_ingrese_clave"
        Me.lbl_ingrese_clave.Size = New System.Drawing.Size(566, 61)
        Me.lbl_ingrese_clave.TabIndex = 2
        Me.lbl_ingrese_clave.Text = "IMPRIMIENDO TICKET..."
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(250, 132)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 200)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 307
        Me.PictureBox1.TabStop = False
        '
        'Print_ticket
        '
        '
        'Form_impresion_ticket_estado_de_cuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 381)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lbl_ingrese_clave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_impresion_ticket_estado_de_cuenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IMPRIMIENDO TICKET"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_ingrese_clave As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Print_ticket As Printing.PrintDocument
End Class
