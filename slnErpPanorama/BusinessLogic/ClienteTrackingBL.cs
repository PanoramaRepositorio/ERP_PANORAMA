using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ClienteTrackingBL
    {
        public List<ClienteTrackingBE> ListaTodosActivo(int IdCliente)
        {
            try
            {
                ClienteTrackingDL ClienteTracking = new ClienteTrackingDL();
                return ClienteTracking.ListaTodosActivo(IdCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClienteTrackingBE Selecciona(int IdClienteTracking)
        {
            try
            {
                ClienteTrackingDL ClienteTracking = new ClienteTrackingDL();
                return ClienteTracking.Selecciona(IdClienteTracking);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ClienteTrackingBE pItem)
        {
            try
            {
                ClienteTrackingDL ClienteTracking = new ClienteTrackingDL();
                ClienteTracking.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ClienteTrackingBE pItem)
        {
            try
            {
                ClienteTrackingDL ClienteTracking = new ClienteTrackingDL();
                ClienteTracking.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ClienteTrackingBE pItem)
        {
            try
            {
                ClienteTrackingDL ClienteTracking = new ClienteTrackingDL();
                ClienteTracking.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
