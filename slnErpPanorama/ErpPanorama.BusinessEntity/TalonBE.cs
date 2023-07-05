using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class TalonBE
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
        public Int32 IdTamanoHoja { get; set; }
        [DataMember]
        public String NumeroSerie { get; set; }
        [DataMember]
        public String NumeroAutoriza { get; set; }
        [DataMember]
        public String SerieImpresora { get; set; }
        [DataMember]
        public String DireccionFiscal { get; set; }
        [DataMember]
        public String Impresora { get; set; }
        [DataMember]
        public Boolean FlagAbrirCajon { get; set; }
        [DataMember]
        public String NombreComercial { get; set; }
        [DataMember]
        public String PaginaWeb { get; set; }


        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
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
        [DataMember]
        public String DescTamanoHoja { get; set; }
        #endregion
    }
}
