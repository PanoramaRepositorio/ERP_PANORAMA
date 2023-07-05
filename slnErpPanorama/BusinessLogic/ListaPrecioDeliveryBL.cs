using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ListaPrecioDeliveryBL
    {
        public List<ListaPrecioDeliveryBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ListaPrecioDeliveryDL ListaPrecioDelivery = new ListaPrecioDeliveryDL();
                return ListaPrecioDelivery.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ListaPrecioDeliveryBE> ListaDistrito(string IdDepartamento, string IdProvincia)
        {
            try
            {
                ListaPrecioDeliveryDL ListaPrecioDelivery = new ListaPrecioDeliveryDL();
                return ListaPrecioDelivery.ListaDistrito(IdDepartamento, IdProvincia);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ListaPrecioDeliveryBE Selecciona(int IdListaPrecioDelivery, int IdTienda)
        {
            try
            {
                ListaPrecioDeliveryDL ListaPrecioDelivery = new ListaPrecioDeliveryDL();
                return ListaPrecioDelivery.Selecciona(IdListaPrecioDelivery, IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ListaPrecioDeliveryBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ListaPrecioDeliveryDL ListaPrecioDelivery = new ListaPrecioDeliveryDL();
                    ListaPrecioDelivery.Inserta(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ListaPrecioDeliveryBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ListaPrecioDeliveryDL ListaPrecioDelivery = new ListaPrecioDeliveryDL();
                    ListaPrecioDelivery.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ListaPrecioDeliveryBE pItem)
        {
            try
            {
                ListaPrecioDeliveryDL ListaPrecioDelivery = new ListaPrecioDeliveryDL();
                ListaPrecioDelivery.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
