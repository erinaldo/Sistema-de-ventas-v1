using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Cesion {

  public class DTECedido {
    public DocumentoDTECedido DocumentoDTECedido { get; set; }
  }

  public class DocumentoDTECedido {
    public string DTE { get; set; }
  }

  public class Cesion {
    public DocumentoCesion DocumentoCesion { get; set; }
  }

  public class DocumentoCesion {

    public int SeqCesion { get; set; }
    public IdDTE IdDTE { get; set; }
    public Cedente Cedente { get; set; }
    public Cesionario Cesionario { get; set; }
    public int MontoCesion { get; set; }

    [XmlElement(DataType = "date")]
    public DateTime UltimoVencimiento { get; set; }

    [XmlElement("OtrasCondiciones")]
    public List<string> OtrasCondiciones { get; set; }
    public string eMailDeudor { get; set; }
  }
  public class IdDTE {
    public int TipoDTE { get; set; }
    public string RUTEmisor { get; set; }
    public string RUTReceptor { get; set; }
    public long Folio { get; set; }

    [XmlElement(DataType = "date")]
    public DateTime FchEmis { get; set; }
    public int MntTotal { get; set; }
  }

  public class Cedente {
    public string RUT { get; set; }
    public string RazonSocial { get; set; }
    public string Direccion { get; set; }
    public string eMail { get; set; }

    [XmlElement("RUTAutorizado")]
    public List<RUTAutorizado> RUTAutorizado { get; set; }
    public string DeclaracionJurada { get; set; }

  }

  public class RUTAutorizado {
    public string RUT { get; set; }
    public string Nombre { get; set; }
  }

  public class Cesionario {
    public string RUT { get; set; }
    public string RazonSocial { get; set; }
    public string Direccion { get; set; }
    public string eMail { get; set; }
  }


}
