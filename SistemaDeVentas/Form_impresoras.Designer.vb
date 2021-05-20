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
        Me.GroupBox_datos = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Combo_tipo_impresion_notas_de_debito = New System.Windows.Forms.ComboBox()
        Me.Combo_tipo_impresion_notas_de_credito = New System.Windows.Forms.ComboBox()
        Me.Combo_tipo_impresion_guias = New System.Windows.Forms.ComboBox()
        Me.Combo_tipo_impresion_facturas = New System.Windows.Forms.ComboBox()
        Me.Combo_tipo_impresion_boletas = New System.Windows.Forms.ComboBox()
        Me.txt_margen_consumo_interno = New System.Windows.Forms.NumericUpDown()
        Me.combo_impresora_consumo_interno = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txt_margen_ticket_de_cheques = New System.Windows.Forms.NumericUpDown()
        Me.Combo_impresora_boletas = New System.Windows.Forms.ComboBox()
        Me.combo_impresora_registro_cheques = New System.Windows.Forms.ComboBox()
        Me.txt_margen_ticket_de_ventas = New System.Windows.Forms.NumericUpDown()
        Me.combo_impresora_ticket_de_ventas = New System.Windows.Forms.ComboBox()
        Me.txt_margen_estado_de_cuenta = New System.Windows.Forms.NumericUpDown()
        Me.radio_directa = New System.Windows.Forms.RadioButton()
        Me.combo_impresora_estados_de_cuenta = New System.Windows.Forms.ComboBox()
        Me.radio_ticket = New System.Windows.Forms.RadioButton()
        Me.txt_margen_caja = New System.Windows.Forms.NumericUpDown()
        Me.Combo_impresora_etiquetas_2 = New System.Windows.Forms.ComboBox()
        Me.combo_impresora_caja = New System.Windows.Forms.ComboBox()
        Me.Combo_impresora_etiquetas_1 = New System.Windows.Forms.ComboBox()
        Me.Combo_impresora_guias = New System.Windows.Forms.ComboBox()
        Me.txt_margen_pedidos = New System.Windows.Forms.NumericUpDown()
        Me.Combo_impresora_facturas = New System.Windows.Forms.ComboBox()
        Me.Combo_impresora_pedidos = New System.Windows.Forms.ComboBox()
        Me.txt_margen_etiquetas_1 = New System.Windows.Forms.NumericUpDown()
        Me.txt_margen_etiquetas_2 = New System.Windows.Forms.NumericUpDown()
        Me.txt_margen_vales_de_cambio = New System.Windows.Forms.NumericUpDown()
        Me.txt_margen_anticipos = New System.Windows.Forms.NumericUpDown()
        Me.combo_impresora_cotizaciones = New System.Windows.Forms.ComboBox()
        Me.txt_margen_tarjeta_rapida = New System.Windows.Forms.NumericUpDown()
        Me.txt_margen_envios_a_sucursal = New System.Windows.Forms.NumericUpDown()
        Me.combo_impresora_abonos = New System.Windows.Forms.ComboBox()
        Me.txt_margen_abonos = New System.Windows.Forms.NumericUpDown()
        Me.txt_margen_facturas = New System.Windows.Forms.NumericUpDown()
        Me.combo_impresora_vales_de_cambio = New System.Windows.Forms.ComboBox()
        Me.txt_margen_cotizaciones = New System.Windows.Forms.NumericUpDown()
        Me.txt_margen_nb = New System.Windows.Forms.NumericUpDown()
        Me.combo_impresora_envio_sucursal = New System.Windows.Forms.ComboBox()
        Me.txt_margen_nc = New System.Windows.Forms.NumericUpDown()
        Me.txt_margen_guias = New System.Windows.Forms.NumericUpDown()
        Me.txt_margen_boletas = New System.Windows.Forms.NumericUpDown()
        Me.combo_impresora_nota_de_debito = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.combo_impresora_nota_de_credito = New System.Windows.Forms.ComboBox()
        Me.combo_impresora_anticipos = New System.Windows.Forms.ComboBox()
        Me.combo_impresora_tarjeta_rapida = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbl_cuenta = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_modificar = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.Check_facturas_electronica = New System.Windows.Forms.CheckBox()
        Me.Check_boletas_electronicas = New System.Windows.Forms.CheckBox()
        Me.Check_guia_electronica = New System.Windows.Forms.CheckBox()
        Me.GroupBox_electronicas = New System.Windows.Forms.GroupBox()
        Me.Check_nota_debito_electronica = New System.Windows.Forms.CheckBox()
        Me.Check_nota_credito_electronica = New System.Windows.Forms.CheckBox()
        Me.GroupBox_datos.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txt_margen_consumo_interno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_margen_ticket_de_cheques, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_margen_ticket_de_ventas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_margen_estado_de_cuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_margen_caja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_margen_pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_margen_etiquetas_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_margen_etiquetas_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_margen_vales_de_cambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_margen_anticipos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_margen_tarjeta_rapida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_margen_envios_a_sucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_margen_abonos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_margen_facturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_margen_cotizaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_margen_nb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_margen_nc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_margen_guias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_margen_boletas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_electronicas.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox_datos
        '
        Me.GroupBox_datos.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox_datos.Controls.Add(Me.Panel1)
        Me.GroupBox_datos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_datos.Location = New System.Drawing.Point(8, 95)
        Me.GroupBox_datos.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_datos.Name = "GroupBox_datos"
        Me.GroupBox_datos.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_datos.Size = New System.Drawing.Size(880, 621)
        Me.GroupBox_datos.TabIndex = 2
        Me.GroupBox_datos.TabStop = False
        Me.GroupBox_datos.Text = "CONFIGURACION DE IMPRESION"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Combo_tipo_impresion_notas_de_debito)
        Me.Panel1.Controls.Add(Me.Combo_tipo_impresion_notas_de_credito)
        Me.Panel1.Controls.Add(Me.Combo_tipo_impresion_guias)
        Me.Panel1.Controls.Add(Me.Combo_tipo_impresion_facturas)
        Me.Panel1.Controls.Add(Me.Combo_tipo_impresion_boletas)
        Me.Panel1.Controls.Add(Me.txt_margen_consumo_interno)
        Me.Panel1.Controls.Add(Me.combo_impresora_consumo_interno)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.txt_margen_ticket_de_cheques)
        Me.Panel1.Controls.Add(Me.Combo_impresora_boletas)
        Me.Panel1.Controls.Add(Me.combo_impresora_registro_cheques)
        Me.Panel1.Controls.Add(Me.txt_margen_ticket_de_ventas)
        Me.Panel1.Controls.Add(Me.combo_impresora_ticket_de_ventas)
        Me.Panel1.Controls.Add(Me.txt_margen_estado_de_cuenta)
        Me.Panel1.Controls.Add(Me.radio_directa)
        Me.Panel1.Controls.Add(Me.combo_impresora_estados_de_cuenta)
        Me.Panel1.Controls.Add(Me.radio_ticket)
        Me.Panel1.Controls.Add(Me.txt_margen_caja)
        Me.Panel1.Controls.Add(Me.Combo_impresora_etiquetas_2)
        Me.Panel1.Controls.Add(Me.combo_impresora_caja)
        Me.Panel1.Controls.Add(Me.Combo_impresora_etiquetas_1)
        Me.Panel1.Controls.Add(Me.Combo_impresora_guias)
        Me.Panel1.Controls.Add(Me.txt_margen_pedidos)
        Me.Panel1.Controls.Add(Me.Combo_impresora_facturas)
        Me.Panel1.Controls.Add(Me.Combo_impresora_pedidos)
        Me.Panel1.Controls.Add(Me.txt_margen_etiquetas_1)
        Me.Panel1.Controls.Add(Me.txt_margen_etiquetas_2)
        Me.Panel1.Controls.Add(Me.txt_margen_vales_de_cambio)
        Me.Panel1.Controls.Add(Me.txt_margen_anticipos)
        Me.Panel1.Controls.Add(Me.combo_impresora_cotizaciones)
        Me.Panel1.Controls.Add(Me.txt_margen_tarjeta_rapida)
        Me.Panel1.Controls.Add(Me.txt_margen_envios_a_sucursal)
        Me.Panel1.Controls.Add(Me.combo_impresora_abonos)
        Me.Panel1.Controls.Add(Me.txt_margen_abonos)
        Me.Panel1.Controls.Add(Me.txt_margen_facturas)
        Me.Panel1.Controls.Add(Me.combo_impresora_vales_de_cambio)
        Me.Panel1.Controls.Add(Me.txt_margen_cotizaciones)
        Me.Panel1.Controls.Add(Me.txt_margen_nb)
        Me.Panel1.Controls.Add(Me.combo_impresora_envio_sucursal)
        Me.Panel1.Controls.Add(Me.txt_margen_nc)
        Me.Panel1.Controls.Add(Me.txt_margen_guias)
        Me.Panel1.Controls.Add(Me.txt_margen_boletas)
        Me.Panel1.Controls.Add(Me.combo_impresora_nota_de_debito)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.combo_impresora_nota_de_credito)
        Me.Panel1.Controls.Add(Me.combo_impresora_anticipos)
        Me.Panel1.Controls.Add(Me.combo_impresora_tarjeta_rapida)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.lbl_cuenta)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Location = New System.Drawing.Point(4, 17)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(873, 599)
        Me.Panel1.TabIndex = 73
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(222, 1)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(113, 20)
        Me.Label19.TabIndex = 392
        Me.Label19.Text = "IMPRESORA:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(572, 1)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(149, 20)
        Me.Label18.TabIndex = 391
        Me.Label18.Text = "TIPO IMPRESION:"
        '
        'Combo_tipo_impresion_notas_de_debito
        '
        Me.Combo_tipo_impresion_notas_de_debito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_tipo_impresion_notas_de_debito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_tipo_impresion_notas_de_debito.BackColor = System.Drawing.Color.White
        Me.Combo_tipo_impresion_notas_de_debito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_tipo_impresion_notas_de_debito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_tipo_impresion_notas_de_debito.FormattingEnabled = True
        Me.Combo_tipo_impresion_notas_de_debito.Items.AddRange(New Object() {"ELECTRONICA", "INTERNA", "MANUAL", "SIN IMPRESION"})
        Me.Combo_tipo_impresion_notas_de_debito.Location = New System.Drawing.Point(576, 171)
        Me.Combo_tipo_impresion_notas_de_debito.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_tipo_impresion_notas_de_debito.Name = "Combo_tipo_impresion_notas_de_debito"
        Me.Combo_tipo_impresion_notas_de_debito.Size = New System.Drawing.Size(160, 28)
        Me.Combo_tipo_impresion_notas_de_debito.TabIndex = 390
        Me.Combo_tipo_impresion_notas_de_debito.TabStop = False
        '
        'Combo_tipo_impresion_notas_de_credito
        '
        Me.Combo_tipo_impresion_notas_de_credito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_tipo_impresion_notas_de_credito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_tipo_impresion_notas_de_credito.BackColor = System.Drawing.Color.White
        Me.Combo_tipo_impresion_notas_de_credito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_tipo_impresion_notas_de_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_tipo_impresion_notas_de_credito.FormattingEnabled = True
        Me.Combo_tipo_impresion_notas_de_credito.Items.AddRange(New Object() {"ELECTRONICA", "INTERNA", "MANUAL", "SIN IMPRESION"})
        Me.Combo_tipo_impresion_notas_de_credito.Location = New System.Drawing.Point(576, 134)
        Me.Combo_tipo_impresion_notas_de_credito.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_tipo_impresion_notas_de_credito.Name = "Combo_tipo_impresion_notas_de_credito"
        Me.Combo_tipo_impresion_notas_de_credito.Size = New System.Drawing.Size(160, 28)
        Me.Combo_tipo_impresion_notas_de_credito.TabIndex = 389
        Me.Combo_tipo_impresion_notas_de_credito.TabStop = False
        '
        'Combo_tipo_impresion_guias
        '
        Me.Combo_tipo_impresion_guias.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_tipo_impresion_guias.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_tipo_impresion_guias.BackColor = System.Drawing.Color.White
        Me.Combo_tipo_impresion_guias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_tipo_impresion_guias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_tipo_impresion_guias.FormattingEnabled = True
        Me.Combo_tipo_impresion_guias.Items.AddRange(New Object() {"ELECTRONICA", "INTERNA", "MANUAL", "SIN IMPRESION"})
        Me.Combo_tipo_impresion_guias.Location = New System.Drawing.Point(576, 97)
        Me.Combo_tipo_impresion_guias.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_tipo_impresion_guias.Name = "Combo_tipo_impresion_guias"
        Me.Combo_tipo_impresion_guias.Size = New System.Drawing.Size(160, 28)
        Me.Combo_tipo_impresion_guias.TabIndex = 388
        Me.Combo_tipo_impresion_guias.TabStop = False
        '
        'Combo_tipo_impresion_facturas
        '
        Me.Combo_tipo_impresion_facturas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_tipo_impresion_facturas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_tipo_impresion_facturas.BackColor = System.Drawing.Color.White
        Me.Combo_tipo_impresion_facturas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_tipo_impresion_facturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_tipo_impresion_facturas.FormattingEnabled = True
        Me.Combo_tipo_impresion_facturas.Items.AddRange(New Object() {"ELECTRONICA", "INTERNA", "MANUAL", "SIN IMPRESION"})
        Me.Combo_tipo_impresion_facturas.Location = New System.Drawing.Point(576, 60)
        Me.Combo_tipo_impresion_facturas.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_tipo_impresion_facturas.Name = "Combo_tipo_impresion_facturas"
        Me.Combo_tipo_impresion_facturas.Size = New System.Drawing.Size(160, 28)
        Me.Combo_tipo_impresion_facturas.TabIndex = 387
        Me.Combo_tipo_impresion_facturas.TabStop = False
        '
        'Combo_tipo_impresion_boletas
        '
        Me.Combo_tipo_impresion_boletas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_tipo_impresion_boletas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_tipo_impresion_boletas.BackColor = System.Drawing.Color.White
        Me.Combo_tipo_impresion_boletas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo_tipo_impresion_boletas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_tipo_impresion_boletas.FormattingEnabled = True
        Me.Combo_tipo_impresion_boletas.Items.AddRange(New Object() {"ELECTRONICA", "INTERNA", "MANUAL", "SIN IMPRESION"})
        Me.Combo_tipo_impresion_boletas.Location = New System.Drawing.Point(576, 23)
        Me.Combo_tipo_impresion_boletas.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_tipo_impresion_boletas.Name = "Combo_tipo_impresion_boletas"
        Me.Combo_tipo_impresion_boletas.Size = New System.Drawing.Size(160, 28)
        Me.Combo_tipo_impresion_boletas.TabIndex = 386
        Me.Combo_tipo_impresion_boletas.TabStop = False
        '
        'txt_margen_consumo_interno
        '
        Me.txt_margen_consumo_interno.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_margen_consumo_interno.Location = New System.Drawing.Point(744, 615)
        Me.txt_margen_consumo_interno.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_margen_consumo_interno.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_margen_consumo_interno.Name = "txt_margen_consumo_interno"
        Me.txt_margen_consumo_interno.Size = New System.Drawing.Size(100, 29)
        Me.txt_margen_consumo_interno.TabIndex = 385
        Me.txt_margen_consumo_interno.TabStop = False
        '
        'combo_impresora_consumo_interno
        '
        Me.combo_impresora_consumo_interno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_impresora_consumo_interno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_impresora_consumo_interno.BackColor = System.Drawing.Color.White
        Me.combo_impresora_consumo_interno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_impresora_consumo_interno.FormattingEnabled = True
        Me.combo_impresora_consumo_interno.Location = New System.Drawing.Point(226, 615)
        Me.combo_impresora_consumo_interno.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_impresora_consumo_interno.Name = "combo_impresora_consumo_interno"
        Me.combo_impresora_consumo_interno.Size = New System.Drawing.Size(510, 28)
        Me.combo_impresora_consumo_interno.TabIndex = 17
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(3, 618)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(220, 20)
        Me.Label17.TabIndex = 384
        Me.Label17.Text = "CONSUMO INTERNO:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_margen_ticket_de_cheques
        '
        Me.txt_margen_ticket_de_cheques.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_margen_ticket_de_cheques.Location = New System.Drawing.Point(744, 578)
        Me.txt_margen_ticket_de_cheques.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_margen_ticket_de_cheques.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_margen_ticket_de_cheques.Name = "txt_margen_ticket_de_cheques"
        Me.txt_margen_ticket_de_cheques.Size = New System.Drawing.Size(100, 29)
        Me.txt_margen_ticket_de_cheques.TabIndex = 382
        Me.txt_margen_ticket_de_cheques.TabStop = False
        '
        'Combo_impresora_boletas
        '
        Me.Combo_impresora_boletas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_impresora_boletas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_impresora_boletas.BackColor = System.Drawing.Color.White
        Me.Combo_impresora_boletas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_impresora_boletas.FormattingEnabled = True
        Me.Combo_impresora_boletas.Location = New System.Drawing.Point(226, 23)
        Me.Combo_impresora_boletas.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_impresora_boletas.Name = "Combo_impresora_boletas"
        Me.Combo_impresora_boletas.Size = New System.Drawing.Size(342, 28)
        Me.Combo_impresora_boletas.TabIndex = 1
        '
        'combo_impresora_registro_cheques
        '
        Me.combo_impresora_registro_cheques.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_impresora_registro_cheques.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_impresora_registro_cheques.BackColor = System.Drawing.Color.White
        Me.combo_impresora_registro_cheques.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_impresora_registro_cheques.FormattingEnabled = True
        Me.combo_impresora_registro_cheques.Location = New System.Drawing.Point(226, 578)
        Me.combo_impresora_registro_cheques.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_impresora_registro_cheques.Name = "combo_impresora_registro_cheques"
        Me.combo_impresora_registro_cheques.Size = New System.Drawing.Size(510, 28)
        Me.combo_impresora_registro_cheques.TabIndex = 16
        '
        'txt_margen_ticket_de_ventas
        '
        Me.txt_margen_ticket_de_ventas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_margen_ticket_de_ventas.Location = New System.Drawing.Point(744, 393)
        Me.txt_margen_ticket_de_ventas.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_margen_ticket_de_ventas.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_margen_ticket_de_ventas.Name = "txt_margen_ticket_de_ventas"
        Me.txt_margen_ticket_de_ventas.Size = New System.Drawing.Size(100, 29)
        Me.txt_margen_ticket_de_ventas.TabIndex = 379
        Me.txt_margen_ticket_de_ventas.TabStop = False
        '
        'combo_impresora_ticket_de_ventas
        '
        Me.combo_impresora_ticket_de_ventas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_impresora_ticket_de_ventas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_impresora_ticket_de_ventas.BackColor = System.Drawing.Color.White
        Me.combo_impresora_ticket_de_ventas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_impresora_ticket_de_ventas.FormattingEnabled = True
        Me.combo_impresora_ticket_de_ventas.Location = New System.Drawing.Point(226, 393)
        Me.combo_impresora_ticket_de_ventas.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_impresora_ticket_de_ventas.Name = "combo_impresora_ticket_de_ventas"
        Me.combo_impresora_ticket_de_ventas.Size = New System.Drawing.Size(510, 28)
        Me.combo_impresora_ticket_de_ventas.TabIndex = 11
        '
        'txt_margen_estado_de_cuenta
        '
        Me.txt_margen_estado_de_cuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_margen_estado_de_cuenta.Location = New System.Drawing.Point(744, 356)
        Me.txt_margen_estado_de_cuenta.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_margen_estado_de_cuenta.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_margen_estado_de_cuenta.Name = "txt_margen_estado_de_cuenta"
        Me.txt_margen_estado_de_cuenta.Size = New System.Drawing.Size(100, 29)
        Me.txt_margen_estado_de_cuenta.TabIndex = 376
        Me.txt_margen_estado_de_cuenta.TabStop = False
        '
        'radio_directa
        '
        Me.radio_directa.AutoSize = True
        Me.radio_directa.BackColor = System.Drawing.Color.Transparent
        Me.radio_directa.Checked = True
        Me.radio_directa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radio_directa.Location = New System.Drawing.Point(227, 727)
        Me.radio_directa.Margin = New System.Windows.Forms.Padding(4)
        Me.radio_directa.Name = "radio_directa"
        Me.radio_directa.Size = New System.Drawing.Size(200, 24)
        Me.radio_directa.TabIndex = 19
        Me.radio_directa.TabStop = True
        Me.radio_directa.Text = "IMPRESION DIRECTA"
        Me.radio_directa.UseVisualStyleBackColor = False
        '
        'combo_impresora_estados_de_cuenta
        '
        Me.combo_impresora_estados_de_cuenta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_impresora_estados_de_cuenta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_impresora_estados_de_cuenta.BackColor = System.Drawing.Color.White
        Me.combo_impresora_estados_de_cuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_impresora_estados_de_cuenta.FormattingEnabled = True
        Me.combo_impresora_estados_de_cuenta.Location = New System.Drawing.Point(226, 356)
        Me.combo_impresora_estados_de_cuenta.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_impresora_estados_de_cuenta.Name = "combo_impresora_estados_de_cuenta"
        Me.combo_impresora_estados_de_cuenta.Size = New System.Drawing.Size(510, 28)
        Me.combo_impresora_estados_de_cuenta.TabIndex = 10
        '
        'radio_ticket
        '
        Me.radio_ticket.AutoSize = True
        Me.radio_ticket.BackColor = System.Drawing.Color.Transparent
        Me.radio_ticket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radio_ticket.Location = New System.Drawing.Point(452, 727)
        Me.radio_ticket.Margin = New System.Windows.Forms.Padding(4)
        Me.radio_ticket.Name = "radio_ticket"
        Me.radio_ticket.Size = New System.Drawing.Size(155, 24)
        Me.radio_ticket.TabIndex = 20
        Me.radio_ticket.Text = "TICKET PREVIO"
        Me.radio_ticket.UseVisualStyleBackColor = False
        '
        'txt_margen_caja
        '
        Me.txt_margen_caja.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_margen_caja.Location = New System.Drawing.Point(744, 319)
        Me.txt_margen_caja.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_margen_caja.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_margen_caja.Name = "txt_margen_caja"
        Me.txt_margen_caja.Size = New System.Drawing.Size(100, 29)
        Me.txt_margen_caja.TabIndex = 373
        Me.txt_margen_caja.TabStop = False
        '
        'Combo_impresora_etiquetas_2
        '
        Me.Combo_impresora_etiquetas_2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_impresora_etiquetas_2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_impresora_etiquetas_2.BackColor = System.Drawing.Color.White
        Me.Combo_impresora_etiquetas_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_impresora_etiquetas_2.FormattingEnabled = True
        Me.Combo_impresora_etiquetas_2.Location = New System.Drawing.Point(226, 689)
        Me.Combo_impresora_etiquetas_2.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_impresora_etiquetas_2.Name = "Combo_impresora_etiquetas_2"
        Me.Combo_impresora_etiquetas_2.Size = New System.Drawing.Size(510, 28)
        Me.Combo_impresora_etiquetas_2.TabIndex = 19
        '
        'combo_impresora_caja
        '
        Me.combo_impresora_caja.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_impresora_caja.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_impresora_caja.BackColor = System.Drawing.Color.White
        Me.combo_impresora_caja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_impresora_caja.FormattingEnabled = True
        Me.combo_impresora_caja.Location = New System.Drawing.Point(226, 319)
        Me.combo_impresora_caja.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_impresora_caja.Name = "combo_impresora_caja"
        Me.combo_impresora_caja.Size = New System.Drawing.Size(510, 28)
        Me.combo_impresora_caja.TabIndex = 9
        '
        'Combo_impresora_etiquetas_1
        '
        Me.Combo_impresora_etiquetas_1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_impresora_etiquetas_1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_impresora_etiquetas_1.BackColor = System.Drawing.Color.White
        Me.Combo_impresora_etiquetas_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_impresora_etiquetas_1.FormattingEnabled = True
        Me.Combo_impresora_etiquetas_1.Location = New System.Drawing.Point(226, 652)
        Me.Combo_impresora_etiquetas_1.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_impresora_etiquetas_1.Name = "Combo_impresora_etiquetas_1"
        Me.Combo_impresora_etiquetas_1.Size = New System.Drawing.Size(510, 28)
        Me.Combo_impresora_etiquetas_1.TabIndex = 18
        '
        'Combo_impresora_guias
        '
        Me.Combo_impresora_guias.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_impresora_guias.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_impresora_guias.BackColor = System.Drawing.Color.White
        Me.Combo_impresora_guias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_impresora_guias.FormattingEnabled = True
        Me.Combo_impresora_guias.Location = New System.Drawing.Point(226, 97)
        Me.Combo_impresora_guias.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_impresora_guias.Name = "Combo_impresora_guias"
        Me.Combo_impresora_guias.Size = New System.Drawing.Size(342, 28)
        Me.Combo_impresora_guias.TabIndex = 3
        '
        'txt_margen_pedidos
        '
        Me.txt_margen_pedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_margen_pedidos.Location = New System.Drawing.Point(744, 541)
        Me.txt_margen_pedidos.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_margen_pedidos.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_margen_pedidos.Name = "txt_margen_pedidos"
        Me.txt_margen_pedidos.Size = New System.Drawing.Size(100, 29)
        Me.txt_margen_pedidos.TabIndex = 370
        Me.txt_margen_pedidos.TabStop = False
        '
        'Combo_impresora_facturas
        '
        Me.Combo_impresora_facturas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_impresora_facturas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_impresora_facturas.BackColor = System.Drawing.Color.White
        Me.Combo_impresora_facturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_impresora_facturas.FormattingEnabled = True
        Me.Combo_impresora_facturas.Location = New System.Drawing.Point(226, 60)
        Me.Combo_impresora_facturas.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_impresora_facturas.Name = "Combo_impresora_facturas"
        Me.Combo_impresora_facturas.Size = New System.Drawing.Size(342, 28)
        Me.Combo_impresora_facturas.TabIndex = 2
        '
        'Combo_impresora_pedidos
        '
        Me.Combo_impresora_pedidos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Combo_impresora_pedidos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo_impresora_pedidos.BackColor = System.Drawing.Color.White
        Me.Combo_impresora_pedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_impresora_pedidos.FormattingEnabled = True
        Me.Combo_impresora_pedidos.Location = New System.Drawing.Point(226, 541)
        Me.Combo_impresora_pedidos.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_impresora_pedidos.Name = "Combo_impresora_pedidos"
        Me.Combo_impresora_pedidos.Size = New System.Drawing.Size(510, 28)
        Me.Combo_impresora_pedidos.TabIndex = 15
        '
        'txt_margen_etiquetas_1
        '
        Me.txt_margen_etiquetas_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_margen_etiquetas_1.Location = New System.Drawing.Point(744, 652)
        Me.txt_margen_etiquetas_1.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_margen_etiquetas_1.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_margen_etiquetas_1.Name = "txt_margen_etiquetas_1"
        Me.txt_margen_etiquetas_1.Size = New System.Drawing.Size(100, 29)
        Me.txt_margen_etiquetas_1.TabIndex = 12
        Me.txt_margen_etiquetas_1.TabStop = False
        '
        'txt_margen_etiquetas_2
        '
        Me.txt_margen_etiquetas_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_margen_etiquetas_2.Location = New System.Drawing.Point(744, 689)
        Me.txt_margen_etiquetas_2.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_margen_etiquetas_2.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_margen_etiquetas_2.Name = "txt_margen_etiquetas_2"
        Me.txt_margen_etiquetas_2.Size = New System.Drawing.Size(100, 29)
        Me.txt_margen_etiquetas_2.TabIndex = 13
        Me.txt_margen_etiquetas_2.TabStop = False
        '
        'txt_margen_vales_de_cambio
        '
        Me.txt_margen_vales_de_cambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_margen_vales_de_cambio.Location = New System.Drawing.Point(744, 467)
        Me.txt_margen_vales_de_cambio.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_margen_vales_de_cambio.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_margen_vales_de_cambio.Name = "txt_margen_vales_de_cambio"
        Me.txt_margen_vales_de_cambio.Size = New System.Drawing.Size(100, 29)
        Me.txt_margen_vales_de_cambio.TabIndex = 367
        Me.txt_margen_vales_de_cambio.TabStop = False
        '
        'txt_margen_anticipos
        '
        Me.txt_margen_anticipos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_margen_anticipos.Location = New System.Drawing.Point(744, 282)
        Me.txt_margen_anticipos.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_margen_anticipos.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_margen_anticipos.Name = "txt_margen_anticipos"
        Me.txt_margen_anticipos.Size = New System.Drawing.Size(100, 29)
        Me.txt_margen_anticipos.TabIndex = 365
        Me.txt_margen_anticipos.TabStop = False
        '
        'combo_impresora_cotizaciones
        '
        Me.combo_impresora_cotizaciones.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_impresora_cotizaciones.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_impresora_cotizaciones.BackColor = System.Drawing.Color.White
        Me.combo_impresora_cotizaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_impresora_cotizaciones.FormattingEnabled = True
        Me.combo_impresora_cotizaciones.Location = New System.Drawing.Point(226, 208)
        Me.combo_impresora_cotizaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_impresora_cotizaciones.Name = "combo_impresora_cotizaciones"
        Me.combo_impresora_cotizaciones.Size = New System.Drawing.Size(510, 28)
        Me.combo_impresora_cotizaciones.TabIndex = 6
        '
        'txt_margen_tarjeta_rapida
        '
        Me.txt_margen_tarjeta_rapida.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_margen_tarjeta_rapida.Location = New System.Drawing.Point(744, 504)
        Me.txt_margen_tarjeta_rapida.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_margen_tarjeta_rapida.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_margen_tarjeta_rapida.Name = "txt_margen_tarjeta_rapida"
        Me.txt_margen_tarjeta_rapida.Size = New System.Drawing.Size(100, 29)
        Me.txt_margen_tarjeta_rapida.TabIndex = 364
        Me.txt_margen_tarjeta_rapida.TabStop = False
        '
        'txt_margen_envios_a_sucursal
        '
        Me.txt_margen_envios_a_sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_margen_envios_a_sucursal.Location = New System.Drawing.Point(744, 430)
        Me.txt_margen_envios_a_sucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_margen_envios_a_sucursal.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_margen_envios_a_sucursal.Name = "txt_margen_envios_a_sucursal"
        Me.txt_margen_envios_a_sucursal.Size = New System.Drawing.Size(100, 29)
        Me.txt_margen_envios_a_sucursal.TabIndex = 363
        Me.txt_margen_envios_a_sucursal.TabStop = False
        '
        'combo_impresora_abonos
        '
        Me.combo_impresora_abonos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_impresora_abonos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_impresora_abonos.BackColor = System.Drawing.Color.White
        Me.combo_impresora_abonos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_impresora_abonos.FormattingEnabled = True
        Me.combo_impresora_abonos.Location = New System.Drawing.Point(226, 245)
        Me.combo_impresora_abonos.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_impresora_abonos.Name = "combo_impresora_abonos"
        Me.combo_impresora_abonos.Size = New System.Drawing.Size(510, 28)
        Me.combo_impresora_abonos.TabIndex = 7
        '
        'txt_margen_abonos
        '
        Me.txt_margen_abonos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_margen_abonos.Location = New System.Drawing.Point(744, 245)
        Me.txt_margen_abonos.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_margen_abonos.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_margen_abonos.Name = "txt_margen_abonos"
        Me.txt_margen_abonos.Size = New System.Drawing.Size(100, 29)
        Me.txt_margen_abonos.TabIndex = 362
        Me.txt_margen_abonos.TabStop = False
        '
        'txt_margen_facturas
        '
        Me.txt_margen_facturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_margen_facturas.Location = New System.Drawing.Point(744, 60)
        Me.txt_margen_facturas.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_margen_facturas.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_margen_facturas.Name = "txt_margen_facturas"
        Me.txt_margen_facturas.Size = New System.Drawing.Size(100, 29)
        Me.txt_margen_facturas.TabIndex = 361
        Me.txt_margen_facturas.TabStop = False
        '
        'combo_impresora_vales_de_cambio
        '
        Me.combo_impresora_vales_de_cambio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_impresora_vales_de_cambio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_impresora_vales_de_cambio.BackColor = System.Drawing.Color.White
        Me.combo_impresora_vales_de_cambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_impresora_vales_de_cambio.FormattingEnabled = True
        Me.combo_impresora_vales_de_cambio.Location = New System.Drawing.Point(226, 467)
        Me.combo_impresora_vales_de_cambio.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_impresora_vales_de_cambio.Name = "combo_impresora_vales_de_cambio"
        Me.combo_impresora_vales_de_cambio.Size = New System.Drawing.Size(510, 28)
        Me.combo_impresora_vales_de_cambio.TabIndex = 13
        '
        'txt_margen_cotizaciones
        '
        Me.txt_margen_cotizaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_margen_cotizaciones.Location = New System.Drawing.Point(744, 208)
        Me.txt_margen_cotizaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_margen_cotizaciones.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_margen_cotizaciones.Name = "txt_margen_cotizaciones"
        Me.txt_margen_cotizaciones.Size = New System.Drawing.Size(100, 29)
        Me.txt_margen_cotizaciones.TabIndex = 360
        Me.txt_margen_cotizaciones.TabStop = False
        '
        'txt_margen_nb
        '
        Me.txt_margen_nb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_margen_nb.Location = New System.Drawing.Point(744, 171)
        Me.txt_margen_nb.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_margen_nb.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_margen_nb.Name = "txt_margen_nb"
        Me.txt_margen_nb.Size = New System.Drawing.Size(100, 29)
        Me.txt_margen_nb.TabIndex = 359
        Me.txt_margen_nb.TabStop = False
        '
        'combo_impresora_envio_sucursal
        '
        Me.combo_impresora_envio_sucursal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_impresora_envio_sucursal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_impresora_envio_sucursal.BackColor = System.Drawing.Color.White
        Me.combo_impresora_envio_sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_impresora_envio_sucursal.FormattingEnabled = True
        Me.combo_impresora_envio_sucursal.Location = New System.Drawing.Point(226, 430)
        Me.combo_impresora_envio_sucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_impresora_envio_sucursal.Name = "combo_impresora_envio_sucursal"
        Me.combo_impresora_envio_sucursal.Size = New System.Drawing.Size(510, 28)
        Me.combo_impresora_envio_sucursal.TabIndex = 12
        '
        'txt_margen_nc
        '
        Me.txt_margen_nc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_margen_nc.Location = New System.Drawing.Point(744, 133)
        Me.txt_margen_nc.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_margen_nc.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_margen_nc.Name = "txt_margen_nc"
        Me.txt_margen_nc.Size = New System.Drawing.Size(100, 29)
        Me.txt_margen_nc.TabIndex = 358
        Me.txt_margen_nc.TabStop = False
        '
        'txt_margen_guias
        '
        Me.txt_margen_guias.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_margen_guias.Location = New System.Drawing.Point(744, 96)
        Me.txt_margen_guias.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_margen_guias.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_margen_guias.Name = "txt_margen_guias"
        Me.txt_margen_guias.Size = New System.Drawing.Size(100, 29)
        Me.txt_margen_guias.TabIndex = 357
        Me.txt_margen_guias.TabStop = False
        '
        'txt_margen_boletas
        '
        Me.txt_margen_boletas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_margen_boletas.Location = New System.Drawing.Point(744, 22)
        Me.txt_margen_boletas.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_margen_boletas.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.txt_margen_boletas.Name = "txt_margen_boletas"
        Me.txt_margen_boletas.Size = New System.Drawing.Size(100, 29)
        Me.txt_margen_boletas.TabIndex = 356
        Me.txt_margen_boletas.TabStop = False
        '
        'combo_impresora_nota_de_debito
        '
        Me.combo_impresora_nota_de_debito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_impresora_nota_de_debito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_impresora_nota_de_debito.BackColor = System.Drawing.Color.White
        Me.combo_impresora_nota_de_debito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_impresora_nota_de_debito.FormattingEnabled = True
        Me.combo_impresora_nota_de_debito.Location = New System.Drawing.Point(226, 171)
        Me.combo_impresora_nota_de_debito.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_impresora_nota_de_debito.Name = "combo_impresora_nota_de_debito"
        Me.combo_impresora_nota_de_debito.Size = New System.Drawing.Size(342, 28)
        Me.combo_impresora_nota_de_debito.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(740, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 20)
        Me.Label4.TabIndex = 352
        Me.Label4.Text = "MARGEN:"
        '
        'combo_impresora_nota_de_credito
        '
        Me.combo_impresora_nota_de_credito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_impresora_nota_de_credito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_impresora_nota_de_credito.BackColor = System.Drawing.Color.White
        Me.combo_impresora_nota_de_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_impresora_nota_de_credito.FormattingEnabled = True
        Me.combo_impresora_nota_de_credito.Location = New System.Drawing.Point(226, 134)
        Me.combo_impresora_nota_de_credito.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_impresora_nota_de_credito.Name = "combo_impresora_nota_de_credito"
        Me.combo_impresora_nota_de_credito.Size = New System.Drawing.Size(342, 28)
        Me.combo_impresora_nota_de_credito.TabIndex = 4
        '
        'combo_impresora_anticipos
        '
        Me.combo_impresora_anticipos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_impresora_anticipos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_impresora_anticipos.BackColor = System.Drawing.Color.White
        Me.combo_impresora_anticipos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_impresora_anticipos.FormattingEnabled = True
        Me.combo_impresora_anticipos.Location = New System.Drawing.Point(226, 282)
        Me.combo_impresora_anticipos.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_impresora_anticipos.Name = "combo_impresora_anticipos"
        Me.combo_impresora_anticipos.Size = New System.Drawing.Size(510, 28)
        Me.combo_impresora_anticipos.TabIndex = 8
        '
        'combo_impresora_tarjeta_rapida
        '
        Me.combo_impresora_tarjeta_rapida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.combo_impresora_tarjeta_rapida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_impresora_tarjeta_rapida.BackColor = System.Drawing.Color.White
        Me.combo_impresora_tarjeta_rapida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_impresora_tarjeta_rapida.FormattingEnabled = True
        Me.combo_impresora_tarjeta_rapida.Location = New System.Drawing.Point(226, 504)
        Me.combo_impresora_tarjeta_rapida.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_impresora_tarjeta_rapida.Name = "combo_impresora_tarjeta_rapida"
        Me.combo_impresora_tarjeta_rapida.Size = New System.Drawing.Size(510, 28)
        Me.combo_impresora_tarjeta_rapida.TabIndex = 14
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(3, 26)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(220, 20)
        Me.Label25.TabIndex = 289
        Me.Label25.Text = "BOLETAS:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(3, 581)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(220, 20)
        Me.Label13.TabIndex = 381
        Me.Label13.Text = "TICKET DE CHEQUES:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 64)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(220, 20)
        Me.Label1.TabIndex = 290
        Me.Label1.Text = "FACTURAS:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 100)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(220, 20)
        Me.Label2.TabIndex = 291
        Me.Label2.Text = "GUIAS:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(3, 655)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(220, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "ETIQUETAS 1:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(3, 396)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(220, 20)
        Me.Label9.TabIndex = 378
        Me.Label9.Text = "TICKET DE VENTAS:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_cuenta
        '
        Me.lbl_cuenta.BackColor = System.Drawing.Color.Transparent
        Me.lbl_cuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cuenta.Location = New System.Drawing.Point(3, 729)
        Me.lbl_cuenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_cuenta.Name = "lbl_cuenta"
        Me.lbl_cuenta.Size = New System.Drawing.Size(217, 20)
        Me.lbl_cuenta.TabIndex = 326
        Me.lbl_cuenta.Text = "TIPO IMPRESION:"
        Me.lbl_cuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(3, 359)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(220, 20)
        Me.Label8.TabIndex = 375
        Me.Label8.Text = "ESTADO DE CUENTA:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(3, 692)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(220, 20)
        Me.Label5.TabIndex = 330
        Me.Label5.Text = "ETIQUETAS 2:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(3, 322)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(220, 20)
        Me.Label7.TabIndex = 372
        Me.Label7.Text = "CAJA:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(3, 544)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(220, 20)
        Me.Label6.TabIndex = 369
        Me.Label6.Text = "PEDIDOS:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(3, 211)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(220, 20)
        Me.Label10.TabIndex = 339
        Me.Label10.Text = "COTIZACIONES:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(3, 248)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(220, 20)
        Me.Label11.TabIndex = 341
        Me.Label11.Text = "ABONOS:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(3, 470)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(220, 20)
        Me.Label12.TabIndex = 343
        Me.Label12.Text = "VALES DE CAMBIO:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(3, 433)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(220, 20)
        Me.Label14.TabIndex = 347
        Me.Label14.Text = "ENVIOS A SUCURSAL:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(3, 137)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(220, 20)
        Me.Label22.TabIndex = 315
        Me.Label22.Text = "NOTAS DE CREDITO:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(3, 174)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(220, 20)
        Me.Label21.TabIndex = 316
        Me.Label21.Text = "NOTAS DE DEBITO:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(3, 507)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(220, 20)
        Me.Label15.TabIndex = 349
        Me.Label15.Text = "TARJETA RAPIDA:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(3, 285)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(220, 20)
        Me.Label16.TabIndex = 351
        Me.Label16.Text = "ANTICIPOS:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btn_salir)
        Me.GroupBox2.Controls.Add(Me.btn_cancelar)
        Me.GroupBox2.Controls.Add(Me.btn_modificar)
        Me.GroupBox2.Controls.Add(Me.btn_guardar)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 778)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(880, 77)
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
        Me.btn_salir.Location = New System.Drawing.Point(675, 17)
        Me.btn_salir.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(127, 49)
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
        Me.btn_cancelar.Location = New System.Drawing.Point(476, 17)
        Me.btn_cancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(127, 49)
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
        Me.btn_modificar.Location = New System.Drawing.Point(78, 17)
        Me.btn_modificar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(127, 49)
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
        Me.btn_guardar.Location = New System.Drawing.Point(277, 17)
        Me.btn_guardar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(127, 49)
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
        Me.PictureBox_logo.Location = New System.Drawing.Point(9, 7)
        Me.PictureBox_logo.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox_logo.Name = "PictureBox_logo"
        Me.PictureBox_logo.Size = New System.Drawing.Size(400, 86)
        Me.PictureBox_logo.TabIndex = 72
        Me.PictureBox_logo.TabStop = False
        '
        'Check_facturas_electronica
        '
        Me.Check_facturas_electronica.AutoSize = True
        Me.Check_facturas_electronica.BackColor = System.Drawing.Color.Transparent
        Me.Check_facturas_electronica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_facturas_electronica.Location = New System.Drawing.Point(30, 25)
        Me.Check_facturas_electronica.Margin = New System.Windows.Forms.Padding(4)
        Me.Check_facturas_electronica.Name = "Check_facturas_electronica"
        Me.Check_facturas_electronica.Size = New System.Drawing.Size(120, 24)
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
        Me.Check_boletas_electronicas.Location = New System.Drawing.Point(182, 25)
        Me.Check_boletas_electronicas.Margin = New System.Windows.Forms.Padding(4)
        Me.Check_boletas_electronicas.Name = "Check_boletas_electronicas"
        Me.Check_boletas_electronicas.Size = New System.Drawing.Size(109, 24)
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
        Me.Check_guia_electronica.Location = New System.Drawing.Point(323, 25)
        Me.Check_guia_electronica.Margin = New System.Windows.Forms.Padding(4)
        Me.Check_guia_electronica.Name = "Check_guia_electronica"
        Me.Check_guia_electronica.Size = New System.Drawing.Size(82, 24)
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
        Me.GroupBox_electronicas.Location = New System.Drawing.Point(8, 715)
        Me.GroupBox_electronicas.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_electronicas.Name = "GroupBox_electronicas"
        Me.GroupBox_electronicas.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_electronicas.Size = New System.Drawing.Size(880, 62)
        Me.GroupBox_electronicas.TabIndex = 68
        Me.GroupBox_electronicas.TabStop = False
        Me.GroupBox_electronicas.Text = "DESHABILITAR IMPRESIONES MANUALES"
        '
        'Check_nota_debito_electronica
        '
        Me.Check_nota_debito_electronica.AutoSize = True
        Me.Check_nota_debito_electronica.BackColor = System.Drawing.Color.Transparent
        Me.Check_nota_debito_electronica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_nota_debito_electronica.Location = New System.Drawing.Point(666, 25)
        Me.Check_nota_debito_electronica.Margin = New System.Windows.Forms.Padding(4)
        Me.Check_nota_debito_electronica.Name = "Check_nota_debito_electronica"
        Me.Check_nota_debito_electronica.Size = New System.Drawing.Size(185, 24)
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
        Me.Check_nota_credito_electronica.Location = New System.Drawing.Point(437, 25)
        Me.Check_nota_credito_electronica.Margin = New System.Windows.Forms.Padding(4)
        Me.Check_nota_credito_electronica.Name = "Check_nota_credito_electronica"
        Me.Check_nota_credito_electronica.Size = New System.Drawing.Size(197, 24)
        Me.Check_nota_credito_electronica.TabIndex = 291
        Me.Check_nota_credito_electronica.TabStop = False
        Me.Check_nota_credito_electronica.Text = "NOTAS DE CREDITO"
        Me.Check_nota_credito_electronica.UseVisualStyleBackColor = False
        '
        'Form_impresoras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 864)
        Me.Controls.Add(Me.GroupBox_electronicas)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox_datos)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Form_impresoras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONFIGURACION DE IMPRESION"
        Me.GroupBox_datos.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txt_margen_consumo_interno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_margen_ticket_de_cheques, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_margen_ticket_de_ventas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_margen_estado_de_cuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_margen_caja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_margen_pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_margen_etiquetas_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_margen_etiquetas_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_margen_vales_de_cambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_margen_anticipos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_margen_tarjeta_rapida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_margen_envios_a_sucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_margen_abonos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_margen_facturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_margen_cotizaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_margen_nb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_margen_nc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_margen_guias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_margen_boletas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_electronicas.ResumeLayout(False)
        Me.GroupBox_electronicas.PerformLayout()
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Check_nota_debito_electronica As System.Windows.Forms.CheckBox
    Friend WithEvents Check_nota_credito_electronica As System.Windows.Forms.CheckBox
    Friend WithEvents radio_ticket As System.Windows.Forms.RadioButton
    Friend WithEvents radio_directa As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_cuenta As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents combo_impresora_nota_de_debito As System.Windows.Forms.ComboBox
    Friend WithEvents combo_impresora_nota_de_credito As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_impresora_etiquetas_2 As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_impresora_etiquetas_1 As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_impresora_guias As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_impresora_facturas As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_impresora_boletas As System.Windows.Forms.ComboBox
    Friend WithEvents txt_margen_etiquetas_2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txt_margen_etiquetas_1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents combo_impresora_anticipos As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents combo_impresora_tarjeta_rapida As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents combo_impresora_envio_sucursal As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents combo_impresora_vales_de_cambio As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents combo_impresora_abonos As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents combo_impresora_cotizaciones As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txt_margen_vales_de_cambio As NumericUpDown
    Friend WithEvents txt_margen_anticipos As NumericUpDown
    Friend WithEvents txt_margen_tarjeta_rapida As NumericUpDown
    Friend WithEvents txt_margen_envios_a_sucursal As NumericUpDown
    Friend WithEvents txt_margen_abonos As NumericUpDown
    Friend WithEvents txt_margen_facturas As NumericUpDown
    Friend WithEvents txt_margen_cotizaciones As NumericUpDown
    Friend WithEvents txt_margen_nb As NumericUpDown
    Friend WithEvents txt_margen_nc As NumericUpDown
    Friend WithEvents txt_margen_guias As NumericUpDown
    Friend WithEvents txt_margen_boletas As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_margen_pedidos As NumericUpDown
    Friend WithEvents Combo_impresora_pedidos As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_margen_caja As NumericUpDown
    Friend WithEvents combo_impresora_caja As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_margen_estado_de_cuenta As NumericUpDown
    Friend WithEvents combo_impresora_estados_de_cuenta As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_margen_ticket_de_ventas As NumericUpDown
    Friend WithEvents combo_impresora_ticket_de_ventas As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txt_margen_ticket_de_cheques As NumericUpDown
    Friend WithEvents combo_impresora_registro_cheques As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txt_margen_consumo_interno As NumericUpDown
    Friend WithEvents combo_impresora_consumo_interno As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Combo_tipo_impresion_boletas As ComboBox
    Friend WithEvents Combo_tipo_impresion_notas_de_debito As ComboBox
    Friend WithEvents Combo_tipo_impresion_notas_de_credito As ComboBox
    Friend WithEvents Combo_tipo_impresion_guias As ComboBox
    Friend WithEvents Combo_tipo_impresion_facturas As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
End Class
