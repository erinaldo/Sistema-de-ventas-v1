using Comun;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static Comun.General;

namespace DTE {
  public  class DTEEjecutar {

    General objGeneral;

    public DTEEjecutar() {
      objGeneral = new General();
    }

    public  ResXML GenerarXML(Empresa objEmpresa, ParamDTE objDTE, string strRutaTemporal, string strRutaFinal, byte[] bytCAF, string strTED) {
      try {
        string strID = string.Format("E{1}T{0}F{2}", (int)objDTE.DTE.Documento.Encabezado.IdDoc.TipoDTE, objDTE.DTE.Documento.Encabezado.Emisor.RUTEmisor.Replace("-", ""), objDTE.DTE.Documento.Encabezado.IdDoc.Folio);

        if (!Directory.Exists(strRutaFinal))
          Directory.CreateDirectory(strRutaFinal);

        var res = GenerarXMLPuro(objDTE, strRutaTemporal, bytCAF, strTED);
        string strNombreArchivo = string.Format("{0}.xml", strID);


        if (res.Error != null && !string.IsNullOrEmpty(res.Error.Mensaje))
          return new ResXML() { Error = res.Error };

        var docXml = new XmlDocument();
        docXml.PreserveWhitespace = true;
        docXml.Load(res.Resultado);

        string strArchivoTmp = FirmarDoc(objEmpresa, docXml, strID, res.Resultado);

        Dictionary<int, List<XmlDocument>> xml = new Dictionary<int, List<XmlDocument>>();
        xml.Add((int)objDTE.DTE.Documento.Encabezado.IdDoc.TipoDTE, new List<XmlDocument>());
        xml[(int)objDTE.DTE.Documento.Encabezado.IdDoc.TipoDTE].Add(docXml);

        strArchivoTmp = GenerarSetDTE(objEmpresa, xml, objDTE, strArchivoTmp);

        var xmlSet = new XmlDocument();
        xmlSet.PreserveWhitespace = true;
        xmlSet.Load(strArchivoTmp);

        string strRutaFinalArchivo = Path.Combine(strRutaFinal, strNombreArchivo);
        strRutaFinalArchivo = FirmarDoc(objEmpresa, xmlSet, "SetDoc", strRutaFinalArchivo);

        var nodoTED = docXml.GetElementsByTagName("TED");

        if (nodoTED != null && nodoTED.Count > 0)
          strTED = nodoTED[0].OuterXml;

        return new ResXML() { ArchivoFinal = strRutaFinalArchivo, ArchivoTemporal = strArchivoTmp, DatosPDF417 = objGeneral.LimpiarDD(strTED) };

      } catch (Exception ex) {
        
        return new ResXML() { Error = new Error() { Mensaje = ex.Message, Numero = General.ERROR } };
      }
    }

    public ResString GenerarXMLPuro(ParamDTE objDTE, string strRutaTemporal, byte[] bytCAF, string strTED, string strFormatoNombre = "") {
      XmlAttribute att;
      string strRuta = strRutaTemporal;

      if (string.IsNullOrWhiteSpace(strFormatoNombre))
        strFormatoNombre = "E{1}T{0}F{2}";

      string strID = "";

      
        strID = string.Format(strFormatoNombre, (int)objDTE.DTE.Documento.Encabezado.IdDoc.TipoDTE, objDTE.DTE.Documento.Encabezado.Emisor.RUTEmisor.Replace("-", ""), objDTE.DTE.Documento.Encabezado.IdDoc.Folio);


      string strTipo = "Documento";
      
      string strNombreArchivo = string.Format("{0}.xml", strID);
     
        objDTE.DTE.Documento.TmstFirma = DateTime.Now;
  

      try {
        //objDTE.DTE.Documento.Encabezado.RUTMandante = objDTE.DTE.Documento.Encabezado.Emisor.RUTEmisor;
        //objDTE.DTE.Documento.Encabezado.RUTSolicita = objDTE.DTE.Documento.Encabezado.Emisor.RUTEmisor;

        XmlSerializer xmlSerializador = new XmlSerializer(objDTE.DTE.GetType());
        string strArchivoTmp = Path.Combine(strRuta, strNombreArchivo);

        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        using (var stream = new StreamWriter(
          new FileStream(strArchivoTmp, FileMode.Create, FileAccess.Write), Encoding.GetEncoding("ISO-8859-1"))) {
          xmlSerializador.Serialize(stream, objDTE.DTE, namespaces);
        }

        XmlDocument docXml = new XmlDocument();
        docXml.PreserveWhitespace = true;
        docXml.Load(strArchivoTmp);

        XmlAttribute objElId = docXml.CreateAttribute("ID");
        objElId.Value = strID;
        docXml["DTE"][strTipo].Attributes.Append(objElId);

        if (docXml["DTE"].Attributes.Count == 0) { 
          var a = docXml.CreateAttribute("version");
          a.Value = "1.0";
          docXml["DTE"].Attributes.Append(a);
        }


        //Aca se crea el nodo TED

        if (!string.IsNullOrEmpty(strTED)) {

          XmlNode nodo = docXml.CreateNode(XmlNodeType.Element, "TED", null);
          docXml["DTE"][strTipo].InsertBefore(nodo, docXml.GetElementsByTagName("TmstFirma")[0]);
          strTED = strTED.Replace("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>", "");
          strTED = strTED.Replace("<?xml version='1.0' encoding='ISO-8859-1'?>", "");
          string strDoc = docXml.OuterXml.Replace("<TED />", strTED);

          docXml = new XmlDocument();
          docXml.PreserveWhitespace = true;
          docXml.LoadXml(strDoc);

          docXml.Save(strArchivoTmp);

        }
        else {

          #region Agregamos el nodo TED
    

          XmlNode nodo = docXml.CreateNode(XmlNodeType.Element, "TED", null);
          att = docXml.CreateAttribute("version");
          att.Value = "1.0";
          nodo.Attributes.Append(att);
          docXml["DTE"][strTipo].InsertBefore(nodo, docXml.GetElementsByTagName("TmstFirma")[0]);

          nodo = docXml.CreateNode(XmlNodeType.Element, "DD", null);
          docXml["DTE"][strTipo]["TED"].AppendChild(nodo);

          nodo = docXml.CreateNode(XmlNodeType.Element, "RE", null);
          docXml["DTE"][strTipo]["TED"]["DD"].AppendChild(nodo);

          nodo = docXml.CreateNode(XmlNodeType.Element, "TD", null);
          docXml["DTE"][strTipo]["TED"]["DD"].AppendChild(nodo);

          nodo = docXml.CreateNode(XmlNodeType.Element, "F", null);
          docXml["DTE"][strTipo]["TED"]["DD"].AppendChild(nodo);

          nodo = docXml.CreateNode(XmlNodeType.Element, "FE", null);
          docXml["DTE"][strTipo]["TED"]["DD"].AppendChild(nodo);

          nodo = docXml.CreateNode(XmlNodeType.Element, "RR", null);
          docXml["DTE"][strTipo]["TED"]["DD"].AppendChild(nodo);

          nodo = docXml.CreateNode(XmlNodeType.Element, "RSR", null);
          docXml["DTE"][strTipo]["TED"]["DD"].AppendChild(nodo);

          nodo = docXml.CreateNode(XmlNodeType.Element, "MNT", null);
          docXml["DTE"][strTipo]["TED"]["DD"].AppendChild(nodo);

          nodo = docXml.CreateNode(XmlNodeType.Element, "IT1", null);
          docXml["DTE"][strTipo]["TED"]["DD"].AppendChild(nodo);

          nodo = docXml.CreateNode(XmlNodeType.Element, "CAF", null);
          docXml["DTE"][strTipo]["TED"]["DD"].AppendChild(nodo);

          nodo = docXml.CreateNode(XmlNodeType.Element, "TSTED", null);
          docXml["DTE"][strTipo]["TED"]["DD"].AppendChild(nodo);

          docXml.Save(strArchivoTmp);

          //Se termina de agregar los nodos, ahora a llenarlos

          docXml = new XmlDocument();
          docXml.PreserveWhitespace = true;
          docXml.Load(strArchivoTmp);

          docXml["DTE"][strTipo]["TED"]["DD"]["RE"].InnerText = objDTE.DTE.Documento.Encabezado.Emisor.RUTEmisor;
          docXml["DTE"][strTipo]["TED"]["DD"]["TD"].InnerText = ((int)objDTE.DTE.Documento.Encabezado.IdDoc.TipoDTE).ToString();
          docXml["DTE"][strTipo]["TED"]["DD"]["F"].InnerText =objDTE.DTE.Documento.Encabezado.IdDoc.Folio.ToString();
          docXml["DTE"][strTipo]["TED"]["DD"]["FE"].InnerText =objDTE.DTE.Documento.Encabezado.IdDoc.FchEmis.ToString("yyyy-MM-dd");
          docXml["DTE"][strTipo]["TED"]["DD"]["RR"].InnerText = objDTE.DTE.Documento.Encabezado.Receptor.RUTRecep;
          docXml["DTE"][strTipo]["TED"]["DD"]["MNT"].InnerText =  objDTE.DTE.Documento.Encabezado.Totales.MntTotal.ToString();

          string strTSTED = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

          //if (strTEDAux != null) {
          //  XmlDocument a = new XmlDocument();
          //  a.PreserveWhitespace = true;
          //  a.LoadXml(strTEDAux);

          //  strTSTED = a.GetElementsByTagName("TSTED")[0].InnerText;
          //}

          docXml["DTE"][strTipo]["TED"]["DD"]["TSTED"].InnerText = strTSTED;

          string strRSR =  objDTE.DTE.Documento.Encabezado.Receptor.RznSocRecep;

          if (strRSR.Length > 40)
            strRSR = strRSR.Substring(0, 40);

          docXml["DTE"][strTipo]["TED"]["DD"]["RSR"].InnerText = strRSR;

          if (objDTE.DTE.Documento.Detalle != null && objDTE.DTE.Documento.Detalle.Count > 0) {
            string strIT1 = objDTE.DTE.Documento.Detalle[0].NmbItem;
            if (strIT1.Length > 40)
              strIT1 = strIT1.Substring(0, 39);
            docXml["DTE"][strTipo]["TED"]["DD"]["IT1"].InnerText = strIT1;
          }

          string xml = Encoding.GetEncoding("ISO-8859-1").GetString(bytCAF);

          string strXml = docXml.OuterXml.Replace("iso-8859-1", "ISO-8859-1");
          strXml = Regex.Replace(strXml, @">(\s+)<|><", ">\r\n<");


          int intInicio = xml.IndexOf("<CAF");
          string strDACAF = xml.Substring(intInicio, xml.IndexOf("</CAF>") - intInicio + 6);

          strXml = strXml.Replace("<CAF />", strDACAF);

          docXml.LoadXml(strXml);
          docXml.Save(strArchivoTmp);
          #endregion

          #region Timbre Electronico


          docXml = new XmlDocument();
          docXml.PreserveWhitespace = true;
          docXml.Load(strArchivoTmp);


          intInicio = xml.IndexOf("<RSASK>");
          string strRSASK = xml.Substring(intInicio, xml.IndexOf("</RSASK>") - intInicio + 8);
          string strTimbre = objGeneral.RetornarFirma(docXml.GetElementsByTagName("DD")[0].OuterXml, strRSASK.Replace("<RSASK>", "").Replace("</RSASK>", ""));


          nodo = docXml.CreateNode(XmlNodeType.Element, "FRMT", null);
          att = docXml.CreateAttribute("algoritmo");
          att.Value = "SHA1withRSA";
          nodo.Attributes.Append(att);
          nodo.InnerText = strTimbre;
          docXml["DTE"][strTipo]["TED"].AppendChild(nodo);

          att = docXml.CreateAttribute("version");
          att.Value = "1.0";
          docXml["DTE"].Attributes.Append(att);

          docXml.Save(strArchivoTmp);

          #endregion


        }
          return new ResString() { Resultado = strArchivoTmp };
      }
      catch (Exception ex) {
        return new ResString() { Error = new Error() { Mensaje = ex.Message, Numero = General.ERROR } };
      }

    }

    public string FirmarDoc(Empresa objEmpresa, XmlDocument doc, string strID, string strRutaTemporal) {


      X509Certificate2 certificado;

      if (objEmpresa.Certificado == null)
        certificado = objGeneral.ObtenerCertificado(objEmpresa.RutaCertificado, objEmpresa.ClaveCertificado);
      else
        certificado = objGeneral.ObtenerCertificado(objEmpresa.Certificado, objEmpresa.ClaveCertificado);

      objGeneral.firmarDocumentoXml(ref doc, certificado, "#" + strID);

      doc.Save(strRutaTemporal);

      return strRutaTemporal;

    }

    public string GenerarSetDTE(Empresa objEmpresa, Dictionary<int,List<XmlDocument>> docs, ParamDTE objDTE, string strRutaTemporal, string strRutAEnviar = "") {
      XmlNode nodo;
      XmlAttribute att;
      XmlDocument xmlSet = new XmlDocument();
      xmlSet.PreserveWhitespace = true;
      XmlDeclaration decla = xmlSet.CreateXmlDeclaration("1.0", "ISO-8859-1", "");
      xmlSet.InsertBefore(decla, xmlSet.DocumentElement);

      nodo = xmlSet.CreateNode(XmlNodeType.Element, "EnvioDTE", null);
      xmlSet.AppendChild(nodo);
      nodo = xmlSet.CreateNode(XmlNodeType.Element, "SetDTE", null);
      att = xmlSet.CreateAttribute("ID");
      att.InnerText = "SetDoc";
      nodo.Attributes.Append(att);
      xmlSet["EnvioDTE"].AppendChild(nodo);
      nodo = xmlSet.CreateNode(XmlNodeType.Element, "Caratula", null);
      att = xmlSet.CreateAttribute("version");
      att.InnerText = "1.0";
      nodo.Attributes.Append(att);
      xmlSet["EnvioDTE"]["SetDTE"].AppendChild(nodo);

      nodo = xmlSet.CreateNode(XmlNodeType.Element, "DTE", null);
      xmlSet["EnvioDTE"]["SetDTE"].AppendChild(nodo);

      nodo = xmlSet.CreateNode(XmlNodeType.Element, "RutEmisor", null);
      xmlSet["EnvioDTE"]["SetDTE"]["Caratula"].AppendChild(nodo);
      nodo = xmlSet.CreateNode(XmlNodeType.Element, "RutEnvia", null);
      xmlSet["EnvioDTE"]["SetDTE"]["Caratula"].AppendChild(nodo);
      nodo = xmlSet.CreateNode(XmlNodeType.Element, "RutReceptor", null);
      xmlSet["EnvioDTE"]["SetDTE"]["Caratula"].AppendChild(nodo);
      nodo = xmlSet.CreateNode(XmlNodeType.Element, "FchResol", null);
      xmlSet["EnvioDTE"]["SetDTE"]["Caratula"].AppendChild(nodo);
      nodo = xmlSet.CreateNode(XmlNodeType.Element, "NroResol", null);
      xmlSet["EnvioDTE"]["SetDTE"]["Caratula"].AppendChild(nodo);
      nodo = xmlSet.CreateNode(XmlNodeType.Element, "TmstFirmaEnv", null);
      xmlSet["EnvioDTE"]["SetDTE"]["Caratula"].AppendChild(nodo);

      xmlSet.Save(strRutaTemporal);

      xmlSet = new XmlDocument();
      xmlSet.PreserveWhitespace = true;
      xmlSet.Load(strRutaTemporal);

      xmlSet["EnvioDTE"]["SetDTE"]["Caratula"]["RutEmisor"].InnerText = objDTE.DTE.Documento.Encabezado.Emisor.RUTEmisor;
      xmlSet["EnvioDTE"]["SetDTE"]["Caratula"]["RutEnvia"].InnerText = objEmpresa.RutEnvia;
      xmlSet["EnvioDTE"]["SetDTE"]["Caratula"]["RutReceptor"].InnerText = string.IsNullOrWhiteSpace(strRutAEnviar) ? "60803000-K" : objDTE.DTE.Documento.Encabezado.Receptor.RUTRecep;
      xmlSet["EnvioDTE"]["SetDTE"]["Caratula"]["FchResol"].InnerText = objDTE.FechaResolucion.ToString("yyyy-MM-dd");
      xmlSet["EnvioDTE"]["SetDTE"]["Caratula"]["NroResol"].InnerText = objDTE.NroResolucion.ToString();
      xmlSet["EnvioDTE"]["SetDTE"]["Caratula"]["TmstFirmaEnv"].InnerText = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

      //var grupo = from x in docs group x by x.Key into a select new { TipoDoc = a.Key, Cantidad = a.Count() };

      foreach (var item in docs) {

        var nodoSub = xmlSet.CreateNode(XmlNodeType.Element, "SubTotDTE", null);
        nodo = xmlSet.CreateNode(XmlNodeType.Element, "TpoDTE", null);
        nodo.InnerText = item.Key.ToString();
        nodoSub.AppendChild(nodo);
        nodo = xmlSet.CreateNode(XmlNodeType.Element, "NroDTE", null);
        nodo.InnerText = item.Value.Count.ToString();
        nodoSub.AppendChild(nodo);

        xmlSet["EnvioDTE"]["SetDTE"]["Caratula"].AppendChild(nodoSub);  
      }


      xmlSet.DocumentElement.SetAttribute("version", "1.0");
      xmlSet.DocumentElement.SetAttribute("xmlns", "http://www.sii.cl/SiiDte");
      xmlSet.DocumentElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
      xmlSet.DocumentElement.SetAttribute("xsi:schemaLocation", "http://www.sii.cl/SiiDte EnvioDTE_v10.xsd");


      StringBuilder strDTEs = new StringBuilder();

      foreach (var item in docs) {
        foreach (var otro in item.Value) {
          strDTEs.AppendLine(otro.OuterXml.Replace("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>", "").Replace("<?xml version='1.0' encoding='ISO-8859-1'?>", ""));
        }
      }

      strDTEs.Replace("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>", "");
      strDTEs.Replace("<?xml version='1.0' encoding='ISO-8859-1'?>", "");

      string strXml = xmlSet.OuterXml;
      strXml = Regex.Replace(strXml, @">(\s+)<|><", ">\r\n<");
      strXml = strXml.Replace("<DTE />", strDTEs.ToString());
      strXml = strXml.Replace("schemaLocation", "xsi:schemaLocation");

      xmlSet = new XmlDocument();
      xmlSet.PreserveWhitespace = true;
      xmlSet.LoadXml(strXml);
      xmlSet.Save(strRutaTemporal);

      return strRutaTemporal;
    }

    public byte[] BajarPDF(DTE objDTE, bool bolCedible, string strNroResolucion, DateTime dtFechaResolucion, string strRutaPDF417) {
      ReportViewer rpt = null;
      try {
        rpt = new ReportViewer();
        rpt.ProcessingMode = ProcessingMode.Local;
        rpt.PageCountMode = PageCountMode.Actual;
        rpt.ShowParameterPrompts = false;
        rpt.ShowCredentialPrompts = false;
      var objEnsamblado = Assembly.Load( "ComunFE");

      rpt.LocalReport.ReportPath = string.Empty;
      rpt.LocalReport.ReportEmbeddedResource = string.Empty;
      rpt.LocalReport.EnableExternalImages = true;
      string strReporte = string.Format("ComunFE.Reporte.{0}{1}.rdlc", objDTE.Documento.Encabezado.IdDoc.TipoDTE, bolCedible ? "Cedible" : "");
      rpt.LocalReport.LoadReportDefinition(objEnsamblado.GetManifestResourceStream(strReporte));
        
      rpt.LocalReport.DataSources.Add(new ReportDataSource("Emisor", ObjectToData(objDTE.Documento.Encabezado.Emisor)));
      rpt.LocalReport.DataSources.Add(new ReportDataSource("Receptor", ObjectToData(objDTE.Documento.Encabezado.Receptor)));
      rpt.LocalReport.DataSources.Add(new ReportDataSource("Totales", ObjectToData(objDTE.Documento.Encabezado.Totales)));
      rpt.LocalReport.DataSources.Add(new ReportDataSource("Referencia", ObjectToData(objDTE.Documento.Referencia)));
      rpt.LocalReport.DataSources.Add(new ReportDataSource("IdDoc", ObjectToData(objDTE.Documento.Encabezado.IdDoc)));
      rpt.LocalReport.DataSources.Add(new ReportDataSource("Detalle", ObjectToData(objDTE.Documento.Detalle)));
      rpt.LocalReport.DataSources.Add(new ReportDataSource("DsctRecargo", ObjectToData(objDTE.Documento.DscRcgGlobal)));        
      //  rpt.LocalReport.DataSources.Add(new ReportDataSource("Emisor", objDTE.Documento.Encabezado.Emisor));
      //rpt.LocalReport.DataSources.Add(new ReportDataSource("Receptor", objDTE.Documento.Encabezado.Receptor));
      //rpt.LocalReport.DataSources.Add(new ReportDataSource("Totales", objDTE.Documento.Encabezado.Totales));
      //rpt.LocalReport.DataSources.Add(new ReportDataSource("Referencia", objDTE.Documento.Referencia));
      //rpt.LocalReport.DataSources.Add(new ReportDataSource("IdDoc", objDTE.Documento.Encabezado.IdDoc));
      //rpt.LocalReport.DataSources.Add(new ReportDataSource("Detalle", objDTE.Documento.Detalle));
      //rpt.LocalReport.DataSources.Add(new ReportDataSource("DsctRecargo", objDTE.Documento.DscRcgGlobal));

      Uri pathAsUri = new Uri(strRutaPDF417);

      rpt.LocalReport.SetParameters(new ReportParameter("Timbre", pathAsUri.AbsoluteUri));
        rpt.LocalReport.SetParameters(new ReportParameter("NroResolucion", strNroResolucion));
        rpt.LocalReport.SetParameters(new ReportParameter("FechaResolucion", dtFechaResolucion.ToString()));

        string strDeviceInfo = "<DeviceInfo><StreamRoot>/RSWebServiceXS/</StreamRoot><OmitFormulas>True</OmitFormulas></DeviceInfo>";
        rpt.ServerReport.Refresh();

        return rpt.ServerReport.Render("PDF", strDeviceInfo);

      } catch (Exception ex) {
        
      }

      return null;
    }

    public static DataTable ObjectToData(object o) {
      DataTable dt = new DataTable("OutputData");

      DataRow dr = dt.NewRow();
      dt.Rows.Add(dr);

      o.GetType().GetProperties().ToList().ForEach(f => {
        try {
          f.GetValue(o, null);
          dt.Columns.Add(f.Name, f.PropertyType);
          dt.Rows[0][f.Name] = f.GetValue(o, null);
        } catch { }
      });
      return dt;
    }
  }
}
