using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class DescuentoClienteMayoristaFeriaDL
    {
        public DescuentoClienteMayoristaFeriaDL() { }

        public void Inserta(DescuentoClienteMayoristaFeriaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClienteMayoristaFeria_Inserta");

            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Int32, pItem.Descuento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(DescuentoClienteMayoristaFeriaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClienteMayoristaFeria_Actualiza");

            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Int32, pItem.Descuento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(DescuentoClienteMayoristaFeriaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClienteMayoristaFeria_Elimina");

            //db.AddInParameter(dbCommand, "pIdDescuentoClienteMayoristaFeria", DbType.Int32, pItem.IdDescuentoClienteMayoristaFeria);
            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<DescuentoClienteMayoristaFeriaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClienteMayoristaFeria_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DescuentoClienteMayoristaFeriaBE> DescuentoClienteMayoristaFerialist = new List<DescuentoClienteMayoristaFeriaBE>();
            DescuentoClienteMayoristaFeriaBE DescuentoClienteMayoristaFeria;
            while (reader.Read())
            {
                DescuentoClienteMayoristaFeria = new DescuentoClienteMayoristaFeriaBE();
                DescuentoClienteMayoristaFeria.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                DescuentoClienteMayoristaFeria.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                DescuentoClienteMayoristaFeria.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DescuentoClienteMayoristaFerialist.Add(DescuentoClienteMayoristaFeria);
            }
            reader.Close();
            reader.Dispose();
            return DescuentoClienteMayoristaFerialist;
        }

        public DescuentoClienteMayoristaFeriaBE Selecciona(int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClienteMayoristaFeria_Selecciona");
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            IDataReader reader = db.ExecuteReader(dbCommand);

            DescuentoClienteMayoristaFeriaBE DescuentoClienteMayoristaFeria = null;
            while (reader.Read())
            {
                DescuentoClienteMayoristaFeria = new DescuentoClienteMayoristaFeriaBE();
                DescuentoClienteMayoristaFeria.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                DescuentoClienteMayoristaFeria.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                DescuentoClienteMayoristaFeria.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return DescuentoClienteMayoristaFeria;
        }

    }
}
