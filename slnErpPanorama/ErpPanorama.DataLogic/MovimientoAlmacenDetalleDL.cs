using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class MovimientoAlmacenDetalleDL
    {
        public MovimientoAlmacenDetalleDL() { }

        public void Inserta(MovimientoAlmacenDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacenDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacenDetalle", DbType.Int32, pItem.IdMovimientoAlmacenDetalle);
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, pItem.IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pCostoUnitario", DbType.Decimal, pItem.CostoUnitario);
            db.AddInParameter(dbCommand, "pMontoTotal", DbType.Decimal, pItem.MontoTotal);
            db.AddInParameter(dbCommand, "pIdKardex", DbType.Decimal, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(MovimientoAlmacenDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacenDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacenDetalle", DbType.Int32, pItem.IdMovimientoAlmacenDetalle);
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, pItem.IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pCostoUnitario", DbType.Decimal, pItem.CostoUnitario);
            db.AddInParameter(dbCommand, "pMontoTotal", DbType.Decimal, pItem.MontoTotal);
            db.AddInParameter(dbCommand, "pIdKardex", DbType.Int32, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(MovimientoAlmacenDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacenDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacenDetalle", DbType.Int32, pItem.IdMovimientoAlmacenDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<MovimientoAlmacenDetalleBE> ListaTodosActivo(int IdEmpresa, int IdMovimientoAlmacen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacenDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, IdMovimientoAlmacen);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoAlmacenDetalleBE> MovimientoAlmacenDetallelist = new List<MovimientoAlmacenDetalleBE>();
            MovimientoAlmacenDetalleBE MovimientoAlmacenDetalle;
            while (reader.Read())
            {
                MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBE();
                MovimientoAlmacenDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = Int32.Parse(reader["idMovimientoAlmacenDetalle"].ToString());
                MovimientoAlmacenDetalle.IdMovimientoAlmacen = Int32.Parse(reader["IdMovimientoAlmacen"].ToString());
                MovimientoAlmacenDetalle.Item = Int32.Parse(reader["Item"].ToString());
                MovimientoAlmacenDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                MovimientoAlmacenDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                MovimientoAlmacenDetalle.NombreProducto = reader["NombreProducto"].ToString();
                MovimientoAlmacenDetalle.Abreviatura = reader["Abreviatura"].ToString();
                MovimientoAlmacenDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                MovimientoAlmacenDetalle.CantidadAnt = Int32.Parse(reader["Cantidad"].ToString());
                MovimientoAlmacenDetalle.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                MovimientoAlmacenDetalle.MontoTotal = Decimal.Parse(reader["MontoTotal"].ToString());
                MovimientoAlmacenDetalle.Observacion = reader["Observacion"].ToString();
                MovimientoAlmacenDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoAlmacenDetalle.TipoOper = 4; //Consultar
                MovimientoAlmacenDetallelist.Add(MovimientoAlmacenDetalle);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenDetallelist;
        }

        public List<MovimientoAlmacenDetalleBE> ListaNumero(int IdEmpresa, int Periodo, int IdTipoMovimiento, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacenDetalle_ListaNumero");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdTipoMovimiento", DbType.Int32, IdTipoMovimiento);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoAlmacenDetalleBE> MovimientoAlmacenDetallelist = new List<MovimientoAlmacenDetalleBE>();
            MovimientoAlmacenDetalleBE MovimientoAlmacenDetalle;
            while (reader.Read())
            {
                MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBE();
                MovimientoAlmacenDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = Int32.Parse(reader["idMovimientoAlmacenDetalle"].ToString());
                MovimientoAlmacenDetalle.IdMovimientoAlmacen = Int32.Parse(reader["IdMovimientoAlmacen"].ToString());
                MovimientoAlmacenDetalle.Item = Int32.Parse(reader["Item"].ToString());
                MovimientoAlmacenDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                MovimientoAlmacenDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                MovimientoAlmacenDetalle.NombreProducto = reader["NombreProducto"].ToString();
                MovimientoAlmacenDetalle.Abreviatura = reader["Abreviatura"].ToString();
                MovimientoAlmacenDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                MovimientoAlmacenDetalle.CantidadAnt = Int32.Parse(reader["Cantidad"].ToString());
                MovimientoAlmacenDetalle.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                MovimientoAlmacenDetalle.MontoTotal = Decimal.Parse(reader["MontoTotal"].ToString());
                MovimientoAlmacenDetalle.Observacion = reader["Observacion"].ToString();
                MovimientoAlmacenDetallelist.Add(MovimientoAlmacenDetalle);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenDetallelist;
        }

        public List<MovimientoAlmacenDetalleBE> ListaNumeroDocumento(int IdEmpresa, int Periodo, int IdTipoMovimiento, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacenDetalle_ListaNumeroDocumento");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdTipoMovimiento", DbType.Int32, IdTipoMovimiento);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoAlmacenDetalleBE> MovimientoAlmacenDetallelist = new List<MovimientoAlmacenDetalleBE>();
            MovimientoAlmacenDetalleBE MovimientoAlmacenDetalle;
            while (reader.Read())
            {
                MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBE();
                MovimientoAlmacenDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = Int32.Parse(reader["idMovimientoAlmacenDetalle"].ToString());
                MovimientoAlmacenDetalle.IdMovimientoAlmacen = Int32.Parse(reader["IdMovimientoAlmacen"].ToString());
                MovimientoAlmacenDetalle.Item = Int32.Parse(reader["Item"].ToString());
                MovimientoAlmacenDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                MovimientoAlmacenDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                MovimientoAlmacenDetalle.NombreProducto = reader["NombreProducto"].ToString();
                MovimientoAlmacenDetalle.Abreviatura = reader["Abreviatura"].ToString();
                MovimientoAlmacenDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                MovimientoAlmacenDetalle.CantidadAnt = Int32.Parse(reader["Cantidad"].ToString());
                MovimientoAlmacenDetalle.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                MovimientoAlmacenDetalle.MontoTotal = Decimal.Parse(reader["MontoTotal"].ToString());
                MovimientoAlmacenDetalle.Observacion = reader["Observacion"].ToString();
                MovimientoAlmacenDetallelist.Add(MovimientoAlmacenDetalle);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenDetallelist;
        }

        public List<MovimientoAlmacenDetalleBE> ListaTodosActivoChequeo(int IdMovimientoAlmacen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacenDetalle_ListaTodosActivoChequeo");
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, IdMovimientoAlmacen);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoAlmacenDetalleBE> MovimientoAlmacenDetallelist = new List<MovimientoAlmacenDetalleBE>();
            MovimientoAlmacenDetalleBE MovimientoAlmacenDetalle;
            while (reader.Read())
            {
                MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBE();
                MovimientoAlmacenDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = Int32.Parse(reader["idMovimientoAlmacenDetalle"].ToString());
                MovimientoAlmacenDetalle.IdMovimientoAlmacen = Int32.Parse(reader["IdMovimientoAlmacen"].ToString());
                MovimientoAlmacenDetalle.Item = Int32.Parse(reader["Item"].ToString());
                MovimientoAlmacenDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                MovimientoAlmacenDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                MovimientoAlmacenDetalle.NombreProducto = reader["NombreProducto"].ToString();
                MovimientoAlmacenDetalle.Abreviatura = reader["Abreviatura"].ToString();
                MovimientoAlmacenDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                MovimientoAlmacenDetalle.CantidadChequeo = Int32.Parse(reader["CantidadChequeo"].ToString());
                MovimientoAlmacenDetalle.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                MovimientoAlmacenDetalle.MontoTotal = Decimal.Parse(reader["MontoTotal"].ToString());
                MovimientoAlmacenDetalle.Observacion = reader["Observacion"].ToString();
                MovimientoAlmacenDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoAlmacenDetalle.TipoOper = 4; //Consultar
                MovimientoAlmacenDetallelist.Add(MovimientoAlmacenDetalle);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenDetallelist;
        }

        public void ActualizaChequeo(int IdMovimientoAlmacenDetalle, int CantidadChequeo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacenDetalle_ActualizaCantidadChequeo");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacenDetalle", DbType.Int32, IdMovimientoAlmacenDetalle);
            db.AddInParameter(dbCommand, "pCantidadChequeo", DbType.Int32, CantidadChequeo);

            db.ExecuteNonQuery(dbCommand);

        }

    }
}
