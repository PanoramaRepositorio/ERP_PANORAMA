using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class SectorDL
    {
        public SectorDL() { }

        public void Inserta(SectorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sector_Inserta");

            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, pItem.IdSector);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pDescSector", DbType.String, pItem.DescSector);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(SectorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sector_Actualiza");

            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, pItem.IdSector);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pDescSector", DbType.String, pItem.DescSector);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(SectorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sector_Elimina");

            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, pItem.IdSector);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<SectorBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int IdAlmacen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sector_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SectorBE> Sectorlist = new List<SectorBE>();
            SectorBE Sector;
            while (reader.Read())
            {
                Sector = new SectorBE();
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
