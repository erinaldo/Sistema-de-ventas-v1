<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_informe_abono
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_informe_abono))
        Me.rpt_abono = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'rpt_abono
        '
        Me.rpt_abono.ActiveViewIndex = -1
        Me.rpt_abono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rpt_abono.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpt_abono.Location = New System.Drawing.Point(0, 0)
        Me.rpt_abono.Name = "rpt_abono"
        Me.rpt_abono.SelectionFormula = ""
        Me.rpt_abono.Size = New System.Drawing.Size(292, 266)
        Me.rpt_abono.TabIndex = 0
        Me.rpt_abono.ViewTimeSelectionFormula = ""
        '
        'Form_informe_abono
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.rpt_abono)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_informe_abono"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABONOS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpt_abono As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
