using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class EstudioRealizadoDL
    {
        public EstudioRealizadoDL() { }

        public void Inserta(EstudioRealizadoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstudioRealizado_Inserta");

            db.AddInParameter(dbCommand, "pIdEstudioRealizado", DbType.Int32, pItem.IdEstudioRealizado);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdNivelEstudio", DbType.Int32, pItem.IdNivelEstudio);
            db.AddInParameter(dbCommand, "pCentroEstudio", DbType.String, pItem.CentroEstudio);
            db.AddInParameter(dbCommand, "pGradoObtenido", DbType.String, pItem.GradoObtenido);
            db.AddInParameter(dbCommand, "pMesAnioIncio", DbType.String, pItem.MesAnioIncio);
            db.AddInParameter(dbCommand, "pMesAnioFin", DbType.String, pItem.MesAnioFin);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(EstudioRealizadoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstudioRealizado_Actualiza");

            db.AddInParameter(dbCommand, "pIdEstudioRealizado", DbType.Int32, pItem.IdEstudioRealizado);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdNivelEstudio", DbType.Int32, pItem.IdNivelEstudio);
            db.AddInParameter(dbCommand, "pCentroEstudio", DbType.String, pItem.CentroEstudio);
            db.AddInParameter(dbCommand, "pGradoObtenido", DbType.String, pItem.GradoObtenido);
            db.AddInParameter(dbCommand, "pMesAnioIncio", DbType.String, pItem.MesAnioIncio);
            db.AddInParameter(dbCommand, "pMesAnioFin", DbType.String, pItem.MesAnioFin);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(EstudioRealizadoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstudioRealizado_Elimina");

            db.AddInParameter(dbCommand, "pIdEstudioRealizado", DbType.Int32, pItem.IdEstudioRealizado);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<EstudioRealizadoBE> ListaTodosActivo(int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstudioRealizado_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EstudioRealizadoBE> EstudioRealizadolist = new List<EstudioRealizadoBE>();
            EstudioRealizadoBE EstudioRealizado;
            while (reader.Read())
            {
                EstudioRealizado = new EstudioRealizadoBE();
                EstudioRealizado.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                EstudioRealizado.IdEstudioRealizado = Int32.Parse(reader["idEstudioRealizado"].ToString());
                EstudioRealizado.IdNivelEstudio = Int32.Parse(reader["IdNivelEstudio"].ToString());
                EstudioRealizado.DescNivelEstudio = reader["DescNivelEstudio"].ToString();
                EstudioRealizado.CentroEstudio = reader["CentroEstudio"].ToString();
                EstudioRealizado.GradoObtenido = reader["GradoObtenido"].ToString();
                EstudioRealizado.MesAnioIncio = reader["MesAnioIncio"].ToString();
                EstudioRealizado.MesAnioFin = reader["MesAnioFin"].ToString();
                EstudioRealizado.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                EstudioRealizado.TipoOper = 4; //Consultar
                EstudioRealizadolist.Add(EstudioRealizado);
            }
            reader.Close();
            reader.Dispose();
            return EstudioRealizadolist;
        }

        public EstudioRealizadoBE Selecciona(int IdPersona, int IdEstudioRealizado)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstudioRealizado_Selecciona");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pIdEstudioRealizado", DbType.Int32, IdEstudioRealizado);
           
            IDataReader reader = db.ExecuteReader(dbCommand);
            EstudioRealizadoBE EstudioRealizado = null;
            while (reader.Read())
            {
                EstudioRealizado = new EstudioRealizadoBE();
                EstudioRealizado.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                EstudioRealizado.IdEstudioRealizado = Int32.Parse(reader["idEstudioRealizado"].ToString());
                EstudioRealizado.IdNivelEstudio = Int32.Parse(reader["IdNivelEstudio"].ToString());
                EstudioRealizado.DescNivelEstudio = reader["DescNivelEstudio"].ToString();
                EstudioRealizado.CentroEstudio = reader["CentroEstudio"].ToString();
                EstudioRealizado.GradoObtenido = reader["GradoObtenido"].ToString();
                EstudioRealizado.MesAnioIncio = reader["MesAnioIncio"].ToString();
                EstudioRealizado.MesAnioFin = reader["MesAnioFin"].ToString();
                EstudioRealizado.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                EstudioRealizado.TipoOper = 4; //Consultar
                
            }
            reader.Close();
            reader.Dispose();
            return EstudioRealizado;
        }
    }
}
