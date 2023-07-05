using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class BloqueDL
    {
        public BloqueDL() { }

        public void Inserta(BloqueBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bloque_Inserta");

            db.AddInParameter(dbCommand, "pIdBloque", DbType.Int32, pItem.IdBloque);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, pItem.IdSector);
            db.AddInParameter(dbCommand, "pDescBloque", DbType.String, pItem.DescBloque);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(BloqueBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bloque_Actualiza");

            db.AddInParameter(dbCommand, "pIdBloque", DbType.Int32, pItem.IdBloque);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, pItem.IdSector);
            db.AddInParameter(dbCommand, "pDescBloque", DbType.String, pItem.DescBloque);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(BloqueBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bloque_Elimina");

            db.AddInParameter(dbCommand, "pIdBloque", DbType.Int32, pItem.IdBloque);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<BloqueBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int IdAlmacen, int IdSector)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bloque_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, IdSector);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<BloqueBE> Bloquelist = new List<BloqueBE>();
            BloqueBE Bloque;
            while (reader.Read())
            {
                Bloque = new BloqueBE();
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
