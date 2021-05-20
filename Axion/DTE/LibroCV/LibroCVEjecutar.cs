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

namespace DTE.LibroCV {


  public class LibroCVEjecutar {
     
    General objGeneral;

    public LibroCVEjecutar() {
      objGeneral = new General();
    }

    public ResXML GenerarXML(Empresa objEmpresa, ParamLibroCV objLibroCV, string strRutaTemporal, string strRutaFinal ) {
      //XmlAttribute att;
      Empresa objEmp = objEmpresa;
      string strRuta = strRutaTemporal;
      string strID = string.Format("E{0}T{1}F{2}", objLibroCV.Libro.Caratula.RutEmisorLibro.Replace("-", ""), objLibroCV.Libro.Caratula.TipoOperacion, objLibroCV.Libro.Caratula.PeriodoTributario.ToString("yyyyMM"));
      objLibroCV.Libro.Caratula.RutEnvia = objEmp.RutEnvia;
      string strNombreArchivo = string.Format("{0}.xml", strID);
      objLibroCV.Libro.TmstFirma = DateTime.Now;


      if (!Directory.Exists(strRutaFinal))
        Directory.CreateDirectory(strRutaFinal);

      try {

      //  //objDTE.DTE.Documento.Encabezado.RUTMandante = objDTE.DTE.Documento.Encabezado.Emisor.RUTEmisor;
      //  //objDTE.DTE.Documento.Encabezado.RUTSolicita = objDTE.DTE.Documento.Encabezado.Emisor.RUTEmisor;

        XmlSerializer xmlSerializador = new XmlSerializer(objLibroCV.Libro.GetType());
        string strArchivoTmp = Path.Combine(strRuta, strNombreArchivo);

        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        using (var stream = new StreamWriter(
          new FileStream(strArchivoTmp, FileMode.Create, FileAccess.Write), Encoding.GetEncoding("ISO-8859-1"))) {
            xmlSerializador.Serialize(stream, objLibroCV.Libro, namespaces);
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


        XmlNode nodo = xmlSet.CreateNode(XmlNodeType.Element, "LibroCompraVenta", null);
        xmlSet.AppendChild(nodo);
        nodo = xmlSet.CreateNode(XmlNodeType.Element, "AA", null);
        xmlSet["LibroCompraVenta"].AppendChild(nodo);


        xmlSet.DocumentElement.SetAttribute("xmlns", "http://www.sii.cl/SiiDte");
        xmlSet.DocumentElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
        xmlSet.DocumentElement.SetAttribute("xsi:schemaLocation", "http://www.sii.cl/SiiDte LibroCV_v10.xsd");
        xmlSet.DocumentElement.SetAttribute("version", "1.0");

        strXML = xmlSet.OuterXml;
        strXML = strXML.Replace("<AA />", docXml.DocumentElement.OuterXml);
        strXML = strXML.Replace("schemaLocation", "xsi:schemaLocation");
        strXML = Regex.Replace(strXML, @">(\s+)<|><", ">\r\n<");

        xmlSet = new XmlDocument();
        xmlSet.PreserveWhitespace = true;
        xmlSet.LoadXml(strXML);

        var certificado = objGeneral.ObtenerCertificado(objEmp.RutaCertificado, objEmp.ClaveCertificado);

        objGeneral.firmarDocumentoXml(ref xmlSet, certificado, "#" + strID);

      //  General.firmarDocumentoXml(ref xmlSet, certificado, "#SetDoc");
        string strRutaFinalArchivo = Path.Combine(strRutaFinal, strNombreArchivo);
        xmlSet.Save(strRutaFinalArchivo);



      //  #endregion

        return new ResXML() { ArchivoFinal = strRutaFinalArchivo, ArchivoTemporal = strArchivoTmp };
      }
      catch (Exception ex) {
        return new ResXML(){ Error = new Error() { Mensaje = ex.Message, Numero = General.ERROR }};
      }
    }

    private XmlDocument CrearLCE(Empresa objEmp, ParamLibroCV objLibroCV, string strId, string strArchivoTmp) {
      XmlDocument xmlLce = new XmlDocument();

      xmlLce.PreserveWhitespace = true;
      XmlDeclaration decla = xmlLce.CreateXmlDeclaration("1.0", "ISO-8859-1", "");
      xmlLce.InsertBefore(decla, xmlLce.DocumentElement);

      XmlNode nodo = xmlLce.CreateNode(XmlNodeType.Element, "DocumentoCal", null);
      xmlLce.AppendChild(nodo);

      strId = strId + "LCE";
      string strArchivo = strArchivoTmp;

      XmlAttribute objElId = xmlLce.CreateAttribute("ID");
      objElId.Value = strId;
      xmlLce["DocumentoCal"].Attributes.Append(objElId);


      nodo = xmlLce.CreateNode(XmlNodeType.Element, "RutDistribuidor", null);
      nodo.InnerText = objLibroCV.Libro.Caratula.RutEmisorLibro;
      xmlLce.DocumentElement.AppendChild(nodo);

      nodo = xmlLce.CreateNode(XmlNodeType.Element, "TipoCertificado", null);
      nodo.InnerText = "C";
      xmlLce.DocumentElement.AppendChild(nodo);

      nodo = xmlLce.CreateNode(XmlNodeType.Element, "Clase", null);
      nodo.InnerText = "3";
      xmlLce.DocumentElement.AppendChild(nodo);

      nodo = xmlLce.CreateNode(XmlNodeType.Element, "TipoLCE", null);
      nodo.InnerText = "6";
      xmlLce.DocumentElement.AppendChild(nodo);

      nodo = xmlLce.CreateNode(XmlNodeType.Element, "FchEmision", null);
      nodo.InnerText = DateTime.Now.ToString("yyyy-MM-dd");
      xmlLce.DocumentElement.AppendChild(nodo);

      nodo = xmlLce.CreateNode(XmlNodeType.Element, "PeriodoVigencia", null);
      nodo.InnerText = DateTime.Now.Year.ToString();
      xmlLce.DocumentElement.AppendChild(nodo);

      nodo = xmlLce.CreateNode(XmlNodeType.Element, "RutDistribuidor", null);
      nodo.InnerText = objLibroCV.Libro.Caratula.RutEmisorLibro;
      xmlLce.DocumentElement.AppendChild(nodo);

      nodo = xmlLce.CreateNode(XmlNodeType.Element, "TmstFirma", null);
      nodo.InnerText = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
      xmlLce.DocumentElement.AppendChild(nodo);

      xmlLce.Save(strArchivo);

      xmlLce = new XmlDocument();
      xmlLce.PreserveWhitespace = true;
      xmlLce.Load(strArchivo);

      string strXML = xmlLce.OuterXml;
      strXML = Regex.Replace(strXML, @">(\s+)<|><", ">\r\n<");
      strXML = strXML.Replace("iso-8859-1", "ISO-8859-1");

      xmlLce = new XmlDocument();
      xmlLce.PreserveWhitespace = true;
      xmlLce.LoadXml(strXML);

      var certificado = objGeneral.ObtenerCertificado(objEmp.RutaCertificado, objEmp.ClaveCertificado);

      objGeneral.firmarDocumentoXml(ref xmlLce, certificado, "#" + strId);

      File.Delete(strArchivo);

      return xmlLce;

    }

  }
}
