using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class CuentaBancoDL
    {
        public CuentaBancoDL() { }

        public void Inserta(CuentaBancoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBanco_Inserta");

            db.AddInParameter(dbCommand, "pIdCuentaBanco", DbType.Int32, pItem.IdCuentaBanco);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pNumeroCuenta", DbType.String, pItem.NumeroCuenta);
            db.AddInParameter(dbCommand, "pIdTipoCuenta", DbType.Int32, pItem.IdTipoCuenta);
            db.AddInParameter(dbCommand, "pTitular", DbType.String, pItem.Titular);
            db.AddInParameter(dbCommand, "pSaldoDisponible", DbType.Decimal, pItem.SaldoDisponible);
            db.AddInParameter(dbCommand, "pOficina", DbType.String, pItem.Oficina);
            db.AddInParameter(dbCommand, "pCCI", DbType.String, pItem.CCI);
            db.AddInParameter(dbCommand, "pLineaCredito", DbType.Decimal, pItem.LineaCredito);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(CuentaBancoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBanco_Actualiza");

            db.AddInParameter(dbCommand, "pIdCuentaBanco", DbType.Int32, pItem.IdCuentaBanco);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pNumeroCuenta", DbType.String, pItem.NumeroCuenta);
            db.AddInParameter(dbCommand, "pIdTipoCuenta", DbType.Int32, pItem.IdTipoCuenta);
            db.AddInParameter(dbCommand, "pTitular", DbType.String, pItem.Titular);
            db.AddInParameter(dbCommand, "pSaldoDisponible", DbType.Decimal, pItem.SaldoDisponible);
            db.AddInParameter(dbCommand, "pOficina", DbType.String, pItem.Oficina);
            db.AddInParameter(dbCommand, "pCCI", DbType.String, pItem.CCI);
            db.AddInParameter(dbCommand, "pLineaCredito", DbType.Decimal, pItem.LineaCredito);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(CuentaBancoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBanco_Elimina");

            db.AddInParameter(dbCommand, "pIdCuentaBanco", DbType.Int32, pItem.IdCuentaBanco);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public CuentaBancoBE Selecciona(int IdCuentaBanco)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBanco_Selecciona");
            db.AddInParameter(dbCommand, "pIdCuentaBanco", DbType.Int32, IdCuentaBanco);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            CuentaBancoBE CuentaBanco = null;
            while (reader.Read())
            {
                CuentaBanco = new CuentaBancoBE();
                CuentaBanco.IdCuentaBanco = Int32.Parse(reader["idCuentaBanco"].ToString());
                CuentaBanco.IdBanco = Int32.Parse(reader["idBanco"].ToString());
                CuentaBanco.DescBanco = reader["descBanco"].ToString();
                CuentaBanco.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                CuentaBanco.CodMoneda = reader["CodMoneda"].ToString();
                CuentaBanco.NumeroCuenta = reader["NumeroCuenta"].ToString();
                CuentaBanco.IdTipoCuenta = Int32.Parse(reader["IdTipoCuenta"].ToString());
                CuentaBanco.DescTipoCuenta = reader["DescTipoCuenta"].ToString();
                CuentaBanco.Titular = reader["Titular"].ToString();
                CuentaBanco.SaldoDisponible = Decimal.Parse(reader["SaldoDisponible"].ToString());
                CuentaBanco.Oficina = reader["Oficina"].ToString();
                CuentaBanco.CCI = reader["CCI"].ToString();
                CuentaBanco.LineaCredito = Decimal.Parse(reader["LineaCredito"].ToString());
                CuentaBanco.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return CuentaBanco;
        }

        public List<CuentaBancoBE> ListaTodosActivo(int IdBanco)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBanco_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, IdBanco);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CuentaBancoBE> CuentaBancolist = new List<CuentaBancoBE>();
            CuentaBancoBE CuentaBanco;
            while (reader.Read())
            {
                CuentaBanco = new CuentaBancoBE();
                CuentaBanco.IdCuentaBanco = Int32.Parse(reader["IdCuentaBanco"].ToString());
                CuentaBanco.IdBanco = Int32.Parse(reader["IdBanco"].ToString());
                CuentaBanco.DescBanco = reader["descBanco"].ToString();
                CuentaBanco.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                CuentaBanco.CodMoneda = reader["CodMoneda"].ToString();
                CuentaBanco.NumeroCuenta = reader["NumeroCuenta"].ToString();
                CuentaBanco.IdTipoCuenta = Int32.Parse(reader["IdTipoCuenta"].ToString());
                CuentaBanco.DescTipoCuenta = reader["DescTipoCuenta"].ToString();
                CuentaBanco.Titular = reader["Titular"].ToString();
                CuentaBanco.SaldoDisponible = Decimal.Parse(reader["SaldoDisponible"].ToString());
                CuentaBanco.Oficina = reader["Oficina"].ToString();
                CuentaBanco.CCI = reader["CCI"].ToString();
                CuentaBanco.LineaCredito = Decimal.Parse(reader["LineaCredito"].ToString());
                //CuentaBanco.FechaUltimoRegistro = DateTime.Parse(reader["FechaUltimoRegistro"].ToString());
                CuentaBanco.FechaUltimoRegistro = reader.IsDBNull(reader.GetOrdinal("FechaUltimoRegistro")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaUltimoRegistro"));
                CuentaBanco.Abreviatura = reader["Abreviatura"].ToString();
                CuentaBanco.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                CuentaBancolist.Add(CuentaBanco);
            }
            reader.Close();
            reader.Dispose();
            return CuentaBancolist;
        }

        public List<CuentaBancoBE> Lista(int IdBanco)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBanco_Lista");
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, IdBanco);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CuentaBancoBE> CuentaBancolist = new List<CuentaBancoBE>();
            CuentaBancoBE CuentaBanco;
            while (reader.Read())
            {
                CuentaBanco = new CuentaBancoBE();
                CuentaBanco.IdCuentaBanco = Int32.Parse(reader["IdCuentaBanco"].ToString());
                CuentaBanco.IdBanco = Int32.Parse(reader["IdBanco"].ToString());
                CuentaBanco.DescBanco = reader["descBanco"].ToString();
                CuentaBanco.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                CuentaBanco.CodMoneda = reader["CodMoneda"].ToString();
                CuentaBanco.NumeroCuenta = reader["NumeroCuenta"].ToString();
                CuentaBanco.IdTipoCuenta = Int32.Parse(reader["IdTipoCuenta"].ToString());
                CuentaBanco.DescTipoCuenta = reader["DescTipoCuenta"].ToString();
                CuentaBanco.Titular = reader["Titular"].ToString();
                CuentaBanco.Oficina = reader["Oficina"].ToString();
                CuentaBanco.CCI = reader["CCI"].ToString();
                CuentaBanco.LineaCredito = Decimal.Parse(reader["LineaCredito"].ToString());
                CuentaBanco.Abreviatura = reader["Abreviatura"].ToString();
                CuentaBanco.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                CuentaBancolist.Add(CuentaBanco);
            }
            reader.Close();
            reader.Dispose();
            return CuentaBancolist;
        }

        public List<CuentaBancoBE> ListaTodosActivoProveedor(int IdProveedor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBanco_ListaTodosActivoProveedor");
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, IdProveedor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CuentaBancoBE> CuentaBancolist = new List<CuentaBancoBE>();
            CuentaBancoBE CuentaBanco;
            while (reader.Read())
            {
                CuentaBanco = new CuentaBancoBE();
                CuentaBanco.IdCuentaBancoProveedor = Int32.Parse(reader["IdCuentaBancoProveedor"].ToString());
                CuentaBanco.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());

                CuentaBanco.IdBanco = Int32.Parse(reader["IdBanco"].ToString());
                CuentaBanco.DescBanco = reader["DescBanco"].ToString();

                CuentaBanco.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                CuentaBanco.DescMoneda = reader["DescMoneda"].ToString();

                CuentaBanco.NumeroCuenta = reader["Cuenta"].ToString();
                CuentaBanco.CCI = reader["cci"].ToString();
                CuentaBanco.IdTipoCuenta = Int32.Parse(reader["IdTipoCuenta"].ToString());
                CuentaBanco.DescTipoCuenta = reader["DescTipoCuenta"].ToString();
                CuentaBanco.TipoOper = 4; //  Consultar
                //                CuentaBanco.FechaUltimoRegistro = reader.IsDBNull(reader.GetOrdinal("FechaUltimoRegistro")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaUltimoRegistro"));
                CuentaBancolist.Add(CuentaBanco);
            }
            reader.Close();
            reader.Dispose();
            return CuentaBancolist;
        }

        public void InsertaCuentaBancoProveedor(CuentaBancoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoProveedor_Inserta");

            db.AddInParameter(dbCommand, "pIdCuentaBancoProveedor", DbType.Int32, pItem.IdCuentaBancoProveedor);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pCuenta", DbType.String, pItem.NumeroCuenta);
            db.AddInParameter(dbCommand, "pcci", DbType.String, pItem.CCI);
            db.AddInParameter(dbCommand, "pIdTipoCuenta", DbType.Int32, pItem.IdTipoCuenta);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCuentaBancoProveedor(CuentaBancoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoProveedor_Actualiza");

            db.AddInParameter(dbCommand, "pIdCuentaBancoProveedor", DbType.Int32, pItem.IdCuentaBancoProveedor);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pCuenta", DbType.String, pItem.NumeroCuenta);
            db.AddInParameter(dbCommand, "pcci", DbType.String, pItem.CCI);
            db.AddInParameter(dbCommand, "pIdTipoCuenta", DbType.Int32, pItem.IdTipoCuenta);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina_CuentaBancoProvee(CuentaBancoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoProveedor_Elimina");

            db.AddInParameter(dbCommand, "pIdCuentaBancoProveedor", DbType.Int32, pItem.IdCuentaBancoProveedor);
            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<CuentaBancoBE> ListaTodosCuentaBancoProveedor(int IdProveedor, int IdMoneda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoProveedor_ListaTodos");
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, IdProveedor);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, IdMoneda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CuentaBancoBE> CuentaBancolist = new List<CuentaBancoBE>();
            CuentaBancoBE CuentaBanco;
            while (reader.Read())
            {
                CuentaBanco = new CuentaBancoBE();
                CuentaBanco.IdCuentaBancoProveedor = Int32.Parse(reader["IdCuentaBancoProveedor"].ToString());
                CuentaBanco.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());

                CuentaBanco.IdBanco = Int32.Parse(reader["IdBanco"].ToString());
                CuentaBanco.DescBanco = reader["DescBanco"].ToString();

                CuentaBanco.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                CuentaBanco.DescMoneda = reader["DescMoneda"].ToString();

                CuentaBanco.NumeroCuenta = reader["Cuenta"].ToString();
                CuentaBanco.CCI = reader["cci"].ToString();
                CuentaBanco.IdTipoCuenta = Int32.Parse(reader["IdTipoCuenta"].ToString());
                CuentaBanco.DescTipoCuenta = reader["DescTipoCuenta"].ToString();
                CuentaBancolist.Add(CuentaBanco);
            }
            reader.Close();
            reader.Dispose();
            return CuentaBancolist;
        }

        public CuentaBancoBE Selecciona_CuentaBancoProveedor(int IdCuentaBancoProveedor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoProveedor_IdCuentaBancoProv");
            db.AddInParameter(dbCommand, "pIdCuentaBancoProveedor", DbType.Int32, IdCuentaBancoProveedor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CuentaBancoBE CuentaBanco = null;
            while (reader.Read())
            {
                CuentaBanco = new CuentaBancoBE();
                CuentaBanco.IdCuentaBancoProveedor = Int32.Parse(reader["IdCuentaBancoProveedor"].ToString());
                CuentaBanco.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());

                CuentaBanco.IdBanco = Int32.Parse(reader["IdBanco"].ToString());
                CuentaBanco.DescBanco = reader["DescBanco"].ToString();

                CuentaBanco.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                CuentaBanco.DescMoneda = reader["DescMoneda"].ToString();

                CuentaBanco.NumeroCuenta = reader["Cuenta"].ToString();
                CuentaBanco.CCI = reader["cci"].ToString();
                CuentaBanco.IdTipoCuenta = Int32.Parse(reader["IdTipoCuenta"].ToString());
                CuentaBanco.DescTipoCuenta = reader["DescTipoCuenta"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return CuentaBanco;
        }

    }
}
