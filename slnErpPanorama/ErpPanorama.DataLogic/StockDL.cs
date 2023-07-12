using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class StockDL
    {
        public StockDL() { }

        /// <summary>
        /// Inserta un nuevo registro en la tabla Stock con los datos proporcionados en el objeto StockBE.
        /// </summary>
        /// <param name="pItem">Objeto StockBE que contiene los datos a insertar.</param>
        public void Inserta(StockBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_Inserta");

            db.AddInParameter(dbCommand, "pIdStock", DbType.Int32, pItem.IdStock);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecioCostoPromedio", DbType.Decimal, pItem.PrecioCostoPromedio);
            db.AddInParameter(dbCommand, "pCostoTotal", DbType.Decimal, pItem.CostoTotal);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(StockBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_Actualiza");

            db.AddInParameter(dbCommand, "pIdStock", DbType.Int32, pItem.IdStock);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecioCostoPromedio", DbType.Decimal, pItem.PrecioCostoPromedio);
            db.AddInParameter(dbCommand, "pCostoTotal", DbType.Decimal, pItem.CostoTotal);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCantidades(StockBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_ActualizaCantidades");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pValorIncrementa", DbType.Int32, pItem.ValorIncrementa);
            db.AddInParameter(dbCommand, "pValorDescuenta", DbType.Int32, pItem.ValorDescuenta);
            db.AddInParameter(dbCommand, "pPrecioCostoPromedio", DbType.Decimal, pItem.PrecioCostoPromedio);
            db.AddInParameter(dbCommand, "pCostoTotal", DbType.Decimal, pItem.CostoTotal);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCantidadesSubAlmacen(StockBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_ActualizaCantidadesSubAlmacen");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pValorIncrementa", DbType.Int32, pItem.ValorIncrementa);
            db.AddInParameter(dbCommand, "pValorDescuenta", DbType.Int32, pItem.ValorDescuenta);
            db.AddInParameter(dbCommand, "pPrecioCostoPromedio", DbType.Decimal, pItem.PrecioCostoPromedio);
            db.AddInParameter(dbCommand, "pCostoTotal", DbType.Decimal, pItem.CostoTotal);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(StockBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_Elimina");

            db.AddInParameter(dbCommand, "pIdStock", DbType.Int32, pItem.IdStock);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<StockBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int IdAlmacen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<StockBE> Stocklist = new List<StockBE>();
            StockBE Stock;
            while (reader.Read())
            {
                Stock = new StockBE();
                Stock.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Stock.IdStock = Int32.Parse(reader["idStock"].ToString());
                Stock.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Stock.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Stock.DescTienda = reader["DescTienda"].ToString();
                Stock.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Stock.PrecioCostoPromedio = Decimal.Parse(reader["precioCostoPromedio"].ToString());
                Stock.CostoTotal = Decimal.Parse(reader["costoTotal"].ToString());
                Stock.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Stock.DescAlmacen = reader["DescAlmacen"].ToString();
                Stock.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Stock.NombreProducto = reader["NombreProducto"].ToString();
                Stock.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Stocklist.Add(Stock);
            }
            reader.Close();
            reader.Dispose();
            return Stocklist;
        }

        public List<StockBE> ListaProducto(int IdEmpresa, int IdTienda, int IdAlmacen, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_ListaProducto");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<StockBE> Stocklist = new List<StockBE>();
            StockBE Stock;
            while (reader.Read())
            {
                Stock = new StockBE();
                Stock.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Stock.IdStock = Int32.Parse(reader["idStock"].ToString());
                Stock.Periodo = Int32.Parse(reader["periodo"].ToString());
                Stock.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Stock.DescTienda = reader["DescTienda"].ToString();
                Stock.IdAlmacen = Int32.Parse(reader["idAlmacen"].ToString());
                Stock.DescAlmacen = reader["descAlmacen"].ToString();
                Stock.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Stock.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Stock.NombreProducto = reader["NombreProducto"].ToString();
                Stock.Abreviatura = reader["Abreviatura"].ToString();
                Stock.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Stock.PrecioCostoPromedio = Decimal.Parse(reader["PrecioCostoPromedio"].ToString());
                Stock.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                Stock.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Stocklist.Add(Stock);
            }
            reader.Close();
            reader.Dispose();
            return Stocklist;
        }

        public List<StockBE> ListaProductoTienda(int IdEmpresa, int IdTienda, int IdAlmacen, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_ListaProductoTienda");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<StockBE> Stocklist = new List<StockBE>();
            StockBE Stock;
            while (reader.Read())
            {
                Stock = new StockBE();
                Stock.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Stock.IdStock = Int32.Parse(reader["idStock"].ToString());
                Stock.Periodo = Int32.Parse(reader["periodo"].ToString());
                Stock.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Stock.DescTienda = reader["DescTienda"].ToString();
                Stock.IdAlmacen = Int32.Parse(reader["idAlmacen"].ToString());
                Stock.DescAlmacen = reader["descAlmacen"].ToString();
                Stock.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Stock.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Stock.NombreProducto = reader["NombreProducto"].ToString();
                Stock.Abreviatura = reader["Abreviatura"].ToString();
                Stock.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Stock.CantidadNS = Int32.Parse(reader["CantidadNS"].ToString());
                Stock.PrecioCostoPromedio = Decimal.Parse(reader["PrecioCostoPromedio"].ToString());
                Stock.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                Stock.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

                //Stock.IdFamiliaProducto = Int32.Parse(reader["IdFamiliaProducto"].ToString());
                //Stock.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                //Stock.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                //Stock.IdMarca = Int32.Parse(reader["IdMarca"].ToString());
                //Stock.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                //Stock.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());

                Stocklist.Add(Stock);
            }
            reader.Close();
            reader.Dispose();
            return Stocklist;
        }

        public List<StockBE> ListaProductoTiendaVenta(int IdEmpresa, int IdTienda, int IdAlmacen, int IdProducto, int IdFormaPago, int IdAlmacenPrincipal)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_ListaProductoTiendaVenta");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, IdFormaPago);
            db.AddInParameter(dbCommand, "pIdAlmacenPrincipal", DbType.Int32, IdAlmacenPrincipal);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<StockBE> Stocklist = new List<StockBE>();
            StockBE Stock;
            while (reader.Read())
            {
                Stock = new StockBE();
                Stock.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Stock.IdStock = Int32.Parse(reader["idStock"].ToString());
                Stock.Periodo = Int32.Parse(reader["periodo"].ToString());
                Stock.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Stock.DescTienda = reader["DescTienda"].ToString();
                Stock.IdAlmacen = Int32.Parse(reader["idAlmacen"].ToString());
                Stock.DescAlmacen = reader["descAlmacen"].ToString();
                Stock.AbrevAlmacen = reader["AbrevAlmacen"].ToString();
                Stock.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Stock.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Stock.PrecioCostoPromedio = Decimal.Parse(reader["PrecioCostoPromedio"].ToString());
                Stock.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                Stock.CantidadPedida = Int32.Parse(reader["CantidadPedida"].ToString());
                Stock.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Stocklist.Add(Stock);
            }
            reader.Close();
            reader.Dispose();
            return Stocklist;
        }

        public List<StockBE> ListaProductoTiendaAutoservicio(int IdEmpresa, int IdTienda, int IdAlmacen, int IdProducto, int IdFormaPago)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_ListaProductoTiendaAutoservicio");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, IdFormaPago);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<StockBE> Stocklist = new List<StockBE>();
            StockBE Stock;
            while (reader.Read())
            {
                Stock = new StockBE();
                Stock.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Stock.IdStock = Int32.Parse(reader["idStock"].ToString());
                Stock.Periodo = Int32.Parse(reader["periodo"].ToString());
                Stock.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Stock.DescTienda = reader["DescTienda"].ToString();
                Stock.IdAlmacen = Int32.Parse(reader["idAlmacen"].ToString());
                Stock.DescAlmacen = reader["descAlmacen"].ToString();
                Stock.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Stock.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Stock.PrecioCostoPromedio = Decimal.Parse(reader["PrecioCostoPromedio"].ToString());
                Stock.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                Stock.CantidadPedida = Int32.Parse(reader["CantidadPedida"].ToString());
                Stock.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Stocklist.Add(Stock);
            }
            reader.Close();
            reader.Dispose();
            return Stocklist;
        }

        public int ListaProductoPrecioBusquedaCount(int IdTienda, int IdAlmacen, string pFiltro)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_ListaProductoPrecioBusCount");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public List<StockBE> ListaProductoPrecio(int IdTienda, int IdAlmacen, string pFiltro, int Pagina, int CantidadRegistro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_ListaProductoPrecio");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<StockBE> Stocklist = new List<StockBE>();
            StockBE Stock;
            while (reader.Read())
            {
                Stock = new StockBE();
                Stock.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Stock.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Stock.IdFamiliaProducto = Int32.Parse(reader["IdFamiliaProducto"].ToString());
                Stock.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                 Stock.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                Stock.IdMarca = Int32.Parse(reader["IdMarca"].ToString());
                Stock.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Stock.NombreProducto = reader["NombreProducto"].ToString();
                Stock.Medida = reader["Medida"].ToString();
                Stock.Abreviatura = reader["Abreviatura"].ToString();
                Stock.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Stock.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Stock.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Stock.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                Stock.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                Stock.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Stock.DescuentoOutlet = Decimal.Parse(reader["DescuentoOutlet"].ToString());
                Stock.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                Stock.DescUbicacion = reader["DescUbicacion"].ToString();
                Stock.DescuentoAB = Decimal.Parse(reader["DescuentoAB"].ToString());
                Stock.FlagDescuentoAB = Boolean.Parse(reader["FlagDescuentoAB"].ToString());
                Stock.FlagAutoservicio = Boolean.Parse(reader["FlagAutoservicio"].ToString());
                Stock.IdProductoArmado = Int32.Parse(reader["IdProductoArmado"].ToString());
                Stock.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                Stock.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Stock.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                Stocklist.Add(Stock);
            }
            reader.Close();
            reader.Dispose();
            return Stocklist;
        }

        public StockBE SeleccionaProductoPrecio(int IdTienda, int IdAlmacen, string CodigoProveedor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_SeleccionaProductoPrecio");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, CodigoProveedor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            StockBE Stock = null;
            while (reader.Read())
            {
                Stock = new StockBE();
                Stock.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Stock.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Stock.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Stock.NombreProducto = reader["NombreProducto"].ToString();
                Stock.Abreviatura = reader["Abreviatura"].ToString();
                Stock.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Stock.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                Stock.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                Stock.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Stock.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                Stock.DescUbicacion = reader["DescUbicacion"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return Stock;
        }

        public StockBE SeleccionaIdProductoPrecio(int IdTienda, int IdAlmacen, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_SeleccionaIdProductoPrecio");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            StockBE Stock = null;
            while (reader.Read())
            {
                Stock = new StockBE();
                Stock.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Stock.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Stock.IdFamiliaProducto = Int32.Parse(reader["IdFamiliaProducto"].ToString());
                Stock.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                 Stock.IdMarca = Int32.Parse(reader["IdMarca"].ToString());
                Stock.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Stock.NombreProducto = reader["NombreProducto"].ToString();
                Stock.Abreviatura = reader["Abreviatura"].ToString();
                  Stock.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                Stock.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Stock.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Stock.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Stock.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                Stock.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                Stock.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Stock.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                Stock.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());
                Stock.DescUbicacion = reader["DescUbicacion"].ToString();
                Stock.DescuentoAB = Decimal.Parse(reader["DescuentoAB"].ToString());
                Stock.DescuentoOutlet = Decimal.Parse(reader["DescuentoOutlet"].ToString());
                Stock.FlagDescuentoAB = Boolean.Parse(reader["FlagDescuentoAB"].ToString());
                Stock.IdProductoArmado = Int32.Parse(reader["IdProductoArmado"].ToString());
                Stock.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                Stock.FlagAutoservicio = Boolean.Parse(reader["FlagAutoservicio"].ToString());
                Stock.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Stock.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Stock;
        }

        public StockBE SeleccionaProductoCodigoBarra(int IdTienda, int IdAlmacen, string CodigoBarra)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_SeleccionaProductoCodigoBarra");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pCodigoBarra", DbType.String, CodigoBarra);

            IDataReader reader = db.ExecuteReader(dbCommand);
            StockBE Stock = null;
            while (reader.Read())
            {
                Stock = new StockBE();
                Stock.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Stock.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Stock.IdFamiliaProducto = Int32.Parse(reader["IdFamiliaProducto"].ToString());
                Stock.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                  Stock.IdMarca = Int32.Parse(reader["IdMarca"].ToString());
                Stock.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Stock.NombreProducto = reader["NombreProducto"].ToString();
                   Stock.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                Stock.Abreviatura = reader["Abreviatura"].ToString();
                Stock.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Stock.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Stock.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Stock.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                Stock.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                Stock.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Stock.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                Stock.DescuentoAB = Decimal.Parse(reader["DescuentoAB"].ToString());
                Stock.DescuentoOutlet = Decimal.Parse(reader["DescuentoOutlet"].ToString());
                Stock.FlagDescuentoAB = Boolean.Parse(reader["FlagDescuentoAB"].ToString());
                Stock.DescUbicacion = reader["DescUbicacion"].ToString();
                Stock.IdProductoArmado = Int32.Parse(reader["IdProductoArmado"].ToString());
                Stock.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                Stock.FlagAutoservicio = Boolean.Parse(reader["FlagAutoservicio"].ToString());
                Stock.Fecha = DateTime .Parse(reader["Fecha"].ToString());
                Stock.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                  Stock.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Stock;
        }

        public StockBE SeleccionaCantidadIdProducto(int IdTienda, int IdAlmacen, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_SeleccionaCantidadIdProducto");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            StockBE Stock = null;
            while (reader.Read())
            {
                Stock = new StockBE();
                Stock.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Stock.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Stock.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Stock.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Stock.IdTipoProducto = Int32.Parse(reader["IdTipoProducto"].ToString());
                Stock.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return Stock;
        }

        public int ListaProductoCostoBusquedaCount(int IdAlmacen, string pFiltro)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_ListaProductoCostoBusCount");
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public List<StockBE> ListaProductoCosto(int IdAlmacen, string pFiltro, int Pagina, int CantidadRegistro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_ListaProductoCosto");
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<StockBE> Stocklist = new List<StockBE>();
            StockBE Stock;
            while (reader.Read())
            {
                Stock = new StockBE();
                Stock.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Stock.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                Stock.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Stock.NombreProducto = reader["NombreProducto"].ToString();
                Stock.Medida = reader["Medida"].ToString();
                Stock.Abreviatura = reader["Abreviatura"].ToString();
                Stock.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Stock.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Stock.CostoUnitarioSoles = Decimal.Parse(reader["CostoUnitarioSoles"].ToString());
                Stock.DescUbicacion = reader["DescUbicacion"].ToString();
                Stocklist.Add(Stock);
            }
            reader.Close();
            reader.Dispose();
            return Stocklist;
        }

        public List<StockBE> ListaProductoTransito(int IdEmpresa, int IdTienda, int IdAlmacen, int IdProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_ListaProductoTransito");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<StockBE> Stocklist = new List<StockBE>();
            StockBE Stock;
            while (reader.Read())
            {
                Stock = new StockBE();
                Stock.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Stock.Origen = reader["Origen"].ToString();
                Stock.Destino = reader["Destino"].ToString();
                Stock.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Stock.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Stock.NombreProducto = reader["NombreProducto"].ToString();
                Stock.Abreviatura = reader["Abreviatura"].ToString();
                Stock.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Stock.Importe = Decimal.Parse(reader["Importe"].ToString());
                Stocklist.Add(Stock);
            }
            reader.Close();
            reader.Dispose();
            return Stocklist;
        }

        public List<StockBE> ListaProductoTransitoDetalleV2(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
           // reader.IsDBNull(reader.GetOrdinal("FechaHasta")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaHasta"));
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("[usp_Stock_ListaProductoTransitoDetallev2]");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
           // db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
           //  db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            //db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde );
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<StockBE> Stocklist = new List<StockBE>();
            StockBE Stock;
            while (reader.Read())
            {
                Stock = new StockBE();
                Stock.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Stock.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Stock.Origen = reader["Origen"].ToString();
                Stock.DescTipoDocumento = reader["DescTipoDocumento"].ToString();
                Stock.Numero = reader["Numero"].ToString();
                Stock.Destino = reader["Destino"].ToString();
                Stock.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Stock.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Stock.NombreProducto = reader["NombreProducto"].ToString();
                Stock.Abreviatura = reader["Abreviatura"].ToString();
                Stock.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Stock.Importe = Decimal.Parse(reader["Importe"].ToString());
                Stock.DescSituacion= reader["DescSituacion"].ToString();
                Stocklist.Add(Stock);
            }
            reader.Close();
            reader.Dispose();
            return Stocklist;
        }

        public List<StockBE> ListaProductoTransitoV2(int IdEmpresa, int IdProducto)
        {
            
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_ListaProductoTransitov2");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            //db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            //db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<StockBE> Stocklist = new List<StockBE>();
            StockBE Stock;
            while (reader.Read())
            {
       
                Stock = new StockBE();
                Stock.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Stock.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Stock.Origen = reader["Origen"].ToString();
                Stock.DescTipoDocumento = reader["DescTipoDocumento"].ToString();
                Stock.Numero = reader["Numero"].ToString();
                Stock.Destino = reader["Destino"].ToString();
                Stock.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Stock.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Stock.NombreProducto = reader["NombreProducto"].ToString();
                Stock.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Stock.Importe = Decimal.Parse(reader["Importe"].ToString());
                Stock.DescSituacion = reader["DescSituacion"].ToString();
                Stocklist.Add(Stock);

            }
            reader.Close();
            reader.Dispose();
            return Stocklist;
        }


        public List<StockBE> ListaProductoTransitoDetalle(int IdEmpresa, int IdTienda, int IdAlmacen, int IdProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_ListaProductoTransitoDetalle");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<StockBE> Stocklist = new List<StockBE>();
            StockBE Stock;
            while (reader.Read())
            {
                Stock = new StockBE();
                Stock.DescTipoDocumento = reader["DescTipoDocumento"].ToString();
                Stock.Numero = reader["Numero"].ToString();
                Stock.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Stock.DescFormaPago = reader["DescFormaPago"].ToString();
                Stock.Origen = reader["Origen"].ToString();
                Stock.Destino = reader["Destino"].ToString();
                Stock.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Stock.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Stock.NombreProducto = reader["NombreProducto"].ToString();
                Stock.Abreviatura = reader["Abreviatura"].ToString();
                Stock.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Stock.Importe = Decimal.Parse(reader["Importe"].ToString());
                Stock.DescSituacion = reader["DescSituacion"].ToString();
                Stock.DescVendedor = reader["DescVendedor"].ToString();
                Stock.DescCliente = reader["DescCliente"].ToString();
                Stocklist.Add(Stock);
            }
            reader.Close();
            reader.Dispose();
            return Stocklist;
        }


        #region "OUTLET no va"

        //public List<StockBE> ListaProductoPrecio(int IdTienda, int IdAlmacen, string pFiltro, int Pagina, int CantidadRegistro)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_Stock_ListaProductoPrecioOutlet");
        //    db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
        //    db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
        //    db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);
        //    db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
        //    db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);


        //    IDataReader reader = db.ExecuteReader(dbCommand);
        //    List<StockBE> Stocklist = new List<StockBE>();
        //    StockBE Stock;
        //    while (reader.Read())
        //    {
        //        Stock = new StockBE();
        //        Stock.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
        //        Stock.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
        //        Stock.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
        //        Stock.CodigoProveedor = reader["CodigoProveedor"].ToString();
        //        Stock.NombreProducto = reader["NombreProducto"].ToString();
        //        Stock.Abreviatura = reader["Abreviatura"].ToString();
        //        Stock.Cantidad = Int32.Parse(reader["cantidad"].ToString());
        //        Stock.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
        //        Stock.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
        //        Stock.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
        //        Stock.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
        //        Stock.Descuento = Decimal.Parse(reader["Descuento"].ToString());
        //        Stock.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
        //        Stock.DescUbicacion = reader["DescUbicacion"].ToString();
        //        Stock.DescuentoAB = Decimal.Parse(reader["DescuentoAB"].ToString());
        //        Stock.FlagDescuentoAB = Boolean.Parse(reader["FlagDescuentoAB"].ToString());
        //        Stock.FlagAutoservicio = Boolean.Parse(reader["FlagAutoservicio"].ToString());
        //        Stock.IdProductoArmado = Int32.Parse(reader["IdProductoArmado"].ToString());
        //        Stocklist.Add(Stock);
        //    }
        //    reader.Close();
        //    reader.Dispose();
        //    return Stocklist;
        //}
        #endregion
    }
}
