Public Class Form_dbf

    Private Sub Form_dbf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' mostrar_malla()
    End Sub
    Sub mostrar_malla()
        DS1.Tables.Clear()
        DT1.Rows.Clear()
        DT1.Columns.Clear()
        DS1.Clear()
        conexion.Open()

        SC1.Connection = conexion
        SC1.CommandText = "select * from maeprov"
        DA1.SelectCommand = SC1
        DA1.Fill(DT1)
        DS1.Tables.Add(DT1)

        migrilla.DataSource = DS1.Tables(DT1.TableName)
        conexion.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        actualizar()
    End Sub
    Sub actualizar()

        'Dim varupdate As String
        'Dim varrevisar As String


        'varupdate = migrilla.Rows(0).Cells(0).Value.ToString
        'varrevisar = migrilla.Rows(0).Cells(2).Value.ToString
        'For i = 0 To migrilla.Rows.Count - 1


        '    varupdate = migrilla.Rows(i).Cells(0).Value.ToString

        '    varrevisar = migrilla.Rows(i).Cells(6).Value.ToString



        '    varrevisar = UCase(varrevisar)

  


        'Next
        'MsgBox("listo")
        'mostrar_malla()












        Dim rut As String
        Dim nombre As String
        Dim direccion As String
        Dim ciudad As String
        Dim comuna As String
        Dim telefono As String
        Dim giro As String
        Dim NOMBRE_VENDEDOR As String

        'Dim numero_tecnico As String
        ''Dim cantidad_minima As String
        'Dim proveedor As String
        ''Dim margen As String
        ''Dim familia As String
        ''Dim subfamilia As String
        ''Dim codigo_barra As String
        ''txt_total_saldo.Text = "0"


        For i = 0 To migrilla.Rows.Count - 1
            rut = migrilla.Rows(i).Cells(0).Value.ToString
            nombre = migrilla.Rows(i).Cells(2).Value.ToString
            direccion = migrilla.Rows(i).Cells(3).Value.ToString
            ciudad = migrilla.Rows(i).Cells(4).Value.ToString
            comuna = migrilla.Rows(i).Cells(5).Value.ToString
            telefono = migrilla.Rows(i).Cells(6).Value.ToString
            giro = migrilla.Rows(i).Cells(8).Value.ToString
            NOMBRE_VENDEDOR = migrilla.Rows(i).Cells(10).Value.ToString

            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion

            ' SC.CommandText = "INSERT INTO PROVEEDORES(RUT_PROVEEDOR, NOMBRE_PROVEEDOR, DIRECCION_PROVEEDOR, CIUDAD_PROVEEDOR, COMUNA_PROVEEDOR, TELEFONO_PROVEEDOR, GIRO_PROVEEDOR) VALUES (" & (rut) & ",'" & (nombre) & "','" & (direccion) & "','" & (ciudad) & "','" & (comuna) & "','" & (telefono) & "','" & (giro) & "')"
            SC.CommandText = "INSERT INTO PROVEEDORES (RUT_PROVEEDOR, NOMBRE_PROVEEDOR, DIRECCION_PROVEEDOR, TELEFONO_PROVEEDOR, EMAIL_PROVEEDOR, CIUDAD_PROVEEDOR, COMUNA_PROVEEDOR, GIRO_PROVEEDOR, REPRESENTANTE_PROVEEDOR, CREDITO_PROVEEDOR) VALUES ('" & (rut) & "','" & (nombre) & "','" & (direccion) & "','" & (telefono) & "','" & ("-") & "','" & (ciudad) & "','" & (comuna) & "','" & (giro) & "','" & (NOMBRE_VENDEDOR) & "','" & (0) & "')"


            DA.SelectCommand = SC
            DA.Fill(DT)
            conexion.Close()
        Next
        MsgBox("listo")











    End Sub





End Class