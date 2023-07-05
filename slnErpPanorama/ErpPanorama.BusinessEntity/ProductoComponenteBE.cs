using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    public class ProductoComponenteBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdProductoComponente { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String DescComponente { get; set; }

        public Int32 IdMaterial { get; set; }
        public String DescMaterial { get; set; }

        public Int32 IdColor { get; set; }
        public String DescColor { get; set; }

        public Int32 cAncho { get; set; }
        public Int32 cLargo { get; set; }
        public Int32 cAlto { get; set; }
        public Int32 cProfundidad { get; set; }
        public Int32 Cantidad { get; set; }

        public Int32 IdUnidadMedida { get; set; }
        public String DescUnidadMedida { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

        #endregion
    }
}
