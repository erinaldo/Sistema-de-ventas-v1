<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_numeros_impresion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_numeros_impresion))
        Me.txt_boleta_desde = New System.Windows.Forms.TextBox()
        Me.txt_factura_desde = New System.Windows.Forms.TextBox()
        Me.txt_guia_desde = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_modificar = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_nota_credito_hasta = New System.Windows.Forms.TextBox()
        Me.txt_boleta_hasta = New System.Windows.Forms.TextBox()
        Me.txt_factura_hasta = New System.Windows.Forms.TextBox()
        Me.txt_guia_hasta = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_abono_hasta = New System.Windows.Forms.TextBox()
        Me.txt_cotizacion_hasta = New System.Windows.Forms.TextBox()
        Me.txt_orden_de_compra_hasta = New System.Windows.Forms.TextBox()
        Me.txt_nota_debito_hasta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Radio_abono = New System.Windows.Forms.RadioButton()
        Me.Radio_nota_credito = New System.Windows.Forms.RadioButton()
        Me.Radio_nota_debito = New System.Windows.Forms.RadioButton()
        Me.txt_nota_credito_desde = New System.Windows.Forms.TextBox()
        Me.txt_abono_desde = New System.Windows.Forms.TextBox()
        Me.Radio_guia = New System.Windows.Forms.RadioButton()
        Me.txt_cotizacion_desde = New System.Windows.Forms.TextBox()
        Me.Radio_factura = New System.Windows.Forms.RadioButton()
        Me.Radio_orden_de_compra = New System.Windows.Forms.RadioButton()
        Me.Radio_boleta = New System.Windows.Forms.RadioButton()
        Me.Radio_cotizacion = New System.Windows.Forms.RadioButton()
        Me.txt_orden_de_compra_desde = New System.Windows.Forms.TextBox()
        Me.txt_nota_debito_desde = New System.Windows.Forms.TextBox()
        Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_boleta_desde
        '
        Me.txt_boleta_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_boleta_desde.Location = New System.Drawing.Point(232, 40)
        Me.txt_boleta_desde.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_boleta_desde.MaxLength = 11
        Me.txt_boleta_desde.Name = "txt_boleta_desde"
        Me.txt_boleta_desde.Size = New System.Drawing.Size(132, 29)
        Me.txt_boleta_desde.TabIndex = 1
        Me.txt_boleta_desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_factura_desde
        '
        Me.txt_factura_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_factura_desde.Location = New System.Drawing.Point(232, 93)
        Me.txt_factura_desde.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_factura_desde.MaxLength = 11
        Me.txt_factura_desde.Name = "txt_factura_desde"
        Me.txt_factura_desde.Size = New System.Drawing.Size(132, 29)
        Me.txt_factura_desde.TabIndex = 3
        Me.txt_factura_desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_guia_desde
        '
        Me.txt_guia_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_guia_desde.Location = New System.Drawing.Point(232, 146)
        Me.txt_guia_desde.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_guia_desde.MaxLength = 11
        Me.txt_guia_desde.Name = "txt_guia_desde"
        Me.txt_guia_desde.Size = New System.Drawing.Size(132, 29)
        Me.txt_guia_desde.TabIndex = 5
        Me.txt_guia_desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btn_salir)
        Me.GroupBox2.Controls.Add(Me.btn_cancelar)
        Me.GroupBox2.Controls.Add(Me.btn_modificar)
        Me.GroupBox2.Controls.Add(Me.btn_guardar)
        Me.GroupBox2.Location = New System.Drawing.Point(1047, 95)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(143, 241)
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
        Me.btn_salir.Location = New System.Drawing.Point(7, 182)
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
        Me.btn_cancelar.Location = New System.Drawing.Point(8, 127)
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
        Me.btn_modificar.Location = New System.Drawing.Point(8, 16)
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
        Me.btn_guardar.Location = New System.Drawing.Point(8, 71)
        Me.btn_guardar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(127, 49)
        Me.btn_guardar.TabIndex = 9
        Me.btn_guardar.Text = "GUARDAR"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_nota_credito_hasta)
        Me.GroupBox1.Controls.Add(Me.txt_boleta_hasta)
        Me.GroupBox1.Controls.Add(Me.txt_factura_hasta)
        Me.GroupBox1.Controls.Add(Me.txt_guia_hasta)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_abono_hasta)
        Me.GroupBox1.Controls.Add(Me.txt_cotizacion_hasta)
        Me.GroupBox1.Controls.Add(Me.txt_orden_de_compra_hasta)
        Me.GroupBox1.Controls.Add(Me.txt_nota_debito_hasta)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Radio_abono)
        Me.GroupBox1.Controls.Add(Me.Radio_nota_credito)
        Me.GroupBox1.Controls.Add(Me.Radio_nota_debito)
        Me.GroupBox1.Controls.Add(Me.txt_nota_credito_desde)
        Me.GroupBox1.Controls.Add(Me.txt_abono_desde)
        Me.GroupBox1.Controls.Add(Me.Radio_guia)
        Me.GroupBox1.Controls.Add(Me.txt_cotizacion_desde)
        Me.GroupBox1.Controls.Add(Me.Radio_factura)
        Me.GroupBox1.Controls.Add(Me.Radio_orden_de_compra)
        Me.GroupBox1.Controls.Add(Me.Radio_boleta)
        Me.GroupBox1.Controls.Add(Me.Radio_cotizacion)
        Me.GroupBox1.Controls.Add(Me.txt_boleta_desde)
        Me.GroupBox1.Controls.Add(Me.txt_orden_de_compra_desde)
        Me.GroupBox1.Controls.Add(Me.txt_factura_desde)
        Me.GroupBox1.Controls.Add(Me.txt_nota_debito_desde)
        Me.GroupBox1.Controls.Add(Me.txt_guia_desde)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 95)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1030, 241)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(368, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 20)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "HASTA:"
        '
        'txt_nota_credito_hasta
        '
        Me.txt_nota_credito_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nota_credito_hasta.Location = New System.Drawing.Point(372, 199)
        Me.txt_nota_credito_hasta.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_nota_credito_hasta.MaxLength = 11
        Me.txt_nota_credito_hasta.Name = "txt_nota_credito_hasta"
        Me.txt_nota_credito_hasta.Size = New System.Drawing.Size(132, 29)
        Me.txt_nota_credito_hasta.TabIndex = 8
        Me.txt_nota_credito_hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_boleta_hasta
        '
        Me.txt_boleta_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_boleta_hasta.Location = New System.Drawing.Point(372, 40)
        Me.txt_boleta_hasta.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_boleta_hasta.MaxLength = 11
        Me.txt_boleta_hasta.Name = "txt_boleta_hasta"
        Me.txt_boleta_hasta.Size = New System.Drawing.Size(132, 29)
        Me.txt_boleta_hasta.TabIndex = 2
        Me.txt_boleta_hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_factura_hasta
        '
        Me.txt_factura_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_factura_hasta.Location = New System.Drawing.Point(372, 93)
        Me.txt_factura_hasta.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_factura_hasta.MaxLength = 11
        Me.txt_factura_hasta.Name = "txt_factura_hasta"
        Me.txt_factura_hasta.Size = New System.Drawing.Size(132, 29)
        Me.txt_factura_hasta.TabIndex = 4
        Me.txt_factura_hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_guia_hasta
        '
        Me.txt_guia_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_guia_hasta.Location = New System.Drawing.Point(372, 146)
        Me.txt_guia_hasta.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_guia_hasta.MaxLength = 11
        Me.txt_guia_hasta.Name = "txt_guia_hasta"
        Me.txt_guia_hasta.Size = New System.Drawing.Size(132, 29)
        Me.txt_guia_hasta.TabIndex = 6
        Me.txt_guia_hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(885, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 20)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "HASTA:"
        '
        'txt_abono_hasta
        '
        Me.txt_abono_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_abono_hasta.Location = New System.Drawing.Point(889, 199)
        Me.txt_abono_hasta.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_abono_hasta.MaxLength = 11
        Me.txt_abono_hasta.Name = "txt_abono_hasta"
        Me.txt_abono_hasta.Size = New System.Drawing.Size(132, 29)
        Me.txt_abono_hasta.TabIndex = 16
        Me.txt_abono_hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_cotizacion_hasta
        '
        Me.txt_cotizacion_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cotizacion_hasta.Location = New System.Drawing.Point(889, 93)
        Me.txt_cotizacion_hasta.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_cotizacion_hasta.MaxLength = 11
        Me.txt_cotizacion_hasta.Name = "txt_cotizacion_hasta"
        Me.txt_cotizacion_hasta.Size = New System.Drawing.Size(132, 29)
        Me.txt_cotizacion_hasta.TabIndex = 12
        Me.txt_cotizacion_hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_orden_de_compra_hasta
        '
        Me.txt_orden_de_compra_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_orden_de_compra_hasta.Location = New System.Drawing.Point(889, 146)
        Me.txt_orden_de_compra_hasta.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_orden_de_compra_hasta.MaxLength = 11
        Me.txt_orden_de_compra_hasta.Name = "txt_orden_de_compra_hasta"
        Me.txt_orden_de_compra_hasta.Size = New System.Drawing.Size(132, 29)
        Me.txt_orden_de_compra_hasta.TabIndex = 14
        Me.txt_orden_de_compra_hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_nota_debito_hasta
        '
        Me.txt_nota_debito_hasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nota_debito_hasta.Location = New System.Drawing.Point(889, 40)
        Me.txt_nota_debito_hasta.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_nota_debito_hasta.MaxLength = 11
        Me.txt_nota_debito_hasta.Name = "txt_nota_debito_hasta"
        Me.txt_nota_debito_hasta.Size = New System.Drawing.Size(132, 29)
        Me.txt_nota_debito_hasta.TabIndex = 10
        Me.txt_nota_debito_hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(745, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "DESDE:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(228, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "DESDE:"
        '
        'Radio_abono
        '
        Me.Radio_abono.BackColor = System.Drawing.Color.Transparent
        Me.Radio_abono.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_abono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_abono.Location = New System.Drawing.Point(526, 202)
        Me.Radio_abono.Margin = New System.Windows.Forms.Padding(4)
        Me.Radio_abono.Name = "Radio_abono"
        Me.Radio_abono.Size = New System.Drawing.Size(215, 24)
        Me.Radio_abono.TabIndex = 10
        Me.Radio_abono.Text = "ABONOS:"
        Me.Radio_abono.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_abono.UseVisualStyleBackColor = False
        '
        'Radio_nota_credito
        '
        Me.Radio_nota_credito.BackColor = System.Drawing.Color.Transparent
        Me.Radio_nota_credito.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_nota_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_nota_credito.Location = New System.Drawing.Point(9, 202)
        Me.Radio_nota_credito.Margin = New System.Windows.Forms.Padding(4)
        Me.Radio_nota_credito.Name = "Radio_nota_credito"
        Me.Radio_nota_credito.Size = New System.Drawing.Size(215, 24)
        Me.Radio_nota_credito.TabIndex = 4
        Me.Radio_nota_credito.Text = "NOTAS DE CREDITO:"
        Me.Radio_nota_credito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_nota_credito.UseVisualStyleBackColor = False
        '
        'Radio_nota_debito
        '
        Me.Radio_nota_debito.BackColor = System.Drawing.Color.Transparent
        Me.Radio_nota_debito.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_nota_debito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_nota_debito.Location = New System.Drawing.Point(526, 43)
        Me.Radio_nota_debito.Margin = New System.Windows.Forms.Padding(4)
        Me.Radio_nota_debito.Name = "Radio_nota_debito"
        Me.Radio_nota_debito.Size = New System.Drawing.Size(215, 24)
        Me.Radio_nota_debito.TabIndex = 7
        Me.Radio_nota_debito.Text = "NOTAS DE DEBITO:"
        Me.Radio_nota_debito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_nota_debito.UseVisualStyleBackColor = False
        '
        'txt_nota_credito_desde
        '
        Me.txt_nota_credito_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nota_credito_desde.Location = New System.Drawing.Point(232, 199)
        Me.txt_nota_credito_desde.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_nota_credito_desde.MaxLength = 11
        Me.txt_nota_credito_desde.Name = "txt_nota_credito_desde"
        Me.txt_nota_credito_desde.Size = New System.Drawing.Size(132, 29)
        Me.txt_nota_credito_desde.TabIndex = 7
        Me.txt_nota_credito_desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_abono_desde
        '
        Me.txt_abono_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_abono_desde.Location = New System.Drawing.Point(749, 199)
        Me.txt_abono_desde.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_abono_desde.MaxLength = 11
        Me.txt_abono_desde.Name = "txt_abono_desde"
        Me.txt_abono_desde.Size = New System.Drawing.Size(132, 29)
        Me.txt_abono_desde.TabIndex = 15
        Me.txt_abono_desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Radio_guia
        '
        Me.Radio_guia.BackColor = System.Drawing.Color.Transparent
        Me.Radio_guia.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_guia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_guia.Location = New System.Drawing.Point(9, 149)
        Me.Radio_guia.Margin = New System.Windows.Forms.Padding(4)
        Me.Radio_guia.Name = "Radio_guia"
        Me.Radio_guia.Size = New System.Drawing.Size(215, 24)
        Me.Radio_guia.TabIndex = 2
        Me.Radio_guia.Text = "GUIAS:"
        Me.Radio_guia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_guia.UseVisualStyleBackColor = False
        '
        'txt_cotizacion_desde
        '
        Me.txt_cotizacion_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cotizacion_desde.Location = New System.Drawing.Point(749, 93)
        Me.txt_cotizacion_desde.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_cotizacion_desde.MaxLength = 11
        Me.txt_cotizacion_desde.Name = "txt_cotizacion_desde"
        Me.txt_cotizacion_desde.Size = New System.Drawing.Size(132, 29)
        Me.txt_cotizacion_desde.TabIndex = 11
        Me.txt_cotizacion_desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Radio_factura
        '
        Me.Radio_factura.BackColor = System.Drawing.Color.Transparent
        Me.Radio_factura.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_factura.Location = New System.Drawing.Point(9, 96)
        Me.Radio_factura.Margin = New System.Windows.Forms.Padding(4)
        Me.Radio_factura.Name = "Radio_factura"
        Me.Radio_factura.Size = New System.Drawing.Size(215, 24)
        Me.Radio_factura.TabIndex = 2
        Me.Radio_factura.Text = "FACTURAS:"
        Me.Radio_factura.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_factura.UseVisualStyleBackColor = False
        '
        'Radio_orden_de_compra
        '
        Me.Radio_orden_de_compra.BackColor = System.Drawing.Color.Transparent
        Me.Radio_orden_de_compra.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_orden_de_compra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_orden_de_compra.Location = New System.Drawing.Point(526, 149)
        Me.Radio_orden_de_compra.Margin = New System.Windows.Forms.Padding(4)
        Me.Radio_orden_de_compra.Name = "Radio_orden_de_compra"
        Me.Radio_orden_de_compra.Size = New System.Drawing.Size(215, 24)
        Me.Radio_orden_de_compra.TabIndex = 8
        Me.Radio_orden_de_compra.Text = "ORDEN DE COMPRA:"
        Me.Radio_orden_de_compra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_orden_de_compra.UseVisualStyleBackColor = False
        '
        'Radio_boleta
        '
        Me.Radio_boleta.BackColor = System.Drawing.Color.Transparent
        Me.Radio_boleta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_boleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_boleta.Location = New System.Drawing.Point(9, 43)
        Me.Radio_boleta.Margin = New System.Windows.Forms.Padding(4)
        Me.Radio_boleta.Name = "Radio_boleta"
        Me.Radio_boleta.Size = New System.Drawing.Size(215, 24)
        Me.Radio_boleta.TabIndex = 2
        Me.Radio_boleta.Text = "BOLETAS:"
        Me.Radio_boleta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_boleta.UseVisualStyleBackColor = False
        '
        'Radio_cotizacion
        '
        Me.Radio_cotizacion.BackColor = System.Drawing.Color.Transparent
        Me.Radio_cotizacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_cotizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_cotizacion.Location = New System.Drawing.Point(526, 96)
        Me.Radio_cotizacion.Margin = New System.Windows.Forms.Padding(4)
        Me.Radio_cotizacion.Name = "Radio_cotizacion"
        Me.Radio_cotizacion.Size = New System.Drawing.Size(215, 24)
        Me.Radio_cotizacion.TabIndex = 2
        Me.Radio_cotizacion.Text = "COTIZACIONES:"
        Me.Radio_cotizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Radio_cotizacion.UseVisualStyleBackColor = False
        '
        'txt_orden_de_compra_desde
        '
        Me.txt_orden_de_compra_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_orden_de_compra_desde.Location = New System.Drawing.Point(749, 146)
        Me.txt_orden_de_compra_desde.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_orden_de_compra_desde.MaxLength = 11
        Me.txt_orden_de_compra_desde.Name = "txt_orden_de_compra_desde"
        Me.txt_orden_de_compra_desde.Size = New System.Drawing.Size(132, 29)
        Me.txt_orden_de_compra_desde.TabIndex = 13
        Me.txt_orden_de_compra_desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_nota_debito_desde
        '
        Me.txt_nota_debito_desde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nota_debito_desde.Location = New System.Drawing.Point(749, 40)
        Me.txt_nota_debito_desde.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_nota_debito_desde.MaxLength = 11
        Me.txt_nota_debito_desde.Name = "txt_nota_debito_desde"
        Me.txt_nota_debito_desde.Size = New System.Drawing.Size(132, 29)
        Me.txt_nota_debito_desde.TabIndex = 9
        Me.txt_nota_debito_desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.PictureBox_logo.TabIndex = 69
        Me.PictureBox_logo.TabStop = False
        '
        'Form_numeros_impresion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1198, 344)
        Me.Controls.Add(Me.PictureBox_logo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Form_numeros_impresion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NUMEROS DE IMPRESION"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_boleta_desde As System.Windows.Forms.TextBox
    Friend WithEvents txt_factura_desde As System.Windows.Forms.TextBox
    Friend WithEvents txt_guia_desde As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_modificar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox_logo As System.Windows.Forms.PictureBox
    Friend WithEvents txt_nota_credito_desde As System.Windows.Forms.TextBox
    Friend WithEvents txt_nota_debito_desde As System.Windows.Forms.TextBox
    Friend WithEvents txt_orden_de_compra_desde As System.Windows.Forms.TextBox
    Friend WithEvents txt_abono_desde As System.Windows.Forms.TextBox
    Friend WithEvents txt_cotizacion_desde As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_nota_credito_hasta As TextBox
    Friend WithEvents txt_boleta_hasta As TextBox
    Friend WithEvents txt_factura_hasta As TextBox
    Friend WithEvents txt_guia_hasta As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_abono_hasta As TextBox
    Friend WithEvents txt_cotizacion_hasta As TextBox
    Friend WithEvents txt_orden_de_compra_hasta As TextBox
    Friend WithEvents txt_nota_debito_hasta As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Radio_abono As RadioButton
    Friend WithEvents Radio_nota_credito As RadioButton
    Friend WithEvents Radio_nota_debito As RadioButton
    Friend WithEvents Radio_guia As RadioButton
    Friend WithEvents Radio_factura As RadioButton
    Friend WithEvents Radio_orden_de_compra As RadioButton
    Friend WithEvents Radio_boleta As RadioButton
    Friend WithEvents Radio_cotizacion As RadioButton
End Class
