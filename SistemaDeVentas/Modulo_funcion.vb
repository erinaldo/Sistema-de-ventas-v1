Imports System.IO
Imports System.Security.Cryptography.X509Certificates

Module Modulo_funcion

    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean

    Public Sub LiberarMemoria()
        Try
            Dim memoria As Process
            memoria = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(memoria.Handle, -1, -1)
        Catch ex As Exception
        End Try
    End Sub

    Public Function RecuperarCertificado(ByVal CN As String) As X509Certificate2

        '''' string CN = "FERNANDO ANTONIO CARRANDI DIAZ";

        '''
        ''' Respuesta
        Dim certificado As X509Certificate2 = Nothing

        '''
        ''' Certificado que se esta buscando
        If String.IsNullOrEmpty(CN) OrElse CN.Length = 0 Then Return Nothing


        '''
        ''' Inicie la busqueda del certificado
        Try

            '''
            ''' Abra el repositorio de certificados para buscar el indicado
            Dim store As X509Store = New X509Store(StoreName.My, StoreLocation.CurrentUser)
            store.Open(OpenFlags.ReadOnly)
            Dim Certificados1 As X509Certificate2Collection = store.Certificates
            Dim Certificados2 As X509Certificate2Collection = Certificados1.Find(X509FindType.FindByTimeValid, Date.Now, False)
            Dim Certificados3 As X509Certificate2Collection = Certificados2.Find(X509FindType.FindBySubjectName, CN, False)

            '''
            ''' Si hay certificado disponible envíe el primero
            If Certificados3 IsNot Nothing AndAlso Certificados3.Count <> 0 Then certificado = Certificados3(0)

            '''
            ''' Cierre el almacen de sertificados
            store.Close()
        Catch __unusedException1__ As Exception
            certificado = Nothing
            MessageBox.Show("Error de certificado")
        End Try

        Return certificado
    End Function

    Sub recuperar_conexion_actual()
        Try
            conexion.Close()
            conexion.ConnectionString = conexion_actual
            conexion.Open()
            conexion.Close()
        Catch
            MsgBox("NO SE HA PODIDO RECUPERAR LA CONEXION, EL SISTEMA SE CERRARA.", 0 + 16, "ERROR")
            Application.Exit()
        End Try
        LiberarMemoria()
    End Sub

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

    Sub mostrar_cierre_sistema()
        If cierre_sistema = "" Then
            conexion.Close()
            DS.Tables.Clear()
            DT.Rows.Clear()
            DT.Columns.Clear()
            DS.Clear()
            conexion.Open()
            SC.Connection = conexion
            SC.CommandText = "select cierre_sistema from valores"
            DA.SelectCommand = SC
            DA.Fill(DT)
            DS.Tables.Add(DT)
            If DS.Tables(DT.TableName).Rows.Count > 0 Then
                cierre_sistema = DS.Tables(DT.TableName).Rows(0).Item("cierre_sistema")
            End If
        End If
        conexion.Close()
        If cierre_sistema = "NO" Then
            form_Ingreso.Show()
        End If
    End Sub

    Function dejarNumerosPuntos(ByVal cadenaTexto As String) As String
        Const listaNumeros = "0123456789"
        Dim cadenaTemporal As String
        Dim i As Integer

        cadenaTexto = Trim$(cadenaTexto)
        If Len(cadenaTexto) = 0 Then
            Return Nothing
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
            Return Nothing
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
        Dim mMaskChar As String =
"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVW XYZ0123456789-_.@"
        If agEmail.Length > 0 Then mEmailOk = True
        If mEmailOk Then
            mSubCad = agEmail.Substring(0, 1)
            If mSubCad = "." OrElse mSubCad = "@" Then mEmailOk = False
        End If
        If mEmailOk Then
            mSubCad = agEmail.Substring(agEmail.Length - 1, 1)
            If mSubCad = "." Or mSubCad = "@" Or mSubCad = "_" Or mSubCad =
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
                If mCadInd < agEmail.Length - 1 And (mSubCad = "@" OrElse
mSubCad = ".") Then
                    If agEmail.Substring(mCadInd + 1, 1) = "@" OrElse
agEmail.Substring(mCadInd + 1, 1) = "." Then
                        mCanDup += 1
                    End If
                End If
            Next
            If mCanChar <> 1 Or mCanDup > 0 Or mCanPunt < 1 Then mEmailOk =
False
        End If
        If agMsge AndAlso Not mEmailOk Then
            MessageBox.Show("Dirección de correo electrónico incorrecta !" &
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






    Public Function CambiaColorFondo(ByRef Control_color As Control, ByVal Rut_color As String)

        Dim Color_empresa_1 As Long
        Color_empresa_1 = RGB(0, 112, 130)

        If (TypeOf (Control_color) Is Label) Then
            Control_color.ForeColor = SystemColors.WindowFrame
        Else
            Control_color.BackColor = SystemColors.WindowFrame
        End If



        'Control_color.BackColor = SystemColors.WindowFrame

        'CLICKOFFICE
        If Rut_color = "16972940-9" Then
            If (TypeOf (Control_color) Is Label) Then
                Control_color.ForeColor = Color.FromArgb(40, 100, 137)
            Else
                Control_color.BackColor = Color.FromArgb(40, 100, 137)
            End If
        End If

        'NEUMAPRO
        If Rut_color = "18229026-2" Then
            If (TypeOf (Control_color) Is Label) Then
                Control_color.ForeColor = Color.FromArgb(0, 112, 130)
            Else
                Control_color.BackColor = Color.FromArgb(0, 112, 130)
            End If
        End If

        If Rut_color = "76474168-4" Then
            If (TypeOf (Control_color) Is Label) Then
                Control_color.ForeColor = Color.FromArgb(104, 0, 0)
            Else
                Control_color.BackColor = Color.FromArgb(104, 0, 0)
            End If
        End If

        If Rut_color = "87686300-6" Then
            If (TypeOf (Control_color) Is Label) Then
                Control_color.ForeColor = Color.FromArgb(24, 49, 106)
            Else
                Control_color.BackColor = Color.FromArgb(24, 49, 106)
            End If
        End If

        If Rut_color = "13501829-5" Then
            If (TypeOf (Control_color) Is Label) Then
                Control_color.ForeColor = Color.FromArgb(217, 0, 0)
            Else
                Control_color.BackColor = Color.FromArgb(217, 0, 0)
            End If
        End If


        If Rut_color = "76820004-1" Then
            If (TypeOf (Control_color) Is Label) Then
                Control_color.ForeColor = Color.FromArgb(10, 33, 61)
            Else
                Control_color.BackColor = Color.FromArgb(10, 33, 61)
            End If
        End If




        If Rut_color = "76366176-8" Then
            If (TypeOf (Control_color) Is Label) Then
                Control_color.ForeColor = Color.FromArgb(192, 0, 0)
            Else
                Control_color.BackColor = Color.FromArgb(192, 0, 0)
            End If
        End If

        Return Nothing
    End Function









End Module
