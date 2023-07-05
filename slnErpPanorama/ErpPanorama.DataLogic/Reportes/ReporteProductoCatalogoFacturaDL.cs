using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteProductoCatalogoFacturaDL
    {
        public List<ReporteProductoCatalogoFacturaBE> Listado(int IdEmpresa, int IdFacturaCompra, int IdTipoCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProductoCatalogoFactura");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, IdFacturaCompra);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProductoCatalogoFacturaBE> ProductoCatalogoFacturalist = new List<ReporteProductoCatalogoFacturaBE>();
            ReporteProductoCatalogoFacturaBE ProductoCatalogoFactura;
            while (reader.Read())
            {
                ProductoCatalogoFactura = new ReporteProductoCatalogoFacturaBE();
                ProductoCatalogoFactura.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ProductoCatalogoFactura.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ProductoCatalogoFactura.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ProductoCatalogoFactura.CodigoPanorama = reader["CodigoPanorama"].ToString();
                ProductoCatalogoFactura.Abreviatura = reader["Abreviatura"].ToString();
                ProductoCatalogoFactura.DescLineaProducto = reader["DescLineaProducto"].ToString();
                ProductoCatalogoFactura.DescModeloProducto = reader["DescModeloProducto"].ToString();
                ProductoCatalogoFactura.DescMaterial = reader["DescMaterial"].ToString();
                ProductoCatalogoFactura.DescMarca = reader["DescMarca"].ToString();
                ProductoCatalogoFactura.DescProcedencia = reader["DescProcedencia"].ToString();
                ProductoCatalogoFactura.NombreProducto = reader["NombreProducto"].ToString();
                ProductoCatalogoFactura.Descripcion = reader["Descripcion"].ToString();
                ProductoCatalogoFactura.Peso = Decimal.Parse(reader["Peso"].ToString());
                ProductoCatalogoFactura.Medida = reader["Medida"].ToString();
                ProductoCatalogoFactura.CodigoBarra = reader["CodigoBarra"].ToString();
                ProductoCatalogoFactura.Imagen = (byte[])reader["Imagen"];
                ProductoCatalogoFactura.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                ProductoCatalogoFactura.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                ProductoCatalogoFactura.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ProductoCatalogoFactura.DescuentoAB = Decimal.Parse(reader["DescuentoAB"].ToString());
                ProductoCatalogoFactura.FlagDescuentoAB = Boolean.Parse(reader["FlagDescuentoAB"].ToString());
                ProductoCatalogoFactura.StockBultos = Int32.Parse(reader["StockBultos"].ToString());
                ProductoCatalogoFactura.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                ProductoCatalogoFactura.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                ProductoCatalogoFactura.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                ProductoCatalogoFactura.Observacion = reader["Observacion"].ToString();
                ProductoCatalogoFactura.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ProductoCatalogoFactura.TipoCambioMinorista = Decimal.Parse(reader["TipoCambioMinorista"].ToString());
                ProductoCatalogoFactura.FlagEstado = Boolean.Parse(reader["Flagestado"].ToString());
                ProductoCatalogoFactura.TcListaPrecioCD = Decimal.Parse(reader["TcListaPrecioCD"].ToString());
                
                ProductoCatalogoFacturalist.Add(ProductoCatalogoFactura);
            }
            reader.Close();
            reader.Dispose();
            return ProductoCatalogoFacturalist;
        }

        public List<ReporteProductoCatalogoFacturaBE> ListadoSolicitudCompra(int IdEmpresa, int IdSolicitudCompra, int IdTipoCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProductoCatalogoSolicitudCompra");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdSolicitudCompra", DbType.Int32, IdSolicitudCompra);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProductoCatalogoFacturaBE> ProductoCatalogoFacturalist = new List<ReporteProductoCatalogoFacturaBE>();
            ReporteProductoCatalogoFacturaBE ProductoCatalogoFactura;
            while (reader.Read())
            {
                ProductoCatalogoFactura = new ReporteProductoCatalogoFacturaBE();
                ProductoCatalogoFactura.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ProductoCatalogoFactura.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ProductoCatalogoFactura.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ProductoCatalogoFactura.CodigoPanorama = reader["CodigoPanorama"].ToString();
                ProductoCatalogoFactura.Abreviatura = reader["Abreviatura"].ToString();
                ProductoCatalogoFactura.DescLineaProducto = reader["DescLineaProducto"].ToString();
                ProductoCatalogoFactura.DescModeloProducto = reader["DescModeloProducto"].ToString();
                ProductoCatalogoFactura.DescMaterial = reader["DescMaterial"].ToString();
                ProductoCatalogoFactura.DescMarca = reader["DescMarca"].ToString();
                ProductoCatalogoFactura.DescProcedencia = reader["DescProcedencia"].ToString();
                ProductoCatalogoFactura.NombreProducto = reader["NombreProducto"].ToString();
                ProductoCatalogoFactura.Descripcion = reader["Descripcion"].ToString();
                ProductoCatalogoFactura.Peso = Decimal.Parse(reader["Peso"].ToString());
                ProductoCatalogoFactura.Medida = reader["Medida"].ToString();
                ProductoCatalogoFactura.CodigoBarra = reader["CodigoBarra"].ToString();
                ProductoCatalogoFactura.Imagen = (byte[])reader["Imagen"];
                ProductoCatalogoFactura.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                ProductoCatalogoFactura.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                ProductoCatalogoFactura.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ProductoCatalogoFactura.DescuentoAB = Decimal.Parse(reader["DescuentoAB"].ToString());
                ProductoCatalogoFactura.FlagDescuentoAB = Boolean.Parse(reader["FlagDescuentoAB"].ToString());
                ProductoCatalogoFactura.StockBultos = Int32.Parse(reader["StockBultos"].ToString());
                ProductoCatalogoFactura.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                ProductoCatalogoFactura.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                ProductoCatalogoFactura.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                ProductoCatalogoFactura.Observacion = reader["Observacion"].ToString();
                ProductoCatalogoFactura.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ProductoCatalogoFactura.TipoCambioMinorista = Decimal.Parse(reader["TipoCambioMinorista"].ToString());
                ProductoCatalogoFactura.TcListaPrecioCD = Decimal.Parse(reader["TcListaPrecioCD"].ToString());
                ProductoCatalogoFactura.FlagEstado = Boolean.Parse(reader["Flagestado"].ToString());
                ProductoCatalogoFacturalist.Add(ProductoCatalogoFactura);
            }
            reader.Close();
            reader.Dispose();
            return ProductoCatalogoFacturalist;
        }

    }
}
