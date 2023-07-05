using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpPanorama.BusinessLogic
{
  public  class EstadoCuentaProveedorPagoBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<EstadoCuentaProveedorPagoBE> ListaTodosActivo(int IdEmpresa, int IdProveedor, string TipoMovimiento, int IdSituacion)
        {
            try
            {
                EstadoCuentaProveedorPagoDL EstadoCuentaProveedorPago = new EstadoCuentaProveedorPagoDL();
                return EstadoCuentaProveedorPago.ListaTodosActivo(IdEmpresa, IdProveedor, TipoMovimiento, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EstadoCuentaProveedorPagoBE> ListaPagado(int IdEmpresa, int IdProveedor)
        {
            try
            {
                EstadoCuentaProveedorPagoDL EstadoCuentaProveedorPago = new EstadoCuentaProveedorPagoDL();
                return EstadoCuentaProveedorPago.ListaPagado(IdEmpresa, IdProveedor);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EstadoCuentaProveedorPagoBE Selecciona(int IdEstadoCuentaProveedorPago)
        {
            try
            {
                EstadoCuentaProveedorPagoDL EstadoCuentaProveedorPago = new EstadoCuentaProveedorPagoDL();
                return EstadoCuentaProveedorPago.Selecciona(IdEstadoCuentaProveedorPago);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EstadoCuentaProveedorPagoBE SeleccionaUltimo(int IdProveedor, int IdEstadoCuentaCliente, string TipoMovimiento)
        {
            try
            {
                EstadoCuentaProveedorPagoDL EstadoCuentaProveedorPago = new EstadoCuentaProveedorPagoDL();
                return EstadoCuentaProveedorPago.SeleccionaUltimo(IdProveedor, IdEstadoCuentaCliente, TipoMovimiento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(EstadoCuentaProveedorPagoBE pItem)
        {
            try
            {
                EstadoCuentaProveedorPagoDL EstadoCuentaProveedorPago = new EstadoCuentaProveedorPagoDL();
                EstadoCuentaProveedorPago.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(EstadoCuentaProveedorPagoBE pItem)
        {
            try
            {
                EstadoCuentaProveedorPagoDL EstadoCuentaProveedorPago = new EstadoCuentaProveedorPagoDL();
                EstadoCuentaProveedorPago.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void ActualizaSaldo(int IdEstadoCuentaProveedorPago, decimal Saldo)
        {
            try
            {
                EstadoCuentaProveedorPagoDL EstadoCuentaProveedorPago = new EstadoCuentaProveedorPagoDL();
                EstadoCuentaProveedorPago.ActualizaSaldo(IdEstadoCuentaProveedorPago, Saldo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EstadoCuentaProveedorPagoBE pItem)
        {
            try
            {
                EstadoCuentaProveedorPagoDL EstadoCuentaProveedorPago = new EstadoCuentaProveedorPagoDL();
                EstadoCuentaProveedorPago.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 EliminaCompensado(EstadoCuentaProveedorPagoBE pItem)
        {
            try
            {
                int IdEstadoCuentaProveedor = 0;
                EstadoCuentaProveedorPagoDL EstadoCuentaProveedorPago = new EstadoCuentaProveedorPagoDL();
                IdEstadoCuentaProveedor = EstadoCuentaProveedorPago.EliminaCompensado(pItem);

                return IdEstadoCuentaProveedor;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EstadoCuentaProveedorPagoBE> ListaHistorial(int IdEmpresa, int IdEstadoCuentaProveedor)
        {
            try
            {
                EstadoCuentaProveedorPagoDL EstadoCuentaProveedorPago = new EstadoCuentaProveedorPagoDL();
                return EstadoCuentaProveedorPago.ListaHistorial(IdEmpresa, IdEstadoCuentaProveedor);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
