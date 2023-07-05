using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteProductoCatalogoPromocionTemporalDL
    {
        public List<ReporteProductoCatalogoPromocionTemporalBE> Listado(int IdPromocionTemporal)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProductoCatologoPromocionTemporalDetalle");
            db.AddInParameter(dbCommand, "pIdPromocionTemporal", DbType.Int32, IdPromocionTemporal);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProductoCatalogoPromocionTemporalBE> ProductoCatalogoPromocionTemporallist = new List<ReporteProductoCatalogoPromocionTemporalBE>();
            ReporteProductoCatalogoPromocionTemporalBE ProductoCatalogoPromocionTemporal;
            while (reader.Read())
            {
                ProductoCatalogoPromocionTemporal = new ReporteProductoCatalogoPromocionTemporalBE();
                ProductoCatalogoPromocionTemporal.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ProductoCatalogoPromocionTemporal.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ProductoCatalogoPromocionTemporal.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ProductoCatalogoPromocionTemporal.CodigoPanorama = reader["CodigoPanorama"].ToString();
                ProductoCatalogoPromocionTemporal.Abreviatura = reader["Abreviatura"].ToString();
                ProductoCatalogoPromocionTemporal.DescLineaProducto = reader["DescLineaProducto"].ToString();
                ProductoCatalogoPromocionTemporal.DescModeloProducto = reader["DescModeloProducto"].ToString();
                ProductoCatalogoPromocionTemporal.DescMaterial = reader["DescMaterial"].ToString();
                ProductoCatalogoPromocionTemporal.DescMarca = reader["DescMarca"].ToString();
                ProductoCatalogoPromocionTemporal.DescProcedencia = reader["DescProcedencia"].ToString();
                ProductoCatalogoPromocionTemporal.NombreProducto = reader["NombreProducto"].ToString();
                ProductoCatalogoPromocionTemporal.Descripcion = reader["Descripcion"].ToString();
                ProductoCatalogoPromocionTemporal.Peso = Decimal.Parse(reader["Peso"].ToString());
                ProductoCatalogoPromocionTemporal.Medida = reader["Medida"].ToString();
                ProductoCatalogoPromocionTemporal.CodigoBarra = reader["CodigoBarra"].ToString();
                ProductoCatalogoPromocionTemporal.Imagen = (byte[])reader["Imagen"];
                ProductoCatalogoPromocionTemporal.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                ProductoCatalogoPromocionTemporal.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                ProductoCatalogoPromocionTemporal.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ProductoCatalogoPromocionTemporal.StockBultos = Int32.Parse(reader["StockBultos"].ToString());
                ProductoCatalogoPromocionTemporal.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                ProductoCatalogoPromocionTemporal.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                ProductoCatalogoPromocionTemporal.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                ProductoCatalogoPromocionTemporal.Observacion = reader["Observacion"].ToString();
                ProductoCatalogoPromocionTemporal.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ProductoCatalogoPromocionTemporal.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                ProductoCatalogoPromocionTemporal.TipoCambioMinorista = Decimal.Parse(reader["TipoCambioMinorista"].ToString());
                ProductoCatalogoPromocionTemporal.FlagEstado = Boolean.Parse(reader["Flagestado"].ToString());
                ProductoCatalogoPromocionTemporallist.Add(ProductoCatalogoPromocionTemporal);
            }
            reader.Close();
            reader.Dispose();
            return ProductoCatalogoPromocionTemporallist;
        }

        public List<ReporteProductoCatalogoPromocionTemporalBE> ListadoLineaProducto(int IdPromocionTemporal, int IdLineaProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProductoCatologoPromocionTemporalDetallePorLinea");
            db.AddInParameter(dbCommand, "pIdPromocionTemporal", DbType.Int32, IdPromocionTemporal);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProductoCatalogoPromocionTemporalBE> ProductoCatalogoPromocionTemporallist = new List<ReporteProductoCatalogoPromocionTemporalBE>();
            ReporteProductoCatalogoPromocionTemporalBE ProductoCatalogoPromocionTemporal;
            while (reader.Read())
            {
                ProductoCatalogoPromocionTemporal = new ReporteProductoCatalogoPromocionTemporalBE();
                ProductoCatalogoPromocionTemporal.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ProductoCatalogoPromocionTemporal.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ProductoCatalogoPromocionTemporal.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ProductoCatalogoPromocionTemporal.CodigoPanorama = reader["CodigoPanorama"].ToString();
                ProductoCatalogoPromocionTemporal.Abreviatura = reader["Abreviatura"].ToString();
                ProductoCatalogoPromocionTemporal.DescLineaProducto = reader["DescLineaProducto"].ToString();
                ProductoCatalogoPromocionTemporal.DescModeloProducto = reader["DescModeloProducto"].ToString();
                ProductoCatalogoPromocionTemporal.DescMaterial = reader["DescMaterial"].ToString();
                ProductoCatalogoPromocionTemporal.DescMarca = reader["DescMarca"].ToString();
                ProductoCatalogoPromocionTemporal.DescProcedencia = reader["DescProcedencia"].ToString();
                ProductoCatalogoPromocionTemporal.NombreProducto = reader["NombreProducto"].ToString();
                ProductoCatalogoPromocionTemporal.Descripcion = reader["Descripcion"].ToString();
                ProductoCatalogoPromocionTemporal.Peso = Decimal.Parse(reader["Peso"].ToString());
                ProductoCatalogoPromocionTemporal.Medida = reader["Medida"].ToString();
                ProductoCatalogoPromocionTemporal.CodigoBarra = reader["CodigoBarra"].ToString();
                ProductoCatalogoPromocionTemporal.Imagen = (byte[])reader["Imagen"];
                ProductoCatalogoPromocionTemporal.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                ProductoCatalogoPromocionTemporal.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                ProductoCatalogoPromocionTemporal.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ProductoCatalogoPromocionTemporal.StockBultos = Int32.Parse(reader["StockBultos"].ToString());
                ProductoCatalogoPromocionTemporal.StockTotal = Int32.Parse(reader["StockTotal"].ToString());
                ProductoCatalogoPromocionTemporal.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                ProductoCatalogoPromocionTemporal.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                ProductoCatalogoPromocionTemporal.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                ProductoCatalogoPromocionTemporal.Observacion = reader["Observacion"].ToString();
                ProductoCatalogoPromocionTemporal.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ProductoCatalogoPromocionTemporal.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                ProductoCatalogoPromocionTemporal.TipoCambioMinorista = Decimal.Parse(reader["TipoCambioMinorista"].ToString());
                ProductoCatalogoPromocionTemporal.FlagEstado = Boolean.Parse(reader["Flagestado"].ToString());
                ProductoCatalogoPromocionTemporallist.Add(ProductoCatalogoPromocionTemporal);
            }
            reader.Close();
            reader.Dispose();
            return ProductoCatalogoPromocionTemporallist;
        }

        public List<ReporteProductoCatalogoPromocionTemporalBE> ListadoSubLineaProducto(int IdPromocionTemporal, int IdSubLineaProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProductoCatologoPromocionTemporalDetallePorSubLinea");
            db.AddInParameter(dbCommand, "pIdPromocionTemporal", DbType.Int32, IdPromocionTemporal);
            db.AddInParameter(dbCommand, "pIdSubLineaProducto", DbType.Int32, IdSubLineaProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProductoCatalogoPromocionTemporalBE> ProductoCatalogoPromocionTemporallist = new List<ReporteProductoCatalogoPromocionTemporalBE>();
            ReporteProductoCatalogoPromocionTemporalBE ProductoCatalogoPromocionTemporal;
            while (reader.Read())
            {
                ProductoCatalogoPromocionTemporal = new ReporteProductoCatalogoPromocionTemporalBE();
                ProductoCatalogoPromocionTemporal.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ProductoCatalogoPromocionTemporal.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ProductoCatalogoPromocionTemporal.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ProductoCatalogoPromocionTemporal.CodigoPanorama = reader["CodigoPanorama"].ToString();
                ProductoCatalogoPromocionTemporal.Abreviatura = reader["Abreviatura"].ToString();
                ProductoCatalogoPromocionTemporal.DescLineaProducto = reader["DescLineaProducto"].ToString();
                ProductoCatalogoPromocionTemporal.DescModeloProducto = reader["DescModeloProducto"].ToString();
                ProductoCatalogoPromocionTemporal.DescMaterial = reader["DescMaterial"].ToString();
                ProductoCatalogoPromocionTemporal.DescMarca = reader["DescMarca"].ToString();
                ProductoCatalogoPromocionTemporal.DescProcedencia = reader["DescProcedencia"].ToString();
                ProductoCatalogoPromocionTemporal.NombreProducto = reader["NombreProducto"].ToString();
                ProductoCatalogoPromocionTemporal.Descripcion = reader["Descripcion"].ToString();
                ProductoCatalogoPromocionTemporal.Peso = Decimal.Parse(reader["Peso"].ToString());
                ProductoCatalogoPromocionTemporal.Medida = reader["Medida"].ToString();
                ProductoCatalogoPromocionTemporal.CodigoBarra = reader["CodigoBarra"].ToString();
                ProductoCatalogoPromocionTemporal.Imagen = (byte[])reader["Imagen"];
                ProductoCatalogoPromocionTemporal.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                ProductoCatalogoPromocionTemporal.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                ProductoCatalogoPromocionTemporal.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ProductoCatalogoPromocionTemporal.StockBultos = Int32.Parse(reader["StockBultos"].ToString());
                ProductoCatalogoPromocionTemporal.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                ProductoCatalogoPromocionTemporal.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                ProductoCatalogoPromocionTemporal.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                ProductoCatalogoPromocionTemporal.Observacion = reader["Observacion"].ToString();
                ProductoCatalogoPromocionTemporal.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ProductoCatalogoPromocionTemporal.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                ProductoCatalogoPromocionTemporal.TipoCambioMinorista = Decimal.Parse(reader["TipoCambioMinorista"].ToString());
                ProductoCatalogoPromocionTemporal.FlagEstado = Boolean.Parse(reader["Flagestado"].ToString());
                ProductoCatalogoPromocionTemporallist.Add(ProductoCatalogoPromocionTemporal);
            }
            reader.Close();
            reader.Dispose();
            return ProductoCatalogoPromocionTemporallist;
        }

    }
}
