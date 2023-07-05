using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
   public class EstadoCuentaProveedorBL
    {
        public void Inserta(EstadoCuentaProveedorBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    EstadoCuentaProveedorDL EstadoCuentaProveedor = new EstadoCuentaProveedorDL();
                    EstadoCuentaProveedor.Inserta(pItem);

                    //ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                    //if (pItem.TipoMovimiento == "C")
                    //    ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, pItem.Importe, 0, pItem.IdMotivo);
                    //else
                    //    ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, 0, pItem.Importe, pItem.IdMotivo)

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EstadoCuentaProveedorBE> ListaProveedor(DateTime FechaDesde, DateTime FechaHasta, int IdProveedor)
        {
            try
            {
                EstadoCuentaProveedorDL EstadoCuentaProveedor = new EstadoCuentaProveedorDL();
                return EstadoCuentaProveedor.ListaProveedor(FechaDesde, FechaHasta, IdProveedor);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //public List<EstadoCuentaProveedorBE> ListaClienteResumen(DateTime FechaDesde, DateTime FechaHasta, int IdEmpresa, int IdTipoCliente, int IdCliente, int IdMotivo)
        //{
        //    try
        //    {
        //        EstadoCuentaDL EstadoCuentaProveedor = new EstadoCuentaDL();
        //        return EstadoCuenta.ListaClienteResumen(FechaDesde, FechaHasta, IdEmpresa, IdTipoCliente, IdCliente, IdMotivo);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        public List<EstadoCuentaProveedorBE> ListaTodosActivo(int IdEmpresa, int IdProveedor,string TipoMovimiento,  int IdSituacion)
        {
            try
            {
                EstadoCuentaProveedorDL EstadoCuentaProveedor = new EstadoCuentaProveedorDL();
                return EstadoCuentaProveedor.ListaTodosActivo(IdEmpresa, IdProveedor, TipoMovimiento, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //public List<EstadoCuentaProveedorBE> ListaPedido(int IdEmpresa, int IdPedido, string TipoMovimiento)
        //{
        //    try
        //    {
        //        EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
        //        return EstadoCuenta.ListaPedido(IdEmpresa, IdPedido, TipoMovimiento);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        public EstadoCuentaProveedorBE Selecciona(int IdEmpresa, int IdEstadoCuentaProveedor)
        {
            try
            {
                EstadoCuentaProveedorDL EstadoCuenta = new EstadoCuentaProveedorDL();
                return EstadoCuenta.Selecciona(IdEmpresa, IdEstadoCuentaProveedor);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //public EstadoCuentaProveedorBE SeleccionaNumeroDocumento(int Periodo, string NumeroDocumento)
        //{
        //    try
        //    {
        //        EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
        //        return EstadoCuenta.SeleccionaNumeroDocumento(Periodo, NumeroDocumento);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public EstadoCuentaProveedorBE SeleccionaMovimientoCaja(int? IdMovimientoCaja)
        //{
        //    try
        //    {
        //        EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
        //        return EstadoCuenta.SeleccionaMovimientoCaja(IdMovimientoCaja);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public EstadoCuentaProveedorBE SeleccionaDocumentoVenta(int? IdDocumentoVenta)
        //{
        //    try
        //    {
        //        EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
        //        return EstadoCuenta.SeleccionaDocumentoVenta(IdDocumentoVenta);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public void Inserta(EstadoCuentaProveedorBE pItem)
        //{
        //    try
        //    {
        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
        //            EstadoCuenta.Inserta(pItem);

        //            ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
        //            if (pItem.TipoMovimiento == "C")
        //                ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, pItem.Importe, 0, pItem.IdMotivo);
        //            else
        //                ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, 0, pItem.Importe, pItem.IdMotivo);

        //            ts.Complete();
        //        }
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        public void Actualiza(EstadoCuentaProveedorBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    EstadoCuentaProveedorDL EstadoCuentaProveedor = new EstadoCuentaProveedorDL();
                    EstadoCuentaProveedor.Actualiza(pItem);

                    //ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                    //if (pItem.TipoMovimiento == "C")
                    //    ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, pItem.Importe, pItem.ImporteAnt, pItem.IdMotivo);
                    //else
                    //    ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, pItem.ImporteAnt, pItem.Importe, pItem.IdMotivo);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EstadoCuentaProveedorBE pItem)
        {
            try
            {
                EstadoCuentaProveedorDL EstadoCuenta = new EstadoCuentaProveedorDL();
                EstadoCuenta.Elimina(pItem);

                //ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                //if (pItem.TipoMovimiento == "C")
                //    ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, 0, pItem.Importe, pItem.IdMotivo);
                //else
                //    ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, pItem.Importe, 0, pItem.IdMotivo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //public void EliminaDocumento(int IdEmpresa, int Periodo, int IdCliente, string NumeroDocumento, string TipoMovimiento, decimal Importe, int IdMotivo)
        //{
        //    try
        //    {
        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
        //            EstadoCuenta.EliminaDocumento(IdEmpresa, Periodo, IdCliente, NumeroDocumento);

        //            ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
        //            if (TipoMovimiento == "C")
        //                ClienteCredito.ActualizaLineaCreditoUtilizada(IdEmpresa, IdCliente, 0, Importe, IdMotivo);
        //            else
        //                ClienteCredito.ActualizaLineaCreditoUtilizada(IdEmpresa, IdCliente, Importe, 0, IdMotivo);

        //            ts.Complete();
        //        }


        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        public List<EstadoCuentaProveedorBE> ListaFacturaCompra(int IdEmpresa, int IdFacturaCompra, string TipoMovimiento)
        {
            try
            {
                EstadoCuentaProveedorDL EstadoCuenta = new EstadoCuentaProveedorDL();
                return EstadoCuenta.ListaFacturaCompra(IdEmpresa, IdFacturaCompra, TipoMovimiento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSaldo(int IdEstadoCuentaProveedor, decimal Saldo)
        {
            try
            {
                EstadoCuentaProveedorDL EstadoCuentaCliente = new EstadoCuentaProveedorDL();
                EstadoCuentaCliente.ActualizaSaldo(IdEstadoCuentaProveedor, Saldo);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
