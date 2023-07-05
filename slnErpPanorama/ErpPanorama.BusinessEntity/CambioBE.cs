using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class CambioBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCambio { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public Int32 IdTipoCambio { get; set; }
        [DataMember]
        public Int32? IdPedido { get; set; }
        [DataMember]
        public String NumeroPedido { get; set; }
        [DataMember]
        public Int32 IdTipoDocumentoVenta { get; set; }
        [DataMember]
        public String SerieDocumentoVenta { get; set; }
        [DataMember]
        public String NumeroDocumentoVenta { get; set; }
        [DataMember]
        public DateTime FechaVenta { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String NumeroCliente { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public Int32 IdSupervisor { get; set; }
        [DataMember]
        public Int32 IdMotivo { get; set; }
        [DataMember]
        public String Motivo { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagAprobado { get; set; }
        [DataMember]
        public Boolean FlagRecibido { get; set; }
        [DataMember]
        public String NumeroNotaCredito { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescTipoCambio { get; set; }
        [DataMember]
        public String DescSupervisor { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public Int32 IdDocumentoVenta { get; set; }
        [DataMember]
        public Int32? IdDocumentoVentaNcv { get; set; }
        [DataMember]
        public Int32? IdTipoAplicacion { get; set; }
        [DataMember]
        public String DescTipoAplicacion { get; set; }
        [DataMember]
        public String DescTipoCliente { get; set; }

        [DataMember]
        public DateTime? FechaRecibido { get; set; }
        [DataMember]
        public Int32 IdPersonaRecibido { get; set; }
        [DataMember]
        public Int32 IdPersonaAprobado { get; set; }
        [DataMember]
        public Boolean FlagReajuste { get; set; }
        [DataMember]
        public String CodigoNC { get; set; }

        [DataMember]
        public String UsuarioAprobado { get; set; }
        [DataMember]
        public DateTime? FechaAprobado { get; set; }
        [DataMember]
        public String UsuarioRecibido { get; set; }


        #endregion

    }
}
