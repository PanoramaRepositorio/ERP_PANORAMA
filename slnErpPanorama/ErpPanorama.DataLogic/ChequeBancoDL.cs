using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ChequeBancoDL
    {
        public ChequeBancoDL() { }

        public void Inserta(ChequeBancoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ChequeBanco_Inserta");

            db.AddInParameter(dbCommand, "pIdChequeBanco", DbType.Int32, pItem.IdChequeBanco);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pTCambio", DbType.Decimal, pItem.TCambio);
            db.AddInParameter(dbCommand, "pNumeroCheque", DbType.String, pItem.NumeroCheque);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ChequeBancoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ChequeBanco_Actualiza");

            db.AddInParameter(dbCommand, "pIdChequeBanco", DbType.Int32, pItem.IdChequeBanco);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pTCambio", DbType.Decimal, pItem.TCambio);
            db.AddInParameter(dbCommand, "pNumeroCheque", DbType.String, pItem.NumeroCheque);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ChequeBancoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ChequeBanco_Elimina");

            db.AddInParameter(dbCommand, "pIdChequeBanco", DbType.Int32, pItem.IdChequeBanco);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ChequeBancoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ChequeBanco_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ChequeBancoBE> ChequeBancolist = new List<ChequeBancoBE>();
            ChequeBancoBE ChequeBanco;
            while (reader.Read())
            {
                ChequeBanco = new ChequeBancoBE();
                ChequeBanco.IdChequeBanco = Int32.Parse(reader["IdChequeBanco"].ToString());
                ChequeBanco.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ChequeBanco.IdBanco = Int32.Parse(reader["IdBanco"].ToString());
                ChequeBanco.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                ChequeBanco.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                ChequeBanco.TCambio = Decimal.Parse(reader["TCambio"].ToString());
                ChequeBanco.RazonSocial = reader["RazonSocial"].ToString();
                ChequeBanco.DesBanco = reader["DesBanco"].ToString();
                ChequeBanco.DesMoneda = reader["DesMoneda"].ToString();
                ChequeBanco.NumeroCheque = reader["NumeroCheque"].ToString();
                ChequeBanco.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                ChequeBanco.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                ChequeBancolist.Add(ChequeBanco);
            }
            reader.Close();
            reader.Dispose();
            return ChequeBancolist;
        }

        public ChequeBancoBE Consulta(int IdChequeBanco)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ChequeBanco_Consulta");
            db.AddInParameter(dbCommand, "pIdChequeBanco", DbType.Int32, IdChequeBanco);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ChequeBancoBE ChequeBanco = new ChequeBancoBE();
            while (reader.Read())
            {
                ChequeBanco = new ChequeBancoBE();
                ChequeBanco.IdChequeBanco = Int32.Parse(reader["IdChequeBanco"].ToString());
                ChequeBanco.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ChequeBanco.IdBanco = Int32.Parse(reader["IdBanco"].ToString());
                ChequeBanco.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                ChequeBanco.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                ChequeBanco.TCambio = Decimal.Parse(reader["TCambio"].ToString());
                ChequeBanco.RazonSocial = reader["RazonSocial"].ToString();
                ChequeBanco.DesBanco = reader["DesBanco"].ToString();
                ChequeBanco.DesMoneda = reader["DesMoneda"].ToString();
                ChequeBanco.NumeroCheque = reader["NumeroCheque"].ToString();
                ChequeBanco.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                ChequeBanco.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ChequeBanco;
        }

        public int Valida(ChequeBancoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ChequeBanco_Valida");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            int Cantidad = 0;
            while (reader.Read())
            {
                Cantidad = Int32.Parse(reader["cantidad"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Cantidad;
        }
    }
}
