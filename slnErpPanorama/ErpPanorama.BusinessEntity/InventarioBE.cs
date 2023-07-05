using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class InventarioBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdInventario { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public Int32 IdAlmacen { get; set; }
        [DataMember]
        public Int32 IdAlmacenPiso { get; set; }
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
        public String Ubicacion { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public Int32 IdPersona2 { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescAlmacen { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String ApeNom2 { get; set; }
        [DataMember]
        public String DescAlmacenPiso { get; set; }
        



        #endregion
    }
}
