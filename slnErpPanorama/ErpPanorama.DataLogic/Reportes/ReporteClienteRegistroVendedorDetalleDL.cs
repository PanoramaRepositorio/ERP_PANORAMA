using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteClienteRegistroVendedorDetalleDL
    {
        public List<ReporteClienteRegistroVendedorDetalleBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptClienteRegistroVendedorDetalle");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteClienteRegistroVendedorDetalleBE> Pedidolist = new List<ReporteClienteRegistroVendedorDetalleBE>();
            ReporteClienteRegistroVendedorDetalleBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReporteClienteRegistroVendedorDetalleBE();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.ApeNom = reader["ApeNom"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.AbrevDomicilio = reader["AbrevDomicilio"].ToString();
                Pedido.Direccion = reader["Direccion"].ToString();
                Pedido.NomDpto = reader["NomDpto"].ToString();
                Pedido.NomProv = reader["NomProv"].ToString();
                Pedido.NomDist = reader["NomDist"].ToString();
                Pedido.Telefono = reader["Telefono"].ToString();
                Pedido.Celular = reader["Celular"].ToString();
                Pedido.OtroTelefono = reader["OtroTelefono"].ToString();
                Pedido.TelefonoAdicional = reader["TelefonoAdicional"].ToString();
                Pedido.Email = reader["Email"].ToString();
                Pedido.TipoCliente = reader["TipoCliente"].ToString();
                Pedido.FechaRegistro = reader["FechaRegistro"].ToString();
                Pedido.Edad = reader["Edad"].ToString();
                Pedido.TotalSoles = Decimal.Parse(reader["TotalSoles"].ToString());

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
