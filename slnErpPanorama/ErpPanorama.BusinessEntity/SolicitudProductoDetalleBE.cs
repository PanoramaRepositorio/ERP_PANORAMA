using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class SolicitudProductoDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdSolicitudProductoDetalle { get; set; }
        [DataMember]
        public Int32 IdSolicitudProducto { get; set; }
        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Decimal CostoUnitario { get; set; }
        [DataMember]
        public Decimal MontoTotal { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public DateTime FechaSolicitud { get; set; }
        [DataMember]
        public DateTime FechaImpresion { get; set; }
        [DataMember]
        public Int32 IdAlmacenOrigen { get; set; }
        [DataMember]
        public Int32 IdAlmacenDestino { get; set; }
        [DataMember]
        public Int32 IdSolicitante { get; set; }
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
        public byte[] Imagen { get; set; }
        [DataMember]
        public String DescUbicacion { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        [DataMember]
        public Int32? IdAuxiliar { get; set; }

        [DataMember]
        public String DocReferencia { get; set; }
        [DataMember]
        public Int32 IdCausalTransferencia { get; set; }
        [DataMember]
        public Int32 IdVendedor { get; set; }
        #endregion
    }
}