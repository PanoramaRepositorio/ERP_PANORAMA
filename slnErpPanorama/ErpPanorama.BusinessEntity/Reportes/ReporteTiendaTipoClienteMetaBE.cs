using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteTiendaTipoClienteMetaBE
    {
        #region "Atributos"

        [DataMember]
        public String Dia { get; set; }
        [DataMember]
        public Int32 DiaMes { get; set; }
        [DataMember]
        public DateTime Fecha1 { get; set; }
        [DataMember]
        public Decimal Importe1 { get; set; }
        [DataMember]
        public Decimal Porcentaje { get; set; }
        [DataMember]
        public DateTime Fecha2 { get; set; }
        [DataMember]
        public Decimal ImporteFinal { get; set; }
        [DataMember]
        public Decimal ImporteMayorista { get; set; }
        [DataMember]
        public Decimal Importe2 { get; set; }
        [DataMember]
        public Decimal Meta { get; set; }
        [DataMember]
        public Decimal Cumplimiento { get; set; }

        [DataMember]
        public Int32 CantidadCliente { get; set; }
        [DataMember]
        public Decimal TicketPromedio { get; set; }

        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String DescCargo { get; set; }
        [DataMember]
        public String DescTienda { get; set; }


        #endregion
    }
}

