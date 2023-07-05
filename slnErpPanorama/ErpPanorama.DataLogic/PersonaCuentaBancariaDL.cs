using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class PersonaCuentaBancariaDL
    {
        public PersonaCuentaBancariaDL() { }

        public void Inserta(PersonaCuentaBancariaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaCuentaBancaria_Inserta");

            db.AddOutParameter(dbCommand, "pIdPersonaCuentaBancaria", DbType.Int32, pItem.IdPersonaCuentaBancaria);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pNumeroCuenta", DbType.String, pItem.NumeroCuenta);
            db.AddInParameter(dbCommand, "pIdTipoCuenta", DbType.Int32, pItem.IdTipoCuenta);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(PersonaCuentaBancariaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaCuentaBancaria_Actualiza");

            db.AddInParameter(dbCommand, "pIdPersonaCuentaBancaria", DbType.Int32, pItem.IdPersonaCuentaBancaria);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pNumeroCuenta", DbType.String, pItem.NumeroCuenta);
            db.AddInParameter(dbCommand, "pIdTipoCuenta", DbType.Int32, pItem.IdTipoCuenta);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(PersonaCuentaBancariaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaCuentaBancaria_Elimina");

            db.AddInParameter(dbCommand, "pIdPersonaCuentaBancaria", DbType.Int32, pItem.IdPersonaCuentaBancaria);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<PersonaCuentaBancariaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaCuentaBancaria_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaCuentaBancariaBE> PersonaCuentaBancarialist = new List<PersonaCuentaBancariaBE>();
            PersonaCuentaBancariaBE PersonaCuentaBancaria;
            while (reader.Read())
            {
                PersonaCuentaBancaria = new PersonaCuentaBancariaBE();
                PersonaCuentaBancaria.IdPersonaCuentaBancaria = Int32.Parse(reader["IdPersonaCuentaBancaria"].ToString());
                PersonaCuentaBancaria.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                PersonaCuentaBancaria.ApeNom = reader["ApeNom"].ToString();
                PersonaCuentaBancaria.IdBanco = Int32.Parse(reader["IdBanco"].ToString());
                PersonaCuentaBancaria.DescBanco = reader["DescBanco"].ToString();
                PersonaCuentaBancaria.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                PersonaCuentaBancaria.DescMoneda = reader["DescMoneda"].ToString();
                PersonaCuentaBancaria.NumeroCuenta = reader["NumeroCuenta"].ToString();
                PersonaCuentaBancaria.IdTipoCuenta = Int32.Parse(reader["IdTipoCuenta"].ToString());
                PersonaCuentaBancaria.DescTipoCuenta = reader["DescTipoCuenta"].ToString();
                PersonaCuentaBancaria.Observacion = reader["Observacion"].ToString();
                PersonaCuentaBancaria.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PersonaCuentaBancarialist.Add(PersonaCuentaBancaria);
            }
            reader.Close();
            reader.Dispose();
            return PersonaCuentaBancarialist;
        }

        public List<PersonaCuentaBancariaBE> ListaTodosPersona(int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaCuentaBancaria_ListaTodosPersona");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaCuentaBancariaBE> PersonaCuentaBancarialist = new List<PersonaCuentaBancariaBE>();
            PersonaCuentaBancariaBE PersonaCuentaBancaria;
            while (reader.Read())
            {
                PersonaCuentaBancaria = new PersonaCuentaBancariaBE();
                PersonaCuentaBancaria.IdPersonaCuentaBancaria = Int32.Parse(reader["IdPersonaCuentaBancaria"].ToString());
                PersonaCuentaBancaria.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                PersonaCuentaBancaria.ApeNom = reader["ApeNom"].ToString();
                PersonaCuentaBancaria.IdBanco = Int32.Parse(reader["IdBanco"].ToString());
                PersonaCuentaBancaria.DescBanco = reader["DescBanco"].ToString();
                PersonaCuentaBancaria.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                PersonaCuentaBancaria.DescMoneda = reader["DescMoneda"].ToString();
                PersonaCuentaBancaria.NumeroCuenta = reader["NumeroCuenta"].ToString();
                PersonaCuentaBancaria.IdTipoCuenta = Int32.Parse(reader["IdTipoCuenta"].ToString());
                PersonaCuentaBancaria.DescTipoCuenta = reader["DescTipoCuenta"].ToString();
                PersonaCuentaBancaria.Observacion = reader["Observacion"].ToString();
                PersonaCuentaBancaria.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PersonaCuentaBancarialist.Add(PersonaCuentaBancaria);
            }
            reader.Close();
            reader.Dispose();
            return PersonaCuentaBancarialist;
        }

        public PersonaCuentaBancariaBE Selecciona(int IdPersonaCuentaBancaria)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaCuentaBancaria_Selecciona");
            db.AddInParameter(dbCommand, "pIdPersonaCuentaBancaria", DbType.Int32, IdPersonaCuentaBancaria);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PersonaCuentaBancariaBE PersonaCuentaBancaria = null;
            while (reader.Read())
            {
                PersonaCuentaBancaria = new PersonaCuentaBancariaBE();
                PersonaCuentaBancaria.IdPersonaCuentaBancaria = Int32.Parse(reader["IdPersonaCuentaBancaria"].ToString());
                PersonaCuentaBancaria.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                PersonaCuentaBancaria.ApeNom = reader["ApeNom"].ToString();
                PersonaCuentaBancaria.IdBanco = Int32.Parse(reader["IdBanco"].ToString());
                PersonaCuentaBancaria.DescBanco = reader["DescBanco"].ToString();
                PersonaCuentaBancaria.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                PersonaCuentaBancaria.DescMoneda = reader["DescMoneda"].ToString();
                PersonaCuentaBancaria.NumeroCuenta = reader["NumeroCuenta"].ToString();
                PersonaCuentaBancaria.IdTipoCuenta = Int32.Parse(reader["IdTipoCuenta"].ToString());
                PersonaCuentaBancaria.DescTipoCuenta = reader["DescTipoCuenta"].ToString();
                PersonaCuentaBancaria.Observacion = reader["Observacion"].ToString();
                PersonaCuentaBancaria.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return PersonaCuentaBancaria;
        }

    }
}
