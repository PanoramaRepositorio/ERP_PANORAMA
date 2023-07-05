using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class AgenciaOficinaDL
    {
       public AgenciaOficinaDL() { }

        public void Inserta(AgenciaOficinaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AgenciaOficina_Inserta");

            db.AddInParameter(dbCommand, "pIdAgenciaOficina", DbType.Int32, pItem.IdAgenciaOficina);
            db.AddInParameter(dbCommand, "pIdAgencia", DbType.Int32, pItem.IdAgencia);
            db.AddInParameter(dbCommand, "pDescAgencia", DbType.String, pItem.DescAgencia);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
            db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(AgenciaOficinaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AgenciaOficina_Actualiza");

            db.AddInParameter(dbCommand, "pIdAgenciaOficina", DbType.Int32, pItem.IdAgenciaOficina);
            db.AddInParameter(dbCommand, "pIdAgencia", DbType.Int32, pItem.IdAgencia);
            db.AddInParameter(dbCommand, "pDescAgencia", DbType.String, pItem.DescAgencia);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
            db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(AgenciaOficinaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AgenciaOficina_Elimina");

            db.AddInParameter(dbCommand, "pIdAgenciaOficina", DbType.Int32, pItem.IdAgenciaOficina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<AgenciaOficinaBE> ListaTodosActivo(int IdAgencia)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AgenciaOficina_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdAgencia", DbType.Int32, IdAgencia);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AgenciaOficinaBE> AgenciaOficinalist = new List<AgenciaOficinaBE>();
            AgenciaOficinaBE AgenciaOficina;
            while (reader.Read())
            {
                AgenciaOficina = new AgenciaOficinaBE();
                AgenciaOficina.IdAgenciaOficina = Int32.Parse(reader["IdAgenciaOficina"].ToString());
                AgenciaOficina.IdAgencia = Int32.Parse(reader["IdAgencia"].ToString());
                AgenciaOficina.DescAgencia = reader["DescAgencia"].ToString();
                AgenciaOficina.Direccion = reader["Direccion"].ToString();
                AgenciaOficina.IdUbigeo = reader["IdUbigeo"].ToString();
                AgenciaOficina.NomDpto = reader["NomDpto"].ToString();
                AgenciaOficina.NomProv = reader["NomProv"].ToString();
                AgenciaOficina.NomDist = reader["NomDist"].ToString();
                AgenciaOficina.Telefono = reader["Telefono"].ToString();
                AgenciaOficina.Observacion = reader["Observacion"].ToString();
                AgenciaOficina.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                AgenciaOficinalist.Add(AgenciaOficina);
            }
            reader.Close();
            reader.Dispose();
            return AgenciaOficinalist;
        }

        public AgenciaOficinaBE Selecciona(int IdAgenciaOficina)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AgenciaOficina_Selecciona");
            db.AddInParameter(dbCommand, "pIdAgenciaOficina", DbType.Int32, IdAgenciaOficina);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AgenciaOficinaBE AgenciaOficina = null;
            while (reader.Read())
            {
                AgenciaOficina = new AgenciaOficinaBE();
                AgenciaOficina.IdAgenciaOficina = Int32.Parse(reader["IdAgenciaOficina"].ToString());
                AgenciaOficina.IdAgencia = Int32.Parse(reader["IdAgencia"].ToString());
                AgenciaOficina.DescAgencia = reader["DescAgencia"].ToString();
                AgenciaOficina.Direccion = reader["Direccion"].ToString();
                AgenciaOficina.IdUbigeo = reader["IdUbigeo"].ToString();
                AgenciaOficina.NomDpto = reader["NomDpto"].ToString();
                AgenciaOficina.NomProv = reader["NomProv"].ToString();
                AgenciaOficina.NomDist = reader["NomDist"].ToString();
                AgenciaOficina.Telefono = reader["Telefono"].ToString();
                AgenciaOficina.Observacion = reader["Observacion"].ToString();
                AgenciaOficina.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return AgenciaOficina;
        }
    }
}
