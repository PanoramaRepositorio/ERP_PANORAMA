using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteProductoCatalogoProformaDL
    {
        public List<ReporteProductoCatalogoProformaBE> Listado(int IdEmpresa, int IdProforma, int IdTipoCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProductoCatologoProforma");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProforma", DbType.Int32, IdProforma);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProductoCatalogoProformaBE> ProductoCatalogoProformalist = new List<ReporteProductoCatalogoProformaBE>();
            ReporteProductoCatalogoProformaBE ProductoCatalogoProforma;
            while (reader.Read())
            {
                ProductoCatalogoProforma = new ReporteProductoCatalogoProformaBE();
                ProductoCatalogoProforma.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ProductoCatalogoProforma.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ProductoCatalogoProforma.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ProductoCatalogoProforma.CodigoPanorama = reader["CodigoPanorama"].ToString();
                ProductoCatalogoProforma.Abreviatura = reader["Abreviatura"].ToString();
                ProductoCatalogoProforma.DescLineaProducto = reader["DescLineaProducto"].ToString();
                ProductoCatalogoProforma.DescModeloProducto = reader["DescModeloProducto"].ToString();
                ProductoCatalogoProforma.DescMaterial = reader["DescMaterial"].ToString();
                ProductoCatalogoProforma.DescMarca = reader["DescMarca"].ToString();
                ProductoCatalogoProforma.DescProcedencia = reader["DescProcedencia"].ToString();
                ProductoCatalogoProforma.NombreProducto = reader["NombreProducto"].ToString();
                ProductoCatalogoProforma.Descripcion = reader["Descripcion"].ToString();
                ProductoCatalogoProforma.Peso = Decimal.Parse(reader["Peso"].ToString());
                ProductoCatalogoProforma.Medida = reader["Medida"].ToString();
                ProductoCatalogoProforma.CodigoBarra = reader["CodigoBarra"].ToString();
                ProductoCatalogoProforma.Imagen = (byte[])reader["Imagen"];
                ProductoCatalogoProforma.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                ProductoCatalogoProforma.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                ProductoCatalogoProforma.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ProductoCatalogoProforma.StockBultos = Int32.Parse(reader["StockBultos"].ToString());
                ProductoCatalogoProforma.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                ProductoCatalogoProforma.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                ProductoCatalogoProforma.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                ProductoCatalogoProforma.Observacion = reader["Observacion"].ToString();
                ProductoCatalogoProforma.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ProductoCatalogoProforma.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                ProductoCatalogoProforma.TipoCambioMinorista = Decimal.Parse(reader["TipoCambioMinorista"].ToString());
                ProductoCatalogoProforma.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ProductoCatalogoProforma.FlagEstado = Boolean.Parse(reader["Flagestado"].ToString());
                ProductoCatalogoProformalist.Add(ProductoCatalogoProforma);
            }
            reader.Close();
            reader.Dispose();
            return ProductoCatalogoProformalist;
        }
    }
}
