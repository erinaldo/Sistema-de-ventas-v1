Public Class Form_listados

    Private Sub Form_listados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_listados_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_listados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        combo_listado.SelectedItem = "-"
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub llenar_combo_campos()
        conexion.Close()
        CheckedListBox_campos.Items.Clear()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()
        SC3.Connection = conexion
        SC3.CommandText = "select * from tipo_pallet order by tipo_pallet"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)
        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                CheckedListBox_campos.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("tipo_pallet"))
            Next
        End If
        conexion.Close()
    End Sub

    Sub mostrar_malla_familia()
        Dim ordenar_por As String = ""
        Dim forma_ordenar As String = ""

        If Combo_forma.Text = "ASCENDENTE" Then
            forma_ordenar = "ASC"
        End If

        If Combo_forma.Text = "DESCENDENTE" Then
            forma_ordenar = "DESC"
        End If

        If Combo_campos.Text = "CODIGO" Then
            ordenar_por = "codigo"
        End If

        If Combo_campos.Text = "FAMILIA" Then
            ordenar_por = "nombre_familia"
        End If

        ordenar_por = ordenar_por & " " & forma_ordenar

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select codigo, nombre_familia from familia order by " & (ordenar_por) & ""
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_libro_compras.Rows.Clear()
        grilla_libro_compras.Columns.Clear()
        grilla_libro_compras.Columns.Add("", "CODIGO")
        grilla_libro_compras.Columns.Add("", "FAMILIA")

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_libro_compras.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("codigo"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("nombre_familia"))
            Next
        End If

        If grilla_libro_compras.Rows.Count <> 0 Then
            If grilla_libro_compras.Columns(0).Width = 100 Then
                grilla_libro_compras.Columns(0).Width = 99
            Else
                grilla_libro_compras.Columns(0).Width = 100
            End If
            grilla_libro_compras.Columns(1).Width = 250
            grilla_libro_compras.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        Dim eliminados As Integer = 0
        For i = 0 To (CheckedListBox_campos.Items.Count - 1)
            If CheckedListBox_campos.GetItemChecked(i) = False Then
                grilla_libro_compras.Columns.RemoveAt(eliminados)
                eliminados = eliminados - 1
            End If
            eliminados = eliminados + 1
        Next
    End Sub

    Sub mostrar_malla_subfamilia()
        Dim ordenar_por As String = ""
        Dim forma_ordenar As String = ""

        If Combo_forma.Text = "ASCENDENTE" Then
            forma_ordenar = "ASC"
        End If

        If Combo_forma.Text = "DESCENDENTE" Then
            forma_ordenar = "DESC"
        End If

        If Combo_campos.Text = "COD. FAM." Then
            ordenar_por = "codigo_familia"
        End If

        If Combo_campos.Text = "COD. SUBFAM." Then
            ordenar_por = "cod_auto"
        End If

        If Combo_campos.Text = "SUBFAMILIA" Then
            ordenar_por = "nombre_subfamilia"
        End If

        ordenar_por = ordenar_por & " " & forma_ordenar

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select codigo_familia, cod_auto, nombre_subfamilia from subfamilia order by " & (ordenar_por) & ""
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_libro_compras.Rows.Clear()
        grilla_libro_compras.Columns.Clear()

        grilla_libro_compras.Columns.Add("", "COD. FAM.")
        grilla_libro_compras.Columns.Add("", "COD. SUBFAM.")
        grilla_libro_compras.Columns.Add("", "SUBFAMILIA")
        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_libro_compras.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("codigo_familia"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("cod_auto"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("nombre_subfamilia"))
            Next
        End If

        If grilla_libro_compras.Rows.Count <> 0 Then
            If grilla_libro_compras.Columns(0).Width = 100 Then
                grilla_libro_compras.Columns(0).Width = 99
            Else
                grilla_libro_compras.Columns(0).Width = 100
            End If
            grilla_libro_compras.Columns(1).Width = 100
            grilla_libro_compras.Columns(2).Width = 250

            grilla_libro_compras.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        Dim eliminados As Integer = 0
        For i = 0 To (CheckedListBox_campos.Items.Count - 1)
            If CheckedListBox_campos.GetItemChecked(i) = False Then
                grilla_libro_compras.Columns.RemoveAt(eliminados)
                eliminados = eliminados - 1
            End If
            eliminados = eliminados + 1
        Next
    End Sub

    Sub mostrar_malla_subfamilia2()
        Dim ordenar_por As String = ""
        Dim forma_ordenar As String = ""

        If Combo_forma.Text = "ASCENDENTE" Then
            forma_ordenar = "ASC"
        End If

        If Combo_forma.Text = "DESCENDENTE" Then
            forma_ordenar = "DESC"
        End If

        If Combo_campos.Text = "COD. SUBFAMILIA DOS" Then
            ordenar_por = "cod_auto"
        End If

        If Combo_campos.Text = "COD. SUBFAMILIA" Then
            ordenar_por = "nombre_subfamilia"
        End If

        If Combo_campos.Text = "SUBFAMILIA DOS" Then
            ordenar_por = "nombre_subfamilia"
        End If

        If Combo_campos.Text = "M" Then
            ordenar_por = "m"
        End If

        If Combo_campos.Text = "O" Then
            ordenar_por = "o"
        End If

        ordenar_por = ordenar_por & " " & forma_ordenar

        If mirutempresa <> "87686300-6" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select cod_auto, codigo_subfamilia, nombre_subfamilia subfamilia_dos order by " & (ordenar_por) & ""
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_libro_compras.Rows.Clear()
            grilla_libro_compras.Columns.Clear()
            grilla_libro_compras.Columns.Add("", "COD. SUBFAM. DOS")
            grilla_libro_compras.Columns.Add("", "COD. SUBFAM.")
            grilla_libro_compras.Columns.Add("", "SUBFAMILIA DOS")
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_libro_compras.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_auto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("codigo_subfamilia"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("nombre_subfamilia"))
                Next
            End If

            If grilla_libro_compras.Rows.Count <> 0 Then
                If grilla_libro_compras.Columns(0).Width = 100 Then
                    grilla_libro_compras.Columns(0).Width = 99
                Else
                    grilla_libro_compras.Columns(0).Width = 100
                End If
                grilla_libro_compras.Columns(1).Width = 100
                grilla_libro_compras.Columns(2).Width = 250
                grilla_libro_compras.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                grilla_libro_compras.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                grilla_libro_compras.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End If
        End If


        If mirutempresa = "87686300-6" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            SC.Connection = conexion
            SC.CommandText = "select cod_auto, codigo_subfamilia, nombre_subfamilia, m, o from subfamilia_dos WHERE nombre_subfamilia <> '0'  order by " & (ordenar_por) & ""
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            grilla_libro_compras.Rows.Clear()
            grilla_libro_compras.Columns.Clear()
            grilla_libro_compras.Columns.Add("", "COD. SUBFAM. DOS")
            grilla_libro_compras.Columns.Add("", "COD. SUBFAM.")
            grilla_libro_compras.Columns.Add("", "SUBFAMILIA DOS")
            grilla_libro_compras.Columns.Add("", "M")
            grilla_libro_compras.Columns.Add("", "O")
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_libro_compras.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_auto"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("codigo_subfamilia"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("nombre_subfamilia"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("m"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("o"))
                Next
            End If

            If grilla_libro_compras.Rows.Count <> 0 Then
                If grilla_libro_compras.Columns(0).Width = 100 Then
                    grilla_libro_compras.Columns(0).Width = 99
                Else
                    grilla_libro_compras.Columns(0).Width = 100
                End If
                grilla_libro_compras.Columns(1).Width = 100
                grilla_libro_compras.Columns(2).Width = 250
                grilla_libro_compras.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                grilla_libro_compras.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                grilla_libro_compras.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End If
        End If

        Dim eliminados As Integer = 0
        For i = 0 To (CheckedListBox_campos.Items.Count - 1)
            If CheckedListBox_campos.GetItemChecked(i) = False Then
                grilla_libro_compras.Columns.RemoveAt(eliminados)
                eliminados = eliminados - 1
            End If
            eliminados = eliminados + 1
        Next
    End Sub

    Sub mostrar_malla_clientes()
        Dim ordenar_por As String = ""
        Dim forma_ordenar As String = ""

        If Combo_forma.Text = "ASCENDENTE" Then
            forma_ordenar = "ASC"
        End If

        If Combo_forma.Text = "DESCENDENTE" Then
            forma_ordenar = "DESC"
        End If

        If Combo_campos.Text = "CODIGO" Then
            ordenar_por = "cod_cliente"
        End If
        If Combo_campos.Text = "RUT" Then
            ordenar_por = "rut_cliente"
        End If
        If Combo_campos.Text = "NOMBRE" Then
            ordenar_por = "nombre_cliente"
        End If
        If Combo_campos.Text = "DIRECCION" Then
            ordenar_por = "direccion_cliente"
        End If
        If Combo_campos.Text = "COMUNA" Then
            ordenar_por = "comuna_cliente"
        End If
        If Combo_campos.Text = "TELEFONO" Then
            ordenar_por = "telefono_cliente"
        End If
        If Combo_campos.Text = "GIRO" Then
            ordenar_por = "giro_cliente"
        End If
        If Combo_campos.Text = "EMAIL" Then
            ordenar_por = "email_cliente"
        End If
        If Combo_campos.Text = "DESCUENTO 1" Then
            ordenar_por = "descuento_1"
        End If
        If Combo_campos.Text = "DESCUENTO 2" Then
            ordenar_por = "descuento_2"
        End If
        If Combo_campos.Text = "DOCUMENTO" Then
            ordenar_por = "tipo_cuenta"
        End If
        If Combo_campos.Text = "ESTADO CUENTA" Then
            ordenar_por = "estado_cuenta"
        End If
        If Combo_campos.Text = "FOLIO CLIENTE" Then
            ordenar_por = "folio_cliente"
        End If
        If Combo_campos.Text = "ORDEN DE COMPRA" Then
            ordenar_por = "orden_de_compra"
        End If
        If Combo_campos.Text = "MENSAJE" Then
            ordenar_por = "mensaje"
        End If

        ordenar_por = ordenar_por & " " & forma_ordenar

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from clientes order by " & (ordenar_por) & ""
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_libro_compras.Rows.Clear()
        grilla_libro_compras.Columns.Clear()
        grilla_libro_compras.Columns.Add("", "CODIGO")
        grilla_libro_compras.Columns.Add("", "RUT")
        grilla_libro_compras.Columns.Add("", "NOMBRE")
        grilla_libro_compras.Columns.Add("", "DIRECCION")
        grilla_libro_compras.Columns.Add("", "COMUNA")
        grilla_libro_compras.Columns.Add("", "TELEFONO")
        grilla_libro_compras.Columns.Add("", "GIRO")
        grilla_libro_compras.Columns.Add("", "EMAIL")
        grilla_libro_compras.Columns.Add("", "DESCUENTO 1")
        grilla_libro_compras.Columns.Add("", "DESCUENTO 2")
        grilla_libro_compras.Columns.Add("", "DOCUMENTO")
        grilla_libro_compras.Columns.Add("", "ESTADO CUENTA")
        grilla_libro_compras.Columns.Add("", "FOLIO CLIENTE")
        grilla_libro_compras.Columns.Add("", "ORDEN DE COMPRA")
        grilla_libro_compras.Columns.Add("", "MENSAJE")

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_libro_compras.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_cliente"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("rut_cliente"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("nombre_cliente"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("direccion_cliente"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("comuna_cliente"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("telefono_cliente"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("giro_cliente"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("email_cliente"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("descuento_1"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("descuento_2"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("tipo_cuenta"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("estado_cuenta"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("folio_cliente"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("orden_de_compra"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("mensaje"))
            Next
        End If

        If grilla_libro_compras.Rows.Count <> 0 Then
            If grilla_libro_compras.Columns(0).Width = 100 Then
                grilla_libro_compras.Columns(0).Width = 99
            Else
                grilla_libro_compras.Columns(0).Width = 100
            End If
            grilla_libro_compras.Columns(1).Width = 100
            grilla_libro_compras.Columns(2).Width = 250
            grilla_libro_compras.Columns(3).Width = 100
            grilla_libro_compras.Columns(4).Width = 100
            grilla_libro_compras.Columns(5).Width = 100
            grilla_libro_compras.Columns(6).Width = 100
            grilla_libro_compras.Columns(7).Width = 100
            grilla_libro_compras.Columns(8).Width = 100
            grilla_libro_compras.Columns(9).Width = 100
            grilla_libro_compras.Columns(10).Width = 100
            grilla_libro_compras.Columns(11).Width = 100
            grilla_libro_compras.Columns(12).Width = 100
            grilla_libro_compras.Columns(13).Width = 100
            grilla_libro_compras.Columns(14).Width = 100
            grilla_libro_compras.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        Dim eliminados As Integer = 0
        For i = 0 To (CheckedListBox_campos.Items.Count - 1)
            If CheckedListBox_campos.GetItemChecked(i) = False Then
                grilla_libro_compras.Columns.RemoveAt(eliminados)
                eliminados = eliminados - 1
            End If
            eliminados = eliminados + 1
        Next
    End Sub

    Sub mostrar_malla_productos()
        Dim ordenar_por As String = ""
        Dim forma_ordenar As String = ""

        If Combo_forma.Text = "ASCENDENTE" Then
            forma_ordenar = "ASC"
        End If

        If Combo_forma.Text = "DESCENDENTE" Then
            forma_ordenar = "DESC"
        End If




        If Combo_campos.Text = "CODIGO" Then
            ordenar_por = "cod_producto"
        End If
        If Combo_campos.Text = "NOMBRE" Then
            ordenar_por = "nombre"
        End If
        If Combo_campos.Text = "MARCA" Then
            ordenar_por = "marca"
        End If
        If Combo_campos.Text = "APLICACION" Then
            ordenar_por = "aplicacion"
        End If
        If Combo_campos.Text = "CANTIDAD" Then
            ordenar_por = "cantidad"
        End If
        If Combo_campos.Text = "PRECIO" Then
            ordenar_por = "precio"
        End If
        If Combo_campos.Text = "COSTO" Then
            ordenar_por = "costo"
        End If
        If Combo_campos.Text = "FACTOR" Then
            ordenar_por = "factor"
        End If
        If Combo_campos.Text = "NRO. TECNICO" Then
            ordenar_por = "numero_tecnico"
        End If
        If Combo_campos.Text = "CANT. MIN." Then
            ordenar_por = "cantidad_minima"
        End If
        If Combo_campos.Text = "PROVEEDOR" Then
            ordenar_por = "proveedor"
        End If
        If Combo_campos.Text = "MARGEN" Then
            ordenar_por = "margen"
        End If
        If Combo_campos.Text = "FAMILIA" Then
            ordenar_por = "familia"
        End If
        If Combo_campos.Text = "SUBFAMILIA" Then
            ordenar_por = "subfamilia"
        End If
        If Combo_campos.Text = "SUBFAMILIA DOS" Then
            ordenar_por = "subfamilia_dos"
        End If
        If Combo_campos.Text = "DOC. COMPRA" Then
            ordenar_por = "tipo_doc"
        End If
        If Combo_campos.Text = "NRO. DOC." Then
            ordenar_por = "nro_doc"
        End If
        If Combo_campos.Text = "ULT. COM." Then
            ordenar_por = "ultima_compra"
        End If
        If Combo_campos.Text = "ACTIVO" Then
            ordenar_por = "activo"
        End If


        ordenar_por = ordenar_por & " " & forma_ordenar

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from productos order by " & (ordenar_por) & ""
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_libro_compras.Rows.Clear()
        grilla_libro_compras.Columns.Clear()
        grilla_libro_compras.Columns.Add("", "CODIGO")
        grilla_libro_compras.Columns.Add("", "NOMBRE")
        grilla_libro_compras.Columns.Add("", "MARCA")
        grilla_libro_compras.Columns.Add("", "APLICACION")
        grilla_libro_compras.Columns.Add("", "CANTIDAD")
        grilla_libro_compras.Columns.Add("", "PRECIO")
        grilla_libro_compras.Columns.Add("", "COSTO")
        grilla_libro_compras.Columns.Add("", "FACTOR")
        grilla_libro_compras.Columns.Add("", "NRO. TECNICO")
        grilla_libro_compras.Columns.Add("", "CANT. MIN.")
        grilla_libro_compras.Columns.Add("", "PROVEEDOR")
        grilla_libro_compras.Columns.Add("", "MARGEN")
        grilla_libro_compras.Columns.Add("", "FAMILIA")
        grilla_libro_compras.Columns.Add("", "SUBFAMILIA")
        grilla_libro_compras.Columns.Add("", "SUBFAMILIA DOS")
        grilla_libro_compras.Columns.Add("", "DOC. COMPRA")
        grilla_libro_compras.Columns.Add("", "NRO. DOC.")
        grilla_libro_compras.Columns.Add("", "ULT. COM.")
        grilla_libro_compras.Columns.Add("", "ACTIVO")

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_libro_compras.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                               DS.Tables(DT.TableName).Rows(i).Item("nombre"), _
                                                DS.Tables(DT.TableName).Rows(i).Item("marca"), _
                                                 DS.Tables(DT.TableName).Rows(i).Item("aplicacion"), _
                                                  DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                   DS.Tables(DT.TableName).Rows(i).Item("precio"), _
                                                    DS.Tables(DT.TableName).Rows(i).Item("costo"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("factor"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("cantidad_minima"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("proveedor"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("margen"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("familia"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("subfamilia"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("subfamilia_dos"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("tipo_doc"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("nro_doc"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("ultima_compra"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("activo"))
            Next
        End If

        If grilla_libro_compras.Rows.Count <> 0 Then
            If grilla_libro_compras.Columns(0).Width = 100 Then
                grilla_libro_compras.Columns(0).Width = 99
            Else
                grilla_libro_compras.Columns(0).Width = 100
            End If
            grilla_libro_compras.Columns(0).Width = 100
            grilla_libro_compras.Columns(1).Width = 250
            grilla_libro_compras.Columns(2).Width = 100
            grilla_libro_compras.Columns(3).Width = 100
            grilla_libro_compras.Columns(4).Width = 100
            grilla_libro_compras.Columns(5).Width = 100
            grilla_libro_compras.Columns(6).Width = 100
            grilla_libro_compras.Columns(7).Width = 100
            grilla_libro_compras.Columns(8).Width = 100
            grilla_libro_compras.Columns(9).Width = 100
            grilla_libro_compras.Columns(10).Width = 100
            grilla_libro_compras.Columns(11).Width = 100
            grilla_libro_compras.Columns(12).Width = 100
            grilla_libro_compras.Columns(13).Width = 100
            grilla_libro_compras.Columns(14).Width = 100
            grilla_libro_compras.Columns(15).Width = 100
            grilla_libro_compras.Columns(16).Width = 100
            grilla_libro_compras.Columns(18).Width = 100
            ' grilla_libro_compras.Columns(19).Width = 100
            grilla_libro_compras.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_libro_compras.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_libro_compras.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        Dim eliminados As Integer = 0
        For i = 0 To (CheckedListBox_campos.Items.Count - 1)
            If CheckedListBox_campos.GetItemChecked(i) = False Then
                grilla_libro_compras.Columns.RemoveAt(eliminados)
                eliminados = eliminados - 1
            End If
            eliminados = eliminados + 1
        Next
    End Sub


    Sub mostrar_malla_proveedor()
        Dim ordenar_por As String = ""
        Dim forma_ordenar As String = ""

        If Combo_forma.Text = "ASCENDENTE" Then
            forma_ordenar = "ASC"
        End If

        If Combo_forma.Text = "DESCENDENTE" Then
            forma_ordenar = "DESC"
        End If

        If Combo_campos.Text = "RUT" Then
            ordenar_por = "rut_proveedor"
        End If
        If Combo_campos.Text = "NOMBRE" Then
            ordenar_por = "nombre_proveedor"
        End If
        If Combo_campos.Text = "DIRECCION" Then
            ordenar_por = "direccion_proveedor"
        End If
        If Combo_campos.Text = "COMUNA" Then
            ordenar_por = "comuna_proveedor"
        End If
        If Combo_campos.Text = "CIUDAD" Then
            ordenar_por = "ciudad_proveedor"
        End If
        If Combo_campos.Text = "TELEFONO" Then
            ordenar_por = "telefono_proveedor"
        End If
        If Combo_campos.Text = "EMAIL" Then
            ordenar_por = "email_proveedor"
        End If
        If Combo_campos.Text = "GIRO" Then
            ordenar_por = "giro_proveedor"
        End If
        If Combo_campos.Text = "REPRESENTANTE" Then
            ordenar_por = "representante_proveedor"
        End If
        If Combo_campos.Text = "CREDITO" Then
            ordenar_por = "credito_proveedor"
        End If


        ordenar_por = ordenar_por & " " & forma_ordenar

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from proveedores order by " & (ordenar_por) & ""
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_libro_compras.Rows.Clear()
        grilla_libro_compras.Columns.Clear()

        grilla_libro_compras.Columns.Add("", "RUT_PROVEEDOR")
        grilla_libro_compras.Columns.Add("", "NOMBRE")
        grilla_libro_compras.Columns.Add("", "DIRECCION")
        grilla_libro_compras.Columns.Add("", "CIUDAD")
        grilla_libro_compras.Columns.Add("", "COMUNA")
        grilla_libro_compras.Columns.Add("", "TELEFONO")
        grilla_libro_compras.Columns.Add("", "EMAIL")
        grilla_libro_compras.Columns.Add("", "GIRO")
        grilla_libro_compras.Columns.Add("", "REPRESENTANTE")
        grilla_libro_compras.Columns.Add("", "CREDITO")

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                grilla_libro_compras.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("rut_proveedor"),
                                               DS.Tables(DT.TableName).Rows(i).Item("nombrE_proveedor"),
                                                DS.Tables(DT.TableName).Rows(i).Item("direccion_proveedor"),
                                                 DS.Tables(DT.TableName).Rows(i).Item("ciudad_proveedor"),
                                                  DS.Tables(DT.TableName).Rows(i).Item("comuna_proveedor"),
                                                   DS.Tables(DT.TableName).Rows(i).Item("telefono_proveedor"),
                                                    DS.Tables(DT.TableName).Rows(i).Item("email_proveedor"),
                                                     DS.Tables(DT.TableName).Rows(i).Item("giro_proveedor"),
                                                      DS.Tables(DT.TableName).Rows(i).Item("representante_proveedor"),
                                                       DS.Tables(DT.TableName).Rows(i).Item("credito_proveedor"))
            Next
        End If

        If grilla_libro_compras.Rows.Count <> 0 Then
            If grilla_libro_compras.Columns(0).Width = 100 Then
                grilla_libro_compras.Columns(0).Width = 99
            Else
                grilla_libro_compras.Columns(0).Width = 100
            End If
            grilla_libro_compras.Columns(0).Width = 100
            grilla_libro_compras.Columns(1).Width = 250
            grilla_libro_compras.Columns(2).Width = 250
            grilla_libro_compras.Columns(3).Width = 100
            grilla_libro_compras.Columns(4).Width = 100
            grilla_libro_compras.Columns(5).Width = 100
            grilla_libro_compras.Columns(6).Width = 100
            grilla_libro_compras.Columns(7).Width = 100
            grilla_libro_compras.Columns(8).Width = 100
            grilla_libro_compras.Columns(9).Width = 100

            grilla_libro_compras.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

        Dim eliminados As Integer = 0
        For i = 0 To (CheckedListBox_campos.Items.Count - 1)
            If CheckedListBox_campos.GetItemChecked(i) = False Then
                grilla_libro_compras.Columns.RemoveAt(eliminados)
                eliminados = eliminados - 1
            End If
            eliminados = eliminados + 1
        Next
    End Sub


    Sub mostrar_malla_creditos()
        Dim ordenar_por As String = ""
        Dim forma_ordenar As String = ""

        If Combo_forma.Text = "ASCENDENTE" Then
            forma_ordenar = "ASC"
        End If

        If Combo_forma.Text = "DESCENDENTE" Then
            forma_ordenar = "DESC"
        End If

        If Combo_campos.Text = "CODIGO" Then
            ordenar_por = "cod_auto"
        End If
        If Combo_campos.Text = "N. CREDITO" Then
            ordenar_por = "n_creditos"
        End If
        If Combo_campos.Text = "TIPO DETALLE" Then
            ordenar_por = "tipo_detalle"
        End If
        If Combo_campos.Text = "COD. CLIENTE" Then
            ordenar_por = "codigo_cliente"
        End If
        If Combo_campos.Text = "RUT CLIENTE" Then
            ordenar_por = "rut_cliente"
        End If
        If Combo_campos.Text = "FECHA VENTA" Then
            ordenar_por = "fecha_venta"
        End If
        If Combo_campos.Text = "TOTAL" Then
            ordenar_por = "total"
        End If
        If Combo_campos.Text = "SALDO" Then
            ordenar_por = "saldo"
        End If
        If Combo_campos.Text = "CONDICION" Then
            ordenar_por = "condiciones"
        End If
        If Combo_campos.Text = "ESTADO" Then
            ordenar_por = "estado"
        End If
        If Combo_campos.Text = "RECINTO" Then
            ordenar_por = "recinto"
        End If
        If Combo_campos.Text = "VENCIMIENTO" Then
            ordenar_por = "fech_vencimiento"
        End If
        If Combo_campos.Text = "PAGO" Then
            ordenar_por = "fecha_pago"
        End If
        If Combo_campos.Text = "RESPONSABLE" Then
            ordenar_por = "usuario_responsable"
        End If

        ordenar_por = ordenar_por & " " & forma_ordenar

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select * from creditos order by " & (ordenar_por) & ""
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_libro_compras.Rows.Clear()
        grilla_libro_compras.Columns.Clear()

        grilla_libro_compras.Columns.Add("", "CODIGO")
        grilla_libro_compras.Columns.Add("", "N. CREDITO")
        grilla_libro_compras.Columns.Add("", "TIPO DETALLE")
        grilla_libro_compras.Columns.Add("", "COD. CLIENTE")
        grilla_libro_compras.Columns.Add("", "RUT CLIENTE")
        grilla_libro_compras.Columns.Add("", "FECHA VENTA")
        grilla_libro_compras.Columns.Add("", "TOTAL")
        grilla_libro_compras.Columns.Add("", "SALDO")
        grilla_libro_compras.Columns.Add("", "CONDICION")
        grilla_libro_compras.Columns.Add("", "ESTADO")
        grilla_libro_compras.Columns.Add("", "RECINTO")
        grilla_libro_compras.Columns.Add("", "VENCIMIENTO")
        grilla_libro_compras.Columns.Add("", "PAGO")
        grilla_libro_compras.Columns.Add("", "RESPONSABLE")

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim fecha_vencimiento As String
                Try
                    fecha_vencimiento = DS.Tables(DT.TableName).Rows(i).Item("fecha_vencimiento")
                    If fecha_vencimiento.Length > 10 Then
                        fecha_vencimiento = fecha_vencimiento.Substring(0, 10)
                    End If
                Catch
                    fecha_vencimiento = "00-00-0000"
                End Try

                Dim fecha_pago As String
                Try
                    fecha_pago = DS.Tables(DT.TableName).Rows(i).Item("fecha_pago")
                    If fecha_pago.Length > 10 Then
                        fecha_pago = fecha_pago.Substring(0, 10)
                    End If
                Catch
                    fecha_pago = "00-00-0000"
                End Try

                If fecha_vencimiento = "0:00:00" Then
                    fecha_vencimiento = "00-00-0000"
                End If

                If fecha_pago = "0:00:00" Then
                    fecha_pago = "00-00-0000"
                End If

                grilla_libro_compras.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cod_auto"),
                                               DS.Tables(DT.TableName).Rows(i).Item("n_creditos"),
                                                DS.Tables(DT.TableName).Rows(i).Item("tipo_detalle"),
                                                 DS.Tables(DT.TableName).Rows(i).Item("codigo_cliente"),
                                                  DS.Tables(DT.TableName).Rows(i).Item("rut_cliente"),
                                                   DS.Tables(DT.TableName).Rows(i).Item("fecha_venta"),
                                                    DS.Tables(DT.TableName).Rows(i).Item("total"),
                                                     DS.Tables(DT.TableName).Rows(i).Item("saldo"),
                                                      DS.Tables(DT.TableName).Rows(i).Item("condiciones"),
                                                       DS.Tables(DT.TableName).Rows(i).Item("estado"),
                                                        DS.Tables(DT.TableName).Rows(i).Item("recinto"),
                                                         fecha_vencimiento,
                                                          fecha_pago,
                                                           DS.Tables(DT.TableName).Rows(i).Item("usuario_responsable"))
            Next
        End If

        If grilla_libro_compras.Rows.Count <> 0 Then
            If grilla_libro_compras.Columns(0).Width = 100 Then
                grilla_libro_compras.Columns(0).Width = 99
            Else
                grilla_libro_compras.Columns(0).Width = 100
            End If
            grilla_libro_compras.Columns(0).Width = 100
            grilla_libro_compras.Columns(1).Width = 100
            grilla_libro_compras.Columns(2).Width = 100
            grilla_libro_compras.Columns(3).Width = 100
            grilla_libro_compras.Columns(4).Width = 100
            grilla_libro_compras.Columns(5).Width = 100
            grilla_libro_compras.Columns(6).Width = 100
            grilla_libro_compras.Columns(7).Width = 100
            grilla_libro_compras.Columns(8).Width = 100
            grilla_libro_compras.Columns(9).Width = 100
            grilla_libro_compras.Columns(10).Width = 100
            grilla_libro_compras.Columns(11).Width = 100
            grilla_libro_compras.Columns(12).Width = 100
            grilla_libro_compras.Columns(13).Width = 100

            grilla_libro_compras.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_libro_compras.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_libro_compras.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_libro_compras.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_libro_compras.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_libro_compras.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_libro_compras.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        Dim eliminados As Integer = 0
        For i = 0 To (CheckedListBox_campos.Items.Count - 1)
            If CheckedListBox_campos.GetItemChecked(i) = False Then
                grilla_libro_compras.Columns.RemoveAt(eliminados)
                eliminados = eliminados - 1
            End If
            eliminados = eliminados + 1
        Next
    End Sub



    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        If grilla_libro_compras.Rows.Count = 0 Then
            combo_listado.Focus()
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_libro_compras, save.FileName)
        End If

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub



    Public Sub Exportar_Excel(ByVal dgv As DataGridView, ByVal pth As String)

        Dim xlApp As Object = CreateObject("Excel.Application")
        'crear una nueva hoja de calculo 
        Dim xlWB As Object = xlApp.WorkBooks.add
        Dim xlWS As Object = xlWB.WorkSheets(1)

        'exportamos los caracteres de las columnas 
        For c As Integer = 0 To grilla_libro_compras.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_libro_compras.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_libro_compras.RowCount - 1
            For c As Integer = 0 To grilla_libro_compras.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_libro_compras.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        If combo_listado.Text = "-" Then
            MsgBox("CAMPO TIPO LISTADO VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_listado.Focus()
            Exit Sub
        End If

        If Combo_campos.Text = "-" Then
            MsgBox("CAMPO ORDENAR POR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_campos.Focus()
            Exit Sub
        End If

        If Combo_forma.Text = "-" Then
            MsgBox("CAMPO FORMA DE ORDENAR POR VACIO, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Combo_forma.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        If combo_listado.Text = "FAMILIAS" Then
            mostrar_malla_familia()
        End If

        If combo_listado.Text = "SUBFAMILIAS" Then
            mostrar_malla_subfamilia()
        End If

        If combo_listado.Text = "SUBFAMILIAS DOS" Then
            mostrar_malla_subfamilia2()
        End If

        If combo_listado.Text = "CLIENTES" Then
            mostrar_malla_clientes()
        End If

        If combo_listado.Text = "PRODUCTOS" Then
            mostrar_malla_productos()
        End If

        If combo_listado.Text = "CREDITOS" Then
            mostrar_malla_creditos()
        End If

        If combo_listado.Text = "PROVEEDORES" Then
            mostrar_malla_proveedor()
        End If

        txt_registros.Text = grilla_libro_compras.Rows.Count
        If txt_registros.Text = "" Or txt_registros.Text = "0" Then
            txt_registros.Text = "0"
        Else
            txt_registros.Text = Format(Int(txt_registros.Text), "###,###,###")
        End If

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then
            grilla_libro_compras.Columns.Clear()
            CheckedListBox_campos.Items.Clear()
            txt_registros.Text = "0"
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub combo_listado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_listado.SelectedIndexChanged
        grilla_libro_compras.Columns.Clear()
        txt_registros.Text = "0"
        If combo_listado.Text = "-" Then
            CheckedListBox_campos.Items.Clear()
            Combo_campos.Items.Clear()
            Combo_campos.Items.Add("-")
        End If

        If combo_listado.Text = "FAMILIAS" Then
            CheckedListBox_campos.Items.Clear()
            CheckedListBox_campos.Items.Add("CODIGO")
            CheckedListBox_campos.Items.Add("FAMILIA")

            Combo_campos.Items.Clear()
            Combo_campos.Items.Add("-")
            Combo_campos.Items.Add("CODIGO")
            Combo_campos.Items.Add("FAMILIA")
        End If


        If combo_listado.Text = "SUBFAMILIAS" Then
            CheckedListBox_campos.Items.Clear()
            CheckedListBox_campos.Items.Add("COD. FAM.")
            CheckedListBox_campos.Items.Add("COD. SUBFAM.")
            CheckedListBox_campos.Items.Add("SUBFAMILIA")

            Combo_campos.Items.Clear()
            Combo_campos.Items.Add("-")
            Combo_campos.Items.Add("COD. FAM.")
            Combo_campos.Items.Add("COD. SUBFAM.")
            Combo_campos.Items.Add("SUBFAMILIA")
        End If



        If mirutempresa <> "87686300-6" Then
            If combo_listado.Text = "SUBFAMILIAS DOS" Then
                CheckedListBox_campos.Items.Clear()
                CheckedListBox_campos.Items.Add("COD. SUBFAMILIA DOS")
                CheckedListBox_campos.Items.Add("COD. SUBFAMILIA")
                CheckedListBox_campos.Items.Add("SUBFAMILIA DOS")

                Combo_campos.Items.Clear()
                Combo_campos.Items.Add("-")
                Combo_campos.Items.Add("COD. SUBFAMILIA DOS")
                Combo_campos.Items.Add("COD. SUBFAMILIA")
                Combo_campos.Items.Add("SUBFAMILIA DOS")
            End If
        Else
            If combo_listado.Text = "SUBFAMILIAS DOS" Then
                CheckedListBox_campos.Items.Clear()
                CheckedListBox_campos.Items.Add("COD. SUBFAMILIA DOS")
                CheckedListBox_campos.Items.Add("COD. SUBFAMILIA")
                CheckedListBox_campos.Items.Add("SUBFAMILIA DOS")
                CheckedListBox_campos.Items.Add("M")
                CheckedListBox_campos.Items.Add("O")

                Combo_campos.Items.Clear()
                Combo_campos.Items.Add("-")
                Combo_campos.Items.Add("COD. SUBFAMILIA DOS")
                Combo_campos.Items.Add("COD. SUBFAMILIA")
                Combo_campos.Items.Add("SUBFAMILIA DOS")
                Combo_campos.Items.Add("M")
                Combo_campos.Items.Add("O")
            End If
        End If

        If combo_listado.Text = "CLIENTES" Then
            CheckedListBox_campos.Items.Clear()
            CheckedListBox_campos.Items.Add("CODIGO")
            CheckedListBox_campos.Items.Add("RUT")
            CheckedListBox_campos.Items.Add("NOMBRE")
            CheckedListBox_campos.Items.Add("DIRECCION")
            CheckedListBox_campos.Items.Add("COMUNA")
            CheckedListBox_campos.Items.Add("TELEFONO")
            CheckedListBox_campos.Items.Add("GIRO")
            CheckedListBox_campos.Items.Add("EMAIL")
            CheckedListBox_campos.Items.Add("DESCUENTO 1")
            CheckedListBox_campos.Items.Add("DESCUENTO 2")
            CheckedListBox_campos.Items.Add("DOCUMENTO")
            CheckedListBox_campos.Items.Add("ESTADO CUENTA")
            CheckedListBox_campos.Items.Add("FOLIO CLIENTE")
            CheckedListBox_campos.Items.Add("ORDEN DE COMPRA")
            CheckedListBox_campos.Items.Add("MENSAJE")

            Combo_campos.Items.Clear()
            Combo_campos.Items.Add("-")
            Combo_campos.Items.Add("CODIGO")
            Combo_campos.Items.Add("RUT")
            Combo_campos.Items.Add("NOMBRE")
            Combo_campos.Items.Add("DIRECCION")
            Combo_campos.Items.Add("COMUNA")
            Combo_campos.Items.Add("TELEFONO")
            Combo_campos.Items.Add("GIRO")
            Combo_campos.Items.Add("EMAIL")
            Combo_campos.Items.Add("DESCUENTO 1")
            Combo_campos.Items.Add("DESCUENTO 2")
            Combo_campos.Items.Add("DOCUMENTO")
            Combo_campos.Items.Add("ESTADO CUENTA")
            Combo_campos.Items.Add("FOLIO CLIENTE")
            Combo_campos.Items.Add("ORDEN DE COMPRA")
            Combo_campos.Items.Add("MENSAJE")
        End If


        If combo_listado.Text = "PRODUCTOS" Then
            CheckedListBox_campos.Items.Clear()
            CheckedListBox_campos.Items.Add("CODIGO")
            CheckedListBox_campos.Items.Add("NOMBRE")
            CheckedListBox_campos.Items.Add("MARCA")
            CheckedListBox_campos.Items.Add("APLICACION")
            CheckedListBox_campos.Items.Add("CANTIDAD")
            CheckedListBox_campos.Items.Add("PRECIO")
            CheckedListBox_campos.Items.Add("COSTO")
            CheckedListBox_campos.Items.Add("FACTOR")
            CheckedListBox_campos.Items.Add("NRO. TECNICO")
            CheckedListBox_campos.Items.Add("CANT. MIN.")
            CheckedListBox_campos.Items.Add("PROVEEDOR")
            CheckedListBox_campos.Items.Add("MARGEN")
            CheckedListBox_campos.Items.Add("FAMILIA")
            CheckedListBox_campos.Items.Add("SUBFAMILIA")
            CheckedListBox_campos.Items.Add("SUBFAMILIA DOS")
            CheckedListBox_campos.Items.Add("DOC. COMPRA")
            CheckedListBox_campos.Items.Add("NRO. DOC.")
            CheckedListBox_campos.Items.Add("ULT. COM.")
            CheckedListBox_campos.Items.Add("ACTIVO")

            Combo_campos.Items.Clear()
            Combo_campos.Items.Add("-")
            Combo_campos.Items.Add("CODIGO")
            Combo_campos.Items.Add("NOMBRE")
            Combo_campos.Items.Add("MARCA")
            Combo_campos.Items.Add("APLICACION")
            Combo_campos.Items.Add("CANTIDAD")
            Combo_campos.Items.Add("PRECIO")
            Combo_campos.Items.Add("COSTO")
            Combo_campos.Items.Add("FACTOR")
            Combo_campos.Items.Add("NRO. TECNICO")
            Combo_campos.Items.Add("CANT. MIN.")
            Combo_campos.Items.Add("PROVEEDOR")
            Combo_campos.Items.Add("MARGEN")
            Combo_campos.Items.Add("FAMILIA")
            Combo_campos.Items.Add("SUBFAMILIA")
            Combo_campos.Items.Add("SUBFAMILIA DOS")
            Combo_campos.Items.Add("DOC. COMPRA")
            Combo_campos.Items.Add("NRO. DOC.")
            Combo_campos.Items.Add("ULT. COM.")
            Combo_campos.Items.Add("ACTIVO")
        End If


        If combo_listado.Text = "CREDITOS" Then
            CheckedListBox_campos.Items.Clear()
            CheckedListBox_campos.Items.Add("CODIGO")
            CheckedListBox_campos.Items.Add("N. CREDITO")
            CheckedListBox_campos.Items.Add("TIPO DETALLE")
            CheckedListBox_campos.Items.Add("COD. CLIENTE")
            CheckedListBox_campos.Items.Add("RUT CLIENTE")
            CheckedListBox_campos.Items.Add("FECHA VENTA")
            CheckedListBox_campos.Items.Add("TOTAL")
            CheckedListBox_campos.Items.Add("SALDO")
            CheckedListBox_campos.Items.Add("CONDICION")
            CheckedListBox_campos.Items.Add("ESTADO")
            CheckedListBox_campos.Items.Add("RECINTO")
            CheckedListBox_campos.Items.Add("VENCIMIENTO")
            CheckedListBox_campos.Items.Add("PAGO")
            CheckedListBox_campos.Items.Add("RESPONSABLE")

            Combo_campos.Items.Clear()
            Combo_campos.Items.Add("-")
            Combo_campos.Items.Add("CODIGO")
            Combo_campos.Items.Add("N. CREDITO")
            Combo_campos.Items.Add("TIPO DETALLE")
            Combo_campos.Items.Add("COD. CLIENTE")
            Combo_campos.Items.Add("RUT CLIENTE")
            Combo_campos.Items.Add("FECHA VENTA")
            Combo_campos.Items.Add("TOTAL")
            Combo_campos.Items.Add("SALDO")
            Combo_campos.Items.Add("CONDICION")
            Combo_campos.Items.Add("ESTADO")
            Combo_campos.Items.Add("RECINTO")
            Combo_campos.Items.Add("VENCIMIENTO")
            Combo_campos.Items.Add("PAGO")
            Combo_campos.Items.Add("RESPONSABLE")
        End If


        If combo_listado.Text = "PROVEEDORES" Then
            CheckedListBox_campos.Items.Clear()
            CheckedListBox_campos.Items.Add("RUT")
            CheckedListBox_campos.Items.Add("NOMBRE")
            CheckedListBox_campos.Items.Add("DIRECCION")
            CheckedListBox_campos.Items.Add("CIUDAD")
            CheckedListBox_campos.Items.Add("COMUNA")
            CheckedListBox_campos.Items.Add("TELEFONO")
            CheckedListBox_campos.Items.Add("EMAIL")
            CheckedListBox_campos.Items.Add("GIRO")
            CheckedListBox_campos.Items.Add("REPRESENTANTE")
            CheckedListBox_campos.Items.Add("CREDITO")

            Combo_campos.Items.Clear()
            Combo_campos.Items.Add("-")
            Combo_campos.Items.Add("RUT")
            Combo_campos.Items.Add("NOMBRE")
            Combo_campos.Items.Add("DIRECCION")
            Combo_campos.Items.Add("CIUDAD")
            Combo_campos.Items.Add("COMUNA")
            Combo_campos.Items.Add("TELEFONO")
            Combo_campos.Items.Add("EMAIL")
            Combo_campos.Items.Add("GIRO")
            Combo_campos.Items.Add("REPRESENTANTE")
            Combo_campos.Items.Add("CREDITO")
        End If

        Combo_campos.SelectedItem = "-"
        Combo_forma.SelectedItem = "-"

        For i = 0 To (CheckedListBox_campos.Items.Count - 1)
            If CheckedListBox_campos.GetItemChecked(i) = False Then
                CheckedListBox_campos.SetItemChecked(i, True)
            End If
        Next
    End Sub

    Private Sub CheckedListBox_campos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox_campos.SelectedIndexChanged
        grilla_libro_compras.Columns.Clear()
        txt_registros.Text = "0"
    End Sub

    Private Sub Combo_campos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_campos.SelectedIndexChanged
        grilla_libro_compras.Columns.Clear()
        txt_registros.Text = "0"
    End Sub

    Private Sub Combo_forma_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_forma.SelectedIndexChanged
        grilla_libro_compras.Columns.Clear()
        txt_registros.Text = "0"
    End Sub
End Class