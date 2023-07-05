using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class DescuentoClienteMayoristaDL
    {
        public DescuentoClienteMayoristaDL() { }

        public void Inserta(DescuentoClienteMayoristaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClienteMayorista_Inserta");

            db.AddInParameter(dbCommand, "pIdDescuentoClienteMayorista", DbType.Int32, pItem.IdDescuentoClienteMayorista);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pMontoMin", DbType.Decimal, pItem.MontoMin);
            db.AddInParameter(dbCommand, "pMontoMax", DbType.Decimal, pItem.MontoMax);
            db.AddInParameter(dbCommand, "pPorDescuento", DbType.Decimal, pItem.PorDescuento);
            db.AddInParameter(dbCommand, "pFlagPreVenta", DbType.Boolean, pItem.FlagPreVenta);
            db.AddInParameter(dbCommand, "pFlagVenta", DbType.Boolean, pItem.FlagVenta);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(DescuentoClienteMayoristaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClienteMayorista_Actualiza");

            db.AddInParameter(dbCommand, "pIdDescuentoClienteMayorista", DbType.Int32, pItem.IdDescuentoClienteMayorista);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pMontoMin", DbType.Decimal, pItem.MontoMin);
            db.AddInParameter(dbCommand, "pMontoMax", DbType.Decimal, pItem.MontoMax);
            db.AddInParameter(dbCommand, "pPorDescuento", DbType.Decimal, pItem.PorDescuento);
            db.AddInParameter(dbCommand, "pFlagPreVenta", DbType.Boolean, pItem.FlagPreVenta);
            db.AddInParameter(dbCommand, "pFlagVenta", DbType.Boolean, pItem.FlagVenta);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(DescuentoClienteMayoristaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClienteMayorista_Elimina");

            db.AddInParameter(dbCommand, "pIdDescuentoClienteMayorista", DbType.Int32, pItem.IdDescuentoClienteMayorista);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<DescuentoClienteMayoristaBE> ListaTodosActivo(int IdEmpresa, int IdFormaPago, int IdLineaProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClienteMayorista_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, IdFormaPago);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DescuentoClienteMayoristaBE> DescuentoClienteMayoristalist = new List<DescuentoClienteMayoristaBE>();
            DescuentoClienteMayoristaBE DescuentoClienteMayorista;
            while (reader.Read())
            {
                DescuentoClienteMayorista = new DescuentoClienteMayoristaBE();
                DescuentoClienteMayorista.IdDescuentoClienteMayorista = Int32.Parse(reader["idDescuentoClienteMayorista"].ToString());
                DescuentoClienteMayorista.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DescuentoClienteMayorista.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                DescuentoClienteMayorista.DescFormaPago = reader["DescFormaPago"].ToString();
                DescuentoClienteMayorista.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                DescuentoClienteMayorista.DescLineaProducto = reader["DescLineaProducto"].ToString();
                DescuentoClienteMayorista.MontoMin = Decimal.Parse(reader["MontoMin"].ToString());
                DescuentoClienteMayorista.MontoMax = Decimal.Parse(reader["MontoMax"].ToString());
                DescuentoClienteMayorista.PorDescuento = Decimal.Parse(reader["PorDescuento"].ToString());
                DescuentoClienteMayorista.FlagPreVenta = Boolean.Parse(reader["FlagPreVenta"].ToString());
                DescuentoClienteMayorista.FlagVenta = Boolean.Parse(reader["FlagVenta"].ToString());
                DescuentoClienteMayorista.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DescuentoClienteMayoristalist.Add(DescuentoClienteMayorista);
            }
            reader.Close();
            reader.Dispose();
            return DescuentoClienteMayoristalist;
        }
    }
}
