using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class KardexDL
    {
        public KardexDL() { }

        public Int32 Inserta(KardexBE pItem)
        {
            Int32 intIdKardex = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_Inserta");

            db.AddOutParameter(dbCommand, "pIdKardex", DbType.Int32, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pFechaMovimiento", DbType.DateTime, pItem.FechaMovimiento);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.String, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pMontoUnitarioCompra", DbType.Decimal, pItem.MontoUnitarioCompra);
            db.AddInParameter(dbCommand, "pPrecioCostoPromedio", DbType.Decimal, pItem.PrecioCostoPromedio);
            db.AddInParameter(dbCommand, "pMontoTotalCompra", DbType.Decimal, pItem.MontoTotalCompra);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            

            db.ExecuteNonQuery(dbCommand);

            intIdKardex = (int)db.GetParameterValue(dbCommand, "pIdKardex");

            return intIdKardex;
        }

        public void Actualiza(KardexBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_Actualiza");

            db.AddInParameter(dbCommand, "pIdKardex", DbType.Int32, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pFechaMovimiento", DbType.DateTime, pItem.FechaMovimiento);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.String, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pMontoUnitarioCompra", DbType.Decimal, pItem.MontoUnitarioCompra);
            db.AddInParameter(dbCommand, "pPrecioCostoPromedio", DbType.Decimal, pItem.PrecioCostoPromedio);
            db.AddInParameter(dbCommand, "pMontoTotalCompra", DbType.Decimal, pItem.MontoTotalCompra);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(KardexBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_Elimina");

            db.AddInParameter(dbCommand, "pIdKardex", DbType.Int32, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<KardexBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int IdAlmacen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<KardexBE> Kardexlist = new List<KardexBE>();
            KardexBE Kardex;
            while (reader.Read())
            {
                Kardex = new KardexBE();
                Kardex.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Kardex.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Kardex.DescTienda = reader["DescTienda"].ToString();
                Kardex.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Kardex.DescAlmacen = reader["DescAlmacen"].ToString();
                Kardex.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Kardex.IdKardex = Int32.Parse(reader["idKardex"].ToString());
                Kardex.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Kardex.Observacion = reader["Observacion"].ToString();
                Kardex.FechaMovimiento = DateTime.Parse(reader["FechaMovimiento"].ToString());
                Kardex.TipoMovimiento = reader["TipoMovimiento"].ToString();
                Kardex.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Kardex.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Kardex.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Kardexlist.Add(Kardex);
            }
            reader.Close();
            reader.Dispose();
            return Kardexlist;
        }

        public List<KardexBE> ListaTransito(int IdEmpresa, int IdTienda, int IdAlmacen, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_ListaTransito");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<KardexBE> Kardexlist = new List<KardexBE>();
            KardexBE Kardex;
            while (reader.Read())
            {
                Kardex = new KardexBE();
                //Kardex.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                //Kardex.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                //Kardex.DescTienda = reader["DescTienda"].ToString();
                Kardex.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Kardex.DescAlmacen = reader["DescAlmacen"].ToString();
                Kardex.DescAlmacenOrigen = reader["DescAlmacenOrigen"].ToString();
                Kardex.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Kardex.FechaRegistro = reader.IsDBNull(reader.GetOrdinal("FechaRegistro")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRegistro"));
                Kardex.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Kardex.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                Kardex.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Kardex.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Kardex.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Kardex.Observacion = reader["Observacion"].ToString();
                Kardex.TipoMovimiento = reader["TipoMovimiento"].ToString();
                Kardex.Usuario = reader["Usuario"].ToString();
                Kardexlist.Add(Kardex);
            }
            reader.Close();
            reader.Dispose();
            return Kardexlist;
        }

        public List<KardexBE> Selecciona(int IdEmpresa, int IdKardex)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdKardex", DbType.Int32, IdKardex);
           
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<KardexBE> Kardexlist = new List<KardexBE>();
            KardexBE Kardex;
            while (reader.Read())
            {
                Kardex = new KardexBE();
                Kardex.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Kardex.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Kardex.DescTienda = reader["DescTienda"].ToString();
                Kardex.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Kardex.DescAlmacen = reader["DescAlmacen"].ToString();
                Kardex.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Kardex.IdKardex = Int32.Parse(reader["idKardex"].ToString());
                Kardex.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Kardex.Observacion = reader["Observacion"].ToString();
                Kardex.FechaMovimiento = DateTime.Parse(reader["FechaMovimiento"].ToString());
                Kardex.TipoMovimiento = reader["TipoMovimiento"].ToString();
                Kardex.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Kardex.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Kardex.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Kardexlist.Add(Kardex);
            }
            reader.Close();
            reader.Dispose();
            return Kardexlist;
        }

        public List<KardexBE> ListaInventario(int IdEmpresa, int IdAlmacen, int IdProducto, int IdAlmacen2, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_ListaInventario");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pIdAlmacen2", DbType.Int32, IdAlmacen2);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<KardexBE> Kardexlist = new List<KardexBE>();
            KardexBE Kardex;
            while (reader.Read())
            {
                Kardex = new KardexBE();
                Kardex.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Kardex.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Kardex.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Kardex.DescAlmacen = reader["DescAlmacen"].ToString();
                Kardex.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Kardex.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Kardex.NombreProducto = reader["NombreProducto"].ToString();
                Kardex.Abreviatura = reader["Abreviatura"].ToString();
                Kardex.Stock = Int32.Parse(reader["Stock"].ToString());
                Kardex.StockTransito=Int32.Parse(reader["StockTransito"].ToString());
                Kardex.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Kardex.DescUbicacion = reader["DescUbicacion"].ToString();
                Kardex.Stock2 = Int32.Parse(reader["Stock2"].ToString());
                Kardex.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Kardex.CostoPromedio = Decimal.Parse(reader["CostoPromedio"].ToString());
                Kardex.TotalCostoUnitario = Decimal.Parse(reader["TotalCostoUnitario"].ToString());
                Kardex.TotalCostoPromedio = Decimal.Parse(reader["TotalCostoPromedio"].ToString());
                Kardex.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Kardex.FechaRecepcion = DateTime.Parse(reader["FechaRecepcion"].ToString());
                Kardexlist.Add(Kardex);
            }
            reader.Close();
            reader.Dispose();
            return Kardexlist;
        }

        public List<KardexBE> ListaInventarioDetalle(int IdEmpresa, int IdAlmacen, int IdProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_ListaInventarioDetalle");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<KardexBE> Kardexlist = new List<KardexBE>();
            KardexBE Kardex;
            while (reader.Read())
            {
                Kardex = new KardexBE();
                Kardex.IdKardex = Int32.Parse(reader["IdKardex"].ToString());
                Kardex.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Kardex.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Kardex.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Kardex.DescTienda = reader["DescTienda"].ToString();
                Kardex.FechaMovimiento = DateTime.Parse(reader["FechaMovimiento"].ToString());
                Kardex.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Kardex.DescAlmacen = reader["DescAlmacen"].ToString();
                Kardex.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Kardex.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Kardex.NombreProducto = reader["NombreProducto"].ToString();
                Kardex.Abreviatura = reader["Abreviatura"].ToString();
                Kardex.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Kardex.Observacion = reader["Observacion"].ToString();
                Kardex.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                Kardex.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Kardex.TipoMovimiento = reader["TipoMovimiento"].ToString();
                Kardex.Ingresos = Int32.Parse(reader["Ingresos"].ToString());
                Kardex.Salidas = Int32.Parse(reader["Salidas"].ToString());
                Kardex.Stock = Int32.Parse(reader["Stock"].ToString());
                Kardex.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Kardex.Usuario = reader["Usuario"].ToString();
                Kardexlist.Add(Kardex);
            }
            reader.Close();
            reader.Dispose();
            return Kardexlist;
        }

        public List<KardexBE> ListaInventarioDetalle20(int IdEmpresa, int IdAlmacen, int IdProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_ListaInventarioDetalle2020");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<KardexBE> Kardexlist = new List<KardexBE>();
            KardexBE Kardex;
            while (reader.Read())
            {
                Kardex = new KardexBE();
                Kardex.IdKardex = Int32.Parse(reader["IdKardex"].ToString());
                Kardex.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Kardex.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Kardex.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Kardex.DescTienda = reader["DescTienda"].ToString();
                Kardex.FechaMovimiento = DateTime.Parse(reader["FechaMovimiento"].ToString());
                Kardex.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Kardex.DescAlmacen = reader["DescAlmacen"].ToString();
                Kardex.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Kardex.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Kardex.NombreProducto = reader["NombreProducto"].ToString();
                Kardex.Abreviatura = reader["Abreviatura"].ToString();
                Kardex.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Kardex.Observacion = reader["Observacion"].ToString();
                Kardex.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                Kardex.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Kardex.TipoMovimiento = reader["TipoMovimiento"].ToString();
                Kardex.Ingresos = Int32.Parse(reader["Ingresos"].ToString());
                Kardex.Salidas = Int32.Parse(reader["Salidas"].ToString());
                Kardex.Stock = Int32.Parse(reader["Stock"].ToString());
                Kardex.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Kardex.Usuario = reader["Usuario"].ToString();
                Kardexlist.Add(Kardex);
            }
            reader.Close();
            reader.Dispose();
            return Kardexlist;
        }

        public KardexBE SeleccionaCalculaSaldo(int IdEmpresa, int IdTienda, int IdAlmacen, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_SeleccionaCalculaSaldo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            KardexBE Kardex = null;
            while (reader.Read())
            {
                Kardex = new KardexBE();
                Kardex.PrecioCostoPromedio = Decimal.Parse(reader["PrecioCostoPromedio"].ToString());
                Kardex.Saldo = Int32.Parse(reader["Saldo"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Kardex;
        }
    }
}

