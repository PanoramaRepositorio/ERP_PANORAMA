using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class PromocionDL
    {
        public PromocionDL() { }

        public Int32 Inserta(PromocionBE pItem)
        {
            Int32 intIdCliente = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Promocion_Inserta");

            db.AddOutParameter(dbCommand, "pIdPromocion", DbType.Int32, pItem.IdPromocion);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
            db.AddInParameter(dbCommand, "pMontoMin", DbType.Decimal, pItem.MontoMin);
            db.AddInParameter(dbCommand, "pMontoMax", DbType.Decimal, pItem.MontoMax);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);

            intIdCliente = (int)db.GetParameterValue(dbCommand, "pIdPromocion");

            return intIdCliente;
        }

        public void Actualiza(PromocionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Promocion_Actualiza");

            db.AddInParameter(dbCommand, "pIdPromocion", DbType.Int32, pItem.IdPromocion);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
            db.AddInParameter(dbCommand, "pMontoMin", DbType.Decimal, pItem.MontoMin);
            db.AddInParameter(dbCommand, "pMontoMax", DbType.Decimal, pItem.MontoMax);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(PromocionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Promocion_Elimina");

            db.AddInParameter(dbCommand, "pIdPromocion", DbType.Int32, pItem.IdPromocion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<PromocionBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Promocion_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PromocionBE> Promocionlist = new List<PromocionBE>();
            PromocionBE Promocion;
            while (reader.Read())
            {
                Promocion = new PromocionBE();
                Promocion.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Promocion.IdPromocion = Int32.Parse(reader["idPromocion"].ToString());
                Promocion.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                Promocion.DescFormaPago = reader["DescFormaPago"].ToString();
                Promocion.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Promocion.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Promocion.MontoMin = Decimal.Parse(reader["MontoMin"].ToString());
                Promocion.MontoMax = Decimal.Parse(reader["MontoMax"].ToString());
                Promocion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Promocionlist.Add(Promocion);
            }
            reader.Close();
            reader.Dispose();
            return Promocionlist;
        }

        public int ListaProductoPrecioBusquedaCount(int IdTienda, int IdFormaPago, int IdTipoCliente, decimal Total, string pFiltro)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Promocion_ListaProductoPrecioBusCount");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, IdFormaPago);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, Total);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public List<PromocionBE> ListaProductoPrecio(int IdTienda, int IdFormaPago, int IdTipoCliente, decimal Total, string pFiltro, int Pagina, int CantidadRegistro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Promocion_ListaProductoPrecio");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, IdFormaPago);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, Total);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PromocionBE> ProductoNavidadImportadolist = new List<PromocionBE>();
            PromocionBE ProductoNavidadImportado;
            while (reader.Read())
            {
                ProductoNavidadImportado = new PromocionBE();
                ProductoNavidadImportado.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                ProductoNavidadImportado.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                ProductoNavidadImportado.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                ProductoNavidadImportado.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ProductoNavidadImportado.NombreProducto = reader["NombreProducto"].ToString();
                ProductoNavidadImportado.Abreviatura = reader["Abreviatura"].ToString();
                ProductoNavidadImportado.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                ProductoNavidadImportado.Precio = Decimal.Parse(reader["Precio"].ToString());
                ProductoNavidadImportado.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                ProductoNavidadImportado.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                ProductoNavidadImportado.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                ProductoNavidadImportado.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                ProductoNavidadImportado.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ProductoNavidadImportado.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                ProductoNavidadImportado.DescUbicacion = reader["DescUbicacion"].ToString();
                ProductoNavidadImportadolist.Add(ProductoNavidadImportado);
            }
            reader.Close();
            reader.Dispose();
            return ProductoNavidadImportadolist;
        }



    }
}
