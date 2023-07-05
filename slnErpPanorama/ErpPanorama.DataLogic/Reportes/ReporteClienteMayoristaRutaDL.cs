using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteClienteMayoristaRutaDL
    {
        public List<ReporteClienteMayoristaRutaBE> Listado(int IdEmpresa, int IdRuta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptClienteMayoristaRuta");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdRuta", DbType.Int32, IdRuta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteClienteMayoristaRutaBE> ClienteGenerallist = new List<ReporteClienteMayoristaRutaBE>();
            ReporteClienteMayoristaRutaBE ClienteGeneral;
            while (reader.Read())
            {
                ClienteGeneral = new ReporteClienteMayoristaRutaBE();
                ClienteGeneral.DescCliente = reader["descCliente"].ToString();
                ClienteGeneral.Direccion = reader["direccion"].ToString();
                ClienteGeneral.NomDpto = reader["NomDpto"].ToString();
                ClienteGeneral.NomProv = reader["NomProv"].ToString();
                ClienteGeneral.NomDist = reader["NomDist"].ToString();
                ClienteGeneral.Telefono = reader["telefono"].ToString();
                ClienteGeneral.Celular = reader["celular"].ToString();
                ClienteGeneral.OtroTelefono = reader["otroTelefono"].ToString();
                ClienteGenerallist.Add(ClienteGeneral);
            }
            reader.Close();
            reader.Dispose();
            return ClienteGenerallist;
        }
    }
}
