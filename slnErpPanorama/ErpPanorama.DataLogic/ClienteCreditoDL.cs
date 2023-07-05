using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ClienteCreditoDL
    {
        public ClienteCreditoDL() { }

        public void Inserta(ClienteCreditoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteCredito_Inserta");

            db.AddInParameter(dbCommand, "pIdClienteCredito", DbType.Int32, pItem.IdClienteCredito);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdClasificacionCliente", DbType.Int32, pItem.IdClasificacionCliente);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pFechaAprobacion", DbType.DateTime, pItem.FechaAprobacion);
            db.AddInParameter(dbCommand, "pLineaCredito", DbType.Decimal, pItem.LineaCredito);
            db.AddInParameter(dbCommand, "pLineaCreditoUtilizada", DbType.Decimal, pItem.LineaCreditoUtilizada);
            db.AddInParameter(dbCommand, "pLineaCreditoDisponible", DbType.Decimal, pItem.LineaCreditoDisponible);
            db.AddInParameter(dbCommand, "pGarantia", DbType.Decimal, pItem.Garantia);
            db.AddInParameter(dbCommand, "pNumeroDias", DbType.Int32, pItem.NumeroDias);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ClienteCreditoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteCredito_Actualiza");

            db.AddInParameter(dbCommand, "pIdClienteCredito", DbType.Int32, pItem.IdClienteCredito);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdClasificacionCliente", DbType.Int32, pItem.IdClasificacionCliente);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pFechaAprobacion", DbType.DateTime, pItem.FechaAprobacion);
            db.AddInParameter(dbCommand, "pLineaCredito", DbType.Decimal, pItem.LineaCredito);
            db.AddInParameter(dbCommand, "pLineaCreditoUtilizada", DbType.Decimal, pItem.LineaCreditoUtilizada);
            db.AddInParameter(dbCommand, "pLineaCreditoDisponible", DbType.Decimal, pItem.LineaCreditoDisponible);
            db.AddInParameter(dbCommand, "pGarantia", DbType.Decimal, pItem.Garantia);
            db.AddInParameter(dbCommand, "pNumeroDias", DbType.Int32, pItem.NumeroDias);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ClienteCreditoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteCredito_Elimina");
            db.AddInParameter(dbCommand, "pIdClienteCredito", DbType.Int32, pItem.IdClienteCredito);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }


        public void ActualizaLineaCreditoUtilizada(int IdEmpresa, int IdCliente, decimal ValorIncrementa, decimal ValorDescuenta, int IdMotivo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteCredito_ActualizaLineaCreditoUtilizada");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pValorIncrementa", DbType.Decimal, ValorIncrementa);
            db.AddInParameter(dbCommand, "pValorDescuenta", DbType.Decimal, ValorDescuenta);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);

            db.ExecuteNonQuery(dbCommand);
        }

        public ClienteCreditoBE Selecciona(int IdEmpresa, int IdClienteCredito)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteCredito_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdClienteCredito", DbType.Int32, IdClienteCredito);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClienteCreditoBE ClienteCredito = null;
            while (reader.Read())
            {
                ClienteCredito = new ClienteCreditoBE();
                ClienteCredito.IdClienteCredito = Int32.Parse(reader["IdClienteCredito"].ToString());
                ClienteCredito.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                ClienteCredito.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ClienteCredito.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                ClienteCredito.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                ClienteCredito.DescMotivo = reader["DescMotivo"].ToString();
                ClienteCredito.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                ClienteCredito.AbrevDocumento = reader["AbrevDocumento"].ToString();
                ClienteCredito.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ClienteCredito.DescCliente = reader["DescCliente"].ToString();
                ClienteCredito.Direccion = reader["Direccion"].ToString();
                ClienteCredito.AbrevClasifica = reader["AbrevClasifica"].ToString();
                ClienteCredito.FechaAprobacion = DateTime.Parse(reader["fechaAprobacion"].ToString());
                ClienteCredito.LineaCredito = Decimal.Parse(reader["lineaCredito"].ToString());
                ClienteCredito.LineaCreditoUtilizada = Decimal.Parse(reader["LineaCreditoUtilizada"].ToString());
                ClienteCredito.LineaCreditoDisponible = Decimal.Parse(reader["LineaCreditoDisponible"].ToString());
                ClienteCredito.Garantia = Decimal.Parse(reader["Garantia"].ToString());
                ClienteCredito.NumeroDias = Int32.Parse(reader["numeroDias"].ToString());
                ClienteCredito.Observacion = reader["Observacion"].ToString();
                ClienteCredito.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ClienteCredito;
        }

        public ClienteCreditoBE SeleccionaCliente(int IdEmpresa, int IdCliente, int IdMotivo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteCredito_SeleccionaCliente");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pIdMotivo ", DbType.Int32, IdMotivo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClienteCreditoBE ClienteCredito = null;
            while (reader.Read())
            {
                ClienteCredito = new ClienteCreditoBE();
                ClienteCredito.IdClienteCredito = Int32.Parse(reader["IdClienteCredito"].ToString());
                ClienteCredito.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                ClienteCredito.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ClienteCredito.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                ClienteCredito.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                ClienteCredito.DescMotivo = reader["DescMotivo"].ToString();
                ClienteCredito.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                ClienteCredito.AbrevDocumento = reader["AbrevDocumento"].ToString();
                ClienteCredito.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ClienteCredito.DescCliente = reader["DescCliente"].ToString();
                ClienteCredito.Direccion = reader["Direccion"].ToString();
                ClienteCredito.AbrevClasifica = reader["AbrevClasifica"].ToString();
                ClienteCredito.FechaAprobacion = DateTime.Parse(reader["fechaAprobacion"].ToString());
                ClienteCredito.LineaCredito = Decimal.Parse(reader["lineaCredito"].ToString());
                ClienteCredito.LineaCreditoUtilizada = Decimal.Parse(reader["LineaCreditoUtilizada"].ToString());
                ClienteCredito.LineaCreditoDisponible = Decimal.Parse(reader["LineaCreditoDisponible"].ToString());
                ClienteCredito.Garantia = Decimal.Parse(reader["Garantia"].ToString());
                ClienteCredito.NumeroDias = Int32.Parse(reader["numeroDias"].ToString());
                ClienteCredito.Observacion = reader["Observacion"].ToString();
                ClienteCredito.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ClienteCredito;
        }

        public List<ClienteCreditoBE> SeleccionaTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteCredito_Selecciona");



            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteCreditoBE> ClienteCreditolist = new List<ClienteCreditoBE>();
            ClienteCreditoBE ClienteCredito;
            while (reader.Read())
            {
                ClienteCredito = new ClienteCreditoBE();
                ClienteCredito.IdClienteCredito = Int32.Parse(reader["IdClienteCredito"].ToString());
                ClienteCredito.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                ClienteCredito.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ClienteCredito.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                ClienteCredito.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                ClienteCredito.DescMotivo = reader["DescMotivo"].ToString();
                ClienteCredito.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                ClienteCredito.AbrevDocumento = reader["AbrevDocumento"].ToString();
                ClienteCredito.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ClienteCredito.DescCliente = reader["DescCliente"].ToString();
                ClienteCredito.DescCliente = reader["Direccion"].ToString();
                ClienteCredito.AbrevClasifica = reader["AbrevClasifica"].ToString();
                ClienteCredito.FechaAprobacion = DateTime.Parse(reader["fechaAprobacion"].ToString());
                ClienteCredito.LineaCredito = Decimal.Parse(reader["lineaCredito"].ToString());
                ClienteCredito.LineaCreditoUtilizada = Decimal.Parse(reader["LineaCreditoUtilizada"].ToString());
                ClienteCredito.LineaCreditoDisponible = Decimal.Parse(reader["LineaCreditoDisponible"].ToString());
                ClienteCredito.Garantia = Decimal.Parse(reader["Garantia"].ToString());
                ClienteCredito.NumeroDias = Int32.Parse(reader["numeroDias"].ToString());
                ClienteCredito.DescCliente = reader["DescCliente"].ToString();
                ClienteCredito.Observacion = reader["Observacion"].ToString();
                ClienteCredito.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ClienteCreditolist.Add(ClienteCredito);
            }
            reader.Close();
            reader.Dispose();
            return ClienteCreditolist;
        }

        public List<ClienteCreditoBE> ListaTodosActivo(int IdEmpresa, int IdMotivo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteCredito_ListaTodosActivo");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteCreditoBE> ClienteCreditolist = new List<ClienteCreditoBE>();
            ClienteCreditoBE ClienteCredito;
            while (reader.Read())
            {
                ClienteCredito = new ClienteCreditoBE();
                ClienteCredito.IdClienteCredito = Int32.Parse(reader["IdClienteCredito"].ToString());
                ClienteCredito.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                ClienteCredito.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ClienteCredito.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                ClienteCredito.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                ClienteCredito.DescMotivo = reader["DescMotivo"].ToString();
                ClienteCredito.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                ClienteCredito.AbrevDocumento = reader["AbrevDocumento"].ToString();
                ClienteCredito.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ClienteCredito.DescCliente = reader["DescCliente"].ToString();
                ClienteCredito.DescCliente = reader["Direccion"].ToString();
                ClienteCredito.AbrevClasifica = reader["AbrevClasifica"].ToString();
                ClienteCredito.FechaAprobacion = DateTime.Parse(reader["fechaAprobacion"].ToString());
                ClienteCredito.LineaCredito = Decimal.Parse(reader["lineaCredito"].ToString());
                ClienteCredito.LineaCreditoUtilizada = Decimal.Parse(reader["LineaCreditoUtilizada"].ToString());
                ClienteCredito.LineaCreditoDisponible = Decimal.Parse(reader["LineaCreditoDisponible"].ToString());
                ClienteCredito.Garantia = Decimal.Parse(reader["Garantia"].ToString());
                ClienteCredito.NumeroDias = Int32.Parse(reader["numeroDias"].ToString());
                ClienteCredito.DescCliente = reader["DescCliente"].ToString();
                ClienteCredito.Observacion = reader["Observacion"].ToString();
                ClienteCredito.DescTipoCliente = reader["DescTipoCliente"].ToString();
                ClienteCredito.DescRuta = reader["DescRuta"].ToString();
                ClienteCredito.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                ClienteCredito.FechaRegistro = reader.IsDBNull(reader.GetOrdinal("FechaRegistro")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRegistro"));
                ClienteCredito.UsuarioModifica = reader["UsuarioModifica"].ToString();
                ClienteCredito.FechaModifica = reader.IsDBNull(reader.GetOrdinal("FechaModifica")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaModifica"));
                ClienteCredito.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ClienteCreditolist.Add(ClienteCredito);
            }
            reader.Close();
            reader.Dispose();
            return ClienteCreditolist;
        }
    }
}
