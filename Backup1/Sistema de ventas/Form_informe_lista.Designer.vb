﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_informe_lista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_informe_lista))
        Me.rpt_lista = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'rpt_lista
        '
        Me.rpt_lista.ActiveViewIndex = -1
        Me.rpt_lista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rpt_lista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpt_lista.Location = New System.Drawing.Point(0, 0)
        Me.rpt_lista.Name = "rpt_lista"
        Me.rpt_lista.SelectionFormula = ""
        Me.rpt_lista.Size = New System.Drawing.Size(292, 266)
        Me.rpt_lista.TabIndex = 0
        Me.rpt_lista.ViewTimeSelectionFormula = ""
        '
        'Form_informe_lista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.rpt_lista)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_informe_lista"
        Me.Text = "LISTA PARA LA FACTURACION"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpt_lista As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
