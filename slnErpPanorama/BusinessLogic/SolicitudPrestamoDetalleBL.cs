using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class SolicitudPrestamoDetalleBL
    {
        public List<SolicitudPrestamoDetalleBE> ListaTodosActivo(int IdSolicitudPrestamo)
        {
            try
            {
                SolicitudPrestamoDetalleDL SolicitudPrestamoDetalle = new SolicitudPrestamoDetalleDL();
                return SolicitudPrestamoDetalle.ListaTodosActivo(IdSolicitudPrestamo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<SolicitudPrestamoDetalleBE> ListaPersona(DateTime FechaDesde, DateTime FechaHasta, int IdPersona)
        {
            try
            {
                SolicitudPrestamoDetalleDL SolicitudPrestamoDetalle = new SolicitudPrestamoDetalleDL();
                return SolicitudPrestamoDetalle.ListaPersona(FechaDesde, FechaHasta, IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(SolicitudPrestamoDetalleBE pItem)
        {
            try
            {
                SolicitudPrestamoDetalleDL SolicitudPrestamoDetalle = new SolicitudPrestamoDetalleDL();
                SolicitudPrestamoDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SolicitudPrestamoDetalleBE pItem)
        {
            try
            {
                SolicitudPrestamoDetalleDL SolicitudPrestamoDetalle = new SolicitudPrestamoDetalleDL();
                SolicitudPrestamoDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(SolicitudPrestamoDetalleBE pItem)
        {
            try
            {
                SolicitudPrestamoDetalleDL SolicitudPrestamoDetalle = new SolicitudPrestamoDetalleDL();
                SolicitudPrestamoDetalle.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
