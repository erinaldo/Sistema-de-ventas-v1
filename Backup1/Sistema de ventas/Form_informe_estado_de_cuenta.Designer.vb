<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_informe_estado_de_cuenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_informe_estado_de_cuenta))
        Me.rpt_estado_de_cuenta = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        '    Me.CrystalReport11 = New proyecto_sistema_ventas.CrystalReport1
        '  Me.CrystalReport21 = New proyecto_sistema_ventas.CrystalReport2
        Me.SuspendLayout()
        '
        'rpt_estado_de_cuenta
        '
        Me.rpt_estado_de_cuenta.ActiveViewIndex = 0
        Me.rpt_estado_de_cuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rpt_estado_de_cuenta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpt_estado_de_cuenta.Location = New System.Drawing.Point(0, 0)
        Me.rpt_estado_de_cuenta.Name = "rpt_estado_de_cuenta"
        '    Me.rpt_estado_de_cuenta.ReportSource = Me.CrystalReport21
        Me.rpt_estado_de_cuenta.Size = New System.Drawing.Size(790, 389)
        Me.rpt_estado_de_cuenta.TabIndex = 0
        '
        'Form_informe_estado_de_cuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 389)
        Me.Controls.Add(Me.rpt_estado_de_cuenta)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_informe_estado_de_cuenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ESTADOS DE CUENTA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpt_estado_de_cuenta As CrystalDecisions.Windows.Forms.CrystalReportViewer

End Class
