using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoRutaSemanaDL
    {
        public List<ReportePedidoRutaSemanaBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoRutaSemana");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoRutaSemanaBE> Pedidolist = new List<ReportePedidoRutaSemanaBE>();
            ReportePedidoRutaSemanaBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoRutaSemanaBE();
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.Semana = reader["Semana"].ToString();
                Pedido.Ruta10 = decimal.Parse(reader["Ruta10"].ToString());
                Pedido.Ruta20 = decimal.Parse(reader["Ruta20"].ToString());
                Pedido.Ruta30 = decimal.Parse(reader["Ruta30"].ToString());
                Pedido.Ruta40 = decimal.Parse(reader["Ruta40"].ToString());
                Pedido.Ruta50 = decimal.Parse(reader["Ruta50"].ToString());
                Pedido.Ruta60 = decimal.Parse(reader["Ruta60"].ToString());
                Pedido.Ruta70 = decimal.Parse(reader["Ruta70"].ToString());
                Pedido.Ruta80 = decimal.Parse(reader["Ruta80"].ToString());
                Pedido.Ruta90 = decimal.Parse(reader["Ruta90"].ToString());
                Pedido.Ruta100 = decimal.Parse(reader["Ruta100"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
