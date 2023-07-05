using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class TempDescuentoVentaProductoDL
    {
        public TempDescuentoVentaProductoDL() { }

        public void Inserta(TempDescuentoVentaProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TempDescuentoVentaProducto_Inserta");

            db.AddInParameter(dbCommand, "pIdTempDescuentoVentaProducto", DbType.Int32, pItem.IdTempDescuentoVentaProducto);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pPrecioUnitario", DbType.Decimal, pItem.PrecioUnitario);
            db.AddInParameter(dbCommand, "pPrecioVenta", DbType.Decimal, pItem.PrecioVenta);
            db.AddInParameter(dbCommand, "pDescuentoAnterior", DbType.Decimal, pItem.DescuentoAnterior);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pOperacion", DbType.String, pItem.Operacion);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pUsuarioAutoriza", DbType.String, pItem.UsuarioAutoriza);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pMotivo", DbType.String, pItem.Motivo);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(TempDescuentoVentaProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TempDescuentoVentaProducto_Actualiza");

            db.AddInParameter(dbCommand, "pIdTempDescuentoVentaProducto", DbType.Int32, pItem.IdTempDescuentoVentaProducto);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pPrecioVenta", DbType.Decimal, pItem.PrecioVenta);
            db.AddInParameter(dbCommand, "pDescuentoAnterior", DbType.Decimal, pItem.DescuentoAnterior);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pOperacion", DbType.String, pItem.Operacion);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pUsuarioAutoriza", DbType.String, pItem.UsuarioAutoriza);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(TempDescuentoVentaProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TempDescuentoVentaProducto_Elimina");

            db.AddInParameter(dbCommand, "pIdTempDescuentoVentaProducto", DbType.Int32, pItem.IdTempDescuentoVentaProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public int SeleccionaBusquedaCount(int IdEmpresa, int IdTienda, int IdListaPrecio, string pFiltro)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TempDescuentoVentaProducto_SeleccionaBusCount");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdListaPrecio", DbType.Int32, IdListaPrecio);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public List<TempDescuentoVentaProductoBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TempDescuentoVentaProducto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TempDescuentoVentaProductoBE> TempDescuentoVentaProductolist = new List<TempDescuentoVentaProductoBE>();
            TempDescuentoVentaProductoBE TempDescuentoVentaProducto;
            while (reader.Read())
            {
                TempDescuentoVentaProducto = new TempDescuentoVentaProductoBE();
                TempDescuentoVentaProducto.IdTempDescuentoVentaProducto = Int32.Parse(reader["IdTempDescuentoVentaProducto"].ToString());
                TempDescuentoVentaProducto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TempDescuentoVentaProducto.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                TempDescuentoVentaProducto.DescTienda = reader["DescTienda"].ToString();
                TempDescuentoVentaProducto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                TempDescuentoVentaProducto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                TempDescuentoVentaProducto.NombreProducto = reader["nombreProducto"].ToString();
                TempDescuentoVentaProducto.Abreviatura = reader["Abreviatura"].ToString();
                TempDescuentoVentaProducto.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                TempDescuentoVentaProducto.DescuentoAnterior = Decimal.Parse(reader["DescuentoAnterior"].ToString());
                TempDescuentoVentaProducto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                TempDescuentoVentaProducto.Operacion = reader["Operacion"].ToString();
                TempDescuentoVentaProducto.Fecha = DateTime.Parse(reader["Fecha"].ToString()); //reader.IsDBNull(reader.GetOrdinal("Fecha")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("Fecha"));
                TempDescuentoVentaProducto.UsuarioAutoriza = reader["UsuarioAutoriza"].ToString();
                TempDescuentoVentaProducto.Maquina = reader["Maquina"].ToString();
                TempDescuentoVentaProducto.Usuario = reader["Usuario"].ToString();
                TempDescuentoVentaProducto.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                ///TempDescuentoVentaProducto.TipoOper = 4; //Consultar
                TempDescuentoVentaProductolist.Add(TempDescuentoVentaProducto);
            }
            reader.Close();
            reader.Dispose();
            return TempDescuentoVentaProductolist;
        }


        public List<TempDescuentoVentaProductoBE> ListaFecha(int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TempDescuentoVentaProducto_ListaFecha");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TempDescuentoVentaProductoBE> TempDescuentoVentaProductolist = new List<TempDescuentoVentaProductoBE>();
            TempDescuentoVentaProductoBE TempDescuentoVentaProducto;
            while (reader.Read())
            {
                TempDescuentoVentaProducto = new TempDescuentoVentaProductoBE();
                TempDescuentoVentaProducto.IdTempDescuentoVentaProducto = Int32.Parse(reader["IdTempDescuentoVentaProducto"].ToString());
                TempDescuentoVentaProducto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TempDescuentoVentaProducto.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                TempDescuentoVentaProducto.DescTienda = reader["DescTienda"].ToString();
                TempDescuentoVentaProducto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                TempDescuentoVentaProducto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                TempDescuentoVentaProducto.NombreProducto = reader["nombreProducto"].ToString();
                TempDescuentoVentaProducto.Abreviatura = reader["Abreviatura"].ToString();
                TempDescuentoVentaProducto.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                TempDescuentoVentaProducto.DescuentoAnterior = Decimal.Parse(reader["DescuentoAnterior"].ToString());
                TempDescuentoVentaProducto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                TempDescuentoVentaProducto.Operacion = reader["Operacion"].ToString();
                TempDescuentoVentaProducto.Fecha = DateTime.Parse(reader["Fecha"].ToString()); //reader.IsDBNull(reader.GetOrdinal("Fecha")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("Fecha"));
                TempDescuentoVentaProducto.UsuarioAutoriza = reader["UsuarioAutoriza"].ToString();
                TempDescuentoVentaProducto.Maquina = reader["Maquina"].ToString();
                TempDescuentoVentaProducto.Usuario = reader["Usuario"].ToString();
                TempDescuentoVentaProducto.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                TempDescuentoVentaProductolist.Add(TempDescuentoVentaProducto);
            }
            reader.Close();
            reader.Dispose();
            return TempDescuentoVentaProductolist;
        }

    }
}
