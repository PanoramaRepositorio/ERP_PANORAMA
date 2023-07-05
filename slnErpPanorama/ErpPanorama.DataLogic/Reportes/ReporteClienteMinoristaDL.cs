using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteClienteMinoristaDL
    {
        public List<ReporteClienteMinoristaBE> Listado(int IdEmpresa, int IdTipoCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptClienteMinorista");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteClienteMinoristaBE> ClienteMinoristalist = new List<ReporteClienteMinoristaBE>();
            ReporteClienteMinoristaBE ClienteMinorista;
            while (reader.Read())
            {
                ClienteMinorista = new ReporteClienteMinoristaBE();
                ClienteMinorista.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ClienteMinorista.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                ClienteMinorista.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                ClienteMinorista.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ClienteMinorista.DescCliente = reader["descCliente"].ToString();
                ClienteMinorista.IdTipoDireccion = Int32.Parse(reader["idTipoDireccion"].ToString());
                ClienteMinorista.Direccion = reader["direccion"].ToString();
                ClienteMinorista.NumDireccion = reader["numDireccion"].ToString();
                ClienteMinorista.Urbanizacion = reader["urbanizacion"].ToString();
                ClienteMinorista.IdUbigeoDom = reader["idUbigeoDom"].ToString();
                ClienteMinorista.NomDpto = reader["NomDpto"].ToString();
                ClienteMinorista.NomProv = reader["NomProv"].ToString();
                ClienteMinorista.NomDist = reader["NomDist"].ToString();
                ClienteMinorista.Telefono = reader["telefono"].ToString();
                ClienteMinorista.Celular = reader["celular"].ToString();
                ClienteMinorista.OtroTelefono = reader["otroTelefono"].ToString();
                ClienteMinorista.Email = reader["email"].ToString();
                ClienteMinorista.FechaNac = reader.IsDBNull(reader.GetOrdinal("FechaNac")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaNac"));
                ClienteMinorista.FechaAniv = reader.IsDBNull(reader.GetOrdinal("FechaAniv")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaAniv"));
                ClienteMinorista.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ClienteMinoristalist.Add(ClienteMinorista);
            }
            reader.Close();
            reader.Dispose();
            return ClienteMinoristalist;
        }
    }
}
