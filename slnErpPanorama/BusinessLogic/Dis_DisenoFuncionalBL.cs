using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class Dis_DisenoFuncionalBL
    {
        public List<Dis_DisenoFuncionalBE> ListaTodosActivo(int IdDis_ProyectoServicio)
        {
            try
            {
                Dis_DisenoFuncionalDL Dis_DisenoFuncional = new Dis_DisenoFuncionalDL();
                return Dis_DisenoFuncional.ListaTodosActivo(IdDis_ProyectoServicio);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(Dis_DisenoFuncionalBE pItem)
        {
            try
            {
                Dis_DisenoFuncionalDL Dis_DisenoFuncional = new Dis_DisenoFuncionalDL();
                Dis_DisenoFuncional.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(Dis_DisenoFuncionalBE pItem)
        {
            try
            {
                Dis_DisenoFuncionalDL Dis_DisenoFuncional = new Dis_DisenoFuncionalDL();
                Dis_DisenoFuncional.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(Dis_DisenoFuncionalBE pItem)
        {
            try
            {
                Dis_DisenoFuncionalDL Dis_DisenoFuncional = new Dis_DisenoFuncionalDL();
                Dis_DisenoFuncional.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
