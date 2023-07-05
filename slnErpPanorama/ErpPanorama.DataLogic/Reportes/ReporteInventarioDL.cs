using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteInventarioDL
    {
        public List<ReporteInventarioBE> Listado(int IdEmpresa, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInventario");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInventarioBE> Inventariolist = new List<ReporteInventarioBE>();
            ReporteInventarioBE Inventario;
            while (reader.Read())
            {
                Inventario = new ReporteInventarioBE();
                Inventario.DescTienda = reader["DescTienda"].ToString();
                Inventario.DescAlmacen = reader["DescAlmacen"].ToString();
                Inventario.CodigoProveedor = reader["codigoProveedor"].ToString();
                Inventario.NombreProducto = reader["nombreProducto"].ToString();
                Inventario.Abreviatura = reader["Abreviatura"].ToString();
                Inventario.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Inventario.Ubicacion = reader["Ubicacion"].ToString();
                Inventario.DescVendedor = reader["DescVendedor"].ToString();
                Inventario.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Inventario.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Inventariolist.Add(Inventario);
            }
            reader.Close();
            reader.Dispose();
            return Inventariolist;
        }
    }
}
