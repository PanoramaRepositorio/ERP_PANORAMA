using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ChequeDL
    {
        public ChequeDL() { }

        public void Inserta(ChequeBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cheque_Inserta");

            db.AddInParameter(dbCommand, "pIdCheque", DbType.Int32, pItem.IdCheque);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "IdChequeBanco", DbType.Int32, pItem.IdChequeBanco);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pTCambio", DbType.Decimal, pItem.TCambio);
            db.AddInParameter(dbCommand, "pMonto", DbType.Decimal, pItem.Monto);
            db.AddInParameter(dbCommand, "pMontoSoles", DbType.Decimal, pItem.MontoSoles);
            db.AddInParameter(dbCommand, "pRazonSocial", DbType.String, pItem.RazonSocial);
            db.AddInParameter(dbCommand, "pPortador", DbType.String, pItem.Portador);
            db.AddInParameter(dbCommand, "pDestino", DbType.String, pItem.Destino);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pNumeroCheque", DbType.String, pItem.NumeroCheque);
            db.AddInParameter(dbCommand, "pFechaEmision", DbType.DateTime, pItem.FechaEmision);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.AddInParameter(dbCommand, "pNumRecibo", DbType.String, pItem.NumRecibo);
            db.AddInParameter(dbCommand, "pNumCajaChica", DbType.String, pItem.NumCajaChica);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ChequeBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cheque_Actualiza");

            db.AddInParameter(dbCommand, "pIdCheque", DbType.Int32, pItem.IdCheque);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "IdChequeBanco", DbType.Int32, pItem.IdChequeBanco);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pTCambio", DbType.Decimal, pItem.TCambio);
            db.AddInParameter(dbCommand, "pMonto", DbType.Decimal, pItem.Monto);
            db.AddInParameter(dbCommand, "pMontoSoles", DbType.Decimal, pItem.MontoSoles);
            db.AddInParameter(dbCommand, "pRazonSocial", DbType.String, pItem.RazonSocial);
            db.AddInParameter(dbCommand, "pPortador", DbType.String, pItem.Portador);
            db.AddInParameter(dbCommand, "pDestino", DbType.String, pItem.Destino);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pNumeroCheque", DbType.String, pItem.NumeroCheque);
            db.AddInParameter(dbCommand, "pFechaEmision", DbType.DateTime, pItem.FechaEmision);
            //db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.AddInParameter(dbCommand, "pNumRecibo", DbType.String, pItem.NumRecibo);
            db.AddInParameter(dbCommand, "pNumCajaChica", DbType.String, pItem.NumCajaChica);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ChequeBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cheque_Elimina");

            db.AddInParameter(dbCommand, "pIdCheque", DbType.Int32, pItem.IdCheque);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);

            db.ExecuteNonQuery(dbCommand);
        }

        public void AnulaCheque(ChequeBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cheque_Anula");

            db.AddInParameter(dbCommand, "pIdCheque", DbType.Int32, pItem.IdCheque);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ChequeBE> ListaTodosActivo(int IdEmpresa, DateTime pFecDesde, DateTime pFecHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cheque_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, pFecDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, pFecHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ChequeBE> Chequelist = new List<ChequeBE>();
            ChequeBE Cheque;
            while (reader.Read())
            {
                Cheque = new ChequeBE();
                Cheque.IdCheque = Int32.Parse(reader["IdCheque"].ToString());
                Cheque.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Cheque.IdBanco = Int32.Parse(reader["IdBanco"].ToString());
                Cheque.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                Cheque.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Cheque.IdChequeBanco = Int32.Parse(reader["IdChequeBanco"].ToString());
                Cheque.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Cheque.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Cheque.TCambio = Decimal.Parse(reader["TCambio"].ToString());
                Cheque.Monto = Decimal.Parse(reader["Monto"].ToString());
                Cheque.MontoSoles = Decimal.Parse(reader["MontoSoles"].ToString());
                Cheque.NumeroCheque = reader["NumeroCheque"].ToString();
                Cheque.RazonSocial = reader["RazonSocial"].ToString();
                Cheque.DesBanco = reader["DesBanco"].ToString();
                Cheque.DesMoneda = reader["DesMoneda"].ToString();
                Cheque.DesMotivo = reader["DesMotivo"].ToString();
                Cheque.DesSituacion = reader["DesSituacion"].ToString();
                Cheque.Portador = reader["Portador"].ToString();
                Cheque.Destino = reader["Destino"].ToString();
                Cheque.Observacion = reader["Observacion"].ToString();
                Cheque.FechaEmision = DateTime.Parse(reader["FechaEmision"].ToString());
                Cheque.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Cheque.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

                Cheque.NumRecibo = reader["NumRecibo"].ToString();
                Cheque.NumCajaChica = reader["NumCajaChica"].ToString();
                Chequelist.Add(Cheque);
            }
            reader.Close();
            reader.Dispose();
            return Chequelist;
        }

        public ChequeBE Consulta(int IdCheque)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cheque_ConsultaNumeracionPost");
            db.AddInParameter(dbCommand, "pIdCheque", DbType.Int32, IdCheque);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ChequeBE Cheque = new ChequeBE();
            while (reader.Read())
            {
                Cheque = new ChequeBE();

                Cheque.IdCheque = Int32.Parse(reader["IdCheque"].ToString());
                Cheque.NumeroCheque = reader["NumeroCheque"].ToString();

                Cheque.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Cheque.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Cheque.IdBanco = Int32.Parse(reader["IdBanco"].ToString());
                Cheque.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());

                Cheque.FechaEmision = DateTime.Parse(reader["FechaEmision"].ToString());
                Cheque.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());

                Cheque.Portador = reader["Portador"].ToString();
                Cheque.Destino = reader["Destino"].ToString();
                Cheque.Observacion = reader["Observacion"].ToString();
                Cheque.Monto = Decimal.Parse(reader["Monto"].ToString());

                Cheque.NumRecibo = reader["NumRecibo"].ToString();
                Cheque.NumCajaChica = reader["NumCajaChica"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return Cheque;
        }

        public List<ChequeBE> GetMoneda(int IdEmpresa, int IdBanco)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cheque_GetMoneda");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, IdBanco);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ChequeBE> Chequelist = new List<ChequeBE>();
            ChequeBE Cheque;
            while (reader.Read())
            {
                Cheque = new ChequeBE();
                Cheque.IdChequeBanco = Int32.Parse(reader["IdChequeBanco"].ToString());
                Cheque.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                Cheque.DesMoneda = reader["DesMoneda"].ToString();
                Chequelist.Add(Cheque);
            }
            reader.Close();
            reader.Dispose();
            return Chequelist;
        }

        public ChequeBancoBE NumeroCheque(int IdEmpresa, int IdBanco, int IdMoneda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cheque_NumeroCheque");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, IdBanco);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, IdMoneda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ChequeBancoBE Cheque = new ChequeBancoBE();
            while (reader.Read())
            {
                Cheque = new ChequeBancoBE();
                Cheque.IdChequeBanco = Int32.Parse(reader["IdChequeBanco"].ToString());
                Cheque.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Cheque.IdBanco = Int32.Parse(reader["IdBanco"].ToString());
                Cheque.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                Cheque.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Cheque.TCambio = Decimal.Parse(reader["TCambio"].ToString());
                Cheque.RazonSocial = reader["RazonSocial"].ToString();
                Cheque.DesBanco = reader["DesBanco"].ToString();
                Cheque.DesMoneda = reader["DesMoneda"].ToString();
                Cheque.NumeroCheque = reader["NumeroCheque"].ToString();
                Cheque.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Cheque.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Cheque;
        }
    }
}
