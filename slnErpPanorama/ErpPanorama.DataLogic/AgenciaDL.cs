using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class AgenciaDL
    {
       public AgenciaDL() { }

        public void Inserta(AgenciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Agencia_Inserta");

            db.AddInParameter(dbCommand, "pIdAgencia", DbType.Int32, pItem.IdAgencia);
            db.AddInParameter(dbCommand, "pRuc", DbType.String, pItem.Ruc);
            db.AddInParameter(dbCommand, "pDescAgencia", DbType.String, pItem.DescAgencia);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
            db.AddInParameter(dbCommand, "pReferencia", DbType.String, pItem.Referencia);
            db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pContacto", DbType.String, pItem.Contacto);
            db.AddInParameter(dbCommand, "pPaginaWeb", DbType.String, pItem.PaginaWeb);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(AgenciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Agencia_Actualiza");

            db.AddInParameter(dbCommand, "pIdAgencia", DbType.Int32, pItem.IdAgencia);
            db.AddInParameter(dbCommand, "pRuc", DbType.String, pItem.Ruc);
            db.AddInParameter(dbCommand, "pDescAgencia", DbType.String, pItem.DescAgencia);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
            db.AddInParameter(dbCommand, "pReferencia", DbType.String, pItem.Referencia);
            db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pContacto", DbType.String, pItem.Contacto);
            db.AddInParameter(dbCommand, "pPaginaWeb", DbType.String, pItem.PaginaWeb);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(AgenciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Agencia_Elimina");

            db.AddInParameter(dbCommand, "pIdAgencia", DbType.Int32, pItem.IdAgencia);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<AgenciaBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Agencia_ListaTodosActivo");
            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            //db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AgenciaBE> Agencialist = new List<AgenciaBE>();
            AgenciaBE Agencia;
            while (reader.Read())
            {
                Agencia = new AgenciaBE();
                Agencia.IdAgencia = Int32.Parse(reader["IdAgencia"].ToString());
                Agencia.Ruc = reader["Ruc"].ToString();
                Agencia.DescAgencia = reader["DescAgencia"].ToString();
                Agencia.Direccion = reader["Direccion"].ToString();
                Agencia.IdUbigeo = reader["IdUbigeo"].ToString();
                Agencia.NomDpto = reader["NomDpto"].ToString();
                Agencia.NomProv = reader["NomProv"].ToString();
                Agencia.NomDist = reader["NomDist"].ToString();
                Agencia.Referencia = reader["Referencia"].ToString();
                Agencia.Telefono = reader["Telefono"].ToString();
                Agencia.Email = reader["Email"].ToString();
                Agencia.Contacto = reader["Contacto"].ToString();
                Agencia.PaginaWeb = reader["PaginaWeb"].ToString();
                Agencia.Observacion = reader["Observacion"].ToString();
                Agencia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Agencialist.Add(Agencia);
            }
            reader.Close();
            reader.Dispose();
            return Agencialist;
        }

        public AgenciaBE Selecciona(int IdAgencia)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Agencia_Selecciona");
            db.AddInParameter(dbCommand, "pIdAgencia", DbType.Int32, IdAgencia);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AgenciaBE Agencia = null;
            while (reader.Read())
            {
                Agencia = new AgenciaBE();
                Agencia.IdAgencia = Int32.Parse(reader["IdAgencia"].ToString());
                Agencia.Ruc = reader["Ruc"].ToString();
                Agencia.DescAgencia = reader["DescAgencia"].ToString();
                Agencia.Direccion = reader["Direccion"].ToString();
                Agencia.IdUbigeo = reader["IdUbigeo"].ToString();
                Agencia.NomDpto = reader["NomDpto"].ToString();
                Agencia.NomProv = reader["NomProv"].ToString();
                Agencia.NomDist = reader["NomDist"].ToString();
                Agencia.Referencia = reader["Referencia"].ToString();
                Agencia.Telefono = reader["Telefono"].ToString();
                Agencia.Email = reader["Email"].ToString();
                Agencia.Contacto = reader["Contacto"].ToString();
                Agencia.PaginaWeb = reader["PaginaWeb"].ToString();
                Agencia.Observacion = reader["Observacion"].ToString();
                Agencia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Agencia;
        }
    }
}
