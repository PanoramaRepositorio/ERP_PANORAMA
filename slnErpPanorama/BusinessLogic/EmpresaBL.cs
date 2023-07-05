using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class EmpresaBL
    {
        public List<EmpresaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                EmpresaDL Empresa = new EmpresaDL();
                return Empresa.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EmpresaBE> SeleccionaTodos()
        {
            try
            {
                EmpresaDL empresa = new EmpresaDL();
                List<EmpresaBE> lista = empresa.SeleccionaTodos();
                return lista;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EmpresaBE> ListaCombo()
        {
            try
            {
                EmpresaDL empresa = new EmpresaDL();
                List<EmpresaBE> lista = empresa.ListaCombo();
                return lista;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EmpresaBE> ListaComboCajaEgreso()
        {
            try
            {
                EmpresaDL empresa = new EmpresaDL();
                List<EmpresaBE> lista = empresa.ListaComboCajaEgreso();
                return lista;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EmpresaBE> ListaRUS()
        {
            try
            {
                EmpresaDL empresa = new EmpresaDL();
                List<EmpresaBE> lista = empresa.ListaRUS();
                return lista;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EmpresaBE Selecciona(int IdEmpresa)
        {
            try
            {
                EmpresaDL empresa = new EmpresaDL();
                EmpresaBE objEmp = empresa.Selecciona(IdEmpresa);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(EmpresaBE pItem)
        {
            try
            {
                EmpresaDL Empresa = new EmpresaDL();
                Empresa.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(EmpresaBE pItem)
        {
            try
            {
                EmpresaDL Empresa = new EmpresaDL();
                Empresa.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EmpresaBE pItem)
        {
            try
            {
                EmpresaDL Empresa = new EmpresaDL();
                Empresa.Elimina(pItem);
               
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
