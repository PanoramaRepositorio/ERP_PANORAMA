using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class CambioDetalleBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdCambioDetalle { get; set; }
        [DataMember]
        public Int32 IdCambio { get; set; }
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
        public Decimal PrecioUnitario { get; set; }
        [DataMember]
        public Decimal PorcentajeDescuento { get; set; }
        [DataMember]
        public Decimal PrecioVenta { get; set; }
        [DataMember]
        public Decimal ValorVenta { get; set; }
        [DataMember]
        public String CodAfeIGV { get; set; }
        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public Decimal PrecioUnitarioPedido { get; set; }
        [DataMember]
        public Decimal PrecioVentaPedido { get; set; }
        [DataMember]
        public Decimal ValorVentaSoles { get; set; }
        [DataMember]
        public Decimal ValorVentaDolares { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String Observacion { get; set; }

        [DataMember]
        public Int32 TipoOper { get; set; }
        [DataMember]
        public Int32 IdMarca { get; set; }
        [DataMember]
        public String DescPromocion { get; set; }

        #endregion
    }
}
