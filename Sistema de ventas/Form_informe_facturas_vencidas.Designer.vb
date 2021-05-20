<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_informe_facturas_vencidas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_informe_facturas_vencidas))
        Me.rpt_facturas_vencidas = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'rpt_facturas_vencidas
        '
        Me.rpt_facturas_vencidas.ActiveViewIndex = -1
        Me.rpt_facturas_vencidas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rpt_facturas_vencidas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpt_facturas_vencidas.Location = New System.Drawing.Point(0, 0)
        Me.rpt_facturas_vencidas.Name = "rpt_facturas_vencidas"
        Me.rpt_facturas_vencidas.SelectionFormula = ""
        Me.rpt_facturas_vencidas.Size = New System.Drawing.Size(292, 266)
        Me.rpt_facturas_vencidas.TabIndex = 0
        Me.rpt_facturas_vencidas.ViewTimeSelectionFormula = ""
        '
        'Form_informe_facturas_vencidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.rpt_facturas_vencidas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_informe_facturas_vencidas"
        Me.Text = "FACTURAS VENCIDAS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpt_facturas_vencidas As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
