using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class InmueblePagoBL
    {
        public List<InmueblePagoBE> ListaTodosActivo(int IdEmpresa, int IdInmueble, int IdCliente)
        {
            try
            {
                InmueblePagoDL InmueblePago = new InmueblePagoDL();
                return InmueblePago.ListaTodosActivo(IdEmpresa, IdInmueble, IdCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InmueblePagoBE> ListaClienteInmueble(DateTime FechaDesde, DateTime FechaHasta, int IdInmueble, int IdCliente)
        {
            try
            {
                InmueblePagoDL InmueblePago = new InmueblePagoDL();
                return InmueblePago.ListaClienteInmueble(FechaDesde, FechaHasta, IdInmueble, IdCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public InmueblePagoBE Selecciona(int IdInmueblePago)
        {
            try
            {
                InmueblePagoDL InmueblePago = new InmueblePagoDL();
                return InmueblePago.Selecciona(IdInmueblePago);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(InmueblePagoBE pItem)
        {
            try
            {
                InmueblePagoDL InmueblePago = new InmueblePagoDL();
                InmueblePago.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(InmueblePagoBE pItem)
        {
            try
            {
                InmueblePagoDL InmueblePago = new InmueblePagoDL();
                InmueblePago.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(InmueblePagoBE pItem)
        {
            try
            {
                InmueblePagoDL InmueblePago = new InmueblePagoDL();
                InmueblePago.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
