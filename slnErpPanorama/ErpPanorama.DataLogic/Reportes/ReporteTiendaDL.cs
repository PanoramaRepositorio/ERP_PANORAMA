using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteTiendaDL
    {
        public List<ReporteTiendaBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptTienda");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteTiendaBE> Tiendalist = new List<ReporteTiendaBE>();
            ReporteTiendaBE Tienda;
            while (reader.Read())
            {
                Tienda = new ReporteTiendaBE();
                Tienda.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Tienda.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                Tienda.DescTienda = reader["descTienda"].ToString();
                Tienda.Direccion = reader["direccion"].ToString();
                Tienda.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Tiendalist.Add(Tienda);
            }
            reader.Close();
            reader.Dispose();
            return Tiendalist;
        }
    }
}

