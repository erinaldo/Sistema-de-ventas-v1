<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_impresoras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_impresoras))
        Me.GroupBox_datos = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.combo_impresora_traspaso_sucursal = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Combo_impresora_boletas = New System.Windows.Forms.ComboBox
        Me.Combo_impresora_facturas = New System.Windows.Forms.ComboBox
        Me.Combo_impresora_guias = New System.Windows.Forms.ComboBox
        Me.Combo_impresora_etiquetas_1 = New System.Windows.Forms.ComboBox
        Me.Combo_impresora_etiquetas_2 = New System.Windows.Forms.ComboBox
        Me.Combo_impresora_ticket_1 = New System.Windows.Forms.ComboBox
        Me.Combo_impresora_ticket_2 = New System.Windows.Forms.ComboBox
        Me.combo_impresora_nota_de_credito = New System.Windows.Forms.ComboBox
        Me.combo_impresora_nota_de_debito = New System.Windows.Forms.ComboBox
        Me.combo_impresora_reportes = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.radio_ticket = New System.Windows.Forms.RadioButton
        Me.radio_directa = New System.Windows.Forms.RadioButton
        Me.lbl_cuenta = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_modificar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox
        Me.Check_facturas_electronica = New System.Windows.Forms.CheckBox
        Me.Check_boletas_electronicas = New System.Windows.Forms.CheckBox
        Me.Check_guia_electronica = New System.Windows.Forms.CheckBox
        Me.GroupBox_electronicas = New System.Windows.Forms.GroupBox
        Me.Check_nota_debito_electronica = New System.Windows.Forms.CheckBox
        Me.Check_nota_credito_electronica = New System.Windows.Forms.CheckBox
        Me.txt_impresora_etiquetas_1 = New System.Windows.Forms.NumericUpDown
        Me.txt_impresora_etiquetas_2 = New System.Windows.Forms.NumericUpDown
        Me.GroupBox_datos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_electronicas.SuspendLayout()
        CType(Me.txt_impresora_etiquetas_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_impresora_etiquetas_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox_datos
        '
        Me.GroupBox_datos.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_datos.Controls.Add(Me.txt_impresora_etiquetas_2)
        Me.GroupBox_datos.Controls.Add(Me.txt_impresora_etiquetas_1)
        Me.GroupBox_datos.Controls.Add(Me.Label9)
        Me.GroupBox_datos.Controls.Add(Me.Label8)
        Me.GroupBox_datos.Controls.Add(Me.combo_impresora_traspaso_sucursal)
        Me.GroupBox_datos.Controls.Add(Me.Label7)
        Me.GroupBox_datos.Controls.Add(Me.Combo_impresora_boletas)
        Me.GroupBox_datos.Controls.Add(Me.Combo_impresora_facturas)
        Me.GroupBox_datos.Controls.Add(Me.Combo_impresora_guias)
        Me.GroupBox_datos.Controls.Add(Me.Combo_impresora_etiquetas_1)
        Me.GroupBox_datos.Controls.Add(Me.Combo_impresora_etiquetas_2)
        Me.GroupBox_datos.Controls.Add(Me.Combo_impresora_ticket_1)
        Me.GroupBox_datos.Controls.Add(Me.Combo_impresora_ticket_2)
        Me.GroupBox_datos.Controls.Add(Me.combo_impresora_nota_de_credito)
        Me.GroupBox_datos.Controls.Add(Me.combo_impresora_nota_de_debito)
        Me.GroupBox_datos.Controls.Add(Me.combo_impresora_reportes)
        Me.GroupBox_datos.Controls.Add(Me.Label6)
        Me.GroupBox_datos.Controls.Add(Me.Label5)
        Me.GroupBox_datos.Controls.Add(Me.radio_ticket)
        Me.GroupBox_datos.Controls.Add(Me.radio_directa)
        Me.GroupBox_datos.Controls.Add(Me.lbl_cuenta)
        Me.GroupBox_datos.Controls.Add(Me.Label26)
        Me.GroupBox_datos.Controls.Add(Me.Label21)
        Me.GroupBox_datos.Controls.Add(Me.Label22)
        Me.GroupBox_datos.Controls.Add(Me.Label4)
        Me.GroupBox_datos.Controls.Add(Me.Label3)
        Me.GroupBox_datos.Controls.Add(Me.Label2)
        Me.GroupBox_datos.Controls.Add(Me.Label1)
        Me.GroupBox_datos.Controls.Add(Me.Label25)
        Me.GroupBox_datos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_datos.Location = New System.Drawing.Point(6, 77)
        Me.GroupBox_datos.Name = "GroupBox_datos"
        Me.GroupBox_datos.Size = New System.Drawing.Size(626, 458)
        Me.GroupBox_datos.TabIndex = 2
        Me.GroupBox_datos.TabStop = False
        Me.GroupBox_datos.Text = "IMPRESORAS PARA DOCUMENTOS MANUALES"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 404)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(160, 16)
        Me.Label9.TabIndex = 337
        Me.Label9.Text = "MARGEN ETIQUETAS 2:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 373)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(160, 16)
        Me.Label8.TabIndex = 335
        Me.Label8.Text = "MARGEN ETIQUETAS 1:"
        '
        'combo_impresora_traspaso_sucursal
        '
        Me.combo_impresora_traspaso_sucursal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_impresora_traspaso_sucursal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_impresora_traspaso_sucursal.BackColor = System.Drawing.Color.White
        Me.combo_impresora_traspaso_sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_impresora_traspaso_sucursal.FormattingEnabled = True
        Me.combo_impresora_traspaso_sucursal.Location = New System.Drawing.Point(165, 276)
        Me.combo_impresora_traspaso_sucursal.Name = "combo_impresora_traspaso_sucursal"
        Me.combo_impresora_traspaso_sucursal.Size = New System.Drawing.Size(454, 24)
        Me.combo_impresora_traspaso_sucursal.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(77, 279)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 16)
        Me.Label7.TabIndex = 334
        Me.Label7.Text = "DESPACHO:"
        '
        'Combo_impresora_boletas
        '
        Me.Combo_impresora_boletas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_impresora_boletas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_impresora_boletas.BackColor = System.Drawing.Color.White
        Me.Combo_impresora_boletas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_impresora_boletas.FormattingEnabled = True
        Me.Combo_impresora_boletas.Location = New System.Drawing.Point(165, 21)
        Me.Combo_impresora_boletas.Name = "Combo_impresora_boletas"
        Me.Combo_impresora_boletas.Size = New System.Drawing.Size(454, 24)
        Me.Combo_impresora_boletas.TabIndex = 1
        '
        'Combo_impresora_facturas
        '
        Me.Combo_impresora_facturas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_impresora_facturas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_impresora_facturas.BackColor = System.Drawing.Color.White
        Me.Combo_impresora_facturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_impresora_facturas.FormattingEnabled = True
        Me.Combo_impresora_facturas.Location = New System.Drawing.Point(165, 53)
        Me.Combo_impresora_facturas.Name = "Combo_impresora_facturas"
        Me.Combo_impresora_facturas.Size = New System.Drawing.Size(454, 24)
        Me.Combo_impresora_facturas.TabIndex = 2
        '
        'Combo_impresora_guias
        '
        Me.Combo_impresora_guias.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_impresora_guias.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_impresora_guias.BackColor = System.Drawing.Color.White
        Me.Combo_impresora_guias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_impresora_guias.FormattingEnabled = True
        Me.Combo_impresora_guias.Location = New System.Drawing.Point(165, 85)
        Me.Combo_impresora_guias.Name = "Combo_impresora_guias"
        Me.Combo_impresora_guias.Size = New System.Drawing.Size(454, 24)
        Me.Combo_impresora_guias.TabIndex = 3
        '
        'Combo_impresora_etiquetas_1
        '
        Me.Combo_impresora_etiquetas_1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_impresora_etiquetas_1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_impresora_etiquetas_1.BackColor = System.Drawing.Color.White
        Me.Combo_impresora_etiquetas_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_impresora_etiquetas_1.FormattingEnabled = True
        Me.Combo_impresora_etiquetas_1.Location = New System.Drawing.Point(165, 307)
        Me.Combo_impresora_etiquetas_1.Name = "Combo_impresora_etiquetas_1"
        Me.Combo_impresora_etiquetas_1.Size = New System.Drawing.Size(454, 24)
        Me.Combo_impresora_etiquetas_1.TabIndex = 10
        '
        'Combo_impresora_etiquetas_2
        '
        Me.Combo_impresora_etiquetas_2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_impresora_etiquetas_2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_impresora_etiquetas_2.BackColor = System.Drawing.Color.White
        Me.Combo_impresora_etiquetas_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_impresora_etiquetas_2.FormattingEnabled = True
        Me.Combo_impresora_etiquetas_2.Location = New System.Drawing.Point(165, 339)
        Me.Combo_impresora_etiquetas_2.Name = "Combo_impresora_etiquetas_2"
        Me.Combo_impresora_etiquetas_2.Size = New System.Drawing.Size(454, 24)
        Me.Combo_impresora_etiquetas_2.TabIndex = 11
        '
        'Combo_impresora_ticket_1
        '
        Me.Combo_impresora_ticket_1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_impresora_ticket_1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_impresora_ticket_1.BackColor = System.Drawing.Color.White
        Me.Combo_impresora_ticket_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_impresora_ticket_1.FormattingEnabled = True
        Me.Combo_impresora_ticket_1.Location = New System.Drawing.Point(165, 116)
        Me.Combo_impresora_ticket_1.Name = "Combo_impresora_ticket_1"
        Me.Combo_impresora_ticket_1.Size = New System.Drawing.Size(454, 24)
        Me.Combo_impresora_ticket_1.TabIndex = 4
        '
        'Combo_impresora_ticket_2
        '
        Me.Combo_impresora_ticket_2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_impresora_ticket_2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_impresora_ticket_2.BackColor = System.Drawing.Color.White
        Me.Combo_impresora_ticket_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_impresora_ticket_2.FormattingEnabled = True
        Me.Combo_impresora_ticket_2.Location = New System.Drawing.Point(165, 148)
        Me.Combo_impresora_ticket_2.Name = "Combo_impresora_ticket_2"
        Me.Combo_impresora_ticket_2.Size = New System.Drawing.Size(454, 24)
        Me.Combo_impresora_ticket_2.TabIndex = 5
        '
        'combo_impresora_nota_de_credito
        '
        Me.combo_impresora_nota_de_credito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_impresora_nota_de_credito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_impresora_nota_de_credito.BackColor = System.Drawing.Color.White
        Me.combo_impresora_nota_de_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_impresora_nota_de_credito.FormattingEnabled = True
        Me.combo_impresora_nota_de_credito.Location = New System.Drawing.Point(165, 180)
        Me.combo_impresora_nota_de_credito.Name = "combo_impresora_nota_de_credito"
        Me.combo_impresora_nota_de_credito.Size = New System.Drawing.Size(454, 24)
        Me.combo_impresora_nota_de_credito.TabIndex = 6
        '
        'combo_impresora_nota_de_debito
        '
        Me.combo_impresora_nota_de_debito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_impresora_nota_de_debito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_impresora_nota_de_debito.BackColor = System.Drawing.Color.White
        Me.combo_impresora_nota_de_debito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_impresora_nota_de_debito.FormattingEnabled = True
        Me.combo_impresora_nota_de_debito.Location = New System.Drawing.Point(165, 212)
        Me.combo_impresora_nota_de_debito.Name = "combo_impresora_nota_de_debito"
        Me.combo_impresora_nota_de_debito.Size = New System.Drawing.Size(454, 24)
        Me.combo_impresora_nota_de_debito.TabIndex = 7
        '
        'combo_impresora_reportes
        '
        Me.combo_impresora_reportes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_impresora_reportes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_impresora_reportes.BackColor = System.Drawing.Color.White
        Me.combo_impresora_reportes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_impresora_reportes.FormattingEnabled = True
        Me.combo_impresora_reportes.Location = New System.Drawing.Point(165, 244)
        Me.combo_impresora_reportes.Name = "combo_impresora_reportes"
        Me.combo_impresora_reportes.Size = New System.Drawing.Size(454, 24)
        Me.combo_impresora_reportes.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(95, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 16)
        Me.Label6.TabIndex = 332
        Me.Label6.Text = "TICKET 2:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(65, 342)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 16)
        Me.Label5.TabIndex = 330
        Me.Label5.Text = "ETIQUETAS 2:"
        '
        'radio_ticket
        '
        Me.radio_ticket.AutoSize = True
        Me.radio_ticket.BackColor = System.Drawing.Color.Transparent
        Me.radio_ticket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radio_ticket.Location = New System.Drawing.Point(402, 432)
        Me.radio_ticket.Name = "radio_ticket"
        Me.radio_ticket.Size = New System.Drawing.Size(126, 20)
        Me.radio_ticket.TabIndex = 15
        Me.radio_ticket.Text = "TICKET PREVIO"
        Me.radio_ticket.UseVisualStyleBackColor = False
        '
        'radio_directa
        '
        Me.radio_directa.AutoSize = True
        Me.radio_directa.BackColor = System.Drawing.Color.Transparent
        Me.radio_directa.Checked = True
        Me.radio_directa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radio_directa.Location = New System.Drawing.Point(166, 432)
        Me.radio_directa.Name = "radio_directa"
        Me.radio_directa.Size = New System.Drawing.Size(162, 20)
        Me.radio_directa.TabIndex = 14
        Me.radio_directa.TabStop = True
        Me.radio_directa.Text = "IMPRESION DIRECTA"
        Me.radio_directa.UseVisualStyleBackColor = False
        '
        'lbl_cuenta
        '
        Me.lbl_cuenta.AutoSize = True
        Me.lbl_cuenta.BackColor = System.Drawing.Color.Transparent
        Me.lbl_cuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cuenta.Location = New System.Drawing.Point(44, 434)
        Me.lbl_cuenta.Name = "lbl_cuenta"
        Me.lbl_cuenta.Size = New System.Drawing.Size(119, 16)
        Me.lbl_cuenta.TabIndex = 326
        Me.lbl_cuenta.Text = "TIPO IMPRESION:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(77, 247)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(86, 16)
        Me.Label26.TabIndex = 323
        Me.Label26.Text = "REPORTES:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(30, 215)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(133, 16)
        Me.Label21.TabIndex = 316
        Me.Label21.Text = "NOTAS DE DEBITO:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(20, 183)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(143, 16)
        Me.Label22.TabIndex = 315
        Me.Label22.Text = "NOTAS DE CREDITO:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(95, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 293
        Me.Label4.Text = "TICKET 1:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(65, 310)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "ETIQUETAS 1:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(111, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 291
        Me.Label2.Text = "GUIAS:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(79, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 16)
        Me.Label1.TabIndex = 290
        Me.Label1.Text = "FACTURAS:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(90, 24)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(73, 16)
        Me.Label25.TabIndex = 289
        Me.Label25.Text = "BOLETAS:"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btn_salir)
        Me.GroupBox2.Controls.Add(Me.btn_cancelar)
        Me.GroupBox2.Controls.Add(Me.btn_modificar)
        Me.GroupBox2.Controls.Add(Me.btn_guardar)
        Me.GroupBox2.Location = New System.Drawing.Point(638, 78)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(128, 457)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.Transparent
        Me.btn_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(17, 377)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 40)
        Me.btn_salir.TabIndex = 11
        Me.btn_salir.Text = "SALIR"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.Transparent
        Me.btn_cancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(17, 266)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(95, 40)
        Me.btn_cancelar.TabIndex = 10
        Me.btn_cancelar.Text = "CANCELAR"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'btn_modificar
        '
        Me.btn_modificar.BackColor = System.Drawing.Color.Transparent
        Me.btn_modificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_modificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_modificar.Image = CType(resources.GetObject("btn_modificar.Image"), System.Drawing.Image)
        Me.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_modificar.Location = New System.Drawing.Point(17, 44)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(95, 40)
        Me.btn_modificar.TabIndex = 0
        Me.btn_modificar.Text = "MODIFICAR"
        Me.btn_modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_modificar.UseVisualStyleBackColor = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.Transparent
        Me.btn_guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.Location = New System.Drawing.Point(17, 155)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(95, 40)
        Me.btn_guardar.TabIndex = 9
        Me.btn_guardar.Text = "GUARDAR"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'PictureBox_logo
        '
        Me.PictureBox_logo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_logo.ErrorImage = Nothing
        Me.PictureBox_logo.Location = New System.Drawing.Point(7, 6)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(300, 70)
        Me.PictureBox_logo.TabIndex = 72
        Me.PictureBox_logo.TabStop = False
        '
        'Check_facturas_electronica
        '
        Me.Check_facturas_electronica.AutoSize = True
        Me.Check_facturas_electronica.BackColor = System.Drawing.Color.Transparent
        Me.Check_facturas_electronica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_facturas_electronica.Location = New System.Drawing.Point(18, 20)
        Me.Check_facturas_electronica.Name = "Check_facturas_electronica"
        Me.Check_facturas_electronica.Size = New System.Drawing.Size(100, 20)
        Me.Check_facturas_electronica.TabIndex = 288
        Me.Check_facturas_electronica.TabStop = False
        Me.Check_facturas_electronica.Text = "FACTURAS"
        Me.Check_facturas_electronica.UseVisualStyleBackColor = False
        '
        'Check_boletas_electronicas
        '
        Me.Check_boletas_electronicas.AutoSize = True
        Me.Check_boletas_electronicas.BackColor = System.Drawing.Color.Transparent
        Me.Check_boletas_electronicas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_boletas_electronicas.Location = New System.Drawing.Point(158, 20)
        Me.Check_boletas_electronicas.Name = "Check_boletas_electronicas"
        Me.Check_boletas_electronicas.Size = New System.Drawing.Size(89, 20)
        Me.Check_boletas_electronicas.TabIndex = 289
        Me.Check_boletas_electronicas.TabStop = False
        Me.Check_boletas_electronicas.Text = "BOLETAS"
        Me.Check_boletas_electronicas.UseVisualStyleBackColor = False
        '
        'Check_guia_electronica
        '
        Me.Check_guia_electronica.AutoSize = True
        Me.Check_guia_electronica.BackColor = System.Drawing.Color.Transparent
        Me.Check_guia_electronica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_guia_electronica.Location = New System.Drawing.Point(287, 20)
        Me.Check_guia_electronica.Name = "Check_guia_electronica"
        Me.Check_guia_electronica.Size = New System.Drawing.Size(68, 20)
        Me.Check_guia_electronica.TabIndex = 290
        Me.Check_guia_electronica.TabStop = False
        Me.Check_guia_electronica.Text = "GUIAS"
        Me.Check_guia_electronica.UseVisualStyleBackColor = False
        '
        'GroupBox_electronicas
        '
        Me.GroupBox_electronicas.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_electronicas.Controls.Add(Me.Check_nota_debito_electronica)
        Me.GroupBox_electronicas.Controls.Add(Me.Check_nota_credito_electronica)
        Me.GroupBox_electronicas.Controls.Add(Me.Check_boletas_electronicas)
        Me.GroupBox_electronicas.Controls.Add(Me.Check_guia_electronica)
        Me.GroupBox_electronicas.Controls.Add(Me.Check_facturas_electronica)
        Me.GroupBox_electronicas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_electronicas.Location = New System.Drawing.Point(6, 535)
        Me.GroupBox_electronicas.Name = "GroupBox_electronicas"
        Me.GroupBox_electronicas.Size = New System.Drawing.Size(760, 50)
        Me.GroupBox_electronicas.TabIndex = 68
        Me.GroupBox_electronicas.TabStop = False
        Me.GroupBox_electronicas.Text = "DESHABILITAR IMPRESIONES MANUALES"
        '
        'Check_nota_debito_electronica
        '
        Me.Check_nota_debito_electronica.AutoSize = True
        Me.Check_nota_debito_electronica.BackColor = System.Drawing.Color.Transparent
        Me.Check_nota_debito_electronica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_nota_debito_electronica.Location = New System.Drawing.Point(594, 20)
        Me.Check_nota_debito_electronica.Name = "Check_nota_debito_electronica"
        Me.Check_nota_debito_electronica.Size = New System.Drawing.Size(149, 20)
        Me.Check_nota_debito_electronica.TabIndex = 292
        Me.Check_nota_debito_electronica.TabStop = False
        Me.Check_nota_debito_electronica.Text = "NOTAS DE DEBITO"
        Me.Check_nota_debito_electronica.UseVisualStyleBackColor = False
        '
        'Check_nota_credito_electronica
        '
        Me.Check_nota_credito_electronica.AutoSize = True
        Me.Check_nota_credito_electronica.BackColor = System.Drawing.Color.Transparent
        Me.Check_nota_credito_electronica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_nota_credito_electronica.Location = New System.Drawing.Point(395, 20)
        Me.Check_nota_credito_electronica.Name = "Check_nota_credito_electronica"
        Me.Check_nota_credito_electronica.Size = New System.Drawing.Size(159, 20)
        Me.Check_nota_credito_electronica.TabIndex = 291
        Me.Check_nota_credito_electronica.TabStop = False
        Me.Check_nota_credito_electronica.Text = "NOTAS DE CREDITO"
        Me.Check_nota_credito_electronica.UseVisualStyleBackColor = False
        '
        'txt_impresora_etiquetas_1
        '
        Me.txt_impresora_etiquetas_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_impresora_etiquetas_1.Location = New System.Drawing.Point(165, 371)
        Me.txt_impresora_etiquetas_1.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_impresora_etiquetas_1.Name = "txt_impresora_etiquetas_1"
        Me.txt_impresora_etiquetas_1.Size = New System.Drawing.Size(84, 24)
        Me.txt_impresora_etiquetas_1.TabIndex = 12
        '
        'txt_impresora_etiquetas_2
        '
        Me.txt_impresora_etiquetas_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_impresora_etiquetas_2.Location = New System.Drawing.Point(165, 402)
        Me.txt_impresora_etiquetas_2.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_impresora_etiquetas_2.Name = "txt_impresora_etiquetas_2"
        Me.txt_impresora_etiquetas_2.Size = New System.Drawing.Size(84, 24)
        Me.txt_impresora_etiquetas_2.TabIndex = 13
        '
        'Form_impresoras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 591)
        Me.Controls.Add(Me.GroupBox_electronicas)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox_datos)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form_impresoras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IMPRESORAS"
        Me.GroupBox_datos.ResumeLayout(False)
        Me.GroupBox_datos.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_electronicas.ResumeLayout(False)
        Me.GroupBox_electronicas.PerformLayout()
        CType(Me.txt_impresora_etiquetas_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_impresora_etiquetas_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox_datos As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_modificar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents Check_facturas_electronica As System.Windows.Forms.CheckBox
    Friend WithEvents Check_boletas_electronicas As System.Windows.Forms.CheckBox
    Friend WithEvents Check_guia_electronica As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox_electronicas As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Check_nota_debito_electronica As System.Windows.Forms.CheckBox
    Friend WithEvents Check_nota_credito_electronica As System.Windows.Forms.CheckBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents radio_ticket As System.Windows.Forms.RadioButton
    Friend WithEvents radio_directa As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_cuenta As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents combo_impresora_reportes As System.Windows.Forms.ComboBox
    Friend WithEvents combo_impresora_nota_de_debito As System.Windows.Forms.ComboBox
    Friend WithEvents combo_impresora_nota_de_credito As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_impresora_ticket_2 As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_impresora_ticket_1 As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_impresora_etiquetas_2 As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_impresora_etiquetas_1 As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_impresora_guias As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_impresora_facturas As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_impresora_boletas As System.Windows.Forms.ComboBox
    Friend WithEvents combo_impresora_traspaso_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_impresora_etiquetas_2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txt_impresora_etiquetas_1 As System.Windows.Forms.NumericUpDown
End Class
