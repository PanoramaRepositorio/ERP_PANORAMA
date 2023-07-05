using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class MovimientoPedidoDespachobl
    {
        public List<MovimientoPedidoDespachoBE> ListaTodosActivo(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                MovimientoPedidoDespachoDL MovimientoPedidoDespacho = new MovimientoPedidoDespachoDL();
                return MovimientoPedidoDespacho.ListaTodosActivo(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoPedidoDespachoBE> ListaNumero(int Periodo, string Numero)
        {
            try
            {
                MovimientoPedidoDespachoDL MovimientoPedidoDespacho = new MovimientoPedidoDespachoDL();
                return MovimientoPedidoDespacho.ListaNumero(Periodo, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MovimientoPedidoDespachoBE Selecciona(int IdPedido)
        {
            try
            {
                MovimientoPedidoDespachoDL MovimientoPedidoDespacho = new MovimientoPedidoDespachoDL();
                return MovimientoPedidoDespacho.Selecciona(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(MovimientoPedidoDespachoBE pItem)
        {
            try
            {
                MovimientoPedidoDespachoDL MovimientoPedidoDespacho = new MovimientoPedidoDespachoDL();
                MovimientoPedidoDespacho.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(MovimientoPedidoDespachoBE pItem)
        {
            try
            {
                MovimientoPedidoDespachoDL MovimientoPedidoDespacho = new MovimientoPedidoDespachoDL();
                MovimientoPedidoDespacho.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(MovimientoPedidoDespachoBE pItem)
        {
            try
            {
                MovimientoPedidoDespachoDL MovimientoPedidoDespacho = new MovimientoPedidoDespachoDL();
                MovimientoPedidoDespacho.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaEmbalador(MovimientoPedidoDespachoBE pItem)
        {
            try
            {
                MovimientoPedidoDespachoDL MovimientoPedidoDespacho = new MovimientoPedidoDespachoDL();
                MovimientoPedidoDespacho.ActualizaEmbalador(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaDespachador(MovimientoPedidoDespachoBE pItem)
        {
            try
            {
                MovimientoPedidoDespachoDL MovimientoPedidoDespacho = new MovimientoPedidoDespachoDL();
                MovimientoPedidoDespacho.ActualizaDespachador(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
