using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpPanorama.BusinessEntity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace ErpPanorama.DataLogic
{
    public   class FacturaCompraGastoDL
    {

        public FacturaCompraGastoDL() {}

        public Int32 Inserta(FacturaCompraGastoBE pItem)
        {
            Int32 intIdFacturaCompraGasto = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraGasto_Inserta");
        
            db.AddOutParameter(dbCommand, "pIdFacturaCompraGasto", DbType.Int32, pItem.IdFacturaCompraGasto);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, pItem.IdFacturaCompra);
            db.AddInParameter(dbCommand, "pIdTipoGasto", DbType.Int32, pItem.IdTipoGasto);
            //db.AddInParameter(dbCommand, "pDescTipoGasto", DbType.String, pItem.DescTipoGasto);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            //db.AddInParameter(dbCommand, "Moneda", DbType.Int32, pItem.Moneda);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);

            db.ExecuteNonQuery(dbCommand);

            intIdFacturaCompraGasto = (int)db.GetParameterValue(dbCommand, "pIdFacturaCompraGasto");

            return intIdFacturaCompraGasto;
        }

        public void Actualiza(FacturaCompraGastoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraGasto_Actualiza");

            db.AddInParameter(dbCommand, "pIdFacturaCompraGasto", DbType.Int32, pItem.IdFacturaCompraGasto);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, pItem.IdFacturaCompra);
            db.AddInParameter(dbCommand, "pIdTipoGasto", DbType.Int32, pItem.IdTipoGasto);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(FacturaCompraGastoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraGasto_Elimina");

            db.AddInParameter(dbCommand, "pIdFacturaCompraGasto", DbType.Int32, pItem.IdFacturaCompraGasto);

            db.ExecuteNonQuery(dbCommand);
        }


        public List<FacturaCompraGastoBE> ListaTodosActivo(int IdEmpresa, int IdFacturaCompra)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraGasto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, IdFacturaCompra);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FacturaCompraGastoBE> FacturaCompraGastolist = new List<FacturaCompraGastoBE>();
            FacturaCompraGastoBE FacturaCompraGasto;
            while (reader.Read())
            {
                FacturaCompraGasto = new FacturaCompraGastoBE();
                //FacturaCompraDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                FacturaCompraGasto.IdFacturaCompraGasto = Int32.Parse(reader["IdFacturaCompraGasto"].ToString());
                FacturaCompraGasto.IdFacturaCompra = Int32.Parse(reader["IdFacturaCompra"].ToString());
                FacturaCompraGasto.IdTipoGasto = Int32.Parse(reader["IdTipoGasto"].ToString());
                FacturaCompraGasto.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                FacturaCompraGasto.Moneda = reader["Moneda"].ToString();
                FacturaCompraGasto.Importe = Int32.Parse(reader["Importe"].ToString());
                FacturaCompraGasto.DescTipoGasto = reader["DescTipoGasto"].ToString();
                FacturaCompraGasto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                FacturaCompraGasto.TipoOper = 4;
                //FacturaCompraDetalle.TipoOper = 4; //Consultar
                FacturaCompraGastolist.Add(FacturaCompraGasto);
            }
            reader.Close();
            reader.Dispose();
            return FacturaCompraGastolist;
        }
    }
}
