using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteProductoDL
    {
        public List<ReporteProductoBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProducto");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProductoBE> Productolist = new List<ReporteProductoBE>();
            ReporteProductoBE Producto;
            while (reader.Read())
            {
                Producto = new ReporteProductoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.CodigoPanorama = reader["CodigoPanorama"].ToString();
                Producto.IdUnidadMedida = reader.IsDBNull(reader.GetOrdinal("IdUnidadMedida")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdUnidadMedida"));
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.IdLineaProducto = reader.IsDBNull(reader.GetOrdinal("IdLineaProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdLineaProducto"));
                Producto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Producto.IdModeloProducto = reader.IsDBNull(reader.GetOrdinal("IdModeloProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdModeloProducto"));
                Producto.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Producto.IdMaterial = reader.IsDBNull(reader.GetOrdinal("IdMaterial")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMaterial"));
                Producto.DescMaterial = reader["DescMaterial"].ToString();
                Producto.IdMarca = reader.IsDBNull(reader.GetOrdinal("IdMarca")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMarca"));
                Producto.DescMarca = reader["DescMarca"].ToString();
                Producto.IdProcedencia = reader.IsDBNull(reader.GetOrdinal("IdProcedencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProcedencia"));
                Producto.DescProcedencia = reader["DescProcedencia"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Descripcion = reader["Descripcion"].ToString();
                Producto.Peso = Decimal.Parse(reader["Peso"].ToString());
                Producto.Medida = reader["Medida"].ToString();
                Producto.CodigoBarra = reader["CodigoBarra"].ToString();
                //Producto.Imagen = (byte[])reader["Imagen"];
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                Producto.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                Producto.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                Producto.Observacion = reader["Observacion"].ToString();
                Producto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Producto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }
    }
}
