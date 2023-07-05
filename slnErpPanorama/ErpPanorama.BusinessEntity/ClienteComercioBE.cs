using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ClienteComercioBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdComercio { get; set; }

        [DataMember]
        public Int32 IdEmpresa { get; set; }

        [DataMember]
        public Int32 IdTienda { get; set; }

        [DataMember]
        public Int32 Periodo { get; set; }

        [DataMember]
        public Int32 Mes { get; set; }

        [DataMember]
        public Int32? IdDocumentoVenta { get; set; }

        [DataMember]
        public DateTime? Fecdoc { get; set; }

        [DataMember]
        public Int32? IdPedido { get; set; }

        [DataMember]
        public Int32 IdCliente { get; set; }

        [DataMember]
        public Int32 IdTipodocumento { get; set; }

        [DataMember]
        public String NumeroDocumento { get; set; }

        [DataMember]
        public String DescCliente { get; set; }

        [DataMember]
        public Int32 IdMoneda { get; set; }

        [DataMember]
        public Int32 IdFormaPago { get; set; }

        [DataMember]
        public Decimal Total { get; set; }

        [DataMember]
        public Int32 IdSituacion { get; set; }


        #endregion
    }
}
