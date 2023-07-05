using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ConPlanContableBL
    {
        public List<ConPlanContableBE> ListaTodosActivo()
        {
            try
            {
                ConPlanContableDL ConPlanContable = new ConPlanContableDL();
                return ConPlanContable.ListaTodosActivo();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ConPlanContableBE Selecciona(int IdConPlanContable)
        {
            try
            {
                ConPlanContableDL ConPlanContable = new ConPlanContableDL();
                return ConPlanContable.Selecciona(IdConPlanContable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ConPlanContableBE pItem)
        {
            try
            {
                ConPlanContableDL ConPlanContable = new ConPlanContableDL();
                ConPlanContable.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ConPlanContableBE pItem)
        {
            try
            {
                ConPlanContableDL ConPlanContable = new ConPlanContableDL();
                ConPlanContable.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ConPlanContableBE pItem)
        {
            try
            {
                ConPlanContableDL ConPlanContable = new ConPlanContableDL();
                ConPlanContable.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
