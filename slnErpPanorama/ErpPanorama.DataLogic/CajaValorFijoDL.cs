using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class CajaValorFijoDL
    {
        public CajaValorFijoDL() { }

        public void Inserta(CajaValorFijoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaValorFijo_Inserta");

            db.AddInParameter(dbCommand, "pIdCajaValorFijo", DbType.Int32, pItem.IdCajaValorFijo);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pTipoValor", DbType.String, pItem.TipoValor);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pDenominacion", DbType.Decimal, pItem.Denominacion);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(CajaValorFijoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaValorFijo_Actualiza");

            db.AddInParameter(dbCommand, "pIdCajaValorFijo", DbType.Int32, pItem.IdCajaValorFijo);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pTipoValor", DbType.String, pItem.TipoValor);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pDenominacion", DbType.Decimal, pItem.Denominacion);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(CajaValorFijoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaValorFijo_Elimina");

            db.AddInParameter(dbCommand, "pIdCajaValorFijo", DbType.Int32, pItem.IdCajaValorFijo);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<CajaValorFijoBE> ListaTodosActivo(int IdCaja, DateTime Fecha, string TipoValor, int IdMoneda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaValorFijo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);
            db.AddInParameter(dbCommand, "pTipoValor", DbType.String, TipoValor);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, IdMoneda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaValorFijoBE> CajaValorFijolist = new List<CajaValorFijoBE>();
            CajaValorFijoBE CajaValorFijo;
            while (reader.Read())
            {
                CajaValorFijo = new CajaValorFijoBE();
                CajaValorFijo.IdCajaValorFijo = Int32.Parse(reader["IdCajaValorFijo"].ToString());
                CajaValorFijo.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                CajaValorFijo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                CajaValorFijo.TipoValor = reader["TipoValor"].ToString();
                CajaValorFijo.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                CajaValorFijo.Denominacion = Decimal.Parse(reader["Denominacion"].ToString());
                CajaValorFijo.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                CajaValorFijo.Total = Decimal.Parse(reader["Total"].ToString());
                CajaValorFijo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CajaValorFijolist.Add(CajaValorFijo);
            }
            reader.Close();
            reader.Dispose();
            return CajaValorFijolist;
        }
    }
}
