using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    public class FacturaCompraGastoBE
    {
        [DataMember]
        public Int32 IdFacturaCompraGasto { get; set; }
        [DataMember]
        public Int32 IdFacturaCompra { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdTipoGasto { get; set; }
        [DataMember]
         public Int32 IdMoneda { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public String DescTipoGasto { get; set; }
        [DataMember]
        public String Moneda { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
    }
}

