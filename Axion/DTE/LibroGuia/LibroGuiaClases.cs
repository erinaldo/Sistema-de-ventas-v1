using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DTE.LibroGuia {

  #region EnvioLibro
  
  public class EnvioLibroGuia {

    [XmlElementAttribute("Caratula")]
    
    public LGCaratula Caratula { get; set; }

    [XmlElementAttribute("ResumenPeriodo")]
    
    public List<LGResumenPeriodo> ResumenPeriodo { get; set; }

    [XmlElementAttribute("ResumenSegmento")]
    
    public List<LGResumenSegmento> ResumenSegmento { get; set; }

    [XmlElementAttribute("Detalle")]
    
    public List<LGDetalle> Detalle { get; set; }
    DateTime tmstFirmaField;

    [XmlIgnoreAttribute()]
    public DateTime TmstFirma { get { return tmstFirmaField; } set { tmstFirmaField = value; } }
    [XmlElement("TmstFirma")]
    
    public string TmstFirmaString { get { return tmstFirmaField.ToString("yyy-MM-ddTHH:mm:ss"); } set { DateTime.TryParse(value, out this.tmstFirmaField); } }

  }

  #endregion

  #region Caratula

  public class LGCaratula {

    public string RutEmisorLibro { get; set; }

    public string RutEnvia { get; set; }

    DateTime tmstPeriodoTributario;

    [XmlIgnoreAttribute()]
    public DateTime PeriodoTributario { get { return tmstPeriodoTributario; } set { tmstPeriodoTributario = value; } }
    
    [XmlElement("PeriodoTributario")]
    public string PeriodoTributarioString { get { return tmstPeriodoTributario.ToString("yyyy-MM"); } set { DateTime.TryParseExact(value, "yyyy-MM", new CultureInfo("es-CL"), DateTimeStyles.None, out this.tmstPeriodoTributario); } }

    [XmlElement(DataType = "date")]
    public DateTime FchResol { get; set; }

    public int NroResol { get; set; }

    
    public string TipoLibro { get; set; }

    
    public string TipoEnvio { get; set; }

    
    public int NroSegmento { get; set; }
    public bool ShouldSerializeNroSegmento() { return NroSegmento != 0; }

    
    public int FolioNotificacion { get; set; }
    public bool ShouldSerializeFolioNotificacion() { return FolioNotificacion != 0; }
  }

  #endregion

  #region ResumenSegmento
  
  public class LGResumenSegmento {

    
    public int TotFolAnulado { get; set; }
    public bool ShouldSerializeTotFolAnulado() { return TotFolAnulado > 0; }

    
    public int TotGuiaAnulada { get; set; }
    public bool ShouldSerializeTotGuiaAnulada() { return TotGuiaAnulada > 0; }

    
    public int TotGuiaVenta { get; set; }

    
    public int TotMntGuiaVta { get; set; }

    
    public int TotMntModificado { get; set; }
    public bool ShouldSerializeTotMntModificado() { return TotMntModificado > 0; }

    [XmlElementAttribute("TotTraslado")]    
    public List<LGTotalTraslado> TotTraslado { get; set; }
    public bool ShouldSerializeTotTraslado() { return TotTraslado != null && TotTraslado.Count != 0; }
  }

  #endregion

  #region ResumenPeriodo
  
  public class LGResumenPeriodo {

    
    public int TotFolAnulado { get; set; }

    
    public int TotGuiaAnulada { get; set; }

    
    public int TotGuiaVenta { get; set; }

    
    public int TotMntGuiaVta { get; set; }

    
    public int TotMntModificado { get; set; }
    public bool ShouldSerializeTotMntModificado() { return TotMntModificado > 0; }

    [XmlElementAttribute("TotTraslado")]
    
    public List<LGTotalTraslado> TotTraslado { get; set; }
    public bool ShouldSerializeTotTraslado() { return TotTraslado != null && TotTraslado.Count != 0; }
  }

  #endregion

  #region TotTraslado
  
  public class LGTotalTraslado {

    
    public int TpoTraslado { get; set; }

    
    public int CantGuia { get; set; }

    
    public int MntGuia { get; set; }
    public bool ShouldSerializeMntGuia() { return MntGuia > 0; }
  }

  #endregion

  #region Detalle
  
  public class LGDetalle {

    
    public int Folio { get; set; }

    
    public int Anulado { get; set; }
    public bool ShouldSerializeAnulado() { return Anulado > 0; }

    
    public int Operacion { get; set; }
    public bool ShouldSerializeOperacion() { return Operacion > 0; }

    
    public int TpoOper { get; set; }

    [XmlElement(DataType = "date")]    
    public DateTime FchDoc { get; set; }

    
    public string RUTDoc { get; set; }

    
    public string RznSoc { get; set; }

    
    public int MntNeto { get; set; }
    public bool ShouldSerializeMntNeto() { return MntNeto > 0; }

    
    public int TasaImp { get; set; }
    public bool ShouldSerializeTasaImp() { return TasaImp > 0; }

    
    public int IVA { get; set; }
    public bool ShouldSerializeIVA() { return IVA > 0; }

    
    public int MntTotal { get; set; }
    public bool ShouldSerializeMntTotal() { return MntTotal > 0; }

    
    public int MntModificado { get; set; }
    public bool ShouldSerializeMntModificado() { return MntModificado > 0; }

    
    public int TpoDocRef { get; set; }
    public bool ShouldSerializeTpoDocRef() { return TpoDocRef > 0; }

    
    public string FolioDocRef { get; set; }

    [XmlElement(DataType = "date")]
    
    public DateTime FchDocRef { get; set; }
    public bool ShouldSerializeFchDocRef() { return FchDocRef.Ticks != 0; }
  }

  #endregion


}
