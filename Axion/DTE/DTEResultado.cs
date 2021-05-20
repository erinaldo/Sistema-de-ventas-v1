using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTE.LibroGuia;
using DTE.LibroCV;
using DTE;
using Cesion;


namespace DTE {

  public class DatosAdicionales {
    public string Campo { get; set; }
    public string Valor { get; set; }
  }

  public class ParamCesion {
    public DTECedido DTECedido { get; set; }
    public Cesion.Cesion Cesion { get; set; }

    public bool AmbienteProduccion { get; set; }

    public string NmbContacto { get; set; }
    public string FonoContacto { get; set; }
    public string MailContacto { get; set; }

    public string XMLDTE { get; set; }
  }


  public class ParamDTE {
    public DTE DTE { get; set; }

    public bool AmbienteProduccion { get; set; }

    public DateTime FechaResolucion { get; set; }

    public int NroResolucion { get; set; }
    public string XMLTED { get; set; }

    public List<DatosAdicionales> ListaDatosAdicionales { get; set; }

  }


  public class ParamDTEXml {
    public string XML { get; set; }
    public string XMLTED { get; set; }
    public bool AmbienteProduccion { get; set; }
    public DateTime FechaResolucion { get; set; }
    public int NroResolucion { get; set; }
  }
  
  public class ParamLibroGuia {
    public EnvioLibroGuia Libro { get; set; }
    public bool AmbienteProduccion { get; set; }
    public DateTime FechaResolucion { get; set; }
    public int NroResolucion { get; set; }
    public DateTime PeriodoTributario { get; set; }
    public int RutEmisor { get; set; }
  }

  public class ParamLibroCV {
    public EnvioLibro Libro { get; set; }
    public bool AmbienteProduccion { get; set; }
    public DateTime FechaResolucion { get; set; }
    public int NroResolucion { get; set; }
    public DateTime PeriodoTributario { get; set; }
    public string RutEmisor { get; set; }
  }

}
