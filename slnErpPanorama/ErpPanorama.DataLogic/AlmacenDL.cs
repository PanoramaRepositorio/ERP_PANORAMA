using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;


namespace ErpPanorama.DataLogic
{
    public class AlmacenDL
    {
        public AlmacenDL() { }

        public void Inserta(AlmacenBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Almacen_Inserta");
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pDescAlmacen", DbType.String, pItem.DescAlmacen);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(AlmacenBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Almacen_Actualiza");

            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pDescAlmacen", DbType.String, pItem.DescAlmacen);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(AlmacenBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Almacen_Elimina");

            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<AlmacenBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Almacen_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AlmacenBE> Almacenlist = new List<AlmacenBE>();
            AlmacenBE Almacen;
            while (reader.Read())
            {
                Almacen = new AlmacenBE();
                Almacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Almacen.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Almacen.DescTienda = reader["DescTienda"].ToString();
                Almacen.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Almacen.DescAlmacen = reader["descAlmacen"].ToString();
                Almacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Almacenlist.Add(Almacen);
            }
            reader.Close();
            reader.Dispose();
            return Almacenlist;
        }


        public List<AlmacenBE> ListaTodosActivoPerfil(int IdEmpresa, int IdTienda, int IdPerfil)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Almacen_ListaTodosActivoPerfil");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdPerfil", DbType.Int32, IdPerfil);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AlmacenBE> Almacenlist = new List<AlmacenBE>();
            AlmacenBE Almacen;
            while (reader.Read())
            {
                Almacen = new AlmacenBE();
                Almacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Almacen.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Almacen.DescTienda = reader["DescTienda"].ToString();
                Almacen.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Almacen.DescAlmacen = reader["descAlmacen"].ToString();
                Almacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Almacenlist.Add(Almacen);
            }
            reader.Close();
            reader.Dispose();
            return Almacenlist;
        }


        public List<AlmacenBE> ListaTodosActivoPrincipal(int IdEmpresa, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Almacen_ListaTodosActivoPrincipal2");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AlmacenBE> Almacenlist = new List<AlmacenBE>();
            AlmacenBE Almacen;
            while (reader.Read())
            {
                Almacen = new AlmacenBE();
                Almacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Almacen.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Almacen.DescTienda = reader["DescTienda"].ToString();
                Almacen.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Almacen.DescAlmacen = reader["descAlmacen"].ToString();
                Almacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Almacenlist.Add(Almacen);
            }
            reader.Close();
            reader.Dispose();
            return Almacenlist;
        }

        public List<AlmacenBE> ListaTodosActivoPrincipalMar(int IdEmpresa, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Almacen_ListaTodosActivoPrincipalMar");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AlmacenBE> Almacenlist = new List<AlmacenBE>();
            AlmacenBE Almacen;
            while (reader.Read())
            {
                Almacen = new AlmacenBE();
                Almacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Almacen.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Almacen.DescTienda = reader["DescTienda"].ToString();
                Almacen.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Almacen.DescAlmacen = reader["descAlmacen"].ToString();
                Almacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Almacenlist.Add(Almacen);
            }
            reader.Close();
            reader.Dispose();
            return Almacenlist;
        }
        public List<AlmacenBE> ListaAlmacenesTodosActivos(int IdEmpresa, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Almacen_ListaTodosActivoPrincipal");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AlmacenBE> Almacenlist = new List<AlmacenBE>();
            AlmacenBE Almacen;
            while (reader.Read())
            {
                Almacen = new AlmacenBE();
                Almacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Almacen.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Almacen.DescTienda = reader["DescTienda"].ToString();
                Almacen.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Almacen.DescAlmacen = reader["descAlmacen"].ToString();
                Almacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Almacenlist.Add(Almacen);
            }
            reader.Close();
            reader.Dispose();
            return Almacenlist;
        }

        public AlmacenBE Selecciona(int IdAlmacen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Almacen_Selecciona");
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AlmacenBE Almacen = null;
            while (reader.Read())
            {
                Almacen = new AlmacenBE();
                Almacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Almacen.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Almacen.DescTienda = reader["DescTienda"].ToString();
                Almacen.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Almacen.DescAlmacen = reader["descAlmacen"].ToString();
                Almacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Almacen;
        }

    }
}
