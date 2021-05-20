<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_caja_diaria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_caja_diaria))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_boleta_minimo = New System.Windows.Forms.TextBox()
        Me.txt_boleta_maximo = New System.Windows.Forms.TextBox()
        Me.txt_factura_minimo = New System.Windows.Forms.TextBox()
        Me.txt_factura_maximo = New System.Windows.Forms.TextBox()
        Me.txt_guia_minimo = New System.Windows.Forms.TextBox()
        Me.txt_guia_maximo = New System.Windows.Forms.TextBox()
        Me.txt_abono_minimo = New System.Windows.Forms.TextBox()
        Me.txt_abono_maximo = New System.Windows.Forms.TextBox()
        Me.txt_nota_credito_minimo = New System.Windows.Forms.TextBox()
        Me.txt_nota_credito_maximo = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtp_fecha_caja_desde = New System.Windows.Forms.DateTimePicker()
        Me.txt_total_boleta_contado = New System.Windows.Forms.TextBox()
        Me.txt_total_factura_contado = New System.Windows.Forms.TextBox()
        Me.txt_total_factura_credito = New System.Windows.Forms.TextBox()
        Me.txt_total_guia_credito = New System.Windows.Forms.TextBox()
        Me.txt_total_abono_contado = New System.Windows.Forms.TextBox()
        Me.txt_total_nota_credito_contado = New System.Windows.Forms.TextBox()
        Me.GroupBox_boleta = New System.Windows.Forms.GroupBox()
        Me.txt_total_boleta_credito_millar = New System.Windows.Forms.TextBox()
        Me.txt_total_boleta_contado_millar = New System.Windows.Forms.TextBox()
        Me.txt_cantidad_boletas_anuladas = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox_factura = New System.Windows.Forms.GroupBox()
        Me.txt_total_factura_credito_millar = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_total_factura_contado_millar = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_cantidad_facturas_anuladas = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.GroupBox_guia = New System.Windows.Forms.GroupBox()
        Me.txt_total_guia_contado_millar = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txt_total_guia_credito_millar = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_cantidad_guias_anuladas = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.GroupBox_abono = New System.Windows.Forms.GroupBox()
        Me.txt_total_abono_credito_millar = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txt_total_abono_contado_millar = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_cantidad_abonos_anuladas = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.GroupBox_nc = New System.Windows.Forms.GroupBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txt_total_nota_credito_credito_millar = New System.Windows.Forms.TextBox()
        Me.txt_total_nota_credito_millar = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txt_cantidad_notas_credito_anuladas = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.txt_total_credito_millar = New System.Windows.Forms.TextBox()
        Me.txt_total_credito = New System.Windows.Forms.TextBox()
        Me.txt_total_contado_millar = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_total_contado = New System.Windows.Forms.TextBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.btn_mostrar = New System.Windows.Forms.Button()
        Me.btn_ticket = New System.Windows.Forms.Button()
        Me.btn_detalle = New System.Windows.Forms.Button()
        Me.btn_calcular = New System.Windows.Forms.Button()
        Me.btn_limpiar = New System.Windows.Forms.Button()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.txt_total_boleta_credito = New System.Windows.Forms.TextBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.txt_total_egresos = New System.Windows.Forms.TextBox()
        Me.txt_total_ingresos = New System.Windows.Forms.TextBox()
        Me.GroupBox_nd = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txt_total_nota_debito_credito_millar = New System.Windows.Forms.TextBox()
        Me.txt_total_nota_debito_millar = New System.Windows.Forms.TextBox()
        Me.txt_nota_debito_minimo = New System.Windows.Forms.TextBox()
        Me.txt_nota_debito_maximo = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txt_cantidad_notas_debito_anuladas = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.txt_total_nota_debito_contado = New System.Windows.Forms.TextBox()
        Me.txt_total_nota_credito_credito = New System.Windows.Forms.TextBox()
        Me.lbl_mensaje = New System.Windows.Forms.Label()
        Me.txt_total_abono_credito = New System.Windows.Forms.TextBox()
        Me.txt_total_guia_contado = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Combo_sucursal = New System.Windows.Forms.ComboBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.Combo_caja = New System.Windows.Forms.ComboBox()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.PrintDocument_ticket = New System.Drawing.Printing.PrintDocument()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.PrintDocument_carta = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.grilla_detalle_caja = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_total_nota_debito_credito = New System.Windows.Forms.TextBox()
        Me.grilla_inventario = New System.Windows.Forms.DataGridView()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox_boleta.SuspendLayout()
        Me.GroupBox_factura.SuspendLayout()
        Me.GroupBox_guia.SuspendLayout()
        Me.GroupBox_abono.SuspendLayout()
        Me.GroupBox_nc.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox_nd.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_detalle_caja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla_inventario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(27, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "DESDE:"
        '
        'txt_boleta_minimo
        '
        Me.txt_boleta_minimo.BackColor = System.Drawing.Color.White
        Me.txt_boleta_minimo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_boleta_minimo.Location = New System.Drawing.Point(31, 41)
        Me.txt_boleta_minimo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_boleta_minimo.Name = "txt_boleta_minimo"
        Me.txt_boleta_minimo.Size = New System.Drawing.Size(147, 29)
        Me.txt_boleta_minimo.TabIndex = 1
        Me.txt_boleta_minimo.TabStop = False
        Me.txt_boleta_minimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_boleta_maximo
        '
        Me.txt_boleta_maximo.BackColor = System.Drawing.Color.White
        Me.txt_boleta_maximo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_boleta_maximo.Location = New System.Drawing.Point(209, 41)
        Me.txt_boleta_maximo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_boleta_maximo.Name = "txt_boleta_maximo"
        Me.txt_boleta_maximo.Size = New System.Drawing.Size(147, 29)
        Me.txt_boleta_maximo.TabIndex = 1
        Me.txt_boleta_maximo.TabStop = False
        Me.txt_boleta_maximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_factura_minimo
        '
        Me.txt_factura_minimo.BackColor = System.Drawing.Color.White
        Me.txt_factura_minimo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_factura_minimo.Location = New System.Drawing.Point(31, 41)
        Me.txt_factura_minimo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_factura_minimo.Name = "txt_factura_minimo"
        Me.txt_factura_minimo.Size = New System.Drawing.Size(147, 29)
        Me.txt_factura_minimo.TabIndex = 1
        Me.txt_factura_minimo.TabStop = False
        Me.txt_factura_minimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_factura_maximo
        '
        Me.txt_factura_maximo.BackColor = System.Drawing.Color.White
        Me.txt_factura_maximo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_factura_maximo.Location = New System.Drawing.Point(209, 41)
        Me.txt_factura_maximo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_factura_maximo.Name = "txt_factura_maximo"
        Me.txt_factura_maximo.Size = New System.Drawing.Size(147, 29)
        Me.txt_factura_maximo.TabIndex = 1
        Me.txt_factura_maximo.TabStop = False
        Me.txt_factura_maximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_guia_minimo
        '
        Me.txt_guia_minimo.BackColor = System.Drawing.Color.White
        Me.txt_guia_minimo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_guia_minimo.HideSelection = False
        Me.txt_guia_minimo.Location = New System.Drawing.Point(31, 41)
        Me.txt_guia_minimo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_guia_minimo.Name = "txt_guia_minimo"
        Me.txt_guia_minimo.Size = New System.Drawing.Size(147, 29)
        Me.txt_guia_minimo.TabIndex = 1
        Me.txt_guia_minimo.TabStop = False
        Me.txt_guia_minimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_guia_maximo
        '
        Me.txt_guia_maximo.BackColor = System.Drawing.Color.White
        Me.txt_guia_maximo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_guia_maximo.Location = New System.Drawing.Point(209, 41)
        Me.txt_guia_maximo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_guia_maximo.Name = "txt_guia_maximo"
        Me.txt_guia_maximo.Size = New System.Drawing.Size(147, 29)
        Me.txt_guia_maximo.TabIndex = 1
        Me.txt_guia_maximo.TabStop = False
        Me.txt_guia_maximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_abono_minimo
        '
        Me.txt_abono_minimo.BackColor = System.Drawing.Color.White
        Me.txt_abono_minimo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_abono_minimo.Location = New System.Drawing.Point(31, 41)
        Me.txt_abono_minimo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_abono_minimo.Name = "txt_abono_minimo"
        Me.txt_abono_minimo.Size = New System.Drawing.Size(147, 29)
        Me.txt_abono_minimo.TabIndex = 1
        Me.txt_abono_minimo.TabStop = False
        Me.txt_abono_minimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_abono_maximo
        '
        Me.txt_abono_maximo.BackColor = System.Drawing.Color.White
        Me.txt_abono_maximo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_abono_maximo.Location = New System.Drawing.Point(209, 41)
        Me.txt_abono_maximo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_abono_maximo.Name = "txt_abono_maximo"
        Me.txt_abono_maximo.Size = New System.Drawing.Size(147, 29)
        Me.txt_abono_maximo.TabIndex = 1
        Me.txt_abono_maximo.TabStop = False
        Me.txt_abono_maximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_nota_credito_minimo
        '
        Me.txt_nota_credito_minimo.BackColor = System.Drawing.Color.White
        Me.txt_nota_credito_minimo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nota_credito_minimo.Location = New System.Drawing.Point(31, 41)
        Me.txt_nota_credito_minimo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_nota_credito_minimo.Name = "txt_nota_credito_minimo"
        Me.txt_nota_credito_minimo.Size = New System.Drawing.Size(147, 29)
        Me.txt_nota_credito_minimo.TabIndex = 1
        Me.txt_nota_credito_minimo.TabStop = False
        Me.txt_nota_credito_minimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_nota_credito_maximo
        '
        Me.txt_nota_credito_maximo.BackColor = System.Drawing.Color.White
        Me.txt_nota_credito_maximo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nota_credito_maximo.Location = New System.Drawing.Point(209, 41)
        Me.txt_nota_credito_maximo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_nota_credito_maximo.Name = "txt_nota_credito_maximo"
        Me.txt_nota_credito_maximo.Size = New System.Drawing.Size(147, 29)
        Me.txt_nota_credito_maximo.TabIndex = 1
        Me.txt_nota_credito_maximo.TabStop = False
        Me.txt_nota_credito_maximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dtp_fecha_caja_desde)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(937, 95)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(412, 80)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "FECHA:"
        '
        'dtp_fecha_caja_desde
        '
        Me.dtp_fecha_caja_desde.Checked = False
        Me.dtp_fecha_caja_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_caja_desde.Location = New System.Drawing.Point(29, 31)
        Me.dtp_fecha_caja_desde.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_fecha_caja_desde.Name = "dtp_fecha_caja_desde"
        Me.dtp_fecha_caja_desde.Size = New System.Drawing.Size(355, 29)
        Me.dtp_fecha_caja_desde.TabIndex = 0
        '
        'txt_total_boleta_contado
        '
        Me.txt_total_boleta_contado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_boleta_contado.Location = New System.Drawing.Point(1381, 22)
        Me.txt_total_boleta_contado.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_boleta_contado.Name = "txt_total_boleta_contado"
        Me.txt_total_boleta_contado.ReadOnly = True
        Me.txt_total_boleta_contado.Size = New System.Drawing.Size(39, 29)
        Me.txt_total_boleta_contado.TabIndex = 4
        Me.txt_total_boleta_contado.TabStop = False
        Me.txt_total_boleta_contado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_factura_contado
        '
        Me.txt_total_factura_contado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_factura_contado.Location = New System.Drawing.Point(1381, 81)
        Me.txt_total_factura_contado.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_factura_contado.Name = "txt_total_factura_contado"
        Me.txt_total_factura_contado.ReadOnly = True
        Me.txt_total_factura_contado.Size = New System.Drawing.Size(39, 29)
        Me.txt_total_factura_contado.TabIndex = 4
        Me.txt_total_factura_contado.TabStop = False
        Me.txt_total_factura_contado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_factura_credito
        '
        Me.txt_total_factura_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_factura_credito.Location = New System.Drawing.Point(1420, 81)
        Me.txt_total_factura_credito.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_factura_credito.Name = "txt_total_factura_credito"
        Me.txt_total_factura_credito.ReadOnly = True
        Me.txt_total_factura_credito.Size = New System.Drawing.Size(39, 29)
        Me.txt_total_factura_credito.TabIndex = 4
        Me.txt_total_factura_credito.TabStop = False
        Me.txt_total_factura_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_guia_credito
        '
        Me.txt_total_guia_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_guia_credito.Location = New System.Drawing.Point(1420, 138)
        Me.txt_total_guia_credito.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_guia_credito.Name = "txt_total_guia_credito"
        Me.txt_total_guia_credito.ReadOnly = True
        Me.txt_total_guia_credito.Size = New System.Drawing.Size(39, 29)
        Me.txt_total_guia_credito.TabIndex = 4
        Me.txt_total_guia_credito.TabStop = False
        Me.txt_total_guia_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_abono_contado
        '
        Me.txt_total_abono_contado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_abono_contado.Location = New System.Drawing.Point(1381, 199)
        Me.txt_total_abono_contado.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_abono_contado.Name = "txt_total_abono_contado"
        Me.txt_total_abono_contado.ReadOnly = True
        Me.txt_total_abono_contado.Size = New System.Drawing.Size(39, 29)
        Me.txt_total_abono_contado.TabIndex = 4
        Me.txt_total_abono_contado.TabStop = False
        Me.txt_total_abono_contado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_nota_credito_contado
        '
        Me.txt_total_nota_credito_contado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_nota_credito_contado.Location = New System.Drawing.Point(1381, 258)
        Me.txt_total_nota_credito_contado.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_nota_credito_contado.Name = "txt_total_nota_credito_contado"
        Me.txt_total_nota_credito_contado.ReadOnly = True
        Me.txt_total_nota_credito_contado.Size = New System.Drawing.Size(39, 29)
        Me.txt_total_nota_credito_contado.TabIndex = 4
        Me.txt_total_nota_credito_contado.TabStop = False
        Me.txt_total_nota_credito_contado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox_boleta
        '
        Me.GroupBox_boleta.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_boleta.Controls.Add(Me.txt_total_boleta_credito_millar)
        Me.GroupBox_boleta.Controls.Add(Me.txt_total_boleta_contado_millar)
        Me.GroupBox_boleta.Controls.Add(Me.txt_boleta_maximo)
        Me.GroupBox_boleta.Controls.Add(Me.txt_cantidad_boletas_anuladas)
        Me.GroupBox_boleta.Controls.Add(Me.Label30)
        Me.GroupBox_boleta.Controls.Add(Me.Label25)
        Me.GroupBox_boleta.Controls.Add(Me.txt_boleta_minimo)
        Me.GroupBox_boleta.Controls.Add(Me.Label8)
        Me.GroupBox_boleta.Controls.Add(Me.Label7)
        Me.GroupBox_boleta.Controls.Add(Me.Label1)
        Me.GroupBox_boleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_boleta.Location = New System.Drawing.Point(8, 95)
        Me.GroupBox_boleta.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_boleta.Name = "GroupBox_boleta"
        Me.GroupBox_boleta.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_boleta.Size = New System.Drawing.Size(921, 80)
        Me.GroupBox_boleta.TabIndex = 5
        Me.GroupBox_boleta.TabStop = False
        Me.GroupBox_boleta.Text = "BOLETA:"
        '
        'txt_total_boleta_credito_millar
        '
        Me.txt_total_boleta_credito_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_boleta_credito_millar.Location = New System.Drawing.Point(565, 41)
        Me.txt_total_boleta_credito_millar.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_boleta_credito_millar.Name = "txt_total_boleta_credito_millar"
        Me.txt_total_boleta_credito_millar.ReadOnly = True
        Me.txt_total_boleta_credito_millar.Size = New System.Drawing.Size(147, 29)
        Me.txt_total_boleta_credito_millar.TabIndex = 5
        Me.txt_total_boleta_credito_millar.TabStop = False
        Me.txt_total_boleta_credito_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_boleta_contado_millar
        '
        Me.txt_total_boleta_contado_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_boleta_contado_millar.Location = New System.Drawing.Point(387, 41)
        Me.txt_total_boleta_contado_millar.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_boleta_contado_millar.Name = "txt_total_boleta_contado_millar"
        Me.txt_total_boleta_contado_millar.ReadOnly = True
        Me.txt_total_boleta_contado_millar.Size = New System.Drawing.Size(147, 29)
        Me.txt_total_boleta_contado_millar.TabIndex = 5
        Me.txt_total_boleta_contado_millar.TabStop = False
        Me.txt_total_boleta_contado_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_cantidad_boletas_anuladas
        '
        Me.txt_cantidad_boletas_anuladas.BackColor = System.Drawing.SystemColors.Control
        Me.txt_cantidad_boletas_anuladas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad_boletas_anuladas.Location = New System.Drawing.Point(743, 41)
        Me.txt_cantidad_boletas_anuladas.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_cantidad_boletas_anuladas.Name = "txt_cantidad_boletas_anuladas"
        Me.txt_cantidad_boletas_anuladas.ReadOnly = True
        Me.txt_cantidad_boletas_anuladas.Size = New System.Drawing.Size(147, 29)
        Me.txt_cantidad_boletas_anuladas.TabIndex = 9
        Me.txt_cantidad_boletas_anuladas.TabStop = False
        Me.txt_cantidad_boletas_anuladas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Location = New System.Drawing.Point(739, 19)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(119, 20)
        Me.Label30.TabIndex = 8
        Me.Label30.Text = "DOC. NULOS:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Location = New System.Drawing.Point(561, 19)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(89, 20)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "CREDITO:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(383, 19)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 20)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "CONTADO:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(205, 19)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 20)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "HASTA:"
        '
        'GroupBox_factura
        '
        Me.GroupBox_factura.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_factura.Controls.Add(Me.txt_total_factura_credito_millar)
        Me.GroupBox_factura.Controls.Add(Me.Label11)
        Me.GroupBox_factura.Controls.Add(Me.txt_total_factura_contado_millar)
        Me.GroupBox_factura.Controls.Add(Me.txt_factura_maximo)
        Me.GroupBox_factura.Controls.Add(Me.txt_factura_minimo)
        Me.GroupBox_factura.Controls.Add(Me.Label4)
        Me.GroupBox_factura.Controls.Add(Me.Label2)
        Me.GroupBox_factura.Controls.Add(Me.Label3)
        Me.GroupBox_factura.Controls.Add(Me.txt_cantidad_facturas_anuladas)
        Me.GroupBox_factura.Controls.Add(Me.Label35)
        Me.GroupBox_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_factura.Location = New System.Drawing.Point(8, 175)
        Me.GroupBox_factura.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_factura.Name = "GroupBox_factura"
        Me.GroupBox_factura.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_factura.Size = New System.Drawing.Size(921, 80)
        Me.GroupBox_factura.TabIndex = 6
        Me.GroupBox_factura.TabStop = False
        Me.GroupBox_factura.Text = "FACTURA:"
        '
        'txt_total_factura_credito_millar
        '
        Me.txt_total_factura_credito_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_factura_credito_millar.Location = New System.Drawing.Point(565, 41)
        Me.txt_total_factura_credito_millar.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_factura_credito_millar.Name = "txt_total_factura_credito_millar"
        Me.txt_total_factura_credito_millar.ReadOnly = True
        Me.txt_total_factura_credito_millar.Size = New System.Drawing.Size(147, 29)
        Me.txt_total_factura_credito_millar.TabIndex = 5
        Me.txt_total_factura_credito_millar.TabStop = False
        Me.txt_total_factura_credito_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(561, 19)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 20)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "CREDITO:"
        '
        'txt_total_factura_contado_millar
        '
        Me.txt_total_factura_contado_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_factura_contado_millar.Location = New System.Drawing.Point(387, 41)
        Me.txt_total_factura_contado_millar.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_factura_contado_millar.Name = "txt_total_factura_contado_millar"
        Me.txt_total_factura_contado_millar.ReadOnly = True
        Me.txt_total_factura_contado_millar.Size = New System.Drawing.Size(147, 29)
        Me.txt_total_factura_contado_millar.TabIndex = 5
        Me.txt_total_factura_contado_millar.TabStop = False
        Me.txt_total_factura_contado_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(383, 19)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "CONTADO:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(27, 19)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "DESDE:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(205, 19)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "HASTA:"
        '
        'txt_cantidad_facturas_anuladas
        '
        Me.txt_cantidad_facturas_anuladas.BackColor = System.Drawing.SystemColors.Control
        Me.txt_cantidad_facturas_anuladas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad_facturas_anuladas.Location = New System.Drawing.Point(743, 41)
        Me.txt_cantidad_facturas_anuladas.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_cantidad_facturas_anuladas.Name = "txt_cantidad_facturas_anuladas"
        Me.txt_cantidad_facturas_anuladas.ReadOnly = True
        Me.txt_cantidad_facturas_anuladas.Size = New System.Drawing.Size(147, 29)
        Me.txt_cantidad_facturas_anuladas.TabIndex = 16
        Me.txt_cantidad_facturas_anuladas.TabStop = False
        Me.txt_cantidad_facturas_anuladas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Location = New System.Drawing.Point(739, 19)
        Me.Label35.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(119, 20)
        Me.Label35.TabIndex = 15
        Me.Label35.Text = "DOC. NULOS:"
        '
        'GroupBox_guia
        '
        Me.GroupBox_guia.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_guia.Controls.Add(Me.txt_total_guia_contado_millar)
        Me.GroupBox_guia.Controls.Add(Me.Label29)
        Me.GroupBox_guia.Controls.Add(Me.txt_total_guia_credito_millar)
        Me.GroupBox_guia.Controls.Add(Me.txt_guia_maximo)
        Me.GroupBox_guia.Controls.Add(Me.txt_guia_minimo)
        Me.GroupBox_guia.Controls.Add(Me.Label14)
        Me.GroupBox_guia.Controls.Add(Me.Label13)
        Me.GroupBox_guia.Controls.Add(Me.Label12)
        Me.GroupBox_guia.Controls.Add(Me.txt_cantidad_guias_anuladas)
        Me.GroupBox_guia.Controls.Add(Me.Label39)
        Me.GroupBox_guia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_guia.Location = New System.Drawing.Point(8, 255)
        Me.GroupBox_guia.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_guia.Name = "GroupBox_guia"
        Me.GroupBox_guia.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_guia.Size = New System.Drawing.Size(921, 80)
        Me.GroupBox_guia.TabIndex = 8
        Me.GroupBox_guia.TabStop = False
        Me.GroupBox_guia.Text = "GUIA:"
        '
        'txt_total_guia_contado_millar
        '
        Me.txt_total_guia_contado_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_guia_contado_millar.Location = New System.Drawing.Point(387, 41)
        Me.txt_total_guia_contado_millar.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_guia_contado_millar.Name = "txt_total_guia_contado_millar"
        Me.txt_total_guia_contado_millar.ReadOnly = True
        Me.txt_total_guia_contado_millar.Size = New System.Drawing.Size(147, 29)
        Me.txt_total_guia_contado_millar.TabIndex = 20
        Me.txt_total_guia_contado_millar.TabStop = False
        Me.txt_total_guia_contado_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Location = New System.Drawing.Point(383, 19)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(98, 20)
        Me.Label29.TabIndex = 19
        Me.Label29.Text = "CONTADO:"
        '
        'txt_total_guia_credito_millar
        '
        Me.txt_total_guia_credito_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_guia_credito_millar.Location = New System.Drawing.Point(565, 41)
        Me.txt_total_guia_credito_millar.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_guia_credito_millar.Name = "txt_total_guia_credito_millar"
        Me.txt_total_guia_credito_millar.ReadOnly = True
        Me.txt_total_guia_credito_millar.Size = New System.Drawing.Size(147, 29)
        Me.txt_total_guia_credito_millar.TabIndex = 5
        Me.txt_total_guia_credito_millar.TabStop = False
        Me.txt_total_guia_credito_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(561, 19)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 20)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "CREDITO:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(27, 19)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 20)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "DESDE:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(205, 19)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 20)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "HASTA:"
        '
        'txt_cantidad_guias_anuladas
        '
        Me.txt_cantidad_guias_anuladas.BackColor = System.Drawing.SystemColors.Control
        Me.txt_cantidad_guias_anuladas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad_guias_anuladas.Location = New System.Drawing.Point(743, 41)
        Me.txt_cantidad_guias_anuladas.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_cantidad_guias_anuladas.Name = "txt_cantidad_guias_anuladas"
        Me.txt_cantidad_guias_anuladas.ReadOnly = True
        Me.txt_cantidad_guias_anuladas.Size = New System.Drawing.Size(147, 29)
        Me.txt_cantidad_guias_anuladas.TabIndex = 16
        Me.txt_cantidad_guias_anuladas.TabStop = False
        Me.txt_cantidad_guias_anuladas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Location = New System.Drawing.Point(739, 19)
        Me.Label39.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(119, 20)
        Me.Label39.TabIndex = 15
        Me.Label39.Text = "DOC. NULOS:"
        '
        'GroupBox_abono
        '
        Me.GroupBox_abono.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_abono.Controls.Add(Me.txt_total_abono_credito_millar)
        Me.GroupBox_abono.Controls.Add(Me.Label28)
        Me.GroupBox_abono.Controls.Add(Me.txt_total_abono_contado_millar)
        Me.GroupBox_abono.Controls.Add(Me.txt_abono_minimo)
        Me.GroupBox_abono.Controls.Add(Me.txt_abono_maximo)
        Me.GroupBox_abono.Controls.Add(Me.Label17)
        Me.GroupBox_abono.Controls.Add(Me.Label16)
        Me.GroupBox_abono.Controls.Add(Me.Label15)
        Me.GroupBox_abono.Controls.Add(Me.txt_cantidad_abonos_anuladas)
        Me.GroupBox_abono.Controls.Add(Me.Label43)
        Me.GroupBox_abono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_abono.Location = New System.Drawing.Point(8, 335)
        Me.GroupBox_abono.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_abono.Name = "GroupBox_abono"
        Me.GroupBox_abono.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_abono.Size = New System.Drawing.Size(921, 80)
        Me.GroupBox_abono.TabIndex = 9
        Me.GroupBox_abono.TabStop = False
        Me.GroupBox_abono.Text = "ABONO:"
        '
        'txt_total_abono_credito_millar
        '
        Me.txt_total_abono_credito_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_abono_credito_millar.Location = New System.Drawing.Point(565, 41)
        Me.txt_total_abono_credito_millar.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_abono_credito_millar.Name = "txt_total_abono_credito_millar"
        Me.txt_total_abono_credito_millar.ReadOnly = True
        Me.txt_total_abono_credito_millar.Size = New System.Drawing.Size(147, 29)
        Me.txt_total_abono_credito_millar.TabIndex = 18
        Me.txt_total_abono_credito_millar.TabStop = False
        Me.txt_total_abono_credito_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Location = New System.Drawing.Point(561, 19)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(89, 20)
        Me.Label28.TabIndex = 17
        Me.Label28.Text = "CREDITO:"
        '
        'txt_total_abono_contado_millar
        '
        Me.txt_total_abono_contado_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_abono_contado_millar.Location = New System.Drawing.Point(387, 41)
        Me.txt_total_abono_contado_millar.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_abono_contado_millar.Name = "txt_total_abono_contado_millar"
        Me.txt_total_abono_contado_millar.ReadOnly = True
        Me.txt_total_abono_contado_millar.Size = New System.Drawing.Size(147, 29)
        Me.txt_total_abono_contado_millar.TabIndex = 5
        Me.txt_total_abono_contado_millar.TabStop = False
        Me.txt_total_abono_contado_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(383, 19)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(98, 20)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "CONTADO:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(27, 19)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 20)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "DESDE:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(205, 19)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 20)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "HASTA:"
        '
        'txt_cantidad_abonos_anuladas
        '
        Me.txt_cantidad_abonos_anuladas.BackColor = System.Drawing.SystemColors.Control
        Me.txt_cantidad_abonos_anuladas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad_abonos_anuladas.Location = New System.Drawing.Point(743, 41)
        Me.txt_cantidad_abonos_anuladas.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_cantidad_abonos_anuladas.Name = "txt_cantidad_abonos_anuladas"
        Me.txt_cantidad_abonos_anuladas.ReadOnly = True
        Me.txt_cantidad_abonos_anuladas.Size = New System.Drawing.Size(147, 29)
        Me.txt_cantidad_abonos_anuladas.TabIndex = 16
        Me.txt_cantidad_abonos_anuladas.TabStop = False
        Me.txt_cantidad_abonos_anuladas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Location = New System.Drawing.Point(739, 19)
        Me.Label43.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(119, 20)
        Me.Label43.TabIndex = 15
        Me.Label43.Text = "DOC. NULOS:"
        '
        'GroupBox_nc
        '
        Me.GroupBox_nc.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_nc.Controls.Add(Me.Label24)
        Me.GroupBox_nc.Controls.Add(Me.txt_total_nota_credito_credito_millar)
        Me.GroupBox_nc.Controls.Add(Me.txt_total_nota_credito_millar)
        Me.GroupBox_nc.Controls.Add(Me.txt_nota_credito_minimo)
        Me.GroupBox_nc.Controls.Add(Me.txt_nota_credito_maximo)
        Me.GroupBox_nc.Controls.Add(Me.Label20)
        Me.GroupBox_nc.Controls.Add(Me.Label19)
        Me.GroupBox_nc.Controls.Add(Me.Label18)
        Me.GroupBox_nc.Controls.Add(Me.txt_cantidad_notas_credito_anuladas)
        Me.GroupBox_nc.Controls.Add(Me.Label47)
        Me.GroupBox_nc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_nc.Location = New System.Drawing.Point(8, 415)
        Me.GroupBox_nc.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_nc.Name = "GroupBox_nc"
        Me.GroupBox_nc.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_nc.Size = New System.Drawing.Size(921, 80)
        Me.GroupBox_nc.TabIndex = 10
        Me.GroupBox_nc.TabStop = False
        Me.GroupBox_nc.Text = "NOTA DE CREDITO:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Location = New System.Drawing.Point(561, 19)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(89, 20)
        Me.Label24.TabIndex = 315
        Me.Label24.Text = "CREDITO:"
        '
        'txt_total_nota_credito_credito_millar
        '
        Me.txt_total_nota_credito_credito_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_nota_credito_credito_millar.Location = New System.Drawing.Point(565, 41)
        Me.txt_total_nota_credito_credito_millar.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_nota_credito_credito_millar.Name = "txt_total_nota_credito_credito_millar"
        Me.txt_total_nota_credito_credito_millar.ReadOnly = True
        Me.txt_total_nota_credito_credito_millar.Size = New System.Drawing.Size(147, 29)
        Me.txt_total_nota_credito_credito_millar.TabIndex = 314
        Me.txt_total_nota_credito_credito_millar.TabStop = False
        Me.txt_total_nota_credito_credito_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_nota_credito_millar
        '
        Me.txt_total_nota_credito_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_nota_credito_millar.Location = New System.Drawing.Point(387, 41)
        Me.txt_total_nota_credito_millar.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_nota_credito_millar.Name = "txt_total_nota_credito_millar"
        Me.txt_total_nota_credito_millar.ReadOnly = True
        Me.txt_total_nota_credito_millar.Size = New System.Drawing.Size(147, 29)
        Me.txt_total_nota_credito_millar.TabIndex = 5
        Me.txt_total_nota_credito_millar.TabStop = False
        Me.txt_total_nota_credito_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(383, 19)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(98, 20)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "CONTADO:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(27, 19)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 20)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "DESDE:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(205, 19)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 20)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "HASTA:"
        '
        'txt_cantidad_notas_credito_anuladas
        '
        Me.txt_cantidad_notas_credito_anuladas.BackColor = System.Drawing.SystemColors.Control
        Me.txt_cantidad_notas_credito_anuladas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad_notas_credito_anuladas.Location = New System.Drawing.Point(743, 41)
        Me.txt_cantidad_notas_credito_anuladas.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_cantidad_notas_credito_anuladas.Name = "txt_cantidad_notas_credito_anuladas"
        Me.txt_cantidad_notas_credito_anuladas.ReadOnly = True
        Me.txt_cantidad_notas_credito_anuladas.Size = New System.Drawing.Size(147, 29)
        Me.txt_cantidad_notas_credito_anuladas.TabIndex = 319
        Me.txt_cantidad_notas_credito_anuladas.TabStop = False
        Me.txt_cantidad_notas_credito_anuladas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.Location = New System.Drawing.Point(739, 19)
        Me.Label47.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(119, 20)
        Me.Label47.TabIndex = 318
        Me.Label47.Text = "DOC. NULOS:"
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox8.Controls.Add(Me.txt_total_credito_millar)
        Me.GroupBox8.Controls.Add(Me.txt_total_credito)
        Me.GroupBox8.Controls.Add(Me.txt_total_contado_millar)
        Me.GroupBox8.Controls.Add(Me.Label9)
        Me.GroupBox8.Controls.Add(Me.Label6)
        Me.GroupBox8.Controls.Add(Me.txt_total_contado)
        Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(937, 175)
        Me.GroupBox8.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox8.Size = New System.Drawing.Size(412, 80)
        Me.GroupBox8.TabIndex = 11
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "TOTALES:"
        '
        'txt_total_credito_millar
        '
        Me.txt_total_credito_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_credito_millar.Location = New System.Drawing.Point(234, 41)
        Me.txt_total_credito_millar.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_credito_millar.Name = "txt_total_credito_millar"
        Me.txt_total_credito_millar.ReadOnly = True
        Me.txt_total_credito_millar.Size = New System.Drawing.Size(150, 29)
        Me.txt_total_credito_millar.TabIndex = 145
        Me.txt_total_credito_millar.TabStop = False
        Me.txt_total_credito_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_credito
        '
        Me.txt_total_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_credito.Location = New System.Drawing.Point(248, 41)
        Me.txt_total_credito.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_credito.Name = "txt_total_credito"
        Me.txt_total_credito.ReadOnly = True
        Me.txt_total_credito.Size = New System.Drawing.Size(116, 29)
        Me.txt_total_credito.TabIndex = 144
        Me.txt_total_credito.TabStop = False
        Me.txt_total_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_contado_millar
        '
        Me.txt_total_contado_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_contado_millar.Location = New System.Drawing.Point(29, 41)
        Me.txt_total_contado_millar.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_contado_millar.Name = "txt_total_contado_millar"
        Me.txt_total_contado_millar.ReadOnly = True
        Me.txt_total_contado_millar.Size = New System.Drawing.Size(150, 29)
        Me.txt_total_contado_millar.TabIndex = 144
        Me.txt_total_contado_millar.TabStop = False
        Me.txt_total_contado_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(230, 19)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 20)
        Me.Label9.TabIndex = 143
        Me.Label9.Text = "CREDITO:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(25, 19)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 20)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "CONTADO:"
        '
        'txt_total_contado
        '
        Me.txt_total_contado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_contado.Location = New System.Drawing.Point(41, 41)
        Me.txt_total_contado.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_contado.Name = "txt_total_contado"
        Me.txt_total_contado.ReadOnly = True
        Me.txt_total_contado.Size = New System.Drawing.Size(116, 29)
        Me.txt_total_contado.TabIndex = 1
        Me.txt_total_contado.TabStop = False
        Me.txt_total_contado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox10.Controls.Add(Me.btn_mostrar)
        Me.GroupBox10.Controls.Add(Me.btn_ticket)
        Me.GroupBox10.Controls.Add(Me.btn_detalle)
        Me.GroupBox10.Controls.Add(Me.btn_calcular)
        Me.GroupBox10.Controls.Add(Me.btn_limpiar)
        Me.GroupBox10.Controls.Add(Me.btn_imprimir)
        Me.GroupBox10.Location = New System.Drawing.Point(937, 415)
        Me.GroupBox10.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox10.Size = New System.Drawing.Size(412, 160)
        Me.GroupBox10.TabIndex = 2
        Me.GroupBox10.TabStop = False
        '
        'btn_mostrar
        '
        Me.btn_mostrar.BackColor = System.Drawing.Color.Transparent
        Me.btn_mostrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_mostrar.Image = CType(resources.GetObject("btn_mostrar.Image"), System.Drawing.Image)
        Me.btn_mostrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_mostrar.Location = New System.Drawing.Point(9, 30)
        Me.btn_mostrar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_mostrar.Name = "btn_mostrar"
        Me.btn_mostrar.Size = New System.Drawing.Size(127, 49)
        Me.btn_mostrar.TabIndex = 1
        Me.btn_mostrar.Text = "MOSTRAR"
        Me.btn_mostrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_mostrar.UseVisualStyleBackColor = False
        '
        'btn_ticket
        '
        Me.btn_ticket.BackColor = System.Drawing.Color.Transparent
        Me.btn_ticket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ticket.Image = CType(resources.GetObject("btn_ticket.Image"), System.Drawing.Image)
        Me.btn_ticket.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ticket.Location = New System.Drawing.Point(143, 85)
        Me.btn_ticket.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_ticket.Name = "btn_ticket"
        Me.btn_ticket.Size = New System.Drawing.Size(127, 49)
        Me.btn_ticket.TabIndex = 4
        Me.btn_ticket.Text = "TICKET"
        Me.btn_ticket.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_ticket.UseVisualStyleBackColor = False
        '
        'btn_detalle
        '
        Me.btn_detalle.BackColor = System.Drawing.Color.Transparent
        Me.btn_detalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_detalle.Image = CType(resources.GetObject("btn_detalle.Image"), System.Drawing.Image)
        Me.btn_detalle.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_detalle.Location = New System.Drawing.Point(276, 30)
        Me.btn_detalle.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_detalle.Name = "btn_detalle"
        Me.btn_detalle.Size = New System.Drawing.Size(127, 49)
        Me.btn_detalle.TabIndex = 5
        Me.btn_detalle.Text = "DETALLE"
        Me.btn_detalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_detalle.UseVisualStyleBackColor = False
        '
        'btn_calcular
        '
        Me.btn_calcular.BackColor = System.Drawing.Color.Transparent
        Me.btn_calcular.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_calcular.Image = CType(resources.GetObject("btn_calcular.Image"), System.Drawing.Image)
        Me.btn_calcular.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_calcular.Location = New System.Drawing.Point(143, 30)
        Me.btn_calcular.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_calcular.Name = "btn_calcular"
        Me.btn_calcular.Size = New System.Drawing.Size(127, 49)
        Me.btn_calcular.TabIndex = 2
        Me.btn_calcular.Text = "CALCULAR"
        Me.btn_calcular.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_calcular.UseVisualStyleBackColor = False
        '
        'btn_limpiar
        '
        Me.btn_limpiar.BackColor = System.Drawing.Color.Transparent
        Me.btn_limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_limpiar.Image = CType(resources.GetObject("btn_limpiar.Image"), System.Drawing.Image)
        Me.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_limpiar.Location = New System.Drawing.Point(276, 85)
        Me.btn_limpiar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(127, 49)
        Me.btn_limpiar.TabIndex = 6
        Me.btn_limpiar.Text = "LIMPIAR"
        Me.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_limpiar.UseVisualStyleBackColor = False
        '
        'btn_imprimir
        '
        Me.btn_imprimir.BackColor = System.Drawing.Color.Transparent
        Me.btn_imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.Image = CType(resources.GetObject("btn_imprimir.Image"), System.Drawing.Image)
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_imprimir.Location = New System.Drawing.Point(9, 85)
        Me.btn_imprimir.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(127, 49)
        Me.btn_imprimir.TabIndex = 3
        Me.btn_imprimir.Text = "IMPRIMIR"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir.UseVisualStyleBackColor = False
        '
        'txt_total_boleta_credito
        '
        Me.txt_total_boleta_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_boleta_credito.Location = New System.Drawing.Point(1420, 22)
        Me.txt_total_boleta_credito.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_boleta_credito.Name = "txt_total_boleta_credito"
        Me.txt_total_boleta_credito.ReadOnly = True
        Me.txt_total_boleta_credito.Size = New System.Drawing.Size(39, 29)
        Me.txt_total_boleta_credito.TabIndex = 4
        Me.txt_total_boleta_credito.TabStop = False
        Me.txt_total_boleta_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'txt_total_egresos
        '
        Me.txt_total_egresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_egresos.Location = New System.Drawing.Point(1519, 215)
        Me.txt_total_egresos.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_egresos.Name = "txt_total_egresos"
        Me.txt_total_egresos.ReadOnly = True
        Me.txt_total_egresos.Size = New System.Drawing.Size(39, 29)
        Me.txt_total_egresos.TabIndex = 6
        Me.txt_total_egresos.TabStop = False
        Me.txt_total_egresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_ingresos
        '
        Me.txt_total_ingresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_ingresos.Location = New System.Drawing.Point(1471, 215)
        Me.txt_total_ingresos.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_ingresos.Name = "txt_total_ingresos"
        Me.txt_total_ingresos.ReadOnly = True
        Me.txt_total_ingresos.Size = New System.Drawing.Size(39, 29)
        Me.txt_total_ingresos.TabIndex = 309
        Me.txt_total_ingresos.TabStop = False
        Me.txt_total_ingresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox_nd
        '
        Me.GroupBox_nd.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_nd.Controls.Add(Me.Label26)
        Me.GroupBox_nd.Controls.Add(Me.txt_total_nota_debito_credito_millar)
        Me.GroupBox_nd.Controls.Add(Me.txt_total_nota_debito_millar)
        Me.GroupBox_nd.Controls.Add(Me.txt_nota_debito_minimo)
        Me.GroupBox_nd.Controls.Add(Me.txt_nota_debito_maximo)
        Me.GroupBox_nd.Controls.Add(Me.Label21)
        Me.GroupBox_nd.Controls.Add(Me.Label22)
        Me.GroupBox_nd.Controls.Add(Me.Label23)
        Me.GroupBox_nd.Controls.Add(Me.txt_cantidad_notas_debito_anuladas)
        Me.GroupBox_nd.Controls.Add(Me.Label51)
        Me.GroupBox_nd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_nd.Location = New System.Drawing.Point(8, 495)
        Me.GroupBox_nd.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_nd.Name = "GroupBox_nd"
        Me.GroupBox_nd.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_nd.Size = New System.Drawing.Size(921, 80)
        Me.GroupBox_nd.TabIndex = 11
        Me.GroupBox_nd.TabStop = False
        Me.GroupBox_nd.Text = "NOTA DE DEBITO:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Location = New System.Drawing.Point(561, 19)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(89, 20)
        Me.Label26.TabIndex = 316
        Me.Label26.Text = "CREDITO:"
        '
        'txt_total_nota_debito_credito_millar
        '
        Me.txt_total_nota_debito_credito_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_nota_debito_credito_millar.Location = New System.Drawing.Point(565, 41)
        Me.txt_total_nota_debito_credito_millar.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_nota_debito_credito_millar.Name = "txt_total_nota_debito_credito_millar"
        Me.txt_total_nota_debito_credito_millar.ReadOnly = True
        Me.txt_total_nota_debito_credito_millar.Size = New System.Drawing.Size(147, 29)
        Me.txt_total_nota_debito_credito_millar.TabIndex = 315
        Me.txt_total_nota_debito_credito_millar.TabStop = False
        Me.txt_total_nota_debito_credito_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_nota_debito_millar
        '
        Me.txt_total_nota_debito_millar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_nota_debito_millar.Location = New System.Drawing.Point(387, 41)
        Me.txt_total_nota_debito_millar.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_nota_debito_millar.Name = "txt_total_nota_debito_millar"
        Me.txt_total_nota_debito_millar.ReadOnly = True
        Me.txt_total_nota_debito_millar.Size = New System.Drawing.Size(147, 29)
        Me.txt_total_nota_debito_millar.TabIndex = 5
        Me.txt_total_nota_debito_millar.TabStop = False
        Me.txt_total_nota_debito_millar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_nota_debito_minimo
        '
        Me.txt_nota_debito_minimo.BackColor = System.Drawing.Color.White
        Me.txt_nota_debito_minimo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nota_debito_minimo.Location = New System.Drawing.Point(31, 41)
        Me.txt_nota_debito_minimo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_nota_debito_minimo.Name = "txt_nota_debito_minimo"
        Me.txt_nota_debito_minimo.Size = New System.Drawing.Size(147, 29)
        Me.txt_nota_debito_minimo.TabIndex = 1
        Me.txt_nota_debito_minimo.TabStop = False
        Me.txt_nota_debito_minimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_nota_debito_maximo
        '
        Me.txt_nota_debito_maximo.BackColor = System.Drawing.Color.White
        Me.txt_nota_debito_maximo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nota_debito_maximo.Location = New System.Drawing.Point(209, 41)
        Me.txt_nota_debito_maximo.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_nota_debito_maximo.Name = "txt_nota_debito_maximo"
        Me.txt_nota_debito_maximo.Size = New System.Drawing.Size(147, 29)
        Me.txt_nota_debito_maximo.TabIndex = 1
        Me.txt_nota_debito_maximo.TabStop = False
        Me.txt_nota_debito_maximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(383, 19)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(98, 20)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "CONTADO:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(27, 19)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(73, 20)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "DESDE:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Location = New System.Drawing.Point(205, 19)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(70, 20)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "HASTA:"
        '
        'txt_cantidad_notas_debito_anuladas
        '
        Me.txt_cantidad_notas_debito_anuladas.BackColor = System.Drawing.SystemColors.Control
        Me.txt_cantidad_notas_debito_anuladas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cantidad_notas_debito_anuladas.Location = New System.Drawing.Point(743, 41)
        Me.txt_cantidad_notas_debito_anuladas.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_cantidad_notas_debito_anuladas.Name = "txt_cantidad_notas_debito_anuladas"
        Me.txt_cantidad_notas_debito_anuladas.ReadOnly = True
        Me.txt_cantidad_notas_debito_anuladas.Size = New System.Drawing.Size(147, 29)
        Me.txt_cantidad_notas_debito_anuladas.TabIndex = 320
        Me.txt_cantidad_notas_debito_anuladas.TabStop = False
        Me.txt_cantidad_notas_debito_anuladas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.Location = New System.Drawing.Point(739, 19)
        Me.Label51.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(119, 20)
        Me.Label51.TabIndex = 319
        Me.Label51.Text = "DOC. NULOS:"
        '
        'txt_total_nota_debito_contado
        '
        Me.txt_total_nota_debito_contado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_nota_debito_contado.Location = New System.Drawing.Point(1381, 305)
        Me.txt_total_nota_debito_contado.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_nota_debito_contado.Name = "txt_total_nota_debito_contado"
        Me.txt_total_nota_debito_contado.ReadOnly = True
        Me.txt_total_nota_debito_contado.Size = New System.Drawing.Size(39, 29)
        Me.txt_total_nota_debito_contado.TabIndex = 6
        Me.txt_total_nota_debito_contado.TabStop = False
        Me.txt_total_nota_debito_contado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_nota_credito_credito
        '
        Me.txt_total_nota_credito_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_nota_credito_credito.Location = New System.Drawing.Point(1429, 258)
        Me.txt_total_nota_credito_credito.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_nota_credito_credito.Name = "txt_total_nota_credito_credito"
        Me.txt_total_nota_credito_credito.ReadOnly = True
        Me.txt_total_nota_credito_credito.Size = New System.Drawing.Size(39, 29)
        Me.txt_total_nota_credito_credito.TabIndex = 313
        Me.txt_total_nota_credito_credito.TabStop = False
        Me.txt_total_nota_credito_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_mensaje
        '
        Me.lbl_mensaje.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mensaje.Location = New System.Drawing.Point(410, 2)
        Me.lbl_mensaje.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_mensaje.Name = "lbl_mensaje"
        Me.lbl_mensaje.Size = New System.Drawing.Size(945, 100)
        Me.lbl_mensaje.TabIndex = 319
        Me.lbl_mensaje.Text = "UN MOMENTO POR FAVOR..."
        Me.lbl_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_mensaje.Visible = False
        '
        'txt_total_abono_credito
        '
        Me.txt_total_abono_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_abono_credito.Location = New System.Drawing.Point(1420, 199)
        Me.txt_total_abono_credito.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_abono_credito.Name = "txt_total_abono_credito"
        Me.txt_total_abono_credito.ReadOnly = True
        Me.txt_total_abono_credito.Size = New System.Drawing.Size(39, 29)
        Me.txt_total_abono_credito.TabIndex = 324
        Me.txt_total_abono_credito.TabStop = False
        Me.txt_total_abono_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total_guia_contado
        '
        Me.txt_total_guia_contado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_guia_contado.Location = New System.Drawing.Point(1381, 140)
        Me.txt_total_guia_contado.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_guia_contado.Name = "txt_total_guia_contado"
        Me.txt_total_guia_contado.ReadOnly = True
        Me.txt_total_guia_contado.Size = New System.Drawing.Size(39, 29)
        Me.txt_total_guia_contado.TabIndex = 325
        Me.txt_total_guia_contado.TabStop = False
        Me.txt_total_guia_contado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.Combo_sucursal)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(937, 255)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(412, 80)
        Me.GroupBox4.TabIndex = 149
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "SUCURSAL: "
        '
        'Combo_sucursal
        '
        Me.Combo_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_sucursal.FormattingEnabled = True
        Me.Combo_sucursal.Location = New System.Drawing.Point(29, 31)
        Me.Combo_sucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_sucursal.Name = "Combo_sucursal"
        Me.Combo_sucursal.Size = New System.Drawing.Size(357, 32)
        Me.Combo_sucursal.TabIndex = 3
        Me.Combo_sucursal.TabStop = False
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox9.Controls.Add(Me.Combo_caja)
        Me.GroupBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(937, 335)
        Me.GroupBox9.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox9.Size = New System.Drawing.Size(412, 80)
        Me.GroupBox9.TabIndex = 150
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "CAJA: "
        '
        'Combo_caja
        '
        Me.Combo_caja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_caja.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_caja.FormattingEnabled = True
        Me.Combo_caja.Location = New System.Drawing.Point(29, 31)
        Me.Combo_caja.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_caja.Name = "Combo_caja"
        Me.Combo_caja.Size = New System.Drawing.Size(357, 32)
        Me.Combo_caja.TabIndex = 3
        Me.Combo_caja.TabStop = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(8, 7)
        Me.PictureBox_logo.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(400, 86)
        Me.PictureBox_logo.TabIndex = 65
        Me.PictureBox_logo.TabStop = False
        '
        'PrintDocument_ticket
        '
        '
        'PrintDocument_carta
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'grilla_detalle_caja
        '
        Me.grilla_detalle_caja.AllowUserToAddRows = False
        Me.grilla_detalle_caja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grilla_detalle_caja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_detalle_caja.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.Column2, Me.Column4})
        Me.grilla_detalle_caja.Location = New System.Drawing.Point(8, 582)
        Me.grilla_detalle_caja.Margin = New System.Windows.Forms.Padding(4)
        Me.grilla_detalle_caja.Name = "grilla_detalle_caja"
        Me.grilla_detalle_caja.ReadOnly = True
        Me.grilla_detalle_caja.Size = New System.Drawing.Size(1341, 272)
        Me.grilla_detalle_caja.TabIndex = 343
        Me.grilla_detalle_caja.TabStop = False
        '
        'Column3
        '
        Me.Column3.HeaderText = "IMPRIMIR"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "TIPO"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "DETALLE"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn2.HeaderText = "MONTO"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "MONTO"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "HORA"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'txt_total_nota_debito_credito
        '
        Me.txt_total_nota_debito_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total_nota_debito_credito.Location = New System.Drawing.Point(1429, 305)
        Me.txt_total_nota_debito_credito.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_total_nota_debito_credito.Name = "txt_total_nota_debito_credito"
        Me.txt_total_nota_debito_credito.ReadOnly = True
        Me.txt_total_nota_debito_credito.Size = New System.Drawing.Size(39, 29)
        Me.txt_total_nota_debito_credito.TabIndex = 314
        Me.txt_total_nota_debito_credito.TabStop = False
        Me.txt_total_nota_debito_credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grilla_inventario
        '
        Me.grilla_inventario.AllowUserToAddRows = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla_inventario.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grilla_inventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla_inventario.DefaultCellStyle = DataGridViewCellStyle6
        Me.grilla_inventario.Location = New System.Drawing.Point(61, 707)
        Me.grilla_inventario.Margin = New System.Windows.Forms.Padding(4)
        Me.grilla_inventario.Name = "grilla_inventario"
        Me.grilla_inventario.ReadOnly = True
        Me.grilla_inventario.Size = New System.Drawing.Size(1260, 125)
        Me.grilla_inventario.TabIndex = 344
        Me.grilla_inventario.TabStop = False
        '
        'Form_caja_diaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1357, 862)
        Me.Controls.Add(Me.grilla_detalle_caja)
        Me.Controls.Add(Me.grilla_inventario)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.txt_total_guia_contado)
        Me.Controls.Add(Me.txt_total_abono_credito)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox_boleta)
        Me.Controls.Add(Me.lbl_mensaje)
        Me.Controls.Add(Me.GroupBox_nd)
        Me.Controls.Add(Me.txt_total_ingresos)
        Me.Controls.Add(Me.txt_total_egresos)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox_nc)
        Me.Controls.Add(Me.GroupBox_abono)
        Me.Controls.Add(Me.GroupBox_guia)
        Me.Controls.Add(Me.GroupBox_factura)
        Me.Controls.Add(Me.txt_total_factura_credito)
        Me.Controls.Add(Me.txt_total_boleta_credito)
        Me.Controls.Add(Me.txt_total_nota_credito_contado)
        Me.Controls.Add(Me.txt_total_abono_contado)
        Me.Controls.Add(Me.txt_total_guia_credito)
        Me.Controls.Add(Me.txt_total_factura_contado)
        Me.Controls.Add(Me.txt_total_boleta_contado)
        Me.Controls.Add(Me.txt_total_nota_debito_contado)
        Me.Controls.Add(Me.txt_total_nota_debito_credito)
        Me.Controls.Add(Me.txt_total_nota_credito_credito)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Form_caja_diaria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CUADRATURA DE CAJA"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox_boleta.ResumeLayout(False)
        Me.GroupBox_boleta.PerformLayout()
        Me.GroupBox_factura.ResumeLayout(False)
        Me.GroupBox_factura.PerformLayout()
        Me.GroupBox_guia.ResumeLayout(False)
        Me.GroupBox_guia.PerformLayout()
        Me.GroupBox_abono.ResumeLayout(False)
        Me.GroupBox_abono.PerformLayout()
        Me.GroupBox_nc.ResumeLayout(False)
        Me.GroupBox_nc.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox_nd.ResumeLayout(False)
        Me.GroupBox_nd.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_detalle_caja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla_inventario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_boleta_minimo As System.Windows.Forms.TextBox
    Friend WithEvents txt_boleta_maximo As System.Windows.Forms.TextBox
    Friend WithEvents txt_factura_minimo As System.Windows.Forms.TextBox
    Friend WithEvents txt_factura_maximo As System.Windows.Forms.TextBox
    Friend WithEvents txt_guia_minimo As System.Windows.Forms.TextBox
    Friend WithEvents txt_guia_maximo As System.Windows.Forms.TextBox
    Friend WithEvents txt_abono_minimo As System.Windows.Forms.TextBox
    Friend WithEvents txt_abono_maximo As System.Windows.Forms.TextBox
    Friend WithEvents txt_nota_credito_minimo As System.Windows.Forms.TextBox
    Friend WithEvents txt_nota_credito_maximo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_fecha_caja_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_total_boleta_contado As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_factura_contado As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_factura_credito As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_guia_credito As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_abono_contado As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_nota_credito_contado As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox_boleta As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox_factura As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox_guia As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox_abono As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox_nc As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_total_contado As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txt_total_boleta_credito As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents txt_total_boleta_contado_millar As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_factura_credito_millar As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_guia_credito_millar As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_abono_contado_millar As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_nota_credito_millar As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_boleta_credito_millar As System.Windows.Forms.TextBox
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents btn_calcular As System.Windows.Forms.Button
    Friend WithEvents txt_total_factura_contado_millar As System.Windows.Forms.TextBox
    Friend WithEvents btn_detalle As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_total_egresos As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_ingresos As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox_nd As System.Windows.Forms.GroupBox
    Friend WithEvents txt_total_nota_debito_millar As System.Windows.Forms.TextBox
    Friend WithEvents txt_nota_debito_minimo As System.Windows.Forms.TextBox
    Friend WithEvents txt_nota_debito_maximo As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txt_total_nota_debito_contado As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_nota_credito_credito As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_nota_credito_credito_millar As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txt_total_nota_debito_credito_millar As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lbl_mensaje As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad_facturas_anuladas As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad_guias_anuladas As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad_abonos_anuladas As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad_notas_credito_anuladas As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad_notas_debito_anuladas As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents txt_cantidad_boletas_anuladas As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txt_total_abono_credito_millar As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txt_total_abono_credito As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_guia_contado As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_guia_contado_millar As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txt_total_credito_millar As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_contado_millar As System.Windows.Forms.TextBox
    Friend WithEvents txt_total_credito As System.Windows.Forms.TextBox
    Friend WithEvents btn_ticket As System.Windows.Forms.Button
    Friend WithEvents btn_mostrar As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Combo_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Combo_caja As System.Windows.Forms.ComboBox
    Friend WithEvents PrintDocument_ticket As System.Drawing.Printing.PrintDocument
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents PrintDocument_carta As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents grilla_detalle_caja As System.Windows.Forms.DataGridView
    Friend WithEvents txt_total_nota_debito_credito As System.Windows.Forms.TextBox
    Friend WithEvents Column3 As DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents grilla_inventario As DataGridView
End Class
