using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class MovimientoAlmacenDetalleBL
    {
        public List<MovimientoAlmacenDetalleBE> ListaTodosActivo(int IdEmpresa, int IdMovimientoAlmacen)
        {
            try
            {
                MovimientoAlmacenDetalleDL MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                return MovimientoAlmacenDetalle.ListaTodosActivo(IdEmpresa, IdMovimientoAlmacen);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoAlmacenDetalleBE> ListaTodosActivoChequeo(int IdMovimientoAlmacen)
        {
            try
            {
                MovimientoAlmacenDetalleDL MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                return MovimientoAlmacenDetalle.ListaTodosActivoChequeo(IdMovimientoAlmacen);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoAlmacenDetalleBE> ListaNumero(int IdEmpresa, int Periodo, int IdTipoMovimiento, string Numero)
        {
            try
            {
                MovimientoAlmacenDetalleDL MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                return MovimientoAlmacenDetalle.ListaNumero(IdEmpresa, Periodo, IdTipoMovimiento, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoAlmacenDetalleBE> ListaNumeroDocumento(int IdEmpresa, int Periodo, int IdTipoMovimiento, string Numero)
        {
            try
            {
                MovimientoAlmacenDetalleDL MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                return MovimientoAlmacenDetalle.ListaNumeroDocumento(IdEmpresa, Periodo, IdTipoMovimiento, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(MovimientoAlmacenDetalleBE pItem)
        {
            try
            {
                MovimientoAlmacenDetalleDL MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                MovimientoAlmacenDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(MovimientoAlmacenDetalleBE pItem)
        {
            try
            {
                MovimientoAlmacenDetalleDL MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                MovimientoAlmacenDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void ActualizaChequeo(List<MovimientoAlmacenDetalleBE> pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    MovimientoAlmacenDetalleDL MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();

                    foreach (MovimientoAlmacenDetalleBE item in pItem)
                    {
                        MovimientoAlmacenDetalle.ActualizaChequeo(item.IdMovimientoAlmacenDetalle, item.CantidadChequeo);
                    }

                    ts.Complete();

                    //return IdPedido;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(MovimientoAlmacenDetalleBE pItem, int IdTipoMovimiento, int IdAlmacen)
        {
            try
            {
                //Eliminar el detalle del movimiento de almacen
                MovimientoAlmacenDetalleDL MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                MovimientoAlmacenDetalle.Elimina(pItem);

                if (IdTipoMovimiento == Parametros.intTipMovIngreso) //Nota de Ingreso)
                {
                    //Actualizar Stock
                    StockBE objE_Stock = new StockBE();
                    objE_Stock.IdEmpresa = pItem.IdEmpresa;
                    objE_Stock.IdAlmacen = IdAlmacen;
                    objE_Stock.IdProducto = pItem.IdProducto;
                    objE_Stock.ValorIncrementa = 0;
                    objE_Stock.ValorDescuenta = pItem.Cantidad;
                    objE_Stock.Usuario = pItem.Usuario;
                    objE_Stock.Maquina = pItem.Maquina;

                    StockDL objDL_Stock = new StockDL();
                    objDL_Stock.ActualizaCantidades(objE_Stock);
                }
                else //Nota de Salida
                {
                    //Actualizar Stock
                    StockBE objE_Stock = new StockBE();
                    objE_Stock.IdEmpresa = pItem.IdEmpresa;
                    objE_Stock.IdAlmacen = IdAlmacen;
                    objE_Stock.IdProducto = pItem.IdProducto;
                    objE_Stock.ValorIncrementa = pItem.Cantidad;
                    objE_Stock.ValorDescuenta = 0;
                    objE_Stock.Usuario = pItem.Usuario;
                    objE_Stock.Maquina = pItem.Maquina;

                    StockDL objDL_Stock = new StockDL();
                    objDL_Stock.ActualizaCantidades(objE_Stock);
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
