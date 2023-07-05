using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class EscalaMayoristaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdEscalaMayorista { get; set; }
        [DataMember]
        public Int32 IdEscalaMayoristaPreVenta { get; set; }
        [DataMember]
        public Int32 IdFamiliaProducto { get; set; }
        [DataMember]
        public String DescFamiliaProducto { get; set; }
        [DataMember]
        public Int32 IdFormaPago { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public Decimal Precio_Del { get; set; }
        [DataMember]
        public Decimal Precio_Al { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public Boolean General { get; set; }
        [DataMember]
        public Int32 IdUsuario { get; set; }
        [DataMember]
        public Int32 IdUsuarioRegistro { get; set; }
        [DataMember]
        public Int32 IdUsuarioModificacion { get; set; }
        [DataMember]
        public String DescUsuarioRegistro { get; set; }
        [DataMember]
        public String DescUsuarioModificacion { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
        public DateTime FechaModificacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        #endregion
    }
}
