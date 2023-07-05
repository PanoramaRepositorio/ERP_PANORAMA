using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ListaPrecioDL
    {
        public ListaPrecioDL() { }

        public Int32 Inserta(ListaPrecioBE pItem)
        {
            Int32 IdListaPrecio = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecio_Inserta");

            db.AddOutParameter(dbCommand, "pIdListaPrecio", DbType.Int32, pItem.IdListaPrecio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pDescListaPrecio", DbType.String, pItem.DescListaPrecio);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
           
            db.ExecuteNonQuery(dbCommand);

            IdListaPrecio = (int)db.GetParameterValue(dbCommand, "pIdListaPrecio");

            return IdListaPrecio;
        }

        public void Actualiza(ListaPrecioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecio_Actualiza");

            db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, pItem.IdListaPrecio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pDescListaPrecio", DbType.String, pItem.DescListaPrecio);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ListaPrecioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecio_Elimina");

            db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, pItem.IdListaPrecio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ListaPrecioBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecio_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ListaPrecioBE> ListaPreciolist = new List<ListaPrecioBE>();
            ListaPrecioBE ListaPrecio;
            while (reader.Read())
            {
                ListaPrecio = new ListaPrecioBE();
                ListaPrecio.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ListaPrecio.RazonSocial = reader["RazonSocial"].ToString();
                ListaPrecio.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                ListaPrecio.DescTienda = reader["DescTienda"].ToString();
                ListaPrecio.IdListaPrecio = Int32.Parse(reader["idListaPrecio"].ToString());
                ListaPrecio.DescListaPrecio = reader["descListaPrecio"].ToString();
                ListaPrecio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ListaPreciolist.Add(ListaPrecio);
            }
            reader.Close();
            reader.Dispose();
            return ListaPreciolist;
        }
    }
}
