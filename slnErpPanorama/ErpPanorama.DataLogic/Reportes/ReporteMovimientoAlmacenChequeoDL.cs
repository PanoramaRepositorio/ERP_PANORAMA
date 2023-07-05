using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteMovimientoAlmacenChequeoDL
    {
        public List<ReporteMovimientoAlmacenChequeoBE> Listado(int Periodo, string Numero, int IdTipoMovimiento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptMovimientoAlmacenChequeo");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);
            db.AddInParameter(dbCommand, "pIdTipoMovimiento", DbType.Int32, IdTipoMovimiento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMovimientoAlmacenChequeoBE> MovimientoAlmacenlist = new List<ReporteMovimientoAlmacenChequeoBE>();
            ReporteMovimientoAlmacenChequeoBE MovimientoAlmacen;
            while (reader.Read())
            {
                MovimientoAlmacen = new ReporteMovimientoAlmacenChequeoBE();
                MovimientoAlmacen.Periodo = Int32.Parse(reader["periodo"].ToString());
                MovimientoAlmacen.Numero = reader["Numero"].ToString();
                MovimientoAlmacen.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoAlmacen.DescAlmacen = reader["DescAlmacen"].ToString();
                MovimientoAlmacen.DescMotivo = reader["DescMotivo"].ToString();
                MovimientoAlmacen.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoAlmacen.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoAlmacen.Referencia = reader["Referencia"].ToString();
                MovimientoAlmacen.Observaciones = reader["Observaciones"].ToString();
                MovimientoAlmacen.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                MovimientoAlmacen.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                MovimientoAlmacen.Usuario = reader["Usuario"].ToString();
                MovimientoAlmacen.FechaChequeo = DateTime.Parse(reader["FechaChequeo"].ToString());
                MovimientoAlmacen.DescPicking = reader["DescPicking"].ToString();
                MovimientoAlmacen.DescChequeador = reader["DescChequeador"].ToString();
                MovimientoAlmacen.DescEmbalador = reader["DescEmbalador"].ToString();
                MovimientoAlmacen.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
                MovimientoAlmacen.Item = Int32.Parse(reader["Item"].ToString());
                MovimientoAlmacen.CodigoProveedor = reader["CodigoProveedor"].ToString();
                MovimientoAlmacen.NombreProducto = reader["NombreProducto"].ToString();
                MovimientoAlmacen.Abreviatura = reader["Abreviatura"].ToString();
                MovimientoAlmacen.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                MovimientoAlmacen.CantidadChequeo = Int32.Parse(reader["CantidadChequeo"].ToString());
                MovimientoAlmacen.CodigoBarraNumero = null;
                //MovimientoAlmacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoAlmacenlist.Add(MovimientoAlmacen);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenlist;
        }
    }
}
