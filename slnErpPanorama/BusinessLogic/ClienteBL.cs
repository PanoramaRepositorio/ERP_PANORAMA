using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ClienteBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<ClienteBE> ListaTodosActivo(int IdEmpresa, int IdTipoCliente)
        {
            try
            {
                ClienteDL Cliente = new ClienteDL();
                return Cliente.ListaTodosActivo(IdEmpresa, IdTipoCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ClienteBE> ListaTodosActivoRuta(int IdRuta, int IdSituacion, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            try
            {
                ClienteDL Cliente = new ClienteDL();
                return Cliente.ListaTodosActivoRuta(IdRuta, IdSituacion, FechaDesde, FechaHasta, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ClienteBE> ListaTelefonos(int IdCliente)
        {
            try
            {
                ClienteDL Cliente = new ClienteDL();
                return Cliente.ListaTelefonos(IdCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ClienteBE> ListaCelulares(int TipoCliente)
        {
            try
            {
                ClienteDL Cliente = new ClienteDL();
                return Cliente.ListaCelulares(TipoCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ClienteBE> ListaAsesorExterno(int IdEmpresa)
        {
            try
            {
                ClienteDL Cliente = new ClienteDL();
                return Cliente.ListaAsesorExterno(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
        
        public ClienteBE Selecciona(int IdEmpresa, int IdCliente)
        {
            try
            {
                ClienteDL Cliente = new ClienteDL();
                ClienteBE objEmp = Cliente.Selecciona(IdEmpresa,IdCliente);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ClienteBE> SeleccionaLista(int IdEmpresa, int IdCliente)
        {
            try
            {
                ClienteDL Cliente = new ClienteDL();
               return  Cliente.SeleccionaLista(IdEmpresa, IdCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ClienteBE> SeleccionaBusqueda(int IdEmpresa, int IdTipoCliente, string pFiltro, int Pagina, int CantidadRegistro,int TipoBusqueda)
        {
            try
            {
                ClienteDL Cliente = new ClienteDL();
                return Cliente.SeleccionaBusqueda(IdEmpresa, IdTipoCliente, pFiltro, Pagina, CantidadRegistro, TipoBusqueda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ClienteBE> SeleccionaBusquedaCliente(int IdEmpresa, int IdTipoCliente, string pFiltro, int Pagina, int CantidadRegistro, int TipoBusqueda)
        {
            try
            {
                ClienteDL Cliente = new ClienteDL();
                return Cliente.SeleccionaBusquedaClienteSolicitud(IdEmpresa, IdTipoCliente, pFiltro, Pagina, CantidadRegistro, TipoBusqueda);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<ClienteBE> SeleccionaBusquedaComercio(int IdEmpresa, int IdTipoCliente, string pFiltro, int Pagina, int CantidadRegistro, int TipoBusqueda)
        {
            try
            {
                ClienteDL Cliente = new ClienteDL();
                return Cliente.SeleccionaBusquedaComercio(IdEmpresa, IdTipoCliente, pFiltro, Pagina, CantidadRegistro, TipoBusqueda);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public List<ClienteBE> SeleccionaBusquedaConAsociado(int IdEmpresa, string pFiltro, int Pagina, int CantidadRegistro)
        {
            try
            {
                ClienteDL Cliente = new ClienteDL();
                return Cliente.SeleccionaBusquedaConAsociado(IdEmpresa, pFiltro, Pagina, CantidadRegistro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int SeleccionaBusquedaCount(int IdEmpresa, int IdTipoCliente, string pFiltro, int TipoBusqueda)
        {
            try
            {
                ClienteDL Cliente = new ClienteDL();
                return Cliente.SeleccionaBusquedaCount(IdEmpresa, IdTipoCliente,pFiltro, TipoBusqueda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClienteBE SeleccionaNumero(int IdEmpresa, string NumeroDocumento)
        {
            try
            {
                ClienteDL Cliente = new ClienteDL();
                return Cliente.SeleccionaNumero(IdEmpresa, NumeroDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClienteBE SeleccionaNumeroAgenda(int IdEmpresa, string NumeroDocumento)
        {
            try
            {
                ClienteDL Cliente = new ClienteDL();
                return Cliente.SeleccionaNumeroAgenda(IdEmpresa, NumeroDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClienteBE SeleccionaNumeroComercio(int IdEmpresa, string NumeroDocumento)
        {
            try
            {
                ClienteDL Cliente = new ClienteDL();
                return Cliente.SeleccionaNumeroComercio(IdEmpresa, NumeroDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClienteBE SeleccionaUsuarioNumero(int IdEmpresa, string NumeroDocumento)
        {
            try
            {
                ClienteDL Cliente = new ClienteDL();
                return Cliente.SeleccionaUsuarioNumero(IdEmpresa, NumeroDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClienteBE SeleccionaNumeroSunat(int IdEmpresa, string NumeroDocumento)
        {
            try
            {
                ClienteDL Cliente = new ClienteDL();
                return Cliente.SeleccionaNumeroSunat(IdEmpresa, NumeroDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClienteBE SeleccionaDescripcion(int IdEmpresa, string DescCliente)
        {
            try
            {
                ClienteDL Cliente = new ClienteDL();
                return Cliente.SeleccionaDescripcion(IdEmpresa, DescCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ClienteBE pItem, List<ClienteLineaProductoBE> pListaClienteLineaProducto, List<ClienteAsociadoBE> pListaClienteAsociado, List<ClienteCorreoBE> pListaClienteCorreo, List<ClienteTrackingBE> pListaClienteTracking, ClienteEncuestaBE pClienteEncuesta)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ClienteDL Cliente = new ClienteDL();
                    ClienteLineaProductoDL ClienteLineaProducto = new ClienteLineaProductoDL();
                    ClienteAsociadoDL ClienteAsociado = new ClienteAsociadoDL();
                    ClienteCorreoDL ClienteCorreo = new ClienteCorreoDL();
                    ClienteTrackingDL ClienteTracking = new ClienteTrackingDL();
                    ClienteEncuestaDL ClienteEncuesta = new ClienteEncuestaDL();

                    int IdCliente = 0;
                    //Insertamos el cliente principal
                    IdCliente = Cliente.Inserta(pItem);

                    foreach (ClienteLineaProductoBE item in pListaClienteLineaProducto)
                    {
                        //Insertamos el detalle de la linea producto asociado al cliente mayorista
                        item.IdCliente = IdCliente;
                        ClienteLineaProducto.Inserta(item);
                    }

                    foreach (ClienteAsociadoBE item in pListaClienteAsociado)
                    {
                        //Insertamos el detalle del cliente asociado al cliente mayorista
                        item.IdCliente = IdCliente;
                        ClienteAsociado.Inserta(item);
                    }

                    foreach (ClienteCorreoBE item in pListaClienteCorreo)
                    {
                        //Insertamos el detalle del correo electronico asociado al cliente mayorista
                        item.IdCliente = IdCliente;
                        ClienteCorreo.Inserta(item);
                    }

                    foreach (ClienteTrackingBE item in pListaClienteTracking)
                    {
                        //Insertamos el detalle del tracking de llamadas al cliente mayorista
                        item.IdCliente = IdCliente;
                        ClienteTracking.Inserta(item);
                    }

                    //Cliente Encuesta
                    pClienteEncuesta.IdCliente = IdCliente;
                    ClienteEncuesta.Inserta(pClienteEncuesta);


                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ClienteBE pItem, List<ClienteLineaProductoBE> pListaClienteLineaProducto, List<ClienteAsociadoBE> pListaClienteAsociado, List<ClienteCorreoBE> pListaClienteCorreo, List<ClienteTrackingBE> pListaClienteTracking, ClienteEncuestaBE pClienteEncuesta)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ClienteDL Cliente = new ClienteDL();
                    ClienteLineaProductoDL ClienteLineaProducto = new ClienteLineaProductoDL();
                    ClienteAsociadoDL ClienteAsociado = new ClienteAsociadoDL();
                    ClienteCorreoDL ClienteCorreo = new ClienteCorreoDL();
                    ClienteTrackingDL ClienteTracking = new ClienteTrackingDL();
                    ClienteEncuestaDL ClienteEncuesta = new ClienteEncuestaDL();

                    foreach (ClienteLineaProductoBE item in pListaClienteLineaProducto)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la linea producto asociado al cliente mayorista
                            item.IdCliente = pItem.IdCliente;
                            ClienteLineaProducto.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la linea producto asociado al cliente mayorista
                            ClienteLineaProducto.Actualiza(item);
                        }
                    }

                    foreach (ClienteAsociadoBE item in pListaClienteAsociado)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle del cliente asociado al cliente mayorista
                            item.IdCliente = pItem.IdCliente;
                            ClienteAsociado.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la linea producto asociado al cliente mayorista
                            ClienteAsociado.Actualiza(item);
                        }
                    }

                    foreach (ClienteCorreoBE item in pListaClienteCorreo)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle del correo electronico asociado al cliente mayorista
                            item.IdCliente = pItem.IdCliente;
                            ClienteCorreo.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle del correo electronico asociado al cliente mayorista
                            ClienteCorreo.Actualiza(item);
                        }
                    }

                    foreach (ClienteTrackingBE item in pListaClienteTracking)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle del tracking de llamadas al cliente mayorista
                            item.IdCliente = pItem.IdCliente;
                            ClienteTracking.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle del tracking de llamadas al cliente mayorista
                            ClienteTracking.Actualiza(item);
                        }
                    }

                    if (pClienteEncuesta.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                    {
                        //Insertamos el medio contactado
                        pClienteEncuesta.IdCliente = pItem.IdCliente;
                        ClienteEncuesta.Inserta(pClienteEncuesta);
                    }
                    else
                    {
                        //Actualizamos el medio contactado
                        pClienteEncuesta.IdCliente = pItem.IdCliente;
                        ClienteEncuesta.Actualiza(pClienteEncuesta);
                    }


                    //Actualizamos la tabla principal cliente
                    Cliente.Actualiza(pItem);

                    //Actualizamos las direccion del pedido asociado al cliente
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(pItem.IdEmpresa, pItem.NumeroDocumento);

                    PedidoDL objDL_Pedido = new PedidoDL();
                    objDL_Pedido.ActualizaClienteDireccion(objE_Cliente.IdCliente, objE_Cliente.AbrevDomicilio + " " + objE_Cliente.Direccion);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ClienteBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ClienteLineaProductoDL ClienteLineaProducto = new ClienteLineaProductoDL();
                    ClienteAsociadoDL ClienteAsociado = new ClienteAsociadoDL();
                    ClienteCorreoDL ClienteCorreo = new ClienteCorreoDL();
                    ClienteTrackingDL ClienteTracking = new ClienteTrackingDL();
                    ClienteAgendaDL ClienteAgenda = new ClienteAgendaDL();

                    List<ClienteLineaProductoBE> lstClienteLineaProducto = null;
                    lstClienteLineaProducto = ClienteLineaProducto.ListaTodosActivo(pItem.IdEmpresa, pItem.IdCliente);

                    foreach (ClienteLineaProductoBE item in lstClienteLineaProducto)
                    {
                        ClienteLineaProducto.Elimina(item);
                    }

                    List<ClienteAsociadoBE> lstClienteAsociado = null;
                    lstClienteAsociado = ClienteAsociado.ListaTodosActivo(pItem.IdEmpresa, pItem.IdCliente);

                    foreach (ClienteAsociadoBE item in lstClienteAsociado)
                    {
                        ClienteAsociado.Elimina(item);
                    }

                    List<ClienteCorreoBE> lstClienteCorreo = null;
                    lstClienteCorreo = ClienteCorreo.ListaTodosActivo(pItem.IdEmpresa, pItem.IdCliente);

                    foreach (ClienteCorreoBE item in lstClienteCorreo)
                    {
                        ClienteCorreo.Elimina(item);
                    }

                    List<ClienteTrackingBE> lstClienteTracking = null;
                    lstClienteTracking = ClienteTracking.ListaTodosActivo(pItem.IdCliente);

                    foreach (ClienteTrackingBE item in lstClienteTracking)
                    {
                        ClienteTracking.Elimina(item);
                    }

                    List<ClienteAgendaBE> lstClienteAgenda = null;
                    lstClienteAgenda = ClienteAgenda.ListaTodosActivo(pItem.IdCliente);

                    foreach (ClienteAgendaBE item in lstClienteAgenda)
                    {
                        ClienteAgenda.Elimina(item);
                    }

                    //Eliminamos el cliente principal
                    ClienteDL Cliente = new ClienteDL();
                    Cliente.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaMayorista(ClienteBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //Actualizamos el cliente mayorista
                    ClienteDL Cliente = new ClienteDL();
                    Cliente.ActualizaMayorista(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaMinorista(ClienteBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //Actualizamos el cliente mayorista
                    ClienteDL Cliente = new ClienteDL();
                    Cliente.ActualizaMinorista(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaPadron(ClienteBE pItem)
        {
            try
            {
                ClienteDL Cliente = new ClienteDL();
                Cliente.ActualizaPadron(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}

