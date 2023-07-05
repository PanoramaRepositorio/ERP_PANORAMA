using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteEmpresaDL
    {
        public List<ReporteEmpresaBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEmpresa");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEmpresaBE> Empresalist = new List<ReporteEmpresaBE>();
            ReporteEmpresaBE Empresa;
            while (reader.Read())
            {
                Empresa = new ReporteEmpresaBE();
                Empresa.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Empresa.CodEmpresa = reader["codEmpresa"].ToString();
                Empresa.IdNivel = Int32.Parse(reader["IdNivel"].ToString());
                Empresa.DescNivel = reader["DescNivel"].ToString();
                Empresa.IdRegimenTributario = Int32.Parse(reader["IdRegimenTributario"].ToString());
                Empresa.RegimenTributario = reader["RegimenTributario"].ToString();
                Empresa.Ruc = reader["Ruc"].ToString();
                Empresa.RazonSocial = reader["RazonSocial"].ToString();
                Empresa.Direccion = reader["Direccion"].ToString();
                Empresa.Telefono = reader["Telefono"].ToString();
                Empresa.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                Empresalist.Add(Empresa);
            }
            reader.Close();
            reader.Dispose();
            return Empresalist;
        }
    }
}
