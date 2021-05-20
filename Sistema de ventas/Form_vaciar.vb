Imports System.Resources
Imports MySql.Data.MySqlClient

Public Class Form_vaciar

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        Dim valormensaje As Integer
        valormensaje = MsgBox("¿ESTA REALMENTE SEGURO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "ATENCION")

        If valormensaje = vbYes Then
            vaciar()
        End If
    End Sub

    Sub vaciar()

        Me.Enabled = False


        conexion.Close()

        ' conexion.ConnectionString = "Database=casa_bravo_520; Data Source=localhost; User Id=root;Password=1234;Convert Zero Datetime=True"

        Dim nombre_tabla As String
        Dim llave_primaria As String

        For i = 0 To grilla_tablas.Rows.Count - 1
            nombre_tabla = grilla_tablas.Rows(i).Cells(0).Value.ToString
            llave_primaria = grilla_tablas.Rows(i).Cells(1).Value.ToString
            If nombre_tabla <> "comuna" Then
                If nombre_tabla <> "empresa" Then
                    If nombre_tabla <> "valores" Then
                        If nombre_tabla <> "imagenes_de_sistema" Then
                            If nombre_tabla <> "imagenes_de_productos" Then
                                SC.Connection = conexion
                                SC.CommandText = "DELETE FROM " & (nombre_tabla) & " WHERE " & (llave_primaria) & " <> '1'"
                                DA.SelectCommand = SC
                                DA.Fill(DT)

                                SC.Connection = conexion
                                SC.CommandText = "DELETE FROM " & (nombre_tabla) & "  WHERE " & (llave_primaria) & " = '1'"
                                DA.SelectCommand = SC
                                DA.Fill(DT)
                            End If
                        End If
                    End If
                End If
            End If
        Next


        'INSERTO MI USUARIO
        SC.Connection = conexion
        SC.CommandText = "INSERT INTO  usuarios (rut_usuario, nombre_usuario, usuario, clave, tipo_usuario, area_usuario, pregunta_usuario, respuesta_usuario, telefono_usuario, autoriza_venta, tiempo_espera, fecha_modificacion, activo) VALUES ('16972940-9','CLAUDIO CALDERON R.','CCR','1010','ADMINISTRADOR DEL SISTEMA','INFORMATICA','OCUPACION DEL ABUELO','VENDEDOR','52642690','SI','999','2017-01-11', 'SI')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        'INSERTO EL USUARIO SISTEMA
        SC.Connection = conexion
        SC.CommandText = "INSERT INTO  usuarios (rut_usuario, nombre_usuario, usuario, clave, tipo_usuario, area_usuario, pregunta_usuario, respuesta_usuario, telefono_usuario, autoriza_venta, tiempo_espera, fecha_modificacion, activo) VALUES ('11111111-1','SISTEMA','SISTEMA','SISTEMA','ADMINISTRADOR DEL SISTEMA','INFORMATICA','OCUPACION DEL ABUELO','VENDEDOR','52642690','SI','999','2017-01-11', 'SI')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        'INSERTO UN CLIENTE

        SC.Connection = conexion
        SC.CommandText = "INSERT INTO `clientes` (`cod_cliente`, `rut_cliente`, `nombre_cliente`, `direccion_cliente`, `telefono_cliente`, `ciudad_cliente`, `comuna_cliente`, `giro_cliente`, `email_cliente`, `tipo_cliente`, `descuento_1`, `descuento_2`, `cuenta_cliente`) VALUES ('0', '-', '-', '-', '0', '-', '-', '-', '-', '-', '0', '0', '-');"
        DA.SelectCommand = SC
        DA.Fill(DT)

        SC.Connection = conexion
        SC.CommandText = "INSERT INTO clientes (cod_cliente, tipo_cliente, rut_cliente, nombre_cliente, direccion_cliente, telefono_cliente, email_cliente, comuna_cliente, giro_cliente, descuento_1, ciudad_cliente, descuento_2, folio_cliente, estado_cuenta, cuenta_cliente, tipo_cuenta, orden_de_compra, mensaje, cupo_cliente, saldo_cliente, fecha_modificacion, activo) VALUES  ('1','PERSONA','11111111-1','SIN NOMBRE','SIN DIRECCION','0','SIN CORREO','SIN COMUNA','SIN GIRO','0','SIN COMUNA','0','-','-', '-', '-', 'NO', 'SIN MENSAJE', '0', '0','2017-01-11', 'SI')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        'INSERTO UN PRODUCTO
        SC.Connection = conexion
        SC.CommandText = "INSERT INTO productos(cod_producto, nombre, marca, aplicacion, numero_tecnico, cantidad, precio, costo, factor, familia, subfamilia, subfamilia_dos, proveedor, codigo_barra, ultima_compra, cantidad_ultima_compra, nro_doc, tipo_doc, cantidad_minima, fecha_modificacion, margen, numero_proveedor, tipo_precio, estado_producto, activo) VALUES ('000001','PRODUCTO DE PRUEBA','PRUEBA','-','-','1000','500','100','0','0','0','0','11111111-1','0', '2017-01-11','0', '0', '-', '0', '2017-01-11', '0', '-', '0', '-', 'SI')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        'INSERTO UN PROVEEDOR
        SC.Connection = conexion
        SC.CommandText = "INSERT INTO PROVEEDORES (RUT_PROVEEDOR, NOMBRE_PROVEEDOR, DIRECCION_PROVEEDOR, TELEFONO_PROVEEDOR, EMAIL_PROVEEDOR, CIUDAD_PROVEEDOR, COMUNA_PROVEEDOR, GIRO_PROVEEDOR, REPRESENTANTE_PROVEEDOR, CREDITO_PROVEEDOR) VALUES ('11111111-1','PROVEEDOR DE PRUEBA','-','0','-','-','-','GIRO','-','0')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        'INSERTO UN CLIENTE QUE RETIRA
        SC.Connection = conexion
        SC.CommandText = "INSERT INTO clientes_retira (rut_cliente_retira, nombre_cliente_retira) VALUES  ('11111111-1','CLIENTE PRUEBA')"
        DA.SelectCommand = SC
        DA.Fill(DT)

        'INSERTO SUBFAMILIA
        SC.Connection = conexion
        SC.CommandText = "INSERT INTO `subfamilia` (`cod_auto`, `codigo_familia`, `nombre_subfamilia`, `fecha_modificacion`) VALUES ('0', '0', 'SIN SUBFAMILIA', '2018-07-31');"
        DA.SelectCommand = SC
        DA.Fill(DT)

        'INSERTO SUBFAMILIA DOS
        SC.Connection = conexion
        SC.CommandText = "INSERT INTO `subfamilia_dos` (`cod_auto`, `codigo_subfamilia`, `nombre_subfamilia`, `fecha_modificacion`) VALUES ('0', '0', 'SIN SUBFAMILIA DOS', '2018-07-31');"
        DA.SelectCommand = SC
        DA.Fill(DT)

        'INSERTO FAMILIA
        SC.Connection = conexion
        SC.CommandText = "INSERT INTO `familia` (`codigo`, `nombre_familia`, `fecha_modificacion`) VALUES ('0', 'SIN FAMILIA', '2018-07-31');"
        DA.SelectCommand = SC
        DA.Fill(DT)

        'RUTAS FACTURACION Y RESPALDO
        SC.Connection = conexion
        SC.CommandText = "INSERT INTO `rutas_archivos` (`cod_auto`, `archivo_plano_documentos_electronicos`, `archivo_plano_facturacion`, `archivo_respaldo`, `ruta_nube`) VALUES ('1', 'C:\\DTE\\Proceso', 'C:\\DTE\\Proceso', 'C:\\Google Drive', 'C:\\Program Files\\Google\\Drive\\googledrivesync.exe');"
        DA.SelectCommand = SC
        DA.Fill(DT)

        'CORREO ADMINISTRACION
        SC.Connection = conexion
        SC.CommandText = "INSERT INTO `correo_de_administracion` (`cod_auto`, `correo`, `clave_correo`, `seguridad_ssl`, `puerto_smtp`, `servidor_smtp`) VALUES ('1', 'CORREO@PRUEBA.CL', 'CORREO', 'SI', '587', 'smtp.gmail.com');"
        DA.SelectCommand = SC
        DA.Fill(DT)

        'CORREO VENTAS
        SC.Connection = conexion
        SC.CommandText = "INSERT INTO `correo_de_ventas` (`cod_auto`, `correo`, `clave_correo`, `seguridad_ssl`, `puerto_smtp`, `servidor_smtp`) VALUES ('1', 'CORREO@PRUEBA.CL', 'CORREO', 'SI', '587', 'smtp.gmail.com');"
        DA.SelectCommand = SC
        DA.Fill(DT)

        'VALORES
        SC.Connection = conexion
        SC.CommandText = "UPDATE `valores` SET `inicio_sugerir_codigo`='0', `inicio_codigo_cliente`='0', `inventario_inicial`='" & (Form_menu_principal.dtp_fecha.Text) & "', `valor_descuento_ventas`='0' WHERE `cod_auto`<>'0';"
        DA.SelectCommand = SC
        DA.Fill(DT)

        Me.Enabled = True
        MsgBox("DATOS MODIFICADOS CORRECTAMENTE", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "INFORMACION")
    End Sub

    Private Sub Form_vaciar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_tablas()
    End Sub


    Sub cargar_tablas()

        Dim nombre_tabla As String
        Dim llave_primaria As String

        grilla_tablas.Rows.Clear()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        SC.Connection = conexion
        SC.CommandText = "select table_name, column_name From information_schema.key_column_usage WHERE TABLE_SCHEMA='basededatos';"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)

        If DS.Tables(DT.TableName).Rows.Count > 0 Then
            For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
                nombre_tabla = DS.Tables(DT.TableName).Rows(i).Item("TABLE_NAME")
                llave_primaria = DS.Tables(DT.TableName).Rows(i).Item("column_name")

                grilla_tablas.Rows.Add(nombre_tabla, llave_primaria)
            Next
        End If
    End Sub
End Class