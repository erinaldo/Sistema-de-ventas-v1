Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.IO
Imports System.Math

Public Class Form_administrar_servicios_lubricentro
    Dim mifecha2 As String
    Dim mifecha4 As String
    Dim numero_lineas_total As Integer = 0

    Private Sub Form_administrar_servicios_lubricentro_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Form_administrar_servicios_lubricentro_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
            form_Ingreso.Show()
            Form_menu_principal.Close()
        End If
    End Sub

    Sub fecha()
        Dim mifecha As Date
        mifecha = dtp_desde.Text
        mifecha2 = mifecha.ToString("yyy-MM-dd")

        Dim mifecha3 As Date
        mifecha3 = dtp_hasta.Text
        mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub



    Sub cargar_logo()
        Try
            PictureBox_logo.Image = Bytes_Imagen(Imagen_formulario)
        Catch
        End Try
    End Sub

    Sub mostrar_malla()
        If combo_mecanico.Text = "TODOS" Then

            conexion.Close()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion

            SC.CommandText = "SELECT FECHA, PATENTE, MODELO, kilometraje, NOMBRE_USUARIO, CODIGO_1, ACEITE_DE_MOTOR, CANTIDAD_1, CODIGO_2, FILTRO_DE_ACEITE, CANTIDAD_2, CODIGO_3,  FILTRO_DE_AIRE, CANTIDAD_3, CODIGO_4, FILTRO_DE_COMBUSTIBLE, CANTIDAD_4, CODIGO_5,  aceite_de_caja, CANTIDAD_5, CODIGO_6,  ACEITE_DIFERENCIAL, CANTIDAD_6, CODIGO_7,  OTROS_1, CANTIDAD_7, CODIGO_8,  OTROS_2, CANTIDAD_8,CODIGO_9,  OTROS_3, CANTIDAD_9,CODIGO_10,  OTROS_4, CANTIDAD_10, tipo_documento, nro_documento FROM `servicios_lubricentro`, `USUARIOS` WHERE USUARIOS.RUT_USUARIO=SERVICIOS_LUBRICENTRO.RUT_MECANICO and  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "'"

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("fecha"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("patente"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("modelo"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("kilometraje"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("tipo_documento"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("nro_documento"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("codigo_1"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("filtro_de_aceite"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("cantidad_1"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("codigo_2"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("aceite_de_motor"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("cantidad_2"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("codigo_3"), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("filtro_de_aire"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("cantidad_3"), _
                                                                    DS.Tables(DT.TableName).Rows(i).Item("codigo_4"), _
                                                                     DS.Tables(DT.TableName).Rows(i).Item("filtro_de_combustible"), _
                                                                      DS.Tables(DT.TableName).Rows(i).Item("cantidad_4"), _
                                                                       DS.Tables(DT.TableName).Rows(i).Item("codigo_5"), _
                                                                        DS.Tables(DT.TableName).Rows(i).Item("aceite_de_caja"), _
                                                                         DS.Tables(DT.TableName).Rows(i).Item("cantidad_5"), _
                                                                          DS.Tables(DT.TableName).Rows(i).Item("codigo_6"), _
                                                                           DS.Tables(DT.TableName).Rows(i).Item("aceite_diferencial"), _
                                                                            DS.Tables(DT.TableName).Rows(i).Item("cantidad_6"), _
                                                                             DS.Tables(DT.TableName).Rows(i).Item("codigo_7"), _
                                                                              DS.Tables(DT.TableName).Rows(i).Item("otros_1"), _
                                                                               DS.Tables(DT.TableName).Rows(i).Item("cantidad_7"), _
                                                                                DS.Tables(DT.TableName).Rows(i).Item("codigo_8"), _
                                                                                 DS.Tables(DT.TableName).Rows(i).Item("otros_2"), _
                                                                                  DS.Tables(DT.TableName).Rows(i).Item("cantidad_8"), _
                                                                                   DS.Tables(DT.TableName).Rows(i).Item("codigo_9"), _
                                                                                    DS.Tables(DT.TableName).Rows(i).Item("otros_3"), _
                                                                                     DS.Tables(DT.TableName).Rows(i).Item("cantidad_9"), _
                                                                                      DS.Tables(DT.TableName).Rows(i).Item("codigo_10"), _
                                                                                       DS.Tables(DT.TableName).Rows(i).Item("otros_4"), _
                                                                                        DS.Tables(DT.TableName).Rows(i).Item("cantidad_10"))

                Next
            End If
        End If


        If combo_mecanico.Text <> "TODOS" Then

            conexion.Close()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "SELECT FECHA, PATENTE, MODELO, KILOMETRAJE, NOMBRE_USUARIO, CODIGO_1, ACEITE_DE_MOTOR, CANTIDAD_1, CODIGO_2, FILTRO_DE_ACEITE, CANTIDAD_2, CODIGO_3,  FILTRO_DE_AIRE, CANTIDAD_3, CODIGO_4, FILTRO_DE_COMBUSTIBLE, CANTIDAD_4, CODIGO_5,  aceite_de_caja, CANTIDAD_5, CODIGO_6,  ACEITE_DIFERENCIAL, CANTIDAD_6, CODIGO_7,  OTROS_1, CANTIDAD_7, CODIGO_8,  OTROS_2, CANTIDAD_8, tipo_documento, nro_documento  FROM `servicios_lubricentro`, `USUARIOS` WHERE USUARIOS.RUT_USUARIO=SERVICIOS_LUBRICENTRO.RUT_MECANICO and  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND RUT_USUARIO='" & (txt_rut_vendedor.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("fecha"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("patente"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("modelo"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("kilometraje"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("tipo_documento"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("nro_documento"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("codigo_1"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("filtro_de_aceite"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("cantidad_1"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("codigo_2"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("aceite_de_motor"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("cantidad_2"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("codigo_3"), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("filtro_de_aire"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("cantidad_3"), _
                                                                    DS.Tables(DT.TableName).Rows(i).Item("codigo_4"), _
                                                                     DS.Tables(DT.TableName).Rows(i).Item("filtro_de_combustible"), _
                                                                      DS.Tables(DT.TableName).Rows(i).Item("cantidad_4"), _
                                                                       DS.Tables(DT.TableName).Rows(i).Item("codigo_5"), _
                                                                        DS.Tables(DT.TableName).Rows(i).Item("aceite_de_caja"), _
                                                                         DS.Tables(DT.TableName).Rows(i).Item("cantidad_5"), _
                                                                          DS.Tables(DT.TableName).Rows(i).Item("codigo_6"), _
                                                                           DS.Tables(DT.TableName).Rows(i).Item("aceite_diferencial"), _
                                                                            DS.Tables(DT.TableName).Rows(i).Item("cantidad_6"), _
                                                                             DS.Tables(DT.TableName).Rows(i).Item("codigo_7"), _
                                                                              DS.Tables(DT.TableName).Rows(i).Item("otros_1"), _
                                                                               DS.Tables(DT.TableName).Rows(i).Item("cantidad_7"), _
                                                                                DS.Tables(DT.TableName).Rows(i).Item("codigo_8"), _
                                                                                 DS.Tables(DT.TableName).Rows(i).Item("otros_2"), _
                                                                                  DS.Tables(DT.TableName).Rows(i).Item("cantidad_8"))

                Next
            End If
        End If

        If grilla_estado_de_cuenta.Rows.Count <> 0 Then
            If grilla_estado_de_cuenta.Columns(0).Width = 100 Then
                grilla_estado_de_cuenta.Columns(0).Width = 99
            Else
                grilla_estado_de_cuenta.Columns(0).Width = 100
            End If
        End If

    End Sub





    Sub mostrar_malla_buscar()
        Dim consulta_busqueda As String
        grilla_estado_de_cuenta.Rows.Clear()

        If combo_mecanico.Text = "TODOS" Then

            consulta_busqueda = "SELECT FECHA, PATENTE, MODELO, kilometraje, NOMBRE_USUARIO, CODIGO_1, ACEITE_DE_MOTOR, CANTIDAD_1, CODIGO_2, FILTRO_DE_ACEITE, CANTIDAD_2, CODIGO_3,  FILTRO_DE_AIRE, CANTIDAD_3, CODIGO_4, FILTRO_DE_COMBUSTIBLE, CANTIDAD_4, CODIGO_5,  aceite_de_caja, CANTIDAD_5, CODIGO_6,  ACEITE_DIFERENCIAL, CANTIDAD_6, CODIGO_7,  OTROS_1, CANTIDAD_7, CODIGO_8,  OTROS_2, CANTIDAD_8, tipo_documento, nro_documento FROM `servicios_lubricentro`, `USUARIOS` WHERE USUARIOS.RUT_USUARIO=SERVICIOS_LUBRICENTRO.RUT_MECANICO and  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' "

            '  consulta_busqueda = "select cod_producto as PRODUCTO, nombre as DESCRIPCION, numero_tecnico as 'NUMERO TECNICO',  aplicacion as 'APLICACION/MARCA', cantidad as CANTIDAD, precio as PRECIO, proveedores.nombre_proveedor 'NOMBRE PROVEEDOR', productos.ULTIMA_COMPRA AS 'ULTIMA COMPRA', productos.cantidad_ULTIMA_COMPRA AS 'CANT. ULTIMA COMPRA' from productos, proveedores where proveedores.rut_proveedor=productos.proveedor "
            Dim cadena As String
            Dim tabla() As String
            Dim n As Integer

            cadena = txt_buscar.Text
            '   Dim split As String() = words.Split(New [Char]() {" "c, ","c, "."c, ":"c})
            tabla = Split(cadena, " ")

            For n = 0 To UBound(tabla, 1)
                consulta_busqueda = consulta_busqueda & "AND CONCAT_WS(' ',patente, modelo) LIKE '" & ("%" & tabla(n) & "%") & "'"
            Next




            conexion.Close()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion

            SC.CommandText = consulta_busqueda

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("fecha"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("patente"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("modelo"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("kilometraje"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("tipo_documento"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("nro_documento"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("codigo_1"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("filtro_de_aceite"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("cantidad_1"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("codigo_2"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("aceite_de_motor"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("cantidad_2"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("codigo_3"), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("filtro_de_aire"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("cantidad_3"), _
                                                                    DS.Tables(DT.TableName).Rows(i).Item("codigo_4"), _
                                                                     DS.Tables(DT.TableName).Rows(i).Item("filtro_de_combustible"), _
                                                                      DS.Tables(DT.TableName).Rows(i).Item("cantidad_4"), _
                                                                       DS.Tables(DT.TableName).Rows(i).Item("codigo_5"), _
                                                                        DS.Tables(DT.TableName).Rows(i).Item("aceite_de_caja"), _
                                                                         DS.Tables(DT.TableName).Rows(i).Item("cantidad_5"), _
                                                                          DS.Tables(DT.TableName).Rows(i).Item("codigo_6"), _
                                                                           DS.Tables(DT.TableName).Rows(i).Item("aceite_diferencial"), _
                                                                            DS.Tables(DT.TableName).Rows(i).Item("cantidad_6"), _
                                                                             DS.Tables(DT.TableName).Rows(i).Item("codigo_7"), _
                                                                              DS.Tables(DT.TableName).Rows(i).Item("otros_1"), _
                                                                               DS.Tables(DT.TableName).Rows(i).Item("cantidad_7"), _
                                                                                DS.Tables(DT.TableName).Rows(i).Item("codigo_8"), _
                                                                                 DS.Tables(DT.TableName).Rows(i).Item("otros_2"), _
                                                                                  DS.Tables(DT.TableName).Rows(i).Item("cantidad_8"))

                Next
            End If
        End If


        If combo_mecanico.Text <> "TODOS" Then

            consulta_busqueda = "SELECT FECHA, PATENTE, MODELO, KILOMETRAJE, NOMBRE_USUARIO, CODIGO_1, ACEITE_DE_MOTOR, CANTIDAD_1, CODIGO_2, FILTRO_DE_ACEITE, CANTIDAD_2, CODIGO_3,  FILTRO_DE_AIRE, CANTIDAD_3, CODIGO_4, FILTRO_DE_COMBUSTIBLE, CANTIDAD_4, CODIGO_5,  aceite_de_caja, CANTIDAD_5, CODIGO_6,  ACEITE_DIFERENCIAL, CANTIDAD_6, CODIGO_7,  OTROS_1, CANTIDAD_7, CODIGO_8,  OTROS_2, CANTIDAD_8, tipo_documento, nro_documento  FROM `servicios_lubricentro`, `USUARIOS` WHERE USUARIOS.RUT_USUARIO=SERVICIOS_LUBRICENTRO.RUT_MECANICO and  fecha >='" & (mifecha2) & "' and fecha <= '" & (mifecha4) & "' AND RUT_USUARIO='" & (txt_rut_vendedor.Text) & "'"

            '  consulta_busqueda = "select cod_producto as PRODUCTO, nombre as DESCRIPCION, numero_tecnico as 'NUMERO TECNICO',  aplicacion as 'APLICACION/MARCA', cantidad as CANTIDAD, precio as PRECIO, proveedores.nombre_proveedor 'NOMBRE PROVEEDOR', productos.ULTIMA_COMPRA AS 'ULTIMA COMPRA', productos.cantidad_ULTIMA_COMPRA AS 'CANT. ULTIMA COMPRA' from productos, proveedores where proveedores.rut_proveedor=productos.proveedor "
            Dim cadena As String
            Dim tabla() As String
            Dim n As Integer

            cadena = txt_buscar.Text
            '   Dim split As String() = words.Split(New [Char]() {" "c, ","c, "."c, ":"c})
            tabla = Split(cadena, " ")

            For n = 0 To UBound(tabla, 1)
                consulta_busqueda = consulta_busqueda & "AND CONCAT_WS(' ',patente, modelo) LIKE '" & ("%" & tabla(n) & "%") & "'"
            Next

            conexion.Close()
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = consulta_busqueda

            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_estado_de_cuenta.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("fecha"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("patente"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("modelo"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("kilometraje"), _
                                                        DS.Tables(DT.TableName).Rows(i).Item("nombre_usuario"), _
                                                         DS.Tables(DT.TableName).Rows(i).Item("tipo_documento"), _
                                                          DS.Tables(DT.TableName).Rows(i).Item("nro_documento"), _
                                                           DS.Tables(DT.TableName).Rows(i).Item("codigo_1"), _
                                                            DS.Tables(DT.TableName).Rows(i).Item("filtro_de_aceite"), _
                                                             DS.Tables(DT.TableName).Rows(i).Item("cantidad_1"), _
                                                              DS.Tables(DT.TableName).Rows(i).Item("codigo_2"), _
                                                               DS.Tables(DT.TableName).Rows(i).Item("aceite_de_motor"), _
                                                                DS.Tables(DT.TableName).Rows(i).Item("cantidad_2"), _
                                                                 DS.Tables(DT.TableName).Rows(i).Item("codigo_3"), _
                                                                  DS.Tables(DT.TableName).Rows(i).Item("filtro_de_aire"), _
                                                                   DS.Tables(DT.TableName).Rows(i).Item("cantidad_3"), _
                                                                    DS.Tables(DT.TableName).Rows(i).Item("codigo_4"), _
                                                                     DS.Tables(DT.TableName).Rows(i).Item("filtro_de_combustible"), _
                                                                      DS.Tables(DT.TableName).Rows(i).Item("cantidad_4"), _
                                                                       DS.Tables(DT.TableName).Rows(i).Item("codigo_5"), _
                                                                        DS.Tables(DT.TableName).Rows(i).Item("aceite_de_caja"), _
                                                                         DS.Tables(DT.TableName).Rows(i).Item("cantidad_5"), _
                                                                          DS.Tables(DT.TableName).Rows(i).Item("codigo_6"), _
                                                                           DS.Tables(DT.TableName).Rows(i).Item("aceite_diferencial"), _
                                                                            DS.Tables(DT.TableName).Rows(i).Item("cantidad_6"), _
                                                                             DS.Tables(DT.TableName).Rows(i).Item("codigo_7"), _
                                                                              DS.Tables(DT.TableName).Rows(i).Item("otros_1"), _
                                                                               DS.Tables(DT.TableName).Rows(i).Item("cantidad_7"), _
                                                                                DS.Tables(DT.TableName).Rows(i).Item("codigo_8"), _
                                                                                 DS.Tables(DT.TableName).Rows(i).Item("otros_2"), _
                                                                                  DS.Tables(DT.TableName).Rows(i).Item("cantidad_8"))

                Next
            End If
        End If

        If grilla_estado_de_cuenta.Rows.Count <> 0 Then
            If grilla_estado_de_cuenta.Columns(0).Width = 100 Then
                grilla_estado_de_cuenta.Columns(0).Width = 99
            Else
                grilla_estado_de_cuenta.Columns(0).Width = 100
            End If
        End If

    End Sub


    Sub mostrar_malla_detalle()

        Dim tipo_doc As String
        Dim nro_doc As String

        tipo_doc = grilla_estado_de_cuenta.CurrentRow.Cells(5).Value
        nro_doc = grilla_estado_de_cuenta.CurrentRow.Cells(6).Value

        grilla_detalle_productos.Rows.Clear()


        If tipo_doc = "BOLETA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_boleta WHERE n_boleta='" & (nro_doc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_productos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"))

                Next
            End If
        End If

        If tipo_doc = "FACTURA DE CREDITO" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_factura WHERE n_factura='" & (nro_doc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_productos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"))

                Next
            End If
        End If

        If tipo_doc = "FACTURA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_factura WHERE n_factura='" & (nro_doc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_productos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"))

                Next
            End If
        End If

        If tipo_doc = "GUIA" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select * from detalle_guia WHERE n_guia='" & (nro_doc) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                    grilla_detalle_productos.Rows.Add(DS.Tables(DT.TableName).Rows(i).Item("cantidad"), _
                                                     DS.Tables(DT.TableName).Rows(i).Item("cod_producto"), _
                                                      DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre"), _
                                                       DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico"))

                Next
            End If
        End If

        If grilla_detalle_productos.Rows.Count <> 0 Then
            If grilla_detalle_productos.Columns(0).Width = 100 Then
                grilla_detalle_productos.Columns(0).Width = 99
            Else
                grilla_detalle_productos.Columns(0).Width = 100
            End If
        End If
    End Sub

    Private Sub Form_administrar_servicios_lubricentro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()
        llenar_combo_vendedor()
        mostrar_malla()

        grilla_estado_de_cuenta.Columns(0).Width = 100
        grilla_estado_de_cuenta.Columns(1).Width = 100
        grilla_estado_de_cuenta.Columns(2).Width = 200
        grilla_estado_de_cuenta.Columns(3).Width = 100
        grilla_estado_de_cuenta.Columns(4).Width = 200
        grilla_estado_de_cuenta.Columns(5).Width = 200
        grilla_estado_de_cuenta.Columns(6).Width = 100
        grilla_estado_de_cuenta.Columns(7).Width = 100
        grilla_estado_de_cuenta.Columns(8).Width = 200
        grilla_estado_de_cuenta.Columns(9).Width = 100
        grilla_estado_de_cuenta.Columns(10).Width = 100
        grilla_estado_de_cuenta.Columns(11).Width = 200
        grilla_estado_de_cuenta.Columns(12).Width = 100
        grilla_estado_de_cuenta.Columns(13).Width = 100
        grilla_estado_de_cuenta.Columns(14).Width = 200
        grilla_estado_de_cuenta.Columns(15).Width = 100
        grilla_estado_de_cuenta.Columns(16).Width = 100
        grilla_estado_de_cuenta.Columns(17).Width = 200
        grilla_estado_de_cuenta.Columns(18).Width = 100
        grilla_estado_de_cuenta.Columns(19).Width = 100
        grilla_estado_de_cuenta.Columns(20).Width = 200
        grilla_estado_de_cuenta.Columns(21).Width = 100
        grilla_estado_de_cuenta.Columns(22).Width = 100
        grilla_estado_de_cuenta.Columns(23).Width = 200
        grilla_estado_de_cuenta.Columns(24).Width = 100
        grilla_estado_de_cuenta.Columns(25).Width = 100
        grilla_estado_de_cuenta.Columns(26).Width = 200
        grilla_estado_de_cuenta.Columns(27).Width = 100
        grilla_estado_de_cuenta.Columns(28).Width = 100
        grilla_estado_de_cuenta.Columns(29).Width = 200
        grilla_estado_de_cuenta.Columns(30).Width = 100

        grilla_estado_de_cuenta.Columns(31).Width = 100
        grilla_estado_de_cuenta.Columns(32).Width = 200
        grilla_estado_de_cuenta.Columns(33).Width = 100

        grilla_estado_de_cuenta.Columns(34).Width = 100
        grilla_estado_de_cuenta.Columns(35).Width = 200
        grilla_estado_de_cuenta.Columns(36).Width = 100

        grilla_estado_de_cuenta.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        grilla_estado_de_cuenta.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_estado_de_cuenta.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_estado_de_cuenta.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_estado_de_cuenta.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_estado_de_cuenta.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_estado_de_cuenta.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_estado_de_cuenta.Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(24).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_estado_de_cuenta.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(26).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(27).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grilla_estado_de_cuenta.Columns(28).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(29).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(30).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grilla_estado_de_cuenta.Columns(31).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(32).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(33).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grilla_estado_de_cuenta.Columns(34).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(35).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grilla_estado_de_cuenta.Columns(36).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub btn_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.Click
        Dim mensaje As String = ""

        If grilla_estado_de_cuenta.Rows.Count = 0 Then
            mensaje = "MALLA VACIA, FAVOR LLENAR" + Chr(13) & mensaje
            dtp_desde.Focus()
            MsgBox(mensaje, MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            Exit Sub
        End If
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

    Sub llenar_combo_vendedor()
        combo_mecanico.Items.Clear()
        combo_mecanico.Items.Add("TODOS")
        conexion.Close()
        DS3.Tables.Clear()
        DT3.Rows.Clear()
        DT3.Columns.Clear()
        DS3.Clear()
        conexion.Open()

        SC3.Connection = conexion
        SC3.CommandText = "select * from usuarios WHERE AREA_USUARIO='MECANICO' order by nombre_usuario"
        DA3.SelectCommand = SC3
        DA3.Fill(DT3)
        DS3.Tables.Add(DT3)

        If DS3.Tables(DT3.TableName).Rows.Count > 0 Then
            For i = 0 To DS3.Tables(DT3.TableName).Rows.Count - 1
                combo_mecanico.Items.Add(DS3.Tables(DT3.TableName).Rows(i).Item("nombre_usuario"))
            Next
        End If
        conexion.Close()
        combo_mecanico.SelectedItem = "TODOS"
    End Sub

    Sub mostrar_datos_vendedor()
        conexion.Close()
        If combo_mecanico.Text <> "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()

            SC.Connection = conexion
            SC.CommandText = "select * from usuarios where nombre_usuario ='" & (combo_mecanico.Text) & "'"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)

            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                txt_rut_vendedor.Text = DS.Tables(DT.TableName).Rows(0).Item("rut_usuario")
            End If

            conexion.Close()
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        grilla_estado_de_cuenta.Rows.Clear()
        fecha()
        mostrar_malla()

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿DESEA LIMPIAR LA PANTALLA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "LIMPIAR")
        If valormensaje = vbYes Then   
            combo_mecanico.SelectedItem = "TODOS"
            dtp_desde.Text = FormatDateTime(Now, DateFormat.ShortDate)
            dtp_hasta.Text = FormatDateTime(Now, DateFormat.ShortDate)
            grilla_estado_de_cuenta.Rows.Clear()
        End If
    End Sub

    Private Sub dtp_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_desde.ValueChanged
        combo_mecanico.SelectedItem = "TODOS"
        grilla_estado_de_cuenta.Rows.Clear()
    End Sub

    Private Sub dtp_hasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hasta.ValueChanged
        combo_mecanico.SelectedItem = "TODOS"
        grilla_estado_de_cuenta.Rows.Clear()
    End Sub

    Private Sub combo_mecanico_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_mecanico.SelectedIndexChanged
        mostrar_datos_vendedor()
        grilla_estado_de_cuenta.Rows.Clear()
    End Sub

    Private Sub grilla_documento_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub btn_exportar_excel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.GotFocus
        btn_exportar_excel.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_exportar_excel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_exportar_excel.LostFocus
        btn_exportar_excel.BackColor = Color.Transparent
    End Sub

    Private Sub btn_limpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.GotFocus
        btn_limpiar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_limpiar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpiar.LostFocus
        btn_limpiar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_mostrar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.GotFocus
        btn_mostrar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_mostrar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.LostFocus
        btn_mostrar.BackColor = Color.Transparent
    End Sub

    Private Sub btn_salir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.GotFocus
        btn_salir.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_salir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.LostFocus
        btn_salir.BackColor = Color.Transparent
    End Sub

    Private Sub txt_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_buscar.GotFocus
        txt_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub txt_buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_buscar.KeyPress
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
            btn_buscar.PerformClick()
        End If

    End Sub

    Private Sub txt_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_buscar.LostFocus
        txt_buscar.BackColor = Color.White
    End Sub
    'Private Sub btn_imprimir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.GotFocus
    '    btn_imprimir.BackColor = Color.LightSkyBlue
    'End Sub

    'Private Sub btn_imprimir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.LostFocus
    '    btn_imprimir.BackColor = Color.Transparent
    'End Sub

    Private Sub btn_buscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.GotFocus
        btn_buscar.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub btn_buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar.LostFocus
        btn_buscar.BackColor = Color.Transparent
    End Sub

    Private Sub combo_mecanico_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_mecanico.GotFocus
        combo_mecanico.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub combo_mecanico_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles combo_mecanico.LostFocus
        combo_mecanico.BackColor = Color.White
    End Sub

    Private Sub dtp_desde_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_desde.GotFocus
        dtp_desde.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub dtp_desde_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_desde.LostFocus
        dtp_desde.BackColor = Color.White
    End Sub

    Private Sub dtp_hasta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_hasta.GotFocus
        dtp_hasta.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub dtp_hasta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_hasta.LostFocus
        dtp_hasta.BackColor = Color.White
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        lbl_mensaje.Visible = True
        Me.Enabled = False
        fecha()
        mostrar_malla_buscar()
        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub


    Private Sub txt_buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_buscar.TextChanged

    End Sub

    Private Sub btn_salir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub grilla_estado_de_cuenta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla_estado_de_cuenta.CellContentClick

    End Sub

    Private Sub grilla_estado_de_cuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla_estado_de_cuenta.Click
        If grilla_estado_de_cuenta.Rows.Count = 0 Then
            Exit Sub
        End If
        mostrar_malla_detalle()
    End Sub

    Private Sub grilla_estado_de_cuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grilla_estado_de_cuenta.KeyPress

    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        If grilla_estado_de_cuenta.Rows.Count = 0 Then
            MsgBox("MALLA VACIA, FAVOR LLENAR", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
            combo_mecanico.Focus()
            Exit Sub
        End If

        lbl_mensaje.Visible = True
        Me.Enabled = False

        PrintDialog1.Document = PrintDocument1

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument1.DefaultPageSettings.Landscape = False
            PrintDocument1.Print()

            Try
                PrintDocument1.DefaultPageSettings.Landscape = False
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Custom
                PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize.PaperName = PaperKind.Letter
            Catch
            End Try
        End If

        lbl_mensaje.Visible = False
        Me.Enabled = True
    End Sub

    Private Function ReturnDataSet() As DataSet

        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ds As New DataSet

        dt.Columns.Add(New DataColumn("logo_empresa", GetType(Byte())))
        dt.Columns.Add(New DataColumn("nombre_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("giro_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("comuna_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("telefono_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("correo_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("rut_empresa", GetType(String)))
        dt.Columns.Add(New DataColumn("fechas", GetType(String)))
        dt.Columns.Add(New DataColumn("titulo", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn1", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn2", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn3", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn4", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn5", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn6", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn7", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn8", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn9", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn10", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn11", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn12", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn13", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn14", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn15", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn16", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn17", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn18", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn19", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn20", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn21", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn22", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn23", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn24", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn25", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn26", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn27", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn28", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn29", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn30", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn31", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn32", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn33", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn34", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DataColumn35", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn36", GetType(String)))
        dt.Columns.Add(New DataColumn("DataColumn37", GetType(String)))


        Dim VarFecha As String
        Dim VarVehiculo As String
        Dim VarPatente As String
        Dim VarKilometros As String
        Dim VarCantidad As String
        Dim VarCodigo As String
        Dim VarNombre As String
        Dim VarNumeroTecnico As String

        VarFecha = grilla_estado_de_cuenta.CurrentRow.Cells(0).Value.ToString
        VarVehiculo = grilla_estado_de_cuenta.CurrentRow.Cells(2).Value.ToString
        VarPatente = grilla_estado_de_cuenta.CurrentRow.Cells(1).Value.ToString
        VarKilometros = grilla_estado_de_cuenta.CurrentRow.Cells(3).Value.ToString

        For i = 0 To grilla_detalle_productos.Rows.Count - 1
       

            VarCantidad = grilla_detalle_productos.Rows(i).Cells(0).Value.ToString
            VarCodigo = grilla_detalle_productos.Rows(i).Cells(1).Value.ToString
            VarNombre = grilla_detalle_productos.Rows(i).Cells(2).Value.ToString
            VarNumeroTecnico = grilla_detalle_productos.Rows(i).Cells(3).Value.ToString

            dr = dt.NewRow()

            Try
                dr("logo_empresa") = Imagen_reporte
            Catch
            End Try

            'dr("nombre_empresa") = minombreempresa
            'dr("giro_empresa") = migiroempresa
            'dr("direccion_empresa") = midireccionempresa
            'dr("comuna_empresa") = micomunaempresa
            'dr("telefono_empresa") = mitelefonoempresa
            'dr("correo_empresa") = micorreoempresa
            'dr("rut_empresa") = mirutempresa

            Try
                dr("DataColumn1") = "POR MEDIO DE LA PRESENTE, LA EMPRESA RAFAEL ARANA Y CÍA CERTIFICA QUE EL DÍA " & VarFecha & " SE RECIBIÓ EL VEHÍCULO " & VarVehiculo & " , PATENTE " & VarPatente & " , CON " & VarKilometros & " KMS., Y SE LE INSTALARON LOS SIGUIENTES ITEMS:"
            Catch
            End Try

            Try
                dr("DataColumn2") = VarCantidad
            Catch
            End Try

            Try
                dr("DataColumn3") = VarCodigo
            Catch
            End Try

            Try
                dr("DataColumn4") = VarNombre
            Catch
            End Try

            Try
                dr("DataColumn5") = VarNumeroTecnico
            Catch
            End Try

            dt.Rows.Add(dr)
        Next

        ds.Tables.Add(dt)
        ds.Tables(0).TableName = "DS_reporte"

        Dim iDS As New DS_reporte
        iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
        Return iDS
    End Function

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        format1.Alignment = StringAlignment.Far

        Dim Font_titulo As New Font("arial", 12, FontStyle.Regular)
        Dim Font_subtitulo As New Font("arial", 9, FontStyle.Regular)
        Dim Font_titulo_columna As New Font("verdana", 8, FontStyle.Bold)
        Dim Font_texto_impresion As New Font("verdana", 8, FontStyle.Regular)
        Dim Font_campos_superiores As New Font("verdana", 9.5, FontStyle.Regular)
        Dim Font_datos_empresa As New Font("verdana", 7, FontStyle.Regular)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim margen_izquierdo As Integer
        Dim margen_superior As Integer

        margen_izquierdo = -30
        margen_superior = 0

        Try
            e.Graphics.DrawImage(Bytes_Imagen(Imagen_reporte), 560, 10, 260, 70)
        Catch
        End Try

        e.Graphics.DrawString(minombreempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 10)
        e.Graphics.DrawString(migiroempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 20)
        e.Graphics.DrawString(midireccionempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 30)
        e.Graphics.DrawString(micomunaempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 40)
        e.Graphics.DrawString(mitelefonoempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 50)
        e.Graphics.DrawString(mirutempresa, Font_datos_empresa, Brushes.Black, margen_izquierdo + 50, margen_superior + 60)

        Dim rect1 As New Rectangle(margen_izquierdo + 50, margen_superior + 60, margen_izquierdo + 810, margen_superior + 60)
        Dim rect2 As New Rectangle(margen_izquierdo + 50, margen_superior + 75, margen_izquierdo + 810, margen_superior + 75)

        e.Graphics.DrawString("CERTIFICADO DE TRABAJO RALIZADO", Font_titulo, Brushes.Black, rect1, stringFormat)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 100, margen_izquierdo + 865, margen_superior + 100)

    
        Dim VarFecha As String
        Dim VarVehiculo As String
        Dim VarPatente As String
        Dim VarKilometros As String
        Dim VarCantidad As String
        Dim VarCodigo As String
        Dim VarNombre As String
        Dim VarNumeroTecnico As String
        Dim numero_lineas As Integer = 0
        Dim multiplicador_lineas As Integer = 15

        VarFecha = grilla_estado_de_cuenta.CurrentRow.Cells(0).Value.ToString
        VarVehiculo = grilla_estado_de_cuenta.CurrentRow.Cells(2).Value.ToString
        VarPatente = grilla_estado_de_cuenta.CurrentRow.Cells(1).Value.ToString
        VarKilometros = grilla_estado_de_cuenta.CurrentRow.Cells(3).Value.ToString

        If VarFecha.Length > 10 Then
            VarFecha = VarFecha.Substring(0, 10)
        End If

        e.Graphics.DrawString("POR MEDIO DE LA PRESENTE, LA EMPRESA ARANA Y CIA LIMITADA CERTIFICA QUE EL DÍA " & VarFecha & " SE", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 130)
        e.Graphics.DrawString("RECIBIÓ EL VEHÍCULO " & VarVehiculo & ", PATENTE " & VarPatente & ", CON " & VarKilometros & " KMS., Y SE LE INSTALARON LOS", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 145)
        e.Graphics.DrawString("SIGUIENTES ITEMS:", Font_campos_superiores, Brushes.Black, margen_izquierdo + 50, margen_superior + 160)

        e.Graphics.DrawString("CANTIDAD", Font_titulo_columna, Brushes.Black, margen_izquierdo + 140, margen_superior + 200, format1)
        e.Graphics.DrawString("CODIGO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 200, margen_superior + 200)
        e.Graphics.DrawString("DESCRIPCION", Font_titulo_columna, Brushes.Black, margen_izquierdo + 300, margen_superior + 200)
        e.Graphics.DrawString("NRO. TECNICO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 600, margen_superior + 200)
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 220, margen_izquierdo + 865, margen_superior + 220)

        For i = numero_lineas_total To grilla_detalle_productos.Rows.Count - 1
            VarCantidad = grilla_detalle_productos.Rows(i).Cells(0).Value.ToString
            VarCodigo = grilla_detalle_productos.Rows(i).Cells(1).Value.ToString
            VarNombre = grilla_detalle_productos.Rows(i).Cells(2).Value.ToString
            VarNumeroTecnico = grilla_detalle_productos.Rows(i).Cells(3).Value.ToString

            If VarNombre.Length > 25 Then
                VarNombre = VarNombre.Substring(0, 25)
            End If

            If VarNumeroTecnico.Length > 25 Then
                VarNumeroTecnico = VarNumeroTecnico.Substring(0, 25)
            End If

            e.Graphics.DrawString(VarCantidad, Font_texto_impresion, Brushes.Black, margen_izquierdo + 140, margen_superior + 230 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarCodigo, Font_texto_impresion, Brushes.Black, margen_izquierdo + 200, margen_superior + 230 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarNombre, Font_texto_impresion, Brushes.Black, margen_izquierdo + 300, margen_superior + 230 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            e.Graphics.DrawString(VarNumeroTecnico, Font_texto_impresion, Brushes.Black, margen_izquierdo + 600, margen_superior + 230 + (numero_lineas * multiplicador_lineas))
            '***************************************************************************************************************************************************

            numero_lineas = numero_lineas + 1
            numero_lineas_total = numero_lineas_total + 1

            If numero_lineas > 85 Then
                'Linea horizontal
                e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 240 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 240 + (numero_lineas * multiplicador_lineas))
                '***************************************************************************************************************************************************
                e.HasMorePages = True ' Todavia faltan mas paginas
                Exit Sub
            Else
                e.HasMorePages = False
            End If
        Next

        'Linea horizontal
        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 40, margen_superior + 240 + (numero_lineas * multiplicador_lineas), margen_izquierdo + 865, margen_superior + 240 + (numero_lineas * multiplicador_lineas))
        '***************************************************************************************************************************************************


        e.Graphics.DrawLine(Pens.Black, margen_izquierdo + 200, margen_superior + 900, margen_izquierdo + 665, margen_superior + 900)
        e.Graphics.DrawString("LUBRICENTRO ARANA, QUECHEREGUAS 856, SAN FERNANDO", Font_titulo_columna, Brushes.Black, margen_izquierdo + 240, margen_superior + 915)
        e.Graphics.DrawString("ARANA Y CIA LIMITADA", Font_titulo_columna, Brushes.Black, margen_izquierdo + 360, margen_superior + 930)
        numero_lineas_total = 0
    End Sub
End Class