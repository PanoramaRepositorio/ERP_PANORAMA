using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteAlmacenDL
    {
        public List<ReporteAlmacenBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAlmacen");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAlmacenBE> Almacenlist = new List<ReporteAlmacenBE>();
            ReporteAlmacenBE Almacen;
            while (reader.Read())
            {
                Almacen = new ReporteAlmacenBE();
                Almacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Almacen.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Almacen.DescTienda = reader["DescTienda"].ToString();
                Almacen.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Almacen.DescAlmacen = reader["descAlmacen"].ToString();
                Almacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Almacenlist.Add(Almacen);
            }
            reader.Close();
            reader.Dispose();
            return Almacenlist;
        }
    }
}