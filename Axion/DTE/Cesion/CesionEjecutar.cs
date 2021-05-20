using Comun;
using DTE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using static Comun.General;

namespace Cesion {
  public class CesionEjecutar {

    General objGeneral;

    public CesionEjecutar() {
      objGeneral = new General();
    }

    public ResXMLCesion GenerarXML(Empresa objEmpresa, ParamCesion ParamCes, string strRutaTemporal, string strRutaFinal) {
      try {
        string strID = string.Format("E{1}T{0}F{2}-{3}", ParamCes.Cesion.DocumentoCesion.IdDTE.TipoDTE, ParamCes.Cesion.DocumentoCesion.IdDTE.RUTEmisor.Replace("-", ""), ParamCes.Cesion.DocumentoCesion.IdDTE.Folio, ParamCes.Cesion.DocumentoCesion.SeqCesion);

        if (!Directory.Exists(strRutaFinal))
          Directory.CreateDirectory(strRutaFinal);

        
        var res = GenerarXMLPuroDocumentoCesion(ParamCes.Cesion, strRutaTemporal);
        string strNombreArchivo = string.Format("{0}.xml", strID);


        if (res.Error != null && !string.IsNullOrEmpty(res.Error.Mensaje))
          return new ResXMLCesion() { Error = res.Error };

        var docXml = new XmlDocument();
        docXml.PreserveWhitespace = true;
        docXml.Load(res.Resultado);

        string strArchivoTmp = FirmarDoc(objEmpresa, docXml, strID, res.Resultado);

        //strArchivoTmp = GenerarDocumentoAEC(objEmpresa, xml, objDTE, strArchivoTmp);


        if (ParamCes.DTECedido == null) {
          ParamCes.DTECedido = new DTECedido();
          ParamCes.DTECedido.DocumentoDTECedido = new DocumentoDTECedido();
          ParamCes.DTECedido.DocumentoDTECedido.DTE = "";
        }

        string strIdCed = string.Format("Ced{0}", strID);
        var resCed = GenerarXMLPuroDTECedido(ParamCes.DTECedido, ParamCes.XMLDTE, strRutaTemporal, strIdCed);


        if (resCed.Error != null && !string.IsNullOrEmpty(resCed.Error.Mensaje))
          return new ResXMLCesion() { Error = resCed.Error };

        var docXmlCed = new XmlDocument();
        docXmlCed.PreserveWhitespace = true;
        docXmlCed.Load(resCed.Resultado);

        strArchivoTmp = FirmarDoc(objEmpresa, docXmlCed, strIdCed, resCed.Resultado);

        //strArchivoTmp = GenerarDocumentoAEC(objEmpresa, xml, objDTE, strArchivoTmp);

        var xmlSetCed = new XmlDocument();
        xmlSetCed.PreserveWhitespace = true;
        xmlSetCed.Load(strArchivoTmp);

        
        strArchivoTmp = GenerarDocumentoAEC(objEmpresa, ParamCes,  docXml, docXmlCed, strArchivoTmp);

        var xmlSet = new XmlDocument();
        xmlSet.PreserveWhitespace = true;
        xmlSet.Load(strArchivoTmp);

        string strRutaFinalArchivo = Path.Combine(strRutaFinal, strNombreArchivo);
        strRutaFinalArchivo = FirmarDoc(objEmpresa, xmlSet, "Doc1", strRutaFinalArchivo);


        return new ResXMLCesion() { ArchivoFinal = strRutaFinalArchivo, ArchivoTemporal = strArchivoTmp };

      } catch (Exception ex) {

        return new ResXMLCesion() { Error = new Error() { Mensaje = ex.Message, Numero = General.ERROR } };
      }
      //return new ResXMLCesion();
    }


    public string FirmarDoc(Empresa objEmpresa, XmlDocument doc, string strID, string strRutaTemporal) {
      var certificado = objGeneral.ObtenerCertificado(objEmpresa.RutaCertificado, objEmpresa.ClaveCertificado);

      objGeneral.firmarDocumentoXml(ref doc, certificado, "#" + strID);

      doc.Save(strRutaTemporal);

      return strRutaTemporal;

    }

    public ResString GenerarXMLPuroDocumentoCesion(Cesion objDTE, string strRutaTemporal, string strFormatoNombre = "") {
      XmlAttribute att;
      string strRuta = strRutaTemporal;

      if (string.IsNullOrWhiteSpace(strFormatoNombre))
        strFormatoNombre = "E{1}T{0}F{2}-{3}";
      
      string strID = string.Format(strFormatoNombre, objDTE.DocumentoCesion.IdDTE.TipoDTE, objDTE.DocumentoCesion.IdDTE.RUTEmisor.Replace("-", ""), objDTE.DocumentoCesion.IdDTE.Folio, objDTE.DocumentoCesion.SeqCesion);
      
      string strNombreArchivo = string.Format("{0}.xml", strID);
      
      try {
        //objDTE.DTE.Documento.Encabezado.RUTMandante = objDTE.DTE.Documento.Encabezado.Emisor.RUTEmisor;
        //objDTE.DTE.Documento.Encabezado.RUTSolicita = objDTE.DTE.Documento.Encabezado.Emisor.RUTEmisor;

        XmlSerializer xmlSerializador = new XmlSerializer(objDTE.GetType());
        string strArchivoTmp = Path.Combine(strRuta, strNombreArchivo);

        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        using (var stream = new StreamWriter(
          new FileStream(strArchivoTmp, FileMode.Create, FileAccess.Write), Encoding.GetEncoding("ISO-8859-1"))) {
          xmlSerializador.Serialize(stream, objDTE, namespaces);
        }

        XmlDocument docXml = new XmlDocument();
        docXml.PreserveWhitespace = true;
        docXml.Load(strArchivoTmp);

        XmlAttribute objElId = docXml.CreateAttribute("ID");
        objElId.Value = strID;
        docXml["Cesion"]["DocumentoCesion"].Attributes.Append(objElId);


        var nodo = docXml.CreateNode(XmlNodeType.Element, "TmstCesion", null);
        docXml["Cesion"]["DocumentoCesion"].AppendChild(nodo);

        docXml["Cesion"]["DocumentoCesion"]["TmstCesion"].InnerText = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");


        if (docXml["Cesion"].Attributes.Count == 0) {
          var a = docXml.CreateAttribute("version");
          a.Value = "1.0";
          docXml["Cesion"].Attributes.Append(a);
        }

        docXml.Save(strArchivoTmp);
        
        return new ResString() { Resultado = strArchivoTmp };
      } catch (Exception ex) {
        return new ResString() { Error = new Error() { Mensaje = ex.Message, Numero = General.ERROR } };
      }

    }

    public ResString GenerarXMLPuroDTECedido(DTECedido objDTE, string strXMLDTE, string strRutaTemporal, string strId) {
      XmlAttribute att;
      string strRuta = strRutaTemporal;
      
      string strID = strId;

      string strNombreArchivo = string.Format("{0}.xml", strID);
      
      try {
        //objDTE.DTE.Documento.Encabezado.RUTMandante = objDTE.DTE.Documento.Encabezado.Emisor.RUTEmisor;
        //objDTE.DTE.Documento.Encabezado.RUTSolicita = objDTE.DTE.Documento.Encabezado.Emisor.RUTEmisor;

        XmlSerializer xmlSerializador = new XmlSerializer(objDTE.GetType());
        string strArchivoTmp = Path.Combine(strRuta, strNombreArchivo);

        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        using (var stream = new StreamWriter(
          new FileStream(strArchivoTmp, FileMode.Create, FileAccess.Write), Encoding.GetEncoding("ISO-8859-1"))) {
          xmlSerializador.Serialize(stream, objDTE, namespaces);
        }

        XmlDocument docXml = new XmlDocument();
        docXml.PreserveWhitespace = true;
        docXml.Load(strArchivoTmp);

        XmlAttribute objElId = docXml.CreateAttribute("ID");
        objElId.Value = strID;
        docXml["DTECedido"]["DocumentoDTECedido"].Attributes.Append(objElId);

        
        if (docXml["DTECedido"].Attributes.Count == 0) {
          var a = docXml.CreateAttribute("version");
          a.Value = "1.0";
          docXml["DTECedido"].Attributes.Append(a);
        }


        var nodo = docXml.CreateNode(XmlNodeType.Element, "TmstFirma", null);
        docXml["DTECedido"]["DocumentoDTECedido"].AppendChild(nodo);

        docXml["DTECedido"]["DocumentoDTECedido"]["TmstFirma"].InnerText = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");


        docXml.Save(strArchivoTmp);



        docXml = new XmlDocument();
        docXml.PreserveWhitespace = true;
        docXml.Load(strArchivoTmp);



        StringBuilder strXML = new StringBuilder( docXml.OuterXml);
        strXML.Replace("<DTE />", strXMLDTE).AppendLine();
        //strXML.Replace("<TmstFirma />", "<TmstFirma>" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "</TmstFirma>");
        //strXML.Replace("<TmstCesion />", "<TmstCesion>" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "</TmstCesion>");


        docXml = new XmlDocument();
        docXml.PreserveWhitespace = true;
        docXml.LoadXml(strXML.ToString());
        docXml.Save(strArchivoTmp);

        return new ResString() { Resultado = strArchivoTmp };
      } catch (Exception ex) {
        return new ResString() { Error = new Error() { Mensaje = ex.Message, Numero = General.ERROR } };
      }

    }


    public string GenerarDocumentoAEC(Empresa objEmpresa, ParamCesion objDTE, XmlDocument xmlCesion, XmlDocument xmlCedido, string strRutaTemporal) {
      XmlNode nodo;
      XmlAttribute att;
      XmlDocument xmlSet = new XmlDocument();
      xmlSet.PreserveWhitespace = true;
      XmlDeclaration decla = xmlSet.CreateXmlDeclaration("1.0", "ISO-8859-1", "");
      xmlSet.InsertBefore(decla, xmlSet.DocumentElement);

      nodo = xmlSet.CreateNode(XmlNodeType.Element, "AEC", null);
      xmlSet.AppendChild(nodo);
      nodo = xmlSet.CreateNode(XmlNodeType.Element, "DocumentoAEC", null);
      att = xmlSet.CreateAttribute("ID");
      att.InnerText = "Doc1";
      nodo.Attributes.Append(att);
      xmlSet["AEC"].AppendChild(nodo);
      nodo = xmlSet.CreateNode(XmlNodeType.Element, "Caratula", null);
      att = xmlSet.CreateAttribute("version");
      att.InnerText = "1.0";
      nodo.Attributes.Append(att);
      xmlSet["AEC"]["DocumentoAEC"].AppendChild(nodo);

      nodo = xmlSet.CreateNode(XmlNodeType.Element, "Cesiones", null);
      xmlSet["AEC"]["DocumentoAEC"].AppendChild(nodo);

      nodo = xmlSet.CreateNode(XmlNodeType.Element, "RutCedente", null);
      xmlSet["AEC"]["DocumentoAEC"]["Caratula"].AppendChild(nodo);
      nodo = xmlSet.CreateNode(XmlNodeType.Element, "RutCesionario", null);
      xmlSet["AEC"]["DocumentoAEC"]["Caratula"].AppendChild(nodo);
      nodo = xmlSet.CreateNode(XmlNodeType.Element, "NmbContacto", null);
      xmlSet["AEC"]["DocumentoAEC"]["Caratula"].AppendChild(nodo);
      nodo = xmlSet.CreateNode(XmlNodeType.Element, "FonoContacto", null);
      xmlSet["AEC"]["DocumentoAEC"]["Caratula"].AppendChild(nodo);
      nodo = xmlSet.CreateNode(XmlNodeType.Element, "MailContacto", null);
      xmlSet["AEC"]["DocumentoAEC"]["Caratula"].AppendChild(nodo);
      nodo = xmlSet.CreateNode(XmlNodeType.Element, "TmstFirmaEnvio", null);
      xmlSet["AEC"]["DocumentoAEC"]["Caratula"].AppendChild(nodo);

      xmlSet.Save(strRutaTemporal);

      xmlSet = new XmlDocument();
      xmlSet.PreserveWhitespace = true;
      xmlSet.Load(strRutaTemporal);

      xmlSet["AEC"]["DocumentoAEC"]["Caratula"]["RutCedente"].InnerText = objDTE.Cesion.DocumentoCesion.Cedente.RUT;//  objEmpresa.RutEnvia; 
      xmlSet["AEC"]["DocumentoAEC"]["Caratula"]["RutCesionario"].InnerText = objDTE.Cesion.DocumentoCesion.Cesionario.RUT;
      xmlSet["AEC"]["DocumentoAEC"]["Caratula"]["NmbContacto"].InnerText = objDTE.NmbContacto;
      xmlSet["AEC"]["DocumentoAEC"]["Caratula"]["FonoContacto"].InnerText = objDTE.FonoContacto;
      xmlSet["AEC"]["DocumentoAEC"]["Caratula"]["MailContacto"].InnerText = objDTE.MailContacto;
      xmlSet["AEC"]["DocumentoAEC"]["Caratula"]["TmstFirmaEnvio"].InnerText = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

      //var grupo = from x in docs group x by x.Key into a select new { TipoDoc = a.Key, Cantidad = a.Count() };
      

      xmlSet.DocumentElement.SetAttribute("xmlns", "http://www.sii.cl/SiiDte");
      xmlSet.DocumentElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
      xmlSet.DocumentElement.SetAttribute("xsi:schemaLocation", "http://www.sii.cl/SiiDte AEC_v10.xsd");
      xmlSet.DocumentElement.SetAttribute("version", "1.0");
      
      StringBuilder strDTEs = new StringBuilder();
      strDTEs.AppendLine("<Cesiones>");
      strDTEs.AppendLine(xmlCedido.OuterXml.Replace("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>", "").Replace("<?xml version='1.0' encoding='ISO-8859-1'?>", "").Trim());
      strDTEs.AppendLine(xmlCesion.OuterXml.Replace("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>", "").Replace("<?xml version='1.0' encoding='ISO-8859-1'?>", "").Trim());
      strDTEs.AppendLine("</Cesiones>");


      strDTEs.Replace("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>", "");
      strDTEs.Replace("<?xml version='1.0' encoding='ISO-8859-1'?>", "");

      string strXml = xmlSet.OuterXml;
      strXml = Regex.Replace(strXml, @">(\s+)<|><", ">\r\n<");
      strXml = strXml.Replace("<Cesiones />", strDTEs.ToString());
      strXml = strXml.Replace("schemaLocation", "xsi:schemaLocation");

      xmlSet = new XmlDocument();
      xmlSet.PreserveWhitespace = true;
      xmlSet.LoadXml(strXml);
      xmlSet.Save(strRutaTemporal);

      return strRutaTemporal;
    }


  }
}
