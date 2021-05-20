using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DTE.LibroCV {

  #region EnvioLibro
  public class EnvioLibro {

    [XmlElementAttribute("Caratula")]
    public Caratula Caratula { get; set; }

     [XmlElementAttribute("ResumenSegmento")]
    public ResumenSegmento ResumenSegmento { get; set; }

    [XmlElementAttribute("ResumenPeriodo")]
    public ResumenPeriodo ResumenPeriodo { get; set; }

    [XmlElementAttribute("Detalle")]
    public List<LCV_Detalle> Detalle { get; set; }
    DateTime tmstFirmaField;

    [XmlIgnoreAttribute()]
    public DateTime TmstFirma { get { return tmstFirmaField; } set { tmstFirmaField = value; } }
    [XmlElement("TmstFirma")]
    public string TmstFirmaString { get { return tmstFirmaField.ToString("yyy-MM-ddTHH:mm:ss"); } set { DateTime.TryParse(value, out this.tmstFirmaField); } }

  }

  #endregion

  #region Caratula
  
   public class Caratula {
    public string RutEmisorLibro { get; set; }

    public string RutEnvia { get; set; }

    DateTime tmstPeriodoTributario;

    [XmlIgnoreAttribute()]
    public DateTime PeriodoTributario { get { return tmstPeriodoTributario; } set { tmstPeriodoTributario = value; } }
    [XmlElement("PeriodoTributario")]
    public string PeriodoTributarioString { get { return tmstPeriodoTributario.ToString("yyyy-MM"); } set { DateTime.TryParseExact(value,"yyyy-MM", new CultureInfo("es-CL"), DateTimeStyles.None , out this.tmstPeriodoTributario); } }

    [XmlElement(DataType = "date")]
    public DateTime FchResol { get; set; }
    public int NroResol { get; set; }
    public string TipoOperacion { get; set; }
    public string TipoLibro { get; set; }
    public string TipoEnvio { get; set; }

    public int NroSegmento { get; set; }
    public bool ShouldSerializeNroSegmento() { return NroSegmento != 0; }
    
    public int FolioNotificacion { get; set; }
    public bool ShouldSerializeFolioNotificacion() { return FolioNotificacion != 0; }
    
    public string CodAutRec { get; set; }
  }

  #endregion

  #region ResumenSegmento

  public class ResumenSegmento {
    [XmlElement("TotalesSegmento")]
    public List<TotalesSegmento> TotalesSegmento { get; set; }
    public bool ShouldSerializeTotalesSegmento() { return TotalesSegmento != null && TotalesSegmento.Count > 0; }
  }
  
  #endregion

  #region TotalSegmento
  
  public class TotalesSegmento {
    public int TpoDoc { get; set; }
    
    /// <comentarios/>
    public int TpoImp { get; set; }
    public bool ShouldSerializeTpoImp() { return TpoImp > 0; }
    
    public int TotDoc { get; set; }
    
    public int TotAnulado { get; set; }
    public bool ShouldSerializeTotAnulado() { return TotAnulado != 0; }
    
    public int TotOpExe { get; set; }
    public bool ShouldSerializeTotOpExe() { return TotOpExe != 0; }

    public int TotMntExe { get; set; }

    public int TotMntNeto { get; set; }

    public int TotOpIVARec { get; set; }
    public bool ShouldSerializeTotOpIVARec() { return TotOpIVARec != 0; }
    
    public int TotMntIVA { get; set; }
    
    public int TotOpActivoFijo { get; set; }
    public bool ShouldSerializeTotOpActivoFijo() { return TotOpActivoFijo != 0; }
    
    public int TotMntActivoFijo { get; set; }
    public bool ShouldSerializeTotMntActivoFijo() { return TotMntActivoFijo != 0; }
    
    public int TotMntIVAActivoFijo { get; set; }
    public bool ShouldSerializeTotMntIVAActivoFijo() { return TotMntIVAActivoFijo != 0; }
    
    [XmlElement("TotIVANoRec")]
    public List<TotIVANoRec> TotIVANoRec { get; set; }
    public bool ShouldSerializeTotIVANoRec() { return TotIVANoRec != null && TotIVANoRec.Count > 0; }
    
    public int TotOpIVAUsoComun { get; set; }
    public bool ShouldSerializeTotOpIVAUsoComun() { return TotOpIVAUsoComun != 0; }
    
    public int TotIVAUsoComun { get; set; }
    public bool ShouldSerializeTotIVAUsoComun() { return TotIVAUsoComun != 0; }
    
    public decimal TotIVAFueraPlazo { get; set; }
    public bool ShouldSerializeTotIVAFueraPlazo() { return TotIVAFueraPlazo != 0; }
    
    public int TotCredIVAUsoComun { get; set; }
    public bool ShouldSerializeTotCredIVAUsoComun() { return TotCredIVAUsoComun != 0; }
    
    public int TotIVAPropio { get; set; }
    public bool ShouldSerializeTotIVAPropio() { return TotIVAPropio != 0; }
    
    public int TotIVATerceros { get; set; }
    public bool ShouldSerializeTotIVATerceros() { return TotIVATerceros != 0; }
    
    public int TotLey18211 { get; set; }
    public bool ShouldSerializeTotLey18211() { return TotLey18211 != 0; }
    
    [XmlElement("TotOtrosImp")]
    public List<TotOtrosImp> TotOtrosImp { get; set; }
    public bool ShouldSerializeTotOtrosImp() { return TotOtrosImp != null && TotOtrosImp.Count > 0; }
    
    public int TotImpSinCredito { get; set; }
    public bool ShouldSerializeTotImpSinCredito() { return TotImpSinCredito != 0; }
    
    public int TotOpIVARetTotal { get; set; }
    public bool ShouldSerializeTotOpIVARetTotal() { return TotOpIVARetTotal != 0; }
    
    public int TotIVARetTotal { get; set; }
    public bool ShouldSerializeTotIVARetTotal() { return TotIVARetTotal != 0; }
    
    public int TotOpIVARetParcial { get; set; }
    public bool ShouldSerializeTotOpIVARetParcial() { return TotOpIVARetParcial != 0; }
    
    public int TotIVARetParcial { get; set; }
    public bool ShouldSerializeTotIVARetParcial() { return TotIVARetParcial != 0; }
    
    public int TotCredEC { get; set; }
    public bool ShouldSerializeTotCredEC() { return TotCredEC != 0; }
    
    public int TotDepEnvase { get; set; }
    public bool ShouldSerializeTotDepEnvase() { return TotDepEnvase != 0; }
    
    public TotLiquidaciones TotLiquidaciones { get; set; }
    public bool ShouldSerializeTotLiquidaciones() { return TotLiquidaciones != null; }
    
    public int TotMntTotal { get; set; }
    
    public int TotOpIVANoRetenido { get; set; }
    public bool ShouldSerializeTotOpIVANoRetenido() { return TotOpIVANoRetenido != 0; }
    
    public int TotIVANoRetenido { get; set; }
    public bool ShouldSerializeTotIVANoRetenido() { return TotIVANoRetenido != 0; }
    
    public int TotMntNoFact { get; set; }
    public bool ShouldSerializeTotMntNoFact() { return TotMntNoFact != 0; }
    
    public int TotMntPeriodo { get; set; }
    public bool ShouldSerializeTotMntPeriodo() { return TotMntPeriodo != 0; }
    
    public int TotPsjNac { get; set; }
    public bool ShouldSerializeTotPsjNac() { return TotPsjNac != 0; }
    
    public int TotPsjInt { get; set; }
    public bool ShouldSerializeTotPsjInt() { return TotPsjInt != 0; }
    
    public int TotTabPuros { get; set; }
    public bool ShouldSerializeTotTabPuros() { return TotTabPuros != 0; }
    
    public int TotTabCigarrillos { get; set; }
    public bool ShouldSerializeTotTabCigarrillos() { return TotTabCigarrillos != 0; }
    
    public int TotTabElaborado { get; set; }
    public bool ShouldSerializeTotTabElaborado() { return TotTabElaborado != 0; }

  }

  #endregion

  #region TotOtrosImp
  public class TotOtrosImp {

    /// <comentarios/>
    public int CodImp { get; set; }
    public bool ShouldSerializeCodImp() { return CodImp > 0; }

    /// <comentarios/>
    public int TotMntImp { get; set; }
    public bool ShouldSerializeTotMntImp() { return TotMntImp != 0; }
  }
  
  #endregion

  #region TotLiquidaciones
  
  public class TotLiquidaciones {

    /// <comentarios/>
    
    public int TotValComNeto { get; set; }
    public bool ShouldSerializeTotValComNeto() { return TotValComNeto != 0; }

    /// <comentarios/>
    
    public int TotValComExe { get; set; }
    public bool ShouldSerializeTotValComExe() { return TotValComExe != 0; }

    /// <comentarios/>
    
    public int TotValComIVA { get; set; }
    public bool ShouldSerializeTotValComIVA() { return TotValComIVA != 0; }
  }

  #endregion

  #region TotIVANoRec
  
  public class TotIVANoRec {

    /// <comentarios/>
    
    public int CodIVANoRec { get; set; }
    public bool ShouldSerializeCodIVANoRec() { return CodIVANoRec > 0; }

    /// <comentarios/>
    
    public int TotOpIVANoRec { get; set; }
    public bool ShouldSerializeTotOpIVANoRec() { return TotOpIVANoRec != 0; }
    /// <comentarios/>
    
    public int TotMntIVANoRec { get; set; }
    public bool ShouldSerializeTotMntIVANoRec() { return TotMntIVANoRec != 0; }
  }
  
  #endregion

  #region ResumenPeriodo
  
  public class ResumenPeriodo {

    [XmlElement("TotalesPeriodo")]    
    public List<TotalesPeriodo> TotalesPeriodo { get; set; }
    public bool ShouldSerializeTotalesPeriodo() { return TotalesPeriodo != null && TotalesPeriodo.Count > 0; }
  }
 
  #endregion

  #region TotalesPeriodo
  
  public class TotalesPeriodo {
    
    public int TpoDoc { get; set; }

    /// <comentarios/>
    
    public int TpoImp { get; set; }
    public bool ShouldSerializeTpoImp() { return TpoImp > 0; }

    
    public int TotDoc { get; set; }

    
    public int TotAnulado { get; set; }
    public bool ShouldSerializeTotAnulado() { return TotAnulado != 0; }

    
    public int TotOpExe { get; set; }
    public bool ShouldSerializeTotOpExe() { return TotOpExe != 0; }

    /// <comentarios/>
    
    public int TotMntExe { get; set; }

    /// <comentarios/>
    
    public int TotMntNeto { get; set; }

    
    public int TotOpIVARec { get; set; }
    public bool ShouldSerializeTotOpIVARec() { return TotOpIVARec != 0; }

    
    public int TotMntIVA { get; set; }

    
    public int TotOpActivoFijo { get; set; }
    public bool ShouldSerializeTotOpActivoFijo() { return TotOpActivoFijo != 0; }

    
    public int TotMntActivoFijo { get; set; }
    public bool ShouldSerializeTotMntActivoFijo() { return TotMntActivoFijo != 0; }

    
    public int TotMntIVAActivoFijo { get; set; }
    public bool ShouldSerializeTotMntIVAActivoFijo() { return TotMntIVAActivoFijo != 0; }

    [XmlElement("TotIVANoRec")]    
    public List<TotIVANoRec> TotIVANoRec { get; set; }
    public bool ShouldSerializeTotIVANoRec() { return TotIVANoRec != null && TotIVANoRec.Count > 0; }

    
    public int TotOpIVAUsoComun { get; set; }
    public bool ShouldSerializeTotOpIVAUsoComun() { return TotOpIVAUsoComun != 0; }

    
    public int TotIVAUsoComun { get; set; }
    public bool ShouldSerializeTotIVAUsoComun() { return TotIVAUsoComun != 0; }

    
    public decimal FctProp { get; set; }
    public bool ShouldSerializeFctProp() { return FctProp != 0; }

    
    public int TotCredIVAUsoComun { get; set; }
    public bool ShouldSerializeTotCredIVAUsoComun() { return TotCredIVAUsoComun != 0; }

    
    public int TotIVAFueraPlazo { get; set; }
    public bool ShouldSerializeTotIVAFueraPlazo() { return TotIVAFueraPlazo != 0; }

    
    public int TotIVAPropio { get; set; }
    public bool ShouldSerializeTotIVAPropio() { return TotIVAPropio != 0; }

    
    public int TotIVATerceros { get; set; }
    public bool ShouldSerializeTotIVATerceros() { return TotIVATerceros != 0; }

    
    public int TotLey18211 { get; set; }
    public bool ShouldSerializeTotLey18211() { return TotLey18211 != 0; }

    [XmlElement("TotOtrosImp")]    
    public List<TotOtrosImp> TotOtrosImp { get; set; }
    public bool ShouldSerializeTotOtrosImp() { return TotOtrosImp != null && TotOtrosImp.Count > 0; }

    
    public int TotImpSinCredito { get; set; }
    public bool ShouldSerializeTotImpSinCredito() { return TotImpSinCredito != 0; }

    
    public int TotOpIVARetTotal { get; set; }
    public bool ShouldSerializeTotOpIVARetTotal() { return TotOpIVARetTotal != 0; }

    
    public int TotIVARetTotal { get; set; }
    public bool ShouldSerializeTotIVARetTotal() { return TotIVARetTotal != 0; }

    
    public int TotOpIVARetParcial { get; set; }
    public bool ShouldSerializeTotOpIVARetParcial() { return TotOpIVARetParcial != 0; }

    
    public int TotIVARetParcial { get; set; }
    public bool ShouldSerializeTotIVARetParcial() { return TotIVARetParcial != 0; }

    
    public int TotCredEC { get; set; }
    public bool ShouldSerializeTotCredEC() { return TotCredEC != 0; }

    
    public int TotDepEnvase { get; set; }
    public bool ShouldSerializeTotDepEnvase() { return TotDepEnvase != 0; }

    
    public TotLiquidaciones TotLiquidaciones { get; set; }
    public bool ShouldSerializeTotLiquidaciones() { return TotLiquidaciones != null; }

    
    public int TotMntTotal { get; set; }

    
    public int TotOpIVANoRetenido { get; set; }
    public bool ShouldSerializeTotOpIVANoRetenido() { return TotOpIVANoRetenido != 0; }

    
    public int TotIVANoRetenido { get; set; }
    public bool ShouldSerializeTotIVANoRetenido() { return TotIVANoRetenido != 0; }

    
    public int TotMntNoFact { get; set; }
    public bool ShouldSerializeTotMntNoFact() { return TotMntNoFact != 0; }

    
    public int TotMntPeriodo { get; set; }
    public bool ShouldSerializeTotMntPeriodo() { return TotMntPeriodo != 0; }

    
    public int TotPsjNac { get; set; }
    public bool ShouldSerializeTotPsjNac() { return TotPsjNac != 0; }

    
    public int TotPsjInt { get; set; }
    public bool ShouldSerializeTotPsjInt() { return TotPsjInt != 0; }

    
    public int TotTabPuros { get; set; }
    public bool ShouldSerializeTotTabPuros() { return TotTabPuros != 0; }

    
    public int TotTabCigarrillos { get; set; }
    public bool ShouldSerializeTotTabCigarrillos() { return TotTabCigarrillos != 0; }

    
    public int TotTabElaborado { get; set; }
    public bool ShouldSerializeTotTabElaborado() { return TotTabElaborado != 0; }

  }
  
  #endregion

  #region LCV_Detalle
  
  public class LCV_Detalle {

    /// <comentarios/>
    
    public int TpoDoc { get; set; }

    /// <comentarios/>
    
    public int Emisor { get; set; }
    public bool ShouldSerializeEmisor() { return Emisor > 0; }

    /// <comentarios/>
    
    public int IndFactCompra { get; set; }
    public bool ShouldSerializeIndFactCompra() { return IndFactCompra  > 0; }

    
    public long NroDoc { get; set; }

    /// <comentarios/>
    
    public string Anulado { get; set; }

    /// <comentarios/>
    
    public int Operacion { get; set; }
    public bool ShouldSerializeOperacion() { return Operacion > 0; }

    
    public int TpoImp { get; set; }
    public bool ShouldSerializeTpoImp() { return TpoImp > 0; }

    /// <comentarios/>
    
    public decimal TasaImp { get; set; }

    /// <comentarios/>
    
    public string NumInt { get; set; }

    /// <comentarios/>
    
    public int IndServicio { get; set; }
    public bool ShouldSerializeIndServicio() { return IndServicio > 0; }

    /// <comentarios/>
    
    public int IndSinCosto { get; set; }
    public bool ShouldSerializeIndSinCosto() { return IndSinCosto > 0; }

    [XmlElement(DataType = "date")]
    public DateTime FchDoc { get; set; }
    public bool ShouldSerializeFchDoc() { return FchDoc.Ticks > 0; }

    public string CdgSIISucur { get; set; }

    /// <comentarios/>
    
    public string RUTDoc { get; set; }

    /// <comentarios/>
    
    public string RznSoc { get; set; }

    /// <comentarios/>
    
    public LCV_Extranjero Extranjero { get; set; }
    public bool ShouldSerializeExtranjero() { return Extranjero != null; }

    /// <comentarios/>
    
    public int TpoDocRef { get; set; }
    public bool ShouldSerializeTpoDocRef() { return TpoDocRef > 0; }


    /// <comentarios/>
    
    public long FolioDocRef { get; set; }
    public bool ShouldSerializeFolioDocRef() { return FolioDocRef != 0; }

    /// <comentarios/>
    
    public int MntExe { get; set; }

    
    public int MntNeto { get; set; }

    
    public int MntIVA { get; set; }

    
    public int MntActivoFijo { get; set; }
    public bool ShouldSerializeMntActivoFijo() { return MntActivoFijo != 0; }

    
    public int MntIVAActivoFijo { get; set; }
    public bool ShouldSerializeMntIVAActivoFijo() { return MntIVAActivoFijo != 0; }

    [XmlElement("IVANoRec")]    
    public List<IVANoRec> IVANoRec { get; set; }
    public bool ShouldSerializeIVANoRec() { return IVANoRec != null && IVANoRec.Count > 0; }

    
    public int IVAUsoComun { get; set; }
    public bool ShouldSerializeIVAUsoComun() { return IVAUsoComun != 0; }

    
    public int IVAFueraPlazo { get; set; }
    public bool ShouldSerializeIVAFueraPlazo() { return IVAFueraPlazo != 0; }

    
    public int IVAPropio { get; set; }
    public bool ShouldSerializeIVAPropio() { return IVAPropio != 0; }

    
    public int IVATerceros { get; set; }
    public bool ShouldSerializeIVATerceros() { return IVATerceros != 0; }

    
    public int Ley18211 { get; set; }
    public bool ShouldSerializeLey18211() { return Ley18211 != 0; }

    [XmlElement("OtrosImp")]    
    public List<OtrosImp> OtrosImp { get; set; }
    public bool ShouldSerializeOtrosImp() { return OtrosImp != null && OtrosImp.Count > 0; }

    
    public int MntSinCred { get; set; }
    public bool ShouldSerializeMntSinCred() { return MntSinCred != 0; }

    
    public int IVARetTotal { get; set; }
    public bool ShouldSerializeIVARetTotal() { return IVARetTotal != 0; }

    
    public int IVARetParcial { get; set; }
    public bool ShouldSerializeIVARetParcial() { return IVARetParcial != 0; }

    
    public int CredEC { get; set; }
    public bool ShouldSerializeCredEC() { return CredEC != 0; }

    
    public int DepEnvase { get; set; }
    public bool ShouldSerializeDepEnvase() { return DepEnvase != 0; }

    /// <comentarios/>
    
    public Liquidaciones Liquidaciones { get; set; }
    public bool ShouldSerializeLiquidaciones() { return Liquidaciones != null; }

    
    public int MntTotal { get; set; }

    
    public int IVANoRetenido { get; set; }
    public bool ShouldSerializeIVANoRetenido() { return IVANoRetenido != 0; }

    
    public int MntNoFact { get; set; }
    public bool ShouldSerializeMntNoFact() { return MntNoFact != 0; }

    
    public int MntPeriodo { get; set; }
    public bool ShouldSerializeMntPeriodo() { return MntPeriodo != 0; }

    
    public int PsjNac { get; set; }
    public bool ShouldSerializePsjNac() { return PsjNac != 0; }

    
    public int PsjInt { get; set; }
    public bool ShouldSerializePsjInt() { return PsjInt != 0; }

    
    public int TabPuros { get; set; }
    public bool ShouldSerializeTabPuros() { return TabPuros != 0; }

    
    public int TabCigarrillos { get; set; }
    public bool ShouldSerializeTabCigarrillos() { return TabCigarrillos != 0; }

    
    public int TabElaborado { get; set; }
    public bool ShouldSerializeTabElaborado() { return TabElaborado != 0; }

    
    public int ImpVehiculo { get; set; }
    public bool ShouldSerializeImpVehiculo() { return ImpVehiculo != 0; }
  }
  
  #endregion

  #region IVANoRec
  
  public class IVANoRec {

    /// <comentarios/>
    
    public int CodIVANoRec { get; set; }
    public bool ShouldSerializeCodIVANoRec() { return CodIVANoRec > 0; }

    
    public int MntIVANoRec { get; set; }
    public bool ShouldSerializeMntIVANoRec() { return MntIVANoRec != 0; }
  }
  
  #endregion

  #region LCV_Extranjero
  
  public class LCV_Extranjero {
    
    public string NumId { get; set; }

    /// <comentarios/>
    
    public string Nacionalidad { get; set; }
  } 

  #endregion

  #region OtrosImp
  
  public class OtrosImp {

    /// <comentarios/>
    
    public int CodImp { get; set; }
    public bool ShouldSerializeCodImp() { return CodImp > 0; }

    /// <comentarios/>
    
    public decimal TasaImp { get; set; }
    public bool ShouldSerializeTasaImp() { return TasaImp != 0; }

    /// <comentarios/>
    
    public int MntImp { get; set; }
    public bool ShouldSerializeMntImp() { return MntImp != 0; }
  }

  #endregion
  
  #region Liquidaciones
  
  public class Liquidaciones {

    /// <comentarios/>
    
    public string RutEmisor { get; set; }

    
    public int ValComNeto { get; set; }
    public bool ShouldSerializeValComNeto() { return ValComNeto != 0; }

    
    public int ValComExe { get; set; }
    public bool ShouldSerializeValComExe() { return ValComExe != 0; }

    
    public int ValComIVA { get; set; }
    public bool ShouldSerializeValComIVA() { return ValComIVA != 0; }
  }

  #endregion

}
