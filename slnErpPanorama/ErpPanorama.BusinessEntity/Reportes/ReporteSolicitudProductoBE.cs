using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteSolicitudProductoBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdSolicitudProducto { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public String Documento { get; set; }
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
        public DateTime FechaEnvio { get; set; }
        [DataMember]
        public DateTime FechaImpresion { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Int32 IdSolicitudProductoDetalle { get; set; }
        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public String UbicacionUcayali { get; set; }
        [DataMember]
        public String UbicacionAndahuaylas { get; set; }
        [DataMember]
        public Int32 CantidadBulto { get; set; }
        [DataMember]
        public String ObservacionDetalle { get; set; }
        [DataMember]
        public Byte[] CodigoBarraNumero { get; set; }
        [DataMember]
        public String NumerosBultos { get; set; }
        [DataMember]
        public String DesCausalTransferencia { get; set; }
        [DataMember]
        public String DocumentoReferencia { get; set; }
        #endregion
    }
}
