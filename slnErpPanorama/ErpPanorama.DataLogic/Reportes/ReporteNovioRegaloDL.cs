using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteNovioRegaloDL
    {
        public List<ReporteNovioRegaloBE> Listado(int IdNovioRegalo, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptNovioRegalo");
            db.AddInParameter(dbCommand, "pIdNovioRegalo", DbType.Int32, IdNovioRegalo);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteNovioRegaloBE> lista = new List<ReporteNovioRegaloBE>();
            ReporteNovioRegaloBE reporte = null;
            while (reader.Read())
            {
                reporte = new ReporteNovioRegaloBE();
                reporte.RazonSocial = reader["RazonSocial"].ToString();
                reporte.DescTienda = reader["DescTienda"].ToString();
                reporte.CodigoNovio = reader["CodigoNovio"].ToString();
                reporte.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                reporte.DniNovio = reader["DniNovio"].ToString();
                reporte.DescNovio = reader["DescNovio"].ToString();
                reporte.DniNovia = reader["DniNovia"].ToString();
                reporte.DescNovia = reader["DescNovia"].ToString();
                reporte.Telefono = reader["Telefono"].ToString();
                reporte.Celular = reader["Celular"].ToString();
                reporte.Email = reader["Email"].ToString();
                reporte.Email2 = reader["Email2"].ToString();
                reporte.Direccion = reader["Direccion"].ToString();
                reporte.FechaBoda = DateTime.Parse(reader["FechaBoda"].ToString());
                reporte.DescAsesor = reader["DescAsesor"].ToString();
                reporte.DescVendedor = reader["DescVendedor"].ToString();
                reporte.Observacion = reader["Observacion"].ToString();
                reporte.Item = reader["Item"].ToString();
                reporte.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                reporte.CodigoProveedor = reader["CodigoProveedor"].ToString();
                reporte.NombreProducto = reader["NombreProducto"].ToString();
                reporte.Abreviatura = reader["Abreviatura"].ToString();
                reporte.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                reporte.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                reporte.PorcentajeDescuento = Decimal.Parse(reader["PorcentajeDescuento"].ToString());
                reporte.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                reporte.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                reporte.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                reporte.ObservacionDetalle = reader["ObservacionDetalle"].ToString();
                reporte.Comprado = reader["Comprado"].ToString();
                reporte.FlagComprado = Boolean.Parse(reader["FlagComprado"].ToString());
                reporte.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }
    }
}
