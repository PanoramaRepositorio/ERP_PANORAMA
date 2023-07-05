using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class PedidoDetalleDL
    {
        public PedidoDetalleDL() { }

        public void Inserta(PedidoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdPedidoDetalle", DbType.Int32, pItem.IdPedidoDetalle);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecioUnitario", DbType.Decimal, pItem.PrecioUnitario);
            db.AddInParameter(dbCommand, "pPorcentajeDescuento", DbType.Double, pItem.PorcentajeDescuento);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pPrecioVenta", DbType.Decimal, pItem.PrecioVenta);
            db.AddInParameter(dbCommand, "pValorVenta", DbType.Decimal, pItem.ValorVenta);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
                        db.AddInParameter(dbCommand, "pObsEscala", DbType.String, pItem.ObsEscala);
            db.AddInParameter(dbCommand, "pCodAfeIGV", DbType.String, pItem.CodAfeIGV);
            db.AddInParameter(dbCommand, "pIdKardex", DbType.Int32, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, pItem.IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacenDetalle", DbType.Int32, pItem.IdMovimientoAlmacenDetalle);
             db.AddInParameter(dbCommand, "pFlagFijarDescuento", DbType.Boolean, pItem.FlagFijarDescuento);
            db.AddInParameter(dbCommand, "pFlagMuestra", DbType.Boolean, pItem.FlagMuestra);
            db.AddInParameter(dbCommand, "pFlagRegalo", DbType.Boolean, pItem.FlagRegalo);
            db.AddInParameter(dbCommand, "pFlagBultoCerrado", DbType.Boolean, pItem.FlagBultoCerrado);
            db.AddInParameter(dbCommand, "pIdPromocion", DbType.Int32, pItem.IdPromocion);
                        db.AddInParameter(dbCommand, "pIdPromocion2", DbType.Int32, pItem.IdPromocion2);
            db.AddInParameter(dbCommand, "pDescPromocion", DbType.String, pItem.DescPromocion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(PedidoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdPedidoDetalle", DbType.Int32, pItem.IdPedidoDetalle);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecioUnitario", DbType.Decimal, pItem.PrecioUnitario);
            db.AddInParameter(dbCommand, "pPorcentajeDescuento", DbType.Double, pItem.PorcentajeDescuento);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pPrecioVenta", DbType.Decimal, pItem.PrecioVenta);
            db.AddInParameter(dbCommand, "pValorVenta", DbType.Decimal, pItem.ValorVenta);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
                        db.AddInParameter(dbCommand, "pObsEscala", DbType.String, pItem.ObsEscala);
            db.AddInParameter(dbCommand, "pCodAfeIGV", DbType.String, pItem.CodAfeIGV);
            db.AddInParameter(dbCommand, "pIdKardex", DbType.Int32, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, pItem.IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacenDetalle", DbType.Int32, pItem.IdMovimientoAlmacenDetalle);
            db.AddInParameter(dbCommand, "pFlagMuestra", DbType.Boolean, pItem.FlagMuestra);
            db.AddInParameter(dbCommand, "pFlagRegalo", DbType.Boolean, pItem.FlagRegalo);
            db.AddInParameter(dbCommand, "pFlagBultoCerrado", DbType.Boolean, pItem.FlagBultoCerrado);
             db.AddInParameter(dbCommand, "pFlagFijarDescuento", DbType.Boolean, pItem.FlagFijarDescuento);
            db.AddInParameter(dbCommand, "pIdPromocion", DbType.Int32, pItem.IdPromocion);
            db.AddInParameter(dbCommand, "pDescPromocion", DbType.String, pItem.DescPromocion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaChequeo(int IdPedidoDetalle, int CantidadChequeo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_ActualizaCantidadChequeo");

            db.AddInParameter(dbCommand, "pIdPedidoDetalle", DbType.Int32, IdPedidoDetalle);
            db.AddInParameter(dbCommand, "pCantidadChequeo", DbType.Int32, CantidadChequeo);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaChequeoProducto(int IdPedido, int IdProducto, int CantidadChequeo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_ActualizaCantidadChequeoProducto");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pCantidadChequeo", DbType.Int32, CantidadChequeo);

            db.ExecuteNonQuery(dbCommand);

        }



        public void ActualizaArmado(int IdPedidoDetalle, bool FlagArmado)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_ActualizaArmado");

            db.AddInParameter(dbCommand, "pIdPedidoDetalle", DbType.Int32, IdPedidoDetalle);
            db.AddInParameter(dbCommand, "pFlagArmado", DbType.Int32, FlagArmado);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaEstado(int IdPedido)//, int TipoOperacion)//, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_ActualizaEstado");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            //db.AddInParameter(dbCommand, "pTipoOperacion", DbType.Int32, TipoOperacion); //1 Elimina, 2 Recupera, 3 Recuperatodo
            
            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaPromocion(int IdPedidoDetalle, int? IdPromocion, int IdTipoCliente, int IdProducto, string DescPromocion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_ActualizaPromocion");

            db.AddInParameter(dbCommand, "pIdPedidoDetalle", DbType.Int32, IdPedidoDetalle);
            db.AddInParameter(dbCommand, "pIdPromocion", DbType.Int32, IdPromocion);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pDescPromocion", DbType.String, DescPromocion);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaDescuentoAuditoria(PedidoDetalleBE pItem)//, int TipoOperacion)//, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_ActualizaDescuentoAuditoria");

            db.AddInParameter(dbCommand, "pIdPedidoDetalle", DbType.Int32, pItem.IdPedidoDetalle);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pPrecioVenta", DbType.Decimal, pItem.PrecioVenta);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaPersonaServicio(int IdPedidoDetalle, int IdPersonaServicio)//, int TipoOperacion)//, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_ActualizaPersonaServicio");

            db.AddInParameter(dbCommand, "pIdPedidoDetalle", DbType.Int32, IdPedidoDetalle);
            db.AddInParameter(dbCommand, "pIdPersonaServicio", DbType.Int32, IdPersonaServicio);

            db.ExecuteNonQuery(dbCommand);
        }


        public void Elimina(PedidoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdPedidoDetalle", DbType.Int32, pItem.IdPedidoDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void EliminaSinChequear(PedidoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_PedidoDetalle_EliminaSinChequear");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public List<PedidoDetalleBE> ListaTodosActivoDetalleWeb(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalleWeb_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoDetalleBE> PedidoDetallelist = new List<PedidoDetalleBE>();
            PedidoDetalleBE PedidoDetalle;
            while (reader.Read())
            {
                PedidoDetalle = new PedidoDetalleBE();
                PedidoDetalle.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                PedidoDetalle.IdPedidoDetalle = Int32.Parse(reader["idPedidoDetalle"].ToString());
                PedidoDetalle.Item = Int32.Parse(reader["item"].ToString());
                PedidoDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                PedidoDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                PedidoDetalle.NombreProducto = reader["nombreProducto"].ToString();
                PedidoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PedidoDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.CantidadAnt = Int32.Parse(reader["cantidad"].ToString());  
                PedidoDetalle.CantidadChequeo = Int32.Parse(reader["CantidadChequeo"].ToString());
                PedidoDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                PedidoDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                PedidoDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                PedidoDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                PedidoDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                PedidoDetalle.Observacion = reader["Observacion"].ToString();
                PedidoDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                PedidoDetalle.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                PedidoDetalle.IdAlmacen = reader.IsDBNull(reader.GetOrdinal("IdAlmacen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacen"));
                PedidoDetalle.IdAlmacenOrigen = reader.IsDBNull(reader.GetOrdinal("IdAlmacenOrigen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenOrigen"));
                PedidoDetalle.IdMovimientoAlmacenDetalle = reader.IsDBNull(reader.GetOrdinal("IdMovimientoAlmacenDetalle")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoAlmacenDetalle"));
                //PedidoDetalle.FlagMuestra = Boolean.Parse(reader["FlagMuestra"].ToString());
                //PedidoDetalle.FlagRegalo = Boolean.Parse(reader["FlagRegalo"].ToString());
                //PedidoDetalle.FlagBultoCerrado = Boolean.Parse(reader["FlagBultoCerrado"].ToString());
                PedidoDetalle.IdPromocion = reader.IsDBNull(reader.GetOrdinal("IdPromocion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPromocion"));
                PedidoDetalle.DescPromocion = reader["DescPromocion"].ToString();
                PedidoDetalle.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                PedidoDetalle.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                PedidoDetalle.IdMarca = Int32.Parse(reader["IdMarca"].ToString());
                PedidoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                PedidoDetalle.TipoOper = 4;
                PedidoDetallelist.Add(PedidoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PedidoDetallelist;
        }


        public List<PedidoDetalleBE> ListaTodosActivo(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoDetalleBE> PedidoDetallelist = new List<PedidoDetalleBE>();
            PedidoDetalleBE PedidoDetalle;
            while (reader.Read())
            {
                PedidoDetalle = new PedidoDetalleBE();
                PedidoDetalle.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                PedidoDetalle.IdPedidoDetalle = Int32.Parse(reader["idPedidoDetalle"].ToString());
                PedidoDetalle.Item = Int32.Parse(reader["item"].ToString());
                PedidoDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                PedidoDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                PedidoDetalle.NombreProducto = reader["nombreProducto"].ToString();
                PedidoDetalle.Medida = reader["Medida"].ToString();
                PedidoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PedidoDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.CantidadAnt = Int32.Parse(reader["cantidad"].ToString()); //ADD
                PedidoDetalle.CantidadChequeo = Int32.Parse(reader["CantidadChequeo"].ToString()); 
                PedidoDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                PedidoDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                PedidoDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                PedidoDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                PedidoDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                PedidoDetalle.Observacion = reader["Observacion"].ToString();
                 PedidoDetalle.ObsEscala = reader["ObsEscala"].ToString();
                PedidoDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                PedidoDetalle.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                PedidoDetalle.IdAlmacen = reader.IsDBNull(reader.GetOrdinal("IdAlmacen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacen"));
                PedidoDetalle.IdAlmacenOrigen = reader.IsDBNull(reader.GetOrdinal("IdAlmacenOrigen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenOrigen"));
                PedidoDetalle.IdMovimientoAlmacenDetalle = reader.IsDBNull(reader.GetOrdinal("IdMovimientoAlmacenDetalle")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoAlmacenDetalle"));
                PedidoDetalle.FlagMuestra = Boolean.Parse(reader["FlagMuestra"].ToString());
                PedidoDetalle.FlagRegalo = Boolean.Parse(reader["FlagRegalo"].ToString());
                PedidoDetalle.FlagBultoCerrado = Boolean.Parse(reader["FlagBultoCerrado"].ToString());
                PedidoDetalle.IdPromocion = reader.IsDBNull(reader.GetOrdinal("IdPromocion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPromocion"));
                 PedidoDetalle.IdPromocion2 = reader.IsDBNull(reader.GetOrdinal("IdPromocion2")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPromocion2"));
                PedidoDetalle.DescPromocion = reader["DescPromocion"].ToString();
                PedidoDetalle.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                 PedidoDetalle.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                PedidoDetalle.FlagFijarDescuento = Boolean.Parse(reader["FlagFijarDescuento"].ToString());
                PedidoDetalle.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                PedidoDetalle.IdFamiliaProducto = Int32.Parse(reader["IdFamiliaProducto"].ToString());
                PedidoDetalle.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                PedidoDetalle.IdMarca = Int32.Parse(reader["IdMarca"].ToString());
                 PedidoDetalle.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                PedidoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                PedidoDetalle.TipoOper = 4;
                PedidoDetallelist.Add(PedidoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PedidoDetallelist;
        }

        public List<PedidoDetalleBE> ListaTodosActivoWeb(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalleWeb_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoDetalleBE> PedidoDetallelist = new List<PedidoDetalleBE>();
            PedidoDetalleBE PedidoDetalle;
            while (reader.Read())
            {
                PedidoDetalle = new PedidoDetalleBE();
                PedidoDetalle.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                PedidoDetalle.IdPedidoDetalle = Int32.Parse(reader["idPedidoDetalle"].ToString());
                PedidoDetalle.Item = Int32.Parse(reader["item"].ToString());
                PedidoDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                PedidoDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                PedidoDetalle.NombreProducto = reader["nombreProducto"].ToString();
                PedidoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PedidoDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.CantidadAnt = Int32.Parse(reader["cantidad"].ToString()); //ADD
                PedidoDetalle.CantidadChequeo = Int32.Parse(reader["CantidadChequeo"].ToString());
                PedidoDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                PedidoDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                PedidoDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                PedidoDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                PedidoDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                PedidoDetalle.Observacion = reader["Observacion"].ToString();
                PedidoDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                PedidoDetalle.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                PedidoDetalle.IdAlmacen = reader.IsDBNull(reader.GetOrdinal("IdAlmacen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacen"));
                PedidoDetalle.IdAlmacenOrigen = reader.IsDBNull(reader.GetOrdinal("IdAlmacenOrigen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenOrigen"));
                PedidoDetalle.IdMovimientoAlmacenDetalle = reader.IsDBNull(reader.GetOrdinal("IdMovimientoAlmacenDetalle")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoAlmacenDetalle"));
                PedidoDetalle.FlagMuestra = Boolean.Parse(reader["FlagMuestra"].ToString());
                PedidoDetalle.FlagRegalo = Boolean.Parse(reader["FlagRegalo"].ToString());
                PedidoDetalle.FlagBultoCerrado = Boolean.Parse(reader["FlagBultoCerrado"].ToString());
                PedidoDetalle.IdPromocion = reader.IsDBNull(reader.GetOrdinal("IdPromocion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPromocion"));
                PedidoDetalle.DescPromocion = reader["DescPromocion"].ToString();
                PedidoDetalle.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                PedidoDetalle.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                PedidoDetalle.IdMarca = Int32.Parse(reader["IdMarca"].ToString());
                PedidoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                PedidoDetalle.TipoOper = 4;
                PedidoDetallelist.Add(PedidoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PedidoDetallelist;
        }

        public List<PedidoDetalleBE> ListaTodosActivo_ConsultaWeb(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_ConsultaWeb_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoDetalleBE> PedidoDetallelist = new List<PedidoDetalleBE>();
            PedidoDetalleBE PedidoDetalle;
            while (reader.Read())
            {
                PedidoDetalle = new PedidoDetalleBE();
                PedidoDetalle.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                PedidoDetalle.IdPedidoDetalle = Int32.Parse(reader["idPedidoDetalle"].ToString());
                PedidoDetalle.Item = Int32.Parse(reader["item"].ToString());
                PedidoDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                PedidoDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                PedidoDetalle.NombreProducto = reader["nombreProducto"].ToString();
                PedidoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PedidoDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.CantidadAnt = Int32.Parse(reader["cantidad"].ToString()); //ADD
                PedidoDetalle.CantidadChequeo = Int32.Parse(reader["CantidadChequeo"].ToString());
                PedidoDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                PedidoDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                PedidoDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                PedidoDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                PedidoDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                PedidoDetalle.Observacion = reader["Observacion"].ToString();
                PedidoDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                PedidoDetalle.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                PedidoDetalle.IdAlmacen = reader.IsDBNull(reader.GetOrdinal("IdAlmacen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacen"));
                PedidoDetalle.IdAlmacenOrigen = reader.IsDBNull(reader.GetOrdinal("IdAlmacenOrigen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenOrigen"));
                PedidoDetalle.IdMovimientoAlmacenDetalle = reader.IsDBNull(reader.GetOrdinal("IdMovimientoAlmacenDetalle")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoAlmacenDetalle"));
                PedidoDetalle.FlagMuestra = Boolean.Parse(reader["FlagMuestra"].ToString());
                PedidoDetalle.FlagRegalo = Boolean.Parse(reader["FlagRegalo"].ToString());
                PedidoDetalle.FlagBultoCerrado = Boolean.Parse(reader["FlagBultoCerrado"].ToString());
                PedidoDetalle.IdPromocion = reader.IsDBNull(reader.GetOrdinal("IdPromocion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPromocion"));
                PedidoDetalle.DescPromocion = reader["DescPromocion"].ToString();
                PedidoDetalle.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                PedidoDetalle.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                PedidoDetalle.IdMarca = Int32.Parse(reader["IdMarca"].ToString());
                PedidoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                PedidoDetalle.TipoOper = 4;
                PedidoDetallelist.Add(PedidoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PedidoDetallelist;
        }


        public List<PedidoDetalleBE> ListaTodosActivoChequeo(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_ListaTodosActivoChequeo");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoDetalleBE> PedidoDetallelist = new List<PedidoDetalleBE>();
            PedidoDetalleBE PedidoDetalle;
            while (reader.Read())
            {
                PedidoDetalle = new PedidoDetalleBE();
                PedidoDetalle.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                PedidoDetalle.IdPedidoDetalle = Int32.Parse(reader["idPedidoDetalle"].ToString());
                PedidoDetalle.Item = Int32.Parse(reader["item"].ToString());
                PedidoDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                PedidoDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                PedidoDetalle.NombreProducto = reader["nombreProducto"].ToString();
                PedidoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PedidoDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.CantidadChequeo = Int32.Parse(reader["CantidadChequeo"].ToString());
                PedidoDetalle.CantidadAnt = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                PedidoDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                PedidoDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                PedidoDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                PedidoDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                PedidoDetalle.Observacion = reader["Observacion"].ToString();
                PedidoDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                PedidoDetalle.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                PedidoDetalle.IdAlmacen = reader.IsDBNull(reader.GetOrdinal("IdAlmacen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacen"));
                PedidoDetalle.FlagMuestra = Boolean.Parse(reader["FlagMuestra"].ToString());
                PedidoDetalle.FlagRegalo = Boolean.Parse(reader["FlagRegalo"].ToString());
                PedidoDetalle.IdPromocion = reader.IsDBNull(reader.GetOrdinal("IdPromocion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPromocion"));
                PedidoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                PedidoDetalle.TipoOper = 4;
                PedidoDetallelist.Add(PedidoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PedidoDetallelist;
        }

        public List<PedidoDetalleBE> ListaTodosActivoChequeoProducto(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_ListaTodosActivoChequeoProducto");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoDetalleBE> PedidoDetallelist = new List<PedidoDetalleBE>();
            PedidoDetalleBE PedidoDetalle;
            while (reader.Read())
            {
                PedidoDetalle = new PedidoDetalleBE();
                PedidoDetalle.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                //PedidoDetalle.IdPedidoDetalle = Int32.Parse(reader["idPedidoDetalle"].ToString());
                PedidoDetalle.Item = Int32.Parse(reader["item"].ToString());
                PedidoDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                PedidoDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                PedidoDetalle.NombreProducto = reader["nombreProducto"].ToString();
                PedidoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PedidoDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.CantidadChequeo = Int32.Parse(reader["CantidadChequeo"].ToString());
                PedidoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                PedidoDetalle.TipoOper = 4;
                PedidoDetallelist.Add(PedidoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PedidoDetallelist;
        }

        public List<PedidoDetalleBE> ListaTotalMarca(int IdPedido, int TipoConsulta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_ListaTotalMarca");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            db.AddInParameter(dbCommand, "pTipoConsulta", DbType.Int32, TipoConsulta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoDetalleBE> PedidoDetallelist = new List<PedidoDetalleBE>();
            PedidoDetalleBE PedidoDetalle;
            while (reader.Read())
            {
                PedidoDetalle = new PedidoDetalleBE();
                //PedidoDetalle.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                PedidoDetalle.IdMarca = Int32.Parse(reader["IdMarca"].ToString());
                PedidoDetalle.ValorVenta = Int32.Parse(reader["ValorVenta"].ToString());
                PedidoDetallelist.Add(PedidoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PedidoDetallelist;
        }


        public List<PedidoDetalleBE> ListaTodosActivoInstalacion(int IdHojaInstalacion, int TipoConsulta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_ListaTodosActivoInstalacion");
            db.AddInParameter(dbCommand, "pIdHojaInstalacion", DbType.Int32, IdHojaInstalacion);
            db.AddInParameter(dbCommand, "pTipoConsulta", DbType.Int32, TipoConsulta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoDetalleBE> PedidoDetallelist = new List<PedidoDetalleBE>();
            PedidoDetalleBE PedidoDetalle;
            while (reader.Read())
            {
                PedidoDetalle = new PedidoDetalleBE();
                PedidoDetalle.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                PedidoDetalle.IdPedidoDetalle = Int32.Parse(reader["IdPedidoDetalle"].ToString());
                PedidoDetalle.Item = Int32.Parse(reader["item"].ToString());
                PedidoDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                PedidoDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                PedidoDetalle.NombreProducto = reader["nombreProducto"].ToString();
                PedidoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PedidoDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.CantidadChequeo = Int32.Parse(reader["CantidadChequeo"].ToString());
                PedidoDetalle.CantidadAnt = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                PedidoDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                PedidoDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                PedidoDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                PedidoDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                PedidoDetalle.Observacion = reader["Observacion"].ToString();
                PedidoDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                PedidoDetalle.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                PedidoDetalle.IdAlmacen = reader.IsDBNull(reader.GetOrdinal("IdAlmacen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacen"));
                PedidoDetalle.FlagMuestra = Boolean.Parse(reader["FlagMuestra"].ToString());
                PedidoDetalle.FlagRegalo = Boolean.Parse(reader["FlagRegalo"].ToString());
                PedidoDetalle.IdPromocion = reader.IsDBNull(reader.GetOrdinal("IdPromocion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPromocion"));
                PedidoDetalle.IdPersonaServicio = reader.IsDBNull(reader.GetOrdinal("IdPersonaServicio")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPersonaServicio"));
                PedidoDetalle.DescInstalador = reader["DescInstalador"].ToString();
                PedidoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                PedidoDetalle.TipoOper = 4;
                PedidoDetallelist.Add(PedidoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PedidoDetallelist;
        }

        public List<PedidoDetalleBE> ListaTodosActivoInstalacionPedido(int IdPedido, int TipoConsulta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_ListaTodosActivoInstalacionPedido");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            db.AddInParameter(dbCommand, "pTipoConsulta", DbType.Int32, TipoConsulta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoDetalleBE> PedidoDetallelist = new List<PedidoDetalleBE>();
            PedidoDetalleBE PedidoDetalle;
            while (reader.Read())
            {
                PedidoDetalle = new PedidoDetalleBE();
                PedidoDetalle.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                PedidoDetalle.IdPedidoDetalle = Int32.Parse(reader["IdPedidoDetalle"].ToString());
                PedidoDetalle.Item = Int32.Parse(reader["item"].ToString());
                PedidoDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                PedidoDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                PedidoDetalle.NombreProducto = reader["nombreProducto"].ToString();
                PedidoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PedidoDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.CantidadChequeo = Int32.Parse(reader["CantidadChequeo"].ToString());
                PedidoDetalle.CantidadAnt = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                PedidoDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                PedidoDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                PedidoDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                PedidoDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                PedidoDetalle.Observacion = reader["Observacion"].ToString();
                PedidoDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                PedidoDetalle.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                PedidoDetalle.IdAlmacen = reader.IsDBNull(reader.GetOrdinal("IdAlmacen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacen"));
                PedidoDetalle.FlagMuestra = Boolean.Parse(reader["FlagMuestra"].ToString());
                PedidoDetalle.FlagRegalo = Boolean.Parse(reader["FlagRegalo"].ToString());
                PedidoDetalle.IdPromocion = reader.IsDBNull(reader.GetOrdinal("IdPromocion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPromocion"));
                PedidoDetalle.IdPersonaServicio = reader.IsDBNull(reader.GetOrdinal("IdPersonaServicio")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPersonaServicio"));
                PedidoDetalle.DescInstalador = reader["DescInstalador"].ToString();
                PedidoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                PedidoDetalle.TipoOper = 4;
                PedidoDetallelist.Add(PedidoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PedidoDetallelist;
        }

        public List<PedidoDetalleBE> ListaTodos(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_ListaTodos");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoDetalleBE> PedidoDetallelist = new List<PedidoDetalleBE>();
            PedidoDetalleBE PedidoDetalle;
            while (reader.Read())
            {
                PedidoDetalle = new PedidoDetalleBE();
                PedidoDetalle.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                PedidoDetalle.IdPedidoDetalle = Int32.Parse(reader["idPedidoDetalle"].ToString());
                PedidoDetalle.Item = Int32.Parse(reader["item"].ToString());
                PedidoDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                PedidoDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                PedidoDetalle.NombreProducto = reader["nombreProducto"].ToString();
                PedidoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PedidoDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.CantidadAnt = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                PedidoDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                PedidoDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                PedidoDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                PedidoDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                PedidoDetalle.Observacion = reader["Observacion"].ToString();
                PedidoDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                PedidoDetalle.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                PedidoDetalle.IdAlmacen = reader.IsDBNull(reader.GetOrdinal("IdAlmacen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacen"));
                PedidoDetalle.IdAlmacenOrigen = reader.IsDBNull(reader.GetOrdinal("IdAlmacenOrigen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenOrigen"));
                PedidoDetalle.FlagMuestra = Boolean.Parse(reader["FlagMuestra"].ToString());
                PedidoDetalle.FlagRegalo = Boolean.Parse(reader["FlagRegalo"].ToString());
                PedidoDetalle.IdPromocion = reader.IsDBNull(reader.GetOrdinal("IdPromocion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPromocion"));
                PedidoDetalle.DescPromocion = reader["DescPromocion"].ToString();
                PedidoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                PedidoDetalle.TipoOper = 4;
                PedidoDetallelist.Add(PedidoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PedidoDetallelist;
        }

        public List<PedidoDetalleBE> ListaTodosStock(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_ListaTodosStock");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoDetalleBE> PedidoDetallelist = new List<PedidoDetalleBE>();
            PedidoDetalleBE PedidoDetalle;
            while (reader.Read())
            {
                PedidoDetalle = new PedidoDetalleBE();
                PedidoDetalle.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                PedidoDetalle.IdPedidoDetalle = Int32.Parse(reader["idPedidoDetalle"].ToString());
                PedidoDetalle.Item = Int32.Parse(reader["item"].ToString());
                PedidoDetalle.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                PedidoDetalle.IdFamiliaProducto = Int32.Parse(reader["IdFamiliaProducto"].ToString());
                PedidoDetalle.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                PedidoDetalle.IdMarca = Int32.Parse(reader["IdMarca"].ToString());
                PedidoDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                PedidoDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                PedidoDetalle.NombreProducto = reader["nombreProducto"].ToString();
                PedidoDetalle.ObsEscala = reader["ObsEscala"].ToString();
                PedidoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PedidoDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.CantidadAnt = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                PedidoDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                PedidoDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                PedidoDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                PedidoDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                PedidoDetalle.Observacion = reader["Observacion"].ToString();
                PedidoDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                PedidoDetalle.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                PedidoDetalle.IdAlmacen = reader.IsDBNull(reader.GetOrdinal("IdAlmacen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacen"));
                PedidoDetalle.IdAlmacenOrigen = reader.IsDBNull(reader.GetOrdinal("IdAlmacenOrigen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenOrigen"));
                PedidoDetalle.IdMovimientoAlmacenDetalle = reader.IsDBNull(reader.GetOrdinal("IdMovimientoAlmacenDetalle")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoAlmacenDetalle"));
                 PedidoDetalle.FlagFijarDescuento = Boolean.Parse(reader["FlagFijarDescuento"].ToString());
                PedidoDetalle.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                PedidoDetalle.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                PedidoDetalle.FlagMuestra = Boolean.Parse(reader["FlagMuestra"].ToString());
                PedidoDetalle.FlagRegalo = Boolean.Parse(reader["FlagRegalo"].ToString());
                PedidoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                PedidoDetalle.TipoOper = 4;
                PedidoDetallelist.Add(PedidoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PedidoDetallelist;
        }

        public List<PedidoDetalleBE> ListaTodosActivoActualizado(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_ListaTodosActivoActualizado");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoDetalleBE> PedidoDetallelist = new List<PedidoDetalleBE>();
            PedidoDetalleBE PedidoDetalle;
            while (reader.Read())
            {
                PedidoDetalle = new PedidoDetalleBE();
                PedidoDetalle.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                PedidoDetalle.IdPedidoDetalle = Int32.Parse(reader["idPedidoDetalle"].ToString());
                PedidoDetalle.Item = Int32.Parse(reader["item"].ToString());
                PedidoDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                PedidoDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                PedidoDetalle.NombreProducto = reader["nombreProducto"].ToString();
                PedidoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PedidoDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.CantidadAnt = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                PedidoDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                PedidoDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                PedidoDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                PedidoDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                PedidoDetalle.Observacion = reader["Observacion"].ToString();
                PedidoDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                PedidoDetalle.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                PedidoDetalle.IdAlmacen = reader.IsDBNull(reader.GetOrdinal("IdAlmacen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacen"));
                PedidoDetalle.IdAlmacenOrigen = reader.IsDBNull(reader.GetOrdinal("IdAlmacenOrigen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenOrigen"));
                PedidoDetalle.IdMovimientoAlmacenDetalle = reader.IsDBNull(reader.GetOrdinal("IdMovimientoAlmacenDetalle")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoAlmacenDetalle"));
                PedidoDetalle.FlagMuestra = Boolean.Parse(reader["FlagMuestra"].ToString());
                PedidoDetalle.FlagRegalo = Boolean.Parse(reader["FlagRegalo"].ToString());
                PedidoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                PedidoDetalle.TipoOper = 4;
                PedidoDetallelist.Add(PedidoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PedidoDetallelist;
        }

        public List<PedidoDetalleBE> ListaTodosActivoActualizadoStock(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_ListaTodosActivoActualizadoStock");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoDetalleBE> PedidoDetallelist = new List<PedidoDetalleBE>();
            PedidoDetalleBE PedidoDetalle;
            while (reader.Read())
            {
                PedidoDetalle = new PedidoDetalleBE();
                PedidoDetalle.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                PedidoDetalle.IdPedidoDetalle = Int32.Parse(reader["idPedidoDetalle"].ToString());
                PedidoDetalle.Item = Int32.Parse(reader["item"].ToString());
                 PedidoDetalle.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                PedidoDetalle.IdFamiliaProducto = Int32.Parse(reader["IdFamiliaProducto"].ToString());
                PedidoDetalle.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                PedidoDetalle.IdMarca = Int32.Parse(reader["IdMarca"].ToString());
                PedidoDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                PedidoDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                PedidoDetalle.NombreProducto = reader["nombreProducto"].ToString();
                         PedidoDetalle.ObsEscala = reader["ObsEscala"].ToString();
                PedidoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PedidoDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.CantidadAnt = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                PedidoDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                PedidoDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                PedidoDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                PedidoDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                PedidoDetalle.Observacion = reader["Observacion"].ToString();
                PedidoDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                PedidoDetalle.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                PedidoDetalle.IdAlmacen = reader.IsDBNull(reader.GetOrdinal("IdAlmacen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacen"));
                PedidoDetalle.IdAlmacenOrigen = reader.IsDBNull(reader.GetOrdinal("IdAlmacenOrigen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenOrigen"));
                PedidoDetalle.IdMovimientoAlmacenDetalle = reader.IsDBNull(reader.GetOrdinal("IdMovimientoAlmacenDetalle")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoAlmacenDetalle"));
                PedidoDetalle.FlagFijarDescuento = Boolean.Parse(reader["FlagFijarDescuento"].ToString());
                PedidoDetalle.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                PedidoDetalle.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                PedidoDetalle.FlagMuestra = Boolean.Parse(reader["FlagMuestra"].ToString());
                PedidoDetalle.FlagRegalo = Boolean.Parse(reader["FlagRegalo"].ToString());
                PedidoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                PedidoDetalle.TipoOper = 4;
                PedidoDetallelist.Add(PedidoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PedidoDetallelist;
        }

        public List<PedidoDetalleBE> ListaTodosActivoConsignacion(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_ListaTodosActivoConsignacion");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoDetalleBE> PedidoDetallelist = new List<PedidoDetalleBE>();
            PedidoDetalleBE PedidoDetalle;
            while (reader.Read())
            {
                PedidoDetalle = new PedidoDetalleBE();
                PedidoDetalle.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                PedidoDetalle.IdPedidoDetalle = Int32.Parse(reader["idPedidoDetalle"].ToString());
                PedidoDetalle.Item = Int32.Parse(reader["item"].ToString());
                PedidoDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                PedidoDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                PedidoDetalle.NombreProducto = reader["nombreProducto"].ToString();
                PedidoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PedidoDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.CantidadAnt = Int32.Parse(reader["cantidad"].ToString());
                PedidoDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                PedidoDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                PedidoDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                PedidoDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                PedidoDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                PedidoDetalle.Observacion = reader["Observacion"].ToString();
                PedidoDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                PedidoDetalle.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                PedidoDetalle.IdAlmacen = reader.IsDBNull(reader.GetOrdinal("IdAlmacen")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacen"));
                PedidoDetalle.FlagMuestra = Boolean.Parse(reader["FlagMuestra"].ToString());
                PedidoDetalle.FlagRegalo = Boolean.Parse(reader["FlagRegalo"].ToString());
                PedidoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                PedidoDetalle.TipoOper = 4;
                PedidoDetallelist.Add(PedidoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PedidoDetallelist;
        }

        public PedidoDetalleBE SeleccionaPreVentaNavidad(int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_SeleccionaPreventaNavidad");
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PedidoDetalleBE PedidoDetalle = null;
            while (reader.Read())
            {
                PedidoDetalle = new PedidoDetalleBE();
                PedidoDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                PedidoDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return PedidoDetalle;
        }

        public PedidoDetalleBE SeleccionaVariosAlmacenes(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoDetalle_SeleccionaVariosAlmacenes");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PedidoDetalleBE PedidoDetalle = null;
            while (reader.Read())
            {
                PedidoDetalle = new PedidoDetalleBE();
                PedidoDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return PedidoDetalle;
        }

    }
}



