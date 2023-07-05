using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteProductividadOperadorResumenDL
    {
        public List<ReporteProductividadOperadorResumenBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProductividadOperadorResumen");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProductividadOperadorResumenBE> Lista = new List<ReporteProductividadOperadorResumenBE>();
            ReporteProductividadOperadorResumenBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteProductividadOperadorResumenBE();
                Reporte.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Reporte.ApeNom = reader["ApeNom"].ToString();
                Reporte.Tipo = reader["Tipo"].ToString();
                Reporte.CantidadPedidoPicking = Decimal.Parse(reader["CantidadPedidoPicking"].ToString());
                Reporte.CantidadPedidoChequeo = Decimal.Parse(reader["CantidadPedidoChequeo"].ToString());
                Reporte.CantidadPedidoEmbalaje = Decimal.Parse(reader["CantidadPedidoEmbalaje"].ToString());
                Reporte.PromedioItemsPicking = Decimal.Parse(reader["PromedioItemsPicking"].ToString());
                Reporte.PromedioItemsChequeo = Decimal.Parse(reader["PromedioItemsChequeo"].ToString());
                Reporte.PromedioItemsEmbalaje = Decimal.Parse(reader["PromedioItemsEmbalaje"].ToString());
                Reporte.CantidadDetallePicking = Decimal.Parse(reader["CantidadDetallePicking"].ToString());
                Reporte.CantidadDetalleChequeo = Decimal.Parse(reader["CantidadDetalleChequeo"].ToString());
                Reporte.CantidadDetalleEmbalaje = Decimal.Parse(reader["CantidadDetalleEmbalaje"].ToString());
                Reporte.CantidadBulto = Decimal.Parse(reader["CantidadBulto"].ToString());
                Reporte.PromedioMinutosPicking = reader["PromedioMinutosPicking"].ToString();
                Reporte.PromedioMinutosChequeo = reader["PromedioMinutosChequeo"].ToString();
                Reporte.PromedioMinutosEmbalaje = reader["PromedioMinutosEmbalaje"].ToString();
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }
    }
}
