using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class Dis_ContratoFabricacionDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdDis_ContratoFabricacionDetalle { get; set; }
        [DataMember]
        public Int32 IdDis_ContratoFabricacion { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public Int32 IdUnidadMedida { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public String Modelo { get; set; }
        [DataMember]
        public String Medida { get; set; }
        [DataMember]
        public String Material { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal Precio { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }

        [DataMember]
        public Decimal ValorVenta { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        [DataMember]
        public Boolean FlagObsequio { get; set; }

        [DataMember]
        public Boolean FlagModificado { get; set; }
        [DataMember]
        public Boolean FlagAprobado { get; set; }
        [DataMember]
        public Int32 DiasProduccion { get; set; }
        [DataMember]
        public DateTime? FechaEntrega { get; set; }

        [DataMember]
        public byte[] Imagen { get; set; }

        #endregion
    }
}
