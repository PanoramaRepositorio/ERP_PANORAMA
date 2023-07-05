using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteTransferenciaBultoDL
    {
        public List<ReporteTransferenciaBultoBE> Listado(int IdEmpresa, int IdTransferenciaBulto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptTransferenciaBulto");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, IdTransferenciaBulto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteTransferenciaBultoBE> TransferenciaBultolist = new List<ReporteTransferenciaBultoBE>();
            ReporteTransferenciaBultoBE TransferenciaBulto;
            while (reader.Read())
            {
                TransferenciaBulto = new ReporteTransferenciaBultoBE();
                TransferenciaBulto.IdTransferenciaBulto = Int32.Parse(reader["idTransferenciaBulto"].ToString());
                TransferenciaBulto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                TransferenciaBulto.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                TransferenciaBulto.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                TransferenciaBulto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                TransferenciaBulto.FechaMovimiento = DateTime.Parse(reader["FechaMovimiento"].ToString());
                TransferenciaBulto.IdAlmacenOrigen = Int32.Parse(reader["IdAlmacenOrigen"].ToString());
                TransferenciaBulto.AlmacenOrigen = reader["AlmacenOrigen"].ToString();
                TransferenciaBulto.IdAlmacenDestino = Int32.Parse(reader["IdAlmacenDestino"].ToString());
                TransferenciaBulto.AlmacenDestino = reader["AlmacenDestino"].ToString();
                TransferenciaBulto.Observacion = reader["Observacion"].ToString();
                TransferenciaBulto.IdMovimientoAlmacenIngreso = Int32.Parse(reader["IdMovimientoAlmacenIngreso"].ToString());
                TransferenciaBulto.NumeroDocumentoIngreso = reader["NumeroDocumentoIngreso"].ToString();
                TransferenciaBulto.IdMovimientoAlmacenSalida = Int32.Parse(reader["IdMovimientoAlmacenSalida"].ToString());
                TransferenciaBulto.NumeroDocumentoSalida = reader["NumeroDocumentoSalida"].ToString();
                TransferenciaBulto.IdBulto = Int32.Parse(reader["IdBulto"].ToString());
                TransferenciaBulto.NumeroBulto = reader["NumeroBulto"].ToString();
                TransferenciaBulto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                TransferenciaBulto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                TransferenciaBulto.NombreProducto = reader["NombreProducto"].ToString();
                TransferenciaBulto.Abreviatura = reader["Abreviatura"].ToString();
                TransferenciaBulto.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                TransferenciaBulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                       TransferenciaBultolist.Add(TransferenciaBulto);
            }
            reader.Close();
            reader.Dispose();
            return TransferenciaBultolist;
        }
    }
}
