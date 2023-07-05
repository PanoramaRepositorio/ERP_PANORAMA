using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class CajaCajeroDL
    {
        public CajaCajeroDL() { }

        public void Inserta(CajaCajeroBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaCajero_Inserta");

            db.AddInParameter(dbCommand, "pIdCajaCajero", DbType.Int32, pItem.IdCajaCajero);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(CajaCajeroBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaCajero_Actualiza");

            db.AddInParameter(dbCommand, "pIdCajaCajero", DbType.Int32, pItem.IdCajaCajero);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(CajaCajeroBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaCajero_Elimina");

            db.AddInParameter(dbCommand, "pIdCajaCajero", DbType.Int32, pItem.IdCajaCajero);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<CajaCajeroBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int IdCaja)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaCajero_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaCajeroBE> CajaCajerolist = new List<CajaCajeroBE>();
            CajaCajeroBE CajaCajero;
            while (reader.Read())
            {
                CajaCajero = new CajaCajeroBE();
                CajaCajero.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CajaCajero.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                CajaCajero.DescTienda = reader["DescTienda"].ToString();
                CajaCajero.IdCajaCajero = Int32.Parse(reader["IdCajaCajero"].ToString());
                CajaCajero.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                CajaCajero.DescCaja = reader["DescCaja"].ToString();
                CajaCajero.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                CajaCajero.ApeNom = reader["ApeNom"].ToString();
                CajaCajero.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CajaCajerolist.Add(CajaCajero);
            }
            reader.Close();
            reader.Dispose();
            return CajaCajerolist;
        }
    }
}
