using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class SolicitudPrestamoDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdSolicitudPrestamoDetalle { get; set; }
        [DataMember]
        public Int32 IdSolicitudPrestamo { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 NumeroCuota { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String Concepto { get; set; }
        [DataMember]
        public DateTime? FechaPago { get; set; }
        [DataMember]
        public DateTime? FechaVencimiento { get; set; }
        [DataMember]
        public Decimal Capital { get; set; }
        [DataMember]
        public Decimal Interes { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public Decimal InteresMoratorio { get; set; }
        [DataMember]
        public String TipoMovimiento { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public Decimal Cargo { get; set; }
        [DataMember]
        public Decimal Abono { get; set; }
        [DataMember]
        public Decimal Saldo { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        
        #endregion

    }
}

