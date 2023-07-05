using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteTiendaAutoservicioDL
    {
        public List<ReporteTiendaAutoservicioBE> Listado(int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaTiendaAutoservicio");
            db.AddInParameter(dbCommand, "@pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteTiendaAutoservicioBE> Pedidolist = new List<ReporteTiendaAutoservicioBE>();
            ReporteTiendaAutoservicioBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReporteTiendaAutoservicioBE();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.ApeNom = reader["ApeNom"].ToString();
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());
                
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReporteTiendaAutoservicioBE> ListadoCodigoProveedor(int IdTienda,int IdFamiliaProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaTiendaAutoservicioCodigoProveedor");
            db.AddInParameter(dbCommand, "@pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "@pIdFamiliaProducto", DbType.Int32, IdFamiliaProducto);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteTiendaAutoservicioBE> Pedidolist = new List<ReporteTiendaAutoservicioBE>();
            ReporteTiendaAutoservicioBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReporteTiendaAutoservicioBE();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Pedido.NombreProducto = reader["NombreProducto"].ToString();
                Pedido.Abreviatura = reader["Abreviatura"].ToString();
                Pedido.Cantidad = int.Parse(reader["Cantidad"].ToString());
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());
                Pedido.DescLineaProducto = reader["DescLineaProducto"].ToString();

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

    }
}
