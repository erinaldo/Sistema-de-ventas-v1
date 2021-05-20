using ITD.AccDatos;
using ITD.Funciones;
using ITD.Log;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Comun {
  public class General {

    #region Resultados

    public class ClaseBase {
      public Error Error { get; set; }
    }

    public class Error {
      public string Mensaje { get; set; }
      public int Numero { get; set; }
    }

    public class ResDocProvResumen : ClaseBase {
      public ResDocProvResumen() {
        Error = new Error();
      }

      public List<DocProvResumen> ListaDocumentos { get; set; }

    }


    public class ResAceptaRechaza : ClaseBase {
      public ResAceptaRechaza() {
        Error = new Error();
      }

      public bool Resultado { get; set; }

    }


    public class DocProvResumen {
      public int Id { get; set; }
      public string TipoDoc { get; set; }
      public string RutEmisor { get; set; }
      public string RazonSocial { get; set; }
      public long Folio { get; set; }
      public DateTime FechaEmision { get; set; }
      public decimal MontoTotal { get; set; }
      public DateTime FechaRecepcion { get; set; }
      public bool TieneXML { get; set; }
      public List<DocProvRespuesta> ListaRespuestaas { get; set; }
    }

    public class DocProvRespuesta {
      public int IdResumen { get; set; }
      public string Codigo { get; set; }
      public string Descripcion { get; set; }
      public DateTime? FechaAcepRec { get; set; }
    }

    public class ResDTEXML : ClaseBase {
      public ResDTEXML() {
        Error = new Error();
      }
      public byte[] DTE { get; set; }
      public DateTime FechaAcepta { get; set; }
    }

    public class ResBooleano : ClaseBase {

      public ResBooleano() {
        Resultado = false;
        Error = new Error();
      }

      public bool Resultado { get; set; }
    }

    public class ResEntero : ClaseBase {

      public ResEntero() {
        Resultado = 0;
        Error = new Error();
      }

      public int Resultado { get; set; }
    }

    public class ResEstado : ClaseBase {

      public ResEstado() {
        Error = new Error();
      }

      public int IdEstado { get; set; }
      public string Estado { get; set; }
      public string InfoEstado { get; set; }
    }

    public class ResEstadoMasivo : ClaseBase {

      public ResEstadoMasivo() {
        Error = new Error();
      }

      public List<ResEstadoValor> ListaDocEstado { get; set; }

    }

    public class ResEstadoValor : ClaseBase {

      public ResEstadoValor() {
        Error = new Error();
      }

      public int Folio { get; set; }
      public int TipoDoc { get; set; }
      public int IdEstado { get; set; }
      public string Estado { get; set; }
      public string InfoEstado { get; set; }

    }

    public class ResByte : ClaseBase {

      public ResByte() {
        Error = new Error();
      }

      public byte[] Resultado { get; set; }
    }

    public class ResString : ClaseBase {

      public ResString() {
        Error = new Error();
      }

      public string Resultado { get; set; }
    }

    public class ResXML : ClaseBase {

      public ResXML() {
        Error = new Error();
      }

      public string ArchivoTemporal { get; set; }
      public string ArchivoFinal { get; set; }
      public string DatosPDF417 { get; set; }
    }

    public class ResXMLCesion : ClaseBase {

      public ResXMLCesion() {
        Error = new Error();
      }

      public string ArchivoTemporal { get; set; }
      public string ArchivoFinal { get; set; }
    }

    #endregion Resultados

    #region Parametros
    
    public class Empresa {
      public int IdEmpresa { get; set; }
      public int Rut { get; set; }
      public string DV { get; set; }
      public string Nombre { get; set; }
      public string RazonSocial { get; set; }
      public AccMsSql Datos { get; set; }
      public string Identificador { get; set; }
      public string ClaveCertificado { get; set; }
      public string RutaCertificado { get; set; }
      public byte[] Certificado { get; set; }
      public string RutEnvia { get; set; }
    }

    public class ParamDocProvXML {
      public int TipoDoc { get; set; }
      public string RutEmisor { get; set; }
      public long Folio { get; set; }
    }

    public class ParamDocProvResumen {
      public DateTime Desde { get; set; }
      public DateTime Hasta { get; set; }
    }


    public class ParamAceptaRechaza {
      public int RutEmisor { get; set; }
      public string DV { get; set; }
      public int TipoDoc { get; set; }
      public long Folio { get; set; }
      public string Accion { get; set; }
    }


    public class ParamRutTipoNum {
      public bool AmbienteProduccion { get; set; }
      public string RutEmisor { get; set; }
      public int TipoDoc { get; set; }
      public int Numero { get; set; }
    }

    public class ParamEstadoMasivo {
      public DateTime FechaDesde { get; set; }
      public bool AmbienteProduccion { get; set; }
      public string RutEmisor { get; set; }
      public int? TipoDoc { get; set; }
    }

    public class ParamXML {
      public string RutEmisor { get; set; }
      public int TipoDoc { get; set; }
      public int Folio { get; set; }  
      public bool AmbienteProduccion { get; set; }
    }

    public class ParamPDF {
      public string RutEmisor { get; set; }
      public int TipoDoc { get; set; }
      public long Folio { get; set; }
      public bool AmbienteProduccion { get; set; }
      public bool Cedible { get; set; }
    }

    public class ParamCAF {
      public string RutEmisor { get; set; }
      public int TipoDoc { get; set; }
      public byte[] ArchivoCAF { get; set; }
      public bool AmbienteProduccion { get; set; }
    }

    public class ParamCertificado {
      public string RutCertificado { get; set; }
      public string ClaveCertificado { get; set; }
      public byte[] Archivo { get; set; }
      public DateTime? FechaVcto { get; set; }
    }

    #endregion Parametros

    public const int ERROR_ACCESO = 100;
    public const int ERROR_SQL = 200;
    public const int ERROR = 5000;

    public X509Certificate2 ObtenerCertificado(string strRutaCertificado, string strClave) {
      ////
      //// Respuesta
      X509Certificate2 certificado = null;
      if (!File.Exists(strRutaCertificado)) {
        return null;
      }

      try {
        string strErr = "";
        byte[] cert = FuncGen.FileToByte(strRutaCertificado, ref strErr);

        certificado = new X509Certificate2(cert, strClave, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
      } catch (Exception ex) {
        ManejadorLog.Log.Error("Error al obtener el certificado", ex);
        certificado = null;
      }

      ////
      //// Regrese el valor de retorno
      return certificado;
    }

    public X509Certificate2 ObtenerCertificado(byte[] bytCertificado, string strClave) {
      ////
      //// Respuesta
      X509Certificate2 certificado = null;

      try {
        string strErr = "";
        byte[] cert = bytCertificado;

        certificado = new X509Certificate2(cert, strClave, X509KeyStorageFlags.UserKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable | X509KeyStorageFlags.MachineKeySet);
      } catch (Exception ex) {
        ManejadorLog.Log.Error("Error al obtener el certificado", ex);
        certificado = null;
      }

      ////
      //// Regrese el valor de retorno
      return certificado;
    }

    public string RetornarFirma(string DD, string pk) {
      string strDD = LimpiarDD(DD);
      pk = pk.Replace("-----BEGIN RSA PRIVATE KEY-----", "").Replace("-----END RSA PRIVATE KEY-----", "");

      pk = Regex.Replace(pk, @"\n", "");

      Encoding ByteConverter = Encoding.GetEncoding("ISO-8859-1");
      byte[] bytesStrDD = ByteConverter.GetBytes(strDD);
      byte[] HashValue = new SHA1CryptoServiceProvider().ComputeHash(bytesStrDD);
      RSACryptoServiceProvider rsa = FuncionesComunes.crearRsaDesdePEM(pk);

      byte[] b = rsa.SignHash(HashValue, "SHA1");

      return Convert.ToBase64String(b);
    }

    public XmlElement firmarDocumentoXml(ref XmlDocument xmldocument, X509Certificate2 certificado, string referenciaUri) {
      ////
      //// Cree el objeto SignedXml donde xmldocument
      //// representa el documento DTE preparado para
      //// ser firmado. Recuerde que debe ser abierto
      //// con la propiedad PreserveWhiteSpace = true

      SignedXml signedXml = new SignedXml(xmldocument);

      ////
      //// Agregue la clave privada al objeto signedXml
      signedXml.SigningKey = certificado.PrivateKey;

      ////
      //// Recupere el objeto signature desde signedXml
      Signature XMLSignature = signedXml.Signature;

      ////
      //// Cree la refrerencia al documento DTE
      //// recuerde que la referencia tiene el
      //// formato '#reference'
      //// ejemplo '#DTE001'
      Reference reference = new Reference();
      reference.Uri = referenciaUri;

      ////
      //// Agregue la referencia al objeto signature
      XMLSignature.SignedInfo.AddReference(reference);
      KeyInfo keyInfo = new KeyInfo();
      keyInfo.AddClause(new RSAKeyValue((RSA)certificado.PrivateKey));

      ////
      //// Agregar información del certificado x509
      keyInfo.AddClause(new KeyInfoX509Data(certificado));
      XMLSignature.KeyInfo = keyInfo;

      ////
      //// Calcule la firma y recupere la representacion
      //// de la firma en un objeto xmlElement
      signedXml.ComputeSignature();
      XmlElement xmlDigitalSignature = signedXml.GetXml();

      ////
      //// Inserte la firma en el documento DTE
      xmldocument.DocumentElement.AppendChild(xmldocument.ImportNode(xmlDigitalSignature, true));

      return xmlDigitalSignature;
    }

    public string LimpiarDD(string str) {
      str = str.Replace(Environment.NewLine, "");
      str = Regex.Replace(str, @">(\s+)<", "><");
      return str;
    }

    public string GetVariableName<T>(Expression<Func<T>> expr) {
      var body = (MemberExpression)expr.Body;

      return body.Member.Name;
    }

    public string Validar(string strValor, string strNombreVariable, bool bolObligatorioDTE, int intLargo, bool bolExportacion = false, bool bolRut = false) {
      StringBuilder stbError = new StringBuilder();
      //string strMaxLargo = "Ha superado el largo del campo {0} ({1})", strRequerido = "{0} es requerido", strNoValido = "{0} es no válido";

      if (bolObligatorioDTE) {
        if (!bolExportacion && string.IsNullOrWhiteSpace(strValor))
          Validar(strNombreVariable, true);
        else if (intLargo > 0 && strValor.Length > intLargo)
          Validar(strNombreVariable, false, false, intLargo);
      } else
        if (intLargo > 0 && strValor.Length > intLargo)
        Validar(strNombreVariable, false, false, intLargo);

      if (bolRut && !string.IsNullOrWhiteSpace(strValor) && !FuncGen.ValidarRut(strValor))
        Validar(strNombreVariable, false, true);

      return stbError.ToString();
    }

    public string Validar(string strNombreVariable, bool bolRequerido = false, bool bolNoValido = false, int intLargo = 0) {
      StringBuilder stbError = new StringBuilder();
      string strMaxLargo = "Ha superado el largo del campo {0} ({1})", strRequerido = "{0} es requerido", strNoValido = "{0} es no válido";

      if (bolRequerido)
        stbError.AppendFormat(strRequerido, strNombreVariable).AppendLine();
      else if (bolNoValido)
        stbError.AppendFormat(strNoValido, strNombreVariable).AppendLine();
      else if (intLargo > 0)
        stbError.AppendFormat(strMaxLargo, strNombreVariable, intLargo).AppendLine();

      return stbError.ToString();
    }

    public byte[] GenerarImagenTimbre(string DatosPDF417) {
      BarcodePDF417 pdf417 = new BarcodePDF417();
      pdf417.CodeRows = 5;
      pdf417.CodeColumns = 18;
      pdf417.ErrorLevel = 5;
      pdf417.LenCodewords = 999;
      pdf417.Options = BarcodePDF417.PDF417_FORCE_BINARY;

      pdf417.Text = Encoding.GetEncoding("ISO-8859-1").GetBytes(DatosPDF417);

      Bitmap bmp = new Bitmap(pdf417.CreateDrawingImage(Color.Black, Color.White));

      ImageConverter converter = new ImageConverter();
      return (byte[])converter.ConvertTo(bmp, typeof(byte[]));
    }

  }


  public class FuncionesComunes {
    private static readonly bool verbose = false;

    public static RSACryptoServiceProvider crearRsaDesdePEM(string base64) {
      ////
      //// Extraiga de la cadena los header y footer
      base64 = base64.Replace("-----BEGIN RSA PRIVATE KEY-----", string.Empty);
      base64 = base64.Replace("-----END RSA PRIVATE KEY-----", string.Empty);

      ////
      //// el resultado que se encuentra en base 64 cambielo a
      //// resultado string
      byte[] arrPK = Convert.FromBase64String(base64);

      ////
      //// obtenga el Rsa object a partir de
      return DecodeRSAPrivateKey(arrPK);
    }

    public static RSACryptoServiceProvider DecodeRSAPrivateKey(byte[] privkey) {
      byte[] MODULUS, E, D, P, Q, DP, DQ, IQ;

      // --------- Set up stream to decode the asn.1 encoded RSA private key ------
      MemoryStream mem = new MemoryStream(privkey);
      BinaryReader binr = new BinaryReader(mem); //wrap Memory Stream with BinaryReader for easy reading
      byte bt = 0;
      ushort twobytes = 0;
      int elems = 0;
      try {
        twobytes = binr.ReadUInt16();
        if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
          binr.ReadByte(); //advance 1 byte
        else if (twobytes == 0x8230)
          binr.ReadInt16(); //advance 2 bytes
        else
          return null;

        twobytes = binr.ReadUInt16();
        if (twobytes != 0x0102) //version number
          return null;
        bt = binr.ReadByte();
        if (bt != 0x00)
          return null;

        //------ all private key components are Integer sequences ----
        elems = GetIntegerSize(binr);
        MODULUS = binr.ReadBytes(elems);

        elems = GetIntegerSize(binr);
        E = binr.ReadBytes(elems);

        elems = GetIntegerSize(binr);
        D = binr.ReadBytes(elems);

        elems = GetIntegerSize(binr);
        P = binr.ReadBytes(elems);

        elems = GetIntegerSize(binr);
        Q = binr.ReadBytes(elems);

        elems = GetIntegerSize(binr);
        DP = binr.ReadBytes(elems);

        elems = GetIntegerSize(binr);
        DQ = binr.ReadBytes(elems);

        elems = GetIntegerSize(binr);
        IQ = binr.ReadBytes(elems);

        Console.WriteLine("showing components ..");
        if (verbose) {
          showBytes("\nModulus", MODULUS);
          showBytes("\nExponent", E);
          showBytes("\nD", D);
          showBytes("\nP", P);
          showBytes("\nQ", Q);
          showBytes("\nDP", DP);
          showBytes("\nDQ", DQ);
          showBytes("\nIQ", IQ);
        }

        // ------- create RSACryptoServiceProvider instance and initialize with public key -----
        CspParameters CspParameters = new CspParameters();
        CspParameters.Flags = CspProviderFlags.UseMachineKeyStore | CspProviderFlags.UseDefaultKeyContainer | CspProviderFlags.NoPrompt;
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(1024, CspParameters);
        RSAParameters RSAparams = new RSAParameters();
        RSAparams.Modulus = MODULUS;
        RSAparams.Exponent = E;
        RSAparams.D = D;
        RSAparams.P = P;
        RSAparams.Q = Q;
        RSAparams.DP = DP;
        RSAparams.DQ = DQ;
        RSAparams.InverseQ = IQ;
        RSA.ImportParameters(RSAparams);
        return RSA;
      } catch (Exception EX) {
        return null;
      } finally {
        binr.Close();
      }
    }

    private static int GetIntegerSize(BinaryReader binr) {
      byte bt = 0;
      byte lowbyte = 0x00;
      byte highbyte = 0x00;
      int count = 0;
      bt = binr.ReadByte();
      if (bt != 0x02) //expect integer
        return 0;
      bt = binr.ReadByte();

      if (bt == 0x81)
        count = binr.ReadByte(); // data size in next byte
      else if (bt == 0x82) {
        highbyte = binr.ReadByte(); // data size in next 2 bytes
        lowbyte = binr.ReadByte();
        byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
        count = BitConverter.ToInt32(modint, 0);
      } else count = bt; // we already have the data size

      while (binr.ReadByte() == 0x00) {
        //remove high order zeros in data
        count -= 1;
      }
      binr.BaseStream.Seek(-1, SeekOrigin.Current); //last ReadByte wasn't a removed zero, so back up a byte
      return count;
    }

    private static void showBytes(String info, byte[] data) {
      Console.WriteLine("{0} [{1} bytes]", info, data.Length);
      for (int i = 1; i <= data.Length; i++) {
        Console.Write("{0:X2} ", data[i - 1]);
        if (i % 16 == 0)
          Console.WriteLine();
      }
      Console.WriteLine("\n\n");
    }
  }

}
