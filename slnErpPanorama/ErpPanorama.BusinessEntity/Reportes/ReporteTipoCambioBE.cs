using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteTipoCambioBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdTipoCambio { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Decimal Compra { get; set; }
        [DataMember]
        public Decimal Venta { get; set; }

        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String Moneda { get; set; }
        #endregion
    }
}
