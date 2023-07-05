using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace ErpPanorama.BusinessEntity
{
    public class ReportePedidoRutaSemanaBE
    {
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public String Semana { get; set; }
        [DataMember]
        public Decimal Ruta10 { get; set; }
        [DataMember]
        public Decimal Ruta20 { get; set; }
        [DataMember]
        public Decimal Ruta30 { get; set; }
        [DataMember]
        public Decimal Ruta40 { get; set; }
        [DataMember]
        public Decimal Ruta50 { get; set; }
        [DataMember]
        public Decimal Ruta60 { get; set; }
        [DataMember]
        public Decimal Ruta70 { get; set; }
        [DataMember]
        public Decimal Ruta80 { get; set; }
        [DataMember]
        public Decimal Ruta90 { get; set; }
        [DataMember]
        public Decimal Ruta100 { get; set; }

    }
}
