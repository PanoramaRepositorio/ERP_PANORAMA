using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class PreventaDL
    {
        public PreventaDL() { }

        public Int32 Inserta(PreventaBE pItem)
        {
            Int32 intIdCliente = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Preventa_Inserta");

            db.AddOutParameter(dbCommand,"pIdPreventa", DbType.Int32, pItem.IdPreventa);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescPreventa", DbType.String, pItem.DescPreventa);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdCliente = (int)db.GetParameterValue(dbCommand, "pIdPreventa");

            return intIdCliente;
        }

        public void Actualiza(PreventaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Preventa_Actualiza");

            db.AddInParameter(dbCommand, "pIdPreventa", DbType.Int32, pItem.IdPreventa);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescPreventa", DbType.String, pItem.DescPreventa);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(PreventaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Preventa_Elimina");

            db.AddInParameter(dbCommand, "pIdPreventa", DbType.Int32, pItem.IdPreventa);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<PreventaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Preventa_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PreventaBE> Preventalist = new List<PreventaBE>();
            PreventaBE Preventa;
            while (reader.Read())
            {
                Preventa = new PreventaBE();
                Preventa.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Preventa.IdPreventa = Int32.Parse(reader["IdPreventa"].ToString());
                Preventa.DescPreventa = reader["DescPreventa"].ToString();
                Preventa.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                Preventa.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Preventa.Observacion = reader["Observacion"].ToString();
                Preventa.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Preventalist.Add(Preventa);
            }
            reader.Close();
            reader.Dispose();
            return Preventalist;
        }
    }
}
