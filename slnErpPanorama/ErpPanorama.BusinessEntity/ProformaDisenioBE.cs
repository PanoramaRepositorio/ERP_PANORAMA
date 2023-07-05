using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ProformaDisenioBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdProformaDisenio { get; set; }
        [DataMember]
        public String NumProformaDisenio { get; set; }
        [DataMember]
        public DateTime FechaProformaDisenio { get; set; }
        [DataMember]
        public int IdTipoProformaDisenio { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String NombreCliente { get; set; }
        [DataMember]
        public String DireccionCliente { get; set; }
        [DataMember]
        public String CorreoEnvio { get; set; }
        [DataMember]
        public String Referencia { get; set; }
        [DataMember]
        public Int32 IdAsesor { get; set; }
        [DataMember]
        public String NombreAsesor { get; set; }
        [DataMember]
        public Int32 IdVendedor { get; set; }
        [DataMember]
        public String NombreVendedor { get; set; }

        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
        public Decimal Total { get; set; }

        [DataMember]
        public String UsuarioCreacion { get; set; }
        [DataMember]
        public DateTime FechaCreacion { get; set; }
        [DataMember]
        public String UsuarioModificacion { get; set; }
        [DataMember]
        public DateTime FechaModificacion { get; set; }

        [DataMember]
        public Int32 Enviado { get; set; }

        [DataMember]
        public DateTime FechaAprobacion { get; set; }

        [DataMember]
        public String Obs { get; set; }

        [DataMember]
        public Int32 IdSituacion { get; set; }

        [DataMember]
        public String Situacion { get; set; }

        [DataMember]
        public String TipoProforma { get; set; }

        [DataMember]
        public int Numero { get; set; }
        #endregion
    }
}