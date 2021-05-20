Imports System.IO
Imports System.Net

Public Class Form_productos_pagina_neumapro
    Dim consulta_busqueda As String

    ' Flag  
    Private Const FLAG_ICC_FORCE_CONNECTION = &H1

    ' Función api InternetCheckConnection  
    Private Declare Function InternetCheckConnection Lib _
    "wininet.dll" Alias _
    "InternetCheckConnectionA" (
        ByVal lpszUrl As String,
        ByVal dwFlags As Long,
        ByVal dwReserved As Long) As Long

    Private Sub Form_productos_pagina_neumapro_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F1 Then
            txt_busqueda.Focus()
        End If

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

    Private Sub Form_productos_pagina_neumapro_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub
    Private Sub Form_productos_pagina_neumapro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CambiaColorFondo(btn_exportar_excel, mirutempresa)
        CambiaColorFondo(btn_buscar, mirutempresa)
        CambiaColorFondo(btn_exportar_csv, mirutempresa)
        CambiaColorFondo(Panel3, mirutempresa)

        cargar_logo()
        txt_busqueda.Focus()
    End Sub


    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        grilla_indice_de_carga()
        grilla_indice_de_velocidad()
        buscar()



        'lbl_resultado.Location = New Point(1024 - lbl_resultado.Width - 7, 30)
    End Sub

    Private Sub txt_busqueda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_busqueda.KeyPress
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
            buscar()
        End If
    End Sub


    Sub grilla_indice_de_velocidad()

        grilla_velocidad.Rows.Clear()
        grilla_velocidad.Columns.Clear()
        grilla_velocidad.Columns.Add("", "INDICE")
        grilla_velocidad.Columns.Add("", "KM")

        grilla_velocidad.Rows.Add("A1", "5")
        grilla_velocidad.Rows.Add("A2", "10")
        grilla_velocidad.Rows.Add("A3", "15")
        grilla_velocidad.Rows.Add("A4", "20")
        grilla_velocidad.Rows.Add("A5", "25")
        grilla_velocidad.Rows.Add("A6", "30")
        grilla_velocidad.Rows.Add("A7", "35")
        grilla_velocidad.Rows.Add("A8", "40")
        grilla_velocidad.Rows.Add("B", "50")
        grilla_velocidad.Rows.Add("C", "60")
        grilla_velocidad.Rows.Add("D", "65")
        grilla_velocidad.Rows.Add("E", "70")
        grilla_velocidad.Rows.Add("F", "80")
        grilla_velocidad.Rows.Add("G", "90")
        grilla_velocidad.Rows.Add("J", "100")
        grilla_velocidad.Rows.Add("K", "110")
        grilla_velocidad.Rows.Add("L", "120")
        grilla_velocidad.Rows.Add("M", "130")
        grilla_velocidad.Rows.Add("N", "140")
        grilla_velocidad.Rows.Add("P", "150")
        grilla_velocidad.Rows.Add("Q", "160")
        grilla_velocidad.Rows.Add("R", "170")
        grilla_velocidad.Rows.Add("S", "180")
        grilla_velocidad.Rows.Add("T", "190")
        grilla_velocidad.Rows.Add("U", "200")
        grilla_velocidad.Rows.Add("H", "210")
        grilla_velocidad.Rows.Add("V", "240")
        grilla_velocidad.Rows.Add("ZR", ">240")
        grilla_velocidad.Rows.Add("W", "270")
        grilla_velocidad.Rows.Add("Y", "300")

    End Sub

    Sub grilla_indice_de_carga()

        grilla_carga.Rows.Clear()
        grilla_carga.Columns.Clear()
        grilla_carga.Columns.Add("", "INDICE")
        grilla_carga.Columns.Add("", "KILOS")
        grilla_carga.Rows.Add("20", "80")
        grilla_carga.Rows.Add("22", "85")
        grilla_carga.Rows.Add("24", "85")
        grilla_carga.Rows.Add("26", "90")
        grilla_carga.Rows.Add("28", "100")
        grilla_carga.Rows.Add("30", "106")
        grilla_carga.Rows.Add("31", "109")
        grilla_carga.Rows.Add("33", "115")
        grilla_carga.Rows.Add("35", "121")
        grilla_carga.Rows.Add("37", "128")
        grilla_carga.Rows.Add("40", "136")
        grilla_carga.Rows.Add("41", "145")
        grilla_carga.Rows.Add("42", "150")
        grilla_carga.Rows.Add("44", "160")
        grilla_carga.Rows.Add("46", "170")
        grilla_carga.Rows.Add("47", "175")
        grilla_carga.Rows.Add("48", "180")
        grilla_carga.Rows.Add("50", "190")
        grilla_carga.Rows.Add("51", "195")
        grilla_carga.Rows.Add("52", "200")
        grilla_carga.Rows.Add("53", "206")
        grilla_carga.Rows.Add("54", "212")
        grilla_carga.Rows.Add("55", "218")
        grilla_carga.Rows.Add("58", "236")
        grilla_carga.Rows.Add("59", "243")
        grilla_carga.Rows.Add("60", "250")
        grilla_carga.Rows.Add("61", "257")
        grilla_carga.Rows.Add("62", "265")
        grilla_carga.Rows.Add("63", "272")
        grilla_carga.Rows.Add("64", "280")
        grilla_carga.Rows.Add("65", "290")
        grilla_carga.Rows.Add("66", "300")
        grilla_carga.Rows.Add("67", "307")
        grilla_carga.Rows.Add("68", "315")
        grilla_carga.Rows.Add("69", "325")
        grilla_carga.Rows.Add("70", "335")
        grilla_carga.Rows.Add("71", "345")
        grilla_carga.Rows.Add("72", "355")
        grilla_carga.Rows.Add("73", "365")
        grilla_carga.Rows.Add("74", "375")
        grilla_carga.Rows.Add("75", "387")
        grilla_carga.Rows.Add("76", "400")
        grilla_carga.Rows.Add("77", "412")
        grilla_carga.Rows.Add("78", "425")
        grilla_carga.Rows.Add("79", "437")
        grilla_carga.Rows.Add("80", "450")
        grilla_carga.Rows.Add("81", "462")
        grilla_carga.Rows.Add("82", "475")
        grilla_carga.Rows.Add("83", "487")
        grilla_carga.Rows.Add("84", "500")
        grilla_carga.Rows.Add("85", "515")
        grilla_carga.Rows.Add("86", "530")
        grilla_carga.Rows.Add("87", "545")
        grilla_carga.Rows.Add("88", "560")
        grilla_carga.Rows.Add("89", "580")
        grilla_carga.Rows.Add("90", "600")
        grilla_carga.Rows.Add("91", "615")
        grilla_carga.Rows.Add("92", "630")
        grilla_carga.Rows.Add("93", "650")
        grilla_carga.Rows.Add("94", "670")
        grilla_carga.Rows.Add("95", "690")
        grilla_carga.Rows.Add("96", "710")
        grilla_carga.Rows.Add("97", "730")
        grilla_carga.Rows.Add("98", "750")
        grilla_carga.Rows.Add("99", "775")
        grilla_carga.Rows.Add("100", "800")
        grilla_carga.Rows.Add("101", "825")
        grilla_carga.Rows.Add("102", "850")
        grilla_carga.Rows.Add("103", "875")
        grilla_carga.Rows.Add("104", "900")
        grilla_carga.Rows.Add("105", "925")
        grilla_carga.Rows.Add("106", "950")
        grilla_carga.Rows.Add("107", "975")
        grilla_carga.Rows.Add("108", "1000")
        grilla_carga.Rows.Add("109", "1030")
        grilla_carga.Rows.Add("110", "1060")
        grilla_carga.Rows.Add("111", "1090")
        grilla_carga.Rows.Add("112", "1120")
        grilla_carga.Rows.Add("113", "1150")
        grilla_carga.Rows.Add("114", "1180")
        grilla_carga.Rows.Add("115", "1215")
        grilla_carga.Rows.Add("116", "1250")
        grilla_carga.Rows.Add("117", "1285")
        grilla_carga.Rows.Add("118", "1320")
        grilla_carga.Rows.Add("119", "1360")
        grilla_carga.Rows.Add("120", "1400")
        grilla_carga.Rows.Add("121", "1450")
        grilla_carga.Rows.Add("122", "1500")
        grilla_carga.Rows.Add("123", "1550")
        grilla_carga.Rows.Add("124", "1600")
        grilla_carga.Rows.Add("125", "1650")
        grilla_carga.Rows.Add("126", "1700")
        grilla_carga.Rows.Add("127", "1750")
        grilla_carga.Rows.Add("128", "1800")
        grilla_carga.Rows.Add("129", "1850")
        grilla_carga.Rows.Add("130", "1900")
        grilla_carga.Rows.Add("131", "1950")
        grilla_carga.Rows.Add("132", "2000")
        grilla_carga.Rows.Add("133", "2060")
        grilla_carga.Rows.Add("134", "2120")
        grilla_carga.Rows.Add("135", "2180")
        grilla_carga.Rows.Add("136", "2240")
        grilla_carga.Rows.Add("137", "2300")
        grilla_carga.Rows.Add("138", "2360")
        grilla_carga.Rows.Add("139", "2430")
        grilla_carga.Rows.Add("140", "2500")
        grilla_carga.Rows.Add("141", "2575")
        grilla_carga.Rows.Add("142", "2650")
        grilla_carga.Rows.Add("143", "2725")
        grilla_carga.Rows.Add("144", "2800")
        grilla_carga.Rows.Add("145", "2900")
        grilla_carga.Rows.Add("146", "3000")
        grilla_carga.Rows.Add("147", "3075")
        grilla_carga.Rows.Add("148", "3150")
        grilla_carga.Rows.Add("149", "3250")
        grilla_carga.Rows.Add("150", "3350")
        grilla_carga.Rows.Add("151", "3450")
        grilla_carga.Rows.Add("152", "3550")
        grilla_carga.Rows.Add("153", "3650")
        grilla_carga.Rows.Add("154", "3750")
        grilla_carga.Rows.Add("155", "3875")
        grilla_carga.Rows.Add("156", "4000")
        grilla_carga.Rows.Add("157", "4125")
        grilla_carga.Rows.Add("158", "4250")
        grilla_carga.Rows.Add("159", "4375")
        grilla_carga.Rows.Add("160", "4500")
        grilla_carga.Rows.Add("161", "4625")
        grilla_carga.Rows.Add("162", "4750")
        grilla_carga.Rows.Add("163", "4875")
        grilla_carga.Rows.Add("164", "5000")
        grilla_carga.Rows.Add("165", "5150")
        grilla_carga.Rows.Add("166", "5300")
        grilla_carga.Rows.Add("167", "5450")
        grilla_carga.Rows.Add("168", "5600")
        grilla_carga.Rows.Add("169", "5800")
        grilla_carga.Rows.Add("170", "6000")
        grilla_carga.Rows.Add("171", "6150")
        grilla_carga.Rows.Add("172", "6300")
        grilla_carga.Rows.Add("173", "6500")
        grilla_carga.Rows.Add("174", "6700")
        grilla_carga.Rows.Add("175", "6900")
        grilla_carga.Rows.Add("176", "7100")
        grilla_carga.Rows.Add("177", "7300")
        grilla_carga.Rows.Add("178", "7500")

    End Sub

    Sub buscar()
        lbl_mensaje.Visible = True
        Me.Enabled = False


        consulta_busqueda = "SELECT productos_neumaticos.cod_producto as 'SKU', cod_proveedor as 'SKU PROV.', medida as 'MEDIDA', modelo as 'MODELO', productos_neumaticos.marca as 'MARCA', indice_de_velocidad as 'VELOCIDAD', indice_de_carga as 'CARGA', tipo as 'TIPO', costo as 'COSTO', nombre_familia as 'FAMILIA', familia as 'CODIGO FAMILIA', precio as 'PRECIO FINAL', porcentaje_descuento as 'DESCUENTO', precio_normal as 'PRECIO NORMAL', cantidad as 'STOCK' , peso_volumetrico as 'PESO' FROM productos_neumaticos, productos, familia where productos.familia=familia.codigo and  productos_neumaticos.cod_producto=productos.cod_producto "

        Dim cadena As String
        Dim tabla() As String
        Dim n As Integer

        cadena = txt_busqueda.Text
        '   Dim split As String() = words.Split(New [Char]() {" "c, ","c, "."c, ":"c})
        tabla = Split(cadena, " ")

        If txt_busqueda.Text <> "" Then
            For n = 0 To UBound(tabla, 1)
                'consulta_busqueda = consulta_busqueda & "And CONCAT_WS(' ',COD_PRODUCTO, NOMBRE, APLICACION, NUMERO_TECNICO, nombre_proveedor) LIKE '" & ("%" & tabla(n) & "%") & "'"
                consulta_busqueda = consulta_busqueda & "AND CONCAT_WS(' ',productos_neumaticos.cod_producto as 'SKU', cod_proveedor as 'SKU PROV.', medida as 'MEDIDA', modelo as 'MODELO', productos_neumaticos.marca as 'MARCA', indice_de_velocidad as 'VELOCIDAD', indice_de_carga as 'CARGA', tipo as 'TIPO', costo as 'COSTO', nombre_familia as 'FAMILIA', familia as 'CODIGO FAMILIA', precio as 'PRECIO FINAL', porcentaje_descuento as 'DESCUENTO', precio_normal as 'PRECIO NORMAL' ) LIKE '" & ("%" & tabla(n) & "%") & "'"
            Next
        End If

        grilla_estado_de_cuenta.Rows.Clear()
        grilla_estado_de_cuenta.Columns.Clear()
        grilla_estado_de_cuenta.Columns.Add("", "SKU")
        grilla_estado_de_cuenta.Columns.Add("", "Nombre")
        grilla_estado_de_cuenta.Columns.Add("", "Descripcion")
        grilla_estado_de_cuenta.Columns.Add("", "Descripcion corta")
        grilla_estado_de_cuenta.Columns.Add("", "Etiquetas")
        grilla_estado_de_cuenta.Columns.Add("", "Categorias")
        grilla_estado_de_cuenta.Columns.Add("", "Precio normal")
        grilla_estado_de_cuenta.Columns.Add("", "Precio rebajado")
        grilla_estado_de_cuenta.Columns.Add("", "Stock")
        grilla_estado_de_cuenta.Columns.Add("", "Peso")
        grilla_estado_de_cuenta.Columns.Add("", "Imagenes")

        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = consulta_busqueda
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        If DS.Tables(DT.TableName).Rows.Count > 0 Then

            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1

                Dim Sku As String = DS.Tables(DT.TableName).Rows(i).Item("SKU")
                Dim Sku_proveedor As String = DS.Tables(DT.TableName).Rows(i).Item("SKU PROV.")
                Dim Medida As String = DS.Tables(DT.TableName).Rows(i).Item("MEDIDA")
                Dim Modelo As String = DS.Tables(DT.TableName).Rows(i).Item("MODELO")
                Dim Marca As String = DS.Tables(DT.TableName).Rows(i).Item("MARCA")
                Dim Velocidad As String = DS.Tables(DT.TableName).Rows(i).Item("VELOCIDAD")
                Dim Carga As String = DS.Tables(DT.TableName).Rows(i).Item("CARGA")
                Dim Tipo As String = DS.Tables(DT.TableName).Rows(i).Item("TIPO")
                Dim Costo As String = DS.Tables(DT.TableName).Rows(i).Item("COSTO")
                Dim Familia As String = DS.Tables(DT.TableName).Rows(i).Item("FAMILIA")
                Dim Codigo_familia As String = DS.Tables(DT.TableName).Rows(i).Item("CODIGO FAMILIA")
                Dim Precio_final As String = DS.Tables(DT.TableName).Rows(i).Item("PRECIO FINAL")
                Dim Descuento As String = DS.Tables(DT.TableName).Rows(i).Item("DESCUENTO")
                Dim Precio_normal As String = DS.Tables(DT.TableName).Rows(i).Item("PRECIO NORMAL")
                Dim Stock As String = DS.Tables(DT.TableName).Rows(i).Item("STOCK")
                Dim Peso As String = DS.Tables(DT.TableName).Rows(i).Item("PESO")

                Dim Marca_imagen As String = Marca.Replace(" ", "-")
                Dim Modelo_imagen As String = Modelo.Replace(" ", "-")

                Dim Imagenes As String = "https://www.neumapro.cl/FOTOSautoymoto/" & Marca_imagen & "-" & Modelo_imagen & ".jpg"

                Velocidad = Completar_velocidad(Velocidad)
                Carga = Completar_carga(Carga)


                If Tipo = "HT" Then
                    Tipo = "Tipo de terreno: <b>HT</b> - CARRETERA"
                End If
                If Tipo = "AT" Then
                    Tipo = "Tipo de terreno: <b>AT</b> - TODO TERRENO"
                End If
                If Tipo = "MT" Then
                    Tipo = "Tipo de terreno: <b>MT</b> - FUERA DE CARRETERA"
                End If







                Dim Nombre As String = "<b>" & Marca & " " & Modelo & "</b><br>" & Medida
                Dim Descripcion As String = Medida
                Descripcion = Descripcion.Replace("/", " ")
                Descripcion = Descripcion.Replace("R", " ")
                Dim Descripcion_final As String = ""




                Dim valor As String = Descripcion

                'Dim total As Double = 0
                Dim arrayPalabras() As String, espacios As Integer
                arrayPalabras = Strings.Split(valor, " ")
                For espacios = 0 To UBound(arrayPalabras)

                    If espacios = 0 Then
                        Descripcion_final = Descripcion_final & "<b>ANCHO: </b> " & (arrayPalabras(espacios)) & "<br>"
                    End If

                    If espacios = 1 Then
                        Descripcion_final = Descripcion_final & "<b>PERFIL: </b> " & (arrayPalabras(espacios)) & "<br>"
                    End If

                    If espacios = 2 Then
                        Descripcion_final = Descripcion_final & "<b>ARO: </b> " & (arrayPalabras(espacios)) & "<br>"
                    End If

                Next espacios

                Descripcion_final = "<div>" & Descripcion_final & "</div>"

                Descripcion = Descripcion_final

                Dim logo_marcas As String = "<div style='margin-top: -20px; text-align: center;'><img src='https://www.neumapro.cl/Imagenes/" & Marca & ".jpg' width='70%' />" & "</div>"
                Dim Carga_velocidad_tipo As String = "<div style='font-family: 'Bai Jamjuree'; margin-top: 10px;'>" & Carga & "<br>" & Velocidad & "<br>" & Tipo & "</div>"
                Dim Titulo_categoria As String = "<div style='background-color: #dbe0e6; height: 40px; width: 100%; text-align: center; padding: 10px; font-family 'Bai Jamjuree', Sans-serif; font-size: 20px; font-style: italic; font-weight: bold;'><b>CATEGORIA</b></div>"
                Dim Imagen_categoria As String = "<div style='margin-top: 10px; text-align: left;'><img src='https://www.neumapro.cl/Imagenes/" & Familia & ".jpg'  width='100%' /></div>"
                Dim Titulo_gratis As String = "<div style='background-color: #dbe0e6; height: 40px; width: 100%; text-align: center; padding: 10px; font-family: 'Bai Jamjuree', Sans-serif; font-size: 20px; font-style: italic; font-weight: bold;'><b>GRATIS</b></div>"
                Dim Imagen_envio_gratis As String = "<div style='float: Left; width: 50%; display: inline; margin-top: 0px; margin-bottom: 20px;'><a href='https://www.neumapro.cl/despachos/'><img src='https://www.neumapro.cl/Imagenes/envio.png' width='100%' /></a></div>"
                Dim Imagen_instalacion_gratis As String = "<div style='float: Left; width: 50%; display: inline; margin-top: 0px; margin-bottom: 20px;'><a href='https://www.neumapro.cl/instalacion/'><img src='https://www.neumapro.cl/Imagenes/instalacion.png' width='100%' /></a></div>"

                'Dim Descripcion_corta As String = logo_marcas & "<br>" & Carga_velocidad_tipo & "<br>" & Titulo_categoria & "<br>" & Imagen_categoria & "<br>" & Titulo_gratis & "<br>" & Imagen_envio_gratis & "<br>" & Imagen_instalacion_gratis
                Dim Descripcion_corta As String = logo_marcas & "<br>" & Carga_velocidad_tipo & "<br>" & Titulo_categoria & Imagen_categoria & Titulo_gratis & Imagen_envio_gratis & Imagen_instalacion_gratis

                Dim Etiquetas As String = Marca & "," & Descuento
                Dim Categorias As String = Medida


                grilla_estado_de_cuenta.Rows.Add(Sku,
                                                  Nombre,
                                                   Descripcion,
                                                    Descripcion_corta,
                                                     Etiquetas,
                                                      Categorias,
                                                       Precio_normal,
                                                        Precio_final,
                                                         Stock,
                                                          Peso,
                                                           Imagenes)
            Next

            grilla_estado_de_cuenta.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            grilla_estado_de_cuenta.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_estado_de_cuenta.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_estado_de_cuenta.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_estado_de_cuenta.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_estado_de_cuenta.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            grilla_estado_de_cuenta.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grilla_estado_de_cuenta.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

        If grilla_estado_de_cuenta.Rows.Count <> 0 Then
            If grilla_estado_de_cuenta.Columns(0).Width = 100 Then
                grilla_estado_de_cuenta.Columns(0).Width = 99
            Else
                grilla_estado_de_cuenta.Columns(0).Width = 100
            End If
            grilla_estado_de_cuenta.Columns(1).Width = 350
            grilla_estado_de_cuenta.Columns(2).Width = 350
            grilla_estado_de_cuenta.Columns(3).Width = 350
            grilla_estado_de_cuenta.Columns(4).Width = 350
            grilla_estado_de_cuenta.Columns(5).Width = 350
            grilla_estado_de_cuenta.Columns(6).Width = 120
            grilla_estado_de_cuenta.Columns(7).Width = 120
            grilla_estado_de_cuenta.Columns(8).Width = 120
            grilla_estado_de_cuenta.Columns(9).Width = 120
            grilla_estado_de_cuenta.Columns(10).Width = 350
        End If







        lbl_mensaje.Visible = False
        Me.Enabled = True

    End Sub





    Public Function Completar_velocidad(ByVal indice As String)


        Dim indice_velocidad As String = ""
        Dim km_equivalentes As String = ""

        For i = 0 To grilla_velocidad.Rows.Count - 1
            indice_velocidad = grilla_velocidad.Rows(i).Cells(0).Value.ToString
            km_equivalentes = grilla_velocidad.Rows(i).Cells(1).Value.ToString

            If indice = indice_velocidad Then
                indice = "Velocidad maxima: " & "<b>" & indice_velocidad & "</b>" & " - " & km_equivalentes & "Km"
                Exit For
            End If
        Next

        Return indice

    End Function

    Public Function Completar_carga(ByVal indice As String)


        Dim indice_carga As String = ""
        Dim kl_equivalentes As String = ""

        For i = 0 To grilla_carga.Rows.Count - 1
            indice_carga = grilla_carga.Rows(i).Cells(0).Value.ToString
            kl_equivalentes = grilla_carga.Rows(i).Cells(1).Value.ToString

            If indice = indice_carga Then
                indice = "Carga maxima: " & "<b>" & indice_carga & "</b>" & " - " & kl_equivalentes & "Kg"
                Exit For
            End If
        Next

        Return indice

    End Function

    Private Sub VolveralmenuprincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_csv.Click
        Dim mensaje As String = ""

        Dim ruta_archivo As String
        Dim hora_sistema As String
        Dim fecha_sistema As String

        hora_sistema = Form_menu_principal.lbl_hora.Text
        hora_sistema = hora_sistema.Replace(":", " ")

        fecha_sistema = Format(Today.Date, "Long Date")

        fecha_sistema = fecha_sistema.Replace(",", " ")

        ruta_archivo = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & txt_busqueda.Text & " " & fecha_sistema & " " & hora_sistema & ".csv"

        If grilla_estado_de_cuenta.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            txt_busqueda.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
        lbl_mensaje.Visible = True
        Me.Enabled = False

        exportar_excel()

        lbl_mensaje.Visible = False
        Me.Enabled = True

    End Sub

    Private Function exportar_excel() As Boolean
        Dim ruta_archivo As String
        Dim hora_sistema As String
        Dim fecha_sistema As String

        hora_sistema = Form_menu_principal.lbl_hora.Text
        hora_sistema = hora_sistema.Replace(":", " ")

        fecha_sistema = Format(Today.Date, "Long Date")

        fecha_sistema = fecha_sistema.Replace(",", " ")

        ruta_archivo = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & txt_busqueda.Text & " " & fecha_sistema & " " & hora_sistema & ".csv"





        'Dim cadenaubicacion As String
        'Dim directorio As New FolderBrowserDialog
        'If directorio.ShowDialog = DialogResult.OK Then
        '    cadenaubicacion = directorio.SelectedPath
        Try
            Dim stream As Stream
            Dim escritor As StreamWriter
            Dim fila = grilla_estado_de_cuenta.Rows.Count
            Dim columnas = grilla_estado_de_cuenta.Columns.Count
            Dim archivo As String = ruta_archivo
            Dim linea As String = ""
            Dim filadata, column As Int32

            File.Delete(archivo)
            stream = File.OpenWrite(archivo)
            escritor = New StreamWriter(stream, System.Text.Encoding.UTF8)

            For column = 0 To columnas - 1
                linea = linea & grilla_estado_de_cuenta.Columns(column).HeaderText & ";"
            Next
            linea = Mid(CStr(linea), 1, linea.ToString.Length - 1)
            escritor.WriteLine(linea)
            linea = Nothing
            For filadata = 0 To fila - 1
                For column = 0 To columnas - 1
                    linea = linea & CStr(grilla_estado_de_cuenta.Item(column, filadata).Value) & ";"
                Next
                linea = Mid(CStr(linea), 1, linea.ToString.Length - 1)
                escritor.WriteLine(linea)
                linea = Nothing
            Next
            escritor.Close()
            Try
                ''Process.Start(archivo)
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        'End If
        'Return False
    End Function

    Private Sub btn_exportar_excel_Click_1(sender As Object, e As EventArgs) Handles btn_exportar_excel.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        Dim save As New SaveFileDialog
        save.Filter = "Archivo Excel | *.xlsx"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.grilla_estado_de_cuenta, save.FileName)
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
        For c As Integer = 0 To grilla_estado_de_cuenta.Columns.Count - 1
            xlWS.cells(1, c + 1).value = grilla_estado_de_cuenta.Columns(c).HeaderText
        Next
        'exportamos las cabeceras de columnas 
        For r As Integer = 0 To grilla_estado_de_cuenta.RowCount - 1
            For c As Integer = 0 To grilla_estado_de_cuenta.Columns.Count - 1
                xlWS.cells(r + 2, c + 1).value = grilla_estado_de_cuenta.Item(c, r).Value
            Next
        Next
        'guardamos la hoja de calculo en la ruta especificada 
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub


    Sub validar()


        Dim link_imagen As String = ""

        For i = 0 To grilla_estado_de_cuenta.Rows.Count - 1
            link_imagen = grilla_estado_de_cuenta.Rows(i).Cells(9).Value.ToString


            'Dim Client As New WebClient
            'Client.DownloadFile(link_imagen, "C:\Temp\" & mirutempresa & "\Imagen.png")



            'If Descargar(link_imagen, My.Computer.FileSystem.SpecialDirectories.Desktop & "\hola.jpg") = False Then
            '    grilla_carga.Rows(i).DefaultCellStyle.BackColor = Color.Red
            '    Exit For
            'End If




        Next

    End Sub

    Private Declare Function URLDownloadToFile Lib "urlmon" Alias "URLDownloadToFileA" (ByVal pCaller As Long, ByVal szURL As String, ByVal szFileName As String, ByVal dwReserved As Long, ByVal lpfnCB As Long) As Long



    Private Function Descargar(URL, Destino) As Boolean
        Dim lRet As Long

        lRet = URLDownloadToFile(0, URL, Destino, 0, 0)

        If lRet = 0 Then
            'Descargar = True
        Else
            Descargar = False
        End If
    End Function


    Private Sub btn_validar_Click(sender As Object, e As EventArgs) Handles btn_validar.Click
        validar()
    End Sub
End Class