using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteMovimientoCajaBE
    {
        
        #region "Atributos"
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescCaja { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public Int32 IdCondicionPago { get; set; }
        [DataMember]
        public String DescCondicionPago { get; set; }
        [DataMember]
        public String TipoMovimiento { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public Decimal CajaInicial { get; set; }
        [DataMember]
        public Decimal ImporteSoles { get; set; }
        [DataMember]
        public Decimal ImporteDolares { get; set; }
        [DataMember]
        public Decimal TotalVisa { get; set; }
        [DataMember]
        public Decimal TotalMastercard { get; set; }
        [DataMember]
        public Decimal TotalNotaCredito { get; set; }
        [DataMember]
        public Decimal TotalAnulados { get; set; }
        [DataMember]
        public Decimal TotalCheques { get; set; }
        [DataMember]
        public Decimal TotalCupon { get; set; }
        [DataMember]
        public Decimal TotalPagos { get; set; }
        [DataMember]
        public Decimal TotalIngresos { get; set; }
        [DataMember]
        public Decimal TotalEgresos { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public String Estado { get; set; }

        [DataMember]
        public Decimal TotalVisaAgente { get; set; }
        [DataMember]
        public Decimal TotalMastercardAgente { get; set; }
        [DataMember]
        public Decimal TotalIngresosAgente { get; set; }
        [DataMember]
        public Decimal TotalEgresosAgente { get; set; }

        [DataMember]
        public Decimal Doscientos { get; set; }
        [DataMember]
        public Decimal Cien { get; set; }
        [DataMember]
        public Decimal Cincuenta { get; set; }
        [DataMember]
        public Decimal Veinte { get; set; }
        [DataMember]
        public Decimal Diez { get; set; }
        [DataMember]
        public Decimal Cinco { get; set; }
        [DataMember]
        public Decimal Dos { get; set; }
        [DataMember]
        public Decimal Un { get; set; }
        [DataMember]
        public Decimal CincuentaCentimos { get; set; }
        [DataMember]
        public Decimal VeinteCentimos { get; set; }
        [DataMember]
        public Decimal DiezCentimos { get; set; }
        [DataMember]
        public Decimal TipoCambioVenta { get; set; }
        [DataMember]
        public Decimal CienDolar { get; set; }
        [DataMember]
        public Decimal CincuentaDolar { get; set; }
        [DataMember]
        public Decimal VeinteDolar { get; set; }
        [DataMember]
        public Decimal DiezDolar { get; set; }
        [DataMember]
        public Decimal CincoDolar { get; set; }
        [DataMember]
        public Decimal UnDolar { get; set; }

        [DataMember]
        public Int32 CantidadVisa { get; set; }
        [DataMember]
        public Int32 CantidadMaster { get; set; }

        [DataMember]
        public Decimal TotalVisaCredito { get; set; }
        [DataMember]
        public Decimal TotalVisaDebito { get; set; }
        [DataMember]
        public Decimal TotalMastercardCredito { get; set; }
        [DataMember]
        public Decimal TotalMastercardDebito { get; set; }
        [DataMember]
        public Decimal Diferencia { get; set; }

        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 Mes { get; set; }
        [DataMember]
        public String NombreMes { get; set; }
        [DataMember]
        public Decimal TotalCajaFinal { get; set; }
        [DataMember]
        public Decimal TotalCajaFinalSoles { get; set; }
        [DataMember]
        public Decimal TotalCajaFinalDolaresaSoles { get; set; }
        [DataMember]
        public Decimal TotalGeneral { get; set; }
        [DataMember]
        public Decimal TotalEgresosSoles { get; set; }
        [DataMember]
        public Decimal TotalEgresosDolares { get; set; }
        [DataMember]
        public String Usuario { get; set; }

        [DataMember]
        public Decimal TotalVisaPuntosVida { get; set; }
        [DataMember]
        public Decimal TotalMastercardPuntosVida { get; set; }
        [DataMember]
        public Decimal TotalDrinerclubPromocion { get; set; }

        [DataMember]
        public Decimal TotalTarjetasForaneas { get; set; }

        [DataMember]
        public Decimal TotalDinnersPromocionCredito { get; set; }

        [DataMember]
        public Decimal TotalDinnersPromocion { get; set; }
        [DataMember]
        public Decimal TotalDinnersPromocionDebito { get; set; }

        [DataMember]
        public Decimal TotalTarjForaneasCredito { get; set; }

        [DataMember]
        public Decimal TotalTarjForaneas { get; set; }
        [DataMember]
        public Decimal TotalTarjForaneasDebito { get; set; }

        
        #endregion

    }
}

