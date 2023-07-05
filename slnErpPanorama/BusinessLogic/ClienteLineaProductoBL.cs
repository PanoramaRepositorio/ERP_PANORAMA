using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ClienteLineaProductoBL
    {
        public List<ClienteLineaProductoBE> ListaTodosActivo(int IdEmpresa, int IdCliente)
        {
            try
            {
                ClienteLineaProductoDL ClienteLineaProducto = new ClienteLineaProductoDL();
                return ClienteLineaProducto.ListaTodosActivo(IdEmpresa,IdCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ClienteLineaProductoBE pItem)
        {
            try
            {
                ClienteLineaProductoDL ClienteLineaProducto = new ClienteLineaProductoDL();
                ClienteLineaProducto.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ClienteLineaProductoBE pItem)
        {
            try
            {
                ClienteLineaProductoDL ClienteLineaProducto = new ClienteLineaProductoDL();
                ClienteLineaProducto.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ClienteLineaProductoBE pItem)
        {
            try
            {
                ClienteLineaProductoDL ClienteLineaProducto = new ClienteLineaProductoDL();
                ClienteLineaProducto.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
