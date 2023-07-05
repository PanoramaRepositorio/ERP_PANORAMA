using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class DocumentoVentaPagoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdDocumentoVentaPago { get; set; }
        [DataMember]
        public Int32 IdDocumentoVenta { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public Int32 IdCondicionPago { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public Decimal TipoCambio { get; set; }

        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public Int32? IdEstadoCuentaCliente { get; set; }
        [DataMember]
        public String GrupoPago { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String DescCondicionPago { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        #endregion
    }
}
