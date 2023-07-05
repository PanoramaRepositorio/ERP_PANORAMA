using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteSectorDL
    {
        public List<ReporteSectorBE> Listado(int IdEmpresa, int IdTienda, int IdAlmacen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptSector");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteSectorBE> Sectorlist = new List<ReporteSectorBE>();
            ReporteSectorBE Sector;
            while (reader.Read())
            {
                Sector = new ReporteSectorBE();
                Sector.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Sector.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Sector.DescTienda = reader["DescTienda"].ToString();
                Sector.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Sector.DescAlmacen = reader["DescAlmacen"].ToString();
                Sector.IdSector = Int32.Parse(reader["idSector"].ToString());
                Sector.DescSector = reader["descSector"].ToString();
                Sector.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Sectorlist.Add(Sector);
            }
            reader.Close();
            reader.Dispose();
            return Sectorlist;
        }
    }
}
