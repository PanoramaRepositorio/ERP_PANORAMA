using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    public class ReportePedidoVendedorCarteraMetaBE
    {
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String DescRuta { get; set; }
        [DataMember]
        public decimal Meta { get; set; }
        [DataMember]
        public decimal AlcanceMeta { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public DateTime FechaPedido { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public decimal TotalSoles { get; set; }
        [DataMember]
        public decimal TotalPiso { get; set; }
        [DataMember]
        public decimal TotalPisoSinIGV { get; set; }


        [DataMember]
        public decimal TotalFinal { get; set; }
        [DataMember]
        public decimal TotalFinalSinIGV { get; set; }
        [DataMember]
        public decimal ComisionFinal { get; set; }

        [DataMember]
        public decimal TotalCartera { get; set; }
        [DataMember]
        public decimal TotalCarteraSinIGV { get; set; }

        [DataMember]
        public decimal TotalCarteraPersona { get; set; }
        [DataMember]
        public decimal TotalCarteraPersonaSinIGV { get; set; }
        [DataMember]
        public decimal TotalSinMatch { get; set; }
        

        [DataMember]
        public decimal TotalPisoAntes { get; set; }
        [DataMember]
        public decimal TotalPisoAntesSinIGV { get; set; }
        [DataMember]
        public decimal TotalCarteraAntes { get; set; }
        [DataMember]
        public decimal TotalCarteraAntesSinIGV { get; set; }


        [DataMember]
        public DateTime FechaFacturacion { get; set; }
        [DataMember]
        public decimal SueldoBase { get; set; }
        [DataMember]
        public decimal Comision { get; set; }
        [DataMember]
        public decimal ComisionCliente { get; set; }
        [DataMember]
        public decimal Prospecto { get; set; }

        [DataMember]
        public decimal ComisionDM5 { get; set; }
        [DataMember]
        public decimal ComisionPiso { get; set; }
        [DataMember]
        public decimal ComisionCartera { get; set; }
        [DataMember]
        public decimal ComisionPersona { get; set; }

        [DataMember]
        public decimal ComisionaPersonaAntes { get; set; }
        [DataMember]
        public decimal ComisionMixtaAntes { get; set; }


        [DataMember]
        public decimal SueldoBruto { get; set; }




    }
}
