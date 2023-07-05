using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteClienteRegistroVendedorDL
    {
        public List<ReporteClienteRegistroVendedorBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptClienteRegistroVendedor");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteClienteRegistroVendedorBE> Pedidolist = new List<ReporteClienteRegistroVendedorBE>();
            ReporteClienteRegistroVendedorBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReporteClienteRegistroVendedorBE();
                Pedido.ApeNom = reader["ApeNom"].ToString();
                Pedido.Numero = int.Parse(reader["Numero"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
