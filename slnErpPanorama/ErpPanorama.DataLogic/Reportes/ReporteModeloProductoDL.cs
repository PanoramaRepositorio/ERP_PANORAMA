using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteModeloProductoDL
    {
        public List<ReporteModeloProductoBE> Listado(int IdEmpresa, int IdLineaProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptModeloProducto");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteModeloProductoBE> ModeloProductolist = new List<ReporteModeloProductoBE>();
            ReporteModeloProductoBE ModeloProducto;
            while (reader.Read())
            {
                ModeloProducto = new ReporteModeloProductoBE();
                ModeloProducto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ModeloProducto.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                ModeloProducto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                ModeloProducto.IdModeloProducto = Int32.Parse(reader["idModeloProducto"].ToString());
                ModeloProducto.DescModeloProducto = reader["descModeloProducto"].ToString();
                ModeloProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ModeloProductolist.Add(ModeloProducto);
            }
            reader.Close();
            reader.Dispose();
            return ModeloProductolist;
        }
    }
}

