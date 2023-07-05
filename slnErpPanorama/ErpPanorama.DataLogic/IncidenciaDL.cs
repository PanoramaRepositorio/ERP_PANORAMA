using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class IncidenciaDL
    {
        public IncidenciaDL() { }

        public void Inserta(IncidenciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Incidencia_Inserta");

            db.AddInParameter(dbCommand, "pIdIncidencia", DbType.Int32, pItem.IdIncidencia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdSolicitante", DbType.Int32, pItem.IdSolicitante);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pSolucion", DbType.String, pItem.Solucion);
            db.AddInParameter(dbCommand, "pIdResponsable", DbType.Int32, pItem.IdResponsable);
            db.AddInParameter(dbCommand, "pFechaCierre", DbType.DateTime, pItem.FechaCierre);
            db.AddInParameter(dbCommand, "pFechaLimite", DbType.DateTime, pItem.FechaLimite);
            db.AddInParameter(dbCommand, "pIdPrioridad", DbType.Int32, pItem.IdPrioridad);
            db.AddInParameter(dbCommand, "pIdEstado", DbType.Int32, pItem.IdEstado);
            db.AddInParameter(dbCommand, "pObservacion", DbType.Int32, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(IncidenciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Incidencia_Actualiza");

            db.AddInParameter(dbCommand, "pIdIncidencia", DbType.Int32, pItem.IdIncidencia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdSolicitante", DbType.Int32, pItem.IdSolicitante);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pSolucion", DbType.String, pItem.Solucion);
            db.AddInParameter(dbCommand, "pIdResponsable", DbType.Int32, pItem.IdResponsable);
            db.AddInParameter(dbCommand, "pFechaCierre", DbType.DateTime, pItem.FechaCierre);
            db.AddInParameter(dbCommand, "pFechaLimite", DbType.DateTime, pItem.FechaLimite);
            db.AddInParameter(dbCommand, "pIdPrioridad", DbType.Int32, pItem.IdPrioridad);
            db.AddInParameter(dbCommand, "pIdEstado", DbType.Int32, pItem.IdEstado);
            db.AddInParameter(dbCommand, "pObservacion", DbType.Int32, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(IncidenciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Incidencia_Elimina");

            db.AddInParameter(dbCommand, "pIdIncidencia", DbType.Int32, pItem.IdIncidencia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<IncidenciaBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Incidencia_ListaTodosActivo");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<IncidenciaBE> Incidencialist = new List<IncidenciaBE>();
            IncidenciaBE Incidencia;
            while (reader.Read())
            {
                Incidencia = new IncidenciaBE();
                Incidencia.RowNumber = Int32.Parse(reader["RowNumber"].ToString());
                Incidencia.IdIncidencia = Int32.Parse(reader["IdIncidencia"].ToString());
                Incidencia.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Incidencia.Numero = reader["Numero"].ToString();
                Incidencia.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Incidencia.IdSolicitante = Int32.Parse(reader["IdSolicitante"].ToString());
                Incidencia.Solicitante = reader["Solicitante"].ToString();
                Incidencia.DescArea = reader["DescArea"].ToString();
                Incidencia.Descripcion = reader["Descripcion"].ToString();
                Incidencia.Solucion = reader["Solucion"].ToString();
                Incidencia.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                Incidencia.Responsable = reader["Responsable"].ToString();
                Incidencia.FechaCierre = reader.IsDBNull(reader.GetOrdinal("FechaCierre")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCierre"));
                Incidencia.FechaLimite = reader.IsDBNull(reader.GetOrdinal("FechaLimite")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaLimite"));
                Incidencia.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                Incidencia.IdPrioridad = Int32.Parse(reader["IdPrioridad"].ToString());
                Incidencia.DescPrioridad = reader["DescPrioridad"].ToString();
                Incidencia.IdEstado = Int32.Parse(reader["IdEstado"].ToString());
                Incidencia.DescEstado = reader["DescEstado"].ToString();
                Incidencia.Observacion = reader["Observacion"].ToString();
                Incidencia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Incidencialist.Add(Incidencia);
            }
            reader.Close();
            reader.Dispose();
            return Incidencialist;
        }

        public List<IncidenciaBE> ListaFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Incidencia_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<IncidenciaBE> Incidencialist = new List<IncidenciaBE>();
            IncidenciaBE Incidencia;
            while (reader.Read())
            {
                Incidencia = new IncidenciaBE();
                Incidencia.RowNumber = Int32.Parse(reader["RowNumber"].ToString());
                Incidencia.IdIncidencia = Int32.Parse(reader["IdIncidencia"].ToString());
                Incidencia.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Incidencia.Numero = reader["Numero"].ToString();
                Incidencia.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Incidencia.IdSolicitante = Int32.Parse(reader["IdSolicitante"].ToString());
                Incidencia.Solicitante = reader["Solicitante"].ToString();
                Incidencia.DescArea = reader["DescArea"].ToString();
                Incidencia.Descripcion = reader["Descripcion"].ToString();
                Incidencia.Solucion = reader["Solucion"].ToString();
                Incidencia.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                Incidencia.Responsable = reader["Responsable"].ToString();
                Incidencia.FechaCierre = reader.IsDBNull(reader.GetOrdinal("FechaCierre")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCierre"));
                Incidencia.FechaLimite = reader.IsDBNull(reader.GetOrdinal("FechaLimite")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaLimite"));
                Incidencia.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                Incidencia.IdPrioridad = Int32.Parse(reader["IdPrioridad"].ToString());
                Incidencia.DescPrioridad = reader["DescPrioridad"].ToString();
                Incidencia.IdEstado = Int32.Parse(reader["IdEstado"].ToString());
                Incidencia.DescEstado = reader["DescEstado"].ToString();
                Incidencia.Observacion = reader["Observacion"].ToString();
                Incidencia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Incidencialist.Add(Incidencia);
            }
            reader.Close();
            reader.Dispose();
            return Incidencialist;
        }

        public List<IncidenciaBE> ListaNumero(int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Incidencia_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<IncidenciaBE> Incidencialist = new List<IncidenciaBE>();
            IncidenciaBE Incidencia;
            while (reader.Read())
            {
                Incidencia = new IncidenciaBE();
                //Incidencia.RowNumber = Int32.Parse(reader["RowNumber"].ToString());
                Incidencia.IdIncidencia = Int32.Parse(reader["IdIncidencia"].ToString());
                Incidencia.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Incidencia.Numero = reader["Numero"].ToString();
                Incidencia.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Incidencia.IdSolicitante = Int32.Parse(reader["IdSolicitante"].ToString());
                Incidencia.Solicitante = reader["Solicitante"].ToString();
                Incidencia.DescArea = reader["DescArea"].ToString();
                Incidencia.Descripcion = reader["Descripcion"].ToString();
                Incidencia.Solucion = reader["Solucion"].ToString();
                Incidencia.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                Incidencia.Responsable = reader["Responsable"].ToString();
                Incidencia.FechaCierre = reader.IsDBNull(reader.GetOrdinal("FechaCierre")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCierre"));
                Incidencia.FechaLimite = reader.IsDBNull(reader.GetOrdinal("FechaLimite")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaLimite"));
                Incidencia.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                Incidencia.IdPrioridad = Int32.Parse(reader["IdPrioridad"].ToString());
                Incidencia.DescPrioridad = reader["DescPrioridad"].ToString();
                Incidencia.IdEstado = Int32.Parse(reader["IdEstado"].ToString());
                Incidencia.DescEstado = reader["DescEstado"].ToString();
                Incidencia.Observacion = reader["Observacion"].ToString();
                Incidencia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Incidencialist.Add(Incidencia);
            }
            reader.Close();
            reader.Dispose();
            return Incidencialist;
        }

        public IncidenciaBE Selecciona(int IdIncidencia)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Incidencia_Selecciona");
            db.AddInParameter(dbCommand, "pIdIncidencia", DbType.Int32, IdIncidencia);

            IDataReader reader = db.ExecuteReader(dbCommand);
            IncidenciaBE Incidencia = null;
            while (reader.Read())
            {
                Incidencia = new IncidenciaBE();
                //Incidencia.RowNumber = Int32.Parse(reader["RowNumber"].ToString());
                Incidencia.IdIncidencia = Int32.Parse(reader["IdIncidencia"].ToString());
                Incidencia.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Incidencia.Numero = reader["Numero"].ToString();
                Incidencia.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Incidencia.IdSolicitante = Int32.Parse(reader["IdSolicitante"].ToString());
                Incidencia.Solicitante = reader["Solicitante"].ToString();
                Incidencia.DescArea = reader["DescArea"].ToString();
                Incidencia.Descripcion = reader["Descripcion"].ToString();
                Incidencia.Solucion = reader["Solucion"].ToString();
                Incidencia.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                Incidencia.Responsable = reader["Responsable"].ToString();
                Incidencia.FechaCierre = reader.IsDBNull(reader.GetOrdinal("FechaCierre")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCierre"));
                Incidencia.FechaLimite = reader.IsDBNull(reader.GetOrdinal("FechaLimite")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaLimite"));
                Incidencia.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                Incidencia.IdPrioridad = Int32.Parse(reader["IdPrioridad"].ToString());
                Incidencia.DescPrioridad = reader["DescPrioridad"].ToString();
                Incidencia.IdEstado = Int32.Parse(reader["IdEstado"].ToString());
                Incidencia.DescEstado = reader["DescEstado"].ToString();
                Incidencia.Observacion = reader["Observacion"].ToString();
                Incidencia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Incidencia;
        }
    }
}
