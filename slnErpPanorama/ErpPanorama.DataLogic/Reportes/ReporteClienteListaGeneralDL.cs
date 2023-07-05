using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteClienteListaGeneralDL
    {
        public List<ReporteClienteListaGeneralBE> ListadoGeneral(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptClienteListaGeneral");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteClienteListaGeneralBE> ClienteGenerallist = new List<ReporteClienteListaGeneralBE>();
            ReporteClienteListaGeneralBE ClienteGeneral;
            while (reader.Read())
            {
                ClienteGeneral = new ReporteClienteListaGeneralBE();
                ClienteGeneral.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ClienteGeneral.DescTipoCliente = reader["DescTipoCliente"].ToString();
                ClienteGeneral.AbrevDocumento = reader["AbrevDocumento"].ToString();
                ClienteGeneral.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ClienteGeneral.DescCliente = reader["descCliente"].ToString();
                ClienteGeneral.NomDist = reader["NomDist"].ToString();
                ClienteGeneral.Telefono = reader["telefono"].ToString();
                ClienteGeneral.Celular = reader["celular"].ToString();
                ClienteGeneral.OtroTelefono = reader["otroTelefono"].ToString();
                ClienteGeneral.Email = reader["email"].ToString();
                ClienteGeneral.EmailAdicional = reader["emailadicional"].ToString();
                ClienteGenerallist.Add(ClienteGeneral);
            }
            reader.Close();
            reader.Dispose();
            return ClienteGenerallist;
        }
    }
}
