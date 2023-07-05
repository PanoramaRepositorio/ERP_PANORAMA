using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteCajaVaciaDL
    {
        public List<ReporteCajaVaciaBE> Listado(int IdEmpresa, int IdUbicacion, int IdPiso)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCajaVacia");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUbicacion", DbType.Int32, IdUbicacion);
            db.AddInParameter(dbCommand, "pIdPiso", DbType.Int32, IdPiso);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCajaVaciaBE> CajaVacialist = new List<ReporteCajaVaciaBE>();
            ReporteCajaVaciaBE CajaVacia;
            while (reader.Read())
            {
                CajaVacia = new ReporteCajaVaciaBE();
                CajaVacia.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CajaVacia.IdCajaVacia = Int32.Parse(reader["IdCajaVacia"].ToString());
                CajaVacia.IdUbicacion = Int32.Parse(reader["IdUbicacion"].ToString());
                CajaVacia.DescUbicacion = reader["DescUbicacion"].ToString();
                CajaVacia.IdPiso = Int32.Parse(reader["idPiso"].ToString());
                CajaVacia.DescPiso = reader["descPiso"].ToString();
                CajaVacia.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                CajaVacia.CodigoProveedor = reader["CodigoProveedor"].ToString();
                CajaVacia.NombreProducto = reader["NombreProducto"].ToString();
                CajaVacia.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                CajaVacia.FechaSalida = DateTime.Parse(reader["FechaSalida"].ToString());
                CajaVacia.Observacion = reader["Observacion"].ToString();
                CajaVacia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CajaVacialist.Add(CajaVacia);
            }
            reader.Close();
            reader.Dispose();
            return CajaVacialist;
        }
    }
}

