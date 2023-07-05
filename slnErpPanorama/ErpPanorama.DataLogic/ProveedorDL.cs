using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ProveedorDL
    {
        public ProveedorDL() { }

        public Int32 Inserta(ProveedorBE pItem)
        {
            Int32 Id = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proveedor_Inserta");

            db.AddOutParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPais", DbType.Int32, pItem.IdPais);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescProveedor", DbType.String, pItem.DescProveedor);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pDireccionTienda", DbType.String, pItem.DireccionTienda);
            db.AddInParameter(dbCommand, "pContacto", DbType.String, pItem.Contacto);
            db.AddInParameter(dbCommand, "pContactoCredito", DbType.String, pItem.ContactoCredito);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pEmail2", DbType.String, pItem.Email2);
            db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
            db.AddInParameter(dbCommand, "pCelular", DbType.String, pItem.Celular);
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdBancoDolares", DbType.Int32, pItem.IdBancoDolares);
            db.AddInParameter(dbCommand, "pCuentaBancoSoles", DbType.String, pItem.CuentaBancoSoles);
            db.AddInParameter(dbCommand, "pCuentaBancoDolares", DbType.String, pItem.CuentaBancoDolares);
            db.AddInParameter(dbCommand, "pCCISoles", DbType.String, pItem.CCISoles);
            db.AddInParameter(dbCommand, "pCCIDolares", DbType.String, pItem.CCIDolares);
            db.AddInParameter(dbCommand, "pIdProveedorReferencia", DbType.Int32, pItem.IdProveedorReferencia);
            db.AddInParameter(dbCommand, "pDiasCredito", DbType.Int32, pItem.DiasCredito);
            db.AddInParameter(dbCommand, "pBancoIntermediario", DbType.String, pItem.BancoIntermediario);
            db.AddInParameter(dbCommand, "pBancoPagador", DbType.String, pItem.BancoPagador);
            db.AddInParameter(dbCommand, "pCodigoSwiftIntermediario", DbType.String, pItem.CodigoSwiftIntermediario);
            db.AddInParameter(dbCommand, "pCodigoSwiftPagador", DbType.String, pItem.CodigoSwiftPagador);
            db.AddInParameter(dbCommand, "pDireccionIntermediario", DbType.String, pItem.DireccionIntermediario);
            db.AddInParameter(dbCommand, "pDireccionPagador", DbType.String, pItem.DireccionPagador);
            db.AddInParameter(dbCommand, "pTipoPago", DbType.Int32, pItem.TipoPago);
            db.AddInParameter(dbCommand, "pDiaSemMes", DbType.Int32, pItem.DiaSemMes);
            db.AddInParameter(dbCommand, "pFechaPago", DbType.DateTime, pItem.FechaPago);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pAcuerdos", DbType.String, pItem.Acuerdos);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.AddInParameter(dbCommand, "pProcedencia", DbType.Int32, pItem.Procedencia);
            db.AddInParameter(dbCommand, "pBeneficiarioNombre", DbType.String, pItem.BeneficiarioNombre);
            db.AddInParameter(dbCommand, "pBeneficiarioAbono", DbType.String, pItem.BeneficiarioAbono);
            db.AddInParameter(dbCommand, "pBeneficiarioDireccion", DbType.String, pItem.BeneficiarioDireccion);
            db.AddInParameter(dbCommand, "pBeneficiarioPais", DbType.String, pItem.BeneficiarioPais);

            db.AddInParameter(dbCommand, "pBancoSwift", DbType.String, pItem.BancoSwift);
            db.AddInParameter(dbCommand, "pBancoNombre", DbType.String, pItem.BancoNombre);
            db.AddInParameter(dbCommand, "pBancoDireccion", DbType.String, pItem.BancoDireccion);
            db.AddInParameter(dbCommand, "pBancoPais", DbType.String, pItem.BancoPais);
            db.AddInParameter(dbCommand, "pBancoCiudad", DbType.String, pItem.BancoCiudad);
            db.AddInParameter(dbCommand, "pPCredito", DbType.Boolean, pItem.PCredito);

            db.ExecuteNonQuery(dbCommand);

            Id = (int)db.GetParameterValue(dbCommand, "pIdProveedor");

            return Id;
        }

        public void Actualiza(ProveedorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proveedor_Actualiza");

            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPais", DbType.Int32, pItem.IdPais);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescProveedor", DbType.String, pItem.DescProveedor);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pDireccionTienda", DbType.String, pItem.DireccionTienda);
            db.AddInParameter(dbCommand, "pContacto", DbType.String, pItem.Contacto);
            db.AddInParameter(dbCommand, "pContactoCredito", DbType.String, pItem.ContactoCredito);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pEmail2", DbType.String, pItem.Email2);
            db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
            db.AddInParameter(dbCommand, "pCelular", DbType.String, pItem.Celular);
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdBancoDolares", DbType.Int32, pItem.IdBancoDolares);
            db.AddInParameter(dbCommand, "pCuentaBancoSoles", DbType.String, pItem.CuentaBancoSoles);
            db.AddInParameter(dbCommand, "pCuentaBancoDolares", DbType.String, pItem.CuentaBancoDolares);
            db.AddInParameter(dbCommand, "pCCISoles", DbType.String, pItem.CCISoles);
            db.AddInParameter(dbCommand, "pCCIDolares", DbType.String, pItem.CCIDolares);
            db.AddInParameter(dbCommand, "pIdProveedorReferencia", DbType.Int32, pItem.IdProveedorReferencia);
            db.AddInParameter(dbCommand, "pDiasCredito", DbType.Int32, pItem.DiasCredito);
            db.AddInParameter(dbCommand, "pBancoIntermediario", DbType.String, pItem.BancoIntermediario);
            db.AddInParameter(dbCommand, "pBancoPagador", DbType.String, pItem.BancoPagador);
            db.AddInParameter(dbCommand, "pCodigoSwiftIntermediario", DbType.String, pItem.CodigoSwiftIntermediario);
            db.AddInParameter(dbCommand, "pCodigoSwiftPagador", DbType.String, pItem.CodigoSwiftPagador);
            db.AddInParameter(dbCommand, "pDireccionIntermediario", DbType.String, pItem.DireccionIntermediario);
            db.AddInParameter(dbCommand, "pDireccionPagador", DbType.String, pItem.DireccionPagador);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pAcuerdos", DbType.String, pItem.Acuerdos);
            db.AddInParameter(dbCommand, "pTipoPago", DbType.Int32, pItem.TipoPago);
            db.AddInParameter(dbCommand, "pDiaSemMes", DbType.Int32, pItem.DiaSemMes);
            db.AddInParameter(dbCommand, "pFechaPago", DbType.DateTime, pItem.FechaPago);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.AddInParameter(dbCommand, "pProcedencia", DbType.Int32, pItem.Procedencia);
            db.AddInParameter(dbCommand, "pBeneficiarioNombre", DbType.String, pItem.BeneficiarioNombre);
            db.AddInParameter(dbCommand, "pBeneficiarioAbono", DbType.String, pItem.BeneficiarioAbono);
            db.AddInParameter(dbCommand, "pBeneficiarioDireccion", DbType.String, pItem.BeneficiarioDireccion);
            db.AddInParameter(dbCommand, "pBeneficiarioPais", DbType.String, pItem.BeneficiarioPais);

            db.AddInParameter(dbCommand, "pBancoSwift", DbType.String, pItem.BancoSwift);
            db.AddInParameter(dbCommand, "pBancoNombre", DbType.String, pItem.BancoNombre);
            db.AddInParameter(dbCommand, "pBancoDireccion", DbType.String, pItem.BancoDireccion);
            db.AddInParameter(dbCommand, "pBancoPais", DbType.String, pItem.BancoPais);
            db.AddInParameter(dbCommand, "pBancoCiudad", DbType.String, pItem.BancoCiudad);
            db.AddInParameter(dbCommand, "pPCredito", DbType.Boolean, pItem.PCredito);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ProveedorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proveedor_Elimina");

            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ProveedorBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proveedor_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProveedorBE> Proveedorlist = new List<ProveedorBE>();
            ProveedorBE Proveedor;
            while (reader.Read())
            {
                Proveedor = new ProveedorBE();
                Proveedor.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Proveedor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Proveedor.IdPais = Int32.Parse(reader["IdPais"].ToString());
                Proveedor.DescPais = reader["DescPais"].ToString();
                Proveedor.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Proveedor.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Proveedor.DescProveedor = reader["DescProveedor"].ToString();
                Proveedor.Direccion = reader["Direccion"].ToString();
                Proveedor.DireccionTienda = reader["DireccionTienda"].ToString();
                Proveedor.Contacto = reader["Contacto"].ToString();
                Proveedor.ContactoCredito = reader["ContactoCredito"].ToString();
                Proveedor.Email = reader["Email"].ToString();
                Proveedor.Email2 = reader["Email2"].ToString();
                Proveedor.Telefono = reader["Telefono"].ToString();
                Proveedor.Celular = reader["Celular"].ToString();
                Proveedor.IdBanco = reader.IsDBNull(reader.GetOrdinal("IdBanco")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdBanco"));
                Proveedor.IdBancoDolares = reader.IsDBNull(reader.GetOrdinal("IdBancoDolares")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdBancoDolares"));
                Proveedor.CuentaBancoSoles = reader["CuentaBancoSoles"].ToString();
                Proveedor.CuentaBancoDolares = reader["CuentaBancoDolares"].ToString();
                Proveedor.CCISoles = reader["CCISoles"].ToString();
                Proveedor.CCIDolares = reader["CCIDolares"].ToString();
                Proveedor.IdProveedorReferencia = Int32.Parse(reader["IdProveedorReferencia"].ToString());
                Proveedor.DiasCredito = Int32.Parse(reader["DiasCredito"].ToString());
                Proveedor.BancoIntermediario = reader["BancoIntermediario"].ToString();
                Proveedor.BancoPagador = reader["BancoPagador"].ToString();
                Proveedor.CodigoSwiftIntermediario = reader["CodigoSwiftIntermediario"].ToString();
                Proveedor.CodigoSwiftPagador = reader["CodigoSwiftPagador"].ToString();
                Proveedor.DireccionIntermediario = reader["DireccionIntermediario"].ToString();
                Proveedor.DireccionPagador = reader["DireccionPagador"].ToString();
                Proveedor.Observacion = reader["Observacion"].ToString();
                Proveedor.TipoPago = Int32.Parse(reader["TipoPago"].ToString());
                Proveedor.DescTipoPago = reader["DescTipoPago"].ToString();
                Proveedor.DiaSemMes = Int32.Parse(reader["DiaSemMes"].ToString());
                Proveedor.NomDiaSemMes = Int32.Parse(reader["TipoPago"].ToString())==7? reader["NomDiaSemMes"].ToString(): reader["DiaSemMes"].ToString().Replace("0","");
                Proveedor.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                Proveedor.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                Proveedor.PCredito = Boolean.Parse(reader["PCredito"].ToString());
                Proveedorlist.Add(Proveedor);
            }
            reader.Close();
            reader.Dispose();
            return Proveedorlist;
        }

        public List<ProveedorBE> ListaTodosActivoNacional(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proveedor_ListaTodosActivoNacional");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProveedorBE> Proveedorlist = new List<ProveedorBE>();
            ProveedorBE Proveedor;
            while (reader.Read())
            {
                Proveedor = new ProveedorBE();
                Proveedor.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Proveedor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Proveedor.IdPais = Int32.Parse(reader["IdPais"].ToString());
                Proveedor.DescPais = reader["DescPais"].ToString();
                Proveedor.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Proveedor.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Proveedor.DescProveedor = reader["DescProveedor"].ToString();
                Proveedor.Direccion = reader["Direccion"].ToString();
                Proveedor.DireccionTienda = reader["DireccionTienda"].ToString();
                Proveedor.Contacto = reader["Contacto"].ToString();
                Proveedor.ContactoCredito = reader["ContactoCredito"].ToString();
                Proveedor.Email = reader["Email"].ToString();
                Proveedor.Email2 = reader["Email2"].ToString();
                Proveedor.Telefono = reader["Telefono"].ToString();
                Proveedor.Celular = reader["Celular"].ToString();
                Proveedor.IdBanco = reader.IsDBNull(reader.GetOrdinal("IdBanco")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdBanco"));
                Proveedor.IdBancoDolares = reader.IsDBNull(reader.GetOrdinal("IdBancoDolares")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdBancoDolares"));
                Proveedor.CuentaBancoSoles = reader["CuentaBancoSoles"].ToString();
                Proveedor.CuentaBancoDolares = reader["CuentaBancoDolares"].ToString();
                Proveedor.CCISoles = reader["CCISoles"].ToString();
                Proveedor.CCIDolares = reader["CCIDolares"].ToString();
                Proveedor.IdProveedorReferencia = Int32.Parse(reader["IdProveedorReferencia"].ToString());
                Proveedor.DiasCredito = Int32.Parse(reader["DiasCredito"].ToString());
                Proveedor.BancoIntermediario = reader["BancoIntermediario"].ToString();
                Proveedor.BancoPagador = reader["BancoPagador"].ToString();
                Proveedor.CodigoSwiftIntermediario = reader["CodigoSwiftIntermediario"].ToString();
                Proveedor.CodigoSwiftPagador = reader["CodigoSwiftPagador"].ToString();
                Proveedor.DireccionIntermediario = reader["DireccionIntermediario"].ToString();
                Proveedor.DireccionPagador = reader["DireccionPagador"].ToString();
                Proveedor.Observacion = reader["Observacion"].ToString();
                Proveedor.TipoPago = Int32.Parse(reader["TipoPago"].ToString());
                Proveedor.DescTipoPago = reader["DescTipoPago"].ToString();
                Proveedor.DiaSemMes = Int32.Parse(reader["DiaSemMes"].ToString());
                Proveedor.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                Proveedor.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                Proveedorlist.Add(Proveedor);
            }
            reader.Close();
            reader.Dispose();
            return Proveedorlist;
        }

        public ProveedorBE SeleccionaNumero(string NumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proveedor_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProveedorBE Proveedor = null;
            while (reader.Read())
            {
                Proveedor = new ProveedorBE();
                Proveedor.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Proveedor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Proveedor.IdPais = Int32.Parse(reader["IdPais"].ToString());
                Proveedor.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Proveedor.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Proveedor.DescProveedor = reader["DescProveedor"].ToString();
                Proveedor.Direccion = reader["Direccion"].ToString();
                Proveedor.DireccionTienda = reader["DireccionTienda"].ToString();
                Proveedor.Contacto = reader["Contacto"].ToString();
                Proveedor.ContactoCredito = reader["ContactoCredito"].ToString();
                Proveedor.Email = reader["Email"].ToString();
                Proveedor.Email2 = reader["Email2"].ToString();
                Proveedor.Telefono = reader["Telefono"].ToString();
                Proveedor.Celular = reader["Celular"].ToString();
                Proveedor.IdBanco = Int32.Parse(reader["IdBanco"].ToString());
                Proveedor.IdBancoDolares = Int32.Parse(reader["IdBancoDolares"].ToString());
                Proveedor.CuentaBancoSoles = reader["CuentaBancoSoles"].ToString();
                Proveedor.CuentaBancoDolares = reader["CuentaBancoDolares"].ToString();
                Proveedor.CCISoles = reader["CCISoles"].ToString();
                Proveedor.CCIDolares = reader["CCIDolares"].ToString();
                Proveedor.IdProveedorReferencia = Int32.Parse(reader["IdProveedorReferencia"].ToString());
                Proveedor.DiasCredito = Int32.Parse(reader["DiasCredito"].ToString());
                Proveedor.BancoIntermediario = reader["BancoIntermediario"].ToString();
                Proveedor.BancoPagador = reader["BancoPagador"].ToString();
                Proveedor.CodigoSwiftIntermediario = reader["CodigoSwiftIntermediario"].ToString();
                Proveedor.CodigoSwiftPagador = reader["CodigoSwiftPagador"].ToString();
                Proveedor.DireccionIntermediario = reader["DireccionIntermediario"].ToString();
                Proveedor.DireccionPagador = reader["DireccionPagador"].ToString();
                Proveedor.Observacion = reader["Observacion"].ToString();
                Proveedor.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                Proveedor.Procedencia = Int32.Parse(reader["Procedencia"].ToString());
                Proveedor.PCredito = Boolean.Parse(reader["PCredito"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Proveedor;
        }

        public ProveedorBE Selecciona(Int32 IdProveedor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proveedor_Selecciona");
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, IdProveedor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProveedorBE Proveedor = null;
            while (reader.Read())
            {
                Proveedor = new ProveedorBE();
                Proveedor.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Proveedor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Proveedor.IdPais = Int32.Parse(reader["IdPais"].ToString());
                Proveedor.DescPais = reader["DescPais"].ToString();
                Proveedor.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Proveedor.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Proveedor.DescProveedor = reader["DescProveedor"].ToString();
                Proveedor.Direccion = reader["Direccion"].ToString();
                Proveedor.DireccionTienda = reader["DireccionTienda"].ToString();
                Proveedor.Contacto = reader["Contacto"].ToString();
                Proveedor.ContactoCredito = reader["ContactoCredito"].ToString();
                Proveedor.Email = reader["Email"].ToString();
                Proveedor.Email2 = reader["Email2"].ToString();
                Proveedor.Telefono = reader["Telefono"].ToString();
                Proveedor.Celular = reader["Celular"].ToString();
                Proveedor.IdBanco = reader.IsDBNull(reader.GetOrdinal("IdBanco")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdBanco"));
                Proveedor.IdBancoDolares = reader.IsDBNull(reader.GetOrdinal("IdBancoDolares")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdBancoDolares"));
                Proveedor.CuentaBancoSoles = reader["CuentaBancoSoles"].ToString();
                Proveedor.CuentaBancoDolares = reader["CuentaBancoDolares"].ToString();
                Proveedor.CCISoles = reader["CCISoles"].ToString();
                Proveedor.CCIDolares = reader["CCIDolares"].ToString();
                Proveedor.IdProveedorReferencia = Int32.Parse(reader["IdProveedorReferencia"].ToString());
                Proveedor.DiasCredito = Int32.Parse(reader["DiasCredito"].ToString());
                Proveedor.BancoIntermediario = reader["BancoIntermediario"].ToString();
                Proveedor.BancoPagador = reader["BancoPagador"].ToString();
                Proveedor.CodigoSwiftIntermediario = reader["CodigoSwiftIntermediario"].ToString();
                Proveedor.CodigoSwiftPagador = reader["CodigoSwiftPagador"].ToString();
                Proveedor.DireccionIntermediario = reader["DireccionIntermediario"].ToString();
                Proveedor.DireccionPagador = reader["DireccionPagador"].ToString();
                Proveedor.Observacion = reader["Observacion"].ToString();
                Proveedor.Acuerdos = reader["Acuerdos"].ToString();
                Proveedor.TipoPago = Int32.Parse(reader["TipoPago"].ToString());
                Proveedor.DescTipoPago = reader["DescTipoPago"].ToString();
                Proveedor.DiaSemMes = Int32.Parse(reader["DiaSemMes"].ToString());
                Proveedor.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                Proveedor.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

                Proveedor.Procedencia = Int32.Parse(reader["Procedencia"].ToString());
                Proveedor.BeneficiarioNombre = reader["BenefNombre"].ToString();
                Proveedor.BeneficiarioAbono = reader["BenefAbono"].ToString();
                Proveedor.BeneficiarioDireccion = reader["BenefDireccion"].ToString();
                Proveedor.BeneficiarioPais = reader["BenefPais"].ToString();

                Proveedor.BancoSwift = reader["BancoSwift"].ToString();
                Proveedor.BancoNombre = reader["BancoNombre"].ToString();
                Proveedor.BancoDireccion = reader["BancoDireccion"].ToString();
                Proveedor.BancoPais = reader["BancoPais"].ToString();
                Proveedor.BancoCiudad = reader["BancoCiudad"].ToString();
                Proveedor.PCredito = Boolean.Parse(reader["PCredito"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Proveedor;
        }

        public List<ProveedorBE> SeleccionaBusqueda(int IdEmpresa, int IdTipoCliente, string pFiltro, int Pagina, int CantidadRegistro, int TipoBusqueda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proveedor_SeleccionaBus");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);
            db.AddInParameter(dbCommand, "pTipoBusqueda", DbType.String, TipoBusqueda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProveedorBE> Proveedorlist = new List<ProveedorBE>();
            ProveedorBE Proveedor;
            while (reader.Read())
            {
                Proveedor = new ProveedorBE();
                Proveedor.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Proveedor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                //Proveedor.IdPais = Int32.Parse(reader["IdPais"].ToString());
                //Proveedor.DescPais = reader["DescPais"].ToString();
                //Proveedor.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Proveedor.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Proveedor.DescProveedor = reader["DescProveedor"].ToString();
                Proveedor.Direccion = reader["Direccion"].ToString();
                Proveedor.DireccionTienda = reader["DireccionTienda"].ToString();
                Proveedor.Contacto = reader["Contacto"].ToString();
                Proveedor.ContactoCredito = reader["ContactoCredito"].ToString();
                Proveedor.Email = reader["Email"].ToString();
                Proveedor.Email2 = reader["Email2"].ToString();
                Proveedor.Procedencia = Int32.Parse(reader["Procedencia"].ToString());
                Proveedor.PCredito = Boolean.Parse(reader["PCredito"].ToString());

                Proveedorlist.Add(Proveedor);
            }
            reader.Close();
            reader.Dispose();
            return Proveedorlist;
        }

        //public List<ProveedorBE> SeleccionaBusquedaEgresos(int IdCajaEgreso, int IdCajaEgresoDetalle)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_Proveedor_SeleccionaBus");
        //    db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
        //    db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
        //    db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
        //    db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);
        //    db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);
        //    db.AddInParameter(dbCommand, "pTipoBusqueda", DbType.String, TipoBusqueda);

        //    IDataReader reader = db.ExecuteReader(dbCommand);
        //    List<ProveedorBE> Proveedorlist = new List<ProveedorBE>();
        //    ProveedorBE Proveedor;
        //    while (reader.Read())
        //    {
        //        Proveedor = new ProveedorBE();
        //        Proveedor.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
        //        Proveedor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
        //        Proveedor.NumeroDocumento = reader["NumeroDocumento"].ToString();
        //        Proveedor.DescProveedor = reader["DescProveedor"].ToString();
        //        Proveedor.Direccion = reader["Direccion"].ToString();
        //        Proveedor.DireccionTienda = reader["DireccionTienda"].ToString();
        //        Proveedor.Contacto = reader["Contacto"].ToString();
        //        Proveedor.ContactoCredito = reader["ContactoCredito"].ToString();
        //        Proveedor.Email = reader["Email"].ToString();
        //        Proveedor.Email2 = reader["Email2"].ToString();
        //        Proveedorlist.Add(Proveedor);
        //    }
        //    reader.Close();
        //    reader.Dispose();
        //    return Proveedorlist;
        //}

    }
}

