using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class MovimientoAlmacenBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdMovimientoAlmacen { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public Int32 IdTipoMovimiento { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Int32 IdAlmacenOrigen { get; set; }
        [DataMember]
        public Int32 IdMotivo { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String Referencia { get; set; }
        [DataMember]
        public String Observaciones { get; set; }
        [DataMember]
        public Int32? IdAlmacenDestino { get; set; }
        [DataMember]
        public Int32? IdCliente { get; set; }
        [DataMember]
        public Int32? IdSolicitudProducto { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Estado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescAlmacen { get; set; }
        [DataMember]
        public String DescMotivo { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }

        [DataMember]
        public String UsuarioRevision { get; set; }
        [DataMember]
        public Boolean FlagRevision { get; set; }

        [DataMember]
        public Boolean FlagRecibido { get; set; }
        [DataMember]
        public Boolean FlagRecibidoFisico { get; set; }
        [DataMember]
        public String DescAlmacenDestino { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Int32 CantidadAnterior { get; set; }
        [DataMember]
        public Decimal CostoUnitario { get; set; }
        [DataMember]
        public Decimal MontoTotal { get; set; }

        [DataMember]
        public DateTimeOffset? FechaChequeo { get; set; }
        [DataMember]
        public Int32? IdAuxiliar { get; set; }
        [DataMember]
        public Int32 IdChequeador { get; set; }
        [DataMember]
        public Int32 IdEmbalador { get; set; }
        [DataMember]
        public Int32 CantidadBulto { get; set; }

        [DataMember]
        public Int32 Items { get; set; }
        [DataMember]
        public Int32 TotalCantidad { get; set; }
        [DataMember]
        public Int32 CantidadChequeo { get; set; }
        [DataMember]
        public Decimal PorcentajeChequeo { get; set; }
        [DataMember]
        public String DescPicking { get; set; }
        [DataMember]
        public String DescChequeador { get; set; }
        [DataMember]
        public String DescEmbalador { get; set; }

        [DataMember]
        public Int32 IdPedido { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public DateTime? FechaDelivery { get; set; }
        [DataMember]
        public String DescSituacionPedido { get; set; }
        [DataMember]
        public Boolean FlagChequeo { get; set; }
        [DataMember]
        public Boolean FlagChequeoFinalizado { get; set; }

        [DataMember]
        public Boolean FlagUpd { get; set; }

        [DataMember]
        public Boolean Preparacion { get; set; }
        [DataMember]
        public DateTime? FechaPreparacion { get; set; }
        [DataMember]
        public Boolean Preparado { get; set; }
        [DataMember]
        public DateTime? FechaPreparado { get; set; }
        [DataMember]
        public Boolean FlagCierre { get; set; }
        [DataMember]
        public Int32 IdMovimientoAlmacenDetalle { get; set; }
        [DataMember]
        public Int32? IdMovimientoAlmacenReferencia { get; set; }
        [DataMember]
        public Boolean FlagDespachado { get; set; }
        [DataMember]
        public DateTime? FechaDespachado { get; set; }
        [DataMember]
        public String PersonaPicking { get; set; }
        [DataMember]
        public String UsuarioRecibidoFisico { get; set; }
        [DataMember]
        public String UsuarioElimina { get; set; }
        [DataMember]
        public String ObservacionElimina { get; set; }
        [DataMember]
        public Boolean FlagEmbalaje { get; set; }
        [DataMember]
        public Boolean FlagEmbalado { get; set; }
        [DataMember]
        public DateTime? FechaEmbalaje { get; set; }
        [DataMember]
        public DateTime? FechaEmbalado { get; set; }
        [DataMember]
        public Int32? Bultos { get; set; }

        [DataMember]
        public String UsuarioUpdBultos { get; set; }

        [DataMember]
        public Int32 IdCausalTransferencia { get; set; }

        [DataMember]
        public String  Causal { get; set; }
        [DataMember]
        public String DocReferencia { get; set; }

        [DataMember]
        public Int32 IdVendedor { get; set; }
        #endregion

    }
}
