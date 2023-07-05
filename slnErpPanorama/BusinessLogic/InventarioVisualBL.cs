using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class InventarioVisualBL
    {
        public List<InventarioVisualBE> ListaTodosActivo(int IdTienda, int IdModulo)
        {
            try
            {
                InventarioVisualDL InventarioVisual = new InventarioVisualDL();
                return InventarioVisual.ListaTodosActivo(IdTienda, IdModulo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InventarioVisualBE> Lista(int IdTienda, int IdModulo, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                InventarioVisualDL InventarioVisual = new InventarioVisualDL();
                return InventarioVisual.Lista(IdTienda, IdModulo, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InventarioVisualBE> ListaBuscaProducto(int IdProducto)
        {
            try
            {
                InventarioVisualDL InventarioVisual = new InventarioVisualDL();
                return InventarioVisual.ListaBuscaProducto(IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public InventarioVisualBE Selecciona(int IdInventarioVisual)
        {
            try
            {
                InventarioVisualDL InventarioVisual = new InventarioVisualDL();
                return InventarioVisual.Selecciona(IdInventarioVisual);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(InventarioVisualBE pItem)
        {
            try
            {
                InventarioVisualDL InventarioVisual = new InventarioVisualDL();
                InventarioVisual.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(InventarioVisualBE pItem)
        {
            try
            {
                InventarioVisualDL InventarioVisual = new InventarioVisualDL();
                InventarioVisual.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(InventarioVisualBE pItem)
        {
            try
            {
                InventarioVisualDL InventarioVisual = new InventarioVisualDL();
                InventarioVisual.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaDescuentoListaPrecio(int IdInventarioVisual)
        {
            try
            {
                InventarioVisualDL InventarioVisual = new InventarioVisualDL();
                InventarioVisual.ActualizaDescuentoListaPrecio(IdInventarioVisual);
            }
            catch (Exception ex)
            { throw ex; }        
        }

        public void RestableceDescuentoListaPrecio(int IdInventarioVisual)
        {
            try
            {
                InventarioVisualDL InventarioVisual = new InventarioVisualDL();
                InventarioVisual.RestableceDescuentoListaPrecio(IdInventarioVisual);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCompra(int IdTienda, int IdModulo, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                InventarioVisualDL InventarioVisual = new InventarioVisualDL();
                InventarioVisual.ActualizaCompra(IdTienda, IdModulo, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaDescuento(int IdInventarioVisual, decimal DescuentoSugerido)
        {
            try
            {
                InventarioVisualDL InventarioVisual = new InventarioVisualDL();
                InventarioVisual.ActualizaDescuento(IdInventarioVisual, DescuentoSugerido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaDescuentoPorLinea(int IdTienda)
        {
            try
            {
                InventarioVisualDL InventarioVisual = new InventarioVisualDL();
                InventarioVisual.ActualizaDescuentoPorLinea(IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaDescuentoPorCodigo(int IdTienda, int IdProducto, decimal DescuentoSugerido)
        {
            try
            {
                InventarioVisualDL InventarioVisual = new InventarioVisualDL();
                InventarioVisual.ActualizaDescuentoPorCodigo(IdTienda, IdProducto, DescuentoSugerido);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void ActualizaCodigo(List<InventarioVisualBE> pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in pItem)
                    {
                        InventarioVisualDL InventarioVisual = new InventarioVisualDL();
                        InventarioVisual.ActualizaCodigo(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCodigoIdProducto(List<InventarioVisualBE> pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in pItem)
                    {
                        InventarioVisualDL InventarioVisual = new InventarioVisualDL();
                        InventarioVisual.ActualizaCodigoIdProducto(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
