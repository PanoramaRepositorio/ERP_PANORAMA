using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class InventarioAnaquelesBL
    {
        public List<InventarioAnaquelesBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
        {
            try
            {
                InventarioAnaquelesDL InventarioAnaqueles = new InventarioAnaquelesDL();
                return InventarioAnaqueles.ListaTodosActivo(IdEmpresa, IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InventarioAnaquelesBE> ListaTodosActivoUsuario(int IdEmpresa, int IdTienda, int IdAlmacen, int IdPersona, DateTime Fecha)
        {
            try
            {
                InventarioAnaquelesDL InventarioAnaqueles = new InventarioAnaquelesDL();
                return InventarioAnaqueles.ListaTodosActivoUsuario(IdEmpresa, IdTienda, IdAlmacen, IdPersona, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public InventarioAnaquelesBE Selecciona(int IdEmpresa, int IdInventarioAnaqueles)
        {
            try
            {
                InventarioAnaquelesDL InventarioAnaqueles = new InventarioAnaquelesDL();
                return InventarioAnaqueles.Selecciona(IdEmpresa, IdInventarioAnaqueles);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public InventarioAnaquelesBE SeleccionaProducto(int IdEmpresa, int IdProducto)
        {
            try
            {
                InventarioAnaquelesDL InventarioAnaqueles = new InventarioAnaquelesDL();
                return InventarioAnaqueles.SeleccionaProducto(IdEmpresa, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(InventarioAnaquelesBE pItem)
        {
            try
            {
                InventarioAnaquelesDL InventarioAnaqueles = new InventarioAnaquelesDL();
                InventarioAnaqueles.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(InventarioAnaquelesBE pItem)
        {
            try
            {
                InventarioAnaquelesDL InventarioAnaqueles = new InventarioAnaquelesDL();
                InventarioAnaqueles.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(InventarioAnaquelesBE pItem)
        {
            try
            {
                InventarioAnaquelesDL InventarioAnaqueles = new InventarioAnaquelesDL();
                InventarioAnaqueles.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
