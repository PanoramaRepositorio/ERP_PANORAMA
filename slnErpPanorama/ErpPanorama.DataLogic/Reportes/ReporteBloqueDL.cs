using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteBloqueDL
    {
        public List<ReporteBloqueBE> Listado(int IdEmpresa, int IdTienda, int IdAlmacen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptBloque");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteBloqueBE> Bloquelist = new List<ReporteBloqueBE>();
            ReporteBloqueBE Bloque;
            while (reader.Read())
            {
                Bloque = new ReporteBloqueBE();
                Bloque.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Bloque.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Bloque.DescTienda = reader["DescTienda"].ToString();
                Bloque.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Bloque.DescAlmacen = reader["DescAlmacen"].ToString();
                Bloque.IdSector = Int32.Parse(reader["IdSector"].ToString());
                Bloque.DescSector = reader["DescSector"].ToString();
                Bloque.IdBloque = Int32.Parse(reader["idBloque"].ToString());
                Bloque.DescBloque = reader["descBloque"].ToString();
                Bloque.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Bloquelist.Add(Bloque);
            }
            reader.Close();
            reader.Dispose();
            return Bloquelist;
        }
    }
}
