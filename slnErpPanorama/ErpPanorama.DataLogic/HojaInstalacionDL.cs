using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class HojaInstalacionDL
	{
		public HojaInstalacionDL() { }

		public Int32 Inserta(HojaInstalacionBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_HojaInstalacion_Inserta");

			db.AddOutParameter(dbCommand, "pIdHojaInstalacion", DbType.Int32, pItem.IdHojaInstalacion);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pIdTurno", DbType.Int32, pItem.IdTurno);
			db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
			db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
			db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
			db.AddInParameter(dbCommand, "pReferencia", DbType.String, pItem.Referencia);
			db.AddInParameter(dbCommand, "pFlagReserva", DbType.Boolean, pItem.FlagReserva);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdHojaInstalacion");

			return Id;
		}

		public void Actualiza(HojaInstalacionBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_HojaInstalacion_Actualiza");

			db.AddInParameter(dbCommand, "pIdHojaInstalacion", DbType.Int32, pItem.IdHojaInstalacion);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pIdTurno", DbType.Int32, pItem.IdTurno);
			db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
			db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
			db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
			db.AddInParameter(dbCommand, "pReferencia", DbType.String, pItem.Referencia);
			db.AddInParameter(dbCommand, "pFlagReserva", DbType.Boolean, pItem.FlagReserva);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

        public void Elimina(HojaInstalacionBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_HojaInstalacion_Elimina");

			db.AddInParameter(dbCommand, "pIdHojaInstalacion", DbType.Int32, pItem.IdHojaInstalacion);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<HojaInstalacionBE> ListaTodosActivo(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_HojaInstalacion_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
			List<HojaInstalacionBE> HojaInstalacionlist = new List<HojaInstalacionBE>();
			HojaInstalacionBE HojaInstalacion;
			while (reader.Read())
			{
				HojaInstalacion = new HojaInstalacionBE();
				HojaInstalacion.IdHojaInstalacion = Int32.Parse(reader["IdHojaInstalacion"].ToString());
				HojaInstalacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                HojaInstalacion.DiaSemana = reader["DiaSemana"].ToString();
                HojaInstalacion.Fecha = DateTime.Parse(reader["Fecha"].ToString());
				HojaInstalacion.IdTurno = Int32.Parse(reader["IdTurno"].ToString());
                HojaInstalacion.DescTurno = reader["DescTurno"].ToString();
                HojaInstalacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                HojaInstalacion.DescCliente = reader["DescCliente"].ToString();
                HojaInstalacion.DescVendedor = reader["DescVendedor"].ToString();
                HojaInstalacion.IdUbigeo = reader["IdUbigeo"].ToString();
                HojaInstalacion.Distrito = reader["Distrito"].ToString();
                HojaInstalacion.Direccion = reader["Direccion"].ToString();
				HojaInstalacion.Referencia = reader["Referencia"].ToString();
				HojaInstalacion.FlagReserva = Boolean.Parse(reader["FlagReserva"].ToString());
				HojaInstalacion.Observacion = reader["Observacion"].ToString();
				HojaInstalacion.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//HojaInstalacion.IdHojaInstalacion = reader.IsDBNull(reader.GetOrdinal("IdHojaInstalacion")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdHojaInstalacion"));
				HojaInstalacionlist.Add(HojaInstalacion);
			}
			reader.Close();
			reader.Dispose();
			return HojaInstalacionlist;
		}

		public HojaInstalacionBE Selecciona(int IdHojaInstalacion)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_HojaInstalacion_Selecciona");
			db.AddInParameter(dbCommand, "pIdHojaInstalacion", DbType.Int32, IdHojaInstalacion);

			IDataReader reader = db.ExecuteReader(dbCommand);
			HojaInstalacionBE HojaInstalacion = null;
			while (reader.Read())
			{
				HojaInstalacion = new HojaInstalacionBE();
                HojaInstalacion.IdHojaInstalacion = Int32.Parse(reader["IdHojaInstalacion"].ToString());
                HojaInstalacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                HojaInstalacion.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                HojaInstalacion.IdTurno = Int32.Parse(reader["IdTurno"].ToString());
                HojaInstalacion.DescTurno = reader["DescTurno"].ToString();
                HojaInstalacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                HojaInstalacion.DescCliente = reader["DescCliente"].ToString();
                HojaInstalacion.IdUbigeo = reader["IdUbigeo"].ToString();
                HojaInstalacion.Distrito = reader["Distrito"].ToString();
                HojaInstalacion.Direccion = reader["Direccion"].ToString();
                HojaInstalacion.Referencia = reader["Referencia"].ToString();
                HojaInstalacion.FlagReserva = Boolean.Parse(reader["FlagReserva"].ToString());
                HojaInstalacion.Observacion = reader["Observacion"].ToString();
                HojaInstalacion.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //HojaInstalacion.IdHojaInstalacion = reader.IsDBNull(reader.GetOrdinal("IdHojaInstalacion")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdHojaInstalacion"));
            }
			reader.Close();
			reader.Dispose();
			return HojaInstalacion;
		}

        public HojaInstalacionBE SeleccionaFechaTurno(int IdTurno, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HojaInstalacion_SeleccionaFechaTurno");
            db.AddInParameter(dbCommand, "pIdTurno", DbType.Int32, IdTurno);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            HojaInstalacionBE HojaInstalacion = null;
            while (reader.Read())
            {
                HojaInstalacion = new HojaInstalacionBE();
                HojaInstalacion.IdHojaInstalacion = Int32.Parse(reader["IdHojaInstalacion"].ToString());
                HojaInstalacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                HojaInstalacion.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                HojaInstalacion.IdTurno = Int32.Parse(reader["IdTurno"].ToString());
                HojaInstalacion.DescTurno = reader["DescTurno"].ToString();
                HojaInstalacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                HojaInstalacion.DescCliente = reader["DescCliente"].ToString();
                HojaInstalacion.IdUbigeo = reader["IdUbigeo"].ToString();
                HojaInstalacion.Distrito = reader["Distrito"].ToString();
                HojaInstalacion.Direccion = reader["Direccion"].ToString();
                HojaInstalacion.Referencia = reader["Referencia"].ToString();
                HojaInstalacion.FlagReserva = Boolean.Parse(reader["FlagReserva"].ToString());
                HojaInstalacion.Observacion = reader["Observacion"].ToString();
                HojaInstalacion.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //HojaInstalacion.IdHojaInstalacion = reader.IsDBNull(reader.GetOrdinal("IdHojaInstalacion")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdHojaInstalacion"));
            }
            reader.Close();
            reader.Dispose();
            return HojaInstalacion;
        }

    }
}
