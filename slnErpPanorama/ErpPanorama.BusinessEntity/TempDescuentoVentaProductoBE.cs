using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class TempDescuentoVentaProductoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdTempDescuentoVentaProducto { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public Decimal PrecioVenta { get; set; }
        [DataMember]
        public Decimal DescuentoAnterior { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public String Operacion { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String UsuarioAutoriza { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }

        [DataMember]
        public Int32 IdPedido { get; set; }
        [DataMember]
        public Decimal PrecioUnitario { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String Motivo { get; set; }
        


        #endregion
    }
}
