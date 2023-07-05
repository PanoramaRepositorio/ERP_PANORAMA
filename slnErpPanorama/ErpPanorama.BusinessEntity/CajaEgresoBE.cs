using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class CajaEgresoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCajaEgreso { get; set; }
        [DataMember]
        public String Documento { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String NombreEmpresa { get; set; }
        [DataMember]
        public String NumCaja { get; set; }
        [DataMember]
        public String NombreCaja { get; set; }
        [DataMember]
        public DateTime FecApertura { get; set; }
        [DataMember]
        public DateTime ?FecCierre { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
        public Decimal SaldoInicial { get; set; }
        [DataMember]
        public Decimal SaldoActual { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public Int32 TipoPersona { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public String Recibio { get; set; }
        [DataMember]
        public String NroRecibo { get; set; }
        [DataMember]
        public String Situacion { get; set; }
        [DataMember]
        public String UsuarioCreacion { get; set; }
        [DataMember]
        public String UsuarioCierre { get; set; }
        [DataMember]
        public String Mes { get; set; }
        [DataMember]
        public Decimal Monto { get; set; }
        [DataMember]
        public DateTime FechaAbono { get; set; }
        [DataMember]
        public Decimal Abono { get; set; }
        [DataMember]
        public Int32 IdBanco { get; set; }
        [DataMember]
        public String Banco { get; set; }
        [DataMember]
        public DateTime? FechaRecibo { get; set; }
        [DataMember]
        public DateTime? FechaRevision { get; set; }
        [DataMember]
        public Boolean FlagRevision { get; set; }

        [DataMember]
        public String UsuarioRevision { get; set; }
        #endregion
    }
}
