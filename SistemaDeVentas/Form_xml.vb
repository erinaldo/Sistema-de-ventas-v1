Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography

Public Class Form_xml
    Private Sub Form_xml_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Main()
    End Sub



    Sub Main()
        Dim m_xmlr As XmlTextReader
        'Create the XML Reader
        m_xmlr = New XmlTextReader("C:\SistemaVenta\Electronica\DTE\E-Factura\EFactura_4_envio.XML")
        'Disable whitespace so that you don't have to read over whitespaces
        m_xmlr.WhitespaceHandling = WhitespaceHandling.None
        'read the xml declaration and advance to family tag
        m_xmlr.Read()
        'read the family tag
        m_xmlr.Read()
        'Load the Loop
        While Not m_xmlr.EOF
            'Go to the name tag
            m_xmlr.Read()
            'if not start element exit while loop
            If Not m_xmlr.IsStartElement() Then
                Exit While
            End If
            'Get the Gender Attribute Value
            Dim Emisor = m_xmlr.GetAttribute("Emisor")
            'Read elements firstname and lastname
            m_xmlr.Read()
            'Get the firstName Element Value

            Dim RutEmisor = m_xmlr.ReadElementString("RutEmisor")

            Dim RznSoc = m_xmlr.ReadElementString("RznSoc")
            'Get the lastName Element Value
            Dim GiroEmis = m_xmlr.ReadElementString("GiroEmis")
            'Write Result to the Console
            Console.WriteLine("RutEmisor: " & RutEmisor _
                  & " RznSoc: " & RznSoc & " GiroEmis: " _
                  & GiroEmis)
            Console.Write(vbCrLf)
        End While
        'close the reader
        m_xmlr.Close()
    End Sub


    Sub cargar_doc()
        'Dim VarCodProducto As String
        'Dim varnombre As String
        'Dim vartecnico As String
        'Dim VarValorUnitario As Integer
        'Dim VarCantidad As Integer
        'Dim VarNeto As Integer
        'Dim VarIva As Integer
        'Dim VarSubtotal As Integer
        'Dim VarPorcentaje As Integer
        'Dim VarDescuento As Integer
        'Dim VarTotal As Integer
        'Dim VarPrecioReal As Integer
        'Dim iva_valor As String
        'Dim VarUnidadMedida As String

        'grilla_detalle_venta.Rows.Clear()
        'conexion.Close()
        '    DS.Tables.Clear()
        '    DT.Rows.Clear()
        '    DT.Columns.Clear()
        '    DS.Clear()
        '    SC.Connection = conexion
        '    SC.CommandText = "select * from detalle_boleta where detalle_boleta.n_boleta='" & (txt_cargar.Text) & "'"
        '    DA.SelectCommand = SC
        '    DA.Fill(DT)
        '    DS.Tables.Add(DT)
        'If DS.Tables(DT.TableName).Rows.Count > 0 Then
        '    For i = 0 To DS.Tables(DT.TableName).Rows.Count - 1
        '        VarCodProducto = DS.Tables(DT.TableName).Rows(i).Item("cod_producto")
        '        varnombre = DS.Tables(DT.TableName).Rows(i).Item("detalle_nombre")
        '        vartecnico = DS.Tables(DT.TableName).Rows(i).Item("numero_tecnico")
        '        VarValorUnitario = DS.Tables(DT.TableName).Rows(i).Item("valor_unitario")
        '        VarCantidad = DS.Tables(DT.TableName).Rows(i).Item("cantidad")
        '        VarNeto = DS.Tables(DT.TableName).Rows(i).Item("detalle_neto")
        '        VarIva = DS.Tables(DT.TableName).Rows(i).Item("detalle_iva")
        '        VarSubtotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_subtotal")
        '        VarPorcentaje = DS.Tables(DT.TableName).Rows(i).Item("porcentaje_desc")
        '        VarDescuento = DS.Tables(DT.TableName).Rows(i).Item("detalle_descuento")
        '        VarTotal = DS.Tables(DT.TableName).Rows(i).Item("detalle_total")
        '        conexion.Close()
        '        DS2.Tables.Clear()
        '        DT2.Rows.Clear()
        '        DT2.Columns.Clear()
        '        DS2.Clear()
        '        conexion.Open()
        '        SC2.Connection = conexion
        '        SC2.CommandText = "select * from productos where cod_producto ='" & (VarCodProducto) & "'"
        '        DA2.SelectCommand = SC2
        '        DA2.Fill(DT2)
        '        DS2.Tables.Add(DT2)
        '        If DS2.Tables(DT2.TableName).Rows.Count > 0 Then
        '            VarPrecioReal = DS2.Tables(DT2.TableName).Rows(0).Item("precio")
        '            VarUnidadMedida = DS2.Tables(DT2.TableName).Rows(0).Item("tipo_medida")
        '        End If
        '        conexion.Close()
        '        VarPorcentaje = Val(VarValorUnitario) * 100 / Val(VarPrecioReal)
        '        VarPorcentaje = 100 - VarPorcentaje
        '        VarDescuento = VarPrecioReal - VarValorUnitario
        '        VarValorUnitario = VarPrecioReal
        '        iva_valor = valor_iva / 100 + 1
        '        VarNeto = (VarTotal / iva_valor)
        '        VarIva = (VarNeto) * valor_iva / 100
        '        grilla_detalle_venta.Rows.Add(VarCodProducto,
        '            varnombre,
        '            vartecnico,
        '            VarValorUnitario,
        '            VarCantidad,
        '            VarNeto,
        '            VarIva,
        '            VarSubtotal,
        '            VarPorcentaje,
        '            VarDescuento,
        '            VarTotal,
        '            VarUnidadMedida)
        '    Next
        'End If
    End Sub

    Private Function SHA1(ByVal Content As String)
        Dim MoLeCuL3 As New Security.Cryptography.SHA1CryptoServiceProvider
        Dim ByteString() As Byte = System.Text.Encoding.ASCII.GetBytes(Content)

        Dim FinalString As String = Nothing

        For Each bt As Byte In ByteString
            FinalString &= bt.ToString("x2")
        Next

        Return FinalString
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Text = SHA1(TextBox1.Text)
    End Sub
End Class