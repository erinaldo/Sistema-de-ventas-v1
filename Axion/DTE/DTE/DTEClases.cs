using Comun;
using ITD.Funciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DTE {

  public class DTE {
    public Documento Documento { get; set; }
  }

  #region Documento

  public class Documento {
    public Encabezado Encabezado { get; set; }

    [XmlElement("Detalle")]
    public List<Detalle> Detalle { get; set; }

    [XmlElement("DscRcgGlobal")]
    public List<DscRcgGlobal> DscRcgGlobal { get; set; }

    public bool ShouldSerializeDscRcgGlobal() {
      return DscRcgGlobal != null && DscRcgGlobal.Count > 0;
    }

    [XmlElement("Referencia")]
    public List<Referencia> Referencia { get; set; }

    public bool ShouldSerializeReferencia() {
      return Referencia != null && Referencia.Count > 0;
    }

    [XmlElement("SubTotInfo")]
    public List<SubTotInfo> SubTotInfo { get; set; }

    public bool ShouldSerializeSubTotInfo() {
      return SubTotInfo != null && SubTotInfo.Count > 0;
    }

    private DateTime tmstFirmaField;

    [XmlIgnoreAttribute()]
    public DateTime TmstFirma { get { return tmstFirmaField; } set { tmstFirmaField = value; } }

    [XmlElement("TmstFirma")]
    [DataMember]
    public string TmstFirmaString { get { return tmstFirmaField.ToString("yyy-MM-ddTHH:mm:ss"); } set { DateTime.TryParse(value, out this.tmstFirmaField); } }
  }

  #endregion Documento

  #region Exportacion
  
  #endregion Exportacion

  #region Referencia

  public class Referencia {
    General objGeneral;

    public Referencia() {
      objGeneral = new General();
    }

    public string Validar(bool bolExportacion) {
      StringBuilder stbError = new StringBuilder();
      string strRes = "";

      //TpoDocRef
      string strNombreVariable = objGeneral.GetVariableName(() => TpoDocRef);
      strRes = objGeneral.Validar(TpoDocRef, strNombreVariable, true, 0, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //IndGlobal
      strNombreVariable = objGeneral.GetVariableName(() => IndGlobal);
      strRes = objGeneral.Validar(strNombreVariable, false, IndGlobal != 0 && IndGlobal != 1);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //FolioRef
      strNombreVariable = objGeneral.GetVariableName(() => FolioRef);
      strRes = objGeneral.Validar(FolioRef, strNombreVariable, true, 18, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //RUTOtr
      strNombreVariable = objGeneral.GetVariableName(() => RUTOtr);
      strRes = objGeneral.Validar(RUTOtr, strNombreVariable, false, 0, bolExportacion, true);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //CodRef
      strNombreVariable = objGeneral.GetVariableName(() => CodRef);
      strRes = objGeneral.Validar(strNombreVariable, false, CodRef != 0 && (CodRef < 1 || CodRef > 3));
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //RazonRef
      strNombreVariable = objGeneral.GetVariableName(() => RazonRef);
      strRes = objGeneral.Validar(RazonRef, strNombreVariable, false, 90, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      return stbError.ToString();
    }

    public long NroLinRef { get; set; }

    public bool ShouldSerializeNroLinRef() {
      return NroLinRef != 0;
    }

    public string TpoDocRef { get; set; }

    public int IndGlobal { get; set; }

    public bool ShouldSerializeIndGlobal() {
      return IndGlobal > 0;
    }

    public string FolioRef { get; set; }

    public string RUTOtr { get; set; }

    [XmlElement(DataType = "date")]
    //[DataMember]
    public DateTime FchRef { get; set; }

    public bool ShouldSerializeFchRef() {
      return FchRef.Ticks != 0;
    }

    public int? CodRef { get; set; }

    public bool ShouldSerializeCodRef() {
      return CodRef.HasValue;
    }

    public string RazonRef { get; set; }
  }

  #endregion Referencia

  #region Encabezado

  public class Encabezado {
    General objGeneral;

    public Encabezado() {
      objGeneral = new General();
    }

    public string Validar(bool bolExportacion) {
      StringBuilder stbError = new StringBuilder();
      string strRes;

      //RUTMandante
      string strNombreVariable = objGeneral.GetVariableName(() => RUTMandante);
      strRes = objGeneral.Validar(RUTMandante, strNombreVariable, false, 0, bolExportacion, true);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //RUTMandante
      strNombreVariable = objGeneral.GetVariableName(() => RUTSolicita);
      strRes = objGeneral.Validar(RUTSolicita, strNombreVariable, false, 0, bolExportacion, true);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      return stbError.ToString();
    }

    public IdDoc IdDoc { get; set; }

    public Emisor Emisor { get; set; }

    public string RUTMandante { get; set; }

    public Receptor Receptor { get; set; }

    public string RUTSolicita { get; set; }

    public Transporte Transporte { get; set; }

    public bool ShouldSerializeTransporte() {
      return Transporte != null;
    }

    public Totales Totales { get; set; }

    public bool ShouldSerializeTotales() {
      return Totales != null;
    }

    public OtraMoneda OtraMoneda { get; set; }

    public bool ShouldSerializeOtraMoneda() {
      return OtraMoneda != null;
    }

  }

  #endregion Encabezado

  #region ImpRetOtrMnda

  public class ImpRetOtrMnda {

    public string Validar() {
      StringBuilder stbError = new StringBuilder();

      if (TipoImpOtrMnda != 0 && !((TipoImpOtrMnda >= 14 && TipoImpOtrMnda <= 19) || (TipoImpOtrMnda >= 23 && TipoImpOtrMnda <= 28) || (TipoImpOtrMnda >= 30 && TipoImpOtrMnda <= 41) || (TipoImpOtrMnda >= 44 && TipoImpOtrMnda <= 53) || TipoImpOtrMnda == 301 || TipoImpOtrMnda == 321 || TipoImpOtrMnda == 331 || TipoImpOtrMnda == 341 || TipoImpOtrMnda == 361 || TipoImpOtrMnda == 371 || TipoImpOtrMnda == 481))
        stbError.AppendLine("TipoImpOtrMnda no válido");

      return stbError.ToString();
    }

    public int TipoImpOtrMnda { get; set; }

    public bool ShouldSerializeTipoImpOtrMnda() {
      return TipoImpOtrMnda > 0;
    }

    public decimal TasaImpOtrMnda { get; set; }

    public bool ShouldSerializeTasaImpOtrMnda() {
      return TasaImpOtrMnda != 0;
    }

    public decimal VlrImpOtrMnda { get; set; }

    public bool ShouldSerializeVlrImpOtrMnda() {
      return VlrImpOtrMnda != 0;
    }
  }

  #endregion ImpRetOtrMnda

  #region ImptoReten

  public class ImptoReten {

    public string Validar() {
      StringBuilder stbError = new StringBuilder();

      if (TipoImp != 0 && !((TipoImp >= 14 && TipoImp <= 19) || (TipoImp >= 23 && TipoImp <= 28) || (TipoImp >= 30 && TipoImp <= 41) || (TipoImp >= 44 && TipoImp <= 53) || TipoImp == 301 || TipoImp == 321 || TipoImp == 331 || TipoImp == 341 || TipoImp == 361 || TipoImp == 371 || TipoImp == 481))
        stbError.AppendLine("TipoImp no válido");

      return stbError.ToString();
    }

    public int TipoImp { get; set; }

    public bool ShouldSerializeTipoImp() {
      return TipoImp > 0;
    }

    public decimal TasaImp { get; set; }

    public bool ShouldSerializeTasaImp() {
      return TasaImp != 0;
    }

    public decimal MontoImp { get; set; }

    public bool ShouldSerializeMontoImp() {
      return MontoImp != 0;
    }
  }

  #endregion ImptoReten

  #region IdDoc

  public class IdDoc {
    General objGeneral;

    public IdDoc() {
      objGeneral = new General();
    }
    public string Validar(bool bolExportacion) {
      StringBuilder stbError = new StringBuilder();
      int int20 = 20;
      string strRes;

      //TipoDTE
      string strNombreVariable = objGeneral.GetVariableName(() => TipoDTE);
      strRes = objGeneral.Validar(strNombreVariable, false, TipoDTE == 0 || !(TipoDTE == 33 || TipoDTE == 34 || TipoDTE == 46 || TipoDTE == 52 || TipoDTE == 56 || TipoDTE == 61));
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //Folio
      strNombreVariable = objGeneral.GetVariableName(() => Folio);
      strRes = objGeneral.Validar(strNombreVariable, false, Folio == 0);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //FchEmis
      strNombreVariable = objGeneral.GetVariableName(() => FchEmis);
      strRes = objGeneral.Validar(strNombreVariable, FchEmis.Ticks == 0);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //IndNoRebaja
      strNombreVariable = objGeneral.GetVariableName(() => IndNoRebaja);
      strRes = objGeneral.Validar(strNombreVariable, false, IndNoRebaja != 0 && IndNoRebaja != 1);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //TipoDespacho
      strNombreVariable = objGeneral.GetVariableName(() => TipoDespacho);
      strRes = objGeneral.Validar(strNombreVariable, false, TipoDespacho != 0 && (TipoDespacho < 1 || TipoDespacho > 3));
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //IndTraslado
      strNombreVariable = objGeneral.GetVariableName(() => IndTraslado);
      strRes = objGeneral.Validar(strNombreVariable, false, IndTraslado != 0 && (IndTraslado < 1 || IndTraslado > 9));
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //IndTraslado
      strNombreVariable = objGeneral.GetVariableName(() => IndTraslado);
      strRes = objGeneral.Validar(strNombreVariable, false, IndTraslado != 0 && (IndTraslado < 1 || IndTraslado > 9));
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //TpoImpresion
      if (!string.IsNullOrWhiteSpace(TpoImpresion))
        TpoImpresion = TpoImpresion.ToUpper();
      strNombreVariable = objGeneral.GetVariableName(() => TpoImpresion);
      strRes = objGeneral.Validar(strNombreVariable, false, !string.IsNullOrWhiteSpace(TpoImpresion) && TpoImpresion != "N" && TpoImpresion != "T");
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //IndServicio
      strNombreVariable = objGeneral.GetVariableName(() => IndServicio);
      strRes = objGeneral.Validar(strNombreVariable, false, IndServicio != 0 && (IndServicio < 1 || IndServicio > 5));
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //MntBruto
      strNombreVariable = objGeneral.GetVariableName(() => MntBruto);
      strRes = objGeneral.Validar(strNombreVariable, false, MntBruto != 0 && MntBruto != 1);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //FmaPago
      strNombreVariable = objGeneral.GetVariableName(() => FmaPago);
      strRes = objGeneral.Validar(strNombreVariable, false, FmaPago != 0 && (FmaPago < 1 || FmaPago > 3));
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //MedioPago
      if (!string.IsNullOrWhiteSpace(MedioPago))
        MedioPago = MedioPago.ToUpper();
      strNombreVariable = objGeneral.GetVariableName(() => MedioPago);
      strRes = objGeneral.Validar(strNombreVariable, false, !string.IsNullOrWhiteSpace(MedioPago) && (MedioPago.Length > 2 || (MedioPago != "CH" && MedioPago != "CF" && MedioPago != "LT" && MedioPago != "EF" && MedioPago != "PE" && MedioPago != "TC" && MedioPago != "OT")));
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //TipoCtaPago
      if (!string.IsNullOrWhiteSpace(TipoCtaPago))
        TipoCtaPago = TipoCtaPago.ToUpper();
      strNombreVariable = objGeneral.GetVariableName(() => TipoCtaPago);
      strRes = objGeneral.Validar(strNombreVariable, false, !string.IsNullOrWhiteSpace(TipoCtaPago) && (TipoCtaPago.Length > 2 || (TipoCtaPago != "CT" && TipoCtaPago != "AH" && TipoCtaPago != "OT")));
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //NumCtaPago
      strNombreVariable = objGeneral.GetVariableName(() => NumCtaPago);
      strRes = objGeneral.Validar(NumCtaPago, strNombreVariable, false, int20, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //BcoPago
      strNombreVariable = objGeneral.GetVariableName(() => BcoPago);
      strRes = objGeneral.Validar(BcoPago, strNombreVariable, false, 40, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //TermPagoCdg
      strNombreVariable = objGeneral.GetVariableName(() => TermPagoCdg);
      strRes = objGeneral.Validar(TermPagoCdg, strNombreVariable, false, 4, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //TermPagoGlosa
      strNombreVariable = objGeneral.GetVariableName(() => TermPagoGlosa);
      strRes = objGeneral.Validar(TermPagoGlosa, strNombreVariable, false, 100, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      if (MntPagos != null && MntPagos.Count > 30)
        stbError.AppendLine("Ha superado el límite del campo MntPagos");

      return stbError.ToString();
    }

    public int TipoDTE { get; set; }

    public long Folio { get; set; }

    [XmlElement(DataType = "date")]
    public DateTime FchEmis { get; set; }

    public int IndNoRebaja { get; set; }

    public bool ShouldSerializeIndNoRebaja() {
      return IndNoRebaja > 0;
    }

    public int TipoDespacho { get; set; }

    public bool ShouldSerializeTipoDespacho() {
      return TipoDespacho > 0;
    }

    public int IndTraslado { get; set; }

    public bool ShouldSerializeIndTraslado() {
      return IndTraslado > 0;
    }

    public string TpoImpresion { get; set; }

    public int IndServicio { get; set; }

    public bool ShouldSerializeIndServicio() {
      return IndServicio > 0;
    }

    public int MntBruto { get; set; }

    public bool ShouldSerializeMntBruto() {
      return MntBruto != 0;
    }

    public int FmaPago { get; set; }

    public int FmaPagExp { get; set; }

    public bool ShouldSerializeFmaPagExp() {
      return FmaPagExp != 0;
    }

    public bool ShouldSerializeFmaPago() {
      return FmaPago > 0;
    }

    [XmlElement(DataType = "date")]
    public DateTime FchCancel { get; set; }

    public bool ShouldSerializeFchCancel() {
      return FchCancel.Ticks != 0;
    }

    public long MntCancel { get; set; }

    public bool ShouldSerializeMntCancel() {
      return MntCancel != 0;
    }

    public long SaldoInsol { get; set; }

    public bool ShouldSerializeSaldoInsol() {
      return SaldoInsol != 0;
    }

    [XmlElement("MntPagos")]
    public List<MntPagos> MntPagos { get; set; }

    public bool ShouldSerializeMntPagos() {
      return MntPagos != null && MntPagos.Count > 0;
    }

    [XmlElement(DataType = "date")]
    public DateTime PeriodoDesde { get; set; }

    public bool ShouldSerializePeriodoDesde() {
      return PeriodoDesde.Ticks != 0;
    }

    [XmlElement(DataType = "date")]
    public DateTime PeriodoHasta { get; set; }

    public bool ShouldSerializePeriodoHasta() {
      return PeriodoHasta.Ticks != 0;
    }

    public string MedioPago { get; set; }

    public string TipoCtaPago { get; set; }

    public string NumCtaPago { get; set; }

    public string BcoPago { get; set; }

    public string TermPagoCdg { get; set; }

    public string TermPagoGlosa { get; set; }

    public long TermPagoDias { get; set; }

    public bool ShouldSerializeTermPagoDias() {
      return TermPagoDias != 0;
    }

    [XmlElement(DataType = "date")]
    public DateTime FchVenc { get; set; }

    public bool ShouldSerializeFchVenc() {
      return FchVenc.Ticks != 0;
    }
  }

  #endregion IdDoc

  #region MntPagos

  public class MntPagos {

    [XmlElement(DataType = "date")]
    public DateTime FchPago { get; set; }

    public long MntPago { get; set; }

    public string GlosaPagos { get; set; }
  }

  #endregion MntPagos

  #region GuiaExport

  public class GuiaExport {

    public string Validar() {
      StringBuilder stbError = new StringBuilder();

      if (CdgTraslado != 0 && (CdgTraslado < 1 || CdgTraslado > 4))
        stbError.AppendLine("CdgTraslado no válido");

      return stbError.ToString();
    }

    public int CdgTraslado { get; set; }

    public bool ShouldSerializeCdgTraslado() {
      return CdgTraslado > 0;
    }

    public int FolioAut { get; set; }

    public bool ShouldSerializeFolioAut() {
      return FolioAut != 0;
    }

    public DateTime FchAut { get; set; }

    public bool ShouldSerializeFchAut() {
      return FchAut.Ticks != 0;
    }
  }

  #endregion GuiaExport

  #region Emisor

  public class Emisor {
    General objGeneral;

    public Emisor() {
      objGeneral = new General();
    }
    public string Validar(bool bolExportacion) {
      StringBuilder stbError = new StringBuilder();
      int int20 = 20, int80 = 80, int100 = 100, int60 = 60;
      string strRes = "";

      //RUTEmisor
      string strNombreVariable = objGeneral.GetVariableName(() => RUTEmisor);
      strRes = objGeneral.Validar(RUTEmisor, strNombreVariable, true, 0, bolExportacion, true);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //RznSoc
      strNombreVariable = objGeneral.GetVariableName(() => RznSoc);
      strRes = objGeneral.Validar(RznSoc, strNombreVariable, true, int100, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //GiroEmis
      strNombreVariable = objGeneral.GetVariableName(() => GiroEmis);
      strRes = objGeneral.Validar(GiroEmis, strNombreVariable, true, int80, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //Telefono
      strNombreVariable = objGeneral.GetVariableName(() => Telefono);
      strRes = objGeneral.Validar(Telefono, strNombreVariable, false, int20, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //CorreoEmisor
      strNombreVariable = objGeneral.GetVariableName(() => CorreoEmisor);
      strRes = objGeneral.Validar(CorreoEmisor, strNombreVariable, false, int80, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //Sucursal
      strNombreVariable = objGeneral.GetVariableName(() => Sucursal);
      strRes = objGeneral.Validar(Sucursal, strNombreVariable, false, int20, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //DirOrigen
      strNombreVariable = objGeneral.GetVariableName(() => DirOrigen);
      strRes = objGeneral.Validar(DirOrigen, strNombreVariable, true, int60, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //CmnaOrigen
      strNombreVariable = objGeneral.GetVariableName(() => CmnaOrigen);
      strRes = objGeneral.Validar(CmnaOrigen, strNombreVariable, true, int20, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //CmnaOrigen
      strNombreVariable = objGeneral.GetVariableName(() => CiudadOrigen);
      strRes = objGeneral.Validar(CiudadOrigen, strNombreVariable, false, int20, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //CdgVendedor
      strNombreVariable = objGeneral.GetVariableName(() => CdgVendedor);
      strRes = objGeneral.Validar(CdgVendedor, strNombreVariable, false, int60, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //IdAdicEmisor
      strNombreVariable = objGeneral.GetVariableName(() => IdAdicEmisor);
      strRes = objGeneral.Validar(IdAdicEmisor, strNombreVariable, false, int20, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      return stbError.ToString();
    }

    public string RUTEmisor { get; set; }

    public string RznSoc { get; set; }

    public string GiroEmis { get; set; }

    public string Telefono { get; set; }

    public string CorreoEmisor { get; set; }

    public int Acteco { get; set; }

    public bool ShouldSerializeActeco() {
      return Acteco != 0;
    }

    public GuiaExport GuiaExport { get; set; }

    public bool ShouldSerializeGuiaExport() {
      return GuiaExport != null;
    }

    public string Sucursal { get; set; }

    public int CdgSIISucur { get; set; }

    public bool ShouldSerializeCdgSIISucur() {
      return CdgSIISucur != 0;
    }

    public string DirOrigen { get; set; }

    public string CmnaOrigen { get; set; }

    public string CiudadOrigen { get; set; }

    public string CdgVendedor { get; set; }

    public string IdAdicEmisor { get; set; }
  }

  #endregion Emisor

  #region Receptor

  public class Receptor {
    General objGeneral;

    public Receptor() {
      objGeneral = new General();
    }
    public string Validar(bool bolExportacion) {
      StringBuilder stbError = new StringBuilder();
      int int20 = 20, int80 = 80, int70 = 70, int100 = 100;
      string strRes;

      //RUTRecep
      string strNombreVariable = objGeneral.GetVariableName(() => RUTRecep);
      strRes = objGeneral.Validar(RUTRecep, strNombreVariable, true, 0, bolExportacion, true);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //CdgIntRecep
      strNombreVariable = objGeneral.GetVariableName(() => CdgIntRecep);
      strRes = objGeneral.Validar(CdgIntRecep, strNombreVariable, false, int20, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //RznSocRecep
      strNombreVariable = objGeneral.GetVariableName(() => RznSocRecep);
      strRes = objGeneral.Validar(RznSocRecep, strNombreVariable, true, int100, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //GiroRecep
      strNombreVariable = objGeneral.GetVariableName(() => GiroRecep);
      strRes = objGeneral.Validar(GiroRecep, strNombreVariable, true, int80, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //Contacto
      strNombreVariable = objGeneral.GetVariableName(() => Contacto);
      strRes = objGeneral.Validar(Contacto, strNombreVariable, false, int80, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //CorreoRecep
      strNombreVariable = objGeneral.GetVariableName(() => CorreoRecep);
      strRes = objGeneral.Validar(CorreoRecep, strNombreVariable, false, int80, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //DirRecep
      strNombreVariable = objGeneral.GetVariableName(() => DirRecep);
      strRes = objGeneral.Validar(DirRecep, strNombreVariable, true, int70, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //CmnaRecep
      strNombreVariable = objGeneral.GetVariableName(() => CmnaRecep);
      strRes = objGeneral.Validar(CmnaRecep, strNombreVariable, true, int20, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //CiudadRecep
      strNombreVariable = objGeneral.GetVariableName(() => CiudadRecep);
      strRes = objGeneral.Validar(CiudadRecep, strNombreVariable, false, int20, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      return stbError.ToString();
    }

    public string RUTRecep { get; set; }

    public string CdgIntRecep { get; set; }

    public string RznSocRecep { get; set; }

    public Extranjero Extranjero { get; set; }

    public bool ShouldSerializeExtranjero() {
      return Extranjero != null;
    }

    public string GiroRecep { get; set; }

    public string Contacto { get; set; }

    public string CorreoRecep { get; set; }

    public string DirRecep { get; set; }

    public string CmnaRecep { get; set; }

    public string CiudadRecep { get; set; }

    public string DirPostal { get; set; }

    public string CmnaPostal { get; set; }

    public string CiudadPostal { get; set; }
  }

  #endregion Receptor

  #region Extranjero

  public class Extranjero {
    public long NumId { get; set; }

    public bool ShouldSerializeNumId() {
      return NumId != 0;
    }

    public string Nacionalidad { get; set; }
  }

  #endregion Extranjero

  
  #region Totales

  public class Totales {
    public long MntNeto { get; set; }

    public bool ShouldSerializeMntNeto() {
      return MntNeto != 0;
    }

    public string TpoMoneda { get; set; }

    public long MntExe { get; set; }

    public bool ShouldSerializeMntExe() {
      return MntExe != 0;
    }

    public long MntBase { get; set; }

    public bool ShouldSerializeMntBase() {
      return MntBase != 0;
    }

    public long MntMargenCom { get; set; }

    public bool ShouldSerializeMntMargenCom() {
      return MntMargenCom != 0;
    }

    public decimal TasaIVA { get; set; }

    public bool ShouldSerializeTasaIVA() {
      return TasaIVA != 0;
    }

    public int IVA { get; set; }

    public bool ShouldSerializeIVA() {
      return IVA != 0;
    }

    public long IVAProp { get; set; }

    public bool ShouldSerializeIVAProp() {
      return IVAProp != 0;
    }

    public long IVATerc { get; set; }

    public bool ShouldSerializeIVATerc() {
      return IVATerc != 0;
    }

    public long IVANoRet { get; set; }

    public bool ShouldSerializeIVANoRet() {
      return IVANoRet != 0;
    }

    public long CredEC { get; set; }

    public bool ShouldSerializeCredEC() {
      return CredEC != 0;
    }

    public long GrntDep { get; set; }

    public bool ShouldSerializeGrntDep() {
      return GrntDep != 0;
    }

    /*Falta clase de Comisiones*/

    [XmlElement("ImptoReten")]
    public List<ImptoReten> ImptoReten { get; set; }

    public bool ShouldSerializeImptoReten() {
      return ImptoReten != null && ImptoReten.Count > 0;
    }

    public long MntTotal { get; set; }

    public long MontoNF { get; set; }

    public bool ShouldSerializeMontoNF() {
      return MontoNF != 0;
    }

    public long MontoPeriodo { get; set; }

    public bool ShouldSerializeMontoPeriodo() {
      return MontoPeriodo != 0;
    }

    public long SaldoAnterior { get; set; }

    public bool ShouldSerializeSaldoAnterior() {
      return SaldoAnterior != 0;
    }

    public long VlrPagar { get; set; }

    public bool ShouldSerializeVlrPagar() {
      return VlrPagar != 0;
    }
  }

  #endregion Totales

  #region SubTotInfo

  public class SubTotInfo {
    public string NroSTI { get; set; }

    public string GlosaSTI { get; set; }

    public string OrdenSTI { get; set; }

    public decimal SubTotNetoSTI { get; set; }

    public bool ShouldSerializeSubTotNetoSTI() {
      return SubTotNetoSTI != 0;
    }

    public decimal SubTotIVASTI { get; set; }

    public bool ShouldSerializeSubTotIVASTI() {
      return SubTotIVASTI != 0;
    }

    public decimal SubTotAdicSTI { get; set; }

    public bool ShouldSerializeSubTotAdicSTI() {
      return SubTotAdicSTI != 0;
    }

    public decimal SubTotExeSTI { get; set; }

    public bool ShouldSerializeSubTotExeSTI() {
      return SubTotExeSTI != 0;
    }

    public decimal ValSubtotSTI { get; set; }

    public bool ShouldSerializeValSubtotSTI() {
      return ValSubtotSTI != 0;
    }

    [XmlElementAttribute("LineasDeta")]
    public List<string> LineasDeta { get; set; }

    public bool ShouldSerializeLineasDeta() {
      return LineasDeta != null && LineasDeta.Count > 0;
    }
  }

  #endregion SubTotInfo

  #region OtraMoneda

  public class OtraMoneda {
    General objGeneral;

    public OtraMoneda() {
      objGeneral = new General();
    }
    public string Validar(bool bolExportacion) {
      StringBuilder stbError = new StringBuilder();
      string strRes;

      //TpoMoneda
      string strNombreVariable = objGeneral.GetVariableName(() => TpoMoneda);
      strRes = objGeneral.Validar(strNombreVariable, false);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      return stbError.ToString();
    }

    public int? TpoMoneda { get; set; }
    
    [XmlElement( DataType = "decimal", ElementName =  "TpoCambio")]
    public decimal TpoCambio { get; set; }

    public bool ShouldSerializeTpoCambio() {
      return TpoCambio != 0;
    }

    public decimal MntNetoOtrMnda { get; set; }

    public bool ShouldSerializeMntNetoOtrMnda() {
      return MntNetoOtrMnda != 0;
    }

    public decimal MntExcOtrMnda { get; set; }

    public bool ShouldSerializeMntExcOtrMnda() {
      return MntExcOtrMnda != 0;
    }

    public decimal MntFaeCarneOtrMnda { get; set; }

    public bool ShouldSerializeMntFaeCarneOtrMnda() {
      return MntFaeCarneOtrMnda != 0;
    }

    public decimal MntMargComOtrMnda { get; set; }

    public bool ShouldSerializeMntMargComOtrMnda() {
      return MntMargComOtrMnda != 0;
    }

    public decimal IVAOtrMnda { get; set; }

    public bool ShouldSerializeIVAOtrMnda() {
      return IVAOtrMnda != 0;
    }

    public List<ImpRetOtrMnda> ImpRetOtrMnda { get; set; }

    public bool ShouldSerializeImpRetOtrMnda() {
      return ImpRetOtrMnda != null && ImpRetOtrMnda.Count > 0;
    }

    public decimal IVANoRetOtrMnda { get; set; }

    public bool ShouldSerializeIVANoRetOtrMnda() {
      return IVANoRetOtrMnda != 0;
    }

    public decimal MntExeOtrMnda { get; set; }

    public bool ShouldSerializeMntExeOtrMnda() {
      return MntExeOtrMnda != 0;
    }

    public decimal MntTotOtrMnda { get; set; }

    public bool ShouldSerializeMntTotOtrMnda() {
      return MntTotOtrMnda != 0;
    }

  }

  #endregion OtraMoneda

  #region Detalle

  public class Detalle {
    General objGeneral;

    public Detalle() {
      objGeneral = new General();
    }
    public string Validar(bool bolExportacion) {
      StringBuilder stbError = new StringBuilder();
      int int80 = 80;
      string strRes;

      //IndExe
      string strNombreVariable = objGeneral.GetVariableName(() => IndExe);
      strRes = objGeneral.Validar(strNombreVariable, false, IndExe != 0 && (IndExe < 1 || IndExe > 6));
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //NmbItem
      strNombreVariable = objGeneral.GetVariableName(() => NmbItem);
      strRes = objGeneral.Validar(NmbItem, strNombreVariable, true, int80, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      //DscItem
      strNombreVariable = objGeneral.GetVariableName(() => DscItem);
      strRes = objGeneral.Validar(DscItem, strNombreVariable, false, int80, bolExportacion);
      if (!string.IsNullOrWhiteSpace(strRes))
        stbError.AppendLine(strRes);

      return stbError.ToString();
    }

    public int NroLinDet { get; set; }

    public bool ShouldSerializeNroLinDet() {
      return NroLinDet != 0;
    }

    [XmlElement("CdgItem")]
    public List<CdgItem> CdgItem { get; set; }

    public bool ShouldSerializeCdgItem() {
      return CdgItem != null && CdgItem.Count > 0;
    }

    public int IndExe { get; set; }

    public bool ShouldSerializeIndExe() {
      return IndExe > 0;
    }

    public Retenedor Retenedor { get; set; }

    public bool ShouldSerializeRetenedor() {
      return Retenedor != null;
    }

    public string NmbItem { get; set; }

    public string DscItem { get; set; }

    public decimal QtyRef { get; set; }

    public bool ShouldSerializeQtyRef() {
      return QtyRef != 0;
    }

    public string UnmdRef { get; set; }

    public decimal PrcRef { get; set; }

    public bool ShouldSerializePrcRef() {
      return PrcRef != 0;
    }

    public decimal QtyItem { get; set; }

    public bool ShouldSerializeQtyItem() {
      return QtyItem != 0;
    }

    public DateTime FchElabor { get; set; }

    public bool ShouldSerializeFchElabor() {
      return FchElabor.Ticks != 0;
    }

    public DateTime FchVencim { get; set; }

    public bool ShouldSerializeFchVencim() {
      return FchVencim.Ticks != 0;
    }

    public string UnmdItem { get; set; }

    public decimal PrcItem { get; set; }

    public bool ShouldSerializePrcItem() {
      return PrcItem != 0;
    }

    public decimal DescuentoPct { get; set; }

    public bool ShouldSerializeDescuentoPct() {
      return DescuentoPct != 0;
    }

    public long DescuentoMonto { get; set; }

    public bool ShouldSerializeDescuentoMonto() {
      return DescuentoMonto != 0;
    }

    public decimal RecargoPct { get; set; }

    public bool ShouldSerializeRecargoPct() {
      return RecargoPct != 0;
    }

    public long RecargoMonto { get; set; }

    public bool ShouldSerializeRecargoMonto() {
      return RecargoMonto != 0;
    }

    [XmlElement("CodImpAdic")]
    public List<int> CodImpAdic { get; set; }

    public bool ShouldSerializeCodImpAdic() {
      return CodImpAdic != null && CodImpAdic.Count > 0;
    }

    public OtrMnda OtrMnda { get; set; }

    public bool ShouldSerializeOtrMnda() {
      return OtrMnda != null;
    }

    public long MontoItem { get; set; }

    [XmlElement("SubDscto")]
    public List<SubDscto> SubDscto { get; set; }

    public bool ShouldSerializeSubDscto() {
      return SubDscto != null && SubDscto.Count > 0;
    }

    [XmlElement("SubRecargo")]
    public List<SubRecargo> SubRecargo { get; set; }

    public bool ShouldSerializeSubRecargo() {
      return SubRecargo != null && SubRecargo.Count > 0;
    }

    [XmlElement("Subcantidad")]
    public List<Subcantidad> Subcantidad { get; set; }

    public bool ShouldSerializeSubcantidad() {
      return Subcantidad != null && Subcantidad.Count > 0;
    }
  }

  [DataContract]
  public class CdgItem {
    [DataMember]
    public string TpoCodigo { get; set; }
    [DataMember]
    public string VlrCodigo { get; set; }
  }

  #endregion Detalle

  #region SubRecargo

  public class SubRecargo {
    public string TipoRecargo { get; set; }

    public decimal ValorRecargo { get; set; }

    public bool ShouldSerializeValorRecargo() {
      return ValorRecargo != 0;
    }
  }

  #endregion SubRecargo

  #region Subcantidad

  public class Subcantidad {
    public decimal SubQty { get; set; }

    public bool ShouldSerializeSubQty() {
      return SubQty != 0;
    }

    public string SubCod { get; set; }
  }

  #endregion Subcantidad

  #region SubDscto

  public class SubDscto {
    public string TipoDscto { get; set; }

    public decimal ValorDscto { get; set; }

    public bool ShouldSerializeValorDscto() {
      return ValorDscto != 0;
    }
  }

  #endregion SubDscto

  #region OtrMnda

  public class OtrMnda {
    public decimal PrcOtrMon { get; set; }

    public bool ShouldSerializePrcOtrMon() {
      return PrcOtrMon != 0;
    }

    public string Moneda { get; set; }

    public decimal FctConv { get; set; }

    public bool ShouldSerializeFctConv() {
      return FctConv != 0;
    }

    public decimal DctoOtrMnda { get; set; }

    public bool ShouldSerializeDctoOtrMnda() {
      return DctoOtrMnda != 0;
    }

    public decimal RecargoOtrMnda { get; set; }

    public bool ShouldSerializeRecargoOtrMnda() {
      return RecargoOtrMnda != 0;
    }

    public decimal MontoItemOtrMnda { get; set; }

    public bool ShouldSerializeMontoItemOtrMnda() {
      return MontoItemOtrMnda != 0;
    }
  }

  #endregion OtrMnda

  #region Retenedor

  public class Retenedor {
    public string IndAgente { get; set; }

    public long MntBaseFaena { get; set; }

    public bool ShouldSerializeMntBaseFaena() {
      return MntBaseFaena != 0;
    }

    public long MntMargComer { get; set; }

    public bool ShouldSerializeMntMargComer() {
      return MntMargComer != 0;
    }

    public long PrcConsFinal { get; set; }

    public bool ShouldSerializePrcConsFinal() {
      return PrcConsFinal != 0;
    }
  }

  #endregion Retenedor

  #region Transporte

  public class Transporte {
    public string Patente { get; set; }

    public string RUTTrans { get; set; }

    public Chofer Chofer { get; set; }

    public bool ShouldSerializeAduana() {
      return Aduana != null;
    }

    public bool ShouldSerializeChofer() {
      return Chofer != null;
    }

    public string CiudadDest { get; set; }

    public string CmnaDest { get; set; }

    public string DirDest { get; set; }

    public Aduana Aduana { get; set; }

  }

  public class Aduana {
    public long CodModVenta { get; set; }

    public bool ShouldSerializeCodModVenta() {
      return CodModVenta != 0;
    }

    public long CodClauVenta { get; set; }

    public bool ShouldSerializeCodClauVenta() {
      return CodClauVenta != 0;
    }

    public decimal TotClauVenta { get; set; }

    public bool ShouldSerializeTotClauVenta() {
      return TotClauVenta != 0;
    }

    public long CodViaTransp { get; set; }

    public bool ShouldSerializeCodViaTransp() {
      return CodViaTransp != 0;
    }

    public string NombreTransp { get; set; }

    public string RUTCiaTransp { get; set; }

    public string NomCiaTransp { get; set; }

    public string IdAdicTransp { get; set; }

    public string Booking { get; set; }

    public string Operador { get; set; }

    public long CodPtoEmbarque { get; set; }

    public bool ShouldSerializeCodPtoEmbarque() {
      return CodPtoEmbarque != 0;
    }

    public string IdAdicPtoEmb { get; set; }

    public long CodPtoDesemb { get; set; }

    public bool ShouldSerializeCodPtoDesemb() {
      return CodPtoDesemb != 0;
    }

    public string IdAdicPtoDesemb { get; set; }

    public long Tara { get; set; }

    public bool ShouldSerializeTara() {
      return Tara != 0;
    }

    public long CodUnidMedTara { get; set; }

    public bool ShouldSerializeCodUnidMedTara() {
      return CodUnidMedTara != 0;
    }

    public decimal PesoBruto { get; set; }

    public bool ShouldSerializePesoBruto() {
      return PesoBruto != 0;
    }

    public long CodUnidPesoBruto { get; set; }

    public bool ShouldSerializeCodUnidPesoBruto() {
      return CodUnidPesoBruto != 0;
    }

    public decimal PesoNeto { get; set; }

    public bool ShouldSerializePesoNeto() {
      return PesoNeto != 0;
    }

    public long CodUnidPesoNeto { get; set; }

    public bool ShouldSerializeCodUnidPesoNeto() {
      return CodUnidPesoNeto != 0;
    }

    public long TotItems { get; set; }

    public bool ShouldSerializeTotItems() {
      return TotItems != 0;
    }

    public long TotBultos { get; set; }

    public bool ShouldSerializeTotBultos() {
      return TotBultos != 0;
    }

    [XmlElement("TipoBultos")]
    public List<TipoBultos> TipoBultos { get; set; }

    public bool ShouldSerializeTipoBultos() {
      return TipoBultos != null && TipoBultos.Count > 0;
    }

    public decimal MntFlete { get; set; }

    public bool ShouldSerializeMntFlete() {
      return MntFlete != 0;
    }

    public decimal MntSeguro { get; set; }

    public bool ShouldSerializeMntSeguro() {
      return MntSeguro != 0;
    }

    public long CodPaisRecep { get; set; }

    public bool ShouldSerializeCodPaisRecep() {
      return CodPaisRecep != 0;
    }

    public long CodPaisDestin { get; set; }

    public bool ShouldSerializeCodPaisDestin() {
      return CodPaisDestin != 0;
    }

  }

  #region TipoBultos

  public class TipoBultos {
    public string CodTpoBultos { get; set; }

    public int CantBultos { get; set; }

    public bool ShouldSerializeCantBultos() {
      return CantBultos != 0;
    }

    public string Marcas { get; set; }

    public string IdContainer { get; set; }

    public string Sello { get; set; }

    public string EmisorSello { get; set; }
  }

  #endregion TipoBultos

  public class Chofer {
    public string RUTChofer { get; set; }

    public string NombreChofer { get; set; }

  }

  #endregion Transporte

  #region Descuentos y Recargo

  public class DscRcgGlobal {
    public long NroLinDR { get; set; }

    public string TpoMov { get; set; }

    public string GlosaDR { get; set; }

    public string TpoValor { get; set; }

    public decimal ValorDR { get; set; }

    public bool ShouldSerializeValorDR() {
      return ValorDR != 0;
    }

    public decimal ValorDROtrMnda { get; set; }

    public bool ShouldSerializeValorDROtrMnda() {
      return ValorDROtrMnda != 0;
    }

    public int IndExeDR { get; set; }

    public bool ShouldSerializeIndExeDR() {
      return IndExeDR > 0;
    }
  }

  #endregion Descuentos y Recargo

  //#region Enumerados DTE

  //public enum Referencia_CodRef {
  //  [XmlEnum("1")]
  //  n1 = 1,
  //  [XmlEnum("2")]
  //  n2 = 2,
  //  [XmlEnum("3")]
  //  n3 = 3,
  //}

  //public enum Retenedor_IndAgente {
  //  [XmlEnum("R")]
  //  R,
  //}

  //[DataContract]
  //public enum DTEType {
  //  [XmlEnum("33")]
  //  [EnumMember]
  //  n33 = 33,
  //  [XmlEnum("34")]
  //  [EnumMember]
  //  n34 = 34,
  //  [XmlEnum("46")]
  //  [EnumMember]
  //  n46 = 46,
  //  [XmlEnum("52")]
  //  [EnumMember]
  //  n52 = 52,
  //  [XmlEnum("56")]
  //  [EnumMember]
  //  n56 = 56,
  //  [XmlEnum("61")]
  //  [EnumMember]
  //  n61 = 61,
  //}

  //public enum Ref_IndGlobal {
  //  [XmlEnum("1")]
  //  n1 = 1,
  //}

  //public enum MedioPagoType {
  //  [XmlEnum("CH")]
  //  CH ,
  //  [XmlEnum("LT")]
  //  LT ,
  //  [XmlEnum("EF")]
  //  EF ,
  //  [XmlEnum("PE")]
  //  PE ,
  //  [XmlEnum("TC")]
  //  TC ,
  //  [XmlEnum("CF")]
  //  CF ,
  //  [XmlEnum("OT")]
  //  OT ,
  //}

  //public enum IdDoc_TpoCtaPago {
  //  [XmlEnum("CT")]
  //  CT ,
  //  [XmlEnum("AH")]
  //  AH ,
  //  [XmlEnum("OT")]
  //  OT ,
  //}

  //public enum IdDoc_TipoDespacho {
  //  /// <summary>
  //  /// Despacho por cuenta del receptor del documento. (cliente o vendedor en caso de facturas de compra)
  //  /// </summary>
  //  [XmlEnum("1")]
  //  DesRec = 1,
  //  /// <summary>
  //  /// Despacho por cuenta del emisor a instalaciones del cliente.
  //  /// </summary>
  //  [XmlEnum("2")]
  //  DesEmi = 2,
  //  /// <summary>
  //  /// Despacho por cuenta del emisor a otras instalaciones. (Ejemplo: Entrega en obra)
  //  /// </summary>
  //  [XmlEnum("3")]
  //  DesEmiOtras = 3,
  //}

  //public enum IdDoc_CdgTraslado {
  //  [XmlEnum("1")]
  //  Item1 = 1,

  //  /// <comentarios/>
  //  [XmlEnum("2")]
  //  Item2 = 2,

  //  /// <comentarios/>
  //  [XmlEnum("3")]
  //  Item3 = 3,

  //  /// <comentarios/>
  //  [XmlEnum("4")]
  //  Item4 = 4,
  //}

  //public enum IdDoc_IndTraslado {
  //  /// <summary>
  //  /// Operación constituye venta
  //  /// </summary>
  //  [XmlEnum("1")]
  //  OperacionConstVenta = 1,
  //  [XmlEnum("2")]
  //  VentasPorEfectuar = 2,
  //  [XmlEnum("3")]
  //  Consignaciones = 3,
  //  [XmlEnum("4")]
  //  EntregaGratuita = 4,
  //  [XmlEnum("5")]
  //  TrasladosInternos = 5,
  //  [XmlEnum("6")]
  //  OtrosTrasladosNoVenta = 6,
  //  [XmlEnum("7")]
  //  GuiaDeDevolucion = 7,
  //  /// <summary>
  //  /// Traslado para exportación. (No venta)
  //  /// </summary>
  //  [XmlEnum("8")]
  //  TrasExp = 8,
  //  [XmlEnum("9")]
  //  VentaExportacion = 9,
  //}
  //public enum IdDoc_IndServicio {
  //  /// <summary>
  //  /// Factura de servicios periódicos domiciliarios.
  //  /// </summary>
  //  [XmlEnum("0")]
  //  FactServPerDom = 0,
  //  /// <summary>
  //  /// Factura de otros servicios periódicos.
  //  /// </summary>
  //  [XmlEnum("1")]
  //  FactOtrosServPer = 1,
  //  /// <summary>
  //  /// En caso de Factura de Exportacion: Servicio calificado como tal por Aduana.
  //  /// </summary>
  //  [XmlEnum("2")]
  //  FacturaDeServicio = 2,
  //}

  //public enum IdDoc_IndNoRebaja {
  //  /// <summary>
  //  /// Nota de crédito sin derecho a descontar débito.
  //  /// </summary>
  //  [XmlEnum("1")]
  //  NCSinDerADescDeb = 1,
  //}

  //public enum IdDoc_FmaPago {
  //  [XmlEnum("1")]
  //  Contado = 1,
  //  [XmlEnum("2")]
  //  Credito = 2,
  //  [XmlEnum("3")]
  //  SinCosto = 3,
  //}

  //public enum IdDoc_TpoImpresion {
  //  [XmlEnum("N")]
  //  N = 0,
  //  [XmlEnum("T")]
  //  T = 1,
  //}

  //public enum TPO_MONEDA : int {
  //  [XmlEnum("13")]
  //  DOLAR_USA = 13,
  //  [XmlEnum("900")]
  //  Otras = 900

  //}

  //public enum ImpAdicDTEType {
  //  [XmlEnum("14")]
  //  n14 = 14,
  //  [XmlEnum("15")]
  //  n15 = 15,
  //  [XmlEnum("16")]
  //  n16 = 16,
  //  [XmlEnum("17")]
  //  n17 = 17,
  //  [XmlEnum("18")]
  //  n18 = 18,
  //  [XmlEnum("19")]
  //  n19 = 19,
  //  [XmlEnum("23")]
  //  n23 = 23,
  //  [XmlEnum("24")]
  //  n24 = 24,
  //  [XmlEnum("25")]
  //  n25 = 25,
  //  [XmlEnum("26")]
  //  n26 = 26,
  //  [XmlEnum("27")]
  //  n27 = 27,
  //  [XmlEnum("28")]
  //  n28 = 28,
  //  [XmlEnum("30")]
  //  n30 = 30,
  //  [XmlEnum("31")]
  //  n31 = 31,
  //  [XmlEnum("32")]
  //  n32 = 32,
  //  [XmlEnum("33")]
  //  n33 = 33,
  //  [XmlEnum("34")]
  //  n34 = 34,
  //  [XmlEnum("35")]
  //  n35 = 35,
  //  [XmlEnum("36")]
  //  n36 = 36,
  //  [XmlEnum("37")]
  //  n37 = 37,
  //  [XmlEnum("38")]
  //  n38 = 38,
  //  [XmlEnum("39")]
  //  n39 = 39,
  //  [XmlEnum("40")]
  //  n40 = 40,
  //  [XmlEnum("41")]
  //  n41 = 41,
  //  [XmlEnum("44")]
  //  n44 = 44,
  //  [XmlEnum("45")]
  //  n45 = 45,
  //  [XmlEnum("46")]
  //  n46 = 46,
  //  [XmlEnum("47")]
  //  n47 = 47,
  //  [XmlEnum("48")]
  //  n48 = 48,
  //  [XmlEnum("49")]
  //  n49 = 49,
  //  [XmlEnum("50")]
  //  n50 = 50,
  //  [XmlEnum("51")]
  //  n51 = 51,
  //  [XmlEnum("52")]
  //  n52 = 52,
  //  [XmlEnum("53")]
  //  n53 = 53,
  //  [XmlEnum("301")]
  //  n301 = 301,
  //  [XmlEnum("321")]
  //  n321 = 321,
  //  [XmlEnum("331")]
  //  n331 = 331,
  //  [XmlEnum("341")]
  //  n341 = 341,
  //  [XmlEnum("361")]
  //  n361 = 361,
  //  [XmlEnum("371")]
  //  n371 = 371,
  //  [XmlEnum("481")]
  //  n481 = 481,
  //}

  //public enum Detalle_IndExe {
  //  /// <summary>
  //  /// No afecto o exento de IVA.
  //  /// </summary>
  //  [XmlEnum("1")]
  //  NoAfecto = 1,
  //  /// <summary>
  //  /// Producto o servicio no es facturable.
  //  /// </summary>
  //  [XmlEnum("2")]
  //  ProdNoFact = 2,
  //  /// <summary>
  //  /// Garantía de depósito por envases. (Cervezas, Jugos, Aguas Minerales, Bebidas Alcohólicas u otros autorizados por Resolución especial)
  //  /// </summary>
  //  [XmlEnum("3")]
  //  GarDepEnv = 3,
  //  /// <summary>
  //  /// Ítem no venta  (Para facturas y guías de despacho (ésta última con Indicador Tipo de Traslado de Bienes igual a 1) y este ítem no será facturado.
  //  /// </summary>
  //  [XmlEnum("4")]
  //  ItemNoVenta = 4,
  //  /// <summary>
  //  /// Ítem a rebajar. Para guías de despacho NO VENTA que rebajan guía anterior. En el área de referencias se debe indicar la guía anterior.
  //  /// </summary>
  //  [XmlEnum("5")]
  //  ItemReb = 5,
  //  /// <summary>
  //  /// Producto o servicio no facturable negativo (excepto en liquidaciones-factura)
  //  /// </summary>
  //  [XmlEnum("6")]
  //  ProdNoFactNeg = 6,
  //}

  //public enum DscRcgGlobal_IndExeDR {
  //  /// <summary>
  //  /// No afecto o exento de IVA
  //  /// </summary>
  //  [XmlEnum("1")]
  //  NoAfecto = 1,
  //  /// <summary>
  //  /// No Facturable
  //  /// </summary>
  //  [XmlEnum("2")]
  //  NoFacturable = 2,
  //}

  //public enum DscRcgGlobal_TpoMov {
  //  [XmlEnum("D")]
  //  D = 0,
  //  [XmlEnum("R")]
  //  R = 1,
  //}

  //public enum DineroPorcentaje {
  //  [XmlEnum("%")]
  //  Percent = 0,
  //  [XmlEnum("$")]
  //  Dinero = 1,
  //}

  //#endregion
}