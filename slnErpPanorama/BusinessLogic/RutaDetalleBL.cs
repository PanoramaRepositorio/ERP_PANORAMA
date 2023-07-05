using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class RutaDetalleBL
    {
        public List<RutaDetalleBE> ListaTodosActivo(int IdRuta)
        {
            try
            {
                RutaDetalleDL RutaDetalle = new RutaDetalleDL();
                return RutaDetalle.ListaTodosActivo(IdRuta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public RutaDetalleBE Selecciona(int IdRutaDetalle)
        {
            try
            {
                RutaDetalleDL RutaDetalle = new RutaDetalleDL();
                return RutaDetalle.Selecciona(IdRutaDetalle);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public RutaDetalleBE SeleccionaUbigeo(string IdUbigeo)
        {
            try
            {
                RutaDetalleDL RutaDetalle = new RutaDetalleDL();
                return RutaDetalle.SeleccionaUbigeo(IdUbigeo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(RutaDetalleBE pItem)
        {
            try
            {
                RutaDetalleDL RutaDetalle = new RutaDetalleDL();
                RutaDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(RutaDetalleBE pItem)
        {
            try
            {
                RutaDetalleDL RutaDetalle = new RutaDetalleDL();
                RutaDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(RutaDetalleBE pItem)
        {
            try
            {
                RutaDetalleDL RutaDetalle = new RutaDetalleDL();
                RutaDetalle.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
