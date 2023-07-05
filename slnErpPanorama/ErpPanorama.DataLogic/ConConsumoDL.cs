using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ConConsumoDL
    {
       public ConConsumoDL() { }

        public void Inserta(ConConsumoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConConsumo_Inserta");

            db.AddInParameter(dbCommand, "pIdConConsumo", DbType.Int32, pItem.IdConConsumo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pCuo", DbType.String, pItem.Cuo);
            db.AddInParameter(dbCommand, "pNumeroCuo", DbType.String, pItem.NumeroCuo);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pIdConTipoComprobantePago", DbType.String, pItem.IdConTipoComprobantePago);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, pItem.Serie);
            db.AddInParameter(dbCommand, "pPeriodoDua", DbType.Int32, pItem.PeriodoDua);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pNumeroInicial", DbType.String, pItem.NumeroInicial);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescProveedor", DbType.String, pItem.DescProveedor);
            db.AddInParameter(dbCommand, "pIdConPlanContable", DbType.Int32, pItem.IdConPlanContable);
            db.AddInParameter(dbCommand, "pBaseImponible", DbType.Decimal, pItem.BaseImponible);
            db.AddInParameter(dbCommand, "pIgv", DbType.Decimal, pItem.Igv);
            db.AddInParameter(dbCommand, "pBaseImponible2", DbType.Decimal, pItem.BaseImponible2);
            db.AddInParameter(dbCommand, "pIgv2", DbType.Decimal, pItem.Igv2);
            db.AddInParameter(dbCommand, "pBaseImponibleSCF", DbType.Decimal, pItem.BaseImponibleSCF);
            db.AddInParameter(dbCommand, "pIgvSCF", DbType.Decimal, pItem.IgvSCF);
            db.AddInParameter(dbCommand, "pImporteANG", DbType.Decimal, pItem.ImporteANG);
            db.AddInParameter(dbCommand, "pIsc", DbType.Decimal, pItem.Isc);
            db.AddInParameter(dbCommand, "pOtroCargo", DbType.Decimal, pItem.OtroCargo);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pImporteDolares", DbType.Decimal, pItem.ImporteDolares);
            db.AddInParameter(dbCommand, "pIdConsumoReferencia", DbType.Int32, pItem.IdConsumoReferencia);
            db.AddInParameter(dbCommand, "pCda", DbType.String, pItem.Cda);
            db.AddInParameter(dbCommand, "pFechaDeposito", DbType.DateTime, pItem.FechaDeposito);
            db.AddInParameter(dbCommand, "pNumeroDeposito", DbType.String, pItem.NumeroDeposito);
            db.AddInParameter(dbCommand, "pFlagRetencion", DbType.Boolean, pItem.FlagRetencion);
            db.AddInParameter(dbCommand, "pIdEstado", DbType.Int32, pItem.IdEstado);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ConConsumoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConConsumo_Actualiza");

            db.AddInParameter(dbCommand, "pIdConConsumo", DbType.Int32, pItem.IdConConsumo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pCuo", DbType.String, pItem.Cuo);
            db.AddInParameter(dbCommand, "pNumeroCuo", DbType.String, pItem.NumeroCuo);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pIdConTipoComprobantePago", DbType.String, pItem.IdConTipoComprobantePago);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, pItem.Serie);
            db.AddInParameter(dbCommand, "pPeriodoDua", DbType.Int32, pItem.PeriodoDua);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pNumeroInicial", DbType.String, pItem.NumeroInicial);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescProveedor", DbType.String, pItem.DescProveedor);
            db.AddInParameter(dbCommand, "pIdConPlanContable", DbType.Int32, pItem.IdConPlanContable);
            db.AddInParameter(dbCommand, "pBaseImponible", DbType.Decimal, pItem.BaseImponible);
            db.AddInParameter(dbCommand, "pIgv", DbType.Decimal, pItem.Igv);
            db.AddInParameter(dbCommand, "pBaseImponible2", DbType.Decimal, pItem.BaseImponible2);
            db.AddInParameter(dbCommand, "pIgv2", DbType.Decimal, pItem.Igv2);
            db.AddInParameter(dbCommand, "pBaseImponibleSCF", DbType.Decimal, pItem.BaseImponibleSCF);
            db.AddInParameter(dbCommand, "pIgvSCF", DbType.Decimal, pItem.IgvSCF);
            db.AddInParameter(dbCommand, "pImporteANG", DbType.Decimal, pItem.ImporteANG);
            db.AddInParameter(dbCommand, "pIsc", DbType.Decimal, pItem.Isc);
            db.AddInParameter(dbCommand, "pOtroCargo", DbType.Decimal, pItem.OtroCargo);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pImporteDolares", DbType.Decimal, pItem.ImporteDolares);
            db.AddInParameter(dbCommand, "pIdConsumoReferencia", DbType.Int32, pItem.IdConsumoReferencia);
            db.AddInParameter(dbCommand, "pCda", DbType.String, pItem.Cda);
            db.AddInParameter(dbCommand, "pFechaDeposito", DbType.DateTime, pItem.FechaDeposito);
            db.AddInParameter(dbCommand, "pNumeroDeposito", DbType.String, pItem.NumeroDeposito);
            db.AddInParameter(dbCommand, "pFlagRetencion", DbType.Boolean, pItem.FlagRetencion);
            db.AddInParameter(dbCommand, "pIdEstado", DbType.Int32, pItem.IdEstado);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ConConsumoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConConsumo_Elimina");

            db.AddInParameter(dbCommand, "pIdConConsumo", DbType.Int32, pItem.IdConConsumo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ConConsumoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConConsumo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            //db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ConConsumoBE> ConConsumolist = new List<ConConsumoBE>();
            ConConsumoBE ConConsumo;
            while (reader.Read())
            {
                ConConsumo = new ConConsumoBE();
                ConConsumo.IdConConsumo = Int32.Parse(reader["IdConConsumo"].ToString());
                ConConsumo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ConConsumo.RazonSocial = reader["RazonSocial"].ToString();
                ConConsumo.Periodo = Int32.Parse(reader["Periodo"].ToString());
                ConConsumo.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                ConConsumo.DescTienda = reader["DescTienda"].ToString();
                ConConsumo.IdArea = Int32.Parse(reader["IdArea"].ToString());
                ConConsumo.DescArea = reader["DescArea"].ToString();
                ConConsumo.Cuo = reader["Cuo"].ToString();
                ConConsumo.NumeroCuo = reader["NumeroCuo"].ToString();
                ConConsumo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                //ConConsumo.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                ConConsumo.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                ConConsumo.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                ConConsumo.DescTipoComprobantePago = reader["DescTipoComprobantePago"].ToString();
                ConConsumo.Serie = reader["Serie"].ToString();
                //ConConsumo.PeriodoDua = Int32.Parse(reader["PeriodoDua"].ToString());
                ConConsumo.PeriodoDua = reader.IsDBNull(reader.GetOrdinal("PeriodoDua")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("PeriodoDua"));
                ConConsumo.Numero = reader["Numero"].ToString();
                ConConsumo.NumeroInicial = reader["NumeroInicial"].ToString();
                ConConsumo.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                ConConsumo.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                ConConsumo.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ConConsumo.DescProveedor = reader["DescProveedor"].ToString();
                ConConsumo.IdConPlanContable = Int32.Parse(reader["IdConPlanContable"].ToString());
                ConConsumo.DescConPlanContable = reader["DescConPlanContable"].ToString();
                ConConsumo.BaseImponible = Decimal.Parse(reader["BaseImponible"].ToString());
                ConConsumo.Igv = Decimal.Parse(reader["Igv"].ToString());
                ConConsumo.BaseImponible2 = Decimal.Parse(reader["BaseImponible2"].ToString());
                ConConsumo.Igv2 = Decimal.Parse(reader["Igv2"].ToString());
                ConConsumo.BaseImponibleSCF = Decimal.Parse(reader["BaseImponibleSCF"].ToString());
                ConConsumo.IgvSCF = Decimal.Parse(reader["IgvSCF"].ToString());
                ConConsumo.ImporteANG = Decimal.Parse(reader["ImporteANG"].ToString());
                ConConsumo.Isc = Decimal.Parse(reader["Isc"].ToString());
                ConConsumo.OtroCargo = Decimal.Parse(reader["OtroCargo"].ToString());
                ConConsumo.Importe = Decimal.Parse(reader["Importe"].ToString());
                ConConsumo.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                ConConsumo.ImporteDolares = Decimal.Parse(reader["ImporteDolares"].ToString());
                ConConsumo.IdConsumoReferencia = reader.IsDBNull(reader.GetOrdinal("IdConsumoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdConsumoReferencia"));
                ConConsumo.FechaReferencia = reader.IsDBNull(reader.GetOrdinal("FechaReferencia")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaReferencia"));
                ConConsumo.IdConTipoComprobantePagoReferencia = reader.IsDBNull(reader.GetOrdinal("IdConTipoComprobantePagoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdConTipoComprobantePagoReferencia"));
                ConConsumo.SerieReferencia = reader["SerieReferencia"].ToString();
                ConConsumo.Cda = reader["Cda"].ToString();
                ConConsumo.NumeroReferencia = reader["NumeroReferencia"].ToString();
                ConConsumo.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                //ConConsumo.FechaDeposito = DateTime.Parse(reader["FechaDeposito"].ToString());
                ConConsumo.NumeroDeposito = reader["NumeroDeposito"].ToString();
                ConConsumo.FlagRetencion = Boolean.Parse(reader["FlagRetencion"].ToString());
                ConConsumo.IdEstado = Int32.Parse(reader["IdEstado"].ToString());
                ConConsumo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                ConConsumolist.Add(ConConsumo);
            }
            reader.Close();
            reader.Dispose();
            return ConConsumolist;
        }

        public ConConsumoBE Selecciona(int IdConConsumo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConConsumo_Selecciona");
            db.AddInParameter(dbCommand, "pIdConConsumo", DbType.Int32, IdConConsumo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ConConsumoBE ConConsumo = null;
            while (reader.Read())
            {
                ConConsumo = new ConConsumoBE();
                ConConsumo.IdConConsumo = Int32.Parse(reader["IdConConsumo"].ToString());
                ConConsumo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ConConsumo.RazonSocial = reader["RazonSocial"].ToString();
                ConConsumo.Periodo = Int32.Parse(reader["Periodo"].ToString());
                ConConsumo.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                ConConsumo.DescTienda = reader["DescTienda"].ToString();
                ConConsumo.IdArea = Int32.Parse(reader["IdArea"].ToString());
                ConConsumo.DescArea = reader["DescArea"].ToString();
                ConConsumo.Cuo = reader["Cuo"].ToString();
                ConConsumo.NumeroCuo = reader["NumeroCuo"].ToString();
                ConConsumo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                //ConConsumo.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                ConConsumo.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                ConConsumo.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                ConConsumo.DescTipoComprobantePago = reader["DescTipoComprobantePago"].ToString();
                ConConsumo.Serie = reader["Serie"].ToString();
                //ConConsumo.PeriodoDua = Int32.Parse(reader["PeriodoDua"].ToString());
                ConConsumo.PeriodoDua = reader.IsDBNull(reader.GetOrdinal("PeriodoDua")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("PeriodoDua"));
                ConConsumo.Numero = reader["Numero"].ToString();
                ConConsumo.NumeroInicial = reader["NumeroInicial"].ToString();
                ConConsumo.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                ConConsumo.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                ConConsumo.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ConConsumo.DescProveedor = reader["DescProveedor"].ToString();
                ConConsumo.IdConPlanContable = Int32.Parse(reader["IdConPlanContable"].ToString());
                ConConsumo.DescConPlanContable = reader["DescConPlanContable"].ToString();
                ConConsumo.BaseImponible = Decimal.Parse(reader["BaseImponible"].ToString());
                ConConsumo.Igv = Decimal.Parse(reader["Igv"].ToString());
                ConConsumo.BaseImponible2 = Decimal.Parse(reader["BaseImponible2"].ToString());
                ConConsumo.Igv2 = Decimal.Parse(reader["Igv2"].ToString());
                ConConsumo.BaseImponibleSCF = Decimal.Parse(reader["BaseImponibleSCF"].ToString());
                ConConsumo.IgvSCF = Decimal.Parse(reader["IgvSCF"].ToString());
                ConConsumo.ImporteANG = Decimal.Parse(reader["ImporteANG"].ToString());
                ConConsumo.Isc = Decimal.Parse(reader["Isc"].ToString());
                ConConsumo.OtroCargo = Decimal.Parse(reader["OtroCargo"].ToString());
                ConConsumo.Importe = Decimal.Parse(reader["Importe"].ToString());
                ConConsumo.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                ConConsumo.ImporteDolares = Decimal.Parse(reader["ImporteDolares"].ToString());
                ConConsumo.IdConsumoReferencia = reader.IsDBNull(reader.GetOrdinal("IdConsumoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdConsumoReferencia"));
                ConConsumo.FechaReferencia = reader.IsDBNull(reader.GetOrdinal("FechaReferencia")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaReferencia"));
                ConConsumo.IdConTipoComprobantePagoReferencia = reader.IsDBNull(reader.GetOrdinal("IdConTipoComprobantePagoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdConTipoComprobantePagoReferencia"));
                ConConsumo.SerieReferencia = reader["SerieReferencia"].ToString();
                ConConsumo.Cda = reader["Cda"].ToString();
                ConConsumo.NumeroReferencia = reader["NumeroReferencia"].ToString();
                ConConsumo.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                //ConConsumo.FechaDeposito = DateTime.Parse(reader["FechaDeposito"].ToString());
                ConConsumo.NumeroDeposito = reader["NumeroDeposito"].ToString();
                ConConsumo.FlagRetencion = Boolean.Parse(reader["FlagRetencion"].ToString());
                ConConsumo.IdEstado = Int32.Parse(reader["IdEstado"].ToString());
                ConConsumo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ConConsumo;
        }

        public ConConsumoBE SeleccionaNumero(string IdConTipoComprobantePago, string Serie, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConConsumo_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pIdConTipoComprobantePago", DbType.String, IdConTipoComprobantePago);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ConConsumoBE ConConsumo = null;
            while (reader.Read())
            {
                ConConsumo = new ConConsumoBE();
                ConConsumo.IdConConsumo = Int32.Parse(reader["IdConConsumo"].ToString());
                ConConsumo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ConConsumo.RazonSocial = reader["RazonSocial"].ToString();
                ConConsumo.Periodo = Int32.Parse(reader["Periodo"].ToString());
                ConConsumo.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                ConConsumo.DescTienda = reader["DescTienda"].ToString();
                ConConsumo.IdArea = Int32.Parse(reader["IdArea"].ToString());
                ConConsumo.DescArea = reader["DescArea"].ToString();
                ConConsumo.Cuo = reader["Cuo"].ToString();
                ConConsumo.NumeroCuo = reader["NumeroCuo"].ToString();
                ConConsumo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                //ConConsumo.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                ConConsumo.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                ConConsumo.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                ConConsumo.DescTipoComprobantePago = reader["DescTipoComprobantePago"].ToString();
                ConConsumo.Serie = reader["Serie"].ToString();
                //ConConsumo.PeriodoDua = Int32.Parse(reader["PeriodoDua"].ToString());
                ConConsumo.PeriodoDua = reader.IsDBNull(reader.GetOrdinal("PeriodoDua")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("PeriodoDua"));
                ConConsumo.Numero = reader["Numero"].ToString();
                ConConsumo.NumeroInicial = reader["NumeroInicial"].ToString();
                ConConsumo.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                ConConsumo.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                ConConsumo.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ConConsumo.DescProveedor = reader["DescProveedor"].ToString();
                ConConsumo.IdConPlanContable = Int32.Parse(reader["IdConPlanContable"].ToString());
                ConConsumo.DescConPlanContable = reader["DescConPlanContable"].ToString();
                ConConsumo.BaseImponible = Decimal.Parse(reader["BaseImponible"].ToString());
                ConConsumo.Igv = Decimal.Parse(reader["Igv"].ToString());
                ConConsumo.BaseImponible2 = Decimal.Parse(reader["BaseImponible2"].ToString());
                ConConsumo.Igv2 = Decimal.Parse(reader["Igv2"].ToString());
                ConConsumo.BaseImponibleSCF = Decimal.Parse(reader["BaseImponibleSCF"].ToString());
                ConConsumo.IgvSCF = Decimal.Parse(reader["IgvSCF"].ToString());
                ConConsumo.ImporteANG = Decimal.Parse(reader["ImporteANG"].ToString());
                ConConsumo.Isc = Decimal.Parse(reader["Isc"].ToString());
                ConConsumo.OtroCargo = Decimal.Parse(reader["OtroCargo"].ToString());
                ConConsumo.Importe = Decimal.Parse(reader["Importe"].ToString());
                ConConsumo.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                ConConsumo.ImporteDolares = Decimal.Parse(reader["ImporteDolares"].ToString());
                ConConsumo.IdConsumoReferencia = reader.IsDBNull(reader.GetOrdinal("IdConsumoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdConsumoReferencia"));
                ConConsumo.FechaReferencia = reader.IsDBNull(reader.GetOrdinal("FechaReferencia")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaReferencia"));
                ConConsumo.IdConTipoComprobantePagoReferencia = reader.IsDBNull(reader.GetOrdinal("IdConTipoComprobantePagoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdConTipoComprobantePagoReferencia"));
                ConConsumo.SerieReferencia = reader["SerieReferencia"].ToString();
                ConConsumo.Cda = reader["Cda"].ToString();
                ConConsumo.NumeroReferencia = reader["NumeroReferencia"].ToString();
                ConConsumo.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                //ConConsumo.FechaDeposito = DateTime.Parse(reader["FechaDeposito"].ToString());
                ConConsumo.NumeroDeposito = reader["NumeroDeposito"].ToString();
                ConConsumo.FlagRetencion = Boolean.Parse(reader["FlagRetencion"].ToString());
                ConConsumo.IdEstado = Int32.Parse(reader["IdEstado"].ToString());
                ConConsumo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ConConsumo;
        }
    }
}
