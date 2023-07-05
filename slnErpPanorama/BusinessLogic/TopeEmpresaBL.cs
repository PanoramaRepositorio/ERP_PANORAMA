using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class TopeEmpresaBL
    {
        public List<TopeEmpresaBE> ListaTodosActivo()
        {
            try
            {
                TopeEmpresaDL TopeEmpresa = new TopeEmpresaDL();
                return TopeEmpresa.ListaTodosActivo();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TopeEmpresaBE pItem)
        {
            try
            {
                TopeEmpresaDL TopeEmpresa = new TopeEmpresaDL();
                TopeEmpresa.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TopeEmpresaBE pItem)
        {
            try
            {
                TopeEmpresaDL TopeEmpresa = new TopeEmpresaDL();
                TopeEmpresa.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TopeEmpresaBE pItem)
        {
            try
            {
                TopeEmpresaDL TopeEmpresa = new TopeEmpresaDL();
                TopeEmpresa.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TopeEmpresaBE Selecciona(int IdEmpresa)
        {
            try
            {
                TopeEmpresaDL TopeEmpresa = new TopeEmpresaDL();
                return TopeEmpresa.Selecciona(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
