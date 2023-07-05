using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic.Reporte
{
    public class ReporteSolicitudProductoDetalleDL
    {
        public List<ReporteSolicitudProductoDetalleBE> Listado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta )
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptSolicitudProductoListaDetalle");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteSolicitudProductoDetalleBE> SolicitudProductolist = new List<ReporteSolicitudProductoDetalleBE>();
            ReporteSolicitudProductoDetalleBE SolicitudProducto;
            while (reader.Read())
            {
                SolicitudProducto = new ReporteSolicitudProductoDetalleBE();
                SolicitudProducto.IdSolicitudProducto = Int32.Parse(reader["IdSolicitudProducto"].ToString());
                SolicitudProducto.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                SolicitudProducto.Numero = reader["Numero"].ToString();
                SolicitudProducto.FechaSolicitud = DateTime.Parse(reader["FechaSolicitud"].ToString());
                SolicitudProducto.Solicitante = reader["Solicitante"].ToString();
                SolicitudProducto.DescAlmacen = reader["DescAlmacen"].ToString();
                SolicitudProducto.DescTiendaDestino = reader["DescTiendaDestino"].ToString();
                SolicitudProducto.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                SolicitudProducto.Observacion = reader["Observacion"].ToString();
                SolicitudProducto.FechaEnvio = DateTime.Parse(reader["FechaEnvio"].ToString());
                SolicitudProducto.FlagEnviado = Boolean.Parse(reader["FlagEnviado"].ToString());
                SolicitudProducto.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                SolicitudProducto.NumeroNS = reader["NumeroNS"].ToString();
                SolicitudProducto.Item = Int32.Parse(reader["Item"].ToString());
                SolicitudProducto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                SolicitudProducto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                SolicitudProducto.NombreProducto = reader["NombreProducto"].ToString();
                SolicitudProducto.Medida = reader["Medida"].ToString();
                SolicitudProducto.Abreviatura = reader["Abreviatura"].ToString();
                SolicitudProducto.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                SolicitudProductolist.Add(SolicitudProducto);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudProductolist;
        }
    }
}
