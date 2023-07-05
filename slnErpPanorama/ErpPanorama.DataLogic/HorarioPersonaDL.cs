using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class HorarioPersonaDL
    {
        public HorarioPersonaDL() { }

        public Int32 Inserta(HorarioPersonaBE pItem)
        {
            Int32 Id = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_Inserta");

            db.AddOutParameter(dbCommand, "pIdHorarioPersona", DbType.Int32, pItem.IdHorarioPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdCargo", DbType.Int32, pItem.IdCargo);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaIngreso", DbType.DateTime, pItem.FechaIngreso);
            db.AddInParameter(dbCommand, "pFechaSalidaRef", DbType.DateTime, pItem.FechaSalidaRef);
            db.AddInParameter(dbCommand, "pFechaIngresoRef", DbType.DateTime, pItem.FechaIngresoRef);
            db.AddInParameter(dbCommand, "pFechaSalida", DbType.DateTime, pItem.FechaSalida);
            db.AddInParameter(dbCommand, "pIdHorarioTipoIncidencia", DbType.Int32, pItem.IdHorarioTipoIncidencia);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagObligatorio", DbType.Boolean, pItem.FlagObligatorio);
            db.AddInParameter(dbCommand, "pFlagApoyo", DbType.Boolean, pItem.FlagApoyo);
            db.AddInParameter(dbCommand, "pFlagPagado", DbType.Boolean, pItem.FlagPagado);
            db.AddInParameter(dbCommand, "pSueldo", DbType.Decimal, pItem.Sueldo);
            db.AddInParameter(dbCommand, "pTotalHorasRef", DbType.Decimal, pItem.TotalHorasRef);
            db.AddInParameter(dbCommand, "pTotalHorasTrab", DbType.Decimal, pItem.TotalHorasTrab);
            db.AddInParameter(dbCommand, "pToleranciaTarde", DbType.Int32, pItem.ToleranciaTarde);
            db.AddInParameter(dbCommand, "pIdPersonaRegistro", DbType.Int32, pItem.IdPersonaRegistro);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pIdPersonaModifica", DbType.Int32, pItem.IdPersonaModifica);
            db.AddInParameter(dbCommand, "pFechaModifica", DbType.DateTime, pItem.FechaModifica);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            Id = (int)db.GetParameterValue(dbCommand, "pIdHorarioPersona");

            return Id;
        }

        public void Actualiza(HorarioPersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_Actualiza");

            db.AddInParameter(dbCommand, "pIdHorarioPersona", DbType.Int32, pItem.IdHorarioPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdCargo", DbType.Int32, pItem.IdCargo);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaIngreso", DbType.DateTime, pItem.FechaIngreso);
            db.AddInParameter(dbCommand, "pFechaSalidaRef", DbType.DateTime, pItem.FechaSalidaRef);
            db.AddInParameter(dbCommand, "pFechaIngresoRef", DbType.DateTime, pItem.FechaIngresoRef);
            db.AddInParameter(dbCommand, "pFechaSalida", DbType.DateTime, pItem.FechaSalida);
            db.AddInParameter(dbCommand, "pIdHorarioTipoIncidencia", DbType.Int32, pItem.IdHorarioTipoIncidencia);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagObligatorio", DbType.Boolean, pItem.FlagObligatorio);
            db.AddInParameter(dbCommand, "pFlagApoyo", DbType.Boolean, pItem.FlagApoyo);
            db.AddInParameter(dbCommand, "pFlagPagado", DbType.Boolean, pItem.FlagPagado);
            db.AddInParameter(dbCommand, "pSueldo", DbType.Decimal, pItem.Sueldo);
            db.AddInParameter(dbCommand, "pTotalHorasRef", DbType.Decimal, pItem.TotalHorasRef);
            db.AddInParameter(dbCommand, "pTotalHorasTrab", DbType.Decimal, pItem.TotalHorasTrab);
            db.AddInParameter(dbCommand, "pToleranciaTarde", DbType.Int32, pItem.ToleranciaTarde);
            db.AddInParameter(dbCommand, "pIdPersonaRegistro", DbType.Int32, pItem.IdPersonaRegistro);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pIdPersonaModifica", DbType.Int32, pItem.IdPersonaModifica);
            db.AddInParameter(dbCommand, "pFechaModifica", DbType.DateTime, pItem.FechaModifica);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(HorarioPersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_Elimina");

            db.AddInParameter(dbCommand, "pIdHorarioPersona", DbType.Int32, pItem.IdHorarioPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<HorarioPersonaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<HorarioPersonaBE> HorarioPersonalist = new List<HorarioPersonaBE>();
            HorarioPersonaBE HorarioPersona;
            while (reader.Read())
            {
                HorarioPersona = new HorarioPersonaBE();
                HorarioPersona.IdHorarioPersona = Int32.Parse(reader["IdHorarioPersona"].ToString());
                HorarioPersona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                HorarioPersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                HorarioPersona.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                HorarioPersona.IdArea = Int32.Parse(reader["IdArea"].ToString());
                HorarioPersona.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                HorarioPersona.Periodo = Int32.Parse(reader["Periodo"].ToString());
                HorarioPersona.Mes = Int32.Parse(reader["Mes"].ToString());
                HorarioPersona.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                HorarioPersona.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                HorarioPersona.FechaSalidaRef = DateTime.Parse(reader["FechaSalidaRef"].ToString());
                HorarioPersona.FechaIngresoRef = DateTime.Parse(reader["FechaIngresoRef"].ToString());
                HorarioPersona.FechaSalida = DateTime.Parse(reader["FechaSalida"].ToString());
                HorarioPersona.IdHorarioTipoIncidencia = Int32.Parse(reader["IdHorarioTipoIncidencia"].ToString());
                HorarioPersona.Observacion = reader["Observacion"].ToString();
                HorarioPersona.FlagObligatorio = Boolean.Parse(reader["FlagObligatorio"].ToString());
                HorarioPersona.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
                HorarioPersona.FlagPagado = Boolean.Parse(reader["FlagPagado"].ToString());
                HorarioPersona.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
                HorarioPersona.TotalHorasRef = Decimal.Parse(reader["TotalHorasRef"].ToString());
                HorarioPersona.TotalHorasTrab = Decimal.Parse(reader["TotalHorasTrab"].ToString());
                HorarioPersona.ToleranciaTarde = Int32.Parse(reader["ToleranciaTarde"].ToString());
                HorarioPersona.IdPersonaRegistro = Int32.Parse(reader["IdPersonaRegistro"].ToString());
                HorarioPersona.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                HorarioPersona.IdPersonaModifica = Int32.Parse(reader["IdPersonaModifica"].ToString());
                HorarioPersona.FechaModifica = DateTime.Parse(reader["FechaModifica"].ToString());
                HorarioPersona.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //HorarioPersona.IdHorarioPersona = reader.IsDBNull(reader.GetOrdinal("IdHorarioPersona")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdHorarioPersona"));
                HorarioPersonalist.Add(HorarioPersona);
            }
            reader.Close();
            reader.Dispose();
            return HorarioPersonalist;
        }

        public List<HorarioPersonaBE> ListaHorasFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_ListaHorasFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<HorarioPersonaBE> HorarioPersonalist = new List<HorarioPersonaBE>();
            HorarioPersonaBE HorarioPersona;
            while (reader.Read())
            {
                HorarioPersona = new HorarioPersonaBE();
                HorarioPersona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                HorarioPersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                HorarioPersona.ApeNom = reader["ApeNom"].ToString();
                HorarioPersona.TotalHorasRef = Decimal.Parse(reader["TotalHorasRef"].ToString());
                HorarioPersona.TotalHorasTrab = Decimal.Parse(reader["TotalHorasTrab"].ToString());
                //HorarioPersona.IdHorarioPersona = reader.IsDBNull(reader.GetOrdinal("IdHorarioPersona")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdHorarioPersona"));
                HorarioPersonalist.Add(HorarioPersona);
            }
            reader.Close();
            reader.Dispose();
            return HorarioPersonalist;
        }

        public List<HorarioPersonaBE> ListaFecha(int IdEmpresa, int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<HorarioPersonaBE> HorarioPersonalist = new List<HorarioPersonaBE>();
            HorarioPersonaBE HorarioPersona;
            while (reader.Read())
            {
                HorarioPersona = new HorarioPersonaBE();
                HorarioPersona.IdHorarioPersona = Int32.Parse(reader["IdHorarioPersona"].ToString());
                HorarioPersona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                HorarioPersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                HorarioPersona.ApeNom = reader["ApeNom"].ToString();
                HorarioPersona.DiaSemanaName = reader["DiaSemanaName"].ToString();
                HorarioPersona.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                HorarioPersona.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                HorarioPersona.FechaSalidaRef = DateTime.Parse(reader["FechaSalidaRef"].ToString());
                HorarioPersona.FechaIngresoRef = DateTime.Parse(reader["FechaIngresoRef"].ToString());
                HorarioPersona.FechaSalida = DateTime.Parse(reader["FechaSalida"].ToString());
                HorarioPersona.IdHorarioTipoIncidencia = Int32.Parse(reader["IdHorarioTipoIncidencia"].ToString());
                HorarioPersona.FlagObligatorio = Boolean.Parse(reader["FlagObligatorio"].ToString());
                HorarioPersona.TotalHorasRef = Decimal.Parse(reader["TotalHorasRef"].ToString());
                HorarioPersona.TotalHorasTrab = Decimal.Parse(reader["TotalHorasTrab"].ToString());
                HorarioPersona.DescTurno = reader["DescTurno"].ToString();
                HorarioPersona.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //HorarioPersona.IdHorarioPersona = reader.IsDBNull(reader.GetOrdinal("IdHorarioPersona")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdHorarioPersona"));
                HorarioPersonalist.Add(HorarioPersona);
            }
            reader.Close();
            reader.Dispose();
            return HorarioPersonalist;
        }

        public HorarioPersonaBE Selecciona(int IdHorarioPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_Selecciona");
            db.AddInParameter(dbCommand, "pIdHorarioPersona", DbType.Int32, IdHorarioPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            HorarioPersonaBE HorarioPersona = null;
            while (reader.Read())
            {
                HorarioPersona = new HorarioPersonaBE();
                HorarioPersona.IdHorarioPersona = Int32.Parse(reader["IdHorarioPersona"].ToString());
                HorarioPersona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                HorarioPersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                HorarioPersona.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                HorarioPersona.IdArea = Int32.Parse(reader["IdArea"].ToString());
                HorarioPersona.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                HorarioPersona.Periodo = Int32.Parse(reader["Periodo"].ToString());
                HorarioPersona.Mes = Int32.Parse(reader["Mes"].ToString());
                HorarioPersona.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                HorarioPersona.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                HorarioPersona.FechaSalidaRef = DateTime.Parse(reader["FechaSalidaRef"].ToString());
                HorarioPersona.FechaIngresoRef = DateTime.Parse(reader["FechaIngresoRef"].ToString());
                HorarioPersona.FechaSalida = DateTime.Parse(reader["FechaSalida"].ToString());
                HorarioPersona.IdHorarioTipoIncidencia = Int32.Parse(reader["IdHorarioTipoIncidencia"].ToString());
                HorarioPersona.Observacion = reader["Observacion"].ToString();
                HorarioPersona.FlagObligatorio = Boolean.Parse(reader["FlagObligatorio"].ToString());
                HorarioPersona.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
                HorarioPersona.FlagPagado = Boolean.Parse(reader["FlagPagado"].ToString());
                HorarioPersona.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
                HorarioPersona.TotalHorasRef = Decimal.Parse(reader["TotalHorasRef"].ToString());
                HorarioPersona.TotalHorasTrab = Decimal.Parse(reader["TotalHorasTrab"].ToString());
                HorarioPersona.ToleranciaTarde = Int32.Parse(reader["ToleranciaTarde"].ToString());
                HorarioPersona.IdPersonaRegistro = Int32.Parse(reader["IdPersonaRegistro"].ToString());
                HorarioPersona.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                HorarioPersona.IdPersonaModifica = Int32.Parse(reader["IdPersonaModifica"].ToString());
                HorarioPersona.FechaModifica = DateTime.Parse(reader["FechaModifica"].ToString());
                HorarioPersona.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //HorarioPersona.IdHorarioPersona = reader.IsDBNull(reader.GetOrdinal("IdHorarioPersona")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdHorarioPersona"));
            }
            reader.Close();
            reader.Dispose();
            return HorarioPersona;
        }

        public void InsertaFecha(int IdEmpresa, int IdPersona, int IdTurno, DateTime FechaDesde, DateTime FechaHasta, int IdPerReg, string Usuario, string Maquina)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_InsertaFecha");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pIdTurno", DbType.Int32, IdTurno);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdPersonaRegistro", DbType.Int32, IdPerReg);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaIncidencia(HorarioPersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_ActualizaIncidencia");

            db.AddInParameter(dbCommand, "pIdHorarioPersona", DbType.Int32, pItem.IdHorarioPersona);
            db.AddInParameter(dbCommand, "pFechaIngreso", DbType.DateTime, pItem.FechaIngreso);
            db.AddInParameter(dbCommand, "pFechaSalidaRef", DbType.DateTime, pItem.FechaSalidaRef);
            db.AddInParameter(dbCommand, "pFechaIngresoRef", DbType.DateTime, pItem.FechaIngresoRef);
            db.AddInParameter(dbCommand, "pFechaSalida", DbType.DateTime, pItem.FechaSalida);
            db.AddInParameter(dbCommand, "pIdHorarioTipoIncidencia", DbType.Int32, pItem.IdHorarioTipoIncidencia);
            db.AddInParameter(dbCommand, "pTotalHorasRef", DbType.Decimal, pItem.TotalHorasRef);
            db.AddInParameter(dbCommand, "pTotalHorasTrab", DbType.Decimal, pItem.TotalHorasTrab);
            db.AddInParameter(dbCommand, "pIdPersonaModifica", DbType.Int32, pItem.IdPersonaModifica);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCerrado(int IdEmpresa, int IdPersona, bool FlagCerrado, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_ActualizaCerrado");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pFlagCerrado", DbType.Boolean, FlagCerrado);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            db.ExecuteNonQuery(dbCommand);
        }
    }
    //public class HorarioPersonaDL
    //{
    //	public HorarioPersonaDL() { }

    //	public Int32 Inserta(HorarioPersonaBE pItem)
    //	{
    //		Int32 Id = 0;
    //		Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //		DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_Inserta");
    //		//db.AddOutParameter(dbCommand, "pIdHorarioPersona", DbType.Int32, pItem.IdHorarioPersona);
    //		//db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
    //		//db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
    //		//db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
    //		//db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
    //		//db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
    //		//db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
    //		//db.AddInParameter(dbCommand, "pIdHorarioTipoIncidencia", DbType.Int32, pItem.IdHorarioTipoIncidencia);
    //		//db.AddInParameter(dbCommand, "pRefrigerio", DbType.Int32, pItem.Refrigerio);
    //		//db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
    //		//db.AddInParameter(dbCommand, "pFlagObligatorio", DbType.Boolean, pItem.FlagObligatorio);
    //		//db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
    //		//db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
    //		//db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

    //           db.AddOutParameter(dbCommand, "pIdHorarioPersona", DbType.Int32, pItem.IdHorarioPersona);
    //           db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
    //           db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
    //           db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
    //           db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
    //           db.AddInParameter(dbCommand, "pIdCargo", DbType.Int32, pItem.IdCargo);
    //           db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
    //           db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
    //           db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
    //           db.AddInParameter(dbCommand, "pFechaIngreso", DbType.DateTime, pItem.FechaIngreso);
    //           db.AddInParameter(dbCommand, "pFechaSalidaRef", DbType.DateTime, pItem.FechaSalidaRef);
    //           db.AddInParameter(dbCommand, "pFechaIngresoRef", DbType.DateTime, pItem.FechaIngresoRef);

    //           db.AddInParameter(dbCommand, "pFechaSalida", DbType.DateTime, pItem.FechaSalida);
    //           db.AddInParameter(dbCommand, "pIdHorarioTipoIncidencia", DbType.Int32, pItem.IdHorarioTipoIncidencia);
    //           db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
    //           db.AddInParameter(dbCommand, "pFlagObligatorio", DbType.Boolean, pItem.FlagObligatorio);
    //           db.AddInParameter(dbCommand, "pFlagApoyo", DbType.Boolean, pItem.FlagApoyo);
    //           db.AddInParameter(dbCommand, "pFlagPagado", DbType.Boolean, pItem.FlagPagado);

    //           db.AddInParameter(dbCommand, "pSueldo", DbType.Decimal, pItem.Sueldo);
    //           db.AddInParameter(dbCommand, "pTotalHorasRef", DbType.Decimal, pItem.TotalHorasRef);
    //           db.AddInParameter(dbCommand, "pTotalHorasTrab", DbType.Decimal, pItem.TotalHorasTrab);
    //           db.AddInParameter(dbCommand, "pToleranciaTarde", DbType.Int32, pItem.ToleranciaTarde);
    //           db.AddInParameter(dbCommand, "pIdPersonaRegistro", DbType.Int32, pItem.IdPersonaRegistro);
    //           db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
    //           db.AddInParameter(dbCommand, "pIdPersonaModifica", DbType.Int32, pItem.IdPersonaModifica);
    //           db.AddInParameter(dbCommand, "pFechaModifica", DbType.DateTime, pItem.FechaModifica);
    //           db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
    //           db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
    //           db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


    //           db.ExecuteNonQuery(dbCommand);

    //		Id = (int)db.GetParameterValue(dbCommand, "pIdHorarioPersona");

    //		return Id;
    //	}

    //	public void Actualiza(HorarioPersonaBE pItem)
    //	{
    //		Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //		DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_Actualiza");

    //           //db.AddInParameter(dbCommand, "pIdHorarioPersona", DbType.Int32, pItem.IdHorarioPersona);
    //           //db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
    //           //db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
    //           //db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
    //           //db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
    //           //db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
    //           //db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
    //           //db.AddInParameter(dbCommand, "pIdHorarioTipoIncidencia", DbType.Int32, pItem.IdHorarioTipoIncidencia);
    //           //db.AddInParameter(dbCommand, "pRefrigerio", DbType.Int32, pItem.Refrigerio);
    //           //db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
    //           //db.AddInParameter(dbCommand, "pFlagObligatorio", DbType.Boolean, pItem.FlagObligatorio);
    //           //db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
    //           //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
    //           //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

    //           db.AddInParameter(dbCommand, "pIdHorarioPersona", DbType.Int32, pItem.IdHorarioPersona);
    //           db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
    //           db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
    //           db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
    //           db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
    //           db.AddInParameter(dbCommand, "pIdCargo", DbType.Int32, pItem.IdCargo);
    //           db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
    //           db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
    //           db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);

    //           db.AddInParameter(dbCommand, "pFechaIngreso", DbType.DateTime, pItem.FechaIngreso);
    //           db.AddInParameter(dbCommand, "pFechaSalidaRef", DbType.DateTime, pItem.FechaSalidaRef);
    //           db.AddInParameter(dbCommand, "pFechaIngresoRef", DbType.DateTime, pItem.FechaIngresoRef);
    //           db.AddInParameter(dbCommand, "pFechaSalida", DbType.DateTime, pItem.FechaSalida);
    //           db.AddInParameter(dbCommand, "pIdHorarioTipoIncidencia", DbType.Int32, pItem.IdHorarioTipoIncidencia);
    //           db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
    //           db.AddInParameter(dbCommand, "pFlagObligatorio", DbType.Boolean, pItem.FlagObligatorio);
    //           db.AddInParameter(dbCommand, "pFlagApoyo", DbType.Boolean, pItem.FlagApoyo);
    //           db.AddInParameter(dbCommand, "pFlagPagado", DbType.Boolean, pItem.FlagPagado);


    //           db.AddInParameter(dbCommand, "pSueldo", DbType.Decimal, pItem.Sueldo);
    //           db.AddInParameter(dbCommand, "pTotalHorasRef", DbType.Decimal, pItem.TotalHorasRef);
    //           db.AddInParameter(dbCommand, "pTotalHorasTrab", DbType.Decimal, pItem.TotalHorasTrab);
    //           db.AddInParameter(dbCommand, "pToleranciaTarde", DbType.Int32, pItem.ToleranciaTarde);
    //           db.AddInParameter(dbCommand, "pIdPersonaRegistro", DbType.Int32, pItem.IdPersonaRegistro);
    //           db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
    //           db.AddInParameter(dbCommand, "pIdPersonaModifica", DbType.Int32, pItem.IdPersonaModifica);
    //           db.AddInParameter(dbCommand, "pFechaModifica", DbType.DateTime, pItem.FechaModifica);
    //           db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
    //           db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
    //           db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


    //           db.ExecuteNonQuery(dbCommand);
    //	}

    //	public void Elimina(HorarioPersonaBE pItem)
    //	{
    //		Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //		DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_Elimina");

    //		db.AddInParameter(dbCommand, "pIdHorarioPersona", DbType.Int32, pItem.IdHorarioPersona);
    //		db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
    //		db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
    //		db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

    //		db.ExecuteNonQuery(dbCommand);
    //	}



    ////	public List<HorarioPersonaBE> ListaTodosActivo(int IdPersona, DateTime FechaDesde, DateTime FechaHasta)

    //       public List<HorarioPersonaBE> ListaTodosActivo(int IdEmpresa)
    //       {
    //           Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //           DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_ListaTodosActivo");
    //           db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

    //           IDataReader reader = db.ExecuteReader(dbCommand);
    //           List<HorarioPersonaBE> HorarioPersonalist = new List<HorarioPersonaBE>();
    //           HorarioPersonaBE HorarioPersona;
    //           while (reader.Read())
    //           {
    //               HorarioPersona = new HorarioPersonaBE();
    //               HorarioPersona.IdHorarioPersona = Int32.Parse(reader["IdHorarioPersona"].ToString());
    //               HorarioPersona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
    //               HorarioPersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
    //               HorarioPersona.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
    //               HorarioPersona.IdArea = Int32.Parse(reader["IdArea"].ToString());
    //               HorarioPersona.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
    //               HorarioPersona.Periodo = Int32.Parse(reader["Periodo"].ToString());
    //               HorarioPersona.Mes = Int32.Parse(reader["Mes"].ToString());
    //               HorarioPersona.Fecha = DateTime.Parse(reader["Fecha"].ToString());


    //               HorarioPersona.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
    //               HorarioPersona.FechaSalidaRef = DateTime.Parse(reader["FechaSalidaRef"].ToString());
    //               HorarioPersona.FechaIngresoRef = DateTime.Parse(reader["FechaIngresoRef"].ToString());
    //               HorarioPersona.FechaSalida = DateTime.Parse(reader["FechaSalida"].ToString());
    //               HorarioPersona.IdHorarioTipoIncidencia = Int32.Parse(reader["IdHorarioTipoIncidencia"].ToString());
    //               HorarioPersona.Observacion = reader["Observacion"].ToString();
    //               HorarioPersona.FlagObligatorio = Boolean.Parse(reader["FlagObligatorio"].ToString());
    //               HorarioPersona.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
    //               HorarioPersona.FlagPagado = Boolean.Parse(reader["FlagPagado"].ToString());

    //               HorarioPersona.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
    //               HorarioPersona.TotalHorasRef = Decimal.Parse(reader["TotalHorasRef"].ToString());
    //               HorarioPersona.TotalHorasTrab = Decimal.Parse(reader["TotalHorasTrab"].ToString());
    //               HorarioPersona.ToleranciaTarde = Int32.Parse(reader["ToleranciaTarde"].ToString());
    //               HorarioPersona.IdPersonaRegistro = Int32.Parse(reader["IdPersonaRegistro"].ToString());
    //               HorarioPersona.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
    //               HorarioPersona.IdPersonaModifica = Int32.Parse(reader["IdPersonaModifica"].ToString());
    //               HorarioPersona.FechaModifica = DateTime.Parse(reader["FechaModifica"].ToString());
    //               HorarioPersona.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
    //               //HorarioPersona.IdHorarioPersona = reader.IsDBNull(reader.GetOrdinal("IdHorarioPersona")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdHorarioPersona"));
    //               HorarioPersonalist.Add(HorarioPersona);
    //           }
    //           reader.Close();
    //           reader.Dispose();
    //           return HorarioPersonalist;
    //       }

    //       public List<HorarioPersonaBE> ListaHorasFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
    //       {
    //           Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //           DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_ListaHorasFecha");
    //           db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
    //           db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
    //           db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

    //           IDataReader reader = db.ExecuteReader(dbCommand);
    //           List<HorarioPersonaBE> HorarioPersonalist = new List<HorarioPersonaBE>();
    //           HorarioPersonaBE HorarioPersona;
    //           while (reader.Read())
    //           {
    //               HorarioPersona = new HorarioPersonaBE();
    //               HorarioPersona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
    //               HorarioPersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
    //               HorarioPersona.ApeNom = reader["ApeNom"].ToString();
    //               HorarioPersona.TotalHorasRef = Decimal.Parse(reader["TotalHorasRef"].ToString());
    //               HorarioPersona.TotalHorasTrab = Decimal.Parse(reader["TotalHorasTrab"].ToString());
    //               //HorarioPersona.IdHorarioPersona = reader.IsDBNull(reader.GetOrdinal("IdHorarioPersona")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdHorarioPersona"));
    //               HorarioPersonalist.Add(HorarioPersona);
    //           }
    //           reader.Close();
    //           reader.Dispose();
    //           return HorarioPersonalist;
    //       }

    //       public List<HorarioPersonaBE> ListaFecha(int IdEmpresa, int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
    //       {
    //           Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //           DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_ListaFecha");
    //           db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
    //           db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
    //           db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
    //           db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

    //           IDataReader reader = db.ExecuteReader(dbCommand);
    //           List<HorarioPersonaBE> HorarioPersonalist = new List<HorarioPersonaBE>();
    //           HorarioPersonaBE HorarioPersona;
    //           while (reader.Read())
    //           {
    //               HorarioPersona = new HorarioPersonaBE();
    //               HorarioPersona.IdHorarioPersona = Int32.Parse(reader["IdHorarioPersona"].ToString());
    //               HorarioPersona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
    //               HorarioPersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
    //               HorarioPersona.ApeNom = reader["ApeNom"].ToString();
    //               HorarioPersona.DiaSemanaName = reader["DiaSemanaName"].ToString();
    //               HorarioPersona.Fecha = DateTime.Parse(reader["Fecha"].ToString());
    //               HorarioPersona.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
    //               HorarioPersona.FechaSalidaRef = DateTime.Parse(reader["FechaSalidaRef"].ToString());
    //               HorarioPersona.FechaIngresoRef = DateTime.Parse(reader["FechaIngresoRef"].ToString());
    //               HorarioPersona.FechaSalida = DateTime.Parse(reader["FechaSalida"].ToString());

    //               HorarioPersona.IdHorarioTipoIncidencia = Int32.Parse(reader["IdHorarioTipoIncidencia"].ToString());
    //               HorarioPersona.FlagObligatorio = Boolean.Parse(reader["FlagObligatorio"].ToString());
    //               HorarioPersona.TotalHorasRef = Decimal.Parse(reader["TotalHorasRef"].ToString());
    //               HorarioPersona.TotalHorasTrab = Decimal.Parse(reader["TotalHorasTrab"].ToString());
    //               HorarioPersona.DescTurno = reader["DescTurno"].ToString();
    //               HorarioPersona.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
    //               //HorarioPersona.IdHorarioPersona = reader.IsDBNull(reader.GetOrdinal("IdHorarioPersona")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdHorarioPersona"));
    //               HorarioPersonalist.Add(HorarioPersona);
    //           }
    //           reader.Close();
    //           reader.Dispose();
    //           return HorarioPersonalist;
    //       }



    //       public HorarioPersonaBE Selecciona(int IdHorarioPersona)
    //	{
    //           Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //           DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_Selecciona");
    //           db.AddInParameter(dbCommand, "pIdHorarioPersona", DbType.Int32, IdHorarioPersona);

    //           IDataReader reader = db.ExecuteReader(dbCommand);
    //           HorarioPersonaBE HorarioPersona = null;
    //           while (reader.Read())
    //           {
    //               HorarioPersona = new HorarioPersonaBE();
    //               HorarioPersona.IdHorarioPersona = Int32.Parse(reader["IdHorarioPersona"].ToString());
    //               HorarioPersona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
    //               HorarioPersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
    //               HorarioPersona.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
    //               HorarioPersona.IdArea = Int32.Parse(reader["IdArea"].ToString());
    //               HorarioPersona.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
    //               HorarioPersona.Periodo = Int32.Parse(reader["Periodo"].ToString());
    //               HorarioPersona.Mes = Int32.Parse(reader["Mes"].ToString());
    //               HorarioPersona.Fecha = DateTime.Parse(reader["Fecha"].ToString());
    //               HorarioPersona.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
    //               HorarioPersona.FechaSalidaRef = DateTime.Parse(reader["FechaSalidaRef"].ToString());
    //               HorarioPersona.FechaIngresoRef = DateTime.Parse(reader["FechaIngresoRef"].ToString());
    //               HorarioPersona.FechaSalida = DateTime.Parse(reader["FechaSalida"].ToString());
    //               HorarioPersona.IdHorarioTipoIncidencia = Int32.Parse(reader["IdHorarioTipoIncidencia"].ToString());
    //               HorarioPersona.Observacion = reader["Observacion"].ToString();
    //               HorarioPersona.FlagObligatorio = Boolean.Parse(reader["FlagObligatorio"].ToString());
    //               HorarioPersona.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
    //               HorarioPersona.FlagPagado = Boolean.Parse(reader["FlagPagado"].ToString());

    //               HorarioPersona.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
    //               HorarioPersona.TotalHorasRef = Decimal.Parse(reader["TotalHorasRef"].ToString());
    //               HorarioPersona.TotalHorasTrab = Decimal.Parse(reader["TotalHorasTrab"].ToString());
    //               HorarioPersona.ToleranciaTarde = Int32.Parse(reader["ToleranciaTarde"].ToString());
    //               HorarioPersona.IdPersonaRegistro = Int32.Parse(reader["IdPersonaRegistro"].ToString());
    //               HorarioPersona.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
    //               HorarioPersona.IdPersonaModifica = Int32.Parse(reader["IdPersonaModifica"].ToString());
    //               HorarioPersona.FechaModifica = DateTime.Parse(reader["FechaModifica"].ToString());
    //               HorarioPersona.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
    //               //HorarioPersona.IdHorarioPersona = reader.IsDBNull(reader.GetOrdinal("IdHorarioPersona")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdHorarioPersona"));
    //           }
    //           reader.Close();
    //           reader.Dispose();
    //           return HorarioPersona;
    //       }

    //       public void InsertaFecha(int IdEmpresa, int IdPersona, int IdTurno, DateTime FechaDesde, 
    //           DateTime FechaHasta, int IdPerReg, string Usuario, string Maquina)
    //       {
    //           Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //           DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_InsertaFecha");

    //           db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
    //           db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
    //           db.AddInParameter(dbCommand, "pIdTurno", DbType.Int32, IdTurno);
    //           db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
    //           db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
    //           db.AddInParameter(dbCommand, "pIdPersonaRegistro", DbType.Int32, IdPerReg);
    //           db.AddInParameter(dbCommand, "pUsuario", DbType.String, Usuario);
    //           db.AddInParameter(dbCommand, "pMaquina", DbType.String, Maquina);

    //           db.ExecuteNonQuery(dbCommand);

    //       }

    //       public void ActualizaIncidencia(HorarioPersonaBE pItem)
    //       {
    //           Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //           DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_ActualizaIncidencia");

    //           db.AddInParameter(dbCommand, "pIdHorarioPersona", DbType.Int32, pItem.IdHorarioPersona);
    //           db.AddInParameter(dbCommand, "pFechaIngreso", DbType.DateTime, pItem.FechaIngreso);
    //           db.AddInParameter(dbCommand, "pFechaSalidaRef", DbType.DateTime, pItem.FechaSalidaRef);
    //           db.AddInParameter(dbCommand, "pFechaIngresoRef", DbType.DateTime, pItem.FechaIngresoRef);
    //           db.AddInParameter(dbCommand, "pFechaSalida", DbType.DateTime, pItem.FechaSalida);
    //           db.AddInParameter(dbCommand, "pIdHorarioTipoIncidencia", DbType.Int32, pItem.IdHorarioTipoIncidencia);
    //           db.AddInParameter(dbCommand, "pTotalHorasRef", DbType.Decimal, pItem.TotalHorasRef);
    //           db.AddInParameter(dbCommand, "pTotalHorasTrab", DbType.Decimal, pItem.TotalHorasTrab);
    //           db.AddInParameter(dbCommand, "pIdPersonaModifica", DbType.Int32, pItem.IdPersonaModifica);
    //           db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
    //           db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


    //           db.ExecuteNonQuery(dbCommand);
    //       }
    //       public void ActualizaCerrado(int IdEmpresa, int IdPersona, bool FlagCerrado, DateTime FechaDesde, DateTime FechaHasta)
    //       {
    //           Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //           DbCommand dbCommand = db.GetStoredProcCommand("usp_HorarioPersona_ActualizaCerrado");

    //           db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
    //           db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
    //           db.AddInParameter(dbCommand, "pFlagCerrado", DbType.Boolean, FlagCerrado);
    //           db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
    //           db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

    //           db.ExecuteNonQuery(dbCommand);
    //       }






    //   }
}
