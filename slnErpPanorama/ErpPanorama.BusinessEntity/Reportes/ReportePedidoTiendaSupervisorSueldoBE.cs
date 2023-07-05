using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoTiendaSupervisorSueldoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 Tipo { get; set; }
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
        public String DescTienda { get; set; }
        [DataMember]
        public Decimal TotalClienteFinal { get; set; }
        [DataMember]
        public Decimal TotalClienteMayorista { get; set; }
        [DataMember]
        public Decimal TotalVenta { get; set; }
        [DataMember]
        public Decimal Meta { get; set; }
        [DataMember]
        public Decimal PorMeta { get; set; }
        [DataMember]
        public Decimal BonoMetaTienda { get; set; }
        [DataMember]
        public Boolean FlaCobro { get; set; }
        [DataMember]
        public String DetalleCobro { get; set; }
        [DataMember]
        public Int32 DiaAlcanceMetaTienda { get; set; }
        [DataMember]
        public Decimal Conversion { get; set; }
        [DataMember]
        public Decimal BonoConversion { get; set; }
        [DataMember]
        public Decimal Basico { get; set; }
        [DataMember]
        public Decimal ComisionBasica { get; set; }
        [DataMember]
        public Decimal BonoGestion { get; set; }
        [DataMember]
        public Decimal Sueldo { get; set; }
        #endregion
    }
}
