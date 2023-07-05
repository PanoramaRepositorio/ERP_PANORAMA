using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteGuiaRemisionBE
    {
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdGuiaRemision { get; set; }
        [DataMember]
        public String RazonSocialRemitente { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String Serie { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Int32 IdTiendaRemitente { get; set; }
        [DataMember]
        public String TiendaRemitente { get; set; }
        [DataMember]
        public String DireccionRemitente { get; set; }
        [DataMember]
        public Int32 IdEmpresaDestinatario { get; set; }
        [DataMember]
        public String RazonSocialDestinatario { get; set; }
        [DataMember]
        public Int32 IdTiendaDestinatario { get; set; }
        [DataMember]
        public String TiendaDestinatario { get; set; }
        [DataMember]
        public String DireccionDestinatario { get; set; }
        [DataMember]
        public String DescTransportista { get; set; }
        [DataMember]
        public String RucTransportista { get; set; }
        [DataMember]
        public String NumeroLicencia { get; set; }
        [DataMember]
        public String DescVehiculo { get; set; }
        [DataMember]
        public String NumeroPlaca { get; set; }
        [DataMember]
        public Int32 IdTipoDocumentoReferencia { get; set; }
        [DataMember]
        public String CodTipoDocumentoReferencia { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public Int32 IdMotivo { get; set; }
        [DataMember]
        public String DescMotivo { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal CostoUnitario { get; set; }
        [DataMember]
        public Decimal MontoTotal { get; set; }
    }
}
