using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ComboDL
    {
        public ComboDL() { }

        public Int32 Inserta(ComboBE pItem)
        {
            Int32 intIdCliente = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Combo_Inserta");

            db.AddOutParameter(dbCommand, "pIdCombo", DbType.Int32, pItem.IdCombo);
            db.AddInParameter(dbCommand, "pDescCombo", DbType.String, pItem.DescCombo);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);

            intIdCliente = (int)db.GetParameterValue(dbCommand, "pIdCombo");

            return intIdCliente;
        }

        public void Actualiza(ComboBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Combo_Actualiza");

            db.AddInParameter(dbCommand, "pIdCombo", DbType.Int32, pItem.IdCombo);
            db.AddInParameter(dbCommand, "pDescCombo", DbType.String, pItem.DescCombo);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ComboBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Combo_Elimina");

            db.AddInParameter(dbCommand, "pIdCombo", DbType.Int32, pItem.IdCombo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ComboBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Combo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ComboBE> Combolist = new List<ComboBE>();
            ComboBE Combo;
            while (reader.Read())
            {
                Combo = new ComboBE();
                Combo.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Combo.IdCombo = Int32.Parse(reader["idCombo"].ToString());
                Combo.DescCombo = reader["DescCombo"].ToString();
                Combo.Total = Decimal.Parse(reader["Total"].ToString());
                Combo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Combolist.Add(Combo);
            }
            reader.Close();
            reader.Dispose();
            return Combolist;
        }
    }
}
