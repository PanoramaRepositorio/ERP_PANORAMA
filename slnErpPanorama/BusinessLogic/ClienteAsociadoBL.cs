using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ClienteAsociadoBL
    {
        public List<ClienteAsociadoBE> ListaTodosActivo(int IdEmpresa, int IdCliente)
        {
            try
            {
                ClienteAsociadoDL ClienteAsociado = new ClienteAsociadoDL();
                return ClienteAsociado.ListaTodosActivo(IdEmpresa,IdCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ClienteAsociadoBE> ListaTodosActivoConPrincipal(int IdEmpresa, int IdCliente)
        {
            try
            {
                ClienteAsociadoDL ClienteAsociado = new ClienteAsociadoDL();
                return ClienteAsociado.ListaTodosActivoConPrincipal(IdEmpresa, IdCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClienteAsociadoBE SeleccionaConPrincipal(int IdEmpresa, int IdCliente, int IdClienteAsociado)
        {
            try
            {
                ClienteAsociadoDL ClienteAsociado = new ClienteAsociadoDL();
                return ClienteAsociado.SeleccionaConPrincipal(IdEmpresa, IdCliente, IdClienteAsociado);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClienteAsociadoBE SeleccionaNumero(int IdEmpresa, string NumeroDocumento)
        {
            try
            {
                ClienteAsociadoDL ClienteAsociado = new ClienteAsociadoDL();
                return ClienteAsociado.SeleccionaNumero(IdEmpresa, NumeroDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClienteAsociadoBE SeleccionaDescripcion(int IdEmpresa, string DescCliente)
        {
            try
            {
                ClienteAsociadoDL ClienteAsociado = new ClienteAsociadoDL();
                return ClienteAsociado.SeleccionaDescripcion(IdEmpresa, DescCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ClienteAsociadoBE pItem)
        {
            try
            {
                ClienteAsociadoDL ClienteAsociado = new ClienteAsociadoDL();
                ClienteAsociado.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ClienteAsociadoBE pItem)
        {
            try
            {
                ClienteAsociadoDL ClienteAsociado = new ClienteAsociadoDL();
                ClienteAsociado.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ClienteAsociadoBE pItem)
        {
            try
            {
                ClienteAsociadoDL ClienteAsociado = new ClienteAsociadoDL();
                ClienteAsociado.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
