using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class AnuncioDL
    {
        public AnuncioDL() { }

        public void Inserta(AnuncioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Anuncio_Inserta");

            db.AddInParameter(dbCommand, "pIdAnuncio", DbType.Int32, pItem.IdAnuncio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pDescAnuncio", DbType.String, pItem.DescAnuncio);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pIdTipoAnuncio", DbType.Int32, pItem.IdTipoAnuncio);
            db.AddInParameter(dbCommand, "pTitulo", DbType.String, pItem.Titulo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(AnuncioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Anuncio_Actualiza");

            db.AddInParameter(dbCommand, "pIdAnuncio", DbType.Int32, pItem.IdAnuncio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pDescAnuncio", DbType.String, pItem.DescAnuncio);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pIdTipoAnuncio", DbType.Int32, pItem.IdTipoAnuncio);
            db.AddInParameter(dbCommand, "pTitulo", DbType.String, pItem.Titulo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(AnuncioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Anuncio_Elimina");

            db.AddInParameter(dbCommand, "pIdAnuncio", DbType.Int32, pItem.IdAnuncio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<AnuncioBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Anuncio_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AnuncioBE> Anunciolist = new List<AnuncioBE>();
            AnuncioBE Anuncio;
            while (reader.Read())
            {
                Anuncio = new AnuncioBE();
                Anuncio.IdAnuncio = Int32.Parse(reader["idAnuncio"].ToString());
                Anuncio.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Anuncio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Anuncio.DescAnuncio = reader["descAnuncio"].ToString();
                Anuncio.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                Anuncio.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Anuncio.IdTipoAnuncio = Int32.Parse(reader["IdTipoAnuncio"].ToString());
                Anuncio.DescTipoAnuncio = reader["DescTipoAnuncio"].ToString();
                Anuncio.Titulo = reader["Titulo"].ToString();
                Anuncio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Anunciolist.Add(Anuncio);
            }
            reader.Close();
            reader.Dispose();
            return Anunciolist;
        }
        public List<AnuncioBE> ListaUltimoTipo(int IdTipoAnuncio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Anuncio_ListaUltimoTipo");
            db.AddInParameter(dbCommand, "pIdTipoAnuncio", DbType.Int32, IdTipoAnuncio);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AnuncioBE> Anunciolist = new List<AnuncioBE>();
            AnuncioBE Anuncio;
            while (reader.Read())
            {
                Anuncio = new AnuncioBE();
                Anuncio.IdAnuncio = Int32.Parse(reader["idAnuncio"].ToString());
                Anuncio.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Anuncio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Anuncio.DescAnuncio = reader["DescAnuncio"].ToString();
                Anuncio.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                Anuncio.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Anuncio.IdTipoAnuncio = Int32.Parse(reader["IdTipoAnuncio"].ToString());
                Anuncio.DescTipoAnuncio = reader["DescTipoAnuncio"].ToString();
                Anuncio.Titulo = reader["Titulo"].ToString();
                Anuncio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Anunciolist.Add(Anuncio);
            }
            reader.Close();
            reader.Dispose();
            return Anunciolist;
        }


        public AnuncioBE Selecciona(int IdAnuncio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Anuncio_Selecciona");
            db.AddInParameter(dbCommand, "pIdAnuncio", DbType.Int32, IdAnuncio);
            IDataReader reader = db.ExecuteReader(dbCommand);
           
            AnuncioBE Anuncio=null;
            while (reader.Read())
            {
                Anuncio = new AnuncioBE();
                Anuncio.IdAnuncio = Int32.Parse(reader["idAnuncio"].ToString());
                Anuncio.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Anuncio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Anuncio.DescAnuncio = reader["descAnuncio"].ToString();
                Anuncio.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                Anuncio.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Anuncio.IdTipoAnuncio = Int32.Parse(reader["IdTipoAnuncio"].ToString());
                Anuncio.DescTipoAnuncio = reader["DescTipoAnuncio"].ToString();
                Anuncio.Titulo = reader["Titulo"].ToString();
                Anuncio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                
            }
            reader.Close();
            reader.Dispose();
            return Anuncio;
        }

        public AnuncioBE SeleccionaUltimo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Anuncio_SeleccionaUltimoAnuncio");
            IDataReader reader = db.ExecuteReader(dbCommand);

            AnuncioBE Anuncio = null;
            while (reader.Read())
            {
                Anuncio = new AnuncioBE();
                Anuncio.IdAnuncio = Int32.Parse(reader["idAnuncio"].ToString());
                Anuncio.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Anuncio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Anuncio.DescAnuncio = reader["descAnuncio"].ToString();
                Anuncio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Anuncio;
        }
    }
}
