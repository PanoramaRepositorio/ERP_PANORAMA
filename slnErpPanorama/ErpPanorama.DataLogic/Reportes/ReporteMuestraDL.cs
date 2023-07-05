using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteMuestraDL
    {
        public List<ReporteMuestraBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptMuestra");

            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMuestraBE> Muestralist = new List<ReporteMuestraBE>();
            ReporteMuestraBE Muestra;
            while (reader.Read())
            {
                Muestra = new ReporteMuestraBE();
                Muestra.RazonSocial = reader["RazonSocial"].ToString();
                Muestra.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Muestra.DescTienda = reader["DescTienda"].ToString();
                Muestra.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Muestra.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Muestra.NombreProducto = reader["NombreProducto"].ToString();
                Muestra.Abreviatura = reader["Abreviatura"].ToString();
                Muestra.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Muestra.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Muestra.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                Muestra.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                Muestralist.Add(Muestra);
            }
            reader.Close();
            reader.Dispose();
            return Muestralist;
        }
    }
}
