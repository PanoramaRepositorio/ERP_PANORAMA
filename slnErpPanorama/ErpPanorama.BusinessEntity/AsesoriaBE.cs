using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class AsesoriaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32? IdAsesoria { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32? IdPedido { get; set; }
        [DataMember]
        public DateTime? Fecha { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String DescAsesor { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public String Situacion { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public String FormaPago { get; set; }
        [DataMember]
        public DateTime? FechaContrato { get; set; }
        [DataMember]
        public DateTime? FechaVenta { get; set; }
        [DataMember]
        public DateTime? FechaVisita { get; set; }
        [DataMember]
        public DateTime? FechaEntrega { get; set; }
        [DataMember]
        public String Observacion { get; set; }

        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public Int32 IdAsesor { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }


        #endregion
    }
}
