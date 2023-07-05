using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteCajaVaciaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCajaVacia { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public DateTime FechaIngreso { get; set; }
        [DataMember]
        public DateTime FechaSalida { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdUbicacion { get; set; }
        [DataMember]
        public String DescUbicacion { get; set; }
        [DataMember]
        public Int32 IdPiso { get; set; }
        [DataMember]
        public String DescPiso { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        #endregion
    }
}


