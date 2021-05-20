Imports System.IO

Module Modulo_funcion
    Sub Consultas_SQL(ByVal a As String)
        conexion.Close()
        DS.Tables.Clear()
        DT.Rows.Clear()
        DT.Columns.Clear()
        DS.Clear()
        conexion.Open()

        SC.Connection = conexion
        SC.CommandText = "" & (a) & ""
        DA.SelectCommand = SC
        DA.Fill(DT)
        DS.Tables.Add(DT)
        conexion.Close()
    End Sub

    Function dejarNumerosPuntos(ByVal cadenaTexto As String) As String
        Const listaNumeros = "0123456789"
        Dim cadenaTemporal As String
        Dim i As Integer

        cadenaTexto = Trim$(cadenaTexto)
        If Len(cadenaTexto) = 0 Then
            Exit Function
        End If

        cadenaTemporal = ""

        For i = 1 To Len(cadenaTexto)
            If InStr(listaNumeros, Mid$(cadenaTexto, i, 1)) Then
                cadenaTemporal = cadenaTemporal + Mid$(cadenaTexto, i, 1)
            End If
        Next
        dejarNumerosPuntos = cadenaTemporal
    End Function

    Sub validar_comilla(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsControl(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Function Bytes_Imagen(ByVal Imagen As Byte()) As Image
        Try
            'si hay imagen
            If Not Imagen Is Nothing Then
                'caturar array con memorystream hacia Bin
                Dim Bin As New MemoryStream(Imagen)
                'con el método FroStream de Image obtenemos imagen
                Dim Resultado As Image = Image.FromStream(Bin)
                'y la retornamos
                Return Resultado
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function



    Function ImageToByte(ByVal pImagen As Image) As Byte()
        Dim mImage() As Byte
        Try
            If Not IsNothing(pImagen) Then
                Dim ms As New System.IO.MemoryStream
                pImagen.Save(ms, pImagen.RawFormat)
                mImage = ms.GetBuffer
                ms.Close()
                Return mImage
            Else
                Return Nothing
            End If
        Catch
        End Try
    End Function

    Function valida_rut(ByVal a As String) As Boolean
        Dim largoRut As Integer
        Dim michar As String
        Dim mirut As String = ""
        largoRut = Len(a)
        For i = 1 To largoRut
            michar = Mid(a, i, 1)
            If michar <> "," Then
                mirut = mirut & michar
            End If
        Next

        Dim suma, resto As Integer
        Dim dv As String

        Dim tamañocadena As Integer
        tamañocadena = Len(mirut)
        If mirut <> "        -" Then
            If tamañocadena < 9 Or tamañocadena > 10 Then
                MsgBox("RUT INCORRECTO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")

                Return False
                Exit Function
            ElseIf tamañocadena = 9 Then
                suma = CInt(Mid(mirut, 1, 1)) * 2 + CInt(Mid(mirut, 2, 1)) * 7 + CInt(Mid(mirut, 3, 1)) * 6 + CInt(Mid(mirut, 4, 1)) * 5 + CInt(Mid(mirut, 5, 1)) * 4 + CInt(Mid(mirut, 6, 1)) * 3 + CInt(Mid(mirut, 7, 1)) * 2
                resto = suma Mod 11
                dv = CStr(11 - resto)
                If dv = "10" Then dv = "K"
                If dv = "11" Then dv = "0"
                If dv = Mid(mirut, 9, 1) Then
                Else
                    MsgBox("RUT INCORRECTO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")
                    Return False
                    Exit Function
                End If
            Else
                If tamañocadena = 10 Then
                    suma = CInt(Mid(mirut, 1, 1)) * 3 + CInt(Mid(mirut, 2, 1)) * 2 + CInt(Mid(mirut, 3, 1)) * 7 + CInt(Mid(mirut, 4, 1)) * 6 + CInt(Mid(mirut, 5, 1)) * 5 + CInt(Mid(mirut, 6, 1)) * 4 + CInt(Mid(mirut, 7, 1)) * 3 + CInt(Mid(mirut, 8, 1)) * 2
                    resto = suma Mod 11
                    dv = CStr(11 - resto)
                    If dv = "10" Then dv = "K"
                    If dv = "11" Then dv = "0"
                    If dv = Mid(mirut, 10, 1) Then
                    Else
                        MsgBox("RUT INCORRECTO", MessageBoxIcon.Information + MsgBoxStyle.OkOnly, "ATENCION")

                        Return False
                        Exit Function
                    End If
                End If
            End If
        End If
        Return True
    End Function

    Public Function ValidEmail(ByVal agEmail As String, Optional ByVal _
agMsge As Boolean = True) As Boolean
        Dim mSubCad As String
        Dim mCadInd As Integer
        Dim mCanChar As Integer
        Dim mCanDup As Integer
        Dim mCanPunt As Integer
        Dim mEmailOk As Boolean = False
        Dim mMaskChar As String = _
"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVW XYZ0123456789-_.@"
        If agEmail.Length > 0 Then mEmailOk = True
        If mEmailOk Then
            mSubCad = agEmail.Substring(0, 1)
            If mSubCad = "." OrElse mSubCad = "@" Then mEmailOk = False
        End If
        If mEmailOk Then
            mSubCad = agEmail.Substring(agEmail.Length - 1, 1)
            If mSubCad = "." Or mSubCad = "@" Or mSubCad = "_" Or mSubCad = _
"-" Then mEmailOk = False
        End If
        If mEmailOk Then
            mCanChar = 0
            mCanDup = 0 'cantidad @. duplicados
            mCanPunt = 0 'cantidad de puntos despues de @
            For mCadInd = 0 To agEmail.Length - 1
                mSubCad = agEmail.Substring(mCadInd, 1)
                If mSubCad = "@" Then
                    mCanChar += 1
                    'primer punto despues de @
                    mCanPunt = agEmail.IndexOf(".", mCadInd)
                Else
                    If mMaskChar.IndexOf(mSubCad, 0) < 0 Then
                        'Caracter inválido, rompe bucle
                        mEmailOk = False
                        Exit For
                    End If
                End If
                If mCadInd < agEmail.Length - 1 And (mSubCad = "@" OrElse _
mSubCad = ".") Then
                    If agEmail.Substring(mCadInd + 1, 1) = "@" OrElse _
agEmail.Substring(mCadInd + 1, 1) = "." Then
                        mCanDup += 1
                    End If
                End If
            Next
            If mCanChar <> 1 Or mCanDup > 0 Or mCanPunt < 1 Then mEmailOk = _
False
        End If
        If agMsge AndAlso Not mEmailOk Then
            MessageBox.Show("Dirección de correo electrónico incorrecta !" & _
            System.Environment.NewLine & "Formato: usuario@dominio[.país]", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            'MessageBox.Show("Dirección de correo electrónico correcta !" & _
            'System.Environment.NewLine & "Formato: usuario@dominio[.país]", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return mEmailOk
    End Function






    Public Function Numeros(ByVal Tecla As Integer) As Integer
        Dim strValido As String
        'Esta es la cadena que contiene los caracteres aceptados en tu TextBox
        'Asi que si en el número de telefono le quieres aceptar algun otro
        'caracter lo puedes hacer tan solo con incluirlo en la cadena STRVALIDO
        strValido = "0123456789"
        If Tecla > 26 Then
            If InStr(strValido, Chr(Tecla)) = 0 Then 'Aqui se checa si la tecla pulsada esta en la cadena de numeros si regresa 0 quiere decir que no fue un numero
                Tecla = 0
            End If
        End If
        Numeros = Tecla
    End Function


End Module
