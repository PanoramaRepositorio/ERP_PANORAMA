using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class SolicitudProductoDetalleBL
    {
        public List<SolicitudProductoDetalleBE> ListaTodosActivo(int IdEmpresa, int IdSolicitudProducto)
        {
            try
            {
                SolicitudProductoDetalleDL SolicitudProductoDetalle = new SolicitudProductoDetalleDL();
                return SolicitudProductoDetalle.ListaTodosActivo(IdEmpresa, IdSolicitudProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<SolicitudProductoDetalleBE> ListaTodosImagen(int IdEmpresa, int IdSolicitudProducto)
        {
            try
            {
                SolicitudProductoDetalleDL SolicitudProductoDetalle = new SolicitudProductoDetalleDL();
                return SolicitudProductoDetalle.ListaTodosImagen(IdEmpresa, IdSolicitudProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<SolicitudProductoDetalleBE> ListaNumero(int IdEmpresa, int Periodo, string Numero)
        {
            try
            {
                SolicitudProductoDetalleDL SolicitudProductoDetalle = new SolicitudProductoDetalleDL();
                return SolicitudProductoDetalle.ListaNumero(IdEmpresa, Periodo, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(SolicitudProductoDetalleBE pItem)
        {
            try
            {
                SolicitudProductoDetalleDL SolicitudProductoDetalle = new SolicitudProductoDetalleDL();
                SolicitudProductoDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SolicitudProductoDetalleBE pItem)
        {
            try
            {
                SolicitudProductoDetalleDL SolicitudProductoDetalle = new SolicitudProductoDetalleDL();
                SolicitudProductoDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(SolicitudProductoDetalleBE pItem)
        {
            try
            {
                SolicitudProductoDetalleDL SolicitudProductoDetalle = new SolicitudProductoDetalleDL();
                SolicitudProductoDetalle.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}



