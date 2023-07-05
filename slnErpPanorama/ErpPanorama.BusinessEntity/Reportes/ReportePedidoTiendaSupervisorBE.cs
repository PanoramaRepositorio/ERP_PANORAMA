using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoTiendaSupervisorBE
    {
        [DataMember]
        public Int32 IdVendedor { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
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
        public Int32 CanRegCliente { get; set; }
        [DataMember]
        public decimal TotalVentaSupervisor { get; set; }
        [DataMember]
        public decimal TotalVentaIncentivado { get; set; }
        [DataMember]
        public decimal TotalCompraPerfecta { get; set; }
        [DataMember]
        public decimal TotalVenta { get; set; }
        [DataMember]
        public decimal TotalVentaSinIGV { get; set; }
        [DataMember]
        public decimal PorMeta { get; set; }

        [DataMember]
        public decimal TasaConversion { get; set; }
        [DataMember]
        public decimal MetaConversion { get; set; }
        [DataMember]
        public decimal PorConversion { get; set; }
        [DataMember]
        public decimal BonoConversion { get; set; }
        [DataMember]
        public decimal BonoMeta { get; set; }
        [DataMember]
        public decimal Basico { get; set; }
        [DataMember]
        public decimal AlcanceJunior { get; set; }
        [DataMember]
        public decimal AlcanceSenior { get; set; }
        [DataMember]
        public decimal AlcanceMaster { get; set; }
        [DataMember]
        public decimal ComisionMaster { get; set; }
        [DataMember]
        public decimal ComisionSenior { get; set; }
        [DataMember]
        public decimal ComisionJunior { get; set; }
        [DataMember]
        public decimal ComisionSupervisor { get; set; }
        [DataMember]
        public decimal ComisionIncentivado { get; set; }
        [DataMember]
        public decimal ComisionCompraPerfecta { get; set; }
        [DataMember]
        public decimal RegCliSueldo { get; set; }
        [DataMember]
        public decimal ComisionTotal { get; set; }
        [DataMember]
        public decimal Sueldo { get; set; }

        [DataMember]
        public decimal TotalClienteFinal { get; set; }
        [DataMember]
        public decimal TotalClienteMayorista { get; set; }

        [DataMember]
        public Int32 Faltas { get; set; }
        [DataMember]
        public Int32 Tardanzas { get; set; }
        [DataMember]
        public bool FlagIndisciplina { get; set; }
        

    }
}
