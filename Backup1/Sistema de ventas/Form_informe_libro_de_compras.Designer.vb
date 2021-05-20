<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_informe_libro_de_compras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_informe_libro_de_compras))
        Me.rpt_libro_de_compras = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'rpt_libro_de_compras
        '
        Me.rpt_libro_de_compras.ActiveViewIndex = -1
        Me.rpt_libro_de_compras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rpt_libro_de_compras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpt_libro_de_compras.Location = New System.Drawing.Point(0, 0)
        Me.rpt_libro_de_compras.Name = "rpt_libro_de_compras"
        Me.rpt_libro_de_compras.SelectionFormula = ""
        Me.rpt_libro_de_compras.Size = New System.Drawing.Size(284, 262)
        Me.rpt_libro_de_compras.TabIndex = 1
        Me.rpt_libro_de_compras.ViewTimeSelectionFormula = ""
        '
        'Form_informe_libro_de_compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.rpt_libro_de_compras)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_informe_libro_de_compras"
        Me.Text = "INFORME DE LIBRO DE COMPRAS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpt_libro_de_compras As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
