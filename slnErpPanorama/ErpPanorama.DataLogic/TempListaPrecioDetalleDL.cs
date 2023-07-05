using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class TempListaPrecioDetalleDL
    {
        public TempListaPrecioDetalleDL() { }

        //public void Inserta(TempListaPrecioDetalleBE pItem)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_TempListaPrecioDetalle_Inserta");

        //    db.AddInParameter(dbCommand, "pIdTempListaPrecioDetalle", DbType.Int32, pItem.IdTempListaPrecioDetalle);
        //    db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, pItem.IdListaPrecio);
        //    db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
        //    db.AddInParameter(dbCommand, "pPrecioAB", DbType.Decimal, pItem.PrecioAB);
        //    db.AddInParameter(dbCommand, "pPrecioCD", DbType.Decimal, pItem.PrecioCD);
        //    db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
        //    db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
        //    db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
        //    db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
        //    db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

        //    db.ExecuteNonQuery(dbCommand);
        //}

        //public void Actualiza(TempListaPrecioDetalleBE pItem)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_TempListaPrecioDetalle_Actualiza");

        //    db.AddInParameter(dbCommand, "pIdTempListaPrecioDetalle", DbType.Int32, pItem.IdTempListaPrecioDetalle);
        //    db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, pItem.IdListaPrecio);
        //    db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
        //    db.AddInParameter(dbCommand, "pPrecioAB", DbType.Decimal, pItem.PrecioAB);
        //    db.AddInParameter(dbCommand, "pPrecioCD", DbType.Decimal, pItem.PrecioCD);
        //    db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
        //    db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
        //    db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
        //    db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
        //    db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

        //    db.ExecuteNonQuery(dbCommand);
        //}

        //public void Elimina(TempListaPrecioDetalleBE pItem)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_TempListaPrecioDetalle_Elimina");

        //    db.AddInParameter(dbCommand, "pIdTempListaPrecioDetalle", DbType.Int32, pItem.IdTempListaPrecioDetalle);
        //    db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
        //    db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
        //    db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

        //    db.ExecuteNonQuery(dbCommand);
        //}

        //public int SeleccionaBusquedaCount(int IdEmpresa, int IdTienda, int IdListaPrecio,string pFiltro)
        //{
        //    int intRowCount = 0;
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_TempListaPrecioDetalle_SeleccionaBusCount");
        //    db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
        //    db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
        //    db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, IdListaPrecio);
        //    db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

        //    intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
        //    return intRowCount;
        //}

        public List<TempListaPrecioDetalleBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TempListaPrecioDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TempListaPrecioDetalleBE> TempListaPrecioDetallelist = new List<TempListaPrecioDetalleBE>();
            TempListaPrecioDetalleBE TempListaPrecioDetalle;
            while (reader.Read())
            {
                TempListaPrecioDetalle = new TempListaPrecioDetalleBE();
                TempListaPrecioDetalle.DescListaPrecio = reader["DescListaPrecio"].ToString();
                TempListaPrecioDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                TempListaPrecioDetalle.NombreProducto = reader["nombreProducto"].ToString();
                TempListaPrecioDetalle.Abreviatura = reader["Abreviatura"].ToString();
                TempListaPrecioDetalle.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                TempListaPrecioDetalle.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                TempListaPrecioDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                TempListaPrecioDetalle.Operacion = reader["Operacion"].ToString();
                TempListaPrecioDetalle.Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("Fecha"));
                TempListaPrecioDetalle.Maquina = reader["Maquina"].ToString();
                TempListaPrecioDetalle.Usuario = reader["Usuario"].ToString();
                TempListaPrecioDetalle.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                TempListaPrecioDetalle.TipoOper = 4; //Consultar
                TempListaPrecioDetallelist.Add(TempListaPrecioDetalle);
            }
            reader.Close();
            reader.Dispose();
            return TempListaPrecioDetallelist;
        }


        public List<TempListaPrecioDetalleBE> ListaFecha(int IdTienda, DateTime FechaIni, DateTime FechaFin)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TempListaPrecioDetalle_ListaFecha");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaIni);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaFin);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TempListaPrecioDetalleBE> TempListaPrecioDetallelist = new List<TempListaPrecioDetalleBE>();
            TempListaPrecioDetalleBE TempListaPrecioDetalle;
            while (reader.Read())
            {
                TempListaPrecioDetalle = new TempListaPrecioDetalleBE();
                TempListaPrecioDetalle.DescListaPrecio = reader["DescListaPrecio"].ToString();
                TempListaPrecioDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                TempListaPrecioDetalle.NombreProducto = reader["nombreProducto"].ToString();
                TempListaPrecioDetalle.Abreviatura = reader["Abreviatura"].ToString();
                TempListaPrecioDetalle.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                TempListaPrecioDetalle.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                TempListaPrecioDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                TempListaPrecioDetalle.Operacion = reader["Operacion"].ToString();
                TempListaPrecioDetalle.Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("Fecha"));
                TempListaPrecioDetalle.Maquina = reader["Maquina"].ToString();
                TempListaPrecioDetalle.Usuario = reader["Usuario"].ToString();
                TempListaPrecioDetalle.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                TempListaPrecioDetalle.TipoOper = 4; //Consultar
                TempListaPrecioDetallelist.Add(TempListaPrecioDetalle);
            }
            reader.Close();
            reader.Dispose();
            return TempListaPrecioDetallelist;
        }

        //public List<TempListaPrecioDetalleBE> ListaBusqueda(int IdEmpresa, int IdTienda, int IdListaPrecio, string pFiltro, int Pagina, int CantidadRegistro)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_TempListaPrecioDetalle_SeleccionaBus");
        //    db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
        //    db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
        //    db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, IdListaPrecio);
        //    db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
        //    db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);
        //    db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

        //    IDataReader reader = db.ExecuteReader(dbCommand);
        //    List<TempListaPrecioDetalleBE> TempListaPrecioDetallelist = new List<TempListaPrecioDetalleBE>();
        //    TempListaPrecioDetalleBE TempListaPrecioDetalle;
        //    while (reader.Read())
        //    {
        //        TempListaPrecioDetalle = new TempListaPrecioDetalleBE();
        //        TempListaPrecioDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
        //        TempListaPrecioDetalle.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
        //        TempListaPrecioDetalle.IdListaPrecio = Int32.Parse(reader["idListaPrecio"].ToString());
        //        TempListaPrecioDetalle.IdTempListaPrecioDetalle = Int32.Parse(reader["idTempListaPrecioDetalle"].ToString());
        //        TempListaPrecioDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
        //        TempListaPrecioDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
        //        TempListaPrecioDetalle.NombreProducto = reader["nombreProducto"].ToString();
        //        TempListaPrecioDetalle.Abreviatura = reader["Abreviatura"].ToString();
        //        TempListaPrecioDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
        //        TempListaPrecioDetalle.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
        //        TempListaPrecioDetalle.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
        //        TempListaPrecioDetalle.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
        //        TempListaPrecioDetalle.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
        //        TempListaPrecioDetalle.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
        //        TempListaPrecioDetalle.TipoOper = 4; //Consultar
        //        TempListaPrecioDetallelist.Add(TempListaPrecioDetalle);
        //    }
        //    reader.Close();
        //    reader.Dispose();
        //    return TempListaPrecioDetallelist;
        //}

    }
}
