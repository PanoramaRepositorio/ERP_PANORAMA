using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class PromocionTemporalDetalleDL
    {
        public PromocionTemporalDetalleDL() { }

        public void Inserta(PromocionTemporalDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionTemporalDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdPromocionTemporalDetalle", DbType.Int32, pItem.IdPromocionTemporalDetalle);
            db.AddInParameter(dbCommand, "pIdPromocionTemporal", DbType.Int32, pItem.IdPromocionTemporal);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(PromocionTemporalDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionTemporalDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdPromocionTemporalDetalle", DbType.Int32, pItem.IdPromocionTemporalDetalle);
            db.AddInParameter(dbCommand, "pIdPromocionTemporal", DbType.Int32, pItem.IdPromocionTemporal);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(PromocionTemporalDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionTemporalDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdPromocionTemporalDetalle", DbType.Int32, pItem.IdPromocionTemporalDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void EliminaTodo(PromocionTemporalDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionTemporalDetalle_EliminaTodo");

            db.AddInParameter(dbCommand, "pIdPromocionTemporal", DbType.Int32, pItem.IdPromocionTemporal);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<PromocionTemporalDetalleBE> ListaTodosActivo(int IdPromocionTemporal)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionTemporalDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdPromocionTemporal", DbType.Int32, IdPromocionTemporal);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PromocionTemporalDetalleBE> PromocionTemporalDetallelist = new List<PromocionTemporalDetalleBE>();
            PromocionTemporalDetalleBE PromocionTemporalDetalle;
            while (reader.Read())
            {
                PromocionTemporalDetalle = new PromocionTemporalDetalleBE();
                PromocionTemporalDetalle.IdPromocionTemporalDetalle = Int32.Parse(reader["IdPromocionTemporalDetalle"].ToString());
                PromocionTemporalDetalle.IdPromocionTemporal = Int32.Parse(reader["IdPromocionTemporal"].ToString());
                PromocionTemporalDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                PromocionTemporalDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                PromocionTemporalDetalle.NombreProducto = reader["NombreProducto"].ToString();
                PromocionTemporalDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PromocionTemporalDetalle.DescLineaProducto = reader["DescLineaProducto"].ToString();
                PromocionTemporalDetalle.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                PromocionTemporalDetalle.Precio = Decimal.Parse(reader["Precio"].ToString());
                PromocionTemporalDetalle.Precio2 = Decimal.Parse(reader["Precio2"].ToString());
                PromocionTemporalDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                PromocionTemporalDetalle.DescuentoActual = Decimal.Parse(reader["DescuentoActual"].ToString());
                PromocionTemporalDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PromocionTemporalDetalle.CantidadCompra = Int32.Parse(reader["CantidadCompra"].ToString());
                PromocionTemporalDetalle.AlmacenCentral = Int32.Parse(reader["AlmacenCentral"].ToString());
                PromocionTemporalDetalle.AlmacenTienda = Int32.Parse(reader["AlmacenTienda"].ToString());
                PromocionTemporalDetalle.AlmacenAndahuaylas = Int32.Parse(reader["AlmacenAndahuaylas"].ToString());
                PromocionTemporalDetalle.AlmacenPrescott = Int32.Parse(reader["AlmacenPrescott"].ToString());
                PromocionTemporalDetalle.AlmacenAviacion = Int32.Parse(reader["AlmacenAviacion"].ToString());
                PromocionTemporalDetalle.AlmacenMegaPlaza = Int32.Parse(reader["AlmacenMegaPlaza"].ToString());
                PromocionTemporalDetalle.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                PromocionTemporalDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PromocionTemporalDetalle.AlmacenAviacion2 = Int32.Parse(reader["AlmacenAviacion2"].ToString());
                PromocionTemporalDetalle.AlmacenSanMiguel = Int32.Parse(reader["AlmacenSanMiguel"].ToString());
                PromocionTemporalDetalle.TipoOper = 4;
                PromocionTemporalDetallelist.Add(PromocionTemporalDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PromocionTemporalDetallelist;
        }

        public List<PromocionTemporalDetalleBE> ListaTipoClienteFormapago(int IdEmpresa, int IdTipoCliente, int IdFormaPago)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionTemporalDetalle_ListaTipoClienteFormapago");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, IdFormaPago);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PromocionTemporalDetalleBE> PromocionTemporalDetallelist = new List<PromocionTemporalDetalleBE>();
            PromocionTemporalDetalleBE PromocionTemporalDetalle;
            while (reader.Read())
            {
                PromocionTemporalDetalle = new PromocionTemporalDetalleBE();
                PromocionTemporalDetalle.IdPromocionTemporalDetalle = Int32.Parse(reader["IdPromocionTemporalDetalle"].ToString());
                PromocionTemporalDetalle.IdPromocionTemporal = Int32.Parse(reader["IdPromocionTemporal"].ToString());
                PromocionTemporalDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                PromocionTemporalDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                PromocionTemporalDetalle.NombreProducto = reader["NombreProducto"].ToString();
                PromocionTemporalDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PromocionTemporalDetalle.DescLineaProducto = reader["DescLineaProducto"].ToString();
                PromocionTemporalDetalle.Precio = Decimal.Parse(reader["Precio"].ToString());
                PromocionTemporalDetalle.Precio2 = Decimal.Parse(reader["Precio2"].ToString());
                PromocionTemporalDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                PromocionTemporalDetalle.DescuentoActual = Decimal.Parse(reader["DescuentoActual"].ToString());
                PromocionTemporalDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PromocionTemporalDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PromocionTemporalDetallelist.Add(PromocionTemporalDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PromocionTemporalDetallelist;
        }

        public PromocionTemporalDetalleBE Selecciona(int IdEmpresa, int IdTipoCliente, int IdFormaPago, int IdTienda, int IdTipoVenta, int IdProducto, bool TraerIdTemDet)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionTemporalDetalle_SeleccionaTipoClienteFormapago");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, IdFormaPago);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdTipoVenta", DbType.Int32, IdTipoVenta);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pTraerIdTemDet", DbType.Boolean, TraerIdTemDet);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PromocionTemporalDetalleBE PromocionTemporalDetalle = null;
            while (reader.Read())
            {
                PromocionTemporalDetalle = new PromocionTemporalDetalleBE();
                PromocionTemporalDetalle.IdPromocionTemporalDetalle = Int32.Parse(reader["IdPromocionTemporalDetalle"].ToString());
                PromocionTemporalDetalle.IdPromocionTemporal = Int32.Parse(reader["IdPromocionTemporal"].ToString());
                PromocionTemporalDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                PromocionTemporalDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                PromocionTemporalDetalle.NombreProducto = reader["NombreProducto"].ToString();
                PromocionTemporalDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PromocionTemporalDetalle.DescLineaProducto = reader["DescLineaProducto"].ToString();
                PromocionTemporalDetalle.Precio = Decimal.Parse(reader["Precio"].ToString());
                PromocionTemporalDetalle.Precio2 = Decimal.Parse(reader["Precio2"].ToString());
                PromocionTemporalDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                PromocionTemporalDetalle.DescuentoActual = Decimal.Parse(reader["DescuentoActual"].ToString());
                PromocionTemporalDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PromocionTemporalDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return PromocionTemporalDetalle;
        }
        public List<PromocionTemporalDetalleBE> Selecciona_Lista(int IdEmpresa, int IdTipoCliente, int IdFormaPago, int IdTienda, int IdTipoVenta, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionTemporalDetalle_SeleccionaTipoClienteFormapago_new");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, IdFormaPago);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdTipoVenta", DbType.Int32, IdTipoVenta);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PromocionTemporalDetalleBE> PromocionTemporalDetallelist = new List<PromocionTemporalDetalleBE>();
            PromocionTemporalDetalleBE PromocionTemporalDetalle;
            while (reader.Read())
            {
                PromocionTemporalDetalle = new PromocionTemporalDetalleBE();
                PromocionTemporalDetalle.IdPromocionTemporalDetalle = Int32.Parse(reader["IdPromocionTemporalDetalle"].ToString());
                PromocionTemporalDetalle.IdPromocionTemporal = Int32.Parse(reader["IdPromocionTemporal"].ToString());
                PromocionTemporalDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                PromocionTemporalDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                PromocionTemporalDetalle.NombreProducto = reader["NombreProducto"].ToString();
                PromocionTemporalDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PromocionTemporalDetalle.DescLineaProducto = reader["DescLineaProducto"].ToString();
                PromocionTemporalDetalle.Precio = Decimal.Parse(reader["Precio"].ToString());
                PromocionTemporalDetalle.Precio2 = Decimal.Parse(reader["Precio2"].ToString());
                PromocionTemporalDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                PromocionTemporalDetalle.DescuentoActual = Decimal.Parse(reader["DescuentoActual"].ToString());
                PromocionTemporalDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PromocionTemporalDetalle.FlagClienteMayorista = Boolean.Parse(reader["FlagClienteMayorista"].ToString());
                PromocionTemporalDetalle.FlagClienteFinal = Boolean.Parse(reader["FlagClienteFinal"].ToString());
                PromocionTemporalDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PromocionTemporalDetallelist.Add(PromocionTemporalDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PromocionTemporalDetallelist;
        }
        public PromocionTemporalDetalleBE SeleccionaUltimo(int IdEmpresa, int IdTipoCliente, int IdFormaPago, int IdTienda, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionTemporalDetalle_SeleccionaUltimoTipoClienteFormapago");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, IdFormaPago);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PromocionTemporalDetalleBE PromocionTemporalDetalle = null;
            while (reader.Read())
            {
                PromocionTemporalDetalle = new PromocionTemporalDetalleBE();
                PromocionTemporalDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                PromocionTemporalDetalle.Precio2 = Decimal.Parse(reader["Precio2"].ToString());
                PromocionTemporalDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                PromocionTemporalDetalle.DsctoEcommerce = Decimal.Parse(reader["DsctoEcommerce"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return PromocionTemporalDetalle;
        }


    }
}
