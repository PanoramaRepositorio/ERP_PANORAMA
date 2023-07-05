using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class SolicitudCompraDetalleBL
    {
        public List<SolicitudCompraDetalleBE> ListaTodosActivo(int IdEmpresa, int IdSolicitudCompra)
        {
            try
            {
                SolicitudCompraDetalleDL SolicitudCompraDetalle = new SolicitudCompraDetalleDL();
                return SolicitudCompraDetalle.ListaTodosActivo(IdEmpresa, IdSolicitudCompra);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(SolicitudCompraDetalleBE pItem)
        {
            try
            {
                SolicitudCompraDetalleDL SolicitudCompraDetalle = new SolicitudCompraDetalleDL();
                SolicitudCompraDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SolicitudCompraDetalleBE pItem)
        {
            try
            {
                SolicitudCompraDetalleDL SolicitudCompraDetalle = new SolicitudCompraDetalleDL();
                SolicitudCompraDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(SolicitudCompraDetalleBE pItem)
        {
            try
            {
                SolicitudCompraDetalleDL SolicitudCompraDetalle = new SolicitudCompraDetalleDL();
                SolicitudCompraDetalle.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
