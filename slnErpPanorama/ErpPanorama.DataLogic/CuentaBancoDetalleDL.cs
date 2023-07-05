using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class CuentaBancoDetalleDL
    {
        public CuentaBancoDetalleDL() { }

        public void Inserta(CuentaBancoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdCuentaBancoDetalle", DbType.Int32, pItem.IdCuentaBancoDetalle);
            db.AddInParameter(dbCommand, "pIdCuentaBanco", DbType.Int32, pItem.IdCuentaBanco);
            db.AddInParameter(dbCommand, "pNumeroMovimiento", DbType.String, pItem.NumeroMovimiento);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
            db.AddInParameter(dbCommand, "pITF", DbType.Decimal, pItem.ITF);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pIdCuentaBancoDetalleCausal", DbType.Int32, pItem.IdCuentaBancoDetalleCausal);
            db.AddInParameter(dbCommand, "pIdCuentaBancoDetalleConcepto", DbType.Int32, pItem.IdCuentaBancoDetalleConcepto);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pFechaCuadre", DbType.DateTime, pItem.FechaCuadre);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(CuentaBancoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdCuentaBancoDetalle", DbType.Int32, pItem.IdCuentaBancoDetalle);
            db.AddInParameter(dbCommand, "pIdCuentaBanco", DbType.Int32, pItem.IdCuentaBanco);
            db.AddInParameter(dbCommand, "pNumeroMovimiento", DbType.String, pItem.NumeroMovimiento);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
            db.AddInParameter(dbCommand, "pITF", DbType.Decimal, pItem.ITF);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pIdCuentaBancoDetalleCausal", DbType.Int32, pItem.IdCuentaBancoDetalleCausal);
            db.AddInParameter(dbCommand, "pIdCuentaBancoDetalleConcepto", DbType.Int32, pItem.IdCuentaBancoDetalleConcepto);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pFechaCuadre", DbType.DateTime, pItem.FechaCuadre);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(CuentaBancoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdCuentaBancoDetalle", DbType.Int32, pItem.IdCuentaBancoDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCliente(CuentaBancoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoDetalle_ActualizaCliente");

            db.AddInParameter(dbCommand, "pIdCuentaBancoDetalle", DbType.Int32, pItem.IdCuentaBancoDetalle);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaProveedor(CuentaBancoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoDetalle_ActualizaProveedor");

            db.AddInParameter(dbCommand, "pIdCuentaBancoDetalle", DbType.Int32, pItem.IdCuentaBancoDetalle);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pDescProveedor", DbType.String, pItem.DescProveedor);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<CuentaBancoDetalleBE> ListaTodosActivo(int IdCuentaBanco)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCuentaBanco", DbType.Int32, IdCuentaBanco);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CuentaBancoDetalleBE> CuentaBancoDetallelist = new List<CuentaBancoDetalleBE>();
            CuentaBancoDetalleBE CuentaBancoDetalle;
            while (reader.Read())
            {
                CuentaBancoDetalle = new CuentaBancoDetalleBE();
                CuentaBancoDetalle.IdCuentaBanco = Int32.Parse(reader["IdCuentaBanco"].ToString());
                CuentaBancoDetalle.IdCuentaBancoDetalle = Int32.Parse(reader["IdCuentaBancoDetalle"].ToString());
                CuentaBancoDetalle.NumeroMovimiento = reader["NumeroMovimiento"].ToString();
                CuentaBancoDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                CuentaBancoDetalle.Concepto = reader["Concepto"].ToString();
                CuentaBancoDetalle.ITF = Decimal.Parse(reader["ITF"].ToString());
                CuentaBancoDetalle.Importe = Decimal.Parse(reader["Importe"].ToString());
                CuentaBancoDetalle.TipoMovimiento = reader["TipoMovimiento"].ToString();
                CuentaBancoDetalle.IdCuentaBancoDetalleCausal = Int32.Parse(reader["IdCuentaBancoDetalleCausal"].ToString());
                CuentaBancoDetalle.IdCuentaBancoDetalleConcepto = Int32.Parse(reader["IdCuentaBancoDetalleConcepto"].ToString());
                CuentaBancoDetalle.IdCliente = reader.IsDBNull(reader.GetOrdinal("IdCliente")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCliente"));
                CuentaBancoDetalle.IdTienda = reader.IsDBNull(reader.GetOrdinal("IdTienda")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdTienda"));
                CuentaBancoDetalle.FechaCuadre = reader.IsDBNull(reader.GetOrdinal("FechaCuadre")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCuadre"));
                CuentaBancoDetalle.Observacion = reader["Observacion"].ToString();
                CuentaBancoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CuentaBancoDetallelist.Add(CuentaBancoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return CuentaBancoDetallelist;
        }

        public List<CuentaBancoDetalleBE> ListaCuentaBanco(DateTime FechaDesde, DateTime FechaHasta, int IdCuentaBanco)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoDetalle_ListaCuentaBanco");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdCuentaBanco", DbType.Int32, IdCuentaBanco);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CuentaBancoDetalleBE> CuentaBancoDetallelist = new List<CuentaBancoDetalleBE>();
            CuentaBancoDetalleBE CuentaBancoDetalle;
            while (reader.Read())
            {
                CuentaBancoDetalle = new CuentaBancoDetalleBE();
                CuentaBancoDetalle.IdCuentaBanco = Int32.Parse(reader["IdCuentaBanco"].ToString());
                CuentaBancoDetalle.IdCuentaBancoDetalle = Int32.Parse(reader["IdCuentaBancoDetalle"].ToString());
                CuentaBancoDetalle.NumeroMovimiento = reader["NumeroMovimiento"].ToString();
                CuentaBancoDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                CuentaBancoDetalle.Concepto = reader["Concepto"].ToString();
                CuentaBancoDetalle.ITF = Decimal.Parse(reader["ITF"].ToString());
                CuentaBancoDetalle.CuentaCargo = Decimal.Parse(reader["CuentaCargo"].ToString());
                CuentaBancoDetalle.PagoAbono = Decimal.Parse(reader["PagoAbono"].ToString());
                CuentaBancoDetalle.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                CuentaBancoDetalle.TipoMovimiento = reader["TipoMovimiento"].ToString();
                CuentaBancoDetalle.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                CuentaBancoDetalle.DescCliente = reader["DescCliente"].ToString();
                CuentaBancoDetalle.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                CuentaBancoDetalle.DescProveedor = reader["DescProveedor"].ToString();
                CuentaBancoDetalle.DescTienda = reader["DescTienda"].ToString();
                CuentaBancoDetalle.IdCuentaBancoDetalleCausal = Int32.Parse(reader["IdCuentaBancoDetalleCausal"].ToString());
                CuentaBancoDetalle.IdCuentaBancoDetalleConcepto = Int32.Parse(reader["IdCuentaBancoDetalleConcepto"].ToString());
                //CuentaBancoDetalle.IdCliente = reader.IsDBNull(reader.GetOrdinal("IdCliente")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCliente"));
                //CuentaBancoDetalle.IdTienda = reader.IsDBNull(reader.GetOrdinal("IdTienda")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdTienda"));
                CuentaBancoDetalle.Observacion = reader["Observacion"].ToString();
                //CuentaBancoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CuentaBancoDetallelist.Add(CuentaBancoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return CuentaBancoDetallelist;
        }

        public CuentaBancoDetalleBE Selecciona(int IdCuentaBancoDetalle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoDetalle_Selecciona");
            db.AddInParameter(dbCommand, "pIdCuentaBancoDetalle", DbType.Int32, IdCuentaBancoDetalle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CuentaBancoDetalleBE CuentaBancoDetalle = null;
            while (reader.Read())
            {
                CuentaBancoDetalle = new CuentaBancoDetalleBE();
                CuentaBancoDetalle.IdCuentaBanco = Int32.Parse(reader["IdCuentaBanco"].ToString());
                CuentaBancoDetalle.IdCuentaBancoDetalle = Int32.Parse(reader["IdCuentaBancoDetalle"].ToString());
                CuentaBancoDetalle.NumeroMovimiento = reader["NumeroMovimiento"].ToString();
                CuentaBancoDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                CuentaBancoDetalle.Concepto = reader["Concepto"].ToString();
                CuentaBancoDetalle.ITF = Decimal.Parse(reader["ITF"].ToString());
                CuentaBancoDetalle.Importe = Decimal.Parse(reader["Importe"].ToString());
                CuentaBancoDetalle.TipoMovimiento = reader["TipoMovimiento"].ToString();
                CuentaBancoDetalle.IdCuentaBancoDetalleCausal = Int32.Parse(reader["IdCuentaBancoDetalleCausal"].ToString());
                CuentaBancoDetalle.IdCuentaBancoDetalleConcepto = Int32.Parse(reader["IdCuentaBancoDetalleConcepto"].ToString());
                CuentaBancoDetalle.IdCliente = reader.IsDBNull(reader.GetOrdinal("IdCliente")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCliente"));
                CuentaBancoDetalle.IdTienda = reader.IsDBNull(reader.GetOrdinal("IdTienda")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdTienda"));
                CuentaBancoDetalle.FechaCuadre = reader.IsDBNull(reader.GetOrdinal("FechaCuadre")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCuadre"));
                CuentaBancoDetalle.Observacion = reader["Observacion"].ToString();
                CuentaBancoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return CuentaBancoDetalle;
        }


    }
}
