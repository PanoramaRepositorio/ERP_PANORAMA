using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class EncuestaDL
    {
        public EncuestaDL() { }

        public void Inserta(EncuestaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Encuesta_Inserta");

            db.AddInParameter(dbCommand, "pIdEncuesta", DbType.Int32, pItem.IdEncuesta);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pFlagDescuento", DbType.Boolean, pItem.FlagDescuento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(EncuestaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Encuesta_Actualiza");

            db.AddInParameter(dbCommand, "pIdEncuesta", DbType.Int32, pItem.IdEncuesta);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.Int32, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pFlagDescuento", DbType.Boolean, pItem.FlagDescuento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaFlagDescuento(int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Encuesta_ActualizaFlagDescuento");

            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Encuesta_Elimina");

            db.AddInParameter(dbCommand, "pIdEncuesta", DbType.Int32, IdCliente);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<EncuestaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Encuesta_ListaTodosActivo");
            db.AddInParameter(dbCommand, "@pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EncuestaBE> Encuestalist = new List<EncuestaBE>();
            EncuestaBE Encuesta;
            while (reader.Read())
            {
                Encuesta = new EncuestaBE();
                Encuesta.IdEncuesta = Int32.Parse(reader["idEncuesta"].ToString());
                Encuesta.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Encuesta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Encuesta.DescCliente = reader["DescCliente"].ToString();
                Encuesta.FlagDescuento = Boolean.Parse(reader["FlagDescuento"].ToString());
                Encuesta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Encuestalist.Add(Encuesta);
            }
            reader.Close();
            reader.Dispose();
            return Encuestalist;
        }

        public EncuestaBE Selecciona(int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Encuesta_Selecciona");
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EncuestaBE Encuesta = null;
            while (reader.Read())
            {
                Encuesta = new EncuestaBE();
                Encuesta.IdEncuesta = Int32.Parse(reader["IdEncuesta"].ToString());
                Encuesta.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Encuesta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Encuesta.DescCliente = reader["DescCliente"].ToString();
                Encuesta.FlagDescuento = Boolean.Parse(reader["FlagDescuento"].ToString());
                Encuesta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Encuesta;
        }


        public EncuestaBE SeleccionaDescuento(int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Encuesta_SeleccionaFlagDescuento");
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EncuestaBE Encuesta = null;
            while (reader.Read())
            {
                Encuesta = new EncuestaBE();
                Encuesta.IdEncuesta = Int32.Parse(reader["IdEncuesta"].ToString());
                Encuesta.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Encuesta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Encuesta.DescCliente = reader["DescCliente"].ToString();
                Encuesta.FlagDescuento = Boolean.Parse(reader["FlagDescuento"].ToString());
                Encuesta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Encuesta;
        }

    }
}
