using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class VariablesBL
    {
        //public List<VariablesBE> ListaTodosActivo(int IdEmpresa, int IdMoneda)
        //{
        //    try
        //    {
        //        VariablesDL Variables = new VariablesDL();
        //        return Variables.ListaTodosActivo(IdEmpresa, IdMoneda);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        public VariablesBE Selecciona(int IdEmpresa)
        {
            try
            {
                VariablesDL Variables = new VariablesDL();
                return Variables.Selecciona(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(VariablesBE pItem)
        {
            try
            {
                VariablesDL Variables = new VariablesDL();
                Variables.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(VariablesBE pItem)
        {
            try
            {
                VariablesDL Variables = new VariablesDL();
                Variables.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(VariablesBE pItem)
        {
            try
            {
                VariablesDL Variables = new VariablesDL();
                Variables.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
