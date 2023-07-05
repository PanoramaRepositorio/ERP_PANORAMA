using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;


namespace ErpPanorama.DataLogic
{
    public class ReporteProductoCatologoInvBultoDL
    {
        public List<ReporteProductoCatologoInvBultoBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProductoCatologoInvBulto");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProductoCatologoInvBultoBE> ProductoCatologoInvBultolist = new List<ReporteProductoCatologoInvBultoBE>();
            ReporteProductoCatologoInvBultoBE ProductoCatologoInvBulto;
            while (reader.Read())
            {
                ProductoCatologoInvBulto = new ReporteProductoCatologoInvBultoBE();
                ProductoCatologoInvBulto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ProductoCatologoInvBulto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ProductoCatologoInvBulto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ProductoCatologoInvBulto.CodigoPanorama = reader["CodigoPanorama"].ToString();
                ProductoCatologoInvBulto.Abreviatura = reader["Abreviatura"].ToString();
                ProductoCatologoInvBulto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                ProductoCatologoInvBulto.DescModeloProducto = reader["DescModeloProducto"].ToString();
                ProductoCatologoInvBulto.DescMaterial = reader["DescMaterial"].ToString();
                ProductoCatologoInvBulto.DescMarca = reader["DescMarca"].ToString();
                ProductoCatologoInvBulto.DescProcedencia = reader["DescProcedencia"].ToString();
                ProductoCatologoInvBulto.NombreProducto = reader["NombreProducto"].ToString();
                ProductoCatologoInvBulto.Descripcion = reader["Descripcion"].ToString();
                ProductoCatologoInvBulto.Peso = Decimal.Parse(reader["Peso"].ToString());
                ProductoCatologoInvBulto.Medida = reader["Medida"].ToString();
                ProductoCatologoInvBulto.CodigoBarra = reader["CodigoBarra"].ToString();
                ProductoCatologoInvBulto.Imagen = (byte[])reader["Imagen"];
                ProductoCatologoInvBulto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                ProductoCatologoInvBulto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                ProductoCatologoInvBulto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ProductoCatologoInvBulto.StockBultos = Int32.Parse(reader["StockBultos"].ToString());
                ProductoCatologoInvBulto.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                ProductoCatologoInvBulto.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                ProductoCatologoInvBulto.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                ProductoCatologoInvBulto.Observacion = reader["Observacion"].ToString();
                ProductoCatologoInvBulto.TipoCambioMinorista = Decimal.Parse(reader["TipoCambioMinorista"].ToString());
                ProductoCatologoInvBulto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ProductoCatologoInvBulto.FlagEstado = Boolean.Parse(reader["Flagestado"].ToString());
                ProductoCatologoInvBultolist.Add(ProductoCatologoInvBulto);
            }
            reader.Close();
            reader.Dispose();
            return ProductoCatologoInvBultolist;
        }

        public List<ReporteProductoCatologoInvBultoBE> ListadoPreNavidad(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProductoCatologoPrevNavidad");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProductoCatologoInvBultoBE> ProductoCatologoInvBultolist = new List<ReporteProductoCatologoInvBultoBE>();
            ReporteProductoCatologoInvBultoBE ProductoCatologoInvBulto;
            while (reader.Read())
            {
                ProductoCatologoInvBulto = new ReporteProductoCatologoInvBultoBE();
                ProductoCatologoInvBulto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ProductoCatologoInvBulto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ProductoCatologoInvBulto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ProductoCatologoInvBulto.CodigoPanorama = reader["CodigoPanorama"].ToString();
                ProductoCatologoInvBulto.Abreviatura = reader["Abreviatura"].ToString();
                ProductoCatologoInvBulto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                ProductoCatologoInvBulto.DescModeloProducto = reader["DescModeloProducto"].ToString();
                ProductoCatologoInvBulto.DescMaterial = reader["DescMaterial"].ToString();
                ProductoCatologoInvBulto.DescMarca = reader["DescMarca"].ToString();
                ProductoCatologoInvBulto.DescProcedencia = reader["DescProcedencia"].ToString();
                ProductoCatologoInvBulto.NombreProducto = reader["NombreProducto"].ToString();
                ProductoCatologoInvBulto.Descripcion = reader["Descripcion"].ToString();
                ProductoCatologoInvBulto.Peso = Decimal.Parse(reader["Peso"].ToString());
                ProductoCatologoInvBulto.Medida = reader["Medida"].ToString();
                ProductoCatologoInvBulto.CodigoBarra = reader["CodigoBarra"].ToString();
                ProductoCatologoInvBulto.Imagen = (byte[])reader["Imagen"];
                ProductoCatologoInvBulto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                ProductoCatologoInvBulto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                ProductoCatologoInvBulto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ProductoCatologoInvBulto.StockBultos = Int32.Parse(reader["StockBultos"].ToString());
                ProductoCatologoInvBulto.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                ProductoCatologoInvBulto.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                ProductoCatologoInvBulto.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                ProductoCatologoInvBulto.Observacion = reader["Observacion"].ToString();
                ProductoCatologoInvBulto.TipoCambioMinorista = Decimal.Parse(reader["TipoCambioMinorista"].ToString());
                ProductoCatologoInvBulto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ProductoCatologoInvBulto.FlagEstado = Boolean.Parse(reader["Flagestado"].ToString());
                ProductoCatologoInvBultolist.Add(ProductoCatologoInvBulto);
            }
            reader.Close();
            reader.Dispose();
            return ProductoCatologoInvBultolist;
        }
    }
}
