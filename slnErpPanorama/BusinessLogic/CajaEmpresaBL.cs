using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class CajaEmpresaBL
    {
        public List<CajaEmpresaBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int IdCaja)
        {
            try
            {
                CajaEmpresaDL CajaEmpresa = new CajaEmpresaDL();
                return CajaEmpresa.ListaTodosActivo(IdEmpresa, IdTienda, IdCaja);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CajaEmpresaBE> ListaTodosActivosRER(int IdEmpresa, int IdTienda, int IdCaja)
        {
            try
            {
                CajaEmpresaDL CajaEmpresa = new CajaEmpresaDL();
                return CajaEmpresa.ListaTodosActivosRER(IdEmpresa, IdTienda, IdCaja);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CajaEmpresaBE Selecciona(int IdEmpresa, int IdTienda, int IdCaja)
        {
            try
            {
                CajaEmpresaDL CajaEmpresa = new CajaEmpresaDL();
                return CajaEmpresa.Selecciona(IdEmpresa, IdTienda, IdCaja);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(CajaEmpresaBE pItem)
        {
            try
            {
                CajaEmpresaDL CajaEmpresa = new CajaEmpresaDL();
                CajaEmpresa.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CajaEmpresaBE pItem)
        {
            try
            {
                CajaEmpresaDL CajaEmpresa = new CajaEmpresaDL();
                CajaEmpresa.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CajaEmpresaBE pItem)
        {
            try
            {
                CajaEmpresaDL CajaEmpresa = new CajaEmpresaDL();
                CajaEmpresa.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
