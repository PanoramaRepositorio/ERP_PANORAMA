using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoContadoBE
    {
        [DataMember]
        public String Ruc { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public Int32 IdPedido { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescCampana { get; set; }
        [DataMember]
        public String Serie { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String NumeroDocumentoAsociado { get; set; }
        [DataMember]
        public String DescClienteAsociado { get; set; }
        [DataMember]
        public String DireccionAsociado { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String DescMotivo { get; set; }
        [DataMember]
        public Int32 TotalCantidad { get; set; }
        [DataMember]
        public String Despachar { get; set; }
        [DataMember]
        public String Observaciones { get; set; }
        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Int32 CantidadAnterior { get; set; }
        [DataMember]
        public Int32 CantidadChequeo { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public String UbicacionUcayali { get; set; }
        [DataMember]
        public String UbicacionAndahuaylas { get; set; }
        [DataMember]
        public String UbicacionAviacion { get; set; }
        [DataMember]
        public String UbicacionPrescott { get; set; }
        [DataMember]
        public String UbicacionSanMiguel { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String DescTipoVenta { get; set; }
        [DataMember]
        public String DescTipoCliente { get; set; }
        [DataMember]
        public String DescPersonaAprueba { get; set; }
        [DataMember]
        public String DescPersonaPicking { get; set; }
        [DataMember]
        public String DescPersonaChequeo { get; set; }
        [DataMember]
        public String DescPersonaEmabalaje { get; set; }
        [DataMember]
        public Int32 CantidadBulto { get; set; }
        [DataMember]
        public byte[] CodigoBarraNumero { get; set; }
        [DataMember]
        public String DescAlmacen { get; set; }
        [DataMember]
        public Int32 NumeroModificacion { get; set; }
        [DataMember]
        public DateTime FechaDelivery { get; set; }
        

    }
}
