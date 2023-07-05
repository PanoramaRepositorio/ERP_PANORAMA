using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class PlaAfpDL
    {
        public PlaAfpDL() { }

        public void Inserta(PlaAfpBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlaAfp_Inserta");

            db.AddInParameter(dbCommand, "pIdPlaAfp", DbType.Int32, pItem.IdPlaAfp);
            db.AddInParameter(dbCommand, "pDescPlaAfp", DbType.String, pItem.DescPlaAfp);
            db.AddInParameter(dbCommand, "pAporteObligatorio", DbType.Decimal, pItem.AporteObligatorio);
            db.AddInParameter(dbCommand, "pComision", DbType.Decimal, pItem.Comision);
            db.AddInParameter(dbCommand, "pPrimaSeguro", DbType.Decimal, pItem.PrimaSeguro);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(PlaAfpBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlaAfp_Actualiza");

            db.AddInParameter(dbCommand, "pIdPlaAfp", DbType.Int32, pItem.IdPlaAfp);
            db.AddInParameter(dbCommand, "pDescPlaAfp", DbType.String, pItem.DescPlaAfp);
            db.AddInParameter(dbCommand, "pAporteObligatorio", DbType.Decimal, pItem.AporteObligatorio);
            db.AddInParameter(dbCommand, "pComision", DbType.Decimal, pItem.Comision);
            db.AddInParameter(dbCommand, "pPrimaSeguro", DbType.Decimal, pItem.PrimaSeguro);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(PlaAfpBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlaAfp_Elimina");

            db.AddInParameter(dbCommand, "pIdPlaAfp", DbType.Int32, pItem.IdPlaAfp);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<PlaAfpBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlaAfp_ListaTodosActivo");
            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PlaAfpBE> PlaAfplist = new List<PlaAfpBE>();
            PlaAfpBE PlaAfp;
            while (reader.Read())
            {
                PlaAfp = new PlaAfpBE();
                PlaAfp.IdPlaAfp = Int32.Parse(reader["idPlaAfp"].ToString());
                PlaAfp.DescPlaAfp = reader["descPlaAfp"].ToString();
                PlaAfp.AporteObligatorio = Decimal.Parse(reader["AporteObligatorio"].ToString());
                PlaAfp.Comision = Decimal.Parse(reader["Comision"].ToString());
                PlaAfp.PrimaSeguro = Decimal.Parse(reader["PrimaSeguro"].ToString());
                PlaAfp.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                PlaAfplist.Add(PlaAfp);
            }
            reader.Close();
            reader.Dispose();
            return PlaAfplist;
        }

        public PlaAfpBE Selecciona( int IdPlaAfp)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PlaAfp_Selecciona");
            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPlaAfp", DbType.Int32, IdPlaAfp);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PlaAfpBE PlaAfp = null;
            while (reader.Read())
            {
                PlaAfp = new PlaAfpBE();
                PlaAfp.IdPlaAfp = Int32.Parse(reader["idPlaAfp"].ToString());
                PlaAfp.DescPlaAfp = reader["descPlaAfp"].ToString();
                PlaAfp.AporteObligatorio = Decimal.Parse(reader["AporteObligatorio"].ToString());
                PlaAfp.Comision = Decimal.Parse(reader["Comision"].ToString());
                PlaAfp.PrimaSeguro = Decimal.Parse(reader["PrimaSeguro"].ToString());
                PlaAfp.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return PlaAfp;
        }
    }
}
