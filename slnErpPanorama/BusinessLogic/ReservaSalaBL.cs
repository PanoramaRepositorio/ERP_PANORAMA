using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReservaSalaBL
    {
        public List<CajaBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
        {
            try
            {
                CajaDL Caja = new CajaDL();
                return Caja.ListaTodosActivo(IdEmpresa, IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ReservaSalaBE pItem)
        {
            try
            {
                ReservaSalaDL Sala = new ReservaSalaDL();
                Sala.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CajaBE pItem)
        {
            try
            {
                CajaDL Caja = new CajaDL();
                Caja.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CajaBE pItem)
        {
            try
            {
                CajaDL Caja = new CajaDL();
                Caja.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReservaSalaBE> ListaFecha(DateTime Fecha)
        {
            try
            {
                ReservaSalaDL ReservaSala = new ReservaSalaDL();
                return ReservaSala.ListaFecha(Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ReservaSalaBE ValidaHoraInicio(DateTime pHoraInicio, DateTime pFechaReserva)
        {
            try
            {
                ReservaSalaDL Pedido = new ReservaSalaDL();
                ReservaSalaBE objAna = Pedido.ValidaHoraInicio(pHoraInicio, pFechaReserva);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ReservaSalaBE ValidaHoraFin(DateTime pHoraFin, DateTime pFechaReserva)
        {
            try
            {
                ReservaSalaDL Pedido = new ReservaSalaDL();
                ReservaSalaBE objAna = Pedido.ValidaHoraFin(pHoraFin, pFechaReserva);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }


    }
}
