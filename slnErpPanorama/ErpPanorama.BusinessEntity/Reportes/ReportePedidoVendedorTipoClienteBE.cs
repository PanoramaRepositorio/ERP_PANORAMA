using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoVendedorTipoClienteBE
    {
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public Int32 IdUbigeoDom { get; set; }
        [DataMember]
        public String NomDpto { get; set; }
        [DataMember]
        public String NomProv { get; set; }
        [DataMember]
        public String NomDist { get; set; }
        [DataMember]
        public Decimal TotalSoles { get; set; }

        [DataMember]
        public String TipoDoc { get; set; }
        [DataMember]
        public String Serie { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String NumeroServicio { get; set; }
        [DataMember]
        public String NumeroCFabricacion { get; set; }
        [DataMember]
        public DateTime FecDoc { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
    }

    public class ReporteAvanceMeta
    {
        [DataMember]
        public Int32 IdVendedor { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public Int32 IdCargo { get; set; }
        [DataMember]
        public String Cargo { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public Decimal Cliente_Final { get; set; }
        [DataMember]
        public Decimal Cliente_Mayorista { get; set; }
        [DataMember]
        public Decimal Cliente_Diseño { get; set; }
        [DataMember]
        public Decimal VentaTotalPagada { get; set; }
        [DataMember]
        public Decimal Meta { get; set; }
        [DataMember]
        public Decimal BonificacionBasica { get; set; }
        [DataMember]
        public Decimal PorcBonificacionBasica { get; set; }
        [DataMember]
        public Decimal ExtraBonificacion { get; set; }
        [DataMember]
        public Decimal CantidadExtra { get; set; }
        [DataMember]
        public Decimal TotalNC { get; set; }
        [DataMember]
        public Decimal BonoMeta { get; set; }
        [DataMember]
        public Decimal TotalCreditos { get; set; }

        [DataMember]
        public Decimal RutaPropiag { get; set; }
        [DataMember]
        public Decimal RutaTercerosg { get; set; }
        [DataMember]
        public Decimal RutaPropiap { get; set; }
        [DataMember]
        public Decimal RutaTercerosp { get; set; }

        [DataMember]
        public int RegClientes { get; set; }
        [DataMember]
        public String FechaCese { get; set; }

        [DataMember]
        public Decimal PFinal { get; set; }
        [DataMember]
        public Decimal PMayor { get; set; }
        [DataMember]
        public Decimal PFabrica { get; set; }

        [DataMember]
        public Decimal BFinal { get; set; }
        [DataMember]
        public Decimal BMayor { get; set; }
        [DataMember]
        public Decimal BFabrica { get; set; }

        [DataMember]
        public DateTime FechaIngreso { get; set; }

        [DataMember]
        public int DiasIngreso { get; set; }
    }

    public class ReporteSueldoAdmUcayali
    {
        [DataMember]
        public String Tienda { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String Cargo { get; set; }
        [DataMember]
        public Decimal Meta { get; set; }
        [DataMember]
        public Decimal SueldoBasico { get; set; }
        [DataMember]
        public Decimal VentaTotal { get; set; }
        [DataMember]
        public Decimal CMayorista { get; set; }
        [DataMember]
        public Decimal CDiseño { get; set; }
        [DataMember]
        public Decimal VentaTotalPagada { get; set; }
        [DataMember]
        public decimal TasaConversion { get; set; }
        [DataMember]
        public Decimal BonificacionBasica { get; set; }
        [DataMember]
        public Decimal PorcBonificacionBasica { get; set; }
        [DataMember]
        public Decimal ExtraBonificacion { get; set; }
        [DataMember]
        public Decimal CantidadExtra { get; set; }
        [DataMember]
        public Decimal BonoMeta { get; set; }
        [DataMember]
        public DateTime FechaIngreso { get; set; }
    }

}
