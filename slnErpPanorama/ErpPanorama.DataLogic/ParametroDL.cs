using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ParametroDL
    {
        public ParametroDL() { }

        public void Inserta(ParametroBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Parametro_Inserta");

            db.AddInParameter(dbCommand, "pIdParametro", DbType.String, pItem.IdParametro);
            db.AddInParameter(dbCommand, "pValor", DbType.String, pItem.Valor);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pFechaCreacion", DbType.DateTime, pItem.FechaCreacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ParametroBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Parametro_Actualiza");

            db.AddInParameter(dbCommand, "pIdParametro", DbType.String, pItem.IdParametro);
            db.AddInParameter(dbCommand, "pValor", DbType.String, pItem.Valor);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            //db.AddInParameter(dbCommand, "pFechaCreacion", DbType.DateTime, pItem.FechaCreacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaEstado(ParametroBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Parametro_ActualizaEstado");

            db.AddInParameter(dbCommand, "pIdParametro", DbType.String, pItem.IdParametro);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ParametroBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Parametro_Elimina");

            db.AddInParameter(dbCommand, "pIdParametro", DbType.String, pItem.IdParametro);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ParametroBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Parametro_ListaTodosActivo");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ParametroBE> Parametrolist = new List<ParametroBE>();
            ParametroBE Parametro;
            while (reader.Read())
            {
                Parametro = new ParametroBE();
                Parametro.IdParametro = reader["idParametro"].ToString();
                Parametro.Valor = reader["Valor"].ToString();
                Parametro.Numero = Decimal.Parse(reader["Numero"].ToString());
                Parametro.Descripcion = reader["Descripcion"].ToString();
                Parametro.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Parametrolist.Add(Parametro);
            }
            reader.Close();
            reader.Dispose();
            return Parametrolist;
        }

        public List<ParametroBE> ListaNumero()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Parametro_ListaNumero");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ParametroBE> Parametrolist = new List<ParametroBE>();
            ParametroBE Parametro;
            while (reader.Read())
            {
                Parametro = new ParametroBE();
                Parametro.IdParametro = reader["idParametro"].ToString();
                Parametro.Valor = reader["Valor"].ToString();
                Parametro.Numero = Decimal.Parse(reader["Numero"].ToString());
                Parametro.Descripcion = reader["Descripcion"].ToString();
                Parametro.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Parametrolist.Add(Parametro);
            }
            reader.Close();
            reader.Dispose();
            return Parametrolist;
        }

        public ParametroBE Selecciona(string IdParametro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Parametro_Selecciona");
            db.AddInParameter(dbCommand, "pIdParametro", DbType.String, IdParametro);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ParametroBE Parametro = null;
            while (reader.Read())
            {
                Parametro = new ParametroBE();
                Parametro.IdParametro = reader["IdParametro"].ToString();
                Parametro.Valor = reader["Valor"].ToString();
                Parametro.Numero = Decimal.Parse(reader["Numero"].ToString());
                Parametro.Descripcion = reader["Descripcion"].ToString();
                Parametro.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Parametro;
        }

        public ParametroBE SeleccionaServidor()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Parametro_Servidor");

            IDataReader reader = db.ExecuteReader(dbCommand);
            ParametroBE Parametro = null;
            while (reader.Read())
            {
                Parametro = new ParametroBE();
                Parametro.Fecha = DateTime.Parse(reader["Fecha"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Parametro;
        }

    }
}

