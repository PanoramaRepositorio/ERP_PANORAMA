using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class TiendaBL
    {
        public List<TiendaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                TiendaDL Tienda = new TiendaDL();
                return Tienda.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TiendaBE> ListaTodosActivoKardex(int IdEmpresa)
        {
            try
            {
                TiendaDL Tienda = new TiendaDL();
                return Tienda.ListaTodosActivoKardex(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TiendaBE> ListaTodosActivoAuditoria(int IdEmpresa)
        {
            try
            {
                TiendaDL Tienda = new TiendaDL();
                return Tienda.ListaTodosActivoAuditoria(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<TiendaBE> ListaTodosTiendasActivo(int IdEmpresa)
        {
            try
            {
                TiendaDL Tienda = new TiendaDL();
                return Tienda.ListaTodosTiendasActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<TiendaBE> ListaTodosCombo(int IdEmpresa)
        {
            try
            {
                TiendaDL Tienda = new TiendaDL();
                return Tienda.ListaTodosCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TiendaBE Selecciona(int IdTienda)
        {
            try
            {
                TiendaDL Tienda = new TiendaDL();
                return Tienda.Selecciona(IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(TiendaBE pItem)
        {
            try
            {
                TiendaDL Tienda = new TiendaDL();
                Tienda.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TiendaBE pItem)
        {
            try
            {
                TiendaDL Tienda = new TiendaDL();
                Tienda.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TiendaBE pItem)
        {
            try
            {
                TiendaDL Tienda = new TiendaDL();
                Tienda.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<TiendaBE> ListaTodosTiendasActivo2(int IdEmpresa)
        {
            try
            {
                TiendaDL Tienda = new TiendaDL();
                return Tienda.ListaTodosTiendasActivo2(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
