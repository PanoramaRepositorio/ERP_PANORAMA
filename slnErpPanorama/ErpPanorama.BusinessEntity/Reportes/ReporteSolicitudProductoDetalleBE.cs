using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteSolicitudProductoDetalleBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdSolicitudProducto { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime FechaSolicitud { get; set; }
        [DataMember]
        public String Solicitante { get; set; }
        [DataMember]
        public String DescAlmacen { get; set; }
        [DataMember]
        public String DescTiendaDestino { get; set; }
        [DataMember]
        public String DescAlmacenDestino { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public DateTime FechaEnvio { get; set; }
        [DataMember]
        public Boolean FlagEnviado { get; set; }
        [DataMember]
        public Boolean FlagRecibido { get; set; }
        [DataMember]
        public String NumeroNS { get; set; }


        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Medida { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }


        #endregion
    }
}
