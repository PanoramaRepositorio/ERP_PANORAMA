using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ClienteCreditoBL
    {
        public List<ClienteCreditoBE> ListaTodosActivo(int IdEmpresa, int IdMotivo)
        {
            try
            {
                ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                return ClienteCredito.ListaTodosActivo(IdEmpresa, IdMotivo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ClienteCreditoBE> SeleccionaTodos()
        {
            try
            {
                ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                List<ClienteCreditoBE> lista = ClienteCredito.SeleccionaTodos();
                return lista;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClienteCreditoBE Selecciona(int IdEmpresa, int IdClienteCredito)
        {
            try
            {
                ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                return ClienteCredito.Selecciona(IdEmpresa, IdClienteCredito);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClienteCreditoBE SeleccionaCliente(int IdEmpresa, int IdCliente, int IdMotivo)
        {
            try
            {
                ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                return ClienteCredito.SeleccionaCliente(IdEmpresa, IdCliente, IdMotivo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ClienteCreditoBE pItem)
        {
            try
            {
                ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                ClienteCredito.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ClienteCreditoBE pItem)
        {
            try
            {
                ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                ClienteCredito.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ClienteCreditoBE pItem)
        {
            try
            {
                ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                ClienteCredito.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
