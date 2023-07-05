using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ProcedenciaBL
    {
        public List<ProcedenciaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ProcedenciaDL Procedencia = new ProcedenciaDL();
                return Procedencia.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ProcedenciaBE pItem)
        {
            try
            {
                ProcedenciaDL Procedencia = new ProcedenciaDL();
                Procedencia.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ProcedenciaBE pItem)
        {
            try
            {
                ProcedenciaDL Procedencia = new ProcedenciaDL();
                Procedencia.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ProcedenciaBE pItem)
        {
            try
            {
                ProcedenciaDL Procedencia = new ProcedenciaDL();
                Procedencia.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}

