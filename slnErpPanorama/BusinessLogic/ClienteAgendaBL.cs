using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ClienteAgendaBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<ClienteAgendaBE> ListaTodosActivo(int IdCliente)
        {
            try
            {
                ClienteAgendaDL ClienteAgenda = new ClienteAgendaDL();
                return ClienteAgenda.ListaTodosActivo(IdCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ClienteAgendaBE> ListaVendedorSituacion(int IdVendedor, int IdSituacion)
        {
            try
            {
                ClienteAgendaDL ClienteAgenda = new ClienteAgendaDL();
                return ClienteAgenda.ListaVendedorSituacion(IdVendedor,IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClienteAgendaBE Selecciona(int IdClienteAgenda)
        {
            try
            {
                ClienteAgendaDL ClienteAgenda = new ClienteAgendaDL();
                return ClienteAgenda.Selecciona(IdClienteAgenda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(List<ClienteAgendaBE> pListaClienteAgenda)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ClienteAgendaDL ClienteAgenda = new ClienteAgendaDL();

                    foreach (ClienteAgendaBE item in pListaClienteAgenda)
                    {
                        //Insertamos el detalle del tracking de llamadas al cliente mayorista
                        ClienteAgenda.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(List<ClienteAgendaBE> pListaClienteAgenda)
        {
            try
            {
                ClienteAgendaDL ClienteAgenda = new ClienteAgendaDL();

                foreach (ClienteAgendaBE item in pListaClienteAgenda)
                {
                    if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                    {
                        //Insertamos el detalle del tracking de llamadas al cliente mayorista
                        ClienteAgenda.Inserta(item);
                    }
                    else
                    {
                        //Actualizamos el detalle del tracking de llamadas al cliente mayorista
                        ClienteAgenda.Actualiza(item);
                    }
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ClienteAgendaBE pItem)
        {
            try
            {
                ClienteAgendaDL ClienteAgenda = new ClienteAgendaDL();
                ClienteAgenda.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
