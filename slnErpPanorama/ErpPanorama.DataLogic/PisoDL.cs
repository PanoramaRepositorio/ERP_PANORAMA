using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class PisoDL
    {
        public PisoDL() { }

        public void Inserta(PisoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Piso_Inserta");

            db.AddInParameter(dbCommand, "pIdPiso", DbType.Int32, pItem.IdPiso);
            db.AddInParameter(dbCommand, "pIdUbicacion", DbType.Int32, pItem.IdUbicacion);
            db.AddInParameter(dbCommand, "pDescPiso", DbType.String, pItem.DescPiso);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(PisoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Piso_Actualiza");

            db.AddInParameter(dbCommand, "pIdPiso", DbType.Int32, pItem.IdPiso);
            db.AddInParameter(dbCommand, "pIdUbicacion", DbType.Int32, pItem.IdUbicacion);
            db.AddInParameter(dbCommand, "pDescPiso", DbType.String, pItem.DescPiso);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(PisoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Piso_Elimina");

            db.AddInParameter(dbCommand, "pIdPiso", DbType.Int32, pItem.IdPiso);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<PisoBE> ListaTodosActivo(int IdEmpresa, int IdUbicacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Piso_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUbicacion", DbType.Int32, IdUbicacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PisoBE> Pisolist = new List<PisoBE>();
            PisoBE Piso;
            while (reader.Read())
            {
                Piso = new PisoBE();
                Piso.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Piso.IdUbicacion = Int32.Parse(reader["IdUbicacion"].ToString());
                Piso.DescUbicacion = reader["DescUbicacion"].ToString();
                Piso.IdPiso = Int32.Parse(reader["idPiso"].ToString());
                Piso.DescPiso = reader["descPiso"].ToString();
                Piso.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Pisolist.Add(Piso);
            }
            reader.Close();
            reader.Dispose();
            return Pisolist;
        }
    }
}
