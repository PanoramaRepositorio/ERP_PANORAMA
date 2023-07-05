using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteProductoCatalogoPromocion2x1DL
    {
        public List<ReporteProductoCatalogoPromocion2x1BE> Listado(int IdPromocion2x1)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProductoCatologoPromocion2x1Detalle");
            db.AddInParameter(dbCommand, "pIdPromocion2x1", DbType.Int32, IdPromocion2x1);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProductoCatalogoPromocion2x1BE> ProductoCatalogoPromocion2x1list = new List<ReporteProductoCatalogoPromocion2x1BE>();
            ReporteProductoCatalogoPromocion2x1BE ProductoCatalogoPromocion2x1;
            while (reader.Read())
            {
                ProductoCatalogoPromocion2x1 = new ReporteProductoCatalogoPromocion2x1BE();
                ProductoCatalogoPromocion2x1.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ProductoCatalogoPromocion2x1.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ProductoCatalogoPromocion2x1.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ProductoCatalogoPromocion2x1.CodigoPanorama = reader["CodigoPanorama"].ToString();
                ProductoCatalogoPromocion2x1.Abreviatura = reader["Abreviatura"].ToString();
                ProductoCatalogoPromocion2x1.DescLineaProducto = reader["DescLineaProducto"].ToString();
                ProductoCatalogoPromocion2x1.DescModeloProducto = reader["DescModeloProducto"].ToString();
                ProductoCatalogoPromocion2x1.DescMaterial = reader["DescMaterial"].ToString();
                ProductoCatalogoPromocion2x1.DescMarca = reader["DescMarca"].ToString();
                ProductoCatalogoPromocion2x1.DescProcedencia = reader["DescProcedencia"].ToString();
                ProductoCatalogoPromocion2x1.NombreProducto = reader["NombreProducto"].ToString();
                ProductoCatalogoPromocion2x1.Descripcion = reader["Descripcion"].ToString();
                ProductoCatalogoPromocion2x1.Peso = Decimal.Parse(reader["Peso"].ToString());
                ProductoCatalogoPromocion2x1.Medida = reader["Medida"].ToString();
                ProductoCatalogoPromocion2x1.CodigoBarra = reader["CodigoBarra"].ToString();
                ProductoCatalogoPromocion2x1.Imagen = (byte[])reader["Imagen"];
                ProductoCatalogoPromocion2x1.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                ProductoCatalogoPromocion2x1.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                ProductoCatalogoPromocion2x1.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ProductoCatalogoPromocion2x1.StockBultos = Int32.Parse(reader["StockBultos"].ToString());
                ProductoCatalogoPromocion2x1.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                ProductoCatalogoPromocion2x1.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                ProductoCatalogoPromocion2x1.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                ProductoCatalogoPromocion2x1.Observacion = reader["Observacion"].ToString();
                ProductoCatalogoPromocion2x1.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ProductoCatalogoPromocion2x1.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                ProductoCatalogoPromocion2x1.TipoCambioMinorista = Decimal.Parse(reader["TipoCambioMinorista"].ToString());
                ProductoCatalogoPromocion2x1.FlagEstado = Boolean.Parse(reader["Flagestado"].ToString());
                ProductoCatalogoPromocion2x1list.Add(ProductoCatalogoPromocion2x1);
            }
            reader.Close();
            reader.Dispose();
            return ProductoCatalogoPromocion2x1list;
        }

        public List<ReporteProductoCatalogoPromocion2x1BE> ListadoLineaProducto(int IdPromocion2x1, int IdLineaProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProductoCatologoPromocion2x1DetallePorLinea");
            db.AddInParameter(dbCommand, "pIdPromocion2x1", DbType.Int32, IdPromocion2x1);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProductoCatalogoPromocion2x1BE> ProductoCatalogoPromocion2x1list = new List<ReporteProductoCatalogoPromocion2x1BE>();
            ReporteProductoCatalogoPromocion2x1BE ProductoCatalogoPromocion2x1;
            while (reader.Read())
            {
                ProductoCatalogoPromocion2x1 = new ReporteProductoCatalogoPromocion2x1BE();
                ProductoCatalogoPromocion2x1.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ProductoCatalogoPromocion2x1.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ProductoCatalogoPromocion2x1.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ProductoCatalogoPromocion2x1.CodigoPanorama = reader["CodigoPanorama"].ToString();
                ProductoCatalogoPromocion2x1.Abreviatura = reader["Abreviatura"].ToString();
                ProductoCatalogoPromocion2x1.DescLineaProducto = reader["DescLineaProducto"].ToString();
                ProductoCatalogoPromocion2x1.DescModeloProducto = reader["DescModeloProducto"].ToString();
                ProductoCatalogoPromocion2x1.DescMaterial = reader["DescMaterial"].ToString();
                ProductoCatalogoPromocion2x1.DescMarca = reader["DescMarca"].ToString();
                ProductoCatalogoPromocion2x1.DescProcedencia = reader["DescProcedencia"].ToString();
                ProductoCatalogoPromocion2x1.NombreProducto = reader["NombreProducto"].ToString();
                ProductoCatalogoPromocion2x1.Descripcion = reader["Descripcion"].ToString();
                ProductoCatalogoPromocion2x1.Peso = Decimal.Parse(reader["Peso"].ToString());
                ProductoCatalogoPromocion2x1.Medida = reader["Medida"].ToString();
                ProductoCatalogoPromocion2x1.CodigoBarra = reader["CodigoBarra"].ToString();
                ProductoCatalogoPromocion2x1.Imagen = (byte[])reader["Imagen"];
                ProductoCatalogoPromocion2x1.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                ProductoCatalogoPromocion2x1.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                ProductoCatalogoPromocion2x1.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ProductoCatalogoPromocion2x1.StockBultos = Int32.Parse(reader["StockBultos"].ToString());
                ProductoCatalogoPromocion2x1.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                ProductoCatalogoPromocion2x1.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                ProductoCatalogoPromocion2x1.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                ProductoCatalogoPromocion2x1.Observacion = reader["Observacion"].ToString();
                ProductoCatalogoPromocion2x1.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ProductoCatalogoPromocion2x1.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                ProductoCatalogoPromocion2x1.TipoCambioMinorista = Decimal.Parse(reader["TipoCambioMinorista"].ToString());
                ProductoCatalogoPromocion2x1.FlagEstado = Boolean.Parse(reader["Flagestado"].ToString());
                ProductoCatalogoPromocion2x1list.Add(ProductoCatalogoPromocion2x1);
            }
            reader.Close();
            reader.Dispose();
            return ProductoCatalogoPromocion2x1list;
        }

        public List<ReporteProductoCatalogoPromocion2x1BE> ListadoSubLineaProducto(int IdPromocion2x1, int IdSubLineaProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProductoCatologoPromocion2x1DetallePorSubLinea");
            db.AddInParameter(dbCommand, "pIdPromocion2x1", DbType.Int32, IdPromocion2x1);
            db.AddInParameter(dbCommand, "pIdSubLineaProducto", DbType.Int32, IdSubLineaProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProductoCatalogoPromocion2x1BE> ProductoCatalogoPromocion2x1list = new List<ReporteProductoCatalogoPromocion2x1BE>();
            ReporteProductoCatalogoPromocion2x1BE ProductoCatalogoPromocion2x1;
            while (reader.Read())
            {
                ProductoCatalogoPromocion2x1 = new ReporteProductoCatalogoPromocion2x1BE();
                ProductoCatalogoPromocion2x1.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ProductoCatalogoPromocion2x1.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ProductoCatalogoPromocion2x1.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ProductoCatalogoPromocion2x1.CodigoPanorama = reader["CodigoPanorama"].ToString();
                ProductoCatalogoPromocion2x1.Abreviatura = reader["Abreviatura"].ToString();
                ProductoCatalogoPromocion2x1.DescLineaProducto = reader["DescLineaProducto"].ToString();
                ProductoCatalogoPromocion2x1.DescModeloProducto = reader["DescModeloProducto"].ToString();
                ProductoCatalogoPromocion2x1.DescMaterial = reader["DescMaterial"].ToString();
                ProductoCatalogoPromocion2x1.DescMarca = reader["DescMarca"].ToString();
                ProductoCatalogoPromocion2x1.DescProcedencia = reader["DescProcedencia"].ToString();
                ProductoCatalogoPromocion2x1.NombreProducto = reader["NombreProducto"].ToString();
                ProductoCatalogoPromocion2x1.Descripcion = reader["Descripcion"].ToString();
                ProductoCatalogoPromocion2x1.Peso = Decimal.Parse(reader["Peso"].ToString());
                ProductoCatalogoPromocion2x1.Medida = reader["Medida"].ToString();
                ProductoCatalogoPromocion2x1.CodigoBarra = reader["CodigoBarra"].ToString();
                ProductoCatalogoPromocion2x1.Imagen = (byte[])reader["Imagen"];
                ProductoCatalogoPromocion2x1.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                ProductoCatalogoPromocion2x1.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                ProductoCatalogoPromocion2x1.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ProductoCatalogoPromocion2x1.StockBultos = Int32.Parse(reader["StockBultos"].ToString());
                ProductoCatalogoPromocion2x1.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                ProductoCatalogoPromocion2x1.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                ProductoCatalogoPromocion2x1.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                ProductoCatalogoPromocion2x1.Observacion = reader["Observacion"].ToString();
                ProductoCatalogoPromocion2x1.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ProductoCatalogoPromocion2x1.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                ProductoCatalogoPromocion2x1.TipoCambioMinorista = Decimal.Parse(reader["TipoCambioMinorista"].ToString());
                ProductoCatalogoPromocion2x1.FlagEstado = Boolean.Parse(reader["Flagestado"].ToString());
                ProductoCatalogoPromocion2x1list.Add(ProductoCatalogoPromocion2x1);
            }
            reader.Close();
            reader.Dispose();
            return ProductoCatalogoPromocion2x1list;
        }

    }
}
