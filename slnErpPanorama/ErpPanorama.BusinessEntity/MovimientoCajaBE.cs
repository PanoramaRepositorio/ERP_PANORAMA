using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class MovimientoCajaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdMovimientoCaja { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String Empresa { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public Int32 IdCaja { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public Int32 IdFormaPago { get; set; }
        [DataMember]
        public Int32 IdCondicionPago { get; set; }
        [DataMember]
        public String TipoTarjeta { get; set; }
        [DataMember]
        public String TipoMovimiento { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public Decimal ImporteSoles { get; set; }
        [DataMember]
        public Decimal ImporteDolares { get; set; }
        [DataMember]
        public Int32? IdDocumentoVenta { get; set; }
        [DataMember]
        public Int32? IdDocumentoVentaReferencia { get; set; }
        [DataMember]
        public Int32? IdPago { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }


        [DataMember]
        public String DescCaja { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String DescCondicionPago { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }

        [DataMember]
        public Int32 CantidadVisa { get; set; }
        [DataMember]
        public Int32 CantidadMaster { get; set; }
        [DataMember]
        public Int32 IdMotivoAnulacion { get; set; }
        [DataMember]
        public String DescMotivoAnulacion { get; set; }
        [DataMember]
        public String NumeroCondicion { get; set; }
        [DataMember]
        public Int32 IdPedido { get; set; }
        //[DataMember]
        //public Int32? IdMovimientoCajaChica { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        [DataMember]
        public String Concepto { get; set; }



        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public String DescPersona { get; set; }
        [DataMember]
        public String NumeroCupon { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Int32 IdPersonaAutoriza { get; set; }
        [DataMember]
        public String DescPersonaAutoriza { get; set; }
        [DataMember]
        public String UsuarioRegistro { get; set; }
        [DataMember]
        public DateTime? FechaRegistro { get; set; }
        [DataMember]
        public String UsuarioModifica { get; set; }
        [DataMember]
        public DateTime? FechaModifica { get; set; }
        [DataMember]
        public String UsuarioElimina { get; set; }
        [DataMember]
        public DateTime? FechaElimina { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento2 { get; set; }
        [DataMember]
        public String CodTipoDocumento2 { get; set; }
        [DataMember]
        public String NumeroDocumento2 { get; set; }
        [DataMember]
        public Int32 IdDis_ProyectoServicio { get; set; }
        [DataMember]
        public Int32 IdSolicitudPrestamo { get; set; }
        [DataMember]
        public String Placa { get; set; }
        [DataMember]
        public String DescSituacionPSE { get; set; }
        [DataMember]
        public String DescSituacionSunat { get; set; }
        [DataMember]
        public Boolean FlagRetiroCliente { get; set; }
        #endregion
    }
}