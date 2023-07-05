using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteGuiaRemisionDL
    {
        public List<ReporteGuiaRemisionBE> Listado(int IdEmpresa, int IdGuiaRemision)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptGuiaRemision");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdGuiaRemision", DbType.Int32, IdGuiaRemision);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteGuiaRemisionBE> GuiaRemisionlist = new List<ReporteGuiaRemisionBE>();
            ReporteGuiaRemisionBE GuiaRemision;
            while (reader.Read())
            {
                GuiaRemision = new ReporteGuiaRemisionBE();
                GuiaRemision.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                GuiaRemision.IdGuiaRemision = Int32.Parse(reader["idGuiaRemision"].ToString());
                GuiaRemision.RazonSocialRemitente = reader["RazonSocialRemitente"].ToString();
                GuiaRemision.Periodo = Int32.Parse(reader["periodo"].ToString());
                GuiaRemision.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                GuiaRemision.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                GuiaRemision.Serie = reader["Serie"].ToString();
                GuiaRemision.Numero = reader["numero"].ToString();
                GuiaRemision.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                GuiaRemision.IdTiendaRemitente = Int32.Parse(reader["IdTiendaRemitente"].ToString());
                GuiaRemision.TiendaRemitente = reader["TiendaRemitente"].ToString();
                GuiaRemision.DireccionRemitente = reader["DireccionRemitente"].ToString();
                GuiaRemision.IdEmpresaDestinatario = Int32.Parse(reader["IdEmpresaDestinatario"].ToString());
                GuiaRemision.RazonSocialDestinatario = reader["RazonSocialRemitente"].ToString();
                GuiaRemision.IdTiendaDestinatario = Int32.Parse(reader["IdTiendaDestinatario"].ToString());
                GuiaRemision.TiendaDestinatario = reader["TiendaDestinatario"].ToString();
                GuiaRemision.DireccionDestinatario = reader["DireccionDestinatario"].ToString();
                GuiaRemision.DescTransportista = reader["DescTransportista"].ToString();
                GuiaRemision.RucTransportista = reader["RucTransportista"].ToString();
                GuiaRemision.NumeroLicencia = reader["NumeroLicencia"].ToString();
                GuiaRemision.DescVehiculo = reader["DescVehiculo"].ToString();
                GuiaRemision.NumeroPlaca = reader["NumeroPlaca"].ToString();
                GuiaRemision.IdTipoDocumentoReferencia = Int32.Parse(reader["IdTipoDocumentoReferencia"].ToString());
                GuiaRemision.CodTipoDocumentoReferencia = reader["CodTipoDocumentoReferencia"].ToString();
                GuiaRemision.NumeroDocumento = reader["NumeroDocumento"].ToString();
                GuiaRemision.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                GuiaRemision.DescMotivo = reader["DescMotivo"].ToString();
                GuiaRemision.Observacion = reader["observacion"].ToString();
                GuiaRemision.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                GuiaRemision.Item = Int32.Parse(reader["Item"].ToString());
                GuiaRemision.CodigoProveedor = reader["CodigoProveedor"].ToString();
                GuiaRemision.NombreProducto = reader["nombreProducto"].ToString();
                GuiaRemision.Abreviatura = reader["Abreviatura"].ToString();
                GuiaRemision.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                GuiaRemision.CostoUnitario = Decimal.Parse(reader["costoUnitario"].ToString());
                GuiaRemision.MontoTotal = Decimal.Parse(reader["montoTotal"].ToString());
                GuiaRemisionlist.Add(GuiaRemision);
            }
            reader.Close();
            reader.Dispose();
            return GuiaRemisionlist;
        }
    }
}
