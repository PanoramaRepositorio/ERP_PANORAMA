using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class SolicitudEgresoDetalleBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdSolicitudEgreso { get; set; }
        [DataMember]
        public Int32 IdSolicitudEgresoDetalle { get; set; }

 


        [DataMember]
        public Int32 NumeroAbono { get; set; }
        [DataMember]
        public DateTime? FechaPagoSolicitada { get; set; }

        [DataMember]
        public DateTime FechaPagoSolicitada2 { get; set; }

        [DataMember]
        public DateTime? FechaPagoSolicitada3 { get; set; }

        [DataMember]
        public Decimal MontoAbono { get; set; }
        [DataMember]
        public DateTime? FechaDeposito { get; set; }
        [DataMember]
        public DateTime FechaDeposito2 { get; set; }
        [DataMember]
        public DateTime? FechaIngresoAlmacen { get; set; }
        [DataMember]
        public DateTime FechaIngresoAlmacen2 { get; set; }

        [DataMember]
        public DateTime? FechaRecepcionFactura { get; set; }
        [DataMember]
        public DateTime FechaRecepcionFactura2 { get; set; }


        [DataMember]
        public String NumeroFactura { get; set; }
        [DataMember]
        public Decimal MontoFactura { get; set; }
        [DataMember]
        public DateTime? FechaEmisionFactura { get; set; }
        [DataMember]
        public DateTime FechaEmisionFactura2 { get; set; }
        [DataMember]
        public String RutaArchivo { get; set; }

        [DataMember]
        public String fname { get; set; }
        [DataMember]
        public String tipo { get; set; }
        [DataMember]
        public byte[] fcontent { get; set; }

        [DataMember]
        public Boolean FlagEstado { get; set; }


        [DataMember]
        public Int32 TipoOper { get; set; }

        [DataMember]
        public String Usuario { get; set; }

        [DataMember]
        public int TipDocumento { get; set; }

        [DataMember]
        public String DescTipDocumento { get; set; }

        [DataMember]
        public String Serie { get; set; }
        #endregion
    }
}
