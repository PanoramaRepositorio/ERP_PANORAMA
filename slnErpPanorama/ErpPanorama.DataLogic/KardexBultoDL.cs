using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class KardexBultoDL
    {
        public KardexBultoDL() { }

        public Int32 Inserta(KardexBultoBE pItem)
        {
            Int32 intIdKardexBulto = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_KardexBulto_Inserta");

            db.AddOutParameter(dbCommand, "pIdKardexBulto", DbType.Int32, pItem.IdKardexBulto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pFechaMovimiento", DbType.DateTime, pItem.FechaMovimiento);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdBulto", DbType.Int32, pItem.IdBulto);
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

            intIdKardexBulto = (int)db.GetParameterValue(dbCommand, "pIdKardexBulto");

            return intIdKardexBulto;
        }

        public void Actualiza(KardexBultoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_KardexBulto_Actualiza");

            db.AddInParameter(dbCommand, "pIdKardexBulto", DbType.Int32, pItem.IdKardexBulto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pFechaMovimiento", DbType.DateTime, pItem.FechaMovimiento);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdBulto", DbType.Int32, pItem.IdBulto);
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

        public void Elimina(KardexBultoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_KardexBulto_Elimina");

            db.AddInParameter(dbCommand, "pIdKardexBulto", DbType.Int32, pItem.IdKardexBulto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdKardexBulto);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<KardexBultoBE> ListaTodosActivo(int IdEmpresa, int IdAlmacen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_KardexBulto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<KardexBultoBE> KardexBultolist = new List<KardexBultoBE>();
            KardexBultoBE KardexBulto;
            while (reader.Read())
            {
                KardexBulto = new KardexBultoBE();
                KardexBulto.IdKardexBulto = Int32.Parse(reader["IdKardexBulto"].ToString());
                KardexBulto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                KardexBulto.Periodo = Int32.Parse(reader["Periodo"].ToString());
                KardexBulto.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                KardexBulto.DescAlmacen = reader["DescAlmacen"].ToString();
                KardexBulto.IdSector = Int32.Parse(reader["IdSector"].ToString());
                KardexBulto.DescSector = reader["DescSector"].ToString();
                KardexBulto.IdBloque = Int32.Parse(reader["IdBloque"].ToString());
                KardexBulto.DescBloque = reader["DescBloque"].ToString();
                KardexBulto.IdBulto = Int32.Parse(reader["IdBulto"].ToString());
                KardexBulto.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                KardexBulto.Observacion = reader["Observacion"].ToString();
                KardexBulto.FechaMovimiento = DateTime.Parse(reader["FechaMovimiento"].ToString());
                KardexBulto.TipoMovimiento = reader["TipoMovimiento"].ToString();
                KardexBulto.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                KardexBulto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                KardexBulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                KardexBultolist.Add(KardexBulto);
            }
            reader.Close();
            reader.Dispose();
            return KardexBultolist;
        }

        public List<KardexBultoBE> ListaInventario(int IdEmpresa, int IdProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_KardexBulto_ListaInventario");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<KardexBultoBE> KardexBultolist = new List<KardexBultoBE>();
            KardexBultoBE KardexBulto;
            while (reader.Read())
            {
                KardexBulto = new KardexBultoBE();
                KardexBulto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                KardexBulto.Periodo = Int32.Parse(reader["Periodo"].ToString());
                KardexBulto.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                KardexBulto.DescAlmacen = reader["DescAlmacen"].ToString();
                KardexBulto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                KardexBulto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                KardexBulto.NombreProducto = reader["NombreProducto"].ToString();
                KardexBulto.Abreviatura = reader["Abreviatura"].ToString();
                KardexBulto.StockBultos = Int32.Parse(reader["StockBultos"].ToString());
                KardexBulto.StockCantidades = Int32.Parse(reader["StockCantidades"].ToString());
                KardexBultolist.Add(KardexBulto);
            }
            reader.Close();
            reader.Dispose();
            return KardexBultolist;
        }

        public List<KardexBultoBE> ListaInventarioDetalle(int IdEmpresa, int IdAlmacen, int IdProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_KardexBulto_ListaInventarioDetalle");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<KardexBultoBE> KardexBultolist = new List<KardexBultoBE>();
            KardexBultoBE KardexBulto;
            while (reader.Read())
            {
                KardexBulto = new KardexBultoBE();
                KardexBulto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                KardexBulto.Periodo = Int32.Parse(reader["Periodo"].ToString());
                KardexBulto.FechaMovimiento = DateTime.Parse(reader["FechaMovimiento"].ToString());
                KardexBulto.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                KardexBulto.DescAlmacen = reader["DescAlmacen"].ToString();
                KardexBulto.IdBulto = Int32.Parse(reader["IdBulto"].ToString());
                KardexBulto.NumeroBulto = reader["NumeroBulto"].ToString();
                KardexBulto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                KardexBulto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                KardexBulto.NombreProducto = reader["NombreProducto"].ToString();
                KardexBulto.Abreviatura = reader["Abreviatura"].ToString();
                KardexBulto.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                KardexBulto.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                KardexBulto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                KardexBulto.TipoMovimiento = reader["TipoMovimiento"].ToString();
                KardexBulto.Ingresos = Int32.Parse(reader["Ingresos"].ToString());
                KardexBulto.Salidas = Int32.Parse(reader["Salidas"].ToString());
                KardexBulto.Stock = Int32.Parse(reader["Stock"].ToString());
                KardexBultolist.Add(KardexBulto);
            }
            reader.Close();
            reader.Dispose();
            return KardexBultolist;
        }

        public KardexBultoBE SeleccionaCalculaSaldo(int IdEmpresa, int IdAlmacen, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_KardexBulto_SeleccionaCalculaSaldo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            KardexBultoBE KardexBulto = null;
            while (reader.Read())
            {
                KardexBulto = new KardexBultoBE();
                KardexBulto.PrecioCostoPromedio = Decimal.Parse(reader["PrecioCostoPromedio"].ToString());
                KardexBulto.Saldo = Int32.Parse(reader["Saldo"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return KardexBulto;
        }
    }
}
