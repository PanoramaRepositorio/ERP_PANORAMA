using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ConTipoComprobantePagoDL
    {
       public ConTipoComprobantePagoDL() { }

        public void Inserta(ConTipoComprobantePagoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConTipoComprobantePago_Inserta");

            db.AddInParameter(dbCommand, "pIdConTipoComprobantePago", DbType.Int32, pItem.IdConTipoComprobantePago);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pDescTipoComprobantePago", DbType.String, pItem.DescTipoComprobantePago);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ConTipoComprobantePagoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConTipoComprobantePago_Actualiza");

            db.AddInParameter(dbCommand, "pIdConTipoComprobantePago", DbType.Int32, pItem.IdConTipoComprobantePago);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pDescTipoComprobantePago", DbType.String, pItem.DescTipoComprobantePago);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ConTipoComprobantePagoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConTipoComprobantePago_Elimina");

            db.AddInParameter(dbCommand, "pIdConTipoComprobantePago", DbType.Int32, pItem.IdConTipoComprobantePago);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ConTipoComprobantePagoBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConTipoComprobantePago_ListaTodosActivo");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ConTipoComprobantePagoBE> ConTipoComprobantePagolist = new List<ConTipoComprobantePagoBE>();
            ConTipoComprobantePagoBE ConTipoComprobantePago;
            while (reader.Read())
            {
                ConTipoComprobantePago = new ConTipoComprobantePagoBE();
                ConTipoComprobantePago.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                ConTipoComprobantePago.Abreviatura = reader["Abreviatura"].ToString();
                ConTipoComprobantePago.DescTipoComprobantePago = reader["DescTipoComprobantePago"].ToString();
                ConTipoComprobantePago.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                ConTipoComprobantePagolist.Add(ConTipoComprobantePago);
            }
            reader.Close();
            reader.Dispose();
            return ConTipoComprobantePagolist;
        }

        public ConTipoComprobantePagoBE Selecciona(int IdConTipoComprobantePago)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConTipoComprobantePago_Selecciona");
            db.AddInParameter(dbCommand, "pIdConTipoComprobantePago", DbType.Int32, IdConTipoComprobantePago);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ConTipoComprobantePagoBE ConTipoComprobantePago = null;
            while (reader.Read())
            {
                ConTipoComprobantePago = new ConTipoComprobantePagoBE();
                ConTipoComprobantePago.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                ConTipoComprobantePago.Abreviatura = reader["Abreviatura"].ToString();
                ConTipoComprobantePago.DescTipoComprobantePago = reader["DescTipoComprobantePago"].ToString();
                ConTipoComprobantePago.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ConTipoComprobantePago;
        }
    }
}
