using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteTalonBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdTalon { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdCaja { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public Int32 IdTipoFormato { get; set; }
        [DataMember]
        public String NumeroSerie { get; set; }
        [DataMember]
        public String NumeroAutoriza { get; set; }
        [DataMember]
        public String SerieImpresora { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String DescCaja { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String DescTipoFormato { get; set; }
        #endregion
    }
}
