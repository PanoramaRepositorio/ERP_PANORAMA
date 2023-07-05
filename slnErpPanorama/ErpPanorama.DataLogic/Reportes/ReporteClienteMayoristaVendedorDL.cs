using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteClienteMayoristaVendedorDL
    {
  public List<ReporteClienteMayoristaVendedorBE> Listado(int IdEmpresa, int IdVendedor,int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptClienteMayoristaVendedor");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteClienteMayoristaVendedorBE> ClienteGenerallist = new List<ReporteClienteMayoristaVendedorBE>();
            ReporteClienteMayoristaVendedorBE ClienteGeneral;
            while (reader.Read())
            {
                ClienteGeneral = new ReporteClienteMayoristaVendedorBE();
                ClienteGeneral.DescCliente = reader["descCliente"].ToString();
                ClienteGeneral.Direccion = reader["direccion"].ToString();
                ClienteGeneral.NomDpto = reader["NomDpto"].ToString();
                ClienteGeneral.NomProv = reader["NomProv"].ToString();
                ClienteGeneral.NomDist = reader["NomDist"].ToString();
                ClienteGeneral.Telefono = reader["telefono"].ToString();
                ClienteGeneral.Celular = reader["celular"].ToString();
                ClienteGeneral.OtroTelefono = reader["otroTelefono"].ToString();
                ClienteGeneral.Email = reader["Email"].ToString();
                ClienteGeneral.IdRuta = Int32.Parse(reader["IdRuta"].ToString());
                ClienteGeneral.DescRuta = reader["DescRuta"].ToString();
                ClienteGeneral.Categoria = reader["Categoria"].ToString();
                ClienteGenerallist.Add(ClienteGeneral);
            }
            reader.Close();
            reader.Dispose();
            return ClienteGenerallist;
        }

  public List<ReporteClienteMayoristaVendedorBE> ListadoAsociado(int IdEmpresa, int IdVendedor, int IdSituacion, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptClienteMayoristaVendedorAsociado");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteClienteMayoristaVendedorBE> ClienteGenerallist = new List<ReporteClienteMayoristaVendedorBE>();
            ReporteClienteMayoristaVendedorBE ClienteGeneral;
            while (reader.Read())
            {
                ClienteGeneral = new ReporteClienteMayoristaVendedorBE();
                ClienteGeneral.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                ClienteGeneral.Tipo = reader["Tipo"].ToString();
                ClienteGeneral.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ClienteGeneral.DescCliente = reader["descCliente"].ToString();
                ClienteGeneral.Direccion = reader["direccion"].ToString();
                ClienteGeneral.NomDpto = reader["NomDpto"].ToString();
                ClienteGeneral.NomProv = reader["NomProv"].ToString();
                ClienteGeneral.NomDist = reader["NomDist"].ToString();
                ClienteGeneral.Telefono = reader["telefono"].ToString();
                ClienteGeneral.Celular = reader["celular"].ToString();
                ClienteGeneral.OtroTelefono = reader["otroTelefono"].ToString();
                ClienteGeneral.Email = reader["Email"].ToString();
                ClienteGeneral.IdRuta = Int32.Parse(reader["IdRuta"].ToString());
                ClienteGeneral.DescRuta = reader["DescRuta"].ToString();
                ClienteGeneral.Categoria = reader["Categoria"].ToString();
                ClienteGeneral.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ClienteGeneral.FechaAniv = DateTime.Parse(reader["FechaAniv"].ToString());
                ClienteGeneral.FechaNac = DateTime.Parse(reader["FechaNac"].ToString());
                ClienteGeneral.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());

                //ClienteGeneral.Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Fecha"));
                //ClienteGeneral.FechaAniv = reader.IsDBNull(reader.GetOrdinal("FechaAniv")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaAniv"));
                //ClienteGeneral.FechaNac = reader.IsDBNull(reader.GetOrdinal("FechaNac")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaNac"));
                //ClienteGeneral.FechaCompra = reader.IsDBNull(reader.GetOrdinal("FechaCompra")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCompra"));
                ClienteGeneral.TotalSoles = Decimal.Parse(reader["TotalSoles"].ToString());
                ClienteGenerallist.Add(ClienteGeneral);
            }
            reader.Close();
            reader.Dispose();
            return ClienteGenerallist;
        }

  public List<ReporteClienteMayoristaVendedorBE> ListadoCompra(int IdEmpresa, int IdVendedor, int IdSituacion, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptClienteMayoristaVendedorCompra");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteClienteMayoristaVendedorBE> ClienteGenerallist = new List<ReporteClienteMayoristaVendedorBE>();
            ReporteClienteMayoristaVendedorBE ClienteGeneral;
            while (reader.Read())
            {
                ClienteGeneral = new ReporteClienteMayoristaVendedorBE();
                ClienteGeneral.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                ClienteGeneral.Tipo = reader["Tipo"].ToString();
                ClienteGeneral.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ClienteGeneral.DescCliente = reader["descCliente"].ToString();
                ClienteGeneral.Direccion = reader["direccion"].ToString();
                ClienteGeneral.NomDpto = reader["NomDpto"].ToString();
                ClienteGeneral.NomProv = reader["NomProv"].ToString();
                ClienteGeneral.NomDist = reader["NomDist"].ToString();
                ClienteGeneral.Telefono = reader["telefono"].ToString();
                ClienteGeneral.Celular = reader["celular"].ToString();
                ClienteGeneral.OtroTelefono = reader["otroTelefono"].ToString();
                ClienteGeneral.Email = reader["Email"].ToString();
                ClienteGeneral.IdRuta = Int32.Parse(reader["IdRuta"].ToString());
                ClienteGeneral.DescRuta = reader["DescRuta"].ToString();
                ClienteGeneral.Categoria = reader["Categoria"].ToString();
                ClienteGeneral.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ClienteGeneral.FechaAniv = DateTime.Parse(reader["FechaAniv"].ToString());
                ClienteGeneral.FechaNac = DateTime.Parse(reader["FechaNac"].ToString());
                ClienteGeneral.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());

                //ClienteGeneral.Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Fecha"));
                //ClienteGeneral.FechaAniv = reader.IsDBNull(reader.GetOrdinal("FechaAniv")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaAniv"));
                //ClienteGeneral.FechaNac = reader.IsDBNull(reader.GetOrdinal("FechaNac")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaNac"));
                //ClienteGeneral.FechaCompra = reader.IsDBNull(reader.GetOrdinal("FechaCompra")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCompra"));
                ClienteGeneral.TotalSoles = Decimal.Parse(reader["TotalSoles"].ToString());
                ClienteGenerallist.Add(ClienteGeneral);
            }
            reader.Close();
            reader.Dispose();
            return ClienteGenerallist;
        }     

    }
}
