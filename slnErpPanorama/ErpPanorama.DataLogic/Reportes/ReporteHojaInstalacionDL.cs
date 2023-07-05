using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteHojaInstalacionDL
    {
        public List<ReporteHojaInstalacionBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptHojaInstalacion");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteHojaInstalacionBE> HojaInstalacionlist = new List<ReporteHojaInstalacionBE>();
            ReporteHojaInstalacionBE HojaInstalacion;
            while (reader.Read())
            {
                HojaInstalacion = new ReporteHojaInstalacionBE();
                HojaInstalacion.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                HojaInstalacion.IdHojaInstalacion = Int32.Parse(reader["idHojaInstalacion"].ToString());
                HojaInstalacion.DiaSemana = reader["DiaSemana"].ToString();
                HojaInstalacion.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                HojaInstalacion.IdTurno = Int32.Parse(reader["IdTurno"].ToString());
                HojaInstalacion.DescTurno = reader["DescTurno"].ToString();
                HojaInstalacion.DescVendedor = reader["DescVendedor"].ToString();
                HojaInstalacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                HojaInstalacion.DescCliente = reader["DescCliente"].ToString();
                HojaInstalacion.IdUbigeo = reader["IdUbigeo"].ToString();
                HojaInstalacion.Distrito = reader["Distrito"].ToString();
                HojaInstalacion.Direccion = reader["Direccion"].ToString();
                HojaInstalacion.Referencia = reader["Referencia"].ToString();
                HojaInstalacion.FlagReserva = Boolean.Parse(reader["FlagReserva"].ToString());
                HojaInstalacion.Observacion = reader["Observacion"].ToString();
                HojaInstalacion.NumeroPedido = reader["NumeroPedido"].ToString();
                HojaInstalacion.NombreProducto = reader["NombreProducto"].ToString();
                HojaInstalacion.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                HojaInstalacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                HojaInstalacionlist.Add(HojaInstalacion);
            }
            reader.Close();
            reader.Dispose();
            return HojaInstalacionlist;
        }

    }
}
