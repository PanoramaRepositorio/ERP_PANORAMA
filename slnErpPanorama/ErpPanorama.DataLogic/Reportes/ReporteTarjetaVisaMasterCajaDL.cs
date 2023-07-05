using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteTarjetaVisaMasterCajaDL
    {
        public List<ReporteTarjetaVisaMasterCajaBE> Listado(int IdTienda, int IdCaja, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptListaTarjetaCaja");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteTarjetaVisaMasterCajaBE> ClienteMinoristalist = new List<ReporteTarjetaVisaMasterCajaBE>();
            ReporteTarjetaVisaMasterCajaBE ClienteMinorista;
            while (reader.Read())
            {
                ClienteMinorista = new ReporteTarjetaVisaMasterCajaBE();
                ClienteMinorista.DescTienda = reader["DescTienda"].ToString();
                ClienteMinorista.DescCaja = reader["DescCaja"].ToString();
                ClienteMinorista.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ClienteMinorista.DescCondicionPago = reader["DescCondicionPago"].ToString();
                ClienteMinorista.TipoTarjeta = reader["TipoTarjeta"].ToString();
                ClienteMinorista.ImporteSoles = decimal.Parse(reader["ImporteSoles"].ToString());
                ClienteMinorista.Comision = decimal.Parse(reader["Comision"].ToString());
                ClienteMinorista.ComBanco = decimal.Parse(reader["ComBanco"].ToString());
                ClienteMinorista.IGV = decimal.Parse(reader["IGV"].ToString());
                ClienteMinorista.PorCobrar = decimal.Parse(reader["PorCobrar"].ToString());
                ClienteMinoristalist.Add(ClienteMinorista);
            }
            reader.Close();
            reader.Dispose();
            return ClienteMinoristalist;
        }

    }
}
