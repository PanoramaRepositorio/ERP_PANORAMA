using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteUbicacionProductoDL
    {
        public List<ReporteUbicacionProductoBE> Listado()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptUbicacionProducto");
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteUbicacionProductoBE> UbicacionProductolist = new List<ReporteUbicacionProductoBE>();
            ReporteUbicacionProductoBE UbicacionProducto;
            while (reader.Read())
            {
                UbicacionProducto = new ReporteUbicacionProductoBE();
                UbicacionProducto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                UbicacionProducto.DescAlmacen = reader["DescAlmacen"].ToString();
                UbicacionProducto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                UbicacionProducto.NombreProducto = reader["NombreProducto"].ToString();
                UbicacionProducto.Abreviatura = reader["Abreviatura"].ToString();
                UbicacionProducto.DescUbicacion = reader["DescUbicacion"].ToString();
                UbicacionProductolist.Add(UbicacionProducto);
            }
            reader.Close();
            reader.Dispose();
            return UbicacionProductolist;
        }
    }
}

