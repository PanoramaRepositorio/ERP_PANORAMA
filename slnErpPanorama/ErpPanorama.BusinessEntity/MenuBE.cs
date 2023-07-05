using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    public class MenuBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdMenu { get; set; }
        [DataMember]
        public String MenuCodigo { get; set; }
        [DataMember]
        public Int32 IdMenuPadre { get; set; }
        [DataMember]
        public String MenuDescripcion { get; set; }
        [DataMember]
        public String Imagen { get; set; }
        [DataMember]
        public Boolean LargeImage { get; set; }
        [DataMember]
        public String Clase { get; set; }
        [DataMember]
        public String Ensamblado { get; set; }
        [DataMember]
        public Int32 IdMenuTipo { get; set; }
        [DataMember]
        public String ModoCargaVentana { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        #endregion
    }
}
