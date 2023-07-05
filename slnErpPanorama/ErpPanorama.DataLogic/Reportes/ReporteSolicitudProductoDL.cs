using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteSolicitudProductoDL
    {
        public List<ReporteSolicitudProductoBE> Listado(int IdEmpresa, int IdSolicitudProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptSolicitudProducto2");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdSolicitudProducto", DbType.Int32, IdSolicitudProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteSolicitudProductoBE> SolicitudProductolist = new List<ReporteSolicitudProductoBE>();
            ReporteSolicitudProductoBE SolicitudProducto;
            while (reader.Read())
            {
                SolicitudProducto = new ReporteSolicitudProductoBE();
                SolicitudProducto.IdSolicitudProducto = Int32.Parse(reader["IdSolicitudProducto"].ToString());
                SolicitudProducto.Periodo = Int32.Parse(reader["Periodo"].ToString());
                SolicitudProducto.Documento = reader["Documento"].ToString();
                SolicitudProducto.Numero = reader["Numero"].ToString();
                SolicitudProducto.FechaSolicitud = DateTime.Parse(reader["FechaSolicitud"].ToString());
                SolicitudProducto.Solicitante = reader["Solicitante"].ToString();
                SolicitudProducto.DescAlmacen = reader["DescAlmacen"].ToString();
                SolicitudProducto.DescTiendaDestino = reader["DescTiendaDestino"].ToString();
                SolicitudProducto.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                SolicitudProducto.Observacion = reader["Observacion"].ToString();
                SolicitudProducto.FechaEnvio = DateTime.Parse(reader["FechaEnvio"].ToString());
                SolicitudProducto.FechaImpresion = DateTime.Parse(reader["FechaImpresion"].ToString());
                SolicitudProducto.IdSolicitudProductoDetalle = Int32.Parse(reader["IdSolicitudProductoDetalle"].ToString());
                SolicitudProducto.Item = Int32.Parse(reader["Item"].ToString());
                SolicitudProducto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                SolicitudProducto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                SolicitudProducto.NombreProducto = reader["NombreProducto"].ToString();
                SolicitudProducto.Abreviatura = reader["Abreviatura"].ToString();
                SolicitudProducto.UbicacionUcayali = reader["UbicacionUcayali"].ToString();
                SolicitudProducto.UbicacionAndahuaylas = reader["UbicacionAndahuaylas"].ToString();
                SolicitudProducto.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                SolicitudProducto.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
                SolicitudProducto.ObservacionDetalle = reader["ObservacionDetalle"].ToString();
                SolicitudProducto.NumerosBultos = reader["NumerosBultos"].ToString();
                SolicitudProducto.CodigoBarraNumero = null;
                SolicitudProducto.DesCausalTransferencia = reader["DesCausalTransferencia"].ToString();
                SolicitudProducto.DocumentoReferencia = reader["DocumentoReferencia"].ToString();

                SolicitudProductolist.Add(SolicitudProducto);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudProductolist;
        }
    }
}
