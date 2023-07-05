using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoVendedorAsesoriaBE
    {
        [DataMember]
        public Int32 IdVendedor { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public Int32 IdCargo { get; set; }
        [DataMember]
        public String DescCargo { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }

        [DataMember]
        public decimal TotalClienteFinal { get; set; }
        [DataMember]
        public decimal TotalClienteMayorista { get; set; }
        [DataMember]
        public decimal TotalClienteDiseno { get; set; }
        [DataMember]
        public decimal TotalClienteFinalSinIGV { get; set; }
        [DataMember]
        public decimal TotalClienteMayoristaSinIGV { get; set; }
        [DataMember]
        public decimal TotalClienteDisenoSinIGV { get; set; }
        [DataMember]
        public decimal TotalProyectoFactura { get; set; }
        [DataMember]
        public decimal TotalProyectoFacturaSinIGV { get; set; }
        [DataMember]
        public decimal TotalVenta { get; set; }
        [DataMember]
        public decimal Basico { get; set; }
        [DataMember]
        public Int32 CantidadCliente { get; set; }
        [DataMember]
        public decimal ComisionCliente { get; set; }
        [DataMember]
        public decimal ComisionFinal { get; set; }
        [DataMember]
        public decimal ComisionMayorista { get; set; }
        [DataMember]
        public decimal ComisionDiseno { get; set; }
        [DataMember]
        public decimal ComisionExtra { get; set; }
        [DataMember]
        public decimal Meta { get; set; }
        [DataMember]
        public decimal AlcanceMeta { get; set; }
        [DataMember]
        public decimal BonoMeta { get; set; }
        [DataMember]
        public decimal BonoItem { get; set; }

        [DataMember]
        public decimal ComisionFinalDM { get; set; }
        [DataMember]
        public decimal ComisionMayoristaDM { get; set; }
        [DataMember]
        public decimal ComisionFinalDM5 { get; set; }
        [DataMember]
        public decimal ComisionMayoristaDM5 { get; set; }
        [DataMember]
        public decimal BonoProyectoFactura { get; set; }
        [DataMember]
        public decimal BonoProyectoInstala { get; set; }
        [DataMember]
        public decimal DescuentoFalta { get; set; }
        [DataMember]
        public decimal DescuentoTardanza { get; set; }
        [DataMember]
        public decimal DescuentoReclamo { get; set; }
        [DataMember]
        public decimal DescuentoMemo { get; set; }
        [DataMember]
        public Boolean FlagIndisciplina { get; set; }
        [DataMember]
        public decimal SueldoBruto { get; set; }

    }
}
