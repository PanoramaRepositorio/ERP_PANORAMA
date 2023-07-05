using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class FacturaCompraInsumoDL
	{
		public FacturaCompraInsumoDL() { }

		public Int32 Inserta(FacturaCompraInsumoBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraInsumo_Inserta");

			db.AddOutParameter(dbCommand, "pIdFacturaCompraInsumo", DbType.Int32, pItem.IdFacturaCompraInsumo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
			db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
			db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
			db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
			db.AddInParameter(dbCommand, "pFechaCompra", DbType.DateTime, pItem.FechaCompra);
			db.AddInParameter(dbCommand, "pFechaRecepcion", DbType.DateTime, pItem.FechaRecepcion);
			db.AddInParameter(dbCommand, "pTipoRegistro", DbType.String, pItem.TipoRegistro);
			db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
			db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
			db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
			db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pDiasCredito", DbType.Int32, pItem.DiasCredito);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagRecibido", DbType.Boolean, pItem.FlagRecibido);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdFacturaCompraInsumo");

			return Id;
		}

		public void Actualiza(FacturaCompraInsumoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraInsumo_Actualiza");

			db.AddInParameter(dbCommand, "pIdFacturaCompraInsumo", DbType.Int32, pItem.IdFacturaCompraInsumo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
			db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
			db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
			db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
			db.AddInParameter(dbCommand, "pFechaCompra", DbType.DateTime, pItem.FechaCompra);
			db.AddInParameter(dbCommand, "pFechaRecepcion", DbType.DateTime, pItem.FechaRecepcion);
			db.AddInParameter(dbCommand, "pTipoRegistro", DbType.String, pItem.TipoRegistro);
			db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
			db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
			db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
			db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pDiasCredito", DbType.Int32, pItem.DiasCredito);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagRecibido", DbType.Boolean, pItem.FlagRecibido);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(FacturaCompraInsumoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraInsumo_Elimina");

			db.AddInParameter(dbCommand, "pIdFacturaCompraInsumo", DbType.Int32, pItem.IdFacturaCompraInsumo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<FacturaCompraInsumoBE> ListaTodosActivo(int IdEmpresa, int Periodo)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraInsumo_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
			List<FacturaCompraInsumoBE> FacturaCompraInsumolist = new List<FacturaCompraInsumoBE>();
			FacturaCompraInsumoBE FacturaCompraInsumo;
			while (reader.Read())
			{
				FacturaCompraInsumo = new FacturaCompraInsumoBE();
                FacturaCompraInsumo.IdFacturaCompraInsumo = Int32.Parse(reader["IdFacturaCompraInsumo"].ToString());
                FacturaCompraInsumo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                FacturaCompraInsumo.Periodo = Int32.Parse(reader["Periodo"].ToString());
                FacturaCompraInsumo.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                FacturaCompraInsumo.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                FacturaCompraInsumo.NumeroDocumento = reader["NumeroDocumento"].ToString();
                FacturaCompraInsumo.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                FacturaCompraInsumo.DescProveedor = reader["DescProveedor"].ToString();
                FacturaCompraInsumo.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                FacturaCompraInsumo.DescFormaPago = reader["DescFormaPago"].ToString();
                FacturaCompraInsumo.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());
                FacturaCompraInsumo.FechaRecepcion = reader.IsDBNull(reader.GetOrdinal("FechaRecepcion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecepcion"));
                FacturaCompraInsumo.TipoRegistro = reader["TipoRegistro"].ToString();
                FacturaCompraInsumo.Importe = Decimal.Parse(reader["Importe"].ToString());
                FacturaCompraInsumo.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                FacturaCompraInsumo.Moneda = reader["Moneda"].ToString();
                FacturaCompraInsumo.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                FacturaCompraInsumo.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                FacturaCompraInsumo.DiasCredito = Int32.Parse(reader["DiasCredito"].ToString());
                FacturaCompraInsumo.Observacion = reader["Observacion"].ToString();
                FacturaCompraInsumo.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                FacturaCompraInsumo.Usuario = reader["Usuario"].ToString();
                FacturaCompraInsumo.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                FacturaCompraInsumo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                FacturaCompraInsumolist.Add(FacturaCompraInsumo);
			}
			reader.Close();
			reader.Dispose();
			return FacturaCompraInsumolist;
		}

        public List<FacturaCompraInsumoBE> ListaProveedor(int IdEmpresa, int IdProveedor, string NumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraInsumo_ListaProveedor");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, IdProveedor);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FacturaCompraInsumoBE> FacturaCompraInsumolist = new List<FacturaCompraInsumoBE>();
            FacturaCompraInsumoBE FacturaCompraInsumo;
            while (reader.Read())
            {
                FacturaCompraInsumo = new FacturaCompraInsumoBE();
                FacturaCompraInsumo.IdFacturaCompraInsumo = Int32.Parse(reader["IdFacturaCompraInsumo"].ToString());
                FacturaCompraInsumo.NumeroDocumento = reader["NumeroDocumento"].ToString();

                FacturaCompraInsumolist.Add(FacturaCompraInsumo);
            }
            reader.Close();
            reader.Dispose();
            return FacturaCompraInsumolist;
        }

        public FacturaCompraInsumoBE Selecciona(int IdFacturaCompraInsumo)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraInsumo_Selecciona");
			db.AddInParameter(dbCommand, "pIdFacturaCompraInsumo", DbType.Int32, IdFacturaCompraInsumo);

			IDataReader reader = db.ExecuteReader(dbCommand);
			FacturaCompraInsumoBE FacturaCompraInsumo = null;
			while (reader.Read())
			{
				FacturaCompraInsumo = new FacturaCompraInsumoBE();
                FacturaCompraInsumo.IdFacturaCompraInsumo = Int32.Parse(reader["IdFacturaCompraInsumo"].ToString());
                FacturaCompraInsumo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                FacturaCompraInsumo.Periodo = Int32.Parse(reader["Periodo"].ToString());
                FacturaCompraInsumo.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                FacturaCompraInsumo.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                FacturaCompraInsumo.NumeroDocumento = reader["NumeroDocumento"].ToString();
                FacturaCompraInsumo.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                FacturaCompraInsumo.DescProveedor = reader["DescProveedor"].ToString();
                FacturaCompraInsumo.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                FacturaCompraInsumo.DescFormaPago = reader["DescFormaPago"].ToString();
                FacturaCompraInsumo.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());
                FacturaCompraInsumo.FechaRecepcion = reader.IsDBNull(reader.GetOrdinal("FechaRecepcion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecepcion"));
                FacturaCompraInsumo.TipoRegistro = reader["TipoRegistro"].ToString();
                FacturaCompraInsumo.Importe = Decimal.Parse(reader["Importe"].ToString());
                FacturaCompraInsumo.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                FacturaCompraInsumo.Moneda = reader["Moneda"].ToString();
                FacturaCompraInsumo.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                FacturaCompraInsumo.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                FacturaCompraInsumo.DiasCredito = Int32.Parse(reader["DiasCredito"].ToString());
                FacturaCompraInsumo.Observacion = reader["Observacion"].ToString();
                FacturaCompraInsumo.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                FacturaCompraInsumo.Usuario = reader["Usuario"].ToString();
                FacturaCompraInsumo.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                FacturaCompraInsumo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
			reader.Close();
			reader.Dispose();
			return FacturaCompraInsumo;
		}

	}
}
