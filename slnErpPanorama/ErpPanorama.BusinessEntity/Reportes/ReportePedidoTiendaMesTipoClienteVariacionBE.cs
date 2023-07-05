using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    public class ReportePedidoTiendaMesTipoClienteVariacionBE
    {
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescTipoCliente { get; set; }
        [DataMember]
        public String DescTiendaAnterior { get; set; }
        [DataMember]
        public Decimal PeriodoAnterior { get; set; }
        [DataMember]
        public Decimal PeriodoActual { get; set; }
        [DataMember]
        public Decimal VariacionRelativa { get; set; }
        [DataMember]
        public Decimal VariacionPorcentual { get; set; }
        [DataMember]
        public Decimal Meta { get; set; }
        [DataMember]
        public Decimal VariacionRelativaMeta { get; set; }
        [DataMember]
        public Decimal VariacionPorcentualMeta { get; set; }
        [DataMember]
        public Decimal PorcentajeCrecimiento { get; set; }

   
    }
}
