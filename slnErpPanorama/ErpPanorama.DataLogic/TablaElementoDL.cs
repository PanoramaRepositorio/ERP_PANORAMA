using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class TablaElementoDL
    {
        public TablaElementoDL() { }

        public void Inserta(TablaElementoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TablaElemento_Inserta");

            db.AddInParameter(dbCommand, "pIdTablaElemento", DbType.Int32, pItem.IdTablaElemento);
            db.AddInParameter(dbCommand, "pIdTabla", DbType.Int32, pItem.IdTabla);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pDescTablaElemento", DbType.String, pItem.DescTablaElemento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(TablaElementoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TablaElemento_Actualiza");

            db.AddInParameter(dbCommand, "pIdTablaElemento", DbType.Int32, pItem.IdTablaElemento);
            db.AddInParameter(dbCommand, "pIdTabla", DbType.Int32, pItem.IdTabla);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pDescTablaElemento", DbType.String, pItem.DescTablaElemento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(TablaElementoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TablaElemento_Elimina");

            db.AddInParameter(dbCommand, "pIdTablaElemento", DbType.Int32, pItem.IdTablaElemento);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<TablaElementoBE> ListaTodosActivo(int IdEmpresa, int IdTabla)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TablaElemento_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTabla", DbType.Int32, IdTabla);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TablaElementoBE> TablaElementolist = new List<TablaElementoBE>();
            TablaElementoBE TablaElemento;
            while (reader.Read())
            {
                TablaElemento = new TablaElementoBE();
                TablaElemento.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                TablaElemento.IdTablaElemento = Int32.Parse(reader["idTablaElemento"].ToString());
                TablaElemento.IdTabla = Int32.Parse(reader["idTabla"].ToString());
                TablaElemento.DescTabla = reader["descTabla"].ToString();
                TablaElemento.Abreviatura = reader["Abreviatura"].ToString();
                TablaElemento.DescTablaElemento = reader["descTablaElemento"].ToString();
                TablaElemento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TablaElementolist.Add(TablaElemento);
            }
            reader.Close();
            reader.Dispose();
            return TablaElementolist;
        }

        public List<TablaElementoBE> ListaTodosActivoSinEcommerce(int IdEmpresa, int IdTabla, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TablaElemento_ListaTodosActivoSinEcommerce");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTabla", DbType.Int32, IdTabla);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TablaElementoBE> TablaElementolist = new List<TablaElementoBE>();
            TablaElementoBE TablaElemento;
            while (reader.Read())
            {
                TablaElemento = new TablaElementoBE();
                TablaElemento.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                TablaElemento.IdTablaElemento = Int32.Parse(reader["idTablaElemento"].ToString());
                TablaElemento.IdTabla = Int32.Parse(reader["idTabla"].ToString());
                TablaElemento.DescTabla = reader["descTabla"].ToString();
                TablaElemento.Abreviatura = reader["Abreviatura"].ToString();
                TablaElemento.DescTablaElemento = reader["descTablaElemento"].ToString();
                TablaElemento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TablaElementolist.Add(TablaElemento);
            }
            reader.Close();
            reader.Dispose();
            return TablaElementolist;
        }


        public List<TablaElementoBE> ListaTodosActivoPorTabla(int IdEmpresa, int IdTabla)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TablaElemento_ListaTodosActivoPorTabla");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTabla", DbType.Int32, IdTabla);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TablaElementoBE> TablaElementolist = new List<TablaElementoBE>();
            TablaElementoBE TablaElemento;
            while (reader.Read())
            {
                TablaElemento = new TablaElementoBE();
                TablaElemento.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                TablaElemento.IdTablaElemento = Int32.Parse(reader["idTablaElemento"].ToString());
                TablaElemento.IdTabla = Int32.Parse(reader["idTabla"].ToString());
                TablaElemento.DescTabla = reader["descTabla"].ToString();
                TablaElemento.Abreviatura = reader["Abreviatura"].ToString();
                TablaElemento.DescTablaElemento = reader["descTablaElemento"].ToString();
                TablaElemento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TablaElementolist.Add(TablaElemento);
            }
            reader.Close();
            reader.Dispose();
            return TablaElementolist;
        }

        public List<TablaElementoBE> ListaTodosActivoPorTablaExterna(int IdEmpresa, int IdTabla, int IdTablaExterna)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TablaElemento_ListaTodosActivoPorTablaExterna");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTabla", DbType.Int32, IdTabla);
            db.AddInParameter(dbCommand, "pIdTablaExterna", DbType.Int32, IdTablaExterna);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TablaElementoBE> TablaElementolist = new List<TablaElementoBE>();
            TablaElementoBE TablaElemento;
            while (reader.Read())
            {
                TablaElemento = new TablaElementoBE();
                TablaElemento.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                TablaElemento.IdTablaElemento = Int32.Parse(reader["idTablaElemento"].ToString());
                TablaElemento.IdTabla = Int32.Parse(reader["idTabla"].ToString());
                TablaElemento.DescTabla = reader["descTabla"].ToString();
                TablaElemento.Abreviatura = reader["Abreviatura"].ToString();
                TablaElemento.DescTablaElemento = reader["descTablaElemento"].ToString();
                TablaElemento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TablaElementolist.Add(TablaElemento);
            }
            reader.Close();
            reader.Dispose();
            return TablaElementolist;
        }

        public List<TablaElementoBE> ListaAlmacenIngreso(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TablaElemento_ListaAlmacenIngreso");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
           
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TablaElementoBE> TablaElementolist = new List<TablaElementoBE>();
            TablaElementoBE TablaElemento;
            while (reader.Read())
            {
                TablaElemento = new TablaElementoBE();
                TablaElemento.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                TablaElemento.IdTablaElemento = Int32.Parse(reader["idTablaElemento"].ToString());
                TablaElemento.IdTabla = Int32.Parse(reader["idTabla"].ToString());
                TablaElemento.DescTabla = reader["descTabla"].ToString();
                TablaElemento.Abreviatura = reader["Abreviatura"].ToString();
                TablaElemento.DescTablaElemento = reader["descTablaElemento"].ToString();
                TablaElemento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TablaElementolist.Add(TablaElemento);
            }
            reader.Close();
            reader.Dispose();
            return TablaElementolist;
        }

        public List<TablaElementoBE> ListaAlmacenSalida(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TablaElemento_ListaAlmacenSalida");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TablaElementoBE> TablaElementolist = new List<TablaElementoBE>();
            TablaElementoBE TablaElemento;
            while (reader.Read())
            {
                TablaElemento = new TablaElementoBE();
                TablaElemento.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                TablaElemento.IdTablaElemento = Int32.Parse(reader["idTablaElemento"].ToString());
                TablaElemento.IdTabla = Int32.Parse(reader["idTabla"].ToString());
                TablaElemento.DescTabla = reader["descTabla"].ToString();
                TablaElemento.Abreviatura = reader["Abreviatura"].ToString();
                TablaElemento.DescTablaElemento = reader["descTablaElemento"].ToString();
                TablaElemento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TablaElementolist.Add(TablaElemento);
            }
            reader.Close();
            reader.Dispose();
            return TablaElementolist;
        }
    }
}
