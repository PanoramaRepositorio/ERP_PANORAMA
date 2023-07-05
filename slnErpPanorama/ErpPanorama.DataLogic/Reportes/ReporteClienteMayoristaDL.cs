using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteClienteMayoristaDL
    {
        public List<ReporteClienteMayoristaBE> Listado(int IdEmpresa, int IdTipoCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptClienteMayorista");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteClienteMayoristaBE> ClienteMayoristalist = new List<ReporteClienteMayoristaBE>();
            ReporteClienteMayoristaBE ClienteMayorista;
            while (reader.Read())
            {
                ClienteMayorista = new ReporteClienteMayoristaBE();
                ClienteMayorista.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ClienteMayorista.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                ClienteMayorista.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                ClienteMayorista.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ClienteMayorista.DescCliente = reader["descCliente"].ToString();
                ClienteMayorista.IdTipoDireccion = Int32.Parse(reader["idTipoDireccion"].ToString());
                ClienteMayorista.Direccion = reader["direccion"].ToString();
                ClienteMayorista.NumDireccion = reader["numDireccion"].ToString();
                ClienteMayorista.Urbanizacion = reader["urbanizacion"].ToString();
                ClienteMayorista.IdUbigeoDom = reader["idUbigeoDom"].ToString();
                ClienteMayorista.NomDpto = reader["NomDpto"].ToString();
                ClienteMayorista.NomProv = reader["NomProv"].ToString();
                ClienteMayorista.NomDist = reader["NomDist"].ToString();
                ClienteMayorista.Telefono = reader["telefono"].ToString();
                ClienteMayorista.Celular = reader["celular"].ToString();
                ClienteMayorista.OtroTelefono = reader["otroTelefono"].ToString();
                ClienteMayorista.Email = reader["email"].ToString();
                ClienteMayorista.FechaNac = reader.IsDBNull(reader.GetOrdinal("FechaNac")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaNac"));
                ClienteMayorista.FechaAniv = reader.IsDBNull(reader.GetOrdinal("FechaAniv")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaAniv"));
                ClienteMayorista.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ClienteMayoristalist.Add(ClienteMayorista);
            }
            reader.Close();
            reader.Dispose();
            return ClienteMayoristalist;
        }
    }
}