Imports System.Data.OleDb
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.DirectoryServices
Imports System.Resources

Public Class Form_pruebas
    Dim mifecha2 As String
    Dim mifecha4 As String

    Private Sub Form_pruebas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_menu_principal.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form_pruebas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub Form_pruebas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_logo()


        fecha()



        malla_prueba()

    End Sub

    Sub fecha()
        'Dim mifecha As Date
        'mifecha = dtp_fecha_caja_desde.Text
        'mifecha2 = mifecha.ToString("yyy-MM-dd")

        'Dim mifecha3 As Date
        'mifecha3 = dtp_fecha_caja_hasta.Text
        'mifecha4 = mifecha3.ToString("yyy-MM-dd")
    End Sub

    Sub cargar_logo()
        Try
            PictureBox_logo.ImageLocation = "C:\Temp\" & mirutempresa & "\Logo-formulario.png"
        Catch
        End Try
    End Sub

    Sub malla_prueba()
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()
        SC.Connection = conexion
        SC.CommandText = " SELECT proveedor FROM productos group by proveedor asc;"
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        grilla_pruebas.DataSource = DS.Tables(DT.TableName)
        conexion.Close()
        txt_item.Text = grilla_pruebas.Rows.Count
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ejecutar.Click

        lbl_mensaje.Visible = True
        Me.Enabled = False

        Dim proveedor As String = ""
        Dim resultado As String = ""

        For i = 0 To grilla_pruebas.Rows.Count - 1

            proveedor = grilla_pruebas.Rows(i).Cells(0).Value.ToString

            conexion.Close()
            DS2.Tables.Clear()
            DT2.Rows.Clear()
            DT2.Columns.Clear()
            DS2.Clear()
            conexion.Open()
            SC2.Connection = conexion
            SC2.CommandText = "select * from proveedores where rut_proveedor='" & (proveedor) & "'"
            DA2.SelectCommand = SC2
            DA2.Fill(DT2)
            DS2.Tables.Add(DT2)
            If DS2.Tables(DT2.TableName).Rows.Count = 0 Then

                SC2.Connection = conexion
                SC2.CommandText = "UPDATE `productos` SET `proveedor`='11111111-1' WHERE `cod_producto`<>'000000' and proveedor='" & (proveedor) & "'"
                DA2.SelectCommand = SC2
                DA2.Fill(DT2)

                resultado = resultado & ", " & proveedor
            End If
            conexion.Close()
        Next

        lbl_mensaje.Visible = False
        Me.Enabled = True

        MsgBox("PROCESO TERMINADO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
        resultado = resultado
    End Sub


End Class