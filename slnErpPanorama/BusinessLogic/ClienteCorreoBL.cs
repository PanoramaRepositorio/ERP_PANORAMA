using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ClienteCorreoBL
    {
        public List<ClienteCorreoBE> ListaTodosActivo(int IdEmpresa, int IdCliente)
        {
            try
            {
                ClienteCorreoDL ClienteCorreo = new ClienteCorreoDL();
                return ClienteCorreo.ListaTodosActivo(IdEmpresa, IdCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ClienteCorreoBE> ListadoMailing(int IdEmpresa, int IdClienteCorreo)
        {
            try
            {
                ClienteCorreoDL ClienteCorreo = new ClienteCorreoDL();
                return ClienteCorreo.ListadoMailing(IdEmpresa, IdClienteCorreo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ClienteCorreoBE> ListadoMailingFiltro(int IdTipoCliente)
        {
            try
            {
                ClienteCorreoDL ClienteCorreo = new ClienteCorreoDL();
                return ClienteCorreo.ListadoMailingFiltro(IdTipoCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ClienteCorreoBE pItem)
        {
            try
            {
                ClienteCorreoDL ClienteCorreo = new ClienteCorreoDL();
                ClienteCorreo.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ClienteCorreoBE pItem)
        {
            try
            {
                ClienteCorreoDL ClienteCorreo = new ClienteCorreoDL();
                ClienteCorreo.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ClienteCorreoBE pItem)
        {
            try
            {
                ClienteCorreoDL ClienteCorreo = new ClienteCorreoDL();
                ClienteCorreo.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}