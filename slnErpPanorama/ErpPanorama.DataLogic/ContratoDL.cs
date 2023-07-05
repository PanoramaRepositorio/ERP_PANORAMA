using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ContratoDL
    {
        public ContratoDL() { }

        public void Inserta(ContratoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Contrato_Inserta");

            db.AddInParameter(dbCommand, "pIdContrato", DbType.Int32, pItem.IdContrato);
            db.AddInParameter(dbCommand, "pIdTipoContrato", DbType.Int32, pItem.IdTipoContrato);
            db.AddInParameter(dbCommand, "pIdTipoTrabajador", DbType.Int32, pItem.IdTipoTrabajador);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.String, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdCargo", DbType.Int32, pItem.IdCargo);
            db.AddInParameter(dbCommand, "pIdHorario", DbType.Int32, pItem.IdHorario);
            db.AddInParameter(dbCommand, "pFechaIni", DbType.DateTime, pItem.FechaIni);
            db.AddInParameter(dbCommand, "pFechaVen", DbType.DateTime, pItem.FechaVen);
            db.AddInParameter(dbCommand, "pIdTipoRenta", DbType.Int32, pItem.IdTipoRenta);
            db.AddInParameter(dbCommand, "pSueldo", DbType.Decimal, pItem.Sueldo);
            db.AddInParameter(dbCommand, "pHoraExtra", DbType.Decimal, pItem.HoraExtra);
            db.AddInParameter(dbCommand, "pBonSueldo", DbType.Decimal, pItem.BonSueldo);
            db.AddInParameter(dbCommand, "pMovilidad", DbType.Decimal, pItem.Movilidad);
            db.AddInParameter(dbCommand, "pSueldoNeto", DbType.Decimal, pItem.SueldoNeto);
            db.AddInParameter(dbCommand, "pIdClasificacionTrabajador", DbType.Int32, pItem.IdClasificacionTrabajador);
            db.AddInParameter(dbCommand, "pRutaContrato", DbType.String, pItem.RutaContrato);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pDias", DbType.String, pItem.Dias);
            db.AddInParameter(dbCommand, "pMeses", DbType.String, pItem.Meses);
            db.AddInParameter(dbCommand, "pFlagHoraExtra", DbType.Boolean, pItem.FlagHoraExtra);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ContratoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Contrato_Actualiza");

            db.AddInParameter(dbCommand, "pIdContrato", DbType.Int32, pItem.IdContrato);
            db.AddInParameter(dbCommand, "pIdTipoContrato", DbType.Int32, pItem.IdTipoContrato);
            db.AddInParameter(dbCommand, "pIdTipoTrabajador", DbType.Int32, pItem.IdTipoTrabajador);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.String, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdCargo", DbType.Int32, pItem.IdCargo);
            db.AddInParameter(dbCommand, "pIdHorario", DbType.Int32, pItem.IdHorario);
            db.AddInParameter(dbCommand, "pFechaIni", DbType.DateTime, pItem.FechaIni);
            db.AddInParameter(dbCommand, "pFechaVen", DbType.DateTime, pItem.FechaVen);
            db.AddInParameter(dbCommand, "pIdTipoRenta", DbType.Int32, pItem.IdTipoRenta);
            db.AddInParameter(dbCommand, "pSueldo", DbType.Decimal, pItem.Sueldo);
            db.AddInParameter(dbCommand, "pHoraExtra", DbType.Decimal, pItem.HoraExtra);
            db.AddInParameter(dbCommand, "pBonSueldo", DbType.Decimal, pItem.BonSueldo);
            db.AddInParameter(dbCommand, "pMovilidad", DbType.Decimal, pItem.Movilidad);
            db.AddInParameter(dbCommand, "pSueldoNeto", DbType.Decimal, pItem.SueldoNeto);
            db.AddInParameter(dbCommand, "pIdClasificacionTrabajador", DbType.Int32, pItem.IdClasificacionTrabajador);
            db.AddInParameter(dbCommand, "pRutaContrato", DbType.String, pItem.RutaContrato);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pDias", DbType.String, pItem.Dias);
            db.AddInParameter(dbCommand, "pMeses", DbType.String, pItem.Meses);
            db.AddInParameter(dbCommand, "pFlagHoraExtra", DbType.Boolean, pItem.FlagHoraExtra);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ContratoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Contrato_Elimina");

            db.AddInParameter(dbCommand, "pIdContrato", DbType.Int32, pItem.IdContrato);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ContratoBE> ListaTodosActivo(int Periodo, string Dni)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Contrato_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ContratoBE> Contratolist = new List<ContratoBE>();
            ContratoBE Contrato;
            while (reader.Read())
            {
                Contrato = new ContratoBE();
                Contrato.IdContrato = Int32.Parse(reader["IdContrato"].ToString());
                Contrato.IdTipoContrato = Int32.Parse(reader["IdTipoContrato"].ToString());
                Contrato.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Contrato.IdTipoTrabajador = Int32.Parse(reader["IdTipoTrabajador"].ToString());
                Contrato.DescTipoTrabajador = reader["DescTipoTrabajador"].ToString();
                Contrato.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Contrato.RazonSocial = reader["RazonSocial"].ToString();
                Contrato.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Contrato.Dni = reader["Dni"].ToString();
                Contrato.ApeNom = reader["ApeNom"].ToString();
                Contrato.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Contrato.DescTienda = reader["DescTienda"].ToString();
                Contrato.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Contrato.DescArea = reader["DescArea"].ToString();
                Contrato.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Contrato.DescCargo = reader["DescCargo"].ToString();
                Contrato.DescSexo = reader["DescSexo"].ToString();
                Contrato.IdHorario = Int32.Parse(reader["IdHorario"].ToString());
                Contrato.DescHorario = reader["DescHorario"].ToString();
                Contrato.HorarioInicio = reader["HorarioInicio"].ToString();
                Contrato.HorarioFin = reader["HorarioFin"].ToString();

                Contrato.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                Contrato.FechaVen = reader.IsDBNull(reader.GetOrdinal("FechaVen")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVen"));
                Contrato.IdTipoRenta = Int32.Parse(reader["IdTipoRenta"].ToString());
                Contrato.DescTipoRenta = reader["DescTipoRenta"].ToString();
                Contrato.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
                Contrato.HoraExtra = Decimal.Parse(reader["HoraExtra"].ToString());
                Contrato.BonSueldo = Decimal.Parse(reader["BonSueldo"].ToString());
                Contrato.Movilidad = Decimal.Parse(reader["Movilidad"].ToString());
                Contrato.SueldoNeto = Decimal.Parse(reader["SueldoNeto"].ToString());
                Contrato.IdClasificacionTrabajador = Int32.Parse(reader["IdClasificacionTrabajador"].ToString());
                Contrato.DescClasificacionTrabajador = reader["DescClasificacionTrabajador"].ToString();
                Contrato.RutaContrato = reader["RutaContrato"].ToString();
                Contrato.Observacion = reader["Observacion"].ToString();
                Contrato.FlagHoraExtra = Boolean.Parse(reader["FlagHoraExtra"].ToString());
                Contrato.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Contrato.DescBanco = reader["DescBanco"].ToString();
                Contrato.NumeroCuenta = reader["NumeroCuenta"].ToString();
                Contrato.Descanso = reader["Descanso"].ToString();
                Contrato.SistemaPension = reader["SistemaPension"].ToString();
                Contrato.Ruc = reader["Ruc"].ToString();
                Contrato.UsuarioSol = reader["UsuarioSol"].ToString();
                Contrato.ClaveSol = reader["ClaveSol"].ToString();
                Contrato.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                Contrato.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Contrato.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                Contratolist.Add(Contrato);
            }
            reader.Close();
            reader.Dispose();
            return Contratolist;
        }

        public List<ContratoBE> ListaPersona(int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Contrato_ListaPersona");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ContratoBE> Contratolist = new List<ContratoBE>();
            ContratoBE Contrato;
            while (reader.Read())
            {
                Contrato = new ContratoBE();
                Contrato.IdContrato = Int32.Parse(reader["IdContrato"].ToString());
                Contrato.IdTipoContrato = Int32.Parse(reader["IdTipoContrato"].ToString());
                Contrato.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Contrato.IdTipoTrabajador = Int32.Parse(reader["IdTipoTrabajador"].ToString());
                Contrato.DescTipoTrabajador = reader["DescTipoTrabajador"].ToString();
                Contrato.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Contrato.RazonSocial = reader["RazonSocial"].ToString();
                Contrato.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Contrato.Dni = reader["Dni"].ToString();
                Contrato.ApeNom = reader["ApeNom"].ToString();
                Contrato.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Contrato.DescTienda = reader["DescTienda"].ToString();
                Contrato.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Contrato.DescArea = reader["DescArea"].ToString();
                Contrato.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Contrato.DescCargo = reader["DescCargo"].ToString();
                Contrato.IdHorario = Int32.Parse(reader["IdHorario"].ToString());
                Contrato.DescHorario = reader["DescHorario"].ToString();
                Contrato.Numero = Int32.Parse(reader["Numero"].ToString());
                Contrato.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                Contrato.FechaVen = reader.IsDBNull(reader.GetOrdinal("FechaVen")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVen"));
                Contrato.IdTipoRenta = Int32.Parse(reader["IdTipoRenta"].ToString());
                Contrato.DescTipoRenta = reader["DescTipoRenta"].ToString();
                Contrato.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
                Contrato.HoraExtra = Decimal.Parse(reader["HoraExtra"].ToString());
                Contrato.BonSueldo = Decimal.Parse(reader["BonSueldo"].ToString());
                Contrato.Movilidad = Decimal.Parse(reader["Movilidad"].ToString());
                Contrato.SueldoNeto = Decimal.Parse(reader["SueldoNeto"].ToString());
                Contrato.IdClasificacionTrabajador = Int32.Parse(reader["IdClasificacionTrabajador"].ToString());
                Contrato.DescClasificacionTrabajador = reader["DescClasificacionTrabajador"].ToString();
                Contrato.RutaContrato = reader["RutaContrato"].ToString();
                Contrato.Observacion = reader["Observacion"].ToString();
                Contrato.Meses = Int32.Parse(reader["Meses"].ToString());
                Contrato.Dias = Int32.Parse(reader["Dias"].ToString());
                Contrato.FlagHoraExtra = Boolean.Parse(reader["FlagHoraExtra"].ToString());
                Contrato.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Contrato.DescBanco = reader["DescBanco"].ToString();
                Contrato.NumeroCuenta = reader["NumeroCuenta"].ToString();
                Contrato.Descanso = reader["Descanso"].ToString();
                Contrato.SistemaPension = reader["SistemaPension"].ToString();
                Contrato.Ruc = reader["Ruc"].ToString();
                Contrato.UsuarioSol = reader["UsuarioSol"].ToString();
                Contrato.ClaveSol = reader["ClaveSol"].ToString();
                Contrato.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                Contrato.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Contrato.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                Contrato.Continuidad = Boolean.Parse(reader["Continuidad"].ToString());
                Contratolist.Add(Contrato);
            }
            reader.Close();
            reader.Dispose();
            return Contratolist;
        }

        public ContratoBE Selecciona(int IdContrato)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Contrato_Selecciona");
            db.AddInParameter(dbCommand, "pIdContrato", DbType.Int32, IdContrato);
           
            IDataReader reader = db.ExecuteReader(dbCommand);
            ContratoBE Contrato = null;
            while (reader.Read())
            {
                Contrato = new ContratoBE();
                Contrato.IdContrato = Int32.Parse(reader["IdContrato"].ToString());
                Contrato.IdTipoContrato = Int32.Parse(reader["IdTipoContrato"].ToString());
                Contrato.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Contrato.IdTipoTrabajador = Int32.Parse(reader["IdTipoTrabajador"].ToString());
                Contrato.DescTipoTrabajador = reader["DescTipoTrabajador"].ToString();
                Contrato.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Contrato.RazonSocial = reader["RazonSocial"].ToString();
                Contrato.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Contrato.ApeNom = reader["ApeNom"].ToString();
                Contrato.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Contrato.DescTienda = reader["DescTienda"].ToString();
                Contrato.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Contrato.DescArea = reader["DescArea"].ToString();
                Contrato.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Contrato.DescCargo = reader["DescCargo"].ToString();
                Contrato.IdHorario = Int32.Parse(reader["IdHorario"].ToString());
                Contrato.DescHorario = reader["DescHorario"].ToString();
                Contrato.Numero = Int32.Parse(reader["Numero"].ToString());
                Contrato.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                Contrato.FechaVen = reader.IsDBNull(reader.GetOrdinal("FechaVen")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVen"));
                Contrato.IdTipoRenta = Int32.Parse(reader["IdTipoRenta"].ToString());
                Contrato.DescTipoRenta = reader["DescTipoRenta"].ToString();
                Contrato.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
                Contrato.HoraExtra = Decimal.Parse(reader["HoraExtra"].ToString());
                Contrato.BonSueldo = Decimal.Parse(reader["BonSueldo"].ToString());
                Contrato.Movilidad = Decimal.Parse(reader["Movilidad"].ToString());
                Contrato.SueldoNeto = Decimal.Parse(reader["SueldoNeto"].ToString());
                Contrato.IdClasificacionTrabajador = Int32.Parse(reader["IdClasificacionTrabajador"].ToString());
                Contrato.DescClasificacionTrabajador = reader["DescClasificacionTrabajador"].ToString();
                Contrato.RutaContrato = reader["RutaContrato"].ToString();
                Contrato.Observacion = reader["Observacion"].ToString();
                Contrato.Dias = Int32.Parse(reader["Dias"].ToString());
                Contrato.Meses = Int32.Parse(reader["Meses"].ToString());
                Contrato.FlagHoraExtra = Boolean.Parse(reader["FlagHoraExtra"].ToString());
                Contrato.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                Contrato.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Contrato.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                
            }
            reader.Close();
            reader.Dispose();
            return Contrato;
        }

        public ContratoBE SeleccionaUltimo(int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Contrato_SeleccionaUltimo");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ContratoBE Contrato = null;
            while (reader.Read())
            {
                Contrato = new ContratoBE();
                Contrato.IdContrato = Int32.Parse(reader["IdContrato"].ToString());
                Contrato.IdTipoContrato = Int32.Parse(reader["IdTipoContrato"].ToString());
                Contrato.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Contrato.IdTipoTrabajador = Int32.Parse(reader["IdTipoTrabajador"].ToString());
                Contrato.DescTipoTrabajador = reader["DescTipoTrabajador"].ToString();
                Contrato.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Contrato.RazonSocial = reader["RazonSocial"].ToString();
                Contrato.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Contrato.ApeNom = reader["ApeNom"].ToString();
                Contrato.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Contrato.DescTienda = reader["DescTienda"].ToString();
                Contrato.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Contrato.DescArea = reader["DescArea"].ToString();
                Contrato.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Contrato.DescCargo = reader["DescCargo"].ToString();
                Contrato.IdHorario = Int32.Parse(reader["IdHorario"].ToString());
                Contrato.DescHorario = reader["DescHorario"].ToString();
                //Contrato.Numero = Int32.Parse(reader["Numero"].ToString());
                Contrato.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                Contrato.FechaVen = reader.IsDBNull(reader.GetOrdinal("FechaVen")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVen"));
                Contrato.IdTipoRenta = Int32.Parse(reader["IdTipoRenta"].ToString());
                Contrato.DescTipoRenta = reader["DescTipoRenta"].ToString();
                Contrato.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
                Contrato.HoraExtra = Decimal.Parse(reader["HoraExtra"].ToString());
                Contrato.BonSueldo = Decimal.Parse(reader["BonSueldo"].ToString());
                Contrato.Movilidad = Decimal.Parse(reader["Movilidad"].ToString());
                Contrato.SueldoNeto = Decimal.Parse(reader["SueldoNeto"].ToString());
                Contrato.IdClasificacionTrabajador = Int32.Parse(reader["IdClasificacionTrabajador"].ToString());
                Contrato.DescClasificacionTrabajador = reader["DescClasificacionTrabajador"].ToString();
                Contrato.RutaContrato = reader["RutaContrato"].ToString();
                Contrato.Observacion = reader["Observacion"].ToString();
                Contrato.Dias = Int32.Parse(reader["Dias"].ToString());
                Contrato.Meses = Int32.Parse(reader["Meses"].ToString());
                Contrato.FlagHoraExtra = Boolean.Parse(reader["FlagHoraExtra"].ToString());
                Contrato.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                Contrato.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Contrato.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return Contrato;
        }

    }
}
