using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class PersonalDL
    {
        public PersonalDL() { }

        public Int32 Inserta(PersonaBE pItem)
        {
            Int32 intIdPersona = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_Inserta");

            db.AddOutParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pDni", DbType.String, pItem.Dni);
            db.AddInParameter(dbCommand, "pIdSexo", DbType.Int32, pItem.IdSexo);
            db.AddInParameter(dbCommand, "pNombres", DbType.String, pItem.Nombres);
            db.AddInParameter(dbCommand, "pApellidos", DbType.String, pItem.Apellidos);
            db.AddInParameter(dbCommand, "pApeNom", DbType.String, pItem.ApeNom);
            db.AddInParameter(dbCommand, "pIdCargo", DbType.Int32, pItem.IdCargo);
            db.AddInParameter(dbCommand, "pEssalud", DbType.String, pItem.Essalud);
            db.AddInParameter(dbCommand, "pFlagEps", DbType.Boolean, pItem.FlagEps);
            db.AddInParameter(dbCommand, "pFlagSctr", DbType.Boolean, pItem.FlagSctr);
            db.AddInParameter(dbCommand, "pFlagOnp", DbType.Boolean, pItem.FlagOnp);
            db.AddInParameter(dbCommand, "pIdPlaAfp", DbType.Int32, pItem.IdPlaAfp);
            db.AddInParameter(dbCommand, "pCuspp", DbType.String, pItem.Cuspp);
            db.AddInParameter(dbCommand, "pFlagPensionista", DbType.Boolean, pItem.FlagPensionista);
            db.AddInParameter(dbCommand, "pBrevete", DbType.String, pItem.Brevete);
            db.AddInParameter(dbCommand, "pIdEstadoCivil", DbType.Int32, pItem.IdEstadoCivil);
            db.AddInParameter(dbCommand, "pFechaNac", DbType.DateTime, pItem.FechaNac);
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
            db.AddInParameter(dbCommand, "pCelular", DbType.String, pItem.Celular);
            db.AddInParameter(dbCommand, "pTelefonoOtro", DbType.String, pItem.TelefonoOtro);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pFoto", DbType.Binary, pItem.Foto);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pRutaCV", DbType.String, pItem.RutaCV);
            db.AddInParameter(dbCommand, "pFechaIngreso", DbType.DateTime, pItem.FechaIngreso);
            db.AddInParameter(dbCommand, "pFechaCese", DbType.DateTime, pItem.FechaCese);
            db.AddInParameter(dbCommand, "pDescanso", DbType.String, pItem.Descanso);
            db.AddInParameter(dbCommand, "pFlagHoraExtra", DbType.Boolean, pItem.FlagHoraExtra);
            db.AddInParameter(dbCommand, "pFlagAsignacion", DbType.Boolean, pItem.FlagAsignacion);
            db.AddInParameter(dbCommand, "pRuc", DbType.String, pItem.Ruc);
            db.AddInParameter(dbCommand, "pUsuarioSol", DbType.String, pItem.UsuarioSol);
            db.AddInParameter(dbCommand, "pClaveSol", DbType.String, pItem.ClaveSol);
            db.AddInParameter(dbCommand, "pFlagApoyo", DbType.Boolean, pItem.FlagApoyo);
            db.AddInParameter(dbCommand, "pMotivoCese", DbType.String, pItem.MotivoCese);
            db.AddInParameter(dbCommand, "pFlagAsistencia", DbType.Boolean, pItem.FlagAsistencia);
            db.AddInParameter(dbCommand, "pSueldo", DbType.Decimal, pItem.Sueldo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.AddInParameter(dbCommand, "pDiscapacidad", DbType.Int32, pItem.Discapacidad);
            db.AddInParameter(dbCommand, "pClasificaPuesto", DbType.Int32, pItem.ClasificaPuesto);
            db.AddInParameter(dbCommand, "pSituacionEspecial", DbType.Int32, pItem.SituacionEspecial);

            db.ExecuteNonQuery(dbCommand);

            intIdPersona = (int)db.GetParameterValue(dbCommand, "pIdPersona");

            return intIdPersona;


        }

        public void Actualiza(PersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_Actualiza");

            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pDni", DbType.String, pItem.Dni);
            db.AddInParameter(dbCommand, "pIdSexo", DbType.Int32, pItem.IdSexo);
            db.AddInParameter(dbCommand, "pNombres", DbType.String, pItem.Nombres);
            db.AddInParameter(dbCommand, "pApellidos", DbType.String, pItem.Apellidos);
            db.AddInParameter(dbCommand, "pApeNom", DbType.String, pItem.ApeNom);
            db.AddInParameter(dbCommand, "pIdCargo", DbType.Int32, pItem.IdCargo);
            db.AddInParameter(dbCommand, "pEssalud", DbType.String, pItem.Essalud);
            db.AddInParameter(dbCommand, "pFlagEps", DbType.Boolean, pItem.FlagEps);
            db.AddInParameter(dbCommand, "pFlagSctr", DbType.Boolean, pItem.FlagSctr);
            db.AddInParameter(dbCommand, "pFlagOnp", DbType.Boolean, pItem.FlagOnp);
            db.AddInParameter(dbCommand, "pIdPlaAfp", DbType.Int32, pItem.IdPlaAfp);
            db.AddInParameter(dbCommand, "pCuspp", DbType.String, pItem.Cuspp);
            db.AddInParameter(dbCommand, "pFlagPensionista", DbType.Boolean, pItem.FlagPensionista);
            db.AddInParameter(dbCommand, "pBrevete", DbType.String, pItem.Brevete);
            db.AddInParameter(dbCommand, "pIdEstadoCivil", DbType.Int32, pItem.IdEstadoCivil);
            db.AddInParameter(dbCommand, "pFechaNac", DbType.DateTime, pItem.FechaNac);
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
            db.AddInParameter(dbCommand, "pCelular", DbType.String, pItem.Celular);
            db.AddInParameter(dbCommand, "pTelefonoOtro", DbType.String, pItem.TelefonoOtro);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pFoto", DbType.Binary, pItem.Foto);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pRutaCV", DbType.String, pItem.RutaCV);
            db.AddInParameter(dbCommand, "pFechaIngreso", DbType.DateTime, pItem.FechaIngreso);
            db.AddInParameter(dbCommand, "pFechaCese", DbType.DateTime, pItem.FechaCese);
            db.AddInParameter(dbCommand, "pDescanso", DbType.String, pItem.Descanso);
            db.AddInParameter(dbCommand, "pFlagHoraExtra", DbType.Boolean, pItem.FlagHoraExtra);
            db.AddInParameter(dbCommand, "pFlagAsignacion", DbType.Boolean, pItem.FlagAsignacion);
            db.AddInParameter(dbCommand, "pRuc", DbType.String, pItem.Ruc);
            db.AddInParameter(dbCommand, "pUsuarioSol", DbType.String, pItem.UsuarioSol);
            db.AddInParameter(dbCommand, "pClaveSol", DbType.String, pItem.ClaveSol);
            db.AddInParameter(dbCommand, "pFlagApoyo", DbType.Boolean, pItem.FlagApoyo);
            db.AddInParameter(dbCommand, "pMotivoCese", DbType.String, pItem.MotivoCese);
            db.AddInParameter(dbCommand, "pFlagAsistencia", DbType.Boolean, pItem.FlagAsistencia);
            db.AddInParameter(dbCommand, "pSueldo", DbType.Decimal, pItem.Sueldo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.AddInParameter(dbCommand, "pDiscapacidad", DbType.Int32, pItem.Discapacidad);
            db.AddInParameter(dbCommand, "pClasificaPuesto", DbType.Int32, pItem.ClasificaPuesto);
            db.AddInParameter(dbCommand, "pSituacionEspecial", DbType.Int32, pItem.SituacionEspecial);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaDisponibilidad(int IdPersona, int IdDisponibilidad)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_ActualizaDisponibilidad");

            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pIdDisponibilidad", DbType.Int32, IdDisponibilidad);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(PersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_Elimina");

            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void EliminaFisico(PersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_EliminaFisico");

            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public List<PersonaBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personallist = new List<PersonaBE>();
            PersonaBE Personal;
            while (reader.Read())
            {
                Personal = new PersonaBE();
                Personal.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Personal.RazonSocial = reader["RazonSocial"].ToString();
                Personal.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Personal.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Personal.DescTienda = reader["DescTienda"].ToString();
                Personal.DescTipoDocumento = reader["DescTipoDocumento"].ToString();
                Personal.Dni = reader["Dni"].ToString();
                Personal.IdSexo = Int32.Parse(reader["IdSexo"].ToString());
                Personal.DescSexo = reader["DescSexo"].ToString();
                Personal.Nombres = reader["Nombres"].ToString();
                Personal.Apellidos = reader["Apellidos"].ToString();
                Personal.ApeNom = reader["ApeNom"].ToString();
                Personal.Essalud = reader["Essalud"].ToString();
                Personal.FlagEps = Boolean.Parse(reader["FlagEps"].ToString());
                Personal.FlagSctr = Boolean.Parse(reader["FlagSctr"].ToString());
                Personal.FlagOnp = Boolean.Parse(reader["FlagOnp"].ToString());
                Personal.IdPlaAfp = Int32.Parse(reader["IdPlaAfp"].ToString());
                Personal.Brevete = reader["Brevete"].ToString();
                Personal.IdEstadoCivil = Int32.Parse(reader["IdEstadoCivil"].ToString());
                Personal.DescEstadoCivil = reader["DescEstadoCivil"].ToString();
                Personal.FechaNac = DateTime.Parse(reader["FechaNac"].ToString());
                Personal.IdUbigeo = reader["IdUbigeo"].ToString();
                Personal.NomDpto = reader["NomDpto"].ToString();
                Personal.NomProv = reader["NomProv"].ToString();
                Personal.NomDist = reader["NomDist"].ToString();
                Personal.Direccion = reader["Direccion"].ToString();
                Personal.Telefono = reader["Telefono"].ToString();
                Personal.Celular = reader["Celular"].ToString();
                Personal.TelefonoOtro = reader["TelefonoOtro"].ToString();
                Personal.Email = reader["Email"].ToString();
                //Personal.Foto = (byte[])reader["Foto"];
                Personal.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Personal.DescCargo = reader["DescCargo"].ToString();
                Personal.Descanso = reader["Descanso"].ToString();
                Personal.Observacion = reader["Observacion"].ToString();
                Personal.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Personal.DescArea = reader["DescArea"].ToString();
                Personal.RutaCV = reader["RutaCV"].ToString();
                Personal.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Personal.FechaCese = reader.IsDBNull(reader.GetOrdinal("FechaCese")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCese"));
                Personal.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
                Personal.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Personal.FechaInicioContrato = reader.IsDBNull(reader.GetOrdinal("FechaInicioContrato")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaInicioContrato"));
                Personal.FechaFinContrato = reader.IsDBNull(reader.GetOrdinal("FechaFinContrato")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaFinContrato"));
                Personal.DescTipoRenta = reader["DescTipoRenta"].ToString();
                Personal.Ruc = reader["Ruc"].ToString();
                Personal.UsuarioSol = reader["UsuarioSol"].ToString();
                Personal.ClaveSol = reader["ClaveSol"].ToString();
                Personal.DescBanco = reader["DescBanco"].ToString();
                Personal.NumeroCuenta = reader["NumeroCuenta"].ToString();
                Personal.Edad = Int32.Parse(reader["Edad"].ToString());
                Personal.DiasVacaciones = Int32.Parse(reader["DiasVacaciones"].ToString());
                Personal.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Personal.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());

                Personallist.Add(Personal);
            }
            reader.Close();
            reader.Dispose();
            return Personallist;
        }

        public List<PersonaBE> ListaTodos(int IdEmpresa, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_ListaTodos");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personallist = new List<PersonaBE>();
            PersonaBE Personal;
            while (reader.Read())
            {
                Personal = new PersonaBE();
                Personal.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Personal.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Personal.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Personal.DescTienda = reader["DescTienda"].ToString();
                Personal.DescTipoDocumento = reader["DescTipoDocumento"].ToString();
                Personal.Dni = reader["Dni"].ToString();
                Personal.IdSexo = Int32.Parse(reader["IdSexo"].ToString());
                Personal.DescSexo = reader["DescSexo"].ToString();
                Personal.Nombres = reader["Nombres"].ToString();
                Personal.Apellidos = reader["Apellidos"].ToString();
                Personal.ApeNom = reader["ApeNom"].ToString();
                Personal.Essalud = reader["Essalud"].ToString();
                Personal.FlagEps = Boolean.Parse(reader["FlagEps"].ToString());
                Personal.FlagSctr = Boolean.Parse(reader["FlagSctr"].ToString());
                Personal.FlagOnp = Boolean.Parse(reader["FlagOnp"].ToString());
                Personal.IdPlaAfp = Int32.Parse(reader["IdPlaAfp"].ToString());
                Personal.Brevete = reader["Brevete"].ToString();
                Personal.IdEstadoCivil = Int32.Parse(reader["IdEstadoCivil"].ToString());
                Personal.DescEstadoCivil = reader["DescEstadoCivil"].ToString();
                Personal.FechaNac = DateTime.Parse(reader["FechaNac"].ToString());
                Personal.IdUbigeo = reader["IdUbigeo"].ToString();
                Personal.NomDpto = reader["NomDpto"].ToString();
                Personal.NomProv = reader["NomProv"].ToString();
                Personal.NomDist = reader["NomDist"].ToString();
                Personal.Direccion = reader["Direccion"].ToString();
                Personal.Telefono = reader["Telefono"].ToString();
                Personal.Celular = reader["Celular"].ToString();
                Personal.TelefonoOtro = reader["TelefonoOtro"].ToString();
                Personal.Email = reader["Email"].ToString();
                //Personal.Foto = (byte[])reader["Foto"];
                Personal.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Personal.DescCargo = reader["DescCargo"].ToString();
                Personal.Descanso = reader["Descanso"].ToString();
                Personal.Observacion = reader["Observacion"].ToString();
                Personal.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Personal.DescArea = reader["DescArea"].ToString();
                Personal.RutaCV = reader["RutaCV"].ToString();
                Personal.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Personal.FechaCese = reader.IsDBNull(reader.GetOrdinal("FechaCese")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCese"));
                Personal.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
                Personal.DescTipoContrato = reader["DescTipoContrato"].ToString();
                Personal.DescTipoRenta = reader["DescTipoRenta"].ToString();
                Personal.Ruc = reader["Ruc"].ToString();
                Personal.UsuarioSol = reader["UsuarioSol"].ToString();
                Personal.ClaveSol = reader["ClaveSol"].ToString();
                Personal.DescBanco = reader["DescBanco"].ToString();
                Personal.NumeroCuenta = reader["NumeroCuenta"].ToString();
                Personal.DiasVacaciones = Int32.Parse(reader["DiasVacaciones"].ToString());
                Personal.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Personal.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
                Personallist.Add(Personal);
            }
            reader.Close();
            reader.Dispose();
            return Personallist;
        }

        public List<PersonaBE> ListaDescanso(DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_ListaDescanso");
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personallist = new List<PersonaBE>();
            PersonaBE Personal;
            while (reader.Read())
            {
                Personal = new PersonaBE();
                Personal.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Personal.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Personal.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Personal.DescTienda = reader["DescTienda"].ToString();
                Personal.Dni = reader["Dni"].ToString();
                Personal.IdSexo = Int32.Parse(reader["IdSexo"].ToString());
                Personal.DescSexo = reader["DescSexo"].ToString();
                Personal.Nombres = reader["Nombres"].ToString();
                Personal.Apellidos = reader["Apellidos"].ToString();
                Personal.ApeNom = reader["ApeNom"].ToString();
                Personal.Essalud = reader["Essalud"].ToString();
                Personal.FlagEps = Boolean.Parse(reader["FlagEps"].ToString());
                Personal.FlagSctr = Boolean.Parse(reader["FlagSctr"].ToString());
                Personal.FlagOnp = Boolean.Parse(reader["FlagOnp"].ToString());
                Personal.IdPlaAfp = Int32.Parse(reader["IdPlaAfp"].ToString());
                Personal.Brevete = reader["Brevete"].ToString();
                Personal.IdEstadoCivil = Int32.Parse(reader["IdEstadoCivil"].ToString());
                Personal.DescEstadoCivil = reader["DescEstadoCivil"].ToString();
                Personal.FechaNac = DateTime.Parse(reader["FechaNac"].ToString());
                Personal.IdUbigeo = reader["IdUbigeo"].ToString();
                Personal.NomDpto = reader["NomDpto"].ToString();
                Personal.NomProv = reader["NomProv"].ToString();
                Personal.NomDist = reader["NomDist"].ToString();
                Personal.Direccion = reader["Direccion"].ToString();
                Personal.Telefono = reader["Telefono"].ToString();
                Personal.Celular = reader["Celular"].ToString();
                Personal.TelefonoOtro = reader["TelefonoOtro"].ToString();
                Personal.Email = reader["Email"].ToString();
                //Personal.Foto = (byte[])reader["Foto"];
                Personal.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Personal.DescCargo = reader["DescCargo"].ToString();
                Personal.Descanso = reader["Descanso"].ToString();
                Personal.Observacion = reader["Observacion"].ToString();
                Personal.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Personal.DescArea = reader["DescArea"].ToString();
                Personal.RutaCV = reader["RutaCV"].ToString();
                Personal.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Personal.FechaCese = reader.IsDBNull(reader.GetOrdinal("FechaCese")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCese"));
                Personal.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
                Personal.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Personallist.Add(Personal);
            }
            reader.Close();
            reader.Dispose();
            return Personallist;
        }

        public List<PersonaBE> ListaApoyo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_ListaApoyo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personallist = new List<PersonaBE>();
            PersonaBE Personal;
            while (reader.Read())
            {
                Personal = new PersonaBE();
                Personal.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Personal.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Personal.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Personal.DescTienda = reader["DescTienda"].ToString();
                Personal.Dni = reader["Dni"].ToString();
                Personal.IdSexo = Int32.Parse(reader["IdSexo"].ToString());
                Personal.DescSexo = reader["DescSexo"].ToString();
                Personal.Nombres = reader["Nombres"].ToString();
                Personal.Apellidos = reader["Apellidos"].ToString();
                Personal.ApeNom = reader["ApeNom"].ToString();
                Personal.Essalud = reader["Essalud"].ToString();
                Personal.FlagEps = Boolean.Parse(reader["FlagEps"].ToString());
                Personal.FlagSctr = Boolean.Parse(reader["FlagSctr"].ToString());
                Personal.FlagOnp = Boolean.Parse(reader["FlagOnp"].ToString());
                Personal.IdPlaAfp = Int32.Parse(reader["IdPlaAfp"].ToString());
                Personal.Brevete = reader["Brevete"].ToString();
                Personal.IdEstadoCivil = Int32.Parse(reader["IdEstadoCivil"].ToString());
                Personal.DescEstadoCivil = reader["DescEstadoCivil"].ToString();
                Personal.FechaNac = DateTime.Parse(reader["FechaNac"].ToString());
                Personal.IdUbigeo = reader["IdUbigeo"].ToString();
                Personal.NomDpto = reader["NomDpto"].ToString();
                Personal.NomProv = reader["NomProv"].ToString();
                Personal.NomDist = reader["NomDist"].ToString();
                Personal.Direccion = reader["Direccion"].ToString();
                Personal.Telefono = reader["Telefono"].ToString();
                Personal.Celular = reader["Celular"].ToString();
                Personal.TelefonoOtro = reader["TelefonoOtro"].ToString();
                Personal.Email = reader["Email"].ToString();
                //Personal.Foto = (byte[])reader["Foto"];
                Personal.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Personal.DescCargo = reader["DescCargo"].ToString();
                Personal.Descanso = reader["Descanso"].ToString();
                Personal.Observacion = reader["Observacion"].ToString();
                Personal.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Personal.DescArea = reader["DescArea"].ToString();
                Personal.RutaCV = reader["RutaCV"].ToString();
                Personal.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Personal.FechaCese = reader.IsDBNull(reader.GetOrdinal("FechaCese")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCese"));
                Personal.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
                Personal.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Personallist.Add(Personal);
            }
            reader.Close();
            reader.Dispose();
            return Personallist;
        }

        public PersonaBE Selecciona(int IdEmpresa, int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PersonaBE Personal = null;
            while (reader.Read())
            {
                Personal = new PersonaBE();
                Personal.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Personal.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Personal.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Personal.DescTienda = reader["DescTienda"].ToString();
                Personal.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Personal.Dni = reader["Dni"].ToString();
                Personal.IdSexo = Int32.Parse(reader["IdSexo"].ToString());
                Personal.DescSexo = reader["DescSexo"].ToString();
                Personal.Nombres = reader["Nombres"].ToString();
                Personal.Apellidos = reader["Apellidos"].ToString();
                Personal.ApeNom = reader["ApeNom"].ToString();
                Personal.Essalud = reader["Essalud"].ToString();
                Personal.FlagEps = Boolean.Parse(reader["FlagEps"].ToString());
                Personal.FlagSctr = Boolean.Parse(reader["FlagSctr"].ToString());
                Personal.FlagOnp = Boolean.Parse(reader["FlagOnp"].ToString());
                Personal.IdPlaAfp = Int32.Parse(reader["IdPlaAfp"].ToString());
                Personal.Cuspp = reader["Cuspp"].ToString();
                Personal.FlagPensionista = Boolean.Parse(reader["FlagPensionista"].ToString());
                Personal.Brevete = reader["Brevete"].ToString();
                Personal.IdEstadoCivil = Int32.Parse(reader["IdEstadoCivil"].ToString());
                Personal.DescEstadoCivil = reader["DescEstadoCivil"].ToString();
                Personal.FechaNac = DateTime.Parse(reader["FechaNac"].ToString());
                Personal.IdUbigeo = reader["IdUbigeo"].ToString();
                Personal.NomDpto = reader["NomDpto"].ToString();
                Personal.NomProv = reader["NomProv"].ToString();
                Personal.NomDist = reader["NomDist"].ToString();
                Personal.Direccion = reader["Direccion"].ToString();
                Personal.Telefono = reader["Telefono"].ToString();
                Personal.Celular = reader["Celular"].ToString();
                Personal.TelefonoOtro = reader["TelefonoOtro"].ToString();
                Personal.Email = reader["Email"].ToString();
                Personal.Foto = (byte[])reader["Foto"];
                Personal.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Personal.DescCargo = reader["DescCargo"].ToString();
                Personal.Observacion = reader["Observacion"].ToString();
                Personal.Observacion = reader["Observacion"].ToString();
                Personal.Descanso = reader["Descanso"].ToString();
                Personal.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Personal.RutaCV = reader["RutaCV"].ToString();
                Personal.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Personal.FechaCese = reader.IsDBNull(reader.GetOrdinal("FechaCese")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCese"));
                Personal.FlagHoraExtra = Boolean.Parse(reader["FlagHoraExtra"].ToString());
                Personal.FlagAsignacion = Boolean.Parse(reader["FlagAsignacion"].ToString());
                Personal.Ruc = reader["Ruc"].ToString();
                Personal.UsuarioSol = reader["UsuarioSol"].ToString();
                Personal.ClaveSol = reader["ClaveSol"].ToString();
                Personal.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
                Personal.MotivoCese = reader["MotivoCese"].ToString();
                Personal.FlagAsistencia = Boolean.Parse(reader["FlagAsistencia"].ToString());
                Personal.Sueldo = decimal.Parse(reader["Sueldo"].ToString());
                Personal.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                Personal.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Personal.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

                Personal.Discapacidad = Int32.Parse(reader["Discapacidad"].ToString());
                Personal.SituacionEspecial = Int32.Parse(reader["SituacionEspecial"].ToString());
                Personal.ClasificaPuesto = Int32.Parse(reader["ClasificaPuesto"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Personal;
        }

        public PersonaBE SeleccionaNumeroDocumento(string Dni)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_SeleccionaNumeroDocumento");
            db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PersonaBE Personal = null;
            while (reader.Read())
            {
                Personal = new PersonaBE();
                Personal.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Personal.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Personal.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Personal.DescTienda = reader["DescTienda"].ToString();
                Personal.Dni = reader["Dni"].ToString();
                Personal.IdSexo = Int32.Parse(reader["IdSexo"].ToString());
                Personal.DescSexo = reader["DescSexo"].ToString();
                Personal.Nombres = reader["Nombres"].ToString();
                Personal.Apellidos = reader["Apellidos"].ToString();
                Personal.ApeNom = reader["ApeNom"].ToString();
                Personal.Essalud = reader["Essalud"].ToString();
                Personal.FlagEps = Boolean.Parse(reader["FlagEps"].ToString());
                Personal.FlagSctr = Boolean.Parse(reader["FlagSctr"].ToString());
                Personal.FlagOnp = Boolean.Parse(reader["FlagOnp"].ToString());
                Personal.IdPlaAfp = Int32.Parse(reader["IdPlaAfp"].ToString());
                Personal.Brevete = reader["Brevete"].ToString();
                Personal.IdEstadoCivil = Int32.Parse(reader["IdEstadoCivil"].ToString());
                Personal.DescEstadoCivil = reader["DescEstadoCivil"].ToString();
                Personal.FechaNac = DateTime.Parse(reader["FechaNac"].ToString());
                Personal.IdUbigeo = reader["IdUbigeo"].ToString();
                Personal.NomDpto = reader["NomDpto"].ToString();
                Personal.NomProv = reader["NomProv"].ToString();
                Personal.NomDist = reader["NomDist"].ToString();
                Personal.Direccion = reader["Direccion"].ToString();
                Personal.Telefono = reader["Telefono"].ToString();
                Personal.Celular = reader["Celular"].ToString();
                Personal.TelefonoOtro = reader["TelefonoOtro"].ToString();
                Personal.Email = reader["Email"].ToString();
                //Personal.Foto = (byte[])reader["Foto"];
                Personal.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Personal.DescCargo = reader["DescCargo"].ToString();
                Personal.Observacion = reader["Observacion"].ToString();
                Personal.Observacion = reader["Observacion"].ToString();
                Personal.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Personal.RutaCV = reader["RutaCV"].ToString();
                Personal.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Personal.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
                Personal.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Personal;
        }

        public List<PersonaBE> SeleccionaBusqueda()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_SeleccionaBusqueda");
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personallist = new List<PersonaBE>();
            PersonaBE Persona;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Persona.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Persona.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Persona.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Persona.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Persona.ApeNom = reader["apenom"].ToString();

                Personallist.Add(Persona);
            }
            reader.Close();
            reader.Dispose();
            return Personallist;
        }

        public List<PersonaBE> SeleccionaBusquedaSinUsuario()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_SeleccionaBusquedaSinUsuario");
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personallist = new List<PersonaBE>();
            PersonaBE Persona;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Persona.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Persona.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Persona.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Persona.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Persona.ApeNom = reader["apenom"].ToString();

                Personallist.Add(Persona);
            }
            reader.Close();
            reader.Dispose();
            return Personallist;
        }

        public List<PersonaBE> SeleccionaCargo(int IdEmpresa, int IdCargo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_SeleccionaCargo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCargo", DbType.Int32, IdCargo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personallist = new List<PersonaBE>();
            PersonaBE Persona;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Persona.ApeNom = reader["apenom"].ToString();

                Personallist.Add(Persona);
            }
            reader.Close();
            reader.Dispose();
            return Personallist;
        }

        public List<PersonaBE> SeleccionaVendedor(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_SeleccionaVendedor");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personallist = new List<PersonaBE>();
            PersonaBE Persona;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Persona.ApeNom = reader["apenom"].ToString();

                Personallist.Add(Persona);
            }
            reader.Close();
            reader.Dispose();
            return Personallist;
        }

        public List<PersonaBE> SeleccionaVendedorTodos(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_SeleccionaVendedorTodos");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personallist = new List<PersonaBE>();
            PersonaBE Persona;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Persona.ApeNom = reader["apenom"].ToString();

                Personallist.Add(Persona);
            }
            reader.Close();
            reader.Dispose();
            return Personallist;
        }

        public List<PersonaBE> SeleccionaConductor(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_SeleccionaConductor");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personallist = new List<PersonaBE>();
            PersonaBE Persona;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Persona.ApeNom = reader["apenom"].ToString();

                Personallist.Add(Persona);
            }
            reader.Close();
            reader.Dispose();
            return Personallist;
        }

        public List<PersonaBE> SeleccionaGerencia(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_SeleccionaGerencia");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personallist = new List<PersonaBE>();
            PersonaBE Persona;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Persona.ApeNom = reader["apenom"].ToString();

                Personallist.Add(Persona);
            }
            reader.Close();
            reader.Dispose();
            return Personallist;
        }

        public List<PersonaBE> SeleccionaAuxiliar(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_SeleccionaAuxiliar");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personallist = new List<PersonaBE>();
            PersonaBE Persona;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Persona.ApeNom = reader["apenom"].ToString();

                Personallist.Add(Persona);
            }
            reader.Close();
            reader.Dispose();
            return Personallist;
        }

        public List<PersonaBE> SeleccionaAsesor(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_SeleccionaAsesor");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personallist = new List<PersonaBE>();
            PersonaBE Persona;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Persona.ApeNom = reader["apenom"].ToString();

                Personallist.Add(Persona);
            }
            reader.Close();
            reader.Dispose();
            return Personallist;
        }

        public List<PersonaBE> SeleccionaSistemas(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_SeleccionSistemas");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personallist = new List<PersonaBE>();
            PersonaBE Persona;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Persona.ApeNom = reader["apenom"].ToString();

                Personallist.Add(Persona);
            }
            reader.Close();
            reader.Dispose();
            return Personallist;
        }

        public List<PersonaBE> ListaArea(int IdEmpresa, int IdArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_ListaArea");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personallist = new List<PersonaBE>();
            PersonaBE Persona;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Persona.ApeNom = reader["apenom"].ToString();

                Personallist.Add(Persona);
            }
            reader.Close();
            reader.Dispose();
            return Personallist;
        }

        public List<PersonaBE> ListaCumpleaño()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_Cumpleanio");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personallist = new List<PersonaBE>();
            PersonaBE Persona;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Persona.Dni = reader["Dni"].ToString();
                Persona.Nombres = reader["Nombres"].ToString();
                Persona.ApeNom = reader["apenom"].ToString();
                Persona.DescTienda = reader["DescTienda"].ToString();
                Persona.DescArea = reader["DescArea"].ToString();
                Persona.DescCargo = reader["DescCargo"].ToString();
                Personallist.Add(Persona);
            }
            reader.Close();
            reader.Dispose();
            return Personallist;
        }

        public List<PersonaBE> ListaEnviaCorreoErrorPSE()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_EnviaCorreoErrorPSE");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personallist = new List<PersonaBE>();
            PersonaBE Persona;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Persona.DescSexo = reader["DescSexo"].ToString();
                Persona.Email = reader["Email"].ToString();
                Persona.Nombres = reader["Nombres"].ToString();

                Personallist.Add(Persona);
            }
            reader.Close();
            reader.Dispose();
            return Personallist;
        }

        public PersonaBE Selecciona_UsuarioValidar(int IdEmpresa, int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_Selecciona_Validar");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PersonaBE Personal = null;
            while (reader.Read())
            {
                Personal = new PersonaBE();
                Personal.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Personal.Usuario = reader["Usuario"].ToString();
                Personal.Password = reader["Password"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return Personal;
        }

        public PersonaBE SeleccionaNumeroDocumentoPersonal(string Dni)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_SeleccionaNumeroDocumentoPersonal");
            db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PersonaBE Personal = null;
            while (reader.Read())
            {
                Personal = new PersonaBE();
                Personal.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Personal.Dni = reader["Dni"].ToString();
                Personal.Nombres = reader["Nombres"].ToString();
                Personal.Apellidos = reader["Apellidos"].ToString();
                Personal.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                //Personal.FechaCese = DateTime.Parse(reader["FechaCese"].ToString());
                Personal.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Personal;
        }
        public List<PersonaBE> SeleccionaDisenador(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_SeleccionaDisenador");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Personallist = new List<PersonaBE>();
            PersonaBE Persona;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Persona.ApeNom = reader["apenom"].ToString();

                Personallist.Add(Persona);
            }
            reader.Close();
            reader.Dispose();
            return Personallist;
        }

        public List<PersonaBE> SeleccionaBusqueda(int IdEmpresa, int IdTipoCliente, string pFiltro, int Pagina, int CantidadRegistro, int TipoBusqueda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_SeleccionaBus");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);
            db.AddInParameter(dbCommand, "pTipoBusqueda", DbType.String, TipoBusqueda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaBE> Proveedorlist = new List<PersonaBE>();
            PersonaBE Persona;
            while (reader.Read())
            {
                Persona = new PersonaBE();
                Persona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Persona.Dni = reader["Dni"].ToString();
                Persona.ApeNom = reader["ApeNom"].ToString();
                Proveedorlist.Add(Persona);
            }
            reader.Close();
            reader.Dispose();
            return Proveedorlist;
        }

        public int SeleccionaBusquedaCount(int IdEmpresa, int IdTipoCliente, string pFiltro, int TipoBusqueda)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_SeleccionaBusCount");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);
            db.AddInParameter(dbCommand, "pTipoBusqueda", DbType.Int32, TipoBusqueda);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }
        public PersonaBE SeleccionaPersonal(string pNumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_SeleccionaNumDoc");
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pNumeroDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PersonaBE Personal = null;
            while (reader.Read())
            {
                Personal = new PersonaBE();
                Personal.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Personal.Dni = reader["Dni"].ToString();
                Personal.ApeNom = reader["ApeNom"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return Personal;
        }
    }
}
