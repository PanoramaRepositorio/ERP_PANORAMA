using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class CambioDetalleDL
    {
        public CambioDetalleDL() { }

        public void Inserta(CambioDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CambioDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdCambioDetalle", DbType.Int32, pItem.IdCambioDetalle);
            db.AddInParameter(dbCommand, "pIdCambio", DbType.Int32, pItem.IdCambio);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecioUnitario", DbType.Decimal, pItem.PrecioUnitario);
            db.AddInParameter(dbCommand, "pPorcentajeDescuento", DbType.Double, pItem.PorcentajeDescuento);
            db.AddInParameter(dbCommand, "pPrecioVenta", DbType.Decimal, pItem.PrecioVenta);
            db.AddInParameter(dbCommand, "pValorVenta", DbType.Decimal, pItem.ValorVenta);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pPrecioUnitarioPedido", DbType.Decimal, pItem.PrecioUnitarioPedido);
            db.AddInParameter(dbCommand, "pPrecioVentaPedido", DbType.Decimal, pItem.PrecioVentaPedido);
            db.AddInParameter(dbCommand, "pValorVentaSoles", DbType.Decimal, pItem.ValorVentaSoles);
            db.AddInParameter(dbCommand, "pValorVentaDolares", DbType.Decimal, pItem.ValorVentaDolares);
            db.AddInParameter(dbCommand, "pCodAfeIGV", DbType.String, pItem.CodAfeIGV);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pDescPromocion", DbType.String, pItem.DescPromocion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(CambioDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CambioDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdCambioDetalle", DbType.Int32, pItem.IdCambioDetalle);
            db.AddInParameter(dbCommand, "pIdCambio", DbType.Int32, pItem.IdCambio);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecioUnitario", DbType.Decimal, pItem.PrecioUnitario);
            db.AddInParameter(dbCommand, "pPorcentajeDescuento", DbType.Double, pItem.PorcentajeDescuento);
            db.AddInParameter(dbCommand, "pPrecioVenta", DbType.Decimal, pItem.PrecioVenta);
            db.AddInParameter(dbCommand, "pValorVenta", DbType.Decimal, pItem.ValorVenta);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pPrecioUnitarioPedido", DbType.Decimal, pItem.PrecioUnitarioPedido);
            db.AddInParameter(dbCommand, "pPrecioVentaPedido", DbType.Decimal, pItem.PrecioVentaPedido);
            db.AddInParameter(dbCommand, "pValorVentaSoles", DbType.Decimal, pItem.ValorVentaSoles);
            db.AddInParameter(dbCommand, "pValorVentaDolares", DbType.Decimal, pItem.ValorVentaDolares);
            db.AddInParameter(dbCommand, "pCodAfeIGV", DbType.String, pItem.CodAfeIGV);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);


        }

        public void Elimina(CambioDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CambioDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdCambioDetalle", DbType.Int32, pItem.IdCambioDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


            db.ExecuteNonQuery(dbCommand);
        }


        public List<CambioDetalleBE> ListaTodosActivo(int IdCambio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CambioDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCambio", DbType.Int32, IdCambio);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CambioDetalleBE> CambioDetallelist = new List<CambioDetalleBE>();
            CambioDetalleBE CambioDetalle;
            while (reader.Read())
            {
                CambioDetalle = new CambioDetalleBE();
                CambioDetalle.IdCambio = Int32.Parse(reader["idCambio"].ToString());
                CambioDetalle.IdCambioDetalle = Int32.Parse(reader["idCambioDetalle"].ToString());
                CambioDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                CambioDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                CambioDetalle.NombreProducto = reader["nombreProducto"].ToString();
                CambioDetalle.Abreviatura = reader["Abreviatura"].ToString();
                CambioDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                CambioDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                CambioDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                CambioDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                CambioDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                CambioDetalle.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                CambioDetalle.PrecioUnitarioPedido = Decimal.Parse(reader["PrecioUnitarioPedido"].ToString());
                CambioDetalle.PrecioVentaPedido = Decimal.Parse(reader["PrecioVentaPedido"].ToString());
                CambioDetalle.ValorVentaSoles = Decimal.Parse(reader["ValorVentaSoles"].ToString());
                CambioDetalle.ValorVentaDolares = Decimal.Parse(reader["ValorVentaDolares"].ToString());
                CambioDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                CambioDetalle.Observacion = reader["Observacion"].ToString();
                CambioDetalle.DescPromocion = reader["DescPromocion"].ToString();
                CambioDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CambioDetalle.TipoOper = 4; //Consultar
                CambioDetallelist.Add(CambioDetalle);
            }
            reader.Close();
            reader.Dispose();
            return CambioDetallelist;
        }
    }
}
