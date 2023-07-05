using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteCumpleaniosClienteBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String AbrevDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public DateTime ?FechaNac { get; set; }
        [DataMember]
        public Int32 Dia { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public String OtroTelefono { get; set; }
        [DataMember]
        public String Celular { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public Int32 Tickets { get; set; }
        [DataMember]
        public Decimal TotalSoles { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
        public Int32 TicketMes { get; set; }
        [DataMember]
        public Decimal TotalMes { get; set; }

        [DataMember]
        public String NomDpto { get; set; }
        [DataMember]
        public String NomProv { get; set; }
        [DataMember]
        public String NomDist { get; set; }

        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String TipoCliente { get; set; }

        [DataMember]
        public Int32 IdTipoCliente { get; set; }
        [DataMember]
        public Int32 NroCorreo { get; set; }
        #endregion
    }
}
