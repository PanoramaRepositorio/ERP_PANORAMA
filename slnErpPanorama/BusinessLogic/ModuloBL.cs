using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ModuloBL
    {
        public List<ModuloBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ModuloDL Modulo = new ModuloDL();
                return Modulo.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ModuloBE pItem)
        {
            try
            {
                ModuloDL Modulo = new ModuloDL();
                Modulo.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ModuloBE pItem)
        {
            try
            {
                ModuloDL Modulo = new ModuloDL();
                Modulo.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ModuloBE pItem)
        {
            try
            {
                ModuloDL Modulo = new ModuloDL();
                Modulo.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}

