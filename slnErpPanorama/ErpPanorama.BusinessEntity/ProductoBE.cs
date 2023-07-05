using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ProductoBE
    {
        #region "Atributos"
		[DataMember]
		public Int32 IdProducto { get; set; }
        [DataMember]
        public String IdProductoStr { get; set; }
        [DataMember]
		public Int32 IdEmpresa { get; set; }
		[DataMember]
        public Int32 IdProveedor { get; set; }
        [DataMember]
        public String DescProveedor { get; set; }
        [DataMember]
        public Decimal PrecioPromedio { get; set; }

        [DataMember]
        public String CodigoProveedor { get; set; }

		[DataMember]
		public String CodigoPanorama { get; set; }
		[DataMember]
		public Int32? IdUnidadMedida { get; set; }
        [DataMember]
        public Int32? IdFamiliaProducto { get; set; }
		[DataMember]
		public Int32? IdLineaProducto { get; set; }
        [DataMember]
        public Int32? IdSubLineaProducto { get; set; }
		[DataMember]
		public Int32? IdModeloProducto { get; set; }
		[DataMember]
		public Int32? IdMaterial { get; set; }
        [DataMember]
        public Int32? IdMaterial2 { get; set; }
        [DataMember]
		public Int32? IdMarca { get; set; }
		[DataMember]
		public Int32? IdProcedencia { get; set; }
		[DataMember]
		public String NombreProducto { get; set; }
		[DataMember]
		public String Descripcion { get; set; }
		[DataMember]
		public Decimal? Peso { get; set; }
		[DataMember]
		public String Medida { get; set; }
		[DataMember]
		public String CodigoBarra { get; set; }
		[DataMember]
        public byte[] Imagen { get; set; }
		[DataMember]
		public Decimal PrecioAB { get; set; }
		[DataMember]
		public Decimal PrecioCD { get; set; }
		[DataMember]
		public Decimal Descuento { get; set; }
        [DataMember]
        public Decimal DescuentoAB { get; set; }
        [DataMember]
        public Decimal DescuentoTemporal { get; set; }
        [DataMember]
        public Boolean FlagDescuentoAB { get; set; }
        [DataMember]
        public Decimal TipoCambioCD { get; set; }
        [DataMember]
		public Boolean FlagCompuesto { get; set; }
		[DataMember]
		public Boolean FlagObsequio { get; set; }
		[DataMember]
		public Boolean FlagEscala { get; set; }
        [DataMember]
        public Boolean FlagDestacado { get; set; }
        [DataMember]
        public Boolean FlagRecomendado { get; set; }
        [DataMember]
        public Boolean FlagNacional { get; set; }
		[DataMember]
		public String Observacion { get; set; }
		[DataMember]
		public DateTime Fecha { get; set; }

        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String Usuario { get; set; }

        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public String DescFamiliaProducto { get; set; }
        [DataMember]
        public String DescLineaProducto { get; set; }
        [DataMember]
        public String DescSubLineaProducto { get; set; }
        [DataMember]
        public String DescModeloProducto { get; set; }
        [DataMember]
        public String DescMaterial { get; set; }
        [DataMember]
        public String DescMaterial2 { get; set; }
        [DataMember]
        public String DescMarca { get; set; }
        [DataMember]
        public String DescProcedencia { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Decimal PrecioABSoles { get; set; }
        [DataMember]
        public Decimal PrecioCDSoles { get; set; }
        [DataMember]
        public String DescUbicacion { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public DateTime? FechaRecepcion { get; set; }
        [DataMember]
        public Int32? IdProductoArmado { get; set; }

        //Almacenes
        [DataMember]
        public Int32 AlmacenCentral { get; set; }
        [DataMember]
        public Int32 AlmacenTienda { get; set; }
        [DataMember]
        public Int32 AlmacenAndahuaylas { get; set; }
        [DataMember]
        public Int32 AlmacenOutlet { get; set; }
        [DataMember]
        public Int32 AlmacenTdaOutlet { get; set; }
        [DataMember]
        public Int32 AlmacenPrescott { get; set; }
        [DataMember]
        public Int32 AlmacenAviacion { get; set; }
        [DataMember]
        public Int32 AlmacenAviacion2 { get; set; }
        [DataMember]
        public Int32 AlmacenSanMiguel { get; set; }
        [DataMember]
        public Int32 AlmacenMegaPlaza { get; set; }
        [DataMember]
        public Int32 AlmacenMermas { get; set; }
        [DataMember]
        public Int32 AlmacenReparacion { get; set; }
        [DataMember]
        public Int32 AlmacenDiferencias { get; set; }
        [DataMember]
        public Int32 AlmacenTransito { get; set; }
        [DataMember]
        public Int32 AlmacenTransito_NS { get; set; }
        [DataMember]
        public Int32 AlmacenTransito_PED { get; set; }
        [DataMember]
        public Int32 AlmacenPendiente { get; set; }
        [DataMember]
        public Int32 AlmacenMuestras { get; set; }
        [DataMember]
        public Int32 AlmacenMarketing { get; set; }

        [DataMember]
        public Int32 TotalStock { get; set; }
        [DataMember]
        public Int32 CantidadCompra { get; set; }

        [DataMember]
        public Int32 IdTipoProducto { get; set; }
        [DataMember]
        public Int32 IdSubTipoProducto { get; set; }

        // Agregado 02-11-21
        [DataMember]
        public Decimal? MedidaInternaAltura { get; set; }
        [DataMember]
        public Decimal? MedidaInternaAncho { get; set; }
        [DataMember]
        public Decimal? MedidaInternaProfundidad { get; set; }

        [DataMember]
        public Decimal? MedidaExternaAltura { get; set; }
        [DataMember]
        public Decimal? MedidaExternaAncho { get; set; }
        [DataMember]
        public Decimal? MedidaExternaProfundidad { get; set; }

        [DataMember]
        public Decimal? PesoNeto { get; set; }
        [DataMember]
        public Decimal? PesoBruto { get; set; }

        [DataMember]
        public String Coleccion { get; set; }
        [DataMember]
        public String DescAlmacen { get; set; }
        #endregion

    }
}

