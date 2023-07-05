using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class CajaVaciaBL
    {
        public List<CajaVaciaBE> ListaTodosActivo(int IdEmpresa, int IdUbicacion, int IdPiso)
        {
            try
            {
                CajaVaciaDL CajaVacia = new CajaVaciaDL();
                return CajaVacia.ListaTodosActivo(IdEmpresa,IdUbicacion,IdPiso);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CajaVaciaBE> ListaCodigo(int IdEmpresa, int IdTienda,string CodigoProveedor)
        {
            try
            {
                CajaVaciaDL CajaVacia = new CajaVaciaDL();
                return CajaVacia.ListaCodigo(IdEmpresa, IdTienda,CodigoProveedor);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CajaVaciaBE> ListaIdProducto(int IdEmpresa, int IdProducto)
        {
            try
            {
                CajaVaciaDL CajaVacia = new CajaVaciaDL();
                return CajaVacia.ListaIdProducto(IdEmpresa, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CajaVaciaBE Selecciona(int IdEmpresa, int IdCajaVacia)
        {
            try
            {
                CajaVaciaDL CajaVacia = new CajaVaciaDL();
                return CajaVacia.Selecciona(IdEmpresa, IdCajaVacia);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CajaVaciaBE SeleccionaCodigo(int IdEmpresa, int IdTienda, string CodigoProveedor)
        {
            try
            {
                CajaVaciaDL CajaVacia = new CajaVaciaDL();
                return CajaVacia.SeleccionaCodigo(IdEmpresa, IdTienda, CodigoProveedor);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(CajaVaciaBE pItem)
        {
            try
            {
                CajaVaciaDL CajaVacia = new CajaVaciaDL();
                CajaVacia.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CajaVaciaBE pItem)
        {
            try
            {
                CajaVaciaDL CajaVacia = new CajaVaciaDL();
                CajaVacia.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CajaVaciaBE pItem)
        {
            try
            {
                CajaVaciaDL CajaVacia = new CajaVaciaDL();
                CajaVacia.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}


