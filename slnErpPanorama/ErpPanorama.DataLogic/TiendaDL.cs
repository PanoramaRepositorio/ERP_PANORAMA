using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class TiendaDL
    {
        public TiendaDL() { }

        public void Inserta(TiendaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tienda_Inserta");

            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTienda", DbType.String, pItem.DescTienda);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(TiendaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tienda_Actualiza");

            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTienda", DbType.String, pItem.DescTienda);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(TiendaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tienda_Elimina");

            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<TiendaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tienda_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TiendaBE> Tiendalist = new List<TiendaBE>();
            TiendaBE Tienda;
            while (reader.Read())
            {
                Tienda = new TiendaBE();
                Tienda.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Tienda.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                Tienda.DescTienda = reader["descTienda"].ToString();
                Tienda.Direccion = reader["direccion"].ToString();
                Tienda.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Tiendalist.Add(Tienda);
            }
            reader.Close();
            reader.Dispose();
            return Tiendalist;
        }


        public List<TiendaBE> ListaTodosActivoKardex(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tienda_ListaTodosActivoKardex");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TiendaBE> Tiendalist = new List<TiendaBE>();
            TiendaBE Tienda;
            while (reader.Read())
            {
                Tienda = new TiendaBE();
                Tienda.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Tienda.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                Tienda.DescTienda = reader["descTienda"].ToString();
                Tienda.Direccion = reader["direccion"].ToString();
                Tienda.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Tiendalist.Add(Tienda);
            }
            reader.Close();
            reader.Dispose();
            return Tiendalist;
        }


        public List<TiendaBE> ListaTodosActivoAuditoria(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tienda_ListaTodosActivoAuditoria");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TiendaBE> Tiendalist = new List<TiendaBE>();
            TiendaBE Tienda;
            while (reader.Read())
            {
                Tienda = new TiendaBE();
                Tienda.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Tienda.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                Tienda.DescTienda = reader["descTienda"].ToString();
                Tienda.Direccion = reader["direccion"].ToString();
                Tienda.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Tiendalist.Add(Tienda);
            }
            reader.Close();
            reader.Dispose();
            return Tiendalist;
        }

        public List<TiendaBE> ListaTodosTiendasActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tienda_ListaTodosTiendasActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TiendaBE> Tiendalist = new List<TiendaBE>();
            TiendaBE Tienda;
            while (reader.Read())
            {
                Tienda = new TiendaBE();
                Tienda.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Tienda.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                Tienda.DescTienda = reader["descTienda"].ToString();
                Tienda.Direccion = reader["direccion"].ToString();
                Tienda.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Tiendalist.Add(Tienda);
            }
            reader.Close();
            reader.Dispose();
            return Tiendalist;
        }

        public List<TiendaBE> ListaTodosCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tienda_ListaTodosCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TiendaBE> Tiendalist = new List<TiendaBE>();
            TiendaBE Tienda;
            while (reader.Read())
            {
                Tienda = new TiendaBE();
                Tienda.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Tienda.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                Tienda.DescTienda = reader["descTienda"].ToString();
                Tienda.Direccion = reader["direccion"].ToString();
                Tienda.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Tiendalist.Add(Tienda);
            }
            reader.Close();
            reader.Dispose();
            return Tiendalist;
        }

        public TiendaBE Selecciona(int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tienda_Selecciona");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TiendaBE Tienda = null;
            while (reader.Read())
            {
                Tienda = new TiendaBE();
                Tienda.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Tienda.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                Tienda.DescTienda = reader["descTienda"].ToString();
                Tienda.Direccion = reader["direccion"].ToString();
                Tienda.IdUbigeo = reader["IdUbigeo"].ToString();
                Tienda.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Tienda;
        }
        public List<TiendaBE> ListaTodosTiendasActivo2(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tienda_ListaTodosTiendasActivo2");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TiendaBE> Tiendalist = new List<TiendaBE>();
            TiendaBE Tienda;
            while (reader.Read())
            {
                Tienda = new TiendaBE();
                Tienda.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Tienda.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                Tienda.DescTienda = reader["descTienda"].ToString();
                Tienda.Direccion = reader["direccion"].ToString();
                Tienda.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Tiendalist.Add(Tienda);
            }
            reader.Close();
            reader.Dispose();
            return Tiendalist;
        }

    }
}
