using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class DerechoHabienteDL
    {
        public DerechoHabienteDL() { }

        public void Inserta(DerechoHabienteBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DerechoHabiente_Inserta");

            db.AddInParameter(dbCommand, "pIdDerechoHabiente", DbType.Int32, pItem.IdDerechoHabiente);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdSexo", DbType.Int32, pItem.IdSexo);
            db.AddInParameter(dbCommand, "pIdParentesco", DbType.Int32, pItem.IdParentesco);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pApeNom", DbType.String, pItem.ApeNom);
            db.AddInParameter(dbCommand, "pFechaNac", DbType.DateTime, pItem.FechaNac);
            db.AddInParameter(dbCommand, "pOcupacion", DbType.String, pItem.Ocupacion);
            db.AddInParameter(dbCommand, "pFlagEps", DbType.Boolean, pItem.FlagEps);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(DerechoHabienteBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DerechoHabiente_Actualiza");

            db.AddInParameter(dbCommand, "pIdDerechoHabiente", DbType.Int32, pItem.IdDerechoHabiente);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdSexo", DbType.Int32, pItem.IdSexo);
            db.AddInParameter(dbCommand, "pIdParentesco", DbType.Int32, pItem.IdParentesco);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pApeNom", DbType.String, pItem.ApeNom);
            db.AddInParameter(dbCommand, "pFechaNac", DbType.DateTime, pItem.FechaNac);
            db.AddInParameter(dbCommand, "pOcupacion", DbType.String, pItem.Ocupacion);
            db.AddInParameter(dbCommand, "pFlagEps", DbType.Boolean, pItem.FlagEps);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(DerechoHabienteBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DerechoHabiente_Elimina");

            db.AddInParameter(dbCommand, "pIdDerechoHabiente", DbType.Int32, pItem.IdDerechoHabiente);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<DerechoHabienteBE> ListaTodosActivo(int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DerechoHabiente_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DerechoHabienteBE> DerechoHabientelist = new List<DerechoHabienteBE>();
            DerechoHabienteBE DerechoHabiente;
            while (reader.Read())
            {
                DerechoHabiente = new DerechoHabienteBE();
                DerechoHabiente.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                DerechoHabiente.IdDerechoHabiente = Int32.Parse(reader["idDerechoHabiente"].ToString());
                DerechoHabiente.IdSexo = Int32.Parse(reader["IdSexo"].ToString());
                DerechoHabiente.DescSexo = reader["DescSexo"].ToString();
                DerechoHabiente.IdParentesco = Int32.Parse(reader["IdParentesco"].ToString());
                DerechoHabiente.DescParentesco = reader["DescParentesco"].ToString();
                DerechoHabiente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DerechoHabiente.ApeNom = reader["ApeNom"].ToString();
                DerechoHabiente.FechaNac = DateTime.Parse(reader["FechaNac"].ToString());
                DerechoHabiente.Ocupacion = reader["Ocupacion"].ToString();
                DerechoHabiente.FlagEps = Boolean.Parse(reader["FlagEps"].ToString());
                DerechoHabiente.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                DerechoHabiente.TipoOper = 4; //Consultar
                DerechoHabientelist.Add(DerechoHabiente);
            }
            reader.Close();
            reader.Dispose();
            return DerechoHabientelist;
        }

        public DerechoHabienteBE Selecciona(int IdPersona, int IdDerechoHabiente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DerechoHabiente_Selecciona");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pIdDerechoHabiente", DbType.Int32, IdDerechoHabiente);
           
            IDataReader reader = db.ExecuteReader(dbCommand);
            DerechoHabienteBE DerechoHabiente = null;
            while (reader.Read())
            {
                DerechoHabiente = new DerechoHabienteBE();
                DerechoHabiente.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                DerechoHabiente.IdDerechoHabiente = Int32.Parse(reader["idDerechoHabiente"].ToString());
                DerechoHabiente.IdSexo = Int32.Parse(reader["IdSexo"].ToString());
                DerechoHabiente.DescSexo = reader["DescSexo"].ToString();
                DerechoHabiente.IdParentesco = Int32.Parse(reader["IdParentesco"].ToString());
                DerechoHabiente.DescParentesco = reader["DescParentesco"].ToString();
                DerechoHabiente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DerechoHabiente.ApeNom = reader["ApeNom"].ToString();
                DerechoHabiente.FechaNac = DateTime.Parse(reader["FechaNac"].ToString());
                DerechoHabiente.Ocupacion = reader["Ocupacion"].ToString();
                DerechoHabiente.FlagEps = Boolean.Parse(reader["FlagEps"].ToString());
                DerechoHabiente.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                DerechoHabiente.TipoOper = 4; //Consultar
                
            }
            reader.Close();
            reader.Dispose();
            return DerechoHabiente;
        }
    }
}
