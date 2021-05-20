Imports System.IO
Imports System.Drawing.Drawing2D

Public Class Form_registro_proveedores_compra

    Dim VarSeleccion As Integer
    Dim MiPos As Integer

    Private Sub form_registro_proveedores_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_Compra.Enabled = True
        Form_Compra.WindowState = FormWindowState.Normal
    End Sub

    Private Sub form_clientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'DS.Tables.Clear()
        'DT.Rows.Clear()
        'DT.Columns.Clear()
        'DS.Clear()
        'conexion.Open()

        'SC.Connection = conexion
        'SC.CommandText = "select * from proveedores where rut_proveedor <> 'TODOS'"
        'DA.SelectCommand = SC
        'DA.Fill(DT)
        'DS.Tables.Add(DT)

        'mostrar(0)

        conexion.Close()


        comunas()

        CONTROLES(False, True)
        cargar_logo()
    End Sub

    Sub comunas()


        conexion.Close()
        DS4.Tables.Clear()
        DT4.Rows.Clear()
        DT4.Columns.Clear()
        DS4.Clear()
        SC4.Connection = conexion
        SC4.CommandText = "select * from comuna order by comuna_nombre asc"
        DA4.SelectCommand = SC4
        DA4.Fill(DT4)
        DS4.Tables.Add(DT4)

        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        If DS4.Tables(DT4.TableName).Rows.Count > 0 Then


            For i = 0 To DS4.Tables(0).Rows.Count - 1

                ' Combo_comuna.Items.Add(UCase(DS3.Tables(DT3.TableName).Rows(i).Item("comuna_nombre")))
                col.Add(UCase(DS4.Tables(0).Rows(i)("comuna_nombre").ToString()))
            Next
            txt_comuna.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt_comuna.AutoCompleteCustomSource = col
            txt_comuna.AutoCompleteMode = AutoCompleteMode.Suggest

            txt_comuna.AutoCompleteSource = AutoCompleteSource.CustomSource
            txt_comuna.AutoCompleteCustomSource = col
            txt_comuna.AutoCompleteMode = AutoCompleteMode.Suggest
        End If

        txt_comuna.AutoCompleteSource = AutoCompleteSource.CustomSource
        txt_comuna.AutoCompleteCustomSource = col
        txt_comuna.AutoCompleteMode = AutoCompleteMode.Suggest








    End Sub

    Sub MOSTRAR_DATOS_PROVEEDOR()

        If txt_rut.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from proveedores where rut_proveedor ='" & (txt_rut.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut.Text = DS.Tables(DT.TableName).Rows(0).Item("RUT_PROVEEDOR")
                txt_nombre.Text = DS.Tables(DT.TableName).Rows(0).Item("NOMBRE_PROVEEDOR")
                txt_direccion.Text = DS.Tables(DT.TableName).Rows(0).Item("DIRECCION_PROVEEDOR")
                txt_telefono.Text = DS.Tables(DT.TableName).Rows(0).Item("TELEFONO_PROVEEDOR")
                txt_email.Text = DS.Tables(DT.TableName).Rows(0).Item("EMAIL_PROVEEDOR")
                '  txt_ciudad.Text = DS.Tables(DT.TableName).Rows(0).Item("CIUDAD_PROVEEDOR")
                txt_comuna.Text = DS.Tables(DT.TableName).Rows(0).Item("COMUNA_PROVEEDOR")
                txt_giro.Text = DS.Tables(DT.TableName).Rows(0).Item("GIRO_PROVEEDOR")
                txt_representante.Text = DS.Tables(DT.TableName).Rows(0).Item("REPRESENTANTE_PROVEEDOR")
                txt_credito.Text = DS.Tables(DT.TableName).Rows(0).Item("CREDITO_PROVEEDOR")
                txt_rut.Enabled = False
                txt_nombre.Enabled = True
                txt_direccion.Enabled = True
                txt_telefono.Enabled = True
                txt_email.Enabled = True
                'txt_ciudad.Enabled = True
                txt_comuna.Enabled = True
                txt_giro.Enabled = True
                txt_representante.Enabled = True
                txt_credito.Enabled = True
                txt_nombre.Enabled = True
                btn_guardar.Enabled = True
                txt_nombre.Focus()
            Else
                MsgBox("RUT DE PROVEEDOR NO EXISTENTE", 0 + 16, "ERROR")
                conexion.Close()
                Exit Sub
            End If
            conexion.Close()
        End If
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub


    Private Sub txt_rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rut.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "|" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "¿" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "?" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "}" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "{" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "<" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = ">" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "*" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If



        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If VarSeleccion = 1 Then
                guion_rut()
                txt_nombre.Focus()
            End If
            If VarSeleccion = 2 Then
                guion_rut()
                MOSTRAR_DATOS_PROVEEDOR()
            End If
        End If

    End Sub

    Sub guion_rut()
        Dim rut_cliente As String
        Dim guion As String
        rut_cliente = txt_rut.Text
        If rut_cliente.Length > 2 Then
            guion = rut_cliente(rut_cliente.Length - 2).ToString()
            If guion <> "-" Then
                Dim fin_rut As String = rut_cliente(rut_cliente.Length - 1).ToString()
                rut_cliente = Mid(rut_cliente, 1, Len(rut_cliente) - 1)
                rut_cliente = rut_cliente & "-" & fin_rut
                txt_rut.Text = rut_cliente
            End If
        End If
    End Sub

    Private Sub TXT_RUT_VALIDATED(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles txt_rut.Validated
        'If VALIDA_RUT(TXT_RUT.TEXT) = False Then
        '    TXT_RUT.FOCUS()
        '    TXT_RUT.SELECTALL()
        'End If
    End Sub

    Sub MOSTRAR(ByVal I As Integer)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            txt_rut.Text = DS.Tables(DT.TableName).Rows(I).Item("RUT_PROVEEDOR")
            txt_nombre.Text = DS.Tables(DT.TableName).Rows(I).Item("NOMBRE_PROVEEDOR")
            txt_direccion.Text = DS.Tables(DT.TableName).Rows(I).Item("DIRECCION_PROVEEDOR")
            txt_telefono.Text = DS.Tables(DT.TableName).Rows(I).Item("TELEFONO_PROVEEDOR")
            txt_email.Text = DS.Tables(DT.TableName).Rows(I).Item("EMAIL_PROVEEDOR")
            'txt_ciudad.Text = DS.Tables(DT.TableName).Rows(I).Item("CIUDAD_PROVEEDOR")
            txt_comuna.Text = DS.Tables(DT.TableName).Rows(I).Item("COMUNA_PROVEEDOR")
            txt_giro.Text = DS.Tables(DT.TableName).Rows(I).Item("GIRO_PROVEEDOR")
            txt_representante.Text = DS.Tables(DT.TableName).Rows(I).Item("REPRESENTANTE_PROVEEDOR")
            txt_credito.Text = DS.Tables(DT.TableName).Rows(I).Item("CREDITO_PROVEEDOR")
        End If
    End Sub

    Sub CONTROLES(ByVal A As Boolean, ByVal B As Boolean)
        btn_nuevo.Enabled = B
        btn_eliminar.Enabled = B
        btn_modificar.Enabled = B
        'BTN_BUSCAR.ENABLED = B
        btn_guardar.Enabled = A
        btn_cancelar.Enabled = A
        'BTN_IMPRIMIR.ENABLED = B
        txt_rut.Enabled = A
        txt_direccion.Enabled = A
        txt_nombre.Enabled = A
        txt_telefono.Enabled = A
        txt_email.Enabled = A
        ' txt_ciudad.Enabled = A
        txt_comuna.Enabled = A
        txt_giro.Enabled = A

        txt_representante.Enabled = A
        txt_credito.Enabled = A

        ' BTN_PRIMERO.ENABLED = B
        ' BTN_ULTIMO.ENABLED = B
        ' BTN_SIGUIENTE.ENABLED = B
        '  BTN_ANTERIOR.ENABLED = B
    End Sub

    Sub LIMPIAR()
        txt_rut.Text = ""
        txt_nombre.Text = ""
        txt_direccion.Text = ""
        txt_telefono.Text = ""
        txt_email.Text = ""
        'txt_ciudad.Text = ""
        txt_comuna.Text = ""
        txt_giro.Text = ""
        txt_representante.Text = ""
        txt_credito.Text = ""
    End Sub

    Private Sub BTN_NUEVO_CLICK(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles btn_nuevo.Click
        LIMPIAR()
        CONTROLES(True, False)
        VarSeleccion = 1
        txt_rut.Focus()
    End Sub

    Private Sub BTN_MODIFICAR_CLICK(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles btn_modificar.Click
        CONTROLES(True, False)
        VarSeleccion = 2


        txt_rut.Enabled = True

        txt_nombre.Enabled = False
        txt_direccion.Enabled = False
        txt_telefono.Enabled = False
        txt_email.Enabled = False
        ' txt_ciudad.Enabled = False
        txt_comuna.Enabled = False
        txt_giro.Enabled = False
        txt_representante.Enabled = False
        txt_credito.Enabled = False
        txt_nombre.Enabled = False
        txt_rut.Focus()
    End Sub

    Private Sub BTN_GUARDAR_CLICK(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles btn_guardar.Click
      
        
       
      
        
       
        If txt_rut.Text = "" Then
            MsgBox("CAMPO RUT VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_rut.Focus()
            Exit Sub
        End If
        If txt_nombre.Text = "" Then
            MsgBox("CAMPO NOMBRE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_nombre.Focus()
            Exit Sub
        End If
        If txt_direccion.Text = "" Then
            MsgBox("CAMPO DIRECCION VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_direccion.Focus()
            Exit Sub
        End If
        If txt_telefono.Text = "" Then
            MsgBox("CAMPO TELEFONO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_telefono.Focus()
            Exit Sub
        End If
        If txt_email.Text = "" Then
            MsgBox("CAMPO CORREO ELECTRONICO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_email.Focus()
            Exit Sub
        End If
        If txt_comuna.Text = "" Then
            MsgBox("CAMPO COMUNA VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_comuna.Focus()
            Exit Sub
        End If
        If txt_giro.Text = "" Then
            MsgBox("CAMPO GIRO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_giro.Focus()
            Exit Sub
        End If
        If txt_representante.Text = "" Then
            MsgBox("CAMPO REPRESENTANTE VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_representante.Focus()
            Exit Sub
        End If
        If txt_credito.Text = "" Then
            MsgBox("CAMPO CREDITO VACIO, FAVOR LLENAR", 0 + 16, "ERROR")
            txt_credito.Focus()
            Exit Sub
        End If




        conexion.Close()
        Consultas_SQL("select * from comuna where comuna_nombre = '" & (txt_comuna.Text) & "'")
        If DS.Tables(DT.TableName).Rows.Count = 0 Then
            MsgBox("DEBE SELECCIONAR UNA COMUNA DEL SISTEMA", 0 + 16, "ERROR")
            txt_comuna.Focus()
            Exit Sub
        End If


     
        If VarSeleccion = 1 Then
            If valida_rut(txt_rut.Text) = False Then
                txt_rut.Focus()
                txt_rut.SelectAll()
            End If

            conexion.Close()
            Consultas_SQL("SELECT * FROM PROVEEDORES WHERE RUT_PROVEEDOR = '" & (txt_rut.Text) & "'")
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                MsgBox("RUT DE PROVEEDOR YA EXISTENTE", 0 + 16, "ERROR")
                txt_rut.Focus()
            End If

            SC.Connection = conexion
            SC.CommandText = "INSERT INTO PROVEEDORES (RUT_PROVEEDOR, NOMBRE_PROVEEDOR, DIRECCION_PROVEEDOR, TELEFONO_PROVEEDOR, EMAIL_PROVEEDOR, CIUDAD_PROVEEDOR, COMUNA_PROVEEDOR, GIRO_PROVEEDOR, REPRESENTANTE_PROVEEDOR, CREDITO_PROVEEDOR, fecha_modificacion) VALUES ('" & (txt_rut.Text) & "','" & (txt_nombre.Text) & "','" & (txt_direccion.Text) & "','" & (txt_telefono.Text) & "','" & (txt_email.Text) & "','" & (txt_comuna.Text) & "','" & (txt_comuna.Text) & "','" & (txt_giro.Text) & "','" & (txt_representante.Text) & "','" & (txt_credito.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PROVEEDORES','CREACION DE PROVEEDORES','" & (txt_nombre.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "','CREACION','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            ACTUALIZAR_TABLA()
            CONTROLES(False, True)

            MsgBox("DATOS INGRESADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

            Form_Compra.txt_rut_proveedor.Text = txt_rut.Text
            Form_Compra.mostrar_datos_proveedores_combo()
            Form_Compra.txt_rut_proveedor.Focus()
            Me.Close()
        End If



        If VarSeleccion = 2 Then
            SC.Connection = conexion
            SC.CommandText = "UPDATE PROVEEDORES SET NOMBRE_PROVEEDOR='" & (txt_nombre.Text) & "', DIRECCION_PROVEEDOR='" & (txt_direccion.Text) & "', TELEFONO_PROVEEDOR = '" & (txt_telefono.Text) & "', EMAIL_PROVEEDOR = '" & (txt_email.Text) & "', CIUDAD_PROVEEDOR = '" & (txt_comuna.Text) & "', COMUNA_PROVEEDOR = '" & (txt_comuna.Text) & "', GIRO_PROVEEDOR = '" & (txt_giro.Text) & "', REPRESENTANTE_PROVEEDOR = '" & (txt_representante.Text) & "', CREDITO_PROVEEDOR = '" & (txt_credito.Text) & "', fecha_modificacion = '" & (Form_menu_principal.dtp_fecha.Text) & "' WHERE RUT_PROVEEDOR = '" & (txt_rut.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)

            SC.Connection = conexion
            SC.CommandText = "insert into bitacora_de_cambios (procedencia, detalle, codigo, fecha, TIPO, usuario_responsable) values('PROVEEDORES','MODIFICACION DE PROVEEDORES','" & (txt_nombre.Text) & "','" & (Form_menu_principal.dtp_fecha.Text) & "',',MODIFICACION','" & (miusuario) & "')"
            DA.SelectCommand = SC
            DA.Fill(DT)

            MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")

            ACTUALIZAR_TABLA()
            CONTROLES(False, True)
            Form_Compra.txt_rut_proveedor.Text = txt_rut.Text
            Form_Compra.mostrar_datos_proveedores_combo()
            Form_Compra.txt_rut_proveedor.Focus()
            Me.Close()
        End If


    End Sub

    Private Sub BTN_ELIMINAR_CLICK(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles btn_eliminar.Click
        Dim VALORMENSAJE As Integer
        VALORMENSAJE = MsgBox("¿DESEA ELIMINAR ESTE REGISTRO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ELIMINAR")

        If VALORMENSAJE = vbYes Then
            SC.Connection = conexion
            SC.CommandText = "DELETE FROM PROVEEDORES WHERE RUT_PROVEEDOR = '" & (txt_rut.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
        End If

        ACTUALIZAR_TABLA()
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            MOSTRAR(0)
        Else
            LIMPIAR()
        End If
    End Sub

    Private Sub BTN_CANCELAR_CLICK(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles btn_cancelar.Click
        CONTROLES(False, True)
        ACTUALIZAR_TABLA()
        MOSTRAR(0)
    End Sub

    Private Sub BTN_PRIMERO_CLICK(ByVal SENDER As Object, ByVal E As System.EventArgs)
        MiPos = 0
        MOSTRAR(0)
    End Sub

    Private Sub BTN_ANTERIOR_CLICK(ByVal SENDER As Object, ByVal E As System.EventArgs)
        If MiPos >= 1 Then
            MiPos -= 1
            MOSTRAR(MiPos)
        End If
    End Sub

    Private Sub BTN_SIGUIENTE_CLICK(ByVal SENDER As Object, ByVal E As System.EventArgs)
        If MiPos < DT.Rows.Count - 1 Then
            MiPos += 1
            MOSTRAR(MiPos)
        End If
    End Sub

    Private Sub BTN_ULTIMO_CLICK(ByVal SENDER As Object, ByVal E As System.EventArgs)
        MiPos = DT.Rows.Count - 1
        MOSTRAR(MiPos)
    End Sub

    Private Sub BTN_SALIR_CLICK(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub


    Private Sub BTN_IMPRIMIR_CLICK(ByVal SENDER As System.Object, ByVal E As System.EventArgs)
        Me.Enabled = False
        'DS.TABLES.CLEAR()
        'DT.ROWS.CLEAR()
        'DT.COLUMNS.CLEAR()
        'DS.CLEAR()

        'CONEXION.OPEN()

        'SC.CONNECTION = CONEXION
        'SC.COMMANDTEXT = "SELECT * FROM PROVEEDORES, EMPRESA WHERE RUT = '" & (TXT_RUT.TEXT) & "'"
        'DA.SELECTCOMMAND = SC
        'DA.FILL(DT)
        'DS.TABLES.ADD(DT)

        'Dim RPT As New CRYSTAL_PROVEEDORES_SISTEMA

        'RPT.SETDATASOURCE(DS.TABLES(DT.TABLENAME))
        'FORM_INFORME_PROVEEDORES.RPT_PROVEEDORES.REPORTSOURCE = RPT
        'FORM_INFORME_PROVEEDORES.SHOW()
        'CONEXION.CLOSE()
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.ShowDialog()
        Me.Enabled = True
    End Sub

    Sub ACTUALIZAR_TABLA()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "SELECT * FROM PROVEEDORES"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        conexion.Close()
    End Sub

    Private Sub TXT_TELEFONO_KEYPRESS(ByVal SENDER As Object, ByVal E As System.Windows.Forms.KeyPressEventArgs) Handles txt_telefono.KeyPress
        E.KeyChar = E.KeyChar.ToString.ToUpper

        If E.KeyChar = "'" Then
            E.KeyChar = "´"
        End If

        If E.KeyChar = "&" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = Chr(34) Then
            E.KeyChar = "´´"
        End If

        If E.KeyChar = "\" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = "|" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = "¿" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = "?" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = "}" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = "{" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = "<" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = ">" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = "*" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = "+" Then
            E.KeyChar = ""
        End If



        If Char.IsDigit(E.KeyChar) Then
            E.Handled = False
        ElseIf Char.IsControl(E.KeyChar) Then
            E.Handled = False
        Else
            E.Handled = True
        End If
    End Sub



    Private Sub TXT_CREDITO_KEYPRESS(ByVal SENDER As Object, ByVal E As System.Windows.Forms.KeyPressEventArgs) Handles txt_credito.KeyPress
        E.KeyChar = E.KeyChar.ToString.ToUpper

        If E.KeyChar = "'" Then
            E.KeyChar = "´"
        End If

        If E.KeyChar = "&" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = Chr(34) Then
            E.KeyChar = "´´"
        End If

        If E.KeyChar = "\" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = "|" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = "¿" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = "?" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = "}" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = "{" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = "<" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = ">" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = "*" Then
            E.KeyChar = ""
        End If

        If E.KeyChar = "+" Then
            E.KeyChar = ""
        End If



        If Char.IsDigit(E.KeyChar) Then
            E.Handled = False
        ElseIf Char.IsControl(E.KeyChar) Then
            E.Handled = False
        Else
            E.Handled = True
        End If
    End Sub

    Private Sub AYUDATOOLSTRIPMENUITEM_CLICK(ByVal SENDER As System.Object, ByVal E As System.EventArgs)
        Try
            Process.Start("C:\AYUDA MARKET DIGITAL\AYUDA MARKET DIGITAL.CHM")
        Catch
        End Try
    End Sub


    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font1 As New Font("arial", 11, FontStyle.Regular)
        Dim Font2 As New Font("arial", 12, FontStyle.Bold)
        Dim Font3 As New Font("arial", 7, FontStyle.Bold)
        Dim Font4 As New Font("arial", 8, FontStyle.Bold)

        Dim im As Image
        Try
            im = Image.FromFile("C:\Sistema de ventas\Logo de empresa\logo_ticket.jpg")
            Dim p As New PointF(535, 10)
            e.Graphics.DrawImage(im, p)
        Catch
        End Try

        Dim rect1 As New Rectangle(10, 15, 250, 15)
        Dim rect2 As New Rectangle(10, 30, 250, 15)
        Dim rect3 As New Rectangle(10, 45, 250, 15)
        Dim rect4 As New Rectangle(10, 60, 250, 15)
        Dim rect5 As New Rectangle(10, 75, 250, 15)
        Dim rect6 As New Rectangle(10, 90, 250, 15)
        Dim rect_titulo As New Rectangle(10, 130, 830, 30)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim stringFormat_logo As New StringFormat()
        stringFormat_logo.Alignment = StringAlignment.Center
        stringFormat_logo.LineAlignment = StringAlignment.Far

        e.Graphics.DrawString(migiroempresa, Font3, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawString(midireccionempresa, Font3, Brushes.Black, rect2, stringFormat)
        e.Graphics.DrawString(miciudadempresa, Font3, Brushes.Black, rect3, stringFormat)
        e.Graphics.DrawString(mitelefonoempresa, Font3, Brushes.Black, rect4, stringFormat)
        e.Graphics.DrawString(micorreoempresa, Font3, Brushes.Black, rect5, stringFormat)
        e.Graphics.DrawString(mirutempresa, Font3, Brushes.Black, rect6, stringFormat)

        e.Graphics.DrawString("DATOS PROVEEDOR", Font2, Brushes.Black, rect_titulo, stringFormat)

        e.Graphics.DrawLine(Pens.Black, 10, 160, 820, 160)

        e.Graphics.DrawString("RUT", Font1, Brushes.Black, 30, 200)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 200)
        e.Graphics.DrawString(txt_rut.Text, Font1, Brushes.Gray, 200, 200)
        e.Graphics.DrawString("NOMBRE", Font1, Brushes.Black, 30, 220)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 220)
        e.Graphics.DrawString(txt_nombre.Text, Font1, Brushes.Gray, 200, 220)
        e.Graphics.DrawString("DIRECCION", Font1, Brushes.Black, 30, 240)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 240)
        e.Graphics.DrawString(txt_direccion.Text, Font1, Brushes.Gray, 200, 240)
        e.Graphics.DrawString("TELEFONO", Font1, Brushes.Black, 30, 260)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 260)
        e.Graphics.DrawString(txt_telefono.Text, Font1, Brushes.Gray, 200, 260)
        e.Graphics.DrawString("EMAIL", Font1, Brushes.Black, 30, 280)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 280)
        e.Graphics.DrawString(txt_email.Text, Font1, Brushes.Gray, 200, 280)
        'e.Graphics.DrawString("CIUDAD", Font1, Brushes.Black, 30, 300)
        ' e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 300)
        ' e.Graphics.DrawString(txt_ciudad.Text, Font1, Brushes.Gray, 200, 300)
        e.Graphics.DrawString("COMUNA", Font1, Brushes.Black, 30, 320)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 320)
        e.Graphics.DrawString(txt_comuna.Text, Font1, Brushes.Gray, 200, 320)
        e.Graphics.DrawString("GIRO", Font1, Brushes.Black, 30, 340)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 340)
        e.Graphics.DrawString(txt_giro.Text, Font1, Brushes.Gray, 200, 340)
        e.Graphics.DrawString("REPRESENTANTE", Font1, Brushes.Black, 30, 360)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 360)
        e.Graphics.DrawString(txt_representante.Text, Font1, Brushes.Gray, 200, 360)
        e.Graphics.DrawString("CREDITO EN DIAS", Font1, Brushes.Black, 30, 380)
        e.Graphics.DrawString(":", Font1, Brushes.Black, 180, 380)
        e.Graphics.DrawString(txt_credito.Text, Font1, Brushes.Gray, 200, 380)

    End Sub





    Private Sub TXT_RUT_GOTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles txt_rut.GotFocus
        txt_rut.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub TXT_RUT_LOSTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles txt_rut.LostFocus
        txt_rut.BackColor = Color.White
    End Sub

    Private Sub TXT_NOMBRE_GOTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles txt_nombre.GotFocus
        txt_nombre.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_nombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nombre.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "|" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "¿" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "?" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "}" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "{" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "<" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = ">" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "*" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If


    End Sub

    Private Sub TXT_NOMBRE_LOSTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles txt_nombre.LostFocus
        txt_nombre.BackColor = Color.White
    End Sub

    Private Sub TXT_DIRECCION_GOTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles txt_direccion.GotFocus
        txt_direccion.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_direccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_direccion.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "|" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "¿" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "?" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "}" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "{" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "<" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = ">" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "*" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If


    End Sub

    Private Sub TXT_DIRECCION_LOSTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles txt_direccion.LostFocus
        txt_direccion.BackColor = Color.White
    End Sub

    Private Sub TXT_TELEFONO_GOTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles txt_telefono.GotFocus
        txt_telefono.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub TXT_TELEFONO_LOSTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles txt_telefono.LostFocus
        txt_telefono.BackColor = Color.White
    End Sub

    Private Sub TXT_EMAIL_GOTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles txt_email.GotFocus
        txt_email.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_email_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_email.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "|" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "¿" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "?" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "}" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "{" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "<" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = ">" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "*" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If


    End Sub

    Private Sub TXT_EMAIL_LOSTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles txt_email.LostFocus
        txt_email.BackColor = Color.White
    End Sub

    'Private Sub TXT_CIUDAD_GOTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs)
    '    txt_ciudad.BackColor = Color.LightSkyBlue
    'End Sub

    Private Sub txt_ciudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "|" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "¿" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "?" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "}" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "{" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "<" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = ">" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "*" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If


    End Sub

    'Private Sub TXT_CIUDAD_LOSTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs)
    '    txt_ciudad.BackColor = Color.White
    'End Sub

    Private Sub TXT_COMUNA_GOTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles txt_comuna.GotFocus
        txt_comuna.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_comuna_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_comuna.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "|" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "¿" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "?" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "}" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "{" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "<" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = ">" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "*" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If


    End Sub

    Private Sub TXT_COMUNA_LOSTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles txt_comuna.LostFocus
        txt_comuna.BackColor = Color.White
    End Sub

    Private Sub TXT_GIRO_GOTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles txt_giro.GotFocus
        txt_giro.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_giro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_giro.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "|" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "¿" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "?" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "}" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "{" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "<" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = ">" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "*" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If


    End Sub

    Private Sub TXT_GIRO_LOSTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles txt_giro.LostFocus
        txt_giro.BackColor = Color.White
    End Sub

    Private Sub TXT_REPRESENTANTE_GOTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles txt_representante.GotFocus
        txt_representante.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_representante_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_representante.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper

        If e.KeyChar = "'" Then
            e.KeyChar = "´"
        End If

        If e.KeyChar = "&" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = Chr(34) Then
            e.KeyChar = "´´"
        End If

        If e.KeyChar = "\" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "|" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "¿" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "?" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "}" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "{" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "<" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = ">" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "*" Then
            e.KeyChar = ""
        End If

        If e.KeyChar = "+" Then
            e.KeyChar = ""
        End If


    End Sub

    Private Sub TXT_REPRESENTANTE_LOSTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles txt_representante.LostFocus
        txt_representante.BackColor = Color.White
    End Sub

    Private Sub TXT_CREDITO_GOTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles txt_credito.GotFocus
        txt_credito.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub TXT_CREDITO_LOSTFOCUS(ByVal SENDER As Object, ByVal E As System.EventArgs) Handles txt_credito.LostFocus
        txt_credito.BackColor = Color.White
    End Sub



















    Private Sub btn_nuevo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.GotFocus
        btn_nuevo.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_nuevo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.LostFocus
        btn_nuevo.BackColor = Color.Transparent
    End Sub

    Private Sub btn_modificar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.GotFocus
        btn_modificar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_modificar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.LostFocus
        btn_modificar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_eliminar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.GotFocus
        btn_eliminar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_eliminar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.LostFocus
        btn_eliminar.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
    '    btn_buscar.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
    '    btn_buscar.BackColor = Color.WhiteSmoke
    'End Sub

    'Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_imprimir.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_imprimir.BackColor = Color.WhiteSmoke
    'End Sub

    Private Sub btn_guardar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.GotFocus
        btn_guardar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_guardar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.LostFocus
        btn_guardar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_cancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.GotFocus
        btn_cancelar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_cancelar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.LostFocus
        btn_cancelar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    'Private Sub btn_primero_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_primero.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_primero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_primero.BackColor = Color.WhiteSmoke
    'End Sub

    'Private Sub btn_anterior_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_anterior.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_anterior_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_anterior.BackColor = Color.WhiteSmoke
    'End Sub

    'Private Sub btn_siguiente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_siguiente.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_siguiente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_siguiente.BackColor = Color.WhiteSmoke
    'End Sub

    'Private Sub btn_ultimo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_ultimo.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_ultimo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btn_ultimo.BackColor = Color.WhiteSmoke
    'End Sub

    Private Sub txt_nombre_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nombre.LostFocus
        txt_nombre.BackColor = Color.White
    End Sub

    Private Sub Form_registro_proveedores_compra_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F3 Then
            Dim forms As FormCollection = Application.OpenForms
            Dim i As Integer
            For i = 0 To forms.Count - 1
                Try
                    For Each form As Form In forms
                        If TypeOf form Is Form_menu_principal Then

                        Else
                            form.Close()
                        End If
                    Next
                Catch err As InvalidOperationException
                End Try
            Next i
            mostrar_cierre_sistema()
            Form_menu_principal.Close()
        End If
    End Sub

    Private Sub txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rut.TextChanged

    End Sub

    Private Sub txt_nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nombre.TextChanged

    End Sub

    Private Sub txt_direccion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_direccion.TextChanged

    End Sub

    Private Sub txt_telefono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_telefono.TextChanged

    End Sub

    Private Sub txt_email_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_email.TextChanged

    End Sub

    Private Sub txt_ciudad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_comuna_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_comuna.TextChanged

    End Sub

    Private Sub txt_giro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_giro.TextChanged

    End Sub

    Private Sub txt_representante_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_representante.TextChanged

    End Sub

    Private Sub txt_credito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_credito.TextChanged

    End Sub


    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Form_buscador_proveedores_compras.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub
End Class