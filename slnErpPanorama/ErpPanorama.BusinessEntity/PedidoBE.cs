using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class PedidoBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdPedido { get; set; }
        [DataMember]
        public Int32 IdPedidoPanorama { get; set; }
        [DataMember]
        public Int32 IdPPedido { get; set; }
        [DataMember]
        public Int32 IdPedidoWeb { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public Int32 IdCampana { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 Mes { get; set; }
        [DataMember]
        public Int32? IdProforma { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String Serie { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String FechaPedPanorama { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime? FechaVencimiento { get; set; }
        [DataMember]
        public DateTime? FechaCancelacion { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public Int32? IdClienteAsociado { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String NumeroDocumentoAsociado { get; set; }
        [DataMember]
        public String DescClienteAsociado { get; set; }
        [DataMember]
        public String DireccionAsociado { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public Int32 IdFormaPago { get; set; }
        [DataMember]
        public Int32 IdVendedor { get; set; }
        [DataMember]
        public Int32 TotalCantidad { get; set; }
        [DataMember]
        public Decimal SubTotal { get; set; }
        [DataMember]
        public Decimal PorcentajeDescuento { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public Decimal PorcentajeImpuesto { get; set; }
        [DataMember]
        public Decimal Igv { get; set; }
        [DataMember]
        public Decimal Icbper { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public Decimal TotalBruto { get; set; }
        [DataMember]
        public Decimal TotalDiferencia { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Int32 IdCombo { get; set; }
        [DataMember]
        public String Despachar { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public Int32 IdTipoVenta { get; set; }
        [DataMember]
        public Int32 IdMotivo { get; set; }
        [DataMember]
        public Int32 IdAsesor { get; set; }
        [DataMember]
        public Int32 IdAsesorExterno { get; set; }
        [DataMember]
        public Boolean FlagPreVenta { get; set; }
        [DataMember]
        public Boolean FlagProcesado { get; set; }
        [DataMember]
        public Boolean FlagImpresion { get; set; }
        [DataMember]
        public Boolean FlagIniCalidad { get; set; }
        [DataMember]
        public DateTimeOffset? FechaIniCalidad { get; set; }
        [DataMember]
        public Boolean FlagFinCalidad { get; set; }
        [DataMember]
        public DateTimeOffset? FechaFinCalidad { get; set; }
        [DataMember]
        public Boolean FlagCompraPerfecta { get; set; }
        [DataMember]
        public Boolean FlagAuditado { get; set; }
        [DataMember]
        public DateTime? FechaAuditado { get; set; }
        [DataMember]
        public Boolean FlagImpresionRus { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Estado { get; set; }
        [DataMember]
        public int ModalidadEnvio { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String Ruc { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescCampana { get; set; }
        [DataMember]
        public String NumeroProforma { get; set; }
        [DataMember]
        public String NumeroCredito { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public String Add_user { get; set; }
        [DataMember]
        public String DescTipoVenta { get; set; }
        [DataMember]
        public String DescMotivo { get; set; }
        [DataMember]
        public String DescAsesor { get; set; }
        [DataMember]
        public Int32 IdAlmacen { get; set; }
        [DataMember]
        public Int32 IdTipoCliente { get; set; }
        [DataMember]
        public String TiposCliente { get; set; }
        [DataMember]
        public String DescTipoCliente { get; set; }
        [DataMember]
        public Int32 IdClasificacionCliente { get; set; }
        [DataMember]
        public String DescClasificacionCliente { get; set; }
        [DataMember]
        public Int32 IdTipoDocumentoCliente { get; set; }
        [DataMember]
        public String DescSituacionAlmacen { get; set; }
        [DataMember]
        public String Conductor { get; set; }
        [DataMember]
        public String DescAuxiliar { get; set; }
        [DataMember]
        public Boolean FlagEstadoCuenta { get; set; }
        [DataMember]
        public Int32 IdTipoDocumentoClienteAsociado { get; set; }
        [DataMember]
        public String DescRuta { get; set; }
        [DataMember]
        public Int32 IdEstadoCuenta { get; set; }
        [DataMember]
        public DateTime FechaCredito { get; set; }
        [DataMember]
        public Int32? IdPedidoReferencia { get; set; }
        [DataMember]
        public Decimal DisponiblePorcentaje { get; set; }
        [DataMember]
        public Decimal TarifaEnvio { get; set; }
        [DataMember]
        public String CompPago { get; set; }

        [DataMember]
        public Boolean Chequeado { get; set; }
        [DataMember]
        public DateTime FechaChequeado { get; set; }
        [DataMember]
        public Boolean bOrigenFlagPreVenta { get; set; }
        [DataMember]
        public String NumeroPedidoReferencia { get; set; }
        [DataMember]
        public String Destino { get; set; }

        [DataMember]
        public Boolean FlagCliente { get; set; }
        [DataMember]
        public Boolean FlagPago { get; set; }
        [DataMember]
        public String FechaPago { get; set; }

        [DataMember]
        public Int32 IdPedidoWEB { get; set; }

        [DataMember]
        public String EstadoActual { get; set; }

        [DataMember]
        public String PaisLocalidad { get; set; }

        [DataMember]
        public String DirReferencia { get; set; }

        //Detalle
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal PrecioVenta { get; set; }
        [DataMember]
        public Decimal ValorVenta { get; set; }
        [DataMember]
        public Boolean FlagArmado { get; set; }
        [DataMember]
        public String DescDespachador { get; set; }
        [DataMember]
        public String DescPersonaCalidad { get; set; }

        //MovimientoPedido
        [DataMember]
        public Int32 Items { get; set; }
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
        public Int32 CantidadBulto { get; set; }

        [DataMember]
        public String NumeroModificacion { get; set; }

        [DataMember]
        public String NumeroLiberacion { get; set; }
        [DataMember]
        public int NumLiberacion { get; set; }

        [DataMember]
        public Int32? IdContratoFabricacion { get; set; }
        [DataMember]
        public Int32? IdProyectoServicio { get; set; }
        [DataMember]
        public Int32? IdNovioRegalo { get; set; }

        [DataMember]
        public Int32 IdSituacionCliente { get; set; }

        [DataMember]
        public DateTimeOffset? FechaPreparacion { get; set; }
        [DataMember]
        public DateTimeOffset? FechaPreparado { get; set; }

        [DataMember]
        public DateTimeOffset? FechaChequeo { get; set; }
        [DataMember]
        public DateTimeOffset? FechaChequeado2 { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }

        // Tienda Web
        [DataMember]
        public String NumPedidoWeb { get; set; }
        [DataMember]
        public String DesTipoCliente { get; set; }
        [DataMember]
        public String ModalidadPago { get; set; }
        [DataMember]
        public String NumDocumento { get; set; }
        [DataMember]
        public String DireccionEnvio { get; set; }
        [DataMember]
        public String Ciudad { get; set; }
        [DataMember]
        public String Distrito { get; set; }
        [DataMember]
        public String Correo { get; set; }
        [DataMember]
        public String Rucweb { get; set; }
        [DataMember]
        public String Razonsocial { get; set; }
        [DataMember]
        public String TelMovil { get; set; }
        [DataMember]
        public String Telfijo { get; set; }
        [DataMember]
        public String RefOtro { get; set; }
        [DataMember]
        public Int32? Flag { get; set; }

        [DataMember]
        public Boolean FlagPtFlores { get; set; }
        [DataMember]
        public Boolean FlagCumpleanios { get; set; }
        [DataMember]
        public Decimal TotalDscCumpleanios { get; set; }

        [DataMember]
        public String UsuarioAprobo { get; set; }
        
        // Actualizado

        //[DataMember]
        //public Boolean FlagIniCalidad { get; set; }
        //[DataMember]
        //public Boolean FlagFinCalidad { get; set; }
        //[DataMember]
        //public String DescPersonaCalidad { get; set; }





        #endregion
    }
}

