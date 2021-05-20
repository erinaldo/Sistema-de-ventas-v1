<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_informe_deudores2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_informe_deudores2))
        Me.rpt_deudores2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'rpt_deudores2
        '
        Me.rpt_deudores2.ActiveViewIndex = -1
        Me.rpt_deudores2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rpt_deudores2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpt_deudores2.Location = New System.Drawing.Point(0, 0)
        Me.rpt_deudores2.Name = "rpt_deudores2"
        Me.rpt_deudores2.SelectionFormula = ""
        Me.rpt_deudores2.Size = New System.Drawing.Size(284, 262)
        Me.rpt_deudores2.TabIndex = 0
        Me.rpt_deudores2.ViewTimeSelectionFormula = ""
        '
        'Form_informe_deudores2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.rpt_deudores2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_informe_deudores2"
        Me.Text = "DEUDORES"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpt_deudores2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
