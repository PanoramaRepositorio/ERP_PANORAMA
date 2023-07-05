using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteBultoTranferidoOperadorBE
    {
        #region "Atributos"
        [DataMember]
        public String UsuarioSalida { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }


        #endregion
    }
}
