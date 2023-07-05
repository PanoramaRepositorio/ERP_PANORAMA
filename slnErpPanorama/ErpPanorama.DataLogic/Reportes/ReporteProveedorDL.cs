using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteProveedorDL
    {
        public List<ReporteProveedorBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProveedor");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProveedorBE> Proveedorlist = new List<ReporteProveedorBE>();
            ReporteProveedorBE Proveedor;
            while (reader.Read())
            {
                Proveedor = new ReporteProveedorBE();
                Proveedor.IdProveedor = Int32.Parse(reader["idProveedor"].ToString());
                Proveedor.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Proveedor.DescProveedor = reader["descProveedor"].ToString();
                Proveedor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Proveedorlist.Add(Proveedor);
            }
            reader.Close();
            reader.Dispose();
            return Proveedorlist;
        }
    }
}
