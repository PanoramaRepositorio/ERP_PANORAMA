using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class RutaDL
    {
        public RutaDL() { }

        public void Inserta(RutaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ruta_Inserta");

            db.AddInParameter(dbCommand, "pIdRuta", DbType.Int32, pItem.IdRuta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pDescRuta", DbType.String, pItem.DescRuta);
            db.AddInParameter(dbCommand, "pTipo", DbType.String, pItem.Tipo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(RutaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ruta_Actualiza");

            db.AddInParameter(dbCommand, "pIdRuta", DbType.Int32, pItem.IdRuta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pDescRuta", DbType.String, pItem.DescRuta);
            db.AddInParameter(dbCommand, "pTipo", DbType.String, pItem.Tipo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(RutaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ruta_Elimina");

            db.AddInParameter(dbCommand, "pIdRuta", DbType.Int32, pItem.IdRuta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<RutaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ruta_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<RutaBE> Rutalist = new List<RutaBE>();
            RutaBE Ruta;
            while (reader.Read())
            {
                Ruta = new RutaBE();
                Ruta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Ruta.IdRuta = Int32.Parse(reader["IdRuta"].ToString());
                Ruta.DescRuta = reader["DescRuta"].ToString();
                Ruta.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                Ruta.DescVendedor = reader["DescVendedor"].ToString();
                Ruta.Tipo = reader["Tipo"].ToString();
                Ruta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Rutalist.Add(Ruta);
            }
            reader.Close();
            reader.Dispose();
            return Rutalist;
        }

        public RutaBE Selecciona(int IdEmpresa, int IdRuta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ruta_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdRuta", DbType.Int32, IdRuta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            RutaBE Ruta=null;
            while (reader.Read())
            {
                Ruta = new RutaBE();
                Ruta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Ruta.IdRuta = Int32.Parse(reader["IdRuta"].ToString());
                Ruta.DescRuta = reader["DescRuta"].ToString();
                Ruta.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                Ruta.DescVendedor = reader["DescVendedor"].ToString();
                Ruta.Tipo = reader["Tipo"].ToString();
                Ruta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Ruta;
        }
    }
}
