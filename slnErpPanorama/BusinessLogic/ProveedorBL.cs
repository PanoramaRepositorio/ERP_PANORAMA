using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ProveedorBL
    {
        public List<ProveedorBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ProveedorDL Proveedor = new ProveedorDL();
                return Proveedor.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProveedorBE> ListaTodosActivoNacional(int IdEmpresa)
        {
            try
            {
                ProveedorDL Proveedor = new ProveedorDL();
                return Proveedor.ListaTodosActivoNacional(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProveedorBE SeleccionaNumero(string NumeroDocumento)
        {
            try
            {
                ProveedorDL ConTipoComprobantePago = new ProveedorDL();
                return ConTipoComprobantePago.SeleccionaNumero(NumeroDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProveedorBE Selecciona(Int32 IdProveedor)
        {
            try
            {
                ProveedorDL ConTipoComprobantePago = new ProveedorDL();
                return ConTipoComprobantePago.Selecciona(IdProveedor);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public  int Inserta(ProveedorBE pItem)
        {
            try
            {
                ProveedorDL Proveedor = new ProveedorDL();
              int vid =  Proveedor.Inserta(pItem);
                return vid;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ProveedorBE pItem)
        {
            try
            {
                ProveedorDL Proveedor = new ProveedorDL();
                Proveedor.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ProveedorBE pItem)
        {
            try
            {
                ProveedorDL Proveedor = new ProveedorDL();
                Proveedor.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProveedorBE> SeleccionaBusqueda(int IdEmpresa, int IdTipoCliente, string pFiltro, int Pagina, int CantidadRegistro, int TipoBusqueda)
        {
            try
            {
                ProveedorDL Proveedor = new ProveedorDL();
                return Proveedor.SeleccionaBusqueda(IdEmpresa, IdTipoCliente, pFiltro, Pagina, CantidadRegistro, TipoBusqueda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //public List<ProveedorBE> SeleccionaBusquedaEgresosCaja(int IdCajaEgreso, int IdCajaEgresoDetalle)
        //{
        //    try
        //    {
        //        ProveedorDL Proveedor = new ProveedorDL();
        //        return Proveedor.SeleccionaBusquedaEgresos(IdCajaEgreso, IdCajaEgresoDetalle);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

    }
}

