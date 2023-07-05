using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class CajaEgresoDL
    {
        public CajaEgresoDL() { }

        public void Inserta(CajaEgresoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgreso_Inserta");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pFecApertura", DbType.DateTime, pItem.FecApertura);
            db.AddInParameter(dbCommand, "pSaldoInicial", DbType.Decimal, pItem.SaldoInicial);
            db.AddInParameter(dbCommand, "pUsuarioCreacion", DbType.String, pItem.UsuarioCreacion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);

            db.AddInParameter(dbCommand, "pTipoPersona", DbType.Int32, pItem.TipoPersona);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pRecibio", DbType.String, pItem.Recibio);

            db.AddInParameter(dbCommand, "pNroRecibo", DbType.String, pItem.NroRecibo);
            db.AddInParameter(dbCommand, "pFechaRecibo", DbType.DateTime, pItem.FechaRecibo);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(CajaEgresoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgreso_Actualiza");

            db.AddInParameter(dbCommand, "pIdCajaEgreso", DbType.Int32, pItem.IdCajaEgreso);
            db.AddInParameter(dbCommand, "pAbono", DbType.Decimal, pItem.Abono);
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pFechaAbono", DbType.DateTime, pItem.FechaAbono);
            db.AddInParameter(dbCommand, "pUsuarioCierre", DbType.String, pItem.UsuarioCierre);

            db.ExecuteNonQuery(dbCommand);
        }

        public void RevisionCaja(CajaEgresoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgreso_ActualizaRevision");

            db.AddInParameter(dbCommand, "pIdCajaEgreso", DbType.Int32, pItem.IdCajaEgreso);
            db.AddInParameter(dbCommand, "pFechaRevision", DbType.Date, pItem.FechaRevision);
            db.AddInParameter(dbCommand, "pFlagRevision", DbType.Decimal, pItem.FlagRevision);
            db.AddInParameter(dbCommand, "pUsuarioRevision", DbType.String, pItem.UsuarioRevision);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(CajaEgresoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaCierre_Elimina");

            //db.AddInParameter(dbCommand, "pIdCajaCierre", DbType.Int32, pItem.IdCajaCierre);

            db.ExecuteNonQuery(dbCommand);
        }

        public void EliminaFecha(CajaEgresoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaCierre_EliminaFecha");

            //db.AddInParameter(dbCommand, "pFecha ", DbType.DateTime, pItem.Fecha);
            //db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<CajaEgresoBE> ListaTodosActivo(DateTime pFecDesde, DateTime pFecHasta, int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgreso_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, pFecDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, pFecHasta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaEgresoBE> CajaCierrelist = new List<CajaEgresoBE>();
            CajaEgresoBE CajaEgreso;
            while (reader.Read())
            {
                CajaEgreso = new CajaEgresoBE();
                CajaEgreso.IdCajaEgreso = Int32.Parse(reader["IdCajaEgreso"].ToString());
                CajaEgreso.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CajaEgreso.NombreEmpresa = reader["NombreEmpresa"].ToString();
                CajaEgreso.NumCaja =  reader["NumCaja"].ToString();
                CajaEgreso.NombreCaja = reader["NombreCaja"].ToString();
                CajaEgreso.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                CajaEgreso.DescMoneda = reader["Moneda"].ToString();
                CajaEgreso.FecApertura = DateTime.Parse(reader["FecApertura"].ToString());
                CajaEgreso.FecCierre = reader.IsDBNull(reader.GetOrdinal("FecCierre")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FecCierre")); //DateTime.Parse(reader["FecCierre"].ToString());
                CajaEgreso.SaldoInicial = Decimal.Parse(reader["SaldoInicial"].ToString());
                CajaEgreso.SaldoActual = Decimal.Parse(reader["SaldoActual"].ToString());
                CajaEgreso.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                CajaEgreso.Situacion = reader["Situacion"].ToString();
                CajaEgreso.UsuarioCreacion = reader["UsuarioCreacion"].ToString();
                CajaEgreso.Mes = reader["Mes"].ToString();

                CajaEgreso.Banco = reader["Banco"].ToString();
                CajaEgreso.Abono = Decimal.Parse(reader["Abono"].ToString());

                CajaEgreso.NroRecibo = reader["Recibo"].ToString();
                CajaEgreso.FechaRecibo = reader.IsDBNull(reader.GetOrdinal("FechaRecibo")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecibo"));

                CajaEgreso.FechaRevision = reader.IsDBNull(reader.GetOrdinal("FechaRevision")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRevision"));
                CajaEgreso.FlagRevision = Boolean.Parse(reader["FlagRevision"].ToString());    //    Boolean.Parse(reader["FlagRevision"].ToString());
                CajaEgreso.UsuarioRevision =  reader["UsuarioRevision"].ToString();

                CajaCierrelist.Add(CajaEgreso);
            }
            reader.Close();
            reader.Dispose();
            return CajaCierrelist;
        }



        public List<CajaEgresoBE> ListaFechaCaja(DateTime FechaDesde, DateTime FechaHasta, int IdCaja)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaCierre_ListaFecha");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaEgresoBE> CajaCierrelist = new List<CajaEgresoBE>();
            CajaEgresoBE CajaCierre;
            while (reader.Read())
            {
                CajaCierre = new CajaEgresoBE();
                //CajaCierre.IdCajaCierre = Int32.Parse(reader["IdCajaCierre"].ToString());
                //CajaCierre.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                //CajaCierre.DescTienda = reader["DescTienda"].ToString();
                //CajaCierre.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                //CajaCierre.DescCaja = reader["DescCaja"].ToString();
                //CajaCierre.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                //CajaCierre.TotalVisa = Int32.Parse(reader["TotalVisa"].ToString());
                //CajaCierre.TotalMastercard = Int32.Parse(reader["TotalMastercard"].ToString());
                //CajaCierre.Usuario = reader["Usuario"].ToString();
                //CajaCierre.Maquina = reader["Maquina"].ToString();
                //CajaCierre.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CajaCierrelist.Add(CajaCierre);
            }
            reader.Close();
            reader.Dispose();
            return CajaCierrelist;
        }

        public List<CajaEgresoBE> Resumen(int pIdCajaEgreso)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgreso_Resumen");
            db.AddInParameter(dbCommand, "pIdCajaEgreso", DbType.Int32, pIdCajaEgreso);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaEgresoBE> CajaCierrelist = new List<CajaEgresoBE>();
            CajaEgresoBE CajaEgreso;
            while (reader.Read())
            {
                CajaEgreso = new CajaEgresoBE();
                CajaEgreso.IdCajaEgreso = Int32.Parse(reader["IdCajaEgreso"].ToString());
                CajaEgreso.Documento = reader["Documento"].ToString();
                CajaEgreso.Monto = Decimal.Parse(reader["Monto"].ToString());

                CajaCierrelist.Add(CajaEgreso);
            }
            reader.Close();
            reader.Dispose();
            return CajaCierrelist;
        }

    }
}
