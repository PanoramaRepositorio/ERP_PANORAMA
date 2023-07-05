using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoVendedorJuniorSeniorBE
    {
        [DataMember]
        public Int32 IdVendedor { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public decimal TotalCliMin { get; set; }
        [DataMember]
        public decimal TotalCliMay { get; set; }
        [DataMember]
        public decimal TotalRusMin { get; set; }
        [DataMember]
        public decimal TotalRusMay { get; set; }
        [DataMember]
        public decimal TotalRus { get; set; }
        [DataMember]
        public decimal TotalFacEsp { get; set; }
        [DataMember]
        public decimal TotalNotaCre { get; set; }
        [DataMember]
        public Int32 CanRegCliente { get; set; }
        [DataMember]
        public Int32 CanVentaIntermediaria { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public Int32 IdCargo { get; set; }
        [DataMember]
        public String Cargo { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public decimal Meta { get; set; }
        [DataMember]
        public decimal TotalCliMinSIGV { get; set; }
        [DataMember]
        public decimal TotalCliMaySIGV { get; set; }
        [DataMember]
        public decimal TotalRusSIGV { get; set; }
        [DataMember]
        public decimal TotalFacEspSIGV { get; set; }
        [DataMember]
        public decimal TotalVenta { get; set; }
        [DataMember]
        public decimal TotalVentaIncentivado { get; set; }
        [DataMember]
        public decimal TotalCompraPerfecta { get; set; }
        [DataMember]
        public decimal PorMeta { get; set; }
        [DataMember]
        public decimal Basico { get; set; }
        [DataMember]
        public decimal RusSueldo { get; set; }
        [DataMember]
        public decimal BonoVenta { get; set; }
        [DataMember]
        public decimal BonoVentaIntermediaria { get; set; }
        [DataMember]
        public decimal RegCliSueldo { get; set; }
        [DataMember]
        public decimal BonoMeta { get; set; }
        [DataMember]
        public decimal Sbruto { get; set; }
        [DataMember]
        public decimal SubVencion { get; set; }

        [DataMember]
        public decimal Promocion { get; set; }
        [DataMember]
        public decimal Asesoria { get; set; }
        [DataMember]
        public decimal ComisionPromocion { get; set; }
        [DataMember]
        public decimal ComisionAsesoria { get; set; }
        [DataMember]
        public decimal TotalVentaNeta { get; set; }
        [DataMember]
        public decimal ComisionVentaNeta { get; set; }
        [DataMember]
        public decimal ComisionIncentivado { get; set; }
        [DataMember]
        public decimal ComisionCompraPerfecta { get; set; }
        [DataMember]
        public decimal TotalComision { get; set; }
        
    }
}
