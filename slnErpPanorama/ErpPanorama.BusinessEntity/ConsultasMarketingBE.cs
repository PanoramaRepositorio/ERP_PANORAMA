using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ConsultasMarketingBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 Tickets { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String Tienda { get; set; }
        [DataMember]
        public String TipoCliente { get; set; }
        [DataMember]
        public String Nombres { get; set; }
        [DataMember]
        public String ApeMaterno { get; set; }
        [DataMember]
        public String ApePaterno { get; set; }
        [DataMember]
        public String Cliente { get; set; }
        [DataMember]
        public String Distrito { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public DateTime? FechaNac { get; set; }
        [DataMember]
        public String TipoPersona { get; set; }
        [DataMember]
        public String Celular { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public Decimal? TotalSoles { get; set; }
        [DataMember]
        public String AbrevDocumento { get; set; }
        [DataMember]
        public String OtroTelefono { get; set; }
        [DataMember]
        public String EmailAdicional { get; set; }
        [DataMember]
        public String Encuesta { get; set; }
        [DataMember]
        public DateTime? FechaRegistro { get; set; }
        [DataMember]
        public DateTime? FechaActualizacion { get; set; }
        [DataMember]
        public String Registro { get; set; }
        //******Productos Compras************
        [DataMember]
        public int IdProducto { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String LineaProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal ValorVenta { get; set; }

        [DataMember]
        public String Referido { get; set; }
        [DataMember]
        public String NumeroPedido { get; set; }
        [DataMember]
        public String Concepto { get; set; }
        [DataMember]
        public String Compro { get; set; }
        [DataMember]
        public String DescTienda { get; set; }


        #endregion
    }
}
