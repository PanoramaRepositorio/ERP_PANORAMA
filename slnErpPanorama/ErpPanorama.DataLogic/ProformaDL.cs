using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ProformaDL
    {
        public ProformaDL() { }

        public Int32 Inserta(ProformaBE pItem)
        {
            Int32 intIdProforma = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proforma_Inserta");

            db.AddOutParameter(dbCommand, "pIdProforma", DbType.Int32, pItem.IdProforma);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pTotalCantidad", DbType.Int32, pItem.TotalCantidad);
            db.AddInParameter(dbCommand, "pSubTotal", DbType.Decimal, pItem.SubTotal);
            db.AddInParameter(dbCommand, "pIgv", DbType.Decimal, pItem.Igv);
            db.AddInParameter(dbCommand, "pPorcentajeImpuesto", DbType.Double, pItem.PorcentajeImpuesto);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, pItem.IdDis_ProyectoServicio);
            db.AddInParameter(dbCommand, "pIdClienteEntidad", DbType.Int32, pItem.IdClienteEntidad);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdProforma = (int)db.GetParameterValue(dbCommand, "pIdProforma");

            return intIdProforma;

        }

        public void Actualiza(ProformaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proforma_Actualiza");

            db.AddInParameter(dbCommand, "pIdProforma", DbType.Int32, pItem.IdProforma);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pTotalCantidad", DbType.Int32, pItem.TotalCantidad);
            db.AddInParameter(dbCommand, "pSubTotal", DbType.Decimal, pItem.SubTotal);
            db.AddInParameter(dbCommand, "pIgv", DbType.Decimal, pItem.Igv);
            db.AddInParameter(dbCommand, "pPorcentajeImpuesto", DbType.Double, pItem.PorcentajeImpuesto);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, pItem.IdDis_ProyectoServicio);
            db.AddInParameter(dbCommand, "pIdClienteEntidad", DbType.Int32, pItem.IdClienteEntidad);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaSituacion(int IdEmpresa, int IdProforma, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proforma_ActualizaSituacion");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProforma", DbType.Int32, IdProforma);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ProformaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proforma_Elimina");

            db.AddInParameter(dbCommand, "pIdProforma", DbType.Int32, pItem.IdProforma);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public List<ProformaBE> ListaTodosActivo(int IdEmpresa, int Periodo, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proforma_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProformaBE> Proformalist = new List<ProformaBE>();
            ProformaBE Proforma;
            while (reader.Read())
            {
                Proforma = new ProformaBE();
                Proforma.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Proforma.Ruc = reader["Ruc"].ToString();
                Proforma.RazonSocial = reader["RazonSocial"].ToString();
                Proforma.IdProforma = Int32.Parse(reader["idProforma"].ToString());
                Proforma.Periodo = Int32.Parse(reader["periodo"].ToString());
                Proforma.Mes = Int32.Parse(reader["mes"].ToString());
                Proforma.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Proforma.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                Proforma.Numero = reader["numero"].ToString();
                Proforma.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Proforma.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Proforma.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Proforma.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Proforma.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Proforma.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                Proforma.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Proforma.DescCliente = reader["DescCliente"].ToString();
                Proforma.Direccion = reader["direccion"].ToString();
                Proforma.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Proforma.CodMoneda = reader["CodMoneda"].ToString();
                Proforma.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Proforma.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                Proforma.DescFormaPago = reader["descFormaPago"].ToString();
                Proforma.IdVendedor = Int32.Parse(reader["idVendedor"].ToString());
                Proforma.DescVendedor = reader["DescVendedor"].ToString();
                Proforma.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
                Proforma.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                Proforma.Igv = Decimal.Parse(reader["igv"].ToString());
                Proforma.PorcentajeImpuesto = Decimal.Parse(reader["porcentajeImpuesto"].ToString());
                Proforma.Total = Decimal.Parse(reader["total"].ToString());
                Proforma.Observacion = reader["observacion"].ToString();
                Proforma.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                Proforma.DescSituacion = reader["DescSituacion"].ToString();
                Proforma.IdDis_ProyectoServicio = reader.IsDBNull(reader.GetOrdinal("IdDis_ProyectoServicio")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDis_ProyectoServicio"));
                Proforma.NumeroPedido = reader["NumeroPedido"].ToString();
                Proforma.DescSituacionPedido = reader["DescSituacionPedido"].ToString();
                Proforma.Celular = reader["Celular"].ToString();
                Proforma.DescClienteEntidad = reader["DescClienteEntidad"].ToString();
                Proforma.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Proformalist.Add(Proforma);
            }
            reader.Close();
            reader.Dispose();
            return Proformalist;
        }

        public ProformaBE Selecciona(int IdProforma)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proforma_Selecciona");
            db.AddInParameter(dbCommand, "pIdProforma", DbType.Int32, IdProforma);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProformaBE Proforma = null;
            while (reader.Read())
            {
                Proforma = new ProformaBE();
                Proforma.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Proforma.Ruc = reader["Ruc"].ToString();
                Proforma.RazonSocial = reader["RazonSocial"].ToString();
                Proforma.IdProforma = Int32.Parse(reader["idProforma"].ToString());
                Proforma.Periodo = Int32.Parse(reader["periodo"].ToString());
                Proforma.Mes = Int32.Parse(reader["mes"].ToString());
                Proforma.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Proforma.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                Proforma.Numero = reader["numero"].ToString();
                Proforma.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Proforma.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Proforma.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Proforma.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Proforma.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Proforma.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                Proforma.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Proforma.DescCliente = reader["DescCliente"].ToString();
                Proforma.Direccion = reader["direccion"].ToString();
                Proforma.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Proforma.CodMoneda = reader["CodMoneda"].ToString();
                Proforma.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Proforma.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                Proforma.DescFormaPago = reader["descFormaPago"].ToString();
                Proforma.IdVendedor = Int32.Parse(reader["idVendedor"].ToString());
                Proforma.DescVendedor = reader["DescVendedor"].ToString();
                Proforma.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
                Proforma.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                Proforma.Igv = Decimal.Parse(reader["igv"].ToString());
                Proforma.PorcentajeImpuesto = Decimal.Parse(reader["porcentajeImpuesto"].ToString());
                Proforma.Total = Decimal.Parse(reader["total"].ToString());
                Proforma.Observacion = reader["observacion"].ToString();
                Proforma.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                Proforma.DescSituacion = reader["DescSituacion"].ToString();
                Proforma.IdDis_ProyectoServicio = reader.IsDBNull(reader.GetOrdinal("IdDis_ProyectoServicio")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDis_ProyectoServicio"));
                Proforma.IdClienteEntidad = Int32.Parse(reader["IdClienteEntidad"].ToString());
                Proforma.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Proforma;
        }

        public ProformaBE SeleccionaNumero(int Periodo, string Numero, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proforma_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProformaBE Proforma = null;
            while (reader.Read())
            {
                Proforma = new ProformaBE();
                Proforma.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Proforma.Ruc = reader["Ruc"].ToString();
                Proforma.RazonSocial = reader["RazonSocial"].ToString();
                Proforma.IdProforma = Int32.Parse(reader["idProforma"].ToString());
                Proforma.Periodo = Int32.Parse(reader["periodo"].ToString());
                Proforma.Mes = Int32.Parse(reader["mes"].ToString());
                Proforma.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Proforma.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                Proforma.Numero = reader["numero"].ToString();
                Proforma.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Proforma.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Proforma.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Proforma.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Proforma.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Proforma.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                Proforma.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Proforma.DescCliente = reader["DescCliente"].ToString();
                Proforma.Direccion = reader["direccion"].ToString();
                Proforma.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Proforma.CodMoneda = reader["CodMoneda"].ToString();
                Proforma.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Proforma.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                Proforma.DescFormaPago = reader["descFormaPago"].ToString();
                Proforma.IdVendedor = Int32.Parse(reader["idVendedor"].ToString());
                Proforma.DescVendedor = reader["DescVendedor"].ToString();
                Proforma.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
                Proforma.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                Proforma.Igv = Decimal.Parse(reader["igv"].ToString());
                Proforma.PorcentajeImpuesto = Decimal.Parse(reader["porcentajeImpuesto"].ToString());
                Proforma.Total = Decimal.Parse(reader["total"].ToString());
                Proforma.Observacion = reader["observacion"].ToString();
                Proforma.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                Proforma.DescSituacion = reader["DescSituacion"].ToString();
                Proforma.IdDis_ProyectoServicio = reader.IsDBNull(reader.GetOrdinal("IdDis_ProyectoServicio")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDis_ProyectoServicio"));
                Proforma.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Proforma;
        }
    }
}
