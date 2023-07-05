using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class SolicitudProductoBE
    {
        #region "Atributos"
        
        [DataMember]
        public Int32 IdSolicitudProducto { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime FechaSolicitud { get; set; }
        [DataMember]
        public Int32 IdSolicitante { get; set; }
        [DataMember]
        public Int32 IdAlmacenOrigen { get; set; }
        [DataMember]
        public Int32 IdTiendaDestino { get; set; }
        [DataMember]
        public Int32 IdAlmacenDestino { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public DateTime? FechaEnvio { get; set; }
        [DataMember]
        public Boolean FlagEnviado { get; set; }
        [DataMember]
        public DateTime? FechaRecibido { get; set; }
        [DataMember]
        public Boolean FlagRecibido { get; set; }
        [DataMember]
        public DateTime? FechaPicking { get; set; }
        [DataMember]
        public Boolean PickingNS { get; set; }

        [DataMember]
        public String NumeroNS { get; set; }
        [DataMember]
        public DateTime? FechaDelivery { get; set; }
        

        [DataMember]
        public DateTime? FechaImpresion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdAuxiliar { get; set; }

        [DataMember]
        public Int32 IdTiendaOrigen { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String Solicitante { get; set; }
        [DataMember]
        public String DescAlmacen { get; set; }
        [DataMember]
        public String DescTiendaDestino { get; set; }
        [DataMember]
        public String DescAlmacenDestino { get; set; }
        [DataMember]
        public String DescAuxiliar { get; set; }

        [DataMember]
        public Int32 IdCausalTransferencia { get; set; }
        [DataMember]
        public String DocReferencia { get; set; }
        [DataMember]
        public Int32 IdVendedor { get; set; }

        [DataMember]
        public String Causal { get; set; }

        [DataMember]
        public Int32 SolPendientes { get; set; }
        #endregion

    }
}