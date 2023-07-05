using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteTarjetaIziPayBE
    {
        #region "Atributos"
        public String DescTienda { get; set; }
        [DataMember]
        public String DescCaja { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String DescCondicionPago { get; set; }
        [DataMember]
        public Int32 IdCondicionPago { get; set; }
        [DataMember]
        public String TipoTarjeta { get; set; }
        [DataMember]
        public Decimal ImporteSoles { get; set; }
        [DataMember]
        public Decimal Comision { get; set; }
        [DataMember]
        public Decimal IGV { get; set; }
        [DataMember]
        public Decimal PorCobrar { get; set; }
        #endregion
    }
}

