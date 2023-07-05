using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class PagosBE
    {
        #region "Atributos"
       
        [DataMember]
        public Int32 IdPago { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32? IdPedido { get; set; }
        [DataMember]
        public Int32 IdCaja { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public Int32 IdCondicionPago { get; set; }
        [DataMember]
        public String Concepto { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public Decimal ImporteSoles { get; set; }
        [DataMember]
        public Decimal ImporteDolares { get; set; }
        [DataMember]
        public Int32? IdMovimientoCaja { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String TipoMovimiento { get; set; }

 

        [DataMember]
        public String NumeroPedido { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String CodMonedaPedido { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public String DescCaja { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String DescCondicionPago { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }

        [DataMember]
        public String NumeroAntecesor { get; set; }
        [DataMember]
        public String NumeroPredecesor { get; set; }
        [DataMember]
        public String CodTipoDocumentoAntecesor { get; set; }
        [DataMember]
        public String CodTipoDocumentoPredecesor { get; set; }
        [DataMember]
        public Int32 IdVendedor { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public Int32? IdDis_ProyectoServicio { get; set; }
        [DataMember]
        public Int32? IdDis_ContratoFabricacion { get; set; }
        [DataMember]
        public String NumeroProyectoServicio { get; set; }
        [DataMember]
        public String NumeroContrato { get; set; }
        [DataMember]
        public Int32? IdCliente { get; set; }
        [DataMember]
        public String TipoCliente { get; set; }
        [DataMember]
        public Int32? IdPersona { get; set; }
        [DataMember]
        public Int32? IdSolicitudPrestamo { get; set; }
        [DataMember]
        public Int32? IdHoraExtra { get; set; }

        [DataMember]
        public String CodigoGiftCard { get; set; }
        #endregion
    }
}
