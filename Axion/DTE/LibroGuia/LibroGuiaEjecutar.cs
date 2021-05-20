using Comun;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static Comun.General;

namespace DTE.LibroGuia {


  public class LibroGuiaEjecutar {

     General objGeneral;

     public LibroGuiaEjecutar() {
      objGeneral = new General();
    }
    public ResXML GenerarXML(Empresa objEmpresa, ParamLibroGuia objLibroGuia, string strRutaTemporal, string strRutaFinal ) {
      //XmlAttribute att;
      Empresa objEmp = objEmpresa;
      string strRuta = strRutaTemporal;
      string strID = string.Format("E{0}T{1}F{2}", objLibroGuia.Libro.Caratula.RutEmisorLibro.Replace("-", ""), 97, objLibroGuia.Libro.Caratula.PeriodoTributario.ToString("yyyyMM"));
      objLibroGuia.Libro.Caratula.RutEnvia = objEmp.RutEnvia;
      string strNombreArchivo = string.Format("{0}.xml", strID);
      objLibroGuia.Libro.TmstFirma = DateTime.Now;

      if (!Directory.Exists(strRutaFinal))
        Directory.CreateDirectory(strRutaFinal);


      try {



      //  //objDTE.DTE.Documento.Encabezado.RUTMandante = objDTE.DTE.Documento.Encabezado.Emisor.RUTEmisor;
      //  //objDTE.DTE.Documento.Encabezado.RUTSolicita = objDTE.DTE.Documento.Encabezado.Emisor.RUTEmisor;

        XmlSerializer xmlSerializador = new XmlSerializer(objLibroGuia.Libro.GetType());
        string strArchivoTmp = Path.Combine(strRuta, strNombreArchivo);

        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        using (var stream = new StreamWriter(
          new FileStream(strArchivoTmp, FileMode.Create, FileAccess.Write), Encoding.GetEncoding("ISO-8859-1"))) {
            xmlSerializador.Serialize(stream, objLibroGuia.Libro, namespaces);
        }

        XmlDocument docXml = new XmlDocument();
        docXml.PreserveWhitespace = true;
        docXml.Load(strArchivoTmp);

        string strXML = docXml.OuterXml;
        strXML = strXML.Replace("iso-8859-1", "ISO-8859-1");

        docXml = new XmlDocument();
        docXml.PreserveWhitespace = true;
        docXml.LoadXml(strXML);

        XmlAttribute objElId = docXml.CreateAttribute("ID");
        objElId.Value = strID;
        docXml.DocumentElement.Attributes.Append(objElId);

        docXml.Save(strArchivoTmp);

        docXml = new XmlDocument();
        docXml.PreserveWhitespace = true;
        docXml.Load(strArchivoTmp);

        XmlDocument xmlSet = new XmlDocument();
        xmlSet.PreserveWhitespace = true;
        XmlDeclaration decla = xmlSet.CreateXmlDeclaration("1.0", "ISO-8859-1", "");
        xmlSet.InsertBefore(decla, xmlSet.DocumentElement);


        XmlNode nodo = xmlSet.CreateNode(XmlNodeType.Element, "LibroGuia", null);
        xmlSet.AppendChild(nodo);
        nodo = xmlSet.CreateNode(XmlNodeType.Element, "AA", null);
        xmlSet["LibroGuia"].AppendChild(nodo);


        xmlSet.DocumentElement.SetAttribute("xmlns", "http://www.sii.cl/SiiDte");
        xmlSet.DocumentElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
        xmlSet.DocumentElement.SetAttribute("xsi:schemaLocation", "http://www.sii.cl/SiiDte LibroGuia_v10.xsd");
        xmlSet.DocumentElement.SetAttribute("version", "1.0");

        strXML = xmlSet.OuterXml;
        strXML = strXML.Replace("<AA />", docXml.DocumentElement.OuterXml.Replace("EnvioLibroGuia", "EnvioLibro"));
        strXML = strXML.Replace("schemaLocation", "xsi:schemaLocation");
        strXML = Regex.Replace(strXML, @">(\s+)<|><", ">\r\n<");

        xmlSet = new XmlDocument();
        xmlSet.PreserveWhitespace = true;
        xmlSet.LoadXml(strXML);



        var certificado = objGeneral.ObtenerCertificado(objEmp.RutaCertificado, objEmp.ClaveCertificado);

        objGeneral.firmarDocumentoXml(ref xmlSet, certificado, "#" + strID);

        string strRutaFinalArchivo = Path.Combine(strRutaFinal, strNombreArchivo);
        xmlSet.Save(strRutaFinalArchivo);



        return new ResXML() { ArchivoFinal = strRutaFinalArchivo, ArchivoTemporal = strArchivoTmp };
      }
      catch (Exception ex) {
        return new ResXML(){ Error = new Error() { Mensaje = ex.Message, Numero = General.ERROR }};
      }
    }
    
    private string AgregarSaltoLineaFirma(string strCadena) {
      string strNueva = "";
      while (strCadena.Length > 76) {
        string strAux = strCadena.Substring(0, 76);
        strCadena = strCadena.Replace(strAux, "");
        strNueva += strAux + Environment.NewLine;
      }

      strNueva += strCadena;
      return strNueva;
    }

  }
}
