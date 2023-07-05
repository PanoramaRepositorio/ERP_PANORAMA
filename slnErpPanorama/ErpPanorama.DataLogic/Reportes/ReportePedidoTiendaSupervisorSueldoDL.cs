using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoTiendaSupervisorSueldoDL
    {
        public List<ReportePedidoTiendaSupervisorSueldoBE> Listado(int IdEmpresa, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoTiendaSupervisorSueldo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoTiendaSupervisorSueldoBE> lista = new List<ReportePedidoTiendaSupervisorSueldoBE>();
            ReportePedidoTiendaSupervisorSueldoBE reporte = null;
            while (reader.Read())
            {
                reporte = new ReportePedidoTiendaSupervisorSueldoBE();
                reporte.Tipo = Int32.Parse(reader["Tipo"].ToString());
                reporte.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                reporte.ApeNom = reader["ApeNom"].ToString();
                reporte.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                reporte.Cargo = reader["Cargo"].ToString();
                reporte.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                reporte.DescTienda = reader["DescTienda"].ToString();
                reporte.TotalClienteFinal = Decimal.Parse(reader["TotalClienteFinal"].ToString());
                reporte.TotalClienteMayorista = Decimal.Parse(reader["TotalClienteMayorista"].ToString());
                reporte.TotalVenta = Decimal.Parse(reader["TotalVenta"].ToString());
                reporte.Meta = Decimal.Parse(reader["Meta"].ToString());
                reporte.PorMeta = Decimal.Parse(reader["PorMeta"].ToString());
                reporte.BonoMetaTienda = Decimal.Parse(reader["BonoMetaTienda"].ToString());
                reporte.FlaCobro = Boolean.Parse(reader["FlaCobro"].ToString());
                reporte.DetalleCobro = reader["DetalleCobro"].ToString();
                reporte.DiaAlcanceMetaTienda = Int32.Parse(reader["DiaAlcanceMetaTienda"].ToString());
                reporte.Conversion = Decimal.Parse(reader["Conversion"].ToString());
                reporte.BonoConversion = Decimal.Parse(reader["BonoConversion"].ToString());
                reporte.Basico = Decimal.Parse(reader["Basico"].ToString());
                reporte.ComisionBasica = Decimal.Parse(reader["ComisionBasica"].ToString());
                reporte.BonoGestion = Decimal.Parse(reader["BonoGestion"].ToString());
                reporte.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }
    }
}
