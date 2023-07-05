using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoVendedorCajaBE
    {
        #region "Atributos"
        
        [DataMember]
        public Int32 IdVendedor { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public Int32 IdCargo { get; set; }
        [DataMember]
        public String Cargo { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public Int32 CanRegCliente { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public decimal TotalPedido { get; set; }
        [DataMember]
        public decimal TotalAutoservicio { get; set; }
        [DataMember]
        public decimal TotalRus { get; set; }
        [DataMember]
        public decimal TotalRusOtros { get; set; }
        [DataMember]
        public decimal TotalVenta { get; set; }
        [DataMember]
        public decimal Basico { get; set; }
        [DataMember]
        public decimal Meta { get; set; }
        [DataMember]
        public decimal AlcanceMeta { get; set; }
        [DataMember]
        public decimal BonoMeta { get; set; }

        [DataMember]
        public decimal ComisionRegCliente { get; set; }
        [DataMember]
        public decimal ComisionAutoservicio { get; set; }
        [DataMember]
        public decimal ComisionPedido { get; set; }
        [DataMember]
        public decimal ComisionRus { get; set; }
        [DataMember]
        public decimal ComisionRusOtros { get; set; }
        [DataMember]
        public decimal Sueldo { get; set; }

        [DataMember]
        public decimal TotalRusSinIGV { get; set; }
        [DataMember]
        public decimal TotalRusOtrosSinIGV { get; set; }
        [DataMember]
        public decimal ComisionVenta { get; set; }
        [DataMember]
        public decimal TotalVentaSinIGV { get; set; }



        #endregion
    }
}
