using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteMovimientoAlmacenChequeoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String Referencia { get; set; }
        [DataMember]
        public String Observaciones { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public String DescAlmacen { get; set; }
        [DataMember]
        public String DescMotivo { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String DescAlmacenDestino { get; set; }

        [DataMember]
        public Int32 CantidadChequeo { get; set; }
        [DataMember]
        public DateTime FechaChequeo { get; set; }
        [DataMember]
        public Boolean FlagRecibido { get; set; }

        [DataMember]
        public String DescPicking { get; set; }
        [DataMember]
        public String DescChequeador { get; set; }
        [DataMember]
        public String DescEmbalador { get; set; }
        [DataMember]
        public Int32 CantidadBulto { get; set; }
        [DataMember]
        public byte[] CodigoBarraNumero { get; set; }

        #endregion
    }
}
