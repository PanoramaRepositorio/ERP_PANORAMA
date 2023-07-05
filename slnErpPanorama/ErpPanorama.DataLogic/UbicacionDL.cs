using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class UbicacionDL
    {
        public UbicacionDL() { }

        public void Inserta(UbicacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ubicacion_Inserta");

            db.AddInParameter(dbCommand, "pIdUbicacion", DbType.Int32, pItem.IdUbicacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pDescUbicacion", DbType.String, pItem.DescUbicacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(UbicacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ubicacion_Actualiza");

            db.AddInParameter(dbCommand, "pIdUbicacion", DbType.Int32, pItem.IdUbicacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pDescUbicacion", DbType.String, pItem.DescUbicacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(UbicacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ubicacion_Elimina");

            db.AddInParameter(dbCommand, "pIdUbicacion", DbType.Int32, pItem.IdUbicacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<UbicacionBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ubicacion_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UbicacionBE> Ubicacionlist = new List<UbicacionBE>();
            UbicacionBE Ubicacion;
            while (reader.Read())
            {
                Ubicacion = new UbicacionBE();
                Ubicacion.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Ubicacion.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Ubicacion.IdUbicacion = Int32.Parse(reader["idUbicacion"].ToString());
                Ubicacion.DescUbicacion = reader["descUbicacion"].ToString();
                Ubicacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Ubicacionlist.Add(Ubicacion);
            }
            reader.Close();
            reader.Dispose();
            return Ubicacionlist;
        }
    }
}
