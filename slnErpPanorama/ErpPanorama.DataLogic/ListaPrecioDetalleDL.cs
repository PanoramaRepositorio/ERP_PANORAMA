using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ListaPrecioDetalleDL
    {
        public ListaPrecioDetalleDL() { }

        public void Inserta(ListaPrecioDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdListaPrecioDetalle", DbType.Int32, pItem.IdListaPrecioDetalle);
            db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, pItem.IdListaPrecio);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pPrecioAB", DbType.Decimal, pItem.PrecioAB);
            db.AddInParameter(dbCommand, "pPrecioCD", DbType.Decimal, pItem.PrecioCD);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pDescuentoAB", DbType.Decimal, pItem.DescuentoAB);
            db.AddInParameter(dbCommand, "pFlagAutoservicio", DbType.Boolean, pItem.FlagAutoservicio);
            db.AddInParameter(dbCommand, "pFlagDescuentoAB", DbType.Boolean, pItem.FlagDescuentoAB);
            db.AddInParameter(dbCommand, "pTipoCambioCD", DbType.Decimal, pItem.TipoCambioCD);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ListaPrecioDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdListaPrecioDetalle", DbType.Int32, pItem.IdListaPrecioDetalle);
            db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, pItem.IdListaPrecio);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pPrecioAB", DbType.Decimal, pItem.PrecioAB);
            db.AddInParameter(dbCommand, "pPrecioCD", DbType.Decimal, pItem.PrecioCD);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pDescuentoAB", DbType.Decimal, pItem.DescuentoAB);
            db.AddInParameter(dbCommand, "pFlagAutoservicio", DbType.Boolean, pItem.FlagAutoservicio);
            db.AddInParameter(dbCommand, "pFlagDescuentoAB", DbType.Boolean, pItem.FlagDescuentoAB);
            db.AddInParameter(dbCommand, "pTipoCambioCD", DbType.Decimal, pItem.TipoCambioCD);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaMasivo(ListaPrecioDetalleBE pItem)
        {
     
                Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
                DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDetalle_ActualizaMasivo");

                db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, pItem.IdListaPrecio);
                db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
                db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
                db.AddInParameter(dbCommand, "pPrecioAB", DbType.Decimal, pItem.PrecioAB);
                db.AddInParameter(dbCommand, "pPrecioCD", DbType.Decimal, pItem.PrecioCD);
                db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
                db.AddInParameter(dbCommand, "pTipoCambioCD", DbType.Decimal, pItem.TipoCambioCD);
                db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
                db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
                db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

                db.ExecuteNonQuery(dbCommand);
            

        }

        public void ActualizaDescuento(ListaPrecioDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDetalle_ActualizaDescuento");

            db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, pItem.IdListaPrecio);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pFlagDescuentoAB", DbType.Boolean, pItem.FlagDescuentoAB);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaProductoDescuento(ListaPrecioDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDetalle_ActualizaProductoDescuento");

            db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, pItem.IdListaPrecio);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pFlagDescuentoAB", DbType.Boolean, pItem.FlagDescuentoAB);

            db.ExecuteNonQuery(dbCommand);
           
        }

        public void ActualizaProductoDescuentoOutlet(ListaPrecioDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDetalle_ActualizaProductoDescuentoOutlet");

            db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, pItem.IdListaPrecio);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaAutoservicio(ListaPrecioDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDetalle_ActualizaAutoservicio");

            db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, pItem.IdListaPrecio);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pFlagAutoservicio", DbType.Boolean, pItem.FlagAutoservicio);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaProductoAutoservicio(ListaPrecioDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDetalle_ActualizaProductoAutoservicio");

            db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, pItem.IdListaPrecio);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pFlagAutoservicio", DbType.Boolean, pItem.FlagAutoservicio);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaDescuentoMayorista()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDetalle_ActualizaDescuentoMayorista");

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ListaPrecioDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdListaPrecioDetalle", DbType.Int32, pItem.IdListaPrecioDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public int SeleccionaBusquedaCount(int IdEmpresa, int IdTienda, int IdListaPrecio,string pFiltro)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDetalle_SeleccionaBusCount");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, IdListaPrecio);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public List<ListaPrecioDetalleBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int IdListaPrecio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, IdListaPrecio);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ListaPrecioDetalleBE> ListaPrecioDetallelist = new List<ListaPrecioDetalleBE>();
            ListaPrecioDetalleBE ListaPrecioDetalle;
            while (reader.Read())
            {
                ListaPrecioDetalle = new ListaPrecioDetalleBE();
                ListaPrecioDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ListaPrecioDetalle.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                ListaPrecioDetalle.IdListaPrecio = Int32.Parse(reader["idListaPrecio"].ToString());
                ListaPrecioDetalle.IdListaPrecioDetalle = Int32.Parse(reader["idListaPrecioDetalle"].ToString());
                ListaPrecioDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ListaPrecioDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ListaPrecioDetalle.NombreProducto = reader["nombreProducto"].ToString();
                ListaPrecioDetalle.Abreviatura = reader["Abreviatura"].ToString();
                ListaPrecioDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ListaPrecioDetalle.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                ListaPrecioDetalle.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                ListaPrecioDetalle.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                ListaPrecioDetalle.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                ListaPrecioDetalle.TipoCambioCD = Decimal.Parse(reader["TipoCambioCD"].ToString());
                ListaPrecioDetalle.FlagAutoservicio = Boolean.Parse(reader["FlagAutoservicio"].ToString());
                ListaPrecioDetalle.DescuentoAB = Decimal.Parse(reader["DescuentoAB"].ToString());
                ListaPrecioDetalle.FlagDescuentoAB = Boolean.Parse(reader["FlagDescuentoAB"].ToString());
                ListaPrecioDetalle.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                ListaPrecioDetalle.TipoOper = 4; //Consultar
                ListaPrecioDetallelist.Add(ListaPrecioDetalle);
            }
            reader.Close();
            reader.Dispose();
            return ListaPrecioDetallelist;
        }

        public List<ListaPrecioDetalleBE> ListaBusqueda(int IdEmpresa, int IdTienda, int IdListaPrecio, string pFiltro, int Pagina, int CantidadRegistro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDetalle_SeleccionaBus");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, IdListaPrecio);
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ListaPrecioDetalleBE> ListaPrecioDetallelist = new List<ListaPrecioDetalleBE>();
            ListaPrecioDetalleBE ListaPrecioDetalle;
            while (reader.Read())
            {
                ListaPrecioDetalle = new ListaPrecioDetalleBE();
                ListaPrecioDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ListaPrecioDetalle.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                ListaPrecioDetalle.IdListaPrecio = Int32.Parse(reader["idListaPrecio"].ToString());
                ListaPrecioDetalle.IdListaPrecioDetalle = Int32.Parse(reader["idListaPrecioDetalle"].ToString());
                ListaPrecioDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ListaPrecioDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ListaPrecioDetalle.NombreProducto = reader["nombreProducto"].ToString();
                ListaPrecioDetalle.Abreviatura = reader["Abreviatura"].ToString();
                ListaPrecioDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ListaPrecioDetalle.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                ListaPrecioDetalle.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                ListaPrecioDetalle.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                ListaPrecioDetalle.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                ListaPrecioDetalle.TipoCambioCD = Decimal.Parse(reader["TipoCambioCD"].ToString());
                ListaPrecioDetalle.FlagAutoservicio = Boolean.Parse(reader["FlagAutoservicio"].ToString());
                ListaPrecioDetalle.DescuentoAB = Decimal.Parse(reader["DescuentoAB"].ToString());
                ListaPrecioDetalle.FlagDescuentoAB = Boolean.Parse(reader["FlagDescuentoAB"].ToString());
                ListaPrecioDetalle.DescuentoOutlet = Decimal.Parse(reader["DescuentoOutlet"].ToString());
                ListaPrecioDetalle.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                ListaPrecioDetalle.TipoOper = 4; //Consultar
                ListaPrecioDetallelist.Add(ListaPrecioDetalle);
            }
            reader.Close();
            reader.Dispose();
            return ListaPrecioDetallelist;
        }

        public List<ListaPrecioDetalleBE> ListaAutoservicio(int IdEmpresa, int IdTienda, int IdListaPrecio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDetalle_ListaAutoservicio");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, IdListaPrecio);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ListaPrecioDetalleBE> ListaPrecioDetallelist = new List<ListaPrecioDetalleBE>();
            ListaPrecioDetalleBE ListaPrecioDetalle;
            while (reader.Read())
            {
                ListaPrecioDetalle = new ListaPrecioDetalleBE();
                ListaPrecioDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ListaPrecioDetalle.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                ListaPrecioDetalle.IdListaPrecio = Int32.Parse(reader["idListaPrecio"].ToString());
                ListaPrecioDetalle.IdListaPrecioDetalle = Int32.Parse(reader["idListaPrecioDetalle"].ToString());
                ListaPrecioDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ListaPrecioDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ListaPrecioDetalle.NombreProducto = reader["nombreProducto"].ToString();
                ListaPrecioDetalle.Abreviatura = reader["Abreviatura"].ToString();
                ListaPrecioDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ListaPrecioDetalle.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                ListaPrecioDetalle.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                ListaPrecioDetalle.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                ListaPrecioDetalle.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                ListaPrecioDetalle.FlagAutoservicio = Boolean.Parse(reader["FlagAutoservicio"].ToString());
                ListaPrecioDetalle.DescuentoAB = Decimal.Parse(reader["DescuentoAB"].ToString());
                ListaPrecioDetalle.FlagDescuentoAB = Boolean.Parse(reader["FlagDescuentoAB"].ToString());
                ListaPrecioDetalle.AlmacenCentral = Int32.Parse(reader["AlmacenCentral"].ToString());
                ListaPrecioDetalle.AlmacenTienda = Int32.Parse(reader["AlmacenTienda"].ToString());
                ListaPrecioDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ListaPrecioDetalle.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                ListaPrecioDetalle.TipoOper = 4; //Consultar
                ListaPrecioDetallelist.Add(ListaPrecioDetalle);
            }
            reader.Close();
            reader.Dispose();
            return ListaPrecioDetallelist;
        }

        public List<ListaPrecioDetalleBE> ListaTodosAutoservicio(int IdEmpresa, int IdTienda, int IdListaPrecio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListaPrecioDetalle_ListaTodosAutoservicio");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, IdListaPrecio);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ListaPrecioDetalleBE> ListaPrecioDetallelist = new List<ListaPrecioDetalleBE>();
            ListaPrecioDetalleBE ListaPrecioDetalle;
            while (reader.Read())
            {
                ListaPrecioDetalle = new ListaPrecioDetalleBE();
                ListaPrecioDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ListaPrecioDetalle.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                ListaPrecioDetalle.IdListaPrecio = Int32.Parse(reader["idListaPrecio"].ToString());
                ListaPrecioDetalle.IdListaPrecioDetalle = Int32.Parse(reader["idListaPrecioDetalle"].ToString());
                ListaPrecioDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ListaPrecioDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ListaPrecioDetalle.NombreProducto = reader["nombreProducto"].ToString();
                ListaPrecioDetalle.Abreviatura = reader["Abreviatura"].ToString();
                ListaPrecioDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ListaPrecioDetalle.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                ListaPrecioDetalle.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                ListaPrecioDetalle.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                ListaPrecioDetalle.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                ListaPrecioDetalle.FlagAutoservicio = Boolean.Parse(reader["FlagAutoservicio"].ToString());
                ListaPrecioDetalle.DescuentoAB = Decimal.Parse(reader["DescuentoAB"].ToString());
                ListaPrecioDetalle.FlagDescuentoAB = Boolean.Parse(reader["FlagDescuentoAB"].ToString());
                ListaPrecioDetalle.AlmacenCentral = Int32.Parse(reader["AlmacenCentral"].ToString());
                ListaPrecioDetalle.AlmacenTienda = Int32.Parse(reader["AlmacenTienda"].ToString());
                ListaPrecioDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ListaPrecioDetalle.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                ListaPrecioDetalle.TipoOper = 4; //Consultar
                ListaPrecioDetallelist.Add(ListaPrecioDetalle);
            }
            reader.Close();
            reader.Dispose();
            return ListaPrecioDetallelist;
        }
    }
}
