using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class EmpresaDL
    {
        public EmpresaDL() { }

        public void Inserta(EmpresaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Empresa_Inserta");

            db.AddOutParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pCodEmpresa", DbType.String, pItem.CodEmpresa);
            db.AddInParameter(dbCommand, "pIdNivel", DbType.Int32, pItem.IdNivel);
            db.AddInParameter(dbCommand, "pIdRegimenTributario", DbType.Int32, pItem.IdRegimenTributario);
            db.AddInParameter(dbCommand, "pRuc", DbType.String, pItem.Ruc);
            db.AddInParameter(dbCommand, "pRazonSocial", DbType.String, pItem.RazonSocial);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pDniGerente", DbType.String, pItem.DniGerente);
            db.AddInParameter(dbCommand, "pNombreGerente", DbType.String, pItem.NombreGerente);
            db.AddInParameter(dbCommand, "pCodigoCompania", DbType.String, pItem.CodigoCompania);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(EmpresaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Empresa_Actualiza");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pCodEmpresa", DbType.String, pItem.CodEmpresa);
            db.AddInParameter(dbCommand, "pIdNivel", DbType.Int32, pItem.IdNivel);
            db.AddInParameter(dbCommand, "pIdRegimenTributario", DbType.Int32, pItem.IdRegimenTributario);
            db.AddInParameter(dbCommand, "pRuc", DbType.String, pItem.Ruc);
            db.AddInParameter(dbCommand, "pRazonSocial", DbType.String, pItem.RazonSocial);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pDniGerente", DbType.String, pItem.DniGerente);
            db.AddInParameter(dbCommand, "pNombreGerente", DbType.String, pItem.NombreGerente);
            db.AddInParameter(dbCommand, "pCodigoCompania", DbType.String, pItem.CodigoCompania);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(EmpresaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Empresa_Elimina");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public EmpresaBE Selecciona(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Empresa_Selecciona");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EmpresaBE empresa = null;
            while (reader.Read())
            {
                empresa = new EmpresaBE();
                empresa.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                empresa.CodEmpresa = reader["CodEmpresa"].ToString();
                empresa.IdNivel = Int32.Parse(reader["IdNivel"].ToString());
                empresa.DescNivel = reader["DescNivel"].ToString();
                empresa.IdRegimenTributario = Int32.Parse(reader["IdRegimenTributario"].ToString());
                empresa.RegimenTributario = reader["RegimenTributario"].ToString();
                empresa.Ruc = reader["Ruc"].ToString();
                empresa.RazonSocial = reader["RazonSocial"].ToString();
                empresa.Direccion = reader["Direccion"].ToString();
                empresa.Telefono = reader["Telefono"].ToString();
                empresa.Abreviatura = reader["Abreviatura"].ToString();
                empresa.DniGerente = reader["DniGerente"].ToString();
                empresa.NombreGerente = reader["NombreGerente"].ToString();
                empresa.CodigoCompania = reader["CodigoCompania"].ToString();
                empresa.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return empresa;
        }

        public List<EmpresaBE> SeleccionaTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Empresa_Selecciona");

            

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EmpresaBE> empresalist = new List<EmpresaBE>();
            EmpresaBE empresa;
            while (reader.Read())
            {
                empresa = new EmpresaBE();
                empresa.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                empresa.RazonSocial = reader["RazonSocial"].ToString();
                empresa.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                empresalist.Add(empresa);
            }
            reader.Close();
            reader.Dispose();
            return empresalist;
        }

        public List<EmpresaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Empresa_ListaTodosActivo");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EmpresaBE> empresalist = new List<EmpresaBE>();
            EmpresaBE empresa;
            while (reader.Read())
            {
                empresa = new EmpresaBE();
                empresa.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                empresa.CodEmpresa = reader["CodEmpresa"].ToString();
                empresa.IdNivel = Int32.Parse(reader["IdNivel"].ToString());
                empresa.DescNivel = reader["DescNivel"].ToString();
                empresa.IdRegimenTributario = Int32.Parse(reader["IdRegimenTributario"].ToString());
                empresa.RegimenTributario = reader["RegimenTributario"].ToString();
                empresa.Ruc = reader["Ruc"].ToString();
                empresa.RazonSocial = reader["RazonSocial"].ToString();
                empresa.Direccion = reader["Direccion"].ToString();
                empresa.Telefono = reader["Telefono"].ToString();
                empresa.Abreviatura = reader["Abreviatura"].ToString();
                empresa.DniGerente = reader["DniGerente"].ToString();
                empresa.NombreGerente = reader["NombreGerente"].ToString();
                empresa.CodigoCompania = reader["CodigoCompania"].ToString();
                empresa.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                empresalist.Add(empresa);
            }
            reader.Close();
            reader.Dispose();
            return empresalist;
        }

        public List<EmpresaBE> ListaCombo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Empresa_ListaCombo");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EmpresaBE> empresalist = new List<EmpresaBE>();
            EmpresaBE empresa;
            while (reader.Read())
            {
                empresa = new EmpresaBE();
                empresa.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                empresa.RazonSocial = reader["RazonSocial"].ToString();
                empresalist.Add(empresa);
            }
            reader.Close();
            reader.Dispose();
            return empresalist;
        }

        public List<EmpresaBE> ListaComboCajaEgreso()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Empresa_ListaComboCajaEgreso");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EmpresaBE> empresalist = new List<EmpresaBE>();
            EmpresaBE empresa;
            while (reader.Read())
            {
                empresa = new EmpresaBE();
                empresa.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                empresa.RazonSocial = reader["RazonSocial"].ToString();
                empresalist.Add(empresa);
            }
            reader.Close();
            reader.Dispose();
            return empresalist;
        }

        public List<EmpresaBE> ListaRUS()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Empresa_ListaRus");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EmpresaBE> empresalist = new List<EmpresaBE>();
            EmpresaBE empresa;
            while (reader.Read())
            {
                empresa = new EmpresaBE();
                empresa.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                empresa.RazonSocial = reader["RazonSocial"].ToString();
                empresalist.Add(empresa);
            }
            reader.Close();
            reader.Dispose();
            return empresalist;
        }
    }
}
