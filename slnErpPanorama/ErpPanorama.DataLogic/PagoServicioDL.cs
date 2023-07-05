using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class PagoServicioDL
	{
		public PagoServicioDL() { }

		public Int32 Inserta(PagoServicioBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PagoServicio_Inserta");

			db.AddOutParameter(dbCommand, "pIdPagoServicio", DbType.Int32, pItem.IdPagoServicio);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pIdTipoServicio", DbType.Int32, pItem.IdTipoServicio);
			db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
			db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
			db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
			db.AddInParameter(dbCommand, "pNumeroCuotas", DbType.Int32, pItem.NumeroCuotas);
			db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
			db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
			db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
			db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
			db.AddInParameter(dbCommand, "pTipoRecordatorio", DbType.Int32, pItem.TipoRecordatorio);
			db.AddInParameter(dbCommand, "pDiasAntes", DbType.Int32, pItem.DiasAntes);
			db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdPagoServicio");

			return Id;
		}

		public void Actualiza(PagoServicioBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PagoServicio_Actualiza");

			db.AddInParameter(dbCommand, "pIdPagoServicio", DbType.Int32, pItem.IdPagoServicio);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pIdTipoServicio", DbType.Int32, pItem.IdTipoServicio);
			db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
			db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
			db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
			db.AddInParameter(dbCommand, "pNumeroCuotas", DbType.Int32, pItem.NumeroCuotas);
			db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
			db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
			db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
			db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
			db.AddInParameter(dbCommand, "pTipoRecordatorio", DbType.Int32, pItem.TipoRecordatorio);
			db.AddInParameter(dbCommand, "pDiasAntes", DbType.Int32, pItem.DiasAntes);
			db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(PagoServicioBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PagoServicio_Elimina");

			db.AddInParameter(dbCommand, "pIdPagoServicio", DbType.Int32, pItem.IdPagoServicio);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<PagoServicioBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PagoServicio_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<PagoServicioBE> PagoServiciolist = new List<PagoServicioBE>();
			PagoServicioBE PagoServicio;
			while (reader.Read())
			{
				PagoServicio = new PagoServicioBE();
				PagoServicio.IdPagoServicio = Int32.Parse(reader["IdPagoServicio"].ToString());
				PagoServicio.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				PagoServicio.Periodo = Int32.Parse(reader["Periodo"].ToString());
				PagoServicio.IdTipoServicio = Int32.Parse(reader["IdTipoServicio"].ToString());
				PagoServicio.Numero = reader["Numero"].ToString();
				PagoServicio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PagoServicio.IdProveedor = reader.IsDBNull(reader.GetOrdinal("IdProveedor")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdProveedor"));
                PagoServicio.IdBanco = reader.IsDBNull(reader.GetOrdinal("IdBanco")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdBanco"));
                PagoServicio.Concepto = reader["Concepto"].ToString();
				PagoServicio.NumeroCuotas = Int32.Parse(reader["NumeroCuotas"].ToString());
				PagoServicio.TipoMovimiento = reader["TipoMovimiento"].ToString();
				PagoServicio.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
				PagoServicio.Importe = Decimal.Parse(reader["Importe"].ToString());
				PagoServicio.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                PagoServicio.TipoRecordatorio = Int32.Parse(reader["TipoRecordatorio"].ToString());
				PagoServicio.DiasAntes = Int32.Parse(reader["DiasAntes"].ToString());
				PagoServicio.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
				PagoServicio.Observacion = reader["Observacion"].ToString();
				PagoServicio.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				PagoServiciolist.Add(PagoServicio);
			}
			reader.Close();
			reader.Dispose();
			return PagoServiciolist;
		}

        public List<PagoServicioBE> ListaFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PagoServicio_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PagoServicioBE> PagoServiciolist = new List<PagoServicioBE>();
            PagoServicioBE PagoServicio;
            while (reader.Read())
            {
                PagoServicio = new PagoServicioBE();
                PagoServicio.IdPagoServicio = Int32.Parse(reader["IdPagoServicio"].ToString());
                PagoServicio.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PagoServicio.Periodo = Int32.Parse(reader["Periodo"].ToString());
                PagoServicio.IdTipoServicio = Int32.Parse(reader["IdTipoServicio"].ToString());
                PagoServicio.Numero = reader["Numero"].ToString();
                PagoServicio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PagoServicio.IdProveedor = reader.IsDBNull(reader.GetOrdinal("IdProveedor")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdProveedor"));
                PagoServicio.IdBanco = reader.IsDBNull(reader.GetOrdinal("IdBanco")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdBanco"));
                PagoServicio.Concepto = reader["Concepto"].ToString();
                PagoServicio.NumeroCuotas = Int32.Parse(reader["NumeroCuotas"].ToString());
                PagoServicio.TipoMovimiento = reader["TipoMovimiento"].ToString();
                PagoServicio.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                PagoServicio.Importe = Decimal.Parse(reader["Importe"].ToString());
                PagoServicio.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                PagoServicio.TipoRecordatorio = Int32.Parse(reader["TipoRecordatorio"].ToString());
                PagoServicio.DiasAntes = Int32.Parse(reader["DiasAntes"].ToString());
                PagoServicio.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                PagoServicio.Observacion = reader["Observacion"].ToString();
                PagoServicio.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PagoServiciolist.Add(PagoServicio);
            }
            reader.Close();
            reader.Dispose();
            return PagoServiciolist;
        }

        public List<PagoServicioBE> ListaVencido(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PagoServicio_ListaVencido");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PagoServicioBE> PagoServiciolist = new List<PagoServicioBE>();
            PagoServicioBE PagoServicio;
            while (reader.Read())
            {
                PagoServicio = new PagoServicioBE();
                PagoServicio.IdPagoServicio = Int32.Parse(reader["IdPagoServicio"].ToString());
                PagoServicio.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PagoServicio.Periodo = Int32.Parse(reader["Periodo"].ToString());
                PagoServicio.IdTipoServicio = Int32.Parse(reader["IdTipoServicio"].ToString());
                PagoServicio.Numero = reader["Numero"].ToString();
                PagoServicio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PagoServicio.IdProveedor = reader.IsDBNull(reader.GetOrdinal("IdProveedor")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdProveedor"));
                PagoServicio.IdBanco = reader.IsDBNull(reader.GetOrdinal("IdBanco")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdBanco"));
                PagoServicio.Concepto = reader["Concepto"].ToString();
                PagoServicio.NumeroCuotas = Int32.Parse(reader["NumeroCuotas"].ToString());
                PagoServicio.TipoMovimiento = reader["TipoMovimiento"].ToString();
                PagoServicio.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                PagoServicio.Importe = Decimal.Parse(reader["Importe"].ToString());
                PagoServicio.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                PagoServicio.TipoRecordatorio = Int32.Parse(reader["TipoRecordatorio"].ToString());
                PagoServicio.DiasAntes = Int32.Parse(reader["DiasAntes"].ToString());
                PagoServicio.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                PagoServicio.Observacion = reader["Observacion"].ToString();
                PagoServicio.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PagoServiciolist.Add(PagoServicio);
            }
            reader.Close();
            reader.Dispose();
            return PagoServiciolist;
        }

        public PagoServicioBE Selecciona(int IdPagoServicio)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PagoServicio_Selecciona");
			db.AddInParameter(dbCommand, "pIdPagoServicio", DbType.Int32, IdPagoServicio);

			IDataReader reader = db.ExecuteReader(dbCommand);
			PagoServicioBE PagoServicio = null;
			while (reader.Read())
			{
				PagoServicio = new PagoServicioBE();
				PagoServicio.IdPagoServicio = Int32.Parse(reader["IdPagoServicio"].ToString());
				PagoServicio.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				PagoServicio.Periodo = Int32.Parse(reader["Periodo"].ToString());
				PagoServicio.IdTipoServicio = Int32.Parse(reader["IdTipoServicio"].ToString());
				PagoServicio.Numero = reader["Numero"].ToString();
				PagoServicio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PagoServicio.IdProveedor = reader.IsDBNull(reader.GetOrdinal("IdProveedor")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdProveedor"));
                PagoServicio.IdBanco = reader.IsDBNull(reader.GetOrdinal("IdBanco")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdBanco"));
                PagoServicio.Concepto = reader["Concepto"].ToString();
				PagoServicio.NumeroCuotas = Int32.Parse(reader["NumeroCuotas"].ToString());
				PagoServicio.TipoMovimiento = reader["TipoMovimiento"].ToString();
				PagoServicio.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
				PagoServicio.Importe = Decimal.Parse(reader["Importe"].ToString());
				PagoServicio.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
				PagoServicio.TipoRecordatorio = Int32.Parse(reader["TipoRecordatorio"].ToString());
				PagoServicio.DiasAntes = Int32.Parse(reader["DiasAntes"].ToString());
				PagoServicio.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
				PagoServicio.Observacion = reader["Observacion"].ToString();
				PagoServicio.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
			}
			reader.Close();
			reader.Dispose();
			return PagoServicio;
		}

        public PagoServicioBE SeleccionaNumero(int IdEmpresa, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PagoServicio_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PagoServicioBE PagoServicio = null;
            while (reader.Read())
            {
                PagoServicio = new PagoServicioBE();
                PagoServicio.IdPagoServicio = Int32.Parse(reader["IdPagoServicio"].ToString());
                PagoServicio.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PagoServicio.Periodo = Int32.Parse(reader["Periodo"].ToString());
                PagoServicio.IdTipoServicio = Int32.Parse(reader["IdTipoServicio"].ToString());
                PagoServicio.Numero = reader["Numero"].ToString();
                PagoServicio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PagoServicio.IdProveedor = reader.IsDBNull(reader.GetOrdinal("IdProveedor")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdProveedor"));
                PagoServicio.IdBanco = reader.IsDBNull(reader.GetOrdinal("IdBanco")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdBanco"));
                PagoServicio.Concepto = reader["Concepto"].ToString();
                PagoServicio.NumeroCuotas = Int32.Parse(reader["NumeroCuotas"].ToString());
                PagoServicio.TipoMovimiento = reader["TipoMovimiento"].ToString();
                PagoServicio.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                PagoServicio.Importe = Decimal.Parse(reader["Importe"].ToString());
                PagoServicio.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                PagoServicio.TipoRecordatorio = Int32.Parse(reader["TipoRecordatorio"].ToString());
                PagoServicio.DiasAntes = Int32.Parse(reader["DiasAntes"].ToString());
                PagoServicio.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                PagoServicio.Observacion = reader["Observacion"].ToString();
                PagoServicio.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return PagoServicio;
        }

    }
}
