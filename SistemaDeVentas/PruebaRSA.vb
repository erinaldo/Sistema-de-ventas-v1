Option Strict On

Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Public Class PruebaRSA
    Private Shared dirPruebas As String = "C:\Pruebas3\RSA cripto"
    Private Shared ficPruebas As String = Path.Combine(dirPruebas, "MisClaves.xml")

    Public Shared Sub Main()
        ' Cifrar y descifrar con RSA
        Console.Title = "Cifrar y descifrar con RSA"

        ' Si no existe el fichero de claves,
        ' crearlo y guardarlo en el fichero indicado
        If File.Exists(ficPruebas) = False Then
            crearXMLclaves(ficPruebas)
        End If

        ' Leer las claves del fichero
        Dim xmlKeys As String = clavesXML(ficPruebas)

        ' Cifrar la cadena indicada
        Dim datos As Byte() = cifrar("Claudio Andres Calderon Ramirez", xmlKeys)

        ' Descifrar el array de bytes con la cadena cifrada
        Dim res As String = descifrar(datos, xmlKeys)

        ' Mostrar el texto descifrado
        Console.WriteLine(res)

        Console.ReadLine()
    End Sub

    ''' <summary>
    ''' Guarda las claves en el fichero indicado
    ''' </summary>
    Private Shared Sub crearXMLclaves(ByVal ficPruebas As String)
        Dim rsa As New RSACryptoServiceProvider()

        Dim xmlKey As String = rsa.ToXmlString(True)

        ' Si no existe el directorio, crearlo
        Dim dirPruebas As String = Path.GetDirectoryName(ficPruebas)

        If Directory.Exists(dirPruebas) = False Then
            Directory.CreateDirectory(dirPruebas)
        End If

        Using sw As New StreamWriter(ficPruebas, False, Encoding.UTF8)
            sw.WriteLine(xmlKey)
            sw.Close()
        End Using

    End Sub

    ''' <summary>
    ''' Lee las claves del fichero y las devuelve como una cadena
    ''' que se puede usar con FromXmlString de RSACryptoServiceProvider
    ''' </summary>
    Private Shared Function clavesXML(ByVal fichero As String) As String
        Dim s As String

        Using sr As New StreamReader(fichero, Encoding.UTF8)
            s = sr.ReadToEnd
            sr.Close()
        End Using

        Return s
    End Function

    ''' <summary>
    ''' Cifra el texto indicado usando las claves en formato XML
    ''' </summary>
    Private Shared Function cifrar(ByVal texto As String, ByVal xmlKeys As String) As Byte()
        Dim rsa As New RSACryptoServiceProvider()

        rsa.FromXmlString(xmlKeys)

        Dim datosEnc As Byte() = rsa.Encrypt(Encoding.Default.GetBytes(texto), False)

        Return datosEnc
    End Function

    ''' <summary>
    ''' Descifra el array de bytes usando las claves en formato XML
    ''' </summary>
    Private Shared Function descifrar(ByVal datosEnc As Byte(), ByVal xmlKeys As String) As String
        Dim rsa As New RSACryptoServiceProvider()

        rsa.FromXmlString(xmlKeys)

        Dim datos As Byte() = rsa.Decrypt(datosEnc, False)

        Dim res As String = Encoding.Default.GetString(datos)

        Return res
    End Function

    Private Sub PruebaRSA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Cifrar y descifrar con RSA
        'Console.Title = "Cifrar y descifrar con RSA"

        ' Si no existe el fichero de claves,
        ' crearlo y guardarlo en el fichero indicado
        If File.Exists(ficPruebas) = False Then
            crearXMLclaves(ficPruebas)
        End If

        ' Leer las claves del fichero
        Dim xmlKeys As String = clavesXML(ficPruebas)

        ' Cifrar la cadena indicada
        Dim datos As Byte() = cifrar("3c5445442076657273696f6e3d22312e30223e3c44443e3c52453e31363937323934302d393c2f52453e3c54443e33333c2f54443e3c463e373c2f463e3c46453e323031392d30362d31383c2f46453e3c52523e38373638363330302d363c2f52523e3c5253523e4152414e41205920434941204c5444412e3c2f5253523e3c4d4e543e313139303c2f4d4e543e3c4954313e534552564943494f5320444520494e464f524d41544943413c2f4954313e3c4341462076657273696f6e3d22312e30223e3c44413e3c52453e31363937323934302d393c2f52453e3c52533e434c415544494f20414e445245532043414c4445524f4e2052414d4952455a3c2f52533e3c54443e33333c2f54443e3c524e473e3c443e313c2f443e3c483e35303c2f483e3c2f524e473e3c46413e323031392d30352d31363c2f46413e3c525341504b3e3c4d3e78696b3333532f545867536d436e497a79556a503372457462684154776f574d5a4341365642475542354f723956646e4d423659426e6a426e68527042564a48384970376651335951494475704b6f2b7a46457265773d3d3c2f4d3e3c453e41773d3d3c2f453e3c2f525341504b3e3c49444b3e3130303c2f49444b3e3c2f44413e3c46524d4120616c676f7269746d6f3d225348413177697468525341223e77396833396a7347426258613641317a4874556d53375949686a6447465349773336642b67564358724e4938597268774d326e61465a367576542f3944463444614b5975666f6b62575976326a6d705650646c5369513d3d3c2f46524d413e3c2f4341463e3c54535445443e323031392d30362d31385431363a33373a35353c2f54535445443e3c2f44443e3c46524d5420616c676f7269746d6f3d225348413177697468525341223e6a65456c707a58684a6e6842762f545378347638625674413735575875635a5532394169784b49325976457458712b636a326d6a47494f712b78326d7963666768504b5a3547446155684133496762726b4376447a513d3d3c2f46524d543e3c2f5445443e", xmlKeys)



        'datos = Convert.FromBase64String("3Lszg8sMrfXBgW92UBo8NJdSX3jXr1+FZxVMHWWwQt1yX0sLxs4jCvMtf7vvY+xS4qCuXdCJ5IkJdk2YaLM4x1Z2AR1rYfB9s1+98F0s4mbX7wMLUj+U2l/R5xzdNphXtvj+hStr1/5xTqvH8SfyqHyuWuhBElgkeR3OxpaojaU=")

        ' Descifrar el array de bytes con la cadena cifrada
        Dim res As String = descifrar(datos, xmlKeys)

        ' Mostrar el texto descifrado
        'Console.WriteLine(res)

        'Console.ReadLine()


        TextBox1.Text = res
    End Sub
End Class