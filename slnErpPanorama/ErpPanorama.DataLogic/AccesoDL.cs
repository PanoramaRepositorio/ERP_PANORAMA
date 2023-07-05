using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class AccesoDL
    {
        public AccesoDL() { }

        public void Inserta(AccesoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Acceso_Inserta");

            db.AddInParameter(dbCommand, "pIdPerfil", DbType.Int32, pItem.IdPerfil);
            db.AddInParameter(dbCommand, "pIdMenu", DbType.Int32, pItem.IdMenu);
            db.AddInParameter(dbCommand, "pFlagLectura", DbType.Boolean, pItem.FlagLectura);
            db.AddInParameter(dbCommand, "pFlagAdicion", DbType.Boolean, pItem.FlagAdicion);
            db.AddInParameter(dbCommand, "pFlagActualizacion", DbType.Boolean, pItem.FlagActualizacion);
            db.AddInParameter(dbCommand, "pFlagEliminacion", DbType.Boolean, pItem.FlagEliminacion);
            db.AddInParameter(dbCommand, "pFlagImpresion", DbType.Boolean, pItem.FlagImpresion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(AccesoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Acceso_Actualiza");

            db.AddInParameter(dbCommand, "pIdPerfil", DbType.Int32, pItem.IdPerfil);
            db.AddInParameter(dbCommand, "pIdMenu", DbType.Int32, pItem.IdMenu);
            db.AddInParameter(dbCommand, "pFlagLectura", DbType.Boolean, pItem.FlagLectura);
            db.AddInParameter(dbCommand, "pFlagAdicion", DbType.Boolean, pItem.FlagAdicion);
            db.AddInParameter(dbCommand, "pFlagActualizacion", DbType.Boolean, pItem.FlagActualizacion);
            db.AddInParameter(dbCommand, "pFlagEliminacion", DbType.Boolean, pItem.FlagEliminacion);
            db.AddInParameter(dbCommand, "pFlagImpresion", DbType.Boolean, pItem.FlagImpresion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(AccesoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Acceso_Elimina");

            db.AddInParameter(dbCommand, "pIdPerfil", DbType.Int32, pItem.IdPerfil);
            db.AddInParameter(dbCommand, "pIdMenu", DbType.Int32, pItem.IdMenu);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<AccesoBE> SeleccionaPerfil(int IdPerfil)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Acceso_SeleccionaPerfil");
            db.AddInParameter(dbCommand, "pIdPerfil", DbType.Int32, IdPerfil);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccesoBE> accesolist = new List<AccesoBE>();
            AccesoBE acceso;
            while (reader.Read())
            {
                acceso = new AccesoBE();
                acceso.IdPerfil = Int32.Parse(reader["idperfil"].ToString());
                acceso.IdMenu = Int32.Parse(reader["idmenu"].ToString());
                acceso.FlagLectura = Boolean.Parse(reader["flaglectura"].ToString());
                acceso.FlagAdicion = Boolean.Parse(reader["flagadicion"].ToString());
                acceso.FlagActualizacion = Boolean.Parse(reader["flagactualizacion"].ToString());
                acceso.FlagEliminacion = Boolean.Parse(reader["flageliminacion"].ToString());
                acceso.FlagImpresion = Boolean.Parse(reader["flagimpresion"].ToString());
                acceso.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                acceso.TipOper = 4;
                accesolist.Add(acceso);
            }
            reader.Close();
            reader.Dispose();
            return accesolist;
        }

        public List<AccesoBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Acceso_ListaTodosActivo");
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccesoBE> accesolist = new List<AccesoBE>();
            AccesoBE acceso;
            while (reader.Read())
            {
                acceso = new AccesoBE();
                acceso.IdPerfil = Int32.Parse(reader["idperfil"].ToString());
                acceso.IdMenu = Int32.Parse(reader["idmenu"].ToString());
                acceso.FlagLectura = Boolean.Parse(reader["flaglectura"].ToString());
                acceso.FlagAdicion = Boolean.Parse(reader["flagadicion"].ToString());
                acceso.FlagActualizacion = Boolean.Parse(reader["flagactualizacion"].ToString());
                acceso.FlagEliminacion = Boolean.Parse(reader["flageliminacion"].ToString());
                acceso.FlagImpresion = Boolean.Parse(reader["flagimpresion"].ToString());
                acceso.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                accesolist.Add(acceso);
            }
            reader.Close();
            reader.Dispose();
            return accesolist;
        }
    }
}
