using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ListaPrecioDeliveryDL
    {
        public ListaPrecioDeliveryDL() { }

        public void Inserta(ListaPrecioDeliveryBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDelivery_Inserta");

            db.AddInParameter(dbCommand, "pIdListaPrecioDelivery", DbType.Int32, pItem.IdListaPrecioDelivery);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
            db.AddInParameter(dbCommand, "pIdDepartamento", DbType.String, pItem.IdDepartamento);
            db.AddInParameter(dbCommand, "pIdProvincia", DbType.String, pItem.IdProvincia);
            db.AddInParameter(dbCommand, "pIdDistrito", DbType.String, pItem.IdDistrito);
            db.AddInParameter(dbCommand, "pDescUbigeo", DbType.String, pItem.DescUbigeo);

            db.AddInParameter(dbCommand, "pTarifaEnvio", DbType.Decimal, pItem.TarifaEnvio);
            db.AddInParameter(dbCommand, "pTarifaEnvioA", DbType.Decimal, pItem.TarifaEnvioA);
            db.AddInParameter(dbCommand, "pTarifaEnvioP", DbType.Decimal, pItem.TarifaEnvioP);

            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ListaPrecioDeliveryBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDelivery_Actualiza");

            db.AddInParameter(dbCommand, "pIdListaPrecioDelivery", DbType.Int32, pItem.IdListaPrecioDelivery);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
            db.AddInParameter(dbCommand, "pIdDepartamento", DbType.String, pItem.IdDepartamento);
            db.AddInParameter(dbCommand, "pIdProvincia", DbType.String, pItem.IdProvincia);
            db.AddInParameter(dbCommand, "pIdDistrito", DbType.String, pItem.IdDistrito);
            db.AddInParameter(dbCommand, "pDescUbigeo", DbType.String, pItem.DescUbigeo);

            db.AddInParameter(dbCommand, "pTarifaEnvio", DbType.Decimal, pItem.TarifaEnvio);
            db.AddInParameter(dbCommand, "pTarifaEnvioA", DbType.Decimal, pItem.TarifaEnvioA);
            db.AddInParameter(dbCommand, "pTarifaEnvioP", DbType.Decimal, pItem.TarifaEnvioP);

            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ListaPrecioDeliveryBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDelivery_Elimina");

            db.AddInParameter(dbCommand, "pIdListaPrecioDelivery", DbType.Int32, pItem.IdListaPrecioDelivery);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ListaPrecioDeliveryBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDelivery_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ListaPrecioDeliveryBE> ListaPrecioDeliverylist = new List<ListaPrecioDeliveryBE>();
            ListaPrecioDeliveryBE ListaPrecioDelivery;
            while (reader.Read())
            {
                ListaPrecioDelivery = new ListaPrecioDeliveryBE();
                ListaPrecioDelivery.IdListaPrecioDelivery = Int32.Parse(reader["idListaPrecioDelivery"].ToString());
                ListaPrecioDelivery.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ListaPrecioDelivery.IdUbigeo = reader["IdUbigeo"].ToString();
                ListaPrecioDelivery.IdDepartamento = reader["IdDepartamento"].ToString();
                ListaPrecioDelivery.IdProvincia = reader["IdProvincia"].ToString();
                ListaPrecioDelivery.IdDistrito = reader["IdDistrito"].ToString();
                ListaPrecioDelivery.DescUbigeo = reader["DescUbigeo"].ToString();
                ListaPrecioDelivery.TarifaEnvio = Decimal.Parse(reader["TarifaEnvio"].ToString());
                ListaPrecioDelivery.TarifaEnvioA = Decimal.Parse(reader["TarifaEnvioA"].ToString());
                ListaPrecioDelivery.TarifaEnvioP = Decimal.Parse(reader["TarifaEnvioP"].ToString());
                ListaPrecioDelivery.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ListaPrecioDeliverylist.Add(ListaPrecioDelivery);
            }
            reader.Close();
            reader.Dispose();
            return ListaPrecioDeliverylist;
        }

        public List<ListaPrecioDeliveryBE> ListaDistrito(string IdDepartamento, string IdProvincia)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDelivery_SeleccionaDistritos");
            db.AddInParameter(dbCommand, "pIdDepartamento", DbType.String, IdDepartamento);
            db.AddInParameter(dbCommand, "pIdProvincia", DbType.String, IdProvincia);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ListaPrecioDeliveryBE> ListaPrecioDeliverylist = new List<ListaPrecioDeliveryBE>();
            ListaPrecioDeliveryBE ListaPrecioDelivery;
            while (reader.Read())
            {
                ListaPrecioDelivery = new ListaPrecioDeliveryBE();
                ListaPrecioDelivery.IdListaPrecioDelivery = Int32.Parse(reader["IdListaPrecioDelivery"].ToString());
                ListaPrecioDelivery.IdDistrito = reader["IdDistrito"].ToString();
                ListaPrecioDelivery.NomDist = reader["NomDist"].ToString();
                ListaPrecioDeliverylist.Add(ListaPrecioDelivery);
            }
            reader.Close();
            reader.Dispose();
            return ListaPrecioDeliverylist;
        }

        public ListaPrecioDeliveryBE Selecciona(int IdListaPrecioDelivery, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDelivery_Selecciona");
            db.AddInParameter(dbCommand, "pIdListaPrecioDelivery", DbType.Int32, IdListaPrecioDelivery);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            IDataReader reader = db.ExecuteReader(dbCommand);
           
            ListaPrecioDeliveryBE ListaPrecioDelivery=null;
            while (reader.Read())
            {
                ListaPrecioDelivery = new ListaPrecioDeliveryBE();
                ListaPrecioDelivery.IdListaPrecioDelivery = Int32.Parse(reader["idListaPrecioDelivery"].ToString());
                ListaPrecioDelivery.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ListaPrecioDelivery.IdUbigeo = reader["IdUbigeo"].ToString();
                ListaPrecioDelivery.IdDepartamento = reader["IdDepartamento"].ToString();
                ListaPrecioDelivery.IdProvincia = reader["IdProvincia"].ToString();
                ListaPrecioDelivery.IdDistrito = reader["IdDistrito"].ToString();
                ListaPrecioDelivery.DescUbigeo = reader["DescUbigeo"].ToString();
                ListaPrecioDelivery.TarifaEnvio = Decimal.Parse(reader["TarifaEnvio"].ToString());
                ListaPrecioDelivery.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ListaPrecioDelivery;
        }

    }
}
