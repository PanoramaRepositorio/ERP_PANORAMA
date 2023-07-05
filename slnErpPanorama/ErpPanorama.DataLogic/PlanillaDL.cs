using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class PlanillaDL
    {
         public PlanillaDL() { }

        public Int32 Inserta(PlanillaBE pItem)
        {
            Int32 intIdPlanilla = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Planilla_Inserta");

            db.AddOutParameter(dbCommand, "pIdPlanilla", DbType.Int32, pItem.IdPlanilla);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pDiasEfectivoTrabajado", DbType.Int32, pItem.DiasEfectivoTrabajado);
            db.AddInParameter(dbCommand, "pHorasOrdinarias", DbType.Int32, pItem.HorasOrdinarias);
            db.AddInParameter(dbCommand, "pHorasExtrasDiarias", DbType.Decimal, pItem.HorasExtrasDiarias);
            db.AddInParameter(dbCommand, "pRemuneracionVital", DbType.Decimal, pItem.RemuneracionVital);
            db.AddInParameter(dbCommand, "pAportacionSeguro", DbType.Decimal, pItem.AportacionSeguro);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdPlanilla = (int)db.GetParameterValue(dbCommand, "pIdPlanilla");

            return intIdPlanilla;

        }

        public void Actualiza(PlanillaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Planilla_Actualiza");

            db.AddInParameter(dbCommand, "pIdPlanilla", DbType.Int32, pItem.IdPlanilla);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pDiasEfectivoTrabajado", DbType.Int32, pItem.DiasEfectivoTrabajado);
            db.AddInParameter(dbCommand, "pHorasOrdinarias", DbType.Int32, pItem.HorasOrdinarias);
            db.AddInParameter(dbCommand, "pHorasExtrasDiarias", DbType.Decimal, pItem.HorasExtrasDiarias);
            db.AddInParameter(dbCommand, "pRemuneracionVital", DbType.Decimal, pItem.RemuneracionVital);
            db.AddInParameter(dbCommand, "pAportacionSeguro", DbType.Decimal, pItem.AportacionSeguro);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(PlanillaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Planilla_Elimina");

            db.AddInParameter(dbCommand, "pIdPlanilla", DbType.Int32, pItem.IdPlanilla);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public List<PlanillaBE> ListaTodosActivo(int IdEmpresa, int Periodo, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Planilla_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PlanillaBE> Planillalist = new List<PlanillaBE>();
            PlanillaBE Planilla;
            while (reader.Read())
            {
                Planilla = new PlanillaBE();
                Planilla.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Planilla.RazonSocial = reader["RazonSocial"].ToString();
                Planilla.IdPlanilla = Int32.Parse(reader["idPlanilla"].ToString());
                Planilla.Periodo = Int32.Parse(reader["periodo"].ToString());
                Planilla.Mes = Int32.Parse(reader["mes"].ToString());
                Planilla.DescMes = reader["descmes"].ToString();
                Planilla.DiasEfectivoTrabajado = Int32.Parse(reader["DiasEfectivoTrabajado"].ToString());
                Planilla.HorasOrdinarias = Int32.Parse(reader["HorasOrdinarias"].ToString());
                Planilla.HorasExtrasDiarias = Decimal.Parse(reader["HorasExtrasDiarias"].ToString());
                Planilla.RemuneracionVital = Decimal.Parse(reader["RemuneracionVital"].ToString());
                Planilla.AportacionSeguro = Decimal.Parse(reader["AportacionSeguro"].ToString());
                Planilla.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Planillalist.Add(Planilla);
            }
            reader.Close();
            reader.Dispose();
            return Planillalist;
        }

        public PlanillaBE Selecciona(int IdPlanilla)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Planilla_Selecciona");
            db.AddInParameter(dbCommand, "pIdPlanilla", DbType.Int32, IdPlanilla);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PlanillaBE Planilla = null;
            while (reader.Read())
            {
                Planilla = new PlanillaBE();
                Planilla.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Planilla.RazonSocial = reader["RazonSocial"].ToString();
                Planilla.IdPlanilla = Int32.Parse(reader["idPlanilla"].ToString());
                Planilla.Periodo = Int32.Parse(reader["periodo"].ToString());
                Planilla.Mes = Int32.Parse(reader["mes"].ToString());
                Planilla.DescMes = reader["descmes"].ToString();
                Planilla.DiasEfectivoTrabajado = Int32.Parse(reader["DiasEfectivoTrabajado"].ToString());
                Planilla.HorasOrdinarias = Int32.Parse(reader["HorasOrdinarias"].ToString());
                Planilla.HorasExtrasDiarias = Decimal.Parse(reader["HorasExtrasDiarias"].ToString());
                Planilla.RemuneracionVital = Decimal.Parse(reader["RemuneracionVital"].ToString());
                Planilla.AportacionSeguro = Decimal.Parse(reader["AportacionSeguro"].ToString());
                Planilla.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Planilla;
        }


    }
}
