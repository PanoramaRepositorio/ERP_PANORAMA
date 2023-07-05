using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoVendedorPisoSueldoBE
    {
        #region "Atributos"
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String DescCargo { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public Decimal TotalClienteFinal { get; set; }
        [DataMember]
        public Decimal TotalClienteMayorista { get; set; }
        [DataMember]
        public Decimal TotalClienteDiseno { get; set; }
        [DataMember]
        public Decimal TotalClienteFinalSinIGV { get; set; }
        [DataMember]
        public Decimal TotalClienteMayoristaSinIGV { get; set; }
        [DataMember]
        public Decimal TotalClienteDisenoSinIGV { get; set; }

        [DataMember]
        public Decimal TotalVenta { get; set; }
        [DataMember]
        public Decimal TotalVentaConIGV { get; set; }
        [DataMember]
        public Decimal Basico { get; set; }
        [DataMember]
        public Int32 CantidadCliente { get; set; }
        [DataMember]
        public Decimal ComisionCliente { get; set; }
        [DataMember]
        public Decimal ComisionFinal { get; set; }
        [DataMember]
        public Decimal ComisionMayorista { get; set; }
        [DataMember]
        public Decimal ComisionDiseno { get; set; }
        [DataMember]
        public Decimal Meta { get; set; }
        [DataMember]
        public Decimal MetaTienda { get; set; }
        [DataMember]
        public Decimal AlcanceMeta { get; set; }
        [DataMember]
        public Decimal AlcanceMetaTienda { get; set; }

        
        [DataMember]
        public Decimal MetaConversion { get; set; }
        [DataMember]
        public Decimal Conversion { get; set; }
        [DataMember]
        public Decimal BonoConversion { get; set; }
        [DataMember]
        public Decimal BonoMetaTienda { get; set; }
        [DataMember]
        public Boolean FlaCobro { get; set; }
        [DataMember]
        public String DetalleCobro { get; set; }
        [DataMember]
        public Decimal BonoItem { get; set; }
        [DataMember]
        public Decimal ComisionFinalDM { get; set; }
        [DataMember]
        public Decimal ComisionMayoristaDM { get; set; }
        [DataMember]
        public Decimal ComisionFinalDM5 { get; set; }
        [DataMember]
        public Decimal ComisionMayoristaDM5 { get; set; }
        [DataMember]
        public Decimal ComisionAsesoria { get; set; }

        [DataMember]
        public String DiaAlcanceMeta { get; set; }
        [DataMember]
        public String DiaAlcanceMetaTienda { get; set; }
        [DataMember]
        public Decimal DescuentoFalta { get; set; }
        [DataMember]
        public Decimal DescuentoTardanza { get; set; }
        [DataMember]
        public Decimal DescuentoReclamo { get; set; }
        [DataMember]
        public Decimal DescuentoMemo { get; set; }

        [DataMember]
        public Boolean FlagIndisciplina { get; set; }
        [DataMember]
        public Int32 Faltas { get; set; }
        [DataMember]
        public Int32 Tardanzas { get; set; }

        [DataMember]
        public Decimal TotalSueldo { get; set; }
        [DataMember]
        public Decimal TotalSueldoNeto { get; set; }
        [DataMember]
        public Int32 DiasIngreso { get; set; }
        

        #endregion
    }
}
