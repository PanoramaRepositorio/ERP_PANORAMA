using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    public class UbicacionesBE
    {
        #region "Atributos"
        [DataMember]
        public string NumeroBulto { get; set; }
        [DataMember]
        public string Almacen { get; set; }
        [DataMember]
        public string Sector { get; set; }
        [DataMember]
        public string Bloque { get; set; }
        [DataMember]
        public string Linea { get; set; }
        [DataMember]
        public string Sublinea { get; set; }
        [DataMember]
        public string Hangtag { get; set; }
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string Abreviatura { get; set; }

        [DataMember]
        public int Stock { get; set; }

        [DataMember]
        public string Situacion { get; set; }
        [DataMember]
        public string Observacion { get; set; }

        [DataMember]
        public DateTimeOffset? FecInventario { get; set; }
        [DataMember]
        public DateTimeOffset? FechaRecepcion { get; set; }
        [DataMember]
        public string Ubicacion { get; set; }
        #endregion

    }
}
