using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ClienteCreditoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdClienteCredito { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public Int32 IdClasificacionCliente { get; set; }
        [DataMember]
        public String AbrevClasifica { get; set; }
        [DataMember]
        public Int32 IdMotivo { get; set; }
        [DataMember]
        public String DescMotivo { get; set; }
        [DataMember]
        public DateTime FechaAprobacion { get; set; }
        [DataMember]
        public Decimal LineaCredito { get; set; }
        [DataMember]
        public Decimal LineaCreditoUtilizada { get; set; }
        [DataMember]
        public Decimal LineaCreditoDisponible { get; set; }
        [DataMember]
        public Decimal Garantia { get; set; }
        [DataMember]
        public Int32 NumeroDias { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String DescTipoCliente { get; set; }
        [DataMember]
        public String DescRuta { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }
        [DataMember]
        public DateTime? FechaRegistro { get; set; }
        [DataMember]
        public String UsuarioModifica { get; set; }
        [DataMember]
        public DateTime? FechaModifica { get; set; }


        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String AbrevDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        

        #endregion
    }
}
